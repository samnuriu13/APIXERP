using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using API.DAO;
using API.BLL;
using API.DATA;
using System.Text;

namespace API.Controls.Layout
{
    public partial class HeaderSettings : System.Web.UI.UserControl
    {
        WorkFlowTransactionManager _manager = new WorkFlowTransactionManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              CustomList<WFApprovalPendingList> WFPendingList =  _manager.GetWFApprovalPendingList(((FRAMEWORK.PageBase)this.Page).MenuID, ((FRAMEWORK.PageBase)this.Page).CurrentUserSession.UserCode,0);
              var sb = new StringBuilder();
                sb.Append("<table id='PandingList'>");
              foreach (WFApprovalPendingList wF in WFPendingList)
              {
                  sb.Append("<tr><td>" + wF.TransactionID.ToString()+"</td>");
                  sb.Append("<td>"+wF.Status+"</td></tr>");
              }
              sb.Append("</table>");
              PendingList.InnerHtml = sb.ToString();
            }
        }
        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            //TODO
            //Store logout info (datetime, etc..) in the database.
            Session.Abandon();
            Response.Redirect("~/UI/Security/Login.aspx");
        }
        public void SaveWF()
        {

        }
    }
}