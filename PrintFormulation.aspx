<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PrintFormulation.aspx.vb" Inherits="PrintFormulation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
</head>
<body style="padding: 0; margin: 0;" onload="window.print()">
    <form id="form1" runat="server">
<%--              <div>
             <input type="button" value="Print Invoice" onclick="javascript: printDiv(&#39;printablediv&#39;)" style="width: 138px;    margin-left: 4.5in; border: 1px solid #A39A9A; padding: 7px; background-color: #B31616; color: white;  margin-right: 791px;margin-top: 14px; margin-bottom:20px;" />

        </div>
        <div id="printablediv">--%>
        <div style="width: 11.69in; height: 8.00in;">
            <div style="padding: 5px;" runat="server" id="divfill">
                <div style="background-color: #394263; color: white; padding: 5px;">
                    Formulation (<asp:Label runat="server" ID="lblFormulationno"></asp:Label>)<asp:Label runat="server" ID="lblapproved" Style="float: right;"></asp:Label>
                </div>
                <div style="width:100%;display:flex;padding:1px">
                    <div style="width:25%">
                        Formulation Type : <b>
                            <asp:Label runat="server" ID="lblformulationtype"></asp:Label></b>
                    </div>
                    <div style="width:40%">
                        Product Code : <b>
                            <asp:Label runat="server" ID="lblproductcode"></asp:Label></b>
                    </div>
                    <div style="width:17.5%">
                        Mix Type : <b>
                            <asp:Label runat="server" ID="lblmixtype"></asp:Label></b>
                    </div>
                    <div style="width:17.5%">
                        Quantity(KG) : <b>
                            <asp:Label runat="server" ID="lblformulationqty"></asp:Label></b>
                    </div>
                </div>
                <hr />
                <div>
                    <table style="width: 100%;" cellpadding="5">
                        <tbody>
                            <tr>
                                <td colspan="3">Formulation Table</td>
                            </tr>

                            <asp:Repeater runat="server" ID="rpformulation">
                                <HeaderTemplate>
                                    <tr>
                                        <td style="border: none; text-align: center;">RAW MATERIAL</td>
                                        <td style="border: none; text-align: center;">QUANTITY(%)</td>
                                        <td style="border: none; text-align: center;">QUANTITY(KG)</td>
                                        <td style="border: none; text-align: center;">QUANTITY(GM)</td>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="border: 1px solid;">
                                            <asp:DropDownList ID="ddlRM" runat="server" CssClass="form-control select-chosen " Visible="false"></asp:DropDownList>
                                            <asp:Label runat="server" ID="lblname" Visible="false" Text='<%#Eval("FRawM_RawMID")%>'></asp:Label>
                                            <asp:Label runat="server" ID="lblpname"></asp:Label>
                                        </td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="Label1" Text='<%#Convert.ToDouble(Eval("FRawM_Percentage")).ToString("0.00")%>'></asp:Label></td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="Label2" Text='<%#Convert.ToDouble(Eval("FRawM_QtyKg")).ToString("0.000")%>'></asp:Label></td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="Label3" Text='<%#Convert.ToDouble(Eval("FRawM_QtyGm")).ToString("0.0")%>'></asp:Label></td>
                                    </tr>
                                </ItemTemplate>

                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
                <hr />
                <div runat="server" visible="false">
                    Remark :
                    <asp:Label runat="server" ID="lblremark"></asp:Label>
                </div>
            </div>
            <div style="padding: 5px;" runat="server" id="divblank">
                <div style="background-color: #394263; color: white; padding: 5px;">
                    Formulation (<asp:Label runat="server" ID="lblformulationno2"></asp:Label>)<asp:Label runat="server" ID="Label5" Style="float: right;"></asp:Label>
                </div>
                <div style="margin-top: 28px;">
                    <div style="margin-top: -18px; margin-left: 01px;">
                        Formulation Type : <b>
                            <asp:Label runat="server" ID="Label6"></asp:Label></b>
                    </div>
                    <div style="margin-top: -19px; margin-left: 290px;">
                        Product Code : <b>
                            <asp:Label runat="server" ID="Label7"></asp:Label></b>
                    </div>
                    <div style="margin-top: -19px; margin-left: 660px;">
                        Mix Type : <b>
                            <asp:Label runat="server" ID="Label8"></asp:Label></b>
                    </div>
                    <div style="margin-top: -18px; margin-left: 843px;">
                        Quantity(KG) : <b>
                            <asp:Label runat="server" ID="Label9"></asp:Label></b>
                    </div>
                </div>
                <hr />
                <div>
                    <table style="width: 100%;" cellpadding="5">
                        <tbody>
                            <tr>
                                <td colspan="3">Formulation Table</td>
                            </tr>
                            <tr>
                                <td style="border: none; text-align: center;">RAW MATERIAL</td>
                                <td style="border: none; text-align: center;">QUANTITY(%)</td>
                                <td style="border: none; text-align: center;">QUANTITY(KG)</td>
                                <td style="border: none; text-align: center;">QUANTITY(GM)</td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>                            <tr>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>                            <tr>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>                            <tr>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>                            <tr>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>                            <tr>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>                            <tr>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>                            <tr>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>                            <tr>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>                            <tr>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>                            <tr>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>                            <tr>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>                            <tr>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>                            <tr>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>                            <tr>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>                            <tr>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>                        </tbody>
                    </table>
                </div>
                <hr />
                <div runat="server" visible="false">
                    Remark :
                    <asp:Label runat="server" ID="Label10"></asp:Label>
                </div>
            </div>
        </div>
            <%--</div>--%>
    </form>
</body>
</html>
