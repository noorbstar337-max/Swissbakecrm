<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GridviewDynamicColoumControl.ascx.vb" Inherits="UserControl_Back_GridviewDynamicColoumControl" %>
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
<asp:HiddenField ID="deletestatus" runat="server" />
<asp:HiddenField ID="hfcoloumname" runat="server" />
<asp:HiddenField ID="hfdelcoloum" runat="server" />
<asp:HiddenField ID="hfdefaultcoloum" runat="server" />
<asp:HiddenField ID="hfstatus" runat="server" />
<asp:HiddenField ID="hfdeletsi" runat="server" />
<asp:HiddenField ID="hfpagename" runat="server" />
<asp:HiddenField ID="hficon" runat="server" />
<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="content-header">
            <div class="header-section">
                <h1>
                    <i class="gi gi-table" style="margin: -8px"></i>
                    <asp:Literal ID="ltname" runat="server"></asp:Literal><br>
                </h1>
            </div>
        </div>
        <ul class="breadcrumb breadcrumb-top">
            <li><a href="_Home.aspx">Home</a></li>
            <li>
                <asp:Literal ID="ltbreadcrumbname" runat="server"></asp:Literal></li>
        </ul>

        <div class="block">
            <div class="block-title">
                <h2><strong>
                    <asp:Literal ID="lttitle" runat="server"></asp:Literal></strong> Detail</h2>
            </div>

            <%--Search User Control Start--%>
            <div class="row">
                <div class="form-group" style="margin: 0px 57px">
                    <asp:ImageButton ID="btnExportWord" Height="40px" Width="40px" ImageAlign="Right" ImageUrl="~/Admin/img/word.gif"
                        runat="server" />
                    <asp:ImageButton ID="btnExportExcel" Style="margin-right: 10px" Height="40px" Width="40px" ImageAlign="Right" runat="server" ImageUrl="~/Admin/img/excel.gif" />

                </div>
            </div>


            <div class="table-options clearfix">
                <div class="col-sm-6 col-xs-5">
                    <div class="dataTables_length" id="example-datatable_length">
                        <asp:DropDownList ID="ddpagesize" AutoPostBack="true" runat="server" CssClass="form-control">
                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                            <asp:ListItem Text="20" Value="20"></asp:ListItem>
                            <asp:ListItem Text="30" Value="30"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-sm-4 col-xs-7">
                    <div id="example-datatable_filter" class="dataTables_filter">
                        <label>
                            <div class="input-group">
                                <asp:TextBox ID="txtsearch" runat="server" class="form-control" placeholder="Search" /><span class="input-group-addon">
                                    <i class="fa fa-search"></i></span>
                            </div>
                        </label>
                    </div>
                </div>
                <div class="col-sm-2 col-xs-7">
                    <asp:Button ID="btnshowall" EnableViewState="false" runat="server" Text="Show All" CssClass="btn btn-alt btn-sm btn-info" />
                    <asp:HyperLink ID="hfadd" EnableViewState="false" runat="server" Text="ADD" CssClass="btn btn-alt btn-sm btn-primary"></asp:HyperLink>

                </div>
            </div>
             <div class="table-options clearfix">
            <div id="faq1" class="panel-group">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title"><i class="fa fa-angle-right"></i> <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq1" href="#faq1_q1">Add Coloum To Gridview</a></h4>
                                            </div>
                                            <div id="faq1_q1" class="panel-collapse collapse" style="height: 0px;">
                                                <div class="panel-body">
                                                    <asp:DataList ID="dtcoloumname" runat="server" RepeatColumns="5" RepeatLayout="Table" CssClass="table table-striped table-vcenter table-hover" RepeatDirection="Horizontal">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ckselect"  Text='<%#(Eval("Column_name"))%>' TextAlign="Right"  runat="server" />
                                                        </ItemTemplate>
                                                       <%-- <ItemTemplate>
                                                               <asp:Literal ID="ltname" runat="server"  Text='<%#(Eval("Column_name"))%>'></asp:Literal>
                                                        </ItemTemplate>--%>
                                                    </asp:DataList>
                                                    <asp:Button ID="btnsavecoloum" runat="server" Text="Save" CssClass="btn btn-alt btn-primary" />
                                                     <asp:CheckBoxList ID="ckcoloumname" Visible="false" runat="server" CellPadding="20" TextAlign="Right" CellSpacing="20" RepeatLayout="Flow" RepeatColumns="8" RepeatDirection="Horizontal"></asp:CheckBoxList>
                                                </div>
                                            </div>
                                        </div></div>
                 </div>
              
            <asp:HiddenField ID="hfsearchmode" runat="server" />
            <asp:HiddenField ID="hfgridviewmode" runat="server" />
            <asp:HiddenField ID="hftotalcount" runat="server" />
            <%--Search User Control End--%>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" DataKeyNames="ID" AllowCustomPaging="true"
                            CssClass="table table-striped table-vcenter table-hover"  AllowSorting="true" OnRowCreated="GridView1_RowCreated"
                            AllowPaging="True" PageSize="10">
                            <Columns>
                                <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Status">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnk" CssClass='<%#Security.checkStatus(Eval("Status"))%>' runat="server" Text='<%#Eval("Status")%>'
                                            CommandName="statuslink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="View" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                    <ItemTemplate>
                                        <div class="btn-group btn-group-xs">
                                            <asp:HyperLink ID="HyperLink1" EnableViewState="false" NavigateUrl='<%#Page.ResolveUrl(hfpagename.Value + "?chk=v&GId=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("ID").ToString())))%>'
                                                data-toggle="tooltip" title="View" class="btn btn-default" runat="server"><i class="fa fa-eye"></i></asp:HyperLink>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                    <ItemTemplate>
                                        <div class="btn-group btn-group-xs">

                                            <asp:HyperLink ID="HyperLink2" EnableViewState="false" NavigateUrl='<%#Page.ResolveUrl(hfpagename.Value + "?GId=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("ID").ToString())))%>'
                                                data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete"  ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                    <ItemTemplate>
                                        <div class="btn-group btn-group-xs">
                                            <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
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
