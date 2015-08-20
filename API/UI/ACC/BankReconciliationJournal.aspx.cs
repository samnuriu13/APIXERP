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
    public partial class BankReconciliationJournal : PageBase
    {
        #region Constructur
        public BankReconciliationJournal()
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
                lbl.Text = "Bank Reconciliation Voucher";
                ctrlVoucher.MenuName = "BankReconciliationJournal";
                ctrlVoucher.GridCaption = "Bank Reconciliation Voucher";
                ctrlVoucher.VoucherType = 11;
                ctrlVoucher.prifix = "BRJ";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}