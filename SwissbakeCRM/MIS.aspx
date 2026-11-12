<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="MIS.aspx.vb" Inherits="MIS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header">
        <div class="header-section">
            <h1>
                <i class="hi hi-tasks" style="margin: -8px"></i>MIS Report<br>
            </h1>
        </div>
    </div>
    <ul class="breadcrumb breadcrumb-top">
        <li><a href="index.aspx">Home</a></li>
        <li>MIS Report</li>
    </ul>
    <div class="block">
        <div class="block-title">
            <h2><strong>MIS Report</strong> Detail</h2>
        </div>
        <div class="row">
            <div class="form-horizontal form-bordered">
                <div class="col-md-12">
                    <br />
                </div>
                <div class="col-md-12">
                    <div class="table-responsive" style="overflow: auto;">
                            <asp:GridView ID="GridView1" runat="server"  PageSize="30" EnableViewState="true" AutoGenerateColumns="false" 
                                CssClass="table table-striped table-vcenter"  ShowHeader="false"
                                AllowPaging="True" >
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                           <h5><b><asp:Literal ID="ltname" runat="server" Text='<%#Eval("name")%>'></asp:Literal></b></h5>
                                            <asp:GridView ID="grdreport" runat="server" AllowPaging="false" AutoGenerateColumns="false" CssClass="table table-striped table-vcenter" ShowHeader="false">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <a href='<%#"CustomMis.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("CustomReport_Id")).ToString)%>' >
                                                            <asp:Literal ID="lblname" runat="server" Text='<%#(Eval("CustomReport_Name"))%>'/></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:GridView ID="grdsalesreportnew" runat="server" AllowPaging="false" AutoGenerateColumns="false" CssClass="table table-striped table-vcenter" ShowHeader="false">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <%--<a href='<%#"SalesOrderReport.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("CustomReport_Id")).ToString)%>' >--%>
                                                              <a id="btnanchor" href='<%#(Eval("CustomReport_Id"))%>' runat="server" >
                                                            <asp:Literal ID="lblname" runat="server" Text='<%#(Eval("CustomReport_Name"))%>'/></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:GridView ID="grdsalesreport" runat="server" AllowPaging="false" AutoGenerateColumns="false" CssClass="table table-striped table-vcenter" ShowHeader="false">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <a href='<%#"SalesPerformanceReportByUser.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("CustomReport_Id")).ToString)%>' >
                                                            <asp:Literal ID="lblname" runat="server" Text='<%#(Eval("CustomReport_Name"))%>'/></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:GridView ID="grdTop" runat="server" AllowPaging="false" AutoGenerateColumns="false" CssClass="table table-striped table-vcenter remove-margin-bottom" ShowHeader="false">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <a href='<%#"TopAccounts.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("CustomReport_Id")).ToString)%>' >
                                                            <asp:Literal ID="lblname" runat="server" Text='<%#(Eval("CustomReport_Name"))%>'/></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:GridView ID="grdTopProduct" runat="server" AllowPaging="false" AutoGenerateColumns="false" CssClass="table table-striped table-vcenter" ShowHeader="false">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <a href='<%#"TopProduct.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("CustomReport_Id")).ToString)%>' >
                                                            <asp:Literal ID="lblname" runat="server" Text='<%#(Eval("CustomReport_Name"))%>'/></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                             <asp:GridView ID="grdPerformance" runat="server" AllowPaging="false" AutoGenerateColumns="false" CssClass="table table-striped table-vcenter" ShowHeader="false">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <a href='<%#"PerformanceReportByUser.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("CustomReport_Id")).ToString)%>' >
                                                            <asp:Literal ID="lblname" runat="server" Text='<%#(Eval("CustomReport_Name"))%>'/></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
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
                        </div></div></div>
        </div>
    </div>
</asp:Content>

