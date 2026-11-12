<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ComposeMessage.aspx.vb" ValidateRequest="false" Inherits="ComposeMessage" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function addFileUploadBox() {
            if (!document.getElementById || !document.createElement)
                return false;

            var uploadArea = document.getElementById("upload-area");

            if (!uploadArea)
                return;

            var newLine = document.createElement("br");
            uploadArea.appendChild(newLine);

            var newUploadBox = document.createElement("input");

            // Set up the new input for file uploads  
            newUploadBox.type = "file";
            newUploadBox.size = "60";

            // The new box needs a name and an ID  
            if (!addFileUploadBox.lastAssignedId)
                addFileUploadBox.lastAssignedId = 100;

            newUploadBox.setAttribute("id", "dynamic" + addFileUploadBox.lastAssignedId);
            newUploadBox.setAttribute("name", "dynamic:" + addFileUploadBox.lastAssignedId);
            uploadArea.appendChild(newUploadBox);
            addFileUploadBox.lastAssignedId++;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header">
        <div class="header-section">
            <h1><i class="gi gi-pencil"></i>Compose Message<br>
                <small>Your Message Center</small></h1>
        </div>
    </div>
    <ul class="breadcrumb breadcrumb-top">
        <%--<li>Pages</li>--%>
        <li><a href="index.aspx">Home</a></li>
        <li><a href="Email.aspx">Message Center</a></li>
        <li>Compose Message</li>
    </ul>
    <!-- END Inbox Header -->
    <!-- Inbox Content -->
    <div class="row">
        <asp:UpdatePanel ID="uppopup" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:LinkButton ID="btnShow" runat="server"></asp:LinkButton>
                <asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="btnShow"
                    CancelControlID="btnNo" BackgroundCssClass="pop">
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlPopup" runat="server" Style="display: none" DefaultButton="btnsave">
                    <div class="modal-dialog modal-sm">
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                                <h3 class="modal-title">Contact List</h3>
                            </div>
                            <div class="modal-body">
                                <asp:GridView ID="GridView1" runat="server" GridLines="None" CssClass="table table-striped table-vcenter" CellPadding="0" CellSpacing="0" HeaderStyle-Width="100" HeaderStyle-Font-Size="Smaller" HeaderStyle-Font-Bold="true" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Contact Name" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                            <HeaderTemplate>
                                                <asp:HyperLink ID="HyperLink11" runat="server">Contact Name</asp:HyperLink>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="ltname" runat="server" Text='<%#Eval("Contact Name")%>' CommandName="SelectContact" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                            <HeaderTemplate>
                                                <asp:HyperLink ID="HyperLink1" runat="server">Email</asp:HyperLink>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Literal ID="ltemail" runat="server" Text='<%#Eval("Email")%>'></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="left" BackColor="White" />
                                    <FooterStyle HorizontalAlign="left" BackColor="White" />
                                    <PagerSettings PageButtonCount="4" />
                                    <EmptyDataTemplate>
                                        <asp:Label ID="s" runat="server" Text="No Record Found"></asp:Label><br />
                                        <br />
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle HorizontalAlign="Center" />
                                </asp:GridView>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnsave" OnClientClick="check();" runat="server" class="btn btn-sm btn-primary" Text="Close" ValidationGroup="TaskMasterGroup"></asp:Button>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnselectcontact" />
                <asp:AsyncPostBackTrigger ControlID="GridView1" />
            </Triggers>
        </asp:UpdatePanel>

        <div class="col-sm-12 col-lg-12" id="divedit" runat="server">
            <!-- Compose Message Block -->
            <div class="block">
                <!-- Compose Message Title -->
                <div class="block-title">
                    <div class="block-options pull-right">
                        <a href="javascript:void(0)" id="cc-input-btn" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="Show Cc field"><i class="fa fa-plus"></i>Cc</a>
                        <a href="javascript:void(0)" id="bcc-input-btn" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="Show Bcc field"><i class="fa fa-plus"></i>Bcc</a>
                    </div>
                    <h2>Compose <strong>Message</strong></h2>
                </div>
                <!-- END Compose Message Title -->
                <!-- Compose Message Content -->
                <div class="form-horizontal form-bordered">
                    <asp:HiddenField ID ="hfpath" runat="server" />
                    <%--<div class="form-group">
                        <label class="col-md-3 col-lg-2 control-label" for="compose-to">Assign To</label>
                        <div class="col-md-3 col-lg-4">
                            <asp:DropDownList ID="ddowner" runat="server" data-toggle="tooltip" title="Task Owner" name="example-chosen" class="select-chosen">
                                <asp:ListItem>Shahid</asp:ListItem>
                                <asp:ListItem>Admin</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>--%>
                    <div class="form-group">
                        <label class="col-md-3 col-lg-2 control-label" for="compose-to">Type</label>
                        <div class="col-md-3 col-lg-4">
                            <asp:DropDownList ID="ddrelatedtype" runat="server" AutoPostBack="true" data-toggle="tooltip" title="Related Type" CssClass="form-control">
                                <asp:ListItem Value="None">None</asp:ListItem>
                                <asp:ListItem Value="Lead">Lead</asp:ListItem>
                                <asp:ListItem Value="Prospect">Prospect</asp:ListItem>
                                <asp:ListItem Value="Account">Account</asp:ListItem>
                                <asp:ListItem Value="Opportunity">Opportunity</asp:ListItem>
                                <asp:ListItem Value="Quotation">Quotation</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3 col-lg-4">
                            <asp:DropDownList ID="ddrelatedtypeid" runat="server" name="example-chosen" class="select-chosen" data-toggle="tooltip" title="Related Type ID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-lg-2 control-label" for="compose-to">To</label>
                        <asp:UpdatePanel ID="upto" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="col-md-3 col-lg-4">
                                    <asp:TextBox ID="txtto" class="form-control" placeholder="Where to?" runat="server" />
                                    <asp:RequiredFieldValidator ID="remembername" runat="server" ControlToValidate="txtto" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="Please enter emailid" SetFocusOnError="true"></asp:RequiredFieldValidator>

                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="GridView1" />
                            </Triggers>
                        </asp:UpdatePanel>

                        <div class="col-md-2 col-lg-3">
                            <asp:Button ID="btnselectcontact" CssClass="btn btn-alt btn-xs btn-primary" runat="server" Text="Select Contact" />
                        </div>
                    </div>
                    <div id="cc-input" class="form-group display-none">
                        <label class="col-md-3 col-lg-2 control-label" for="compose-to-cc">Cc</label>
                        <div class="col-md-9 col-lg-10">
                            <input type="email" id="compose-to-cc" name="compose-to-cc" class="form-control form-control-borderless" placeholder="Enter Cc emails..">
                        </div>
                    </div>
                    <div id="bcc-input" class="form-group display-none">
                        <label class="col-md-3 col-lg-2 control-label" for="compose-to-bcc">Bcc</label>
                        <div class="col-md-9 col-lg-10">
                            <input type="email" id="compose-to-bcc" name="compose-to-bcc" class="form-control form-control-borderless" placeholder="Enter Bcc emails..">
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-lg-2 control-label" for="compose-subject">Subject</label>
                        <div class="col-md-3 col-lg-4">
                            <asp:TextBox ID="txtsubject" runat="server" class="form-control" placeholder="Your subject.." />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtsubject" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                ErrorMessage="Please enter subject" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-lg-2 control-label" for="compose-message">Message</label>
                        <div class="col-md-9 col-lg-10">
                            <textarea id="txtmessge" runat="server" name="compose-message" rows="10" class="form-control textarea-editor" placeholder="Your message.."></textarea>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtmessge" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                ErrorMessage="Please enter messgae" SetFocusOnError="true"></asp:RequiredFieldValidator>
                           
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-lg-2 control-label" for="compose-message">Attachment</label>
                        <div class="col-md-9 col-lg-10">
                            <input id="AddFile" type="button" value="Add file" onclick="addFileUploadBox()" class="btn btn-sm btn-primary" style="background-color: #000000;
  float: left;
  margin-right: 10px;
  padding: 2px 10px;
  margin-top: 5px;" />
                            <asp:HyperLink ID="hyppdf" runat="server" download></asp:HyperLink>
                             <div id="upload-area">
                                <input id="File1" type="file" runat="server" size="60" />
                            </div>
                              <span id="Span1" runat="server"></span>
                            </div>
                        </div>
                    
                    <div class="form-group form-actions">
                        <div class="col-md-9 col-md-offset-3 col-lg-10 col-lg-offset-2">
                            <asp:LinkButton ID="btnsend" runat="server" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                UseSubmitBehavior="false" class="btn btn-sm btn-primary"><i class="fa fa-paper-plane-o"></i> Send</asp:LinkButton>
                            <asp:LinkButton  ID="hfcancel" CausesValidation="false"  Text="Cancel" runat="server"  class="btn btn-sm btn-primary" TabIndex ="9"/>
                            <%--<button type="button" class="btn btn-sm btn-default"><i class="fa fa-pencil"></i>Save Draft</button>--%>
                        </div>
                    </div>
                </div>
                <!-- END Compose Message Content -->
            </div>
            <!-- END Compose Message Block -->
        </div>

        <div class="col-sm-12 col-lg-12" id="divview" runat="server">
            <!-- View Message Block -->
            <div class="block full">
                <!-- View Message Title -->
                <div class="block-title">
                    <div class="block-options pull-right">
                        <%-- <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="" data-original-title="Print"><i class="fa fa-print"></i></a>
                                            <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="" data-original-title="Delete"><i class="fa fa-times"></i></a>--%>
                    </div>
                    <h2><strong>
                        <asp:Literal ID="ltsubject" runat="server"></asp:Literal></strong></h2>
                </div>
                <!-- END View Message Title -->

                <!-- Message Meta -->
                <table class="table table-borderless table-vcenter remove-margin">
                    <tbody>
                        <tr>
                            <td class="hidden-xs">From : <a>
                                <asp:Literal ID="ltemailfrom" runat="server"></asp:Literal></a> <a></a>
                            </td>
                        </tr>
                        <tr>
                            <td class="hidden-xs">To : <a>
                                <asp:Literal ID="ltemailto" runat="server"></asp:Literal></a> <a></a>
                            </td>
                            <td class="text-right"><strong>
                                <asp:Literal ID="ltdate" runat="server"></asp:Literal></strong></td>
                        </tr>
                    </tbody>
                </table>
                <hr>
                <asp:Literal ID="ltmessgae" runat="server"></asp:Literal>
<hr>            <a><asp:Label ID="lblattahment" runat="server" Text="Attachment"></asp:Label></a><br /><br />
                <asp:DataList ID="dtattachent" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <ItemTemplate>
                        <a href='<%#Eval("Doc_Path")%>' data-toggle="tooltip" title="" data-original-title="download" download>
                            <i class='<%#"fa-5x fi fi-" + Eval("Doc_Extention").ToString.Replace(".", "")%>'></i></a>
                    </ItemTemplate>
                    
                </asp:DataList>
                <br /><br />

                <asp:LinkButton ID="btnback" runat="server" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                    UseSubmitBehavior="false" class="btn btn-sm btn-primary"><i class="fa fa-arrow-left"></i> Back</asp:LinkButton>
                
                <%--<button type="button" class="btn btn-sm btn-default"><i class="fa fa-pencil"></i>Save Draft</button>--%>
            </div>
            <!-- END View Message Block -->
        </div>
        <!-- END Compose Message -->
    </div>
</asp:Content>


