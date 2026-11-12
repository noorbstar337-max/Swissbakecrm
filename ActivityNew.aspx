<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ActivityNew.aspx.vb" Inherits="ActivityNew" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/jquery.min.js"></script>
    <script type="text/javascript">
        function ShowMyModalPopup(Type) {
            debugger;
            try {
                var modal = $find('<%=Activityclose.FindControl("mpclose").ClientID%>');
                var hftype = $find('<%=Activityclose.FindControl("hftype").ClientID%>');
                hftype.value = Type;
               <%-- var modal = $find('<%=Activityclose.FindControl("hftypeid").ClientID%>').value = TypeID;--%>
                modal.show();
            }
            catch (err) {
                alert(err.message);
            }

        }
    </script>
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
    <script>

        jQuery(function ($) {
            var focusedElementId = "";
            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_beginRequest(function (source, args) {
                var fe = document.activeElement;
                if (fe != null) {
                    focusedElementId = fe.id;
                } else {
                    focusedElementId = "";
                }
            });

            prm.add_endRequest(function (source, args) {
                if (focusedElementId != "") {

                    $("#" + focusedElementId).focus();
                    var tmpStr = $("#" + focusedElementId).val();
                    $("#" + focusedElementId).val('');
                    $("#" + focusedElementId).val(tmpStr);
                    document.getElementById('<%=hfBackcount.ClientID %>').value = "1";

                }
            });
        });
    </script>
    <script>
        $(document).ready(function(){
            var text = <%=tabss%>;
            if (text == "0"){
            }
            else{
                $('a:contains("' + text + '")').parent().addClass('active disabled');
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                prm.add_pageLoaded(panelLoaded);
            
                function panelLoaded(sender, args){
                  
                    var text = <%=tabss%>;
                    var value = $("#<%=tab.ClientID%>").val();
                
                    // re-bind your jQuery events here
                    $('a:contains("' + value + '")').parent().addClass('active disabled');

                }
            }

        });
    </script>
    <script type="text/javascript">
        function lkviewclick(id) {

            var a = "";
            // var id= "321";
            // var c = +Prodname;
            $.ajax({
                type: "POST",
                url: "ItemcontrolService.asmx/Encrypt",
                data: '{id: ' + id + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    a = response.d;
                },
                async: false
            });

            window.location.href = "ViewAccount.aspx?Id=" + a;
        }
        function lkEditclick(id, ActivityType, Status, type) {
            ; debugger
            var a = "";
            var p1 = "ActivityTask.aspx?returnurl=";
            var Curr=type;
            $.ajax({
                type: "POST",
                url: "ItemcontrolService.asmx/DoubleEncrypt",
                //data: '{id: ' + id + '}',
                data: '{id: ' + id + ', type: "'+ Curr + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    a = response.d;
                },
                async: false
            });

            if (ActivityType == "Task") {
                // link.Value = "Modifyproposal.aspx";
                p1 = "ActivityTask.aspx?returnurl=";
                //p1 = "~/ActivityTask.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=";
            }
            else if (ActivityType == "Reminder") {
                // link.Value = "Modifyproposal.aspx";
                p1 = "Reminder.aspx?returnurl=";
            }
            else if (ActivityType == "Event") {
                // link.Value = "Modifyproposal.aspx";
                p1 = "ActivityEvent.aspx?returnurl=";
            }
            else if (ActivityType == "Call") {
                // link.Value = "ModifyMPLS.aspx";
                p1 = "ActivityCall.aspx?returnurl=";
            }
            else if (ActivityType == "DSR") {
                // link.Value = "ModifyMPLS.aspx";
                p1 = "dsr.aspx?returnurl=";
            }
            a=a.split(",");
            p1 =  "../" + p1+ a[1]+"&Id="+a[0]
           
            var win = window.open(p1, '_blank');
            win.focus();
            //window.location.href = p1 + a;
        }
    </script>
    <script type="text/javascript">
        function AtLeastOneField_ClientValidate(sender, args) {
            //var txt1 = document.getElementById("<%= txtRelatedType.ClientID%>");
            var txt1 = document.getElementById("<%= ddlrelatedtype.ClientID%>");
            var txt2 = document.getElementById("<%= txtNameColumn.ClientID%>");
            //var txt3 = document.getElementById("<%= txtSubject.ClientID%>");
            var txt3 = document.getElementById("<%= ddlSubject.ClientID%>");
            //var txt4 = document.getElementById("<%= txtActivityType.ClientID%>");
            var txt4 = document.getElementById("<%= ddlActivityType.ClientID%>");
            var txt5 = document.getElementById("<%= txtFrom.ClientID%>");
            var txt6 = document.getElementById("<%= txtTo.ClientID%>");
            //var txt7 = document.getElementById("<%= txtPriority.ClientID%>");
            var txt7 = document.getElementById("<%= ddpriority.ClientID%>");
            //var txt8 = document.getElementById("<%= txtStatus.ClientID%>");
            var txt8 = document.getElementById("<%= ddlStatus.ClientID%>");
            var txt9 = document.getElementById("<%= txtAssignTo.ClientID%>");
            var txt10 = document.getElementById("<%= txtActDescription.ClientID%>");
            args.IsValid = (txt1.value != "Select") || (txt2.value != "" && txt2.value.length >= 3) || (txt3.value != "Select") || (txt4.value != "Select") || (txt5.value != "" && txt5.value.length >= 3) || (txt6.value != "" && txt6.value.length >= 3) || (txt7.value != "Select") || (txt8.value != "Select") || (txt9.value != "" && txt9.value.length >= 3) || (txt10.value != "" && txt10.value.length >= 3);
        }

        function ClearAllFunction() {
            var txt1 = document.getElementById("<%= ddlrelatedtype.ClientID%>");
            var txt2 = document.getElementById("<%= txtNameColumn.ClientID%>");
            var txt3 = document.getElementById("<%= ddlSubject.ClientID%>");
            var txt4 = document.getElementById("<%= ddlActivityType.ClientID%>");
            var txt5 = document.getElementById("<%= txtFrom.ClientID%>");
            var txt6 = document.getElementById("<%= txtTo.ClientID%>");
            var txt7 = document.getElementById("<%= ddpriority.ClientID%>");
            var txt8 = document.getElementById("<%= ddlStatus.ClientID%>");
            var txt9 = document.getElementById("<%= txtAssignTo.ClientID%>");
            var txt10 = document.getElementById("<%= txtActDescription.ClientID%>");
            txt1.value = "Select";
            txt2.value = "";
            txt3.value = "Select";
            txt4.value = "Select";
            txt5.value = "";
            txt6.value = "";
            txt7.value = "Select";
            txt8.value = "Select";
            txt9.value = "";
            txt10.value = "";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hfType" runat="server" />
    <asp:HiddenField ID="hfSearchValue" runat="server" />
    <asp:HiddenField ID="hfExcel" runat="server" />
    <asp:HiddenField ID="deletestatus" runat="server" />
    <asp:HiddenField ID="Hfgridview" runat="server" />
    <asp:HiddenField ID="hftotalrecord" runat="server" />
    <asp:HiddenField ID="hfsearch" runat="server" />
    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>--%>
    <div class="content-header">
        <div class="header-section">
            <h1>
                <i class="hi hi-tasks" style="margin: -8px"></i>Activity<br>
            </h1>
        </div>
    </div>
    <ul class="breadcrumb breadcrumb-top">
        <li><a href="index.aspx">Home</a></li>
        <li>Activity</li>

    </ul>

    <div class="block">
        <div class="block-title">
            <h2><strong>Activity</strong> Detail</h2>
        </div>
        <asp:HiddenField ID="hfcheck" runat="server" />
        <asp:HiddenField ID="hfchanged" runat="server" />
        <div class="row">
            <asp:Panel runat="server" DefaultButton="btnsubmit">
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Related Type</label>
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddlrelatedtype" runat="server" data-toggle="tooltip" title="Related Type" CssClass="form-control ">
                            <asp:ListItem Text="Select Related Type" Value="Select"></asp:ListItem>
                            <asp:ListItem Text="None" Value="None"></asp:ListItem>
                            <asp:ListItem Text="Lead" Value="Lead"></asp:ListItem>
                            <asp:ListItem Text="Prospect" Value="Prospect"></asp:ListItem>
                            <asp:ListItem Text="Account" Value="Account"></asp:ListItem>
                            <asp:ListItem Text="Opportunity" Value="Opportunity"></asp:ListItem>
                            <asp:ListItem Text="Quotation" Value="Quotation"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtRelatedType" runat="server" placeholder="Related Type" data-toggle="tooltip" title="Related Type" Visible="false"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Name</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtNameColumn" runat="server" placeholder="Name" data-toggle="tooltip" title="Name"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Subject</label>
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddlSubject" runat="server" name="example-chosen" data-toggle="tooltip" title="Subject" CssClass="form-control" TabIndex="3">
                            <asp:ListItem Text="Select Subject" Value="Select"></asp:ListItem>
                            <asp:ListItem Text="Chat" Value="Chat"></asp:ListItem>
                            <asp:ListItem Text="Demo" Value="Demo"></asp:ListItem>
                            <asp:ListItem Text="Demonstration" Value="Demonstration"></asp:ListItem>
                            <asp:ListItem Text="Email" Value="Email"></asp:ListItem>
                            <asp:ListItem Text="Email/Phone Call" Value="Email/Phone Call"></asp:ListItem>
                            <asp:ListItem Text="General Call" Value="General Call"></asp:ListItem>
                            <asp:ListItem Text="General Meeting" Value="General Meeting"></asp:ListItem>
                            <asp:ListItem Text="Internal Office Work" Value="Internal Office Work"></asp:ListItem>
                            <asp:ListItem Text="Market Visit" Value="Market Visit"></asp:ListItem>
                            <asp:ListItem Text="Meeting" Value="Meeting"></asp:ListItem>
                            <asp:ListItem Text="New Password Request" Value="New Password Request"></asp:ListItem>
                            <asp:ListItem Text="Order Follow Up" Value="Order Follow Up"></asp:ListItem>
                            <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                            <asp:ListItem Text="Payment Follow Up" Value="Payment Follow Up"></asp:ListItem>
                            <asp:ListItem Text="Phone Call Inbound" Value="Phone Call Inbound"></asp:ListItem>
                            <asp:ListItem Text="Phone Call Outbound" Value="Phone Call Outbound"></asp:ListItem>
                            <asp:ListItem Text="Sales Follow up" Value="Sales Follow up"></asp:ListItem>
                            <asp:ListItem Text="Sales Meeting" Value="Sales Meeting"></asp:ListItem>
                            <asp:ListItem Text="Sample Follow up" Value="Sample Follow up"></asp:ListItem>
                            <asp:ListItem Text="Sampling" Value="Sampling"></asp:ListItem>
                            <asp:ListItem Text="Sampling Demo" Value="Sampling Demo"></asp:ListItem>
                            <asp:ListItem Text="Study & Research" Value="Study & Research"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtSubject" runat="server" placeholder="Subject" data-toggle="tooltip" title="Subject" Visible="false"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both"></div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Activity Type</label>
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddlActivityType" runat="server" CssClass="form-control" data-toggle="tooltip" title="Activity Type">
                            <asp:ListItem Text="Select Type" Value="Select"></asp:ListItem>
                            <asp:ListItem Text="Task" Value="Task"></asp:ListItem>
                            <asp:ListItem Text="Call" Value="Call"></asp:ListItem>
                            <asp:ListItem Text="Event" Value="Event"></asp:ListItem>
                            <asp:ListItem Text="DSR" Value="DSR"></asp:ListItem>
                            <asp:ListItem Text="Reminder" Value="Reminder"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtActivityType" runat="server" placeholder="Activity Type" data-toggle="tooltip" title="Activity Type" Visible="false"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">From</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtFrom" runat="server" placeholder="From" data-toggle="tooltip" title="From" TextMode="Date"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">To</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtTo" runat="server" placeholder="To" data-toggle="tooltip" title="To" TextMode="Date"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both"></div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Priority</label>
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddpriority" runat="server" CssClass="form-control" data-toggle="tooltip" title="Priority">
                            <asp:ListItem Text="Select Priority" Value="Select"></asp:ListItem>
                            <asp:ListItem Text="High" Value="High"></asp:ListItem>
                            <asp:ListItem Text="Highest" Value="Highest"></asp:ListItem>
                            <asp:ListItem Text="Low" Value="Low"></asp:ListItem>
                            <asp:ListItem Text="Lowest" Value="Lowest"></asp:ListItem>
                            <asp:ListItem Text="Normal" Value="Normal"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtPriority" runat="server" placeholder="Priority" data-toggle="tooltip" title="Priority" Visible="false"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Status</label>
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" data-toggle="tooltip" title="Status">
                            <asp:ListItem Text="Select Status" Value="Select"></asp:ListItem>
                            <asp:ListItem Text="Close" Value="Close"></asp:ListItem>
                            <asp:ListItem Text="Close Postpone" Value="Close Postpone"></asp:ListItem>
                            <asp:ListItem Text="Today" Value="Today"></asp:ListItem>
                            <asp:ListItem Text="Tommorrow" Value="Tommorrow"></asp:ListItem>
                            <asp:ListItem Text="Due" Value="Due"></asp:ListItem>
                            <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                            <asp:ListItem Text="Missed" Value="Missed"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtStatus" runat="server" placeholder="Status" data-toggle="tooltip" title="Status" Visible="false"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Assign To</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtAssignTo" runat="server" placeholder="Assign To" data-toggle="tooltip" title="Assign To"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both"></div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Activity Description</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtActDescription" runat="server" placeholder="Activity Description" data-toggle="tooltip" title="Activity Description"
                            CssClass="form-control"></asp:TextBox>
                        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Atleast one field required" ValidationGroup="MasterGroupSearch"
                            CssClass="MasterValidationCSS" Display="Dynamic" OnServerValidate="AtLeastOneField_ServerValidate"
                            ClientValidationFunction="AtLeastOneField_ClientValidate" SetFocusOnError="true"></asp:CustomValidator>

                    </div>
                </div>
                <div class="col-sm-8 text-right">
                    <div class="col-md-12">
                        <asp:LinkButton ID="btnAddReminder" runat="server" class="btn btn-alt btn-xs btn-primary">Add Reminder</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="btnAddDSR" runat="server" class="btn btn-alt btn-xs btn-primary">Add DSR</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                        <button id="btnClearAll1" type="button" class="btn btn-sm btn-warning" style="margin-right: 10px;" onclick="ClearAllFunction()">Clear All</button>
                        <%--<asp:Button ID="btnClearAll" runat="server" Text="Clear All" class="btn btn-sm btn-warning" Style="margin-right: 10px;" />--%>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-sm btn-info pull-right" UseSubmitBehavior="false"
                            OnClientClick="if (!Page_ClientValidate('MasterGroupSearch')){ return false; } this.disabled = true; this.value = 'Searching...';"></asp:Button>
                    </div>
                </div>
            </asp:Panel>
        </div>
        <div class="table-responsive" runat="server" id="divMain" visible="false">
            <div class="row">
                <div class="">

                    <div class="col-md-1">
                        <asp:DropDownList ID="ddpagesize" AutoPostBack="true" runat="server" CssClass="form-control">
                            <asp:ListItem Text="30" Value="30"></asp:ListItem>
                            <asp:ListItem Text="50" Value="50"></asp:ListItem>
                            <asp:ListItem Text="100" Value="100"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                    </div>
                    <div class="col-md-2" runat="server" visible="false">
                        <div class="">
                            <asp:DropDownList ID="ddtasktype" AutoPostBack="true" runat="server" CssClass="form-control">
                                <asp:ListItem Value="All Activities">All Activities</asp:ListItem>
                                <asp:ListItem Value="Reminder">All Reminder</asp:ListItem>
                                <asp:ListItem Value="DSR">All DSR</asp:ListItem>
                                <asp:ListItem Value="Missed">All Missed Activities</asp:ListItem>
                                <%--  <asp:ListItem Value="All Close Activities">All Close Activities</asp:ListItem>
                                    <asp:ListItem Value="All Open Activities">All Open Activities</asp:ListItem>
                                    <asp:ListItem Value="Task">All Task</asp:ListItem>
                                    <asp:ListItem Value="Event">All Sampling/Demo</asp:ListItem>
                                    <asp:ListItem Value="Call">All Phone/Email</asp:ListItem>
                                    - -%>
                                    <asp:ListItem Value="Today Task">All Today Task</asp:ListItem>
                                    <asp:ListItem Value="Today Event">All Today Sampling/Demo</asp:ListItem>
                                    <asp:ListItem Value="Today Call">All Today Phone/Email</asp:ListItem>
                                    <%--<asp:ListItem Value="Today Reminder">All Today Reminder</asp:ListItem>- -%>
                                    <asp:ListItem Value="Due Task">All Due Task</asp:ListItem>
                                    <asp:ListItem Value="Due Event">All Due Sampling/Demo</asp:ListItem>
                                    <asp:ListItem Value="Due Call">All Due Phone/Email</asp:ListItem>
                                    <%--<asp:ListItem Value="Due Reminder">All Due Reminder</asp:ListItem>- -%>
                                    <asp:ListItem Value="Missed Task">All Missed Task</asp:ListItem>
                                    <asp:ListItem Value="Missed Event">All Missed Sampling/Demo</asp:ListItem>
                                    <asp:ListItem Value="Missed Call">All Missed Phone/Email</asp:ListItem>
                                    <%--<asp:ListItem Value="Missed Reminder">All Missed Reminder</asp:ListItem> - -%>
                                    <asp:ListItem Value="Close Postpone Task">All Close Postpone Task</asp:ListItem>
                                    <asp:ListItem Value="Close Postpone Event">All Close Postpone Sampling/Demo</asp:ListItem>
                                    <asp:ListItem Value="Close Postpone Call">All Close Postpone Phone/Email</asp:ListItem>
                                    <%--<asp:ListItem Value="Close Postpone Reminder">All Close Postpone Reminder</asp:ListItem>--%>
                            </asp:DropDownList>

                        </div>
                        <br />
                    </div>

                    <div class="col-sm-6 col-xs-12 pull-right input-group">
                        <div class="pull-right">

                            <%--<asp:Button ID="btnshowall" EnableViewState="false" runat="server" Text="Show All" CssClass="btn btn-alt btn-xs btn-primary" />--%>&nbsp;&nbsp;&nbsp;&nbsp;
                            <%--<asp:LinkButton ID="btnAddReminder" runat="server" class="btn btn-alt btn-xs btn-primary">Add Reminder</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="btnAddDSR" runat="server" class="btn btn-alt btn-xs btn-primary">Add DSR</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;--%>
                            <%-- <asp:LinkButton ID="btntask" runat="server" class="btn btn-alt btn-xs btn-primary">Add Task</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:LinkButton ID="btevent" runat="server" class="btn btn-alt btn-xs btn-primary">Add Sampling/Demo</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:LinkButton ID="btncall" runat="server" class="btn btn-alt btn-xs btn-primary">Add Phone/Email</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;--%>
                        </div>
                        <%--<div id="example-datatable_filter" class="dataTables_filter">
                                <label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtsearch" runat="server" class="form-control" placeholder="Search" /><span class="input-group-addon">
                                            <i class="fa fa-search"></i></span>
                                    </div>
                                </label>
                            </div>--%>
                        <%--<br />--%>
                    </div>

                </div>
            </div>
            <User:ActivityCloseButtonControl ID="Activityclose" runat="server" />
            <asp:UpdatePanel runat="server" ID="rpg">
                <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server">
                        <%--  <asp:UpdatePanel runat="server" ID="rpg">
                    <ContentTemplate>--%>
                        <table id="printtable" class="table table-vcenter table-condensed table-bordered" style="margin-bottom: 0px;">
                            <thead>
                                <tr>
                                    <th id="thView" runat="server" class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">View</th>
                                    <th id="thClose" runat="server" class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Close/Convert</th>
                                    <th id="thEdit" runat="server" class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Edit</th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                        <asp:LinkButton ID="RelatedType" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;">Related Type</asp:LinkButton>
                                    </th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                        <asp:LinkButton ID="Name" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;">Name</asp:LinkButton>
                                    </th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                        <asp:LinkButton ID="Subject" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;">Subject</asp:LinkButton>
                                    </th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                        <asp:LinkButton ID="ActivityType" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;">Activity Type</asp:LinkButton>

                                    </th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                        <asp:LinkButton ID="From1" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;">From</asp:LinkButton>

                                    </th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                        <asp:LinkButton ID="To1" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;">To</asp:LinkButton>

                                    </th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                        <asp:LinkButton ID="Priority" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;">Priority</asp:LinkButton>

                                    </th>

                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                        <asp:LinkButton ID="Status" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;">Status</asp:LinkButton>

                                    </th>
                                    <%--<th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">For</th>--%>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                        <asp:LinkButton ID="AssignTo" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;">AssignTo</asp:LinkButton>

                                    </th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                        <asp:LinkButton ID="Activity_Description" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;">Activity Description</asp:LinkButton>

                                    </th>

                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;" id="thEdit1" runat="server" visible="false">Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="GridView1" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td id="tdView" runat="server" class="text-center">
                                                <%-- <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# "ModifyAccount.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Acc_Id").ToString()))%>'
                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>--%>
                                                <asp:LinkButton ID="lnkview" Height="25" Width="25" runat="server"
                                                    CommandName="Viewing" CommandArgument="<%# CType(Container, RepeaterItem).ItemIndex%>"><i class="fa fa-eye"></i></asp:LinkButton>
                                                <%--<a id="lkView" data-toggle="tooltip" title="Edit" class="btn btn-alt btn-xs btn-primary" onclick='lkEditclick(<%#Eval("ID").ToString()%>)'><i class="fa fa-pencil"></i></a>--%>
                                            </td>
                                            <td id="tdClose" runat="server" class="text-center">
                                                <%-- <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# "ModifyAccount.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Acc_Id").ToString()))%>'
                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>--%>
                                                <asp:LinkButton ID="lnk" runat="server" ToolTip="Close"
                                                    CommandName="Closing" CommandArgument="<%# CType(Container, RepeaterItem).ItemIndex%>"><i class="fa fa-times"></i></asp:LinkButton>
                                                <asp:LinkButton ID="lnkChangeDSR" runat="server" Visible="false" OnClientClick="checkConvert();" ToolTip="Convert to DSR"
                                                    CommandName="ChangeToDSR" CommandArgument="<%# CType(Container, RepeaterItem).ItemIndex%>"><i class="fa fa-share"></i></asp:LinkButton>
                                                <%--<a id="lkClose" data-toggle="tooltip" title="Edit" class="btn btn-alt btn-xs btn-primary" onclick='lkEditclick(<%#Eval("ID").ToString()%>)'><i class="fa fa-pencil"></i></a>--%>
                                            </td>
                                            <td id="tdEdit" runat="server" class="text-center">
                                                <%-- <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# "ModifyAccount.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Acc_Id").ToString()))%>'
                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>--%>
                                                <asp:Label ID="lkedit" runat="server">
                                                        <a id="lkedit1" data-toggle="tooltip" title="Edit" class="btn btn-alt btn-xs btn-primary" onclick='lkEditclick(<%#Eval("ID").ToString()%>,"<%#Eval("ActivityType").ToString()%>","<%#Eval("Status").ToString()%>","<%#Request.Url.AbsoluteUri.ToString()%>")'><i class="fa fa-pencil"></i></a>
                                                </asp:Label>
                                            </td>

                                            <td class="text-center">
                                                <asp:Literal ID="ltrelatedtypeid" runat="server" Text='<%#Eval("Activity_RelatedTypeID")%>' Visible="false"></asp:Literal>
                                                <asp:Literal ID="ltrelatedtype" runat="server" Text='<%#Eval("RelatedType")%>' /></td>
                                            <td class="text-center">
                                                <%--<a id="lkView1" data-toggle="tooltip" title="View" style='cursor: pointer;' onclick='lkviewclick(<%#Eval("Acc_ID").ToString()%>)'>
                                                    </a>--%>
                                                <asp:Literal ID="lblcontact" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Name")))%>' />
                                                <asp:Literal ID="lbluId" runat="server" Text='<%#(Eval("ID"))%>' Visible="false" />
                                            </td>
                                            <%--<td class="text-center">
                                                <asp:Literal ID="lblphone" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Name"))%>' /></td>--%>
                                            <td class="text-center">
                                                <asp:Literal ID="lblSubject" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Subject"))%>' /></td>
                                            <td class="text-center">
                                                <asp:Literal ID="lblActivityType" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("ActivityType"))%>' /></td>
                                            <td class="text-center">
                                                <asp:Literal ID="lblFrom" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("From1"))%>' />
                                            </td>
                                            <%--<td class="text-center">
                                                <asp:Label ID="lblType" runat="server"  Text='<%#Eval("Acc_Type").ToString%>' EnableViewState="false" />
                                            <asp:Literal ID="lblowner" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("U_FirstName")), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                            </td>--%>
                                            <td class="text-center">
                                                <asp:Literal ID="lblowner" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("To1")))%>' />
                                            </td>
                                            <td class="text-center">
                                                <asp:Label ID="Literal1" runat="server" CssClass='<%#(Eval("Class"))%>' Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Priority")))%>' />
                                            </td>
                                            <td class="text-center">
                                                <asp:Label ID="Literal2" runat="server" CssClass='<%#(Eval("Class1"))%>' Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Status")))%>' />
                                            </td>
                                            <td class="text-center">
                                                <asp:Label ID="lblassignto" runat="server" Text='<%#Eval("AssignTo")%>' /></td>
                                            <td class="text-center">
                                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("Activity_Description")%>' /></td>
                                            <%--   <td class="text-center">
                                                <asp:Label ID="lblfrom" runat="server" CssClass='<%#(Eval("Class"))%>' Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_OpenFrom")))%>' />
                                            </td>--%>
                                        </tr>

                                    </ItemTemplate>


                                    <FooterTemplate>
                                        <tr id="trEmpty" runat="server" visible="false">
                                            <td class="dataTables_empty" style="width: 240px;">No matching records found.
                                            </td>
                                        </tr>

                                    </FooterTemplate>
                                </asp:Repeater>
                                <asp:Label ID="Label2" runat="server" Text="No matching records found" Visible="false"></asp:Label>
                                <tfoot style="display: none;">
                                    <tr>
                                        <th class="text-center"></th>
                                        <th class="text-center"><span class="filter_column filter_text">
                                            <asp:TextBox ID="TextBox1" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="Company Name" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                        <th class="text-center"><span class="filter_column filter_text">
                                            <asp:TextBox ID="TextBox2" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="Contact Person" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                        <th class="text-center"><span class="filter_column filter_text">
                                            <asp:TextBox ID="TextBox3" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="Phone" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                        <th class="text-center"><span class="filter_column filter_text">
                                            <asp:TextBox ID="TextBox4" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="Email" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                        <th class="text-center"><span class="filter_column filter_text">
                                            <asp:TextBox ID="TextBox5" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="Mobile" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                        <th class="text-center"><span class="filter_column filter_text">
                                            <asp:TextBox ID="TextBox6" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="City" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                        <th class="text-center"><span class="filter_column filter_text">
                                            <asp:TextBox ID="TextBox9" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="Type" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                        <th class="text-center"><span class="filter_column filter_text">
                                            <asp:TextBox ID="TextBox7" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="Assign To" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                        <th class="text-center" style="display: none;"><span class="filter_column filter_text">
                                            <asp:TextBox ID="TextBox10" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="For" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                        <th class="text-center"><span class="filter_column filter_text">
                                            <asp:TextBox ID="TextBox8" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="From" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>

                                        <th class="text-center"><span class="filter_column filter_text"></span></th>
                                    </tr>
                                </tfoot>


                            </tbody>

                        </table>
                        <asp:HiddenField ID="hfBackcount" runat="server" />
                        <asp:HiddenField ID="tab" runat="server" />
                        <div class="row" style="margin: 0px;">
                            <div class="col-md-12" style="background-color: #f9fafc; padding: 10px 0; border: 1px solid #eaedf1; border-top-width: 0;">
                                <div class="col-sm-5 hidden-xs">
                                    <div class="dataTables_info" role="status" aria-live="polite">
                                        <strong>
                                            <asp:Label ID="lblTcount" runat="server"></asp:Label></strong>

                                    </div>
                                </div>
                                <div class="col-sm-7 col-xs-12 clearfix">
                                    <div class="dataTables_paginate paging_bootstrap" id="example-datatable_paginate">
                                        <ul id="menu" class="pagination pagination-sm remove-margin" style="height: 12px;">

                                            <asp:Repeater ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand" OnItemDataBound="rptPaging_ItemDataBound">

                                                <ItemTemplate>

                                                    <li data-category="TestValue" id="li1">

                                                        <asp:LinkButton ID="btnPage" CssClass="" class="dataTables_paginate paging_bootstrap" data-category="TestValue"
                                                            CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                                                            runat="server" Font-Bold="True"><%# Container.DataItem %>
                                                        </asp:LinkButton>
                                                    </li>
                                                </ItemTemplate>

                                            </asp:Repeater>


                                        </ul>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </asp:Panel>
                </ContentTemplate>
                <Triggers>
                    <%--<asp:AsyncPostBackTrigger ControlID="rpgridview" />
                      <asp:AsyncPostBackTrigger ControlID="rptPaging" />--%>
                    <%-- <asp:AsyncPostBackTrigger ControlID="rptPaging"  EventName="rptPaging_ItemCommand"/>--%>
                </Triggers>

            </asp:UpdatePanel>
        </div>

        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:LinkButton ID="btnfollowupshow" runat="server"></asp:LinkButton>
                <asp:ModalPopupExtender ID="mpefollowup" runat="server" PopupControlID="Panel2" TargetControlID="btnfollowupshow"
                    CancelControlID="btnfollowNo" BackgroundCssClass="pop">
                </asp:ModalPopupExtender>
                <asp:Panel ID="Panel2" runat="server" Style="display: none">
                    <div class="modal-dialog modal-lg" style="overflow-y: scroll; position: fixed; top: 0; bottom: 0; left: 0; right: 0; overflow: auto;">
                        <div class="modal-content" style="top: 1%; overflow-x: hidden; overflow-y: auto; outline: none; margin-top: 0; overflow: visible;">
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
                                            <asp:TemplateField HeaderText="Note Date" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Opportunity_ExpectedDate">
                                                <ItemTemplate>
                                                    <asp:Literal ID="lblcontact" runat="server" Text='<%#((Eval("Date")))%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Opportunity_ExpectedDate">
                                                <ItemTemplate>
                                                    <asp:Literal ID="lblFirstName" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("U_FirstName")))%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Note Text" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Opportunity_ExpectedDate">
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
                <%--<asp:AsyncPostBackTrigger ControlID="GridView1" />--%>
                <asp:AsyncPostBackTrigger ControlID="btnaddnote" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <%--</ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddtasktype" />
        </Triggers>
    </asp:UpdatePanel>--%>
    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <br />
            <div class="divWaiting">
                <i class="fa fa-sun-o fa-spin" id="LoadingUpadatePanel"></i>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

