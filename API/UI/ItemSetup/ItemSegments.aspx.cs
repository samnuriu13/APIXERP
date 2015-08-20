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
    public partial class ItemSegments : PageBase
    {
        ItemSegmentManager manager = new ItemSegmentManager();
        #region Constructur
        public ItemSegments()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Event
        private CustomList<SegmentNames> SegmentNamesList
        {
            get
            {
                if (Session["ItemSegments_SegmentNamesList"] == null)
                    return new CustomList<SegmentNames>();
                else
                    return (CustomList<SegmentNames>)Session["ItemSegments_SegmentNamesList"];
            }
            set
            {
                Session["ItemSegments_SegmentNamesList"] = value;
            }
        }

        private CustomList<SegmentValues> SegmentValuesList
        {
            get
            {
                if (Session["ItemSegments_SegmentValuesList"] == null)
                    return new CustomList<SegmentValues>();
                else
                    return (CustomList<SegmentValues>)Session["ItemSegments_SegmentValuesList"];
            }
            set
            {
                Session["ItemSegments_SegmentValuesList"] = value;
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
            SegmentNamesList = new CustomList<SegmentNames>();
            SegmentNamesList = manager.GetAllSegmentNames();
            ddlSegmentNames.DataSource = SegmentNamesList;
            ddlSegmentNames.DataTextField = "SegName";
            ddlSegmentNames.DataValueField = "SegNameID";
            ddlSegmentNames.DataBind();
            ddlSegmentNames.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlSegmentNames.SelectedIndex = 0;
        }
        private void InitializeSession()
        {
            try
            {
                SegmentValuesList = new CustomList<SegmentValues>();
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
        private void SetDataFromControlToObj(ref CustomList<SegmentNames> lstSegmentNames)
        {
            try
            {
                SegmentNames obj = lstSegmentNames[0];
                obj.SegName = txtSegmentName.Text;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<SegmentNames> lstSegmentNames = SegmentNamesList;
                if (lstSegmentNames.Count == 0)
                {
                    SegmentNames newSegmentNames = new SegmentNames();
                    lstSegmentNames.Add(newSegmentNames);
                }
                SetDataFromControlToObj(ref lstSegmentNames);
                CustomList<SegmentValues> lstSegmentValues = (CustomList<SegmentValues>)SegmentValuesList;

                if (!CheckUserAuthentication(lstSegmentNames, lstSegmentValues)) return;
                manager.SaveItemSegment(ref lstSegmentNames, ref lstSegmentValues);
                InitializeCombo();
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
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<SegmentNames> lstSegmentNames = (CustomList<SegmentNames>)SegmentNamesList;
                lstSegmentNames.ForEach(f => f.Delete());
                CustomList<SegmentValues> lstSegmentValues = (CustomList<SegmentValues>)SegmentValuesList;
                lstSegmentValues.ForEach(s => s.Delete());
                if (CheckUserAuthentication(lstSegmentNames, lstSegmentValues).IsFalse()) return;
                manager.SaveItemSegment(ref lstSegmentNames, ref lstSegmentValues);
                InitializeCombo();
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