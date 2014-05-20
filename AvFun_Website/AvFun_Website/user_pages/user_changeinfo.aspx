<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_changeinfo.aspx.cs" Inherits="AvFun_Website.user_pages.user_changeinfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改个人资料</title>

    <link rel="stylesheet" type="text/css" href="~/Scripts/Uploadify/uploadify.css" />
<script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="../Scripts/Uploadify/jquery.uploadify.min.js" type="text/javascript"></script>
<script src="../Scripts/jquery.cookie.js" type="text/javascript"></script>
 <script type="text/javascript">
     $(function () {
         $("#uploadImage").uploadify({
             width: 100,
             height: 26,
             swf: '../Scripts/Uploadify/uploadify.swf', //[*]swf的路径
             uploader: 'UserUploadHeadImage.ashx', //[*]一般处理程序
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
                     $("#imgHead").attr("src", data.substr(13)).hide().fadeIn(2000);
                     //分配Cookie指定上传路径，7天过期，实际上用完立刻释放。
                     $.cookie('userHead', data.substr(13)
                                , {expires: 7});

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
    <asp:Label ID="logStatus" runat="server" Text=""></asp:Label>
    <form id="form1" runat="server">
    <div id="loggedDiv"  runat="server">
    
        <asp:Label ID="lblUserAccount" runat="server" Text="登录账号："></asp:Label>
        <asp:TextBox ID="txtUserAccount" runat="server" Enabled="False" MaxLength="64"></asp:TextBox>
        <br />
        <hr />
        <asp:Label ID="lblChangePasswordStatus" runat="server" 
            Text="以下三项若不想修改密码请留空，注意：修改密码将导致其他项不被修改，修改密码后请重新登录"></asp:Label>
        <br />
        <asp:Label ID="lblOldPassword" runat="server" Text="旧密码"></asp:Label>
        ：<asp:TextBox ID="txtUserOldPassword" runat="server" MaxLength="16" 
            TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="lblNewPassword" runat="server" Text="新密码（6-16位）："></asp:Label>
        <asp:TextBox ID="txtUserNewPassword" runat="server" MaxLength="16" 
            TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="urlVerifyNewPassword" runat="server" Text="确认密码（6-16位）："></asp:Label>
        <asp:TextBox ID="txtUserVerifyNewPassword" runat="server" MaxLength="16" 
            TextMode="Password"></asp:TextBox>
        <br />
        <hr />
        <asp:Label ID="lblMoney" runat="server" Text="令咒数量："></asp:Label>
    
        <asp:HyperLink ID="urlMoney" runat="server">令咒充值</asp:HyperLink>
    
        <br />
        <asp:Label ID="lblHead" runat="server" Text="头像："></asp:Label>
        <asp:Image ID="imgHead" runat="server" Height="180px" Width="180px" />
        <input type="file" name="uploadImage" id="uploadImage" />
        <br />
        <br />
        <br />
        <asp:Label ID="lblNickname" runat="server" Text="昵称："></asp:Label>
        <asp:TextBox ID="txtUserNickname" runat="server" MaxLength="32"></asp:TextBox>
        <asp:RequiredFieldValidator ID="nicknameRequired" runat="server" 
            ControlToValidate="txtUserNickname">*昵称不可以为空</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblSex" runat="server" Text="性别："></asp:Label>
        <asp:RadioButtonList ID="UserSex" runat="server" 
            RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="Male">男</asp:ListItem>
            <asp:ListItem Value="Female">女</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Label ID="lblUserIntroduction" runat="server" Text="个人简介："></asp:Label>
        <asp:TextBox ID="txtUserIntroduction" runat="server" TextMode="MultiLine" 
            MaxLength="256"></asp:TextBox>
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="修改" />
    
    </div>
    </form>
</body>
</html>
