Imports System.Drawing

Partial Class PrintSalesOrder
    Inherits System.Web.UI.Page
    Dim countrydt As DataTable
    Dim statedt As DataTable
    Dim MainID As Integer
    Dim VatAmount As Double = 0.0
    Dim FooterTotalAmount As Double = 0.0
    Dim TotalKg As Integer = 0
    Dim temp As String
    Dim blogcookie As HttpCookie
    Private bc As New BarcodeLib.Barcode()
    Dim BitBarcode As New Bitmap(120, 80)
    Dim imagepath As String
    Dim invoiceNumber As String
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            'MaintainSession()
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not Request.QueryString("Id") = Nothing Then
                Try
                    FillDetail()
                    Fillcompany()
                    FillPrimaryCont()
                    FillMainProduct()
                    FillBillingAddressDetail()
                    FillShippingAddressDetail()
                    FillfooterDetail()
                    Fillowner()
                    fillbarcode()
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("PrintSalesOrder", "Page_Load", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Else
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('There is no order to print!')", True)
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
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "EditOrderViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            ' lblmodeofpayment.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_ModeofPayment").ToString())
            lblpono.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_PoNo").ToString())
            If Not String.IsNullOrEmpty(drLogin("Order_PoDate").ToString()) Then
                lblpodate.Text = DynamicparcelDataManipulation.DateFormatfirstdate(drLogin("Order_PoDate").ToString())
            End If
            lblorderdate.Text = DynamicparcelDataManipulation.DateFormatfirstdate(drLogin("Order_CreatedDate").ToString())
            lblordercode.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_Code").ToString())
            invoiceNumber = lblordercode.Text
            hfcustid.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_CustId").ToString())
            hfownerid.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_CreatedID").ToString())
            hfFreight.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_Freight").ToString())
            hfcompanyid.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_Billedfrom").ToString())
            lbltermsofdelivery.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_TermsDelivery").ToString())
            lbldispatch.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_Dispach").ToString())
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PrintSalesOrder", "FillDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillBillingAddressDetail()
        Try
            countrydt = MainBLL.Dropdown("CountryDropDown").Tables(0)
            statedt = MainBLL.Dropdown("ALLStateDropDown").Tables(0)
            MainID = hfcustid.Value
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "ProspectBillingAddressViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                If String.IsNullOrEmpty(drLogin("AccAddr_Name").ToString()) Then
                    lblnamebill.Visible = False
                Else
                    lblnamebill.Visible = True
                    lblnamebill.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Name").ToString())
                    'lblbuyerref.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Name").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("AccAddr_Telephone").ToString()) Then
                    ' lblcontacbill.Visible = False
                Else
                    '  lblcontacbill.Visible = True
                    '  lblcontacbill.Text = "Phone: " + DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Telephone").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("AccAddr_Email").ToString()) Then
                    ' lblcontacbill.Visible = False
                Else
                    ' lblcontacbill.Visible = True
                    ' lblcontacbill.Text = " Email: " + DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Email").ToString())
                End If

                If String.IsNullOrEmpty(drLogin("AccAddr_Address").ToString()) Then
                    lbladdressbill.Visible = False
                Else
                    lbladdressbill.Visible = True
                    lbladdressbill.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Address").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("AccAddr_Pincode").ToString()) Then
                    lblpincodebill.Visible = False
                Else
                    lblpincodebill.Visible = True
                    lblpincodebill.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Pincode").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("AccAddr_City").ToString()) Then
                    lblcitybill.Visible = False
                Else
                    lblcitybill.Visible = True
                    lblcitybill.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_City").ToString())
                End If
                Dim country As Array = countrydt.Select("ID = '" + drLogin("AccAddr_Country").ToString() + "'")
                If country.Length <> 0 Then
                    lblcontrybill.Text = country(0)(1).ToString + " "
                End If
                Dim state As Array = statedt.Select("ID = '" + drLogin("AccAddr_State").ToString() + "'")
                If state.Length <> 0 Then
                    lblstatebill.Text = state(0)(1).ToString
                End If
                lblnamebill.Text = lblnamebill.Text.ToUpper
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PrintSalesOrder", "FillBillingAddressDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillShippingAddressDetail()
        Try
            countrydt = MainBLL.Dropdown("CountryDropDown").Tables(0)
            statedt = MainBLL.Dropdown("ALLStateDropDown").Tables(0)
            MainID = hfcustid.Value
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "ProspectShippingAddressViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                If String.IsNullOrEmpty(drLogin("AccAddr_Name").ToString()) Then
                    lblnameship.Visible = False
                Else
                    lblnameship.Visible = True
                    lblnameship.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Name").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("AccAddr_Telephone").ToString()) Then
                    'lblcontacship.Visible = False
                Else
                    '  lblcontacship.Visible = True
                    'lblcontacship.Text = "Phone:" + DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Telephone").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("AccAddr_Email").ToString()) Then
                    'lblcontacship.Visible = False
                Else
                    'lblcontacship.Visible = True
                    'lblcontacship.Text = " Email: " + DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Email").ToString())
                End If

                If String.IsNullOrEmpty(drLogin("AccAddr_Address").ToString()) Then
                    lbladdressShip.Visible = False
                Else
                    lbladdressShip.Visible = True
                    lbladdressShip.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Address").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("AccAddr_Pincode").ToString()) Then
                    lblpincodeship.Visible = False
                Else
                    lblpincodeship.Visible = True
                    lblpincodeship.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Pincode").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("AccAddr_City").ToString()) Then
                    lblcityship.Visible = False
                Else
                    lblcityship.Visible = True
                    lblcityship.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_City").ToString())
                End If
                Dim country As Array = countrydt.Select("ID = '" + drLogin("AccAddr_Country").ToString() + "'")
                If country.Length <> 0 Then
                    lblcontryship.Text = country(0)(1).ToString + " "
                End If
                Dim state As Array = statedt.Select("ID = '" + drLogin("AccAddr_State").ToString() + "'")
                If state.Length <> 0 Then
                    lblstateship.Text = state(0)(1).ToString
                End If
                lblnameship.Text = lblnameship.Text.ToUpper
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PrintSalesOrder", "FillShippingAddressDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub Fillcompany()
        Try
            Dim dt As DataSet = MainBLL.ViewByID(hfcompanyid.Value, "CompanyViewByID")
            Dim dtFaq As New DataTable
            dtFaq = dt.Tables(0)
            Dim drFaqRow As DataRow
            drFaqRow = dtFaq.Rows(0)
            'lblcompanyname.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_Name").ToString())
            'lblcompanyaddress.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_Address").ToString())
            'lblcompanyphone.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_Phone").ToString())
            'lblcompanyemail.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_EmailId").ToString())
            lblcompanypan.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_PAN").ToString())
            lblcompanycin.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_VAT").ToString())
            lblcompanytin.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_CST").ToString())

            'imgheader.ImageUrl = "http://crm.swissbake.in/img/CompanyImage/040515040511-Swissbake_-Headerr-800X100-px_4-10-14.png"
            'imgfooter.ImageUrl = "http://crm.swissbake.in/img/CompanyImage/040515040511-Swissbake_Footer-800X100-px_4-10-14.png"
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
            grditemproduct.DataSource = OrderBLL.FillOrderDetail(MainID)
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
                'lblamountword.Text = InvoiceBLL.NumbersToWords(FooterTotalAmount) + " Only"
                lblvatword.Text = MainBLL.NumbersToWords(VatAmount) + " Only"
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PrintSalesOrder", "FillMainProduct", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    'Public Sub FillMainProduct()
    '    Try
    '        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
    '        grditemproduct.DataSource = OrderBLL.FillOrderDetail(MainID)
    '        grditemproduct.DataBind()
    '        If grditemproduct.Rows.Count > 0 Then
    '            Dim lttotalamount As Label = DirectCast(grditemproduct.FooterRow.FindControl("lttotalamount"), Label)
    '            Dim lttotalvat As Label = DirectCast(grditemproduct.FooterRow.FindControl("lttotalvat"), Label)
    '            Dim lblsubtotal As Label = DirectCast(grditemproduct.FooterRow.FindControl("lblsubtotal"), Label)
    '            Dim lblfreight As Label = DirectCast(grditemproduct.FooterRow.FindControl("lblfreight"), Label)
    '            Dim lbltotalkg As Label = DirectCast(grditemproduct.FooterRow.FindControl("lbltotalkg"), Label)

    '            For i As Integer = 0 To grditemproduct.Rows.Count - 1
    '                Dim ltamount As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltamount"), Label)
    '                Dim lblvatinrs As Label = DirectCast(grditemproduct.Rows(i).FindControl("lblvatinrs"), Label)
    '                Dim hfPacking_Weight As HiddenField = DirectCast(grditemproduct.Rows(i).FindControl("hfPacking_Weight"), HiddenField)
    '                Dim ltquantity As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltquantity"), Label)
    '                Dim ltkg As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltkg"), Label)
    '                ltkg.Text = CInt(hfPacking_Weight.Value) * CInt(ltquantity.Text)
    '                TotalKg = TotalKg + Convert.ToInt32(ltkg.Text)
    '                ltamount.Text = Math.Round(Convert.ToDouble(ltamount.Text)).ToString("N2")
    '                lblvatinrs.Text = Math.Round(Convert.ToDouble(lblvatinrs.Text)).ToString("N2")
    '                VatAmount = VatAmount + lblvatinrs.Text
    '                FooterTotalAmount = FooterTotalAmount + ltamount.Text
    '                ltamount.Text = CDbl(ltamount.Text).ToString("N2")
    '                lblvatinrs.Text = CDbl(lblvatinrs.Text).ToString("N2")
    '            Next
    '            lbltotalkg.Text = TotalKg.ToString
    '            lblsubtotal.Text = Math.Round(FooterTotalAmount).ToString("N2")
    '            lblfreight.Text = Math.Round(Convert.ToDouble(hfFreight.Value)).ToString("N2")
    '            FooterTotalAmount = Math.Round(FooterTotalAmount + VatAmount + Convert.ToDouble(lblfreight.Text))
    '            lttotalamount.Text = FooterTotalAmount.ToString("N2")
    '            lttotalvat.Text = Math.Round(VatAmount).ToString("N2")
    '            lblamountword.Text = MainBLL.NumbersToWords(FooterTotalAmount) + " Only"
    '        End If

    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert("PrintSalesOrder", "FillMainProduct", error1, Session("UserId"))
    '        'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '        Throw ex
    '    End Try
    'End Sub

    Public Sub FillfooterDetail()
        Try
            MainID = hfcustid.Value
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "ACCTaxationDetail")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                If String.IsNullOrEmpty(drLogin("Cust_Vat").ToString()) Then
                    'lblbyuervat.Visible = False
                Else
                    lblbyuervat.Visible = True
                    lblbyuervat.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Cust_Vat").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("Cust_Tin").ToString()) Then
                    ' lblbyuervat.Visible = False
                Else
                    lblbyuervat.Visible = True
                    lblbyuervat.Text += " / " + DynamicparcelDataManipulation.FixNullFromDB(drLogin("Cust_Tin").ToString())
                End If

                If String.IsNullOrEmpty(drLogin("Cust_Pan").ToString()) Then
                    ' lblbyuervat.Visible = False
                Else
                    lblbuyerpan.Visible = True
                    lblbuyerpan.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Cust_Pan").ToString())
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PrintSalesOrder", "FillfooterDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub Fillowner()
        Try
            MainID = hfownerid.Value
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "Orderownername")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                If String.IsNullOrEmpty(drLogin("Owner").ToString()) Then
                    'lblownername.Visible = False
                Else
                    lblownername.Visible = True
                    lblownername.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Owner").ToString())
                End If

            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PrintSalesOrder", "Fillowner", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillPrimaryCont()
        Try
            MainID = hfcustid.Value
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "AccountViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                If String.IsNullOrEmpty(drLogin("Contact_ContactPerson").ToString()) Then
                    lblprimarycont.Visible = False
                Else
                    lblprimarycont.Visible = True
                    lblprimarycont.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_ContactPerson").ToString())
                    lblbuyerref.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_ContactPerson").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("Contact_Landline").ToString()) Then
                    Label1.Visible = False
                Else
                    Label1.Visible = True
                    ' lblcontPhone.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Landline").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("Contact_Mobile").ToString()) Then
                    '  Label2.Visible = False
                Else
                    'Label2.Visible = True
                    lblcontMobile.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Mobile").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("Contact_Email").ToString()) Then
                    Label3.Visible = False
                Else
                    Label3.Visible = True
                    lblcontemail.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Email").ToString())
                End If
                lblprimarycont.Text = lblprimarycont.Text.ToUpper
                lblcontemail.Text = lblcontemail.Text.ToUpper
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PrintSalesOrder", "FillPrimaryCont", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub


End Class
