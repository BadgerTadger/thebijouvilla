<%@ Page Title="Booking" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Booking.aspx.cs" Inherits="Booking_Booking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>jQuery UI Datepicker - Default functionality</title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#StartDatePicker").datepicker();
        });
        $(function () {
            $("#EndDatePicker").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="Server">
    <table style="width: 100%; height: 100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>&nbsp;</td>
            <td align="center" width="1000" valign="top">
                <p>English Booking Page</p>
                <table>
                    <tr>
                        <td width="70%">
                            <p>Use the calendar to the right to find available dates. Dates shown in pink are not available</p>
                            <p>Select the start and end dates that you would like to stay at The Bijou.</p>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Start Date"></asp:Label>
                                    </td>
                                    <td>
                                        <input type="text" id="StartDatePicker">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="End Date"></asp:Label>
                                    </td>
                                    <td>
                                        <input type="text" id="EndDatePicker">
                                    </td>
                                </tr>
                            </table>

                        </td>
                        <td>
                            <asp:Calendar ID="Calendar1" OnDayRender="Calendar1_DayRender"
                                runat="server" Width="30%" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged" SelectionMode="None"></asp:Calendar>
                            <asp:Label runat="server" ID="lblStatus" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

