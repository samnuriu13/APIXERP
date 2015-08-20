<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="MailSetup.aspx.cs" Inherits="API.UI.Setup.MailSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/EmailAddressList.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#cphBody_cphInfbody_chkIndividual").click(function (e) {
                var isIndividual = false;
                if ($("#cphBody_cphInfbody_chkIndividual").is(":checked"))
                    isIndividual = true
                var retVal = jQuery.ajax
                        (
                            {
                                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=CheckAllIndividual&IsIndividual=' + isIndividual,
                                async: false
                            }
                        ).responseText
                $("#grdEmailAddressList").trigger("reloadGrid");
            }); 
            $("#cphBody_cphInfbody_chkSupervisor").click(function (e) {
                var isSupervisor = false;
                if ($("#cphBody_cphInfbody_chkSupervisor").is(":checked"))
                    isSupervisor = true
                var retVal = jQuery.ajax
                        (
                            {
                                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=CheckAllSupervisor&IsSupervisor=' + isSupervisor,
                                async: false
                            }
                        ).responseText
                $("#grdEmailAddressList").trigger("reloadGrid");
            });
            $("#cphBody_cphInfbody_chkHOD").click(function (e) {
                var isHOD = false;
                if ($("#cphBody_cphInfbody_chkHOD").is(":checked"))
                    isHOD = true
                var retVal = jQuery.ajax
                        (
                            {
                                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=CheckAllHOD&IsHOD=' + isHOD,
                                async: false
                            }
                        ).responseText
                $("#grdEmailAddressList").trigger("reloadGrid");
            });
            $("#<%= txtEmpCode.ClientID %>").keyup(function (event) {

                var _empCode = $(this).val();
                var selectionCriteria = $('#cphBody_cphInfbody_ddlSelectionCritaria').val();
                if (event.keyCode == 13 && event.which == 13) {
                    if (_empCode == '') return;
                    else {
                        if ($("#cphBody_cphInfbody_chkOptional").is(":checked")) {
                            retval = jQuery.ajax
                        (
                            {
                                url: rootPath + "GridHelperClasses/DataHandler.ashx?CallMode=_SearchByEmpCodeToSetEmail&SelectionCriteria=" + selectionCriteria + "&EmpCode=" + _empCode,
                                async: false
                            }
                        ).responseText;
                            if (retval == "false") {
                                ShowMessageBox("HR", "No employee found with this Employee ID Or Email Address is Empty.");
                                return false;
                            }
                            else {
                                $("#grdEmailAddressList").trigger("reloadGrid");
                                $('#cphBody_cphInfbody_txtEmpCode').val("");
                            }
                        }
                        else {
                            ShowMessageBox("HR", "Please Checked Optional.");
                            return;
                        }
                    }
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Mail Setup"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 40%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Report List</a>
                    </div>
                    <div class="div80Px">
                        <asp:DropDownList ID="ddlReportList" runat="server" CssClass="drpwidth180px" OnSelectedIndexChanged="ddlReportList_SelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlReportList"
                            runat="server" ForeColor="Red" ErrorMessage="Please select report list!" ValidationGroup="save">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="tmp5">
                    <div style="width: 25%;">
                        <asp:CheckBox ID="chkIndividual" Text="Individual" CssClass="fieldset-legend" runat="server" />
                    </div>
                    <div style="width: 25%;">
                        <asp:CheckBox ID="chkDirector" Text="Director" CssClass="fieldset-legend" runat="server" />
                    </div>
                    <div style="width: 25%;">
                        <asp:CheckBox ID="chkSupervisor" Text="Supervisor" CssClass="fieldset-legend" runat="server" />
                    </div>
                    <div style="width: 25%;">
                        <asp:CheckBox ID="chkHOD" Text="HOD" CssClass="fieldset-legend" runat="server" />
                    </div>
                    <div style="width: 25%;">
                        <asp:CheckBox ID="chkOptional" Text="Optional" CssClass="fieldset-legend" runat="server" />
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>E-Mail Subject</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtSubject" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>E-Mail File Name</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtFileName" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div>
                    <a>E-mail Body</a>
                    <div class="lblAndTxtStyle">
                        <div>
                            <asp:TextBox ID="txtBody" runat="server" CssClass="txtwidth178px allowEnter"
                                TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="tmp5">
                    <div style="width: 100%;">
                        <asp:CheckBox ID="chkSubject" Text="E-Mail Subject Month And Year Name Required." CssClass="fieldset-legend" runat="server" />
                    </div>
                    <div style="width: 100%;">
                        <asp:CheckBox ID="chkFileName" Text="File Month And Year Name Required." CssClass="fieldset-legend" runat="server" />
                    </div>
                </div>
            </div>
            <div style="width: 60%; float: left">
                <div>
                    <div style="float: left; width: 80%">
                        <a>Employee Code</a>
                        <asp:TextBox ID="txtEmpCode" runat="server" CssClass="txtwidth178px" Width="99.6%"
                            MaxLength="100"></asp:TextBox>
                    </div>
                    <div style="float: left; width: 20%">
                        <a>Search Options</a>
                        <asp:DropDownList ID="ddlSelectionCritaria" runat="server" CssClass="drpwidth180px"
                            Width="92.6%" Font-Size="11px">
                            <asp:ListItem Text="EmpCode" Value="EmpCode" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div style="width: 98.6%">
                    <table id="grdEmailAddressList">
                    </table>
                </div>
                <div id="grdEmailAddressList_pager">
                </div>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" OnClick="btnDelete_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="save"
                    OnClick="btnSave_Click" OnClientClick="CheckValidity();" />
            </div>
        </div>
        <div style="clear: both">
        </div>
    </div>
</asp:Content>
