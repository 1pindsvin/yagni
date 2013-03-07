using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace DataService.Model
{
    public partial class User : IPrincipal, IIdentity
    {
        public ulong RtVersion
        {
            get
            {
                return System.BitConverter.ToUInt64(Version.ToArray(), 0);
            }
            set
            {
                this.Version = System.BitConverter.GetBytes(value);
            }
        }

        bool IPrincipal.IsInRole(string role)
        {
            throw new System.NotImplementedException();
        }

        IIdentity IPrincipal.Identity
        {
            get { return this; }
        }

        string IIdentity.Name
        {
            get { return this.UserName; }
        }

        private const string NO_AUTHENTICATIONTYPE = "";

        string IIdentity.AuthenticationType
        {
            get
            {
                return NO_AUTHENTICATIONTYPE;
            }
        }

        private bool _isAuthenticated;

        bool IIdentity.IsAuthenticated
        {
            get { return _isAuthenticated; }
        }

        public void SetAuthenticated(bool value)
        {
            _isAuthenticated = value;     
        }

    }
}
