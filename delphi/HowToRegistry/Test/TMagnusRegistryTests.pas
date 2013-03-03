unit TMagnusRegistryTests;

interface

uses
  TestFrameWork,
  Classes,
  DkMagnusRegistry,
  registry;

type

  TRegistryIntegrationTestsFixture = class(TTestCase)
    const
      USER_NAME = 'PWIH';
      MAGNUS_INIT_APP_KEY = 'Magnus Informatik\Magnus:Årsafslutning\Init-App';
      SOFTWARE_SECTION = 'Software';
      PROPERTY_NAME = 'LastUserName';
    private
      fCanActuallyWriteAndRead : boolean;
    protected
      procedure SetUp; override;
      procedure TearDown; override;
    published
      procedure CanWriteValue;
      procedure CanReadValue;
      procedure CreatesMissingKeysInPath;
  end;

  TRegistryAdapter = class
       fRegistry : TRegistry;
    public
      constructor Create();
      destructor Destroy; override;
  end;

  TMagnusRegistryFixture = class(TTestCase)
    const
      USER_NAME = 'PWIH';
      MAGNUS_INIT_APP_KEY = 'Magnus Informatik\Magnus:Årsafslutning\Init-App';
      SOFTWARE_SECTION = 'Software';
      PROPERTY_NAME = 'LastUserName';
    private
      fGuidName : string;
      fKeyToCreateAndDelete : string;
      procedure WriteAndReadToRegistry(regIni: TRegIniFile);
    protected
      procedure SetUp; override;
      procedure TearDown; override;
    published
      procedure CanWriteToLocalMachine;
      procedure CanReadMagnusLastUserDirectly;
      procedure CanWriteAndReadToRegistry;
      procedure CanCreateKey;
      procedure CanReadMagnusLastUser;
      procedure CanDeleteKeyIfSet;
  end;

  TRegistryPathFixture = class(TTestCase)
    const
      fFirstPartOfPath = 'Gombert';
      fSecondPartOfPath = 'Flandhart';
    private
      fCurrentPath : string;
    protected
      procedure SetUp; override;
      procedure CheckCount(path : string; expectedCount : integer);
      procedure CreateInvalidPathThrowsEInvalidRegistryPathException();
      function Equals(left, right : TStringList) : boolean;
    published
      procedure SplitsPathToExpectedNumberOfSubstrings;
      procedure CreateThrowsForInvalidPaths;
      procedure DeletesLastItemIfEmpty();
      procedure CanResolveRoot;
  end;

implementation

uses
  SysUtils,
  Windows;

{ TMagnusRegistryFixture }


procedure TMagnusRegistryFixture.CanDeleteKeyIfSet;
var
  guid : TGUID;
  regIni : TRegIniFile;
  theKey : string;
begin
  regIni := TRegIniFile.Create(SOFTWARE_SECTION);
  try
    //must include windows for this to work;
    regIni.RootKey := HKEY_CURRENT_USER;
    theKey := MAGNUS_INIT_APP_KEY + '\' + fKeyToCreateAndDelete;
    Assert(regIni.KeyExists(theKey));
    regIni.DeleteKey(SOFTWARE_SECTION, theKey);

  finally
    regIni.Free;
  end;
end;

procedure TMagnusRegistryFixture.CanReadMagnusLastUser;
var
  reg : TMagnusRegistry;
begin
  reg := TMagnusRegistry.Create(TRegistryPath.Create(TMagnusRegistry.MAGNUS_LAST_USER_NAME_PATH));
  try

  finally
    reg.Free;
  end;

end;

procedure TMagnusRegistryFixture.CanReadMagnusLastUserDirectly;
var
  regIni : TRegIniFile;
  name : string;
begin
  regIni := TRegIniFile.Create(SOFTWARE_SECTION);
  try
    name := regIni.ReadString(MAGNUS_INIT_APP_KEY,PROPERTY_NAME,'');
    CheckEquals(USER_NAME,name);
  finally
    regIni.Free;
  end;
end;

procedure TMagnusRegistryFixture.CanWriteAndReadToRegistry;
var
  regIni : TRegIniFile;
