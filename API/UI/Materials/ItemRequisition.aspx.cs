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
    public partial class ItemRequisition : PageBase
    {
        #region Constructur
        public ItemRequisition()
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
                lbl.Text = "Item Requisition";
                ctrlRequisition.MenuName = "ItemRequisition";
                ctrlRequisition.GridCaption = "Item Requisition Detail";
                ctrlRequisition.TransType = 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}