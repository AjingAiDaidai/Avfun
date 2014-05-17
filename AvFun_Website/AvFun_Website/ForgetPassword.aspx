<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="AvFun_Website.ForgetPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <asp:Label ID="ForgetPswInfo" runat="server" Text="请输入注册邮箱："></asp:Label>
    <form id="ForgetPasswordForm" runat="server">
    <br />
    <asp:Label ID="lblUserAccount" runat="server" Text="注册邮箱："></asp:Label>
    <asp:TextBox ID="UserAccount" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="UserAccountRequire" runat="server" 
        ControlToValidate="UserAccount">*请填写您的注册邮箱</asp:RequiredFieldValidator>
    <br />
    <asp:RegularExpressionValidator ID="UserAccountExpression" runat="server" 
        ControlToValidate="UserAccount" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*邮箱格式不正确，请检查</asp:RegularExpressionValidator>
    <div>
    
        <asp:Button ID="btnGetPassword" runat="server" Text="找回密码" />
    
    </div>
    </form>
</body>
</html>
