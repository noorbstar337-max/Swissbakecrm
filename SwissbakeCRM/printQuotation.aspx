<%@ Page Language="VB" AutoEventWireup="false" CodeFile="printQuotation.aspx.vb" Inherits="printQuotation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
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
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>

    <script>
        function myFunction(){var a=$("#MyTable >tbody >tr").length;a>10?$("#bg").css("display","none"):($("#bg").css("display","block"),$("#tblsub >tbody >tr:first >td").css("border-top","1px solid #000"))}
    </script>

    <script>
        $( document ).ready(function() {
            debugger;
            var Qtyp = $("#<%=curtype.ClientID%>").val();
            if (Qtyp=="USD")
            {
                replaceImages('img/quotation/r.png', 'img/quotation/d.png')
            }
        });
        function replaceImages(oldUrl, newUrl) {
            var imgs = document.getElementsByTagName('img')
            for (i = 0; i<imgs.length; i++) {
                imgs[i].src = imgs[i].src.replace(oldUrl, newUrl)
            }
            //Working code to decrypt and get Main ID and pass it to decrpt function in webservice
           
          
        }

      
    </script>
    <style>
        table {
            page-break-inside: auto;
        }

        tr {
            page-break-inside: avoid;
            page-break-after: auto;
        }

        @media sceen and (max-width:380px) {
            .quotation-tag {
                position: absolute;
                top: 130px;
                left: 100px;
            }
        }

        @media print {
            thead {
                display: table-header-group;
            }

            tfoot {
                display: table-footer-group;
            }

            tr {
                page-break-inside: avoid;
                page-break-after: auto;
            }
        }

        @media screen {
            thead {
                display: block;
            }

            tfoot {
                display: block;
            }
        }

        thead {
            display: table-header-group;
        }

        ul {
            padding-left: 0px;
            margin: 0px;
            list-style: none;
        }

            ul li {
                padding-left: 0px;
                margin: 0px;
                list-style: none;
                font-family: Arial;
                font-size: 13px;
                font-weight: bold;
            }
    </style>
