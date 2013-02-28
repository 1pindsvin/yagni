unit Unit1;

interface
(*

Code for the article:

Accessing and managing MS Excel sheets with Delphi

http://delphi.about.com/library/weekly/aa090903a.htm

How to retrieve, display and edit Microsoft Excel spreadsheets
with ADO (dbGO) and Delphi. This step-by-step article describes
how to connect to Excel, retrieve sheet data, and enable editing
of data (using the DBGrid). You'll also find a list of most common
errors (and how to deal with them) that might pop up in the process.

*)


uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, DBCtrls, Grids, DBGrids, DB, ADODB, Buttons,
  ComCtrls;

type
  TForm1 = class(TForm)
    ADOConnection1: TADOConnection;
    DataSource1: TDataSource;
    DBGrid1: TDBGrid;
    DBNavigator1: TDBNavigator;
    Edit1: TEdit;
    Panel1: TPanel;
    Label1: TLabel;
    ADOQuery1: TADOQuery;
    Edit2: TEdit;
    Label2: TLabel;
    BitBtn1: TBitBtn;
    StatusBar1: TStatusBar;
    ComboBox1: TComboBox;
    Label3: TLabel;
    ListBox1: TListBox;
    ADOConnection2: TADOConnection;
    ADOQuery2: TADOQuery;
    Panel2: TPanel;
    Button1: TButton;
    Button2: TButton;
    procedure BitBtn1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    procedure ConnectToExcel;
    procedure FetchData;
    procedure GetFieldInfo;

    procedure DisplayException(Sender:TObject; E: Exception);
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation
{$R *.dfm}
uses typinfo;


{ TForm1 }

procedure TForm1.ConnectToExcel;
var strConn :  widestring;
begin
  strConn:='Provider=Microsoft.Jet.OLEDB.4.0;' +
           'Data Source=' + Edit1.Text + ';' +
           'Extended Properties=Excel 8.0;';

  AdoConnection1.Connected:=False;
  AdoConnection1.ConnectionString:=strConn;
  try
    AdoConnection1.Open;
    AdoConnection1.GetTableNames(ComboBox1.Items,True);
  except
    ShowMessage('Unable to connect to Excel, make sure the workbook ' + Edit1.Text + ' exist!');
    raise;
  end;
end;(*ConnectToExcel*)

procedure TForm1.FetchData;
begin
  StatusBar1.SimpleText:='';

  if not AdoConnection1.Connected then ConnectToExcel;

  AdoQuery1.Close;
  AdoQuery1.SQL.Text:=Edit2.Text;
  try
    AdoQuery1.Open;
  except
    ShowMessage('Unable to read data from Excel, make sure the query ' + Edit1.Text + ' is meaningful!');
    raise;
  end;
end;

procedure TForm1.BitBtn1Click(Sender: TObject);
begin
  FetchData;

  GetFieldInfo;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  AdoConnection1.LoginPrompt:=False;
  AdoQuery1.Connection:=AdoConnection1;
  DataSource1.DataSet:=AdoQuery1;
  DBGrid1.DataSource:=DataSource1;
  DBNavigator1.DataSource:=DataSource1;

  Application.OnException:= DisplayException;


  //connect to an Access database to send the data to Excel
  AdoConnection2.LoginPrompt:=False;
  AdoConnection2.ConnectionString:='Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\!Gajba\About\QuickiesContest.mdb;Persist Security Info=False';
  AdoQuery2.Connection:=AdoConnection2;
  AdoConnection2.Open;
end;

procedure TForm1.DisplayException(Sender: TObject; E: Exception);
begin
  StatusBar1.SimpleText:=E.Message;

  //edit3.Text:=E.Message;
end;

procedure TForm1.GetFieldInfo;
var
  i   : integer;
  ft     : TFieldType;
  sft    : string;
  fname  : string;
begin
  ListBox1.Clear;
  for i := 0 to AdoQuery1.Fields.Count - 1 do
  begin
    ft := AdoQuery1.Fields[i].DataType;
    sft := GetEnumName(TypeInfo(TFieldType), Integer(ft));
    fname:= AdoQuery1.Fields[i].FieldName;

    ListBox1.Items.Add(Format('%d) NAME: %s TYPE: %s',[1+i, fname, sft]));
  end;
end;


procedure TForm1.Button2Click(Sender: TObject);
var sAppend : string;
begin
  sAppend:='INSERT INTO [Sheet2$] IN "' + Edit1.Text + '" "Excel 8.0;" SELECT AuthorEmail, Title, Description FROM Articles';

  AdoQuery2.SQL.Text:=sAppend;
  AdoQuery2.ExecSQL;
end;

procedure TForm1.Button1Click(Sender: TObject);
var sCopy : string;
begin
  sCopy := 'SELECT * INTO ["Excel 8.0;Database=' + Edit1.Text + '"].[SheetAuthors] FROM Authors';

  AdoQuery2.SQL.Text:=sCopy;
  AdoQuery2.ExecSQL;
end;

end.
