using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

namespace FlexHelper
{
    public struct FieldPtrTable
    {
        public int index;
    }

    public struct MethodPtrTable
    {
        public int index;
    }

    public struct ExceptionTable
    {
        public int flags;

        public int handlerlength;
        public int handleroffset;

        public int oneline;
        public int token;
        public int trylength;
        public int tryoffset;
    }

    public struct ExportedTypeTable
    {
        public int coded;
        public int flags;

        public int name;

        public int nspace;
        public int typedefindex;
    }

    public struct NestedClassTable
    {
        public int enclosingclass;
        public int nestedclass;
    }

    public struct MethodImpTable
    {
        public int classindex;

        public int codedbody;

        public int codeddef;
    }

    public struct ClassLayoutTable
    {
        public int classsize;
        public short packingsize;

        public int parent;
    }

    public struct ManifestResourceTable
    {
        public int coded;
        public int flags;

        public int name;
        public int offset;
    }

    public struct ModuleRefTable
    {
        public int name;
    }

    public struct FileTable
    {
        public int flags;

        public int index;
        public int name;
    }

    public struct EventTable
    {
        public short attr;

        public int coded;
        public int name;
    }

    public struct EventMapTable
    {
        public int eindex;
        public int index;
    }

    public struct MethodSemanticsTable
    {
        public int association;
        public int methodindex;
        public short methodsemanticsattributes;
    }

    public struct PropertyMapTable
    {
        public int parent;

        public int propertylist;
    }

    public struct PropertyTable
    {
        public int flags;

        public int name;

        public int type;
    }

    public struct ConstantsTable
    {
        public short dtype;

        public int parent;

        public int value;
    }

    public struct FieldLayoutTable
    {
        public int fieldindex;
        public int offset;
    }

    public struct FieldRVATable
    {
        public int fieldi;
        public int rva;
    }

    public struct FieldMarshalTable
    {
        public int coded;

        public int index;
    }

    public struct FieldTable
    {
        public int flags;

        public int name;

        public int sig;
    }

    public struct ParamTable
    {
        public int name;
        public short pattr;

        public int sequence;
    }

    public struct TypeSpecTable
    {
        public int signature;
    }

    public struct MemberRefTable
    {
        public int clas;

        public int name;

        public int sig;
    }

    public struct StandAloneSigTable
    {
        public int index;
    }

    public struct InterfaceImplTable
    {
        public int classindex;

        public int interfaceindex;
    }

    public struct TypeDefTable
    {
        public int cindex;

        public int findex;
        public int flags;

        public int mindex;
        public int name;

        public int nspace;
    }

    public struct CustomAttributeTable
    {
        public int parent;

        public int type;

        public int value;
    }

    public struct AssemblyRefTable
    {
        public short build;

        public int culture;
        public int flags;

        public int hashvalue;
        public short major, minor;
        public int name;
        public int publickey;
        public short revision;
    }

    public struct AssemblyTable
    {
        public int build;
        public int culture;
        public int flags;
        public int HashAlgId;

        public int major, minor;

        public int name;
        public int publickey;
        public int revision;
    }

    public struct ModuleTable
    {
        public int EncBaseId;
        public int EncId;
        public int Generation;

        public int Mvid;
        public int Name;
    }

    public struct TypeRefTable
    {
        public int name;

        public int nspace;
        public int resolutionscope;
    }

    public struct MethodTable
    {
        public int flags;
        public int impflags;

        public int name;

        public int param;
        public int rva;
        public int signature;
    }

    public struct DeclSecurityTable
    {
        public int action;

        public int bindex;
        public int coded;
    }

    public struct ImplMapTable
    {
        public short attr;

        public int cindex;

        public int name;

        public int scope;
    }

    public class PrintAssembly
    {
        private readonly string[] tablenames = new[]
                                               {
                                                   "Module", "TypeRef", "TypeDef", "FieldPtr", "Field", "MethodPtr",
                                                   "Method", "ParamPtr", "Param", "InterfaceImpl", "MemberRef", "Constant",
                                                   "CustomAttribute", "FieldMarshal", "DeclSecurity", "ClassLayout",
                                                   "FieldLayout", "StandAloneSig", "EventMap", "EventPtr", "Event",
                                                   "PropertyMap", "PropertyPtr", "Properties", "MethodSemantics",
                                                   "MethodImpl", "ModuleRef", "TypeSpec", "ImplMap", "FieldRVA", "ENCLog",
                                                   "ENCMap", "Assembly", "AssemblyProcessor", "AssemblyOS", "AssemblyRef",
                                                   "AssemblyRefProcessor", "AssemblyRefOS", "File", "ExportedType",
                                                   "ManifestResource", "NestedClass", "TypeTyPar", "MethodTyPar"
                                               };

        public AssemblyRefTable[] AssemblyRefStruct;
        public AssemblyTable[] AssemblyStruct;
        private byte[] blob;
        public ClassLayoutTable[] ClassLayoutStruct;
        private int codesize;
        public ConstantsTable[] ConstantsStruct;
        private int corflags;
        private int count;
        public CustomAttributeTable[] CustomAttributeStruct;
        private int datad;
        private int[] datadirectoryrva;

        private int[] datadirectorysize;
        private string[] datavtfixuparray;
        private bool debug;
        public DeclSecurityTable[] DeclSecurityStruct;
        private int entrypoint;
        private int entrypointtoken;
        public EventMapTable[] EventMapStruct;
        public EventTable[] EventStruct;
        public ExceptionTable[] ExceptionStruct;
        private int exportaddressrva;

        private int exportaddresssize;
        public ExportedTypeTable[] ExportedTypeStruct;
        private string[] fieldflagsarray;
        public FieldLayoutTable[] FieldLayoutStruct;
        public FieldMarshalTable[] FieldMarshalStruct;
        private string[] fieldparamarray;
        public FieldPtrTable[] FieldPtrStruct;
        public FieldRVATable[] FieldRVAStruct;
        public FieldTable[] FieldStruct;
        private int filea;
        private string filename;
        public FileTable[] FileStruct;
        private int first12;
        private byte[] guid;
        private int ImageBase;
        public ImplMapTable[] ImplMapStruct;
        public InterfaceImplTable[] InterfaceImplStruct;
        private int lasttypedisplayed;
        public ManifestResourceTable[] ManifestResourceStruct;
        private BinaryReader mbinaryreader;
        public MemberRefTable[] MemberRefStruct;
        private byte[] metadata;
        private int metadatarva;
        private string methodaccessattribute;
        private string[] methoddefparamarray;

        private string[] methoddefparamarray1;
        private int[] methoddefparamcount;
        private string[] methoddefreturnarray;
        private string[] methoddeftypearray;
        public MethodImpTable[] MethodImpStruct;
        private string methodpinvokestring;
        public MethodPtrTable[] MethodPtrStruct;
        private string[] methodrefparamarray1;

        private string[] methodrefreturnarray;

        private string[] methodreftypearray;
        public MethodSemanticsTable[] MethodSemanticsStruct;
        public MethodTable[] MethodStruct;
        private int[] methodvtentryarray;
        private FileStream mfilestream;
        public ModuleRefTable[] ModuleRefStruct;
        public ModuleTable[] ModuleStruct;
        private byte[][] names;
        public NestedClassTable[] NestedClassStruct;
        private bool notprototype;
        private int[] offset;
        private int offsetblob = 2;

        private int offsetguid = 2;
        private int offsetstring = 2;
        private OpCode[] OpCodesArray;

        private OpCode[] OpCodesArray1;
        private string[] paramnames;
        public ParamTable[] ParamStruct;
        private bool placedend;
        public PropertyMapTable[] PropertyMapStruct;
        private string[] propertyparmarray;
        private string[] propertyreturnarray;
        public PropertyTable[] PropertyStruct;
        private string[] propertytypearray;
        private int[] rows;
        private int sectiona;
        private long sectionoffset;

        private short sections;
        private int[] sizes;
        private int spacefornamespace;

        private int spacesfornested;
        private int spacesforrest = 2;
        private int spacesfortry;
        private int[] SPointerToRawData;
        private int[] ssize;
        private int[] SSizeOfRawData;
        private int stackcommit;
        private int stackreserve;
        private string[] standalonesigarray;
        public StandAloneSigTable[] StandAloneSigStruct;
        private long startofmetadata;

        private string[] streamnames;
        private byte[] strings;
        private int subsystem;
        private int[] SVirtualAddress;
        private int tableoffset;
        private bool tinyformat;
        private string[] typedefnames;
        public TypeDefTable[] TypeDefStruct;
        private string[] typerefnames;
        public TypeRefTable[] TypeRefStruct;
        public TypeSpecTable[] TypeSpecStruct;
        private byte[] us;
        private long valid;
        private int vtablerva;

        private int vtablesize;
        private string[] vtfixuparray;
        private bool writenamespace;

        public void DisplayTablesForDebugging()
        {
            /*

            Console.WriteLine("Strings Table:{0}" , strings.Length);

            for ( int o = 0 ; o < strings.Length ; o++)

            {

            if ( strings[o] == 0)

            {

            Console.WriteLine();

            Console.Write("{0}:" , o+1);

            }

            else

            Console.Write("{0}" , (char)strings[o]);

            }

            */

            /*

            Console.WriteLine("Module Table:{0}" , ModuleStruct.Length);

            Console.WriteLine("Name={0} {1}", GetString(ModuleStruct[1].Name) , ModuleStruct[1].Name.ToString("X"));

            Console.WriteLine("Generation={0} Mvid={1} EncId={2} EncBaseId={3}" , ModuleStruct[1].Generation , ModuleStruct[1].Mvid , ModuleStruct[1].EncId , ModuleStruct[1].EncBaseId);

            */

            /*

            Console.WriteLine("TypeRef Table:{0}" , TypeRefStruct.Length );

            for ( int o = 1 ; o < TypeRefStruct.Length ; o++)

            {

            Console.WriteLine("Type {0}", o );

            Console.WriteLine("Resolotion Scope={0} {1}" , GetResolutionScopeTable(TypeRefStruct[o].resolutionscope), GetResolutionScopeValue(TypeRefStruct[o].resolutionscope));

            Console.WriteLine("NameSpace={0} {1}" , GetString(TypeRefStruct[o].nspace) , TypeRefStruct[o].nspace.ToString("X"));

            Console.WriteLine("Name={0} {1}" , GetString(TypeRefStruct[o].name), TypeRefStruct[o].name.ToString("X"));

            }

            */

            /*

            Console.WriteLine("TypeDef Table:{0}" , TypeDefStruct.Length );

            for ( int o = 1 ; o < TypeDefStruct.Length ; o++)

            {

            Console.WriteLine("Type {0} ", o)  ;

            Console.WriteLine("Name={0} {1}" , GetString(TypeDefStruct[o].name), TypeDefStruct[o].name.ToString("X"));

            Console.WriteLine("NameSpace={0} {1}" , GetString(TypeDefStruct[o].nspace) , TypeDefStruct[o].nspace.ToString("X"));

            Console.WriteLine("Field[{0}]", TypeDefStruct[o].findex);

            Console.WriteLine("Method[{0}]", TypeDefStruct[o].mindex);

            }

            */

            /*

            Console.WriteLine("CustomAttributeTable:{0}" , CustomAttributeStruct.Length );

            for ( int o = 1 ; o < CustomAttributeStruct.Length ; o++)

            {

            string tablename= GetHasCustomAttributeTable(CustomAttributeStruct[o].parent) ;

            int index = GetHasCustomAttributeValue(CustomAttributeStruct[o].parent);

            string methoddefref = GetCustomAttributeTypeTable(CustomAttributeStruct[o].type);

            int methoddefrefindex = GetCustomAttributeTypevalue(CustomAttributeStruct[o].type);

            Console.WriteLine("Row={0} Parent tablename={1} index={2} methoddefref={3} methoddefrefindex={4}" , o.ToString("X") , tablename , index , methoddefref , methoddefrefindex);

            }

            */

            /*

            Console.WriteLine("AssemblyRefTable:{0}" , AssemblyRefStruct.Length );

            for ( int o = 1 ; o < AssemblyRefStruct.Length ; o++)

            {

            }

            */
        }

        private bool IsMakeArray(byte[] stringarray)
        {
            var countascii = 0;

            var index = 0;

            var makearray = false;

            while (index < stringarray.Length - 1)
            {
                if (stringarray[index] >= 129)

                    countascii++;

                if (stringarray[index] <= 31 &&
                    !(stringarray[index] == 0x0d || stringarray[index] == 0x0a || stringarray[index] == 0x09))

                    countascii++;

                if (stringarray[index + 1] != 0)

                    countascii++;

                index = index + 2;
            }

            if (countascii >= 1)

                makearray = true;

            return makearray;
        }

        public void GetFieldConstantValueAsString(int tablerow, int value, int len)
        {
            var returnstring = " = ";

            Console.Write(returnstring);

            int howmanybytes = 0, uncompressedbyte, count;

            howmanybytes = CorSigUncompressData(blob, value, out uncompressedbyte);

            count = uncompressedbyte;

            value = value + howmanybytes;

            var stringarray = new byte[count];

            Array.Copy(blob, value, stringarray, 0, count);

            var makearray = IsMakeArray(stringarray);

            if (makearray && count != 0)
            {
                Console.Write("bytearray (");

                DisplayFormattedColumns(value - howmanybytes, len + 14, false, false);
            }

            else
            {
                var str = "";

                str = GetNameU(value - howmanybytes, true, tablerow);

                returnstring = "\"";

                returnstring = returnstring +
                               DisplayStringMethod(str, spacesforrest + spacesfortry + spacesfornested, tablerow, true);

                returnstring = returnstring + "\"";

                Console.WriteLine(returnstring);
            }

            return;
        }

        public string DisplayStringMethod(string str, int spaces, int tablerow, bool field)
        {
            var notfirstline = false;

            var len = str.Length;

            var countofchars = 0;

            var totalcount = 0;

            var bytecount = 49;

            var returnstring = "";

            var secondline = 101;

            if (field)
            {
                var s = GetFieldAttributes(tablerow);

                secondline = s.Length + fieldparamarray[tablerow].Length +
                             NameReserved(GetString(FieldStruct[tablerow].name)).Length + 74;
            }

            for (var ii = 0; ii < len; ii++)
            {
                if (str[ii] == '\t')

                    returnstring = returnstring + "\\t";

                else if (str[ii] == '"')

                    returnstring = returnstring + "\\\"";

                else if (str[ii] == '\\')

                    returnstring = returnstring + "\\\\";

                else if (str[ii] == 13)

                    returnstring = returnstring + "\\r";

                else if (str[ii] == 10)

                    returnstring = returnstring + "\\n";

                else if (str[ii] == '?')

                    returnstring = returnstring + "\\?";

                else

                    returnstring = returnstring + str[ii];

                if (str.Length >= 50 && str[49] == '\\')

                    bytecount = 48;

                if (countofchars == bytecount && !notfirstline && !(len == 50 || len == 51 || len == 52))
                {
                    returnstring = returnstring + "\"\r\n" + CreateSpaces(spaces) + "+ \"";

                    notfirstline = true;

                    countofchars = 0;
                }

                else if (notfirstline && (countofchars % secondline) == 0)
                {
                    var charsleft = len - totalcount;

                    if (charsleft >= 4)

                        returnstring = returnstring + "\"\r\n" + CreateSpaces(spaces) + "+ \"";

                    countofchars = 0;
                }

                totalcount++;

                countofchars++;
            }

            return returnstring;
        }

        public string GetNameU(int starting, bool blobtable, int tablerow)
        {
            int howmanybytes, uncompressedbyte;

            if (blobtable)

                howmanybytes = CorSigUncompressData(blob, starting, out uncompressedbyte);

            else

                howmanybytes = CorSigUncompressData(us, starting, out uncompressedbyte);

            var len = uncompressedbyte;

            var e = System.Text.Encoding.Unicode;

            string returnstring;

            if (blobtable)

                returnstring = e.GetString(blob, starting + howmanybytes, len);

            else

                returnstring = e.GetString(us, starting + howmanybytes, len);

            return returnstring;
        }


        public void DisplayR8(double token, byte[] codearray, int codeindex)
        {
            var b1 = codearray[codeindex + 1];

            var b2 = codearray[codeindex + 2];

            var b3 = codearray[codeindex + 3];

            var b4 = codearray[codeindex + 4];

            var b5 = codearray[codeindex + 5];

            var b6 = codearray[codeindex + 6];

            var b7 = codearray[codeindex + 7];

            var b8 = codearray[codeindex + 8];

            var doubles = token.ToString();

            var pos = doubles.IndexOf("E-");

            var d2 = 0;

            if (pos != -1)
            {
                var d1 = doubles.Substring(pos + 2);

                d2 = Convert.ToInt32(d1);
            }

            //Console.WriteLine(".......{0} {1}" , doubles , token);

            if (doubles.IndexOf("Infinity") != -1 || doubles.IndexOf("NaN") != -1 || d2 >= 308)

                Console.Write("({0} {1} {2} {3} {4} {5} {6} {7})", b1.ToString("X2"), b2.ToString("X2"), b3.ToString("X2"),
                              b4.ToString("X2"), b5.ToString("X2"), b6.ToString("X2"), b7.ToString("X2"), b8.ToString("X2"));

            else if (token == 0 && b8 == 0x80)

                Console.Write("-0.0");

            else if (token == 0 && b8 == 0x00)

                Console.Write("0.0");

            else
            {
                var s1 = new IldasmString();

                string ss = s1.ReturnStringForR8(token, 0);

                Console.Write(ss);
            }
        }

        public void GetFieldConstantValue(int constantrow, int len)
        {
            int ii;

            if (ConstantsStruct == null)
            {
                Console.WriteLine();

                return;
            }

            for (ii = 1; ii < ConstantsStruct.Length; ii++)
            {
                var tabletype = ConstantsStruct[ii].parent & 0x03;

                if (tabletype == 0)
                {
                    var constantrowcoded = ConstantsStruct[ii].parent >> 2;

                    if (constantrowcoded == constantrow)

                        break;
                }
            }

            if (ii != ConstantsStruct.Length)
            {
                if (ConstantsStruct[ii].dtype == 14)

                    GetFieldConstantValueAsString(constantrow, ConstantsStruct[ii].value, len);

                else
                {
                    var ss = DisplayFromConstantsTable(constantrow, 0, "FieldDef");

                    Console.Write(ss);
                }
            }

            else

                Console.WriteLine();
        }

        public string DisplayFromConstantsTable(int start, int end, string tablename)
        {
            var returnstring = "";

            if (ConstantsStruct == null)

                return "";

            for (var ii = 1; ii < ConstantsStruct.Length; ii++)
            {
                var consttablename = GetHasConstTable(ConstantsStruct[ii].parent);

                var constindex = GetHasConstValue(ConstantsStruct[ii].parent);

                if (consttablename == tablename)
                {
                    if (start == constindex)
                    {
                        if (consttablename == "Property" || consttablename == "FieldDef")

                            returnstring = " = ";

                        else

                            returnstring = "  = ";

                        var value = ConstantsStruct[ii].value;

                        if (ConstantsStruct[ii].dtype == 2)
                        {
                            var val = BitConverter.ToBoolean(blob, ConstantsStruct[ii].value + 1);

                            if (val)

                                returnstring = returnstring + GetType(ConstantsStruct[ii].dtype) + "(true)" + "\r\n";

                            else

                                returnstring = returnstring + GetType(ConstantsStruct[ii].dtype) + "(false)" + "\r\n";
                        }

                        if (ConstantsStruct[ii].dtype == 0x03)
                        {
                            returnstring = returnstring + "char(0x";

                            var val = BitConverter.ToInt16(blob, value + 1);

                            returnstring = returnstring + val.ToString("X4");

                            returnstring = returnstring + ")\r\n";
                        }

                        if (ConstantsStruct[ii].dtype == 0x04 || ConstantsStruct[ii].dtype == 0x05)
                        {
                            int val = blob[ConstantsStruct[ii].value + 1];

                            returnstring = returnstring + GetType(0x04) + "(0x" + val.ToString("X2") + ")" + "\r\n";
                        }

                        if (ConstantsStruct[ii].dtype == 0x06 || ConstantsStruct[ii].dtype == 0x07)
                        {
                            var val = BitConverter.ToInt16(blob, ConstantsStruct[ii].value + 1);

                            //if ( val == -1)

                            //returnstring = returnstring +  GetType(0x06) + "(0xFFFF)" + "\r\n";

                            //else

                            returnstring = returnstring + GetType(0x06) + "(0x" + val.ToString("X4") + ")" + "\r\n";
                        }

                        if (ConstantsStruct[ii].dtype == 0x08 || ConstantsStruct[ii].dtype == 0x09)
                        {
                            var val = BitConverter.ToInt32(blob, ConstantsStruct[ii].value + 1);

                            returnstring = returnstring + GetType(0x08) + "(0x" + val.ToString("X8") + ")" + "\r\n";
                        }

                        if (ConstantsStruct[ii].dtype == 0x0a || ConstantsStruct[ii].dtype == 0x0b)
                        {
                            var val = BitConverter.ToInt64(blob, ConstantsStruct[ii].value + 1);

                            returnstring = returnstring + GetType(0x0a) + "(0x" + val.ToString("X") + ")" + "\r\n";
                        }

                        if (ConstantsStruct[ii].dtype == 12)
                        {
                            returnstring = returnstring + "float32(";

                            var singlevalue = BitConverter.ToSingle(blob, value + 1);

                            var val = BitConverter.ToInt32(blob, value + 1);

                            var s = singlevalue.ToString();

                            var decimalpoint = s.IndexOf(".");

                            if (singlevalue == 1.5e+009)

                                returnstring = returnstring + "1.5e+009";

                            else if (decimalpoint == -1 && !(s.IndexOf("Infinity") != -1 || s.IndexOf("NaN") != -1))

                                returnstring = returnstring + s + ".";

                            else

                                returnstring = returnstring + "0x" + val.ToString("X8");

                            returnstring = returnstring + ")\r\n";

                            //Console.WriteLine(returnstring);
                        }

                        if (ConstantsStruct[ii].dtype == 13)
                        {
                            returnstring = returnstring + "float64(";

                            var val = BitConverter.ToDouble(blob, value + 1);

                            //int dummy = BitConverter.ToInt32(blob , value+1);

                            var s1 = new IldasmString();

                            string ss = s1.ReturnStringForR8(val, 1);

                            returnstring = returnstring + ss + "\r\n";
                        }

                        if (ConstantsStruct[ii].dtype == 0xe)
                        {
                            int len = blob[ConstantsStruct[ii].value];

                            if (len >= 1)
                            {
                                returnstring = returnstring + "\"";

                                for (var jj = 1; jj < len; jj++)
                                {
                                    if (blob[ConstantsStruct[ii].value + jj] != 0)

                                        returnstring = returnstring + (char)blob[ConstantsStruct[ii].value + jj];
                                }

                                returnstring = returnstring + "\"\r\n";
                            }

                            else

                                returnstring = returnstring + "\"\"" + "\r\n";
                        }

                        if (ConstantsStruct[ii].dtype == 0x12)
                        {
                            returnstring = returnstring + "nullref" + "\r\n";
                        }
                    }
                }
            }

            return returnstring;
        }

        public int DecodeILInstrcution2(OpCode opcode, int codeindex, byte[] codearray, int methodindex, string strings)
        {
            var sizeofinstructiondata = 0;

            if (opcode.OperandType == OperandType.ShortInlineR)
            {
                Console.Write(strings);

                var b1 = codearray[codeindex + 1];

                var b2 = codearray[codeindex + 2];

                var b3 = codearray[codeindex + 3];

                var b4 = codearray[codeindex + 4];

                //int int32value = BitConverter.ToInt32(codearray, codeindex+1);

                var singlevalue = BitConverter.ToSingle(codearray, codeindex + 1);

                var s = singlevalue.ToString();

                Console.Write("{0}{1}{2}{3}", b1.ToString("X2"), b2.ToString("X2"), b3.ToString("X2"), b4.ToString("X2"));

                Console.Write(CreateSpaces(8));

                Console.Write(" */ {0} {1} ", opcode.Name, CreateSpaces(3));

                if (singlevalue == 0.015625)

                    Console.Write("1.5625e-002");

                else if (singlevalue == 1.5e+009)

                    Console.Write("1.5e+009");

                else if (singlevalue == 1.5e+008)

                    Console.Write("1.5e+008");

                else if (singlevalue == 0 && b4 == 0x80)

                    Console.Write("-0.0");

                else if (singlevalue == 0)

                    Console.Write("0.0");

                else if (s.EndsWith(".5") || s.EndsWith(".25") || s.EndsWith(".75") || s.EndsWith("0625") ||
                         s.EndsWith("125") || s.EndsWith(".375"))

                    Console.Write(s);

                else
                {
                    //Console.WriteLine(".......A");

                    var s4 = new IldasmString();

                    string ss = s4.ReturnStringForR4(singlevalue);

                    if (ss == "")

                        Console.Write("({0} {1} {2} {3})", b1.ToString("X2"), b2.ToString("X2"), b3.ToString("X2"),
                                      b4.ToString("X2"));

                    else

                        Console.Write(ss);
                }

                sizeofinstructiondata = 5;
            }

            if (opcode.OperandType == OperandType.InlineR)
            {
                Console.Write(strings);

                var token = BitConverter.ToDouble(codearray, codeindex + 1);

                var b1 = codearray[codeindex + 1];

                var b2 = codearray[codeindex + 2];

                var b3 = codearray[codeindex + 3];

                var b4 = codearray[codeindex + 4];

                var b5 = codearray[codeindex + 5];

                var b6 = codearray[codeindex + 6];

                var b7 = codearray[codeindex + 7];

                var b8 = codearray[codeindex + 8];

                Console.Write("{0}{1}{2}{3}{4}{5}{6}{7}", b1.ToString("X2"), b2.ToString("X2"), b3.ToString("X2"),
                              b4.ToString("X2"), b5.ToString("X2"), b6.ToString("X2"), b7.ToString("X2"), b8.ToString("X2"));

                Console.Write(" */ {0} {1} ", opcode.Name, CreateSpaces(3));

                DisplayR8(token, codearray, codeindex);

                sizeofinstructiondata = 9;
            }

            if (opcode.OperandType == OperandType.InlineString)
            {
                Console.Write(strings);

                var token = BitConverter.ToInt32(codearray, codeindex + 1);

                token = token & 0x00ffffff;

                int howmanybytes, uncompressedbyte5;

                howmanybytes = CorSigUncompressData(us, token, out uncompressedbyte5);

                var count = uncompressedbyte5;

                //int count = uncompressedbyte5 - 1;

                var stringarray = new byte[count];

                var startingpt = token + howmanybytes;

                Array.Copy(us, startingpt, stringarray, 0, count);

                var makearray = IsMakeArray(stringarray);

                if (makearray && count != 0)
                {
                    Console.Write("(70){0}       */ {1}      ", token.ToString("X6"), opcode.Name);

                    Console.Write("bytearray (");

                    DisplayFormattedColumns(token, 62 + (spacesforrest + 2 + spacesfortry + spacesfornested), false, true);
                }

                else
                {
                    var str = GetNameU(token, false, 0);

                    Console.Write("(70){0}       */ {1}      ", token.ToString("X6"), opcode.Name);

                    Console.Write("\"");

                    string returnstring;

                    returnstring = DisplayStringMethod(str, spacesforrest + 2 + spacesfortry + spacesfornested, 0, false);

                    Console.Write(returnstring);

                    Console.Write("\" /* 70{0} */", token.ToString("X6"));
                }

                sizeofinstructiondata = 5;
            }

            if (codearray.Length - 1 == codeindex && opcode.OperandType == OperandType.InlineMethod)
            {
                Console.Write(strings);

                Console.Write("(00)02301B       */ call       0x2301b ");

                return 1;
            }

            if (opcode.OperandType == OperandType.InlineNone)
            {
                Console.Write(strings);

                Console.Write("{0}*/ {1}", CreateSpaces(17), opcode.Name);

                if (opcode.Name == "ret" && codeindex != (codearray.Length - 1))

                    Console.WriteLine();

                if (opcode.Name == "throw" && codeindex != (codearray.Length - 1))

                    Console.WriteLine();

                sizeofinstructiondata = 1;
            }

            if (opcode.OperandType == OperandType.InlineI)
            {
                Console.Write(strings);

                var token = BitConverter.ToInt32(codearray, codeindex + 1);

                var b1 = codearray[codeindex + 1];

                var b2 = codearray[codeindex + 2];

                var b3 = codearray[codeindex + 3];

                var b4 = codearray[codeindex + 4];

                Console.Write("{0}{1}{2}{3}", b1.ToString("X2"), b2.ToString("X2"), b3.ToString("X2"), b4.ToString("X2"));

                Console.Write(CreateSpaces(8));

                Console.Write(" */ {0} {1} 0x{2}", opcode.Name, CreateSpaces(3), token.ToString("x"));

                sizeofinstructiondata = 5;
            }

            if (opcode.OperandType == OperandType.InlineI8)
            {
                Console.Write(strings);

                var token = BitConverter.ToInt64(codearray, codeindex + 1);

                var b1 = codearray[codeindex + 1];

                var b2 = codearray[codeindex + 2];

                var b3 = codearray[codeindex + 3];

                var b4 = codearray[codeindex + 4];

                var b5 = codearray[codeindex + 5];

                var b6 = codearray[codeindex + 6];

                var b7 = codearray[codeindex + 7];

                var b8 = codearray[codeindex + 8];

                Console.Write("{0}{1}{2}{3}{4}{5}{6}{7}", b1.ToString("X2"), b2.ToString("X2"), b3.ToString("X2"),
                              b4.ToString("X2"), b5.ToString("X2"), b6.ToString("X2"), b7.ToString("X2"), b8.ToString("X2"));

                Console.Write(" */ {0} {1} 0x{2}", opcode.Name, CreateSpaces(3), token.ToString("x"));

                sizeofinstructiondata = 9;
            }

            if (opcode.OperandType == OperandType.ShortInlineI)
            {
                Console.Write(strings);

                int token = codearray[codeindex + 1];

                Console.Write("{0}", token.ToString("X2"));

                Console.Write(CreateSpaces(14));

                if (token >= 128)

                    token = token - 256;

                if (opcode.Name == "unaligned.")

                    Console.Write(" */ {0} {1}", opcode.Name, token);

                else

                    Console.Write(" */ {0}   {1}", opcode.Name, token);

                sizeofinstructiondata = 2;
            }

            if (opcode.OperandType == OperandType.InlineBrTarget)
            {
                Console.Write(strings);

                var token = BitConverter.ToInt32(codearray, codeindex + 1);

                var returnstring = "";

                var b1 = codearray[codeindex + 1];

                var b2 = codearray[codeindex + 2];

                var b3 = codearray[codeindex + 3];

                var b4 = codearray[codeindex + 4];

                Console.Write("{0}{1}{2}{3}", b1.ToString("X2"), b2.ToString("X2"), b3.ToString("X2"), b4.ToString("X2"));

                Console.Write(CreateSpaces(9) + "*/ ");

                token = token + codeindex + 5;

                var len = opcode.Name.Length;

                returnstring = opcode.Name + " " + CreateSpaces(9 - len) + " IL_" + token.ToString("x4");

                Console.Write(returnstring);

                if (!(codearray.Length == codeindex + 5))

                    Console.WriteLine();

                sizeofinstructiondata = 5;
            }

            if (opcode.OperandType == OperandType.ShortInlineBrTarget)
            {
                Console.Write(strings);

                int token = codearray[codeindex + 1];

                var returnstring = "";

                Console.Write("{0}", token.ToString("X2"));

                Console.Write(CreateSpaces(15) + "*/ ");

                if (token >= 128)
                {
                    token = 0xff - token;

                    token = codeindex + 1 - token;
                }

                else

                    token = token + codeindex + 2;

                var len = opcode.Name.Length;

                returnstring = opcode.Name + " " + CreateSpaces(9 - len) + " IL_" + token.ToString("x4");

                Console.Write(returnstring);

                if (!(codearray.Length == codeindex + 2))

                    Console.WriteLine();

                sizeofinstructiondata = 2;
            }

            if (opcode.OperandType == OperandType.InlineSwitch)
            {
                Console.Write(strings);

                var token = BitConverter.ToInt32(codearray, codeindex + 1);

                var b1 = codearray[codeindex + 1];

                var b2 = codearray[codeindex + 2];

                var b3 = codearray[codeindex + 3];

                var b4 = codearray[codeindex + 4];

                Console.Write("{0}{1}{2}{3}", b1.ToString("X2"), b2.ToString("X2"), b3.ToString("X2"), b4.ToString("X2"));

                Console.Write(CreateSpaces(9));

                Console.Write("*/ switch     ( ");

                if (token == 0)

                    Console.Write(")");

                else

                    for (var ii = 1; ii <= token; ii++)
                    {
                        Console.Write("\r\n" + CreateSpaces(spacesforrest + 2 + spacesfortry + spacesfornested));

                        Console.Write(CreateSpaces(10) + "/*      | ");

                        var index = BitConverter.ToInt32(codearray, codeindex + 1 + ii * 4);

                        b1 = codearray[codeindex + 1 + ii * 4];

                        b2 = codearray[codeindex + 2 + ii * 4];

                        b3 = codearray[codeindex + 3 + ii * 4];

                        b4 = codearray[codeindex + 4 + ii * 4];

                        Console.Write("{0}{1}{2}{3}", b1.ToString("X2"), b2.ToString("X2"), b3.ToString("X2"),
                                      b4.ToString("X2"));

                        var tot = codeindex + index + 1 + token * 4 + 4;

                        Console.Write(CreateSpaces(9) + "*/" + CreateSpaces(13) + "IL_{0}", tot.ToString("x4"));

                        if (ii != token)

                            Console.Write(",");

                        else

                            Console.Write(")");
                    }

                sizeofinstructiondata = 5 + token * 4;
            }

            if (opcode.OperandType == OperandType.ShortInlineVar)
            {
                Console.Write(strings);

                int token = codearray[codeindex + 1];

                Console.Write("{0}", token.ToString("X2"));

                Console.Write(CreateSpaces(15) + "*/ {0}", opcode.Name);

                var len = opcode.Name.Length;

                if (opcode.Name == "ldarg.s" || opcode.Name == "ldarga.s" || opcode.Name == "starg.s")
                {
                    var methodattributeflags = GetMethodAttribute(MethodStruct[methodindex].flags, methodindex);

                    var sname = "";

                    if (token > methoddefparamcount[methodindex] && methodattributeflags.IndexOf("static") != -1)

                        sname = token + " // ERROR: invalid arg index (>=" + (methoddefparamcount[methodindex] + 1) + ")";

                    else if (token > methoddefparamcount[methodindex] + 1 && methodattributeflags.IndexOf("instance") != -1)

                        sname = token + " // ERROR: invalid arg index (>=" + (methoddefparamcount[methodindex] + 1) + ")";

                    else if (token == 0 && methodattributeflags.IndexOf("instance") != -1)

                        sname = "0";

                    else
                    {
                        if (methodattributeflags.IndexOf("static") != -1)

                            token++;

                        sname = GetParamNameForMethod(methodindex, 0, token);
                    }

                    Console.Write("{0}{1}", CreateSpaces(11 - len), sname);
                }

                else

                    Console.Write("{0}V_{1}", CreateSpaces(11 - len), token);

                sizeofinstructiondata = 2;
            }

            if (opcode.OperandType == OperandType.InlineVar)
            {
                Console.Write(strings);

                var token = (ushort)BitConverter.ToInt16(codearray, codeindex + 1);

                var b1 = codearray[codeindex + 1];

                var b2 = codearray[codeindex + 2];

                Console.Write("{0}{1}", b1.ToString("X2"), b2.ToString("X2"));

                Console.Write(CreateSpaces(13) + "*/ {0}", opcode.Name);

                var len = opcode.Name.Length;

                if (opcode.Name == "ldarg" || opcode.Name == "ldarga" || opcode.Name == "starg")
                {
                    var methodattributeflags = GetMethodAttribute(MethodStruct[methodindex].flags, methodindex);

                    var sname = "";

                    if (token > methoddefparamcount[methodindex] && methodattributeflags.IndexOf("static") != -1)

                        sname = token + " // ERROR: invalid arg index (>=" + (methoddefparamcount[methodindex] + 1) + ")";

                    else if (token > methoddefparamcount[methodindex] + 1 && methodattributeflags.IndexOf("instance") != -1)

                        sname = token + " // ERROR: invalid arg index (>=" + (methoddefparamcount[methodindex] + 1) + ")";

                    else if (token == 0 && methodattributeflags.IndexOf("instance") != -1)

                        sname = "0";

                    else
                    {
                        if (methodattributeflags.IndexOf("static") != -1)

                            token++;

                        sname = GetParamNameForMethod(methodindex, 0, token);
                    }

                    Console.Write("{0}{1}", CreateSpaces(11 - len), sname);
                }

                else

                    Console.Write("{0}V_{1}", CreateSpaces(11 - len), token);

                sizeofinstructiondata = 3;
            }

            if (opcode.OperandType == OperandType.InlineField || opcode.OperandType == OperandType.InlineMethod ||
                opcode.OperandType == OperandType.InlineType || opcode.OperandType == OperandType.InlineTok ||
                opcode.OperandType == OperandType.InlineSig)
            {
                var token = BitConverter.ToInt32(codearray, codeindex + 1);

                int seriouserror;

                DecodeTokenIL(token, opcode, methodindex, strings, out seriouserror);

                var table = (int)(token & 0xff000000);

                table = table >> 24;

                token = token & 0x00ffffff;

                if (table == 0x0a)
                {
                    var b = HasCustomAttribute("MemberRef", token);

                    if (b)
                    {
                        Console.WriteLine();

                        DisplayCustomAttribute("MemberRef", token, 2 + spacesforrest + spacesfornested);
                    }
                }

                if (seriouserror == 1)

                    sizeofinstructiondata = codearray.Length + 1;

                else

                    sizeofinstructiondata = 5;
            }


            return sizeofinstructiondata;
        }

