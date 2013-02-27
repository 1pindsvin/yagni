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
  LOG_FILE_PATH = 'c:\Dev\yagni\delphi\log.txt';
  FILE_APPENDER_NAME = 'TLogRollingFileAppender';
var
  appender: TLogFileAppender;
  logLayout : ILogLayout;
begin
  appender := TLogRollingFileAppender.Create(FILE_APPENDER_NAME,LOG_FILE_PATH);
  //appender.Layout := TLogHTMLLayout.Create;
  logLayout := TLogPatternLayout.Create('[%p] %d %c  %m %e %t %n');
  logLayout.Options[DateFormatOpt] := 'yyyy-mm-dd hh:mm:ss';
  appender.Layout := logLayout;
  TLogBasicConfigurator.Configure(appender);
  TLogLogger.GetRootLogger.Level := All;
end;

begin
  Application.Initialize;
  InitializeLoggingFrameWork();
  log := TLogLogger.GetLogger(Application.ClassType);
  if IsConsole then
  begin
    //(rxbHaltOnFailures) will just stop execution
    log.Debug(Application.ClassName);
    testResult := TextTestRunner.RunRegisteredTests();
    try
      if testResult.WasSuccessful then
      begin
        log.info('no errors or failures in test, exiting');
        exit;
      end;
      log.Error(Format('Errors or failures found in tests. Failures [%d], Errors [%d]',[testResult.FailureCount, testResult.ErrorCount]));
      //raise Exception.Create(Format('Errors in test: %d',[testResult.FailureCount]));
    finally
      log.debug('freeing objects');
      FreeAndNil(testResult);
    end;

  end
  else
  begin
    log.Debug('Entering GUI tests (Dunit)');
    GUITestRunner.RunRegisteredTests;
  end;
  log.Info('Done running tests');

end.

