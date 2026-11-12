<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" CodeFile="ViewLead.aspx.vb" Inherits="ViewLead" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function checkdelete() {
            ; debugger
            if (confirm('Are you Sure want to convert this lead to junk lead?')) {
                document.getElementById('<%=deletestatus.ClientID %>').value = "yes";
                return true
            }
            else {
                document.getElementById('<%=deletestatus.ClientID %>').value = "no";

                return true
            }
        }
        function checkdeleteproduct() {
            ; debugger
            if (confirm('Sure, you want to Delete?')) {
                document.getElementById('<%=deletestatus.ClientID %>').value = "yes";
                return true
            }
            else {
                document.getElementById('<%=deletestatus.ClientID %>').value = "no";

                return true
            }
        }
        function checkconvertprospect() {
            ; debugger
            if (confirm('Are you Sure want to convert this lead to prospect?')) {
                document.getElementById('<%=deletestatus.ClientID %>').value = "yes";
                return true
            }
            else {
                document.getElementById('<%=deletestatus.ClientID %>').value = "no";
                return true
            }
        }
    </script>
    <script type="text/javascript">
        function CheckOtherIsCheckedByGVID(spanChk) {

            var IsChecked = spanChk.checked;
            if (IsChecked) {
                //spanChk.parentElement.parentElement.style.backgroundColor = '#EF998A';
                //spanChk.parentElement.parentElement.style.color = 'rgb(19, 18, 18)';
                //spanChk.parentElement.parentElement.style.border = '1px solid';

            }
            var CurrentRdbID = spanChk.id;
            var Chk = spanChk;
            Parent = document.getElementById("<%=GridView1.ClientID%>");
            var items = Parent.getElementsByTagName('input');
            for (i = 0; i < items.length; i++) {
                if (items[i].id != CurrentRdbID && items[i].type == "radio") {
                    if (items[i].checked) {
                        items[i].checked = false;
                        items[i].parentElement.parentElement.style.backgroundColor = 'white'

                        items[i].parentElement.parentElement.style.color = 'black';
                    }
                }
            }
        }
    </script>
    <script type="text/javascript">
        function AtLeastOneContact_ClientValidate(sender, args) {
            var txt1 = document.getElementById("<%= txtemail.ClientID%>");
            var txt2 = document.getElementById("<%= txtmob.ClientID%>");
            var txt3 = document.getElementById("<%= txtofficeno.ClientID%>");
            args.IsValid = (txt1.value != "") || (txt2.value != "") || (txt3.value != "");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField runat="server" ID="hfLeadName" />
    <asp:HiddenField runat="server" ID="hfLeadEmail" />
    <div class="row">
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <i class="gi gi-table" style="margin: -8px"></i>Lead Detail<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="Lead.aspx">Lead</a></li>
                <li>Lead Detail</li>

            </ul>
            <div class="col-md-8">
                <!-- Advanced Active Theme Color Widget Alternative -->
                <div class="widget" style="min-height: 331px">
                    <div class="widget-advanced widget-advanced-alt">
                        <!-- Widget Header -->
                        <div class="widget-header text-center themed-background-dark">
                            <%-- <div class="widget-options-left">
                                <a id="aedit" runat="server" class="btn btn-xs btn-primary" data-toggle="tooltip" title="" data-original-title="Edit"><i class="fa fa-pencil"></i></a>
                            </div>--%>
                            <%-- <div class="widget-options">
                                <asp:LinkButton ID="lkdelete" runat="server" class="btn btn-xs btn-primary" data-toggle="tooltip" title="" data-original-title="Settings"><i class="fa fa-times"></i></asp:LinkButton>
                            </div>--%>

                            <h4 class="widget-content-light">
                                <a href="page_ready_user_profile.html">
                                    <asp:Literal ID="ltcontactname" runat="server"></asp:Literal></a><br>
                                <small>
                                    <asp:Literal ID="ltcompanyname" runat="server"></asp:Literal></small>
                            </h4>
                            <div class="col-md-12">
                                <div class="block-section">

                                    <a id="aedit" runat="server" class="btn btn-alt btn-sm btn-primary">Edit</a>
                                    <asp:LinkButton ID="lkdelete" runat="server" class="btn btn-alt btn-sm btn-danger" OnClientClick="checkdelete();" Visible="false">Delete</asp:LinkButton>
                                    <asp:LinkButton ID="lkconvacount" runat="server" class="btn btn-alt btn-sm btn-danger">Junk</asp:LinkButton>
                                    <asp:LinkButton ID="lkconvprospect" runat="server" class="btn btn-alt btn-sm btn-warning">Convert To Prospect</asp:LinkButton>
                                    <%--<button type="button" class="btn btn-alt btn-sm btn-warning">Warning</button>
                                        <button type="button" class="btn btn-alt btn-sm btn-danger">Danger</button>--%>
                                </div>

                            </div>
                        </div>
                        <!-- END Widget Header -->

                        <!-- Widget Main -->
                        <div class="widget-main">
                            <div class="list-group remove-margin">
                                <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Repeater ID="rpowner" runat="server">
                                            <ItemTemplate>
                                                <%#Eval("U_FirstName")%>
                                            </ItemTemplate>
                                            <SeparatorTemplate>
                                                ,
                                            </SeparatorTemplate>
                                        </asp:Repeater>
                                    </strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-tag fa-fw"></i>&nbsp;Lead Assign to</h5>
                                </a>
                                <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltmobile" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-mobile fa-fw"></i>&nbsp;Mobile</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                                <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltphone" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-phone fa-fw"></i>&nbsp;Phone</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                                <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltleaddate" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-envelope-o fa-fw"></i>&nbsp;EmailID</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                                <%--<a href="javascript:void(0)" class="list-group-item" style="padding-bottom: 26px;">
                                   <span style="  width: 100px; display: table; float: left;"> <h5 class="list-group-item-heading remove-margin"><i class="fa fa-envelope-o fa-fw"></i>&nbsp;EmailID</h5></span>
                                 <%--   <p class="list-group-item-text"></p>--
                                     <span class="pull-right"><strong>
                                        <asp:Literal ID="ltleaddate" runat="server"></asp:Literal></strong></span>
                                </a>--%>
                                <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="lbladdress" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-home fa-fw"></i>&nbsp;Address</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                            </div>
                        </div>
                        <!-- END Widget Main -->
                    </div>
                </div>
                <!-- END Advanced Active Theme Color Widget Alternative -->
            </div>
            <asp:UpdatePanel ID="upquickaction" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="col-sm-6 col-md-4">
                        <!-- Widget -->

                        <div class="widget">
                            <div class="widget-simple">
                                <a class="widget-icon pull-left animation-fadeIn themed-background">
                                    <i class="hi hi-tasks"></i>
                                </a>
                                <h4 class="widget-content text-right animation-hatch">
                                    <a href="javascript:void(0)"><strong>
                                        <asp:Literal ID="ltcounttask" runat="server"></asp:Literal></strong> Task</a>
                                    <small>
                                        <asp:LinkButton ID="lkquicktask" CssClass="btn btn-alt btn-xs btn-primary" runat="server">Add New Task</asp:LinkButton></small>
                                </h4>
                            </div>
                        </div>

                        <!-- END Widget -->
                    </div>
                    <div class="col-sm-6 col-md-4">
                        <!-- Widget -->
                        <div class="widget">
                            <div class="widget-simple">
                                <a class="widget-icon pull-left animation-fadeIn themed-background-default">
                                    <i class="hi hi-bullhorn"></i>
                                </a>
                                <h4 class="widget-content text-right animation-hatch">
                                    <a href="javascript:void(0)" style="color: #3498db;"><strong>
                                        <asp:Literal ID="ltcountevent" runat="server"></asp:Literal></strong> Sampling/Demo</a>
                                    <small>
                                        <asp:LinkButton ID="lkquickevent" CssClass="btn btn-alt btn-xs btn-info" runat="server">Add New Sampling/Demo</asp:LinkButton></small>
                                </h4>
                            </div>
                        </div>
                        <!-- END Widget -->
                    </div>
                    <div class="col-sm-6 col-md-4">
                        <!-- Widget -->
                        <div class="widget">
                            <div class="widget-simple">
                                <a href="javascript:void(0)" class="widget-icon pull-left animation-fadeIn themed-background-fire">
                                    <i class="hi hi-phone_alt"></i>
                                </a>
                                <h4 class="widget-content text-right animation-hatch">
                                    <a href="javascript:void(0)" style="color: #e74c3c"><strong>
                                        <asp:Literal ID="ltcountcall" runat="server"></asp:Literal></strong> Phone/Email</a>
                                    <small>
                                        <asp:LinkButton ID="lkquickcall" CssClass="btn btn-alt btn-xs btn-danger" runat="server">Add New Phone/Email</asp:LinkButton></small>
                                </h4>
                            </div>
                        </div>
                        <!-- END Widget -->
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="upreason" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:HiddenField ID="deletestatus" runat="server" />
                    <asp:LinkButton ID="lkopendemo" runat="server"></asp:LinkButton>
                    <asp:ModalPopupExtender ID="mpclose" runat="server" PopupControlID="Panel1" TargetControlID="lkopendemo"
                        CancelControlID="lkclose">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="Panel1" runat="server" Style="display: none">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <asp:LinkButton ID="lkclose" class="close" runat="server">&times;</asp:LinkButton>
                                    <h5 class="modal-title">
                                        <asp:Literal ID="ltreason" runat="server"></asp:Literal></h5>
                                </div>
                                <div class="modal-body">
                                    <div class="form-group">
                                        <label for="example-nf-email">Reason </label>
                                        <asp:TextBox ID="txtremark" runat="server" placeholder="Enter Reason" TabIndex="1" TextMode="MultiLine" Rows="2" Columns="2" data-toggle="tooltip" title="Enter Reason"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ControlToValidate="txtremark" ValidationGroup="ResonGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please Enter Reason" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btncloseyes" TabIndex="2" runat="server" ValidationGroup="ResonGroup" class="btn btn-alt btn-primary" Text="Yes" UseSubmitBehavior="false" OnClientClick="if (!Page_ClientValidate('ResonGroup')){ return false; } this.disabled = true; this.value = 'Converting...';"></asp:Button>
                                    <asp:Button ID="btclosenno" TabIndex="3" runat="server" class="btn btn-alt btn-danger" Text="No"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="lkconvprospect" />
                    <asp:AsyncPostBackTrigger ControlID="lkconvacount" />
                    <asp:AsyncPostBackTrigger ControlID="btncloseyes" />
                </Triggers>
            </asp:UpdatePanel>

            <div class="col-md-12">
                <div id="faq12" class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq12" href="#faq12_q12">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="lblcontact" Text="Contact" runat="server"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </a></h4>
                        </div>
                        <div id="faq12_q12" class="panel-collapse collapse" style="height: 0px;">
                            <div class="panel-body">
                                <asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlcontactPopup" TargetControlID="btnShow"
                                    CancelControlID="btnNo">
                                </asp:ModalPopupExtender>
                                <asp:Panel ID="pnlcontactPopup" runat="server" Style="display: none" DefaultButton="btnsave">
                                    <div class="modal-dialog modal-sm">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                                                <h3 class="modal-title">Add Contact</h3>
                                            </div>
                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="modal-body">
                                                        <div class="form-group">
                                                            <%--<span class="text-danger">--%>
                                                                <label for="example-nf-email">Contact Person </label>
                                                            <%--</span>--%>
                                                            <asp:TextBox ID="txtname" runat="server" placeholder="Enter Name" data-toggle="tooltip" title="Enter Name"
                                                                CssClass="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="refirstname" Display="Dynamic" runat="server" ControlToValidate="txtname" ValidationGroup="ContactGroup" CssClass="MasterValidationCSS"
                                                                ErrorMessage="Please enter name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                            <ContentTemplate>
                                                                <div class="form-group">
                                                                    <label for="example-nf-email">Email </label>
                                                                    <asp:TextBox ID="txtemail" runat="server" placeholder="Enter Email Id" data-toggle="tooltip" title="Enter Email Id" onkeyup="this.value=this.value.replace(/ /g, '');"
                                                                        CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                                                                    <asp:Label ID="lblemail" runat="server" Style="color: red;" Visible="false"></asp:Label>
                                                                    <asp:RegularExpressionValidator ID="rgemailship" runat="server" ValidationGroup="ContactGroup" ErrorMessage="Please enter valid email id"
                                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>

                                                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="At leat one contact required" ValidationGroup="ContactGroup" CssClass="MasterValidationCSS" Display="Dynamic" OnServerValidate="AtLeastOneContact_ServerValidate"
                                                                        ClientValidationFunction="AtLeastOneContact_ClientValidate"></asp:CustomValidator>
                                                                </div>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <div class="form-group">
                                                            <label for="example-nf-email">Mobile </label>
                                                            <asp:TextBox ID="txtmob" runat="server" placeholder="Enter Mobile Number" onkeyup="this.value=this.value.replace(/[^\d]/g,'');" MaxLength="10" data-toggle="tooltip" title="Enter Mobile Number"
                                                                CssClass="form-control"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="rgmobship" runat="server" ErrorMessage="Please enter valid mobile number" ControlToValidate="txtmob"
                                                                ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="example-nf-email">Phone </label>
                                                            <asp:TextBox ID="txtofficeno" runat="server" placeholder="Enter Office Number" onkeyup="this.value=this.value.replace(/[^\d]/g,'');" MaxLength="11" data-toggle="tooltip" title="Enter Office Number"
                                                                CssClass="form-control"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="rgofficeno" runat="server" ErrorMessage="invalid number" ControlToValidate="txtofficeno"
                                                                ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" Display="Dynamic" Enabled="false"></asp:RegularExpressionValidator>
                                                            <asp:RequiredFieldValidator ID="reoffice" runat="server" Display="Dynamic" ControlToValidate="txtofficeno" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                                ErrorMessage="invalid number" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="example-nf-email">Designation</label>
                                                            <asp:DropDownList ID="ddldesignation" runat="server" name="Title" CssClass="form-control">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvdesignation" Display="Dynamic" runat="server" ControlToValidate="ddldesignation" ValidationGroup="ContactGroup" CssClass="MasterValidationCSS"
                                                                ErrorMessage="select designation" SetFocusOnError="true" InitialValue="0"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="example-nf-email">Notify by </label>
                                                            <asp:DropDownList ID="ddlnotifyby" runat="server" name="Title" CssClass="form-control">
                                                                <asp:ListItem Text="Email" Value="Email"></asp:ListItem>
                                                                <asp:ListItem Text="Alert" Value="Alert"></asp:ListItem>
                                                                <asp:ListItem Text="None" Value="None"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="renotifyby" Display="Dynamic" runat="server" ControlToValidate="ddlnotifyby" ValidationGroup="ContactGroup" CssClass="MasterValidationCSS"
                                                                ErrorMessage="Please Select" SetFocusOnError="true" InitialValue="0"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnsave" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <div class="modal-footer">
                                                <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-primary" Text="Save" ValidationGroup="ContactGroup"></asp:Button>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <div class="">
                                    <asp:LinkButton ID="btnShow" runat="server" CssClass="btn btn-alt btn-xs btn-primary">New Contact</asp:LinkButton><br />
                                    <br />
                                </div>
                                <asp:UpdatePanel ID="updocument" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView1" runat="server" ShowFooter="true" AutoGenerateColumns="True" CellPadding="0" CellSpacing="0" DataKeyNames="Id" AllowSorting="true" HeaderStyle-Font-Size="Smaller"
                                                CssClass="table table-borderless table-striped" PageSize="5" GridLines="Horizontal" BorderWidth="0px" Width="100%" Font-Size="Small" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true"
                                                AllowPaging="True">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Primary" FooterStyle-CssClass="MasterGridviewItem" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Deprt_Status" ItemStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:RadioButton ID="rbowner" runat="server" Checked='<%#Eval("Contact_Primary").ToString().Equals("True")%>' onclick="javascript:CheckOtherIsCheckedByGVID(this);" AutoPostBack="true" OnCheckedChanged="rbowner_CheckedChanged" />
                                                        </ItemTemplate>
                                                        <%-- <FooterTemplate>
                                                     <asp:HyperLink ID="lknew" NavigateUrl='<%# Page.ResolveUrl("Contact.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(0)))%>' runat="server">New</asp:HyperLink>
                                                 </FooterTemplate>--%>
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="Delete" SortExpression="Deprt_Status" ItemStyle-Width="50px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnk" Text="Delete" runat="server"
                                                        CommandName="Closing" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                                    <asp:TemplateField ItemStyle-Width="10px">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink2" runat="server">Edit</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Page.ResolveUrl("ModifyLeadContact.aspx?returnurl=y&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Id").ToString())))%>'
                                                                    data-toggle="tooltip" title="Edit" class="btn btn-Primary" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="left" BackColor="White" />
                                                <FooterStyle HorizontalAlign="left" BackColor="White" />
                                                <PagerSettings PageButtonCount="4" />
                                                <EmptyDataTemplate>
                                                    <asp:Label ID="s" runat="server" Text="No Record Found"></asp:Label><br />
                                                    <br />
                                                </EmptyDataTemplate>
                                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>

                                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                                    </Triggers>
                                </asp:UpdatePanel>

                            </div>
                        </div>
                    </div>
                </div>
            </div>




            <%--sample request start from here--%>

            <div class="col-md-12">
                <div id="faq13" class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq13" href="#faq13_q12">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="lblsamreq" Text="Sample Request" runat="server"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </a></h4>
                        </div>
                        <div id="faq13_q12" class="panel-collapse collapse" style="height: 0px;">
                            <div class="panel-body">

                                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="table-responsive">
                                            <asp:GridView ID="grdsamplereq" runat="server" ShowFooter="true" AutoGenerateColumns="False" CellPadding="0" CellSpacing="0" DataKeyNames="SampleRequest_Id" AllowSorting="true" HeaderStyle-Font-Size="Smaller"
                                                CssClass="table table-borderless table-striped" PageSize="5" GridLines="Horizontal" BorderWidth="0px" Width="100%" Font-Size="Small" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true"
                                                AllowPaging="True">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SampleRequest No">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hlSamReqNo" EnableViewState="false" NavigateUrl='<%# "ModifySampleRequest.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("SampleRequest_Id").ToString()))%>'
                                                                data-toggle="tooltip" title="View" runat="server">
                                                                <asp:Literal ID="lblSamReqNo" runat="server" Text='<%#Eval("SampleRequestNo")%>' EnableViewState="false" />
                                                            </asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:BoundField HeaderText="SampleRequest No" DataField="SampleRequestNo" />--%>
                                                    <asp:BoundField HeaderText="Request Date" DataField="Request_Date" />
                                                    <asp:BoundField HeaderText="Company Name" DataField="CompanyName" />
                                                    <asp:BoundField HeaderText="Contact Name" DataField="ContactName" />

                                                    <asp:BoundField HeaderText="Qty(kg)" DataField="Qty" />
                                                    <asp:BoundField HeaderText="Assign To" DataField="AssignTo" />
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblunit" runat="server" CssClass='<%#Security.checkSRStatus(Eval("SampleStatus"))%>' Text='<%#Eval("SampleStatus")%>' Style="padding: 1px 10px; border-radius: 5px;" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:BoundField HeaderText="Request Status" DataField="SampleStatus" />--%>
                                                    <%--<asp:BoundField HeaderText="Track Order" DataField="hreftracking" />--%>
                                                    <asp:BoundField HeaderText="AWB" DataField="SampleRequest_AWB" />
                                                    <asp:TemplateField HeaderText="Track Order">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink1" runat="server" Visible='<%# If(Eval("SampleRequest_AWB") = "", False, True)%>' NavigateUrl='<%#Eval("hreftracking").ToString()%>' Target="_blank">
                                                                <img src="images/track.png" style="width: 22px; margin-top: 4px;">
                                                            </asp:HyperLink>
                                                            <asp:Label ID="lbldirect" runat="server" Text='<%#Eval("hreftracking").ToString()%>' Font-Bold="true" Visible="false" ForeColor="#c42126"></asp:Label>
                                                            <asp:Label ID="lbldash" runat="server" Text="-" Font-Bold="true" Visible='<%# If(Eval("SampleRequest_AWB") = "", True, False)%>' ForeColor="#c42126"></asp:Label><br />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="left" BackColor="White" />
                                                <FooterStyle HorizontalAlign="left" BackColor="White" />
                                                <PagerSettings PageButtonCount="4" />
                                                <EmptyDataTemplate>
                                                    <asp:Label ID="s" runat="server" Text="No Record Found"></asp:Label><br />
                                                    <br />
                                                </EmptyDataTemplate>
                                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </div>
                                    </ContentTemplate>

                                </asp:UpdatePanel>

                            </div>
                        </div>
                    </div>
                </div>
            </div>



            <%--sample request ends from here--%>


            <div class="col-md-12">
                <div id="faq123" class="panel-group">
                    <asp:HiddenField ID="hftype" runat="server" />
                    <asp:HiddenField ID="hftypeid" runat="server" />
                    <div id="faq8561" class="panel-group">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title"><a id="aToggle" runat="server" class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq8561" href="#ContentPlaceHolder1_faq8561_q12">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                                        <ContentTemplate>
                                            <asp:Label ID="lblSample" Text="Interested Product" runat="server"></asp:Label><asp:Label ID="lblInterest" CssClass="pull-right " runat="server"></asp:Label>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="Button1" />
                                            <%--  <asp:AsyncPostBackTrigger ControlID="btnadd" />--%>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </a></h4>
                            </div>
                            <div id="faq8561_q12" runat="server" class="panel-collapse collapse" style="height: 0px;">
                                <div class="panel-body">
                                    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnlPopup" TargetControlID="btnShow"
                                        CancelControlID="btnNo">
                                    </asp:ModalPopupExtender>
                                    <asp:Panel ID="pnlPopup" runat="server" Style="display: none">
                                        <div class="modal-dialog modal-lg" style="overflow-y: scroll; position: fixed; top: 0; bottom: 0; left: 0; right: 0; overflow: auto; width: 1192px;">
                                            <div class="modal-content" style="top: 1%; overflow-x: hidden; overflow-y: auto; outline: none; margin-top: 0; overflow: visible;">
                                                <div class="modal-header">
                                                    <asp:LinkButton ID="LinkButton1" class="close" runat="server">&times;</asp:LinkButton>
                                                    <h3 class="modal-title">Add Product</h3>
                                                </div>
                                                <div class="modal-body" style="overflow: auto; height: 400px;">
                                                    <div class="table-options clearfix">
                                                        <div class="col-sm-5 col-xs-4">
                                                            <div class="dataTables_length" id="example-datatable_length">
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-4 col-xs-12">
                                                            <div id="example-datatable_filter" class="dataTables_filter">
                                                                <label>
                                                                    <div class="input-group">
                                                                        <asp:TextBox ID="txtsearch" runat="server" class="form-control" placeholder="Search" /><span class="input-group-addon">
                                                                            <i class="fa fa-search"></i></span>
                                                                    </div>
                                                                </label>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-3 col-xs-12">
                                                            <asp:Button ID="btnshowall"  runat="server" Text="Show All" CssClass="btn btn-alt btn-sm btn-info" />
                                                        </div>
                                                    </div>
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <div class="table-responsive">
                                                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Product_Id"
                                                                    CssClass="table table-striped table-vcenter table-hover" Font-Size="12px">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Select" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Product_Id">
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="ckselect" runat="server" />
                                                                                <asp:Label ID="lblproductId" runat="server" Text='<%#Eval("Product_Id")%>' Visible="false" />

                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Code" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Product_Code">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblcode" runat="server" Text='<%#Eval("Product_Code")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Product Name" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Product_Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblname" runat="server" Text='<%#Eval("Product_Name")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>



                                                                        <asp:TemplateField HeaderText="Category" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="PrdCategory_Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("PrdCategory_Name")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                    </Columns>
                                                                    <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="Right" BackColor="White" />

                                                                    <FooterStyle HorizontalAlign="Center" BackColor="White" />
                                                                    <PagerSettings PageButtonCount="4" />

                                                                    <EmptyDataTemplate>
                                                                        <asp:Label ID="s" runat="server" Text="No Record Found"></asp:Label><br />
                                                                        <br />
                                                                    </EmptyDataTemplate>
                                                                    <EmptyDataRowStyle HorizontalAlign="Center" />
                                                                </asp:GridView>
                                                            </div>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="Button1" />
                                                            <asp:AsyncPostBackTrigger ControlID="btnopen" />
                                                            <%--   <asp:AsyncPostBackTrigger ControlID="btnQuickOpen" />--%>
                                                            <asp:AsyncPostBackTrigger ControlID="btnshowall" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div class="modal-footer">
                                                            <asp:Button ID="Button1" runat="server" class="btn btn-sm btn-primary" ValidationGroup="ProductItemGroup" Text="Save & Close"></asp:Button>

                                                        </div>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnopen" />
                                                        <%-- <asp:AsyncPostBackTrigger ControlID="btnQuickOpen" />--%>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <div class="">
                                        <asp:LinkButton ID="btnopen" Text="Add Item" ValidationGroup="MasterGrouppop" runat="server" class="btn btn-alt btn-xs btn-primary" TabIndex="11" />

                                    </div>
                                    <asp:LinkButton ID="LinkButton2" runat="server" Text=""></asp:LinkButton>
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:HiddenField ID="hftotalvat" runat="server" />
                                            <asp:HiddenField ID="hfgrandtotal" runat="server" />
                                            <div class="table-responsive">
                                                <asp:GridView ID="grditemproduct" ShowFooter="true" GridLines="None" CssClass="table table-striped table-vcenter" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Smaller" CellPadding="0" CellSpacing="0" runat="server" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Product Name" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                            <HeaderTemplate>
                                                                <asp:HyperLink ID="HyperLink11" runat="server">Product Name</asp:HyperLink>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="ltproductname" runat="server" Text='<%#Eval("Product_Name")%>'></asp:Label>
                                                                <asp:Label ID="ltitemid" runat="server" Text='<%#Eval("ItemDt_ID")%>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Product Code" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                            <HeaderTemplate>
                                                                <asp:HyperLink ID="HyperLink12" runat="server">Product Code</asp:HyperLink>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="ltproductcode" runat="server" Text='<%#Eval("Product_Code")%>'></asp:Label>
                                                                <asp:Label ID="ltproductid" runat="server" Text='<%#Eval("ProductId")%>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField ItemStyle-Width="" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                            <HeaderTemplate>
                                                                <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <div class="btn-group btn-group-xs">
                                                                    <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger" runat="server" OnClientClick="checkdeleteproduct();"
                                                                        CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>">Delete</asp:LinkButton>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="left" BackColor="White" />
                                                    <FooterStyle HorizontalAlign="left" BackColor="White" />
                                                    <PagerSettings PageButtonCount="4" />
                                                    <EmptyDataTemplate>
                                                        <asp:Label ID="s" runat="server" Text="No Item Found"></asp:Label><br />
                                                        <br />
                                                    </EmptyDataTemplate>
                                                    <EmptyDataRowStyle HorizontalAlign="Center" />
                                                </asp:GridView>
                                            </div>

                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="GridView1" />
                                            <asp:AsyncPostBackTrigger ControlID="Button1" />

                                            <asp:AsyncPostBackTrigger ControlID="grditemproduct" />
                                        </Triggers>
                                    </asp:UpdatePanel>

                                    <br />
                                    <asp:Label ID="lblOtherPI" runat="server" CssClass="col-md-2" Style="width: 13%;" Text="Other Interested Products:"></asp:Label>
                                    <asp:TextBox ID="txtOtherPI" runat="server" CssClass="col-md-3" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                    <div style="clear: both;"></div>
                                    <br />

                                    <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>



            <div class="col-md-12">
                <div id="faq6" class="panel-group">
                    <User:NoteControl ID="notecontrol" runat="server" />
                </div>
                <div id="faq1" class="panel-group">

                    <User:NewDocumentControl ID="documentcontrol" runat="server" />

                </div>
                <User:EmailControl ID="emailcontrol" runat="server" />
            </div>

            <User:ActivityControl ID="activitycontrol" runat="server" />
        </div>
    </div>
</asp:Content>

