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
    public partial class BankPaymentVoucher : PageBase
    {
        #region Constructur
        public BankPaymentVoucher()
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
                lbl.Text = "Bank Payment Voucher";
                ctrlVoucher.MenuName = "BankPaymentVoucher";
                ctrlVoucher.GridCaption = "Bank Payment Voucher";
                ctrlVoucher.VoucherType = 5;
                ctrlVoucher.prifix = "BP";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}