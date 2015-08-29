using System;
using System.Collections.Generic;
using System.Globalization;
using System.Data;
using System.Web.UI.WebControls;
using API.DATA;
using REPORT.DAO;
using FRAMEWORK;
using System.Configuration;
using System.IO;
using API.BLL;
using API.DAO;
//using API.Email;


namespace API.Reports
{
    public partial class ReportViewer : PageBase
    {
        private const String ParamTableName = "ParameterValues";

        #region Constructur
        public ReportViewer()
        {
            RequiresAuthorization = true;
        }
        #endregion

        #region Session Value
        private CustomList<ReportSuiteMenu> ReportMenuList
        {
            get
            {
                if (Session["ReportViewer_ReportSuiteMenu"].IsNull())
                    Session["ReportViewer_ReportSuiteMenu"] = new CustomList<ReportSuiteMenu>();
                //
                return (CustomList<ReportSuiteMenu>)Session["ReportViewer_ReportSuiteMenu"];
            }
            set
            {
                Session["ReportViewer_ReportSuiteMenu"] = value;
            }
        }
        private RDLReportDocument Report
        {
            get
            {
                if (Session["ReportViewer_Report"].IsNull())
                    Session["ReportViewer_Report"] = new RDLReportDocument();
                //
                return (RDLReportDocument)Session["ReportViewer_Report"];
            }
            set
            {
                Session["ReportViewer_Report"] = value;
            }
        }
        private List<RDLReportDocument> SubReportList
        {
            get
            {
                if (Session["ReportViewer_SubReportDocument"].IsNull())
                    Session["ReportViewer_SubReportDocument"] = new List<RDLReportDocument>();
                //
                return (List<RDLReportDocument>)Session["ReportViewer_SubReportDocument"];
            }
            set
            {
                Session["ReportViewer_SubReportDocument"] = value;
            }
        }
        private DataSet ParameterValues
        {
            get
            {
                if (Session["ReportViewer_ParameterValues"].IsNull())
                    Session["ReportViewer_ParameterValues"] = new DataSet();
                //
                return (DataSet)Session["ReportViewer_ParameterValues"];
            }
            set
            {
                Session["ReportViewer_ParameterValues"] = value;
            }
        }
        private CustomList<FilterSets> FilterSetList
        {
            get
            {
                if (Session["ReportViewer_FilterSetList"].IsNull())
                    Session["ReportViewer_FilterSetList"] = new CustomList<FilterSets>();
                //
                return (CustomList<FilterSets>)Session["ReportViewer_FilterSetList"];
            }
            set
            {
                Session["ReportViewer_FilterSetList"] = value;
            }
        }
        private CustomList<ParameterFilterValue> FilterValueList
        {
            get
            {
                if (Session["ReportViewer_FilterValueList"].IsNull())
                    Session["ReportViewer_FilterValueList"] = new CustomList<ParameterFilterValue>();
                //
                return (CustomList<ParameterFilterValue>)Session["ReportViewer_FilterValueList"];
            }
            set
            {
                Session["ReportViewer_FilterValueList"] = value;
            }
        }
        private CustomList<ErrorList> errorList
        {
            get
            {
                if (Session["ReportViewer_errorList"] == null)
                    return new CustomList<ErrorList>();
                else
                    return (CustomList<ErrorList>)Session["ReportViewer_errorList"];
            }
            set
            {
                Session["ReportViewer_errorList"] = value;
            }
        }
        #endregion

