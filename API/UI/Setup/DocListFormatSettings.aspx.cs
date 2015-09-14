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
using SECURITY.BLL;

namespace API.UI.Setup
{
    public partial class DocListFormatSettings : PageBase
    {
        ApplicationManager _aManager = new ApplicationManager();
        DocListFormatSettingManager _manager = new DocListFormatSettingManager();
        #region Constructur
        public DocListFormatSettings()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Variables
        private CustomList<PopulateDropdownList> lstPopulateDropdown
        {
            get
            {
                if (Session["DocListFormatSettings_PopulateDropdownList"] == null)
                    return new CustomList<PopulateDropdownList>();
                else
                    return (CustomList<PopulateDropdownList>)Session["DocListFormatSettings_PopulateDropdownList"];
            }
            set
            {
                Session["DocListFormatSettings_PopulateDropdownList"] = value;
            }
        }
        private CustomList<CmnDocListFormat> DocListFormatList
        {
            get
            {
                if (Session["DocListFormatSettings_DocListFormatList"] == null)
                    return new CustomList<CmnDocListFormat>();
                else
                    return (CustomList<CmnDocListFormat>)Session["DocListFormatSettings_DocListFormatList"];
            }
            set
            {
                Session["DocListFormatSettings_DocListFormatList"] = value;
            }
        }
        private CustomList<CmnDocListFormatDetail> DocListFormatDetailList
        {
            get
            {
                if (Session["DocListFormatSettings_CmnDocListFormatDetailList"] == null)
                    return new CustomList<CmnDocListFormatDetail>();
                else
                    return (CustomList<CmnDocListFormatDetail>)Session["DocListFormatSettings_CmnDocListFormatDetailList"];
            }
            set
            {
                Session["DocListFormatSettings_CmnDocListFormatDetailList"] = value;
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
                    if (Request["__EVENTTARGET"] == "SearchCmnDocListFormat")
                    {
                        DocListFormatList = new CustomList<CmnDocListFormat>();
                        CmnDocListFormat searchCmnDocListFormat = Session[STATIC.StaticInfo.SearchSessionVarName] as CmnDocListFormat;
                        DocListFormatList.Add(searchCmnDocListFormat);
                        if (searchCmnDocListFormat.IsNotNull())
                        {
                            PopulateDocListFormatInformation(searchCmnDocListFormat);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #region All Methods

        private void PopulateDocListFormatInformation(CmnDocListFormat cmnDocListFormat)
        {
            try
            {
                txtCustomCode.Text = cmnDocListFormat.CustomCode;
                txtPrefix.Text = cmnDocListFormat.Prefix;
                txtSufix.Text = cmnDocListFormat.Suffix;
                ddlMenuName.SelectedValue = cmnDocListFormat.DocListId.ToString();
                DocListFormatDetailList = _manager.GetAllDocListFormat_Detail(cmnDocListFormat.DocListFormatID);   
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        private void InitializeSession()
        {
            PopulateParameter();
            DocListFormatList = new CustomList<CmnDocListFormat>();
            DocListFormatDetailList = new CustomList<CmnDocListFormatDetail>();
        }

        private void InitializeCombo()
        {
            ddlMenuName.DataSource = _aManager.GetAllMenuList();
            ddlMenuName.DataTextField = "DisplayMember";
            ddlMenuName.DataValueField = "MenuID";
            ddlMenuName.DataBind();
            ddlMenuName.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlMenuName.SelectedIndex = 0;
        }

        private void PopulateParameter()
        {
            lstPopulateDropdown = new CustomList<PopulateDropdownList>();
            PopulateDropdownList obj = new PopulateDropdownList();
            obj.ValueDoc = "Prefix";
            obj.Text = "Prefix";
            lstPopulateDropdown.Add(obj);

            PopulateDropdownList obj1 = new PopulateDropdownList();
            obj1.ValueDoc = "Sufix";
            obj1.Text = "Sufix";
            lstPopulateDropdown.Add(obj1);

            PopulateDropdownList obj2 = new PopulateDropdownList();
            obj2.ValueDoc = "AutoNo";
            obj2.Text = "AutoNo";
            lstPopulateDropdown.Add(obj2);

            PopulateDropdownList obj3 = new PopulateDropdownList();
            obj3.ValueDoc = "Year";
            obj3.Text = "Year";
            lstPopulateDropdown.Add(obj3);

            PopulateDropdownList obj4 = new PopulateDropdownList();
            obj4.ValueDoc = "Month";
            obj4.Text = "Month";
            lstPopulateDropdown.Add(obj4);

            PopulateDropdownList obj5 = new PopulateDropdownList();
            obj5.ValueDoc = "Day";
            obj5.Text = "Day";
            lstPopulateDropdown.Add(obj5);
        }
        private void SetDataFromControlToObject(ref CustomList<CmnDocListFormat> lstDocListFormat)
        {
            CmnDocListFormat obj = lstDocListFormat[0];
            if (ddlMenuName.SelectedValue != "")
                obj.DocListId = ddlMenuName.SelectedValue.ToInt();
            obj.CustomCode = txtCustomCode.Text;
            obj.Prefix = txtPrefix.Text;
            obj.Suffix = txtSufix.Text;
            obj.PeriodType = ddlPeriodType.SelectedValue;
        }
        #endregion
        #region Button Event
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {                                                                                
                CustomList<CmnDocListFormat> items = _manager.GetAllDocListFormatFind();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("Description", "Description");

                StaticInfo.SearchItem(items, "DocListFormat", "SearchCmnDocListFormat", FRAMEWORK.SearchColumnConfig.GetColumnConfig(typeof(CmnDocListFormat), columns), 500);
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
                CustomList<CmnDocListFormat> lstCmnDocListFormat = (CustomList<CmnDocListFormat>)DocListFormatList;
                if (lstCmnDocListFormat.Count == 0)
                {
                    CmnDocListFormat newObj = new CmnDocListFormat();
                    lstCmnDocListFormat.Add(newObj);
                }
                SetDataFromControlToObject(ref lstCmnDocListFormat);
                CustomList<CmnDocListFormatDetail> lstCmnDocListFormatDetail = DocListFormatDetailList;
                if (!CheckUserAuthentication(lstCmnDocListFormat)) return;
                _manager.SaveDocListFormat(ref lstCmnDocListFormat, ref lstCmnDocListFormatDetail);
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
        #endregion
    }
}