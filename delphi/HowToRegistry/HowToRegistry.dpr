program HowToRegistry;

{$APPTYPE CONSOLE}

uses
  SysUtils,
  dk.magnus.registry.classes in 'dk.magnus.registry.classes.pas',
  registry;

var
  s : string;
  app : TMagnusRegistry;
  registry : TRegistry;
begin

  try
    app := TMagnusRegistry.Create();
    registry := app.GetLocalMachineRegistry();
    try
      registry.OpenKeyReadOnly(app.MAGNUS_COMPANY_PATH);
    finally
      FreeAndNil(registry);
      FreeAndNil(app);
    end;
    s := 'wat';
    Writeln(s);
    Readln;
  except
    on E:Exception do
      Writeln(E.Classname, ': ', E.Message);
  end;
end.
