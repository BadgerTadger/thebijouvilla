<%@ Page Title="Réservation" Language="C#" MasterPageFile="~/SiteFr.master" AutoEventWireup="true" CodeFile="BookingFr.aspx.cs" Inherits="BookingFr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">
    <link href="Content/Site.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <script>
        $(function () {
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
    <table style="width: 100%; height: 100%" border="0" cellspacing="0" cellpadding="0">
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
                                            <strong>Tarifs pour 2017.</strong><br />
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><strong>Période de taux</strong></td>
                                    <td><strong>Taux minimum</strong></td>
                                    <td><strong>Nuit supplémentaire</strong></td>
                                </tr>
                                <tr>
                                    <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><strong>Basse saison</strong></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>31-Dec-2016 - 29-Apr-2017</td>
                                    <td>&#8364;429.00</td>
                                    <td>De &#8364;143.00</td>
                                </tr>
                                <tr>
                                    <td><em>3 nuits minimum de séjour</em></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><strong>Mi-saison</strong></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>30-Apr-2017 - 03-Jun-2017</td>
                                    <td>&#8364;471.00</td>
                                    <td>De &#8364;157.00</td>
                                </tr>
                                <tr>
                                    <td><em>3 nuits minimum de séjour</em></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><strong>Haute saison</strong></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>4-Jun-2017 - 23-Sep-2017</td>
                                    <td>&#8364;1250.00</td>
                                    <td>De &#8364;179.00</td>
                                </tr>
                                <tr>
                                    <td><em>7 nuits minimum de séjour</em></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><strong>L'automne</strong></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>24-Sep-2017 - 28-Oct-2017</td>
                                    <td>&#8364;471.00</td>
                                    <td>De &#8364;157.00</td>
                                </tr>
                                <tr>
                                    <td><em>3 nuits minimum de séjour</em></td>
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
                                    <td>29-Oct-2016 - 30-Dec-2017</td>
                                    <td>&#8364;429.00</td>
                                    <td>De &#8364;143.00</td>
                                </tr>
                                <tr>
                                    <td><em>3 nuits minimum de séjour</em></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><strong>Mon taux standard</strong></td>
                                    <td>&#8364;1000.00</td>
                                    <td>De &#8364;143.00</td>
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
                                <strong>Les réservations sont 1600 samedi à 1100 samedi</strong><br />
                                Pour confirmer la disponibilité, demander une réservation ou demander disponibilité et tarifs pour des périodes plus courtes, utilisez le formulaire de demande ci-dessous ou envoyez un courriel aux propriétaires à <a href="mailto:info@thebijouvilla.com">info@thebijouvilla.com</a>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <p>
                                Utilisez le calendrier à droite pour trouver les dates disponibles.<br />
                                Les dates indiquées en rose sont provisoirement réservées.<br />
                                (Envoyez-nous un courriel à <a href="mailto:info@thebijouvilla.com">info@thebijouvilla.com</a> Si vous souhaitez être contacté si ces dates deviennent disponibles.)<br />
                                Les dates indiquées en rouge ne sont pas disponibles.<br />
                                Dès réception de votre réservation, nous vous enverrons un e-mail avec les détails du paiement afin que vous puissiez confirmer votre réservation. 
                                Les réservations sont conservées pendant une semaine et confirmées sur preuve de paiement.
                            </p>
                            <p>
                                <strong>Modalités de paiement</strong><br />
                                50&#37; À la réservation<br />
                                50&#37; 60 jours avant l'arrivée
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
                            <strong>Pour effectuer une réservation en ligne avec paiement par carte de crédit, veuillez visiter notre site sur Homeaway.fr en cliquant sur le lien suivant ou en le collant dans votre navigateur: 
                            <a class="ObviousLink" target="_blank" href="http://www.homeaway.co.uk/p6883483">http://www.homeaway.co.uk/p6883483</a></strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="30%">&nbsp;</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <strong>Vous pouvez aussi remplir le formulaire ci-dessous et cliquer sur le bouton &quot;Réservation&quot; Bouton en bas.</strong>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <p>
                                Sélectionnez le début de la semaine que vous aimeriez séjourner à The Bijou.
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Date de début (cliquez pour sélectionner)"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
                            <asp:HiddenField ID="txtEndDate" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <h4>About you:</h4>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Nom complet"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTenantName" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Première ligne d'adresse"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress1" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Deuxième ligne d'adresse"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress2" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Province"></asp:Label>
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
                            <asp:Label ID="Label8" runat="server" Text="Région"></asp:Label>
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
                            <asp:Label ID="Label11" runat="server" Text="Email"></asp:Label>
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
                            <asp:Label ID="Label13" runat="server" Text="Numéro de portable"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMobile" runat="server" Width="250"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label14" runat="server" Text="Commentaires - (inclure les dates préférées si la réservation pendant les périodes creuses)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Rows="10" Width="800"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label2" runat="server" Text="Dites-nous comment vous avez entendu parler de nous. (Agence, Recommandation, Moteur de recherche, etc.)"></asp:Label>
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
                    <asp:Button ID="btnClear" runat="server" Text="Clair" OnClick="btnClear_Click" />
                </p>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

