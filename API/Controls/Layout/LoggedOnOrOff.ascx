<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoggedOnOrOff.ascx.cs"
    Inherits="API.Controls.Layout.LoggedOnOrOff" %>
<%@ Register Src="~/Controls/Layout/HeaderSettings.ascx" TagName="HeaderSettings"
    TagPrefix="st" %>
<span>Welcome,</span><span> <b>
    <%= ((FRAMEWORK.PageBase)this.Page).CurrentUserSession == null ? "" : ((FRAMEWORK.PageBase)this.Page).CurrentUserSession.PersonName%></b>
</span><span></span><span></span>
<st:HeaderSettings ID="ctrlHeaderSettings" runat="server" />
