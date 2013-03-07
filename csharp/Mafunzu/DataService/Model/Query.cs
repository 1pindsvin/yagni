using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Model
{
    public class Query<T>   
    {
        public DateTime? After { get; set; }
        public DateTime? Before { get; set; }
        public Athlete Athlete { get; set; }
        public List<T> Items { get; set; }
        public PagingData PagingData { get; set; }
    }
}
