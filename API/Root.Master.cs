﻿using System;
using System.Web.UI;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web;
using SECURITY.DAO;
using API.DATA;
using System.Linq;

namespace API
{
    public partial class Root : System.Web.UI.MasterPage
    {
        public string appRootPath
        {
            get
            {
                //var url = new Uri(Request.Url.AbsoluteUri);
                //return url.GetLeftPart(UriPartial.Authority);
                return Page.ResolveClientUrl("~");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string script = "$(document).ready(function () { $('[id*=btnSubmit]').click(); });";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
                stBreadcrumb.Visible = (SiteMap.CurrentNode != SiteMap.RootNode);
            }

            Page.Header.DataBind();

            String csname = "OnSubmitScript";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            if (!cs.IsOnSubmitStatementRegistered(cstype, csname))
            {
                String cstext = "g_isPostBack = true;";
                cs.RegisterOnSubmitStatement(cstype, csname, cstext);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }
    }
}