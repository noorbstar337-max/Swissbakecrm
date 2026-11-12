<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="AccountOwner.aspx.vb" Inherits="ModifyCampaign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .control-label{padding: 6px;
        }
       .col-md-4 > .form-group {
        padding-bottom:0px;}

       .multiselect-container > li > a > label {
    padding: 5px 20px 5px 40px !important;
}

.multiselect-container > li > a > label > input[type="checkbox"] {
    margin-right: 8px !important;
}
    </style>    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <asp:HiddenField ID="hfemail" runat="server" />
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <i class="gi gi-shop" style="margin: -8px"></i>Modify Account Owner<br>
                    </h1>
                </div>
            </div>

            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="AccountOwnerlist.aspx">Account Owner List</a></li>
                <li>Modify Account Owner</li>
            </ul>

            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" OnClick="btnadd_Click"/>
                        <asp:HyperLink ID="HyperLink1" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/AccountOwnerlist.aspx" class="btn btn-alt btn-sm btn-danger" />
                </div>
            </div>
            <div class="col-md-12">
                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <h4 class="widget-content-light abc">
                            <strong>Account Owner</strong> Information                          
                            
                        </h4>
                        
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                           
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="col-md-4 control-label" for="example-hf-email">Account<span class="text-danger"> *</span></label>
                            <div class="col-md-8">
                                 <asp:DropDownList ID="ddlacc" runat="server" name="example-chosen" class="select-chosen" TabIndex="1"></asp:DropDownList>
                                <br />
                                <br />                                
                            </div>
                        </div>
                    </div>
                     <div class="col-md-6">
     <div class="form-group">
         <label class="col-md-4 control-label" for="example-hf-email">Owner<span class="text-danger"> *</span></label>
         <div class="col-md-8">
             <%-- <asp:DropDownList ID="ddluser" runat="server" name="example-chosen" class="select-chosen" TabIndex="2"></asp:DropDownList>--%>
              <asp:ListBox
    ID="ddluser"
    runat="server"
    CssClass="multiSelect"
    SelectionMode="Multiple">
</asp:ListBox>
             <br />
         </div>
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
                    <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" TabIndex="3" />
                        <asp:HyperLink ID="hfcancel" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/AccountOwnerlist.aspx" class="btn btn-alt btn-sm btn-danger" TabIndex="4" />
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </div>

   
</asp:Content>

