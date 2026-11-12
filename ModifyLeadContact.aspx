<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ModifyLeadContact.aspx.vb" Inherits="ModifyLeadContact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script type="text/javascript">
        function AtLeastOneContact_ClientValidate(sender, args) {
            var txt1 = document.getElementById("<%= txtemail.ClientID%>");
            var txt2 = document.getElementById("<%= txtmob.ClientID%>");
            var txt3 = document.getElementById("<%= txtofficeno.ClientID%>");
            args.IsValid = (txt1.value != "") || (txt2.value != "") || (txt3.value != "");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <i class="gi gi-parents" style="margin: -8px"></i>
                        <asp:Label ID="lbltitle1" runat="server" ></asp:Label><br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="Lead.aspx">Lead</a></li>
                <li><asp:Label ID="lbltitle2" runat="server" ></asp:Label></li>

            </ul>
            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">

                <div class="pull-right">
                    <%-- btn-group removed by mandar --%>
                    <div class="" style="">
                        <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroup" OnClick="btnadd_Click" />
                        <asp:LinkButton ID="HyperLink1" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/Lead.aspx" class="btn btn-alt btn-danger" OnClick="hfcancel_Click" />
                        <%--<button class="btn btn-sm btn-primary"><i class="fa fa-floppy-o"></i>&nbsp;Save</button>

                        <button class="btn btn-sm btn-primary"><i class="fa fa-times"></i>&nbsp;Cancel</button>--%>
                    </div>
                </div>

            </div>

            <div class="col-md-12">
                <div class="widget">
                    <div class="widget-extra themed-background-dark">

                        <h4 class="widget-content-light">
                            <strong>Contact</strong> Information
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Title<span class="text-danger"> </span></label>
                                    <div class="col-md-8">
                                        <asp:HiddenField ID ="hfcontactid" runat="server" />
                                        <asp:HiddenField ID ="hfleadid" runat="server" />
                                        <asp:DropDownList ID="ddltitle" runat="server" name="Title" class="form-control">
                                            <asp:ListItem Text="Mr." Value="Mr."></asp:ListItem>
                                            <asp:ListItem Text="Mrs." Value="Mrs."></asp:ListItem>
                                            <asp:ListItem Text="Ms." Value="Ms."></asp:ListItem>
                                            <asp:ListItem Text="Chef." Value="Chef."></asp:ListItem>
                                            <asp:ListItem Text="Dr." Value="Dr."></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Name <span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtname" runat="server" placeholder="Enter Name" data-toggle="tooltip" title="Enter Name"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="refirstname" runat="server" ControlToValidate="txtname" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Designation</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddldesignation" runat="server" name="example-chosen" class="select-chosen"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="redesig" runat="server" ControlToValidate="ddldesignation" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select designation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <br />
                                    </div>
                                </div>
                            </div>                            
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Email Id</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtemail" runat="server" placeholder="Enter Email Id" data-toggle="tooltip" title="Enter Email Id"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="rgemailship" runat="server" ValidationGroup="MasterGroup" ErrorMessage="Please enter valid email id"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="reemailship" runat="server" ControlToValidate="txtemail" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter email id" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="At leat one contact required" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS" Display="Dynamic" OnServerValidate="AtLeastOneContact_ServerValidate"
                                            ClientValidationFunction="AtLeastOneContact_ClientValidate" ></asp:CustomValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Mobile Number</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtmob" runat="server" placeholder="Enter Mobile Number" onkeyup="this.value=this.value.replace(/[^\d\.]/g,'');" data-toggle="tooltip" title="Enter Mobile Number"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="rgmobship" runat="server" ErrorMessage="Enter valid mobile number" ControlToValidate="txtmob"
                                            ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="remobship" runat="server" ControlToValidate="txtmob" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="Enter mobile number" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Office Number</label>
                                    <div class="col-md-5">
                                        <asp:TextBox ID="txtofficeno" runat="server" placeholder="Enter Office Number" data-toggle="tooltip" title="Enter Office Number"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="rgofficeno" runat="server" ErrorMessage="Enter valid phone number" ControlToValidate="txtofficeno" ValidationGroup ="MasterGroup"
                                            ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="reoffice" runat="server" ControlToValidate="txtofficeno" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="Enter Phone number" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtextention" runat="server" placeholder="Extention" data-toggle="tooltip" title="Enter Extention"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both"></div>
							      <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Notify by<span class="text-danger"> </span></label>
                                    <div class="col-md-8">                              
                                        <asp:DropDownList ID="ddlnotifyby" runat="server" name="Title" CssClass="form-control">
                                           <asp:ListItem Text="Email" Value="Email"></asp:ListItem>   
                                            <asp:ListItem Text="Alert" Value="Alert"></asp:ListItem>
                                            <asp:ListItem Text="None" Value="None"></asp:ListItem>
                                        </asp:DropDownList>
                                           <asp:RequiredFieldValidator ID="renotifyby" runat="server" ControlToValidate="ddlnotifyby" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please Select" SetFocusOnError="true" InitialValue ="---Please Select---"></asp:RequiredFieldValidator>
                                
                                    </div>
                                </div>
                            </div>
							<div style="clear: both"></div>
                        </div>
                    </div>
                </div>
                  </div>
            <div class="col-md-12">
                <div class="pull-right">
                    
                    <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroup" />
                    <asp:LinkButton  ID="hfcancel" CausesValidation="false"  Text="Cancel" runat="server" NavigateUrl="~/Lead.aspx" class="btn btn-alt btn-danger" />
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

