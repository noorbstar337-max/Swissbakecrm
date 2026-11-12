<%@ Control Language="VB" AutoEventWireup="false" CodeFile="QuotationControl.ascx.vb" Inherits="UserControl_Back_QuotationControl" %>
<asp:HiddenField ID="hftype" runat="server" />
<asp:HiddenField ID="hftypeid" runat="server" />
<div class="panel panel-default">
    <div class="panel-heading">
        <h4 class="panel-title"><a class="accordion-toggle" data-toggle="collapse" data-parent="#faq007" href="#faq007_q74">
            <asp:Literal ID="ltstage" Text="Email" runat="server"></asp:Literal></a></h4>
    </div>
    <div id="faq007_q74" class="panel-collapse collapse">
        <div class="panel-body">
            <asp:Button ID="btncomposeemail" runat="server" Style="margin-bottom: 8px" CssClass="btn btn-alt btn-xs btn-primary" Text="Create Quotation" />
            <asp:UpdatePanel ID="updocument" runat="server">
                <ContentTemplate>
                    <div class="table-responsive">
                        <asp:GridView ID="grdquotation" GridLines="None" CssClass="table table-striped table-vcenter" CellPadding="0" CellSpacing="0" HeaderStyle-Width="100" HeaderStyle-Font-Size="Smaller" HeaderStyle-Font-Bold="true" runat="server" AutoGenerateColumns="false"
                            AllowPaging="true" PageSize="5">
                            <Columns>
                                <asp:TemplateField HeaderText="Quotation No" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                    <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink21" runat="server">Quotation No</asp:HyperLink>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="ltamount" runat="server" NavigateUrl='<%#Page.ResolveUrl("ModifyQuotation.aspx?chk=v&returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Quotation_Id").ToString())))%>' Text='<%#Eval("Quotation_No")%>'></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                    <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink23" runat="server">Date</asp:HyperLink>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Literal ID="ltexpectedrevenue" runat="server" Text='<%#(DynamicparcelDataManipulation.AlphaDateFormat(Eval("Quotation_Date")))%>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                    <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink22" runat="server">Status</asp:HyperLink>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Literal ID="lblProbability" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Quotation_QuoStatus")))%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                    <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink24" runat="server">Acc Name</asp:HyperLink>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Literal ID="ltclosingdate" runat="server" Text='<%#(Eval("Acc_name"))%>'></asp:Literal>
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
                    <asp:AsyncPostBackTrigger ControlID="grdquotation" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</div>