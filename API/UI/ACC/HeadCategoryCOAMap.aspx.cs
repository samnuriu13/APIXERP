using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACC.BLL;
using API.BLL;
using ACC.DAO;
using STATIC;
using API.DATA;
using FRAMEWORK;
using API.DAO;
using REPORT.DAO;
using System.Data.SqlClient;

namespace API.UI.ACC
{
    public partial class HeadCategoryCOAMap : PageBase
    {
        HeadCategoryManager hCM = new HeadCategoryManager();

        #region Session & ViewState
        public CustomList<Acc_COA> _COA
        {
            get
            {
                if (Session["COA_COA"] == null)
                    return new CustomList<Acc_COA>();
                else
                    return (CustomList<Acc_COA>)Session["COA_COA"];
            }
            set
            {
                Session["COA_COA"] = value;
            }
        }

        private CustomList<Acc_COA> GRID_COA
        {
            get
            {
                if (Session["GRID_COA"] == null)
                    return new CustomList<Acc_COA>();
                else
                    return (CustomList<Acc_COA>)Session["GRID_COA"];
            }
            set
            {
                Session["GRID_COA"] = value;
            }
        }

        private Int64 _SelectedCOAKey
        {
            get
            {
                if (ViewState["COA_SelectedCOAKey"] == null)
                    return (Int64)0;
                else
                    return (Int64)ViewState["COA_SelectedCOAKey"];
            }
            set
            {
                ViewState["COA_SelectedCOAKey"] = value;
            }
        }
        private TreeNode _selnode
        {
            get
            {
                if (Session["_selnode"] == null)
                    return null;
                else
                    return (TreeNode)Session["_selnode"];
            }
            set
            {
                Session["_selnode"] = value;
            }
        }


        private CustomList<AccReportConfigurationHead> AccReportConfigurationHeadList   
        {
            get
            {
                if (Session["Acc_ReportConfigurationHeadList"] == null)
                    return new CustomList<AccReportConfigurationHead>();
                else
                    return (CustomList<AccReportConfigurationHead>)Session["Acc_ReportConfigurationHeadList"];
            }
            set
            {
                Session["Acc_ReportConfigurationHeadList"] = value;
            }
        }

