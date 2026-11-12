<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="Addressbook.aspx.vb" Inherits="Addressbook" %>

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
                        <i class="hi hi-tasks" style="margin: -8px"></i>Contact<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="AdminMenu.aspx">Admin</a></li>
                <li>Contact</li>

            </ul>
            <div class="block">
                <div class="block-title">
                    <h2><strong>Contact</strong> Detail</h2>
                </div>
                <div class="row">
                    <div class="">
                        <div class="col-md-1">
                            <asp:DropDownList ID="ddpagesize" AutoPostBack="true" runat="server" CssClass="form-control">
                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                <asp:ListItem Text="40" Value="40"></asp:ListItem>
                                <asp:ListItem Text="50" Value="50"></asp:ListItem>
                            </asp:DropDownList>
                            <br />
                        </div>
                        <div class="col-md-3">
                            <div class="">
                                <asp:DropDownList ID="ddtasktype" AutoPostBack="true" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="All Contact">All Contact</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <br />
                        </div>

                        <div class="col-sm-4 col-xs-12">
                            <div id="example-datatable_filter" class="dataTables_filter">
                                <label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtsearch" runat="server" class="form-control" placeholder="Search" /><span class="input-group-addon">
                                            <i class="fa fa-search"></i></span>
                                    </div>
                                </label>
                            </div>
                            <br />
                        </div>
                        <div class="col-md-1">
                        </div>
                        <div class="col-md-4">

                            <asp:Button ID="btnshowall" runat="server" Text="Show All" CssClass="btn btn-alt btn-sm btn-primary" />&nbsp;&nbsp
                                       <asp:LinkButton ID="btnadd" runat="server" class="btn btn-alt btn-sm btn-primary">ADD</asp:LinkButton>&nbsp;&nbsp
                             <asp:ImageButton ID="btnExportWord" Width="33px" ImageAlign="Right" data-toggle="tooltip" title="Export Word" ImageUrl="~/images/word.gif"
            runat="server" />
        <asp:ImageButton ID="btnExportExcel" data-toggle="tooltip" title="Export Excel" Style="margin-right: 10px" Width="33px" ImageAlign="Right" runat="server" ImageUrl="~/images/excel.gif" />
          
                        </div>
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="hfalpha" runat="server" />
                        <asp:HiddenField ID="hfIsalpha" runat="server" />
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" DataKeyNames="Id" AllowCustomPaging="true"
                                CssClass="table table-striped table-vcenter" ShowFooter="true" AlternatingRowStyle-CssClass="Alternate_grid"
                                AllowPaging="True" AllowSorting="True">
                                <Columns>
                                    <%--<asp:TemplateField HeaderText="Delete" SortExpression="Deprt_Status" ItemStyle-Width="10px" Visible="false" >
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk" Text="Delete" runat="server"
                                                CommandName="Closing" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField ItemStyle-Width="10px">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="fghfgh" runat="server">Edit</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="gjghj" NavigateUrl='<%# Page.ResolveUrl("Contact.aspx?returnurl="+ HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) +"&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Id").ToString())))%>'
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
                        <asp:AsyncPostBackTrigger ControlID="GridView1" />
                        <asp:AsyncPostBackTrigger ControlID="txtsearch" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </ContentTemplate>
        <Triggers>
            <%--<asp:AsyncPostBackTrigger ControlID="btncloseyes" />--%>
        </Triggers>
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

