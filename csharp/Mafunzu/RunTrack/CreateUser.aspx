<%@ Page Language="C#" %>
<%@ Import Namespace="DataService.DataAccess" %>

<script runat="server">

    void CreateClick(object sender, EventArgs e)
    {
        const string redirectUrl = "/";
        try
        {
            UserDataAccess userDataAccess = new UserDataAccess();
            string email = UserEmail.Text;
            if (userDataAccess.TryFindByEmail(email) != null)
            {
                DataService.Error.UserExistsException(email);
            }
            userDataAccess.CreateUserWithDefaultAthlete(email, UserPass.Text);
            Response.Redirect(redirectUrl);
        }
        catch (Exception exception)
        {
            Msg.Text = "Brugeren kunne ikke oprettes [" + exception.Message + "]";
        }
    }

</script>

<html>
<head id="Head1" runat="server">
    <title>Opret ny bruger</title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        Opret ny bruger</h1>
    <table width="600">
        <tr>
            <td colspan="3">
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <hr height="1px">
            </td>
        </tr>
        <tr>
            <td>
                E-mail:
            </td>
            <td>
                <asp:TextBox ID="UserEmail" runat="server" value="" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="UserEmail"
                    Display="Dynamic" ErrorMessage="Cannot be empty." runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Password:
            </td>
            <td>
                <asp:TextBox ID="UserPass" TextMode="Password" runat="server" value="" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="UserPass"
                    ErrorMessage="Cannot be empty." runat="server" />
            </td>
        </tr>
    </table>
    <asp:Button ID="Submit1" OnClick="CreateClick" Text="Opret mig" runat="server" />
    <p>
        <asp:Label ID="Msg" ForeColor="red" runat="server" /></p>
    </form>
</body>
</html>
