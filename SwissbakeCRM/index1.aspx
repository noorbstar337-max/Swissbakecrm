<%@ Page Language="VB" MasterPageFile="~/MCRMMaster.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="index1.aspx.vb" Inherits="index1" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="http://www.google.com/jsapi" type="text/javascript"></script>--%>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <%--  <script src="js/pages/widgetsStats.js"></script>
        <script>$(function () { WidgetsStats.init(); });</script>--%>
    <style>
        input[type="checkbox"] {
            margin-right: 10px;
        }
       
    </style>
    <script type="text/javascript">
           function checkConvert() {
               if (confirm('Are you Sure, you want to take this action ?')) {
                   document.getElementById('<%=deletestatus.ClientID %>').value = "yes";
                 return true
             }
             else {
                 document.getElementById('<%=deletestatus.ClientID %>').value = "no";
                 return true
             }
         }
    </script>
  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <asp:HiddenField ID="deletestatus" runat="server" />
    <!-- Page content -->
    <div class="content-header content-header-media" style="height: 125px;">
        <div class="header-section">
            <div class="row">
                <!-- Main Title (hidden on small devices for the statistics to fit hidden-xs hidden-sm) -->
                <div class="col-md-4 col-lg-6">
                    <h1>Welcome  <strong>
                        <asp:Label ID="lblusername" runat="server" Font-Bold="true"></asp:Label></strong><br>
                    </h1>                     
                </div>
                <div class="col-md-8 col-lg-6">
                  <%--  <div class="col-xs-4 col-sm-3 pull-right">
                        <asp:DropDownList ID="ddluser" runat="server" AutoPostBack="true"  name="example-chosen" class="form-control"></asp:DropDownList>
                    </div>--%>
                </div>
            </div>
        </div>
        <!-- For best results use an image with a resolution of 2560x248 pixels (You can also use a blurred image with ratio 10:1 - eg: 1000x100 pixels - it will adjust and look great!) -->
        <img src="img/placeholders/headers/dashboard_header.jpg" alt="header image" class="animation-pulseSlow">
    </div>
    <!-- Mini Top Stats Row -->
      <div class="col-md-12 " id="divPurchase" style="float:none" runat="server"  >
            <div class="">
                <div class="row media-filter-items">
                  
                  
                    <div class="col-sm-3 "  >
                        <div class="media-items animation-fadeInQuickInv" >
                            <a href="<%= "MCRMAddLead.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(0))%>"  class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class=" fa fa-random fa-4x themed-color-amethyst pull-left" style="padding-left:1em;"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Add Lead</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-3 " >
                        <div class="media-items animation-fadeInQuickInv" >
                            <a href="<%= "MCRMAddProspect.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(0))%>"  class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class="gi gi-group  fa-4x themed-color-amethyst pull-left" style="padding-left:1em;"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Add Prospect</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-3 " >
                        <div class="media-items animation-fadeInQuickInv" >
                            <a href="<%= "MCRMAddAccount.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(0))%>"   class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class="fa fa-bank fa-4x themed-color-amethyst pull-left" style="padding-left:1em;"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Add Account</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-3 " >
                        <div class="media-items animation-fadeInQuickInv" >
                            <a href="<%= "dsr.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(0))%>" class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class=" gi gi-notes_2  fa-4x text-color-amethyst pull-left " style="padding-left:1em;"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Add DSR</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    
                     <div class="col-sm-3 " >
                        <div class="media-items animation-fadeInQuickInv" >
                            <a href="<%= "ModifySampleRequest.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0))%>" class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class="fa fa-cube fa-4x text-color-amethyst pull-left " style="padding-left:1em;"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Add Sample Request</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>

                     <div class="col-sm-3 " >
                        <div class="media-items animation-fadeInQuickInv" >
                            <a href="<%= "Reminder.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0))%>" class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class="fa fa-repeat fa-4x text-color-amethyst pull-left " style="padding-left:1em;"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Add Reminder</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>

                    <div class="col-sm-3 " >
                        <div class="media-items animation-fadeInQuickInv" >
                            <a href="<%= "Support_Ticket.aspx"%>" class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class="fa fa-comments fa-4x text-color-amethyst pull-left " style="padding-left:1em;"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Add Complaint</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                  
                </div>
       
            </div>
        </div>

          <div class="row">
            <div class="col-md-12">
                <div class="block">
                    <div class="block-title">
                        <h2>To Do List</h2>
                    </div>
                    <asp:HiddenField ID="Hfgridview" runat="server" />
                    <User:ActivityCloseButtonControl ID="Activityclose" runat="server" />
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div style="max-height: 300px; overflow: auto;">
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" DataKeyNames="Id"
                                                CssClass="table table-striped table-vcenter">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="View" SortExpression="Deprt_Status" ItemStyle-Width="10" ItemStyle-CssClass="MasterGridviewItem">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkview" Height="25" Width="25" runat="server"
                                                                CommandName="Viewing" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-eye"></i></asp:LinkButton>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Close" SortExpression="Deprt_Status" ItemStyle-Width="10" ItemStyle-CssClass="MasterGridviewItem">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnk" runat="server"
                                                                CommandName="Closing" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                                            <asp:LinkButton ID="lnkChangeDSR" runat="server" Visible="false"   OnClientClick="checkConvert();" ToolTip="Convert to DSR"
                                                                CommandName="ChangeToDSR" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-share"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit" SortExpression="Deprt_Status" ItemStyle-Width="10" ItemStyle-CssClass="MasterGridviewItem">

                                                        <ItemTemplate>
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:HyperLink ID="HyperLink1"  NavigateUrl='<%# Page.ResolveUrl("ActivityTask.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Id").ToString())))%>'
                                                                    data-toggle="tooltip" title="Edit" class="btn btn-Primary" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                                            </div>
                                                            <asp:Literal ID="ltrelatedtypeid" runat="server" Text='<%#Eval("Activity_RelatedTypeID")%>' Visible="false"></asp:Literal>
                                                            <asp:Literal ID="ltrelatedtype" runat="server" Text='<%#Eval("Related To")%>' Visible="false"></asp:Literal>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="left" BackColor="White" />
                                                <FooterStyle HorizontalAlign="left" BackColor="White" />
                                                <PagerSettings PageButtonCount="4" />
                                                <EmptyDataTemplate>
                                                    <asp:Label ID="s" runat="server" Text="No To Do List Found" CssClass="label label-danger"></asp:Label><br />
                                                    <br />
                                                </EmptyDataTemplate>
                                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GridView1" />
                                    <%-- <asp:PostBackTrigger ControlID="btnsave" />--%>
                                </Triggers>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:LinkButton ID="btnfollowupshow" runat="server"></asp:LinkButton>
                            <asp:ModalPopupExtender ID="mpefollowup" runat="server" PopupControlID="Panel2" TargetControlID="btnfollowupshow"
                                CancelControlID="btnfollowNo" BackgroundCssClass="pop">
                            </asp:ModalPopupExtender>
                            <asp:Panel ID="Panel2" runat="server" Style="display: none">
                                <div class="modal-dialog modal-lg" style="overflow-y: scroll; position: fixed; top: 0; bottom: 0; left: 0; right: 0; overflow: auto;">
                                    <div class="modal-content" style="top: 1%; overflow-x: hidden; overflow-y: auto; outline: none; margin-top: 0; top: 50%; overflow: visible;">
                                        <div class="modal-header">
                                            <asp:LinkButton ID="btnfollowNo" class="close" runat="server">&times;</asp:LinkButton>
                                            <h4 class="modal-title">Activity Detail</h4>
                                        </div>
                                        <div class="modal-body">
                                            <div id="actndt1" class="panel-group">
                                                <div class="panel panel-default">
                                                    <div class="panel-heading">
                                                        <h4 class="panel-title"><i class="fa fa-angle-right"></i><a class="accordion-toggle" data-toggle="collapse" data-parent="#actndt1" href="#Actdt">Activity Detail</a></h4>
                                                    </div>
                                                    <div id="Actdt" class="panel-collapse collapse in">
                                                        <div class="panel-body">
                                                            <div class="table-responsive">
                                                                <table class="table table-borderless table-striped">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="width: 20%;"><strong>
                                                                                <asp:Label ID="lblname" runat="server" Text="Account Name"></asp:Label></a></strong></td>
                                                                            <td>
                                                                                <asp:Literal ID="lblaccname" runat="server"></asp:Literal></td>

                                                                        </tr>
                                                                        <tr id="trcontact" runat="server">
                                                                            <td style="width: 20%;"><strong>
                                                                                <asp:Label ID="Label1" runat="server" Text="Contact Name"></asp:Label></a></strong></td>
                                                                            <td>
                                                                                <asp:Literal ID="ltcontact" runat="server"></asp:Literal></td>

                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 20%;"><strong>
                                                                                <asp:Label ID="Label3" runat="server" Text="Activity Owner"></asp:Label></a></strong></td>
                                                                            <td>
                                                                                <asp:Literal ID="ltowner" runat="server"></asp:Literal></td>

                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 20%;"><strong>Activity Subject</strong></td>
                                                                            <td>
                                                                                <asp:Literal ID="lblsubject" runat="server"></asp:Literal></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td><strong>Activity Date </strong></td>
                                                                            <td>
                                                                                <b>From </b>
                                                                                <asp:Literal ID="ltstartdate" Text="25 April 2014" runat="server"></asp:Literal>
                                                                                <b>To</b>
                                                                                <asp:Literal ID="ltenddate" Text="25 April 2014" runat="server"></asp:Literal></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td><strong>Status</strong></td>
                                                                            <td>
                                                                                <asp:Label ID="ltstatus" CssClass="label label-info" Text="Close Pospone" runat="server"></asp:Label></td>

                                                                        </tr>
                                                                        <tr>
                                                                            <td><strong>Priority</strong></td>
                                                                            <td>
                                                                                <asp:Label ID="ltpriority" CssClass="label label-warning" Text="High" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td><strong>Desc</strong></td>
                                                                            <td>
                                                                                <asp:Literal ID="ltdesc" runat="server"></asp:Literal>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td><strong>Result</strong></td>
                                                                            <td>
                                                                                <asp:Literal ID="ltresult" runat="server"></asp:Literal>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="panel panel-default">
                                                    <div class="panel-heading">
                                                        <h4 class="panel-title"><i class="fa fa-angle-right"></i><a class="accordion-toggle" data-toggle="collapse" data-parent="#actndt1" href="#faq1asda_q2">Activity History</a></h4>
                                                    </div>
                                                    <div id="faq1asda_q2" class="panel-collapse collapse">
                                                        <div class="panel-body">
                                                            <asp:GridView ID="grdactivityhistory" runat="server" AutoGenerateColumns="true" DataKeyNames="Status" CssClass="table table-striped table-vcenter table-hover">

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
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-2" style="display: none"><a>Date</a>:-<b><asp:Literal ID="lblactivitydate" runat="server"></asp:Literal></b></div>
                                            <div style="clear: both"></div>
                                            <div style="overflow-y: auto; max-height: 176px; margin-bottom: 10px;">
                                                <asp:GridView ID="lvnote" DataKeyNames="Note_Id" AutoGenerateColumns="false" HeaderStyle-Font-Size="Smaller" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true" AllowPaging="false" CssClass="table table-striped table-vcenter" GridLines="None" runat="server">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Note Date"  ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Opportunity_ExpectedDate">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="lblcontact" runat="server" Text='<%#((Eval("Date")))%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Name" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Opportunity_ExpectedDate">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="lblFirstName" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("U_FirstName")))%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Note Text"   ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Opportunity_ExpectedDate">
                                                            <ItemTemplate>
                                                                 
                                                                <asp:Literal ID="lblNoteText" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Note_Text")))%>' />
                                                                     
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Activity" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Opportunity_ExpectedDate">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="ltsubject" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Activity_Subject")))%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="From" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Activity_Type">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="ltstartdate" Text='<%#((Eval("Activity_CallStartTime")))%>' runat="server"></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Activity Type" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Activity_Type">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="lttype" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Activity_Type")))%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <div class="col-sm-12">
                                                            <asp:Label ID="lblnorecord" runat="server" Text="No Note Found" CssClass="label label-danger"></asp:Label>
                                                        </div>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </div>
                                            <asp:HiddenField ID="hffollowactivityid" runat="server" />
                                            <asp:HiddenField ID="hfmainactivityid" runat="server" />
                                            <asp:HiddenField ID="hfreltype" runat="server" />
                                            <asp:HiddenField ID="hfreltypeId" runat="server" />
                                            <div class="col-sm-10">
                                                <div class="form-group">
                                                    <label for="example-nf-email">Note <span class="text-danger">*</span></label>
                                                    <asp:TextBox ID="txtname" runat="server" TextMode="MultiLine" Columns="2" Rows="2" placeholder="Enter Note" data-toggle="tooltip" title="Enter Note"
                                                        CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="remembername" runat="server" SetFocusOnError="true" ControlToValidate="txtname" ValidationGroup="FollowNoteGroup" CssClass="MasterValidationCSS"
                                                        ErrorMessage="Please enter note"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-sm-2">
                                                <br />
                                                <br />
                                                <asp:Button ID="btnaddnote" runat="server" class="btn btn-sm btn-primary" Text="Add Note" ValidationGroup="FollowNoteGroup"></asp:Button>
                                                <br />
                                                <br />
                                            </div>
                                            <div style="clear: both"></div>
                                            <div class="col-sm-3" style="display: none">
                                                <asp:CheckBox ID="ckcreatefollowupactvt" AutoPostBack="true" Style="padding-right: 10px;" runat="server" Text="Create Follow Up Activity" TextAlign="Right" />
                                            </div>

                                        </div>

                                    </div>
                                </div>
                            </asp:Panel>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="GridView1" />
                            <asp:AsyncPostBackTrigger ControlID="btnaddnote" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

</asp:Content>

