<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ProductsReport.aspx.vb" Inherits="ProductsReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script type="text/javascript">
        var tableToExcel = (function () {
            var uri = 'data:application/vnd.ms-excel;base64,'
                , template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table border="1px"><tr bgcolor="#394263">{table}</table></body></html>'
                , base64 = function (s) { return window.btoa(unescape(encodeURIComponent(s))) }
                , format = function (s, c) { return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; }) }
            return function (table, name) {
                if (!table.nodeType) table = document.getElementById(table)
                table: table.innerHTML.replace(/<\s*img[^>]*>/gi, '');
                var ctx = { worksheet: name || 'Worksheet', table: table.innerHTML, }
                window.location.href = uri + base64(format(template, ctx))
            }
        })()
    </script>
    <script type="text/javascript">
        function fnExcelReport() {
            var tab_text = "<table border='2px'><tr bgcolor='#394263'>";
            var textRange; var j = 0;
            tab = document.getElementById('example-datatable'); // id of table

            for (j = 0 ; j < tab.rows.length ; j++) {
                tab_text = tab_text + tab.rows[j].innerHTML + "</tr>";
                //tab_text=tab_text+"</tr>";
            }

            tab_text = tab_text + "</table>";
            tab_text = tab_text.replace(/<A[^>]*>|<\/A>/g, "");//remove if u want links in your table
            tab_text = tab_text.replace(/<img[^>]*>/gi, ""); // remove if u want images in your table
            tab_text = tab_text.replace(/<input[^>]*>|<\/input>/gi, ""); // reomves input params

            var ua = window.navigator.userAgent;
            var msie = ua.indexOf("MSIE ");

            if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))      // If Internet Explorer
            {
                txtArea1.document.open("txt/html", "replace");
                txtArea1.document.write(tab_text);
                txtArea1.document.close();
                txtArea1.focus();
                sa = txtArea1.document.execCommand("SaveAs", true, "Say Thanks to Sumit.xls");
            }
            else                 //other browser not tested on IE 11
                sa = window.open('data:application/vnd.ms-excel,' + encodeURIComponent(tab_text));

            return (sa);
        }
    </script>
    <style>
