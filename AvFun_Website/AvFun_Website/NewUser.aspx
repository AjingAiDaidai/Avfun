<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewUser.aspx.cs" Inherits="AvFun_Website.NewUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<script language="javascript" type="text/javascript"> 
function GetImgCode() 
{
    var ImgCode = document.getElementById("imgVerifyCode");
    ImgCode.src = "RegVerifyCodeGenerator.ashx"; 
} 
</script>
<body>
    <asp:Label ID="RegResult" runat="server" Text=""></asp:Label>
    <form id="RegUser" runat="server">
    <div>        
        <br />
    
        <asp:Label ID="Label1" runat="server" Text="昵称："></asp:Label>
        <asp:TextBox ID="UserNickname" runat="server" MaxLength="32"></asp:TextBox>
        <asp:RequiredFieldValidator ID="userNicknameRequired" runat="server" 
            ControlToValidate="UserNickname">*昵称必填，长度1-32</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label2" runat="server" Text="密码："></asp:Label>
        <asp:TextBox ID="UserPassword" runat="server" MaxLength="16" 
            TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="userPasswordRequried" runat="server" 
            ControlToValidate="UserPassword">*密码必填，长度6-16</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label3" runat="server" Text="邮箱"></asp:Label>
        ：<asp:TextBox ID="UserAccount" runat="server" MaxLength="64"></asp:TextBox>
        <asp:RequiredFieldValidator ID="userAccountRequired" runat="server" 
            ControlToValidate="UserAccount">*邮箱必填，长度5-64</asp:RequiredFieldValidator>
        <br />
        <asp:RegularExpressionValidator ID="mailFormatCheck" runat="server" 
            ControlToValidate="UserAccount" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">邮箱格式不正确，请检查</asp:RegularExpressionValidator>
        <br />
        <br />
        性别：<asp:RadioButtonList ID="UserSex" runat="server" 
            RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="Male">男</asp:ListItem>
            <asp:ListItem Value="Female">女</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Label ID="Label4" runat="server" Text="个人简介："></asp:Label>
        <asp:TextBox ID="UserIntroduction" runat="server" Height="64px" TextMode="MultiLine" 
            Width="249px" MaxLength="256"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="验证码："></asp:Label>
        <asp:TextBox ID="RegVerifyCode" runat="server" MaxLength="5"></asp:TextBox>
        <asp:Image ID="imgVerifyCode" src="RegVerifyCodeGenerator.ashx" runat="server" />
        <A href="javascript:GetImgCode()">刷新验证码</A>
        <asp:RequiredFieldValidator ID="verifyCodeRequired" runat="server" 
            ControlToValidate="RegVerifyCode">*验证码必填</asp:RequiredFieldValidator>
        <br />
        <!-- 后加  PostBackUrl="~/AvFun_TestPages/Reg.aspx" 使用这种方法在页面间传递，-->
        <asp:Button ID="UserReg" runat="server" Text="注册"  />
        
    </div>
    </form>
</body>
</html>
