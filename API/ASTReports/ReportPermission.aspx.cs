using System;
using System.Web.UI.WebControls;
using API.DATA;
using STATIC;
using SECURITY.BLL;
using REPORT.BLL;
using FRAMEWORK;

namespace API.Reports
{
    public partial class ReportPermission : PageBase
    {
        ReportPermissionManager manager = new ReportPermissionManager();
        #region Session Value
        private CustomList<REPORT.DAO.ReportPermission> ReportList
        {
            get
            {
                if (Session["ReportPermission_ReportList"] == null)
                    return new CustomList<REPORT.DAO.ReportPermission>();
                else
                    return (CustomList<REPORT.DAO.ReportPermission>)Session["ReportPermission_ReportList"];
            }
            set
            {
                Session["ReportPermission_ReportList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {

                InitializieCombo();
                //ClearControls();
                InitializeSession();
                //EnableAllControls(false);
            }

        }
        #region All Methods
        private void InitializieCombo()
        {
            try
            {
                UserInformationManager uIManager = new UserInformationManager();

                ddlUser.DataSource = uIManager.GetAllUsers();
                ddlUser.DataTextField = "Name";
                ddlUser.DataValueField = "UserCode";
                ddlUser.DataBind();
                ddlUser.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlUser.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void InitializeSession()
        {
            try
            {
                ReportList = new CustomList<REPORT.DAO.ReportPermission>();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion
        #region Combo Event
        protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportList = new CustomList<REPORT.DAO.ReportPermission>();
            ReportList = manager.GetAllReportPermissionByUsercode(ddlUser.SelectedValue);
        }
        #endregion
        #region Button Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<REPORT.DAO.ReportPermission> rPList = ReportList;
                CustomList<REPORT.DAO.ReportPermission> checkRPermission = manager.GetAllReportPermission(ddlUser.SelectedValue);

                foreach (REPORT.DAO.ReportPermission rPObj in rPList)
                {
                    REPORT.DAO.ReportPermission chkRP = checkRPermission.Find(f => f.ReportID == rPObj.ReportID);
                    if (chkRP.IsNull())
                    {
                        rPObj.UserCode = ddlUser.SelectedValue;
                        rPObj.SetAdded();
                    }
                    else
                    {
                        rPObj.SetModified();
                    }
                }
                
                manager.SaveReportPermission(ref rPList);
                //Message.ShowMessageBox(StaticInfo.SavedSuccessfullyMsg);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSelectAll.Checked)
                {
                    foreach (REPORT.DAO.ReportPermission obj in ReportList)
                    {
                        obj.IsPreview = true;
                        obj.IsPrint = true;
                        obj.IsVissible = true;
                    }
                }
                else
                {
                    foreach (REPORT.DAO.ReportPermission obj in ReportList)
                    {
                        obj.IsPreview = false;
                        obj.IsPrint = false;
                        obj.IsVissible = false;
                    }
                }
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
}
