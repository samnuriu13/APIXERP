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
    public partial class PurchaseReturn : PageBase
    {
        #region Constructur
        public PurchaseReturn()
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
                lbl.Text = "Purchase Return";
                ctrlRequisition.MenuName = "PurchaseReturn";
                ctrlRequisition.GridCaption = "Purchase Return Detail";
                ctrlRequisition.TransType = 9;
                ctrlRequisition.DocListID = 255;
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