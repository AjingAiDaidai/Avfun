<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyCourse.aspx.cs" Inherits="AvFun_Website.BuyCourse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:Label ID="lblLoginStatus" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblCourseStateus" runat="server"></asp:Label>
    <form id="BuyCourseForm" runat="server">
    <div>
        <br />
        <asp:Label ID="lblCourseName" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblCoursePrice" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblCourseTime" runat="server" Text="购买天数："></asp:Label>
        <asp:TextBox ID="txtCourseTime" runat="server" MaxLength="4"></asp:TextBox>
        <asp:RequiredFieldValidator ID="courseTimeRequired" runat="server" 
            ControlToValidate="txtCourseTime">*请填写购买天数</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="courseTimeRegular" runat="server" 
            ValidationExpression="^[1-9]\d*$" ControlToValidate="txtCourseTime">*购买天数必须是正整数</asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="lblUserMoney" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="确认购买" />
    
    </div>
    </form>
</body>
</html>
