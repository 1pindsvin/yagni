program HowToRegistryTests;
{

  Delphi DUnit Test Project
  -------------------------
  This project contains the DUnit test framework and the GUI/Console test runners.
  Add "CONSOLE_TESTRUNNER" to the conditional defines entry in the project options 
  to use the console test runner.  Otherwise the GUI test runner will be used by 
  default.

}

{$IFDEF CONSOLE_TESTRUNNER}
{$APPTYPE CONSOLE}
{$ENDIF}

uses
  Forms,
  TestFramework,
  GUITestRunner,
  TextTestRunner,
  SysUtils,
  TMagnusRegistryTests in 'TMagnusRegistryTests.pas';

{$R *.RES}
var
  testResult : TTestResult;
begin
  Application.Initialize;
  if IsConsole then
  begin
    testResult := TextTestRunner.RunRegisteredTests(); //(rxbHaltOnFailures)
    if testResult.WasSuccessful then
    begin
      exit;
    end;
    raise Exception.Create('Errors in test');
  end
  else
  begin
    GUITestRunner.RunRegisteredTests;
  end;
  
end.

