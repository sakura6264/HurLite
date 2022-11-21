#define MyAppName "HurLite"
#define NameSmall "HurLite"
#define MyAppExeName "HurLite.exe"

[Setup]
AppId={{B4E70EF7-BC4B-4056-A055-6D74C8FFC053}
AppName={#MyAppName}
SetupIconFile=..\App\Assets\internet.ico
LicenseFile=..\LICENSE
InfoBeforeFile=..\README.md
AppVerName="HurLite"

UsePreviousAppDir=yes
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
PrivilegesRequired=admin

OutputDir=.
OutputBaseFilename=HurLite_Installer

ArchitecturesAllowed=x64
Compression=lzma
SolidCompression=yes
WizardStyle=modern

SetupLogging=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "..\App\bin\Release\netcoreapp3.1\*";Excludes: "*.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\App\bin\Release\netcoreapp3.1\runtimes\win\lib\netcoreapp3.1\*";Excludes: "*.pdb"; DestDir: "{app}\runtimes\win\lib\netcoreapp3.1"; Flags: ignoreversion

[Icons]
Name: "{autoprograms}\{#MyAppName}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Registry]
#define RootKey "HKCU"
#define URLAssociate "HandleURLHurLite65001"

Root: {#RootKey}; Subkey: "Software\Clients\StartMenuInternet\{#MyAppName}\Capabilities"; ValueType: string; ValueName: "ApplicationName"; ValueData: "{#MyAppName}"; Flags: uninsdeletekey
Root: {#RootKey}; Subkey: "Software\Clients\StartMenuInternet\{#MyAppName}\Capabilities"; ValueType: string; ValueName: "ApplicationDescription"; ValueData: "HurLite -- select browser dynamically"; Flags: uninsdeletekey
Root: {#RootKey}; Subkey: "Software\Clients\StartMenuInternet\{#MyAppName}\Capabilities"; ValueType: string; ValueName: "ApplicationIcon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletekey deletevalue

Root: {#RootKey}; Subkey: "Software\Clients\StartMenuInternet\{#MyAppName}\Capabilities\StartMenu"; ValueType: string; ValueName: "StartMenuInternet"; ValueData: "{#MyAppName}"; Flags: uninsdeletekey deletevalue
Root: {#RootKey}; Subkey: "Software\Clients\StartMenuInternet\{#MyAppName}\Capabilities\URLAssociations"; ValueType: string; ValueName: "http"; ValueData: "{#URLAssociate}"; Flags: uninsdeletekey
Root: {#RootKey}; Subkey: "Software\Clients\StartMenuInternet\{#MyAppName}\Capabilities\URLAssociations"; ValueType: string; ValueName: "https"; ValueData: "{#URLAssociate}"; Flags: uninsdeletekey

Root: {#RootKey}; Subkey: "Software\Clients\StartMenuInternet\{#MyAppName}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletekey deletevalue
Root: {#RootKey}; Subkey: "Software\Clients\StartMenuInternet\{#MyAppName}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"""; Flags: uninsdeletekey deletevalue

Root: {#RootKey}; Subkey: "Software\Classes\{#URLAssociate}"; ValueType: string; ValueName: ""; ValueData: "{#MyAppName} URL"; Flags: uninsdeletekey
Root: {#RootKey}; Subkey: "Software\Classes\{#URLAssociate}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#MyAppExeName},0"; Flags: deletevalue
Root: {#RootKey}; Subkey: "Software\Classes\{#URLAssociate}\shell\open"; ValueType: string; ValueName: "Icon"; ValueData: """{app}\{#MyAppExeName}"""; Flags: deletevalue
Root: {#RootKey}; Subkey: "Software\Classes\{#URLAssociate}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""; Flags: uninsdeletekey deletevalue

Root: {#RootKey}; Subkey: "Software\Classes\.html\OpenWithProgids"; ValueType: string; ValueName: "{#URLAssociate}"; ValueData: ""; Flags: uninsdeletevalue;
Root: {#RootKey}; Subkey: "Software\Classes\.htm\OpenWithProgids"; ValueType: string; ValueName: "{#URLAssociate}"; ValueData: ""; Flags: uninsdeletevalue;


Root: {#RootKey}; Subkey: "Software\RegisteredApplications"; ValueType: string; ValueName: "{#MyAppName}"; ValueData: "Software\Clients\StartMenuInternet\{#MyAppName}\Capabilities"; Flags: deletevalue uninsdeletevalue

[CustomMessages]
OtherOptions=Other Options