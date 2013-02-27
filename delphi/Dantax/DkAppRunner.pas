unit DkAppRunner;

interface

uses
  SysUtils,
  Windows,
  Classes,
  Forms,
  Controls;

type

  TMessageProcedure = procedure(shortMessage : string; msgID: Longint; const Args: array of string);

  TAppRunner = class
    class function IsAppRunning(appName: string): boolean;
    class procedure ExecProcess(executablePath, startInDirectory: string);
    class procedure ConnectAndRunMacro(const AppName: string;const macroLine : string; messageProcedure : TMessageProcedure);
  end;



implementation
  uses ddeman;

class procedure TAppRunner.ConnectAndRunMacro(const AppName, macroLine: string;messageProcedure : TMessageProcedure);
var
  macroLines : TStringList;
  DDEClientConv : TDDEClientConv;
  couldExecuteMacroLines : boolean;
begin
  macroLines := TStringList.Create;
  DDEClientConv := TDDEClientConv.Create(Application.MainForm);
  try
    macroLines.Add(macroLine);
    DDEClientConv.ConnectMode := ddeManual;
    DDEClientConv.SetLink(AppName,'NJDBAppDdeServerConv');
    if DDEClientConv.OpenLink then
    begin
      couldExecuteMacroLines := DDEClientConv.ExecuteMacroLines(macroLines, False);
      if not couldExecuteMacroLines then
      begin
        messageProcedure('Ixxxx', 10000, ['Executemacro failed']);
      end;
      DDEClientConv.CloseLink;
    end
    else
    begin
      messageProcedure('Ixxxx', 10000, ['OpenLink failed']);
    end;
  finally
    macroLines.Free;
    DDEClientConv.Free;
  end;
end;

class procedure TAppRunner.ExecProcess(executablePath, startInDirectory: string);
var
  StartInfo      : TStartupInfo;
  ProcInfo       : TProcessInformation;
  StartPathPChar : PChar;
begin
  { fill with known state }
  FillChar(StartInfo,SizeOf(TStartupInfo),#0);
  FillChar(ProcInfo,SizeOf(TProcessInformation),#0);
  StartInfo.cb := SizeOf(TStartupInfo);

  if startInDirectory <> EmptyStr then
    StartPathPChar := PChar(startInDirectory)
  else
    StartPathPChar := nil;

  if not CreateProcess(
    nil,                       // Pointer to a null-terminated string that specifies the module to execute.
    PChar(executablePath),        // Pointer to a null-terminated string that specifies the command line to execute.
    nil,                       // Default process security
    nil,                       // Default thread security
    False,                     // Do not inherit handles
    CREATE_NEW_PROCESS_GROUP+NORMAL_PRIORITY_CLASS, // Creation flags
    nil,                       // Environment block
    StartPathPChar,            // Current working directory for new app
    StartInfo,                 // Startup window appearance
    ProcInfo                   // Process information
  ) then
  begin
    RaiseLastOSError;
  end;
end;

class function TAppRunner.IsAppRunning(appName: string): boolean;
var
  handle : THandle;
begin
  Result := False;
  handle := OpenMutex(MUTEX_ALL_ACCESS, False, PChar(AnsiUpperCase(AppName)));
  If handle <> 0 then
  begin
    Result := True;
    CloseHandle(handle);
  end
end;

end.
