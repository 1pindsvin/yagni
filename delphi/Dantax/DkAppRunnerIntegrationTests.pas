unit DkAppRunnerIntegrationTests;

interface

uses
  SysUtils,
  TestFrameWork,
  Classes,
  DkAppRunner;

type

  ERemoteCallFailed = class(Exception);

  TAppRunnerFixture = class(TTestCase)
    const
      APP_NAME = 'Aarsafslut';
    private
      fIsRunning : boolean;
    protected
      procedure SetUp; override;
      procedure TearDown; override;
    published
      procedure CanRunAarsAfslutning;
      procedure IsAarsAfslutningRunning;
      procedure CanSendMessageToRunningInstanceOfAarafslutning;
  end;


implementation

{ TAppRunnerFixture }

procedure showMessage(shortMessage: string;
  msgID: Integer; const Args: array of string);
begin
  raise ERemoteCallFailed.Create('Ups');
end;

function TSkAppResolveAarsafslutningExePathFromRegistry: string;
begin
  result := 'c:\Program Files (x86)\Magnus\Magnus Årsafslutning\Aarsafslut.exe';
end;

function TSkAppResolveAarsafslutningStartPathFromRegistry: string;
begin
  result := 'c:\Program Files (x86)\Magnus\Magnus Årsafslutning';
end;

procedure TAppRunnerFixture.CanRunAarsAfslutning;
var
  exepath : string;
  startPath : string;
begin
  exepath	:= TSkAppResolveAarsafslutningExePathFromRegistry();
  startPath := TSkAppResolveAarsafslutningStartPathFromRegistry();
  TAppRunner.ExecProcess(exepath,startPath);
end;

procedure TAppRunnerFixture.CanSendMessageToRunningInstanceOfAarafslutning;
const
  DOFileNameOpt = '/SKDO';
  FILE_NAME = 'wat.txt';
var
  callBack : TMessageProcedure;
begin
  if TAppRunner.IsAppRunning(APP_NAME)  then
  begin
    callBack := showMessage;
    TAppRunner.ConnectAndRunMacro(APP_NAME, FILE_NAME, callBack);
  end;
end;

procedure TAppRunnerFixture.IsAarsAfslutningRunning;
begin
  CheckTrue(TAppRunner.IsAppRunning(self.APP_NAME));
end;

procedure TAppRunnerFixture.SetUp;
begin
  inherited;

end;



procedure TAppRunnerFixture.TearDown;
begin
  inherited;

end;

initialization
  TestFramework.RegisterTest(TAppRunnerFixture.Suite);
end.

