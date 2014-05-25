<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AvFun_Website.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AvFun在线日语学习网站——オタクが世界を守って、救っている</title>
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
            NavigateUrl="~/user_pages/user_index.aspx" Target="_blank">用户中心</asp:HyperLink>
        <asp:HyperLink ID="urlMoney" runat="server">令咒充值</asp:HyperLink>
        <asp:HyperLink ID="urlChooseCourse" runat="server" 
            NavigateUrl="~/course_index.aspx">选择女友</asp:HyperLink>
        <asp:HyperLink ID="urlChat" runat="server" 
            NavigateUrl="~/user_pages/user_course_list.aspx" Target="_blank">临幸后宫</asp:HyperLink>
    </div>
        <asp:HyperLink ID="urlNews" runat="server" NavigateUrl="~/news_index.aspx">本站新闻</asp:HyperLink>
        <asp:HyperLink ID="urlCourseIntro" runat="server" 
        NavigateUrl="~/course_index.aspx" Target="_blank">课程介绍</asp:HyperLink>
    <asp:SqlDataSource ID="IndexNewsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AvfunNewsConnectingString %>" 
        SelectCommand="SELECT TOP 5 [news_id],[news_title],[admin_nickname], [news_isOnIndex], [news_image], [news_isDeleted], [news_publish_date] FROM [AdminNewsList] WHERE (([news_isDeleted] &lt;&gt; @news_isDeleted) AND ([news_isOnIndex] = @news_isOnIndex)) ORDER BY [news_publish_date] DESC">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="news_isDeleted" Type="Boolean" />
            <asp:Parameter DefaultValue="True" Name="news_isOnIndex" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />    
    <asp:DataList ID="ImageIndexNewsList" runat="server" DataKeyField="news_id" 
        DataSourceID="IndexNewsDataSource">
        <ItemTemplate>
        <table>
        <tr align="center" width="80%">
            <td width="20%">
                <asp:Label ID="news_title" runat="server" Text='<%# Eval("news_title") %>'></asp:Label>
                <br />
                <asp:Label ID="news_author"
                    runat="server" Text='<%# Eval("admin_nickname") %>'></asp:Label>
            </td>
            <td width="80%">
            <asp:HyperLink ID="NewsURL" runat="server" target="_blank"
                NavigateUrl = '<%# String.Format("ViewNews.aspx?news_id={0}", Eval("news_id")) %>'>
                <asp:Image ID="NewsImage" runat="server" ImageURL='<%# Eval("news_image") %>' Width = "480"
                Height = "320"/>
                </asp:HyperLink>
            </td>
         </tr>
         </table>
        </ItemTemplate>
    </asp:DataList>
    </form>
</body>
</html>
