<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Gallery2.aspx.cs" Inherits="Gallery2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <link rel="stylesheet" href="Content/Gallery.css" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table style="width: 100%; height: 100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>&nbsp;</td>
            <td align="center" width="1000" valign="top">
                Click on an image to see a larger version
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <div class="gallery">
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/Town.jpg"></a>
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/gorges%20Ardeche.jpg" />
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/5A.jpg" /></a>
        </a>
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/languedoc-roussillon%201.jpg" />
        </a>

        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/lavender%20region.jpg" />
        </a>
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/Nimes.jpg" />
        </a>
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/Oak.jpg" />
        </a>
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/Pont%20du%20Gard%20free.jpg" />
        </a>

        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/avignon.png" />
        </a>
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/Camargue1.jpg" />
        </a>
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/Building.jpg" />
        </a>
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/Sunflower%20region.jpg" />
        </a>

        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/Uzes%20atmosphere.jpg" />
        </a>
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/Uzes%20market.jpg" />
        </a>
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/uzes%20market2.jpg" />
        </a>
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/uzesmarket3.jpg" />
        </a>
        <span class="closed">+</span>
        <span class="closed-layer"></span>
    </div>
    <div class="footer">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td width="70" height="25">&nbsp;</td>
                <td width="362"></td>
                <td width="363"></td>
                <td width="80"></td>
            </tr>
            <tr>
                <td></td>
                <td colspan="3" class="gris11" style="text-align: center"><a href="Gallery.aspx">&lt;&lt;&nbsp;Page 1</a></td>
            </tr>
        </table>
    </div>
</asp:Content>
