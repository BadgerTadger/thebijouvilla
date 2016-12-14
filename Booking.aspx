<%@ Page Title="Booking" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Booking.aspx.cs" Inherits="Booking_Booking" %>

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
                                            <strong>Rates for 2017.</strong><br />
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><strong>Rate Period</strong></td>
                                    <td><strong>Minimum Rate</strong></td>
                                    <td><strong>Additional Night</strong></td>
                                </tr>
                                <tr>
                                    <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><strong>Low Season</strong></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>31-Dec-2016 - 29-Apr-2017</td>
                                    <td>&#8364;428.58</td>
                                    <td>From &#8364;142.86</td>
                                </tr>
                                <tr>
                                    <td><em>3 nights minimum stay</em></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><strong>Mid Season</strong></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>30-Apr-2017 - 03-Jun-2017</td>
                                    <td>&#8364;471.42</td>
                                    <td>From &#8364;157.14</td>
                                </tr>
                                <tr>
                                    <td><em>3 nights minimum stay</em></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><strong>High Season</strong></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>4-Jun-2017 - 23-Sep-2017</td>
                                    <td>&#8364;1249.99</td>
                                    <td>From &#8364;178.57</td>
                                </tr>
                                <tr>
                                    <td><em>7 nights minimum stay</em></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><strong>Autumn</strong></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>24-Sep-2017 - 28-Oct-2017</td>
                                    <td>&#8364;471.42</td>
                                    <td>From &#8364;157.14</td>
                                </tr>
                                <tr>
                                    <td><em>3 nights minimum stay</em></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><strong>Winter</strong></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>29-Oct-2016 - 30-Dec-2017</td>
                                    <td>&#8364;428.58</td>
                                    <td>From &#8364;142.86</td>
                                </tr>
                                <tr>
                                    <td><em>3 nights minimum stay</em></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><strong>My standard rate</strong></td>
                                    <td>&#8364;1000.02</td>
                                    <td>From &#8364;142.86</td>
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
                                <strong>Bookings are 1600 Saturday to 1100 Saturday</strong><br />
                                To confirm availability, request a booking or to request availability and rates for shorter periods, use the request form below or e-mail the owners at <a href="mailto:info@thebijouvilla.com">info@thebijouvilla.com</a>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <p>
                                Use the calendar to the right to find available dates.<br />
                                Dates shown in pink are provisionally booked.<br />
                                (Please email us at <a href="mailto:info@thebijouvilla.com">info@thebijouvilla.com</a> if you would like to be contacted if these dates become available.)<br />
                                Dates shown in red are not available.<br />
                                On receipt of your reservation, we will e-mail you with payment details so that you can confirm your booking. Reservations are held for one week and confirmed upon proof of payment.
                            </p>
                            <p>
                                <strong>Payment Terms</strong><br />
                                50&#37; at Booking<br />
                                50&#37; 60 days before arrival
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
                        <td align="center" colspan="2">
                            <h4>Please complete the form below and click the &quot;Reservation&quot; button at the bottom.</h4>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <p>
                                Select the beginning of the week that you would like to stay at The Bijou.
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Start Date (click to select)"></asp:Label>
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
                            <asp:Label ID="Label3" runat="server" Text="Full Name"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTenantName" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="First Line of Address"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress1" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Second Line of Address"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress2" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Town"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTown" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="City"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCity" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="County"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCounty" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text="Postcode"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPostcode" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="Country"></asp:Label>
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
                            <asp:Label ID="Label12" runat="server" Text="Landline"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLandline" runat="server" Width="250"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label13" runat="server" Text="Mobile"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMobile" runat="server" Width="250"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label14" runat="server" Text="Comments - (include preferred dates if booking during off-peak periods)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Rows="10" Width="800"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label2" runat="server" Text="Please tell us how you heard about us. (Agency, Recommendation, Search Engine etc.)"></asp:Label>
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
                    <asp:Button ID="btnBook" runat="server" Text="Reservation" OnClick="btnBook_Click" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                </p>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

