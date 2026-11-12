<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ActivityControl.ascx.vb" Inherits="UserControl_Back_ActivityControl" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<style>
    .example-nf-email {
        padding: 6px;
    }

    .form-group > . {
        padding-bottom: 0px;
    }

    input[type="radio"], input[type="checkbox"] {
        margin: 4px 0 0;
        margin-top: 1px \9;
        line-height: normal;
        margin-left: 10px;
        margin-right: 5px;
    }
</style>
<asp:HiddenField ID="hftype" runat="server" />
<asp:HiddenField ID="hftypeid" runat="server" />
<div class="col-md-12">
    <asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="btnShow"
        CancelControlID="btnNo" BackgroundCssClass="pop">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPopup" runat="server" Style="display: none" DefaultButton="btnsave">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                    <h4 class="modal-title">Add Task</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <span class="text-danger">
                            <label for="example-nf-email">Subject </label>
                        </span>
                        <%-- <asp:TextBox ID="txtsubject" runat="server" placeholder="Enter Subject" data-toggle="tooltip" title="Enter Subject"
                            CssClass="form-control"></asp:TextBox>--%>
                        <asp:DropDownList ID="txtsubject" runat="server" name="example-chosen" data-toggle="tooltip" title="Task" CssClass="form-control" TabIndex="1">
                            <asp:ListItem>Select Subject</asp:ListItem>
                            <asp:ListItem>Meeting</asp:ListItem>
                            <asp:ListItem>Market Visit</asp:ListItem>
                            <asp:ListItem>Study & Research</asp:ListItem>
                            <asp:ListItem>Internal Office Work</asp:ListItem>
                            <asp:ListItem>Order Follow Up</asp:ListItem>
                            <asp:ListItem>Payment Follow Up</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="resubject" runat="server" ControlToValidate="txtsubject" ValidationGroup="TaskMasterGroup" CssClass="MasterValidationCSS"
                            ErrorMessage="Select subject" Display="Dynamic" InitialValue="Select Subject"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        <span>
                            <label for="example-nf-email">Task Date/Time </label>
                        </span>
                        <asp:TextBox ID="txttaskdate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="2" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttaskdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                            ErrorMessage="Please enter date" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <div class="input-group" data-date-format="mm/dd/yyyy">
                            <asp:TextBox ID="txttaskstarttime" runat="server" TextMode="Time" class="form-control text-center" placeholder="From" TabIndex="3" />
                            <span class="input-group-addon" style="font-size: 10px"><i class="fa fa-angle-right"></i></span>
                            <asp:TextBox ID="txttaskendtime" runat="server" TextMode="Time" class="form-control text-center" placeholder="To" TabIndex="4" />
                        </div>
                    </div>

                    <div class="form-group" runat="server" visible="false">
                        <label for="example-nf-email">Due Date </label>
                        <asp:TextBox ID="txtduedate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" />
                    </div>
                    <div class="form-group">
                        <label for="example-nf-email">Priority </label>
                        <asp:DropDownList ID="ddpriority" runat="server" name="example-chosen" class="select-chosen" TabIndex="5">
                            <asp:ListItem>High</asp:ListItem>
                            <asp:ListItem>Highest</asp:ListItem>
                            <asp:ListItem>Low</asp:ListItem>
                            <asp:ListItem>Lowest</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="example-nf-email">
                            Reminder 
                            <asp:CheckBox ID="ckopentaskreminder" runat="server" TabIndex="6" /></label>
                        <asp:TextBox ID="txtopnetaskreminderdate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="7" />
                        <asp:CompareValidator ID="CompareValidator2" runat="server" SetFocusOnError="true" ValidationGroup="TaskMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Reminder date should equal or earlier tahn Task date"  Display="Dynamic" ControlToValidate="txtopnetaskreminderdate" ControlToCompare="txttaskdate" Operator="LessThanEqual" Type="Date"></asp:CompareValidator>
                                        
                    </div>
                    <div class="form-group">
                        <label for="example-nf-email">Reminder Time</label>
                        <asp:TextBox ID="txtopnetaskremindertime" runat="server" TextMode="Time" CssClass="form-control" TabIndex="8" placeholder="From" />
                    </div>

                    <div class="form-group" runat="server" visible="false">
                        <label for="example-nf-email">Owner </label>
                        <asp:DropDownList ID="ddowner" runat="server" name="example-chosen" class="select-chosen">
                            <asp:ListItem>Shahid</asp:ListItem>
                            <asp:ListItem>Admin</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group" runat="server" visible="false">
                        <label for="example-nf-email">Status </label>
                        <asp:DropDownList ID="ddstatus" runat="server" name="example-chosen" data-toggle="tooltip" title="Status" class="select-chosen">
                            <asp:ListItem>Not Started</asp:ListItem>
                            <asp:ListItem>Deferred</asp:ListItem>
                            <asp:ListItem>In Progress</asp:ListItem>
                            <asp:ListItem>Completed</asp:ListItem>
                            <asp:ListItem>Close</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-primary" Text="Save changes" TabIndex="9" ValidationGroup="TaskMasterGroup"></asp:Button>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="mpecall" runat="server" PopupControlID="pnlcall" TargetControlID="btncall"
        CancelControlID="lkcallno" BackgroundCssClass="pop">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlcall" runat="server" Style="display: none" DefaultButton="btncalladd">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <asp:LinkButton ID="lkcallno" class="close" runat="server">&times;</asp:LinkButton>
                    <h4 class="modal-title">Add Phone/Email</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <span class="text-danger">
                            <label for="example-nf-email">Subject </label>
                        </span>
                        <%--<asp:TextBox ID="TextBox1" runat="server" placeholder="Enter Subject" data-toggle="tooltip" title="Enter Subject"
                            CssClass="form-control"></asp:TextBox>--%>
                        <asp:DropDownList ID="TextBox1" runat="server" name="example-chosen" data-toggle="tooltip" title="Call" CssClass="form-control" TabIndex="1">
                            <asp:ListItem>Select Subject</asp:ListItem>
                            <asp:ListItem>Phone Call Inbound</asp:ListItem>
                            <asp:ListItem>Phone Call Outbound</asp:ListItem>
                            <asp:ListItem>Email</asp:ListItem>
                            <asp:ListItem>Others</asp:ListItem>

                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="recallsubject" runat="server" ControlToValidate="TextBox1" ValidationGroup="CallMasterGroup" CssClass="MasterValidationCSS"
                            ErrorMessage="Select subject" Display="Dynamic" InitialValue="Select Subject"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group" style="display: none">
                        <label for="example-nf-email">Call Type </label>
                        <asp:DropDownList ID="ddcalltype" runat="server" CssClass="form-control">
                            <asp:ListItem Value="Inbound" Text="Inbound"></asp:ListItem>
                            <asp:ListItem Value="Outbound" Text="Outbound"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="example-nf-email">Priority </label>
                        <asp:DropDownList ID="ddcallpriority" runat="server" CssClass="form-control" TabIndex="2">
                            <asp:ListItem>High</asp:ListItem>
                            <asp:ListItem>Highest</asp:ListItem>
                            <asp:ListItem>Low</asp:ListItem>
                            <asp:ListItem>Lowest</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group" style="display: none">
                        <label for="example-nf-email">Call Purpose </label>
                        <asp:DropDownList ID="ddcallpurpose" runat="server" CssClass="form-control">
                            <asp:ListItem Value="None" Text="None"></asp:ListItem>
                            <asp:ListItem Value="Prospecting" Text="Prospecting"></asp:ListItem>
                            <asp:ListItem Value="Administrative" Text="Administrative"></asp:ListItem>
                            <asp:ListItem Value="Demo" Text="Demo"></asp:ListItem>
                            <asp:ListItem Value="Project" Text="Project"></asp:ListItem>
                            <asp:ListItem Value="Support" Text="Support"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="example-nf-email">Date/Time </label>
                        <asp:TextBox ID="txtdate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="3" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                            ErrorMessage="Please enter  date"></asp:RequiredFieldValidator>
                        <div class="input-group" data-date-format="mm/dd/yyyy">
                            <asp:TextBox ID="txtstarttime" runat="server" TextMode="Time" class="form-control text-center" TabIndex="4" placeholder="From" Style="padding: 2px 0px;" />
                            <span class="input-group-addon" style="font-size: 10px; min-width: 25px;"><i class="fa fa-angle-right"></i></span>
                            <asp:TextBox ID="txtendtime" runat="server" TextMode="Time" class="form-control text-center" TabIndex="5" placeholder="To" Style="padding: 2px 0px;" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="example-nf-email">
                            Reminder 
                            <asp:CheckBox ID="ckopencallreminder" TabIndex="6" runat="server" /></label>
                        <asp:TextBox ID="txtopencallremindrdate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="7" />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" SetFocusOnError="true" ValidationGroup="CallMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Reminder date should equal or earlier tahn Phone/Email date"  Display="Dynamic" ControlToValidate="txtopencallremindrdate" ControlToCompare="txtdate" Operator="LessThanEqual" Type="Date"></asp:CompareValidator>
                    </div>
                    <div class="form-group">
                        <label for="example-nf-email">Reminder Time</label>
                        <asp:TextBox ID="txtopencallremindrtime" runat="server" TextMode="Time" CssClass="form-control" TabIndex="8" placeholder="From" />                        
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btncalladd" runat="server" class="btn btn-sm btn-primary" Text="Save changes" TabIndex="9" ValidationGroup="CallMasterGroup"></asp:Button>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="mpeevent" runat="server" PopupControlID="pnlevent" TargetControlID="btnevent"
        CancelControlID="lkeventno" BackgroundCssClass="pop">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlevent" runat="server" Style="display: none" DefaultButton="btneventsave">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <asp:LinkButton ID="lkeventno" class="close" runat="server">&times;</asp:LinkButton>
                    <h4 class="modal-title">Add Sampling/Demo</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <span class="text-danger">
                            <label for="example-nf-email">Subject </label>
                        </span>
                        <%--<asp:TextBox ID="txteventname" runat="server" placeholder="Enter Event Name" data-toggle="tooltip" title="Enter Event Name"
                            CssClass="form-control"></asp:TextBox>--%>
                        <asp:DropDownList ID="txteventname" runat="server" name="example-chosen" data-toggle="tooltip" title="Event" CssClass="form-control" TabIndex="1">
                            <asp:ListItem>Select Subject</asp:ListItem>
                            <asp:ListItem>Sampling</asp:ListItem>
                            <asp:ListItem>Demonstration</asp:ListItem>
                            <asp:ListItem>Exhibition</asp:ListItem>
                            <asp:ListItem>Others</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rename" runat="server" ControlToValidate="txteventname" ValidationGroup="EventMasterGroup" CssClass="MasterValidationCSS"
                            ErrorMessage="Select Subject" InitialValue="Select Subject"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-horizontal form-bordered">
                        <div class="col-md-6">
                            <div class="">
                                <label class="col-md-2 control-label" for="example-hf-email">From</label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtfromdate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="2" />
                                     <asp:CompareValidator ID="CompareValidator3" runat="server" SetFocusOnError="true" ValidationGroup="EventMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="From date should equal or earlier tahn To date"  Display="Dynamic" ControlToValidate="txtfromdate" ControlToCompare="txttodate" Operator="LessThanEqual" Type="Date"></asp:CompareValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="">
                                <div class="col-md-10">
                                    <asp:TextBox ID="txtfromtime" runat="server" TextMode="Time" CssClass="form-control" TabIndex="3"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div style="clear: both"></div>
                        <div class="col-md-6">
                            <div class="">
                                <label class="col-md-2 control-label" for="example-hf-email">To</label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txttodate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="4" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="">
                                <div class="col-md-10">
                                    <asp:TextBox ID="txttotime" runat="server" TextMode="Time" CssClass="form-control" TabIndex="5"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br />
                    </div>
                    <div style="clear: both"></div>
                    <div class="form-group">
                        <label for="example-nf-email">
                            Reminder 
                            <asp:CheckBox ID="ckopeneventreminder" runat="server" TabIndex="7" /></label>
                        <asp:TextBox ID="txtopeneventreminderdate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="8" />
                         <asp:CompareValidator ID="CompareValidator4" runat="server" SetFocusOnError="true" ValidationGroup="EventMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Reminder date should equal or earlier tahn From date"  Display="Dynamic" ControlToValidate="txtopeneventreminderdate" ControlToCompare="txtfromdate" Operator="LessThanEqual" Type="Date"></asp:CompareValidator>
                    </div>
                    <div class="form-group">
                        <label for="example-nf-email">Reminder Time</label>
                        <asp:TextBox ID="txtopeneventremindertime" runat="server" TextMode="Time" CssClass="form-control" TabIndex="9" placeholder="From" />                       
                    </div>
                    <div class="form-group">
                        <label for="example-nf-email">Sampling/Demo Location </label>
                        <asp:TextBox ID="txtlocation" runat="server" placeholder="Enter Location" TabIndex="10" data-toggle="tooltip" title="Enter Location"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="example-nf-email">Priority </label>
                        <asp:DropDownList ID="ddeventprioritys" runat="server" TabIndex="11" CssClass="form-control">
                            <asp:ListItem>High</asp:ListItem>
                            <asp:ListItem>Highest</asp:ListItem>
                            <asp:ListItem>Low</asp:ListItem>
                            <asp:ListItem>Lowest</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group" style="display: none">
                        <label for="example-nf-email">Host </label>
                        <asp:DropDownList ID="ddhost" runat="server" data-toggle="tooltip" title="Host" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btneventsave" runat="server" class="btn btn-sm btn-primary" TabIndex="12" Text="Save changes" ValidationGroup="EventMasterGroup"></asp:Button>
                </div>
            </div>
        </div>
    </asp:Panel>
    <div id="faq2" class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title"><a class="panel-collapse collapse in" data-toggle="collapse" data-parent="#faq2" href="#faq2_q1">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Label ID="lblactivity" runat="server" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="GridView1" />
                            <asp:AsyncPostBackTrigger ControlID="btncloseyes" />
                            <asp:PostBackTrigger ControlID="btneventsave" />
                            <asp:PostBackTrigger ControlID="btncalladd" />
                            <asp:PostBackTrigger ControlID="btnsave" />
                        </Triggers>
                    </asp:UpdatePanel></h4>
            </div>
            <div id="faq2_q1" class="panel-collapse collapse">
                <div class="panel-body">
                    <div class="">
                        <div class="col-md-8" style="margin-left: -12px; margin-bottom: 10px;">
                            <asp:LinkButton ID="btnShow" runat="server" CssClass="btn btn-alt btn-xs btn-primary">New Task</asp:LinkButton>&nbsp;&nbsp;
    <asp:LinkButton ID="btnevent" runat="server" CssClass="btn btn-alt btn-xs btn-primary">New Sampling/Demo</asp:LinkButton>&nbsp;&nbsp;
    <asp:LinkButton ID="btncall" runat="server" CssClass="btn btn-alt btn-xs btn-primary">New Phone/Email</asp:LinkButton>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:LinkButton ID="lkopendemo" runat="server"></asp:LinkButton>

                                <asp:ModalPopupExtender ID="mpclose" runat="server" PopupControlID="Panel1" TargetControlID="lkopendemo"
                                    CancelControlID="lkclose">
                                </asp:ModalPopupExtender>
                                <asp:Panel ID="Panel1" runat="server" Style="display: none">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <asp:LinkButton ID="lkclose" class="close" runat="server">&times;</asp:LinkButton>
                                                <h5 class="modal-title">Activity Closing</h5>
                                            </div>
                                            <div class="modal-body">
                                                <div class="form-group">
                                                    <asp:RadioButtonList ID="rdcloselist" AutoPostBack="true" runat="server" CellPadding="10" CellSpacing="10" RepeatColumns="3" RepeatDirection="Horizontal" TextAlign="right">
                                                        <asp:ListItem Text="Close Success" Value="Close"></asp:ListItem>
                                                        <asp:ListItem Text="Close Follow Up" Value="FollowUp"></asp:ListItem>
                                                        <asp:ListItem Text="Close Postpone" Value="Postpone"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <div class="form-group" id="divremark" runat="server" visible="false">
                                                    <label for="example-nf-email">Result </label>
                                                    <asp:TextBox ID="txtremark" runat="server" placeholder="Enter Result" TabIndex="1" TextMode="MultiLine" Rows="4" Columns="4" data-toggle="tooltip" title="Enter Result"
                                                        CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18"  runat="server" ControlToValidate="txtremark" ValidationGroup="FollowSuccessMasterGroup" CssClass="MasterValidationCSS"
                                                            ErrorMessage="Enter Result" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group" id="dvresult" visible="false" runat="server">
                                                    <label for="example-nf-email">Result </label>
                                                    <asp:TextBox ID="txtdvresult" runat="server" TabIndex="1" placeholder="Enter Result" TextMode="MultiLine" Rows="1" Columns="1" data-toggle="tooltip" title="Enter Result"
                                                        CssClass="form-control"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="rqdvresult"  runat="server" ControlToValidate="txtdvresult" ValidationGroup="FollowTaskMasterGroup" CssClass="MasterValidationCSS"
                                                            ErrorMessage="Enter Result" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group">
                                                    <asp:DropDownList ID="ddtype" Visible="false" runat="server" TabIndex="1" AutoPostBack="true" CssClass="form-control">
                                                        <asp:ListItem Value="Task" Text="Task"></asp:ListItem>
                                                        <asp:ListItem Value="Event" Text="Sampling/Demo"></asp:ListItem>
                                                        <asp:ListItem Value="Call" Text="Call/Email"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-12">
                                                    <br />
                                                </div>
                                                <div id="divtask" runat="server" visible="false">
                                                    <div style="clear: both"></div>
                                                    <div class="col-sm-6">
                                                        <span class="text-danger">
                                                            <label for="example-nf-email">Subject </label>
                                                        </span>
                                                        <asp:DropDownList ID="txtfollowupsubject" runat="server" name="example-chosen" data-toggle="tooltip" title="Task" CssClass="form-control" TabIndex="2">
                                                            <asp:ListItem>Select Subject</asp:ListItem>
                                                            <asp:ListItem>Meeting</asp:ListItem>
                                                            <asp:ListItem>Market Visit</asp:ListItem>
                                                            <asp:ListItem>Study & Research</asp:ListItem>
                                                            <asp:ListItem>Internal Office Work</asp:ListItem>
                                                            <asp:ListItem>Order Follow Up</asp:ListItem>
                                                            <asp:ListItem>Payment Follow Up</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="Select Subject" runat="server" ControlToValidate="txtfollowupsubject" ValidationGroup="FollowTaskMasterGroup" CssClass="MasterValidationCSS"
                                                            ErrorMessage="Select Subject" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <span>
                                                            <label for="example-nf-email">Priority</label>
                                                        </span>
                                                        <asp:DropDownList ID="ddfollowpriority" runat="server" CssClass="form-control" data-toggle="tooltip" title="Priority" TabIndex="3">
                                                            <asp:ListItem>High</asp:ListItem>
                                                            <asp:ListItem>Highest</asp:ListItem>
                                                            <asp:ListItem>Low</asp:ListItem>
                                                            <asp:ListItem>Lowest</asp:ListItem>
                                                            <asp:ListItem>Normal</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txttaskdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                            ErrorMessage="Please enter task name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <span>
                                                            <label for="example-nf-email">Task Date </label>
                                                        </span>
                                                        <asp:TextBox ID="txtfollowtaskdate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="4" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txttaskdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                            ErrorMessage="Please enter task name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <label for="example-nf-email">Task Time </label>
                                                        <div class="input-group" data-date-format="mm/dd/yyyy">
                                                            <asp:TextBox ID="txtfollowstart" runat="server" TextMode="Time" class="form-control text-center" TabIndex="5" placeholder="From" />
                                                            <span class="input-group-addon" style="font-size: 10px;"><i class="fa fa-angle-right"></i></span>
                                                            <asp:TextBox ID="txtfollowend" runat="server" TextMode="Time" class="form-control text-center" TabIndex="6" placeholder="To" />

                                                        </div>
                                                    </div>
                                                    <div style="clear: both"></div>
                                                    <div class="col-sm-6">
                                                        <span>
                                                            <label for="example-nf-email">Reminder</label>
                                                        </span>
                                                        <div class="col-sm-12">
                                                            <div class="col-sm-2">
                                                                <asp:CheckBox ID="cktaskreminder" runat="server" TabIndex="7" />
                                                            </div>
                                                            <div class="col-sm-10">
                                                                <asp:TextBox ID="txttaskreminderdate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="8" />
                                                                 <asp:CompareValidator ID="CompareValidator5" runat="server" SetFocusOnError="true" ValidationGroup="CallMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Reminder date should equal or earlier tahn Task date"  Display="Dynamic" ControlToValidate="txttaskreminderdate" ControlToCompare="txtfollowtaskdate" Operator="LessThanEqual" Type="Date"></asp:CompareValidator>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtfollowtaskdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                                    ErrorMessage="Please enter task name" SetFocusOnError="true"></asp:RequiredFieldValidator>                                                                
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <label for="example-nf-email">Reminder Time </label>
                                                        <asp:TextBox ID="txttaskremindertime" runat="server" TextMode="Time" CssClass="form-control" TabIndex="9" placeholder="From" />
                                                    </div>
                                                    <div style="clear: both"></div>
                                                </div>
                                                <div id="divcall" runat="server" visible="false">
                                                    <div style="clear: both"></div>
                                                    <div class="col-sm-6">
                                                        <span class="text-danger">
                                                            <label for="example-nf-email">Subject </label>
                                                        </span>
                                                        <asp:DropDownList ID="txtcallsubject" runat="server" name="example-chosen" data-toggle="tooltip" title="Task" CssClass="form-control" TabIndex="2">
                                                            <asp:ListItem>Select Subject</asp:ListItem>
                                                            <asp:ListItem>Phone Call Inbound</asp:ListItem>
                                                            <asp:ListItem>Phone Call Outbound</asp:ListItem>
                                                            <asp:ListItem>Email</asp:ListItem>
                                                            <asp:ListItem>Others</asp:ListItem>

                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" InitialValue="Select Subject" ControlToValidate="txtcallsubject" ValidationGroup="CallTaskMasterGroup" CssClass="MasterValidationCSS"
                                                            ErrorMessage="Select Subject"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <span>
                                                            <label for="example-nf-email">Priority</label>
                                                        </span>
                                                        <asp:DropDownList ID="ddfollowcallpriority" runat="server" CssClass="form-control" data-toggle="tooltip" title="Priority" TabIndex="3">
                                                            <asp:ListItem>High</asp:ListItem>
                                                            <asp:ListItem>Highest</asp:ListItem>
                                                            <asp:ListItem>Low</asp:ListItem>
                                                            <asp:ListItem>Lowest</asp:ListItem>
                                                            <asp:ListItem>Normal</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txttaskdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                            ErrorMessage="Please enter task name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-sm-4" style="display: none">
                                                        <span class="text-danger">
                                                            <label for="example-nf-email">Call Type </label>
                                                        </span>
                                                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Inbound" Text="Inbound"></asp:ListItem>
                                                            <asp:ListItem Value="Outbound" Text="Outbound"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-sm-4" style="display: none">
                                                        <span class="text-danger">
                                                            <label for="example-nf-email">Call Type </label>
                                                        </span>
                                                        <asp:DropDownList ID="ddfollowcalltype" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Inbound" Text="Inbound"></asp:ListItem>
                                                            <asp:ListItem Value="Outbound" Text="Outbound"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-sm-4" style="display: none">
                                                        <label for="example-nf-email">Call Purpose </label>
                                                        <asp:DropDownList ID="ddfollowcallpurpose" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="None" Text="None"></asp:ListItem>
                                                            <asp:ListItem Value="Prospecting" Text="Prospecting"></asp:ListItem>
                                                            <asp:ListItem Value="Administrative" Text="Administrative"></asp:ListItem>
                                                            <asp:ListItem Value="Demo" Text="Demo"></asp:ListItem>
                                                            <asp:ListItem Value="Project" Text="Project"></asp:ListItem>
                                                            <asp:ListItem Value="Support" Text="Support"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div style="clear: both"></div>
                                                    <div class="col-sm-4">
                                                        <label for="example-nf-email">Date</label>
                                                        <asp:TextBox ID="txtfollowcalldate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="4" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                            ErrorMessage="Please enter  Task name"></asp:RequiredFieldValidator>

                                                    </div>
                                                    <div class="col-sm-8">
                                                        <label for="example-nf-email">Time</label>
                                                        <div class="input-group" data-date-format="mm/dd/yyyy">
                                                            <asp:TextBox ID="txtfollowcallstart" runat="server" TextMode="Time" class="form-control text-center" placeholder="From" TabIndex="5" Style="padding: 2px 0px;" />
                                                            <span class="input-group-addon" style="font-size: 10px; min-width: 25px;"><i class="fa fa-angle-right"></i></span>
                                                            <asp:TextBox ID="txtfollowcallend" runat="server" TextMode="Time" class="form-control text-center" placeholder="To" TabIndex="6" Style="padding: 2px 0px;" />
                                                        </div>
                                                    </div>
                                                    <div style="clear: both"></div>
                                                    <div class="col-sm-6">
                                                        <span>
                                                            <label for="example-nf-email">Reminder</label>
                                                        </span>
                                                        <div class="col-sm-12">
                                                            <div class="col-sm-2">
                                                                <asp:CheckBox ID="ckcallreminder" runat="server" TabIndex="7" />
                                                            </div>
                                                            <div class="col-sm-10">
                                                                <asp:TextBox ID="txtcallreminderdate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="8" />
                                                                <asp:CompareValidator ID="CompareValidator6" runat="server" SetFocusOnError="true" ValidationGroup="CallMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Reminder date should equal or earlier tahn Phone/Email date"  Display="Dynamic" ControlToValidate="txtcallreminderdate" ControlToCompare="txtfollowcalldate" Operator="LessThanEqual" Type="Date"></asp:CompareValidator>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtfollowtaskdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                                    ErrorMessage="Please enter task name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <label for="example-nf-email">Reminder Time </label>
                                                        <asp:TextBox ID="txtcallremindertime" runat="server" TextMode="Time" CssClass="form-control" TabIndex="9" placeholder="From" />
                                                    </div>
                                                </div>
                                                <div id="divevent" runat="server" visible="false">
                                                    <div style="clear: both"></div>
                                                    <div class="col-sm-6">
                                                        <span class="text-danger">
                                                            <label for="example-nf-email">Subject</label>
                                                        </span>
                                                        <asp:DropDownList ID="txtfolloweventname" runat="server" name="example-chosen" data-toggle="tooltip" title="Task" CssClass="form-control" TabIndex="2">
                                                            <asp:ListItem>Select Subject</asp:ListItem>
                                                            <asp:ListItem>Sampling</asp:ListItem>
                                                            <asp:ListItem>Demonstration</asp:ListItem>
                                                            <asp:ListItem>Exhibition</asp:ListItem>
                                                            <asp:ListItem>Others</asp:ListItem>

                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" InitialValue="Select Subject" ControlToValidate="txtfolloweventname" ValidationGroup="FollowEventMasterGroup" CssClass="MasterValidationCSS"
                                                            ErrorMessage="Select Subject"></asp:RequiredFieldValidator>

                                                    </div>
                                                    <div class="col-sm-6">
                                                        <span>
                                                            <label for="example-nf-email">Priority </label>
                                                        </span>
                                                        <asp:DropDownList ID="ddeventfollowpriority" runat="server" CssClass="form-control" data-toggle="tooltip" title="Priority" TabIndex="3">
                                                            <asp:ListItem>High</asp:ListItem>
                                                            <asp:ListItem>Highest</asp:ListItem>
                                                            <asp:ListItem>Low</asp:ListItem>
                                                            <asp:ListItem>Lowest</asp:ListItem>
                                                            <asp:ListItem>Normal</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <span>
                                                            <label for="example-nf-email">Sampling/Demo Location </label>
                                                        </span>
                                                        <asp:TextBox ID="txtfollowlocation" runat="server" placeholder="Enter Location" data-toggle="tooltip" title="Enter Location"
                                                            CssClass="form-control" TabIndex="4"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txttaskdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                            ErrorMessage="Please enter task name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </div>

                                                    <div style="clear: both"></div>
                                                    <div class="col-sm-6">
                                                        <span>
                                                            <label for="example-nf-email">From </label>
                                                        </span>
                                                        <asp:TextBox ID="txtfollowfrom" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="5" />
                                                        <asp:CompareValidator ID="CompareValidator7" runat="server" SetFocusOnError="true" ValidationGroup="CallMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Reminder date should equal or earlier tahn To date"  Display="Dynamic" ControlToValidate="txtfollowfrom" ControlToCompare="txtfollowto" Operator="LessThanEqual" Type="Date"></asp:CompareValidator>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txttaskdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                            ErrorMessage="Please enter task name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <span>
                                                            <label for="example-nf-email">From Time </label>
                                                        </span>
                                                        <asp:TextBox ID="txtfollowfromtime" runat="server" TextMode="Time" CssClass="form-control" TabIndex="6"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txttaskdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                            ErrorMessage="Please enter task name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <span>
                                                            <label for="example-nf-email">To </label>
                                                        </span>
                                                        <asp:TextBox ID="txtfollowto" runat="server" TextMode="Date" CssClass="form-control" TabIndex="7" placeholder="mm/dd/yy" />
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <span>
                                                            <label for="example-nf-email">To Time </label>
                                                        </span>
                                                        <asp:TextBox ID="txtfollowtotime" runat="server" TextMode="Time" TabIndex="8" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                    <div style="clear: both"></div>
                                                    <div class="col-sm-6">
                                                        <span>
                                                            <label for="example-nf-email">Reminder</label>
                                                        </span>
                                                        <div class="col-sm-12">
                                                            <div class="col-sm-2">
                                                                <asp:CheckBox ID="ckeventreminder" runat="server" TabIndex="9" />
                                                            </div>
                                                            <div class="col-sm-10">
                                                                <asp:TextBox ID="txteventreminderdate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="10" />
                                                                <asp:CompareValidator ID="CompareValidator8" runat="server" SetFocusOnError="true" ValidationGroup="CallMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Reminder date should equal or earlier tahn From date"  Display="Dynamic" ControlToValidate="txteventreminderdate" ControlToCompare="txtfollowfrom" Operator="LessThanEqual" Type="Date"></asp:CompareValidator>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtfollowtaskdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                                    ErrorMessage="Please enter task name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <label for="example-nf-email">Reminder Time </label>
                                                        <asp:TextBox ID="txteventremindertime" runat="server" TextMode="Time" CssClass="form-control" TabIndex="11" placeholder="From" />
                                                    </div>
                                                </div>
                                                <div id="divpostpone" runat="server" visible="false">
                                                    <div class="col-sm-6">
                                                        <span>
                                                            <label for="example-nf-email">Postpone Date </label>
                                                        </span>
                                                        <asp:TextBox ID="txtpostponedate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="1" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txttaskdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                            ErrorMessage="Please enter task name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <label for="example-nf-email">Postpone Time </label>
                                                        <div class="input-group" data-date-format="mm/dd/yyyy">
                                                            <asp:TextBox ID="txtpostponestart" runat="server" TextMode="Time" class="form-control text-center" TabIndex="2" placeholder="From" />
                                                            <span class="input-group-addon" style="font-size: 10px;"><i class="fa fa-angle-right"></i></span>
                                                            <asp:TextBox ID="txtpostponeend" runat="server" TextMode="Time" class="form-control text-center" TabIndex="3" placeholder="To" />
                                                        </div>
                                                    </div>
                                                    <div style="clear: both"></div>
                                                    <div class="col-sm-6">
                                                        <span>
                                                            <label for="example-nf-email">Reminder</label>
                                                        </span>
                                                        <div class="col-sm-12">
                                                            <div class="col-sm-2">
                                                                <asp:CheckBox ID="ckpostponereminder" runat="server" TabIndex="4" />
                                                            </div>
                                                            <div class="col-sm-10">
                                                                <asp:TextBox ID="txtpostreminderdate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="5" />
                                                                 <asp:CompareValidator ID="CompareValidator9" runat="server" SetFocusOnError="true" ValidationGroup="CallMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Reminder date should equal or earlier tahn Postpone date"  Display="Dynamic" ControlToValidate="txtpostreminderdate" ControlToCompare="txtpostponedate" Operator="LessThanEqual" Type="Date"></asp:CompareValidator>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtfollowtaskdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                                    ErrorMessage="Please enter task name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <label for="example-nf-email">Reminder Time </label>
                                                        <asp:TextBox ID="txtpostremindertime" runat="server" TextMode="Time" CssClass="form-control" TabIndex="6" placeholder="From" />
                                                    </div>
                                                </div>
                                                <div style="clear: both"></div>
                                                <div class="modal-footer" id="divfollowup" runat="server" visible="false">
                                                    <asp:Button ID="btnfollowsave" runat="server" class="btn btn-sm btn-primary" TabIndex="12" Text="Save changes" ValidationGroup="FollowTaskMasterGroup"></asp:Button>
                                                </div>
                                                <div class="modal-footer" id="divpostponesave" runat="server" visible="false">
                                                    <asp:Button ID="btnpostponesave" TabIndex="7" runat="server" class="btn btn-sm btn-primary" Text="Save changes" ValidationGroup="Postponegroup"></asp:Button>
                                                </div>
                                            </div>
                                            <div class="modal-footer" id="divremarkfooter" runat="server" visible="false">
                                                <asp:Button ID="btncloseyes" TabIndex="2" runat="server" class="btn btn-alt btn-primary" ValidationGroup="FollowSuccessMasterGroup" Text="Yes"></asp:Button>
                                                <asp:Button ID="btclosenno" TabIndex="3" runat="server" class="btn btn-alt btn-danger" Text="No"></asp:Button>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="GridView1" />
                                <asp:AsyncPostBackTrigger ControlID="rdcloselist" />
                                <asp:PostBackTrigger ControlID="btnfollowsave" />
                                <asp:AsyncPostBackTrigger ControlID="ddtype" />
                                <asp:PostBackTrigger ControlID="btnpostponesave" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="upactivitygrid" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="table-responsive">
                                    <asp:HiddenField ID="hfactivityid" runat="server" />
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" CellPadding="0" CellSpacing="0" DataKeyNames="Id" AllowSorting="true" HeaderStyle-Font-Size="Smaller"
                                        CssClass="table table-borderless table-striped" PageSize="5" GridLines="Horizontal" BorderWidth="0px" Width="100%" Font-Size="Small" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true"
                                        AllowPaging="True">
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
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="10px" ItemStyle-CssClass="MasterGridviewItem">
                                                <HeaderTemplate>
                                                    <asp:HyperLink ID="HyperLink2" runat="server">Edit</asp:HyperLink>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div class="btn-group btn-group-xs">
                                                        <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Page.ResolveUrl("ActivityTask.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Id").ToString())))%>'
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
                                <asp:AsyncPostBackTrigger ControlID="GridView1" />
                                <asp:AsyncPostBackTrigger ControlID="btncloseyes" />
                                <asp:PostBackTrigger ControlID="btneventsave" />
                                <asp:PostBackTrigger ControlID="btncalladd" />
                                <asp:PostBackTrigger ControlID="btnsave" />
                                <%-- <asp:AsyncPostBackTrigger ControlID="btnsave" />--%>
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:LinkButton ID="btnfollowupshow" runat="server"></asp:LinkButton>
            <asp:ModalPopupExtender ID="mpefollowup" runat="server" PopupControlID="Panel2" TargetControlID="btnfollowupshow"
                CancelControlID="btnfollowNo" BackgroundCssClass="pop">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel2" runat="server" Style="display: none" DefaultButton="btnsave">
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


                            <%--<div class="col-sm-12">
                                                <a>
                                                    <asp:Label ID="lblconatctddt" runat="server" Text="Contact Detail"></asp:Label></a>:--<b><asp:Literal ID="lblconatctd" runat="server"></asp:Literal></b>
                                            </div>--%>

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
            <asp:AsyncPostBackTrigger ControlID="GridView1" />
            <asp:AsyncPostBackTrigger ControlID="btnaddnote" />
            <asp:PostBackTrigger ControlID="btnfollowsave" />
            <asp:AsyncPostBackTrigger ControlID="ckcreatefollowupactvt" />
            <asp:AsyncPostBackTrigger ControlID="ddtype" />
            <asp:AsyncPostBackTrigger ControlID="GridView2" />
        </Triggers>
    </asp:UpdatePanel>
