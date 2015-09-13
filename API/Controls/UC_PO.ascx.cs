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
using REPORT.DAO;

namespace API.Controls
{
    public partial class UC_PO : System.Web.UI.UserControl
    {
        HKEntryManager hkManager = new HKEntryManager();
        POManager manager = new POManager();

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
        private CustomList<POMaster> POMasterList
        {
            get
            {
                if (Session["PO_POMasterList"] == null)
                    return new CustomList<POMaster>();
                else
                    return (CustomList<POMaster>)Session["PO_POMasterList"];
            }
            set
            {
                Session["PO_POMasterList"] = value;
            }
        }
        private CustomList<PODetail> PODetailList
        {
            get
            {
                if (Session["PO_PODetailList"] == null)
                    return new CustomList<PODetail>();
                else
                    return (CustomList<PODetail>)Session["PO_PODetailList"];
            }
            set
            {
                Session["PO_PODetailList"] = value;
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
                    if (Request["__EVENTTARGET"] == "SearchPO")
                    {
                        POMasterList = new CustomList<POMaster>();
                        POMaster searchPOMaster = Session[STATIC.StaticInfo.SearchSessionVarName] as POMaster;
                        POMasterList.Add(searchPOMaster);
                        PopulatePO(searchPOMaster);
                    }
                }
                TransRef.DocListID = 258;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #region All Methods
        private void PopulatePO(POMaster objPO)
        {
            try
            {
                txtCustomCode.Text = objPO.CustomCode;
                txtTransactionDate.Text = objPO.PODate.ToShortDateString();
                ddlCostCentre.SelectedValue = objPO.CostCenterID.ToString();
                ddlDepartment.SelectedValue = objPO.DeptID.ToString();
                txtNote.Text = objPO.Description;
                txtShipTo.Text = objPO.ShipTo;
                txtBillTo.Text = objPO.BillTo;
                txtExpectedReceiveDate.Text = objPO.ExpectedReceiptDate.ToShortDateString();
                ddlParty.SelectedValue = objPO.SupplierID.ToString();
                PODetailList = new CustomList<PODetail>();
                PODetailList = manager.GetAllPODetail(objPO.POID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void InitializeCombo()
        {
            ddlCostCentre.DataSource = hkManager.GetAllHouseKeeping(31);
            ddlCostCentre.DataTextField = "HKName";
            ddlCostCentre.DataValueField = "HKID";
            ddlCostCentre.DataBind();
            ddlCostCentre.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlCostCentre.SelectedIndex = 0;

            ddlDepartment.DataSource = hkManager.GetAllHouseKeeping(3);
            ddlDepartment.DataTextField = "HKName";
            ddlDepartment.DataValueField = "HKID";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlDepartment.SelectedIndex = 0;

            ContactInfoManager cIM = new ContactInfoManager();
            ddlParty.DataSource = cIM.GetAllContactInfo();
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

                PODetailList = new CustomList<PODetail>();
                UnitSetupList = new CustomList<UnitSetup>();
                UnitSetupList = USManager.GetAllUnitSetup();
                POMasterList = new CustomList<POMaster>();
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
        private void SetDataFromControlToObj(ref CustomList<POMaster> lstPOMaster)
        {
            try
            {
                POMaster obj = lstPOMaster[0];
                obj.PODate = txtTransactionDate.Text.ToDateTime();
                if (ddlCostCentre.SelectedValue != "")
                    obj.CostCenterID = ddlCostCentre.SelectedValue.ToInt();
                if (ddlDepartment.SelectedValue != "")
                    obj.DeptID = ddlDepartment.SelectedValue.ToInt();
                if (ddlParty.SelectedValue != "")
                    obj.SupplierID = ddlParty.SelectedValue.ToInt();
                obj.Description = txtNote.Text;
                obj.BillTo = txtBillTo.Text;
                obj.ShipTo = txtShipTo.Text;
                obj.ExpectedReceiptDate = txtExpectedReceiveDate.Text.ToDateTime();
                obj.TransType = 3;
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
                CustomList<POMaster> items = manager.GetAllPOMasterFind();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("CustomCode", "Requisition No");
                columns.Add("PODate", "PO Date");
                columns.Add("Description", "Note");
                columns.Add("CostCenter", "CostCenter");
                columns.Add("Department", "Department");

                StaticInfo.SearchItem(items, "POMaster", "SearchPO", FRAMEWORK.SearchColumnConfig.GetColumnConfig(typeof(POMaster), columns), 600);
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
                CustomList<POMaster> lstPOMaster = POMasterList;
                if (lstPOMaster.Count == 0)
                {
                    POMaster newPOMaster = new POMaster();
                    lstPOMaster.Add(newPOMaster);
                }
                SetDataFromControlToObj(ref lstPOMaster);
                CustomList<PODetail> lstPODetail = (CustomList<PODetail>)PODetailList;

                if (!((PageBase)this.Page).CheckUserAuthentication(lstPOMaster, lstPODetail)) return;
                manager.SavePO(ref lstPOMaster, ref lstPODetail);
                InitializeCombo();
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
                CustomList<POMaster> lstPOMaster = (CustomList<POMaster>)POMasterList;
                lstPOMaster.ForEach(f => f.Delete());
                CustomList<PODetail> lstPODetail = (CustomList<PODetail>)PODetailList;
                PODetailList.ForEach(s => s.Delete());
                if (((PageBase)this.Page).CheckUserAuthentication(lstPOMaster, lstPODetail).IsFalse()) return;
                manager.SavePO(ref lstPOMaster, ref lstPODetail);
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
                Session["Account"] = "PO";
                if (POMasterList.Count != 0)
                {
                    Session["POID"] = POMasterList[0].POID.ToString();
                    Report.ReportPath = Server.MapPath(@"~\ASTReports\PurchaseOrder.rdl");
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