begin
  regIni := TRegIniFile.Create(SOFTWARE_SECTION);
  try
    WriteAndReadToRegistry(regIni);
  finally
    regIni.Free;
  end;
end;

procedure TMagnusRegistryFixture.CanWriteToLocalMachine;
var
  regIni : TRegIniFile;
begin
  regIni := TRegIniFile.Create(SOFTWARE_SECTION, KEY_ALL_ACCESS);
  regIni.RootKey := HKEY_LOCAL_MACHINE;
  try
    WriteAndReadToRegistry(regIni);
  finally
    regIni.Free;
  end;
end;

procedure TMagnusRegistryFixture.CanCreateKey;
var
  guid : TGUID;
  regIni : TRegIniFile;
  theKey : string;
begin
  CheckEquals(0,CreateGUID(guid));
  regIni := TRegIniFile.Create(SOFTWARE_SECTION);
  try
    //must include windows for this to work;
    regIni.RootKey := HKEY_CURRENT_USER;
    theKey := MAGNUS_INIT_APP_KEY + '\' + fKeyToCreateAndDelete;
    CheckTrue(regIni.CreateKey(theKey));
    regIni.CloseKey();
  finally
    regIni.Free;
  end;
end;

procedure TMagnusRegistryFixture.WriteAndReadToRegistry(regIni: TRegIniFile);
var
  name: string;
begin
  regIni.WriteString(MAGNUS_INIT_APP_KEY, PROPERTY_NAME, USER_NAME);
  name := regIni.ReadString(MAGNUS_INIT_APP_KEY, PROPERTY_NAME, '');
  CheckEquals(USER_NAME, name);
end;

procedure TMagnusRegistryFixture.SetUp;
begin
  inherited;
  fGuidName := '';
  fKeyToCreateAndDelete := 'Gombert';
end;

procedure TMagnusRegistryFixture.TearDown;
begin
  inherited;
  
end;

{ TRegistryPathFixture }

procedure TRegistryPathFixture.CreateThrowsForInvalidPaths;
const
  paths : array[0..4] of string =('','\isInvalid\\','\\\\','\isInvalid\\','foo');
var
  path : string;
begin
  for path in paths do
  begin
    fCurrentPath := path;
    CheckException(CreateInvalidPathThrowsEInvalidRegistryPathException,EInvalidRegistryPath);
  end;
end;



procedure TRegistryPathFixture.CanResolveRoot;
var
  registryPath : TRegistryPath;
  expected : string;
begin
  //'Software\Magnus Informatik\Magnus:Årsafslutning\Init-App'
  registryPath := TRegistryPath.Create(TMagnusRegistry.MAGNUS_LAST_USER_NAME_PATH);
  try
    expected := TRegistryPath.VALID_NAMES[4];
    CheckEqualsString(expected, registryPath.Root);
    CheckEqualsString('LastUserName',registryPath.PropertyName);
    CheckEqualsString('Software\Magnus Informatik\Magnus:Årsafslutning\Init-App',registryPath.Section);
  finally
    registryPath.Free;
  end;

end;

procedure TRegistryPathFixture.CheckCount(path: string; expectedCount: integer);
var
  strings : TStringList;
begin
  strings := TRegistryPath.CreatePathStrings(path);
  try
    CheckEquals(expectedCount, strings.Count);
  finally
    strings.Free();
  end;
end;


procedure TRegistryPathFixture.CreateInvalidPathThrowsEInvalidRegistryPathException();
begin
  TRegistryPath.Create(fCurrentPath);
end;

procedure TRegistryPathFixture.DeletesLastItemIfEmpty;
var
  path : string;
  expected : string;
begin
  path := 'some\path\';
  expected := 'some\path';
  CheckEquals(expected, TRegistryPath.TrimLastCharIfEmpty(path));
  path := 'path\';
  expected := 'path';
  CheckEquals(expected, TRegistryPath.TrimLastCharIfEmpty(path));
  path := '\';
  //trouble ahead
  expected := '""';
  CheckEquals(expected, TRegistryPath.TrimLastCharIfEmpty(path));  
