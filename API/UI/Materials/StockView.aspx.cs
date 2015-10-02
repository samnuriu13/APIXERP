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

namespace API.UI.Materials
{
    public partial class StockView : PageBase
    {
        HKEntryManager hkManager = new HKEntryManager();
        StockViewManager manager = new StockViewManager();

        #region Constructur
        public StockView()
        {
            RequiresAuthorization = true;
        }
        #endregion

        #region Session Variable
        private CustomList<API.DAO.StockView> StockViewList
        {
            get
            {
                if (Session["StockView_StockViewList"] == null)
                    return new CustomList<API.DAO.StockView>();
                else
                    return (CustomList<API.DAO.StockView>)Session["StockView_StockViewList"];
            }
            set
            {
                Session["StockView_StockViewList"] = value;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                InitializeCombo();
                StockViewList = new CustomList<DAO.StockView>();
                StockViewList = manager.StockView1();
            }
        }
        #region All Methods
        private void InitializeCombo()
        {
            try
            {
                ddlCostCenter.DataSource = hkManager.GetAllHouseKeeping(3);
                ddlCostCenter.DataTextField = "HKName";
                ddlCostCenter.DataValueField = "HKID";
                ddlCostCenter.DataBind();
                ddlCostCenter.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlCostCenter.SelectedIndex = 0;

               ddlBranchOrUnit.DataSource = hkManager.GetAllHouseKeeping(31);
               ddlBranchOrUnit.DataTextField = "HKName";
               ddlBranchOrUnit.DataValueField = "HKID";
               ddlBranchOrUnit.DataBind();
               ddlBranchOrUnit.Items.Insert(0, new ListItem(String.Empty, String.Empty));
               ddlBranchOrUnit.SelectedIndex = 0;

               ddlStockLocation.DataSource = hkManager.GetAllHouseKeeping(11);
               ddlStockLocation.DataTextField = "HKName";
               ddlStockLocation.DataValueField = "HKID";
               ddlStockLocation.DataBind();
               ddlStockLocation.Items.Insert(0, new ListItem(String.Empty, String.Empty));
               ddlStockLocation.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
        #region Button Event
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
               // VoucherList = manager.GetAllAcc_Voucher(ddlCostCenter.SelectedValue == "" ? 0 : Convert.ToInt32(ddlCostCenter.SelectedValue), ddlBranchOrUnit.SelectedValue == "" ? 0 : Convert.ToInt32(ddlBranchOrUnit.SelectedValue), ddlBankBranch.SelectedValue == "" ? 0 : Convert.ToInt32(ddlBankBranch.SelectedValue), txtFromDate.Text, txtToDate.Text);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
    }
}