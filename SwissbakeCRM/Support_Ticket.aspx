<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="Support_Ticket.aspx.vb" Inherits="Support_Ticket" %>

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
                        <i class="gi gi-parents" style="margin: -8px"></i>
                        <asp:Label ID="lbltitle1" runat="server">Support Ticket</asp:Label><br>
                        <asp:Label ID="lblconvertdate" runat="server" Visible="false"></asp:Label>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="Support.aspx">Support Ticket</a></li>
                <li>
                    <asp:Label ID="lbltitle2" runat="server"></asp:Label></li>
            </ul>
           <%-- <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <div class="" style="">
                        <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroup" OnClick="btnsubmit_Click" />
                        <asp:LinkButton ID="HyperLink1" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/Support.aspx" class="btn btn-alt btn-danger" />
                    </div>
                </div>
            </div>--%>
            <div class="col-md-12">
                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <h4 class="widget-content-light  abc">
                            <strong>Support</strong> Ticket
                           
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                            <div class="col-md-12">
                                <div class="row">

                                    <div class="col-md-3">
                                        <div class="">
                                            <label class="col-md-4 control-label" for="example-hf-email">Department<span class="text-danger"> *</span></label>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddldepartment" runat="server" name="example-chosen" class="select-chosen" TabIndex="1"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="reProspectname" runat="server" ControlToValidate="ddldepartment" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                    ErrorMessage="This is required" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4" id="divcode" runat="server">
                                        <div class="">
                                            <label class="col-md-3 control-label" for="example-hf-password">Subject<span class="text-danger"> *</span></label>
                                            <div class="col-md-9">
                                                <asp:DropDownList ID="ddsubject" runat="server" class="select-chosen" TabIndex="2">
                                                    <asp:ListItem Value="0">--- Select Subject ---</asp:ListItem>
                                                    <asp:ListItem Value="Website Support">Website Support</asp:ListItem>
                                                    <asp:ListItem Value="Order Support">Order Support</asp:ListItem>
                                                    <asp:ListItem Value="Shipping Support">Shipping Support</asp:ListItem>
                                                    <asp:ListItem Value="Product Support">Product Support</asp:ListItem>
                                                    <asp:ListItem Value="New Product Query">New Product Query</asp:ListItem>
                                                    <asp:ListItem Value="Suggestions">Suggestions</asp:ListItem>
                                                    <asp:ListItem Value="Return Request">Return Request</asp:ListItem>
                                                    <asp:ListItem Value="Payment Support">Payment Support</asp:ListItem>
                                                    <asp:ListItem Value="Bakery Support">Bakery Support</asp:ListItem>
                                                    <asp:ListItem Value="Packing Related">Packing Related</asp:ListItem>
                                                    <asp:ListItem Value="Product Related">Product Related</asp:ListItem>
                                                    <asp:ListItem Value="Service Related">Service Related</asp:ListItem>
                                                    <asp:ListItem Value="Others">Others</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddsubject" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                    InitialValue="0" ErrorMessage="This is required" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-5">
                                        <div class="">
                                            <label class="col-md-2 control-label" for="example-hf-email">Account<span class="text-danger"> *</span></label>
                                            <div class="col-md-10">
                                                <asp:DropDownList ID="ddrelatedtypeid" runat="server" name="example-chosen" CssClass="form-control select-chosen" class="select-chosen form-control" data-toggle="tooltip" title="Related Type ID" TabIndex="3"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddrelatedtypeid" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                    InitialValue="---Select Account Name---" ErrorMessage="This is required" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                </div>
                                <br />
                            <div class="col-md-12">
                                <div class="row">



                                    <div class="col-md-8">
                                        <label class="col-md-2 control-label" for="example-hf-password">Description<span class="text-danger"> *</span></label>
                                        <div >

                                            <asp:TextBox ID="txtaddress" runat="server" placeholder="Enter Discription" data-toggle="tooltip" data-placement="right" title="Enter Discription" TabIndex="4"
                                                CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="reIndustry" runat="server" ControlToValidate="txtaddress" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="">
                                            <label class="col-md-4 control-label" for="example-hf-password">Attachments</label>
                                            <div class="col-md-8">
                                                <asp:FileUpload ID="FileUpload1" runat="server" Style="border: 0px solid;" TabIndex="5" />
                                            </div>
                                        </div>
                                    </div>
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
                <asp:Button Text="Save" runat="server" ID="btnsubmit" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                    UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroup" TabIndex="6" />
                
                 <a ID="lkback" href="Support.aspx" class="btn btn-alt btn-danger" TabIndex="7" > Cancel</a>
                <br />
            </div>
        </div>
    </div>

</asp:Content>

