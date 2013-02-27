program HowToRegistry;

{$APPTYPE CONSOLE}

uses
  SysUtils,
  DkMagnusRegistry in 'DkMagnusRegistry.pas',
  registry;

var
  s : string;
  app : TMagnusRegistry;
  registryPath : TRegistryPath;
  
begin
  try
    registryPath := TRegistryPath.Create(TMagnusRegistry.MAGNUS_LAST_USER_NAME_PATH);
    app := TMagnusRegistry.Create(registryPath);
    try
    finally
      app.Free;
      registryPath := nil;
    end;
    s := 'wat';
    Writeln(s);
    Readln;
  except
    on E:Exception do
      Writeln(E.Classname, ': ', E.Message);
  end;
end.
