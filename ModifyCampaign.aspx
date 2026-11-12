<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ModifyCampaign.aspx.vb" Inherits="ModifyCampaign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .control-label{padding: 6px;
        }
       .col-md-4 > .form-group {
        padding-bottom:0px;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <asp:HiddenField ID="hfemail" runat="server" />
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <i class="gi gi-shop" style="margin: -8px"></i>Modify Campaign<br>
                    </h1>
                </div>
            </div>

            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="Campaign.aspx">Campaign</a></li>
                <li>Modify Campaign</li>
            </ul>

            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" OnClick="btnadd_Click"/>
                        <asp:HyperLink ID="HyperLink1" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/Campaign.aspx" class="btn btn-alt btn-sm btn-danger" />
                </div>
            </div>
            <div class="col-md-12">
                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <h4 class="widget-content-light abc">
                            <strong>Campaign</strong> Information
                            <small>
                                <span class="pull-right" id="modifyspan" runat="server" >
                            By&nbsp;<a style="text-decoration:none;"><asp:Label ID="lblmodifiedname" runat="server" Font-Bold="true"></asp:Label></a>&nbsp;on&nbsp;<a style="text-decoration:none;"><asp:Label ID="lblmodifieddate" Font-Bold="true" runat="server" Font-Italic="true"></asp:Label></a>
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
                        <div class="form-group">
                            <label class="col-md-4 control-label" for="example-hf-email">Title<span class="text-danger"> *</span></label>
                            <div class="col-md-8">
                                 <asp:TextBox ID="txttitle" runat="server" placeholder="Enter Campaign Title" data-toggle="tooltip" title="Enter Campaign Title"
                                    CssClass="form-control" TabIndex="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="retitle" runat="server" ControlToValidate="txttitle" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Select campaign title" SetFocusOnError ="true" ></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="col-md-4 control-label" for="example-hf-email">Campaign Type<span class="text-danger"> *</span></label>
                            <div class="col-md-8">
                                 <asp:DropDownList ID="ddcampaign_type" runat="server" name="example-chosen" class="select-chosen" TabIndex="2"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddcampaign_type" InitialValue="select campaign type" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Select campaign type" SetFocusOnError ="true" ></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                       <div class="form-group">
                            <label class="col-md-4 control-label" for="example-hf-password">Start Date<span class="text-danger"> *</span></label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtstartdate" runat="server" placeholder="dd/mm/yy" data-toggle="tooltip" title="Enter Start Date"
                                    CssClass="form-control input-datepicker" data-date-format="dd/mm/yy" TabIndex="3"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtstartdate" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Enter start date" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                           <div class="form-group">
                            <label class="col-md-4 control-label" for="example-hf-password">End Date<span class="text-danger"> *</span></label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtenddate" runat="server" data-toggle="tooltip" placeholder="dd/mm/yy" title="Enter End Date"
                                    CssClass="form-control input-datepicker" data-date-format="dd/mm/yy" TabIndex="4"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtenddate" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Enter end date" SetFocusOnError ="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="col-md-4 control-label" for="example-hf-password">Campaign Budget<span class="text-danger">*</span></label>
                            <div class="col-md-8">
                                 <asp:TextBox ID="txtbudget" runat="server" placeholder="Enter Campaign Budget" data-toggle="tooltip" title="Enter Campaign Budget"
                                    CssClass="form-control" TextMode="Number"  TabIndex="5"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtbudget" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Enter campaign budget" SetFocusOnError ="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="col-md-4 control-label" for="example-hf-password">No. of Lead</label>
                            <div class="col-md-8">
                                 <asp:TextBox ID="txtlead" runat="server" placeholder="Enter No. of Lead" data-toggle="tooltip" title="Enter No. of Lead"
                                    CssClass="form-control" TextMode="Number"  TabIndex="6"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtlead" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Enter no. of lead" SetFocusOnError ="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                          <div class="form-group">
                            <label class="col-md-1 control-label" for="example-hf-password">Remark</label>
                            <div class="col-md-11">
                                 <asp:TextBox ID="txtremark" runat="server" placeholder="Enter Remark" data-toggle="tooltip" title="Enter Remark"
                                    CssClass="form-control" TabIndex="7"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtremark" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Enter remark" SetFocusOnError ="true"></asp:RequiredFieldValidator>
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
                            UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" TabIndex="8" />
                        <asp:HyperLink ID="hfcancel" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/Campaign.aspx" class="btn btn-alt btn-sm btn-danger" TabIndex="9" />
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

