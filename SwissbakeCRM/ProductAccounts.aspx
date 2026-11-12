<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="ProductAccounts.aspx.vb" Inherits="ProductAccounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="content-header">
                <div class="header-section">
                    <h1>
                        <i class="gi gi-parents" style="margin: -8px"></i>Product Account<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="MIS.aspx">MIS</a></li>
                <li><a href="TopProduct.aspx">Top Product</a></li>
                <li>Product Account</li>
            </ul>
            <div class="block">
                <div class="block-title">
                    <h2><strong>Product Account</h2>
                </div>

                <div class="col-md-12">
                    <div class="pull-right">
                        <asp:ImageButton ID="btnExportExcel" data-toggle="tooltip" title="Export Excel" Style="margin-right: 23px" Width="33px" ImageAlign="Right" runat="server" ImageUrl="~/images/excel.gif" />                     
                    </div>
                </div>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="hfsearch" runat="server" />

                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Acc_Id"
                                CssClass="table table-striped table-vcenter" GridLines="None"
                                AllowSorting="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="Account Code" HeaderStyle-CssClass="" ItemStyle-CssClass="" SortExpression="Acc_Code">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblacode" runat="server" Text='<%#Eval("Acc_Code")%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Account Name" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Acc_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblaname" runat="server" Text='<%#Eval("Acc_Name")%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order Date" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Order_CreatedDate">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblorddate" runat="server" Text='<%#Eval("Order_CreatedDate")%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="OrDetail_Qty">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblordqty" runat="server" Text='<%#Eval("OrDetail_Qty")%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="left" BackColor="White" />
                                <FooterStyle HorizontalAlign="left" BackColor="White" />
                                <PagerSettings PageButtonCount="4" />
                                <EmptyDataTemplate>
                                    <asp:Label ID="s" runat="server" Text="No Record Found"></asp:Label><br />
                                    <br />
                                </EmptyDataTemplate>
                                <EmptyDataRowStyle HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>                       
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

