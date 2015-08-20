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

namespace API.UI.ItemSetup
{
    public partial class GroupItem : PageBase
    {
        GroupItemManager manager = new GroupItemManager();
        UnitSetupManager unitManager = new UnitSetupManager();

        #region Constructur
        public GroupItem()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Event
        private CustomList<ItemGroup> ItemGroupList
        {
            get
            {
                if (Session["ItemGroup_ItemGroupList"] == null)
                    return new CustomList<ItemGroup>();
                else
                    return (CustomList<ItemGroup>)Session["ItemGroup_ItemGroupList"];
            }
            set
            {
                Session["ItemGroup_ItemGroupList"] = value;
            }
        }
        private CustomList<UnitSetup> UnitList
        {
            get
            {
                if (Session["ItemGroup_UnitList"] == null)
                    return new CustomList<UnitSetup>();
                else
                    return (CustomList<UnitSetup>)Session["ItemGroup_UnitList"];
            }
            set
            {
                Session["ItemGroup_UnitList"] = value;
            }
        }
        #endregion
        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack.IsFalse())
                {
                    InitializeSession();
                    ItemGroupList = manager.GetAllItemGroup();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #region All Methods
        private void InitializeSession()
        {
            try
            {
                ItemGroupList = new CustomList<ItemGroup>();
                UnitList = new CustomList<UnitSetup>();
                UnitList = unitManager.GetAllUnitSetup();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
        #region Button Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<ItemGroup> ItemGroup = (CustomList<ItemGroup>)ItemGroupList;

                if (!CheckUserAuthentication(ItemGroup)) return;
                manager.SaveUnitSetup(ref ItemGroup);
                ItemGroupList = manager.GetAllItemGroup();
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