        public void DisplayCustomAttribute(string tname, int tabindex, int noofspaces)
        {
            if (CustomAttributeStruct == null)

                return;

            for (var ii = 1; ii < CustomAttributeStruct.Length; ii++)
            {
                var parentcodedtablename = GetHasCustomAttributeTable(CustomAttributeStruct[ii].parent);

                var parentcodedindex = GetHasCustomAttributeValue(CustomAttributeStruct[ii].parent);

                var typecodetable = GetCustomAttributeTypeTable(CustomAttributeStruct[ii].type);

                var typecodedindex = GetCustomAttributeTypevalue(CustomAttributeStruct[ii].type);

                string initialspaces;

                initialspaces = CreateSpaces(noofspaces);

                var tableindexcode = 0;

                var tablenumber = 0;

                var returnstring = "";

                var custombug = false;

                int typeindex;

                var typename = "";

                var returnvaluestring = "";

                var paramstring = "";

                var dummy = "";

                var methodname = "";

                var onespace = "";

                if ((tname == parentcodedtablename && tabindex == parentcodedindex) ||
                    (parentcodedtablename == "TypeRef" && tabindex == 0))
                {
                    if (typecodetable == "MethodRef")
                    {
                        tableindexcode = 0x0A;

                        typeindex = MemberRefStruct[typecodedindex].clas >> 3;

                        typename = typerefnames[typeindex];

                        returnvaluestring = methodrefreturnarray[typecodedindex];

                        paramstring = methodrefparamarray1[typecodedindex];

                        tablenumber = 1;

                        methodname = NameReserved(GetString(MemberRefStruct[typecodedindex].name));

                        onespace = " ";
                    }

                    else
                    {
                        tableindexcode = 0x06;

                        typeindex = GetTypeForMethod(typecodedindex);

                        typename = typedefnames[typeindex];

                        returnvaluestring = methoddefreturnarray[typecodedindex];

                        paramstring = methoddefparamarray1[typecodedindex];

                        tablenumber = 02;

                        methodname = NameReserved(GetString(MethodStruct[typecodedindex].name));
                    }

                    if (typename.IndexOf("System.Diagnostics.DebuggableAttribute") != -1)

                        custombug = true;

                    if (custombug)
                    {
                        Console.Write(CreateSpaces(noofspaces));

                        Console.WriteLine(
                            "// --- The following custom attribute is added automatically, do not uncomment -------");

                        returnstring = returnstring + CreateSpaces(noofspaces) + "//";

                        if (initialspaces == "")

                            returnstring = returnstring + "  ";
                    }

                    if (parentcodedtablename == "TypeRef")
                    {
                        returnstring = returnstring + initialspaces + ".custom /*0C" + ii.ToString("X6") + "*/ (" +
                                       typerefnames[parentcodedindex];

                        returnstring = returnstring + "/*" + tablenumber.ToString("X2") + parentcodedindex.ToString("X6") +
                                       "*/ ) ";
                    }

                    else

                        returnstring = returnstring + initialspaces + ".custom /*0C" + ii.ToString("X6") + ":" +
                                       tableindexcode.ToString("X2") + typecodedindex.ToString("X6") + "*/ ";

                    returnstring = returnstring + "instance " + returnvaluestring + onespace + typename;

                    returnstring = returnstring + "::" + methodname;

                    returnstring = returnstring + "(";

                    if (noofspaces == 0)

                        dummy = ParamOnMultipleLines(paramstring, returnstring.Length + 2);

                    else if (paramstring != null)

                        dummy = ParamOnMultipleLines(paramstring, returnstring.Length);

                    if (custombug)
                    {
                        var ind1 = dummy.IndexOf("\r\n");

                        dummy = dummy.Insert(ind1 + 2, CreateSpaces(noofspaces) + "//");

                        dummy = dummy.Remove(ind1 + 10, 4);
                    }

                    returnstring = returnstring + dummy;

                    returnstring = returnstring + ")";

                    returnstring = returnstring + " /* " + tableindexcode.ToString("X2") + typecodedindex.ToString("X6") +
                                   " */";

                    Console.Write(returnstring);

                    ///////

                    var index = CustomAttributeStruct[ii].value;

                    int howmanybytes, uncompressedbyte;

                    howmanybytes = CorSigUncompressData(blob, index, out uncompressedbyte);

                    if (uncompressedbyte == 0)
                    {
                        Console.WriteLine();

                        continue;
                    }

                    index = index + howmanybytes;

                    var blobarray = new byte[uncompressedbyte];

                    Array.Copy(blob, index, blobarray, 0, uncompressedbyte);

                    var displayoneline = true;

                    var displaystring = "";

                    for (var jj = 0; jj < uncompressedbyte; jj++)
                    {
                        if (blobarray[jj] < 0x20)

                            displayoneline = false;

                        if (blobarray[jj] >= 0x7f)

                            displayoneline = false;
                    }

                    if (displayoneline)
                    {
                        displaystring = " = \"";

                        for (var jj = 0; jj < uncompressedbyte; jj++)
                        {
                            displaystring = displaystring + (char)blobarray[jj];
                        }

                        displaystring = displaystring + "\"";

                        if (tname == "MemberRef")

                            Console.Write(displaystring);

                        else

                            Console.WriteLine(displaystring);
                    }

                    else
                    {
                        var startoffunctionclosebracket = returnstring.LastIndexOf(")");

                        var lastenter = returnstring.LastIndexOf("\r\n");

                        if (lastenter == -1)

                            lastenter = -2;

                        var diff2 = startoffunctionclosebracket - lastenter + 19;

                        Console.Write(" = ( ");

                        DisplayFormattedColumns(CustomAttributeStruct[ii].value, diff2, false, false);
                    }
                }
            }
        }

        public void Read(string[] args)
        {
            ReadPEStructures(args);

            DisplayPEStructures();

            ReadandDisplayImportAdressTable();

            ReadandDisplayCLRHeader();

            ReadStreamsData();

            FillTableSizes();

            ReadTablesIntoStructures();

            DisplayTablesForDebugging();

            ReadandDisplayVTableFixup();

            ReadandDisplayExportAddressTableJumps();

            FillArray();

            FillOpCodeArray();

            CreateSignatures();

            DisplayModuleRefs();

            DisplayAssembleyRefs();

            DisplayAssembley();

            DisplayFileTable();

            DisplayClassExtern();

            DisplayResources();

            DisplayModuleAndMore();

            DispalyVtFixup();

            DisplayTypeDefs();

            DisplayTypeDefsAndMethods();
        }

        public void DisplayFormattedColumns(int index, int startingspaces, bool putonespace, bool opcode)
        {
            int howmanybytes, uncompressedbyte;

            if (opcode)
            {
                howmanybytes = CorSigUncompressData(us, index, out uncompressedbyte);

                uncompressedbyte = uncompressedbyte - 1;
            }

            else

                howmanybytes = CorSigUncompressData(blob, index, out uncompressedbyte);

            var token = index;

            index = index + howmanybytes;

            var blobarray = new byte[uncompressedbyte];

            if (opcode)

                Array.Copy(us, index, blobarray, 0, uncompressedbyte);

            else

                Array.Copy(blob, index, blobarray, 0, uncompressedbyte);

            var maincounter = 0;

            while (maincounter < uncompressedbyte)
            {
                var firststring = "";

                var secondstring = "";

                var counterforascii = 0;

                int ii;

                var noascii = false;

                for (counterforascii = 0; counterforascii < 16; counterforascii++)
                {
                    if (maincounter == uncompressedbyte)

                        break;

                    if (blobarray[maincounter] >= 0x20 && blobarray[maincounter] <= 0x7e)

                        noascii = true;

                    maincounter++;
                }

                maincounter -= counterforascii;

                for (ii = 0; ii < 16; ii++)
                {
                    if (maincounter == uncompressedbyte)

                        break;

                    firststring = firststring + blobarray[maincounter].ToString("X2") + " ";

                    if (blobarray[maincounter] >= 0x20 && blobarray[maincounter] <= 0x7e)

                        secondstring = secondstring + (char)blobarray[maincounter];

                    else

                        secondstring = secondstring + ".";

                    maincounter++;
                }

                if (maincounter == uncompressedbyte)
                {
                    var leftovers = maincounter % 16;

                    if (leftovers != 0)
                    {
                        leftovers = 15 - leftovers;

                        firststring = firststring + ")";

                        var space = leftovers * 3 + 3;

                        if (noascii)

                            firststring = firststring + CreateSpaces(space);

                        else

                            firststring = firststring + " ";
                    }

                    else
                    {
                        firststring = firststring + ")";

                        if (putonespace && uncompressedbyte <= 16)

                            firststring = firststring + " ";

                        firststring = firststring + CreateSpaces(0);
                    }
                }

                if (maincounter == uncompressedbyte)
                {
                    if (noascii)

                        firststring = firststring + " // " + secondstring;

                    if (uncompressedbyte == 16 && !noascii && opcode)

                        firststring = firststring + "  /* 70" + token.ToString("X6") + " */";

                    else if (opcode)

                        firststring = firststring + " /* 70" + token.ToString("X6") + " */";
                }

                else
                {
                    if (noascii)

                        firststring = firststring + "  // " + secondstring;
                }

                if (maincounter == uncompressedbyte && opcode)

                    Console.Write(firststring);

                else

                    Console.WriteLine(firststring);

                if (maincounter != uncompressedbyte)

                    Console.Write(CreateSpaces(startingspaces));
            }
        }

        public string DecodeMemberRefToken(int token, int methodindex, OpCode opcode)
        {
            var returnstring = "";

            //Console.WriteLine(".......{0}" , token.ToString("X"));

            if (token >= MemberRefStruct.Length)

                return " $MR$" + token.ToString("X2") + "() /* 0A0000" + token.ToString("X2") + " */";

            var row = MemberRefStruct[token].clas;

            var codedindextable = GetMemberRefParentCodedIndexTable(row);

            var codedindexrow = row >> 3;

            var initialstring = "";

            //Console.WriteLine(".......{0}" , codedindextable);

            if (codedindextable == "ModuleRef")
            {
                initialstring = methodreftypearray[token] + methodrefreturnarray[token] + " ";

                var name = NameReserved(GetString(ModuleRefStruct[codedindexrow].name));

                initialstring = initialstring + "[.module " + name + "/* 1A" + codedindexrow.ToString("X6") + " */]";
            }

            if (codedindextable == "TypeSpec") //arrays.exe
            {
                var returnarray = methodrefreturnarray[token];

                var typeplusreturn = methodreftypearray[token] + returnarray;

                var types = CreateSignatureForTypeSpec(codedindexrow);

                types = types.Replace("^", ",");

                initialstring = typeplusreturn + " " + types;
            }

            else if (codedindextable == "MethodDef")
            {
                initialstring = initialstring + methodreftypearray[token] + methodrefreturnarray[token] + " ";

                var typeindex = GetTypeForMethod(codedindexrow);

                initialstring = initialstring + typedefnames[typeindex];
            }

            else if (codedindextable == "TypeRef")
            {
                if (opcode.Name == "ldtoken")
                {
                    var typeindex1 = 0;

                    var typename = NameReserved(GetString(TypeRefStruct[codedindexrow].name));

                    var typenamespace = NameReserved(GetString(TypeRefStruct[codedindexrow].nspace));

                    for (var typecnt = 1; typecnt < TypeDefStruct.Length; typecnt++)
                    {
                        if (typename == NameReserved(GetString(TypeDefStruct[typecnt].name)) &&
                            typenamespace == NameReserved(GetString(TypeDefStruct[typecnt].nspace)))
                        {
                            typeindex1 = typecnt;

                            //Console.WriteLine("...{0}" , typename , );

                            break;
                        }
                    }

                    int start, startofnext;

                    start = TypeDefStruct[typeindex1].findex;

                    if (typeindex1 == (TypeDefStruct.Length - 1))

                        startofnext = FieldStruct.Length;

                    else

                        startofnext = TypeDefStruct[typeindex1 + 1].findex;

                    var found = false;

                    for (var fieldindex = start; fieldindex < startofnext; fieldindex++)
                    {
                        var name = NameReserved(GetString(MemberRefStruct[token].name));

                        if (name == NameReserved(GetString(FieldStruct[fieldindex].name)))
                        {
                            found = true;

                            break;
                        }
                    }

                    if (found)

                        initialstring = "field ";

                    else

                        initialstring = "method ";
                }

                initialstring = initialstring + methodreftypearray[token] + methodrefreturnarray[token] + " ";

                initialstring = initialstring + typerefnames[codedindexrow];

                //Console.WriteLine("......{0} {1}" , codedindexrow , typerefnames[codedindexrow] );
            }

            else if (codedindextable == "TypeDef")
            {
                if (opcode.Name == "ldtoken")

                    initialstring = "field ";

                initialstring = initialstring + methodreftypearray[token] + methodrefreturnarray[token] + " ";

                initialstring = initialstring + typedefnames[codedindexrow];
            }

            var methodparmarraystring = methodrefparamarray1[token];

            var nameplusparams = "";

            if (methodparmarraystring != null)
            {
                nameplusparams = NameReserved(GetString(MemberRefStruct[token].name)) + "(";

                var len = 51 + spacesforrest + 2 + spacesfortry + spacesfornested + nameplusparams.Length +
                          initialstring.Length + 2;

                nameplusparams = nameplusparams + ParamOnMultipleLines(methodparmarraystring, len);

                nameplusparams = nameplusparams + ")";
            }

            else

                nameplusparams = NameReserved(GetString(MemberRefStruct[token].name));

            returnstring = initialstring + "::" + nameplusparams + " /* 0A" + token.ToString("X6") + " */";

            return returnstring;
        }

        public string DecodeMemberDefToken(int token, OpCode opcode)
        {
            var returnstring = "";

            if (token >= MethodStruct.Length)

                return returnstring;

            var name = NameReserved(GetString(MethodStruct[token].name));

            var methodattributes = GetMethodAttribute(MethodStruct[token].flags, token);

            if (methodattributes.IndexOf("privatescope ") != -1)

                name = name + "$PST06" + token.ToString("X6");

            var typeindex = GetTypeForMethod(token);

            if (opcode.Name == "ldtoken")

                returnstring = "method ";

            returnstring = returnstring + methoddeftypearray[token] + methoddefreturnarray[token] + typedefnames[typeindex];

            returnstring = returnstring + "::" + name + "(";

            var len = returnstring.Length + 53 + spacesforrest + spacesfortry + spacesfornested;

            var sfinal = methoddefparamarray1[token];

            returnstring = returnstring + ParamOnMultipleLines(sfinal, len) + ")";

            returnstring = returnstring + " " + "/* 06" + token.ToString("X6") + " */";

            return returnstring;
        }

        public void DecodeTokenIL(int token, OpCode opcode, int methodindex, string strings, out int seriouserror)
        {
            seriouserror = 0;

            var originaltoken = token;

            var table = (int)(token & 0xff000000);

            table = table >> 24;

            token = token & 0x00ffffff;

            //if ( opcode.Name == "ldtoken")

            //Console.WriteLine("........");

            if (table == 4 && token > FieldStruct.Length)
            {
                Console.Write("     ********* ERROR DISASSEMBLING THE METHOD IL CODE ***********");

                seriouserror = 1;

                return;
            }

            if (table == 1 && token > TypeRefStruct.Length)
            {
                Console.Write("     ********* ERROR DISASSEMBLING THE METHOD IL CODE ***********");

                seriouserror = 1;

                return;
            }

            Console.Write(strings);

            if (table == 0)
            {
                Console.Write("({0}){1}       */ {2}{3}0x{4} ", table.ToString("X2"), token.ToString("X6"), opcode.Name,
                              CreateSpaces(11 - opcode.Name.Length), token.ToString("X2"));
            }

            if (table >= 60 || table < 0)
            {
                var dummybyte = (byte)table;

                var returnstring = "(" + dummybyte.ToString("X2") + ")" + token.ToString("X6");

                returnstring = returnstring + "       */ " + opcode.Name;

                Console.Write(returnstring);

                var len = 31 - returnstring.Length;

                Console.Write(CreateSpaces(len));

                Console.Write("<unknown token type 0x" + dummybyte.ToString("x2") + ">");
            }

            if (table == 0x01)
            {
                var returnstring = "(01)" + token.ToString("X6") + "       */ " + opcode.Name;

                var len = opcode.Name.Length;

                returnstring = returnstring + CreateSpaces(11 - len) + typerefnames[token];

                Console.Write(returnstring);
            }

            if (table == 0x02)
            {
                var returnstring = "(02)" + token.ToString("X6") + "       */ " + opcode.Name;

                var len = opcode.Name.Length;

                returnstring = returnstring + CreateSpaces(11 - len) + typedefnames[token];

                Console.Write(returnstring);
            }

            if (table == 0x06) //Method
            {
                var returnstring = "(06)" + token.ToString("X6") + "       */ " + opcode.Name;

                var len = opcode.Name.Length;

                returnstring = returnstring + CreateSpaces(11 - len) + DecodeMemberDefToken(token, opcode);

                Console.Write(returnstring);
            }

            if (table == 0x04)
            {
                var returnstring = "(" + table.ToString("X2") + ")" + token.ToString("X6");

                returnstring = returnstring + "       */ " + opcode.Name;

                Console.Write(returnstring);

                var typeindex = GetTypeForField(token);

                if (opcode.Name == "ldtoken")

                    Console.Write("    field ");

                else
                {
                    var len = opcode.Name.Length;

                    Console.Write(CreateSpaces(11 - len));
                }

                Console.Write(fieldparamarray[token]);

                var finalstring = typedefnames[typeindex];

                Console.Write(" {0}::", finalstring, typeindex.ToString("X6"));

                var name = NameReserved(GetString(FieldStruct[token].name));

                if (fieldflagsarray[token].IndexOf("privatescope ") != -1)

                    name = name + "$PST04" + token.ToString("X6");

                name = name + " /* 04" + token.ToString("X6") + " */";

                Console.Write(name);
            }

            if (table == 0x0a) //MemberRef
            {
                var returnstring = "(0A)" + token.ToString("X6") + "       */ " + opcode.Name;

                var len = opcode.Name.Length;

                returnstring = returnstring + CreateSpaces(11 - len) + DecodeMemberRefToken(token, methodindex, opcode);

                Console.Write(returnstring);
            }

            if (table == 0x11) //StandAlonesig
            {
                var b1 = token & 0xff;

                var b2 = (token & 0xff00) >> 8;

                var b3 = (token & 0xff0000) >> 16;

                var returnstring = b1.ToString("X2") + b2.ToString("X2") + b3.ToString("X2") + table.ToString("X2");

                returnstring = returnstring + "         */ " + opcode.Name + "      ";

                var dummy = CreateSignatureForCalli(token);

                var len = opcode.Name.Length;

                if (dummy == "error")

                    returnstring = "(" + table.ToString("X2") + ")" + token.ToString("X6") + "       */ " + opcode.Name +
                                   CreateSpaces(11 - len) + "<unknown token type 0x" + table.ToString("X2") + ">";

                else

                    returnstring = returnstring + dummy + " /*" + originaltoken.ToString("X8") + "*/";

                Console.Write(returnstring);
            }

            if (table == 0x1b) // Typespec
            {
                var returnstring = "(" + table.ToString("X2") + ")" + token.ToString("X6");

                returnstring = returnstring + "       */ " + opcode.Name;

                var len = opcode.Name.Length;

                var types = CreateSignatureForTypeSpec(token);

                types = types.Replace("^", ",");

                returnstring = returnstring + CreateSpaces(11 - len) + types;

                Console.Write(returnstring);
            }
        }

        public string CreateSignatureForCalli(int row)
        {
            var aa = -1;

            int howmanybytes, uncompressedbyte, count;

            if (row >= StandAloneSigStruct.Length)

                return "error";

            var index = StandAloneSigStruct[row].index;

            howmanybytes = CorSigUncompressData(blob, index, out uncompressedbyte);

            count = uncompressedbyte;

            var blobarray = new byte[count];

            Array.Copy(blob, index + howmanybytes, blobarray, 0, count);

            if (row == aa)
            {
                for (var i = 0; i < count; i++)

                    Console.Write("{0} ", blobarray[i].ToString("X"));

                Console.WriteLine();
            }

            var types = DecodeFirstByteofMethodSignature(blobarray[0], row);

            index = 1;

            howmanybytes = CorSigUncompressData(blobarray, index, out uncompressedbyte);

            count = uncompressedbyte;

            index = index + howmanybytes;

            var returnstring = types;

            int dummyint1;

            returnstring = returnstring + GetElementType(index, blobarray, out dummyint1, 0, "");

            index = index + dummyint1;

            returnstring = returnstring + "(";

            for (var l = 1; l <= count; l++)
            {
                if (blobarray[index] == 0x41)
                {
                    returnstring = returnstring + "...,";

                    index = index + 1;
                }

                var dummy = GetElementType(index, blobarray, out howmanybytes, 0, "");

                returnstring = returnstring + dummy;

                if (l != count)

                    returnstring = returnstring + ",";

                index = index + howmanybytes;
            }

            if (index < blobarray.Length && blobarray[index] == 0x41)

                returnstring = returnstring + ",...";

            returnstring = returnstring + ")";

            return returnstring;
        }

        public string CreateSignatureForTypeSpec(int row)
        {
            var returnstring = "";

            int howmanybytes, uncompressedbyte, count;

            var index = TypeSpecStruct[row].signature;

            howmanybytes = CorSigUncompressData(blob, index, out uncompressedbyte);

            count = uncompressedbyte;

            var blobarray = new byte[count];

            Array.Copy(blob, index + howmanybytes, blobarray, 0, count);

            /*

            Console.WriteLine(".........{0} {1} {2} {3}" , count , blob[index] ,blob[index+1], blob[index+2] );

            for ( int i = 0 ; i < count ; i++)

            Console.Write("{0} " , blobarray[i]);

            Console.WriteLine();

            */

            returnstring = GetElementType(0, blobarray, out howmanybytes, 0, "");

            return returnstring;
        }

        public string GetParamNameForMethod(int row, int count, int l)
        {
            var returnstring = "";

            var mattributes = GetMethodAttribute(MethodStruct[row].flags, row);

            if (ParamStruct == null)
            {
                //isnan.exe

                if (mattributes.IndexOf("static") != -1)

                    l--;

                return "A_" + l;
            }

            int start, startofnext = 0, paramcount;

            start = MethodStruct[row].param;

            if (row == (MethodStruct.Length - 1))

                startofnext = ParamStruct.Length;

            else

                startofnext = MethodStruct[row + 1].param;

            paramcount = startofnext - start;

            int ind;

            var paramfound = false;

            for (ind = start; ind < startofnext; ind++)
            {
                if (ParamStruct[ind].sequence == l)
                {
                    paramfound = true;

                    break;
                }
            }

            //if ( ind < paramnames.Length && && paramfound)

            if (paramfound && paramnames[ind] != "")
            {
                returnstring = NameReserved(paramnames[ind]);
            }

            else
            {
                //Interop.orders.dll

                if (mattributes.IndexOf("static") != -1)

                    l--;

                returnstring = "A_" + l;
            }

            return returnstring;
        }

        public void FillOpCodeArray()
        {
            OpCodesArray = new OpCode[256];

            OpCodesArray1 = new OpCode[32];

            var fields =
                typeof(OpCodes).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static |
                                           BindingFlags.Instance | BindingFlags.DeclaredOnly);

            //Console.WriteLine("Name              Value OperandType          Flow         OpCode     Size");

            foreach (var f in fields)
            {
                var o = (OpCode)f.GetValue(null);

                //if ( o.OperandType  == OperandType.InlineField)

                //Console.WriteLine("{0,-17} {1,5} {2,-20} {3,-12} {4,-10} {5}" , o.Name, o.Value.ToString("X") , o.OperandType , o.FlowControl , o.OpCodeType , o.Size);

                if (o.Value <= 255 && o.Value >= 0)

                    OpCodesArray[o.Value] = o;

                OpCodesArray1[0x00] = OpCodes.Arglist;

                OpCodesArray1[0x01] = OpCodes.Ceq;

                OpCodesArray1[0x02] = OpCodes.Cgt;

                OpCodesArray1[0x03] = OpCodes.Cgt_Un;

                OpCodesArray1[0x04] = OpCodes.Clt;

                OpCodesArray1[0x05] = OpCodes.Clt_Un;

                OpCodesArray1[0x06] = OpCodes.Ldftn;

                OpCodesArray1[0x07] = OpCodes.Ldvirtftn;

                OpCodesArray1[0x09] = OpCodes.Ldarg;

                OpCodesArray1[0x0A] = OpCodes.Ldarga;

                OpCodesArray1[0x0B] = OpCodes.Starg;

                OpCodesArray1[0x0C] = OpCodes.Ldloc;

                OpCodesArray1[0x0D] = OpCodes.Ldloca;

                OpCodesArray1[0x0E] = OpCodes.Stloc;

                OpCodesArray1[0x0F] = OpCodes.Localloc;

                OpCodesArray1[0x11] = OpCodes.Endfilter;

                OpCodesArray1[0x12] = OpCodes.Unaligned;

                OpCodesArray1[0x13] = OpCodes.Volatile;

                OpCodesArray1[0x14] = OpCodes.Tailcall;

                OpCodesArray1[0x15] = OpCodes.Initobj;

                OpCodesArray1[0x17] = OpCodes.Cpblk;

                OpCodesArray1[0x18] = OpCodes.Initblk;

                OpCodesArray1[0x1A] = OpCodes.Rethrow;

                OpCodesArray1[0x1C] = OpCodes.Sizeof;

                OpCodesArray1[0x1D] = OpCodes.Refanytype;
            }
        }

        public void DisplayAllMethods(int typeindex)
        {
            if (TypeDefStruct == null)

                return;

            if (MethodStruct == null)

                return;

            int start, startofnext = 0;

            start = TypeDefStruct[typeindex].mindex;

            if (typeindex == (TypeDefStruct.Length - 1))
            {
                startofnext = MethodStruct.Length;
            }

            else

                startofnext = TypeDefStruct[typeindex + 1].mindex;

            for (var methodindex = start; methodindex < startofnext; methodindex++)
            {
                var methodstring = CreateSpaces(spacesforrest);

                if (IsTypeNested(typeindex))

                    methodstring = methodstring + CreateSpaces(spacesfornested);

                methodstring = methodstring + ".method ";

                methodstring = methodstring + "/*06" + methodindex.ToString("X6") + "*/ ";

                var methodattribute = GetMethodAttribute(MethodStruct[methodindex].flags, methodindex);

                var pos1 = methodattribute.IndexOf("instance");

                if (pos1 != -1)

                    methodattribute = methodattribute.Remove(pos1, 9);

                var enterformethodattrbute = "";

                var enterforreturnvalue = "";

                var enterformarshal = "";

                var paramattrstring = "";

                var parammarshalstring = "";

                paramattrstring = GetParamAttrforMethodCalling(methodindex);

                parammarshalstring = GetParamAttrforMethodMarshal(methodindex, 0);

                var nspace = "";

                nspace = NameReserved(GetString(TypeDefStruct[typeindex].nspace));

                var parenttype = GetParentForNestedType(typeindex);

                if (parenttype != 0)

                    nspace = NameReserved(GetString(TypeDefStruct[parenttype].nspace));

                var cat2return = false;

                var cat3returnvaluemarshal = false;

                var cat4 = false;

                var howmany = HowManyMethodAttributes(methodattribute);

                if (parammarshalstring == "")
                {
                    if (methodattribute == "public static " && !(IsTypeNested(typeindex) && nspace != ""))

                        cat2return = true;

                    if (methodattribute == "private static " && !(IsTypeNested(typeindex) && nspace != ""))

                        cat2return = true;

                    if (methodattribute == "family static " && !(IsTypeNested(typeindex) && nspace != ""))

                        cat2return = true;

                    if (methodattribute == "assembly static " && !IsTypeNested(typeindex) && nspace == "")

                        cat2return = true;

                    if (methodattribute == "public virtual " && !(IsTypeNested(typeindex) && nspace != ""))

                        cat2return = true;

                    if (methodattribute == "private virtual " && !IsTypeNested(typeindex) && nspace == "")

                        cat2return = true;

                    if (methodattribute == "family virtual " && !(IsTypeNested(typeindex) && nspace != ""))

                        cat2return = true;

                    if (methodattribute == "public newslot " && !(IsTypeNested(typeindex) && nspace != ""))

                        cat2return = true;

                    if (methodattribute == "private newslot " && !IsTypeNested(typeindex) && nspace == "")

                        cat2return = true;

                    if (methodattribute == "family newslot " && !(IsTypeNested(typeindex) && nspace != ""))

                        cat2return = true;

                    if (methodattribute == "public final ")

                        cat2return = true;

                    if (methodattribute == "private final " && !(IsTypeNested(typeindex) && nspace != ""))

                        cat2return = true;

                    if (methodattribute == "family final ")

                        cat2return = true;

                    if (methodattribute == "public abstract " && !IsTypeNested(typeindex) && nspace == "")

                        cat2return = true;

                    if (methodattribute == "private abstract " && !IsTypeNested(typeindex) && nspace == "")

                        cat2return = true;

                    if (methodattribute == "family abstract " && !IsTypeNested(typeindex) && nspace == "")

                        cat2return = true;

                    if (methodattribute == "public hidebysig " && !IsTypeNested(typeindex) && nspace == "")

                        cat2return = true;

                    if (methodattribute == "family hidebysig " && !IsTypeNested(typeindex) && nspace == "")

                        cat2return = true;

                    if (methodattribute.IndexOf("pinvokeimpl") == -1)
                    {
                        if (howmany == 0 && methoddeftypearray[methodindex].IndexOf("instance ") != -1)

                            cat2return = true;
                    }
                }

                var aa = 0x00;

                if (parammarshalstring != "")
                {
                    if (methodattribute == "public hidebysig " && nspace == "" && !IsTypeNested(typeindex))

                        cat3returnvaluemarshal = true;

                    if (methodattribute == "family hidebysig " && nspace == "" && !IsTypeNested(typeindex))

                        cat3returnvaluemarshal = true;

                    if (methodattribute == "public virtual " && nspace != "" && !IsTypeNested(typeindex))

                        cat3returnvaluemarshal = true;

                    if (methodattribute == "public virtual " && nspace == "" && !IsTypeNested(typeindex))

                        cat3returnvaluemarshal = true;

                    if (methodattribute == "public virtual " && nspace == "" && IsTypeNested(typeindex))

                        cat3returnvaluemarshal = true;

                    if (methodattribute == "public static " && !(IsTypeNested(typeindex) && nspace != ""))

                        cat3returnvaluemarshal = true;

                    if (methodattribute == "private static " && !(IsTypeNested(typeindex) && nspace != ""))

                        cat3returnvaluemarshal = true;

                    if (methodattribute == "family static " && !(IsTypeNested(typeindex) && nspace != ""))

                        cat3returnvaluemarshal = true;


                    if (methodattribute == "assembly static " && !IsTypeNested(typeindex) && nspace == "")

                        cat3returnvaluemarshal = true;

                    if (howmany == 0 && methoddeftypearray[methodindex] == "instance ")

                        cat3returnvaluemarshal = true;
                }

                if (parammarshalstring != "" && methodattribute.IndexOf("pinvokeimpl") == -1)
                {
                    if (methodattribute == "public virtual " && nspace != "" && IsTypeNested(typeindex))

                        cat4 = true;

                    if (howmany == 0 && IsTypeNested(typeindex) && nspace != "" && methoddeftypearray[methodindex] == "")
                    {
                        var problem1 = true;

                        if (methodindex == aa)

                            Console.WriteLine("....{0} {1}..", methoddefreturnarray[methodindex].Length,
                                              methoddefreturnarray[methodindex]);

                        if (methodattribute == "assembly static " || methodattribute == "public static " ||
                            methodattribute == "private static " || methodattribute == "family static ")
                        {
                            if (paramattrstring == "")

                                problem1 = false;
                        }

                        if (problem1)

                            cat4 = true;
                    }

                    if (methodattribute.IndexOf("hidebysig") != -1)
                    {
                        if (methodattribute.IndexOf("public") != -1 || methodattribute.IndexOf("family") != -1)
                        {
                            if (IsTypeNested(typeindex) || nspace != "")

                                cat4 = true;
                        }

                        else

                            cat4 = true;
                    }

                    if (howmany >= 2)

                        cat4 = true;
                }

                if (cat2return)
                {
                    enterformethodattrbute = "";

                    enterforreturnvalue = "\r\n" + CreateSpaces(spacesforrest + 8 + spacesfornested);

                    enterformarshal = "";
                }

                else if (cat3returnvaluemarshal)
                {
                    enterformethodattrbute = "";

                    enterforreturnvalue = "\r\n" + CreateSpaces(spacesforrest + 8 + spacesfornested);

                    enterformarshal = "\r\n" + CreateSpaces(spacesforrest + 8 + spacesfornested);
                }

                else if (cat4)
                {
                    enterformethodattrbute = "\r\n" + CreateSpaces(spacesforrest + 8 + spacesfornested);

                    enterforreturnvalue = "\r\n" + CreateSpaces(spacesforrest + 8 + spacesfornested);

                    enterformarshal = "\r\n" + CreateSpaces(spacesforrest + 8 + spacesfornested);
                }

                else
                {
                    enterformethodattrbute = "\r\n" + CreateSpaces(spacesforrest + 8 + spacesfornested);

                    enterforreturnvalue = " ";

                    if (parammarshalstring != "")

                        enterformarshal = " ";
                }

                methodstring = methodstring + methodattribute + enterformethodattrbute;

                methodstring = methodstring + methoddeftypearray[methodindex] + paramattrstring;

                methodstring = methodstring + methoddefreturnarray[methodindex] + enterforreturnvalue;

                methodstring = methodstring + parammarshalstring + enterformarshal;

                if (methodstring.Length - methodstring.LastIndexOf("\r\n") >= 44)
                {
                    methodstring = methodstring.Remove(methodstring.Length - 1, 1);

                    methodstring = methodstring + "\r\n" + CreateSpaces(spacesforrest + 8 + spacesfornested);
                }

                methodstring = methodstring + NameReserved(GetString(MethodStruct[methodindex].name));

                if (methodattribute.IndexOf("privatescope") != -1)

                    methodstring = methodstring + "$PST06" + methodindex.ToString("X6");

                methodstring = methodstring + "(";

                var len = 0;

                if (methoddefparamarray[methodindex] != null)
                {
                    var indexofenter = methodstring.LastIndexOf("\r\n");

                    var lengthofstring = methodstring.Length;

                    len = lengthofstring - indexofenter - 2;

                    methodstring = methodstring + ParamOnMultipleLines(methoddefparamarray[methodindex], len);
                }

                methodstring = methodstring + ")";

                var implflags = GetMethodAttribute1(MethodStruct[methodindex].impflags);

                methodstring = methodstring + " " + implflags;

                var methodsignature = GetMethodSignatureBytes(methodindex);

                methodstring = methodstring + methodsignature;

                methodstring = methodstring + "\r\n" + CreateSpaces(spacesforrest + spacesfornested) + "{";

                var tablerow = entrypointtoken & 0x00ffffff;

                if (tablerow == methodindex)

                    methodstring = methodstring + "\r\n" + CreateSpaces(spacesforrest + 2 + spacesfornested) + ".entrypoint";

                Console.WriteLine(methodstring);

                DisplayCustomAttribute("MethodDef", methodindex, 2 + spacesforrest + spacesfornested);

                DisplayParamsForMethod(methodindex);

                DisplayAllSecurity(1, methodindex);

                DisplayOverrideMethod(methodindex); // interfaces.exe

                if (implflags.IndexOf("cil managed") == -1 || MethodStruct[methodindex].rva == 0)
                {
                    var problem1 = true;

                    if (methodattribute.IndexOf("pinvokeimpl") != -1)
                    {
                        if (methodattribute.IndexOf("pinvokeimpl(/* No map */)") != -1)
                        {
                            Console.WriteLine("  // Embedded native code");

                            Console.WriteLine("  //  Disassembly of native methods is not supported.");

                            Console.WriteLine("  //  Managed TargetRVA = 0x{0}",
                                              MethodStruct[methodindex].rva.ToString("x4"));

                            Console.WriteLine(CreateSpaces(spacesforrest + spacesfornested) + "} // end of global method " +
                                              NameReserved(GetString(MethodStruct[methodindex].name)));
                        }

                        else
                        {
                            methodstring = CreateSpaces(spacesforrest + spacesfornested) + "}";

                            Console.Write(methodstring);
                        }

                        methodstring = "";

                        problem1 = false;
                    }

                    else if (implflags.IndexOf("runtime managed") != -1)
                    {
                        methodstring = "";
                    }

                    else if (implflags.IndexOf("runtime unmanaged") != -1)

                        methodstring = "    //  Method provided by Runtime\r\n";

                    else if (implflags.IndexOf("native unmanaged") != -1)

                        methodstring = "    //  Unmanaged TargetRVA = 0x" + MethodStruct[methodindex].rva.ToString("x4") +
                                       "\r\n";

                    else if (implflags.IndexOf("native") != -1)
                    {
                        methodstring = "    //  Disassembly of native methods is not supported.";

                        methodstring = methodstring + "\r\n    //  Managed TargetRVA = 0x" +
                                       MethodStruct[methodindex].rva.ToString("x4") + "\r\n";
                    }

                    else if (MethodStruct[methodindex].rva == 0 && implflags.IndexOf("unmanaged") == -1)
                    {
                        methodstring = CreateSpaces(spacesforrest + spacesfornested + 2) + "// Method begins at RVA 0x0\r\n";
                    }

                    else if (implflags.IndexOf("optil") != -1)
                    {
                        methodstring = CreateSpaces(spacesforrest + spacesfornested + 2) + "// Method begins at RVA 0x" +
                                       MethodStruct[methodindex].rva.ToString("x4") + "\r\n";

                        methodstring = methodstring + CreateSpaces(spacesforrest + spacesfornested + 2) +
                                       "// Code size       0 (0x0)\r\n";
                    }

                    else
                    {
                        methodstring = "";
                    }

                    if (problem1)

                        methodstring = methodstring + CreateSpaces(spacesforrest + spacesfornested) + "} // end of method " +
                                       NameReserved(GetString(TypeDefStruct[typeindex].name)) + "::" +
                                       NameReserved(GetString(MethodStruct[methodindex].name)) + "\r\n";

                    Console.WriteLine(methodstring);

                    continue;
                }

                var vtentrystring = GetVtentryString(methodindex);

                methodstring = vtentrystring;

                methodstring = methodstring + CreateSpaces(spacesforrest + 2 + spacesfornested) +
                               "// Method begins at RVA 0x" + MethodStruct[methodindex].rva.ToString("x4");

                Console.Write(methodstring);

                var fileoffset = ConvertRVA(MethodStruct[methodindex].rva);

                mfilestream.Seek(fileoffset, SeekOrigin.Begin);

                DisplayFatFormat(NameReserved(GetString(TypeDefStruct[typeindex].name)),
                                 NameReserved(GetString(MethodStruct[methodindex].name)), methodindex);
            }
        }

