using Csml;
public sealed partial class Api : Scope<Api>{
	public static MultiLanguageGroup _Material => new MultiLanguageGroup("Api");
	 int NumberOfTupes = 0;
	 int NumberOfNamespaces = 1;
	public static Material _Material_en => new Material(_Material.Title, null, @$"Full list of Api.
Number of nested namespaces: 1 
Number of nested types: 0
.");
	public sealed partial class Antilatency : Scope<Antilatency>{
		public static MultiLanguageGroup _Material => new MultiLanguageGroup("Api\u200B.Antilatency");
		 int NumberOfTupes = 0;
		 int NumberOfNamespaces = 2;
		public static Material _Material_en => new Material(_Material.Title, null, @$"Namespace, a part of {Api._Material}
Number of nested namespaces: 2 
Number of nested types: 0
.");
		public sealed partial class DeviceNetwork : Scope<DeviceNetwork>{
			public static MultiLanguageGroup _Material => new MultiLanguageGroup("Api\u200B.Antilatency\u200B.DeviceNetwork");
			 int NumberOfTupes = 6;
			 int NumberOfNamespaces = 1;
			public static Material _Material_en => new Material(_Material.Title, null, @$"Namespace, a part of {Api.Antilatency._Material}
Number of nested namespaces: 1 
Number of nested types: 6
.");
			public sealed partial class Interop : Scope<Interop>{
				public static MultiLanguageGroup _Material => new MultiLanguageGroup("Api\u200B.Antilatency\u200B.DeviceNetwork\u200B.Interop");
				 int NumberOfTupes = 1;
				 int NumberOfNamespaces = 0;
				public static Material _Material_en => new Material(_Material.Title, null, @$"Namespace, a part of {Api.Antilatency.DeviceNetwork._Material}
Number of nested namespaces: 0 
Number of nested types: 1
.");
				public sealed partial class IDataReceiver : Scope<IDataReceiver>{
				}
			}
			public sealed partial class ILibrary : Scope<ILibrary>{
			}
			public sealed partial class INetwork : Scope<INetwork>{
			}
			public sealed partial class NodeStatus : Scope<NodeStatus>{
			}
			public sealed partial class NodeHandle : Scope<NodeHandle>{
			}
			public sealed partial class ISynchronousConnection : Scope<ISynchronousConnection>{
			}
			public sealed partial class LogLevel : Scope<LogLevel>{
			}
		}
		public sealed partial class Alt : Scope<Alt>{
			public static MultiLanguageGroup _Material => new MultiLanguageGroup("Api\u200B.Antilatency\u200B.Alt");
			 int NumberOfTupes = 0;
			 int NumberOfNamespaces = 1;
			public static Material _Material_en => new Material(_Material.Title, null, @$"Namespace, a part of {Api.Antilatency._Material}
Number of nested namespaces: 1 
Number of nested types: 0
.");
			public sealed partial class Tracking : Scope<Tracking>{
				public static MultiLanguageGroup _Material => new MultiLanguageGroup("Api\u200B.Antilatency\u200B.Alt\u200B.Tracking");
				 int NumberOfTupes = 7;
				 int NumberOfNamespaces = 0;
				public static Material _Material_en => new Material(_Material.Title, null, @$"Namespace, a part of {Api.Antilatency.Alt._Material}
Number of nested namespaces: 0 
Number of nested types: 7
.");
				public sealed partial class ILibrary : Scope<ILibrary>{
				}
				public sealed partial class IEnvironment : Scope<IEnvironment>{
				}
				public sealed partial class ITrackingCotaskConstructor : Scope<ITrackingCotaskConstructor>{
				}
				public sealed partial class ITrackingCotask : Scope<ITrackingCotask>{
				}
				public sealed partial class ITrackingDataCotaskConstructor : Scope<ITrackingDataCotaskConstructor>{
				}
				public sealed partial class ITrackingDataCotask : Scope<ITrackingDataCotask>{
				}
				public sealed partial class ITrackingDataCallback : Scope<ITrackingDataCallback>{
				}
			}
		}
	}
}
