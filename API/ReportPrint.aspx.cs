using System;
using System.Collections.Generic;
using System.Data;
using API.DATA;
using Microsoft.Reporting.WebForms;
using REPORT.DAO;
using API.BLL;
using API.DAO;
using System.Web.UI.WebControls;
using REPORT.BLL;
using FRAMEWORK;
using System.IO;


namespace API.Reports
{
    public partial class ReportPrint : PageBase
    {
        #region Constructur
        public ReportPrint()
        {
            RequiresAuthorization = true;
        }
        #endregion

        #region Session Value
        private PrinterSetup PrinterSettings
        {
            get
            {
                if (Session["PrinterSetup"] == null)
                    return new PrinterSetup();
                else
                    return (PrinterSetup)Session["PrinterSetup"];
            }
            set
            {
                Session["PrinterSetup"] = value;
            }
        }
        private int CurrentPage
        {
            get
            {
                if (Session["CurrentPage"].IsNull())
                    return -1;
                else
                    return (int)Session["CurrentPage"];
            }
            set
            {
                Session["CurrentPage"] = value;
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
        private DataSet ReportDataSources
        {
            get
            {
                if (Session["VoucherReportViewer_Account"].IsNull())
                    return new DataSet();
                else
                    return (DataSet)Session["VoucherReportViewer_Account"];
            }
            set
            {
                Session["VoucherReportViewer_Account"] = value;
            }
        }
        #endregion

        #region Page event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                rbAllPages.Checked = true;
                rbPortrait.Checked = true;
                if (!IsPostBack)
                {
                    GetAllPrinter();
                }
                if (Request["__EVENTTARGET"] == "postBackFromParent")
                {
                    string selectPrinterSettings = Request["__EVENTARGUMENT"].ToString();
                    string[] printerSetting = selectPrinterSettings.Split(new char[] { ';' });
                    string printerName = printerSetting[0];
                    int noOfCopies = printerSetting[1].ToInt();
                    bool isLandscape = (printerSetting[2] == "true") ? false : true;
                    bool isAllPages = (printerSetting[3] == "true") ? true : false;
                    bool isCurrentpage = (printerSetting[4] == "true") ? true : false;
                    bool isPageRange = (printerSetting[5] == "true") ? true : false;
                    int fromPage = printerSetting[6].ToInt();
                    int toPage = printerSetting[7].ToInt();
                    PrintReport(printerName, isLandscape, noOfCopies, isAllPages, isCurrentpage, isPageRange, fromPage, toPage);
                }
                //Init Evants
                rpViewer.Drillthrough += new DrillthroughEventHandler(rpViewer_Drillthrough);
                //
                if (IsPostBack)
                {
                    rpViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
                    return;
                }
                rpViewer.Reset();

                rpViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
                rpViewer.ProcessingMode = ProcessingMode.Local;
                rpViewer.LocalReport.DataSources.Clear();

                //rpViewer.LocalReport.ReportPath = Report.ReportPath;
                rpViewer.LocalReport.LoadReportDefinition(Report.GetCustomTextReader(Report.ReportPath));

                rpViewer.LocalReport.DisplayName = Report.Name;
                rpViewer.LocalReport.EnableExternalImages = true;
                rpViewer.LocalReport.EnableHyperlinks = true;
                //rpViewer.LocalReport.ReportPath = Report.ReportPath;

                LoadSubReportDefinition();
                string value = (string)Session["Account"];
                switch (value)
                {
                    case "Voucher":
                        LoadReportSourceData(value);
                        break;
                    default:
                        {
                            SetDataSource(Report.dsSource);
                            SetParameter();
                            rpViewer.LocalReport.Refresh();
                        }
                        break;

                }
                //SetDataSource(Report.dsSource);
                //SetParameter();
                //rpViewer.LocalReport.Refresh();
            }
            catch (Exception ex)
            {
                //this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }

        protected void rpViewer_Drillthrough(object sender, DrillthroughEventArgs e)
        {
            try
            {
                // Handle local drillthrough only
                if (e.Report is ServerReport) return;

                LocalReport localreport = (LocalReport)e.Report;

                RDLReportDocument drillReport = new RDLReportDocument(e.ReportPath);
                drillReport.ReportPathWithOutName = Report.ReportPathWithOutName;
                drillReport.Load(String.Format(@"{0}\{1}.{2}", Report.ReportPathWithOutName, e.ReportPath, "rdl"));

                drillReport.LoadSourceDataSet(localreport.OriginalParametersToDrillthrough);

                localreport.DataSources.Clear();
                localreport.LoadReportDefinition(drillReport.GetCustomTextReader(drillReport.ReportPath));
                localreport.DisplayName = drillReport.Name;
                SetDataSource(drillReport.dsSource, localreport);

                ReportParameter[] Parameters = new ReportParameter[drillReport.Parameters.Count];
                int i = 0;
                foreach (RDLParameter rpParam in drillReport.Parameters)
                {
                    Parameters[i] = new ReportParameter();
                    Parameters[i].Name = rpParam.Name;
                    Parameters[i].Values.Add(rpParam.Value.ToString());
                    i++;

                }
                localreport.Refresh();
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        protected void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            try
            {
                RDLReportDocument subReport = SubReportList.Find(item => item.Name == e.ReportPath);
                if (subReport.IsNotNull())
                {
                    subReport.LoadSubReportSourceDataSet(e.Parameters);
                    ReportDataSource rdSource = null;
                    foreach (DataTable dtTable in subReport.dsSource.Tables)
                    {
                        rdSource = new ReportDataSource();
                        rdSource.Name = dtTable.TableName;
                        rdSource.Value = dtTable.DefaultView;
                        e.DataSources.Add(rdSource);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        #endregion

        #region All Method
        private void LoadReportSourceData(string value)
        {
            try
            {
                DataSet CompanyList = new DataSet();
                Microsoft.Reporting.WebForms.ReportViewer rview = new Microsoft.Reporting.WebForms.ReportViewer();
                switch (value)
                {
                    case "Voucher":
                        {
                            String orgKey = "1";//(String)Session["OrgKey"];
                            String voucherNo = (String)Session["VoucherNo"];
                            if (orgKey.IsNotNullOrEmpty())
                            {
                                ReportManager manager = new ReportManager();
                                CompanyList = manager.GetCompany(orgKey);
                                ReportDataSources = manager.GetVoucherDataSources(voucherNo);
                            }
                            rview.LocalReport.ReportPath = Report.ReportPath;
                            ReportDataSource companyDatasource = new ReportDataSource("Company", CompanyList.Tables["spGetCompany"]);
                            ReportDataSource masterDatasource = new ReportDataSource("Voucher", ReportDataSources.Tables["spPreviewVoucher"]); rpViewer.LocalReport.DataSources.Add(companyDatasource);
                            rview.LocalReport.DataSources.Add(companyDatasource);
                            rview.LocalReport.DataSources.Add(masterDatasource);
                            SetReportParameters(value, rview);
                            OpenReportInPDF(rview);
                            //rview.LocalReport.Refresh();

                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                //Message.ShowErrorMessage("Error: <br>" + ex.Message + "<br>Call Stack: <br>" + ex.StackTrace);
            }
        }
        private void SetReportParameters(string value, Microsoft.Reporting.WebForms.ReportViewer rptViewer)
        {
            try
            {
                switch (value)
                {
                    case "Voucher":
                        {
                            String voucherNo = (String)Session["VoucherNo"];
                            String orgKey = (String)Session["OrgKey"];
                            List<ReportParameter> paramList = new List<ReportParameter>();

                            ReportParameter voucher = new ReportParameter();
                            voucher.Name = "VoucherNo";
                            voucher.Values.Add(voucherNo);
                            paramList.Add(voucher);

                            ReportParameter company = new ReportParameter();
                            company.Name = "OrgKey";
                            company.Values.Add(orgKey);
                            paramList.Add(company);

                            rpViewer.LocalReport.SetParameters(paramList);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void OpenReportInPDF(Microsoft.Reporting.WebForms.ReportViewer rpViewerObj)
        {
            var path = Server.MapPath("~/CrystalPersonInfo.pdf");

            string mimeType, encoding, extension;
            string[] streamids; Microsoft.Reporting.WebForms.Warning[] warnings;
            string format = "PDF";
            byte[] bytes = rpViewerObj.LocalReport.Render(format, "", out mimeType, out encoding, out extension, out streamids, out warnings);



            FileStream fs = new FileStream(path, FileMode.Create);
            byte[] data = new byte[fs.Length];
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            Response.ContentType = "Application/pdf";
            //Get the physical path to the file.
            string FilePath = Server.MapPath("~/CrystalPersonInfo.pdf");
            //Write the file directly to the HTTP content output stream.
            Response.WriteFile(FilePath);
            Response.End();
        }
        private void GetAllPrinter()
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                ddlPrinterName.Items.Add(new ListItem(printer, printer));
            }
            ddlPrinterName.Items.Insert(0, new ListItem("Select Printer", ""));
        }
        private void LoadSubReportDefinition()
        {
            try
            {
                foreach (RDLReportDocument subReport in SubReportList)
                {
                    subReport.InitializeReportParameter();
                    rpViewer.LocalReport.LoadSubreportDefinition(subReport.Name, Report.GetCustomTextReader(subReport.ReportPath));
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void SetDataSource(DataSet dsSource)
        {
            ReportDataSource rdSource = null;
            foreach (DataTable dtTable in dsSource.Tables)
            {
                rdSource = new ReportDataSource();
                rdSource.Name = dtTable.TableName;
                rdSource.Value = dtTable.DefaultView;
                rpViewer.LocalReport.DataSources.Add(rdSource);
            }
        }
        private void SetDataSource(DataSet dsSource, LocalReport report)
        {
            ReportDataSource rdSource = null;
            foreach (DataTable dtTable in dsSource.Tables)
            {
                rdSource = new ReportDataSource();
                rdSource.Name = dtTable.TableName;
                rdSource.Value = dtTable.DefaultView;
                report.DataSources.Add(rdSource);
            }
        }
        private void SetParameter()
        {
            ReportParameter[] Parameters = new ReportParameter[Report.Parameters.Count];
            int i = 0;
            foreach (RDLParameter rpParam in this.Report.Parameters)
            {
                if (rpParam.Value.ToString() == "") rpParam.Value = "0";
                Parameters[i] = new ReportParameter();
                Parameters[i].Name = rpParam.Name;
                Parameters[i].Values.Add(rpParam.Value.ToString());
                i++;

            }
            rpViewer.LocalReport.SetParameters(Parameters);
        }
        private void PrintReport(string printerName, bool isLandscape, int noOfCopies, bool isAllPages, bool isCurrentpage, bool isPageRange, int fromPage, int toPage)
        {
            try
            {
                CurrentPage = rpViewer.CurrentPage;

                ReportPrintDocument rptPrintDoc = new ReportPrintDocument(rpViewer.LocalReport, isLandscape);
                rptPrintDoc.PrinterSettings.PrinterName = printerName;
                rptPrintDoc.NoofCopies = noOfCopies;
                if (isAllPages == true)
                {
                }
                else if (isCurrentpage == true)
                {
                    rptPrintDoc.PageRange = true;
                    rptPrintDoc.FromPage = CurrentPage;
                    rptPrintDoc.ToPage = CurrentPage;
                }
                else
                {
                    rptPrintDoc.PageRange = true;
                    rptPrintDoc.FromPage = fromPage;
                    rptPrintDoc.ToPage = toPage;
                }
                rptPrintDoc.Print();
            }
            catch (Exception ex)
            {
                Response.Output.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
