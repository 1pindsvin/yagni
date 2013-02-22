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
    const MAGNUS_AARSAFSLUTNING_PATH = 'SOFTWARE\Magnus Informatik\Magnus:Årsafslutning';
    constructor Create();
    function GetLocalMachineRegistry() : TRegistry;
    function GetCurrentUserRegistry() : TRegistry;
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

end.