        private CustomList<AccReportConfigurationHeadCOAMap> AccReportConfigurationHeadCOAMapList
        {
            get
            {
                if (Session["Acc_ReportConfigurationHeadCOAMapList"] == null)
                    return new CustomList<AccReportConfigurationHeadCOAMap>();
                else
                    return (CustomList<AccReportConfigurationHeadCOAMap>)Session["Acc_ReportConfigurationHeadCOAMapList"];
            }
            set
            {
                Session["Acc_ReportConfigurationHeadCOAMapList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadCOA();
                populateTreeView();
                tv.CollapseAll();
                InitializeCombo();
                InitializeSession();
            }

            else
            {
                Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                if (Request["__EVENTTARGET"] == "SearchBank")
                {
                    AccReportConfigurationHeadList = new CustomList<AccReportConfigurationHead>();
                    AccReportConfigurationHead searchAccReportConfigurationHead = Session[STATIC.StaticInfo.SearchSessionVarName] as AccReportConfigurationHead;
                    AccReportConfigurationHeadList.Add(searchAccReportConfigurationHead);
                    if (searchAccReportConfigurationHead.IsNotNull())
                    {
                        PopulateACCInformation(searchAccReportConfigurationHead);
                    }
                }
            }
        }

        #region OnPreRender
        protected override void OnPreRender(EventArgs e)
        {
            try
            {
                if (_selnode != null)
                {
                    string[] nodes = _selnode.ValuePath.Split('/');
                    string curNode = string.Empty;
                    foreach (string node in nodes)
                    {
                        curNode += node;
                        tv.FindNode(curNode).Expand();
                        curNode += "/";
                    }
                }
            }
            catch
            {
                tv.CollapseAll();
            }
            base.OnPreRender(e);
        }
        #endregion

        #region Load COA from DB
        private void loadCOA()
        {
            _COA = Acc_COA.GetAllAcc_COA(true);
        }

        private void InitializeSession()
        {
            try
            {
                GRID_COA = new CustomList<Acc_COA>();
                AccReportConfigurationHeadList = new CustomList<AccReportConfigurationHead>();
                AccReportConfigurationHeadCOAMapList = new CustomList<AccReportConfigurationHeadCOAMap>();
            }

            catch(Exception ex)
            {
               throw(ex);
            }
        }

        private void SetDataFromControlToObj(ref CustomList<AccReportConfigurationHead> lstAccReportConfigurationHead)
        {
            try
            {
                AccReportConfigurationHead obj = lstAccReportConfigurationHead[0];
                obj.HeadCategoryID = Convert.ToInt32(ddlHeadCategory.SelectedValue);
                obj.ReportTypeID = Convert.ToInt32(ddlReportType.SelectedValue);
                obj.Sequence = Convert.ToInt32(txtSequence.Text);
                obj.OperationOperator = ddlOperator.SelectedValue.ToString();
                obj.HeadName = "";
                obj.CostCenterID = 0;
                obj.CompanyID = 0;
               // obj.HeadID = 0;
                obj.IsActive = true;
                //if (obj.ShiftID != 0) obj.SetModified();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        #endregion

        #region Build Treeview
        private void populateTreeView()
        {
            loadCOA();
            tv.Nodes.Clear();
            foreach (Acc_COA item in _COA)
            {
                if (item.ParentKey == null)
                {
                    TreeNode tnParent = new TreeNode();
                    tnParent.Text = item.COAName;
                    tnParent.Value = item.COAKey.ToString();
                    tnParent.ShowCheckBox = true;
                    tv.Nodes.Add(tnParent);
                    FillChild(tnParent, item.COAKey);
                }
            }
        }

        public int FillChild(TreeNode parent, Int64 coaKey)
        {
            CustomList<Acc_COA> list = _COA.FindAll(p => p.ParentKey == coaKey);

            if (list.Count > 0)
            {
                foreach (Acc_COA item in list)
                {
                    TreeNode child = new TreeNode();
                    child.Text = item.COAName;
                    child.Value = item.COAKey.ToString();
                    child.ShowCheckBox = true;
                    parent.ChildNodes.Add(child);
                    FillChild(child, item.COAKey);
                }
                return 0;
            }
            else
            {
                return 0;
            }
        }
        #endregion
        protected void tv_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            if (e.Node.Checked)
            {
                var stack = new Stack<TreeNode>();
                stack.Push(e.Node);
                while (stack.Count > 0)
                {
                    var node = stack.Pop();
                    node.Checked = true;
                    foreach (TreeNode childNode in node.ChildNodes)
                    {
                        stack.Push(childNode);
                    }
                }
            }
        }
        protected void tv_SelectedNodeChanged(object sender, EventArgs e)
        {
            //if (e.Node.Checked)
            //{
            //    var stack = new Stack<TreeNode>();
            //    stack.Push(e.Node);
            //    while (stack.Count > 0)
            //    {
            //        var node = stack.Pop();
            //        node.Checked = true;
            //        foreach (TreeNode childNode in node.ChildNodes)
            //        {
            //            stack.Push(childNode);
            //        }
            //    }
            //}
        }

        private void PopulateACCInformation(AccReportConfigurationHead accReportConfigurationHead)  
        {
            try
            {
                //txtBankName.Text = bank.BnakName;
               // txtBankSName.Text = bank.BankSName;
               // txtAddress.Text = bank.Address;
               // txtContactPerson.Text = bank.ContactPerson;
                AccReportConfigurationHeadCOAMapList = hCM.GetAllAccReportConfigurationHeadCOAMap(accReportConfigurationHead.HeadID); 
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        private void InitializeCombo()
        {
            CustomList<PopulateDropdownList> lstDropdown = new CustomList<PopulateDropdownList>();
            foreach (int value in Enum.GetValues(typeof(enumsHr.enumReportType)))
            {
                lstDropdown.Add(new PopulateDropdownList
                {
                    Text = Enum.GetName(typeof(enumsHr.enumReportType), value),
                    ValueField = value
                });
            }

            ddlReportType.DataSource = lstDropdown;
            ddlReportType.DataTextField = "Text";
            ddlReportType.DataValueField = "ValueField";
            ddlReportType.DataBind();
            ddlReportType.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlReportType.SelectedIndex = 0;


            ddlHeadCategory.DataSource = hCM.GetAllAccReportConfigurationHeadCategory();
            ddlHeadCategory.DataTextField = "HeadCategoryName";
            ddlHeadCategory.DataValueField = "HeadCategoryID";
            ddlHeadCategory.DataBind();
            ddlHeadCategory.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlHeadCategory.SelectedIndex = 0;

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

        #region button event

        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CustomList<AccReportConfigurationHead> items = hCM.GetAllAccReportConfigurationHead(); 
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("BnakName", "Bank Name");

                StaticInfo.SearchItem(items, "Bank", "SearchAccReportConfigurationHead", FRAMEWORK.SearchColumnConfig.GetColumnConfig(typeof(AccReportConfigurationHead), columns), 500);
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            List<TreeNode> AllCheckedNodes = new List<TreeNode>();
            CustomList<AccReportConfigurationHeadCOAMap> lstCoaFgrid = new CustomList<AccReportConfigurationHeadCOAMap>();
            CustomList<Acc_COA> lstSessionAcc_COA = new CustomList<Acc_COA>();
            lstSessionAcc_COA = (CustomList<Acc_COA>)Session["COA_COA"];

            string allChkName = "";
            for (int i = 0; i < tv.CheckedNodes.Count; i++)
            {
                AccReportConfigurationHeadCOAMap objCOA = new AccReportConfigurationHeadCOAMap();
                objCOA.COAName = tv.CheckedNodes[i].Text;
                objCOA.COAID =Convert.ToInt32(tv.CheckedNodes[i].Value);
                objCOA.HeadCOAMapID = 0;
                //objCOA.HeadID = 0;
                foreach (Acc_COA acccoa in lstSessionAcc_COA)
                {
                    if (objCOA.COAID == Convert.ToInt32(acccoa.COAKey) && acccoa.IsPostingHead == true)
                    {
                        objCOA.IsActive = true;
                        lstCoaFgrid.Add(objCOA);
                    }
                }
                // lstCoaFgrid.Add(objCOA);  
                // allChkName=allChkName+"_"+tv.CheckedNodes[i].Text;
            }

            AccReportConfigurationHeadCOAMapList = lstCoaFgrid;

            ////List<TreeNode> AllCheckedNodes = new List<TreeNode>();
            ////CustomList<Acc_COA> lstCoaFgrid = new CustomList<Acc_COA>();
            ////CustomList<Acc_COA> lstSessionAcc_COA = new CustomList<Acc_COA>();
            ////lstSessionAcc_COA = (CustomList<Acc_COA>)Session["COA_COA"];

            ////string allChkName = "";
            ////for (int i = 0; i < tv.CheckedNodes.Count; i++)
            ////{
            ////    Acc_COA objCOA = new Acc_COA();
            ////    objCOA.COAName = tv.CheckedNodes[i].Text;
            ////    // objCOA.IsActive = false;
            ////    foreach (Acc_COA acccoa in lstSessionAcc_COA)
            ////    {
            ////        if (objCOA.COAName == acccoa.COAName && acccoa.IsPostingHead == true)
            ////        {
            ////            objCOA.IsActive = true;
            ////            lstCoaFgrid.Add(objCOA);
            ////        }
            ////    }
            ////    // lstCoaFgrid.Add(objCOA);  
            ////    // allChkName=allChkName+"_"+tv.CheckedNodes[i].Text;
            ////}

            ////Session["GRID_COA"] = lstCoaFgrid;



        }    

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                CustomList<AccReportConfigurationHead> lstAccReportConfigurationHead = AccReportConfigurationHeadList;
                if (lstAccReportConfigurationHead.Count == 0)
                {
                    AccReportConfigurationHead newAccReportConfigurationHead = new AccReportConfigurationHead();
                    lstAccReportConfigurationHead.Add(newAccReportConfigurationHead);
                }
                SetDataFromControlToObj(ref lstAccReportConfigurationHead);
                CustomList<AccReportConfigurationHeadCOAMap> lstAccReportConfigurationHeadCOAMap = (CustomList<AccReportConfigurationHeadCOAMap>)AccReportConfigurationHeadCOAMapList;

                //if (!CheckUserAuthentication(lstAccReportConfigurationHead, lstAccReportConfigurationHeadCOAMap)) return;
                hCM.SaveAccReportConfigurationHead(ref lstAccReportConfigurationHead, ref lstAccReportConfigurationHeadCOAMap);
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