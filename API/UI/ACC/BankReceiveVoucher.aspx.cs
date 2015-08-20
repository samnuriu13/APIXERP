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
    public partial class BankReceiveVoucher : PageBase
    {
        #region Constructur
        public BankReceiveVoucher()
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
                lbl.Text = "Bank Receive Voucher";
                ctrlVoucher.MenuName = "BankReceiveVoucher";
                ctrlVoucher.GridCaption = "Bank Receive Voucher";
                ctrlVoucher.VoucherType = 6;
                ctrlVoucher.prifix = "BR";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}