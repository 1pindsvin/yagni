using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using DataService.DataAccess;
using DataService.Io;

namespace RunTrack
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["RunTrackDb"].ConnectionString;
            UserDataAccess.SetConnectionString(connectionString);

            var downloadpath = Context.Request.ApplicationPath + "/Download"; 
            RunTrackEnvironment.FullyQualifiedDownloadDirectoryUrl = downloadpath;
            RunTrackEnvironment.MappedFullyQualifiedDownloadDirectory = Server.MapPath(downloadpath);

            var config = new Weborb.Config.ORBConfig();
            var server = new Weborb.Messaging.RTMPServer("default", 2037, 500, config);
            server.start();
            Application["weborbMessagingServer"] = server;
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            //When application uses Forms Authentication, it creates FormsIdentity along 
            // with the FormsAuthenticationTicket. The API call below establishes WebORB 
            // principal for the current Forms Authentication request. As a result, 
            // WebORB security can leverage the same user identity created through
            // Forms Authentication
            Weborb.Security.ORBSecurity.AuthenticateRequest();
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Weborb.Messaging.RTMPServer server = (Weborb.Messaging.RTMPServer)Application["weborbMessagingServer"];

            if (server != null)
                server.shutdown();

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}