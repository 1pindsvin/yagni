using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text;


namespace DataService.Model
{
    public partial class Run
    {
        public ulong RtVersion
        {
            get
            {
                return System.BitConverter.ToUInt64(Version.ToArray(), 0);
            }
            set
            {
                this.Version = System.BitConverter.GetBytes(value);
            }
        }


    }
}
