<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="CustomMis.aspx.vb" Inherits="CustomMis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="deletestatus" runat="server" />
    <asp:HiddenField ID="Hfsearchcheck" runat="server" />
    <asp:HiddenField ID="hfsearchquery" runat="server" />
    <asp:HiddenField ID="hfsearch" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="content-header">
                <div class="header-section">
                    <h1>
                        <i class="hi hi-tasks" style="margin: -8px"></i>
                        <asp:Literal ID="ltmainreport" runat="server"></asp:Literal><br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="MIS.aspx">MIS</a></li>
                <li>
                    <asp:Literal ID="ltreport" runat="server"></asp:Literal></li>
            </ul>
            <div class="block">
                <div class="block-title">
                    <h2><strong>
                        <asp:Literal ID="ltreportdetails" runat="server"></asp:Literal></strong> Detail</h2>
                </div>
                <asp:HiddenField ID="hfcheck" runat="server" />
                <asp:HiddenField ID="hfchanged" runat="server" />
                <asp:HiddenField ID="hfquery" runat="server" />
                <asp:HiddenField ID="hfmodule" runat="server" />
                <asp:HiddenField ID="hftopquery" runat="server" />
                 <asp:HiddenField ID="hftopquerycheck" runat="server" />
                <asp:HiddenField ID="hfReport_Type" runat="server" />
                <div class="row">
                    <div class="form-horizontal form-bordered">
                        <div class="col-md-12">
                            <br />
                        </div>
                        <asp:Repeater ID="rpsearch" runat="server">
                            <ItemTemplate>
                                <div class="col-md-4" id="divTextbox" runat="server" style="margin-bottom: 5px;">
                                    <div class="">
                                        <label class="col-md-7 control-label" for="example-hf-email" style="text-align: left; width: auto;"><%#Eval("CustomReportDt_FieldName").ToString .Replace ("_"," ")%></label>
                                        <asp:HiddenField ID="hfcoloumname" runat="server" Value='<%#Eval("CustomReportDt_FieldName")%>' />
                                        <asp:HiddenField ID="hflogoperator" runat="server" Value='<%#Eval("CustomReportDt_LogOperator")%>' />
                                        <asp:HiddenField ID="hfoperator" runat="server" Value='<%#Eval("CustomReportDt_Operator")%>' />
                                        <asp:HiddenField ID="hfdatatype" runat="server" Value='<%#Eval("CustomReportDt_DataType")%>' />
                                        <asp:Label class="col-md-1 control-label" for="example-hf-email" Visible="false" runat="server" ID="lbloperator" Style="float: right; right: 20px; color: rgb(236, 12, 12); font-weight: 600;"><%#Eval("CustomReportDt_Operator").ToString .Replace ("_"," ")%></asp:Label><div class="col-md-12">
                                            <asp:TextBox ID="txtsearch" runat="server" placeholder='<%#Eval("CustomReportDt_FieldName").ToString.Replace("_", " ")%>' data-toggle="tooltip" title='<%#Eval("CustomReportDt_FieldName").ToString.Replace("_", " ")%>'
                                                CssClass="form-control"></asp:TextBox>
                                           <%--  <asp:CustomValidator ID="cValidation" runat="server" ClientValidationFunction="MyClientValidation"
                      ErrorMessage="Invalid"></asp:CustomValidator>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4" id="divbetwwen" runat="server" visible="false" style="margin-bottom: 5px;">
                                    <div class="">
                                        <label class="col-md-1 control-label" for="example-hf-email" style="text-align: left; width: auto; padding-right: 0px;"><%#Eval("CustomReportDt_FieldName").ToString .Replace ("_"," ")%> </label>
                                        <asp:Label class="col-md-9 control-label" Visible="false" for="example-hf-email" Style="color: rgb(236, 12, 12); font-weight: 600; padding-right: 0px;" runat="server" ID="lbloperator1">Between</asp:Label>
                                        <div class="col-md-12">

                                            <div class="input-group" data-date-format="mm/dd/yyyy">
                                                <div class="col-md-5" style="padding: 0px;">
                                                    <asp:TextBox ID="txtstart" runat="server" class="form-control text-center" step="1" />
                                                </div>
                                                <div class="col-md-2" style="padding: 0px;"><span class="input-group-addon" style="font-size: 10px; min-width: 9px; height: 25px;"><i class="fa fa-angle-right"></i></span></div>
                                                <div class="col-md-5" style="padding: 0px;">
                                                    <asp:TextBox ID="txtend" runat="server" class="form-control text-center" step="1" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="col-md-9">
                        </div>
                        <div style="clear:both"></div>
                         <div class="col-md-4" style="margin-top:5px">
                             
                             <label class="col-md-12 control-label" for="example-hf-email" style="text-align: left; width: auto;">Number of Record</label>
                              <div class="col-md-5">
                             <asp:TextBox ID="txttop" runat="server" onkeyup="this.value=this.value.replace(/[^\d\.]/g,'');" placeholder="Number of Record" data-toggle="tooltip" title="Number of Record"
                                                CssClass="form-control"></asp:TextBox>
                                  </div>
                                  
                             </div>
                        <div class="col-md-8">
                            <div class="pull-right">
                                <asp:ImageButton ID="btnExportExcel" data-toggle="tooltip" title="Export Excel" Style="margin-right: 23px" Width="33px" ImageAlign="Right" runat="server" ImageUrl="~/images/excel.gif" />
                               <asp:LinkButton Text="Report" runat="server" Style="margin-right: 15px;" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Reporting...';"
                                    UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" ><i class="fa fa-line-chart"></i>  Report</asp:LinkButton>
                                 <asp:LinkButton Text="Show All" runat="server" Style="margin-right: 15px;" ID="btnshowall" class="btn btn-alt btn-sm btn-primary"><i class="gi gi-refresh"></i>  Show All</asp:LinkButton>
                                
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <br />
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="table-responsive" style="overflow: auto;">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" PageSize="30" EnableViewState="true"
                                CssClass="table table-striped table-vcenter" AlternatingRowStyle-CssClass="Alternate_grid" AllowSorting="true" OnSorting="GridView1_Sorting"
                                AllowPaging="True">

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
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnadd" />
            <asp:PostBackTrigger ControlID="btnExportExcel" />
            <asp:AsyncPostBackTrigger ControlID="btnshowall" />

        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <br />
            <div class="divWaiting">
                <i class="fa fa-sun-o fa-spin" id="LoadingUpadatePanel"></i>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

