<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ItemDetailControl.ascx.vb" Inherits="UserControl_Back_ItemDetailControl" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:HiddenField ID="hftype" runat="server" />
<asp:HiddenField ID="hftypeid" runat="server" />
<asp:HiddenField ID="hfopptype" runat="server" />
<asp:HiddenField ID="hfopptypeid" runat="server" />
<div id="faq188" class="panel-group">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq188" href="#faq188_q188">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblitemdt" runat="server"></asp:Label></ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                    </Triggers>
                </asp:UpdatePanel>
            </a></h4>
        </div>
        <div id="faq188_q188" class="panel-collapse collapse" style="height: 0px;max-height: 303px;overflow: auto;">
            <div class="panel-body">
                <asp:LinkButton ID="btnShow" Text="" runat="server" />
                <asp:LinkButton ID="btnopen" Text="Add Item" runat="server" class="btn btn-alt btn-xs btn-primary" />
                <br />
                <br />
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="table-responsive">
                            <asp:GridView ID="grditemproduct" ShowFooter="true"    GridLines="None" CssClass="table table-striped table-vcenter" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true"  HeaderStyle-Font-Size="Smaller" CellPadding="0" CellSpacing="0" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="Product Name"  HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                         <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink11" runat="server">Product Name</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Literal ID="ltproductname" runat="server" Text='<%#Eval("Product_Name")%>'></asp:Literal>
                                            <asp:Literal ID="ltitemid" runat="server" Text='<%#Eval("ItemDt_ID")%>' Visible="false"></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product Code" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                          <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink12" runat="server">Product Code</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Literal ID="ltproductcode" runat="server" Text='<%#Eval("Product_Code")%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SKU" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                          <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink13" runat="server">SKU</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Literal ID="ltproductWeight" runat="server" Text='<%#Eval("Packing_Weight")%>' Visible="false"></asp:Literal>
                                            <asp:Literal ID="ltpackingpacking" runat="server" Text='<%#Eval("Packing_Packing")%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                          <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink15" runat="server">Rate/kg</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                           <i class="fa fa-rupee"></i>&nbsp; <asp:Literal ID="ltrate" runat="server" Text='<%#Eval("ItemDt_Rate")%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No.Of Pack" ItemStyle-Width="100px" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                        <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink14" runat="server">No.Of Pack</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="col-md-12">
                                                <asp:TextBox ID="txtquantity" runat="server" Visible="false" onkeyup="this.value=this.value.replace(/[^\d\.]/g,'');" OnTextChanged="txtquantity_TextChanged" AutoPostBack="true" Text='<%#Eval("ItemDt_Qty")%>' Height="25" data-toggle="tooltip" title="Enter Qunatity"
                                                    CssClass="form-control"></asp:TextBox>
                                                <asp:Literal ID="ltquantity" runat="server" Text='<%#Eval("ItemDt_Qty")%>'></asp:Literal>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="KG" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                          <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink17" runat="server">KG</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Literal ID="ltkg" Text='<%#Eval("Packing_Weight")%>' runat="server"></asp:Literal> kg
                                            <%-- <asp:Literal ID="lblvat" runat="server" Text='<%#Eval("Product_Vat")%>' Visible="false" />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="VAT" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                          <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink17" runat="server">VAT</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            
                                            
                                            <i class="fa fa-rupee"></i>&nbsp; <asp:Literal ID="lblvatinrs" runat="server" Text='<%#Eval("Product_Vat")%>' />(<asp:Literal ID="lblvat" runat="server" Text='<%#Eval("Product_Vat")%>' />%)
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            Total VAT:<br /><hr style="border:0;border-top: 1px solid #eee;margin-top:4px;margin-bottom:4px;"" />
                                              Freight:<br />
                                                            <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />
                                            Total Amount:
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                            <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink18" runat="server">Amount</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <i class="fa fa-rupee"></i>&nbsp;<asp:Literal ID="ltamount" Text='<%#Eval("ItemDt_Amount")%>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <FooterTemplate>
<%--Total Amount:<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                                            <b><i class="fa fa-rupee"></i>&nbsp;<asp:Literal ID="lttotalvat" Text='78500' runat="server"></asp:Literal></b><br />
                                                                            <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />
                                                                            <b><i class="fa fa-rupee"></i>&nbsp;
                                                                <asp:Label ID="lblfreight"  runat="server"></asp:Label>

                                                            </b>
                                                            <br /><hr style="border:0;border-top: 1px solid #eee;margin-top:4px;margin-bottom:4px;" /><b><i class="fa fa-rupee"></i>&nbsp; <asp:Literal ID="lttotalamount" Text='78500' runat="server"></asp:Literal></b></FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:LinkButton ID="lkupdate" data-toggle="tooltip" title="Update" Visible="false" runat="server" class="btn btn-primary"
                                                    CommandName="updatelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>">Update</asp:LinkButton>
                                                <asp:LinkButton ID="lnkedit" data-toggle="tooltip" title="Edit" runat="server" class="btn btn-primary"
                                                    CommandName="Editlink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>">Edit</asp:LinkButton>

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
                        <asp:AsyncPostBackTrigger ControlID="grditemproduct" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="btnShow"
                    CancelControlID="btnNo">
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlPopup" runat="server" Style="display: none">
                    <div class="modal-dialog modal-lg" style="overflow-y: scroll; position: fixed; top: 0; bottom: 0; left: 0; right: 0; overflow: auto;">
                        <div class="modal-content" style="top: 1%; overflow-x: hidden; overflow-y: auto; outline: none; margin-top: 0; overflow: visible;">
                            <div class="modal-header">
                                <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                                <h3 class="modal-title">Add Product</h3>
                            </div>
                            <div class="modal-body" style="overflow: auto">
                                <div class="table-options clearfix">
                                    <div class="col-sm-5 col-xs-4">
                                        <div class="dataTables_length" id="example-datatable_length">
                                          <%--  <asp:DropDownList ID="ddpagesize" AutoPostBack="true" runat="server" CssClass="form-control">
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
                                                CssClass="table table-striped table-vcenter table-hover">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Select" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Product_Id">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ckselect" runat="server" />
                                                            <asp:Literal ID="lblProductId" runat="server" Text='<%#Eval("Product_Id")%>' Visible="false" />
                                                            <asp:Literal ID="lbldiscount" runat="server" Text='<%#Eval("Discount_Discount")%>' Visible="false"></asp:Literal>
                                                            <asp:Literal ID="lblrate" runat="server" Text='<%#Eval("Product_Rate")%>' Visible="false" />
                                                            <asp:Literal ID="lblvat" runat="server" Text='<%#Eval("Product_Vat")%>' Visible="false" />
                                                            <asp:Literal ID="lblunit" runat="server" Text='<%#Eval("Packing_weight")%>' Visible="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Product Name" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Product_Name">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblname" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDisplayFunctions.TruncateDescription(Eval("Product_Name"), "100"), txtsearch)%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Category" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="PrdCategory_Name">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblCategory" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("PrdCategory_Name"), txtsearch)%>' />
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
                                        <asp:AsyncPostBackTrigger ControlID ="btnshowall" />
                                    </Triggers>
                                </asp:UpdatePanel>

                            </div>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="modal-footer">
                                        <asp:Button ID="btnsave" runat="server" OnClientClick="if (!Page_ClientValidate('ProductItemGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                            UseSubmitBehavior="false" class="btn btn-sm btn-primary" ValidationGroup="ProductItemGroup" Text="Save changes"></asp:Button>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnopen" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</div>
<asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="" runat="server" DisplayAfter="0">
    <ProgressTemplate>
        <br />
        <div class="divWaiting">
            <i class="fa fa-sun-o fa-spin" id="LoadingUpadatePanel"></i>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
