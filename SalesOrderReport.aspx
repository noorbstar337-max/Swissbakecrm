<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="SalesOrderReport.aspx.vb" Inherits="SalesOrderReport" EnableEventValidation = "false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:HiddenField ID="deletestatus" runat="server" />
    <asp:HiddenField ID="Hfgridview" runat="server" />
    <asp:HiddenField ID="hftotalrecord" runat="server" />
    <asp:HiddenField ID="hfsearch" runat="server" />
    <asp:HiddenField ID="Hfsearchcheck" runat="server" />
    <asp:HiddenField ID="hfsearchquery" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            
            <div class="content-header">
                <div class="header-section">
                    <h1>
                        <i class="gi gi-parents" style="margin: -8px"></i>Sales Order Report<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                 <li><a href="MIS.aspx">MIS</a></li>
                <li>Sales Order Report</li>
            </ul>
            <div class="block">
                <div class="block-title">
                    <h2><strong>Sales Order</strong> Report</h2>
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
                         <div class="col-md-3" style="margin-top:5px">                             
                             <label class="col-md-12 control-label" for="example-hf-email" style="text-align: left; width: auto;">Number of Record</label>
                              <div class="col-md-5">
                             <asp:TextBox ID="txttop" runat="server" onkeyup="this.value=this.value.replace(/[^\d\.]/g,'');" placeholder="Number of Record" data-toggle="tooltip" title="Number of Record"
                                                CssClass="form-control"></asp:TextBox>
                                  </div>                                  
                             </div>
                          <div class="col-md-3"  style="margin-top:5px">
                    <div class="">
                        <label class="col-md-4 control-label" for="example-hf-password">Type</label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="ddlType" runat="server" name="example-chosen" class="form-control">
                                <asp:ListItem Selected="True" Text="Team" Value="Team"></asp:ListItem>
                                <asp:ListItem Text="Individual" Value="Individual"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-md-3"  style="margin-top:5px">
                    <div class="">
                        <label class="col-md-4 control-label" for="example-hf-password">User</label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="ddluser" runat="server" name="example-chosen" class="form-control"></asp:DropDownList><br />
                        </div>
                    </div>
                </div>
                        <div class="col-md-3"  style="margin-top:5px">
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
            <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>  --%>                      
                        <div class="table-responsive">                           
                                <asp:GridView ID="GridView1" runat="server" PageSize="30" DataKeyNames="Order_Id" AutoGenerateColumns="false"
                                CssClass="table table-striped table-vcenter" AlternatingRowStyle-CssClass="Alternate_grid" AllowSorting="true" OnSorting="GridView1_Sorting"
                                AllowPaging="True">
                                <Columns>                                   
                                    <asp:TemplateField HeaderText="Order ID" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" Visible="false" >
                                        <ItemTemplate>
                                            <asp:Literal ID="lblOrderId" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Order_Id"))%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order Code" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem"  SortExpression="Code">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblOrderCode" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Code"))%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order Date" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="CreatedDate">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblDate" runat="server" Text='<%#DynamicparcelDataManipulation.DateFormat(Eval("CreatedDate"))%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Customer Name" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Account_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblcustname" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Account_Name"))%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="amount">
                                        <ItemTemplate>
                                            <i class="fa fa-rupee"></i>&nbsp;
                                            <asp:Literal ID="lblamount" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(CDbl(Math.Round(Eval("amount"))).ToString("N2"))%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="City" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem"  SortExpression="City">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblCity" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("City"))%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order Status" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Status">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblanswer" runat="server"  Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Status"))%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Customer Owner" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="User_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblowner" runat="server"  Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("User_Name"))%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="AssignTo" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="AssignTo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblassignto" runat="server"  Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("AssignTo"))%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>                                 
                                      <asp:TemplateField HeaderText="From" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Order_type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfrom" runat="server" CssClass='<%#Security.OrderFrom(Eval("Order_type"))%>'  Text='<%#DynamicparcelDataManipulation.FixNullFromDB(If(Eval("Order_type") = "CRM", "CRM", "B2B"))%>' EnableViewState="false" />
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
                    <%--</ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" />
                    </Triggers>
                </asp:UpdatePanel>--%>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnadd" />
            <asp:PostBackTrigger ControlID="btnExportExcel" />
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

