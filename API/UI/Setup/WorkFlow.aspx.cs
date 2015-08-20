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
using SECURITY.BLL;
using SECURITY.DAO;
using System.Data.SqlClient;

namespace API.UI.Setup
{
    public partial class WorkFlow : PageBase
    {
        StatusListManager _stManager = new StatusListManager();
        ContactInfoManager _uiManager = new ContactInfoManager();
        HKEntryManager _hkManager = new HKEntryManager();
        ApplicationManager _aManager = new ApplicationManager();
        WorkFlowManager _manager = new WorkFlowManager();

        #region Constructur
        public WorkFlow()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Variables
        private CustomList<CmnStatusList> lstCmnStatusList
        {
            get
            {
                if (Session["WorkFlow_lstCmnStatusList"] == null)
                    return new CustomList<CmnStatusList>();
                else
                    return (CustomList<CmnStatusList>)Session["WorkFlow_lstCmnStatusList"];
            }
            set
            {
                Session["WorkFlow_lstCmnStatusList"] = value;
            }
        }

        private CustomList<ContactInfo> UserList
        {
            get
            {
                if (Session["WorkFlow_UserList"] == null)
                    return new CustomList<ContactInfo>();
                else
                    return (CustomList<ContactInfo>)Session["WorkFlow_UserList"];
            }
            set
            {
                Session["WorkFlow_UserList"] = value;
            }
        }

        private CustomList<CmnWorkFlowMaster> CmnWorkFlowMasterList
        {
            get
            {
                if (Session["WorkFlow_CmnWorkFlowMasterList"] == null)
                    return new CustomList<CmnWorkFlowMaster>();
                else
                    return (CustomList<CmnWorkFlowMaster>)Session["WorkFlow_CmnWorkFlowMasterList"];
            }
            set
            {
                Session["WorkFlow_CmnWorkFlowMasterList"] = value;
            }
        }

