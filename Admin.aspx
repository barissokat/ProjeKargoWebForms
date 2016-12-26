<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ProjeKargoWebForms.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvKargo" EmptyDataText="Herhangi bir kargo bulunamadı.." runat="server" OnSelectedIndexChanged="gvKargo_SelectedIndexChanged">
        <Columns>
            <asp:ButtonField CommandName="Select" Text="Seç" />
        </Columns>
    </asp:GridView>

    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="Label0" runat="server" Text="Kargo Ekle" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnYeniKargo" runat="server" Text="Yeni Kargo" OnClick="btnYeniKargo_Click" />
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
                <asp:TextBox ID="tbGonderenAd" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label9" runat="server" Text="Soyad"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbGonderenSoyad" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label10" runat="server" Text="Tel"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbGonderenTel" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label11" runat="server" Text="İl"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlGonderenIl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlgIl_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label12" runat="server" Text="İlçe"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlGonderenIlce" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label13" runat="server" Text="Mahalle"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbGonderenMahalle" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label14" runat="server" Text="Sokak"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbGonderenSokak" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label15" runat="server" Text="Apartman"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbGonderenApartman" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label16" runat="server" Text="No"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbGonderenNo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label17" runat="server" Text="Alici İçerik" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label18" runat="server" Text="Ad"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbAliciAd" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label19" runat="server" Text="Soyad"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbAliciSoyad" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label20" runat="server" Text="Tel"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbAliciTel" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label21" runat="server" Text="İl"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlAliciIl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlaIl_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label22" runat="server" Text="İlçe"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlAliciIlce" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label23" runat="server" Text="Mahalle"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbAliciMahalle" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label24" runat="server" Text="Sokak"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbAliciSokak" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label25" runat="server" Text="Apartman"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbAliciApartman" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label26" runat="server" Text="No"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbAliciNo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnKargo" runat="server" Text="Kaydet" OnClick="btnKargo_Click" OnClientClick="return kontrolTakip()" />
                <asp:Button ID="btnKargoSil" runat="server" Text="Sil" OnClick="btnKargoSil_Click" />
            </td>
            <td>
                <asp:Label ID="lblKargoSonuc" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
    </table>

    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="Label27" runat="server" Text="Kargo Durum Değişimi" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label28" runat="server" Text="Takip No"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbTakipNo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label29" runat="server" Text="Durum:"></asp:Label>

            </td>
            <td>
                <asp:DropDownList ID="ddlDurum" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnDurumDegis" runat="server" Text="Güncelle" OnClick="btnDurumDegis_Click" OnClientClick="return kontrolDurum()" />
            </td>
            <td>
                <asp:Label ID="lblDurumSonuc" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="Label30" runat="server" Text="Şube Tablosu" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>
                <div style="overflow-x: auto; width: 800px">
                    <asp:GridView ID="gvSube" EmptyDataText="Henüz şube bulunmamaktadır." runat="server" OnSelectedIndexChanged="gvSube_SelectedIndexChanged">
                        <Columns>
                            <asp:ButtonField CommandName="Select" Text="Seç" />
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSubeYeni" runat="server" Text="Yeni Şube" OnClick="btnSubeYeni_Click" />
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label31" runat="server" Text="Sube ID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbSubeId" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label32" runat="server" Text="İl"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSubeIl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubeIl_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label33" runat="server" Text="İlce"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSubeIlce" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label34" runat="server" Text="Mahalle"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbSubeMahalle" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label35" runat="server" Text="Sokak"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbSubeSokak" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label36" runat="server" Text="Ad"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbSubeAd" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label37" runat="server" Text="Tel"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbSubeTel" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSube" runat="server" Text="Kaydet" OnClick="btnSube_Click" OnClientClick="return kontrolSube()" />
                <asp:Button ID="btnSubeSil" runat="server" Text="Sil" OnClick="btnSubeSil_Click" />
            </td>
            <td>
                <asp:Label ID="lblSubeSonuc" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Kurye Çağır Tablosu" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>
                <div style="overflow-x: auto; width: 800px">
                    <asp:GridView ID="gvKuryeCagir" EmptyDataText="Henüz kurye çağıran biri olmamıştır." runat="server" OnSelectedIndexChanged="gvKuryeCagir_SelectedIndexChanged">
                        <Columns>
                            <asp:ButtonField CommandName="Select" Text="Seç" />
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
            <td class="auto-style1">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Label ID="Label42" runat="server" Text="Yeni Kuryeci"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlKuryeciID" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnKuryeciGüncelle" runat="server" Text="Değiştir" OnClick="btnKuryeciGüncelle_Click" OnClientClick="return kontrolKuryeci()" />
                        </td>
                        <td>
                            <asp:Label ID="lblsKuryeci" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function kontrolTakip() {
            var ktbAgirlik = document.getElementById('<%=tbAgirlik.ClientID%>');
            var ktbYukseklik = document.getElementById('<%=tbYukseklik.ClientID%>');
            var ktbEn = document.getElementById('<%=tbEn.ClientID%>');
            var ktbBoy = document.getElementById('<%=tbBoy.ClientID%>');
            var ktbgAd = document.getElementById('<%=tbGonderenAd.ClientID%>');
            var ktbgSoyad = document.getElementById('<%=tbGonderenSoyad.ClientID%>');
            var ktbgTel = document.getElementById('<%=tbGonderenTel.ClientID%>');
            var kddlgIl = document.getElementById('<%=ddlGonderenIl.ClientID%>');
            var kddlgIlce = document.getElementById('<%=ddlGonderenIlce.ClientID%>');
            var ktbgMah = document.getElementById('<%=tbGonderenMahalle.ClientID%>');
            var ktbgSok = document.getElementById('<%=tbGonderenSokak.ClientID%>');
            var ktbgApart = document.getElementById('<%=tbGonderenApartman.ClientID%>');
            var ktbgNo = document.getElementById('<%=tbGonderenNo.ClientID%>');
            var ktbaAd = document.getElementById('<%=tbAliciAd.ClientID%>');
            var ktbaSoyad = document.getElementById('<%=tbAliciSoyad.ClientID%>');
            var ktbaTel = document.getElementById('<%=tbAliciTel.ClientID%>');
            var kddlaIl = document.getElementById('<%=ddlAliciIl.ClientID%>');
            var kddlaIlce = document.getElementById('<%=ddlAliciIlce.ClientID%>');
            var ktbaMah = document.getElementById('<%=tbAliciMahalle.ClientID%>');
            var ktbaSok = document.getElementById('<%=tbAliciSokak.ClientID%>');
            var ktbaApart = document.getElementById('<%=tbAliciApartman.ClientID%>');
            var ktbaNo = document.getElementById('<%=tbAliciNo.ClientID%>');
            var mesaj = "";
            if (ktbAgirlik.value == "") {
                mesaj = "Lütfen ağırlık giriniz.";
                alert(mesaj);
                document.getElementById('<%=tbAgirlik.ClientID%>').focus();
            }
            else if (ktbYukseklik.value == "") {
                mesaj = "Lütfen yükseklik giriniz.";
                alert(mesaj);
                document.getElementById('<%=tbYukseklik.ClientID%>').focus();
            }
            else if (ktbEn.value == "") {
                mesaj = "Lütfen en giriniz.";
                alert(mesaj);
                document.getElementById('<%=tbEn.ClientID%>').focus();
            }
            else if (ktbBoy.value == "") {
                mesaj = "Lütfen boy giriniz.";
                alert(mesaj);
                document.getElementById('<%=tbBoy.ClientID%>').focus();
            }
            else if (ktbgAd.value == "") {
                mesaj = "Lütfen gönderen için ad giriniz.";
                alert(mesaj);
                document.getElementById('<%=tbGonderenAd.ClientID%>').focus();
            }
            else if (ktbgSoyad.value == "") {
                mesaj = "Lütfen gönderen için soyad giriniz.";
                alert(mesaj);
                document.getElementById('<%=tbGonderenSoyad.ClientID%>').focus();
            }
            else if (ktbgTel.value == "") {
                mesaj = "Lütfen gönderen için tel giriniz.";
                alert(mesaj);
                document.getElementById('<%=tbGonderenTel.ClientID%>').focus();
            }
            else if (kddlgIl.selectedIndex <= 0) {
                mesaj = "Lütfen gönderen için il seçiniz.";
                alert(mesaj);
            }
            else if (kddlgIlce.selectedIndex <= 0) {
                mesaj = "Lütfen gönderen için ilçe seçiniz.";
                alert(mesaj);
            }
            else if (ktbgMah.value == "") {
                mesaj = "Lütfen gönderen için mahalle giriniz.";
                alert(mesaj);
                document.getElementById('<%=tbGonderenMahalle.ClientID%>').focus();
            }
            else if (ktbgSok.value == "") {
                mesaj = "Lütfen gönderen için sokak giriniz.";
                alert(mesaj);
                document.getElementById('<%=tbGonderenSokak.ClientID%>').focus();
            }
            else if (ktbgApart.value == "") {
                mesaj = "Lütfen gönderen için apartman giriniz.";
                alert(mesaj);
                document.getElementById('<%=tbGonderenApartman.ClientID%>').focus();
            }
            else if (ktbgNo.value == "") {
                mesaj = "Lütfen gönderen için no giriniz.";
                alert(mesaj);
                document.getElementById('<%=tbGonderenNo.ClientID%>').focus();
            }
            else if (ktbaAd.value == "") {
                mesaj = "Lütfen alıcı için ad giriniz.";
                alert(mesaj);
                document.getElementById('<%=tbAliciAd.ClientID%>').focus();
            }
            else if (ktbaSoyad.value == "") {
                mesaj = "Lütfen alıcı için soyad giriniz.";
                alert(mesaj);
                document.getElementById('<%=tbAliciSoyad.ClientID%>').focus();
            }
            else if (ktbaTel.value == "") {
                mesaj = "Lütfen alıcı için tel giriniz.";
                alert(mesaj);
                document.getElementById('<%=tbAliciTel.ClientID%>').focus();
            }
            else if (kddlaIl.selectedIndex <= 0) {
                mesaj = "Lütfen alıcı için il seçiniz.";
                alert(mesaj);
            }
            else if (kddlaIlce.selectedIndex <= 0) {
                mesaj = "Lütfen alıcı için ilçe seçiniz.";
                alert(mesaj);
            }
            else if (ktbaMah.value == "") {
                mesaj = "Lütfen alıcı için mahalle giriniz.";
                alert(mesaj);
                document.getElementById('<%=tbAliciMahalle.ClientID%>').focus();
            }
            else if (ktbaSok.value == "") {
                mesaj = "Lütfen alıcı için sokak giriniz.";
                alert(mesaj);
                document.getElementById('<%=tbAliciSokak.ClientID%>').focus();
            }
            else if (ktbaApart.value == "") {
                mesaj = "Lütfen alıcı için apartman giriniz.";
                alert(mesaj);
                document.getElementById('<%=tbAliciApartman.ClientID%>').focus();
            }
            else if (ktbaNo.value == "") {
                mesaj = "Lütfen alıcı için no giriniz.";
                alert(mesaj);
                document.getElementById('<%=tbAliciNo.ClientID%>').focus();
            }
            else
                mesaj = "";
    if (mesaj == "")
        return true;
    else
        return false;
}

