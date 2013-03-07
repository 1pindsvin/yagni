using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace DataService.Garmin
{
    public class XmlSanitizer
    {
        public string Sanitize(string xmlContent)
        {
            using (var stringWriter = new EncodingStringWriter(new StringBuilder(), Encoding.UTF8))
            {
                using (var noNamespaceWriter = new NamespaceStrippingXmlWriter(stringWriter))
                {
                    var doc = XDocument.Parse(xmlContent);
                    doc.WriteTo(noNamespaceWriter);
                    noNamespaceWriter.Flush();
                    var sanitizedXml = stringWriter.GetStringBuilder().ToString();
                    return sanitizedXml;
                }
            }
        }

        #region Nested type: EncodingStringWriter

        private class EncodingStringWriter : StringWriter
        {
            private readonly Encoding _encoding;

            public EncodingStringWriter(StringBuilder builder, Encoding encoding)
                : base(builder)
            {
                _encoding = encoding;
            }

            public override Encoding Encoding
            {
                get { return _encoding; }
            }
        }

        #endregion

        #region Nested type: NamespaceStrippingXmlWriter

        private class NamespaceStrippingXmlWriter : XmlTextWriter
        {
            private bool _skipAttribute;

            public NamespaceStrippingXmlWriter(System.IO.TextWriter writer)
                : base(writer)
            {
            }

            public override void WriteStartElement(string prefix, string localName, string ns)
            {
                base.WriteStartElement(null, localName, null);
            }


            public override void WriteStartAttribute(string prefix, string localName, string ns)
            {
                const string xmlns = "xmlns";
                _skipAttribute = prefix == xmlns || localName == xmlns || prefix == "xsi";
                if (!_skipAttribute)
                {
                    base.WriteStartAttribute(null, localName, null);
                }
            }

            public override void WriteString(string text)
            {
                if (!_skipAttribute)
                {
                    base.WriteString(text);
                }
            }

            public override void WriteEndAttribute()
            {
                if (!_skipAttribute)
                {
                    base.WriteEndAttribute();
                }
                _skipAttribute = false;
            }


            public override void WriteQualifiedName(string localName, string ns)
            {
                //Always write the qualified name using only the
                //localname.
                base.WriteQualifiedName(localName, null);
            }
        }

        #endregion
    }
}