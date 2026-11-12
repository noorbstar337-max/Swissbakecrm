<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ProductItemControl.ascx.vb" Inherits="UserControl_Back_ProductItemControl" %>
<%--<User:SearchBar ID="SearchControl" runat="server" />--%>
<%--Search User Control End--%>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:HiddenField ID="hftype" runat="server" />
<asp:HiddenField ID="hftypeid" runat="server" />
<%--<asp:LinkButton ID="btnShow" Text="Add Item" runat="server" class="btn btn-sm btn-primary" />--%>

<asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="btnShow"
    CancelControlID="btnNo">
</asp:ModalPopupExtender>
<asp:Panel ID="pnlPopup" runat="server" Style="display: none">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                <h3 class="modal-title">Add Document</h3>
            </div>
            <div class="modal-body">
                <div class="table-options clearfix">
                    <div class="col-sm-5 col-xs-4">
                        <div class="dataTables_length" id="example-datatable_length">
                            <asp:DropDownList ID="ddpagesize" AutoPostBack="true" runat="server" CssClass="form-control">
                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                <asp:ListItem Text="30" Value="30"></asp:ListItem>
                            </asp:DropDownList>
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
                        <asp:HiddenField ID="hfcheck" runat="server" />
                        <asp:HiddenField ID="hfchanged" runat="server" />
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Product_Id" AllowCustomPaging="true"
                                CssClass="table table-striped table-vcenter" AlternatingRowStyle-CssClass="Alternate_grid"
                                AllowPaging="True" AllowSorting="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Product_Id">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ckselect" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" Visible="false" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Product_Id">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblscId" runat="server" Text='<%#(Eval("Product_Id"))%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product Name" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Product_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblname" runat="server" Text='<%#(Eval("Product_Name"))%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                 <%--   <asp:TemplateField HeaderText="Category Name" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Category_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblcatname" runat="server" Text='<%#(Eval("Category_Name"))%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

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
                        <asp:AsyncPostBackTrigger ControlID="GridView1" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnsave" runat="server" OnClientClick="if (!Page_ClientValidate('ItemGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                    UseSubmitBehavior="false" class="btn btn-sm btn-primary" ValidationGroup="ItemGroup" Text="Save changes"></asp:Button>
            </div>
        </div>
    </div>
</asp:Panel>
<div class="panel panel-default">
    <div class="panel-heading">
        <h4 class="panel-title"><i class="fa fa-angle-right"></i><a class="accordion-toggle" data-toggle="collapse" data-parent="#faq1" href="#faq1_q2">View Item Added</a><asp:LinkButton ID="btnShow" Text="Add Item" runat="server" class="btn btn-alt btn-sm btn-primary" Style="float: right; margin-top: -7px;" /></h4>
    </div>
    <div id="faq1_q2" class="panel-collapse collapse">
        <div class="panel-body">
            <asp:UpdatePanel ID="updocument" runat="server">
                <ContentTemplate>
                    <div class="table-responsive">
                        <asp:GridView ID="grditemproduct" ShowFooter="true" GridLines="None" CssClass="table table-striped table-vcenter" CellPadding="0" CellSpacing="0" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="Item Name" ItemStyle-Width="600" FooterStyle-Height="10px" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                    <ItemTemplate>
                                        <asp:Literal ID="ltproductid" runat="server" Visible="false" Text='<%# Container.DataItem%>'></asp:Literal>
                                         <asp:Literal ID="ltpname" runat="server"></asp:Literal>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div class="form-horizontal form-bordered">
                                            <div class="form-group">
                                                <div class="col-md-12">
                                                    <label class="col-md-4 control-label" for="example-hf-email" style="float: right">Total</label>
                                                </div>
                                            </div>
                                        </div>
                                       <%-- <div class="form-horizontal form-bordered">
                                            <div class="form-group">
                                                <div class="col-md-12">
                                                    <label class="col-md-4 control-label" for="example-hf-email" style="float: right">Ex-Rate</label>
                                                </div>
                                            </div>
                                        </div>--%>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="QTY/UOM" ItemStyle-Width="250px" FooterStyle-Height="10px" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                    <ItemTemplate>
                                        <div class="col-md-5">
                                            <asp:TextBox ID="txtquantity" Text="1" runat="server" Height="25" CssClass="form-control" OnTextChanged="txtquantity_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                           <asp:Literal ID="ltuom" Text="KG"  runat="server" ></asp:Literal>
                                           <asp:Literal ID="ltuomid" Visible ="false"   runat="server" ></asp:Literal>
                                        </div>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div class="form-horizontal form-bordered">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <div class="col-md-5">
                                                        <asp:TextBox ID="txtquantitytotal" runat="server" ReadOnly="true" Height="25" data-toggle="tooltip" title="Enter Service Name"
                                                            CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                   <%--     <div class="form-horizontal form-bordered">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <div class="col-md-4">
                                                        <asp:TextBox ID="txtquantityextotal" runat="server" ReadOnly="true" Height="25" data-toggle="tooltip" title="Enter Service Name"
                                                            CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>--%>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rate" ItemStyle-Width="150px" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtrate" runat="server" Height="25" CssClass="form-control" OnTextChanged="txtrate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                    <ItemTemplate>
                                        <div class="col-md-12">
                                            <asp:TextBox ID="txtamount" runat="server" ReadOnly="true" Height="25" data-toggle="tooltip" title="Enter Service Name"
                                                CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div class="col-md-12">
                                            <asp:Literal ID="lbltotal" runat="server" Visible="false"></asp:Literal>
                                            <asp:TextBox ID="txttotalamount" runat="server" ReadOnly="true" Height="25" data-toggle="tooltip" title="Enter Service Name"
                                                CssClass="form-control"></asp:TextBox>
                                            
                                        </div>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-CssClass="MasterGridviewHeader1" ItemStyle-CssClass="MasterGridviewItem">
                                    <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server">Delete</asp:HyperLink>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="btn-group btn-group-xs">
                                            <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <br />
                                <asp:Label ID="empty" Text="No Document Added" runat="server" CssClass="themed-color-fire"></asp:Label>
                            </EmptyDataTemplate>
                            <EmptyDataRowStyle VerticalAlign="Middle" />
                        </asp:GridView>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="grditemproduct" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</div>

