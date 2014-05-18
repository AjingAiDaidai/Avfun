<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_index.aspx.cs" Inherits="AvFun_Website.user_pages.user_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="loggedDiv" runat="server">
        
        <asp:HyperLink ID="urlIndex" runat="server" NavigateUrl="~/Default.aspx" 
            Target="_self">返回首页</asp:HyperLink>
        <asp:HyperLink ID="urlChooseCourse" runat="server">选择女友</asp:HyperLink>
        <asp:HyperLink ID="urlChat" runat="server">临幸后宫</asp:HyperLink>
        <asp:HyperLink ID="urlChangInfo" runat="server" 
            NavigateUrl="~/user_pages/user_changeinfo.aspx" Target="_self">修改资料</asp:HyperLink>
        <asp:HyperLink ID="urlAnalyze" runat="server">统计信息</asp:HyperLink>
        <asp:Label ID="lblMoney" runat="server" Text="令咒充值"></asp:Label>
        <br />
        
        <asp:Table ID="tbl_UserDetail" runat="server">
            <asp:TableRow runat="server" HorizontalAlign="Center" VerticalAlign="Middle" 
                >
                <asp:TableCell runat="server">昵称</asp:TableCell>
                <asp:TableCell ID="nickName" runat="server"></asp:TableCell>
                <asp:TableCell runat="server">头像</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:Image ID="head" runat="server" Width="180" Height="180" /></asp:TableCell>
                <asp:TableCell runat="server">最后登录日期</asp:TableCell>
                <asp:TableCell ID="last_login_time" runat="server"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell runat="server" >令咒数量</asp:TableCell>
                <asp:TableCell ID="money" runat="server" ></asp:TableCell>
                <asp:TableCell runat="server" >是否激活</asp:TableCell>
                <asp:TableCell ID="isChecked" runat="server" ></asp:TableCell>
                <asp:TableCell runat="server" >最后登录ip</asp:TableCell>
                <asp:TableCell ID="last_login_ip" runat="server" ></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell runat="server">是否冻结</asp:TableCell>
                <asp:TableCell ID="isDeleted" runat="server"></asp:TableCell>
                <asp:TableCell runat="server">个人简介</asp:TableCell>
                <asp:TableCell ID="user_introduction" runat="server"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    
    </div>
    <asp:Label ID="logStatus" runat="server"></asp:Label>
    </form>
</body>
</html>
