<%@ Control Language="VB" AutoEventWireup="false" CodeFile="NoteControl.ascx.vb" Inherits="UserControl_Back_NoteControl" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<asp:HiddenField ID="hftype" runat="server" />
<asp:HiddenField ID="hftypeid" runat="server" />
<asp:UpdatePanel ID="Updocumentpopup" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="btnfake"
            CancelControlID="btnNo">
        </asp:ModalPopupExtender>
        <asp:LinkButton ID="btnfake" runat="server"></asp:LinkButton>
        <asp:Panel ID="pnlPopup" runat="server" Style="display: none" DefaultButton="btnsave">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                        <h3 class="modal-title">Add Note</h3>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="example-nf-email">Note <span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtname" runat="server" TextMode="MultiLine" Columns="4" Rows="4" placeholder="Enter Note" data-toggle="tooltip" title="Enter Note"
                                CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="remembername" runat="server" SetFocusOnError="true" ControlToValidate="txtname" ValidationGroup="NoteGroup" CssClass="MasterValidationCSS"
                                ErrorMessage="Please enter note"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnsave" runat="server" OnClientClick="if (!Page_ClientValidate('NoteGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" class="btn btn-sm btn-primary" ValidationGroup="NoteGroup" Text="Save"></asp:Button>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnShow" />
        <asp:AsyncPostBackTrigger ControlID="btnsave" />
    </Triggers>
</asp:UpdatePanel>
<div id="faq1" class="panel-group">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq6" href="#faq6_q6">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbldoc" runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                        <asp:AsyncPostBackTrigger ControlID="lvnote" />
                    </Triggers>
                </asp:UpdatePanel>
            </a>
                <asp:LinkButton ID="btnShow" Text="Add Note" runat="server" ValidationGroup="DemogruopNote" class="btn btn-alt btn-sm btn-primary" Style="float: right; width: 122px; margin-top: -22px;" /></h4>
        </div>
        <div id="faq6_q6" class="panel-collapse collapse" style="height: 0px;">
            <div class="panel-body">
                <asp:UpdatePanel ID="updocument" runat="server">
                    <ContentTemplate>
                        <div class="col-sm-12">
                            <div class="">
                                <!-- Comments Content -->
                                <ul class="media-list">
                                    <asp:ListView ID="lvnote" DataKeyNames="Note_Id" runat="server" OnItemEditing="Edit_Command" OnItemUpdating="Update_Command" OnItemCanceling="Cancel_Command">
                                        <ItemTemplate>
                                            <li class="media">
                                                <a class="pull-left">
                                                    <img src='<%#Eval("U_ProfileImage")%>' height="64" width="64" alt="Avatar" class="img-circle">
                                                    <asp:Label ID="lblnoteid" runat="server" Text='<%#Eval("Note_Id")%>' Visible="false"></asp:Label>
                                                </a>
                                                <div class="media-body">
                                                    <span class="text-muted pull-right">
                                                        <asp:LinkButton ID="lnkedit" Visible="false" runat="server" data-toggle="tooltip" title="Edit" ClientIDMode="AutoID" class="btn btn-xs btn-primary" CommandName="Edit">Edit</asp:LinkButton>&nbsp;&nbsp;&nbsp;<small><em><%#Eval("Date")%></em></small></span>
                                                    <a><strong><%#Eval("U_FirstName")%></strong></a>
                                                    <p><%#Eval("Note_Text")%></p>
                                                </div>
                                            </li>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <li class="media">
                                                <a class="pull-left">
                                                    <img src='<%#Eval("U_ProfileImage")%>' height="64" width="64" alt="Avatar" class="img-circle">
                                                    <asp:Label ID="lblnoteid" runat="server" Text='<%#Eval("Note_Id")%>' Visible="false"></asp:Label>
                                                </a>
                                                <div class="media-body">
                                                    <span class="text-muted pull-right">
                                                        <asp:LinkButton ID="lnkupdate" runat="server" ClientIDMode="AutoID" data-toggle="tooltip" title="Update" CommandName="Update" class="btn btn-xs btn-primary">Update</asp:LinkButton>&nbsp;
                                                        <asp:LinkButton ID="lnkcancel" runat="server" ClientIDMode="AutoID" data-toggle="tooltip" title="Cancel" CommandName="Cancel" class="btn btn-xs btn-warning">Cancel</asp:LinkButton>&nbsp;
                                                        <asp:LinkButton ID="lnkdelete" runat="server" ClientIDMode="AutoID" data-toggle="tooltip" title="Delete" CommandName="deletelink" class="btn btn-xs btn-danger">Delete</asp:LinkButton>
                                                        &nbsp;&nbsp;&nbsp;<small><em><%#Eval("Date")%></em></small></span>
                                                    <a><strong><%#Eval("U_FirstName")%></strong></a>
                                                    <p>
                                                        <asp:TextBox ID="txtnote" runat="server" Text='<%#Eval("Note_Text")%>' TextMode="MultiLine" Rows="5" CssClass="form-control"></asp:TextBox>
                                                    </p>
                                                </div>
                                            </li>
                                        </EditItemTemplate>
                                    </asp:ListView>
                                </ul>
                                <asp:DataPager ID="DataPager1" PageSize="5" runat="server" class="MasterGridviewPaging" PagedControlID="lvnote">
                                    <Fields>
                                        <asp:NextPreviousPagerField ShowNextPageButton="False" ButtonType="Link" PreviousPageText="" ButtonCssClass="<" />
                                        <asp:NumericPagerField ButtonCount="10" ButtonType="Link" NumericButtonCssClass="numericLink" />
                                        <asp:NextPreviousPagerField ButtonType="Link" ShowPreviousPageButton="False" NextPageText="" ButtonCssClass=">" />
                                    </Fields>
                                </asp:DataPager>
                                <!-- END Comments Content -->
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lvnote" />
                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</div>
