<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="ItemDefination.aspx.cs" Inherits="API.UI.ItemSetup.ItemDefination" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Item Defination"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 33%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Item Code</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtItemCode" runat="server" CssClass="txtwidth93px" Style="width: 75%;"
                            MaxLength="100" ReadOnly="true"></asp:TextBox>
                        <div style="float: right; margin-left: 5px;">
                            <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/new 20X20.png" OnClick="btnNew_Click" />
                            <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png" OnClick="btnFind_Click" />
                        </div>
                        <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                            ControlToValidate="txtItemCode" runat="server" ValidationGroup="Save" ForeColor="Red"
                            ErrorMessage="Item code is required">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Item Group</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlItemGroup" OnSelectedIndexChanged="ddlItemGroup_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlItemGroup"
                            runat="server" ForeColor="Red" ErrorMessage="Item Group is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <%--<div id="divSubGroup" runat="server" class="lblAndTxtStyle" style="visibility:hidden">
                    <div class="divlblwidth100px bglbl">
                        <a>Item Sub-Group</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlItemSubGroup" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlItemSubGroup"
                            runat="server" ForeColor="Red" ErrorMessage="Item SubGroup is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </div>
                </div>--%>
            </div>
            <div style="float:left; width:33%">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>UOM</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlUOM1" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlUOM1"
                            runat="server" ForeColor="Red" ErrorMessage="UOM is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Buying Price</a>
                    </div>
                    <div class="div182Px">
                        <asp:TextBox ID="txtBuyingPrice" runat="server" CssClass="txtwidth93px" Style="width: 75%;" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Selling Price</a>
                    </div>
                    <div class="div182Px">
                        <asp:TextBox ID="txtSellingPrice" runat="server" CssClass="txtwidth93px" Style="width: 75%;" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div style="float: left; width: 99%">
                <asp:Panel ID="Panel1" runat="server" Style="height: auto;">
                </asp:Panel>
            </div>
        </div>
        <div style="clear: both"></div>
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="save" OnClick="btnSave_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" OnClick="btnDelete_Click" />
            </div>
        </div>
    </div>
</asp:Content>