</div>
<div class="col-md-12">
    <div id="faq4" class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title"><a class="accordion-toggle" data-toggle="collapse" data-parent="#faq4" href="#faq4_q2">
                    <asp:Label ID="lblcloseactivity" runat="server"></asp:Label></a></h4>
            </div>
            <div id="faq4_q2" class="panel-collapse collapse">
                <div class="panel-body">
                    <div class="">
                        <!-- Twitter Title -->
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="table-responsive">
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="true" CellPadding="0" CellSpacing="0" DataKeyNames="Id" AllowSorting="true" HeaderStyle-Font-Size="Smaller"
                                        CssClass="table table-borderless table-striped" PageSize="5" GridLines="Horizontal" BorderWidth="0px" Width="100%" Font-Size="Small" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true"
                                        AllowPaging="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="View" SortExpression="Deprt_Status" ItemStyle-Width="10" ItemStyle-CssClass="MasterGridviewItem">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkview" Height="25" Width="25" runat="server"
                                                        CommandName="Viewing" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-eye"></i></asp:LinkButton>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="10px">
                                                <HeaderTemplate>
                                                    <asp:HyperLink ID="HyperLink2" runat="server">Edit</asp:HyperLink>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div class="btn-group btn-group-xs">
                                                        <asp:HyperLink ID="HyperLink1" EnableViewState="false" NavigateUrl='<%# Page.ResolveUrl("ActivityTask.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Id").ToString())))%>'
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
                                <asp:AsyncPostBackTrigger ControlID="GridView2" />
                                <asp:AsyncPostBackTrigger ControlID="btncloseyes" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>

    </div>
