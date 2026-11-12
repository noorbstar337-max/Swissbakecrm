<%@ Control Language="VB" AutoEventWireup="false" CodeFile="NewDocumentControl.ascx.vb" Inherits="UserControl_Back_NewDocumentControl" %>
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
                        <h3 class="modal-title">Add Document</h3>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="example-nf-email">Document Name <span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtname" runat="server" placeholder="Enter Document Name" data-toggle="tooltip" title="Enter Document Name"
                                CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="remembername" runat="server" Display="Dynamic" ControlToValidate="txtname" ValidationGroup="DocumentGroup" CssClass="MasterValidationCSS"
                                ErrorMessage="Please enter  document name"></asp:RequiredFieldValidator>

                        </div>
                        <div class="form-group">
                            <label for="example-nf-email">Select File <span class="text-danger">*</span></label>
                            <asp:FileUpload ID="fpdocument" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fpdocument" Display="Dynamic" ValidationGroup="DocumentGroup" CssClass="MasterValidationCSS"
                                ErrorMessage="select file"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnsave" runat="server" OnClientClick="if (!Page_ClientValidate('DocumentGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" class="btn btn-sm btn-primary" ValidationGroup="DocumentGroup" Text="Save changes"></asp:Button>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnShow" />
        <asp:PostBackTrigger ControlID="btnsave" />
    </Triggers>
</asp:UpdatePanel>
<div id="faq187" class="panel-group">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq187" href="#faq187_q1">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lbldoc" runat="server"></asp:Label></ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grddcoument" />
                    </Triggers>
                </asp:UpdatePanel>
            </a>
                <asp:LinkButton ID="btnShow" Text="Attach Document" runat="server" class="btn btn-alt btn-sm btn-primary" Style="float: right; margin-top: -22px;" /></h4>
        </div>
        <div id="faq187_q1" class="panel-collapse collapse" style="height: 0px;">
            <div class="panel-body">
                <asp:UpdatePanel ID="updocument" runat="server">
                    <ContentTemplate>
                        <div class="col-sm-12">
                            <table class="table table-striped table-vcenter">
                                <tbody>
                                    <asp:DataList ID="grddcoument" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" OnEditCommand="Edit_Command" OnUpdateCommand="Update_Command" OnCancelCommand="Cancel_Command">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="ltid" runat="server" Visible="false" Text='<%#Eval("Doc_ID")%>'></asp:Literal>
                                                    <a href='<%#Eval("Doc_Path")%>' data-toggle="tooltip" title="" data-original-title="download" download>
                                                        <i class='<%#"fa-3x fi fi-" + Eval("Doc_Extention").ToString.Replace(".", "")%>'></i></a>&nbsp;&nbsp;<%#Eval("Doc_Name")%>
                                                </td>
                                                <td class="text-center" style="width: 125px;">
                                                    <div class="btn-group btn-group-xs">
                                                        <asp:LinkButton ID="lnkedit" runat="server" data-toggle="tooltip" title="Edit" CommandName="Edit" class="btn btn-primary">Edit</asp:LinkButton>
                                                        <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger" runat="server" OnClientClick="checkdelete();"
                                                            CommandName="deletelink">Delete</asp:LinkButton>
                                                    </div>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <tr>
                                                <td>
                                                    <div class="col-sm-6">
                                                        <div class="col-sm-1">
                                                            <asp:Literal ID="ltid" runat="server" Visible="false" Text='<%#Eval("Doc_ID")%>'></asp:Literal>
                                                            <a href='<%#Eval("Doc_Path")%>' data-toggle="tooltip" title="" data-original-title="download" download>
                                                                <i class='<%#"fa-3x fi fi-" + Eval("Doc_Extention").ToString.Replace(".", "")%>'></i></a>
                                                        </div>
                                                        <div class="col-sm-5">
                                                            <asp:TextBox ID="txtdocname" runat="server" Text='<%#Eval("Doc_Name")%>' placeholder="Enter Document Name" data-toggle="tooltip" title="Enter Document Name"
                                                                CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="text-center" style="width: 125px;">
                                                    <div class="btn-group btn-group-xs">
                                                        <asp:LinkButton ID="lnkupdate" runat="server" data-toggle="tooltip" title="Update" CommandName="Update" class="btn btn-primary">Update</asp:LinkButton>
                                                        <asp:LinkButton ID="lnkcancel" data-toggle="tooltip" title="Cancel" class="btn btn-xs btn-warning" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                                                    </div>
                                                </td>
                                            </tr>
                                        </EditItemTemplate>
                                    </asp:DataList>
                                </tbody>
                            </table>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grddcoument" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</div>
