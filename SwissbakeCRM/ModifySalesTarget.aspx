<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ModifySalesTarget.aspx.vb" Inherits="ModifySalesTarget" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .control-label {
            padding: 6px;
        }

        .col-md-4 {
            padding-bottom: 0px;
        }
    </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <asp:Label ID="lbltitle1" runat="server"></asp:Label><br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="SalesTarget.aspx">Sales Target</a></li>
                <li>
                    <asp:Label ID="lbltitle2" runat="server"></asp:Label></li>
            </ul>

        </div>



        <div class="col-md-12">
            <div class="widget">
                <div class="widget-extra themed-background-dark">
                    <h4 class="widget-content-light">
                        <strong>Sales Target</strong> Information
                    </h4>
                </div>
                <div class="widget-extra-full">
                    <div class="form-horizontal form-bordered">
                        <br />
                        <div class="col-md-4">
                            <div class="">
                                <label class="col-md-4 control-label" for="example-hf-password">User</label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="dduser" CssClass="form-control" AutoPostBack="true" runat="server" name="example-chosen" class="select-chosen" TabIndex="1"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="reIndustry" runat="server" ControlToValidate="dduser" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="select User" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="">
                                <label class="col-md-4 control-label" for="example-hf-password">Financial Year</label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddfinancilayear" CssClass="form-control" runat="server" name="example-chosen" class="select-chosen" TabIndex="2"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddfinancilayear" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="select Financial Year" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4" id="divsalestarget" runat="server">
                            <div class="">
                                <label class="col-md-4 control-label" for="example-hf-password"></label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddsalestarget" CssClass="form-control" runat="server" AutoPostBack="true" name="example-chosen" class="select-chosen" TabIndex="3">
                                        <asp:ListItem>Annually</asp:ListItem>
                                        <asp:ListItem>Monthly</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddsalestarget" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="select industry" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true" UpdateMode="Always">
                            <ContentTemplate>
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="grdsalesorder" GridLines="Vertical" CssClass="table table-striped table-vcenter" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Smaller" CellPadding="0" CellSpacing="0" runat="server" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Product Name" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="">
                                                    <HeaderTemplate>
                                                        <asp:HyperLink ID="HyperLink11" runat="server">Month</asp:HyperLink>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Literal ID="ltmonthname" runat="server" Text='<%#Eval("monthname")%>'></asp:Literal>
                                                        <asp:Literal ID="ltmonth" runat="server" Visible="false" Text='<%#Eval("month")%>'></asp:Literal>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Lead" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="">
                                                    <HeaderTemplate>
                                                        <asp:HyperLink ID="HyperLink14" runat="server">Lead</asp:HyperLink>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtlead" Text='<%#Eval("lead")%>' runat="server" CssClass="form-control"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Lead Achived" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="">
                                                    <HeaderTemplate>
                                                        <asp:HyperLink ID="HyperLink14" runat="server">Achieved</asp:HyperLink>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtachiveLead" ReadOnly="true" Text='<%#Eval("LeadAchived")%>' runat="server" CssClass="form-control"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Prospect" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="">
                                                    <HeaderTemplate>
                                                        <asp:HyperLink ID="HyperLink13" runat="server">Prospect</asp:HyperLink>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtprospect" Text='<%#Eval("prospect")%>' runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Prospect Achieved" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="">
                                                    <HeaderTemplate>
                                                        <asp:HyperLink ID="HyperLink13" runat="server">Achieved</asp:HyperLink>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtachiveProspect" ReadOnly="true" Text='<%#Eval("prospectAchived")%>' runat="server" CssClass="form-control"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Account" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="">
                                                    <HeaderTemplate>
                                                        <asp:HyperLink ID="HyperLink12" runat="server">Account</asp:HyperLink>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtaccount" Text='<%#Eval("account")%>' runat="server" CssClass="form-control"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Account Achieved" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="">
                                                    <HeaderTemplate>
                                                        <asp:HyperLink ID="HyperLink12" runat="server">Achieved</asp:HyperLink>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtAchiveAccount" Text='<%#Eval("AccountAchived")%>' runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sales Amount" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="">
                                                    <HeaderTemplate>
                                                        <asp:HyperLink ID="HyperLink15" runat="server">Sales Amount</asp:HyperLink>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtsalesamount"  ReadOnly="true" Text='<%#Eval("sales")%>' runat="server" CssClass="form-control"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sales Amount Achieved" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="">
                                                    <HeaderTemplate>
                                                        <asp:HyperLink ID="HyperLink15" runat="server">Achieved</asp:HyperLink>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtachivesalesamount" ReadOnly="true" Text='<%#If(String.IsNullOrEmpty(Eval("SalesAchived")), "", Convert.ToDouble(Eval("SalesAchived").ToString).ToString("#,##0.00"))%>' runat="server" CssClass="form-control"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="left" BackColor="White" />
                                            <FooterStyle HorizontalAlign="left" BackColor="White" />
                                            <PagerSettings PageButtonCount="4" />
                                            <EmptyDataTemplate>
                                                <asp:Label ID="s" runat="server" Text="No Item Found"></asp:Label><br />
                                                <br />
                                            </EmptyDataTemplate>
                                            <EmptyDataRowStyle HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </div>
                                </div>


                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:Repeater ID="RPTtarget" runat="server">
                                            <ItemTemplate>
                                                <h4 style="text-align: center;">
                                                    <asp:Literal ID="lblmonthname" runat="server" Text='<%#Eval("monthname")%>'></asp:Literal></h4>
                                                <asp:Literal ID="ltmonth" runat="server" Visible="false" Text='<%#Eval("month")%>'></asp:Literal>
                                                <asp:GridView ID="grdcatgTarget" GridLines="Vertical" CssClass="table table-striped table-vcenter" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Smaller" CellPadding="0" CellSpacing="0" runat="server" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Target Category" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="">
                                                            <HeaderTemplate>
                                                                <asp:HyperLink ID="HyperLink21" runat="server">Target Category</asp:HyperLink>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Literal ID="lblSTC_ID" runat="server" Text='<%#Eval("TC_ID")%>' Visible="false" ></asp:Literal>
                                                                <asp:Literal ID="lblcatname" runat="server" Text='<%#Eval("TC_Name")%>'></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sales Amount" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="">
                                                            <HeaderTemplate>
                                                                <asp:HyperLink ID="HyperLink22" runat="server">Sales Amount</asp:HyperLink>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTargetsalesamount" Text='<%#Eval("Targetsales")%>' runat="server" CssClass="form-control decimal" ></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sales Amount Achieved" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="">
                                                            <HeaderTemplate>
                                                                <asp:HyperLink ID="HyperLink23" runat="server">Achieved</asp:HyperLink>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtachivesalesTargetamount" ReadOnly="true" Text='<%#If(String.IsNullOrEmpty(Eval("TargetSalesAchived")), "", Convert.ToDouble(Eval("TargetSalesAchived").ToString).ToString("#,##0.00"))%>' runat="server" CssClass="form-control"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="left" BackColor="White" />
                                                    <FooterStyle HorizontalAlign="left" BackColor="White" />
                                                    <PagerSettings PageButtonCount="4" />
                                                    <EmptyDataTemplate>
                                                        <asp:Label ID="s" runat="server" Text="No Item Found"></asp:Label><br />
                                                        <br />
                                                    </EmptyDataTemplate>
                                                    <EmptyDataRowStyle HorizontalAlign="Center" />
                                                </asp:GridView>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="RPTtarget" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
                            <ProgressTemplate>
                                <br />
                                <div class="divWaiting">
                                    <i class="fa fa-sun-o fa-spin" id="LoadingUpadatePanel"></i>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <div style="clear: both"></div>
                        <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                            <div class="pull-right">
                                <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                    UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" />
                                <asp:LinkButton ID="LinkButton1" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/Activity.aspx" class="btn btn-alt btn-sm btn-danger" />
                            </div>
                        </div>
                        <div style="clear: both"></div>
                    </div>
                </div>
            </div>
        </div>

    </div>
    
</asp:Content>

