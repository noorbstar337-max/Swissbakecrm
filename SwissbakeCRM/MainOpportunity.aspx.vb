
Partial Class MainOpportunity
    Inherits _PageBaseClass
    Private MainId As Integer

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Session("UserId") = Nothing Then
                TryCast(Me.Master, MainPage).MaintainSession()
                SearchControl.ULkadd.Visible = False
                SearchControl.ULkadd.Text = "Quick Add"
                SearchControl.Uhfadd.NavigateUrl = Page.ResolveUrl("Opportunity.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)))
                If Not IsPostBack Then
                    Hfgridview.Value = "OpportunityGridviewByAssign"
                    hfsearch.Value = "SearchOpportunityByAssign"
                    hftotalrecord.Value = "OpporTotalNumberOfRecord"
                    fillLead()
                    CheckPrivilage()
                    'Above Line For Passing Mode In Search Lead Control
                    SearchControl.UhfExcelName.Value = "Opportunity Details"
                    SearchControl.Uhfgridviewmode.Value = "OpportunityGridviewByAssign"
                    SearchControl.Uhfsearchmode.Value = "SearchOpportunityByAssign"
                    SearchControl.UhfExcelmode.Value = "ExcelOpportunityByAssign"
                    SearchControl.Uhftotalcount.Value = "OpporTotalNumberOfRecord"
                End If
            Else
                SearchControl.ULkadd.Visible = False
                SearchControl.ULkadd.Text = "Quick Add"
                SearchControl.Uhfadd.NavigateUrl = Page.ResolveUrl("Opportunity.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)))
                If Not IsPostBack Then
                    Hfgridview.Value = "OpportunityGridviewByAssign"
                    hfsearch.Value = "SearchOpportunityByAssign"
                    hftotalrecord.Value = "OpporTotalNumberOfRecord"
                    fillLead()
                    CheckPrivilage()
                    'Above Line For Passing Mode In Search Lead Control
                    SearchControl.UhfExcelName.Value = "Opportunity Details"
                    SearchControl.Uhfgridviewmode.Value = "OpportunityGridviewByAssign"
                    SearchControl.Uhfsearchmode.Value = "SearchOpportunityByAssign"
                    SearchControl.UhfExcelmode.Value = "ExcelOpportunityByAssign"
                    SearchControl.Uhftotalcount.Value = "OpporTotalNumberOfRecord"
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MainOpportunity", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillLead()
        Try
            GridView1.PageSize = SearchControl.Uddpagesize.SelectedValue
            GridView1.VirtualItemCount = MainBLL.TotalRowInGridviewBYID(hftotalrecord.Value, Session("UserId"))
            GridView1.DataSource = MainBLL.FillGridViewById("0", SearchControl.Uddpagesize.SelectedValue, Session("UserId"), Hfgridview.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MainOpportunity", "fillLead", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub IndexfillLead()
        Try
            GridView1.DataSource = MainBLL.FillGridViewById(GridView1.PageIndex, SearchControl.Uddpagesize.SelectedValue, Session("UserId"), Hfgridview.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MainOpportunity", "IndexfillLead", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            If SearchControl.UtxtSearch.Text = "" Then
                GridView1.PageIndex = e.NewPageIndex
                GridView1.DataSource = MainBLL.FillGridViewById(GridView1.PageIndex, SearchControl.Uddpagesize.SelectedValue, Session("UserId"), Hfgridview.Value)
                GridView1.DataBind()
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
            Else
                GridView1.PageIndex = e.NewPageIndex
                SearchFillLead()
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MainOpportunity", "GridView1_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddpagesize_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchControl.SelectedIndexChanged
        Try
        If SearchControl.Uddpagesize.SelectedItem.Text <> "0" Then
            GridView1.PageSize = SearchControl.Uddpagesize.SelectedValue.ToString()
            IndexfillLead()
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MainOpportunity", "ddpagesize_SelectedIndexChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs)
        SetSortDirection(SortDireaction)
        Try
            Dim dt As DataSet = OpportunityBLL.OpportunitySortingByAssign(Session("UserId"))
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
            ExecptionBLL.Insert("MainOpportunity", "GridView1_Sorting", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "deletelink" Then
            If deletestatus.Value = "yes" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                MainId = GridView1.DataKeys(index).Value
                Try
                    MainBLL.DeleteSI(MainId, Session("LeadId"), "LeadDeleteSi", Session("Audlog_Id"))
                    IndexfillLead()
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("MainOpportunity", "deletelink", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Else
                If SearchControl.UtxtSearch.Text.Trim = "" Then
                    IndexfillLead()
                Else
                    SearchFillLead()
                End If
            End If
        ElseIf e.CommandName = "statuslink" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            MainId = GridView1.DataKeys(index).Value
            Try
                MainBLL.UpdateStatus(MainId, Session("LeadId"), "LeadStatus", Session("Audlog_Id"))
                If SearchControl.UtxtSearch.Text.Trim = "" Then
                    IndexfillLead()
                Else
                    SearchFillLead()
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("MainOpportunity", "statuslink", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
    End Sub

    Public Sub SearchFillLead()
        Try
            'Shhaid
            GridView1.DataSource = MainBLL.SearchGridViewByID(SearchControl.UtxtSearch.Text.Trim, Session("UserId"), hfsearch.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MainOpportunity", "SearchFillLead", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub CheckPrivilage()
        Try
            Dim dt As DataSet = PrivilageBLL.CheckPrivilige(Session("UserRoleID"), "MainOpportunity.aspx")
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
                    SearchControl.ULkadd.Visible = False
                Else
                    SearchControl.Uhfadd.Visible = False
                    SearchControl.ULkadd.Visible = False
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
            ExecptionBLL.Insert("MainOpportunity", "CheckPrivilage", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lbprobability As Literal = DirectCast(e.Row.FindControl("lblProbability"), Literal)
            Dim divprogress As HtmlGenericControl = DirectCast(e.Row.FindControl("divprogress"), HtmlGenericControl)
            divprogress.Style("width") = lbprobability.Text + "%"
            'divprogress.InnerHtml = lbprobability.Text
            lbprobability.Text = lbprobability.Text.Replace("%", "")
            If lbprobability.Text >= 0 And lbprobability.Text <= 20 Then
                divprogress.Attributes("class") = "progress-bar progress-bar-danger"
            ElseIf lbprobability.Text >= 20 And lbprobability.Text <= 40 Then
                divprogress.Attributes("class") = "progress-bar progress-bar-warning"
            ElseIf lbprobability.Text >= 40 And lbprobability.Text <= 60 Then
                divprogress.Attributes("class") = "progress-bar progress-bar-info"
            ElseIf lbprobability.Text >= 60 Then
                divprogress.Attributes("class") = "progress-bar progress-bar-success"
            End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MainOpportunity", "GridView1_RowDataBound", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class
