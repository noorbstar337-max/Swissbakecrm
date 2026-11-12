<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="SupportAddLead.aspx.vb" Inherits="SupportAddLead" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function AtLeastOneContact_ClientValidate(sender, args) {
            var txt1 = document.getElementById("<%= txtemail.ClientID%>");
            var txt2 = document.getElementById("<%= txtmob.ClientID%>");
            var txt3 = document.getElementById("<%= txtofficeno.ClientID%>");
            args.IsValid = (txt1.value != "") || (txt2.value != "") || (txt3.value != "");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <contenttemplate>
            <div class="content-header">
                <div class="header-section">
                    <h1>
                        <i class="gi gi-parents" style="margin: -8px"></i>Add Lead<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li>Add Lead</li>
            </ul>
            <div class="col-md-12">
                <div class="widget">
                    <div class="widget-extra themed-background-dark">

                        <h4 class="widget-content-light abc">
                            <strong>Lead</strong> Details
                             <%--<small>
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
                              <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                       <div class="col-md-4">
                                        <div class="">
                                            <label for="example-nf-email">Lead Name <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtleadname" runat="server" AutoPostBack="true" placeholder="Enter Lead Name" data-toggle="tooltip" title="Enter Lead Name"
                                                CssClass="form-control" ></asp:TextBox>
											<asp:Label ID="lblname" runat="server" style="color:red;" Visible="false" ></asp:Label>
                                            <asp:RequiredFieldValidator ID="releadname" runat="server" ControlToValidate="txtleadname" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="This is required" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                        </div>
                                             </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="txtleadname" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                      <div class="col-md-4">
                                <div class="">
                                            <label for="example-nf-email">Lead Date <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtleaddate" runat="server" placeholder="dd/mm/yy" data-toggle="tooltip" title="Enter Lead Date"
                                                CssClass="form-control " data-date-format="dd/mm/yy" TextMode="Date" ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="releaddate" runat="server" ControlToValidate="txtleaddate" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="This is required" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                        </div>

                                         <div class="col-md-4">
                                <div class="">
                                            <label for="example-nf-email">Contact Person <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtname" runat="server" placeholder="Enter Name" data-toggle="tooltip" title="Enter Name"
                                                CssClass="form-control" ></asp:TextBox><asp:RequiredFieldValidator ID="refirstname" runat="server" ControlToValidate="txtname" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                    ErrorMessage="This is required" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                        </div>
                            <div style="clear: both"></div>
                    <br />
                             <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                         <div class="col-md-4">
                                    <div class="">
                                            <label for="example-nf-email">Email <span class="text-danger">*</span></label>
                                           <%-- <asp:TextBox ID="txtemail" runat="server" AutoPostBack="true" placeholder="Enter Email Id" data-toggle="tooltip" title="Enter Email Id"
                                                CssClass="form-control" "></asp:TextBox>--%>
                                            <asp:TextBox ID="txtemail" runat="server" AutoPostBack="true" placeholder="Enter Email Id" data-toggle="tooltip" title="Enter Email Id"
                                                CssClass="form-control" ></asp:TextBox>
                                            <asp:Label ID="lblErrEmail" runat="server" style="color:red;" Visible="false" ></asp:Label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtemail" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="This is required" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="rgemailship" runat="server" ValidationGroup="MasterGroup" ErrorMessage="Please enter valid email id"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" CssClass="MasterValidationCSS" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                        </div>
                                        </div>
                                             </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="txtemail" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                     <div class="col-md-4">
                                        <div class="">
                                            <label for="example-nf-email">Mobile Number <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtmob" runat="server" MaxLength="10" onkeyup="this.value=this.value.replace(/[^\d\.]/g,''); copyMobileVal();" placeholder="Enter Mobile Number" data-toggle="tooltip" title="Enter Mobile Number"
                                        CssClass="form-control"></asp:TextBox>
                                           <%-- <asp:TextBox ID="txtmob" runat="server" placeholder="Enter Mobile Number" data-toggle="tooltip" title="Enter Mobile Number" MaxLength="10"
                                                CssClass="form-control" ></asp:TextBox>--%>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtmob" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="This is required" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="rgmobship" runat="server" ErrorMessage="Please enter valid mobile number" ControlToValidate="txtmob"
                                                ValidationExpression="^[()0-9 +-]{10,10}$" CssClass="MasterValidationCSS" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>

                                        </div>
                                        </div>
                                        
                                       <div class="col-md-4">
                                <div class="">
											<label for="example-nf-email">Assign To <span class="text-danger">*</span></label>
											<asp:DropDownList ID="ddlAssignTo" runat="server" name="Title" CssClass="form-control select-chosen" >
                                                   																			
											</asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlAssignTo" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
												ErrorMessage="This is required" Display="Dynamic" SetFocusOnError="true" InitialValue="-1"></asp:RequiredFieldValidator>
										</div>
										</div>
                             <div style="clear: both"></div>
                    <br />
                            <div class="col-md-4">
                                        <div class="">
                                            <label  >Office Number <span class="text-danger"></span></label><br />
                                            <asp:TextBox ID="txtofficeno" runat="server" placeholder="Enter Office Number" data-toggle="tooltip" title="Enter Office Number"
                                                Class="form-control col-md-8" ></asp:TextBox>
                                            <asp:TextBox ID="txtextention" runat="server" placeholder="Extention" data-toggle="tooltip" title="Enter Extention"
                                                CssClass="form-control" class="col-md-4" ></asp:TextBox>
                                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="At leat one contact required" ValidationGroup="MasterGroup"
                                                CssClass="MasterValidationCSS" Display="Dynamic" OnServerValidate="AtLeastOneContact_ServerValidate"
                                                ClientValidationFunction="AtLeastOneContact_ClientValidate" SetFocusOnError="true"></asp:CustomValidator>
                                        </div>
                                        </div>
                    <div class="pull-right" style="margin-right:20px;">
                        <asp:Button Text="Save" runat="server" ID="btnsave" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroup" />
                    </div>
                             <div style="clear: both"></div>
                    <br />
                 </div>
                 </div>
                 </div>
                 </div>
        
        </contenttemplate>
</asp:Content>

