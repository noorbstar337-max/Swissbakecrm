<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="ActivityTask.aspx.vb" Inherits="ActivityTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .control-label {
            padding: 6px;
        }

        .col-md-4 {
            padding-bottom: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <asp:Label ID="lbltitle1" runat="server"></asp:Label><br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="Activity.aspx">Activity</a></li>
                <li>
                    <asp:Label ID="lbltitle2" runat="server"></asp:Label></li>
            </ul>

            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" OnClick="btnadd_Click" />
                    <asp:LinkButton ID="LinkButton1" Text="Cancel" runat="server" NavigateUrl="~/Activity.aspx" class="btn btn-alt btn-sm btn-danger" OnClick="hfcancel_Click" />
                </div>
            </div>

            <div class="col-md-12">
                <div class="widget">
                    <div class="widget-extra themed-background-dark">
<h4 class="widget-content-light">
                            <strong>Task</strong> Information
                        </h4> </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                            <div class="col-md-12">
                                <div id="divstatus" runat="server" visible="false" class="alert alert-warning animation-fadeInQuick">
                                    Current Status: <strong>
                                        <asp:Literal ID="ltstatus" runat="server"></asp:Literal></strong>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Subject<span class="text-danger"> *</span></label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="txtsubject" runat="server" name="example-chosen" data-toggle="tooltip" title="Task" CssClass="form-control" TabIndex="1">
                                            <asp:ListItem>Select Subject</asp:ListItem>
                                            <asp:ListItem>Meeting</asp:ListItem>
                                            <asp:ListItem>Market Visit</asp:ListItem>
                                            <asp:ListItem>Study & Research</asp:ListItem>
                                            <asp:ListItem>Internal Office Work</asp:ListItem>
                                            <asp:ListItem>Order Follow Up</asp:ListItem>
                                            <asp:ListItem>Payment Follow Up</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="remembername" runat="server" ControlToValidate="txtsubject" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Select subject" SetFocusOnError="true" InitialValue="Select Subject"></asp:RequiredFieldValidator>
                                    </div>

                                </div>
                            </div>

                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Task Desc</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtdec" runat="server" placeholder="Enter Task Desc" TextMode="MultiLine" Columns="2" Rows="2" data-toggle="tooltip" title="Enter Service Name" TabIndex="2"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtsubject" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter  desc" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12" runat="server" visible="false">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-password">Task Owner<span class="text-danger"> *</span></label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddowner" runat="server" data-toggle="tooltip" title="Task Owner" name="example-chosen" class="select-chosen" TabIndex="2">
                                            <asp:ListItem>Shahid</asp:ListItem>
                                            <asp:ListItem>Admin</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddowner" InitialValue="Select Category" ValidationGroup="DemoMasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="select Owner" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Task Date/Time</label>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtdate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="3" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter  date" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="col-md-4">
                                        <div class="input-group" data-date-format="mm/dd/yyyy">
                                            <asp:TextBox ID="txtstarttime" runat="server" TextMode="Time" class="form-control text-center" placeholder="From" TabIndex="4" />
                                            <span class="input-group-addon" style="font-size: 10px"><i class="fa fa-angle-right"></i></span>
                                            <asp:TextBox ID="txtendtime" runat="server" TextMode="Time" class="form-control text-center" placeholder="To" TabIndex="5" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12" runat="server" visible="false">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Due Date</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtduedate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtduedate" ValidationGroup="DemoMasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter  date" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <label class="col-md-2 control-label" for="example-hf-password">Reminder</label>
                                <div class="col-md-4">
                                    <div class="col-md-1">
                                        <asp:CheckBox ID="ckreminder" runat="server" TabIndex="6" />
                                    </div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtreminderdate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="7" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtreminderdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter  date" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" SetFocusOnError="true" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Reminder date should equal or earlier tahn Task date"  Display="Dynamic" ControlToValidate="txtreminderdate" ControlToCompare="txtdate" Operator="LessThanEqual" Type="Date"></asp:CompareValidator>
                                        <br />
                                    </div>
                                </div>


                                <div class="col-md-2">

                                    <asp:TextBox ID="txtremindertime" runat="server" TextMode="Time" CssClass="form-control" placeholder="From" TabIndex="8" />


                                </div>
                            </div>
                            <div class="col-md-12" runat="server" visible="false">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Status</label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddstatus" runat="server" name="example-chosen" data-toggle="tooltip" title="Status" class="select-chosen">
                                            <asp:ListItem>Not Started</asp:ListItem>
                                            <asp:ListItem>Deferred</asp:ListItem>
                                            <asp:ListItem>In Progress</asp:ListItem>
                                            <asp:ListItem>Completed</asp:ListItem>
                                            <asp:ListItem>Close</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddstatus" ValidationGroup="DemoMasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="Select status" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Priority</label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddpriority" runat="server" CssClass="form-control" data-toggle="tooltip" title="Priority" TabIndex="9">
                                            <asp:ListItem>High</asp:ListItem>
                                            <asp:ListItem>Highest</asp:ListItem>
                                            <asp:ListItem>Low</asp:ListItem>
                                            <asp:ListItem>Lowest</asp:ListItem>
                                            <asp:ListItem>Normal</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddpriority" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Select priority" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <label class="col-md-2 control-label" for="example-hf-password">Related To</label>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddrelatedtype" runat="server" AutoPostBack="true" data-toggle="tooltip" title="Related Type" CssClass="form-control" TabIndex="10">
                                        <asp:ListItem Value="None">None</asp:ListItem>
                                        <asp:ListItem Value="Lead">Lead</asp:ListItem>
                                        <asp:ListItem Value="Prospect">Prospect</asp:ListItem>
                                        <asp:ListItem Value="Account">Account</asp:ListItem>
                                        <asp:ListItem Value="Opportunity">Opportunity</asp:ListItem>
                                        <asp:ListItem Value="Quotation">Quotation</asp:ListItem>
                                        <%-- <asp:ListItem Value="Account">Account</asp:ListItem>
                                        <asp:ListItem Value="Contact">Contact</asp:ListItem>
                                        <asp:ListItem Value="Potential">Potential</asp:ListItem>
                                        <asp:ListItem Value="Vendor">Vendor</asp:ListItem>
                                        <asp:ListItem Value="Quote">Quote</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddrelatedtype" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="Select  Related Type" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddrelatedtypeid" runat="server" AutoPostBack="true" name="example-chosen" class="select-chosen" data-toggle="tooltip" title="Related Type ID" TabIndex="11"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtsubject" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="Select  Related Type" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-md-12">
                                <label class="col-md-2 control-label" for="example-hf-password">Contact</label>
                                <div style="display: none">

                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddcontactype" runat="server" AutoPostBack="true" data-toggle="tooltip" title="Contact Type" CssClass="form-control">
                                            <asp:ListItem Value="None">None</asp:ListItem>
                                            <asp:ListItem Value="Lead">Lead</asp:ListItem>
                                            <asp:ListItem Value="Contact">Contact</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddcontactype" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Select Contact Type" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <asp:UpdatePanel ID="upcontactid" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="ddcontactypeid" AutoPostBack="true" runat="server" name="example-chosen" class="select-chosen" data-toggle="tooltip" title="Contact ID" TabIndex="12"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddcontactypeid" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Select Contact Type" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="ddcontactype" />
                                        <asp:PostBackTrigger ControlID="ddcontactypeid" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-12" runat="server" visible="false" id="divresult">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Result</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtresult" runat="server" placeholder="Enter Result" data-toggle="tooltip" title="Enter Result" TabIndex="9" TextMode="MultiLine" Rows="2"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtresult" ValidationGroup="DemoMasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter  Result" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <User:AssignControl ID="assigncontrol" runat="server" />
                                <div id="faq6" class="panel-group">
                                    <User:NoteControl ID="notecontrol" runat="server" />
                                </div>
                            </div>
                            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                                <div class="pull-right">
                                    <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" TabIndex="13" />
                                    <asp:LinkButton ID="hfcancel" Text="Cancel" runat="server" NavigateUrl="~/Activity.aspx" class="btn btn-alt btn-sm btn-danger" TabIndex="14" />
                                </div>
                            </div>

                            <div style="clear: both"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

