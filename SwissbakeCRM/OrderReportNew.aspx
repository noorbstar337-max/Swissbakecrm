<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="OrderReportNew.aspx.vb" Inherits="OrderReportNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header">
        <div class="header-section">
            <h2>
                <i class="gi gi-check"></i>Order Report
            </h2>
        </div>
    </div>
    <ul class="breadcrumb breadcrumb-top">
        <li><a href="Index.aspx">Home</a></li>
        <li>Order Report</li>
    </ul>
    <div class="block full">
        <div class="block-title">
            <h2><strong>Order</strong> List</h2>
        </div>
        <div class="row">
            <div class="form-horizontal form-bordered">
                <div class="col-md-12">
                    <div class="col-md-5">
                        <label class="col-md-1 control-label">From</label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtfrom" runat="server" class="form-control" placeholder="Enter From Date" TextMode="Date" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfrom" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                ErrorMessage="Enter From date" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-1 control-label">To</label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtto" runat="server" class="form-control" placeholder="Enter To Date" TextMode="Date" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                ErrorMessage="Enter To date" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ErrorMessage="Enter Valid date" CssClass="MasterValidationCSS" ControlToCompare="txtfrom" ControlToValidate="txtto" Operator="GreaterThanEqual" ValidationGroup="MasterGroup"></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnSubmit" ValidationGroup="MasterGroup" runat="server" TabIndex="4" Text="Submit" CssClass="btn btn-sm btn-primary" />
                        <asp:Button ID="btnExport" runat="server" CssClass="btn btn-alt btn-sm btn-success" CausesValidation="false" Text="Export to Excel" />
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="table-responsive" id="tblGrid" runat="server">
            <table id="example-datatable" class=" MultiDatatable table table-vcenter table-condensed table-bordered">
                <thead>
                    <tr>
                        <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 50px">SrNo.</th>
                        <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 200px">Company</th>
                        <%--<th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Company Code</th>--%>
                        <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 200px">Contact Person</th>                        
                        <%--<th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Category</th>--%>
                        <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 200px">Product Name</th>
                       <%-- <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Product Code</th>--%>
                        <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 150px">Rate / KG (<i class="fa fa-inr " />)</th>
                        <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Quantity</th>
                        <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Total (<i class="fa fa-inr " />)</th>
                        <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Owner</th>
                        <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Email</th>
                        <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">Mobile</th>
                        <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 150px">Order Code</th>
                       <%-- <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">City</th>
                        <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; width: 100px">State</th>--%>                        
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpOrderReport" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="text-center" style="width: 50px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("SrNo"))%></td>
                                <td class="text-center" style="width: 200px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_Name"))%></td>
                                <%--<td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_Code"))%></td>--%>
                                <td class="text-center" style="width: 200px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Contact Person"))%></td>   
                                <%--<td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("PrdCategory_Name"))%></td>--%>
                                <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Product_Name"))%></td>
                                <%--<td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Product_Code"))%></td>--%>
                                <td class="text-center" style="width: 150px"><i class="fa fa-inr " />&nbsp;<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("OrDetail_Rate"))%></td>
                                <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("OrDetail_Qty"))%>&nbsp;KG</td>
                                <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("[Total]"))%></td> 
                                <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("[Contact_ContactPerson]"))%></td>                               
                                <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("[Contact_Email]"))%></td>
                                <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("[Contact_Mobile]"))%></td>   
                                <td class="text-center" style="width: 150px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("[Order_Code]"))%></td>                               
                                <%--<td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("[U_City]"))%></td>
                                <td class="text-center" style="width: 100px"><%#DynamicparcelDataManipulation.FixNullFromDB(Eval("[STATE]"))%></td>   --%>
                                  
                            </tr>
                        </ItemTemplate>

                        <FooterTemplate>
                            <tr style="font-size: 16px; font: bold;" id="trFooter" runat="server">
                                <td class="text-right" style="width: 100px;" colspan="6">Total</td>
                                <%--<td class="text-center" style="width: 100px">
                                    <asp:Label ID="lblQty" runat="server" />&nbsp;<i class="fa">KG</i></td>
                                <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lblAmount" runat="server" /></td>
                                <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lblGST" runat="server" /></td>
                                <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lblFreight" runat="server" /></td>--%>
                                <td class="text-center" style="width: 100px"><i class="fa fa-inr " />&nbsp;<asp:Label ID="lblAmountTot" runat="server" /></td>

                            </tr>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </tbody>
                <tfoot>
                </tfoot>

            </table>
            <asp:Label ID="lblfoot" Text="No records found" Visible="false" runat="server"></asp:Label>

        </div>
    </div>
</asp:Content>

