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

namespace API.UI.Setup
{
    public partial class DocListFormatSettings : PageBase
    {
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
                    InitializeSession();
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
            PopulateParameter();
            DocListFormatList = new CustomList<CmnDocListFormat>();
            DocListFormatDetailList = new CustomList<CmnDocListFormatDetail>();
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
        }
        private void SetDataFromControlToObject(ref CustomList<CmnDocListFormat> lstDocListFormat)
        {
            CmnDocListFormat obj = lstDocListFormat[0];
            if (ddlMenuName.SelectedValue != "")
                obj.DocListId = ddlMenuName.SelectedValue.ToInt();
            obj.Prefix = txtPrefix.Text;
            obj.Suffix = txtSufix.Text;
            obj.PeriodType = ddlPeriodType.SelectedValue;
        }
        #endregion
        #region Button Event
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
                //manager.SaveItemStructure(ref lstItemStructure);
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