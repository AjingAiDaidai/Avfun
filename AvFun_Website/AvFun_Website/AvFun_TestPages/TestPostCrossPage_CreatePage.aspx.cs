using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AvFun_Website.AvFun_UI;
using System.Collections.Specialized;
namespace AvFun_Website.AvFun_TestPages
{
    public partial class TestPostCrossPage_CreatePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                String UserAccount = Request.Form["txtUserAccount"];
                String UserPassword = Request.Form["txtUserPassword"];
                lblRegInfo.Text = "UserAccount:" + UserAccount + "," + "UserPassword" + UserPassword;
            }
        }
    }
}