<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DocumentControl.ascx.vb" Inherits="UserControl_Back_DocumentControl" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:HiddenField ID="hftype" runat="server" />
<asp:HiddenField ID="hftypeid" runat="server" />

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
                <div class="form-group">
                    <label for="example-nf-email">Document Name <span class="text-danger">*</span></label>
                    <asp:TextBox ID="txtname" runat="server" placeholder="Enter Document Name" data-toggle="tooltip" title="Enter Document Name"
                        CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="remembername" runat="server" ControlToValidate="txtname" ValidationGroup="DocumentGroup" CssClass="MasterValidationCSS"
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
<div id="faq1" class="panel-group">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq1" href="#faq1_q1"> Document </a><asp:LinkButton ID="btnShow" Text="Attach Document" runat="server" class="btn btn-alt btn-sm btn-primary" Style="float: right; margin-top: -7px;" /></h4>
        </div>
        <div id="faq1_q1" class="panel-collapse collapse" style="height: 0px;">
            <div class="panel-body">
                <asp:UpdatePanel ID="updocument" runat="server">
                    <ContentTemplate>
                        <%--<asp:GridView ID="grddcoument" CssClass="table table-striped table-vcenter" Visible="false" CellPadding="0" CellSpacing="0" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Document Name" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                    <ItemTemplate>
                       <asp:Literal ID="lttemp" runat="server" Text='<%# (DataBinder.Eval(Container.DataItem, "Value"))%>' ></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                    <ItemTemplate>
                        <a href='<%# DataBinder.Eval(Container.DataItem, "Key") %>' download>Download</a>
                        <asp:Literal ID="ltid" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "Key") %>'></asp:Literal>
                    </ItemTemplate>
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
        </asp:GridView>--%>
                        <div class="col-sm-12">
                            <%--<div class="col-sm-2 col-lg-2">
                                            <div class="media-items animation-fadeInQuickInv" data-category="photo">
                                                <div class="media-items-options text-left">
                                                    <a href="javascript:void(0)" class="btn btn-xs btn-primary"><i class="fa fa-pencil"></i></a>
                                                    <a href="img/placeholders/photos/photo7.jpg" class="btn btn-xs btn-danger" data-toggle="lightbox-image"><i class="fa fa-search"></i></a>
                                                </div>
                                                <div class="media-items-content">
                                                    <i class="fi fi-jpg fa-5x text-success"></i>
                                                </div>
                                                <h4>
                                                    <strong>Food</strong>.jpg<br>
                                                    <small>5.3MB</small>
                                                </h4>
                                            </div>
                                        </div>--%>
                            <%--   <div class="col-sm-3 col-lg-3">
                 
                                <a href="javascript:void(0)" class="widget widget-hover-effect3 themed-background">
                                    <div class="widget-simple">
                                        
                                        <img src="img/placeholders/avatars/avatar12.jpg" alt="avatar" class="widget-image img-circle pull-left">
                                        <h4 class="widget-content widget-content-light">
                                        <strong>Julia Warren Julia Warren </strong>
                                         <small>Web Designer Web Designer</small>
                                        </h4>
                                    </div>
                                </a>
                            </div>--%>
                            <asp:DataList ID="grddcoument" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                <ItemTemplate>
                                    <div class="col-sm-2 col-lg-2">
                                        <%--<div class="widget widget-hover-effect3 themed-background">
                                            <div class="widget-simple">
                                                <a href="page_ready_user_profile.html">
                                                    <img src="img/placeholders/avatars/avatar16.jpg" alt="avatar" class="widget-image img-circle pull-left animation-fadeIn">
                                                </a>
                                                <h4 class="widget-content widget-content-light text-right">
                                                    <strong><%# (DataBinder.Eval(Container.DataItem, "Value"))%>
                                                        <asp:Literal ID="ltid" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "Key") %>'></asp:Literal></strong>
                                                    <span class="btn-group">
                                                        <a href='<%# DataBinder.Eval(Container.DataItem, "Key") %>' class="btn btn-xs btn-default" data-toggle="tooltip" title="" data-original-title="download" download><i class="fa fa-download"></i></a>
                                                        <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-primary" runat="server" OnClientClick="checkdelete();"
                                                            CommandName="deletelink"><i class="fa fa-times"></i></asp:LinkButton>
                                                    </span>
                                                </h4>
                                            </div>
                                        </div>--%>
                                        <a href='<%# DataBinder.Eval(Container.DataItem, "Key") %>' class="btn btn-alt btn-lg btn-default" data-toggle="tooltip" title="" data-original-title="fi fi-txt" download>
                                          <i class="fa-2x hi hi-file"></i></a><br />
                                        <%# (DataBinder.Eval(Container.DataItem, "Value"))%>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
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


