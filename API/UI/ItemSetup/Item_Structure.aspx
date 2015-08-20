<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="Item_Structure.aspx.cs" Inherits="API.UI.ItemSetup.Item_Structure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/ItemStructure.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= ddlItemGroup.ClientID %>").change(function (e) {
                var itemGroupID = $("#<%= ddlItemGroup.ClientID %>").val();
                var retVal = jQuery.ajax
                        	        (
                        	            {
                        	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ItemStructure&itemGroupID=' + itemGroupID,
                        	                async: false
                        	            }
                                    ).responseText;
                $("#grdItemStructure").trigger("reloadGrid");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Item Structure"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 40%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Item Group</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlItemGroup" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlItemGroup"
                            runat="server" ForeColor="Red" ErrorMessage="Item Group is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div style="float: left; width: 40%">
                <div>
                    <table id="grdItemStructure">
                    </table>
                </div>
                <div id="grdItemStructure_pager">
                </div>
            </div>
        </div>
        <div style="clear: both"></div>
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="save" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
