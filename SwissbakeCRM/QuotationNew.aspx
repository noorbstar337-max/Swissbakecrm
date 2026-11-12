<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="QuotationNew.aspx.vb" Inherits="QuotationNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/jquery.min.js"></script>
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
           
           ;debugger
                var text = <%=tabss%>;
                if (text == "0"){
                }
                else{
                    ;debugger
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
    <script type="text/javascript">
        function lkviewclick(id, type){       
           
            var a="";
            var pagename="ViewQuotation.aspx?Id=";
            var Curr=type;
            // var id= "321";
            // var c = +Prodname;
            $.ajax({
                type: "POST",
                url: "ItemcontrolService.asmx/DoubleEncrypt",
                data: '{id: ' + id + ', type: "'+ Curr + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(response){
                    a=response.d;
                },
                async: false
            });
            a=a.split(",");
            pagename =  "../" + pagename+ a[0]+"&Qtyp="+a[1]
           
            //var win = window.open(pagename, '_blank');
            var win = window.open(pagename,'_self');
            win.focus();
        }
        function lkEditclick(id, type){
           
            var a="";
            var pagename="ModifyQuotation.aspx?returnurl=";
            var Curr=type;
            $.ajax({
                type: "POST",
                url: "ItemcontrolService.asmx/DoubleEncrypt",
                //data: '{id: ' + id + '}',
                data: '{id: ' + id + ', type: "'+ Curr + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(response){
                    a=response.d;
                },
                async: false
            });
            a=a.split(",");
            pagename =  "../" + pagename+ a[1]+"&Id="+a[0]
           
            var win = window.open(pagename, '_self');   //'_blank');
            win.focus();
            //window.location.href="ModifyQuotation.aspx?chk=e&Id="+a;
        }     
        function lkPrintClick(id, type){
            debugger;
            var a="";
            var pagename="PrintDocs.aspx?tpy=Quotation&type=";
            var Curr=type;
            $.ajax({
                type: "POST",
                url: "ItemcontrolService.asmx/DoubleEncrypt",
                data: '{id: ' + id + ', type: "'+ Curr + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(response){
                    a=response.d;

                },
                async: false

            });
            a=a.split(",");
            pagename =  "../" + pagename+ a[1]+"&Id="+a[0]
           
            var win = window.open(pagename, '_blank');
            win.focus();
        }   
    </script>
    <script type="text/javascript">
        function AtLeastOneField_ClientValidate(sender, args) {
            var txt1 = document.getElementById("<%= txtQuotationDate.ClientID%>");
            //var txt2 = document.getElementById("<%= txtQuotationStatus.ClientID%>");
            var txt2 = document.getElementById("<%= ddstatus.ClientID%>");
            var txt3 = document.getElementById("<%= txtAccPros.ClientID%>");
            var txt4 = document.getElementById("<%= txtAmount.ClientID%>");
            var txt5 = document.getElementById("<%= txtAssignTo.ClientID%>");
            var txt6 = document.getElementById("<%= txtQuotationNo.ClientID%>");
            args.IsValid = (txt1.value != "" && txt1.value.length >= 3) || (txt2.value != "Select") || (txt3.value != "" && txt3.value.length >= 3) || (txt4.value != "" && txt4.value.length >= 3) || (txt5.value != "" && txt5.value.length >= 3) || (txt6.value != "" && txt6.value.length >= 3);
        }

        function ClearAllFunction() {
            var txt1 = document.getElementById("<%= txtQuotationDate.ClientID%>");
            var txt2 = document.getElementById("<%= ddstatus.ClientID%>");
            var txt3 = document.getElementById("<%= txtAccPros.ClientID%>");
            var txt4 = document.getElementById("<%= txtAmount.ClientID%>");
            var txt5 = document.getElementById("<%= txtAssignTo.ClientID%>");
            var txt6 = document.getElementById("<%= txtQuotationNo.ClientID%>");
            txt1.value = "";
            txt2.value = "Select";
            txt3.value = "";
            txt4.value = "";
            txt5.value = "";
            txt6.value = "";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hfassigntype" runat="server" />
    <asp:HiddenField ID="hfExcel" runat="server" />
    <asp:HiddenField ID="deletestatus" runat="server" />
    <asp:HiddenField ID="Hfgridview" runat="server" />
    <asp:HiddenField ID="hftotalrecord" runat="server" />
    <asp:HiddenField ID="hfsearch" runat="server" />
    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>--%>
    <div class="content-header">
        <div class="header-section">
            <h1>
                <i class="gi gi-parents" style="margin: -8px"></i>Quotation<br>
            </h1>
        </div>
    </div>
    <ul class="breadcrumb breadcrumb-top">
        <li><a href="index.aspx">Home</a></li>
        <li>Quotation</li>
    </ul>
    <div class="block full">
        <div class="block-title">
            <h2><strong>Quotation</strong> Detail</h2>
        </div>
        <div class="row">
            <asp:Panel runat="server" DefaultButton="btnsubmit">
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Quotation No</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtQuotationNo" runat="server" placeholder="Quotation No" data-toggle="tooltip" title="Quotation No"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Quotation Date</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtQuotationDate" runat="server" placeholder="Quotation Date" data-toggle="tooltip" title="Quotation Date" TextMode="Date"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Quotation Status</label>
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddstatus" runat="server" CssClass="form-control" title="Quotation Status">
                            <asp:ListItem Text="Select Status" Value="Select"></asp:ListItem>
                            <asp:ListItem Text="New" Value="New"></asp:ListItem>
                            <asp:ListItem Text="Negotiation/Review" Value="Negotiation/Review"></asp:ListItem>
                            <asp:ListItem Text="Repeated Order" Value="Repeated Order"></asp:ListItem>
                            <asp:ListItem Text="Closed Won" Value="Closed Won"></asp:ListItem>
                            <asp:ListItem Text="Closed Lost" Value="Closed Lost"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtQuotationStatus" runat="server" placeholder="Quotation Status" data-toggle="tooltip" title="Quotation Status" Visible="false"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both"></div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Account/Prospect</label>
                    <div class="col-md-8">
                        <%--<asp:DropDownList ID="ddlAccPros" runat="server" CssClass="form-control" title="Account/Prospect">
                        <asp:ListItem Text="Select Status" Value="Select"></asp:ListItem>
                        <asp:ListItem Text="Account" Value="Account"></asp:ListItem>
                        <asp:ListItem Text="Prospect" Value="Prospect"></asp:ListItem>
                    </asp:DropDownList>--%>
                        <asp:TextBox ID="txtAccPros" runat="server" placeholder="Account/Prospect" data-toggle="tooltip" title="Account/Prospect"
                            CssClass="form-control"></asp:TextBox>
                        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Atleast one field required" ValidationGroup="MasterGroupSearch"
                            CssClass="MasterValidationCSS" Display="Dynamic" OnServerValidate="AtLeastOneField_ServerValidate"
                            ClientValidationFunction="AtLeastOneField_ClientValidate" SetFocusOnError="true"></asp:CustomValidator>
                    </div>
                </div>
                <div class="col-md-4" style="display: none;">
                    <label class="col-md-4 control-label" for="example-hf-email">Amount</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtAmount" runat="server" placeholder="Amount" data-toggle="tooltip" title="Amount"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4" style="display: none;">
                    <label class="col-md-4 control-label" for="example-hf-email">Assign To</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtAssignTo" runat="server" placeholder="Assign To" data-toggle="tooltip" title="Assign To"
                            CssClass="form-control"></asp:TextBox>

                    </div>
                </div>
                <%--<div style="clear: both"></div>--%>
                <div class="col-sm-8 text-right">
                    <div class="col-md-12">
                        <asp:HyperLink ID="hlnkAdd" EnableViewState="false" runat="server" Text="ADD" CssClass="btn btn-alt btn-sm btn-primary"></asp:HyperLink>
                        <asp:Button ID="btnExport" runat="server" CssClass="btn btn-alt btn-sm btn-success " Text="Export to Excel" Visible="false" />
                        <button id="btnClearAll1" type="button" class="btn btn-sm btn-warning" style="margin-right: 10px;" onclick="ClearAllFunction()">Clear All</button>
                        <%--<asp:Button ID="btnClearAll" runat="server" Text="Clear All" class="btn btn-sm btn-warning" Style="margin-right: 10px;" />--%>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-sm btn-info pull-right" UseSubmitBehavior="false"
                            OnClientClick="if (!Page_ClientValidate('MasterGroupSearch')){ return false; } this.disabled = true; this.value = 'Searching...';"></asp:Button>
                    </div>
                </div>
            </asp:Panel>
        </div>
        <div class="row">

            <div class="col-sm-12 text-right">
                <%--<asp:HyperLink ID="hlnkAdd" EnableViewState="false" runat="server" Text="ADD" CssClass="btn btn-alt btn-sm btn-primary"></asp:HyperLink>
                <asp:Button ID="btnExport" runat="server" CssClass="btn btn-alt btn-sm btn-success " Text="Export to Excel" Visible="false" />--%>
                <%--<User:SearchBarByID ID="SearchControl" runat="server" />--%>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="table-responsive" runat="server" id="divMain" visible="false">

                    <div class="table-options clearfix" style="background-color: #f9fafc; padding: 8px 0 5px; width: auto; border: 1px solid #eaedf1;">

                        <div class="col-md-2">
                            <div>
                                <asp:DropDownList ID="ddpagesize" AutoPostBack="true" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                    <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-8">
                        </div>
                        <%--<div class="col-sm-3 pull-right input-group" style="padding-left: 15px; padding-right: 15px;">
                            <asp:TextBox runat="server" ID="txtSearch" class="form-control" placeholder="Search" OnTextChanged="Text_TextChanged"></asp:TextBox>
                            <span class="input-group-addon"><i class="fa fa-search"></i></span>
                        </div>--%>
                    </div>

                    <asp:UpdatePanel runat="server" ID="rpg">
                        <ContentTemplate>
                            <asp:Panel ID="Panel1" runat="server">
                                <%--  <asp:UpdatePanel runat="server" ID="rpg">
                    <ContentTemplate>--%>
                                <table id="printtable" class="table table-vcenter table-condensed table-bordered" style="margin-bottom: 0px;">
                                    <thead>
                                        <tr>
                                            <th id="thEdit" runat="server" class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Edit</th>
                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                <asp:LinkButton ID="Quotation_No" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Quotation No</asp:LinkButton>
                                            </th>
                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                <asp:LinkButton ID="Quotation_Date" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Quotation Date</asp:LinkButton>
                                            </th>
                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                <asp:LinkButton ID="Quotation_QuoStatus" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Quotation Status</asp:LinkButton>
                                            </th>
                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                <asp:LinkButton ID="Acc_name" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Account/Prospect</asp:LinkButton>

                                            </th>
                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                <asp:LinkButton ID="FinalAmount" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Amount</asp:LinkButton>

                                            </th>
                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                <asp:LinkButton ID="AssignTo" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>AssignTo</asp:LinkButton>

                                            </th>
                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;" id="th1" runat="server">View</th>
                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;" id="thEdit1" runat="server">Order</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rpgridview" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td id="tdEdit" runat="server" class="text-center">
                                                        <%-- <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# "ModifyQuotation.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Acc_Id").ToString()))%>'
                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>--%>
                                                        <asp:Label ID="lkedit" runat="server">
                                                        <a id="lkedit1" data-toggle="tooltip" title="Edit" class="btn btn-alt btn-xs btn-primary" onclick='lkEditclick(<%#Eval("Quotation_Id").ToString()%>,"<%#Request.Url.AbsoluteUri.ToString()%>")'><i class="fa fa-pencil"></i></a>
                                                        </asp:Label>
                                                    </td>
                                                    <td class="text-center">
                                                        <%--<asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "ViewAccount.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Acc_Id").ToString()))%>'
                                                    data-toggle="tooltip" title="View" runat="server">
                                                    <asp:Literal ID="lblcontact" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_Name")))%>' />
                                                </asp:HyperLink>--%>
                                                        <a id="lkView" data-toggle="tooltip" title="View" style='cursor: pointer;' onclick='lkviewclick(<%#Eval("Quotation_Id").ToString()%>,"<%#Eval("Quotation_Currency").ToString()%>")'>
                                                            <asp:Literal ID="lblcontact" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Quotation_No")))%>' />
                                                        </a>
                                                        <asp:Literal ID="lbluId" runat="server" Text='<%#(Eval("Quotation_Id"))%>' Visible="false" />
                                                        <asp:Literal runat="server" ID="lblChild" Text='<%#Eval("Quotation_isChild").ToString()%>' Visible="false" />
                                                    </td>

                                                    <td class="text-center">
                                                        <asp:Literal ID="lblname" runat="server" Text='<%#Eval("Quotation_Date")%>' /></td>
                                                    <td class="text-center">
                                                        <asp:Literal ID="lblphone" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Quotation_QuoStatus"))%>' /></td>
                                                    <td class="text-center">
                                                        <asp:Literal ID="lblemail" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_name"))%>' />
                                                        <asp:Literal runat="server" ID="lblAccId" Text='<%#Eval("Acc_id").ToString()%>' Visible="false" />
                                                    </td>
                                                    <td class="text-center">
                                                        <asp:Label ID="lblFinalAmount" runat="server" Text='<%#CDbl(Math.Round(Eval("FinalAmount"))).ToString("N2")%>' /></td>
                                                    <td class="text-center">
                                                        <asp:Label ID="lblassignto" runat="server" Text='<%#Eval("AssignTo")%>' /></td>
                                                    <%--<td class="text-center">
                                                <asp:Label ID="lblFor" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Reseller_Name"))%>' EnableViewState="false" />
                                            </td>--%>
                                                    <td class="text-center">
                                                        <a id="hplPrintInvoice" data-toggle="tooltip" title="Print Quotation" class="btn btn-alt" onclick='lkPrintClick(<%#Eval("Quotation_Id").ToString()%>,"<%#Eval("Quotation_Currency").ToString()%>")'>
                                                            <i class="fa fa-file"></i>
                                                        </a>
                                                        <%--<asp:HyperLink ID="HlReceipt2" EnableViewState="false" NavigateUrl='<%# "PrintDocs.aspx?tpy=Quotation&type=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Quotation_Currency").ToString())) + "&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Quotation_Id").ToString()))%>'
                                                    data-toggle="tooltip" title="Print Quotation" class="btn btn-xs btn-default" runat="server"  Target="_blank"><i class="fa fa-file"></i></asp:HyperLink>--%>
                                                    </td>
                                                    <td class="text-center">
                                                        <asp:LinkButton ID="lnkorder" data-toggle="tooltip" title="Click here to Create Order" class="btn-xs btn-success" runat="server"
                                                            OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Creating Order...';"
                                                            UseSubmitBehavior="false" CommandName="createorder" CommandArgument='<%#Eval("Quotation_Id").ToString()%>'><i class="fa fa-plus"></i></asp:LinkButton>
                                                        <a id="vieworder" runat="server" class="btn-xs btn-warning" title="View Order" target="_blank"><i class="fa fa-eye"></i></a>

                                                    </td>
                                                    <%--<td class="text-center" id="tdEdit" runat="server" visible="false">
                                                <a id="lkedit" data-toggle="tooltip" title="Edit" class="btn btn-alt btn-xs btn-primary" href='<%#"ModifyAccount.aspx?chk=e&ID=" + HttpUtility.UrlEncode(Security.Encrypt( Eval("Acc_Id").ToString()))%>'><i class="fa fa-pencil"></i></a>&nbsp;
                                                <asp:LinkButton ID="btndelete" CommandName="Delete" Visible="false" CommandArgument='<%#Eval("Acc_Id")%>' OnClientClick="lkdeleteclick()" data-toggle="tooltip" title="Delete" class="btn btn-alt btn-xs btn-danger" runat="server"><i class="fa fa-times"></i></asp:LinkButton>
                                            </td>--%>
                                                </tr>

                                            </ItemTemplate>


                                            <FooterTemplate>
                                                <tr id="trEmpty" runat="server" visible="false">
                                                    <td class="dataTables_empty" style="width: 240px;">No matching records found.
                                                    </td>
                                                </tr>

                                            </FooterTemplate>
                                        </asp:Repeater>
                                        <asp:Label ID="Label1" runat="server" Text="No matching records found" Visible="false"></asp:Label>
                                        <tfoot style="display: none;">
                                            <tr>
                                                <th class="text-center"></th>
                                                <th class="text-center"><span class="filter_column filter_text">
                                                    <asp:TextBox ID="TextBox1" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="Company Name" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                                <th class="text-center"><span class="filter_column filter_text">
                                                    <asp:TextBox ID="TextBox2" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="Contact Person" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                                <th class="text-center"><span class="filter_column filter_text">
                                                    <asp:TextBox ID="TextBox3" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="Phone" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                                <th class="text-center"><span class="filter_column filter_text">
                                                    <asp:TextBox ID="TextBox4" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="Email" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                                <th class="text-center"><span class="filter_column filter_text">
                                                    <asp:TextBox ID="TextBox5" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="Mobile" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                                <th class="text-center"><span class="filter_column filter_text">
                                                    <asp:TextBox ID="TextBox6" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="City" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                                <th class="text-center"><span class="filter_column filter_text">
                                                    <asp:TextBox ID="TextBox9" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="Type" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                                <th class="text-center"><span class="filter_column filter_text">
                                                    <asp:TextBox ID="TextBox7" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="Assign To" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                                <th class="text-center" style="display: none;"><span class="filter_column filter_text">
                                                    <asp:TextBox ID="TextBox10" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="For" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                                <th class="text-center"><span class="filter_column filter_text">
                                                    <asp:TextBox ID="TextBox8" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="From" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>

                                                <th class="text-center"><span class="filter_column filter_text"></span></th>
                                                <%--  <th class="text-center"><span class="filter_column filter_text">
                                           </span></th>
                                      <th class="text-center"><span class="filter_column filter_text">
                                           </span></th>--%>
                                            </tr>
                                        </tfoot>


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
                        </ContentTemplate>
                        <Triggers>
                            <%--<asp:AsyncPostBackTrigger ControlID="rpgridview" />
                      <asp:AsyncPostBackTrigger ControlID="rptPaging" />--%>
                            <%-- <asp:AsyncPostBackTrigger ControlID="rptPaging"  EventName="rptPaging_ItemCommand"/>--%>
                        </Triggers>

                    </asp:UpdatePanel>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="rpgridview" />
                <%--<asp:PostBackTrigger ControlID="btnsave" />--%>
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <br />
            <div class="divWaiting">
                <i class="fa fa-sun-o fa-spin" id="LoadingUpadatePanel"></i>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

