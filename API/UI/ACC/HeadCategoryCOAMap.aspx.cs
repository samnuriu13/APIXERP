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
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadCOA();
                populateTreeView();
                tv.CollapseAll();
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

    }
}