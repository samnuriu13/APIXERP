<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="ItemIssue.aspx.cs" Inherits="API.UI.Materials.ItemIssue" %>

<%@ Register Src="~/Controls/StockTransaction.ascx" TagName="MRR"
    TagPrefix="PS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <PS:MRR ID="ctrlRequisition" runat="server"></PS:MRR>
</asp:Content>
