<%@ Page Title="Réservations" Language="C#" MasterPageFile="~/SiteFr.master" AutoEventWireup="true" CodeFile="BookingFr.aspx.cs" Inherits="BookingFr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">
    <link href="Content/Site.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <script>
<%--        $(function () {
            $('#<%= txtStartDate.ClientID %>').datepicker({
                firstDay: 6,
                dateFormat: "dd/mm/yy",
                minDate: 1,
                beforeShowDay: function (date) {
                    var day = date.getDay();
                    //if (date.getMonth() > 7 || date.getMonth() < 6) {
                    //    return [true, ""];
                    //}
                    //else {
                    //    return [day == 6, ""];
                    //}
                    return [day == 6, ""];
                }
            });
        });
        <%--        $(function () {
            $('#<%= txtEndDate.ClientID %>').datepicker({
                firstDay: 6,
                dateFormat: dd/mm/yy",
                minDate: 2,
                beforeShowDay: function (date) {
                    var day = date.getDay();
                    if (date.getMonth() > 7 || date.getMonth() < 6) {
                        return [true, ""];
                    }
                    else {
                        return [day == 6, ""];
                    }
                }
            });
        });--%>
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="Server">
    <table style="width: 100%; height: 100%" border="0" cellspacing="20" cellpadding="0">
        <tr>
            <td align="center">
                <table style="width: 80%; height: 100%" border="0" cellspacing="20" cellpadding="0">
                    <tr>
                        <td>&nbsp;</td>
                        <td align="center" width="1000" valign="top">
                            Pour demander la disponibilité ou effectuer une réservation en ligne par carte de crédit merci de nous 
                            retrouver sur le site de Homeaway en cliquant sur le lien ci-dessous ou en le recopiant sur votre écran:
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td align="center" width="1000" valign="top">
                            <a href="http://www.homeaway.co.uk/p6883483" target="_blank">http://www.homeaway.co.uk/<wbr>p6883483</a>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td align="center" width="1000" valign="top">
                            Vous pouvez également le faire sur le site de French Connections par transfert bancaire
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td align="center" width="1000" valign="top">
                            <a href="http://www.frenchconnections.co.uk/listing/168056?unit_id=168051" target="_blank">http://www.frenchconnections.co.uk/listing/168056?unit_id=168051</a>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

<%--    <table style="width: 100%; height: 100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>&nbsp;</td>
            <td align="center" width="1000" valign="top">
                <table style="width: 80%; height: 100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="3">
                            <table style="width: 100%; height: 100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="3">
                                        <p>
                                            <strong>Tarifs pour 2017</strong><br />
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><strong>Période</strong></td>
                                    <td><strong>Tarif</strong></td>
                                    <td><strong>Nuit suppl.</strong></td>
                                </tr>
                                <tr>
                                    <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><strong>Hiver</strong></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>31.12.2016 - 29.04.2017</td>
                                    <td>&#8364;429.00</td>
                                    <td>&#8364;143.00</td>
                                </tr>
                                <tr>
                                    <td><em>3 nuits min.</em></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><strong>Printemps</strong></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>30.04.2017 - 03.06.2017</td>
                                    <td>&#8364;471.00</td>
                                    <td>&#8364;157.00</td>
                                </tr>
                                <tr>
                                    <td><em>3 nuits min.</em></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><strong>Eté</strong></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>04.06.2017 - 23.09.2017</td>
                                    <td>&#8364;1250.00</td>
                                    <td>&#8364;179.00</td>
                                </tr>
                                <tr>
                                    <td><em>7 nuits min.</em></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><strong>Automne</strong></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>24.09.2017 - 28.10.2017</td>
                                    <td>&#8364;471.00</td>
                                    <td>&#8364;157.00</td>
                                </tr>
                                <tr>
                                    <td><em>3 nuits min.</em></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><strong>Hiver</strong></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>29.10.2017 - 30.12.2017</td>
                                    <td>&#8364;429.00</td>
                                    <td>&#8364;143.00</td>
                                </tr>
                                <tr>
                                    <td><em>3 nuits min.</em></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><strong>Tarif hebdomadaire moyen</strong></td>
                                    <td>&#8364;1000.00</td>
                                    <td>&#8364;143.00</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <p>&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <p>
                                <strong>Réservations du Samedi 16h au Samedi 11h</strong><br />
                                Pour demander la disponibilité et les conditions pour une période plus courte ou pour confirmer une réservation, merci d’utiliser le formulaire ci-dessous ou faire la demande par courriel adressé à <a href="mailto:info@thebijouvilla.com">info@thebijouvilla.com</a>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <p>
                                Vous pouvez consulter le calendrier ci-joint.<br />
                                Les dates en rose sont réservées temporairement (merci de nous consulter pour une confirmation)<br />
                                Les dates en rouge ne sont plus disponibles.<br />
                                Avec la  confirmation de la disponibilité,  nous vous enverrons les détails pour effectuer le paiement afin de confirmer votre réservation. 
                                Les réservations sont bloquées une semaine, dans l’attente de la copie de votre paiement.
                            </p>
                            <p>
                                <strong>Conditions de paiement</strong><br />
                                50&#37; à la réservation<br />
                                50&#37; 60 jours avant votre arrivée.
                            </p>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Calendar ID="Calendar1" OnDayRender="Calendar1_DayRender"
                                runat="server" Width="40%" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged" SelectionMode="None" FirstDayOfWeek="Saturday"></asp:Calendar>
                            <asp:Label runat="server" ID="lblStatus" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <table style="width: 100%; height: 100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>&nbsp;</td>
            <td align="center" width="1000" valign="top">
                <table style="width: 80%; height: 100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="30%"></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <strong>Le paiement en ligne avec carte de crédit, peut se faire avec Home Away où nous  sommes listés en cliquant sur: 
                            <a class="ObviousLink" target="_blank" href="http://www.homeaway.co.uk/p6883483">http://www.homeaway.co.uk/p6883483</a></strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="30%">&nbsp;</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <strong>Ou en complétant le formulaire ci-dessous en cliquant sur la touche &quot;Réservation&quot;.</strong>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <p>
                                Sélectionnez le premier jour de la période  qui vous intéresse.
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Début de la période"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
                            <asp:HiddenField ID="txtEndDate" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <h4>Vos données :</h4>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Nom et prénom"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTenantName" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Adresse"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress1" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="2eme ligne adresse"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress2" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Lieu"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTown" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="Ville"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCity" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="Département"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCounty" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text="Code postal"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPostcode" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="Pays"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCountry" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="Adresse email"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label12" runat="server" Text="Téléphone fixe"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLandline" runat="server" Width="250"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label13" runat="server" Text="Téléphone portable"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMobile" runat="server" Width="250"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label14" runat="server" Text="Message (inclure dates souhaitées pour les périodes autres que 7nuits minimum)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Rows="10" Width="800"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label2" runat="server" Text="Vous avez découvert The Bijou sur (agence, recommandation, site internet, etc.)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtAgency" runat="server" TextMode="MultiLine" Rows="2" Width="800"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblWarning" CssClass="WarningText" runat="server" Text="" Visible="false"></asp:Label>
                <p>
                    <asp:Button ID="btnBook" runat="server" Text="Réservation" OnClick="btnBook_Click" />
                    <asp:Button ID="btnClear" runat="server" Text="Annuler" OnClick="btnClear_Click" />
                </p>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>--%>
</asp:Content>

