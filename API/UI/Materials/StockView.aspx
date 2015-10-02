<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="StockView.aspx.cs" Inherits="API.UI.Materials.StockView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
        <script src="<%= ResolveUrl("~/gridscripts/StockView.js") %> " type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
        <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Bank Reconciliation"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 33%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Branch/Unit</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlBranchOrUnit" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div style="width: 33%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Cost Center</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlCostCenter" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div style="width: 33%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Stock Location</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlStockLocation" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    </div>
                </div>
                <div style="text-align: center">
                    <asp:Button ID="btnFilter" runat="server" CssClass="button" Text="Filter" />
                </div>
            </div>
            <div style="clear: both"></div>
            <div style="width: 98%">
                <div>
                    <table id="grdStockView">
                    </table>
                </div>
                <div id="grdStockView_pager">
                </div>
            </div>
        </div>
        <div style="clear: both"></div>
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnPreview" runat="server" CssClass="button" Text="Preview" Visible="true" />
            </div>
        </div>
    </div>
</asp:Content>
