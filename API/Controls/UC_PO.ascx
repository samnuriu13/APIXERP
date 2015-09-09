<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_PO.ascx.cs" Inherits="API.Controls.UC_PO" %>
<%@ Register Src="~/Controls/TransRef.ascx" TagPrefix="uc1" TagName="TransRef" %>

<script src="<%= ResolveUrl("~/gridscripts/PO.js") %> " type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("input[id$='txtTransactionDate'], .datepicker").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), dateFormat: 'mm/dd/yy' });
        $("#cphBody_cphInfbody_ctrlPO_TransRef_ddlReference").change(function (e) {
            var POID = $("#cphBody_cphInfbody_ctrlPO_TransRef_ddlReference").val();
            var refTypeID = $("#cphBody_cphInfbody_ctrlPO_TransRef_ddlRefType").val();
            var refTypeTest = $("#cphBody_cphInfbody_ctrlPO_TransRef_ddlRefType option:selected").text();
            var POTest = $("#cphBody_cphInfbody_ctrlPO_TransRef_ddlReference option:selected").text();
            var refNo = $("#cphBody_cphInfbody_ctrlPO_TransRef_txtRefNo").val();
            var retVal = jQuery.ajax
                                (
                                    {
                                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=GetRefTransDetail&RefID=' + POID + '&&POTest=' + POTest + '&&refTypeID=' + refTypeID + '&&refTypeTest=' + refTypeTest + '&&refNo=' + refNo,
                                        async: false
                                    }
                                ).responseText;
            $("#grdPO").trigger("reloadGrid");
        });
    });
</script>

<div class="form-wrapper">
    <div class="form-header">
        <asp:Label ID="lblFrmHeader" runat="server" Text="Purchase Order"></asp:Label>
    </div>
    <div class="form-details">
        <div style="width: 33%; float: left">
            <div class="lblAndTxtStyle">
                <div class="divlblwidth100px bglbl">
                    <a>Custom Code</a>
                </div>
                <div class="div80Px">
                    <asp:TextBox ID="txtCustomCode" runat="server" CssClass="txtwidth93px" Style="width: 75%;"
                        MaxLength="100"></asp:TextBox>
                    <div style="float: right; margin-left: 5px;">
                        <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/new 20X20.png" OnClick="btnNew_Click" />
                        <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png" OnClick="btnFind_Click" />
                    </div>
                </div>
            </div>
            <div class="lblAndTxtStyle">
                <div class="divlblwidth100px bglbl">
                    <a>Transaction date</a>
                </div>
                <div class="div80Px">
                    <asp:TextBox ID="txtTransactionDate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                </div>
            </div>
            <div class="lblAndTxtStyle">
                <div class="divlblwidth100px bglbl">
                    <a>Party</a>
                </div>
                <div class="div182Px">
                    <asp:DropDownList ID="ddlParty" runat="server" CssClass="drpwidth180px">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="lblAndTxtStyle">
                <div class="divlblwidth100px bglbl">
                    <a>Currency</a>
                </div>
                <div class="div182Px">
                    <asp:DropDownList ID="ddlCurrencyID" runat="server" CssClass="drpwidth180px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlCurrencyID"
                        runat="server" ForeColor="Red" ErrorMessage="Cost Centre is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="lblAndTxtStyle">
                <div class="divlblwidth100px bglbl">
                    <a>Cost Centre</a>
                </div>
                <div class="div182Px">
                    <asp:DropDownList ID="ddlCostCentre" runat="server" CssClass="drpwidth180px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlCostCentre"
                        runat="server" ForeColor="Red" ErrorMessage="Cost Center is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="lblAndTxtStyle">
                <div class="divlblwidth100px bglbl">
                    <a>Department</a>
                </div>
                <div class="div182Px">
                    <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="drpwidth180px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlDepartment"
                        runat="server" ForeColor="Red" ErrorMessage="Department is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div style="width: 33%; float: left">
            <div class="lblAndTxtStyle">
                <div class="divlblwidth100px bglbl">
                    <a>Expected Receipt Date</a>
                </div>
                <div class="div80Px">
                    <asp:TextBox ID="txtExpectedReceiveDate" runat="server" CssClass="txtwidth178px datepicker" MaxLength="100"></asp:TextBox>
                </div>
            </div>
            <div class="lblAndTxtStyle">
                <a>Ship To</a>
                <asp:TextBox ID="txtShipTo" runat="server" CssClass="txtwidth178px" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
            </div>
            <div class="lblAndTxtStyle">
                <a>Bill To</a>
                <asp:TextBox ID="txtBillTo" runat="server" CssClass="txtwidth178px" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
            </div>
        </div>
        <div style="width: 33%; float: left">
            <div class="lblAndTxtStyle">
                <a>Note</a>
                <asp:TextBox ID="txtNote" runat="server" CssClass="txtwidth178px" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
            </div>
            <uc1:TransRef runat="server" ID="TransRef" />
        </div>

        <div style="float: left; width: 98%">
            <div>
                <table id="grdPO">
                </table>
            </div>
            <div id="grdPO_pager">
            </div>
        </div>
    </div>
    <div style="clear: both"></div>
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
        <div class="btnRight">
            <asp:Button ID="btnPreview" runat="server" CssClass="button" Text="Preview" />
        </div>
    </div>
</div>
