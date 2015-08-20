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
    public partial class ItemTransfer : PageBase
    {
        #region Constructur
        public ItemTransfer()
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
                lbl.Text = "Material Transfer";
                ctrlRequisition.MenuName = "MaterialTransfer";
                ctrlRequisition.GridCaption = "Material Transfer Detail";
                ctrlRequisition.TransType = 7;
                ctrlRequisition.DocListID = 230;
                ctrlRequisition.NatureOfTrans = "Issue";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}