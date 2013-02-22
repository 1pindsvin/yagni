unit TMagnusRegistryTests;

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

    procedure CanReadMagnusValue;

  end;

implementation

uses
  registry;
{ TMagnusRegistryFixture }

procedure TMagnusRegistryFixture.CanReadMagnusValue;
var
  reg : TRegistry;
begin
  reg := fMagnusRegistry.GetCurrentUserRegistry();
  reg.OpenKeyReadOnly(TMagnusRegistry.MAGNUS_AARSAFSLUTNING_PATH);
  CheckTrue(false);
end;

procedure TMagnusRegistryFixture.SetUp;
begin
  inherited;
  fMagnusRegistry := TMagnusRegistry.Create();
end;

initialization

  TestFramework.RegisterTest(TMagnusRegistryFixture.Suite);

end.
