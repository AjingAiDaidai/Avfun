<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="AvFun_Website.ViewUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="ViewUserForm" runat="server">
    <div>
    
        <asp:ListView ID="ListView1" runat="server" DataSourceID="ViewUserDataSource" >
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>
                            未返回数据。</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <EmptyItemTemplate>
<td runat="server" />
            </EmptyItemTemplate>
            <ItemTemplate>
                    <asp:Image ID="user_headImg" runat="server" Height="180" Width="180" ImageUrl='<%#"user_pages/" + Eval("user_head") %>' />
                    <asp:Label ID="user_nicknameLabel" runat="server" 
                        Text='<%# Eval("user_nickname") %>' />
                    <br />
                    性别：
                    <asp:CheckBox ID="user_sexCheckBox" runat="server" 
                        Checked='<%# Eval("user_sex") %>' Enabled="false" Text="带把" />
                    <br />自我介绍:
                    <asp:Label ID="user_introductionLabel" runat="server" 
                        Text='<%# Eval("user_introduction") %>' />
                    <br />
            </ItemTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="ViewUserDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AvfunNewsConnectingString %>" 
            SelectCommand="SELECT [user_nickname], [user_head], [user_sex], [user_introduction] FROM [USER] WHERE ([user_id] = @user_id)">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="00000000-0000-0000-0000-000000000000" 
                    Name="user_id" QueryStringField="user_id" DbType="Guid" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
