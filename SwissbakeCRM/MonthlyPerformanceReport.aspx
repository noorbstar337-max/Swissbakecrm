<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MonthlyPerformanceReport.aspx.vb" Inherits="MonthlyPerformanceReport" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Stylesheets -->
    <!-- Bootstrap is included in its original form, unaltered -->
    <link rel="stylesheet" href="css/bootstrap.min.css" />

    <!-- Related styles of various icon packs and plugins -->
    <link rel="stylesheet" href="css/plugins.css" />

    <!-- The main stylesheet of this template. All Bootstrap overwrites are defined in here -->
    <link rel="stylesheet" href="css/main.css" />

    <!-- Include a specific file here from css/themes/ folder to alter the default theme of the template -->

    <!-- The themes stylesheet of this template (for using specific theme color in individual elements - must included last) -->
    <link rel="stylesheet" href="css/themes.css" />
    <!-- END Stylesheets -->

    <!-- Modernizr (browser feature detection library) & Respond.js (Enable responsive CSS code on browsers that don't support it, eg IE8) -->
    <script src="js/vendor/modernizr-2.7.1-respond-1.4.2.min.js"></script>

    <%--google--%>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>


    <%--google--%>
  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<%--<script type="text/javascript" src="http://cdn.rawgit.com/niklasvh/html2canvas/master/dist/html2canvas.min.js"></script>--%>
        <script src="js/jquery.min.js"></script>
    <script src="js/html2canvas.min.js"></script>
<script type="text/javascript">
    function ConvertToImage(btnExport) {
        html2canvas($("#dvTable")[0]).then(function (canvas) {
            var base64 = canvas.toDataURL();
            $("[id*=hfImageData]").val(base64);
            __doPostBack(btnExport.name, "");
        });
        return false;
    }
</script>
   
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager11" runat="server"></asp:ScriptManager>
        
        <div id="page-content">
             <asp:HiddenField ID="hfImageData" runat="server" />
            <div class="">
            <div class="row">
                <div class="col-md-2 col-md-offset-5">
<asp:Button ID="btnExport" Text="Export Report" runat="server" UseSubmitBehavior="false"
    OnClick="ExportToImage" OnClientClick="return ConvertToImage(this)" CssClass="btn btn-alt btn-info" />
                </div>
                </div>
                </div>
            <div style="clear:both;"></div>
            <!-- Statistics Widgets Header -->
           <div id="dvTable">
              <asp:Panel id="printablediv" runat="server" >
            <div class="content-header">
                <div class="header-section">
                    <h1>
                       <asp:LinkButton ID="btnShow" runat="server" ><i class="fa fa-calendar themed-color-default" data-toggle="tooltip" title="Change Month" data-placement="left"></i></asp:LinkButton>
                        <asp:Label ID="lblbodname" runat="server" Font-Bold="true"></asp:Label>
                        <br />
                        <small>Monthly Performance Report  Period:
                            <asp:Label ID="lblmonth" runat="server" Font-Bold="true"></asp:Label></small>
                       
                    </h1>
                    
                </div>
            </div>

 
            <div class="row">
                <div class="col-md-8">
                    <!-- Large Widget (Active Color Theme Light) -->

                    <div class="widget">
                        <div class="widget-advanced widget-advanced-alt">

                            <!-- Widget Main -->
                            <div class="widget-main" style="padding-bottom: 0">
                                <h4 class="center-block"><strong> Team</strong> <br /></h4>
                                <h4 class="sub-header remove-margin-bottom ">Sales Performance <small>(<asp:Label ID="lblcMonth" runat="server"></asp:Label>
                                    )</small></h4>
                                <div class="row text-center">
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong><i class="fa fa-rupee"></i>&nbsp;<asp:Label ID="lblCMST" runat="server"></asp:Label></strong><br />
                                            <small>Total Sales Target</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong><i class="fa fa-rupee"></i>&nbsp;<asp:Label ID="lblCMA" runat="server"></asp:Label></strong><br />
                                            <small>Achieved Amount</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblCMAP" runat="server"></asp:Label>%&nbsp;</strong><br />
                                            <small>Achieved %</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblCMQTY" runat="server"></asp:Label>&nbsp;Kg</strong><br />
                                            <small>Quantity Achieved</small></h3>
                                    </div>
                                </div>
                            </div>
                            <!-- END Widget Main -->
                           
                            <!-- Widget Main -->
                            <div class="widget-main" style="padding-top: 0">
                                <h4 class="sub-header remove-margin-bottom ">Sales Performance <small>(<asp:Label ID="lblLMonth" runat="server"></asp:Label>)</small></h4>
                                <div class="row text-center">
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong><i class="fa fa-rupee"></i>&nbsp;<asp:Label ID="lblLMST" runat="server"></asp:Label></strong><br />
                                            <small>Total Sales Target</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong><i class="fa fa-rupee"></i>&nbsp;<asp:Label ID="lblLMA" runat="server"></asp:Label></strong><br />
                                            <small>Achieved Amount</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblLMAP" runat="server"></asp:Label>%&nbsp;</strong><br />
                                            <small>Achieved %</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblLMQTY" runat="server"></asp:Label>&nbsp;Kg</strong><br />
                                            <small>Quantity Achieved</small></h3>
                                    </div>
                                </div>
                            </div>
                            <!-- END Widget Main -->
                        </div>
                    </div>
                    <!-- END Large Widget (Active Color Theme Light) -->
                </div>
                <div class="col-md-4">
                    <div class="block remove-margin-bottom">
                        <div class="col-md-12 panel panel-default">
                            <div class="table-responsive">
                                <asp:Literal ID="lblsalestarget" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div style="clear: both;"></div>
                    </div>
                </div>
            </div>
     
              <div class="row">
                <div class="col-md-8">
                    <!-- Large Widget (Active Color Theme Light) -->

                    <div class="widget">
                        <div class="widget-advanced widget-advanced-alt">
                                                       
                            <!-- Widget Main -->
                            <div class="widget-main" style="padding-bottom: 0">
                                  <h4 class="center-block"><strong> Individual</strong> <br /></h4>
                                <h4 class="sub-header remove-margin-bottom ">Sales Performance <small>(<asp:Label ID="lblcMonthI" runat="server"></asp:Label>
                                    )</small></h4>
                                <div class="row text-center">
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong><i class="fa fa-rupee"></i>&nbsp;<asp:Label ID="lblCMSTI" runat="server"></asp:Label></strong><br />
                                            <small>Total Sales Target</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong><i class="fa fa-rupee"></i>&nbsp;<asp:Label ID="lblCMAI" runat="server"></asp:Label></strong><br />
                                            <small>Achieved Amount</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblCMAPI" runat="server"></asp:Label>%&nbsp;</strong><br />
                                            <small>Achieved %</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblCMQTYI" runat="server"></asp:Label>&nbsp;Kg</strong><br />
                                            <small>Quantity Achieved</small></h3>
                                    </div>
                                </div>
                            </div>
                            <!-- END Widget Main -->

                              <!-- Widget Main -->
                            <div class="widget-main" style="padding-top: 0">
                                <h4 class="sub-header remove-margin-bottom ">Sales Performance <small>(<asp:Label ID="lblLMonthI" runat="server"></asp:Label>)</small></h4>
                                <div class="row text-center">
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong><i class="fa fa-rupee"></i>&nbsp;<asp:Label ID="lblLMSTI" runat="server"></asp:Label></strong><br />
                                            <small>Total Sales Target</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong><i class="fa fa-rupee"></i>&nbsp;<asp:Label ID="lblLMAI" runat="server"></asp:Label></strong><br />
                                            <small>Achieved Amount</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblLMAPI" runat="server"></asp:Label>%&nbsp;</strong><br />
                                            <small>Achieved %</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblLMQTYI" runat="server"></asp:Label>&nbsp;Kg</strong><br />
                                            <small>Quantity Achieved</small></h3>
                                    </div>
                                </div>
                            </div>
                            <!-- END Widget Main -->
                        </div>
                    </div>
                    <!-- END Large Widget (Active Color Theme Light) -->
                </div>
                <div class="col-md-4">
                    <div class="block remove-margin-bottom">
                        <div class="col-md-12 panel panel-default">
                            <div class="table-responsive">
                                <asp:Literal ID="lblsalestargetI" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div style="clear: both;"></div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <div class="block remove-margin-bottom ">
                        <div class="col-md-12 panel panel-default">
                            <div class="table-responsive">
                                <asp:Literal ID="lblgrouptarget" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div style="clear: both;"></div>
                    </div>
                </div>
                <div class="col-md-8">
                    <!-- Large Widget (Active Color Theme Light) -->

                    <div class="widget" style="min-height: 275px;">
                        <div class="widget-advanced widget-advanced-alt">
                            <div class="widget-main" style="padding-top: 0">
                                <h4 class="sub-header" style="margin-top: 0"><strong>Team</strong> Group Wise Detail</h4>
                                <!-- Widget Main -->
                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="table-responsive">
                                            <asp:GridView ID="GrdGroupwise" runat="server" CssClass="table table-striped table-vcenter" AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Group Name" ItemStyle-CssClass="" HeaderStyle-CssClass="">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblGroupname" runat="server" Text='<%#Eval("TC_Name")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Target Given" ItemStyle-CssClass="" HeaderStyle-CssClass="">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblGroupname" runat="server" Text='<%#CDbl(Math.Round(Eval("STCD_SalesAmt"))).ToString("N2")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Achieved" ItemStyle-CssClass="" HeaderStyle-CssClass="">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblGroupname" runat="server" Text='<%#CDbl(Math.Round(Eval("TargetSalesAchived"))).ToString("N2")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Achieved %" ItemStyle-CssClass="" HeaderStyle-CssClass="">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblGroupname" runat="server" Text='<%#Eval("achivepercent")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Quantity" ItemStyle-CssClass="" HeaderStyle-CssClass="">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblGroupname" runat="server" Text='<%#CDbl(Math.Round(Eval("TargetQTYAchived"))).ToString("N2")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <!-- END Widget Main -->
                            </div>
                        </div>
                    </div>
                    <!-- END Large Widget (Active Color Theme Light) -->
                </div>

            </div>

            <div class="row">
                <div class="col-md-4">
                    <div class="block remove-margin-bottom ">
                        <div class="col-md-12 panel panel-default">
                            <div class="table-responsive">
                                <asp:Literal ID="lblgrouptargetI" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div style="clear: both;"></div>
                    </div>
                </div>
                <div class="col-md-8">
                    <!-- Large Widget (Active Color Theme Light) -->

                    <div class="widget" style="min-height: 275px;">
                        <div class="widget-advanced widget-advanced-alt">
                            <div class="widget-main" style="padding-top: 0">
                                <h4 class="sub-header" style="margin-top: 0"><strong>Individual</strong> Group Wise Detail</h4>
                                <!-- Widget Main -->
                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="table-responsive">
                                            <asp:GridView ID="GrdGroupwiseI" runat="server" CssClass="table table-striped table-vcenter" AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Group Name" ItemStyle-CssClass="" HeaderStyle-CssClass="">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblGroupname" runat="server" Text='<%#Eval("TC_Name")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Target Given" ItemStyle-CssClass="" HeaderStyle-CssClass="">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblGroupname" runat="server" Text='<%#CDbl(Math.Round(Eval("STCD_SalesAmt"))).ToString("N2")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Achieved" ItemStyle-CssClass="" HeaderStyle-CssClass="">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblGroupname" runat="server" Text='<%#CDbl(Math.Round(Eval("TargetSalesAchived"))).ToString("N2")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Achieved %" ItemStyle-CssClass="" HeaderStyle-CssClass="">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblGroupname" runat="server" Text='<%#Eval("achivepercent")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Quantity" ItemStyle-CssClass="" HeaderStyle-CssClass="">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblGroupname" runat="server" Text='<%#CDbl(Math.Round(Eval("TargetQTYAchived"))).ToString("N2")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <!-- END Widget Main -->
                            </div>
                        </div>
                    </div>
                    <!-- END Large Widget (Active Color Theme Light) -->
                </div>

            </div>

            <div class="row">

                <div class="col-md-8">
                    <!-- Large Widget (Active Color Theme Light) -->

                    <div class="widget">
                        <div class="widget-advanced widget-advanced-alt">
                            <div class="widget-main" style="padding-top: 0">
                                <h4 class="sub-header" style="margin-top: 0"><strong>Team </strong>Activity Report</h4>
                                <!-- Widget Main -->
                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="table-responsive">
                                            <table id="reportTable" class=" text-center table table-vcenter table-condensed table-bordered table-hover">
                                                <thead>
                                                    <tr style="background-color: rgba(160, 159, 158, 0.85);">
                                                        <th class="text-center col-xs-2">Activity</th>
                                                        <th class="text-center col-xs-2" colspan="2">Perform</th>
                                                        <th class="text-center col-xs-2" colspan="2">Missed</th>
                                                        <th class="text-center col-xs-2" colspan="2">Close Postpone</th>
                                                        <th class="text-center col-xs-2" colspan="2">Total</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td class="">Task</td>

                                                        <td><span class="label" style="background-color: rgba(66, 133, 244, 1);">
                                                            <asp:Label ID="taskPerform" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color: rgba(66, 133, 244, 1);">
                                                            <asp:Label ID="pertaskPerform" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color: rgba(219, 68, 55, 1);">
                                                            <asp:Label ID="taskMissed" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color: rgba(219, 68, 55, 1);">
                                                            <asp:Label ID="pertaskMissed" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color: rgba(244, 180, 0, 1);">
                                                            <asp:Label ID="taskClose" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color: rgba(244, 180, 0, 1);">
                                                            <asp:Label ID="pertaskClose" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label label-success">
                                                            <asp:Label ID="taskTotal" runat="server" Text="Label"></asp:Label>
                                                        </span></td>
                                                        <td><span class="label label-success">
                                                            <asp:Label ID="pertaskTotal" runat="server" Text="Label"></asp:Label></span></td>
                                                    </tr>

                                                    <tr>
                                                        <td class="text-center">Sampling/Demo</td>
                                                        <td><span class="label" style="background-color: rgba(66, 133, 244, 1);">
                                                            <asp:Label ID="demoPerform" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color: rgba(66, 133, 244, 1);">
                                                            <asp:Label ID="perdemoPerform" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color: rgba(219, 68, 55, 1);">
                                                            <asp:Label ID="demoMissed" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color: rgba(219, 68, 55, 1);">
                                                            <asp:Label ID="perdemoMissed" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color: rgba(244, 180, 0, 1);">
                                                            <asp:Label ID="demoClose" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color: rgba(244, 180, 0, 1);">
                                                            <asp:Label ID="perdemoClose" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label label-success">
                                                            <asp:Label ID="demoTotal" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label label-success">
                                                            <asp:Label ID="perdemoTotal" runat="server" Text="Label"></asp:Label></span></td>
                                                    </tr>

                                                    <tr>
                                                        <td class="text-center">Phone & Email</td>
                                                        <td><span class="label" style="background-color: rgba(66, 133, 244, 1);">
                                                            <asp:Label ID="phonePerform" runat="server"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color: rgba(66, 133, 244, 1);">
                                                            <asp:Label ID="perphonePerform" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color: rgba(219, 68, 55, 1);">
                                                            <asp:Label ID="phoneMissed" runat="server"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color: rgba(219, 68, 55, 1);">
                                                            <asp:Label ID="perphoneMissed" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color: rgba(244, 180, 0, 1);">
                                                            <asp:Label ID="phoneClose" runat="server"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color: rgba(244, 180, 0, 1);">
                                                            <asp:Label ID="perphoneClose" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label label-success">
                                                            <asp:Label ID="phoneTotal" runat="server"></asp:Label></span></td>
                                                        <td><span class="label label-success">
                                                            <asp:Label ID="perphoneTotal" runat="server" Text="Label"></asp:Label></span></td>
                                                    </tr>

                                                    <tr style="background-color: rgba(160, 159, 158, 0.39);">
                                                        <th class="text-center">Total</th>
                                                        <td><span class="label" style="background-color: rgba(66, 133, 244, 1);">
                                                            <asp:Label ID="totalPerform" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color: rgba(66, 133, 244, 1);">
                                                            <asp:Label ID="pertotalPerform" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color: rgba(219, 68, 55, 1);">
                                                            <asp:Label ID="totalkMissed" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color: rgba(219, 68, 55, 1);">
                                                            <asp:Label ID="pertotalkMissed" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color: rgba(244, 180, 0, 1);">
                                                            <asp:Label ID="totalClose" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color: rgba(244, 180, 0, 1);">
                                                            <asp:Label ID="pertotalClose" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label label-success">
                                                            <asp:Label ID="totalTotal" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label label-success">
                                                            <asp:Label ID="pertotalTotal" runat="server" Text="100.00%"></asp:Label></span></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <!-- END Widget Main -->
                            </div>
                        </div>
                    </div>
                    <!-- END Large Widget (Active Color Theme Light) -->
                </div>
                <div class="col-md-4">
                    <div class="block">
                        <div class="col-md-12 panel panel-default">
                            <div class="table-responsive">
                                <asp:Literal ID="lblstacked" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div style="clear: both;"></div>
                    </div>
                </div>
            </div>

            <div class="row">

                <div class="col-md-8">
                    <!-- Large Widget (Active Color Theme Light) -->

                    <div class="widget">
                        <div class="widget-advanced widget-advanced-alt">
                            <div class="widget-main" style="padding-top: 0">
                                <h4 class="sub-header" style="margin-top: 0"><strong>Individual </strong>Activity Report</h4>
                                <!-- Widget Main -->
                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="table-responsive">
                                            <table id="reportTableI" class=" text-center table table-vcenter table-condensed table-bordered table-hover">
                                                <thead>
                                                    <tr style="background-color: rgba(160, 159, 158, 0.85);">
                                                        <th class="text-center col-xs-2">Activity</th>
                                                        <th class="text-center col-xs-2" colspan="2">Perform</th>
                                                        <th class="text-center col-xs-2" colspan="2">Missed</th>
                                                        <th class="text-center col-xs-2" colspan="2">Close Postpone</th>
                                                        <th class="text-center col-xs-2" colspan="2">Total</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td class="">Task</td>

                                                        <td><span class="label" style="background-color:rgba(73, 29, 114, 1);">
                                                            <asp:Label ID="taskPerformI" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(73, 29, 114, 1);">
                                                            <asp:Label ID="pertaskPerformI" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(187, 48, 45, 1);">
                                                            <asp:Label ID="taskMissedI" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(187, 48, 45, 1);">
                                                            <asp:Label ID="pertaskMissedI" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(203, 190, 0, 1);">
                                                            <asp:Label ID="taskCloseI" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(203, 190, 0, 1);">
                                                            <asp:Label ID="pertaskCloseI" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(1, 137, 137, 1);">
                                                            <asp:Label ID="taskTotalI" runat="server" Text="Label"></asp:Label>
                                                        </span></td>
                                                        <td><span class="label" style="background-color:rgba(1, 137, 137, 1);">
                                                            <asp:Label ID="pertaskTotalI" runat="server" Text="Label"></asp:Label></span></td>
                                                    </tr>

                                                    <tr>
                                                        <td class="text-center">Sampling/Demo</td>
                                                        <td><span class="label" style="background-color:rgba(73, 29, 114, 1);">
                                                            <asp:Label ID="demoPerformI" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(73, 29, 114, 1);">
                                                            <asp:Label ID="perdemoPerformI" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(187, 48, 45, 1);">
                                                            <asp:Label ID="demoMissedI" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(187, 48, 45, 1);">
                                                            <asp:Label ID="perdemoMissedI" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(203, 190, 0, 1);">
                                                            <asp:Label ID="demoCloseI" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(203, 190, 0, 1);">
                                                            <asp:Label ID="perdemoCloseI" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(1, 137, 137, 1);">
                                                            <asp:Label ID="demoTotalI" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(1, 137, 137, 1);">
                                                            <asp:Label ID="perdemoTotalI" runat="server" Text="Label"></asp:Label></span></td>
                                                    </tr>

                                                    <tr>
                                                        <td class="text-center">Phone & Email</td>
                                                        <td><span class="label" style="background-color:rgba(73, 29, 114, 1);">
                                                            <asp:Label ID="phonePerformI" runat="server"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(73, 29, 114, 1);">
                                                            <asp:Label ID="perphonePerformI" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(187, 48, 45, 1);">
                                                            <asp:Label ID="phoneMissedI" runat="server"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(187, 48, 45, 1);">
                                                            <asp:Label ID="perphoneMissedI" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(203, 190, 0, 1);">
                                                            <asp:Label ID="phoneCloseI" runat="server"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(203, 190, 0, 1);">
                                                            <asp:Label ID="perphoneCloseI" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(1, 137, 137, 1);">
                                                            <asp:Label ID="phoneTotalI" runat="server"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(1, 137, 137, 1);">
                                                            <asp:Label ID="perphoneTotalI" runat="server" Text="Label"></asp:Label></span></td>
                                                    </tr>

                                                    <tr style="background-color: rgba(160, 159, 158, 0.39);">
                                                        <th class="text-center">Total</th>
                                                        <td><span class="label" style="background-color:rgba(73, 29, 114, 1);">
                                                            <asp:Label ID="totalPerformI" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(73, 29, 114, 1);">
                                                            <asp:Label ID="pertotalPerformI" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(187, 48, 45, 1);">
                                                            <asp:Label ID="totalkMissedI" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(187, 48, 45, 1);">
                                                            <asp:Label ID="pertotalkMissedI" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(203, 190, 0, 1);">
                                                            <asp:Label ID="totalCloseI" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(203, 190, 0, 1);">
                                                            <asp:Label ID="pertotalCloseI" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(1, 137, 137, 1);">
                                                            <asp:Label ID="totalTotalI" runat="server" Text="Label"></asp:Label></span></td>
                                                        <td><span class="label" style="background-color:rgba(1, 137, 137, 1);">
                                                            <asp:Label ID="pertotalTotalI" runat="server" Text="100.00%"></asp:Label></span></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <!-- END Widget Main -->
                            </div>
                        </div>
                    </div>
                    <!-- END Large Widget (Active Color Theme Light) -->
                </div>
                <div class="col-md-4">
                    <div class="block">
                        <div class="col-md-12 panel panel-default">
                            <div class="table-responsive">
                                <asp:Literal ID="lblstackedI" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div style="clear: both;"></div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <div class="block remove-margin-bottom">
                        <div class="col-md-12 panel panel-default">
                            <div class="table-responsive">
                                <asp:Literal ID="lblpie" runat="server"></asp:Literal>

                            </div>
                        </div>
                        <div style="clear: both;"></div>
                    </div>
                </div>
                <div class="col-md-8">
                    <!-- Large Widget (Active Color Theme Light) -->

                    <div class="widget">
                        <div class="widget-advanced widget-advanced-alt">

                            <!-- Widget Main -->
                            <div class="widget-main" style="padding-bottom: 0">
                                <h4 class="sub-header remove-margin-bottom "><strong>Team </strong><br /> Conversions / Productivity <small>(<asp:Label ID="lblcMonth1" runat="server"></asp:Label>
                                    )</small></h4>
                                <div class="row text-center">
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblCLead" runat="server"></asp:Label></strong><small>/<asp:Label ID="lblCLeadTarget" runat="server"></asp:Label></small><br />
                                            <small>Leads</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblCProspect" runat="server"></asp:Label></strong><small>/<asp:Label ID="lblCProspectTarget" runat="server"></asp:Label></small><br />
                                            <small>Prospects</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblCAccount" runat="server"></asp:Label></strong><small>/<asp:Label ID="lblCAccountTarget" runat="server"></asp:Label></small><br />
                                            <small>Accounts</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblCProductivity" runat="server"></asp:Label></strong><br />
                                            <small>Productivity(A/P)</small></h3>
                                    </div>
                                </div>
                            </div>
                            <!-- END Widget Main -->
                            <!-- Widget Main -->
                            <div class="widget-main" style="padding-top: 0">
                                <h4 class="sub-header remove-margin-bottom ">Conversions / Productivity <small>(<asp:Label ID="lblLMonth1" runat="server"></asp:Label>)</small></h4>
                                <div class="row text-center">
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblLLead" runat="server"></asp:Label></strong><small>/<asp:Label ID="lblLLeadTarget" runat="server"></asp:Label></small><br />
                                            <small>Leads</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblLProspect" runat="server"></asp:Label></strong><small>/<asp:Label ID="lblLProspectTarget" runat="server"></asp:Label></small><br />
                                            <small>Prospects</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblLAccount" runat="server"></asp:Label></strong><small>/<asp:Label ID="lblLAccountTarget" runat="server"></asp:Label></small><br />
                                            <small>Accounts</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblLProductivity" runat="server"></asp:Label></strong><br />
                                            <small>Productivity(A/P)</small></h3>
                                    </div>
                                </div>
                            </div>
                            <!-- END Widget Main -->
                        </div>
                    </div>
                    <!-- END Large Widget (Active Color Theme Light) -->
                </div>

            </div>

            <div class="row">
                <div class="col-md-4">
                    <div class="block remove-margin-bottom">
                        <div class="col-md-12 panel panel-default">
                            <div class="table-responsive">
                                <asp:Literal ID="lblpieI" runat="server"></asp:Literal>

                            </div>
                        </div>
                        <div style="clear: both;"></div>
                    </div>
                </div>
                <div class="col-md-8">
                    <!-- Large Widget (Active Color Theme Light) -->

                    <div class="widget">
                        <div class="widget-advanced widget-advanced-alt">

                            <!-- Widget Main -->
                            <div class="widget-main" style="padding-bottom: 0">
                                <h4 class="sub-header remove-margin-bottom "><strong>Individual </strong><br /> Conversions / Productivity <small>(<asp:Label ID="lblcMonth1I" runat="server"></asp:Label>
                                    )</small></h4>
                                <div class="row text-center">
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblCLeadI" runat="server"></asp:Label></strong><small>/<asp:Label ID="lblCLeadTargetI" runat="server"></asp:Label></small><br />
                                            <small>Leads</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblCProspectI" runat="server"></asp:Label></strong><small>/<asp:Label ID="lblCProspectTargetI" runat="server"></asp:Label></small><br />
                                            <small>Prospects</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblCAccountI" runat="server"></asp:Label></strong><small>/<asp:Label ID="lblCAccountTargetI" runat="server"></asp:Label></small><br />
                                            <small>Accounts</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblCProductivityI" runat="server"></asp:Label></strong><br />
                                            <small>Productivity(A/P)</small></h3>
                                    </div>
                                </div>
                            </div>
                            <!-- END Widget Main -->
                            <!-- Widget Main -->
                            <div class="widget-main" style="padding-top: 0">
                                <h4 class="sub-header remove-margin-bottom ">Conversions / Productivity <small>(<asp:Label ID="lblLMonth1I" runat="server"></asp:Label>)</small></h4>
                                <div class="row text-center">
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblLLeadI" runat="server"></asp:Label></strong><small>/<asp:Label ID="lblLLeadTargetI" runat="server"></asp:Label></small><br />
                                            <small>Leads</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblLProspectI" runat="server"></asp:Label></strong><small>/<asp:Label ID="lblLProspectTargetI" runat="server"></asp:Label></small><br />
                                            <small>Prospects</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblLAccountI" runat="server"></asp:Label></strong><small>/<asp:Label ID="lblLAccountTargetI" runat="server"></asp:Label></small><br />
                                            <small>Accounts</small></h3>
                                    </div>
                                    <div class="col-xs-3">
                                        <h3 class="animation-hatch"><strong>
                                            <asp:Label ID="lblLProductivityI" runat="server"></asp:Label></strong><br />
                                            <small>Productivity(A/P)</small></h3>
                                    </div>
                                </div>
                            </div>
                            <!-- END Widget Main -->
                        </div>
                    </div>
                    <!-- END Large Widget (Active Color Theme Light) -->
                </div>

            </div>
                  </asp:Panel>
                </div> 
            <center>
            <div>
               
                <br />
                <br />
            </div>
                </center>
           
            <asp:ModalPopupExtender ID="mpe" runat="server" BehaviorID="mpe" PopupControlID="pnlPopup" TargetControlID="btnShow"
                CancelControlID="btnNo">
            </asp:ModalPopupExtender>
            <asp:Panel ID="pnlPopup" runat="server" Style="display: none" DefaultButton="btnreport">
                <div class="modal-dialog modal-sm">
                    <div class="modal-content">
                        <div class="modal-header">
                            <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                            <h3 class="modal-title">
                                Report
                            </h3>
                        </div>
                        <div class="modal-body">
                            <div class="form-group" id="divusername" runat="server" >
                                <label for="example-nf-email">User <span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddluser" runat="server" data-toggle="tooltip" title="User" CssClass="form-control" TabIndex="1"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="remembername" runat="server" ControlToValidate="ddluser" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Please select user name" SetFocusOnError="true" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="example-nf-email">Month <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtmonth" runat="server" placeholder="Month" data-toggle="tooltip" title="Enter Month" TabIndex="2"
                                    CssClass="form-control" TextMode="Month"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="relevel" runat="server" ControlToValidate="txtmonth" Display="Dynamic"  ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Please select Month" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnreport" runat="server" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'calculating...';"
                                UseSubmitBehavior="false" class="btn btn-sm btn-primary" ValidationGroup="MasterGroup" Text="Report" TabIndex="3"></asp:Button>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
          <footer class="clearfix">
            <div class="">
                <div class="">
                    <div class="pull-right">
                        Design credit &#64; <a href="http://www.acaira.com/" target="_blank">Acaira Technologies Pvt.Ltd</a>
                    </div>
                    <div class="pull-left">
                        <span id="year-copy"></span>&nbsp;&copy;&nbsp;<a href="index.aspx" target="_blank">CRM</a>
                    </div>
                </div>
            </div>
        </footer>
    </form>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script>!window.jQuery && document.write(decodeURI('%3Cscript src="js/vendor/jquery-1.11.1.min.js"%3E%3C/script%3E'));</script>

    <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
    <script src="js/vendor/bootstrap.min.js"></script>
    <script src="js/plugins.js"></script>
    <script src="js/app.js"></script>
    
</body>
</html>
