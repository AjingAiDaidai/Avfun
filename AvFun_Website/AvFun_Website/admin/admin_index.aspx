<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_index.aspx.cs" Inherits="AvFun_Website.admin.admin_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:Label ID="lblLoginStatus" runat="server"></asp:Label>
    <form id="AdminLoggedForm" runat="server">
    <div>
    
        <asp:Label ID="lblAdminInfo" runat="server"></asp:Label>
        <asp:HyperLink ID="urlNewsAdmin" runat="server" 
            NavigateUrl="~/admin/news_manage_index.aspx" Target="_blank">新闻管理</asp:HyperLink>
        <asp:HyperLink ID="urlCourseAdmin" runat="server" 
            NavigateUrl="~/admin/course_manage_index.aspx">课程管理</asp:HyperLink>
        <asp:HyperLink ID="urlUserAdmin" runat="server" 
            NavigateUrl="~/admin/user_manage_index.aspx">用户管理</asp:HyperLink>
        <asp:HyperLink ID="urlAnalyze" runat="server" 
            NavigateUrl="~/admin/admin_statistical.aspx">订单明细</asp:HyperLink>
        <asp:HyperLink ID="urlModifyInfo" runat="server" 
            NavigateUrl="~/admin/admin_changeInfo.aspx" Target="_blank">修改资料</asp:HyperLink>
        <asp:LinkButton ID="btnLogout" runat="server">登出</asp:LinkButton>
    
        <br />
        <br />
        <asp:Label ID="lblShortInfo" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
