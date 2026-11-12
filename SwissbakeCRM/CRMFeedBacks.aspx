<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="CRMFeedBacks.aspx.vb" Inherits="CRMFeedBacks" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/jquery.min.js"></script>
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
    <script type="text/javascript">
        function lkdeleteclick() {
            if (confirm('Are you sure want to delete ?')) {
                document.getElementById('<%=deletestatus.ClientID %>').value = "yes";
            }
            else {
                document.getElementById('<%=deletestatus.ClientID %>').value = "no";
                return true
            }
        }
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
    </script>
    <script>
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
    <%--<script>
        $(document).ready(function(){
           
            $(function () {
           
           
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
        });
    </script>--%>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="PrintStatus" runat="server" />
    <asp:HiddenField ID="hfgridview" runat="server" />
    <asp:HiddenField ID="deletestatus" runat="server" />
    <div class="content-header">
        <div class="header-section">
            <h2><asp:Label ID="lblHead1" runat="server" >CRM Feedback</asp:Label></h2>
        </div>
    </div>
    <ul class="breadcrumb breadcrumb-top">
        <li><a href="CRMindex.aspx">Home</a> </li>
        <li><asp:Label ID="lblHead2" runat="server" >CRM Feedback</asp:Label></li>
    </ul>
    <div class="block full">
        <div class="block-title">
            <h2><strong><asp:Label ID="lblHead3" runat="server" >CRM Feedback</asp:Label></strong> List</h2>
        </div>
        <%--<div class="row">

            <div class="col-sm-12 text-right">
                <asp:HyperLink ID="hlnkAdd" EnableViewState="false" runat="server" Text="ADD" CssClass="btn btn-alt btn-sm btn-primary"></asp:HyperLink>
                <asp:Button ID="btnExport" runat="server" CssClass="btn btn-alt btn-sm btn-success " CausesValidation="false" Text="Export to Excel" Visible="false" />
                <asp:Button ID="btnAllContacts" runat="server" CssClass="btn btn-sm btn-warning " CausesValidation="false" Text="All Contacts to Excel"  />
            </div>
        </div>--%>
        <div class="table-responsive">

            <div class="table-options clearfix" style="background-color: #f9fafc; padding: 8px 0 5px; width: auto; border: 1px solid #eaedf1;">
                <div id="divParam" runat="server" visible="false">
                <div class="col-md-3">
                        <label class="col-md-3 control-label">From</label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtfrom" runat="server" class="form-control" placeholder="Enter From Date" TextMode="Date" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfrom" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                ErrorMessage="Enter From date" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <label class="col-md-3 control-label">To</label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtto" runat="server" class="form-control" placeholder="Enter To Date" TextMode="Date" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                ErrorMessage="Enter To date" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ErrorMessage="Enter Valid date" CssClass="MasterValidationCSS" ControlToCompare="txtfrom" ControlToValidate="txtto" Operator="GreaterThanEqual" ValidationGroup="MasterGroup"></asp:CompareValidator>
                        </div>
                    </div>
                <div class="col-md-3">
                        <label class="col-md-3 control-label">User</label>
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddlUser" runat="server" AutoPostBack="true" class="form-control select-chosen">
                            </asp:DropDownList>

                        </div>
                    </div>

                    <div class="col-md-3">
                        <label class="col-md-3 control-label">Customer</label>
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddlCustomer" runat="server" AutoPostBack="true" class="form-control select-chosen">
                            </asp:DropDownList>

                        </div>
                    </div>
                </div>
                            <div style="clear: both"></div>
            <br />
                <div class="col-md-2">
                    <div>
                        <asp:DropDownList ID="ddpagesize" AutoPostBack="true" runat="server" CssClass="form-control">
                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                            <asp:ListItem Text="30" Value="30"></asp:ListItem>
                            <asp:ListItem Text="50" Value="50"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
              <%--  <div class="col-sm-8">
                </div>--%>
                 <div class="col-md-1 pull-right" id="divSub" runat="server">
                        <asp:Button ID="btndashboard" ValidationGroup="MasterGroup" runat="server" Text="Submit" CssClass="btn btn-sm btn-primary" />

                    </div>
                <asp:Button ID="btnExport" runat="server" CssClass="btn btn-alt btn-sm btn-success pull-right " CausesValidation="false" Text="Export to Excel" />
                <div class="col-sm-3 pull-right input-group" style="padding-left: 15px; padding-right: 15px;">
                    <asp:TextBox runat="server" ID="txtSearch" class="form-control" placeholder="Search" OnTextChanged="Text_TextChanged"></asp:TextBox>
                    <span class="input-group-addon"><i class="fa fa-search"></i></span>
                </div>
               

            </div>

            <asp:UpdatePanel runat="server" ID="rpg">
                <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server">
                        <%--  <asp:UpdatePanel runat="server" ID="rpg">
                    <ContentTemplate>--%>
                        <table id="printtable" class="table table-vcenter table-condensed table-bordered" style="margin-bottom: 0px;">
                            <thead>
                                <tr>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">User</th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Customer</th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Contact</th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Subject</th>
                                    <%--<th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Activity Type</th>--%>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Date</th>
                                    <%--<th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">To</th>--%>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Ratings</th>
                                    <%--<th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Listening</th>--%>
                                     <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Communication</th>
                                    <%--<th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Knowledge</th>--%>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Product Knowledge</th>
                                    <%--<th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Understandability</th>--%>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Attitude</th>

                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;" id="thEdit" runat="server" >Remark</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rpgridview" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            
                                            <td class="text-center">
                                                <asp:Label ID="lblMessageID" runat="server" Text='<%# (Eval("Rating_Id"))%>' Visible="false"></asp:Label>
                                                <asp:Literal ID="lblActivityID" runat="server" Text='<%#Eval("Activity_Id")%>' Visible="false" />
                                                <asp:Literal ID="lblRemark" runat="server" Text='<%#Eval("Rating_Remark")%>' Visible="false" />
                                                <asp:Literal ID="lblU_FirstName" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("U_FirstName"))%>' /></td>
                                            </td>
                                            <td class="text-center">
                                                <asp:Literal ID="lblAccName" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("AccName"))%>' /></td>
                                            <td class="text-center">
                                                <asp:Literal ID="lblContactName" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("ContactName"))%>' /></td>
                                            <td class="text-center">
                                                    <asp:Literal ID="lblSubject" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Subject"))%>' /></td>
                                                <td class="text-center" style="display:none;">
                                                    <asp:Literal ID="lblRelatedTypeID" runat="server" Visible="false" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Activity_RelatedTypeID"))%>' />
                                                    <asp:Literal ID="lblRelatedType" runat="server" Visible="false" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("RelatedType"))%>' />
                                                    <asp:Literal ID="lblActivityType" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("ActivityType"))%>' /></td>
                                                <td class="text-center">
                                                    <asp:Literal ID="lblFrom" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("From1"))%>' />
                                                </td>
                                                <%--<td class="text-center">
                                                <asp:Label ID="lblType" runat="server"  Text='<%#Eval("Acc_Type").ToString%>' EnableViewState="false" />
                                            <asp:Literal ID="lblowner" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("U_FirstName")), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                            </td>--%>
                                                <td class="text-center" style="display:none;">
                                                    <asp:Literal ID="lblTo" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("To1")))%>' />
                                                </td>
                                            <td class="text-center">
                                                <asp:Literal ID="lblRating_TypeId" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Ratings"))%>' />
                                                
                                            </td>
                                            <td class="text-center">
                                                <asp:Literal ID="lblRating_Listening" Visible="false" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Rating_Listening"))%>' />
                                                <asp:Rating runat="server" ID="Rating1" MaxRating="5" CurrentRating='<%#Eval("Rating_Listening")%>'
                                                    CssClass="ratingStar1" StarCssClass="ratingItem1" WaitingStarCssClass="Saved1" FilledStarCssClass="Filled1"
                                                    EmptyStarCssClass="Empty1" AutoPostBack="True" ReadOnly="true">
                                                </asp:Rating>
                                            </td>
                                            <td class="text-center">
                                                <asp:Literal ID="lblRating_Knowledge" Visible="false" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Rating_Knowledge"))%>' />
                                                 <asp:Rating runat="server" ID="Rating2" MaxRating="5" CurrentRating='<%#Eval("Rating_Knowledge")%>'
                                                    CssClass="ratingStar1" StarCssClass="ratingItem1" WaitingStarCssClass="Saved1" FilledStarCssClass="Filled1"
                                                    EmptyStarCssClass="Empty1" AutoPostBack="True" ReadOnly="true">
                                                </asp:Rating>
                                            </td>
                                            <td class="text-center">
                                                <asp:Literal ID="lblRating_Understandability" Visible="false" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Rating_Understandability"))%>' />
                                                <asp:Rating runat="server" ID="Rating3" MaxRating="5" CurrentRating='<%#Eval("Rating_Understandability")%>'
                                                    CssClass="ratingStar1" StarCssClass="ratingItem1" WaitingStarCssClass="Saved1" FilledStarCssClass="Filled1"
                                                    EmptyStarCssClass="Empty1" AutoPostBack="True" ReadOnly="true">
                                                </asp:Rating>
                                            </td>
                                            <td class="text-center" id="tdEdit" runat="server">
                                                <div class="btn-group btn-group-xs">
                                                    <asp:LinkButton ID="lnkMessage" CommandName="MessagePopUp" CommandArgument='<%#Eval("Rating_Id")%>'
                                                        data-toggle="tooltip" title="View" class="btn btn-success" runat="server"><i class="fa fa-eye"></i></asp:LinkButton>
                                                </div>
                                            </td>
                                        </tr>

                                    </ItemTemplate>


                                    <FooterTemplate>
                                        <tr id="trEmpty" runat="server" visible="false">
                                            <td class="dataTables_empty" style="width: 240px;">No matching records found.
                                            </td>
                                        </tr>

                                    </FooterTemplate>
                                </asp:Repeater>
                                <asp:Label ID="Label3" runat="server" Text="No matching records found" Visible="false"></asp:Label>



                            </tbody>

                        </table>
                        <%--   </ContentTemplate>
                    </asp:UpdatePanel> --%>
                        <asp:HiddenField ID="hfBackcount" runat="server" />
                        <asp:HiddenField ID="tab" runat="server" />
                        <div class="row" style="margin: 0px;">
                            <div class="col-md-12" style="background-color: #f9fafc; padding: 10px 0; border: 1px solid #eaedf1; border-top-width: 0;">
                                <div class="col-sm-5 hidden-xs">
                                    <div class="dataTables_info" role="status" aria-live="polite">
                                        <%--  <strong>1</strong>-<strong>10</strong> of <strong>10</strong>--%>

                                        <strong>
                                            <asp:Label ID="lblTcount" runat="server"></asp:Label></strong>

                                    </div>
                                </div>
                                <div class="col-sm-7 col-xs-12 clearfix">
                                    <div class="dataTables_paginate paging_bootstrap" id="example-datatable_paginate">
                                        <%--  <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                    <ContentTemplate>--%>
                                        <ul id="menu" class="pagination pagination-sm remove-margin" style="height: 12px;">

                                            <asp:Repeater ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand" OnItemDataBound="rptPaging_ItemDataBound">

                                                <ItemTemplate>

                                                    <li data-category="TestValue" id="li1">

                                                        <asp:LinkButton ID="btnPage" CssClass="" class="dataTables_paginate paging_bootstrap" data-category="TestValue"
                                                            CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                                                            runat="server" Font-Bold="True"><%# Container.DataItem %>
                                                        </asp:LinkButton>
                                                    </li>
                                                </ItemTemplate>

                                            </asp:Repeater>


                                        </ul>
                                        <%--   </ContentTemplate>
                                     
                    </asp:UpdatePanel> --%>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </asp:Panel>

                    <%-- PoPuP --%>
                    <asp:LinkButton ID="btnShow" runat="server" />
                    <asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="btnShow"
                        CancelControlID="btnNo">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlPopup" runat="server" Style="display: none" DefaultButton="btnsave">
                        <div class="modal-dialog">
                            <div class="modal-content" style="max-height: 600px; min-width: 700px;">
                                <div class="modal-header">
                                    <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                                    <h4 class="modal-title">
                                        <asp:Label ID="Label1" runat="server" Text="Feedback Details"></asp:Label></h4>
                                </div>
                                <div class="modal-body" style="overflow-y: scroll; max-height: 550px; min-width: 700px;">
                                    
                                    <div class="modal-body">
                                        <div id="actndt1" class="panel-group">
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title"><i class="fa fa-angle-right"></i><a class="accordion-toggle" data-toggle="collapse" data-parent="#actndt1" href="#faq1asda_q2">Customer Remark</a></h4>
                                                </div>
                                                <div id="faq1asda_q2" class="panel-collapse collapse in">
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
                                                                            EmptyStarCssClass="Empty1" AutoPostBack="True" ReadOnly="true"></asp:Rating>
                                                                    </td>

                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%;"><strong>
                                                                        <asp:Label ID="Label8" runat="server" Text="Product Knowledge"></asp:Label></strong></td>
                                                                    <td>
                                                                        <asp:Rating runat="server" ID="RatingKnowledge" MaxRating="5" 
                                                                            CssClass="ratingStar1" StarCssClass="ratingItem1" WaitingStarCssClass="Saved1" FilledStarCssClass="Filled1"
                                                                            EmptyStarCssClass="Empty1" AutoPostBack="True" ReadOnly="true"></asp:Rating>
                                                                    </td>

                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%;"><strong>
                                                                        <asp:Label ID="Label9" runat="server" Text="Attitude"></asp:Label></strong></td>
                                                                    <td>
                                                                        <asp:Rating runat="server" ID="RatingUnderstandability" MaxRating="5" 
                                                                            CssClass="ratingStar1" StarCssClass="ratingItem1" WaitingStarCssClass="Saved1" FilledStarCssClass="Filled1"
                                                                            EmptyStarCssClass="Empty1" AutoPostBack="True" ReadOnly="true"></asp:Rating>
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
                                                    <h4 class="panel-title"><i class="fa fa-angle-right"></i><a class="accordion-toggle" data-toggle="collapse" data-parent="#actndt1" href="#Actdt">Activity Detail</a></h4>
                                                </div>
                                                <div id="Actdt" class="panel-collapse collapse">
                                                    <div class="panel-body">
                                                        <div class="table-responsive">
                                                            <table class="table table-borderless table-striped">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 20%;"><strong>
                                                                            <asp:Label ID="lblname" runat="server" Text="Account Name"></asp:Label></a></strong></td>
                                                                        <td>
                                                                            <asp:Literal ID="lblaccname" runat="server"></asp:Literal></td>

                                                                    </tr>
                                                                    <tr id="trcontact" runat="server">
                                                                        <td style="width: 20%;"><strong>
                                                                            <asp:Label ID="Label2" runat="server" Text="Contact Name"></asp:Label></a></strong></td>
                                                                        <td>
                                                                            <asp:Literal ID="ltcontact" runat="server"></asp:Literal></td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 20%;"><strong>
                                                                            <asp:Label ID="Label4" runat="server" Text="Activity Owner"></asp:Label></a></strong></td>
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
                                                                            <b>From </b>
                                                                            <asp:Literal ID="ltstartdate" Text="25 April 2014" runat="server"></asp:Literal>
                                                                            <b>To</b>
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
                                                                            <asp:Literal ID="ltdesc" runat="server"></asp:Literal>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><strong>Result</strong></td>
                                                                        <td>
                                                                            <asp:Literal ID="ltresult" runat="server"></asp:Literal>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <asp:HiddenField ID="hffollowactivityid" runat="server" />
                                        <asp:HiddenField ID="hfmainactivityid" runat="server" />
                                        <asp:HiddenField ID="hfreltype" runat="server" />
                                        <asp:HiddenField ID="hfreltypeId" runat="server" />

                                    </div>

                                <%--</div>--%>
                            <%--</div>--%>
                        <%--</asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnaddnote" />
                    </Triggers>
                </asp:UpdatePanel>--%>
                                </div>
                                <div class="modal-footer" style="display: none;">
                                    <asp:Button Visible="false" ID="btnsave" runat="server" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                        UseSubmitBehavior="false" class="btn btn-sm btn-primary" ValidationGroup="MasterGroup" Text="Save"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <%-- PoPuP --%>
                </ContentTemplate>
                <Triggers>
                   <asp:AsyncPostBackTrigger ControlID="rpgridview" />
                       <%--<asp:AsyncPostBackTrigger ControlID="rptPaging" />--%>
                    <%-- <asp:AsyncPostBackTrigger ControlID="rptPaging"  EventName="rptPaging_ItemCommand"/>--%>
                </Triggers>

            </asp:UpdatePanel>
        </div>
    </div>


</asp:Content>





<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>--%>

