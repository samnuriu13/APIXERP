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
using REPORT.DAO;
using System.Data.SqlClient;

namespace API.Controls
{
    public partial class StockTransaction : System.Web.UI.UserControl
    {
        HKEntryManager hkManager = new HKEntryManager();
        StockTransactionManager manager = new StockTransactionManager();
        CurrencyManager _CurrencyManager = new CurrencyManager();
        ContactInfoManager _contactInfoManager = new ContactInfoManager();
        private string _MenuName;

        public string MenuName
        {
            get { return _MenuName; }
            set { _MenuName = value; }
        }

        private Int32 _TransType;
        public Int32 TransType
        {
            get { return _TransType; }
            set { _TransType = value; }
        }

        private String _NatureOfTrans;
        public String NatureOfTrans
        {
            get { return _NatureOfTrans; }
            set { _NatureOfTrans = value; }
        }

        private Int32 _DocListID;
        public Int32 DocListID
        {
            get { return _DocListID; }
            set { _DocListID = value; }
        }

        private string _GridCaption;

        public string GridCaption
        {
            get { return _GridCaption; }
            set { _GridCaption = value; }
        }

        #region Session Variables
        private CustomList<ItemGroup> ItemGroupList
        {
            get
            {
                if (Session["StockTransaction_ItemGroupList"] == null)
                    return new CustomList<ItemGroup>();
                else
                    return (CustomList<ItemGroup>)Session["StockTransaction_ItemGroupList"];
            }
            set
            {
                Session["StockTransaction_ItemGroupList"] = value;
            }
        }
        private CustomList<ItemSubGroup> ItemSubGroupList
        {
            get
            {
                if (Session["StockTransaction_ItemSubGroupList"] == null)
                    return new CustomList<ItemSubGroup>();
                else
                    return (CustomList<ItemSubGroup>)Session["StockTransaction_ItemSubGroupList"];
            }
            set
            {
                Session["StockTransaction_ItemSubGroupList"] = value;
            }
        }
        private CustomList<StockTransactionMaster> StockTransactionMasterList
        {
            get
            {
                if (Session[_MenuName + "_StockTransactionMasterList"] == null)
                    return new CustomList<StockTransactionMaster>();
                else
                    return (CustomList<StockTransactionMaster>)Session[_MenuName + "_StockTransactionMasterList"];
            }
            set
            {
                Session[_MenuName + "_StockTransactionMasterList"] = value;
            }
        }
        private CustomList<StockTransactionDetail> StockTransactionDetailList
        {
            get
            {
                if (Session[_MenuName + "_StockTransactionDetailList"] == null)
                    return new CustomList<StockTransactionDetail>();
                else
                    return (CustomList<StockTransactionDetail>)Session[_MenuName + "_StockTransactionDetailList"];
            }
            set
            {
                Session[_MenuName + "_StockTransactionDetailList"] = value;
            }
        }
        private CustomList<ItemMaster> ItemMasterList
        {
            get
            {
                if (Session["StockTransaction_ItemMasterList"] == null)
                    return new CustomList<ItemMaster>();
                else
                    return (CustomList<ItemMaster>)Session["StockTransaction_ItemMasterList"];
            }
            set
            {
                Session["StockTransaction_ItemMasterList"] = value;
            }
        }
        private CustomList<UnitSetup> UnitSetupList
        {
            get
            {
                if (Session["StockTransaction_UnitSetupList"] == null)
                    return new CustomList<UnitSetup>();
                else
                    return (CustomList<UnitSetup>)Session["StockTransaction_UnitSetupList"];
            }
            set
            {
                Session["StockTransaction_UnitSetupList"] = value;
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
        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack.IsFalse())
                {
                    InitializeCombo();
                    InitializeSession();
                }
                else
                {
                    Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                    String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                    if (Request["__EVENTTARGET"] == "SearchStockTransaction")
                    {
                        StockTransactionMasterList = new CustomList<StockTransactionMaster>();
                        StockTransactionMaster searchStockTransactionMaster = Session[STATIC.StaticInfo.SearchSessionVarName] as StockTransactionMaster;
                        StockTransactionMasterList.Add(searchStockTransactionMaster);
                        PopulateStockTransaction(searchStockTransactionMaster);
                    }
                }
                TransRef.DocListID = DocListID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #region All Methods
        private void PopulateStockTransaction(StockTransactionMaster objSTM)
        {
            try
            {
                txtCustomCode.Text = objSTM.CustomCode;
                txtTransactionDate.Text = objSTM.TransDate.ToShortDateString();
                if (objSTM.FromCostCenterID != 0)
                    ddlFromCostCentre.SelectedValue = objSTM.FromCostCenterID.ToString();
                if (objSTM.FromStockLocationID != 0)
                    ddlFromStockLocation.SelectedValue = objSTM.FromStockLocationID.ToString();
                if (objSTM.ToCostCenterID != 0)
                    ddlToCostCentre.SelectedValue = objSTM.ToCostCenterID.ToString();
                if (objSTM.ToStockLocationID != 0)
                    ddlToStockLocation.SelectedValue = objSTM.ToStockLocationID.ToString();
                if (objSTM.DeptID != 0)
                    ddlDepartment.SelectedValue = objSTM.DeptID.ToString();
                if (objSTM.PartyID != 0)
                    ddlParty.SelectedValue = objSTM.PartyID.ToString();
                if (objSTM.CurrencyID != 0)
                    ddlCurrencyID.SelectedValue = objSTM.CurrencyID.ToString();
                StockTransactionDetailList = new CustomList<StockTransactionDetail>();
                StockTransactionDetailList = manager.GetAllStockTransactionDetail(objSTM.StockTransID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void InitializeCombo()
        {
            ddlFromCostCentre.DataSource = hkManager.GetAllHouseKeeping(31);
            ddlFromCostCentre.DataTextField = "HKName";
            ddlFromCostCentre.DataValueField = "HKID";
            ddlFromCostCentre.DataBind();
            ddlFromCostCentre.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlFromCostCentre.SelectedIndex = 0;

            ddlFromStockLocation.DataSource = hkManager.GetAllHouseKeeping(11);
            ddlFromStockLocation.DataTextField = "HKName";
            ddlFromStockLocation.DataValueField = "HKID";
            ddlFromStockLocation.DataBind();
            ddlFromStockLocation.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlFromStockLocation.SelectedIndex = 0;

            ddlToCostCentre.DataSource = hkManager.GetAllHouseKeeping(31);
            ddlToCostCentre.DataTextField = "HKName";
            ddlToCostCentre.DataValueField = "HKID";
            ddlToCostCentre.DataBind();
            ddlToCostCentre.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlToCostCentre.SelectedIndex = 0;

            ddlToStockLocation.DataSource = hkManager.GetAllHouseKeeping(11);
            ddlToStockLocation.DataTextField = "HKName";
            ddlToStockLocation.DataValueField = "HKID";
            ddlToStockLocation.DataBind();
            ddlToStockLocation.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlToStockLocation.SelectedIndex = 0;


            ddlDepartment.DataSource = hkManager.GetAllHouseKeeping(3);
            ddlDepartment.DataTextField = "HKName";
            ddlDepartment.DataValueField = "HKID";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlDepartment.SelectedIndex = 0;

            ddlCurrencyID.DataSource = _CurrencyManager.GetAllGen_Currency();
            ddlCurrencyID.DataTextField = "CurrencyName";
            ddlCurrencyID.DataValueField = "CurrencyKey";
            ddlCurrencyID.DataBind();
            ddlCurrencyID.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlCurrencyID.SelectedIndex = 0;

            ddlParty.DataSource = _contactInfoManager.GetAllSupplier();
            ddlParty.DataTextField = "Name";
            ddlParty.DataValueField = "ContactID";
            ddlParty.DataBind();
            ddlParty.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlParty.SelectedIndex = 0;
        }
        private void InitializeSession()
        {
            try
            {
                GroupItemManager GIManager = new GroupItemManager();
                ItemSubGroupManager SGManager = new ItemSubGroupManager();
                ItemMasterManager IMManager = new ItemMasterManager();
                UnitSetupManager USManager = new UnitSetupManager();

                ItemGroupList = new CustomList<ItemGroup>();
                ItemGroupList = GIManager.DeptWiseItemGroup(41);
                ItemSubGroupList = new CustomList<ItemSubGroup>();
                ItemSubGroupList = SGManager.GetAllItemSubGroup();
                ItemMasterList = new CustomList<ItemMaster>();
                ItemMasterList = IMManager.FindAllItemMasterGroupWise();

                StockTransactionDetailList = new CustomList<StockTransactionDetail>();
                UnitSetupList = new CustomList<UnitSetup>();
                UnitSetupList = USManager.GetAllUnitSetup();
                StockTransactionMasterList = new CustomList<StockTransactionMaster>();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        public void ClearControls()
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
        private void SetDataFromControlToObj(ref CustomList<StockTransactionMaster> lstStockTransactionMaster)
        {
            try
            {
                StockTransactionMaster obj = lstStockTransactionMaster[0];
                obj.TransDate = txtTransactionDate.Text.ToDateTime();
                if (ddlFromCostCentre.SelectedValue != "")
                    obj.FromCostCenterID = ddlFromCostCentre.SelectedValue.ToInt();
                if (ddlToCostCentre.SelectedValue != "")
                    obj.ToCostCenterID = ddlToCostCentre.SelectedValue.ToInt();
                if (ddlParty.SelectedValue != "")
                    obj.PartyID = ddlParty.SelectedValue.ToInt();
                if (ddlDepartment.SelectedValue != "")
                    obj.DeptID = ddlDepartment.SelectedValue.ToInt();
                if (ddlFromStockLocation.SelectedValue != "")
                    obj.FromStockLocationID = ddlFromStockLocation.SelectedValue.ToInt();
                if (ddlToStockLocation.SelectedValue != "")
                    obj.ToStockLocationID = ddlToStockLocation.SelectedValue.ToInt();
                if (ddlCurrencyID.SelectedValue != "")
                    obj.CurrencyID = ddlCurrencyID.SelectedValue.ToInt();
                // obj.Description =  txtNote.Text;
                obj.TransType = TransType;
                obj.NatureOfTrans = NatureOfTrans;
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
                CustomList<StockTransactionMaster> items = manager.GetAllStockTransactionMaster(TransType);
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("CustomCode", "Custom Code");
                columns.Add("TransDate", "Transaction Date");
                columns.Add("Description", "Note");
                columns.Add("FromCostCenter", "From CostCenter");
                columns.Add("ToCostCenter", "To CostCenter");
                columns.Add("Department", "Department");

                StaticInfo.SearchItem(items, "Stock Transaction", "SearchStockTransaction", FRAMEWORK.SearchColumnConfig.GetColumnConfig(typeof(StockTransactionMaster), columns), 600);
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
                InitializeSession();
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
                CustomList<StockTransactionMaster> lstStockTransactionMaster = StockTransactionMasterList;
                if (lstStockTransactionMaster.Count == 0)
                {
                    StockTransactionMaster newStockTransactionMaster = new StockTransactionMaster();
                    lstStockTransactionMaster.Add(newStockTransactionMaster);
                }
                SetDataFromControlToObj(ref lstStockTransactionMaster);
                CustomList<StockTransactionDetail> lstStockTransactionDetail = (CustomList<StockTransactionDetail>)StockTransactionDetailList;

                if (!((PageBase)this.Page).CheckUserAuthentication(lstStockTransactionMaster, lstStockTransactionDetail)) return;
                manager.SaveStockTransaction(ref lstStockTransactionMaster, ref lstStockTransactionDetail);
                txtCustomCode.Text = manager.CustomCode;
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
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {

                ClearControls();
                InitializeSession();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<StockTransactionMaster> lstStockTransactionMaster = (CustomList<StockTransactionMaster>)StockTransactionMasterList;
                lstStockTransactionMaster.ForEach(f => f.Delete());
                CustomList<StockTransactionDetail> lstStockTransactionDetail = (CustomList<StockTransactionDetail>)StockTransactionDetailList;
                lstStockTransactionDetail.ForEach(s => s.Delete());
                if (((PageBase)this.Page).CheckUserAuthentication(lstStockTransactionMaster, lstStockTransactionDetail).IsFalse()) return;
                manager.deleteStockTransaction(ref lstStockTransactionMaster, ref lstStockTransactionDetail);
                InitializeCombo();
                ClearControls();
                InitializeSession();
                ((PageBase)this.Page).ErrorMessage = (StaticInfo.DeletedSuccessfullyMsg);
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
        protected void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                Session["Account"] = "Transaction";
                if (StockTransactionMasterList.Count != 0)
                {
                    Session["StockTransID"] = StockTransactionMasterList[0].StockTransID.ToString();
                    Report.ReportPath = Server.MapPath(@"~\ASTReports\TransactionReport.rdl");
                    String script = "javascript:ShowReportViewer();";
                    if (((PageBase)this.Page).ClientScript.IsClientScriptBlockRegistered("scriptShowReportViewer").IsFalse())
                    {
                        ((PageBase)this.Page).ClientScript.RegisterStartupScript(this.GetType(), "scriptShowReportViewer", script, true);
                    }
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