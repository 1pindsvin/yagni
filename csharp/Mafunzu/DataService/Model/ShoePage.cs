using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Model
{
    public class ShoePage
    {
        public bool RequestsLastPage { get; set; }
        public int Start { get; set; }
        public int PageSize { get; set; }
        public int ShoeCount { get; set; }
        public bool Active { get; set; }
        public Athlete Athlete { get; set; }
        public List<Shoe> Shoes { get; set; }
    }
}
