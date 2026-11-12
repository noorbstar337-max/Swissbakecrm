Imports DynamicparcelEnumerations

Partial Class AddQuotationResponse
    Inherits _PageBaseClass
    Dim MainID As Integer
    Public VendorID As Integer
    Dim dt As New Data.DataTable
    Dim addrowtype As New Label
    Dim Temptable As DataTable
    Dim strvat As New List(Of String)
    Dim Total, amt, txt, freight As Integer

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
            Try
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                VendorID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("VId")))
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("index.aspx")
                End If
                If VendorID = "0" Then
                    
                    lbltitle1.Text = "New Quotation "
                    lbltitle2.Text = "New Quotation "
                    btnRejectAll.Visible = False
                    btnApprove.Visible = False
                    btnReject.Visible = False

                Else
                    lbltitle1.Text = "Modify Quotation "
                    lbltitle2.Text = "Modify Quotation "
                End If
                'DynamicparcelGridview.CheckPrivilageForModify(Session("UserRoleID"), Button1, btnadd, "Vendor.aspx")
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("AddQuotationResponse", "Page_Init", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "');window.location='index.aspx';", True)
            End Try
        Else
            Try

                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("index.aspx")
                End If
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                VendorID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("VId")))
                If VendorID = "0" Then

                    lbltitle1.Text = "New Quotation "
                    lbltitle2.Text = "New Quotation "
                    btnRejectAll.Visible = False
                    btnApprove.Visible = False
                    btnReject.Visible = False
                Else
                    lbltitle1.Text = "Modify Quotation "
                    lbltitle2.Text = "Modify Quotation "
                End If
                'DynamicparcelGridview.CheckPrivilageForModify(Session("UserRoleID"), Button1, btnadd, "Vendor.aspx")
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("AddQuotationResponse", "Page_Init", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "');window.location='index.aspx';", True)
            End Try
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                VendorID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("VId")))
                'txtDate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                If Not VendorID = "0" Then
                    '       FillDetail()
                    FillRawmaterialViewByID()
                    fillVendor()
                    FillDetail()
                    ddVendor.Enabled = False
                    txtVQNo.Enabled = False
                    txtDate.Enabled = False
                    modifyspan.Visible = True
                Else
                    '      txtcode.Text = MainBLL.GetGodownCode("QuotationCode")
                    '     FillGodown()
                    FillRawmaterialViewByID()
                    FillRespVendor()
                    txtDate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                    '    fillVendorViewEdit()
                    modifyspan.Visible = False
                    lblQReqCode.Text = QuotationResponseBLL.FillQRCode("GetReqQRCode", MainID)
                End If

            Catch ex As Exception
                'Response.Redirect("index.aspx")
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("AddQuotationResponse", "Page_Load", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
    End Sub
    Public Sub fillVendor()
        Try
            ddVendor.DataSource = MainBLL.Dropdown("VendorDropDown")
            ddVendor.DataTextField = "Vendor_Name"
            ddVendor.DataValueField = "Vendor_ID"
            ddVendor.DataBind()
            ' ddVendor.Items.Insert(0, "Select VendorType")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyVendor", "fillVendortype", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Public Sub FillRespVendor()
        Try
            ddVendor.DataSource = MainBLL.DropdownByuser("ResVdropdown", MainID)
            ddVendor.DataTextField = "Vendor_Name"
            ddVendor.DataValueField = "id"
            ddVendor.DataBind()
            'ddlsource.Items.Insert(0, New ListItem("Select Source", "0"))
            ddVendor.Items.Insert(0, "Select Vendor")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AddquotationResponse", "FillGodown", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Public Sub FillRawmaterialViewByID()
        Dim dsRcptDtl As DataSet
        Try
            If VendorID = "0" Then

                dsRcptDtl = QuotationRequestBLL.FillGridViewByID("fillmaterialByQuotation", MainID)
            Else
                dsRcptDtl = QuotationResponseBLL.FillrawRespbyID("FillrawRespbyID", MainID, VendorID)

            End If
            Temptable = dsRcptDtl.Tables(0)
            ViewState("CurrentTable") = Temptable
            GridView1.DataSource = dsRcptDtl
            GridView1.DataBind()
            ' fillRcptDtl()
        Catch ex As Exception
            Dim errorMsg As String = ex.Message.Replace(Chr(34), "")
            errorMsg = errorMsg.Replace(Chr(39), "")
            ExecptionBLL.Insert("AddquotationResponse", "fillRcptDtl", errorMsg, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (errorMsg.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            'Dim ddprinciple As DropDownList = DirectCast(e.Row.FindControl("ddprinciple"), DropDownList)
            Dim ddrawmaterial As DropDownList = TryCast(e.Row.FindControl("ddrawmaterial"), DropDownList)
            Dim ltattid As Literal = DirectCast(e.Row.FindControl("ltattid"), Literal)
            Dim ddunuit As DropDownList = DirectCast(e.Row.FindControl("ddunuit"), DropDownList)
            Dim lblunite As Label = DirectCast(e.Row.FindControl("lblunite"), Label)
            ddrawmaterial.Enabled = False
            ddunuit.Enabled = False
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim ds As New DataSet
                ds = MainBLL.Dropdown("RawmaterialDropDown")
                ddrawmaterial.DataSource = ds.Tables(0)
                'ddprinciple.DataSource = MainBLL.Dropdown("PrincipleDropDown")
                ddrawmaterial.DataTextField = "Rm_Name"
                ddrawmaterial.DataValueField = "Rm_ID"
                ddrawmaterial.DataBind()
                ' ddrawmaterial.Items.Insert(0, "Select Raw Material")
                ddrawmaterial.SelectedValue = ltattid.Text
                ddunuit.SelectedValue = lblunite.Text
            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Sub FillDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            VendorID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("VId")))
            Dim dt As DataSet = QuotationResponseBLL.FillQRespDetailbyID("FillQRespDetailbyID", MainID, VendorID)
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            txtVQNo.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationResponse_Code").ToString())
            ddVendor.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QREHistory_VendorID").ToString())
            txtDate.Text = DynamicparcelDataManipulation.DateFormat(drLogin("QuotationResponse_CreateDate").ToString())
            txtRemark.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationResponse_Remarks").ToString())
            'txtHSCode.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationResponse_HSCode").ToString())
            'txtPackSize.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationResponse_PackSize").ToString())
            txtPaymentTerms.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QREHistory_PaymentTerms").ToString())
            txtDeliveryTerms.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QREHistory_DeliveryTerms").ToString())
            txtAmount.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QREHistory_Amt").ToString())
            txtTax.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QREHistory_Tax").ToString())
            txtFreight.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QREHistory_Freight").ToString())
            txtTotalAmt.Text = Convert.ToDouble(txtAmount.Text) + Convert.ToDouble(txtTax.Text) + Convert.ToDouble(txtFreight.Text)
            txtTaxPercent.Text = (Convert.ToDouble(txtTax.Text) * 100) / Convert.ToDouble(txtAmount.Text)
            Dim txtquantity As TextBox = DirectCast(GridView1.Rows(0).FindControl("txtquantity"), TextBox)
            txtAmountPerUnit.Text = txtAmount.Text / txtquantity.Text

            hfpaymentterms.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QREHistory_PaymentTerms").ToString())
            hfDeliveryTerms.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QREHistory_DeliveryTerms").ToString())
            hfamount.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QREHistory_Amt").ToString())
            hftax.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QREHistory_Tax").ToString())
            hffreight.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QREHistory_Freight").ToString())

            ' ddgodown.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationRequest_Godown_ID").ToString())
            ' txtaddinfo.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationRequest_AdditionalInfo").ToString())
            'txtaddinfo.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationRequest_Vendor_ID").ToString())
            lblmodifiedname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
            lblmodifieddate.Text = DynamicparcelDataManipulation.AlphaDateFormat(drLogin("QDate").ToString())

            lblQReqCode.Text = QuotationResponseBLL.FillQRCode("GetReqQRCode", MainID)

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AddquotationResponse", "FillDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    '=============================GAYATRI changed UpdateQuotationResp, InsertQResponse==============================================================
    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try
                    'QuotationRequestBLL.UpdateQuotation(DynamicparcelDataManipulation.DateFormat(txtDate.Text), txtcode.Text, txtaddinfo.Text, ddgodown.SelectedValue, Session("UserId"), MainID)
                    QuotationResponseBLL.UpdateQuotationResp(txtVQNo.Text, txtRemark.Text, Session("UserId"), MainID, VendorID)

                    For Each row As GridViewRow In GridView1.Rows
                        Dim ltqrid = DirectCast(row.FindControl("ltqrid"), Literal)
                        Dim ltattid = DirectCast(row.FindControl("ltattid"), Literal)
                        Dim ddrawmaterial = DirectCast(row.FindControl("ddrawmaterial"), DropDownList)
                        Dim txtquantity = DirectCast(row.FindControl("txtquantity"), TextBox)
                        Dim txtHSCode = DirectCast(row.FindControl("txtHSCode"), TextBox)
                        Dim txtPackSize = DirectCast(row.FindControl("txtPackSize"), TextBox)
                        Dim ddunuit = DirectCast(row.FindControl("ddunuit"), DropDownList)
                        Dim rfvddmaterial = DirectCast(row.FindControl("rfvddmaterial"), RequiredFieldValidator)
                        If ddrawmaterial.SelectedValue = "Select Raw Material" Then
                            'vendorbll.insertprinciple(ddrawmaterial.selectedvalue, session("userid"), mainid)
                            rfvddmaterial.Enabled = True
                        Else
                            'QuotationRequestBLL.UpdateRawMaterial(ddrawmaterial.SelectedValue, txtquantity.Text, ddunuit.SelectedValue, Session("UserId"), ltqrid.Text)
                            QuotationResponseBLL.UpdateQRespRaw(txtquantity.Text, ddunuit.SelectedValue, Session("UserId"), MainID, VendorID, txtHSCode.Text, txtPackSize.Text)
                        End If

                    Next
                    If txtAmount.Text.Trim <> hfamount.Value Or txtTax.Text <> hftax.Value Or txtFreight.Text <> hffreight.Value Or txtPaymentTerms.Text <> hfpaymentterms.Value Or txtDeliveryTerms.Text <> hfDeliveryTerms.Value Then
                        '  If txtAmount.Text.Trim <> hfamount.Value Then


                        QuotationResponseBLL.InsertQRHistoryVersion(MainID, VendorID, txtAmount.Text.Trim, txtTax.Text.Trim, txtFreight.Text.Trim, txtPaymentTerms.Text.Trim, Session("UserId"), txtDeliveryTerms.Text.Trim)
                    End If


                    Response.Redirect("QuotationRequest.aspx")
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("AddquotationResponse", "UPDATE", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Case DML_OPERATION.INSERT
                Try
                    ''Adding Quotation 

                    Dim QuotationID As String = QuotationResponseBLL.InsertQResponse(DynamicparcelDataManipulation.DateFormat(txtDate.Text), txtVQNo.Text, txtRemark.Text, MainID, Session("UserId"))

                    Dim QREHistory_ID As String = QuotationResponseBLL.InsertQRespHistory(QuotationID, ddVendor.SelectedValue, Convert.ToDouble(txtAmount.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtFreight.Text), txtPaymentTerms.Text.Trim, txtDeliveryTerms.Text, Session("UserId"))

                    ''Adding Raw material
                    For Each row As GridViewRow In GridView1.Rows
                        Dim ddrawmaterial = DirectCast(row.FindControl("ddrawmaterial"), DropDownList)
                        Dim txtquantity = DirectCast(row.FindControl("txtquantity"), TextBox)
                        Dim txtHSCode = DirectCast(row.FindControl("txtHSCode"), TextBox)
                        Dim txtPackSize = DirectCast(row.FindControl("txtPackSize"), TextBox)
                        Dim ddunuit = DirectCast(row.FindControl("ddunuit"), DropDownList)
                        Dim rfvddmaterial = DirectCast(row.FindControl("rfvddmaterial"), RequiredFieldValidator)
                        If ddrawmaterial.SelectedValue = "Select Raw Material" Then
                            'vendorbll.insertprinciple(ddrawmaterial.selectedvalue, session("userid"), mainid)
                            rfvddmaterial.Enabled = True
                        Else
                            'QuotationRequestBLL.InsertRawMaterial(ddrawmaterial.SelectedIndex, txtquantity.Text, ddunuit.SelectedValue, Session("UserId"), QuotationID)
                            QuotationResponseBLL.InsertRespRawMaterial(ddrawmaterial.SelectedValue, txtquantity.Text, ddunuit.SelectedValue, Session("UserId"), QREHistory_ID, txtHSCode.text, txtPackSize.text)
                        End If
                    Next




                    Response.Redirect("QuotationRequest.aspx")
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("AddquotationResponse", "INSERT", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub
    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try

            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            VendorID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("VId")))
            If Page.IsValid Then
                If VendorID = 0 Then
                    SaveProduct(DML_OPERATION.INSERT)
                ElseIf VendorID > 0 Then
                    SaveProduct(DML_OPERATION.UPDATE)
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AddquotationResponse", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            VendorID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("VId")))
            QuotationResponseBLL.UpdateQuotationStatus("UpdateStatusApprove", MainID, VendorID, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('This Quotation has been approved');window.location='/Quotationrequest.aspx'", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AddquotationResponse", "btnApprove_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            VendorID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("VId")))
            QuotationResponseBLL.UpdateQuotationStatus("UpdateStatusReject1", MainID, VendorID, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('This Quotation has been rejected');window.location='/Quotationrequest.aspx'", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AddquotationResponse", "btnReject_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnRejectAll_Click(sender As Object, e As EventArgs) Handles btnRejectAll.Click
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            VendorID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("VId")))
            QuotationResponseBLL.UpdateQuotationStatus("UpdateStatusRejectAll", MainID, VendorID, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('All Quotation has been rejected');window.location='/Quotationrequest.aspx'", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AddquotationResponse", "btnRejectAll_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub hfcancel_Click(sender As Object, e As EventArgs) Handles hfcancel.Click
        Try
            Response.Redirect("QuotationRequest.aspx")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AddquotationResponse", "hfcancel_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    'Protected Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged
    '    Dim txtquantity As TextBox = DirectCast(GridView1.Rows(0).FindControl("txtquantity"), TextBox)
    '    txtAmountPerUnit.Text = txtAmount.Text / txtquantity.Text
    'End Sub

    'Protected Sub txtquantity_TextChanged(sender As Object, e As EventArgs)
    '    If txtAmountPerUnit.Text <> "" Then
    '        Dim txtquantity As TextBox = DirectCast(GridView1.Rows(0).FindControl("txtquantity"), TextBox)
    '        txtAmount.Text = txtAmountPerUnit.Text * txtquantity.Text
    '    End If
    '    If txtTaxPercent.Text <> "" Then
    '        Dim txtquantity As TextBox = DirectCast(GridView1.Rows(0).FindControl("txtquantity"), TextBox)
    '        txtTax.Text = ((txtAmountPerUnit.Text * txtquantity.Text) * (txtTaxPercent.Text / 100))
    '    End If
    'End Sub
    Protected Sub txtquantity_TextChanged(sender As Object, e As EventArgs)
        'If txtQuantity.Text = "" Then
        '    txtQuantity.Text = "0"
        'End If
        Dim txtquantity As TextBox = DirectCast(GridView1.Rows(0).FindControl("txtquantity"), TextBox)
        If txtQuantity.Text = "" Then
            ' txtFreight.Text = ""
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Please provide Quantity first')", True)
        Else

            If txtAmountPerUnit.Text <> "" Then
                txtAmount.Text = txtAmountPerUnit.Text * txtquantity.Text
                txtAmount.Text = CDbl(txtAmount.Text).ToString("N2")
            End If
            If txtTaxPercent.Text <> "" Then
                txtTax.Text = ((txtAmountPerUnit.Text * txtQuantity.Text) * (txtTaxPercent.Text / 100))
            End If
            If txtTotalAmt.Text <> "" Then
                txtTotalAmt.Text = Total.ToString()
            End If
            calculatetotal()
        End If

    End Sub

    'Protected Sub txtAmountPerUnit_TextChanged(sender As Object, e As EventArgs) Handles txtAmountPerUnit.TextChanged
    '    Dim txtquantity As TextBox = DirectCast(GridView1.Rows(0).FindControl("txtquantity"), TextBox)
    '    txtAmount.Text = txtAmountPerUnit.Text * txtquantity.Text
    '    amt = txtAmount.Text
    '    Total = amt + txt + freight
    '    txtTotalAmt.Text = Total.ToString
    'End Sub
    Protected Sub txtAmountPerUnit_TextChanged(sender As Object, e As EventArgs) Handles txtAmountPerUnit.TextChanged
        Dim txtquantity As TextBox = DirectCast(GridView1.Rows(0).FindControl("txtquantity"), TextBox)
        If txtQuantity.Text = "" Then
            ' txtFreight.Text = ""
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Please provide Quantity first')", True)
        Else
            If txtAmountPerUnit.Text = "" Then
                txtAmountPerUnit.Text = "0.0"
            End If
            txtAmount.Text = txtAmountPerUnit.Text * txtQuantity.Text
            amt = txtAmount.Text
            Total = amt + txt + freight
            txtTotalAmt.Text = Total.ToString("N2")

            txtAmount.Text = CDbl(txtAmount.Text).ToString("N2")
            txtTaxPercent_TextChanged(Nothing, Nothing)
            calculatetotal()
            txtTaxPercent.Focus()
        End If
    End Sub
    'Protected Sub txtTaxPercent_TextChanged(sender As Object, e As EventArgs) Handles txtTaxPercent.TextChanged
    '    txtTax.Text = (txtAmount.Text * (txtTaxPercent.Text / 100))
    '    txt = txtTax.Text
    '    Total = txtAmount.Text + txt + txtFreight.Text
    '    txtTotalAmt.Text = Total.ToString
    'End Sub
    Protected Sub txtTaxPercent_TextChanged(sender As Object, e As EventArgs) Handles txtTaxPercent.TextChanged
        Dim txtquantity As TextBox = DirectCast(GridView1.Rows(0).FindControl("txtquantity"), TextBox)
        If txtQuantity.Text = "" Then
            ' txtFreight.Text = ""
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Please provide Quantity first')", True)

        ElseIf txtAmountPerUnit.Text = "" Then
            txtTaxPercent.Text = ""
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Please provide Amount first')", True)
        Else
            If txtTaxPercent.Text = "" Then
                txtTaxPercent.Text = "0.0"
            End If
            txtTax.Text = (txtAmount.Text * (txtTaxPercent.Text / 100))
            txt = txtTax.Text
            txtTax.Text = Math.Round(CDbl(txtTax.Text), 0).ToString("N2")   'CDbl(txtTax.Text).ToString("N2")          
            If (txtFreight.Text = "") Then
                Total = txtAmount.Text + txt
            Else
                Total = txtAmount.Text + txt + txtFreight.Text
            End If
            txtTotalAmt.Text = Total.ToString("N2")
            calculatetotal()
            txtFreight.Focus()
        End If
    End Sub
    'Protected Sub txtFreight_TextChanged(sender As Object, e As EventArgs) Handles txtFreight.TextChanged

    '    freight = txtFreight.Text
    '    Total = txtAmount.Text + txt + freight
    '    txtTotalAmt.Text = Total.ToString
    'End Sub
    Protected Sub txtFreight_TextChanged(sender As Object, e As EventArgs) Handles txtFreight.TextChanged
        'freight = txtFreight.Text
        Dim txtquantity As TextBox = DirectCast(GridView1.Rows(0).FindControl("txtquantity"), TextBox)
        If txtQuantity.Text = "" Then
            ' txtFreight.Text = ""
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Please provide Quantity first')", True)

        ElseIf txtAmountPerUnit.Text = "" Then
            txtFreight.Text = ""
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Please provide Amount first')", True)
        Else

            If txtFreight.Text = "" Then
                txtFreight.Text = "0.0"
            End If
            If txtTax.Text = "" Then
                txtTotalAmt.Text = txtAmount.Text + txtFreight.Text
                txtTotalAmt.Text = txtTotalAmt.Text("N2")
            Else
                txtTotalAmt.Text = Convert.ToDouble(txtAmount.Text) + Convert.ToDouble(txtTax.Text) + Convert.ToDouble(txtFreight.Text)
                'txtTotalAmt.Text = txtTotalAmt.Text.ToString()
                txtTotalAmt.Text = CDbl(txtTotalAmt.Text).ToString("N2")
                calculatetotal()
                txtDeliveryTerms.Focus()
            End If
        End If
        ' txtTotalAmt.Text = Total.ToString
    End Sub

    Protected Sub ddVendor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddVendor.SelectedIndexChanged
        Dim ds As DataSet = QuotationResponseBLL.vendorNameByID("vendorNameByID", ddVendor.SelectedValue)
        Dim dr As DataRow = ds.Tables(0).Rows(0)
        '   txtVendor.Text = DynamicparcelDataManipulation.FixNullFromDB(dr("Vendor_Name").ToString())
        txtPaymentTerms.Text = DynamicparcelDataManipulation.FixNullFromDB(dr("Vendor_PaymentTerms").ToString())
    End Sub
    Public Sub calculatetotal()
        If txtAmount.Text = "" Then
            txtAmount.Text = "0.0"
        End If
        If txtTax.Text = "" Then
            txtTax.Text = "0.0"
        End If
        If txtFreight.Text = "" Then
            txtFreight.Text = "0.0"
        End If
        txtTotalAmt.Text = Convert.ToDouble(txtAmount.Text) + Convert.ToDouble(txtTax.Text) + Convert.ToDouble(txtFreight.Text)
        txtTotalAmt.Text = CDbl(txtTotalAmt.Text).ToString("N2")
    End Sub
End Class
