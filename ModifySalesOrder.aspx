<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" EnableEventValidation="false" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="ModifySalesOrder.aspx.vb" Inherits="ModifySalesOrder" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .text-left {
            text-align: left !important;
        }

        .pd-b-10 {
            padding-bottom: 17px;
        }

        .f-size-10 {
            font-size: 10px;
        }

        .select2 {
            width: 100% !important;
        }

        @media only screen and (max-width: 1024px) and (min-width: 768px) {
  .modal .close,
  .modal .btn-close {
    position: absolute;
    top: 10px;
    right: 15px;
    z-index: 9999;
    display: block !important;
  }
}
.modal {
  overflow-y: auto !important;
}
             /*  .billed-from-dropdown .chosen-container,
.shipped-from-dropdown .chosen-container {
    width: 82% !important;
}*/
    </style>
    <script src="js/jquery.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-beta.1/dist/css/select2.min.css" rel="stylesheet" />
    <%--<script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-beta.1/dist/js/select2.min.js"></script>--%>
    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.8/js/select2.min.js" defer></script>--%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.8/js/select2.full.min.js" defer></script>
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
        function calculateFinalPrice(txtquantity, hfkg) {
            debugger;
            var type = document.getElementById('<%=qtntype.ClientID%>').value
            var hfPacking_Weight = document.getElementById(txtquantity.id.replace('txtquantity', 'hfPacking_Weight'))
            var ltrate = document.getElementById(txtquantity.id.replace('txtquantity', 'ltrate'))
            var lblvat = document.getElementById(txtquantity.id.replace('txtquantity', 'lblvat'))
            var lblvatinrs = document.getElementById(txtquantity.id.replace('txtquantity', 'lblvatinrs'))
            var ltamount = document.getElementById(txtquantity.id.replace('txtquantity', 'ltamount'))
            var ltkg = document.getElementById(txtquantity.id.replace('txtquantity', 'ltkg'))
            var hfltamount = document.getElementById(txtquantity.id.replace('txtquantity', 'hfltamount'))
            var hflblvatinrs = document.getElementById(txtquantity.id.replace('txtquantity', 'hflblvatinrs'))

            ltkg.textContent = parseFloat(hfPacking_Weight.value * txtquantity.value).toFixed(2)
            var amount = 0
            var vatinr = 0
            amount = parseFloat(ltrate.textContent.replace(/,/g, '')) * parseFloat(ltkg.textContent.replace(/,/g, ''));
            if (type == "Domestic") {
                vatinr = amount * parseFloat(lblvat.textContent.replace(/,/g, '')) / 100;
                //hflblvatinrs.value = Math.round(vatinr);
                //lblvatinrs.textContent = Math.round(vatinr).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
                hflblvatinrs.value = (vatinr);
                lblvatinrs.textContent = (vatinr).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');



            }
            else {
                vatinr = 0;
                hflblvatinrs.value = 0;
            }
            hfltamount.value = Math.round(amount);

            ltamount.textContent = Math.round(parseFloat(ltrate.textContent.replace(/,/g, '')) * parseFloat(ltkg.textContent.replace(/,/g, ''))).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');

            Read_Data();
        }

        function Read_Data() {
            ; debugger
            var total = 0;
            var vat = 0;
            var grandtoatal = 0;
            var totalkg = 0;
            var Grid_Table = document.getElementById('<%= grditemproduct.ClientID%>');

            var type = document.getElementById('<%=qtntype.ClientID%>').value


            var Freight = document.getElementById('<%= txtfreight.ClientID %>');
            if (type == "Domestic") {
                for (var row = 1; row < Grid_Table.rows.length - 1; row++) {

                    vat = parseFloat(vat) + parseFloat(Grid_Table.rows[row].cells[6].textContent.split("(")[0].replace(/[^0-9.]/g, ""));
                    total = parseFloat(total) + parseFloat(Grid_Table.rows[row].cells[8].textContent.replace(/[^0-9.]/g, ""));
                    totalkg = parseFloat(totalkg) + parseFloat(Grid_Table.rows[row].cells[7].textContent.replace(/[^0-9.]/g, ""));
                }
                if (!Freight.value.length > 0) {
                    Freight.value = 0;
                }

                var Freighttaxper = '<%= System.Configuration.ConfigurationManager.AppSettings("freightvalue").ToString()%>';
                var FreightAmt = parseFloat(Freight.value) * Freighttaxper / 100;
                grandtoatal = vat + total + parseFloat(Freight.value) + parseFloat(FreightAmt)
                Grid_Table.rows[row].cells[6].innerHTML = "<b>" + totalkg + " Kg</b>";
                //Grid_Table.rows[row].cells[8].innerHTML = "<b><i class='fa fa-rupee'></i> " + Math.round(vat + parseFloat(FreightAmt)).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') + "</b>" + "<hr style='border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;'>" + "<b><i class='fa fa-rupee'></i> " + parseFloat(Freight.value).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') + "</b>" + "<hr style='border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;'>" + "<b><i class='fa fa-rupee'></i> " + Math.round(grandtoatal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') + "</b>";***********MUBYN
                Grid_Table.rows[row].cells[8].innerHTML = "<b><i class='fa fa-rupee'></i> " + (vat + parseFloat(FreightAmt)).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') + "</b>" + "<hr style='border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;'>" + "<b><i class='fa fa-rupee'></i> " + parseFloat(Freight.value).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') + "</b>" + "<hr style='border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;'>" + "<b><i class='fa fa-rupee'></i> " + Math.round(grandtoatal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') + "</b>";
                document.getElementById('<%=hftotalvat.ClientID%>').value = vat;
                document.getElementById('<%=hfgrandtotal.ClientID%>').value = grandtoatal - parseFloat(Freight.value);
                return false;
            }
            else {
                var LocFreight = document.getElementById('<%= txtfreight.ClientID %>');
                var docclear = document.getElementById('<%= txtdocnclr.ClientID%>');
                var ocFreight = document.getElementById('<%= txtocfrei.ClientID%>');
                var Insurance = document.getElementById('<%= txtinsurance.ClientID%>');

                var e = document.getElementById('<%= dddelivery.ClientID%>');  //document.getElementById("");
                if (e.value == "EXW") {
                    var Freight = (parseFloat(LocFreight.value));
                }
                else if (e.value == "FOB") {
                    var Freight = (parseFloat(LocFreight.value) + parseFloat(docclear.value));
                }
                else if (e.value == "CNF") {
                    var Freight = (parseFloat(LocFreight.value) + parseFloat(docclear.value) + parseFloat(ocFreight.value));
                }
                else {

                    var Freight = (parseFloat(LocFreight.value) + parseFloat(docclear.value) + parseFloat(ocFreight.value) + parseFloat(Insurance.value));
                }


                //var Freight = (parseFloat(LocFreight.value) + parseFloat(docclear.value) + parseFloat(ocFreight.value) + parseFloat(Insurance.value));

                for (var row = 1; row < Grid_Table.rows.length - 1; row++) {
                    vat = 0;//parseFloat(vat) + parseFloat(Grid_Table.rows[row].cells[7].textContent.split("(")[0].replace(/[^0-9.]/g, ""));
                    total = parseFloat(total) + parseFloat(Grid_Table.rows[row].cells[9].textContent.replace(/[^0-9.]/g, ""));
                    totalkg = parseFloat(totalkg) + parseFloat(Grid_Table.rows[row].cells[8].textContent.replace(/[^0-9.]/g, ""));
                }
                if (!Freight.length > 0) {
                    Freight.value = 0;
                }
                grandtoatal = vat + total + (Freight)
                Grid_Table.rows[row].cells[7].innerHTML = "<b>" + totalkg + " Kg</b>";
                Grid_Table.rows[row].cells[9].innerHTML = "</b>" + "<hr style='border: 0; margin-top: 4px; margin-bottom: 4px;'>" + "<b><i class='fa fa-rupee'></i> " + parseFloat(Freight).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') + "</b>" + "<hr style='border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;'>" + "<b><i class='fa fa-rupee'></i> " + Math.round(grandtoatal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') + "</b>";
                document.getElementById('<%=hftotalvat.ClientID%>').value = vat;
                document.getElementById('<%=hfgrandtotal.ClientID%>').value = grandtoatal - parseFloat(Freight);
                return false;
            }
        }
    </script>
    <script>
        // $(".account-dd").select2();
        $(document).ready(function () {

            $(".account-dd").on("change", function () {
                $("#ContentPlaceHolder1_livedd").val(this.value);
            })

            loadDD("ItemcontrolService.asmx/Filldropdown", ".account-dd", "account", "", "", "", "", 0);
        });
        function loadDD(URL, id, pholder, val1, val2, val3, refid, minlnth, read) {
            ; debugger
            // loading remote data
            minlnth = 1;
            read = false;
            var x = refid;

            var formData = "";

            function createpara(term, page) {
                debugger

                formData = {};
                formData.q = term;
                formData.page = page;

                //formData.__RequestVerificationToken = $("input[name=__RequestVerificationToken]").val();
                formData.value1 = $("#ContentPlaceHolder1_ddQuotationType option:selected").text();
                if (x.split(',').length > 1) {
                    var a = x.split(',')

                    for (var i = 0; i < a.length; i++) {
                        formData["v" + i] = $(a[i]).val();
                    }

                }
                else if (x.split(',').length == 0 || x != "") {
                    formData["v1"] = $(x).val();
                }

                return formData;
            }




            function formatRepo(repo) {



                if (repo.loading) return repo.text;
                var markup = "<div class='select2-result-repository clearfix'>" +
                    "<div class='select2-result-repository__meta'>" +
                    "<div class='select2-result-repository__title'>" + repo.text + "</div>" +
                    "</div></div>";
                //if (repo.description) {
                //    markup += "<div class='select2-result-repository__description'>" + repo.description + "</div>";
                //}
                //markup += "<div class='select2-result-repository__statistics'>" +
                //    "<div class='select2-result-repository__forks'><i class='fa fa-flash'></i> " + repo.forks_count + " Forks</div>" +
                //    "<div class='select2-result-repository__stargazers'><i class='fa fa-star'></i> " + repo.stargazers_count + " Stars</div>" +
                //    "<div class='select2-result-repository__watchers'><i class='fa fa-eye'></i> " + repo.watchers_count + " Watchers</div>" +
                //    "</div>" +
                //    "</div></div>";
                return markup;
            }

            function formatRepoSelection(repo) {
                return repo.full_name || repo.text;
            }




            $(id).select2({
                placeholder: "Select " + pholder,
                allowClear: false,
                ajax: {
                    type: "POST",
                    url: URL,
                    //contentType: "application/json; charset=utf-8",
                    //params: {
                    //    contentType: 'application/json; charset=utf-8'
                    //},
                    dataType: 'json',
                    delay: 250,
                    data: function (params) {
                        return createpara(params.term, params.page);
                        //return {


                        //    q: params.term, // search term
                        //    page: params.page,
                        //    v1: function () {
                        //        if (x != ""){
                        //            return $(x).val();
                        //        }
                        //        else {
                        //            return "";
                        //        }
                        //    },
                        //    v2: val2,
                        //    v3: val3,
                        //    __RequestVerificationToken: $("input[name=__RequestVerificationToken]").val()
                        //};
                    },
                    processResults: function (data, params) {
                        // parse the results into the format expected by Select2
                        // since we are using custom formatting functions we do not need to
                        // alter the remote JSON data, except to indicate that infinite
                        // scrolling can be used
                        params.page = params.page || 1;

                        return {
                            results: data,
                            pagination: {
                                more: (params.page * 30) < data.total_count
                            }
                        };
                    },
                    cache: false
                },
                escapeMarkup: function (markup) {
                    return markup;
                }, // let our custom formatter work
                minimumInputLength: minlnth,
                disabled: read,
                minimumResultsForSearch: 6,
                templateResult: formatRepo, // omitted for brevity, see the source of this page
                templateSelection: formatRepoSelection // omitted for brevity, see the source of this page
            });
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hfsubtotal" runat="server" />
    <asp:HiddenField ID="hfquantity" runat="server" />
    <asp:HiddenField ID="hftotalq" runat="server" />
    <asp:HiddenField ID="hfvat" runat="server" />
    <asp:HiddenField ID="hffreight" runat="server" />
    <asp:HiddenField ID="hfgrand" runat="server" />
    <asp:HiddenField ID="deletestatus" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HiddenField4" runat="server" />
    <asp:HiddenField ID="tablecheck" runat="server" />

    <asp:HiddenField ID="hfcurrencyrate" runat="server" />
    <asp:HiddenField ID="qtntype" runat="server" />
    <asp:HiddenField ID="livedd" runat="server" />

    <div class="row">
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <%-- <i class="hi hi-tasks" style="margin: -8px"></i>Modify Task<br>--%>
                    New Sale Order
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="SalesOrders.aspx">Sale Order</a></li>
                <li>New Sale Order</li>
                <%-- <li>Modify Task</li>--%>
            </ul>
            <div class="col-md-12">
                <div class="widget" style="display: table; width: 100%">
                    <div class="widget-extra themed-background-dark">
                        <h4 class="widget-content-light">
                            <strong>Sales</strong> Order
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                                <div class="col-md-4 pd-b-10">
                                    <div class="col-md-4">
                                        <label class="control-label f-size-10" for="example-hf-password">Account Category<span class="text-danger"> *</span></label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddQuotationType" runat="server" AutoPostBack="true" data-toggle="tooltip" title="Quotation Type" CssClass="form-control">
                                            <%--<asp:ListItem Value="None">None</asp:ListItem>--%>
                                            <asp:ListItem Value="Domestic">Domestic</asp:ListItem>
                                            <asp:ListItem Value="Export">Export</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" Display="Dynamic" runat="server" ControlToValidate="ddQuotationType" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please select Quotation Type" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-8 pd-b-10">
                                    <div class="col-md-2">
                                        <label class="control-label f-size-10" for="example-hf-password">Account Name:</label>
                                    </div>
                                    <div class="col-md-10" style="padding: 3px;">
                                        <%--<asp:DropDownList ID="ddrelatedtypeid" runat="server" AutoPostBack="true" name="example-chosen" class="select-chosen" data-toggle="tooltip" title="Related Type ID"></asp:DropDownList>--%>
                                        <asp:DropDownList ID="ddrelatedtypeid" runat="server" AutoPostBack="true"
                                            name="example-chosen" class="select-chosen" data-toggle="tooltip" title="Select account">
                                        </asp:DropDownList>
                                        <%-- <select class="account-dd"  class="account-dd">
                                            <option value="213" selected="selected">Lbagute</option>
                                        </select>--%>
                                        <asp:Label ID="lblblock" runat="server" Style="color: red" Visible="false"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-4 pd-b-10">
                                    <div class="col-md-4">
                                        <label class="control-label f-size-10" for="example-hf-password">Payment Mode</label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddpayment" runat="server" class="select-chosen">
                                            <asp:ListItem Value="Select Payment Mode" Selected="True">Select Payment Mode</asp:ListItem>
                                            <asp:ListItem Value="Bank Transfer">Bank Transfer</asp:ListItem>
                                            <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddpayment" InitialValue="Select Payment Mode" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please select payment mode" Display="Dynamic"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                                <div class="col-md-4 pd-b-10">
                                    <div class="col-md-4">
                                        <label class="control-label f-size-10" for="example-hf-password">PO. Number</label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtpono" runat="server" placeholder="Enter PO. Number" data-toggle="tooltip" title="Enter PO. Number"
                                            CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-4 pd-b-10">
                                    <div class="col-md-4">
                                        <label class="control-label f-size-10" for="example-hf-password">PO. Date</label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtpodate" runat="server" placeholder="Enter PO. Date" data-toggle="tooltip" title="Enter PO. Date"
                                            CssClass="form-control" TextMode="Date"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-4 pd-b-10">
                                    <div class="col-md-4">
                                        <label class="control-label f-size-10" for="example-hf-password">Order Date</label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtorderdate" runat="server" placeholder="Enter Order Date" data-toggle="tooltip" title="Enter Order Date"
                                            CssClass="form-control" TextMode="DateTimeLocal"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4 pd-b-10">
                                    <div class="col-md-4">
                                        <label class="control-label f-size-10" for="example-hf-password">DispatchThrough</label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtdispach" runat="server" placeholder="Enter Dispatch Through" data-toggle="tooltip" title="Enter Dispatch Through"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4 pd-b-10">
                                    <div class="col-md-4">
                                        <label class="control-label f-size-10" for="example-hf-password">Terms of Delivery</label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="dddelivery" runat="server" CssClass="form-control" AutoPostBack="true">
                                            <asp:ListItem Text="EXW" Value="EXW"></asp:ListItem>
                                            <asp:ListItem Text="FOB" Value="FOB"></asp:ListItem>
                                            <asp:ListItem Text="CNF" Value="CNF"></asp:ListItem>
                                            <asp:ListItem Text="CIF" Value="CIF"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txttermdelivery" runat="server" placeholder="Enter Terms of Delivery" data-toggle="tooltip" title="Enter Terms of Delivery"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <%--<div class="col-md-4">
                                    <div class="col-md-5">
                                        <label class="control-label" for="example-hf-password">Terms of Payment</label>
                                    </div>
                                    <div class="col-md-7">
                                       
                                        <br />
                                    </div>
                                </div>--%>
                                <div id="divCurrencyRate" runat="server">
                                    <div class="col-md-4 pd-b-10">
                                        <div class="">
                                            <label class="text-left col-md-4 control-label f-size-10" for="example-hf-email">Currency Rate</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtCurrencyRate" runat="server" AutoPostBack="true" onkeyup="this.value=this.value.replace(/[^\d\.]/g,'');" placeholder="Enter Currency Rate" data-toggle="tooltip" title="Enter Currency Rate"
                                                    CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqCurrencyRate" runat="server" ControlToValidate="txtCurrencyRate" Text="65.0" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                                    ErrorMessage="Please Enter Currency Rate" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <%--<asp:HiddenField ID="hfvat" runat="server" />
                                          <asp:HiddenField ID="hffreight" runat="server" />--%>
                                        <div class="col-md-4 pd-b-10">
                                            <div class="col-md-4">
                                                <label class="control-label f-size-10" for="example-hf-password">Local Freight</label>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtfreight" runat="server"  AutoPostBack="true" OnTextChanged="txtfreight_TextChanged"  placeholder="Enter Freight" data-toggle="tooltip" title="Enter Freight"
                                                    CssClass="form-control" onblur="Read_Data();"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-4 pd-b-10">
                                            <div class="col-md-4">
                                                <label class="control-label f-size-10" for="example-hf-password">Bank</label>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlBank" runat="server" name="example-chosen" class="select-chosen">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="dddelivery" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <div id="divDomestic" runat="server">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div class="col-md-4 pd-b-10" id="divdocnclr" runat="server">
                                                <div class="">
                                                    <label class="text-left col-md-4 control-label f-size-10" for="example-hf-email">Document and Clearance</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtdocnclr" runat="server" onkeyup="this.value=this.value.replace(/[^\d\.]/g,'');" placeholder="Enter Document and Clearance Charges" data-toggle="tooltip" title="Enter Document and Clearance Charges"
                                                            CssClass="form-control" onblur="Read_Data();"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" Display="Dynamic" runat="server" ControlToValidate="txtdocnclr" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                                            ErrorMessage="Enter Document and Clearance charges" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="dddelivery" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div class="col-md-4 pd-b-10" id="divocnfre" runat="server">
                                                <div class="">
                                                    <label class="text-left col-md-4 control-label f-size-10" for="example-hf-email">Ocean Freight</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtocfrei" runat="server" onkeyup="this.value=this.value.replace(/[^\d\.]/g,'');" placeholder="Enter Ocean Freight Charges" data-toggle="tooltip" title="Enter Ocean Freight Charges"
                                                            CssClass="form-control" onblur="Read_Data();"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" Display="Dynamic" runat="server" ControlToValidate="txtocfrei" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                                            ErrorMessage="Enter Ocean Freight" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="dddelivery" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div class="col-md-4 pd-b-10" id="divins" runat="server">
                                                <div class="">
                                                    <label class="text-left col-md-4 control-label f-size-10" for="example-hf-email">Insurance</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtinsurance" runat="server" onkeyup="this.value=this.value.replace(/[^\d\.]/g,'');" placeholder="Enter Insurance charges" data-toggle="tooltip" title="Enter Insurance charges"
                                                            CssClass="form-control" onblur="Read_Data();"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" Display="Dynamic" runat="server" ControlToValidate="txtinsurance" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                                            ErrorMessage="Enter Insurance charges" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="dddelivery" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <div class="col-md-4 pd-b-10">
                                        <div class="">
                                            <label class="text-left col-md-4 control-label f-size-10" for="example-hf-email">Currency</label>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddCurrency" runat="server" CssClass="form-control" Enabled="false">
                                                    <asp:ListItem Text="INR" Value="INR"></asp:ListItem>
                                                    <asp:ListItem Text="USD" Value="USD"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4 pd-b-10">
                                        <label class="text-left col-md-4 control-label f-size-10" for="example-hf-email">Mode Of Transport</label>
                                        <div class="col-md-8">
                                            <%--<asp:TextBox ID="txtModeOfTransport" runat="server"   placeholder="Enter Mode Of Transport" data-toggle="tooltip" title="Enter Mode Of Transport"
                                            CssClass="form-control"></asp:TextBox>--%>
                                            <asp:DropDownList ID="ddModeOfTransport" runat="server" CssClass="form-control" AutoPostBack="true">
                                                <asp:ListItem Text="Sea" Value="Sea"></asp:ListItem>
                                                <asp:ListItem Text="Air" Value="Air"></asp:ListItem>
                                                <asp:ListItem Text="Road" Value="Road"></asp:ListItem>
                                            </asp:DropDownList>
                                            <%--<asp:RequiredFieldValidator ID="reqModeTransport" runat="server" ControlToValidate="txtModeOfTransport" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please Enter Mode Of Transport" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>
                                    <div class="col-md-4 pd-b-10">
                                        <label class="text-left col-md-4 control-label f-size-10" for="example-hf-email">Port Of Loading</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtPortLoading" runat="server" placeholder="Enter Port Of Loading" data-toggle="tooltip" title="Enter Port Of Loading"
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="reqPortLoading" runat="server" ControlToValidate="txtPortLoading" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please Enter Port Of Loading" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-4 pd-b-10">
                                        <label class="text-left col-md-4 control-label f-size-10" for="example-hf-email">Port Of Discharge</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtPortDischarge" runat="server" placeholder="Enter Port Of Discharge" data-toggle="tooltip" title="Enter Port Of Discharge"
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="reqPortDischarge" runat="server" ControlToValidate="txtPortDischarge" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please Enter Port Of Discharge" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                        <br />
                                    </div>
                                    <div class="col-md-4 pd-b-10">
                                        <label class="text-left col-md-4 control-label f-size-10" for="example-hf-email">Country Of Origin</label>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlcountrybillCOO" runat="server" name="example-chosen" class="select-chosen"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" InitialValue="0" ControlToValidate="ddlcountrybillCOO" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="select country" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                        <br />
                                        <br />
                                        <br />
                                    </div>
                                    <div class="col-md-4 pd-b-10">
                                        <div class="col-md-4">
                                            <label class="text-left control-label f-size-10" for="example-hf-email">Country Of Final Destination</label>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlcountrybill" runat="server" name="example-chosen" class="select-chosen" AutoPostBack="true"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="recountrybill" runat="server" InitialValue="0" ControlToValidate="ddlcountrybill" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="select country" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                        <br />
                                        <br />
                                        <br />
                                    </div>
                                    <div class="col-md-4 pd-b-10">
                                        <label class="text-left col-md-4 control-label f-size-10" for="example-hf-email">Final Destination</label>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlstatebill" runat="server" name="example-chosen" class="select-chosen"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="restatebill" InitialValue="0" runat="server" ControlToValidate="ddlstatebill" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="select state" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                        <br />
                                        <br />
                                        <br />
                                    </div>
                                </div>
                                <div id="divpayterms" runat="server">
                                    <div class="col-md-4 pd-b-10">
                                        <label class="text-left col-md-4 control-label f-size-10" for="example-hf-email">Terms Of Payments</label>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddPaymentTerms" runat="server" CssClass="form-control" AutoPostBack="true">
                                                <asp:ListItem Text="Pre Payment" Value="Pre Payment"></asp:ListItem>
                                                <asp:ListItem Text="Payment Against Document" Value="Payment Against Document"></asp:ListItem>
                                                <asp:ListItem Text="Credit" Value="Credit"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:TextBox ID="txttermpayment" runat="server" placeholder="Enter Terms of Payment" data-toggle="tooltip" title="Enter Terms of Payment"
                                                CssClass="form-control"></asp:TextBox>

                                            <%--<asp:TextBox ID="txtPaymentTerms" runat="server"  placeholder="Enter Terms Of Payments" data-toggle="tooltip" title="Enter Terms Of Payments"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqPaymentTerms" runat="server" ControlToValidate="txtPaymentTerms" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please Enter Terms Of Payments" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                            <%--<br />
                                            <br />
                                            <br />--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4 pd-b-10">
                                    <div class="col-md-4">
                                        <label class="text-left control-label f-size-10" for="example-hf-email">Shipping Address</label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlShipAddr" runat="server" name="example-chosen" class="select-chosen" AutoPostBack="true" ToolTip="Select Shipping Address"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="0" ControlToValidate="ddlcountrybill" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select country" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <br />
                                    <br />
                                    <br />
                                </div>

                                                              <%-- Shipping address --%>
                                
                                <div class="col-md-4 pd-b-10 ">
     
                                    <div class="col-md-4">
    <label class="text-left control-label f-size-10" for="example-hf-email">Billed From<span class="text-danger">*</span></label>
</div>
                                   <%-- <label for="example-nf-email">
         Billed From <span class="text-danger">*</span>
     </label>--%>
 <div class="col-md-8">
     <asp:DropDownList ID="ddlbilledfrom" runat="server" data-toggle="tooltip" title="Billed From" class="select-chosen" TabIndex="1">
     </asp:DropDownList>

     <asp:RequiredFieldValidator
         ID="rebill"
         runat="server"
         ControlToValidate="ddlbilledfrom"
         ValidationGroup="MasterGroup"
         CssClass="MasterValidationCSS"
         ErrorMessage="Please select company"
         InitialValue="0"
         Display="Dynamic">
     </asp:RequiredFieldValidator>
     </div>
     <br />
     <br />

 </div>

 <div class="col-md-4 pd-b-10 ">
    
                                         <div class="col-md-4">
    <label class="text-left control-label f-size-10" for="example-hf-email">Shipped From<span class="text-danger">*</span></label>
</div>
     <div class="col-md-8">
     <asp:DropDownList
         ID="ddlshippedfrom"
         runat="server"
         data-toggle="tooltip"
         title="Shipped From"
         class="select-chosen"
         TabIndex="2">
     </asp:DropDownList>

     <asp:RequiredFieldValidator
         ID="reship"
         runat="server"
         ControlToValidate="ddlshippedfrom"
         ValidationGroup="MasterGroup"
         CssClass="MasterValidationCSS"
         ErrorMessage="Please select company"
         InitialValue="0"
         Display="Dynamic">
     </asp:RequiredFieldValidator>
</div>
     <br />
     <br />
 </div>
<%-- end Shipping and billing--%>

                                <div class="col-md-4 pd-b-10">
                                    <!-- <div class="col-md-4">
                                        <div id="dvTCS" runat="server" class="label label-danger label-TCS">TCS Applicable</div>
                                    </div>-->
                                </div>
                                <asp:UpdatePanel ID="uptop" runat="server" UpdateMode="Always">
                                    <ContentTemplate>
                                        <div class="text-left col-md-4 control-label f-size-10" id="divmop" runat="server" visible="false">
                                            <div class="col-md-4">
                                                <label class="control-label f-size-10" for="example-hf-email">
                                                    <asp:Label ID="lbmopsub" runat="server"></asp:Label></label>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtmopsub" runat="server" data-toggle="tooltip"
                                                    CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddPaymentTerms" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <div id="divPrintIn" runat="server" class="col-md-4 pd-b-10" visible="false">
                                    <label class="col-md-4 control-label" for="example-hf-email">Print In</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlPrint" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="USD" Value="USD"></asp:ListItem>
                                            <asp:ListItem Text="INR" Value="INR"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 pd-b-10">
                                <div class="col-md-4" id="divinclude" runat="server">
                                    <div class="">
                                        <label class="col-md-4 control-label" for="example-hf-email">Order Includes Freight</label>
                                        <div class="col-md-8">
                                            <asp:CheckBox ID="chkqif" runat="server" AutoPostBack="true" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12 pd-b-10" runat="server" visible="false">
                                <div class="col-md-4">
                                    <div class="col-md-5">
                                        <label class="control-label" for="example-hf-password">Billed From</label>
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlcompany" runat="server" name="example-chosen" class="select-chosen" data-toggle="tooltip" title="Billed From"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div style="clear: both;"></div>
                            <br />
                            <div class="col-md-12 pd-b-10">

                                <%--<div class="col-md-4">
                                    <div class="checkbox">
                                                    <label for="example-checkbox1">
                                                        <asp:CheckBox ID="chknotax" runat="server"  Text="No taxation detail available"/>                                                        
                                                    </label>
                                                </div>
                                    </div> 
                                </div> --%>
                                <div style="clear: both;"></div>
                                <div class="col-md-12 pd-b-10">
                                    <div class="col-md-12">
                                        <!-- Company Info -->
                                        <div class="col-sm-3">
                                            <h4 class="themed-color"><strong>Account Details</strong></h4>
                                            <address>
                                                <strong>
                                                    <asp:Label ID="lblaccname" runat="server"></asp:Label></strong><br />
                                                <asp:Label ID="lblaccontact" runat="server"></asp:Label><br />
                                                <div runat="server" id="atphone">
                                                    <i class="fa fa-phone"></i>
                                                    <asp:Label ID="lbltelephone" runat="server"></asp:Label><br />
                                                </div>
                                                <div runat="server" id="amphone">
                                                    <i class="gi gi-iphone"></i>
                                                    <asp:Label ID="lblacphone" runat="server"></asp:Label><br />
                                                </div>
                                                <div runat="server" id="aemail">
                                                    <i class="fa fa-envelope-o"></i>
                                                    <asp:Label ID="lblaccemail" runat="server"></asp:Label>
                                                </div>
                                            </address>
                                        </div>
                                        <div class="col-sm-3">
                                            <h4 class="themed-color"><strong>Billing Address</strong></h4>
                                            <address>
                                                <strong>
                                                    <asp:Label ID="lblnamebill" runat="server"></asp:Label></strong><br />
                                                <asp:Label ID="lbladdressbill" runat="server"></asp:Label><br />
                                                <asp:Label ID="lblcountrybill" runat="server"></asp:Label>
                                                <asp:Label ID="lblsatatebill" runat="server"></asp:Label><br />
                                                <asp:Label ID="lblCitybill" runat="server"></asp:Label>
                                                <asp:Label ID="lblpincodebill" runat="server"></asp:Label><br />
                                                <div runat="server" id="bphone">
                                                    <i class="fa fa-phone"></i>
                                                    <asp:Label ID="lbltelephonebill" runat="server"></asp:Label><br />
                                                </div>
                                                <div runat="server" id="bemail">
                                                    <i class="fa fa-envelope-o"></i>
                                                    <asp:Label ID="lblemailbill" runat="server"></asp:Label>
                                                </div>
                                            </address>
                                        </div>
                                        <div class="col-sm-3">
                                            <h4 class="themed-color"><strong>Shipping Address</strong></h4>
                                            <address>
                                                <strong>
                                                    <asp:Label ID="lblnameship" runat="server"></asp:Label></strong><br />
                                                <asp:Label ID="lbladdressShip" runat="server"></asp:Label><br />
                                                <asp:Label ID="lblcountryship" runat="server"></asp:Label>
                                                <asp:Label ID="lblsatateship" runat="server"></asp:Label><br />
                                                <asp:Label ID="lblCityship" runat="server"></asp:Label>
                                                <asp:Label ID="lblpincodeship" runat="server"></asp:Label><br />
                                                <div runat="server" id="sphone">
                                                    <i class="fa fa-phone"></i>
                                                    <asp:Label ID="lbltelephoneship" runat="server"></asp:Label><br />
                                                </div>
                                                <div runat="server" id="semail">
                                                    <i class="fa fa-envelope-o"></i>
                                                    <asp:Label ID="lblemailship" runat="server"></asp:Label>
                                                </div>
                                            </address>
                                        </div>
                                        <div class="col-sm-3">
                                            <h4 class="themed-color"><strong>TAX. Details</strong></h4>
                                            <address>
                                                <div style="display: none;">
                                                    <b>
                                                        <label class="control-label" for="example-hf-password">CST:  </label>
                                                    </b>
                                                    <strong>
                                                        <asp:Label ID="lblcst" runat="server" Font-Bold="true"></asp:Label></strong><br />
                                                </div>

                                                <b>
                                                    <label class="control-label" for="example-hf-password">PAN:  </label>
                                                </b>
                                                <strong>
                                                    <asp:Label ID="lblpan" runat="server" Font-Bold="true"></asp:Label></strong>
                                                <br />
                                                <b>
                                                    <label class="control-label" for="example-hf-password">GST:  </label>
                                                </b>
                                                <strong>
                                                    <asp:Label ID="lblvat" runat="server" Font-Bold="true"></asp:Label></strong>
                                                <!--ODA NEW -->
                                                <br />
                                                <div id="divODALimit" runat="server" Visible="false">
                                                    <b>
                                                        <label class="control-label" for="example-hf-password">ODA Limit:  </label>
                                                    </b>
                                                    <strong>
                                                        <asp:Label ID="lblODALimit" runat="server" Text="0" Font-Bold="true"></asp:Label></strong>
                                                </div>
                                                <br />
                                                <div id="divODACharge" runat="server" Visible="false">
                                                    <b>
                                                        <label class="control-label" for="example-hf-password">ODA Charges:  </label>
                                                    </b>
                                                    <strong>
                                                        <asp:Label ID="lblODACharges" runat="server" Text="0" Font-Bold="true"></asp:Label></strong>
                                                </div>
                                                <br />
                                                <asp:Label ID="lblTCSApplicable" runat="server" Visible="false" Font-Bold="true" class="btn btn-xs btn-danger control-label" Text="TCS Applicable"></asp:Label>

                                                <asp:Label ID="lblODAApplicable" runat="server" Visible="true" Font-Bold="true" class="btn btn-xs btn-danger control-label" Text="ODA Applicable"></asp:Label>
                                            </address>
                                            <!--Discount div added on 10-03-2026-->
                                            <%--<div class="col-md-4 pd-b-10">
                                                <div class="col-md-4">
                                                    <div id="dvdiscount" runat="server" class="label label-danger label-Discount">Discount Applicable</div>
                                                </div>
                                            </div>--%>
                                          <div id="dvdiscount" runat="server" visible="false">
    <asp:CheckBox ID="chkApplyCashDiscount"
        runat="server"
        Text="Apply Cash Discount"
        AutoPostBack="true" />
</div>
                                            <!-- end of discount div-->
                                        </div>
                                    </div>
                                </div>

                                <hr />
                                <div class="col-md-12" style="display: none;">
                                    <User:AssignControl ID="assigncontrol" runat="server" />
                                </div>

                                <div class="col-md-12">
                                    <asp:LinkButton ID="btnopen" Text="Add Item" ValidationGroup="MasterGrouppop" runat="server" class="btn btn-alt btn-xs btn-primary" />
                                    <asp:LinkButton ID="btnQuickOpen" Text="Quick Add Item" ValidationGroup="MasterGrouppop" runat="server" class="btn btn-alt btn-xs btn-primary" />
                                    <br />
                                    <br />
                                </div>
                              
                              

                                  <%--Adding Free Sample--%>
  <asp:CheckBox ID="chkAddFreeSample" runat="server" Text=" Add Free Sample" />
  <%--END Free Sample--%>
                                <div class="col-md-12">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
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
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SKU" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                            <HeaderTemplate>
                                                                <asp:HyperLink ID="HyperLink13" runat="server">SKU</asp:HyperLink>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hfPacking_Weight" runat="server" Value='<%#Eval("Packing_Weight")%>' />
                                                                <asp:Label ID="ltproductWeight" runat="server" Text='<%#Eval("Packing_Weight")%>' Visible="false"></asp:Label>
                                                                <asp:Label ID="ltpackingpacking" runat="server" Text='<%#Eval("Packing_Packing")%>'></asp:Label>
                                                                <asp:Label ID="ltproductid" runat="server" Text='<%#Eval("ProductId")%>' Visible="false"></asp:Label>
                                                                <asp:Label ID="lblLinkAs" runat="server" Text='<%#Eval("Product_linkas")%>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="PrdRate" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                            <HeaderTemplate>
                                                                <asp:HyperLink ID="HyperLink15" runat="server">Rate/kg</asp:HyperLink>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <i class="fa fa-rupee"></i>&nbsp;
                                                            <asp:Label ID="ltPrdrate" runat="server" Text='<%#Eval("Product_Rate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Rate" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                            <HeaderTemplate>
                                                                <asp:HyperLink ID="HyperLink15" runat="server">Discounted Rate/kg</asp:HyperLink>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <i class="fa fa-rupee"></i>&nbsp;
                                                            <asp:Label ID="ltrate" runat="server" Text='<%#Eval("ItemDt_Rate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="$ Rate" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                            <HeaderTemplate>
                                                                <asp:HyperLink ID="HyperLink15" runat="server">$Rate/kg</asp:HyperLink>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <i class="fa fa-dollar "></i>&nbsp;
                                                                            <asp:Label ID="ltdollarrate" runat="server" Text='<%#(CDbl(Eval("ItemDt_Rate")) / CDbl(txtCurrencyRate.Text)).ToString("N2")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="$ Rate/SKU" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                            <HeaderTemplate>
                                                                <asp:HyperLink ID="HyperLink15" runat="server">$Rate/SKU</asp:HyperLink>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <i class="fa fa-dollar"></i>&nbsp;
                                                                            <asp:Label ID="ltDrateSKU" runat="server" Text='<%#(CDbl((CDbl(Eval("ItemDt_Rate")) / CDbl(txtCurrencyRate.Text)).ToString("N2")) * Eval("Packing_Weight"))%>'></asp:Label>
                                                                <asp:Label ID="ltrateSKU" Visible="false" runat="server" Text='<%#(Eval("SKUcost"))%>'></asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Lot No." ItemStyle-Width="100px" HeaderStyle-CssClass="" ItemStyle-CssClass="" Visible="false">
                                                            <HeaderTemplate>
                                                                <asp:HyperLink ID="HyperLink14" runat="server">Lot No.</asp:HyperLink>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <div>
                                                                    <asp:TextBox ID="txtlot" runat="server" Height="25" data-toggle="tooltip" title="Enter Lot No."
                                                                        CssClass="form-control"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtlot" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                                        ErrorMessage="This field is required" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Mfg. Date" ItemStyle-Width="100px" HeaderStyle-CssClass="" ItemStyle-CssClass="" Visible="false">
                                                            <HeaderTemplate>
                                                                <asp:HyperLink ID="HyperLink14" runat="server">Mfg. Date</asp:HyperLink>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <div>
                                                                    <asp:TextBox ID="txtmfgdate" TextMode="Date" runat="server" Height="25" Width="143" data-toggle="tooltip" title="Enter Mfg. Date"
                                                                        CssClass="form-control" MaxLength="3"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtmfgdate" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                                        ErrorMessage="This field is required" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Exp. Date" ItemStyle-Width="100px" HeaderStyle-CssClass="" ItemStyle-CssClass="" Visible="false">
                                                            <HeaderTemplate>
                                                                <asp:HyperLink ID="HyperLink14" runat="server">Exp. Date</asp:HyperLink>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <div>
                                                                    <asp:TextBox ID="txtExpdate" TextMode="Date" runat="server" Height="25" Width="143" data-toggle="tooltip" title="Enter Exp. Date"
                                                                        CssClass="form-control" MaxLength="3"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtExpdate" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                                        ErrorMessage="This field is required" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>




                                                        <asp:TemplateField HeaderText="No.Of Pack" ItemStyle-Width="100px" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                            <HeaderTemplate>
                                                                <asp:HyperLink ID="HyperLink14" runat="server">No.Of Pack</asp:HyperLink>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <div class="col-md-12">
                                                                    <asp:TextBox ID="txtquantity" runat="server" AutoPostBack="true" OnTextChanged="txtquantity_TextChanged" onblur="calculateFinalPrice(this,'hfkg')" onkeyup="this.value=this.value.replace(/\D/g,'');" Text='<%#Eval("ItemDt_Qty")%>' Height="25" data-toggle="tooltip" title="Enter Qunatity"
                                                                        CssClass="form-control" ></asp:TextBox><%--MaxLength="3"--%>
                                                                    <asp:Label ID="ltquantity" runat="server" Visible="false" Text='<%#Eval("ItemDt_Qty")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="GST" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                            <HeaderTemplate>
                                                                <asp:HyperLink ID="HyperLink17" runat="server">GST</asp:HyperLink>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <i class="fa fa-rupee"></i>&nbsp;
                                                            <asp:Label ID="lblvatinrs" runat="server" Text='<%#Eval("Product_Vat")%>' />

                                                                (<asp:Label ID="lblvat" runat="server" Text='<%#Eval("Product_Vat")%>' />%)
                                                            
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lttotalkg" runat="server" Font-Bold="true" Style="position: absolute; margin-top: -23px;"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Qty" HeaderStyle-CssClass="" ItemStyle-CssClass="" FooterStyle-VerticalAlign="Top">
                                                            <HeaderTemplate>
                                                                <asp:HyperLink ID="HyperLink17" runat="server">Qty</asp:HyperLink>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="ltkg" Text='<%#Eval("Packing_Weight")%>' runat="server"></asp:Label>
                                                                <asp:HiddenField ID="hfkg" runat="server" Value='<%#Eval("Packing_Weight")%>' />
                                                                kg
                                           
                                                                                                                  

                                                            </ItemTemplate>

                                                            <FooterTemplate>

                                                                <table border="0">
                                                                    <!--Discount-->
                                                                    <div id="divdiscount" runat="server" Visible="false">
                                                                        Discount Amount (<asp:Label ID="lblDiscountPer" runat="server"></asp:Label>%):
    <br />
                                                                        <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />
                                                                    </div>
                                                                    <!--Discount end -->
                                                                    
                                                                    <tr runat="server" id="trGSTRowTitle" >
                                                                        <td>Total GST:
                                                                            <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />
                                                                        </td>
                                                                    </tr>

                                                                    <tr ID="trODARowTitle" Visible="false" runat="server">
                                                                        <td>ODA Charges:
                                                                            <br /><hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" /> 
                                                                        </td>
                                                                    </tr>
                                                          
                                                                    <tr ID="trFrgtRowTitle" Visible="false" runat="server">
                                                                        <td>Freight:
                                                                            <br /><hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" /> 
                                                                        </td>
                                                                    </tr>

                                                                    <tr ID="trTCSRowTitle" Visible="false" runat="server">
                                                                        <td>TCS:
                                                                            <br /><hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" /> 
                                                                        </td>
                                                                    </tr>

                                                                    <tr ID="trTotalAmountRowTitle" Visible="false" runat="server">
                                                                        <td>Total Amount:
                                                                            <br /><hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" /> 
                                                                        </td>
                                                                    </tr>


                                                                </table>

                                                               
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
                                                                
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Amount" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                            <HeaderTemplate>
                                                                <asp:HyperLink ID="HyperLink18" runat="server">Amount</asp:HyperLink>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
<%--                                                                <asp:HiddenField ID="hflblvatinrs" runat="server" />
                                                                <asp:Label ID="ltamtdollar" runat="server" Visible="false"> <i class="fa fa-dollar"></i>&nbsp;</asp:Label>
                                                                <asp:Label ID="ltamtrupee" runat="server" Visible="false"><i class="fa fa-rupee"></i>&nbsp;</asp:Label>
                                                                <asp:Label ID="ltamount" runat="server"></asp:Label>
                                                                <asp:HiddenField ID="hfltamount" runat="server" />--%>
                                                                              <asp:HiddenField ID="hflblvatinrs" runat="server" />
                                                                <asp:Label ID="ltamtdollar" runat="server" Visible="false"> <i class="fa fa-dollar"></i>&nbsp;</asp:Label>
                                                                <asp:Label ID="ltamtrupee" runat="server" Visible="false"><i class="fa fa-rupee"></i>&nbsp;</asp:Label>
                                                                <asp:Label ID="ltamount" runat="server"></asp:Label>
                                                                <asp:HiddenField ID="hfltamount" runat="server" />
                                                            </ItemTemplate>
                                                            <FooterTemplate>

                                                              <table border="0">

                                                                  <!--Discount-->
                                                                  <div id="discountamt" runat="server" visible="false" >
                                                                      <b><i class="fa fa-rupee"></i>&nbsp;
                                                                      <asp:Label ID="LbldiscountAmt" runat="server"></asp:Label>
                                                                      </b>
                                                                      <br />

                                                                  </div>
                                                                  <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />
                                                                  <!--Discount end-->
                                                                    <tr runat="server" id="trGSTRowValue" Visible="false">
                                                                        <td>
                                                                                <b><i class="fa fa-rupee"></i>&nbsp;
                                                                                <asp:Label ID="lttotalvat" runat="server"></asp:Label></b><br />
                                                                    <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />
                                                                        </td>
                                                                    </tr>

                                                                    <tr ID="trODARowValue" Visible="false" runat="server">
                                                                        <td>
                                                                                <b><i class="fa fa-rupee"></i>&nbsp;
                                                                                <asp:Label ID="lblODAAmountChrgs" runat="server" Text="0" Font-Bold="true"></asp:Label></b><br />
                                                                    <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />
                                                                        </td>
                                                                    </tr>
                                                          
                                                                    <tr ID="trFrgtRowValue" Visible="false" runat="server">
                                                                        <td>
                                                                            <b><i class="fa fa-rupee"></i>&nbsp;
                                                                <asp:Label ID="lblfreight" runat="server"></asp:Label>
                                                                </b>
                                                                <br />
                                                                <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />

                                                                        </td>
                                                                    </tr>

                                                                    <tr ID="trTCSRowValue" Visible="false" runat="server">
                                                                        <td>
                                                                            <b><i class="fa fa-rupee"></i>&nbsp;
                                                                <asp:Label ID="LblTcsAmount" Visible="false" runat="server" Text="0">
                                                                </asp:Label>
                                                                <br /><hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />   
                                                                
                                                                        </td>
                                                                    </tr>

                                                                    <tr ID="trTotalAmountRowValue" Visible="false" runat="server">
                                                                        <td>
                                                                            <b><i class="fa fa-rupee"></i>&nbsp;
                                                                            <asp:Label ID="lttotalamount" Style="font-weight: bold;" runat="server" Text="we34wd23" ></asp:Label></b>

                                                                        </td>
                                                                    </tr>


                                                                </table>


<%--                                                                <%--Total Amount:<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
   <%--                                                             <div runat="server" id="divfootvatamt">
                                                                    <b><i class="fa fa-rupee"></i>&nbsp;
                                                                                <asp:Label ID="lttotalvat" runat="server"></asp:Label></b><br />
                                                                    <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />
                                                                </div>
                                                                <asp:Label ID="rsODA" Visible="false" Text=' ' class="fa fa-rupee" runat="server"> </asp:Label>&nbsp;
                                                                <asp:Label ID="LblODAAmnt" Style="font-weight: bold;" Visible="false" Text="0" runat="server"> </asp:Label>
                                                                <asp:Label ID="hrODA" Style="font-weight: bold;" Visible="false" runat="server" Text="0">
                                                                <br /><hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />   
                                                                </asp:Label>

                                                                <b><i class="fa fa-rupee"></i>&nbsp;
                                                                <asp:Label ID="lblfreight" runat="server"></asp:Label>

                                                                </b>
                                                                <br />
                                                                <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />



                                                                <asp:Label ID="rsTCS" Visible="false" Style="font-weight: bold;" class="fa fa-rupee" runat="server"></asp:Label>&nbsp;
                                                                <asp:Label ID="LblTcsAmount" Style="font-weight: bold;" Visible="false" runat="server" Text="0">
                                                                </asp:Label>
                                                                <asp:Label ID="hrTCS" Style="font-weight: bold;" Visible="false" runat="server" Text="0">
                                                                <br /><hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />   
                                                                </asp:Label>


                                                                <b><i class="fa fa-rupee"></i>&nbsp;
                                                                                <asp:Label ID="lttotalamount" runat="server" Text="we34wd23" >345354353</asp:Label></b>--%>
                                                            



                                                            
                                                            </FooterTemplate>
                                                            <%--                               <FooterTemplate>
                                                               <b><i class="fa fa-rupee"></i>&nbsp;
                                                                <asp:Label ID="lttotalvat" Text='78500' runat="server"></asp:Label>

                                                                </b>
                                                                <br />
                                                                <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />
                                                                <b><i class="fa fa-rupee"></i>&nbsp;
                                                                <asp:Label ID="lblfreight" Text='78500' runat="server"></asp:Label>

                                                                </b>
                                                                <br />
                                                                <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />
                                                                <b><i class="fa fa-rupee"></i>&nbsp;
                                                                <asp:Label ID="lttotalamount" Text='78500' runat="server"></asp:Label>

                                                                </b>
                                                            </FooterTemplate>--%>
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
                                            <asp:AsyncPostBackTrigger ControlID="btnsaveclose" />
                                            <asp:AsyncPostBackTrigger ControlID="grditemproduct" />
                                            <asp:AsyncPostBackTrigger ControlID="dddelivery" />

                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>

                            </div>
                        </div>
                        <asp:LinkButton ID="btnShow" runat="server" Text=""></asp:LinkButton>
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
                                                    <%-- <asp:DropDownList ID="ddpagesize" AutoPostBack="true" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                    <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                                </asp:DropDownList>--%>
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
                                            <div class="col-sm-3 col-xs-12" style="display: none;">
                                                <asp:Button ID="btnshowall" EnableViewState="false" runat="server" Text="Show All" CssClass="btn btn-alt btn-sm btn-info" />
                                            </div>
                                        </div>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div class="table-responsive">
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Product_Id"
                                                        CssClass="table table-striped table-vcenter table-hover" Font-Size="12px">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Select" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Product_Id">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="ckselect" runat="server" />
                                                                    <asp:Label ID="lblproductId" runat="server" Text='<%#Eval("Product_Id")%>' Visible="false" />
                                                                    <%--   <asp:Label ID="lbldiscount" runat="server" Text='<%#Eval("Discount_Discount")%>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblrate" runat="server" Text='<%#Eval("Product_Rate")%>' Visible="false" />
                                                            <asp:Label ID="lblvat" runat="server" Text='<%#Eval("Product_Vat")%>' Visible="false" />--%>
                                                                    <%-- <asp:Label ID="lblunit" runat="server" Text='<%#Eval("Packing_weight")%>' Visible="false" />--%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="No of Pack" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="PrdCategory_Name" ItemStyle-Width="101">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblstock" runat="server" Text='<%#Eval("Product_Stock")%>' Visible="false"></asp:Label>
                                                                    <asp:TextBox ID="txtOrderQty" runat="server" Style="width: 54px;" min="0"></asp:TextBox>
                                                                    <%-- onblur="calculateFinalPrice(this,'hfproductWeight')" --%>
                                                                    <asp:Label ID="lblout" runat="server" Text="Out Of Stock" Style="color: red; font-weight: bold;"
                                                                        Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblamount" runat="server" Visible="false"></asp:Label>
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

                                                            <asp:TemplateField HeaderText="SKU" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Packing_Packing">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblunit" runat="server" Text='<%#Eval("Packing_Packing")%>' />
                                                                    <asp:Label ID="ltproductWeight" runat="server" Text='<%#Eval("Packing_Weight")%>' Visible="false"></asp:Label>
                                                                    <asp:HiddenField ID="hfproductWeight" runat="server" Value='<%#Eval("Packing_Weight")%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Type" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Product_linkas">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLinkAs" runat="server" Text='<%#Eval("Product_linkas")%>' />
                                                                    <asp:HiddenField ID="hfLinkAs" runat="server" Value='<%#Eval("Product_linkas")%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Category" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="PrdCategory_Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("PrdCategory_Name")%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Rate / kg" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Product_Rate" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbldiscount" runat="server" Text='<%#Eval("Discount_Discount")%>' Visible="false" />
                                                                    <i class="fa fa-rupee"></i>&nbsp;
                                                                <asp:HiddenField ID="hfdiscount" runat="server" Value='<%#Eval("Discount_Discount")%>' />
                                                                    <asp:Label ID="lblrate" runat="server" Text='<%#Eval("Product_Rate")%>' />
                                                                    <asp:HiddenField ID="hfrate" runat="server" Value='<%#Eval("Product_Rate")%>' />
                                                                    <asp:HiddenField ID="hfdiscountrate" runat="server" />
                                                                    <asp:Label ID="lblvat" runat="server" Text='<%#Eval("Product_Vat")%>' Visible="false" />
                                                                    <asp:HiddenField ID="hfvat" runat="server" Value='<%#Eval("Product_Vat")%>' />
                                                                    <asp:Label ID="Label1" runat="server"></asp:Label><br />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Kgs" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Product_Code" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblkgs" runat="server" Text="-"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Amount" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Product_Code" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltotalamount2" runat="server" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lbltotalamount" runat="server" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lbltotalamount1" runat="server" Text="-"></asp:Label>
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
                                                <asp:AsyncPostBackTrigger ControlID="btnQuickOpen" />
                                                <asp:AsyncPostBackTrigger ControlID="btnshowall" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="modal-footer">
                                                <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-primary" ValidationGroup="ProductItemGroup" Text="Save changes"></asp:Button>
                                                <asp:Button ID="btnsaveclose" runat="server" class="btn btn-sm btn-primary" ValidationGroup="ProductItemGroup" Text="Save & Close"></asp:Button>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnopen" />
                                            <asp:AsyncPostBackTrigger ControlID="btnQuickOpen" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="" runat="server" DisplayAfter="0">
                            <ProgressTemplate>
                                <br />
                                <div class="divWaiting">
                                    <i class="fa fa-sun-o fa-spin" id="LoadingUpadatePanel"></i>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                </div>
            </div>
            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" />
                    <asp:LinkButton ID="hfcancel" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/SalesOrders.aspx" class="btn btn-alt btn-sm btn-danger" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

