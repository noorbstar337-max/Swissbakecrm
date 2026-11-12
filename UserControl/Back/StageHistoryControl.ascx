<%@ Control Language="VB" AutoEventWireup="false" CodeFile="StageHistoryControl.ascx.vb" Inherits="UserControl_Back_StageHistoryControl" %>
<asp:HiddenField ID="hftype" runat="server" />
<asp:HiddenField ID="hftypeid" runat="server" />
<div class="panel panel-default">
    <div class="panel-heading">
        <h4 class="panel-title"><a class="accordion-toggle" data-toggle="collapse" data-parent="#faq74" href="#faq74_q74">
            <asp:Literal ID="ltstage" runat="server"></asp:Literal></a></h4>
    </div>
    <div id="faq74_q74" class="panel-collapse collapse">
        <div class="panel-body">
            <asp:UpdatePanel ID="updocument" runat="server">
                <ContentTemplate>
                    <div class="table-responsive">
                        <asp:GridView ID="grdstage" GridLines="None" CssClass="table table-striped table-vcenter" CellPadding="0" CellSpacing="0" HeaderStyle-Width="100" HeaderStyle-Font-Size="Smaller" HeaderStyle-Font-Bold="true" runat="server" AutoGenerateColumns="false"
                            AllowPaging="true" PageSize="5">
                            <Columns>
                                <asp:TemplateField HeaderText="Amount" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                    <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink21" runat="server">Amount</asp:HyperLink>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Literal ID="ltamount" runat="server" Text='<%#Eval("OpStageHistory_Amount")%>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                              
                                <asp:TemplateField HeaderText="Expected Revenue" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                    <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink23" runat="server">Expected Revenue</asp:HyperLink>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Literal ID="ltexpectedrevenue" runat="server" Text='<%#Math.Round(CDbl(Eval("Revenue")),2)%>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Probability" ItemStyle-Width="300px" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                    <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink22" runat="server">Probability</asp:HyperLink>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%-- <asp:Literal ID="ltprobability" runat="server" Text='<%#Eval("OppStage_Probability")%>'></asp:Literal>--%>
                                        <asp:Literal ID="lblProbability" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("OppStage_Probability")))%>' Visible="false" />
                                        <div class="progress progress-striped active" style="margin-bottom: 0px">
                                            <div id="divprogress" runat="server" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 40%"><%#Eval("OppStage_Probability")%>%</div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Closing Date" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                    <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink24" runat="server">Closing Date</asp:HyperLink>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Literal ID="ltclosingdate" runat="server" Text='<%#DynamicparcelDataManipulation.AlphaDateFormat(Eval("OpStageHistory_ExpectedDate"))%>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Modified Time" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                    <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink25" runat="server">Modified Time</asp:HyperLink>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Literal ID="ltmodifiedtime" runat="server" Text='<%#Eval("OpStageHistory_CreatedDate")%>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Stage" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                    <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink222" runat="server">Stage</asp:HyperLink>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="ltstage" runat="server" Style="color: white; padding: 0 10px; border-radius: 3px;" BackColor='<%#(System.Drawing.Color.FromName(Eval("OppStage_ColorBand").ToString))%>' Text='<%#Eval("OppStage_Name")%>'></asp:Label>
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
                    <asp:AsyncPostBackTrigger ControlID="grdstage" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
