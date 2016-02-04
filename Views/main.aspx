<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Connection.Views.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 324px">
    
        username:&nbsp;
    
        <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
        <br />
        password:&nbsp;
        <asp:TextBox ID="txt_pass" runat="server" style="margin-bottom: 0px"></asp:TextBox>
        <asp:Button ID="btn_confirm" runat="server" OnClick="btn_confirm_Click" Text="Confirm" />
    
        <asp:Button ID="btn_NewUser" runat="server" OnClick="btn_NewUser_Click" style="height: 26px" Text="New user" />
    
        <br />
        <asp:Label ID="lbl_res" runat="server"></asp:Label>
    
        <asp:SqlDataSource ID="UserDB" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [ID], [Name], [Password] FROM [User]"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
