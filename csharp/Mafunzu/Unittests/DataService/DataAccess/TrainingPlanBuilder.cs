using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.Model;

namespace DataService.DataAccess
{
    public class TrainingPlanBuilder
    {
        private Athlete _athlete;
        private int _ID;

        public TrainingPlanBuilder()
        {
            _ID = 1;
            _athlete = null;
        }
        public TrainingPlan Build()
        {
            var plan = new TrainingPlan {Goal = new Goal(), ID = _ID};
            return plan;
        }

        public TrainingPlan WithAthlete()
        {
            _athlete = new AthleteBuilder().Build();
            var plan = Build();
            plan.Athlete = _athlete;
            return plan;
        }



    }
}
