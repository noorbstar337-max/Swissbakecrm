<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="AccountOwnerlist.aspx.vb" Inherits="Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                        <i class="gi gi-parents" style="margin: -8px"></i>Account Owner List<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li>Account Owner List</li>
            </ul>
            <div class="block">
                <div class="block-title">
                    <h2><strong>Account Owner List</strong> Detail</h2>
                </div>
                <%--Search User Control Start--%>
                <User:SearchBarByID ID="SearchControl" runat="server" />
                <%--Search User Control End--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="hfcheck" runat="server" />
                        <asp:HiddenField ID="hfchanged" runat="server" />
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Acc_Id" AllowCustomPaging="true"
                                CssClass="table table-striped table-vcenter" OnSorting="GridView1_Sorting" GridLines="None"
                                AllowPaging="True" AllowSorting="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink4" runat="server">Edit</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="HyperLink2" EnableViewState="false" NavigateUrl='<%# "AccountOwner.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Acc_Id").ToString()))%>'
                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="" Visible="false" ItemStyle-CssClass="" SortExpression="Acc_Id">
                                        <ItemTemplate>
                                            <asp:Literal ID="lbluId" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Acc_Id"), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Company Name" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Acc_Name">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" EnableViewState="false" NavigateUrl='<%# "AccountOwner.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Acc_Id").ToString()))%>'
                                                data-toggle="tooltip" title="View" runat="server">
                                            <asp:Literal ID="lblcontact" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_Name")), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                        </asp:HyperLink></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Owner" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="U_FirstName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblassignto" runat="server"  Text='<%#DynamicparcelGridview.HighlightText(Eval("U_FirstName"), SearchControl.UtxtSearch)%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="left" BackColor="White" />
                                <FooterStyle HorizontalAlign="left" BackColor="White" />
                                <PagerSettings PageButtonCount="4" />
                                <EmptyDataTemplate>
                                    <asp:Label ID="s" runat="server" Text="No Record Found"></asp:Label><br /><br /></EmptyDataTemplate><EmptyDataRowStyle HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" />
                        <%--<asp:PostBackTrigger ControlID="btnsave" />--%>
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

