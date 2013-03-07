using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Model
{
    public enum ActivityType
    {
        None = 0,
        Running = 1,
        Biking = 2,
        Other = 1073741824 //2^30
    }
}
