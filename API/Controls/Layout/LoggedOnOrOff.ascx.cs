using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using API.DATA;
using SECURITY.DAO;
using System.Text;
using FRAMEWORK;
using System.Configuration;

namespace API.Controls.Layout
{
    public partial class LoggedOnOrOff : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((PageBase)this.Page).CurrentUserSession.IsNull())
            {
                HttpContext.Current.Response.Redirect("~/UI/Security/Login.aspx?back_url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }
        }
    }
}