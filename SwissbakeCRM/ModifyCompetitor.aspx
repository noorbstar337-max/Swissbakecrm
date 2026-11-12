<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ModifyCompetitor.aspx.vb" Inherits="ModifyCompetitor" %>
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
                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" />
                    <asp:LinkButton ID="LinkButton1" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/Activity.aspx" class="btn btn-alt btn-sm btn-danger" />
                </div>
            </div>

            <div class="col-md-12">
                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                      <h4 class="widget-content-light">
                            <strong>Competitor</strong> Information
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Competitor Name<span class="text-danger"> *</span></label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtname" runat="server" placeholder="Enter Competitor Name" data-toggle="tooltip" title="Enter Competitor Name"
                                        CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="refirstname" runat="server" ControlToValidate="txtname" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="Please competitor name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-password">Amount<span class="text-danger"> *</span></label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtamount" runat="server" placeholder="Enter Amount" data-toggle="tooltip" title="Enter Amount"
                                        CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtamount" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="Please enter amount" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Website</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtwebsite" runat="server" TextMode="Url" CssClass="form-control" placeholder="Enter Website" data-toggle="tooltip" title="Enter Website" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtwebsite" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter  website" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Strengths</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtstrengths" runat="server" TextMode="MultiLine" Columns="2" Rows="2" CssClass="form-control" data-toggle="tooltip" title="Enter Strengths" placeholder="Enter Strengths" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtwebsite" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter  strength" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Weaknesses</label>
                                    <div class="col-md-6">
                                         <asp:TextBox ID="txtweakness" runat="server" TextMode="MultiLine" Columns="2" Rows="2" CssClass="form-control" data-toggle="tooltip" title="Enter Weaknesses" placeholder="Enter Weaknesses" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtwebsite" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter  weakness" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                       <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Remark</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtremark" runat="server" placeholder="Enter Remark" TextMode="MultiLine" Columns="2" Rows="2" data-toggle="tooltip" title="Enter Remark"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtweakness" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter remark" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                           
<div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                                <div class="pull-right">
                                    <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" />
                                    <asp:LinkButton ID="hfcancel" Text="Cancel" CausesValidation="false" runat="server" NavigateUrl="~/Activity.aspx" class="btn btn-alt btn-sm btn-danger" />
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

