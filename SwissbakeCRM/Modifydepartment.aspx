<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="Modifydepartment.aspx.vb" Inherits="Modifydepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <script src="js/ckeditor/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
        <div class="col-md-12">
             <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <i class="gi gi-table" style="margin: -8px"></i>Modify Department<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="department.aspx">Department</a></li>
                 <li>Modify Department</li>
            </ul>
            
            <div class="widget">
             
                <div class="widget-extra-full">
                    <div class="form-group">
                        <label for="example-nf-email">Department Name <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtdepartname" runat="server" placeholder="Enter Department Name" data-toggle="tooltip" title="Enter Service Name"
                            CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="remembername" runat="server" ControlToValidate="txtdepartname" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                            ErrorMessage="Please enter a Department name" SetFocusOnError="true" ></asp:RequiredFieldValidator>
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
        </div>
    </div>
</asp:Content>

