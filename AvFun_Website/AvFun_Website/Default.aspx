<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AvFun_Website.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <div id="unloginDiv" runat="server">
    <asp:HyperLink ID="urlLogin" runat="server" NavigateUrl="~/Login.aspx" 
            Target="_self">登录</asp:HyperLink>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/NewUser.aspx" 
        Target="_self">注册</asp:HyperLink>    
    </div>
    <div id="loginDiv" runat="server">
        <asp:Label ID="WelcomeInfo1" runat="server" Text="亲爱的"></asp:Label>
        <asp:Label ID="loggedUserNickname" runat="server"></asp:Label>
        <asp:Label ID="WelcomeInfo2" runat="server" Text="大人，欢迎回来！"></asp:Label>
        <asp:LinkButton ID="btnLogout" runat="server">登出</asp:LinkButton>
&nbsp;<asp:HyperLink ID="urlUserIndex" runat="server" 
            NavigateUrl="~/user_pages/user_index.aspx" Target="_self">用户中心</asp:HyperLink>
    </div>
    </form>
</body>
</html>
