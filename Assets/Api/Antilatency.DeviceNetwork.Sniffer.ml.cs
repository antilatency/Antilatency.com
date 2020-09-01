//Generated by AntilatencyApiGenerator
#pragma warning disable IDE1006 // Do not warn about naming style violations
using Csml;
using static ApiStatic;
public sealed partial class Api : Scope {
	public sealed partial class Antilatency : Scope {
		public sealed partial class DeviceNetwork : Scope {
			public sealed partial class Sniffer : Scope {
				public static IElement _NameRef => new Deferred(()=>Material).Modify().ContentReplace($"Sniffer").AddClasses("Namespace");
				public static IElement NameRefCode => _NameRef.Modify().Wrap("code");
				public static IElement _FullNameRef => new Text($"{Antilatency.DeviceNetwork._FullNameRef}.{_NameRef}");
				public static IElement FullNameRefCode => _FullNameRef.Modify().Wrap("code");
				public static Material Material => new Material("Antilatency.DeviceNetwork.Sniffer",null,$"Namespace in `{Api.Antilatency.DeviceNetwork._FullNameRef}`")
					[new Section("Types")
						[new UnorderedList()
							[$"*interface* {ISniffer.NameRefCode}"]
							[$"*interface* {ISnifferable.NameRefCode}"]
						]
					]
					;
				public sealed partial class ISniffer : Scope {
					public static IElement _NameRef => new Deferred(()=>Material).Modify().ContentReplace($"ISniffer").AddClasses("Type");
					public static IElement NameRefCode => _NameRef.Modify().Wrap("code");
					public static IElement _FullNameRef => new Text($"{Sniffer._FullNameRef}.{_NameRef}");
					public static IElement FullNameRefCode => _FullNameRef.Modify().Wrap("code");
					public static IElement RawDeclarationCode => new Text($"{Interface} {_NameRef} : {Namespace("InterfaceContract")}.{Type("IInterface")} {{\n    {Methods.onDeviceConnected.RawDeclarationCode};\n    {Methods.onDeviceDisconnected.RawDeclarationCode};\n    {Methods.onDataRx.RawDeclarationCode};\n    {Methods.onDataTx.RawDeclarationCode};\n}}");
					public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
					public static Material Material => new Material("Antilatency.DeviceNetwork.Sniffer.ISniffer",null,$"Interface in `{Api.Antilatency.DeviceNetwork.Sniffer._FullNameRef}`")[CodeBlock];
					public sealed partial class Methods : Scope {
						public sealed partial class onDeviceConnected : Scope {
							public static IElement _NameRef => new Deferred(()=>Material).Modify().ContentReplace($"onDeviceConnected").AddClasses("Method");
							public static IElement NameRefCode => _NameRef.Modify().Wrap("code");
							public static IElement _FullNameRef => new Text($"{ISniffer._FullNameRef}.{_NameRef}");
							public static IElement FullNameRefCode => _FullNameRef.Modify().Wrap("code");
							public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
							public static IElement CodeInline => CodeInline(RawDeclarationCode);
							public static IElement RawDeclarationCode => new Text($"{Keyword("void")} {_NameRef}({Parameters.name.RawDeclarationCode}, {Parameters.id.RawDeclarationCode})");
							public static Material Material => new Material("Antilatency.DeviceNetwork.Sniffer.ISniffer.onDeviceConnected",null,$"Method of `{Api.Antilatency.DeviceNetwork.Sniffer.ISniffer._NameRef}`\n`{RawDeclarationCode}`")
								[new Section("Parameters")]
								;
							public sealed partial class Parameters : Scope {
								public sealed partial class name : Scope {
									public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
									public static IElement CodeInline => CodeInline(RawDeclarationCode);
									public static IElement RawDeclarationCode => new Text($"{Keyword("string")} {_Name}");
									public static IElement _Name => new Modify($"name").Attribute("title", "parameter name");
									public static IElement NameCode => _Name.Modify().Wrap("code");
								} //scope name
								public sealed partial class id : Scope {
									public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
									public static IElement CodeInline => CodeInline(RawDeclarationCode);
									public static IElement RawDeclarationCode => new Text($"{Keyword("uint")} {_Name}");
									public static IElement _Name => new Modify($"id").Attribute("title", "parameter id");
									public static IElement NameCode => _Name.Modify().Wrap("code");
								} //scope id
							} //scope Parameters
						} //scope onDeviceConnected
						public sealed partial class onDeviceDisconnected : Scope {
							public static IElement _NameRef => new Deferred(()=>Material).Modify().ContentReplace($"onDeviceDisconnected").AddClasses("Method");
							public static IElement NameRefCode => _NameRef.Modify().Wrap("code");
							public static IElement _FullNameRef => new Text($"{ISniffer._FullNameRef}.{_NameRef}");
							public static IElement FullNameRefCode => _FullNameRef.Modify().Wrap("code");
							public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
							public static IElement CodeInline => CodeInline(RawDeclarationCode);
							public static IElement RawDeclarationCode => new Text($"{Keyword("void")} {_NameRef}({Parameters.id.RawDeclarationCode})");
							public static Material Material => new Material("Antilatency.DeviceNetwork.Sniffer.ISniffer.onDeviceDisconnected",null,$"Method of `{Api.Antilatency.DeviceNetwork.Sniffer.ISniffer._NameRef}`\n`{RawDeclarationCode}`")
								[new Section("Parameters")]
								;
							public sealed partial class Parameters : Scope {
								public sealed partial class id : Scope {
									public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
									public static IElement CodeInline => CodeInline(RawDeclarationCode);
									public static IElement RawDeclarationCode => new Text($"{Keyword("uint")} {_Name}");
									public static IElement _Name => new Modify($"id").Attribute("title", "parameter id");
									public static IElement NameCode => _Name.Modify().Wrap("code");
								} //scope id
							} //scope Parameters
						} //scope onDeviceDisconnected
						public sealed partial class onDataRx : Scope {
							public static IElement _NameRef => new Deferred(()=>Material).Modify().ContentReplace($"onDataRx").AddClasses("Method");
							public static IElement NameRefCode => _NameRef.Modify().Wrap("code");
							public static IElement _FullNameRef => new Text($"{ISniffer._FullNameRef}.{_NameRef}");
							public static IElement FullNameRefCode => _FullNameRef.Modify().Wrap("code");
							public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
							public static IElement CodeInline => CodeInline(RawDeclarationCode);
							public static IElement RawDeclarationCode => new Text($"{Keyword("void")} {_NameRef}({Parameters.id.RawDeclarationCode}, {Parameters.data.RawDeclarationCode}, {Parameters.size.RawDeclarationCode})");
							public static Material Material => new Material("Antilatency.DeviceNetwork.Sniffer.ISniffer.onDataRx",null,$"Method of `{Api.Antilatency.DeviceNetwork.Sniffer.ISniffer._NameRef}`\n`{RawDeclarationCode}`")
								[new Section("Parameters")]
								;
							public sealed partial class Parameters : Scope {
								public sealed partial class id : Scope {
									public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
									public static IElement CodeInline => CodeInline(RawDeclarationCode);
									public static IElement RawDeclarationCode => new Text($"{Keyword("uint")} {_Name}");
									public static IElement _Name => new Modify($"id").Attribute("title", "parameter id");
									public static IElement NameCode => _Name.Modify().Wrap("code");
								} //scope id
								public sealed partial class data : Scope {
									public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
									public static IElement CodeInline => CodeInline(RawDeclarationCode);
									public static IElement RawDeclarationCode => new Text($"{Keyword("constPointer")} {_Name}");
									public static IElement _Name => new Modify($"data").Attribute("title", "parameter data");
									public static IElement NameCode => _Name.Modify().Wrap("code");
								} //scope data
								public sealed partial class size : Scope {
									public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
									public static IElement CodeInline => CodeInline(RawDeclarationCode);
									public static IElement RawDeclarationCode => new Text($"{Keyword("uint")} {_Name}");
									public static IElement _Name => new Modify($"size").Attribute("title", "parameter size");
									public static IElement NameCode => _Name.Modify().Wrap("code");
								} //scope size
							} //scope Parameters
						} //scope onDataRx
						public sealed partial class onDataTx : Scope {
							public static IElement _NameRef => new Deferred(()=>Material).Modify().ContentReplace($"onDataTx").AddClasses("Method");
							public static IElement NameRefCode => _NameRef.Modify().Wrap("code");
							public static IElement _FullNameRef => new Text($"{ISniffer._FullNameRef}.{_NameRef}");
							public static IElement FullNameRefCode => _FullNameRef.Modify().Wrap("code");
							public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
							public static IElement CodeInline => CodeInline(RawDeclarationCode);
							public static IElement RawDeclarationCode => new Text($"{Keyword("void")} {_NameRef}({Parameters.id.RawDeclarationCode}, {Parameters.data.RawDeclarationCode}, {Parameters.size.RawDeclarationCode})");
							public static Material Material => new Material("Antilatency.DeviceNetwork.Sniffer.ISniffer.onDataTx",null,$"Method of `{Api.Antilatency.DeviceNetwork.Sniffer.ISniffer._NameRef}`\n`{RawDeclarationCode}`")
								[new Section("Parameters")]
								;
							public sealed partial class Parameters : Scope {
								public sealed partial class id : Scope {
									public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
									public static IElement CodeInline => CodeInline(RawDeclarationCode);
									public static IElement RawDeclarationCode => new Text($"{Keyword("uint")} {_Name}");
									public static IElement _Name => new Modify($"id").Attribute("title", "parameter id");
									public static IElement NameCode => _Name.Modify().Wrap("code");
								} //scope id
								public sealed partial class data : Scope {
									public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
									public static IElement CodeInline => CodeInline(RawDeclarationCode);
									public static IElement RawDeclarationCode => new Text($"{Keyword("constPointer")} {_Name}");
									public static IElement _Name => new Modify($"data").Attribute("title", "parameter data");
									public static IElement NameCode => _Name.Modify().Wrap("code");
								} //scope data
								public sealed partial class size : Scope {
									public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
									public static IElement CodeInline => CodeInline(RawDeclarationCode);
									public static IElement RawDeclarationCode => new Text($"{Keyword("uint")} {_Name}");
									public static IElement _Name => new Modify($"size").Attribute("title", "parameter size");
									public static IElement NameCode => _Name.Modify().Wrap("code");
								} //scope size
							} //scope Parameters
						} //scope onDataTx
					} //scope Methods
				} //scope ISniffer
				
