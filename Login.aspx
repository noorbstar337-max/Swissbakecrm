<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SwissBake CRM - Admin Login</title>

    <meta name="viewport" content="width=device-width,initial-scale=1,maximum-scale=1.0" />

    <!-- Icons -->
    <!-- The following icons can be replaced with your own, they are used by desktop and mobile browsers -->


    <!-- END Icons -->

    <!-- Stylesheets -->
    <!-- Bootstrap is included in its original form, unaltered -->
    <link rel="stylesheet" href="css/bootstrap.min.css">

    <!-- Related styles of various icon packs and plugins -->
    <link rel="stylesheet" href="css/plugins.css">

    <!-- The main stylesheet of this template. All Bootstrap overwrites are defined in here -->
    <link rel="stylesheet" href="css/main.css">

    <!-- Include a specific file here from css/themes/ folder to alter the default theme of the template -->

    <!-- The themes stylesheet of this template (for using specific theme color in individual elements - must included last) -->
    <link rel="stylesheet" href="css/themes.css">
    <!-- END Stylesheets -->

    <!-- Modernizr (browser feature detection library) & Respond.js (Enable responsive CSS code on browsers that don't support it, eg IE8) -->
    <%--<script src="js/vendor/modernizr-2.7.1-respond-1.4.2.min.js"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <img src="img/placeholders/backgrounds/login_full_bg.jpg" alt="Login Full Background" class="full-bg animation-pulseSlow">
        <!-- END Login Full Background -->

        <!-- Login Container -->
        <div id="login-container" class="animation-fadeIn">
            <!-- Login Title -->
            <div class="login-title text-center">
                <h1><strong>Administrator Control Center</strong>
                    <br />
                    <small>Please login to access this secure area.</small>
                </h1>
            </div>
            <!-- END Login Title -->

            <!-- Login Block -->
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
    
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="block push-bit">
                        <!-- Login Form -->
                        <asp:Panel runat="server" DefaultButton="btnsubmit">
                            <div class="form-horizontal form-bordered form-control-borderless">
                                <div class="form-group">
                                    <div class="col-xs-12">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                            <%--  <input type="text" id="login-email" name="login-email" class="form-control input-lg" placeholder="Email">--%>
                                            <asp:TextBox ID="txtusername" runat="server" CssClass="form-control input-lg" placeholder="UserName" TabIndex="1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rqusername" runat="server" ControlToValidate="txtusername" ValidationGroup="LoginGroup" CssClass="text-danger"
                                                ErrorMessage="Enter User Name" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-xs-12">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="gi gi-asterisk"></i></span>
                                            <%--<input type="password" id="login-password" name="login-password" class="form-control input-lg" placeholder="Password">--%>
                                            <asp:TextBox ID="txtpassword" runat="server" class="form-control input-lg" TextMode="Password" placeholder="Password" TabIndex="2"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rqpassword" runat="server" ControlToValidate="txtpassword" ValidationGroup="LoginGroup" CssClass="text-danger"
                                                ErrorMessage="Enter Password" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group form-actions">
                                    <div class="col-xs-8 text-right">
                                        <asp:Button  type="submit" runat="server" TabIndex="3" ID="btnsubmit" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true;"
                                            UseSubmitBehavior="false" ValidationGroup="LoginGroup" class="btn btn-sm btn-primary" Text="Login to Dashboard"/>
                                        
                                    </div>
                                   
                                    <div class="col-xs-12 text-right">
                                        <asp:Label ID="lblip" runat="server" Visible="false"></asp:Label>
                                    </div>                                   
                                </div>
                                  <div class=" text-center">
                                        <a href="ForgotPassword.aspx" id="link-reminder-login"><small>Forgot password?</small>
                                    </div><br />
                            </div>
                        </asp:Panel>
                        <!-- END Login Form -->

                        <!-- Reminder Form -->

                        <!-- END Reminder Form -->

                        <!-- Register Form -->

                        <!-- END Register Form -->
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <!-- END Login Block -->
        </div>

        <!-- END Modal Terms -->

        <!-- Include Jquery library from Google's CDN but if something goes wrong get Jquery from local file (Remove 'http:' if you have SSL) -->
        <%--  <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
        <script>!window.jQuery && document.write(decodeURI('%3Cscript src="js/vendor/jquery-1.11.1.min.js"%3E%3C/script%3E'));</script>

        <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
        <script src="js/vendor/bootstrap.min.js"></script>
        <script src="js/plugins.js"></script>
        <script src="js/app.js"></script>--%>

        <!-- Load and execute javascript code used only in this page -->
        <%--      <script src="js/pages/login.js"></script>
        <script>$(function () { Login.init(); });</script>--%>
    </form>
</body>
</html>
