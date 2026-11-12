<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" CodeFile="ViewVendor.aspx.vb" Inherits="ViewVendor" %>

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
                        <i class="gi gi-table" style="margin: -8px"></i>Vendor Detail<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="Vendor.aspx">Vendor</a></li>
                <li>Vendor Detail</li>
            </ul>
            <div class="col-md-12">
                <!-- Advanced Active Theme Color Widget Alternative -->
                <%--<div class="widget" style="min-height: 352px">--%>
                <div class="widget" >
                    <div class="widget-advanced widget-advanced-alt">
                        <!-- Widget Header -->
                        <div class="widget-header text-center themed-background-dark" style="min-height: 90px;">
                            <h4 class="widget-content-light">
                                <a>
                                    <asp:Literal ID="ltcontactname" runat="server"></asp:Literal></a><br>
                                <small>
                                    <asp:Literal ID="ltcompanyname" runat="server"></asp:Literal></small>
                            </h4>
                            <div class="col-md-12 remove-padding">
                                <%--<div class="block-section">--%>
                                <a id="aedit" runat="server" class="btn btn-alt btn-sm btn-primary">Edit</a>
                                <asp:LinkButton ID="lkdelete" runat="server" class="btn btn-alt btn-sm btn-danger" OnClientClick="checkdelete();" Visible="false">Delete</asp:LinkButton>
                                <%-- <asp:LinkButton ID="lkconvacount" runat="server" class="btn btn-alt btn-sm btn-info">Convert To Vendor</asp:LinkButton>--%>
                                <%-- <asp:LinkButton ID="lkconvprospect" runat="server" class="btn btn-alt btn-sm btn-warning">Convert To Prospect</asp:LinkButton>--%>
                                <%--</div>--%>
                            </div>
                        </div>
                        <!-- END Widget Header -->

                        <!-- Widget Main -->
                        <div class="widget-main">
                            <div class="list-group remove-margin">
                                <%--<a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Repeater ID="rpowner" runat="server">
                                            <ItemTemplate>
                                               <%#Eval("U_FirstName")%>
                                            </ItemTemplate>
                                            <SeparatorTemplate>
                                              ,
                                            </SeparatorTemplate>
                                        </asp:Repeater>
                                        </strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-tag fa-fw"></i>&nbsp;Vendor assign to</h5>
                                </a>--%>
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
                                <%--<div >
                                <a href="javascript:void(0)" class="list-group-item col-md-4" >
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="lblcst" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin">&nbsp;CST</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                                    <a href="javascript:void(0)" class="list-group-item col-md-4" >
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="lblpan" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin">&nbsp;PAN</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                                    <a href="javascript:void(0)" class="list-group-item col-md-4" >
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="lblvat" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin">&nbsp;VAT</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                                </div>--%>
                            </div>
                        </div>
                        <!-- END Widget Main -->
                    </div>
                </div>
                <!-- END Advanced Active Theme Color Widget Alternative -->
            </div>
            
            <div class="col-md-12">
                <%--<div class="row">
            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a  class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-fire animation-fadeIn">
                            <i class="fa fa-cubes"></i>
                        </div>
                        <h3 class="widget-content text-right animation-pullDown"><i class="fa fa-rupee"></i>&nbsp;<strong><asp:Literal ID="lblorderamount" runat="server"></asp:Literal> </strong><br>
                            <small>Total <asp:Literal ID="lblordercount" runat="server"></asp:Literal> order</small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
            </div>
            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a  class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-autumn animation-fadeIn">
                            <i class="fa fa-file-o"></i>
                        </div>
                        <h3 class="widget-content text-right animation-pullDown"><i class="fa fa-rupee"></i>&nbsp;<strong>
                            <asp:Literal ID="lblinvtotal" runat="server"></asp:Literal>
                             </strong>
                            <br>
                            <small>Total <asp:Literal ID="lblinvoicecount" runat="server"></asp:Literal> invoice generated</small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
            </div>
            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a  class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-spring animation-fadeIn">
                            <i class="fa fa-rupee"></i>
                        </div>
                        <h4 class="widget-content text-right animation-pullDown"><i class="fa fa-rupee"></i>&nbsp;<strong>
                            <asp:Literal ID="lblpaytotal" runat="server"></asp:Literal>
                             </strong>
                            <small>Total <asp:Literal ID="lblpaycount" runat="server"></asp:Literal> payment </small>
                        </h4>
                    </div>
                </a>
                <!-- END Widget -->
            </div>
            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a  class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-amethyst animation-fadeIn">
                            <i class="gi gi-money"></i>
                        </div>
                        <h3 class="widget-content text-right animation-pullDown"><i class="fa fa-rupee"></i>&nbsp;
                            <strong>
                                <asp:Literal ID="lblbalpay" runat="server"></asp:Literal>
                                 </strong>
                            <small>Total balance</small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
            </div>
                     </div>--%>
            <%--    <User:ContactControl ID="contactcontrol" runat="server" />--%>

                <!-- Product -->
                <div id="faq188" class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq188" href="#faq188_q188">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="lblitemdt" runat="server" Text="raw"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                                        <asp:AsyncPostBackTrigger ControlID="gridviewcontact" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </a></h4>
                        </div>
                        <div id="faq188_q188" class="panel-collapse collapse" style="height: 0px; max-height: 303px; overflow: auto;">
                            <div class="panel-body">
                                <asp:LinkButton ID="btnShow" Text="" runat="server" />
                                <asp:LinkButton ID="btnopen" Text="Add Item" runat="server" class="btn btn-alt btn-xs btn-primary" Visible="false"  />
                                <br />
                                <br />
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="table-responsive">
                                            <asp:GridView ID="gridviewcontact" ShowFooter="true" GridLines="None" CssClass="table table-striped table-vcenter" 
                                                HeaderStyle-Width="100" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Smaller" CellPadding="0" CellSpacing="0" 
                                                runat="server" AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Contact Person" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink11" runat="server">Contact Person</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Literal ID="ltproductname" runat="server" Text='<%#Eval("Contact_ContactPerson")%>'></asp:Literal>
                                                            <asp:Literal ID="ltitemid" runat="server" Text='<%#Eval("Contact_Id")%>' Visible="false"></asp:Literal>
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
                                                    <%--<asp:TemplateField HeaderText="Rate" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                          <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink15" runat="server">Rate/kg</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                           <i class="fa fa-rupee"></i>&nbsp; <asp:Literal ID="ltrate" runat="server" Text='<%#Eval("ItemDt_Rate")%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                                   <%-- <asp:TemplateField HeaderText="VP_RefName" ItemStyle-Width="100px" HeaderStyle-CssClass="" ItemStyle-CssClass="" Visible="false" >
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink14" runat="server">Reference Name</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div class="col-md-12">
                                                                <asp:TextBox ID="txtquantity" runat="server" Visible="false" Text='<%#Eval("VP_RefName")%>' Height="25" Width="400" data-toggle="tooltip" title="Enter Qunatity"
                                                                    CssClass="form-control"></asp:TextBox>
                                                                <asp:Literal ID="ltquantity" runat="server" Text='<%#Eval("VP_RefName")%>'></asp:Literal>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <%--<asp:TemplateField HeaderText="KG" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                          <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink17" runat="server">KG</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Literal ID="ltkg" Text='<%#Eval("Packing_Weight")%>' runat="server"></asp:Literal> kg
                                            <%-- <asp:Literal ID="lblvat" runat="server" Text='<%#Eval("Product_Vat")%>' Visible="false" />--%
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vat" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                          <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink17" runat="server">Vat</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            
                                            
                                            <i class="fa fa-rupee"></i>&nbsp; <asp:Literal ID="lblvatinrs" runat="server" Text='<%#Eval("Product_Vat")%>' />(<asp:Literal ID="lblvat" runat="server" Text='<%#Eval("Product_Vat")%>' />%)
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            Total Vat:<br /><hr style="border:0;border-top: 1px solid #eee;margin-top:4px;margin-bottom:4px;"" />
                                            Total Amount:
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                            <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink18" runat="server">Amount</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <i class="fa fa-rupee"></i>&nbsp;<asp:Literal ID="ltamount" Text='<%#Eval("ItemDt_Amount")%>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <FooterTemplate>
<%--Total Amount:<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%<b><i class="fa fa-rupee"></i>&nbsp;<asp:Literal ID="lttotalvat" Text='78500' runat="server"></asp:Literal></b><br /><hr style="border:0;border-top: 1px solid #eee;margin-top:4px;margin-bottom:4px;" /><b><i class="fa fa-rupee"></i>&nbsp; <asp:Literal ID="lttotalamount" Text='78500' runat="server"></asp:Literal></b></FooterTemplate>
                                    </asp:TemplateField>--%>
                                                   <%-- <asp:TemplateField ItemStyle-Width="" HeaderStyle-CssClass="" ItemStyle-CssClass="" Visible="false" >
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:LinkButton ID="lkupdate" data-toggle="tooltip" title="Update" Visible="false" runat="server" class="btn btn-primary"
                                                                    CommandName="updatelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>">Update</asp:LinkButton>
                                                                <asp:LinkButton ID="lnkedit" data-toggle="tooltip" title="Edit" runat="server" class="btn btn-primary"
                                                                    CommandName="Editlink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>">Edit</asp:LinkButton>

                                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger" runat="server" OnClientClick="checkdelete();"
                                                                    CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>">Delete</asp:LinkButton>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
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
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="GridView1" />
                                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                                        <asp:AsyncPostBackTrigger ControlID="gridviewcontact" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="btnShow"
                                    CancelControlID="btnNo">
                                </asp:ModalPopupExtender>
                                <asp:Panel ID="pnlPopup" runat="server" Style="display: none">
                                    <div class="modal-dialog modal-lg" style="overflow-y: scroll; position: fixed; top: 0; bottom: 0; left: 0; right: 0; overflow: auto;">
                                        <div class="modal-content" style="top: 1%; overflow-x: hidden; overflow-y: auto; outline: none; margin-top: 0; top: 50%; overflow: visible;">
                                            <div class="modal-header">
                                                <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                                                <h3 class="modal-title">Add Product</h3>
                                            </div>
                                            <div class="modal-body" style="overflow: auto">
                                                <div class="table-options clearfix">
                                                    <div class="col-sm-5 col-xs-4">
                                                        <div class="dataTables_length" id="example-datatable_length">
                                                            <%--  <asp:DropDownList ID="ddpagesize" AutoPostBack="true" runat="server" CssClass="form-control">
                                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                            </asp:DropDownList>--%>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-4 col-xs-12">
                                                        <div id="example-datatable_filter" class="dataTables_filter">
                                                            <label>
                                                                <div class="input-group">
                                                                    <asp:TextBox ID="txtsearch" runat="server" class="form-control" placeholder="Search" /><span class="input-group-addon">
                                                                        <i class="fa fa-search"></i></span>
                                                                </div>
                                                            </label>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-3 col-xs-12">
                                                        <asp:Button ID="btnshowall" EnableViewState="false" runat="server" Text="Show All" CssClass="btn btn-alt btn-sm btn-info" />
                                                    </div>
                                                </div>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Rm_ID"
                                                                CssClass="table table-striped table-vcenter table-hover">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Select" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Rm_ID">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="ckselect" runat="server" />
                                                                            <asp:Literal ID="lblProductId" runat="server" Text='<%#Eval("Rm_ID")%>' Visible="false" />

                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Product Name" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                                        <HeaderTemplate>
                                                                            <asp:HyperLink ID="HyperLink11" runat="server">Raw Material Name</asp:HyperLink>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Literal ID="ltproductname" runat="server" Text='<%#Eval("Rm_Name")%>'></asp:Literal>
                                                                            <asp:Literal ID="ltitemid" runat="server" Text='<%#Eval("Rm_ID")%>' Visible="false"></asp:Literal>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Description" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                                        <HeaderTemplate>
                                                                            <asp:HyperLink ID="HyperLink12" runat="server">Description</asp:HyperLink>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Literal ID="ltproductcode" runat="server" Text='<%#Eval("Rm_Desc")%>'></asp:Literal>
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
                                                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                                                        <asp:AsyncPostBackTrigger ControlID="btnopen" />
                                                        <asp:AsyncPostBackTrigger ControlID="btnshowall" />
                                                    </Triggers>
                                                </asp:UpdatePanel>

                                            </div>
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="modal-footer">
                                                        <asp:Button ID="btnsave" runat="server" OnClientClick="if (!Page_ClientValidate('ProductItemGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                                            UseSubmitBehavior="false" class="btn btn-sm btn-primary" ValidationGroup="ProductItemGroup" Text="Save changes"></asp:Button>
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnopen" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Product -->
                <div id="faq1881" class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq1881" href="#faq1881_q1881">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="lblprinciple" runat="server" Text="raw"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                                        <asp:AsyncPostBackTrigger ControlID="gridviewcontact" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </a></h4>
                        </div>
                        <div id="faq1881_q1881" class="panel-collapse collapse" style="height: 0px; max-height: 303px; overflow: auto;">
                            <div class="panel-body">
                                <asp:LinkButton ID="LinkButton1" Text="" runat="server" />
                                <asp:LinkButton ID="LinkButton2" Text="Add Item" runat="server" class="btn btn-alt btn-xs btn-primary" Visible="false"  />
                                <br />
                                <br />
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="table-responsive">
                                            <asp:GridView ID="gridview2" ShowFooter="true" GridLines="None" CssClass="table table-striped table-vcenter" 
                                                HeaderStyle-Width="100" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Smaller" CellPadding="0" CellSpacing="0" 
                                                runat="server" AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Contact Name" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink11" runat="server">Contact Name</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Literal ID="ltproductname1" runat="server" Text='<%#Eval("Principle_ContactPerson")%>'></asp:Literal>
                                                            <asp:Literal ID="ltitemid" runat="server" Text='<%#Eval("Principle_ID")%>' Visible="false"></asp:Literal>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Mobile" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink12" runat="server">Mobile</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Literal ID="ltproductcode" runat="server" Text='<%#Eval("Principle_MobileNo")%>'></asp:Literal>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="EmailId" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink13" runat="server">EmailId</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Literal ID="ltpackingpacking" runat="server" Text='<%#Eval("Principle_EmailID")%>'></asp:Literal>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Phone" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink13" runat="server">Phone</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Literal ID="ltpackingpacking" runat="server" Text='<%#Eval("Principle_Phone")%>'></asp:Literal>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="Rate" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                          <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink15" runat="server">Rate/kg</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                           <i class="fa fa-rupee"></i>&nbsp; <asp:Literal ID="ltrate" runat="server" Text='<%#Eval("ItemDt_Rate")%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                                   <%-- <asp:TemplateField HeaderText="VP_RefName" ItemStyle-Width="100px" HeaderStyle-CssClass="" ItemStyle-CssClass="" Visible="false" >
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink14" runat="server">Reference Name</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div class="col-md-12">
                                                                <asp:TextBox ID="txtquantity" runat="server" Visible="false" Text='<%#Eval("VP_RefName")%>' Height="25" Width="400" data-toggle="tooltip" title="Enter Qunatity"
                                                                    CssClass="form-control"></asp:TextBox>
                                                                <asp:Literal ID="ltquantity" runat="server" Text='<%#Eval("VP_RefName")%>'></asp:Literal>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <%--<asp:TemplateField HeaderText="KG" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                          <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink17" runat="server">KG</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Literal ID="ltkg" Text='<%#Eval("Packing_Weight")%>' runat="server"></asp:Literal> kg
                                            <%-- <asp:Literal ID="lblvat" runat="server" Text='<%#Eval("Product_Vat")%>' Visible="false" />--%
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vat" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                          <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink17" runat="server">Vat</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            
                                            
                                            <i class="fa fa-rupee"></i>&nbsp; <asp:Literal ID="lblvatinrs" runat="server" Text='<%#Eval("Product_Vat")%>' />(<asp:Literal ID="lblvat" runat="server" Text='<%#Eval("Product_Vat")%>' />%)
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            Total Vat:<br /><hr style="border:0;border-top: 1px solid #eee;margin-top:4px;margin-bottom:4px;"" />
                                            Total Amount:
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                            <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink18" runat="server">Amount</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <i class="fa fa-rupee"></i>&nbsp;<asp:Literal ID="ltamount" Text='<%#Eval("ItemDt_Amount")%>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <FooterTemplate>
<%--Total Amount:<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%<b><i class="fa fa-rupee"></i>&nbsp;<asp:Literal ID="lttotalvat" Text='78500' runat="server"></asp:Literal></b><br /><hr style="border:0;border-top: 1px solid #eee;margin-top:4px;margin-bottom:4px;" /><b><i class="fa fa-rupee"></i>&nbsp; <asp:Literal ID="lttotalamount" Text='78500' runat="server"></asp:Literal></b></FooterTemplate>
                                    </asp:TemplateField>--%>
                                                   <%-- <asp:TemplateField ItemStyle-Width="" HeaderStyle-CssClass="" ItemStyle-CssClass="" Visible="false" >
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:LinkButton ID="lkupdate" data-toggle="tooltip" title="Update" Visible="false" runat="server" class="btn btn-primary"
                                                                    CommandName="updatelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>">Update</asp:LinkButton>
                                                                <asp:LinkButton ID="lnkedit" data-toggle="tooltip" title="Edit" runat="server" class="btn btn-primary"
                                                                    CommandName="Editlink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>">Edit</asp:LinkButton>

                                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger" runat="server" OnClientClick="checkdelete();"
                                                                    CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>">Delete</asp:LinkButton>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
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
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="GridView1" />
                                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                                        <asp:AsyncPostBackTrigger ControlID="gridviewcontact" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnlPopup" TargetControlID="btnShow"
                                    CancelControlID="btnNo">
                                </asp:ModalPopupExtender>
                                <asp:Panel ID="Panel1" runat="server" Style="display: none">
                                    <div class="modal-dialog modal-lg" style="overflow-y: scroll; position: fixed; top: 0; bottom: 0; left: 0; right: 0; overflow: auto;">
                                        <div class="modal-content" style="top: 1%; overflow-x: hidden; overflow-y: auto; outline: none; margin-top: 0; top: 50%; overflow: visible;">
                                            <div class="modal-header">
                                                <asp:LinkButton ID="LinkButton3" class="close" runat="server">&times;</asp:LinkButton>
                                                <h3 class="modal-title">Add Product</h3>
                                            </div>
                                            <div class="modal-body" style="overflow: auto">
                                                <div class="table-options clearfix">
                                                    <div class="col-sm-5 col-xs-4">
                                                        <div class="dataTables_length" id="example-datatable_length">
                                                            <%--  <asp:DropDownList ID="ddpagesize" AutoPostBack="true" runat="server" CssClass="form-control">
                                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                            </asp:DropDownList>--%>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-4 col-xs-12">
                                                        <div id="example-datatable_filter" class="dataTables_filter">
                                                            <label>
                                                                <div class="input-group">
                                                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Search" /><span class="input-group-addon">
                                                                        <i class="fa fa-search"></i></span>
                                                                </div>
                                                            </label>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-3 col-xs-12">
                                                        <asp:Button ID="Button1" EnableViewState="false" runat="server" Text="Show All" CssClass="btn btn-alt btn-sm btn-info" />
                                                    </div>
                                                </div>
                                                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="Rm_ID"
                                                                CssClass="table table-striped table-vcenter table-hover">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Select" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Rm_ID">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="ckselect" runat="server" />
                                                                            <asp:Literal ID="lblProductId" runat="server" Text='<%#Eval("Rm_ID")%>' Visible="false" />

                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Product Name" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                                        <HeaderTemplate>
                                                                            <asp:HyperLink ID="HyperLink11" runat="server">Raw Material Name</asp:HyperLink>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Literal ID="ltproductname" runat="server" Text='<%#Eval("Rm_Name")%>'></asp:Literal>
                                                                            <asp:Literal ID="ltitemid" runat="server" Text='<%#Eval("Rm_ID")%>' Visible="false"></asp:Literal>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Description" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                                        <HeaderTemplate>
                                                                            <asp:HyperLink ID="HyperLink12" runat="server">Description</asp:HyperLink>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Literal ID="ltproductcode" runat="server" Text='<%#Eval("Rm_Desc")%>'></asp:Literal>
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
                                                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                                                        <asp:AsyncPostBackTrigger ControlID="btnopen" />
                                                        <asp:AsyncPostBackTrigger ControlID="btnshowall" />
                                                    </Triggers>
                                                </asp:UpdatePanel>

                                            </div>
                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="modal-footer">
                                                        <asp:Button ID="Button2" runat="server" OnClientClick="if (!Page_ClientValidate('ProductItemGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                                            UseSubmitBehavior="false" class="btn btn-sm btn-primary" ValidationGroup="ProductItemGroup" Text="Save changes"></asp:Button>
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnopen" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
                <%--<User:OportunityControl ID="oportunitycontrol" runat="server" />--%>

                <!--ORDER-->
                <%--<div id="divorder55" class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#divorder55" href="#manOrder">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="lblorder" Text="Order" runat="server"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </a></h4>
                        </div>
                        <div id="manOrder" class="panel-collapse collapse" style="height: 0px;">
                            <div class="panel-body">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="Order_Id" AllowCustomPaging="true"
                                                CssClass="table table-striped table-vcenter table-hover" AllowPaging="True" PageSize="10">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="" ItemStyle-Width="10px" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink4" runat="server">Edit</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="lkedit" EnableViewState="false" NavigateUrl='<%# "EditSalesOrder.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Order_Id").ToString()))%>'
                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server" onclick="window.open (this.href, 'popupwindow',  'width=900,height=500,scrollbars,resizable,top=100,left=200'); return false;"><i class="fa fa-pencil"></i></asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Order Code" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Order_Id">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblInvoiceId" runat="server" Text='<%#Eval("Order_Id")%>' EnableViewState="false"  Visible="false" />
                                                             <asp:HyperLink ID="hpviwe4" EnableViewState="false" NavigateUrl='<%# "EditSalesOrder.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Order_Id").ToString()))%>'
                                                    data-toggle="tooltip" title="View" runat="server" onclick="window.open (this.href, 'popupwindow',  'width=900,height=500,scrollbars,resizable,top=100,left=200'); return false;">
                                            <asp:Literal ID="lblOrderCode" runat="server" Text='<%#Eval("Order_Code")%>' EnableViewState="false" /></asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Order Date" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Order_CreatedDate">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblorderdate" runat="server" Text='<%#Eval("Order_CreatedDate")%>' EnableViewState="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Order_Amount">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblamount" runat="server" Text='<%#Eval("Order_Amount")%>' EnableViewState="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Order Status" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Order_OrderStatus">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblorderstatus" runat="server" Text='<%#Eval("Order_OrderStatus")%>' EnableViewState="false" />
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
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>--%>
                <!--ORDER-->

                <!--Invoice-->
                <%--<div id="divinv26" class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#divinv26" href="#faqInvoice">
                                <asp:UpdatePanel ID="UpdatePanelinv" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="lblinvoice" Text="Invoice" runat="server"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </a></h4>
                        </div>
                        <div id="faqInvoice" class="panel-collapse collapse" style="height: 0px;">
                            <div class="panel-body">
                                <asp:UpdatePanel ID="upInvoice" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Invoice_ID" AllowCustomPaging="true"
                                                CssClass="table table-striped table-vcenter table-hover" AllowPaging="True" PageSize="10">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Invoice Number" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Invoice_ID">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblInvoiceId" runat="server" Text='<%#Eval("Invoice_ID")%>' EnableViewState="false"  Visible="false" />
                                                            <asp:HyperLink ID="HyperLink3" EnableViewState="false" NavigateUrl='<%# "PrintInvoice.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Invoice_ID").ToString()))%>'
                                                                    data-toggle="tooltip" title="View" runat="server" Target="_blank">                                                            
                                                             <asp:Literal ID="lblinvno" runat="server" Text='<%#Eval("Invoice_Number")%>' EnableViewState="false" /></asp:HyperLink>                                                           
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Order Code" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Order_Code">
                                                        <ItemTemplate>                                                            
                                                            <asp:HyperLink ID="hpviwe4" EnableViewState="false" NavigateUrl='<%# "EditSalesOrder.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Order_Id").ToString()))%>'
                                                    data-toggle="tooltip" title="View" runat="server" onclick="window.open (this.href, 'popupwindow',  'width=900,height=500,scrollbars,resizable,top=100,left=200'); return false;">
                                            <asp:Literal ID="lblOrderCode" runat="server" Text='<%#Eval("Order_Code")%>' EnableViewState="false" /></asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Invoice Date" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Invoice_Date">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lbldate" runat="server" Text='<%#Eval("Invoice_Date")%>' EnableViewState="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Invoice_Amount">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblamount" runat="server" Text='<%#Eval("Invoice_Amount")%>' EnableViewState="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Invoice Status" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Invoice_Status">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblstatus" runat="server" Text='<%#Eval("Invoice_Status")%>' EnableViewState="false" />
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
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>--%>
                <!--Invoice-->
                <!--Payment-->
                <%--<div id="divpayment92" class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#divpayment92" href="#faqPayment">
                                <asp:UpdatePanel ID="UpdatePanelPay" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="lblpayment" Text="Payment" runat="server"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </a></h4>
                        </div>
                        <div id="faqPayment" class="panel-collapse collapse" style="height: 0px;">
                            <div class="panel-body">
                                <asp:UpdatePanel ID="UpdatePanelpayment" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Payment_ID" AllowCustomPaging="true"
                                                CssClass="table table-striped table-vcenter table-hover" AllowPaging="True" PageSize="10">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Payment_ID" Visible="false" >
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblPaymentId" runat="server" Text='<%#Eval("Payment_ID")%>' EnableViewState="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Payment_Date">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lbldate" runat="server" Text='<%#Eval("Payment_Date")%>' EnableViewState="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>                                                    
                                                    <asp:TemplateField HeaderText="Amount" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Payment_Amount">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblamount" runat="server" Text='<%#Eval("Payment_Amount")%>' EnableViewState="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Mode Of Payment" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Payment_Mode">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblmode" runat="server" Text='<%#Eval("Payment_Mode")%>' EnableViewState="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Other info" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="otherinfo">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblinfo" runat="server" Text='<%#Eval("otherinfo")%>' EnableViewState="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Payment_Status">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk" CssClass='<%#Security.checkStatus(Eval("Payment_Status"))%>' runat="server" Text='<%#Eval("Payment_Status")%>'
                                                CommandName="statuslink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="View" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="HyperLink1" EnableViewState="false" NavigateUrl='<%# "_ModifyPayment.aspx?chk=v&PaymentId=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Payment_ID").ToString()))%>'
                                                    data-toggle="tooltip" title="View" class="btn btn-default" runat="server"><i class="fa fa-eye"></i></asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">

                                                <asp:HyperLink ID="HyperLink2" EnableViewState="false" NavigateUrl='<%# "_ModifyPayment.aspx?PaymentId=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Payment_ID").ToString()))%>'
                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                    CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%
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
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>--%>
                <!--Payment-->
                <%-- <User:QuotationControl ID="quotationcontrol" runat="server" />--%>
                <User:EmailControl ID="emailcontrol" runat="server" Visible="false"  />
                <div id="faq6" class="panel-group">
                    <User:NoteControl ID="notecontrol" runat="server" Visible="false"  />
                </div>
                <div id="faq1" class="panel-group">
                    <User:NewDocumentControl ID="documentcontrol" runat="server" Visible="false"  />
                </div>
            </div>
            <User:ActivityControl ID="activitycontrol" runat="server" Visible="false"  />
        </div>
    </div>
</asp:Content>
