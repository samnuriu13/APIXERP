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
    public partial class MenuWiseTableMapping : PageBase
    {
         ApplicationManager _aManager = new ApplicationManager();
         MenuWiseTableMappingManager _manager = new MenuWiseTableMappingManager();
        #region Constructur
        public MenuWiseTableMapping()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session variables
        private CustomList<CmnDocListTableMapping> TransactionReferenceList
        {
            get
            {
                if (Session["TransactionReference_TransactionReferenceList"] == null)
                    return new CustomList<CmnDocListTableMapping>();
                else
                    return (CustomList<CmnDocListTableMapping>)Session["TransactionReference_TransactionReferenceList"];
            }
            set
            {
                Session["TransactionReference_TransactionReferenceList"] = value;
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
                    if (Request["__EVENTTARGET"] == "SearchCmnDocListTableMapping")
                    {
                        TransactionReferenceList = new CustomList<CmnDocListTableMapping>();
                        CmnDocListTableMapping searchCmnDocListTableMapping = Session[STATIC.StaticInfo.SearchSessionVarName] as CmnDocListTableMapping;
                        TransactionReferenceList.Add(searchCmnDocListTableMapping);
                        if (searchCmnDocListTableMapping.IsNotNull())
                        {
                            PopulateTransactionReferenceInformation(searchCmnDocListTableMapping);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #region  All Methods
        private void PopulateTransactionReferenceInformation(CmnDocListTableMapping TransactionReference)
        {
            try
            {

              
                 ddlTableName.SelectedValue = TransactionReference.TableName.ToString();
                //ddlDetailForeignKey.SelectedValue = TransactionReference.DetailForeignKey.ToString();
                ddlColumnName.DataSource = _manager.GetAllDetailForeignKey(TransactionReference.TableName.ToString());
                ddlColumnName.DataTextField = "DetailForeignKey";
                ddlColumnName.DataValueField = "DetailForeignKey";
                ddlColumnName.DataBind();
                ddlColumnName.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlColumnName.SelectedIndex = 0;
                ddlColumnName.SelectedValue = TransactionReference.ColumnName.ToString();

                ddlDocList.SelectedValue = TransactionReference.DocListID.ToString();
                lblTableType.Text = TransactionReference.TableType.ToString();
                lblColumnType.Text = TransactionReference.ColumnType.ToString();

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
                TransactionReferenceList = new CustomList<CmnDocListTableMapping>();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void InitializeCombo()
        {
           // ddlReferenceMasterTable.DataSource = _manager.GetAllReferenceType();
            ddlTableName.DataSource = _manager.GetAllReferenceMasterTable();
            ddlTableName.DataTextField = "ReferenceMasterTable";
            ddlTableName.DataValueField = "ReferenceMasterTable";
            ddlTableName.DataBind();
            ddlTableName.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlTableName.SelectedIndex = 0;           
            
            ddlDocList.DataSource = _aManager.GetAllMenuList();
            ddlDocList.DataTextField = "DisplayMember";
            ddlDocList.DataValueField = "MenuID";
            ddlDocList.DataBind();
            ddlDocList.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlDocList.SelectedIndex = 0;
        }
        private void SetDataFromControlToObj(ref CustomList<CmnDocListTableMapping> lstTransactionReference)
        {
            try
            {
                CmnDocListTableMapping obj = lstTransactionReference[0];
               // obj.DocListID= 0;
                obj.ColumnName = ddlColumnName.SelectedItem.Text;
                obj.ColumnType = lblColumnType.Text;
              //  obj.DocListTableMappingID = ddlTableName.SelectedValue.ToInt();
                obj.TableName = ddlTableName.SelectedItem.Text;
              //  obj.TransactionTypeColumn = txtTransactionTypeColumn.Text;
                obj.TableType = lblTableType.Text;
                obj.DocListID = ddlDocList.SelectedValue.ToInt();
               // obj.TransTypeID = ddlTransTypeName.SelectedValue.ToInt();
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
                //CustomList<CmnTransactionReference> items = _manager.GetAllReferenceType();
                CustomList<CmnDocListTableMapping> items = _manager.GetAllCmnTransactionReferenceFind();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("DocListID", "Doc List ID");
               // columns.Add("TypeName", "TypeName");

                StaticInfo.SearchItem(items, "Search DocListID", "SearchCmnDocListTableMapping", FRAMEWORK.SearchColumnConfig.GetColumnConfig(typeof(CmnDocListTableMapping), columns), 500);
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
                CustomList<CmnDocListTableMapping> lstTransactionReference = TransactionReferenceList;
                if (lstTransactionReference.Count == 0)
                {
                    CmnDocListTableMapping newTransactionReference = new CmnDocListTableMapping();
                    lstTransactionReference.Add(newTransactionReference);
                }
                SetDataFromControlToObj(ref lstTransactionReference);

                if (!CheckUserAuthentication(lstTransactionReference)) return;
                _manager.SaveCmnDocListTableMapping(ref lstTransactionReference);
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
                InitializeSession();
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
                CustomList<CmnDocListTableMapping> lstTransactionReference = (CustomList<CmnDocListTableMapping>)TransactionReferenceList;
                lstTransactionReference.ForEach(f => f.Delete());
                if (CheckUserAuthentication(lstTransactionReference).IsFalse()) return;
                _manager.SaveCmnDocListTableMapping(ref lstTransactionReference);
                ClearControls();
                InitializeSession();
                this.ErrorMessage = (StaticInfo.DeletedSuccessfullyMsg);
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

        #region Selected Index Changed Event
        protected void ddlTableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTableName.SelectedValue != "")
            {
                ddlColumnName.DataSource = _manager.GetAllDetailForeignKey(ddlTableName.SelectedValue.ToString());
                ddlColumnName.DataTextField = "DetailForeignKey";
                ddlColumnName.DataValueField = "DetailForeignKey";
                ddlColumnName.DataBind();
                ddlColumnName.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlColumnName.SelectedIndex = 0;
            }
        }
        #endregion

        
    }
}