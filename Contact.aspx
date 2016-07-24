<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>You can contact &#39;The Bijou&#39; by post at:</h3>
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
