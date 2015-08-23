<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="HeadCategory.aspx.cs" Inherits="API.UI.ACC.HeadCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/HeadCategory.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= ddlReportType.ClientID %>").change(function (e) {
                var reportType = $("#<%= ddlReportType.ClientID %>").val();
                var retVal = jQuery.ajax
                                    (
                                        {
                                            url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=FilterByReportType&ReportType=' + reportType,
                                            async: false
                                        }
                                    ).responseText;
                $("#grdHeadCategory").trigger("reloadGrid");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Head Category"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 40%">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Report Type</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlReportType" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlReportType"
                            runat="server" ForeColor="Red" ErrorMessage="Report Type is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 70%; float: left">
                <div>
                    <table id="grdHeadCategory">
                    </table>
                </div>
                <div id="grdHeadCategory_pager">
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <br />
        <br />
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
