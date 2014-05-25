<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewNews.aspx.cs" Inherits="AvFun_Website.ViewNews" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="NewsForm" runat="server">
    <div>
    
        <asp:DataList ID="DataList1" runat="server" DataSourceID="ViewNewsDataSource">
            <ItemTemplate>
                <asp:Label ID="news_titleLabel" runat="server" 
                    Text='<%# Eval("news_title") %>' />
                <br />
               <asp:Label ID="admin_nicknameLabel" runat="server" 
                    Text='<%# Eval("admin_nickname") %>' />
                <asp:Label ID="news_publish_dateLabel" runat="server" 
                    Text='<%# Eval("news_publish_date") %>' />
                点击数:
                <asp:Label ID="news_click_countLabel" runat="server" 
                    Text='<%# Eval("news_click_count") %>' />
                <br />
                <asp:Label ID="news_contentLabel" runat="server" 
                    Text='<%# Eval("news_content") %>' />
                <br />
<br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="ViewNewsDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AvfunNewsConnectingString %>" 
            SelectCommand="SELECT [admin_nickname], [news_title], [news_publish_date], [news_click_count], [news_content] FROM [AdminNewsList] WHERE (([news_isDeleted] &lt;&gt; @news_isDeleted) AND ([news_id] = @news_id))">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="news_isDeleted" Type="Boolean" />
                <asp:QueryStringParameter DbType="Guid" Name="news_id" 
                    QueryStringField="news_id" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
    
    </div>
    </form>
</body>
</html>
