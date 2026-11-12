<%@ Control Language="VB" AutoEventWireup="false" CodeFile="OpportunityContactControl.ascx.vb" Inherits="UserControl_Back_OpportunityContactControl" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<script type="text/javascript">
    function CheckOtherIsCheckedByGVID(spanChk) {

        var IsChecked = spanChk.checked;
        if (IsChecked) {
            //spanChk.parentElement.parentElement.style.backgroundColor = '#EF998A';
            //spanChk.parentElement.parentElement.style.color = 'rgb(19, 18, 18)';
            //spanChk.parentElement.parentElement.style.border = '1px solid';

        }
        var CurrentRdbID = spanChk.id;
        var Chk = spanChk;
        Parent = document.getElementById("<%=GridView1.ClientID%>");
        var items = Parent.getElementsByTagName('input');
        for (i = 0; i < items.length; i++) {
            if (items[i].id != CurrentRdbID && items[i].type == "radio") {
                if (items[i].checked) {
                    items[i].checked = false;
                    items[i].parentElement.parentElement.style.backgroundColor = 'white'

                    items[i].parentElement.parentElement.style.color = 'black';
                }
            }
        }
    }
</script>

<script type="text/javascript">
    function AtLeastOneContact_ClientValidate(sender, args) {
        var txt1 = document.getElementById("<%= txtemail.ClientID%>");
        var txt2 = document.getElementById("<%= txtmob.ClientID%>");
        var txt3 = document.getElementById("<%= txtofficeno.ClientID%>");
        args.IsValid = (txt1.value != "") || (txt2.value != "") || (txt3.value != "");
    }
</script>
<asp:HiddenField ID="hftype" runat="server" />
<asp:HiddenField ID="hftypeid" runat="server" />
<asp:HiddenField ID="hfopptype" runat="server" />
<asp:HiddenField ID="hfopptypeid" runat="server" />
<div id="faq12" class="panel-group">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq12" href="#faq12_q12">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblcontact" runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                    </Triggers>
                </asp:UpdatePanel>
            </a></h4>
        </div>
        <div id="faq12_q12" class="panel-collapse collapse" style="height: 0px;">
            <div class="panel-body">
                <asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlcontactPopup" TargetControlID="btnShow"
                    CancelControlID="btnNo">
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlcontactPopup" runat="server" Style="display: none" DefaultButton="btnsave">
                    <div class="modal-dialog modal-sm">
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                                <h3 class="modal-title">Add Task</h3>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <span class="text-danger">
                                        <label for="example-nf-email">Contact Person </label>
                                    </span>
                                    <asp:TextBox ID="txtname" runat="server" placeholder="Enter Name" data-toggle="tooltip" title="Enter Name"
                                        CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="refirstname" runat="server" ControlToValidate="txtname" ValidationGroup="ContactGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="Please enter name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label for="example-nf-email">Email </label>
                                    <asp:TextBox ID="txtemail" runat="server" placeholder="Enter Email Id" data-toggle="tooltip" title="Enter Email Id"
                                        CssClass="form-control"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="rgemailship" runat="server" ValidationGroup="ContactGroup" ErrorMessage="Please enter valid email id"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>

                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="At leat one contact required" ValidationGroup="ContactGroup" CssClass="MasterValidationCSS" Display="Dynamic" OnServerValidate="AtLeastOneContact_ServerValidate"
                                        ClientValidationFunction="AtLeastOneContact_ClientValidate"></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                    <label for="example-nf-email">Mobile </label>
                                    <asp:TextBox ID="txtmob" runat="server" placeholder="Enter Mobile Number" data-toggle="tooltip" title="Enter Mobile Number"
                                        CssClass="form-control"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="rgmobship" runat="server" ErrorMessage="Please enter valid mobile number" ControlToValidate="txtmob"
                                        ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <label for="example-nf-email">Phone </label>
                                    <asp:TextBox ID="txtofficeno" runat="server" placeholder="Enter Office Number" data-toggle="tooltip" title="Enter Office Number"
                                        CssClass="form-control"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="rgofficeno" runat="server" ErrorMessage="invalid number" ControlToValidate="txtofficeno"
                                        ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" Display="Dynamic" Enabled="false"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="reoffice" runat="server" ControlToValidate="txtofficeno" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="invalid number" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>

                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-primary" Text="Save" ValidationGroup="ContactGroup"></asp:Button>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:ModalPopupExtender ID="mpeselectcontact" runat="server" PopupControlID="pnlselectcontactPopup" TargetControlID="btnshowcontact"
                    CancelControlID="LinkButton1">
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlselectcontactPopup" runat="server" Style="display: none" DefaultButton="btnsave">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:LinkButton ID="LinkButton1" class="close" runat="server">&times;</asp:LinkButton>
                                <h3 class="modal-title">Add Contact</h3>
                            </div>
                            <div class="modal-body">
                                <asp:UpdatePanel ID="upselectcontact" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView2" runat="server" ShowFooter="true" AutoGenerateColumns="true" CellPadding="0" CellSpacing="0" DataKeyNames="Id" AllowSorting="true" HeaderStyle-Font-Size="Smaller"
                                                CssClass="table table-borderless table-striped" PageSize="5" GridLines="Horizontal" BorderWidth="0px" Width="100%" Font-Size="Small" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true"
                                                AllowPaging="True">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Select" FooterStyle-CssClass="MasterGridviewItem" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Deprt_Status" ItemStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ckselect" runat="server" />
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
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnselectcontact" />
                                        <asp:AsyncPostBackTrigger ControlID="GridView1" />
                                    </Triggers>
                                </asp:UpdatePanel>

                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnselectcontact" runat="server" class="btn btn-sm btn-primary" Text="Save" ValidationGroup="SelectContactGroup"></asp:Button>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <div class="">
                    <asp:LinkButton ID="btnShow" runat="server" CssClass="btn btn-alt btn-xs btn-primary">New Contact</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton ID="btnshowcontact" runat="server" CssClass="btn btn-alt btn-xs btn-primary">Select Contact</asp:LinkButton><br />
                    <br />
                </div>
                <asp:UpdatePanel ID="updocument" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="table-responsive">

                            <asp:GridView ID="GridView1" runat="server" ShowFooter="true" AutoGenerateColumns="true" CellPadding="0" CellSpacing="0" DataKeyNames="Id" AllowSorting="true" HeaderStyle-Font-Size="Smaller"
                                CssClass="table table-borderless table-striped" PageSize="5" GridLines="Horizontal" BorderWidth="0px" Width="100%" Font-Size="Small" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true"
                                AllowPaging="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="Remove" ItemStyle-Width="50px">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink222" runat="server">Remove</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk" Text="Remove" runat="server"
                                                CommandName="Closing" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Primary" FooterStyle-CssClass="MasterGridviewItem" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Deprt_Status" ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:RadioButton ID="rbowner" runat="server" Checked='<%#Eval("OpporCont_Primary").ToString().Equals("True")%>' onclick="javascript:CheckOtherIsCheckedByGVID(this);" AutoPostBack="true" OnCheckedChanged="rbowner_CheckedChanged" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="10px">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink2" runat="server">Edit</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="HyperLink1" EnableViewState="false" NavigateUrl='<%# Page.ResolveUrl("Contact.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("ContactId").ToString())))%>'
                                                    data-toggle="tooltip" title="Edit" class="btn btn-Primary" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                            </div>
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
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                        <asp:AsyncPostBackTrigger ControlID="btnselectcontact" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</div>
