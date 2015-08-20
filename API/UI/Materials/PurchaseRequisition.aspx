<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="PurchaseRequisition.aspx.cs" Inherits="API.UI.Materials.PurchaseRequisition" %>

<%@ Register Src="~/Controls/UC_Requisition.ascx" TagName="Requisition"
    TagPrefix="PS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <PS:Requisition ID="ctrlRequisition" runat="server"></PS:Requisition>
</asp:Content>
