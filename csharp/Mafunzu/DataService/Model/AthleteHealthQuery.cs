using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Model
{
    public class AthleteHealthQuery
    {
        public PagingData PagingData { get; set; }
        public Athlete Athlete { get; set; }
        public List<AthleteHealth> AthleteHealthHistory { get; set; }
    }
}
