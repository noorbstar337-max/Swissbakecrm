<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LMSLogin.aspx.vb" Inherits="LMSLogin" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LMS -Admin Login</title>

    <meta name="viewport" content="width=device-width,initial-scale=1,maximum-scale=1.0" />
      <style>
        h2 {
            color: black;
            font-size: 14px;
            border-bottom: 1px solid;
            margin-bottom: 20px;
            padding-bottom: 10px;
            border-bottom-style: dashed;
            font-weight: bold;
        }

        fieldset {
            border: 1px solid rgb(208, 201, 201);
            margin-bottom: 25px;
        }

        .page3 {
            margin: 0 auto;
            display: table;
            width: 980px;
            background: none;
        }

        .fscf-div-clear {
            float: left;
            margin-right: 34px;
        }

        legend {
            font-size: 14px;
            color: #c42126;
            text-transform: uppercase;
            margin-left: 10px;
            padding: 0 9px;
            font-weight: bold;
        }

        .fscf-label {
            text-transform: uppercase;
        }

        #CheckBox1 {
            width: 24px !important;
        }

        .divWaiting {
            position: fixed;
            background-color: #fafafa;
            z-index: 2147483647 !important;
            opacity: .8;
            overflow: hidden;
            text-align: center;
            top: 0;
            bottom: 0;
            right: 0;
            height: 100%;
            width: 100%;
            padding-top: 20%;
        }
         .pop {
            background-color: rgba(0, 0, 0, 0.46);
        }

          .close {
            /*background-color: #C42126;*/
            color: white;
            padding: 1px 7px 3px;
            border-radius: 16px;
            position: absolute;
            right: 8px;
            margin-top: -8px;
        }
    </style>
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
        <img src="img/placeholders/backgrounds/lock_full_bg.jpg" alt="Login Full Background" class="full-bg animation-pulseSlow" />
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
                                        <asp:Button  type="submit" runat="server" TabIndex="3" ID="btnsubmit" OnClientClick="if (!Page_ClientValidate('LoginGroup')){ return false; } this.disabled = true;"
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
             <%--otp pop up starts--%>
             <asp:LinkButton ID="btnShow" runat="server" />
        <asp:ModalPopupExtender ID="mpe" runat="server" BehaviorID="mpe" PopupControlID="pnlPopup" BackgroundCssClass="pop" TargetControlID="btnShow"
            CancelControlID="btnNo">
        </asp:ModalPopupExtender>
                       <asp:Panel ID="pnlPopup" runat="server" Style="display: none; background-color: #ffffff00; padding: 16px 19px 19px;" DefaultButton="btnsave">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                        <h3 class="modal-title" style="border-bottom: 1px solid red; padding-bottom: 5px; margin-bottom: 17px;">
                            <asp:Label ID="lblheading" runat="server" Text="Please enter OTP" Style="font-weight: bold; font-size: 16px; color: #c42126; text-transform: uppercase; margin-bottom: 10px;"></asp:Label>
                        </h3>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="example-nf-email" style="color: black; font-size: 14px;">
                                OTP Code <span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtuname" runat="server" Style="border: 1px solid #d04849; padding: 5px; width: 267px; margin-bottom: 5px;"
                                placeholder="Enter OTP Code" data-toggle="tooltip" title="Enter OTP Code" TabIndex="1"
                                CssClass="form-control" onkeyup="this.value=this.value.replace(/[^\d\.]/g,'');" MaxLength="6"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="req" runat="server" ControlToValidate="txtuname1" ErrorMessage="wrong" Display="Dynamic" CssClass="text-danger"  ></asp:RequiredFieldValidator>--%>
                            <asp:RequiredFieldValidator ID="remembername" runat="server" ControlToValidate="txtuname" Display="Dynamic"  ValidationGroup="MasterGroup"  CssClass="MasterValidationCSS"
                                ErrorMessage="Please enter OTP code" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:LinkButton  ID="HyperLink1" runat="server" style=" float:left; margin-top: 17px;">Resend Code</asp:LinkButton>
                        <asp:Button ID="btnsave" runat="server" Style="width: 116px; border: 1px solid #A39A9A; padding: 7px; background-color: #B31616; color: white; float: right; margin-top: 9px;"
                              class="btn btn-sm btn-primary"  OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Verifying...';"
                            UseSubmitBehavior="false"  ValidationGroup="MasterGroup" Text="Verify" TabIndex="6"></asp:Button>
                    </div>
                </div>
            </div>
        </asp:Panel>
            <%--otp ends--%>
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

