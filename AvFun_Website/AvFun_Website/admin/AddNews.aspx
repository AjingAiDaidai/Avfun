<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="AvFun_Website.admin.AddNews" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新闻发布</title>
    <link rel="stylesheet" type="text/css" href="~/Scripts/Uploadify/uploadify.css" />


    <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
        <script type="text/javascript" src="../Scripts/Uploadify/jquery.uploadify.min.js"></script>
            <script type="text/javascript" src="../Scripts/jquery.cookie.js"></script>

    <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="../ckeditor/adapters/jquery.js"></script>
    <script type="text/javascript">
        $(function () {
            CKEDITOR.replace('<%=txtNewsContent.ClientID %>', { filebrowserImageUploadUrl: '../admin/image_upload.ashx' });
            $("#uploadImage").uploadify({
                width: 100,
                height: 26,
                swf: '../Scripts/Uploadify/uploadify.swf', //[*]swf的路径
                uploader: 'NewsUploadHeadImage.ashx', //[*]一般处理程序
                cancelImg: '../Scripts/Uploadify/uploadify-cancel.png', //取消图片路径
                multi: false,
                'fileTypeDesc': '图片文件',
                fileTypeExts: '*.gif;*.jpg;*.jpeg;*.bmp', //允许上传的文件类型，使用分号(”;)”分割 例如:*.jpg;*.gif,默认为null(所有文件类型)
                'fileSizeLimit': '6000KB',
                onUploadSuccess: function (file, data, response) {//上传完成时触发（每个文件触发一次）
                    if (data.indexOf('错误提示') > -1) {
                        alert(data);
                    }
                    else {
                        $("#imgHeadImage").attr("src", ".." + data.substr(1)).hide().fadeIn(2000);
                        //分配Cookie指定上传路径，7天过期，实际上用完立刻释放。
                        $.cookie('newsHeadImage',  data.substr(1)
                                , { expires: 7 });

                    }
                },
                'onUploadError': function (file, errorCode, errorMsg, errorString) {//当单个文件上传出错时触发
                    alert('文件：' + file.name + ' 上传失败: ' + errorString);
                },
                buttonText: '选择图片'
            });
        });
    </script>
</head>
<body>
<asp:Label ID="lblLoginStatus" runat="server" Text=""></asp:Label>
    <form id="loginForm" runat="server">
    <div>
        <asp:Label ID="lblNewsTitle" runat="server" Text="新闻标题："></asp:Label>
        
        <asp:TextBox ID="txtNewsTitle" runat="server" MaxLength="128" Width="650px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="NewsTitleRequired" runat="server" 
            ControlToValidate="txtNewsTitle" ErrorMessage="RequiredFieldValidator">*请填写新闻标题</asp:RequiredFieldValidator>
        <br />
        <asp:CheckBox ID="chkboxIsOnIndex" runat="server" Text="上首页" />
        <br />
        <asp:Label ID="lblHeadImage" runat="server" Text="新闻题头图："></asp:Label>
        <asp:Image ID="imgHeadImage" runat="server" Width="480" Height="320" />
        <input type="file" name="uploadImage" id="uploadImage" />
        <br />
        <asp:Label ID="lblNewsContent" runat="server" Text="新闻正文："></asp:Label>
        <br />
     <asp:TextBox ID="txtNewsContent" runat="server" TextMode="MultiLine"  CssClass="ckeditor"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="NewsContentRequired" runat="server" 
            ControlToValidate="txtNewsContent" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="btnSubmitNews" runat="server" Text="提交" />
    </div>
    </form>
</body>
</html>
