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

namespace API.UI.ACC
{
    public partial class HeadCategory : PageBase
    {
        HeadCategoryManager manager = new HeadCategoryManager();
        #region Constructur
        public HeadCategory()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Variables
        private CustomList<AccReportConfigurationHeadCategory> HeadCategoryList
        {
            get
            {
                if (Session["HeadCategory_HeadCategoryList"] == null)
                    return new CustomList<AccReportConfigurationHeadCategory>();
                else
                    return (CustomList<AccReportConfigurationHeadCategory>)Session["HeadCategory_HeadCategoryList"];
            }
            set
            {
                Session["HeadCategory_HeadCategoryList"] = value;
            }
        }
        private CustomList<AccReportConfigurationHeadCategory> HeadCategoryByReportTypeList
        {
            get
            {
                if (Session["HeadCategory_HeadCategoryByReportTypeList"] == null)
                    return new CustomList<AccReportConfigurationHeadCategory>();
                else
                    return (CustomList<AccReportConfigurationHeadCategory>)Session["HeadCategory_HeadCategoryByReportTypeList"];
            }
            set
            {
                Session["HeadCategory_HeadCategoryByReportTypeList"] = value;
            }
        }
        private CustomList<AccReportConfigurationHeadCategory> ParentList
        {
            get
            {
                if (Session["HeadCategory_ParentList"] == null)
                    return new CustomList<AccReportConfigurationHeadCategory>();
                else
                    return (CustomList<AccReportConfigurationHeadCategory>)Session["HeadCategory_ParentList"];
            }
            set
            {
                Session["HeadCategory_ParentList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                InitializeSession();
                InitializeCombo();
            }
        }
        #region All Methods
        private void InitializeCombo()
        {
            CustomList<PopulateDropdownList> lstDropdown = new CustomList<PopulateDropdownList>();
            foreach (int value in Enum.GetValues(typeof(enumsHr.enumReportType)))
            {
                lstDropdown.Add(new PopulateDropdownList
                {
                    Text = Enum.GetName(typeof(enumsHr.enumReportType), value),
                    ValueField = value
                });
            }

            ddlReportType.DataSource = lstDropdown;
            ddlReportType.DataTextField = "Text";
            ddlReportType.DataValueField = "ValueField";
            ddlReportType.DataBind();
            ddlReportType.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlReportType.SelectedIndex = 0;
        }
        private void InitializeSession()
        {
            HeadCategoryList = new CustomList<AccReportConfigurationHeadCategory>();
            HeadCategoryList = manager.GetAllAccReportConfigurationHeadCategory();
            ParentList = new CustomList<AccReportConfigurationHeadCategory>();
            ParentList = HeadCategoryList.FindAll(f => f.ParentID == 0);
            HeadCategoryByReportTypeList = new CustomList<AccReportConfigurationHeadCategory>();
        }
        #endregion
        #region Button Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<AccReportConfigurationHeadCategory> lstHeadCategory = (CustomList<AccReportConfigurationHeadCategory>)HeadCategoryByReportTypeList;
                foreach (AccReportConfigurationHeadCategory HC in lstHeadCategory)
                {
                    if (HC.IsAdded)
                    {
                        HC.ReportTypeID = ddlReportType.SelectedValue.ToInt();
                    }
                }
                if (lstHeadCategory.IsNotNull())
                {
                    if (!CheckUserAuthentication(lstHeadCategory)) return;
                    manager.SaveHeadCategory(ref lstHeadCategory);
                    HeadCategoryList = manager.GetAllAccReportConfigurationHeadCategory();
                    this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
                }
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