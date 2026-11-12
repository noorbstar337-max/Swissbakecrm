<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ModifyTaxMaster.aspx.vb" Inherits="ModifyTaxMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        input[type="checkbox"], input[type="radio"] {
        margin-right:5px;}
        #ContentPlaceHolder1_rdtax > tbody > tr > td {
       padding: 0 38px 0 0;}
        #ContentPlaceHolder1_rdtaxPrincipal > tbody > tr > td {
       padding: 0 38px 0 0;  }
           #ContentPlaceHolder1_rdaddition > tbody > tr > td {
       padding: 0 38px 0 0;  }
          #ContentPlaceHolder1_checkbox_tax > tbody > tr > td {
       padding: 0 38px 0 0;  }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-12">
             <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <i class="gi gi-table" style="margin: -8px"></i> Tax Master<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
               <%-- <li><a href="department.aspx">Tax Master</a></li>--%>
                 <li> Tax Master</li>
            </ul>
            <div class="col-md-6">
                 <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
            <div class="widget">
             
                <div class="widget-extra-full">
                     <div class="form-group">
                         <asp:RadioButtonList ID="rdtax" runat="server" RepeatDirection="Horizontal" CellSpacing="10" AutoPostBack="True" OnSelectedIndexChanged="rdtax_SelectedIndexChanged">
                             <asp:ListItem Value="Tax" Selected="True">Tax</asp:ListItem>
                              
                             <asp:ListItem Value="Additional Charges">Additional Charges</asp:ListItem>
                         </asp:RadioButtonList>
                        <%-- <asp:RadioButton ID="rdtax" runat="server" GroupName="decide" Text="Tax" Style="margin-right:20px;" Checked="true" AutoPostBack="true"/>
                          <asp:RadioButton ID="rdaddCharge" runat="server" GroupName="decide" Text="Additional Charges" AutoPostBack="true"/>--%>
                    </div>
                    <div class="form-group">
                        <label for="example-nf-email">Tax Name <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txttaxname" runat="server" placeholder="Enter Tax Name" data-toggle="tooltip" title="Enter Tax Name"
                            CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="remembername" runat="server" ControlToValidate="txttaxname" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                            ErrorMessage="Please enter Tax Name"></asp:RequiredFieldValidator>
                    </div>
                      <div class="form-group" id="taxpercent" runat="server">
                        <label for="example-nf-email">Tax Percent <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txttaxpercent" runat="server" placeholder="Enter Tax Percent" data-toggle="tooltip" title="Enter Tax Percent"
                            CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttaxpercent" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                            ErrorMessage="Please Enter Tax Percent"></asp:RequiredFieldValidator>
                    </div>
                     <div class="form-group" id="taxamount" runat="server" visible="false">
                        <label for="example-nf-email">Amount/Qty <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txttaxamount" runat="server" placeholder="Enter Amount/Qty" data-toggle="tooltip" title="Enter Amount/Qty"
                            CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttaxamount" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                            ErrorMessage="Please Amount/Qty"></asp:RequiredFieldValidator>
                    </div>

                     <div class="form-group">
                         <asp:CheckBoxList ID="checkbox_tax" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="checkbox_tax_SelectedIndexChanged">
                             <asp:ListItem Value="1">Editable Tax</asp:ListItem>
                             <asp:ListItem Value="2">Add to Principal</asp:ListItem>
                             <asp:ListItem Value="3">Tax on Qty</asp:ListItem>
                         </asp:CheckBoxList>
                    </div>
           
                    <div class="form-group">
                        <label for="example-nf-email">MRP Abatement% <span class="text-danger"></span></label>
                        <asp:TextBox ID="txtmrpabatement" runat="server" placeholder="Enter MRP Abatement%" data-toggle="tooltip" title="Enter MRP Abatement%"
                            CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtmrpabatement" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                            ErrorMessage="Please enter mrp abatement% "></asp:RequiredFieldValidator>
                    </div>

                     <div class="form-group">
                        <label for="example-nf-email">Sequence No <span class="text-danger"></span></label>
                        <asp:TextBox ID="txtsequence" runat="server" placeholder="Sequence No" data-toggle="tooltip" title="Enter Sequence No"
                            CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtsequence" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                            ErrorMessage="Please enter sequence no"></asp:RequiredFieldValidator>
                    </div>

                    <div id="divdate" runat="server">
                        <div class="col-md-6" style="padding:0px 15px 0 0;">
                            <label for="example-nf-email">Created Date <span class="text-danger"></span></label>
                            <asp:TextBox ID="txtcreatedate" runat="server" placeholder="Created Date" ReadOnly="true" data-toggle="tooltip" title="Created Date"
                                CssClass="form-control"></asp:TextBox>
                            <br />
                        </div>

                        <div class="col-md-6" style="padding:0px 0px 0 0;">
                            <label for="example-nf-email">Modified Date <span class="text-danger"></span></label>
                            <asp:TextBox ID="txtmodifieddate" runat="server" placeholder="Modified Date" ReadOnly="true" data-toggle="tooltip" title="Modified Date"
                                CssClass="form-control"></asp:TextBox>
                            <br />
                        </div>

                    </div>
                    <div class="form-group">
                        <br />
                        <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroup" />
                        <asp:HyperLink ID="hfcancel" EnableViewState="false" Text="Cancel" runat="server" NavigateUrl="~/department.aspx" class="btn btn-alt btn-danger" />

                    </div>
                </div>



            </div>
                    </ContentTemplate>
                     <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="checkbox_tax"/>
                     </Triggers>
                 </asp:UpdatePanel>
                </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="col-md-6">

                 <div class="widget">
             
                <div class="widget-extra-full">
                     <div class="form-group" id="tax_block" runat="server">
                          <asp:RadioButtonList ID="rdtaxPrincipal" runat="server" CssClass="inline-rb" RepeatDirection="Horizontal" CellSpacing="10"  >
                             <asp:ListItem Value="Tax on Principal" Selected="True">Tax on Principal</asp:ListItem>
                             <asp:ListItem Value="Tax on Tax">Tax on Tax</asp:ListItem>
                         </asp:RadioButtonList>
                        
                    </div>
                       <div class="form-group" id="addition_block" runat="server" visible="false">
                            <asp:RadioButtonList ID="rdaddition" runat="server" CssClass="inline-rb" RepeatDirection="Horizontal" CellSpacing="10"  >
                             <asp:ListItem Value="Addition" Selected="True">Addition</asp:ListItem>
                             <asp:ListItem Value="Subtraction">Subtraction</asp:ListItem>
                         </asp:RadioButtonList>
                        
                    </div>
                  <%--  <div class="form-group">
                        <label for="example-nf-email">Tax Name <span class="text-danger">*</span></label>
                        <asp:TextBox ID="TextBox1" runat="server" placeholder="Enter Tax Name" data-toggle="tooltip" title="Enter Tax Name"
                            CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdepartname" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                            ErrorMessage="Please enter a Department name"></asp:RequiredFieldValidator>
                    </div>
           
                    <div id="div1" runat="server">
                        <div class="col-md-6" style="padding:0px 15px 0 0;">
                            <label for="example-nf-email">Created Date <span class="text-danger"></span></label>
                            <asp:TextBox ID="TextBox2" runat="server" placeholder="Created Date" ReadOnly="true" data-toggle="tooltip" title="Created Date"
                                CssClass="form-control"></asp:TextBox>
                            <br />
                        </div>

                        <div class="col-md-6" style="padding:0px 0px 0 0;">
                            <label for="example-nf-email">Modified Date <span class="text-danger"></span></label>
                            <asp:TextBox ID="TextBox3" runat="server" placeholder="Modified Date" ReadOnly="true" data-toggle="tooltip" title="Modified Date"
                                CssClass="form-control"></asp:TextBox>
                            <br />
                        </div>

                    </div>
                    <div class="form-group">
                        <br />
                        <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroup" />
                        <asp:HyperLink ID="HyperLink1" EnableViewState="false" Text="Cancel" runat="server" NavigateUrl="~/department.aspx" class="btn btn-alt btn-danger" />

                    </div>--%>
                </div>



            </div>
             </div>
                </ContentTemplate>
                <Triggers>

                    <asp:AsyncPostBackTrigger ControlID="rdtax"/>
                </Triggers>
            </asp:UpdatePanel>
             

        </div>
    </div>
</asp:Content>

