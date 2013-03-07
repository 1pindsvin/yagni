using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Model
{
    public partial class DbDataContext : System.Data.Linq.DataContext
    {
        partial void DeleteRun(Run instance)
        {
            this.ExecuteDynamicDelete(instance);
        }
    }
}
