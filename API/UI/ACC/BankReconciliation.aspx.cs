using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using API.BLL;
using ACC.BLL;
using API.DAO;
using ACC.DAO;
using STATIC;
using API.DATA;
using FRAMEWORK;
using System.Data.SqlClient;

namespace API.UI.ACC
{
    public partial class BankReconciliation : PageBase
    {
        HKEntryManager hkManager = new HKEntryManager();
        BankAccountManager _baManager = new BankAccountManager();
        BankReconciliationManager manager = new BankReconciliationManager();

        #region Constructur
        public BankReconciliation()
        {
            RequiresAuthorization = true;
        }
        #endregion

        #region Session Variable
        private CustomList<Acc_Voucher> VoucherList
        {
            get
            {
                if (Session["BankReconciliation_VoucherList"] == null)
                    return new CustomList<Acc_Voucher>();
                else
                    return (CustomList<Acc_Voucher>)Session["BankReconciliation_VoucherList"];
            }
            set
            {
                Session["BankReconciliation_VoucherList"] = value;
            }
        }
        private CustomList<AccChequeStatusList> ChequeStatusList
        {
            get
            {
                if (Session["BankReconciliation_ChequeStatusList"] == null)
                    return new CustomList<AccChequeStatusList>();
                else
                    return (CustomList<AccChequeStatusList>)Session["BankReconciliation_ChequeStatusList"];
            }
            set
            {
                Session["BankReconciliation_ChequeStatusList"] = value;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                InitializeCombo();
                VoucherList = new CustomList<Acc_Voucher>();
                ChequeStatusList = new CustomList<AccChequeStatusList>();
                ChequeStatusList = manager.GetAllAccChequeStatusList();
            }
        }
        #region All Methods
        private void InitializeCombo()
        {
            try
            {
                ddlCostCenter.DataSource = hkManager.GetAllHouseKeeping(3);
                ddlCostCenter.DataTextField = "HKName";
                ddlCostCenter.DataValueField = "HKID";
                ddlCostCenter.DataBind();
                ddlCostCenter.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlCostCenter.SelectedIndex = 0;

               ddlBranchOrUnit.DataSource = hkManager.GetAllHouseKeeping(31);
               ddlBranchOrUnit.DataTextField = "HKName";
               ddlBranchOrUnit.DataValueField = "HKID";
               ddlBranchOrUnit.DataBind();
               ddlBranchOrUnit.Items.Insert(0, new ListItem(String.Empty, String.Empty));
               ddlBranchOrUnit.SelectedIndex = 0;

                ddlBankBranch.DataSource = _baManager.GetAllCmnBankAccount();
                ddlBankBranch.DataTextField = "AccountNo";
                ddlBankBranch.DataValueField = "AccountID";
                ddlBankBranch.DataBind();
                ddlBankBranch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlBankBranch.SelectedIndex = 0;

            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
        #region Button Event
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                VoucherList = manager.GetAllAcc_Voucher(ddlCostCenter.SelectedValue == "" ? 0 : Convert.ToInt32(ddlCostCenter.SelectedValue), ddlBranchOrUnit.SelectedValue == "" ? 0 : Convert.ToInt32(ddlBranchOrUnit.SelectedValue), ddlBankBranch.SelectedValue == "" ? 0 : Convert.ToInt32(ddlBankBranch.SelectedValue), txtFromDate.Text, txtToDate.Text);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<Acc_Voucher> lstAccVoucher = VoucherList;

                if (!((PageBase)this.Page).CheckUserAuthentication(lstAccVoucher)) return;
                manager.SaveBankReconciliation(ref lstAccVoucher);
                ((PageBase)this.Page).SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);

            }
            catch (SqlException ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getSqlExceptionMessage(ex));
            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        #endregion
    }
}