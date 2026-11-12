<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="DirectPO.aspx.vb" Inherits="DirectPO" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .control-label {
            padding: 6px;
        }

        .col-md-4 > . {
            padding-bottom: 0px;
        }

        .c-label {
            padding-left: 13em;
        }

        .multiselect {
            width: 33em;
            height: 15em;
            border: solid 1px;
            overflow: auto;
        }

            .multiselect label {
                display: inline;
            }
    </style>
    <style>
        input[type=date]::-webkit-inner-spin-button {
            -webkit-appearance: none;
            display: none;
        }
    </style>
    <script src="js/jquery.min.js"></script>
    <script>

        function jspaytm() {
            var op = $('.paytm option:selected').val();

            if (op == "Payment against documents") {
                $('#divpayter').css("display", "block")
                $('#divpayter span').text('Documents No')
            }
            else if (op == "Credit") {
                $('#divpayter').css("display", "block")
                $('#divpayter span').text('Credit')
            }
            else {
                $('#divpayter').css("display", "none")
                $('#divpayter span').text('')
            }

            
        }

        //$(document).ready(function () {
        //    $('.paytm').change(function () {
        //        debugger;
        //        var op = $('.paytm option:selected').val();
        //        alert(op);
        //    })
        //});
    </script>
    <script>
        //document.getElementById("txttest").onkeyup = function() {myFunction()};
        function onlyNos(e, t) {
            try {
                var cnt = 0;
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                    if (charCode == 46) {
                        return true;
                    }
                    else if (charCode == 45) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                return true;
            }
            catch (err) {
                alert(err.Description);
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
                    var tmpStr = $("#" + focusedElementId).val();
                    $("#" + focusedElementId).val('');
                    $("#" + focusedElementId).val(tmpStr);


                }
            });
        });
    </script>
    <script>
        function Oninputchange(txtQty) {
            debugger;
            var name = txtQty.id;
            var myString = (name).split("_");
            var txtQty = document.getElementById(txtQty.id.replace(myString[2], 'txtQty'));
            var name = txtQty.id;
            var myString = (name).split("_");
            var txtRate = document.getElementById(txtQty.id.replace(myString[2], 'txtRate'));
            var txtTax = document.getElementById(txtQty.id.replace(myString[2], 'txtTax'));
            var lblsubtotal = document.getElementById(txtQty.id.replace(myString[2], 'lblsubtotal'));
            var lbltaxamount = document.getElementById(txtQty.id.replace(myString[2], 'lbltaxamount'));


            var hfamount = document.getElementById(txtQty.id.replace(myString[2], 'hfamount'));
            var hftax = document.getElementById(txtQty.id.replace(myString[2], 'hftax'));
            //var hfamounttotal = document.getElementById(txtQty.id.replace(myString[2], 'hfamounttotal'));
            //var hftaxtotal = document.getElementById(txtQty.id.replace(myString[2], 'hftaxtotal'));


            var lblsubtotalf = document.getElementById(txtQty.id.replace(myString[2], 'lblsubtotalf'));
            var lblgrandtaxttotalf = document.getElementById(txtQty.id.replace(myString[2], 'lblgrandtaxttotalf'));
            var lblgrandtotalf = document.getElementById(txtQty.id.replace(myString[2], 'lblsubtotal'));
            //var lblrate = document.getElementById(txtOrderQty.id.replace('txtQty', 'Literal1'));
            //var lblpackweight = document.getElementById(txtOrderQty.id.replace('txtQty', 'lblpackweight'));

            if (txtQty.value != "" && txtQty.value != "0") {
                if (!isNaN(txtQty.value)) {
                    var Amount = 0;
                    var tax = 0;
                    var subtotal = 0;
                    subtotal = ((parseFloat(txtQty.value) * parseFloat(txtRate.value))).toFixed(2);

                    tax = (subtotal * (parseFloat(txtTax.value) / 100)).toFixed(2);
                    //  lblsubtotal.textContent = (parseFloat(tax) + parseFloat(subtotal)).toFixed(2);
                    lblsubtotal.textContent = (parseFloat(subtotal)).toFixed(2);
                    hfamount.value = (parseFloat(subtotal)).toFixed(2);
                    hftax.value = tax;
                    lbltaxamount.textContent = tax;
                    var total = document.getElementsByClassName('lblsubtotal');

                    var lbltaxamount = document.getElementsByClassName('lbltaxamount');
                    var txttax = document.getElementsByClassName('txtQty');
                    var lblsubtotalf = document.getElementsByClassName('lblsubtotalf');
                    var sum = 0;
                    var tax = 0;
                    var grandtotal = 0;
                    for (var i = 0; i < total.length; ++i) {

                        var item = total[i];
                        sum = sum + parseFloat((item.innerHTML).replace(',', ''));
                    }
                    var taxamount = 0;
                    for (var i = 0; i < lbltaxamount.length; ++i) {
                        ; debugger
                        var item = lbltaxamount[i];
                        var itemchar = item.innerHTML;
                        itemchar = itemchar.replace('&nbsp;₹ ', '').replace(',','');
                        taxamount += parseFloat(itemchar);
                    }
                    //for (var i = 0; i < txttax.length; ++i) {
                    //    ; debugger
                    //    var item = txttax[i];
                    //    //tax += parseInt(item.innerHTML);
                    //    tax += parseInt(item.textContent);

                    //}
                    var grid = document.getElementById("<%= GridView1.ClientID%>");

                    //for (i = 1; i < grid.rows.length ; i++) {
                    //    var cellValue = grid.rows[i].cells[5].value;
                    //    alert(cellValue);
                    //}
                    for (var i = 0; i < grid.rows.length - 2; i++) {
                        // ; debugger
                        var txtAmountReceive = $("input[id*=txtTax]")
                        if (txtAmountReceive[i].value != "" || txtAmountReceive[i].value != 'undefined') {
                            var findtaxt = txtAmountReceive[i].value;
                            tax = tax + parseFloat(findtaxt);
                            //alert(txtAmountReceive[i].value);
                        }
                    }

                    //  taxamount = parseFloat(sum).toFixed(2) * parseFloat(tax).toFixed(2)/100
                    document.getElementById('<%=hfamounttotal.ClientID%>').value = sum;
                    document.getElementById('<%=hftaxtotal.ClientID%>').value = taxamount;


                    grandtotal = sum + taxamount;
                    $('#lisubtotal').text(parseFloat(sum).toFixed(2));
                    $('#ligrandtaxttotal').text(parseFloat(taxamount).toFixed(2));
                    $('#ligrandtotal').text(parseFloat(grandtotal).toFixed(2));

                    Read_Data()

                    //lblsubtotalf.textContent = parseFloat(sum).toFixed(2);
                    //lblgrandtaxttotalf.textContent = parseFloat(sum).toFixed(2);
                    //lblgrandtaxttotalf.textContent = parseFloat(sum).toFixed(2);
                    // alert(Amount);
                }
                //    else {
                //        lblkgs.textContent = "-";
                //        lbltotalamount1.textContent = "-";
                //    }
                //}
                //else {
                //    lblkgs.textContent = "-";
                //    lbltotalamount1.textContent = "-";
            }
        };

        function Read_Data() {
            ; debugger
            var total = 0;
            var vat = 0;
            var grandtoatal = 0;
            var totalkg = 0;
            var Grid_Table = document.getElementById('<%= GridView1.ClientID%>');


            var Freight = document.getElementById('<%= txtfreight.ClientID %>');

            for (var row = 1; row < Grid_Table.rows.length - 1; row++) {

                //    vat = parseFloat(vat) + parseFloat(Grid_Table.rows[row].cells[6].textContent.split("(")[0].replace(/[^0-9.]/g, ""));
                total = parseFloat(total) + parseFloat(Grid_Table.rows[row].cells[7].textContent.replace(/[^0-9.]/g, ""));
                //    totalkg = parseFloat(totalkg) + parseFloat(Grid_Table.rows[row].cells[7].textContent.replace(/[^0-9.]/g, ""));
            }
            if (!Freight.value.length > 0) {
                Freight.value = 0;
            }

              <%--  var Freighttaxper = '<%= System.Configuration.ConfigurationManager.AppSettings("freightvalue").ToString()%>';--%>
            //var FreightAmt = parseFloat(Freight.value) * Freighttaxper / 100;
            var FreightAmt = parseFloat(Freight.value);
            // grandtoatal = vat + total + parseFloat(Freight.value) //+ parseFloat(FreightAmt)

            // Grid_Table.rows[row].cells[8].innerHTML = "<b><i class='fa fa-rupee'></i> " + Math.round(vat + parseFloat(FreightAmt)).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') + "</b>" + "<hr style='border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;'>" + "<b><i class='fa fa-rupee'></i> " + parseFloat(Freight.value).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') + "</b>" + "<hr style='border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;'>" + "<b><i class='fa fa-rupee'></i> " + Math.round(grandtoatal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') + "</b>";
            var v1 = $('#ligrandtaxttotal').text();
            var g1 = total;//$('#ligrandtotal').text();
            grandtotal = (parseFloat(g1) + parseFloat(FreightAmt) + parseFloat(v1)).toFixed(2);
            $('#lifreight').text(parseFloat(FreightAmt).toFixed(2));
            $('#ligrandtotal').text(parseFloat(grandtotal).toFixed(2));
            return false;


        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hfsearch" runat="server" />


    <div class="row">
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <i class="gi gi-parents" style="margin: -8px"></i>
                        <asp:Label ID="lbltitle1" runat="server"></asp:Label><br>
                        <asp:Label ID="lblconvertdate" runat="server" Visible="false"></asp:Label>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="DirectPO.aspx">Direct PO</a></li>
                <li>
                    <asp:Label ID="lbltitle2" runat="server"></asp:Label></li>
                <asp:HiddenField ID="strrowcount" runat="server" />
            </ul>
            <asp:Panel ID="FullPanel" runat="server">
                <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                    <div class="pull-right">
                        <div class="" style="">
                            <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroup" OnClick="btnadd_Click" />
                            <%--<asp:LinkButton ID="HyperLink1" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/QuotationRequest.aspx" class="btn btn-alt btn-danger" OnClick="hfcancel_Click" />--%>
                            <a href="QuotationRequest.aspx" class="btn btn-alt btn-danger">Cancel</a>
                        </div>
                    </div>
                </div>

                <div class="col-md-12">
                    <div class="widget">
                        <div class="widget-extra themed-background-dark">
                            <h4 class="widget-content-light abc">
                                <strong>Direct</strong> PO
                            <small>
                                <span class="pull-right" id="modifyspan" runat="server">By&nbsp;<a style="text-decoration: none;"><asp:Label ID="lblmodifiedname" runat="server" Font-Bold="true"></asp:Label></a>&nbsp;on&nbsp;<a style="text-decoration: none;"><asp:Label ID="lblmodifieddate" Font-Bold="true" runat="server" Font-Italic="true"></asp:Label></a>
                                </span>
                            </small>
                            </h4>
                        </div>
                        <div class="widget-extra-full">
                            <div class="form-horizontal form-bordered">
                                <div class="col-md-12">
                                    <br />
                                </div>
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        <label class="control-label" for="example-hf-email">Type<span class="text-danger"> *</span></label>
                                        <asp:DropDownList ID="DDVendorType" runat="server" AutoPostBack="true" class="form-control select-chosen">
                                            <asp:ListItem Text="Domestic" Value="Domestic"></asp:ListItem>
                                            <asp:ListItem Text="International" Value="International"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div class="col-md-4">
                                                <label class="control-label" for="example-hf-email">Vendor<span class="text-danger"> *</span></label>
                                                <asp:DropDownList ID="DDVendor" runat="server" AutoPostBack="true" class="form-control select-chosen">
                                                </asp:DropDownList>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="DDVendorType" />
                                            <%--<asp:PostBackTrigger ControlID="DDVendorType" />--%>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <div class="col-md-4">
                                        <label class="control-label" for="example-hf-email">PO Number<span class="text-danger"> *</span></label>
                                        <asp:TextBox ID="txtcode" runat="server" placeholder="Enter Code" data-toggle="tooltip" title="Enter Code" ReadOnly="true"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reVendorname" runat="server" ControlToValidate="txtcode" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter code" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>

                                    </div>
                                    <div class="col-md-4" runat="server" visible="false">
                                        <label class="control-label" for="example-hf-email">Valid Upto<span class="text-danger"> *</span></label>
                                        <asp:TextBox ID="txtdate" onkeypress="return false;" runat="server" placeholder="Select Date" data-toggle="tooltip" title="Enter Date" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdate" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter date" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>

                                    </div>
                                    <div class="col-md-4">
                                        <label class="control-label" for="example-hf-password">Godown<span class="text-danger"> *</span></label>
                                        <asp:DropDownList ID="ddgodown" runat="server" name="example-chosen" class="select-chosen">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="recompnytype" runat="server" InitialValue="Select Godown" ControlToValidate="ddgodown" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select godown" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4">
                                        <label class="control-label">Billed To <span class="text-danger">*</span></label>
                                        <asp:DropDownList ID="ddlbilledfrom" runat="server" data-toggle="tooltip" title="Billed From" class="select-chosen" TabIndex="1">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rebill" runat="server" ControlToValidate="ddlbilledfrom" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please select company" InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>

                                    </div>
                                    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                        <ContentTemplate>
                                            <div id="divImport" runat="server">
                                                <div class="col-md-4">
                                                    <div class="">
                                                    <label class="control-label">Currency Type  <span class="text-danger">*</span></label>
                                                    <asp:DropDownList ID="ddCurrency" runat="server" CssClass="form-control" Enabled="false">
                                                        <asp:ListItem Text="USD" Value="USD"></asp:ListItem>
                                                        <asp:ListItem Text="AED" Value="AED"></asp:ListItem>
                                                    </asp:DropDownList>
                                                        </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="">
                                                        <label class="control-label" for="example-hf-email">Currency Rate</label>                                                        
                                                            <asp:TextBox ID="txtCurrencyRate" runat="server" AutoPostBack="true" onkeyup="this.value=this.value.replace(/[^\d\.]/g,'');" placeholder="Enter Currency Rate" data-toggle="tooltip" title="Enter Currency Rate"
                                                                CssClass="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="reqCurrencyRate" Display="Dynamic" runat="server" ControlToValidate="txtCurrencyRate" Text="65.0" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                                                ErrorMessage="Please Enter Currency Rate" SetFocusOnError="true"></asp:RequiredFieldValidator>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="">
                                                    <label class="control-label" style="float: left;">Freight <i class="fa fa-inr"></i></label>

                                                    <asp:TextBox ID="txtFreight" OnKeypress="return onlyNos(event,this);" runat="server" data-toggle="tooltip" title=" Freight" onblur="Read_Data();"
                                                        CssClass="form-control"></asp:TextBox>

                                                </div>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="DDVendorType" />
                                        </Triggers>
                                    </asp:UpdatePanel>

                                    <div class="col-md-12">
                                        <label class="control-label" for="example-hf-email">Additional Information<span class="text-danger"> </span></label>

                                        <asp:TextBox ID="txtaddinfo" runat="server" placeholder="Enter Additional Information" data-toggle="tooltip" title="Enter Additional Information" TextMode="MultiLine" Rows="2"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtaddinfo" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please additional information" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>


                                    </div>
                                </div>
                                <div style="clear: both"></div>
                            </div>
                        </div>
                    </div>
                    <div class="widget">
                        <div class="widget-extra themed-background-dark">
                            <h4 class="widget-content-light">
                                <strong>Item</strong> Details
                            </h4>
                        </div>
                        <div class="widget-extra-full">
                            <div class="form-horizontal form-bordered">
                                <div class="col-md-12">
                                    <br />
                                </div>
                              <%--  <div class="row">
                                    <div class="block">--%>
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                        <div class="col-md-12">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    <div class="table-responsive">
                                                        <asp:HiddenField ID="hfgrandtotal" runat="server" />
                                                        <asp:HiddenField ID="hfamounttotal" runat="server" />
                                                        <asp:HiddenField ID="hftaxtotal" runat="server" />
                                                        <asp:HiddenField ID="hfbarcodechk" runat="server" />
                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="" AllowCustomPaging="true"
                                                            CssClass="table table-vcenter table-condensed table-bordered tblbkgrdclr" ShowFooter="true">
                                                            <Columns>
                                                                <asp:BoundField DataField="RowNumber" Visible="false" />
                                                                <asp:TemplateField Visible="false">
                                                                    <ItemTemplate>
                                                                        <script type="text/javascript">
                                                                            Sys.Application.add_load(Oninputchange);
                                                                        </script>
                                                                        <div class="col-md-6" runat="server" visible="false">
                                                                            <asp:Label runat="server" ID="RowNumber" Text='<%#Eval("RowNumber")%>'></asp:Label>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Item Name" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader text-center" ItemStyle-CssClass="">
                                                                    <ItemTemplate>
                                                                        <div class="input-group  col-md-12">
                                                                            <asp:DropDownList ID="ddproduct" Width="500" ValidationGroup="grd1" runat="server" CssClass="select2able  " onchange="Oninputchange(this)"></asp:DropDownList>
                                                                            <asp:RequiredFieldValidator InitialValue="Select Item" ID="rfvddproduct" runat="server" Display="Dynamic" ControlToValidate="ddproduct" ErrorMessage="Select Item" ForeColor="Red" ValidationGroup="grd1"></asp:RequiredFieldValidator>
                                                                            <asp:Literal ID="ltattid" runat="server" Text='<%#Eval("QRRawMaterial_RawID")%>' Visible="false"></asp:Literal>
                                                                            <asp:Literal ID="ltqrid" runat="server" Text='<%#Eval("QRRawMaterial_QRDID")%>' Visible="false"></asp:Literal>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Rate/Item (₹)" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtRate" MaxLength="7" onkeyup="Oninputchange(this);" runat="server" Text='<%#Eval("QRRawMaterial_AMT")%>' data-toggle="tooltip" ToolTip="Rate/Item in Rupees" CssClass="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfvd1" runat="server" ControlToValidate="txtrate" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                                            ErrorMessage="This field is required" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="TAX (%)" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtTax" onkeyup="Oninputchange(this);" style="margin-top: 16px;" MaxLength="2" CssClass=" txtTax form-control" runat="server" Text='<%#Eval("QRRawMaterial_tax")%>' data-toggle="tooltip" ToolTip="Tax in Percentage"></asp:TextBox>
                                                                        <i class="fa fa-inr"></i>
                                                                        <asp:Label ID="lbltaxamount" CssClass="lbltaxamount" runat="server"></asp:Label>
                                                                        <asp:HiddenField ID="hfamount" runat="server" />
                                                                        <asp:HiddenField ID="hftax" runat="server" />
                                                                        <asp:RequiredFieldValidator ID="rfvd2" runat="server" ControlToValidate="txttax" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                                            ErrorMessage="This field is required" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Unit" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblunite" runat="server" Text='<%#Eval("QRRawMaterial_Unit")%>' Visible="false"></asp:Label>
                                                                        <asp:DropDownList ID="ddunuit" runat="server" CssClass="select-chosen">
                                                                            <asp:ListItem Value="KG" Text="KG"></asp:ListItem>
                                                                            <asp:ListItem Value="Nos." Text="Nos."></asp:ListItem>
                                                                            <asp:ListItem Value="Each" Text="Each"></asp:ListItem>
                                                                            <asp:ListItem Value="SqMt" Text="SqMt"></asp:ListItem>
                                                <asp:ListItem Value="RnMt" Text="RnMt"></asp:ListItem>
                                                <asp:ListItem Value="Ltr" Text="Ltr"></asp:ListItem>
                                                <asp:ListItem Value="Unit" Text="Unit"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="rfvddunit" runat="server" ControlToValidate="ddunuit" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                                            ErrorMessage="Select unit" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Quantity" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtQty" MaxLength="5" CssClass="txtQty form-control" runat="server" onkeyup="Oninputchange(this);" Text='<%#Eval("QRRawMaterial_Quantity")%>' data-toggle="tooltip"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfvdqty" runat="server" ControlToValidate="txtqty" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                                            ErrorMessage="This field is required" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="PACK SIZE" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtpacksize" runat="server" Text='<%#Eval("QRRawMaterial_Packsize")%>' data-toggle="tooltip" CssClass="form-control"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="HS CODE" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txthscode" runat="server" Text='<%#Eval("QRRawMaterial_Hscode")%>' data-toggle="tooltip" CssClass="form-control"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <div class="footer_grid">
                                                                            <div style="float: right; width: 105px;">
                                                                                <ul style="list-style-type: none; margin: 0;">
                                                                                    <li style="border-bottom: 0px; border-right: 0px; text-align: right;"><b>Sub Total</b></li>
                                                                                    <li style="border-bottom: 0px; border-right: 0px; text-align: right;"><b>Freight</b></li>
                                                                                    <li style="border-bottom: 0px; border-right: 0px; text-align: right;"><b>GST Total</b></li>
                                                                                    <li style="border-right: 0px; border-bottom: 0px; text-align: right;"><b>Grand Total</b></li>
                                                                                </ul>
                                                                            </div>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Amount" FooterStyle-Width="10%" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                                    <ItemTemplate>
                                                                        <div style="float: right;">
                                                                            <i class="fa fa-inr"></i>
                                                                        <asp:Label ID="lblsubtotal" CssClass="lblsubtotal" runat="server" Text='<%#Eval("QRRawMaterial_totalamt")%>' data-toggle="tooltip"></asp:Label>
                                                                        </div>                                                                        
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>

                                                                        <div style="float: right;">
                                                                            <ul style="list-style-type: none; margin: 0;">
                                                                              <span style="float:left;"> <i class="fa fa-inr"></i>&nbsp;&nbsp;</span>
                                                                                <i style="border-bottom: 0px; border-right: 0px;" id="lisubtotal">&nbsp;  
                                                                                               <asp:Label ID="lblsubtotalf" CssClass="lblsubtotalf" runat="server" Text="0"></asp:Label></i>
                                                                                <br />
                                                                               <span style="float:left;"> <i class="fa fa-inr"></i>&nbsp;&nbsp;</span>
                                                                                <i style="border-bottom: 0px; border-right: 0px;" id="lifreight">&nbsp;  
                                                                                               <asp:Label ID="lblfreight" CssClass="lblfreight" runat="server" Text="0"></asp:Label></i>
                                                                                <br />
                                                                               <span style="float:left;"> <i class="fa fa-inr"></i>&nbsp;&nbsp;</span>
                                                                                <i style="border-bottom: 0px; border-right: 0px;" id="ligrandtaxttotal">&nbsp;
                                                                                 <asp:Label ID="lblgrandtaxttotalf" runat="server" Text="0"></asp:Label></i>
                                                                                <br />
                                                                                <span style="float:left;"> <i class="fa fa-inr"></i>&nbsp;&nbsp;</span>
                                                                                <i style="border-bottom: 0px; border-right: 0px;" id="ligrandtotal">&nbsp;
                                                                                  <asp:Label ID="lblgrandtotalf" runat="server" Text="0"></asp:Label></i>
                                                                            </ul>
                                                                        </div>
                                                                        </div>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>

                                                                <%-- <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                                                <ItemTemplate>
                                                                    <div class="btn-group btn-group-xs">
                                                                        <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                                            CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <div class="btn-group btn-group-xs">
                                                                        <asp:LinkButton ID="lnkadd" data-toggle="tooltip" title="Add" class="btn btn-info" runat="server"
                                                                            CommandName="AddNewRow" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="gi gi-plus"></i></asp:LinkButton>
                                                                    </div>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>--%>
                                                                <%--  <asp:TemplateField HeaderText="Mobile" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("Principle_MobileNo")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="EmailID" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblemail" runat="server" Text='<%#Eval("Principle_EmailID")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="City" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcity" runat="server" Text='<%#Eval("Principle_City")%>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>--%>

                                                                <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                                                    <ItemTemplate>
                                                                        <div class="btn-group btn-group-xs">
                                                                            <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                                                CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <div class="btn-group btn-group-xs">
                                                                            <asp:LinkButton ID="lnkadd" ValidationGroup="grd1" data-toggle="tooltip" title="Add" class="btn btn-info" runat="server"
                                                                                CommandName="AddNewRow" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>">+</asp:LinkButton>
                                                                        </div>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="Right" BackColor="White" />
                                                            <FooterStyle HorizontalAlign="Center" BackColor="White" />
                                                            <PagerSettings PageButtonCount="4" />
                                                            <EmptyDataTemplate>
                                                                <h3>Add Product Detail</h3>
                                                                <div class="btn-group btn-group-xs" style="align-content: center;">
                                                                    <asp:LinkButton ID="lnkadd" data-toggle="tooltip" title="Add" class="btn btn-info" runat="server" Font-Size="20px" Width="100px"
                                                                        CommandName="Add" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"> Add Product</asp:LinkButton>
                                                                </div>
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
                                        <div style="clear: both;"></div>
                                        <br />
                                 <%--   </div>
                                </div>  --%>                              
                            </div>
                        </div>
                    </div>





                    <div class="widget">
                        <div class="widget-extra themed-background-dark">
                            <h4 class="widget-content-light">
                                <strong>Other</strong> Details
                            </h4>
                        </div>

                        <div class="widget-extra-full">
                            <div class="form-horizontal form-bordered">
                                <div class="col-md-12">
                                    <br />
                                </div>

                                <div class="col-md-4" style="display: none;">
                                    <div class="">
                                        <label class="col-md-3 control-label" for="example-hf-password">Total Amount<span> <i class="fa fa-inr "></i></span></label>
                                        <div class="col-md-9">
                                            <asp:Literal ID="lblamount" runat="server" Visible="false"></asp:Literal>
                                            <asp:Literal ID="lbltax" runat="server" Visible="false"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="">
                                        <label class="col-md-1 control-label" for="example-hf-password">Delivery Terms</label>
                                        <div class="col-md-11">
                                            <asp:TextBox ID="txtDeliveryTerms" runat="server" TextMode="MultiLine" Columns="4" data-toggle="tooltip" title="Terms Of Delivery" CssClass="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <div style="clear: both">
                                    <br />
                                </div>
                                <asp:UpdatePanel runat="server" ID="UpdatePanel6">
                                    <ContentTemplate>
                                        <div class="col-md-12" runat="server" id="DIVPTTX">
                                            <div class="">
                                                <label class="col-md-1 control-label" for="example-hf-password">Payment Terms</label>
                                                <div class="col-md-11">
                                                    <asp:TextBox ID="txtPaymentTerms" TextMode="MultiLine" Columns="4" runat="server" data-toggle="tooltip" title=" Payment Terms" CssClass="form-control"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="DDVendorType" />
                                        <%--<asp:PostBackTrigger ControlID="DDVendorType" />--%>
                                    </Triggers>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel runat="server" ID="UpdatePanel8">
                                    <ContentTemplate>
                                        <div class="col-md-4" runat="server" id="DIVPTDD">
                                            <div class="">
                                                <label class="col-md-3 control-label" for="example-hf-password">Payment Terms</label>
                                                <div class="col-md-9">
                                                    <asp:DropDownList ID="ddPaymentTerms" runat="server" class="form-control paytm select-chosen" onchange="jspaytm()">
                                                        <asp:ListItem Value="Advance " Text="Advance "></asp:ListItem>
                                                        <asp:ListItem Value="Payment against documents" Text="Payment against documents"></asp:ListItem>
                                                        <asp:ListItem Value="Credit" Text="Credit"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="DDVendorType" />
                                        <%--<asp:PostBackTrigger ControlID="DDVendorType" />--%>
                                    </Triggers>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel runat="server" ID="UPQT">
                                    <ContentTemplate>
                                        <div class="col-md-4" runat="server" id="DIVQuatationTerms">
                                            <div class="">
                                                <label class="col-md-4 control-label" for="example-hf-password">Quotation Terms<span></span></label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="ddQuatationTerms" runat="server" class="form-control select-chosen">
                                                        <asp:ListItem Value="EXW" Text="EXW"></asp:ListItem>
                                                        <asp:ListItem Value="FOB" Text="FOB"></asp:ListItem>
                                                        <asp:ListItem Value="CNF" Text="CNF"></asp:ListItem>
                                                        <asp:ListItem Value="CIF" Text="CIF"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="DDVendorType" />
                                        <%--<asp:PostBackTrigger ControlID="DDVendorType" />--%>
                                    </Triggers>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel runat="server" ID="UpdatePanel5">
                                    <ContentTemplate>
                                        <div class="col-md-4" runat="server" id="divplace">
                                            <div class="">
                                                <label class="col-md-4 control-label" for="example-hf-password">Place<span></span></label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="DDPLACE" runat="server" class="form-control select-chosen">
                                                        <asp:ListItem Value="Exwork " Text="Exwork "></asp:ListItem>
                                                        <asp:ListItem Value="Port" Text="Port"></asp:ListItem>
                                                        <asp:ListItem Value="Delivery Port" Text="Delivery Port"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="DDVendorType" />
                                        <%--<asp:PostBackTrigger ControlID="DDVendorType" />--%>
                                    </Triggers>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel runat="server" ID="UpdatePanel7">
                                    <ContentTemplate>
                                        <div class="col-md-12" id="divpayter" style="display:none;">
                                            <label class="col-md-1 control-label" for="example-hf-password">
                                                <asp:Label runat="server" ID="lblpaytype"></asp:Label></label>
                                            <div class="col-md-11">
                                                <asp:TextBox ID="txtpayterm" runat="server" TextMode="MultiLine" Columns="4" data-toggle="tooltip" title=" Payment Terms" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddPaymentTerms" />
                                        <%--<asp:PostBackTrigger ControlID="ddPaymentTerms" />--%>
                                    </Triggers>
                                </asp:UpdatePanel>
                                <%--<User:DocumentControl runat="server" ID="DocumentControl" />--%>
                                <div style="clear: both"></div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                    <div class="pull-right">
                        <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroup" />
                        <%--<asp:LinkButton ID="hfcancel" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/QuotationRequest.aspx" class="btn btn-alt btn-danger" />--%>
                        <a href="QuotationRequest.aspx" class="btn btn-alt btn-danger">Cancel</a>
                        <br />
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>


