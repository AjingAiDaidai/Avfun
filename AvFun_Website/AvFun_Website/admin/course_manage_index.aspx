<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="course_manage_index.aspx.cs" Inherits="AvFun_Website.admin.course_manage_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:Label ID="lblLoginStatus" runat="server" Text=""></asp:Label>
    <form id="LoginForm" runat="server">
    <div align="center">
        <asp:HyperLink ID="urlAddCourse" runat="server" Target="_blank" NavigateUrl="AddCourse.aspx">发布课程</asp:HyperLink>

        <br />
        <asp:Label ID="lblSearchKeyWords" runat="server" Text="关键字："></asp:Label>
        <asp:TextBox ID="txtSearchKeyWords" runat="server" MaxLength="32"></asp:TextBox>
        <asp:Label ID="lblKeyWords" runat="server" Text="范围："></asp:Label>
        <asp:DropDownList ID="dplstSearchScope" runat="server">
            <asp:ListItem Value="all">(显示全部)</asp:ListItem>
            <asp:ListItem Value="course_name">课程名称</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnSearch" runat="server" Text="搜索" onclick="btnSearch_Click" />
        <br />
        <asp:GridView ID="CourseLists" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="course_id" DataSourceID="CourseManageDataSource" 
            AllowPaging="True" AllowSorting="True">
            <Columns>
                <asp:BoundField DataField="course_name" HeaderText="course_name" 
                    SortExpression="course_name" />
                <asp:BoundField DataField="course_price" HeaderText="course_price" 
                    SortExpression="course_price" />
                <asp:BoundField DataField="course_begin_date" HeaderText="course_begin_date" 
                    SortExpression="course_begin_date" />
                <asp:BoundField DataField="course_robot_link" HeaderText="course_robot_link" 
                    SortExpression="course_robot_link" />
                <asp:CheckBoxField DataField="course_isDeleted" HeaderText="course_isDeleted" 
                    SortExpression="course_isDeleted" />
                <asp:HyperLinkField DataNavigateUrlFields="course_id" 
                    DataNavigateUrlFormatString="AddCourse.Aspx?course_id={0}" Text="修改" 
                    Target="_blank" />
                <asp:HyperLinkField DataNavigateUrlFields="course_id" 
                    DataNavigateUrlFormatString="delCourse.aspx?course_id={0}" Text="删除" 
                    Target="_blank" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="CourseManageDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AvfunNewsConnectingString %>" 
            SelectCommand="SELECT [course_id], [course_name], [course_intro], [course_price], [course_begin_date], [course_robot_link], [course_isDeleted] FROM [COURSE] ORDER BY [course_begin_date] DESC"
            FilterExpression="{0} LIKE '%{1}%'" 
            onfiltering="CourseManageDataSource_Filtering" >
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
