<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" CodeFile="ViewAccount.aspx.vb" Inherits="ViewAccount" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/jquery.min.js"></script>
    <script type="text/javascript">
        function checkdelete() {
            if (confirm('Sure, you want to Delete?')) {
                document.getElementById('<%=deletestatus.ClientID %>').value = "yes";
                return true
            }
            else {
                document.getElementById('<%=deletestatus.ClientID %>').value = "no";
                return true
            }
        }
    </script>
    <script type="text/javascript">
        function lkviewInvclick(pagename, invid, id, custid) {
            ; debugger
            var a = "";
            // var id= "321";
            // var c = +Prodname;
            $.ajax({
                type: "POST",
                url: "ItemcontrolService.asmx/TripleEncrypt",
                data: '{invid: ' + invid + ',id: ' + id + ', custid: ' + custid + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    a = response.d;

                },
                async: false
            });






            a = a.split(",");
            //if (pagename == "PrintDocs.aspx?tpy=SO&type=" || pagename == "PrintDocs.aspx?tpy=InvExp&type=") {
            if (pagename == "PrintDocs.aspx?tpy=SO&type=" || pagename == "PrintDocs.aspx?tpy=InvExp&type=" || pagename == "PrintDocs.aspx?tpy=InvDom&type=") {

                if (location.hostname === "localhost") {
                    //pagename = "http://localhost:56361/" + pagename + "pJyQIVSSnfWdSCc47JLzHg%3d%3d" + "&Id=" + a[1] + "&Gyt32XyHTtsuc=" + a[2]
                    pagename = "http://localhost:56361/" + pagename+ "pJyQIVSSnfWdSCc47JLzHg%3d%3d"+"&Id="+a[1]+"&Gyt32XyHTtsuc="+a[2]+"&InvId="+a[0]

                }
                else {
                    //pagename = "http://b2b.swissbake.ch/" + pagename + "pJyQIVSSnfWdSCc47JLzHg%3d%3d" + "&Id=" + a[1] + "&Gyt32XyHTtsuc=" + a[2]
                    pagename = "http://b2b.swissbake.in/Admin/" + pagename+ "pJyQIVSSnfWdSCc47JLzHg%3d%3d"+"&Id="+a[1]+"&Gyt32XyHTtsuc="+a[2]+"&InvId="+a[0]

                }

            }
            else {


                if (location.hostname === "localhost") {
                    pagename = "http://localhost:56361/" + pagename + a[0]

                }
                else {
                    pagename = "http://b2b.swissbake.in/Admin/" + pagename + a[0]

                }
            }
            //   window.location.href="../"+pagename;

            var win = window.open(pagename, '_blank');
            win.focus();

        }
    </script>
    <script type="text/javascript">
        function lkviewclick(pagename, id, custid) {
            ; debugger
            var a = "";
            // var id= "321";
            // var c = +Prodname;
            $.ajax({
                type: "POST",
                url: "ItemcontrolService.asmx/MultiEncrypt",
                data: '{id: ' + id + ', custid: ' + custid + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    a = response.d;

                },
                async: false
            });


            a = a.split(",");
            //if (pagename == "PrintDocs.aspx?tpy=SO&type=") {
            if (pagename == "PrintDocs.aspx?tpy=SO&type=" || pagename == "PrintDocs.aspx?tpy=SODom&type=") {
                if (location.hostname === "localhost") {
                    pagename = "http://localhost:56361/" + pagename + "pJyQIVSSnfWdSCc47JLzHg%3d%3d" + "&Id=" + a[0] + "&Gyt32XyHTtsuc=" + a[1]

                }
                else {
                    pagename = "http://b2b.swissbake.in/Admin/" + pagename + "pJyQIVSSnfWdSCc47JLzHg%3d%3d" + "&Id=" + a[0] + "&Gyt32XyHTtsuc=" + a[1]

                }
                //pagename = "../" + pagename + "pJyQIVSSnfWdSCc47JLzHg%3d%3d" + "&Id=" + a[0] + "&Gyt32XyHTtsuc=" + a[1]
            }
            else {
                if (location.hostname === "localhost") {
                    pagename = "http://localhost:56361/" + pagename + a[0]

                }
                else {
                    pagename = "http://b2b.swissbake.in/Admin/" + pagename + a[0]

                }
                //pagename = "../" + pagename + a[0]
            }
            //  window.location.href="../"+pagename;

            var win = window.open(pagename, '_blank');
            win.focus();

        }
        //function lkEditclick(id) {

        //    var a = "";
        //    $.ajax({
        //        type: "POST",
        //        url: "ItemcontrolService.asmx/Encrypt",
        //        data: '{id: ' + id + '}',
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        success: function (response) {
        //            a = response.d;
        //        },
        //        async: false
        //    });
        //    window.location.href = "_ModifyOrder.aspx?chk=v&OrderId=" + a;
        //}
    </script>
    <%--<script>
        $(document).ready(function(){
            var text = <%=tabss%>;
            if (text == "0"){
            }
            else{
                $('a:contains("' + text + '")').parent().addClass('active disabled');
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                prm.add_pageLoaded(panelLoaded);
            
                function panelLoaded(sender, args){
                  
                    var text = <%=tabss%>;
                    var value = $("#<%=tab.ClientID%>").val();
                
                    // re-bind your jQuery events here
                    $('a:contains("' + value + '")').parent().addClass('active disabled');

                }
            }

        });
    </script>
    <script>
      
        jQuery(function ($) {
            var focusedElementId = "";
            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_beginRequest(function (source, args) {
               
                var fe = document.activeElement;
                if (fe != null) {
                    focusedElementId = fe.id;
                } else {
                    focusedElementId = "";
                }
            });

            prm.add_endRequest(function (source, args) {
                debugger;
                if (focusedElementId != "") {
                  
                    $("#" + focusedElementId).focus();
                    var tmpStr =$("#" + focusedElementId).val();
                    $("#" + focusedElementId).val('');
                    $("#" + focusedElementId).val(tmpStr);
                    document.getElementById('<%=hfBackcount.ClientID %>').value = "1";
                    
                }
            });
        });
    </script>--%>
    <style>
        /*faisal code*/
        .ratingStar .ratingItem {
            float: left;
            font-size: 0;
            margin-left: 2px;
            margin-right: 2px;
            padding: 0;
            width: 16px;
            height: 18px;
            display: block;
            background-repeat: no-repeat;
            cursor: pointer;
        }

        .ratingStar .Filled {
            background-image: url('../images/rating/star.png');
        }

        .ratingStar .Empty {
            background-image: url(../images/rating/EmptyStar.png);
        }

        .ratingStar .Saved {
            background-image: url('../imagesrating/star.png');
        }



        .ratingStar1 .ratingItem1 {
            float: left;
            font-size: 0pt;
            margin-left: 2px;
            margin-right: 2px;
            margin-top: 3px;
            padding: 0px;
            /*width: 16px;
    height: 18px;*/
            width: 11.7px;
            height: 14px;
            display: block;
            background-repeat: no-repeat;
            cursor: pointer;
        }

        .ratingStar1 .Filled1 {
            background-image: url('../images/rating/star3.png');
        }

        .ratingStar1 .Empty1 {
            background-image: url(../images/rating/EmptyStar3.png);
        }

        .ratingStar1 .Saved1 {
            background-image: url('../images/rating/star3.png');
        }


        /*faisal code ends*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="deletestatus" runat="server" />
    <div class="row">
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <i class="gi gi-table" style="margin: -8px"></i>Account Detail<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="Account.aspx">Account</a></li>
                <li>Account Detail</li>
            </ul>
            <div class="col-md-12">
                <!-- Advanced Active Theme Color Widget Alternative -->
                <div class="widget" style="min-height: 352px">
                    <div class="widget-advanced widget-advanced-alt">
                        <!-- Widget Header -->
                        <div class="widget-header text-center themed-background-dark" style="min-height: 90px;">
                            <h4 class="widget-content-light">
                                <a>
                                    <asp:Literal ID="ltcontactname" runat="server"></asp:Literal></a><br>
                                <small>
                                    <asp:Literal ID="ltcompanyname" runat="server"></asp:Literal></small>
                            </h4>
                            <div class="col-md-12 remove-padding">
                                <%--<div class="block-section">--%>
                                <a id="aedit" runat="server" class="btn btn-alt btn-sm btn-primary">Edit</a>
                                <a id="aprint" title="Print Price List" class="btn btn-alt btn-sm btn-default" runat="server" target="_blank"><i class="fa fa-file"></i>Price List</a>
                                <asp:LinkButton ID="lkdelete" runat="server" class="btn btn-alt btn-sm btn-danger" OnClientClick="checkdelete();" Visible="false">Delete</asp:LinkButton>
                                <%-- <asp:LinkButton ID="lkconvacount" runat="server" class="btn btn-alt btn-sm btn-info">Convert To Account</asp:LinkButton>--%>
                                <%-- <asp:LinkButton ID="lkconvprospect" runat="server" class="btn btn-alt btn-sm btn-warning">Convert To Prospect</asp:LinkButton>--%>
                                <%--</div>--%>
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
                                        </asp:Repeater>
                                    </strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-tag fa-fw"></i>&nbsp;Account assign to</h5>
                                </a>
                                <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltmobile" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-mobile fa-fw"></i>&nbsp;Mobile</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                                <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltphone" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-phone fa-fw"></i>&nbsp;Phone</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                                <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="ltleaddate" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-envelope-o fa-fw"></i>&nbsp;EmailID</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
								<a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="Lblbank" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-bank fa-fw"></i>&nbsp;Bank </h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                                <a href="javascript:void(0)" class="list-group-item">
                                    <span class="pull-right"><strong>
                                        <asp:Literal ID="lbladdress" runat="server"></asp:Literal></strong></span>
                                    <h5 class="list-group-item-heading remove-margin"><i class="fa fa-home fa-fw"></i>&nbsp;Address</h5>
                                    <p class="list-group-item-text"></p>
                                </a>
                                <div>
                                    <a href="javascript:void(0)" class="list-group-item col-md-3">
                                        <span class="pull-right"><strong>
                                            <asp:Literal ID="lblcst" runat="server"></asp:Literal></strong></span>
                                        <h5 class="list-group-item-heading remove-margin">&nbsp;CST</h5>
                                        <p class="list-group-item-text"></p>
                                    </a>
                                    <a href="javascript:void(0)" class="list-group-item col-md-3">
                                        <span class="pull-right"><strong>
                                            <asp:Literal ID="lblpan" runat="server"></asp:Literal></strong></span>
                                        <h5 class="list-group-item-heading remove-margin">&nbsp;PAN</h5>
                                        <p class="list-group-item-text"></p>
                                    </a>
                                    <a href="javascript:void(0)" class="list-group-item col-md-3">
                                        <span class="pull-right"><strong>
                                            <asp:Literal ID="lblvat" runat="server"></asp:Literal></strong></span>
                                        <h5 class="list-group-item-heading remove-margin">&nbsp;VAT</h5>
                                        <p class="list-group-item-text"></p>
                                    </a>
                                    <a href="javascript:void(0)" class="list-group-item col-md-3">
                                        <span class="pull-right"><strong>
                                            <asp:Literal ID="lblgst" runat="server"></asp:Literal></strong></span>
                                        <h5 class="list-group-item-heading remove-margin">&nbsp;GST</h5>
                                        <p class="list-group-item-text"></p>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <!-- END Widget Main -->
                    </div>
                </div>
                <!-- END Advanced Active Theme Color Widget Alternative -->
            </div>
            <asp:UpdatePanel ID="upquickaction" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="col-sm-6 col-md-4" style="display: none;">
                        <!-- Widget -->

                        <div class="widget" style="display: none;">
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
                    <div class="col-sm-6 col-md-4" style="display: none;">
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
                    <div class="col-sm-6 col-md-4" style="display: none;">
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
                <div class="row">
                    <div class="col-sm-6 col-lg-3">
                        <!-- Widget -->
                        <a class="widget widget-hover-effect1">
                            <div class="widget-simple">
                                <div class="widget-icon pull-left themed-background-fire animation-fadeIn">
                                    <i class="fa fa-cubes"></i>
                                </div>
                                <h3 class="widget-content text-right animation-pullDown"><i class="fa fa-rupee"></i>&nbsp;<strong><asp:Literal ID="lblorderamount" runat="server"></asp:Literal>
                                </strong>
                                    <br>
                                    <small>Total
                                        <asp:Literal ID="lblordercount" runat="server"></asp:Literal>
                                        order</small>
                                </h3>
                            </div>
                        </a>
                        <!-- END Widget -->
                    </div>
                    <div class="col-sm-6 col-lg-3">
                        <!-- Widget -->
                        <a class="widget widget-hover-effect1">
                            <div class="widget-simple">
                                <div class="widget-icon pull-left themed-background-autumn animation-fadeIn">
                                    <i class="fa fa-file-o"></i>
                                </div>
                                <h3 class="widget-content text-right animation-pullDown"><i class="fa fa-rupee"></i>&nbsp;<strong>
                                    <asp:Literal ID="lblinvtotal" runat="server"></asp:Literal>
                                </strong>
                                    <br>
                                    <small>Total
                                        <asp:Literal ID="lblinvoicecount" runat="server"></asp:Literal>
                                        invoice generated</small>
                                </h3>
                            </div>
                        </a>
                        <!-- END Widget -->
                    </div>
                    <div class="col-sm-6 col-lg-3">
                        <!-- Widget -->
                        <a class="widget widget-hover-effect1">
                            <div class="widget-simple">
                                <div class="widget-icon pull-left themed-background-spring animation-fadeIn">
                                    <i class="fa fa-rupee"></i>
                                </div>
                                <h4 class="widget-content text-right animation-pullDown"><i class="fa fa-rupee"></i>&nbsp;<strong>
                                    <asp:Literal ID="lblpaytotal" runat="server"></asp:Literal>
                                </strong>
                                    <small>Total
                                        <asp:Literal ID="lblpaycount" runat="server"></asp:Literal>
                                        payment </small>
                                </h4>
                            </div>
                        </a>
                        <!-- END Widget -->
                    </div>
                    <div class="col-sm-6 col-lg-3">
                        <!-- Widget -->
                        <a class="widget widget-hover-effect1">
                            <div class="widget-simple">
                                <div class="widget-icon pull-left themed-background-amethyst animation-fadeIn">
                                    <i class="gi gi-money"></i>
                                </div>
                                <h3 class="widget-content text-right animation-pullDown"><i class="fa fa-rupee"></i>&nbsp;
                            <strong>
                                <asp:Literal ID="lblbalpay" runat="server"></asp:Literal>
                            </strong>
                                    <small>Total balance</small>
                                </h3>
                            </div>
                        </a>
                        <!-- END Widget -->
                    </div>
                </div>
                <User:ContactControl ID="contactcontrol" runat="server" />

                <asp:HiddenField ID="hftype" runat="server" />
                <asp:HiddenField ID="hftypeid" runat="server" />

                <div id="faq13" class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq13" href="#faq13_q12">
                                <asp:UpdatePanel ID="UpdatePanel14" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="lblsamplereq" Text="Sample Request" runat="server"></asp:Label>
                                    </ContentTemplate>

                                </asp:UpdatePanel>
                            </a></h4>
                        </div>
                        <div id="faq13_q12" class="panel-collapse collapse" style="height: 0px;">
                            <div class="panel-body">

                                <asp:UpdatePanel ID="UpdatePanel15" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="table-responsive">
                                            <asp:GridView ID="grdsamplereq" runat="server" ShowFooter="true" AutoGenerateColumns="false" CellPadding="0" CellSpacing="0" DataKeyNames="SampleRequest_Id" AllowSorting="true" HeaderStyle-Font-Size="Smaller"
                                                CssClass="table table-borderless table-striped" PageSize="5" GridLines="Horizontal" BorderWidth="0px" Width="100%" Font-Size="Small" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true"
                                                AllowPaging="True">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SampleRequest No">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hlSamReqNo" EnableViewState="false" NavigateUrl='<%# "ModifySampleRequest.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("SampleRequest_Id").ToString()))%>'
                                                                data-toggle="tooltip" title="View" runat="server">
                                                                <asp:Literal ID="lblSamReqNo" runat="server" Text='<%#Eval("SampleRequestNo")%>' EnableViewState="false" />
                                                            </asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:BoundField HeaderText="SampleRequest No" DataField="SampleRequestNo" />--%>
                                                    <asp:BoundField HeaderText="Request Date" DataField="Request_Date" />
                                                    <asp:BoundField HeaderText="Company Name" DataField="CompanyName" />
                                                    <asp:BoundField HeaderText="Contact Name" DataField="ContactName" />

                                                    <asp:BoundField HeaderText="Qty(kg)" DataField="Qty" />
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblunit" runat="server" CssClass='<%#Security.checkSRStatus(Eval("SampleStatus"))%>' Text='<%#Eval("SampleStatus")%>' Style="padding: 1px 10px; border-radius: 5px;" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:BoundField HeaderText="Request Status" DataField="SampleStatus" />--%>
                                                    <%--<asp:BoundField HeaderText="Track Order" DataField="hreftracking" />--%>
                                                    <asp:BoundField HeaderText="AWB" DataField="SampleRequest_AWB" />
                                                    <asp:TemplateField HeaderText="Track Order">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink1" runat="server" Visible='<%# If(Eval("SampleRequest_AWB") = "", False, True)%>' NavigateUrl='<%#Eval("hreftracking").ToString()%>' Target="_blank">
                                                                <img src="images/track.png" style="width: 22px; margin-top: 4px;">
                                                            </asp:HyperLink>
                                                            <asp:Label ID="lbldirect" runat="server" Text='<%#Eval("hreftracking").ToString()%>' Font-Bold="true" Visible="false" ForeColor="#c42126"></asp:Label>
                                                            <asp:Label ID="lbldash" runat="server" Text="-" Font-Bold="true" Visible='<%# If(Eval("SampleRequest_AWB") = "", True, False)%>' ForeColor="#c42126"></asp:Label><br />
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

                                </asp:UpdatePanel>

                            </div>
                        </div>
                    </div>
                </div>




                <div id="faq8561" class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a id="aToggle" runat="server" class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq8561" href="#ContentPlaceHolder1_faq8561_q12">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="lblSample" Text="Interested Product" runat="server"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </a></h4>
                        </div>
                        <div id="faq8561_q12" runat="server" class="panel-collapse collapse" style="height: 0px;">
                            <div class="panel-body">
                                <asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="btnShow"
                                    CancelControlID="btnNo">
                                </asp:ModalPopupExtender>
                                <asp:Panel ID="pnlPopup" runat="server" Style="display: none">
                                    <div class="modal-dialog modal-lg" style="overflow-y: scroll; position: fixed; top: 0; bottom: 0; left: 0; right: 0; overflow: auto; width: 1192px;">
                                        <div class="modal-content" style="top: 1%; overflow-x: hidden; overflow-y: auto; outline: none; margin-top: 0; overflow: visible;">
                                            <div class="modal-header">
                                                <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                                                <h3 class="modal-title">Add Product</h3>
                                            </div>
                                            <div class="modal-body" style="overflow: auto; height: 400px;">
                                                <div class="table-options clearfix">
                                                    <div class="col-sm-5 col-xs-4">
                                                        <div class="dataTables_length" id="example-datatable_length">
                                                        </div>
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
                                                    </div>
                                                    <div class="col-sm-3 col-xs-12">
                                                        <asp:Button ID="btnshowall" runat="server" Text="Show All" CssClass="btn btn-alt btn-sm btn-info" />
                                                    </div>
                                                </div>
                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataKeyNames="Product_Id"
                                                                CssClass="table table-striped table-vcenter table-hover" Font-Size="12px">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Select" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Product_Id">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="ckselect" runat="server" />
                                                                            <asp:Label ID="lblproductId" runat="server" Text='<%#Eval("Product_Id")%>' Visible="false" />

                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Code" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Product_Code">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblcode" runat="server" Text='<%#Eval("Product_Code")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Product Name" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Product_Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("Product_Name")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>



                                                                    <asp:TemplateField HeaderText="Category" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="PrdCategory_Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("PrdCategory_Name")%>' />
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
                                                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                                                        <asp:AsyncPostBackTrigger ControlID="btnopen" />
                                                        <%--   <asp:AsyncPostBackTrigger ControlID="btnQuickOpen" />--%>
                                                        <asp:AsyncPostBackTrigger ControlID="btnshowall" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="modal-footer">
                                                        <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-primary" ValidationGroup="ProductItemGroup" Text="Save & Close"></asp:Button>

                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnopen" />
                                                    <%-- <asp:AsyncPostBackTrigger ControlID="btnQuickOpen" />--%>
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <div class="">
                                    <asp:LinkButton ID="btnopen" Text="Add Item" ValidationGroup="MasterGrouppop" runat="server" class="btn btn-alt btn-xs btn-primary" TabIndex="11" />

                                </div>
                                <asp:LinkButton ID="btnShow" runat="server" Text=""></asp:LinkButton>
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Always">
                                    <ContentTemplate>
                                        <asp:HiddenField ID="hftotalvat" runat="server" />
                                        <asp:HiddenField ID="hfgrandtotal" runat="server" />
                                        <div class="table-responsive">
                                            <asp:GridView ID="grditemproduct" ShowFooter="true" GridLines="None" CssClass="table table-striped table-vcenter" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Smaller" CellPadding="0" CellSpacing="0" runat="server" AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Product Name" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink11" runat="server">Product Name</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="ltproductname" runat="server" Text='<%#Eval("Product_Name")%>'></asp:Label>
                                                            <asp:Label ID="ltitemid" runat="server" Text='<%#Eval("ItemDt_ID")%>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Product Code" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink12" runat="server">Product Code</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="ltproductcode" runat="server" Text='<%#Eval("Product_Code")%>'></asp:Label>
                                                            <asp:Label ID="ltproductid" runat="server" Text='<%#Eval("ProductId")%>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField ItemStyle-Width="" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger" runat="server" OnClientClick="checkdelete();"
                                                                    CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>">Delete</asp:LinkButton>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="left" BackColor="White" />
                                                <FooterStyle HorizontalAlign="left" BackColor="White" />
                                                <PagerSettings PageButtonCount="4" />
                                                <EmptyDataTemplate>
                                                    <asp:Label ID="s" runat="server" Text="No Item Found"></asp:Label><br />
                                                    <br />
                                                </EmptyDataTemplate>
                                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </div>

                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="GridView1" />
                                        <asp:AsyncPostBackTrigger ControlID="btnsave" />

                                        <asp:AsyncPostBackTrigger ControlID="grditemproduct" />
                                    </Triggers>
                                </asp:UpdatePanel>

                                <br />
                                <asp:Label ID="lblOtherPI" runat="server" CssClass="col-md-2" Style="width: 13%;" Text="Other Interested Products:"></asp:Label>
                                <asp:TextBox ID="txtOtherPI" runat="server" CssClass="col-md-3" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                <div style="clear: both;"></div>
                                <br />

                                <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                    UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" />
                            </div>
                        </div>
                    </div>
                </div>




                <User:OportunityControl ID="oportunitycontrol" runat="server" Visible="false" />

                <!--ORDER-->
                <div id="divorder55" class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#divorder55" href="#manOrder">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="lblorder" Text="Order" runat="server"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </a></h4>
                        </div>
                        <div id="manOrder" class="panel-collapse collapse" style="height: 0px;">
                            <div class="panel-body">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                                    <ContentTemplate>
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="Order_Id" AllowCustomPaging="true"
                                                CssClass="table table-striped table-vcenter table-hover" AllowPaging="True" PageSize="10000">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="" ItemStyle-Width="10px" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                                        <HeaderTemplate>
                                                            <asp:HyperLink ID="HyperLink4" runat="server">Edit</asp:HyperLink>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:HyperLink ID="lkedit" NavigateUrl='<%# "EditSalesOrder.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Order_Id").ToString()))%>'
                                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server" onclick="window.open (this.href, 'popupwindow',  'width=900,height=500,scrollbars,resizable,top=100,left=200'); return false;"><i class="fa fa-pencil"></i></asp:HyperLink>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Order Code" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Order_Id">
                                                        <ItemTemplate>
                                                            <a id="lkview" data-toggle="tooltip" title="View" class="btn btn-alt"
                                                                onclick='lkviewclick("<%#(Eval("href").ToString()).Replace("PrintSalesOrdergst.aspx?Id=", "PrintDocs.aspx?tpy=SODom&type=")%>",<%#Eval("Order_ID").ToString()%>,<%#Eval("Order_CustId").ToString()%>)'>
                                                                <%--<a id="lkview" data-toggle="tooltip" title="View" class="btn btn-alt" onclick='lkviewclick("<%#Eval("href").ToString()%>",<%#Eval("Order_ID").ToString()%>,<%#Eval("Order_CustId").ToString()%>)'>--%>
                                                                <asp:Label ID="lblname" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Order_Code"), txtSearch)%>' />
                                                                <asp:Literal ID="lblInvoiceId" runat="server" Text='<%#Eval("Order_Id")%>' Visible="false" />
                                                                <%-- <asp:HyperLink ID="hpviwe4" NavigateUrl='<%# "http://b2b.swissbake.ch/" + Eval("href") + HttpUtility.UrlEncode(Security.Encrypt(Eval("Order_Id").ToString()))%>'
                                                                data-toggle="tooltip" title="View" runat="server" Target="_blank">
                                                                <asp:Literal ID="lblOrderCode" runat="server" Text='<%#Eval("Order_Code")%>'  />
                                                            </asp:HyperLink>--%>
                                                                <%--  NavigateUrl='<%# "EditSalesOrder.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Order_Id").ToString()))%>'  
                                                                onclick="window.open (this.href, 'popupwindow',  'width=900,height=500,scrollbars,resizable,top=100,left=200'); return false;" --%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Order Date" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Order_CreatedDate">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblorderdate" runat="server" Text='<%#Eval("Order_CreatedDate")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Order_Amount">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblamount" runat="server" Text='<%#Eval("Order_Amount")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Order Status" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Order_OrderStatus">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblorderstatus" runat="server" Text='<%#Eval("Order_OrderStatus")%>' />
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
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
                <!--ORDER-->

                <!--Invoice-->
                <div id="divinv26" class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#divinv26" href="#faqInvoice">
                                <asp:UpdatePanel ID="UpdatePanelinv" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="lblinvoice" Text="Invoice" runat="server"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </a></h4>
                        </div>
                        <div id="faqInvoice" class="panel-collapse collapse" style="height: 0px;">
                            <div class="panel-body">
                                <asp:UpdatePanel ID="upInvoice" runat="server" UpdateMode="Always">
                                    <ContentTemplate>
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Invoice_ID" AllowCustomPaging="true"
                                                CssClass="table table-striped table-vcenter table-hover" AllowPaging="True" PageSize="10">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Invoice Number" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Invoice_ID">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblInvoiceId" runat="server" Text='<%#Eval("Invoice_ID")%>' Visible="false" />
                                                            <%--<a id="hplPrintInvoice" data-toggle="tooltip" title="View" style="cursor: pointer;" onclick='lkviewInvclick("<%#Eval("hrefinvoice").ToString()%>",<%#Eval("Invoice_ID").ToString()%>,<%#Eval("Order_ID").ToString()%>,<%#Eval("Acc_Id").ToString()%>)'>--%>
                                                            <a id="hplPrintInvoice" data-toggle="tooltip" title="View" style="cursor: pointer;" onclick='lkviewInvclick("<%#(Eval("hrefinvoice").ToString()).Replace("printinvoiceGST.aspx?Id=", "PrintDocs.aspx?tpy=InvDom&type=")%>",<%#Eval("Invoice_ID").ToString()%>,<%#Eval("Order_ID").ToString()%>,<%#Eval("Acc_Id").ToString()%>)'> 
                                                                <asp:Literal ID="lblinvno" runat="server" Text='<%#Eval("Invoice_Number")%>' />

                                                                <%--<asp:HyperLink ID="HyperLink3"  NavigateUrl='<%# "http://b2b.swissbake.ch/" + Eval("hrefinvoice") + HttpUtility.UrlEncode(Security.Encrypt(Eval("Invoice_ID").ToString()))%>'
                                                                data-toggle="tooltip" title="View Invoice" runat="server" Target="_blank">
                                                                <asp:Literal ID="lblinvno" runat="server" Text='<%#Eval("Invoice_Number")%>'  />
                                                            </asp:HyperLink>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Order Code" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Order_Code">
                                                        <ItemTemplate>
                                                            <%--<a id="lkview" data-toggle="tooltip" title="View" class="btn btn-alt" onclick='lkviewclick("<%#Eval("hrefordre").ToString()%>",<%#Eval("Order_ID").ToString()%>,<%#Eval("Acc_Id").ToString()%>)'>--%>
                                                            <a id="lkview" data-toggle="tooltip" title="View" class="btn btn-alt" onclick='lkviewclick("<%#(Eval("hrefordre").ToString()).Replace("PrintSalesOrdergst.aspx?Id=", "PrintDocs.aspx?tpy=SODom&type=")%>",<%#Eval("Order_ID").ToString()%>,<%#Eval("Acc_Id").ToString()%>)'>
                                                                <asp:Label ID="lblname" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Order_Code"), txtSearch)%>' />
                                                                <%-- <asp:HyperLink ID="hpviwe4"  NavigateUrl='<%# "http://b2b.swissbake.ch/" + Eval("hrefordre") + HttpUtility.UrlEncode(Security.Encrypt(Eval("Order_Id").ToString()))%>'
                                                                data-toggle="tooltip" title="View Print" runat="server" Target="_blank">
                                                                <asp:Literal ID="lblOrderCode" runat="server" Text='<%#Eval("Order_Code")%>'  />
                                                            </asp:HyperLink>--%>
                                                                <%--<asp:HyperLink ID="hpviwe4"  NavigateUrl='<%# "EditSalesOrder.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Order_Id").ToString()))%>'
                                                                data-toggle="tooltip" title="View" runat="server" onclick="window.open (this.href, 'popupwindow',  'width=900,height=500,scrollbars,resizable,top=100,left=200'); return false;">--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Invoice Date" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Invoice_Date">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lbldate" runat="server" Text='<%#Eval("Invoice_Date")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Invoice_Amount">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblamount" runat="server" Text='<%#Eval("Invoice_Amount")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Invoice Status" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Invoice_Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblunit" runat="server" CssClass='<%#Security.UniversalStatus(Eval("Invoice_Status"))%>' Text='<%#Eval("Invoice_Status")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="AWB" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Invoice_AWB">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAWB" runat="server" Text='<%#Eval("Invoice_AWB")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Track Order">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink1" runat="server" Visible='<%# If(Eval("Invoice_AWB") = "", False, True)%>' NavigateUrl='<%#Eval("hreftracking").ToString()%>' Target="_blank">
                                                                <img src="images/track.png" style="width: 22px; margin-top: 4px;">
                                                            </asp:HyperLink>
                                                            <asp:Label ID="lbldirect" runat="server" Text='<%#Eval("hreftracking").ToString()%>' Font-Bold="true" Visible="false" ForeColor="#c42126"></asp:Label>
                                                            <asp:Label ID="lbldash" runat="server" Text="-" Font-Bold="true" Visible='<%# If(Eval("Invoice_AWB") = "", True, False)%>' ForeColor="#c42126"></asp:Label><br />
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
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
                <!--Invoice-->
                <!--Payment-->
                <div id="divpayment92" class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#divpayment92" href="#faqPayment">
                                <asp:UpdatePanel ID="UpdatePanelPay" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="lblpayment" Text="Payment" runat="server"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </a></h4>
                        </div>
                        <div id="faqPayment" class="panel-collapse collapse" style="height: 0px;">
                            <div class="panel-body">
                                <asp:UpdatePanel ID="UpdatePanelpayment" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Payment_ID" AllowCustomPaging="true"
                                                CssClass="table table-striped table-vcenter table-hover" AllowPaging="True" PageSize="10">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Payment_ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblPaymentId" runat="server" Text='<%#Eval("Payment_ID")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Payment_Date">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lbldate" runat="server" Text='<%#Eval("Payment_Date")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Payment_Amount">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblamount" runat="server" Text='<%#Eval("Payment_Amount")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Mode Of Payment" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Payment_Mode">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblmode" runat="server" Text='<%#Eval("Payment_Mode")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Other info" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="otherinfo">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblinfo" runat="server" Text='<%#Eval("otherinfo")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Payment_Status">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk" CssClass='<%#Security.checkStatus(Eval("Payment_Status"))%>' runat="server" Text='<%#Eval("Payment_Status")%>'
                                                CommandName="statuslink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="View" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="HyperLink1"  NavigateUrl='<%# "_ModifyPayment.aspx?chk=v&PaymentId=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Payment_ID").ToString()))%>'
                                                    data-toggle="tooltip" title="View" class="btn btn-default" runat="server"><i class="fa fa-eye"></i></asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">

                                                <asp:HyperLink ID="HyperLink2"  NavigateUrl='<%# "_ModifyPayment.aspx?PaymentId=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Payment_ID").ToString()))%>'
                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                    CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
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
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>

                <!--Payment-->
                <!--Complaint-->
                <div id="divComplaint92" class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#divComplaint92" href="#faqComplaint">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="lblSolution" Text="Complaint" runat="server"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </a>
                                <asp:LinkButton ID="lnkAddComplaint" Text="Add Complaint" runat="server" ValidationGroup="DemogruopNote" class="btn btn-alt btn-sm btn-primary" Style="float: right; width: 122px; margin-top: -22px;" />
                            </h4>
                        </div>
                        <div id="faqComplaint" class="panel-collapse collapse" style="height: 0px;">
                            <div class="panel-body">
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="table-responsive">
                                            <asp:GridView ID="gvComplaint" runat="server" AutoGenerateColumns="False" DataKeyNames="CustComplaint_ID" AllowCustomPaging="true"
                                                CssClass="table table-striped table-vcenter table-hover" AllowPaging="True" PageSize="10">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="CustComplaint_ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblProductId" runat="server" Text='<%#(Eval("CustComplaint_ID"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Complaint no." ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="CustComplaint_No">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblcode" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("CustComplaint_No"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Invoice No." ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="CustComplaint_InvoiceNo">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblname" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("CustComplaint_InvoiceNo"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Product" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Product_Name">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblCategory" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Product_Name"))%>' />
                                                            <asp:Literal ID="Literal1" runat="server" Text='<%#(Eval("Product_ID"))%>' Visible="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Title" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="CustComplaint_Title">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lbltitle" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("CustComplaint_Title"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Product" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="CustComplaint_Title" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblCategory" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("CustComplaint_Title"))%>' />

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Account" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Acc_Name">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblRate" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_Name"))%>' />
                                                            <asp:Literal ID="Literal1" runat="server" Text='<%#(Eval("Acc_ID"))%>' Visible="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="CustComplaint_Status" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnk" CssClass='<%#Security.checkStatus(Eval("CustComplaint_Status"))%>' runat="server" Text='<%#Eval("CustComplaint_Status")%>'
                                                                CommandName="statuslink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="View" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                                        <ItemTemplate>
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "ViewCustomerComplaint.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("CustComplaint_ID").ToString()))%>'
                                                                    data-toggle="tooltip" title="View" class="btn btn-default" runat="server"><i class="fa fa-eye"></i></asp:HyperLink>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="Edit" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" Visible="false">
                                                        <ItemTemplate>
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:HyperLink ID="hledit"  NavigateUrl='<%# "ModifyCustomerComplaint.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("CustComplaint_ID").ToString()))%>'
                                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" Visible="false">
                                                        <ItemTemplate>
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                                    CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
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
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
                <!--Complaint-->

                <!--Case-->
                <div id="divCase92" class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#divCase92" href="#faqCase">
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="lblCase" Text="Case" runat="server"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </a></h4>
                        </div>
                        <div id="faqCase" class="panel-collapse collapse" style="height: 0px;">
                            <div class="panel-body">
                                <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="table-responsive">
                                            <asp:GridView ID="gvCase" runat="server" AutoGenerateColumns="False" DataKeyNames="Complaint_ID" AllowCustomPaging="true"
                                                CssClass="table table-striped table-vcenter table-hover" AllowPaging="True" PageSize="10">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="Case No." HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Complaint_Id">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblComplaintId" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Complaint_ID"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="DEPARTMENT" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Deprt_Name">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblDname" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Deprt_Name"))%>' />
                                                            <asp:Literal ID="ltDname" runat="server" Visible="false" Text='<%#(Eval("Deprt_Name"))%>'></asp:Literal>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="Customer Name" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Acc_Name">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblCustomerName" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_Name"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>

                                                    <asp:TemplateField HeaderText="Subject" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Complaint_Subject">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lbldescription" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Complaint_Subject"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Complaint Status" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Complaint_CompStatus">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCname" runat="server" CssClass='<%#Security.checkValidsupport(Eval("Complaint_CompStatus"))%>' Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Complaint_CompStatus"))%>' />
                                                            <%--<asp:Label ID="lblcompstatus" runat="server" CssClass='<%#(Eval("Complaint_CompStatus"))%>' Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Complaint_CompStatus")) %>' />--%>
                                                            <%--<asp:Label ID="lblcompstatus" runat="server" CssClass='<%#Security.checkSupport(Eval("Complaint_CompStatus"))%>' Text='<%#DynamicparcelGridview.HighlightText(Eval("Complaint_CompStatus"), SearchControl.UtxtSearch)%>' />--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Complaint_Status" Visible="false">
                                                        <ItemTemplate>
                                                            <%-- <asp:LinkButton ID="lnk" CssClass='<%#Security.checkStatus(Eval("Complaint_Status"))%>' runat="server" Text='<%#Eval("Complaint_Status")%>'
                                                                CommandName="statuslink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>" />--%>
                                                            <asp:Label ID="lblCname" runat="server" CssClass='<%#Security.checkValidsupport(Eval("Complaint_CompStatus"))%>' Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Complaint_CompStatus"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
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
                                                    <%-- <asp:TemplateField HeaderText="View" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                                        <ItemTemplate>
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:HyperLink ID="HyperLink1"  NavigateUrl='<%# "ViewCustomerComplaint.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Complaint_ID") .ToString()))%>'
                                                                    data-toggle="tooltip" title="View" class="btn btn-default" runat="server"><i class="fa fa-eye"></i></asp:HyperLink></div></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Edit" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                                        <ItemTemplate>
                                                            <div class="btn-group btn-group-xs">

                                                                <asp:HyperLink ID="HyperLink2"  NavigateUrl='<%# "ModifyCustomerComplaint.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Complaint_ID").ToString()))%>'
                                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink></div></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Delete" Visible="false" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                                        <ItemTemplate>
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                                    CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton></div></ItemTemplate></asp:TemplateField>--%>
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
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
                <!--Case-->

                <!--DSR-->

                <div id="divDSR92" class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#divDSR92" href="#faqDSR">
                                <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="lblDSR" Text="DSR" runat="server"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </a></h4>
                        </div>
                        <div id="faqDSR" class="panel-collapse collapse" style="height: 0px;">
                            <div class="panel-body">
                                <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="table-responsive">
                                            <asp:GridView ID="gvDSR" runat="server" AutoGenerateColumns="False" DataKeyNames="Activity_Id" AllowCustomPaging="true"
                                                CssClass="table table-striped table-vcenter table-hover" AllowPaging="True" PageSize="10">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Activity_Id" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblProductId" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Activity_Id"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Activity Subject" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Activity_Subject">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblcode" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Activity_Subject"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Activity Date From" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Activity_CallStartTime">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblname" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Activity_CallStartTime"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Activity Date To" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Activity_CallEndTime">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblCategory" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Activity_CallEndTime"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Account Name" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Acc_Name">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblRate" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_Name"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Activity Owner" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="U_FirstName">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblActOwner" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("U_FirstName"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Activity_ActivityStatus">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblStatus" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Activity_ActivityStatus"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Priority" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Activity_Priority">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblPriority" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Activity_Priority"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="View" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                                        <ItemTemplate>
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:LinkButton ID="lnkview" Height="25" Width="25" runat="server"
                                                                    CommandName="Viewing" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-eye"></i></asp:LinkButton><%-- <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "ViewCustomerComplaint.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Activity_Id").ToString()))%>'
                                                                    data-toggle="tooltip" title="View" class="btn btn-default" runat="server"><i class="fa fa-eye"></i></asp:HyperLink>--%><asp:Literal ID="ltrelatedtypeid" runat="server" Text='<%#Eval("Activity_RelatedTypeID")%>' Visible="false"></asp:Literal><asp:Literal ID="ltrelatedtype" runat="server" Text='<%#Eval("Activity_RelatedType")%>' Visible="false"></asp:Literal>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="Edit" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                                        <ItemTemplate>
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:HyperLink ID="hledit" NavigateUrl='<%# "ModifyCustomerComplaint.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Activity_Id").ToString()))%>'
                                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%><%--<asp:TemplateField HeaderText="Delete" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                    CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
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
                                        <%--<asp:AsyncPostBackTrigger ControlID="btnfollowNo" />--%>
                                        <%--<asp:AsyncPostBackTrigger ControlID="btnaddnote" />--%>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>

                <asp:UpdatePanel ID="UpdatePanel13" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:LinkButton ID="btnfollowupshow" runat="server"></asp:LinkButton><asp:ModalPopupExtender ID="mpefollowup" runat="server" PopupControlID="Panel2" TargetControlID="btnfollowupshow"
                            CancelControlID="btnfollowNo" BackgroundCssClass="pop">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="Panel2" runat="server" Style="display: none">
                            <div class="modal-dialog modal-lg" style="overflow-y: scroll; position: fixed; top: 0; bottom: 0; left: 0; right: 0; overflow: auto;">
                                <div class="modal-content" style="top: 1%; overflow-x: hidden; overflow-y: auto; outline: none; margin-top: 0; overflow: visible;">
                                    <div class="modal-header">
                                        <asp:LinkButton ID="btnfollowNo" class="close" runat="server">&times;</asp:LinkButton><h4 class="modal-title">DSR Detail</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div id="actndt1" class="panel-group">
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title"><i class="fa fa-angle-right"></i><a class="accordion-toggle" data-toggle="collapse" data-parent="#actndt1" href="#Actdt">DSR Detail</a></h4>
                                                </div>
                                                <div id="Actdt" class="panel-collapse collapse in">
                                                    <div class="panel-body">
                                                        <div class="table-responsive">
                                                            <table class="table table-borderless table-striped">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 20%;"><strong>
                                                                            <asp:Label ID="lblAccName" runat="server" Text="Account Name"></asp:Label></a></strong></td>
                                                                        <td>
                                                                            <asp:Literal ID="ltAccName" runat="server"></asp:Literal></td>
                                                                    </tr>
                                                                    <tr id="trcontact" runat="server">
                                                                        <td style="width: 20%;"><strong>
                                                                            <asp:Label ID="Label1" runat="server" Text="Contact Name"></asp:Label></a></strong></td>
                                                                        <td>
                                                                            <asp:Literal ID="ltcontact" runat="server"></asp:Literal></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 20%;"><strong>
                                                                            <asp:Label ID="Label3" runat="server" Text="Activity Owner"></asp:Label></a></strong></td>
                                                                        <td>
                                                                            <asp:Literal ID="ltowner" runat="server"></asp:Literal></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 20%;"><strong>Activity Subject</strong></td>
                                                                        <td>
                                                                            <asp:Literal ID="lblsubject" runat="server"></asp:Literal></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><strong>Activity Date </strong></td>
                                                                        <td>
                                                                            <b>From </b><%--<asp:Literal ID="ltstartdate" runat="server"></asp:Literal>--%><asp:Literal ID="ltstartdate" Text="25 April 2014" runat="server"></asp:Literal><b>To</b>
                                                                            <asp:Literal ID="ltenddate" Text="25 April 2014" runat="server"></asp:Literal></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><strong>Status</strong></td>
                                                                        <td>
                                                                            <asp:Label ID="ltstatus" CssClass="label label-info" Text="Close Pospone" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><strong>Priority</strong></td>
                                                                        <td>
                                                                            <asp:Label ID="ltpriority" CssClass="label label-warning" Text="High" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><strong>Desc</strong></td>
                                                                        <td>
                                                                            <asp:Literal ID="ltdesc" runat="server"></asp:Literal></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><strong>Result</strong></td>
                                                                        <td>
                                                                            <asp:Literal ID="ltresult" runat="server"></asp:Literal></td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-default" style="display: none;">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title"><i class="fa fa-angle-right"></i><a class="accordion-toggle" data-toggle="collapse" data-parent="#actndt1" href="#faq1asda_q2">DSR History</a></h4>
                                                </div>
                                                <div id="faq1asda_q2" class="panel-collapse collapse">
                                                    <div class="panel-body">
                                                        <asp:GridView ID="grdactivityhistory" runat="server" AutoGenerateColumns="true" DataKeyNames="Status" CssClass="table table-striped table-vcenter table-hover">

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
                                                </div>
                                            </div>
                                        </div>
                                        <%--<div class="col-sm-2" style="display: none"><a>Date</a>:-<b><asp:Literal ID="lblactivitydate" runat="server"></asp:Literal></b></div>--%>
                                        <div style="clear: both"></div>

                                        <asp:HiddenField ID="hffollowactivityid" runat="server" />
                                        <asp:HiddenField ID="hfmainactivityid" runat="server" />
                                        <asp:HiddenField ID="hfreltype" runat="server" />
                                        <asp:HiddenField ID="hfreltypeId" runat="server" />
                                    </div>

                                </div>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvDSR" />
                        <%--<asp:AsyncPostBackTrigger ControlID="btnaddnote" />--%>
                    </Triggers>
                </asp:UpdatePanel>

                <!--DSR-->

                <User:QuotationControl ID="quotationcontrol" runat="server" />
                <User:EmailControl ID="emailcontrol" runat="server" />
                <div id="faq6" class="panel-group">
                    <User:NoteControl ID="notecontrol" runat="server" />
                </div>
                <div id="faq1" class="panel-group">
                    <User:NewDocumentControl ID="documentcontrol" runat="server" />
                </div>

                <%-- CRM Feedback --%>
                <div id="divCRM92" class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#divCRM92" href="#faqCRM">
                                <asp:UpdatePanel ID="UpdatePanel16" runat="server" UpdateMode="Always" >
                                    <ContentTemplate>
                                        <asp:Label ID="lblCRMFeedback" Text="CRM Feedback" runat="server"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </a></h4>
                        </div>
                        <div id="faqCRM" class="panel-collapse collapse" style="height: 0px;">
                            <div class="panel-body">
                                <asp:UpdatePanel ID="UpdatePanel17" runat="server" UpdateMode="Always">
                                    <ContentTemplate>
                                        <div class="table-responsive">
                                            <asp:GridView ID="gvFeedBack" runat="server" AutoGenerateColumns="False" DataKeyNames="Rating_Id" AllowCustomPaging="true"
                                                CssClass="table table-striped table-vcenter table-hover" AllowPaging="True" PageSize="10">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="User" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="U_FirstName" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblRelatedTypeID" runat="server" Visible="false" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Activity_RelatedTypeID"))%>' />
                                                                        <asp:Literal ID="lblRelatedType" runat="server" Visible="false" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("RelatedType"))%>' />
                                                                        <asp:Literal ID="lblActivityType" Visible="false"  runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("ActivityType"))%>' /></td>
                                                            <asp:Label ID="lblMessageID" runat="server" Text='<%# (Eval("Rating_Id"))%>' Visible="false"></asp:Label>
                                                <asp:Literal ID="lblActivityID" runat="server" Text='<%#Eval("Activity_Id")%>' Visible="false" />
                                                <asp:Literal ID="lblRemark" runat="server" Text='<%#Eval("Rating_Remark")%>' Visible="false" />
                                                <asp:Literal ID="lblU_FirstName" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("U_FirstName"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Customer" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Contact">
                                                        <ItemTemplate>
                                                <asp:Literal ID="lblContactName" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("ContactName"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Subject" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Subject">
                                                        <ItemTemplate>
                                                    <asp:Literal ID="lblSubject" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Subject"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="From1">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblFrom" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("From1"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Ratings" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Ratings">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblRating_TypeId" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Ratings"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Communication" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Rating_Listening">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblRating_Listening" Visible="false" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Rating_Listening"))%>' />
                                                <asp:Rating runat="server" ID="Rating1" MaxRating="5" CurrentRating='<%#Eval("Rating_Listening")%>'
                                                    CssClass="ratingStar1" StarCssClass="ratingItem1" WaitingStarCssClass="Saved1" FilledStarCssClass="Filled1"
                                                    EmptyStarCssClass="Empty1" AutoPostBack="True" ReadOnly="true">
                                                </asp:Rating>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Product Knowledge" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="lblRating_Knowledge">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblRating_Knowledge" Visible="false" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Rating_Knowledge"))%>' />
                                                 <asp:Rating runat="server" ID="Rating2" MaxRating="5" CurrentRating='<%#Eval("Rating_Knowledge")%>'
                                                    CssClass="ratingStar1" StarCssClass="ratingItem1" WaitingStarCssClass="Saved1" FilledStarCssClass="Filled1"
                                                    EmptyStarCssClass="Empty1" AutoPostBack="True" ReadOnly="true">
                                                </asp:Rating>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Attitude" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Activity_Priority">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="lblRating_Understandability" Visible="false" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Rating_Understandability"))%>' />
                                                <asp:Rating runat="server" ID="Rating3" MaxRating="5" CurrentRating='<%#Eval("Rating_Understandability")%>'
                                                    CssClass="ratingStar1" StarCssClass="ratingItem1" WaitingStarCssClass="Saved1" FilledStarCssClass="Filled1"
                                                    EmptyStarCssClass="Empty1" AutoPostBack="True" ReadOnly="true">
                                                </asp:Rating>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Remark" ItemStyle-Width="10px" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                                        <ItemTemplate>
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:LinkButton ID="lnkview" Height="25" Width="25" runat="server"
                                                                    CommandName="Viewing" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-eye"></i></asp:LinkButton><%-- <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "ViewCustomerComplaint.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Activity_Id").ToString()))%>'
                                                                    data-toggle="tooltip" title="View" class="btn btn-default" runat="server"><i class="fa fa-eye"></i></asp:HyperLink>--%>
                                                                <asp:Literal ID="ltrelatedtypeid" runat="server" Text='<%#Eval("Activity_RelatedTypeID")%>' Visible="false"></asp:Literal><asp:Literal ID="ltrelatedtype" runat="server" Text='<%#Eval("Activity_RelatedType")%>' Visible="false"></asp:Literal>
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
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel18" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:LinkButton ID="btnShowFeed" runat="server" ></asp:LinkButton>
                                <asp:ModalPopupExtender ID="mpeFeed" runat="server" PopupControlID="pnlPopupFeed" TargetControlID="btnShowFeed"
                                    CancelControlID="btnNo">
                                </asp:ModalPopupExtender>
                                <asp:Panel ID="pnlPopupFeed" runat="server" Style="display: none">
                                    <div class="modal-dialog">
                                        <div class="modal-content" style="max-height: 600px; min-width: 700px;">
                                            <div class="modal-header">
                                                <asp:LinkButton ID="LinkButton2" class="close" runat="server">&times;</asp:LinkButton>
                                                <h4 class="modal-title">
                                                    <asp:Label ID="Label2" runat="server" Text="Feedback Details"></asp:Label></h4>
                                            </div>
                                            <div class="modal-body" style="overflow-y: scroll; max-height: 550px; min-width: 700px;">

                                                <div class="modal-body">
                                                    <div id="CRMactndt1" class="panel-group">
                                                        <div class="panel panel-default">
                                                            <div class="panel-heading">
                                                                <h4 class="panel-title"><i class="fa fa-angle-right"></i><a class="accordion-toggle" data-toggle="collapse" data-parent="#CRMactndt1" href="#CRMFeedback_q2">Customer Remark</a></h4>
                                                            </div>
                                                            <div id="CRMFeedback_q2" class="panel-collapse collapse in">
                                                                <div class="panel-body">
                                                                    <div class="table-responsive">
                                                                        <table class="table table-borderless table-striped">
                                                                            <tr>
                                                                                <td style="width: 20%;"><strong>
                                                                                    <asp:Label ID="Label6" runat="server" Text="Ratings"></asp:Label></strong></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblRating" runat="server" data-toggle="tooltip" title="Message"></asp:Label>
                                                                                </td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 20%;"><strong>
                                                                                    <asp:Label ID="Label7" runat="server" Text="Communication"></asp:Label></strong></td>
                                                                                <td>
                                                                                    <asp:Rating runat="server" ID="RatingListening" MaxRating="5"
                                                                                        CssClass="ratingStar1" StarCssClass="ratingItem1" WaitingStarCssClass="Saved1" FilledStarCssClass="Filled1"
                                                                                        EmptyStarCssClass="Empty1" AutoPostBack="True" ReadOnly="true">
                                                                                    </asp:Rating>
                                                                                </td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 20%;"><strong>
                                                                                    <asp:Label ID="Label8" runat="server" Text="Product Knowledge"></asp:Label></strong></td>
                                                                                <td>
                                                                                    <asp:Rating runat="server" ID="RatingKnowledge" MaxRating="5"
                                                                                        CssClass="ratingStar1" StarCssClass="ratingItem1" WaitingStarCssClass="Saved1" FilledStarCssClass="Filled1"
                                                                                        EmptyStarCssClass="Empty1" AutoPostBack="True" ReadOnly="true">
                                                                                    </asp:Rating>
                                                                                </td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 20%;"><strong>
                                                                                    <asp:Label ID="Label9" runat="server" Text="Attitude"></asp:Label></strong></td>
                                                                                <td>
                                                                                    <asp:Rating runat="server" ID="RatingUnderstandability" MaxRating="5"
                                                                                        CssClass="ratingStar1" StarCssClass="ratingItem1" WaitingStarCssClass="Saved1" FilledStarCssClass="Filled1"
                                                                                        EmptyStarCssClass="Empty1" AutoPostBack="True" ReadOnly="true">
                                                                                    </asp:Rating>
                                                                                </td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 20%;"><strong>
                                                                                    <asp:Label ID="Label5" runat="server" Text="Remark"></asp:Label></strong></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblMessage" runat="server" data-toggle="tooltip" title="Message"></asp:Label></td>

                                                                            </tr>

                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="panel panel-default">
                                                            <div class="panel-heading">
                                                                <h4 class="panel-title"><i class="fa fa-angle-right"></i><a class="accordion-toggle" data-toggle="collapse" data-parent="#CRMactndt1" href="#ActdtCRM">Activity Detail</a></h4>
                                                            </div>
                                                            <div id="ActdtCRM" class="panel-collapse collapse">
                                                                <div class="panel-body">
                                                                    <div class="table-responsive">
                                                                        <table class="table table-borderless table-striped">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 20%;"><strong>
                                                                                        <asp:Label ID="lblnameFeed" runat="server" Text="Account Name"></asp:Label></a></strong></td>
                                                                                    <td>
                                                                                        <asp:Literal ID="lblaccnameFeed" runat="server"></asp:Literal></td>

                                                                                </tr>
                                                                                <tr id="trcontactFeed" runat="server">
                                                                                    <td style="width: 20%;"><strong>
                                                                                        <asp:Label ID="Label10" runat="server" Text="Contact Name"></asp:Label></a></strong></td>
                                                                                    <td>
                                                                                        <asp:Literal ID="ltcontactFeed" runat="server"></asp:Literal></td>

                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 20%;"><strong>
                                                                                        <asp:Label ID="Label11" runat="server" Text="Activity Owner"></asp:Label></a></strong></td>
                                                                                    <td>
                                                                                        <asp:Literal ID="ltownerFeed" runat="server"></asp:Literal></td>

                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 20%;"><strong>Activity Subject</strong></td>
                                                                                    <td>
                                                                                        <asp:Literal ID="lblsubjectFeed" runat="server"></asp:Literal></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td><strong>Activity Date </strong></td>
                                                                                    <td>
                                                                                        <b>From </b>
                                                                                        <asp:Literal ID="ltstartdateFeed" Text="25 April 2014" runat="server"></asp:Literal>
                                                                                        <b>To</b>
                                                                                        <asp:Literal ID="ltenddateFeed" Text="25 April 2014" runat="server"></asp:Literal></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td><strong>Status</strong></td>
                                                                                    <td>
                                                                                        <asp:Label ID="ltstatusFeed" CssClass="label label-info" Text="Close Pospone" runat="server"></asp:Label></td>

                                                                                </tr>
                                                                                <tr>
                                                                                    <td><strong>Priority</strong></td>
                                                                                    <td>
                                                                                        <asp:Label ID="ltpriorityFeed" CssClass="label label-warning" Text="High" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td><strong>Desc</strong></td>
                                                                                    <td>
                                                                                        <asp:Literal ID="ltdescFeed" runat="server"></asp:Literal>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td><strong>Result</strong></td>
                                                                                    <td>
                                                                                        <asp:Literal ID="ltresultFeed" runat="server"></asp:Literal>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <asp:HiddenField ID="hffollowactivityidFeed" runat="server" />
                                                    <asp:HiddenField ID="hfmainactivityidFeed" runat="server" />
                                                    <asp:HiddenField ID="hfreltypeFeed" runat="server" />
                                                    <asp:HiddenField ID="hfreltypeIdFeed" runat="server" />

                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="gvFeedBack" />
                            </Triggers>
                        </asp:UpdatePanel>
                

                <%-- CRM Feedback --%>

            </div>
            <User:ActivityControl ID="activitycontrol" runat="server" Visible="false" />


        </div>
    </div>
</asp:Content>
