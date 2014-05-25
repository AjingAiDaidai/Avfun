using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
namespace AvFun_Website.admin
{

    public class image_upload : IHttpHandler
    {
        protected string AllowExt = "bmp|gif|jpeg|jpg";
        public void ProcessRequest(HttpContext context)
        {
            string ResultURL = null;
            string CKEditorFuncNum = context.Request["CKEditorFuncNum"];
           // string file = System.IO.Path.GetFileName(uploads.FileName);
         /*
                安全大检查哟
          */
            int FileMaxSize = 10240;//文件大小，单位为K
            HttpPostedFile fileUpload = context.Request.Files["upload"];//获取上传文件方式二
            if (fileUpload != null)
            {
                try
                {
                    // string UploadDir = "~/upload/Uploadify/";//图片保存的文件夹
                    string UploadDir = AvFun_Website.Avfun_BLL.ReadWebConfig.GetAppSettingValue("NewsImageFolder");
                    string ReturnUploadDir = UploadDir.Replace("~", "..");
                    //图片保存的文件夹路径
                    string path = context.Server.MapPath(UploadDir);
                    //如果文件夹不存在，则创建
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    //上传图片的扩展名
                    string fileExtension = fileUpload.FileName.Substring(fileUpload.FileName.LastIndexOf('.'));
                    //判断文件格式
                    if (!CheckValidExt(fileExtension))
                    {
                        context.Response.Write("错误提示：文件格式不正确！" + fileExtension);
                        return;
                    }
                    //判断文件大小
                    if (fileUpload.ContentLength > FileMaxSize * 1024)
                    {
                        context.Response.Write("错误提示：上传的文件(" + fileUpload.FileName + ")超过最大限制：" + FileMaxSize + "KB");
                        return;
                    }
                    //保存图片的文件名
                    //string saveName = Guid.NewGuid().ToString() + fileExtension;
                    //使用时间+随机数重命名文件
                    string strDateTime = DateTime.Now.ToString("yyMMddhhmmssfff");//取得时间字符串
                    Random ran = new Random();
                    string strRan = Convert.ToString(ran.Next(100, 999));//生成三位随机数
                    string saveName = strDateTime + strRan + fileExtension;

                    //保存图片
                    fileUpload.SaveAs(path + "/" + saveName);
                    context.Response.Write(UploadDir + "/" + saveName);
                    ResultURL = ReturnUploadDir + "/" + saveName;
                    context.Response.Write("<script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + ResultURL + "\");</script>");
                    
                }
                catch
                {
                    context.Response.Write("错误提示：上传失败");
                }
            }
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        #region 检测扩展名的有效性 bool CheckValidExt(string sExt)

        /// <summary>
        /// 检测扩展名的有效性
        /// </summary>
        /// <param name="sExt">文件名扩展名</param>
        /// <returns>如果扩展名有效,返回true,否则返回false.</returns>
        public bool CheckValidExt(string strExt)
        {
            bool flag = false;
            string[] arrExt = AllowExt.Split('|');
            foreach (string filetype in arrExt)
            {
                if (filetype.ToLower() == strExt.ToLower().Replace(".", ""))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        #endregion

    }
}