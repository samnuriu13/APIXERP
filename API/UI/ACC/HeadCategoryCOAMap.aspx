<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="HeadCategoryCOAMap.aspx.cs" Inherits="API.UI.ACC.HeadCategoryCOAMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Head Category"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 40%; float: left">
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
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Sequence</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtSequence" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div style="width: 40%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Head Category</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlHeadCategory" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlHeadCategory"
                            runat="server" ForeColor="Red" ErrorMessage="Report Type is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Operator</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlOperator" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlOperator"
                            runat="server" ForeColor="Red" ErrorMessage="Operator is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <div>
                <div style="float: left; width: 40%; padding-bottom: 10px; min-height: 300px;">
                    <fieldset class="fieldset-panel" style="min-height: 200px;">
                        <legend class="fieldset-legend">Account Heads</legend>
                        <div style="overflow: auto; max-height: 400px;">
                            <asp:TreeView ID="tv" runat="server" OnTreeNodeCheckChanged="tv_TreeNodeCheckChanged" ShowCheckBoxes="All" >
                            </asp:TreeView>
                        </div>
                    </fieldset>
                </div>
            </div>
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
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save"/>
            </div>
        </div>
    </div>
</asp:Content>
