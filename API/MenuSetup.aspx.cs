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
using SECURITY.BLL;
using System.IO;

namespace API
{
    public partial class MenuSetup : PageBase
    {
        SecurityManager manager = new SecurityManager();

        public MenuSetup()
        {
            RequiresAuthorization = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                InitializeSession();
            }
        }

        private CustomList<SECURITY.DAO.MenuSetup> MenuList
        {
            get
            {
                if (Session["MenuSetup_MenuList"] == null)
                    return new CustomList<SECURITY.DAO.MenuSetup>();
                else
                    return (CustomList<SECURITY.DAO.MenuSetup>)Session["MenuSetup_MenuList"];
            }
            set
            {
                Session["MenuSetup_MenuList"] = value;
            }
        }

        private CustomList<SECURITY.DAO.MenuSetup> MenuTypeList
        {
            get
            {
                if (Session["MenuSetup_MenuTypeList"] == null)
                    return new CustomList<SECURITY.DAO.MenuSetup>();
                else
                    return (CustomList<SECURITY.DAO.MenuSetup>)Session["MenuSetup_MenuTypeList"];
            }
            set
            {
                Session["MenuSetup_MenuTypeList"] = value;
            }
        }

        private CustomList<SECURITY.DAO.MenuSetup> MenuListForDropDown
        {
            get
            {
                if (Session["MenuSetup_MenuListForDropDown"] == null)
                    return new CustomList<SECURITY.DAO.MenuSetup>();
                else
                    return (CustomList<SECURITY.DAO.MenuSetup>)Session["MenuSetup_MenuListForDropDown"];
            }
            set
            {
                Session["MenuSetup_MenuListForDropDown"] = value;
            }
        }

        private void InitializeSession()
        {
            try
            {
                MenuList = new CustomList<SECURITY.DAO.MenuSetup>();
                MenuList = manager.GetAllMenuForSetup();
                MenuListForDropDown = new CustomList<SECURITY.DAO.MenuSetup>();
                MenuListForDropDown = GetMenuList();
                MenuTypeList = new CustomList<SECURITY.DAO.MenuSetup>();
                MenuTypeList = manager.GetMenuType();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        private CustomList<SECURITY.DAO.MenuSetup> GetMenuList()
        {
            CustomList<SECURITY.DAO.MenuSetup> _List = new CustomList<SECURITY.DAO.MenuSetup>();
            _List.Add(new SECURITY.DAO.MenuSetup { MenuID = "0", DisplayMember = "Home" });
            _List.AddRange(manager.GellAllMenu());
            return _List;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<SECURITY.DAO.MenuSetup> menuList = (CustomList<SECURITY.DAO.MenuSetup>)MenuList;
                //if (!CheckUserAuthentication(menuList)) return;
                manager.SaveMenu(ref menuList);
                MenuList = manager.GetAllMenuForSetup();
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
    }
}