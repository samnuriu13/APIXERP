<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TransRef.ascx.cs" Inherits="API.Controls.TransRef" %>

<div class="lblAndTxtStyle">
    <div class="divlblwidth100px bglbl">
        <a>Reference No</a>
    </div>
    <div class="div80Px">
        <asp:TextBox ID="txtRefNo" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
    </div>
</div>
<div class="lblAndTxtStyle">
    <div class="divlblwidth100px bglbl">
        <a>Reference Type</a>
    </div>
    <div class="div182Px">
        <asp:DropDownList ID="ddlRefType" runat="server" CssClass="drpwidth180px" OnSelectedIndexChanged="ddlRefType_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList>
    </div>
</div>

<div class="lblAndTxtStyle">
    <div class="divlblwidth100px bglbl">
        <a>Reference</a>
    </div>
    <div class="div182Px">
        <asp:DropDownList ID="ddlReference" runat="server" CssClass="drpwidth180px">
        </asp:DropDownList>
    </div>
</div>


