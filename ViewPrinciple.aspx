<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ViewPrinciple.aspx.vb" Inherits="ViewPrinciple" %>

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
    <div class="row">
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <i class="gi gi-table" style="margin: -8px"></i>Principle Detail<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="Vendor.aspx">Principle</a></li>
                <li>Principle Detail</li>
            </ul>
            <div class="col-md-12">
                <!-- Advanced Active Theme Color Widget Alternative -->
                <%--<div class="widget" style="min-height: 352px">--%>
                <div class="widget">
                    <div class="widget-advanced widget-advanced-alt">
                        <!-- Widget Header -->
                        <div class="widget-header text-center themed-background-dark" style="min-height: 90px;">
                            <h4 class="widget-content-light">
                                <a>
                                    <asp:Literal ID="ltcontactname" runat="server"></asp:Literal></a><br>
                                <small>
                                    <asp:Literal ID="ltcompanyname" runat="server"></asp:Literal></small>
                            </h4>
                         </div>
                        <!-- END Widget Header -->

                        <!-- Widget Main -->
                        <div class="widget-main">
                            <div class="list-group remove-margin">

                                <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltmobile" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-mobile fa-fw"></i>&nbsp;Mobile</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                                <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltphone" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-phone fa-fw"></i>&nbsp;Phone</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                                <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltemail" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-envelope-o fa-fw"></i>&nbsp;EmailID</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                                <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="lbladdress" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-home fa-fw"></i>&nbsp;Address</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div id="faq1881" class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq1881" href="#faq1881_q1881">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="lblprinciple" runat="server" Text="raw"></asp:Label>
                                    </ContentTemplate>
                                    <%--  <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                                        <asp:AsyncPostBackTrigger ControlID="gridviewcontact" />
                                    </Triggers>--%>
                                </asp:UpdatePanel>
                            </a></h4>
                        </div>
                        <div id="faq1881_q1881" class="panel-collapse collapse" style="height: 0px; max-height: 303px; overflow: auto;">
                            <div class="panel-body">
                                <asp:LinkButton ID="LinkButton1" Text="" runat="server" />
                                <asp:LinkButton ID="LinkButton2" Text="Add Item" runat="server" class="btn btn-alt btn-xs btn-primary" Visible="false" />
                                <br />
                                <br />
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="table-responsive">
                                            <asp:GridView ID="gridview2" ShowFooter="true" GridLines="None" CssClass="table table-striped table-vcenter"
                                                HeaderStyle-Width="100" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Smaller" CellPadding="0" CellSpacing="0"
                                                runat="server" AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Vendor Name" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink11" runat="server">Vendor Name</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Literal ID="ltproductname1" runat="server" Text='<%#Eval("Vendor_Name")%>'></asp:Literal>
                                                            <asp:Literal ID="ltitemid" runat="server" Text='<%#Eval("Vendor_ID")%>' Visible="false"></asp:Literal>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Mobile" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink12" runat="server">Mobile</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Literal ID="ltproductcode" runat="server" Text='<%#Eval("Contact_Mobile")%>'></asp:Literal>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="EmailId" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink13" runat="server">EmailId</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Literal ID="ltpackingpacking" runat="server" Text='<%#Eval("Contact_Email")%>'></asp:Literal>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Phone" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink13" runat="server">Phone</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Literal ID="ltpackingpacking" runat="server" Text='<%#Eval("Contact_Landline")%>'></asp:Literal>
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
                    <User:NoteControl ID="notecontrol" runat="server" Visible="false" />
                </div>
                <div id="faq1" class="panel-group">
                    <User:NewDocumentControl ID="documentcontrol" runat="server" Visible="false" />
                </div>
            </div>
            <User:ActivityControl ID="activitycontrol" runat="server" Visible="false" />
        </div>
    </div>
</asp:Content>

