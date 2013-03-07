using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Model
{
    public class PagingData
    {
        public int PageSize { get; set; }
        public int PageOffset { get; set; }
        public int TotalCount { get; set; }
        public bool RequestsLastPage { get; set; }
    }
}
