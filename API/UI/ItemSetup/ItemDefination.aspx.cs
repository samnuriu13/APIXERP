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
    public partial class ItemDefination : PageBase
    {
        GroupItemManager itemGroupManager = new GroupItemManager();
        ItemSubGroupManager subGroupManager = new ItemSubGroupManager();
        ItemSegmentManager itemSegmentManager = new ItemSegmentManager();
        ItemMasterManager manager = new ItemMasterManager();
        UnitSetupManager unitSetUpManager = new UnitSetupManager();

        #region Constructur
        public ItemDefination()
        {
            RequiresAuthorization = true;
        }
        #region Session Variable
        private CustomList<ItemGroup> ItemGroupList
        {
            get
            {
                if (Session["ItemDefination_ItemGroupList"] == null)
                    return new CustomList<ItemGroup>();
                else
                    return (CustomList<ItemGroup>)Session["ItemDefination_ItemGroupList"];
            }
            set
            {
                Session["ItemDefination_ItemGroupList"] = value;
            }
        }
        private CustomList<SegmentNames> SegmentNamesList
        {
            get
            {
                if (Session["ItemDefination_SegmentNamesList"] == null)
                    return new CustomList<SegmentNames>();
                else
                    return (CustomList<SegmentNames>)Session["ItemDefination_SegmentNamesList"];
            }
            set
            {
                Session["ItemDefination_SegmentNamesList"] = value;
            }
        }
        private CustomList<ItemMaster> ItemMasterList
        {
            get
            {
                if (Session["ItemDefination_ItemMasterList"] == null)
                    return new CustomList<ItemMaster>();
                else
                    return (CustomList<ItemMaster>)Session["ItemDefination_ItemMasterList"];
            }
            set
            {
                Session["ItemDefination_ItemMasterList"] = value;
            }
        }
        #endregion
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack.IsFalse())
                {
                    InitializeSession();
                    InitializeCombo();
                }
                else
                {
                    Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                    String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                    if (Request["__EVENTTARGET"] == "SearchItem")
                    {
                        ItemMasterList = new CustomList<ItemMaster>();
                        ItemMaster searchItemMaster = Session[STATIC.StaticInfo.SearchSessionVarName] as ItemMaster;
                        ItemMasterList=manager.GetAllItemMasterByItemCode(searchItemMaster.ItemCode);
                        if (ItemMasterList.Count!=0)
                        {
                            PopulateItemMaster(ItemMasterList[0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void PopulateItemMaster(ItemMaster itemMaster)
        {
            try
            {
                txtItemCode.Text = itemMaster.ItemCode;
                txtBuyingPrice.Text = itemMaster.BuyingPrice.ToString();
                txtSellingPrice.Text = itemMaster.SellingPrice.ToString();
                ddlItemGroup.SelectedValue = itemMaster.ItemGroupID.ToString();
                ddlItemGroup_SelectedIndexChanged(null,null);
                //ddlItemSubGroup.SelectedValue = itemMaster.ItemSubGroupID.ToString();
                ddlUOM1.SelectedValue = itemMaster.UOMID == 0 ? null : itemMaster.UOMID.ToString();

                DropDownList ddlItemSubGroup = (DropDownList)Panel1.FindControl("ddlItemSubGroup");
                ddlItemSubGroup.SelectedValue = itemMaster.ItemSubGroupID == 0 ? null : itemMaster.ItemSubGroupID.ToString();

                int count=0;
                foreach (SegmentNames sN in SegmentNamesList)
                {
                    DropDownList ddl = (DropDownList)Panel1.FindControl("ddl" + sN.SegName.ToString());
                    if (count == 0)
                        ddl.SelectedValue = itemMaster.ValueIDSeg1.ToString();
                   else if (count == 1)
                        ddl.SelectedValue = itemMaster.ValueIDSeg2.ToString();
                   else if (count == 2)
                        ddl.SelectedValue = itemMaster.ValueIDSeg3.ToString();
                   else if (count == 3)
                        ddl.SelectedValue = itemMaster.ValueIDSeg4.ToString();
                   else if (count == 4)
                        ddl.SelectedValue = itemMaster.ValueIDSeg5.ToString();
                   else if (count == 5)
                        ddl.SelectedValue = itemMaster.ValueIDSeg6.ToString();
                   else if (count == 6)
                        ddl.SelectedValue = itemMaster.ValueIDSeg7.ToString();
                   else if (count == 7)
                        ddl.SelectedValue = itemMaster.ValueIDSeg8.ToString();
                   else if (count == 8)
                        ddl.SelectedValue = itemMaster.ValueIDSeg9.ToString();
                   else if (count == 9)
                        ddl.SelectedValue = itemMaster.ValueIDSeg10.ToString();
                    count++;
                }
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }
        private void InitializeSession()
        {
            SegmentNamesList = new CustomList<SegmentNames>();
            ItemMasterList = new CustomList<ItemMaster>();
        }
        override protected void OnInit(EventArgs e)
        {
            CustomList<ItemSubGroup> subGroupList = new CustomList<ItemSubGroup>();

            Panel1.Controls.Clear();
            if (ddlItemGroup.SelectedValue != "")
            {
                SegmentNamesList = itemSegmentManager.GetGroupSegmentNames(ddlItemGroup.SelectedValue);

                if (itemGroupManager.IsSubgroupApplicable(ddlItemGroup.SelectedValue.ToInt()))
                {
                    subGroupList = subGroupManager.GetAllItemSubGroup(ddlItemGroup.SelectedValue);
                }
            }

            if (subGroupList.Count > 0)
            {
                Panel1.Controls.Add(new LiteralControl("<div class='lblAndTxtStyle' style='width:33%; float:left;'><div class='divlblwidth100px bglbl'><a>Item Sub-Group</a></div><div class='div182Px'>"));

                DropDownList ddlItemSubGroup = new DropDownList();
                ddlItemSubGroup.ID = "ddlItemSubGroup";
                ddlItemSubGroup.DataSource = subGroupList;
                ddlItemSubGroup.DataTextField = "SubGroupName";
                ddlItemSubGroup.DataValueField = "ItemSubGroupID";
                ddlItemSubGroup.DataBind();
                ddlItemSubGroup.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlItemSubGroup.SelectedIndex = 0;
                ddlItemSubGroup.Attributes.Add("class", "drpwidth180px");
                Panel1.Controls.Add(ddlItemSubGroup);

                Panel1.Controls.Add(new LiteralControl("</div></div>"));
            }

            foreach (SegmentNames sN in SegmentNamesList)
            {
                int c = 0;
                Label lb;
                Label lfs;
                DropDownList ddl;
                lb = new Label();
                ddl = new DropDownList();
                lb.ID = "lvl" + sN.SegName;
                lb.Text = sN.SegName;
                lb.Width = 85;
                lfs = new Label();
                lfs.Width = 25;
                lfs.CssClass.PadLeft(5);
                lb.CssClass.PadLeft(10);
                ddl.ID = "ddl" + sN.SegName;

                // User Defined Field
                ddl.DataSource = itemSegmentManager.GetAllSegmentValues(sN.SegNameID);
                ddl.DataTextField = "SegValue";
                ddl.DataValueField = "SegValueID";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddl.SelectedIndex = 0;
                ddl.Width = 135;
                ddl.Attributes.Add("class", "drpdynamic");
                ddl.CssClass.PadLeft(1);

                Panel1.Controls.Add(new LiteralControl("<div class='lblAndTxtStyle' style='width:33%; float:left;'><div class='divlblwidth100px bglbl'><a>"));

                Panel1.Controls.Add(lb);
                Panel1.Controls.Add(new LiteralControl("</a></div>"));
                Panel1.Controls.Add(new LiteralControl("<div class='div182Px'>"));
                Panel1.Controls.Add(ddl);
                Panel1.Controls.Add(new LiteralControl("</div></div>"));

                c = c + 2;
                if ((c % 6) == 0)
                {
                    Panel1.Controls.Add(new LiteralControl("<br/><br/>"));
                }
                else if ((c % 2) == 0 || (c % 4) == 0)
                {
                    Panel1.Controls.Add(lfs);

                }
            }
            base.OnInit(e);
        }
        #region All Methods
        private void InitializeCombo()
        {
            #region Item Group
            ItemGroupList = new CustomList<ItemGroup>();
            ItemGroupList = itemGroupManager.GetAllItemGroup();
            ddlItemGroup.DataSource = ItemGroupList;
            ddlItemGroup.DataTextField = "GroupName";
            ddlItemGroup.DataValueField = "ItemGroupID";
            ddlItemGroup.DataBind();
            ddlItemGroup.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlItemGroup.SelectedIndex = 0;
            #endregion
            #region Item UOM
            ddlUOM1.DataSource = unitSetUpManager.GetAllUnitSetup();
            ddlUOM1.DataTextField = "Name";
            ddlUOM1.DataValueField = "UnitID";
            ddlUOM1.DataBind();
            ddlUOM1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlUOM1.SelectedIndex = 0;
            #endregion
        }
        private void SetDataFromControlToObj(ref CustomList<ItemMaster> lstItemMaster)
        {
            try
            {
                ItemMaster obj = lstItemMaster[0];
                obj.ItemGroupID = ddlItemGroup.SelectedValue.ToInt();
                //obj.ItemSubGroupID = ddlItemSubGroup.SelectedValue.ToInt();
                obj.UOMID = ddlUOM1.SelectedValue.ToInt();
                obj.BuyingPrice = Convert.ToDecimal(txtBuyingPrice.Text);
                obj.SellingPrice = Convert.ToDecimal(txtSellingPrice.Text);

                int count = 0;
                String itemDescription = ddlItemGroup.SelectedItem.Text; //+ " " + ddlItemSubGroup.SelectedItem.Text;
                foreach (SegmentNames sN in SegmentNamesList)
                {
                    DropDownList ddl = (DropDownList)Panel1.FindControl("ddl" + sN.SegName.ToString()); 
                    if (count == 0)
                    {
                        obj.ValueIDSeg1 = ddl.SelectedValue.ToInt();
                        itemDescription = itemDescription + " " + ddl.SelectedItem.Text;
                    }
                    else if (count == 1)
                    {
                        obj.ValueIDSeg2 = ddl.SelectedValue.ToInt();
                        itemDescription = itemDescription + " " + ddl.SelectedItem.Text;
                    }
                    else if (count == 2)
                    {
                        obj.ValueIDSeg3 = ddl.SelectedValue.ToInt();
                        itemDescription = itemDescription + " " + ddl.SelectedItem.Text;
                    }
                    else if (count == 3)
                    {
                        obj.ValueIDSeg4 = ddl.SelectedValue.ToInt();
                        itemDescription = itemDescription + " " + ddl.SelectedItem.Text;
                    }
                    else if (count == 4)
                    {
                        obj.ValueIDSeg5 = ddl.SelectedValue.ToInt();
                        itemDescription = itemDescription + " " + ddl.SelectedItem.Text;
                    }
                    else if (count == 5)
                    {
                        obj.ValueIDSeg6 = ddl.SelectedValue.ToInt();
                        itemDescription = itemDescription + " " + ddl.SelectedItem.Text;
                    }
                    else if (count == 6)
                    {
                        obj.ValueIDSeg7 = ddl.SelectedValue.ToInt();
                        itemDescription = itemDescription + " " + ddl.SelectedItem.Text;
                    }
                    else if (count == 7)
                    {
                        obj.ValueIDSeg8 = ddl.SelectedValue.ToInt();
                        itemDescription = itemDescription + " " + ddl.SelectedItem.Text;
                    }
                    else if (count == 8)
                    {
                        obj.ValueIDSeg9 = ddl.SelectedValue.ToInt();
                        itemDescription = itemDescription + " " + ddl.SelectedItem.Text;
                    }
                    else if (count == 9)
                    {
                        obj.ValueIDSeg10 = ddl.SelectedValue.ToInt();
                        itemDescription = itemDescription + " " + ddl.SelectedItem.Text;
                    }

                    count++;
                }
                obj.ItemDescription = itemDescription;
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
        #region Combo Event
        protected void ddlItemGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ddlItemSubGroup.DataSource = subGroupManager.GetAllItemSubGroup(ddlItemGroup.SelectedValue);
            //ddlItemSubGroup.DataTextField = "SubGroupName";
            //ddlItemSubGroup.DataValueField = "ItemSubGroupID";
            //ddlItemSubGroup.DataBind();
            //ddlItemSubGroup.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            //ddlItemSubGroup.SelectedIndex = 0;
            OnInit(null);
        }
        #endregion
        #region Button Event
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
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CustomList<ItemMaster> items = manager.FindAllItemMaster();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("ItemCode", "Item Code");
                columns.Add("GroupName", "Group");
                columns.Add("SubGroupName", "Sub Group");
                columns.Add("ItemDescription", "Item Description");

                StaticInfo.SearchItem(items, "ItemMaster", "SearchItem", FRAMEWORK.SearchColumnConfig.GetColumnConfig(typeof(ItemMaster), columns), 600);
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
                CustomList<ItemMaster> lstItemMaster = ItemMasterList;
                if (lstItemMaster.Count == 0)
                {
                    ItemMaster newItemMaster = new ItemMaster();
                    lstItemMaster.Add(newItemMaster);
                }
                SetDataFromControlToObj(ref lstItemMaster);

                if (!CheckUserAuthentication(lstItemMaster)) return;
                manager.SaveItemMaster(ref lstItemMaster);
                txtItemCode.Text = lstItemMaster[0].ItemCode;
                ((PageBase)this.Page).SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
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
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<ItemMaster> lstItemMaster = (CustomList<ItemMaster>)ItemMasterList;
                lstItemMaster.ForEach(f => f.Delete());
                if (CheckUserAuthentication(lstItemMaster).IsFalse()) return;
                manager.SaveItemMaster(ref lstItemMaster);
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
    }
}