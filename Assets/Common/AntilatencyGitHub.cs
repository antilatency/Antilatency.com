using Csml;

public class AntilatencyGitHub : Scope {
    public static Csml.GitHub.Owner Owner => new Csml.GitHub.Owner("antilatency");

    public class AntilatencyCom_Master : Scope {
        static public Csml.GitHub.RepositoryBranch RepositoryBranch => Owner.GetRepositoryBranchPinned("Antilatency.com");
        static public CSharpCode Program => new CSharpCode(RepositoryBranch.GetFile("Program.cs"));
    }

    public class TrackingMinimalDemoCSharp_Master : Scope {
        static public Csml.GitHub.RepositoryBranch RepositoryBranch => Owner.GetRepositoryBranchPinned("TrackingMinimalDemoCSharp");
        static public CSharpCode Program => new CSharpCode(RepositoryBranch.GetFile("Program.cs"));
    }


}