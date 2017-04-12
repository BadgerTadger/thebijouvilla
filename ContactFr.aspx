<%@ Page Title="Conctac" Language="C#" MasterPageFile="~/SiteFr.master" AutoEventWireup="true" CodeFile="ContactFr.aspx.cs" Inherits="ContactFr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Nous sommes joignables par</h3>
    <h3>Poste</h3>
    <address>
        Marie et Robert Pyle<br />
        The Bijou<br />
        15, Domaine du Pré Cabrian<br />
        30330 GAUJAC<br />
        France<br />
        <br />
        GPS: Latitude 44.0814 Longitude 04.5762<br />
    </address>

    <address>
    <h3>E-mail</h3>
        <strong>Email:</strong>   <a href="mailto:info@thebijouvilla.com">info@thebijouvilla.com</a><br />
    </address>
    <h3>en complétant le formulaire de réservation</h3>
    <p>Nous parlons français, anglais, allemand et italien.</p>
</asp:Content>

