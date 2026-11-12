<%@ Page Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="DSRReport.aspx.vb" Inherits="DSRReport" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hfExcelmode" runat="server" />
    <div class="content-header">
        <div class="header-section">
            <h1>
                <i class="hi hi-tasks" style="margin: -8px"></i>DSR Report<br>
            </h1>
        </div>
    </div>
    <ul class="breadcrumb breadcrumb-top">
        <li><a href="index.aspx">Home</a></li>
        <li>DSR Report</li>
    </ul>
    <div class="row">
        <asp:Repeater runat="server" ID="rrtotal">
            <ItemTemplate>
                <div class="col-sm-6 col-lg-3">
                    <!-- Widget -->
                    <a href="#" class="widget widget-hover-effect1">
                        <div class="widget-simple">
                            <div class="widget-icon pull-left themed-background-fire animation-fadeIn">
                                <asp:Literal ID="ltTotalLeads" runat="server" Text='<%#Eval("id")%>'></asp:Literal>
                            </div>
                            <p style="min-height: 60px;">
                                <asp:Repeater runat="server" ID="rrtotalin">
                                    <ItemTemplate>
                                        <small>
                                            <asp:Literal ID="Literal1" runat="server" Text='<%#Eval("Activity_Subject")%>'></asp:Literal>
                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Literal ID="Literal2" runat="server" Text='<%#Eval("Duration")%>'></asp:Literal>
                                            <br />
                                        </small>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </p>
                            <h3 class="widget-content text-right animation-pullDown"><strong>
                                <asp:Literal ID="litname" runat="server" Text='<%#Eval("U_FirstName")%>'></asp:Literal></strong><%--<br>--%>
                                <small><%#Eval("Duration")%></small>
                            </h3>
                        </div>
                    </a>
                    <!-- END Widget -->
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="block">
        <div class="block-title">
            <h2><strong>DSR Report</strong> Detail</h2>
        </div>
        <div class="row">
            <div class="form-horizontal form-bordered">

                <div class="col-md-12">
                        <div class="col-md-3">
                            <label class="col-md-2 control-label">From</label>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtfrom" runat="server" TabIndex="2" class="form-control" placeholder="Enter From Date" TextMode="Date" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfrom" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Enter From date" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <label class="col-md-2 control-label">To</label>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtto" runat="server" TabIndex="3" class="form-control" placeholder="Enter To Date" TextMode="Date" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Enter To date" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ErrorMessage="Enter Valid date" CssClass="MasterValidationCSS" ControlToCompare="txtfrom" ControlToValidate="txtto" Operator="GreaterThanEqual" ValidationGroup="MasterGroup"></asp:CompareValidator>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <label class="col-md-3 control-label">User</label>
                            <div class="col-md-9">
                                <asp:DropDownList ID="ddlUser" runat="server" AutoPostBack="true" TabIndex="4" class="select-chosen">
                                </asp:DropDownList>

                            </div>
                        </div>
                        <div class="col-md-3">
                            <label class="col-md-3 control-label">Company</label>
                            <div class="col-md-9">
                                <asp:DropDownList ID="ddlCompany" runat="server" AutoPostBack="true" TabIndex="5" class="select-chosen">
                                </asp:DropDownList>

                            </div>
                        </div>
                </div>
                 <div style="clear: both"></div>
                <br />
                <div class="col-md-12">
                    <div class="col-md-2 pull-right" style="margin-right:20px;">
                        <asp:Button ID="btndashboard" ValidationGroup="MasterGroup" runat="server" TabIndex="6" Text="Submit" CssClass="btn btn-sm btn-primary" />
                        <%--     <asp:ImageButton ID="btnExportExcel" OnClientClick="tableToExcel('example-datatable', 'W3C Example Table')" data-toggle="tooltip" title="Export Excel" Style="margin-right: 10px" Width="33px" ImageAlign="Right" runat="server" ImageUrl="~/img/excel.gif" />--%>
                        <%--<input type="button" onclick="tableToExcel('example-datatable', 'W3C Example Table')" class="btn btn-sm btn-success" value="Export to Excel" />--%>
                        <asp:Button ID="btnExport" runat="server" CssClass="btn btn-alt btn-sm btn-success" CausesValidation="false" Text="Export to Excel" />
                    </div>
                </div>


            </div>
        </div>

        <br />

        <div class="row" id="divsumary" runat="server" style="display: none;">

            <div class="col-md-12">
                <div class="col-sm-1">
                </div>
                <div class="col-sm-10">
                    <div class="widget">
                        <div class="widget-extra themed-background-fire text-center">
                            <h3 class="widget-content-light animation-hatch">
                                <strong>
                                    <asp:Label ID="lblamt" runat="server"></asp:Label></strong>
                                <br>
                                <a href="#.aspx"><small>Total Account</small></a>
                            </h3>
                        </div>
                    </div>
                </div>
                <div class="col-sm-1">
                </div>
            </div>
        </div>

        <div class="table-responsive" id="tblGrid" runat="server">
            <asp:Panel ID="pnldemo" runat="server">


                <table id="example-datatable" class=" MultiDatatable table table-vcenter table-condensed table-bordered">
                    <thead>
                        <tr>

                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 60px">Sr No.</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Date</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">City</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Type</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Name</th>

                            <th class="text-center mydate" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Subject</th>
                            <%--<th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Priority</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Status</th>--%>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Description</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Time</th>
                            <%--    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Start time</th>  
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">End Time</th>  --%>
                            <th id="tdOwner" runat="server" class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Owner</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpgridview" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center" style="width: 60px"><%#Eval("RowNumber")%></td>
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.DateFormatfirstdate(Eval("From"))%></td>
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("City"))%></td>
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Related Type"))%></td>
                                    <%--  <td class="text-center" style="width: 100px"> <asp:HyperLink ID="HyperLink1" Target="_blank" NavigateUrl='<%# DynamicparcelDataManipulation.FixNullFromDB(Eval("href")) + HttpUtility.UrlEncode(Security.Encrypt(Eval("Activity_Id").ToString()))%>' title="View" runat="server">
                                            <asp:Literal ID="lblcontact" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_Name"))%>' />
                                        </asp:HyperLink></td>  --%>
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Name"))%></td>
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Subject"))%></td>
                                    <%--<td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Priority"))%></td>  
                                     <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Status"))%>
                                         <asp:literal ID="ltqty" runat="server" Visible ="false" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Status"))%>'></asp:literal>
                                     </td>   --%>
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Activity_Description"))%></td>
                                    <%--<td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.TimeFormatAmPm(Eval("Time"))%></td>--%>
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.TimeFormatAmPm(Eval("From"))%>-<%#DynamicparcelDataManipulation.TimeFormatAmPm(Eval("To"))%>(<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Duration"))%> hrs)</td>
                                    <%--<td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.TimeFormatAmPm(Eval("To"))%></td>--%>
                                    <td id="tdOwner1" runat="server" class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("AssignTo"))%></td>
                                </tr>
                            </ItemTemplate>

                            <%--<FooterTemplate>
                                <tr>
                                    <td colspan="3" class="text-right" style="width: 100px">Total</td>
                                    <td class="text-center" style="width: 100px">
                                        <asp:Label ID="quantityTotal" runat="server" /></td>
                                    <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="amountTotal" runat="server" /></td>
                                </tr>
                                </table>
                            </FooterTemplate>--%>
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
                <asp:Label ID="lblfoot" Text="No records found" Visible="false" runat="server"></asp:Label>
            </asp:Panel>
        </div>



    </div>

</asp:Content>

