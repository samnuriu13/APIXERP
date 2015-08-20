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
    public partial class TransferReceive : PageBase
    {
        #region Constructur
        public TransferReceive()
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
                lbl.Text = "Material Transfer Receive";
                ctrlRequisition.MenuName = "TransferReceive";
                ctrlRequisition.GridCaption = "Transfer Receive Detail";
                ctrlRequisition.TransType = 10;
                ctrlRequisition.DocListID = 231;
                ctrlRequisition.NatureOfTrans = "Receive";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}