        public void DisplayFatFormat(string classname, string methodname, int methodindex)
        {
            DisplayInitialMethodHeader(methodindex);

            DisplayMethodILCode(classname, methodname, methodindex);
        }

        public void DisplayInitialMethodHeader(int methodindex)
        {
            int tiny = mbinaryreader.ReadByte();

            if ((tiny & 0x03) == 0x03)

                tinyformat = false;

            else

                tinyformat = true;

            mfilestream.Seek(-1, SeekOrigin.Current);

            var methodstring = "";

            if (!tinyformat)
            {
                var where = mfilestream.Position;

                var first = mbinaryreader.ReadInt16();

                first12 = (short)(first & 0x0fff);

                var first4 = (short)(first & 0xf000);

                first4 = (short)(first4 >> 12);

                var stacksize = mbinaryreader.ReadInt16();

                codesize = mbinaryreader.ReadInt32();

                methodstring = "\r\n" + CreateSpaces(spacesforrest + 2 + spacesfornested) + "// Code size       " + codesize +
                               " (0x" + codesize.ToString("x") + ")\r\n";

                if ((first12 & 0x08) == 0x08)

                    ReadExceptions(where, codesize, methodindex);

                methodstring = methodstring + CreateSpaces(spacesforrest + 2 + spacesfornested) + ".maxstack  " + stacksize;

                var standalonesig = mbinaryreader.ReadInt32();

                var rowstandalonesig = standalonesig & 0x00ffffff;

                //Console.WriteLine(".......{0} " , rowstandalonesig);

                if (StandAloneSigStruct != null && standalonesigarray == null)

                    standalonesigarray = new string[StandAloneSigStruct.Length];


                if (rowstandalonesig != 0)
                {
                    CreateSignatureForEachType(5, StandAloneSigStruct[rowstandalonesig].index, rowstandalonesig);

                    if (standalonesigarray[rowstandalonesig] != "")
                    {
                        methodstring = methodstring + "\r\n" + CreateSpaces(spacesforrest + 2 + spacesfornested) +
                                       ".locals /*11" + rowstandalonesig.ToString("X6") + "*/ ";

                        if ((first12 & 0x10) == 0x10)

                            methodstring = methodstring + "init (";

                        else

                            methodstring = methodstring + "(";

                        methodstring = methodstring + standalonesigarray[rowstandalonesig];

                        methodstring = methodstring + ")";
                    }
                }
            }

            else
            {
                mbinaryreader.ReadByte();

                codesize = tiny >> 2;

                methodstring = methodstring + "\r\n" + CreateSpaces(spacesforrest + 2 + spacesfornested) +
                               "// Code size       " + codesize + " (0x" + codesize.ToString("x") + ")";

                if (codesize != 0)

                    methodstring = methodstring + "\r\n" + CreateSpaces(spacesforrest + 2 + spacesfornested) +
                                   ".maxstack  8";
            }

            Console.WriteLine(methodstring);
        }


        public string DisplayParamsForMethod(int methodrow)
        {
            if (ParamStruct == null)

                return "";

            var returnstring = "";

            int start = 0, end = 0;

            start = MethodStruct[methodrow].param;

            if (methodrow == (MethodStruct.Length - 1))

                end = ParamStruct.Length;

            else

                end = MethodStruct[methodrow + 1].param;

            for (var index = start; index < end; index++)
            {
                var seq = ParamStruct[index].sequence;

                returnstring = CreateSpaces(spacesforrest + spacesfornested + 2) + ".param [" + seq + "]" + "/*08" +
                               index.ToString("X6") + "*/";

                var str = DisplayFromConstantsTable(index, 0, "ParamDef");

                if (str != "")

                    Console.Write(returnstring + str);

                var b = HasCustomAttribute("ParamDef", index);

                if (b && str == "")

                    Console.WriteLine(returnstring + " ");

                DisplayCustomAttribute("ParamDef", index, spacesforrest + spacesfornested + 2);
            }

            return "";
        }

        public int GetCustomAttributeTypevalue(int attributecodedtype)
        {
            return attributecodedtype >> 3;
        }

        public string GetCustomAttributeTypeTable(int attributecodedtype)
        {
            var returnstring = "";

            var tag = attributecodedtype & 0x07;

            if (tag == 0)

                returnstring = returnstring + "NotUsed";

            if (tag == 1)

                returnstring = returnstring + "NotUsed";

            if (tag == 2)

                returnstring = returnstring + "MethodDef";

            if (tag == 3)

                returnstring = returnstring + "MethodRef";

            if (tag == 4)

                returnstring = returnstring + "NotUsed";

            return returnstring;
        }

        public int GetHasCustomAttributeValue(int attributecodedparent)
        {
            return attributecodedparent >> 5;
        }

        public string GetHasCustomAttributeTable(int attributecodedparent)
        {
            var returnstring = "";

            var tag = attributecodedparent & 0x1F;

            if (tag == 0)

                returnstring = returnstring + "MethodDef";

            if (tag == 1)

                returnstring = returnstring + "FieldDef";

            if (tag == 2)

                returnstring = returnstring + "TypeRef";

            if (tag == 3)

                returnstring = returnstring + "TypeDef";

            if (tag == 4)

                returnstring = returnstring + "ParamDef";

            if (tag == 5)

                returnstring = returnstring + "InterfaceImpl";

            if (tag == 6)

                returnstring = returnstring + "MemberRef";

            if (tag == 7)

                returnstring = returnstring + "Module";

            if (tag == 8)

                returnstring = returnstring + "DeclSecurity";

            if (tag == 9)

                returnstring = returnstring + "Property";

            if (tag == 10)

                returnstring = returnstring + "Event";

            if (tag == 11)

                returnstring = returnstring + "Signature";

            if (tag == 12)

                returnstring = returnstring + "ModuleRef";

            if (tag == 13)

                returnstring = returnstring + "TypeSpec";

            if (tag == 14)

                returnstring = returnstring + "Assembly";

            if (tag == 15)

                returnstring = returnstring + "AssemblyRef";

            if (tag == 16)

                returnstring = returnstring + "File";

            if (tag == 17)

                returnstring = returnstring + "ExportedType";

            if (tag == 18)

                returnstring = returnstring + "ManifestResource";

            return returnstring;
        }


        public void CreateSignatures()
        {
            //StandAloneSig

            //MethodTable

            if (MethodStruct != null)
            {
                methoddefreturnarray = new string[MethodStruct.Length];

                methoddefparamarray = new string[MethodStruct.Length];

                methoddefparamarray1 = new string[MethodStruct.Length];

                methoddeftypearray = new string[MethodStruct.Length];

                methoddefparamcount = new int[MethodStruct.Length];

                for (var l = 1; l < MethodStruct.Length; l++)
                {
                    CreateSignatureForEachType(1, MethodStruct[l].signature, l);
                }
            }

            //MethodRefTable

            if (MemberRefStruct != null)
            {
                methodreftypearray = new string[MemberRefStruct.Length];

                methodrefreturnarray = new string[MemberRefStruct.Length];

                methodrefparamarray1 = new string[MemberRefStruct.Length];

                for (var l = 1; l < MemberRefStruct.Length; l++)
                {
                    CreateSignatureForEachType(2, MemberRefStruct[l].sig, l);
                }
            }

            //fieldtable

            if (FieldStruct != null)
            {
                fieldflagsarray = new string[FieldStruct.Length];

                fieldparamarray = new string[FieldStruct.Length];

                for (var l = 1; l < FieldStruct.Length; l++)
                {
                    CreateSignatureForEachType(6, FieldStruct[l].sig, l);
                }
            }

            //propertytable

            if (PropertyStruct != null)
            {
                propertyparmarray = new string[PropertyStruct.Length];

                propertyreturnarray = new string[PropertyStruct.Length];

                propertytypearray = new string[PropertyStruct.Length];

                for (var l = 1; l < PropertyStruct.Length; l++)
                {
                    CreateSignatureForEachType(7, PropertyStruct[l].type, l);
                }
            }
        }

        public void CreateSignatureForEachType(byte type, int index, int row)
        {
            int uncompressedbyte, count, howmanybytes;

            howmanybytes = CorSigUncompressData(blob, index, out uncompressedbyte);

            count = uncompressedbyte;

            var blob1 = new byte[count];

            Array.Copy(blob, index + howmanybytes, blob1, 0, count);

            if (type == 7)

                CreatePropertySignature(blob1, row);

            if (type == 6)

                CreateFieldSignature(blob1, row);

            if (type == 5)

                CreateLocalVarSignature(blob1, row);

            if (type == 1)

                CreateMethodDefSignature(blob1, row);

            if (type == 2)

                CreateMethodRefSignature(blob1, row);
        }

        public void DisplayOneType(int typedefindex)
        {
            DisplayOneTypeDefStart(typedefindex);

            DisplaySizeAndPack(typedefindex);

            DisplayCustomAttribute("TypeDef", typedefindex, 2 + spacefornamespace + spacesfornested);

            DisplayAllSecurity(0, typedefindex);

            DisplayNestedTypes(typedefindex);

            DisplayOverride(typedefindex);

            DisplayAllFields(typedefindex);

            DisplayAllMethods(typedefindex);

            DisplayAllEvents(typedefindex);

            DisplayAllProperties(typedefindex);

            DisplayOneTypeDefEnd(typedefindex);
        }

        public void DisplayAllFields(int typeindex)
        {
            if (FieldStruct == null)

                return;

            int start, startofnext = 0;

            start = TypeDefStruct[typeindex].findex;

            if (typeindex == (TypeDefStruct.Length - 1))

                startofnext = FieldStruct.Length;

            else

                startofnext = TypeDefStruct[typeindex + 1].findex;

            var returnstring = "";

            for (var fieldindex = start; fieldindex < startofnext; fieldindex++)
            {
                if (NameReserved(GetString(FieldStruct[fieldindex].name)) == "_Deleted")

                    continue;

                if (typeindex == 1)

                    returnstring = "";

                else

                    returnstring = CreateSpaces(spacesfornested + spacesforrest);

                returnstring = returnstring + ".field /*04" + fieldindex.ToString("X6") + "*/";

                returnstring = returnstring + " " + fieldflagsarray[fieldindex] + fieldparamarray[fieldindex] + " " +
                               NameReserved(GetString(FieldStruct[fieldindex].name));

                if (fieldindex < fieldflagsarray.Length && fieldflagsarray[fieldindex] != null &&
                    fieldflagsarray[fieldindex].IndexOf("privatescope") != -1)
                {
                    var ss = GetString(FieldStruct[fieldindex].name);

                    if (ss.Length == 1 && (byte)ss[0] == 1)
                    {
                        returnstring = returnstring.Remove(returnstring.Length - 1, 1);

                        returnstring = returnstring + "$PST04" + fieldindex.ToString("X6") + "'";
                    }

                    else

                        returnstring = returnstring + "$PST04" + fieldindex.ToString("X6");
                }

                var fieldrva = GetFieldRVA(fieldindex);

                if (fieldrva != "")

                    returnstring = returnstring + " at" + fieldrva;

                var len = returnstring.Length;

                Console.Write(returnstring);

                GetFieldConstantValue(fieldindex, len);

                DisplayCustomAttribute("FieldDef", fieldindex, spacesfornested + spacesforrest);
            }
        }

        /////


        public void DisplayAllEvents(int typeindex)
        {
            int ii;

            if (EventMapStruct == null)

                return;

            for (ii = 1; ii < EventMapStruct.Length; ii++)
            {
                if (typeindex == (EventMapStruct[ii].index))

                    break;
            }

            if (ii == EventMapStruct.Length)

                return;

            var start = EventMapStruct[ii].eindex;

            int end;

            if (ii == EventMapStruct.Length - 1)

                end = EventStruct.Length - 1;

            else

                end = EventMapStruct[ii + 1].eindex - 1;

            for (var eventrow = start; eventrow <= end; eventrow++)
            {
                Console.Write(CreateSpaces(spacesforrest + spacesfornested));

                Console.Write(".event /*14{0}*/ {1}", (eventrow).ToString("X6"),
                              GetPropertyAttribute(EventStruct[eventrow].attr));

                var name = NameReserved(GetString(EventStruct[eventrow].name));

                var codedtablename = GetTypeDefOrRefTable(EventStruct[eventrow].coded);

                var codedindex = GetTypeDefOrRefValue(EventStruct[eventrow].coded);

                var returnstring = "";

                if (codedtablename == "TypeRef")

                    returnstring = typerefnames[codedindex] + " /*01" + codedindex.ToString("X6") + "*/";

                if (codedtablename == "TypeDef")

                    returnstring = typedefnames[codedindex] + " /*02" + codedindex.ToString("X6") + "*/";

                Console.Write(returnstring);

                Console.Write(" " + name);

                Console.WriteLine();

                Console.Write(CreateSpaces(spacesforrest + spacesfornested));

                Console.WriteLine("{");

                DisplayCustomAttribute("Event", eventrow, spacesfornested + spacesforrest + 2);

                for (var kk = 1; kk < MethodSemanticsStruct.Length; kk++)
                {
                    var attributes = GetMethodSemanticsAttributes(MethodSemanticsStruct[kk].methodsemanticsattributes);

                    var table = GetHasSemanticsTable(MethodSemanticsStruct[kk].association);

                    var eventindex = GetHasSemanticsValue(MethodSemanticsStruct[kk].association);

                    var methodindex = MethodSemanticsStruct[kk].methodindex;

                    var methodattribute = GetMethodAttribute(MethodStruct[methodindex].flags, methodindex);

                    if (eventindex == eventrow && table == "Event")
                    {
                        Console.Write(CreateSpaces(spacesforrest + 2 + spacesfornested));

                        Console.Write("{0} {1}{2}", attributes, methoddeftypearray[methodindex],
                                      methoddefreturnarray[methodindex]);

                        var name1 = NameReserved(GetString(MethodStruct[methodindex].name));


                        Console.Write("{0}::{1}({2})", typedefnames[typeindex], name1, methoddefparamarray1[methodindex]);

                        Console.WriteLine(" /* 06{0} */", (methodindex).ToString("X6"));
                    }
                }

                Console.Write(CreateSpaces(spacesforrest + spacesfornested));

                Console.Write("} ");

                Console.WriteLine("// end of event {0}::{1}", NameReserved(GetString(TypeDefStruct[typeindex].name)), name);
            }
        }


        public string GetPropertyAttributeDefault(int flags, int row)
        {
            var returnstring = "";

            if ((flags & 0x1000) == 0x1000)
            {
                returnstring = DisplayFromConstantsTable(row, 0, "Property");

                returnstring = returnstring.Remove(returnstring.Length - 2, 2);
            }

            return returnstring;
        }

        public void CreatePropertySignature(byte[] blobarray, int row)
        {
            var aa = -1;

            if (row == aa)
            {
                for (var l = 0; l < blobarray.Length; l++)

                    Console.Write("{0} ", blobarray[l].ToString("X"));

                Console.WriteLine();
            }

            int howmanybytes, uncompressedbyte;

            var index = 0;

            howmanybytes = CorSigUncompressData(blobarray, index, out uncompressedbyte);

            index = index + howmanybytes;

            if ((uncompressedbyte & 0x20) == 0x20)

                propertytypearray[row] = "instance ";

            howmanybytes = CorSigUncompressData(blobarray, index, out uncompressedbyte);

            index = index + howmanybytes;

            var count = uncompressedbyte;

            var typestring = "";

            var returnstring = "";

            returnstring = GetElementType(index, blobarray, out howmanybytes, 0, "");

            propertyreturnarray[row] = returnstring;

            index = index + howmanybytes;

            returnstring = "";

            for (var l = 1; l <= count; l++)
            {
                typestring = GetElementType(index, blobarray, out howmanybytes, 0, "");

                returnstring = returnstring + typestring;

                index = index + howmanybytes;

                if (l != count)

                    returnstring = returnstring + ",";
            }

            propertyparmarray[row] = returnstring;
        }

        public string GetPropertyAttribute(int flags)
        {
            var returnstring = "";

            if ((flags & 0x200) == 0x200)

                returnstring = returnstring + "specialname ";

            if ((flags & 0x400) == 0x400)

                returnstring = returnstring + "rtspecialname ";

            return returnstring;
        }

        public void DisplayAllProperties(int typeindex)
        {
            int ii;

            if (PropertyMapStruct == null || PropertyStruct == null)

                return;

            for (ii = 1; ii < PropertyMapStruct.Length; ii++)
            {
                if (typeindex == (PropertyMapStruct[ii].parent))

                    break;
            }

            if (ii == PropertyMapStruct.Length)

                return;

            var start = PropertyMapStruct[ii].propertylist;

            int end;

            if (ii + 1 == PropertyMapStruct.Length)

                end = PropertyStruct.Length - 1;

            else

                end = PropertyMapStruct[ii + 1].propertylist - 1;

            for (var propertyrow = start; propertyrow <= end; propertyrow++)
            {
                var returnstring = CreateSpaces(spacesforrest + spacesfornested);

                returnstring = returnstring + ".property /*17" + propertyrow.ToString("X6") + "*/ ";

                var name = NameReserved(GetString(PropertyStruct[propertyrow].name));

                var flags = PropertyStruct[propertyrow].flags;

                var propertyattribute = GetPropertyAttribute(flags);

                returnstring = returnstring + propertyattribute + propertytypearray[propertyrow] +
                               propertyreturnarray[propertyrow];

                if (returnstring.Length >= 41)

                    returnstring = returnstring + "\r\n" + CreateSpaces(spacesforrest + spacesfornested) + CreateSpaces(7);

                returnstring = returnstring + " " + name + "(";

                var len = returnstring.Length;

                var len1 = returnstring.LastIndexOf("\r\n");

                if (len1 == -1)

                    len1 = -2;

                var dummy = ParamOnMultipleLines(propertyparmarray[propertyrow], len - len1 - 2);

                returnstring = returnstring + dummy + ")";

                returnstring = returnstring + GetPropertyAttributeDefault(flags, propertyrow);

                Console.WriteLine(returnstring);

                Console.WriteLine(CreateSpaces(spacesforrest + spacesfornested) + "{");

                DisplayCustomAttribute("Property", propertyrow, 2 + spacesforrest + spacesfornested);

                for (var kk = 1; kk < MethodSemanticsStruct.Length; kk++)
                {
                    var attributes = GetMethodSemanticsAttributes(MethodSemanticsStruct[kk].methodsemanticsattributes);

                    var table = GetHasSemanticsTable(MethodSemanticsStruct[kk].association);

                    var propertyindex = GetHasSemanticsValue(MethodSemanticsStruct[kk].association);

                    var methodindex = MethodSemanticsStruct[kk].methodindex;

                    var methodattribute = GetMethodAttribute(MethodStruct[methodindex].flags, methodindex);

                    var paramstring = methoddefparamarray1[methodindex];

                    if (propertyindex == propertyrow && table == "Property")
                    {
                        var dummy1 = CreateSpaces(spacesforrest + 2 + spacesfornested);

                        dummy1 = dummy1 + attributes + " /*06" + methodindex.ToString("X6") + "*/ " +
                                 methoddeftypearray[methodindex] + methoddefreturnarray[methodindex];


                        var name1 = NameReserved(GetString(MethodStruct[methodindex].name)) + "(";

                        var dummy2 = dummy1 + typedefnames[typeindex] + "::" + name1;

                        var dummyint = dummy2.IndexOf("(");

                        var dummy3 = ParamOnMultipleLines(paramstring, dummyint + 1);

                        dummy3 = dummy3 + ")" + " /* 06" + (methodindex).ToString("X6") + " */";

                        Console.WriteLine(dummy2 + dummy3);
                    }
                }

                Console.Write(CreateSpaces(spacesforrest + spacesfornested));

                Console.Write("} ");

                Console.WriteLine("// end of property {0}::{1}", NameReserved(GetString(TypeDefStruct[typeindex].name)),
                                  name);
            }
        }

        public string GetHasSemanticsTable(int asscoiationbyte)
        {
            var returnstring = "";

            var tag = asscoiationbyte & 0x01;

            if (tag == 0)

                returnstring = returnstring + "Event";

            if (tag == 1)

                returnstring = returnstring + "Property";

            return returnstring;
        }

        public string GetMethodSemanticsAttributes(short asscoiationbyte)
        {
            var returnstring = "";

            if ((asscoiationbyte & 0x01) == 0x01)

                returnstring = returnstring + ".set";

            if ((asscoiationbyte & 0x02) == 0x02)

                returnstring = returnstring + ".get";

            if ((asscoiationbyte & 0x04) == 0x04)

                returnstring = returnstring + ".other";

            if ((asscoiationbyte & 0x08) == 0x08)

                returnstring = returnstring + ".addon";

            if ((asscoiationbyte & 0x10) == 0x10)

                returnstring = returnstring + ".removeon";

            if ((asscoiationbyte & 0x20) == 0x20)

                returnstring = returnstring + ".fire";

            return returnstring;
        }

        public void CreateMethodRefSignature(byte[] blobarray, int row)
        {
            //Console.WriteLine("CreateMethodRefSignature Name={0} row={1} b.Length={2}" , GetString(MemberRefStruct[row].name), row, blobarray.Length);

            var aa = -1;

            if (row == aa)
            {
                Console.WriteLine("row number {0} {1}", row, GetString(MemberRefStruct[row].name));

                for (var l = 0; l < blobarray.Length; l++)

                    Console.Write("{0} ", blobarray[l].ToString("X"));

                Console.WriteLine();
            }

            int howmanybytes, uncompressedbyte, index;

            index = 0;

            howmanybytes = CorSigUncompressData(blobarray, index, out uncompressedbyte);

            if (uncompressedbyte == 0x06)
            {
                index = index + howmanybytes;

                methodrefreturnarray[row] = GetElementType(index, blobarray, out howmanybytes, 0, "");

                return;
            }

            methodreftypearray[row] = DecodeFirstByteofMethodSignature(uncompressedbyte, row);
            ;

            index = index + howmanybytes;

            howmanybytes = CorSigUncompressData(blobarray, index, out uncompressedbyte);

            count = uncompressedbyte;

            index = index + howmanybytes;

            var typestring = GetElementType(index, blobarray, out howmanybytes, 0, "");

            methodrefreturnarray[row] = typestring;

            index = index + howmanybytes;

            var returnstring = "";

            methodrefparamarray1[row] = "";

            for (var l = 1; l <= count; l++)
            {
                var sentinel = "";

                if (blobarray[index] == 0x41)
                {
                    sentinel = "..." + ",";

                    index = index + 1;
                }

                typestring = sentinel + GetElementType(index, blobarray, out howmanybytes, 0, "");

                index = index + howmanybytes;

                returnstring = returnstring + typestring;

                if (l != count)

                    returnstring = returnstring + ",";
            }

            if (index < blobarray.Length && blobarray[index] == 0x41)

                returnstring = returnstring + ",...";

            methodrefparamarray1[row] = returnstring;
        }

        public void DisplayOverride(int typedefindex)
        {
            if (MethodImpStruct == null)

                return;

            for (var ii = 1; ii < MethodImpStruct.Length; ii++)
            {
                if (typedefindex == MethodImpStruct[ii].classindex)
                {
                    var codedeftablename = GetMethodDefTable(MethodImpStruct[ii].codeddef);

                    var codedefindex = GetMethodDefValue(MethodImpStruct[ii].codeddef);

                    var codebodytablename = GetMethodDefTable(MethodImpStruct[ii].codedbody);

                    var codebodyindex = GetMethodDefValue(MethodImpStruct[ii].codedbody);

                    //Console.WriteLine("...codedeftablename={0} codebodytablename={1} codedefindex={2} codebodyindex={3} ",codedeftablename ,codebodytablename,codedefindex,codebodyindex );

                    if (codebodytablename == "MethodDef")

                        continue;

                    var finals = "";

                    if (codedeftablename == "MethodDef")
                    {
                        finals = CreateSpaces(spacesforrest + spacesfornested);

                        finals = finals + ".override ";

                        var typedefmethodindex = GetTypeForMethod(codedefindex);

                        finals = finals + NameReserved(GetString(TypeDefStruct[typedefmethodindex].name));

                        finals = finals + "/* 02" + typedefmethodindex.ToString("X6") + " */::";

                        finals = finals + NameReserved(GetString(MethodStruct[codedefindex].name)) + " with";
                    }

                    else
                    {
                        finals = CreateSpaces(spacesforrest + spacesfornested);

                        finals = finals + ".override ";

                        var typerefindex = GetTypeRefFromMethodRef(codedefindex);

                        finals = finals + typerefnames[typerefindex] + "::";

                        finals = finals + NameReserved(GetString(MemberRefStruct[codedefindex].name)) + " with";
                    }

                    var typerefindex1 = GetTypeRefFromMethodRef(codebodyindex);

                    finals = finals + " " + methodreftypearray[codebodyindex];

                    finals = finals + methodrefreturnarray[codebodyindex] + " ";

                    finals = finals + DisplayTypeRefExtends(typerefindex1) + "::";

                    finals = finals + NameReserved(GetString(MemberRefStruct[codebodyindex].name)) + "(";

                    var len = finals.Length;

                    var paramstring = ParamOnMultipleLines(methodrefparamarray1[codebodyindex], len);

                    finals = finals + paramstring + ") /* 0A" + codebodyindex.ToString("X6") + " */";

                    Console.WriteLine(finals);
                }
            }
        }

        public void ReadandDisplayVTableFixup()
        {
            //Console.WriteLine("........{0}" , MethodStruct.Length  );

            if (MethodStruct == null)

                return;

            methodvtentryarray = new int[MethodStruct.Length + 1];

            for (var jj = 1; jj <= MethodStruct.Length; jj++)

                methodvtentryarray[jj] = 0;

            if (vtablerva != 0)
            {
                long save;

                var position = ConvertRVA(vtablerva);

                if (position == -1)

                    return;

                mfilestream.Position = position;

                Console.WriteLine("// VTableFixup Directory:");

                var count1 = vtablesize / 8;

                vtfixuparray = new string[count1];

                datavtfixuparray = new string[count1];

                for (var ii = 0; ii < count1; ii++)
                {
                    vtfixuparray[ii] = ".vtfixup ";

                    datavtfixuparray[ii] = ".data ";

                    var fixuprva = mbinaryreader.ReadInt32();

                    Console.WriteLine("//   IMAGE_COR_VTABLEFIXUP[{0}]:", ii);

                    Console.WriteLine("//       RVA:               {0}", fixuprva.ToString("x8"));

                    var count = mbinaryreader.ReadInt16();

                    Console.WriteLine("//       Count:             {0}", count.ToString("x4"));

                    var type = mbinaryreader.ReadInt16();

                    Console.WriteLine("//       Type:              {0}", type.ToString("x4"));

                    save = mfilestream.Position;

                    mfilestream.Position = ConvertRVA(fixuprva);

                    int i1;

                    var val = new long[count];

                    for (i1 = 0; i1 < count; i1++)
                    {
                        if ((type & 0x01) == 0x01)

                            val[i1] = mbinaryreader.ReadInt32();

                        if ((type & 0x02) == 0x02)

                            val[i1] = mbinaryreader.ReadInt64();

                        if ((type & 0x01) == 0x01)

                            Console.WriteLine("//         [{0}]            ({1})", i1.ToString("x4"), val[i1].ToString("X8"));

                        if ((type & 0x02) == 0x02)

                            Console.WriteLine("//         [{0}]            (         {1})", i1.ToString("x4"),
                                              (val[i1] & 0xffffffff).ToString("X"));
                    }

                    mfilestream.Position = save;

                    vtfixuparray[ii] = vtfixuparray[ii] + "[" + (i1).ToString("X") + "] ";

                    if ((type & 0x01) == 0x01)

                        vtfixuparray[ii] = vtfixuparray[ii] + "int32 ";

                    if ((type & 0x02) == 0x02)

                        vtfixuparray[ii] = vtfixuparray[ii] + "int64 ";

                    if ((type & 0x04) == 0x04)

                        vtfixuparray[ii] = vtfixuparray[ii] + "fromunmanaged ";

                    vtfixuparray[ii] = vtfixuparray[ii] + "at D_" + fixuprva.ToString("X8");

                    vtfixuparray[ii] = vtfixuparray[ii] + " //";

                    for (i1 = 0; i1 < count; i1++)
                    {
                        if ((type & 0x01) == 0x01)

                            vtfixuparray[ii] = vtfixuparray[ii] + " " + val[i1].ToString("X8");

                        if ((type & 0x02) == 0x02)

                            vtfixuparray[ii] = vtfixuparray[ii] + " " + val[i1].ToString("X16");
                    }

                    long index = 0;

                    if (val != null)

                        index = val[0] & 0xffffff;

                    methodvtentryarray[ii + 1] = (int)index;

                    /*

                    datavtfixuparray[ii] = datavtfixuparray[ii] + "D_" + fixuprva.ToString("X8") + " = bytearray (\r\n" ;

                    string dummy = "";

                    datavtfixuparray[ii] = datavtfixuparray[ii] + CreateSpaces(17);

                    for ( int jj = 0 ; jj <= 3; jj++)

                    {

                    long value = (val[0] >> jj*8)&0xff;

                    dummy= dummy + value.ToString("X2") ;

                    if ( jj != 3)

                    dummy = dummy + " ";

                    }

                    datavtfixuparray[ii] = datavtfixuparray[ii] + dummy + ") ";

                    */
                }

                Console.WriteLine();
            }
        }

        public void DispalyVtFixup()
        {
            if (vtfixuparray == null)

                return;

            for (var ii = 0; ii < vtfixuparray.Length; ii++)

                Console.WriteLine(vtfixuparray[ii]);
        }

        public string GetVtentryString(int methodrow)
        {
            var returnstring = "";

            var kk = GetVtentryInteger(methodrow);

            if (kk >= 1)

                returnstring = CreateSpaces(spacesforrest + 2) + ".vtentry " + kk + " : 1" + "\r\n";

            return returnstring;
        }

        public int GetVtentryInteger(int methodrow)
        {
            int ii;

            for (ii = 1; ii < methodvtentryarray.Length - 1; ii++)
            {
                if (methodvtentryarray[ii] == methodrow)

                    break;
            }

            if (methodvtentryarray[ii] == 0)

                return 0;

            else

                return ii;
        }


