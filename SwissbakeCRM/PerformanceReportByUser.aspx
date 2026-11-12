<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="PerformanceReportByUser.aspx.vb" Inherits="PerformanceReportByUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .tableftright {
            border-left: #D9416C 1px solid;
            border-right: #D9416C 1px solid;
            BORDER-TOP: #D9416C 1px solid;
            BORDER-BOTTOM: #D9416C 1px solid;
        }

        .Headerfont2 {
            color: #211F1F;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="deletestatus" runat="server" />
    <asp:HiddenField ID="Hfgridview" runat="server" />
    <asp:HiddenField ID="hftotalrecord" runat="server" />
    <asp:HiddenField ID="hfsearch" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="content-header">
                <div class="header-section">
                    <h1>
                        <i class="hi hi-tasks" style="margin: -8px"></i>Performance Report<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li>Performance Report</li>

            </ul>

            <div class="block">
                <div class="block-title">
                    <h2><strong>Performance Report</strong> Detail</h2>
                </div>

                <div class="col-md-12" style="margin-bottom: 28px;">
                    <label class="col-md-1 control-label" for="example-hf-password">User</label>
                    <div class="col-md-3">

                        <asp:DropDownList ID="ddusertype" runat="server" AutoPostBack="true" data-toggle="tooltip" title="User" CssClass="form-control">

                            <%-- <asp:ListItem Value="Account">Account</asp:ListItem>
                                        <asp:ListItem Value="Contact">Contact</asp:ListItem>
                                        <asp:ListItem Value="Potential">Potential</asp:ListItem>
                                        <asp:ListItem Value="Vendor">Vendor</asp:ListItem>
                                        <asp:ListItem Value="Quote">Quote</asp:ListItem>--%>
                        </asp:DropDownList>
                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddrelatedtype" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="Please enter  Task name" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                    </div>
                    <label class="col-md-1 control-label" for="example-hf-password">Duration</label>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="col-md-4">
                                <div class="col-md-12" style="padding: 0px;">
                                    <div class="col-md-6" style="padding: 0px;">
                                        <asp:TextBox ID="txtstartdate" runat="server" class="form-control" TextMode="Date" Text="01-03-2015" />
                                    </div>
                                    <div class="col-md-6" style="padding: 0px;">
                                        <asp:TextBox ID="txtenddate" runat="server" class="form-control" TextMode="Date" />
                                    </div>
                                </div>


                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="ddusertype" />
                            <asp:PostBackTrigger ControlID="btnreport" />
                        </Triggers>
                    </asp:UpdatePanel>

                    <div class="col-md-3">
                        <asp:LinkButton ID="btnreport" runat="server" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" class="btn btn-sm btn-primary"><i class="fa fa-share"></i>Report</asp:LinkButton>
                        <asp:LinkButton ID="btnshow" runat="server" class="btn btn-sm btn-primary">Show All</asp:LinkButton>
                        <%--<asp:ImageButton ID="btnExportExcel" data-toggle="tooltip" title="Export Excel" Style="margin-right: 10px" Width="33px" ImageAlign="Right" runat="server" ImageUrl="~/images/excel.gif" />--%>

                    </div>
                </div>

                <div class="table-responsive">
                    <table id="reportTable" class=" text-center table table-vcenter table-condensed table-bordered table-hover">
                        <thead>
                            <tr style="background-color:rgba(160, 159, 158, 0.85);">
                                <th class="text-center col-xs-2">Activity</th>
                                <th class="text-center col-xs-2">Perform</i></th>
                                <th class="text-center col-xs-2">Missed</th>
                                <th class="text-center col-xs-2">Close Postpone</th>
                                <th class="text-center col-xs-2">Total</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td class="">Task</td>

                                <td><span class="label label-info">
                                    <asp:Label ID="taskPerform" runat="server" Text="Label"></asp:Label></span></td>
                                <td><span class="label label-danger">
                                    <asp:Label ID="taskMissed" runat="server" Text="Label"></asp:Label></span></td>
                                <td><span class="label label-warning">
                                    <asp:Label ID="taskClose" runat="server" Text="Label"></asp:Label></span></td>
                                <td><span class="label label-success">
                                    <asp:Label ID="taskTotal" runat="server" Text="Label"></asp:Label>
                                </span></td>
                            </tr>

                            <tr>
                                <td class="text-center">Sampling/Demo</td>
                                <td><span class="label label-info">
                                    <asp:Label ID="demoPerform" runat="server" Text="Label"></asp:Label></span></td>
                                <td><span class="label label-danger">
                                    <asp:Label ID="demoMissed" runat="server" Text="Label"></asp:Label></span></td>
                                <td><span class="label label-warning">
                                    <asp:Label ID="demoClose" runat="server" Text="Label"></asp:Label></td>
                                <td><span class="label label-success">
                                    <asp:Label ID="demoTotal" runat="server" Text="Label"></asp:Label></span></td>
                            </tr>

                            <tr>
                                <td class="text-center">Phone</td>
                                <td><span class="label label-info">
                                    <asp:Label ID="phonePerform" runat="server"></asp:Label></span></td>
                                <td><span class="label label-danger">
                                    <asp:Label ID="phoneMissed" runat="server"></asp:Label></span></td>
                                <td><span class="label label-warning">
                                    <asp:Label ID="phoneClose" runat="server"></asp:Label></span></td>
                                <td><span class="label label-success">
                                    <asp:Label ID="phoneTotal" runat="server"></asp:Label></span></td>
                            </tr>

                            <tr style="background-color: rgba(160, 159, 158, 0.39);">
                                <th class="text-center">Total</th>
                                <td><span class="label label-info">
                                    <asp:Label ID="totalPerform" runat="server" Text="Label"></asp:Label></span></td>
                                <td><span class="label label-danger">
                                    <asp:Label ID="totalkMissed" runat="server" Text="Label"></asp:Label></span></td>
                                <td><span class="label label-warning">
                                    <asp:Label ID="totalClose" runat="server" Text="Label"></asp:Label></span></td>
                                <td><span class="label label-success">
                                    <asp:Label ID="totalTotal" runat="server" Text="Label"></asp:Label></span></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <br></br>
                <%--percentage table--%>
                <div style="clear: both"></div>

                <div class="table-responsive">
                    <table id="PerreportTable" class=" text-center table table-vcenter table-condensed table-bordered table-hover">
                        <thead>
                            <tr  style="background-color:rgba(160, 159, 158, 0.85);">
                                <th class="text-center col-xs-2">Activity</th>
                                <th class="text-center col-xs-2">Perform</i></th>
                                <th class="text-center col-xs-2">Missed</th>
                                <th class="text-center col-xs-2">Close Postpone</th>
                                <th class="text-center col-xs-2">Total</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td class="">Task</td>

                                <td><span class="label label-info">
                                    <asp:Label ID="pertaskPerform" runat="server" Text="Label"></asp:Label></span></td>
                                <td><span class="label label-danger">
                                    <asp:Label ID="pertaskMissed" runat="server" Text="Label"></asp:Label></span></td>
                                <td><span class="label label-warning">
                                    <asp:Label ID="pertaskClose" runat="server" Text="Label"></asp:Label></span></td>
                                <td><span class="label label-success">
                                    <asp:Label ID="pertaskTotal" runat="server" Text="Label"></asp:Label></span></td>
                            </tr>

                            <tr>
                                <td class="text-center">Sampling/Demo</td>
                                <td><span class="label label-info">
                                    <asp:Label ID="perdemoPerform" runat="server" Text="Label"></asp:Label></span></td>
                                <td><span class="label label-danger">
                                    <asp:Label ID="perdemoMissed" runat="server" Text="Label"></asp:Label></span></td>
                                <td><span class="label label-warning">
                                    <asp:Label ID="perdemoClose" runat="server" Text="Label"></asp:Label></span></td>
                                <td><span class="label label-success">
                                    <asp:Label ID="perdemoTotal" runat="server" Text="Label"></asp:Label></span></td>
                            </tr>

                            <tr>
                                <td class="text-center">Phone</td>
                                <td><span class="label label-info">
                                    <asp:Label ID="perphonePerform" runat="server" Text="Label"></asp:Label></span></td>
                                <td><span class="label label-danger">
                                    <asp:Label ID="perphoneMissed" runat="server" Text="Label"></asp:Label></span></td>
                                <td><span class="label label-warning">
                                    <asp:Label ID="perphoneClose" runat="server" Text="Label"></asp:Label></span></td>
                                <td><span class="label label-success">
                                    <asp:Label ID="perphoneTotal" runat="server" Text="Label"></asp:Label></span></td>
                            </tr>

                            <tr style="background-color: rgba(160, 159, 158, 0.39);">
                                <th class="text-center">Total</th>
                                <td><span class="label label-info">
                                    <asp:Label ID="pertotalPerform" runat="server" Text="Label"></asp:Label></span></td>
                                <td><span class="label label-danger">
                                    <asp:Label ID="pertotalkMissed" runat="server" Text="Label"></asp:Label></span></td>
                                <td><span class="label label-warning">
                                    <asp:Label ID="pertotalClose" runat="server" Text="Label"></asp:Label></span></td>
                                <td><span class="label label-success">
                                    <asp:Label ID="pertotalTotal" runat="server" Text="100.00%"></asp:Label></span></td>
                            </tr>
                        </tbody>
                    </table>
                </div>

            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <br />
            <div class="divWaiting">
                <i class="fa fa-sun-o fa-spin" id="LoadingUpadatePanel"></i>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

