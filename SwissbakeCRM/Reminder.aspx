<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="Reminder.aspx.vb" Inherits="Reminder" MaintainScrollPositionOnPostback="true" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>


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
                            <strong>Reminder</strong> Information
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
                                <label class="col-md-2 control-label" for="example-hf-password">Company Name<span class="text-danger"> *</span></label>
                             <div class="col-md-3" hidden="hidden">
                                    <asp:DropDownList ID="ddrelatedtype" runat="server" AutoPostBack="true" data-toggle="tooltip" title="Company Name" CssClass="form-control "  >
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
                                   
                                </div>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddrelatedtypeid" runat="server" AutoPostBack="true" name="example-chosen" class="select-chosen" CssClass="form-control select-chosen" data-toggle="tooltip" title="Related Type ID" TabIndex="1"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddrelatedtypeid" InitialValue="0" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                    <div class="col-md-1 " > 
                                             <asp:LinkButton ID="btnAddLead" runat="server" class="btn btn-alt btn-sm btn-success" Text="Add Lead" />
                                             </div>
                            </div>

                              <div class="col-md-12">
                                <label class="col-md-2 control-label" for="example-hf-password">Contact</label>
                                <div style="display: none">

                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddcontactype" runat="server" AutoPostBack="true" data-toggle="tooltip" title="Contact" CssClass="form-control">
                                            <asp:ListItem Value="None">None</asp:ListItem>
                                            <asp:ListItem Value="Lead">Lead</asp:ListItem>
                                            <asp:ListItem Value="Contact">Contact</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddcontactype" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <asp:UpdatePanel ID="upcontactid" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="ddcontactypeid" runat="server" name="example-chosen" class="select-chosen" CssClass="form-control" data-toggle="tooltip" title="Contact ID" TabIndex="2"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddcontactypeid" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="ddcontactype" />
                                        <asp:PostBackTrigger ControlID="ddcontactypeid" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>

                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Subject<span class="text-danger"> *</span></label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="txtsubject" runat="server" name="example-chosen" data-toggle="tooltip" title="Subject" CssClass="form-control" TabIndex="3">
                                            <asp:ListItem>Select Subject</asp:ListItem>
                                            <asp:ListItem>Meeting</asp:ListItem>
                                            <asp:ListItem>Sampling Demo</asp:ListItem>
                                            <asp:ListItem>Email/Phone Call</asp:ListItem>
                                            <asp:ListItem>Order Follow Up</asp:ListItem>
                                            <asp:ListItem>Payment Follow Up</asp:ListItem>
                                            <asp:ListItem>Sales Follow up</asp:ListItem>
                                            <asp:ListItem>Sample Follow up</asp:ListItem>
                                            <asp:ListItem>Payment Follow up</asp:ListItem>
                                            <asp:ListItem>General Call</asp:ListItem>
                                            <asp:ListItem>Sales Meeting</asp:ListItem>
                                            <asp:ListItem>Demo</asp:ListItem>
                                            <asp:ListItem>Order Follow Up</asp:ListItem>
                                            <asp:ListItem>General Meeting</asp:ListItem>
                                            <asp:ListItem>Chat</asp:ListItem>
                                            <asp:ListItem>Email</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="remembername" runat="server" ControlToValidate="txtsubject" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="This is required" SetFocusOnError="true" InitialValue="Select Subject"></asp:RequiredFieldValidator>
                                    </div>

                                </div>
                            </div>

                         
                            <div class="col-md-12" runat="server" visible="false">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-password">Task Owner<span class="text-danger"> *</span></label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddowner" runat="server" data-toggle="tooltip" title="Task Owner" name="example-chosen" class="select-chosen" >
                                            <asp:ListItem>Shahid</asp:ListItem>
                                            <asp:ListItem>Admin</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddowner" InitialValue="Select Category" ValidationGroup="DemoMasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Date/Time<span class="text-danger"> *</span></label>
                                    <div class="col-md-2">
										 <asp:TextBox ID="ddlDate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="3" min="Getdate" />
                                         <%-- <asp:DropDownList ID="ddlDate" runat="server" data-toggle="tooltip" title="Date" name="example-chosen" class="select-chosen" TabIndex="4">                                         
                                        </asp:DropDownList>--%>
                                       <%-- <asp:TextBox ID="txtdate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="3" />--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" InitialValue="0" ControlToValidate="ddlDate" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="col-md-4">
                                        <div class="input-group" data-date-format="mm/dd/yyyy">
                                            <%--<asp:TextBox ID="txtstarttime" runat="server" TextMode="Time" class="form-control text-center" TabIndex="5" />--%>
                                            <asp:TextBox ID="txtstarttime" runat="server" TextMode="Time" class="form-control text-center" placeholder="From" TabIndex="5" />
                                            <span class="input-group-addon" style="font-size: 10px"><i class="fa fa-angle-right"></i></span>
                                            <asp:TextBox ID="txtendtime" runat="server" TextMode="Time" class="form-control text-center" placeholder="To" TabIndex="6" />
                                            </div>
                                        <asp:CompareValidator ID="ComValEndTime" runat="server"  ControlToValidate="txtendtime" ControlToCompare="txtstarttime"
                                              class="text-danger"   ErrorMessage="This is invalid - End time must be Greater" Display="Dynamic" Operator="GreaterThan"  ValidationGroup="MasterGroup"></asp:CompareValidator>
                                       <%-- <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="End time should be greater than Start" ClientValidationFunction="compareTime" ControlToValidate="txtendtime"  ValidationGroup="MasterGroup" ></asp:CustomValidator>--%>
                                    </div>
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
                                            ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Priority</label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddpriority" runat="server" CssClass="form-control" data-toggle="tooltip" title="Priority" TabIndex="7">
                                            <asp:ListItem>High</asp:ListItem>
                                            <asp:ListItem>Highest</asp:ListItem>
                                            <asp:ListItem>Low</asp:ListItem>
                                            <asp:ListItem>Lowest</asp:ListItem>
                                            <asp:ListItem>Normal</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddpriority" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12" runat="server" visible="false">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Due Date</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtduedate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtduedate" ValidationGroup="DemoMasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                          <%--  <div class="col-md-12">
                                <label class="col-md-2 control-label" for="example-hf-password">Reminder</label>
                                <div class="col-md-4">
                                    <div class="col-md-1">
                                        <asp:CheckBox ID="ckreminder" runat="server" TabIndex="8" />
                                    </div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtreminderdate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" TabIndex="9" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtreminderdate" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter  date" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" SetFocusOnError="true" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Reminder date should equal or earlier tahn Task date"  Display="Dynamic" ControlToValidate="txtreminderdate" ControlToCompare="ddlDate" Operator="LessThanEqual" Type="Date"></asp:CompareValidator>
                                        <br />
                                    </div>
                                </div>
                              <div class="col-md-2">
                                <asp:TextBox ID="txtremindertime" runat="server" TextMode="Time" CssClass="form-control" placeholder="From" TabIndex="10" />
                              </div>
                              </div>--%>
                           

                             <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Task Description<span class="text-danger"> *</span></label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtdec" runat="server" placeholder="Enter Task Description" TextMode="MultiLine" Columns="2" Rows="2" data-toggle="tooltip" title="Task Description" TabIndex="11"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtdec" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>


                          
                            <div class="col-md-12" runat="server" visible="false" id="divresult">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Result</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtresult" runat="server" placeholder="Enter Result" data-toggle="tooltip" title="Result"  TextMode="MultiLine" Rows="2"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtresult" ValidationGroup="DemoMasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>
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
                                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" TabIndex="12" />
                                    <asp:LinkButton ID="hfcancel" Text="Cancel" runat="server" NavigateUrl="~/Activity.aspx" class="btn btn-alt btn-sm btn-danger" TabIndex="13" />
                                </div>
                            </div>

                            <div style="clear: both"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <asp:ModalPopupExtender ID="mpe" runat="server" BehaviorID="mpe" PopupControlID="pnlPopup" TargetControlID="btnAddLead"
                            CancelControlID="btnNo">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="pnlPopup" runat="server" Style="display: none" DefaultButton="btnsavePop">
                            <div class="modal-dialog modal-sm">
                                <div class="modal-content " >
                                    <div class="modal-header themed-background-dark">
                                        <asp:LinkButton ID="btnNo" class="close" runat="server" ForeColor="White">&times;</asp:LinkButton>
                                        <h5 class="modal-title"> <asp:Label ID="lblheading" runat="server" Text="New Lead" ForeColor="WhiteSmoke"></asp:Label></h5>
                                    </div>
                                    <div class="modal-body">
                                        <div class="form-group">
                                            <label for="example-nf-email">Lead Name <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtleadname" runat="server" placeholder="Enter Lead Name" data-toggle="tooltip" title="Lead Name"
                                                CssClass="form-control" ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="releadname" runat="server" ControlToValidate="txtleadname" ValidationGroup="MasterGroups" CssClass="MasterValidationCSS"
                                                ErrorMessage="This is required" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label for="example-nf-email">Lead Date <span class="text-danger">*</span></label>

                                            <asp:TextBox ID="txtleaddate" runat="server" placeholder="dd/mm/yy" data-toggle="tooltip" title="Lead Date"
                                                CssClass="form-control " data-date-format="dd/mm//yy" TextMode="Date" ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="releaddate" runat="server" ControlToValidate="txtleaddate" ValidationGroup="MasterGroups" CssClass="MasterValidationCSS"
                                                ErrorMessage="This is required" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>

                                        </div>
                                       <div class="form-group">
                                            <label for="example-nf-email">Lead Category<span class="text-danger"> *</span></label>
                                        <div >
                                            <asp:DropDownList ID="ddlLeadCategory" runat="server" data-toggle="tooltip" title="Lead Category" CssClass="form-control">
                                                 <%--<asp:ListItem Value="None">None</asp:ListItem>--%>
                                                 <asp:ListItem Value="Domestic">Domestic</asp:ListItem>
                                                 <asp:ListItem Value="Export">Export</asp:ListItem>
                                            </asp:DropDownList>
                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddQuotationType" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please select Quotation Type" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                   
                                         </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="example-nf-email">Contact Person <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtname" runat="server" placeholder="Enter Name" data-toggle="tooltip" title="Contact Person" CssClass="form-control" ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="refirstname" runat="server" ControlToValidate="txtname" ValidationGroup="MasterGroups" CssClass="MasterValidationCSS"
                                                ErrorMessage="This is required" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="form-group">
                                            <label for="example-nf-email">Email <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtemail" runat="server" placeholder="Enter Email Id" data-toggle="tooltip" title="Email Id"
                                                CssClass="form-control" ></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rgemailship" runat="server" ValidationGroup="MasterGroups" ErrorMessage="This is invalid - abc@xyz.com is valid"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" CssClass="MasterValidationCSS" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>

                                        </div>
                                        <div class="form-group">
                                            <label for="example-nf-email">Mobile Number <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtmob" runat="server" placeholder="Enter Mobile Number" data-toggle="tooltip" title="Mobile Number"
                                                CssClass="form-control" TextMode="Number" ></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rgmobship" runat="server" ErrorMessage="This is required" ControlToValidate="txtmob"
                                                ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>

                                        </div>
                                        <div class="form-group" hidden="hidden">
                                            <label for="example-nf-email">Office Number </label>
                                            <asp:TextBox ID="txtofficeno" runat="server" placeholder="Enter Office Number" data-toggle="tooltip" title="Office Number"
                                                CssClass="form-control" ></asp:TextBox><br />
                                            <asp:TextBox ID="txtextention" runat="server" placeholder="Extention" data-toggle="tooltip" title="Extention"
                                                CssClass="form-control" ></asp:TextBox>
                                            <%-- <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="At leat one contact required" ValidationGroup="MasterGroup1"
                                                CssClass="MasterValidationCSS" Display="Dynamic" OnServerValidate="AtLeastOneContact_ServerValidate"
                                                ClientValidationFunction="AtLeastOneContact_ClientValidate" SetFocusOnError="true"></asp:CustomValidator>--%>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID="btnsavePop" runat="server"  OnClientClick="if (!Page_ClientValidate('MasterGroups')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                            UseSubmitBehavior="false" class="btn btn-sm btn-primary" ValidationGroup="MasterGroups" Text="Save" TabIndex="8"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
    </div>
</asp:Content>




