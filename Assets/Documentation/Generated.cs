using Csml;
public sealed partial class Api : Scope{
	public static MultiLanguageGroup _Material => new MultiLanguageGroup("Api");
	 int NumberOfTupes = 0;
	 int NumberOfNamespaces = 1;
	public static Material _Material_en => new Material(_Material.Title, null, @$"Full list of Api.
Number of nested namespaces: 1 
Number of nested types: 0
.");
	public sealed partial class Antilatency : Scope{
		public static MultiLanguageGroup _Material => new MultiLanguageGroup("Api\u200B.Antilatency");
		 int NumberOfTupes = 0;
		 int NumberOfNamespaces = 2;
		public static Material _Material_en => new Material(_Material.Title, null, @$"Namespace, a part of {Api._Material}
Number of nested namespaces: 2 
Number of nested types: 0
.");
		public sealed partial class DeviceNetwork : Scope{
			public static MultiLanguageGroup _Material => new MultiLanguageGroup("Api\u200B.Antilatency\u200B.DeviceNetwork");
			 int NumberOfTupes = 6;
			 int NumberOfNamespaces = 1;
			public static Material _Material_en => new Material(_Material.Title, null, @$"Namespace, a part of {Api.Antilatency._Material}
Number of nested namespaces: 1 
Number of nested types: 6
.");
			public sealed partial class Interop : Scope{
				public static MultiLanguageGroup _Material => new MultiLanguageGroup("Api\u200B.Antilatency\u200B.DeviceNetwork\u200B.Interop");
				 int NumberOfTupes = 1;
				 int NumberOfNamespaces = 0;
				public static Material _Material_en => new Material(_Material.Title, null, @$"Namespace, a part of {Api.Antilatency.DeviceNetwork._Material}
Number of nested namespaces: 0 
Number of nested types: 1
.");
				public sealed partial class IDataReceiver : Scope{
				}
			}
			public sealed partial class ILibrary : Scope{
			}
			public sealed partial class INetwork : Scope{
			}
			public sealed partial class NodeStatus : Scope{
			}
			public sealed partial class NodeHandle : Scope{
			}
			public sealed partial class ISynchronousConnection : Scope{
			}
			public sealed partial class LogLevel : Scope{
			}
		}
		public sealed partial class Alt : Scope{
			public static MultiLanguageGroup _Material => new MultiLanguageGroup("Api\u200B.Antilatency\u200B.Alt");
			 int NumberOfTupes = 0;
			 int NumberOfNamespaces = 1;
			public static Material _Material_en => new Material(_Material.Title, null, @$"Namespace, a part of {Api.Antilatency._Material}
Number of nested namespaces: 1 
Number of nested types: 0
.");
			public sealed partial class Tracking : Scope{
				public static MultiLanguageGroup _Material => new MultiLanguageGroup("Api\u200B.Antilatency\u200B.Alt\u200B.Tracking");
				 int NumberOfTupes = 7;
				 int NumberOfNamespaces = 0;
				public static Material _Material_en => new Material(_Material.Title, null, @$"Namespace, a part of {Api.Antilatency.Alt._Material}
Number of nested namespaces: 0 
Number of nested types: 7
.");
				public sealed partial class ILibrary : Scope{
				}
				public sealed partial class IEnvironment : Scope{
				}
				public sealed partial class ITrackingCotaskConstructor : Scope{
				}
				public sealed partial class ITrackingCotask : Scope{
				}
				public sealed partial class ITrackingDataCotaskConstructor : Scope{
				}
				public sealed partial class ITrackingDataCotask : Scope{
				}
				public sealed partial class ITrackingDataCallback : Scope{
				}
			}
		}
	}
}
