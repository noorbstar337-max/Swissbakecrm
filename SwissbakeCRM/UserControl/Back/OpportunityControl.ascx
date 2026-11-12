<%@ Control Language="VB" AutoEventWireup="false" CodeFile="OpportunityControl.ascx.vb" Inherits="UserControl_Back_OpportunityControl" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:HiddenField ID="hftype" runat="server" />
<asp:HiddenField ID="hftypeid" runat="server" />
<div id="faq856" class="panel-group">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq856" href="#faq856_q12">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblcontact" Text="Oportunity" runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                    </Triggers>
                </asp:UpdatePanel>
            </a></h4>
        </div>
        <div id="faq856_q12" class="panel-collapse collapse" style="height: 0px;">
            <div class="panel-body">
                <asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlcontactPopup" TargetControlID="btnShow"
                    CancelControlID="btnNo">
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlcontactPopup" runat="server" Style="display: none" DefaultButton="btnsave">
                    <div class="modal-dialog modal-sm">
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                                <h3 class="modal-title">Add Opportunity</h3>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <span class="text-danger">
                                        <label for="example-nf-email">Name </label>
                                    </span>
                                    <asp:TextBox ID="txtname" runat="server" placeholder="Enter Name" data-toggle="tooltip" title="Enter Name"
                                        CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="refirstname" runat="server" Display="Dynamic" ControlToValidate="txtname" ValidationGroup="OpportunityGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="Please enter name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label for="example-nf-email">Expected Date </label>
                                    <asp:TextBox ID="txtduedate" runat="server" placeholder="Enter Expected Date" data-toggle="tooltip" title="Enter Expected Date"
                                        CssClass="form-control"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtduedate" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtduedate" ValidationGroup="OpportunityGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="Please select date" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label for="example-nf-email">Owner </label>
                                    <asp:DropDownList ID="ddowner" runat="server" data-toggle="tooltip" title="Task Owner" name="example-chosen" class="select-chosen">
                                    </asp:DropDownList>
                                    <asp:RegularExpressionValidator ID="rgmobship" Enabled="false" runat="server" ValidationGroup="sd" ErrorMessage="Please enter valid mobile number" ControlToValidate="txtname"
                                        ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <label for="example-nf-email">Amount </label>
                                    <asp:TextBox ID="txtamount" runat="server" Text="0" placeholder="Enter Amount" AutoPostBack="true" data-toggle="tooltip" title="Enter Amount"
                                        CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lbprobability" Visible="false" CssClass="text-primary" Font-Size="12" runat="server"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label for="example-nf-email">Stage </label>
                                    <asp:DropDownList ID="ddstage" runat="server" data-toggle="tooltip" AutoPostBack="true" title="Task Owner" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Enabled="false" runat="server" ValidationGroup="sd" ErrorMessage="Please enter valid mobile number" ControlToValidate="txtname"
                                        ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <label for="example-nf-email">Expected Revenue </label>
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
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-primary" Text="Save" ValidationGroup="OpportunityGroup"></asp:Button>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <div class="">
                    <asp:LinkButton ID="btnShow" runat="server" CssClass="btn btn-alt btn-xs btn-primary">New Opportunity</asp:LinkButton><br />
                    <br />
                </div>
                <asp:UpdatePanel ID="updocument" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" HeaderStyle-Font-Size="Smaller" PageSize="5" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true" DataKeyNames="Opportunity_Id" CssClass="table table-striped table-vcenter" GridLines="None"
                                AllowPaging="True" AllowSorting="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink4" runat="server">Edit</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="HyperLink2" EnableViewState="false" NavigateUrl='<%# Page.ResolveUrl("opportunity.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Opportunity_Id").ToString())))%>'
                                                    data-toggle="tooltip" title="Edit" class="btn btn-Primary" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="" Visible="false" ItemStyle-CssClass="" SortExpression="Opportunity_Id">
                                        <ItemTemplate>
                                            <asp:Literal ID="lbluId" runat="server" Text='<%#(Eval("Opportunity_Id"))%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Opportunity Name" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Opportunity_Name">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" EnableViewState="false" NavigateUrl='<%# Page.ResolveUrl("Viewopportunity.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Opportunity_Id").ToString())))%>'
                                                data-toggle="tooltip" title="View" runat="server">
                                              <%#(Eval("Opportunity_Name"))%>
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Opportunity Amount" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Opportunity_Amount">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblOpportunityAmount" runat="server" Text='<%#((Math.Round(CDbl(DynamicparcelDataManipulation.FixNullFromDB(Eval("Opportunity_Amount"))), 2)))%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Expected Revenue" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="OppStage_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblRevenue" runat="server" Text='<%#((Math.Round(CDbl(DynamicparcelDataManipulation.FixNullFromDB(Eval("Revenue"))), 2)))%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Probability" ItemStyle-CssClass="" ItemStyle-Width="300px" HeaderStyle-CssClass="" SortExpression="OppStage_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblProbability" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("OppStage_Probability")))%>' Visible="false" />
                                            <div class="progress progress-striped active" style="margin-bottom: 0px">
                                                <div id="divprogress" runat="server" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 40%"><%#Eval("OppStage_Probability")%>%</div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Expected Date" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Opportunity_ExpectedDate">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblcontact" runat="server" Text='<%#(DynamicparcelDataManipulation.AlphaDateFormat(Eval("Opportunity_ExpectedDate")))%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Stage" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="OppStage_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblphone" runat="server" style="color:white;padding: 0 10px;border-radius: 3px;" BackColor='<%#(System.Drawing.Color.FromName(Eval("OppStage_ColorBand").ToString))%>' Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("OppStage_Name")))%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="left" BackColor="White" />
                                <FooterStyle HorizontalAlign="left" BackColor="White" />
                                <PagerSettings PageButtonCount="4" />
                                <EmptyDataTemplate>
                                    <asp:Label ID="s" runat="server" Text="No Record Found"></asp:Label><br />
                                    <br />
                                </EmptyDataTemplate>
                                <EmptyDataRowStyle HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</div>
