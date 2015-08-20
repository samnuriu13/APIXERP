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
    public partial class SubGroupItem : PageBase
    {
       GroupItemManager itemGroupManager = new GroupItemManager();
       ItemSubGroupManager manager = new ItemSubGroupManager();

        #region Constructur
        public SubGroupItem()
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
        private CustomList<ItemSubGroup> ItemSubGroupList
        {
            get
            {
                if (Session["SubGroupItem_ItemSubGroupList"] == null)
                    return new CustomList<ItemSubGroup>();
                else
                    return (CustomList<ItemSubGroup>)Session["SubGroupItem_ItemSubGroupList"];
            }
            set
            {
                Session["SubGroupItem_ItemSubGroupList"] = value;
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
                    ItemSubGroupList = manager.GetAllItemSubGroup();
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
                ItemSubGroupList = new CustomList<ItemSubGroup>();
                ItemGroupList = new CustomList<ItemGroup>();
                ItemGroupList = itemGroupManager.GetAllItemGroup();
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
                CustomList<ItemSubGroup> ItemSubGroup = (CustomList<ItemSubGroup>)ItemSubGroupList;

                if (!CheckUserAuthentication(ItemSubGroup)) return;
                manager.SaveUnitSetup(ref ItemSubGroup);
                ItemSubGroupList = manager.GetAllItemSubGroup();
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