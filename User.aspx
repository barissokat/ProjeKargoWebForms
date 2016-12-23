<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="ProjeKargoWebForms.User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Kargom Nerede?" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Kargo Takip No:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbTakipNo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style1">
                <asp:Button ID="btnKargomNerede" runat="server" Text="Sorgula" OnClick="btnKargomNerede_Click" OnClientClick="return kontrolKargo()" />
                <asp:Button ID="btnTakipTemizle" runat="server" Text="Temizle" OnClick="btnTakipTemizle_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Kargonuz, " Font-Bold="True" Font-Size="Medium"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTakipSonuc" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
