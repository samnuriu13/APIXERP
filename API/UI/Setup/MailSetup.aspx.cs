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

namespace API.UI.Setup
{
    public partial class MailSetup : PageBase
    {
        MailSetupManager manager = new MailSetupManager();
        #region Constructur
        public MailSetup()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Variable
        private CustomList<API.DAO.MailSetup> MailSetupList
        {
            get
            {
                if (Session["MailSetup_MailSetupList"] == null)
                    return new CustomList<API.DAO.MailSetup>();
                else
                    return (CustomList<API.DAO.MailSetup>)Session["MailSetup_MailSetupList"];
            }
            set
            {
                Session["MailSetup_MailSetupList"] = value;
            }
        }
        #endregion
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
        #region All Method
        private void InitializeSession()
        {
            try
            {
                MailSetupList = new CustomList<API.DAO.MailSetup>();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void InitializeCombo()
        {
            try
            {
                ddlReportList.DataSource = manager.GetReportList();
                ddlReportList.DataTextField = "NODE_TEXT";
                ddlReportList.DataValueField = "REPORTID";
                ddlReportList.DataBind();
                ddlReportList.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlReportList.SelectedIndex = 0;
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
        #region Button
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<API.DAO.MailSetup> lstMailSetup = (CustomList<API.DAO.MailSetup>)MailSetupList;
                CustomList<API.DAO.MailSetup> checkedMailList = lstMailSetup.FindAll(f => f.EmailAddress.Trim()!="" && f.IsChecked);
                if (checkedMailList.Count != 0)
                {
                    API.DAO.MailSetup mS=checkedMailList[0];
                    mS.IsIndividual = chkIndividual.Checked;
                    mS.IsDirector = chkDirector.Checked;
                    mS.IsOptional = chkOptional.Checked;
                    mS.Subject = txtSubject.Text;
                    mS.FileName = txtFileName.Text;
                    mS.Body = txtBody.Text;
                    mS.IsSubjectYM = chkSubject.Checked;
                    mS.IsFileNameYM = chkFileName.Checked;
                }
                foreach (API.DAO.MailSetup mS in checkedMailList)
                {
                    if (mS.IsChecked)
                    {
                        if (mS.ReportID == 0)
                        {
                            mS.SetAdded();
                            mS.ReportID = ddlReportList.SelectedValue.ToInt();
                        }
                    }
                    else
                    {
                        mS.Delete();
                    }
                }

                if (!CheckUserAuthentication(checkedMailList)) return;
                manager.SaveMailSetup(checkedMailList);
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
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<API.DAO.MailSetup> lstMailSetup = (CustomList<API.DAO.MailSetup>)MailSetupList;
                CustomList<API.DAO.MailSetup> DeletedList = lstMailSetup.FindAll(f=>f.IsChecked);
                DeletedList.ForEach(f => f.Delete());
                if (CheckUserAuthentication(DeletedList).IsFalse()) return;
                manager.SaveMailSetup(DeletedList);
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
        #region Combo Event
        protected void ddlReportList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                chkIndividual.Checked = false;
                chkDirector.Checked = false;
                chkOptional.Checked = false;
                MailSetupList = manager.GetAllMailSetup(Convert.ToInt32(ddlReportList.SelectedValue));
                API.DAO.MailSetup masterInfo = MailSetupList.Find(f=>f.IsIndividual || f.IsDirector || f.IsOptional || f.Subject.IsNotNullOrEmpty() || f.FileName.IsNotNullOrEmpty() || f.Body.IsNotNullOrEmpty());
                if (masterInfo.IsNotNull())
                {
                    chkIndividual.Checked = masterInfo.IsIndividual;
                    chkDirector.Checked = masterInfo.IsDirector;
                    chkOptional.Checked = masterInfo.IsOptional;
                    txtSubject.Text = masterInfo.Subject;
                    txtFileName.Text = masterInfo.FileName;
                    txtBody.Text = masterInfo.Body;
                    chkSubject.Checked = masterInfo.IsSubjectYM;
                    chkFileName.Checked = masterInfo.IsFileNameYM;
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