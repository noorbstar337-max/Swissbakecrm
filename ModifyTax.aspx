<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ModifyTax.aspx.vb" Inherits="ModifyTax" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        input[type="checkbox"], input[type="radio"] {
            margin-right: 5px;
        }

        #ContentPlaceHolder1_rdtax > tbody > tr > td {
            padding: 0 38px 0 0;
        }

        #ContentPlaceHolder1_rdtaxPrincipal > tbody > tr > td {
            padding: 0 38px 0 0;
        }

        #ContentPlaceHolder1_rdaddition > tbody > tr > td {
            padding: 0 38px 0 0;
        }

        #ContentPlaceHolder1_checkbox_tax > tbody > tr > td {
            padding: 0 38px 0 0;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <asp:HiddenField ID="deletestatus" runat="server" />
        <asp:HiddenField ID="hfTax" runat="server" />
        <asp:HiddenField ID="hfaddcharge" runat="server" />
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <i class="gi gi-table" style="margin: -8px"></i>Tax Master<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="Tax.aspx">Tax </a></li>
                <li>ModifyTax </li>
            </ul>
            <div class="col-md-12" id="divpart1" runat="server">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="widget">
                            <div class="widget-extra-full">
                                <ul class="nav nav-tabs" data-toggle="tabs">
                                    <li id="taxx" runat="server"><a href="#tabsss" data-toggle="tooltip" title="Tax" runat="server"><strong>&nbsp;&nbsp;Tax</strong></a></li>
                                    <li id="addcharge" runat="server"><a href="#tabss" data-toggle="tooltip" title="Additional Charges" runat="server"><strong>&nbsp;&nbsp;Additional Charges</strong></a></li>
                                </ul>

                                <div class="tab-content">
                                    <div class="tab-pane active" id="tabsss" runat="server" visible="false">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <div class="form-group" id="divtax" runat="server">
                                                            <br />
                                                            <div class="col-md-4">
                                                                <asp:RadioButton ID="rdbtaxprincipal" runat="server" Text="Tax on Principal" GroupName="taxprincipal" Checked="true" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:RadioButton ID="rdbtaxtax" runat="server" Text="Tax on Tax" GroupName="taxprincipal" AutoPostBack="true" />
                                                            </div>
                                                            <div class="col-md-8" id="divtaxmapcontrol" runat="server">
                                                                <User:MappingTaxNameControl ID="MappingTaxNameControl" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <label for="example-nf-email">Tax Name <span class="text-danger">*</span></label>
                                                    <asp:TextBox ID="txttaxname" runat="server" placeholder="Enter Tax Name" data-toggle="tooltip" title="Enter Tax Name" TabIndex="1"
                                                        CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="remembername" runat="server" ControlToValidate="txttaxname" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                        ErrorMessage="Please enter tax "></asp:RequiredFieldValidator>
                                                </div>

                                                <div class="col-md-4" id="taxpercent" runat="server">
                                                    <label for="example-nf-email">Tax Percent <span class="text-danger">*</span></label>
                                                    <asp:TextBox ID="txttaxpercent" runat="server" placeholder="Enter Tax Percent" data-toggle="tooltip" title="Enter Tax Percent" TabIndex="2"
                                                        CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttaxpercent" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                        ErrorMessage="Please enter tax percent"></asp:RequiredFieldValidator>
                                                </div>

                                                <div class="col-md-4">
                                                    <label for="example-nf-email">Sequence No <span class="text-danger"></span></label>
                                                    <asp:TextBox ID="txtsequence" runat="server" placeholder="Sequence No" data-toggle="tooltip" title="Enter Sequence No" TabIndex="3"
                                                        CssClass="form-control"></asp:TextBox>
                                                    <asp:Label ID="lbltaxseqno" runat="server" ForeColor="Red"></asp:Label><br />
                                                </div>

                                                <div class="col-md-12">
                                                    <asp:CheckBox ID="chkeditable" runat="server" Text="Editable Tax" TabIndex="4" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                                  
                                                    <asp:CheckBox ID="chkaddprincipal" runat="server" Text="Add to Principal" TabIndex="5" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <br />
                                                    <br />
                                                </div>

                                                <div class="form-group">
                                                    <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                                        UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroup" TabIndex="7" />
                                                    <asp:HyperLink ID="hfcancel" EnableViewState="false" Text="Cancel" runat="server" NavigateUrl="~/Tax.aspx" class="btn btn-alt btn-danger" TabIndex="8" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="tab-pane active" id="tabss" runat="server" visible="false">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <div class="form-group" id="divaddcharge" runat="server">
                                                            <br />
                                                            <asp:RadioButton ID="rdbaddition" runat="server" Text="Addition" GroupName="addsubcharge" Checked="true" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                                                         
                                                            <asp:RadioButton ID="rdbsubtraction" runat="server" Text="Subtraction" GroupName="addsubcharge" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <label for="example-nf-email">Additional Charges Name <span class="text-danger">*</span></label>
                                                    <asp:TextBox ID="txttaxname_charge" runat="server" placeholder="Enter Additional Charges Name" data-toggle="tooltip" title="Enter Additional Charges Name" TabIndex="1"
                                                        CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttaxname_charge" Display="Dynamic" ValidationGroup="MasterGroupAddCharge" CssClass="MasterValidationCSS"
                                                        ErrorMessage="Enter additional charges name "></asp:RequiredFieldValidator>
                                                </div>

                                                <div class="col-md-4" id="Div1" runat="server">
                                                    <label for="example-nf-email">Additional Charge  <span class="text-danger">*</span></label>
                                                    <asp:TextBox ID="txtaddcharge_charge" runat="server" placeholder="Enter Additional Charges " data-toggle="tooltip" title="Enter Additional Charges " TabIndex="2"
                                                        CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtaddcharge_charge" Display="Dynamic" ValidationGroup="MasterGroupAddCharge" CssClass="MasterValidationCSS"
                                                        ErrorMessage="Enter additional charges "></asp:RequiredFieldValidator>
                                                </div>

                                                <div class="col-md-4">
                                                    <label for="example-nf-email">Sequence No <span class="text-danger"></span></label>
                                                    <asp:TextBox ID="txtseq_charge" runat="server" placeholder="Sequence No" data-toggle="tooltip" title="Enter Sequence No" TabIndex="3"
                                                        CssClass="form-control"></asp:TextBox>
                                                    <asp:Label ID="lbladdcharge" runat="server" ForeColor="Red"></asp:Label><br />
                                                </div>

                                                <div class="col-md-12">
                                                    <asp:CheckBox ID="chkeditax_charge" runat="server" Text="Editable Tax" TabIndex="4" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                                  
                                                    <asp:CheckBox ID="chkaddprin_charge" runat="server" Text="Add to Principal" TabIndex="5" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <br />
                                                    <br />
                                                </div>

                                                <div class="form-group">
                                                    <asp:Button Text="Save" runat="server" ID="btnsavecharge" OnClientClick="if (!Page_ClientValidate('MasterGroupAddCharge')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                                        UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroupAddCharge" TabIndex="7" />
                                                    <asp:HyperLink ID="hfcancelcharge" EnableViewState="false" Text="Cancel" runat="server" NavigateUrl="~/Tax.aspx" class="btn btn-alt btn-danger" TabIndex="8" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <div class="col-md-12" id="divpart2" runat="server">
                <asp:UpdatePanel ID="UpdatePaneladdcharge" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="widget">
                            <div class="widget-extra-full">
                                <ul class="nav nav-tabs" data-toggle="tabs">
                                    <li class="active" runat="server"><a href="#tabsssmod" data-toggle="tooltip" title="Tax" runat="server"><strong>&nbsp;&nbsp;Tax</strong></a></li>
                                    <li runat="server"><a href="#tabssmod" data-toggle="tooltip" title="Additional Charges" runat="server"><strong>&nbsp;&nbsp;Additional Charges</strong></a></li>
                                </ul>

                                <div class="tab-content">
                                    <div class="tab-pane active" id="tabsssmod">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <div class="form-group" id="divtaxmod" runat="server">
                                                            <br />
                                                            <div class="col-md-4">
                                                                <asp:RadioButton ID="rdbtaxprincipalmod" runat="server" Text="Tax on Principal" GroupName="taxprincipalmod" Checked="true" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:RadioButton ID="rdbtaxtaxmod" runat="server" Text="Tax on Tax" GroupName="taxprincipalmod" AutoPostBack="true" />
                                                            </div>
                                                            <div class="col-md-8" id="divtaxmapcontrolmod" runat="server">
                                                                <User:MappingTaxNameControl ID="MappingTaxNameControl1" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <label for="example-nf-email">Tax Name <span class="text-danger">*</span></label>
                                                    <asp:TextBox ID="txttaxnamemod" runat="server" placeholder="Enter Tax Name" data-toggle="tooltip" title="Enter Tax Name" TabIndex="1"
                                                        CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="remembernamemod" runat="server" ControlToValidate="txttaxnamemod" Display="Dynamic" ValidationGroup="MasterGroupmod" CssClass="MasterValidationCSS"
                                                        ErrorMessage="Please enter tax "></asp:RequiredFieldValidator>
                                                </div>

                                                <div class="col-md-4" id="taxpercentmod" runat="server">
                                                    <label for="example-nf-email">Tax Percent <span class="text-danger">*</span></label>
                                                    <asp:TextBox ID="txttaxpercentmod" runat="server" placeholder="Enter Tax Percent" data-toggle="tooltip" title="Enter Tax Percent" TabIndex="2"
                                                        CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2mod" runat="server" ControlToValidate="txttaxpercentmod" Display="Dynamic" ValidationGroup="MasterGroupmod" CssClass="MasterValidationCSS"
                                                        ErrorMessage="Please enter tax percent"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-4">
                                                    <label for="example-nf-email">Sequence No <span class="text-danger"></span></label>
                                                    <asp:TextBox ID="txtsequencemod" runat="server" placeholder="Sequence No" data-toggle="tooltip" title="Enter Sequence No" TabIndex="3"
                                                        CssClass="form-control"></asp:TextBox>
                                                    <asp:Label ID="lbltaxseqnomod" runat="server" ForeColor="Red"></asp:Label><br />
                                                </div>

                                                <div class="col-md-12">
                                                    <asp:CheckBox ID="chkeditablemod" runat="server" Text="Editable Tax" TabIndex="4" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                                  
                                                    <asp:CheckBox ID="chkaddprincipalmod" runat="server" Text="Add to Principal" TabIndex="5" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <br />
                                                    <br />
                                                </div>

                                                <div class="form-group">
                                                    <asp:Button Text="Save" runat="server" ID="btnaddmod" OnClientClick="if (!Page_ClientValidate('MasterGroupmod')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                                        UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroupmod" TabIndex="7" />
                                                    <asp:HyperLink ID="hfcancelmod" EnableViewState="false" Text="Cancel" runat="server" NavigateUrl="~/Tax.aspx" class="btn btn-alt btn-danger" TabIndex="8" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="tab-pane" id="tabssmod">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:UpdatePanel ID="UpdatePanelseq" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div class="col-md-12">
                                                            <div class="form-group">
                                                                <div class="form-group" id="divaddchargemod" runat="server">
                                                                    <br />
                                                                    <asp:RadioButton ID="rdbadditionmod" runat="server" Text="Addition" GroupName="addsubchargemdo" Checked="true" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                                                         
                                                            <asp:RadioButton ID="rdbsubtractionmod" runat="server" Text="Subtraction" GroupName="addsubchargemod" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label for="example-nf-email">Additional Charges Name <span class="text-danger">*</span></label>
                                                            <asp:TextBox ID="txttaxname_chargemod" runat="server" placeholder="Enter Additional Charges Name" data-toggle="tooltip" title="Enter Additional Charges Name" TabIndex="1"
                                                                CssClass="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1mod" runat="server" ControlToValidate="txttaxname_chargemod" Display="Dynamic" ValidationGroup="MasterGroupAddChargemod" CssClass="MasterValidationCSS"
                                                                ErrorMessage="Enter additional charges name "></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-md-4" id="Div11" runat="server">
                                                            <label for="example-nf-email">Additional Charge  <span class="text-danger">*</span></label>
                                                            <asp:TextBox ID="txtaddcharge_chargemod" runat="server" placeholder="Enter Additional Charges " data-toggle="tooltip" title="Enter Additional Charges " TabIndex="2"
                                                                CssClass="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3mod" runat="server" ControlToValidate="txtaddcharge_chargemod" Display="Dynamic" ValidationGroup="MasterGroupAddChargemod" CssClass="MasterValidationCSS"
                                                                ErrorMessage="Enter additional charges "></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label for="example-nf-email">Sequence No <span class="text-danger"></span></label>
                                                            <asp:TextBox ID="txtseq_chargemod" runat="server" placeholder="Sequence No" data-toggle="tooltip" title="Enter Sequence No" TabIndex="3"
                                                                CssClass="form-control"></asp:TextBox>
                                                            <asp:Label ID="lbladdchargemod" runat="server" ForeColor="Red"></asp:Label><br />
                                                        </div>
                                                        <div class="col-md-12">
                                                            <asp:CheckBox ID="chkeditax_chargemod" runat="server" Text="Editable Tax" TabIndex="4" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                                  
                                                          <asp:CheckBox ID="chkaddprin_chargemod" runat="server" Text="Add to Principal" TabIndex="5" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                         <br />
                                                         <br />
                                                        </div>
                                                        <div class="form-group">
                                                            <asp:Button Text="Save" runat="server" ID="btnsavechargemod" OnClientClick="if (!Page_ClientValidate('MasterGroupAddChargemod')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                                                UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroupAddChargemod" TabIndex="7" />
                                                            <asp:HyperLink ID="hfcancelchargemod" EnableViewState="false" Text="Cancel" runat="server" NavigateUrl="~/Tax.aspx" class="btn btn-alt btn-danger" TabIndex="8" />
                                                        </div>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="txtseq_chargemod" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>

