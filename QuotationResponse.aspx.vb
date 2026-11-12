
Partial Class QuotationResponse
    Inherits _PageBaseClass
    Private MainId As Integer
    Dim RespCount As String
    Dim RespVendor As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        Else
        End If
        Try
            ' If MainId = 0 Then
            '  MainId = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            'SearchControl.ULkadd.Visible = False
            ' SearchControl.Uhfadd.NavigateUrl = Page.ResolveUrl("AddQuotationResponse.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(MainId)) & "&VID=" + HttpUtility.UrlEncode(Security.Encrypt(0)))
            'Else
            '    MainId = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            'End If
            SearchControl.ULkadd.Visible = False
            SearchControl.Uhfadd.Visible = False
            If Not IsPostBack Then
                If (Request.QueryString("Id") <> Nothing) Then
                    Hfgridview.Value = "QuotationResponseViewbyID"
                    hfsearch.Value = "SearchQuotationRespByAssignByID"
                    hftotalrecord.Value = "QuotationRespTotalNumberOfRecordByID"
                    fillQuotation()
                    'CheckPrivilage()
                    'Above Line For Passing Mode In Search Lead Control
                    MainId = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                    SearchControl.UhfExcelName.Value = "Quotation Response Details"
                    SearchControl.Uhfgridviewmode.Value = "QuotationResponseViewbyID"
                    SearchControl.Uhfsearchmode.Value = "SearchQuotationRespByAssignByID"
                    SearchControl.UhfExcelmode.Value = "ExcelQuotationRespByAssign"
                    ' SearchControl.UhfExcelName.Value = "ExcelQuotationRespByAssign"
                    SearchControl.Uhftotalcount.Value = "QuotationRespTotalNumberOfRecordByID"
                    SearchControl.Uhfid.Value = MainId

                Else
                    Hfgridview.Value = "FillGridViewQuotationResponse"
                    hfsearch.Value = "SearchQuotationRespAll"
                    hftotalrecord.Value = "QuotationRespTotalNumberOfRecord"
                    fillQuotation()
                    'CheckPrivilage()
                    'Above Line For Passing Mode In Search Lead Control
                    SearchControl.UhfExcelName.Value = "Quotation Request Details"
                    SearchControl.Uhfgridviewmode.Value = "FillGridViewQuotationResponse"
                    SearchControl.Uhfsearchmode.Value = "SearchQuotationRespAll"
                    SearchControl.UhfExcelmode.Value = "ExcelQuotationRespByAssign"
                    SearchControl.Uhftotalcount.Value = "QuotationRespTotalNumberOfRecord"
                    SearchControl.Uhfid.Value = MainId
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("QuotationResponse", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try

    End Sub

    Public Sub fillQuotation()
        Try
            If (Request.QueryString("Id") <> Nothing) Then

                MainId = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                GridView1.PageSize = SearchControl.Uddpagesize.SelectedValue
                GridView1.VirtualItemCount = MainBLL.TotalRowInGridviewBYID(hftotalrecord.Value, MainId)
                GridView1.DataSource = MainBLL.FillGridViewById("0", SearchControl.Uddpagesize.SelectedValue, MainId, Hfgridview.Value)
                GridView1.DataBind()
            Else
                GridView1.PageSize = SearchControl.Uddpagesize.SelectedValue
                GridView1.VirtualItemCount = MainBLL.TotalRowInGridview(hftotalrecord.Value)
                GridView1.DataSource = MainBLL.FillGridView("0", SearchControl.Uddpagesize.SelectedValue, Hfgridview.Value)
                GridView1.DataBind()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("QuotationResponse", "fillQuotation", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub IndexfillQuotation()
       Try
            If (Request.QueryString("Id") <> Nothing) Then

                MainId = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                GridView1.PageSize = SearchControl.Uddpagesize.SelectedValue
                GridView1.VirtualItemCount = MainBLL.TotalRowInGridviewBYID(hftotalrecord.Value, MainId)
                GridView1.DataSource = MainBLL.FillGridViewById(GridView1.PageIndex, SearchControl.Uddpagesize.SelectedValue, MainId, Hfgridview.Value)
                GridView1.DataBind()
            Else
                GridView1.PageSize = SearchControl.Uddpagesize.SelectedValue
                GridView1.VirtualItemCount = MainBLL.TotalRowInGridview(hftotalrecord.Value)
                GridView1.DataSource = MainBLL.FillGridView(GridView1.PageIndex, SearchControl.Uddpagesize.SelectedValue, Hfgridview.Value)
                GridView1.DataBind()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("QuotationResponse", "fillQuotation", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            If SearchControl.UtxtSearch.Text = "" Then
                GridView1.PageIndex = e.NewPageIndex
                If (Request.QueryString("Id") <> Nothing) Then
                    MainId = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                    GridView1.DataSource = MainBLL.FillGridViewById(GridView1.PageIndex, SearchControl.Uddpagesize.SelectedValue, MainId, Hfgridview.Value)
                    GridView1.DataBind()
                Else
                    GridView1.DataSource = MainBLL.FillGridView(GridView1.PageIndex, SearchControl.Uddpagesize.SelectedValue, Hfgridview.Value)
                    GridView1.DataBind()
                End If
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
            Else
                GridView1.PageIndex = e.NewPageIndex
                SearchFillQuotation()
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("QuotationResponse", "GridView1_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddpagesize_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchControl.SelectedIndexChanged
        Try
            If SearchControl.Uddpagesize.SelectedItem.Text <> "0" Then
                GridView1.PageSize = SearchControl.Uddpagesize.SelectedValue.ToString()
                ' IndexfillQuotation()
                fillQuotation()
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("QuotationResponse", "ddpagesize_SelectedIndexChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GridView1.Sorting
        SetSortDirection(SortDireaction)
        Try
            Dim dt As DataSet
            If (Request.QueryString("Id") <> Nothing) Then
                MainId = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                dt = MainBLL.SortingGridViewById("QuotationResponseSorting", MainId)
                Dim DataTable As DataTable = dt.Tables(0)
                If DataTable IsNot Nothing Then
                    DataTable.DefaultView.Sort = Convert.ToString(e.SortExpression) & " " & _sortDirection
                    GridView1.DataSource = DataTable
                    GridView1.DataBind()
                    SortDireaction = _sortDirection
                    Dim columnIndex As Integer = 0
                    For Each headerCell As DataControlFieldHeaderCell In GridView1.HeaderRow.Cells
                        If headerCell.ContainingField.SortExpression = e.SortExpression Then
                            columnIndex = GridView1.HeaderRow.Cells.GetCellIndex(headerCell)
                        End If
                    Next
                    GridView1.HeaderRow.Cells(columnIndex).Controls.Add(sortImage)
                End If

            Else

                dt = MainBLL.SortingGridView("QuotationResponseSorting")

                Dim DataTable As DataTable = dt.Tables(0)
                If DataTable IsNot Nothing Then
                    DataTable.DefaultView.Sort = Convert.ToString(e.SortExpression) & " " & _sortDirection
                    GridView1.DataSource = DataTable
                    GridView1.DataBind()
                    SortDireaction = _sortDirection
                    Dim columnIndex As Integer = 0
                    For Each headerCell As DataControlFieldHeaderCell In GridView1.HeaderRow.Cells
                        If headerCell.ContainingField.SortExpression = e.SortExpression Then
                            columnIndex = GridView1.HeaderRow.Cells.GetCellIndex(headerCell)
                        End If
                    Next
                    GridView1.HeaderRow.Cells(columnIndex).Controls.Add(sortImage)
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("QuotationResponse", "GridView1_Sorting", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub SearchFillQuotation()
        Try

            MainId = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            GridView1.DataSource = MainBLL.SearchGridViewByID(SearchControl.UtxtSearch.Text, hfsearch.Value, MainId)
            GridView1.DataBind()

            'GridView1.DataSource = MainBLL.SearchGridView(SearchControl.UtxtSearch.Text, hfsearch.Value)
            'GridView1.DataBind()

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("QuotationResponse", "SearchFillQuotation", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub


    Public Sub CheckPrivilage()
        Try
            Dim dt As DataSet = PrivilageBLL.CheckPrivilige(Session("UserRoleID"), "QuotationRequest.aspx")
            Dim dtprivilage As New DataTable
            dtprivilage = dt.Tables(0)
            Dim drprivilage As DataRow
            If dtprivilage.Rows.Count = 0 Then
                SearchControl.Uhfadd.Visible = False
                GridView1.Columns(0).Visible = False
                SearchControl.ULkadd.Visible = False
            Else
                drprivilage = dtprivilage.Rows(0)
                If (drprivilage("Prvg_RAdd").ToString()) = True Then
                    SearchControl.Uhfadd.Visible = True
                Else
                    SearchControl.Uhfadd.Visible = False

                End If
                If (drprivilage("Prvg_RUpdate").ToString()) = True Then
                    GridView1.Columns(0).Visible = True
                Else
                    GridView1.Columns(0).Visible = False
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("QuotationResponse", "CheckPrivilage", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
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

               


                If SearchControl.UtxtSearch.Text.Trim = "" Then
                    IndexfillQuotation()
                Else
                    SearchFillQuotation()
                End If
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

            Dim lblPerUnit As Literal = DirectCast(GridView1.Rows(index).FindControl("lblPerUnit1"), Literal)

            Dim lblAmount As Literal = DirectCast(GridView1.Rows(index).FindControl("lblAmount1"), Literal)
            Dim lblTax As Literal = DirectCast(GridView1.Rows(index).FindControl("lblTax1"), Literal)
            Dim lblFreight As Literal = DirectCast(GridView1.Rows(index).FindControl("lblFreight1"), Literal)
            Dim lblRMID As Literal = DirectCast(GridView1.Rows(index).FindControl("lblRMID"), Literal)
            Dim lblQResponse_Code As Literal = DirectCast(GridView1.Rows(index).FindControl("lblQResponse_Code"), Literal)
            Dim lblQty As Literal = DirectCast(GridView1.Rows(index).FindControl("lblQty1"), Literal)
            Dim getstring As String() = lblQty.Text.ToString().Split(New Char() {"-"c})
            Dim Qty, unit As String
            Qty = getstring(0)
            unit = getstring(1)
            Dim PurchaseOrder_ID As Integer = PurchaseOrderBLL.InsertPurchaseOrder(a, lblQResponse_Code.Text, b, lblAmount.Text, lblTax.Text, lblFreight.Text, Session("UserId"), Session("Audlog_Id"))
            'Dim ds As DataSet = MainBLL.ViewByID(0, "PurchaseOrderViewById")
            PurchaseOrderBLL.InsertPORawMaterial(lblRMID.Text, PurchaseOrder_ID, Qty, unit, Session("UserId"), Session("Audlog_Id"))
            PurchaseOrderBLL.UpdatePORawMaterial(lblRMID.Text, PurchaseOrder_ID, CDbl(lblPerUnit.Text), CDbl(lblTax.Text), CDbl(lblAmount.Text))

            Response.Redirect("Purchaseorder.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(a)) + "&VId=" + HttpUtility.UrlEncode(Security.Encrypt(b)))



            If SearchControl.UtxtSearch.Text.Trim = "" Then
                IndexfillQuotation()
            Else
                SearchFillQuotation()
            End If
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

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
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
End Class

