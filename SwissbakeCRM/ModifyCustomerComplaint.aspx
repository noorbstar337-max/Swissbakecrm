<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ModifyCustomerComplaint.aspx.vb" Inherits="ModifyCustomerComplaint" MaintainScrollPositionOnPostback="true" %>

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
    <asp:HiddenField ID="hfCustId" runat="server" />
    <div class="row">
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <i class="gi gi-parents" style="margin: -8px"></i>
                        <asp:Label ID="lbltitle1" runat="server"></asp:Label><br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="CustomerComplaint.aspx">Customer Complaint</a></li>
                <li>
                    <asp:Label ID="lbltitle2" runat="server"></asp:Label></li>

            </ul>
            <asp:Panel ID="pnlfull" runat="server">
                <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">

                    <div class="pull-right">
                        <%-- btn-group removed by mandar --%>
                        <div class="" style="">
                            <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroup" OnClick="btnadd_Click" />
                            <asp:LinkButton ID="HyperLink1" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/Solution.aspx" class="btn btn-alt btn-danger" OnClick="hfcancel_Click" />
                            <%--<button class="btn btn-sm btn-primary"><i class="fa fa-floppy-o"></i>&nbsp;Save</button>

                        <button class="btn btn-sm btn-primary"><i class="fa fa-times"></i>&nbsp;Cancel</button>--%>
                        </div>
                    </div>

                </div>
                <div class="col-md-12">
                    <div class="widget">
                        <div class="widget-extra themed-background-dark">

                            <h4 class="widget-content-light abc">
                                <strong>Complaint</strong> Information
                             <small>
                                 <span class="pull-right" id="modifyspan" runat="server">By&nbsp;<a style="text-decoration: none;"><asp:Label ID="lblmodifiedname" runat="server" Font-Bold="true"></asp:Label></a>&nbsp;on&nbsp;<a style="text-decoration: none;"><asp:Label ID="lblmodifieddate" Font-Bold="true" runat="server" Font-Italic="true"></asp:Label></a>
                                 </span>
                             </small>
                            </h4>
                        </div>
                        <div class="widget-extra-full">
                            <div class="form-horizontal form-bordered">
                                <div class="col-md-12">
                                    <br />
                                </div>
                                <div class="col-md-4">
                                    <div class="">
                                        <label class="col-md-4 control-label" for="example-hf-email">Complaint No.<span class="text-danger"> *</span></label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtcomplaintcode" runat="server" placeholder="Enter Complaint No." data-toggle="tooltip" title="Enter Complaint No." ReadOnly="true"
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="releadname" runat="server" ControlToValidate="txtcomplaintcode" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter complaint no." Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-8">
                                    <div class="">
                                        <label class="col-md-2 control-label" for="example-hf-password">Product</label>
                                        <div class="col-md-10">
                                            <asp:DropDownList ID="ddproduct" runat="server" name="example-chosen" class="select-chosen"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="reIndustry" runat="server" ControlToValidate="ddproduct" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="select product" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                              <%--  <div class="col-md-4" runat="server" visible="false" >
                                    <div class="">
                                        <label class="col-md-4 control-label" for="example-hf-password">Account</label>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddaccount" runat="server" name="example-chosen" class="select-chosen"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="recompnytype" runat="server" ControlToValidate="ddaccount" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="select account" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                 <div class="col-md-4" runat="server" visible="false" >
                                    <div class="">
                                        <label class="col-md-4 control-label" for="example-hf-password">Prospect</label>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddprospect" runat="server" name="example-chosen" class="select-chosen"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddprospect" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="select prospect" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>--%>
                                    <div class="col-md-4">
                                <label class="col-md-4 control-label" for="example-hf-password">Type</label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddtype" runat="server" AutoPostBack="true" data-toggle="tooltip" title="Contact Type" CssClass="form-control">
                                      <%--  <asp:ListItem Value="None">None</asp:ListItem>--%>
                                        <asp:ListItem Value="Account">Account</asp:ListItem>
                                        <asp:ListItem Value="Prospect">Prospect</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddtype" InitialValue="None" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="Select a type" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                        </div>
                                <div class="col-md-4">
                                <asp:UpdatePanel ID="upcontactid" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="col-md-2"></div> 
                                        <div class="col-md-10">
                                            <asp:DropDownList ID="ddtypeid" runat="server" name="example-chosen" class="select-chosen" data-toggle="tooltip" title="Contact ID"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddtypeid" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter  Task name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <%--   <asp:PostBackTrigger ControlID="ddtype" />
                                        <asp:PostBackTrigger ControlID="ddtypeid" />--%>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                                <asp:UpdatePanel ID="upchkbox" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="col-md-4">
                                            <label class="col-md-4 control-label" for="example-hf-password">Mark As Solution</label>
                                            <div class="col-md-6">
                                                <asp:CheckBox ID="chksolution" runat="server" />
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtfeedback" />
                                        <asp:AsyncPostBackTrigger ControlID="txtexterneal" />
                                        <asp:AsyncPostBackTrigger ControlID="txtinternal" />
                                        <asp:AsyncPostBackTrigger ControlID="txtaction" />
                                        <asp:AsyncPostBackTrigger ControlID="txtprevent" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <div style="clear:both;"></div>
                                <div class="col-md-6">
                                    <div class="">
                                        <label class="col-md-4 control-label" for="example-hf-password">Lot No./Batch No.</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtbatch" runat="server" placeholder="Enter Lot No./Batch No." data-toggle="tooltip" title="Enter Lot No./Batch No."
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="returnover" runat="server" ControlToValidate="txtbatch" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Enter lot no./batch no." SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="">
                                        <label class="col-md-4 control-label" for="example-hf-password">Invoice No.</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtinvoice" runat="server" placeholder="Enter Invoice No." data-toggle="tooltip" title="Enter Invoice No."
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rewebsite" runat="server" ControlToValidate="txtinvoice" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Enter invoice no." SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="col-md-12">
                                    <label class="col-md-2 control-label" for="example-hf-password">Title Of Complaint<span class="text-danger"> *</span></label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txttitle" runat="server" placeholder="Enter Title Of Complaint" data-toggle="tooltip" title="Enter Title Of Complaint"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reotherref" runat="server" ControlToValidate="txttitle" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Enter title of complaint" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <label class="col-md-2 control-label" for="example-hf-password">Description</label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtdiscription" runat="server" placeholder="Enter Description" data-toggle="tooltip" title="Enter Description"
                                            CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rediscription" runat="server" ControlToValidate="txtdiscription" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Select description" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div style="clear: both"></div>
                                <div class="col-md-12">
                                    <User:AssignControl ID="assigncontrol" runat="server" />
                                </div>
                                 
                                <div style="clear: both"></div>
                            </div>
                        </div>
                    </div>
                    <div class="widget">
                        <div class="widget-extra themed-background-dark">

                            <h4 class="widget-content-light">
                                <strong>Reason & Causes</strong> Information
                            </h4>
                        </div>
                        <div class="widget-extra-full">
                            <div class="form-horizontal form-bordered">
                                <div class="col-md-12">
                                    <br />
                                </div>
                                <div class="col-md-6">
                                    <div class="">
                                        <label class="col-md-2 control-label" for="example-hf-password">External <span class="text-danger"></span></label>
                                        <div class="col-md-10">
                                            <asp:TextBox ID="txtexterneal" runat="server" placeholder="Enter External" data-toggle="tooltip" title="Enter External" AutoPostBack="true" OnTextChanged="txtexterneal_TextChanged"
                                                CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="refirstname" runat="server" ControlToValidate="txtexterneal" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter external" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="">
                                        <label class="col-md-2 control-label" for="example-hf-password">Internal <span class="text-danger"></span></label>
                                        <div class="col-md-10">
                                            <asp:TextBox ID="txtinternal" runat="server" placeholder="Enter Internal" data-toggle="tooltip" title="Enter Internal" AutoPostBack="true" OnTextChanged="txtinternal_TextChanged"
                                                CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtinternal" ValidationGroup="MasterGrou1p" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter internal" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div style="clear: both;"></div>

                            </div>
                        </div>
                    </div>
                    <div class="widget">
                        <div class="widget-extra themed-background-dark">
                            <div class="pull-right">
                            </div>
                            <h4 class="widget-content-light">
                                <strong>Actions & Preventive</strong> Information
                            </h4>
                        </div>
                        <div class="widget-extra-full">
                            <div class="form-horizontal form-bordered">
                                <div class="col-md-12">
                                    <br />
                                </div>
                                <div class="col-md-12">
                                    <div class="">
                                        <label class="col-md-2 control-label" for="example-hf-email">Action Taken<span class="text-danger"> </span></label>
                                        <div class="col-md-10">
                                            <asp:TextBox ID="txtaction" runat="server" placeholder="Enter Action Taken" data-toggle="tooltip" title="Enter Action Taken" AutoPostBack="true" OnTextChanged="txtaction_TextChanged"
                                                CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="readdressbill" runat="server" ControlToValidate="txtaction" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter action taken" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="">
                                        <label class="col-md-2 control-label" for="example-hf-password">Preventive Measure</label>
                                        <div class="col-md-10">
                                            <asp:TextBox ID="txtprevent" runat="server" placeholder="Enter Preventive Measure" data-toggle="tooltip" title="Enter Preventive Measure" AutoPostBack="true" OnTextChanged="txtprevent_TextChanged"
                                                CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="repicodebill" runat="server" ControlToValidate="txtprevent" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter preventive measure" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="">
                                        <label class="col-md-2 control-label" for="example-hf-password">Client Feedback</label>
                                        <div class="col-md-10">
                                            <asp:TextBox ID="txtfeedback" runat="server" placeholder="Enter Client Feedback" data-toggle="tooltip" title="Enter Client Feedback" AutoPostBack="true" OnTextChanged="txtfeedback_TextChanged"
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtfeedback" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter client feedback" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div style="clear: both"></div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                    <div class="pull-right">
                        <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroup" />
                        <asp:LinkButton ID="hfcancel" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/Solution.aspx" class="btn btn-alt btn-danger" />
                        <br />
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>

