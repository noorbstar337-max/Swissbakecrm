<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="QRDetails.aspx.vb" Inherits="QRDetails" %>
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
                        <i class="gi gi-parents" style="margin: -8px"></i>Quotations<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li>Quotations</li>
            </ul>
            <div class="block">
                <div class="block-title">
                    <h2><strong>Quotation</strong> Detail</h2>
                </div>
                <%--Search User Control Start--%>
                <User:SearchBarByID ID="SearchControl" runat="server" />
                <%--   <User:SearchBar ID="SearchControl" runat="server" />--%>

                <%--Search User Control End--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="hfcheck" runat="server" />
                        <asp:HiddenField ID="hfchanged" runat="server" />
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="QuotationRequest_No" AllowCustomPaging="true"
                                CssClass="table table-striped table-vcenter " AlternatingRowStyle-CssClass="Alternate_grid"
                                AllowPaging="True" PageSize="10" AllowSorting="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="QR-No" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="QuotationRequest_No">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hpsponsor" EnableViewState="false" NavigateUrl='<%# "ViewQuotationResponse.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("QuotationRequest_ID").ToString())) & "&VId=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Vendor_Id").ToString()))%>'
                                                data-toggle="tooltip" title="View" runat="server">
                                                <asp:Literal ID="LblR" runat="server" Text='<%#Eval("QuotationRequest_ID")%>' Visible="false" />
                                                <asp:Literal ID="LblV" runat="server" Text='<%#Eval("Vendor_Id")%>' Visible="false" />
                                                <asp:Literal ID="lblid" runat="server" Text='<%#Eval("QuotationRequest_No")%>' Visible="false" />
                                                <asp:Literal ID="lblQRNo" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("QuotationRequest_No"), SearchControl.UtxtSearch)%>' />
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:TemplateField HeaderText="Vendor-Code" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Vendor_Code" Visible ="false" >
                                        <ItemTemplate>
                                            <asp:Literal ID="lblVendorCode" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Vendor_Code"), SearchControl.UtxtSearch)%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%><asp:TemplateField HeaderText="Vendor-Name" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Vendor_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblVendorName" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Vendor_Name"), SearchControl.UtxtSearch)%>' />
                                            <asp:Literal ID="ltname" runat="server" Visible="false" Text='<%#(Eval("Vendor_Name"))%>'></asp:Literal>
                                             <asp:Literal ID="LblResponse_ID" runat="server" Text='<%#Eval("QuotationResponse_ID")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Raw-Material" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Rm_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblRMName" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Rm_Name"), SearchControl.UtxtSearch)%>' />
                                            <asp:Literal ID="lblRMID" runat="server" Text='<%#Eval("Rm_ID")%>' Visible="false" />
                                            <asp:Literal ID="lblQResponse_Code" runat="server" Text='<%#Eval("QuotationResponse_Code")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Quantity">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblQty" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Quantity"), SearchControl.UtxtSearch)%>' />
                                            <asp:Literal ID="lblQty1" runat="server" Text='<%#Eval("Quantity")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Amount">
                                        <ItemTemplate>
                                            <i class="fa fa-inr "></i>&nbsp;
                                            <asp:Literal ID="lblAmount" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Convert.ToDouble(Eval("Amount")).ToString("#,##0.00"), SearchControl.UtxtSearch)%>' />
                                            <asp:Literal ID="lblAmount1" runat="server" Text='<%#Eval("Amount")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Per-Unit" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Per_Unit">
                                        <ItemTemplate>
                                            <i class="fa fa-inr "></i>&nbsp;
                                            <asp:Literal ID="lblPerUnit" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Convert.ToDouble(Eval("Per_Unit")).ToString("#,##0.00"), SearchControl.UtxtSearch)%>' />
                                            <asp:Literal ID="lblPerUnit1" runat="server" Text='<%#Eval("Per_Unit")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tax" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Tax">
                                        <ItemTemplate>
                                            <i class="fa fa-inr "></i>&nbsp;
                                            <asp:Literal ID="lblTax" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Convert.ToDouble(Eval("Tax")).ToString("#,##0.00"), SearchControl.UtxtSearch)%>' />
                                            <asp:Literal ID="lblTax1" runat="server" Text='<%#Eval("Tax")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Freight" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Freight">
                                        <ItemTemplate>
                                            <i class="fa fa-inr "></i>&nbsp;
                                            <asp:Literal ID="lblFreight" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Convert.ToDouble(Eval("Freight")).ToString("#,##0.00"), SearchControl.UtxtSearch)%>' />
                                            <asp:Literal ID="lblFreight1" runat="server" Text='<%#Eval("Freight")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Total">
                                        <ItemTemplate>
                                            <i class="fa fa-inr "></i>&nbsp;
                                            <asp:Literal ID="lblTotal" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Convert.ToDouble(Eval("Total")).ToString("#,##0.00"), SearchControl.UtxtSearch)%>' />
                                            <asp:Literal ID="lblTotal1" runat="server" Text='<%#Eval("Total")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="QR-Vendor" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="QuotationRequest_Vendor_ID">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblname2" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("QuotationRequest_Vendor_ID"), SearchControl.UtxtSearch)%>' />                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="View" Visible="false" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink4" runat="server">View</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="hlview" EnableViewState="false" NavigateUrl='<%# "AddQuotationResponse.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("QuotationRequest_ID").ToString()))%>'
                                                    data-toggle="tooltip" title="View" class="btn btn-default" runat="server"><i class="fa fa-eye "></i></asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="QuotationResponse_Status">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblStatus" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("QuotationResponse_Status"), SearchControl.UtxtSearch)%>' />
                                            <asp:Literal ID="lblstatus1" runat="server" Text='<%#(Eval("QuotationResponse_Status"))%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink4" runat="server">Edit</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="hledit" EnableViewState="false" NavigateUrl='<%# "AddQuotationResponse.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("QuotationRequest_ID").ToString())) & "&VId=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Vendor_Id").ToString()))%>'
                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Delete" ItemStyle-Width="10px" HeaderStyle-CssClass="MasterGridviewHeader1" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Delete">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLinkdelete" runat="server">Delete</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                    CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%><%--   <asp:TemplateField HeaderText="Delete" ItemStyle-Width="10px" HeaderStyle-CssClass="MasterGridviewHeader1" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Delete" Visible="false">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLinkdelete" runat="server">Delete</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                    CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%><asp:TemplateField HeaderText="Action" ItemStyle-Width="10px" HeaderStyle-CssClass="MasterGridviewHeader1" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Delete" Visible="true">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLinkAction" runat="server">Action</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:LinkButton ID="lnkApproved" data-toggle="tooltip" title="Approved" class="btn btn-success" runat="server"
                                                    CommandName="Approvedink" CommandArgument='<%#Eval("QuotationRequest_ID").ToString() + ","+Eval("Vendor_Id").ToString() %>'>Approve</asp:LinkButton>
                                                <asp:LinkButton ID="lnkPO" data-toggle="tooltip" title="Create PO" class="btn btn-warning" runat="server"
                                                        CommandName="createPO" CommandArgument='<%#Eval("QuotationRequest_ID").ToString() + ","+Eval("Vendor_Id").ToString() %>'>Create PO</asp:LinkButton>
                                                <%--  <asp:LinkButton ID="LnkViewPO" data-toggle="tooltip" title="View PO" class="btn btn-info" runat="server"  OnClientClick="aspnetForm.target ='_blank';"
                                                    CommandName="ViewPo"  CommandArgument='<%#Eval("QuotationRequest_ID").ToString() + ","+Eval("Vendor_Id").ToString() %>'>View PO</asp:LinkButton>--%>

                                                <a id="LnkViewPO" runat="server"  data-toggle="tooltip" title="View PO" class="btn btn-alt btn-xs btn-success" href='<%#"Purchaseorder.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("QuotationRequest_ID").ToString)) + "&VId=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Vendor_Id").ToString))%>' target="_blank"><i class="fa fa-print"></i>&nbsp;View PO</a>
                                            </div>
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
                        <%--<asp:PostBackTrigger ControlID="btnsave" />--%>
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


