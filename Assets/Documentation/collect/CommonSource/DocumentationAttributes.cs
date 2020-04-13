using System;
using System.Reflection;

public static class Documentation {
    public static Format format = Format.XML;
    public const int NewLine = 0;
    public const int See = 1;
    public const int see = 2;
    public const int Code = 3;
    public const int code = 4;

    public enum Format {
        XML
    };

    /*public static void generate (CodeWriter code, Attribute[] attributes) {
        foreach (var a in attributes) {
            a.write(code);
        }
    }

    public static void generate(CodeWriter code, Type type) {
        var attributes = (Attribute[]) type.GetCustomAttributes(typeof(Attribute), false);
        generate(code,attributes);
    }

    public static void generate(CodeWriter code, MemberInfo memberInfo) {
        var attributes = (Attribute[])memberInfo.GetCustomAttributes(typeof(Attribute), false);
        generate(code,attributes);
    }


    public abstract class Attribute : System.Attribute {
        public abstract void write(CodeWriter code);
    }*/


    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class TagAttribute : Attribute {
        string tag;
        object[] items;
        public TagAttribute(string tag, params object[] items) {
            this.tag = tag;
            this.items = items;
        }
        /*public override void write(CodeWriter _code)  {

            if (format == Format.XML) {
                _code.append("/// <").append(tag).append(">");
                foreach(var i in items) {
                    if (i is string) {
                        bool firstLine = true;
                        foreach (var l in (i as string).Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)) {
                            if (!firstLine) _code.newLine().append("/// ");
                            _code.append(l);
                            firstLine = false;
                        }
                    } else if (i is int) {
                        int id = (int)i;
                        switch (id) {
                            case NewLine:
                                _code.newLine().append("/// ");
                                break;
                            case See:
                                _code.append("<see cref=\"");
                                break;

                            case see:
                                _code.append("\"/>");
                                break;

                            case Code:
                                _code.append("<code>");
                                break;
                            case code:
                                _code.append("</code>");
                                break;
                        }
                    } else if (i is Type){
                        Type t = i as Type;
                        _code.append(t.Namespace).append('.').append(t.Name);
                    }
                }
                
                _code.append("</").append(tag).append(">").newLine();
            }          
        } */ 
    }

    public class SummaryAttribute : TagAttribute {
        public SummaryAttribute( params object[] items) : base("summary", items) {
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ReturnsAttribute : TagAttribute {
        public ReturnsAttribute(params object[] items) : base("returns", items) {
        }
    }

    public class ExampleAttribute : TagAttribute {
        public ExampleAttribute(params object[] items) : base("example", items) {
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ParameterAttribute : Attribute {
        string name;
        string text;
        public ParameterAttribute(string name, string text) {
            this.name = name;
            this.text = text;
        }
        /*public override void write(CodeWriter code) {
            if (format == Format.XML) {
                code.append("/// <param name = \"").append(name).append("\">").newLine();
                foreach (var l in text.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)) {
                    code.append("/// ").append(l).newLine();
                }
                code.append("/// </param>").newLine();
            }
        }*/
    }



}