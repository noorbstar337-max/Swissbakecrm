<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="LiveRate.aspx.vb" Inherits="LiveRate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
table {
	max-width:980px;
	table-layout:fixed;
	margin:auto;
    border-color: black;
}
th, td {
	/*padding:5px 10px;*/
	border:1px solid black;
}
thead, tfoot {
	background:#d81f26;
    color:whitesmoke;
	display:table;
	width:100%;
	width:calc(100% - 18px);
}
tbody {
	max-height:350px;
	overflow:auto;
	overflow-x:hidden;
	display:block;
	width:100%;
}
tbody tr {
	display:table;
	width:100%;
	table-layout:fixed;
    text-align:center;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="content-header">
                <div class="header-section">
                    <h1>
                        <strong>Live Rate</strong> Details
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li>Live Rate</li>
            </ul>
   <%-- <div class="block" style ="width:100%;">
                <div class="block-title">
                    <h2><strong>Live Rate</strong> Details</h2>
                </div>
        </div>--%>
      <div class="row">
            
             <%-- Domestic Rate --%>
             <div class="col-md-6 table-responsive ">
                         <asp:Panel ID="pnldemo" runat="server">
                        <div class="block widget" style="min-height:520px">
                        <div id="2" class="form-horizontal form-bordered block-title widget">
                            <h2><strong>Domestic</strong> Live Rates</h2>
                        </div> 
                          <div  style="height:400px; ">
                        <table id="example-datatable3" class="MultiDatatable table table-vcenter table-condensed table-bordered widget" >
                    <thead >
                        <tr>   
                            <th class="text-center" style="display: none">Domestic</th>  
                            <th class="text-center col-md-1" style="font-size: 14px; font-weight: 600; color: whitesmoke;">Sr No.</th>
                             <th class="text-center col-md-5" style="font-size: 14px; font-weight: 600; color: whitesmoke;">Product</th>
                            <th class="text-center col-md-3" style="font-size: 14px; font-weight: 600; color: whitesmoke;">CLP</th>
                            <th class="text-center col-md-3" style="font-size: 14px; font-weight: 600; color: whitesmoke;">DLP</th>
                       </tr>
                    </thead>
                    <tbody >
                        <asp:Repeater ID="rptDomesticRate" runat="server" >
                            <ItemTemplate>
                                <tr>
                                                               
                                    <td style="display: none" class ="text-center "><asp:Label ID="lblPurchaseId" runat="server" Text='<%#Eval("Product_Id")%>'></asp:Label></td> 
                                    <td class ="text-center col-md-1"><asp:Label ID="Label3" runat="server" Text='<%#Eval("RowNumber")%>'></asp:Label></td>                                
                                    <td class ="text-center col-md-5"><asp:Label ID="lblPDelivery" runat="server" Text='<%#Eval("Product_Name") + " - (" + Eval("Product_Code") + ")"%>'></asp:Label></td>
                                    <td class ="text-center col-md-3"><asp:Label ID="Label2" runat="server" Text='<%#"₹ " + Convert.ToString(Eval("Product_Rate"))%>'></asp:Label></td> 
                                    <td class ="text-center col-md-3"><asp:Label ID="Label9" runat="server" Text='<%#"₹ " + Convert.ToString(Eval("DLP"))%>'></asp:Label></td> 
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                 <tr style="font-size: 16px; font: bold;" id="trFooter" runat="server" visible="false">
                                     <td class="text-center" style="width: 200px;" colspan="2">Total</td>
                                    <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lblDomclp" runat="server" /></td>
                                    <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lblDomdlp" runat="server" /></td>
                                </tr>
                            </FooterTemplate>
                        </asp:Repeater>
                    </tbody>
                <tfoot>
                         <%--  <tr>
                            <td colspan="3">
                                <label for="example-nf-email" class="control-label " id="Label5" runat="server" visible="false">No Record Found</label>
                            </td>
                         </tr>--%>
                    </tfoot>
                </table>
                              <asp:Label ID="lblfoot" Text="No records found" Visible="false"  runat="server" ></asp:Label>
                        </div> 
                        </div>  
                    </asp:Panel>
                         </div> 


              <%-- Export Rate --%>
                <div class="col-md-6 table-responsive ">  
                        <asp:Panel ID="Panel1" runat="server">
                        <div class="block widget" style="height:520px; ">             
                        <div id="1" class="form-horizontal form-bordered block-title widget">
                            <h2><strong>Export</strong> Live Rates</h2>
                        </div> 
                             <div  style="height:400px; ">                   
                        <table id="example-datatable4" class="MultiDatatable table table-vcenter table-condensed table-bordered widget" >
                    <thead>
                        <tr>   
                            <th class="text-center" style="display: none">Export</th> 
                             <th class="text-center col-md-1" style=" font-size: 14px; font-weight: 600; color: whitesmoke;">Sr No.</th>   
                            <th class="text-center col-md-5" style="font-size: 14px; font-weight: 600; color: whitesmoke;">Product</th>
                            <th class="text-center col-md-3" style="font-size: 14px; font-weight: 600; color: whitesmoke;">CLP</th>
                            <th class="text-center col-md-3" style=" font-size: 14px; font-weight: 600; color: whitesmoke;">DLP</th>
                       </tr>
                    </thead>
                           
                    <tbody>
                        <asp:Repeater ID="rptExportRate" runat="server" >
                            <ItemTemplate>
                                <tr>
                                    <td style="display: none" class ="text-center "><asp:Label ID="lblPurchaseId" runat="server" Text='<%#Eval("Product_Id")%>'></asp:Label></td>  
                                    <td class ="text-center col-md-1"><asp:Label ID="Label3" runat="server" Text='<%#Eval("RowNumber")%>'></asp:Label></td>                  
                                    <td class ="text-center col-md-5"><asp:Label ID="lblPDelivery" runat="server" Text='<%#Eval("Product_Name") + " - (" + Eval("Product_Code") + ")"%>'></asp:Label></td>
                                    <td class ="text-center col-md-3"><asp:Label ID="Label2" runat="server" Text='<%#"₹ " + Convert.ToString(Eval("Product_Rate"))%>'></asp:Label></td> 
                                    <td class ="text-center col-md-3"><asp:Label ID="Label1" runat="server" Text='<%#"₹ " + Convert.ToString(Eval("DLP"))%>'></asp:Label></td> 
                                </tr>
                            </ItemTemplate>
                               <FooterTemplate>
                                 <tr style="font-size: 16px; font: bold;" id="trFooter1" runat="server" visible="false">
                                     <td class="text-center" style="width: 200px;" colspan="2">Total</td>
                                    <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lblExpoclp" runat="server" /></td>
                                    <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lblExpodlp" runat="server" /></td>
                                </tr>
                            </FooterTemplate>
                        </asp:Repeater>
                           
                    </tbody>
                                
                   <tfoot>
                       <%-- <tr>
                            <td colspan="3">
                                <label for="example-nf-email" class="control-label " id="lblNoDataExp" runat="server" visible="false">No Record Found</label>
                            </td>
                         </tr>--%>
                    </tfoot>
                </table>
                                  <asp:Label ID="lblfoot1" Text="No records found" Visible="false"  runat="server" ></asp:Label>
                                  </div>
                    </div>
                    
                   </asp:Panel>
                   
                </div>

             <div style="clear: both"></div>
                </div>
    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <br />
            <div class="divWaiting">
                <i class="fa fa-sun-o fa-spin" id="LoadingUpadatePanel"></i>
            </div>

        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

