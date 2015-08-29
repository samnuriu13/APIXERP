<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="ItemSegments.aspx.cs" Inherits="API.UI.ItemSetup.ItemSegments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/SegmentValues.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= ddlSegmentNames.ClientID %>").change(function (e) {
                var segmentNameID = $("#<%= ddlSegmentNames.ClientID %>").val();
                var retVal = jQuery.ajax
                        	        (
                        	            {
                        	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ItemSegment&SegmentNameID=' + segmentNameID,
                        	                async: false
                        	            }
                                    ).responseText;
                $("#grdSegmentValues").trigger("reloadGrid");
                $("#cphBody_cphInfbody_txtSegmentName").val($("#cphBody_cphInfbody_ddlSegmentNames option:selected").text());
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Item Segments"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 40%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Segment Names</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlSegmentNames" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlSegmentNames"
                            runat="server" ForeColor="Red" ErrorMessage="Segment Name is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Segment Name</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtSegmentName" runat="server" CssClass="txtwidth93px" Style="width: 75%;"
                            MaxLength="100"></asp:TextBox>
                        <div style="float: right; margin-left: 5px;">
                            <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/new 20X20.png" OnClick="btnNew_Click" />
                        </div>
                        <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            ControlToValidate="txtSegmentName" runat="server" ValidationGroup="Save" ForeColor="Red"
                            ErrorMessage="Segment Name is required">*</asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div style="float: left; width: 40%">
                <div>
                    <table id="grdSegmentValues">
                    </table>
                </div>
                <div id="grdSegmentValues_pager">
                </div>
            </div>
        </div>
        <div style="clear:both"></div>
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" OnClick="btnDelete_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="save" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
