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
    public partial class InvMRR : PageBase
    {
        #region Constructur
        public InvMRR()
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
                lbl.Text = "Material Receive";
                ctrlRequisition.MenuName = "MaterialReceive";
                ctrlRequisition.GridCaption = "Material Receive Detail";
                ctrlRequisition.TransType = 4;
                ctrlRequisition.DocListID = 228;
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