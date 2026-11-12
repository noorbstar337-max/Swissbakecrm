<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ActivityCloseButtonControl.ascx.vb" Inherits="UserControl_Back_ActivityCloseButtonControl" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<style>
      input[type="radio"], input[type="checkbox"] {
        margin: 4px 0 0;
        margin-top: 1px \9;
        line-height: normal;
        margin-left: 10px;
        margin-right: 5px;
    }
</style>
<asp:UpdatePanel ID="UpdatePanel1dfgdf" runat="server" UpdateMode="Conditional">
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
                        <asp:HiddenField ID="hftype" runat="server" />
                        <asp:HiddenField ID="hftypeid" runat="server" />
                        <asp:HiddenField ID="hfactivityid" runat="server" />
                        <div class="form-group">
                            <asp:RadioButtonList ID="rdcloselist" AutoPostBack="true"  runat="server" CellPadding="10" CellSpacing="10" RepeatColumns="3" RepeatDirection="Horizontal" TextAlign="right">
                                <asp:ListItem Text="Close Success" Value="Close"></asp:ListItem>
                                <asp:ListItem Text="Close Follow Up" Value="FollowUp"></asp:ListItem>
                                <asp:ListItem Text="Close Postpone" Value="Postpone"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="form-group" id="divremark" runat="server"  visible="false">
                            <label for="example-nf-email">Result </label>
                            <asp:TextBox ID="txtremark" runat="server" tabindex="1" placeholder="Enter Result" TextMode="MultiLine" Rows="4" Columns="4" data-toggle="tooltip" title="Enter Result"
                                CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16"  runat="server" ControlToValidate="txtremark" ValidationGroup="FollowSuccessMasterGroup" CssClass="MasterValidationCSS"
                                                            ErrorMessage="Enter Result" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                         <div class="form-group" id="dvresult" visible="false" runat="server">
                         <label for="example-nf-email">Result </label>
                            <asp:TextBox ID="txtdvresult" runat="server" tabindex="1" placeholder="Enter Result" TextMode="MultiLine" Rows="1" Columns="1" data-toggle="tooltip" title="Enter Result"
                                CssClass="form-control"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rqdvresult"  runat="server" ControlToValidate="txtdvresult" ValidationGroup="FollowTaskMasterGroup" CssClass="MasterValidationCSS"
                                                            ErrorMessage="Enter Result" Display="Dynamic"></asp:RequiredFieldValidator>
                             </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddtype" Visible="false" runat="server" TabIndex="1" AutoPostBack="true" CssClass="form-control">
                                <asp:ListItem Value="Task" Text="Task"></asp:ListItem>
                                <asp:ListItem Value="Event" Text="Sampling/Demo"></asp:ListItem>
                                <asp:ListItem Value="Call" Text="Phone/Email"></asp:ListItem>
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
                                <asp:DropDownList ID="txtfollowupsubject" runat="server" name="example-chosen" data-toggle="tooltip" title="Task" CssClass="form-control" TabIndex="1">
                                    <asp:ListItem>Select Subject</asp:ListItem>
                                    <asp:ListItem>Meeting</asp:ListItem>
                                    <asp:ListItem>Market Visit</asp:ListItem>
                                    <asp:ListItem>Study & Research</asp:ListItem>
                                    <asp:ListItem>Internal Office Work</asp:ListItem>
                                    <asp:ListItem>Order Follow Up</asp:ListItem>
                                    <asp:ListItem>Payment Follow Up</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="Select Subject" runat="server" ControlToValidate="txtfollowupsubject" ValidationGroup="FollowTaskMasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Enter a subject" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-6">
                                <span>
                                    <label for="example-nf-email">Priority</label>
                                </span>
                                <asp:DropDownList ID="ddfollowpriority" runat="server" CssClass="form-control" data-toggle="tooltip" title="Priority" TabIndex="2">
                                    <asp:ListItem>High</asp:ListItem>
                                    <asp:ListItem>Highest</asp:ListItem>
                                    <asp:ListItem>Low</asp:ListItem>
                                    <asp:ListItem>Lowest</asp:ListItem>
                                    <asp:ListItem>Normal</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddfollowpriority" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Please enter task name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-6">
                                <span>
                                    <label for="example-nf-email">Task Date </label>
                                </span>
                                <asp:TextBox ID="txtfollowtaskdate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="3" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfollowtaskdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Please enter task name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-6">
                                <label for="example-nf-email">Task Time </label>
                                <div class="input-group" data-date-format="mm/dd/yyyy">
                                    <asp:TextBox ID="txtfollowstart" runat="server" TextMode="Time" class="form-control text-center" TabIndex="4" placeholder="From" />
                                    <span class="input-group-addon" style="font-size: 10px;"><i class="fa fa-angle-right"></i></span>
                                    <asp:TextBox ID="txtfollowend" runat="server" TextMode="Time" class="form-control text-center" TabIndex="5" placeholder="To" />

                                </div>
                            </div>
                            <div style="clear: both"></div>
                            <div class="col-sm-6">
                                <span>
                                    <label for="example-nf-email">Reminder</label>
                                </span>
                                <div class="col-sm-12">
                                    <div class="col-sm-2">
                                        <asp:CheckBox ID="cktaskreminder" runat="server" TabIndex="6" />
                                    </div>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txttaskreminderdate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="7" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfollowtaskdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter task name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <label for="example-nf-email">Reminder Time </label>
                                <asp:TextBox ID="txttaskremindertime" runat="server" TextMode="Time" CssClass="form-control" TabIndex="8" placeholder="From" />
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddfollowcallpriority" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddfollowcallpriority" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
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
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtfollowtaskdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtfollowtaskdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Please enter task name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>

                            <div style="clear: both"></div>
                            <div class="col-sm-6">
                                <span>
                                    <label for="example-nf-email">From </label>
                                </span>
                                <asp:TextBox ID="txtfollowfrom" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="5" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtfollowtaskdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Please enter task name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-6">
                                <span>
                                    <label for="example-nf-email">From Time </label>
                                </span>
                                <asp:TextBox ID="txtfollowfromtime" runat="server" TextMode="Time" CssClass="form-control" TabIndex="6"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtfollowtaskdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
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
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtfollowtaskdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtfollowtaskdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
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
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtfollowtaskdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
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
                            <asp:Button ID="btnpostponesave" runat="server" class="btn btn-sm btn-primary" TabIndex="6" Text="Save changes" ValidationGroup="Postponegroup"></asp:Button>
                        </div>
                    </div>
                    <div class="modal-footer" id="divremarkfooter" runat="server" visible="false">
                        <asp:Button ID="btncloseyes" runat="server" class="btn btn-alt btn-primary" ValidationGroup="FollowSuccessMasterGroup" TabIndex="2" Text="Yes"></asp:Button>
                        <asp:Button ID="btclosenno" runat="server" class="btn btn-alt btn-danger" TabIndex="3" Text="No"></asp:Button>
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
