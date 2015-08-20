<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="SubGroupItem.aspx.cs" Inherits="API.UI.ItemSetup.SubGroupItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
        <script src="<%= ResolveUrl("~/gridscripts/SubGroupItem.js") %> " type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Item Sub-Group"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 45%; height: auto;">
                <div>
                    <table id="grdItemSubGroup">
                    </table>
                </div>
                <div id="grdItemSubGroup_pager">
                </div>
            </div>
        </div>
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="save"
                    OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
