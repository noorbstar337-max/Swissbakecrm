<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="QuotationRequest.aspx.vb" Inherits="QuotationRequest" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
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
                        <i class="gi gi-parents" style="margin: -8px"></i>Quotation Request<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li>Quotation Request</li>
            </ul>
            <div class="block">
                <div class="block-title">
                    <h2><strong>Quotation Request</strong> Detail</h2>
                </div>
                <%--Search User Control Start--%>
                <User:SearchBar ID="SearchControl" runat="server" />
                <%--Search User Control End--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="hfcheck" runat="server" />
                        <asp:HiddenField ID="hfchanged" runat="server" />
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="QuotationRequest_ID" AllowCustomPaging="true"
                                CssClass="table table-striped table-vcenter "  AlternatingRowStyle-CssClass="Alternate_grid"
                                AllowPaging="True" PageSize="10" AllowSorting="True">
                                <Columns>
                                     <asp:TemplateField HeaderText="QR-No" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="QuotationRequest_No">
                                        <ItemTemplate>
                                             <asp:HyperLink ID="hpsponsor" EnableViewState="false" NavigateUrl='<%# "ModifyQuotationrequest.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("QuotationRequest_ID").ToString()))%>'
                                                data-toggle="tooltip" title="View" runat="server">
                                            <asp:Literal ID="lblid" runat="server" Text='<%#Eval("QuotationRequest_ID")%>' Visible="false"  />                                           
                                            <asp:Literal ID="lblname" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("QuotationRequest_No"), SearchControl.UtxtSearch)%>' /> 
                                                  </asp:HyperLink  >                                        
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                        
                                    <asp:TemplateField HeaderText="Quotation Date" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="QuotationRequest_Date">
                                        <ItemTemplate>
                                            <asp:Literal ID="lbldate" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("QuotationRequest_Date"), SearchControl.UtxtSearch)%>' />                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>                                   
                                    <asp:TemplateField HeaderText="QR-Godown" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Godown_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblname1" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Godown_Name"), SearchControl.UtxtSearch)%>'  />
                                            <asp:Literal ID="ltname" runat="server" Visible="false" Text='<%#(Eval("Godown_Name"))%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="QR-Item" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Rm_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblRawMaterial" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Rm_Name"), SearchControl.UtxtSearch)%>'  />
                                            <asp:Literal ID="ltRawMaterial" runat="server" Visible="false" Text='<%#(Eval("Rm_Name"))%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="QR-Quantity" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="QRRawMaterial_Quantity">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblQuantity" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("QRRawMaterial_Quantity"), SearchControl.UtxtSearch) + " " + DynamicparcelGridview.HighlightText(Eval("QRRawMaterial_Unit"), SearchControl.UtxtSearch)%>'  />
                                            <asp:Literal ID="ltQuantity" runat="server" Visible="false" Text='<%#(Eval("QRRawMaterial_Quantity"))%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="QR-Vendor" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="QuotationRequest_Vendor_ID">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblname2" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("QuotationRequest_Vendor_ID"), SearchControl.UtxtSearch)%>' />                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="EMAIL" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewHeader">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink4" runat="server">EMAIL</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                
                                                  <asp:LinkButton ID="lnkemail" data-toggle="tooltip"  title="Send Email" class="btn btn-success" runat="server"
                                                        CommandName="emailpopup" CommandArgument='<%#Eval("QuotationRequest_ID").ToString()%>'><i class="fa fa-envelope"></i></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="View" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewHeader">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink4" runat="server">VIEW</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="hlview" EnableViewState="false" NavigateUrl='<%# "QuotationResponse.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("QuotationRequest_ID").ToString()))%>'
                                                    data-toggle="tooltip" title="View" class="btn btn-default" runat="server"><i class="fa fa-eye "></i></asp:HyperLink>

                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Create Quotation" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewHeader">                                        
                                             <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink4" runat="server">SUBMIT QUOTATION</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                          <%--  <asp:LinkButton ID="lnkresponse" CommandName="addresponse" CommandArgument='<%# Eval("QuotationRequest_ID") %>' 
                                                data-toggle="tooltip" title="Add Response" class="btn btn-alt btn-sm btn-primary" runat="server">Response</asp:LinkButton>--%>
                                              <div class="btn-group btn-group-xs">
                                             <asp:HyperLink ID="hladdresponse" EnableViewState="false" NavigateUrl='<%# "AddQuotationResponse.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("QuotationRequest_ID").ToString()))  & "&VId=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y"%>'
                                                    data-toggle="tooltip" title="Submit Quotation" class="btn btn-default" runat="server"><i class="gi gi-edit"></i></asp:HyperLink>
                                                  </div> 
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink4" runat="server">EDIT</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="hledit" EnableViewState="false" NavigateUrl='<%# "ModifyQuotationrequest.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("QuotationRequest_ID").ToString()))%>'
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
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="10px" HeaderStyle-CssClass="MasterGridviewHeader1" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Delete">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLinkdelete" runat="server">DELETE</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                    CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
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
                          <asp:LinkButton ID="btnShow" runat="server" />
                        <asp:ModalPopupExtender ID="mpe" runat="server" BehaviorID="mpe" PopupControlID="pnlPopup" TargetControlID="btnShow"
                            CancelControlID="btnNo">
                        </asp:ModalPopupExtender>
                       <%-- <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Always"  >
                            <ContentTemplate>--%>
                        <asp:Panel ID="pnlPopup" runat="server" Style="display: none" CssClass="animation-slideDown">
                                       <%--<asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>--%>
                            
                            <div  id="modal-large" class="modal-dialog" tabindex="-1" role="dialog" aria-hidden="true">
                                
                                <%--class="modal-dialog"--%>
                                <div class="modal-content">
                                
                                        <div class="modal-header">
                                            <button type="button" class="close"  ID="btnNo"  data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h3 class="modal-title" style="float:left;padding-right:300px;">Vendor Details</h3>
                                            <asp:Button ID="btnsendall" runat="server" CssClass="btn btn-xs btn-success"  Text="Send all" float="right" />
                                    </div>
                                    <div class="modal-body">
                                        <div class="table-responsive">
                                            <asp:GridView ID="grdvendoremail" ShowFooter="true" GridLines="None" CssClass="table table-striped table-vcenter" HeaderStyle-Width="100"
                                                HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Smaller" CellPadding="0" CellSpacing="0" runat="server" AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Vendor Name" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink11" runat="server">Vendor Name</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="ltvendorname" runat="server" Text='<%#Eval("Vendor_Name")%>'></asp:Label>
                                                            <asp:Label ID="ltvendorid" runat="server" Text='<%#Eval("Vendor_ID")%>' Visible="false"></asp:Label>
                                                            <asp:Label ID="ltitemid" runat="server" Text='<%#Eval("ItemDt_ID")%>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Contact Person" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink12" runat="server">Contact Person</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="ltcntactprsn" runat="server" Text='<%#Eval("Contact_ContactPerson")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="EmailId" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink13" runat="server">EmailId</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="ltemail" runat="server" Text='<%#Eval("Contact_Email")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Mobile" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink13" runat="server">Mobile</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("Contact_Mobile")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Sent Email" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink13" runat="server">Sent Email</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label  ID="lblsent" runat="server"  EnableViewState="false" Visible="false"  ><i class="fa fa-check fa-2x text-success "></i></asp:Label> 
                                                            <asp:Label  ID="lblnotsent" runat="server"    EnableViewState="false" Visible="false"  ><i class="gi gi-remove_2 fa-2x  text-danger "></i></asp:Label> 
                                                            <asp:Label ID="lblemailstatus" runat="server" Text='<%#Eval("QRVendor_Email")%>'  EnableViewState="false" Visible="false"  />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Send Email" class="btn btn-xs btn-success" runat="server"
                                                                    CommandName="sendmail" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>">Send</asp:LinkButton>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="left" BackColor="White" />
                                                <FooterStyle HorizontalAlign="left" BackColor="White" />
                                                <PagerSettings PageButtonCount="4" />
                                                <EmptyDataTemplate>
                                                    <asp:Label ID="s" runat="server" Text="No Item Found"></asp:Label><br />
                                                    <br />
                                                </EmptyDataTemplate>
                                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </div>

                                    </div>                                  
                                </div>
                            </div>
                        </asp:Panel>
                          <%--  </ContentTemplate>
                            </asp:UpdatePanel> --%>
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