function kontrolDurum() {
    var ktbTakipNo = document.getElementById('<%=tbTakipNo.ClientID%>');
            var kddlDurum = document.getElementById('<%=ddlDurum.ClientID%>');
            var mesaj = "";
            if (ktbTakipNo.value == "") {
                mesaj = "Lütfen durum değişikliği için takip no giriniz.";
                alert(mesaj);
                document.getElementById('<%=tbTakipNo.ClientID%>').focus();
            }
            else if (kddlDurum.selectedIndex <= 0) {
                mesaj = "Lütfen kargo için durum seçiniz.";
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
            var kddlsIl = document.getElementById('<%=ddlSubeIl.ClientID%>');
            var kddlsIlce = document.getElementById('<%=ddlSubeIlce.ClientID%>');
            var ktbsMah = document.getElementById('<%=tbSubeMahalle.ClientID%>');
            var ktbsSok = document.getElementById('<%=tbSubeSokak.ClientID%>');
            var ktbsAd = document.getElementById('<%=tbSubeAd.ClientID%>');
            var ktbsTel = document.getElementById('<%=tbSubeTel.ClientID%>');
            var mesaj = "";
            if (kddlsIl.selectedIndex <= 0) {
                mesaj = "Lütfen sube için il seçiniz.";
                alert(mesaj);
            }
            else if (kddlsIlce.selectedIndex <= 0) {
                mesaj = "Lütfen sube için ilce seçiniz.";
                alert(mesaj);
            }
            else if (ktbsMah.value == "") {
                mesaj = "Lütfen sube için mahalle giriniz.";
                alert(mesaj);
                document.getElementById('<%=tbSubeMahalle.ClientID%>').focus();
            }
            else if (ktbsSok.value == "") {
                mesaj = "Lütfen sube için sokak giriniz.";
                alert(mesaj);
                document.getElementById('<%=tbSubeSokak.ClientID%>').focus();
                    }
                    else if (ktbsAd.value == "") {
                        mesaj = "Lütfen sube için ad giriniz.";
                        alert(mesaj);
                        document.getElementById('<%=tbSubeAd.ClientID%>').focus();
                    }
                    else if (ktbsTel.value == "") {
                        mesaj = "Lütfen sube için tel giriniz.";
                        alert(mesaj);
                        document.getElementById('<%=tbSubeTel.ClientID%>').focus();
                            }
                            else
                                mesaj = "";
        if (mesaj == "")
            return true;
        else
            return false;
    }

    function kontrolKuryeci() {
        var kddlKuryeciID = document.getElementById('<%=ddlKuryeciID.ClientID%>');
            var mesaj = "";
            if (kddlKuryeciID.selectedIndex <= 0) {
                mesaj = "Lütfen yeni kuryeciyi seçiniz.";
                alert(mesaj);
            }
            else
                mesaj = "";
            if (mesaj == "")
                return true;
            else
                return false;
        }
    </script>
</asp:Content>
