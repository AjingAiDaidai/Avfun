<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="AvFun_Website.admin.AddNews" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新闻发布</title>
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="../ckeditor/adapters/jquery.js"></script>
    <script type="text/javascript">
        $(function () {
            CKEDITOR.replace('<%=TextBox1.ClientID %>', { filebrowserImageUploadUrl: '../admin/image_upload.ashx' });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" CssClass="ckeditor"></asp:TextBox>
    </div>
    </form>
</body>
</html>
