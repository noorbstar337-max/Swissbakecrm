Imports DynamicparcelEnumerations
Partial Class MainOrder

    Inherits _PageBaseClass
    Private MainId As Integer

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            SearchControl.Uhfadd.Visible = False
            If Not IsPostBack Then
                Hfgridview.Value = "ViewOrderByMemberID"
                'hfsearch.Value = "ComplaintSearch"
                'hftotalrecord.Value = "ComplaintTotalNumberOfRecord"
                fillUser()
                'CheckPrivilage()
                'Above Line For Passing Mode In Search User Control
                SearchControl.Uhfgridviewmode.Value = "ComplaintGridview"
                SearchControl.Uhfsearchmode.Value = "ComplaintSearch"
                SearchControl.Uhftotalcount.Value = "ComplaintTotalNumberOfRecord"
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Complaint", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillUser()
        Try
            GridView1.VirtualItemCount = MainBLL.TotalRowInGridviewBYID(hftotalrecord.Value, Session("UserId"))
            GridView1.DataSource = MainBLL.FillGridViewById("0", SearchControl.Uddpagesize.SelectedValue, Session("UserId"), Hfgridview.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Complaint", "fillUser", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub IndexfillUser()
        Try
            GridView1.DataSource = MainBLL.FillGridViewById(GridView1.PageIndex, SearchControl.Uddpagesize.SelectedValue, Session("UserId"), Hfgridview.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Complaint", "IndexfillUser", error1, Session("UserId"))
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
                SearchFillUser()
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Complaint", "GridView1_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddpagesize_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchControl.SelectedIndexChanged
        Try
            If SearchControl.Uddpagesize.SelectedItem.Text <> "0" Then
                GridView1.PageSize = SearchControl.Uddpagesize.SelectedValue.ToString()
                IndexfillUser()
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Complaint", "ddpagesize_SelectedIndexChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs)
        SetSortDirection(SortDireaction)
        Try
            Dim dt As DataSet = MainBLL.SortingGridView("UserTypeSorting")
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
            ExecptionBLL.Insert("UserType", "GridView1_Sorting", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "deletelink" Then
            If deletestatus.Value = "yes" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                MainId = GridView1.DataKeys(index).Value
                Try
                    MainBLL.DeleteSI(MainId, Session("UserId"), "ComplaintDeleteSi", Session("Audlog_Id"))
                    IndexfillUser()
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("UserType", "deletelink", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Else
                If SearchControl.UtxtSearch.Text.Trim = "" Then
                    IndexfillUser()
                Else
                    SearchFillUser()
                End If
            End If

        ElseIf e.CommandName = "statuslink" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            MainId = GridView1.DataKeys(index).Value
            Try
                MainBLL.UpdateStatus(MainId, Session("UserId"), "UserTypeStatus", Session("Audlog_Id"))
                If SearchControl.UtxtSearch.Text.Trim = "" Then
                    IndexfillUser()
                Else
                    SearchFillUser()
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("UserType", "statuslink", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
    End Sub

    Public Sub SearchFillUser()
        Try
            GridView1.DataSource = MainBLL.SearchGridView(SearchControl.UtxtSearch.Text.Trim, hfsearch.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("UserType", "SearchFillUser", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub CheckPrivilage()
        Try
            DynamicparcelGridview.CheckPrivilageWithSamePageModified(SearchControl.ULkadd, 3, 4, 2, GridView1, Session("UserRoleID"), "UserType.aspx")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("UserType", "CheckPrivilage", error1, Session("UserId"))
            ' ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
End Class
