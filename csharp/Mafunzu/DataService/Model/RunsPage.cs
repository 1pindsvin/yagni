using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Model
{
    public class RunsPage
    {
        public bool RequestsLastPage { get; set; }
        public bool Ascending { get; set; }
        public DateTime? ByDateTime { get; set; }
        public int Start { get; set; }
        public int Page { get; set; }
        public int RunCount { get; set; }
        public string OrderByExpression { get; set; }
        public Athlete Athlete { get; set; }
        public List<Run> Runs { get; set; }
    }
}
