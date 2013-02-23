unit MagnusRegistryTestUnit;

interface

uses
  TestFrameWork,
  Classes,
  dk.magnus.registry.classes;

  type
  TMagnusRegistryFixture = class(TTestCase)
    fMagnusRegistry : TMagnusRegistry;
  protected
    procedure SetUp; override;

  published

    procedure CanReadMagnusCompanyKey;
    procedure CanReadAarsafslutningExecuteablePath;
  end;


implementation
uses
  registry;
{ TMagnusRegistryFixture }

procedure TMagnusRegistryFixture.CanReadAarsafslutningExecuteablePath;
var
  reg : TRegistry;
begin
  reg := fMagnusRegistry.GetCurrentUserRegistry();
  CheckTrue(reg.OpenKeyReadOnly(TMagnusRegistry.AARSAFSLUTNING_EXECUTABLE_PATH_KEY));
end;

procedure TMagnusRegistryFixture.CanReadMagnusCompanyKey;
var
  reg : TRegistry;
begin
  reg := fMagnusRegistry.GetCurrentUserRegistry();
  CheckTrue(reg.OpenKeyReadOnly(TMagnusRegistry.MAGNUS_COMPANY_PATH));
end;

procedure TMagnusRegistryFixture.SetUp;
begin
  inherited;
  fMagnusRegistry := TMagnusRegistry.Create();
end;

initialization
  TestFramework.RegisterTest(TMagnusRegistryFixture.Suite);

end.

