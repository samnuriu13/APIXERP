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
    public partial class OpeningStock : PageBase
    {
        #region Constructur
        public OpeningStock()
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
                lbl.Text = "Opening Stock";
                ctrlRequisition.MenuName = "OpeningStock";
                ctrlRequisition.GridCaption = "Opening Stock";
                ctrlRequisition.TransType = 8;
                ctrlRequisition.DocListID = 252;
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