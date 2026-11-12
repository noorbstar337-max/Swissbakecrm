<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ModifyUser.aspx.vb" Inherits="UserModify" MaintainScrollPositionOnPostback="true" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .control-label {
            padding: 6px;
        }

        .col-md-4 {
            padding-bottom: 0px;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                <li><a href="index.aspx">Home</a></li>
                <li><a href="AdminMenu.aspx">Admin</a></li>
                <li><a href="User.aspx">User</a></li>
                <li>Modify User</li>
            </ul>

            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" OnClick="btnadd_Click" />
                    <asp:HyperLink ID="HyperLink1" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/User.aspx" class="btn btn-alt btn-sm btn-danger" />
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
                                        <asp:DropDownList ID="ddllevel" runat="server" data-toggle="tooltip" title="Role" CssClass="form-control" TabIndex="1"></asp:DropDownList>
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
                                            CssClass="form-control" TabIndex="2"></asp:TextBox>
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
                                            CssClass="form-control" TabIndex="3"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="relast" runat="server" ControlToValidate="txtlastname" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter last name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Date of Birth </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtdob" runat="server" placeholder="Enter Date of Birth" data-toggle="tooltip" title="Enter Date of Birth"
                                            CssClass="form-control" TextMode="Date" TabIndex="4"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Department</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddldept" runat="server" data-toggle="tooltip" title="User" CssClass="select-chosen" TabIndex="5"></asp:DropDownList>
                                        <br />
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Designation</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddldesignation" runat="server" data-toggle="tooltip" title="Dsignation" CssClass="select-chosen" TabIndex="6"></asp:DropDownList>
                                        <br />
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Report To </label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlemp" runat="server" data-toggle="tooltip" title="Report To" CssClass="select-chosen" TabIndex="5"></asp:DropDownList>
                                        <br />
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4" runat="server" id="divpass">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Password <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtpass" runat="server" placeholder="" data-toggle="tooltip" title="Password" CssClass="form-control" TextMode="Password" TabIndex="7"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="repass" runat="server" ControlToValidate="txtpass" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter password" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                               <div class="col-md-4" runat="server" id="divCpass">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Conf Password <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtconpass" runat="server" placeholder="" data-toggle="tooltip" title="Confirm Password" CssClass="form-control" TextMode="Password" TabIndex="8"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtconpass" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter password" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtconpass" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                Operator="Equal" ControlToCompare="txtpass" ForeColor="Red" ErrorMessage="Password must be same" />
                                    </div>
                                </div>
                            </div>
                               <div class="col-md-12">
                                
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Display Name</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtdisplayname" runat="server" placeholder="Enter Display Name" data-toggle="tooltip" title="Enter Display Name"
                                            CssClass="form-control" TabIndex="9"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdisplayname" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter Display name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

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
                                                    CssClass="form-control" TabIndex="1" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rqusername" runat="server" ControlToValidate="txtnewpass" ValidationGroup="passwordgroup" CssClass="MasterValidationCSS"
                                                    ErrorMessage="Please enter a new password" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="form-group">
                                                <label for="example-nf-email">Confirm Password <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtconfirm" runat="server" placeholder="Enter Confirm Password" data-toggle="tooltip" title="Enter Confirm Password"
                                                    CssClass="form-control" TabIndex="2" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnewpass" ValidationGroup="passwordgroup" CssClass="MasterValidationCSS"
                                                    ErrorMessage="Please enter a confirm password" Display="Dynamic"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="cvpass" runat="server" ErrorMessage="Password does not match" ControlToValidate="txtconfirm" ControlToCompare="txtnewpass" Operator="Equal"
                                                    ValidationGroup="passwordgroup" CssClass="MasterValidationCSS" Display="Dynamic"></asp:CompareValidator>
                                                <br />
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                            <asp:Button ID="btnresetpass" runat="server" OnClientClick="if (!Page_ClientValidate('passwordgroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                                UseSubmitBehavior="false" class="btn btn-sm btn-primary" ValidationGroup="passwordgroup" Text="Save" TabIndex="3"></asp:Button>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>

                            <div style="clear: both"></div>
                        </div>
                    </div>
                </div>

                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <div class="pull-right">
                        </div>
                        <h4 class="widget-content-light">
                            <strong>Contact</strong> Information
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                            <div class="col-md-6">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-password">Email Id<span class="text-danger"> *</span></label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtemail" runat="server" placeholder="Enter Email Id" data-toggle="tooltip" title="Enter Email Id"
                                            CssClass="form-control" TabIndex="8"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reemail" runat="server" ControlToValidate="txtemail" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter email id" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="regemail" runat="server" ValidationGroup="MasterGroup" ErrorMessage="Please enter valid email id"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:Label ID="lblemail" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-password">Mobile No</label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtmob" runat="server" placeholder="Enter Mobile Number" data-toggle="tooltip" title="Enter Mobile Number"
                                            CssClass="form-control" TabIndex="9"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="remob" runat="server" ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" ValidationGroup="MasterGroup"
                                            ErrorMessage="Please enter valid mobile number" ControlToValidate="txtmob" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                        <br />
                                    </div>
                                </div>
                            </div>

                            <div style="clear: both"></div>
                        </div>
                    </div>
                </div>

                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <div class="pull-right">
                        </div>
                        <h4 class="widget-content-light">
                            <strong>Address</strong> Information
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-1" for="example-hf-password">Address1 </label>
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txtaddr1" runat="server" placeholder="Enter Address" data-toggle="tooltip" title="Enter Address"
                                            CssClass="form-control" TabIndex="10"></asp:TextBox>
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-1" for="example-hf-password">Address2 </label>
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txtaddr2" runat="server" placeholder="Enter Address" data-toggle="tooltip" title="Enter Address"
                                            CssClass="form-control" TabIndex="11"></asp:TextBox>
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-password">City </label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtcity" runat="server" placeholder="Enter City" data-toggle="tooltip" title="Enter City"
                                            CssClass="form-control" TabIndex="12"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-password">State </label>
                                    <div class="col-md-10">
                                        <asp:DropDownList ID="ddlstate" runat="server" data-toggle="tooltip" title="State" CssClass="select-chosen" TabIndex="13"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-password">Country </label>
                                    <div class="col-md-10">
                                        <asp:DropDownList ID="ddlcountry" runat="server" data-toggle="tooltip" title="Country" CssClass="select-chosen" AutoPostBack="true" TabIndex="14"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="">
                                    <label class="col-md-3 control-label" for="example-hf-password">Pin code </label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtpincode" runat="server" placeholder="Enter Pin code" data-toggle="tooltip" title="Enter Pin code"
                                            CssClass="form-control" TabIndex="15"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                            ValidationExpression="[0-9 ]+" CssClass="MasterValidationCSS" ValidationGroup="MasterGroup"
                                            ErrorMessage="Please enter valid pin code" ControlToValidate="txtpincode" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>

                            <div style="clear: both"></div>
                        </div>
                    </div>
                </div>

                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <div class="pull-right">
                        </div>
                        <h4 class="widget-content-light">
                            <strong>Other</strong> Information
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                            <div class="col-md-6">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-password">Employee ID</label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtempid" runat="server" placeholder="Enter Employee ID" data-toggle="tooltip" title="Enter Employee ID"
                                            CssClass="form-control" TabIndex="16"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-password">User Group </label>
                                    <div class="col-md-10">
                                        <asp:DropDownList ID="ddlusertype" runat="server" data-toggle="tooltip" title="User Group" CssClass="form-control" TabIndex="17" Height="30"></asp:DropDownList>

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-password">Date of Join </label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtdoj" runat="server" placeholder="Enter Date of Birth" data-toggle="tooltip" title="Enter Date of Birth"
                                            CssClass="form-control" TextMode="Date" TabIndex="18"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-password">Region </label>
                                    <div class="col-md-10">
                                        <asp:DropDownList ID="ddlregion" runat="server" data-toggle="tooltip" title="User Type" CssClass="form-control" TabIndex="19" Height="30"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <br />

                            <div class="col-md-4" runat="server" visible="false">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Report To </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtreportto" runat="server" placeholder="" data-toggle="tooltip" title="" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>


                            <%--<div id="divdate" runat="server" visible="false">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="example-nf-email">Created Date</label>
                                        <asp:TextBox ID="txtcreatedate" runat="server" ReadOnly="true" placeholder="Created Date" data-toggle="tooltip" title="Created Date"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="example-nf-email">Created Name</label>
                                        <asp:TextBox ID="txtcreatedname" runat="server" placeholder="Modified Date" ReadOnly="true" data-toggle="tooltip" title="Modified Date"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="example-nf-email">Modified Date</label>
                                        <asp:TextBox ID="txtmodifieddate" runat="server" placeholder="Modified Date" ReadOnly="true" data-toggle="tooltip" title="Modified Date"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="example-nf-email">Modified Name</label>
                                        <asp:TextBox ID="txtmodifiedname" runat="server" placeholder="Modified Date" ReadOnly="true" data-toggle="tooltip" title="Modified Date"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>--%>
                            <div style="clear: both"></div>
                        </div>
                    </div>
                </div>

                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <div class="pull-right">
                        </div>
                        <h4 class="widget-content-light">
                            <strong>Email</strong> Configuration
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>

                            <div class="col-md-6" runat="server">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-password">Server Name  </label>
                                    <div class="col-md-10">
                                        <asp:DropDownList ID="ddlservername" runat="server" data-toggle="tooltip" CssClass="form-control" TabIndex="20">
                                            <asp:ListItem Value="smtp.gmail.com">Gmail</asp:ListItem>
                                            <asp:ListItem Value="smtp-mail.outlook.com">Outlook</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>


                            <div class="col-md-6" runat="server">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-password">Server Port  </label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtport" runat="server" placeholder="" data-toggle="tooltip" title="" TabIndex="21" Text="587"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6" runat="server">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-password">EmailPassword</label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtemailpassword" runat="server" placeholder="" data-toggle="tooltip" title="" TextMode="Password" TabIndex="22"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6" runat="server">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-password">SSL  </label>
                                    <div class="col-md-10">
                                        <asp:CheckBox ID="chkSSL" runat="server" TabIndex="23" Checked="true" />
                                    </div>
                                </div>
                            </div>


                            <div style="clear: both"></div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" TabIndex="24" />
                    <asp:HyperLink ID="hfcancel" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/User.aspx" class="btn btn-alt btn-sm btn-danger" TabIndex="25" />
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

