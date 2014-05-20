<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_login.aspx.cs" Inherits="AvFun_Website.admin.admin_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ご、ご主人様！お帰り！管理员登录</title>
<script language="javascript" type="text/javascript">
        function GetImgCode() {
            var ImgCode = document.getElementById("imgAdminVerifyCode");
            ImgCode.src = "LoginVerifyCodeGenerator.ashx";
        } 
</script>
</head>
<body>
    <asp:Label ID="AdminLoginStatus" runat="server" Text=""></asp:Label>
    <form id="AdminLoginForm" runat="server">
    <div>
    
        <asp:Label ID="lblAdminAccount" runat="server" Text="管理员账号："></asp:Label>
        <asp:TextBox ID="txtAdminAccount" runat="server" MaxLength="64"></asp:TextBox>
        <asp:RequiredFieldValidator ID="adminAccountRequired" runat="server" 
            ControlToValidate="txtAdminAccount" ErrorMessage="RequiredFieldValidator">*请填写管理员账号</asp:RequiredFieldValidator>
        <br />
        <asp:RegularExpressionValidator ID="adminAccountRegular" runat="server" 
            ControlToValidate="txtAdminAccount" 
            ErrorMessage="RegularExpressionValidator" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">管理员账号格式不正确，请重新填写</asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="lblAdminPassword" runat="server" Text="管理员密码："></asp:Label>
        <asp:TextBox ID="txtAdminPassword" runat="server" MaxLength="16" 
            TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="adminPasswordRequired" runat="server" 
            ControlToValidate="txtAdminPassword" ErrorMessage="RequiredFieldValidator">*请填写管理员密码</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblVerifyCode" runat="server" Text="验证码："></asp:Label>
        <asp:TextBox ID="txtAdminVerifyCode" runat="server" MaxLength="5"></asp:TextBox>
        <asp:Image ID="imgAdminVerifyCode"  src="AdminLoginVerifyCodeGenerator.ashx" runat="server" />
        <A href="javascript:GetImgCode()">刷新验证码</A>
        <asp:RequiredFieldValidator ID="adminloginVerifyCodeRequired" runat="server" 
            ControlToValidate="txtAdminVerifyCode" ErrorMessage="RequiredFieldValidator">*请填写验证码</asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="登录"/>
    
    </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
