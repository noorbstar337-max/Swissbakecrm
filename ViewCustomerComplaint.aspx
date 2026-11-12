<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" CodeFile="ViewCustomerComplaint.aspx.vb" Inherits="ViewCustomerComplaint" %>

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
                        <i class="gi gi-table" style="margin: -8px"></i>Customer Complaint Detail<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="CustomerComplaint.aspx">CustomerComplaint</a></li>
                <li>Customer Complaint Detail</li>
            </ul>
            <div class="col-md-12">
                <!-- Advanced Active Theme Color Widget Alternative -->
                <div class="widget" style="min-height: 190px">
                    <div class="widget-advanced widget-advanced-alt">
                        <!-- Widget Header -->
                        <div class=" text-right themed-background-dark" style=" padding: 5px;">

                            <h4 class="widget-content-light" style="display:none;">   
                                <asp:Literal ID="ltcontactname" runat="server"></asp:Literal>                    
                                <asp:HiddenField ID="hfcontacttype" runat="server" />
                                <asp:HiddenField ID="hfcontacttypeid" runat="server" />
                                <br>
                                <small>
                                    <asp:Literal ID="ltcompanyname" runat="server"></asp:Literal>
                                    <a></a></small>
                            </h4>
                                    <a id="aedit" runat="server" class="btn btn-alt btn-sm btn-primary">Edit</a>
                                    <asp:LinkButton ID="lkdelete" runat="server" class="btn btn-alt btn-sm btn-danger" OnClientClick="checkdelete();" Visible="false">Delete</asp:LinkButton>
                                    <%--  <asp:LinkButton ID="lkconvacount" runat="server" class="btn btn-alt btn-sm btn-info">Convert To Account</asp:LinkButton>--%>
                                    <%-- <asp:LinkButton ID="lkconvOpportunity" runat="server" class="btn btn-alt btn-sm btn-warning">Convert To Opportunity</asp:LinkButton>--%>
                                
                      </div>
                        <!-- END Widget Header -->

                        <!-- Widget Main -->
                        <div class="widget-main">
                            <div class="list-group remove-margin">
                                <a href="javascript:void(0)" class="list-group-item col-md-6">
                                    <span class="pull-right"><strong>
                                        <asp:Repeater ID="rpowner" runat="server">
                                            <ItemTemplate>
                                                <%#Eval("U_FirstName")%>
                                            </ItemTemplate>
                                            <SeparatorTemplate>
                                                ,
                                            </SeparatorTemplate>
                                        </asp:Repeater>
                                    </strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-tag fa-fw"></i>&nbsp;Assign to</h5>
                                </a>
                                <a href="javascript:void(0)" class="list-group-item col-md-6">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltcomplaint" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-pencil"></i>&nbsp;Complaint No.</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                                <a href="javascript:void(0)" class="list-group-item col-md-6">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltProduct" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-briefcase"></i>&nbsp;Product</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                                <a href="javascript:void(0)" class="list-group-item col-md-6">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltaccount" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-money"></i>&nbsp;<asp:Literal ID ="ltAccPro" runat ="server"></asp:Literal></h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                                <a href="javascript:void(0)" class="list-group-item col-md-6">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltinvoice" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="gi gi-notes_2"></i>&nbsp;Invoice No.</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                                <a href="javascript:void(0)" class="list-group-item col-md-6">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltbatch" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-paperclip"></i>&nbsp;Batch/Lot No.</h5>
                                    <p class="list-group-item-text"></p>
                                </a>

                            </div>
                        </div>
                        <!-- END Widget Main -->
                    </div>
                </div>
                <!-- END Advanced Active Theme Color Widget Alternative -->
            </div>
            <div style="clear: both;"></div>
            <div class="col-md-12">
            </div>
            <div id="faq1881" class="panel-group col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <asp:Label ID="lbltitle" runat="server" Text="Title Of Complaint"></asp:Label>&nbsp;:&nbsp;<asp:Label ID="lbltitleofcomp" runat="server"></asp:Label>
                        </h4>
                    </div>
                    <div >
                        <div class="panel-body">
                            <strong>
                                <asp:Label ID="Label1" runat="server" Text="Title Of Complaint"></asp:Label></strong> &nbsp;:&nbsp;<asp:Label ID="lbltitleofcomp1" runat="server"></asp:Label>
                            <br />
                            <br />
                            <strong>
                                <asp:Label ID="Label3" runat="server" Text="Description On Title"></asp:Label></strong> &nbsp;:&nbsp;<asp:Label ID="lbldescription" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>

            <div id="faq18811" class="panel-group col-lg-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <asp:Label ID="Label2" runat="server" Text="Reason & Causes (External)"></asp:Label>
                        </h4>
                    </div>
                    <div id="faq1881123">
                        <div class="panel-body">
                            <strong>
                                <asp:Label ID="Label5" runat="server" Text="External"></asp:Label></strong> &nbsp;:&nbsp;<asp:Label ID="lblexternal" runat="server"></asp:Label>
                            <br />
                            <br />
                        </div>
                    </div>
                </div>
            </div>

            <div id="faq18812" class="panel-group col-lg-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <asp:Label ID="Label9" runat="server" Text="Reason & Causes (Internal)"></asp:Label>
                       </h4>
                    </div>
                    <div>
                        <div class="panel-body">
                            <strong>
                                <asp:Label ID="Label11" runat="server" Text="Internal"></asp:Label></strong> &nbsp;:&nbsp;<asp:Label ID="lblinternal" runat="server"></asp:Label>
                            <br />
                            <br />

                        </div>
                    </div>
                </div>
            </div>

            <div id="faq18815" class="panel-group col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <asp:Label ID="Label4" runat="server" Text="Actions & Preventive"></asp:Label>
                        </h4>
                    </div>
                    <div>
                        <div class="panel-body">
                            <strong>
                                <asp:Label ID="Label7" runat="server" Text="Actions Taken"></asp:Label></strong> &nbsp;:&nbsp;<asp:Label ID="lblaction" runat="server"></asp:Label>
                            <br />
                            <br />
                            <strong>
                                <asp:Label ID="Label10" runat="server" Text="Preventive Measure"></asp:Label></strong> &nbsp;:&nbsp;<asp:Label ID="lblprevent" runat="server"></asp:Label>
                            <br />
                            <br />
                            <strong>
                                <asp:Label ID="Label6" runat="server" Text="Client Feedback"></asp:Label></strong> &nbsp;:&nbsp;<asp:Label ID="lblfeedback" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                                  
                                     <%-- <User:DocumentControl runat="server" ID="DocumentControl" />--%>
                <User:NewDocumentControl ID="documentcontrol" runat="server" />
                                </div>

            <User:ActivityControl ID="activitycontrol" runat="server" />
        </div>
    </div>
</asp:Content>

