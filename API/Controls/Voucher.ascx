<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Voucher.ascx.cs" Inherits="API.Controls.Voucher" %>

<script src="<%= ResolveUrl("~/gridscripts/PF_Voucher.js") %> " type="text/javascript"></script>
<script type="text/javascript">
    var menuName = '<%=MenuName%>';
    var gridCaption = '<%=GridCaption%>';
    var voucherType = '<%=prifix%>';

    $(document).ready(function () {
        try {
            $("input[id$='txtVoucherDate_nc']").datepicker({ dateFormat: "dd/mm/yy", showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), yearRange: '2007:2020' });
            $("input[id$='txtChequeDate']").datepicker({ dateFormat: "dd/mm/yy", showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date() });
            $(".Comhide").hide();
            if (voucherType == "BP" || voucherType == "BR") {
                $(".BPorBR").show();
            }
            else {
                $(".BPorBR").hide();
            }
            if (menuName == "CashPaymantVoucher" || menuName == "BankPaymentVoucher" || menuName == "BankReceiveVoucher" || menuName == "CashReceiveVoucher")
                $(".CashOrBank").show();
            else
                $(".CashOrBank").hide();

            $("#cphBody_cphInfbody_ctrlVoucher_btnDelete").click(function () {
                if ($("#cphBody_cphInfbody_ctrlVoucher_txtVoucher").val() != "****<< NEW >>****") {
                    ShowConfirmBox("Confirmation", "This will delete the voucher. Are you sure you want to continue?", "OkButtonClick", "CancelButtonClick");
                    return false;
                }
                else {
                    return false;
                }
            });
            $("#cphBody_cphInfbody_ctrlVoucher_btnSave").click(function () {
                var retVal = jQuery.ajax
                    (
                        {
                            url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=CheckTransaction&menuName=' + '<%=MenuName%>',
                            async: false
                        }
                    ).responseText
                if (parseInt(retVal) < 2) {
                    ShowMessageBox("HR", "To complete the transaction you should need to select account head from grid!");
                    return false;
                }
            });
        }
        catch (e)
        { alert(e); }
    });
    function OpenDialog_COA(vid) {
        //reload finder grid
        $('#grdFind').trigger('reloadGrid');

        $("#divFind").dialog('open');
        $("#divFind").dialog
        (
            {
                title: 'Find ',
                height: 450,
                width: 330,
                modal: true,
                zIndex: 10,
                buttons:
                {
                    Ok: function () {
                        if (getSelectedItem(vid))
                            $(this).dialog('close');
                    }
                }
            }
        )
    }
    function OpenDialog_Party(vid) {
        //reload finder grid
        $('#grdPartyFind').trigger('reloadGrid');

        $("#divPartyFind").dialog('open');
        $("#divPartyFind").dialog
        (
            {
                title: 'Find ',
                height: 450,
                width: 330,
                modal: true,
                zIndex: 10,
                buttons:
                {
                    Ok: function () {
                        if (getSelectedParty(vid))
                            $(this).dialog('close');
                    }
                }
            }
        )
    }
    function CancelButtonClick() {
        return false;
    }
    function OkButtonClick() {
        __doPostBack("vou_delete");
    }
</script>

