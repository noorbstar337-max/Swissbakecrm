<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ModifyProduct.aspx.vb" Inherits="ModifyProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .control-label {
            padding: 6px;
        }

        .col-md-4 > . {
            padding-bottom: 0px;
        }
    </style>
    <script type="text/javascript">
        function checkdelete() {
            if (confirm('Are you Sure want to Delete?')) {
                document.getElementById('<%=deletestatus.ClientID %>').value = "yes";
                return true
            }
            else {
                document.getElementById('<%=deletestatus.ClientID %>').value = "no";
                return true
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="deletestatus" runat="server" />
    <div class="row">
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <%-- <i class="fa fa-cubes" style="margin: -8px"></i>Modify Product<br>--%>
                        <asp:Label ID="lbltitle1" runat="server"></asp:Label><br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="Product.aspx">Product</a></li>
                <li>
                    <asp:Label ID="lbltitle2" runat="server"></asp:Label></li>
                <%--<li>Modify Product</li>--%>
            </ul>

            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" OnClick="btnadd_Click" />
                    <asp:HyperLink ID="HyperLink1" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/Product.aspx" class="btn btn-alt btn-sm btn-danger" />
                </div>
            </div>

            <div class="col-md-12">
                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <h4 class="widget-content-light">
                            <strong>Product</strong> Information
                         <small>
                             <span class="pull-right" id="modifyspan" runat="server">By&nbsp;<a style="text-decoration: none;"><asp:Label ID="lblmodifiedname" runat="server" Font-Bold="true"></asp:Label></a>&nbsp;on&nbsp;<a style="text-decoration: none;"><asp:Label ID="lblmodifieddate" Font-Bold="true" runat="server" Font-Italic="true"></asp:Label></a>
                             </span>
                         </small>
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-email">Product Name<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtproductname" runat="server" placeholder="Enter Product Name" data-toggle="tooltip" title="Enter Product Name"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="remembername" runat="server" ControlToValidate="txtproductname" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter  product name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Category<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddcategory" runat="server" name="example-chosen" class="select-chosen"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddcategory" InitialValue="Select Category" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select category" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Refer No/ID</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtrefid" runat="server" placeholder="Enter Reference No/ID" data-toggle="tooltip" title="Enter Reference No/ID"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtrefid" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Enter Refer No/ID" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">UOM <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="dduom" runat="server" name="example-chosen" class="select-chosen"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dduom" InitialValue="0" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select uom" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Currency <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddcurrency" runat="server" name="example-chosen" class="select-chosen"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddcurrency" InitialValue="0" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select currency" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Price <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtprice" runat="server" placeholder="Enter Price" data-toggle="tooltip" title="Enter Price"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtprice" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Enter price" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Min Order</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtminorder" runat="server" placeholder="Min Order" data-toggle="tooltip" title="Min Order"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtminorder" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Enter min order" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Bar Code</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtbarcode" runat="server" placeholder="Bar Code" data-toggle="tooltip" title="Bar Code"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtbarcode" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Enter barcode" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Tariff Heading</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txttariffheading" runat="server" placeholder="Tariff Heading" data-toggle="tooltip" title="Tariff Heading"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txttariffheading" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Enter tariff heading" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4" id="divopenningstock" runat="server">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Openning Stock</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtopenstock" runat="server" placeholder="Openning Stock" data-toggle="tooltip" title="Openning Stock"
                                            CssClass="form-control" TextMode="Number" step="any"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txttariffheading" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Enter openning stock" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email" style="width: auto;">Product Descriptn<span class="text-danger"> *</span></label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtdesc" runat="server" TextMode="MultiLine" Rows="2" Columns="4" placeholder="Enter Product Description" data-toggle="tooltip" title="Enter Product Description"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtdesc" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter  product description" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div id="divdate" runat="server" visible="false">
                                <div class="col-md-3">
                                    <div class="">
                                        <label for="example-nf-email">Created Date</label>
                                        <asp:TextBox ID="txtcreatedate" runat="server" ReadOnly="true" placeholder="Created Date" data-toggle="tooltip" title="Created Date"
                                            CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="">
                                        <label for="example-nf-email">Created Name</label>
                                        <asp:TextBox ID="txtcreatedname" runat="server" placeholder="Modified Date" ReadOnly="true" data-toggle="tooltip" title="Modified Date"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="">
                                        <label for="example-nf-email">Modified Date</label>
                                        <asp:TextBox ID="txtmodifieddate" runat="server" placeholder="Modified Date" ReadOnly="true" data-toggle="tooltip" title="Modified Date"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="">
                                        <label for="example-nf-email">Modified Name</label>
                                        <asp:TextBox ID="txtmodifiedname" runat="server" placeholder="Modified Date" ReadOnly="true" data-toggle="tooltip" title="Modified Date"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>



                            </div>
                            <div class="col-md-12">
                                <div class="">
                                    <br />
                                    <User:DocumentControl ID="documentcontrol" runat="server" />
                                    <User:NewDocumentControl ID="Newdocumentcontrol" runat="server" />
                                    <%-- <User:ItemControl ID="itemcontrol" runat="server" />--%>
                                </div>
                            </div>
                            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                                <div class="pull-right">
                                    <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" />
                                    <asp:HyperLink ID="hfcancel" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/Product.aspx" class="btn btn-alt btn-sm btn-danger" />
                                </div>
                            </div>
                            <div style="clear: both"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

