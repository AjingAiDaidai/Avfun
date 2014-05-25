<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_changeInfo.aspx.cs" Inherits="AvFun_Website.admin.admin_changeInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:Label ID="lblLoginStatus" runat="server"></asp:Label>
    <form id="LoggedForm" runat="server">
    <div>
        <asp:Label ID="lblChangeInfo" runat="server" 
            Text="若不想修改密码，以下三项请留空，修改密码将导致需要重新登录"></asp:Label>
        <br />
    <hr runat="server" />
        <br />
        <asp:Label ID="lblOldPassword" runat="server" Text="旧密码："></asp:Label>
        <asp:TextBox ID="txtOldPassword" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblNewPassword" runat="server" Text="新密码："></asp:Label>
        <asp:TextBox ID="txtNewPassword" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblVerifyNewPassword" runat="server" Text="确认新密码："></asp:Label>
        <asp:TextBox ID="txtVerifyNewPassword" runat="server"></asp:TextBox>
    <hr runat="server" />
        <asp:Label ID="lblNickname" runat="server" Text="用户昵称："></asp:Label>
        <asp:TextBox ID="txtAdminNickname" runat="server"></asp:TextBox>
        <br />
        <asp:LinkButton ID="btnChangePassword" runat="server">修改</asp:LinkButton>
    </div>
    </form>
</body>
</html>
