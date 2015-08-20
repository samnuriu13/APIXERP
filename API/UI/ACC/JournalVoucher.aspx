<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="JournalVoucher.aspx.cs" Inherits="API.UI.ACC.JournalVoucher" %>
<%@ Register Src="~/Controls/Voucher.ascx" TagName="ucVoucher" TagPrefix="PS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
        <PS:ucVoucher ID="ctrlVoucher" runat="server"></PS:ucVoucher>
</asp:Content>
