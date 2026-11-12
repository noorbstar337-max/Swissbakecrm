<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="ActivityCall.aspx.vb" Inherits="ActivityCall" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<script type="text/javascript">
        function getDropdownListSelectedText() {
        var DropdownList = document.getElementById('<%=ddcontactypeid.ClientID %>');
        var SelectedIndex = DropdownList.selectedIndex;
        var SelectedValue = DropdownList.value;
        var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
        document.getElementById('<%=ddrelatedtypeid.ClientID%>').selectedIndex = SelectedIndex;
        //var sValue = 'Selected Index: ' + SelectedIndex + '<br/> Selected Value: ' + SelectedValue + '<br/> Selected Text: ' + SelectedText;
        //LabelDropdownList.innerHTML = sValue;
    }
</script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <%--<i class="gi gi-table" style="margin: -8px"></i>Modify Call<br>--%>
                        <asp:Label ID="lbltitle1" runat="server"></asp:Label><br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="Activity.aspx">Activity</a></li>
                <li>
                    <asp:Label ID="lbltitle2" runat="server"></asp:Label></li>
                <li><asp:Label ID="lblDropdownList" runat="server"></asp:Label></li>
            </ul>
            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" OnClick="btnadd_Click" />
                    <asp:LinkButton ID="LinkButton1" Text="Cancel" runat="server" NavigateUrl="~/Task.aspx" class="btn btn-alt btn-sm btn-danger" OnClick="hfcancel_Click" />
                </div>
            </div>
            <div class="col-md-12">
                <div class="widget">
                    <div class="widget-extra themed-background-dark">

                        <h4 class="widget-content-light">
                            <strong>Phone/Email</strong> Information
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                            <div class="col-md-12">
                            <div id="divstatus" runat="server" visible="false" class="alert alert-warning animation-fadeInQuick">Current Status: <strong><asp:Literal ID="ltstatus" runat="server"></asp:Literal></strong></div>
                                 </div>
                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Subject<span class="text-danger"> *</span></label>
                                    <div class="col-md-6">
                                        <%--<asp:TextBox ID="txtsubject" runat="server" placeholder="Enter Event Name" data-toggle="tooltip" title="Enter Event Name" TabIndex ="1"
                                            CssClass="form-control"></asp:TextBox>--%>
                                         <asp:DropDownList ID="txtsubject" runat="server" name="example-chosen" data-toggle="tooltip" title="Call" CssClass="form-control"  TabIndex ="1">
                                             <asp:ListItem>Select Subject</asp:ListItem>
                                              <asp:ListItem>Phone Call Inbound</asp:ListItem>
                                              <asp:ListItem>Phone Call Outbound</asp:ListItem>
                                              <asp:ListItem>Email</asp:ListItem>
                                              <asp:ListItem>Others</asp:ListItem>
                                              
                                         </asp:DropDownList> 
                                        <asp:RequiredFieldValidator ID="remembername" runat="server" ControlToValidate="txtsubject" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Select subject" SetFocusOnError="true" InitialValue ="Select Subject"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12" style="display:none">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Call Type<span class="text-danger"> *</span></label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddcalltype" runat="server" CssClass="form-control" TabIndex ="2">
                                            <asp:ListItem Value="Inbound" Text="Inbound"></asp:ListItem>
                                            <asp:ListItem Value="Outbound" Text="Outbound"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4fgh" runat="server" ControlToValidate="ddcalltype" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Select call type" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12" style="display:none">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Call Purpose</label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddcallpurpose" runat="server" CssClass="form-control" TabIndex ="3">
                                            <asp:ListItem Value="None" Text="None"></asp:ListItem>
                                            <asp:ListItem Value="Prospecting" Text="Prospecting"></asp:ListItem>
                                            <asp:ListItem Value="Administrative" Text="Administrative"></asp:ListItem>
                                            <asp:ListItem Value="Demo" Text="Demo"></asp:ListItem>
                                            <asp:ListItem Value="Project" Text="Project"></asp:ListItem>
                                            <asp:ListItem Value="Support" Text="Support"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddcallpurpose" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Select Call Purpose" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Desc</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtdec" runat="server" placeholder="Enter  Desc" TextMode="MultiLine" Columns="2" Rows="2" data-toggle="tooltip" title="Enter  Name"
                                            CssClass="form-control" TabIndex ="2"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1desc" runat="server" ControlToValidate="txtsubject" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter  desc" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Priority</label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddpriority" runat="server" CssClass="form-control" data-toggle="tooltip" title="Priority" TabIndex="3">
                                            <asp:ListItem>High</asp:ListItem>
                                            <asp:ListItem>Highest</asp:ListItem>
                                            <asp:ListItem>Low</asp:ListItem>
                                            <asp:ListItem>Lowest</asp:ListItem>
                                            <asp:ListItem>Normal</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddpriority" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Select priority" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Date/Time</label>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtdate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex ="4" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Enter date" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="col-md-4">
                                        <div class="input-group" data-date-format="mm/dd/yyyy">
                                            <asp:TextBox ID="txtstarttime" runat="server" TextMode="Time" class="form-control text-center" placeholder="From"  TabIndex ="5" />
                                            <span class="input-group-addon" style="font-size: 10px"><i class="fa fa-angle-right"></i></span>
                                            <asp:TextBox ID="txtendtime" runat="server" TextMode="Time" class="form-control text-center" placeholder="To"  TabIndex ="6" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <label class="col-md-2 control-label" for="example-hf-password">Reminder</label>
                                <div class="col-md-4">
                                    <div class="col-md-1">
                                        <asp:CheckBox ID="ckreminder" runat="server" TabIndex="7" /></div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtreminderdate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="8" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtreminderdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter  date" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" SetFocusOnError="true" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Reminder date should equal or earlier tahn Phone/Email date"  Display="Dynamic" ControlToValidate="txtreminderdate" ControlToCompare="txtdate" Operator="LessThanEqual" Type="Date"></asp:CompareValidator>
                                        <br />
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtremindertime" runat="server" TextMode="Time" CssClass="form-control" placeholder="From" TabIndex="9" />
                                </div>
                            </div>
                            <%--<div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Status</label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddstatus" runat="server" name="example-chosen" data-toggle="tooltip" title="Status" class="select-chosen">
                                            <asp:ListItem>Not Startes</asp:ListItem>
                                            <asp:ListItem>defredd</asp:ListItem>
                                            <asp:ListItem>in Progress</asp:ListItem>
                                            <asp:ListItem>Completed</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddstatus" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter  Task name"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>--%>

                             <div class="col-md-12">
                                <label class="col-md-2 control-label" for="example-hf-password">Related Type</label>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddrelatedtype" runat="server" AutoPostBack="true" data-toggle="tooltip" title="Related Type" CssClass="form-control" TabIndex ="10">
                                        <asp:ListItem Value="None">None</asp:ListItem>
                                        <asp:ListItem Value="Lead">Lead</asp:ListItem>
                                        <asp:ListItem Value="Prospect">Prospect</asp:ListItem>
                                       <asp:ListItem Value="Account">Account</asp:ListItem>
                                       <asp:ListItem Value="Opportunity">Opportunity</asp:ListItem>
                                         <asp:ListItem Value="Quotation">Quotation</asp:ListItem>
                                         <%--<asp:ListItem Value="Contact">Contact</asp:ListItem>
                                        <asp:ListItem Value="Potential">Potential</asp:ListItem>
                                        <asp:ListItem Value="Vendor">Vendor</asp:ListItem>
                                        <asp:ListItem Value="Quote">Quote</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddrelatedtype" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="Select Related Type" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddrelatedtypeid" runat="server" AutoPostBack="true" name="example-chosen" class="select-chosen" data-toggle="tooltip" title="Related Type ID" TabIndex ="11"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtsubject" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="Please enter  Task name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-md-12">
                                <label class="col-md-2 control-label" for="example-hf-password">Contact Type</label>
                                <div class="col-md-3" style="display:none">
                                    <asp:DropDownList ID="ddcontactype" runat="server" AutoPostBack="true" data-toggle="tooltip" title="Contact Type" CssClass="form-control" >
                                        <asp:ListItem Value="None">None</asp:ListItem>
                                        <asp:ListItem Value="Lead">Lead</asp:ListItem>
                                        <asp:ListItem Value="Contact">Contact</asp:ListItem>
                                        <%--<asp:ListItem Value="Contact">Contact</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddcontactype" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="Select Contact Type" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <asp:UpdatePanel ID="upcontactid" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="ddcontactypeid" AutoPostBack="true" runat="server"  name="example-chosen" class="select-chosen" TabIndex ="12"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddcontactypeid" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter  Task name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="ddcontactype" />
                                        <asp:PostBackTrigger ControlID="ddcontactypeid" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                           
                            <div class="col-md-12" runat ="server" visible ="false" >
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Call Status</label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlcallstatus" runat="server" data-toggle="tooltip" title="Call Status" CssClass="form-control">
                                            <asp:ListItem>Not Startes</asp:ListItem>
                                            <asp:ListItem>defredd</asp:ListItem>
                                            <asp:ListItem>in Progress</asp:ListItem>
                                            <asp:ListItem>Completed</asp:ListItem>
                                            <asp:ListItem>Close</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtsubject" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Select Call Status" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                             <div class="col-md-12" style="display:none">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Call Result</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtresult" runat="server" placeholder="Enter Call Result" TextMode="MultiLine" Columns="2" Rows="2" data-toggle="tooltip" title="Enter Call Result"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtsubject" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Enter result" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12" style="display :none">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Billable</label>
                                    <div class="col-md-6">
                                        <asp:CheckBox ID="ckbillable" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtsubject" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select Billable" SetFocusOnError="true"></asp:RequiredFieldValidator>
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
                                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" TabIndex ="13" />
                                    <asp:LinkButton ID="hfcancel" Text="Cancel" runat="server" NavigateUrl="~/Task.aspx" class="btn btn-alt btn-sm btn-danger" TabIndex ="14" />
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

