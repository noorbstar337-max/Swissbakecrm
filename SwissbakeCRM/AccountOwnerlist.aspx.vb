
Partial Class Account
    Inherits _PageBaseClass
    Private MainId As Integer

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            CheckPrivilage()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AccountOwnerlist", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "');window.location='CRMindex.aspx';", True)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            SearchControl.ULkadd.Visible = False
            SearchControl.Uhfadd.Visible = False
            If Not IsPostBack Then
                Hfgridview.Value = "AccountWithOwner"
                hfsearch.Value = "SearchAccountWithOwner"
                hftotalrecord.Value = "AccountWithOwnerTotalNumberOfRecord"
                fillLead()
                'Above Line For Passing Mode In Search Lead Control
                SearchControl.UhfExcelName.Value = "Account Details"
                SearchControl.Uhfgridviewmode.Value = "AccountWithOwner"
                SearchControl.Uhfsearchmode.Value = "SearchAccountWithOwner"
                SearchControl.UhfExcelmode.Value = "ExcelAccountWithOwner"
                SearchControl.Uhftotalcount.Value = "AccountWithOwnerTotalNumberOfRecord"
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AccountOwnerlist", "Page_Load", error1, Session("UserId"))
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
            ExecptionBLL.Insert("AccountOwnerlist", "fillLead", error1, Session("UserId"))
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
            ExecptionBLL.Insert("AccountOwnerlist", "IndexfillLead", error1, Session("UserId"))
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
            ExecptionBLL.Insert("AccountOwnerlist", "GridView1_PageIndexChanging", error1, Session("UserId"))
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
            ExecptionBLL.Insert("AccountOwnerlist", "ddpagesize_SelectedIndexChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs)
        SetSortDirection(SortDireaction)
        Try
            Dim dt As DataSet
            dt = AccountBLL.AccountSortingByOwner()
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
            ExecptionBLL.Insert("AccountOwnerlist", "GridView1_Sorting", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
       
    End Sub

    Public Sub SearchFillLead()
        Try
            'Shhaid
            GridView1.DataSource = MainBLL.SearchGridViewByID(SearchControl.UtxtSearch.Text.Trim, Session("UserId"), hfsearch.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AccountOwnerlist", "SearchFillLead", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub


    Public Sub CheckPrivilage()
        If Not Session("UserRoleID") = 1 Then
            Throw New Exception("You don't have right to view this page\n Please contact admin!")
        End If
        'Try
        '    Dim dt As DataSet = PrivilageBLL.CheckPrivilige(Session("UserRoleID"), "Account.aspx")
        '    Dim dtprivilage As New DataTable
        '    dtprivilage = dt.Tables(0)
        '    Dim drprivilage As DataRow
        '    If dtprivilage.Rows.Count = 0 Then
        '        SearchControl.Uhfadd.Visible = False
        '        GridView1.Columns(0).Visible = False
        '        SearchControl.ULkadd.Visible = False
        '    Else
        '        drprivilage = dtprivilage.Rows(0)
        '        If (drprivilage("Prvg_RAdd").ToString()) = True Then
        '            SearchControl.Uhfadd.Visible = True
        '        Else
        '            SearchControl.Uhfadd.Visible = False

        '        End If
        '        If (drprivilage("Prvg_RUpdate").ToString()) = True Then
        '            GridView1.Columns(0).Visible = True
        '        Else
        '            GridView1.Columns(0).Visible = False
        '        End If
        '    End If
        'Catch ex As Exception
        '    Dim error1 As String = ex.Message.Replace(Chr(34), "")
        '    error1 = error1.Replace(Chr(39), "")
        '    ExecptionBLL.Insert("Account", "CheckPrivilage", error1, Session("UserId"))
        '    'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        '    Throw ex
        'End Try
    End Sub

End Class
