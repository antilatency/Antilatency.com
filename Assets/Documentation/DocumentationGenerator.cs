



using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Csml;


public partial class Api {
    //public static MultiLanguageGroup NamespaceDescription => new MultiLanguageGroup();
    //public static Paragraph NamespaceDescription_en => new Paragraph
    
}


public class DocumentationGenerator {

    public class Namespace {
        public string Name = "";
        public string FullName => Parent == null ? Name : Parent.FullName + "." + Name;
        public string FullNameWithZWS => Parent == null ? Name : Parent.FullNameWithZWS + "\\u200B." + Name;

        public Namespace Parent;
        public List<Namespace> namespaces = new List<Namespace>();
        public List<Type> types = new List<Type>();
        public Namespace(string name, Namespace parent = null) {
            Name = name;
            Parent = parent;
        }

        public void AddType(Type t, string[] ns, int id = 0) {
            if (id == ns.Length) {
                types.Add(t);
            } else {
                var subNs = namespaces.FirstOrDefault(x => x.Name == ns[id]);
                if (subNs == null) {
                    subNs = new Namespace(ns[id], this);
                    namespaces.Add(subNs);
                }
                subNs.AddType(t, ns, id + 1);
            }
        }

        public override string ToString() {
            return Name;
        }
    }
    Namespace global = new Namespace("Api");

    HashSet<Type> visibleTypes = new HashSet<Type>();


    public DocumentationGenerator(params Type[] types) {
        types.ForEach(x => CollectVisibleTypes(x));
        visibleTypes.ForEach(x => global.AddType(x, x.Namespace.Split(".")));
    }

    void CollectVisibleTypes(Type x) {

        if (x.IsInterface) {
            var interfaces = x.GetInterfaces();
            if (interfaces.Count() == 1) {
                CollectVisibleTypes(interfaces.First());
            }

            if (visibleTypes.Add(x)) {
                foreach (var m in x.GetMembers()) {
                    CollectVisibleTypes(m);
                }
            }
            return;
        }
        if (x.IsEnum) {
            if (visibleTypes.Add(x)) {

            }
            return;
        }
    }

    void CollectVisibleTypes(MemberInfo x) {
        if (x is MethodInfo) {
            var tx = x as MethodInfo;
            if (tx.ReturnType != null) {
                CollectVisibleTypes(tx.ReturnType);
            }
            foreach (var p in tx.GetParameters()) {
                CollectVisibleTypes(p.ParameterType);
            }
        }

    }


    public void Generate() {
        var outputPath = Path.Combine(Utils.ThisDirectory(), "Generated.cs");
        StringWriter stringWriter = new StringWriter();
        stringWriter.WriteLine("using Csml;");
        Generate(global).ForEach(x => stringWriter.WriteLine(x));


        File.WriteAllText(outputPath, stringWriter.ToString());
        /*
         Utils.DeleteDirectory(OutputRootDirectory);
        Utils.ThisDirectory
         */
    }



    public IEnumerable<string> Generate(Namespace ns) {
        yield return $"public sealed partial class {ns.Name} : Scope{{";
        
        yield return $"\tpublic static MultiLanguageGroup _Material => new MultiLanguageGroup(\"{ns.FullNameWithZWS}\");"; ;
        
        yield return $"\t int NumberOfTupes = {ns.types.Count};";
        yield return $"\t int NumberOfNamespaces = {ns.namespaces.Count};";

        StringWriter description = new StringWriter();
        if (ns.Parent == null) {//Api
            description.WriteLine("Full list of Api.");
        } else {
            description.WriteLine($"Namespace, a part of {{{ns.Parent.FullName}._Material}}");
        }
        description.WriteLine($"Number of nested namespaces: {ns.namespaces.Count} ");
        description.WriteLine($"Number of nested types: {ns.types.Count}");

        yield return $"\tpublic static Material _Material_en => new Material(_Material.Title, null, @$\"{description}.\");";




        foreach (var l in ns.namespaces.SelectMany(x => Generate(x))) {
            yield return "\t" + l;
        }
        foreach (var l in ns.types.SelectMany(x => Generate(x))) {
            yield return "\t" + l;
        }


        yield return "}";
    }

    public IEnumerable<string> Generate(Type x) {
        yield return $"public sealed partial class {x.Name} : Scope{{";
        
        yield return "}";
    }


}