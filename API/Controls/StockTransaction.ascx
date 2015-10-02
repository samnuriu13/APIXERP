<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StockTransaction.ascx.cs" Inherits="API.Controls.StockTransaction" %>
<%@ Register Src="~/Controls/TransRef.ascx" TagPrefix="uc1" TagName="TransRef" %>

<script src="<%= ResolveUrl("~/gridscripts/StockTransaction.js") %> " type="text/javascript"></script>
<script type="text/javascript">
    var menuName = '<%=MenuName%>';
    var gridCaption = '<%=GridCaption%>';
    $(document).ready(function () {
        $("input[id$='txtTransactionDate'], .datepicker").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), dateFormat: 'mm/dd/yy' });
        $("#cphBody_cphInfbody_ctrlRequisition_TransRef_ddlReference").change(function (e) {
            var stockID = $("#cphBody_cphInfbody_ctrlRequisition_TransRef_ddlReference").val();
            var stockTest = $("#cphBody_cphInfbody_ctrlRequisition_TransRef_ddlReference option:selected").text();
            var refNo = $("#cphBody_cphInfbody_ctrlRequisition_TransRef_txtRefNo").val();
            var transTypeID = $("#cphBody_cphInfbody_ctrlRequisition_TransRef_ddlRefType").val();
            var refTypeTest = $("#cphBody_cphInfbody_ctrlRequisition_TransRef_ddlRefType option:selected").text();

            var retVal = jQuery.ajax
                                (
                                    {
                                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=GetRefDetail&stockID=' + stockID + '&&menuName=' + menuName + '&&stockTest=' + stockTest + '&&transTypeID=' + transTypeID + '&&refTypeTest=' + refTypeTest + '&&refNo=' + refNo,
                                        async: false
                                    }
                                ).responseText;
            $("#grdStockTransaction").trigger("reloadGrid");
        });
        if (menuName == "OpeningStock") {
            $("#cphBody_cphInfbody_ctrlRequisition_ddlCurrencyID").attr("disabled", true);
            $("#cphBody_cphInfbody_ctrlRequisition_ddlParty").attr("disabled", true);
            $("#cphBody_cphInfbody_ctrlRequisition_ddlFromBranch").attr("disabled", true);
            $("#cphBody_cphInfbody_ctrlRequisition_ddlFromCostCentre").attr("disabled", true);
            $("#cphBody_cphInfbody_ctrlRequisition_ddlFromStockLocation").attr("disabled", true);
            $("#cphBody_cphInfbody_ctrlRequisition_TransRef_txtRefNo").attr("disabled", true);
            $("#cphBody_cphInfbody_ctrlRequisition_TransRef_ddlRefType").attr("disabled", true);
            $("#cphBody_cphInfbody_ctrlRequisition_TransRef_ddlReference").attr("disabled",true);
        }
        else if (menuName == "MaterialReceive" || menuName == "IssueReturn") {
            $("#cphBody_cphInfbody_ctrlRequisition_ddlFromBranch").attr("disabled", true);
            $("#cphBody_cphInfbody_ctrlRequisition_ddlFromCostCentre").attr("disabled", true);
            $("#cphBody_cphInfbody_ctrlRequisition_ddlFromStockLocation").attr("disabled", true);
        }
        else if (menuName == "PurchaseReturn" || menuName == "MaterialIssue") {
            $("#cphBody_cphInfbody_ctrlRequisition_ddlToBranch").attr("disabled", true);
            $("#cphBody_cphInfbody_ctrlRequisition_ddlToCostCentre").attr("disabled", true);
            $("#cphBody_cphInfbody_ctrlRequisition_ddlToStockLocation").attr("disabled", true);
        }
        });
</script>

<div class="form-wrapper">
    <div class="form-header">
        <asp:Label ID="lblFrmHeader" runat="server" Text="Stock Transaction"></asp:Label>
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
                    <asp:TextBox ID="txtTransactionDate" runat="server" CssClass="txtwidth178px datepicker" MaxLength="100"></asp:TextBox>
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
                    <a>Party</a>
                </div>
                <div class="div182Px">
                    <asp:DropDownList ID="ddlParty" runat="server" CssClass="drpwidth180px">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="lblAndTxtStyle">
                <div class="divlblwidth100px bglbl">
                    <a>From Branch/Unit</a>
                </div>
                <div class="div182Px">
                    <asp:DropDownList ID="ddlFromBranch" runat="server" CssClass="drpwidth180px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlFromBranch"
                        runat="server" ForeColor="Red" ErrorMessage="From Branch is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div style="width: 33%; float: left">
            <div class="lblAndTxtStyle">
                <div class="divlblwidth100px bglbl">
                    <a>From Cost Centre</a>
                </div>
                <div class="div182Px">
                    <asp:DropDownList ID="ddlFromCostCentre" runat="server" CssClass="drpwidth180px" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlFromCostCentre_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="lblAndTxtStyle">
                <div class="divlblwidth100px bglbl">
                    <a>From Stock Location</a>
                </div>
                <div class="div182Px">
                    <asp:DropDownList ID="ddlFromStockLocation" runat="server" CssClass="drpwidth180px">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="lblAndTxtStyle">
                <div class="divlblwidth100px bglbl">
                    <a>To Branch/Unit</a>
                </div>
                <div class="div182Px">
                    <asp:DropDownList ID="ddlToBranch" runat="server" CssClass="drpwidth180px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlToBranch"
                        runat="server" ForeColor="Red" ErrorMessage="To Branch is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="lblAndTxtStyle">
                <div class="divlblwidth100px bglbl">
                    <a>To Cost Centre</a>
                </div>
                <div class="div182Px">
                    <asp:DropDownList ID="ddlToCostCentre" runat="server" CssClass="drpwidth180px" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlToCostCentre_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div style="float: left; width: 33%">
            <div class="lblAndTxtStyle">
                <div class="divlblwidth100px bglbl">
                    <a>To Stock Location</a>
                </div>
                <div class="div182Px">
                    <asp:DropDownList ID="ddlToStockLocation" runat="server" CssClass="drpwidth180px">
                    </asp:DropDownList>
                </div>
            </div>
            <uc1:TransRef runat="server" ID="TransRef" />
        </div>
        <br />
        <div style="float: left; width: 98%">
            <div>
                <table id="grdStockTransaction">
                </table>
            </div>
            <div id="grdStockTransaction_pager">
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
            <asp:Button ID="btnPreview" runat="server" CssClass="button" Text="Preview" OnClick="btnPreview_Click" />
        </div>
    </div>
</div>
