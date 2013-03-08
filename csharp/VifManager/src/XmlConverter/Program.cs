using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace dk.magnus.xml
{

    class XmlConverter
    {
        public XmlConverter()
        {
            
        }   
  
        void ReadXml(IEnumerable<string> lines)
        {
            
        }
    }

    class IgnoreCaseComparer : IEqualityComparer<string>
    {
        public static readonly IgnoreCaseComparer Default = new IgnoreCaseComparer();

        public bool Equals(string x, string y)
        {
            return string.Equals(x, y, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }

    class Program
    {
        
        private const string path = "Aarsafslut.xml";
        private const string separator = "=================================================================================================";
        static void Main(string[] args)
        {
            var text = File.ReadAllText(path);
            var xDoc = XDocument.Parse(text);

            var search = @"..\..\KernelEx".ToLower();
            var list = new List<string>();
            list.Add(separator);
            list.Add(separator);

            Predicate<XElement> containsSearchText = x => x.Value.ToLower().Contains(search);
            List<XElement> elements; 
            foreach (var element in xDoc.Descendants())
            {
                foreach (var findElement in FindElements(element, containsSearchText))
                {
                    list.Add(string.Format("Name: [{0}], Value: [{1}]", findElement.Name.LocalName, findElement.Value));
                }
            }

            list.Add(separator);
            list.Add(separator);


            var txt = "elements.txt";
            File.WriteAllLines(txt,list);
            Console.WriteLine("Ok, elements written to [{0}]", txt);
            Console.ReadKey();
        }

        static IEnumerable<XElement> FindElements(XElement element, Predicate<XElement>  isSearched)
        {
            if (element.HasElements)
            {
                foreach (var subElement in element.Descendants().SelectMany(child => FindElements(child,isSearched)))
                {
                    yield return subElement;
                }
            }
            else
            {
                if (isSearched(element))
                {
                    yield return element;
                }
            }

        }

        static IEnumerable<string> DumpXml(XElement property)
        {
            yield return property.Name.LocalName;
            if (property.HasElements)
            {
                foreach (var e in property.Descendants().SelectMany(DumpXml))
                {
                    yield return e;
                }
            }
            else
            {
                yield return "Value: " + property.Value;
            }
        }
    }
}
