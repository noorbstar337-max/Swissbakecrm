<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="TopProduct.aspx.vb" Inherits="TopProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .table-responsive {
            overflow-x: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hfBackcount" runat="server" />
    <asp:HiddenField ID="hfExcelmode" runat="server" />
    <div class="content-header">
        <div class="header-section">
            <h1>
                <i class="gi gi-parents" style="margin: -8px"></i>Top Product<br>
            </h1>
        </div>
    </div>
    <ul class="breadcrumb breadcrumb-top">
        <li><a href="index.aspx">Home</a></li>
        <li>Top Product Report</li>
    </ul>
        <div class="row" >				
			<div class="col-sm-6 col-lg-3"  runat="server" id="div1">
                <!-- Widget -->
                 <a href="#" class="widget widget-hover-effect1">
                <div class="widget">                
                    <div class="widget-extra themed-background-dark text-center" style="color:#B31616;">
                        <h3 class="widget-content-light">
                            <small><asp:Literal runat="server" ID="litlead"></asp:Literal> </small><br/><br/>                            
                               <asp:Label runat="server" ID="lblleadtotal"></asp:Label>                              
                        </h3>
                    </div>
                </div>
                     </a>
                <!-- END Widget -->
            </div>	
						<div class="col-sm-6 col-lg-3"  runat="server" id="div2">
                <!-- Widget -->
                 <a href="#" class="widget widget-hover-effect1">
                <div class="widget">                
                    <div class="widget-extra themed-background-dark-amethyst text-center" style="color:#B31616;">
                        <h3 class="widget-content-light">
                            <small><asp:Literal runat="server" ID="litoalquanty"></asp:Literal> </small><br/><br/>                            
                               <asp:Label runat="server" ID="lbltoalquanty"></asp:Label> kg <%--(&#x20B9; <asp:Label runat="server" ID="Label2"></asp:Label>) --%>                               
                        </h3>
                    </div>
                </div>
                     </a>
                <!-- END Widget -->
            </div>
							<div class="col-sm-6 col-lg-3"  runat="server" id="div3">
                <!-- Widget -->
                 <a href="#" class="widget widget-hover-effect1">
                <div class="widget">                
                    <div class="widget-extra themed-background-autumn text-center" style="color:#B31616;">
                        <h3 class="widget-content-light">
                            <small><asp:Literal runat="server" ID="litotalamount"></asp:Literal> </small><br/><br/>                            
                               &#x20B9; <asp:Label runat="server" ID="lbltotalamount"></asp:Label>                               
                        </h3>
                    </div>
                </div>
                     </a>
                <!-- END Widget -->
            </div>
									<div class="col-sm-6 col-lg-3"  runat="server" id="div4">
                <!-- Widget -->
                 <a href="#" class="widget widget-hover-effect1">
                <div class="widget">                
                    <div class="widget-extra themed-background-dark-fire text-center" style="color:#B31616;">
                        <h3 class="widget-content-light">
                            <small><asp:Literal runat="server" ID="liaverage"></asp:Literal> </small><br/><br/>                            
                               &#x20B9; <asp:Label runat="server" ID="lblaverage"></asp:Label>                               
                        </h3>
                    </div>
                </div>
                     </a>
                <!-- END Widget -->
            </div>
</div>
    <div class="block">
        <div class="block-title">
            <h2><strong>Top Product</strong></h2>
        </div>
        <div class="row">
            <div class="form-horizontal form-bordered">
                <div class="col-md-12">
                    <div class="col-md-9">
                        <div class="col-md-4">
                            <label class="col-md-3 control-label">Start Date</label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtfrom" runat="server" class="form-control" placeholder="Enter From Date" TextMode="Date" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfrom" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Enter From date" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <label class="col-md-3 control-label">End Date</label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtto" runat="server" class="form-control" placeholder="Enter To Date" TextMode="Date" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Enter To date" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ErrorMessage="Enter Valid date" CssClass="MasterValidationCSS" ControlToCompare="txtfrom" ControlToValidate="txtto" Operator="GreaterThanEqual" ValidationGroup="MasterGroup"></asp:CompareValidator>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <label class="col-md-3 control-label">Product</label>
                            <div class="col-md-9">
                                <asp:DropDownList ID="ddlProduct" runat="server" class="select-chosen form-control" >
									</asp:DropDownList>
                                <asp:TextBox ID="txtSearch" runat="server" Visible="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-3 pull-right">
                        <asp:ImageButton ID="btnExportExcel" class="pull-right" OnClientClick="tableToExcel('example-datatable', 'W3C Example Table')" data-toggle="tooltip" title="Export Excel" Style="margin-right: 50px" Width="33px" ImageAlign="Right" runat="server" ImageUrl="~/img/excel.gif" />
                        <%--<asp:LinkButton Text="Show All" runat="server" Style="margin-right: 15px;" ID="btnshowall" class="btn btn-alt btn-sm btn-primary pull-right"><i class="gi gi-refresh"></i>  Show All</asp:LinkButton>--%>
                        <%--<asp:LinkButton Text="Report" runat="server" Style="margin-right: 15px;" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Reporting...';"
                            UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary pull-right" ValidationGroup="MasterGroup"><i class="fa fa-line-chart"></i>  Report</asp:LinkButton>--%>
                        <asp:Button ID="btnadd" ValidationGroup="MasterGroup" runat="server" Text="Submit" CssClass="btn btn-sm btn-primary pull-right" Style="margin-right: 15px;"/>
                        <%--<asp:Button ID="btndashboard" ValidationGroup="MasterGroup" runat="server" Text="Submit" CssClass="btn btn-sm btn-primary" />--%>
                        <%--<input type="button" onclick="tableToExcel('example-datatable', 'W3C Example Table')" class="btn btn-sm btn-success" value="Export to Excel" />--%>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <div class="block" id="tblGrid" runat="server">
        <%--<div class="table-responsive" id="tblGrid">--%>
        <div class="table-responsive" >
            <%--<div id="tblGrid">--%>
            <asp:UpdatePanel runat="server" ID="rpg">
                <ContentTemplate>
                    <asp:Panel ID="pnldemo" runat="server">


                        <table class="table table-vcenter table-condensed table-bordered">
                            <%--<table id="example-datatable" class=" MultiDatatable table table-vcenter table-condensed table-bordered">--%>
                            <thead runat="server" id="repHeader">
                                <tr>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 60px">Sr No.</th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Product Name</th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Product Code</th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Total Qty</th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Product Rate</th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Category Name</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rpgridview" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center" style="width: 60px"><%#Eval("RowNumber")%></td>
                                            <td class="text-center" style="width: 100px; display: none;"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Product_Id"))%></td>
                                            <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Product_Name"))%></td>
                                            <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Product_Code"))%></td>
                                            <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Totalqty")).ToString + " KG"%></td>
                                            <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Rate"))%></td>
                                            <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Category"))%></td>
                                        </tr>
                                    </ItemTemplate>

                                    <FooterTemplate>
                                        <tr id="lblNoRecord" runat="server">
                                            <td colspan="3" style="width: 100px; text-align:center;">
                                                <asp:Label runat="server" ID="lblNoData" Style="font-size: 15px; text-align: center;"><strong>Total</strong></asp:Label>
                                            </td>
                                            <td colspan="1" style="width: 100px; text-align:center;" >
                                                <asp:Label runat="server" ID="lblFProdTotalqty" Style="font-size: 15px; text-align: center;"></asp:Label>&nbsp;Kg
                                            </td>
                                             <td colspan="1" style="width: 100px; text-align:center;">
                                                ₹&nbsp;<asp:Label runat="server" ID="lblFProdRate" Style="font-size: 15px; text-align: center;"></asp:Label>
                                            </td>
                                             <td colspan="1" style="width: 100px; text-align:center;">
                                            </td>
                                        </tr>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>



                            </tbody>
                            <tfoot>
                            </tfoot>

                        </table>
                        <asp:Label ID="lblfoot" Text="No records found" Visible="false" runat="server"></asp:Label>
                    </asp:Panel>
                </ContentTemplate>
                <Triggers>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>

