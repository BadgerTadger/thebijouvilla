<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>You can contact us by</h3>
    <h3>Post</h3>
    <address>
        Marie and Robert Pyle<br />
        The Bijou<br />
        15, Domaine du Pre Cabrian<br />
        30330 GAUJAC<br />
        France<br />
        <br />
        GPS: Latitude 44.0814 Longitude 04.5762<br />
    </address>
    <h3>E-mail</h3>
    <address>
        <a href="mailto:info@thebijouvilla.com">info@thebijouvilla.com</a><br />
    </address>
    <h3>By filling the form under bookings</h3>
    <p>Languages spoken: English, French, German and Italian.</p>
</asp:Content>
