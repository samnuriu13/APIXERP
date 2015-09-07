<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="HeadCategoryCOAMap.aspx.cs" Inherits="API.UI.ACC.HeadCategoryCOAMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">

    <script src="<%= ResolveUrl("~/gridscripts/HeadCategoryCOAMap.js") %> " type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Head Category COA Map"></asp:Label>
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
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="1">+</asp:ListItem>
                            <asp:ListItem Value="2">-</asp:ListItem>
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
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:TextBox ID="txtName" runat="server" Width="150px" ReadOnly="false"
                                    BorderStyle="Double">
                                </asp:TextBox>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="tv" EventName="SelectedNodeChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <div style="overflow: auto; max-height: 400px;">
                            <%--<asp:TreeView ID="tv" runat="server" OnTreeNodeCheckChanged="tv_TreeNodeCheckChanged" ShowCheckBoxes="All">
                            </asp:TreeView>--%>
                            <asp:TreeView ID="tv" runat="server" ImageSet="Arrows"
                                OnSelectedNodeChanged="tv_SelectedNodeChanged">
                                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                    NodeSpacing="0px" VerticalPadding="0px" />
                                <SelectedNodeStyle CssClass="treeHover"></SelectedNodeStyle>
                            </asp:TreeView>
                        </div>
                    </fieldset>
                </div>
                <div style="width:10%; float:left;">
                     <asp:Button ID="btnAdd" runat="server" CssClass="button" Text="ADD" OnClick="btnAdd_Click" />
                </div>
                <div style="width: 30%; float: left">
                    <div>
                        <table id="grdHeadCategoryCOAMap">
                        </table>
                    </div>
                    <div id="grdHeadCategoryCOAMap_pager">
                    </div>
                </div>
            </div>

        </div>
        <div class="clear">
        </div>
        <br />
        <br />
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" />
            </div>
        </div>
    </div>
</asp:Content>
