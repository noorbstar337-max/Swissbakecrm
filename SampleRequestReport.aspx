<%@ Page Language="VB"  MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="SampleRequestReport.aspx.vb" Inherits="SampleRequestReport" %>

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
                <i class="hi hi-tasks" style="margin: -8px"></i>Sample Request Report<br>
            </h1>
        </div>
    </div>
    <ul class="breadcrumb breadcrumb-top">
        <li><a href="index.aspx">Home</a></li>
        <li>Sample Request Report</li>
    </ul>

		<div class="row" >				
			<div class="col-sm-6 col-lg-3"  runat="server" id="div1">
                <!-- Widget -->
                 <a href="#" class="widget widget-hover-effect1">
                <div class="widget">                
                    <div class="widget-extra themed-background-dark text-center" style="color:#B31616;">
                        <h4 class="widget-content-light">
                            <small><asp:Literal runat="server" ID="litlead"></asp:Literal> </small><br/><br/>                            
                               <asp:Label runat="server" ID="lblleadtotal"></asp:Label> kg (&#x20B9; <asp:Label runat="server" ID="lblleadamt"></asp:Label>)                                
                        </h4>
                    </div>
                </div>
                     </a>
                <!-- END Widget -->
            </div>	
					<div class="col-sm-6 col-lg-3" runat="server" id="div2">
                <!-- Widget -->
                 <a href="#" class="widget widget-hover-effect1">
                <div class="widget">                
                    <div class="widget-extra themed-background-dark-amethyst text-center" style="color:#B31616;">
                        <h4 class="widget-content-light">
                            <small><asp:Literal runat="server" ID="liprospect"></asp:Literal></small><br/><br/>                           
                               <asp:Label runat="server" ID="lblPtotal"></asp:Label> kg (&#x20B9; <asp:Label runat="server" ID="lblpamt"></asp:Label>)                              
                        </h4>
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
                        <h4 class="widget-content-light">
                            <small><asp:Literal runat="server" ID="liaccount"></asp:Literal></small><br/><br/>                           
                               <asp:Label runat="server" ID="lblatotal"></asp:Label> kg (&#x20B9; <asp:Label runat="server" ID="lblaamt"></asp:Label>)                              
                        </h4>
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
                        <h4 class="widget-content-light">
                            <small>Total</small><br/><br/>                           
                               <asp:Label runat="server" ID="lbaatotal"></asp:Label> kg (&#x20B9; <asp:Label runat="server" ID="labamtt1"></asp:Label>)                              
                        </h4>
                    </div>
                </div>
                     </a>
                <!-- END Widget -->
            </div>		
		</div>


    <div class="block">
        <div class="block-title">
            <h2><strong>Sample Request Report</strong> Detail</h2>
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
                        <label class="col-md-3 control-label">User</label>
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddlUser" runat="server" TabIndex="4" class="select-chosen">
                              </asp:DropDownList>
                            
                        </div>
                    </div>
					<div class="col-md-3">
                        <label class="col-md-3 control-label">Company Type</label>
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddcompanytype" runat="server" AutoPostBack="true" TabIndex="7" class="select-chosen">  
								<asp:ListItem >All</asp:ListItem>
                                <asp:ListItem >Lead</asp:ListItem> 
                                <asp:ListItem >Prospect</asp:ListItem> 
								 <asp:ListItem >Account</asp:ListItem> 
                            </asp:DropDownList>
                            
                        </div>
                    </div>

                </div>
               
                 <div style="clear: both"></div>
         <%--       <br/>--%>
                <br/>

                <div class="col-md-12" runat="server" id="divemp">
              
					<asp:UpdatePanel runat="server">
						<ContentTemplate>
							      <div class="col-md-3">
                        <label class="col-md-3 control-label">Company</label>
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddlCompany" runat="server" TabIndex="5" class="select-chosen">                              
                            </asp:DropDownList>
                            
                        </div>
                    </div>
						</ContentTemplate>
						<Triggers>
							<asp:PostBackTrigger ControlID="ddcompanytype" />
						</Triggers>
					</asp:UpdatePanel>
               
			
                    <div class="col-md-3">
                        <label class="col-md-3 control-label">Product</label>
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddlProduct" runat="server"  TabIndex="6" class="select-chosen">                              
                            </asp:DropDownList>
                            
                        </div>
					</div>
					 <div class="col-md-3">
                        <label class="col-md-3 control-label">Status</label>
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddlStage" runat="server" TabIndex="7" class="select-chosen">  
								<asp:ListItem >None</asp:ListItem>    
                                <asp:ListItem >Requested</asp:ListItem>                        
                                <asp:ListItem >Dispatched</asp:ListItem> 
                                <asp:ListItem >Approved</asp:ListItem> 
                                <asp:ListItem >Authorized</asp:ListItem> 
                                <asp:ListItem >Rejected</asp:ListItem> 
                            </asp:DropDownList>
                            
                        </div>
                    </div>
					<div class="col-md-2 pull-right" >
                    <asp:Button ID="btndashboard" ValidationGroup="MasterGroup" runat="server" TabIndex="8" Text="Submit" CssClass="btn btn-sm btn-primary" />
                  
                    <%--<input type="button" onclick="tableToExcel('example-datatable', 'W3C Example Table')" class="btn btn-sm btn-success" value="Export to Excel" />--%>
                        <asp:Button ID="btnExport" runat="server" CssClass="btn btn-alt btn-sm btn-success" CausesValidation="false" Text="Export to Excel"  />
					</div> 
				   <%-- <div class="col-md-1 pull-right"  >
                      <asp:ImageButton ID="btnExportExcel" OnClientClick="tableToExcel('example-datatable', 'W3C Example Table')" data-toggle="tooltip" title="Export Excel" Style="margin-right: 50px" Width="33px" ImageAlign="Right" runat="server" ImageUrl="~/img/excel.gif" />
                  </div>  --%>
                     
                </div>   
			
                


            </div>
        </div>
       
        <br />

        <div class="row" id="divsumary" runat="server" style="display:none;">
           
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
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Request No.</th>  
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Company Name</th>  
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Type</th>  
                            <th class="text-center mydate" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Product Name</th> 
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Quantity</th> 
							 <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Rate / KG</th> 
							 <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Price</th> 
                                                   
                             <%--<th class="text-center mydate" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Subject</th>                          
                           <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Priority</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Status</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Description</th>--%>
                             <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Status</th>                
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Owner</th>                       
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpgridview" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center" style="width: 60px"><%#Eval("RowNumber")%></td>  
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.DateFormat(Eval("SampleRequest_Date"))%></td> 
                                  <%--  <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.TimeFormatAmPm(Eval("SampleRequest_No"))%></td>  --%>
                                      <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("SampleRequest_No"))%></td>  
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("CompanyName"))%></td>  
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("SampleRequest_Type"))%></td> 
                                   <%--  <td class="text-center" style="width: 100px"> <asp:HyperLink ID="HyperLink1" Target="_blank" NavigateUrl='<%# DynamicparcelDataManipulation.FixNullFromDB(Eval("href")) + HttpUtility.UrlEncode(Security.Encrypt(Eval("Activity_Id").ToString()))%>' title="View" runat="server">
                                            <asp:Literal ID="lblcontact" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_Name"))%>' />
                                        </asp:HyperLink></td>  --%>
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Product_Name"))%></td> 
                                     <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("qty"))%> KG</td>  
									 <td class="text-center" style="width: 100px">&#x20B9; <%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Product_Rate"))%></td> 
									 <td class="text-center" style="width: 100px">&#x20B9; <%#DynamicparcelDataManipulation.FixNullFromDB(CInt(Eval("Samplerate")).ToString("N2"))%></td> 
                                     <%-- <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Subject"))%></td>  
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Priority"))%></td>  
                                     <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Status"))%>
                                         <asp:literal ID="ltqty" runat="server" Visible ="false" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Status"))%>'></asp:literal>
                                     </td>          
                                     <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Activity_Description"))%></td>     --%>   
                                     <%--<td class="text-center " style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("SampleRequest_SampleStatus"))%>--%>
                                   <td class="text-center " style="width: 100px"> <asp:Label ID="lblReqStatus" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("SampleRequest_SampleStatus"))%>'
												CssClass='<%#Security.checkSRStatus(Eval("SampleRequest_SampleStatus"))%>' EnableViewState="false" />   </td>                 
                                     <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("AssignTo"))%>
                                         
                                     </td>
                                </tr>
                            </ItemTemplate>

                               <FooterTemplate>
                                <tr style="font-size: 16px; font: bold;" id="trFooter" runat="server">
                                    <td class="text-center" style="width: 100px;" colspan="6">Total</td>
                                    <td class="text-center" style="width: 100px">
                                      <asp:Label ID="lblQty" runat="server" />&nbsp;<i class="fa">KG</i></td>
                                    <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lblrate" runat="server" /></td>
                                    <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lblprice" runat="server" /></td>
                                     

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




