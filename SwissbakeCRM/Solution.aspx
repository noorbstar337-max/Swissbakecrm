<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="Solution.aspx.vb" Inherits="Solution" %>

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
                        <i class="fa fa-sitemap" style="margin: -8px"></i>Solution<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="AdminMenu.aspx">Admin</a></li>
                <li>Solution</li>
            </ul>
            <div class="block">
                <div class="block-title">
                    <h2><strong>Solution</strong> Detail</h2>
                </div>
                <%--Search --%>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="faq1" class="panel-group">

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title"><i class="fa fa-angle-right"></i><a class="accordion-toggle" data-toggle="collapse" data-parent="#faq1" href="#faq1_q2">Solution Search</a></h4>
                                </div>
                                <div id="faq1_q2" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="widget-extra-full">
                                                <div class="form-horizontal form-bordered">
                                                    <div class="col-md-12">
                                                        <br />
                                                    </div>

                                                    <div class="col-md-12">
                                                        <div class="col-md-4">
                                                            <label class="col-md-4 control-label" for="example-hf-email">Complaint No.<span class="text-danger"> </span></label>
                                                            <div class="col-md-8">
                                                                <asp:TextBox ID="txtcomplaintcode" runat="server" placeholder="Enter Complaint No." data-toggle="tooltip" title="Enter Complaint No."
                                                                    CssClass="form-control"></asp:TextBox><br />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label class="col-md-4 control-label" for="example-hf-password">Product</label>
                                                            <div class="col-md-8">
                                                                <asp:TextBox ID="txtproduct" runat="server" placeholder="Enter Product" data-toggle="tooltip" title="Enter Product"
                                                                    CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                            <br />
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label class="col-md-4 control-label" for="example-hf-password">Account</label>
                                                            <div class="col-md-8">
                                                                <asp:TextBox ID="txtaccount" runat="server" placeholder="Enter Account" data-toggle="tooltip" title="Enter Account"
                                                                    CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                        <br />
                                                        </div>
                                                    </div>
                                                  
                                                    <div class="col-md-12">
                                                        <div class="col-md-4">
                                                            <label class="col-md-4 control-label" for="example-hf-password">Lot/Batch No.</label>
                                                            <div class="col-md-8">
                                                                <asp:TextBox ID="txtbatch" runat="server" placeholder="Enter Lot No./Batch No." data-toggle="tooltip" title="Enter Lot No./Batch No."
                                                                    CssClass="form-control"></asp:TextBox>
                                                           <br /> </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label class="col-md-4 control-label" for="example-hf-password">Invoice No.</label>
                                                            <div class="col-md-8">
                                                                <asp:TextBox ID="txtinvoice" runat="server" placeholder="Enter Invoice No." data-toggle="tooltip" title="Enter Invoice No."
                                                                    CssClass="form-control"></asp:TextBox>
                                                           <br /> </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label class="col-md-4 control-label" for="example-hf-password">Title<span class="text-danger"> </span></label>
                                                            <div class="col-md-8">
                                                                <asp:TextBox ID="txttitle" runat="server" placeholder="Enter Title Of Complaint" data-toggle="tooltip" title="Enter Title Of Complaint"
                                                                    CssClass="form-control"></asp:TextBox>
                                                                <br />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div style="clear: both"></div>
                                                    <div class="col-md-12">
                                                        <div class="col-md-4">
                                                            <label class="col-md-4 control-label" for="example-hf-password">Description</label>
                                                            <div class="col-md-8">
                                                                <asp:TextBox ID="txtdiscription" runat="server" placeholder="Enter Description" data-toggle="tooltip" title="Enter Description"
                                                                    CssClass="form-control"></asp:TextBox>
                                                          <br />  </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label class="col-md-4 control-label" for="example-hf-password">External <span class="text-danger"></span></label>
                                                            <div class="col-md-8">
                                                                <asp:TextBox ID="txtexterneal" runat="server" placeholder="Enter External" data-toggle="tooltip" title="Enter External"
                                                                    CssClass="form-control"></asp:TextBox>
                                                           <br /> </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label class="col-md-4 control-label" for="example-hf-password">Internal <span class="text-danger"></span></label>
                                                            <div class="col-md-8">
                                                                <asp:TextBox ID="txtinternal" runat="server" placeholder="Enter Internal" data-toggle="tooltip" title="Enter Internal"
                                                                    CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                      <br />  </div>
                                                    </div>
                                                    <div style="clear: both"></div>
                                                    <div class="col-md-12">
                                                        <div class="col-md-4">
                                                            <label class="col-md-4 control-label" for="example-hf-email">Action Taken<span class="text-danger"> </span></label>
                                                            <div class="col-md-8">
                                                                <asp:TextBox ID="txtaction" runat="server" placeholder="Enter Action Taken" data-toggle="tooltip" title="Enter Action Taken"
                                                                    CssClass="form-control"></asp:TextBox>
                                                           <br /> </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label class="col-md-4 control-label" for="example-hf-password">Preventive</label>
                                                            <div class="col-md-8">
                                                                <asp:TextBox ID="txtprevent" runat="server" placeholder="Enter Preventive Measure" data-toggle="tooltip" title="Enter Preventive Measure"
                                                                    CssClass="form-control"></asp:TextBox>
                                                            </div>
