<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="Support.aspx.vb" Inherits="Support" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
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
                        <i class="fa fa-user" style="margin: -8px"></i>Complaints<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li>Complaints</li>
            </ul>

            <div class="block">
                <div class="block-title">
                    <h2><strong>Complaints</strong> Detail</h2>
                </div>
                <%--Search User Control Start--%>
                <User:SearchBarByID ID="SearchControl" runat="server" />

                <%--Search User Control End--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="hfcheck" runat="server" />
                        <asp:HiddenField ID="hfchanged" runat="server" />
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Complaint_ID" AllowCustomPaging="true"
                                CssClass="table table-striped table-vcenter " OnSorting="GridView1_Sorting" AlternatingRowStyle-CssClass="Alternate_grid"
                                AllowPaging="True" AllowSorting="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="Reference No" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Complaint_Id">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblscId" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Complaint_Id"), SearchControl.UtxtSearch)%>' />
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DEPARTMENT" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Deprt_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblDname" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Deprt_Name"), SearchControl.UtxtSearch)%>' />
                                            <asp:Literal ID="ltDname" runat="server" Visible="false" Text='<%#(Eval("Deprt_Name"))%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SUBJECT" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Complaint_Subject">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblname" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Complaint_Subject"), SearchControl.UtxtSearch)%>' />
                                            <asp:Literal ID="ltname" runat="server" Visible="false" Text='<%#(Eval("Complaint_Subject"))%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="COMPLAINT STATUS" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Complaint_CompStatus">
                                        <ItemTemplate>
                                            <asp:label ID="lblCname" runat="server" CssClass='<%#Security.checkValidsupport(Eval("Complaint_CompStatus"))%>' Text='<%#DynamicparcelGridview.HighlightText(Eval("Complaint_CompStatus"), SearchControl.UtxtSearch)%>' />
                                            <asp:label ID="ltCname" runat="server" Visible="false" Text='<%#(Eval("Complaint_CompStatus"))%>'></asp:label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                  <%--  <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="UType_Status" ItemStyle-Width="25">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk" CssClass='<%#Security.checkStatus(Eval("UType_Status"))%>' runat="server" Text='<%#Eval("UType_Status")%>'
                                                CommandName="statuslink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                    <asp:TemplateField HeaderText="Reply" ItemStyle-Width="10px" HeaderStyle-CssClass="MasterGridviewHeader1" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Edit">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLinkedit" runat="server">Reply</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# "ModifyComplaint.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Complaint_Id").ToString()))%>' data-toggle="tooltip" title="Reply" class="btn btn-default" runat="server"><i class="fa fa-reply fa-fw"></i></asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField HeaderText="Delete" ItemStyle-Width="10px" HeaderStyle-CssClass="MasterGridviewHeader1" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Delete">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLinkdelete" runat="server">Delete</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                    CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
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

