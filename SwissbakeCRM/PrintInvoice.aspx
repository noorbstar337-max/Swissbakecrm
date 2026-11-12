<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PrintInvoice.aspx.vb" Inherits="PrintInvoiceNew" %>

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
    <%-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>--%>

    <script>
        function myFunction(){var a=$("#MyTable >tbody >tr").length;a>10?$("#bg").css("display","none"):($("#bg").css("display","block"),$("#tblsub >tbody >tr:first >td").css("border-top","1px solid #000"))}
    </script>
    <style>
        table {
            page-break-inside: auto;
        }

        tr {
            page-break-inside: avoid;
            page-break-after: auto;
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

        <asp:HiddenField ID="hfFreight" runat="server" />
        <asp:HiddenField ID="hfcustid" runat="server" />
        <asp:HiddenField ID="hfcompanyid" runat="server" />
        <center>
        <div>
             <input type="button" value="Print Invoice" onclick="javascript: printDiv(&#39;printablediv&#39;)" style="width: 138px; border: 1px solid #A39A9A; padding: 7px; background-color: #B31616; color: white;  margin-right: 791px;margin-top: 14px; margin-bottom:20px;" />

        </div>
      </center>
        <div id="printablediv">
            <div style="background-image: url('img/PrintInvoice/bg1.jpg'); background-repeat: no-repeat; width: 8.27in; height: 11.69in; background-size: cover">
                <table>
                    <tr>
                        <td>
                            <%--<div style="background-image: url('../bg1.jpg'); background-repeat: no-repeat; width: 21cm; height: 29.8cm; background-size: cover">--%>
                            <%--<div style="background-image: url('../hsb.png');background-repeat: no-repeat;width: 786px;height: 122px;background-size: cover;">--%>
                            <table style="width: 759px; height: auto; margin: 0 auto; margin-left: 10px; padding: 0px; display: table;">
                                <tr>
                                    <td>
                                        <h1 style="font-size: 28px; font-family: Arial; margin: 5px 0; margin-top: 96px;">TAX INVOICE</h1>
                                    </td>
                                </tr>
                            </table>

                            <table style="width: 759px; height: auto; margin: 0 auto; padding: 0px; margin-left: 10px; display: table; margin-bottom: 0.70in;">
                                <tr>
                                    <td>
                                        <div style="width: 759px; height: auto; float: left;">
                                            <div style="width: 365px; height: auto; float: left; line-height: 20px;">

                                                <div style="float: left; width: 98%; padding: 5px; height: auto;">

                                                    <small style="font-family: Arial; font-size: 12px;"><b>CONSIGNEE</b></small> <small style="font-size: 12px; font-family: Arial;">(Account No.-<asp:Label ID="lblcode" runat="server"></asp:Label>)</small>
                                                    <p style="font-size: 10px; font-family: Arial; margin: 0px 0 4px 0;">
                                                        <b>
                                                            <asp:Label ID="lblaccname" runat="server"></asp:Label>
                                                        </b>
                                                    </p>
                                                    <p style="font-size: 10px; font-family: Arial; margin: 0px;">
                                                        <asp:Label ID="lblbilladdress" runat="server"></asp:Label>
                                                        <br />
                                                        <asp:Label ID="lblbillcity" runat="server"></asp:Label>-<asp:Label ID="lblbillpincode" runat="server"></asp:Label><br />
                                                        <asp:Label ID="lblcontactmobile2" runat="server"></asp:Label>
                                                    </p>
                                                </div>
                                                <div style="float: left; width: 98%; padding: 5px; height: auto;">

                                                    <small style="font-family: Arial; font-size: 12px;"><b>BUYER</b> (if other than consignee)</small> <%--(Account No.-
                            <asp:Label ID="lblcode2" runat="server" Style="font-size: 14px; font-weight: 700; font-family: Arial;"></asp:Label>)--%>
                                                    <p style="font-size: 10px; font-family: Arial; margin: 0px 0 4px 0;">
                                                        <b>
                                                            <asp:Label ID="lblaccname2" runat="server"></asp:Label>
                                                        </b>
                                                    </p>
                                                    <p style="font-size: 10px; font-family: Arial; margin: 0px;">
                                                        <asp:Label ID="lblshipaddress" runat="server"></asp:Label><br />
                                                        <asp:Label ID="lblshipcity" runat="server"></asp:Label>-<asp:Label ID="lblshippincode" runat="server"></asp:Label><br />
                                                        <asp:Label ID="lblcontactmobile1" runat="server"></asp:Label>
                                                    </p>
                                                </div>
                                                <%-- <div style="border-top: 0px; border-left: 0px; border-right: 0px; border-bottom: 1px solid; float: left; width: 98%; padding: 5px; height: auto;">
                            <h1 style="font-size: 14px; font-family: Arial; margin: 0px 0 4px 0;">
                                <asp:Label ID="lblcompanyName" runat="server"></asp:Label>
                            </h1>
                            <p style="font-size: 12px; font-family: Arial; margin: 0px;">
                                <asp:Label ID="lblcompanyaddress" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblCompanyEmail" runat="server"></asp:Label>
                            </p>
                        </div>--%>
                                            </div>
                                            <div style="width: 277px; height: auto; float: right;">
                                                <table style="width: 100%;" cellspacing="0" cellpadding="3">
                                                    <tbody>
                                                        <tr>
                                                            <td style="font-size: 13px; font-family: Arial; margin: 0px;"><b style="font-family: Arial; font-size: 18px;">INVOICE NO:
                                                                <asp:Label ID="lblinvoicenumber" runat="server"></asp:Label></b></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Image ID="Image1" runat="server" caption="barcode" Style="margin-left: -27px;" />
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td style="font-size: 13px; font-family: Arial; margin: 0px;"><b style="font-family: Arial; font-size: 18px;">DATE:
                                                                <asp:Label ID="lbldate" runat="server"></asp:Label></b></td>
                                                        </tr>
                                                    </tbody>
                                                </table>

                                                <table style="width: 100%;" cellspacing="0" cellpadding="3">
                                                    <tr>
                                                        <td colspan="3"></td>
                                                    </tr>

                                                    <tr>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px; width: 40%;"><i>COMPANY'S VAT TIN</i></td>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>:</i></td>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>
                                                            <asp:Label ID="lblcompanyvat" Style="font-family: Arial; margin-left: 5px;" runat="server"></asp:Label></i></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>COMPANY'S CST NO</i></td>
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
                                                    <tr>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>BUYER'S VAT TIN</i></td>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>:</i></td>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>
                                                            <asp:Label ID="lblbuyervat" runat="server" Style="font-family: Arial; margin-left: 5px;"></asp:Label></i></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>BUYER'S CST NO</i> </td>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>:</i></td>
                                                        <td style="font-size: 10px; font-family: Arial; margin: 0px;"><i>
                                                            <asp:Label ID="lblbuyercst" runat="server" Style="font-family: Arial; margin-left: 5px;"></asp:Label></i></td>
                                                    </tr>
                                                </table>

                                                <%--    <tbody>
                                <tr>
                                    <td style="border: 1px solid; border-top: 0px; border-left: 0px;">
                                        <p style="font-size: 12px; font-family: Arial; margin: 0px;">Invoice No</p>
                                        <b style="font-family: Arial; font-size: 13px;">
                                            <asp:Label ID="lblinvoicenumber" runat="server"></asp:Label>

                                        </b></td>
                                    <td style="border: 1px solid; border-top: 0px; border-right: 0px; border-left: 0px;">
                                        <p style="font-size: 12px; font-family: Arial; margin: 0px;">Dated</p>
                                        <b style="font-family: Arial; font-size: 13px;">
                                            <asp:Label ID="lbldate" runat="server"></asp:Label>

                                        </b></td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid; border-top: 0px; border-left: 0px;">
                                        <p style="font-size: 12px; font-family: Arial; margin: 0px;">Supplier's Ref.</p>
                                        <b style="font-family: Arial; font-size: 13px;">
                                            <asp:Label ID="lblsuplierref" runat="server"></asp:Label>

                                        </b></td>
                                    <td style="border: 1px solid; border-top: 0px; border-right: 0px; border-left: 0px;">
                                        <p style="font-size: 12px; font-family: Arial; margin: 0px;">Mode/Terms of Payment</p>
                                        <b style="font-family: Arial; font-size: 13px;">
                                            <asp:Label ID="lbltermsofpay" runat="server"></asp:Label>

                                        </b></td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid; border-top: 0px; border-left: 0px;">
                                        <p style="font-size: 12px; font-family: Arial; margin: 0px;">Buyer's Order No.</p>
                                        <b style="font-family: Arial; font-size: 13px;">
                                            <asp:Label ID="lblbuyer" runat="server"></asp:Label>

                                        </b></td>
                                    <td style="border: 1px solid; border-top: 0px; border-right: 0px; border-left: 0px;">
                                        <p style="font-size: 12px; font-family: Arial; margin: 0px;">Dispatch Document No.</p>
                                        <b style="font-family: Arial; font-size: 13px;">
                                            <asp:Label ID="lbldisdocno" runat="server"></asp:Label>

                                        </b></td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid; border-top: 0px; border-left: 0px;">
                                        <p style="font-size: 12px; font-family: Arial; margin: 0px;">Dispatch through</p>
                                        <b style="font-family: Arial; font-size: 13px;">
                                            <asp:Label ID="lbldispatch" runat="server"></asp:Label>

                                        </b></td>
                                    <td style="border: 1px solid; border-top: 0px; border-right: 0px; border-left: 0px;">
                                        <p style="font-size: 12px; font-family: Arial; margin: 0px;">Destination</p>
                                        <b style="font-family: Arial; font-size: 13px;">
                                            <asp:Label ID="lbldestination" runat="server"></asp:Label>

                                        </b></td>
                                </tr>

                                <tr>
                                    <td colspan="2" style="border-bottom: 0px;">
                                        <p style="font-size: 12px; font-family: Arial; margin: 0px;">Terms of Delivery</p>

                                        <asp:Label ID="lbltermofdelivery" runat="server"></asp:Label>
                                        <ul runat="server" id="KeyBenefityList">
                                        </ul>


                                    </td>

                                </tr>
                            </tbody>--%>
                                            </div>
                                        </div>

                                        <div style="font-family: Arial; width: 759px; min-height: 375px; float: left; margin-top: 5px;">
                                            <%--  <img id="bg" src="../images/1.png" style="background-repeat: repeat-y; width: 759px; z-index: 999999; position: absolute; height: 300px;" />--%>
                                            <table id="MyTable" cellpadding="0" cellspacing="0" style="width: 759px; height: auto; float: left;">

                                                <thead>
                                                    <tr>
                                                        <td style="font-family: Arial; font-size: 13px; color: white; text-align: center; width: 30%; padding: 5px; border-right: 1px solid white;"></td>
                                                        <td style="font-family: Arial; font-size: 13px; color: white; text-align: center; width: 12%; padding: 5px; border-right: 1px solid white;"></td>
                                                        <td style="font-family: Arial; font-size: 13px; color: white; text-align: center; width: 12%; padding: 5px; border-right: 1px solid white;"></td>
                                                        <td style="font-family: Arial; font-size: 13px; color: white; text-align: center; width: 15%; padding: 5px; border-right: 1px solid white;"></td>
                                                        <td style="font-family: Arial; font-size: 13px; color: white; text-align: center; width: 18%; padding: 5px; border-right: 1px solid white;"></td>
                                                        <td style="font-family: Arial; font-size: 13px; color: white; text-align: center; width: 15%; padding: 5px;"></td>
                                                    </tr>
                                                </thead>
                                                <tr>
                                                    <td colspan="6">
                                                        <img src="img/PrintInvoice/lable.png" />
                                                    </td>
                                                </tr>
                                                <asp:Repeater ID="grditemproduct" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td style="font-family: Arial; font-size: 12px; text-align: left; padding: 5px;">
                                                                <asp:Label ID="ltproductname" runat="server" Text='<%#Eval("Product_Name")%>'></asp:Label>
                                                                <asp:Label ID="ltproductcode" runat="server" Text='<%#Eval("Product_Code")%>' Visible="false"></asp:Label>
                                                                <asp:Label ID="ltitemid" runat="server" Text='<%#Eval("InDetail_ID")%>' Visible="false"></asp:Label></td>
                                                            <td style="font-family: Arial; font-size: 12px; text-align: center; padding: 5px;">

                                                                <asp:Label ID="Label4" Style="text-align: center; width: 389px; font-size: 12px; font-family: Arial;" Text='<%#Eval("Product_Code")%>' runat="server"></asp:Label>


                                                            </td>
                                                            <td style="font-family: Arial; font-size: 12px; text-align: center; padding: 5px;">
                                                                <asp:Label ID="ltquantity" Style="text-align: center; width: 389px; padding: 0 5px; font-size: 12px; font-family: Arial;" runat="server" Text='<%#Eval("InDetail_Qty")%>' Visible="false"></asp:Label>
                                                                <asp:Label ID="ltkg" Style="text-align: center; width: 389px; font-size: 12px; font-family: Arial;" Text='<%#Eval("Packing_Weight")%>' runat="server"></asp:Label>
                                                                <span style="font-size: 12px; font-family: Arial;">Kg</span>
                                                                <asp:HiddenField ID="hfPacking_Weight" runat="server" Value='<%#Eval("Packing_Weight")%>' />
                                                            </td>
                                                            <td style="font-family: Arial; font-size: 12px; text-align: center; padding: 5px;">
                                                                <img src="img/PrintInvoice/r.png" style="width: 7px; margin-right: 5px;" />
                                                                <asp:Label ID="ltPrdrate" runat="server" Text='<%#Eval("InDetail_Rate")%>'></asp:Label></td>
                                                            <td style="font-family: Arial; font-size: 12px; text-align: right; padding: 5px;">
                                                                <img src="img/PrintInvoice/r.png" style="width: 7px; margin-right: 5px;" />
                                                                <asp:Label ID="lblvatinrs" runat="server" Text='<%#Eval("InDetail_Vat")%>' />
                                                                <asp:HiddenField ID="hflblvatinrs" runat="server" />
                                                                <span style="font-size: x-small;">(<asp:Label ID="lblvat" runat="server" />%)</span></td>
                                                            <td style="font-family: Arial; font-size: 12px; text-align: right; padding: 5px;">
                                                                <img src="img/PrintInvoice/r.png" style="width: 7px; margin-right: 5px;" />
                                                                <asp:Label ID="ltamount" runat="server" Text='<%#Eval("InDetail_Amount")%>'></asp:Label>
                                                                <asp:HiddenField ID="hfltamount" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>


                                        </div>
                                        <table id="tblsub" cellpadding="0" cellspacing="0" style="width: 759px; height: auto; float: left;">
                                            <tr>
                                                <td style="font-family: Arial; font-size: 12px; text-align: right; width: 18%; padding: 5px; border-top: 1px Solid rgb(0, 0, 0);">NET WT</td>
                                                <td style="font-family: Arial; font-size: 12px; text-align: center; width: 1%; padding: 5px; border-top: 1px Solid rgb(0, 0, 0);">
                                                    <asp:Label ID="lbltotalkg" Text='20' runat="server"></asp:Label>Kg
                                                </td>
                                                <td style="font-family: Arial; font-size: 12px; text-align: center; width: 1%; padding: 5px; border-top: 1px Solid rgb(0, 0, 0);"></td>
                                                <td style="font-family: Arial; font-size: 12px; text-align: right; width: 13%; padding: 5px; border-top: 1px Solid rgb(0, 0, 0);">SUB TOTAL</td>
                                                <td style="font-family: Arial; font-size: 12px; text-align: right; width: 2%; padding: 5px; border-top: 1px Solid rgb(0, 0, 0);">
                                                    <img src="img/PrintInvoice/r.png" style="width: 7px; margin-right: 5px;" /><asp:Label ID="lblsubtotal" Text='78500' runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                        <table id="tblsub" cellpadding="0" cellspacing="0" style="width: 759px; height: auto; float: left;">
                                            <tr>
                                                <td style="font-family: Arial; width: 28%; font-size: 12px; text-align: left; padding: 5px;"><small style="font-size: 12px; font-family: Arial;">Amount Chargeable (in words):</small></td>
                                                <td style="font-family: Arial; width: 41%; font-size: 12px; text-align: left; padding: 5px;">
                                                    <asp:Label runat="server" ID="lblamountword" Style="font-weight: bold; font-size: 12px; font-family: Arial;"></asp:Label></td>
                                                <td style="font-family: Arial; width: 0%; font-size: 12px; text-align: center; padding: 5px;"></td>
                                                <td style="font-family: Arial; width: 3%; font-size: 12px; text-align: right; padding: 5px;">VAT/CST</td>
                                                <td style="font-family: Arial; width: 14%; font-size: 12px; text-align: right; padding: 5px;">
                                                    <img src="img/PrintInvoice/r.png" style="width: 7px; margin-right: 5px;" /><asp:Label ID="lttotalvat" Text='78500' runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="font-family: Arial; font-size: 12px; text-align: left; padding: 5px;"><small style="font-size: 12px; font-family: Arial;">VAT Amount (in words):</small></td>
                                                <td style="font-family: Arial; font-size: 12px; text-align: left; padding: 5px;">
                                                    <asp:Label runat="server" ID="lblvatword" Style="font-weight: bold; font-size: 12px; font-family: Arial;"></asp:Label></td>
                                                <td style="font-family: Arial; font-size: 12px; text-align: center; padding: 5px;"></td>
                                                <td style="font-family: Arial; font-size: 12px; text-align: right; padding: 5px;">FREIGHT</td>
                                                <td style="font-family: Arial; font-size: 12px; text-align: right; padding: 5px;">
                                                    <img src="img/PrintInvoice/r.png" style="width: 7px; margin-right: 5px;" /><asp:Label ID="lblfreight" Text='78500' runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                        <table id="tblsub" cellpadding="0" cellspacing="0" style="width: 759px; height: auto; float: left;">
                                            <tr>
                                                <td style="font-family: Arial; font-size: 12px; text-align: right; padding: 5px;"></td>
                                                <td style="font-family: Arial; font-size: 12px; text-align: center; padding: 5px;"></td>
                                                <td style="font-family: Arial; font-size: 12px; text-align: center; padding: 5px;"></td>
                                                <td style="font-family: Arial; width: 25%; border-top: 1px solid; font-size: 12px; text-align: right; padding: 5px;"><b>GRAND TOTAL (ROUNDED)</b></td>
                                                <td style="font-family: Arial; border-top: 1px solid; width: 13%; font-size: 12px; text-align: right; padding: 5px; font-weight: bold;">
                                                    <img src="img/PrintInvoice/r.png" style="width: 7px; margin-right: 5px;" /><asp:Label ID="lttotalamount" Text='78500' runat="server"></asp:Label></td>
                                            </tr>
                                        </table>

                                        <%--       <table cellpadding="0" cellspacing="0" style="width: 759px; height: auto; float: left;">
                                            <tr>
                                                <td><small style="font-size: 12px; font-family: Arial;">&nbsp;&nbsp;Amount Chargeable (in words):&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </small>
                                                    <asp:Label runat="server" ID="lblamountword1" Style="font-weight: bold; font-size: 12px; font-family: Arial;"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><small style="font-size: 12px; font-family: Arial;">&nbsp;&nbsp;VAT Amount (in words):&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</small>
                                                    <asp:Label runat="server" ID="lblvatword1" Style="font-weight: bold; font-size: 12px; font-family: Arial;"></asp:Label></td>
                                            </tr>
                                        </table>--%>
                                        <div style="width: 759px; height: auto; float: left;">
                                            <div style="width: 48.4%; height: auto; float: left; padding: 5px;">
                                                <table style="text-align: left; width: 100%;" cellspacing="0" cellpadding="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px; width: 40%">Supplier Reference     
                                                            </td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">:</td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">
                                                                <asp:Label ID="lblsuplierref" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 125px; font-size: 12px; font-family: Arial; margin: 0px;">Buyer Order No.
                                                            </td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">:
                                                            </td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">
                                                                <asp:Label ID="lblbuyer" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">Dispatch Document No</td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">:</td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">
                                                                <asp:Label ID="lbldisdocno" runat="server"></asp:Label></td>
                                                        </tr>
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
                                                        <tr>
                                                            <td style="font-size: 13px; font-family: Arial; margin: 0px;">Form No
                                                               

                                                            </td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">:</td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">
                                                                <asp:Label ID="lblFormNo" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-size: 13px; font-family: Arial; margin: 0px;">Key No
                                                               

                                                            </td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">:</td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">
                                                                <asp:Label ID="lblKeyNo" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-size: 13px; font-family: Arial; margin: 0px;">Purchase Id
                                                               

                                                            </td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">:</td>
                                                            <td style="font-size: 12px; font-family: Arial; margin: 0px;">
                                                                <asp:Label ID="lblPurchaseID" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <%--        <tr>
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0" style="height: 60px;">
                                                                    <tr>
                                                                        <td style="vertical-align: top;">
                                                                            <p style="font-size: 12px; font-family: Arial; margin: 0px; padding: 0;">Terms of Delivery&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: </p>
                                                                        </td>
                                                                        <td style="vertical-align: top;">
                                                                            <ul runat="server" id="KeyBenefityList" style="padding-left: 3px;"></ul>
                                                                        </td>
                                                                    </tr>
                                                                </table>






                                                            </td>
                                                        </tr>--%>
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

                                            <div id="otherbank" runat="server" style="width: 48.4%; height: auto; float: left; padding: 5px;">
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
        </div>
    </form>


</body>
</html>
