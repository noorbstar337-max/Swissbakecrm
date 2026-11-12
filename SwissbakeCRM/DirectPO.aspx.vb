Imports DynamicparcelEnumerations
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net

Partial Class DirectPO
    Inherits _PageBaseClass
    Dim MainID As Integer
    Dim dt As New Data.DataTable
    Dim addrowtype As New Label
    Dim Temptable As DataTable
    Dim strvat As New List(Of String)
    Private dt2 As New DataSet
    Public taxpercent As Double = "0.00", qty As Double = "0.00", grandtotal As Double = "0.00", taxamount As Double = "0.00"
    Dim QREHistory_QtnExport As Boolean
    Dim QuotationResponse_CurrencyType As String
    Dim QuotationResponse_CurrencyRate As Integer



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                MainID = 0 'Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                'FirstGridViewRow()
                'calculatefooter()

                FillGodown()
                FillVendor()
                'txtdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                '     txtdate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")
                FillBilledfrom()
                DDVendorType_SelectedIndexChanged(Nothing, Nothing)
                ddPaymentTerms_SelectedIndexChanged(Nothing, Nothing)
                ddVendor_SelectedIndexChanged(Nothing, Nothing)
                If Not MainID = "0" Then
                    FillDetail()
                    modifyspan.Visible = True
                    txtdate.Enabled = False
                Else
                    txtcode.Text = MainBLL.GetGodownCode("DirectPOCode")
                    FillGodown()
                    'txtdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                    txtdate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")
                    txtdate.Attributes("min") = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")
                    'fillVendorViewEdit()
                    modifyspan.Visible = False
                    Convertcurrency()
                End If
                '  GridView1.FooterRow.Cells(9).Attributes("colspan") = "8"
            Catch ex As Exception
                'Response.Redirect("index.aspx")
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
            '	Me.txtsearch.Attributes.Add("onkeyup", String.Format("javascript:__doPostBack('{0}','')", Me.UpdatePanel1.ClientID))
        Else
            Dim target As String = Me.Request.Form("__EVENTTARGET")

        End If


        ' txtdate.Attributes("min") = DateTime.Now.ToString("yyyy-MM-dd")
        'txtdate.Attributes("min") = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")
    End Sub

    Public Sub FillBilledfrom() ' gayatri on 09-06-17
        Dim ds As DataSet = MainBLL.Dropdown("CompanyDropDown")
        ddlbilledfrom.DataSource = ds.Tables(0)
        ddlbilledfrom.DataTextField = "Company_Name"
        ddlbilledfrom.DataValueField = "Company_ID"
        ddlbilledfrom.DataBind()
        ddlbilledfrom.Items.Insert(0, New ListItem("Select Company", "0"))
    End Sub

    Public Sub FillGodown()
        Try
            ddgodown.DataSource = MainBLL.Dropdown("GodownDropDown")
            ddgodown.DataTextField = "Godown_Name"
            ddgodown.DataValueField = "Godown_ID"
            ddgodown.DataBind()
            'ddlsource.Items.Insert(0, New ListItem("Select Source", "0"))
            ddgodown.Items.Insert(0, "Select Godown")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillVendor()
        Try
            If DDVendorType.SelectedValue = "Domestic" Then
                DDVendor.DataSource = MainBLL.Dropdown("VendorDomesticDropDown")
                DDVendor.DataTextField = "Vendor_Name"
                DDVendor.DataValueField = "Vendor_ID"
                DDVendor.DataBind()
            Else
                DDVendor.DataSource = MainBLL.Dropdown("VendorInternationalDropDown")
                DDVendor.DataTextField = "Vendor_Name"
                DDVendor.DataValueField = "Vendor_ID"
                DDVendor.DataBind()
            End If

            'ddlsource.Items.Insert(0, New ListItem("Select Source", "0"))
            ddgodown.Items.Insert(0, "Select Godown")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Protected Sub Convertcurrency()
        '  Dim amount As Double = 10.0
        ' Dim fromcurrency As String = "USD"
        '  Dim tocurrency As String = "INR"
        '  If Double.TryParse("1", amount) Then
        Try


            If txtCurrencyRate.Text = "" Then

                Dim web As New WebClient()

                'Dim url As String = String.Format("http://www.google.com/ig/calculator?hl=en&q={2}{0}%3D%3F{1}", fromcurrency.ToUpper(), tocurrency.ToUpper(), amount)
                ' Dim url As String = String.Format("http://www.google.com/ig/calculator?hl=en&q=1USD%3D%3FINR", fromcurrency.ToUpper(), tocurrency.ToUpper(), amount)

                '  Dim response As String = web.DownloadString("http://finance.yahoo.com/d/quotes.csv?e=.csv&f=sl1d1t1&s=USDINR=X")
                'Dim values As String() = Regex.Split(response, ",")
                'Dim rate As Decimal = System.Convert.ToDecimal(values(1))
                Dim response As String = web.DownloadString("https://finance.google.com/finance/converter?a=1&from=USD&to=INR&meta=ei%3Deq76Wbm0INq-uwS5hJ6gBg")
                Dim values As String() = Regex.Split(response, "class=bld>")
                Dim rate As Decimal = System.Convert.ToDecimal(values(1).Substring(0, 5))


                'Dim regex As New Regex(":(?<rhs>.+?),")
                'Dim arrDigits As String() = regex.Split(response)
                'Dim match As Match = regex.Match(response)
                'Dim rate As String = arrDigits(3)

                ' ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "alert('Invalid amount value.');", True)
                txtCurrencyRate.Text = rate.ToString("N2").Replace("D", "")
                ' End If

            End If
        Catch ex As Exception
            If txtCurrencyRate.Text = "" Then
                txtCurrencyRate.Text = "65.23"
            End If
        End Try
    End Sub
    Private Sub DDVendorType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDVendorType.SelectedIndexChanged
        Try
            If DDVendorType.SelectedValue = "Domestic" Then
                DIVQuatationTerms.Visible = False
                divplace.Visible = False
                'ddPaymentTerms.Visible = False
                'txtPaymentTerms.Visible = True
                DIVPTDD.Visible = False
                DIVPTTX.Visible = True
                'divpayter.Visible = False
                divImport.Visible = False
                FillVendor()
                FirstGridViewRow()
                calculatefooter()

            ElseIf DDVendorType.SelectedValue = "International" Then
                DIVQuatationTerms.Visible = True
                divplace.Visible = True
                'ddPaymentTerms.Visible = True
                'txtPaymentTerms.Visible = False
                DIVPTDD.Visible = True
                DIVPTTX.Visible = False
                divImport.Visible = True
                FillVendor()
                FirstGridViewRow()
                calculatefooter()

            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try
                    '    QuotationRequestBLL.UpdateQuotation(DynamicparcelDataManipulation.DateFormat(txtdate.Text), txtcode.Text, txtaddinfo.Text, ddgodown.SelectedValue, Session("UserId"), MainID, Convert.ToInt32(ddlbilledfrom.SelectedValue))
                    '    For Each row As GridViewRow In GridView1.Rows
                    '        Dim ltqrid = DirectCast(row.FindControl("ltqrid"), Literal)
                    '        Dim ltattid = DirectCast(row.FindControl("ltattid"), Literal)
                    '        Dim ddrawmaterial = DirectCast(row.FindControl("ddrawmaterial"), DropDownList)
                    '        Dim txtquantity = DirectCast(row.FindControl("txtqty"), TextBox)
                    '        Dim ddunuit = DirectCast(row.FindControl("ddunuit"), DropDownList)
                    '        Dim rfvddmaterial = DirectCast(row.FindControl("rfvddmaterial"), RequiredFieldValidator)
                    '        Dim rfvdqty = DirectCast(row.FindControl("rfvdqty"), RequiredFieldValidator)
                    '        Dim rfvddunit = DirectCast(row.FindControl("rfvddunit"), RequiredFieldValidator)
                    '        If ddrawmaterial.SelectedValue = "Select Item" Then
                    '            'vendorbll.insertprinciple(ddrawmaterial.selectedvalue, session("userid"), mainid)
                    '            rfvddmaterial.Enabled = True
                    '        Else
                    '            QuotationRequestBLL.UpdateRawMaterial(ddrawmaterial.SelectedValue, txtquantity.Text, ddunuit.SelectedValue, Session("UserId"), ltqrid.Text)
                    '        End If
                    '    Next
                    '    QuotationRequestBLL.QuotationVendorDeleteSi(MainID)



                    '    Response.Redirect("QuotationRequest.aspx")
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Case DML_OPERATION.INSERT
                Try
                    ''Adding Quotation 
                    'Dim allid As String() = (PurchaseOrderBLL.InsertdirectQuotation(DynamicparcelDataManipulation.DateFormat(txtdate.Text), DDVendor.SelectedValue, txtcode.Text, txtaddinfo.Text, ddgodown.SelectedValue, Session("UserId"), Convert.ToInt32(ddlbilledfrom.SelectedValue), Convert.ToDouble(lblamount.Text), Convert.ToDouble(lbltax.Text), Convert.ToDouble(txtFreight.Text), txtPaymentTerms.Text.Trim, txtDeliveryTerms.Text)).ToString().Split(",")

                    If DDVendorType.Text = "Domestic" Then
                        QREHistory_QtnExport = "False"
                        QuotationResponse_CurrencyType = "INR"
                        QuotationResponse_CurrencyRate = "1"
                    Else
                        QREHistory_QtnExport = "True"
                        QuotationResponse_CurrencyType = ddCurrency.Text
                        QuotationResponse_CurrencyRate = txtCurrencyRate.Text
                    End If
                    Dim allid As String()
                    If DDVendorType.SelectedValue = "Domestic" Then
                        allid = (PurchaseOrderBLL.InsertdirectQuotation(DynamicparcelDataManipulation.DateFormat(txtdate.Text), DDVendor.SelectedValue, txtcode.Text, txtaddinfo.Text, ddgodown.SelectedValue, Session("UserId"), Convert.ToInt32(ddlbilledfrom.SelectedValue), Convert.ToDouble(hfamounttotal.Value), Convert.ToDouble(hftaxtotal.Value), Convert.ToDouble(txtFreight.Text), txtPaymentTerms.Text.Trim, txtDeliveryTerms.Text, QREHistory_QtnExport, QuotationResponse_CurrencyType, QuotationResponse_CurrencyRate, ddQuatationTerms.SelectedValue, DDPLACE.SelectedValue, txtpayterm.Text)).ToString().Split(",")
                    Else
                        allid = (PurchaseOrderBLL.InsertdirectQuotation(DynamicparcelDataManipulation.DateFormat(txtdate.Text), DDVendor.SelectedValue, txtcode.Text, txtaddinfo.Text, ddgodown.SelectedValue, Session("UserId"), Convert.ToInt32(ddlbilledfrom.SelectedValue), Convert.ToDouble(hfamounttotal.Value), Convert.ToDouble(hftaxtotal.Value), Convert.ToDouble(txtFreight.Text), ddPaymentTerms.SelectedValue, txtDeliveryTerms.Text, QREHistory_QtnExport, QuotationResponse_CurrencyType, QuotationResponse_CurrencyRate, ddQuatationTerms.SelectedValue, DDPLACE.SelectedValue, txtpayterm.Text)).ToString().Split(",")
                    End If
                    Dim QuotationID As Integer = allid(0)
                    Dim QRespID As Integer = allid(1)
                    Dim QREHistory_ID As Integer = allid(2)
                    Dim PurchaseOrder_ID As Integer = PurchaseOrderBLL.InsertPurchaseOrder(QuotationID, "DIRECT", DDVendor.SelectedValue, Convert.ToDouble(hfamounttotal.Value), Convert.ToDouble(hftaxtotal.Value), Convert.ToDouble(txtFreight.Text), Session("UserId"), Session("Audlog_Id"))
                    ''Adding Raw material
                    For Each row As GridViewRow In GridView1.Rows
                        Dim ddrawmaterial = DirectCast(row.FindControl("ddproduct"), DropDownList)
                        Dim hfamount = DirectCast(row.FindControl("hfamount"), HiddenField)
                        Dim hftax = TryCast(row.FindControl("hftax"), HiddenField)
                        Dim txtquantity = DirectCast(row.FindControl("txtqty"), TextBox)
                        Dim txtRate = DirectCast(row.FindControl("txtRate"), TextBox)
                        Dim txttax = DirectCast(row.FindControl("txttax"), TextBox)
                        Dim lbltaxamount = DirectCast(row.FindControl("lbltaxamount"), Label)
                        Dim txthscode = DirectCast(row.FindControl("txthscode"), TextBox)
                        Dim txtpacksize = DirectCast(row.FindControl("txtpacksize"), TextBox)
                        Dim ddunuit = DirectCast(row.FindControl("ddunuit"), DropDownList)
                        Dim rfvddmaterial = DirectCast(row.FindControl("rfvddmaterial"), RequiredFieldValidator)
                        If ddrawmaterial.SelectedValue = "Select Item" Then
                            'vendorbll.insertprinciple(ddrawmaterial.selectedvalue, session("userid"), mainid)
                            rfvddmaterial.Enabled = True
                        Else
                            Dim amount As Double = CDbl(txtquantity.Text) * CDbl(txtRate.Text)
                            Dim taxamt As String = amount * (CDbl(txttax.Text) / 100)

                            QuotationRequestBLL.InsertRawMaterial(ddrawmaterial.SelectedValue, txtquantity.Text, ddunuit.SelectedValue, Session("UserId"), QuotationID)

                            'PurchaseOrderBLL.InsertDirectRespRawMaterial(ddrawmaterial.SelectedValue, txtquantity.Text, ddunuit.SelectedValue, Session("UserId"), QREHistory_ID, txthscode.Text, txtpacksize.Text, CDbl(txtRate.Text), CDbl(IIf(hftax.Value = "", "0", hftax.Value)))
                            PurchaseOrderBLL.InsertDirectRespRawMaterial(ddrawmaterial.SelectedValue, txtquantity.Text, ddunuit.SelectedValue, Session("UserId"), QREHistory_ID, txthscode.Text, txtpacksize.Text, CDbl(txtRate.Text), (IIf(taxamt = "", "0", taxamt)))

                            PurchaseOrderBLL.InsertPORawMaterial(ddrawmaterial.SelectedValue, PurchaseOrder_ID, txtquantity.Text, ddunuit.SelectedValue, Session("UserId"), Session("Audlog_Id"))

                            PurchaseOrderBLL.UpdatePORawMaterial(ddrawmaterial.SelectedValue, PurchaseOrder_ID, CDbl(txtRate.Text), CDbl(IIf(taxamt = "", "0", taxamt)), amount)
                            '  QuotationResponseBLL.PoIDQrespUpdate(PurchaseOrder_ID, QRespID)
                        End If
                    Next

                    ''Adding Vendor


                    Response.Redirect("polist.aspx")
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("UserId")) 'ExpenseReportByName", "FillHeaderName", error1, Session("UserId"))

                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub
    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            MainID = 0 'Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If Page.IsValid Then
               
                    If MainID = 0 Then
                        SaveProduct(DML_OPERATION.INSERT)
                    ElseIf MainID > 0 Then
                        SaveProduct(DML_OPERATION.UPDATE)
                    End If
                End If

            ' End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub FillDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "QuotationReqViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                txtcode.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationRequest_No").ToString())
                txtdate.Text = DynamicparcelDataManipulation.DateFormat(drLogin("QuotationRequest_Date").ToString())
                ddgodown.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationRequest_Godown_ID").ToString())
                txtaddinfo.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationRequest_AdditionalInfo").ToString())
                'txtaddinfo.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationRequest_Vendor_ID").ToString())
                lblmodifiedname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                lblmodifieddate.Text = DynamicparcelDataManipulation.DateFormat(drLogin("QuotationRequest_ModifiedDate").ToString())
                ddlbilledfrom.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationRequest_CompanyID").ToString())
                FillRawmaterialViewByID(dt)
                'fillVendorViewEdit()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Public Sub FillRawmaterialViewByID(ByVal ViewQuotation As DataSet)
        Dim dsRcptDtl As DataSet
        Try
            dsRcptDtl = QuotationRequestBLL.FillGridViewByID("fillmaterialByQuotation", MainID)
            Temptable = dsRcptDtl.Tables(0)
            ViewState("CurrentTable") = Temptable
            GridView1.DataSource = dsRcptDtl
            GridView1.DataBind()
        Catch ex As Exception
            Dim errorMsg As String = ex.Message.Replace(Chr(34), "")
            errorMsg = errorMsg.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, errorMsg, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (errorMsg.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillRcptDtl()
        Dim dsRcptDtl As DataSet
        Try
            dsRcptDtl = QuotationRequestBLL.FillGridView("FillRawMaterialDropDown")
            Temptable = dsRcptDtl.Tables(0)
            ViewState("CurrentTable") = Temptable
            GridView1.DataSource = dsRcptDtl
            GridView1.DataBind()

        Catch ex As Exception
            Dim errorMsg As String = ex.Message.Replace(Chr(34), "")
            errorMsg = errorMsg.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, errorMsg, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (errorMsg.ToString).ToString + "')", True)
        End Try
    End Sub








    ''Code for the vendor view edit








    '=================================FAISAL====================================




    Private Sub ddPaymentTerms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddPaymentTerms.SelectedIndexChanged
        Try
            If ddPaymentTerms.SelectedValue = "Payment against documents" Then
                'divpayter.Visible = True
                lblpaytype.Text = "documents No"
            ElseIf ddPaymentTerms.SelectedValue = "Credit" Then
                'divpayter.Visible = True
                lblpaytype.Text = "Credit"
            Else
                'divpayter.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub ddVendor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDVendor.SelectedIndexChanged
        Dim ds As DataSet = QuotationResponseBLL.vendorNameByID("vendorNameByID", DDVendor.SelectedValue)
        Dim dr As DataRow = ds.Tables(0).Rows(0)
        '   txtVendor.Text = DynamicparcelDataManipulation.FixNullFromDB(dr("Vendor_Name").ToString())
        txtPaymentTerms.Text = DynamicparcelDataManipulation.FixNullFromDB(dr("Vendor_PaymentTerms").ToString())
    End Sub
    Public Sub FillProductgridByID(ByVal viewProduct As DataSet)
        ' Dim dsRcptDtl As DataSet
        Try
            'dsRcptDtl = VendorBLL.FillGridView("fillPrinciple")
            'Temptable = dsRcptDtl.Tables(0)
            'ViewState("CurrentTable") = Temptable
            'GridView1.DataSource = dsRcptDtl
            'GridView1.DataBind()

            '   dsRcptDtl = VendorBLL.FillGridViewByID("fillPrincipleByVendor", MainID)
            Temptable = viewProduct.Tables(0)
            If Temptable.Rows.Count > 1 Then
                ViewState("Dropdown") = "None"
            Else
                ViewState("Dropdown") = ""
            End If
            ViewState("CurrentTable") = Temptable
            GridView1.DataSource = Temptable ' dsRcptDtl
            GridView1.DataBind()
            calculatefooter()

        Catch ex As Exception
            Dim errorMsg As String = ex.Message.Replace(Chr(34), "")
            errorMsg = errorMsg.Replace(Chr(39), "")
            ' ExecptionBLL.Insert("RcptDtlList", "fillRcptDtl", errorMsg, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (errorMsg.ToString).ToString + "')", True)
        End Try
    End Sub


    Private Sub FirstGridViewRow()
        Try
            Dim dt As New DataTable()
            Dim dr As DataRow = Nothing
            dt.Columns.Add(New DataColumn("RowNumber", GetType(String)))
            dt.Columns.Add(New DataColumn("QRRawMaterial_QRDID", GetType(String)))
            dt.Columns.Add(New DataColumn("QRRawMaterial_RawID", GetType(String)))
            dt.Columns.Add(New DataColumn("QRRawMaterial_Quantity", GetType(String)))
            dt.Columns.Add(New DataColumn("QRRawMaterial_Unit", GetType(String)))
            dt.Columns.Add(New DataColumn("QRRawMaterial_Hscode", GetType(String)))
            dt.Columns.Add(New DataColumn("QRRawMaterial_Packsize", GetType(String)))
            dt.Columns.Add(New DataColumn("QRRawMaterial_AMT", GetType(String)))
            dt.Columns.Add(New DataColumn("QRRawMaterial_tax", GetType(String)))
            dt.Columns.Add(New DataColumn("QRRawMaterial_totalamt", GetType(String)))
            'dt.Columns.Add(New DataColumn("Principle_EmailID", GetType(String)))
            dr = dt.NewRow()
            dr("RowNumber") = 1
            strrowcount.Value = dr("RowNumber")
            dr("QRRawMaterial_QRDID") = String.Empty
            dr("QRRawMaterial_RawID") = String.Empty
            dr("QRRawMaterial_Quantity") = String.Empty
            dr("QRRawMaterial_Unit") = String.Empty
            dr("QRRawMaterial_Hscode") = String.Empty
            dr("QRRawMaterial_Packsize") = String.Empty
            dr("QRRawMaterial_AMT") = String.Empty
            dr("QRRawMaterial_tax") = String.Empty
            dr("QRRawMaterial_totalamt") = String.Empty
            dt.Rows.Add(dr)
            ViewState("CurrentTable") = dt
            GridView1.DataSource = dt
            GridView1.DataBind()

            Dim btn1 As LinkButton = DirectCast(GridView1.Rows(0).FindControl("lnkdelete"), LinkButton)
            btn1.Visible = False
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            '  ExecptionBLL.Insert("ModifyVisa", "FirstGridViewRow", error1, Session("UserId"))
            Throw ex
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "AddNewRow" Then
                AddNewRow()
            ElseIf e.CommandName = "Add" Then
                ViewState("Dropdown") = ""
                FirstGridViewRow()
            ElseIf e.CommandName = "deletelink" Then
                If ViewState("CurrentTable") IsNot Nothing Then
                    Dim dt As DataTable = DirectCast(ViewState("CurrentTable"), DataTable)
                    Dim drCurrentRow As DataRow = Nothing
                    Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
                    If dt.Rows.Count > 0 Then
                        dt.Rows.Remove(dt.Rows(rowIndex))
                        drCurrentRow = dt.NewRow()
                        ViewState("CurrentTable") = dt
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                        For i As Integer = 0 To GridView1.Rows.Count - 2
                            GridView1.Rows(i).Cells(0).Text = Convert.ToString(i + 1)
                        Next
                        If dt.Rows.Count = 1 Then

                            Dim btn1 As LinkButton = DirectCast(GridView1.Rows(0).FindControl("lnkdelete"), LinkButton)
                            btn1.Visible = False
                        End If
                    End If
                End If
                SetPreviousData()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ' ExecptionBLL.Insert("ModifyVisa", "Gridview4_RowCommand", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)

        End Try
    End Sub
    Private Sub AddNewRow()
        Try
            Dim rowIndex As Integer = 0
            'addrowtype.Text = "NEW"
            If ViewState("CurrentTable") IsNot Nothing Then
                Dim dtCurrentTable As DataTable = DirectCast(ViewState("CurrentTable"), DataTable)
                Dim drCurrentRow As DataRow = Nothing
                If dtCurrentTable.Rows.Count > 0 Then
                    For i As Integer = 1 To dtCurrentTable.Rows.Count
                        Dim ddrawmaterial As DropDownList = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("ddproduct"), DropDownList)
                        Dim txtquantity As TextBox = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("txtqty"), TextBox)
                        Dim ddunuit As DropDownList = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("ddunuit"), DropDownList)
                        Dim txthscode As TextBox = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("txthscode"), TextBox)
                        Dim txtpacksize As TextBox = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("txtpacksize"), TextBox)
                        Dim txtrate As TextBox = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("txtrate"), TextBox)
                        Dim txttax As TextBox = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("txttax"), TextBox)
                        Dim lblsubtotal As Label = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("lblsubtotal"), Label)

                        drCurrentRow = dtCurrentTable.NewRow()
                        drCurrentRow("RowNumber") = i + 1
                        strrowcount.Value = drCurrentRow("RowNumber")
                        'drCurrentRow("RcptDtl_ID") = "0"

                        dtCurrentTable.Rows(i - 1)("QRRawMaterial_RawID") = ddrawmaterial.SelectedValue
                        dtCurrentTable.Rows(i - 1)("QRRawMaterial_Quantity") = txtquantity.Text
                        dtCurrentTable.Rows(i - 1)("QRRawMaterial_Unit") = ddunuit.SelectedValue
                        dtCurrentTable.Rows(i - 1)("QRRawMaterial_Hscode") = txthscode.Text
                        dtCurrentTable.Rows(i - 1)("QRRawMaterial_Packsize") = txtpacksize.Text
                        dtCurrentTable.Rows(i - 1)("QRRawMaterial_AMT") = txtrate.Text
                        dtCurrentTable.Rows(i - 1)("QRRawMaterial_tax") = txttax.Text
                        dtCurrentTable.Rows(i - 1)("QRRawMaterial_totalamt") = lblsubtotal.Text
                        rowIndex += 1
                    Next

                    dtCurrentTable.Rows.Add(drCurrentRow)
                    ViewState("CurrentTable") = dtCurrentTable
                    GridView1.DataSource = dtCurrentTable
                    GridView1.DataBind()
                End If
            Else
                Response.Write("ViewState is null")
            End If
            SetPreviousData()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyQuotationrequest", "AddNewRow", error1, Session("UserId"))
            Throw ex
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub SetPreviousData()
        Try
            Dim rowIndex As Integer = 0
            If ViewState("CurrentTable") IsNot Nothing Then
                Dim dt As DataTable = DirectCast(ViewState("CurrentTable"), DataTable)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim ddrawmaterial As DropDownList = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("ddproduct"), DropDownList)
                        Dim txtquantity As TextBox = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("txtqty"), TextBox)
                        Dim ddunuit As DropDownList = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("ddunuit"), DropDownList)
                        Dim txthscode As TextBox = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("txthscode"), TextBox)
                        Dim txtpacksize As TextBox = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("txtpacksize"), TextBox)
                        Dim txtrate As TextBox = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("txtrate"), TextBox)
                        Dim txttax As TextBox = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("txttax"), TextBox)
                        Dim lblsubtotal As Label = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("lblsubtotal"), Label)
                        GridView1.Rows(i).Cells(0).Text = Convert.ToString(i + 1)

                        ddrawmaterial.SelectedValue = dt.Rows(i)("QRRawMaterial_RawID").ToString
                        txtquantity.Text = dt.Rows(i)("QRRawMaterial_Quantity").ToString
                        ddunuit.Text = dt.Rows(i)("QRRawMaterial_Unit").ToString
                        txthscode.Text = dt.Rows(i)("QRRawMaterial_Hscode").ToString
                        txtpacksize.Text = dt.Rows(i)("QRRawMaterial_Packsize").ToString
                        txtrate.Text = dt.Rows(i)("QRRawMaterial_AMT").ToString
                        txttax.Text = dt.Rows(i)("QRRawMaterial_tax").ToString
                        lblsubtotal.Text = dt.Rows(i)("QRRawMaterial_totalamt").ToString
                        rowIndex += 1


                        GridView1.Rows(i).Cells(0).Text = Convert.ToString(i + 1)

                        '  ddproduct.SelectedValue = dt.Rows(i)("Product_Id").ToString
                        '   lblcontact.Text = dt.Rows(i)("Principle_ContactPerson").ToString
                        '  lblmobile.Text = dt.Rows(i)("Principle_MobileNo").ToString
                        '  lblcity.Text = dt.Rows(i)("Principle_City").ToString
                        '  lblemail.Text = dt.Rows(i)("Principle_EmailID").ToString
                        '  rowIndex += 1
                        If i < dt.Rows.Count - 1 Then
                            ddrawmaterial.Enabled = False
                        End If
                    Next
                    calculatefooter()

                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            'Dim ddprinciple As DropDownList = DirectCast(e.Row.FindControl("ddprinciple"), DropDownList)

            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim ddproduct As DropDownList = TryCast(e.Row.FindControl("ddproduct"), DropDownList)
                Dim ltattid As Literal = DirectCast(e.Row.FindControl("ltattid"), Literal)
                Dim txtqty As TextBox = DirectCast(e.Row.FindControl("txtqty"), TextBox)
                Dim txtTax As TextBox = DirectCast(e.Row.FindControl("txtTax"), TextBox)
                Dim txtRate As TextBox = DirectCast(e.Row.FindControl("txtRate"), TextBox)
                Dim lbltaxamount As Label = DirectCast(e.Row.FindControl("lbltaxamount"), Label)

                Dim ds As New DataSet

                ds = MainBLL.Dropdown("RawmaterialDropDown")

                'If ViewState("Dropdown") = "None" Then
                '    For i As Integer = ds.Tables(0).Rows.Count - 1 To 0 Step -1
                '        Dim dr As DataRow = ds.Tables(0).Rows(i)
                '        If dr("Product_Name") = "None" Then
                '            dr.Delete()
                '            ViewState("PrincpleDropdown") = ds
                '        End If
                '    Next
                '    ds = ViewState("PrincpleDropdown")

                'End If
                If txtRate.Text = "" Or txtRate.Text = "0" Then
                    txtRate.Text = 1
                End If
               If DDVendorType.Text = "Domestic" Then
                    If txtTax.Text = "" Then
                        txtTax.Text = 0
                    End If
                Else
                    txtTax.Text = 0
                    txtTax.Enabled = False
                End If
                If txtqty.Text = "" Or txtqty.Text = "0" Then
                    txtqty.Text = 1
                End If
                ddproduct.DataSource = ds.Tables(0)
                'ddprinciple.DataSource = MainBLL.Dropdown("PrincipleDropDown")
                ddproduct.DataTextField = "Rm_Name"
                ddproduct.DataValueField = "Rm_ID"
                ddproduct.DataBind()
                ' ddproduct.Items.Insert(0, "Select Item")
                ' ddproduct.Items.RemoveAt()
                ddproduct.SelectedValue = ltattid.Text
                If ltattid.Text = "" Then
                    For x As Integer = 0 To GridView1.Rows.Count - 1
                        Dim ddproduct1 As DropDownList = TryCast(GridView1.Rows(x).FindControl("ddproduct"), DropDownList)

                        ddproduct.Items.Remove(ddproduct.Items.FindByValue(ddproduct1.Text))
                    Next

                End If
                If txtqty.Text <> "" Then

                    txtqty.Text = txtqty.Text
                    lbltaxamount.Text = (txtRate.Text * txtqty.Text) * (txtTax.Text / 100)
                    ' lbltaxamount.Text = "&nbsp;₹ " + lbltaxamount.Text
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub getGridInfo()
        Dim dt As New DataTable()
        Dim dr As DataRow

        Dim i As Integer = 1

        'dt.Columns.Add(New System.Data.DataColumn("BookName", GetType([String])))
        'dt.Columns.Add(New System.Data.DataColumn("BookQty", GetType([String])))
        'dt.Columns.Add(New System.Data.DataColumn("BookImg", GetType([String])))




        dt.Columns.Add(New System.Data.DataColumn("RowNumber", GetType(String)))
        dt.Columns.Add(New System.Data.DataColumn("Product_Id", GetType(String)))
        dt.Columns.Add(New System.Data.DataColumn("Product_Name", GetType(String)))
        dt.Columns.Add(New System.Data.DataColumn("Product_Rate", GetType(String)))
        dt.Columns.Add(New System.Data.DataColumn("Product_Type", GetType(String)))
        dt.Columns.Add(New System.Data.DataColumn("Product_Tax", GetType(String)))
        dt.Columns.Add(New System.Data.DataColumn("Product_HSCODE", GetType(String)))
        dt.Columns.Add(New System.Data.DataColumn("Product_UOM", GetType(String)))
        dt.Columns.Add(New System.Data.DataColumn("Product_QTY", GetType(String)))
        dt.Columns.Add(New System.Data.DataColumn("Product_subtotal", GetType(String)))



        Dim lblsubtotalf As Label = CType(GridView1.FooterRow.FindControl("lblsubtotalf"), Label)
        Dim lblgrandtaxttotalf As Label = CType(GridView1.FooterRow.FindControl("lblgrandtaxttotalf"), Label)
        Dim lblgrandtotalf As Label = CType(GridView1.FooterRow.FindControl("lblgrandtotalf"), Label)



        For Each row As GridViewRow In GridView1.Rows
            'Dim Bookimg As Image = DirectCast(row.FindControl("BookImg"), Image)
            'Dim Booknames As Label = DirectCast(row.FindControl("lblBookName"), Label)
            'Dim Bookqty As TextBox = DirectCast(row.FindControl("TXTQty"), TextBox)
            'Dim TotalPrice As Label = DirectCast(row.FindControl("LBLTotal"), Label)


            Dim ddproduct As DropDownList = DirectCast(row.FindControl("ddproduct"), DropDownList)
            Dim txtRate As TextBox = DirectCast(row.FindControl("txtRate"), TextBox)
            Dim lbltype As Label = DirectCast(row.FindControl("lbltype"), Label)
            Dim txtTax As TextBox = DirectCast(row.FindControl("txtTax"), TextBox)
            Dim lblhscode As Label = DirectCast(row.FindControl("lblhscode"), Label)
            Dim lblUOM As Label = DirectCast(row.FindControl("lblUOM"), Label)
            Dim txtQty As TextBox = DirectCast(row.FindControl("txtQty"), TextBox)
            '    Dim row As GridViewRow = DirectCast(txtQty.NamingContainer, GridViewRow)

            'Dim txtQty As TextBox = DirectCast(row.FindControl("txtQty"), TextBox)


            Dim lblsubtotal As Label = DirectCast(row.FindControl("lblsubtotal"), Label)



            Dim ltattid As Literal = DirectCast(row.FindControl("ltattid"), Literal)
            Dim tax As Double = 0
            Dim subtotal As Double = 0
            Dim amount As Double = 0
            subtotal = ((CDbl(txtQty.Text) * CDbl(txtRate.Text)))

            tax = (subtotal * (CDbl(txtTax.Text) / 100))
            amount = ((tax) + (subtotal))
            lblsubtotal.Text = amount.ToString("N2")

            '  lblsubtotalf.Text = subtotal.ToString("N2")
            '  lblgrandtaxttotalf.Text = tax.ToString("N2")
            '  lblgrandtotalf.Text = amount.ToString("N2")

            dr = dt.NewRow()
            dr(0) = i
            dr(1) = ddproduct.SelectedValue
            dr(2) = ""
            dr(3) = txtRate.Text
            dr(4) = lbltype.Text
            dr(5) = txtTax.Text
            dr(6) = lblhscode.Text
            dr(7) = lblUOM.Text
            dr(8) = txtQty.Text
            dr(9) = lblsubtotal.Text

            dt.Rows.Add(dr)
            i = i + 1
        Next
        ' Session("QtyTable") = dt
        '  ViewState("QtyTable") = dt
        ViewState("CurrentTable") = dt
        calculatefooter()
    End Sub
    Public Sub calculatefooter()
        Dim lblsubtotalf As Label = CType(GridView1.FooterRow.FindControl("lblsubtotalf"), Label)
        Dim lblgrandtaxttotalf As Label = CType(GridView1.FooterRow.FindControl("lblgrandtaxttotalf"), Label)
        Dim lblgrandtotalf As Label = CType(GridView1.FooterRow.FindControl("lblgrandtotalf"), Label)
        Dim lblfreight As Label = CType(GridView1.FooterRow.FindControl("lblfreight"), Label)
        For x As Integer = 0 To GridView1.Rows.Count - 1 Step 1

            Dim ddproduct As DropDownList = DirectCast(GridView1.Rows(x).FindControl("ddproduct"), DropDownList)
            Dim txtRate As TextBox = DirectCast(GridView1.Rows(x).FindControl("txtRate"), TextBox)
            Dim lbltype As Label = DirectCast(GridView1.Rows(x).FindControl("lbltype"), Label)
            Dim txtTax As TextBox = DirectCast(GridView1.Rows(x).FindControl("txtTax"), TextBox)
            Dim lblhscode As Label = DirectCast(GridView1.Rows(x).FindControl("lblhscode"), Label)
            Dim lblUOM As Label = DirectCast(GridView1.Rows(x).FindControl("lblUOM"), Label)
            Dim txtQty As TextBox = DirectCast(GridView1.Rows(x).FindControl("txtQty"), TextBox)
            Dim lblsubtotal As Label = DirectCast(GridView1.Rows(x).FindControl("lblsubtotal"), Label)
            Dim lbltaxamount As Label = DirectCast(GridView1.Rows(x).FindControl("lbltaxamount"), Label)
            If txtRate.Text = "" Or txtRate.Text = "0" Then
                txtRate.Text = 1
            End If

            If DDVendorType.Text = "Domestic" Then
                If txtTax.Text = "" Then
                    txtTax.Text = 0
                End If
            Else
                txtTax.Text = 0
                txtTax.Enabled = False
            End If

            If txtQty.Text = "" Or txtQty.Text = "0" Then
                txtQty.Text = 1
            End If
            lblsubtotal.Text = (CDbl(txtRate.Text) * CDbl(txtQty.Text)).ToString("N2")
            lbltaxamount.Text = (CDbl(lblsubtotal.Text) * CDbl(txtTax.Text) / 100).ToString("N2")
            '     lbltaxamount.Text = "&nbsp;₹ " + lbltaxamount.Text

            If String.IsNullOrEmpty(txtQty.Text) Or txtQty.Text = "0" Then
                'lbltotal.Text = "0"
                'lblvat.Text = "0"
                'lblinvkg.Text = "0"
            Else
                taxpercent = taxpercent + txtTax.Text
                'lbltaxamount.Text = (lbltaxamount.Text).Replace("&nbps;₹ ", "")
                taxamount = taxamount + CDbl((lbltaxamount.Text).Replace("&nbsp;₹ ", ""))  '(txtQty.Text * txtRate.Text) * (txtTax.Text / 100)
                grandtotal = grandtotal + lblsubtotal.Text
                qty = qty + txtQty.Text

                'lblinvkg.Text = CStr(CDbl(lblweight.Text) * CDbl(txtdelqty.Text))
                'Dim amount As Double = Math.Round(Convert.ToDouble(Rate.Text)) * Math.Round(Convert.ToDouble(lblinvkg.Text))

                'Dim pvat As Double = (lblproductvat.Text / lbloAmount.Text) * 100
                'Dim vat As Double = Math.Round((CDbl(pvat) * amount) / 100)
                '' Dim vat As Double = (lblproductvat.Text / lbloAmount.Text) * 100
                ''lblvat.Text = (vat).ToString("N2")
                'vattotal = vattotal + vat
                'subtotalofinvoice = subtotalofinvoice + amount
                'lbltotal.Text = amount.ToString("N2")
                'lblvat.Text = vat.ToString("N2")
            End If
        Next
        ' taxamount = grandtotal * taxpercent / 100
        If txtFreight.Text = "" Then
            lblfreight.Text = "0"
            txtFreight.Text = "0"
        End If
        lblsubtotalf.Text = (grandtotal).ToString("N2")
        lblamount.Text = lblsubtotalf.Text


        lblfreight.Text = txtFreight.Text
        lblgrandtaxttotalf.Text = taxamount.ToString("N2")
        lbltax.Text = lblgrandtaxttotalf.Text
        lblgrandtotalf.Text = (grandtotal + taxamount + lblfreight.Text).ToString("N2")

    End Sub
End Class
