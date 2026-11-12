<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" CodeFile="Opportunity.aspx.vb" Inherits="Opportunity" %>

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
                        <%-- <i class="hi hi-tasks" style="margin: -8px"></i>Modify Task<br>--%>
                        <asp:Label ID="lbltitle1" runat="server"></asp:Label><br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="MainOpportunity.aspx">Opportunity</a></li>
                <li>
                    <asp:Label ID="lbltitle2" runat="server"></asp:Label></li>
                <%-- <li>Modify Task</li>--%>
            </ul>
            <asp:HiddenField ID="hfcheckstageid" runat="server" />
            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" OnClick ="btnadd_Click"  />
                    <asp:LinkButton ID="LinkButton1" Text="Cancel" runat="server" NavigateUrl="~/MainOpportunity.aspx" class="btn btn-alt btn-sm btn-danger" CausesValidation ="false" OnClick ="hfcancel_Click"  />
                </div>
            </div>

            <div class="col-md-12">
                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <h4 class="widget-content-light">
                            <strong>Opportunity</strong> Information
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Opportunity Name<span class="text-danger"> *</span></label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtname" runat="server" placeholder="Enter Opportunity Name" data-toggle="tooltip" title="Enter Opportunity Name"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="remembername" runat="server" ControlToValidate="txtname" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter subject" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-password">Opportunity Owner<span class="text-danger"> *</span></label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddowner" runat="server" data-toggle="tooltip" title="Task Owner" name="example-chosen" class="select-chosen">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddowner" InitialValue="Select Category" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select category" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="upprobability" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-password">Stage<span class="text-danger"> *</span></label>
                                            <div class="col-md-2">
                                                <asp:DropDownList ID="ddstage" runat="server" data-toggle="tooltip" AutoPostBack="true" title="Task Owner" CssClass="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddowner" InitialValue="Select Category" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select category" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>

                                            <div class="col-md-1">
                                                <a class="label label-default">Probability</a> : 
                                                <asp:Label ID="lbprobability" Visible="false" CssClass="text-primary" Font-Size="12" runat="server"></asp:Label>

                                </div>
                                            <div class="col-md-3">
                                                <div class="progress progress-striped active">
                                                    <div id="divprogress" runat="server" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 40%">20%</div>
                            </div>

                                            </div>
                                        </div>
                                    </div>

                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddstage" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <div style="clear: both"></div>
                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Expected Date</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtduedate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtduedate" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please expected date" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Amount</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtamount" runat="server" Text="0" placeholder="Enter Amount" AutoPostBack="true" data-toggle="tooltip" title="Enter Amount"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtname" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter  amount" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Expected Revenue</label>
                                    <div class="col-md-6">
                                        <asp:UpdatePanel ID="upexepectedrevenue" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtrevenue" runat="server" ReadOnly="true" placeholder="Enter Expected Revenue" data-toggle="tooltip" title="Enter Expected Revenue"
                                                    CssClass="form-control"></asp:TextBox>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="txtamount" />
                                                <asp:AsyncPostBackTrigger ControlID="ddstage" />
                                            </Triggers>
                                        </asp:UpdatePanel>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtname" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter  amount" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Next Step</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtnextstep" runat="server" placeholder="Enter Result" data-toggle="tooltip" title="Enter Result"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtname" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter  Result" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <label class="col-md-2 control-label" for="example-hf-password">Type</label>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddtype" runat="server" AutoPostBack="true" data-toggle="tooltip" title="Contact Type" CssClass="form-control">
                                        <asp:ListItem Value="None">None</asp:ListItem>
                                        <asp:ListItem Value="Account">Account</asp:ListItem>
                                        <asp:ListItem Value="Prospect">Prospect</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddtype" InitialValue="None" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="Select a type" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <asp:UpdatePanel ID="upcontactid" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="col-md-3">
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
                            <div class="col-md-12">
                                <label class="col-md-2 control-label" for="example-hf-password">Source Type</label>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddsourcetype" runat="server" data-toggle="tooltip" title="Related Type" CssClass="form-control">
                                        <asp:ListItem Value="None">Other</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddtype" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="Please enter  Task name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddsourcetypeid" runat="server" name="example-chosen" class="select-chosen" data-toggle="tooltip" title="Related Type ID"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtname" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="Please enter  Task name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Desc</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtdec" runat="server" placeholder="Enter Desc" TextMode="MultiLine" Columns="2" Rows="2" data-toggle="tooltip" title="Enter Service Name"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtname" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter  Task name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                         <div class="col-md-12">
                             <User:AssignControl ID="assigncontrol" runat="server" />
                             </div>
                            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                                <div class="pull-right">
                                    <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" />
                                    <asp:LinkButton ID="hfcancel" Text="Cancel" runat="server" NavigateUrl="~/MainOpportunity.aspx" class="btn btn-alt btn-sm btn-danger" CausesValidation ="false"  />
                                </div>
                            </div>

                            <div style="clear: both"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <User:ItemDetailControl ID="itemdtcontrol" runat="server" />
            </div>
        </div>
        <asp:HiddenField ID="hftype" runat="server" />
        <asp:HiddenField ID="hftypeid" runat="server" />
    </div>
</asp:Content>

