unit DkMagnusRegistry;

interface

uses
  classes,
  registry,
  SysUtils;

type
  EInvalidRegistryPath = class(Exception);
  ENotImplemented = class(Exception);

  IMagnusRegistry = interface(IUnknown)
    ['{89C1A2DF-3871-4833-964A-308C4104BEC7}']
    function ReadValue(const path : string) : string;
    procedure WriteValue(const path : string; const value : string);
  end;

  (*
    Knows how to interpret a path in registry context.

  *)
  TRegistryPath = class(TObject)
    private
      fStrings : TStringList;
      function GetKey : string;
      function GetFullPath : string;
      function GetCount : integer;
      function GetRoot : string;
      function GetPropertyName : string;
      function GetSection() : string;
      class function ContainsEmptyElements(const strings : TStringList) : boolean;
      class procedure ValidateRegistryPathElements(const strings : TStringList);
      class function TrimLastItemIfEmpty(strings : TStringList) : TStringList;
    public
      class procedure FreeIfAssigned(const registryPath : TRegistryPath);
      constructor Create(const path : string);
      destructor Destroy();override;
      property Count : integer read GetCount;
      property Key : string read GetKey;
      property FullPath : string read GetFullPath;
      property Root : string read GetRoot;
      property Section : string read GetSection;
      property PropertyName : string read GetPropertyName;
      class function TrimLastCharIfEmpty(const path : string) : string;
      class function CreatePathStrings(const path : string) : TStringList;
      class function CreateStringsRaw() : TStringList;
    const
      DELEMITER = '\';
      //there are more names: http://en.wikipedia.org/wiki/Windows_Registry
      VALID_NAMES : array[0..2] of string =('HKEY_CURRENT_USER','HKEY_LOCAL_MACHINE','HKEY_USERS');
  end;

  TMagnusRegistry = class(TInterfacedObject)

    private
      fRegistry: registry.TRegIniFile;
      fRegistryPath : TRegistryPath;
      const MAGNUS_EMPTY_STRING = '- magnus empty -';
    public
      const MAGNUS_LAST_USER_NAME_PATH = 'HKEY_CURRENT_USER\Software\Magnus Informatik\Magnus:Årsafslutning\Init-App\LastUserName';
      const AARSAFSLUTNING_EXECUTABLE_PATH_KEY = MAGNUS_LAST_USER_NAME_PATH + '\Client';
      constructor Create(registryPath : TRegistryPath);
      destructor Destroy; override;
      function ReadValue() : string;
      procedure WriteValue(const value : string);
      class function CreateDefault(registryPath : TRegistryPath) : TMagnusRegistry;
  end;

implementation
uses
  windows;

type

  TMagnusRegistryHelper = class(TObject)

  end;

constructor TMagnusRegistry.Create(registryPath : TRegistryPath);
begin
  inherited Create();
  fRegistryPath := registryPath;
  assert(fRegistryPath.Root = TRegistryPath.VALID_NAMES[0]);
  //fRegistry := TRegIniFile.Create();
end;


class function TMagnusRegistry.CreateDefault(
  registryPath: TRegistryPath): TMagnusRegistry;
begin
  result := TMagnusRegistry.Create(registryPath);
  result.fRegistry := TRegIniFile.Create(registryPath.FullPath);
end;

destructor TMagnusRegistry.Destroy;
begin
  if assigned(fRegistry) then
  try
    FreeAndNil(fRegistry);
  finally
  end;
  TRegistryPath.FreeIfAssigned(fRegistryPath);
  inherited;
end;



function TMagnusRegistry.ReadValue: string;
begin
  raise ENotImplemented.Create('TMagnusRegistry.ReadValue');
end;

procedure TMagnusRegistry.WriteValue(const value: string);
begin
  raise ENotImplemented.Create('TMagnusRegistry.WriteValue(const value: string)');
end;

{ TRegistryPath }

class function TRegistryPath.ContainsEmptyElements(const strings : TStringList): boolean;
var
  item : string;
begin
  for item in strings do
  begin
    if Length(item)=0 then
    begin
      result := true;
      exit;
    end;
  end;
  result := false;
end;


constructor TRegistryPath.Create(const path: string);
begin
  fStrings := TrimLastItemIfEmpty(CreatePathStrings(path));
  ValidateRegistryPathElements(fStrings);
end;



class function TRegistryPath.CreatePathStrings(const path: string): TStringList;
begin
  result := CreateStringsRaw();
  result.DelimitedText := path;
end;

class function TRegistryPath.CreateStringsRaw(): TStringList;
begin
  result := TStringList.Create();
  result.Delimiter := DELEMITER;
  result.StrictDelimiter := true;
end;

destructor TRegistryPath.Destroy;
begin
  FreeAndNil(fStrings);	
  inherited;
end;

class procedure TRegistryPath.FreeIfAssigned(const registryPath: TRegistryPath);
begin
  if assigned(registryPath) then
  begin
    registryPath.Free();
  end;
end;

function TRegistryPath.GetCount: integer;
begin
  result := fStrings.Count;
end;

function TRegistryPath.GetKey: string;
var
  path : TStringList;
begin
  path := CreateStringsRaw();
  try
    path.AddStrings(fStrings);
    path.Delete(path.Count-1);
    result := path.DelimitedText;
  finally
    path.Free();
  end;
end;



function TRegistryPath.GetFullPath: string;
begin
  result := fStrings.DelimitedText;
end;

function TRegistryPath.GetRoot: string;
begin
  result := fStrings[0];
end;

function TRegistryPath.GetSection: string;
var
  path : TStringList;
begin
  path := CreateStringsRaw();
  try
    path.DelimitedText := fStrings.DelimitedText;
    path.Delete(path.Count-1);
    path.Delete(0);
    result := path.DelimitedText;
  finally
    path.Free();
  end;
end;

function TRegistryPath.GetPropertyName: string;
begin
  result := fStrings[fStrings.Count-1];
end;

class function TRegistryPath.TrimLastCharIfEmpty(const path: string): string;
var
  strings : TStringList;
begin
  strings := TrimLastItemIfEmpty(CreatePathStrings(path));
  try
    result := strings.DelimitedText;
  finally
    strings.Free();
  end;
end;

class function TRegistryPath.TrimLastItemIfEmpty(
  strings: TStringList): TStringList;
begin
  result := strings;
  if result.Count = 0 then
  begin
    exit;
  end;

  if Length(result[result.Count-1])>0 then
  begin
    exit
  end;
  result.Delete(result.Count-1);

end;

class procedure TRegistryPath.ValidateRegistryPathElements(const strings: TStringList);
var
  path : string;
  firstElement : string;
  item : string;
begin
  path := strings.DelimitedText;
  if ContainsEmptyElements(strings) then
  begin
    raise EInvalidRegistryPath.Create(Format('Path contains empty elements [%s]', [path]));
    exit;
  end;
  //Should this be at least four elements (including the root part HKEY_CURRENT_USER)??
  //like so: HKEY_CURRENT_USER\Software\Key\PopertyName
  if strings.Count < 2 then
  begin
    raise EInvalidRegistryPath.Create(Format('Path must at least contain three elements like so: HKEY_CURRENT_USER\Software\Key\PopertyName  [%s]', [path]));
    exit;
  end;

  firstElement := AnsiLowerCase(strings[0]);
  for item in VALID_NAMES do
  begin
    if CompareStr(AnsiLowerCase(item), firstElement)=0 then
    begin
      exit;    
    end;
  end;
  raise EInvalidRegistryPath.Create(Format('Path must start with a known windows registry entry i.e HKEY_CURRENT_USER was [%s]', [path]));

end;


end.
