<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ModifyTargetCategory.aspx.vb" Inherits="ModifyTargetCategory" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
       <%-- <asp:HiddenField ID="hfemail" runat="server" />
        <asp:HiddenField ID="hfimgpath" runat="server" />
        <asp:HiddenField ID="hfimgpathheader" runat="server" />
        <asp:HiddenField ID="hfimgpathfooter" runat="server" />--%>
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <%--<i class="gi gi-user" style="margin: -8px"></i>Target Category<br>--%>
                        <asp:Label ID="lbltitle1" runat="server"></asp:Label><br>
                    </h1>
                </div>
            </div>

            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="AdminMenu.aspx">Admin</a></li>
                <li><a href="TargetCategory.aspx">Target Category</a></li>
                <li><asp:Label ID="lbltitle2" runat="server"></asp:Label></li>
                <%--<li>Target Category</li>--%>
            </ul>

           <%-- <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" OnClick="btnadd_Click" />
                    <asp:HyperLink ID="HyperLink1" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/index.aspx" class="btn btn-alt btn-sm btn-danger" />
                </div>
            </div>--%>

            <div class="col-md-12">
                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <h4 class="widget-content-light abc">
                            <strong>Target Category</strong> Information
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
                            <div class="">
                                <label class="col-md-2 control-label" for="example-hf-email">Target Category Name<span class="text-danger"> *</span></label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="txttargetcategoryname" runat="server" placeholder="Enter Target Category Name" data-toggle="tooltip" title="Enter Target Category Name"
                                        CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="remembername" runat="server" ControlToValidate="txttargetcategoryname" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="Please enter target category name" SetFocusOnError="true" ></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                             <div class="col-md-12">                                   
                                    <asp:LinkButton ID="btnopen" Text="Add Item" ValidationGroup="MasterGroup" runat="server" class="btn btn-alt btn-xs btn-primary" TabIndex="11" />                                   
                                    <br />
                                    <br />
                                 </div>
                            <div class="col-md-12">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>                                        
                                        <div class="table-responsive">
                                            <asp:GridView ID="grditemproduct" ShowFooter="true" GridLines="None" CssClass="table table-striped table-vcenter" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Smaller" CellPadding="0" CellSpacing="0" runat="server" AutoGenerateColumns="false">
                                                <Columns>
                                                     <asp:TemplateField HeaderText="Product Code" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink12" runat="server">Product Code</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="ltproductcode" runat="server" Text='<%#Eval("Product_Code")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Product Name" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink11" runat="server">Product Name</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="ltproductname" runat="server" Text='<%#Eval("Product_Name")%>'></asp:Label>
                                                             <asp:Label ID="ltproductid" runat="server" Text='<%#Eval("Product_Id")%>' Visible="false"></asp:Label>
                                                            <asp:Label ID="ltitemid" runat="server" Text='<%#Eval("ItemDt_ID")%>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                   
                                                    <asp:TemplateField HeaderText="SKU" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink13" runat="server">SKU</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>                                                            
                                                            <asp:Label ID="ltpackingpacking" runat="server" Text='<%#Eval("Packing_Packing")%>'></asp:Label>                                                           
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Category" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                            <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink13" runat="server">Category</asp:HyperLink>
                                                        </HeaderTemplate>
                                                         <ItemTemplate>
                                                                <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("PrdCategory_Name")%>' />
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
                                    <h3 class="modal-title">Add Product</h3>
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
                                                        <asp:TextBox ID="txtsearch" runat="server" class="form-control" placeholder="Search" /><span class="input-group-addon">
                                                            <i class="fa fa-search"></i></span>
                                                    </div>
                                                </label>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <asp:Button ID="btnshowall" EnableViewState="false" runat="server" Text="Show All" CssClass="btn btn-alt btn-sm btn-info" />
                                        </div>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="table-responsive">
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Product_Id"
                                                    CssClass="table table-striped table-vcenter table-hover" Font-Size="12px">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Select" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Product_Id">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ckselect" runat="server" />
                                                                <asp:Label ID="lblproductId" runat="server" Text='<%#Eval("Product_Id")%>' Visible="false"/>
                                                               
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       
                                                        <asp:TemplateField HeaderText="Code" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Product_Code">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcode" runat="server" Text='<%#Eval("Product_Code")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField HeaderText="Product Name" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Product_Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblname" runat="server" Text='<%#Eval("Product_Name")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField HeaderText="SKU" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Packing_Packing">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblunit" runat="server" Text='<%#Eval("Packing_Packing")%>' />                                                                                                                             
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField HeaderText="Category" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="PrdCategory_Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("PrdCategory_Name")%>' />
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
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="modal-footer">
                                            <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-primary"  Text="Save changes"></asp:Button>
                                            <asp:Button ID="btnsaveclose" runat="server" class="btn btn-sm btn-primary"  Text="Save & Close"></asp:Button>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnopen" />                                         
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </asp:Panel>


                            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                                <div class="pull-right">
                                    <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" />
                                    <asp:HyperLink ID="hfcancel" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/TargetCategory.aspx" class="btn btn-alt btn-sm btn-danger" />
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

