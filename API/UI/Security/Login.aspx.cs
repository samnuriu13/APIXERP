﻿using System;
using System.Web.UI;
using SECURITY.BLL;
using SECURITY.DAO;
using UserSession = STATIC.User;
using FRAMEWORK;
using API.DATA;
using API;
using Enc = STATIC.EncDec;


namespace API.UI.Security
{
    public partial class Login : PageBase
    {

        public Login()
        {
            RequiresAuthorization = false;
        }

        ApplicationManager manager_application = new ApplicationManager();
        SecurityManager manager = new SecurityManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.DataBind();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = Enc.Encrypt(txtLoginName.Text, STATIC.StaticInfo.encString);
                string password = Enc.Encrypt(txtLoginPassword.Text, STATIC.StaticInfo.encString);

                if (!DoLogin(userName, password))
                {
                    ((SiteLoggedOff)this.Page.Master).srvMsg = ("Invalid Username or Password.");
                    ((SiteLoggedOff)this.Page.Master).srvMsgCss = STATIC.StaticInfo.ErrorCss;
                }
                else //login successful
                {
                    Session["Static_Theme"] = ((PageBase)Page).CurrentUserSession.DefaultTheme;

                    if (Request.Params["back_url"] != null
                    && Request.Params["back_url"].Length > 0)
                        Response.Redirect(Request.Params["back_url"]);
                    else
                        Response.Redirect("~/Home.aspx");
                }
            }
            catch (Exception ex)
            {
                ((SiteLoggedOff)this.Page.Master).srvMsg = "Error: \n" + ex.Message;
                ((SiteLoggedOff)this.Page.Master).srvMsgCss = STATIC.StaticInfo.ErrorCss;
            }
        }

        private bool DoLogin(string userName, string password)
        {
            try
            {
                Users currentUser = manager.GetUserByNameAndPassword(userName, password);
                if (currentUser.UserCode == null)
                    return false;
                else
                {
                    UserSession _uSession = new STATIC.User();

                    _uSession.IsAdmin = Convert.ToBoolean(currentUser.IsAdmin);
                    _uSession.IsLoggedIn = true;
                    _uSession.UserCode = currentUser.UserCode;
                    _uSession.UserName = currentUser.UserName;
                    _uSession.PersonName = currentUser.Name;
                    _uSession.Password = currentUser.Password;
                    _uSession.EmployeeCode = currentUser.EmpCode;
                    _uSession.EmpName = currentUser.EmpName;
                    _uSession.Company = currentUser.Company;
                    _uSession.Department = currentUser.Department;
                    _uSession.EmpType = currentUser.EmpType;
                    _uSession.Grade = currentUser.Grade;
                    _uSession.Designation = currentUser.Designation;
                    _uSession.EmpKey = currentUser.EmpKey;

                    ProfileManager manager_profile = new ProfileManager();
                    CustomList<UserProfile> UserProfileList = new CustomList<UserProfile>();
                    UserProfileList = new CustomList<UserProfile>();

                    if (UserProfileList.Count != 0)
                    {
                        _uSession.DefaultApplicationID = UserProfileList[0].DefaultAppID;
                        _uSession.DefaultTheme = UserProfileList[0].ThemeName;
                    }
                    else
                    {
                        _uSession.DefaultTheme = "Default";
                    }

                    _uSession.CurrentApplicationID = _uSession.DefaultApplicationID;

                    ((PageBase)Page).CurrentUserSession = _uSession;
                    ((PageBase)Page).OpenPages = new System.Collections.Generic.List<string>();

                    return true;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
