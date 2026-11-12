<%@ Page Language="VB" AutoEventWireup="false" CodeFile="compare.aspx.vb" Inherits="compare" MaintainScrollPositionOnPostback="true" %>

<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>Compare Page</title>
    <style>
        table {
            font-family: arial;
            text-align: center;
            min-width: 100%;
        }

        table, td, th {
            border: 1px solid #bbb;
            min-width:50%;
            max-width:50%;
        }

        #table1 {
            border-collapse: collapse;
             margin: 0px 2px;
        }

        td {
            font-size: 13px;
            font-family: arial;
        }
    </style>
    <style>

       
 .btn-recp {
    background-color:  #ce6161;
    border-color: #7db831;
    color: #ffffff;
}
        .btn-success {
    background-color: #aad178;
    border-color: #7db831;
    color: #ffffff;
}
        .btn-xs {
    padding: 1px 5px;
    font-size: 12px;
    line-height: 1.5;
    border-radius: 3px;
}
        .btn {
    display: inline-block;
    margin-bottom: 0;
    font-weight: normal;
    text-align: center;
    vertical-align: middle;
    cursor: pointer;
    background-image: none;
    border: 1px solid transparent;
    white-space: nowrap;
    /*padding: 6px 12px;
    font-size: 14px;*/
    line-height: 1.42857143;
    border-radius: 4px;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
}
    </style>