        public string GetArrayType(byte[] blobarray, int index, out int howmanybytes)
        {
            string returnstring;

            var total = 1;

            int uncompressedbyte;

            int rank;

            int numsizes;

            int howmanybytes1;

            returnstring = GetElementType(index + 1, blobarray, out howmanybytes, 0, "");

            total = total + howmanybytes;

            returnstring = returnstring + "[";

            howmanybytes1 = CorSigUncompressData(blobarray, index + total, out uncompressedbyte);

            total = total + howmanybytes1;

            rank = uncompressedbyte;

            howmanybytes1 = CorSigUncompressData(blobarray, index + total, out uncompressedbyte);

            total = total + howmanybytes1;

            numsizes = uncompressedbyte;

            var sizearray = new int[numsizes];

            for (var l = 1; l <= numsizes; l++)
            {
                howmanybytes1 = CorSigUncompressData(blobarray, index + total, out uncompressedbyte);

                total = total + howmanybytes1;

                sizearray[l - 1] = uncompressedbyte;
            }

            howmanybytes1 = CorSigUncompressData(blobarray, index + total, out uncompressedbyte);

            total = total + howmanybytes1;

            var bounds = uncompressedbyte;

            var boundsarray = new int[bounds];

            //Console.WriteLine(".....rank={0} numsizes={1} bounds={2} " , rank, numsizes,bounds);

            if (rank != 0 && bounds == 0 && numsizes == 0)
            {
                for (var i = 1; i < rank; i++)

                    returnstring = returnstring + "^";

                returnstring = returnstring + "]";

                howmanybytes = howmanybytes + rank + 1;

                return returnstring;
            }

            var dots = 0;

            for (var l = 1; l <= bounds; l++)
            {
                howmanybytes1 = CorSigUncompressData(blobarray, index + total, out uncompressedbyte);

                total = total + howmanybytes1;

                var ulSigned = uncompressedbyte & 0x1;

                uncompressedbyte = uncompressedbyte >> 1;

                boundsarray[l - 1] = uncompressedbyte;
            }

            if (numsizes == 0)
            {
                for (var l = 0; l < bounds; l++)
                {
                    returnstring = returnstring + boundsarray[l] + "...";

                    if (l != (bounds - 1))

                        returnstring = returnstring + "^";
                }
            }

            else
            {
                for (var l = 0; l < bounds; l++)
                {
                    if (l < numsizes)
                    {
                        var upper = boundsarray[l] + sizearray[l] - 1;

                        if (boundsarray[l] == 0 && sizearray[l] != 0)

                            returnstring = returnstring + sizearray[l];

                        if (boundsarray[l] == 0 && sizearray[l] == 0)

                            returnstring = returnstring + "0";

                        else if (boundsarray[l] != 0 && sizearray[l] != 0)

                            returnstring = returnstring + boundsarray[l] + "..." + upper;

                        else if (boundsarray[l] != 0 && sizearray[l] == 0)

                            returnstring = returnstring + boundsarray[l] + "...";
                    }

                    else
                    {
                        dots++;

                        returnstring = returnstring + boundsarray[l] + "...";
                    }

                    if (l != bounds - 1)

                        returnstring = returnstring + "^";
                }
            }

            if (numsizes != 0) // method a6
            {
                var leftover = rank - numsizes - dots;

                for (var l = 1; l <= leftover; l++)

                    returnstring = returnstring + "^";
            }

            returnstring = returnstring + "]";

            howmanybytes = total - 1;

            return returnstring;
        }

        public string ParamOnMultipleLines(string paramstring, int spaces)
        {
            if (paramstring == "")

                return "";

            if (paramstring == null)

                return "";

            var returnstring = "";

            if (paramstring.IndexOf(",") == -1)
            {
                paramstring = paramstring.Replace("^", ",");

                return paramstring;
            }

            char[] chararray = { ',' };

            var stringarray = paramstring.Split(chararray);

            returnstring = stringarray[0] + ",";

            for (var ii = 1; ii < stringarray.Length; ii++)
            {
                returnstring = returnstring + "\r\n" + CreateSpaces(spaces) + stringarray[ii];

                if (ii != stringarray.Length - 1)

                    returnstring = returnstring + ",";
            }

            returnstring = returnstring.Replace("^", ",");

            return returnstring;
        }

        public int HowManyMethodAttributes(string methodattribute)
        {
            var count = 0;

            if (methodattribute.IndexOf("hidebysig") != -1)

                count++;

            if (methodattribute.IndexOf("newslot") != -1)

                count++;

            if (methodattribute.IndexOf("specialname") != -1)

                count++;

            if (methodattribute.IndexOf("rtspecialname") != -1)

                count++;

            if (methodattribute.IndexOf("final") != -1)

                count++;

            if (methodattribute.IndexOf("virtual") != -1)

                count++;

            if (methodattribute.IndexOf("abstract") != -1)

                count++;

            return count;
        }

        public void CreateMethodDefSignature(byte[] blobarray, int row)
        {
            //Console.WriteLine("CreateMethodDefSignature Array Length={0} method row={1} name={2}" , blobarray.Length , row , GetString(MethodStruct[row].name));

            int howmanybytes, uncompressedbyte, count, index;

            index = 0;

            howmanybytes = CorSigUncompressData(blobarray, index, out uncompressedbyte);

            methoddeftypearray[row] = DecodeFirstByteofMethodSignature(uncompressedbyte, row);

            index = index + howmanybytes;

            howmanybytes = CorSigUncompressData(blobarray, index, out uncompressedbyte);

            count = uncompressedbyte;

            methoddefparamcount[row] = count;

            index = index + howmanybytes;

            var returntypestring = "";

            returntypestring = GetElementType(index, blobarray, out howmanybytes, row, "Method") + " ";

            returntypestring = returntypestring.Replace("^", ",");

            index = index + howmanybytes;

            methoddefreturnarray[row] = returntypestring;

            var returnstring1 = "";

            var returnstring2 = "";

            var typestring = "";

            for (var l = 1; l <= count; l++)
            {
                typestring = GetElementType(index, blobarray, out howmanybytes, 0, "");

                index = index + howmanybytes;

                returnstring2 = returnstring2 + typestring;

                if (l != count)

                    returnstring2 = returnstring2 + ",";

                var ind = GetParamRowNumber(row, l);

                var paramcalling = GetParamAttrforParamCalling(ind);

                var parammarshal = GetParamAttrforParamMarshal(ind, 1);

                returnstring1 = returnstring1 + paramcalling;

                returnstring1 = returnstring1 + typestring + " ";

                returnstring1 = returnstring1 + parammarshal;

                returnstring1 = returnstring1 + GetParamNameForMethod(row, count, l);

                if (l != count)

                    returnstring1 = returnstring1 + ",";

                methoddefparamarray[row] = returnstring1;

                methoddefparamarray1[row] = returnstring2;
            }
        }

        private int GetParamRowNumber(int row, int l)
        {
            if (MethodStruct == null || ParamStruct == null)

                return 0;

            var start = MethodStruct[row].param;

            var end = 0;


            if (row == (MethodStruct.Length - 1))

                end = ParamStruct.Length;

            else

                end = MethodStruct[row + 1].param;

            end--;

            int i;

            for (i = start; i <= end; i++)
            {
                if (ParamStruct[i].sequence == l)

                    return i;
            }

            return 0;
        }

        public string GetParamAttrforParamMarshal(int paramindex, int tabletype)
        {
            var returnstring = "";

            if (ParamStruct == null)

                return "";

            if (paramindex >= ParamStruct.Length)

                return "";

            int pattr = ParamStruct[paramindex].pattr;

            returnstring = DecodeParamAttributes(pattr, tabletype, paramindex, 0x2000);

            return returnstring;
        }

        public string GetModOptOrModReq(int index, byte[] blobarray, out int bytestaken)
        {
            var returnstring = "";

            bytestaken = 0;

            var whileindex = index;

            if (blobarray[index] == 0x20 || blobarray[index] == 0x1f)
            {
                while (true)
                {
                    int noofbytes;

                    var tokens = GetTokenType(blobarray, whileindex, out noofbytes);

                    if (blobarray[whileindex] == 0x20)

                        tokens = "modopt(" + tokens + ")";

                    if (blobarray[whileindex] == 0x1f)

                        tokens = "modreq(" + tokens + ")";

                    bytestaken = bytestaken + noofbytes + 1;

                    returnstring = tokens + " " + returnstring;

                    whileindex = whileindex + noofbytes + 1;

                    if (!(blobarray[whileindex] == 0x20 || blobarray[whileindex] == 0x1f))

                        break;
                }
            }

            if (returnstring != "")

                returnstring = returnstring.Remove(returnstring.Length - 1, 1);

            return returnstring;
        }

        public string GetElementType(int index, byte[] blobarray, out int howmanybytes, int row, string name)
        {
            howmanybytes = 0;

            var returnstring = "";

            var modoptstring = "";

            int bytestaken;

            modoptstring = GetModOptOrModReq(index, blobarray, out bytestaken);

            index = index + bytestaken;

            var type = blobarray[index];

            if (type >= 0x01 && type <= 0x0e)
            {
                returnstring = GetType(type);

                howmanybytes = 1;
            }

            else if (type == 0x0f)
            {
                returnstring = GetPointerToken(index, blobarray, out howmanybytes);
            }

            else if (type == 0x10)
            {
                returnstring = GetByrefToken(index, blobarray, out howmanybytes);
            }

            else if (type == 0x11 || type == 0x12)
            {
                int howmanybytes2;

                returnstring = GetTokenType(blobarray, index, out howmanybytes2);

                howmanybytes = howmanybytes2 + 1;
            }

            else if (type == 0x13)
            {
                returnstring = "!" + blobarray[index + 1];

                howmanybytes = 2;
            }

            else if (type == 0x14)
            {
                int howmanybytes2;

                returnstring = GetArrayType(blobarray, index, out howmanybytes2);

                howmanybytes = howmanybytes2 + 1;
            }

            else if (type == 0x15 || type == 0x17 || type == 0x1e || type == 0x21)
            {
                returnstring = "/* UNKNOWN TYPE (0x" + type.ToString("X") + ")*/";

                howmanybytes = 1;
            }

            else if (type == 0x16)
            {
                returnstring = "typedref";

                howmanybytes = 1;
            }

            else if (type == 0x18)
            {
                returnstring = "native int";

                howmanybytes = 1;
            }

            else if (type == 0x19)
            {
                returnstring = "native unsigned int";

                howmanybytes = 1;
            }

            else if (type == 0x1a)
            {
                returnstring = "native float";

                howmanybytes = 1;
            }

            else if (type == 0x1c)
            {
                returnstring = "object";

                howmanybytes = 1;
            }

            else if (type == 0x1d)
            {
                returnstring = GetSzArray(index, blobarray, out howmanybytes);
            }

            else if (type == 0x45)
            {
                int howmanybytes2;

                returnstring = GetElementType(index + 1, blobarray, out howmanybytes2, 0, "") + " pinned";

                howmanybytes = howmanybytes2 + 1;
            }

            else if (type == 0x1b)
            {
                int howmanybytes2;

                returnstring = GetPointerToFunctionSignature(index, blobarray, out howmanybytes2, ref modoptstring, row,
                                                             name);

                modoptstring = "";

                howmanybytes = howmanybytes2;
            }

            howmanybytes = howmanybytes + bytestaken;

            if (modoptstring != "")

                returnstring = returnstring + " " + modoptstring;

            return returnstring;
        }

        public string GetPointerToFunctionSignature(int index, byte[] blobarray, out int howmanybytes,
                                                    ref string modoptstring, int row, string name)
        {
            int uncompressedbyte;

            index = index + 1;

            int nobytes;

            var totalbytes = 1;

            var returnstring = "";

            nobytes = CorSigUncompressData(blobarray, index, out uncompressedbyte);

            if (row != 0 && name == "Method")
            {
                methoddeftypearray[row] = DecodeFirstByteofMethodSignature(uncompressedbyte, row);

                methoddeftypearray[row] = "method " + methoddeftypearray[row];
            }

            else

                returnstring = "method " + DecodeFirstByteofMethodSignature(uncompressedbyte, row);

            index = index + nobytes;

            totalbytes = totalbytes + nobytes;

            nobytes = CorSigUncompressData(blobarray, index, out uncompressedbyte);

            index = index + nobytes;

            totalbytes = totalbytes + nobytes;

            var nooftypes = uncompressedbyte;

            int bytestaken1;

            var modoptstring1 = GetModOptOrModReq(index, blobarray, out bytestaken1);

            index = index + bytestaken1;

            totalbytes = totalbytes + bytestaken1;

            returnstring = returnstring + GetElementType(index, blobarray, out nobytes, 0, "");

            index = index + nobytes;

            totalbytes = totalbytes + nobytes;

            if (modoptstring1 != "")

                returnstring = returnstring + " " + modoptstring1;

            returnstring = returnstring + " *(";

            if (nooftypes == 0)

                returnstring = returnstring + ")";

            else

                for (var i = 1; i <= nooftypes; i++)
                {
                    returnstring = returnstring + GetElementType(index, blobarray, out nobytes, 0, "");

                    if (i != nooftypes)

                        returnstring = returnstring + ",";

                    else

                        returnstring = returnstring + ")";

                    index = index + nobytes;

                    totalbytes = totalbytes + nobytes;
                }

            if (modoptstring != "")

                returnstring = returnstring + " " + modoptstring;

            howmanybytes = totalbytes;

            return returnstring;
        }

        public string GetTableRefNameForFillArray(int tablerow, int typerow, string tablename)
        {
            var nameandnamespace = "";

            if (tablename == "AssemblyRef")

                nameandnamespace = NameReserved(GetString(AssemblyRefStruct[tablerow].name));

            if (tablename == "ModuleRef")

                nameandnamespace = ".module " + NameReserved(GetString(ModuleRefStruct[tablerow].name));

            var stringnamespace = NameReserved(GetString(TypeRefStruct[typerow].nspace));

            var stringnested = "";

            if (stringnamespace != "")

                stringnamespace = stringnamespace + ".";

            if (tablename == "AssemblyRef")

                stringnested = "[" + nameandnamespace + "/* 23" + tablerow.ToString("X6") + " */]" + stringnamespace +
                               NameReserved(GetString(TypeRefStruct[typerow].name));

            if (tablename == "ModuleRef")

                stringnested = "[" + nameandnamespace + "/* 1A" + tablerow.ToString("X6") + " */]" + stringnamespace +
                               NameReserved(GetString(TypeRefStruct[typerow].name));

            if (tablename == "Module")

                stringnested = stringnested + stringnamespace + NameReserved(GetString(TypeRefStruct[typerow].name));

            stringnested = stringnested + "/* 01" + typerow.ToString("X6") + " *//";

            return stringnested;
        }

        public string GetTypeRefForFillarray(int k)
        {
            var stringnamespace = NameReserved(GetString(TypeRefStruct[k].nspace));

            if (stringnamespace != "")

                stringnamespace = stringnamespace + ".";

            var stringnested = stringnamespace + NameReserved(GetString(TypeRefStruct[k].name));

            stringnested = stringnested + "/* 01" + k.ToString("X6") + " */";

            return stringnested;
        }

        public void FillArray()
        {
            var old = tableoffset;

            var tablehasrows = tablepresent(8);

            var offs = tableoffset;

            tableoffset = old;

            if (tablehasrows)
            {
                paramnames = new string[rows[8] + 1];

                for (var k = 1; k <= rows[8]; k++)
                {
                    var pattr = BitConverter.ToInt16(metadata, offs);

                    offs += 2;

                    int sequence = BitConverter.ToInt16(metadata, offs);

                    offs += 2;

                    var name = ReadStringIndex(metadata, offs);

                    offs += offsetstring;

                    var dummy = GetString(name);

                    paramnames[k] = NameReserved(dummy);
                }
            }

            old = tableoffset;

            tablehasrows = tablepresent(1);

            offs = tableoffset;

            tableoffset = old;

            if (tablehasrows)
            {
                typerefnames = new string[rows[1] + 1];

                for (var k = 1; k <= rows[1]; k++)
                {
                    var resolutionscope = BitConverter.ToInt16(metadata, offs);

                    offs = offs + 2;

                    var name = ReadStringIndex(metadata, offs);

                    offs = offs + offsetstring;

                    var nspace = ReadStringIndex(metadata, offs);

                    offs = offs + offsetstring;

                    var stringname = NameReserved(GetString(name));

                    var stringtypefminusnested = GetString(nspace);

                    if (stringtypefminusnested.Length != 0)

                        stringtypefminusnested = stringtypefminusnested + ".";

                    stringtypefminusnested = stringtypefminusnested + stringname;

                    var stringnested = "";

                    var resolutioncodedtable = GetResolutionScopeTable(resolutionscope);

                    var resolutionrow = GetResolutionScopeValue(resolutionscope);

                    if (resolutioncodedtable == "Module")
                    {
                        stringtypefminusnested = stringtypefminusnested + "/* 01" + k.ToString("X6") + " */";
                    }

                    if (resolutioncodedtable == "AssemblyRef")
                    {
                        stringnested = "[" + NameReserved(GetString(AssemblyRefStruct[resolutionrow].name)) + "/* 23" +
                                       resolutionrow.ToString("X6") + " */]";

                        stringtypefminusnested = stringtypefminusnested + "/* 01" + k.ToString("X6") + " */";
                    }

                    if (resolutioncodedtable == "ModuleRef")
                    {
                        stringnested = "[.module " + NameReserved(GetString(ModuleRefStruct[resolutionrow].name)) + "/* 1A" +
                                       resolutionrow.ToString("x6") + " */]";

                        stringtypefminusnested = stringtypefminusnested + "/* 01" + k.ToString("X6") + " */";
                    }

                    if (resolutioncodedtable == "TypeRef")
                    {
                        var resolutioncodedtable1 = GetResolutionScopeTable(TypeRefStruct[resolutionrow].resolutionscope);

                        var resolutionrow1 = GetResolutionScopeValue(TypeRefStruct[resolutionrow].resolutionscope);

                        if (resolutioncodedtable1 == "AssemblyRef" || resolutioncodedtable1 == "ModuleRef" ||
                            resolutioncodedtable1 == "Module")
                        {
                            stringnested = GetTableRefNameForFillArray(resolutionrow1, resolutionrow, resolutioncodedtable1);

                            stringnested = stringnested + GetTypeRefForFillarray(k);

                            stringtypefminusnested = "";
                        }

                        else
                        {
                            var tablename = GetResolutionScopeTable(TypeRefStruct[k].resolutionscope);

                            var row = GetResolutionScopeValue(TypeRefStruct[k].resolutionscope);

                            var cnt = 0;

                            while (tablename == "TypeRef")
                            {
                                row = GetResolutionScopeValue(TypeRefStruct[row].resolutionscope);

                                tablename = GetResolutionScopeTable(TypeRefStruct[row].resolutionscope);

                                cnt++;
                            }

                            var i = 0;

                            var typerows = new int[cnt];

                            var tablename1 = GetResolutionScopeTable(TypeRefStruct[k].resolutionscope);

                            var row1 = GetResolutionScopeValue(TypeRefStruct[k].resolutionscope);

                            while (i < cnt)
                            {
                                row1 = GetResolutionScopeValue(TypeRefStruct[row1].resolutionscope);

                                tablename1 = GetResolutionScopeTable(TypeRefStruct[row1].resolutionscope);

                                typerows[i] = row1;

                                i++;
                            }


                            var assemblyrow = GetResolutionScopeValue(TypeRefStruct[row].resolutionscope);

                            var typerow = typerows[typerows.Length - 1];

                            stringnested = GetTableRefNameForFillArray(assemblyrow, typerow, tablename);


                            i = 0;

                            var dummy = "";

                            while (i < cnt - 1)
                            {
                                dummy = GetTypeRefForFillarray(typerows[i]) + "/" + dummy;

                                i++;
                            }

                            stringnested = stringnested + dummy;

                            stringnested = stringnested + GetTypeRefForFillarray(resolutionrow);

                            stringnested = stringnested + "/" + GetTypeRefForFillarray(k);

                            stringtypefminusnested = "";
                        }
                    }

                    typerefnames[k] = stringnested + stringtypefminusnested;

                    //Console.WriteLine(".......{0} {1} {2}" , resolutioncodedtable , typerefnames[k] , k);
                }
            }

            old = tableoffset;

            tablehasrows = tablepresent(2);

            offs = tableoffset;

            tableoffset = old;

            if (tablehasrows)
            {
                typedefnames = new string[rows[2] + 1];

                for (var k = 1; k <= rows[2]; k++)
                {
                    var name = TypeDefStruct[k].name;

                    offs += offsetstring;

                    var nspace = TypeDefStruct[k].nspace;

                    offs += offsetstring;

                    var nestedtypestring = "";

                    nestedtypestring = GetNestedTypeAsString(k);

                    var namestring = GetString(name);

                    var namespacestring = NameReserved(GetString(nspace));

                    if (namespacestring.Length != 0)

                        namespacestring = namespacestring + ".";

                    namestring = NameReserved(namestring);

                    typedefnames[k] = nestedtypestring + namespacestring + namestring + "/* 02" + k.ToString("X6") + " */";
                }
            }
        }

        public string DecodeToken(int token, int type)
        {
            var tabletype = (byte)(token & 0x03);

            var tableindex = token >> 2;

            var returnstring = "";

            //Console.WriteLine(".......tabletype={0} {1} {2}" , tabletype , tableindex , typerefnames.Length);

            if (tabletype == 0)

                returnstring = typedefnames[tableindex];

            if (tabletype == 1)

                returnstring = typerefnames[tableindex];

            return returnstring;
        }

        public string DecodeFirstByteofMethodSignature(int firstbyte, int methodrow)
        {
            var returnstring = "";

            //Console.WriteLine(".....{0}" , firstbyte.ToString("X"));

            if ((firstbyte & 0x20) == 0x20)

                returnstring = "instance ";

            if ((firstbyte & 0x60) == 0x60)

                returnstring = "explicit instance ";

            var firstbits = firstbyte & 0xf;

            if (firstbits == 0x02)

                returnstring = returnstring + "unmanaged stdcall ";

            else if (firstbits == 0x03)

                returnstring = returnstring + "unmanaged thiscall ";

            else if (firstbits == 0x05)

                returnstring = returnstring + "vararg ";

            else if (firstbits == 0x01)

                returnstring = returnstring + "unmanaged cdecl ";

            else if (firstbits == 0x04)

                returnstring = returnstring + "unmanaged fastcall ";

            return returnstring;
        }

        public string DecodeParamAttributes(int pattr, int tabletype, int start, int bytemask)
        {
            var returnstring = "";

            if ((pattr & bytemask) == bytemask)
            {
                int ii;

                for (ii = 1; ii <= FieldMarshalStruct.Length; ii++)
                {
                    var coded = FieldMarshalStruct[ii].coded;

                    var table = FieldMarshalStruct[ii].coded & 0x01;

                    coded = coded >> 1;

                    if (coded == start && tabletype == table)

                        break;
                }

                var blobindex = FieldMarshalStruct[ii].index;

                int length, howmanybytes;

                howmanybytes = CorSigUncompressData(blob, blobindex, out length);

                //Console.WriteLine("{0} {1} {2} {3}" ,blob[blobindex].ToString("X") , blob[blobindex+1].ToString("X"),blob[blobindex+2].ToString("X"),blob[blobindex+3].ToString("X") );

                int blobvalue = blob[blobindex + howmanybytes];

                var ss1 = GetMarshallType(blob[blobindex + howmanybytes], howmanybytes, blobindex);

                if (ss1 == "[]" || ss1.IndexOf("[ + ") != -1 || ss1 == "" ||
                    (ss1.Length >= 2 && ss1[0] == '[' && ss1[ss1.Length - 1] == ']'))

                    returnstring = " marshal(" + ss1;

                else

                    returnstring = " marshal( " + ss1;


                returnstring = returnstring + ")";
            }

            if (returnstring != "")

                returnstring = returnstring + " ";

            return returnstring;
        }

        public string GetMarshallType(byte marshalflags, int howmanybytes, int blobindex)
        {
            //Console.WriteLine("...{0} {1} {2} {3} {4}" ,blob[blobindex] , blob[blobindex+1].ToString("X"), blob[blobindex+2].ToString("X"), blob[blobindex+3].ToString("X") , blob[blobindex+4].ToString("X") );

            //Console.WriteLine(".........{0}" , marshalflags.ToString("X"));

            if (blob[blobindex] == 0)

                return "";

            if (marshalflags == 0x01)

                return "void";

            if (marshalflags == 0x02)

                return "bool";

            if (marshalflags == 0x03)

                return "int8";

            if (marshalflags == 0x04)

                return "unsigned int8";

            if (marshalflags == 0x05)

                return "int16";

            if (marshalflags == 0x06)

                return "unsigned int16";

            if (marshalflags == 0x07)

                return "int32";

            if (marshalflags == 0x08)

                return "unsigned int32";

            if (marshalflags == 0x09)

                return "int64";

            if (marshalflags == 0x0a)

                return "unsigned int64";

            if (marshalflags == 0x0b)

                return "float32";

            if (marshalflags == 0x0c)

                return "float64";

            if (marshalflags == 0x0D)

                return "syschar";

            if (marshalflags == 0x0e)

                return "variant";

            if (marshalflags == 0x0f)

                return "currency";

            if (marshalflags == 0x10)

                return "*";

            if (marshalflags == 0x11)

                return "decimal";

            if (marshalflags == 0x12)

                return "date";

            if (marshalflags == 0x13)

                return "bstr";

            if (marshalflags == 0x14)

                return "lpstr";

            if (marshalflags == 0x15)

                return "lpwstr";

            if (marshalflags == 0x16)

                return "lptstr";

            if (marshalflags == 0x17)
            {
                int uncompressedbyte;

                CorSigUncompressData(blob, blobindex + howmanybytes + 1, out uncompressedbyte);

                return "fixed sysstring [" + uncompressedbyte + "]";
            }

            if (marshalflags == 0x18)

                return "objectref";

            if (marshalflags == 0x19)

                return "iunknown";

            if (marshalflags == 0x1a)

                return "idispatch";

            if (marshalflags == 0x1b)

                return "struct";

            if (marshalflags == 0x1c)

                return "interface";

            if (marshalflags == 0x1d)
            {
                var returnstring = "safearray";

                if (blob[blobindex] > 1)
                {
                    var dummy = GetSafeArrayType(blob[blobindex + howmanybytes + 1]);

                    if (dummy != "")

                        returnstring = returnstring + " " + dummy;
                }

                var len = blob[blobindex] - 3;

                if (len > 0)
                {
                    returnstring = returnstring + ", \"";

                    for (var iii = 0; iii < len; iii++)

                        returnstring = returnstring + (char)blob[blobindex + iii + howmanybytes + 3];

                    returnstring = returnstring + "\"";
                }

                return returnstring;
            }

            if (marshalflags == 0x1e)
            {
                int uncompressedbyte;

                CorSigUncompressData(blob, blobindex + howmanybytes + 1, out uncompressedbyte);

                return "fixed array [" + uncompressedbyte + "]";
            }

            if (marshalflags == 0x1f)

                return "int";

            if (marshalflags == 0x20)

                return "unsigned int";

            if (marshalflags == 0x21)

                return "nested struct";

            if (marshalflags == 0x22)

                return "byvalstr";

            if (marshalflags == 0x23)

                return "ansi bstr";

            if (marshalflags == 0x24)

                return "tbstr";

            if (marshalflags == 0x25)

                return "variant bool";

            if (marshalflags == 0x26)

                return "method";

            if (marshalflags == 0x27)

                return "";

            if (marshalflags == 0x28)

                return "as any";

            if (marshalflags == 0x29)

                return "";

            if (marshalflags == 0x2a)
            {
                //Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}" ,blob[blobindex].ToString("X") , blob[blobindex+1].ToString("X"),blob[blobindex+2].ToString("X"),blob[blobindex+3].ToString("X")  ,blob[blobindex+4].ToString("X"),blob[blobindex+5].ToString("X") ,blob[blobindex+6].ToString("X")  ,blob[blobindex+7].ToString("X")  );

                /*

                for ( int i = 0 ; i <= blob[blobindex] ; i++)

                Console.Write("{0} " , blob[blobindex+i].ToString("X"));

                Console.WriteLine();

                */

                var returnstring = "";

                var arrays = "[]";

                var dummy1 = "";

                if (blob[blobindex] == 3)
                {
                    dummy1 = " ";

                    arrays = "[ + " + blob[blobindex + 2 + howmanybytes] + "]";
                }

                if (blob[blobindex] == 4)
                {
                    dummy1 = "";

                    if (blob[blobindex + 2 + howmanybytes] != 0)

                        arrays = "[" + blob[blobindex + 3 + howmanybytes] + " + " + blob[blobindex + 2 + howmanybytes] + "]";

                    else

                        arrays = "[" + blob[blobindex + 3 + howmanybytes] + "]";
                }

                if (blob[blobindex] >= 7)
                {
                    var howmanytypes = blob[blobindex] / 3;

                    returnstring = GetMarshallType(blob[blobindex + howmanybytes + howmanytypes], howmanybytes, blobindex);

                    if (blob[blobindex + 1 + howmanybytes + howmanytypes] != 0)

                        arrays = "[" + blob[blobindex + 2 + howmanybytes + howmanytypes] + " + " +
                                 blob[blobindex + 1 + howmanybytes + howmanytypes] + "]";

                    else

                        arrays = "[" + blob[blobindex + 2 + howmanybytes + howmanytypes] + "]";

                    returnstring = returnstring + arrays;

                    for (var i = 1; i < howmanytypes; i++)
                    {
                        if (blob[blobindex + howmanybytes + howmanytypes + i * 2 + 2] == 0)

                            returnstring = returnstring + " " +
                                           GetMarshallType(blob[blobindex + howmanybytes + howmanytypes + i * 2 + 1],
                                                           howmanybytes, blobindex);

                        else

                            returnstring = returnstring + " " +
                                           GetMarshallType(blob[blobindex + howmanybytes + howmanytypes + i * 2 + 2],
                                                           howmanybytes, blobindex);
                    }

                    return returnstring;
                }

                if (blob[blobindex + howmanybytes + 1] == 0x50)

                    returnstring = arrays;

                else

                    returnstring = dummy1 + GetMarshallType(blob[blobindex + howmanybytes + 1], howmanybytes, blobindex) +
                                   arrays;

                return returnstring;
            }

            if (marshalflags == 0x2b)

                return "lpstruct";

            if (marshalflags == 0x2c)
            {
                var len = 0;

                var howmanybytes1 = 0;

                howmanybytes1 = CorSigUncompressData(blob, blobindex + howmanybytes + 3, out len);

                var returnstring = "custom (\"";

                for (var ii1 = 0; ii1 < len; ii1++)

                    returnstring = returnstring + (char)blob[blobindex + 3 + ii1 + howmanybytes + howmanybytes1];

                returnstring = returnstring + "\"" + ",";

                var len1 = len;

                var bytes = 1;

                if (len1 >= 128)

                    bytes = 2;

                howmanybytes1 = CorSigUncompressData(blob, blobindex + howmanybytes + 3 + len1 + bytes, out len);

                //Console.WriteLine("..............len={0} len1={1} {2}" , len , len1 , blob[blobindex]);

                returnstring = returnstring + "\"";

                for (var ii1 = 1; ii1 <= len; ii1++)

                    returnstring = returnstring + (char)blob[blobindex + 3 + len1 + ii1 + howmanybytes + howmanybytes1];

                returnstring = returnstring + "\")";

                return returnstring;
            }

            if (marshalflags == 0x2d)

                return "error";

            return "Unknown";
        }

        public string GetSafeArrayType(byte safearraytype)
        {
            var returnstring = "";

            //Console.WriteLine("......{0}" , safearraytype.ToString("X"));

            if (safearraytype == 0)

                returnstring = "";

            if (safearraytype == 1)

                returnstring = "null";

            if (safearraytype == 2)

                returnstring = "int16";

            if (safearraytype == 3)

                returnstring = "int32";

            if (safearraytype == 4)

                returnstring = "float32";

            if (safearraytype == 5)

                returnstring = "float34";

            if (safearraytype == 6)

                returnstring = "currency";

            if (safearraytype == 7)

                returnstring = "date";

            if (safearraytype == 8)

                returnstring = "bstr";

            if (safearraytype == 9)

                returnstring = "idispatch";

            if (safearraytype == 0x0a)

                returnstring = "error";

            if (safearraytype == 0x0b)

                returnstring = "bool";

            if (safearraytype == 0x0c)

                returnstring = "variant";

            if (safearraytype == 0x0d)

                returnstring = "iunknown";

            if (safearraytype == 0x0e)

                returnstring = "decimal";

            if (safearraytype == 0x0f)

                returnstring = "illegal";

            if (safearraytype == 0x10)

                returnstring = "int8";

            if (safearraytype == 0x11)

                returnstring = "unsigned int8";

            if (safearraytype == 0x12)

                returnstring = "unsigned int16";

            if (safearraytype == 0x13)

                returnstring = "unsigned int32";

            if (safearraytype == 0x14)

                returnstring = "int64";

            if (safearraytype == 0x15)

                returnstring = "unsigned int64";

            if (safearraytype == 0x16)

                returnstring = "int";

            if (safearraytype == 0x17)

                returnstring = "unsigned int";

            if (safearraytype == 0x18)

                returnstring = "void";

            if (safearraytype == 0x19)

                returnstring = "hresult";

            if (safearraytype == 0x1a)

                returnstring = "*";

            if (safearraytype == 0x1b)

                returnstring = "safearray";

            if (safearraytype == 0x1c)

                returnstring = "carray";

            if (safearraytype == 0x1d)

                returnstring = "userdefined";

            if (safearraytype == 0x1e)

                returnstring = "lpstr";

            if (safearraytype == 0x1f)

                returnstring = "lpwstr";

            if (safearraytype == 0x20)

                returnstring = "illegal";

            if (safearraytype == 0x21)

                returnstring = "illegal";

            if (safearraytype == 0x22)

                returnstring = "illegal";

            if (safearraytype == 0x23)

                returnstring = "illegal";

            if (safearraytype == 0x24)

                returnstring = "record";

            if (safearraytype >= 0x25)

                returnstring = "illegal";

            return returnstring;
        }

        public string GetParamAttrforMethodMarshal(int methodindex, int seq)
        {
            var returnstring = "";

            if (ParamStruct == null)

                return returnstring;

            int end;

            var start = MethodStruct[methodindex].param;

            if (methodindex == (MethodStruct.Length - 1))

                end = ParamStruct.Length + 1;

            else

                end = MethodStruct[methodindex + 1].param;

            if (start == ParamStruct.Length)

                return returnstring;

            if (start == end)

                return returnstring;

            if (seq == 0 && ParamStruct[start].sequence != 0)

                return "";

            int pattr = ParamStruct[start].pattr;

            returnstring = DecodeParamAttributes(pattr, 1, start, 0x2000);

            if (returnstring != "" && returnstring[0] == 32)

                returnstring = returnstring.Remove(0, 1);

            return returnstring;
        }

