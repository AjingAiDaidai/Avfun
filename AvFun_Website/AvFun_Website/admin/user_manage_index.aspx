<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_manage_index.aspx.cs" Inherits="AvFun_Website.admin.user_manage_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:Label ID="lblLoginStatus" runat="server" Text=""></asp:Label>
    <form id="UserManageForm" runat="server">
    <div align="center">
    
        <asp:Label ID="lblSearchKeyWords" runat="server" Text="关键字："></asp:Label>
        <asp:TextBox ID="txtSearchKeyWords" runat="server"></asp:TextBox>
        <asp:Label ID="lblSearchScope" runat="server" Text="范围："></asp:Label>
        <asp:DropDownList ID="dplstSearchScope" runat="server">
            <asp:ListItem>(全部显示)</asp:ListItem>
            <asp:ListItem Value="user_nickname">用户昵称</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnSearch" runat="server" Text="Button" />
        <br />
        <asp:GridView ID="UserGridView" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="user_id" 
            DataSourceID="UserDataSource">
            <Columns>
                <asp:BoundField DataField="user_nickname" HeaderText="user_nickname" 
                    SortExpression="user_nickname" />
                <asp:CheckBoxField DataField="user_isDeleted" HeaderText="user_isDeleted" 
                    SortExpression="user_isDeleted" />
                <asp:CheckBoxField DataField="user_isChecked" HeaderText="user_isChecked" 
                    SortExpression="user_isChecked" />
                <asp:BoundField DataField="user_money" HeaderText="user_money" 
                    SortExpression="user_money" />
                <asp:HyperLinkField DataNavigateUrlFields="user_id" 
                    DataNavigateUrlFormatString="Deluser.aspx?user_id={0}" Target="_blank" 
                    Text="删除"></asp:HyperLinkField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="UserDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AvfunNewsConnectingString %>" 
            SelectCommand="SELECT [user_id], [user_nickname], [user_sex], [user_isDeleted], [user_isChecked], [user_money] FROM [USER] ORDER BY [user_last_login_time] DESC"
            FilterExpression="{0} LIKE '%{1}%'" 
            onfiltering="UserDataSource_Filtering" >
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
