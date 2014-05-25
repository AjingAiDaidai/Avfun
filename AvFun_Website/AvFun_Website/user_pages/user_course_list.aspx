<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_course_list.aspx.cs" Inherits="AvFun_Website.user_pages.user_course_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:Label ID="LoginStatus" runat="server" Text=""></asp:Label>
    <form id="UserCourseListForm" runat="server">
    <div align="center">
    
        <asp:Label ID="lblSearchKeyWords" runat="server" Text="关键字："></asp:Label>
        <asp:TextBox ID="txtSearchKeyWords" runat="server"></asp:TextBox>
        <asp:Label ID="lblSearchScope" runat="server" Text="范围："></asp:Label>
        <asp:DropDownList ID="dplstSearchScope" runat="server">
        </asp:DropDownList>
        <asp:Button ID="btnSearch" runat="server" Text="搜索" />
    
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" 
            DataKeyNames="course_id,user_id" DataSourceID="CourseListDataSource">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="course_id" 
                    DataNavigateUrlFormatString="/ViewCourse.aspx?course_id={0}" 
                    DataTextField="course_name" DataTextFormatString="{0}" HeaderText="女友名称" />
                <asp:BoundField DataField="order_date" HeaderText="召唤日期" 
                    SortExpression="order_date" />
                <asp:BoundField DataField="last_date" HeaderText="召唤时长（天）" 
                    SortExpression="last_date" />
                <asp:HyperLinkField DataNavigateUrlFields="course_robot_link" Text="开始调教" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="CourseListDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AvfunNewsConnectingString %>" 
            SelectCommand="SELECT [course_id] ,[user_id] ,[order_date],[course_name] ,[course_robot_link], SUM([order_price])/[course_price] AS last_date
                           FROM [avfun].[dbo].[UserCourseList] WHERE ([order_user] = @user_id) 
                           GROUP BY [order_date],[course_name],[course_robot_link],[course_price],[user_id],[course_id]
                           ORDER BY [order_date] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="00000000-0000-0000-0000-000000000000" Name="user_id" DbType="Guid" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