        public string GetMethodAttribute(int methodflags, int methodrow)
        {
            var returnstring = "";

            methodaccessattribute = "";

            methodpinvokestring = "";

            if ((methodflags & 0x0006) == 0x0006)

                returnstring = "public ";

            else if ((methodflags & 0x0005) == 0x0005)

                returnstring = "famorassem ";

            else if ((methodflags & 0x0003) == 0x0003)

                returnstring = "assembly ";

            else if ((methodflags & 0x0004) == 0x0004)

                returnstring = "family ";

            else if ((methodflags & 0x0001) == 0x0001)

                returnstring = "private ";

            else if ((methodflags & 0x0002) == 0x0002)

                returnstring = "famandassem ";

            else

                returnstring = "privatescope ";

            methodaccessattribute = returnstring;

            if ((methodflags & 0x0080) == 0x0080)
            {
                returnstring = returnstring + "hidebysig ";
            }

            if ((methodflags & 0x0100) == 0x0100)
            {
                returnstring = returnstring + "newslot ";
            }

            if ((methodflags & 0x0800) == 0x0800 || (methodflags & 0x0200) == 0x0200)
            {
                returnstring = returnstring + "specialname ";
            }

            if ((methodflags & 0x1000) == 0x1000)
            {
                returnstring = returnstring + "rtspecialname ";
            }

            if ((methodflags & 0x0010) == 0x0010)
            {
                returnstring = returnstring + "static ";
            }

            else
            {
                returnstring = returnstring + "instance ";
            }

            if ((methodflags & 0x0020) == 0x0020)
            {
                returnstring = returnstring + "final ";
            }

            if ((methodflags & 0x0040) == 0x0040)
            {
                returnstring = returnstring + "virtual ";
            }

            if ((methodflags & 0x0400) == 0x0400)
            {
                returnstring = returnstring + "abstract ";
            }

            if ((methodflags & 0x2000) == 0x2000)
            {
                returnstring = returnstring + "pinvokeimpl(";

                int ii;

                if (ImplMapStruct == null)
                {
                    returnstring = returnstring + "/* No map */) ";

                    return returnstring;
                }

                else
                {
                    for (ii = 1; ii < ImplMapStruct.Length; ii++)
                    {
                        var index = ImplMapStruct[ii].cindex;

                        index = index >> 1;

                        if (index == methodrow)

                            break;
                    }

                    if (ii == ImplMapStruct.Length)
                    {
                        returnstring = returnstring + "/* No map */) ";

                        return returnstring;
                    }

                    var methodname = NameReserved(GetString(MethodStruct[methodrow].name));

                    var name = NameReserved(GetString(ImplMapStruct[ii].name));

                    var scope = ImplMapStruct[ii].scope;

                    var modulename = NameReserved(GetString(ModuleRefStruct[scope].name));

                    modulename = modulename.Replace("\\", "\\\\");

                    returnstring = returnstring + "\"" + modulename + "\"";

                    if (String.Compare(methodname, name) != 0)

                        returnstring = returnstring + " as \"" + name + "\"";

                    string pinvokeattribute1;

                    var pinvokeattribute = GetPinvokeAttributes(ImplMapStruct[ii].attr, out pinvokeattribute1);

                    returnstring = returnstring + pinvokeattribute1;

                    if (pinvokeattribute.IndexOf("stdcall") == -1)

                        returnstring = returnstring + " " + pinvokeattribute;

                    returnstring = returnstring + ") ";

                    var index1 = returnstring.IndexOf("pinvok");

                    methodpinvokestring = returnstring.Remove(0, index1);
                }
            }

            if ((methodflags & 0x08) == 0x08)
            {
                returnstring = returnstring + "unmanagedexp ";
            }

            if ((methodflags & 0xffff8000) == 0xffff8000)
            {
                returnstring = returnstring + "reqsecobj ";
            }

            return returnstring;
        }

        public string GetPinvokeAttributes(int attribute, out string returnattribute)
        {
            returnattribute = "";

            if ((attribute & 0x001) == 0x0001)

                returnattribute = " nomangle";

            if ((attribute & 0x006) == 0x0006)

                returnattribute = returnattribute + " autochar";

            else if ((attribute & 0x002) == 0x0002)

                returnattribute = returnattribute + " ansi";

            else if ((attribute & 0x004) == 0x0004)

                returnattribute = returnattribute + " unicode";

            if ((attribute & 0x040) == 0x0040)

                returnattribute = returnattribute + " lasterr";

            var returnstring = "";

            if ((attribute & 0x0500) == 0x0500)

                returnstring = returnstring + "fastcall";

            else if ((attribute & 0x0300) == 0x0300)

                returnstring = returnstring + "stdcall";

            else if ((attribute & 0x0100) == 0x0100)

                returnstring = returnstring + "winapi";

            else if ((attribute & 0x0200) == 0x0200)

                returnstring = returnstring + "cdecl";

            else if ((attribute & 0x0400) == 0x0400)

                returnstring = returnstring + "thiscall";

            return returnstring;
        }

        public void DisplaySizeAndPack(int typeindex)
        {
            if (ClassLayoutStruct == null)

                return;

            for (var ii = 1; ii < ClassLayoutStruct.Length; ii++)
            {
                if (ClassLayoutStruct[ii].parent == typeindex)
                {
                    Console.Write(CreateSpaces(spacesfornested + spacesforrest));

                    Console.WriteLine(".pack {0}", ClassLayoutStruct[ii].packingsize);

                    Console.Write(CreateSpaces(spacesfornested + spacesforrest));

                    Console.WriteLine(".size {0}", ClassLayoutStruct[ii].classsize);
                }
            }
        }

        public void DisplayEnd()
        {
            var nspace = NameReserved(GetString(TypeDefStruct[TypeDefStruct.Length - 1].nspace));

            if (!placedend)
            {
                Console.WriteLine();

                Console.WriteLine("// =============================================================");

                Console.WriteLine();

                placedend = true;
            }

            if (nspace == "")

                DisplayCustomAttribute("TypeRef", 0, 0);

            DisplayData();

            Console.WriteLine("//*********** DISASSEMBLY COMPLETE ***********************");

            if (datadirectoryrva[2] != 0)

                Console.WriteLine("// WARNING: Created Win32 resource file a.res");
        }

        public void DisplayOneTypeDefEnd(int typeindex)
        {
            var dummy = "";

            if (IsTypeNested(typeindex))

                dummy = dummy + CreateSpaces(spacesfornested);

            dummy = dummy + CreateSpaces(spacefornamespace);

            dummy = dummy + "} // end of class ";

            var classname = NameReserved(GetString(TypeDefStruct[typeindex].name));

            dummy = dummy + classname;

            Console.WriteLine(dummy);

            var namespacename = NameReserved(GetString(TypeDefStruct[typeindex].nspace));

            Console.WriteLine();

            if (namespacename != "")
            {
                var nspace1 = NameReserved(GetString(TypeDefStruct[typeindex].nspace));

                int ii;

                for (ii = typeindex + 1; ii < TypeDefStruct.Length - 1; ii++)
                {
                    if (IsTypeNested(ii))

                        continue;

                    break;
                }

                var nspace2 = "";

                if (ii != TypeDefStruct.Length)

                    nspace2 = NameReserved(GetString(TypeDefStruct[ii].nspace));

                if (nspace1 != nspace2)
                {
                    if (lasttypedisplayed == typeindex && notprototype)
                    {
                        Console.WriteLine();

                        Console.WriteLine("// =============================================================");

                        Console.WriteLine();

                        placedend = true;

                        DisplayCustomAttribute("TypeRef", 0, 2);
                    }

                    if (lasttypedisplayed == typeindex && notprototype)

                        DisplayFinalCustomAttributes();

                    Console.Write("}");

                    Console.WriteLine(" // end of namespace {0}", namespacename);

                    spacefornamespace = 0;

                    spacesforrest = 2;

                    writenamespace = true;

                    Console.WriteLine();
                }

                else

                    writenamespace = false;
            }
        }


        public int GetTypeForMethod(int methodrow)
        {
            var typedefindex = 0;

            for (typedefindex = 1; typedefindex < TypeDefStruct.Length - 1; typedefindex++)
            {
                var start = TypeDefStruct[typedefindex].mindex;

                var end = TypeDefStruct[typedefindex + 1].mindex - 1;

                if (methodrow >= start && methodrow <= end)

                    return typedefindex;
            }

            return typedefindex;
        }

