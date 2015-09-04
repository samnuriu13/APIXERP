<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="DocListFormatSettings.aspx.cs" Inherits="API.UI.Setup.DocListFormatSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/DocListFormatSettings.js") %> " type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="float: left; width: 35%">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Custom code</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtCustomCode" runat="server" CssClass="txtwidth93px" Style="width: 75%;"
                            MaxLength="100" ReadOnly="true"></asp:TextBox>
                        <div style="float: right; margin-left: 5px;">
                            <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/new 20X20.png" />
                            <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png" />
                        </div>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Menu Name/Doc List</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlMenuName" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlMenuName"
                            runat="server" ForeColor="Red" ErrorMessage="Menu Name is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Prefix</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtPrefix" runat="server" CssClass="txtwidth93px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Sufix</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtSufix" runat="server" CssClass="txtwidth93px" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Period Type</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlPeriodType" runat="server" CssClass="drpwidth180px">
                            <asp:ListItem Text="Monthly" Value="Monthly"></asp:ListItem>
                            <asp:ListItem Text="Yearly" Value="Yearly"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div style="float: left; width: 50%">
                <div>
                    <table id="grdDocListFormatSettings">
                    </table>
                </div>
                <div id="grdDocListFormatSettings_pager">
                </div>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <br />
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="save" />
            </div>
        </div>
    </div>
</asp:Content>