</head>
<body onload="myFunction()" style="margin: 0px;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:HiddenField ID="hfFreight" runat="server" />
        <asp:HiddenField ID="hfcustid" runat="server" />
        <asp:HiddenField ID="hfcompanyid" runat="server" />
        <asp:HiddenField ID="companycode" runat="server" />
        <asp:HiddenField ID="custcode" runat="server" />
        <asp:HiddenField ID="curtype" runat="server" />
        <asp:HiddenField ID="currate" runat="server" />
        <center>
        <div>
             <input type="button" value="Print quotation" onclick="javascript: printDiv(&#39;printablediv&#39;)" style="width: 138px; border: 1px solid #A39A9A; padding: 7px; background-color: #B31616; color: white;  margin-right: 791px;margin-top: 14px; margin-bottom:20px;" />
           <%-- <asp:DropDownList ID="ddquotationtype" runat="server" AutoPostBack="true" style="float: left;margin: 22px 0 0 90px;" >
                <asp:ListItem Text="ORIGINAL"></asp:ListItem>
                <asp:ListItem Text="DUPLICATE"></asp:ListItem>
                <asp:ListItem Text="TRIPLICATE"></asp:ListItem>
            </asp:DropDownList>--%>
        </div>
      </center>
        <div id="printablediv">
            <div style="background-image: url('img/quotation/qheader.png'); background-repeat: no-repeat; width: 8.27in; height: auto; background-size: contain">
                <table>
                    <tr>
                        <td>
                            <table style="width: 759px; height: auto; margin-left: 10px; display: table;">
                                <tr>
                                    <td>
                                        <h1 style="font-size: 28px; font-family: Arial; margin: 5px 0; float: left; margin-top: 96px;">QUOTATION</h1>
                                        <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Always">
                                            <ContentTemplate>
                                                <asp:Label ID="lblquotationtype" Font-Size="18px" Font-Bold="true" Style="font-size: 18px; font-weight: bold; float: left; margin: 100px 0 0 10px;" runat="server"></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                            <table style="width: 759px; height: auto; margin: 0 auto; padding: 0px; margin-left: 10px; display: table; margin-bottom: 0.70in;">
                                <tr>
                                    <td>
                                        <div style="width: 759px; height: auto; float: left;">
                                            <div style="width: 365px; height: auto; float: left; line-height: 15px;">
                                                <div style="float: left; width: 98%; padding: 5px; height: auto;">
                                                    <small style="font-family: Arial; font-size: 12px;"><b>EXPORTER</b></small> <%--<small style="font-size: 10px; font-family: Arial;">(Account No.-<asp:Label ID="lblcode11" runat="server"></asp:Label>)</small>--%>
                                                    <p style="font-size: 10px; font-family: Arial; margin: 0px 0 4px 0;">
                                                        <b>
                                                            <asp:Label ID="lblaccname11" runat="server" Text="SWISS BAKE INGREDIENTS PVT. LTD"></asp:Label></b>
                                                    </p>
                                                    <p style="font-size: 10px; font-family: Arial; margin: 0px;">
                                                        <asp:Label ID="lblbilladdress11" runat="server" Text="G-10, PARELSHIVMRUTI, MANJREKAR LANE DR.E.MOSES ROAD, WORLI"></asp:Label>
                                                        <br />
                                                        <asp:Label ID="lblbillcity2" runat="server" Text="MUMBAI"></asp:Label>-<asp:Label ID="lblbillpincode2" runat="server" Text="400018"></asp:Label><br />
                                                        <div runat="server" id="divmob1" style="font-size: 10px;">
                                                            <asp:Label ID="lblcontactmobile12" runat="server" Text="EMAIL SOLUTIONS@SWISSBAKE.IN"></asp:Label><br />
                                                              <asp:Label ID="Label4" runat="server" Text="TEL:0091-22-24344101, 0091-22-24944104"></asp:Label>
                                                        </div>
                                                    </p>
                                                </div>
                                                <div style="float: left; width: 98%; padding: 5px; height: auto;">
                                                    <small style="font-family: Arial; font-size: 12px;"><b>DELIVER TO</b></small> <small style="font-size: 10px; font-family: Arial;">(Account No.-<asp:Label ID="lblcode" runat="server"></asp:Label>)</small>
                                                    <p style="font-size: 10px; font-family: Arial; margin: 0px 0 4px 0;">
                                                        <b>
                                                            <asp:Label ID="lblaccname" runat="server"></asp:Label></b>
                                                    </p>
                                                    <p style="font-size: 10px; font-family: Arial; margin: 0px;">
                                                        <asp:Label ID="lblbilladdress" runat="server"></asp:Label>
                                                        <br />
                                                        <asp:Label ID="lblbillcity" runat="server"></asp:Label>-<asp:Label ID="lblbillpincode" runat="server"></asp:Label><br />
                                                        <div runat="server" id="div1" style="font-size: 10px;">
                                                            MOB:<asp:Label ID="lblcontactmobile1" runat="server"></asp:Label>
                                                        </div>
                                                    </p>
                                                </div>
                                            </div>
                                            <div style="width: 277px; height: auto; float: right;">
                                                <table style="width: 100%;" cellspacing="0" cellpadding="3">
                                                    <tbody>
                                                        <tr>
                                                            <td style="font-size: 13px; font-family: Arial; margin: 0px;"><b style="font-family: Arial; font-size: 18px;">Quotation No:
                                                                <asp:Label ID="lblquotationnumber" runat="server"></asp:Label></b></td>
                                                        </tr>
                                                   
                                                        <%--   <tr>
                                                            <td>
                                                                <asp:Image ID="Image1" runat="server" caption="barcode" Style="margin-left: -27px;" />
                                                            </td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td style="font-size: 13px; font-family: Arial; margin: 0px;"><b style="font-family: Arial; font-size: 18px;">DATE:
                                                                <asp:Label ID="lbldate" runat="server"></asp:Label></b></td>
                                                        </tr>                                               
                                                    </tbody>
                                                </table>
                                                <table style="width: 100%;line-height: 15px;" cellspacing="0" cellpadding="0">
                                                    <tbody>
                                                                      <tr>
                                                            <td>
                                                                <div style="float: left; width: 98%; padding: 5px; height: auto;">
                                                                    <small style="font-family: Arial; font-size: 12px;"><b>BUYER</b></small> <small style="font-size: 10px; font-family: Arial;">(Account No.-<asp:Label ID="lblcode1" runat="server"></asp:Label>)</small>
                                                                    <p style="font-size: 10px; font-family: Arial; margin: 0px 0 4px 0;">
                                                                        <b>
                                                                            <asp:Label ID="lblaccname1" runat="server"></asp:Label></b>
                                                                    </p>
                                                                    <p style="font-size: 10px; font-family: Arial; margin: 0px;">
                                                                        <asp:Label ID="lblbilladdress1" runat="server"></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="lblbillcity1" runat="server"></asp:Label>-<asp:Label ID="lblbillpincode1" runat="server"></asp:Label><br />
                                                                        <div runat="server" id="div2" style="font-size: 10px;">
                                                                            MOB:<asp:Label ID="lblcontactmobile11" runat="server"></asp:Label>
                                                                        </div>
                                                                    </p>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <table style="width: 100%;margin-top: -19px;" cellspacing="0" cellpadding="3">
                                                    <tr>
                                                        <td colspan="3"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px; width: 40%;"><i>Import Export Code</i></td>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>:</i></td>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>
                                                            <asp:Label ID="Label11" Style="font-family: Arial; margin-left: 5px;" runat="server" Text="0312020350"></asp:Label></i></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px; width: 40%;"><i>COMPANY'S GSTIN</i></td>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>:</i></td>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>
                                                            <asp:Label ID="lblcompanyvat" Style="font-family: Arial; margin-left: 5px;" runat="server"></asp:Label></i></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>COMPANY'S STATE</i></td>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>:</i></td>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>
                                                            <asp:Label ID="lblcompanycst" runat="server" Style="font-family: Arial; margin-left: 5px;"></asp:Label></i></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>COMPANY'S PAN</i></td>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>:</i></td>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>
                                                            <asp:Label ID="lblcompanypan" runat="server" Style="font-family: Arial; margin-left: 5px;"></asp:Label></i></td>
                                                    </tr>
                                                    <%--        <tr>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>BUYER'S GSTIN</i></td>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>:</i></td>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>
                                                            <asp:Label ID="lblbuyervat" runat="server" Style="font-family: Arial; margin-left: 5px;"></asp:Label></i></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>BUYER'S STATE</i> </td>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>:</i></td>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>
                                                            <asp:Label ID="lblbuyercst" runat="server" Style="font-family: Arial; margin-left: 5px;"></asp:Label></i></td>
                                                    </tr>--%>
                                                </table>
                                            </div>
                                        </div>
                                        <div id="divigst" runat="server">
                                            <div style="font-family: Arial; width: 759px; min-height: 340px; float: left; margin-top: 10px;">
                                                <%--  <img id="bg" src="../images/1.png" style="background-repeat: repeat-y; width: 759px; z-index: 999999; position: absolute; height: 300px;" />--%>
                                                <table id="MyTable" cellpadding="0" cellspacing="0" style="width: 759px; height: auto; float: left;">
                                                    <thead>
                                                        <tr>
                                                            <td id="tdcol" runat="server" >
                                                                <img id="imgdomestic" runat="server" />
                                                            </td>
                                                        </tr>
                                                           </thead>
                                                    <%--    <thead>
                                                        <tr>
                                                            <td style="font-family: Arial; background-color: grey; font-size: 13px; color: white; text-align: center; width: 0%; padding: 5px; border-right: 1px solid white;">Sr.No</td>
                                                            <td style="font-family: Arial; background-color: grey; font-size: 13px; color: white; text-align: center; width: 40%; padding: 5px; border-right: 1px solid white;">Product Name</td>
                                                            <td style="font-family: Arial; background-color: grey; font-size: 13px; color: white; text-align: center; width: 14%; padding: 5px; border-right: 1px solid white;">Product Code</td>
                                                            <td style="font-family: Arial; background-color: grey; font-size: 13px; color: white; text-align: center; width: 8%; padding: 5px; border-right: 1px solid white;">HSN</td>
                                                            <td style="font-family: Arial; background-color: grey; font-size: 13px; color: white; text-align: center; width: 8%; padding: 5px; border-right: 1px solid white;">Qty(Bags)</td>
                                                            <td style="font-family: Arial; background-color: grey; font-size: 13px; color: white; text-align: center; width: 8%; padding: 5px; border-right: 1px solid white;">Qty(Kgs)</td>
                                                            <td style="font-family: Arial; background-color: grey; font-size: 13px; color: white; text-align: center; width: 9%; padding: 5px; border-right: 1px solid white;">Rate/KG</td>
                                                            <td style="font-family: Arial; background-color: grey; font-size: 13px; color: white; text-align: center; width: 18%; padding: 5px; border-right: 1px solid white;">GST</td>
                                                            <td style="font-family: Arial; background-color: grey; font-size: 13px; color: white; text-align: center; width: 21%; padding: 5px;">Amount</td>
                                                        </tr>
                                                    </thead>--%>
                                                    <%--    <tr>
                                                        <td colspan="7">
                                                            <img src="img/igst.png" />
                                                        </td>
                                                    </tr>--%>
                                                    <asp:Repeater ID="grditemproduct" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td style="font-family: Arial; font-size: 12px;  text-align: center;  width: 0%; vertical-align: top; padding: 5px;">
                                                                    <asp:Label ID="Label21111" Style="text-align: center; width: 389px; font-size: 12px; font-family: Arial;" Text='<%#Eval("srno")%>' runat="server"></asp:Label>
                                                                </td>
                                                                <td style="font-family: Arial; font-size: 12px;  text-align: left; width: 40%; vertical-align: top; padding: 5px;">
                                                                    <asp:Label ID="ltproductname" runat="server" Text='<%#Eval("Product_Name")%>'></asp:Label><br />
                                                                    <asp:Label ID="ltproductdesc" runat="server" Text='<%#Eval("Product_Desc")%>' Style="font-size: 10px;"></asp:Label>
                                                                    <asp:Label ID="ltitemid" runat="server" Text='<%#Eval("ItemDt_ID")%>' Visible="false"></asp:Label>
                                                                </td>
                                                                <td style="font-family: Arial; font-size: 12px;  text-align: center; width: 14%; vertical-align: top; padding: 5px;">
                                                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("Product_Code")%>'></asp:Label>
                                                                    <asp:Label ID="ltproductcode" runat="server" Text='<%#Eval("Product_Code")%>' Visible="false"></asp:Label>
                                                                </td>
                                                                <td style="font-family: Arial; font-size: 12px; text-align: center; width: 8%; vertical-align: top; padding: 5px;">
                                                                    <asp:Label ID="Label1" Style="text-align: center; width: 389px; font-size: 12px; font-family: Arial;" Text='<%#Eval("Product_HSCODE")%>' runat="server"></asp:Label>

                                                                </td>
                                                                <td style="font-family: Arial; font-size: 12px; vertical-align: top; width: 8%; text-align: center; padding: 5px;">
                                                                  
                                                                    <asp:Label ID="Label3" Style="text-align: center; width: 389px; font-size: 12px; font-family: Arial;" Text='<%#Eval("bags")%>' runat="server"></asp:Label>
                                                                    <span style="font-size: 12px; font-family: Arial;">Bags</span>
                                                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("Packing_Weight")%>' />
                                                                </td>
                                                                <td style="font-family: Arial; font-size: 12px; vertical-align: top; width: 8%; text-align: center; padding: 5px;">
                                                                    <asp:Label ID="ltquantity" Style="text-align: center; width: 389px; padding: 0 5px; font-size: 12px; font-family: Arial;" runat="server" Text='<%#Eval("ItemDt_Qty")%>' Visible="false"></asp:Label>
                                                                    <asp:Label ID="ltkg" Style="text-align: center; width: 389px; font-size: 12px; font-family: Arial;" Text='<%#Eval("Packing_Weight")%>' runat="server"></asp:Label>
                                                                    <span style="font-size: 12px; font-family: Arial;">Kg</span>
                                                                    <asp:HiddenField ID="hfPacking_Weight" runat="server" Value='<%#Eval("Packing_Weight")%>' />
                                                                </td>
                                                                <td style="font-family: Arial; font-size: 12px;  vertical-align: top; width: 9%; text-align: right; padding: 5px;">
                                                                    <img src="img/quotation/r.png" style="width: 7px; margin-right: 5px;" />
                                                                    <asp:Label ID="ltPrdrate" runat="server" Text='<%#Eval("ItemDt_Rate")%>'></asp:Label></td>
                                                                <td id="tdgstrow" runat="server" style="font-family: Arial; width: 18%; font-size: 12px;  vertical-align: top; text-align: right; padding: 5px;">
                                                                    <img src="img/quotation/r.png" style="width: 7px; margin-right: 5px;" />
                                                                    <asp:Label ID="lblvatinrs" runat="server" Text='<%#Eval("ItemDt_Vat")%>' />
                                                                    <asp:HiddenField ID="hflblvatinrs" runat="server" />
                                                                    <span style="font-size: x-small;">(<asp:Label ID="lblvat" runat="server" />%)</span></td>
                                                                <td style="font-family: Arial; font-size: 12px; width: 21%; vertical-align: top; text-align: right; padding: 5px;">
                                                                    <img src="img/quotation/r.png" style="width: 7px; margin-right: 5px;" />
                                                                    <asp:Label ID="ltamount" runat="server" Text='<%#Eval("ItemDt_Amount")%>'></asp:Label>
                                                                    <asp:HiddenField ID="hfltamount" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </table>


                                            </div>
                                        </div>
                                        <table id="tblsub" cellpadding="0" cellspacing="0" style="width: 759px; height: auto; float: left;">
                                            <tr>
                                                <td style="font-family: Arial; font-size: 12px; text-align: right; width: 18%; padding: 5px; border-top: 1px Solid rgb(0, 0, 0);">NET WT</td>
                                                <td style="font-family: Arial; font-size: 12px; text-align: center; width: 3%; padding: 5px; border-top: 1px Solid rgb(0, 0, 0);">
                                                    <asp:Label ID="lbltotalkg" Text='15' runat="server"></asp:Label>
                                                    Kg
                                                </td>
                                                <td style="font-family: Arial; font-size: 12px; text-align: center; width: 1%; padding: 5px; border-top: 1px Solid rgb(0, 0, 0);"></td>
                                                <td style="font-family: Arial; font-size: 12px; text-align: right; width: 13%; padding: 5px; border-top: 1px Solid rgb(0, 0, 0);">SUB TOTAL</td>
                                                <td style="font-family: Arial; font-size: 12px; text-align: right; width: 2%; padding: 5px; border-top: 1px Solid rgb(0, 0, 0);">
                                                    <img src="img/quotation/r.png" style="width: 7px; margin-right: 5px;" /><asp:Label ID="lblsubtotal" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                        <table id="tblsub" cellpadding="0" cellspacing="0" style="width: 759px; height: auto; float: left;">
                                            <tr>
                                                <td style="font-family: Arial; width: 28%; font-size: 12px; text-align: left; padding: 5px;"><small style="font-size: 12px; font-family: Arial;">Amount Chargeable (in words):</small></td>
                                                <td style="font-family: Arial; width: 58%; font-size: 12px; text-align: left; padding: 5px;">
                                                    <asp:Label runat="server" ID="lblamountword" Style="font-weight: bold; font-size: 12px; font-family: Arial;"></asp:Label></td>
                                                <td style="font-family: Arial; width: 0%; font-size: 12px; text-align: center; padding: 5px;"></td>
                                                <td id="tdwgstlbl" runat="server" style="font-family: Arial; width: 3%; font-size: 12px; text-align: right; padding: 5px;">FREIGHT</td>
                                                <td id="tbwgsttxt" runat="server" style="font-family: Arial; width: 14%; font-size: 12px; text-align: right; padding: 5px;">
                                                    <img src="img/quotation/r.png" style="width: 7px; margin-right: 5px;" /><asp:Label ID="lblfreight" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr id="trtax" runat="server">
                                                <td id="tdfgstlbl" runat="server" style="font-family: Arial; font-size: 12px; text-align: left; padding: 5px;"><small style="font-size: 12px; font-family: Arial;">TAX Amount (in words):</small></td>
                                                <td id="tbfgsttxt" runat="server" style="font-family: Arial; font-size: 12px; text-align: left; padding: 5px;">
                                                    <asp:Label runat="server" ID="lblvatword" Style="font-weight: bold; font-size: 12px; font-family: Arial;"></asp:Label></td>
                                                <td style="font-family: Arial; font-size: 12px; text-align: center; padding: 5px;"></td>
                                                <td style="font-family: Arial; font-size: 12px; text-align: right; padding: 5px;">TAX</td>
                                                <td style="font-family: Arial; font-size: 12px; text-align: right; padding: 5px;">
                                                    <img src="img/quotation/r.png" style="width: 7px; margin-right: 5px;" /><asp:Label ID="lttotalvat" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                        <table id="tblsub" cellpadding="0" cellspacing="0" style="width: 759px; height: auto; float: left;">
                                            <tr>
                                                <td style="font-family: Arial; font-size: 12px; width: 7%; text-align: left; padding: 5px;">Remark:</td>
                                                <td colspan="2" style="font-family: Arial; width: 50%; font-size: 12px; text-align: left; padding: 5px;">
                                                    <asp:Label ID="lbremark" runat="server"></asp:Label></td>
                                                <td style="font-family: Arial; width: 32%; border-top: 1px solid; font-size: 12px; text-align: right; padding: 5px;"><b>GRAND TOTAL (ROUNDED)</b></td>
                                                <td style="font-family: Arial; border-top: 1px solid; width: 13%; font-size: 12px; text-align: right; padding: 5px; font-weight: bold;">
                                                    <img src="img/quotation/r.png" style="width: 7px; margin-right: 5px;" /><asp:Label ID="lttotalamount" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>


                                        <div style="width: 759px; height: auto; float: left;">
                                            <div style="width: 48.4%; height: auto; float: left; padding: 5px;">
                                                <table style="text-align: left; width: 100%;" cellspacing="0" cellpadding="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">Mode of transport   
                                                            </td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">:</td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">
                                                                <asp:Label ID="lblmodeoftrans" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <%--   <tr>
                                                            <td style="width: 125px; font-size: 12px; font-family: Arial; margin: 0px;">Vessel/Flight No
                                                            </td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">:
                                                            </td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">
                                                                <asp:Label ID="lblvesselflightno" runat="server"></asp:Label></td>
                                                        </tr>--%>
                                                        <%--  <tr>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">Dispatch Doc No</td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">:</td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">
                                                                <asp:Label ID="lbldisdocno" runat="server"></asp:Label></td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">Dispatch through
                                                            </td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">:</td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">
                                                                <asp:Label ID="lbldispatch" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-size: 13px; font-family: Arial; margin: 0px;">Destination
                                                               

                                                            </td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">:</td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">
                                                                <asp:Label ID="lbldestination" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-size: 13px; font-family: Arial; margin: 0px;">Terms of Payment
                                                            </td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">:</td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">
                                                                <asp:Label ID="lblpayment" runat="server"></asp:Label></td>
                                                        </tr>
                                                    


                                                    </tbody>
                                                </table>
                                            </div>
                                            <div style="width: 48.4%; height: auto; float: left; padding: 5px; padding-top: -15px;">
                                                <table style="text-align: left; width: 100%; font-family: Arial; font-size: 12px;" cellspacing="0" cellpadding="0">
                                                    <tbody >
                                                            <tr id="trcoo" runat="server">
                                                            <td style="font-size: 13px; font-family: Arial; margin: 0px;">Country Of Origin
                                                               

                                                            </td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">:</td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">
                                                                <asp:Label ID="lblcoo" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr id="trcof" runat="server">
                                                            <td style="font-size: 13px; font-family: Arial; margin: 0px;">Country Of FinalDestination
                                                               

                                                            </td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">:</td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">
                                                                <asp:Label ID="lblcofd" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr id="trpol" runat="server">
                                                            <td style="font-size: 13px; font-family: Arial; margin: 0px;">Port Of Loading
                                                               

                                                            </td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">:</td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">
                                                                <asp:Label ID="lblpol" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr id="trpod" runat="server">
                                                            <td style="font-size: 13px; font-family: Arial; margin: 0px;">Port Of Discharge
                                                               

                                                            </td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">:</td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">
                                                                <asp:Label ID="lblpod" runat="server"></asp:Label></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                            <div id="mumbank" runat="server" style="width: 48.4%; height: auto; float: left; padding: 5px; padding-top: -15px;">
                                                <small style="font-family: Arial; font-size: 12px;">Company's Bank Details</small><br>
                                                <table style="text-align: left; width: 100%; font-family: Arial; font-size: 12px;" cellspacing="0" cellpadding="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">Account Name</p>
                                                            </td>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">:&nbsp; SWISS BAKE INGREDIENTS PVT. LTD.</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">Bank Name</p>
                                                            </td>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">:&nbsp; KOTAK MAHINDRA BANK</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">A/c No.</p>
                                                            </td>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">:&nbsp; 7411221116</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">Branch</p>
                                                            </td>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">:&nbsp; MUMBAI CENTRAL</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">IFS Code</p>
                                                            </td>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">:&nbsp; KKBK0001348</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">Account Type</p>
                                                            </td>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">:&nbsp; Current</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">MICR Code</p>
                                                            </td>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">:&nbsp; 400485062</p>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                            <div id="otherbank" runat="server" style="width: 48.4%; height: auto; float: left; padding: 5px; padding-top: -15px;">
                                                <small style="font-family: Arial; font-size: 12px;">Company's Bank Details</small><br />
                                                <table border="0" style="text-align: left; width: 100%; font-family: Arial;" cellspacing="0" cellpadding="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">Account Name</p>
                                                            </td>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">:&nbsp; SWISS BAKE INGREDIENTS PVT. LTD.</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">Bank Name</p>
                                                            </td>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">:&nbsp; ICICI  Bank</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">A/c No.</p>
                                                            </td>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">:&nbsp; 041405004504</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">Branch &amp; IFS Code</p>
                                                            </td>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">:&nbsp; Worli Branch & ICIC0000414</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">Account Type</p>
                                                            </td>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">:&nbsp; Current</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">MICR Code</p>
                                                            </td>
                                                            <td>
                                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">:&nbsp; 400229055</p>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                        <div style="width: 759px; height: auto; float: left;">

                                            <div style="width: 48.4%; height: auto; float: left; padding: 5px;">
                                                <p style="font-size: 12px; font-family: Arial; margin: 0px;">CUSTOMER'S SEAL AND SIGNATURE</p>
                                            </div>
                                            <div style="width: 37.4%; height: auto; float: right; padding: 5px;">
                                                <p style="text-align: center; font-size: 12px; font-family: Arial; margin: 0px;">
                                                    FOR SWISS BAKE INGREDIENTS PVT. LTD.                                                        
                                                            (AUTHORISED SIGNATORY)                 
                                                </p>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>

                            <%--<div style="background-image: url('../fsb.png');background-repeat: no-repeat;width: 791px;height: 83px;background-size: cover;margin-top: 985px;"></div>--%>
                            <%--</div>--%>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="background-image: url('img/quotation/qfooter.png'); background-repeat: no-repeat; width: 8.27in; height: 37px; background-size: contain">
                    </div>
        </div>
    </form>


</body>
</html>