        public void DisplayTypeDefsAndMethods()
        {
            notprototype = true;

            if (TypeDefStruct.Length != 2)
            {
                Console.WriteLine();

                Console.WriteLine("// =============================================================");

                Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine("// =============== GLOBAL FIELDS AND METHODS ===================");

            Console.WriteLine();

            DisplayGlobalFields();

            DisplayGlobalMethods();

            if (TypeDefStruct.Length != 2)
            {
                Console.WriteLine();

                Console.WriteLine("// =============================================================");

                Console.WriteLine();

                Console.WriteLine();

                Console.WriteLine("// =============== CLASS MEMBERS DECLARATION ===================");

                Console.WriteLine("//   note that class flags, 'extends' and 'implements' clauses");

                Console.WriteLine("//          are provided here for information only");

                Console.WriteLine();

                var kk = TypeDefStruct.Length;

                for (var i = 2; i < kk; i++)
                {
                    if (GetString(TypeDefStruct[i].name) == "_Deleted" && streamnames[0] == "#-")

                        continue;

                    if (!IsTypeNested(i))
                    {
                        DisplayOneType(i);
                    }
                }
            }

            DisplayEnd();
        }

        public void DisplayTypeDefs()
        {
            if (TypeDefStruct.Length != 2)
            {
                Console.WriteLine("//");

                Console.WriteLine("// ============== CLASS STRUCTURE DECLARATION ==================");

                Console.WriteLine("//");

                writenamespace = true;

                for (var i = 2; i < TypeDefStruct.Length; i++)
                {
                    if (GetString(TypeDefStruct[i].name) == "_Deleted" && streamnames[0] == "#-")
                    {
                        continue;
                    }

                    if (!IsTypeNested(i))
                    {
                        DisplayOneTypePrototype(i);
                    }
                }
            }
        }

        public bool IsTypeNested(int typeindex)
        {
            if (NestedClassStruct == null)

                return false;

            for (var ii = 1; ii < NestedClassStruct.Length; ii++)
            {
                if (NestedClassStruct[ii].nestedclass == typeindex)

                    return true;
            }

            return false;
        }

        public void DisplayOneTypePrototype(int typedefindex)
        {
            DisplayOneTypeDefStart(typedefindex);

            DisplayNestedTypesPrototypes(typedefindex);

            DisplayOneTypeDefEnd(typedefindex);
        }

        public void DisplayOneTypeDefStart(int typerow)
        {
            var namespacename = NameReserved(GetString(TypeDefStruct[typerow].nspace));

            if (namespacename != "")
            {
                if (writenamespace)
                {
                    Console.WriteLine(".namespace {0}", namespacename);

                    Console.WriteLine("{");

                    spacefornamespace = 2;

                    spacesforrest = 4;
                }
            }

            var typestring = "";

            if (IsTypeNested(typerow))

                typestring = typestring + CreateSpaces(spacesfornested);

            typestring = typestring + CreateSpaces(spacefornamespace);

            typestring = typestring + ".class /*02" + typerow.ToString("X6") + "*/ ";

            var attributeflags = GetTypeAttributeFlags(TypeDefStruct[typerow].flags, typerow);

            Console.WriteLine("{0}{1}{2}", typestring, attributeflags, NameReserved(GetString(TypeDefStruct[typerow].name)));

            var tablename = GetTypeDefOrRefTable(TypeDefStruct[typerow].cindex);

            var index = GetTypeDefOrRefValue(TypeDefStruct[typerow].cindex);

            var typeextends = "";

            if (tablename == "TypeRef")
            {
                typeextends = DisplayTypeRefExtends(index);
            }

            if (tablename == "TypeDef")
            {
                typeextends = GetNestedTypeAsString(index) + DisplayTypeDefExtends(index);
            }

            if (typeextends.Length != 0)
            {
                typestring = "";

                if (IsTypeNested(typerow))

                    typestring = typestring + CreateSpaces(spacesfornested);

                typestring = typestring + CreateSpaces(spacefornamespace);

                typestring = typestring + "       extends " + typeextends;

                Console.WriteLine(typestring);
            }

            var interfacestring = DisplayAllInterfaces(typerow);

            if (interfacestring.Length != 0)
            {
                typestring = "";

                if (IsTypeNested(typerow))

                    typestring = typestring + CreateSpaces(spacesfornested);

                typestring = typestring + CreateSpaces(spacefornamespace);

                typestring = typestring + "       implements " + interfacestring;

                Console.Write(typestring);
            }

            typestring = "";

            if (IsTypeNested(typerow))

                typestring = typestring + CreateSpaces(spacesfornested);

            typestring = typestring + CreateSpaces(spacefornamespace);

            typestring = typestring + "{";

            Console.WriteLine(typestring);
        }

        public string GetTypeAttributeFlags(int typeattributeflags, int typeindex)
        {
            var returnstring = "";

            var visibiltymask = typeattributeflags & 0x07;

            var visibiltymaskstring = "";

            if (visibiltymask == 0)

                visibiltymaskstring = "private ";

            if (visibiltymask == 1)

                visibiltymaskstring = "public ";

            if (visibiltymask == 2)

                visibiltymaskstring = "nested public ";

            if (visibiltymask == 3)

                visibiltymaskstring = "nested private ";

            if (visibiltymask == 4)

                visibiltymaskstring = "nested family ";

            if (visibiltymask == 5)

                visibiltymaskstring = "nested assembly ";

            if (visibiltymask == 6)

                visibiltymaskstring = "nested famandassem ";

            if (visibiltymask == 7)

                visibiltymaskstring = "nested famorassem ";

            var classlayoutmask = typeattributeflags & 0x18;

            var classlayoutstring = "";

            if (classlayoutmask == 0)

                classlayoutstring = "auto ";

            if (classlayoutmask == 0x08)

                classlayoutstring = "sequential ";

            if (classlayoutmask == 0x10)

                classlayoutstring = "explicit ";

            var interfacestring = "";

            if ((typeattributeflags & 0x20) == 0x20)

                interfacestring = "interface ";

            var abstractstring = "";

            if ((typeattributeflags & 0x80) == 0x80)

                abstractstring = "abstract ";

            var sealedstring = "";

            if ((typeattributeflags & 0x100) == 0x100)

                sealedstring = "sealed ";

            var specialnamestring = "";

            if ((typeattributeflags & 0x400) == 0x400)

                specialnamestring = "specialname ";

            var importstring = "";

            if ((typeattributeflags & 0x1000) == 0x1000)

                importstring = "import ";

            var serializablestring = "";

            if ((typeattributeflags & 0x2000) == 0x2000)

                serializablestring = "serializable ";

            var stringformatmask = typeattributeflags & 0x30000;

            var stringformastring = "";

            if (stringformatmask == 0)

                stringformastring = "ansi ";

            if (stringformatmask == 0x10000)

                stringformastring = "unicode ";

            if (stringformatmask == 0x20000)

                stringformastring = "autochar ";

            var beforefieldinitstring = "";

            if ((typeattributeflags & 0x00100000) == 0x00100000)

                beforefieldinitstring = "beforefieldinit ";

            //string rtspecialnamestring = "";

            //if ( (typeattributeflags & 0x800) == 0x800)

            //rtspecialnamestring = "rtspecialname ";

            if (IsTypeNested(typeindex))

                returnstring = interfacestring + abstractstring + classlayoutstring + stringformastring + serializablestring +
                               sealedstring + importstring + visibiltymaskstring + beforefieldinitstring;

            else

                returnstring = interfacestring + visibiltymaskstring + abstractstring + classlayoutstring +
                               stringformastring + importstring + serializablestring + sealedstring + specialnamestring +
                               beforefieldinitstring;

            return returnstring;
        }

        public string DisplayTypeDefExtends(int typedefindex)
        {
            if (typedefindex == 0)

                return "";

            var name = NameReserved(GetString(TypeDefStruct[typedefindex].name));

            var returnstring = NameReserved(GetString(TypeDefStruct[typedefindex].nspace));

            if (returnstring.Length != 0)

                returnstring = returnstring + ".";

            returnstring = returnstring + name + "/* 02" + typedefindex.ToString("X6") + " */";

            return returnstring;
        }

        public string GetNestedTypeAsString(int rowindex)
        {
            var netsedtypestring = "";

            var namespaceandnameparent2 = "";

            var namespaceandnameparent3 = "";

            if (IsTypeNested(rowindex))
            {
                var rowindexparent = GetParentForNestedType(rowindex);

                if (IsTypeNested(rowindexparent))
                {
                    var rowindexparentparent = GetParentForNestedType(rowindexparent);

                    if (IsTypeNested(rowindexparentparent))
                    {
                        var rowindexp3 = GetParentForNestedType(rowindexparentparent);

                        var nameparent3 = NameReserved(GetString(TypeDefStruct[rowindexp3].name));

                        namespaceandnameparent3 = NameReserved(GetString(TypeDefStruct[rowindexp3].nspace));

                        if (namespaceandnameparent3.Length != 0)

                            namespaceandnameparent3 = namespaceandnameparent3 + ".";

                        namespaceandnameparent3 = namespaceandnameparent3 + nameparent3 + "/* 02" +
                                                  rowindexp3.ToString("X6") + " *//";
                    }

                    var nameparent2 = NameReserved(GetString(TypeDefStruct[rowindexparentparent].name));

                    namespaceandnameparent2 = NameReserved(GetString(TypeDefStruct[rowindexparentparent].nspace));

                    if (namespaceandnameparent2.Length != 0)

                        namespaceandnameparent2 = namespaceandnameparent2 + ".";

                    namespaceandnameparent2 = namespaceandnameparent3 + namespaceandnameparent2 + nameparent2 + "/* 02" +
                                              rowindexparentparent.ToString("X6") + " *//";
                }

                var nameparent1 = NameReserved(GetString(TypeDefStruct[rowindexparent].name));

                netsedtypestring = NameReserved(GetString(TypeDefStruct[rowindexparent].nspace));

                if (netsedtypestring.Length != 0)

                    netsedtypestring = netsedtypestring + ".";

                netsedtypestring = namespaceandnameparent2 + netsedtypestring + nameparent1 + "/* 02" +
                                   rowindexparent.ToString("X6") + " *//";
            }

            return netsedtypestring;
        }

        public int GetParentForNestedType(int typeindex)
        {
            var ii = 0;

            if (NestedClassStruct == null)

                return 0;

            for (ii = 0; ii < NestedClassStruct.Length; ii++)
            {
                if (typeindex == NestedClassStruct[ii].nestedclass)
                {
                    //Console.WriteLine("............{0} {1}" , typeindex , NestedClassStruct[ii].nestedclass);

                    return NestedClassStruct[ii].enclosingclass;
                }
            }

            return 0;
        }

        public string DisplayTypeRefExtends(int typerefindex)
        {
            var returnstring = "";

            var resolutionscope = TypeRefStruct[typerefindex].resolutionscope;

            var resolutionscopetable = GetResolutionScopeTable(resolutionscope);

            var resolutionscopeindex = GetResolutionScopeValue(resolutionscope);

            var dummy = "";

            if (resolutionscopetable == "Module")
            {
            }

            if (resolutionscopetable == "AssemblyRef")
            {
                returnstring = "[" + NameReserved(GetString(AssemblyRefStruct[resolutionscopeindex].name));

                returnstring = returnstring + "/* 23" + resolutionscopeindex.ToString("X6") + " */]";
            }

            if (resolutionscopetable == "ModuleRef")
            {
                returnstring = "[.module " + NameReserved(GetString(ModuleRefStruct[resolutionscopeindex].name));

                returnstring = returnstring + "/* 1A" + resolutionscopeindex.ToString("X6") + " */]";
            }

            if (resolutionscopetable == "TypeRef")
            {
                var resolutionscopeindex1 = GetResolutionScopeValue(TypeRefStruct[resolutionscopeindex].resolutionscope);

                var resolutionscopetable1 = GetResolutionScopeTable(TypeRefStruct[resolutionscopeindex].resolutionscope);

                if (resolutionscopetable1 == "AssemblyRef")
                {
                    dummy = "[" + NameReserved(GetString(AssemblyRefStruct[resolutionscopeindex1].name)) + "/* 23" +
                            resolutionscopeindex1.ToString("X6") + " */]";

                    var nspace1 = NameReserved(GetString(TypeRefStruct[resolutionscopeindex].nspace));

                    if (nspace1 != "")

                        nspace1 = nspace1 + ".";

                    dummy = dummy + nspace1 + NameReserved(GetString(TypeRefStruct[resolutionscopeindex].name)) + "/* 01" +
                            resolutionscopeindex.ToString("X6") + " *//";
                }
            }

            var namespaceindex = TypeRefStruct[typerefindex].nspace;

            var nspace = NameReserved(GetString(namespaceindex));

            returnstring = returnstring + nspace;

            if (nspace.Length != 0)

                returnstring = returnstring + ".";

            var nameindex = TypeRefStruct[typerefindex].name;

            returnstring = dummy + returnstring + NameReserved(GetString(nameindex)) + "/* 01" + typerefindex.ToString("X6") +
                           " */";

            return returnstring;
        }

        public int GetResolutionScopeValue(int rvalue)
        {
            return rvalue >> 2;
        }

        public string GetResolutionScopeTable(int rvalue)
        {
            var returnstring = "";

            var tag = rvalue & 0x03;

            if (tag == 0)

                returnstring = returnstring + "Module";

            if (tag == 1)

                returnstring = returnstring + "ModuleRef";

            if (tag == 2)

                returnstring = returnstring + "AssemblyRef";

            if (tag == 3)

                returnstring = returnstring + "TypeRef";

            return returnstring;
        }

        public string DisplayAllInterfaces(int typeindex)
        {
            var returnstring = "";

            if (InterfaceImplStruct == null)

                return "";

            for (var i = 1; i < InterfaceImplStruct.Length; i++)
            {
                if (typeindex == InterfaceImplStruct[i].classindex)
                {
                    var codedtablename = GetTypeDefOrRefTable(InterfaceImplStruct[i].interfaceindex);

                    var interfaceindex = GetTypeDefOrRefValue(InterfaceImplStruct[i].interfaceindex);

                    var interfacename = "";

                    if (codedtablename == "TypeRef")

                        interfacename = DisplayTypeRefExtends(interfaceindex);

                    if (codedtablename == "TypeDef")

                        interfacename = GetNestedTypeAsString(interfaceindex) + DisplayTypeDefExtends(interfaceindex);

                    returnstring = returnstring + interfacename;

                    bool nextclassindex;

                    if (i == (InterfaceImplStruct.Length - 1))

                        nextclassindex = false;

                    else if (typeindex != InterfaceImplStruct[i + 1].classindex)

                        nextclassindex = false;

                    else

                        nextclassindex = true;

                    if (nextclassindex)

                        returnstring = returnstring + ",\r\n                  " +
                                       CreateSpaces(spacefornamespace + spacesfornested);

                    else

                        returnstring = returnstring + "\r\n";
                }
            }

            return returnstring;
        }


        public static void RunILAssemblyParser(string[] args)
        {
            try
            {
                var a = new PrintAssembly();

                a.Read(args);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void ReadPEStructures(string[] args)
        {
            filename = args[0];

            mfilestream = new FileStream(filename, FileMode.Open);

            mbinaryreader = new BinaryReader(mfilestream);

            mfilestream.Seek(60, SeekOrigin.Begin);

            var startofpeheader = mbinaryreader.ReadInt32();

            mfilestream.Seek(startofpeheader, SeekOrigin.Begin);

            byte sig1, sig2, sig3, sig4;

            sig1 = mbinaryreader.ReadByte();

            sig2 = mbinaryreader.ReadByte();

            sig3 = mbinaryreader.ReadByte();

            sig4 = mbinaryreader.ReadByte();

            //First Structure

            var machine = mbinaryreader.ReadInt16();

            sections = mbinaryreader.ReadInt16();

            var time = mbinaryreader.ReadInt32();

            var pointer = mbinaryreader.ReadInt32();

            var symbols = mbinaryreader.ReadInt32();

            int headersize = mbinaryreader.ReadInt16();

            int characteristics = mbinaryreader.ReadInt16();

            sectionoffset = mfilestream.Position + headersize;

            //Second Structure

            int magic = mbinaryreader.ReadInt16();

            int major = mbinaryreader.ReadByte();

            int minor = mbinaryreader.ReadByte();

            var sizeofcode = mbinaryreader.ReadInt32();

            var sizeofdata = mbinaryreader.ReadInt32();

            var sizeofudata = mbinaryreader.ReadInt32();

            entrypoint = mbinaryreader.ReadInt32();

            var baseofcode = mbinaryreader.ReadInt32();

            var baseofdata = mbinaryreader.ReadInt32();

            ImageBase = mbinaryreader.ReadInt32();

            sectiona = mbinaryreader.ReadInt32();

            filea = mbinaryreader.ReadInt32();

            int majoros = mbinaryreader.ReadInt16();

            int minoros = mbinaryreader.ReadInt16();

            int majorimage = mbinaryreader.ReadInt16();

            int minorimage = mbinaryreader.ReadInt16();

            int majorsubsystem = mbinaryreader.ReadInt16();

            int minorsubsystem = mbinaryreader.ReadInt16();

            var verison = mbinaryreader.ReadInt32();

            var imagesize = mbinaryreader.ReadInt32();

            var sizeofheaders = mbinaryreader.ReadInt32();

            var checksum = mbinaryreader.ReadInt32();

            subsystem = mbinaryreader.ReadInt16();

            int dllflags = mbinaryreader.ReadInt16();

            stackreserve = mbinaryreader.ReadInt32();

            stackcommit = mbinaryreader.ReadInt32();

            var heapreserve = mbinaryreader.ReadInt32();

            var heapcommit = mbinaryreader.ReadInt32();

            var loader = mbinaryreader.ReadInt32();

            datad = mbinaryreader.ReadInt32();

            datadirectoryrva = new int[16];

            datadirectorysize = new int[16];

            for (var i = 0; i <= 15; i++)
            {
                datadirectoryrva[i] = mbinaryreader.ReadInt32();

                datadirectorysize[i] = mbinaryreader.ReadInt32();
            }

            if (datadirectorysize[14] == 0)

                throw new System.Exception("Not a valid CLR file");

            mfilestream.Position = sectionoffset;

            SVirtualAddress = new int[sections];

            SSizeOfRawData = new int[sections];

            SPointerToRawData = new int[sections];

            for (var i = 0; i < sections; i++)
            {
                mbinaryreader.ReadBytes(12);

                SVirtualAddress[i] = mbinaryreader.ReadInt32();

                SSizeOfRawData[i] = mbinaryreader.ReadInt32();

                SPointerToRawData[i] = mbinaryreader.ReadInt32();

                mbinaryreader.ReadBytes(16);
            }
        }

        public void DisplayPEStructures()
        {
            Console.WriteLine();

            Console.WriteLine("//  Microsoft (R) .NET Framework IL Disassembler.  Version 1.0.3328.4");

            Console.WriteLine("//  Copyright (C) Microsoft Corporation 1998-2001. All rights reserved.");

            Console.WriteLine();

            Console.WriteLine("// PE Header:");

            Console.WriteLine("// Subsystem:                      {0}", subsystem.ToString("x8"));

            Console.WriteLine("// Native entry point address:     {0}", entrypoint.ToString("x8"));

            Console.WriteLine("// Image base:                     {0}", ImageBase.ToString("x8"));

            Console.WriteLine("// Section alignment:              {0}", sectiona.ToString("x8"));

            Console.WriteLine("// File alignment:                 {0}", filea.ToString("x8"));

            Console.WriteLine("// Stack reserve size:             {0}", stackreserve.ToString("x8"));

            Console.WriteLine("// Stack commit size:              {0}", stackcommit.ToString("x8"));

            Console.WriteLine("// Directories:                    {0}", datad.ToString("x8"));

            DisplayDataDirectory(datadirectoryrva[0], datadirectorysize[0], "Export Directory");

            DisplayDataDirectory(datadirectoryrva[1], datadirectorysize[1], "Import Directory");

            DisplayDataDirectory(datadirectoryrva[2], datadirectorysize[2], "Resource Directory");

            DisplayDataDirectory(datadirectoryrva[3], datadirectorysize[3], "Exception Directory");

            DisplayDataDirectory(datadirectoryrva[4], datadirectorysize[4], "Security Directory");

            DisplayDataDirectory(datadirectoryrva[5], datadirectorysize[5], "Base Relocation Table");

            DisplayDataDirectory(datadirectoryrva[6], datadirectorysize[6], "Debug Directory");

            DisplayDataDirectory(datadirectoryrva[7], datadirectorysize[7], "Architecture Specific");

            DisplayDataDirectory(datadirectoryrva[8], datadirectorysize[8], "Global Pointer");

            DisplayDataDirectory(datadirectoryrva[9], datadirectorysize[9], "TLS Directory");

            DisplayDataDirectory(datadirectoryrva[10], datadirectorysize[10], "Load Config Directory");

            DisplayDataDirectory(datadirectoryrva[11], datadirectorysize[11], "Bound Import Directory");

            DisplayDataDirectory(datadirectoryrva[12], datadirectorysize[12], "Import Address Table");

            DisplayDataDirectory(datadirectoryrva[13], datadirectorysize[13], "Delay Load IAT");

            DisplayDataDirectory(datadirectoryrva[14], datadirectorysize[14], "CLR Header");

            Console.WriteLine();
        }

        public void DisplayDataDirectory(int rva, int size, string ss)
        {
            var sfinal = "";

            sfinal = String.Format("// {0:x}", rva);

            sfinal = sfinal.PadRight(12);

            sfinal = sfinal + String.Format("[{0:x}", size);

            sfinal = sfinal.PadRight(21);

            sfinal = sfinal + String.Format("] address [size] of {0}:", ss);

            if (ss == "CLR Header")

                sfinal = sfinal.PadRight(67);

            else

                sfinal = sfinal.PadRight(68);

            Console.WriteLine(sfinal);
        }

        public void ReadandDisplayImportAdressTable()
        {
            var stratofimports = ConvertRVA(datadirectoryrva[1]);

            mfilestream.Position = stratofimports;

            Console.WriteLine("// Import Address Table");

            var outercount = 0;

            while (true)
            {
                var rvaimportlookuptable = mbinaryreader.ReadInt32();

                if (rvaimportlookuptable == 0)

                    break;

                var datetimestamp = mbinaryreader.ReadInt32();

                var forwarderchain = mbinaryreader.ReadInt32();

                var name = mbinaryreader.ReadInt32();

                var rvaiat = mbinaryreader.ReadInt32();

                mfilestream.Position = ConvertRVA(name);

                Console.Write("//     ");

                DisplayStringFromFile();

                Console.WriteLine("//              {0} Import Address Table", rvaiat.ToString("x8"));

                Console.WriteLine("//              {0} Import Name Table", name.ToString("x8"));

                Console.WriteLine("//              {0}        time date stamp", datetimestamp);

                Console.WriteLine("//              {0}        Index of first forwarder reference", forwarderchain);

                Console.WriteLine("//");


                var importtable = ConvertRVA(rvaimportlookuptable);

                mfilestream.Position = importtable;

                var nexttable = mbinaryreader.ReadInt32();

                if (nexttable < 0)
                {
                    Console.WriteLine("// Failed to read import data.");

                    Console.WriteLine();

                    outercount++;

                    mfilestream.Position = stratofimports + outercount * 20;

                    continue;
                }


                var innercount = 0;

                while (true)
                {
                    var pos0 = ConvertRVA(rvaimportlookuptable) + innercount * 4;

                    mfilestream.Position = pos0;

                    var pos1 = mbinaryreader.ReadInt32();

                    if (pos1 == 0)

                        break;

                    var pos2 = ConvertRVA(pos1);

                    mfilestream.Position = pos2;

                    var hint = mbinaryreader.ReadInt16();

                    Console.Write("//                  ");

                    if (hint.ToString("X").Length == 1)

                        Console.Write("  {0}", hint.ToString("x"));

                    if (hint.ToString("X").Length == 2)

                        Console.Write(" {0}", hint.ToString("x"));

                    if (hint.ToString("X").Length == 3)

                        Console.Write("{0}", hint.ToString("x"));

                    Console.Write("  ");

                    DisplayStringFromFile();

                    innercount++;
                }

                Console.WriteLine();

                outercount++;

                mfilestream.Position = stratofimports + outercount * 20;
            }

            Console.WriteLine("// Delay Load Import Address Table");

            if (datadirectoryrva[13] == 0)

                Console.WriteLine("// No data.");

            if (datadirectoryrva[13] != 0)

                Console.WriteLine("........................// No data.");
        }

        public void DisplayStringFromFile()
        {
            while (true)
            {
                var filebyte = (byte)mfilestream.ReadByte();

                if (filebyte == 0)

                    break;

                Console.Write("{0}", (char)filebyte);
            }

            Console.WriteLine();
        }

        public void ReadandDisplayCLRHeader()
        {
            Console.WriteLine("// CLR Header:");

            mfilestream.Position = ConvertRVA(datadirectoryrva[14]);

            var size = mbinaryreader.ReadInt32();

            int majorruntimeversion = mbinaryreader.ReadInt16();

            int minorruntimeversion = mbinaryreader.ReadInt16();

            metadatarva = mbinaryreader.ReadInt32();

            var metadatasize = mbinaryreader.ReadInt32();

            corflags = mbinaryreader.ReadInt32();

            entrypointtoken = mbinaryreader.ReadInt32();

            var resourcesrva = mbinaryreader.ReadInt32();

            var resourcessize = mbinaryreader.ReadInt32();

            var strongnamesigrva = mbinaryreader.ReadInt32();

            var strongnamesigsize = mbinaryreader.ReadInt32();

            var codemanagerrva = mbinaryreader.ReadInt32();

            var codemanagersize = mbinaryreader.ReadInt32();

            vtablerva = mbinaryreader.ReadInt32();

            vtablesize = mbinaryreader.ReadInt32();

            exportaddressrva = mbinaryreader.ReadInt32();

            exportaddresssize = mbinaryreader.ReadInt32();

            var managednativeheaderrva = mbinaryreader.ReadInt32();

            var managednativeheadersize = mbinaryreader.ReadInt32();

            if (size >= 100)

                Console.WriteLine("// {0}      Header Size", size);

            else

                Console.WriteLine("// {0}       Header Size", size);

            Console.WriteLine("// {0}        Major Runtime Version", majorruntimeversion);

            Console.WriteLine("// {0}        Minor Runtime Version", minorruntimeversion);

            Console.WriteLine("// {0}        Flags", corflags.ToString("x"));

            var dummy = "// " + entrypointtoken.ToString("x");

            dummy = dummy.PadRight(12) + "Entrypoint Token";

            Console.WriteLine(dummy);

            DisplayDataDirectory(metadatarva, metadatasize, "Metadata Directory");

            DisplayDataDirectory(resourcesrva, resourcessize, "Resources Directory");

            DisplayDataDirectory(strongnamesigrva, strongnamesigsize, "Strong Name Signature");

            DisplayDataDirectory(codemanagerrva, codemanagersize, "CodeManager Table");

            DisplayDataDirectory(vtablerva, vtablesize, "VTableFixups Directory");

            DisplayDataDirectory(exportaddressrva, exportaddresssize, "Export Address Table");

            DisplayDataDirectory(managednativeheaderrva, managednativeheadersize, "Precompile Header");

            Console.WriteLine("// Code Manager Table:");

            if (codemanagerrva == 0)

                Console.WriteLine("//  default");
        }

        public void ReadStreamsData()
        {
            startofmetadata = ConvertRVA(metadatarva);

            if (debug)

                Console.WriteLine("Start of Metadata {0} rva={1}", metadatarva, startofmetadata);

            mfilestream.Position = startofmetadata;

            mfilestream.Seek(4 + 2 + 2 + 4, SeekOrigin.Current);

            var lengthofstring = mbinaryreader.ReadInt32();

            if (debug)

                Console.WriteLine("Length of String {0}", lengthofstring);

            mfilestream.Seek(lengthofstring, SeekOrigin.Current);

            var padding = mfilestream.Position % 4;

            if (debug)

                Console.WriteLine("Padding {0}", padding);

            mfilestream.Seek(2, SeekOrigin.Current);

            int streams = mbinaryreader.ReadInt16();

            if (debug)

                Console.WriteLine("No of streams {0} Position={1}", streams, mfilestream.Position);

            streamnames = new string[5];

            offset = new int[5];

            ssize = new int[5];

            names = new byte[5][];

            names[0] = new byte[10];

            names[1] = new byte[10];

            names[2] = new byte[10];

            names[3] = new byte[10];

            names[4] = new byte[10];

            int j;

            for (var i = 0; i < streams; i++)
            {
                if (debug)

                    Console.WriteLine("At Start Position={0} {1}", mfilestream.Position, mfilestream.Position % 4);

                offset[i] = mbinaryreader.ReadInt32();

                ssize[i] = mbinaryreader.ReadInt32();

                if (debug)

                    Console.WriteLine("offset={0} size={1} Position={2}", offset[i], ssize[i], mfilestream.Position);

                j = 0;

                byte bb;

                while (true)
                {
                    bb = mbinaryreader.ReadByte();

                    if (bb == 0)

                        break;

                    names[i][j] = bb;

                    j++;
                }

                names[i][j] = bb;

                streamnames[i] = GetStreamNames(names[i]);

                while (true)
                {
                    if (mfilestream.Position % 4 == 0)

                        break;

                    var b = mbinaryreader.ReadByte();
                }

                if (debug)

                    Console.WriteLine("At End Position={0} {1}", mfilestream.Position, mfilestream.Position % 4);
            }

            for (var i = 0; i < streams; i++)
            {
                if (streamnames[i] == "#~" || streamnames[i] == "#-")
                {
                    metadata = new byte[ssize[i]];

                    mfilestream.Seek(startofmetadata + offset[i], SeekOrigin.Begin);

                    for (var k = 0; k < ssize[i]; k++)

                        metadata[k] = mbinaryreader.ReadByte();
                }

                if (streamnames[i] == "#Strings")
                {
                    strings = new byte[ssize[i]];

                    mfilestream.Seek(startofmetadata + offset[i], SeekOrigin.Begin);

                    for (var k = 0; k < ssize[i]; k++)

                        strings[k] = mbinaryreader.ReadByte();
                }

                if (streamnames[i] == "#US")
                {
                    us = new byte[ssize[i]];

                    mfilestream.Seek(startofmetadata + offset[i], SeekOrigin.Begin);

                    for (var k = 0; k < ssize[i]; k++)

                        us[k] = mbinaryreader.ReadByte();
                }

                if (streamnames[i] == "#GUID")
                {
                    guid = new byte[ssize[i]];

                    mfilestream.Seek(startofmetadata + offset[i], SeekOrigin.Begin);

                    for (var k = 0; k < ssize[i]; k++)

                        guid[k] = mbinaryreader.ReadByte();
                }

                if (streamnames[i] == "#Blob")
                {
                    blob = new byte[ssize[i]];

                    mfilestream.Seek(startofmetadata + offset[i], SeekOrigin.Begin);

                    for (var k = 0; k < ssize[i]; k++)

                        blob[k] = mbinaryreader.ReadByte();
                }
            }

            if (debug)
            {
                for (var i = 0; i < streams; i++)
                {
                    Console.WriteLine("{0} offset {1} size {2}", streamnames[i], offset[i], ssize[i]);

                    if (streamnames[i] == "#~" || streamnames[i] == "#-")
                    {
                        for (var ii = 0; ii <= 9; ii++)

                            Console.Write("{0} ", metadata[ii].ToString("X"));

                        Console.WriteLine();
                    }

                    if (streamnames[i] == "#Strings")
                    {
                        for (var ii = 0; ii <= 9; ii++)

                            Console.Write("{0} ", strings[ii].ToString("X"));

                        Console.WriteLine();
                    }

                    if (streamnames[i] == "#US")
                    {
                        for (var ii = 0; ii <= 9; ii++)

                            Console.Write("{0} ", us[ii].ToString("X"));

                        Console.WriteLine();
                    }

                    if (streamnames[i] == "#GUID")
                    {
                        for (var ii = 0; ii <= 9; ii++)

                            Console.Write("{0} ", guid[ii].ToString("X"));

                        Console.WriteLine();
                    }

                    if (streamnames[i] == "#Blob")
                    {
                        for (var ii = 0; ii <= 9; ii++)

                            Console.Write("{0} ", blob[ii].ToString("X"));

                        Console.WriteLine();
                    }
                }
            }

            int heapsizes = metadata[6];

            if ((heapsizes & 0x01) == 0x01)

                offsetstring = 4;

            if ((heapsizes & 0x02) == 0x02)

                offsetguid = 4;

            if ((heapsizes & 0x04) == 0x04)

                offsetblob = 4;

            valid = BitConverter.ToInt64(metadata, 8);

            tableoffset = 24;

            rows = new int[64];

            Array.Clear(rows, 0, rows.Length);

            for (var k = 0; k <= 63; k++)
            {
                var tablepresent = (int)(valid >> k) & 1;

                if (tablepresent == 1)
                {
                    rows[k] = BitConverter.ToInt32(metadata, tableoffset);

                    tableoffset += 4;
                }
            }

            if (debug)
            {
                for (var k = 62; k >= 0; k--)
                {
                    var tablepresent = (int)(valid >> k) & 1;

                    if (tablepresent == 1)
                    {
                        Console.WriteLine("{0} {1}", tablenames[k], rows[k]);
                    }
                }
            }
        }

        public string GetStreamNames(byte[] b)
        {
            var i = 0;

            while (b[i] != 0)
            {
                i++;
            }

            var e = System.Text.Encoding.UTF8;

            var dummy = e.GetString(b, 0, i);

            return dummy;
        }

        public void FillTableSizes()
        {
            var modulesize = 2 + offsetstring + offsetguid + offsetguid + offsetguid;

            var typerefsize = GetCodedIndexSize("ResolutionScope") + offsetstring + offsetstring;

            var typedefsize = 4 + offsetstring + offsetstring + GetCodedIndexSize("TypeDefOrRef") + GetTableSize("Method") +
                              GetTableSize("Field");

            var fieldsize = 2 + offsetstring + offsetblob;

            var methodsize = 4 + 2 + 2 + offsetstring + offsetblob + GetTableSize("Param");

            var paramsize = 2 + 2 + offsetstring;

            var interfaceimplsize = GetTableSize("TypeDef") + GetCodedIndexSize("TypeDefOrRef");

            var memberrefsize = GetCodedIndexSize("MemberRefParent") + offsetstring + offsetblob;

            var constantsize = 2 + GetCodedIndexSize("HasConst") + offsetblob;

            var customattributesize = GetCodedIndexSize("HasCustomAttribute") + GetCodedIndexSize("HasCustomAttributeType") +
                                      offsetblob;

            var fieldmarshallsize = GetCodedIndexSize("HasFieldMarshal") + offsetblob;

            var declsecuritysize = 2 + GetCodedIndexSize("HasDeclSecurity") + offsetblob;

            var classlayoutsize = 2 + 4 + GetTableSize("TypeDef");

            var fieldlayoutsize = 4 + GetTableSize("Field");

            var stanalonssigsize = offsetblob;

            var eventmapsize = GetTableSize("TypeDef") + GetTableSize("Event");

            var eventsize = 2 + offsetstring + GetCodedIndexSize("TypeDefOrRef");

            var propertymapsize = GetTableSize("Properties") + GetTableSize("TypeDef");

            var propertysize = 2 + offsetstring + offsetblob;

            var methodsemantics = 2 + GetTableSize("Method") + GetCodedIndexSize("HasSemantics");

            var methodimplsize = GetTableSize("TypeDef") + GetCodedIndexSize("MethodDefOrRef") +
                                 GetCodedIndexSize("MethodDefOrRef");

            var modulerefsize = offsetstring;

            var typespecsize = offsetblob;

            var implmapsize = 2 + GetCodedIndexSize("MemberForwarded") + offsetstring + GetTableSize("ModuleRef");

            var fieldrvasize = 4 + GetTableSize("Field");

            var assemblysize = 4 + 2 + 2 + 2 + 2 + 4 + offsetblob + offsetstring + offsetstring;

            var assemblyrefsize = 2 + 2 + 2 + 2 + 4 + offsetblob + offsetstring + offsetstring + offsetblob;

            var filesize = 4 + offsetstring + offsetblob;

            var exportedtype = 4 + 4 + offsetstring + offsetstring + GetCodedIndexSize("Implementation");

            var manifestresourcesize = 4 + 4 + offsetstring + GetCodedIndexSize("Implementation");

            var nestedclasssize = GetTableSize("TypeDef") + GetTableSize("TypeDef");

            sizes = new[]
                    {
                        modulesize, typerefsize, typedefsize, 2, fieldsize, 2, methodsize, 2, paramsize, interfaceimplsize,
                        memberrefsize, constantsize, customattributesize, fieldmarshallsize, declsecuritysize,
                        classlayoutsize, fieldlayoutsize, stanalonssigsize, eventmapsize, 2, eventsize, propertymapsize, 2,
                        propertysize, methodsemantics, methodimplsize, modulerefsize, typespecsize, implmapsize,
                        fieldrvasize, 2, 2, assemblysize, 4, 12, assemblyrefsize, 6, 14, filesize, exportedtype,
                        manifestresourcesize, nestedclasssize
                    };
        }

        public int GetCodedIndexSize(string nameoftable)
        {
            if (nameoftable == "Implementation")
            {
                if (rows[0x26] >= 16384 || rows[0x23] >= 16384 || rows[0x27] >= 16384)

                    return 4;

                else

                    return 2;
            }

            else if (nameoftable == "MemberForwarded")
            {
                if (rows[0x04] >= 32768 || rows[0x06] >= 32768)

                    return 4;

                else

                    return 2;
            }

            else if (nameoftable == "MethodDefOrRef")
            {
                if (rows[0x06] >= 32768 || rows[0x0A] >= 32768)

                    return 4;

                else

                    return 2;
            }

            else if (nameoftable == "HasSemantics")
            {
                if (rows[0x14] >= 32768 || rows[0x17] >= 32768)

                    return 4;

                else

                    return 2;
            }

            else if (nameoftable == "HasDeclSecurity")
            {
                if (rows[0x02] >= 16384 || rows[0x06] >= 16384 || rows[0x20] >= 16384)

                    return 4;

                else

                    return 2;
            }

            else if (nameoftable == "HasFieldMarshal")
            {
                if (rows[0x04] >= 32768 || rows[0x08] >= 32768)

                    return 4;

                else

                    return 2;
            }

            else if (nameoftable == "TypeDefOrRef")
            {
                if (rows[0x02] >= 16384 || rows[0x01] >= 16384 || rows[0x1B] >= 16384)

                    return 4;

                else

                    return 2;
            }

            else if (nameoftable == "ResolutionScope")
            {
                if (rows[0x00] >= 16384 || rows[0x1a] >= 16384 || rows[0x23] >= 16384 || rows[0x01] >= 16384)

                    return 4;

                else

                    return 2;
            }

            else if (nameoftable == "HasConst")
            {
                if (rows[4] >= 16384 || rows[8] >= 16384 || rows[0x17] >= 16384)

                    return 4;

                else

                    return 2;
            }

            else if (nameoftable == "MemberRefParent")
            {
                if (rows[0x08] >= 8192 || rows[0x04] >= 8192 || rows[0x17] >= 8192)

                    return 4;

                else

                    return 2;
            }

            else if (nameoftable == "HasCustomAttribute")
            {
                if (rows[0x06] >= 2048 || rows[0x04] >= 2048 || rows[0x01] >= 2048 || rows[0x02] >= 2048 ||
                    rows[0x08] >= 2048 || rows[0x09] >= 2048 || rows[0x0a] >= 2048 || rows[0x00] >= 2048 ||
                    rows[0x0e] >= 2048 || rows[0x17] >= 2048 || rows[0x14] >= 2048 || rows[0x11] >= 2048 ||
                    rows[0x1a] >= 2048 || rows[0x1b] >= 2048 || rows[0x20] >= 2048 || rows[0x23] >= 2048 ||
                    rows[0x26] >= 2048 || rows[0x27] >= 2048 || rows[0x28] >= 2048)

                    return 4;

                else

                    return 2;
            }

            else if (nameoftable == "HasCustomAttributeType")
            {
                if (rows[2] >= 8192 || rows[1] >= 8192 || rows[6] >= 8192 || rows[0x0a] >= 8192)

                    return 4;

                else

                    return 2;
            }

            else

                return 2;
        }

        public int ReadCodedIndex(byte[] metadataarray, int offset, string nameoftable)
        {
            var returnindex = 0;

            var codedindexsize = GetCodedIndexSize(nameoftable);

            if (codedindexsize == 2)

                returnindex = BitConverter.ToUInt16(metadataarray, offset);

            if (codedindexsize == 4)

                returnindex = (int)BitConverter.ToUInt32(metadataarray, offset);

            return returnindex;
        }

        public void ReadTablesIntoStructures()
        {
            if (rows[5] > 0)

                Console.WriteLine("........");


            //Module

            var old = tableoffset;

            var tablehasrows = tablepresent(0);

            var offs = tableoffset;

            if (debug)

                Console.WriteLine("Module Table Offset {0} Size {1}", offs, sizes[0]);

            tableoffset = old;

            if (tablehasrows)
            {
                ModuleStruct = new ModuleTable[rows[0] + 1];

                for (var k = 1; k <= rows[0]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    ModuleStruct[k].Generation = BitConverter.ToUInt16(metadata, offs);

                    offs += 2;

                    ModuleStruct[k].Name = ReadStringIndex(metadata, offs);

                    offs += offsetstring;

                    ModuleStruct[k].Mvid = ReadGuidIndex(metadata, offs);

                    offs += offsetguid;

                    ModuleStruct[k].EncId = ReadGuidIndex(metadata, offs);

                    offs += offsetguid;

                    ModuleStruct[k].EncBaseId = ReadGuidIndex(metadata, offs);

                    offs += offsetguid;
                }
            }

            //TypeRef

            old = tableoffset;

            tablehasrows = tablepresent(1);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("TypeRef Table Offset {0} Size {1}", offs, sizes[1]);

            tableoffset = old;

            if (tablehasrows)
            {
                //if ( debug )

                //Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}" , metadata[offs].ToString("X") , metadata[offs+1].ToString("X") , metadata[offs+2].ToString("X") ,metadata[offs+3].ToString("X") ,metadata[offs+4].ToString("X") ,metadata[offs+5].ToString("X") , metadata[offs+6].ToString("X") , metadata[offs+7].ToString("X") , metadata[offs+8].ToString("X")  );

                TypeRefStruct = new TypeRefTable[rows[1] + 1];

                for (var k = 1; k <= rows[1]; k++)
                {
                    //if ( debug )

                    //Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}" , metadata[offs].ToString("X") , metadata[offs+1].ToString("X") , metadata[offs+2].ToString("X") ,metadata[offs+3].ToString("X") ,metadata[offs+4].ToString("X") ,metadata[offs+5].ToString("X") , metadata[offs+6].ToString("X") , metadata[offs+7].ToString("X") , metadata[offs+8].ToString("X")  );

                    TypeRefStruct[k].resolutionscope = ReadCodedIndex(metadata, offs, "ResolutionScope");

                    offs = offs + GetCodedIndexSize("ResolutionScope");

                    TypeRefStruct[k].name = ReadStringIndex(metadata, offs);

                    offs = offs + offsetstring;

                    TypeRefStruct[k].nspace = ReadStringIndex(metadata, offs);

                    offs = offs + offsetstring;

                    //Console.WriteLine("......TypeRef {0}" , GetString(TypeRefStruct[k].name));
                }
            }

            //TypeDef

            old = tableoffset;

            tablehasrows = tablepresent(2);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("TypeDef Table Offset {0} Size {1}", offs, sizes[2]);

            tableoffset = old;

            if (tablehasrows)
            {
                TypeDefStruct = new TypeDefTable[rows[2] + 1];

                for (var k = 1; k <= rows[2]; k++)
                {
                    //if ( debug )

                    //Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}" , metadata[offs].ToString("X") , metadata[offs+1].ToString("X") , metadata[offs+2].ToString("X") ,metadata[offs+3].ToString("X") ,metadata[offs+4].ToString("X") ,metadata[offs+5].ToString("X") , metadata[offs+6].ToString("X") , metadata[offs+7].ToString("X") , metadata[offs+8].ToString("X") , metadata[offs+9].ToString("X") , metadata[offs+10].ToString("X")  );

                    TypeDefStruct[k].flags = BitConverter.ToInt32(metadata, offs);

                    offs += 4;

                    TypeDefStruct[k].name = ReadStringIndex(metadata, offs);

                    offs += offsetstring;

                    TypeDefStruct[k].nspace = ReadStringIndex(metadata, offs);

                    offs += offsetstring;

                    TypeDefStruct[k].cindex = ReadCodedIndex(metadata, offs, "TypeDefOrRef");

                    offs += GetCodedIndexSize("TypeDefOrRef");

                    TypeDefStruct[k].findex = ReadTableIndex(metadata, offs, "Field");

                    offs += GetTableSize("Field");

                    TypeDefStruct[k].mindex = ReadTableIndex(metadata, offs, "Method");

                    offs += GetTableSize("Method");

                    //Console.WriteLine("......TypeDef {0}" , GetString(TypeDefStruct[k].name));
                }
            }

            //FieldPtr

            old = tableoffset;

            tablehasrows = tablepresent(3);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("FieldPtr Table Offset {0} Size {1}", offs, sizes[3]);

            tableoffset = old;

            if (tablehasrows)
            {
                FieldPtrStruct = new FieldPtrTable[rows[3] + 1];

                for (var k = 1; k <= rows[3]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    FieldPtrStruct[k].index = BitConverter.ToInt16(metadata, offs);

                    offs += 2;
                }
            }

            //Field

            old = tableoffset;

            tablehasrows = tablepresent(4);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("Field Table Offset {0} Size {1}", offs, sizes[4]);

            tableoffset = old;

            if (tablehasrows)
            {
                FieldStruct = new FieldTable[rows[4] + 1];

                for (var k = 1; k <= rows[4]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    FieldStruct[k].flags = BitConverter.ToInt16(metadata, offs);

                    offs += 2;

                    FieldStruct[k].name = ReadStringIndex(metadata, offs);

                    offs += offsetstring;

                    FieldStruct[k].sig = ReadBlobIndex(metadata, offs);

                    offs += offsetblob;
                }
            }

            //MethodPtr

            old = tableoffset;

            tablehasrows = tablepresent(5);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("Method Table Offset {0} Size {1}", offs, sizes[5]);

            tableoffset = old;

            if (tablehasrows)
            {
                MethodPtrStruct = new MethodPtrTable[rows[5] + 1];

                for (var k = 1; k <= rows[5]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    MethodPtrStruct[k].index = BitConverter.ToInt16(metadata, offs);

                    offs += 2;
                }
            }

            //Method

            old = tableoffset;

            tablehasrows = tablepresent(6);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("Method Table Offset {0} Size {1}", offs, sizes[6]);

            tableoffset = old;

            if (tablehasrows)
            {
                MethodStruct = new MethodTable[rows[6] + 1];

                for (var k = 1; k <= rows[6]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    MethodStruct[k].rva = BitConverter.ToInt32(metadata, offs);

                    offs += 4;

                    MethodStruct[k].impflags = BitConverter.ToInt16(metadata, offs);

                    offs += 2;

                    MethodStruct[k].flags = BitConverter.ToInt16(metadata, offs);

                    offs += 2;

                    MethodStruct[k].name = ReadStringIndex(metadata, offs);

                    offs += offsetstring;

                    MethodStruct[k].signature = ReadBlobIndex(metadata, offs);

                    offs += offsetblob;

                    MethodStruct[k].param = ReadTableIndex(metadata, offs, "Param");

                    offs += GetTableSize("Param");

                    //Console.WriteLine("Method name={0} ParmNo={1}" , GetString(MethodStruct[k].name),MethodStruct[k].param);
                }
            }

            //Param

            old = tableoffset;

            tablehasrows = tablepresent(8);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("Param Table Offset {0} Size {1}", offs, sizes[8]);

            tableoffset = old;

            if (tablehasrows)
            {
                ParamStruct = new ParamTable[rows[8] + 1];

                for (var k = 1; k <= rows[8]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    ParamStruct[k].pattr = BitConverter.ToInt16(metadata, offs);

                    offs += 2;

                    ParamStruct[k].sequence = BitConverter.ToInt16(metadata, offs);

                    offs += 2;

                    ParamStruct[k].name = ReadStringIndex(metadata, offs);

                    offs += offsetstring;

                    //Console.WriteLine("Param {0} name={2} seq={1} attr={3}" ,k, ParamStruct[k].sequence , GetString(ParamStruct[k].name) , ParamStruct[k].pattr);
                }
            }

            //InterfaceImpl

            old = tableoffset;

            tablehasrows = tablepresent(9);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("InterfaceImpl Table Offset {0} Size {1}", offs, sizes[9]);

            tableoffset = old;

            if (tablehasrows)
            {
                InterfaceImplStruct = new InterfaceImplTable[rows[9] + 1];

                for (var k = 1; k <= rows[9]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    InterfaceImplStruct[k].classindex = ReadCodedIndex(metadata, offs, "TypeDefOrRef");

                    offs += GetCodedIndexSize("TypeDefOrRef");

                    InterfaceImplStruct[k].interfaceindex = ReadTableIndex(metadata, offs, "TypeDef");

                    offs += GetTableSize("TypeDef");
                }
            }

            //MemberRef

            old = tableoffset;

            tablehasrows = tablepresent(10);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("MemberRef Table Offset {0} Size {1}", offs, sizes[10]);

            tableoffset = old;

            if (tablehasrows)
            {
                MemberRefStruct = new MemberRefTable[rows[10] + 1];

                for (var k = 1; k <= rows[10]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    MemberRefStruct[k].clas = ReadCodedIndex(metadata, offs, "MemberRefParent");

                    offs += GetCodedIndexSize("MemberRefParent");

                    MemberRefStruct[k].name = ReadStringIndex(metadata, offs);

                    offs += offsetstring;

                    MemberRefStruct[k].sig = ReadBlobIndex(metadata, offs);

                    offs += offsetblob;
                }
            }

            //Constants

            old = tableoffset;

            tablehasrows = tablepresent(11);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("Constant Table Offset {0} Size {1}", offs, sizes[11]);

            tableoffset = old;

            if (tablehasrows)
            {
                ConstantsStruct = new ConstantsTable[rows[11] + 1];

                for (var k = 1; k <= rows[11]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    ConstantsStruct[k].dtype = metadata[offs];

                    offs += 2;

                    ConstantsStruct[k].parent = ReadCodedIndex(metadata, offs, "HasConst");

                    offs += GetCodedIndexSize("HasConst");

                    ConstantsStruct[k].value = ReadBlobIndex(metadata, offs);

                    offs += offsetblob;
                }
            }

            //CustomAttribute

            old = tableoffset;

            tablehasrows = tablepresent(12);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("CustomAttribute Table Offset {0} Size {1}", offs, sizes[12]);

            tableoffset = old;

            if (tablehasrows)
            {
                CustomAttributeStruct = new CustomAttributeTable[rows[12] + 1];

                for (var k = 1; k <= rows[12]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    CustomAttributeStruct[k].parent = ReadCodedIndex(metadata, offs, "HasCustomAttribute");

                    offs += GetCodedIndexSize("HasCustomAttribute");

                    CustomAttributeStruct[k].type = ReadCodedIndex(metadata, offs, "HasCustomAttributeType");

                    offs += GetCodedIndexSize("HasCustomAttributeType");

                    CustomAttributeStruct[k].value = ReadBlobIndex(metadata, offs);

                    offs += offsetblob;
                }
            }

            //FieldMarshal

            old = tableoffset;

            tablehasrows = tablepresent(13);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("FieldMarshal Table Offset {0} Size {1}", offs, sizes[13]);

            tableoffset = old;

            if (tablehasrows)
            {
                FieldMarshalStruct = new FieldMarshalTable[rows[13] + 1];

                for (var k = 1; k <= rows[13]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    FieldMarshalStruct[k].coded = ReadCodedIndex(metadata, offs, "HasFieldMarshal");

                    offs += GetCodedIndexSize("HasFieldMarshal");

                    FieldMarshalStruct[k].index = ReadBlobIndex(metadata, offs);

                    offs += offsetblob;
                }
            }

            //DeclSecurity

            old = tableoffset;

            tablehasrows = tablepresent(14);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("DeclSecurity Table Offset {0} Size {1}", offs, sizes[14]);

            tableoffset = old;

            if (tablehasrows)
            {
                DeclSecurityStruct = new DeclSecurityTable[rows[14] + 1];

                for (var k = 1; k <= rows[14]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    DeclSecurityStruct[k].action = BitConverter.ToInt16(metadata, offs);

                    offs += 2;

                    DeclSecurityStruct[k].coded = ReadCodedIndex(metadata, offs, "HasDeclSecurity");

                    offs += GetCodedIndexSize("HasDeclSecurity");

                    DeclSecurityStruct[k].bindex = ReadBlobIndex(metadata, offs);

                    offs += offsetblob;
                }
            }

            //ClassLayout

            old = tableoffset;

            tablehasrows = tablepresent(15);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("ClassLayout Table Offset {0} Size {1}", offs, sizes[15]);

            tableoffset = old;

            if (tablehasrows)
            {
                ClassLayoutStruct = new ClassLayoutTable[rows[15] + 1];

                for (var k = 1; k <= rows[15]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    ClassLayoutStruct[k].packingsize = BitConverter.ToInt16(metadata, offs);

                    offs += 2;

                    ClassLayoutStruct[k].classsize = BitConverter.ToInt32(metadata, offs);

                    offs += 4;

                    ClassLayoutStruct[k].parent = ReadTableIndex(metadata, offs, "TypeDef");

                    offs += GetTableSize("TypeDef");
                }
            }

            //FieldLayout

            old = tableoffset;

            tablehasrows = tablepresent(16);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("FieldLayout Table Offset {0} {1}", offs, sizes[16]);

            tableoffset = old;

            if (tablehasrows)
            {
                FieldLayoutStruct = new FieldLayoutTable[rows[16] + 1];

                for (var k = 1; k <= rows[16]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    FieldLayoutStruct[k].offset = BitConverter.ToInt32(metadata, offs);

                    offs += 4;

                    FieldLayoutStruct[k].fieldindex = ReadTableIndex(metadata, offs, "Field");

                    offs += GetTableSize("Field");
                }
            }

            //StandAloneSig

            old = tableoffset;

            tablehasrows = tablepresent(17);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("StandAloneSig Table Offset {0} Size {1}", offs, sizes[17]);

            tableoffset = old;

            if (tablehasrows)
            {
                StandAloneSigStruct = new StandAloneSigTable[rows[17] + 1];

                for (var k = 1; k <= rows[17]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    StandAloneSigStruct[k].index = ReadBlobIndex(metadata, offs);

                    offs += offsetblob;
                }
            }

            //EventMap

            old = tableoffset;

            tablehasrows = tablepresent(18);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("EventMap Table Offset {0} Size {1}", offs, sizes[18]);

            tableoffset = old;

            if (tablehasrows)
            {
                EventMapStruct = new EventMapTable[rows[18] + 1];

                for (var k = 1; k <= rows[18]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    EventMapStruct[k].index = ReadTableIndex(metadata, offs, "TypeDef");

                    offs += GetTableSize("TypeDef");

                    EventMapStruct[k].eindex = ReadTableIndex(metadata, offs, "Event");

                    offs += GetTableSize("Event");
                }
            }

            //Event

            old = tableoffset;

            tablehasrows = tablepresent(20);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("Event Table Offset {0} Size {1}", offs, sizes[20]);

            tableoffset = old;

            if (tablehasrows)
            {
                EventStruct = new EventTable[rows[20] + 1];

                for (var k = 1; k <= rows[20]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    EventStruct[k].attr = BitConverter.ToInt16(metadata, offs);

                    offs += 2;

                    EventStruct[k].name = ReadStringIndex(metadata, offs);

                    offs += offsetstring;

                    EventStruct[k].coded = ReadCodedIndex(metadata, offs, "TypeDefOrRef");

                    offs += GetCodedIndexSize("TypeDefOrRef");
                }
            }

            //PropertyMap

            old = tableoffset;

            tablehasrows = tablepresent(21);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("PropertyMap Table Offset {0} Size {1}", offs, sizes[21]);

            tableoffset = old;

            if (tablehasrows)
            {
                PropertyMapStruct = new PropertyMapTable[rows[21] + 1];

                for (var k = 1; k <= rows[21]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    PropertyMapStruct[k].parent = ReadTableIndex(metadata, offs, "TypeDef");

                    offs += GetTableSize("TypeDef");

                    PropertyMapStruct[k].propertylist = ReadTableIndex(metadata, offs, "Properties");

                    offs += GetTableSize("Properties");
                }
            }

            //Property

            old = tableoffset;

            tablehasrows = tablepresent(23);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("Property Table Offset {0} Size {1}", offs, sizes[23]);

            tableoffset = old;

            if (tablehasrows)
            {
                PropertyStruct = new PropertyTable[rows[23] + 1];

                for (var k = 1; k <= rows[23]; k++)
                {
                    //if ( debug )

                    //Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}" , metadata[offs].ToString("X") , metadata[offs+1].ToString("X") , metadata[offs+2].ToString("X") ,metadata[offs+3].ToString("X") ,metadata[offs+4].ToString("X") ,metadata[offs+5].ToString("X") , metadata[offs+6].ToString("X") , metadata[offs+7].ToString("X") , metadata[offs+8].ToString("X")  );

                    PropertyStruct[k].flags = BitConverter.ToInt16(metadata, offs);

                    offs += 2;

                    PropertyStruct[k].name = ReadStringIndex(metadata, offs);

                    offs += offsetstring;

                    PropertyStruct[k].type = ReadBlobIndex(metadata, offs);

                    offs += offsetblob;

                    //Console.WriteLine("...{0} {1} {2} {3}" , k , GetString(PropertyStruct[k].name) , PropertyStruct[k].flags , PropertyStruct[k].type);
                }
            }

            //MethodSemantics

            old = tableoffset;

            tablehasrows = tablepresent(24);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("MethodSemantics Table Offset {0} Size {1}", offs, sizes[24]);

            tableoffset = old;

            if (tablehasrows)
            {
                MethodSemanticsStruct = new MethodSemanticsTable[rows[24] + 1];

                for (var k = 1; k <= rows[24]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    MethodSemanticsStruct[k].methodsemanticsattributes = BitConverter.ToInt16(metadata, offs);

                    offs += 2;

                    MethodSemanticsStruct[k].methodindex = ReadTableIndex(metadata, offs, "Method");

                    offs += GetTableSize("Method");

                    MethodSemanticsStruct[k].association = ReadCodedIndex(metadata, offs, "HasSemantics");

                    offs += GetCodedIndexSize("HasSemantics");
                }
            }

            //MethodImpl

            old = tableoffset;

            tablehasrows = tablepresent(25);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("MethodImpl Table Offset {0} {1}", offs, sizes[25]);

            tableoffset = old;

            if (tablehasrows)
            {
                MethodImpStruct = new MethodImpTable[rows[25] + 1];

                for (var k = 1; k <= rows[25]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    MethodImpStruct[k].classindex = ReadTableIndex(metadata, offs, "TypeDef");

                    offs += GetTableSize("TypeDef");

                    MethodImpStruct[k].codedbody = ReadCodedIndex(metadata, offs, "MethodDefOrRef");

                    offs += GetCodedIndexSize("MethodDefOrRef");

                    MethodImpStruct[k].codeddef = ReadCodedIndex(metadata, offs, "MethodDefOrRef");

                    offs += GetCodedIndexSize("MethodDefOrRef");
                }
            }

            //ModuleRef

            old = tableoffset;

            tablehasrows = tablepresent(26);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("ModuleRef Table Offset {0} Size {1}", offs, sizes[26]);

            tableoffset = old;

            if (tablehasrows)
            {
                ModuleRefStruct = new ModuleRefTable[rows[26] + 1];

                for (var k = 1; k <= rows[26]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    ModuleRefStruct[k].name = ReadStringIndex(metadata, offs);

                    offs += offsetstring;
                }
            }

            //TypeSpec

            old = tableoffset;

            tablehasrows = tablepresent(27);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("TypeSpec Table Offset {0} Size={1}", offs, sizes[27]);

            tableoffset = old;

            if (tablehasrows)
            {
                TypeSpecStruct = new TypeSpecTable[rows[27] + 1];

                for (var k = 1; k <= rows[27]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    TypeSpecStruct[k].signature = ReadBlobIndex(metadata, offs);

                    offs += offsetblob;
                }
            }

            //ImplMap

            old = tableoffset;

            tablehasrows = tablepresent(28);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("ImplMap Table Offset offs={0} Size {1}", offs, sizes[28]);

            tableoffset = old;

            if (tablehasrows)
            {
                ImplMapStruct = new ImplMapTable[rows[28] + 1];

                for (var k = 1; k <= rows[28]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    ImplMapStruct[k].attr = BitConverter.ToInt16(metadata, offs);

                    offs += 2;

                    ImplMapStruct[k].cindex = ReadCodedIndex(metadata, offs, "MemberForwarded");

                    offs += GetCodedIndexSize("MemberForwarded");

                    ImplMapStruct[k].name = ReadStringIndex(metadata, offs);

                    offs += offsetstring;

                    ImplMapStruct[k].scope = ReadTableIndex(metadata, offs, "ModuleRef");

                    offs += GetTableSize("ModuleRef");
                }
            }

            //FieldRVA

            old = tableoffset;

            tablehasrows = tablepresent(29);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("FieldRVA Table Offset {0} Size {1}", offs, sizes[29]);

            tableoffset = old;

            if (tablehasrows)
            {
                FieldRVAStruct = new FieldRVATable[rows[29] + 1];

                for (var k = 1; k <= rows[29]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    FieldRVAStruct[k].rva = BitConverter.ToInt32(metadata, offs);

                    offs += 4;

                    FieldRVAStruct[k].fieldi = ReadTableIndex(metadata, offs, "Field");

                    offs += GetTableSize("Field");
                }
            }

            //Assembley

            old = tableoffset;

            tablehasrows = tablepresent(32);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("Assembly Table Offset {0} Size {1}", offs, sizes[32]);

            tableoffset = old;

            AssemblyStruct = new AssemblyTable[rows[32] + 1];

            if (tablehasrows)
            {
                for (var k = 1; k <= rows[32]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    AssemblyStruct[k].HashAlgId = BitConverter.ToInt32(metadata, offs);

                    offs += 4;

                    AssemblyStruct[k].major = BitConverter.ToInt16(metadata, offs);

                    offs += 2;

                    AssemblyStruct[k].minor = BitConverter.ToInt16(metadata, offs);

                    offs += 2;

                    AssemblyStruct[k].build = BitConverter.ToInt16(metadata, offs);

                    offs += 2;

                    AssemblyStruct[k].revision = BitConverter.ToInt16(metadata, offs);

                    offs += 2;

                    AssemblyStruct[k].flags = BitConverter.ToInt32(metadata, offs);

                    offs += 4;

                    AssemblyStruct[k].publickey = ReadBlobIndex(metadata, offs);

                    offs += offsetblob;

                    AssemblyStruct[k].name = ReadStringIndex(metadata, offs);

                    offs += offsetstring;

                    AssemblyStruct[k].culture = ReadStringIndex(metadata, offs);

                    offs += offsetstring;
                }
            }

            //AssemblyRef

            old = tableoffset;

            tablehasrows = tablepresent(35);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("AssembleyRef Table Offset {0} Size {1}", offs, sizes[35]);

            tableoffset = old;

            if (tablehasrows)
            {
                AssemblyRefStruct = new AssemblyRefTable[rows[35] + 1];

                for (var k = 1; k <= rows[35]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    AssemblyRefStruct[k].major = BitConverter.ToInt16(metadata, offs);

                    offs += 2;

                    AssemblyRefStruct[k].minor = BitConverter.ToInt16(metadata, offs);

                    offs += 2;

                    AssemblyRefStruct[k].build = BitConverter.ToInt16(metadata, offs);

                    offs += 2;

                    AssemblyRefStruct[k].revision = BitConverter.ToInt16(metadata, offs);

                    offs += 2;

                    AssemblyRefStruct[k].flags = BitConverter.ToInt32(metadata, offs);

                    offs += 4;

                    AssemblyRefStruct[k].publickey = ReadBlobIndex(metadata, offs);

                    offs += offsetblob;

                    AssemblyRefStruct[k].name = ReadStringIndex(metadata, offs);

                    offs += offsetstring;

                    AssemblyRefStruct[k].culture = ReadStringIndex(metadata, offs);

                    offs += offsetstring;

                    AssemblyRefStruct[k].hashvalue = ReadBlobIndex(metadata, offs);

                    offs += offsetblob;
                }
            }

            //File

            old = tableoffset;

            tablehasrows = tablepresent(38);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("File Table Offset {0} Size {1}", offs, sizes[38]);

            tableoffset = old;

            if (tablehasrows)
            {
                FileStruct = new FileTable[rows[38] + 1];

                for (var k = 1; k <= rows[38]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    FileStruct[k].flags = BitConverter.ToInt32(metadata, offs);

                    offs += 4;

                    FileStruct[k].name = ReadStringIndex(metadata, offs);

                    offs += offsetstring;

                    FileStruct[k].index = ReadBlobIndex(metadata, offs);

                    offs += offsetblob;
                }
            }

            //ExportedType

            old = tableoffset;

            tablehasrows = tablepresent(39);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("ExportedType Table Offset {0} Size {1}", offs, sizes[39]);

            tableoffset = old;

            if (tablehasrows)
            {
                ExportedTypeStruct = new ExportedTypeTable[rows[39] + 1];

                for (var k = 1; k <= rows[39]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"));

                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} ", metadata[offs + 8].ToString("X"),
                                          metadata[offs + 9].ToString("X"), metadata[offs + 10].ToString("X"),
                                          metadata[offs + 11].ToString("X"), metadata[offs + 12].ToString("X"),
                                          metadata[offs + 13].ToString("X"), metadata[offs + 14].ToString("X"));

                    ExportedTypeStruct[k].flags = BitConverter.ToInt32(metadata, offs);

                    offs += 4;

                    ExportedTypeStruct[k].typedefindex = BitConverter.ToInt32(metadata, offs);

                    offs += 4;

                    ExportedTypeStruct[k].name = ReadStringIndex(metadata, offs);

                    offs += offsetstring;

                    ExportedTypeStruct[k].nspace = ReadStringIndex(metadata, offs);

                    offs += offsetstring;

                    ExportedTypeStruct[k].coded = ReadCodedIndex(metadata, offs, "Implementation");

                    offs += GetCodedIndexSize("Implementation");

                    //Console.WriteLine("......{0} {1}" , ExportedTypeStruct[k].coded , ExportedTypeStruct[k].name );
                }
            }

            //ManifestResource

            old = tableoffset;

            tablehasrows = tablepresent(40);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("ManifestResource Table Offset {0} Size {1}", offs, sizes[40]);

            tableoffset = old;

            if (tablehasrows)
            {
                ManifestResourceStruct = new ManifestResourceTable[rows[40] + 1];

                for (var k = 1; k <= rows[40]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    ManifestResourceStruct[k].offset = BitConverter.ToInt32(metadata, offs);

                    offs += 4;

                    ManifestResourceStruct[k].flags = BitConverter.ToInt32(metadata, offs);

                    offs += 4;

                    ManifestResourceStruct[k].name = ReadStringIndex(metadata, offs);

                    offs += offsetstring;

                    ManifestResourceStruct[k].coded = ReadCodedIndex(metadata, offs, "Implementation");

                    offs += GetCodedIndexSize("");
                }
            }

            //Nested Classes

            old = tableoffset;

            tablehasrows = tablepresent(41);

            offs = tableoffset;

            if (debug)

                Console.WriteLine("Nested Classes Offset {0} Size {1}", offs, sizes[41]);

            tableoffset = old;

            if (tablehasrows)
            {
                NestedClassStruct = new NestedClassTable[rows[41] + 1];

                for (var k = 1; k <= rows[41]; k++)
                {
                    if (debug)

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", metadata[offs].ToString("X"),
                                          metadata[offs + 1].ToString("X"), metadata[offs + 2].ToString("X"),
                                          metadata[offs + 3].ToString("X"), metadata[offs + 4].ToString("X"),
                                          metadata[offs + 5].ToString("X"), metadata[offs + 6].ToString("X"),
                                          metadata[offs + 7].ToString("X"), metadata[offs + 8].ToString("X"));

                    NestedClassStruct[k].nestedclass = ReadTableIndex(metadata, offs, "TypeDef");

                    offs += GetTableSize("TypeDef");

                    NestedClassStruct[k].enclosingclass = ReadTableIndex(metadata, offs, "TypeDef");

                    offs += GetTableSize("TypeDef");
                }
            }

            int ii;

            for (ii = 1; ii <= TypeDefStruct.Length - 1; ii++)
            {
                //Console.WriteLine("........{0} {1} {2}" , TypeDefStruct.Length , IsTypeNested(ii) , ii);

                if (!IsTypeNested(ii))

                    lasttypedisplayed = ii;
            }
        }

