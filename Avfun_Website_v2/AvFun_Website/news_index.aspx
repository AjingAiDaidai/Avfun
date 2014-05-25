<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news_index.aspx.cs" Inherits="AvFun_Website.news_index" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:SqlDataSource ID="NewsIndexDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AvfunNewsConnectingString %>"             
            SelectCommand="SELECT [admin_nickname], [news_id], [news_title], [news_publish_date], [news_click_count], [news_content] FROM [AdminNewsList] WHERE ([news_isDeleted] &lt;&gt; @news_isDeleted) ORDER BY [news_publish_date] DESC"
            FilterExpression="{0} LIKE '%{1}%'" 
            onfiltering="NewsIndexDataSource_Filtering" >
             <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="news_isDeleted" Type="Boolean" />
            </SelectParameters>
            <FilterParameters>
                <asp:ControlParameter ControlID="dplstSearchScope" Name="FieldToSearch" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="txtSearchKeyWords" Name="SearchCriteria" 
                    Type="String" />
            </FilterParameters>
        </asp:SqlDataSource>
        <asp:Label ID="lblKeyWords" runat="server" Text="关键字："></asp:Label>
        <asp:TextBox ID="txtSearchKeyWords" runat="server" MaxLength="32"></asp:TextBox>
        <asp:Label ID="lblScope" runat="server" Text="范围："></asp:Label>
        <asp:DropDownList ID="dplstSearchScope" runat="server">
            <asp:ListItem Selected="True" Value="All">(全部显示)</asp:ListItem>
            <asp:ListItem Value="admin_nickname">作者</asp:ListItem>
            <asp:ListItem Value="news_title">标题</asp:ListItem>
            <asp:ListItem Value="news_content">内容</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnSearch" runat="server" Text="搜索" onclick="btnSearch_Click" />
        <asp:ListView ID="NewLists" runat="server" DataSourceID="NewsIndexDataSource" >
            <EmptyDataTemplate>
                未返回数据。
            </EmptyDataTemplate>
            <ItemSeparatorTemplate>
<br />
            </ItemSeparatorTemplate>
            <ItemTemplate>

                <asp:HyperLink ID="news_title_url" runat="server" Text='<%# Eval("news_title") %>'
                 NavigateUrl='<%# String.Format("ViewNews.aspx?news_id={0}", Eval("news_id")) %>'
                 Target="_blank">
                    </asp:HyperLink>
                    <br />
                    <asp:Label ID="news_click_countLabel" runat="server" 
                        Text='<%# Eval("news_click_count") %>' />
                    <asp:Label ID="admin_nicknameLabel" runat="server" 
                        Text='<%# Eval("admin_nickname") %>' />
                    <asp:Label ID="news_publish_dateLabel" runat="server" 
                        Text='<%# Eval("news_publish_date") %>' />
                    <br />
                    <asp:Label ID="news_contentLabel" runat="server" 
                        Text='<%# Eval("news_content") %>' MaxLength="128" />
                    <br />
            </ItemTemplate>
            <LayoutTemplate>
                <ul ID="itemPlaceholderContainer" runat="server" style="">
                    <li runat="server" id="itemPlaceholder" />
                </ul>
                <div style="">
                    <asp:DataPager ID="DataPager1" runat="server">
                        <Fields>
                            <asp:NumericPagerField />
                        </Fields>
                    </asp:DataPager>
                </div>
            </LayoutTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>
