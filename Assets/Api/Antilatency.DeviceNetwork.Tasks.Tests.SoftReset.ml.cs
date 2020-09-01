//Generated by AntilatencyApiGenerator
#pragma warning disable IDE1006 // Do not warn about naming style violations
using Csml;
using static ApiStatic;
public sealed partial class Api : Scope {
	public sealed partial class Antilatency : Scope {
		public sealed partial class DeviceNetwork : Scope {
			public sealed partial class Tasks : Scope {
				public sealed partial class Tests : Scope {
					public sealed partial class SoftReset : Scope {
						public static IElement _NameRef => new Deferred(()=>Material).Modify().ContentReplace($"SoftReset").AddClasses("Namespace");
						public static IElement NameRefCode => _NameRef.Modify().Wrap("code");
						public static IElement _FullNameRef => new Text($"{Antilatency.DeviceNetwork.Tasks.Tests._FullNameRef}.{_NameRef}");
						public static IElement FullNameRefCode => _FullNameRef.Modify().Wrap("code");
						public static Material Material => new Material("Antilatency.DeviceNetwork.Tasks.Tests.SoftReset",null,$"Namespace in `{Api.Antilatency.DeviceNetwork.Tasks.Tests._FullNameRef}`")
							[new Section("Types")
								[new UnorderedList()
									[$"*constant group* {Constants.NameRefCode}"]
									[$"*interface* {IHostToDevice.NameRefCode}"]
									[$"*interface* {IDeviceToHost.NameRefCode}"]
								]
							]
							;
						public sealed partial class Constants : Scope {
							public static IElement _NameRef => new Deferred(()=>Material).Modify().ContentReplace($"Constants").AddClasses("Type");
							public static IElement NameRefCode => _NameRef.Modify().Wrap("code");
							public static IElement _FullNameRef => new Text($"{SoftReset._FullNameRef}.{_NameRef}");
							public static IElement FullNameRefCode => _FullNameRef.Modify().Wrap("code");
							public static Material Material => new Material("Antilatency.DeviceNetwork.Tasks.Tests.SoftReset.Constants",null,$"Constants in `{Api.Antilatency.DeviceNetwork.Tasks.Tests.SoftReset._FullNameRef}`")[CodeBlock];
							public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
							public static IElement RawDeclarationCode => new Text($"{Fields.TaskID.RawDeclarationCode}");
							public sealed partial class Fields : Scope {
								public sealed partial class TaskID : Scope {
									public static IElement _Name => new Modify($"TaskID").AddClasses("Constant").Attribute("title", "{{0fc93b8d-1df4-447c-bb9b-3502541b99e6}}");
									public static IElement NameCode => _Name.Modify().Wrap("code");
									public static System.Guid Value => new System.Guid("0fc93b8d-1df4-447c-bb9b-3502541b99e6");
									public static IElement RawDeclarationCode => new Text($"{Keyword("Guid")} {_Name} = {_Value}");
									public static IElement _Value => new Text($"{{0fc93b8d-1df4-447c-bb9b-3502541b99e6}}");
								} //scope TaskID
							} //scope Fields
						} //scope Constants
						
						public sealed partial class IHostToDevice : Scope {
							public static IElement _NameRef => new Deferred(()=>Material).Modify().ContentReplace($"IHostToDevice").AddClasses("Type");
							public static IElement NameRefCode => _NameRef.Modify().Wrap("code");
							public static IElement _FullNameRef => new Text($"{SoftReset._FullNameRef}.{_NameRef}");
							public static IElement FullNameRefCode => _FullNameRef.Modify().Wrap("code");
							public static IElement RawDeclarationCode => new Text($"{Interface} {_NameRef} : {Namespace("InterfaceContract")}.{Type("IInterface")} {{\n    {Methods.timeout.RawDeclarationCode};\n}}");
							public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
							public static Material Material => new Material("Antilatency.DeviceNetwork.Tasks.Tests.SoftReset.IHostToDevice",null,$"Interface in `{Api.Antilatency.DeviceNetwork.Tasks.Tests.SoftReset._FullNameRef}`")[CodeBlock];
							public sealed partial class Methods : Scope {
								public sealed partial class timeout : Scope {
									public static IElement _NameRef => new Deferred(()=>Material).Modify().ContentReplace($"timeout").AddClasses("Method");
									public static IElement NameRefCode => _NameRef.Modify().Wrap("code");
									public static IElement _FullNameRef => new Text($"{IHostToDevice._FullNameRef}.{_NameRef}");
									public static IElement FullNameRefCode => _FullNameRef.Modify().Wrap("code");
									public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
									public static IElement CodeInline => CodeInline(RawDeclarationCode);
									public static IElement RawDeclarationCode => new Text($"{Keyword("void")} {_NameRef}({Parameters.delay.RawDeclarationCode})");
									public static Material Material => new Material("Antilatency.DeviceNetwork.Tasks.Tests.SoftReset.IHostToDevice.timeout",null,$"Method of `{Api.Antilatency.DeviceNetwork.Tasks.Tests.SoftReset.IHostToDevice._NameRef}`\n`{RawDeclarationCode}`")
										[new Section("Parameters")]
										;
									public sealed partial class Parameters : Scope {
										public sealed partial class delay : Scope {
											public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
											public static IElement CodeInline => CodeInline(RawDeclarationCode);
											public static IElement RawDeclarationCode => new Text($"{Keyword("uint")} {_Name}");
											public static IElement _Name => new Modify($"delay").Attribute("title", "parameter delay");
											public static IElement NameCode => _Name.Modify().Wrap("code");
										} //scope delay
									} //scope Parameters
								} //scope timeout
							} //scope Methods
						} //scope IHostToDevice
						
						public sealed partial class IDeviceToHost : Scope {
							public static IElement _NameRef => new Deferred(()=>Material).Modify().ContentReplace($"IDeviceToHost").AddClasses("Type");
							public static IElement NameRefCode => _NameRef.Modify().Wrap("code");
							public static IElement _FullNameRef => new Text($"{SoftReset._FullNameRef}.{_NameRef}");
							public static IElement FullNameRefCode => _FullNameRef.Modify().Wrap("code");
							public static IElement RawDeclarationCode => new Text($"{Interface} {_NameRef} : {Namespace("InterfaceContract")}.{Type("IInterface")} {{\n}}");
							public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
							public static Material Material => new Material("Antilatency.DeviceNetwork.Tasks.Tests.SoftReset.IDeviceToHost",null,$"Interface in `{Api.Antilatency.DeviceNetwork.Tasks.Tests.SoftReset._FullNameRef}`")[CodeBlock];
							public sealed partial class Methods : Scope {
							} //scope Methods
						} //scope IDeviceToHost
						
						
					} //scope SoftReset
				} //scope Tests
			} //scope Tasks
		} //scope DeviceNetwork
	} //scope Antilatency
} //scope Api
