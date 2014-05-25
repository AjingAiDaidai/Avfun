<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="course_index.aspx.cs" Inherits="AvFun_Website.course_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblKeyWords" runat="server" Text="关键字："></asp:Label>
        <asp:TextBox ID="txtSearchKeyword" runat="server"></asp:TextBox>
        <asp:Label ID="lblSearchScope" runat="server" Text="搜索范围："></asp:Label>
        <asp:DropDownList ID="dplstSearchScope" runat="server">
            <asp:ListItem Value="All">(全部显示)</asp:ListItem>
            <asp:ListItem Value="course_name">名称</asp:ListItem>
            <asp:ListItem Value="course_intro">内容</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnSearch" runat="server" Text="搜索" onclick="btnSearch_Click" />
        <br />
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="course_id" 
            DataSourceID="CourseIndexDataSource" >
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>
                            未返回数据。</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <ItemTemplate>
                <td runat="server" style="">
                <asp:HyperLink ID="course_name_url" runat="server" Text='<%# Eval("course_name") %>'
                 NavigateUrl='<%# String.Format("ViewCourse.aspx?course_id={0}", Eval("course_id")) %>'
                 Target="_blank">
                    </asp:HyperLink>
                        单日价格：
                    <asp:Label ID="course_priceLabel" runat="server" 
                        Text='<%# Eval("course_price") %>' />令咒
                    <asp:Label ID="course_begin_dateLabel" runat="server" 
                        Text='<%# Eval("course_begin_date") %>' />
                    <br />
                    <asp:Label ID="course_introLabel" runat="server" 
                        Text='<%# Eval("course_intro") %>' />
                        <br />
                </td>
            </ItemTemplate>
            <LayoutTemplate>
                 <ul ID="itemPlaceholderContainer" runat="server" style="">
                    <li runat="server" id="itemPlaceholder" />
                </ul>
                        <div runat="server" style="">
                            <asp:DataPager ID="DataPager1" runat="server" PageSize="6">
                                <Fields>
                                    <asp:NumericPagerField />
                                </Fields>
                            </asp:DataPager>
                            </div>
            </LayoutTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="CourseIndexDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AvfunNewsConnectingString %>" 
            SelectCommand="SELECT [course_id], [course_name], [course_intro], [course_price], [course_begin_date], [course_isDeleted] FROM [COURSE] WHERE ([course_isDeleted] &lt;&gt; @course_isDeleted) ORDER BY [course_begin_date] DESC"
            FilterExpression="{0} LIKE '%{1}%'" onfiltering="CourseIndexDataSource_Filtering" 
            >
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="course_isDeleted" Type="Boolean" />
            </SelectParameters>
            <FilterParameters>
                <asp:ControlParameter ControlID="dplstSearchScope" Name="FieldToSearch" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="txtSearchKeyword" Name="SearchCriteria" 
                    Type="String" />
            </FilterParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
