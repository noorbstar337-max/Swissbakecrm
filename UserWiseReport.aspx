<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="UserWiseReport.aspx.vb" Inherits="UserWiseReport" %>


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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-header">
        <div class="header-section">
            <h2>
                <i class="gi gi-check"></i> User wise Report
            </h2>
        </div>
    </div>
    <ul class="breadcrumb breadcrumb-top">   
         <li><a href="Index.aspx">Home</a></li>    
        <li><a href="ProductWiseReport.aspx" id="breadurl">User wise Report</a></li>
    </ul>
    <div class="block full">
        <div class="block-title">
            <h2><strong>User wise</strong> List</h2>
        </div>
        <div class="row">
            <div class="form-horizontal form-bordered">
                <div class="col-md-12">
                    <div class="col-md-5">
                        <label class="col-md-1 control-label">From</label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtfrom" runat="server" class="form-control" placeholder="Enter From Date" TextMode="Date" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfrom" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                ErrorMessage="Enter From date" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-1 control-label">To</label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtto" runat="server" class="form-control" placeholder="Enter To Date" TextMode="Date" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                ErrorMessage="Enter To date" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ErrorMessage="Enter Valid date" CssClass="MasterValidationCSS" ControlToCompare="txtfrom" ControlToValidate="txtto" Operator="GreaterThanEqual" ValidationGroup="MasterGroup"></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="col-md-5">
                        <label class="col-md-4 control-label">User <span class="text-danger">*</span></label>
                        <div class="col-md-8">
                        <asp:DropDownList ID="ddluser" runat="server" data-toggle="tooltip" title="User" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="remembername" runat="server" ControlToValidate="ddluser" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                            ErrorMessage="Please select user name" SetFocusOnError="true" InitialValue="0"></asp:RequiredFieldValidator>
                    </div>
                         </div>
                    <div class="col-md-2">
                        <asp:Button ID="btndashboard" ValidationGroup="MasterGroup" runat="server" TabIndex="4" Text="Submit" CssClass="btn btn-sm btn-primary" />
                        <%--<asp:ImageButton ID="btnExportExcel"  OnClientClick="tableToExcel('example-datatable', 'W3C Example Table')" data-toggle="tooltip" title="Export Excel" Style="margin-right: 10px" Width="33px" ImageAlign="Right" runat="server" ImageUrl="~/img/excel.gif" />--%>
                        <%--<input type="button" onclick="tableToExcel('example-datatable', 'W3C Example Table')" class="btn btn-sm btn-success" value="Export to Excel" />--%>
                        <asp:Button ID="btnExport" runat="server" CssClass="btn btn-alt btn-sm btn-success" CausesValidation="false" Text="Export to Excel"  />
                    </div>
                </div>
            </div>   
        </div>
        <br />
        <div class="row" id="divsumary" runat="server" >               
            <div class="col-md-12">
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
                <table id="example-datatable" class=" MultiDatatable table table-vcenter table-condensed table-bordered">
                    <thead>
                        <tr>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Sr No.</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Product Name</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">MRP</th> 
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Cost Price</th> 
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Margin</th>   
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Min Selling Price</th>   
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Selling Price</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Quantity(KG)</th> 
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Profit/Loss&nbsp;(<i class ="fa fa-inr "/>)</th> 
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Total Sales&nbsp;(<i class ="fa fa-inr "/>)</th>                        
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpgridview" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("RowNumber"))%></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Product_Name"))%></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Product_Rate"))%></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("OrDetail_ProductCost"))%></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Product_Margin"))%></td>  
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Convert.ToDouble(Eval("MinSP")).ToString("N2"))%></td>  
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("OrDetail_Rate"))%></td>                                   
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("OrDetail_Qty"))%></td>
                                      <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Convert.ToDouble(Eval("Profit")).ToString("N2"))%></td>
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Convert.ToDouble(Eval("TotalSales")).ToString("N2"))%></td>
                                </tr>
                            </ItemTemplate>

                         <FooterTemplate>
                                <tr style="font-size: 16px; font: bold;" id="trFooter" runat="server">
                                    <td class="text-center" style="width: 100px;" colspan="2">Total</td>
                                    
                                    <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lblmrp" runat="server" /></td>
                                    <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lblcostprice" runat="server" /></td>
                                    <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lblmargin" runat="server" /></td>
                                    <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lblminselprice" runat="server" /></td>
                                    <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lblselprice" runat="server" /></td>
                                    <td class="text-center" style="width: 100px">&nbsp;<asp:Label ID="lblqty" runat="server" />&nbsp;<i class="fa">KG</td>
                                    <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lblprofit" runat="server" /></td>
                                    <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lbltotal" runat="server" /></td>

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
          
        </div>
    </div>
</asp:Content>


