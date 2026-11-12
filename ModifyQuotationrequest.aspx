<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ModifyQuotationrequest.aspx.vb" Inherits="ModifyQuotationrequest" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .control-label {
            padding: 6px;
        }

        .col-md-4 > . {
            padding-bottom: 0px;
        }

        .c-label {
            padding-left: 13em;
        }

        .multiselect {
            width: 33em;
            height: 15em;
            border: solid 1px;
            overflow: auto;
        }

            .multiselect label {
                display: inline;
            }
    </style>
    <style>
        input[type=date]::-webkit-inner-spin-button {
            -webkit-appearance: none;
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hfsearch" runat="server" />

    <div class="row">
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <i class="gi gi-parents" style="margin: -8px"></i>
                        <asp:Label ID="lbltitle1" runat="server"></asp:Label><br>
                        <asp:Label ID="lblconvertdate" runat="server" Visible="false"></asp:Label>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="QuotationRequest.aspx">Quotation Request</a></li>
                <li>
                    <asp:Label ID="lbltitle2" runat="server"></asp:Label></li>
                <asp:HiddenField ID="strrowcount" runat="server" />
            </ul>
            <asp:Panel ID="FullPanel" runat="server">
                <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                    <div class="pull-right">
                        <div class="" style="">
                            <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroup" OnClick="btnadd_Click" />
                            <%--<asp:LinkButton ID="HyperLink1" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/QuotationRequest.aspx" class="btn btn-alt btn-danger" OnClick="hfcancel_Click" />--%>
                            <a href="QuotationRequest.aspx" class="btn btn-alt btn-danger">Cancel</a>
                        </div>
                    </div>
                </div>

                <div class="col-md-12">
                    <div class="widget">
                        <div class="widget-extra themed-background-dark">
                            <h4 class="widget-content-light abc">
                                <strong>Quotation</strong> Request
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
                                <div class="col-md-12">
                                    <div class="col-md-3">
                                        <label class="control-label" for="example-hf-email">Code<span class="text-danger"> *</span></label>
                                        <asp:TextBox ID="txtcode" runat="server" placeholder="Enter Code" data-toggle="tooltip" title="Enter Code" ReadOnly="true"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reVendorname" runat="server" ControlToValidate="txtcode" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter code" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>

                                    </div>

                                    <div class="col-md-2">
                                        <label class="control-label" for="example-hf-email">Valid Upto<span class="text-danger"> *</span></label>
                                        <asp:TextBox ID="txtdate" onkeypress="return false;" runat="server" placeholder="Select Date" data-toggle="tooltip" title="Enter Date" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdate" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter date" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>

                                    </div>

                                    <div class="col-md-3">
                                        <label class="control-label" for="example-hf-password">Godown<span class="text-danger"> *</span></label>
                                        <asp:DropDownList ID="ddgodown" runat="server" name="example-chosen" class="select-chosen">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="recompnytype" runat="server" InitialValue="Select Godown" ControlToValidate="ddgodown" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select godown" SetFocusOnError="true"></asp:RequiredFieldValidator>

                                    </div>
                                    <div class="col-md-4">
                                        <label class="control-label">Billed To <span class="text-danger">*</span></label>
                                        <asp:DropDownList ID="ddlbilledfrom" runat="server" data-toggle="tooltip" title="Billed From" class="select-chosen" TabIndex="1">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rebill" runat="server" ControlToValidate="ddlbilledfrom" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please select company" InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <label class="control-label" for="example-hf-email">Additional Information<span class="text-danger"> </span></label>

                                    <asp:TextBox ID="txtaddinfo" runat="server" placeholder="Enter Additional Information" data-toggle="tooltip" title="Enter Additional Information" TextMode="MultiLine" Rows="2"
                                        CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtaddinfo" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                        ErrorMessage="Please additional information" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>


                                </div>


                                <div style="clear: both"></div>
                            </div>
                        </div>
                    </div>
                    <div class="widget">
                        <div class="widget-extra themed-background-dark">
                            <h4 class="widget-content-light">
                                <strong>Item</strong> Details
                            </h4>
                        </div>
                        <div class="widget-extra-full">
                            <div class="form-horizontal form-bordered">
                                <div class="col-md-12">
                                    <br />
                                </div>
                                <div class="block">
                                    <div class="col-md-12">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div class="table-responsive">
                                                    <asp:HiddenField ID="hfgrandtotal" runat="server" />
                                                    <asp:HiddenField ID="hfbarcodechk" runat="server" />
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="" AllowCustomPaging="true"
                                                        CssClass="table table-striped table-vcenter table" ShowFooter="true">
                                                        <Columns>
                                                            <asp:BoundField DataField="RowNumber" Visible="false" />
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <div class="col-md-6" runat="server" visible="false">
                                                                        <asp:Label runat="server" ID="RowNumber" Text='<%#Eval("RowNumber")%>'></asp:Label>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Item Name" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="">
                                                                <ItemTemplate>
                                                                    <div class="input-group  col-md-12">
                                                                        <span class="input-group-addon"><i class="gi gi-tags"></i></span>
                                                                        <asp:DropDownList ID="ddrawmaterial" AutoPostBack="true" OnSelectedIndexChanged="ddrawmaterial_SelectedIndexChanged" runat="server" CssClass="select-chosen"></asp:DropDownList>
                                                                        <asp:Literal ID="ltattid" runat="server" Text='<%#Eval("QRRawMaterial_RawID")%>' Visible="false"></asp:Literal>
                                                                        <asp:Literal ID="ltqrid" runat="server" Text='<%#Eval("QRRawMaterial_QRDID")%>' Visible="false"></asp:Literal>
                                                                        <asp:RequiredFieldValidator ID="rfvddmaterial" runat="server" ControlToValidate="ddrawmaterial" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                                            ErrorMessage="Select Item" InitialValue="Select Item" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                    </div>

                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Quantity" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                                <ItemTemplate>
                                                                    <%--<asp:Label ID="lblcontact" runat="server" Text='<%#Eval("Principle_ContactPerson")%>'></asp:Label>--%>
                                                                    <asp:TextBox ID="txtquantity" runat="server" Text='<%#Eval("QRRawMaterial_Quantity")%>' data-toggle="tooltip" CssClass="form-control"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvdqty" runat="server" ControlToValidate="txtquantity" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                                        ErrorMessage="Please enter quantity" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Unit" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblunite" runat="server" Text='<%#Eval("QRRawMaterial_Unit")%>' Visible="false"></asp:Label>
                                                                    <asp:DropDownList ID="ddunuit" runat="server" CssClass="select-chosen">
                                                                        <%--   <asp:ListItem Value="0" Text="Select Material"></asp:ListItem>--%>
                                                                        <asp:ListItem Value="KG" Text="KG"></asp:ListItem>
                                                                        <%--<asp:ListItem Value="Numbers" Text="Numbers"></asp:ListItem>--%>
                                                                        <asp:ListItem Value="Nos." Text="Nos."></asp:ListItem>
                                                                        <asp:ListItem Value="Each" Text="Each"></asp:ListItem>
                                                                        <asp:ListItem Value="SqMt" Text="SqMt"></asp:ListItem>
                                                                        <asp:ListItem Value="RnMt" Text="RnMt"></asp:ListItem>
                                                                        <asp:ListItem Value="Ltr" Text="Ltr"></asp:ListItem>
                                                                        <asp:ListItem Value="Unit" Text="Unit"></asp:ListItem>

                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvddunit" runat="server" ControlToValidate="ddunuit" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                                        ErrorMessage="Select unit" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" Visible="false">
                                                                <ItemTemplate>
                                                                    <div class="btn-group btn-group-xs">
                                                                        <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                                            CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <div class="btn-group btn-group-xs">
                                                                        <asp:LinkButton ID="lnkadd" data-toggle="tooltip" title="Add" class="btn btn-info" runat="server"
                                                                            CommandName="AddNewRow" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="gi gi-plus"></i></asp:LinkButton>
                                                                    </div>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="Right" BackColor="White" />
                                                        <FooterStyle HorizontalAlign="Center" BackColor="White" />
                                                        <PagerSettings PageButtonCount="4" />
                                                        <EmptyDataTemplate>
                                                            <h3>Add Receipt Detail</h3>
                                                            <div class="btn-group btn-group-xs" style="align-content: center;">
                                                                <asp:LinkButton ID="lnkadd" data-toggle="tooltip" title="Add" class="btn btn-info" runat="server" Font-Size="20px" Width="100px"
                                                                    CommandName="Add" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"> Add Receipt</asp:LinkButton>
                                                            </div>
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
                                    <div style="clear: both;"></div>
                                    <br />

                                </div>


                            </div>
                        </div>
                    </div>


                    <div class="widget">
                        <div class="widget-extra themed-background-dark">
                            <h4 class="widget-content-light abc">
                                <strong>Vendor</strong> Details                         
                            </h4>

                        </div>
                        <div class="widget-extra-full">
                            <div class="form-horizontal form-bordered">
                                <div class="col-md-12">
                                    <br />
                                </div>
                                <%--<div class="col-md-12">
                            <div class="">
                                <label class="col-md-2 control-label" for="example-hf-email">Vendor Name<span class="text-danger"> *</span></label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="txttargetcategoryname" runat="server" placeholder="Enter Target Category Name" data-toggle="tooltip" title="Enter Target Category Name"
                                        CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="remembername" runat="server" ControlToValidate="txttargetcategoryname" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="Please enter target category name" SetFocusOnError="true" ></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>--%>
                                <div class="col-md-12">
                                    <asp:LinkButton ID="btnopen" Text="Add Vendor" ValidationGroup="MasterGroup13" runat="server" class="btn btn-alt btn-xs btn-primary" />
                                    <br />
                                    <br />
                                </div>
                                <div class="col-md-12">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="table-responsive">
                                                <asp:GridView ID="grditemproduct" ShowFooter="true" GridLines="None" CssClass="table table-striped table-vcenter" HeaderStyle-Width="100"
                                                    HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Smaller" CellPadding="0" CellSpacing="0" runat="server" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Vendor Name" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                            <HeaderTemplate>
                                                                <asp:HyperLink ID="HyperLink11" runat="server">Vendor Name</asp:HyperLink>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="ltvendorname" runat="server" Text='<%#Eval("Vendor_Name")%>'></asp:Label>
                                                                <asp:Label ID="ltvendorid" runat="server" Text='<%#Eval("Vendor_ID")%>' Visible="false"></asp:Label>
                                                                <asp:Label ID="ltitemid" runat="server" Text='<%#Eval("ItemDt_ID")%>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Contact Person" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                            <HeaderTemplate>
                                                                <asp:HyperLink ID="HyperLink12" runat="server">Contact Person</asp:HyperLink>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="ltcntactprsn" runat="server" Text='<%#Eval("Contact_ContactPerson")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="EmailId" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                            <HeaderTemplate>
                                                                <asp:HyperLink ID="HyperLink13" runat="server">EmailId</asp:HyperLink>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="ltemail" runat="server" Text='<%#Eval("Contact_Email")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Mobile" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                            <HeaderTemplate>
                                                                <asp:HyperLink ID="HyperLink13" runat="server">Mobile</asp:HyperLink>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("Contact_Mobile")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                            <HeaderTemplate>
                                                                <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <div class="btn-group btn-group-xs">
                                                                    <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger" runat="server" OnClientClick="checkdelete();"
                                                                        CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>">Delete</asp:LinkButton>
                                                                </div>
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

                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="GridView1" />
                                            <asp:AsyncPostBackTrigger ControlID="btnsave" />
                                            <asp:AsyncPostBackTrigger ControlID="btnsaveclose" />
                                            <asp:AsyncPostBackTrigger ControlID="grditemproduct" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <asp:LinkButton ID="btnShow" runat="server" Text=""></asp:LinkButton>
                                <asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="btnShow"
                                    CancelControlID="btnNo">
                                </asp:ModalPopupExtender>
                                <asp:Panel ID="pnlPopup" runat="server" Style="display: none">
                                    <div class="modal-dialog modal-lg" style="overflow-y: scroll; position: fixed; top: 0; bottom: 0; left: 0; right: 0; overflow: auto; width: 1192px;">
                                        <div class="modal-content" style="top: 1%; overflow-x: hidden; overflow-y: auto; outline: none; margin-top: 0; overflow: visible;">
                                            <div class="modal-header">
                                                <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                                                <h3 class="modal-title">Add Vendor</h3>
                                            </div>
                                            <div class="modal-body" style="overflow: auto; height: 400px;">
                                                <div class="table-options clearfix">
                                                    <div class="col-sm-5 col-xs-4">
                                                        <div class="dataTables_length" id="example-datatable_length">
                                                            <%-- <asp:DropDownList ID="ddpagesize" AutoPostBack="true" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                    <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                                </asp:DropDownList>--%>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-4 col-xs-12">
                                                        <div id="example-datatable_filter" class="dataTables_filter">
                                                            <label>
                                                                <div class="input-group">
                                                                    <asp:TextBox ID="txtsearch" runat="server" class="form-control" placeholder="Search" AutoPostBack="true" /><span class="input-group-addon">
                                                                        <i class="fa fa-search"></i></span>
                                                                </div>
                                                            </label>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-3 col-xs-12">
                                                        <asp:Button ID="btnshowall" EnableViewState="false" Visible="false" runat="server" Text="Show All" CssClass="btn btn-alt btn-sm btn-info" />
                                                    </div>
                                                </div>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Vendor_ID"
                                                                CssClass="table table-striped table-vcenter table-hover" Font-Size="12px">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Select" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Vendor_ID">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="ckselect" runat="server" AutoPostBack="true" />
                                                                            <asp:Label ID="lblVendorID" runat="server" Text='<%#Eval("Vendor_ID")%>' Visible="false" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Vendor Name" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Vendor_Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("Vendor_Name")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Contact Person" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Contact_ContactPerson">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblcontact" runat="server" Text='<%#Eval("Contact_ContactPerson")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>


                                                                    <asp:TemplateField HeaderText="Mobile" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Contact_Mobile">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("Contact_Mobile")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Email" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Contact_Email">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblemail" runat="server" Text='<%#Eval("Contact_Email")%>' />
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
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                                                        <asp:AsyncPostBackTrigger ControlID="btnopen" />
                                                        <asp:AsyncPostBackTrigger ControlID="btnshowall" />
                                                        <asp:AsyncPostBackTrigger ControlID="txtsearch" EventName="TextChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="modal-footer">
                                                        <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-primary" Text="Save changes"></asp:Button>
                                                        <asp:Button ID="btnsaveclose" runat="server" class="btn btn-sm btn-primary" Text="Save & Close"></asp:Button>
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnopen" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <div style="clear: both"></div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                    <div class="pull-right">
                        <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroup" />
                        <%--<asp:LinkButton ID="hfcancel" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/QuotationRequest.aspx" class="btn btn-alt btn-danger" />--%>
                        <a href="QuotationRequest.aspx" class="btn btn-alt btn-danger">Cancel</a>
                        <br />
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>


