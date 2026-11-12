Imports DynamicparcelEnumerations

Partial Class UOM
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
            Hfgridview.Value = "UOMGridview"
            hfsearch.Value = "UOMSearch"
            hftotalrecord.Value = "UOMTotalNumberOfRecord"
            txtsequence.Text = MainBLL.GetCode("SequenceNo")
            fillUser()
            CheckPrivilage()
            'Above Line For Passing Mode In Search User Control
            SearchControl.Uhfgridviewmode.Value = "UOMGridview"
            SearchControl.Uhfsearchmode.Value = "UOMSearch"
            SearchControl.Uhftotalcount.Value = "UOMTotalNumberOfRecord"
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("UOM", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillUser()
        Try
            GridView1.VirtualItemCount = MainBLL.TotalRowInGridview(hftotalrecord.Value)
            GridView1.DataSource = MainBLL.FillGridView("0", SearchControl.Uddpagesize.SelectedValue, Hfgridview.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("UOM", "fillUser", error1, Session("UserId"))
            ' ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub IndexfillUser()
        Try
            GridView1.DataSource = MainBLL.FillGridView(GridView1.PageIndex, SearchControl.Uddpagesize.SelectedValue, Hfgridview.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("UOM", "IndexfillUser", error1, Session("UserId"))
            ' ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            If SearchControl.UtxtSearch.Text = "" Then
                GridView1.PageIndex = e.NewPageIndex
                GridView1.DataSource = MainBLL.FillGridView(e.NewPageIndex, SearchControl.Uddpagesize.SelectedValue, Hfgridview.Value)
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
            ExecptionBLL.Insert("UOM", "GridView1_PageIndexChanging", error1, Session("UserId"))
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
            ExecptionBLL.Insert("UOM", "ddpagesize_SelectedIndexChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub lkadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchControl.LKClick
        Try
            lblheading.Text = "Add New UOM"
            hfcheck.Value = 0
            txtUOMname.Text = ""
            lblname.Text = ""
            txtUOMname.Focus()
            mpe.Show()
            txtsequence.Text = MainBLL.GetCode("SequenceNo")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("UOM", "lkadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs)
        SetSortDirection(SortDireaction)
        Try
            Dim dt As DataSet = MainBLL.SortingGridView("UOMSorting")
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
            ExecptionBLL.Insert("UOM", "GridView1_Sorting", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "deletelink" Then
            If deletestatus.Value = "yes" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                MainId = GridView1.DataKeys(index).Value
                Try
                    MainBLL.DeleteSI(MainId, Session("UserId"), "UOMDeleteSi", Session("Audlog_Id"))
                    IndexfillUser()
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("UOM", "deletelink", error1, Session("UserId"))
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
                MainBLL.UpdateStatus(MainId, Session("UserId"), "UOMStatus", Session("Audlog_Id"))
                If SearchControl.UtxtSearch.Text.Trim = "" Then
                    IndexfillUser()
                Else
                    SearchFillUser()
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("UOM", "statuslink", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        ElseIf e.CommandName = "addlink" Then
            Try
                lblname.Text = ""
                txtUOMname.Text = ""
                mpe.Enabled = True
                mpe.Show()
                hfcheck.Value = 0
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("UOM", "addlink", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        ElseIf e.CommandName = "editlink" Then
            txtUOMname.Focus()
            lblname.Text = ""
            lblheading.Text = "Modify UOM"
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            MainId = GridView1.DataKeys(index).Value
            hfcheck.Value = MainId
            Dim row As GridViewRow = GridView1.Rows(index)
            Try
                mpe.Enabled = True
                mpe.Show()
                Dim lblname As Literal = DirectCast(GridView1.Rows(row.RowIndex).FindControl("ltname"), Literal)
                Dim lblseq As Literal = DirectCast(GridView1.Rows(row.RowIndex).FindControl("ltseq"), Literal)
                txtUOMname.Text = lblname.Text
                txtsequence.Text = lblseq.Text
                hfchanged.Value = lblname.Text
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("UOM", "editlink", error1, Session("UserId"))
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
            ExecptionBLL.Insert("UOM", "SearchFillUser", error1, Session("UserId"))
            ' ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub CheckPrivilage()
        Try
            DynamicparcelGridview.CheckPrivilageWithSamePageModified(SearchControl.ULkadd, 4, 5, 3, GridView1, Session("UserRoleID"), "UOM.aspx")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("UOM", "CheckPrivilage", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            If hfcheck.Value = 0 Then
                SaveProduct(DML_OPERATION.INSERT)
            ElseIf hfcheck.Value > 0 Then
                SaveProduct(DML_OPERATION.UPDATE)
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("UOM", "Button1_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try
                    Dim CheckPageName As String = ""
                    If Not txtUOMname.Text = hfchanged.Value Then
                        CheckPageName = MainBLL.CheckPageName(txtUOMname.Text.Trim, "UOMNameCheck")
                    End If

                    If (CheckPageName = "Already Exist") Then
                        lblname.Text = "UOM name  already exist"
                        txtUOMname.Focus()
                        remembername.Display = ValidatorDisplay.Dynamic
                        mpe.Show()
                    Else
                        If String.IsNullOrEmpty(txtsequence.Text) Then
                            txtsequence.Text = "0"
                        End If
                        lblname.Text = ""
                        remembername.Display = ValidatorDisplay.Static
                        UOMBLL.Update(txtUOMname.Text.Trim, Session("UserId"), hfcheck.Value, Session("Audlog_Id"), txtsequence.Text)
                        fillUser()
                        mpe.Hide()

                    End If
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("UOM", "UPDATE", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Case DML_OPERATION.INSERT
                Try
                    Dim CheckPageName As String = MainBLL.CheckPageName(txtUOMname.Text.Trim, "UOMNameCheck")
                    If (CheckPageName = "Already Exist") Then
                        lblname.Text = "UOM name  already exist"
                        txtUOMname.Focus()
                        remembername.Display = ValidatorDisplay.Dynamic
                        mpe.Show()
                    Else
                        If String.IsNullOrEmpty(txtsequence.Text) Then
                            txtsequence.Text = "0"
                        End If
                        lblname.Text = ""
                        remembername.Display = ValidatorDisplay.Static
                        UOMBLL.Insert(txtUOMname.Text.Trim, Session("UserId"), Session("Audlog_Id"), txtsequence.Text)
                        GridView1.PageIndex = GridView1.PageIndex
                        fillUser()
                        mpe.Hide()

                    End If
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("UOM", "INSERT", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub
End Class
