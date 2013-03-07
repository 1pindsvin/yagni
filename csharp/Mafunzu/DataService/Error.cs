using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace DataService
{
    public class Error
    {
        internal static Exception ObjectIdShouldNotBeZero(object instance)
        {
            var message = "Expected ID set on instance [" + instance.GetType().Name + "]";
            throw new InvalidOperationException(message);
        }

        public static void UserNotFoundException(string userid)
        {
            var message = "User [" + userid + "] not found";
            throw new SecurityException(message);
        }

        public static void UserExistsException(string username)
        {
            var message = "User [" + username + "] exists in RunTrack";
            throw new InvalidOperationException(message);
        }

        public static void NotImplementedException(string context)
        {
            throw new NotImplementedException(context);
        }
    }
}
