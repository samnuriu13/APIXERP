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
    public partial class ItemGroup_DetpMaping : PageBase
    {
        ItemSegmentManager itemSegmentManager = new ItemSegmentManager();
        GroupItemManager itemGroupManager = new GroupItemManager();
        ItemGroupDeptMapingManager manager = new ItemGroupDeptMapingManager();

        #region Constructur
        public ItemGroup_DetpMaping()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Variable
        private CustomList<ItemGroupDeptMaping> ItemGroupDeptMapingList
        {
            get
            {
                if (Session["ItemGroup_DetpMaping_ItemGroupDeptMapingList"] == null)
                    return new CustomList<ItemGroupDeptMaping>();
                else
                    return (CustomList<ItemGroupDeptMaping>)Session["ItemGroup_DetpMaping_ItemGroupDeptMapingList"];
            }
            set
            {
                Session["ItemGroup_DetpMaping_ItemGroupDeptMapingList"] = value;
            }
        }
        private CustomList<ItemGroupDeptMaping> GroupWiseSavedList
        {
            get
            {
                if (Session["ItemGroup_DetpMaping_GroupWiseSavedList"] == null)
                    return new CustomList<ItemGroupDeptMaping>();
                else
                    return (CustomList<ItemGroupDeptMaping>)Session["ItemGroup_DetpMaping_GroupWiseSavedList"];
            }
            set
            {
                Session["ItemGroup_DetpMaping_GroupWiseSavedList"] = value;
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
                    InitializeCombo();
                    InitializeSession();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #region All Methods
        private void InitializeCombo()
        {
            ddlItemGroup.DataSource = itemGroupManager.GetAllItemGroup();
            ddlItemGroup.DataTextField = "GroupName";
            ddlItemGroup.DataValueField = "ItemGroupID";
            ddlItemGroup.DataBind();
            ddlItemGroup.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlItemGroup.SelectedIndex = 0;
        }
        private void InitializeSession()
        {
            try
            {
                GroupWiseSavedList = new CustomList<ItemGroupDeptMaping>();
                ItemGroupDeptMapingList = new CustomList<ItemGroupDeptMaping>();
                ItemGroupDeptMapingList = manager.GetAllDept(3);
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
                CustomList<ItemGroupDeptMaping> lstItemGroupDeptMaping = (CustomList<ItemGroupDeptMaping>)ItemGroupDeptMapingList;
                lstItemGroupDeptMaping.ForEach(s => s.ItemGroupID = Convert.ToInt32(ddlItemGroup.SelectedValue));
                foreach (ItemGroupDeptMaping iGDM in lstItemGroupDeptMaping)
                {
                    if (iGDM.ID == 0 && iGDM.IsChecked)
                        iGDM.SetAdded();
                    else if (iGDM.ID != 0 && iGDM.IsChecked)
                        iGDM.SetModified();
                    else if (iGDM.ID != 0 && !iGDM.IsChecked)
                        iGDM.Delete();
                }
                if (!CheckUserAuthentication(lstItemGroupDeptMaping)) return;
                manager.SaveItemGroupDeptMaping(ref lstItemGroupDeptMaping);
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