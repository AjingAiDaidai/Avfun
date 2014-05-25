<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCourse.aspx.cs" Inherits="AvFun_Website.ViewCourse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:Label ID="lblCourseStatus" runat="server" Text=""></asp:Label>
    <form id="CourseForm" runat="server">
    <div>
    
        <asp:DataList ID="DataList1" runat="server" DataKeyField="course_id" 
            DataSourceID="ViewCourseDataSource">
            <ItemTemplate>
                &nbsp;<asp:Label ID="course_nameLabel" runat="server" 
                    Text='<%# Eval("course_name") %>' />
                <br />
                单日价格：
                <asp:Label ID="course_priceLabel" runat="server" 
                    Text='<%# Eval("course_price") %>' />令咒
                <asp:Label ID="course_begin_dateLabel" runat="server" 
                    Text='<%# Eval("course_begin_date") %>' />
                <asp:HyperLink ID="urlBuyCourse" runat="server" NavigateUrl='<%# String.Format("BuyCourse.aspx?course_id={0}", Eval("course_id")) %>'
                 Target="_blank">购买</asp:HyperLink>
                <br />
                <asp:Label ID="course_introLabel" runat="server" 
                    Text='<%# Eval("course_intro") %>' />
                <br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="ViewCourseDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AvfunNewsConnectingString %>" 
            SelectCommand="SELECT [course_id], [course_name], [course_intro], [course_price], [course_begin_date] FROM [COURSE] WHERE (([course_id] = @course_id) AND ([course_isDeleted] &lt;&gt; @course_isDeleted))">
            <SelectParameters>
                <asp:QueryStringParameter Name="course_id" QueryStringField="course_id" DbType="Guid" 
                    />
                <asp:Parameter DefaultValue="True" Name="course_isDeleted" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
