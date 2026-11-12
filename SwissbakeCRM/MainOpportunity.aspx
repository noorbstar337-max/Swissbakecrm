<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="MainOpportunity.aspx.vb" Inherits="MainOpportunity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function checkdelete() {
            if (confirm('Are you Sure want to Delete?')) {
                document.getElementById('<%=deletestatus.ClientID %>').value = "yes";
                return true
            }
            else {
                document.getElementById('<%=deletestatus.ClientID %>').value = "no";
                return true
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="deletestatus" runat="server" />
    <asp:HiddenField ID="Hfgridview" runat="server" />
    <asp:HiddenField ID="hftotalrecord" runat="server" />
    <asp:HiddenField ID="hfsearch" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="content-header">
                <div class="header-section">
                    <h1>
                        <i class="gi gi-parents" style="margin: -8px"></i>Opportunity<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li>Opportunity</li>
            </ul>
            <div class="block">
                <div class="block-title">
                    <h2><strong>Opportunity</strong> Detail</h2>
                </div>
                <%--Search User Control Start--%>
                <User:SearchBarByID ID="SearchControl" runat="server" />
                <%--Search User Control End--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="hfcheck" runat="server" />
                        <asp:HiddenField ID="hfchanged" runat="server" />
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Opportunity_Id" AllowCustomPaging="true" 
                                CssClass="table table-striped table-vcenter" OnSorting="GridView1_Sorting" GridLines="None"
                                AllowPaging="True" AllowSorting="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink4" runat="server">Edit</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="HyperLink2" EnableViewState="false" NavigateUrl='<%# "opportunity.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Opportunity_Id").ToString()))%>'
                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="" Visible="false" ItemStyle-CssClass="" SortExpression="Opportunity_Id">
                                        <ItemTemplate>
                                            <asp:Literal ID="lbluId" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Opportunity_Id"), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Opportunity Name" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Opportunity_Name">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" EnableViewState="false" NavigateUrl='<%# "Viewopportunity.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Opportunity_Id").ToString()))%>'
                                                data-toggle="tooltip" title="View" runat="server">
                                              <%#DynamicparcelGridview.HighlightText(Eval("Opportunity_Name"), SearchControl.UtxtSearch)%>
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Acc/Pros Name" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Acc_Name">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink145" EnableViewState="false" NavigateUrl='<%# "ViewAccount.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Acc_Id").ToString()))%>'
                                                data-toggle="tooltip" title="View" runat="server">
                                              <%#DynamicparcelGridview.HighlightText(Eval("Acc_Name"), SearchControl.UtxtSearch)%>
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Opportunity Amount"  ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Opportunity_Amount">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblOpportunityAmount" runat="server"  Text='<%#(DynamicparcelGridview.HighlightText(Math.Round(CDbl(DynamicparcelDataManipulation.FixNullFromDB(Eval("Opportunity_Amount"))), 2), SearchControl.UtxtSearch))%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:TemplateField HeaderText="Expected Revenue"  ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="OppStage_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblRevenue" runat="server" Text='<%#(DynamicparcelGridview.HighlightText(Math.Round(CDbl(DynamicparcelDataManipulation.FixNullFromDB(Eval("Revenue"))), 2), SearchControl.UtxtSearch))%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Probability" ItemStyle-CssClass="" ItemStyle-Width="200px" HeaderStyle-CssClass="" SortExpression="OppStage_Name">
                                        <ItemTemplate>
                                           <asp:Literal ID="lblProbability" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("OppStage_Probability")))%>' Visible="false" />
                                             <div class="progress progress-striped active" style="margin-bottom:0px">
                                                    <div id="divprogress" runat="server" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100"  style="width: 40%"><%#Eval("OppStage_Probability")%>%</div>
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
                                            <asp:Label ID="lblstagename" runat="server" style="color:white;padding: 0 10px;border-radius: 3px;" BackColor='<%#(System.Drawing.Color.FromName(Eval("OppStage_ColorBand").ToString))%>' Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("OppStage_Name")), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="AssignTo" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="AssignTo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblassignto" runat="server"  Text='<%#DynamicparcelGridview.HighlightText(Eval("AssignTo"), SearchControl.UtxtSearch)%>' />
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
                        <asp:AsyncPostBackTrigger ControlID="GridView1" />
                        <%-- <asp:PostBackTrigger ControlID="btnsave" />--%>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <br />
            <div class="divWaiting">
                <i class="fa fa-sun-o fa-spin" id="LoadingUpadatePanel"></i>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

