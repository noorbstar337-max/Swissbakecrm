<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="Campaign.aspx.vb" Inherits="Campaign" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function checkdelete() {
            if (confirm('Are you Sure want to Delete?')) {
                document.getElementById('<%=deletestatus.ClientID %>').value = "yes";
                return true
            }
            else {
                document.getElementById('<%=deletestatus.ClientID %>').value = "no";
                return true
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="deletestatus" runat="server" />
    <asp:HiddenField ID="Hfgridview" runat="server" />
    <asp:HiddenField ID="hftotalrecord" runat="server" />
    <asp:HiddenField ID="hfsearch" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="content-header">
                <div class="header-section">
                    <h1>
                        <i class="gi gi-shop" style="margin: -8px"></i>Campaign<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="AdminMenu.aspx">Admin</a></li>
                <li>Campaign</li>
            </ul>

            <div class="block">
                <div class="block-title">
                    <h2><strong>Campaign</strong> Detail</h2>
                </div>
                <%--Search User Control Start--%>
                <User:SearchBar ID="SearchControl" runat="server" />

                <%--Search User Control End--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="hfcheck" runat="server" />
                        <asp:HiddenField ID="hfchanged" runat="server" />
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Campaign_Id" AllowCustomPaging="true"
                                CssClass="table table-striped table-vcenter" OnSorting="GridView1_Sorting" AlternatingRowStyle-CssClass="Alternate_grid"
                                AllowPaging="True" AllowSorting="True">
                                <Columns>

                                    <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Campaign_Id" Visible ="false" >
                                        <ItemTemplate>
                                            <asp:Literal ID="lblscId" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Campaign_Id"), SearchControl.UtxtSearch)%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Campaign Title" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Campaign_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lbltitle" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Campaign_Name"), SearchControl.UtxtSearch)%>' />
                                            <asp:Literal ID="lttitle" runat="server" Visible="false" Text='<%#(Eval("Campaign_Name"))%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Campaign Type" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="CampaignType_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblname" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("CampaignType_Name"), SearchControl.UtxtSearch)%>' />
                                            <asp:Literal ID="ltname" runat="server" Visible="false" Text='<%#(Eval("CampaignType_Name"))%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Start Date" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Campaign_StartDate">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblsdate" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Campaign_StartDate"), SearchControl.UtxtSearch)%>' />
                                            <asp:Literal ID="ltsdate" runat="server" Visible="false" Text='<%#(Eval("Campaign_StartDate"))%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="End Date" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Campaign_EndDate">
                                        <ItemTemplate>
                                            <asp:Literal ID="lbledate" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Campaign_EndDate"), SearchControl.UtxtSearch)%>' />
                                            <asp:Literal ID="ltedate" runat="server" Visible="false" Text='<%#(Eval("Campaign_EndDate"))%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Campaign_Status" ItemStyle-Width="25">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk" CssClass='<%#Security.checkStatus(Eval("Campaign_Status"))%>' runat="server" Text='<%#Eval("Campaign_Status")%>'
                                                CommandName="statuslink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-CssClass="MasterGridviewHeader1" ItemStyle-CssClass="MasterGridviewItem">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink4" runat="server">View</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="HyperLink1" EnableViewState="false" NavigateUrl='<%# "ModifyCampaign.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Campaign_Id").ToString()))%>'
                                                    data-toggle="tooltip" title="View" class="btn btn-default" runat="server"><i class="fa fa-eye"></i></asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-CssClass="MasterGridviewHeader1" ItemStyle-CssClass="MasterGridviewItem">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink2" runat="server">Edit</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="HyperLink2" EnableViewState="false" NavigateUrl='<%# "ModifyCampaign.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Campaign_Id").ToString()))%>'
                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                            </div>
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
                        <asp:LinkButton ID="btnShow" runat="server" />
                        <asp:ModalPopupExtender ID="mpe" runat="server" BehaviorID="mpe" PopupControlID="pnlPopup" TargetControlID="btnShow"
                            CancelControlID="btnNo">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="pnlPopup" runat="server" Style="display: none">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                                        <h3 class="modal-title">
                                            <asp:Label ID="Label1" runat="server" Text="Add New Campaign"></asp:Label></h3>
                                    </div>
                                    <div class="modal-body">
                                        <div class="form-group">
                                            <label for="example-nf-email">Campaign Name <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtdepartname" runat="server" placeholder="Enter Campaign Name" data-toggle="tooltip" title="Enter Service Name" TabIndex="1"
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="remembername" runat="server" ControlToValidate="txtdepartname" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter a Campaign name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblname" CssClass="MasterValidationCSS" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <%--   <asp:Button ID="btnNo" runat="server" Text="Close" class="btn btn-sm btn-default"></asp:Button>--%>
                                        <asp:Button ID="btnsave" runat="server" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                            UseSubmitBehavior="false" class="btn btn-sm btn-primary" ValidationGroup="MasterGroup" Text="Save changes" TabIndex="2"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <br />
            <div class="divWaiting">
                <i class="fa fa-sun-o fa-spin" id="LoadingUpadatePanel"></i>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

