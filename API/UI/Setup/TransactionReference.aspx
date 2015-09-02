<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="TransactionReference.aspx.cs" Inherits="API.UI.Setup.TransactionReference" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="width: 100%; height: auto; margin-top: 5px">
                <div style="float: left; width: 60%">
                    <div class="lblAndTxtStyle"> 
                         <div class="divlblwidth100px bglbl">
                            <a>Transaction Reference  Name</a>
                             <span class="r2">*</span>
                        </div>
                        <div class="div182Px">
                            <asp:DropDownList ID="ddlTransactionReferenceName" runat="server" CssClass="drpwidth180px">
                            </asp:DropDownList>
                            
                            
                            
                            <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/new 20X20.png" OnClick="btnNew_Click" />
                            <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png" OnClick="btnFind_Click" />

                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Reference Master Table</a>
                        </div>
                        <div class="div80Px">
                            <asp:DropDownList ID="ddlReferenceMasterTable" runat="server" CssClass="drpwidth180px">
                            </asp:DropDownList>

                            <span class="r2">*</span>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Detail Foreign Key</a>
                        </div>
                        <div class="div80Px">
                            <asp:DropDownList ID="ddlDetailForeignKey" runat="server" CssClass="drpwidth180px">
                            </asp:DropDownList>

                            <span class="r2">*</span>
                        </div>
                    </div>
                </div>


                <div style="float: left; width: 40%">
                    <div class="lblAndTxtStyle">

                       <div class="divlblwidth100px bglbl">
                            <a>Transaction Type Name</a>
                        </div>
                        <div class="div80Px">
                            <asp:DropDownList ID="ddlTransTypeName" runat="server" CssClass="drpwidth180px">
                            </asp:DropDownList>
                        </div> 

                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Reference Detail Table</a>
                        </div>
                        <div class="div80Px">
                            <asp:DropDownList ID="ddlReferenceDetailTable" runat="server" CssClass="drpwidth180px" OnSelectedIndexChanged="ddlReferenceDetailTable_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                            <span class="r2">*</span>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Transaction Type Column</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtTransactionTypeColumn" runat="server" CssClass="txtwidth93px" Style="width: 100%;"
                                MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <div style="clear: both">
        </div>
        <br />
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