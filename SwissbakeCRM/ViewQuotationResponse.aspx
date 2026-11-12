<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ViewQuotationResponse.aspx.vb" Inherits="ViewQuotationResponse" %>



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
    <script src="js/vendor/modernizr-respond.min.js"></script>
    <script src="js/plugins.js"></script>

    <script src="js/jquery.min.js"></script>

    <script src="js/app.js"></script>

    <script src="js/pages/tablesDatatables.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="deletestatus" runat="server" />
    <div class="row">
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <i class="gi gi-table" style="margin: -8px"></i>Quotation Response Detail<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="QuotationResponse.aspx">Quotation Response</a></li>
                <li>Quotation Response Detail</li>
            </ul>
            <%--<div class="col-md-12">--%>
            <!-- Advanced Active Theme Color Widget Alternative -->
            <div class="widget" style="min-height: 331px">
                <div class="widget-advanced widget-advanced-alt">
                    <!-- Widget Header -->
                    <div class="widget-header text-center themed-background-dark">
                        <h4 class="widget-content-light">
                            <a>
                                <asp:Literal ID="ltVendorCode" runat="server"></asp:Literal>
                            </a>
                            <asp:Literal ID="ltamount" runat="server"></asp:Literal><asp:HiddenField ID="hfcontacttype" runat="server" />
                            <asp:HiddenField ID="hfcontacttypeid" runat="server" />
                            <br>
                            <small>
                                <asp:Literal ID="ltVendorName" runat="server"></asp:Literal>
                                <a>
                                    <asp:Literal ID="ltaccname" runat="server"></asp:Literal></a></small>
                        </h4>
                        <div class="col-md-12">
                            <div class="block-section" id="divEdit" runat="server">
                                <%--    <a id="aedit" runat="server" class="btn btn-alt btn-sm btn-primary">Edit</a>--%>

                                <a id="hlEditResponse" class="btn btn-alt btn-sm btn-primary" href='<%= "AddQuotationResponse.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainId.ToString()))  & "&VId=" + HttpUtility.UrlEncode(Security.Encrypt(VendorID.ToString())) + "&returnurl=y"%>'>Edit</a>
                                <asp:LinkButton ID="lkdelete" runat="server" class="btn btn-alt btn-sm btn-danger" OnClientClick="checkdelete();" Visible="false">Delete</asp:LinkButton>
                                <%--  <asp:LinkButton ID="lkconvacount" runat="server" class="btn btn-alt btn-sm btn-info">Convert To Account</asp:LinkButton>--%>
                                <%-- <asp:LinkButton ID="lkconvOpportunity" runat="server" class="btn btn-alt btn-sm btn-warning">Convert To Opportunity</asp:LinkButton>--%>
                            </div>

                        </div>
                    </div>
                    <!-- END Widget Header -->

                    <!-- Widget Main -->
                    <div class="widget-main">
                        <div class="list-group remove-margin">
                            <%-- <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                         <asp:Repeater ID="rpowner" runat="server">
                                            <ItemTemplate>
                                               <%#Eval("U_FirstName")%>
                                            </ItemTemplate>
                                            <SeparatorTemplate>
                                              ,
                                            </SeparatorTemplate>
                                        </asp:Repeater></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-tag fa-fw"></i>&nbsp;Opportunity Assign to</h5>
                                </a>--%>
                            <a href="javascript:void(0)" class="list-group-item">
                                <span class="pull-right"><strong>
                                    <asp:Literal ID="ltStatus" runat="server"></asp:Literal></strong></span>
                                <h5 class="list-group-item-heading remove-margin"><i class="fa fa-mobile fa-fw"></i>&nbsp;Status</h5>
                                <p class="list-group-item-text"></p>
                            </a>
                            <a href="javascript:void(0)" class="list-group-item">
                                <span class="pull-right"><strong>
                                    <asp:Literal ID="ltDate" runat="server"></asp:Literal></strong></span>
                                <h5 class="list-group-item-heading remove-margin"><i class="fa fa-phone fa-fw"></i>&nbsp;Quotation Created Date</h5>
                                <p class="list-group-item-text"></p>
                            </a>
                            <a href="javascript:void(0)" class="list-group-item">
                                <span class="pull-right"><strong>
                                    <asp:Literal ID="ltQReqNo" runat="server"></asp:Literal></strong></span>
                                <h5 class="list-group-item-heading remove-margin"><i class="fa fa-calendar fa-fw"></i>&nbsp;Quotation Request No</h5>
                                <p class="list-group-item-text"></p>
                            </a>
                            <%--   <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltdate" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-calendar fa-fw"></i>&nbsp;Closing Date</h5>
                                    <p class="list-group-item-text"></p>
                                </a>--%>
                        </div>
                    </div>
                    <!-- END Widget Main -->
                </div>
            </div>
            <!-- END Advanced Active Theme Color Widget Alternative -->
            <%--</div>--%>

            <%--    <div id="faq18812" class="panel-group">--%>
            <%--<div class="panel panel-default">--%>
            <%--<div class="col-md-12">--%>
            <%-- <div class="block-title ">--%>
            <%--<div class="col-md-12">--%>



            <div class="full block">
                <div class="block-title ">
                    <h2>Requested Raw Material</h2>

                </div>

                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="table-responsive">


                            <asp:GridView ID="GrdQReqRaw" ShowFooter="true" GridLines="None" CssClass="table table-striped table-vcenter"
                                HeaderStyle-Width="100" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Smaller" CellPadding="0" CellSpacing="0"
                                runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="RowNumber" Visible="false" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div class="col-md-6" runat="server" visible="false">
                                                <asp:Label runat="server" ID="RowNumber" Text='<%#Eval("RowNumber")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="raw Material" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                            <div class="input-group  col-md-12">
                                                <span class="input-group-addon"><i class="gi gi-tags"></i></span>
                                                <asp:DropDownList ID="ddrawmaterial" runat="server" CssClass="select-chosen"></asp:DropDownList>
                                                <asp:Literal ID="ltattid" runat="server" Text='<%#Eval("QRRawMaterial_RawID")%>' Visible="false"></asp:Literal>
                                                <asp:Literal ID="ltqrid" runat="server" Text='<%#Eval("QRRawMaterial_QRDID")%>' Visible="false"></asp:Literal>
                                                <asp:RequiredFieldValidator ID="rfvddmaterial" runat="server" ControlToValidate="ddrawmaterial" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                    ErrorMessage="Select raw material" InitialValue="Select Raw Material" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            </div>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                        <ItemTemplate>
                                            <%--<asp:Label ID="lblcontact" runat="server" Text='<%#Eval("Principle_ContactPerson")%>'></asp:Label>--%>
                                            <asp:Label ID="txtquantity" runat="server" Text='<%#Eval("QRRawMaterial_Quantity")%>' data-toggle="tooltip" CssClass="form-control"></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Unit" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                        <ItemTemplate>
                                            <asp:Label ID="lblunite" runat="server" Text='<%#Eval("QRRawMaterial_Unit")%>' Visible="false"></asp:Label>
                                            <asp:DropDownList ID="ddunuit" runat="server" CssClass="select-chosen">
                                                <%--<asp:ListItem Value="0" Text="Select Material"></asp:ListItem>--%>
                                                <asp:ListItem Value="KG" Text="KG"></asp:ListItem>
                                                <%--<asp:ListItem Value="Numbers" Text="Numbers"></asp:ListItem>--%>
                                                <asp:ListItem Value="Nos." Text="Nos."></asp:ListItem>
                                                <asp:ListItem Value="Each" Text="Each"></asp:ListItem>
                                                <asp:ListItem Value="SqMt" Text="SqMt"></asp:ListItem>
                                                <asp:ListItem Value="RnMt" Text="RnMt"></asp:ListItem>
                                                <asp:ListItem Value="Ltr" Text="Ltr"></asp:ListItem>
                                                <asp:ListItem Value="Unit" Text="Unit"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvddunit" runat="server" ControlToValidate="ddunuit" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Select unit" InitialValue="0" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="full block">
                <div class="block-title ">
                    <h2>Raw Material by Vendor</h2>
                </div>


                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="table-responsive">

                            <asp:GridView ID="GrdQRRaw" ShowFooter="true" GridLines="None" CssClass="table table-striped table-vcenter"
                                HeaderStyle-Width="100" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Smaller" CellPadding="0" CellSpacing="0"
                                runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="RowNumber" Visible="false" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div class="col-md-6" runat="server" visible="false">
                                                <asp:Label runat="server" ID="RowNumber" Text='<%#Eval("RowNumber")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="raw Material" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                            <div class="input-group  col-md-12">
                                                <span class="input-group-addon"><i class="gi gi-tags"></i></span>
                                                <asp:DropDownList ID="ddrawmaterial" runat="server" CssClass="select-chosen"></asp:DropDownList>
                                                <asp:Literal ID="ltattid" runat="server" Text='<%#Eval("QRRawMaterial_RawID")%>' Visible="false"></asp:Literal>
                                                <asp:Literal ID="ltqrid" runat="server" Text='<%#Eval("QRRawMaterial_QRDID")%>' Visible="false"></asp:Literal>
                                                <asp:RequiredFieldValidator ID="rfvddmaterial" runat="server" ControlToValidate="ddrawmaterial" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                    ErrorMessage="Select raw material" InitialValue="Select Raw Material" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            </div>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                        <ItemTemplate>
                                            <%--<asp:Label ID="lblcontact" runat="server" Text='<%#Eval("Principle_ContactPerson")%>'></asp:Label>--%>
                                            <asp:Label ID="txtquantity" runat="server" Text='<%#Eval("QRRawMaterial_Quantity")%>' data-toggle="tooltip" CssClass="form-control"></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Unit" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                        <ItemTemplate>
                                            <asp:Label ID="lblunite" runat="server" Text='<%#Eval("QRRawMaterial_Unit")%>' Visible="false"></asp:Label>
                                            <asp:DropDownList ID="ddunuit" runat="server" CssClass="select-chosen">
                                                <%--<asp:ListItem Value="0" Text="Select Material"></asp:ListItem>--%>
                                                <asp:ListItem Value="KG" Text="KG"></asp:ListItem>
                                                <%--<asp:ListItem Value="Numbers" Text="Numbers"></asp:ListItem>--%>
                                                <asp:ListItem Value="Nos." Text="Nos."></asp:ListItem>
                                                <asp:ListItem Value="Each" Text="Each"></asp:ListItem>
                                                <asp:ListItem Value="SqMt" Text="SqMt"></asp:ListItem>
                                                <asp:ListItem Value="RnMt" Text="RnMt"></asp:ListItem>
                                                <asp:ListItem Value="Ltr" Text="Ltr"></asp:ListItem>
                                                <asp:ListItem Value="Unit" Text="Unit"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvddunit" runat="server" ControlToValidate="ddunuit" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Select unit" InitialValue="0" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <div id="faq18813" class="panel-group">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq18813" href="#faq18813_q1881">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Label ID="lblprinciple" runat="server" Text="raw"></asp:Label>
                                </ContentTemplate>

                            </asp:UpdatePanel>
                        </a></h4>
                    </div>
                    <div id="faq18813_q1881" class="panel-collapse collapse" style="height: 0px; max-height: 303px; overflow: auto;">
                        <div class="panel-body">

                            <asp:LinkButton ID="LinkButton1" Text="" runat="server" />
                            <asp:LinkButton ID="LinkButton2" Text="Add Item" runat="server" class="btn btn-alt btn-xs btn-primary" Visible="false" />
                            <br />
                            <br />
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="table-responsive">
                                        <asp:GridView ID="grdhistory" ShowFooter="true" GridLines="None" CssClass="table table-striped table-vcenter"
                                            HeaderStyle-Width="100" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Smaller" CellPadding="0" CellSpacing="0"
                                            runat="server" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Vendor Name" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                    <HeaderTemplate>
                                                        <asp:HyperLink ID="HyperLink11" runat="server">Date</asp:HyperLink>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Literal ID="ltproductname1" runat="server" Text='<%#Eval("QDate")%>'></asp:Literal>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mobile" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                    <HeaderTemplate>
                                                        <asp:HyperLink ID="HyperLink12" runat="server">Amount</asp:HyperLink>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <i class="fa fa-inr "></i>&nbsp;
                                                            <asp:Literal ID="ltproductcode" runat="server" Text='<%#Convert.ToDouble(Eval("QREHistory_Amt")).ToString("#,##0.00")%>'></asp:Literal>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="EmailId" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                    <HeaderTemplate>
                                                        <asp:HyperLink ID="HyperLink13" runat="server">Tax</asp:HyperLink>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <i class="fa fa-inr "></i>&nbsp;
                                                            <asp:Literal ID="ltpackingpacking" runat="server" Text='<%#Convert .ToDouble (Eval("QREHistory_Tax")).ToString("#,##0.00")%>'></asp:Literal>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Phone" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                    <HeaderTemplate>
                                                        <asp:HyperLink ID="HyperLink13" runat="server">Freight</asp:HyperLink>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <i class="fa fa-inr "></i>&nbsp;
                                                            <asp:Literal ID="ltpackingpacking" runat="server" Text='<%#Convert .ToDouble (Eval("QREHistory_Freight")).ToString("#,##0.00")%>'></asp:Literal>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Phone" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                    <HeaderTemplate>
                                                        <asp:HyperLink ID="HyperLink13" runat="server">Payment Terms</asp:HyperLink>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Literal ID="ltpackingpacking" runat="server" Text='<%#Eval("QREHistory_PaymentTerms")%>'></asp:Literal>
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
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <User:EmailControl ID="emailcontrol" runat="server" Visible="false" />
            <div id="faq6" class="panel-group">
                <User:NoteControl ID="notecontrol1" runat="server" Visible="false" />
            </div>
            <div id="faq1" class="panel-group">
                <User:NewDocumentControl ID="NewDocumentControl1" runat="server" Visible="false" />
            </div>
        </div>
</asp:Content>



