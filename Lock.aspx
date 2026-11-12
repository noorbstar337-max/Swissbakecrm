<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Lock.aspx.vb" Inherits="Lock" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width,initial-scale=1,maximum-scale=1.0" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <!-- Related styles of various icon packs and plugins -->
    <link rel="stylesheet" href="css/plugins.css" />

    <!-- The main stylesheet of this template. All Bootstrap overwrites are defined in here -->
    <link rel="stylesheet" href="css/main.css" />

    <!-- Include a specific file here from css/themes/ folder to alter the default theme of the template -->

    <!-- The themes stylesheet of this template (for using specific theme color in individual elements - must included last) -->
    <link rel="stylesheet" href="css/themes.css" />
    <!-- END Stylesheets -->

    <!-- Modernizr (browser feature detection library) & Respond.js (Enable responsive CSS code on browsers that don't support it, eg IE8) -->
    <script src="js/vendor/modernizr-2.7.1-respond-1.4.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <img src="img/placeholders/backgrounds/lock_full_bg.jpg" alt="Login Full Background" class="full-bg animation-pulseSlow" />
        <!-- END Login Full Background -->

        <!-- Login Container -->
        <div id="login-container" class="animation-hatch">
            <!-- Login Title -->
            <div class="login-title text-right">
                <h1 class="text-center">
                    <asp:Image ID="imgprofile" runat="server" class="img-circle push" Height="100" />
                    <br>
                    <strong>
                        <asp:Label ID="lblname" runat="server"></asp:Label></strong><br>
                    <small>
                        <asp:Label ID="lblemail" runat="server"></asp:Label></small>
                </h1>
            </div>
            <!-- END Login Title -->

            <!-- Login Block -->
            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnunlock">
                <div class="block">
                    <div class="form-group">
                        <div class="col-xs-12">
                            <div class="input-group">
                                <asp:TextBox TextMode="password" ID="txtlockpass" runat="server" onfocus="$(this).removeAttr('readonly');" TabIndex="1" CssClass="form-control" placeholder="Password" Height="34" />
                                <div class="input-group-btn">
                                    <asp:LinkButton ID="btnunlock" runat="server" class="btn btn-primary" TabIndex="2"><i class="fa fa-unlock-alt"></i> Unlock</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                    <p class="text-center">
                        <a href="Login.aspx" tabindex="3"><small>Not
                            <asp:Label ID="lblname2" runat="server"></asp:Label>?</small></a>
                    </p>
                </div>
            </asp:Panel>
            <!-- END Login Block -->
        </div>
        <!-- END Login Container -->
    </form>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script>!window.jQuery && document.write(decodeURI('%3Cscript src="js/vendor/jquery-1.11.1.min.js"%3E%3C/script%3E'));</script>

    <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
    <script src="js/vendor/bootstrap.min.js"></script>
    <script src="js/plugins.js"></script>
    <script src="js/app.js"></script>
</body>
</html>
