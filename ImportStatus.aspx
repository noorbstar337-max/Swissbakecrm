<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ImportStatus.aspx.vb" Inherits="ImportStatus" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="deletestatus" runat="server" />
    <asp:HiddenField ID="Hfgridview" runat="server" />
    <asp:HiddenField ID="hftotalrecord" runat="server" />
    <asp:HiddenField ID="hfsearch" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="content-header">
                <div class="header-section">
                    <h1>
                        <i class="fa fa-building" style="margin: -8px"></i>Import Status<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="AdminMenu.aspx">Admin</a></li>
                <li>Import Status</li>
            </ul>

            <div class="block">
                <div class="block-title">
                    <h2><strong>Import Status</strong> Detail</h2>
                </div>
                <%--Search User Control Start--%>
                <User:SearchBar ID="SearchControl" runat="server" />
                <%--Search User Control End--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="hfcheck" runat="server" />
                        <asp:HiddenField ID="hfchanged" runat="server" />
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ImportStatus_Id" AllowCustomPaging="true"
                                CssClass="table table-striped table-vcenter" OnSorting="GridView1_Sorting" AlternatingRowStyle-CssClass="Alternate_grid"
                                AllowPaging="True" AllowSorting="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="ImportStatus_Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblscId" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("ImportStatus_Id"), SearchControl.UtxtSearch)%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Type" ItemStyle-Width="100" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="ImportStatus_Type">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblname" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("ImportStatus_Type"), SearchControl.UtxtSearch)%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Account Name" ItemStyle-Width="150" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Acc_name" >
                                        <ItemTemplate>
                                            <asp:Literal ID="lnk" runat="server" Text='<%#Eval("Acc_name")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Messgae" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="ImportStatus_Message" ItemStyle-Width="25">
                                        <ItemTemplate>
                                            <asp:Literal ID="ltmessage" runat="server" Text='<%#Eval("ImportStatus_Message")%>' />
                                             <asp:Literal ID="ltpassword" runat="server" Visible="false" Text='<%#Eval("Cust_Password")%>' />
                                             <asp:Literal ID="ltemail" runat="server" Visible="false" Text='<%#Eval("Cust_EmailId")%>' />
                                             <asp:Literal ID="ltaccid" runat="server" Visible="false" Text='<%#Eval("Acc_Id")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Import Date" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="ImportStatus_CreatedDate" ItemStyle-Width="25">
                                        <ItemTemplate>
                                            <asp:Literal ID="ltimportdate" runat="server" Text='<%#Eval(("ImportStatus_CreatedDate"))%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="ImportStatus_Status" ItemStyle-Width="25">
                                        <ItemTemplate>
                                            <asp:Label ID="ltstatatata" CssClass='<%#Security.checkImportStatus(Eval("ImportStatus_Status"))%>' runat="server" Text='<%#Eval("ImportStatus_Status")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-CssClass="MasterGridviewHeader1" ItemStyle-CssClass="MasterGridviewItem">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink2gfhgfg" runat="server">Edit</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="HyperLink2" EnableViewState="false" NavigateUrl='<%# "ModifyAccount.aspx?is=c&chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Acc_Id").ToString()))%>'
                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-CssClass="MasterGridviewHeader1" ItemStyle-CssClass="MasterGridviewItem">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink1hfgh" runat="server">Resend Mail</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Resend Mail" class="btn btn-danger" runat="server" 
                                                    CommandName="resendemail" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>">Resend Mail</asp:LinkButton>
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

