<%@ Page Title="Contactez nous" Language="C#" MasterPageFile="~/SiteFr.master" AutoEventWireup="true" CodeFile="ContactFr.aspx.cs" Inherits="ContactFr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Vous pouvez contacter &#39;The Bijou&#39; par courrier à:</h3>
    <address>
        Marie and Robert Pyle<br />
        The Bijou<br />
        15, Domaine du Pre Cabrian<br />
        30330 GAUJAC<br />
        France<br />
        <br />
        GPS: Latitude 44.0814 Longitude 04.5762<br />
    </address>

    <address>
    <h3>Ou par courriel à:</h3>
        <strong>Email:</strong>   <a href="mailto:info@thebijouvilla.com">info@thebijouvilla.com</a><br />
    </address>
</asp:Content>

