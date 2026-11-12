<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="QuotationResponseNew.aspx.vb" Inherits="QuotationResponseNew" %>

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
            var txt2 = document.getElementById("<%= txtVendorName.ClientID%>");
            var txt3 = document.getElementById("<%= txtItem.ClientID%>");
            var txt4 = document.getElementById("<%= txtQuantity.ClientID%>");
            var txt5 = document.getElementById("<%= txtAmount.ClientID%>");
            var txt6 = document.getElementById("<%= txtPerUnit.ClientID%>");
            var txt7 = document.getElementById("<%= txtTax.ClientID%>");
            var txt8 = document.getElementById("<%= txtFreight.ClientID%>");
            var txt9 = document.getElementById("<%= txtTotal.ClientID%>");
            //var txt10 = document.getElementById("<%= txtStatus.ClientID%>");
            var txt10 = document.getElementById("<%= ddlStatus.ClientID%>");
            args.IsValid = (txt1.value != "" && txt1.value.length >= 3) || (txt2.value != "" && txt2.value.length >= 3) || (txt3.value != "" && txt3.value.length >= 3) || (txt4.value != "" && txt4.value.length >= 3) || (txt5.value != "" && txt5.value.length >= 3) || (txt6.value != "" && txt6.value.length >= 3) || (txt7.value != "" && txt7.value.length >= 3) || (txt8.value != "" && txt8.value.length >= 3) || (txt9.value != "" && txt9.value.length >= 3) || (txt10.value != "Select");
        }

        function ClearAllFunction() {
            var txt1 = document.getElementById("<%= txtQRNO.ClientID%>");
            var txt2 = document.getElementById("<%= txtVendorName.ClientID%>");
            var txt3 = document.getElementById("<%= txtItem.ClientID%>");
            var txt4 = document.getElementById("<%= txtQuantity.ClientID%>");
            var txt5 = document.getElementById("<%= txtAmount.ClientID%>");
            var txt6 = document.getElementById("<%= txtPerUnit.ClientID%>");
            var txt7 = document.getElementById("<%= txtTax.ClientID%>");
            var txt8 = document.getElementById("<%= txtFreight.ClientID%>");
            var txt9 = document.getElementById("<%= txtTotal.ClientID%>");
            var txt10 = document.getElementById("<%= ddlStatus.ClientID%>");
            txt1.value = "";
            txt2.value = "";
            txt3.value = "";
            txt4.value = "";
            txt5.value = "";
            txt6.value = "";
            txt7.value = "";
            txt8.value = "";
            txt9.value = "";
            txt10.value = "Select";
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
                    <label class="col-md-4 control-label" for="example-hf-email">Vendor-Name</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtVendorName" runat="server" placeholder="Vendor-Name" data-toggle="tooltip" title="Vendor-Name"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Item</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtItem" runat="server" placeholder="Item" data-toggle="tooltip" title="Item"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both"></div>


                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Quantity</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtQuantity" runat="server" placeholder="Quantity" data-toggle="tooltip" title="Quantity"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Amount</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtAmount" runat="server" placeholder="Amount" data-toggle="tooltip" title="Amount"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Per-Unit</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtPerUnit" runat="server" placeholder="Per-Unit" data-toggle="tooltip" title="Per-Unit"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both"></div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Tax</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtTax" runat="server" placeholder="Tax" data-toggle="tooltip" title="Tax"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Freight</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtFreight" runat="server" placeholder="Freight" data-toggle="tooltip" title="Freight"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Total</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtTotal" runat="server" placeholder="Total" data-toggle="tooltip" title="Total"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both"></div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Status</label>
                    <div class="col-md-8">
                        <asp:DropDownList runat="server" ID="ddlStatus" CssClass="form-control">
                            <asp:ListItem Value="Select" Text="Select Status"></asp:ListItem>
                            <asp:ListItem Value="Pending" Text="Pending"></asp:ListItem>
                            <asp:ListItem Value="Approved" Text="Approved"></asp:ListItem>
                            <asp:ListItem Value="Rejected" Text="Rejected"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtStatus" runat="server" placeholder="Status" data-toggle="tooltip" title="Status" Visible="false"
                            CssClass="form-control"></asp:TextBox>
                        <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="Atleast one field required" ValidationGroup="MasterGroupSearch"
                            CssClass="MasterValidationCSS" Display="Dynamic" OnServerValidate="AtLeastOneField_ServerValidate"
                            ClientValidationFunction="AtLeastOneField_ClientValidate" SetFocusOnError="true"></asp:CustomValidator>
                    </div>
                </div>
                <div class="col-sm-8 text-right">
                    <div class="col-md-12">
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
                <asp:HyperLink ID="hlnkAdd" Visible="false" runat="server" Text="ADD" CssClass="btn btn-alt btn-sm btn-primary"></asp:HyperLink>
                <%--<asp:Button ID="lkadd" EnableViewState="false" runat="server" Text="Quick Add" CssClass="btn btn-alt btn-sm btn-primary"></asp:Button>--%>
                <asp:Button ID="btnExport" runat="server" CssClass="btn btn-alt btn-sm btn-success " CausesValidation="false" Text="Export to Excel" Visible="false" />
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
                                                    <asp:LinkButton ID="Vendor_Name" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Vendor-Name</asp:LinkButton>
                                                </th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                    <asp:LinkButton ID="Rm_Name" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Item</asp:LinkButton>
                                                </th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                    <asp:LinkButton ID="Quantity" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Quantity</asp:LinkButton>

                                                </th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                    <asp:LinkButton ID="Amount" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Amount</asp:LinkButton>

                                                </th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                    <asp:LinkButton ID="Per_Unit" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Per-Unit</asp:LinkButton>

                                                </th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                    <asp:LinkButton ID="Tax" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Tax</asp:LinkButton>

                                                </th>

                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                    <asp:LinkButton ID="Freight" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Freight</asp:LinkButton>
                                                </th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                    <asp:LinkButton ID="Total" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Total</asp:LinkButton>
                                                </th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                    <asp:LinkButton ID="QuotationResponse_Status" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Status</asp:LinkButton>
                                                </th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;" id="thEdit1" runat="server">Edit</th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;" id="thAction" runat="server">Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rpgridview" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td id="tdEdit" runat="server" class="text-center">
                                                            <asp:HyperLink ID="hpsponsor" EnableViewState="false" NavigateUrl='<%# "ViewQuotationResponse.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("QuotationRequest_ID").ToString())) & "&VId=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Vendor_Id").ToString()))%>'
                                                                data-toggle="tooltip" title="View" runat="server">
                                                                <asp:Literal ID="LblR" runat="server" Text='<%#Eval("QuotationRequest_ID")%>' Visible="false" />
                                                                <asp:Literal ID="LblV" runat="server" Text='<%#Eval("Vendor_Id")%>' Visible="false" />
                                                                <asp:Literal ID="lblid" runat="server" Text='<%#Eval("QuotationRequest_No")%>' Visible="false" />
                                                                <asp:Literal ID="lblQRNo" runat="server" Text='<%#Eval("QuotationRequest_No")%>' />
                                                            </asp:HyperLink>
                                                            <%--<a id="lkedit" data-toggle="tooltip" title="Edit" class="btn btn-alt btn-xs btn-primary" onclick='lkEditclick(<%#Eval("Acc_Id").ToString()%>)'><i class="fa fa-pencil"></i></a>--%>
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Literal ID="lblVendorName" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Vendor_Name"))%>' />
                                                            <asp:Literal ID="ltname" runat="server" Visible="false" Text='<%#(Eval("Vendor_Name"))%>'></asp:Literal>

                                                            <asp:Literal ID="LblResponse_ID" runat="server" Text='<%#Eval("QuotationResponse_ID")%>' Visible="false" />
                                                        </td>

                                                        <td class="text-center">
                                                            <asp:Literal ID="lblRMName" runat="server" Text='<%# DynamicparcelDataManipulation.FixNullFromDB(Eval("Rm_Name"))%>' />
                                                            <asp:Literal ID="lblRMID" runat="server" Text='<%#Eval("Rm_ID")%>' Visible="false" />
                                                            <asp:Literal ID="lblQResponse_Code" runat="server" Text='<%#Eval("QuotationResponse_Code")%>' Visible="false" />
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Literal ID="lblQty" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Quantity"))%>' />
                                                            <asp:Literal ID="lblQty1" runat="server" Text='<%#Eval("Quantity")%>' Visible="false" />
                                                        </td>
                                                        <td class="text-center">
                                                            <i class="fa fa-inr "></i>&nbsp;
                                                            <asp:Literal ID="lblAmount" runat="server" Text='<%#Convert.ToDouble(Eval("Amount")).ToString("#,##0.00")%>' />
                                                            <asp:Literal ID="lblAmount1" runat="server" Text='<%#Eval("Amount")%>' Visible="false" />
                                                        </td>
                                                        <td class="text-center">
                                                            <i class="fa fa-inr "></i>&nbsp;
                                                            <asp:Literal ID="lblPerUnit" runat="server" Text='<%#Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(Eval("Per_Unit"))).ToString("#,##0.00")%>' />
                                                            <asp:Literal ID="lblPerUnit1" runat="server" Text='<%#Eval("Per_Unit")%>' Visible="false" />
                                                        </td>
                                                        <td class="text-center">
                                                            <i class="fa fa-inr "></i>&nbsp;
                                                            <asp:Literal ID="lblTax" runat="server" Text='<%#Convert.ToDouble(Eval("Tax")).ToString("#,##0.00")%>' />
                                                            <asp:Literal ID="lblTax1" runat="server" Text='<%#Eval("Tax")%>' Visible="false" />
                                                        </td>
                                                        <td class="text-center">
                                                            <i class="fa fa-inr "></i>&nbsp;
                                                            <asp:Literal ID="lblFreight" runat="server" Text='<%#Convert.ToDouble(Eval("Freight")).ToString("#,##0.00")%>' />
                                                            <asp:Literal ID="lblFreight1" runat="server" Text='<%#Eval("Freight")%>' Visible="false" />
                                                        </td>
                                                        <td class="text-center">
                                                            <i class="fa fa-inr "></i>&nbsp;
                                                            <asp:Literal ID="lblTotal" runat="server" Text='<%#Convert.ToDouble(Eval("Total")).ToString("#,##0.00")%>' />
                                                            <asp:Literal ID="lblTotal1" runat="server" Text='<%#Eval("Total")%>' Visible="false" />
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Literal ID="lblStatus" runat="server" Text='<%#Eval("QuotationResponse_Status")%>' />
                                                            <asp:Literal ID="lblstatus1" runat="server" Text='<%#(Eval("QuotationResponse_Status"))%>' Visible="false" />
                                                        </td>
                                                        <td class="text-center">
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:HyperLink ID="hledit" EnableViewState="false" NavigateUrl='<%# "AddQuotationResponse.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("QuotationRequest_ID").ToString())) & "&VId=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Vendor_Id").ToString()))%>'
                                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                                            </div>
                                                        </td>
                                                        <td class="text-center">
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:LinkButton ID="lnkApproved" data-toggle="tooltip" title="Approved" class="btn btn-success" runat="server"
                                                                    CommandName="Approvedink" CommandArgument='<%#Eval("QuotationRequest_ID").ToString() + ","+Eval("Vendor_Id").ToString() %>'>Approve</asp:LinkButton>
                                                                <asp:LinkButton ID="lnkPO" data-toggle="tooltip" title="Create PO" class="btn btn-warning" runat="server" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Creating PO...';"
                                                                    CommandName="createPO" CommandArgument='<%#Eval("QuotationRequest_ID").ToString() + ","+Eval("Vendor_Id").ToString() %>'>Create PO</asp:LinkButton>
                                                                <a id="LnkViewPO" runat="server" data-toggle="tooltip" title="View PO" class="btn btn-alt btn-xs btn-success" href='<%#"Purchaseorder.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("QuotationRequest_ID").ToString)) + "&VId=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Vendor_Id").ToString))%>' target="_blank"><i class="fa fa-print"></i>&nbsp;View PO</a>
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

