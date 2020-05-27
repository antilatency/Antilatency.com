//Generated by AntilatencyApiGenerator
using Csml;
public sealed partial class Api : Scope {
	public sealed partial class Antilatency : Scope {
		public sealed partial class DeviceNetwork : Scope {
			public sealed partial class Tasks : Scope {
				public sealed partial class Tests : Scope {
					public sealed partial class Dummy : Scope {
						public static IElement _FullNameRef => new Deferred(()=>Material).Modify().AddClasses("Namespace");
						public static IElement FullNameRefCode => _FullNameRef.Modify().Wrap("code");
						public static Material Material => new Material("Antilatency.DeviceNetwork.Tasks.Tests.Dummy",null,$"Namespace in `{Api.Antilatency.DeviceNetwork.Tasks.Tests._FullNameRef}`")[new Section("Types")
							[new UnorderedList()
								[$"*constant group* `{Constants._NameRef}`"]
								[$"*interface* `{IHostToDevice._NameRef}`"]
								[$"*interface* `{IDeviceToHost._NameRef}`"]
							]
						];
						public sealed partial class Constants : Scope {
							public static IElement _NameRef => new Deferred(()=>Material).Modify().ContentReplace($"Constants").AddClasses("Type");
							public static IElement NameRefCode => _NameRef.Modify().Wrap("code");
							public static IElement _FullNameRef => new Text($"{Dummy._FullNameRef}.{_NameRef}");
							public static IElement FullNameRefCode => _FullNameRef.Modify().Wrap("code");
							public static Material Material => new Material("Antilatency.DeviceNetwork.Tasks.Tests.Dummy.Constants",null,$"Constants in `{Api.Antilatency.DeviceNetwork.Tasks.Tests.Dummy._FullNameRef}`")[CodeBlock];
							public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
							public static IElement RawDeclarationCode => new Text($"{Fields.TaskID.RawDeclarationCode}");
							public sealed partial class Fields : Scope {
								public sealed partial class TaskID : Scope {
									public static IElement _Name => new Modify($"TaskID").AddClasses("Constant").SetAttributeValue("title", "{{8b214fba-4bc8-4521-9ada-47797e542d61}}");
									public static IElement NameCode => _Name.Modify().Wrap("code");
									public static System.Guid Value => new System.Guid("8b214fba-4bc8-4521-9ada-47797e542d61");
									public static IElement RawDeclarationCode => new Text($"{Keyword("Guid")} {_Name} = {_Value}");
									public static IElement _Value => new Text($"{{8b214fba-4bc8-4521-9ada-47797e542d61}}");
								} //scope TaskID
							} //scope Fields
						} //scope Constants
						
						public sealed partial class IHostToDevice : Scope {
							public static IElement _NameRef => new Deferred(()=>Material).Modify().ContentReplace($"IHostToDevice").AddClasses("Type");
							public static IElement NameRefCode => _NameRef.Modify().Wrap("code");
							public static IElement _FullNameRef => new Text($"{Dummy._FullNameRef}.{_NameRef}");
							public static IElement FullNameRefCode => _FullNameRef.Modify().Wrap("code");
							public static IElement RawDeclarationCode => new Text($"{Interface} {_NameRef} : InterfaceContract.{Type("IInterface")} {{\n}}");
							public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
							public static Material Material => new Material("Antilatency.DeviceNetwork.Tasks.Tests.Dummy.IHostToDevice",null,$"Interface in `{Api.Antilatency.DeviceNetwork.Tasks.Tests.Dummy._FullNameRef}`")[CodeBlock];
							public sealed partial class Methods : Scope {
							} //scope Methods
						} //scope IHostToDevice
						
						public sealed partial class IDeviceToHost : Scope {
							public static IElement _NameRef => new Deferred(()=>Material).Modify().ContentReplace($"IDeviceToHost").AddClasses("Type");
							public static IElement NameRefCode => _NameRef.Modify().Wrap("code");
							public static IElement _FullNameRef => new Text($"{Dummy._FullNameRef}.{_NameRef}");
							public static IElement FullNameRefCode => _FullNameRef.Modify().Wrap("code");
							public static IElement RawDeclarationCode => new Text($"{Interface} {_NameRef} : InterfaceContract.{Type("IInterface")} {{\n}}");
							public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
							public static Material Material => new Material("Antilatency.DeviceNetwork.Tasks.Tests.Dummy.IDeviceToHost",null,$"Interface in `{Api.Antilatency.DeviceNetwork.Tasks.Tests.Dummy._FullNameRef}`")[CodeBlock];
							public sealed partial class Methods : Scope {
							} //scope Methods
						} //scope IDeviceToHost
						
						
					} //scope Dummy
				} //scope Tests
			} //scope Tasks
		} //scope DeviceNetwork
	} //scope Antilatency
} //scope Api
