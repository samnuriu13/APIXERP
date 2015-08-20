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
    public partial class CashReceiveVoucher : PageBase
    {
        #region Constructur
        public CashReceiveVoucher()
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
                lbl.Text = "Cash Receive Voucher";
                ctrlVoucher.MenuName = "CashReceiveVoucher";
                ctrlVoucher.GridCaption = "Cash Receive Voucher";
                ctrlVoucher.VoucherType = 4;
                ctrlVoucher.prifix = "CR";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}