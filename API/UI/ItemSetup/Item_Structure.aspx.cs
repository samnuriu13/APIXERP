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
    public partial class Item_Structure : PageBase
    {
        ItemSegmentManager itemSegmentManager = new ItemSegmentManager();
        GroupItemManager itemGroupManager = new GroupItemManager();
        ItemStructureManager manager = new ItemStructureManager();

        #region Constructur
        public Item_Structure()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Variable
        private CustomList<ItemGroup> ItemGroupList
        {
            get
            {
                if (Session["Item_Structure_ItemGroupList"] == null)
                    return new CustomList<ItemGroup>();
                else
                    return (CustomList<ItemGroup>)Session["Item_Structure_ItemGroupList"];
            }
            set
            {
                Session["Item_Structure_ItemGroupList"] = value;
            }
        }
        private CustomList<SegmentNames> SegmentNamesList
        {
            get
            {
                if (Session["Item_Structure_SegmentNamesList"] == null)
                    return new CustomList<SegmentNames>();
                else
                    return (CustomList<SegmentNames>)Session["Item_Structure_SegmentNamesList"];
            }
            set
            {
                Session["Item_Structure_SegmentNamesList"] = value;
            }
        }
        private CustomList<ItemStructure> ItemStructureList
        {
            get
            {
                if (Session["Item_Structure_ItemStructureList"] == null)
                    return new CustomList<ItemStructure>();
                else
                    return (CustomList<ItemStructure>)Session["Item_Structure_ItemStructureList"];
            }
            set
            {
                Session["Item_Structure_ItemStructureList"] = value;
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
            ItemGroupList = new CustomList<ItemGroup>();
            ItemGroupList = itemGroupManager.GetAllItemGroup();
            ddlItemGroup.DataSource = ItemGroupList;
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
                ItemStructureList = new CustomList<ItemStructure>();
                SegmentNamesList = new CustomList<SegmentNames>();
                SegmentNamesList = itemSegmentManager.GetAllSegmentNames();
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
                CustomList<ItemStructure> lstItemStructure = (CustomList<ItemStructure>)ItemStructureList;

                if (!CheckUserAuthentication(lstItemStructure)) return;
                lstItemStructure.ForEach(s => s.GroupItemID = Convert.ToInt32(ddlItemGroup.SelectedValue));
                manager.SaveItemStructure(ref lstItemStructure);
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