<div class="form-wrapper">
    <div class="form-header">
        <asp:Label ID="lblFrmHeader" runat="server" Text="Journal Voucher"></asp:Label>
    </div>
    <div class="form-details">
        <div style="width: 33%; float: left">
            <div class="lblAndTxtStyle">
                <div class="divlblwidth100px bglbl">
                    <a>Voucher Date</a>
                </div>
                <div class="div80Px">
                    <asp:TextBox ID="txtVoucherDate_nc" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                </div>
                <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    ControlToValidate="txtVoucherDate_nc" runat="server" ValidationGroup="Save" ForeColor="Red"
                    ErrorMessage="Voucher Date is required">*</asp:RequiredFieldValidator>
            </div>
            <div class="lblAndTxtStyle">
                <div class="divlblwidth100px bglbl">
                    <a>Voucher No.</a>
                </div>
                <div class="div80Px">
                    <asp:TextBox ID="txtVoucher" runat="server" CssClass="txtwidth178px" Style="width: 80%;"
                        MaxLength="100" Enabled="false"></asp:TextBox>
                    <div style="float: right; margin-left: 0px;">
                        <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle btn-enable" ImageUrl="~/images/new 20X20.png"
                            OnClick="btnNew_Click" OnClientClick="enableControl()" Visible="false" />
                        <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle btn-enable"
                            OnClick="btnFind_Click" ImageUrl="~/images/Search 20X20.png" />
                    </div>
                </div>
            </div>
        </div>
        <div style="width: 33%; float: left">
            <asp:HiddenField ID="hfCOAKey" runat="server" />
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
            <div class="lblAndTxtStyle CashOrBank">
                <div class="divlblwidth100px bglbl">
                    <a>From/To A/C Code</a>
                </div>
                <div class="div80Px">
                    <asp:TextBox ID="txtHeadCode" runat="server" CssClass="txtwidth178px" MaxLength="100" Width="85%"></asp:TextBox>
                    <div style="float: right; margin-left: 0px;">
                        <asp:ImageButton ID="btnFindCOA" runat="server" CssClass="btnImageStyle btn-enable"
                            OnClick="btnFindCOA_Click" ImageUrl="~/images/Search 20X20.png" />
                    </div>
                </div>
            </div>
            <div class="lblAndTxtStyle CashOrBank">
                <div class="divlblwidth100px bglbl">
                    <a>From/To A/C Name</a>
                </div>
                <div class="div80Px">
                    <asp:TextBox ID="txtHeadName" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                </div>
            </div>
        </div>
        <div style="width: 33%; float: left">
            <div class="lblAndTxtStyle BPorBR">
                <div class="divlblwidth100px bglbl">
                    <a>Cheque No.</a>
                </div>
                <div class="div80Px">
                    <asp:TextBox ID="txtChequeNo" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                </div>
            </div>
            <div class="lblAndTxtStyle BPorBR">
                <div class="divlblwidth100px bglbl">
                    <a>Cheque Date</a>
                </div>
                <div class="div80Px">
                    <asp:TextBox ID="txtChequeDate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                </div>
            </div>
            <a>Voucher Description</a>
            <div class="lblAndTxtStyle">
                <asp:TextBox ID="txtVoucherDescription" runat="server" CssClass="txtwidth178px" TextMode="MultiLine"
                    MaxLength="500"></asp:TextBox>
            </div>
        </div>
        <div style="width: 98%; float: left">
            <div>
                <table id="grdPFVoucher">
                </table>
            </div>
            <div id="grdPFVoucher_pager">
            </div>
        </div>
    </div>
    <div class="clear">
    </div>
    <div id="divFind" style="display: none">
        <div>
            <table id="grdFind">
            </table>
        </div>
        <div id="grdFind_pager">
        </div>
    </div>
    <div id="divPartyFind" style="display: none">
        <div>
            <table id="grdPartyFind">
            </table>
        </div>
        <div id="grdPartyFind_pager">
        </div>
    </div>
    <br />
    <br />
    <div class="form-bottom">
        <div id="common" class="btnRight" runat="server">
            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="Save"
                OnClick="btnSave_Click" OnClientClick="CheckValidity();" />
            &nbsp;&nbsp;
                <asp:Button ID="btnClear" runat="server" CssClass="button" Text="Cancel" Visible="true"
                    OnClick="btnClear_Click" />
            &nbsp;&nbsp;
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" Visible="true"
                    OnClick="btnDelete_Click" />
            &nbsp;&nbsp;
                <asp:Button ID="btnPreview" runat="server" CssClass="button" Text="Preview" Visible="true"
                    OnClick="btnPreview_Click" />
        </div>
        <div style="clear: both"></div>
        <div id="workflow" class="btnRight" runat="server">
            <div style="float: left">
                <a>Comment</a>
                <div class="lblAndTxtStyle">
                    <asp:TextBox ID="txtComment" runat="server" CssClass="button" TextMode="MultiLine"
                        MaxLength="500"></asp:TextBox>
                </div>
            </div>

            <div style="float: left">
                <asp:Button ID="btnApproved" runat="server" CssClass="button" Text="Approved" />
                &nbsp;&nbsp;
                <asp:Button ID="btnReject" runat="server" CssClass="button" Text="Reject" Visible="true" />
            </div>
        </div>
    </div>
</div>
