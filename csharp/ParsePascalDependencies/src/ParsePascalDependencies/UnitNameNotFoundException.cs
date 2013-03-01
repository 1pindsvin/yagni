using System.Linq;
using System.Collections.Generic;
using System;

namespace ParsePascalDependencies
{
    class UnitNameNotFoundException : Exception
    {
        public UnitNameNotFoundException(string path)
            : base(string.Format("Could not resolve name of unit. Path [{0}]", path ?? "Path not found- this sucks big time"))
        {
            this.Path = path ?? "Path not found- this sucks big time";
        }

        public string Path
        {
            get; private set; 
        }
    }
}