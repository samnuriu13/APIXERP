<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="ContactInformation.aspx.cs" Inherits="API.UI.Setup.ContactInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/ContactType.js") %> " type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/gridscripts/ContactTypeDetail.js") %> " type="text/javascript"></script>
    <style type="text/css">
        .imgFieldSet {
                        -webkit-border-radius: 8px;
                        -moz-border-radius: 8px;
                        border-radius: 8px;
                     }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="float: left; width: 35%">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Contact ID</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtContactID" runat="server" CssClass="txtwidth93px" Style="width: 75%;"
                            MaxLength="100" ReadOnly="true"></asp:TextBox>
                        <div style="float: right; margin-left: 5px;">
                            <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/new 20X20.png" OnClick="btnNew_Click" />
                            <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png" OnClick="btnFind_Click" />
                        </div>
                        <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            ControlToValidate="txtContactID" runat="server" ValidationGroup="Save" ForeColor="Red"
                            ErrorMessage="Contact ID is required">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Name</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtContactName" runat="server" CssClass="txtwidth93px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Short Name</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtShortName" runat="server" CssClass="txtwidth93px" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Agent Name</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtAgentName" runat="server" CssClass="txtwidth93px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Cost Center</a>
                    </div>
                    <div class="div182Px" style="width:57%">
                        <asp:DropDownList ID="ddlFromCostCentre" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Department</a>
                    </div>
                    <div class="div182Px" style="width:57%">
                        <asp:DropDownList ID="ddlDeptID" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Office Address</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtOfficeAddress" runat="server" CssClass="txtwidth93px" MaxLength="500"
                            TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Factory Address</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtFactoryAddress" runat="server" CssClass="txtwidth93px" MaxLength="500"
                            TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Phone No</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="txtwidth93px" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Fax No</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtFaxNo" runat="server" CssClass="txtwidth93px" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Email</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="txtwidth93px" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Contact Person</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtContactPerson" runat="server" CssClass="txtwidth93px" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>TIN NO</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtTinNo" runat="server" CssClass="txtwidth93px" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>VAT Code</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtVATCode" runat="server" CssClass="txtwidth93px" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div style="float: left; width: 50%">
                <fieldset class="fieldset-panel" style="margin-left: 15px; width: 220px; height: auto;">
                    <legend class="fieldset-legend">Photograph</legend>
                    <div style="text-align: center; vertical-align: middle;">
                        <asp:Image ID="imgContactImage" ImageUrl="~/images/no-image.png" runat="server" Style="max-height: 120px; max-width: 220px;" />
                    </div>
                </fieldset>
                <div class="totalDiv" style="margin-left: 40px;">
                    <asp:FileUpload ID="fuContactImage" runat="server" />
                </div>
            </div>
            <div style="float: left; width: 50%; height:10px"></div>
            <div style="float: left; width: 25%">
                <div>
                    <table id="grdContactType">
                    </table>
                </div>
                <div id="grdContactType_pager">
                </div>
            </div>
             <div style="float: left; width: 25%; padding-left:20px">
                <div>
                    <table id="grdContactTypeDetail">
                    </table>
                </div>
                <div id="grdContactTypeDetail_pager">
                </div>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <br />
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" OnClick="btnDelete_Click"/>
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
