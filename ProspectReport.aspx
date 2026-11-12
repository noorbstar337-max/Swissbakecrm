<%--<%@ Page  Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="LeadReport.aspx.vb" Inherits="LeadReport" %>--%>
<%@ Page Language="VB"  MasterPageFile="~/MainPage.master" AutoEventWireup="false"  CodeFile="ProspectReport.aspx.vb" Inherits="ProspectReport" %>
<%--<%@ Page Language="VB"  MasterPageFile="~/MainPage.master" AutoEventWireup="false"  CodeFile="DSRReport.aspx.vb" Inherits="DSRReport" %>--%>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style>
        .table-responsive{
            overflow-x:auto;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:HiddenField ID="hfExcelmode" runat="server" />
     <div class="content-header">
        <div class="header-section">
            <h1>
                <i class="hi hi-tasks" style="margin: -8px"></i>Prospect Report<br>
            </h1>
        </div>
    </div>
    <ul class="breadcrumb breadcrumb-top">
        <li><a href="index.aspx">Home</a></li>
        <li>Prospect Report</li>
    </ul>
    <div class="block">
        <div class="block-title">
            <h2><strong>Prospect Report</strong> Detail</h2>
        </div>
        <div class="row">
            <div class="form-horizontal form-bordered">
                <div class="col-md-12">
                    <div class="col-md-3">
                        <label class="col-md-3 control-label">From</label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtfrom" runat="server" class="form-control" placeholder="Enter From Date" TextMode="Date" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfrom" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                ErrorMessage="Enter From date" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <label class="col-md-3 control-label">To</label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtto" runat="server" class="form-control" placeholder="Enter To Date" TextMode="Date" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                ErrorMessage="Enter To date" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ErrorMessage="Enter Valid date" CssClass="MasterValidationCSS" ControlToCompare="txtfrom" ControlToValidate="txtto" Operator="GreaterThanEqual" ValidationGroup="MasterGroup"></asp:CompareValidator>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <label class="col-md-3 control-label">Assigned to</label>
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddlUser" runat="server" AutoPostBack="true" class="select-chosen">
                              </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <label class="col-md-3 control-label">Prospect</label>
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddlProspectName" runat="server" AutoPostBack="true" class="select-chosen">                              
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
                                        <asp:DropDownList ID="ddlType" runat="server" name="example-chosen" class="select-chosen" >   
                                            <%--<asp:ListItem Text="All" Value="-1"></asp:ListItem>  
                                            <asp:ListItem Text="None" Value="0"></asp:ListItem>                                       
                                            <asp:ListItem Text="Hot" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Cold" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Normal" Value="3"></asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                    <div class="col-md-3">
                                <div class="">
                                    <label class="col-md-3 control-label" for="example-hf-password">Category</label>
                                    <div class="col-md-9">
                                        <asp:DropDownList ID="ddlCategory" runat="server" name="example-chosen" class="select-chosen" >    
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
                                        <asp:DropDownList ID="ddlSource" runat="server" name="example-chosen" class="select-chosen" >    
                                       
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                
            <%--        <div class="col-md-3">
                                <div class="">
                                    <label class="col-md-3 control-label" for="example-hf-password">Status</label>
                                    <div class="col-md-9">
                                        <asp:DropDownList ID="ddlStatusStage" runat="server" CssClass="form-control" AutoPostBack="true" >    
                                            <asp:ListItem Text="Active Leads" Value="0"></asp:ListItem>                                       
                                            <asp:ListItem Text="Junk Leads" Value="7"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>--%>
                  <%--<div style="clear:both;"><br /></div>--%>
                     <div class="col-md-2 pull-right" >
                    <asp:Button ID="btndashboard" ValidationGroup="MasterGroup" runat="server" Text="Submit" CssClass="btn btn-sm btn-primary" />
                    <asp:ImageButton ID="btnExportExcel" OnClientClick="tableToExcel('example-datatable', 'W3C Example Table')" data-toggle="tooltip" title="Export Excel" Style="margin-right: 50px" Width="33px" ImageAlign="Right" runat="server" ImageUrl="~/img/excel.gif" />
                    <%--<input type="button" onclick="tableToExcel('example-datatable', 'W3C Example Table')" class="btn btn-sm btn-success" value="Export to Excel" />--%>
                </div>   
                    </div> 
                <div style="clear:both;"><br /></div>
            </div>   
                
        </div>
   </div>
         <div class="row ">           
                  <div class="col-sm-1 col-lg-1 "></div>
                  <div class="col-sm-6 col-lg-2 ">
                <!-- Widget -->
                <a href="#" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-fire animation-fadeIn">
                           <asp:Literal ID="ltTotalProspects" runat="server" Text="100"></asp:Literal>
                        </div>                       
                        <h3 class="widget-content text-right animation-pullDown"><strong>Total Prospects</strong>
                            <small></small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
                </div>   
			      <div class="col-sm-6 col-lg-2 " style="display:none;">
                <!-- Widget -->
                <a href="#" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-fire animation-fadeIn">
                           <asp:Literal ID="ltProspectidl" runat="server" Text="100"></asp:Literal>
                        </div>                       
                        <h3 class="widget-content text-right animation-pullDown"><strong>Idle Prospects</strong>
                            <small></small>
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
                            <asp:Literal ID="ltDirectProspects" runat="server" Text="100"></asp:Literal>
                        </div>                       
                        <h3 class="widget-content text-right animation-pullDown"><strong>Direct Prospects</strong><br>
                            <small></small>
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
                            <asp:Literal ID="ltConvertedProspects" runat="server" Text="100"></asp:Literal>
                        </div>                       
                        <h3 class="widget-content text-right animation-pullDown"><strong>Converted Prospects</strong><br>
                            <small></small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
                </div>   
                  <div class="col-sm-6 col-lg-2" style="display:none;">
                <!-- Widget -->
                <a href="#" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-fire animation-fadeIn">
                            <asp:Literal ID="ltHotProspects" runat="server" Text="100"></asp:Literal>
                        </div>                       
                        <h3 class="widget-content text-right animation-pullDown"><strong>Hot Prospects</strong><br>
                            <small></small>
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
                            <asp:Literal ID="ltWebSiteProspects" runat="server" Text="100"></asp:Literal>
                        </div>                       
                        <h3 class="widget-content text-right animation-pullDown"><strong>Web Site Prospects</strong><br>
                            <small></small>
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
                           <asp:Literal ID="litrader" runat="server" Text="100"></asp:Literal>
                        </div>                       
                        <h3 class="widget-content text-right animation-pullDown"><strong>Total Trader & Distributor</strong>
                            <small></small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
                </div> 
          </div>
        <br />


   
    <div class="block">
        <%--<div class="table-responsive" id="tblGrid">--%>
        <div class="table-responsive" >
        <%--<div id="tblGrid">--%>
            <asp:Panel ID="pnldemo" runat="server">
               
                
                <table  class="table table-vcenter table-condensed table-bordered">
                <%--<table id="example-datatable" class=" MultiDatatable table table-vcenter table-condensed table-bordered">--%>
                    <thead runat="server" id="repHeader">
                        <tr>
                             <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 60px">Sr No.</th>  
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Prospect Name</th>  
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Owner</th>  
                            <%--<th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Due Date</th>--%> 
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Category</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Source</th>
                            <%--<th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Priority</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Status</th>--%>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Interested Products/Other</th>
                            <%--<th  id="ColJunk" runat="server" class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Converted Date</th>--%>   
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Last Activity</th>                       
                            
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Contact Person</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Email</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Mobile</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">City</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">State</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Created Date</th>                    
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpgridview" runat="server">
                            <ItemTemplate>
                                <tr>
                                     <td class="text-center" style="width: 60px"><%#Eval("RowNumber")%></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_Name"))%></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("U_FirstName"))%></td> 
                                    <%--<td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_dueDays"))%></td>--%> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_Category"))%></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Source_Name"))%></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("InterestedProds"))%></td> 
                                    <%--<td id="ColJunkRows" runat="server" class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_ConvertDate"))%></td>--%> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("LastActivity"))%></td> 

                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Contact_ContactPerson"))%></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Contact_Email"))%></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Contact_Mobile"))%></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("city"))%></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("State"))%></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_CreatedDate"))%></td> 
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

