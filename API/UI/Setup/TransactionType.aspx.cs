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
    public partial class TransactionType : PageBase
    {
        ApplicationManager _aManager = new ApplicationManager();
        TransactionTypeManager _manager = new TransactionTypeManager();
        #region Constructur
        public TransactionType()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session variables
        private CustomList<CmnTransactionType> TransactionTypeList
        {
            get
            {
                if (Session["TransactionType_TransactionTypeList"] == null)
                    return new CustomList<CmnTransactionType>();
                else
                    return (CustomList<CmnTransactionType>)Session["TransactionType_TransactionTypeList"];
            }
            set
            {
                Session["TransactionType_TransactionTypeList"] = value;
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
                    if (Request["__EVENTTARGET"] == "SearchTransactionType")
                    {
                        TransactionTypeList = new CustomList<CmnTransactionType>();
                        CmnTransactionType searchCmnTransactionType = Session[STATIC.StaticInfo.SearchSessionVarName] as CmnTransactionType;
                        TransactionTypeList.Add(searchCmnTransactionType);
                        if (searchCmnTransactionType.IsNotNull())
                        {
                            PopulateTransactionTypeInformation(searchCmnTransactionType);
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
        private void PopulateTransactionTypeInformation(CmnTransactionType TransactionType)
        {
            try
            {
                txtTransactionTypeName.Text = TransactionType.TransTypeName;
                if (TransactionType.DocListID!=0)
                ddlDocList.SelectedValue = TransactionType.DocListID.ToString();
               
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
                TransactionTypeList = new CustomList<CmnTransactionType>();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void InitializeCombo()
        {
            ddlDocList.DataSource = _aManager.GetAllMenuList();
            ddlDocList.DataTextField = "DisplayMember";
            ddlDocList.DataValueField = "MenuID";
            ddlDocList.DataBind();
            ddlDocList.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlDocList.SelectedIndex = 0;
        }
        private void SetDataFromControlToObj(ref CustomList<CmnTransactionType> lstTransactionType)
        {
            try
            {
                CmnTransactionType obj = lstTransactionType[0];
                obj.TransTypeName = txtTransactionTypeName.Text;
                obj.CustomCode = "0";
                obj.DocListID = ddlDocList.SelectedValue.ToInt();
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
                CustomList<CmnTransactionType> items = _manager.GetAllReferenceType();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("TransTypeName", "Transaction Type");

                StaticInfo.SearchItem(items, "TransactionType", "SearchTransactionType", FRAMEWORK.SearchColumnConfig.GetColumnConfig(typeof(CmnTransactionType), columns), 500);
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
                CustomList<CmnTransactionType> lstTransactionType = TransactionTypeList;
                if (lstTransactionType.Count == 0)
                {
                    CmnTransactionType newTransctionType = new CmnTransactionType();
                    lstTransactionType.Add(newTransctionType);
                }
                SetDataFromControlToObj(ref lstTransactionType);

                if (!CheckUserAuthentication(lstTransactionType)) return;
                _manager.SaveTransactionType(ref lstTransactionType);
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
    }
}