        private CustomList<CmnWorkFlowDetail> CmnWorkFlowDetailList
        {
            get
            {
                if (Session["WorkFlow_CmnWorkFlowDetailList"] == null)
                    return new CustomList<CmnWorkFlowDetail>();
                else
                    return (CustomList<CmnWorkFlowDetail>)Session["WorkFlow_CmnWorkFlowDetailList"];
            }
            set
            {
                Session["WorkFlow_CmnWorkFlowDetailList"] = value;
            }
        }
        #endregion
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
                    if (Request["__EVENTTARGET"] == "SearchWF")
                    {
                        CmnWorkFlowMasterList = new CustomList<CmnWorkFlowMaster>();
                        CmnWorkFlowMaster searchWorkFlowMaster = Session[STATIC.StaticInfo.SearchSessionVarName] as CmnWorkFlowMaster;
                        CmnWorkFlowMasterList.Add(searchWorkFlowMaster);
                        PopulateWorkFlowMaster(searchWorkFlowMaster);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #region All Methods
        private void PopulateWorkFlowMaster(CmnWorkFlowMaster objWF)
        {
            try
            {
                txtWorkFlowID.Text = objWF.WorkFlowID.ToString();
                ddlCostCenter.SelectedValue = objWF.CostCenterID.ToString();
                ddlDepartment.SelectedValue = objWF.DeptID.ToString();
                ddlDocList.SelectedValue = objWF.DocListID.ToString();
                txtSequence.Text = objWF.Sequence.ToString();
                CmnWorkFlowDetailList = new CustomList<CmnWorkFlowDetail>();
                CmnWorkFlowDetailList = _manager.GetAllCmnWorkFlowDetail(objWF.WorkFlowID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void InitializeCombo()
        {
            ddlCostCenter.DataSource = _hkManager.GetAllHouseKeeping(31);
            ddlCostCenter.DataTextField = "HKName";
            ddlCostCenter.DataValueField = "HKID";
            ddlCostCenter.DataBind();
            ddlCostCenter.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlCostCenter.SelectedIndex = 0;

            ddlDepartment.DataSource = _hkManager.GetAllHouseKeeping(3);
            ddlDepartment.DataTextField = "HKName";
            ddlDepartment.DataValueField = "HKID";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlDepartment.SelectedIndex = 0;

            ddlDocList.DataSource = _aManager.GetAllMenuList();
            ddlDocList.DataTextField = "DisplayMember";
            ddlDocList.DataValueField = "MenuID";
            ddlDocList.DataBind();
            ddlDocList.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlDocList.SelectedIndex = 0;
        }
        private void InitializeSession()
        {
            try
            {
                lstCmnStatusList = new CustomList<CmnStatusList>();
                lstCmnStatusList = _stManager.GetAllCmnStatusList();
                UserList = new CustomList<ContactInfo>();
                UserList = _uiManager.GetAllContactInfo();
                CmnWorkFlowDetailList = new CustomList<CmnWorkFlowDetail>();
                CmnWorkFlowMasterList = new CustomList<CmnWorkFlowMaster>();
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
        private void SetDataFromControlToObj(ref CustomList<CmnWorkFlowMaster> lstCmnWorkFlowMaster)
        {
            try
            {
                CmnWorkFlowMaster obj = lstCmnWorkFlowMaster[0];
                if (ddlDocList.SelectedValue != "")
                    obj.DocListID = ddlDocList.SelectedValue.ToInt();
                if (ddlCostCenter.SelectedValue != "")
                    obj.CostCenterID = ddlCostCenter.SelectedValue.ToInt();
                if (ddlDepartment.SelectedValue != "")
                    obj.DeptID = ddlDepartment.SelectedValue.ToInt();
                obj.Sequence = txtSequence.Text.ToInt();
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
                CustomList<CmnWorkFlowMaster> items = _manager.GetAllCmnWorkFlowMasterFind();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("DocName", "Menu Name");
                columns.Add("Sequence", "Sequence");
                columns.Add("CostCenter", "CostCenter");
                columns.Add("Department", "Department");

                StaticInfo.SearchItem(items, "Work Flow", "SearchWF", FRAMEWORK.SearchColumnConfig.GetColumnConfig(typeof(CmnWorkFlowMaster), columns), 600);
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
                CustomList<CmnWorkFlowMaster> lstCmnWorkFlowMaster = CmnWorkFlowMasterList;
                if (lstCmnWorkFlowMaster.Count == 0)
                {
                    CmnWorkFlowMaster newCmnWorkFlowMaster = new CmnWorkFlowMaster();
                    lstCmnWorkFlowMaster.Add(newCmnWorkFlowMaster);
                }
                SetDataFromControlToObj(ref lstCmnWorkFlowMaster);
                CustomList<CmnWorkFlowDetail> lstCmnWorkFlowDetail = (CustomList<CmnWorkFlowDetail>)CmnWorkFlowDetailList;

                if (!((PageBase)this.Page).CheckUserAuthentication(lstCmnWorkFlowMaster, lstCmnWorkFlowDetail)) return;
                _manager.SaveWorkFlow(ref lstCmnWorkFlowMaster, ref lstCmnWorkFlowDetail);
                txtWorkFlowID.Text = _manager.WorkFlowID.ToString();
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
                CustomList<CmnWorkFlowMaster> lstCmnWorkFlowMaster = (CustomList<CmnWorkFlowMaster>)CmnWorkFlowMasterList;
                lstCmnWorkFlowMaster.ForEach(f => f.Delete());
                CustomList<CmnWorkFlowDetail> lstCmnWorkFlowDetail = (CustomList<CmnWorkFlowDetail>)CmnWorkFlowDetailList;
                lstCmnWorkFlowDetail.ForEach(s => s.Delete());
                if (((PageBase)this.Page).CheckUserAuthentication(lstCmnWorkFlowMaster, lstCmnWorkFlowDetail).IsFalse()) return;
                _manager.deleteWrokFlow(ref lstCmnWorkFlowMaster, ref lstCmnWorkFlowDetail);
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