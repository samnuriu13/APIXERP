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
    public partial class CashPaymantVoucher : PageBase
    {
        #region Constructur
        public CashPaymantVoucher()
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
                lbl.Text = "Cash Payment Voucher";
                ctrlVoucher.MenuName = "CashPaymantVoucher";
                ctrlVoucher.GridCaption = "Cash Payment Voucher";
                ctrlVoucher.VoucherType = 3;
                ctrlVoucher.prifix = "CP";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}