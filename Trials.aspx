<%@ Page Title="" Language="VB" MasterPageFile="~/LMSMasterPage.master" AutoEventWireup="false" CodeFile="Trials.aspx.vb" Inherits="Trials" %>

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
    <script type="text/javascript">
        function lkviewInvclick(pagename,invid, id, custid){       
            ;debugger
            var a="";
            // var id= "321";
            // var c = +Prodname;
            $.ajax({
                type: "POST",
                url: "ItemcontrolService.asmx/TripleEncrypt",
                data: '{invid: ' + invid + ',id: ' + id + ', custid: '+ custid+ '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(response){
                    a=response.d;
                    
                },
                async: false
            });
         

            a=a.split(",");
            if(pagename=="PrintDocs.aspx?tpy=SO&type=" || pagename=="PrintDocs.aspx?tpy=InvExp&type=") 
            {
                pagename =  "../"+ pagename+ "pJyQIVSSnfWdSCc47JLzHg%3d%3d"+"&Id="+a[1]+"&Gyt32XyHTtsuc="+a[2]
            }
            else
            {
                pagename = "../"+ pagename+a[0]
            }
            //  window.location.href="../"+pagename;
         
            var win = window.open(pagename, '_blank');
            win.focus();
            
        }
        function lkviewclick(pagename, id, custid){       
            ;debugger
            var a="";
            // var id= "321";
            // var c = +Prodname;
            $.ajax({
                type: "POST",
                url: "ItemcontrolService.asmx/MultiEncrypt",
                data: '{id: ' + id + ', custid: '+ custid+ '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(response){
                    a=response.d;
                    
                },
                async: false
            });
         

            a=a.split(",");
            if(pagename=="PrintDocs.aspx?tpy=SO&type=" || pagename=="PrintDocs.aspx?tpy=InvExp&type=") 
            {
                pagename =  "../"+ pagename+ "pJyQIVSSnfWdSCc47JLzHg%3d%3d"+"&Id="+a[0]+"&Gyt32XyHTtsuc="+a[1]
            }
            else
            {
                pagename = "../"+ pagename+a[0]
            }
            //  window.location.href="../"+pagename;
         
            var win = window.open(pagename, '_blank');
            win.focus();
            
        }
        function lkEditclick(id){
           
            var a="";
            $.ajax({
                type: "POST",
                url: "ItemcontrolService.asmx/Encrypt",
                data: '{id: ' + id + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(response){
                    a=response.d;
                },
                async: false
            });
           
            window.location.href="_ModifyOrder.aspx?chk=v&OrderId="+a;
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
           
            //$(function () {
           
               
            var text = <%=tabss%>;
               
            $('a:contains("' + text + '")').parent().addClass('active disabled');
            $("cite.fn:contains('"+searchText+"')").filter(function(){re‌​turn $(this).text().length==searchText.length})
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_pageLoaded(panelLoaded);
            
            function panelLoaded(sender, args){
                  
                var text = <%=tabss%>;
               var value = $("#<%=tab.ClientID%>").val();
                
               // re-bind your jQuery events here
               $('a:contains("' + value + '")').parent().addClass('active disabled');

           }
               

            //});
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="deletestatus" runat="server" />
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="content-header">
                        <div class="header-section">
                            <h1>Trial<br>
                            </h1>
                        </div>
                    </div>
                    <ul class="breadcrumb breadcrumb-top">
                        <li><a href="LMSDashboard.aspx">Home</a></li>
                        <li>Trial</li>
                    </ul>
                    <div class="col-md-12">
                        <div class="widget">
                            <div class="widget-extra themed-background-dark">
                                <h5 class="widget-content-light abc">
                                    <strong>Trial</strong> Details
                                </h5>
                            </div>

                            <div class="block" style="display: table; width: 100%;">
                                <div class="col-md-2">
                                    <div>
                                        <asp:DropDownList ID="ddpagesize" AutoPostBack="true" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                            <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                            <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-8">
                                </div>
                                <div class="col-sm-3 pull-right input-group" style="padding-left: 15px; padding-right: 15px;">
                                    <asp:TextBox runat="server" ID="txtSearch" class="form-control" placeholder="Search" OnTextChanged="Text_TextChanged"></asp:TextBox>
                                    <span class="input-group-addon"><i class="fa fa-search"></i></span>
                                </div>
                                <div class="col-sm-12">
                                    <br />
                                </div>
                                <%--<div class="row">--%>
                                <div class="table-responsive">
                                    <asp:UpdatePanel runat="server" ID="rpg" UpdateMode="Always">
                                        <ContentTemplate>
                                            <asp:Panel ID="pnldemo" runat="server">
                                                <table id="printtable" class="MultiDatatable table table-vcenter table-condensed table-bordered">
                                                    <thead>
                                                        <tr>
                                                            <th class="text-center" style="display: none"></th>
                                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                                <asp:LinkButton Style="color: #1bbae1;" ID="LinkButton1" OnClick="Sorting" runat="server"><i class="hi hi-sort fa-1x"></i>Trial Code</asp:LinkButton></th>
                                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; display: none;">
                                                                <asp:LinkButton Style="color: #1bbae1;" ID="Recipe_No" OnClick="Sorting" runat="server"><i class="hi hi-sort fa-1x"></i>Recipe Code</asp:LinkButton></th>
                                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1; display: none;">
                                                                <asp:LinkButton Style="color: #1bbae1;" ID="Formulation_No" OnClick="Sorting" runat="server"><i class="hi hi-sort fa-1x"></i>Formulation Code</asp:LinkButton></th>
                                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;" id="thProdName" runat="server" visible="false">
                                                                <asp:LinkButton Style="color: #1bbae1;" ID="Product_Name" OnClick="Sorting" runat="server"><i class="hi hi-sort fa-1x"></i>Product Name</asp:LinkButton></th>
                                                            <%--<th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Assign to</th>--%>

                                                            <th class="text-center col-md-2" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                                <asp:LinkButton Style="color: #1bbae1;" ID="AssignTo" OnClick="Sorting" runat="server"><i class="hi hi-sort fa-1x"></i>Assign to</asp:LinkButton></th>
                                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                                <asp:LinkButton Style="color: #1bbae1;" ID="Recipe_CreatedDate" OnClick="Sorting" runat="server"><i class="hi hi-sort fa-1x"></i>Date</asp:LinkButton></th>
                                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                                <asp:LinkButton Style="color: #1bbae1;" ID="Formulation_ExecutionDate" OnClick="Sorting" runat="server"><i class="hi hi-sort fa-1x"></i>Execution Date</asp:LinkButton></th>
                                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                                <asp:LinkButton Style="color: #1bbae1;" ID="LinkButton2" OnClick="Sorting" runat="server"><i class="hi hi-sort fa-1x"></i>Trial Status</asp:LinkButton></th>
                                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                                <asp:LinkButton Style="color: #1bbae1;" ID="Formulation_Priority" OnClick="Sorting" runat="server"><i class="hi hi-sort fa-1x"></i>Priority</asp:LinkButton></th>
                                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                                <asp:LinkButton Style="color: #1bbae1;" ID="Formulation_CompleteStatus" OnClick="Sorting" runat="server"><i class="hi hi-sort fa-1x"></i>Complete Status</asp:LinkButton></th>
                                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;" id="thview" runat="server" visible="false">View</th>
                                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;" id="thEdit" runat="server" visible="false">Edit</th>
                                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;" id="thDelete" runat="server" visible="false">Delete</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:Repeater ID="rpRecipe" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td style="display: none" class="text-center">
                                                                        <asp:Literal ID="lblRecipeId" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Recipe_Id"), txtSearch)%>' EnableViewState="false" />
                                                                    </td>
                                                                    <td class="text-center">
                                                                        <asp:HyperLink ID="HyperLink1" EnableViewState="false" NavigateUrl='<%# "Multiview.aspx?id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Recipe_Id").ToString())) + "&&Levl=PR" + Eval("Recipe_Id").ToString()%>'
                                                                            runat="server" Target="_blank">
                                                                            <asp:Literal ID="Literal1" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Replace(Eval("Formulation_No"), "FR", "TR"), txtSearch)%>' />
                                                                        </asp:HyperLink><br />
                                                                        <%--<asp:HyperLink ID="HyperLink1" EnableViewState="false" NavigateUrl='<%# "ModifyTrials.aspx?chk=v&ID=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Recipe_FormulationId").ToString())) + "&returnurl=y" %>'
                                                                            runat="server" Target="_blank" ><asp:Literal ID="Literal1" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Replace(Eval("Formulation_No"), "FR", "TR"), txtSearch)%>' /></asp:HyperLink><br /> --%> 
                                                                    </td>
                                                                    <td class="text-center " style="display: none">
                                                                        <%--<asp:Literal ID="lblRecipeno" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Recipe_No"), txtSearch)%>' EnableViewState="false" />--%>

                                                                        <asp:HyperLink ID="HyperLink2" EnableViewState="false" NavigateUrl='<%# "Multiview.aspx?id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Recipe_Id").ToString())) + "&&Levl=PR" + Eval("Recipe_Id").ToString()%>'
                                                                            runat="server" Target="_blank">
                                                                            <asp:Literal ID="lblRecipeno" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Recipe_No"), txtSearch)%>' EnableViewState="false" />
                                                                        </asp:HyperLink><br />



                                                                    </td>
                                                                    <td class="text-center " style="display: none">
                                                                        <asp:Literal ID="lblRecipeName" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Formulation_No"), txtSearch)%>' EnableViewState="false" />
                                                                    </td>
                                                                    <td class="text-center" id="tdProdName" runat="server" visible="false">
                                                                        <asp:Literal ID="lblProductName" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Product_Name"), txtSearch)%>' EnableViewState="false" />
                                                                    </td>
                                                                    <%--<td class="text-center ">
                                                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("Formulation_OwnerId")%>'></asp:Label></td>--%>

                                                                    <td class="text-center col-md-2">
                                                                        <asp:Literal ID="lblassignto" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("AssignTo"), txtSearch)%>' EnableViewState="false" />
                                                                    </td>
                                                                    <td class="text-center ">
                                                                        <asp:Literal ID="lblRecipeDate" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Recipe_CreatedDate"), txtSearch)%>' EnableViewState="false" />
                                                                    </td>
                                                                    <td class="text-center ">
                                                                        <asp:Literal ID="Literal2" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("Formulation_ExecutionDate")), txtSearch)%>' EnableViewState="false" />
                                                                    </td>
                                                                    <td class="text-center ">
                                                                        <asp:Label ID="lblRstatus" runat="server" CssClass='<%#Security.checkpriorityLMS(Eval("Recipe_Approved"))%>' Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Recipe_Approved")))%>' />
                                                                    </td>

                                                                    <td class="text-center ">
                                                                        <asp:Label ID="Literal3" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("Formulation_Priority")), txtSearch)%>'
                                                                            CssClass='<%#Security.checkpriorityLMS(DynamicparcelDataManipulation.FixNullFromDB(Eval("Formulation_Priority")))%>' EnableViewState="false" />
                                                                    </td>
                                                                    <td class="text-center ">
                                                                       <%-- <asp:LinkButton ID="lnkCompleteStatus" CssClass='<%#Security.checkpriorityLMS(Eval("Formulation_CompleteStatus"))%>' runat="server" Text='<%#Eval("Formulation_CompleteStatus")%>'
                                                                            CommandName="Prioritylink" CommandArgument='<%# Eval("Recipe_FormulationId")%>' />--%>
                                                                         <asp:Label ID="lnkCompleteStatus" CssClass='<%#Security.checkpriorityLMS(Eval("Formulation_CompleteStatus"))%>' runat="server" Text='<%#Eval("Formulation_CompleteStatus")%>' />
                                                                        <%--<asp:Label ID="Literal4" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Formulation_CompleteStatus"), txtSearch)%>' 
                                                                            CssClass='<%#Security.checkpriorityLMS(DynamicparcelDataManipulation.FixNullFromDB(Eval("Formulation_CompleteStatus")))%>' EnableViewState="false" />--%>
                                                                    </td>
                                                                    <td class="text-center" id="tdview" runat="server" visible="false">
                                                                        <asp:LinkButton ID="lkview" runat="server" class="btn btn-xs btn-default" CommandName="view" CommandArgument='<%# Eval("Recipe_FormulationId")%>'><i class="fa fa-eye"></i></asp:LinkButton>
                                                                    </td>
                                                                    <td class="text-center" id="tdedit" runat="server" visible="false">
                                                                        <asp:LinkButton ID="lkedit" runat="server" class="btn btn-xs btn-success" CommandName="edit" CommandArgument='<%# Eval("Recipe_FormulationId")%>'><i class="fa fa-pencil"></i></asp:LinkButton>

                                                                    </td>
                                                                    <td class="text-center" id="tddelete" runat="server" visible="false">
                                                                        <asp:LinkButton ID="lkdelete" runat="server" class="btn btn-xs btn-danger" CommandName="delete" CommandArgument='<%# Eval("Recipe_FormulationId")%>' OnClientClick="checkdelete();"><i class="fa fa-times"></i></asp:LinkButton>

                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <tr id="trEmpty" runat="server" visible="false">
                                                                    <td class="dataTables_empty" style="width: 240px;">No records found.
                                                                    </td>
                                                                </tr>

                                                            </FooterTemplate>
                                                        </asp:Repeater>
                                                        <asp:Label ID="Label1" runat="server" Text="No matching records found" Visible="false"></asp:Label>



                                                        <%-- <tfoot>
                        <tr> 
                              <th class="text-center"><span class="filter_column filter_text">
                                            <asp:TextBox ID="TextBox1" runat="server" Style="text-align: center; font-weight: 500;  margin: 0 auto;" class="text-center form-control text_filter"  placeholder="Customer Name" onkeyup="searchfoot(this)" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                        <th class="text-center"><span class="filter_column filter_text">
                                            <asp:TextBox ID="TextBox2" runat="server" Style="text-align: center; font-weight: 500;  margin: 0 auto;" class="text-center form-control text_filter"  placeholder="Mobile No" onkeyup="searchfoot(this)" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                               
                                               <th class="text-center"><span class="filter_column filter_text"></span></th>
                                       
                                         
                        </tr>
                    </tfoot>--%>
                                                    </tbody>
                                                </table>
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
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <%--</div>--%>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

