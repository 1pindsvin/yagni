using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weborb.Message;
using Weborb.Security;
using System.Security.Principal;
using DataService.DataAccess;
using DataService.Model;

namespace DataService.Security
{

    public class SecurityHandler : Weborb.Security.IAuthenticationHandler
    {

        private readonly UserDataAccess _userDataAccess;

        public SecurityHandler()
        {
            _userDataAccess = new UserDataAccess();
        }


        public IPrincipal CheckCredentials(string userid, string password, Request message)
        {
            var user = _userDataAccess.FindByUserNameAndPassword(userid, password);
            if (user==null)
            {
                Error.UserNotFoundException(userid);
            }
            return user;
        }
    }
}