td.ex1:hover, a.ex1:active {color: red;}
Literal.ex2:hover, a.ex2:active {color: red;}
/*a.ex3:hover, a.ex3:active {background: red;}
a.ex4:hover, a.ex4:active {font-family: monospace;}
a.ex5:visited, a.ex5:link {text-decoration: none;}
a.ex5:hover, a.ex5:active {text-decoration: underline;}*/
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-header">
        <div class="header-section">
            <h2>
                <i class="gi gi-check"></i> Products Report
            </h2>
        </div>
    </div>
    <ul class="breadcrumb breadcrumb-top">   
         <li><a href="Index.aspx">Home</a></li>    
        <li><a href="ProductsReport.aspx" id="breadurl">Products Report</a></li>
    </ul>
    <div class="block full">
        <div class="block-title">
            <h2><strong>Products</strong> List</h2>
        </div>
        <div class="row">
            <div class="form-horizontal form-bordered">
				<div class="col-md-12">
					<br /><br />
				</div>
                <div class="col-md-4">
                            <label class="col-md-5 control-label">Product Type</label>
                            <div class="col-md-7">
                                <asp:DropDownList ID="ddlProdType" runat="server" class="form-control select-chosen" AutoPostBack="true">
                                    <asp:ListItem Value="Domestic" Text="Domestic"></asp:ListItem>
                                    <asp:ListItem Value="Export" Text="Export"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                 </div>
               <%-- <div class="col-md-4">                   
                        <label class="col-md-1 control-label">From</label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtfrom" runat="server"  class="form-control" placeholder="Enter From Date" TextMode="Date" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfrom" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                ErrorMessage="Enter From date" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>    
                        <label class="col-md-1 control-label">To</label>
                        <div class="col-md-5">
                           <asp:TextBox ID="txtto" runat="server"  class="form-control" placeholder="Enter To Date" TextMode="Date" />
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                ErrorMessage="Enter To date" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic"  ErrorMessage="Enter Valid date" CssClass="MasterValidationCSS" ControlToCompare="txtfrom" ControlToValidate="txtto" Operator ="GreaterThanEqual"   ValidationGroup="MasterGroup"></asp:CompareValidator>                                    
                        </div>                  
                </div>-- %>
               <% -- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="col-md-3">
                            <label class="col-md-3 control-label">Category</label>
                            <div class="col-md-9">
                                <asp:DropDownList ID="ddCategory" runat="server" class="form-control select-chosen" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-md-3" runat="server" id="divemp">
                            <label class="col-md-3 control-label" runat="server" id="lblProd" visible="false"></label>
                            <div class="col-md-9">
                                <asp:DropDownList ID="ddProduct" runat="server" Visible="false" class="form-control select-chosen" Width="200px">
                                </asp:DropDownList>
                             </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>--%>
                <div class="col-md-2 pull-right">
                        <%--<asp:Button ID="btndashboard" ValidationGroup="MasterGroup" runat="server" TabIndex="4" Text="Submit" CssClass="btn btn-sm btn-primary" />--%>
                        <%-- <asp:ImageButton ID="btnExportExcel"  OnClientClick="tableToExcel('example-datatable', 'W3C Example Table')" data-toggle="tooltip" title="Export Excel" Style="margin-right: 10px" Width="33px" ImageAlign="Right" runat="server" ImageUrl="~/img/excel.gif" />--%>
                        <%--<input type="button" runat="server" visible="false" onclick="tableToExcel('example-datatable', 'W3C Example Table')" class="btn btn-sm btn-success" value="Export to Excel" />--%>
                        <asp:Button ID="btnExport" Visible="false" runat="server" CssClass="btn btn-alt btn-sm btn-success" CausesValidation="false" Text="Export to Excel"  />
                </div>               
            </div>   
        </div>
        <br />
        <div class="row" id="divsumary" runat="server" >               
            <div class="col-md-12" style="display:none;">
                <div class="col-sm-4">
                    <div class="widget">
                        <div class="widget-extra themed-background-fire  text-center">
                            <h3 class="widget-content-light animation-hatch">
                                <strong>
                                    <asp:Label ID="lblqty" runat="server"></asp:Label> KG</strong><br>
                                <a href="#.aspx"><small>Total Quantity</small></a>
                            </h3>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="widget">
                        <div class="widget-extra themed-background-autumn text-center">
                            <h3 class="widget-content-light animation-hatch">
                                <i class="fa fa-inr"></i><strong>
                                    <asp:Label ID="lblamt" runat="server"></asp:Label></strong>
                                <br>
                                <a href="#.aspx"><small>Total Sales</small></a>
                            </h3>
                        </div>
                    </div>
                </div>
                
                 <div class="col-sm-4">
                    <div class="widget">
                        <div class="widget-extra themed-background-fire  text-center">
                            <h3 class="widget-content-light animation-hatch">
                                <strong>
                                 <i class="fa fa-inr"></i>  <asp:Label ID="lblProfit" runat="server"></asp:Label> </strong> <br>
                                <a href="#.aspx"><small>Total Profit/Loss </small></a>
                            </h3>
                        </div>
                    </div>
                </div>
            </div>
            </div>
        <div class="table-responsive">
            <asp:Panel ID="pnldemo" runat="server">
               
                
                <table id="example-datatable" class=" MultiDatatable table table-vcenter table-condensed table-bordered">
                    <thead>
                        <tr>
                            <th class="text-center" style="display: none">Product ID</th>  
                             <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 10px">Sr No.</th>  
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Product Name</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Product Rate&nbsp;</th> 
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Minimum Price&nbsp;</th> 
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Maximum Price&nbsp;</th>   
                            <%--<th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Min Selling Price</th>--%>   
                            <%--<th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Selling Price</th>--%>
                            <%--<th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Quantity(KG)</th>--%> 
                            <%--<th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Profit/Loss&nbsp;(<i class ="fa fa-inr "/>)</th>--%> 
                            <%--<th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Total Sales&nbsp;(<i class ="fa fa-inr "/>)</th>--%>                        
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpProdRep" runat="server">
                            <ItemTemplate>
                                <tr>
                                    
                                    <td class="text-center" style="width: 100px; display: none;"><asp:Label id="ltProduct_Id" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Product_Id"))%>' ></asp:Label></td> 
                                    <td class="text-center" style="width: 10px;"><asp:Label id="Label1" runat="server" Text='<%#Eval("RowNumber")%>' ></asp:Label></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Product_Name"))%></td> 
                                    <td class="text-center" style="width: 100px"><i class ="fa fa-inr "/> <%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Product_Rate"))%></td> 
                                    <td  class="text-center" style="width: 100px">
                                       <i class ="fa fa-inr "/> <a runat="server" ID="lnkMinP" href='<%# "ProductWisePriceList.aspx?ord=a&Id=" + (DynamicparcelDataManipulation.FixNullFromDB(Security.Encrypt(Eval("Product_id")))).ToString() + "&Type=" + ddlProdType.SelectedValue.ToString %>'  Target="_blank">
                                            <%-- NavigateUrl='<%# "ProductWisePriceList.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Product_Id").ToString())) + "&Type=" + HttpUtility.UrlEncode(Security.Encrypt(Session("ProductType").ToString()))%>' --%>
                                            <asp:Literal ID="ltMin" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Min_Price"))%>' EnableViewState="false" />
                                        </a>
                                    </td> 
                                    <%--<td class="ex1 text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Min_Price"))%></td>--%> 
                                    <td class="text-center" style="width: 100px" >
                                       <i class ="fa fa-inr "/> <a ID="lnkMaxP" href='<%# "ProductWisePriceList.aspx?ord=d&Id=" + (DynamicparcelDataManipulation.FixNullFromDB(Security.Encrypt(Eval("Product_id")))).ToString() + "&Type=" + ddlProdType.SelectedValue.ToString %>'  Target="_blank" title="View"  >
                                             <%-- NavigateUrl='<%# "ProductWisePriceList.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Product_Id").ToString()))%>' --%>
                                            <asp:Literal ID="ltMax" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Max_Price"))%>' EnableViewState="false" />
                                        </a>
                                    </td>  
                                    <%--<td class="text-center" style="width: 100px" ><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Max_Price"))%></td>--%>
                                      
                                    <%--<td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Convert.ToDouble(Eval("MinSP")).ToString("N2"))%></td>--%>  
                                    <%--<td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("OrDetail_Rate"))%></td>--%>                                   
                                    <%--<td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("OrDetail_Qty"))%></td>--%>
                                    <%--<td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Convert.ToDouble(Eval("Profit")).ToString("N2"))%></td>--%>
                                    <%--<td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Convert.ToDouble(Eval("TotalSales")).ToString("N2"))%></td>--%>
                                </tr>
                            </ItemTemplate>

					         <FooterTemplate>
								<tr style="font-size: 16px; font: bold; display: none;">
									<td class="text-center" style="width: 100px;" colspan="2">Total</td>
									<td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lblprodrate" runat="server" /></td>
									<td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lblminprice" runat="server" /></td>
									<td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lblmaxprice" runat="server" /></td>
								</tr>
								</table>
							</FooterTemplate> 
                        </asp:Repeater>
                      
                                
                            
                    </tbody>
                    <tfoot>
                        
                        </tfoot> 
                   <%-- <tfoot>
                        <tr>
                            <th class="text-center">Order ID</th>                           
                            <th class="text-center">Emplyoee Name</th>                          
                            <th class="text-center">Product Name</th>
                            <th class="text-center">Quantity(KG)</th>
                            <th class="text-center">Amount</th>
                        </tr>
                    </tfoot>--%>
                </table>
                <asp:Label ID="lblfoot" Text="No records found" Visible="false"  runat="server" ></asp:Label>
            </asp:Panel>
        </div>
    </div>
</asp:Content>

