<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PrintTrial.aspx.vb" Inherits="PrintTrial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
</head>
<body style="padding: 0; margin: 0;">
    <form id="form1" runat="server">
        <div style="width: 11.69in; height: 8.00in;">
            <div style="padding: 5px;" runat="server" id="divfill">
                <asp:HiddenField ID="hfCategory" runat="server" />
                <div style="background-color: #394263; color: white; padding: 5px;">
                    Feedback (<asp:Label runat="server" ID="lblTrialNo"></asp:Label>)<asp:Label runat="server" ID="lblapproved" Style="float: right;"></asp:Label>
                </div>
                <div style="margin-top: 28px;">
                    <div style="margin-top: -18px; margin-left: 01px;">
                        Trial Type : <b>
                            <asp:Label runat="server" ID="lbltype"></asp:Label></b>
                    </div>
                    <div style="margin-top: -19px; margin-left: 290px;" runat="server" visible="false" id="divRecipecode">
                        Recipe : <b>
                            <asp:Label runat="server" ID="lblRecipecode"></asp:Label></b>
                    </div>
                </div>
                <hr />
                <div runat="server" id="DivEvalMethod">
                    <table style="width: 100%;" cellpadding="5">
                        <tbody>
                            <tr>
                                <td colspan="11">Evaluation Method</td>
                            </tr>

                            <asp:Repeater runat="server" ID="rpEvalMethod">
                                <HeaderTemplate>
                                    <tr>
                                        <td style="border: none;">Recipe No.</td>
                                        <td style="border: none;">Dough</td>
                                        <td style="border: none;">Bench</td>
                                        <td style="border: none;">Scale</td>
                                        <td style="border: none;">Scale Weight</td>
                                        <td style="border: none;">In Proofer</td>
                                        <td style="border: none;">Oven in</td>
                                        <td style="border: none;">Oven out</td>
                                        <td style="border: none;">Steam</td>
                                        <td style="border: none;">Bulk Fermentation </td>
                                        <td style="border: none;">Proofing </td>
                                        <td style="border: none;">Steam</td>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="lblRecipeID" Visible="false" Text='<%#Eval("Recipe_Id")%>'></asp:Label>
                                            <asp:Label runat="server" ID="lblRecipeNo" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Recipe_No"))%>'></asp:Label>
                                        </td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="lblname" Visible="false" Text='<%#Eval("TrialMethod_Id")%>'></asp:Label>
                                            <asp:Label runat="server" ID="txtDoughTemp" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialMethod_DoughTemperature"))%>'></asp:Label>
                                        </td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="txtBenchTime" onkeyup="insertColon(this,'txtBenchTime');" onblur="Coloncheck(this,'txtBenchTime');checktime(this,'txtBenchTime');" Text='<%# DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialMethod_OnBenchTime"))%>'></asp:Label></td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="txtScaleTime" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialMethod_ScaleTime"))%>'></asp:Label></td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="txtScaleWeight" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialMethod_ScaleWeight"))%>'></asp:Label></td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="txtInProoferTime" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialMethod_InProoferTime"))%>'></asp:Label></td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="txtInOvenTime" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialMethod_InOvenTime"))%>'></asp:Label></td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="txtOutOvenTime" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialMethod_OutOvenTime"))%>'></asp:Label></td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="ltSteam" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialMethod_Steam"))%>'></asp:Label></td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="lblBulkferment" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Bulk_fermentation"))%>'></asp:Label></td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="lblProofing" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Proofing"))%>'></asp:Label></td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="lblBakingTime" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Baking_Time"))%>'></asp:Label></td>
                                    </tr>
                                </ItemTemplate>

                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
                <hr runat="server" id="hr1" />
                <div style="width: 100%;">
                    <table id="tblSingleEval" runat="server" style="border: 1px dashed black; width: 100%;">
                        <tr>
                            <td colspan="11">Evaluation</td>
                        </tr>
                        <thead style="border: 1px dashed black;">
                            <tr>
                                <%--<th class="text-center" style="display: none">Purchase</th>--%>
                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #666666; width: 30%;"></th>
                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #666666; width: 40%;">Value</th>
                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #666666; width: 40%;">Comment</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr id="trc1" runat="server">
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label1" runat="server" Text="Center Height"></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtcentreHeightVal" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtcentreHeightcom" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr id="trc2" runat="server">
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label2" runat="server" Text="Left Side Height"></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtLeftHeightVal" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtLeftHeightcom" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr id="trc3" runat="server">
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label3" runat="server" Text="Right Side Height"></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtrightHeightVal" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtrightHeightcom" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr id="trc4" runat="server">
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label4" runat="server" Text="Sweetness"></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtsweetVal" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtsweetcom" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr id="trc5" runat="server">
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label5" runat="server" Text="Flavor"></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtflavorval" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtflavorcom" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr id="trc6" runat="server">
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label6" runat="server" Text="Specific Gravity of Batter (g/litre)"></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtbatterval" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtbattercom" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr>
                                <%--<td style="display: none" class ="text-center "><asp:Label ID="lblPurchaseId" runat="server" Text='<%#Eval("Transaction_Id")%>'></asp:Label></td>--%>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="lblPDelivery" runat="server" Text="Volume"></asp:Label></td>

                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtVolumeVal" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtVolumeCom" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="lblWeight" runat="server" Text="Weight"></asp:Label></td>

                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtWeightVal" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtWeightCom" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="lblDimension" runat="server" Text="Dimension"></asp:Label></td>

                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtDimensionVal" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtDimensionCom" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="lblCrumbText" runat="server" Text="Crumb Texture"></asp:Label></td>

                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtCrumbTextVal" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtCrumbTextCom" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="lblCrumbCol" runat="server" Text="Crumb Color"></asp:Label></td>

                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtCrumbColVal" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtCrumbColCom" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="lblCrustText" runat="server" Text="Crust Texture"></asp:Label></td>

                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtCrustTextVal" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtCrustTextCom" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="lblCrustCol" runat="server" Text="Crust Color"></asp:Label></td>

                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtCrustColVal" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="txtCrustColCom" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="lblTaste" runat="server" Text="Taste"></asp:Label></td>

                                <td style="border: 1px solid; text-align: center;" colspan="2">
                                    <asp:Label ID="txtTasteVal" runat="server" CssClass="form-control "></asp:Label></td>
                                <%--<td class ="text-center "><asp:TextBox ID="txtTasteCom" runat="server" CssClass="form-control "></asp:TextBox></td>--%>
                            </tr>

                        </tbody>
                    </table>
                </div>
                <hr runat="server" id="hr2" />
                <div id="tblCompareEval" runat="server">
                    <div class="table-responsive">
                        <div class="table-responsive">
                            <h4 >Evaluation</h4>
                            <table style="width: 100%;" cellpadding="5">
                                
                                <thead>
                                    <tr>
                                        <td style="border: none;"></td>
                                        <td style="border: none;">Recipe No.</td>
                                        <td style="border: none;" runat="server" id="Td1">Center Height</td>
                                        <td style="border: none;" runat="server" id="Td2">Left Side Height</td>
                                        <td style="border: none;" runat="server" id="Td3">Right Side Height</td>
                                        <td style="border: none;" runat="server" id="Td4">Sweetness</td>
                                        <td style="border: none;" runat="server" id="Td5">Flavour</td>
                                        <td style="border: none;" runat="server" id="Td6">Specific Gravity of Batter (g/l)</td>
                                        <td style="border: none;">Volume</td>
                                        <td style="border: none;">Weight</td>
                                        <td style="border: none;">Dimension</td>
                                        <td style="border: none;">Crumb Texture</td>
                                        <td style="border: none;">Crumb Color</td>
                                        <td style="border: none;">Crust Texture</td>
                                        <td style="border: none;">Crust Color</td>
                                        <td style="border: none;">Taste</td>
                                    </tr>
                                </thead>
                                <tbody>

                                    <asp:Repeater runat="server" ID="gvMultiEval">
                                        <ItemTemplate>
                                            <tr>
                                                <td style="border: 1px solid;">
                                                    <asp:Label ID="lblValue" runat="server" Text="Value" Height="20px"></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label ID="lblComment" runat="server" Text="Comment" Height="40px"></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="lblRecipeID" Visible="false" Text='<%#Eval("Recipe_Id")%>'></asp:Label>
                                                    <asp:Label runat="server" ID="lblRecipeNo" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Recipe_No"))%>'></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;" runat="server" id="mE1">
                                                    <asp:Label runat="server" ID="Label53" Height="20px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_CenterHeightVal"))%>'></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="txtDoughTemp" Height="40px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_CenterHeightCom"))%>'></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;" runat="server" id="mE2">
                                                    <asp:Label runat="server" ID="Label54" Height="20px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_LeftHeightVal"))%>'></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label55" Height="40px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_LeftHeightCom"))%>'></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;" runat="server" id="mE3">
                                                    <asp:Label runat="server" ID="Label56" Height="20px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_RightHeightVal"))%>'></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label57" Height="40px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_RightHeightCom"))%>'></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;" runat="server" id="mE4">
                                                    <asp:Label runat="server" ID="Label58" Height="20px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_SweetnessVal"))%>'></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label59" Height="40px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_SweetnessCom"))%>'></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;" runat="server" id="mE5">
                                                    <asp:Label runat="server" ID="Label60" Height="20px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_FlavourVal"))%>'></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label61" Height="40px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_FlavourCom"))%>'></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;" runat="server" id="mE6">
                                                    <asp:Label runat="server" ID="Label62" Height="20px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_BatterGravityVal"))%>'></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label63" Height="40px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_BatterGravityCom"))%>'></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="Label64" Height="20px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_VolumeVal"))%>'></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label65" Height="40px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_VolumeCom"))%>'></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="Label66" Height="20px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_WeightVal"))%>'></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label67" Height="40px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_WeightCom"))%>'></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="Label7" Height="20px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_DimensionVal"))%>'></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label68" Height="40px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_DimensionCom"))%>'></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="Label69" Height="20px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_CrumbTextureVal"))%>'></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label70" Height="40px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_CrumbTextureCom"))%>'></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="Label71" Height="20px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_CrumbColorVal"))%>'></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label72" Height="40px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_CrumbColorCom"))%>'></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="Label73" Height="20px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_CrustTextureVal"))%>'></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label74" Height="40px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_CrustTextureCom"))%>'></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="Label9" Height="20px " Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_CrustColorVal"))%>'></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label10" Height="40px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_CrustColorCom"))%>'></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="Label75" Height="20px" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("TrialEval_Taste"))%>'></asp:Label>

                                                </td>
                                            </tr>
                                        </ItemTemplate>

                                    </asp:Repeater>
                                    <%-- <asp:GridView ID="gvMultiEval" runat="server" Style="border: 1px dotted; width: 100%;" AutoGenerateColumns="False" DataKeyNames="" AllowCustomPaging="true"
                                        CssClass="table table-striped table-vcenter table-condensed" ShowFooter="true" GridLines="None">
                                        <Columns>
                                            <asp:BoundField DataField="RowNumber" Visible="false" />

                                            <asp:TemplateField HeaderText="Sr No." Visible="False" HeaderStyle-ForeColor="#000000" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="">
                                                <ItemTemplate>
                                                    <div class="input-group  col-md-12">
                                                        <div class="text-center">
                                                            <asp:Literal ID="ltFrom" runat="server" Text='<%#Eval("RowNumber")%>' Visible="False"></asp:Literal>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" HeaderStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                                                <HeaderTemplate></HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="border: 1px solid; text-align: center;">
                                                        <asp:Label ID="lblValue" runat="server" Text="Value" CssClass="form-control MasterGridviewItem "></asp:Label>
                                                        <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                        <asp:Label ID="lblComment" runat="server" Text="Comment" CssClass="form-control MasterGridviewItem "></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" HeaderStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                                                <HeaderTemplate>Recipe No.</HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="border: 1px solid; text-align: center; height: 38px;">
                                                        <asp:Label ID="lblRecipeID" runat="server" Text='<%#Bind("Recipe_Id")%>' CssClass="form-control MasterGridviewItem " Visible="false"></asp:Label>
                                                        <asp:Label ID="lblRecipeNo" runat="server" Text='<%#Bind("Recipe_No")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" HeaderStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                                                <HeaderTemplate>Center Height</HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="border: 1px solid; text-align: center;">
                                                        <asp:Label ID="txtcentreHtVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CenterHeightVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                        <asp:Label ID="txtcentreHtcom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CenterHeightCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                <HeaderTemplate>Left Side Height<i class="fa fa-clock-o"></i></HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="border: 1px solid; text-align: center;">
                                                        <asp:Label ID="txtLeftHeightVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_LeftHeightVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                        <asp:Label ID="txtLeftHeightCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_LeftHeightCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                <HeaderTemplate>Right Side Height</HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="border: 1px solid; text-align: center;">
                                                        <asp:Label ID="txtrightHeightVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_RightHeightVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                        <asp:Label ID="txtrightHeightCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_RightHeightCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                <HeaderTemplate>Sweetness</HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="border: 1px solid; text-align: center;">
                                                        <asp:Label ID="txtsweetVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_SweetnessVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                        <asp:Label ID="txtsweetCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_SweetnessCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                <HeaderTemplate>Flavour</HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="border: 1px solid; text-align: center;">
                                                        <asp:Label ID="txtflavorVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_FlavourVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                        <asp:Label ID="txtflavorCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_FlavourCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                <HeaderTemplate>Specific Gravity of Batter (g/litre)</HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="border: 1px solid; text-align: center;">
                                                        <asp:Label ID="txtBatterVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_BatterGravityVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                        <asp:Label ID="txtBatterCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_BatterGravityCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                <HeaderTemplate>Volume</HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="border: 1px solid; text-align: center;">
                                                        <asp:Label ID="txtVolumeVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_VolumeVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                        <asp:Label ID="txtVolumeCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_VolumeCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                <HeaderTemplate>Weight</HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="border: 1px solid; text-align: center;">
                                                        <asp:Label ID="txtWeightVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_WeightVal")%>' CssClass="form-control "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                        <asp:Label ID="txtWeightCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_WeightCom")%>' CssClass="form-control "></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="MasterGridviewItem" ItemStyle-VerticalAlign="Middle">
                                                <HeaderTemplate>Dimension</HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="border: 1px solid; text-align: center;">
                                                        <asp:Label ID="txtDimensionVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_DimensionVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                        <asp:Label ID="txtDimensionCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_DimensionCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                <HeaderTemplate>Crumb Texture</HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="border: 1px solid; text-align: center;">
                                                        <asp:Label ID="txtCrumbTextVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrumbTextureVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                        <asp:Label ID="txtCrumbTextCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrumbTextureCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                <HeaderTemplate>Crumb Color</HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="border: 1px solid; text-align: center;">
                                                        <asp:Label ID="txtCrumbColVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrumbColorVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                        <asp:Label ID="txtCrumbColCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrumbColorCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                <HeaderTemplate>Crust Texture</HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="border: 1px solid; text-align: center;">
                                                        <asp:Label ID="txtCrustTextVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrustTextureVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                        <asp:Label ID="txtCrustTextCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrustTextureCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                <HeaderTemplate>Crust Color</HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="border: 1px solid; text-align: center;">
                                                        <asp:Label ID="txtCrustColVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrustColorVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                        <asp:Label ID="txtCrustColCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrustColorCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                <HeaderTemplate>Taste</HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="border: 1px solid; text-align: center; height: 38px;">
                                                        <asp:Label ID="txtTasteVal" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_Taste")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-ForeColor="#000000" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="MasterGridviewItem" Visible="false">
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
                                    </asp:GridView>--%>
                                </tbody>
                            </table>
                            <asp:Literal runat="server" ID="Literal1"></asp:Literal>

                        </div>

                        <div id="dvPreview">
                        </div>
                    </div>
                </div>
                <hr />
                <div runat="server">
                    Remark :
                    <asp:Label runat="server" ID="lblremark"></asp:Label>
                </div>
            </div>

            <div style="padding: 5px;" runat="server" id="divblank">
                <div style="background-color: #394263; color: white; padding: 5px;">
                    Feedback (<asp:Label runat="server" ID="lblTrialNo2"></asp:Label>)<asp:Label runat="server" ID="Label8" Style="float: right;"></asp:Label>
                </div>
                <div style="margin-top: 28px;">
                    <div style="margin-top: -18px; margin-left: 01px;">
                        Trial Type : <b>
                            <asp:Label runat="server" ID="lbltype2"></asp:Label></b>
                    </div>
                    <div style="margin-top: -19px; margin-left: 290px;" runat="server" visible="false" id="divRecipecode2">
                        Recipe : <b>
                            <asp:Label runat="server" ID="lblRecipecode2"></asp:Label></b>
                    </div>
                </div>
                <hr />
                <div runat="server" id="DivEvalMethod2">
                    <table style="width: 100%;" cellpadding="5">
                        <tbody>
                            <tr>
                                <td colspan="11">Evaluation Method</td>
                            </tr>

                            <asp:Repeater runat="server" ID="rpEvalMethod2">
                                <HeaderTemplate>
                                    <tr>
                                        <td style="border: none;">Recipe No.</td>
                                        <td style="border: none;">Dough</td>
                                        <td style="border: none;">Bench</td>
                                        <td style="border: none;">Scale</td>
                                        <td style="border: none;">Scale Weight</td>
                                        <td style="border: none;">In Proofer</td>
                                        <td style="border: none;">Oven in</td>
                                        <td style="border: none;">Oven out</td>
                                        <td style="border: none;">Steam</td>
                                        <td style="border: none;">Bulk Fermentation </td>
                                        <td style="border: none;">Proofing </td>
                                        <td style="border: none;">Baking</td>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="lblRecipeID" Visible="false" Text='<%#Eval("Recipe_Id")%>'></asp:Label>
                                            <asp:Label runat="server" ID="lblRecipeNo" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Recipe_No"))%>'></asp:Label>
                                        </td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="txtDoughTemp"></asp:Label>
                                        </td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="txtBenchTime"></asp:Label></td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="txtScaleTime"></asp:Label></td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="txtScaleWeight"></asp:Label></td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="txtInProoferTime"></asp:Label></td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="txtInOvenTime"></asp:Label></td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="txtOutOvenTime"></asp:Label></td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="ltSteam"></asp:Label></td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="lblBulkferment"></asp:Label></td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="lblProofing"></asp:Label></td>
                                        <td style="border: 1px solid;">
                                            <asp:Label runat="server" ID="lblBakingTime"></asp:Label></td>
                                    </tr>
                                </ItemTemplate>

                            </asp:Repeater>
                        </tbody>
                    </table>
                    <table id="Table1" runat="server" style="border: 1px dashed black; width: 100%;" visible="false">
                        <tr>
                            <td colspan="11">Evaluation Method</td>
                        </tr>
                        <thead style="border: 1px dashed black;">
                            <tr>
                                <td style="border: none;">Recipe No.</td>
                                <td style="border: none;">Dough</td>
                                <td style="border: none;">Bench</td>
                                <td style="border: none;">Scale</td>
                                <td style="border: none;">Scale Weight</td>
                                <td style="border: none;">In Proofer</td>
                                <td style="border: none;">Oven in</td>
                                <td style="border: none;">Oven out</td>
                                <td style="border: none;">Steam</td>
                                <td style="border: none;">Bulk Fermentation </td>
                                <td style="border: none;">Proofing </td>
                                <td style="border: none;">Steam</td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr id="tr7" runat="server">
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>
                            <tr id="tr8" runat="server">
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>
                            <tr id="tr9" runat="server">
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>
                            <tr id="tr10" runat="server">
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>
                            <tr id="tr11" runat="server">
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>
                            <tr id="tr12" runat="server">
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                                <td style="border: 1px solid;">&nbsp;</td>
                            </tr>

                        </tbody>
                    </table>
                </div>
                <hr runat="server" id="hr3" />
                <div style="width: 100%;">
                    <table id="tblSingleEval2" runat="server" style="border: 1px dashed black; width: 100%;">
                        <tr>
                            <td colspan="11">Evaluation</td>
                        </tr>
                        <thead style="border: 1px dashed black;">
                            <tr>
                                <%--<th class="text-center" style="display: none">Purchase</th>--%>
                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #666666; width: 30%;"></th>
                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #666666; width: 40%;">Value</th>
                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #666666; width: 40%;">Comment</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr id="tr1" runat="server">
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label11" runat="server" Text="Center Height"></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label12" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label13" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr id="tr2" runat="server">
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label14" runat="server" Text="Left Side Height"></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label15" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label16" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr id="tr3" runat="server">
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label17" runat="server" Text="Right Side Height"></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label18" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label19" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr id="tr4" runat="server">
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label20" runat="server" Text="Sweetness"></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label21" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label22" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr id="tr5" runat="server">
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label23" runat="server" Text="Flavor"></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label24" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label25" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr id="tr6" runat="server">
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label26" runat="server" Text="Specific Gravity of Batter (g/litre)"></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label27" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label28" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr>
                                <%--<td style="display: none" class ="text-center "><asp:Label ID="lblPurchaseId" runat="server" Text='<%#Eval("Transaction_Id")%>'></asp:Label></td>--%>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label29" runat="server" Text="Volume"></asp:Label></td>

                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label30" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label31" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label32" runat="server" Text="Weight"></asp:Label></td>

                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label33" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label34" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label35" runat="server" Text="Dimension"></asp:Label></td>

                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label36" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label37" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label38" runat="server" Text="Crumb Texture"></asp:Label></td>

                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label39" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label40" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label41" runat="server" Text="Crumb Color"></asp:Label></td>

                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label42" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label43" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label44" runat="server" Text="Crust Texture"></asp:Label></td>

                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label45" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label46" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label47" runat="server" Text="Crust Color"></asp:Label></td>

                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label48" runat="server" CssClass="form-control "></asp:Label></td>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label49" runat="server" CssClass="form-control "></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid; text-align: center;">
                                    <asp:Label ID="Label50" runat="server" Text="Taste"></asp:Label></td>

                                <td style="border: 1px solid; text-align: center;" colspan="2">
                                    <asp:Label ID="Label51" runat="server" CssClass="form-control "></asp:Label></td>
                                <%--<td class ="text-center "><asp:TextBox ID="txtTasteCom" runat="server" CssClass="form-control "></asp:TextBox></td>--%>
                            </tr>

                        </tbody>
                    </table>
                </div>
                <hr runat="server" id="hr4" />
                <div id="tblCompareEval2" runat="server">
                    <div class="table-responsive">
                        <div class="table-responsive">
                                    <h4 >Evaluation</h4>
                            <table style="width: 100%;" cellpadding="5">
                                <thead>
                                    <tr>
                                        <td style="border: none;"></td>
                                        <td style="border: none;">Recipe No.</td>
                                        <td style="border: none;" runat="server" id="mH1">Center Height</td>
                                        <td style="border: none;" runat="server" id="mH2">Left Side Height</td>
                                        <td style="border: none;" runat="server" id="mH3">Right Side Height</td>
                                        <td style="border: none;" runat="server" id="mH4">Sweetness</td>
                                        <td style="border: none;" runat="server" id="mH5">Flavour</td>
                                        <td style="border: none;" runat="server" id="mH6">Specific Gravity of Batter (g/l)</td>
                                        <td style="border: none;">Volume</td>
                                        <td style="border: none;">Weight</td>
                                        <td style="border: none;">Dimension</td>
                                        <td style="border: none;">Crumb Texture</td>
                                        <td style="border: none;">Crumb Color</td>
                                        <td style="border: none;">Crust Texture</td>
                                        <td style="border: none;">Crust Color</td>
                                        <td style="border: none;">Taste</td>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater runat="server" ID="gvMultiEval2">
                                        <ItemTemplate>
                                            <tr>
                                                <td style="border: 1px solid;">
                                                    <asp:Label ID="lblValue" runat="server" Text="Value" Height="20px"></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label ID="lblComment" runat="server" Text="Comment" Height="40px"></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="lblRecipeID" Visible="false" Text='<%#Eval("Recipe_Id")%>'></asp:Label>
                                                    <asp:Label runat="server" ID="lblRecipeNo" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Recipe_No"))%>'></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;" runat="server" id="mE1">
                                                    <asp:Label runat="server" ID="Label53" Height="20px"></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="txtDoughTemp" Height="40px"></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;" runat="server" id="mE2">
                                                    <asp:Label runat="server" ID="Label54" Height="20px"></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label55" Height="40px"></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;" runat="server" id="mE3">
                                                    <asp:Label runat="server" ID="Label56" Height="20px"></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label57" Height="40px"></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;" runat="server" id="mE4">
                                                    <asp:Label runat="server" ID="Label58" Height="20px"></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label59" Height="40px"></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;" runat="server" id="mE5">
                                                    <asp:Label runat="server" ID="Label60" Height="20px"></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label61" Height="40px"></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;" runat="server" id="mE6">
                                                    <asp:Label runat="server" ID="Label62" Height="20px"></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label63" Height="40px"></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="Label64" Height="20px"></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label65" Height="40px"></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="Label66" Height="20px"></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label67" Height="40px"></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="Label7" Height="20px"></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label68" Height="40px"></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="Label69" Height="20px"></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label70" Height="40px"></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="Label71" Height="20px"></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label72" Height="40px"></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="Label73" Height="20px"></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label74" Height="40px"></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="Label9" Height="20px"></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label runat="server" ID="Label10" Height="40px"></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="Label75" Height="20px"></asp:Label>

                                                </td>
                                            </tr>
                                        </ItemTemplate>

                                    </asp:Repeater>
                                </tbody>
                            </table>

                            <%-- <asp:GridView ID="gvMultiEval2" runat="server" Style="border: 1px dotted; width: 100%;" AutoGenerateColumns="False" DataKeyNames="" AllowCustomPaging="true"
                                CssClass="table table-striped table-vcenter table-condensed" ShowFooter="true" GridLines="None">
                                <Columns>
                                    <asp:BoundField DataField="RowNumber" Visible="false" />

                                    <asp:TemplateField HeaderText="Sr No." Visible="False" HeaderStyle-ForeColor="#000000" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                            <div class="input-group  col-md-12">
                                                <div class="text-center">
                                                    <asp:Literal ID="ltFrom" runat="server" Text='<%#Eval("RowNumber")%>' Visible="False"></asp:Literal>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" HeaderStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                                        <HeaderTemplate></HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td style="border: 1px solid;">
                                                    <asp:Label ID="lblValue" runat="server" Text="Value" CssClass="form-control MasterGridviewItem "></asp:Label>
                                                    <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                    <asp:Label ID="lblComment" runat="server" Text="Comment" CssClass="form-control MasterGridviewItem "></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="Label7" Visible="false" Text='<%#Eval("Recipe_Id")%>'></asp:Label>
                                                    <asp:Label runat="server" ID="Label9" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Recipe_No"))%>'></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="txtcentreHtVal1"></asp:Label>
                                                    <asp:Label ID="txtcentreHtcom1" TextMode="MultiLine" Rows="4" runat="server"></asp:Label>
                                                </td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="txtBenchTime"></asp:Label></td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="txtScaleTime"></asp:Label></td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="txtScaleWeight"></asp:Label></td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="txtInProoferTime"></asp:Label></td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="txtInOvenTime"></asp:Label></td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="txtOutOvenTime"></asp:Label></td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="ltSteam"></asp:Label></td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="lblBulkferment"></asp:Label></td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="lblProofing"></asp:Label></td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="lblBakingTime"></asp:Label></td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="Label10"></asp:Label></td>
                                                <td style="border: 1px solid;">
                                                    <asp:Label runat="server" ID="Label53"></asp:Label></td>
                                            </tr>
                                            <%--<div style="border: 1px solid; text-align: center;">
                                                <asp:Label ID="lblValue" runat="server" Text="Value" CssClass="form-control MasterGridviewItem "></asp:Label>
                                                <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                <asp:Label ID="lblComment" runat="server" Text="Comment" CssClass="form-control MasterGridviewItem "></asp:Label>
                                            </div>-- %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" HeaderStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>Recipe No.</HeaderTemplate>
                                        <ItemTemplate>

                                            <%-- <div style="border: 1px solid; text-align: center; height: 38px;">
                                                <asp:Label ID="lblRecipeID" runat="server" Text='<%#Bind("Recipe_Id")%>' CssClass="form-control MasterGridviewItem " Visible="false"></asp:Label>
                                                <asp:Label ID="lblRecipeNo" runat="server" Text='<%#Bind("Recipe_No")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                            </div>- -%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" HeaderStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>Center Height</HeaderTemplate>
                                        <ItemTemplate>

                                            <div style="border: 1px solid;">
                                                <asp:Label ID="txtcentreHtVal" runat="server" Text=" "></asp:Label>
                                                <hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                            </div>
                                            <div style="border: 1px solid;">
                                                <asp:Label ID="txtcentreHtcom" TextMode="MultiLine" Rows="4" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>Left Side Height<i class="fa fa-clock-o"></i></HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="border: 1px solid; text-align: center;">
                                                <asp:Label ID="txtLeftHeightVal" ToolTip="Dough Temperature" runat="server" CssClass="form-control MasterGridviewItem "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                <asp:Label ID="txtLeftHeightCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" CssClass="form-control MasterGridviewItem "></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>Right Side Height</HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="border: 1px solid; text-align: center;">
                                                <asp:Label ID="txtrightHeightVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_RightHeightVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                <asp:Label ID="txtrightHeightCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_RightHeightCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>Sweetness</HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="border: 1px solid; text-align: center;">
                                                <asp:Label ID="txtsweetVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_SweetnessVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                <asp:Label ID="txtsweetCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_SweetnessCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>Flavour</HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="border: 1px solid; text-align: center;">
                                                <asp:Label ID="txtflavorVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_FlavourVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                <asp:Label ID="txtflavorCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_FlavourCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>Specific Gravity of Batter (g/litre)</HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="border: 1px solid; text-align: center;">
                                                <asp:Label ID="txtBatterVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_BatterGravityVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                <asp:Label ID="txtBatterCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_BatterGravityCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>Volume</HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="border: 1px solid; text-align: center;">
                                                <asp:Label ID="txtVolumeVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_VolumeVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                <asp:Label ID="txtVolumeCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_VolumeCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>Weight</HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="border: 1px solid; text-align: center;">
                                                <asp:Label ID="txtWeightVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_WeightVal")%>' CssClass="form-control "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                <asp:Label ID="txtWeightCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_WeightCom")%>' CssClass="form-control "></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="MasterGridviewItem" ItemStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>Dimension</HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="border: 1px solid; text-align: center;">
                                                <asp:Label ID="txtDimensionVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_DimensionVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                <asp:Label ID="txtDimensionCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_DimensionCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>Crumb Texture</HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="border: 1px solid; text-align: center;">
                                                <asp:Label ID="txtCrumbTextVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrumbTextureVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                <asp:Label ID="txtCrumbTextCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrumbTextureCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>Crumb Color</HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="border: 1px solid; text-align: center;">
                                                <asp:Label ID="txtCrumbColVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrumbColorVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                <asp:Label ID="txtCrumbColCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrumbColorCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>Crust Texture</HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="border: 1px solid; text-align: center;">
                                                <asp:Label ID="txtCrustTextVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrustTextureVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                <asp:Label ID="txtCrustTextCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrustTextureCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>Crust Color</HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="border: 1px solid; text-align: center;">
                                                <asp:Label ID="txtCrustColVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrustColorVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label><hr style="-webkit-margin-before: 0; -webkit-margin-after: 0;" />
                                                <asp:Label ID="txtCrustColCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrustColorCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-ForeColor="#000000" HeaderStyle-Width="10%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>Taste</HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="border: 1px solid; text-align: center; height: 38px;">
                                                <asp:Label ID="txtTasteVal" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_Taste")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-ForeColor="#000000" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="MasterGridviewItem" Visible="false">
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
                            </asp:GridView>--%>
                            <asp:Literal runat="server" ID="Literal2"></asp:Literal>

                        </div>

                        <div id="dvPreview1">
                        </div>
                    </div>
                </div>
                <hr />
                <div runat="server">
                    Remark :
                    <asp:Label runat="server" ID="Label52"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
