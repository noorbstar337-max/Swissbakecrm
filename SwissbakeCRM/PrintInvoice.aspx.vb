Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Drawing

Imports System.Drawing.Imaging
Imports System.IO
Partial Class PrintInvoiceNew
    Inherits System.Web.UI.Page
    ' using System.Text;
    Dim countrydt As DataTable
    Dim statedt As DataTable
    Dim MainID As Integer
    Public VatAmount As Double = 0.0
    Public FooterTotalAmount As Double = 0.0
    Public TotalKg As Integer = 0
    Public name As String
    Public sb As New StringBuilder

    Private bc As New BarcodeLib.Barcode()
    Dim BitBarcode As New Bitmap(120, 80)
    Dim imagepath As String
    Dim invoiceNumber As String


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not Request.QueryString("Id") = Nothing Then
                Try
                    FillDetail()
                    Fillcompany()
                    FillMainProduct()
                    FillfooterDetail()
                    Filladdress()
                    fillbarcode()
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("PrintSalesOrder", "Page_Load", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Else
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('There is no Invoice to print!')", True)
            End If
        End If
    End Sub
    Public Sub fillbarcode()
        Dim W As Integer = 260
        Dim H As Integer = 60
        Dim belowbarcode As String = invoiceNumber
        Dim barCode As String = invoiceNumber

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
                Image1.ImageUrl = "data:image/png;base64," & Convert.ToBase64String(byteImage)
            End Using
        End If
    End Sub
    Public Sub FillDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "InvoicePrintViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)

            If String.IsNullOrEmpty(drLogin("Invoice_TermsOfPayment").ToString()) Then
                'lbltermsofpay.Text = "&nbsp;"
            Else
                'lbltermsofpay.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Invoice_TermsOfPayment").ToString())
            End If

            If Not String.IsNullOrEmpty(drLogin("Order_Code").ToString()) Then
                lblsuplierref.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_Code").ToString())
            End If
            If Not String.IsNullOrEmpty(drLogin("Order_CreatedDate").ToString()) Then
                lblsuplierref.Text += "/" + DynamicparcelDataManipulation.DateFormatFirstDate(drLogin("Order_CreatedDate").ToString())
            End If
            If Not String.IsNullOrEmpty(drLogin("Order_PoNo").ToString()) Then
                lblbuyer.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_PoNo").ToString())
            End If
            If Not String.IsNullOrEmpty(drLogin("Order_PoDate").ToString()) Then
                lblbuyer.Text += "/" + DynamicparcelDataManipulation.DateFormatFirstDate(drLogin("Order_PoDate").ToString())
            Else
                lblbuyer.Text = "&nbsp;"
            End If
            lbldate.Text = DynamicparcelDataManipulation.AlphaDateFormat(drLogin("Invoice_Date").ToString())
            lblinvoicenumber.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Invoice_Number").ToString())
            invoiceNumber = lblinvoicenumber.Text
            hfcustid.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_CustId").ToString())
            hfFreight.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Invoice_Freight").ToString())
            hfcompanyid.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Invoice_BilledFrom").ToString())
            lbldate.Text = lbldate.Text.ToUpper
            lblpayment.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Invoice_TermsofPayment").ToString())

            '  lbltermofdelivery.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Invoice_TermsofDelivery").ToString())
            'altaf start
            'name = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Invoice_TermsofDelivery").ToString())

            'Dim name1() As String
            'name1 = name.Split(",")
            ''Dim sb1 As StringBuilder
            'For Each name As String In name1
            '    sb.Append("<li>" + name + "</li>")


            'Next

            'KeyBenefityList.InnerHtml = sb.ToString
            'altafend
            If String.IsNullOrEmpty(drLogin("Invoice_Dispatch").ToString()) Then
                lbldispatch.Text = "&nbsp;"
            Else
                lbldispatch.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Invoice_Dispatch").ToString())
            End If
            If String.IsNullOrEmpty(drLogin("Invoice_Destination").ToString()) Then
                lbldestination.Text = "&nbsp;"
            Else
                lbldestination.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Invoice_Destination").ToString())
            End If
            If String.IsNullOrEmpty(drLogin("Invoice_DispatchDocNo").ToString()) Then
                lbldisdocno.Text = "&nbsp;"
            Else
                lbldisdocno.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Invoice_DispatchDocNo").ToString())
            End If
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
            If hfcompanyid.Value = 1 Then
                mumbank.Visible = True
                otherbank.Visible = False
            Else
                mumbank.Visible = False
                otherbank.Visible = True
            End If
            Dim dt As DataSet = MainBLL.ViewByID(hfcompanyid.Value, "CompanyViewByID")
            Dim dtFaq As New DataTable
            dtFaq = dt.Tables(0)
            Dim drFaqRow As DataRow
            drFaqRow = dtFaq.Rows(0)
            'lblcompanyName.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_Name").ToString().Remove(drFaqRow("Company_Name").ToString.IndexOf("(")))

            'lblcompanyaddress.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_Address").ToString())
            ' lblCompanyEmail.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_EmailId").ToString())
            lblcompanypan.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_PAN").ToString())
            lblcompanyvat.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_VAT").ToString())
            lblcompanycst.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_CST").ToString())

            'faisal  uppercase 
            'lblcompanyName.Text = lblcompanyName.Text.ToUpper()
            ' lblcompanyaddress.Text = lblcompanyaddress.Text.ToUpper()


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
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            grditemproduct.DataSource = MainBLL.ViewByID(MainID, "InvoiceProductViewByID")
            grditemproduct.DataBind()
            If grditemproduct.Items.Count > 0 Then
                '   Dim lab As Label = TryCast(item.FindControl("lblName"), Label)
                '   Dim lttotalamount As Label = DirectCast(grditemproduct.FindControl("lttotalamount"), Label)
                '  Dim lttotalvat As Label = DirectCast(grditemproduct.FindControl("lttotalvat"), Label)
                '  Dim lblsubtotal As Label = DirectCast(grditemproduct.FindControl("lblsubtotal"), Label)
                '  Dim lblfreight As Label = DirectCast(grditemproduct.FindControl("lblfreight"), Label)
                '  Dim lbltotalkg As Label = TryCast(grditemproduct.FindControl("lbltotalkg"), Label)

                For i As Integer = 0 To grditemproduct.Items.Count - 1
                    Dim ltamount As Label = DirectCast(grditemproduct.Items(i).FindControl("ltamount"), Label)
                    Dim ltPrdrate As Label = DirectCast(grditemproduct.Items(i).FindControl("ltPrdrate"), Label)
                    Dim lblvatinrs As Label = DirectCast(grditemproduct.Items(i).FindControl("lblvatinrs"), Label)
                    Dim hfPacking_Weight As HiddenField = DirectCast(grditemproduct.Items(i).FindControl("hfPacking_Weight"), HiddenField)
                    Dim ltquantity As Label = DirectCast(grditemproduct.Items(i).FindControl("ltquantity"), Label)
                    Dim ltkg As Label = DirectCast(grditemproduct.Items(i).FindControl("ltkg"), Label)
                    'ltkg.Text = ""
                    ltkg.Text = CInt(hfPacking_Weight.Value) * CInt(ltquantity.Text)
                    TotalKg = TotalKg + Convert.ToInt32(ltkg.Text)
                    ltPrdrate.Text = Math.Round(Convert.ToDouble(ltPrdrate.Text)).ToString("N2")
                    ltamount.Text = Math.Round(Convert.ToDouble(ltamount.Text)).ToString("N2")
                    lblvatinrs.Text = Math.Round(Convert.ToDouble(lblvatinrs.Text)).ToString("N2")
                    VatAmount = VatAmount + lblvatinrs.Text
                    FooterTotalAmount = FooterTotalAmount + ltamount.Text
                    ltamount.Text = CDbl(ltamount.Text).ToString("N2")
                    lblvatinrs.Text = CDbl(lblvatinrs.Text).ToString("N2")


                    '  Dim ltamount As Literal = DirectCast(grditemproduct.Rows(i).FindControl("ltamount"), Literal)
                    ' Dim lblvatinrs As Label = DirectCast(grditemproduct.Rows(i).FindControl("lblvatinrs"), Label)
                    Dim lblvat As Label = DirectCast(grditemproduct.Items(i).FindControl("lblvat"), Label)
                    '  Dim txtvat As TextBox = DirectCast(grditemproduct.Rows(i).FindControl("txtvat"), TextBox)

                    'VatAmount = VatAmount + lblvatinrs.Text
                    Dim vat As Double = (lblvatinrs.Text / ltamount.Text) * 100
                    'lblvat.Text = (vat).ToString("N2")
                    lblvat.Text = Math.Round(CDbl(vat)).ToString("N2")
                Next
                '   lbltotalkg.Text = "5"
                lbltotalkg.Text = TotalKg.ToString
                lblsubtotal.Text = Math.Round(FooterTotalAmount).ToString("N2")
                lblfreight.Text = Math.Round(Convert.ToDouble(hfFreight.Value)).ToString("N2")
                FooterTotalAmount = Math.Round(FooterTotalAmount + VatAmount + Convert.ToDouble(lblfreight.Text))
                lttotalamount.Text = FooterTotalAmount.ToString("N2")
                lttotalvat.Text = Math.Round(VatAmount).ToString("N2")
                lblamountword.Text = MainBLL.NumbersToWords(FooterTotalAmount) + " Only"
                lblvatword.Text = MainBLL.NumbersToWords(VatAmount) + " Only"
            End If
            'If grditemproduct.Rows.Count > 0 Then
            '    Dim lttotalamount As Label = DirectCast(grditemproduct.FooterRow.FindControl("lttotalamount"), Label)
            '    Dim lttotalvat As Label = DirectCast(grditemproduct.FooterRow.FindControl("lttotalvat"), Label)
            '    Dim lblsubtotal As Label = DirectCast(grditemproduct.FooterRow.FindControl("lblsubtotal"), Label)
            '    Dim lblfreight As Label = DirectCast(grditemproduct.FooterRow.FindControl("lblfreight"), Label)
            '    Dim lbltotalkg As Label = DirectCast(grditemproduct.FooterRow.FindControl("lbltotalkg"), Label)

            '    For i As Integer = 0 To grditemproduct.Rows.Count - 1
            '        Dim ltamount As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltamount"), Label)
            '        Dim ltPrdrate As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltPrdrate"), Label)
            '        Dim lblvatinrs As Label = DirectCast(grditemproduct.Rows(i).FindControl("lblvatinrs"), Label)
            '        Dim hfPacking_Weight As HiddenField = DirectCast(grditemproduct.Rows(i).FindControl("hfPacking_Weight"), HiddenField)
            '        Dim ltquantity As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltquantity"), Label)
            '        Dim ltkg As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltkg"), Label)
            '        ltkg.Text = CInt(hfPacking_Weight.Value) * CInt(ltquantity.Text)
            '        TotalKg = TotalKg + Convert.ToInt32(ltkg.Text)
            '        ltPrdrate.Text = Math.Round(Convert.ToDouble(ltPrdrate.Text)).ToString("N2")
            '        ltamount.Text = Math.Round(Convert.ToDouble(ltamount.Text)).ToString("N2")
            '        lblvatinrs.Text = Math.Round(Convert.ToDouble(lblvatinrs.Text)).ToString("N2")
            '        VatAmount = VatAmount + lblvatinrs.Text
            '        FooterTotalAmount = FooterTotalAmount + ltamount.Text
            '        ltamount.Text = CDbl(ltamount.Text).ToString("N2")
            '        lblvatinrs.Text = CDbl(lblvatinrs.Text).ToString("N2")


            '        '  Dim ltamount As Literal = DirectCast(grditemproduct.Rows(i).FindControl("ltamount"), Literal)
            '        ' Dim lblvatinrs As Label = DirectCast(grditemproduct.Rows(i).FindControl("lblvatinrs"), Label)
            '        Dim lblvat As Label = DirectCast(grditemproduct.Rows(i).FindControl("lblvat"), Label)
            '        '  Dim txtvat As TextBox = DirectCast(grditemproduct.Rows(i).FindControl("txtvat"), TextBox)

            '        'VatAmount = VatAmount + lblvatinrs.Text
            '        Dim vat As Double = (lblvatinrs.Text / ltamount.Text) * 100
            '        'lblvat.Text = (vat).ToString("N2")
            '        lblvat.Text = Math.Round(CDbl(vat)).ToString("N2")
            '    Next
            '    lbltotalkg.Text = TotalKg.ToString
            '    lblsubtotal.Text = Math.Round(FooterTotalAmount).ToString("N2")
            '    lblfreight.Text = Math.Round(Convert.ToDouble(hfFreight.Value)).ToString("N2")
            '    FooterTotalAmount = Math.Round(FooterTotalAmount + VatAmount + Convert.ToDouble(lblfreight.Text))
            '    lttotalamount.Text = FooterTotalAmount.ToString("N2")
            '    lttotalvat.Text = Math.Round(VatAmount).ToString("N2")
            '    lblamountword.Text = InvoiceBLL.NumbersToWords(FooterTotalAmount) + " Only"
            '    lblvatword.Text = InvoiceBLL.NumbersToWords(VatAmount) + " Only"
            'End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PrintSalesOrder", "FillMainProduct", error1, Session("UserId"))
            Throw ex
        End Try
    End Sub

    Public Sub FillfooterDetail()
        Try
            MainID = hfcustid.Value
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "ACCTaxationDetail")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                lblbuyervat.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Cust_Vat").ToString())
                'lblbuyervat.Text += " / " + DynamicparcelDataManipulation.FixNullFromDB(drLogin("Cust_Tin").ToString())
                lblbuyercst.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Cust_Pan").ToString())
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

            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim CustId As Integer = hfcustid.Value
            Dim dt As DataSet = MainBLL.ViewByID(CustId, "CustomerViewByID")
            Dim dtOrder As New DataTable
            dtOrder = dt.Tables(0)
            Dim drOrderRow As DataRow
            drOrderRow = dtOrder.Rows(0)
            dtOrder = dt.Tables(0)
            drOrderRow = dtOrder.Rows(0)

            lblaccname.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Acc_Name").ToString()) ' + " - " + DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Acc_Code").ToString())
            lblaccname2.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Acc_Name").ToString()) ' + " - " + DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Acc_Code").ToString())
            lblcode.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Acc_Code").ToString())
            'lblcode2.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Acc_Code").ToString())
            lblbilladdress.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("AccAddr_Address").ToString())
            lblbillcity.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("AccAddr_City").ToString())
            Dim country As Array = countrydt.Select("ID = '" + drOrderRow("AccAddr_Country").ToString() + "'")
            If country.Length <> 0 Then
                'lblbillpincode.Text = country(0)(1).ToString + " "
            End If
            Dim state As Array = statedt.Select("ID = '" + drOrderRow("AccAddr_State").ToString() + "'")
            If state.Length <> 0 Then
                lblbillpincode.Text += state(0)(1).ToString + "- "
            End If
            lblbillpincode.Text += DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("AccAddr_Pincode").ToString())
            lblcontactmobile2.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("contact_mobile").ToString())
            lblcontactmobile1.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("contact_mobile").ToString())
            If dtOrder.Rows.Count > 0 Then
                drOrderRow = dtOrder.Rows(1)
                lblshipaddress.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("AccAddr_Address").ToString())
                lblshipcity.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("AccAddr_City").ToString())
                country = countrydt.Select("ID = '" + drOrderRow("AccAddr_Country").ToString() + "'")
                If country.Length <> 0 Then
                    'lblshippincode.Text = country(0)(1).ToString + " "
                End If
                state = statedt.Select("ID = '" + drOrderRow("AccAddr_State").ToString() + "'")
                If state.Length <> 0 Then
                    lblshippincode.Text += state(0)(1).ToString + "- "
                End If
                lblshippincode.Text += DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("AccAddr_Pincode").ToString())
            End If

            'faisal uppercase 
            lblaccname.Text = lblaccname.Text.ToUpper
            lblaccname2.Text = lblaccname2.Text.ToUpper
            lblbilladdress.Text = lblbilladdress.Text.ToUpper
            lblbillcity.Text = lblbillcity.Text.ToUpper
            lblshipaddress.Text = lblshipaddress.Text.ToUpper
            lblshipcity.Text = lblshipcity.Text.ToUpper


        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    'Protected Sub grditemproduct_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles grditemproduct.ItemDataBound
    '    If grditemproduct.Items.Count > 0 Then
    '        '   Dim lab As Label = TryCast(item.FindControl("lblName"), Label)
    '        Dim lttotalamount As Label = DirectCast(grditemproduct.FindControl("lttotalamount"), Label)
    '        Dim lttotalvat As Label = DirectCast(grditemproduct.FindControl("lttotalvat"), Label)
    '        Dim lblsubtotal As Label = DirectCast(grditemproduct.FindControl("lblsubtotal"), Label)
    '        Dim lblfreight As Label = DirectCast(grditemproduct.FindControl("lblfreight"), Label)
    '        Dim lbltotalkg As Label = DirectCast(grditemproduct.FindControl("lbltotalkg"), Label)

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
    '        lblamountword.Text = InvoiceBLL.NumbersToWords(FooterTotalAmount) + " Only"
    '        lblvatword.Text = InvoiceBLL.NumbersToWords(VatAmount) + " Only"
    '    End If
    '    'For Each item As RepeaterItem In grditemproduct.Items
    '    '    Dim lab As Label = TryCast(item.FindControl("lblName"), Label)
    '    'Next
    'End Sub
End Class
