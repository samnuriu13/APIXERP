using System;
using System.Web;
using STATIC;

namespace API
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
#if DEBUG
            {
                ////StaticInfo.ImageSavePath = Server.MapPath("~/UserFileUpload");
                //StaticInfo.ImageViewPath = "http://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"] + @"/UserFileUpload";
                StaticInfo.hostName = "http://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"];

            }
#else
            {
                //StaticInfo.ImageSavePath = Server.MapPath("~/UserFileUpload");
                //StaticInfo.ImageViewPath = @"/Shoilee" + @"/UserFileUpload";
                StaticInfo.hostName = @"/Shoilee";
            }
#endif
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            String sessionId = HttpContext.Current.Session.SessionID;

#if DEBUG
            {
                //StaticInfo.ImageTmpSavePath = Server.MapPath("~/TemporaryUserFiles/" + sessionId);
                //StaticInfo.ImageTmpViewPath = "http://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"] + @"/TemporaryUserFiles/" + sessionId;
            }
#else
            {
                //StaticInfo.ImageTmpSavePath = Server.MapPath("~/TemporaryUserFiles/" + sessionId);
                //StaticInfo.ImageTmpViewPath = @"/Shoilee" + @"/TemporaryUserFiles/" + sessionId;
            }
#endif
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }
        protected void Session_End(object sender, EventArgs e)
        {
           
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}