<%@ Control Language="VB" AutoEventWireup="false" CodeFile="EmailViewControl.ascx.vb" Inherits="UserControl_Back_EmailViewControl" %>
<asp:HiddenField ID="hftype" runat="server" />
<asp:HiddenField ID="hftypeid" runat="server" />
<div class="panel panel-default">
    <div class="panel-heading">
        <h4 class="panel-title"><a class="accordion-toggle" data-toggle="collapse" data-parent="#faq725" href="#faq725_q74">
            <asp:Literal ID="ltstage" Text="Email" runat="server"></asp:Literal></a></h4>
    </div>
    <div id="faq725_q74" class="panel-collapse collapse">
        <div class="panel-body">
            <asp:Button ID="btncomposeemail" runat="server" Style="margin-bottom: 8px" CssClass="btn btn-alt btn-xs btn-primary" Text="Compose Email" />
            <asp:UpdatePanel ID="updocument" runat="server">
                <ContentTemplate>
                    <div class="table-responsive">
                        <asp:GridView ID="grdemail" GridLines="None" CssClass="table table-striped table-vcenter" CellPadding="0" CellSpacing="0" HeaderStyle-Width="100" HeaderStyle-Font-Size="Smaller" HeaderStyle-Font-Bold="true" runat="server" AutoGenerateColumns="false"
                            AllowPaging="true" PageSize="5">
                            <Columns>
                                <asp:TemplateField HeaderText="Subject" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                    <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink21" runat="server">Subject</asp:HyperLink>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="ltamount" runat="server" NavigateUrl='<%#Page.ResolveUrl("composemessage.aspx?chk=v&returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Email_Id").ToString())))%>' Text='<%#Eval("Email_Subject")%>'></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="To" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                    <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink23" runat="server">To</asp:HyperLink>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Literal ID="ltexpectedrevenue" runat="server" Text='<%#(Eval("Email_To"))%>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="From" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                    <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink22" runat="server">From</asp:HyperLink>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Literal ID="lblProbability" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Email_From")))%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                    <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink24" runat="server">Status</asp:HyperLink>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="ltclosingdate" runat="server" Text='<%#(Eval("Email_Status"))%>' CssClass='<%#Security.checkSentStatus (Eval("Email_Status"))%>'></asp:Label>
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
                    <asp:AsyncPostBackTrigger ControlID="grdemail" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
