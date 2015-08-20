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
    public partial class TransRef : System.Web.UI.UserControl
    {
        TransactionTypeManager manager = new TransactionTypeManager();
        private Int32 _DocListID;
        public Int32 DocListID
        {
            get { return _DocListID; }
            set { _DocListID = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                InitializeCombo();
            }
        }
        #region All Methods
        public void InitializeCombo()
        {
           ddlRefType.DataSource = manager.GetAllReferenceType(DocListID);
           ddlRefType.DataTextField = "TransTypeName";
           ddlRefType.DataValueField = "TransTypeID";
           ddlRefType.DataBind();
           ddlRefType.Items.Insert(0, new ListItem(String.Empty, String.Empty));
           ddlRefType.SelectedIndex = 0;
        }
        #endregion
        protected void ddlRefType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlReference.DataSource = manager.GetAllReferenceTransaction(DocListID, ddlRefType.SelectedValue.ToInt());
            ddlReference.DataTextField = "CustomCode";
            ddlReference.DataValueField = "ID";
            ddlReference.DataBind();
            ddlReference.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlReference.SelectedIndex = 0;
        }
    }
}