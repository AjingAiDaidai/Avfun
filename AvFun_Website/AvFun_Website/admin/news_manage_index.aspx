<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news_manage_index.aspx.cs" Inherits="AvFun_Website.admin.news_manage_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:Label ID="lblLoginStatus" runat="server" Text=""></asp:Label>
    <form id="AdminLoggedForm" runat="server">
    <div>
    
        <asp:HyperLink ID="urlAddNews" runat="server">发布新闻</asp:HyperLink>
        <br />
        <asp:GridView ID="AdminNewsList" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataSourceID="NewsDataSource" >
            <Columns>
                <asp:BoundField DataField="news_title" HeaderText="新闻标题" 
                    SortExpression="news_title" />
                <asp:BoundField DataField="news_author" HeaderText="新闻作者" 
                    SortExpression="news_author" />
                <asp:BoundField DataField="news_publish_date" HeaderText="发布日期" 
                    SortExpression="news_publish_date" />
                <asp:BoundField DataField="news_click_count" HeaderText="点击总数" 
                    SortExpression="news_click_count" />
                <asp:ImageField DataImageUrlField="news_image" HeaderText="新闻图片">
                </asp:ImageField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="NewsDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AvfunNewsConnectingString %>" 
            SelectCommand="SELECT [news_title], [news_content], [news_author], [news_publish_date], [news_image], [news_click_count] FROM [NEWS] ORDER BY [news_publish_date] DESC">
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
