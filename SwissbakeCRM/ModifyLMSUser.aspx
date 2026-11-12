<%@ Page Title="" Language="VB" MasterPageFile="~/LMSMasterPage.master" AutoEventWireup="false" CodeFile="ModifyLMSUser.aspx.vb" Inherits="ModifyLMSUser" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="row">
        <asp:HiddenField ID="hfemail" runat="server" />
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <i class="gi gi-user" style="margin: -8px"></i>Modify User<br>
                    </h1>
                </div>
            </div>

            <ul class="breadcrumb breadcrumb-top">
                <li><a href="LMS.aspx">Home</a></li>
                <li><a href="LMSUser.aspx">User</a></li>
                <li>Modify User</li>
            </ul>

            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" OnClick="btnadd_Click" />
                    <asp:HyperLink ID="HyperLink1" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/LMSUser.aspx" class="btn btn-alt btn-sm btn-danger" />
                </div>
            </div>

            <div class="col-md-12">
                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <h4 class="widget-content-light abc">
                            <strong>User</strong> Information
                            <small class="left11">
                                <span id="modifyspan" runat="server">By&nbsp;<a style="text-decoration: none;"><asp:Label ID="lblmodifiedname" runat="server" Font-Bold="true"></asp:Label></a>&nbsp;on&nbsp;<a style="text-decoration: none;"><asp:Label ID="lblmodifieddate" Font-Bold="true" runat="server" Font-Italic="true"></asp:Label></a>
                                </span>
                            </small>
                        </h4>

                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-email">Role<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddllevel" runat="server" data-toggle="tooltip" title="Role" CssClass="form-control" >
                                            <asp:ListItem Value="0">Select Role</asp:ListItem>
                                            <asp:ListItem Value="1">Admin</asp:ListItem>
                                            <asp:ListItem Value="2">R & D</asp:ListItem>
                                            <asp:ListItem Value="3">Lab Technician</asp:ListItem>
                                            <asp:ListItem Value="4">Factory Lab Technician</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="relevel" runat="server" ControlToValidate="ddllevel" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please select role" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">First Name<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtfirstname" runat="server" placeholder="Enter First Name" data-toggle="tooltip" title="Enter First Name"
                                            CssClass="form-control" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="refirstname" runat="server" ControlToValidate="txtfirstname" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter first name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Last Name</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtlastname" runat="server" placeholder="Enter Last Name" data-toggle="tooltip" title="Enter Last Name"
                                            CssClass="form-control" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="relast" runat="server" ControlToValidate="txtlastname" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter last name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <%--<div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Date of Birth </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtdob" runat="server" placeholder="Enter Date of Birth" data-toggle="tooltip" title="Enter Date of Birth"
                                            CssClass="form-control" TextMode="Date" ></asp:TextBox>
                                    </div>
                                </div>
                            </div>--%>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Department</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddldept" runat="server" data-toggle="tooltip" title="User" CssClass="select-chosen" ></asp:DropDownList>
                                        <br />
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Designation</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddldesignation" runat="server" data-toggle="tooltip" title="Dsignation" CssClass="select-chosen" ></asp:DropDownList>
                                        <br />
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Report To </label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlemp" runat="server" data-toggle="tooltip" title="Report To" CssClass="select-chosen" ></asp:DropDownList>
                                        <br />
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Mobile No</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtmob" runat="server" placeholder="Enter Mobile Number" data-toggle="tooltip" title="Enter Mobile Number"
                                            CssClass="form-control"  onkeyup="this.value=this.value.replace(/[^\d\.]/g,'');"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="remob" runat="server" ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" ValidationGroup="MasterGroup"
                                            ErrorMessage="Please enter valid mobile number" ControlToValidate="txtmob" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Email Id<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtemail" runat="server" placeholder="Enter Email Id" data-toggle="tooltip" title="Enter Email Id"
                                            CssClass="form-control" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reemail" runat="server" ControlToValidate="txtemail" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter email id" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="regemail" runat="server" ValidationGroup="MasterGroup" ErrorMessage="Please enter valid email id"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:Label ID="lblemail" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4" runat="server" id="divpass">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Password <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtpass" runat="server" placeholder="" data-toggle="tooltip" title="Password" CssClass="form-control" TextMode="Password" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="repass" runat="server" ControlToValidate="txtpass" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter password" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <%--<div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Display Name</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtdisplayname" runat="server" placeholder="Enter Display Name" data-toggle="tooltip" title="Enter Display Name"
                                            CssClass="form-control" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdisplayname" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter Display name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>--%>

                            <div class="col-md-4" runat="server" id="divresetpassword">
                                <div class="col-md-4"></div>
                                <div class="col-md-8">
                                    <asp:LinkButton ID="btnShow" runat="server" Text="Reset Password" class="btn btn-sm btn-primary"></asp:LinkButton>
                                </div>
                            </div>

                            <%-- <asp:LinkButton ID="LinkButton1" runat="server" />--%>
                            <asp:ModalPopupExtender ID="mpe" runat="server" BehaviorID="mpe" PopupControlID="pnlPopup" TargetControlID="btnShow"
                                CancelControlID="btnNo">
                            </asp:ModalPopupExtender>
                            <asp:Panel ID="pnlPopup" runat="server" Style="display: none" DefaultButton="btnresetpass">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                                            <h4 class="modal-title">
                                                <asp:Label ID="lblheading" runat="server" Text="Reset Password" Font-Bold="true"></asp:Label>
                                            </h4>
                                        </div>
                                        <div class="modal-body">
                                            <div class="form-group">
                                                <label for="example-nf-email">New Password <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtnewpass" runat="server" placeholder="Enter New Password" data-toggle="tooltip" title="Enter New Password"
                                                    CssClass="form-control"  TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rqusername" runat="server" ControlToValidate="txtnewpass" ValidationGroup="passwordgroup" CssClass="MasterValidationCSS"
                                                    ErrorMessage="Please enter a new password" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="form-group">
                                                <label for="example-nf-email">Confirm Password <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtconfirm" runat="server" placeholder="Enter Confirm Password" data-toggle="tooltip" title="Enter Confirm Password"
                                                    CssClass="form-control"  TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnewpass" ValidationGroup="passwordgroup" CssClass="MasterValidationCSS"
                                                    ErrorMessage="Please enter a confirm password" Display="Dynamic"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="cvpass" runat="server" ErrorMessage="Password does not match" ControlToValidate="txtconfirm" ControlToCompare="txtnewpass" Operator="Equal"
                                                    ValidationGroup="passwordgroup" CssClass="MasterValidationCSS" Display="Dynamic"></asp:CompareValidator>
                                                <br />
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                            <asp:Button ID="btnresetpass" runat="server" OnClientClick="if (!Page_ClientValidate('passwordgroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                                UseSubmitBehavior="false" class="btn btn-sm btn-primary" ValidationGroup="passwordgroup" Text="Save" ></asp:Button>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>

                            <div style="clear: both"></div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup"  />
                    <asp:HyperLink ID="hfcancel" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/LMSUser.aspx" class="btn btn-alt btn-sm btn-danger"  />
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

