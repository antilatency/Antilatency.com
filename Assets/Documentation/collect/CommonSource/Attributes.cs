using System;
using System.Runtime.CompilerServices;



public class SourceCodeMarkerAttribute: Attribute {
    public string memberName;
    public string sourceFilePath;
    public int sourceLineNumber;
    public SourceCodeMarkerAttribute([CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0) {
        this.memberName = memberName;
        this.sourceFilePath = sourceFilePath;
        this.sourceLineNumber = sourceLineNumber;
}
}



[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
public class InRefAttribute : Attribute {}

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
public class OutRefAttribute : Attribute { }

[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = false)]
public class ConstAttribute : Attribute { }

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class NoThrowAttribute : SourceCodeMarkerAttribute {
    public NoThrowAttribute(
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0
        ) : base(memberName, sourceFilePath, sourceLineNumber) {
    }
}

//ANTILATENCY_ENUM_INTEGER_BEHAVIOUR_UNSIGNED
//ANTILATENCY_ENUM_INTEGER_BEHAVIOUR_SIGNED
[AttributeUsage(AttributeTargets.Enum, AllowMultiple = false)]
public class IntegerBehaviour : Attribute { }



namespace Antilatency.DeviceNetwork {
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class PacketIdAttribute : SourceCodeMarkerAttribute {
        public uint id;
        public PacketIdAttribute(uint id,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
            ):base(memberName,sourceFilePath,sourceLineNumber) {
            this.id = id;
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class BarrieredByAttribute : SourceCodeMarkerAttribute {
        public string methodName;
        public BarrieredByAttribute(string methodName,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
            ) : base(memberName, sourceFilePath, sourceLineNumber) {
            this.methodName = methodName;
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class BarrieredByItselfAttribute : BarrieredByAttribute {
        public BarrieredByItselfAttribute(
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
            ) : base(memberName, memberName, sourceFilePath, sourceLineNumber) {
        }
    }


}


