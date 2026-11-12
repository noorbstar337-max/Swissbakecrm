<%@ Page Title="" Language="VB" MasterPageFile="~/LMSMasterPage.master" AutoEventWireup="false" CodeFile="ModifyFeedback.aspx.vb" Inherits="ModifyFeedback" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script>
        function checktime(element, txt) {
            //debugger;
            var name = element.id;
            var myString = (name).split("_");
            var txtQty = document.getElementById(element.id.replace(myString[2], txt));
            var name = txtQty.id;
            var myString = (name).split("_");
            var txtBenchTime = document.getElementById(txtQty.id.replace(myString[2], 'txtBenchTime'));
            var txtScaleTime = document.getElementById(txtQty.id.replace(myString[2], 'txtScaleTime'));
            var txtInProoferTime = document.getElementById(txtQty.id.replace(myString[2], 'txtInProoferTime'));
            var txtInOvenTime = document.getElementById(txtQty.id.replace(myString[2], 'txtInOvenTime'));
            var txtOutOvenTime = document.getElementById(txtQty.id.replace(myString[2], 'txtOutOvenTime'));

            var lblBulkferment = document.getElementById(txtQty.id.replace(myString[2], 'lblBulkferment'));
            var lblProofing = document.getElementById(txtQty.id.replace(myString[2], 'lblProofing'));
            var lblBakingTime = document.getElementById(txtQty.id.replace(myString[2], 'lblBakingTime'));


            if (txtBenchTime.value != '' && txtScaleTime.value != '') {

                //var myString1 = (txtBenchTime.value).split(":");
                //var t1 = (parseInt(myString1[0]) * 60) + parseInt(myString1[1]);
                //var myString1 = (txtScaleTime.value).split(":");
                //var t2 = (parseInt(myString1[0]) * 60) + parseInt(myString1[1]);
                //var diff = t1 - t2;
                //lblBulkferment.textContent = convertMinsToHrsMins(diff);
                lblBulkferment.textContent = diffTime(txtBenchTime.value, txtScaleTime.value);
            }



            if (txtInProoferTime.value != '' && txtInOvenTime.value != '') {
                //var myString1 = (txtInProoferTime.value).split(":");
                //var t1 = (parseInt(myString1[0]) * 60) + parseInt(myString1[1]);
                //var myString1 = (txtInOvenTime.value).split(":");
                //var t2 = (parseInt(myString1[0]) * 60) + parseInt(myString1[1]);
                //var diff = t1 - t2;
                //lblProofing.textContent = convertMinsToHrsMins(diff);
                lblProofing.textContent = diffTime(txtInProoferTime.value, txtInOvenTime.value);
            }
            if (txtInOvenTime.value != '' && txtOutOvenTime.value != '') {
                //var myString1 = (txtInOvenTime.value).split(":");
                //var t1 = (parseInt(myString1[0]) * 60) + parseInt(myString1[1]);
                //var myString1 = (txtOutOvenTime.value).split(":");
                //var t2 = (parseInt(myString1[0]) * 60) + parseInt(myString1[1]);
                //var diff = t1 - t2;
                //lblBakingTime.textContent = convertMinsToHrsMins(diff);
                lblBakingTime.textContent = diffTime(txtInOvenTime.value, txtOutOvenTime.value);
            }

        }
        function pad(num) {
            return ("0" + num).slice(-2);
        }

        function diffTime(start, end) {
            var s = start.split(":"), sMin = +s[1] + s[0] * 60,
                e = end.split(":"), eMin = +e[1] + e[0] * 60,
             diff = eMin - sMin;
            if (diff < 0) { sMin -= 12 * 60; diff = eMin - sMin }
            var h = Math.floor(diff / 60),
                m = diff % 60;
            return "" + pad(h) + ":" + pad(m);
        }
        function convertMinsToHrsMins(minutes) {
            var h = Math.floor(minutes / 60);
            var m = minutes % 60;
            h = h < 10 ? '0' + h : h;
            m = m < 10 ? '0' + m : m;
            return h + ':' + m;
        }
    </script>
    <script>
        jQuery(function ($) {

            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_beginRequest(function (source, args) {


            });

            prm.add_endRequest(function (source, args) {
                debugger;
                $(function () {
                    $(".fileuploadM").change(function () {

                        if (typeof (FileReader) != "undefined") {
                            var dvPreview = $("#dvPreview");
                            // dvPreview.html("");
                            var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                            $($(this)[0].files).each(function () {
                                var file = $(this);
                                if (regex.test(file[0].name.toLowerCase())) {
                                    var reader = new FileReader();
                                    reader.onload = function (e) {
                                        var img = $("<img />");
                                        img.attr("style", "height:100px;width: 100px");
                                        img.attr("src", e.target.result);
                                        dvPreview.append(img);
                                    }
                                    reader.readAsDataURL(file[0]);
                                } else {
                                    alert(file[0].name + " is not a valid image file.");
                                    dvPreview.html("");
                                    return false;
                                }
                            });
                        } else {
                            alert("This browser does not support HTML5 FileReader.");
                        }
                    });
                });
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $(".fileuploadM").change(function () {

                if (typeof (FileReader) != "undefined") {
                    var dvPreview = $("#dvPreview");
                    // dvPreview.html("");
                    var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                    $($(this)[0].files).each(function () {
                        var file = $(this);
                        if (regex.test(file[0].name.toLowerCase())) {
                            var reader = new FileReader();
                            reader.onload = function (e) {
                                var img = $("<img />");
                                img.attr("style", "height:100px;width: 100px");
                                img.attr("src", e.target.result);
                                dvPreview.append(img);
                            }
                            reader.readAsDataURL(file[0]);
                        } else {
                            alert(file[0].name + " is not a valid image file.");
                            dvPreview.html("");
                            return false;
                        }
                    });
                } else {
                    alert("This browser does not support HTML5 FileReader.");
                }
            });
        });
    </script>


    <script>


        $(function () {
            $("#btnSaveFile").bind("click", function () {
                if (typeof ($("#FuImage")[0].files) != "undefined") {
                    var size = parseFloat($("#FuImage")[0].files[0].size / 1024).toFixed(2);
                    alert(size + " KB.");
                } else {
                    alert("This browser does not support HTML5.");
                }
            });
        });


        $(".fileuploadM").change(function () {
            ; debugger
            var imageSizeArr = 0;
            var imageSize = document.getElementById('FuImage');
            var imageCount = imageSize.files.length;
            for (var i = 0; i < imageSize.files.length; i++) {
                var imageSize = imageSize.files[i].size;
                if (imageSize > 1) {
                    $('#test').text('3');
                    var imageSizeArr = 1;
                }
                if (imageSizeArr == 1) {
                    $('.element').text('files too big');
                }
                else if (imageSizeArr == 0) {
                    $('.element').text('files not too big');
                }
            }
        });

    </script>

    <%--  --%>
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
    <script>
        jQuery(function ($) {

            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_beginRequest(function (source, args) {


            });

            prm.add_endRequest(function (source, args) {
                debugger;
                $(function () {
                    $(".fileuploadMA1").change(function () {
                        ; debugger
                        if (typeof (FileReader) != "undefined") {
                            var dvPreviewA1 = $("#dvPreviewA1");
                            dvPreviewA1.html("");
                            var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                            $($(this)[0].files).each(function () {
                                var file = $(this);
                                if (regex.test(file[0].name.toLowerCase())) {
                                    var reader = new FileReader();
                                    reader.onload = function (e) {
                                        var img = $("<img />");
                                        img.attr("style", "height:100px;width: 100px");
                                        img.attr("src", e.target.result);
                                        dvPreviewA1.append(img);
                                    }
                                    reader.readAsDataURL(file[0]);
                                } else {
                                    alert(file[0].name + " is not a valid image file.");
                                    dvPreviewA1.html("");
                                    return false;
                                }
                            });
                        } else {
                            alert("This browser does not support HTML5 FileReader.");
                        }
                    });
                });
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $(".fileuploadMA1").change(function () {
                ; debugger
                if (typeof (FileReader) != "undefined") {
                    var dvPreviewA1 = $("#dvPreviewA1");
                    dvPreviewA1.html("");
                    var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                    $($(this)[0].files).each(function () {
                        var file = $(this);
                        if (regex.test(file[0].name.toLowerCase())) {
                            var reader = new FileReader();
                            reader.onload = function (e) {
                                var img = $("<img />");
                                img.attr("style", "height:100px;width: 100px");
                                img.attr("src", e.target.result);
                                dvPreviewA1.append(img);
                            }
                            reader.readAsDataURL(file[0]);
                        } else {
                            alert(file[0].name + " is not a valid image file.");
                            dvPreviewA1.html("");
                            return false;
                        }
                    });
                } else {
                    alert("This browser does not support HTML5 FileReader.");
                }
            });
        });
    </script>

    <script>


        $(function () {
            $("#btnSaveFile").bind("click", function () {
                if (typeof ($("#FuImage")[0].files) != "undefined") {
                    var size = parseFloat($("#FuImage")[0].files[0].size / 1024).toFixed(2);
                    alert(size + " KB.");
                } else {
                    alert("This browser does not support HTML5.");
                }
            });
        });


        $(".fileuploadMA1").change(function () {
            ; debugger
            var imageSizeArr = 0;
            var imageSize = document.getElementById('FuImage');
            var imageCount = imageSize.files.length;
            for (var i = 0; i < imageSize.files.length; i++) {
                var imageSize = imageSize.files[i].size;
                if (imageSize > 1) {
                    $('#test').text('3');
                    var imageSizeArr = 1;
                }
                if (imageSizeArr == 1) {
                    $('.element').text('files too big');
                }
                else if (imageSizeArr == 0) {
                    $('.element').text('files not too big');
                }
            }
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb breadcrumb-top">
        <li><a href="LMSDashboard.aspx">Home</a></li>
        <li>Feedback</li>
        <asp:HiddenField ID="HiddenField1" runat="server" />
    </ul>
    <div class="row">
        <div class="col-md-12">
            <%-- Trial Starts --%>
            <asp:HiddenField ID="strrowcount" runat="server" />
            <asp:HiddenField ID="hfTrId" runat="server" />
            <asp:HiddenField ID="deletestatus" runat="server" />

            <div class="block full ">
                <div class="block-title ">
                    <h2><strong>Modify Feedback</strong></h2>
                </div>
                <%--<ul class="nav nav-pills nav-justified clickable-steps">
                    <li runat="server" id="liFormulation">
                        <asp:HyperLink runat="server" ID="lnkFormulation">
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
                        <asp:HyperLink runat="server" ID="lnkTrial" Style="background-color: #1bbae1;">
                        <span class="badge pull-right"></span>
                        <b><i class="fa fa-gear themed-color-dark"></i></b><strong>&nbsp;&nbsp;Trial</strong>
                        </asp:HyperLink>
                    </li>
                </ul>--%>
                <br />
                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <h5 class="widget-content-light abc">
                            <strong>Feedback (<asp:Label runat="server" ID="lblTrialNo"></asp:Label>
                                <asp:Label runat="server" ID="lbltype1" Style="color: white; text-align: center;"></asp:Label>)</strong>
                            <strong>
                                <asp:Label runat="server" ID="lblapproved" Style="color: white;"></asp:Label></strong>
                            <asp:Button runat="server" ID="btnprint" class="btn btn-alt btn-xs btn-primary" Style="margin-left: 10px;" Visible="false" Text="Print" UseSubmitBehavior="false"></asp:Button>
                            <asp:Button runat="server" ID="btnprintblank" class="btn btn-alt btn-xs btn-primary" Visible="false" Text="Print Blank" UseSubmitBehavior="false"></asp:Button>
                            <%--<a runat="server" id="btnprint" class="btn btn-alt btn-xs btn-primary" target="_blank" style="margin-left: 10px;">Print</a>
                            <a runat="server" id="btnprintblank" class="btn btn-alt btn-xs btn-primary" target="_blank">Print Blank</a>--%> </strong>
                            <span class="pull-right" id="modifyspan" runat="server">By&nbsp;<a style="text-decoration: none;"><asp:Label ID="lblmodifiedname" runat="server" Font-Bold="true"></asp:Label></a>&nbsp;on&nbsp;<a style="text-decoration: none;"><asp:Label ID="lblmodifieddate" Font-Bold="true" runat="server" Font-Italic="true"></asp:Label></a>
                            </span>

                        </h5>
                    </div>

                    <div class="block" style="display: table; width: 100%;">
                        <asp:UpdatePanel ID="UPDATEMAIN" runat="server">
                            <ContentTemplate>
                                <div class="col-md-4" id="div1" runat="server">
                                    <label for="example-nf-email" class="col-md-3">Type </label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddltype" runat="server" AutoPostBack="true" data-toggle="tooltip" title="Select type" CssClass="form-control select-chosen">
                                            <asp:ListItem Text="Single" Value="Single"></asp:ListItem>
                                            <asp:ListItem Text="Compare" Value="Compare"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                </div>



                                <div class="col-md-4" id="divddlRecipe" runat="server">
                                    <label for="example-nf-email" class="col-md-4">Trial Code </label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlrecipie" runat="server" AutoPostBack="true" data-toggle="tooltip" title="Select Trial" CssClass="form-control select-chosen">
                                        </asp:DropDownList>
                                    </div>
                                </div>


                                <%--<div class="col-md-1 ">--%>
                                <%--<asp:Button ID="btnShow" runat="server" Text="Add Trial" class=" form-control btn btn-sm btn-success" visible="false" />--%>
                                <asp:LinkButton ID="btnShowPop" Text="Add Recipe" runat="server" class="btn btn-alt btn-xs btn-primary" Visible="false" />
                                <%--</div>--%>
                                <div style="clear: both"></div>
                                <br />
                                <br />
                                <%--  --%>
                                <div id="divAccordSingle" runat="server" visible="false">
                                    <div id="faq13" class="panel-group">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq13" href="#faq13_q12">
                                                    <asp:UpdatePanel ID="UpdatePanel14" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:Label ID="lblsamplereq" Text="Trial Details" runat="server"></asp:Label>
                                                        </ContentTemplate>

                                                    </asp:UpdatePanel>
                                                </a></h4>
                                            </div>
                                            <div id="faq13_q12" class="panel-collapse collapse" style="height: 0px;">
                                                <div class="panel-body">

                                                    <asp:UpdatePanel ID="UpdatePanel15" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <div class="table-responsive">
                                                                <table id="printtable" class="table table-vcenter table-condensed table-bordered col-md-12" style="margin-bottom: 0px;">
                                                                    <thead>
                                                                        <tr>
                                                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Raw Material</th>
                                                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Quantity(%)</th>
                                                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Quantity(kg)</th>
                                                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Quantity(gm)</th>
                                                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Cost</th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                                        <asp:Repeater ID="rpForm" runat="server">
                                                                            <ItemTemplate>
                                                                                <tr>
                                                                                    <td class="text-center">
                                                                                        <asp:Literal ID="lblname" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("FRawM_RawMat"))%>' /></td>
                                                                                    <asp:Label ID="ltRMat" runat="server" Text='<%#Eval("FRawM_RawMID")%>' Style="display: none;"></asp:Label>
                                                                                    <td class="text-center">
                                                                                        <asp:Literal ID="lblPerc" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("FRawM_Percentage"))%>' /></td>
                                                                                    <td class="text-center">
                                                                                        <asp:Literal ID="lblQtyKg" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("FRawM_QtyKg"))%>' /></td>
                                                                                    <td class="text-center">
                                                                                        <asp:Literal ID="lblQtyGm" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("FRawM_QtyGm"))%>' /></td>
                                                                                    <td class="text-center">
                                                                                        <asp:Literal ID="lblCost" runat="server" Text='<%#Convert.ToDecimal(Eval("FRawM_Cost"))%>' />
                                                                                    </td>
                                                                                </tr>

                                                                            </ItemTemplate>
                                                                        </asp:Repeater>
                                                                    </tbody>
                                                                </table>
                                                            </div>
                                                            <div style="clear: both"></div>
                                                            <br />
                                                            <div class="table-responsive col-md-6">
                                                                <table id="prnTblIng" class="table table-vcenter table-condensed table-bordered" style="margin-bottom: 0px;">
                                                                    <thead>
                                                                        <tr>
                                                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Name</th>
                                                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Value (GM)</th>
                                                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Percentage (%)</th>
                                                                        </tr>
                                                                        <%--<tr>
                                                                            <td class="text-center " style="width: 31%">
                                                                                <asp:Label runat="server" ID="lblFormNoTab"></asp:Label>
                                                                            </td>
                                                                            <td class="text-center">
                                                                                <asp:Label ID="txtFormTab" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td class="text-center ">100</td>
                                                                        </tr>--%>
                                                                    </thead>
                                                                    <tbody>
                                                                        <asp:Repeater ID="rpIng" runat="server">
                                                                            <ItemTemplate>
                                                                                <tr>
                                                                                    <td class="text-center">
                                                                                        <asp:Literal ID="lblname" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("RecipeIngredient_Name"))%>' /></td>
                                                                                    <%--<asp:Label ID="ltRMat" runat="server" Text='<%#Eval("FRawM_RawMID")%>' Style="display: none;"></asp:Label>--%>
                                                                                    <td class="text-center">
                                                                                        <asp:Literal ID="lblPerc" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("RecipeIngredient_Value"))%>' /></td>
                                                                                    <td class="text-center">
                                                                                        <asp:Literal ID="lblQtyKg" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("RecipeIngredient_Percent"))%>' /></td>
                                                                                </tr>

                                                                            </ItemTemplate>
                                                                        </asp:Repeater>
                                                                    </tbody>
                                                                </table>
                                                            </div>

                                                            <div class="table-responsive col-md-6">
                                                                <table id="prnTblProc" class="table table-vcenter table-condensed table-bordered" style="margin-bottom: 0px;">
                                                                    <thead>
                                                                        <tr>
                                                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Method</th>
                                                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Term</th>
                                                                            <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Time/Value</th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                                        <asp:Repeater ID="rpProc" runat="server">
                                                                            <ItemTemplate>
                                                                                <tr>
                                                                                    <td class="text-center">
                                                                                        <asp:Literal ID="lblname" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("RecipeProcedure_Step"))%>' /></td>
                                                                                    <%--<asp:Label ID="ltRMat" runat="server" Text='<%#Eval("FRawM_RawMID")%>' Style="display: none;"></asp:Label>--%>
                                                                                    <td class="text-center">
                                                                                        <asp:Literal ID="lblPerc" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("RecipeProcedure_Term"))%>' /></td>
                                                                                    <td class="text-center">
                                                                                        <asp:Literal ID="lblQtyKg" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("RecipeProcedure_Time"))%>' /></td>
                                                                                </tr>

                                                                            </ItemTemplate>
                                                                        </asp:Repeater>
                                                                    </tbody>
                                                                </table>
                                                            </div>
                                                        </ContentTemplate>

                                                    </asp:UpdatePanel>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div id="divAccordCompare" runat="server" visible="false">
                                    <div id="faq14" class="panel-group">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq14" href="#faq14_q12">
                                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:Label ID="Label8" Text="Trial Details" runat="server"></asp:Label>
                                                        </ContentTemplate>

                                                    </asp:UpdatePanel>
                                                </a></h4>
                                            </div>
                                            <div id="faq14_q12" class="panel-collapse collapse" style="height: 0px;">
                                                <div class="panel-body">

                                                    <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <div class="table-responsive">
                                                                <asp:UpdatePanel runat="server" ID="rpg" UpdateMode="Always">
                                                                    <ContentTemplate>
                                                                        <asp:Panel ID="pnldemo" runat="server">
                                                                            <table id="prnTblComp" class="MultiDatatable table table-vcenter table-condensed table-bordered">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Trial Code</th>
                                                                                        <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Product Name</th>
                                                                                        <th class="text-center col-md-2" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Assign to</th>
                                                                                        <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Date</th>
                                                                                        <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Execution Date</th>
                                                                                        <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Priority</th>
                                                                                        <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Complete Status</th>
                                                                                        <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">View</th>
                                                                                    </tr>
                                                                                </thead>
                                                                                <tbody>
                                                                                    <asp:Repeater ID="rpRecipe" runat="server">
                                                                                        <ItemTemplate>
                                                                                            <tr>
                                                                                                <td style="display: none" class="text-center">
                                                                                                    <asp:Literal ID="lblRecipeId" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Recipe_Id"), txtSearch)%>' />
                                                                                                </td>
                                                                                                <td class="text-center">
                                                                                                    <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "Multiview.aspx?id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Recipe_Id").ToString())) + "&&Levl=PR" + Eval("Recipe_Id").ToString()%>'
                                                                                                        runat="server" Target="_blank">
                                                                                                        <asp:Literal ID="Literal1" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Replace(Eval("Formulation_No"), "FR", "TR"), txtSearch)%>' />
                                                                                                    </asp:HyperLink><br />
                                                                                                </td>
                                                                                                <td class="text-center">
                                                                                                    <asp:Literal ID="Literal4" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Product_Name"), txtSearch)%>' />
                                                                                                </td>
                                                                                                <td class="text-center " style="display: none">
                                                                                                    <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# "Multiview.aspx?id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Recipe_Id").ToString())) + "&&Levl=PR" + Eval("Recipe_Id").ToString()%>'
                                                                                                        runat="server" Target="_blank">
                                                                                                        <asp:Literal ID="lblRecipeno" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Recipe_No"), txtSearch)%>' />
                                                                                                    </asp:HyperLink><br />
                                                                                                </td>
                                                                                                <td class="text-center " style="display: none">
                                                                                                    <asp:Literal ID="lblRecipeName" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Formulation_No"), txtSearch)%>' />
                                                                                                </td>
                                                                                                <td class="text-center" id="tdProdName" runat="server" visible="false">
                                                                                                    <asp:Literal ID="lblProductName" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Product_Name"), txtSearch)%>' />
                                                                                                </td>
                                                                                                <td class="text-center col-md-2">
                                                                                                    <asp:Literal ID="lblassignto" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("AssignTo"), txtSearch)%>' />
                                                                                                </td>
                                                                                                <td class="text-center ">
                                                                                                    <asp:Literal ID="lblRecipeDate" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Recipe_CreatedDate"), txtSearch)%>' />
                                                                                                </td>
                                                                                                <td class="text-center ">
                                                                                                    <asp:Literal ID="Literal2" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("Formulation_ExecutionDate")), txtSearch)%>' />
                                                                                                </td>
                                                                                                <td class="text-center ">
                                                                                                    <asp:Label ID="Literal3" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("Formulation_Priority")), txtSearch)%>'
                                                                                                        CssClass='<%#Security.checkpriorityLMS(DynamicparcelDataManipulation.FixNullFromDB(Eval("Formulation_Priority")))%>' />
                                                                                                </td>
                                                                                                <td class="text-center ">
                                                                                                    <asp:Label ID="Label7" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("Formulation_CompleteStatus")), txtsearch)%>'
                                                                                                        CssClass='<%#Security.checkpriorityLMS(DynamicparcelDataManipulation.FixNullFromDB(Eval("Formulation_CompleteStatus")))%>' />
                                                                                                   <%-- <asp:LinkButton ID="lnkCompleteStatus" CssClass='<%#Security.checkpriorityLMS(Eval("Formulation_CompleteStatus"))%>' runat="server" Text='<%#Eval("Formulation_CompleteStatus")%>'
                                                                                                        CommandName="Prioritylink" CommandArgument='<%# Eval("Recipe_FormulationId")%>' />--%>
                                                                                                </td>
                                                                                                <td class="text-center" id="tdview" runat="server" >
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
                                                                                    </asp:Repeater>
                                                                                </tbody>
                                                                            </table>
                                                                        </asp:Panel>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </ContentTemplate>

                                                    </asp:UpdatePanel>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%--  --%>

                                <div runat="server" id="pnlMain" visible="false">
                                    <div id="DivEvalMethod" runat="server">
                                        <h5><strong>
                                            <asp:Label runat="server" ID="lbltype"></asp:Label>
                                            Evaluation Method</strong></h5>

                                        <div class="table-responsive">
                                            <div class="widget-extra-full">
                                                <div class="form-horizontal">
                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>
                                                            <div class="table-responsive">
                                                                <asp:GridView ID="gvEvalMethod" runat="server" AutoGenerateColumns="False" DataKeyNames="" AllowCustomPaging="true"
                                                                    CssClass="table table-striped table-vcenter table-condensed" ShowFooter="true" GridLines="None">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="RowNumber" Visible="false" />

                                                                        <asp:TemplateField HeaderText="Sr No." Visible="False" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="">
                                                                            <ItemTemplate>
                                                                                <div class="input-group  col-md-12">
                                                                                    <div class="text-center">
                                                                                        <asp:Literal ID="ltFrom" runat="server" Text='<%#Eval("RowNumber")%>' Visible="False"></asp:Literal>
                                                                                    </div>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" Visible="False" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" HeaderStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Recipe No.</HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div class="col-md-12">
                                                                                    <asp:Label ID="lblRecipeID" runat="server" Text='<%#Bind("Recipe_Id")%>' CssClass="form-control MasterGridviewItem " Visible="false"></asp:Label>
                                                                                    <asp:Label ID="lblRecipeNo" runat="server" Text='<%#Bind("Recipe_No")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                    <%--<asp:Literal ID="ltRMat" runat="server" Text='<%#Eval("Dough_Temperature")%>' Visible="false"></asp:Literal>--%>
                                                                                    <%--<asp:RequiredFieldValidator ID="rfvtxtProcStep" runat="server"  ControlToValidate="txtProcStep" Display="Dynamic" ValidationGroup="MasterGroupProc" CssClass="MasterValidationCSS" 
                                                                    ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" HeaderStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Dough &#8451;</HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div class="col-md-12">
                                                                                    <asp:TextBox ID="txtDoughTemp" ToolTip="Dough Temperature" onkeypress="return onlyNos(event,this);" runat="server" Text='<%#Bind("TrialMethod_DoughTemperature")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                    <%--<asp:Literal ID="ltRMat" runat="server" Text='<%#Eval("Dough_Temperature")%>' Visible="false"></asp:Literal>--%>
                                                                                    <%--<asp:RequiredFieldValidator ID="rfvtxtProcStep" runat="server"  ControlToValidate="txtProcStep" Display="Dynamic" ValidationGroup="MasterGroupProc" CssClass="MasterValidationCSS" 
                                                                    ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Bench <i class="fa fa-clock-o"></i></HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div class="col-md-12">
                                                                                    <%--<asp:TextBox ID="txtBenchTime" runat="server" ></asp:TextBox>--%>
                                                                                    <asp:TextBox ID="txtBenchTime" placeholder="HH:MM" runat="server" Text='<%#Bind("TrialMethod_OnBenchTime")%>' CssClass="form-control MasterGridviewItem"
                                                                                        onkeypress="return onlyNos(event,this);" onkeyup="insertColon(this,'txtBenchTime');" onblur="Coloncheck(this,'txtBenchTime');checktime(this,'txtBenchTime');"
                                                                                        MaxLength="5" ToolTip="On Bench Time"></asp:TextBox>
                                                                                    <%--<asp:TextBox ID="txtBenchTime" runat="server" Text='<%#Bind("Bench_Time")%>' CssClass="form-control MasterGridviewItem test-input"  placeholder="hh:mm:ss" ></asp:TextBox>--%>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Scale <i class="fa fa-clock-o"></i></HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div class="col-md-12">
                                                                                    <%--<ajaxToolkit:MaskedEditExtender runat="server" TargetControlID="txtScaleTime" Mask="99:99:99" />--%>
                                                                                    <asp:TextBox ID="txtScaleTime" placeholder="HH:MM" runat="server" Text='<%#Bind("TrialMethod_ScaleTime")%>' CssClass="form-control MasterGridviewItem test-input"
                                                                                        onkeypress="return onlyNos(event,this);" onkeyup="insertColon(this,'txtScaleTime');" onblur="Coloncheck(this,'txtScaleTime');checktime(this,'txtScaleTime');"
                                                                                        MaxLength="5" ToolTip="Scale Time"></asp:TextBox>

                                                                                    <%--<asp:TextBox ID="txtScaleTime" runat="server" Text='<%#Bind("Scale_Time")%>' CssClass="form-control MasterGridviewItem test-input "  placeholder="hh:mm:ss"></asp:TextBox>--%>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Scale Weight </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div class="col-md-12">
                                                                                    <asp:TextBox ID="txtScaleWeight" runat="server" Text='<%#Bind("TrialMethod_ScaleWeight")%>' CssClass="form-control MasterGridviewItem " ToolTip="ScaleWeight"></asp:TextBox>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>In Proofer <i class="fa fa-clock-o"></i></HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div class="col-md-12">
                                                                                    <%--<ajaxToolkit:MaskedEditExtender ID="MeX2" runat="server" TargetControlID="txtInProoferTime" Mask="99:99:99" />--%>
                                                                                    <asp:TextBox ID="txtInProoferTime" placeholder="HH:MM" runat="server" Text='<%#Bind("TrialMethod_InProoferTime")%>' CssClass="form-control MasterGridviewItem test-input"
                                                                                        onkeypress="return onlyNos(event,this);" onkeyup="insertColon(this,'txtInProoferTime');" onblur="Coloncheck(this,'txtInProoferTime');checktime(this,'txtInProoferTime');"
                                                                                        MaxLength="5" ToolTip=" In Proofer Time"></asp:TextBox>
                                                                                    <%--<asp:TextBox ID="txtInProoferTime"  runat="server" Text='<%#Bind("InProofer_Time")%>'  CssClass="form-control MasterGridviewItem test-input" placeholder="hh:mm:ss"  maxlength="8" ></asp:TextBox>--%>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Oven in <i class="fa fa-clock-o"></i></HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div class="col-md-12">
                                                                                    <%--<ajaxToolkit:MaskedEditExtender ID="MeX2" runat="server" TargetControlID="txtInOvenTime" Mask="99:99:99" />--%>
                                                                                    <asp:TextBox ID="txtInOvenTime" runat="server" placeholder="HH:MM" Text='<%#Bind("TrialMethod_InOvenTime")%>' CssClass="form-control MasterGridviewItem test-inpu1t"
                                                                                        onkeypress="return onlyNos(event,this);" onkeyup="insertColon(this,'txtInOvenTime');" onblur="Coloncheck(this,'txtInOvenTime');checktime(this,'txtInOvenTime');"
                                                                                        MaxLength="5" ToolTip="In Oven Time"></asp:TextBox>

                                                                                    <%-- <asp:TextBox ID="txtInOvenTime" runat="server" Text='<%#Bind("InOven_Time")%>' CssClass="form-control MasterGridviewItem test-inpu1t" 
                                                                  placeholder="hh:mm:ss" value="" maxlength="6" ></asp:TextBox>--%>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Oven out <i class="fa fa-clock-o"></i></HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div class="col-md-12">
                                                                                    <asp:TextBox ID="txtOutOvenTime" placeholder="HH:MM" runat="server" Text='<%#Bind("TrialMethod_OutOvenTime")%>' CssClass="form-control MasterGridviewItem test-input"
                                                                                        onkeypress="return onlyNos(event,this);" onkeyup="insertColon(this,'txtOutOvenTime');" onblur="Coloncheck(this,'txtOutOvenTime');checktime(this,'txtOutOvenTime');"
                                                                                        MaxLength="5" ToolTip="Out Oven Time"></asp:TextBox>

                                                                                    <%--<asp:TextBox ID="txtOutOvenTime" runat="server" Text='<%#Bind("OutOven_Time")%>' CssClass="form-control MasterGridviewItem test-input " placeholder="hh:mm:ss"></asp:TextBox>--%>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Steam </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div class="col-md-12">
                                                                                    <%--<asp:CheckBox ID="chkSteam" runat="server" CssClass="form-control select-chosen " />--%>
                                                                                    <asp:DropDownList ID="ddlSteam" runat="server" CssClass="form-control select-chosen " AutoPostBack="false" ToolTip="Steam">
                                                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                                        <asp:ListItem Value="0">No</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <asp:Literal ID="ltSteam" runat="server" Text='<%#Eval("TrialMethod_Steam")%>' Visible="false"></asp:Literal>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Bulk fermentation" HeaderStyle-ForeColor="#666666" HeaderStyle-Width="11%" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="MasterGridviewItem" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Bulk Fermentation <i class="fa fa-clock-o"></i></HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div class="col-md-12">
                                                                                    <asp:Label ID="lblBulkferment" runat="server" Text='<%#Eval("Bulk_fermentation")%>' CssClass="MasterGridviewItem " ToolTip="Bulk Fermentation"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-Width="9%" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Proofing <i class="fa fa-clock-o"></i></HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div class="col-md-12">
                                                                                    <asp:Label ID="lblProofing" runat="server" Text='<%#Bind("Proofing")%>' CssClass="MasterGridviewItem " ToolTip="Proofing"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-Width="9%" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Baking <i class="fa fa-clock-o"></i></HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div class="col-md-12">
                                                                                    <asp:Label ID="lblBakingTime" runat="server" Text='<%#Bind("Baking_Time")%>' CssClass="MasterGridviewItem " ToolTip="Baking Time"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>


                                                                        <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="MasterGridviewItem">
                                                                            <ItemTemplate>
                                                                                <div class="btn-group btn-group-xs" style="display: none;">
                                                                                    <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                                                        CommandName="deleteEvalMLink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <div id="divLknAdd" class="btn-group btn-group-xs" style="display: none;">
                                                                                    <asp:LinkButton ID="lnkadd" data-toggle="tooltip" title="Add" class="btn btn-info" runat="server" OnClientClick="if (!Page_ClientValidate('MasterGroupEvalM')){ return false; } this.disabled = true; this.value = 'Adding...';"
                                                                                        CommandName="AddEvalMNewRow" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-plus"></i></asp:LinkButton>
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
                                                                <asp:Literal runat="server" ID="Literal3"></asp:Literal>
                                                            </div>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="gvEvalMethod" />

                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>
                                        <div style="clear: both"></div>
                                    </div>

                                    <h5><strong>Evaluation</strong></h5>

                                    <div class="table-responsive">
                                        <div class="widget-extra-full">
                                            <div class="form-horizontal">
                                                <div style="border: 1px dashed black; border-top: 1px dashed black;">
                                                    <table id="tblSingleEval" runat="server" visible="false" class="MultiDatatable table table-vcenter table-condensed  widget">
                                                        <thead>
                                                            <tr>
                                                                <%--<th class="text-center" style="display: none">Purchase</th>--%>
                                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #666666;"></th>
                                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #666666;">Value</th>
                                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #666666;">Comment</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr id="trc1" runat="server">
                                                                <td class="text-center ">
                                                                    <asp:Label ID="Label1" runat="server" Text="Center Height"></asp:Label></td>
                                                                <td class="text-center ">

                                                                    <asp:TextBox ID="txtcentreHeightVal" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtcentreHeightcom" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                            </tr>
                                                            <tr id="trc2" runat="server">
                                                                <td class="text-center ">
                                                                    <asp:Label ID="Label2" runat="server" Text="Left Side Height"></asp:Label></td>
                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtLeftHeightVal" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtLeftHeightcom" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                            </tr>
                                                            <tr id="trc3" runat="server">
                                                                <td class="text-center ">
                                                                    <asp:Label ID="Label3" runat="server" Text="Right Side Height"></asp:Label></td>
                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtrightHeightVal" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtrightHeightcom" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                            </tr>
                                                            <tr id="trc4" runat="server">
                                                                <td class="text-center ">
                                                                    <asp:Label ID="Label4" runat="server" Text="Sweetness"></asp:Label></td>
                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtsweetVal" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtsweetcom" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                            </tr>
                                                            <tr id="trc5" runat="server">
                                                                <td class="text-center ">
                                                                    <asp:Label ID="Label5" runat="server" Text="Flavor"></asp:Label></td>
                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtflavorval" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtflavorcom" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                            </tr>
                                                            <tr id="trc6" runat="server">
                                                                <td class="text-center ">
                                                                    <asp:Label ID="Label6" runat="server" Text="Specific Gravity of Batter (g/litre)"></asp:Label></td>
                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtbatterval" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtbattercom" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <%--<td style="display: none" class ="text-center "><asp:Label ID="lblPurchaseId" runat="server" Text='<%#Eval("Transaction_Id")%>'></asp:Label></td>--%>
                                                                <td class="text-center ">
                                                                    <asp:Label ID="lblPDelivery" runat="server" Text="Volume"></asp:Label></td>

                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtVolumeVal" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtVolumeCom" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-center ">
                                                                    <asp:Label ID="lblWeight" runat="server" Text="Weight"></asp:Label></td>

                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtWeightVal" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtWeightCom" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-center ">
                                                                    <asp:Label ID="lblDimension" runat="server" Text="Dimension"></asp:Label></td>

                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtDimensionVal" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtDimensionCom" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-center ">
                                                                    <asp:Label ID="lblCrumbText" runat="server" Text="Crumb Texture"></asp:Label></td>

                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtCrumbTextVal" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtCrumbTextCom" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-center ">
                                                                    <asp:Label ID="lblCrumbCol" runat="server" Text="Crumb Color"></asp:Label></td>

                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtCrumbColVal" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtCrumbColCom" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-center ">
                                                                    <asp:Label ID="lblCrustText" runat="server" Text="Crust Texture"></asp:Label></td>

                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtCrustTextVal" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtCrustTextCom" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-center ">
                                                                    <asp:Label ID="lblCrustCol" runat="server" Text="Crust Color"></asp:Label></td>

                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtCrustColVal" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                                <td class="text-center ">
                                                                    <asp:TextBox ID="txtCrustColCom" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-center ">
                                                                    <asp:Label ID="lblTaste" runat="server" Text="Taste"></asp:Label></td>

                                                                <td class="text-center  " colspan="2">
                                                                    <asp:TextBox ID="txtTasteVal" runat="server" CssClass="form-control "></asp:TextBox></td>
                                                                <%--<td class ="text-center "><asp:TextBox ID="txtTasteCom" runat="server" CssClass="form-control "></asp:TextBox></td>--%>
                                                            </tr>

                                                        </tbody>
                                                    </table>
                                                </div>
                                                <div id="tblCompareEval" runat="server" visible="false">
                                                    <%--  --%>
                                                    <div class="table-responsive">
                                                        <%--<div class="widget-extra-full">
                                            <div class="form-horizontal">--%>
                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                            <ContentTemplate>
                                                                <div class="table-responsive">
                                                                    <asp:GridView ID="gvMultiEval" runat="server" AutoGenerateColumns="False" DataKeyNames="" AllowCustomPaging="true"
                                                                        CssClass="table table-striped table-vcenter table-condensed" ShowFooter="true" GridLines="None">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="RowNumber" Visible="false" />

                                                                            <asp:TemplateField HeaderText="Sr No." Visible="False" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="">
                                                                                <ItemTemplate>
                                                                                    <div class="input-group  col-md-12">
                                                                                        <div class="text-center">
                                                                                            <asp:Literal ID="ltFrom" runat="server" Text='<%#Eval("RowNumber")%>' Visible="False"></asp:Literal>
                                                                                        </div>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" HeaderStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Top">
                                                                                <%--<HeaderTemplate></HeaderTemplate>--%>
                                                                                <ItemTemplate>
                                                                                    <%--<div>--%>
                                                                                    <asp:Label ID="lblValue" runat="server" Text="Value" CssClass=" MasterGridviewItem "></asp:Label>
                                                                                    <br />
                                                                                    <br />
                                                                                    <asp:Label ID="lblComment" runat="server" Text="Comment" CssClass=" MasterGridviewItem "></asp:Label>
                                                                                    <br />
                                                                                    <br />
                                                                                    <br />
                                                                                    <%--</div>--%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-ForeColor="#666666" Visible="false" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" HeaderStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                                                                                <HeaderTemplate>Recipe No.</HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <div>
                                                                                        <asp:Label ID="lblRecipeID" runat="server" Text='<%#Bind("Recipe_Id")%>' CssClass=" MasterGridviewItem " Visible="false"></asp:Label>
                                                                                        <asp:Label ID="lblRecipeNo" runat="server" Text='<%#Bind("Recipe_No")%>' CssClass=" MasterGridviewItem "></asp:Label>
                                                                                        <br />
                                                                                        <br />
                                                                                        <br />
                                                                                        <br />
                                                                                        <br />
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderStyle-ForeColor="#666666" Visible="False" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" HeaderStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                                                                                <HeaderTemplate>Center Height</HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <div>
                                                                                        <asp:TextBox ID="txtcentreHtVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CenterHeightVal")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                        <asp:TextBox ID="txtcentreHtcom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CenterHeightCom")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderStyle-ForeColor="#666666" Visible="False" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                                <HeaderTemplate>Left Side Height</HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <div>
                                                                                        <asp:TextBox ID="txtLeftHeightVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_LeftHeightVal")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                        <asp:TextBox ID="txtLeftHeightCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_LeftHeightCom")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderStyle-ForeColor="#666666" Visible="False" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                                <HeaderTemplate>Right Side Height</HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <div>
                                                                                        <asp:TextBox ID="txtrightHeightVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_RightHeightVal")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                        <asp:TextBox ID="txtrightHeightCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_RightHeightCom")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderStyle-ForeColor="#666666" Visible="False" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                                <HeaderTemplate>Sweetness</HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <div>
                                                                                        <asp:TextBox ID="txtsweetVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_SweetnessVal")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                        <asp:TextBox ID="txtsweetCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_SweetnessCom")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderStyle-ForeColor="#666666" Visible="False" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                                <HeaderTemplate>Flavour</HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <div>
                                                                                        <asp:TextBox ID="txtflavorVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_FlavourVal")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                        <asp:TextBox ID="txtflavorCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_FlavourCom")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderStyle-ForeColor="#666666" Visible="False" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                                <HeaderTemplate>Specific Gravity of Batter (g/litre)</HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <div>
                                                                                        <asp:TextBox ID="txtBatterVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_BatterGravityVal")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                        <asp:TextBox ID="txtBatterCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_BatterGravityCom")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                                <HeaderTemplate>Volume</HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <div>
                                                                                        <asp:TextBox ID="txtVolumeVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_VolumeVal")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                        <asp:TextBox ID="txtVolumeCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_VolumeCom")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                                <HeaderTemplate>Weight</HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <div>
                                                                                        <asp:TextBox ID="txtWeightVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_WeightVal")%>' CssClass="form-control "></asp:TextBox>
                                                                                        <asp:TextBox ID="txtWeightCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_WeightCom")%>' CssClass="form-control "></asp:TextBox>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="MasterGridviewItem" ItemStyle-VerticalAlign="Middle">
                                                                                <HeaderTemplate>Dimension</HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <div>
                                                                                        <asp:TextBox ID="txtDimensionVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_DimensionVal")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                        <asp:TextBox ID="txtDimensionCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_DimensionCom")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                                <HeaderTemplate>Crumb Texture</HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <div>
                                                                                        <asp:TextBox ID="txtCrumbTextVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrumbTextureVal")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                        <asp:TextBox ID="txtCrumbTextCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrumbTextureCom")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                                <HeaderTemplate>Crumb Color</HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <div>
                                                                                        <asp:TextBox ID="txtCrumbColVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrumbColorVal")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                        <asp:TextBox ID="txtCrumbColCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrumbColorCom")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                                <HeaderTemplate>Crust Texture</HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <div>
                                                                                        <asp:TextBox ID="txtCrustTextVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrustTextureVal")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                        <asp:TextBox ID="txtCrustTextCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrustTextureCom")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                                <HeaderTemplate>Crust Color</HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <div>
                                                                                        <asp:TextBox ID="txtCrustColVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrustColorVal")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                        <asp:TextBox ID="txtCrustColCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrustColorCom")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                                <HeaderTemplate>Taste</HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <div>
                                                                                        <asp:TextBox ID="txtTasteVal" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_Taste")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>
                                                                                        <%--<asp:TextBox ID="txtTasteCom" ToolTip="Dough Temperature"  runat="server" Text='<%#Bind("TrialEval_Taste")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>--%>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-Width="8%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                                <HeaderTemplate>Upload Image</HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <div>

                                                                                        <label class="btn btn-alt btn-xs btn-info ">
                                                                                            Choose Files
                                                                                    <asp:FileUpload ID="MuImage" Style="display: none;" CssClass="fileuploadM" multiple="multiple" runat="server" />

                                                                                        </label>

                                                                                        <%--<asp:TextBox ID="txtTasteCom" ToolTip="Dough Temperature"  runat="server" Text='<%#Bind("TrialEval_Taste")%>' CssClass="form-control MasterGridviewItem "></asp:TextBox>--%>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="MasterGridviewItem" Visible="false">
                                                                                <ItemTemplate>
                                                                                    <div class="btn-group btn-group-xs" style="display: none;">
                                                                                        <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                                                            CommandName="deleteEvalMLink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <div id="divLknAdd" class="btn-group btn-group-xs" style="display: none;">
                                                                                        <asp:LinkButton ID="lnkadd" data-toggle="tooltip" title="Add" class="btn btn-info" runat="server" OnClientClick="if (!Page_ClientValidate('MasterGroupEvalM')){ return false; } this.disabled = true; this.value = 'Adding...';"
                                                                                            CommandName="AddEvalMNewRow" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-plus"></i></asp:LinkButton>
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
                                                                    <asp:Literal runat="server" ID="Literal1"></asp:Literal>
                                                                </div>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <%--<asp:AsyncPostBackTrigger ControlID="gvMultiEval" />--%>
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                        <div id="dvPreview">
                                                        </div>

                                                        <%--  --%>
                                                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                            <ContentTemplate>
                                                                <div id="divPopup" runat="server" class="col-md-12">
                                                                    <div id="faq188f1" class="panel-group">
                                                                        <div class="panel panel-default">
                                                                            <div class="panel-heading">
                                                                                <h4 class="panel-title"><a class="accordion-toggle" data-toggle="collapse" data-parent="#faq188f1" href="#faq188f1_q188">
                                                                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
                                                                                        <ContentTemplate>
                                                                                            <asp:Label ID="lblRecipePop" Text="Gallery" runat="server"></asp:Label>
                                                                                        </ContentTemplate>
                                                                                        <Triggers>
                                                                                        </Triggers>
                                                                                    </asp:UpdatePanel>
                                                                                </a>

                                                                                </h4>
                                                                            </div>
                                                                            <div id="faq188f1_q188" class="panel-collapse collapse in" style="max-height: 303px; overflow: auto;">
                                                                                <div class="col-md-12">
                                                                                    <br />


                                                                                    <div class="gallery gallery-widget" data-toggle="lightbox-gallery">
                                                                                        <div class="row">
                                                                                            <asp:UpdatePanel ID="up1" runat="server">
                                                                                                <ContentTemplate>

                                                                                                    <asp:Repeater runat="server" ID="rp_gallery">
                                                                                                        <ItemTemplate>
                                                                                                            <div class="col-xs-6 col-sm-1">
                                                                                                                <a href='<%# Eval("href").ToString%>' class="gallery-link" title='<%# Eval("Recipe_No").ToString%>'>
                                                                                                                    <img src='<%# Eval("href").ToString%>' alt="image" style="width: 105px; height: 70px">
                                                                                                                </a>

                                                                                                            </div>
                                                                                                        </ItemTemplate>

                                                                                                    </asp:Repeater>

                                                                                                </ContentTemplate>
                                                                                            </asp:UpdatePanel>
                                                                                        </div>
                                                                                    </div>
                                                                                    <br />

                                                                                    <%--</div>
                                                                            </div>
                                                                        </div>

                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </div>--%>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <%--<asp:PostBackTrigger ControlID="Button1" />--%>
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                        <%--  --%>
                                                        <%--WAS HERE--%>
                                                    </div>
                                                </div>
                                                <%--STARTS--%>
                                                <div style="clear: both">
                                                    <div>
                                                        <h5><strong>Remark</strong></h5>
                                                        <asp:TextBox runat="server" ID="txtremark" TextMode="MultiLine" Columns="3" Class="col-md-12 form-control"></asp:TextBox>
                                                    </div>
                                                    <div style="clear: both">
                                                        <br />
                                                    </div>

                                                    <%-- Image Control============================== --%>
                                                    <div class="col-md-12 " id="divChooseFileSingle" runat="server" visible="false">
                                                        <div class="col-md-12 ">

                                                            <label class="btn btn-alt btn-xs btn-info ">
                                                                Choose Files
                             <asp:FileUpload ID="MuImageA1" Style="display: none;" CssClass="fileuploadMA1" multiple="multiple" runat="server" /></label>
                                                            <%-- &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <label id="Label7" runat="server">(Product Detail Image Size(429px X 350px))</label>--%>
                                                        </div>
                                                    </div>

                                                    <br />
                                                    <div id="dvPreviewA1">
                                                    </div>
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                        <ContentTemplate>
                                                            <div id="divSingallery" runat="server" class="col-md-12">
                                                                <div id="faq188f1A1" class="panel-group">
                                                                    <div class="panel panel-default">
                                                                        <div class="panel-heading">
                                                                            <h4 class="panel-title"><a class="accordion-toggle" data-toggle="collapse" data-parent="#faq188f1A1" href="#faq188f1A1_q188">
                                                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                                                    <ContentTemplate>
                                                                                        <asp:Label ID="lblImageprod" Text="Trial Detail Images" runat="server"></asp:Label>
                                                                                    </ContentTemplate>
                                                                                    <Triggers>
                                                                                    </Triggers>
                                                                                </asp:UpdatePanel>
                                                                            </a>

                                                                            </h4>
                                                                        </div>
                                                                        <div id="faq188f1A1_q188" class="panel-collapse collapse in" style="max-height: 303px; overflow: auto;">
                                                                            <div class="col-md-12">
                                                                                <br />
                                                                                <div class="gallery gallery-widget" data-toggle="lightbox-gallery">
                                                                                    <div class="row">
                                                                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                                                                            <ContentTemplate>

                                                                                                <asp:Repeater runat="server" ID="rp_galleryA1">
                                                                                                    <ItemTemplate>
                                                                                                        <div class="col-xs-6 col-sm-1">
                                                                                                            <a href='<%# Eval("href").ToString%>' class="gallery-link" title='<%# Eval("Recipe_No").ToString%>'>
                                                                                                                <%-- <img src='<%# Eval("href").ToString%>' alt="image" style="width: 105px; height: 70px">--%>
                                                                                                                <img src='<%# Eval("href").ToString%>' alt="image" style="width: 105px; height: 70px">
                                                                                                            </a>
                                                                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                                                                                <ContentTemplate>
                                                                                                                    <asp:LinkButton ID="lkdelete" runat="server" class="btn btn-alt  btn-xs btn-danger pull-right" data-toggle="tooltip" title="Delete" CommandName="Delete" CommandArgument='<%# Eval("TRImage_id")%>' OnClientClick="checkdelete();"><i class="fa fa-times"></i></asp:LinkButton>
                                                                                                                </ContentTemplate>
                                                                                                                <Triggers>
                                                                                                                    <asp:AsyncPostBackTrigger ControlID="lkdelete" />
                                                                                                                </Triggers>
                                                                                                            </asp:UpdatePanel>
                                                                                                        </div>
                                                                                                    </ItemTemplate>

                                                                                                </asp:Repeater>

                                                                                            </ContentTemplate>
                                                                                            <Triggers>
                                                                                                <asp:AsyncPostBackTrigger ControlID="rp_galleryA1" />
                                                                                            </Triggers>
                                                                                        </asp:UpdatePanel>
                                                                                    </div>
                                                                                </div>
                                                                                <br />


                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                    <br />

                                                    <%-- Image Control eND============================== --%>
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
                                                    <div class="col-md-12">
                                                        <div class="col-md-6">
                                                            <User:LMSAssignControl ID="LMSassigncontrol" runat="server" />
                                                        </div>
                                                    </div>

                                                    <div style="clear: both">
                                                        <br />
                                                        <br />
                                                    </div>
                                                    <div class="col-md-12 ">
                                                        <div class="text-center btn-group-xs ">
                                                            <asp:UpdatePanel runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Button ID="btnTrialSaveApprove" runat="server" Text="Approve" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                                                        UseSubmitBehavior="false" ValidationGroup="MasterGroup" CssClass="btn btn-sm btn-info " Visible="false" />
                                                                    <asp:Button ID="btnTrialDisapprove" runat="server" Text="Reject" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                                                        UseSubmitBehavior="false" ValidationGroup="MasterGroup" CssClass="btn btn-sm btn-danger " Visible="false" />
                                                                    <asp:Button ID="btnRejNCrtNew" runat="server" Text="Reject & Create New Trial" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                                                        UseSubmitBehavior="false" ValidationGroup="MasterGroup" CssClass="btn btn-sm btn-danger " Visible="false" />
                                                                    <%--<asp:UpdatePanel ID="UpdFileUpload" runat="server">
                                                                        <ContentTemplate>--%>
                                                                    <asp:Button ID="btnTrialSave" runat="server" Text="Save" UseSubmitBehavior="false" ValidationGroup="MasterGroup" CssClass="btn btn-sm btn-success" Visible="false" />
                                                                    <%--</ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:PostBackTrigger ControlID="btnTrialSave" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>--%>

                                                                    <asp:Button ID="btnsavenew" runat="server" Visible="false" Text="Save as new" UseSubmitBehavior="false" ValidationGroup="MasterGroup" CssClass="btn btn-alt btn-sm btn-success" />
                                                                    <asp:Button ID="btnFormulationCancel" runat="server" Text="Cancel" UseSubmitBehavior="false" CssClass="btn btn-sm btn-warning " />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                    <div style="clear: both"></div>

                                                </div>
                                                <%--ENDS--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>



                                <asp:ModalPopupExtender ID="mpe" runat="server" BehaviorID="mpe" PopupControlID="pnlPopup" TargetControlID="btnShowPop" CancelControlID="btnNo">
                                </asp:ModalPopupExtender>

                                <%-- Pop Up Start --%>
                                <asp:HiddenField ID="hfRadioCheck" runat="server" />
                                <asp:Panel ID="pnlPopup" runat="server" Style="display: none">
                                    <%--<asp:Panel ID="pnlPopup" runat="server" Style="display: none" DefaultButton="btnPopAdd">--%>
                                    <div class="modal-dialog modal-lg" style="overflow-y: scroll; position: fixed; top: 0; bottom: 0; left: 0; right: 0; overflow: auto; width: 1192px;">
                                        <div class="modal-content" style="top: 1%; overflow-x: hidden; overflow-y: auto; outline: none; margin-top: 0; overflow: visible;">
                                            <div class="modal-header">
                                                <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                                                <h4 class="modal-title">Add Recipe</h4>
                                            </div>
                                            <div class="modal-body" style="overflow: auto; height: 400px;">
                                                <div class="table-options clearfix">
                                                    <div class="col-sm-5 col-xs-4">
                                                        <div class="dataTables_length" id="example-datatable_length">
                                                            <asp:Label runat="server" Text="Select Mix Type"></asp:Label>
                                                            <asp:RadioButtonList runat="server" ID="rbMixType" AutoPostBack="true">
                                                                <asp:ListItem Value="Bread & Improvers" Text="Bread & Improvers" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="Cake & Desserts" Text="Cake & Desserts"></asp:ListItem>
                                                                <%--<asp:ListItem Value="Cream & Filling" Text="Cream & Filling"></asp:ListItem>--%>
                                                            </asp:RadioButtonList>
                                                            <%-- <asp:RadioButton runat="server" AutoPostBack="true" ID="rbBread" Text="Bread" GroupName="MixType" Checked="true" />
                                                    <asp:RadioButton runat="server" AutoPostBack="true" ID="rbCake" Text="Cake" GroupName="MixType" />--%>
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
                                                        <asp:Button ID="btnshowall" EnableViewState="false" runat="server" Text="Show All" CssClass="btn btn-alt btn-sm btn-info" />
                                                    </div>
                                                </div>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                                                    <ContentTemplate>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="gvRecipePopUp" runat="server" AutoGenerateColumns="False" DataKeyNames="Recipe_Id"
                                                                CssClass="table table-striped table-vcenter table-hover" Font-Size="12px">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Select" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Recipe_Id">
                                                                        <ItemTemplate>
                                                                            <%--<div>--%>
                                                                            <asp:CheckBox ID="ckselect" runat="server" />
                                                                            <asp:Label ID="lblRecipe_Id" runat="server" Text='<%#Eval("Recipe_Id")%>' Visible="false" />
                                                                            <%--<asp:RequiredFieldValidator ID="rfckselect" runat="server"  ControlToValidate="ckselect" ValidationGroup="ProductItemGroup" 
                                                                    ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>

                                                                            <%-- </div>--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%--<asp:TemplateField HeaderText="Recipe No." HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Recipe_No">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRecipe_No1" runat="server" Text='<%#Eval("Recipe_No") + "-" + Eval("Formulation_No")%>'></asp:Label>
                                                                            <asp:Label ID="lblRecipe_No" runat="server" Text='<%#Eval("Recipe_No")%>' Visible="false"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                    <asp:TemplateField HeaderText="Trial No." HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Recipe_No">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRecipe_No1" runat="server" Text='<%# Eval("Recipe_No1")%>'></asp:Label>
                                                                            <asp:Label ID="lblRecipe_No" runat="server" Text='<%#Eval("Recipe_No")%>' Visible="false"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Type" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Formulation_Type">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblFormulation_Type" runat="server" Text='<%#Eval("Formulation_Type")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Formulation_Type">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRecipe_Approved" runat="server" Text='<%#Eval("Recipe_Approved")%>' />
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
                                                        <%--<asp:AsyncPostBackTrigger ControlID="btnPopAdd" />--%>
                                                        <asp:AsyncPostBackTrigger ControlID="btnShowPop" />
                                                        <asp:AsyncPostBackTrigger ControlID="btnshowall" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <div class="modal-footer">
                                                        <asp:Button ID="btnPopAdd" runat="server" class="btn btn-sm btn-primary" ValidationGroup="ProductItemGroup" Text="Add Recipe"></asp:Button>
                                                        <asp:Button ID="btnsaveclose" Visible="false" runat="server" class="btn btn-sm btn-primary" ValidationGroup="ProductItemGroup" Text="Save & Close"></asp:Button>
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <%--<asp:AsyncPostBackTrigger ControlID="btnopen" />--%>
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
                                <%-- --%>

                                <%-- Pop Up End --%>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlrecipie" />
                                <asp:AsyncPostBackTrigger ControlID="ddltype" />
                                <asp:AsyncPostBackTrigger ControlID="btnPopAdd" />
                                <asp:AsyncPostBackTrigger ControlID="gvRecipePopUp" />
                                <asp:AsyncPostBackTrigger ControlID="txtsearch" />
                                <asp:AsyncPostBackTrigger ControlID="btnshowall" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

            <%-- Trial Ends --%>
        </div>
    </div>
</asp:Content>

