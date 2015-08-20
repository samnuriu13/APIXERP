<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="WorkFlow.aspx.cs" Inherits="API.UI.Setup.WorkFlow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
        <script src="<%= ResolveUrl("~/gridscripts/WorkflowDetail.js") %> " type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Work Flow"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 33%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Work Flow ID</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtWorkFlowID" runat="server" CssClass="txtwidth93px" Style="width: 75%;"
                            MaxLength="100"></asp:TextBox>
                        <div style="float: right; margin-left: 5px;">
                            <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/new 20X20.png" OnClick="btnNew_Click" />
                            <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png" OnClick="btnFind_Click" />
                        </div>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Doc List</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlDocList" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
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
            <div style="width: 33%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Cost Center</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlCostCenter" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Department</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div style="width: 98%; float: left">
                <div>
                    <table id="grdWorkFlowDetail">
                    </table>
                </div>
                <div id="grdWorkFlowDetail_pager">
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
        </div>
    </div>

</asp:Content>
