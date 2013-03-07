using System;
using System.Linq;
using DataService.Model;
using DataService.Properties;

namespace DataService.DataAccess
{
    public class UserDataAccess
    {

        internal static Func<IDataContext> ResolveDataContext = () => new DataContextAdapter(new DbDataContext());

        private IDataContext DataContext { get; set; }

        public UserDataAccess()
        {
            DataContext = ResolveDataContext();       
        }

        public UserDataAccess(IDataContext dataContext)
        {
            DataContext = dataContext;
        }

        public User FindByUserNameAndPassword(string userName, string password)
        {
            var user = DataContext.Queryable<User>().
                Where(target => target.UserName.Equals(userName)
                                && target.Password.Equals(password)).FirstOrDefault();
            return user;
        }

        public User TryFindByEmail(string email)
        {
            return DataContext.Queryable<User>().
                Where(x => x.UserName.ToLower() == email.ToLower()).
                FirstOrDefault();
        }



        public User FindByEmail(string email)
        {
            return DataContext.Queryable<User>().
                Where(x => x.UserName.ToLower() == email.ToLower()).
                Single();
        }

        public User Save(User user)
        {
            DataContext.UpdateAndAttach(user);
            DataContext.Commit();
            return user;
        }

        public User CreateUserWithDefaultAthlete(string emailAsUserName, string password)
        {
            var user = new User {Password = password, UserName = emailAsUserName};
            DataContext.InsertOnSubmit(user);
            DataContext.Commit();
            user.CustomerID = user.ID.ToString();
            DataContext.Commit();

            var athlete = new Athlete {User = user};
            DataContext.InsertOnSubmit(athlete);
            DataContext.Commit();

            return user;
        }

        public static void SetConnectionString(string connectionString)
        {
            //Hack, should not touch Settings (setters) from code
            Settings.Default.RunTrackConnectionString = connectionString;
        }

        public static string GetConncetionInfo()
        {
            using (var db = new DbDataContext())
            {
                var conncetionInfo = string.Format("Connectionstring [{0}]", Settings.Default.RunTrackConnectionString);
                return conncetionInfo;
            }
        }
    }
}