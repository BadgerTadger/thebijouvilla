<%@ Page Title="Contactez nous" Language="C#" MasterPageFile="~/SiteFr.master" AutoEventWireup="true" CodeFile="ContactFr.aspx.cs" Inherits="ContactFr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Vous pouvez contacter &#39;The Bijou&#39; par courrier à:</h3>
    <address>
        Robert Pyle<br />
        Somewhere in France<br />
        <abbr title="Phone">P:</abbr>
        +33 00000000
    </address>

    <address>
    <h3>Or by email at:</h3>
        <strong>Email:</strong>   <a href="mailto:info@thebijouvilla.com">info@thebijouvilla.com</a><br />
    </address>
</asp:Content>

