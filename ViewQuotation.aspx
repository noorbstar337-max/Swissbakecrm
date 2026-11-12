<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="ViewQuotation.aspx.vb" Inherits="ViewQuotation" Culture="en-GB" %>

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
        function ShowModalPopup() {
            $find("mpe").show();
            return false;
        }
    </script>
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("#dvAccordian").accordion();
        });
    </script>
     <script  type="text/javascript">
         function printDiv(abc) {
             //Get the HTML of div

             //Get the HTML of whole page
             var oldPage = document.body.innerHTML;

             //Reset the page's HTML with div's HTML only
             document.body.innerHTML = "<html><head><title></title></head><body>" + abc + "</body>";

             //Print Page
             window.print();

             //Restore orignal HTML
             document.body.innerHTML = oldPage;


         }
     </script>
    <style>
        .tr_footer {
            border: 0px solid;
        }

            .tr_footer > tr > td {
                border: 0px solid !important;
            }
    </style>
       <script type="text/javascript">
           function SetTarget() {
               document.forms[0].target = "_blank";
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
                        <i class="gi gi-table" style="margin: -8px"></i>Quotation Detail<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="Quotation.aspx">Quotation</a></li>
                <li>Quotation Detail</li>
            </ul>
            <div class="col-md-8">
                <!-- Advanced Active Theme Color Widget Alternative -->
                <div class="widget" style="min-height: 331px">
                    <div class="widget-advanced widget-advanced-alt">
                        <!-- Widget Header -->
                        <div class="widget-header text-center themed-background-dark">
                            <h4 class="widget-content-light">
                                <a>
                                    <asp:Literal ID="ltcontactname" runat="server"></asp:Literal>
                                </a>
                                <asp:HiddenField ID="hfcontacttype" runat="server" />
                                <asp:HiddenField ID="hfcontacttypeid" runat="server" />
                                <br>
                                <small>
                                    <asp:Literal ID="ltcompanyname" runat="server"></asp:Literal>
                                </small>
                            </h4>
                            <div class="col-md-12">
                                <div class="block-section">
                                    <a id="aedit" runat="server" class="btn btn-alt btn-sm btn-primary">Edit</a>
                                        <a  ID="aprint"  title="Print Quotation" class="btn btn-alt btn-sm btn-default" runat="server"  Target="_blank"><i class="fa fa-file"></i> Print</a>
                                    <asp:LinkButton ID="lkdelete" runat="server" class="btn btn-alt btn-sm btn-danger" OnClientClick="checkdelete();" Visible="false">Delete</asp:LinkButton>
                                    <%--  <asp:LinkButton ID="lkconvacount" runat="server" class="btn btn-alt btn-sm btn-info">Convert To Account</asp:LinkButton>--%>
                                    <%-- <asp:LinkButton ID="lkconvQuotation" runat="server" class="btn btn-alt btn-sm btn-warning">Convert To Quotation</asp:LinkButton>--%>
                                </div>

                            </div>
                        </div>
                        <!-- END Widget Header -->

                        <!-- Widget Main -->
                        <div class="widget-main">
                            <div class="list-group remove-margin">
                                <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Repeater ID="rpowner" runat="server">
                                            <ItemTemplate>
                                               <%#Eval("U_FirstName")%>
                                            </ItemTemplate>
                                            <SeparatorTemplate>
                                              ,
                                            </SeparatorTemplate>
                                        </asp:Repeater></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-tag fa-fw"></i>&nbsp;Quotation assign to</h5>
                                </a>
                                <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltStage" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-mobile fa-fw"></i>&nbsp;Validity</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                                <a href="javascript:void(0)" class="list-group-item" runat="server" visible="false" >
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltprobability" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-phone fa-fw"></i>&nbsp;Mode OF Payment</h5>
                                    <p class="list-group-item-text"></p>
                                </a>

                                <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltdate" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-calendar fa-fw"></i>&nbsp;Quotation Date</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
								 <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="Lblbank" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-bank fa-fw"></i>&nbsp;Bank </h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                               <%-- ===============================================================================--%>
                                <div id="divExport" runat="server" visible="false">
                                <a href="javascript:void(0)" class="list-group-item" >
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltModeOfTransport" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-tag fa-fw"></i>&nbsp; Mode Of Transport</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                                <%--<a href="javascript:void(0)" class="list-group-item" runat="server">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltCountryOfOrigin" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-tag fa-fw"></i>&nbsp;Country Of Origin</h5>
                                    <p class="list-group-item-text"></p>
                                </a>--%>
                                <a href="javascript:void(0)" class="list-group-item" >
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltCountryFinalDestination" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-tag fa-fw"></i>&nbsp;Country Of Final Destination</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                               <%-- <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltPortLoading" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-tag fa-fw"></i>&nbsp;Port Of Loading</h5>
                                    <p class="list-group-item-text"></p>
                                </a>--%>
                               <%-- <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltPortDischarge" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-tag fa-fw"></i>&nbsp;Port Of Discharge</h5>
                                    <p class="list-group-item-text"></p>
                                </a>--%>
                                <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltFinalDestination" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-tag fa-fw"></i>&nbsp;Final Destination</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                                </div>


                            </div>
                        </div>
                        <!-- END Widget Main -->
                    </div>
                </div>
                <!-- END Advanced Active Theme Color Widget Alternative -->
            </div>
            <asp:UpdatePanel ID="upquickaction" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="col-sm-12 col-md-4">
                        <!-- Widget -->

                        <div class="widget">
                            <div class="widget-simple">
                                <a class="widget-icon pull-left animation-fadeIn themed-background">
                                    <i class="hi hi-tasks"></i>
                                </a>
                                <h4 class="widget-content text-right animation-hatch">
                                    <a href="javascript:void(0)"><strong>
                                        <asp:Literal ID="ltcounttask" runat="server"></asp:Literal></strong> Task</a>
                                    <small>
                                        <asp:LinkButton ID="lkquicktask" CssClass="btn btn-alt btn-xs btn-primary" runat="server">Add New Task</asp:LinkButton></small>
                                </h4>
                            </div>
                        </div>

                        <!-- END Widget -->
                    </div>
                    <div class="col-sm-12 col-md-4">
                        <!-- Widget -->
                        <div class="widget">
                            <div class="widget-simple">
                                <a class="widget-icon pull-left animation-fadeIn themed-background-default">
                                    <i class="hi hi-bullhorn"></i>
                                </a>
                                <h4 class="widget-content text-right animation-hatch">
                                    <a href="javascript:void(0)" style="color: #3498db;"><strong>
                                        <asp:Literal ID="ltcountevent" runat="server"></asp:Literal></strong> Sampling/Demo</a>
                                    <small>
                                        <asp:LinkButton ID="lkquickevent" CssClass="btn btn-alt btn-xs btn-info" runat="server">Add New Sampling/Demo</asp:LinkButton></small>
                                </h4>
                            </div>
                        </div>
                        <!-- END Widget -->
                    </div>
                    <div class="col-sm-12 col-md-4">
                        <!-- Widget -->
                        <div class="widget">
                            <div class="widget-simple">
                                <a href="javascript:void(0)" class="widget-icon pull-left animation-fadeIn themed-background-fire">
                                    <i class="hi hi-phone_alt"></i>
                                </a>
                                <h4 class="widget-content text-right animation-hatch">
                                    <a href="javascript:void(0)" style="color: #e74c3c"><strong>
                                        <asp:Literal ID="ltcountcall" runat="server"></asp:Literal></strong> Phone/Email</a>
                                    <small>
                                        <asp:LinkButton ID="lkquickcall" CssClass="btn btn-alt btn-xs btn-danger" runat="server">Add New Phone/Email</asp:LinkButton></small>
                                </h4>
                            </div>
                        </div>
                        <!-- END Widget -->
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <%--starts--%>
            <div class="col-md-12">
         <div id="faq188f" class="panel-group">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4 class="panel-title"><a class="accordion-toggle" data-toggle="collapse" data-parent="#faq188f" href="#faq188f_q188">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblitemdt" Text="open" runat="server"></asp:Label></ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                    </Triggers>
                </asp:UpdatePanel>
            </a></h4>
        </div>
        <div id="faq188f_q188" class="panel-collapse collapse in" style="max-height: 303px;overflow: auto;">
                <div class="col-md-12">
                    <br />
                            <div id="faq1881" class="panel-group" runat="server">
                                <asp:Repeater ID="rptmaidq" runat="server">
                                    <ItemTemplate>

                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq1881" href='<%#"#" + Eval("Quotation_Id").ToString%>'>
                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:Label ID="lblDescptn" runat="server" Text='<%#Eval("Quotation_No")%>'></asp:Label>
                                                            <asp:Label ID="lblqtn" runat="server" Text='<%#Eval("Quotation_Id")%>' Visible="false"></asp:Label>&nbsp;&nbsp;|
                                                           Version:<asp:Label ID="lblversion" runat="server"></asp:Label>&nbsp;&nbsp;|
                                                            Amount:<asp:Label ID="lblamt" runat="server" ></asp:Label>
                                                                  
                                                           <%-- <div class="pull-right">
                                                                <asp:Label ID="lblAmt" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                                                <asp:HyperLink ID="hledit" EnableViewState="false" NavigateUrl='<%# "ModifyExpense.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Ex_Id").ToString()))%>'
                                                                    class="btn btn-alt btn-xs btn-primary" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                                            </div>--%>
                                                        </ContentTemplate>

                                                    </asp:UpdatePanel>
                                                </a></h4>
                                            </div>
                                            <div id='<%#Eval("Quotation_Id").ToString%>' class="panel-collapse collapse" style="height: 0px; max-height: 303px; overflow: auto;">
                                                <div class="panel-body">
                                                    <asp:LinkButton ID="LinkButton1" Text="" runat="server" />
                                                    <asp:LinkButton ID="LinkButton2" Text="Add Item" runat="server" class="btn btn-alt btn-xs btn-primary" Visible="false" />
                                                    <br />

                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="table-responsive">
                            <asp:GridView ID="grditemproduct" ShowFooter="true"    GridLines="None" CssClass="table table-striped table-vcenter" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true"  HeaderStyle-Font-Size="Smaller" CellPadding="0" CellSpacing="0" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="Product Name"  HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                         <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink11" runat="server">Product Name</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Literal ID="ltproductname" runat="server" Text='<%#Eval("Product_Name")%>'></asp:Literal>
                                            <asp:Literal ID="ltitemid" runat="server" Text='<%#Eval("ItemDt_ID")%>' Visible="false"></asp:Literal>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product Code" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                          <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink12" runat="server">Product Code</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Literal ID="ltproductcode" runat="server" Text='<%#Eval("Product_Code")%>'></asp:Literal> 
                                            <asp:Label ID="ltitemtypeid" runat="server" Text='<%#Eval("ItemDt_TypeId")%>' Visible="false" ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SKU" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                          <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink13" runat="server">SKU</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Literal ID="ltproductWeight" runat="server" Text='<%#Eval("Packing_Weight")%>' Visible="false"></asp:Literal>
                                            <asp:Literal ID="ltpackingpacking" runat="server" Text='<%#Eval("Packing_Packing")%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                          <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink15" runat="server">Rate/kg</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                           <i class="fa fa-rupee"></i>&nbsp; <asp:Literal ID="ltrate" runat="server" Text='<%#Eval("ItemDt_Rate")%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No.Of Pack" ItemStyle-Width="100px" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                        <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink14" runat="server">No.Of Pack</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="col-md-12">
                                                <asp:label ID="txtquantity" runat="server"  Visible="false" Text='<%#Eval("ItemDt_Qty")%>' Height="25" data-toggle="tooltip" title="Enter Qunatity"
                                                    CssClass="form-control"></asp:label>
                                                <asp:Literal ID="ltquantity" runat="server" Text='<%#Eval("ItemDt_Qty")%>'></asp:Literal>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                               
                                    <asp:TemplateField HeaderText="GST" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                          <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink17" runat="server">GST</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            
                                            
                                            <i class="fa fa-rupee"></i>&nbsp; <asp:Literal ID="lblvatinrs" runat="server" Text='<%#Eval("Product_Vat")%>' />(<asp:Literal ID="lblvat" runat="server" Text='<%#Eval("Product_Vat")%>' />%)
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                         <asp:TemplateField HeaderText="KG" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                          <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink17" runat="server">KG</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Literal ID="ltkg" Text='<%#Eval("Packing_Weight")%>' runat="server"></asp:Literal> kg
                                            <%-- <asp:Literal ID="lblvat" runat="server" Text='<%#Eval("Product_Vat")%>' Visible="false" />--%>
                                        </ItemTemplate>
                                        <FooterTemplate>

                                            <!--Discount-->
                                            <div id="divdiscount" runat="server" visible="false">
                                                Discount Amount (<asp:Label ID="lblDiscountPer" runat="server"></asp:Label>%):
     <br />
                                                <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />
                                            </div>
                                            <!--Discount end -->
                                            
                                            Total GST:<br /><hr style="border:0;border-top: 1px solid #eee;margin-top:4px;margin-bottom:4px;"" />

                                           <%--  TCS Amount:<br /><hr style="border:0;border-top: 1px solid #eee;margin-top:4px;margin-bottom:4px;" "="">
    
    
                                              ODA Charges:<br /><hr style="border:0;border-top: 1px solid #eee;margin-top:4px;margin-bottom:4px;" "="">--%>
                                            <div id="divTCS" runat="server">
                                                TCS Amount:<br />
                                                <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />

                                            </div>

                                            <div id="divODA" runat="server">
                                                ODA Charges:<br />
                                                <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />

                                            </div>
   
    

                                              Freight:<br />
                                                            <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />
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
                                            <%--Total Amount:<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                                            <!--Discount-->
                                            <div id="discountamt" runat="server" visible="false">
                                                <b><i class="fa fa-rupee"></i>&nbsp;
                                                    <asp:Label ID="LbldiscountAmt" runat="server"></asp:Label>
                                                </b>
                                                <br />

                                            </div>
                                            <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />
                                            <!--Discount end-->
                                            <b><i class="fa fa-rupee"></i>&nbsp;<asp:Literal ID="lttotalvat" Text='78500' runat="server"></asp:Literal></b><br />
                                            <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />

                                            <!-- Labels for amounts, separate -->
                                            <span id="spanTCS" runat="server">
                                                <b><i class="fa fa-rupee"></i>&nbsp;
                                              <asp:Label ID="lblTCS" runat="server" Text="0.00" />
                                                </b>
                                                <br />
                                                <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />
                                            </span>
                                            <span id="spanODA" runat="server">
                                                <b><i class="fa fa-rupee"></i>&nbsp;
                                             <asp:Label ID="lblODA" runat="server" Text="0.00" />
                                                </b>
                                                <br />
                                                <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />
                                            </span>
                                            <b><i class="fa fa-rupee"></i>&nbsp;
                                                                <asp:Label ID="lblfreight" runat="server"></asp:Label>

                                            </b>
                                            <br />
                                            <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />
                                            <b><i class="fa fa-rupee"></i>&nbsp;
                                                <asp:Literal ID="lttotalamount" Text='78500' runat="server"></asp:Literal></b>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <%--  <asp:TemplateField ItemStyle-Width="" HeaderStyle-CssClass="" ItemStyle-CssClass="">
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
                       
                        <asp:AsyncPostBackTrigger ControlID="grditemproduct" />
                    </Triggers>
                </asp:UpdatePanel>

                                                </div>
                                            </div>
                                        </div>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>


                        </div>
                                                     
                                                </div> </div>  </div> 
            </div>
            <%--ends--%>
           <%-- <div class="col-md-12">
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
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="table-responsive">
                                                 <table id="printtable" class="table table-vcenter table-condensed table-bordered" style="margin-bottom: 0px;">
                             <thead>
                                 <tr>                                    
                                     <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Quotation No</th>                                    
                                     <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Date</th>
                                     <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Amount</th>
                                     <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Vat</th>
                                     <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Freight</th>
                                      <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Payment Terms</th>
                                 </tr>
                             </thead>
                             <tbody>
                                 <asp:Repeater ID="rpgridhistory" runat="server">
                                     <ItemTemplate>
                                         <div class="panel panel-default">
                                             <div class="panel-heading">
                                                 <h4 class="panel-title">
                                                    <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq1881" href='<%#"#" + Eval("ItemDt_ID").ToString%>'>
                                                         <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                             <ContentTemplate>                                                                 
                                                                 <asp:Label ID="lblId" runat="server" Text='<%#Eval("ItemDt_ID")%>' Visible="false"></asp:Label>                                                                   
                                                                 <asp:Label runat="server" Text='<%#Eval("Quotation_No")%>'></asp:Label>
                                                                 <asp:Label runat="server" Text='<%#Eval("QDate")%>'></asp:Label>
                                                                 <asp:Label runat="server" Text='<%#Convert.ToDouble(Eval("ItemDt_Amount")).ToString("#,##0.00")%>'></asp:Label>
                                                                 <asp:Label runat="server" Text='<%#Convert .ToDouble (Eval("ItemDt_Vat")).ToString("#,##0.00")%>'></asp:Label>
                                                                 <asp:Label runat="server" Text='<%#Convert .ToDouble (Eval("Quotation_Freight")).ToString("#,##0.00")%>'></asp:Label>
                                                                 <div class="pull-right">
                                                                     <a id="lkview" data-toggle="tooltip" title="View" class="btn btn-alt btn-xs btn-default" href='<%#checkurlView(Eval("Quotation_Id").ToString)%>'><i class="fa fa-eye"></i></a>&nbsp;
                                                            <a id="lkedit" data-toggle="tooltip" title="Edit" class="btn btn-alt btn-xs btn-primary" href='<%#checkurledit(Eval("Quotation_Id").ToString)%>'><i class="fa fa-pencil"></i></a>&nbsp;
                                                                 </div>
                                                             </ContentTemplate>
                                                         </asp:UpdatePanel>
                                                    </a>
                                                 </h4>
                                             </div>
                                             <div class="panel-collapse collapse"  style="height: 0px; max-height: 303px; overflow: auto;">
                                                 <div class="panel-body">
                                                     <asp:LinkButton ID="LinkButton1" Text="" runat="server" />
                                                     <asp:LinkButton ID="LinkButton2" Text="Add Item" runat="server" class="btn btn-alt btn-xs btn-primary" Visible="false" />
                                                     <br />
                                                     <br />
                                                     <table id="example-datatable11" class="table table-vcenter table-condensed table-bordered">
                                                         <thead>
                                                             <tr>
                                                                 <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Product Name</th>
                                                                 <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Product Code</th>
                                                                 <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">SKU</th>
                                                                 <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Rate</th>
                                                                 <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">No.Of Pack</th>
                                                                 <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">KG</th>
                                                                 <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">VAT</th>
                                                                 <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Amount</th>
                                                             </tr>
                                                         </thead>
                                                         <tbody>
                                                             <asp:Repeater ID="rptQuotationdetails" runat="server">
                                                                 <ItemTemplate>
                                                                     <tr>
                                                                         <td class="text-center">
                                                                             <asp:Label ID="Label5" runat="server" Text='<%#Eval("Product_Name")%>'></asp:Label>
                                                                             <asp:Literal ID="ltitemid" runat="server" Text='<%#Eval("ItemDt_ID")%>' Visible="false"></asp:Literal>
                                                                         </td>
                                                                         <td class="text-center">
                                                                             <asp:Label ID="Label1" runat="server" Text='<%#Eval("Product_Code")%>'></asp:Label></td>
                                                                         <td class="text-center">
                                                                            <asp:Literal ID="ltproductWeight" runat="server" Text='<%#Eval("Packing_Weight")%>' Visible="false"></asp:Literal>
                                                                            <asp:Literal ID="ltpackingpacking" runat="server" Text='<%#Eval("Packing_Packing")%>'></asp:Literal>
                                                                         </td>
                                                                         <td class="text-center">
                                                                             <i class="fa fa-rupee"></i>&nbsp; <asp:Literal ID="ltrate" runat="server" Text='<%#Eval("ItemDt_Rate")%>'></asp:Literal>
                                                                           </td>
                                                                         <td class="text-center">
                                                                             <asp:Literal ID="ltquantity" runat="server" Text='<%#Eval("ItemDt_Qty")%>'></asp:Literal>
                                                                         </td>
                                                                         <td class="text-center">
                                                                             <asp:Literal ID="ltkg" Text='<%#Eval("Packing_Weight")%>' runat="server"></asp:Literal> kg
                                                                           </td>
                                                                         <td class="text-center">
                                                                             <i class="fa fa-rupee"></i>&nbsp; <asp:Literal ID="lblvatinrs" runat="server" Text='<%#Eval("Product_Vat")%>' />(<asp:Literal ID="lblvat" runat="server" Text='<%#Eval("Product_Vat")%>' />%)
                                                                           </td>
                                                                         <td class="text-center">
                                                                            <i class="fa fa-rupee"></i>&nbsp;<asp:Literal ID="ltamount" Text='<%#Eval("ItemDt_Amount")%>' runat="server"></asp:Literal>
                                                                           </td>
                                                                     </tr>
                                                                 </ItemTemplate>
                                                             </asp:Repeater>
                                                         </tbody>
                                                     </table>
                                                 </div>
                                             </div>
                                         </div>
                                     </ItemTemplate>
                                     <FooterTemplate>
                                         <tr id="trEmpty" runat="server" visible="false">
                                             <td class="dataTables_empty" style="width: 240px;">No matching records found.
                                             </td>
                                         </tr>
                                     </FooterTemplate>
                                 </asp:Repeater>
                                 <asp:Label ID="Label1" runat="server" Text="No matching records found" Visible="false"></asp:Label>
                                 <tfoot>
                                     
                                 </tfoot>


                             </tbody>

                         </table>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                              
                            </div>
                        </div>
                    </div>
                </div>
                
            </div>--%>
            <div class="col-md-12">
                <%--  <User:ContactControl ID="contactcontrol" runat="server" />--%>


                <User:ItemDetailControl ID="itemdtcontrol" runat="server"  Visible="false" />
                <User:EmailControl ID="emailcontrol" runat="server" />
                <div id="faq6454" class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq6454" href="#faq6454_q1285">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="lblcontact" Text="Proforma" runat="server"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                                        <asp:AsyncPostBackTrigger ControlID="grdproforma" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </a></h4>
                        </div>
                        <div id="faq6454_q1285" class="panel-collapse collapse" style="height: 0px; max-height: 303px; overflow: auto;">
                            <div class="panel-body">
                                <asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlcontactPopup" TargetControlID="btnShow"
                                    CancelControlID="btnNo">
                                </asp:ModalPopupExtender>
                                <asp:Panel ID="pnlcontactPopup" runat="server" Style="display: none" DefaultButton="btnsave">
                                    <div class="modal-dialog modal-sm">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                                                <h3 class="modal-title">Add Proforma</h3>
                                            </div>
                                            <div class="modal-body">
                                                <div class="form-group">
                                                    <label for="example-nf-email">Proforma Date</label>
                                                    <span class="text-danger">*
                                                    </span>
                                                    <asp:TextBox ID="txtduedate" runat="server" placeholder="Enter Expected Date" data-toggle="tooltip" title="Enter Expected Date"
                                                        CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="resubject" runat="server" ControlToValidate="txtduedate" ValidationGroup="ProformaGroup" CssClass="MasterValidationCSS"
                                                        ErrorMessage="Please enter date" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtduedate" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>
                                                </div>
                                                <asp:UpdatePanel ID="upquoamount" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div class="form-group">
                                                            <label for="example-nf-email">Quotation Amount: </label>
                                                            <asp:Label ID="lblquoamount" CssClass="badge" runat="server"></asp:Label>
                                                        </div>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnopneprofroma" />

                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                <div class="form-group">
                                                    <label for="example-nf-email">Payable Now </label>
                                                    <asp:TextBox ID="txtpayablenow" runat="server" placeholder="Enter Payable Now" onkeyup="this.value=this.value.replace(/[^\d\.]/g,'');" data-toggle="tooltip" title="Enter Payable Now"
                                                        CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpayablenow" ValidationGroup="ProformaGroup" CssClass="MasterValidationCSS"
                                                        ErrorMessage="Please enter payable now amount" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="modal-footer">
                                                <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-primary" Text="Save" ValidationGroup="ProformaGroup"></asp:Button>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <div class="">
                                    <asp:LinkButton ID="btnShow" runat="server"></asp:LinkButton>
                                    <asp:LinkButton ID="btnopneprofroma" runat="server" CssClass="btn btn-alt btn-xs btn-primary">New Proforma</asp:LinkButton><br />
                                    <br />
                                </div>
                                <asp:UpdatePanel ID="updocument" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="table-responsive">
                                            <asp:GridView ID="grdproforma" runat="server" AutoGenerateColumns="false" CellPadding="0" CellSpacing="0" DataKeyNames="Proforma_Id" AllowSorting="true" HeaderStyle-Font-Size="Smaller"
                                                CssClass="table table-borderless table-striped" GridLines="Horizontal" BorderWidth="0px" Width="100%" Font-Size="Small" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true">
                                                <Columns>
                                                    <%--<asp:TemplateField ItemStyle-Width="10px" HeaderStyle-CssClass="">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink2" runat="server">Edit</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Page.ResolveUrl("ModifyProforma.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Id").ToString())))%>'
                                                                    data-toggle="tooltip" title="Edit" class="btn btn-Primary" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Proforma No" HeaderStyle-CssClass="" SortExpression="Proforma Name" ItemStyle-CssClass="">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lkproformano" runat="server" CommandName="quotatnolink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Proforma_No"))%></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Proforma Date" HeaderStyle-CssClass="" SortExpression="Amount" ItemStyle-CssClass="">
                                                        <ItemTemplate>

                                                            <asp:Literal ID="ltproformadate" runat="server" Text='<%#DynamicparcelDataManipulation.AlphaDateFormat(Eval("Proforma_Date"))%>'></asp:Literal>

                                                            <asp:TextBox ID="txtduedate" runat="server" Text='<%#DynamicparcelDataManipulation.AlphaDateFormat(Eval("Proforma_Date"))%>' Visible="false" placeholder="Enter Expected Date" data-toggle="tooltip" title="Enter Expected Date"
                                                                CssClass="form-control"></asp:TextBox>

                                                            <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtduedate" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Payable Now" HeaderStyle-CssClass="" SortExpression="Website" ItemStyle-CssClass="">
                                                        <ItemTemplate>

                                                            <asp:Label ID="ltpayablenow" CssClass="badge" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Proforma_PayableNow"))%>'></asp:Label>
                                                            <asp:TextBox ID="txtpayablenow" runat="server" onkeyup="this.value=this.value.replace(/[^\d\.]/g,'');" Visible="false" Text='<%#Eval("Proforma_PayableNow")%>' placeholder="Enter Payable Now" data-toggle="tooltip" title="Enter Payable Now"
                                                                CssClass="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpayablenow" ValidationGroup="GridviewProformaGroup" CssClass="MasterValidationCSS"
                                                                ErrorMessage="Please enter payable now amount" Display="Dynamic"></asp:RequiredFieldValidator>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Print Pdf" HeaderStyle-CssClass="" SortExpression="Website" ItemStyle-CssClass="">
                                                        <ItemTemplate>

                                                            <asp:LinkButton ID="lkprintpdf" data-toggle="tooltip" title="Update" runat="server" class="btn btn-alt btn-xs btn-primary" 
                                                                CommandName="updatelink"  CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>" OnClientClick="window.document.forms[0].target='_blank';"><i class="fa fa-file-pdf-o fa-fw"></i> Print Pdf</asp:LinkButton>
                                             
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Email" Visible="false"  HeaderStyle-CssClass="" SortExpression="Website" ItemStyle-CssClass="">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lkemail" data-toggle="tooltip" title="Update" runat="server" class="btn btn-alt btn-xs btn-primary"
                                                                CommandName="EmailLink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-envelope-o"></i> Send Email</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:LinkButton ID="lkupdate" data-toggle="tooltip" title="Update" Visible="false" runat="server" class="btn btn-primary"
                                                                    CommandName="updatelinksdd" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>">Update</asp:LinkButton>
                                                                <asp:LinkButton ID="lnkedit" data-toggle="tooltip" title="Edit" runat="server" class="btn btn-primary"
                                                                    CommandName="Editlink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>">Edit</asp:LinkButton>

                                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger" runat="server" OnClientClick="checkdelete();"
                                                                    CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>">Delete</asp:LinkButton>
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
                                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                                        <asp:AsyncPostBackTrigger ControlID="grdproforma" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="faq6" class="panel-group">
                    <User:NoteControl ID="notecontrol" runat="server" />
                </div>
                <div id="faq1" class="panel-group">
                    <User:NewDocumentControl ID="documentcontrol" runat="server" />
                </div>
            </div>
            <User:ActivityControl ID="activitycontrol" runat="server" />


            
              <%--<div class="main_block" id="printablediv" style="width:793px;margin:auto;">
            <asp:Panel ID="pnl" runat="server">

                <table class="tr_footer" cellpadding="0" cellspacing="0" border="0" style="padding: 0px;  width: 719px; height: auto; position: absolute; top: 0px; z-index: -37;">

                    <tr>
                        <td colspan="4" style="">
                            <img src="http://crm.swissbake.co.in/img/CompanyImage/040515040511-Swissbake_-Headerr-800X100-px_4-10-14.png" style="width:793px;"/></td>
                      

                    </tr>




                    <tr>
                        <td style="">

                            <table cellpadding="0" cellspacing="0" style="  width: 793px;
  font: bold 12px 'Helvetica';
  border:1px solid #BDBCBC;">
                                <tr>

                                    <td colspan="7" style="height: 16px; text-align: center; font-weight: bold;">
                                        <p style="text-align: center; margin-top: 0px; margin-bottom: 0px; font: bold 17px 'Helvetica'; line-height: 19px;">PROFORMA INVOICE</p>
                                    </td>
                                   


                                </tr>


                                <tr>
                                    <td style="height: 16px; border-top: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 43px; vertical-align: bottom;">
                                        <p style="text-align: left; padding-left: 3px; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 12px 'Helvetica'; line-height: 15px;">To</p>
                                    </td>
                                    <td style="height: 16px; border-right: #BDBCBC 1px solid; border-top: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 288px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                    </td>
                                    <td colspan="2" style="height: 16px; border-right: #BDBCBC 1px solid; border-top: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 165px; vertical-align: bottom;">
                                        <p style="text-align: left; padding-left: 1px; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 12px 'Helvetica'; line-height: 15px;">Proforma Invoice No.</p>
                                    </td>
                                    <td style="height: 16px; border-top: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 81px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 12px 'Helvetica'; line-height: 15px;">Date</p>
                                    </td>
                                    <td style="height: 16px; border-top: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 84px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2" style="height: 17px; border-right: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 331px; vertical-align: bottom;">
                                        <p style="text-align: left; padding-left: 3px; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 15px;">
                                            <asp:Literal ID="ltaccname" runat="server"></asp:Literal><br />
                                            <asp:Literal ID="ltaccCont" runat="server"></asp:Literal><br />
                                            <asp:Literal ID="ltAccaddr" runat="server"></asp:Literal><br />
                                            <asp:Literal ID="ltpincity" runat="server"></asp:Literal><br />
                                            <asp:Literal ID="ltstate" runat="server"></asp:Literal>
                                        </p>
                                    </td>
                                    <td style="height: 17px; padding: 0px; margin: 0px; width: 82px; vertical-align: bottom;">
                                        <p style="text-align: left; padding-left: 1px; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 15px;">
                                            <asp:Literal ID="ltquono" runat="server"></asp:Literal>
                                        </p>
                                    </td>
                                    <td style="height: 17px; border-right: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 83px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                    </td>
                                    <td style="height: 17px; padding: 0px; margin: 0px; width: 81px; vertical-align: bottom;">
                                        <p style="text-align: right; padding-right: 21px; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 11px 'Helvetica'; line-height: 14px;">
                                            <asp:Literal ID="ltprodate" runat="server"></asp:Literal>
                                        </p>
                                    </td>
                                    <td style="height: 17px; padding: 0px; margin: 0px; width: 84px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; padding: 0px; margin: 0px; width: 43px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                    </td>
                                    <td style="height: 15px; border-right: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 288px; vertical-align: bottom;">
                                        <p style="font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                    </td>
                                    <td style="height: 15px; padding: 0px; margin: 0px; width: 82px; vertical-align: bottom;">
                                        <p style="text-align: left; padding-left: 1px; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 12px 'Helvetica'; line-height: 15px;">Buyer Ref. No.</p>
                                    </td>
                                    <td style="height: 15px; border-right: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 83px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                    </td>
                                    <td style="height: 15px; padding: 0px; margin: 0px; width: 81px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 12px 'Helvetica'; line-height: 15px;">Other Ref.</p>
                                    </td>
                                    <td style="height: 15px; padding: 0px; margin: 0px; width: 84px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 14px; padding: 0px; margin: 0px; width: 43px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 14px;">&nbsp;</p>
                                    </td>
                                    <td style="height: 14px; border-right: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 288px; vertical-align: bottom;">
                                        <p style="font: 1px 'Helvetica'; line-height: 14px;">&nbsp;</p>
                                    </td>
                                    <td style="height: 14px; padding: 0px; margin: 0px; width: 82px; vertical-align: bottom;">
                                        <p style="text-align: left; padding-left: 1px; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 14px;">
                                            <asp:Literal ID="ltbuyerref" runat="server"></asp:Literal>
                                        </p>
                                    </td>
                                    <td style="height: 14px; border-right: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 83px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 14px;">&nbsp;</p>
                                    </td>
                                    <td style="height: 14px; padding: 0px; margin: 0px; width: 81px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 14px;">
                                            <asp:Literal ID="ltotherref" runat="server"></asp:Literal>
                                        </p>
                                    </td>
                                    <td style="height: 14px; padding: 0px; margin: 0px; width: 84px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 14px;">&nbsp;</p>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="height: 15px; padding: 0px; margin: 0px; width: 43px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                    </td>
                                    <td style="height: 15px; border-right: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 288px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                    </td>
                                    <td colspan="2" style="height: 15px; border-right: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 165px; vertical-align: bottom;">
                                        <p style="text-align: left; padding-left: 1px; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 12px 'Helvetica'; line-height: 15px;">Terms of Delivery</p>
                                    </td>
                                    <td style="height: 15px; padding: 0px; margin: 0px; width: 81px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 12px 'Helvetica'; line-height: 15px;">Validity</p>
                                    </td>
                                    <td style="height: 15px; padding: 0px; margin: 0px; width: 84px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="height: 15px; padding: 0px; margin: 0px; width: 43px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                    </td>
                                    <td style="height: 15px; border-right: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 288px; vertical-align: bottom;">
                                        <p style="font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                    </td>
                                    <td style="height: 15px; padding: 0px; margin: 0px; width: 82px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                    </td>
                                    <td style="height: 15px; border-right: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 83px; vertical-align: bottom;">
                                        <p style="font: 1px 'Helvetica'; line-height: 1px;"></p>
                                    </td>
                                    <td style="height: 15px; padding: 0px; margin: 0px; width: 81px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 15px;">
                                            <asp:Literal ID="ltvalidy" runat="server"></asp:Literal>
                                        </p>
                                    </td>
                                    <td style="height: 15px; padding: 0px; margin: 0px; width: 84px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                    </td>
                                </tr>



                            </table>
                            <table cellpadding="0" cellspacing="0" style="  width: 793px;font: bold 12px 'Helvetica';border: 1px solid #BDBCBC;border-top: 0px;">
                                <asp:Repeater ID="rpproforma" runat="server">
                                    <HeaderTemplate>
                                        <tr>
                                            <td style="height: 16px; border-right: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 42px; vertical-align: bottom;">
                                                <p style="  text-align: center; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 15px;">Code</p>
                                            </td>
                                            <td style="height: 16px; border-right: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 289px; vertical-align: bottom;">
                                                <p style="  text-align: center; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 15px;">Description of Goods</p>
                                            </td>
                                            <td style="height: 16px; border-right: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 81px; vertical-align: bottom;">
                                                <p style="  text-align: center; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 15px;">Qty</p>
                                            </td>
                                            <td style="height: 16px; border-right: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 83px; vertical-align: bottom;">
                                                <p style="  text-align: center; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 15px;">Rate (INR)</p>
                                            </td>
                                            <td style="height: 16px; border-right: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 80px; vertical-align: bottom;">
                                                <p style="  text-align: center;text-align: left; padding-left: 27px; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 15px;">SKU</p>
                                            </td>
                                            <td style="height: 16px; border-right: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 81px; vertical-align: bottom;">
                                                <p style="  text-align: center;margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 15px;">VAT</p>
                                            </td>
                                            <td style="height: 16px; padding: 0px; margin: 0px; width: 83px; vertical-align: bottom;">
                                                <p style="  text-align: center; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 15px;">Amount</p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 13px; border-right: #BDBCBC 1px solid; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 42px; vertical-align: bottom;">
                                                <p style="  text-align: center; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 13px;">&nbsp;</p>
                                            </td>
                                            <td style="height: 13px; border-right: #BDBCBC 1px solid; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 289px; vertical-align: bottom;">
                                                <p style="  text-align: center; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 13px;">&nbsp;</p>
                                            </td>
                                            <td style="height: 13px; border-right: #BDBCBC 1px solid; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 81px; vertical-align: bottom;">
                                                <p style="  text-align: center; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 13px;">&nbsp;</p>
                                            </td>
                                            <td style="height: 13px; padding: 0px; margin: 0px; width: 82px; vertical-align: bottom; border-right: #BDBCBC 1px solid; border-bottom: #BDBCBC 1px solid;">
                                                <p style="  text-align: center; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 13px;">&nbsp;</p>
                                            </td>
                                            <td style="height: 13px; border-right: #BDBCBC 1px solid; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 80px; vertical-align: bottom;">
                                                <p style="  text-align: center; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 13px;">&nbsp;</p>
                                            </td>
                                            <td style="height: 13px; border-right: #BDBCBC 1px solid; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 81px; vertical-align: bottom;">
                                                <p style="  text-align: center; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 13px;">&nbsp;</p>
                                            </td>
                                            <td style="height: 13px; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 83px; vertical-align: bottom;">
                                                <p style="  text-align: center; padding-right: 2px; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 13px;">(INR)</p>
                                            </td>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td style="height: 16px; border-right: #BDBCBC 1px solid; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 42px; vertical-align: bottom;">
                                                <p style="  text-align: center; padding-right: 3px; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 15px;">
                                                    <asp:Literal ID="ltproductcode" runat="server" Text='<%#Eval("Product_Code")%>'></asp:Literal><asp:Literal ID="lblvat" runat="server" Text='<%#Eval("Product_Vat")%>' Visible="false" />
                                                </p>
                                            </td>
                                            <td style="height: 16px; border-right: #BDBCBC 1px solid; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 289px;">
                                                <p style="  text-align: center; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 1px;">
                                                    <asp:Literal ID="ltproductname" runat="server" Text='<%#Eval("Product_Name")%>'></asp:Literal>
                                                </p>
                                            </td>

                                            <td style="height: 16px; border-right: #BDBCBC 1px solid; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 81px; vertical-align: bottom;">
                                                <p style="  text-align: center; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 15px;">
                                                    <asp:Literal ID="ltquantity" runat="server" Text='<%#Eval("ItemDt_Qty")%>'></asp:Literal>
                                                </p>
                                            </td>
                                            <td style="height: 16px; border-right: #BDBCBC 1px solid; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 83px; vertical-align: bottom;">
                                                <p style="  text-align: center; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px'Helvetica'; line-height: 15px;">
                                                    <asp:Literal ID="ltrate" runat="server" Text='<%#Eval("ItemDt_Rate")%>'></asp:Literal>
                                                </p>
                                            </td>
                                            <td style="height: 16px; border-right: #BDBCBC 1px solid; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 80px; vertical-align: bottom;">
                                                <p style="  text-align: center; padding-left: 32px; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 15px;">
                                                    <asp:Literal ID="ltproductWeight" runat="server" Text='<%#Eval("Packing_Weight")%>' Visible="false"></asp:Literal><asp:Literal ID="ltpackingpacking" runat="server" Text='<%#Eval("Packing_Packing")%>'></asp:Literal>
                                                </p>
                                            </td>
                                            <td style="height: 16px; border-right: #BDBCBC 1px solid; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 81px; vertical-align: bottom;">
                                                <p style="text-align: center; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 15px;">
                                                    <asp:Literal ID="lblvatinrs" runat="server" Text='<%#Eval("Product_Vat")%>' /><asp:Literal ID="Literal1" runat="server" Text='<%#Eval("Product_Vat")%> ' Visible="false" />
                                                </p>
                                            </td>
                                            <td style="height: 16px; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 83px; vertical-align: bottom;">
                                                <p style="  text-align: center; padding-right: 4px; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 15px;">
                                                    <asp:Literal ID="ltamount" Text='<%#Eval("ItemDt_Amount")%>' runat="server"></asp:Literal>
                                                </p>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tr>
                                            <td style="height: 16px; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 43px; vertical-align: bottom;">
                                                <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                            </td>
                                            <td style="height: 16px; border-right: #BDBCBC 1px solid; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 288px; vertical-align: bottom;">
                                                <p style="text-align: right; padding-right: 3px; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 15px;">Total VAT</p>
                                            </td>
                                            <td style="height: 16px; border-right: #BDBCBC 1px solid; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 81px; vertical-align: bottom;">
                                                <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                            </td>
                                            <td style="height: 16px; border-right: #BDBCBC 1px solid; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 83px; vertical-align: bottom;">
                                                <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                            </td>
                                            <td style="height: 16px; border-right: #BDBCBC 1px solid; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 80px; vertical-align: bottom;">
                                                <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                            </td>
                                            <td style="height: 16px; border-right: #BDBCBC 1px solid; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 81px; vertical-align: bottom;">
                                                <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                            </td>
                                            <td style="height: 16px; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 83px; vertical-align: bottom;">
                                                <p style="text-align: right; padding-right: 4px; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 15px;">
                                                    <asp:Literal ID="ltvat" Text="36" runat="server"></asp:Literal>
                                                </p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 16px; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 43px; vertical-align: bottom;">
                                                <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                            </td>
                                            <td style="height: 16px; border-right: #BDBCBC 1px solid; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 288px; vertical-align: bottom;">
                                                <p style="text-align: right; padding-right: 3px; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 15px;">Total Amount</p>
                                            </td>
                                            <td style="height: 16px; border-right: #BDBCBC 1px solid; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 81px; vertical-align: bottom;">
                                                <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                            </td>
                                            <td style="height: 16px; border-right: #BDBCBC 1px solid; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 83px; vertical-align: bottom;">
                                                <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                            </td>
                                            <td style="height: 16px; border-right: #BDBCBC 1px solid; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 80px; vertical-align: bottom;">
                                                <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                            </td>
                                            <td style="height: 16px; border-right: #BDBCBC 1px solid; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 81px; vertical-align: bottom;">
                                                <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                            </td>
                                            <td style="height: 16px; border-bottom: #BDBCBC 1px solid; padding: 0px; margin: 0px; width: 83px; vertical-align: bottom;">
                                                <p style="text-align: right; padding-right: 4px; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 15px;">
                                                    <asp:Literal ID="lttotalamount" runat="server"></asp:Literal>
                                                </p>
                                            </td>
                                        </tr>



                                        <tr>
                                            <td style="height: 18px;  padding: 0px; margin: 0px; width: 43px; vertical-align: bottom;">
                                                <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                            </td>
                                            <td style="height: 18px;  padding: 0px; margin: 0px; width: 288px; vertical-align: bottom;">
                                                <p style="text-align: right; padding-right: 3px; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 13px 'Helvetica'; line-height: 16px;">Advance Payable</p>
                                            </td>
                                            <td style="height: 18px;  padding: 0px; margin: 0px; width: 81px; vertical-align: bottom;">
                                                <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                            </td>
                                            <td style="height: 18px;  padding: 0px; margin: 0px; width: 83px; vertical-align: bottom;">
                                                <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                            </td>
                                            <td style="height: 18px;  padding: 0px; margin: 0px; width: 80px; vertical-align: bottom;">
                                                <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                            </td>
                                            <td style="height: 18px;  padding: 0px; margin: 0px; width: 81px; vertical-align: bottom;">
                                                <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                            </td>
                                            <td style="height: 18px;  padding: 0px; margin: 0px; width: 83px; vertical-align: bottom;">
                                                <p style="text-align: right; padding-right: 4px; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 13px 'Helvetica'; line-height: 16px;">
                                                    <asp:Literal ID="ltadvance" runat="server"></asp:Literal>
                                                </p>
                                            </td>
                                        </tr>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </table>

                            <table cellpadding="0" cellspacing="0" style="width: 793px; font: bold 12px 'Helvetica';  border-top: 0px;">
                                <tr>
                                    <td style="height: 20px; padding: 0px; margin: 0px; width: 165px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 11px 'Helvetica'; line-height: 14px;">Company's PAN No.</p>
                                    </td>
                                    <td style="height: 20px; padding: 0px; margin: 0px; width: 226px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 11px 'Helvetica'; line-height: 14px;">: AARCS3831R</p>
                                    </td>
                                    <td style="height: 20px; padding: 0px; margin: 0px; width: 204px; vertical-align: bottom;">
                                        <p style="text-align: center; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: bold 12px 'Helvetica'; line-height: 15px;">For Swiss Bake Ingredients Pvt Ltd</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 45px; padding: 0px; margin: 0px; width: 165px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                    </td>
                                    <td style="height: 45px; padding: 0px; margin: 0px; width: 226px; vertical-align: bottom;">
                                        <p style="text-align: left; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 1px 'Helvetica'; line-height: 1px;">&nbsp;</p>
                                    </td>
                                    <td style="height: 45px; padding: 0px; margin: 0px; width: 204px; vertical-align: bottom;">
                                        <p style="text-align: center; padding-right: 1px; margin-top: 0px; margin-bottom: 0px; white-space: nowrap; font: 11px 'Helvetica'; line-height: 14px;">
                                            <asp:Literal ID="ltloginname" runat="server"></asp:Literal>
                                        </p>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="tr_footer">
                        <td colspan="4" style="">
                            <img src="http://crm.swissbake.co.in/img/CompanyImage/040515040511-Swissbake_Footer-800X100-px_4-10-14.png" style="width:793px;"/></td>
                       

                    </tr>

                </table>
            </asp:Panel></div>--%>

        </div>
    </div>
</asp:Content>

