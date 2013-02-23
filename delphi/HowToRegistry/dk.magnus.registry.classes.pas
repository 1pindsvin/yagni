unit dk.magnus.registry.classes;

interface

uses
  classes,
  registry,
  SysUtils;

type TMagnusRegistry = class(TObject)
  private
    function CreateWithAllAccess() : TRegistry;
    function CreateWithOrdinaryUserAccess() : TRegistry;
  public
    const MAGNUS_COMPANY_PATH = 'SOFTWARE\Magnus Informatik\Magnus:Årsafslutning';
    const AARSAFSLUTNING_EXECUTABLE_PATH_KEY = MAGNUS_COMPANY_PATH + '\Client';
    constructor Create();
    function GetLocalMachineRegistry() : TRegistry;
    function GetCurrentUserRegistry() : TRegistry;
    function NavigateTo(const path : string) : TMagnusRegistry;
    destructor Destroy; override;
private
var
  fRegistry: registry.TRegistry;
end;

implementation
uses
  windows;

constructor TMagnusRegistry.Create;
begin

end;

function TMagnusRegistry.CreateWithAllAccess: TRegistry;
begin
  result := TRegistry.Create(KEY_ALL_ACCESS);
end;

function TMagnusRegistry.CreateWithOrdinaryUserAccess: TRegistry;
begin
  raise Exception.Create('Not implemented');
end;



destructor TMagnusRegistry.Destroy;
begin
  if assigned(fRegistry) then
  try
    fRegistry.CloseKey();
  finally
    FreeAndNil(fRegistry);
  end;
  inherited;
end;

function TMagnusRegistry.GetCurrentUserRegistry: TRegistry;
begin
  result := CreateWithAllAccess();
  result.RootKey := HKEY_CURRENT_USER;
end;

function TMagnusRegistry.GetLocalMachineRegistry: TRegistry;
begin
  result := CreateWithAllAccess();
  result.RootKey := HKEY_LOCAL_MACHINE;
end;

function TMagnusRegistry.NavigateTo(const path: string): TMagnusRegistry;
begin
  fRegistry := CreateWithAllAccess();
  fRegistry.OpenKeyReadOnly(path);
  result := self;
end;

end.
