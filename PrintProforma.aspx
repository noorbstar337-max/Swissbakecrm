<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PrintProforma.aspx.vb" Inherits="PrintProforma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print Proforma</title>
        <style>
        .mainwrapper { border:1px solid;
  width: 758px;
  height: auto;
  margin: 0 auto;
  padding: 0px;
  display:table;
        }

        .container {
  width: 759px;
  height: auto;
  float:left;
        }
        .block1 {
        border-right:1px solid;
  width: 463px;
  height: auto;
  float: left;}
        .block2 {
          
 width: 295px;
  height: auto;
  float: left;}
         .block3 {
           
  width: 48.4%;
  height: auto;
  float: left;
  padding: 5px;}
        .box1 {
         border-top: 0px;
  border-left: 0px;
  border-right: 0px;
    border-bottom: 1px solid;

  float: left;
  width: 98%;
  padding: 5px;
  height:auto;
        }
        h1 {
          font-size: 14px;
  font-family: sans-serif; margin: 0px 0 4px 0;}
         h2 {
         font-size: 10px;
  font-family: sans-serif; margin: 0px 0 4px 0;}
        p {
        font-size: 12px;
  font-family: sans-serif;
  margin: 0px;}
        .block2>table>tbody>tr>td {
      border:1px solid;
     
  border-top: 0px;
  border-right: 0px;
  border-left: 0px;
        }
         .block3>table>tbody>tr>td {
        }
        .Item_cs {
        text-align:center;}
        b {
          font-family: sans-serif;
  font-size: 13px;}
    </style>
     <link rel="stylesheet" href="css/plugins.css" />
    <script type="text/javascript">
        function printDiv(divID) {
            //Get the HTML of div
            var divElements = document.getElementById(divID).innerHTML;
            //Get the HTML of whole page
            var oldPage = document.body.innerHTML;

            //Reset the page's HTML with div's HTML only
            document.body.innerHTML = "<html><head></head><body>" + divElements + "</body>";

            //Print Page
            window.print();

            //Restore orignal HTML
            document.body.innerHTML = oldPage;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hfFreight" runat="server" />
        <asp:HiddenField ID="hfcustid" runat="server" />
        <asp:HiddenField ID="hfcompanyid" runat="server" />
        <div id="printablediv" runat="server">
         <div class="mainwrapper" style="width: 759px;border-bottom:0px solid;">
       
             <h1 style="text-align:center;margin-top:3px;">PROFORMA INVOICE</h1>
       </div>
    <div class="mainwrapper" runat="server">
      
        <div class="container" runat="server">
            <div class="block1">
                <div class="box1">
                    <h1>
                        <asp:Label ID="lblcompanyName" runat="server"></asp:Label></h1>
                    <p><asp:Label ID="lblcompanyaddress" runat="server"></asp:Label><br/> <%--<asp:Label ID="lblcompanypincode" runat="server"></asp:Label><br/>--%><asp:Label ID="lblCompanyEmail" runat="server"></asp:Label></p>
                </div>
                <div class="box1">
                    <small>Consignee</small>
                     <h1><asp:Label ID="lblaccname" runat="server"></asp:Label></h1>
                    <p><asp:Label ID="lblbilladdress" runat="server"></asp:Label><br/> <asp:Label ID="lblbillcity" runat="server"></asp:Label><br/><asp:Label ID="lblbillpincode" runat="server"></asp:Label></p>
                </div>
                <div class="box1" style="border-bottom:0px;">
                    <small>Buyer (if other than consignee)</small>
                     <h1><asp:Label ID="lblaccname2" runat="server"></asp:Label></h1>
                    <p><asp:Label ID="lblshipaddress" runat="server"></asp:Label><br/> <asp:Label ID="lblshipcity" runat="server"></asp:Label><br/><asp:Label ID="lblshippincode" runat="server"></asp:Label></p>
                </div>
            </div>
            <div class="block2">
                <table border="0" style="  width: 100%;" cellspacing="0" cellpadding="3">
                    <tr>
                        <td style="border-right:1px solid;"><p>Proforma No</p><b><asp:Label ID="lblproformanumber" runat="server"></asp:Label></b></td>
                         <td><p>Dated</p><b><asp:Label ID="lbldate" runat="server"></asp:Label></b></td>
                    </tr>
                    <tr>
                        <td style="border-right:1px solid;"><p>Supplier's Ref.</p><b><asp:Label ID="lblsuplierref" runat="server"></asp:Label></b></td>
                         <td><p>Mode/Terms of Payment</p><b><asp:Label ID="lbltermsofpay" runat="server"></asp:Label></b></td>
                    </tr>
                   <%-- <tr>
                        <td style="border-right:1px solid;"><p>Buyer's Order No.</p><b><asp:Label ID="lblbuyer" runat="server"></asp:Label></b></td>
                         <td><p>Dispatch Document No.</p><b><asp:Label ID="lbldisdocno" runat="server"></asp:Label></b></td>
                    </tr>--%>
                    <tr>
                        <td style="border-right:1px solid;"><p>Dispatch through</p><b><asp:Label ID="lbldispatch" runat="server"></asp:Label></b></td>
                         <td><p>Destination</p><b><asp:Label ID="lbldestination" runat="server"></asp:Label></b></td>
                    </tr>
                    <%--<tr>
                        <td><p>Invoice No</p><b>2090</b></td>
                         <td><p>Invoice No</p><b>2090</b></td>
                    </tr>
                    <tr>
                        <td><p>Invoice No</p><b>2090</b></td>
                         <td><p>Invoice No</p><b>2090</b></td>
                    </tr>--%>
                     <tr>
                        <td colspan="2" style="border-bottom: 0px;"><p>Terms of Delivery</p><h2><b><asp:Label ID="lbltermofdelivery" runat="server"></asp:Label></b></h2></td>
                         
                    </tr>
                </table>
            </div>
        </div>

         <div class="container" style="
  border-bottom: 1px solid; " runat="server">
             <asp:GridView ID="grdproforma" ShowFooter="true" CssClass="table table-striped table-vcenter" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Smaller" CellPadding="0" CellSpacing="0" Border="0" runat="server" AutoGenerateColumns="false" Width="100%" style="border-top: 0px;">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="CTNO" HeaderStyle-CssClass="head_css1" ItemStyle-CssClass="Item_cs">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink5" runat="server">Marks & Nos./Container No.</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>                                                            
                                                            <%--<asp:Label ID="lblctno" runat="server" Text='<%#Eval("InDetail_CTNo")%>'></asp:Label>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>  
                                                    <asp:TemplateField HeaderText="Product Name" HeaderStyle-CssClass="head_css" ItemStyle-CssClass="Item_css" FooterStyle-HorizontalAlign="Right"  ItemStyle-Width="389" ItemStyle-Font-Size="Small" FooterStyle-Font-Size="Small">
                                                        
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink11" runat="server">Product Name</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="ltproductname" runat="server" Text='<%#Eval("Product_Name")%>'></asp:Label>
                                                            (<asp:Label ID="ltproductcode" runat="server" Text='<%#Eval("Product_Code")%>'></asp:Label>)
                                                            <%--<asp:Label ID="ltitemid" runat="server" Text='<%#Eval("InDetail_ID")%>' Visible="false"></asp:Label>--%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            Sub Total&nbsp;&nbsp;
                                                            <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />
                                                            VAT/CST&nbsp;&nbsp;
                                                            <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />
                                                            Freight&nbsp;&nbsp;                                                            
                                                            <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />
                                                            Grand Total (Rounded)&nbsp;&nbsp;
                                                        </FooterTemplate>
                                                    </asp:TemplateField>    
                                                    <asp:TemplateField HeaderText="No.Of Pack" ItemStyle-Width="80px" HeaderStyle-CssClass="head_css1" FooterStyle-VerticalAlign="Bottom" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center"  >
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink14" runat="server">Quantity</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>                                                                                                                  
                                                                <asp:Label ID="ltquantity" runat="server" Text='<%#Eval("ItemDt_Qty")%>' Visible="false"></asp:Label>
                                                                 <asp:Label ID="ltkg" Text='<%#Eval("Packing_Weight")%>' runat="server"></asp:Label> Kg
                                                                <asp:HiddenField ID="hfPacking_Weight" runat="server" Value='<%#Eval("Packing_Weight")%>' />                                                            
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <b>
                                                                 <asp:Label ID="lbltotalkg" Text='20' runat="server"></asp:Label>&nbsp;Kg
                                                            </b>
                                                        </FooterTemplate>
                                                    </asp:TemplateField> 
                                                    <asp:TemplateField HeaderText="PrdRate" HeaderStyle-CssClass="head_css1" ItemStyle-CssClass="Item_css1" ItemStyle-Width="90">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink15" runat="server">Rate/Kg (<i class="fa fa-rupee"></i>)</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <small>&nbsp;<i class="fa fa-rupee"></i>&nbsp;</small>
                                                            <asp:Label ID="ltPrdrate" runat="server" Text='<%#Eval("ItemDt_Rate")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>                                                    
                                                    <asp:TemplateField HeaderText="VAT" HeaderStyle-CssClass="head_css1" ItemStyle-CssClass="Item_css1" ItemStyle-Width="120">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink17" runat="server">VAT/CST</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <small>&nbsp;<i class="fa fa-rupee"></i>&nbsp;</small>                                                            
                                                            <asp:Label ID="lblvatinrs" runat="server" Text='<%#Eval("Product_Vat")%>' />                                                            
                                                            <asp:HiddenField ID="hflblvatinrs" runat="server" />
                                                            <span style="font-size:x-small;">(<asp:Label ID="lblvat" runat="server" Text='<%#Eval("Product_Vat")%>' />%)</span>
                                                            
                                                        </ItemTemplate>
                                                        
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-CssClass="head_css2" ItemStyle-CssClass="Item_css1" FooterStyle-CssClass="Item_css1" ItemStyle-Width="120">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink18" runat="server">Amount</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>  
                                                            <small>&nbsp;<i class="fa fa-rupee"></i>&nbsp;</small>                                                         
                                                            <asp:Label ID="ltamount" runat="server" Text='<%#Eval("ItemDt_Amount")%>'></asp:Label>                                                            
                                                            <asp:HiddenField ID="hfltamount" runat="server" />
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <%--Total Amount:<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%><small>&nbsp;<i class="fa fa-rupee"></i>&nbsp;</small><b>
                                                                <asp:Label ID="lblsubtotal" Text='78500' runat="server"></asp:Label>

                                                            </b>                                                            
                                                            <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />
                                                             <small>&nbsp;<i class="fa fa-rupee"></i>&nbsp;</small><b>
                                                                <asp:Label ID="lttotalvat" Text='78500' runat="server"></asp:Label>
                                                            </b>                                                           
                                                            <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />
                                                             <small>&nbsp;<i class="fa fa-rupee"></i>&nbsp;</small><b>
                                                                <asp:Label ID="lblfreight" Text='78500' runat="server"></asp:Label>
                                                            </b>                                                                                                                      
                                                            <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />
                                                            <small>&nbsp;<i class="fa fa-rupee"></i>&nbsp;</small><b>
                                                                <asp:Label ID="lttotalamount" Text='78500' runat="server"></asp:Label>
                                                            </b>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    
                                                </Columns>
                                                <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="left" BackColor="White" />
                                                <FooterStyle HorizontalAlign="left" BackColor="White" />
                                                <PagerSettings PageButtonCount="4" />
                                                <EmptyDataTemplate>
                                                    <asp:Label ID="s" runat="server" Text="No Item Found"></asp:Label><br />
                                                    <br />
                                                </EmptyDataTemplate>
                                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                            </asp:GridView>
        </div>

        <br/>
        <small>
           &nbsp;&nbsp;Amount Chargeable (in words):
        </small>        
        <asp:Label ID="lblamountword" runat="server" Font-Bold="true" Font-Size="Small"></asp:Label>
         <br/>
        <small>
        &nbsp;&nbsp;VAT Amount (in words):
        </small>       
        <asp:Label ID="lblvatword" runat="server" Font-Bold="true" Font-Size="Small"></asp:Label>
        <br />
        <div class="container" style="border-bottom: 1px solid;">
              <div class="block3">
                  <table border="0" style="text-align:left; width: 100%;" cellspacing="0">
                    <tr>
                        <td><p>Remarks:</p></td>
                         <th><p>&nbsp;</p></th>
                    </tr>
                    <tr>
                        <td style="width:125px;"><p>Company's VAT TIN</p></td>
                         <th><p>: <asp:Label ID="lblcompanyvat" runat="server" Font-Bold="true" ></asp:Label></p></th>
                    </tr>
                    <tr>
                        <td><p>Company's CST No.</p></td>
                         <th><p>: <asp:Label ID="lblcompanycst" runat="server" Font-Bold="true"></asp:Label></p></th>
                    </tr>
                    <tr>
                        <td><p>Buyer's VAT TIN</p></td>
                         <th><p>: <asp:Label ID="lblbuyervat" runat="server"  Font-Bold="true"></asp:Label></p></th>
                    </tr>
                    <tr>
                        <td><p>Buyer's CST No.</p></td>
                         <th><p>: <asp:Label ID="lblbuyercst" runat="server" Font-Bold="true"></asp:Label></p></th>
                    </tr>
                      <tr>
                        <td><p>Company's PAN</p></td>
                         <th><p>: <asp:Label ID="lblcompanypan" runat="server" Font-Bold="true"></asp:Label></p></th>
                    </tr>
                      <tr>
                          <td colspan="2" style="font-size:10px;">
                              <small>Declaration</small><br />
                              We declare that this invoice shows the actual price of the goods described and that all particulars are true and correct
                          </td>
                      </tr>
                </table>
              </div>
              <div class="block3" style="padding-top: 68px;" runat="server" id="mumbank">
                  <small>Company's Bank Details</small><br />
                   <table border="0" style="text-align:left; width: 100%;" cellspacing="0">
                    <tr>
                        <td><p>Bank Name</p></td>
                         <th><p>:&nbsp; <b>KOTAK MAHINDRA BANK</b></p></th>
                    </tr>
                       <tr>
                        <td><p>A/c No.</p></td>
                         <th><p>:&nbsp; <b>7411221116</b></p></th>
                    </tr>
                       <tr>
                        <td><p>Branch & IFS Code</p></td>
                         <th><p>:&nbsp; <b>MUMBAI CENTRAL & KKBK0001348</b></p></th>
                    </tr>
                   </table> 
              </div>
            <div class="block3" style="padding-top: 68px;" runat="server" id="otherbank">
                  <small>Company's Bank Details</small><br />
                   <table border="0" style="text-align:left; width: 100%;" cellspacing="0">
                    <tr>
                        <td><p>Bank Name</p></td>
                         <th><p>:&nbsp; <b>ICICI  Bank</b></p></th>
                    </tr>
                       <tr>
                        <td><p>A/c No.</p></td>
                         <th><p>:&nbsp; <b>041405004504</b></p></th>
                    </tr>
                       <tr>
                        <td><p>Branch & IFS Code</p></td>
                         <th><p>:&nbsp; <b>Worli Branch & ICIC0000414</b></p></th>
                    </tr>
                   </table> 
              </div>
        </div>
        <div class="container" >
             
            <div class="block3">
                <p>Customer's Seal and Signature</p>
            </div>
              <div class="block3">
                  <h1>for Swiss Bake Ingredients Pvt Ltd(Mumbai)</h1>
                  <p style="text-align:center;">
                      <br />
                      <br />
                      Authorised Signatory
                  </p>
              </div>
        </div>
    </div>
            </div>
         <center>
        <div>
             <input type="button" value="Print Proforma" onclick="javascript: printDiv('printablediv')"  style="width: 138px; border: 1px solid #A39A9A; padding: 7px; background-color: #B31616; color: white;  margin-right: 29px;
margin-top: 14px;"/>
        </div>
      </center>
    </form>
</body>
</html>
