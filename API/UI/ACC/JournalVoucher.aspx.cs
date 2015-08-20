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
    public partial class JournalVoucher : PageBase
    {
        #region Constructur
        public JournalVoucher()
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
                lbl.Text = "Journal Voucher";
                ctrlVoucher.MenuName = "JournalVoucher";
                ctrlVoucher.GridCaption = "Journal Voucher";
                ctrlVoucher.VoucherType = 7;
                ctrlVoucher.prifix = "JV";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}