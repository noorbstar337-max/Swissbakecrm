<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="Dashboard.aspx.vb" Inherits="Dashboard" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="http://www.google.com/jsapi" type="text/javascript"></script>
    <script type="text/javascript">
        // Global variable to hold data
        google.load('visualization', '1', { packages: ['corechart'] });
    </script>
    <%-- <script type="text/javascript">


        function LeadBySourceTeam() {
            $(function () {
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    contentType: 'application/json',
                    url: 'Dashboard.aspx/LeadByIndustryByTeam',
                    data: '{}',
                    success:
                        function (response) {
                            drawchart(response.d);
                        },

                    error: function () {
                        alert("Error loading data! Please try again.");
                    }
                });
            })
        }

        function drawchart(dataValues) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Column Name');
            data.addColumn('number', 'Column Value');
            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].Industry_Name, dataValues[i].lead_id]);
            }

            //  Donut Parameter
            var options = {
                title: 'Lead By Industry',
                pieHole: 0.4,
            };


            var chart = new google.visualization.PieChart(document.getElementById('chartdiv'));
            chart.draw(data, options);

            new google.visualization.PieChart(document.getElementById('chartdiv')).
                draw(data, options);
        }
    </script>--%>


    <%--<script type="text/javascript">
        $(function () {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'Dashboard.aspx/GetChartData',
                data: '{}',
                success:
                    function (response) {
                        drawchart(response.d);
                    },

                error: function () {
                    alert("Error loading data! Please try again.");
                }
            });
        })
        function drawchart(dataValues) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Column Name');
            data.addColumn('number', 'Column Value');
            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].Industry_Name, dataValues[i].lead_id]);
            }

            //  Donut Parameter
            var options = {
                title: 'Lead By Industry',
                pieHole: 0.4,
            };


            var chart = new google.visualization.PieChart(document.getElementById('chartdiv'));
            chart.draw(data, options);

            new google.visualization.PieChart(document.getElementById('chartdiv')).
                draw(data, options);
        }
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header">
        <div class="header-section">
            <div class="row">
                <!-- Main Title (hidden on small devices for the statistics to fit hidden-xs hidden-sm) -->
                <div class="col-md-9 col-lg-9">
                    <h1>Dashboard  <strong>
                        <asp:Label ID="lblusername" runat="server" Font-Bold="true"></asp:Label></strong><br>
                        <small></small></h1>
                </div>
                <div class="col-md-3 col-lg-3">
                    Module<br />
                    <asp:DropDownList ID="ddlModule" runat="server" AutoPostBack="true" name="example-chosen" class="form-control">
                        <asp:ListItem Text="Lead" Selected="True" Value="Lead"></asp:ListItem>
                        <asp:ListItem Text="Prospects" Value="Prospects"></asp:ListItem>
                        <asp:ListItem Text="Accounts" Value="Accounts"></asp:ListItem>
                        <asp:ListItem Text="Activity" Value="Activity"></asp:ListItem>
                        <asp:ListItem Text="Order" Value="Order"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
    </div>

    <ul class="breadcrumb breadcrumb-top">
        <li><a href="index.aspx">Home</a></li>
        <li>DashBoard</li>
    </ul>

    <div class="widget">
        <div class="widget-extra themed-background-dark">

            <h4 class="widget-content-light">
                <strong>Search</strong> Information
            </h4>
        </div>
        <div class="widget-extra-full">
            <div class="form-horizontal form-bordered">
                <div class="col-md-12">
                    <br />
                </div>
                <div class="col-md-3">
                    <div class="">
                        <label class="col-md-4 control-label " for="example-hf-password">Start Date<span class="text-danger">*</span></label>
                        <div class="col-md-8 ">
                            <asp:TextBox runat="server" ID="txtStartDate" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="">
                        <label class="col-md-4 control-label" for="example-hf-password">End Date <span class="text-danger">*</span></label>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="txtendDate" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="">
                        <label class="col-md-4 control-label" for="example-hf-password">Type</label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="ddlType" runat="server" name="example-chosen" class="form-control">
                                <asp:ListItem Selected="True" Text="Team" Value="Team"></asp:ListItem>
                                <asp:ListItem Text="Individual" Value="Individual"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="">
                        <label class="col-md-4 control-label" for="example-hf-password">User<span class="text-danger"> *</span></label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="ddluser" runat="server" name="example-chosen" class="form-control"></asp:DropDownList><br />
                            <asp:Button runat="server" OnClick="btnGetReport_Click" CssClass="btn btn-alt btn-sm btn-success " ID="btnGetReport" Text="Submit" />
                        </div>
                    </div>
                </div>
                <div style="clear: both"></div>
                <div class="col-md-12  pull-right">
                </div>
                <div style="clear: both"></div>
            </div>
        </div>
    </div>

    <div class="row">
        <div id ="DivTop1" runat ="server"  class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <div class="widget">
                <div class="widget-extra themed-background-dark-night text-center">
                    <h3 class="widget-content-light">
                        <asp:Literal runat="server" ID="ltrltop1" Text="Total <strong>Lead</strong>"></asp:Literal></h3>
                </div>
                <div class="widget-extra-full text-center">
                    <!-- Jquery Sparkline (initialized in js/pages/widgetsStats.js), for more examples you can check out http://omnipotent.net/jquery.sparkline/#s-about -->
                    <h3><span id="widget-mini-chart-bar1">
                        <asp:Literal ID="ltrltop1count" runat="server" Text=""></asp:Literal></span></h3>
                </div>
            </div>
            <!-- END Widget -->
        </div>
        <div id ="DivTop2" runat ="server"  class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <div class="widget">
                <div class="widget-extra themed-background-dark-default text-center">
                    <h3 class="widget-content-light">
                        <asp:Literal ID="ltrltop2" runat="server" Text="Converted <strong>Lead</strong>"></asp:Literal></h3>
                </div>
                <div class="widget-extra-full text-center">
                    <!-- Jquery Sparkline (initialized in js/pages/widgetsStats.js), for more examples you can check out http://omnipotent.net/jquery.sparkline/#s-about -->
                    <span id="widget-mini-chart-bar2">
                        <h3>
                            <asp:Literal ID="ltrltop2count" runat="server" Text=""></asp:Literal>
                    </h3></span>
                </div>
            </div>
            <!-- END Widget -->
        </div>
        <div id ="DivTop3" runat ="server"  class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <div class="widget">
                <div class="widget-extra themed-background-dark-fire text-center">
                    <h3 class="widget-content-light">
                        <asp:Literal ID="ltrltop3" runat="server" Text="Idle <strong>Lead</strong>"></asp:Literal>
                    </h3>
                </div>
                <div class="widget-extra-full text-center">
                    <!-- Jquery Sparkline (initialized in js/pages/widgetsStats.js), for more examples you can check out http://omnipotent.net/jquery.sparkline/#s-about -->
                    <h3><span id="widget-mini-chart-bar3">
                        <asp:Literal ID="ltrltop3count" runat="server" Text=""></asp:Literal></span></h3>
                </div>
            </div>
            <!-- END Widget -->
        </div>
        <div id ="DivTop4" runat ="server"  class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <div class="widget">
                <div class="widget-extra themed-background-dark-amethyst text-center">
                    <h3 class="widget-content-light">
                        <asp:Literal ID="ltrltop4" runat="server" Text="Junk <strong>Lead</strong>"></asp:Literal>
                    </h3>
                </div>
                <div class="widget-extra-full text-center">
                    <!-- Jquery Sparkline (initialized in js/pages/widgetsStats.js), for more examples you can check out http://omnipotent.net/jquery.sparkline/#s-about -->
                    <h3><span id="widget-mini-chart-bar4">
                        <asp:Literal ID="ltrltop4count" runat="server" Text=""></asp:Literal></span></h3>
                </div>
            </div>
            <!-- END Widget -->
        </div>
    </div>


    <div class="block">
        <div class="block-title">
            <h2><strong>DashBoard</strong> Detail</h2>
        </div>

        <div class="col-sm-6">
            <asp:Literal runat="server" ID="DivLitrl1"></asp:Literal><br />
            &nbsp;
        </div>
        <div class="col-sm-6">
            <asp:Literal runat="server" ID="DivLitrl2"></asp:Literal><br />
            &nbsp;
        </div>
        <div style="clear: both"></div>
        <div class="col-sm-6">
            <asp:Literal runat="server" ID="DivLitrl3"></asp:Literal><br />
            &nbsp;
        </div>
        <div class="col-sm-6">
            <asp:Literal runat="server" ID="DivLitrl4"></asp:Literal><br />
            &nbsp;
        </div>
        <div style="clear: both"></div>
        <div class="col-sm-6">
            <asp:Literal runat="server" ID="DivLitrl5"></asp:Literal><br />
            &nbsp;
        </div>
        <div class="col-sm-6">
            <asp:Literal runat="server" ID="DivLitrl6"></asp:Literal><br />
            &nbsp;
        </div>
        <div style="clear: both"></div>

    </div>
</asp:Content>
