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

namespace API.Controls
{
    public partial class UC_Requisition : System.Web.UI.UserControl
    {
        HKEntryManager hkManager = new HKEntryManager();
        RequisitionManager manager = new RequisitionManager();

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
                if (Session["ItemRequisition_ItemGroupList"] == null)
                    return new CustomList<ItemGroup>();
                else
                    return (CustomList<ItemGroup>)Session["ItemRequisition_ItemGroupList"];
            }
            set
            {
                Session["ItemRequisition_ItemGroupList"] = value;
            }
        }
        private CustomList<ItemSubGroup> ItemSubGroupList
        {
            get
            {
                if (Session["ItemRequisition_ItemSubGroupList"] == null)
                    return new CustomList<ItemSubGroup>();
                else
                    return (CustomList<ItemSubGroup>)Session["ItemRequisition_ItemSubGroupList"];
            }
            set
            {
                Session["ItemRequisition_ItemSubGroupList"] = value;
            }
        }
        private CustomList<ItemRequisitionMaster> ItemRequisitionMasterList
        {
            get
            {
                if (Session[_MenuName + "_ItemRequisitionMasterList"] == null)
                    return new CustomList<ItemRequisitionMaster>();
                else
                    return (CustomList<ItemRequisitionMaster>)Session[_MenuName + "_ItemRequisitionMasterList"];
            }
            set
            {
                Session[_MenuName + "_ItemRequisitionMasterList"] = value;
            }
        }
        private CustomList<ItemRequisitionDetail> ItemRequisitionDetailList
        {
            get
            {
                if (Session[_MenuName + "_ItemRequisitionDetailList"] == null)
                    return new CustomList<ItemRequisitionDetail>();
                else
                    return (CustomList<ItemRequisitionDetail>)Session[_MenuName + "_ItemRequisitionDetailList"];
            }
            set
            {
                Session[_MenuName + "_ItemRequisitionDetailList"] = value;
            }
        }
        private CustomList<ItemMaster> ItemMasterList
        {
            get
            {
                if (Session["ItemRequisition_ItemMasterList"] == null)
                    return new CustomList<ItemMaster>();
                else
                    return (CustomList<ItemMaster>)Session["ItemRequisition_ItemMasterList"];
            }
            set
            {
                Session["ItemRequisition_ItemMasterList"] = value;
            }
        }
        private CustomList<UnitSetup> UnitSetupList
        {
            get
            {
                if (Session["ItemRequisition_UnitSetupList"] == null)
                    return new CustomList<UnitSetup>();
                else
                    return (CustomList<UnitSetup>)Session["ItemRequisition_UnitSetupList"];
            }
            set
            {
                Session["ItemRequisition_UnitSetupList"] = value;
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
                    if (Request["__EVENTTARGET"] == "SearchRequisition")
                    {
                        ItemRequisitionMasterList = new CustomList<ItemRequisitionMaster>();
                        ItemRequisitionMaster searchItemRequisitionMaster = Session[STATIC.StaticInfo.SearchSessionVarName] as ItemRequisitionMaster;
                        ItemRequisitionMasterList.Add(searchItemRequisitionMaster);
                        PopulateRequisition(searchItemRequisitionMaster);
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
        private void PopulateRequisition(ItemRequisitionMaster objIRM)
        {
            try
            {
                txtRequisitionNo.Text = objIRM.CustomCode;
                txtRequisitionDate.Text = objIRM.RequisitionDate.ToShortDateString();
                ddlCostCentre.SelectedValue = objIRM.CostCenterID.ToString();
                ddlDepartment.SelectedValue = objIRM.DeptID.ToString();
                txtNote.Text = objIRM.Description;
                ItemRequisitionDetailList = new CustomList<ItemRequisitionDetail>();
                ItemRequisitionDetailList = manager.GetAllItemRequisitionDetail(objIRM.RequisitionID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InitializeCombo()
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
        }
        public void InitializeSession()
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

                ItemRequisitionDetailList = new CustomList<ItemRequisitionDetail>();
                UnitSetupList = new CustomList<UnitSetup>();
                UnitSetupList = USManager.GetAllUnitSetup();
                ItemRequisitionMasterList = new CustomList<ItemRequisitionMaster>();
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
        private void SetDataFromControlToObj(ref CustomList<ItemRequisitionMaster> lstItemRequisitionMaster)
        {
            try
            {
                ItemRequisitionMaster obj = lstItemRequisitionMaster[0];
                obj.RequisitionDate = txtRequisitionDate.Text.ToDateTime();
                if (ddlCostCentre.SelectedValue != "")
                    obj.CostCenterID = ddlCostCentre.SelectedValue.ToInt();
                if (ddlDepartment.SelectedValue != "")
                    obj.DeptID = ddlDepartment.SelectedValue.ToInt();
                if (ddlEmployee.SelectedValue != "")
                    obj.UserID = ddlEmployee.SelectedValue.ToInt();
                obj.Description = txtNote.Text;
                obj.RequisitionTypeID = TransType;
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
                CustomList<ItemRequisitionMaster> items = manager.GetAllItemRequisitionMaster(TransType);
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("CustomCode", "Requisition No");
                columns.Add("RequisitionDate", "Requisition Date");
                columns.Add("Description", "Note");
                columns.Add("CostCenter", "CostCenter");
                columns.Add("Department", "Department");

                StaticInfo.SearchItem(items, "ItemRequisitionMaster", "SearchRequisition", FRAMEWORK.SearchColumnConfig.GetColumnConfig(typeof(ItemRequisitionMaster), columns), 600);
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
                CustomList<ItemRequisitionMaster> lstItemRequisitionMaster = ItemRequisitionMasterList;
                if (lstItemRequisitionMaster.Count == 0)
                {
                    ItemRequisitionMaster newItemRequisitionMaster = new ItemRequisitionMaster();
                    lstItemRequisitionMaster.Add(newItemRequisitionMaster);
                }
                SetDataFromControlToObj(ref lstItemRequisitionMaster);
                CustomList<ItemRequisitionDetail> lstItemRequisitionDetail = (CustomList<ItemRequisitionDetail>)ItemRequisitionDetailList;

                if (!((PageBase)this.Page).CheckUserAuthentication(lstItemRequisitionMaster, lstItemRequisitionDetail)) return;
                manager.SaveRequisition(ref lstItemRequisitionMaster, ref lstItemRequisitionDetail);
                txtRequisitionNo.Text = manager.CustomCode;
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
                CustomList<ItemRequisitionMaster> lstItemRequisitionMaster = (CustomList<ItemRequisitionMaster>)ItemRequisitionMasterList;
                lstItemRequisitionMaster.ForEach(f => f.Delete());
                CustomList<ItemRequisitionDetail> lstItemRequisitionDetail = (CustomList<ItemRequisitionDetail>)ItemRequisitionDetailList;
                lstItemRequisitionDetail.ForEach(s => s.Delete());
                if (((PageBase)this.Page).CheckUserAuthentication(lstItemRequisitionMaster, lstItemRequisitionDetail).IsFalse()) return;
                manager.deleteRequisition(ref lstItemRequisitionMaster, ref lstItemRequisitionDetail);
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
        #endregion
    }
}