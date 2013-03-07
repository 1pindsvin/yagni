using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Model
{
    public class WorkoutQuery
    {
        public PagingData PagingData { get; set; }
        public DateTime? Before { get; set; }
        public DateTime? After { get; set; }
        public Athlete Athlete { get; set; }
        public int WorkoutTypes { get; set; }
        public List<Workout> Workouts { get; set; }
    }
}
