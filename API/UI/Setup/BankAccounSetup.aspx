<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="BankAccounSetup.aspx.cs" Inherits="API.UI.Setup.BankAccounSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">

    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Bank Account Setup"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 33%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Branch/Unit</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlBranchOrUnit" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    </div>
                </div>
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
                        <a>Account No.</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtAccountNo" runat="server" CssClass="txtwidth178px" Style="width: 70%;"
                            MaxLength="100"></asp:TextBox>
                        <div style="float: right; margin-left: 0px;">
                            <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle btn-enable" ImageUrl="~/images/new 20X20.png" OnClick="btnNew_Click" />
                            <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle btn-enable"
                                ImageUrl="~/images/Search 20X20.png" OnClick="btnFind_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div style="width: 33%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Account Name</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtAccountName" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Account Type</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlAccountType" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Bank Branch</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlBankBranch" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div style="width: 33%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>User Name</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlUserName" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>COA</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlCOA" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="lblAndTxtStyle" style="margin-left: 10%; float: left">
                    <asp:CheckBox ID="chkIsCompanyAccount" runat="server" CssClass="cbStyle" />
                    <asp:Label ID="Label9" runat="server" CssClass="lblStyle" Style="margin-top: 3px">Is Company Account</asp:Label>
                </div>
            </div>
        </div>
        <div style="clear: both"></div>
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="Save" OnClick="btnSave_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="btnClear" runat="server" CssClass="button" Text="Cancel" Visible="true" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>
</asp:Content>
