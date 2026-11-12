<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ImportDistributor.aspx.vb" Inherits="ImportDist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .control-label {
            padding: 6px;
        }

        .col-md-4 > .form-group {
            padding-bottom: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <asp:HiddenField ID="hfemail" runat="server" />
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <i class="hi hi-download-alt" style="margin: -8px"></i>Import Distributor<br>
                    </h1>
                </div>
            </div>

            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
               
                <li>Import Distributor</li>
            </ul>

            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">                    
                    <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('DemoMasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="DemoMasterGroup" OnClick="btnadd_Click" />
                    <asp:HyperLink ID="HyperLink1" EnableViewState="false" Text="Cancel" runat="server" NavigateUrl="~/Account.aspx" class="btn btn-alt btn-sm btn-danger" />
                </div>
            </div>
            <div class="col-md-12">
                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <h4 class="widget-content-light">
                            <strong>Distributor</strong> Information                            
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label class="col-md-2 control-label" for="example-hf-email">Distributor File<span class="text-danger"> *</span></label>
                                    <div class="col-md-3">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                        <asp:RequiredFieldValidator ID="retitle" runat="server" ControlToValidate="FileUpload1" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select excel file" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    <div class="col-md-3">

                                        <asp:Button Text="Upload" runat="server" ID="btnupload" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" />
                                         <asp:HyperLink ID="importformat" NavigateUrl="~/ExcelFormat/AccountImportFormat.xlsx" class="btn btn-alt btn-sm btn-primary" runat="server" download>Sample File</asp:HyperLink>
                                        </div> 
                                        
                                </div>
                            </div>
                            <div class="col-md-4" style="text-align:right;">
                    <asp:Label ID="lblvalidAccount" runat="server" CssClass="alert alert-success"></asp:Label>
                    <asp:Label ID="lblinvalidAccount" runat="server" CssClass="alert alert-danger"></asp:Label>
                    </div> 
                            
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
                                            CssClass="table table-striped table-vcenter" GridLines="None" PageSize="100"
                                            AllowPaging="True" >
                                            <Columns>
                                               <%-- <asp:TemplateField HeaderText="Product Code" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Product Code">
                                                    <ItemTemplate>
                                                        <asp:Literal ID="lblname" runat="server" Text='<%#Eval("Product Code")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Product Name" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Product Name">
                                                    <ItemTemplate>
                                                        <asp:Literal ID="lblcontact" runat="server" Text='<%#Eval("NAME")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                              <%--  <asp:TemplateField HeaderText="Category" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Category">
                                                    <ItemTemplate>
                                                        <asp:Literal ID="lblphone" runat="server" Text='<%#Eval("Category")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <%--<asp:TemplateField HeaderText="Email" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Email Id 1">
                                                    <ItemTemplate>
                                                        <asp:Literal ID="lblemail" runat="server" Text='<%#Eval("Email Id 1")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <%--<asp:TemplateField HeaderText="Mobile" HeaderStyle-CssClass="" ItemStyle-CssClass="" SortExpression="Contact MobileNo">
                                                    <ItemTemplate>
                                                        <asp:Literal ID="lblmobile" runat="server" Text='<%#Eval("Contact MobileNo")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Account Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldate" runat="server" Text='<%#Eval("Account Date")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Validation" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Validation">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblvalid" runat="server" Text='<%#Eval("Validation")%>' data-toggle="tooltip" title='<%#Eval("Error")%>' />
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
                                </div>
                            </div>
                             
                            <div style="clear: both"></div>
                        </div>
                    </div>
                </div>
            </div>
            

            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                   <%-- <asp:Button Text="Save & Sending Invitation" runat="server" ID="btnsaveNemail" OnClientClick="if (!Page_ClientValidate('DemoMasterGroup')){ return false; } this.disabled = true; this.value = 'Saving and sending mail...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="DemoMasterGroup" TabIndex="8" />--%>
                    <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('DemoMasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="DemoMasterGroup" TabIndex="9" />
                    <asp:HyperLink ID="hfcancel" EnableViewState="false" Text="Cancel" runat="server" NavigateUrl="~/Account.aspx" class="btn btn-alt btn-sm btn-danger" TabIndex="10" />
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

