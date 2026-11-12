<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="SalesAchievedIndividual.aspx.vb" Inherits="SalesAchievedIndividual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="Hfgridview" runat="server" />
    <asp:HiddenField ID="hftotalrecord" runat="server" />
    <asp:HiddenField ID="hfsearch" runat="server" />
    <div class="content-header">
        <div class="header-section">
            <h1>
                <i class="fa fa-building" style="margin: -8px"></i>Sales Achieved Individual<br>
            </h1>
        </div>
    </div>
    <ul class="breadcrumb breadcrumb-top">
        <li><a href="index.aspx">Home</a></li>
        <li><a href="CategoryWiseAchiveTarget.aspx">CategoryWiseAchievedTarget</a></li>
        <li>SalesAchievedIndividual</li>
    </ul>
    <div class="block">
        <div class="block-title">
            <h2><strong>Sales Achieved Individual</strong> Detail</h2>
        </div>
        <div class="row">
            <div class="form-horizontal form-bordered">
                <div class="col-md-12">
                    <div class="pull-right">
                        <asp:ImageButton ID="btnExportExcel" data-toggle="tooltip" title="Export Excel" Style="margin-right: 23px" Width="33px" ImageAlign="Right" runat="server" ImageUrl="~/images/excel.gif" />
                    </div>
                </div>
            </div>
        </div>
        <br />
        <asp:HiddenField ID="Hfsearchcheck" runat="server" />
        <div class="table-responsive">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Order_Id" CssClass="table table-striped table-vcenter table-hover" AllowPaging="false">
                <Columns>
                    <asp:TemplateField HeaderText="Order ID" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" Visible="false">
                        <ItemTemplate>
                            <asp:Literal ID="lblOrderId" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Order_Id"))%>' EnableViewState="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order Code" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                        <ItemTemplate>
                            <asp:HyperLink ID="hpviwe4" EnableViewState="false"  NavigateUrl='<%# "EditSalesOrder.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Order_Id").ToString()))%>'
                                data-toggle="tooltip" title="View" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Order_Code"))%>'>
                               <%-- <asp:Literal ID="lblOrderCode" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Order_Code"))%>' EnableViewState="false" />--%>
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order Date" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader">
                        <ItemTemplate>
                            <asp:Literal ID="lblDate" runat="server" Text='<%#Convert.ToString(DynamicparcelDataManipulation.FixNullFromDB(Eval("Order_CreatedDate")))%>' EnableViewState="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Customer Name" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader">
                        <ItemTemplate>
                            <asp:Literal ID="lblcustname" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_Name"))%>' EnableViewState="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Amount" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader">
                        <ItemTemplate>
                            <i class="fa fa-rupee"></i>&nbsp;
                                            <asp:Literal ID="lblamount" runat="server" Text='<%#CDbl(Math.Round(DynamicparcelDataManipulation.FixNullFromDB(Eval("amount")))).ToString("N2")%>' EnableViewState="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="City" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                        <ItemTemplate>
                            <asp:Literal ID="lblCity" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("City"))%>' EnableViewState="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order Status" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                        <ItemTemplate>
                            <asp:Literal ID="lblanswer" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Order_OrderStatus"))%>' EnableViewState="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Customer Owner" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                        <ItemTemplate>
                            <asp:Literal ID="lblowner" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("AccountOwner"))%>' EnableViewState="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="AssignTo" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                        <ItemTemplate>
                            <asp:Label ID="lblassignto" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("AssignTo"))%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="From" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                        <ItemTemplate>
                            <asp:Label ID="lblfrom" runat="server" CssClass='<%#Security.OrderFrom(Eval("Order_type"))%>' Text='<%#If(DynamicparcelDataManipulation.FixNullFromDB(Eval("Order_type")) = "CRM", "CRM", "B2B")%>' EnableViewState="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="Right" BackColor="White" />
                <FooterStyle HorizontalAlign="Center" BackColor="White" />
                <PagerSettings PageButtonCount="4" />
                <EmptyDataTemplate>
                    <asp:Label ID="s" runat="server" Text="No Record Found"></asp:Label><br />
                    <br />
                </EmptyDataTemplate>
                <EmptyDataRowStyle HorizontalAlign="Center" />
            </asp:GridView>
        </div>
</asp:Content>

