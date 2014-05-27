<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_statistical.aspx.cs" Inherits="AvFun_Website.user_pages.user_statistical" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:Label ID="lblLoginStatus" runat="server" Text=""></asp:Label>
    <form id="UserStatisticalForm" runat="server">
    <div align="center">
    
        <asp:Label ID="lblSearchKeyWord" runat="server" Text="关键字："></asp:Label>
        <asp:TextBox ID="txtSearchKeyWord" runat="server"></asp:TextBox>
        <asp:Label ID="lblSearchScope" runat="server" Text="范围："></asp:Label>
        <asp:DropDownList ID="dplstSearchScope" runat="server">
            <asp:ListItem Value="all">(全部显示)</asp:ListItem>
            <asp:ListItem Value="course_name">课程名称</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnSearch" runat="server" Text="搜索" onclick="btnSearch_Click" />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="UserStatisticalDataSource">
            <Columns>
                <asp:BoundField DataField="order_price" HeaderText="订单价格" 
                    SortExpression="order_price" />
                <asp:CheckBoxField DataField="order_isPaid" HeaderText="已经结算" 
                    SortExpression="order_isPaid" />
                <asp:BoundField DataField="course_name" HeaderText="课程名称" 
                    SortExpression="course_name" />
                <asp:BoundField DataField="course_price" HeaderText="课程价格（单日）" 
                    SortExpression="course_price" />
                <asp:BoundField DataField="order_date" HeaderText="下单日期" 
                    SortExpression="order_date" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="UserStatisticalDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AvfunNewsConnectingString %>" 
            SelectCommand="SELECT [order_price], [order_isPaid], [course_name], [course_price], [order_date] FROM [UserCourseList] WHERE ([user_id] = @user_id) ORDER BY [order_date] DESC"
            FilterExpression="{0} LIKE '%{1}%'" 
            onfiltering="UserStatisticalDataSource_Filtering">
            <SelectParameters>
                <asp:Parameter DbType="Guid" Name="user_id"  DefaultValue="00000000-0000-0000-0000-000000000000" />
            </SelectParameters>
            <FilterParameters>
                <asp:ControlParameter ControlID="dplstSearchScope" Name="FieldToSearch" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="txtSearchKeyWord" Name="SearchCriteria" 
                    Type="String" />
            </FilterParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
