<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AvFun_Website.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<script language="javascript" type="text/javascript">
    function GetImgCode() {
        var ImgCode = document.getElementById("imgLoginVerifyCode");
        ImgCode.src = "LoginVerifyCodeGenerator.ashx";
    } 
</script>
<body>
    <asp:Label ID="LoginInfo" runat="server" Text=""></asp:Label>
    <form id="LoginForm" runat="server">
    <div>
    
        <asp:Label ID="lblUserName" runat="server" Text="登录邮箱"></asp:Label>
        <asp:TextBox ID="UserAccount" runat="server" MaxLength="64"></asp:TextBox>
        <asp:HyperLink ID="urlReg" runat="server" NavigateUrl="~/NewUser.aspx" 
            Target="_blank">注册</asp:HyperLink>
        <asp:RequiredFieldValidator ID="UserAccountRequire" runat="server" 
            ControlToValidate="UserAccount">*请填写您的注册邮箱</asp:RequiredFieldValidator>
        <br />
        <asp:RegularExpressionValidator ID="UserAccountRegular" runat="server" 
            ControlToValidate="UserAccount" ErrorMessage="RegularExpressionValidator" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*邮箱格式不正确，请检查</asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="lblPassword" runat="server" Text="密码："></asp:Label>
        <asp:TextBox ID="UserPassword" runat="server" MaxLength="16" 
            TextMode="Password"></asp:TextBox>
        <asp:HyperLink ID="urlForgetPassword" runat="server" Target="_blank" 
            NavigateUrl="~/ForgetPassword.aspx">忘记密码？</asp:HyperLink>
        <asp:RequiredFieldValidator ID="UserPasswordRequire" runat="server" 
            ControlToValidate="UserPassword">*请填写密码</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblVerifyCode" runat="server" Text="验证码"></asp:Label>
        <asp:TextBox ID="LoginVerifyCode" runat="server" MaxLength="5"></asp:TextBox>
        <asp:Image ID="imgLoginVerifyCode" src="LoginVerifyCodeGenerator.ashx" runat="server" />
        <A href="javascript:GetImgCode()">刷新验证码</A>
        <asp:RequiredFieldValidator ID="LoginVerifyCodeRequire" runat="server" 
            ControlToValidate="LoginVerifyCode">*请填写验证码（不区分大小写）</asp:RequiredFieldValidator>
        <br />
        <asp:CheckBox ID="RememberMe" runat="server" Text="下次免登陆" />
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="登录" />
    
    </div>
    </form>
</body>
</html>
