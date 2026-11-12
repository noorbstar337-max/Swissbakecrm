<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ProductWisePriceList.aspx.vb" Inherits="ProductWisePriceList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="block full">
           <div class="block-title">
               <h2><strong><asp:Label ID="lblProdName" runat="server"></asp:Label></strong>&nbsp;&nbsp;&nbsp;(<asp:Label ID="lblSKU" runat="server"></asp:Label>)&nbsp;&nbsp;&nbsp;Rate&nbsp;(&#8377<asp:Label ID="lblRate" runat="server"></asp:Label>) </h2>            
        </div>
       <div class="table-responsive">
            <asp:Panel ID="pnldemo" runat="server">
               
                
                <table id="example-datatable" class=" MultiDatatable table table-vcenter table-condensed table-bordered">
                    <thead>
                        <tr>
                            <%--<th class="text-center" style="display: none">Discount ID</th>--%>    
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Account Name</th>
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Selling Price&nbsp;(<i class ="fa fa-inr "/>)</th> 
                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Industry</th> 
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpPriceList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <%--<td class="text-center" style="width: 100px; display: none;"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Discount_ID"))%></td>--%> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_Name"))%></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Price"))%></td> 
                                    <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Industry_Name"))%></td> 
                                   <%-- <td  class="text-center" style="width: 100px">
                                        <asp:HyperLink ID="HyperLink1" EnableViewState="false" NavigateUrl='<%# "ProductWisePriceList.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Product_Id").ToString()))%>'
                                                data-toggle="tooltip" title="View" runat="server">
                                            <asp:Literal ID="lblcontact" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Min_Price"))%>' EnableViewState="false" />
                                        </asp:HyperLink>
                                    </td> --%>
                                    <%--<td class="ex1 text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Min_Price"))%></td>--%> 
                                   <%-- <td class="text-center" style="width: 100px" >
                                         <asp:HyperLink ID="HyperLink2" EnableViewState="false" NavigateUrl='<%# "ProductWisePriceList.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Product_Id").ToString()))%>'
                                                data-toggle="tooltip" title="View" runat="server">
                                            <asp:Literal ID="Literal1" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Max_Price"))%>' EnableViewState="false" />
                                        </asp:HyperLink>
                                    </td>  --%>
                                    <%--<td class="text-center" style="width: 100px" ><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Max_Price"))%></td>--%>
                                </tr>
                            </ItemTemplate>

						<%--	<FooterTemplate>
								<tr style="font-size: 16px; font: bold;">
									<td class="text-center" style="width: 100px;" colspan="6">Total</td>
									<td class="text-center" style="width: 100px">
										<asp:Label ID="TotalQty" runat="server" />&nbsp;<i class="fa">KG</i></td>
									<td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="TotalProfit" runat="server" /></td>
									<td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="TotalSales" runat="server" /></td>
								</tr>
								</table>
							</FooterTemplate>--%>
                        </asp:Repeater>
                    </tbody>
                    <tfoot>
                    </tfoot> 
                </table>
                <asp:Label ID="lblfoot" Text="No records found" Visible="false"  runat="server" ></asp:Label>
            </asp:Panel>
        </div>
    </div>
</asp:Content>

