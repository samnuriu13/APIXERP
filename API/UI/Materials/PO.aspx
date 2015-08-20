<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="PO.aspx.cs" Inherits="API.UI.Materials.PO" %>

<%@ Register Src="~/Controls/UC_PO.ascx" TagName="PO"
    TagPrefix="PS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <PS:PO ID="ctrlPO" runat="server"></PS:PO>
</asp:Content>
