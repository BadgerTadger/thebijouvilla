<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>You can contact &#39;The Bijou&#39; by post at:</h3>
    <address>
        Marie and Robert Pyle<br />
        The Bijou<br />
        15, Domaine du Pre Cabrian<br />
        30330 GAUJAC<br />
        France<br />
        <br />
        GPS: Latitude 44.0814 Longitude 04.5762<br />
    </address>

    <h3>Or by email at:</h3>
    <address>
        <strong>Email:</strong>   <a href="mailto:info@thebijouvilla.com">info@thebijouvilla.com</a><br />
    </address>
</asp:Content>
