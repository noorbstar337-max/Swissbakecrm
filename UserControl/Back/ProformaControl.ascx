<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ProformaControl.ascx.vb" Inherits="UserControl_Back_ProformaControl" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:HiddenField ID="hftype" runat="server" />
<asp:HiddenField ID="hftypeid" runat="server" />
<div id="faq6454" class="panel-group">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq6454" href="#faq6454_q1285">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblcontact" Text="Proforma" runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                    </Triggers>
                </asp:UpdatePanel>
            </a></h4>
        </div>
        <div id="faq6454_q1285" class="panel-collapse collapse" style="height: 0px;">
            <div class="panel-body">
                <asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlcontactPopup" TargetControlID="btnShow"
                    CancelControlID="btnNo">
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlcontactPopup" runat="server" Style="display: none" DefaultButton="btnsave">
                    <div class="modal-dialog modal-sm">
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                                <h3 class="modal-title">Add Proforma</h3>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <span class="text-danger">
                                        <label for="example-nf-email">Proforma Date</label>
                                    </span>
                                   <asp:TextBox ID="txtduedate" runat="server" placeholder="Enter Expected Date" data-toggle="tooltip" title="Enter Expected Date"
                                        CssClass="form-control"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtduedate" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>
                                </div>
                                <asp:UpdatePanel ID="upquoamount" runat="server">
                                    <ContentTemplate>
                                        <div class="form-group">
                                    <label for="example-nf-email">Quotation Amount </label>
                                    <asp:Label ID="lblquoamount" runat="server"></asp:Label>
                                </div>
                                    </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="btnopneprofroma" /></Triggers>
                                </asp:UpdatePanel>
                                <div class="form-group">
                                    <label for="example-nf-email">Payable Now </label>
                                    <asp:TextBox ID="txtremark" runat="server" placeholder="Enter Remark" data-toggle="tooltip" title="Enter Remark"
                                        CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-primary" Text="Save" ValidationGroup="ProformaGroup"></asp:Button>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <div class="">
                    <asp:LinkButton ID="btnShow" runat="server"></asp:LinkButton> <asp:LinkButton ID="btnopneprofroma" runat="server" CssClass="btn btn-alt btn-xs btn-primary">New Proforma</asp:LinkButton><br />
                    <br />
                </div>
                <asp:UpdatePanel ID="updocument" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" ShowFooter="true" AutoGenerateColumns="false" CellPadding="0" CellSpacing="0" DataKeyNames="Id" AllowSorting="true" HeaderStyle-Font-Size="Smaller"
                                CssClass="table table-borderless table-striped" PageSize="5" GridLines="Horizontal" BorderWidth="0px" Width="100%" Font-Size="Small" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true"
                                AllowPaging="True">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-CssClass="">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink2" runat="server">Edit</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Page.ResolveUrl("ModifyProforma.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Id").ToString())))%>'
                                                    data-toggle="tooltip" title="Edit" class="btn btn-Primary" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Proforma Name" HeaderStyle-CssClass="" SortExpression="Proforma Name" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                            <asp:Literal ID="ltname" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Proforma Name"))%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-CssClass="" SortExpression="Amount" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                            <asp:Literal ID="ltAmount" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Amount"))%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Website" HeaderStyle-CssClass="" SortExpression="Website" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                            <asp:Literal ID="ltWebsite" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Website"))%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Strengths" HeaderStyle-CssClass="" SortExpression="Strengths" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                            <asp:Literal ID="ltStrengths" runat="server" Text='<%#DynamicparcelDisplayFunctions.TruncateDescription(DynamicparcelDataManipulation.FixNullFromDB(Eval("Strengths")), 80)%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Weaknesses" HeaderStyle-CssClass="" SortExpression="Weaknesses" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                            <asp:Literal ID="ltWeaknesses" runat="server" Text='<%#DynamicparcelDisplayFunctions.TruncateDescription(DynamicparcelDataManipulation.FixNullFromDB(Eval("Weaknesses")), 80)%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remark" HeaderStyle-CssClass="" SortExpression="Remark" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                            <asp:Literal ID="ltRemark" runat="server" Text='<%#DynamicparcelDisplayFunctions.TruncateDescription(DynamicparcelDataManipulation.FixNullFromDB(Eval("Remark")), 80)%>'></asp:Literal>
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
