<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="ProjeKargoWebForms.User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
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
    <table style="width: 100%;">
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label4" runat="server" Text="Bana En Yakın Şube Nerede?" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="İl:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSubeIli" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubeIli_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label9" runat="server" Text="İlçe:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSubeIlce" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td>
                <asp:Button ID="btnSube" runat="server" Text="Sorgula" OnClick="btnSube_Click" OnClientClick="return kontrolSube()" />
                <asp:Button ID="btnSubeTemizle" runat="server" Text="Temizle" OnClick="btnSubeTemizle_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label25" runat="server" Text="Size En Yakın Şubeler" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </td>
            <td>
                <asp:GridView ID="gvSube" EmptyDataText="Arama yaptığınız bölgede şubemiz bulunmamaktadır." runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Bold="True" Font-Size="Medium" GridLines="Horizontal" ForeColor="Black">
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label11" runat="server" Text="Kurye Çağır!" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label16" runat="server" Text="Kişi"></asp:Label>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label12" runat="server" Text="Ad:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbKuryeAd" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label17" runat="server" Text="Soyad:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbKuryeSoyad" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label19" runat="server" Text="Tel:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbKuryeTel" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label21" runat="server" Text="Adres"></asp:Label>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label22" runat="server" Text="İl:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlKuryeIl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlKuryeIl_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label13" runat="server" Text="İlçe:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlKuryeIlce" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label14" runat="server" Text="Mahalle:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbKuryeMah" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label15" runat="server" Text="Sokak:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbKuryeSok" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label23" runat="server" Text="Apatman:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbKuryeApt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label24" runat="server" Text="No:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbKuryeNo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnKurye" runat="server" Text="Çağır" OnClick="btnKurye_Click"/></td>
            <td>
                <asp:Label ID="lblkcSonuc" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function kontrolKargo() {
            var ktbTakipNo = document.getElementById('<%=tbTakipNo.ClientID%>');
            var mesaj = "";
            if (ktbTakipNo.value == "") {
                mesaj = "Lütfen kargo takip numarasını giriniz.";
                alert(mesaj);
            }
            else
                mesaj = "";
            if (mesaj == "")
                return true;
            else
                return false;
        }
        function kontrolSube() {
            var kddlSubeIli = document.getElementById('<%=ddlSubeIli.ClientID%>');
            var kddlSubeIlce = document.getElementById('<%=ddlSubeIlce.ClientID%>');
            var mesaj = "";
            if (kddlSubeIli.selectedIndex <= 0) {
                mesaj = "Lütfen şube için il seçiniz.";
                alert(mesaj);
            }
            else if (kddlSubeIlce.selectedIndex <= 0) {
                mesaj = "Lütfen şube için ilçe seçiniz.";
                alert(mesaj);
            }
            else
                mesaj = "";
            if (mesaj == "")
                return true
            else
                return false
        }
    </script>
</asp:Content>
