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

namespace API.UI.ACC
{
    public partial class ContraVoucher : PageBase
    {
        #region Constructur
        public ContraVoucher()
        {
            RequiresAuthorization = true;
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack.IsFalse())
                {
                }
                Label lbl = (Label)ctrlVoucher.FindControl("lblFrmHeader");
                lbl.Text = "Contra Voucher";
                ctrlVoucher.MenuName = "ContraVoucher";
                ctrlVoucher.GridCaption = "Contra Voucher";
                ctrlVoucher.VoucherType = 12;
                ctrlVoucher.prifix = "CV";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}