end;

function TRegistryPathFixture.Equals(left, right: TStringList): boolean;
var idx : integer;
begin
  result := left.Count = right.Count;
  if not result then
  begin
    exit;
  end;
  for idx := 0 to left.Count - 1 do
  begin
    result :=  AnsiCompareStr(left[idx],right[idx])=0;
    if not result then
    begin
      exit
    end;
  end;
end;

procedure TRegistryPathFixture.SetUp;
begin
  inherited;
  fCurrentPath := '';
end;

procedure TRegistryPathFixture.SplitsPathToExpectedNumberOfSubstrings;
const
  path = '0\1\2\3';
  suspectPath = '\\\\';
  emptyPath = '\';
begin
  CheckCount(path, 4);
  CheckCount(suspectPath, 5);
  CheckCount(emptyPath, 2);
end;


{ TRegistryFixture }

procedure TRegistryIntegrationTestsFixture.CanReadValue;
var
  reg: TRegistry;
  pathToKey : string;
  canCreate : boolean;
  expected : string;
  valueFromRegistry : string;
begin
  if not fCanActuallyWriteAndRead then
  begin
    exit;
  end;
  canCreate := true;
  pathToKey := 'Software\Magnus Informatik\Magnus:Årsafslutning\Init-App\Gombert';
  reg := TRegistry.Create(KEY_ALL_ACCESS);
  try
    reg.RootKey := HKEY_CURRENT_USER;
    CheckTrue(reg.OpenKeyReadOnly(pathToKey));
    expected := 'PWIH';
    valueFromRegistry := reg.ReadString('Flandhart');
    CheckEqualsString(expected,valueFromRegistry);
    reg.CloseKey();
  finally
    reg.Free;
  end;
end;

procedure TRegistryIntegrationTestsFixture.CanWriteValue;
var
  reg: TRegistry;
  pathToKey : string;
  canCreate : boolean;
begin
  if not fCanActuallyWriteAndRead then
  begin
    exit;
  end;
  canCreate := true;
  pathToKey := 'Software\Magnus Informatik\Magnus:Årsafslutning\Init-App\Gombert';
  reg := TRegistry.Create(KEY_ALL_ACCESS);
  try
    reg.LazyWrite := false;
    reg.RootKey := HKEY_CURRENT_USER;
    CheckTrue(reg.OpenKey(pathToKey,canCreate));
    reg.WriteString('Flandhart', 'PWIH');
    reg.CloseKey();
  finally
    reg.Free;
  end;
end;

procedure TRegistryIntegrationTestsFixture.CreatesMissingKeysInPath;
var
  reg: TRegistry;
  pathToKey : string;
  canCreate : boolean;
begin
  if not fCanActuallyWriteAndRead then
  begin
    exit;
  end;
  canCreate := true;
  pathToKey := 'Software\XXXX\YYYYY\Gombert';
  reg := TRegistry.Create(KEY_ALL_ACCESS);
  try
    reg.LazyWrite := false;
    reg.RootKey := HKEY_CURRENT_USER;
    CheckTrue(reg.OpenKey(pathToKey,canCreate));
    reg.WriteString('Flandhart', 'PWIH');
    reg.CloseKey();
  finally
    reg.Free;
  end;
end;

procedure TRegistryIntegrationTestsFixture.SetUp;
begin
  inherited;
  fCanActuallyWriteAndRead := false;
end;

procedure TRegistryIntegrationTestsFixture.TearDown;
begin
  inherited;

end;

{ TRegistryAdapter }

constructor TRegistryAdapter.Create;
begin
  inherited;
  fRegistry := TRegistry.Create(KEY_ALL_ACCESS);
  fRegistry.RootKey := HKEY_CURRENT_USER;
end;

destructor TRegistryAdapter.Destroy;
begin
  fRegistry.Free;
  inherited;
end;

initialization
  TestFramework.RegisterTest(TMagnusRegistryFixture.Suite);
  TestFramework.RegisterTest(TRegistryPathFixture.Suite);
  TestFramework.RegisterTest(TRegistryIntegrationTestsFixture.Suite);
end.
