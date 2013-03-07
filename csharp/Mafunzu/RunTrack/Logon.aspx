<%@ Page Language="C#" %>
<%@ Import Namespace="Weborb.Security" %>
<%@ Import Namespace="Weborb.Config" %>


<script runat="server">
  /*
  This is a sample logon page demonstrating the usage of Windows Forms Authentication
  with WebORB. To enable Forms Authentication, change the authentication node in web.config 
  as shown below:
  
    <authentication mode="Forms">
        <forms loginUrl="Logon.aspx" name=".ASPXFORMSAUTH">
        </forms>    
    </authentication>  
    
  Additionally, adjust authorization settings to allow/deny users access. For example,
  to deny access to any unauhorized user, enter the following:
  
    <authorization>
       <deny users="?" />
    </authorization>  
  */
  void Logon_Click(object sender, EventArgs e)
  {
      // initialize weborb config
     //ORBConfig orbConfig = new ORBConfig( new string[] {"security", "acl"} );
     
     
     // get reference to security
     ORBSecurity orbSecurity = ORBConfig.GetInstance().getSecurity();
     
     // get auth. handler from the security module
     IAuthenticationHandler authHandler = orbSecurity.GetAuthenticationHandler();
     
     // this is where the user will be redirected to upon successful authentication.
     // The URL is any page with your Flex/Flash movie in it.
     String redirectURL = "examples/flex/remoting/setcredentials/index.htm";
     
     try
     {
       // Check credentials using pre-configured authentication handler.
       // If authentication fails, the handler will throw exception
       authHandler.CheckCredentials( UserEmail.Text, UserPass.Text, null );
       
       // If user has been authenticated, let weborb handle forms authentication bootstrap
       orbSecurity.DoFormsAuthentication( 
                    UserEmail.Text,   // userid
                    30,               // how long should the session last
                    redirectURL,      // where to redirect the user to. THIS IS A PAGE WITH YOUR FLEX/FLASH SWF
                    Persist.Checked,  // whether the forms auth cookie should be persisted
                    Response );       // response object
     }
     catch( Exception )
     {
        Msg.Text = "Invalid credentials. Please try again.";
     }
     
  }
</script>
<html>
<head id="Head1" runat="server">
  <title>Forms Authentication with WebORB - Login</title>
</head>
<body>
  <form id="form1" runat="server">
    <h1>Forms Authentication with WebORB</h1>
    <h3>Logon Page</h3>
    <table width="600">
      <tr>
      <td colspan="3">
This is a sample logon page demonstrating the usage of Windows Forms Authentication with WebORB. To enable Forms Authentication, change the authentication node in web.config as shown below:
<pre>
    &lt;authentication mode="Forms"&gt;
        &lt;forms loginUrl="Logon.aspx" name=".ASPXFORMSAUTH"&gt;
        &lt;/forms&gt;  
    &lt;/authentication&gt;</pre>
    
Additionally, adjust authorization settings to allow/deny users access. For example, to deny access to any unauhorized user, enter the following:
<pre>
    &lt;authorization&gt;
       &lt;deny users="?" /&gt;
    &lt;/authorization&gt;</pre>
The user credentials are validated by authentication handler configured in weborb.config. The default implementation uses the ACL matrix from weborb.config as well. If the credentials are valid, WebORB creates Forms Authentication ticket and forwards the request to the designated URL. When authentication ticket is present, WebORB creates a principal object with the identity of the logged in user (see Application_AuthenticateRequest in Global.asax). The principal performs the role checks against the roles provider configured in weborb.config.
      </td>
      </tr>
      <tr><td colspan="3"><hr height="1px" ></td></tr>
      <tr>
        <td>E-mail address:</td>
        <td><asp:TextBox ID="UserEmail" runat="server" value="testuser" /></td>
        <td>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
            ControlToValidate="UserEmail"
            Display="Dynamic" 
            ErrorMessage="Cannot be empty." 
            runat="server" />
        </td>
      </tr>
      <tr>
        <td>Password:</td>
        <td><asp:TextBox ID="UserPass" TextMode="Password" runat="server" value="password" /></td>
        <td>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
            ControlToValidate="UserPass"
            ErrorMessage="Cannot be empty." 
            runat="server" />
        </td>
      </tr>
      <tr>
        <td>Remember me?</td>
        <td><asp:CheckBox ID="Persist" runat="server" /></td>
      </tr>
    </table>
    <asp:Button ID="Submit1" OnClick="Logon_Click" Text="Log On" runat="server" />
    <p><asp:Label ID="Msg" ForeColor="red" runat="server" /></p>
  </form>
</body>
</html>