				public sealed partial class ISnifferable : Scope {
					public static IElement _NameRef => new Deferred(()=>Material).Modify().ContentReplace($"ISnifferable").AddClasses("Type");
					public static IElement NameRefCode => _NameRef.Modify().Wrap("code");
					public static IElement _FullNameRef => new Text($"{Sniffer._FullNameRef}.{_NameRef}");
					public static IElement FullNameRefCode => _FullNameRef.Modify().Wrap("code");
					public static IElement RawDeclarationCode => new Text($"{Interface} {_NameRef} : {Namespace("InterfaceContract")}.{Type("IInterface")} {{\n    {Methods.setSniffer.RawDeclarationCode};\n}}");
					public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
					public static Material Material => new Material("Antilatency.DeviceNetwork.Sniffer.ISnifferable",null,$"Interface in `{Api.Antilatency.DeviceNetwork.Sniffer._FullNameRef}`")[CodeBlock];
					public sealed partial class Methods : Scope {
						public sealed partial class setSniffer : Scope {
							public static IElement _NameRef => new Deferred(()=>Material).Modify().ContentReplace($"setSniffer").AddClasses("Method");
							public static IElement NameRefCode => _NameRef.Modify().Wrap("code");
							public static IElement _FullNameRef => new Text($"{ISnifferable._FullNameRef}.{_NameRef}");
							public static IElement FullNameRefCode => _FullNameRef.Modify().Wrap("code");
							public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
							public static IElement CodeInline => CodeInline(RawDeclarationCode);
							public static IElement RawDeclarationCode => new Text($"{Keyword("void")} {_NameRef}({Parameters.sniffer.RawDeclarationCode})");
							public static Material Material => new Material("Antilatency.DeviceNetwork.Sniffer.ISnifferable.setSniffer",null,$"Method of `{Api.Antilatency.DeviceNetwork.Sniffer.ISnifferable._NameRef}`\n`{RawDeclarationCode}`")
								[new Section("Parameters")]
								;
							public sealed partial class Parameters : Scope {
								public sealed partial class sniffer : Scope {
									public static IElement CodeBlock => CodeBlock(RawDeclarationCode);
									public static IElement CodeInline => CodeInline(RawDeclarationCode);
									public static IElement RawDeclarationCode => new Text($"{Api.Antilatency.DeviceNetwork.Sniffer.ISniffer._NameRef} {_Name}");
									public static IElement _Name => new Modify($"sniffer").Attribute("title", "parameter sniffer");
									public static IElement NameCode => _Name.Modify().Wrap("code");
								} //scope sniffer
							} //scope Parameters
						} //scope setSniffer
					} //scope Methods
				} //scope ISnifferable
				
				
			} //scope Sniffer
		} //scope DeviceNetwork
	} //scope Antilatency
} //scope Api
