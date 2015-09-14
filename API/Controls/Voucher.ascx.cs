using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACC.BLL;
using API.BLL;
using ACC.DAO;
using STATIC;
using API.DATA;
using FRAMEWORK;
using API.DAO;
using REPORT.DAO;
using System.Data.SqlClient;

namespace API.Controls
{
    public partial class Voucher : System.Web.UI.UserControl
    {
        HKEntryManager hkManager = new HKEntryManager();
        CurrencyManager _CurrencyManager = new CurrencyManager();
        VoucherManager manager = new VoucherManager();
        ContactInfoManager _contactInfoManager = new ContactInfoManager();
        WorkFlowTransactionManager _WF = new WorkFlowTransactionManager();

        private string _MenuName;

        public string MenuName
        {
            get { return _MenuName; }
            set { _MenuName = value; }
        }

        private Int32 _DocListFormatID;

        public Int32 DocListFormatID
        {
            get { return _DocListFormatID; }
            set { _DocListFormatID = value; }
        }

        private Int32 _MenuID;
        public Int32 MenuID
        {
            get { return _MenuID; }
            set { _MenuID = value; }
        }

        private Int32 _StatusID;
        public Int32 StatusID
        {
            get { return _StatusID; }
            set { _StatusID = value; }
        }

        private String _UserCode;
        public String UserCode
        {
            get { return _UserCode; }
            set { _UserCode = value; }
        }

        private string _GridCaption;
        public string GridCaption
        {
            get { return _GridCaption; }
            set { _GridCaption = value; }
        }

        private string _prifix;
        public string prifix
        {
            get { return _prifix; }
            set { _prifix = value; }
        }

        private Int32 _VoucherType;

        public Int32 VoucherType
        {
            get { return _VoucherType; }
            set { _VoucherType = value; }
        }


        #region Session
        private CustomList<Acc_Voucher> AccVoucherList
        {
            get
            {
                if (Session[_MenuName + "_AccVoucherList"] == null)
                    return new CustomList<Acc_Voucher>();
                else
                    return (CustomList<Acc_Voucher>)Session[_MenuName + "_AccVoucherList"];
            }
            set
            {
                Session[_MenuName + "_AccVoucherList"] = value;
            }
        }
        private CustomList<Acc_VoucherDet> AccVoucherDetList
        {
            get
            {
                if (Session[_MenuName + "_AccVoucherDetList"] == null)
                    return new CustomList<Acc_VoucherDet>();
                else
                    return (CustomList<Acc_VoucherDet>)Session[_MenuName + "_AccVoucherDetList"];
            }
            set
            {
                Session[_MenuName + "_AccVoucherDetList"] = value;
            }
        }
        private CustomList<Acc_COA> AccCOAList
        {
            get
            {
                if (Session["Voucher_AccCOAList"] == null)
                    return new CustomList<Acc_COA>();
                else
                    return (CustomList<Acc_COA>)Session["Voucher_AccCOAList"];
            }
            set
            {
                Session["Voucher_AccCOAList"] = value;
            }
        }

        private CustomList<ContactInfo> ContactInfoList
        {
            get
            {
                if (Session["Voucher_ContactInfoList"] == null)
                    return new CustomList<ContactInfo>();
                else
                    return (CustomList<ContactInfo>)Session["Voucher_ContactInfoList"];
            }
            set
            {
                Session["Voucher_ContactInfoList"] = value;
            }
        }
        private RDLReportDocument Report
        {
            get
            {
                if (Session["ReportViewer_Report"].IsNull())
                    Session["ReportViewer_Report"] = new RDLReportDocument();
                //
                return (RDLReportDocument)Session["ReportViewer_Report"];
            }
            set
            {
                Session["ReportViewer_Report"] = value;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                String match = HttpContext.Current.Request.QueryString["Match"];
                if (match == "editVoucher")
                {
                    InitializeCombo();
                    InitializeSession();
                    String vocherNo = HttpContext.Current.Request.QueryString["VoucherNo"];
                    Acc_Voucher item = manager.GetAllAcc_Voucher(vocherNo);
                    CustomList<Acc_Voucher> VoucherList = new CustomList<Acc_Voucher>();
                    VoucherList.Add(item);
                    AccVoucherList = VoucherList;
                    PopulatePFVoucherInformation(item);
                }
                else
                {
                    InitializeCombo();
                    btnNew_Click(null, null);
                }
            }
            else
            {
                Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                if (eventTarget == "SearchVoucher")
                {
                    Acc_Voucher searchAccVoucher = Session[STATIC.StaticInfo.SearchSessionVarName] as Acc_Voucher;
                    CustomList<Acc_Voucher> VoucherList = new CustomList<Acc_Voucher>();
                    VoucherList.Add(searchAccVoucher);
                    AccVoucherList = VoucherList;
                    if (searchAccVoucher.IsNotNull())
                        PopulatePFVoucherInformation(searchAccVoucher);
                }
                else if (eventTarget == "vou_delete")
                {
                    btnDelete_Click(null, null);
                }
            }
        }

