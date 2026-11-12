<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" CodeFile="ViewOpportunity.aspx.vb" Inherits="ViewOpportunity" %>

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
    <div class="row">
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <i class="gi gi-table" style="margin: -8px"></i>Opportunity Detail<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="MainOpportunity.aspx">Opportunity</a></li>
                <li>Opportunity Detail</li>
            </ul>
            <div class="col-md-8">
                <!-- Advanced Active Theme Color Widget Alternative -->
                <div class="widget" style="min-height: 331px">
                    <div class="widget-advanced widget-advanced-alt">
                        <!-- Widget Header -->
                        <div class="widget-header text-center themed-background-dark">
                            <h4 class="widget-content-light">
                                <a>
                                    <asp:Literal ID="ltcontactname" runat="server"></asp:Literal> - </a> <asp:Literal ID="ltamount" runat="server"></asp:Literal><asp:HiddenField ID="hfcontacttype" runat="server" />
                                <asp:HiddenField ID="hfcontacttypeid" runat="server" />
                                <br>
                                <small>
                                    <asp:Literal ID="ltcompanyname" runat="server"></asp:Literal> - <a><asp:Literal ID="ltaccname" runat="server"></asp:Literal></a></small>
                            </h4>
                            <div class="col-md-12">
                                <div class="block-section">
                                    <a id="aedit" runat="server" class="btn btn-alt btn-sm btn-primary">Edit</a>
                                    <asp:LinkButton ID="lkdelete" runat="server" class="btn btn-alt btn-sm btn-danger" OnClientClick="checkdelete();" Visible="false">Delete</asp:LinkButton>
                                  <%--  <asp:LinkButton ID="lkconvacount" runat="server" class="btn btn-alt btn-sm btn-info">Convert To Account</asp:LinkButton>--%>
                                    <%-- <asp:LinkButton ID="lkconvOpportunity" runat="server" class="btn btn-alt btn-sm btn-warning">Convert To Opportunity</asp:LinkButton>--%>
                                </div>

                            </div>
                        </div>
                        <!-- END Widget Header -->

                        <!-- Widget Main -->
                        <div class="widget-main">
                            <div class="list-group remove-margin">
                                <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                         <asp:Repeater ID="rpowner" runat="server">
                                            <ItemTemplate>
                                               <%#Eval("U_FirstName")%>
                                            </ItemTemplate>
                                            <SeparatorTemplate>
                                              ,
                                            </SeparatorTemplate>
                                        </asp:Repeater></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-tag fa-fw"></i>&nbsp;Opportunity Assign to</h5>
                                </a>
                                <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltStage" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-mobile fa-fw"></i>&nbsp;Stage</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                                <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltprobability" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-phone fa-fw"></i>&nbsp;Probability</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                                <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltrevenue" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-calendar fa-fw"></i>&nbsp;Expected Revenue</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                                 <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltdate" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-calendar fa-fw"></i>&nbsp;Closing Date</h5>
                                    <p class="list-group-item-text"></p>
                                </a>

                            </div>
                        </div>
                        <!-- END Widget Main -->
                    </div>
                </div>
                <!-- END Advanced Active Theme Color Widget Alternative -->
            </div>
            <asp:UpdatePanel ID="upquickaction" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="col-sm-6 col-md-4">
                        <!-- Widget -->

                        <div class="widget">
                            <div class="widget-simple">
                                <a class="widget-icon pull-left animation-fadeIn themed-background">
                                    <i class="hi hi-tasks"></i>
                                </a>
                                <h4 class="widget-content text-right animation-hatch">
                                    <a href="javascript:void(0)"><strong>
                                        <asp:Literal ID="ltcounttask" runat="server"></asp:Literal></strong> Task</a>
                                    <small>
                                        <asp:LinkButton ID="lkquicktask" CssClass="btn btn-alt btn-xs btn-primary" runat="server">Add New Task</asp:LinkButton></small>
                                </h4>
                            </div>
                        </div>

                        <!-- END Widget -->
                    </div>
                    <div class="col-sm-6 col-md-4">
                        <!-- Widget -->
                        <div class="widget">
                            <div class="widget-simple">
                                <a class="widget-icon pull-left animation-fadeIn themed-background-default">
                                    <i class="hi hi-bullhorn"></i>
                                </a>
                                <h4 class="widget-content text-right animation-hatch">
                                    <a href="javascript:void(0)" style="color: #3498db;"><strong>
                                        <asp:Literal ID="ltcountevent" runat="server"></asp:Literal></strong> Sampling/Demo</a>
                                    <small>
                                        <asp:LinkButton ID="lkquickevent" CssClass="btn btn-alt btn-xs btn-info" runat="server">Add New Sampling/Demo</asp:LinkButton></small>
                                </h4>
                            </div>
                        </div>
                        <!-- END Widget -->
                    </div>
                    <div class="col-sm-6 col-md-4">
                        <!-- Widget -->
                        <div class="widget">
                            <div class="widget-simple">
                                <a href="javascript:void(0)" class="widget-icon pull-left animation-fadeIn themed-background-fire">
                                    <i class="hi hi-phone_alt"></i>
                                </a>
                                <h4 class="widget-content text-right animation-hatch">
                                    <a href="javascript:void(0)" style="color: #e74c3c"><strong>
                                        <asp:Literal ID="ltcountcall" runat="server"></asp:Literal></strong> Phone/Email</a>
                                    <small>
                                        <asp:LinkButton ID="lkquickcall" CssClass="btn btn-alt btn-xs btn-danger" runat="server">Add New Phone/Email</asp:LinkButton></small>
                                </h4>
                            </div>
                        </div>
                        <!-- END Widget -->
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="col-md-12">
 <%--  <User:ContactControl ID="contactcontrol" runat="server" />--%>
                <User:OpportunityContactControl ID="opcontactcontrol" runat="server" />
                <User:StageHistoryControl ID="staeghistorycontrol" runat="server" />
               <User:CompetitorControl ID="Competitorcontrol" runat="server" />
                 <User:EmailControl ID="emailcontrol" runat="server" />
                <User:ItemDetailControl ID="itemdtcontrol" runat="server" />
                <div id="faq6" class="panel-group">
                    <User:NoteControl ID="notecontrol" runat="server" />
                </div>
                <div id="faq1" class="panel-group">
                    <User:NewDocumentControl ID="documentcontrol" runat="server" />
                </div>
            </div>
            <User:ActivityControl ID="activitycontrol" runat="server" />
        </div>
    </div>
</asp:Content>

