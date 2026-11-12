<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="QuotationRequestNew.aspx.vb" Inherits="QuotationRequestNew" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
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

    <script type="text/javascript">
        function lkviewclick(id){       
           
            var a="";
            // var id= "321";
            // var c = +Prodname;
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
         
            window.location.href="Viewprospect.aspx?Id="+a;
        }
        function lkEditclick(id, ProdName){
           
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
         
            window.location.href="ModifyProspect.aspx?chk=e&Id="+a;
        }        
    </script>
    <script type="text/javascript">
        function AtLeastOneField_ClientValidate(sender, args) {
            var txt1 = document.getElementById("<%= txtQRNO.ClientID%>");
            var txt2 = document.getElementById("<%= txtQuotationDate.ClientID%>");
            //var txt3 = document.getElementById("<%= txtQRGodown.ClientID%>");
            var txt3 = document.getElementById("<%= ddlGodown.ClientID%>");
            var txt4 = document.getElementById("<%= txtQRItem.ClientID%>");
            var txt5 = document.getElementById("<%= txtQRQuantity.ClientID%>");
            args.IsValid = (txt1.value != "" && txt1.value.length >= 3) || (txt2.value != "" && txt2.value.length >= 3) || (txt3.value != "0") || (txt4.value != "" && txt4.value.length >= 3) || (txt5.value != "" && txt5.value.length >= 3);
        }

        function ClearAllFunction() {
            var txt1 = document.getElementById("<%= txtQRNO.ClientID%>");
            var txt2 = document.getElementById("<%= txtQuotationDate.ClientID%>");
            var txt3 = document.getElementById("<%= ddlGodown.ClientID%>");
            var txt4 = document.getElementById("<%= txtQRItem.ClientID%>");
            var txt5 = document.getElementById("<%= txtQRQuantity.ClientID%>");
            txt1.value = "";
            txt2.value = "";
            txt3.value = "0";
            txt4.value = "";
            txt5.value = "";
          
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hfExcel" runat="server" />
    <asp:HiddenField ID="deletestatus" runat="server" />
    <asp:HiddenField ID="Hfgridview" runat="server" />
    <asp:HiddenField ID="hftotalrecord" runat="server" />
    <asp:HiddenField ID="hfsearch" runat="server" />
    <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>--%>
    <div class="content-header">
        <div class="header-section">
            <h1>
                <i class="gi gi-parents" style="margin: -8px"></i>Quotation Response<br>
            </h1>
        </div>
    </div>
    <ul class="breadcrumb breadcrumb-top">
        <li><a href="index.aspx">Home</a></li>
        <li>Quotation Response</li>
    </ul>
    <div class="block">
        <div class="block-title">
            <h2><strong>Quotation Response</strong> Detail</h2>
        </div>
        <div class="row">
            <asp:Panel runat="server" DefaultButton="btnsubmit">
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">QR-NO</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtQRNO" runat="server" placeholder="QR-NO" data-toggle="tooltip" title="QR-NO"
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
                    <label class="col-md-4 control-label" for="example-hf-email">QR-Godown</label>
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddlGodown" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:TextBox ID="txtQRGodown" runat="server" placeholder="QR-Godown" data-toggle="tooltip" title="QR-Godown" Visible="false" 
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both"></div>


                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">QR-Item</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtQRItem" runat="server" placeholder="QR-Item" data-toggle="tooltip" title="QR-Item"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">QR-Quantity</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtQRQuantity" runat="server" placeholder="QR-Quantity" data-toggle="tooltip" title="QR-Quantity"
                            CssClass="form-control"></asp:TextBox>
                         <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Atleast one field required" ValidationGroup="MasterGroupSearch"
                            CssClass="MasterValidationCSS" Display="Dynamic" OnServerValidate="AtLeastOneField_ServerValidate"
                            ClientValidationFunction="AtLeastOneField_ClientValidate" SetFocusOnError="true"></asp:CustomValidator>
                    </div>
                </div>

                <div class="col-sm-4 text-right">
                    <div class="col-md-12">
                        <asp:HyperLink ID="hlnkAdd" Visible="false" runat="server" Text="ADD" CssClass="btn btn-alt btn-sm btn-primary"></asp:HyperLink>
                        <asp:Button ID="btnExport" runat="server" CssClass="btn btn-alt btn-sm btn-success " CausesValidation="false" Text="Export to Excel" Visible="false" />
                        <button id="btnClearAll1" type="button" class="btn btn-sm btn-warning" style="margin-right: 10px;" onclick="ClearAllFunction()">Clear All</button>
                        <%--<asp:Button ID="btnClearAll" runat="server" Text="Clear All" class="btn btn-sm btn-warning" Style="margin-right: 10px;" />--%>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-sm btn-info pull-right" UseSubmitBehavior="false"
                            OnClientClick="if (!Page_ClientValidate('MasterGroupSearch')){ return false; } this.disabled = true; this.value = 'Searching...';"></asp:Button>
                    </div>
                </div>
            </asp:Panel>
        </div>
        <%--Search User Control Start--%>
        <div class="row">

            <div class="col-sm-12 text-right">
                <%--<asp:HyperLink ID="hlnkAdd" Visible="false" runat="server" Text="ADD" CssClass="btn btn-alt btn-sm btn-primary"></asp:HyperLink>--%>
                <%--<asp:Button ID="lkadd" EnableViewState="false" runat="server" Text="Quick Add" CssClass="btn btn-alt btn-sm btn-primary"></asp:Button>--%>
                <%--<asp:Button ID="btnExport" runat="server" CssClass="btn btn-alt btn-sm btn-success " CausesValidation="false" Text="Export to Excel" Visible="false" />--%>
            </div>
        </div>
        <%--Search User Control End--%>
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
                <div class="col-sm-3 pull-right input-group" style="padding-left: 15px; padding-right: 15px;">
                    <asp:TextBox runat="server" ID="txtSearch" class="form-control" placeholder="Search" OnTextChanged="Text_TextChanged"></asp:TextBox>
                    <span class="input-group-addon"><i class="fa fa-search"></i></span>
                </div>

            </div>
            <%--Search User Control End--%>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:HiddenField ID="hfcheck" runat="server" />
                    <asp:HiddenField ID="hfchanged" runat="server" />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="hfquery" runat="server" />
                    <asp:HiddenField ID="hfmodule" runat="server" />
                    <asp:HiddenField ID="hftopquery" runat="server" />
                    <asp:HiddenField ID="hftopquerycheck" runat="server" />
                    <asp:HiddenField ID="hfReport_Type" runat="server" />
                    <asp:HiddenField ID="Hfsearchcheck" runat="server" />
                    <asp:HiddenField ID="hfsearchquery" runat="server" />
                    <div class="table-responsive">
                        <asp:UpdatePanel runat="server" ID="rpg">
                            <ContentTemplate>
                                <asp:Panel ID="Panel1" runat="server">
                                    <table id="printtable" class="table table-vcenter table-condensed table-bordered" style="margin-bottom: 0px;">
                                        <thead>
                                            <tr>
                                                <%--<th id="thEdit" runat="server" class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Edit</th>--%>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                    <asp:LinkButton ID="QuotationRequest_No" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>QR-NO</asp:LinkButton>
                                                </th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                    <asp:LinkButton ID="QuotationRequest_Date" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Quotation Date</asp:LinkButton>
                                                </th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                    <asp:LinkButton ID="Godown_Name" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>QR-Godown</asp:LinkButton>
                                                </th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                    <asp:LinkButton ID="Rm_Name" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>QR-Item</asp:LinkButton>

                                                </th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                    <asp:LinkButton ID="QRRawMaterial_Quantity" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>QR-Quantity</asp:LinkButton>

                                                </th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;" id="thEdit1" runat="server">Email</th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;" id="thAction" runat="server">View</th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;" id="th1" runat="server">Submit Quotation</th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;" id="th2" runat="server">Edit</th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;" id="th3" runat="server">Delete</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rpgridview" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:HyperLink ID="hpsponsor" EnableViewState="false" NavigateUrl='<%# "ModifyQuotationrequest.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("QuotationRequest_ID").ToString()))%>'
                                                                data-toggle="tooltip" title="View" runat="server">
                                                                <asp:Literal ID="lblid" runat="server" Text='<%#Eval("QuotationRequest_ID")%>' Visible="false" />
                                                                <asp:Literal ID="lblname" runat="server" Text='<%#Eval("QuotationRequest_No")%>' />
                                                            </asp:HyperLink>
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Literal ID="lbldate" runat="server" Text='<%#Eval("QuotationRequest_Date")%>' />
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Literal ID="lblname1" runat="server" Text='<%#Eval("Godown_Name")%>' />
                                                            <asp:Literal ID="ltname" runat="server" Visible="false" Text='<%#(Eval("Godown_Name"))%>'></asp:Literal>
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Literal ID="lblRawMaterial" runat="server" Text='<%#Eval("Rm_Name")%>' />
                                                            <asp:Literal ID="ltRawMaterial" runat="server" Visible="false" Text='<%#(Eval("Rm_Name"))%>'></asp:Literal>
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Literal ID="lblQuantity" runat="server" Text='<%# Eval("QRRawMaterial_Quantity").ToString + " " + Eval("QRRawMaterial_Unit").ToString%>' />
                                                            <asp:Literal ID="ltQuantity" runat="server" Visible="false" Text='<%#(Eval("QRRawMaterial_Quantity"))%>'></asp:Literal>
                                                        </td>
                                                        <td class="text-center">
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:LinkButton ID="lnkemail" data-toggle="tooltip" title="Send Email" class="btn btn-success" runat="server"
                                                                    CommandName="emailpopup" CommandArgument='<%#Eval("QuotationRequest_ID").ToString()%>'><i class="fa fa-envelope"></i></asp:LinkButton>
                                                            </div>
                                                        </td>
                                                        <td class="text-center">
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:HyperLink ID="hlview" EnableViewState="false" NavigateUrl='<%# "QuotationResponse.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("QuotationRequest_ID").ToString()))%>'
                                                                    data-toggle="tooltip" title="View" class="btn btn-default" runat="server"><i class="fa fa-eye "></i></asp:HyperLink>
                                                            </div>
                                                        </td>
                                                        <td class="text-center">
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:HyperLink ID="hladdresponse" EnableViewState="false" NavigateUrl='<%# "AddQuotationResponse.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("QuotationRequest_ID").ToString()))  & "&VId=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y"%>'
                                                                    data-toggle="tooltip" title="Submit Quotation" class="btn btn-default" runat="server"><i class="gi gi-edit"></i></asp:HyperLink>
                                                            </div>
                                                        </td>
                                                        <td class="text-center">
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:HyperLink ID="hledit" EnableViewState="false" NavigateUrl='<%# "ModifyQuotationrequest.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("QuotationRequest_ID").ToString()))%>'
                                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                                            </div>
                                                        </td>
                                                        <td class="text-center">
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="lkdeleteclick();"
                                                                    CommandName="deletelink" CommandArgument='<%#Eval("QuotationRequest_ID")%>'><i class="fa fa-times"></i></asp:LinkButton>
                                                            </div>
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
                                                </tr>
                                            </tfoot>


                                        </tbody>

                                    </table>
                                    <asp:HiddenField ID="hfBackcount" runat="server" />
                                    <asp:HiddenField ID="tab" runat="server" />
                                    <div class="row" style="margin: 0px;">
                                        <div class="col-md-12" style="background-color: #f9fafc; padding: 10px 0; border: 1px solid #eaedf1; border-top-width: 0;">
                                            <div class="col-sm-5 hidden-xs">
                                                <div class="dataTables_info" role="status" aria-live="polite">
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

                                    <%-- Pop-Up Start --%>
                                    <asp:LinkButton ID="btnShow" runat="server" />
                                    <asp:ModalPopupExtender ID="mpe" runat="server" BehaviorID="mpe" PopupControlID="pnlPopup" TargetControlID="btnShow"
                                        CancelControlID="btnNo">
                                    </asp:ModalPopupExtender>
                                    <%-- <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Always"  >
                            <ContentTemplate>--%>
                                    <asp:Panel ID="pnlPopup" runat="server" Style="display: none" CssClass="animation-slideDown">
                                        <%--<asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>--%>

                                        <div id="modal-large" class="modal-dialog" tabindex="-1" role="dialog" aria-hidden="true">

                                            <%--class="modal-dialog"--%>
                                            <div class="modal-content">

                                                <div class="modal-header">
                                                    <button type="button" class="close" id="btnNo" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                    <h3 class="modal-title" style="float: left; padding-right: 300px;">Vendor Details</h3>
                                                    <asp:Button ID="btnsendall" runat="server" CssClass="btn btn-xs btn-success" Text="Send all" float="right" />
                                                </div>
                                                <div class="modal-body">
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="grdvendoremail" ShowFooter="true" GridLines="None" CssClass="table table-striped table-vcenter" HeaderStyle-Width="100"
                                                            HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Smaller" CellPadding="0" CellSpacing="0" runat="server" AutoGenerateColumns="false">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Vendor Name" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                                    <HeaderTemplate>
                                                                        <asp:HyperLink ID="HyperLink11" runat="server">Vendor Name</asp:HyperLink>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="ltvendorname" runat="server" Text='<%#Eval("Vendor_Name")%>'></asp:Label>
                                                                        <asp:Label ID="ltvendorid" runat="server" Text='<%#Eval("Vendor_ID")%>' Visible="false"></asp:Label>
                                                                        <asp:Label ID="ltitemid" runat="server" Text='<%#Eval("ItemDt_ID")%>' Visible="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Contact Person" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                                    <HeaderTemplate>
                                                                        <asp:HyperLink ID="HyperLink12" runat="server">Contact Person</asp:HyperLink>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="ltcntactprsn" runat="server" Text='<%#Eval("Contact_ContactPerson")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="EmailId" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                                    <HeaderTemplate>
                                                                        <asp:HyperLink ID="HyperLink13" runat="server">EmailId</asp:HyperLink>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="ltemail" runat="server" Text='<%#Eval("Contact_Email")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Mobile" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                                    <HeaderTemplate>
                                                                        <asp:HyperLink ID="HyperLink13" runat="server">Mobile</asp:HyperLink>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("Contact_Mobile")%>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Sent Email" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                                    <HeaderTemplate>
                                                                        <asp:HyperLink ID="HyperLink13" runat="server">Sent Email</asp:HyperLink>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblsent" runat="server" EnableViewState="false" Visible="false"><i class="fa fa-check fa-2x text-success "></i></asp:Label>
                                                                        <asp:Label ID="lblnotsent" runat="server" EnableViewState="false" Visible="false"><i class="gi gi-remove_2 fa-2x  text-danger "></i></asp:Label>
                                                                        <asp:Label ID="lblemailstatus" runat="server" Text='<%#Eval("QRVendor_Email")%>' EnableViewState="false" Visible="false" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                                    <HeaderTemplate>
                                                                        <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <div class="btn-group btn-group-xs">
                                                                            <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Send Email" class="btn btn-xs btn-success" runat="server"
                                                                                CommandName="sendmail" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>">Send</asp:LinkButton>
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

                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <%-- Pop-Up End --%>
                                </asp:Panel>

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="rpgridview" />
                                <%--<asp:AsyncPostBackTrigger ControlID="rpgridview" />
                      <asp:AsyncPostBackTrigger ControlID="rptPaging" />--%>
                                <%-- <asp:AsyncPostBackTrigger ControlID="rptPaging"  EventName="rptPaging_ItemCommand"/>--%>
                            </Triggers>

                        </asp:UpdatePanel>
                    </div>

                </ContentTemplate>
                <Triggers>
                    <%--<asp:AsyncPostBackTrigger ControlID="GridView1" />--%>
                    <%--<asp:PostBackTrigger ControlID="btnsave" />--%>
                    <%--<asp:AsyncPostBackTrigger ControlID="btnadd" />--%>
                    <%--<asp:AsyncPostBackTrigger ControlID ="btnshowall" />--%>
                    <%--<asp:PostBackTrigger ControlID ="btnExportExcel" />--%>
                </Triggers>
            </asp:UpdatePanel>
        </div>
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

