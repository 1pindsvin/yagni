using System;
using DataService.DataAccess;
using DataService.Model;

namespace DataService.Security
{
    public class SecurityService
    {
        private readonly UserDataAccess _dataAccess;

        public SecurityService()
        {
            _dataAccess = new UserDataAccess();
        }

        public User AuthenticateUser(string userName, string password)
        {
            if (userName == null)
            {
                throw new ArgumentNullException("userName");
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            var user = _dataAccess.FindByUserNameAndPassword(userName, password);
            if (user != null)
            {
                user.SetAuthenticated(true);
            }
            return user;
        }

        public void LogoutUser(User user)
        {
            user.SetAuthenticated(false);
        }
    }
}