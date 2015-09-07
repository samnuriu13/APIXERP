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
        TransactionReferenceManager _manager = new TransactionReferenceManager();
        #region Constructur
        public MenuWiseTableMapping()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session variables
        private CustomList<CmnTransactionReference> TransactionReferenceList
        {
            get
            {
                if (Session["TransactionReference_TransactionReferenceList"] == null)
                    return new CustomList<CmnTransactionReference>();
                else
                    return (CustomList<CmnTransactionReference>)Session["TransactionReference_TransactionReferenceList"];
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
                    if (Request["__EVENTTARGET"] == "SearchTransactionReference")
                    {
                        TransactionReferenceList = new CustomList<CmnTransactionReference>();
                        CmnTransactionReference searchCmnTransactionReference = Session[STATIC.StaticInfo.SearchSessionVarName] as CmnTransactionReference;
                        TransactionReferenceList.Add(searchCmnTransactionReference);
                        if (searchCmnTransactionReference.IsNotNull())
                        {
                            PopulateTransactionReferenceInformation(searchCmnTransactionReference);
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
        private void PopulateTransactionReferenceInformation(CmnTransactionReference TransactionReference)
        {
            try
            {
                    
                if (TransactionReference.TransRefID != 0)
                    ddlTableName.SelectedValue = TransactionReference.ReferenceMasterTable.ToString();
                //ddlDetailForeignKey.SelectedValue = TransactionReference.DetailForeignKey.ToString();
                ddlColumnName.DataSource = _manager.GetAllDetailForeignKey(TransactionReference.ReferenceDetailTable.ToString());
                ddlColumnName.DataTextField = "DetailForeignKey";
                ddlColumnName.DataValueField = "DetailForeignKey";
                ddlColumnName.DataBind();
                ddlColumnName.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlColumnName.SelectedIndex = 0;
                ddlColumnName.SelectedValue = TransactionReference.DetailForeignKey.ToString();

                ddlDocList.SelectedValue = TransactionReference.TransRefID.ToString();
                //ddlTransTypeName.SelectedValue = TransactionReference.TransTypeID.ToString();
               // txtTransactionTypeColumn.Text = TransactionReference.TransactionTypeColumn.ToString();

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
                TransactionReferenceList = new CustomList<CmnTransactionReference>();
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
        private void SetDataFromControlToObj(ref CustomList<CmnTransactionReference> lstTransactionReference)
        {
            try
            {
                CmnTransactionReference obj = lstTransactionReference[0];
                obj.CustomCode = "0";
                obj.ReferenceName = "0";
                obj.TypeName = "0";
                obj.TransRefID = ddlTableName.SelectedValue.ToInt();
                obj.ReferenceMasterTable = ddlTableName.SelectedItem.Text;
              //  obj.TransactionTypeColumn = txtTransactionTypeColumn.Text;
                obj.DetailForeignKey = ddlTableName.SelectedItem.Text;
                obj.TransRefID = ddlDocList.SelectedValue.ToInt();
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
                CustomList<CmnTransactionReference> items = _manager.GetAllCmnTransactionReferenceFind();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("ReferenceName", "ReferenceName");
                columns.Add("TypeName", "TypeName");

                StaticInfo.SearchItem(items, "Search Transaction Reference", "SearchTransactionReference", FRAMEWORK.SearchColumnConfig.GetColumnConfig(typeof(CmnTransactionReference), columns), 500);
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
                CustomList<CmnTransactionReference> lstTransactionReference = TransactionReferenceList;
                if (lstTransactionReference.Count == 0)
                {
                    CmnTransactionReference newTransactionReference = new CmnTransactionReference();
                    lstTransactionReference.Add(newTransactionReference);
                }
                SetDataFromControlToObj(ref lstTransactionReference);

                if (!CheckUserAuthentication(lstTransactionReference)) return;
                _manager.SaveTransactionReference(ref lstTransactionReference);
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
                CustomList<CmnTransactionReference> lstTransactionReference = (CustomList<CmnTransactionReference>)TransactionReferenceList;
                lstTransactionReference.ForEach(f => f.Delete());
                if (CheckUserAuthentication(lstTransactionReference).IsFalse()) return;
                _manager.SaveTransactionReference(ref lstTransactionReference);
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