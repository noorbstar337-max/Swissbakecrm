<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="MIS_Report.aspx.vb" Inherits="MIS_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
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
            <h2><strong>Reports</strong></h2>
        </div>
        <div class="row">
            <div class="form-horizontal form-bordered">
                <div class="col-md-12">
                    <br />
                </div>
                <div class="col-md-4" style="text-align:center" >
                    <div class="table-responsive" style="overflow: auto;">
                        <div class="col-md-12">
                            <b><a href="OutstandingReport.aspx" target="_blank" title="Outstanding Report">
                                <asp:Label ID="Literal10" runat="server" Text="Outstanding Report" /></a></b>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <br />
                    </div>
                    <div class="col-md-12">
                        <b><a href="liverate.aspx" target="_blank" title="Live Rate">
                            <asp:Label ID="Literal11" runat="server" Text="Live Rate" /></a></b>
                    </div>
                    <div class="col-md-12">
                        <br />
                    </div>
                    <div class="col-md-12">
                        <b><a href="DSRReport.aspx" target="_blank" title="DSR wise Report">
                            <asp:Label ID="lblProst1" runat="server" Text="DSR wise Report" /></a></b>
                    </div>

                    <div class="col-md-12">
                        <br />
                    </div>
                    <div class="col-md-12">
                        <b><a href="LeadReport.aspx" target="_blank" title="Lead Report">
                            <asp:Label ID="Literal1" runat="server" Text="Lead Report"  /></a></b>
                    </div>
                    <div class="col-md-12">
                        <br />
                    </div>
                    <div class="col-md-12">
                        <b><a href="ProspectReport.aspx" target="_blank" title="Prospect Report">
                            <asp:Label ID="Literal2" runat="server" Text="Prospect Report" /></a></b>
                    </div>
                    <div class="col-md-12">
                        <br />
                    </div>
                    <div class="col-md-12">
                        <b><a href="AccountReport.aspx" target="_blank" title="Account Report">
                            <asp:Label ID="Literal3" runat="server" Text="Account Report" /></a></b>
                    </div>
                    <div class="col-md-12">
                        <br />
                    </div>
                </div>

                <div class="col-md-4" style="text-align:center" >
                   
                    <div class="col-md-12">
                        <b><a href="ProductReport.aspx" target="_blank" title="Product Report">
                            <asp:Label ID="Literal4" runat="server" Text="Product Report" /></a></b>
                    </div>
                    <div class="col-md-12">
                        <br />
                    </div>
                    <div class="col-md-12">
                        <b><a href="TopProduct.aspx?Id=jJOtHsRVwYECOhoiBc69dA%3d%3d" target="_blank" title="Top Product Report">
                            <asp:Label ID="Literal5" runat="server" Text="Top Product Report" /></a></b>
                    </div>
                    <div class="col-md-12">
                        <br />
                    </div>
                    <div class="col-md-12">
                        <b><a href="TopAccounts.aspx?Id=jJOtHsRVwYECOhoiBc69dA%3d%3d" target="_blank" title="Top Account Report">
                            <asp:Label ID="Literal9" runat="server" Text="Top Account Report" /></a></b>
                    </div>
                    <div class="col-md-12">
                        <br />
                    </div>
                    <div class="col-md-12">
                        <b><a href="citywisereport.aspx" target="_blank" title="City Wise Report">
                            <asp:Label ID="Literal6" runat="server" Text="City Wise Report" /></a></b>
                    </div>
                    <div class="col-md-12">
                        <br />
                    </div>
                    <div class="col-md-12">
                        <b><a href="ProductWiseReport.aspx" target="_blank" title="Product Wise Report">
                            <asp:Label ID="Literal7" runat="server" Text="Product Wise Report" /></a>
                    </div>
                    <div class="col-md-12">
                        <br />
                    </div>
                    <div class="col-md-12">
                        <b><a href="UserWiseReport.aspx" target="_blank" title="User Wise Report">
                            <asp:Label ID="Literal8" runat="server" Text="User Wise Report" /></a></b>
                    </div>
                    <div class="col-md-12">
                        <br />
                    </div>
                </div>

                <div class="col-md-4" style="text-align:center" >
                    <div class="col-md-12">
                        <b><a href="ProductsReport.aspx" target="_blank" title="Product Wise Rate Report">
                            <asp:Label ID="Literal12" runat="server" Text="Product Wise Rate Report" /></a></b>
                    </div>
                    <div class="col-md-12">
                        <br />
                    </div>
                    <div class="col-md-12">
                        <b><a href="OrderReport.aspx" target="_blank" title="Order Report">
                            <asp:Label ID="Literal13" runat="server" Text="Order Report" /></a></b>
                    </div>
                    <div class="col-md-12">
                        <br />
                    </div>
                    <div class="col-md-12">
                        <b><a href="InvoiceReport.aspx" target="_blank" title="Invoice Report">
                            <asp:Label ID="Literal14" runat="server" Text="Invoice Report" /></a></b>
                    </div>
                    <div class="col-md-12">
                        <br />
                    </div>
                    <div class="col-md-12">
                        <b><a href="SampleRequestReport.aspx" target="_blank" title="Sample Request Report">
                            <asp:Label ID="lblRegn" runat="server" Text="Sample Request Report" /></a></b>
                    </div>
                    <div class="col-md-12">
                        <br />
                    </div>
                     <div class="col-md-12">
                        <b><a href="AccReport.aspx" target="_blank" title="Account Report (NEW)">
                            <asp:Label ID="Literal15" runat="server" Text="Account Report (NEW)" /></a></b>
                    </div>
                    <div class="col-md-12">
                        <br />
                    </div>
                    <div class="col-md-12">
                        <b><a href="CRMFeedbacks.aspx?type=Rregpvofrhtj" target="_blank" title="CRM Feedback Report">
                            <asp:Label ID="Label1" runat="server" Text="CRM Feedback Report" /></a></b>
                    </div>
                </div>
                <div style="clear: both;"></div>
                <br />
            </div>
        </div>
    </div>

</asp:Content>

