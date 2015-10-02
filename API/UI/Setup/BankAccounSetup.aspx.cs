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

namespace API.UI.Setup
{
    public partial class BankAccounSetup : PageBase
    {
        HKEntryManager hkManager = new HKEntryManager();
        ContactInfoManager _CIManager = new ContactInfoManager();
        COAManager _COAManager = new COAManager();
        BankAccountManager manager = new BankAccountManager();

        #region Constructur
        public BankAccounSetup()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Variable
        private CustomList<CmnBankAccount> BankAccountList
        {
            get
            {
                if (Session["BankAccounSetup_BankAccountList"] == null)
                    return new CustomList<CmnBankAccount>();
                else
                    return (CustomList<CmnBankAccount>)Session["BankAccounSetup_BankAccountList"];
            }
            set
            {
                Session["BankAccounSetup_BankAccountList"] = value;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                InitializeCombo();
                BankAccountList = new CustomList<CmnBankAccount>();
            }
            else
            {
                Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                if (Request["__EVENTTARGET"] == "SearchBankAccount")
                {
                    BankAccountList = new CustomList<CmnBankAccount>();
                    CmnBankAccount searchBankAccount = Session[STATIC.StaticInfo.SearchSessionVarName] as CmnBankAccount;
                    BankAccountList.Add(searchBankAccount);
                    if (searchBankAccount.IsNotNull())
                    {
                        PopulateBankAccountInformation(searchBankAccount);
                    }
                }
            }
        }
        #region All Methods
        private void PopulateBankAccountInformation(CmnBankAccount bankAccount)
        {
            try
            {
                if (bankAccount.CostCenterID != 0)
                    ddlCostCenter.SelectedValue = bankAccount.CostCenterID.ToString();
                if (bankAccount.BranchOrUnitID != 0)
                   ddlBranchOrUnit.SelectedValue = bankAccount.BranchOrUnitID.ToString();
                txtAccountNo.Text = bankAccount.AccountNo;
                txtAccountName.Text = bankAccount.AccountName;
                if (bankAccount.AccountTypeID != 0)
                    ddlAccountType.SelectedValue = bankAccount.AccountTypeID.ToString();
                if (bankAccount.BankBranchID != 0)
                    ddlBankBranch.SelectedValue = bankAccount.BankBranchID.ToString();
                if (bankAccount.UserID != 0)
                    ddlUserName.SelectedValue = bankAccount.UserID.ToString();
                if (bankAccount.COAID != 0)
                    ddlCOA.SelectedValue = bankAccount.COAID.ToString();
                chkIsCompanyAccount.Checked = bankAccount.IsCompany;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
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

                ddlAccountType.DataSource = manager.GetAllCmnBankAccountType();
                ddlAccountType.DataTextField = "AccountTypeName";
                ddlAccountType.DataValueField = "AccountTypeID";
                ddlAccountType.DataBind();
                ddlAccountType.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlAccountType.SelectedIndex = 0;

                ddlBankBranch.DataSource = manager.GetAllBank_Branch();
                ddlBankBranch.DataTextField = "BranchName";
                ddlBankBranch.DataValueField = "BranchKey";
                ddlBankBranch.DataBind();
                ddlBankBranch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlBankBranch.SelectedIndex = 0;

                ddlUserName.DataSource = _CIManager.GetAllContactInfo();
                ddlUserName.DataTextField = "Name";
                ddlUserName.DataValueField = "ContactID";
                ddlUserName.DataBind();
                ddlUserName.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlUserName.SelectedIndex = 0;

                ddlCOA.DataSource = _COAManager.GetAllAcc_COA_ByLevel(5);
                ddlCOA.DataTextField = "COAName";
                ddlCOA.DataValueField = "COAKey";
                ddlCOA.DataBind();
                ddlCOA.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlCOA.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void SetDataFromControlToObj(ref CustomList<CmnBankAccount> lstBankAccount)
        {
            try
            {
                CmnBankAccount obj = lstBankAccount[0];
                if (ddlCostCenter.SelectedValue != "")
                    obj.CostCenterID = ddlCostCenter.SelectedValue.ToInt();
                if (ddlBranchOrUnit.SelectedValue != "")
                    obj.BranchOrUnitID = ddlBranchOrUnit.SelectedValue.ToInt();
                obj.AccountNo = txtAccountNo.Text;
                obj.AccountName = txtAccountName.Text;
                if (ddlAccountType.SelectedValue != "")
                    obj.AccountTypeID = ddlAccountType.SelectedValue.ToInt();
                if (ddlBankBranch.SelectedValue != "")
                    obj.BankBranchID = ddlBankBranch.SelectedValue.ToInt();
                if (ddlUserName.SelectedValue != "")
                    obj.UserID = ddlUserName.SelectedValue.ToInt();
                if (ddlCOA.SelectedValue != "")
                    obj.COAID = ddlCOA.SelectedValue.ToInt();
                obj.IsCompany = chkIsCompanyAccount.Checked;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void ClearControls()
        {
            try
            {
                FormUtil.ClearForm(this, FormClearOptions.ClearAll, false);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
        #region Button Event
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CustomList<CmnBankAccount> items = manager.GetAllCmnBankAccount();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("AccountName", "Account Name");
                columns.Add("AccountNo", "Account No");
                columns.Add("BranchName", "Branch");



                StaticInfo.SearchItem(items, "Bank Account", "SearchBankAccount", FRAMEWORK.SearchColumnConfig.GetColumnConfig(typeof(CmnBankAccount), columns), 500);
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<CmnBankAccount> lstCmnBankAccount = BankAccountList;
                if (lstCmnBankAccount.Count == 0)
                {
                    CmnBankAccount newBankAccount = new CmnBankAccount();
                    lstCmnBankAccount.Add(newBankAccount);
                }
                SetDataFromControlToObj(ref lstCmnBankAccount);

                if (!CheckUserAuthentication(lstCmnBankAccount)) return;
                manager.SaveBankAccount(ref lstCmnBankAccount);
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
        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {

                ClearControls();
                BankAccountList = new CustomList<CmnBankAccount>();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {

                ClearControls();
                BankAccountList = new CustomList<CmnBankAccount>();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
    }
}