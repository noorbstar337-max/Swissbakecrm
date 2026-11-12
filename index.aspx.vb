Imports System.Timers

Partial Class index
    Inherits _PageBaseClass
    Dim str As New StringBuilder()

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
        Dim host As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) ' HttpContext.Current.Request.Url.Host

        If host = "http://mcrm.swissbake.ch" Then
            Response.Redirect("index1.aspx")
            'Else
            '    Response.Redirect("index.aspx")
        End If
        If host = "http://lms.swissbake.ch" Then
            Response.Redirect("lmsdashboard.aspx")
            'Else
            '    Response.Redirect("index.aspx")
        End If
        If Session("UserRoleID") = "4" Then
            Response.Redirect("SupportDashBoard.aspx")
        End If
    End Sub
    '========================================gayatri 21-07-2017=============================================
    Protected Sub GridPending_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GridPending.Sorting
        SetSortDirection(SortDireaction)
        Try
            Dim dt As DataSet = MainBLL.SortingGridView("SortQRespbyStatus", "Pending")
            Dim DataTable As DataTable = dt.Tables(0)
            If DataTable IsNot Nothing Then
                DataTable.DefaultView.Sort = Convert.ToString(e.SortExpression) & " " & _sortDirection
                GridPending.DataSource = DataTable
                GridPending.DataBind()
                SortDireaction = _sortDirection
                Dim columnIndex As Integer = 0
                For Each headerCell As DataControlFieldHeaderCell In GridPending.HeaderRow.Cells
                    If headerCell.ContainingField.SortExpression = e.SortExpression Then
                        columnIndex = GridPending.HeaderRow.Cells.GetCellIndex(headerCell)
                    End If
                Next
                GridPending.HeaderRow.Cells(columnIndex).Controls.Add(sortImage)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("QuotationResponse", "GridView1_Sorting", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    '=======================================================================================================
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Session("UserRoleID") = "3" Then
                'Response.Redirect("index2.aspx")
                divall.Visible = False
                divPurchase.Visible = True
            End If
            If Not IsPostBack Then
                If Session("UserRoleID") = "3" Then
                    FillUserName()
                    fillQuotation()
                    fillqrcount()
                Else
                    FillUserName()
                    ddluser.SelectedValue = Session("DUserId")
                    fillLead("FillTopTenActivity")
                    'FillIndexCount1()
                    FillIndexCount()
                    ' ''FillIndexCountNew()
                    FillSalesTargetCount()
                    'fillPending()
                    count()
                End If
            Else
                'Session("DUserId") = ddluser.SelectedValue
                'fillLead("FillTopTenActivity")
                'FillIndexCount()
                'FillIndexCountNew()
                'FillSalesTargetCount()
                'fillPending()
            End If
            lblusername.Text = Session("UName")
            ClientScript.RegisterStartupScript([GetType](), "Javascript", "Temp();", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Activity", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub fillqrcount()
        Dim dt As DataSet = QuotationResponseBLL.GetQRCount()
        ltpendingQ.Text = DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(0).Rows(0)("Pending").ToString())
        If ltpendingQ.Text > 0 Then
            ltpendingQ.Text = "(" + DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(0).Rows(0)("Pending").ToString()) + ")"
        Else
            ltpendingQ.Visible = False
        End If
        ltapproveQ.Text = DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(1).Rows(0)("Approved").ToString())
        ltRejectQ.Text = DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(2).Rows(0)("Rejected").ToString())
    End Sub

    Public Sub fillQuotation()
        Try
           
          
            GridPending.DataSource = QuotationResponseBLL.fillQRespbyStatus("Pending")

            GridPending.DataBind()
            If GridPending.Rows.Count > 0 Then
            Else
                divgrid.Visible = False
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("QuotationResponse", "fillQuotation", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Protected Sub GridPending_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridPending.RowCommand
        If e.CommandName = "Approvedink" Then

            ' Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ' MainId = GridView1.DataKeys(index).Value
            Try


                Dim commandArgs As String() = e.CommandArgument.ToString().Split(New Char() {","c})
                Dim a, b As String
                a = commandArgs(0)
                b = commandArgs(1)

                '    MainId = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                '   VendorID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("VId")))
                QuotationResponseBLL.UpdateQuotationStatus("UpdateStatusApprove", a, b, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('This Quotation has been approved');", True)




                'If SearchControl.UtxtSearch.Text.Trim = "" Then
                '    IndexfillQuotation()
                'Else
                '    SearchFillQuotation()
                'End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("AddquotationResponse", "btnApprove_Click", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try


        ElseIf e.CommandName = "createPO" Then
            Dim commandArgs As String() = e.CommandArgument.ToString().Split(New Char() {","c})
            Dim a, b As String
            a = commandArgs(0)
            b = commandArgs(1)
            ' Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            Dim oItem As GridViewRow = DirectCast(DirectCast(e.CommandSource, LinkButton).NamingContainer, GridViewRow)
            Dim index As Integer = oItem.RowIndex


            Dim lblAmount As Literal = DirectCast(GridPending.Rows(index).FindControl("lblAmount1"), Literal)
            Dim lblTax As Literal = DirectCast(GridPending.Rows(index).FindControl("lblTax1"), Literal)
            Dim lblFreight As Literal = DirectCast(GridPending.Rows(index).FindControl("lblFreight1"), Literal)
            Dim lblRMID As Literal = DirectCast(GridPending.Rows(index).FindControl("lblRMID"), Literal)
            Dim lblQResponse_Code As Literal = DirectCast(GridPending.Rows(index).FindControl("lblQResponse_Code"), Literal)
            Dim lblQty As Literal = DirectCast(GridPending.Rows(index).FindControl("lblQty1"), Literal)
            Dim getstring As String() = lblQty.Text.ToString().Split(New Char() {"-"c})
            Dim Qty, unit As String
            Qty = getstring(0)
            unit = getstring(1)
            Dim PurchaseOrder_ID As Integer = PurchaseOrderBLL.InsertPurchaseOrder(a, lblQResponse_Code.Text, b, lblAmount.Text, lblTax.Text, lblFreight.Text, Session("UserId"), Session("Audlog_Id"))
            'Dim ds As DataSet = MainBLL.ViewByID(0, "PurchaseOrderViewById")
            PurchaseOrderBLL.InsertPORawMaterial(lblRMID.Text, PurchaseOrder_ID, Qty, unit, Session("UserId"), Session("Audlog_Id"))
            Response.Redirect("Purchaseorder.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(a)) + "&VId=" + HttpUtility.UrlEncode(Security.Encrypt(b)))



            'If SearchControl.UtxtSearch.Text.Trim = "" Then
            '    IndexfillQuotation()
            'Else
            '    SearchFillQuotation()
            'End If
            'ElseIf e.CommandName = "ViewPo" Then
            '    Dim commandArgs As String() = e.CommandArgument.ToString().Split(New Char() {","c})
            '    Dim a, b As String
            '    a = commandArgs(0)
            '    b = commandArgs(1)
            '    'Dim a As Integer = 12
            '    'Dim b As Integer = 2

            '    'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "window.location='/Purchaseorder.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(12)) + "&VId=" + HttpUtility.UrlEncode(Security.Encrypt(3))) +"'",True)

            '    'ScriptManager.RegisterStartupScript()
            '    Response.Redirect("Purchaseorder.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(a)) + "&VId=" + HttpUtility.UrlEncode(Security.Encrypt(b)))
        End If
    End Sub

    Protected Sub GridPending_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridPending.RowDataBound
        Try

            If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = ListItemType.AlternatingItem Then
                ' For Each row As GridViewRow In GridView1.Rows
                Dim LblR As Literal = DirectCast(e.Row.FindControl("LblR"), Literal)
                Dim LblV As Literal = DirectCast(e.Row.FindControl("LblV"), Literal)
                Dim LblResponse_ID As Literal = DirectCast(e.Row.FindControl("LblResponse_ID"), Literal)

                Dim checkcname As String = PurchaseOrderBLL.CheckExistsPurchaseOrder(LblR.Text, LblResponse_ID.Text, LblV.Text)


                Dim hledit = DirectCast(e.Row.FindControl("hledit"), HyperLink)
                Dim lblStatus As Literal = CType(e.Row.FindControl("lblStatus1"), Literal)
                ' Dim lblDelete = DirectCast(e.Row.FindControl("lnkdelete"), LinkButton)
                Dim lblApproved = DirectCast(e.Row.FindControl("lnkApproved"), LinkButton)
                Dim lblPO = DirectCast(e.Row.FindControl("lnkPO"), LinkButton)
                ' Dim lnkChangeDSR As LinkButton = DirectCast(e.Row.FindControl("lnkChangeDSR"), LinkButton)
                'Dim LnkViewPO = DirectCast(e.Row.FindControl("LnkViewPO"), LinkButton)

                Dim LnkViewPO As HtmlAnchor = DirectCast(e.Row.FindControl("LnkViewPO"), HtmlAnchor)
                If lblStatus.Text = "Pending" Then
                    lblPO.Visible = False
                    LnkViewPO.Visible = False
                    lblApproved.Visible = True
                    hledit.Visible = True
                    'lblDelete.Visible = True
                ElseIf lblStatus.Text = "Approved" Then
                    lblPO.Visible = True
                    LnkViewPO.Visible = False
                    lblApproved.Visible = False
                    hledit.Visible = False
                    ' lblDelete.Visible = False

                Else
                    lblPO.Visible = False
                    lblApproved.Visible = False
                    hledit.Visible = False
                    LnkViewPO.Visible = False
                    '  lblDelete.Visible = False
                End If
                If (checkcname = "Already Exist") Then
                    lblPO.Visible = False
                    lblApproved.Visible = False
                    hledit.Visible = False
                    LnkViewPO.Visible = True
                End If

                ' Next
                   End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub FillUserName()
        Try
            Dim ds As DataSet = MainBLL.DropdownWithID("UserAssignDropDown", Session("UserId"))
            ddluser.DataSource = ds.Tables(0)
            ddluser.DataTextField = "U_FirstName"
            ddluser.DataValueField = "U_ID"
            ddluser.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyUser", "FillUserName", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub fillLead(ByVal Type As String)
        Try
            GridView1.DataSource = ActivityBLL.FillAllActivity("0", "10", Session("DUserId"), Type)
            GridView1.DataBind()
            For Each row As GridViewRow In GridView1.Rows
                GridView1.HeaderRow.Cells(4).Visible = False
                row.Cells(4).Visible = False
                GridView1.HeaderRow.Cells(3).Visible = False
                row.Cells(3).Visible = False
                GridView1.HeaderRow.Cells(12).Visible = False
                row.Cells(12).Visible = False
            Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Activity", "fillLead", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillPending()
        Try
            'Dim ds As DataSet = CountBLL.IndexCount("fillPending", Session("DUserId"))
            'Grdpendingpay.DataSource = ds.Tables(0)
            'Grdpendingpay.DataBind()
            'GrdPendigOrder.DataSource = ds.Tables(1)
            'GrdPendigOrder.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Activity", "fillPending", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillIndexCount()
        Try
            Dim ds As DataSet = CRMDashboardBLL.IndexCount("IndexCount", Session("DUserId"))
            If ds.Tables.Count > 0 Then
                lblnewlead.Text = ds.Tables(3).Rows(0)(0).ToString
                '==========Commented by MUBYN as per Requirement
                ' lbltodayevent.Text = ds.Tables(0).Rows(0)(0).ToString()
                ' lbltodaycall.Text = ds.Tables(2).Rows(0)(0).ToString()
                ' lbltodaytask.Text = ds.Tables(1).Rows(0)(0).ToString()
                ' lttodyactivity.Text = Convert.ToInt32(lbltodayevent.Text) + Convert.ToInt32(lbltodaycall.Text) + Convert.ToInt32(lbltodaytask.Text)
                lttodyactivity.Text = Convert.ToInt32(ds.Tables(0).Rows(0)(0).ToString()) + Convert.ToInt32(ds.Tables(2).Rows(0)(0).ToString()) + Convert.ToInt32(ds.Tables(1).Rows(0)(0).ToString()) + Convert.ToInt32(ds.Tables(12).Rows(0)(0).ToString())
                ltTodayReminderCount.Text = ds.Tables(12).Rows(0)(0).ToString()
                ltprosnoactivity.Text = ds.Tables(4).Rows(0)(0).ToString
                ltaccnosales.Text = ds.Tables(5).Rows(0)(0).ToString
                ltallmissed.Text = ds.Tables(9).Rows(0)(0).ToString()
                Dim TotalRatings As Integer = ds.Tables(13).Rows(0)(0).ToString()
                Dim RatingCount As Integer = ds.Tables(13).Rows(0)(1).ToString()
                lblTodayRatin.Text = CDbl(TotalRatings / (IIf(RatingCount = 0, 1, RatingCount))).ToString("0.0")
                ' ltmissedtask.Text = ds.Tables(8).Rows(0)(0).ToString()
                ' ltmissedevent.Text = ds.Tables(7).Rows(0)(0).ToString
                '  ltmissescall.Text = ds.Tables(6).Rows(0)(0).ToString
                ltlastmonthsales.Text = Convert.ToDouble(ds.Tables(10).Rows(0)(0).ToString).ToString("#,##0.00")
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Index.aspx", "FillIndexCount", error1, Session("UserId"))
            Throw ex
        End Try
    End Sub

    Public Sub FillIndexCount1()
        Try
            Dim ds As DataSet = CRMDashboardBLL.IndexCount("IndexCount1", Session("DUserId"))
            If ds.Tables.Count > 0 Then
                lblnewlead.Text = ds.Tables(3).Rows(0)(0).ToString
                '==========Commented by MUBYN as per Requirement
                ' lbltodayevent.Text = ds.Tables(0).Rows(0)(0).ToString()
                ' lbltodaycall.Text = ds.Tables(2).Rows(0)(0).ToString()
                ' lbltodaytask.Text = ds.Tables(1).Rows(0)(0).ToString()
                ' lttodyactivity.Text = Convert.ToInt32(lbltodayevent.Text) + Convert.ToInt32(lbltodaycall.Text) + Convert.ToInt32(lbltodaytask.Text)
                lttodyactivity.Text = Convert.ToInt32(ds.Tables(0).Rows(0)(0).ToString()) + Convert.ToInt32(ds.Tables(2).Rows(0)(0).ToString()) + Convert.ToInt32(ds.Tables(1).Rows(0)(0).ToString()) + Convert.ToInt32(ds.Tables(12).Rows(0)(0).ToString())
                ltTodayReminderCount.Text = ds.Tables(12).Rows(0)(0).ToString()
                ltprosnoactivity.Text = ds.Tables(4).Rows(0)(0).ToString
                ltaccnosales.Text = ds.Tables(5).Rows(0)(0).ToString
                ltallmissed.Text = ds.Tables(9).Rows(0)(0).ToString()
                Dim TotalRatings As Integer = ds.Tables(13).Rows(0)(0).ToString()
                Dim RatingCount As Integer = ds.Tables(13).Rows(0)(1).ToString()
                lblTodayRatin.Text = CDbl(TotalRatings / (IIf(RatingCount = 0, 1, RatingCount))).ToString("0.0")
                ' ltmissedtask.Text = ds.Tables(8).Rows(0)(0).ToString()
                ' ltmissedevent.Text = ds.Tables(7).Rows(0)(0).ToString
                '  ltmissescall.Text = ds.Tables(6).Rows(0)(0).ToString
                ltlastmonthsales.Text = Convert.ToDouble(ds.Tables(10).Rows(0)(0).ToString).ToString("#,##0.00")

                If ds.Tables(16).Rows.Count > 0 Then
                    ltleadachived.Text = ds.Tables(16).Rows(0)(0).ToString()
                End If
                If ds.Tables(17).Rows.Count > 0 Then
                    ltleadtarget.Text = ds.Tables(17).Rows(0)(0).ToString()
                    If String.IsNullOrEmpty(ltleadtarget.Text) Then
                        ltleadtarget.Text = "0"
                    End If
                    If String.IsNullOrEmpty(ltleadachived.Text) Then
                        ltleadachived.Text = "0"
                    End If
                    ltleadpercentage.Text = "0"
                    If Not String.IsNullOrEmpty(ltleadachived.Text) And Not String.IsNullOrEmpty(ltleadtarget.Text) Then
                        If Not ltleadachived.Text = "0" And Not ltleadtarget.Text = "0" Then
                            ltleadpercentage.Text = Math.Round((Convert.ToDouble(ltleadachived.Text) / Convert.ToDouble(ltleadtarget.Text)) * 100)
                        End If
                    End If
                    divleadchart.Attributes("data-percent") = ltleadpercentage.Text
                    ltleadpercentage.Text = ltleadpercentage.Text + "%"
                End If
                If ds.Tables(18).Rows.Count > 0 Then
                    ltprospectachived.Text = ds.Tables(18).Rows(0)(0).ToString()
                    If ds.Tables(19).Rows.Count > 0 Then
                        ltprospecttarget.Text = ds.Tables(19).Rows(0)(0).ToString()
                        If String.IsNullOrEmpty(ltprospectachived.Text) Then
                            ltprospectachived.Text = "0"
                        End If
                        If String.IsNullOrEmpty(ltprospecttarget.Text) Then
                            ltprospecttarget.Text = "0"
                        End If
                        ltprospectpercentage.Text = "0"
                        If Not String.IsNullOrEmpty(ltprospectachived.Text) And Not String.IsNullOrEmpty(ltprospecttarget.Text) Then
                            If Not ltprospectachived.Text = "0" And Not ltprospecttarget.Text = "0" Then
                                ltprospectpercentage.Text = Math.Round((Convert.ToDouble(ltprospectachived.Text) / Convert.ToDouble(ltprospecttarget.Text)) * 100)
                            End If
                        End If
                        divprospectchart.Attributes("data-percent") = ltprospectpercentage.Text
                        ltprospectpercentage.Text = ltprospectpercentage.Text + "%"
                    End If
                End If
                If ds.Tables(14).Rows.Count > 0 Then
                    ltaccountachived.Text = ds.Tables(14).Rows(0)(0).ToString()
                    If ds.Tables(15).Rows.Count > 0 Then
                        ltaccounttarget.Text = ds.Tables(15).Rows(0)(0).ToString()
                        If String.IsNullOrEmpty(ltaccountachived.Text) Then
                            ltaccountachived.Text = "0"
                        End If
                        If String.IsNullOrEmpty(ltaccounttarget.Text) Then
                            ltaccounttarget.Text = "0"
                        End If
                        ltaccountpercentage.Text = "0"
                        If Not String.IsNullOrEmpty(ltaccountachived.Text) And Not String.IsNullOrEmpty(ltaccounttarget.Text) Then
                            If Not ltaccountachived.Text = "0" And Not ltaccounttarget.Text = "0" Then
                                ltaccountpercentage.Text = Math.Round((Convert.ToDouble(ltaccountachived.Text) / Convert.ToDouble(ltaccounttarget.Text)) * 100)
                            End If
                        End If
                        divaccountchart.Attributes("data-percent") = ltaccountpercentage.Text
                        ltaccountpercentage.Text = ltaccountpercentage.Text + "%"
                    End If
                End If
                If ds.Tables(20).Rows.Count > 0 And Not String.IsNullOrEmpty(ds.Tables(20).Rows(0)(0).ToString()) Then
                    ltsalesachived.Text = ds.Tables(20).Rows(0)(0).ToString()
                    If String.IsNullOrEmpty(ltsalesachived.Text) Then
                        ltsalesachived.Text = "0"
                    End If
                    ltsalesachived.Text = Math.Round(Convert.ToDouble(ltsalesachived.Text))
                End If
                If ds.Tables(21).Rows.Count > 0 Then
                    ltsalestarget.Text = ds.Tables(21).Rows(0)(0).ToString()
                    If String.IsNullOrEmpty(ltsalestarget.Text) Then
                        ltsalestarget.Text = "0"
                    End If
                    ltsalespercentage.Text = "0"
                    ltsalestarget.Text = Math.Round(Convert.ToDouble(ltsalestarget.Text))
                    If Not String.IsNullOrEmpty(ltsalesachived.Text) And Not String.IsNullOrEmpty(ltsalestarget.Text) Then
                        If Not ltsalesachived.Text = "0" And Not ltsalestarget.Text = "0" Then
                            ltsalespercentage.Text = Math.Round((Convert.ToDouble(IIf(IsDBNull(ds.Tables(20).Rows(0)(0)), 0, ds.Tables(20).Rows(0)(0))) / Convert.ToDouble(IIf(IsDBNull(ds.Tables(21).Rows(0)(0)), 0, ds.Tables(21).Rows(0)(0)))) * 100)
                        End If
                    End If
                    divsaleschart.Attributes("data-percent") = ltsalespercentage.Text
                    ltsalespercentage.Text = ltsalespercentage.Text + "%"
                End If
                    If Not ltsalesachived.Text = "0" Then
                        ltsalesachived.Text = Convert.ToDouble(ltsalesachived.Text).ToString("#,##")
                    End If
                    If Not ltsalestarget.Text = "0" Then
                        ltsalestarget.Text = Convert.ToDouble(ltsalestarget.Text).ToString("#,##")
                    End If
                If ds.Tables(22).Rows.Count > 0 And Not String.IsNullOrEmpty(ds.Tables(22).Rows(0)(0).ToString()) Then
                    ltMySales.Text = ds.Tables(22).Rows(0)(0).ToString()
                    If String.IsNullOrEmpty(ltMySales.Text) Then
                        ltMySales.Text = "0"
                    End If
                    ltMySales.Text = Math.Round(Convert.ToDouble(ltMySales.Text))
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Index.aspx", "FillIndexCount", error1, Session("UserId"))
            Throw ex
        End Try
    End Sub
    Public Sub FillIndexCountNew()
        Try
            Dim ds As DataSet = CRMDashboardBLL.IndexCount("IndexCountNew", Session("DUserId"))
            If ds.Tables.Count > 0 Then
                'lblnewlead.Text = ds.Tables(3).Rows(0)(0).ToString
                ' lbltodayevent.Text = ds.Tables(0).Rows(0)(0).ToString()
                ' lbltodaycall.Text = ds.Tables(2).Rows(0)(0).ToString()
                ' lbltodaytask.Text = ds.Tables(1).Rows(0)(0).ToString()
                'ltprosnoactivity.Text = ds.Tables(4).Rows(0)(0).ToString
                'ltaccnosales.Text = ds.Tables(5).Rows(0)(0).ToString
                ' ltallmissed.Text = ds.Tables(9).Rows(0)(0).ToString()
                ' ltmissedtask.Text = ds.Tables(8).Rows(0)(0).ToString()
                ' ltmissedevent.Text = ds.Tables(7).Rows(0)(0).ToString
                '  ltmissescall.Text = ds.Tables(6).Rows(0)(0).ToString
                ltlastmonthsales.Text = Convert.ToDouble(ds.Tables(10).Rows(0)(0).ToString).ToString("#,##0.00")
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Index.aspx", "FillIndexCountNew", error1, Session("UserId"))
            Throw ex
        End Try
    End Sub

    Public Sub FillSalesTargetCount()
        Try
            Dim ds As DataSet = CRMDashboardBLL.IndexCount("CountTeamSalesTarget", Session("DUserId"))
            If ds.Tables.Count > 0 Then
                If ds.Tables(2).Rows.Count > 0 Then
                    ltleadachived.Text = ds.Tables(2).Rows(0)(0).ToString()
                End If
                If ds.Tables(3).Rows.Count > 0 Then
                    ltleadtarget.Text = ds.Tables(3).Rows(0)(0).ToString()
                    If String.IsNullOrEmpty(ltleadtarget.Text) Then
                        ltleadtarget.Text = "0"
                    End If
                    If String.IsNullOrEmpty(ltleadachived.Text) Then
                        ltleadachived.Text = "0"
                    End If
                    ltleadpercentage.Text = "0"
                    If Not String.IsNullOrEmpty(ltleadachived.Text) And Not String.IsNullOrEmpty(ltleadtarget.Text) Then
                        If Not ltleadachived.Text = "0" And Not ltleadtarget.Text = "0" Then
                            ltleadpercentage.Text = Math.Round((Convert.ToDouble(ltleadachived.Text) / Convert.ToDouble(ltleadtarget.Text)) * 100)
                        End If
                    End If
                    divleadchart.Attributes("data-percent") = ltleadpercentage.Text
                    ltleadpercentage.Text = ltleadpercentage.Text + "%"
                End If
                If ds.Tables(4).Rows.Count > 0 Then
                    ltprospectachived.Text = ds.Tables(4).Rows(0)(0).ToString()
                    If ds.Tables(5).Rows.Count > 0 Then
                        ltprospecttarget.Text = ds.Tables(5).Rows(0)(0).ToString()
                        If String.IsNullOrEmpty(ltprospectachived.Text) Then
                            ltprospectachived.Text = "0"
                        End If
                        If String.IsNullOrEmpty(ltprospecttarget.Text) Then
                            ltprospecttarget.Text = "0"
                        End If
                        ltprospectpercentage.Text = "0"
                        If Not String.IsNullOrEmpty(ltprospectachived.Text) And Not String.IsNullOrEmpty(ltprospecttarget.Text) Then
                            If Not ltprospectachived.Text = "0" And Not ltprospecttarget.Text = "0" Then
                                ltprospectpercentage.Text = Math.Round((Convert.ToDouble(ltprospectachived.Text) / Convert.ToDouble(ltprospecttarget.Text)) * 100)
                            End If
                        End If
                        divprospectchart.Attributes("data-percent") = ltprospectpercentage.Text
                        ltprospectpercentage.Text = ltprospectpercentage.Text + "%"
                    End If
                End If
                If ds.Tables(0).Rows.Count > 0 Then
                    ltaccountachived.Text = ds.Tables(0).Rows(0)(0).ToString()
                    If ds.Tables(1).Rows.Count > 0 Then
                        ltaccounttarget.Text = ds.Tables(1).Rows(0)(0).ToString()
                        If String.IsNullOrEmpty(ltaccountachived.Text) Then
                            ltaccountachived.Text = "0"
                        End If
                        If String.IsNullOrEmpty(ltaccounttarget.Text) Then
                            ltaccounttarget.Text = "0"
                        End If
                        ltaccountpercentage.Text = "0"
                        If Not String.IsNullOrEmpty(ltaccountachived.Text) And Not String.IsNullOrEmpty(ltaccounttarget.Text) Then
                            If Not ltaccountachived.Text = "0" And Not ltaccounttarget.Text = "0" Then
                                ltaccountpercentage.Text = Math.Round((Convert.ToDouble(ltaccountachived.Text) / Convert.ToDouble(ltaccounttarget.Text)) * 100)
                            End If
                        End If
                        divaccountchart.Attributes("data-percent") = ltaccountpercentage.Text
                        ltaccountpercentage.Text = ltaccountpercentage.Text + "%"
                    End If
                End If
                If ds.Tables(6).Rows.Count > 0 And Not String.IsNullOrEmpty(ds.Tables(6).Rows(0)(0).ToString()) Then
                    ltsalesachived.Text = ds.Tables(6).Rows(0)(0).ToString()
                    If String.IsNullOrEmpty(ltsalesachived.Text) Then
                        ltsalesachived.Text = "0"
                    End If
                    ltsalesachived.Text = Math.Round(Convert.ToDouble(ltsalesachived.Text))
                End If
                If ds.Tables(7).Rows.Count > 0 Then
                    ltsalestarget.Text = ds.Tables(7).Rows(0)(0).ToString()
                    If String.IsNullOrEmpty(ltsalestarget.Text) Then
                        ltsalestarget.Text = "0"
                    End If
                    ltsalespercentage.Text = "0"
                    ltsalestarget.Text = Math.Round(Convert.ToDouble(ltsalestarget.Text))
                    If Not String.IsNullOrEmpty(ltsalesachived.Text) And Not String.IsNullOrEmpty(ltsalestarget.Text) Then
                        If Not ltsalesachived.Text = "0" And Not ltsalestarget.Text = "0" Then
                            ltsalespercentage.Text = Math.Round((Convert.ToDouble(IIf(IsDBNull(ds.Tables(6).Rows(0)(0)), 0, ds.Tables(6).Rows(0)(0))) / Convert.ToDouble(IIf(IsDBNull(ds.Tables(7).Rows(0)(0)), 0, ds.Tables(7).Rows(0)(0)))) * 100)
                        End If
                    End If
                    divsaleschart.Attributes("data-percent") = ltsalespercentage.Text
                    ltsalespercentage.Text = ltsalespercentage.Text + "%"
                End If
                If Not ltsalesachived.Text = "0" Then
                    ltsalesachived.Text = Convert.ToDouble(ltsalesachived.Text).ToString("#,##")
                End If
                If Not ltsalestarget.Text = "0" Then
                    ltsalestarget.Text = Convert.ToDouble(ltsalestarget.Text).ToString("#,##")
                End If
                If ds.Tables(8).Rows.Count > 0 And Not String.IsNullOrEmpty(ds.Tables(8).Rows(0)(0).ToString()) Then
                    ltMySales.Text = ds.Tables(8).Rows(0)(0).ToString()
                    If String.IsNullOrEmpty(ltMySales.Text) Then
                        ltMySales.Text = "0"
                    End If
                    ltMySales.Text = Math.Round(Convert.ToDouble(ltMySales.Text))
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Index.aspx", "FillIndexCount", error1, Session("UserId"))
            Throw ex
        End Try
    End Sub

    Private Function GetData() As DataTable
        Dim dt As New DataTable()
        'dt.Columns.AddRange(New DataColumn() {New DataColumn("monthname", GetType(String))})
        dt.Columns.AddRange(New DataColumn() {New DataColumn("item", GetType(String)), _
                                          New DataColumn("value", GetType(String))})
        dt.Rows.Add("Lead", ltleadachived.Text)
        dt.Rows.Add("Account", ltaccountachived.Text)
        dt.Rows.Add("Prospect", ltprospectachived.Text)

        Return dt
    End Function

    Private Sub BindChart()
        Dim dt As New DataTable()
        Try
            dt = GetData()

            str.Append("<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*gauge*]});" & vbCr & vbLf & "google.setOnLoadCallback(drawChart);" & vbCr & vbLf & "function drawChart() {" & vbCr & vbLf & "var data = new google.visualization.DataTable();" & vbCr & vbLf & "data.addColumn('string', 'item');" & vbCr & vbLf & "data.addColumn('number', 'value');" & vbCr & vbLf & " " & vbCr & vbLf & "data.addRows(" & dt.Rows.Count & ");")
            For i As Integer = 0 To dt.Rows.Count - 1
                str.Append("data.setValue( " & i & "," & 0 & "," + "'" & dt.Rows(i)("item").ToString() & "');")
                str.Append("data.setValue(" & i & "," & 1 & "," & dt.Rows(i)("value").ToString() & ") ;")
            Next
            str.Append("var options = {width: 600, height: 300,redFrom: 90, redTo: 100,yellowFrom:75, yellowTo: 90,minorTicks: 5, min: 0,max: 100};")
            str.Append(" var chart = new google.visualization.Gauge(document.getElementById('chart_div'));")
            str.Append(" chart.draw(data, options); }")
            str.Append("</script>")
            lt.Text = str.ToString().TrimEnd(","c).Replace("*"c, """"c)
        Catch
        End Try
    End Sub


    Public Sub count()
        Dim ds1 As DataSet
        Dim dt1 As DataTable
        ds1 = CRMDashboardBLL.IndexCount("fillPendingcount", Session("DUserId"))
        If ds1.Tables(0).Rows.Count > 0 Then
            dt1 = ds1.Tables(0)
            Dim penpayment As String = dt1.Rows(0)("Balance").ToString
            lblpendingpay.Text = Convert.ToDouble(penpayment).ToString("#,##0.00")
        End If


        If ds1.Tables(1).Rows.Count > 0 Then
            dt1 = ds1.Tables(1)
            Dim penpayment As String = dt1.Rows(0)("Amount").ToString
            lblpendingorders.Text = Convert.ToDouble(penpayment).ToString("#,##0.00")
        End If

    End Sub


    'Protected Sub Grdpendingpay_DataBound(sender As Object, e As EventArgs) Handles Grdpendingpay.DataBound
    '    Try
    '        Dim totalpendingpay As Double = 0
    '        For i As Integer = 0 To Grdpendingpay.Rows.Count - 1
    '            totalpendingpay = totalpendingpay + Convert.ToDouble(DirectCast(Grdpendingpay.Rows(i).FindControl("lblpenpay"), Literal).Text)
    '            Dim lblpenpay As Literal = DirectCast(Grdpendingpay.Rows(i).FindControl("lblpenpay"), Literal)
    '            lblpenpay.Text = Convert.ToDouble(lblpenpay.Text).ToString("#,##0.00")
    '        Next
    '        lblpendingpay.Text = totalpendingpay.ToString("#,##0.00")
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Protected Sub GrdPendigOrder_DataBound(sender As Object, e As EventArgs) Handles GrdPendigOrder.DataBound
    '    Try
    '        Dim totalpendingorder As Double = 0
    '        For i As Integer = 0 To GrdPendigOrder.Rows.Count - 1
    '            totalpendingorder = totalpendingorder + Convert.ToDouble(DirectCast(GrdPendigOrder.Rows(i).FindControl("lblOrdAmount"), Literal).Text)
    '            Dim lblOrdAmount As Literal = DirectCast(GrdPendigOrder.Rows(i).FindControl("lblOrdAmount"), Literal)
    '            lblOrdAmount.Text = Convert.ToDouble(lblOrdAmount.Text).ToString("#,##0.00")
    '        Next
    '        lblpendingorders.Text = totalpendingorder.ToString("#,##0.00")
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Closing" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = GridView1.Rows(index)
            Try
                Activityclose.Uhactivity.Value = GridView1.DataKeys(index).Value()
                Dim ltrelatedtype As Literal = DirectCast(row.FindControl("ltrelatedtype"), Literal)
                Dim ltrelatedtypeid As Literal = DirectCast(row.FindControl("ltrelatedtypeid"), Literal)
                Activityclose.Umpclose.Show()
                Activityclose.Uhftype.Value = ltrelatedtype.Text
                Activityclose.Uhftypeid.Value = ltrelatedtypeid.Text
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("Closing", "GridView1_RowCommand", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
            '========================== added By MUBYN 
        ElseIf e.CommandName = "ChangeToDSR" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = GridView1.Rows(index)
            Try
                If deletestatus.Value = "yes" Then
                    Dim ltrelatedtype As Literal = DirectCast(row.FindControl("ltrelatedtype"), Literal)
                    Dim ltrelatedtypeid As Literal = DirectCast(row.FindControl("ltrelatedtypeid"), Literal)
                    Dim Activity_Id As Integer
                    Activity_Id = GridView1.DataKeys(index).Value
                    ActivityBLL.ChangeToDSR(Activity_Id, Session("UserId"))
                    fillLead("FillTopTenActivity")
                    'For Each row As GridViewRow In GridView1.Rows
                    '    GridView1.HeaderRow.Cells(4).Visible = False
                    '    row.Cells(4).Visible = False
                    '    GridView1.HeaderRow.Cells(3).Visible = False
                    '    row.Cells(3).Visible = False
                    'Next
                    UpdatePanel2.Update()
                Else

                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ChangeToDSR", "GridView1_RowCommand", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
            '============= Modification by Mubyn ends here
        ElseIf e.CommandName = "Viewing" Then
            Dim ID As Integer = 0
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = GridView1.Rows(index)
            Dim ltrelatedtype As Literal = DirectCast(row.FindControl("ltrelatedtype"), Literal)
            Dim ltrelatedtypeid As Literal = DirectCast(row.FindControl("ltrelatedtypeid"), Literal)
            ID = GridView1.DataKeys(index).Value
            lvnote.DataSource = NoteBLL.NoteActivWithAssReverse(Session("UserId"), ID)
            lvnote.DataBind()
            grdactivityhistory.DataSource = MainBLL.ViewByID(ID, "ActivityHistory")
            grdactivityhistory.DataBind()
            hfmainactivityid.Value = ID
            hfreltypeId.Value = ltrelatedtypeid.Text
            hfreltype.Value = ltrelatedtype.Text
            Dim dt As DataSet
            If hfreltype.Value = "Account" Or hfreltype.Value = "Prospect" Then
                dt = NoteBLL.RecentActivity(ID, hfreltype.Value, hfreltypeId.Value)
                trcontact.Visible = True
                Dim dtUser As New DataTable
                dtUser = dt.Tables(0)
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                lblname.Text = hfreltype.Value + " Name"
                lblsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                ltstartdate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                ltenddate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                lblaccname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
                ltpriority.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                ltowner.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                If ltpriority.Text = "High" Then
                    ltpriority.CssClass = "label label-success"
                ElseIf ltpriority.Text = "Highest" Then
                    ltpriority.CssClass = "label label-success"
                ElseIf ltpriority.Text = "Lowest" Then
                    ltpriority.CssClass = "label label-danger"
                ElseIf ltpriority.Text = "Low" Then
                    ltpriority.CssClass = "label label-warning"
                ElseIf ltpriority.Text = "Normal" Then
                    ltpriority.CssClass = "label label-info"
                End If
                ltstatus.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                If ltstatus.Text = "Close" Then
                    ltstatus.CssClass = "label label-success"
                ElseIf ltstatus.Text = "Close Postpone" Then
                    ltstatus.CssClass = "label label-info"
                ElseIf ltstatus.Text = "Pending" Or ltstatus.Text = "Due" Then
                    ltstatus.CssClass = "label label-warning"
                ElseIf ltstatus.Text = "Today" Then
                    ltstatus.CssClass = "label label-success"
                ElseIf (ltstatus.Text = "Missed") Then
                    ltstatus.CssClass = "label label-danger"
                ElseIf (ltstatus.Text = "Tommorrow") Then
                    ltstatus.CssClass = "label label-info"
                End If
                ltdesc.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                ltresult.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                ltcontact.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("ContactName").ToString())
                'lblconatctd.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString())
                hffollowactivityid.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Id").ToString())
            ElseIf hfreltype.Value = "Quotation" Then
                dt = NoteBLL.ViewNoteQuotation(ID, hfreltypeId.Value)
                Dim dtUser As New DataTable
                dtUser = dt.Tables(0)
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                lblname.Text = "Quotation Name"
                trcontact.Visible = False
                lblsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                ltstartdate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                ltenddate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                ltpriority.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                ltowner.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                If ltpriority.Text = "High" Then
                    ltpriority.CssClass = "label label-success"
                ElseIf ltpriority.Text = "Highest" Then
                    ltpriority.CssClass = "label label-success"
                ElseIf ltpriority.Text = "Lowest" Then
                    ltpriority.CssClass = "label label-danger"
                ElseIf ltpriority.Text = "Low" Then
                    ltpriority.CssClass = "label label-warning"
                ElseIf ltpriority.Text = "Normal" Then
                    ltpriority.CssClass = "label label-info"
                End If
                ltstatus.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                If ltstatus.Text = "Close" Then
                    ltstatus.CssClass = "label label-success"
                ElseIf ltstatus.Text = "Close Postpone" Then
                    ltstatus.CssClass = "label label-info"
                ElseIf ltstatus.Text = "Pending" Or ltstatus.Text = "Due" Then
                    ltstatus.CssClass = "label label-warning"
                ElseIf ltstatus.Text = "Today" Then
                    ltstatus.CssClass = "label label-success"
                ElseIf (ltstatus.Text = "Missed") Then
                    ltstatus.CssClass = "label label-danger"
                ElseIf (ltstatus.Text = "Tommorrow") Then
                    ltstatus.CssClass = "label label-info"
                End If
                ltdesc.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                ltresult.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                lblaccname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_No").ToString()) + "-" + DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
                'lblconatctd.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString())
                hffollowactivityid.Value = ID
            ElseIf hfreltype.Value = "Opportunity" Then
                dt = NoteBLL.ViewOpportunityByID(ID, hfreltypeId.Value)
                Dim dtUser As New DataTable
                dtUser = dt.Tables(0)
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                lblname.Text = "Opportunity Name"
                lblaccname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity_Name").ToString()) + "-" + DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
                trcontact.Visible = True
                lblsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                ltstartdate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                ltenddate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                ltpriority.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                ltowner.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                ltcontact.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("ContactName").ToString())
                If ltpriority.Text = "High" Then
                    ltpriority.CssClass = "label label-success"
                ElseIf ltpriority.Text = "Highest" Then
                    ltpriority.CssClass = "label label-success"
                ElseIf ltpriority.Text = "Lowest" Then
                    ltpriority.CssClass = "label label-danger"
                ElseIf ltpriority.Text = "Low" Then
                    ltpriority.CssClass = "label label-warning"
                ElseIf ltpriority.Text = "Normal" Then
                    ltpriority.CssClass = "label label-info"
                End If
                ltstatus.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                If ltstatus.Text = "Close" Then
                    ltstatus.CssClass = "label label-success"
                ElseIf ltstatus.Text = "Close Postpone" Then
                    ltstatus.CssClass = "label label-info"
                ElseIf ltstatus.Text = "Pending" Then
                    ltstatus.CssClass = "label label-warning"
                ElseIf ltstatus.Text = "Today" Then
                    ltstatus.CssClass = "label label-success"
                ElseIf (ltstatus.Text = "Missed") Then
                    ltstatus.CssClass = "label label-danger"
                ElseIf (ltstatus.Text = "Tommorrow") Then
                    ltstatus.CssClass = "label label-info"
                End If
                ltdesc.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                ltresult.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                hffollowactivityid.Value = ID
            ElseIf hfreltype.Value = "Lead" Then
                dt = NoteBLL.ViewLeadViewByID(ID, hfreltypeId.Value)
                Dim dtUser As New DataTable
                dtUser = dt.Tables(0)
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                lblname.Text = "Lead Name"
                lblaccname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead_Name").ToString())
                trcontact.Visible = True
                lblsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                ltstartdate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                ltenddate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                ltpriority.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                ltowner.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                ltcontact.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("ContactName").ToString())
                If ltpriority.Text = "High" Then
                    ltpriority.CssClass = "label label-success"
                ElseIf ltpriority.Text = "Highest" Then
                    ltpriority.CssClass = "label label-success"
                ElseIf ltpriority.Text = "Lowest" Then
                    ltpriority.CssClass = "label label-danger"
                ElseIf ltpriority.Text = "Low" Then
                    ltpriority.CssClass = "label label-warning"
                ElseIf ltpriority.Text = "Normal" Then
                    ltpriority.CssClass = "label label-info"
                End If
                ltstatus.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                If ltstatus.Text = "Close" Then
                    ltstatus.CssClass = "label label-success"
                ElseIf ltstatus.Text = "Close Postpone" Then
                    ltstatus.CssClass = "label label-info"
                ElseIf ltstatus.Text = "Pending" Then
                    ltstatus.CssClass = "label label-warning"
                ElseIf ltstatus.Text = "Today" Then
                    ltstatus.CssClass = "label label-success"
                ElseIf (ltstatus.Text = "Missed") Then
                    ltstatus.CssClass = "label label-danger"
                ElseIf (ltstatus.Text = "Tommorrow") Then
                    ltstatus.CssClass = "label label-info"
                End If
                ltdesc.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                ltresult.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                hffollowactivityid.Value = ID
            ElseIf hfreltype.Value = "None" Then
                dt = MainBLL.ViewByID(ID, "ActivityViewByID")
                Dim dtUser As New DataTable
                dtUser = dt.Tables(0)
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                lblname.Text = "Account Name"
                lblaccname.Text = "None"
                trcontact.Visible = False
                lblsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                ltstartdate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                ltenddate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                ltpriority.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                If ltpriority.Text = "High" Then
                    ltpriority.CssClass = "label label-success"
                ElseIf ltpriority.Text = "Highest" Then
                    ltpriority.CssClass = "label label-success"
                ElseIf ltpriority.Text = "Lowest" Then
                    ltpriority.CssClass = "label label-danger"
                ElseIf ltpriority.Text = "Low" Then
                    ltpriority.CssClass = "label label-warning"
                ElseIf ltpriority.Text = "Normal" Then
                    ltpriority.CssClass = "label label-info"
                End If
                ltstatus.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                If ltstatus.Text = "Close" Then
                    ltstatus.CssClass = "label label-success"
                ElseIf ltstatus.Text = "Close Postpone" Then
                    ltstatus.CssClass = "label label-info"
                ElseIf ltstatus.Text = "Pending" Or ltstatus.Text = "Due" Then
                    ltstatus.CssClass = "label label-warning"
                ElseIf ltstatus.Text = "Today" Then
                    ltstatus.CssClass = "label label-success"
                ElseIf (ltstatus.Text = "Missed") Then
                    ltstatus.CssClass = "label label-danger"
                ElseIf (ltstatus.Text = "Tommorrow") Then
                    ltstatus.CssClass = "label label-info"
                End If
                ltdesc.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                ltresult.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                ltowner.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                hffollowactivityid.Value = ID
            End If
            mpefollowup.Show()
        End If
    End Sub

    Protected Sub btncloseyes_Click(sender As Object, e As EventArgs) Handles Activityclose.LKCloseyesClick
        Try
            fillLead("FillTopTenActivity")
            For Each row As GridViewRow In GridView1.Rows
                GridView1.HeaderRow.Cells(4).Visible = False
                row.Cells(4).Visible = False
                GridView1.HeaderRow.Cells(3).Visible = False
                row.Cells(3).Visible = False
            Next
            UpdatePanel2.Update()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("NoteControl", "SaveProduct", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnpostponesave_Click(sender As Object, e As EventArgs) Handles Activityclose.LKpostponesaveClick
        Try
            fillLead("FillTopTenActivity")
            For Each row As GridViewRow In GridView1.Rows
                GridView1.HeaderRow.Cells(4).Visible = False
                row.Cells(4).Visible = False
                GridView1.HeaderRow.Cells(3).Visible = False
                row.Cells(3).Visible = False
            Next
            UpdatePanel2.Update()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("NoteControl", "SaveProduct", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnfollowsave_Click(sender As Object, e As EventArgs) Handles Activityclose.LKfollowsaveClick
        Try
            fillLead("FillTopTenActivity")
            For Each row As GridViewRow In GridView1.Rows
                GridView1.HeaderRow.Cells(4).Visible = False
                row.Cells(4).Visible = False
                GridView1.HeaderRow.Cells(3).Visible = False
                row.Cells(3).Visible = False
            Next
            UpdatePanel2.Update()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("NoteControl", "SaveProduct", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnaddnote_Click(sender As Object, e As EventArgs) Handles btnaddnote.Click
        Try
            NoteBLL.Insert(txtname.Text.Trim, "Activity", hfmainactivityid.Value, Session("Audlog_Id"), Session("UserId"))
            lvnote.DataSource = NoteBLL.NoteActivWithAssReverse(Session("UserId"), hfmainactivityid.Value)
            lvnote.DataBind()
            txtname.Text = ""
            mpefollowup.Show()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Activity", "btnaddnote_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    ' commented by MUBYN
    'Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
    '    Try
    '        If e.Row.RowType = DataControlRowType.DataRow Then
    '            If e.Row.RowType = DataControlRowType.DataRow Then
    '                For Each cell As TableCell In e.Row.Cells
    '                    Dim littext As String = cell.Text
    '                    Dim Literals As Label = New Label()
    '                    If (cell.Text = "Low") Then
    '                        Literals.CssClass = "label label-warning"
    '                    ElseIf (cell.Text = "Lowest") Then
    '                        Literals.CssClass = "label label-warning"
    '                    ElseIf (cell.Text = "High") Then
    '                        Literals.CssClass = "label label-danger"
    '                    ElseIf (cell.Text = "Highest") Then
    '                        Literals.CssClass = "label label-danger"
    '                    ElseIf (cell.Text = "Normal") Then
    '                        Literals.CssClass = "label label-info"
    '                    End If
    '                    If (cell.Text = "Event") Then
    '                        littext = "Sampling/Demo"
    '                    ElseIf (cell.Text = "Call") Then
    '                        littext = "Phone/Email"
    '                    End If
    '                    Literals.Text = littext
    '                    cell.Controls.Add(Literals)

    '                Next
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert("Index.aspx", "GridView1_RowDataBound", error1, Session("UserId"))
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim row As GridViewRow = e.Row
                Dim data As DataRow = DirectCast(row.DataItem, DataRowView).Row
                Dim HyperLink1 As HyperLink = DirectCast(e.Row.FindControl("HyperLink1"), HyperLink)
                Dim lnk As LinkButton = DirectCast(e.Row.FindControl("lnk"), LinkButton)
                Dim lnkChangeDSR As LinkButton = DirectCast(e.Row.FindControl("lnkChangeDSR"), LinkButton)
                Dim ActivityID As Long = data.Field(Of Long)("Id")
                'lnk.Attributes.Add("onClick", "ShowMyModalPopup()")
                'lnk.Attributes.Add("onClick", "ShowMyModalPopup('" & data.Field(Of String)("Status") & "')")

                'Dim Type As String = data.Field(Of String)("Status")
                'GridView.Columns("").Visible = False
                Select Case data.Field(Of String)("Activity Type")
                    Case "Task"
                        HyperLink1.NavigateUrl = Page.ResolveUrl("~/ActivityTask.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID)))
                        Dim activitistatus As String = data.Field(Of String)("Status")
                        If activitistatus = "Close" Then
                            lnk.Visible = False
                            HyperLink1.Visible = False
                        Else
                            lnk.Visible = True
                            HyperLink1.Visible = True
                        End If
                        Exit Select
                        '    'Added By MUBYN
                    Case "Reminder"
                        HyperLink1.NavigateUrl = Page.ResolveUrl("~/Reminder.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID)))
                        Dim activitistatus As String = data.Field(Of String)("Status")
                        If activitistatus = "Close" Then
                            lnk.Visible = False
                            HyperLink1.Visible = False
                            lnkChangeDSR.Visible = False
                        Else
                            lnk.Visible = False
                            HyperLink1.Visible = True
                            lnkChangeDSR.Visible = True
                        End If
                        Exit Select
                    Case "Event"
                        HyperLink1.NavigateUrl = Page.ResolveUrl("~/ActivityEvent.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID)))
                        Dim activitistatus As String = data.Field(Of String)("Status")
                        If activitistatus = "Close" Then
                            lnk.Visible = False
                            HyperLink1.Visible = False
                        Else
                            lnk.Visible = True
                            HyperLink1.Visible = True
                        End If
                        Exit Select
                    Case "Call"
                        HyperLink1.NavigateUrl = Page.ResolveUrl("~/ActivityCall.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID)))
                        Dim activitistatus As String = data.Field(Of String)("Status")
                        If activitistatus = "Close" Then
                            lnk.Visible = False
                            HyperLink1.Visible = False
                        Else
                            lnk.Visible = True
                            HyperLink1.Visible = True
                        End If
                        Exit Select
                        '=============Modification By MUBYN ===========Start
                    Case "DSR"
                        'HyperLink1.NavigateUrl = Page.ResolveUrl("~/dsr.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)))
                        HyperLink1.NavigateUrl = Page.ResolveUrl("~/dsr.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID)))
                        Dim activitistatus As String = data.Field(Of String)("Status")
                        If activitistatus = "Close" Then
                            lnk.Visible = False
                            HyperLink1.Visible = False
                        Else
                            lnk.Visible = True
                            HyperLink1.Visible = True
                        End If
                        Exit Select
                        '=============Modification By MUBYN ===========End

                End Select
                If e.Row.RowType = DataControlRowType.DataRow Then
                    For Each cell As TableCell In e.Row.Cells
                        Dim littext As String = cell.Text
                        Dim Literals As Label = New Label()
                        If (cell.Text = "Pending" Or cell.Text = "Low" Or cell.Text = "Lowest") Then
                            Literals.CssClass = "label label-warning"
                        ElseIf (cell.Text = "Due") Then
                            Literals.CssClass = "label label-warning"
                        ElseIf (cell.Text = "Missed") Then
                            Literals.CssClass = "label label-danger"
                        ElseIf (cell.Text = "High" Or cell.Text = "Highest") Then
                            Literals.CssClass = "label label-danger"
                        ElseIf (cell.Text = "Close" Or cell.Text = "Today") Then
                            Literals.CssClass = "label label-success"
                        ElseIf (cell.Text = "Close Postpone" Or cell.Text = "Normal") Then
                            Literals.CssClass = "label label-info"
                        ElseIf (cell.Text = "Tommorrow") Then
                            Literals.CssClass = "label label-info"
                        End If
                        If (cell.Text = "Event") Then
                            littext = "Sampling/Demo"
                        ElseIf (cell.Text = "Call") Then
                            littext = "Phone/Email"
                        End If
                        Literals.EnableViewState = True
                        Literals.Text = littext
                        cell.Controls.Add(Literals)
                    Next
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Activity", "GridView1_RowDataBound", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddluser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddluser.SelectedIndexChanged
        Session("DUserId") = ddluser.SelectedValue
        fillLead("FillTopTenActivity")
        FillIndexCount()
        FillSalesTargetCount()
        fillPending()
    End Sub

End Class