        #region All Methods
        private void PopulatePFVoucherInformation(Acc_Voucher aV)
        {
            try
            {
                SetDataInControls(aV);
                AccVoucherDetList = manager.GetAllAcc_VoucherDet(aV.VoucherKey);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void SetDataInControls(Acc_Voucher aV)
        {
            try
            {
                txtVoucher.Text = aV.VoucherNo;
                txtVoucherDate_nc.Text = aV.VoucherDate == DateTime.MinValue ? string.Empty : aV.VoucherDate.ToString(STATIC.StaticInfo.GridDateFormat);
                if (aV.CostCenterID != 0)
                    ddlFromCostCentre.SelectedValue = aV.CostCenterID.ToString();
                if (aV.DeptID != 0)
                    ddlDeptID.SelectedValue = aV.DeptID.ToString();
                if (aV.CurrencyID != 0)
                    ddlCurrencyID.SelectedValue = aV.CurrencyID.ToString();
                txtChequeNo.Text = aV.CheckNo;
                txtChequeDate.Text = aV.CheckDate == DateTime.MinValue ? string.Empty : aV.CheckDate.ToString(StaticInfo.GridDateFormat);

                txtVoucherDescription.Text = aV.VoucherDesc;
                txtChequeNo.Text = aV.CheckNo;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void InitializeSession()
        {
            try
            {
                AccVoucherList = new CustomList<Acc_Voucher>();
                AccVoucherDetList = new CustomList<Acc_VoucherDet>();
                AccCOAList = new CustomList<Acc_COA>();
                AccCOAList = manager.GetAllAcc_COA_ByLevel(5);
                ContactInfoList = _contactInfoManager.GetAllContactInfo();
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
                ddlFromCostCentre.DataSource = hkManager.GetAllHouseKeeping(31);
                ddlFromCostCentre.DataTextField = "HKName";
                ddlFromCostCentre.DataValueField = "HKID";
                ddlFromCostCentre.DataBind();
                ddlFromCostCentre.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlFromCostCentre.SelectedIndex = 0;

                ddlDeptID.DataSource = hkManager.GetAllHouseKeeping(3);
                ddlDeptID.DataTextField = "HKName";
                ddlDeptID.DataValueField = "HKID";
                ddlDeptID.DataBind();
                ddlDeptID.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlDeptID.SelectedIndex = 0;

                ddlCurrencyID.DataSource = _CurrencyManager.GetAllGen_Currency();
                ddlCurrencyID.DataTextField = "CurrencyName";
                ddlCurrencyID.DataValueField = "CurrencyKey";
                ddlCurrencyID.DataBind();
                ddlCurrencyID.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlCurrencyID.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void SetDataFromControlToObject(ref CustomList<Acc_Voucher> lstAccVoucher)
        {
            try
            {
                Acc_Voucher obj = lstAccVoucher[0];
                obj.VoucherNo = txtVoucher.Text;
                obj.VoucherDate = txtVoucherDate_nc.Text.ToDateTime(STATIC.StaticInfo.GridDateFormat);
                if (ddlFromCostCentre.SelectedValue != "")
                    obj.CostCenterID = ddlFromCostCentre.SelectedValue.ToInt();
                if (ddlDeptID.SelectedValue != "")
                    obj.DeptID = ddlDeptID.SelectedValue.ToInt();
                if (ddlCurrencyID.SelectedValue != "")
                    obj.CurrencyID = ddlCurrencyID.SelectedValue.ToInt();
                obj.VoucherTypeKey = VoucherType;
                obj.VoucherDesc = txtVoucherDescription.Text;
                if (prifix == "BP" || prifix == "BR")
                {
                    obj.CheckNo = txtChequeNo.Text;
                    if (!string.IsNullOrEmpty(txtChequeDate.Text))
                        obj.CheckDate = txtChequeDate.Text.ToDateTime(STATIC.StaticInfo.GridDateFormat);
                }
                if (prifix == "BP")
                {
                    obj.ChequeType = 1;//1 For Issue
                    obj.ChequeStatus = 2;//2 For Issued
                }
                if (prifix == "BR")
                {
                    obj.ChequeType = 2;//2 For Receive
                    obj.ChequeStatus = 3;//3 For Received
                }
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion

        #region Button Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal totalDr = 0.0M;
                Decimal totalCr = 0.0M;
                CustomList<Acc_Voucher> lstAccVoucher = AccVoucherList;
                if (lstAccVoucher.Count == 0)
                {
                    Acc_Voucher newVoucher = new Acc_Voucher();
                    lstAccVoucher.Add(newVoucher);
                }
                SetDataFromControlToObject(ref lstAccVoucher);
                CustomList<Acc_VoucherDet> lstAccVoucherDet = AccVoucherDetList;
                foreach (Acc_VoucherDet vD in lstAccVoucherDet)
                {
                    totalDr += vD.Dr;
                    totalCr += vD.Cr;
                }
                if (totalDr == totalCr)
                {
                    if (!((PageBase)this.Page).CheckUserAuthentication(lstAccVoucher, lstAccVoucherDet)) return;
                    manager.SavePFVoucher(ref lstAccVoucher, ref lstAccVoucherDet, prifix);
                    if (StatusID > 0)
                        _WF.InsertWorkFlowTransaction(MenuID,StatusID, UserCode, 0, lstAccVoucher[0].VoucherKey, true, "", false, false);
                    ((PageBase)this.Page).SuccessMessage = (StaticInfo.SavedSuccessfullyMsg + ". Voucher No: " + manager.VoucherID);
                }
                else
                {
                    ((PageBase)this.Page).ErrorMessage = ("Dr and Cr must be equal.");
                    return;
                }
                btnNew_Click(null, null);
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
        protected void btnClear_Click(object sender, EventArgs e)
        {
            FormUtil.ClearForm(this, FormClearOptions.ClearAll, true);
            btnNew_Click(null, null);
        }
        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            FormUtil.ClearForm(this, FormClearOptions.ClearAll, true);
            InitializeSession();
            txtVoucherDate_nc.Text = DateTime.Now.ToString(StaticInfo.GridDateFormat);
            txtChequeDate.Text = DateTime.Now.ToString(StaticInfo.GridDateFormat);
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            CustomList<Acc_VoucherDet> lstAccVoucherDet = AccVoucherDetList;
            CustomList<Acc_Voucher> lstAccVoucher = AccVoucherList;
            if (!((PageBase)this.Page).CheckUserAuthentication(lstAccVoucherDet, lstAccVoucher).IsFalse()) return;
            manager.DeleteVoucher(ref lstAccVoucherDet, ref lstAccVoucher);
            btnNew_Click(null, null);
            txtVoucherDate_nc.Text = string.Empty;
            ((PageBase)this.Page).SuccessMessage = (StaticInfo.DeletedSuccessfullyMsg);
        }
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //FormUtil.ClearForm(this, FormClearOptions.ClearAll, false);
                InitializeSession();

                CustomList<Acc_Voucher> items = manager.GetAllAcc_Voucher(ddlFromCostCentre.SelectedValue.ToInt(), ddlDeptID.SelectedValue.ToInt(), VoucherType);
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("VoucherNo", "Voucher No");
                columns.Add("VoucherDate", "Voucher Date");

                StaticInfo.SearchItem(items, "Voucher", "SearchVoucher", FRAMEWORK.SearchColumnConfig.GetColumnConfig(typeof(Acc_Voucher), columns), 500);
            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = ("Error: <br>" + ex.Message + "<br>Call Stack: <br>" + ex.StackTrace);
            }
        }
        protected void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                Session["Account"] = "Voucher";
                Session["VoucherNo"] = txtVoucher.Text;
                Report.ReportPath = Server.MapPath(@"~\ASTReports\Voucher.rdl");
                String script = "javascript:ShowReportViewer();";
                if (((PageBase)this.Page).ClientScript.IsClientScriptBlockRegistered("scriptShowReportViewer").IsFalse())
                {
                    ((PageBase)this.Page).ClientScript.RegisterStartupScript(this.GetType(), "scriptShowReportViewer", script, true);
                }
            }
            catch (Exception ex)
            {

                throw (ex);
            }

        }
        #endregion
    }
}