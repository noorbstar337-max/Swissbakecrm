<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" MaintainScrollPositionOnPostback="true"  AutoEventWireup="false" CodeFile="index.aspx.vb" Inherits="index" %>

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

    <%--<script type="text/javascript">
        $(function () {
            $.ajax({
                type: "POST",
                url: "Index.aspx/GetData",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    alert(response.d);
                    $("#mini-chart-leadss").sparkline(response.d, {
                        type: 'bar',
                        barWidth: 8,
                        barSpacing: 6,
                        height: '64px',
                        tooltipOffsetX: -25,
                        tooltipOffsetY: 20,
                        barColor: '#999999',
                        tooltipPrefix: '+ ',
                        tooltipSuffix: ' Sales',
                        tooltipFormat: '{{prefix}}{{value}}{{suffix}}'
                    });
                }
            });

        });
</script>--%>
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
                        <small>You Look Awesome!</small></h1>                     
                </div>
                <div class="col-md-8 col-lg-6">
                    <div class="col-xs-4 col-sm-3 pull-right">
                        <asp:DropDownList ID="ddluser" runat="server" AutoPostBack="true"  name="example-chosen" class="form-control"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <!-- For best results use an image with a resolution of 2560x248 pixels (You can also use a blurred image with ratio 10:1 - eg: 1000x100 pixels - it will adjust and look great!) -->
        <img src="img/placeholders/headers/dashboard_header.jpg" alt="header image" class="animation-pulseSlow">
    </div>
    <!-- Mini Top Stats Row -->
    <div class="row" style="margin-left: -5px; margin-right: -5px;" id="divall"  runat="server" >
        <!-- Mini Top Stats Row -->
        <div>
            <asp:Literal ID="lt" runat="server"></asp:Literal>
        </div>
        <div id="chart_div">
        </div>
        <div class="row">
            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                 <a href="Lead.aspx?Type=zhtqu" class="widget widget-hover-effect1">
                <div class="widget">
                    <div class="widget-extra-full text-center">
                        <div class="pie-chart easyPieChart" id="divleadchart" runat="server" data-percent="0" data-size="90" data-bar-color="#4a2e2b" style="width: 90px; height: 90px; line-height: 90px;">
                            <span>
                                <asp:Literal ID="ltleadpercentage" Text="0%" runat="server"></asp:Literal></span>
                            <canvas width="90" height="90"></canvas>
                        </div>
                    </div>
                    <div class="widget-extra themed-background-dark text-center">
                        <h3 class="widget-content-light">
                            <small>Leads Generated</small><br>
                            <small>
                                <asp:Literal ID="ltleadachived" Text="0" runat="server"></asp:Literal>
                                out of
                                <asp:Literal ID="ltleadtarget" Text="0" runat="server"></asp:Literal></small>
                        </h3>
                    </div>
                </div>
                     </a>
                <!-- END Widget -->
            </div>
            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                 <a href="Prospect.aspx?Type=gktdf" class="widget widget-hover-effect1">
                <div class="widget">
                    <div class="widget-extra-full text-center">
                        <div class="pie-chart easyPieChart" id="divprospectchart" runat="server" data-percent="0" data-size="90" data-bar-color="#27ae60" style="width: 90px; height: 90px; line-height: 90px;">
                            <span>
                                <asp:Literal ID="ltprospectpercentage" Text="0%" runat="server"></asp:Literal></span>
                            <canvas width="90" height="90"></canvas>
                        </div>
                    </div>
                    <div class="widget-extra themed-background-spring text-center">
                        <h3 class="widget-content-light">
                            <small>Prospects Generated</small><br>
                            <small>
                                <asp:Literal ID="ltprospectachived" Text="0" runat="server"></asp:Literal>
                                out of
                                <asp:Literal ID="ltprospecttarget" Text="0" runat="server"></asp:Literal></small>
                        </h3>
                    </div>
                </div>
                     </a>
                <!-- END Widget -->
            </div>
            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a href="Account.aspx?Type=prgvfhjsgho" class="widget widget-hover-effect1">
                <div class="widget">
                    <div class="widget-extra-full text-center">
                        <div class="pie-chart easyPieChart" id="divaccountchart" runat="server" data-percent="0" data-size="90" data-bar-color="#e67e22" style="width: 90px; height: 90px; line-height: 90px;">
                            <span>
                                <asp:Literal ID="ltaccountpercentage" Text="0%" runat="server"></asp:Literal></span>
                            <canvas width="90" height="90"></canvas>
                        </div>
                    </div>
                    <div class="widget-extra themed-background-autumn text-center">
                        <h3 class="widget-content-light">
                            <small>Accounts Opened</small><br>
                            <small>
                                <asp:Literal ID="ltaccountachived" Text="0" runat="server"></asp:Literal>
                                out of
                                <asp:Literal ID="ltaccounttarget" Text="0" runat="server"></asp:Literal></small>
                        </h3>
                    </div>                    
                </div>
                </a>
                <!-- END Widget -->
            </div>
            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <div class="widget widget-hover-effect1">
                 <div class="widget">
                    <div class="widget-extra-full text-center">
                        <div class="widget-options-left">
                            <a class="btn btn-xs btn-alt btn-danger"  href="CategoryWiseAchiveTarget.aspx" data-toggle="tooltip" title="Category wise Sales Target" data-original-title="Category wise Sales Target"><i class="fa fa-sitemap"></i></a>
                        </div>
                        <div class="widget-options">
                            <a class="btn btn-xs btn-alt btn-danger" href="SalesOrders.aspx?Type=zhtqu" data-toggle="tooltip" title="Sales Achieved This Month" data-placement="left" data-original-title="Sales Achieved This Month"><i class="fa fa-eye"></i></a>
                        </div>
                        <div class="pie-chart easyPieChart" id="divsaleschart" runat="server" data-percent="0" data-size="90" data-bar-color="#e11b1b" style="width: 90px; height: 90px; line-height: 90px;">
                            <span>
                                <asp:Literal ID="ltsalespercentage" Text="0%" runat="server"></asp:Literal></span>
                            <canvas width="90" height="90"></canvas>
                        </div>
                    </div>
                     <a  href="SalesOrders.aspx?Type=zhtqu">
                    <div class="widget-extra themed-background-fire text-center">
                        <h3 class="widget-content-light" style="margin: 5px 0;">
                        <%--<h3 class="widget-content-light" >--%>
                            <small>Sales Achieved</small><br>
                            <small>
                                <i class="fa fa-rupee"></i> <asp:Literal ID="ltsalesachived" Text="0" runat="server"></asp:Literal>
                                out of&nbsp;
                                <i class="fa fa-rupee"></i> <asp:Literal ID="ltsalestarget" Text="0" runat="server"></asp:Literal></small><br>
                            <a  href="SalesOrders.aspx?Type=zmhytsqaules">
                            <small style="background: #fff; color: #888888; padding: 0px 8px; border-radius: 20px; font-size: 55%;">
                                My Sales <i class="fa fa-rupee"></i> <asp:Literal ID="ltMySales" Text="0" runat="server"></asp:Literal></small>
                            <%--<small><asp:Literal ID="ltMySales" Text="0" runat="server" Visible="false"></asp:Literal></small>--%>
                         </a>
                        </h3>
                    </div>
                         </a>
                </div>
                    </div>
                <!-- END Widget -->
            </div>

        </div>
        <div class="row">
            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a href="Lead.aspx?Type=lxcgzxfgdfgzg" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-fire animation-fadeIn">
                            <i class="gi gi-parents"></i>
                        </div>
                        <h3 class="widget-content text-right animation-pullDown">Idle <strong>Leads (<asp:Literal ID="lblnewlead" runat="server"></asp:Literal>)</strong><br>
                            <small>Lead with No Activity</small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
            </div>
            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a href="Prospect.aspx?Type=prgvfhjsg%hf" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-flatie animation-fadeIn">
                            <i class="fa fa-ticket"></i>
                        </div>
                        <h3 class="widget-content text-right animation-pullDown">Idle Prospects
                            <strong>(<asp:Literal ID="ltprosnoactivity" runat="server"></asp:Literal>)
                            </strong>
                            <small>Prospect With No Activity</small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
            </div>
            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a href="Account.aspx?Type=prgvfhjsg%hf" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-dark animation-fadeIn">
                            <i class="gi gi-group"></i>
                        </div>
                        <h3 class="widget-content text-right animation-pullDown">Idle Accounts
                            <strong>(<asp:Literal ID="ltaccnosales" runat="server"></asp:Literal>)
                            </strong>
                            <small>No sales for last 60 days</small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
            </div>
            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a href="SalesOrders.aspx?Type=prgvfhjsghf" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-autumn animation-fadeIn">
                            <i class="gi gi-group"></i>
                        </div>
                        <h3 class="widget-content text-right animation-pullDown"> 
                            <strong>
                                <i class="fa fa-rupee"></i> <asp:Literal ID="ltlastmonthsales" runat="server"></asp:Literal>
                            </strong>
                            <small>Sales Achieved in last month</small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
            </div>
            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a href="Activity.aspx?type=tall" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-fancy animation-fadeIn">
                            <i class="fa fa-exclamation"></i>
                        </div>
                        <h3 class="widget-content text-right animation-pullDown">Today <strong>
                            <asp:Literal ID="lttodyactivity" runat="server"></asp:Literal>
                            Activity </strong>
                            <br>
                            <small>Today All Activity</small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
            </div>              
              <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a href="Activity.aspx?type=ara" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-fancy animation-fadeIn">
                            <i class="fa fa-exclamation"></i>
                        </div>
                        <h3 class="widget-content  text-right animation-pullDown">Today <strong>
                            <asp:Literal ID="ltTodayReminderCount" runat="server"></asp:Literal>
                            Reminder </strong>
                            <br>
                            <small>Reminders to do</small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
            </div>   
              <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a href="Activity.aspx?type=ama" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-border-night themed-background-dark-autumn test-circle animation-fadeIn">
                            <i class="fa fa-exclamation"></i>
                        </div>
                        <h3 class="widget-content text-right animation-pullDown">Missed
                            <strong>
                                <asp:Literal ID="ltallmissed" runat="server"></asp:Literal>
                                Activity </strong>
                            <small>All Activity Missed</small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
            </div>           
            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a href="CRMFeedbacks.aspx?type=prgvfhjsghf" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-fire themed-border-fire test-circle animation-fadeIn">
                            <i class="fa fa-star"></i>
                        </div>
                        <h3 class="widget-content text-right animation-pullDown">
                            <strong>
                                <asp:Literal ID="lblTodayRatin" runat="server"></asp:Literal>
                               Overall Ratings </strong>
                            <small>from last 30 days</small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
            </div>          
           <%-- <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a href="Activity.aspx?type=tt" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-autumn animation-fadeIn">
                            <i class="fa fa-check-square-o"></i>
                        </div>
                        <h3 class="widget-content text-right animation-pullDown">Today <strong>
                            <asp:Literal ID="lbltodaytask" runat="server"></asp:Literal>
                            Task </strong>
                            <br>
                            <small>Task to do</small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
            </div>
            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a href="Activity.aspx?type=te" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-spring animation-fadeIn">
                            <i class="fa fa-calendar"></i>
                        </div>
                        <h4 class="widget-content text-right animation-pullDown">Today <strong>
                            <asp:Literal ID="lbltodayevent" runat="server"></asp:Literal>
                            Sampling </strong>
                            <small>Be ready for Sampling/Demo</small>
                        </h4>
                    </div>
                </a>
                <!-- END Widget -->
            </div>
            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a href="Activity.aspx?type=tc" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-amethyst animation-fadeIn">
                            <i class="gi gi-phone_alt"></i>
                        </div>
                        <h3 class="widget-content text-right animation-pullDown">Today
                            <strong>
                                <asp:Literal ID="lbltodaycall" runat="server"></asp:Literal>
                                Phone </strong>
                            <small>Phone/Email to do</small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
            </div>
             <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a href="Activity.aspx?type=ama" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-border-night themed-background-dark-autumn test-circle animation-fadeIn">
                            <i class="fa fa-exclamation"></i>
                        </div>
                        <h3 class="widget-content text-right animation-pullDown">Missed
                            <strong>
                                <asp:Literal ID="ltallmissed" runat="server"></asp:Literal>
                                Activity </strong>
                            <small>All Activity Missed</small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
            </div>
            
            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a href="Activity.aspx?type=amt" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-fancy themed-border-night test-circle animation-fadeIn">
                            <i class="fa fa-check-square-o"></i>
                        </div>
                        <h3 class="widget-content text-right animation-pullDown">Missed <strong>
                            <asp:Literal ID="ltmissedtask" runat="server"></asp:Literal>
                            Task </strong>
                            <small>All Missed Task</small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
            </div>
           <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a href="Activity.aspx?type=ame" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-border-night themed-background-flatie test-circle animation-fadeIn">
                            <i class="fa fa-calendar"></i>
                        </div>
                        <h4 class="widget-content text-right animation-pullDown">Missed <strong>
                            <asp:Literal ID="ltmissedevent" runat="server"></asp:Literal>
                            Sampling </strong>
                            <br>
                            <small>All Missed Sampling/Demo</small>
                        </h4>
                    </div>
                </a>
                <!-- END Widget -->
            </div>
            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a href="Activity.aspx?Type=amc" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-fire themed-border-night test-circle animation-fadeIn">
                            <i class="gi gi-phone_alt"></i>
                        </div>
                        <h3 class="widget-content text-right animation-pullDown">Missed <strong>
                            <asp:Literal ID="ltmissescall" runat="server"></asp:Literal>
                            Phone </strong>
                            <small>All Missed Phone/Email</small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
            </div>--%>
            
            
        </div>
        <div class="col-md-12" style="padding: 0;">
            <div class="col-md-9" style="padding-left: 0;">
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
                                                            <asp:LinkButton ID="lnk" runat="server"  ToolTip="Close" 
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
            <br />
                 <div class="col-md-3">
 
              <div class="block-title" style="margin: 0;margin-right: -14px;">
                   <a href="Pendingpayment.aspx"  target ="_blank">
                                               <h2>Pending Payments
                            (<i class="fa fa-rupee"></i>  <asp:Label ID="lblpendingpay" runat="server"></asp:Label>)</h2>
                       </a>

                    </div>

                 
                    
                 <br />
               
               
           
        
              <div class="block-title" style="margin: 0;margin-right: -14px;">
                       <a href="Pendingorder.aspx" target ="_blank" >
                        <h2>Pending Orders
                            (<i class="fa fa-rupee"></i> <asp:Label ID="lblpendingorders" runat="server"></asp:Label>)</h2>
                                </a>
                    </div>

                   
                      </div>
        </div>
        <br />
    <%--    <div class="row">
            <div class="col-md-6">
                <div class="block">
                    <div class="block-title">
                        <h2>Pending Payments
                            ( <i class="fa fa-rupee"></i> <asp:Label ID="lblpendingpay11" runat="server"></asp:Label>)</h2>
                    </div>
                    <div style="min-height: 200px; max-height: 200px; overflow: auto;">
                        <div class="table-responsive">
                            <asp:GridView ID="Grdpendingpay" AutoGenerateColumns="false" HeaderStyle-Font-Size="Smaller" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true" AllowPaging="false" CssClass="table table-striped table-vcenter" GridLines="None" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="Company Name" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Acc_Name">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" EnableViewState="false" NavigateUrl='<%# "ViewAccount.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Acc_Id").ToString()))%>'
                                                data-toggle="tooltip" title="View" runat="server">
                                                <asp:Literal ID="lblaccname" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("AccountName")))%>' />
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pending Payment" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Balance">
                                        <ItemTemplate>
                                            <i class="fa fa-rupee"></i>
                                            <asp:Literal ID="lblpenpay" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Balance")))%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div class="col-sm-12">
                                        <asp:Label ID="lblnorecord" runat="server" Text="No Pending Payment" CssClass="label label-danger"></asp:Label>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
              <div class="col-md-6">
        
              <div class="block-title">

                        <h2>Pending Payments
                            ( <i class="fa fa-rupee"></i>  <asp:Label ID="ddd" runat="server"></asp:Label>)</h2>
                    </div>

                   
                      </div>
                <div class="col-sm-6">
                <!-- Widget -->
                <a href="Pendingpayment.aspx" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-fancy animation-fadeIn">
                            <i class="fa fa-exclamation"></i>
                        </div>
                        <h3 class="widget-content text-right animation-pullDown">Pending Payments 
                            <br />
                            <strong>
                           (<i class="fa fa-rupee"></i> <asp:Label ID="lblpendingpay111" runat="server"></asp:Label>) </strong>
                       
                            <small>Total Count</small>
   
                                     <strong>
                            (<asp:Literal ID="Literal3" Text ="45645654645654654645645645" runat="server"></asp:Literal> )</strong>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
            </div>          

             
                <div class="col-sm-6">
                <!-- Widget -->
                <a href="Activity.aspx?type=tall" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-fancy animation-fadeIn">
                            <i class="fa fa-exclamation"></i>
                        </div>
                        <h3 class="widget-content text-right animation-pullDown">Pending Orders 
                            <br />
                            <strong>
                           (<i class="fa fa-rupee"></i> <asp:Label ID="ff" runat="server"></asp:Label>) </strong>
                       
                            <small>Total Count</small>
   
                                     <strong>
                            (<asp:Literal ID="Literal4" Text ="45645654645654654645645645" runat="server"></asp:Literal> )</strong>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
            </div>            
            <div class="col-md-6" runat ="server" visible ="false" >
                <div class="block">
                    <div class="block-title">
                        <h2>Pending Orders
                            ( <i class="fa fa-rupee"></i> <asp:Label ID="lblpendingorders11" runat="server"></asp:Label>)</h2>
                    </div>
                    <div style="min-height: 200px; max-height: 200px; overflow: auto;">
                        <div class="table-responsive">
                            <asp:GridView ID="GrdPendigOrder" AutoGenerateColumns="false" HeaderStyle-Font-Size="Smaller" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true" AllowPaging="false" CssClass="table table-striped table-vcenter" GridLines="None" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="Company Name" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Acc_Name">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" EnableViewState="false" NavigateUrl='<%# "ViewAccount.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Acc_Id").ToString()))%>'
                                                data-toggle="tooltip" title="View" runat="server">
                                            <asp:Literal ID="lblaccname" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("AccountName")))%>' />
                                                </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order Code" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Order_Code">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hpviwe4" EnableViewState="false" NavigateUrl='<%# "EditSalesOrder.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Order_Id").ToString()))%>'
                                                data-toggle="tooltip" title="View" runat="server">
                                                <asp:Literal ID="lblordercode" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Order_Code")))%>' />
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order Date" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="odate" ItemStyle-Width="150">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblOrddate" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Convert.ToString(Eval("Order_CreatedDate"))))%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order Amount" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Amount" ItemStyle-Width="100">
                                        <ItemTemplate>
                                            <i class="fa fa-rupee"></i>
                                            <asp:Literal ID="lblOrdAmount" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Amount")))%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div class="col-sm-12">
                                        <asp:Label ID="lblnorecord" runat="server" Text="No Pending Orders" CssClass="label label-danger"></asp:Label>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

            
        </div>--%>
    </div>

    <div class="col-md-12 " id="divPurchase" style="float:none" runat="server" visible="false" >
            <div class="">
                <div class="row media-filter-items">
                  
                  
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" >
                            <a href="Rawmaterial.aspx"  class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class="fa fa-cube fa-4x themed-color-amethyst pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Item</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" >
                            <a href="godown.aspx"  class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class="fa fa-bank fa-4x themed-color-amethyst pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Godown</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" >
                            <a href="Vendor.aspx"   class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class="gi gi-group fa-4x themed-color-amethyst pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Vendor</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" >
                            <a href="Principle.aspx" class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class="fa fa-user fa-4x text-color-amethyst pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Principle</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" >
                            <a href="VendorType.aspx" class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class="fa fa-random fa-4x text-color-amethyst pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>VendorType</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv">
                            <a href="quotationrequest.aspx" class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class="gi gi-notes_2 fa-4x text-color-amethyst pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Quotation Request</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div> 
                        <div class="col-sm-6 col-lg-4">
                        <div class="">
                            <%--<a href="quotationrequest.aspx" class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class="gi gi-notes_2 fa-4x text-color-amethyst pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Pending Quotaions</strong><br>
                                </h4>
                            </a>--%>
                            <a href="QRDetails.aspx?Type=Pending" class="widget widget-hover-effect1">
                                <div class="widget-simple">
                                    <div class="widget-icon pull-left themed-background-autumn  animation-fadeIn">
                                        <i class="fa fa-exclamation"></i>
                                    </div>
                                    <h3 class="widget-content text-right animation-pullDown"> <strong>Pending Quotations <asp:Literal ID="ltpendingQ" runat="server"></asp:Literal></strong><br>
                                        
                                    </h3>
                                </div>
                            </a>
                        </div>
                    </div>         
                     <div class="col-sm-6 col-lg-4">
                        <div class="">
                            <%--<a href="quotationrequest.aspx" class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class="gi gi-notes_2 fa-4x text-color-amethyst pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Pending Quotaions</strong><br>
                                </h4>
                            </a>--%>
                            <a href="QRDetails.aspx?Type=Approved" class="widget widget-hover-effect1">
                                <div class="widget-simple">
                                    <div class="widget-icon pull-left themed-background-spring   animation-fadeIn">
                                        <i class="gi gi-ok_2"></i>
                                    </div>
                                    <h3 class="widget-content text-right animation-pullDown"> <strong>Approved Quotations <asp:Literal ID="ltapproveQ" Visible="false"  runat="server"></asp:Literal></strong><br>
                                        
                                    </h3>
                                </div>
                            </a>
                        </div>
                    </div>       
                     <div class="col-sm-6 col-lg-4">
                        <div class="">
                            <%--<a href="quotationrequest.aspx" class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class="gi gi-notes_2 fa-4x text-color-amethyst pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Pending Quotaions</strong><br>
                                </h4>
                            </a>--%>
                            <a href="QRDetails.aspx?Type=Rejected" class="widget widget-hover-effect1">
                                <div class="widget-simple">
                                    <div class="widget-icon pull-left themed-background-fire   animation-fadeIn">
                                        <i class="gi gi-remove_2"></i>
                                    </div>
                                    <h3 class="widget-content text-right animation-pullDown"> <strong>Rejected Quotations <asp:Literal ID="ltRejectQ" runat="server" Visible="false" ></asp:Literal></strong><br>
                                        
                                    </h3>
                                </div>
                            </a>
                        </div>
                    </div>                 
          
                </div>
                <div class="row" id="divgrid" runat="server" >
            <div class="col-md-12">
                <div class="block">
                    <div class="block-title">
                        <h2>Pending Quotations</h2>
                    </div>
                    <div style="min-height: 200px; max-height: 200px; overflow: auto;">
                        <div class="table-responsive">
                    <asp:GridView ID="GridPending" runat="server" AutoGenerateColumns="False" DataKeyNames="QuotationRequest_No" AllowCustomPaging="true"
                                CssClass="table table-striped table-vcenter " AlternatingRowStyle-CssClass="Alternate_grid"
                                AllowPaging="True" PageSize="10" AllowSorting="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="QR-No" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="QuotationRequest_No">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hpsponsor" EnableViewState="false" NavigateUrl='<%# "ViewQuotationResponse.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("QuotationRequest_ID").ToString())) & "&VId=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Vendor_Id").ToString()))%>'
                                                data-toggle="tooltip" title="View" runat="server">
                                                <asp:Literal ID="LblR" runat="server" Text='<%#Eval("QuotationRequest_ID")%>' Visible="false" />
                                                <asp:Literal ID="LblV" runat="server" Text='<%#Eval("Vendor_Id")%>' Visible="false" />
                                                <%--<asp:Literal ID="lblid" runat="server" Text='<%#Eval("QuotationRequest_No")%>' Visible="false" />--%>
                                                <asp:Literal ID="lblQRNo" runat="server" Text='<%#(Eval("QuotationRequest_No"))%>' />
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:TemplateField HeaderText="Vendor-Code" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Vendor_Code" Visible ="false" >
                                        <ItemTemplate>
                                            <asp:Literal ID="lblVendorCode" runat="server" Text='<%#(Eval("Vendor_Code"))%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%><asp:TemplateField HeaderText="Vendor-Name" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Vendor_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblVendorName" runat="server" Text='<%#(Eval("Vendor_Name"))%>' />
                                            <asp:Literal ID="ltname" runat="server" Visible="false" Text='<%#(Eval("Vendor_Name"))%>'></asp:Literal>
                                          
                                             <asp:Literal ID="LblResponse_ID" runat="server" Text='<%#Eval("QuotationResponse_ID")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Rm_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblRMName" runat="server" Text='<%#(Eval("Rm_Name"))%>' />
                                            <asp:Literal ID="lblRMID" runat="server" Text='<%#Eval("Rm_ID")%>' Visible="false" />
                                            <asp:Literal ID="lblQResponse_Code" runat="server" Text='<%#Eval("QuotationResponse_Code")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Quantity">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblQty" runat="server" Text='<%#(Eval("Quantity"))%>' />
                                            <asp:Literal ID="lblQty1" runat="server" Text='<%#Eval("Quantity")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Amount">
                                        <ItemTemplate>
                                            <i class="fa fa-inr "></i>&nbsp;
                                            <asp:Literal ID="lblAmount" runat="server" Text='<%#(Convert.ToDouble(Eval("Amount")).ToString("#,##0.00"))%>' />
                                            <asp:Literal ID="lblAmount1" runat="server" Text='<%#Eval("Amount")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Per-Unit" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Per_Unit">
                                        <ItemTemplate>
                                            <i class="fa fa-inr "></i>&nbsp;
                                            <asp:Literal ID="lblPerUnit" runat="server" Text='<%#(Convert.ToDouble(Eval("Per_Unit")).ToString("#,##0.00"))%>' />
                                            <asp:Literal ID="lblPerUnit1" runat="server" Text='<%#Eval("Per_Unit")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tax" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Tax">
                                        <ItemTemplate>
                                            <i class="fa fa-inr "></i>&nbsp;
                                            <asp:Literal ID="lblTax" runat="server" Text='<%#(Convert.ToDouble(Eval("Tax")).ToString("#,##0.00"))%>' />
                                            <asp:Literal ID="lblTax1" runat="server" Text='<%#Eval("Tax")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Freight" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Freight">
                                        <ItemTemplate>
                                            <i class="fa fa-inr "></i>&nbsp;
                                            <asp:Literal ID="lblFreight" runat="server" Text='<%#(Convert.ToDouble(Eval("Freight")).ToString("#,##0.00"))%>' />
                                            <asp:Literal ID="lblFreight1" runat="server" Text='<%#Eval("Freight")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Total">
                                        <ItemTemplate>
                                            <i class="fa fa-inr "></i>&nbsp;
                                            <asp:Literal ID="lblTotal" runat="server" Text='<%#(Convert.ToDouble(Eval("Total")).ToString("#,##0.00"))%>' />
                                            <asp:Literal ID="lblTotal1" runat="server" Text='<%#Eval("Total")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="QR-Vendor" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="QuotationRequest_Vendor_ID">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblname2" runat="server" Text='<%#(Eval("QuotationRequest_Vendor_ID"))%>' />                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="View" Visible="false" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink4" runat="server">View</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="hlview" EnableViewState="false" NavigateUrl='<%# "AddQuotationResponse.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("QuotationRequest_ID").ToString()))%>'
                                                    data-toggle="tooltip" title="View" class="btn btn-default" runat="server"><i class="fa fa-eye "></i></asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="QuotationResponse_Status">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblStatus" runat="server" Text='<%#(Eval("QuotationResponse_Status"))%>' />
                                            <asp:Literal ID="lblstatus1" runat="server" Text='<%#(Eval("QuotationResponse_Status"))%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink4" runat="server">Edit</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="hledit" EnableViewState="false" NavigateUrl='<%# "AddQuotationResponse.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("QuotationRequest_ID").ToString())) & "&VId=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Vendor_Id").ToString()))%>'
                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Delete" ItemStyle-Width="10px" HeaderStyle-CssClass="MasterGridviewHeader1" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Delete">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLinkdelete" runat="server">Delete</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                    CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%><%--   <asp:TemplateField HeaderText="Delete" ItemStyle-Width="10px" HeaderStyle-CssClass="MasterGridviewHeader1" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Delete" Visible="false">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLinkdelete" runat="server">Delete</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                    CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%><asp:TemplateField HeaderText="Action" ItemStyle-Width="10px" HeaderStyle-CssClass="MasterGridviewHeader1" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Delete" Visible="true">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLinkAction" runat="server">Action</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:LinkButton ID="lnkApproved" data-toggle="tooltip" title="Approved" class="btn btn-success" runat="server"
                                                    CommandName="Approvedink" CommandArgument='<%#Eval("QuotationRequest_ID").ToString() + ","+Eval("Vendor_Id").ToString() %>'>Approve</asp:LinkButton>
                                                <asp:LinkButton ID="lnkPO" data-toggle="tooltip" title="Create PO" class="btn btn-warning" runat="server"
                                                        CommandName="createPO" CommandArgument='<%#Eval("QuotationRequest_ID").ToString() + ","+Eval("Vendor_Id").ToString() %>'>Create PO</asp:LinkButton>
                                                <%--  <asp:LinkButton ID="LnkViewPO" data-toggle="tooltip" title="View PO" class="btn btn-info" runat="server"  OnClientClick="aspnetForm.target ='_blank';"
                                                    CommandName="ViewPo"  CommandArgument='<%#Eval("QuotationRequest_ID").ToString() + ","+Eval("Vendor_Id").ToString() %>'>View PO</asp:LinkButton>--%>

                                                <a id="LnkViewPO" runat="server"  data-toggle="tooltip" title="View PO" class="btn btn-alt btn-xs btn-success" href='<%#"Purchaseorder.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("QuotationRequest_ID").ToString)) + "&VId=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Vendor_Id").ToString))%>' target="_blank"><i class="fa fa-print"></i>&nbsp;View PO</a>
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
                    </div>
                </div>
            </div>
          
                    

            
        </div>
            </div>
        </div>
    <script src="js/pages/widgetsStats.js"></script>
    <script>$(function () { WidgetsStats.init(); });</script>
</asp:Content>