<br />
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label class="col-md-4 control-label" for="example-hf-password">Client Feedback</label>
                                                            <div class="col-md-8">
                                                                <asp:TextBox ID="txtfeedback" runat="server" placeholder="Enter Client Feedback" data-toggle="tooltip" title="Enter Client Feedback"
                                                                    CssClass="form-control"></asp:TextBox>
                                                           <br /> </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div style="clear: both"></div>
                                                </div>
                                            </div>
                                            <div class="col-md-9">
                                            </div>
                                            <div style="clear: both"></div>
                                            <div class="col-md-4" style="margin-top: 5px">
                                            </div>
                                            <div class="col-md-8">
                                                <div class="pull-right">
                                                    <asp:LinkButton Text="Search" runat="server" Style="margin-right: 15px;" ID="btnshowall" class="btn btn-alt btn-sm btn-primary"><i class="gi gi-refresh"></i>  Search</asp:LinkButton>
                                                    <asp:LinkButton Text="Show All" runat="server" Style="margin-right: 15px;" ID="btnclear" class="btn btn-alt btn-sm btn-primary"><i class="gi gi-refresh"></i>  Show All</asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12">
                                            <br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <%--Search --%>


                <%--Search User Control Start--%>
                <User:SearchBar ID="SearchControl" runat="server" />
                <%--Search User Control End--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="hfcheck" runat="server" />
                        <asp:HiddenField ID="hfchanged" runat="server" />
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CustComplaint_ID" AllowCustomPaging="true"
                                CssClass="table table-striped table-vcenter table-hover" OnSorting="GridView1_Sorting"
                                AllowPaging="True" PageSize="10" AllowSorting="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="CustComplaint_ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblProductId" runat="server" Text='<%#(Eval("CustComplaint_ID"))%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Complaint no." ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="CustComplaint_No">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblcode" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("CustComplaint_No"), txtcomplaintcode)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Invoice No." ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="CustComplaint_InvoiceNo">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblname" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("CustComplaint_InvoiceNo"), txtinvoice)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Product_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblCategory" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Product_Name"), txtproduct)%>' EnableViewState="false" />
                                            <asp:Literal ID="Literal1" runat="server" Text='<%#(Eval("Product_ID"))%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Title" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="CustComplaint_Title">
                                        <ItemTemplate>
                                            <asp:Literal ID="lbltitle" runat="server" Text='<%#DynamicparcelDisplayFunctions.TruncateDescription(DynamicparcelGridview.HighlightText(Eval("CustComplaint_Title"), txttitle), 30)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="CustComplaint_Title" Visible="false">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblCategory" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("CustComplaint_Title"), txttitle)%>' EnableViewState="false" />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Account" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Acc_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblRate" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Acc_Name"), txtaccount)%>' EnableViewState="false" />
                                            <asp:Literal ID="Literal1" runat="server" Text='<%#(Eval("Acc_ID"))%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="CustComplaint_Status" Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk" CssClass='<%#Security.checkStatus(Eval("CustComplaint_Status"))%>' runat="server" Text='<%#Eval("CustComplaint_Status")%>'
                                                CommandName="statuslink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="View" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="HyperLink1" EnableViewState="false" NavigateUrl='<%# "ViewCustomerComplaint.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("CustComplaint_ID").ToString()))%>'
                                                    data-toggle="tooltip" title="View" class="btn btn-default" runat="server"><i class="fa fa-eye"></i></asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" Visible="false">
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="hledit" EnableViewState="false" NavigateUrl='<%# "ModifyCustomerComplaint.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("CustComplaint_ID").ToString()))%>'
                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" Visible="false">
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                    CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="Right" BackColor="White" />

                                <FooterStyle HorizontalAlign="Center" BackColor="White" />
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
                        <asp:AsyncPostBackTrigger ControlID="btnshowall" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" />
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

