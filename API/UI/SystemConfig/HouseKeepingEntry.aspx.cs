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
using API.Controls;
using System.Collections;
using System.Data.SqlClient;

namespace API.UI.SystemConfig
{
    public partial class HouseKeepingEntry : PageBase
    {
        HKEntryManager manager = new HKEntryManager();
        #region Constructur
        public HouseKeepingEntry()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Variable
        private CustomList<HouseKeepingValue> HouseKeepingList
        {
            get
            {
                if (Session["HouseKeepingEntry_HouseKeepingList"] == null)
                    return new CustomList<HouseKeepingValue>();
                else
                    return (CustomList<HouseKeepingValue>)Session["HouseKeepingEntry_HouseKeepingList"];
            }
            set
            {
                Session["HouseKeepingEntry_HouseKeepingList"] = value;
            }
        }
        private CustomList<HouseKeepingValue> ParentList
        {
            get
            {
                if (Session["HouseKeepingEntry_ParentList"] == null)
                    return new CustomList<HouseKeepingValue>();
                else
                    return (CustomList<HouseKeepingValue>)Session["HouseKeepingEntry_ParentList"];
            }
            set
            {
                Session["HouseKeepingEntry_ParentList"] = value;
            }
        }

        private CustomList<HousekeepingHierarchy> ChildList
        {
            get
            {
                if (Session["HouseKeepingEntry_ChildList"] == null)
                    return new CustomList<HousekeepingHierarchy>();
                else
                    return (CustomList<HousekeepingHierarchy>)Session["HouseKeepingEntry_ChildList"];
            }
            set
            {
                Session["HouseKeepingEntry_ChildList"] = value;
            }
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack.IsFalse())
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "IsPostBack", "var isPostBack = true;", true);
                    InitializieCombo();

                    ClearControls();
                    InitializeSession();
                    //EnableAllControls(false);
                }
                else
                {
                    Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                    String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                    if (Request["__EVENTTARGET"] == "SearchHK")
                    {
                        HouseKeepingValue searchHK = Session[STATIC.StaticInfo.SearchSessionVarName] as HouseKeepingValue;
                        HouseKeepingList.Add(searchHK);
                        if (searchHK.IsNotNull())
                            PopulateHKInformation(searchHK);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #region All Methods
        private void InitializeSession()
        {
            try
            {
                ParentList = new CustomList<HouseKeepingValue>();
                HouseKeepingList = new CustomList<HouseKeepingValue>();
                ChildList = new CustomList<HousekeepingHierarchy>();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void PopulateHKInformation(HouseKeepingValue hK)
        {
            try
            {
                SetDataInControls(hK);
                ChildList = manager.GetAllHousekeepingHierarchy(hK.HKID);
                foreach (HouseKeepingValue hKV in ParentList)
                {
                    if (ChildList.FindAll(f => f.ParentID == hKV.HKID).Count != 0)
                    {
                        hKV.IsSaved = true;
                    }
                    else
                    {
                        hKV.IsSaved = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void SetDataInControls(HouseKeepingValue hk)
        {
            try
            {
                txtHKName.Text = hk.HKName;
                txtShortName.Text = hk.ShortName;
                txtDescription.Text = hk.Description;
                txtAddress.Text = hk.Address;
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
        private void InitializieCombo()
        {
            try
            {
                ddlEntityType.DataSource = manager.GetAllEntityListForHouseKeeping();
                ddlEntityType.DataTextField = "EntityName";
                ddlEntityType.DataValueField = "EntityID";
                ddlEntityType.DataBind();
                ddlEntityType.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlEntityType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void SetDataFromControls(ref CustomList<HouseKeepingValue> lstHouseKeepingValue)
        {
            try
            {
                HouseKeepingValue objHKV = lstHouseKeepingValue[0];
                objHKV.EntityID = ddlEntityType.SelectedValue.ToInt();
                objHKV.HKName = txtHKName.Text;
                objHKV.ShortName = txtShortName.Text;
                objHKV.Description = txtDescription.Text;
                objHKV.Address = txtAddress.Text;
                if (objHKV.HKID != 0) objHKV.SetModified();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #region Button Event
        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ClearControls();
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

                CustomList<HouseKeepingValue> lstHKEntry = HouseKeepingList;
                if (lstHKEntry.Count == 0)
                {
                    HouseKeepingValue newHouseKeepingEntry = new HouseKeepingValue();
                    lstHKEntry.Add(newHouseKeepingEntry);
                }
                CustomList<HouseKeepingValue> lstParent = ParentList;
                CustomList<HousekeepingHierarchy> lstChild = ChildList;
                CustomList<HousekeepingHierarchy> savedList = new CustomList<HousekeepingHierarchy>();
                foreach (HouseKeepingValue hKV in lstParent)
                {
                    if (hKV.IsSaved)
                    {
                        HousekeepingHierarchy childObj = ChildList.Find(f => f.ParentID == hKV.HKID);
                        if (childObj.IsNotNull())
                        {
                            savedList.Add(childObj);
                        }
                        else
                        {
                            HousekeepingHierarchy obj = new HousekeepingHierarchy();
                            obj.ParentID = hKV.HKID;
                            savedList.Add(obj);
                        }
                    }
                    else
                    {
                        HousekeepingHierarchy childObj = ChildList.Find(f => f.ParentID == hKV.HKID);
                        if (childObj.IsNotNull())
                        {
                            childObj.Delete();
                            savedList.Add(childObj);
                        }
                    }
                }

                SetDataFromControls(ref lstHKEntry);

                if (!CheckUserAuthentication(lstHKEntry)) return;
                manager.SaveHKEntry(ref lstHKEntry, ref savedList);
                this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
            }
            catch (SqlException ex)
            {
                this.ErrorMessage = (ExceptionHelper.getSqlExceptionMessage(ex));
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CustomList<HouseKeepingValue> items = manager.GetAllHouseKeepingValue(Convert.ToInt32(ddlEntityType.SelectedValue));
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("HKName", "HKName");

                StaticInfo.SearchItem(items, "HK Entry", "SearchHK", FRAMEWORK.SearchColumnConfig.GetColumnConfig(typeof(HouseKeepingValue), columns), 500);
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                CustomList<HouseKeepingValue> lstHKEntry = HouseKeepingList;
                CustomList<HousekeepingHierarchy> lstChild = ChildList;
                lstHKEntry.ForEach(s=>s.Delete());
                lstChild.ForEach(s=>s.Delete());
                if (!CheckUserAuthentication(lstHKEntry)) return;
                manager.DeleteHKEntry(ref lstHKEntry, ref lstChild);
                this.SuccessMessage = (StaticInfo.DeletedSuccessfullyMsg);
                ClearControls();
                InitializeSession();
            }
            catch (SqlException ex)
            {
                this.ErrorMessage = (ExceptionHelper.getSqlExceptionMessage(ex));
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        #endregion
    }
}