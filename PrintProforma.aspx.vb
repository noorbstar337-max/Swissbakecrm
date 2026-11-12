'Imports NReco.PdfGenerator
Imports iTextSharp.text
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf

Partial Class PrintProforma
    Inherits System.Web.UI.Page
    Dim countrydt As DataTable
    Dim statedt As DataTable
    Dim MainID As Integer
    Dim proformaID As Integer
    Dim VatAmount As Double = 0.0
    Dim VAT As Double = 0.0
    Dim FooterTotalAmount As Double = 0.0
    Dim TotalKg As Integer = 0
    Dim temp As String
    Dim blogcookie As HttpCookie
    Dim AccId As Integer

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            MaintainSession()
        End If
    End Sub

    Public Sub MaintainSession()
        blogcookie = Request.Cookies.Get("blogcookievalue")
        If blogcookie.Value = "None" Then
            Response.Redirect("Login.aspx")
        Else
            Dim strArr() As String
            strArr = blogcookie.Value.Split(",")
            For i As Integer = 0 To strArr.Count - 1
                If i = 0 Then
                    Session("UserId") = strArr(i)
                    temp = strArr(i)
                ElseIf i = 1 Then
                    Session("DUserId") = strArr(i)
                    temp = strArr(i)
                ElseIf i = 2 Then
                    Session("UserName") = strArr(i)
                    temp = strArr(i)
                ElseIf i = 3 Then
                    Session("UserRoleID") = strArr(i)
                    temp = strArr(i)
                ElseIf i = 4 Then
                    Session("UName") = strArr(i)
                    temp = strArr(i)
                ElseIf i = 5 Then
                    Session("Audlog_Id") = strArr(i)
                    temp = strArr(i)
                End If
            Next
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not Request.QueryString("Id") = Nothing Then
                Try
                    FillDetail()
                    FillProforma()
                    Fillcompany()
                    FillfooterDetail()
                    FillProformaGrid()
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("PrintProforma", "Page_Load", error1, Session("UserId"))
                    'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Else
                '  ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('There is no Invoice to print!')", True)
            End If
        End If
    End Sub
    Public Sub FillProforma()
        Try
            proformaID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(proformaID, "ProfromabyID")
            Dim dtProforma As New DataTable
            dtProforma = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtProforma.Rows(0)
            lblproformanumber.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Proforma_No").ToString())
            lbldate.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Proforma_Date").ToString())
            ' hfcompanyid.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Proforma_OwnerID").ToString())
            hfcompanyid.Value = 1
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PrintProforma", "lkquicktask_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillProformaGrid()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("qid")))
            grdproforma.DataSource = ItemDetailBLL.FillItemDT("Quotation", MainID, AccId)
            grdproforma.DataBind()

            If grdproforma.Rows.Count > 0 Then
                Dim lttotalamount As Label = DirectCast(grdproforma.FooterRow.FindControl("lttotalamount"), Label)
                Dim lttotalvat As Label = DirectCast(grdproforma.FooterRow.FindControl("lttotalvat"), Label)
                Dim lblsubtotal As Label = DirectCast(grdproforma.FooterRow.FindControl("lblsubtotal"), Label)
                Dim lblfreight As Label = DirectCast(grdproforma.FooterRow.FindControl("lblfreight"), Label)
                Dim lbltotalkg As Label = DirectCast(grdproforma.FooterRow.FindControl("lbltotalkg"), Label)

                For i As Integer = 0 To grdproforma.Rows.Count - 1
                    Dim ltamount As Label = DirectCast(grdproforma.Rows(i).FindControl("ltamount"), Label)
                    Dim ltPrdrate As Label = DirectCast(grdproforma.Rows(i).FindControl("ltPrdrate"), Label)
                    Dim lblvatinrs As Label = DirectCast(grdproforma.Rows(i).FindControl("lblvatinrs"), Label)
                    Dim lblvat As Label = DirectCast(grdproforma.Rows(i).FindControl("lblvat"), Label)
                    Dim hfPacking_Weight As HiddenField = DirectCast(grdproforma.Rows(i).FindControl("hfPacking_Weight"), HiddenField)
                    Dim ltquantity As Label = DirectCast(grdproforma.Rows(i).FindControl("ltquantity"), Label)
                    Dim ltkg As Label = DirectCast(grdproforma.Rows(i).FindControl("ltkg"), Label)
                    ltkg.Text = CInt(hfPacking_Weight.Value) * CInt(ltquantity.Text)
                    TotalKg = TotalKg + Convert.ToInt32(ltkg.Text)
                    ltPrdrate.Text = Math.Round(Convert.ToDouble(ltPrdrate.Text)).ToString("N2")
                    ltamount.Text = Math.Round(Convert.ToDouble(ltamount.Text)).ToString("N2")
                    lblvatinrs.Text = Math.Round(Convert.ToDouble(lblvatinrs.Text)).ToString("N2")
                    VAT = Math.Round((Math.Round(Convert.ToDouble(lblvatinrs.Text)) * Math.Round(Convert.ToDouble(ltamount.Text))) / 100)
                    VatAmount = Math.Round(VatAmount) + VAT
                    FooterTotalAmount = FooterTotalAmount + Convert.ToDouble(ltamount.Text)
                    ltamount.Text = CDbl(ltamount.Text).ToString("N2")
                    lblvatinrs.Text = VAT.ToString("N2")
                Next
                lbltotalkg.Text = TotalKg.ToString
                lblsubtotal.Text = Math.Round(FooterTotalAmount).ToString("N2")
                If Not String.IsNullOrEmpty(hfFreight.Value) Then
                    lblfreight.Text = Math.Round(Convert.ToDouble(hfFreight.Value)).ToString("N2")
                End If
                FooterTotalAmount = Math.Round(FooterTotalAmount + VatAmount + Convert.ToDouble(lblfreight.Text))
                lttotalamount.Text = FooterTotalAmount.ToString("N2")
                lttotalvat.Text = Math.Round(VatAmount).ToString("N2")
                lblamountword.Text = MainBLL.NumbersToWords(FooterTotalAmount) + " Only"
                lblvatword.Text = MainBLL.NumbersToWords(VatAmount) + " Only"
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PrintProforma", "lkquicktask_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
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
            lblcompanyName.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_Name").ToString())
            lblcompanyaddress.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_Address").ToString())
            lblCompanyEmail.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_EmailId").ToString())
            lblcompanypan.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_PAN").ToString())
            lblcompanyvat.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_VAT").ToString())
            lblcompanycst.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_CST").ToString())
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PrintProforma", "Fillcompany", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillDetail()
        Try
            proformaID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("qid")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "ViewQuotation")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            lblsuplierref.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_No").ToString())
            lblsuplierref.Text += "/" + DynamicparcelDataManipulation.DateFormatfirstdate(drLogin("Quotation_Date").ToString())
            lbltermsofpay.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_ModeOFPayment").ToString())
            lbltermofdelivery.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_TermOFDelivery").ToString())
            lbldispatch.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_DispatchThrough").ToString())
            hfFreight.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Freight").ToString())
            AccId = DynamicparcelDataManipulation.FixNullFromDB(drLogin("acc_id").ToString())
            FillBillingAddressDetail()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PrintProforma", "FillDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Private Sub FillBillingAddressDetail()
        Try
            countrydt = MainBLL.Dropdown("CountryDropDown").Tables(0)
            statedt = MainBLL.Dropdown("ALLStateDropDown").Tables(0)

            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(AccId, "ProspectBillingAddressViewByID")
            Dim dtOrder As New DataTable
            dtOrder = dt.Tables(0)
            Dim drOrderRow As DataRow
            drOrderRow = dtOrder.Rows(0)
            dtOrder = dt.Tables(0)
            drOrderRow = dtOrder.Rows(0)

            lblaccname.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("AccAddr_Name").ToString()) + " - " + DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Acc_Code").ToString())
            lblaccname2.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("AccAddr_Name").ToString()) + " - " + DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Acc_Code").ToString())

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
            If dtOrder.Rows.Count > 0 Then
                drOrderRow = dtOrder.Rows(0)
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
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ' ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillfooterDetail()
        Try
            Dim dt As DataSet = MainBLL.ViewByID(AccId, "ACCTaxationDetail")
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
            ExecptionBLL.Insert("PrintProforma", "FillfooterDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

   
End Class
