<%@ Page Title="" Language="VB" MasterPageFile="~/LMSMasterPage.master" AutoEventWireup="false" CodeFile="LMSChangePassword.aspx.vb" Inherits="LMSChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="widget">
                <div class="widget-extra themed-background-dark">
                    <div class="widget-options">
                    </div>
                    <h3 class="widget-content-light"><strong>Change Password</strong>
                    </h3>
                </div>
                <div class="widget-extra-full">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                    <div class="form-group" id="divoldpass" runat="server" >
                        <label for="example-nf-email">Old Password <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtoldpass" runat="server" placeholder="Enter Old Password" data-toggle="tooltip" title="Enter Old Password"
                            CssClass="form-control" TabIndex="1" TextMode="Password" AutoPostBack="true" onfocus="$(this).removeAttr('readonly');"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqoldpass" runat="server" ControlToValidate="txtoldpass" ValidationGroup="passwordgroup" CssClass="MasterValidationCSS"
                            ErrorMessage="Please enter a old password"></asp:RequiredFieldValidator>
                    </div>
 </ContentTemplate>                       
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div id="newpassdiv" runat="server">
                                <div class="form-group">
                                    <label for="example-nf-email">New Password <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtnewpass" runat="server" placeholder="Enter New Password" data-toggle="tooltip" title="Enter New Password"
                                        CssClass="form-control" TabIndex="2" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rqusername" runat="server" ControlToValidate="txtnewpass" ValidationGroup="passwordgroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="Please enter a new password"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label for="example-nf-email">Confirm Password <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtconfirm" runat="server" placeholder="Enter Confirm Password" data-toggle="tooltip" title="Enter Confirm Password"
                                        CssClass="form-control" TabIndex="3" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnewpass" ValidationGroup="passwordgroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="Please enter a confirm password" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cvpass" runat="server" ErrorMessage="Password does not match" ControlToValidate="txtconfirm" ControlToCompare="txtnewpass" Operator="Equal"
                                        ValidationGroup="passwordgroup" CssClass="MasterValidationCSS"></asp:CompareValidator>
                                    <br />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                    UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="passwordgroup" TabIndex="4" />
                                <asp:HyperLink ID="hfcancel" EnableViewState="False" Text="Cancel" runat="server" NavigateUrl="index.aspx" class="btn btn-alt btn-danger" TabIndex="5" />
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="txtoldpass" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

