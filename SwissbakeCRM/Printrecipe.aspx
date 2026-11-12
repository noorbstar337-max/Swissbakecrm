<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Printrecipe.aspx.vb" Inherits="Printrecipe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<link rel="stylesheet" href="css/bootstrap-print.min.css" />--%>
    <style>
        .bdbt {
            border-bottom: 1px solid black;
        }

    </style>
</head>
<body style="padding: 0; margin: 0;" onload="window.print()">
    <form id="form1" runat="server">
        <div style="width: 11.69in; height: 8.00in;">
            <div style="padding: 5px;" runat="server" id="divfill">
                <div style="background-color: black; color: white; padding: 5px;">
                    Recipe (<asp:Label runat="server" ID="lblrecno" ></asp:Label>)<asp:Label runat="server" ID="lblapproved" Style="float: right;"></asp:Label>
                </div>
                <div class="bdbt" style="width:100%; display:flex;">
                    <div style="width:50%;">
                        Product Code : <b>
                            <asp:Label runat="server" ID="lblproductcode"></asp:Label></b>
                    </div>
                    <div style="width:50%; display:none;">
                        Trial No. : <b>
                            <asp:Label runat="server" ID="lblFormno"></asp:Label></b>
                    </div>
                </div>
                <div class="bdbt" style="width:100%; display:flex;">
                    <div style="margin-right:5px;">Machines</div>
                    <div style="width:25%;">
                        Mixer : <b>
                            <asp:Label runat="server" ID="lblmix"></asp:Label></b>
                    </div>
                    <div style="width:25%;">
                        Blade : <b>
                            <asp:Label runat="server" ID="lblblade"></asp:Label></b>
                    </div>
                    <div style="width:25%;">
                        Mould : <b>
                            <asp:Label runat="server" ID="lblMould"></asp:Label></b>
                    </div>
                    <div style="width:25%;">
                        Oven : <b>
                            <asp:Label runat="server" ID="lbloven"></asp:Label></b>
                    </div>
                </div>
                <div class="bdbt" style="width:100%; display:flex;">
                    <div style="width:50%; border-right: 1px dotted black; padding:0 5px;">
                        <table style="width: 100%;" cellpadding="5">
                            <tbody>
                                <tr>
                                    <td colspan="3">Ingredients</td>
                                </tr>

                                <asp:Repeater runat="server" ID="rping">
                                    <HeaderTemplate>
                                        <tr>
                                            <td style="border: none;">Name</td>
                                            <td style="border: none;">Value</td>
                                            <td style="border: none;">Percentage</td>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td style="border: 1px solid;">
                                                <asp:Label runat="server" ID="lblname" Text='<%#Eval("recipeingredient_name")%>'></asp:Label></td>
                                            <td style="border: 1px solid;">
                                                <asp:Label runat="server" ID="Label1" Text='<%#Eval("recipeingredient_value")%>'></asp:Label>
                                                &nbsp;<asp:Label runat="server" Text=" GM" Style="margin: 4px 0px;"></asp:Label>
                                            </td>
                                            <td style="border: 1px solid;">
                                                <asp:Label runat="server" ID="Label2" Text='<%#Eval("recipeingredient_Percent")%>'></asp:Label></td>
                                        </tr>
                                    </ItemTemplate>

                                </asp:Repeater>
                            </tbody>
                        </table>
                        <div>
                            Remark : 
                        <asp:Label runat="server" ID="lblrremar" Text=""></asp:Label>
                        </div>
                    </div>
                    <div style="width:50%;padding:0 5px;">
                        <table style="width: 100%; float: right;" cellpadding="5">
                            <tbody>
                                <tr>
                                    <td colspan="3">Procedure</td>
                                </tr>

                                <asp:Repeater runat="server" ID="rpprod">
                                    <HeaderTemplate>
                                        <tr>
                                            <td style="border: none;">Method</td>
                                            <td style="border: none;">Term</td>
                                            <td style="border: none;">Time/Value </td>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td style="border: 1px solid;">
                                                <asp:Label runat="server" ID="lblname" Text='<%#Eval("recipeprocedure_Term")%>'></asp:Label></td>
                                            <td style="border: 1px solid;">
                                                <asp:Label runat="server" ID="Label1" Text='<%#Eval("recipeprocedure_Term")%>'></asp:Label></td>
                                            <td style="border: 1px solid;">
                                                <asp:Label runat="server" ID="Label2" Text='<%#Eval("recipeprocedure_Time")%>'></asp:Label></td>
                                        </tr>
                                    </ItemTemplate>

                                </asp:Repeater>
                            </tbody>
                        </table>
                        <div>
                            Remark :<asp:Label runat="server" ID="lblpremark" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
               
            </div>
            <%--blank div start--%>
            <div style="padding: 5px;" runat="server" id="divblank">
                <div style="background-color: black; color: white; padding: 5px;">
                    Recipe(<asp:Label runat="server" ID="lblrecipeno2" ></asp:Label>)<asp:Label runat="server" ID="Label4" Style="float: right;"></asp:Label>                   
                </div>
                <div class="bdbt" style="width:100%;  display:flex;">
                    <div style="width:50%;">
                        Product Code : <b>
                            <asp:Label runat="server" ID="lblproductcode1"></asp:Label></b>
                    </div>
                    <div style="width:50%; display:none;">
                        Trail No. : <b>
                            <asp:Label runat="server" ID="lblFormno1"></asp:Label></b>
                    </div>
                </div>
                <div class="bdbt" style="width:100%; display:flex;">
                    <div style="margin-right:5px">Machines</div>
                    <div style="width:25%;">
                        Mixer : <b>
                            <asp:Label runat="server" ID="Label7"></asp:Label></b>
                    </div>
                    <div style="width:25%;">
                        Blade : <b>
                            <asp:Label runat="server" ID="Label8"></asp:Label></b>
                    </div>
                    <div style="width:25%;">
                        Mould : <b>
                            <asp:Label runat="server" ID="Label9"></asp:Label></b>
                    </div>
                    <div style="width:25%;">
                        Oven : <b>
                            <asp:Label runat="server" ID="Label10"></asp:Label></b>
                    </div>
                </div>
                <div style="width:100%; display:flex;">
                    <div style="width:50%;border-right: 1px dotted black; padding: 0 5px;">
                        <table style="width: 100%;" cellpadding="5">
                            <tbody>
                                <tr>
                                    <td colspan="3">Ingredients</td>
                                </tr>
                                <tr>
                                    <td style="border: none;">Name</td>
                                    <td style="border: none;">Value</td>
                                    <td style="border: none;">Percentage</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>

                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>

                            </tbody>
                        </table>
                        <div>
                            Remark :
                    <asp:Label runat="server" ID="Label11"></asp:Label>
                        </div>
                    </div>
                    <div  style="width:50%; padding: 0 5px;">
                        <table style="width: 100%;" float: right; cellpadding="5">
                            <tbody>
                                <tr>
                                    <td colspan="3">Procedure</td>
                                </tr>
                                <tr>
                                    <td style="border: none;">Method</td>
                                    <td style="border: none;">Term</td>
                                    <td style="border: none;">Time/Value </td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                    <td style="border: 1px solid;">&nbsp;</td>
                                </tr>
                            </tbody>
                        </table>

                        <div>
                            Remark :
                    <asp:Label runat="server" ID="Label12"></asp:Label>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
