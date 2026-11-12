<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="TargetCategory.aspx.vb" Inherits="TargetCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:HiddenField ID="deletestatus" runat="server" />
    <asp:HiddenField ID="Hfgridview" runat="server" />
    <asp:HiddenField ID="hftotalrecord" runat="server" />
    <asp:HiddenField ID="hfsearch" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="content-header">
                <div class="header-section">
                    <h1>
                        <i class="fa fa-sitemap" style="margin: -8px"></i>Target Category<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="AdminMenu.aspx">Admin</a></li>
                <li>Target Category</li>
            </ul>

            <div class="block">
                <div class="block-title">
                    <h2><strong>Target Category</strong> Detail</h2>
                </div>
                <%--Search User Control Start--%>
                <User:SearchBar ID="SearchControl" runat="server" />

                <%--Search User Control End--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <%--<asp:HiddenField ID="hfcheck" runat="server" />
                        <asp:HiddenField ID="hfchanged" runat="server" />--%>
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TC_ID" AllowCustomPaging="true"
                                CssClass="table table-striped table-vcenter table-hover" OnSorting="GridView1_Sorting"
                                AllowPaging="True" PageSize="10" AllowSorting="True">
                                <Columns>

                                    <asp:TemplateField HeaderText="ID" ItemStyle-Width="30px" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="TC_ID" Visible ="false" >
                                        <ItemTemplate>
                                            <asp:Literal ID="lblTCategoryId" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("TC_ID"), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Target Category Name" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="TC_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblTCname" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("TC_Name"), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>                                   
                                    <asp:TemplateField HeaderText="View" ItemStyle-Width="100px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="HyperLink1" EnableViewState="false" NavigateUrl='<%# "ModifyTargetCategory.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("TC_ID").ToString()))%>'
                                                    data-toggle="tooltip" title="View" class="btn btn-default" runat="server"><i class="fa fa-eye"></i></asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">

                                                <asp:HyperLink ID="HyperLink2" EnableViewState="false" NavigateUrl='<%# "ModifyTargetCategory.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("TC_ID").ToString()))%>'
                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                    CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                                <%--<asp:Literal ID="ltdel" runat="server"  Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval(""))%>' Visible="false" ></asp:Literal>--%>
                                            </div>
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

