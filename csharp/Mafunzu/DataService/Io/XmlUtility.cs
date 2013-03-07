using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DataService.Io
{
    public static class XmlUtility
    {
        private static T LoadFromAssemblyResource<T>(string filename)
        {
            var assm = Assembly.GetExecutingAssembly();
            filename = assm.GetName().Name + "." + filename;
            using (var streamReader = new StreamReader(assm.GetManifestResourceStream(filename)))
            {
                var item = DeSerializeObject<T>(streamReader.BaseStream);
                return item;
            }
        }


        public static T DeSerializeObject<T>(Stream stream)
        {
            using (var reader = XmlReader.Create(stream))
            {
                return (T) (new XmlSerializer(typeof (T)).Deserialize(reader));
            }
        }

        public static T DeSerializeObject<T>(string fullyQualifiedFileName)
        {
            using (var reader = XmlReader.Create(fullyQualifiedFileName))
            {
                return (T) (new XmlSerializer(typeof (T)).Deserialize(reader));
            }
        }

        public static void SerializeObject(object anObject, string fullyQualifiedFileName)
        {
            var settings = new XmlWriterSettings {Encoding = Encoding.UTF8, NewLineChars = System.Environment.NewLine};
            using (var xmlWriter = XmlWriter.Create(fullyQualifiedFileName, settings))
            {
                new XmlSerializer(anObject.GetType()).Serialize(xmlWriter, anObject);
            }
        }


        public static String SerializeAsXml(Object pObject)
        {
            using (var xmlTextWriter = new XmlTextWriter(new MemoryStream(), Encoding.UTF8))
            {
                new XmlSerializer(pObject.GetType()).Serialize(xmlTextWriter, pObject);
                return Utf8ByteArrayToString(((MemoryStream) xmlTextWriter.BaseStream).ToArray());
            }
        }


        public static T DeSerializeXml<T>(String pXmlizedString)
        {
            using (var memoryStream = new MemoryStream(StringToUtf8ByteArray(pXmlizedString)))
            {
                return (T) new XmlSerializer(typeof (T)).Deserialize(memoryStream);
            }
        }


        public static String Utf8ByteArrayToString(Byte[] characters)
        {
            var encoding = new UTF8Encoding();
            var constructedString = encoding.GetString(characters);
            return (constructedString);
        }


        public static Byte[] StringToUtf8ByteArray(String pXmlString)
        {
            var encoding = new UTF8Encoding();
            var byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }
    }
}