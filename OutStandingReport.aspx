<%@ Page Language="VB"  MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="OutstandingReport.aspx.vb" Inherits="OutstandingReport" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">--%>

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
     <asp:HiddenField ID="hfExcelmode" runat="server" />
     <div class="content-header">
        <div class="header-section">
            <h1>
                <i class="hi hi-tasks" style="margin: -8px"></i>Outstanding Report<br>
            </h1>
        </div>
    </div>
    <ul class="breadcrumb breadcrumb-top">
        <li><a href="index.aspx">Home</a></li>
        <li>Outstanding Report</li>
    </ul>
    <div class="block">
        <div class="block-title">
            <h2><strong>Outstanding Report</strong> Detail</h2>
        </div>
        <div class="row">
            <div class="form-horizontal form-bordered">
             
                <div class="col-md-12"> 
					  <div class="col-md-3">
                        <label class="col-md-3 control-label">User</label>
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddlUser" runat="server" AutoPostBack="true" TabIndex="4" class="select-chosen">
                              </asp:DropDownList>
                        </div>
                    </div>
					<asp:UpdatePanel runat="server">
						<ContentTemplate>
							<div class="col-md-3">
								<label class="col-md-3 control-label">Company</label>
								<div class="col-md-9">
									<asp:DropDownList ID="ddlCompany" runat="server"  TabIndex="5" class="select-chosen">
									</asp:DropDownList>
								</div>
							</div>
						</ContentTemplate>
						<Triggers>
							<asp:PostBackTrigger ControlID="ddlUser" />
						</Triggers>
					</asp:UpdatePanel>
					<div class="col-md-1 pull-right" style="margin-right:35px;">
						<%--<asp:ImageButton ID="btnExportExcel" OnClientClick="tableToExcel('example-datatable', 'W3C Example Table')" data-toggle="tooltip" title="Export Excel" Style="margin-right: 50px" Width="33px" ImageAlign="Right" runat="server" ImageUrl="~/img/excel.gif" />--%>
                         <%--<input type="button" onclick="tableToExcel('example-datatable', 'W3C Example Table')" class="btn btn-sm btn-success" value="Export to Excel" />--%>
                        <asp:Button ID="btnExport" runat="server" CssClass="btn btn-alt btn-sm btn-success" CausesValidation="false" Text="Export to Excel"  />
					</div>
					<div class="col-md-1 pull-right">
						<asp:Button ID="btndashboard" ValidationGroup="MasterGroup" runat="server" TabIndex="8" Text="Submit" CssClass="btn btn-sm btn-primary" />
					</div>
				</div>
            </div>
        </div>
       
        <br /> 

        <div class="table-responsive">
            <asp:Panel ID="pnldemo" runat="server">
               
                
                <table id="example-datatable" class=" MultiDatatable table table-vcenter table-condensed table-bordered">
                    <thead>
                        <tr>
                             <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 10px">Sr No.</th>  
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Company Name</th>  
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Opening Balance</th>  
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Invoice Amount</th>  
							 <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Payment</th> 
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Outstanding</th>                 
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Owner</th>                       
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpgridview" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center" style="width: 10px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("RowNumber"))%></td>                                
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_Name"))%></td>                                
                                      <td class="text-center" style="width: 100px"><i class="fa fa-inr " /> <%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_OpeningBalance"))%></td>  
                                    <td class="text-center" style="width: 100px"><i class="fa fa-inr " /><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("amt"))%></td>  
									 <td class="text-center" style="width: 100px"><i class="fa fa-inr " /> <%#DynamicparcelDataManipulation.FixNullFromDB(Eval("totalpayment"))%></td>  
                                    <td class="text-center" style="width: 100px"><i class="fa fa-inr " /> <%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Outstanding"))%></td>                                                     
                                     <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("U_FirstName"))%></td>
                                </tr>
                            </ItemTemplate>     
                            <FooterTemplate>
                                <tr style="font-size: 16px; font: bold; display:none;" id="trFooter" runat="server">
                                     <td class="text-center" style="width: 100px;" colspan="2">Total</td>
                                    <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lblopeningbal" runat="server" /></td>
                                    <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lblamt" runat="server" /></td>
                                    <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lblpayment" runat="server" /></td>
                                    <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lbloutstanding" runat="server" /></td>
                                </tr>
                            </FooterTemplate>              
                        </asp:Repeater>
                    </tbody>
                    <tfoot>                        
                        </tfoot> 
                </table>
                <asp:Label ID="lblfoot" Text="No records found" Visible="false"  runat="server" ></asp:Label>
            </asp:Panel>
        </div>



    </div>

</asp:Content>