        public bool tablepresent(byte tableindex)
        {
            var tablebit = (int)(valid >> tableindex) & 1;

            for (var j = 0; j < tableindex; j++)
            {
                var o = sizes[j] * rows[j];

                tableoffset = tableoffset + o;
            }

            if (tablebit == 1)

                return true;

            else

                return false;
        }

        public void ReadandDisplayExportAddressTableJumps()
        {
            Console.WriteLine("// Export Address Table Jumps:");

            if (exportaddressrva == 0)
            {
                Console.WriteLine("// No data.");

                Console.WriteLine();
            }
        }

        public void CreateFieldSignature(byte[] blobarray, int row)
        {
            //Console.WriteLine("Field Length={0} method row={1} name={2}" , blobarray.Length , row.ToString("X") , GetString(FieldStruct[row].name));

            var aa = -1;

            if (row == aa)
            {
                for (var l = 0; l < blobarray.Length; l++)

                    Console.Write("{0} ", blobarray[l].ToString("X"));

                Console.WriteLine();

                Console.WriteLine("Length of array is {0}", blobarray.Length);
            }

            int howmanybytes, uncompressedbyte;

            var index = 0;

            howmanybytes = CorSigUncompressData(blobarray, index, out uncompressedbyte);

            index = index + howmanybytes;

            var returnstring = GetElementType(index, blobarray, out howmanybytes, 0, "");

            returnstring = returnstring.Replace("^", ",");

            if (row == aa)

                Console.WriteLine("......returnstring={0}", returnstring);

            //if ( returnstring != "")

            //returnstring = returnstring.Remove(returnstring.Length-1, 1);

            fieldparamarray[row] = returnstring;

            fieldflagsarray[row] = GetFieldAttributes(row);
        }

        public void CreateLocalVarSignature(byte[] blobarray, int row)
        {
            //Console.WriteLine("Local Variable Array Length={0} method row={1} " , blobarray.Length , row );

            var aa = -1;

            if (blobarray.Length == 0)

                return;

            if (row == aa)
            {
                for (var l = 0; l < blobarray.Length; l++)

                    Console.Write("{0} ", blobarray[l].ToString("X"));

                Console.WriteLine();

                Console.WriteLine("Length of array is {0}", blobarray.Length);
            }

            var index = 0;

            standalonesigarray[row] = "";

            if (blobarray[index] != 0x07)

                return;

            index++;

            int howmanybytes, uncompressedbyte;

            howmanybytes = CorSigUncompressData(blobarray, index, out uncompressedbyte);

            index = index + howmanybytes;

            var returnstring = "";

            for (var l = 1; l <= uncompressedbyte; l++)
            {
                var typestring = GetElementType(index, blobarray, out howmanybytes, 0, "");

                typestring = typestring.Replace("^", ",");

                if (row == aa)

                    Console.WriteLine("......l={0} typestring={1} index={2} howmanybytes={3} value={4}", l, typestring,
                                      index, howmanybytes, blobarray[index].ToString("X"));

                //if ( typestring != "")

                //typestring = typestring.Remove(typestring.Length-1 , 1);

                var variableVindex = l - 1;

                returnstring = returnstring + typestring + " V_" + variableVindex;

                if (l != uncompressedbyte)

                    returnstring = returnstring + ",\r\n" + CreateSpaces(spacesforrest + 2 + spacesfornested) +
                                   CreateSpaces(9);

                index = index + howmanybytes;
            }

            standalonesigarray[row] = returnstring;
        }

        public string GetPointerToken(int index, byte[] blobarray, out int howmanybytes)
        {
            var returnstring = "";

            int howmanybytes2;

            returnstring = GetElementType(index + 1, blobarray, out howmanybytes2, 0, "") + "*";

            howmanybytes = howmanybytes2 + 1;

            return returnstring;
        }

        public string GetByrefToken(int index, byte[] blobarray, out int howmanybytes)
        {
            var returnstring = "";

            int howmanybytes2;

            returnstring = GetElementType(index + 1, blobarray, out howmanybytes2, 0, "") + "&";

            howmanybytes = howmanybytes2 + 1;

            return returnstring;
        }

        public string GetSzArray(int index, byte[] blobarray, out int howmanybytes)
        {
            var returnstring = "";

            var i = 1;

            returnstring = "[]";

            while (true)
            {
                var next = blobarray[index + i];

                if (next != 0x1d)

                    break;

                returnstring = returnstring + "[]";

                i = i + 1;
            }

            int howmanybytes2;

            returnstring = GetElementType(index + i, blobarray, out howmanybytes2, 0, "") + returnstring;

            howmanybytes = i + howmanybytes2;

            return returnstring;
        }

        public string GetTokenType(byte[] blobarray, int index, out int howmanybytes)
        {
            var returnstring = "";

            int uncompressedbyte;

            var howmanybytes1 = 0;

            howmanybytes1 = howmanybytes1 + CorSigUncompressData(blobarray, index + 1, out uncompressedbyte);

            var dummy1 = DecodeToken(uncompressedbyte, blobarray[index]);

            if (blobarray[index] == 0x12)

                returnstring = "class " + dummy1;

            else if (blobarray[index] == 0x11)

                returnstring = "valuetype " + dummy1;

            else

                returnstring = dummy1;

            howmanybytes = howmanybytes1;

            return returnstring;
        }

        public string GetPointerType(byte[] blobarray, int index, out int howmanybytes)
        {
            var returnstring = "";

            returnstring = GetElementType(index, blobarray, out howmanybytes, 0, "") + "*";

            return returnstring;
        }

        public void DisplayOverrideMethod(int methodrow)
        {
            if (MethodImpStruct == null)

                return;

            for (var ii = 1; ii < MethodImpStruct.Length; ii++)
            {
                var codeddeftablename = GetMethodDefTable(MethodImpStruct[ii].codeddef);

                var codeddefindex = GetMethodDefValue(MethodImpStruct[ii].codeddef);

                var codedbodytablename = GetMethodDefTable(MethodImpStruct[ii].codedbody);

                var codedbodyindex = GetMethodDefValue(MethodImpStruct[ii].codedbody);

                var typeindex = GetTypeForMethod(codedbodyindex);

                if (typeindex == MethodImpStruct[ii].classindex && codedbodytablename == "MethodDef" &&
                    codedbodyindex == methodrow)
                {
                    if (codeddeftablename == "MethodRef")
                    {
                        Console.Write(CreateSpaces(spacesforrest + 2 + spacesfornested));

                        Console.Write(".override ");

                        var typerefindex = GetTypeRefFromMethodRef(codeddefindex);

                        Console.WriteLine("{0}::{1} /*01{2}::0A{3}*/ ", typerefnames[typerefindex],
                                          NameReserved(GetString(MemberRefStruct[codeddefindex].name)),
                                          typerefindex.ToString("X6"), codeddefindex.ToString("X6"));
                    }

                    if (codeddeftablename == "MethodDef")
                    {
                        Console.Write(CreateSpaces(spacesforrest + 2 + spacesfornested));

                        var typedefindex = GetTypeForMethod(codeddefindex);

                        Console.Write(".override {0}::{1} ", typedefnames[typedefindex],
                                      NameReserved(GetString(MethodStruct[codeddefindex].name)));

                        Console.WriteLine("/*02{0}::06{1}*/ ", typedefindex.ToString("X6"), codeddefindex.ToString("X6"));
                    }
                }
            }
        }

        public bool IsGlobalMethod(int methodrow)
        {
            int start, startofnext = 0;

            //Console.WriteLine("........methodrow={0} TypeDefStruct.Length={1}" , methodrow , TypeDefStruct.Length);

            if (TypeDefStruct.Length == 2)

                return true;

            start = TypeDefStruct[1].mindex;

            if (TypeDefStruct.Length == 1)
            {
                startofnext = MethodStruct.Length;
            }

            else

                startofnext = TypeDefStruct[2].mindex;

            if (methodrow >= start && methodrow < startofnext)

                return true;

            else

                return false;
        }

        public string GetMethodAttribute1(int methodflags)
        {
            var returnstring = "";

            if ((methodflags & 0x0003) == 0x0003)

                returnstring = returnstring + "runtime ";

            else if ((methodflags & 0x0001) == 0x0001)

                returnstring = returnstring + "native ";

            else if ((methodflags & 0x0002) == 0x0002)

                returnstring = returnstring + "optil ";


            else

                returnstring = returnstring + "cil ";

            if ((methodflags & 0x0004) == 0x0004)

                returnstring = returnstring + "unmanaged";

            else

                returnstring = returnstring + "managed";

            if ((methodflags & 0x0080) == 0x0080)

                returnstring = returnstring + " preservesig";

            if ((methodflags & 0x0010) == 0x0010)

                returnstring = returnstring + " forwardref";

            if ((methodflags & 0x01000) == 0x1000)

                returnstring = returnstring + " internalcall";

            if ((methodflags & 0x0020) == 0x0020)

                returnstring = returnstring + " synchronized";

            if ((methodflags & 0x0008) == 0x0008)

                returnstring = returnstring + " noinlining";

            return returnstring;
        }

        public long ConvertRVA(long rva)
        {
            int i;

            for (i = 0; i < sections; i++)
            {
                if (rva >= SVirtualAddress[i] && (rva < SVirtualAddress[i] + SSizeOfRawData[i]))

                    break;
            }

            return SPointerToRawData[i] + (rva - SVirtualAddress[i]);
        }

        public string CreateSpaces(int howmanyspaces)
        {
            var returnstring = "";

            for (var j = 1; j <= howmanyspaces; j++)

                returnstring = returnstring + " ";

            return returnstring;
        }

        public string GetMemberRefParentCodedIndexTable(int memberrefparentcodedindex)
        {
            var returnstring = "";

            memberrefparentcodedindex = memberrefparentcodedindex & 0x07;

            if (memberrefparentcodedindex == 0)

                returnstring = "TypeDef";

            if (memberrefparentcodedindex == 1)

                returnstring = "TypeRef";

            if (memberrefparentcodedindex == 2)

                returnstring = "ModuleRef";

            if (memberrefparentcodedindex == 3)

                returnstring = "MethodDef";

            if (memberrefparentcodedindex == 4)

                returnstring = "TypeSpec";

            return returnstring;
        }

        public string GetString(int starting)
        {
            var ending = starting;

            //Console.WriteLine(".........starting={0} strings.Length={1}" , starting , strings.Length);

            if (starting < 0)

                return "";

            if (starting >= strings.Length)

                return "";

            while (strings[ending] != 0)
            {
                ending++;
            }

            var e = System.Text.Encoding.UTF8;

            var returnstring = e.GetString(strings, starting, ending - starting);

            if (returnstring.Length == 0)

                return "";

            else

                return returnstring;
        }

        public int ReadTableIndex(byte[] metadataarray, int arrayoffset, string tablename)
        {
            var returnindex = 0;

            var tablesize = GetTableSize(tablename);

            if (tablesize == 2)

                returnindex = BitConverter.ToUInt16(metadataarray, arrayoffset);

            if (tablesize == 4)

                returnindex = (int)BitConverter.ToUInt32(metadataarray, arrayoffset);

            return returnindex;
        }

        public int ReadStringIndex(byte[] metadataarray, int arrayoffset)
        {
            var returnindex = 0;

            if (offsetstring == 2)

                returnindex = BitConverter.ToUInt16(metadataarray, arrayoffset);

            if (offsetstring == 4)

                returnindex = (int)BitConverter.ToUInt32(metadataarray, arrayoffset);

            return returnindex;
        }

        public int ReadBlobIndex(byte[] metadataarray, int arrayoffset)
        {
            var returnindex = 0;

            if (offsetblob == 2)

                returnindex = BitConverter.ToUInt16(metadataarray, arrayoffset);

            if (offsetblob == 4)

                returnindex = (int)BitConverter.ToUInt32(metadataarray, arrayoffset);

            return returnindex;
        }

        public int ReadGuidIndex(byte[] metadataarray, int arrayoffset)
        {
            var returnindex = 0;

            if (offsetguid == 2)

                returnindex = BitConverter.ToUInt16(metadataarray, arrayoffset);

            if (offsetguid == 4)

                returnindex = (int)BitConverter.ToUInt32(metadataarray, arrayoffset);

            return returnindex;
        }

        public void DisplayGuid(int guidindex)
        {
            Console.Write("{");

            Console.Write("{0}{1}{2}{3}", guid[guidindex + 2].ToString("X2"), guid[guidindex + 1].ToString("X2"),
                          guid[guidindex].ToString("X2"), guid[guidindex - 1].ToString("X2"));

            Console.Write("-{0}{1}-", guid[guidindex + 4].ToString("X2"), guid[guidindex + 3].ToString("X2"));

            Console.Write("{0}{1}-", guid[guidindex + 6].ToString("X2"), guid[guidindex + 5].ToString("X2"));

            Console.Write("{0}{1}-", guid[guidindex + 7].ToString("X2"), guid[guidindex + 8].ToString("X2"));

            Console.Write("{0}{1}{2}{3}{4}{5}", guid[guidindex + 9].ToString("X2"), guid[guidindex + 10].ToString("X2"),
                          guid[guidindex + 11].ToString("X2"), guid[guidindex + 12].ToString("X2"),
                          guid[guidindex + 13].ToString("X2"), guid[guidindex + 14].ToString("X2"));

            Console.Write("}");
        }

        public void DisplayModuleAndMore()
        {
            Console.WriteLine(".module {0}", NameReserved(GetString(ModuleStruct[1].Name)));

            Console.Write("// MVID: ");

            DisplayGuid(ModuleStruct[1].Mvid);

            Console.WriteLine();

            DisplayCustomAttribute("Module", 1, 0);

            Console.WriteLine(".imagebase 0x{0}", ImageBase.ToString("x8"));

            Console.WriteLine(".subsystem 0x{0}", subsystem.ToString("X8"));

            Console.WriteLine(".file alignment {0}", filea);

            Console.WriteLine(".corflags 0x{0}", corflags.ToString("x8"));

            Console.WriteLine("// Image base: 0x03000000");
        }

        public string GetTypeDefOrRefTable(int codedvalue)
        {
            var returnstring = "";

            var tag = (short)(codedvalue & 0x03);

            if (tag == 0)

                returnstring = returnstring + "TypeDef";

            if (tag == 1)

                returnstring = returnstring + "TypeRef";

            if (tag == 2)

                returnstring = returnstring + "TypeSpec";

            return returnstring;
        }

        public int GetTypeDefOrRefValue(int codedvalue)
        {
            return codedvalue >> 2;
        }

        public string GetFieldRVA(int fieldrow)
        {
            var returnstring = "";

            int ii;

            if (FieldRVAStruct == null)

                return "";

            for (ii = 1; ii < FieldRVAStruct.Length; ii++)
            {
                var jj = FieldRVAStruct[ii].fieldi;

                if (jj == fieldrow)

                    break;
            }

            if (ii != FieldRVAStruct.Length)
            {
                var rva = FieldRVAStruct[ii].rva;

                returnstring = " D_" + rva.ToString("X8");
            }

            return returnstring;
        }

        public string GetMarshalTableValue(int fieldmarshalrow)
        {
            int ii;

            for (ii = 1; ii < FieldMarshalStruct.Length; ii++)
            {
                var fieldmarshalrowcoded = FieldMarshalStruct[ii].coded >> 1;

                if (fieldmarshalrow == fieldmarshalrowcoded)

                    break;
            }

            var index = FieldMarshalStruct[ii].index;

            int count = blob[index];

            var returnstring = GetMarshallType(blob[index + 1], count, 0);

            return returnstring;
        }

        public string GetType(int typebyte)
        {
            if (typebyte == 0x01)

                return "void";

            if (typebyte == 0x02)

                return "bool";

            if (typebyte == 0x03)

                return "char";

            if (typebyte == 0x04)

                return "int8";

            if (typebyte == 0x05)

                return "unsigned int8";

            if (typebyte == 0x06)

                return "int16";

            if (typebyte == 0x07)

                return "unsigned int16";

            if (typebyte == 0x08)

                return "int32";

            if (typebyte == 0x09)

                return "unsigned int32";

            if (typebyte == 0x0a)

                return "int64";

            if (typebyte == 0x0b)

                return "unsigned int64";

            if (typebyte == 0x0c)

                return "float32";

            if (typebyte == 0x0d)

                return "float64";

            if (typebyte == 0x0e)

                return "string";

            return "unknown";
        }

