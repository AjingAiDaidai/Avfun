<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="AvFun_Website.admin.AddCourse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="../ckeditor/adapters/jquery.js"></script>
        <script type="text/javascript">
            $(function () {
                CKEDITOR.replace('<%=txtCourseIntro.ClientID %>', { filebrowserImageUploadUrl: '../admin/image_upload.ashx' });
            });</script>
</head>
<body>
    <asp:Label ID="lblLoginStatus" runat="server" Text=""></asp:Label>
    <form id="LoginForm" runat="server">
    <div>
    
        <asp:Label ID="lblCourseTitle" runat="server" Text="课程名称："></asp:Label>
        <asp:TextBox ID="txtCourseTitle" runat="server" MaxLength="256"></asp:TextBox>
        <asp:RequiredFieldValidator ID="courseNameRequired" runat="server" 
            ControlToValidate="txtCourseTitle">*请填写课程名称</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblCoursePrice" runat="server" Text="课程单价："></asp:Label>
        <asp:TextBox ID="txtCoursePrice" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="coursePriceRequired" runat="server" 
            ControlToValidate="txtCoursePrice">*请填写课程价格</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="coursePriceRegular" runat="server" 
            ControlToValidate="txtCoursePrice" ValidationExpression="^[0-9]+(.[0-9]{2})?$">*价格格式不正确</asp:RegularExpressionValidator>
        <asp:RangeValidator ID="coursePriceRange" runat="server" 
            ControlToValidate="txtCoursePrice" MinimumValue="0.00" 
            MaximumValue="9999.00">*价格范围不正确</asp:RangeValidator>
        <br />
        <asp:Label ID="lblCourseRobotLink" runat="server" Text="上课地址："></asp:Label>
        <asp:TextBox ID="txtCourseRobotLink" runat="server" MaxLength="256"></asp:TextBox>
        <asp:RequiredFieldValidator ID="CourseRobotLinkRequire" runat="server" 
            ControlToValidate="txtCourseRobotLink">*请填写上课地址</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblCourseIntro" runat="server" Text="课程介绍"></asp:Label>
        <br />
        <asp:TextBox ID="txtCourseIntro" runat="server" TextMode="MultiLine" CssClass="ckeditor"></asp:TextBox>
        <asp:RequiredFieldValidator ID="courseIntroRequired" runat="server" 
            ControlToValidate="txtCourseIntro">*请填写课程介绍</asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="提交" />
    
    </div>
    </form>
</body>
</html>
