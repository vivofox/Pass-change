<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PassChange.aspx.cs" Inherits="Connection.Views.PassChange" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 245px">
    <form id="form1" runat="server">
    <div>
    
        old password:<asp:TextBox ID="txtOldPass" runat="server" Height="19px" style="margin-left: 62px"></asp:TextBox>
    
    </div>
        new password:<asp:TextBox ID="txtNewPass" runat="server" style="margin-left: 54px"></asp:TextBox>
        <br />
        confirm password:<asp:TextBox ID="txtConfirmPass" runat="server" style="margin-left: 33px"></asp:TextBox>
        <asp:Label ID="lbl_changePass" runat="server"></asp:Label>
        <asp:Button ID="ButtonChangePass" runat="server" style="margin-left: 47px" Text="Change password" OnClick="ButtonChangePass_Click" />
    </form>
</body>
</html>
