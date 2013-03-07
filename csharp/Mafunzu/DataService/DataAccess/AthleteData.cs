using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.Model;

namespace DataService.DataAccess
{
    public class AthleteData
    {

        public Athlete Athlete { get; set; }
        private List<Run> _runs;

        

        public List<Run> Runs
        {
            get { return _runs; }

            set
            {
                foreach (var run in value)
                {
                    run.Athlete = null;
                    if(run.Shoe!=null)
                    {
                        run.Shoe.Athlete = null;
                    }
                }
                _runs = value;
            }
        }

        public string UniqueID
        {
            
            get
            {
                var now = DateTime.Now;
                return string.Format("athlete_id_{0}_{1}_{2}_{3}_{4}_{5}", Athlete.ID, now.Year, now.Month, now.Day, now.Hour, now.Minute);
            }
        }
    }
}