</head>
<body>
        <form id="form" runat="server"  style="display: flex;">
    <%--<div class="head">
        <p><strong>Choco Mixed</strong></p>
    </div><br />
    <div>&nbsp;</div>--%>
        <asp:HiddenField ID="hfAccessFor" runat="server" />

    <asp:Repeater ID="rptmaidq" runat="server">
        <ItemTemplate>
            <table id="table1">
                <tr ID="trTialHead" runat="server">
                    <th colspan="5" style="padding-top:10px; padding-bottom:10px;">
                        <asp:Label ID="Label1" CssClass="hidden1" Value='<%# "F" + Eval("Formulation_Id").ToString%>' runat="server" Style="display: none;" />
                        <asp:Label ID="lblTrialCode" runat="server" Text='<%#Replace(Eval("Formulation_No"),"FR","TR")%>'></asp:Label>
                        &nbsp;&nbsp;| Status:<asp:Label ID="lblTrialStatus" Text='<%#Eval("Trial_Approved")%>' runat="server"></asp:Label>
                        &nbsp;&nbsp;<asp:Label ID="lblProdName" Text='<%#"| "+Eval("Formulation_ProdName")%>' runat="server"></asp:Label>&nbsp;&nbsp;
                    </th>

                </tr>
                <tr ID="trFormTableHead" runat="server">
                    <th colspan="5">Formulation
                        <asp:Label ID="hfpFormulation" CssClass="hidden1" Value='<%# "F" + Eval("Formulation_Id").ToString%>' runat="server" Style="display: none;" />
                        <asp:Label ID="lblDescptn" runat="server" Text='<%#Eval("Formulation_No")%>' Visible="false"></asp:Label>
                        <asp:Label ID="lblqtn" runat="server" Text='<%#Eval("Formulation_Id")%>' Visible="false"></asp:Label>
                        <%--&nbsp;&nbsp;|Version:--%><asp:Label ID="lblversion" runat="server" Visible="false"></asp:Label>&nbsp;&nbsp;|&nbsp;
                        Amount:<asp:Label ID="lblamt" runat="server"></asp:Label>&nbsp;&nbsp;
                     <asp:LinkButton ID="btnsubmit" ClientIDMode="AutoID" CssClass="btn btn-xs btn-success"   runat="server" Text="Copy"  CommandName="copyfom"></asp:LinkButton>
                    </th>

                </tr>
                <tr ID="trFormTableBody" runat="server">
                    <th>Raw Material</th>
                    <th>QTY(%)</th>
                    <th>QTY(KG)</th>
                    <th>QTY(GM)</th>
                    <th>Cost</th>

                </tr>
                <asp:Repeater ID="rptRaw" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Literal ID="ltRawMID" runat="server" Text='<%#Eval("FRawM_RawMID")%>' Visible="false"></asp:Literal>
                                <asp:Literal ID="ltproductname" runat="server" Text='<%#Eval("Rm_Name")%>'></asp:Literal>
                                <asp:Literal ID="ltitemid" runat="server" Text='<%#Eval("Formulation_Id")%>' Visible="false"></asp:Literal>

                            </td>
                            <td>
                                <asp:Literal ID="ltqtyper" runat="server" Text='<%#Convert.ToDecimal(Eval("FRawM_Percentage")).ToString()%>'></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltqtykg" runat="server" Text='<%#Convert.ToDecimal(Eval("FRawM_QtyKg"))%>'></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltqtygm" runat="server" Text='<%#Convert.ToDecimal(Eval("FRawM_QtyGm"))%>'></asp:Literal></td>
                            <td>₹<asp:Literal ID="ltcost" runat="server" Text='<%#Convert.ToDecimal(Eval("FRawM_Cost"))%>'></asp:Literal></td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

                <tr ID="trFormTableFooter1" runat="server">
                    <td colspan="3" rowspan="3">&nbsp;</td>
                    <td><strong>Total Cost :</strong></td>
                    <td>₹
                            <asp:Label ID="lblTotalCost" runat="server" Text="₹37,551.75"></asp:Label></td>
                </tr>
           
                <tr ID="trFormTableFooter2" runat="server">                    
                    <td><strong>Total QTY(KG) :</strong></td>
                    <td>
                        <asp:Label ID="lblQuantityFoot" runat="server" Text="0.75 KG"></asp:Label>
                        KG</td>
                </tr>
                <tr ID="trFormTblFootPerKg" runat="server">                    
                    <td><strong>Cost/KG :</strong></td>
                    <td>₹
                        <asp:Label ID="lblCostPerKg" runat="server" Text="0.75"></asp:Label>
                        </td>
                </tr>

                <tr ID="trFormTableFooter3" runat="server">                    
                    <td colspan="5">&nbsp;</td>
                </tr>
                
                <asp:Repeater ID="rptmainRcp" runat="server" OnItemDataBound="rptmainRcp_ItemDataBound" OnItemCommand="rptmainRcp_ItemCommand" >
                    <ItemTemplate>
                        <tr>
                            <th colspan="5">Recipe
                                <asp:Label ID="lblRcpNo" runat="server" Text='<%#Eval("Recipe_No")%>' Visible="false"></asp:Label>

                                <asp:Label ID="lblrcpid" runat="server" Text='<%#Eval("Recipe_Id")%>' Visible="false"></asp:Label>
                                <%--&nbsp;&nbsp;| Status:--%><asp:Label ID="lblversion1" Text='<%#Eval("Recipe_Approved")%>' runat="server" Visible="false"></asp:Label>&nbsp;&nbsp;
                                      <asp:LinkButton ID="btnsubmit" ClientIDMode="AutoID" CssClass="btn btn-xs btn-recp"   runat="server" Text="Copy"  CommandName="copyrecp"></asp:LinkButton>                   
                            </th>

                        </tr>
                        <tr>
                            <th colspan="5">Ingredients</th>

                        </tr>
                        <tr>
                            <td><strong>Name</strong></td>
                            <td colspan="2"><strong>Value</strong></td>
                            <td colspan="2"><strong>Percentage</strong></td>
                        </tr>
                        <%--<tr>
                            <td colspan="5">&nbsp;</td>
                        </tr>--%>
                        <asp:Repeater ID="rptRcpIng" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Literal ID="ltproductname" runat="server" Text='<%#Eval("RecipeIngredient_Name")%>'></asp:Literal>
                                        <asp:Literal ID="ltitemid" runat="server" Text='<%#Eval("RecipeIngredient_Name")%>' Visible="false"></asp:Literal>


                                    </td>
                                    <td colspan="2">
                                        <asp:Literal ID="ltproductcode" runat="server" Text='<%#Eval("RecipeIngredient_Value")%>'></asp:Literal>
                                        <asp:Label ID="ltitemtypeid" runat="server" Text='<%#Eval("RecipeIngredient_Value")%>' Visible="false"></asp:Label>
                                    </td>
                                    <td colspan="2">&nbsp;
                                        <asp:Literal ID="ltproductWeight" runat="server" Text='<%#Eval("RecipeIngredient_Percent")%>' Visible="false"></asp:Literal>
                                        <asp:Literal ID="ltIngredient_Percent" runat="server" Text='<%#Eval("RecipeIngredient_Percent")%>'></asp:Literal>
                                    </td>

                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <td colspan="5">&nbsp;</td>

                        </tr>


                        <tr>
                            <th colspan="5"><strong>Procedure</strong></th>

                        </tr>
                        <tr>
                            <td><strong>Step</strong></td>
                            <td colspan="2"><strong>Term</strong></td>
                            <td colspan="2"><strong>Term/Value</strong></td>

                        </tr>
                        <asp:Repeater ID="RptProcedure" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Literal ID="ltproductname" runat="server" Text='<%#Eval("RecipeProcedure_Step")%>'></asp:Literal>
                                        <asp:Literal ID="ltitemid" runat="server" Text='<%#Eval("RecipeProcedure_Step")%>' Visible="false"></asp:Literal>


                                    </td>
                                    <td colspan="2">
                                        <asp:Literal ID="ltproductcode" runat="server" Text='<%#Eval("RecipeProcedure_Term")%>'></asp:Literal>
                                        <asp:Label ID="ltitemtypeid" runat="server" Text='<%#Eval("RecipeProcedure_Term")%>' Visible="false"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <asp:Literal ID="ltproductWeight" runat="server" Text='<%#Eval("RecipeProcedure_Time")%>' Visible="false"></asp:Literal>
                                        <asp:Literal ID="ltpackingpacking" runat="server" Text='<%#Eval("RecipeProcedure_Time")%>'></asp:Literal>
                                    </td>

                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                        <tr>
                            <td colspan="5">&nbsp;</td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr ID="tr1" runat="server" visible="false">                    
                    <td colspan="5">&nbsp;
                        Remark:
                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("Formulation_StatusRemark")%>'></asp:Label>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:Repeater>
        </form>
</body>
</html>
