<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news_manage_index.aspx.cs" Inherits="AvFun_Website.admin.news_manage_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:Label ID="lblLoginStatus" runat="server" Text=""></asp:Label>
    <form id="AdminLoggedForm" runat="server">
    <div id="adminNewsListDiv" align="center">
    
        <asp:HyperLink ID="urlAddNews" runat="server" 
            NavigateUrl="~/admin/AddNews.aspx" Target="_blank">发布新闻</asp:HyperLink>
        <br />
        <asp:Label ID="lblKeyWords" runat="server" Text="搜索关键字："></asp:Label>
        <asp:TextBox ID="txtKeyWord" runat="server" MaxLength="32"></asp:TextBox>
        <asp:Label ID="lblScope" runat="server" Text="范围："></asp:Label>
        <asp:DropDownList ID="dpListKeyScope" runat="server">
            <asp:ListItem Value="news_title">标题</asp:ListItem>
            <asp:ListItem Value="admin_nickname">作者</asp:ListItem>
            <asp:ListItem Value="news_content">内容</asp:ListItem>
            <asp:ListItem Selected="True" Value="all">(显示全部)</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnSearch" runat="server"  Text="搜索" 
            onclick="btnSearch_Click" />
        <br />
        <asp:GridView ID="AdminNewsList" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" 
            DataSourceID="AdminNewsListDataSource" DataKeyNames="news_id" >
            <Columns>
                <asp:BoundField DataField="admin_nickname" HeaderText="admin_nickname" 
                    SortExpression="admin_nickname" />
                <asp:BoundField DataField="news_title" HeaderText="news_title" 
                    SortExpression="news_title" />
                <asp:BoundField DataField="news_publish_date" HeaderText="news_publish_date" 
                    SortExpression="news_publish_date" />
                <asp:CheckBoxField DataField="news_isDeleted" HeaderText="news_isDeleted" 
                    SortExpression="news_isDeleted" />
                <asp:CheckBoxField DataField="news_isOnIndex" HeaderText="news_isOnIndex" 
                    SortExpression="news_isOnIndex" />
                <asp:HyperLinkField DataNavigateUrlFields="news_id" 
                    DataNavigateUrlFormatString="AddNews.aspx?news_id={0}" Text="修改"  />
                <asp:HyperLinkField DataNavigateUrlFields="news_id" 
                    DataNavigateUrlFormatString="DeleteNews.aspx?news_id={0}" Text="删除" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="AdminNewsListDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AvfunNewsConnectingString %>" 
            SelectCommand="SELECT * FROM [AdminNewsList]"
            FilterExpression="{0} LIKE '%{1}%'" 
            onfiltering="AdminNewsListDataSource_Filtering">
            <FilterParameters>
                <asp:ControlParameter ControlID="dpListKeyScope" Name="FieldToSearch" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="txtKeyWord" Name="SearchCriteria" 
                    Type="String" />
            </FilterParameters>
        </asp:SqlDataSource>

    
    </div>
    </form>
</body>
</html>
