unit MagnusRegistryTestUnit;

interface

uses
  TestFrameWork,
  Classes,
  DkMagnusRegistry;

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


procedure TMagnusRegistryFixture.SetUp;
begin
  inherited;
  fMagnusRegistry := TMagnusRegistry.Create();
end;

initialization
  TestFramework.RegisterTest(TMagnusRegistryFixture.Suite);

end.

