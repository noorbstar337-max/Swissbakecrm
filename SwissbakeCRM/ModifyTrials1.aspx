<%@ Page Title="" Language="VB" MasterPageFile="~/LMSMasterPage.master" AutoEventWireup="false" CodeFile="ModifyTrials1.aspx.vb" Inherits="ModifyTrials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/jquery.min.js"></script>
    <script type="text/javascript">
        function Validate() {
            var isValid = false;
            isValid = Page_ClientValidate('MasterGroup2');
            //if (isValid) {
            //    isValid = Page_ClientValidate('MasterGroupRecipe');
            //}
            //if (isValid) {
            //    isValid = Page_ClientValidate('MasterGroupProc');
            //}
            return isValid;
        }
        function ValidateWithGrid() {
            var isValid = false;
            isValid = Page_ClientValidate('MasterGroup2');
            if (isValid) {
                isValid = Page_ClientValidate('MasterGroupRecipe');
            }
            if (isValid) {
                isValid = Page_ClientValidate('MasterGroupProc');
            }
            return isValid;
        }
    </script>
    <script>
        function onlyNos(e, t) {
            debugger;
            try {
                t.onkeypress = function (e) {
                    if (e.keyCode === 46 && this.value.split('.').length === 4) {
                        return false;
                    }
                }
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
        $(function () {
            $('input.number').keyup(function (event) {

                // skip for arrow keys
                if (event.which >= 37 && event.which <= 40) return;

                // format number
                $(this).val(function (index, value) {
                    return value
                    .replace(/\D/g, "")
                    .replace(/\B(?=(\d{3})+(?!\d))/g, ",")
                    ;
                });
            });

            $('input.numberIndian').keyup(function (event) {

                // skip for arrow keys
                if (event.which >= 37 && event.which <= 40) return;

                // format number
                $(this).val(function (index, value) {
                    //var x = value.replaceAll(',', '');
                    var x = value;
                    x = x.replace(/\D/g, "")
                    x = x.toString();
                    var afterPoint = '';
                    if (x.indexOf('.') > 0)
                        afterPoint = x.substring(x.indexOf('.'), x.length);
                    x = Math.floor(x);
                    x = x.toString();
                    var lastThree = x.substring(x.length - 3);
                    var otherNumbers = x.substring(0, x.length - 3);
                    if (otherNumbers != '')
                        lastThree = ',' + lastThree;
                    var res = otherNumbers.replace(/\B(?=(\d{2})+(?!\d))/g, ",") + lastThree + afterPoint;
                    return res;
                    //return value
                    //.replace(/\D/g, "")
                    //.replace(/\B(?=(\d{3})+(?!\d))/g, ",")
                    //;
                });
            });


            $('input.INR').keyup(function (event) {

                //Decimal
                //if (event.keyCode === 46 && this.value.split('.').length === 2) return false;
                // skip for arrow keys
                debugger;
                if (event.which >= 37 && event.which <= 40) return;

                // format number
                $(this).val(function (index, value) {
                    debugger;
                    var x = value;
                    //x = x.replace(/\W+/g, "")
                    x = x.replace(/,/g, "")
                    x = x.toString();
                    var afterPoint = '';

                    if (x.indexOf('.') > 0)
                        afterPoint = x.substring(x.indexOf('.'), x.length);
                    x = Math.floor(x);
                    x = x.toString();
                    var lastThree = x.substring(x.length - 3);
                    var otherNumbers = x.substring(0, x.length - 3);
                    if (otherNumbers != '')
                        lastThree = ',' + lastThree;
                    var res = otherNumbers.replace(/\B(?=(\d{2})+(?!\d))/g, ",") + lastThree + afterPoint;

                    return res;
                });
            });

            jQuery(function () {
                $(".mobile").keyup(function () {
                    debugger;
                    var VAL = this.value;

                    var email = new RegExp('^([+][9][1]|[9][1]|[0]){0,1}([7-9]{1})([0-9]{9})$');

                    if (email.test(VAL)) {


                    }
                    else if (VAL.length > 9) {
                        alert('not a valid no');
                    }
                });
            });




            $('.nos').keypress(function (event) {
                //if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
                //    event.preventDefault();
                //}
                debugger;

                if ((event.which != 46 || $(this).val().indexOf('.') != -1) && $(this).val().length < 0)
                    event.preventDefault();

                if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57))

                    event.preventDefault();
                if (($(this).val().indexOf('.') !== -1)) {
                    if (($(this).val().substring($(this).val().indexOf('.')).length > 4))
                        event.preventDefault();
                }
                //var input = $(this).val();
                //if ((input.indexOf('.') != -1) && (input.substring(input.indexOf('.')).length > 2)) {
                //    event.preventDefault();
                //}
            });

        });
    </script>


    <script type="text/javascript">

        function SetTarget() {

            document.forms[0].target = "_blank";

        }

    </script>
    <script type="text/javascript">
        function BakerPercent(txtIPercent) {
            debugger;
            var name = txtIPercent.id;
            var myString = (name).split("_");
            var txtIPercent = document.getElementById(txtIPercent.id.replace(myString[2], 'txtIPercent'));
            var name = txtIPercent.id;
            var myString = (name).split("_");
            var txtIValue = document.getElementById(txtIPercent.id.replace(myString[2], 'txtIValue'));
            //var lblRateOG = document.getElementById(txtIPercent.id.replace(myString[2], 'lblRateOG'));


            var txtFormTab = document.getElementById('<%= txtFormTab.ClientID%>');
            //var name = txtFormTab.value;
            //var myString = (name).split("_");
            //var txtIPercent = document.getElementById(txtIPercent.id.replace(myString[2], 'txtIPercent'));
            ////var name = txtQty.id;
            ////var myString = (name).split("_");
            //var txtIValue = document.getElementById(txtIPercent.id.replace(myString[2], 'txtIValue'));

            if (txtFormTab.value == "" && txtFormTab.value <= "0") {
                txtFormTab.value = 0;
            }
            if (txtIPercent.value == "" && txtIPercent.value <= "0") {
                txtIPercent.value = 0;
            }
            else {
                //   var txt = "#div21x2.2";
                var numb = txtFormTab.value.match(/\d/g);
                numb = numb.join("");

                var FVal = (numb * txtIPercent.value / 100);
                var id = $('#' + txtIValue.id);
                $('#' + txtIValue.id).val(FVal);
                //      $(id).val(FVal);

                //txtIValue.innerText = (txtFormTab.value * txtIPercent.value / 100).toString;
                //txtRate.value = hfOGRate.value - (parseFloat(hfOGRate.value) * parseFloat(txtDiscount.value) / 100).toFixed(2);
            }
            var total = document.getElementsByClassName('txtIValue');
            var lblsubtotalf = document.getElementsByClassName('lblsubtotalf');
            var sum = 0;

            for (var i = 0; i < total.length; ++i) {

                var item = total[i];
                sum = sum + parseFloat((item.value).replace(',', ''));
            }
            sum = sum + parseFloat(txtFormTab.value);
            $('#lisubtotal').text(parseFloat(sum).toFixed(2));
        }


    </script>
    <script>
        function BakerValue(txtIValue) {
            debugger;
            var name = txtIValue.id;
            var myString = (name).split("_");
            var txtIValue = document.getElementById(txtIValue.id.replace(myString[2], 'txtIValue'));
            var name = txtIValue.id;
            var myString = (name).split("_");
            var txtIPercent = document.getElementById(txtIValue.id.replace(myString[2], 'txtIPercent'));
            //var lblRateOG = document.getElementById(txtIPercent.id.replace(myString[2], 'lblRateOG'));
            var lblsubtotalf = document.getElementById(txtIValue.id.replace(myString[2], 'lblsubtotalf'));

            var txtFormTab = document.getElementById('<%= txtFormTab.ClientID%>');
            //var name = txtFormTab.value;
            //var myString = (name).split("_");
            //var txtIPercent = document.getElementById(txtIPercent.id.replace(myString[2], 'txtIPercent'));
            ////var name = txtQty.id;
            ////var myString = (name).split("_");
            //var txtIValue = document.getElementById(txtIPercent.id.replace(myString[2], 'txtIValue'));

            if (txtFormTab.value == "" && txtFormTab.value <= "0") {
                txtFormTab.value = 0;
            }
            if (txtIValue.value == "" && txtIValue.value <= "0") {
                txtIValue.value = 0;
            }
            else {
                //   var txt = "#div21x2.2";
                var numb = txtFormTab.value.match(/\d/g);
                numb = numb.join("");

                var FVal = (txtIValue.value / numb * 100).toFixed(2);
                var id = $('#' + txtIPercent.id);
                $('#' + txtIPercent.id).val(FVal);
                //      $(id).val(FVal);

                //txtIValue.innerText = (txtFormTab.value * txtIPercent.value / 100).toString;
                //txtRate.value = hfOGRate.value - (parseFloat(hfOGRate.value) * parseFloat(txtDiscount.value) / 100).toFixed(2);
            }
            var total = document.getElementsByClassName('txtIValue');
            var lblsubtotalf = document.getElementsByClassName('lblsubtotalf');
            var sum = 0;

            for (var i = 0; i < total.length; ++i) {

                var item = total[i];
                sum = sum + parseFloat((item.value).replace(',', ''));
            }
            sum = sum + parseFloat(txtFormTab.value);
            $('#lisubtotal').text(parseFloat(sum).toFixed(2));
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--    <div class="content-header header-section">
                <h1>Formulation
                </h1>
            </div>--%>
    <ul class="breadcrumb breadcrumb-top">
        <li><a href="LMSDashboard.aspx">Home</a></li>
        <li>Modify Trial</li>
        <asp:HiddenField ID="strrowcount" runat="server" />
        <asp:HiddenField ID="hfFormVersion" runat="server" />
        <asp:HiddenField ID="hfAccessFor" runat="server" />

    </ul>
     <div class="col-md-4 " id="div2" runat="server">
                                        <label for="example-nf-email" class="col-md-4 p-0">Execution Date </label>
                                        <div class="col-md-8">
                                            <%--<asp:TextBox ID="ddlDate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy"  min="Getdate" />--%>
                                            <asp:TextBox ID="ddlDate" runat="server" placeholder="Enter Execution Date" data-toggle="tooltip" title="Enter Execution Date" TextMode="Date"
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:TextBox ID="txtGetdate" runat="server" TextMode="Date" Style="display: none;" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlDate" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="This is Required" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="ComValEndTime" runat="server" ControlToValidate="ddlDate" ControlToCompare="txtGetdate"
                                                class="text-danger" ErrorMessage="This is invalid - This must be Greater" Display="Dynamic" Operator="GreaterThan" ValidationGroup="MasterGroup"></asp:CompareValidator>
                                        </div>

                                    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="block full ">
                <div class="block-title ">
                    <h2><strong>Modify Trial
                        <asp:Label ID="lblTrialCode" runat="server"></asp:Label></strong></h2>
                </div>

                <%-- <ul class="nav nav-pills nav-justified clickable-steps">
                    <li runat="server" id="liFormulation">
                        <asp:HyperLink runat="server" ID="lnkFormulation" style="background-color: #1bbae1;">
                        <span class="badge pull-right"></span>
                        <b><i class="gi gi-group themed-color-dark"></i></b><strong>&nbsp;&nbsp;Formulation</strong>
                        </asp:HyperLink>
                    </li>
                    <li runat="server" id="liRecipe" class="col-md-4">
                        <asp:HyperLink runat="server" ID="lnkRecipe">
                        <b><i class="fa fa-newspaper-o   themed-color-dark"></i></b>
                        <strong>&nbsp;&nbsp;Recipe</strong>
                        </asp:HyperLink>
                    </li>
                    <li runat="server" id="liTrial" class="col-md-4">
                        <asp:HyperLink runat="server" ID="lnkTrial">
                        <span class="badge pull-right"></span>
                        <b><i class="fa fa-gear themed-color-dark"></i></b><strong>&nbsp;&nbsp;Trial</strong>
                        </asp:HyperLink>
                    </li>
                </ul>
                <br />--%>
                <%--<div class="row">--%>
                <asp:HiddenField ID="hfBtnPrint" runat="server" />
                <div class="widget block full">
                    <%-- Fromulation Starts --%>
                    <div id="divFormulation" runat="server">
                        <div class="widget-extra themed-background-dark">
                            <h5 class="widget-content-light abc">
                                <strong>Formulation (<asp:Label ID="lblFormulationNo" runat="server" data-toggle="tooltip"></asp:Label>) 
                                <strong>
                                    <asp:Label runat="server" ID="lblapproved"></asp:Label></strong>
                                    <a runat="server" id="btnprint" class="btn btn-alt btn-xs btn-primary" target="_blank" style="margin-left: 10px;" visible="false">Print</a>
                                    <a runat="server" id="btnprintblank" class="btn btn-alt btn-xs btn-primary" target="_blank" visible="false">Print Blank</a> </strong>
                                <span class="pull-right" id="modifyspan" runat="server">By&nbsp;<a style="text-decoration: none;"><asp:Label ID="lblmodifiedname" runat="server" Font-Bold="true"></asp:Label></a>&nbsp;on&nbsp;<a style="text-decoration: none;"><asp:Label ID="lblmodifieddate" Font-Bold="true" runat="server" Font-Italic="true"></asp:Label></a>
                                </span>
                            </h5>

                        </div>

                        <div class="block full ">

                            <div class="widget-extra-full">
                                <div class="form-horizontal form-bordered  ">
                                    <asp:Panel runat="server" ID="pnlForm">
                                        <div class="col-md-12">
                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Always">
                                                <ContentTemplate>
                                                    <%--<script type="text/javascript">
                                                        Sys.Application.add_load(custom);
                                                    </script>--%>

                                                    <asp:HiddenField ID="hfCopyFormId" runat="server" />
                                                    <%--<asp:HiddenField ID="HiddenField1" runat="server" />--%>
                                                    <%-- Fromulation Starts --%>
                                                    <%--<div class="col-md-12">--%>
                                                    <%--<div class="widget">--%>
                                                    <%--<div class="block" style="display: table; width: 100%;">--%>
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                                                        <ContentTemplate>
                                                            <%--          <div class="col-lg-3">
                                                            <label for="example-nf-email" class="col-md-6">Formulation No.</label>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="lblFormulationNo" runat="server" data-toggle="tooltip" title="Enter Formulation No."></asp:Label>
                                                            </div>
                                                        </div>--%>
                                                            <div style="clear: both"></div>
                                                            <div class="row">
     <asp:TextBox ID="TextBox1" runat="server" placeholder="Enter Execution Date" data-toggle="tooltip" title="Enter Execution Date" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                                                <div class="col-md-3 mb-2">
                                                                    <label for="example-nf-email" class="col-md-6 p-0">Formulation Type</label>
                                                                    <div class="col-md-6">
                                                                        <asp:DropDownList ID="ddlFormulationType" runat="server" data-toggle="tooltip" title="Select Product Type" CssClass="form-control select-chosen" AutoPostBack="true">
                                                                            <asp:ListItem Value="0">Existing Product</asp:ListItem>
                                                                            <asp:ListItem Value="1">New Product</asp:ListItem>
                                                                            <asp:ListItem Value="2">Competitor Product</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <%--<asp:RequiredFieldValidator ID="rfddlFormulationType" runat="server" ControlToValidate="ddlFormulationType" ValidationGroup="MasterGroupF1" CssClass="MasterValidationCSS"
                                                                            ErrorMessage="This is required" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                                                    </div>

                                                                </div>
                                                                <div class="col-md-3 mb-2" id="divDDLProduct" runat="server">
                                                                    <label for="example-nf-email" class="col-md-3 p-0">Product </label>
                                                                    <div class="col-md-9">
                                                                        <asp:DropDownList ID="ddlProduct" runat="server" AutoPostBack="true" data-toggle="tooltip" title="Select Product" CssClass="form-control select-chosen">
                                                                        </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfddlProduct" runat="server" ControlToValidate="ddlProduct" ValidationGroup="MasterGroupF1" CssClass="MasterValidationCSS"
                                                                        ErrorMessage="This is Required" InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    </div>

                                                                </div>
                                                                <div class="col-md-3 mb-2" id="divTxtProduct" runat="server" visible="false">
                                                                    <label for="example-nf-email" class="col-md-3 p-0">Product </label>
                                                                    <div class="col-md-9">
                                                                        <asp:TextBox ID="txtProduct" runat="server" AutoPostBack="true" data-toggle="tooltip" placeholder="Enter Product" title="Enter Product" CssClass="form-control">
                                                                        </asp:TextBox>
                                                                        <asp:Label Visible="false" ID="lblProdExist" runat="server" Text="Product already Exist" ForeColor="Red"></asp:Label>
                                                                        <asp:RequiredFieldValidator ID="rftxtProduct" runat="server" ControlToValidate="txtProduct" ValidationGroup="MasterGroupF1" CssClass="MasterValidationCSS"
                                                                            ErrorMessage="This is required" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    </div>

                                                                </div>
                                                                <div class="col-md-3 mb-2" id="divCompeteProd" runat="server" visible="false">
                                                                    <label for="example-nf-email" class="col-md-5 p-0">Linked Product </label>
                                                                    <div class="col-md-7">
                                                                        <asp:DropDownList ID="ddlLinkProd" runat="server" AutoPostBack="true" data-toggle="tooltip" title="Select Product" CssClass="form-control select-chosen">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlLinkProd" ValidationGroup="MasterGroupF1" CssClass="MasterValidationCSS"
                                                                            ErrorMessage="This is Required" InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    </div>

                                                                </div>
                                                                <div class="col-md-3 mb-2" id="div1" runat="server">
                                                                    <label for="example-nf-email" class="col-md-3 p-0">Mix Type</label>
                                                                    <div class="col-md-9">
                                                                        <asp:DropDownList ID="ddlMixTypeForm" runat="server" data-toggle="tooltip" title="Select Product" CssClass="form-control select-chosen">
                                                                            <asp:ListItem Value="Bread & Improvers">Bread & Improvers</asp:ListItem>
                                                                            <asp:ListItem Value="Cake & Desserts">Cake & Desserts</asp:ListItem>
                                                                            <%--<asp:ListItem Value="Cream & Filling">Cream & Filling</asp:ListItem>--%>
                                                                        </asp:DropDownList>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlMixTypeForm" ValidationGroup="MasterGroupF1" CssClass="MasterValidationCSS"
                                                                            ErrorMessage="This is Required" Display="Dynamic"></asp:RequiredFieldValidator>--%>

                                                                        <asp:Label ID="lblMixError" runat="server" Style="color: red;" Visible="false">Please update Mix Type of selected Product</asp:Label>
                                                                    </div>

                                                                </div>

                                                                <%--<div style="clear: both"></div>
                                                                <br />--%>
                                                                <%--<div class="col-md-3 mb-2" id="divPriority" runat="server" >
                                                                    <label for="example-nf-email" class="col-md-3 p-0">Priority </label>
                                                                    <div class="col-md-9">
                                                                        <asp:DropDownList ID="ddlPriority" runat="server" data-toggle="tooltip" title="Select Product" CssClass="form-control select-chosen" >
                                                                            <asp:ListItem Value="High">High</asp:ListItem>
                                                                            <asp:ListItem Value="Medium">Medium</asp:ListItem>
                                                                            <asp:ListItem Value="Low">Low</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlPriority" ValidationGroup="MasterGroupF1" CssClass="MasterValidationCSS"
                                                                            ErrorMessage="This is Required" InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator>--% >
                                                                    </div>
                                                                       
                                                                </div>
                                                                <div class="col-md-3 mb-2" id="div2" runat="server" >
                                                                    <label for="example-nf-email" class="col-md-4 p-0">Execution Date </label>
                                                                    <div class="col-md-8">
                                                                        <%--<asp:TextBox ID="ddlDate" runat="server" TextMode="Date" CssClass="form-control" placeholder="mm/dd/yy"  min="Getdate" />--% >
                                                                        <asp:TextBox ID="ddlDate" runat="server" placeholder="Enter Execution Date" data-toggle="tooltip" title="Enter Execution Date" TextMode="Date"
                                                CssClass="form-control"></asp:TextBox>
                                                                        <asp:TextBox ID="txtGetdate" runat="server" placeholder="Enter Execution Date" data-toggle="tooltip" title="Enter Execution Date" TextMode="Date" style="display:none;"
                                                CssClass="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlDate" ValidationGroup="MasterGroupF1" CssClass="MasterValidationCSS"
                                                                            ErrorMessage="This is Required" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="ComValEndTime" runat="server"  ControlToValidate="ddlDate" ControlToCompare="txtGetdate"
                                              class="text-danger"   ErrorMessage="This is invalid - End time must be Greater" Display="Dynamic" Operator="GreaterThan"  ValidationGroup="MasterGroup"></asp:CompareValidator>
                                                                    </div>
                                                                     
                                                                </div>
                                                                --%>
                                                                <div class="col-md-3 mb-2" id="divQuantity" runat="server">
                                                                    <label for="example-nf-email" class="col-md-5 p-0">Quantity(KG) </label>
                                                                    <div class="col-md-7">
                                                                        <asp:TextBox ID="txtQuantityForm" runat="server" data-toggle="tooltip" placeholder="Enter Quantity" Text="1.000" onkeyup="this.value=this.value.replace(/[^\d\.]/g,'');" title="Enter Quantity" CssClass="form-control decimal"></asp:TextBox>
                                                                        <asp:Label ID="lblKG" runat="server" Style="color: red;" Visible="false">This is required</asp:Label>
                                                                        <asp:RequiredFieldValidator ID="RftxtQuantityForm" runat="server" ControlToValidate="txtQuantityForm" ValidationGroup="MasterGroupF1" CssClass="MasterValidationCSS"
                                                                            ErrorMessage="This is required" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegExptxtQuantityForm" runat="server" Display="Dynamic" ValidationGroup="MasterGroupF1" CssClass="MasterValidationCSS" ControlToValidate="txtQuantityForm" ErrorMessage="0 is not valid."
                                                                            ValidationExpression="^(?=.*[1-9])(?:[1-9]\d*\.?|0?\.)\d*$"></asp:RegularExpressionValidator>
                                                                    </div>

                                                                </div>
                                                            </div>

                                                            <%--<asp:Button ID="ntntest" ValidationGroup="1"  runat="server"  Text="test" />--%>
                                                            <div class="col-md-1 pull-right">
                                                                <asp:Button Text="Submit" runat="server" ID="btnSubmit" OnClientClick="if (!Page_ClientValidate('MasterGroupF1')){ return false; } this.disabled = true; this.value = 'Exploring...';"
                                                                    UseSubmitBehavior="false" class="btn btn-xs btn-success" ValidationGroup="MasterGroupF1" />
                                                                <%--<asp:Button Text="Submit Quotation" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup1')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup1" Style="width: 183px; border: 1px solid #A39A9A; padding: 7px; background-color: #B31616; color: white; margin-right: 15px;" />--%>
                                                            </div>
                                                            <div style="clear: both"></div>
                                                            <div id="divCompForm" runat="server">
                                                                <br />
                                                                <%--<asp:LinkButton  ID="btnCompareForm"  runat="server" Text="Compare" CssClass="btn btn-xs btn-danger" UseSubmitBehavior="false" ></asp:LinkButton>--%>
                                                                <%--OnClientClick="SetTarget();" OnClick="btnCompareForm_Click" target="_blank"
                                                                    NavigateUrl='<%# "compare.aspx?id=" + HttpUtility.UrlEncode(Security.Encrypt(hfCompareID.Value.ToString())) + "&&Levl=PR" + Eval("Recipe_Id").ToString()%>'--%>
                                                                <asp:Button ID="btnCompareForm" runat="server" Text="Compare Formulation" CssClass="btn btn-xs btn-danger" UseSubmitBehavior="false" Visible="false"></asp:Button>
                                                                <asp:Button ID="btnPasteCompareForm" runat="server" Text="Paste Formulation" CssClass="btn btn-xs btn-info"
                                                                    OnClientClick="this.value = 'Preparing your Formulation...';"
                                                                    UseSubmitBehavior="false" Visible="false" />
                                                                <br />
                                                                <small>
                                                                    <asp:Label ID="lblCompForm" runat="server" Text="Kindly Allow Pop-Up in your browser" Visible="false"></asp:Label></small>
                                                            </div>
                                                            <div style="clear: both"></div>

                                                            <br />
                                                            <br />
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="btnSubmit"/>
                                                        </Triggers>
                                                    </asp:UpdatePanel>

                                                    <%-- Form history --%>
                                                    <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                        <ContentTemplate>
                                                            <div id="divFormulationHistory" runat="server" class="col-md-12" visible="false">
                                                                <div id="Div5" runat="server">
                                                                    <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                                        <ContentTemplate>
                                                                            <table id="printtable" class="table table-vcenter table-condensed table-bordered" style="margin-bottom: 0px;">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Previous Formulation</th>

                                                                                        <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Action</th>
                                                                                    </tr>
                                                                                </thead>
                                                                                <tbody>
                                                                                    <asp:Repeater ID="rpFormHist" runat="server">
                                                                                        <ItemTemplate>
                                                                                            <tr>
                                                                                                <td class="text-center">
                                                                                                    <asp:Label ID="lblForm_Id" runat="server" Text='<%#Eval("Formulation_Id")%>' Visible="false"></asp:Label>
                                                                                                    <asp:Label ID="lblForm_No" runat="server" Text='<%#Eval("Formulation_No")%>'></asp:Label>

                                                                                                    <br />
                                                                                                </td>
                                                                                                <td class="text-center">
                                                                                                    <asp:LinkButton ID="btnCopyForm" Text="Copy Formulation" runat="server" class="btn btn-xs btn-success " CommandName="CopyFormulation" />
                                                                                                    <asp:HyperLink ID="HypLnkFormNo" Target="_blank" runat="server" class="btn btn-xs btn-success" href='<%# "PrintFormulation.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Formulation_Id")))%>'>
                                                                                                        <asp:Label ID="lblForm_No1" runat="server" Text="View"></asp:Label>
                                                                                                    </asp:HyperLink>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </ItemTemplate>
                                                                                    </asp:Repeater>
                                                                                </tbody>
                                                                            </table>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <%--<asp:AsyncPostBackTrigger ControlID="btnSubmit" />--%>
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </div>

                                                            </div>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <%--  <asp:PostBackTrigger ControlID="gvLMS" />--%>
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                    <div style="clear: both"></div>
                                                    <br />

                                                    <%-- Form History --%>

                                                    <div class="table-responsive">
                                                        <div class="widget-extra-full">
                                                            <div class="form-horizontal">
                                                                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">--%>
                                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                    <ContentTemplate>

                                                                        <div class="table-responsive">
                                                                            <asp:GridView ID="gvLMS" Visible="false" runat="server" AutoGenerateColumns="False" DataKeyNames="" AllowCustomPaging="true"
                                                                                CssClass="table table-striped table-vcenter table-condensed" ShowFooter="true" GridLines="None">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="RowNumber" Visible="true" />

                                                                                    <asp:TemplateField HeaderText="Sr No." Visible="False" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="">
                                                                                        <ItemTemplate>
                                                                                            <div class="input-group  col-md-12">
                                                                                                <div class="text-center">
                                                                                                    <asp:Literal ID="ltRowNumber" runat="server" Text='<%#Eval("RowNumber")%>' Visible="False"></asp:Literal>
                                                                                                </div>
                                                                                            </div>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>

                                                                                    <asp:TemplateField HeaderText="Raw Material" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="MasterGridviewHeader " ItemStyle-CssClass="MasterGridviewItem" ItemStyle-VerticalAlign="Middle">
                                                                                        <ItemTemplate>
                                                                                            <div class="col-md-12">
                                                                                                <asp:DropDownList ID="ddlRM" runat="server" CssClass="form-control select-chosen " AutoPostBack="true" OnSelectedIndexChanged="ddlRM_SelectedIndexChanged"></asp:DropDownList>
                                                                                                <asp:Literal ID="ltRMat" runat="server" Text='<%#Eval("FRawM_RawMID")%>' Visible="false"></asp:Literal>
                                                                                                <asp:RequiredFieldValidator ID="rfvddlRM" runat="server" InitialValue="0" ControlToValidate="ddlRM" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                                                                    ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                                            </div>
                                                                                        </ItemTemplate>
                                                                                        <%--<FooterTemplate>
                                                           <div class="col-md-12">
                                                                <strong><asp:Label ID="lblGvTotal" runat="server" Text="Total"  Visible="false" CssClass=" MasterGridviewItem"  ></asp:Label></strong>
                                                            </div>
                                                        </FooterTemplate>--%>
                                                                                    </asp:TemplateField>

                                                                                    <asp:TemplateField HeaderText="Quantity(%)" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="MasterGridviewHeader col-md-2" ItemStyle-CssClass="MasterGridviewItem" ItemStyle-VerticalAlign="Middle">
                                                                                        <ItemTemplate>
                                                                                            <div class="col-md-12">
                                                                                                <asp:TextBox ID="txtPercentage" runat="server" Text='<%#Convert.ToDecimal(Eval("FRawM_Percentage"))%>' OnTextChanged="txtPercentage_TextChanged" onkeyup="this.value=this.value.replace(/[^\d\.]/g,''); " MaxLength="6"
                                                                                                    AutoPostBack="true" CssClass="form-control MasterGridviewItem nos decimal"></asp:TextBox>
                                                                                                <%--<asp:TextBox ID="txtPercentage" runat="server" Text='<%#Bind("QRRawMaterial_Quantity", "0.00")%>' onChange="Calculate(this)" CssClass="form-control MasterGridviewItem nos decimal " ></asp:TextBox>--%>
                                                                                                <%--<asp:Literal ID="ltQuantity" runat="server" Text='<%#Eval("QRRawMaterial_Quantity")%>' Visible="false"></asp:Literal>--%>
                                                                                                <asp:RequiredFieldValidator ID="rfvddlQuantity" runat="server" ControlToValidate="txtPercentage" Display="Dynamic" InitialValue="" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                                                                    ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS" ControlToValidate="txtPercentage" ErrorMessage="0 is not valid."
                                                                                                    ValidationExpression="^(?=.*[1-9])(?:[1-9]\d*\.?|0?\.)\d*$"></asp:RegularExpressionValidator>
                                                                                            </div>

                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <div class="col-md-12">
                                                                                                <b>
                                                                                                    <asp:Label ID="lblPercentFoot" runat="server" Text='<%#Convert.ToDouble(Eval("FRawM_Percentage")).ToString("0.00")%>' Visible="false" CssClass=" MasterGridviewItem"></asp:Label></b>
                                                                                            </div>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Quantity(kg)" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="MasterGridviewHeader col-md-2" ItemStyle-CssClass="MasterGridviewItem" ItemStyle-VerticalAlign="Middle">
                                                                                        <ItemTemplate>
                                                                                            <div class="col-md-12">
                                                                                                <%--<asp:TextBox ID="TextBox1" runat="server" Text='<%#Convert.ToDouble(Eval("Quantity_kg")).ToString("0.000")%>' OnTextChanged="txtQ_kg_TextChanged"
                                                                  AutoPostBack="true" CssClass="form-control MasterGridviewItem nos decimal " ></asp:TextBox>--%>
                                                                                                <asp:TextBox ID="txtQ_kg" runat="server" Text='<%#Convert.ToDecimal(Eval("FRawM_QtyKg"))%>' OnTextChanged="txtQ_kg_TextChanged" onkeyup="this.value=this.value.replace(/[^\d\.]/g,'');"
                                                                                                    AutoPostBack="true" CssClass="form-control MasterGridviewItem nos decimal "></asp:TextBox>
                                                                                                <%--<asp:TextBox ID="txtQ_kg" runat="server" Text='<%#Bind("QRRawMaterial_Quantity", "0.00")%>' onChange="Calculate(this)" CssClass="form-control MasterGridviewItem nos decimal " ></asp:TextBox>--%>
                                                                                                <%--<asp:Literal ID="ltQuantity" runat="server" Text='<%#Eval("QRRawMaterial_Quantity")%>' Visible="false"></asp:Literal>--%>
                                                                                                <asp:RequiredFieldValidator ID="rfvtxtQ_kg" runat="server" ControlToValidate="txtQ_kg" Display="Dynamic" InitialValue="" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                                                                    ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                                                <asp:RegularExpressionValidator ID="RegExptxtQ_kg" runat="server" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS" ControlToValidate="txtQ_kg" ErrorMessage="0 is not valid."
                                                                                                    ValidationExpression="^(?=.*[1-9])(?:[1-9]\d*\.?|0?\.)\d*$"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <div class="col-md-12">
                                                                                                <%--<b><asp:Label ID="lblQuantityFoot" runat="server" Text='<%#Convert.ToDouble(Eval("Quantity_kg")).ToString("0.000")%>'  Visible="false" CssClass=" MasterGridviewItem"  ></asp:Label></b>
                                                               <br />--%>
                                                                                                <asp:Label ID="lblQFootError" runat="server" Style="color: red;" Visible="false">Raw Material usage exceeding</asp:Label>
                                                                                                <%--<asp:CompareValidator ID="cvtxtFoot" runat="server" ControlToValidate="txtQuantityFoot" ControlToCompare="txtQuantity" Operator="GreaterThan" ValidationGroup="MasterGroup" ErrorMessage="Raw Material usage exceeding"
                                                                                ForeColor="Red" Display="Dynamic" Type="Date"></asp:CompareValidator>--%>
                                                                                            </div>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Quantity(gm)" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="MasterGridviewHeader col-md-2" ItemStyle-CssClass="MasterGridviewItem" ItemStyle-VerticalAlign="Middle">
                                                                                        <ItemTemplate>
                                                                                            <div class="col-md-12">
                                                                                                <%--<asp:TextBox ID="TextBox1" runat="server" Text='<%#Convert.ToDouble(Eval("Quantity_gm")).ToString("0.0")%>' OnTextChanged="txtQ_gm_TextChanged" 
                                                                 AutoPostBack="true" CssClass="form-control MasterGridviewItem nos decimal" ></asp:TextBox>--%>
                                                                                                <asp:TextBox ID="txtQ_gm" runat="server" Text='<%#Convert.ToDecimal(Eval("FRawM_QtyGm"))%>' OnTextChanged="txtQ_gm_TextChanged" onkeyup="this.value=this.value.replace(/[^\d\.]/g,'');"
                                                                                                    AutoPostBack="true" CssClass="form-control MasterGridviewItem nos decimal"></asp:TextBox>
                                                                                                <%--<asp:TextBox ID="txtQ_gm" runat="server" Text='<%#Bind("QRRawMaterial_Quantity", "0.00")%>' onChange="Calculate(this)" CssClass="form-control MasterGridviewItem nos decimal " ></asp:TextBox>--%>
                                                                                                <%--<asp:Literal ID="ltQuantity" runat="server" Text='<%#Eval("QRRawMaterial_Quantity")%>' Visible="false"></asp:Literal>--%>
                                                                                                <asp:RequiredFieldValidator ID="rftxtQ_gm" runat="server" ControlToValidate="txtQ_gm" Display="Dynamic" InitialValue="0" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                                                                    ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                                                <asp:RegularExpressionValidator ID="RegExptxtQ_gm1" runat="server" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS" ControlToValidate="txtQ_gm" ErrorMessage="0 is not valid."
                                                                                                    ValidationExpression="^(?=.*[1-9])(?:[1-9]\d*\.?|0?\.)\d*$"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <div runat="server" id="divfootvat">
                                                                                                <asp:Label ID="lblTotCost" runat="server" Visible="false">Total Cost:</asp:Label>
                                                                                                <%--<br />--%>
                                                                                                <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" runat="server" id="hr1" visible="false" />
                                                                                                <asp:Label ID="lblTotCostKg" runat="server" Visible="false">Cost/Kg:</asp:Label>
                                                                                                <%--<br />--%>
                                                                                                <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" runat="server" id="hr2" visible="false" />
                                                                                                <asp:Label ID="lblQuanFoot" runat="server" Visible="false">Total Quantity(Kg):</asp:Label>
                                                                                                <%--</div>
                                                           <div class="col-md-12">--%>
                                                                                                <b>
                                                                                                    <asp:Label ID="lblQGmfoot" runat="server" Visible="false" CssClass=" MasterGridviewItem"></asp:Label></b>
                                                                                                <%--<b><asp:Label ID="lblQGmfoot" runat="server" Text='<%#Convert.ToDouble(Eval("Quantity_gm")).ToString("0.0")%>'  Visible="false" CssClass=" MasterGridviewItem"  ></asp:Label></b>--%>
                                                                                                <%--<br />--%>
                                                                                            </div>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>

                                                                                    <asp:TemplateField HeaderText="Cost" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="MasterGridviewHeader col-md-2" ItemStyle-CssClass="MasterGridviewItem" ItemStyle-VerticalAlign="Middle">
                                                                                        <ItemTemplate>
                                                                                            <div class="col-md-12">
                                                                                                <asp:TextBox ID="txtCost" runat="server" Text='<%#Convert.ToDecimal(Eval("FRawM_Cost"))%>' onkeyup="this.value=this.value.replace(/[^\d\.]/g,'');"
                                                                                                    CssClass="form-control MasterGridviewItem" OnTextChanged="txtCost_TextChanged"></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator ID="RftxtCost" runat="server" ControlToValidate="txtCost" InitialValue="" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                                                                    ErrorMessage="This is required" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                                <%--<asp:RegularExpressionValidator ID="RegExptxtCost" runat="server" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS" ControlToValidate="txtCost" ErrorMessage="Enter valid cost."
                                                                                                ValidationExpression="^(?=.*[1-9])(?:[1-9]\d*\.?|0?\.)\d*$"></asp:RegularExpressionValidator>--%>
                                                                                            </div>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <div runat="server" id="divfootvat1">
                                                                                                <strong>
                                                                                                    <asp:Label ID="lblTotalCost" runat="server" Visible="false"></asp:Label></strong>
                                                                                                <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" runat="server" id="hr3" visible="false" />

                                                                                                <b>
                                                                                                    <asp:Label ID="lblTotCostGm" runat="server" Visible="false"></asp:Label></b>
                                                                                                <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" runat="server" id="hr4" visible="false" />

                                                                                                <b>
                                                                                                    <asp:Label ID="lblQuantityFoot" runat="server" Visible="false" CssClass=" MasterGridviewItem"></asp:Label></b>
                                                                                                <%-- <div id="divCalc" class="btn-group btn-group-xs">
                                                                    <asp:LinkButton ID="Calc" data-toggle="tooltip" title="Calculate Total" class="btn btn-success" runat="server" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Adding...';"
                                                                        CommandName="TotalCost" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-calculator"></i></asp:LinkButton>
                                                            </div>--%>
                                                                                            </div>

                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>

                                                                                    <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                                                                        <ItemTemplate>
                                                                                            <div class="btn-group btn-group-xs">
                                                                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                                                                    CommandName="deleteLink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                                                                            </div>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <div id="divLknAdd" class="btn-group btn-group-xs">
                                                                                                <asp:LinkButton ID="lnkadd" data-toggle="tooltip" title="Add" class="btn btn-info" runat="server" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Adding...';"
                                                                                                    CommandName="AddFormulaNewRow" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-plus"></i></asp:LinkButton>
                                                                                            </div>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>

                                                                                <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="Right" BackColor="White" />
                                                                                <FooterStyle HorizontalAlign="Center" BackColor="White" />
                                                                                <PagerSettings PageButtonCount="4" />
                                                                                <EmptyDataTemplate>
                                                                                </EmptyDataTemplate>
                                                                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                                                            </asp:GridView>
                                                                            <asp:Literal runat="server" ID="Literal4"></asp:Literal>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="gvLMS" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                                <div style="clear: both"></div>

                                                                <div id="divBtnForm" runat="server" class="col-md-12" style="margin-bottom: 5px; display: table; margin-top: -8px;">
                                                                    <div class="col-md-6 btn-group btn-group-xs">
                                                                        <%--<User:LMSAssignControl ID="LMSassigncontrol" runat="server" Visible="false" />--%>
                                                                    </div>
                                                                    <div class="pull-right btn-group btn-group-xs">
                                                                        <asp:LinkButton ID="btnCalc" data-toggle="tooltip" Visible="false" title="Calculate Total" class="btn btn-success" runat="server"
                                                                            OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Adding...';"><i class="fa fa-calculator"></i></asp:LinkButton>

                                                                        <%--<asp:Button Text="Save" runat="server" ID="btnSave" Visible="false" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                                                        UseSubmitBehavior="false" class="btn btn-xs btn-info" ValidationGroup="MasterGroup" />--%>
                                                                        <%--<asp:LinkButton ID="hfcancel" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="SampleRequest.aspx" class="btn btn-alt btn-sm btn-danger" TabIndex="15" />--%>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <%--</div>--%>
                                                    <%--</div>--%>
                                                    <%--</div>--%>
                                                    <%-- Formulation Ends --%>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <%--  <asp:AsyncPostBackTrigger ControlID="ddltourname" EventName="SelectedIndexChanged" />--%>
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </asp:Panel>
                                    <div class="col-md-12 ">
                                        <div class="text-center   btn-group-xs ">
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnFormulationCancel" runat="server" Text="Cancel" NavigateUrl="~/Trials.aspx"
                                                        UseSubmitBehavior="false" CssClass="btn btn-alt btn-sm btn-primary "></asp:Button>
                                                    <asp:Button ID="btnFormulationSaveApprove" runat="server" Text="Save & Approve" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                                        UseSubmitBehavior="false" ValidationGroup="MasterGroup" CssClass="btn btn-sm btn-info " Visible="false" />
                                                    <asp:Button ID="btnFormulationSaveNext" runat="server" Text="Save & Next" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                                        UseSubmitBehavior="false" ValidationGroup="MasterGroup" CssClass="btn btn-sm btn-succes " Visible="false" />

                                                    <%--   <asp:Button ID="BtnSavePayment" runat="server" Text="Save & Payment" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                                UseSubmitBehavior="false" ValidationGroup="MasterGroup" CssClass="btn btn-alt btn-sm btn-primary " />--%>

                                                    <asp:Button ID="btnFormulationSave" runat="server" Text="Save" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                                        UseSubmitBehavior="false" ValidationGroup="MasterGroup" CssClass="btn btn-alt btn-sm btn-succes" Visible="false" />

                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnSubmit" />
                                                </Triggers>
                                            </asp:UpdatePanel>


                                        </div>
                                    </div>
                                    <div style="clear: both"></div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%--</div>--%>
                    <%-- Formulation Ends --%>



                    <%-- Recipe Starts --%>
                    <%--<div class="widget" >--%>
                    <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                        <ContentTemplate>
                            <div id="divRecipe1" runat="server" visible="false">
                                <asp:HiddenField ID="hfddlId" runat="server" />
                                <asp:HiddenField ID="hfGridId" runat="server" />
                                <asp:HiddenField ID="hfGroup" runat="server" />
                                <asp:HiddenField ID="hfCompareID" runat="server" />

                                <%--<div class="block full ">--%>
                                <div class="widget-extra themed-background-dark">
                                    <h5 class="widget-content-light abc">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <strong>Recipe (<asp:Label ID="lblRecipeNo" runat="server" data-toggle="tooltip" title="Recipe No."></asp:Label>
                                                    <asp:Label runat="server" ID="lblType" Style="color: white; text-align: center;"></asp:Label>)</strong>
                                                <strong>
                                                    <asp:Label runat="server" ID="lblRecApproved" Style="color: white;"></asp:Label></strong>
                                                <a runat="server" id="btnprintRec" class="btn btn-alt btn-xs btn-primary" target="_blank" style="margin-left: 10px;" visible="false">Print</a>
                                                <a runat="server" id="btnprtBlankRec" class="btn btn-alt btn-xs btn-primary" target="_blank" visible="false">Print Blank</a> </strong>
                                        <%--<strong style="text-align:center"><asp:Label runat="server" ID="lblType" Style="color:white; text-align:center;"></asp:Label></strong>--%>
                                                <span class="pull-right" id="modifyspanRec" runat="server">By&nbsp;<a style="text-decoration: none;"><asp:Label ID="lblmodifiednameRecipe" runat="server" Font-Bold="true"></asp:Label></a>&nbsp;on&nbsp;<a style="text-decoration: none;"><asp:Label ID="lblmodifieddateRecipe" Font-Bold="true" runat="server" Font-Italic="true"></asp:Label></a>
                                                </span>
                                            </ContentTemplate>
                                            <Triggers>
                                                <%--<asp:AsyncPostBackTrigger ControlID="btnSubmit" />--%>
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <%--  --%>
                                        <h5></h5>
                                        <h5></h5>
                                    </h5>
                                </div>
                                <asp:Panel runat="server" ID="pnlRecipe">
                                    <div class="block full ">

                                        <div class="widget-extra-full">
                                            <div class="form-horizontal form-bordered form-group ">
                                                <%-- Recipe Starts --%>

                                                <%--<div class="widget">--%>

                                                <asp:HiddenField ID="HiddenField2" runat="server" />


                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="false">
                                                    <ContentTemplate>
                                                        <div id="divFormulationType" runat="server" class="col-md-3">
                                                            <label for="example-nf-email" class="col-md-6">Formulation Type</label>
                                                            <div class="col-md-6">
                                                                <asp:DropDownList ID="ddlFormTypeRecipe" runat="server" data-toggle="tooltip" title="Select Product Type" CssClass="form-control select-chosen" AutoPostBack="true">
                                                                    <asp:ListItem Value="0">Existing Product</asp:ListItem>
                                                                    <asp:ListItem Value="1">New Product</asp:ListItem>
                                                                    <asp:ListItem Value="2">Competitor Product</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlFormulationType" ValidationGroup="MasterGroup2" CssClass="MasterValidationCSS"
                                                                    ErrorMessage="This is required" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                <br />
                                                            </div>
                                                        </div>

                                                        <div class="col-md-3" id="divDDLProductRecipe" runat="server" visible="false">
                                                            <label for="example-nf-email" class="col-md-3">Product </label>
                                                            <div class="col-md-9">
                                                                <asp:DropDownList ID="ddlProductRecipe" runat="server" AutoPostBack="true" data-toggle="tooltip" title="Select Product" CssClass="form-control select-chosen">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlProduct" ValidationGroup="MasterGroup2" CssClass="MasterValidationCSS"
                                                                    ErrorMessage="This is required" InitialValue="Select Product" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3" id="divTxtProductRecipe" runat="server" visible="false">
                                                            <label for="example-nf-email" class="col-md-3">Product </label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox ID="txtProductRecipe" runat="server" data-toggle="tooltip" placeholder="Enter Product" title="Enter Product" CssClass="form-control">
                                                                </asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtProduct" ValidationGroup="MasterGroup2" CssClass="MasterValidationCSS"
                                                                    ErrorMessage="This is required" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div id="divFormulationNo" runat="server" class="col-lg-3" visible="false">
                                                            <label for="example-nf-email" class="col-md-4">Formulation No.</label>
                                                            <div class="col-md-8">
                                                                <asp:DropDownList ID="ddlFormulationNo" runat="server" data-toggle="tooltip" title="Select Formulation No" CssClass="form-control select-chosen" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlFormulationNo" ValidationGroup="MasterGroup2" CssClass="MasterValidationCSS"
                                                                    ErrorMessage="This is required" InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div style="clear: both"></div>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <%--  <asp:PostBackTrigger ControlID="gvLMS" />--%>
                                                    </Triggers>
                                                </asp:UpdatePanel>

                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <ContentTemplate>
                                                        <div class="col-md-12">
                                                            <asp:Label runat="server" class="col-md-1"><h6><strong>Machines</strong></h6></asp:Label>
                                                            <div class="col-md-11">
                                                                <div class="col-md-3">
                                                                    <label for="example-nf-email" class="col-md-4">
                                                                        <h6>Mixer</h6>
                                                                    </label>
                                                                    <div class="col-md-8">
                                                                        <asp:DropDownList ID="ddlMixer" runat="server" data-toggle="tooltip" title="Select Machine 1" CssClass="form-control select-chosen">
                                                                            <asp:ListItem Value="Spiral Mixer">Spiral Mixer</asp:ListItem>
                                                                            <asp:ListItem Value="Planetory Mixer">Planetory Mixer</asp:ListItem>
                                                                            <asp:ListItem Value="Small Planetory Mixer">Small Planetory Mixer</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlMixer" ValidationGroup="MasterGroup2" CssClass="MasterValidationCSS"
                                                                            ErrorMessage="This is required" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                        <br />
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <label for="example-nf-email" class="col-md-4">
                                                                        <h6>Blade</h6>
                                                                    </label>
                                                                    <div class="col-md-8">
                                                                        <asp:DropDownList ID="ddlBlade" runat="server" data-toggle="tooltip" title="Select Machine 2" CssClass="form-control select-chosen">
                                                                            <asp:ListItem Value="Wisk">Wisk</asp:ListItem>
                                                                            <asp:ListItem Value="Hook">Hook</asp:ListItem>
                                                                            <asp:ListItem Value="Padle">Padle</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlBlade" ValidationGroup="MasterGroup2" CssClass="MasterValidationCSS"
                                                                            ErrorMessage="This is required" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                        <br />
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <label for="example-nf-email" class="col-md-4">
                                                                        <h6>Mould/Tray</h6>
                                                                    </label>
                                                                    <div class="col-md-8">
                                                                        <asp:DropDownList ID="ddlMould" runat="server" data-toggle="tooltip" title="Select Machine 3" CssClass="form-control select-chosen">
                                                                            <asp:ListItem Value="Round">Round</asp:ListItem>
                                                                            <asp:ListItem Value="Rectangle">Rectangle</asp:ListItem>
                                                                            <asp:ListItem Value="Square">Square</asp:ListItem>
                                                                            <asp:ListItem Value="Aluminium Cups">Aluminium Cups</asp:ListItem>
                                                                            <asp:ListItem Value="Muffin Cups">Muffin Cups</asp:ListItem>
                                                                            <asp:ListItem Value="Buget Trays">Buget Trays</asp:ListItem>
                                                                            <asp:ListItem Value="Potato Buns Trays">Potato Buns Trays</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlMould" ValidationGroup="MasterGroup2" CssClass="MasterValidationCSS"
                                                                            ErrorMessage="This is required" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                        <br />
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <label for="example-nf-email" class="col-md-4">
                                                                        <h6>Equipment</h6>
                                                                    </label>
                                                                    <div class="col-md-8">
                                                                        <asp:DropDownList ID="ddlOven" runat="server" data-toggle="tooltip" title="Select Machine 4" CssClass="form-control select-chosen">
                                                                            <asp:ListItem Value="Stone Oven">Stone Oven</asp:ListItem>
                                                                            <asp:ListItem Value="Metal Oven">Metal Oven</asp:ListItem>
                                                                            <asp:ListItem Value="Waffle Machine">Waffle Machine</asp:ListItem>
                                                                            <asp:ListItem Value="Pancake Machine">Pancake Machine</asp:ListItem>
                                                                            <asp:ListItem Value="Frier">Frier</asp:ListItem>
                                                                            <asp:ListItem Value="Depositer">Depositer</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlOven" ValidationGroup="MasterGroup2" CssClass="MasterValidationCSS"
                                                                            ErrorMessage="This is required" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                        <br />
                                                                    </div>
                                                                </div>
                                                                <%--<div id="divQuantityRecipe" class="col-md-3" runat="server" visible="false">
                                                        <label for="example-nf-email" class="col-md-5">Quantity(KG) </label>
                                                        <div class="col-md-7">
                                                            <asp:TextBox ID="txtQuantityRecipe" runat="server" data-toggle="tooltip" placeholder="Enter Quantity" title="Enter Quantity" CssClass="form-control decimal" TabIndex="3">
                                                            </asp:TextBox>
                                                            <asp:Label ID="Label26" runat="server" Style="color: red;" Visible="false">This is required</asp:Label>
                                                            <asp:RequiredFieldValidator ID="rFtxtQuantityRecipe" runat="server" ControlToValidate="txtQuantityRecipe" ValidationGroup="MasterGroup2" CssClass="MasterValidationCSS"
                                                                ErrorMessage="This is required" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="rEtxtQuantityRecipe" runat="server" Display="Dynamic" ValidationGroup="MasterGroup2" CssClass="MasterValidationCSS" ControlToValidate="txtQuantityRecipe" ErrorMessage="0 is not valid."
                                                                ValidationExpression="^(?=.*[1-9])(?:[1-9]\d*\.?|0?\.)\d*$"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>--%>
                                                            </div>
                                                        </div>
                                                        <div>
                                                            <br />
                                                            <%--<asp:LinkButton  ID="btnCompareForm"  runat="server" Text="Compare" CssClass="btn btn-xs btn-danger" UseSubmitBehavior="false" ></asp:LinkButton>--%>
                                                            <%--OnClientClick="SetTarget();" OnClick="btnCompareForm_Click" target="_blank"
                                                                    NavigateUrl='<%# "compare.aspx?id=" + HttpUtility.UrlEncode(Security.Encrypt(hfCompareID.Value.ToString())) + "&&Levl=PR" + Eval("Recipe_Id").ToString()%>'--%>
                                                            <asp:Button ID="btnCompareRecipe" runat="server" Text="Compare Recipe" CssClass="btn btn-xs btn-danger" UseSubmitBehavior="false" Visible="false"></asp:Button>
                                                            <asp:Button ID="btnPasteCompareRecipe" runat="server" Text="Paste Recipe" CssClass="btn btn-xs btn-info"
                                                                OnClientClick="this.value = 'Preparing your Recipe...';" UseSubmitBehavior="false" Visible="false" />
                                                            <br />
                                                            <small>
                                                                <asp:Label ID="lblCompRecipe" runat="server" Text="Kindly Allow Pop-Up in your browser" Visible="false"></asp:Label></small>
                                                        </div>
                                                        <div style="clear: both"></div>
                                                        <br />
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <%--  <asp:PostBackTrigger ControlID="gvLMS" />--%>
                                                    </Triggers>
                                                </asp:UpdatePanel>

                                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                    <ContentTemplate>
                                                        <div id="divRecipeHistory" runat="server" class="col-md-12" visible="false">
                                                            <div id="faq188f" class="panel-group">
                                                                <div class="panel panel-default">
                                                                    <div class="panel-heading">
                                                                        <h4 class="panel-title"><a class="accordion-toggle" data-toggle="collapse" data-parent="#faq188f" href="#faq188f_q188">
                                                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblRecipeHistory" Text="Recipe History" runat="server"></asp:Label>
                                                                                </ContentTemplate>
                                                                                <Triggers>
                                                                                    <asp:AsyncPostBackTrigger ControlID="ddlFormulationNo" />
                                                                                </Triggers>
                                                                            </asp:UpdatePanel>
                                                                        </a>
                                                                            <h4></h4>
                                                                            <h4></h4>
                                                                            <h4></h4>
                                                                        </h4>
                                                                    </div>
                                                                    <div id="faq188f_q188" class="panel-collapse collapse in" style="max-height: 303px; overflow: auto;">
                                                                        <div class="col-md-12">
                                                                            <br />
                                                                            <div id="faq1881" class="panel-group" runat="server">
                                                                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                                    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">--%>
                                                                                    <ContentTemplate>
                                                                                        <asp:Repeater ID="rpRecipeHistory" runat="server">
                                                                                            <ItemTemplate>

                                                                                                <div class="panel panel-default">
                                                                                                    <div class="panel-heading">
                                                                                                        <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq1881" href='<%#"#" + Eval("Recipe_Id").ToString%>'>
                                                                                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                                                                <ContentTemplate>
                                                                                                                    <asp:Label ID="lblRecipe_No" runat="server" Text='<%#Eval("Recipe_No")%>'></asp:Label>
                                                                                                                    <asp:Label ID="lblRecipe_Id" runat="server" Text='<%#Eval("Recipe_Id")%>' Visible="false"></asp:Label>
                                                                                                                    <asp:LinkButton ID="btnCopyRecipe" Text="Copy Recipe" runat="server" class="btn btn-xs btn-success pull-right" CommandName="CopyRecipe" />
                                                                                                                    <%-- <div class="pull-right">
                                                                <asp:Label ID="lblAmt" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                                                <asp:HyperLink ID="hledit" EnableViewState="false" NavigateUrl='<%# "ModifyExpense.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Ex_Id").ToString()))%>'
                                                                    class="btn btn-alt btn-xs btn-primary" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                                            </div>--%>
                                                                                                                </ContentTemplate>

                                                                                                            </asp:UpdatePanel>
                                                                                                        </a></h4>
                                                                                                    </div>
                                                                                                    <div id='<%#Eval("Recipe_Id").ToString%>' class="panel-collapse collapse" style="height: 0px; max-height: 100px; overflow: auto;">
                                                                                                        <div class="panel-body">
                                                                                                            <%--<asp:LinkButton ID="LinkButton1" Text="" runat="server" />--%>
                                                                                                            <%--<asp:LinkButton ID="btnCopyRecipe" Text="Copy Recipe" runat="server" class="btn btn-xs btn-success pull-right" CommandName="CopyRecipe" />--%>
                                                                                                            <div style="clear: both"></div>

                                                                                                            <div class="col-md-6" style="border: 1px solid Black;">
                                                                                                                <asp:Label runat="server"><b><small>Ingredients</small></b></asp:Label>
                                                                                                                <div class="table-responsive">
                                                                                                                    <asp:GridView ID="gvRecipeIngDisplay" ShowFooter="true" GridLines="None" CssClass="table table-striped table-vcenter" HeaderStyle-Width="100"
                                                                                                                        HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Smaller" CellPadding="0" CellSpacing="0" runat="server" AutoGenerateColumns="false">
                                                                                                                        <Columns>
                                                                                                                            <asp:TemplateField HeaderText="Name" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                                                                                                <HeaderTemplate>
                                                                                                                                    <asp:HyperLink ID="HyperLink11" runat="server">Name</asp:HyperLink>
                                                                                                                                </HeaderTemplate>
                                                                                                                                <ItemTemplate>
                                                                                                                                    <asp:Literal ID="ltproductname" runat="server" Text='<%#Eval("RecipeIngredient_Name")%>'></asp:Literal>
                                                                                                                                    <asp:Literal ID="ltitemid" runat="server" Text='<%#Eval("RecipeIngredient_Name")%>' Visible="false"></asp:Literal>

                                                                                                                                </ItemTemplate>
                                                                                                                            </asp:TemplateField>
                                                                                                                            <asp:TemplateField HeaderText="Value" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                                                                                                <HeaderTemplate>
                                                                                                                                    <asp:HyperLink ID="HyperLink12" runat="server">Value</asp:HyperLink>
                                                                                                                                </HeaderTemplate>
                                                                                                                                <ItemTemplate>
                                                                                                                                    <asp:Literal ID="ltproductcode" runat="server" Text='<%#Eval("RecipeIngredient_Value")%>'></asp:Literal>
                                                                                                                                    <asp:Label ID="ltitemtypeid" runat="server" Text='<%#Eval("RecipeIngredient_Value")%>' Visible="false"></asp:Label>
                                                                                                                                </ItemTemplate>
                                                                                                                            </asp:TemplateField>
                                                                                                                            <asp:TemplateField HeaderText="Percent" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                                                                                                <HeaderTemplate>
                                                                                                                                    <asp:HyperLink ID="HyperLink13" runat="server">Percent</asp:HyperLink>
                                                                                                                                </HeaderTemplate>
                                                                                                                                <ItemTemplate>
                                                                                                                                    <asp:Literal ID="ltproductWeight" runat="server" Text='<%#Eval("RecipeIngredient_Percent")%>' Visible="false"></asp:Literal>
                                                                                                                                    <asp:Literal ID="ltIngredient_Percent" runat="server" Text='<%#Eval("RecipeIngredient_Percent")%>'></asp:Literal>
                                                                                                                                </ItemTemplate>
                                                                                                                            </asp:TemplateField>

                                                                                                                        </Columns>
                                                                                                                        <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="left" BackColor="White" />
                                                                                                                        <FooterStyle HorizontalAlign="left" BackColor="White" />
                                                                                                                        <PagerSettings PageButtonCount="4" />
                                                                                                                        <EmptyDataTemplate>
                                                                                                                            <asp:Label ID="lblError" runat="server" Text="No Data Found"></asp:Label><br />
                                                                                                                            <br />
                                                                                                                        </EmptyDataTemplate>
                                                                                                                        <EmptyDataRowStyle HorizontalAlign="Center" />
                                                                                                                    </asp:GridView>
                                                                                                                </div>
                                                                                                            </div>
                                                                                                            <div class="col-md-6" style="border: 1px solid Black;">
                                                                                                                <asp:Label runat="server"><b><small>Procedure</small></b></asp:Label>
                                                                                                                <div class="table-responsive">
                                                                                                                    <asp:GridView ID="gvRecipeProcDisplay" ShowFooter="true" GridLines="None" CssClass="table table-striped table-vcenter" HeaderStyle-Width="100"
                                                                                                                        HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Smaller" CellPadding="0" CellSpacing="0" runat="server" AutoGenerateColumns="false">
                                                                                                                        <Columns>
                                                                                                                            <asp:TemplateField HeaderText="Method" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                                                                                                <HeaderTemplate>
                                                                                                                                    <asp:HyperLink ID="HyperLink11" runat="server">Method</asp:HyperLink>
                                                                                                                                </HeaderTemplate>
                                                                                                                                <ItemTemplate>
                                                                                                                                    <asp:Literal ID="ltproductname" runat="server" Text='<%#Eval("RecipeProcedure_Step")%>'></asp:Literal>
                                                                                                                                    <asp:Literal ID="ltitemid" runat="server" Text='<%#Eval("RecipeProcedure_Step")%>' Visible="false"></asp:Literal>
                                                                                                                                </ItemTemplate>
                                                                                                                            </asp:TemplateField>
                                                                                                                            <asp:TemplateField HeaderText="Term" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                                                                                                <HeaderTemplate>
                                                                                                                                    <asp:HyperLink ID="HyperLink12" runat="server">Term</asp:HyperLink>
                                                                                                                                </HeaderTemplate>
                                                                                                                                <ItemTemplate>
                                                                                                                                    <asp:Literal ID="ltproductcode" runat="server" Text='<%#Eval("RecipeProcedure_Term")%>'></asp:Literal>
                                                                                                                                    <asp:Label ID="ltitemtypeid" runat="server" Text='<%#Eval("RecipeProcedure_Term")%>' Visible="false"></asp:Label>
                                                                                                                                </ItemTemplate>
                                                                                                                            </asp:TemplateField>
                                                                                                                            <asp:TemplateField HeaderText="Time" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                                                                                                                <HeaderTemplate>
                                                                                                                                    <asp:HyperLink ID="HyperLink13" runat="server">Time</asp:HyperLink>
                                                                                                                                </HeaderTemplate>
                                                                                                                                <ItemTemplate>
                                                                                                                                    <asp:Literal ID="ltproductWeight" runat="server" Text='<%#Eval("RecipeProcedure_Time")%>' Visible="false"></asp:Literal>
                                                                                                                                    <asp:Literal ID="ltpackingpacking" runat="server" Text='<%#Eval("RecipeProcedure_Time")%>'></asp:Literal>
                                                                                                                                </ItemTemplate>
                                                                                                                            </asp:TemplateField>

                                                                                                                        </Columns>
                                                                                                                        <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="left" BackColor="White" />
                                                                                                                        <FooterStyle HorizontalAlign="left" BackColor="White" />
                                                                                                                        <PagerSettings PageButtonCount="4" />
                                                                                                                        <EmptyDataTemplate>
                                                                                                                            <asp:Label ID="s" runat="server" Text="No Data Found"></asp:Label><br />
                                                                                                                            <br />
                                                                                                                        </EmptyDataTemplate>
                                                                                                                        <EmptyDataRowStyle HorizontalAlign="Center" />
                                                                                                                    </asp:GridView>
                                                                                                                </div>
                                                                                                            </div>

                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>

                                                                                            </ItemTemplate>
                                                                                        </asp:Repeater>
                                                                                    </ContentTemplate>
                                                                                    <Triggers>

                                                                                        <asp:AsyncPostBackTrigger ControlID="rpRecipeHistory" />
                                                                                        <asp:AsyncPostBackTrigger ControlID="ddlFormulationNo" />
                                                                                    </Triggers>
                                                                                </asp:UpdatePanel>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <%--  <asp:PostBackTrigger ControlID="gvLMS" />--%>
                                                    </Triggers>
                                                </asp:UpdatePanel>

                                                <%-- </div>
                                    <div class="block" style ="display:table;width:100%;">--%>
                                                <div class="col-md-6" style="border-right: 1px dotted red; border-top: 2px dotted red;">
                                                    <h6><strong>Ingredients</strong></h6>
                                                    <div class="table-responsive">
                                                        <div class="widget-extra-full">
                                                            <div class="form-horizontal">


                                                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:HiddenField ID="hfFRNo" runat="server" />
                                                                        <div class="table-responsive">
                                                                            <table class="table table-vcenter  table-responsive" style="margin-bottom: 0;">
                                                                                <tr style="background-color: #f9f9f9">
                                                                                    <td class="text-center " style="font-size: 12px; font-weight: 600; width: 31%">
                                                                                        <b>Name</b>
                                                                                    </td>
                                                                                    <td class="text-center" style="font-size: 12px; font-weight: 600; width: 31%">
                                                                                        <b>Value (GM)</b>
                                                                                    </td>
                                                                                    <td class="text-center " style="font-size: 12px; font-weight: 600;">
                                                                                        <b>Percentage (%)</b>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="text-center " style="width: 31%">
                                                                                        <asp:Label runat="server" ID="lblFormNoTab"></asp:Label>
                                                                                    </td>
                                                                                    <td class="text-center " style="display: flex;">
                                                                                        <asp:TextBox ID="txtFormTab" runat="server" CssClass="form-control MasterGridviewItem" onkeyup="this.value=this.value.replace(/[^\d]/g,'');"></asp:TextBox>&nbsp;<asp:Label runat="server" Text=" GM" Style="margin: 4px 0px; display: none;"></asp:Label>
                                                                                        <asp:RequiredFieldValidator ID="rfvFormTab" runat="server" ControlToValidate="txtFormTab" Display="Dynamic" ValidationGroup="MasterGroupRecipe" CssClass="MasterValidationCSS"
                                                                                            ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtFormTab" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                                                            ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                                                                    </td>
                                                                                    <td class="text-center ">100</td>
                                                                                </tr>
                                                                            </table>
                                                                            <asp:GridView ID="gvIngredient" runat="server" AutoGenerateColumns="False" DataKeyNames="" AllowCustomPaging="true"
                                                                                CssClass="table table-striped table-vcenter table-condensed" ShowFooter="true" GridLines="None">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="RowNumber" Visible="false" />

                                                                                    <%--<asp:TemplateField HeaderText="Sr No." Visible="False" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="">--%>
                                                                                    <asp:TemplateField HeaderText="Sr No." Visible="False">
                                                                                        <ItemTemplate>
                                                                                            <script type="text/javascript">
                                                                                                Sys.Application.add_load(BakerPercent);
                                                                                                Sys.Application.add_load(BakerValue);
                                                                                            </script>
                                                                                            <div class="input-group  col-md-12">
                                                                                                <div class="text-center">
                                                                                                    <asp:Literal ID="ltRowNumberIng" runat="server" Text='<%#Eval("RowNumber")%>' Visible="False"></asp:Literal>
                                                                                                </div>
                                                                                            </div>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>

                                                                                    <%--<asp:TemplateField HeaderText="Name" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="text-center col-md-6" ItemStyle-CssClass="MasterGridviewItem" ItemStyle-VerticalAlign="Middle">--%>
                                                                                    <asp:TemplateField HeaderStyle-CssClass="text-center ">
                                                                                        <%-- <HeaderTemplate>Name<br>  
                                                                               <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" runat="server" id="hr1" Visible="false" />
                                                                               <asp:Label runat="server" ID="lblFRNo" Visible="false"></asp:Label>
                                                                           </HeaderTemplate>--%>
                                                                                        <ItemTemplate>
                                                                                            <div>
                                                                                                <%--<asp:Label ID="lblFormNo" runat="server"  CssClass=" MasterGridviewItem " text="as" ></asp:Label>--%>
                                                                                                <asp:TextBox ID="txtIName" runat="server" Text='<%#Bind("RecipeIngredient_Name")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                                <asp:Literal ID="ltRMat" runat="server" Text='<%#Eval("RecipeIngredient_Name")%>' Visible="false"></asp:Literal>
                                                                                                <asp:RequiredFieldValidator ID="rfvtxtIName" runat="server" ControlToValidate="txtIName" Display="Dynamic" ValidationGroup="MasterGroupRecipe" CssClass="MasterValidationCSS"
                                                                                                    ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                                            </div>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <i style="border-bottom: 0px; border-right: 0px;" id="li">&nbsp;  
                                                                                               <asp:Label ID="lblTot" CssClass="lblsubtotalf" runat="server" Text="Total"></asp:Label></i>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>

                                                                                    <%--<asp:TemplateField HeaderText="Value" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="text-center col-md-3" ItemStyle-CssClass="MasterGridviewItem" ItemStyle-VerticalAlign="Middle">--%>
                                                                                    <asp:TemplateField HeaderStyle-CssClass="text-center ">
                                                                                        <ItemTemplate>
                                                                                            <div>
                                                                                                <asp:TextBox ID="txtIValue" runat="server" onkeyup="this.value=this.value.replace(/[^\d\.]/g,''); BakerValue(this);" Text='<%#Bind("RecipeIngredient_Value")%>' CssClass="txtIValue form-control MasterGridviewItem  "></asp:TextBox>
                                                                                                <%--<asp:TextBox ID="txtIValue" onkeypress="return griddecimal(event,this);" runat="server" Text='<%#Bind("RecipeIngredient_Value")%>' CssClass="form-control MasterGridviewItem  "></asp:TextBox>--%>
                                                                                                <asp:RequiredFieldValidator ID="rfvtxtIValue" runat="server" ControlToValidate="txtIValue" Display="Dynamic" ValidationGroup="MasterGroupRecipe" CssClass="MasterValidationCSS"
                                                                                                    ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ValidationGroup="MasterGroupRecipe" CssClass="MasterValidationCSS" ControlToValidate="txtIValue" ErrorMessage="This is required"
                                                                                        ValidationExpression="^(?=.*[1-9])(?:[1-9]\d*\.?|0?\.)\d*$"></asp:RegularExpressionValidator>--%>
                                                                                            </div>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <i style="border-bottom: 0px; border-right: 0px;" id="lisubtotal">&nbsp;  
                                                                                               <asp:Label ID="lblsubtotalf" CssClass="lblsubtotalf" runat="server" Text="0"></asp:Label></i>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>

                                                                                    <%--<asp:TemplateField HeaderText="Percentage" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="text-center col-md-3" ItemStyle-CssClass="MasterGridviewItem" ItemStyle-VerticalAlign="Middle">--%>
                                                                                    <asp:TemplateField HeaderStyle-CssClass="text-center ">
                                                                                        <ItemTemplate>
                                                                                            <div>
                                                                                                <asp:TextBox ID="txtIPercent" runat="server" onkeyup="this.value=this.value.replace(/[^\d\.]/g,''); BakerPercent(this);" Text='<%#Bind("RecipeIngredient_Percent")%>' CssClass="form-control MasterGridviewItem"></asp:TextBox>
                                                                                                <%--<asp:TextBox ID="txtIPercent" runat="server" Text='<%#Bind("RecipeIngredient_Percent")%>' onkeypress="return griddecimal(event,this);" CssClass="form-control MasterGridviewItem"></asp:TextBox>--%>
                                                                                                <asp:RequiredFieldValidator ID="RftxtIPercent" runat="server" ControlToValidate="txtIPercent" ValidationGroup="MasterGroupRecipe" CssClass="MasterValidationCSS"
                                                                                                    ErrorMessage="This is required" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                                <%--<asp:RegularExpressionValidator ID="RegExptxtIPercent" runat="server" Display="Dynamic" ValidationGroup="MasterGroupRecipe" CssClass="MasterValidationCSS" ControlToValidate="txtIPercent" ErrorMessage="This is required"
                                                                                        ValidationExpression="^(?=.*[1-9])(?:[1-9]\d*\.?|0?\.)\d*$"></asp:RegularExpressionValidator>--%>
                                                                                            </div>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>

                                                                                    <%--<asp:TemplateField ItemStyle-Width="10px" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">--%>
                                                                                    <asp:TemplateField HeaderStyle-CssClass="text-center ">
                                                                                        <ItemTemplate>
                                                                                            <div class="btn-group btn-group-xs">
                                                                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                                                                    CommandName="deleteRecipeLink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                                                                            </div>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <div id="divLknAdd" class="btn-group btn-group-xs">
                                                                                                <asp:LinkButton ID="lnkadd" data-toggle="tooltip" title="Add" class="btn btn-info" runat="server" OnClientClick="if (!Page_ClientValidate('MasterGroupRecipe')){ return false; } this.disabled = true; this.value = 'Adding...';"
                                                                                                    CommandName="AddRecipeNewRow" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-plus"></i></asp:LinkButton>
                                                                                            </div>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>

                                                                                <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="Right" BackColor="White" />
                                                                                <FooterStyle HorizontalAlign="Center" BackColor="White" />
                                                                                <PagerSettings PageButtonCount="4" />
                                                                                <EmptyDataTemplate>
                                                                                    <asp:Label ID="lblError" runat="server" Text="No Data Found"></asp:Label><br />
                                                                                    <br />
                                                                                </EmptyDataTemplate>
                                                                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                                                            </asp:GridView>
                                                                            <asp:Literal runat="server" ID="Literal1"></asp:Literal>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="gvIngredient" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <%--<div style="clear: both"></div>--%>
                                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Label runat="server"><h6><strong>Remarks for ingredients</strong></h6></asp:Label>
                                                            <div class="table-responsive">
                                                                <div class="widget-extra-full">
                                                                    <asp:TextBox ID="txtRemarkIngre" runat="server" placeholder="Enter Remarks" TextMode="MultiLine" Columns="1" Rows="3" data-toggle="tooltip" title="Remarks" CssClass="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="gvIngredient" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>

                                                </div>
                                                <div class="col-md-6" style="border-left: 1px dotted red; border-top: 2px dotted red;">
                                                    <h6><strong>Procedure</strong></h6>

                                                    <div class="table-responsive">
                                                        <div class="widget-extra-full">
                                                            <div class="form-horizontal">
                                                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="table-responsive">
                                                                            <asp:GridView ID="gvProcedure" runat="server" AutoGenerateColumns="False" DataKeyNames="" AllowCustomPaging="true"
                                                                                CssClass="table table-striped table-vcenter table-condensed" ShowFooter="true" GridLines="None">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="RowNumber" Visible="false" />

                                                                                    <asp:TemplateField HeaderText="Sr No." Visible="False" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="">
                                                                                        <ItemTemplate>
                                                                                            <div class="input-group  col-md-12">
                                                                                                <div class="text-center">
                                                                                                    <asp:Literal ID="ltRowNumberProc" runat="server" Text='<%#Eval("RowNumber")%>' Visible="False"></asp:Literal>
                                                                                                </div>
                                                                                            </div>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>

                                                                                    <asp:TemplateField HeaderText="Method" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="text-center col-md-4" ItemStyle-CssClass="MasterGridviewItem" ItemStyle-VerticalAlign="Middle">
                                                                                        <ItemTemplate>
                                                                                            <div class="col-md-12">
                                                                                                <asp:TextBox ID="txtProcStep" runat="server" Text='<%#Bind("RecipeProcedure_Step")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                                <asp:Literal ID="ltRMat" runat="server" Text='<%#Eval("RecipeProcedure_Step")%>' Visible="false"></asp:Literal>
                                                                                                <asp:RequiredFieldValidator ID="rfvtxtProcStep" runat="server" ControlToValidate="txtProcStep" Display="Dynamic" ValidationGroup="MasterGroupProc" CssClass="MasterValidationCSS"
                                                                                                    ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                                            </div>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>

                                                                                    <asp:TemplateField HeaderText="Term" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="text-center col-md-4" ItemStyle-CssClass="MasterGridviewItem" ItemStyle-VerticalAlign="Middle">
                                                                                        <ItemTemplate>
                                                                                            <div class="col-md-12">
                                                                                                <asp:TextBox ID="txtProcTerm" runat="server" Text='<%#Bind("RecipeProcedure_Term")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator ID="rfvtxtProcTerm" runat="server" ControlToValidate="txtProcTerm" Display="Dynamic" ValidationGroup="MasterGroupProc" CssClass="MasterValidationCSS"
                                                                                                    ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                                            </div>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>

                                                                                    <asp:TemplateField HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="text-center col-md-4" ItemStyle-CssClass="MasterGridviewItem" ItemStyle-VerticalAlign="Middle">
                                                                                        <HeaderTemplate>Time/Value <i class="fa fa-clock-o"></i></HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <div class="col-md-12">
                                                                                                <div class="input-group bootstrap-timepicker">
                                                                                                    <%--<asp:TextBox ID="txtProcTime" runat="server" Text='<%#Bind("RecipeProcedure_Time")%>' placeHolder="HH:MM" CssClass="form-control MasterGridviewItem" onkeypress="return onlyNos(event,this);" onkeyup="insertColon(this,'txtProcTime');" onblur="Coloncheck(this,'txtProcTime');" MaxLength="5"></asp:TextBox>--%>
                                                                                                    <asp:TextBox ID="txtProcTime" runat="server" Text='<%#Bind("RecipeProcedure_Time")%>' CssClass="form-control MasterGridviewItem"></asp:TextBox>

                                                                                                    <asp:RequiredFieldValidator ID="RftxtProcTime" runat="server" ControlToValidate="txtProcTime" ValidationGroup="MasterGroupProc" CssClass="MasterValidationCSS"
                                                                                                        ErrorMessage="This is required" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                                    <%--<asp:RegularExpressionValidator ID="RegExptxtProcTime" runat="server" Display="Dynamic" ValidationGroup="MasterGroupProc" CssClass="MasterValidationCSS"	ControlToValidate="txtProcTime" ErrorMessage="0 is not valid."
																	ValidationExpression="^(?=.*[1-9])(?:[1-9]\d*\.?|0?\.)\d*$"></asp:RegularExpressionValidator>--%>
                                                                                                    <%--<asp:RegularExpressionValidator id=RegularExpressionValidator1 runat="server" ErrorMessage="* Please enter in correct format for Time." Display="Dynamic" ControlToValidate="txtProcTime" 
                                                                        ValidationExpression="^([1-9]|1[0-2]|0[1-9]){1}(:[0-5][0-9][aApP][mM]){1}$ " ValidationGroup="MasterGroupProc"></asp:RegularExpressionValidator>--%>
                                                                                                </div>
                                                                                            </div>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>

                                                                                    <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                                                                        <ItemTemplate>
                                                                                            <div class="btn-group btn-group-xs">
                                                                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                                                                    CommandName="deleteProcedureLink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                                                                            </div>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <div id="divLknAdd" class="btn-group btn-group-xs">
                                                                                                <asp:LinkButton ID="lnkadd" data-toggle="tooltip" title="Add" class="btn btn-info" runat="server" OnClientClick="if (!Page_ClientValidate('MasterGroupProc')){ return false; } this.disabled = true; this.value = 'Adding...';"
                                                                                                    CommandName="AddProcedureNewRow" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-plus"></i></asp:LinkButton>
                                                                                            </div>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>

                                                                                <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="Right" BackColor="White" />
                                                                                <FooterStyle HorizontalAlign="Center" BackColor="White" />
                                                                                <PagerSettings PageButtonCount="4" />
                                                                                <EmptyDataTemplate>
                                                                                    <asp:Label ID="lblError" runat="server" Text="No Data Found"></asp:Label><br />
                                                                                    <br />
                                                                                </EmptyDataTemplate>
                                                                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                                                            </asp:GridView>
                                                                            <asp:Literal runat="server" ID="Literal2"></asp:Literal>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="gvProcedure" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div style="clear: both"></div>
                                                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                        <ContentTemplate>
                                                            <h6><strong>Remarks for procedure</strong></h6>
                                                            <div class="table-responsive">
                                                                <div class="widget-extra-full">
                                                                    <asp:TextBox ID="txtRemarkProc" runat="server" placeholder="Enter Remarks" TextMode="MultiLine" Columns="1" Rows="3" data-toggle="tooltip" title="Remarks" CssClass="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="gvProcedure" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>

                                                <div style="clear: both"></div>

                                                <%--</div>--%>
                                                <%--</div>--%>
                                                <%--</div>--%>
                                                <%-- Recipe Ends --%>
                                            </div>
                                        </div>
                                        <%--</div>--%>
                                    </div>
                                </asp:Panel>
                                <div class="col-md-12 " id="divStatusRemark" runat="server" visible="false">
                                    <h6><strong>Remarks for Approval/Disapproval</strong></h6>
                                    <div class="table-responsive">
                                        <div class="widget-extra-full">
                                            <asp:TextBox ID="txtAppDisApp" runat="server" placeholder="Enter Remarks" TextMode="MultiLine" Columns="1" Rows="3" data-toggle="tooltip" title="Remarks" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtAppDisApp" ValidationGroup="MasterGroup3" CssClass="MasterValidationCSS"
                                                ErrorMessage="This is required" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 ">
                                    <div class="col-md-4 " id="divPriority" runat="server">
                                        <label for="example-nf-email" class="col-md-3 p-0">Priority </label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlPriority" runat="server" data-toggle="tooltip" title="Select Product" CssClass="form-control select-chosen">
                                                <asp:ListItem Value="High">High</asp:ListItem>
                                                <asp:ListItem Value="Medium">Medium</asp:ListItem>
                                                <asp:ListItem Value="Low">Low</asp:ListItem>
                                            </asp:DropDownList>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlPriority" ValidationGroup="MasterGroupF1" CssClass="MasterValidationCSS"
                                                                            ErrorMessage="This is Required" InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                        </div>

                                    </div>
                                   
                                </div>
                                <div style="clear: both"></div>
                                    <br />
                                <%--</div>--%>


                                <div class="col-md-12 ">
                                    <div class="text-center btn-group-xs ">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <%--  <asp:Button ID="btnRecipePrevious" runat="server" Text="Previous"
                                        UseSubmitBehavior="false" ValidationGroup="MemberGroup" CssClass="btn btn-alt btn-sm  btn-primary " />--%>
                                                <asp:Button ID="btnRecipeSaveApprove" runat="server" Text="Approve" OnClientClick="if (!Page_ClientValidate('MasterGroup3')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                                    UseSubmitBehavior="false" ValidationGroup="MasterGroup" CssClass="btn btn-sm btn-info " Visible="false" />
                                                <asp:Button ID="btnRecipeDisApprove" runat="server" Text="Reject" OnClientClick="if (!Page_ClientValidate('MasterGroup3')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                                    UseSubmitBehavior="false" ValidationGroup="MasterGroup" CssClass="btn btn-sm btn-danger " Visible="false" />
                                                <asp:Button ID="btnOnlyRecipeSave" runat="server" Text="Save" OnClientClick="if (!Validate()){ return false; } this.disabled = true; this.value = 'Saving...';"
                                                    UseSubmitBehavior="false" CssClass="btn btn-sm  btn-success " Visible="false" />
                                                <%--<asp:Button ID="btnRecipeSaveNext" runat="server" Text="Save & Next" OnClientClick="if (!Page_ClientValidate('MemberGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                UseSubmitBehavior="false" ValidationGroup="MasterGroupProc MasterGroupRecipe" CssClass="btn btn-alt btn-sm  btn-primary " />--%>
                                                <asp:Button ID="btnBothFormReciSave" ValidationGroup="MasterGroup" runat="server" Text="Save" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                                    UseSubmitBehavior="false" CssClass="btn  btn-sm  btn-success " Visible="false" />
                                                <asp:Button ID="btnRecipeSaveNew" runat="server" Text="Save As New" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                                    UseSubmitBehavior="false" CssClass="btn btn-alt btn-sm btn-success " Visible="false" />
                                                <asp:Button ID="btnRecipeCancel" runat="server" Text="Cancel" NavigateUrl="~/Trials.aspx"
                                                    UseSubmitBehavior="false" CssClass="btn btn-sm btn-warning "></asp:Button>
                                                <asp:Button ID="btnAddFeedback" runat="server" Text="Add Feedback" Visible="false"
                                                    UseSubmitBehavior="false" CssClass="btn btn-sm btn-primary " />
                                                <asp:LinkButton ID="btnViewFeedback" runat="server" Text="View Feedback" Visible="false"
                                                    UseSubmitBehavior="false" CssClass="btn btn-alt btn-sm btn-primary " target="_blank" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <%--<asp:AsyncPostBackTrigger ControlID="btnSubmit" />--%>
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>

                                </div>
                            </div>

                            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px; padding-bottom: 2em;">
                                <div class="col-md-6 btn-group btn-group-xs">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <User:LMSAssignControl ID="LMSassigncontrol1" runat="server" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnFormulationSave" />
                                            <asp:AsyncPostBackTrigger ControlID="btnFormulationSaveApprove" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>

                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnFormulationSave" />
                            <asp:AsyncPostBackTrigger ControlID="btnFormulationSaveApprove" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <%-- Recipe Ends --%>

                    <%--progress starts--%>
                    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="" runat="server" DisplayAfter="0">
                        <ProgressTemplate>
                            <br />
                            <div class="divWaiting">
                                <i class="fa fa-sun-o fa-spin" id="LoadingUpadatePanel"></i>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <%--Progress ends--%>
                </div>

            </div>
        </div>
    </div>
</asp:Content>


