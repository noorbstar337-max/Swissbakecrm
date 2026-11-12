<%@ Page Language="VB" MasterPageFile="~/MCRMMaster.master" AutoEventWireup="false" CodeFile="MCRMAddLead.aspx.vb" Inherits="MCRMAddLead" %>

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
                        <asp:Label ID="lbltitle1" runat="server" text="New Lead"></asp:Label><br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index1.aspx">Home</a></li>
                <li><a href="Lead.aspx">Add Lead</a></li>
                <li><asp:Label ID="lbltitle2" runat="server" ></asp:Label></li>

            </ul>
            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">

                <div class="pull-right">
                    <%-- btn-group removed by mandar --%>
                    <div class="" style="">
                    <%--    <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroup" OnClick="btnadd_Click" />--%>
                        <%--<asp:LinkButton ID="HyperLink1" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/Lead.aspx" class="btn btn-alt btn-danger" OnClick="hfcancel_Click" />--%>
                        <%--<button class="btn btn-sm btn-primary"><i class="fa fa-floppy-o"></i>&nbsp;Save</button>

                        <button class="btn btn-sm btn-primary"><i class="fa fa-times"></i>&nbsp;Cancel</button>--%>
                    </div>
                </div>

            </div>

            <div class="col-md-12">
                <div class="widget">
                    <div class="widget-extra themed-background-dark">

                        <h4 class="widget-content-light abc">
                            <strong>Lead</strong> Information
                           <%--  <small>
                                <span class="pull-right" id="modifyspan" runat="server" >
                            By&nbsp;<a style="text-decoration:none;"><asp:Label ID="lblmodifiedname" runat="server" Font-Bold="true"></asp:Label></a>&nbsp;on&nbsp;<a style="text-decoration:none;"><asp:Label ID="lblmodifieddate" Font-Bold="true" runat="server" Font-Italic="true"></asp:Label></a>
                            </span>
                            </small>--%>
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
                                    <label class="col-md-4 control-label" for="example-hf-email">Lead Name<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtleadname" runat="server" placeholder="Enter Lead Name" data-toggle="tooltip" title="Enter Lead Name"
                                            CssClass="form-control" TabIndex="1"></asp:TextBox>
										<asp:Label ID="lblname" runat="server" style="color:red;"></asp:Label>
                                        <asp:RequiredFieldValidator ID="releadname" runat="server" ControlToValidate="txtleadname" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="This is Required" Display="Dynamic" SetFocusOnError="true" ></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Date<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtleaddate" runat="server" data-toggle="tooltip" title="Enter Lead Date"
                                           CssClass="form-control " TextMode="Date" placeholder="dd/mm/yy" TabIndex="2" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="releaddate" runat="server" ControlToValidate="txtleaddate" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="This is Required" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                             <div style="clear: both"></div>
                            <br />
                               <div class="col-md-1"></div>
                             <div class="col-md-5">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Contact Person <span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtContPerson" runat="server" placeholder="Enter Name" data-toggle="tooltip" title="Enter Name"
                                            CssClass="form-control" TabIndex="3"></asp:TextBox>										
                                        <asp:RequiredFieldValidator ID="refirstname" runat="server" ControlToValidate="txtContPerson" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="This is Required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                                   <div class="col-md-5">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Email Id</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtemail" runat="server" placeholder="Enter Email Id" data-toggle="tooltip" title="Enter Email Id"
                                            CssClass="form-control" TabIndex="4"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="rgemailship" runat="server" ValidationGroup="MasterGroup" ErrorMessage="Please enter valid email id as abc@xyz.com"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                      <%--  <asp:RequiredFieldValidator ID="reemailship" runat="server" ControlToValidate="txtemail" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="This is Required" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                       <%-- <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="At leat one contact required" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS" Display="Dynamic" OnServerValidate="AtLeastOneContact_ServerValidate"
                                            ClientValidationFunction="AtLeastOneContact_ClientValidate" ></asp:CustomValidator>--%>
                                    </div>
                                </div>
                            </div>
                             <div style="clear: both"></div>
                               <div class="col-md-1"></div>
                                <div class="col-md-5">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Mobile Number</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtmob" runat="server" placeholder="Enter Mobile Number" data-toggle="tooltip" title="Enter Mobile Number"
                                            CssClass="form-control nos" TabIndex="5"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="rgmobship" runat="server" ErrorMessage="Enter valid mobile number" ControlToValidate="txtmob" ValidationGroup ="MasterGroup"
                                            ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                       <%-- <asp:RequiredFieldValidator ID="remobship" runat="server" ControlToValidate="txtmob" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="This is Rquired" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                        
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Office Number</label>
                                    <div class="col-md-5">
                                        <asp:TextBox ID="txtofficeno" runat="server" placeholder="Enter Office Number" data-toggle="tooltip" title="Enter Office Number"
                                            CssClass="form-control nos" TabIndex="6"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="rgofficeno" runat="server" ErrorMessage="Enter valid phone number" ControlToValidate="txtofficeno" ValidationGroup ="MasterGroup"
                                            ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                      <%--  <asp:RequiredFieldValidator ID="reoffice" runat="server" ControlToValidate="txtofficeno" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="This is Rquired" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                          <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Atleat one contact required" ValidationGroup="MasterGroup"
                                                CssClass="MasterValidationCSS" Display="Dynamic" OnServerValidate="AtLeastOneContact_ServerValidate"
                                                ClientValidationFunction="AtLeastOneContact_ClientValidate" SetFocusOnError="true"></asp:CustomValidator>
                                    </div>
                                   
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtextention" runat="server" placeholder="Extention" data-toggle="tooltip" title="Enter Extention"
                                            CssClass="form-control" TabIndex="7"></asp:TextBox>
                                    </div>                                    
                                </div>
                            </div>
                             <div style="clear: both">
                                 <br />
                             </div>
                            <div class="col-md-1"></div>
                               <div class="col-md-5">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Notify by<span class="text-danger"> </span></label>
                                    <div class="col-md-8">                              
                                        <asp:DropDownList ID="ddlnotifyby" runat="server" name="Title" CssClass="form-control" TabIndex="8">
                                            <asp:ListItem Text="Email" Value="Email"></asp:ListItem>
                                            <asp:ListItem Text="Alert" Value="None"></asp:ListItem>
                                            <asp:ListItem Text="None" Value="Alert"></asp:ListItem>                                          
                                        </asp:DropDownList>
                                           <asp:RequiredFieldValidator ID="renotifyby" runat="server" ControlToValidate="ddlnotifyby" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="This is Required" SetFocusOnError="true" ></asp:RequiredFieldValidator>
                                
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
                                  <asp:Button Text="Save" runat="server" ID="btnsave" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" TabIndex="9"/>
                                  <asp:LinkButton  ID="hfcancel" CausesValidation="false"  Text="Cancel" runat="server" NavigateUrl="index1.aspx" class="btn btn-alt btn-sm btn-danger" TabIndex="10" OnClick="hfcancel_Click"/>
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