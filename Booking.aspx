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
                            <p>
                                Rates for 2017.<br />
                                January to April €1000 per week.*<br />
                                May and June €1250 per week.*<br />
                                July and August €1550 per week.<br />
                                September and October €1250 per week.*<br />
                                November and December €1000 per week.*<br />
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <p>
                                Bookings are 1600 Saturday to 1100 Saturday.<br />
                                For off-peak periods marked * shorter periods may be possible.<br />
                                To confirm availability, request a booking or to request availability and rates for shorter periods, use the request form below or e mail the owners at <a href="mailto:info@thebijouvilla.com">info@thebijouvilla.com</a>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align:top">
                            <p>
                                Use the calendar to the right to find available dates.<br />
                                Dates shown in Pink are provisionally booked.<br />
                                (Please email us at <a href="mailto:info@thebijouvilla.com">info@thebijouvilla.com</a> if you would like to be contacted if these dates become available.)<br />
                                Dates shown in red are not available.
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
                            <h4>Please complete the form below and click the &quot;Book&quot; button at the bottom.</h4>
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
                            <asp:Label ID="Label1" runat="server" Text="Start Date"></asp:Label>
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
                </table>
                <asp:Label ID="lblWarning" CssClass="WarningText" runat="server" Text="" Visible="false"></asp:Label>
                <p>
                    <asp:Button ID="btnBook" runat="server" Text="Book" OnClick="btnBook_Click" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                </p>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

