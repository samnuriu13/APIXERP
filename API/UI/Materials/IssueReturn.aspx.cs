using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using API.BLL;
using API.DAO;
using STATIC;
using API.DATA;
using FRAMEWORK;
using System.Data.SqlClient;

namespace API.UI.Materials
{
    public partial class IssueReturn : PageBase
    {
        #region Constructur
        public IssueReturn()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack.IsFalse())
                {
                }
                Label lbl = (Label)ctrlRequisition.FindControl("lblFrmHeader");
                lbl.Text = "Issue Return";
                ctrlRequisition.MenuName = "IssueReturn";
                ctrlRequisition.GridCaption = "Issue Return Detail";
                ctrlRequisition.TransType = 5;
                ctrlRequisition.DocListID = 254;
                ctrlRequisition.NatureOfTrans = "Return";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}