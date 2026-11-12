
Partial Class ViewQuotationResponse
    Inherits _PageBaseClass
    Public MainId As Integer
    Public VendorID As Integer

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            MainId = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            VendorID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("VId")))
            fillViewQuotationResponse()
            FillPrinciple()
            FillRawmaterialQReq()
            FillRawmaterialQRes()

            ' fillrptQRHistory()

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewQuotationResponse", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Private Sub fillViewQuotationResponse()
        Try
            Dim dt As DataSet = MainBLL.QResponseViewByID(MainId, VendorID, "QResponseAndVendorViewbyID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            ltVendorCode.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Vendor_Code").ToString())
            ltVendorName.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Vendor_Name").ToString())
            ltStatus.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QResp_Status").ToString())
            If ltStatus.Text = "Pending" Then
                divEdit.Visible = True
            Else
                divEdit.Visible = False
            End If
            ltDate.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QDate").ToString())
            dt = MainBLL.ViewByID(MainId, "QuotationReqViewByID")
            dtUser = dt.Tables(0)
            drLogin = dtUser.Rows(0)
            ltQReqNo.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationRequest_No").ToString())
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewQuotationResponse", "fillViewQuotationResponse", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Public Sub FillPrinciple()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            grdhistory.DataSource = QuotationResponseBLL.FillQRespDetailbyID("GetQRespHistory", MainId, VendorID)
            grdhistory.DataBind()
            Dim totalcount As Integer = grdhistory.Rows.Count
            If totalcount > 0 Then
                lblprinciple.Text = "Quotation (" + totalcount.ToString + ")"
            Else
                lblprinciple.Text = "No Quotation"
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewPrinciple", "FillPrinciple", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub FillRawmaterialQReq()
        Dim dsRcptDtl As DataSet
        Try
            Dim Temptable As DataTable

            dsRcptDtl = QuotationRequestBLL.FillGridViewByID("fillmaterialByQuotation", MainId)

            Temptable = dsRcptDtl.Tables(0)
            ViewState("CurrentTable") = Temptable
            GrdQReqRaw.DataSource = dsRcptDtl
            GrdQReqRaw.DataBind()
            ' fillRcptDtl()
        Catch ex As Exception
            Dim errorMsg As String = ex.Message.Replace(Chr(34), "")
            errorMsg = errorMsg.Replace(Chr(39), "")
            ExecptionBLL.Insert("AddquotationResponse", "fillRcptDtl", errorMsg, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (errorMsg.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub FillRawmaterialQRes()
        Dim dsRcptDtl As DataSet
        Try
            Dim Temptable1 As DataTable
                dsRcptDtl = QuotationResponseBLL.FillrawRespbyID("FillrawRespbyID", MainId, VendorID)

            Temptable1 = dsRcptDtl.Tables(0)
            ViewState("CurrentTable") = Temptable1
            GrdQRRaw.DataSource = dsRcptDtl
            GrdQRRaw.DataBind()
            ' fillRcptDtl()
        Catch ex As Exception
            Dim errorMsg As String = ex.Message.Replace(Chr(34), "")
            errorMsg = errorMsg.Replace(Chr(39), "")
            ExecptionBLL.Insert("AddquotationResponse", "fillRcptDtl", errorMsg, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (errorMsg.ToString).ToString + "')", True)
        End Try
    End Sub
    'Public Sub fillrptQRHistory()
    '    Try
    '        rpgridview.DataSource = QuotationResponseBLL.FillQRespDetailbyID("GetQRespHistory", MainId, VendorID)
    '        rpgridview.DataBind()

    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub

    Protected Sub GrdQReqRaw_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GrdQReqRaw.RowDataBound
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

    Protected Sub GrdQRRaw_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GrdQRRaw.RowDataBound
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
End Class