        #region Page event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (enterintoLoadEvent.IsFalse()) return;
                if (IsPostBack.IsFalse())
                {
                    errorList = new CustomList<ErrorList>();
                    btnEmail.Visible = false;
                    FilterSetList = new CustomList<FilterSets>();
                    FilterValueList = new CustomList<ParameterFilterValue>();
                    REPORT.BLL.ReportSuite reportSuite = new REPORT.BLL.ReportSuite(STATIC.ConnectionName.HR);
                    string empcode = Request.QueryString.Get("empCode");
                    string empKey = Request.QueryString.Get("EmpKey");
                    if (empcode.IsNullOrEmpty())
                    {
                        //ReportMenuList = reportSuite.GetReportSuiteMenu(CurrentUserSession.UserCode);
                        ReportMenuList = reportSuite.GetReportSuiteMenu();
                    }
                    else
                    {
                        ReportMenuList = reportSuite.GetReportSuiteMenu();
                    }
                    LoadMenu();
                    treeMenu.CollapseAll();
                    if (treeMenu.Nodes.Count > 0)
                        treeMenu.Nodes[0].Expand();
                }
            }
            catch (Exception ex)
            {
                //Message.ShowErrorMessage("Error: <br>" + ex.Message + "<br>Call Stack: <br>" + ex.StackTrace);
            }
        }
        #endregion
        #region Button event
        protected void btnEmail_Click(object sender, EventArgs e)
        {
            try
            {
                string checkedRequiredField = "";
                DataTable dt = new DataTable();
                string subject = "";
                string fileName = "";
                string body = "";
                Boolean isSubjectYM = false;
                Boolean isFileNameYM = false;
                errorList = new CustomList<ErrorList>();
                MailSetupManager manager = new MailSetupManager();
                CustomList<MailSetup> mailSetup = manager.GetAllMailSetup(Convert.ToInt32(Session["ReportID"]));
                MailSetup mS = mailSetup.Find(f => f.Subject.IsNotNullOrEmpty());
                if (mS.IsNull())
                {
                    return;
                }
                else
                {
                    subject = mS.Subject;
                    fileName = mS.FileName;
                    body = mS.Body;
                    isSubjectYM = mS.IsSubjectYM;
                    isFileNameYM = mS.IsFileNameYM;
                }
                #region
                if (isSubjectYM)
                {
                    FilterSets month = FilterSetList.Find(f => f.ColumnName == "MonthNo");
                    FilterSets year = FilterSetList.Find(f => f.ColumnName == "YearNo");
                    string monthYearName = "";
                    if (month.IsNotNull())
                        monthYearName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month.ColumnActualValue.ToInt()).Substring(0, 3) + "' " + year.ColumnActualValue.Substring(2, 2);

                    if (monthYearName == "")
                    {
                        FilterSets fromDate = FilterSetList.Find(f => f.ColumnName == "FromDate");
                        if (fromDate.IsNotNull())
                            monthYearName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(fromDate.ColumnValue.Substring(0, 2).ToInt()).Substring(0, 3) + "' " + fromDate.ColumnValue.Substring(8, 2);

                    }
                    if (monthYearName == "")
                    {
                        FilterSets workDate = FilterSetList.Find(f => f.ColumnName == "Workdate");
                        if (workDate.IsNotNull())
                            monthYearName = Convert.ToDateTime(workDate.ColumnValue).ToString("dd MMM yy");

                    }
                    subject = subject + "_" + monthYearName;
                }
                if (isFileNameYM)
                {
                    FilterSets month = FilterSetList.Find(f => f.ColumnName == "MonthNo");
                    FilterSets year = FilterSetList.Find(f => f.ColumnName == "YearNo");
                    string monthYearName = "";
                    if (month.IsNotNull())
                        monthYearName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month.ColumnActualValue.ToInt()).Substring(0, 3) + "' " + year.ColumnActualValue.Substring(2, 2);

                    if (monthYearName == "")
                    {
                        FilterSets fromDate = FilterSetList.Find(f => f.ColumnName == "FromDate");
                        if (fromDate.IsNotNull())
                            monthYearName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(fromDate.ColumnValue.Substring(0, 2).ToInt()).Substring(0, 3) + "' " + fromDate.ColumnValue.Substring(8, 2);

                    }
                    if (monthYearName == "")
                    {
                        FilterSets workDate = FilterSetList.Find(f => f.ColumnName == "Workdate");
                        if (workDate.IsNotNull())
                            monthYearName = Convert.ToDateTime(workDate.ColumnValue).ToString("dd MMM yy");

                    }
                    fileName = fileName + "_" + monthYearName;
                }
                string reportPath = Session["reportPath"].ToString();
                DataTable dt1 = new DataTable();
                if (!mS.IsIndividual)
                Report.LoadSourceDataSet(ref checkedRequiredField, ref dt1);
                FilterSets empCode = FilterSetList.Find(f => f.ColumnName == "EmpCode");
                if (empCode.ColumnActualValue.IsNotNullOrEmpty())
                {
                    mailSetup = mailSetup.FindAll(f => f.EmpKey.ToString() == empCode.ColumnActualValue);
                }
                #endregion
                foreach (MailSetup m in mailSetup)
                {
                    //if (mS.IsIndividual)
                    //    Report.LoadSourceDataSet(m.EmpKey.ToString(), ref dt1);

                    //SentEmail sm = new SentEmail();
                    //string message = sm.EmailUtil(m.EmailAddress, reportPath, dt1, "", subject, fileName, body);
                    //if (message.IsNotNullOrEmpty())
                    //{
                    //    ErrorList eL = new ErrorList();
                    //    eL.EmpName = m.EmpName.Trim();
                    //    eL.Error = message;
                    //    errorList.Add(eL);
                    //}
                }
                ((PageBase)this.Page).SuccessMessage = "Mail sent successfully!";
            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        protected void treeMenu_SelectedNodeChanged(object sender, EventArgs e)
        {
            try
            {
                if (treeMenu.SelectedNode.IsNotNull() && treeMenu.SelectedNode.ImageToolTip.IsNotNullOrEmpty())
                {
                    REPORT.BLL.ReportSuite reportSuite = new REPORT.BLL.ReportSuite(STATIC.ConnectionName.HR);
                    String reportPath = String.Empty;
                    reportPath = AppDomain.CurrentDomain.BaseDirectory + "ASTReports\\" + treeMenu.SelectedNode.ImageToolTip;
                    Session["reportPath"] = reportPath;
                    if (System.IO.File.Exists(reportPath).IsFalse())
                    {
                        Response.Write("File does not exist.");
                        return;
                    }

                    ParameterValues = new DataSet();
                    ParameterValues = reportSuite.LoadReportParameterInfoFromDB(treeMenu.SelectedNode.Value.ToInt());
                    ParameterValues.Tables[0].TableName = ParamTableName;

                    Session["ReportID"] = treeMenu.SelectedNode.Value.ToString();

                    Int32 reportID = reportSuite.CheckMailExist(treeMenu.SelectedNode.Value.ToString());
                    if (reportID == 0)
                    {
                        btnEmail.Visible = false;
                    }
                    else
                    {
                        btnEmail.Visible = true;
                    }

                    SubReportList = new List<RDLReportDocument>();
                    Report = new RDLReportDocument(treeMenu.SelectedNode.Text);
                    Report.ReportPathWithOutName = treeMenu.SelectedNode.ToolTip;
                    Report.Load(reportPath);
                    Report.LoadFilterTable(ParameterValues.Tables[ParamTableName].Columns);
                    FilterSetList = Report.FilterSetList;
                }
            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                string checkedRequiredField = "";
                ResetSession();
                string empKey = Request.QueryString.Get("EmpKey");
                Report.LoadSourceDataSet(ref checkedRequiredField, empKey);
                if (checkedRequiredField != "")
                {
                    ((PageBase)this.Page).ErrorMessage = checkedRequiredField;
                    return;
                }
                Report.SetFilterValue();
                String script = "javascript:ShowReportViewer();";
                if (ClientScript.IsClientScriptBlockRegistered("scriptShowReportViewer").IsFalse())
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "scriptShowReportViewer", script, true);
                }
            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (FilterSets filter in FilterSetList)
                {
                    filter.ColumnValue = String.Empty;
                }
            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        #endregion

        #region All Method
        private void ResetSession()
        {
            Session["Voucher"] = "";
        }
        private void LoadMenu()
        {
            try
            {
                TreeNode parentNode;
                CustomList<ReportSuiteMenu> parentList = ReportMenuList.FindAll(item => item.REPORTID == item.PARENT_KEY);
                foreach (ReportSuiteMenu parent in parentList)
                {
                    parentNode = new TreeNode();
                    parentNode.Text = parent.NODE_TEXT;
                    parentNode.Value = parent.REPORTID.ToString();

                    LoadChildNodes(parentNode, parent.REPORTID);
                    treeMenu.Nodes.Add(parentNode);
                }
                //
                //treeMenu.ExpandAll();
                treeMenu.SelectedNodeStyle.ForeColor = System.Drawing.Color.Red;
                treeMenu.HoverNodeStyle.ForeColor = System.Drawing.Color.Gray;
                treeMenu.NodeStyle.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void LoadChildNodes(TreeNode parentNode, int parentID)
        {
            try
            {
                TreeNode aNode;
                CustomList<ReportSuiteMenu> childList = ReportMenuList.FindAll(item => item.PARENT_KEY == parentID && item.REPORTID != parentID);
                foreach (ReportSuiteMenu child in childList)
                {

                    aNode = new TreeNode();
                    aNode.Text = child.NODE_TEXT;
                    aNode.Value = child.REPORTID.ToString();
                    aNode.ImageUrl = @"~\images\node.Png";
                    aNode.ToolTip = AppDomain.CurrentDomain.BaseDirectory + "ASTReports";//child.REPORT_PATH_NAME;
                    //aNode.ImageToolTip = String.Format(@"{0}\{1}", child.REPORT_PATH_NAME, child.REPORT_NAME);
                    aNode.ImageToolTip = child.REPORT_NAME;
                    parentNode.ChildNodes.Add(aNode);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

    }
}

