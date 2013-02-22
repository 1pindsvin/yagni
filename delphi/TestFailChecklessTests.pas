{ $Id: TestFailChecklessTests.pas,v 1.1 2006/07/19 02:54:05 judc Exp $ }
{: DUnit: An XTreme testing framework for Delphi programs.
   @author  The DUnit Group.
   @version $Revision: 1.1 $
}
(*
 * The contents of this file are subject to the Mozilla Public
 * License Version 1.1 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of
 * the License at http://www.mozilla.org/MPL/
 *
 * Software distributed under the License is distributed on an "AS
 * IS" basis, WITHOUT WARRANTY OF ANY KIND, either express or
 * implied. See the License for the specific language governing
 * rights and limitations under the License.
 *
 * The Original Code is DUnit.
 *
 * The Initial Developers of the Original Code are Kent Beck, Erich Gamma,
 * and Juancarlo Añez.
 * Portions created The Initial Developers are Copyright (C) 1999-2000.
 * Portions created by The DUnit Group are Copyright (C) 2000.
 * All rights reserved.
 *
 * Contributor(s):
 * Kent Beck <kentbeck@csi.com>
 * Erich Gamma <Erich_Gamma@oti.com>
 * Juanco Añez <juanco@users.sourceforge.net>
 * Chris Morris <chrismo@users.sourceforge.net>
 * Jeff Moore <JeffMoore@users.sourceforge.net>
 * Kris Golko <neuromancer@users.sourceforge.net>
 * The DUnit group at SourceForge <http://dunit.sourceforge.net>
 *
 *)

unit TestFailChecklessTests;



interface


uses
  TestFrameWork, Classes;



type TOtherClass = class(TInterfacedObject)
  
  private
    fItems : TList;
  public
    constructor Create();
    function Sum() : integer;
    procedure Add(const item : integer);
    class procedure FreeIfUnAssigned(obj : TObject);
end;

type
  TTestEmptyTestProcs = class(TTestCase)
  published
    procedure TestWithActiveCallToCheck;
    procedure EmptyTestOptimizationOn;
    procedure EmptyTestOptimizationOff;
    procedure TestWithNoCallToCheck;
    procedure TestWithNoCallToCheck_FailSuppressed;
  end;

  type
  TTestOtherClass = class(TTestCase)
  published
    procedure IsEmptyWhenNothingIsAdded;
    procedure SumOfElements;
  end;


implementation
uses
  windows;

{$IFOPT O+}
{$DEFINE OPTIMIZED}
{$OPTIMIZATION OFF}
{$ENDIF}
procedure TTestEmptyTestProcs.EmptyTestOptimizationOff;
begin
// Test left intentionally empty
end;
{$IFDEF OPTIMIZED}
{$OPTIMIZATION ON}
{$ENDIF}

{$IFOPT O-}
{$DEFINE UNOPTIMIZED}
{$OPTIMIZATION ON}
{$ENDIF}
procedure TTestEmptyTestProcs.EmptyTestOptimizationOn;
  var fNames : TStringList;
begin
  fNames := TStringList.Create();
  try
    fNames.Add('Hey I''m done');
    CheckNotNull(fNames,'This is another nice mess');
  finally
    if assigned(fNames) then
    begin
      fNames.Free();
    end;

  end;
end;

procedure TTestEmptyTestProcs.TestWithNoCallToCheck;
begin
  // Just sufficient code to thwart optimisation
  Sleep(10);
end;

procedure TTestEmptyTestProcs.TestWithActiveCallToCheck;
begin
  CheckTrue(True, 'Failed simple "True" check');
end;

procedure TTestEmptyTestProcs.TestWithNoCallToCheck_FailSuppressed;
begin
  FailsOnNoChecksExecuted := False;
end;

{$IFDEF UNOPTIMIZED}
{$OPTIMIZATION OFF}
{$ENDIF}

{ TOtherClass }

procedure TOtherClass.Add(const item: integer);
begin
  fItems.Add(Pointer(item));
end;


constructor TOtherClass.Create;
begin
  inherited Create;
  fItems := TList.Create;
end;

class procedure TOtherClass.FreeIfUnAssigned(obj: TObject);
begin
  if assigned(obj) then
  begin
    obj.Free;
  end; 
end;

function TOtherClass.Sum: integer;
  var iterator : TListEnumerator;
begin
  iterator := fItems.GetEnumerator;
  result := 0;
  try
    while iterator.MoveNext do
    begin
      result := result + integer(iterator.Current);
    end;
  finally
    iterator.Free
  end;
end;

{ TTestOtherClass }

procedure TTestOtherClass.IsEmptyWhenNothingIsAdded;
  var other : TOtherClass;
begin
  other := TOtherClass.Create;
  CheckEquals(0, other.Sum);  
end;

procedure TTestOtherClass.SumOfElements;
 const items : array[0..9] of Integer=(0,1,2,3,4,5,6,7,8,9);
 var item : integer;
 var other : TOtherClass;
begin
  other := TOtherClass.Create;
  try
    for  item  in items do
    begin
      other.Add(item);
    end;
    CheckEquals(45,other.Sum);
  finally
    TOtherClass.FreeIfUnAssigned(other);  
  end;
end;


initialization
  TestFramework.RegisterTest(TTestEmptyTestProcs.Suite);
  TestFramework.RegisterTest(TTestOtherClass.Suite);

end.
