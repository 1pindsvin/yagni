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
  TMagnusRegistryTests in 'TMagnusRegistryTests.pas',
  Log4D in '..\..\log4d\Log4D.pas';

{$R *.RES}
var
  testResult : TTestResult;
  log : TLogLogger;

procedure InitializeLoggingFrameWork();
const
  LOG_FILE_PATH = 'c:\Dev\yagni\delphi\MagnusRegistryUnittests\log.txt';
  FILE_APPENDER_NAME = 'TLogRollingFileAppender';
var
  appender: TLogFileAppender;
  logLayout : ILogLayout;
begin
  appender := TLogRollingFileAppender.Create(FILE_APPENDER_NAME,LOG_FILE_PATH);
  //appender.Layout := TLogHTMLLayout.Create;
  logLayout := TLogSimpleLayout.Create();
  appender.Layout := logLayout;
  TLogBasicConfigurator.Configure(appender);
  TLogLogger.GetRootLogger.Level := All;
end;

begin
  Application.Initialize;
  InitializeLoggingFrameWork();
  log := TLogLogger.GetLogger('foobar');

  if IsConsole then
  begin
    //(rxbHaltOnFailures) will just stop execution
    log.Debug('foo');
    testResult := TextTestRunner.RunRegisteredTests();
    try
      if testResult.WasSuccessful then
      begin
        exit;
      end;
      log.Error('about to throw an exeption');
      raise Exception.Create(Format('Errors in test: %d',[testResult.FailureCount]));
    finally
      log.Error('exception was thrown - freeing objects');
      FreeAndNil(testResult);
    end;

  end
  else
  begin
    GUITestRunner.RunRegisteredTests;
  end;
  
end.

