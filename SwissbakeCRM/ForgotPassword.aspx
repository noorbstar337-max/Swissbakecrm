<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ForgotPassword.aspx.vb" Inherits="ForgotPassword" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CRM -Admin Login</title>
    <meta name="viewport" content="width=device-width,initial-scale=1,maximum-scale=1.0" />
    <link rel="shortcut icon" href="img/favicon.ico">
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <link rel="stylesheet" href="css/plugins.css">
    <link rel="stylesheet" href="css/main.css">
    <link rel="stylesheet" href="css/themes.css">
</head>
<body>
    <form id="form1" runat="server">
        <img src="img/placeholders/backgrounds/login_full_bg.jpg" alt="Login Full Background" class="full-bg animation-pulseSlow">
        <div id="login-container" class="animation-fadeIn">
            <div class="login-title text-center">
                <h1><strong>Reset Password</strong>
                    <br />
                    <small>Enter email to reset your password</small>
                </h1>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="block push-bit">
                        <asp:Panel runat="server" DefaultButton="btnsubmit">
                            <div class="form-horizontal form-bordered form-control-borderless">
                                <div class="form-group">
                                    <div class="col-xs-12">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                            <asp:TextBox ID="txtusername" runat="server" CssClass="form-control input-lg" placeholder="Enter Email Id" TabIndex="1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rqusername" runat="server" ControlToValidate="txtusername" ValidationGroup="LoginGroup" CssClass="text-danger"
                                                ErrorMessage="Enter email id" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblemail" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group form-actions">
                                    <div class="col-xs-4 text-right">
                                        <asp:Button type="submit" runat="server" TabIndex="2" ID="btnsubmit" OnClientClick="if (!Page_ClientValidate('LoginGroup')){ return false; } this.disabled = true;"
                                            UseSubmitBehavior="false" ValidationGroup="LoginGroup" class="btn btn-sm btn-primary" Text="Submit"/>
                                    </div>
                                    <div class="col-xs-8 text-left">
                                        <small>Did you remember your password?</small> <a href="Login.aspx" id="link-reminder"><small>Login</small></a>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
