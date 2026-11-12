<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AssignToControl.ascx.vb" Inherits="UserControl_Back_AssignToControl" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>


<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:LinkButton ID="btnShow" Text="Assign To" runat="server" class="btn btn-alt btn-xs btn-primary" />
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
    <div class="modal-dialog modal-lg" style="overflow-y: scroll; position: fixed; top: 0; bottom: 0; left: 0; right: 0; overflow: auto;">
        <div class="modal-content" style="top: 1%; overflow-x: hidden; overflow-y: auto; outline: none; margin-top: 0; overflow: visible;">
            <div class="modal-header">
                <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                <h3 class="modal-title">Add User</h3>
            </div>
            <div class="modal-body" style="overflow: auto">
                <div class="table-options clearfix">
                    <%--<div class="col-sm-5 col-xs-4">
                        <div class="dataTables_length" id="example-datatable_length">
                            <asp:DropDownList ID="ddpagesize" AutoPostBack="true" runat="server" CssClass="form-control">
                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                <asp:ListItem Text="30" Value="30"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>--%>
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
                        <asp:Button ID="btnshowall" EnableViewState="false" runat="server" Text="Show All" CssClass="btn btn-alt btn-sm btn-primary" />
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="hfcheck" runat="server" />
                        <asp:HiddenField ID="hfchanged" runat="server" />
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="U_ID" 
                                CssClass="table table-striped table-vcenter" AlternatingRowStyle-CssClass="Alternate_grid" 
                                >
                                <Columns>
                                    <asp:TemplateField HeaderText="" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Product_Id">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ckselect" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="U_ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Literal ID="lbluId" runat="server" Text='<%#(Eval("U_ID"))%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="User Name" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="U_FirstName">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblname" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("U_FirstName"), txtsearch)%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Designation" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Desig_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lbldesig" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("Desig_Name")),txtsearch)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Department" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Deprt_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lbldept" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("Deprt_Name")), txtsearch)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact No" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="U_Mobile">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblcontact" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("U_Mobile")), txtsearch)%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EmailId" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="U_Email">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblemail" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("U_Email"), txtsearch)%>' />
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
                    UseSubmitBehavior="false" class="btn btn-sm btn-primary" ValidationGroup="ItemGroup" Text="Save changes"></asp:Button>
            </div>
        </div>
    </div>
</asp:Panel>

