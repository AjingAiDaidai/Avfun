<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_statistical.aspx.cs" Inherits="AvFun_Website.admin.admin_statistical" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:Label ID="lblLoginStatus" runat="server" Text=""></asp:Label>
    <form id="StatisticalForm" runat="server">
    <div align="center">
    
        <asp:Label ID="lblSearchKeyWord" runat="server" Text="关键字："></asp:Label>
        <asp:TextBox ID="txtSearchKeyWords" runat="server"></asp:TextBox>
        <asp:Label ID="lblSearchScope" runat="server" Text="搜索范围："></asp:Label>
        <asp:DropDownList ID="dplstSearchScope" runat="server">
            <asp:ListItem>(全部显示)</asp:ListItem>
            <asp:ListItem Value="course_name">课程名称</asp:ListItem>
            <asp:ListItem Value="user_nickname">用户昵称</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnSearch" runat="server" Text="搜索" />
    
        <asp:GridView ID="StatisticalView" runat="server" AutoGenerateColumns="False" 
            DataSourceID="AdminStatisticDataSource" AllowPaging="True" 
            AllowSorting="True">
            <Columns>
                <asp:BoundField DataField="order_price" HeaderText="订单价格" 
                    SortExpression="order_price" />
                <asp:BoundField DataField="order_date" HeaderText="订单日期" 
                    SortExpression="order_date" />
                <asp:BoundField DataField="course_name" HeaderText="课程名称" 
                    SortExpression="course_name" />
                <asp:BoundField DataField="course_price" HeaderText="每日单价" 
                    SortExpression="course_price" />
                <asp:BoundField DataField="user_nickname" HeaderText="用户昵称" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="AdminStatisticDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AvfunNewsConnectingString %>" 
            SelectCommand="SELECT [user_nickname],[order_price], [order_date], [course_name], [course_price] FROM [UserCourseList],[USER] WHERE [order_user] = [USER].[user_id] ORDER BY [order_date] DESC"
            FilterExpression="{0} LIKE '%{1}%'" onfiltering="AdminStatisticDataSource_Filtering"
            >
            <FilterParameters>
                <asp:ControlParameter ControlID="dplstSearchScope" Name="FieldToSearch" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="txtSearchKeyWords" Name="SearchCriteria" 
                    Type="String" />
            </FilterParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
