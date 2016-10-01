﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Gallery.aspx.cs" Inherits="Gallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <link rel="stylesheet" href="Content/Gallery.css" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table style="width: 100%; height: 100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>&nbsp;</td>
            <td align="center" width="1000" valign="top">
                Click on an image to see a larger version.
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <div class="gallery">
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/29A.jpg"></a>
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/5A.jpg" /></a>
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/avignon.png" />
        </a>
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/Camargue1.jpg" />
        </a>

        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/Covered%20terrace.jpg" />
        </a>
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/Diningkitchen.jpg" />
        </a>
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/Diningsalon.jpg" />
        </a>
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/ello-hdpi-5da91a04.jpg" />
        </a>

        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/ello-hdpi-cfb7fb3f.jpg" />
        </a>
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/ello-hdpi-eac18384.jpg" />
        </a>
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/Gaujac%20castle.jpg" />
        </a>
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/Gaujac%20village.jpg" />
        </a>

        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/Gite2.jpg" />
        </a>
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/Gite3.jpg" />
        </a>
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/Gitebed1.jpg" />
        </a>
        <a class="gallerya" tabindex="1">
            <img class="galleryaimg" src="images/Gallery/Gitebed2.jpg" />
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
                <td colspan="3" class="gris11" style="text-align: center"><a href="Gallery2.aspx">Page 2&nbsp;&gt;&gt;</a></td>
            </tr>
        </table>
    </div>
</asp:Content>

