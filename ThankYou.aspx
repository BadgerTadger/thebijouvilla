<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ThankYou.aspx.cs" Inherits="ThankYou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>Thank you.</h3>
    <p>We will contact you shortly regarding your booking request.</p>
    <p><asp:Label ID="lblBookingID" runat="server" Text=""></asp:Label></p>
</asp:Content>

