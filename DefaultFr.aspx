<%@ Page Title="Accueil" Language="C#" MasterPageFile="~/SiteFr.master" AutoEventWireup="true" CodeFile="DefaultFr.aspx.cs" Inherits="DefaultFr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css" title="NOF_STYLE_SHEET" media="screen">
        DIV#img1 {
            position: relative;
            left: 0px;
            top: 10px;
            z-index: 10;
            width: 100px;
        }

        DIV#img2 {
            position: absolute;
            left: 110px;
            top: 10px;
            z-index: 10;
        }

        DIV#img3 {
            position: absolute;
            left: 279px;
            top: 10px;
            z-index: 10;
        }

        DIV#img4 {
            position: absolute;
            left: 517px;
            top: 10px;
            z-index: 10;
        }

        DIV#img5 {
            position: absolute;
            left: 876px;
            top: 10px;
            z-index: 10;
        }

        DIV#img6 {
            position: absolute;
            left: 110px;
            top: 197px;
            z-index: 10;
        }

        DIV#img7 {
            position: relative;
            left: 0px;
            top: 17px;
            z-index: 10;
            width: 100px;
            margin-bottom: 30px;
        }

        DIV#img8 {
            position: absolute;
            left: 108px;
            top: 360px;
            z-index: 10;
        }

        DIV#img9 {
            position: absolute;
            left: 708px;
            top: 170px;
            z-index: 10;
        }

        DIV#img10 {
            position: absolute;
            left: 876px;
            top: 406px;
            z-index: 10;
        }

        DIV#logo {
            position: absolute;
            left: 279px;
            top: 170px;
            z-index: 10;
            overflow: hidden;
        }

        DIV#masque {
            position: absolute;
            z-index: 12;
            top: 0px;
            left: -150px;
        }
    </style>

    <script lang="javascript" type="text/javascript">

        var btoff = new Image();
        var bton = new Image();

        btoff.src = "../images/bouton-ok-off.gif";
        bton.src = "../images/bouton-ok-on.gif";
        var t = 0;

        function zap(f) {
            if (f.recherche1.value.length == 2) f.recherche2.focus();
        }

        function effacement() {
            setTimeout("document.getElementById('alert').style.visibility='hidden'", 10000);
        }

        $(document).ready(function () {
            var duration = 1000;
            $("#masque").delay(500).animate({
                marginLeft: "500px",
            }, 3500);

            $.expr[':'].regex = function (elem, index, match) {
                var matchParams = match[3].split(','),
                    validLabels = /^(data|css):/,
                    attr = {
                        method: matchParams[0].match(validLabels) ?
                                    matchParams[0].split(':')[0] : 'attr',
                        property: matchParams.shift().replace(validLabels, '')
                    },
                    regexFlags = 'ig',
                    regex = new RegExp(matchParams.join('').replace(/^\s+|\s+$/g, ''), regexFlags);
                return regex.test(jQuery(elem)[attr.method](attr.property));
            }

            $('div:regex(id,^img)').mouseover(function () {
                $(this).fadeTo(1, 0.5);
                $(this).fadeTo(duration, 1);
            });

            $("#recherche2").keypress(function (e) {
                if (e.which == 13) {
                    if (document.f.recherche1.value != '' && document.f.recherche2.value != '') document.f.submit(); else alert('Vous devez saisir une référence');
                }
            });

            $("#recherche20").keypress(function (e) {
                if (e.which == 13) {
                    if (document.f2.recherche1.value != '' && document.f2.recherche2.value != '') document.f2.submit(); else alert('Vous devez saisir une référence');
                }
            });
        });
    </script>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="img1">
        <a href="propriete-a-vendre-sud-france/index.php">
            <img src="images/image1.jpg" border="0"></a>
    </div>
    <div id="img2">
        <a href="propriete-a-vendre-sud-france/index.php">
            <img src="images/image2.jpg" border="0"></a>
    </div>
    <div id="img3">
        <a href="propriete-a-vendre-sud-france/index.php">
            <img src="images/image3.jpg" border="0"></a>
    </div>
    <div id="img4">
        <a href="propriete-a-vendre-sud-france/index.php">
            <img src="images/image4.jpg" border="0"></a>
    </div>
    <div id="img5">
        <a href="propriete-a-vendre-sud-france/index.php">
            <img src="images/image5.jpg" border="0"></a>
    </div>
    <div id="img6">
        <a href="propriete-a-vendre-sud-france/index.php">
            <img src="images/image6.jpg" border="0"></a>
    </div>
    <div id="img7">
        <a href="propriete-a-vendre-sud-france/index.php">
            <img src="images/image7.jpg" border="0"></a>
    </div>
    <div id="img8">
        <a href="propriete-a-vendre-sud-france/index.php">
            <img src="images/image8.jpg" border="0"></a>
    </div>
    <div id="img9">
        <a href="propriete-a-vendre-sud-france/index.php">
            <img src="images/image9.jpg" border="0"></a>
    </div>
    <div id="img10">
        <a href="propriete-a-vendre-sud-france/index.php">
            <img src="images/image10.jpg" border="0"></a>
    </div>
    <div id="logo">
        <div id="masque">
            <a href="propriete-a-vendre-sud-france/index.php">
                <img src="images/fond-masque.png" border="0"></a>
        </div>
        <div style="position: relative; z-index: 11;">
            <a href="propriete-a-vendre-sud-france/index.php">
                <img src="images/TBVlogo.gif" border="0"></a>
        </div>
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
                <td colspan="3" class="gris11" style="text-align: center">Vive la France!</td>
            </tr>
            <tr>
                <td></td>
                <td height="50" colspan="3" class="gris11" style="text-align: center">Photographies de Rodney Love <a href="https://ello.co/rodneylove">https://ello.co/rodneylove</a></td>
            </tr>
        </table>
    </div>
</asp:Content>
