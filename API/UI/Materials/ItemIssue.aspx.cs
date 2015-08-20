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
    public partial class ItemIssue : PageBase
    {
        #region Constructur
        public ItemIssue()
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
                lbl.Text = "Material Issue";
                ctrlRequisition.MenuName = "MaterialIssue";
                ctrlRequisition.GridCaption = "Issue Detail";
                ctrlRequisition.TransType = 6;
                ctrlRequisition.DocListID = 229;
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