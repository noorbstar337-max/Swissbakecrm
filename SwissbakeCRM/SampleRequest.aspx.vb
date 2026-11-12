
Partial Class Sample

    Inherits _PageBaseClass
    Private MainId As Integer

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            SearchControl.ULkadd.Visible = False
            SearchControl.Uhfadd.NavigateUrl = Page.ResolveUrl("ModifySampleRequest.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)))

            If Not IsPostBack Then
                If Request.QueryString("Type") = Nothing Then
                    Response.Redirect("SampleRequestNew.aspx")
                ElseIf Request.QueryString("Type") = "All" Then
                    Hfgridview.Value = "SampleGridviewByAssign"
                    hfsearch.Value = "SampleSearchByAssign"
                    hftotalrecord.Value = "SampleTotalNumberOfRecord"
                    fillOrder()
                    CheckPrivilage()
                    'Above Line For Passing Mode In Search Order Control
                    SearchControl.UhfExcelName.Value = "Sample Request Details"
                    SearchControl.Uhfgridviewmode.Value = "SampleGridviewByAssign"
                    SearchControl.Uhfsearchmode.Value = "SampleSearchByAssign"
                    SearchControl.UhfExcelmode.Value = "SampleSearchByAssign"
                    SearchControl.Uhftotalcount.Value = "SampleTotalNumberOfRecord"
                Else
                    If Request.QueryString("Type").ToString = "prgvfhjsghf" Then
                        Hfgridview.Value = "SampleViewGridviewByAssign"
                        hfsearch.Value = "SampleViewSearchByAssign"
                        hftotalrecord.Value = "SampleViewTotalNumberOfRecord"
                        fillOrder()
                        ' CheckPrivilage()
                        'Above Line For Passing Mode In Search Order Control
                        SearchControl.UhfExcelName.Value = "Sales Order Details"
                        SearchControl.Uhfgridviewmode.Value = "SampleViewGridviewByAssign"
                        SearchControl.Uhfsearchmode.Value = "SampleViewSearchByAssign"
                        SearchControl.UhfExcelmode.Value = "SampleViewSearchByAssign"
                        SearchControl.Uhftotalcount.Value = "SampleViewTotalNumberOfRecord"

                    End If
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Order", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillOrder()
        Try
            GridView1.PageSize = SearchControl.Uddpagesize.SelectedValue
            'GridView1.VirtualItemCount = MainBLL.TotalRowInGridview(hftotalrecord.Value)
            GridView1.VirtualItemCount = MainBLL.TotalRowInGridviewBYID(hftotalrecord.Value, Session("UserId"))
            GridView1.DataSource = SampleBLL.FillGridViewById("0", SearchControl.Uddpagesize.SelectedValue, Session("UserId"), Hfgridview.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Order", "fillOrder", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub IndexfillOrder()
        Try
            GridView1.DataSource = SampleBLL.FillGridViewById(GridView1.PageIndex, SearchControl.Uddpagesize.SelectedValue, Session("UserId"), Hfgridview.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Order", "IndexfillOrder", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            If SearchControl.UtxtSearch.Text = "" Then
                GridView1.PageIndex = e.NewPageIndex
                GridView1.DataSource = SampleBLL.FillGridViewById(GridView1.PageIndex, SearchControl.Uddpagesize.SelectedValue, Session("UserId"), Hfgridview.Value)
                GridView1.DataBind()
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
            Else
                GridView1.PageIndex = e.NewPageIndex
                SearchFillOrder()
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Order", "GridView1_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddpagesize_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchControl.SelectedIndexChanged
        Try
            If SearchControl.Uddpagesize.SelectedItem.Text <> "0" Then
                GridView1.PageSize = SearchControl.Uddpagesize.SelectedValue.ToString()
                IndexfillOrder()
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Order", "ddpagesize_SelectedIndexChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs)
        SetSortDirection(SortDireaction)
        Try
            Dim dt As DataSet
            If Request.QueryString("Type") = Nothing Then
                dt = SampleBLL.SortingGridViewById("SampleSorting", Session("UserId"))
            Else
                If Request.QueryString("Type").ToString = "prgvfhjsghf" Then
                    dt = SampleBLL.SortingGridViewById("SampleViewSorting", Session("UserId"))
                Else
                    dt = SampleBLL.SortingGridViewById("", Session("UserId"))
                End If
            End If
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
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Order", "GridView1_Sorting", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "deletelink" Then
            If deletestatus.Value = "yes" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                MainId = GridView1.DataKeys(index).Value
                Try
                    Dim msg As String = SampleBLL.DeleteSI(MainId, Session("UserId"), "SampleDeleteSi", Session("Audlog_Id"))
                    If Not String.IsNullOrEmpty(msg) Then
                        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + msg + "')", True)
                    End If
                    IndexfillOrder()
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("Order", "deletelink", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Else
                If SearchControl.UtxtSearch.Text.Trim = "" Then
                    IndexfillOrder()
                Else
                    SearchFillOrder()
                End If
            End If

        End If
    End Sub

    Public Sub SearchFillOrder()
        Try
            GridView1.DataSource = SampleBLL.SearchGridViewByID(SearchControl.UtxtSearch.Text.Trim, Session("UserId"), hfsearch.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Order", "SearchFillOrder", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub CheckPrivilage()
        Try
            Dim dt As DataSet = PrivilageBLL.CheckPrivilige(Session("UserRoleID"), "SampleRequest.aspx")
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
                If (drprivilage("Prvg_RDelete").ToString()) = True Then
					GridView1.Columns(9).Visible = True
				Else
					GridView1.Columns(9).Visible = False
				End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SampleRequest", "CheckPrivilage", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub



    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                '    Dim ltdel As Literal = DirectCast(e.Row.FindControl("ltdel"), Literal)
                Dim ltreqstatus As Literal = DirectCast(e.Row.FindControl("ltreqstatus"), Literal)
                Dim lnkdelete As LinkButton = DirectCast(e.Row.FindControl("lnkdelete"), LinkButton)
                Dim HyperLink2 As HyperLink = DirectCast(e.Row.FindControl("HyperLink2"), HyperLink)
                If ltreqstatus.Text = "Requested" Then
                    lnkdelete.Visible = True
                Else
                    lnkdelete.Visible = False
                End If
                If ltreqstatus.Text = "Requested" Or ltreqstatus.Text = "Dispatched" Then
                    HyperLink2.Visible = True
                Else
                    HyperLink2.Visible = False
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SalesOrders", "GridView1_RowDataBound", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class

