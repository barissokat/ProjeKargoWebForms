<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ProjeKargoWebForms.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvKargo" runat="server" OnSelectedIndexChanged="gvKargo_SelectedIndexChanged">
        <Columns>
            <asp:ButtonField CommandName="Select" Text="Seç" />
        </Columns>
        <EmptyDataTemplate>
            Herhangi bir kargo bulunamadı..
        </EmptyDataTemplate>
    </asp:GridView>
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Button ID="btnYeni" runat="server" Text="Yeni Kargo" OnClick="btnYeniKargo_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Kargo İçerik" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Takip ID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbTakipId" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Ağırlık"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbAgirlik" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Yükseklik"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbYukseklik" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="En"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbEn" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Boy"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbBoy" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Gönderen İçerik" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="Ad"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbgAd" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label9" runat="server" Text="Soyad"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbgSoyad" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label10" runat="server" Text="Tel"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbgTel" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label11" runat="server" Text="İl"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlgIl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlgIl_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label12" runat="server" Text="İlçe"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlgIlce" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label13" runat="server" Text="Mahalle"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbgMah" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label14" runat="server" Text="Sokak"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbgSok" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label15" runat="server" Text="Apartman"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbgApart" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label16" runat="server" Text="No"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbgNo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label17" runat="server" Text="Alıcı İçerik" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label18" runat="server" Text="Ad"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbaAd" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label19" runat="server" Text="Soyad"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbaSoyad" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label20" runat="server" Text="Tel"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbaTel" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label21" runat="server" Text="İl"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlaIl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlaIl_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label22" runat="server" Text="İlçe"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlaIlce" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label23" runat="server" Text="Mahalle"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbaMah" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label24" runat="server" Text="Sokak"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbaSok" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label25" runat="server" Text="Apartman"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbaApart" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label26" runat="server" Text="No"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbaNo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnKargo" runat="server" Text="Kaydet" OnClick="btnKargo_Click" OnClientClick="return kontrolTakip()" />
            </td>
            <td>
                <asp:Label ID="lblSonuc" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>
