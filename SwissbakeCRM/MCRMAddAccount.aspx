<%@ Page Language="VB" MasterPageFile="~/MCRMMaster.master" AutoEventWireup="false" CodeFile="MCRMAddAccount.aspx.vb" Inherits="MCRMAddAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function AtLeastOneContact_ClientValidate(sender, args) {
            var txt1 = document.getElementById("<%= txtemail.ClientID%>");
            var txt2 = document.getElementById("<%= txtmob.ClientID%>");
            var txt3 = document.getElementById("<%= txtofficeno.ClientID%>");
            args.IsValid = (txt1.value != "") || (txt2.value != "") || (txt3.value != "");
        }
    </script>
      <script>
          $(function () {
              $('.nos').keypress(function (event) {
                  //if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
                  //    event.preventDefault();
                  //}
                  debugger;

                  if ((event.which != 46 || $(this).val().indexOf('.') != -1) && $(this).val().length < 0)
                      event.preventDefault();

                  if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57))

                      event.preventDefault();
                  if (($(this).val().indexOf('.') !== -1)) {
                      if (($(this).val().substring($(this).val().indexOf('.')).length > 2))
                          event.preventDefault();
                  }
                  //var input = $(this).val();
                  //if ((input.indexOf('.') != -1) && (input.substring(input.indexOf('.')).length > 2)) {
                  //    event.preventDefault();
                  //}
              });
          });

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <i class="gi gi-parents" style="margin: -8px"></i>
                        <asp:Label ID="lbltitle1" runat="server" text="New Account"></asp:Label><br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index1.aspx">Home</a></li>
                <li><a href="<%= "MCRMAddAccount.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(0))%>">Add Account</a></li>
                <li><asp:Label ID="lbltitle2" runat="server" ></asp:Label></li>

            </ul>
            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">

            </div>

            <div class="col-md-12">
                <div class="widget">
                    <div class="widget-extra themed-background-dark">

                        <h4 class="widget-content-light abc">
                            <strong>Account</strong> Information
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                            <div class="col-md-1"></div>
                            <div class="col-md-5">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-email">Account Name<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtAccountname" runat="server" placeholder="Enter Account Name" data-toggle="tooltip" title="Enter Account Name"
                                            CssClass="form-control" TabIndex="1"></asp:TextBox>
										<asp:Label ID="lblname" runat="server" style="color:red;"></asp:Label>
                                        <asp:RequiredFieldValidator ID="reAccountname" runat="server" ControlToValidate="txtAccountname" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="This is Required" Display="Dynamic" SetFocusOnError="true" ></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                             
                             <div class="col-md-5">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Contact Person <span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtContPerson" runat="server" placeholder="Enter Name" data-toggle="tooltip" title="Enter Name"
                                            CssClass="form-control" TabIndex="2"></asp:TextBox>										
                                        <asp:RequiredFieldValidator ID="refirstname" runat="server" ControlToValidate="txtContPerson" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="This is Required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both"></div>
                               <div class="col-md-1"></div>
                                <div class="col-md-5">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Email Id<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtemail" runat="server" placeholder="Enter Email Id" data-toggle="tooltip" title="Enter Email Id"
                                            CssClass="form-control" TabIndex="3"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="rgemailship" runat="server" ValidationGroup="MasterGroup" ErrorMessage="Please enter valid email id as abc@xyz.com"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="reemailship" runat="server" ControlToValidate="txtemail" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="This is Required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                             
                                <div class="col-md-5">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Mobile Number<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtmob" runat="server" placeholder="Enter Mobile Number" data-toggle="tooltip" title="Enter Mobile Number"
                                            CssClass="form-control nos" TabIndex="4"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="rgmobship" runat="server" ErrorMessage="Enter valid mobile number" ControlToValidate="txtmob" ValidationGroup ="MasterGroup"
                                            ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="remobship" runat="server" ControlToValidate="txtmob" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="This is Rquired" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both"></div>
                               <div class="col-md-1"></div>
                                <div class="col-md-5">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Office Number</label>
                                    <div class="col-md-5">
                                        <asp:TextBox ID="txtofficeno" runat="server" placeholder="Enter Office Number" data-toggle="tooltip" title="Enter Office Number"
                                            CssClass="form-control nos" TabIndex="5"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="rgofficeno" runat="server" ErrorMessage="Enter valid phone number" ControlToValidate="txtofficeno" ValidationGroup ="MasterGroup"
                                            ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                  </div>
                                   
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtextention" runat="server" placeholder="Extention" data-toggle="tooltip" title="Enter Extention"
                                            CssClass="form-control" TabIndex="6"></asp:TextBox>
                                    </div>                                    
                                </div>
                            </div>
                             
                            <div class="col-md-5">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">State<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlState" runat="server" name="example-chosen" class="select-chosen"  TabIndex="7"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="restatebill" runat="server" InitialValue="0" ControlToValidate="ddlState" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="This is Rquired" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both"><br /></div>
                               <div class="col-md-1"></div>
                            <div class="col-md-5">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-email">City<span class="text-danger"> </span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtCity" runat="server" placeholder="Enter City" data-toggle="tooltip" title="Enter City"  TabIndex="8"
                                            CssClass="form-control"></asp:TextBox><br />
                                    </div>
                                </div>
                            </div>
                          
                            <div class="col-md-5">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Pincode<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtPin" runat="server" placeholder="Enter Pincode" data-toggle="tooltip" title="Enter Pincode"  TabIndex="9"
                                            CssClass="form-control" MaxLength="6" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="repicodebill" runat="server" ControlToValidate="txtPin" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="This is Rquired" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both"></div>
                               <div class="col-md-1"></div>
                            <div class="col-md-5">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-email">Address<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtAddress" runat="server" placeholder="Enter Address" data-toggle="tooltip" title="Enter Address"  TabIndex="10"
                                            CssClass="form-control" TextMode="MultiLine" MaxLength="300"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="readdressbill" runat="server" ControlToValidate="txtAddress" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="This is Rquired" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both"></div>
                            <div class="col-md-12">
                                <User:AssignControl ID="assigncontrol" runat="server" />
                            </div>
                            <div style="clear: both"></div>
                             <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                                  <div class="pull-right">
                                    <asp:Button Text="Save" runat="server" ID="btnsave"  OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                          UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" TabIndex="11"/>
                                   <asp:LinkButton  ID="hfcancel" CausesValidation="false"  Text="Cancel" runat="server" NavigateUrl="index1.aspx" class="btn btn-alt btn-sm btn-danger" TabIndex="12" OnClick="hfcancel_Click"/>
                                      <br />
                                  </div>
                              </div>
                            <div style="clear: both"></div>
                        </div>
                    </div>
                </div>

            </div>
           
        </div>
    </div>
</asp:Content>