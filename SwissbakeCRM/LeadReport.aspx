<%--<%@ Page  Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="LeadReport.aspx.vb" Inherits="LeadReport" %>--%>
<%@ Page Language="VB"  MasterPageFile="~/MainPage.master" AutoEventWireup="false"  CodeFile="LeadReport.aspx.vb" Inherits="LeadReport" %>
<%--<%@ Page Language="VB"  MasterPageFile="~/MainPage.master" AutoEventWireup="false"  CodeFile="DSRReport.aspx.vb" Inherits="DSRReport" %>--%>

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
                <i class="hi hi-tasks" style="margin: -8px"></i>Lead Report<br>
            </h1>
        </div>
    </div>
    <ul class="breadcrumb breadcrumb-top">
        <li><a href="index.aspx">Home</a></li>
        <li>Lead Report</li>
    </ul>
    <div class="block">
        <div class="block-title">
            <h2><strong>Lead Report</strong> Detail</h2>
        </div>
        <div class="row">
            <div class="form-horizontal form-bordered">
                <div class="col-md-12">
                    <div class="col-md-3">
                        <label class="col-md-3 control-label">From</label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtfrom" runat="server" TabIndex="2" class="form-control" placeholder="Enter From Date" TextMode="Date" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfrom" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                ErrorMessage="Enter From date" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <label class="col-md-3 control-label">To</label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtto" runat="server" TabIndex="3" class="form-control" placeholder="Enter To Date" TextMode="Date" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                ErrorMessage="Enter To date" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ErrorMessage="Enter Valid date" CssClass="MasterValidationCSS" ControlToCompare="txtfrom" ControlToValidate="txtto" Operator="GreaterThanEqual" ValidationGroup="MasterGroup"></asp:CompareValidator>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <label class="col-md-3 control-label">Assigned to</label>
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddlUser" runat="server" AutoPostBack="true" TabIndex="4" class="select-chosen">
                              </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <label class="col-md-3 control-label">Lead Name</label>
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddlLeadName" runat="server" AutoPostBack="true" TabIndex="5" class="select-chosen">                              
                            </asp:DropDownList>
                            
                        </div>
                    </div>
                     </div>
                <div style="clear:both;"><br /></div>
                <div class="col-md-12" runat="server" id="divemp">
                    <div class="col-md-3">
                                <div class="">
                                    <label class="col-md-3 control-label" for="example-hf-password">Type</label>
                                    <div class="col-md-9">
                                        <asp:DropDownList ID="ddlType" runat="server" TabIndex="6" name="example-chosen" class="select-chosen" >   
                                            <asp:ListItem Text="All" Value="-1"></asp:ListItem>  
                                            <asp:ListItem Text="None" Value="0"></asp:ListItem>                                       
                                            <asp:ListItem Text="High Potential" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Low Potential" Value="2"></asp:ListItem>
                                            <%--<asp:ListItem Text="Normal" Value="3"></asp:ListItem>--%>
                                            <asp:ListItem Text="Keep in View" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Home Baker" Value="5"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                    <div class="col-md-3">
                                <div class="">
                                    <label class="col-md-3 control-label" for="example-hf-password">Category</label>
                                    <div class="col-md-9">
                                        <asp:DropDownList ID="ddlCategory" runat="server" TabIndex="7" name="example-chosen" class="select-chosen" >    
                                            <asp:ListItem Text="All" Value="All"></asp:ListItem>                                       
                                            <asp:ListItem Text="Domestic" Value="Domestic"></asp:ListItem>
                                            <asp:ListItem Text="Export" Value="Export"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                    
                    <div class="col-md-3">
                                <div class="">
                                    <label class="col-md-3 control-label" for="example-hf-password">Source</label>
                                    <div class="col-md-9">
                                        <asp:DropDownList ID="ddlSource" runat="server" TabIndex="8" name="example-chosen" class="select-chosen" >    
                                       
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                
                    <div class="col-md-3">
                                <div class="">
                                    <label class="col-md-3 control-label" for="example-hf-password">Status</label>
                                    <div class="col-md-9">
                                        <asp:DropDownList ID="ddlStatusStage" runat="server" TabIndex="9" CssClass="form-control" AutoPostBack="true" >    
                                            <asp:ListItem Text="Active Leads" Value="0"></asp:ListItem>                                       
                                            <asp:ListItem Text="Junk Leads" Value="7"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                  <div style="clear:both;"><br /></div>
                     <div class="col-md-2 pull-right" >
                    <asp:Button ID="btndashboard" ValidationGroup="MasterGroup" runat="server" TabIndex="6" Text="Submit" CssClass="btn btn-sm btn-primary" />
                    <%--<asp:ImageButton ID="btnExportExcel" OnClientClick="tableToExcel('example-datatable', 'W3C Example Table')" data-toggle="tooltip" title="Export Excel" Style="margin-right: 50px" Width="33px" ImageAlign="Right" runat="server" ImageUrl="~/img/excel.gif" />--%>
                   <%--<input type="button" onclick="tableToExcel('example-datatable', 'W3C Example Table')" class="btn btn-sm btn-success" value="Export to Excel" />--%>
                        <asp:Button ID="btnExport" runat="server" CssClass="btn btn-alt btn-sm btn-success" CausesValidation="false" Text="Export to Excel"  />
                </div>   
                    </div> 
                <div style="clear:both;"><br /></div>
            </div>   
                
        </div>
   </div>
         <div class="row ">
            <%--<asp:Repeater ID="rrvisitcount" runat="server">--%>
                <%--<ItemTemplate>--%>
                  <div class="col-sm-6 col-lg-2 ">
                <!-- Widget -->
                <a href="#" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-fire animation-fadeIn">
                           <asp:Literal ID="ltTotalLeads" runat="server"></asp:Literal>
                        </div>                       
                        <h3 class="widget-content text-right animation-pullDown"><strong><%#Eval("Name")%>Total Leads</strong><%--<br>--%>
                            <small><%#Eval("Duration")%></small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
                </div>   
			          <div class="col-sm-6 col-lg-2 ">
                <!-- Widget -->
                <a href="#" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-fire animation-fadeIn">
                           <asp:Literal ID="ltleadidl" runat="server"></asp:Literal>
                        </div>                       
                        <h3 class="widget-content text-right animation-pullDown"><strong><%#Eval("Name")%>Idle Leads</strong><%--<br>--%>
                            <small><%#Eval("Duration")%></small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
                </div> 
                  <div class="col-sm-6 col-lg-2">
                <!-- Widget -->
                <a href="#" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-fire animation-fadeIn">
                            <asp:Literal ID="ltDomesticLeads" runat="server"></asp:Literal>
                        </div>                       
                        <h3 class="widget-content text-right animation-pullDown"><strong><%#Eval("Name")%>Domestic Leads</strong><br>
                            <small><%#Eval("Duration")%></small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
                </div>   
                  <div class="col-sm-6 col-lg-2">
                <!-- Widget -->
                <a href="#" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-fire animation-fadeIn">
                            <asp:Literal ID="ltExportLeads" runat="server"></asp:Literal>
                        </div>                       
                        <h3 class="widget-content text-right animation-pullDown"><strong><%#Eval("Name")%>Export Leads</strong><br>
                            <small><%#Eval("Duration")%></small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
                </div>   
                  <div class="col-sm-6 col-lg-2">
                <!-- Widget -->
                <a href="#" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-fire animation-fadeIn">
                            <asp:Literal ID="ltHotLeads" runat="server"></asp:Literal>
                        </div>                       
                        <h3 class="widget-content text-right animation-pullDown"><strong><%#Eval("Name")%>High Potetial Leads</strong><br>
                            <small><%#Eval("Duration")%></small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
                </div>
                  <div class="col-sm-6 col-lg-2">
                <!-- Widget -->
                <a href="#" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-fire animation-fadeIn">
                            <asp:Literal ID="ltWebSiteLeads" runat="server"></asp:Literal>
                        </div>                       
                        <h3 class="widget-content text-right animation-pullDown"><strong><%#Eval("Name")%>Web Site Leads</strong><br>
                            <small><%#Eval("Duration")%></small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
                </div>   
                <%--</ItemTemplate>--%>
            <%--</asp:Repeater>--%>       
          </div>
        <br />


     <%--   <div class="row" id="divsumary" runat="server" style="display:none;">
           
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
        </div>--%>
   
    <div class="block">
        <div class="table-responsive" id="tblGrid">
            <asp:Panel ID="pnldemo" runat="server">
               
                
                <table id="example-datatable" class=" MultiDatatable table table-vcenter table-condensed table-bordered">
                    <thead runat="server" id="repHeader">
                        <tr>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 60px">Sr No.</th> 
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Lead Name</th>  
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Owner</th>  
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Type</th> 
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Category</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Source</th>
                            <%--<th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Priority</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Status</th>--%>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Interested Products/Other</th>
                            <th  id="ColJunk" runat="server" class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Junk with Reason</th>   
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Last Activity</th>                       
                                                
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpgridview" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center" style="width: 60px"><%# Eval("RowNumber")%></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Lead_Name"))%></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("AssignTo"))%></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("LeadType"))%></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Lead_Category"))%></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Source_Name"))%></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("InterestedProds"))%></td> 
                                    <td id="ColJunkRows" runat="server" class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Lead_Reason"))%></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("LastActivity"))%></td> 

                                   <%-- <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.DateFormatfirstdate(Eval("From"))%></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.TimeFormatAmPm(Eval("From"))%></td>  
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.TimeFormatAmPm(Eval("To"))%></td>  --%>
                                   <%--  <td class="text-center" style="width: 100px"> <asp:HyperLink ID="HyperLink1" Target="_blank" NavigateUrl='<%# DynamicparcelDataManipulation.FixNullFromDB(Eval("href")) + HttpUtility.UrlEncode(Security.Encrypt(Eval("Activity_Id").ToString()))%>' title="View" runat="server">
                                            <asp:Literal ID="lblcontact" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_Name"))%>' />
                                        </asp:HyperLink></td>  --%>
                                  <%--   <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Name"))%></td>  
                                     <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Subject"))%></td>  --%>
                                     <%--<td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Priority"))%></td>  
                                     <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Status"))%>
                                         <asp:literal ID="ltqty" runat="server" Visible ="false" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Status"))%>'></asp:literal>
                                     </td>   --%>          
                                 <%--    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Activity_Description"))%></td>                         
                                     <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("AssignTo"))%>  </td>--%>
                                </tr>
                            </ItemTemplate>

                            <FooterTemplate>
                                <tr ID="lblNoRecord" Visible="false" runat="server">
                                    <td colspan="6" style="width: 100px">
                                        <asp:Label runat="server" ID="lblNoData" style="font-size:15px; text-align:center;" ><strong>No Record Found</strong></asp:Label>
                                    </td>
                                    <%--<td colspan="3" class="text-right" style="width: 100px">Total</td>
                                    <td class="text-center" style="width: 100px">
                                        <asp:Label ID="quantityTotal" runat="server" /></td>
                                    <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="amountTotal" runat="server" /></td>--%>
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

