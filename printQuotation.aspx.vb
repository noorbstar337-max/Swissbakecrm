
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Drawing

Imports System.Drawing.Imaging
Imports System.IO
Partial Class printQuotation

    Inherits System.Web.UI.Page
    ' using System.Text;
    Dim countrydt As DataTable
    Dim statedt As DataTable
    Dim QuotationID As Integer
    Dim qtyp, qval As String
    Public VatAmount As Double = 0.0
    Public FooterTotalAmount As Double = 0.0
    Public TotalKg As Integer = 0
    Public name As String
    Public sb As New StringBuilder

    Private bc As New BarcodeLib.Barcode()
    Dim BitBarcode As New Bitmap(120, 80)
    Dim imagepath As String
    Dim quotationNumber As String


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not Request.QueryString("Id") = Nothing Then
                Try
                    FillDetail()
                    Fillcompany()
                    Filladdress()
                    FillMainProduct()
                    FillfooterDetail()
                    ' fillbarcode()
                    '  lblquotationtype.Text = "(" + ddquotationtype.SelectedValue + ")"
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("PrintSalesOrder", "Page_Load", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Else
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('There is no quotation to print!')", True)
            End If

        End If
    End Sub
    Public Sub fillbarcode()
        Dim W As Integer = 260
        Dim H As Integer = 60
        Dim belowbarcode As String = quotationNumber
        Dim barCode As String = quotationNumber

        Dim imgBarCode As New System.Web.UI.WebControls.Image()
        'Barcode alignment
        bc.Alignment = BarcodeLib.AlignmentPositions.CENTER
        Dim type As BarcodeLib.TYPE = BarcodeLib.TYPE.UNSPECIFIED
        type = BarcodeLib.TYPE.CODE128

        If type <> BarcodeLib.TYPE.UNSPECIFIED Then
            bc.IncludeLabel = False
            bc.RotateFlipType = DirectCast([Enum].Parse(GetType(RotateFlipType), "rotatenoneflipnone", True), RotateFlipType)
            'label alignment and position
            bc.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER
            '===== Encoding performed here =====
            Me.BitBarcode = bc.Encode(type, belowbarcode, System.Drawing.Color.Black, System.Drawing.Color.White, W, H)
            'Dim filename As String = Path.GetFileName(_candId)
            'imagepath = "img/Barcode/" + filename + ".jpg"
            'Dim path1 As String = Server.MapPath("~/img/Barcode/" + filename)
            'BitBarcode.Save(path1 + ".jpg")
            Using ms As New MemoryStream()
                BitBarcode.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                Dim byteImage As Byte() = ms.ToArray()

                Convert.ToBase64String(byteImage)
                '  imgBarCode.ImageUrl = "data:image/png;base64," & Convert.ToBase64String(byteImage)TryCast(e.Item.FindControl("inwt"), System.Web.UI.WebControls.Label)
                '  Dim Image1 As System.Web.UI.WebControls.Image = TryCast(e.Item.FindControl("Image1"), System.Web.UI.WebControls.Image)
                '' Image1.ImageUrl = "data:image/png;base64," & Convert.ToBase64String(byteImage)
            End Using
        End If
    End Sub
    Public Sub FillDetail()
        Try
            QuotationID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            ' qtyp = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Qtyp")))
            ' qval = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("QVal")))
            Dim dt As DataSet = MainBLL.ViewByID(QuotationID, "quotationPrintViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)

            curtype.Value = dt.Tables(0).Rows(0)("Quotation_Currency")
            currate.Value = dt.Tables(0).Rows(0)("Quotation_CurrencyRate")

            If String.IsNullOrEmpty(drLogin("quotation_TermsOfPayment").ToString()) Then
                'lbltermsofpay.Text = "&nbsp;"
            Else
                'lbltermsofpay.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("quotation_TermsOfPayment").ToString())
            End If

            If Not String.IsNullOrEmpty(drLogin("Quotation_ModeOfTransport").ToString()) Then
                lblmodeoftrans.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_ModeOfTransport").ToString())
            End If
            If Not String.IsNullOrEmpty(drLogin("Quotation_CreatedDate").ToString()) Then
                lblmodeoftrans.Text += "/" + DynamicparcelDataManipulation.DateFormatfirstdate(drLogin("Quotation_CreatedDate").ToString())
            End If
            'If Not String.IsNullOrEmpty(drLogin("Quotation_FlightNo").ToString()) Then
            '    lblvesselflightno.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_FlightNo").ToString())
            'End If
            'If Not String.IsNullOrEmpty(drLogin("Quotation_FlightNo").ToString()) Then
            '    lblvesselflightno.Text += "/" + DynamicparcelDataManipulation.DateFormatfirstdate(drLogin("Quotation_FlightNo").ToString())
            'Else
            '    lblvesselflightno.Text = "&nbsp;"
            'End If
            lbldate.Text = DynamicparcelDataManipulation.AlphaDateFormat(drLogin("quotation_Date").ToString())
            lblquotationnumber.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_No").ToString())
            quotationNumber = lblquotationnumber.Text
            hfcustid.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_TypeID").ToString())
            hfFreight.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Freight").ToString())
            hfcompanyid.Value = "1" 'DynamicparcelDataManipulation.FixNullFromDB(drLogin("quotation_BilledFrom").ToString())
            lbldate.Text = lbldate.Text.ToUpper
            lblpayment.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_TermsOfPayment").ToString())

            lblcoo.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_CountryOfOrigin").ToString())
            lblcofd.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_CountryOfFinalDestination").ToString())
            lblpol.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_PortOfLoading").ToString())
            lblpod.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_PortOfDischarge").ToString())
            'lbremark.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("quotation_Remark").ToString())

            If String.IsNullOrEmpty(drLogin("Quotation_DispatchThrough").ToString()) Then
                lbldispatch.Text = "&nbsp;"
            Else
                lbldispatch.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_DispatchThrough").ToString())
            End If
            If String.IsNullOrEmpty(drLogin("Quotation_CountryOfFinalDestination").ToString()) Then
                lbldestination.Text = "&nbsp;"
            Else
                lbldestination.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_CountryOfFinalDestination").ToString())
            End If
            'If String.IsNullOrEmpty(drLogin("quotation_DispatchDocNo").ToString()) Then
            '    lbldisdocno.Text = "&nbsp;"
            'Else
            '    lbldisdocno.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("quotation_DispatchDocNo").ToString())
            'End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PrintSalesOrder", "FillDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub Fillcompany()
        Try
            '  hfcompanyid.Value = 1
            If hfcompanyid.Value = 1 Then
                mumbank.Visible = False
                otherbank.Visible = False
                companycode.Value = "1575"
            Else
                mumbank.Visible = False
                otherbank.Visible = False
                companycode.Value = "1587"
            End If
            Dim dt As DataSet = MainBLL.ViewByID(hfcompanyid.Value, "CompanyViewByID")
            Dim dtFaq As New DataTable
            dtFaq = dt.Tables(0)
            Dim drFaqRow As DataRow
            drFaqRow = dtFaq.Rows(0)

            lblcompanypan.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_PAN").ToString())
            lblcompanyvat.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_GST").ToString())
            lblcompanycst.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_State").ToString())
            'faisal  uppercase 
            'lblcompanyName.Text = lblcompanyName.Text.ToUpper()
            'lblcompanyaddress.Text = lblcompanyaddress.Text.ToUpper()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PrintSalesOrder", "Fillcompany", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Public Sub FillMainProduct()
        Try
            grditemproduct.DataSource = QuotationBLL.ViewByID(QuotationID, "getQuotationDetailsById")
            grditemproduct.DataBind()

           
            If grditemproduct.Items.Count > 0 Then

                For i As Integer = 0 To grditemproduct.Items.Count - 1
                    Dim ltamount As Label = DirectCast(grditemproduct.Items(i).FindControl("ltamount"), Label)
                    Dim ltPrdrate As Label = DirectCast(grditemproduct.Items(i).FindControl("ltPrdrate"), Label)
                    Dim lblvatinrs As Label = DirectCast(grditemproduct.Items(i).FindControl("lblvatinrs"), Label)
                    Dim hfPacking_Weight As HiddenField = DirectCast(grditemproduct.Items(i).FindControl("hfPacking_Weight"), HiddenField)
                    Dim ltquantity As Label = DirectCast(grditemproduct.Items(i).FindControl("ltquantity"), Label)
                    Dim ltkg As Label = DirectCast(grditemproduct.Items(i).FindControl("ltkg"), Label)

                    Dim tdgstrow As HtmlTableCell = DirectCast(grditemproduct.Items(i).FindControl("tdgstrow"), HtmlTableCell)


                    If curtype.Value = "USD" Then

                        tdgstrow.Visible = False
                        ltkg.Text = CInt(hfPacking_Weight.Value) * CInt(ltquantity.Text)
                        TotalKg = TotalKg + Convert.ToInt32(ltkg.Text)
                        ltPrdrate.Text = (Convert.ToDouble(ltPrdrate.Text) / CDbl(currate.Value)).ToString("N2")
                        ltamount.Text = (Convert.ToDouble(ltamount.Text) / CDbl(currate.Value)).ToString("N2")
                        lblvatinrs.Text = Math.Round(Convert.ToDouble(lblvatinrs.Text)).ToString("N2")
                        VatAmount = VatAmount + lblvatinrs.Text
                        FooterTotalAmount = FooterTotalAmount + ltamount.Text
                        ltamount.Text = CDbl(ltamount.Text).ToString("N2")
                        lblvatinrs.Text = CDbl(lblvatinrs.Text).ToString("N2")

                        Dim lblvat As Label = DirectCast(grditemproduct.Items(i).FindControl("lblvat"), Label)

                        Dim vat As Double = (lblvatinrs.Text / ltamount.Text) * 100

                        lblvat.Text = Math.Round(CDbl(vat)).ToString("N2")


                        ' tdfgstlbl.Visible = False

                        'tbfgsttxt.Visible = False
                        'tdwgstlbl.Visible = False

                        'tbwgsttxt.Visible = False
                        VatAmount = "0.0"
                    Else

                        ltkg.Text = CInt(hfPacking_Weight.Value) * CInt(ltquantity.Text)
                        TotalKg = TotalKg + Convert.ToInt32(ltkg.Text)
                        ltPrdrate.Text = Math.Round(Convert.ToDouble(ltPrdrate.Text)).ToString("N2")
                        ltamount.Text = Math.Round(Convert.ToDouble(ltamount.Text)).ToString("N2")
                        lblvatinrs.Text = Math.Round(Convert.ToDouble(lblvatinrs.Text)).ToString("N2")
                        VatAmount = VatAmount + lblvatinrs.Text
                        FooterTotalAmount = FooterTotalAmount + ltamount.Text
                        ltamount.Text = CDbl(ltamount.Text).ToString("N2")
                        lblvatinrs.Text = CDbl(lblvatinrs.Text).ToString("N2")

                        Dim lblvat As Label = DirectCast(grditemproduct.Items(i).FindControl("lblvat"), Label)

                        Dim vat As Double = (lblvatinrs.Text / ltamount.Text) * 100

                        lblvat.Text = Math.Round(CDbl(vat)).ToString("N2")


                        ' tdfgstlbl.Visible = False

                        'tbfgsttxt.Visible = False
                        'tdwgstlbl.Visible = False

                        'tbwgsttxt.Visible = False
                        ' VatAmount = "0.0"

                    End If
                Next
                lbltotalkg.Text = TotalKg.ToString
                'lblsubtotal.Text = Math.Round(FooterTotalAmount).ToString("N2")
                lblsubtotal.Text = (FooterTotalAmount).ToString("N2")
                If curtype.Value = "USD" Then
                    lblfreight.Text = (Convert.ToDouble(hfFreight.Value) / CDbl(currate.Value)).ToString("N2")
                Else
                    lblfreight.Text = Math.Round(Convert.ToDouble(hfFreight.Value)).ToString("N2")
                End If
                'FooterTotalAmount = Math.Round(FooterTotalAmount + VatAmount + Convert.ToDouble(lblfreight.Text))
                FooterTotalAmount = (FooterTotalAmount + VatAmount + Convert.ToDouble(lblfreight.Text))
                lttotalamount.Text = FooterTotalAmount.ToString("N2")
                lttotalvat.Text = Math.Round(VatAmount).ToString("N2")


                Dim arrayi As String() = FooterTotalAmount.ToString.Split(".")
                Dim decimalamt As String = MainBLL.NumbersToWords(CInt(arrayi(1)))
                If arrayi(1) > "0" Then
                    lblamountword.Text = MainBLL.NumbersToWords(CInt(arrayi(0))) + " and " + decimalamt + "  Cents Only"
                    lblvatword.Text = MainBLL.NumbersToWords(VatAmount) + " Only"
                Else
                    lblamountword.Text = MainBLL.NumbersToWords(FooterTotalAmount) + " Only"
                    lblvatword.Text = MainBLL.NumbersToWords(VatAmount) + " Only"
                End If

                If curtype.Value = "USD" Then
                    'tdfgstlbl.Visible = False
                    'tbfgsttxt.Visible = False
                    'tdwgstlbl.Visible = False
                    'tbwgsttxt.Visible = False
                    trtax.Visible = False
                    imgdomestic.Src = "img/quotation/export.png"
                    tdcol.Attributes("colspan") = "8"

                End If

                If curtype.Value = "INR" Then
                    imgdomestic.Src = "img/quotation/quation.png"
                    tdcol.Attributes("colspan") = "9"
                    trcoo.Visible = False
                    trcof.Visible = False
                    trpod.Visible = False
                    trpol.Visible = False
                    lblamountword.Text = lblamountword.Text.Replace("Cents", "Paise")
                End If



                'If curtype.Value = "USD" Then
                '    tdfgstlbl.Visible = False
                '    tbfgsttxt.Visible = False
                '    tdwgstlbl.Visible = False
                '    tbwgsttxt.Visible = False


                '    lbltotalkg.Text = CDbl(TotalKg / CDbl(currate.Value)).ToString
                '    lblsubtotal.Text = Math.Round(CDbl((FooterTotalAmount / CDbl(currate.Value)))).ToString("N2")
                '    lblfreight.Text = Math.Round(Convert.ToDouble(hfFreight.Value)).ToString("N2")
                '    FooterTotalAmount = Math.Round(FooterTotalAmount + VatAmount + Convert.ToDouble(lblfreight.Text))
                '    lttotalamount.Text = Math.Round(FooterTotalAmount / CDbl(currate.Value)).ToString("N2")
                '    lttotalvat.Text = Math.Round(VatAmount).ToString("N2")
                '    lblamountword.Text = MainBLL.NumbersToWords(FooterTotalAmount) + " Only"
                '    lblvatword.Text = MainBLL.NumbersToWords(VatAmount) + " Only"

                'Else
                '    lbltotalkg.Text = TotalKg.ToString
                '    lblsubtotal.Text = Math.Round(FooterTotalAmount).ToString("N2")
                '    lblfreight.Text = Math.Round(Convert.ToDouble(hfFreight.Value)).ToString("N2")
                '    FooterTotalAmount = Math.Round(FooterTotalAmount + VatAmount + Convert.ToDouble(lblfreight.Text))
                '    lttotalamount.Text = FooterTotalAmount.ToString("N2")
                '    lttotalvat.Text = Math.Round(VatAmount).ToString("N2")
                '    lblamountword.Text = MainBLL.NumbersToWords(FooterTotalAmount) + " Only"
                '    lblvatword.Text = MainBLL.NumbersToWords(VatAmount) + " Only"
                'End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PrintSalesOrder", "FillMainProduct", error1, Session("UserId"))
            Throw ex
        End Try
    End Sub

    Public Sub FillfooterDetail()
        Try
            QuotationID = hfcustid.Value
            Dim dt As DataSet = MainBLL.ViewByID(QuotationID, "ACCTaxationDetail")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                '' lblbuyervat.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Cust_Gst").ToString())
                'lblbuyervat.Text += " / " + DynamicparcelDataManipulation.FixNullFromDB(drLogin("Cust_Tin").ToString())

            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PrintSalesOrder", "FillfooterDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub


    Private Sub Filladdress()
        Try
            countrydt = MainBLL.Dropdown("CountryDropDown").Tables(0)
            statedt = MainBLL.Dropdown("ALLStateDropDown").Tables(0)

            QuotationID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim CustId As Integer = QuotationBLL.GetCustId(QuotationID)
            Dim dt As DataSet = MainBLL.ViewByID(CustId, "CustomerViewByID")
            Dim dtOrder As New DataTable
            dtOrder = dt.Tables(0)
            Dim drOrderRow As DataRow
            drOrderRow = dtOrder.Rows(0)
            dtOrder = dt.Tables(0)
            drOrderRow = dtOrder.Rows(0)
            custcode.Value = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("AccAddr_State").ToString())
            ''lblbuyercst.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("BuyersState").ToString())
            lblcontactmobile1.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("contact_mobile").ToString())
            lblcontactmobile11.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("contact_mobile").ToString())
            If lblcontactmobile1.Text = "" Then
                divmob1.Visible = False
            End If
            lblaccname.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Acc_Name").ToString()) ' + " - " + DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Acc_Code").ToString())
            lblcode.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Acc_Code").ToString())
            'lblcode2.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Acc_Code").ToString())
            lblbilladdress.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("AccAddr_Address").ToString())
            lblbillcity.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("AccAddr_City").ToString())
            lblaccname1.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Acc_Name").ToString()) ' + " - " + DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Acc_Code").ToString())
            lblcode1.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Acc_Code").ToString())
            'lblcode2.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Acc_Code").ToString())
            lblbilladdress1.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("AccAddr_Address").ToString())
            lblbillcity1.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("AccAddr_City").ToString())
            Dim country As Array = countrydt.Select("ID = '" + drOrderRow("AccAddr_Country").ToString() + "'")
            If country.Length <> 0 Then
                'lblbillpincode.Text = country(0)(1).ToString + " "
            End If
            Dim state As Array = statedt.Select("ID = '" + drOrderRow("AccAddr_State").ToString() + "'")

            If state.Length <> 0 Then
                lblbillpincode.Text += state(0)(1).ToString + "- "
            End If
            lblbillpincode.Text += DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("AccAddr_Pincode").ToString())
            lblbillpincode1.Text += DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("AccAddr_Pincode").ToString())
            'faisal uppercase 
            lblaccname.Text = lblaccname.Text.ToUpper
            lblbilladdress.Text = lblbilladdress.Text.ToUpper
            lblbillcity.Text = lblbillcity.Text.ToUpper
            lblaccname1.Text = lblaccname.Text.ToUpper
            lblbilladdress1.Text = lblbilladdress.Text.ToUpper
            lblbillcity1.Text = lblbillcity.Text.ToUpper


        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    'Protected Sub grditemproduct_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles grditemproduct.ItemDataBound
    '    If grditemproduct.Items.Count > 0 Then
    '        '   Dim lab As Label = TryCast(item.FindControl("lblName"), Label)
    '        '' Dim lttotalamount As Label = DirectCast(grditemproduct.FindControl("lttotalamount"), Label)
    '        'Dim lttotalvat As Label = DirectCast(grditemproduct.FindControl("lttotalvat"), Label)
    '        ''Dim lblsubtotal As Label = DirectCast(grditemproduct.FindControl("lblsubtotal"), Label)
    '        '  Dim lblfreight As Label = DirectCast(grditemproduct.FindControl("lblfreight"), Label)
    '        '  Dim lbltotalkg As Label = DirectCast(grditemproduct.FindControl("lbltotalkg"), Label)

    '        For i As Integer = 0 To grditemproduct.Items.Count - 1
    '            Dim ltamount As Label = DirectCast(grditemproduct.Items(i).FindControl("ltamount"), Label)
    '            Dim ltPrdrate As Label = DirectCast(grditemproduct.Items(i).FindControl("ltPrdrate"), Label)
    '            Dim lblvatinrs As Label = DirectCast(grditemproduct.Items(i).FindControl("lblvatinrs"), Label)
    '            Dim hfPacking_Weight As HiddenField = DirectCast(grditemproduct.Items(i).FindControl("hfPacking_Weight"), HiddenField)
    '            Dim ltquantity As Label = DirectCast(grditemproduct.Items(i).FindControl("ltquantity"), Label)
    '            Dim ltkg As Label = DirectCast(grditemproduct.Items(i).FindControl("ltkg"), Label)
    '            ltkg.Text = CInt(hfPacking_Weight.Value) * CInt(ltquantity.Text)
    '            TotalKg = TotalKg + Convert.ToInt32(ltkg.Text)
    '            ltPrdrate.Text = Math.Round(Convert.ToDouble(ltPrdrate.Text)).ToString("N2")
    '            ltamount.Text = Math.Round(Convert.ToDouble(ltamount.Text)).ToString("N2")
    '            lblvatinrs.Text = Math.Round(Convert.ToDouble(lblvatinrs.Text)).ToString("N2")
    '            VatAmount = VatAmount + lblvatinrs.Text
    '            FooterTotalAmount = FooterTotalAmount + ltamount.Text
    '            ltamount.Text = CDbl(ltamount.Text).ToString("N2")
    '            lblvatinrs.Text = CDbl(lblvatinrs.Text).ToString("N2")


    '            '  Dim ltamount As Literal = DirectCast(grditemproduct.Rows(i).FindControl("ltamount"), Literal)
    '            ' Dim lblvatinrs As Label = DirectCast(grditemproduct.Rows(i).FindControl("lblvatinrs"), Label)
    '            Dim lblvat As Label = DirectCast(grditemproduct.Items(i).FindControl("lblvat"), Label)
    '            '  Dim txtvat As TextBox = DirectCast(grditemproduct.Rows(i).FindControl("txtvat"), TextBox)

    '            'VatAmount = VatAmount + lblvatinrs.Text
    '            Dim vat As Double = (lblvatinrs.Text / ltamount.Text) * 100
    '            'lblvat.Text = (vat).ToString("N2")
    '            lblvat.Text = Math.Round(CDbl(vat)).ToString("N2")
    '        Next
    '        lbltotalkg.Text = TotalKg.ToString
    '        lblsubtotal.Text = Math.Round(FooterTotalAmount).ToString("N2")
    '        lblfreight.Text = Math.Round(Convert.ToDouble(hfFreight.Value)).ToString("N2")
    '        FooterTotalAmount = Math.Round(FooterTotalAmount + VatAmount + Convert.ToDouble(lblfreight.Text))
    '        lttotalamount.Text = FooterTotalAmount.ToString("N2")
    '        lttotalvat.Text = Math.Round(VatAmount).ToString("N2")
    '        lblamountword.Text = MainBLL.NumbersToWords(FooterTotalAmount) + " Only"
    '        lblvatword.Text = MainBLL.NumbersToWords(VatAmount) + " Only"
    '    End If
    '    'For Each item As RepeaterItem In grditemproduct.Items
    '    '    Dim lab As Label = TryCast(item.FindControl("lblName"), Label)
    '    'Next
    'End Sub

    'Protected Sub ddquotationtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddquotationtype.SelectedIndexChanged
    '    '  Response.Redirect(Request.RawUrl)
    '    lblquotationtype.Text = "(" + ddquotationtype.SelectedValue + ")"
    'End Sub

    'Protected Sub grditemproduct_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles grditemproduct.ItemDataBound
    '    Dim tdgstrow As HtmlTableCell = DirectCast(e.Item.FindControl("tdgstrow"), HtmlTableCell)

    '    '   Dim tdfgstlbl As HtmlTableCell = DirectCast(e.Item.FindControl("tdfgstlbl"), HtmlTableCell)

    '    '  Dim tbfgsttxt As HtmlTableCell = DirectCast(e.Item.FindControl("tbfgsttxt"), HtmlTableCell)
    '    '  Dim tdwgstlbl As HtmlTableCell = DirectCast(e.Item.FindControl("tdwgstlbl"), HtmlTableCell)

    '    ' Dim tbwgsttxt As HtmlTableCell = DirectCast(e.Item.FindControl("tbwgsttxt"), HtmlTableCell)

    '    If curtype.Value = "USD" Then
    '        '  tdgstrow.Visible = False
    '        tdfgstlbl.Visible = False

    '        tbfgsttxt.Visible = False
    '        tdwgstlbl.Visible = False

    '        tbwgsttxt.Visible = False
    '    Else

    '    End If

    'End Sub
End Class
