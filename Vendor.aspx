<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="Vendor.aspx.vb" Inherits="Vendor" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="deletestatus" runat="server" />
    <asp:HiddenField ID="Hfgridview" runat="server" />
    <asp:HiddenField ID="hftotalrecord" runat="server" />
    <asp:HiddenField ID="hfsearch" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="content-header">
                <div class="header-section">
                    <h1>
                        <i class="gi gi-parents" style="margin: -8px"></i>Vendor<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                 <li><a href="AdminMenu.aspx">Admin</a></li>
                <li>Vendor</li>
            </ul>
            <div class="block">
                <div class="block-title">
                    <h2><strong>Vendor</strong> Detail</h2>
                </div>
                <%--Search User Control Start--%>
                <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="faq1" class="panel-group">

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title"><i class="fa fa-angle-right"></i><a class="accordion-toggle" data-toggle="collapse" data-parent="#faq1" href="#faq1_q2">Global Search</a></h4>
                                </div>
                                <div id="faq1_q2" class="panel-collapse collapse">
                                    <div class="panel-body">
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
                      ErrorMessage="Invalid"></asp:CustomValidator>--%
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4" id="divbetwwen" runat="server" visible="false" style="margin-bottom: 5px;">
                                                            <div class="">
                                                                <label class="col-md-1 control-label" for="example-hf-email" style="text-align: left; width: auto; padding-right: 0px;"><%#Eval("CustomReportDt_FieldName").ToString .Replace ("_"," ")%> </label>
                                                                <asp:Label class="col-md-9 control-label" Visible="false" for="example-hf-email" Style="color: rgb(236, 12, 12); font-weight: 600; padding-right: 0px;" runat="server" ID="lbloperator1">Between</asp:Label>
                                                                <div class="col-md-12">

                                                                  
                                                                        <div class="col-md-5" style="padding: 0px;">
                                                                            <asp:TextBox ID="txtstart"  runat="server" class="form-control text-center"/>
                                                                          
                                    <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtstart" Format="yyyy/MM/dd" runat="server"></asp:CalendarExtender>
                                                                        </div>
                                                                        <div class="col-md-2" style="padding: 0px;"><span class="input-group-addon" style="font-size: 10px; min-width: 9px; height: 25px;"><i class="fa fa-angle-right"></i></span></div>
                                                                        <div class="col-md-5" style="padding: 0px;">
                                                                            <asp:TextBox ID="txtend" runat="server" class="form-control text-center" />
                                                                                                                <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="txtend" Format="yyyy/MM/dd" runat="server"></asp:CalendarExtender>
                                                                        </div>
                                                                   
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <div class="col-md-9">
                                                </div>
                                                <div style="clear: both"></div>
                                                <div class="col-md-4" style="margin-top: 5px">

                                                    <label class="col-md-12 control-label" for="example-hf-email" style="text-align: left; width: auto;">Number of Record</label>
                                                    <div class="col-md-5">
                                                        <asp:TextBox ID="txttop" runat="server" onkeyup="this.value=this.value.replace(/[^\d\.]/g,'');" placeholder="Number of Record" data-toggle="tooltip" title="Number of Record"
                                                            CssClass="form-control"></asp:TextBox>
                                                    </div>

                                                </div>
                                                <div class="col-md-8">
                                                    <div class="pull-right">
                                                        <asp:ImageButton ID="btnExportExcel" data-toggle="tooltip" title="Export Excel" Style="margin-right: 23px" Width="33px" ImageAlign="Right" runat="server" ImageUrl="~/images/excel.gif" />
                                                        <asp:LinkButton Text="Report" runat="server" Style="margin-right: 15px;" ID="btnadd"
                                                            class="btn btn-alt btn-sm btn-primary"><i class="fa fa-line-chart"></i>  Report</asp:LinkButton>
                                                        <asp:LinkButton Text="Show All" runat="server" Style="margin-right: 15px;" ID="btnshowall" class="btn btn-alt btn-sm btn-primary"><i class="gi gi-refresh"></i>  Show All</asp:LinkButton>

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12">
                                                <br />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>--%>
                <User:SearchBar ID="SearchControl" runat="server" />
                
                <%--Search User Control End--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="hfcheck" runat="server" />
                        <asp:HiddenField ID="hfchanged" runat="server" />
                        <asp:HiddenField ID="hfquery" runat="server" />
                        <asp:HiddenField ID="hfmodule" runat="server" />
                        <asp:HiddenField ID="hftopquery" runat="server" />
                        <asp:HiddenField ID="hftopquerycheck" runat="server" />
                        <asp:HiddenField ID="hfReport_Type" runat="server" />
                        <asp:HiddenField ID="Hfsearchcheck" runat="server" />
                        <asp:HiddenField ID="hfsearchquery" runat="server" />
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Vendor_Id" AllowCustomPaging="true"
                                CssClass="table table-striped table-vcenter" OnSorting="GridView1_Sorting" GridLines="None"
                                AllowPaging="True" AllowSorting="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink4" runat="server">Edit</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="HyperLink2" EnableViewState="false" NavigateUrl='<%# "ModifyVendor.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Vendor_Id").ToString()))%>'
                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="" Visible="false" ItemStyle-CssClass="" SortExpression="Vendor_Id">
                                        <ItemTemplate>
                                            <asp:Literal ID="lbluId" runat="server" Text='<%# DynamicparcelGridview.HighlightText(Eval("Vendor_Id"), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vendor Name" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Vendor_Name">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" EnableViewState="false" NavigateUrl='<%# "ViewVendor.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Vendor_Id").ToString()))%>'
                                                data-toggle="tooltip" title="View" runat="server">
                                            <asp:Literal ID="lblcontact" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("Vendor_Name")), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                        </asp:HyperLink>
                                                </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact Person" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Contact_ContactPerson">
                                        <ItemTemplate>                                            
                                                <asp:Literal ID="lblname" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Contact_ContactPerson"), SearchControl.UtxtSearch)%>' EnableViewState="false" />                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>                                    
                                    <asp:TemplateField HeaderText="Phone" ItemStyle-Width="120" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Contact_Landline">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblphone" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("Contact_Landline")), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email"  ItemStyle-Width="120" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Contact_Email">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblemail" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("Contact_Email")), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mobile" ItemStyle-Width="120"  HeaderStyle-CssClass="" ItemStyle-CssClass="" SortExpression="Contact_Mobile">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblmobile" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("Contact_Mobile")), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="City" ItemStyle-Width="120"  HeaderStyle-CssClass="" ItemStyle-CssClass="" SortExpression="Vendor_City">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblCity" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("Vendor_City")), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <%--<asp:TemplateField HeaderText="Vendor Owner" ItemStyle-Width="120" HeaderStyle-CssClass="" ItemStyle-CssClass="" SortExpression="U_FirstName">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblowner" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("U_FirstName")), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                         </asp:TemplateField>--%>
                                     <asp:TemplateField HeaderText="Status" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Vendor_City">
                                        <ItemTemplate>
											  <asp:LinkButton ID="lnk" CssClass='<%#Security.checkStatus(Eval("Vendor_status"))%>' runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Vendor_status"), SearchControl.UtxtSearch)%>'
												                              CommandName="statuslink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>" />                                           
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
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" />
                         <%--<asp:AsyncPostBackTrigger ControlID="btnadd" />--%>
                       <%-- <asp:AsyncPostBackTrigger ControlID ="btnshowall" />--%>
                    <%--    <asp:PostBackTrigger ControlID ="btnExportExcel" />--%>
                        <%--<asp:PostBackTrigger ControlID="btnsave" />--%>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </ContentTemplate>
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

