<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MappingTaxNameControl.ascx.vb" Inherits="UserControl_Back_MappingTaxNameControl" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

   
      <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" >
          <ContentTemplate>
               <asp:LinkButton ID="btnShow" Text="Mapping Tax" runat="server" class="btn btn-alt btn-xs btn-primary" />
    :
              <asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="btnShow"
    CancelControlID="btnNo">
</asp:ModalPopupExtender>
              <asp:Repeater ID="rpassignto" runat="server">
                  <ItemTemplate>
                      <asp:LinkButton ID="lkdelete" runat="server" CommandName="deleteassign" ClientIDMode="AutoID" CssClass="label label-primary"><%# DataBinder.Eval(Container.DataItem, "Value") %>  <i class="fa fa-times"></i></asp:LinkButton>
                      <asp:Literal ID="ltid" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "Key")%>'></asp:Literal>
                  </ItemTemplate>
              </asp:Repeater>
          </ContentTemplate>
      </asp:UpdatePanel>
    <br />
    <br />

<asp:HiddenField ID="hftype" runat="server" />
<asp:HiddenField ID="hftypeid" runat="server" />

<asp:Panel ID="pnlPopup" runat="server" Style="display: none">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                <h4 class="modal-title">Mapping Tax Name</h4>
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
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Tax_Id" AllowCustomPaging="true"
                                CssClass="table table-striped table-vcenter" AlternatingRowStyle-CssClass="Alternate_grid" PageSize="5"
                                AllowPaging="True" AllowSorting="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Product_Id">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ckselect" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Tax_Id">
                                        <ItemTemplate>
                                            <asp:Literal ID="lbluId" runat="server" Text='<%#(Eval("Tax_Id"))%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tax Name" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Tax_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblname" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Tax_Name"), txtsearch)%>' />
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
                        <asp:AsyncPostBackTrigger ControlID="GridView1" />
                        <asp:AsyncPostBackTrigger ControlID="btnshowall" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnsave" runat="server" OnClientClick="if (!Page_ClientValidate('ItemGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                    UseSubmitBehavior="false" class="btn btn-sm btn-primary" ValidationGroup="ItemGroup" Text="Save"></asp:Button>
            </div>
        </div>
    </div>
</asp:Panel>

