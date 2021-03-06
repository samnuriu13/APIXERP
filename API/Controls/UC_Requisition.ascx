﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Requisition.ascx.cs" Inherits="API.Controls.UC_Requisition" %>
<%@ Register Src="~/Controls/TransRef.ascx" TagPrefix="uc1" TagName="TransRef" %>

<script src="<%= ResolveUrl("~/gridscripts/ItemRequisition.js") %> " type="text/javascript"></script>
<script type="text/javascript">
    var menuName = '<%=MenuName%>';
    var gridCaption = '<%=GridCaption%>';
    $(document).ready(function () {
        $("input[id$='txtRequisitionDate'], .datepicker").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), dateFormat: 'mm/dd/yy' });
        //$("#<%= ddlCostCentre.ClientID %>").change(function (e) {
        // var costCenterID = $("#<%= ddlCostCentre.ClientID %>").val();
        // var retVal = jQuery.ajax
        //         (
        //          {
        //              url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=deptWiseGroup&CostCenterID=' + costCenterID,
        //           async: false
        //    }
        // ).responseText;
        // $("#grdItemRequisition").trigger("reloadGrid");
        // });
        $("#cphBody_cphInfbody_ctrlRequisition_TransRef_ddlReference").change(function (e) {
            var refTypeID = $("#cphBody_cphInfbody_ctrlRequisition_TransRef_ddlRefType").val();
            var refTypeTest = $("#cphBody_cphInfbody_ctrlRequisition_TransRef_ddlRefType option:selected").text();
            var requisitionID = $("#cphBody_cphInfbody_ctrlRequisition_TransRef_ddlReference").val();
            var requisitionTest = $("#cphBody_cphInfbody_ctrlRequisition_TransRef_ddlReference option:selected").text();
            var refNo = $("#cphBody_cphInfbody_ctrlRequisition_TransRef_txtRefNo").val();
            var retVal = jQuery.ajax
                                (
                                    {
                                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=GetRequisitionDetail&requisitionID=' + requisitionID + '&&menuName=' + menuName + '&&requisitionTest=' + requisitionTest + '&&refTypeID=' + refTypeID + '&&refTypeTest=' + refTypeTest + '&&refNo=' + refNo,
                                        async: false
                                    }
                                ).responseText;
            $("#grdItemRequisition").trigger("reloadGrid");
        });
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
                    <a>Requisition No</a>
                </div>
                <div class="div80Px">
                    <asp:TextBox ID="txtRequisitionNo" runat="server" CssClass="txtwidth93px" Style="width: 75%;"
                        MaxLength="100" ReadOnly="true"></asp:TextBox>
                    <div style="float: right; margin-left: 5px;">
                        <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/new 20X20.png" OnClick="btnNew_Click" />
                        <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png" OnClick="btnFind_Click" />
                    </div>
                </div>
            </div>
            <div class="lblAndTxtStyle">
                <div class="divlblwidth100px bglbl">
                    <a>Requisition date</a>
                </div>
                <div class="div80Px">
                    <asp:TextBox ID="txtRequisitionDate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    <%--                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtRequisitionDate"
                        runat="server" ForeColor="Red" ErrorMessage="Requisition Date is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>--%>
                </div>
            </div>
            <div class="lblAndTxtStyle">
                <div class="divlblwidth100px bglbl">
                    <a>Party</a>
                </div>
                <div class="div182Px">
                    <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="drpwidth180px">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div style="width: 33%; float: left">
            <div class="lblAndTxtStyle">
                <div class="divlblwidth100px bglbl">
                    <a>Branch/Unit</a>
                </div>
                <div class="div182Px">
                    <asp:DropDownList ID="ddlBranchID" runat="server" CssClass="drpwidth180px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlBranchID"
                        runat="server" ForeColor="Red" ErrorMessage="Branch is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="lblAndTxtStyle">
                <div class="divlblwidth100px bglbl">
                    <a>Cost Centre</a>
                </div>
                <div class="div182Px">
                    <asp:DropDownList ID="ddlCostCentre" runat="server" CssClass="drpwidth180px" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlCostCentre_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlCostCentre"
                        runat="server" ForeColor="Red" ErrorMessage="Cost Centre is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="lblAndTxtStyle">
                <a>Note</a>
                <asp:TextBox ID="txtNote" runat="server" CssClass="txtwidth178px" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
            </div>
        </div>
        <div style="width: 33%; float: left">
            <uc1:TransRef runat="server" ID="TransRef" />
        </div>
        <div style="float: left; width: 98%; padding-top: 20px">
            <div>
                <table id="grdItemRequisition">
                </table>
            </div>
            <div id="grdItemRequisition_pager">
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