        public void DisplayGlobalFields()
        {
            int start, startofnext = 0;

            if (TypeDefStruct == null || FieldStruct == null)

                return;

            start = TypeDefStruct[1].findex;

            if (TypeDefStruct.Length == 2)

                startofnext = FieldStruct.Length;

            else

                startofnext = TypeDefStruct[2].findex;

            if (start != startofnext)
            {
                Console.WriteLine("//Global fields");

                Console.WriteLine("//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                DisplayAllFields(1);
            }
        }

        public void DisplayGlobalMethods()
        {
            int start, startofnext = 0;

            start = TypeDefStruct[1].mindex;

            if (TypeDefStruct == null || MethodStruct == null)

                return;


            if (TypeDefStruct.Length == 2)

                startofnext = MethodStruct.Length;

            else

                startofnext = TypeDefStruct[2].mindex;

            if (start != startofnext)
            {
                Console.WriteLine("//Global methods");

                Console.WriteLine("//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                spacesforrest = 0;

                DisplayAllMethods(1);

                spacesforrest = 2;
            }
        }

        public void DisplayNestedTypes(int typedefindex)
        {
            if (NestedClassStruct == null)

                return;

            for (var ii = 1; ii < NestedClassStruct.Length; ii++)
            {
                if (NestedClassStruct[ii].enclosingclass == typedefindex)
                {
                    spacesfornested += 2;

                    DisplayOneType(NestedClassStruct[ii].nestedclass);

                    spacesfornested -= 2;
                }
            }
        }

        public void DisplayNestedTypesPrototypes(int typedefindex)
        {
            if (NestedClassStruct == null)

                return;

            for (var ii = 1; ii < NestedClassStruct.Length; ii++)
            {
                if (NestedClassStruct[ii].enclosingclass == typedefindex)
                {
                    spacesfornested += 2;

                    DisplayOneTypePrototype(NestedClassStruct[ii].nestedclass);

                    spacesfornested -= 2;
                }
            }
        }

        public string GetMethodSignatureBytes(int methodrow)
        {
            var returnstring = "\r\n" + CreateSpaces(spacesforrest + spacesfornested) + "// SIG: ";

            int uncompressedbyte;

            var signatureindex = MethodStruct[methodrow].signature;

            int howmanybytes;

            howmanybytes = CorSigUncompressData(blob, signatureindex, out uncompressedbyte);

            var count = uncompressedbyte;

            if (howmanybytes == 2)

                count++;

            for (var j = howmanybytes; j <= count; j++)
            {
                returnstring = returnstring + blob[signatureindex + j].ToString("X2");

                if (j != count)

                    returnstring = returnstring + " ";
            }

            return returnstring;
        }

        public int GetHasSemanticsValue(int asscoiationbyte)
        {
            return asscoiationbyte >> 1;
        }

        public string GetFileAttributes(int fileflags)
        {
            var returnstring = "";

            if (fileflags == 0x00)

                returnstring = "";

            if (fileflags == 0x01)

                returnstring = "nometadata ";

            return returnstring;
        }

        public void DisplayModuleRefs()
        {
            if (ModuleRefStruct == null)

                return;

            for (var ii = 1; ii < ModuleRefStruct.Length; ii++)
            {
                var dummy = NameReserved(GetString(ModuleRefStruct[ii].name));

                if (dummy == "..\\unmanaged\\i386\\windowsidentity.dll")

                    Console.WriteLine(".module extern {0} /*1A{1}*/", "'..\\\\unmanaged\\\\i386\\\\windowsidentity.dll'",
                                      ii.ToString("X6"));

                else

                    Console.WriteLine(".module extern {0} /*1A{1}*/", dummy, ii.ToString("X6"));
            }
        }

        public int GetManifestResourceValue(int manifiestvalue)
        {
            return manifiestvalue >> 2;
        }

        public string GetManifestResourceTable(int manifiestvalue)
        {
            var returnstring = "";

            var tag = (short)(manifiestvalue & 0x03);

            if (tag == 0)

                returnstring = returnstring + "File";

            if (tag == 1)

                returnstring = returnstring + "AssemblyRef";

            if (tag == 2)

                returnstring = returnstring + "ExportedType";

            return returnstring;
        }

        public string GetManifestResourceAttributes(int manifiestvalue)
        {
            var returnstring = "";

            if ((manifiestvalue & 0x001) == 0x001)

                returnstring = returnstring + "public ";

            if ((manifiestvalue & 0x002) == 0x002)

                returnstring = returnstring + "private ";

            return returnstring;
        }

        public void DisplayResources()
        {
            if (ManifestResourceStruct == null)

                return;

            for (var ii = 1; ii < ManifestResourceStruct.Length; ii++)
            {
                var flags = GetManifestResourceAttributes(ManifestResourceStruct[ii].flags);

                Console.WriteLine(".mresource /*28{0}*/ {1}{2}", ii.ToString("X6"), flags,
                                  NameReserved(GetString(ManifestResourceStruct[ii].name)));

                Console.WriteLine("{");

                var table = GetManifestResourceTable(ManifestResourceStruct[ii].coded);

                var index = GetManifestResourceValue(ManifestResourceStruct[ii].coded);

                if (table == "AssemblyRef")

                    Console.WriteLine("  .assembly extern {0} /*23{1}*/ ",
                                      NameReserved(GetString(AssemblyRefStruct[index].name)), index.ToString("X6"));

                else if (table == "File" && index > 0)

                    Console.WriteLine("  .file {0}/*26{1}*/  at 0x{2}", NameReserved(GetString(FileStruct[index].name)),
                                      index.ToString("X6"), ManifestResourceStruct[ii].offset.ToString("X8"));

                else

                    Console.WriteLine("  // WARNING: managed resource file {0} created",
                                      NameReserved(GetString(ManifestResourceStruct[ii].name)));

                Console.WriteLine("}");
            }
        }

        public int GetMethodDefValue(int implcoded)
        {
            return implcoded >> 1;
        }

        public string GetMethodDefTable(int implcoded)
        {
            var returnstring = "";

            var tag = (short)(implcoded & 0x01);

            if (tag == 0)

                returnstring = returnstring + "MethodDef";

            if (tag == 1)

                returnstring = returnstring + "MethodRef";

            return returnstring;
        }

        public string GetMemberRefTable(int memberrefcodedindex)
        {
            var returnstring = "";

            var tag = (short)(memberrefcodedindex & 0x07);

            if (tag == 0)

                returnstring = returnstring + "NotUsed";

            if (tag == 1)

                returnstring = returnstring + "TypeRef";

            if (tag == 2)

                returnstring = returnstring + "ModuleRef";

            if (tag == 3)

                returnstring = returnstring + "MethodDef";

            if (tag == 4)

                returnstring = returnstring + "TypeSpec";

            return returnstring;
        }

        public int GetMemberRefValue(int memberrefcodedindex)
        {
            return memberrefcodedindex >> 3;
        }

        public int GetTypeRefFromMethodRef(int methodrefrow)
        {
            var memberrefcodedindex = 0;

            memberrefcodedindex = MemberRefStruct[methodrefrow].clas;

            var tablename = GetMemberRefTable(memberrefcodedindex);

            var typerefindex = GetMemberRefValue(memberrefcodedindex);

            return typerefindex;
        }

        public void DisplayClassExtern()
        {
            if (ExportedTypeStruct == null)

                return;

            for (var ii = 1; ii < ExportedTypeStruct.Length; ii++)
            {
                var ss1 = GetTypeAttributeFlagsForClassExtern(ExportedTypeStruct[ii].flags);

                var ss = GetString(ExportedTypeStruct[ii].nspace);

                if (ss.Length != 0)

                    ss = ss + ".";

                ss = ss + NameReserved(GetString(ExportedTypeStruct[ii].name));

                var table = ExportedTypeStruct[ii].coded & 0x03;

                var index = ExportedTypeStruct[ii].coded >> 2;

                if (table == 1)

                    Console.WriteLine(".............");

                if (index != 0)
                {
                    Console.Write(".class extern /*27{0}*/ {1}", ii.ToString("X6"), ss1);

                    Console.WriteLine(ss);

                    Console.WriteLine("{");

                    DisplayCustomAttribute("ExportedType", ii, 2);

                    if (table == 0)
                    {
                        Console.WriteLine("  .file {0}/*26{1}*/ ", NameReserved(GetString(FileStruct[index].name)),
                                          index.ToString("X6"));
                    }

                    if (table == 2)
                    {
                        Console.WriteLine("  .comtype '{0}' /*27{1}*/ ",
                                          NameReserved(GetString(ExportedTypeStruct[index].name)), index.ToString("X6"));
                    }

                    if (ExportedTypeStruct[ii].typedefindex != 0)

                        Console.WriteLine("  .class 0x{0}", ExportedTypeStruct[ii].typedefindex.ToString("X8"));

                    Console.WriteLine("}");
                }
            }
        }

        public int GetHasConstValue(int constcodedindex)
        {
            return constcodedindex >> 2;
        }

        public string GetHasConstTable(int constcodedindex)
        {
            var returnstring = "";

            var tag = constcodedindex & 0x03;

            if (tag == 0)

                returnstring = returnstring + "FieldDef";

            if (tag == 1)

                returnstring = returnstring + "ParamDef";

            if (tag == 2)

                returnstring = returnstring + "Property";

            return returnstring;
        }

        public void DisplayData()
        {
            if (FieldRVAStruct == null)

                return;

            for (var ii = 1; ii < FieldRVAStruct.Length; ii++)
            {
                Console.WriteLine(".11data D_{0} = bytearray (", FieldRVAStruct[ii].rva.ToString("X8"));

                if (ii == 1)
                {
                    Console.Write("{0} vijay8319){1}// ", CreateSpaces(16), CreateSpaces(37));

                    Console.Write("{");

                    Console.WriteLine("...");
                }

                else

                    Console.WriteLine("{0} 0C 00 00 00) ", CreateSpaces(16));
            }

            if (datavtfixuparray == null)

                return;

            for (var ii = 0; ii < datavtfixuparray.Length; ii++)

                Console.WriteLine(datavtfixuparray[ii]);
        }

        public string NameReserved(string name)
        {
            if (name == null)

                return name;

            if (name.Length == 0)

                return name;

            if (name.Length >= 2 && name[0] == 63 && name[1] == 63)

                return name;

            if ((byte)name[0] == 7)

                return "'\\a'";

            if ((byte)name[0] == 8)

                return "'\\b'";

            if ((byte)name[0] == 9)

                return "'\\t'";

            if ((byte)name[0] == 10)

                return "'\\n'";

            if ((byte)name[0] == 11)

                return "'\\v'";

            if ((byte)name[0] == 12)

                return "'\\f'";

            if ((byte)name[0] == 13)

                return "'\\r'";

            if ((byte)name[0] == 32)

                return "' '";

            if (name == "'")

                return "'\\''";

            if (name == "\"")

                return "'\\\"'";

            if (name.Length == 2 && (byte)name[1] == 7)

                return "'" + name[0] + "\\a'";

            if (name.Length == 2 && (byte)name[1] == 8)

                return "'" + name[0] + "\\b'";

            if (name.Length == 2 && (byte)name[1] == '\t')

                return "'" + name[0] + "\\t'";

            if (name.Length == 2 && (byte)name[1] == '\n')

                return "'" + name[0] + "\\n'";

            if (name.Length == 2 && (byte)name[1] == '\v')

                return "'" + name[0] + "\\v'";

            if (name.Length == 2 && (byte)name[1] == '\f')

                return "'" + name[0] + "\\f'";

            if (name.Length == 2 && (byte)name[1] == '\r')

                return "'" + name[0] + "\\r'";

            if (name.Length == 2 && (byte)name[1] == '"')

                return "'" + name[0] + "\\\"'";

            if (name.Length == 2 && (byte)name[1] == '\'')

                return "'" + name[0] + "\\\''";

            if (name.Length >= 1 && name[0] == '\'' && name[name.Length - 1] == '\'')

                return name;

            var i = 0;

            while (i < name.Length)
            {
                if ((name[i] >= '0' && name[i] <= '9') && i == 0)

                    return "'" + name + "'";

                if (name[i] >= 1 && name[i] <= 31)

                    return "'" + name + "'";

                if (name[i] >= 127 || name[i] == '<' || name[i] == '+' || name[i] == '-' || name[i] == ' ' ||
                    name[i] == '\'')
                {
                    var ind = name.IndexOf("'");

                    if (ind != -1)

                        name = name.Insert(ind, "\\");

                    return "'" + name + "'";
                }

                i++;
            }

            string[] namesarray = {
                                  "value", "blob", "object", "method", "init", ".init", "array", "policy.2.0.myasm",
                                  "policy.2.0.myasm.dll", "add", "assembly", "serializable", "lcid", "stream", "filter",
                                  "handler", "record", "request", "opt", "clsid", "hresult", "cf", "custom", "to", "ret",
                                  "import", "field", "sub", "any", "pop", "final", "rem", "storage", "error", "nested",
                                  "il", "instance", "date", "iunknown", "literal", "implements", "unused", "not",
                                  "alignment", "unicode", "bstr", "auto", "retval", "variant", "or", "family", "arglist",
                                  "br", "wrapper", "demand", "fault", "call", "algorithm", "native", "fixed", "string",
                                  "char", "decimal", "float", "int", "void", "pinned", "div", "true", "false", "default",
                                  "abstract", "^", "`", "{", "|", "}", "~", "!", "#", "(", "%", "-", ")", ":", ";", "=",
                                  ">", "assert", "synchronized", "runtime", "with", "class", "newarr", "ldobj", "ldloc",
                                  "stobj", "stloc", "starg", "refany", "ldelema", "ldarga", "ldarg", "initobj", "box",
                                  "demand", "ldfld", "ldflda", "ldsfld", "ldsflda", "vector", "in", "out", "and", "int8",
                                  "xor", "as", "at", "struct", "finally", "interface", ".CPmain", "enum", "vararg",
                                  "marshal", "policy.1.0.MathLibrary", "policy.1.0.MathLibrary.dll", "final",
                                  "System.Windows.Forms.Design.256_2.bmp", "System.Windows.Forms.Design.256_1.bmp"
                              };

            for (var ii = 0; ii < namesarray.Length; ii++)
            {
                if (name == namesarray[ii])
                {
                    var ind = name.IndexOf("'");

                    if (ind != -1)

                        name = name.Insert(ind, "\\");

                    return "'" + name + "'";
                }
            }

            return name;
        }

        public string GetActionSecurity(int actionbyte)
        {
            var returnstring = "";

            if (actionbyte == 1)

                returnstring = "request";

            if (actionbyte == 2)

                returnstring = "demand";

            if (actionbyte == 3)

                returnstring = "assert";

            if (actionbyte == 4)

                returnstring = "deny";

            if (actionbyte == 5)

                returnstring = "permitonly";

            if (actionbyte == 6)

                returnstring = "linkcheck";

            if (actionbyte == 7)

                returnstring = "inheritcheck";

            if (actionbyte == 8)

                returnstring = "reqmin";

            if (actionbyte == 9)

                returnstring = "reqopt";

            if (actionbyte == 10)

                returnstring = "reqrefuse";

            if (actionbyte == 11)

                returnstring = "prejitgrant";

            if (actionbyte == 12)

                returnstring = "prejitdeny";

            if (actionbyte == 13)

                returnstring = "noncasdemand";

            if (actionbyte == 14)

                returnstring = "noncaslinkdemand";

            if (actionbyte == 15)

                returnstring = "noncasinheritance";

            return returnstring;
        }

        public int GetTypeForField(int fieldrow)
        {
            var ii = 0;

            for (ii = 1; ii < TypeDefStruct.Length - 1; ii++)
            {
                var start = TypeDefStruct[ii].findex;

                var end = TypeDefStruct[ii + 1].findex - 1;

                if (rows[3] >= 1)
                {
                    start = FieldPtrStruct[start].index;

                    end = FieldPtrStruct[end].index;
                }

                if (fieldrow >= start && fieldrow <= end)

                    return ii;
            }

            return ii;
        }

        public int CorSigUncompressData(byte[] blobarray, int index, out int answer)
        {
            var howmanybytes = 0;

            answer = 0;

            if ((blobarray[index] & 0x80) == 0x00)
            {
                howmanybytes = 1;

                answer = blobarray[index];
            }

            else if ((blobarray[index] & 0xC0) == 0x80)
            {
                howmanybytes = 2;

                answer = ((blobarray[index] & 0x3f) << 8) | blobarray[index + 1];
            }

            else if ((blobarray[index] & 0xE0) == 0xC0)
            {
                howmanybytes = 4;

                answer = ((blobarray[index] & 0x1f) << 24) | (blobarray[index + 1] << 16) | (blobarray[index + 2] << 8) |
                         blobarray[index + 3];
            }

            return howmanybytes;
        }

        public int GetTableSize(string tablename)
        {
            int ii;

            for (ii = 0; ii < tablenames.Length; ii++)
            {
                if (tablename == tablenames[ii])

                    break;
            }

            if (rows[ii] >= 65535)

                return 4;

            else

                return 2;
        }

        public bool HasCustomAttribute(string tablename, int index)
        {
            if (CustomAttributeStruct == null)

                return false;

            for (var ii = 1; ii < CustomAttributeStruct.Length; ii++)
            {
                var parentcodedtablename = GetHasCustomAttributeTable(CustomAttributeStruct[ii].parent);

                var parentcodedindex = GetHasCustomAttributeValue(CustomAttributeStruct[ii].parent);

                //Console.WriteLine(".......{0} {1} index={2}",parentcodedtablename , parentcodedindex , index);

                if (parentcodedtablename == tablename && parentcodedindex == index)

                    return true;
            }

            return false;
        }

        public string GetTypeAttributeFlagsForClassExtern(int typeattributeflags)
        {
            typeattributeflags = typeattributeflags & 0x07;

            var visibiltymaskstring = "";

            if (typeattributeflags == 1)

                visibiltymaskstring = "public ";

            if (typeattributeflags == 2)

                visibiltymaskstring = "nested public ";

            return visibiltymaskstring;
        }

        public string GetParamAttrforParamCalling(int paramindex)
        {
            var returnstring = "";

            if (ParamStruct == null)

                return "";

            if (paramindex >= ParamStruct.Length)

                return "";

            if (ParamStruct[paramindex].sequence == 0)

                return returnstring;

            int pattr = ParamStruct[paramindex].pattr;

            if ((pattr & 0x01) == 0x01)

                returnstring = returnstring + "[in]";

            if ((pattr & 0x02) == 0x02)

                returnstring = returnstring + "[out]";

            if ((pattr & 0x10) == 0x10)

                returnstring = returnstring + "[opt]";

            if (returnstring != "")

                returnstring = returnstring + " ";

            return returnstring;
        }

        public string GetParamAttrforMethodCalling(int methodindex)
        {
            var returnstring = "";

            if (ParamStruct == null)

                return returnstring;

            int end;

            var start = MethodStruct[methodindex].param;

            if (methodindex == (MethodStruct.Length - 1))

                end = ParamStruct.Length + 1;

            else

                end = MethodStruct[methodindex + 1].param;

            if (start == ParamStruct.Length)

                return returnstring;

            if (start == end)

                return returnstring;

            if (ParamStruct[start].sequence != 0)

                return "";

            int pattr = ParamStruct[start].pattr;

            if ((pattr & 0x01) == 0x01)

                returnstring = returnstring + "[in]";

            if ((pattr & 0x02) == 0x02)

                returnstring = returnstring + "[out]";

            if ((pattr & 0x10) == 0x10)

                returnstring = returnstring + "[opt]";

            if (returnstring != "")

                returnstring = returnstring + " ";

            return returnstring;
        }

        public string GetFieldAttributes(int fieldrow)
        {
            var flags = FieldStruct[fieldrow].flags;

            var returnstring = "";

            var arrayoffset = "";

            int ii;

            if (FieldLayoutStruct != null)
            {
                for (ii = 1; ii < FieldLayoutStruct.Length; ii++)
                {
                    var jj = FieldLayoutStruct[ii].fieldindex;

                    if (jj == fieldrow)

                        break;
                }

                if (ii != FieldLayoutStruct.Length)
                {
                    var offset = FieldLayoutStruct[ii].offset;

                    arrayoffset = "[" + offset.ToString("") + "] ";
                }
            }

            if ((flags & 0x06) == 0x06)

                returnstring = returnstring + "public ";

            else if ((flags & 0x05) == 0x05)

                returnstring = returnstring + "famorassem ";

            else if ((flags & 0x03) == 0x03)

                returnstring = returnstring + "assembly ";

            else if ((flags & 0x01) == 0x01)

                returnstring = returnstring + "private ";

            else if ((flags & 0x02) == 0x02)

                returnstring = returnstring + "famandassem ";

            else if ((flags & 0x04) == 0x04)

                returnstring = returnstring + "family ";

            else

                returnstring = returnstring + "privatescope ";

            if ((flags & 0x10) == 0x10)
            {
                var firstfourbits = flags & 0xF;

                if ((firstfourbits == 0x06) || (firstfourbits == 0x01))
                {
                    returnstring = returnstring + "static ";
                }

                else

                    returnstring = "static " + returnstring;
            }

            returnstring = arrayoffset + returnstring;

            if ((flags & 0x20) == 0x20)

                returnstring = returnstring + "initonly ";

            if ((flags & 0x40) == 0x40)

                returnstring = returnstring + "literal ";

            if ((flags & 0x80) == 0x80)

                returnstring = returnstring + "notserialized ";

            if ((flags & 0x200) == 0x200)

                returnstring = returnstring + "specialname ";

            if ((flags & 0x400) == 0x400)

                returnstring = returnstring + "rtspecialname ";

            if ((flags & 0x400) == 0x400)

                returnstring = returnstring + "";

            returnstring = returnstring + DecodeParamAttributes(flags, 0, fieldrow, 0x1000);

            return returnstring;
        }

        public void DisplayAllSecurity(int tabletype, int tableindex)
        {
            if (DeclSecurityStruct == null)

                return;

            for (var ii = 1; ii < DeclSecurityStruct.Length; ii++)
            {
                var coded = DeclSecurityStruct[ii].coded;

                var table = coded & 0x03;

                var row = coded >> 2;

                if ((table == tabletype && row == tableindex))
                {
                    string returnstring;

                    if (tabletype == 2)

                        returnstring = CreateSpaces(2);

                    else if (tabletype == 0)

                        returnstring = CreateSpaces(spacesforrest + spacesfornested);

                    else

                        returnstring = CreateSpaces(spacesforrest + 2 + spacesfornested);

                    returnstring = returnstring + ".permissionset ";

                    var actionname = GetActionSecurity(DeclSecurityStruct[ii].action);

                    returnstring = returnstring + actionname;

                    returnstring = returnstring + " = (";

                    Console.Write(returnstring);

                    var index = DeclSecurityStruct[ii].bindex;

                    if (index == 0)

                        Console.WriteLine(")");

                    else

                        DisplayFormattedColumns(index, returnstring.Length, false, false);
                }
            }
        }

        public void DisplayFileTable()
        {
            if (FileStruct == null)

                return;

            for (var ii = 1; ii < FileStruct.Length; ii++)
            {
                Console.WriteLine(".file /*26{0}*/ {1}{2}", ii.ToString("X6"), GetFileAttributes(FileStruct[ii].flags),
                                  NameReserved(GetString(FileStruct[ii].name)));

                var table = entrypointtoken >> 24;

                if (table == 0x26)
                {
                    var row = entrypointtoken & 0x00ffffff;

                    if (row == (ii))

                        Console.WriteLine("    .entrypoint");
                }

                if (FileStruct[ii].index != 0)
                {
                    Console.Write("    .hash = (");

                    var index = FileStruct[ii].index;

                    DisplayFormattedColumns(index, 13, false, false);
                }

                DisplayCustomAttribute("File", ii, 0);
            }
        }

        public void DisplayAssembleyRefs()
        {
            if (AssemblyRefStruct == null)

                return;

            for (var i = 1; i < AssemblyRefStruct.Length; i++)
            {
                //Console.WriteLine("...........{0} {1}" , AssemblyRefStruct[i].name , strings.Length);

                Console.WriteLine(".assembly extern /*23{0}*/ {1}", i.ToString("X6"),
                                  NameReserved(GetString(AssemblyRefStruct[i].name)));

                Console.WriteLine("{");

                DisplayCustomAttribute("AssemblyRef", i, 2);

                if (AssemblyRefStruct[i].publickey != 0)
                {
                    Console.Write("  .publickeytoken = (");

                    DisplayFormattedColumns(AssemblyRefStruct[i].publickey, 22, true, false);
                }

                if (AssemblyRefStruct[i].hashvalue != 0)
                {
                    Console.Write("  .hash = (");

                    DisplayFormattedColumns(AssemblyRefStruct[i].hashvalue, 11, false, false);
                }

                int rev = AssemblyRefStruct[i].revision;

                if (rev < 0)

                    rev = 65536 + rev;

                Console.WriteLine("  .ver {0}:{1}:{2}:{3}", AssemblyRefStruct[i].major, AssemblyRefStruct[i].minor,
                                  AssemblyRefStruct[i].build, rev);

                if (AssemblyRefStruct[i].culture != 0)
                {
                    Console.Write("  .locale = (");

                    var index = AssemblyRefStruct[i].culture;

                    var cnt = 0;

                    while (strings[index] != 0)
                    {
                        Console.Write("{0} 00 ", strings[index].ToString("X"));

                        cnt++;

                        index++;
                    }

                    var nos = 64 - (14 + 6 + (6 * cnt + 1));

                    Console.Write("00 00");

                    Console.Write(" ){0}// ", CreateSpaces(nos));

                    index = AssemblyRefStruct[i].culture;

                    while (strings[index] != 0)
                    {
                        Console.Write("{0}.", (char)strings[index]);

                        index++;
                    }

                    Console.WriteLine("..");
                }

                Console.WriteLine("}");
            }
        }

        public void DisplayAssembley()
        {
            if (AssemblyStruct.Length == 1)

                return;

            Console.WriteLine(".assembly /*20000001*/ {0}", NameReserved(GetString(AssemblyStruct[1].name)));

            Console.WriteLine("{");

            DisplayCustomAttribute("Assembly", 1, 2 + spacefornamespace);

            DisplayAllSecurity(2, 1);

            if (AssemblyStruct[1].publickey != 0)
            {
                Console.Write("  .publickey = (");

                DisplayFormattedColumns(AssemblyStruct[1].publickey, 16, true, false);
            }

            if (AssemblyStruct[1].HashAlgId != 0)

                Console.WriteLine("  .hash algorithm 0x{0}", AssemblyStruct[1].HashAlgId.ToString("x8"));

            var rev = AssemblyStruct[1].revision;

            if (rev < 0)

                rev = 65536 + rev;

            Console.WriteLine("  .ver {0}:{1}:{2}:{3}", AssemblyStruct[1].major, AssemblyStruct[1].minor,
                              AssemblyStruct[1].build, rev);

            if (AssemblyStruct[1].culture != 0)
            {
                Console.Write("  .locale = (");

                var index = AssemblyStruct[1].culture;

                var cnt = 0;

                while (strings[index] != 0)
                {
                    Console.Write("{0} 00 ", strings[index].ToString("X"));

                    index++;

                    cnt++;
                }

                Console.Write("00 00");

                Console.Write(" )");

                var nos = 64 - (15 + cnt * 6 + 6);

                Console.Write(CreateSpaces(nos));

                Console.Write("// ");

                index = AssemblyStruct[1].culture;

                while (strings[index] != 0)
                {
                    Console.Write("{0}.", (char)strings[index]);

                    index++;
                }

                Console.WriteLine("..");
            }

            Console.WriteLine("}");
        }

        public string DisplayExceptionBytes(int i)
        {
            var ss = "// HEX: ";

            ss = ss + ConvertInt32ToString(ExceptionStruct[i].flags);

            ss = ss + ConvertInt32ToString(ExceptionStruct[i].tryoffset);

            ss = ss + ConvertInt32ToString(ExceptionStruct[i].trylength);

            ss = ss + ConvertInt32ToString(ExceptionStruct[i].handleroffset);

            ss = ss + ConvertInt32ToString(ExceptionStruct[i].handlerlength);

            ss = ss + ConvertInt32ToString(ExceptionStruct[i].token);

            ss = ss.Remove(ss.Length - 1, 1);

            return ss + "\r\n";
        }

        public string ConvertInt32ToString(int i)
        {
            var ss = "";

            var b1 = i & 0xff;

            var b2 = (i & 0xff00) >> 8;

            var b3 = (i & 0xff0000) >> 16;

            var b4 = i >> 24;

            if (b4 == -1)

                b4 = 0xff;

            ss = b1.ToString("X2") + " " + b2.ToString("X2") + " " + b3.ToString("X2") + " " + b4.ToString("X2") + " ";

            return ss;
        }

        public void ReadExceptions(long pos, int codesize, int methodindex)
        {
            var aa = -1;

            var where = mfilestream.Position;

            var pos1 = pos + codesize + 12;

            long extra = 0;

            extra = pos1 % 4;

            if (extra != 0)

                extra = 4 - extra;

            var newpos = pos1 + extra;

            mfilestream.Position = newpos;

            int first = mbinaryreader.ReadByte();

            if (methodindex == aa)

                Console.WriteLine("...........Flag={0}", first.ToString("X"));

            if ((first & 0x40) != 0x40)
            {
                int second = mbinaryreader.ReadByte();

                mbinaryreader.ReadInt16();

                var cnt = (second - 4) / 12;

                if (methodindex == aa)

                    Console.WriteLine("................count={0}", cnt);

                ExceptionStruct = new ExceptionTable[cnt];

                for (var jj = 0; jj < cnt; jj++)
                {
                    ExceptionStruct[jj].flags = mbinaryreader.ReadInt16();

                    ExceptionStruct[jj].tryoffset = mbinaryreader.ReadInt16();

                    ExceptionStruct[jj].trylength = mbinaryreader.ReadByte();

                    ExceptionStruct[jj].handleroffset = mbinaryreader.ReadInt16();

                    ExceptionStruct[jj].handlerlength = mbinaryreader.ReadByte();

                    ExceptionStruct[jj].token = mbinaryreader.ReadInt32();

                    ExceptionStruct[jj].oneline = 0;
                }

                if (methodindex == aa)

                    Console.WriteLine("...........If Over");
            }

            else
            {
                if (methodindex == aa)

                    Console.WriteLine("............in else");

                int a1 = mbinaryreader.ReadByte();

                int a2 = mbinaryreader.ReadByte();

                int a3 = mbinaryreader.ReadByte();

                var second = a1 + a2 * 256 + a3 * 65536;

                if (methodindex == aa)

                    Console.WriteLine("............a1={0} a2={1} a3={2} second={3}", a1, a2, a3, second);

                int cnt;

                if (second == 24)

                    cnt = 1;

                else if (second == 48)

                    cnt = 2;

                else

                    cnt = (second - 4) / 24;

                ExceptionStruct = new ExceptionTable[cnt];

                if (methodindex == aa)

                    Console.WriteLine("................count={0}", cnt);

                for (var jj = 0; jj < cnt; jj++)
                {
                    ExceptionStruct[jj].flags = mbinaryreader.ReadInt32();

                    ExceptionStruct[jj].tryoffset = mbinaryreader.ReadInt32();

                    ExceptionStruct[jj].trylength = mbinaryreader.ReadInt32();

                    ExceptionStruct[jj].handleroffset = mbinaryreader.ReadInt32();

                    ExceptionStruct[jj].handlerlength = mbinaryreader.ReadInt32();

                    ExceptionStruct[jj].token = mbinaryreader.ReadInt32();

                    ExceptionStruct[jj].oneline = 0;
                }
            }

            mfilestream.Position = where;
        }

        public void DisplayMethodILCode(string classname, string methodname, int methodindex)
        {
            var codearray = new byte[codesize];

            for (var i = 1; i <= codesize; i++)
            {
                codearray[i - 1] = mbinaryreader.ReadByte();
            }

            spacesfortry = 0;

            if ((first12 & 0x08) == 0x08 && !tinyformat)

                CreateExceptionArray(methodindex, codearray);

            for (var arrayoffset = 0; arrayoffset < codesize; )
            {
                int instructionbyte = codearray[arrayoffset];

                OpCode opcode;

                if ((first12 & 0x08) == 0x08 && !tinyformat)

                    DisplayExceptions(arrayoffset, codearray);

                var strings = "";

                var twobyte = 0;

                if (instructionbyte == 0xFE)
                {
                    instructionbyte = codearray[arrayoffset + 1];

                    opcode = OpCodesArray1[instructionbyte];

                    strings = CreateSpaces(spacesforrest + 2 + spacesfortry + spacesfornested);

                    strings = strings + "IL_" + arrayoffset.ToString("x4") + ":  /* " + opcode.Value.ToString("X") + " | ";

                    //Console.Write(strings);

                    arrayoffset = arrayoffset + 1;

                    twobyte = 1;
                }

                else
                {
                    opcode = OpCodesArray[instructionbyte];

                    strings = CreateSpaces(spacesforrest + 2 + spacesfortry + spacesfornested);

                    twobyte = 0;

                    if (!(opcode.Value == 0 && opcode.Name != "nop"))
                    {
                        strings = strings + "IL_" + arrayoffset.ToString("x4") + ":  /* " + opcode.Value.ToString("X2") +
                                  "   | ";

                        //Console.Write(strings);
                    }
                }

                if (opcode.Value == 0 && opcode.Name != "nop")
                {
                    strings = strings + "IL_" + arrayoffset.ToString("x4") + ":  /* " + instructionbyte.ToString("X2") +
                              "   | ";

                    strings = strings + CreateSpaces(17) + "*/ unused";

                    Console.WriteLine("{0}", strings);

                    arrayoffset = arrayoffset + 1;
                }

                else
                {
                    var sizeofinstructionanddata = DecodeILInstrcution2(opcode, arrayoffset, codearray, methodindex, strings);

                    Console.WriteLine();

                    if ((first12 & 0x08) == 0x08 && !tinyformat)

                        DisplayExceptions1(arrayoffset, codearray, twobyte);

                    arrayoffset = arrayoffset + sizeofinstructionanddata;
                }
            }

            if ((first12 & 0x08) == 0x08 && !tinyformat)
            {
                if (ExceptionStruct[0].oneline == 2)
                {
                    Console.Write(CreateSpaces(spacesforrest + spacesfornested + 2));

                    Console.WriteLine("IL_{0:x4}:  ", codearray.Length);

                    Console.Write(CreateSpaces(spacesforrest + spacesfornested + 2));

                    Console.WriteLine("// Exception count 1");

                    DisplayOneLineTry(0);
                }
            }

            Console.Write(CreateSpaces(spacesforrest + spacesfornested));

            Console.Write("}");

            if (GetTypeForMethod(methodindex) == 1)

                Console.WriteLine(" // end of global method {0}\r\n", methodname);

            else

                Console.WriteLine(" // end of method {0}::{1}\r\n", classname, methodname);
        }

        public void CreateExceptionArray(int methodindex, byte[] codearray)
        {
            if (ExceptionStruct == null)

                return;

            if (ExceptionStruct[0].handleroffset + ExceptionStruct[0].handlerlength == codearray.Length &&
                ExceptionStruct.Length == 1)

                ExceptionStruct[0].oneline = 2;

            if (ExceptionStruct[0].tryoffset + ExceptionStruct[0].trylength != ExceptionStruct[0].handleroffset &&
                ExceptionStruct.Length == 1)

                ExceptionStruct[0].oneline = 1;

            if (ExceptionStruct.Length == 2)
            {
                var a = ExceptionStruct[0].tryoffset + ExceptionStruct[0].trylength != ExceptionStruct[0].handleroffset;

                var b = ExceptionStruct[1].tryoffset + ExceptionStruct[1].trylength != ExceptionStruct[1].handleroffset;

                if (a && b)
                {
                    ExceptionStruct[0].oneline = 1;

                    ExceptionStruct[1].oneline = 1;
                }
            }

            if (ExceptionStruct.Length == 2)
            {
                var a = ExceptionStruct[0].tryoffset + ExceptionStruct[0].trylength != ExceptionStruct[0].handleroffset;

                var b = ExceptionStruct[1].tryoffset + ExceptionStruct[1].trylength == ExceptionStruct[1].handleroffset;

                if (a && b)
                {
                    ExceptionStruct[0].oneline = 1;

                    ExceptionStruct[1].oneline = 0;
                }
            }

            if (ExceptionStruct.Length == 2)
            {
                if (ExceptionStruct[0].tryoffset == ExceptionStruct[1].tryoffset &&
                    ExceptionStruct[0].trylength == ExceptionStruct[1].trylength &&
                    ExceptionStruct[1].handleroffset + ExceptionStruct[1].handlerlength == codearray.Length - 1 &&
                    ExceptionStruct[0].handlerlength == 1)

                    if (ExceptionStruct[0].handleroffset + ExceptionStruct[0].handlerlength !=
                        ExceptionStruct[1].handleroffset)

                        ExceptionStruct[1].oneline = 1;
            }

            if (ExceptionStruct.Length == 3 && ExceptionStruct[0].tryoffset == ExceptionStruct[1].tryoffset &&
                ExceptionStruct[0].tryoffset > ExceptionStruct[2].tryoffset &&
                ExceptionStruct[0].flags == ExceptionStruct[1].flags && ExceptionStruct[2].flags == ExceptionStruct[1].flags &&
                ExceptionStruct[1].flags == 2)
            {
                var a = ExceptionStruct[0];

                ExceptionStruct[0] = ExceptionStruct[2];

                ExceptionStruct[2] = a;
            }

            for (var ii = 0; ii < ExceptionStruct.Length - 1; ii++)
            {
                var secondtry = ExceptionStruct[ii].tryoffset + ExceptionStruct[ii].trylength;

                var thirdtry = ExceptionStruct[ii + 1].tryoffset + ExceptionStruct[ii + 1].trylength;

                if (ExceptionStruct[ii].tryoffset > ExceptionStruct[ii + 1].tryoffset && secondtry > thirdtry)
                {
                    var a = ExceptionStruct[ii];

                    ExceptionStruct[ii] = ExceptionStruct[ii + 1];

                    ExceptionStruct[ii + 1] = a;
                }
            }

            if (methodindex == -1)
            {
                for (var ii = 0; ii < ExceptionStruct.Length; ii++)
                {
                    Console.WriteLine(" Flags {0} ", ExceptionStruct[ii].flags.ToString("X8"));

                    Console.WriteLine(" Try Offset {0} 0x{1}", ExceptionStruct[ii].tryoffset,
                                      ExceptionStruct[ii].tryoffset.ToString("X"));

                    Console.WriteLine(" Try Length {0} 0x{1}", ExceptionStruct[ii].trylength,
                                      ExceptionStruct[ii].trylength.ToString("X"));

                    Console.WriteLine(" Handler  Offset {0} 0x{1}", ExceptionStruct[ii].handleroffset,
                                      ExceptionStruct[ii].handleroffset.ToString("X"));

                    Console.WriteLine(" Handler length {0} 0x{1}", ExceptionStruct[ii].handlerlength,
                                      ExceptionStruct[ii].handlerlength.ToString("X"));

                    Console.WriteLine(" Token {0:X}", ExceptionStruct[ii].token,
                                      ExceptionStruct[ii].handleroffset + ExceptionStruct[ii].handlerlength);

                    Console.WriteLine("EndTry={0:X} Endhandler={1:X} codearray={2:X} oneline={3}",
                                      ExceptionStruct[ii].tryoffset + ExceptionStruct[ii].trylength,
                                      ExceptionStruct[ii].handleroffset + ExceptionStruct[ii].handlerlength,
                                      codearray.Length, ExceptionStruct[ii].oneline);

                    Console.WriteLine();
                }
            }
        }

        public void DisplayExceptions(int instructionnumber, byte[] codearray)
        {
            int ii;

            var endtry = false;

            for (ii = 0; ii < ExceptionStruct.Length; ii++)
            {
                var showtry = true;

                if (ii >= 1) // to show a try or not
                {
                    var first = ExceptionStruct[ii].tryoffset + ExceptionStruct[ii].trylength;

                    var second = ExceptionStruct[ii - 1].tryoffset + ExceptionStruct[ii - 1].trylength;

                    if (first == second && ExceptionStruct[ii - 1].oneline != 1)

                        showtry = false;

                    else

                        showtry = true;
                }

                if (instructionnumber == ExceptionStruct[ii].tryoffset && showtry && ExceptionStruct[ii].oneline == 0)
                {
                    Console.Write(CreateSpaces(spacesforrest + 2 + spacesfortry + spacesfornested));

                    Console.WriteLine(".try");

                    Console.Write(CreateSpaces(spacesforrest + 2 + spacesfortry + spacesfornested));

                    Console.Write("{\r\n");

                    spacesfortry = spacesfortry + 2;
                }

                if (instructionnumber == ExceptionStruct[ii].tryoffset + ExceptionStruct[ii].trylength && !endtry &&
                    ExceptionStruct[ii].oneline == 0)
                {
                    Console.Write(CreateSpaces(spacesforrest + spacesfortry + spacesfornested));

                    Console.WriteLine("}  // end .try");

                    spacesfortry = spacesfortry - 2;

                    endtry = true;
                }

                if (instructionnumber == ExceptionStruct[ii].handleroffset && ExceptionStruct[ii].flags == 0 &&
                    ExceptionStruct[ii].oneline == 0)
                {
                    var token = ExceptionStruct[ii].token;

                    var table = token >> 24;

                    var tablerow = token & 0xffffff;

                    var typename = "";

                    if (table == 2)

                        typename = typedefnames[tablerow];

                    if (table == 1)

                        typename = typerefnames[tablerow];

                    Console.Write(CreateSpaces(spacesforrest + 2 + spacesfortry + spacesfornested));

                    Console.WriteLine("catch {0} ", typename);

                    Console.Write(CreateSpaces(spacesforrest + 2 + spacesfortry + spacesfornested));

                    Console.WriteLine("{");

                    spacesfortry = spacesfortry + 2;

                    //Console.WriteLine("........{0} {1}" , table, tablerow);
                }

                if (instructionnumber == ExceptionStruct[ii].handleroffset && ExceptionStruct[ii].flags == 2 &&
                    ExceptionStruct[ii].oneline == 0)
                {
                    Console.Write(CreateSpaces(spacesforrest + 2 + spacesfortry + spacesfornested));

                    Console.WriteLine("finally");

                    Console.Write(CreateSpaces(spacesforrest + 2 + spacesfortry + spacesfornested));

                    Console.WriteLine("{");

                    spacesfortry = spacesfortry + 2;
                }

                if (instructionnumber == ExceptionStruct[ii].handleroffset && ExceptionStruct[ii].flags == 4 &&
                    ExceptionStruct[ii].oneline == 0)
                {
                    Console.Write(CreateSpaces(spacesforrest + 2 + spacesfortry + spacesfornested));

                    Console.WriteLine("fault");

                    Console.Write(CreateSpaces(spacesforrest + 2 + spacesfortry + spacesfornested));

                    Console.WriteLine("{");

                    spacesfortry = spacesfortry + 2;
                }

                if (instructionnumber == ExceptionStruct[ii].handleroffset + ExceptionStruct[ii].handlerlength &&
                    ExceptionStruct[ii].oneline == 0)
                {
                    Console.Write(CreateSpaces(spacesforrest + spacesfortry + spacesfornested));

                    Console.WriteLine("}  // end handler");

                    Console.Write(CreateSpaces(spacesforrest + spacesfortry + spacesfornested));

                    Console.Write(DisplayExceptionBytes(ii));

                    spacesfortry = spacesfortry - 2;
                }
            }
        }

        public void DisplayExceptions1(int instructionnumber, byte[] codearray, int twobyte)
        {
            int ii;

            //Console.WriteLine(".......{0:X} {1:X}" , instructionnumber , codearray[instructionnumber] );

            for (ii = 0; ii < ExceptionStruct.Length; ii++)
            {
                var trypos = ExceptionStruct[ii].tryoffset + ExceptionStruct[ii].trylength;

                var handlerpos = ExceptionStruct[ii].handleroffset + ExceptionStruct[ii].handlerlength;

                int offset;

                //div_i4.exe div_i8.exe

                if (trypos > handlerpos)

                    offset = trypos;

                else

                    offset = handlerpos;


                if (instructionnumber == offset + twobyte && ExceptionStruct[ii].oneline == 1)

                    DisplayOneLineTry(ii);
            }
        }

        public void DisplayOneLineTry(int ii)
        {
            var token = ExceptionStruct[ii].token;

            var table = token >> 24;

            var tablerow = token & 0xffffff;

            var typename = "";

            if (table == 2)

                typename = typedefnames[tablerow];

            if (table == 1)

                typename = typerefnames[tablerow];

            Console.Write(CreateSpaces(spacesforrest + 2 + spacesfortry + spacesfornested));

            Console.Write(".try IL_{0} to", ExceptionStruct[ii].tryoffset.ToString("x4"));

            var end = ExceptionStruct[ii].tryoffset + ExceptionStruct[ii].trylength;

            Console.Write(" IL_{0} ", end.ToString("x4"));

            if (ExceptionStruct[ii].flags == 0)

                Console.Write("catch {0} handler ", typename);

            else if (ExceptionStruct[ii].flags == 2)

                Console.Write("finally handler ");

            else if (ExceptionStruct[ii].flags == 4)

                Console.Write("fault handler ");

            else

                Console.Write("filter IL_{0} handler ", token.ToString("x4"));

            Console.Write("IL_{0} to", ExceptionStruct[ii].handleroffset.ToString("x4"));

            var end1 = ExceptionStruct[ii].handleroffset + ExceptionStruct[ii].handlerlength;

            Console.WriteLine(" IL_{0}", end1.ToString("x4"));

            Console.Write(CreateSpaces(spacesforrest + spacesfortry + spacesfornested + 2));

            Console.Write(DisplayExceptionBytes(ii));

            ExceptionStruct[ii].oneline = 0;
        }

        public void DisplayFinalBytes(int ii, string returnstring)
        {
            var index = CustomAttributeStruct[ii].value;

            int howmanybytes, uncompressedbyte;

            howmanybytes = CorSigUncompressData(blob, index, out uncompressedbyte);

            index = index + howmanybytes;

            var blobarray = new byte[uncompressedbyte];

            Array.Copy(blob, index, blobarray, 0, uncompressedbyte);

            var displayoneline = true;

            var displaystring = "";

            for (var jj = 0; jj < uncompressedbyte; jj++)
            {
                if (blobarray[jj] < 0x20)

                    displayoneline = false;

                if (blobarray[jj] >= 0x7f)

                    displayoneline = false;
            }

            var countascii = 0;

            for (var jj = 0; jj < uncompressedbyte; jj++)
            {
                if (blobarray[jj] >= 0x20 && blobarray[jj] <= 0x7f)

                    countascii++;
            }

            if (displayoneline)
            {
                displaystring = " = \"";

                for (var jj = 0; jj < uncompressedbyte; jj++)
                {
                    displaystring = displaystring + (char)blobarray[jj];
                }

                displaystring = displaystring + "\"";

                Console.WriteLine(displaystring);
            }

            else
            {
                var startoffunctionclosebracket = returnstring.LastIndexOf(")");

                var startoflastopenbracket = returnstring.Length - 1;

                var lastenter = returnstring.LastIndexOf("\r\n");

                var firstenter = returnstring.IndexOf("\r\n");

                var firstopenbracket = returnstring.IndexOf("(");

                if (lastenter == -1)

                    lastenter = -2;

                var diff2 = startoffunctionclosebracket - lastenter + 19;

                Console.Write(" = ( ");

                DisplayFormattedColumns(CustomAttributeStruct[ii].value, diff2, false, false);
            }
        }

        public void DisplayFinalCustomAttributes()
        {
            if (CustomAttributeStruct == null)

                return;

            for (var ii = 1; ii < CustomAttributeStruct.Length; ii++)
            {
                var parentcodedtablename = GetHasCustomAttributeTable(CustomAttributeStruct[ii].parent);

                var parentcodedindex = GetHasCustomAttributeValue(CustomAttributeStruct[ii].parent);

                var typecodetable = GetCustomAttributeTypeTable(CustomAttributeStruct[ii].type);

                var typecodedindex = GetCustomAttributeTypevalue(CustomAttributeStruct[ii].type);

                var typeindexofmethod = GetTypeForMethod(parentcodedindex);

                var typeindexforfield = GetTypeForField(parentcodedindex);

                if (parentcodedtablename == "Property")
                {
                }

                if (parentcodedtablename == "FieldDef" && GetString(TypeDefStruct[typeindexforfield].name) == "_Deleted")
                {
                    var returnstring = "  .custom /*0C" + ii.ToString("X6") + "*/ (UNKNOWN_OWNER/*040000" +
                                       parentcodedindex.ToString("X2");

                    returnstring = returnstring + "*/ ) instance void ";

                    var typerefindex = MemberRefStruct[typecodedindex].clas >> 3;

                    var typerefname = typerefnames[typerefindex];

                    returnstring = returnstring + typerefname + "::" +
                                   NameReserved(GetString(MemberRefStruct[typecodedindex].name)) + "(";

                    returnstring = returnstring + methodrefparamarray1[typecodedindex] + ") /* 0A0000" +
                                   typecodedindex.ToString("X2") + " */";

                    Console.Write(returnstring);

                    DisplayFinalBytes(ii, returnstring);
                }

                if (parentcodedtablename == "TypeDef" && GetString(TypeDefStruct[parentcodedindex].name) == "_Deleted")
                {
                    var returnstring = "  .custom /*0C" + ii.ToString("X6") + "*/ (" +
                                       GetString(TypeDefStruct[parentcodedindex].nspace) + "." +
                                       GetString(TypeDefStruct[parentcodedindex].name);

                    returnstring = returnstring + "/* 020000" + parentcodedindex.ToString("X2") + " *//*020000" +
                                   parentcodedindex.ToString("X2") + "*/ ) instance void ";

                    var typerefindex = MemberRefStruct[typecodedindex].clas >> 3;

                    var typerefname = typerefnames[typerefindex];

                    returnstring = returnstring + typerefname + "::" +
                                   NameReserved(GetString(MemberRefStruct[typecodedindex].name)) + "() /* 0A0000" +
                                   typecodedindex.ToString("X2") + " */";

                    Console.Write(returnstring);

                    DisplayFinalBytes(ii, returnstring);
                }

                if (parentcodedtablename == "MethodDef" && GetString(TypeDefStruct[typeindexofmethod].name) == "_Deleted")
                {
                    var methodtype = "";

                    if (GetString(MethodStruct[parentcodedindex].name) != "Main")

                        methodtype = methoddeftypearray[typeindexofmethod];

                    if (GetString(MethodStruct[parentcodedindex].name) == "InitializeComponent")

                        methodtype = "instance ";

                    Console.Write("  .custom /*0C{0}*/ (method {1}void ", ii.ToString("X6"), methodtype,
                                  methoddefreturnarray[typeindexofmethod]);

                    Console.Write("{0}.{1}/* 02{2}", GetString(TypeDefStruct[typeindexofmethod].nspace),
                                  GetString(TypeDefStruct[typeindexofmethod].name), typeindexofmethod.ToString("X6"));

                    Console.Write(" */::{0}() /* 060000{1} *//*060000{1}*/ ) ",
                                  GetString(MethodStruct[parentcodedindex].name), parentcodedindex.ToString("X2"));

                    var typerefindex = MemberRefStruct[typecodedindex].clas >> 3;

                    var typerefname = typerefnames[typerefindex];

                    Console.Write("instance void {1}::{2}() /* 0A0000{3} */ = ( 01 00 00 00 ) ",
                                  methoddefreturnarray[typeindexofmethod], typerefname, ".ctor",
                                  typecodedindex.ToString("X2"));

                    Console.WriteLine();
                }
            }
        }
    }
}