</div>
<div class="col-md-12">

    <div id="faq3" class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title"><a class="accordion-toggle" data-toggle="collapse" data-parent="#faq3" href="#faq2_q3">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:Literal ID="ltopentask" runat="server"></asp:Literal>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btncloseyes" />
                        </Triggers>
                    </asp:UpdatePanel>
                </a></h4>
            </div>
            <div id="faq2_q3" class="panel-collapse collapse">
                <div class="panel-body">
                    <asp:UpdatePanel ID="upopentaskactivity" runat="server">
                        <ContentTemplate>
                            <div class="">
                                <!-- Twitter Title -->
                                <div class="">
                                    <!-- Most Viewed Courses Title -->
                                    <div class="col-md-4">
                                        <b><a class="label label-danger">OverDue</a></b>
                                        <div style="max-height: 150px; overflow: auto;">
                                            <table class="table table-striped table-vcenter">
                                                <thead id="headoverdue" runat="server">
                                                    <tr>
                                                        <td class="center"><a>Date</a></td>
                                                        <td class="center"><a>Subject</a></td>
                                                        <td class="center"><a>Status</a></td>
                                                        <td class="center"><a>Prioty</a></td>
                                                    </tr>
                                                </thead>
                                                <asp:Repeater ID="rpoverdue" runat="server">
                                                    <ItemTemplate>
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <span class="text-danger">
                                                                        <asp:Literal ID="ltid" runat="server" Text='<%#DynamicparcelDataManipulation.AlphaDateFormat(Eval("Activity_Duedate"))%>'></asp:Literal></span>
                                                                </td>
                                                                <td>
                                                                    <small><%# (DynamicparcelDisplayFunctions.TruncateDescription(Eval("Subject"), 25))%></small>
                                                                </td>
                                                                <td>
                                                                    <small>
                                                                        <asp:Label ID="ltovstatus" runat="server" Text='<%#(Eval("Status"))%>' CssClass='<%#Security.checkStatuscss(Eval("Status"))%>'></asp:Label></small>
                                                                </td>
                                                                <td>
                                                                    <small>
                                                                        <asp:Label ID="Label2" runat="server" Text='<%#(Eval("Activity_Priority"))%>' CssClass='<%#Security.checkpriority(Eval("Activity_Priority"))%>'></asp:Label></small>

                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbloverdue" runat="server" ForeColor="Red" Text="No Task Found"></asp:Label></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <b><a class="label label-success">Today</a></b>
                                        <div style="max-height: 150px; overflow: auto;">
                                            <table class="table table-striped table-vcenter">
                                                <thead id="headtoday" runat="server">
                                                    <tr>
                                                        <td class="center"><a>Subject</a></td>
                                                        <td class="center"><a>Status</a></td>
                                                        <td class="center"><a>Prioty</a></td>
                                                    </tr>
                                                </thead>
                                                <asp:Repeater ID="rptasktoday" runat="server">
                                                    <ItemTemplate>
                                                        <tbody>
                                                            <tr>

                                                                <td>
                                                                    <small><%# (DynamicparcelDisplayFunctions.TruncateDescription(Eval("Subject"), 25))%></small>
                                                                </td>
                                                                <td>
                                                                    <small>
                                                                        <asp:Label ID="ltovstatus" runat="server" Text='<%#(Eval("Status"))%>' CssClass='<%#Security.checkStatuscss(Eval("Status"))%>'></asp:Label></small>
                                                                </td>
                                                                <td>
                                                                    <small>
                                                                        <asp:Label ID="Label2" runat="server" Text='<%#(Eval("Activity_Priority"))%>' CssClass='<%#Security.checkpriority(Eval("Activity_Priority"))%>'></asp:Label></small>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbltoday" runat="server" ForeColor="Red" Text="No Task Found"></asp:Label></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <b><a class="label label-info">Tommorrow</a></b>
                                        <div style="max-height: 150px; overflow: auto;">
                                            <table class="table table-striped table-vcenter">
                                                <thead id="headtommorrow" runat="server">
                                                    <tr>
                                                        <td class="center"><a>Subject</a></td>
                                                        <td class="center"><a>Status</a></td>
                                                        <td class="center"><a>Prioty</a></td>
                                                    </tr>
                                                </thead>
                                                <asp:Repeater ID="rptasktommorrow" runat="server">
                                                    <ItemTemplate>
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <small><%# (DynamicparcelDisplayFunctions.TruncateDescription(Eval("Subject"), 25))%></small>
                                                                </td>
                                                                <td>
                                                                    <small>
                                                                        <asp:Label ID="ltovstatus" runat="server" Text='<%#(Eval("Status"))%>' CssClass='<%#Security.checkStatuscss(Eval("Status"))%>'></asp:Label></small>
                                                                </td>
                                                                <td>
                                                                    <small>
                                                                        <asp:Label ID="Label2" runat="server" Text='<%#(Eval("Activity_Priority"))%>' CssClass='<%#Security.checkpriority(Eval("Activity_Priority"))%>'></asp:Label></small>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbltommorrow" runat="server" ForeColor="Red" Text="No Task Found"></asp:Label></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btncloseyes" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>

</div>

