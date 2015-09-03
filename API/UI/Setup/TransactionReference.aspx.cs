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
    public partial class TransactionReference : PageBase         
    {
        ApplicationManager _aManager = new ApplicationManager();
        TransactionReferenceManager _manager = new TransactionReferenceManager();
        #region Constructur
        public TransactionReference()
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
                ddlReferenceDetailTable.Text = TransactionReference.TransRef.ToString();
                if (TransactionReference.TransRefID != 0)
                    ddlReferenceDetailTable.SelectedValue = TransactionReference.TransRefID.ToString();
               
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
            ddlReferenceMasterTable.DataSource = _manager.GetAllReferenceType();
            ddlReferenceMasterTable.DataTextField = "ReferenceDetailTable";
            ddlReferenceMasterTable.DataValueField = "ReferenceDetailTable";
            ddlReferenceMasterTable.DataBind();
            ddlReferenceMasterTable.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlReferenceMasterTable.SelectedIndex = 0;

            ddlReferenceDetailTable.DataSource = _manager.GetAllReferenceType();
            ddlReferenceDetailTable.DataTextField = "ReferenceDetailTable";
            ddlReferenceDetailTable.DataValueField = "ReferenceDetailTable";
            ddlReferenceDetailTable.DataBind();
            ddlReferenceDetailTable.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlReferenceDetailTable.SelectedIndex = 0;

            ddlTransTypeName.DataSource = _manager.GetAllTransTypeName();
            ddlTransTypeName.DataTextField = "TransTypeName";
            ddlTransTypeName.DataValueField = "TransTypeID";
            ddlTransTypeName.DataBind();
            ddlTransTypeName.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlTransTypeName.SelectedIndex = 0;

            ddlTransactionReferenceName.DataSource = _manager.GetAllTransTypeName();
            ddlTransactionReferenceName.DataTextField = "TransTypeName";
            ddlTransactionReferenceName.DataValueField = "TransTypeID";
            ddlTransactionReferenceName.DataBind();
            ddlTransactionReferenceName.Items.Insert(0,new ListItem(String.Empty,String.Empty));
            ddlTransactionReferenceName.SelectedIndex = 0;
        }
        private void SetDataFromControlToObj(ref CustomList<CmnTransactionReference> lstTransactionReference)
        {
            try
            {
                CmnTransactionReference obj = lstTransactionReference[0];
                obj.CustomCode = "0";
                obj.TransRefID = ddlReferenceMasterTable.SelectedValue.ToInt();
                obj.ReferenceMasterTable = ddlReferenceMasterTable.SelectedItem.Text;
                obj.ReferenceDetailTable = ddlReferenceDetailTable.SelectedItem.Text;
                obj.TransactionTypeColumn = txtTransactionTypeColumn.Text;
                obj.DetailForeignKey = ddlDetailForeignKey.SelectedItem.Text;
                obj.TransRefID = ddlTransactionReferenceName.SelectedValue.ToInt();
                obj.TransTypeID = ddlTransTypeName.SelectedValue.ToInt();
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
                CustomList<CmnTransactionReference> items = _manager.GetAllReferenceType();
                Dictionary<string, string> columns = new Dictionary<string, string>();    

                columns.Add("TransRef", "Transaction Reference");

                StaticInfo.SearchItem(items, "TransRef", "SearchTransactionReference", FRAMEWORK.SearchColumnConfig.GetColumnConfig(typeof(CmnTransactionReference), columns), 500);
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
        #endregion

        #region Selected Index Changed Event
        protected void ddlReferenceDetailTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlReferenceDetailTable.SelectedValue!="")
            {
                ddlDetailForeignKey.DataSource = _manager.GetAllDetailForeignKey(ddlReferenceDetailTable.SelectedValue.ToString());
                ddlDetailForeignKey.DataTextField = "DetailForeignKey";
                ddlDetailForeignKey.DataValueField = "DetailForeignKey";
                ddlDetailForeignKey.DataBind();
                ddlDetailForeignKey.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlDetailForeignKey.SelectedIndex = 0;
            }
        }
        #endregion
    }
}