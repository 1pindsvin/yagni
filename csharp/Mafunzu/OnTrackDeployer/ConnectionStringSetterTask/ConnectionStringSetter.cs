using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using NAnt.Core.Attributes;

namespace ConnectionStringSetterTask
{
    [TaskName("connectionStringSetter")]
    public class ConnectionStringSetter : NAnt.Core.Task
    {
        protected override void ExecuteTask()
        {
            var xDoc = XDocument.Load(FileName);
            var element =
                xDoc.Descendants().
                Where(x => x.Attributes().
                       Where(attr => attr.Name == "name" && attr.Value == ConnectionStringName).
                       SingleOrDefault() != null).
                Single();

                element.SetAttributeValue("connectionString", NewConnectionString);
            xDoc.Save(FileName);
            Log(
                NAnt.Core.Level.Info, 
                string.Format("[{0}] changed to [{1}]", 
                ConnectionStringName, NewConnectionString));
        }

        [TaskAttribute("fileName", Required = true)]
        [StringValidator(AllowEmpty = false)]
        public string FileName { get; set; }

        [TaskAttribute("connectionStringName", Required = true)]
        [StringValidator(AllowEmpty = false)]
        public string ConnectionStringName { get; set; }

        [TaskAttribute("newConnectionString", Required = true)]
        [StringValidator(AllowEmpty = false)]
        public string NewConnectionString { get; set; }
    }
}
