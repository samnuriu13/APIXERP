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
    public partial class Unit : PageBase
    {
        UnitSetupManager manager = new UnitSetupManager();
        #region Constructur
        public Unit()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Event
        private CustomList<UnitSetup> UnitSetupList
        {
            get
            {
                if (Session["UnitSetup_UnitSetupList"] == null)
                    return new CustomList<UnitSetup>();
                else
                    return (CustomList<UnitSetup>)Session["UnitSetup_UnitSetupList"];
            }
            set
            {
                Session["UnitSetup_UnitSetupList"] = value;
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
                    InitializeSession();
                    UnitSetupList = manager.GetAllUnitSetup();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #region All Methods
        private void InitializeSession()
        {
            try
            {
                UnitSetupList = new CustomList<UnitSetup>();
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
                CustomList<UnitSetup> UnitSetup = (CustomList<UnitSetup>)UnitSetupList;

                if (!CheckUserAuthentication(UnitSetup)) return;
                manager.SaveUnitSetup(ref UnitSetup);
                UnitSetupList = manager.GetAllUnitSetup();
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