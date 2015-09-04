<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="MenuWiseTableMapping.aspx.cs" Inherits="API.UI.Setup.MenuWiseTableMapping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="width: 100%; height: auto; margin-top: 5px">
                <div style="float: left; width: 60%">
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Doc List</a>
                        </div>
                        <div class="div182Px">
                            <asp:DropDownList ID="ddlDocList" runat="server" CssClass="drpwidth180px">
                            </asp:DropDownList>
                            <span class="r2">*</span>
                            <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/new 20X20.png" OnClick="btnNew_Click" />
                            <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png" OnClick="btnFind_Click" />

                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Table Name</a>
                        </div>
                        <div class="div80Px">
                            <asp:DropDownList ID="ddlTableName" runat="server" CssClass="drpwidth180px" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlTableName_SelectedIndexChanged">
                            </asp:DropDownList>

                            <span class="r2">*</span>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Column Name</a>
                        </div>
                        <div class="div80Px">
                            <asp:DropDownList ID="ddlColumnName" runat="server" CssClass="drpwidth180px">
                            </asp:DropDownList>

                            <span class="r2">*</span>
                        </div>
                    </div>
                </div>


                <div style="float: left; width: 40%">
                    <div class="lblAndTxtStyle">

                        <div class="divlblwidth100px bglbl">
                            <a>Table Type</a>
                        </div>
                        <div class="div80Px">
                            <asp:Label ID="lblTableType" Text="Master" runat="server"></asp:Label>
                        </div>

                    </div>

                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Column Type</a>
                        </div>
                        <div class="div80Px">
                            <asp:Label ID="lblColumnType" runat="server" Text="PrimaryKey"></asp:Label>
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
