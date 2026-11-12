<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="CityWiseReport.aspx.vb" Inherits="CityWiseReport" %>



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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header">
        <div class="header-section">
            <h2>
                <i class="gi gi-check"></i> City wise Report
            </h2>
        </div>
    </div>
    <ul class="breadcrumb breadcrumb-top">   
         <li><a href="Index.aspx">Home</a></li>    
        <li><a href="CityWiseReport.aspx" id="breadurl">City wise Report</a></li>
    </ul>
    <div class="block full">
        <div class="block-title">
            <h2><strong>City wise</strong> List</h2>
        </div>
        <div class="row">
            <div class="form-horizontal form-bordered">
                
                <div class="col-md-3">                   
                        <label class="col-md-2 control-label">From</label>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtfrom" runat="server" class="form-control" placeholder="Enter From Date" TextMode="Date" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfrom" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                ErrorMessage="Enter From date" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>                   
                </div>
                <div class="col-md-3">                    
                        <label class="col-md-2 control-label">To</label>
                        <div class="col-md-10">
                           <asp:TextBox ID="txtto" runat="server" class="form-control" placeholder="Enter To Date" TextMode="Date" />
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                ErrorMessage="Enter To date" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic"  ErrorMessage="Enter Valid date" CssClass="MasterValidationCSS" ControlToCompare="txtfrom" ControlToValidate="txtto" Operator ="GreaterThanEqual"   ValidationGroup="MasterGroup"></asp:CompareValidator>                                    
                        </div>                  
                </div> 
                <div class="col-md-3" runat ="server" id="divemp">
                    <label class="col-md-3 control-label">City</label>
                    <div class="col-md-9">
                        <asp:DropDownList ID="ddCity" runat="server" class="select-chosen"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="Select Employee" SetFocusOnError="true" runat="server" Display="Dynamic" ControlToValidate="ddCity"
                            ErrorMessage="Select City" CssClass="help-block" ValidationGroup="MasterGroup"></asp:RequiredFieldValidator>
                    </div>
                </div>              
                <div class="col-md-3">                    
                        <asp:Button ID="btndashboard" ValidationGroup="MasterGroup" runat="server" Text="Submit" CssClass="btn btn-sm btn-primary" />
                        <%-- <asp:ImageButton ID="btnExportExcel"  OnClientClick="tableToExcel('example-datatable', 'W3C Example Table')" data-toggle="tooltip" title="Export Excel" Style="margin-right: 10px" Width="33px" ImageAlign="Right" runat="server" ImageUrl="~/img/excel.gif" />--%>
                        <%--<input type="button" onclick="tableToExcel('example-datatable', 'W3C Example Table')" class="btn btn-sm btn-success" value="Export to Excel" />--%>
                        <asp:Button ID="btnExport" runat="server" CssClass="btn btn-alt btn-sm btn-success" CausesValidation="false" Text="Export to Excel"  />
                    </div>               
            </div>   
        </div>
        <br />
        <div class="row" id="divsumary" runat="server" >
               <%-- <div class="col-sm-6 col-lg-4">
                    <div class="widget">
                        <div class="widget-extra themed-background-dark-default text-center">
                            <h3 class="widget-content-light animation-hatch">
                                <i class="fa fa-inr"></i><strong>
                                    <asp:Label ID="ltsalpaid" runat="server"></asp:Label></strong>
                                <br>
                                <a href="#.aspx"><small>Paid Amount</small></a>
                            </h3>
                        </div>
                    </div>
                </div>--%>
            <div class="col-md-12">
                <div class="col-sm-6">
                    <div class="widget">
                        <div class="widget-extra themed-background-fire text-center">
                            <h3 class="widget-content-light animation-hatch">
                                <i class="fa fa-inr"></i><strong>
                                    <asp:Label ID="lblamt" runat="server"></asp:Label></strong>
                                <br>
                                <a href="#.aspx"><small>Total Amount</small></a>
                            </h3>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="widget">
                        <div class="widget-extra themed-background-autumn  text-center">
                            <h3 class="widget-content-light animation-hatch">
                                <strong>
                                    <asp:Label ID="lblqty" runat="server"></asp:Label> KG</strong><br>
                                <a href="#.aspx"><small>Total Quantity</small></a>
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
                             <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 60px">Sr No.</th>                          
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Order No</th>                          
                            <th class="text-center mydate" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Employee Name</th>                          
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Product Name</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Quantity(KG)</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Amount</th>                       
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpgridview" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center" style="width: 60px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("RowNumber"))%></td>  
                                     <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Order_Code"))%></td>  
                                     <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("U_FirstName"))%></td>  
                                     <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Product_Name"))%></td>  
                                     <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Quantity"))%>&nbsp;KG
                                         <asp:literal ID="ltqty" runat="server" Visible ="false" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Quantity"))%>'></asp:literal>
                                     </td>                                    
                                     <td class="text-center" style="width: 100px"><i class ="fa fa-inr "/>&nbsp;<%#Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(Eval("OrDetail_Amount"))).ToString("#,##0.00")%>
                                          <asp:literal ID="ltamount" runat="server" Visible ="false"  Text='<%#Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(Eval("OrDetail_Amount"))).ToString("#,##0.00")%>'></asp:literal>
                                     </td>
                                </tr>
                            </ItemTemplate>

                                    <FooterTemplate>
                                        <tr style="font-size: 16px; font: bold;" id="trFooter" runat="server">
                                            <td colspan="4" class="text-center" style="width: 100px" >Total</td>
                                            <td class="text-center" style="width: 100px"><asp:Label ID="quantityTotal" runat="server" />&nbsp;<i class="fa">KG</i></td>
                                            <td class="text-center" style="width: 100px"><i class ="fa fa-inr "/>&nbsp;<asp:Label ID="amountTotal" runat="server" /></td>

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





