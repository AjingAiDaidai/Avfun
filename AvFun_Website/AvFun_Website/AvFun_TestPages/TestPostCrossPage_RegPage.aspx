<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPostCrossPage_RegPage.aspx.cs" Inherits="AvFun_Website.AvFun_TestPages.TestPostCrossPage_PostPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post">
    <div>
    <asp:TextBox runat="server" ID="txtUserAccount"></asp:TextBox>&nbsp;
    <asp:TextBox runat="server"   ID="txtUserPassword"></asp:TextBox>&nbsp;
    <asp:Button runat="server"  ID="btnRegSubmit" 
            PostBackUrl="~/AvFun_TestPages/TestPostCrossPage_CreatePage.aspx" Text="注册新用户" 
            onclick="btnRegSubmit_Click"/>
    </div>
    </form>
</body>
</html>
