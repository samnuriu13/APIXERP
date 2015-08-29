<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="TransactionType.aspx.cs" Inherits="API.UI.Setup.TransactionType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="width: 100%; height: auto; margin-top: 5px">
                <div style="float: left; width: 40%">
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Bank Name</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtBankName" runat="server" CssClass="txtwidth93px" Style="width: 80%;"
                                MaxLength="100"></asp:TextBox>
                            <div style="float: right; margin-left: 5px;">
                                <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/new 20X20.png" />
                                <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png" />
                            </div>
                            <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                ControlToValidate="txtBankName" runat="server" ValidationGroup="Save" ForeColor="Red"
                                ErrorMessage="Bank Name is required">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Bank Short Name</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtBankSName" runat="server" CssClass="txtwidth93px" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Address</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="txtwidth93px" MaxLength="100"
                                TextMode="MultiLine"></asp:TextBox>
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
                </div>
                <div style="float: left; width: 60%;">
                    <div>
                        <table id="grdBankBranch">
                        </table>
                    </div>
                    <div id="grdBankBranch_pager">
                    </div>
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
