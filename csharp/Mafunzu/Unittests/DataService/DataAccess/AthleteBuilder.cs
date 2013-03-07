using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.Model;

namespace DataService.DataAccess
{
    public class AthleteBuilder
    {
        public Athlete Build()
        {
            var user = new User {UserName = "mafunzu@gmail.com", ID = 10};

            var dateOfBirth = DateTime.MinValue;
            var athlete =
                new Athlete
                              {
                                  DateOfBirth = dateOfBirth,
                                  FirstName = "Gryffe",
                                  ID = 1,
                                  LastName = null,
                                  User = user,
                              };
            return athlete;
        }
    }
}
