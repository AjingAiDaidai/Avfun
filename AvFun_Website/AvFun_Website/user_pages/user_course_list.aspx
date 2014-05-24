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
    
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" 
            DataKeyNames="order_id,course_id,user_id" DataSourceID="CourseListDataSource">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="course_id" 
                    DataNavigateUrlFormatString="/ViewCourse.aspx?course_id={0}" 
                    DataTextField="course_name" DataTextFormatString="{0}" HeaderText="女友名称" />
                <asp:BoundField DataField="order_date" HeaderText="召唤日期" 
                    SortExpression="order_date" />
                <asp:HyperLinkField DataNavigateUrlFields="course_robot_link" Text="开始调教" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="CourseListDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AvfunNewsConnectingString %>" 
            SelectCommand="SELECT * FROM [UserCourseList] WHERE ([user_id] = @user_id) ORDER BY [order_date] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="00000000-0000-0000-0000-000000000000" Name="user_id" DbType="Guid" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
