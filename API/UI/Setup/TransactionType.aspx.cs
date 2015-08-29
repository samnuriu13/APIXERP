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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack.IsFalse())
                {
                    InitializeCombo();
                }
                else
                {
                   
                }
            }
            catch (Exception ex)
            {

                throw ex;
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
    }
}