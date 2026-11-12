Imports DynamicparcelEnumerations

Partial Class SubCategory
    Inherits _PageBaseClass
    Private MainId As Integer
    Dim ParentiD As String

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        SearchControl.Uhfadd.Visible = False
        If Not IsPostBack Then
            Hfgridview.Value = "SubCategoryGridview"
            hfsearch.Value = "SubCategorySearch"
            hftotalrecord.Value = "SubCategoryTotalNumberOfRecord"
            txtsequence.Text = MainBLL.GetCode("SubCategorySeqNo")
            fillUser()
            FillCategory()
            CheckPrivilage()
            'Above Line For Passing Mode In Search User Control
            SearchControl.Uhfgridviewmode.Value = "SubCategoryGridview"
            SearchControl.Uhfsearchmode.Value = "SubCategorySearch"
            SearchControl.Uhftotalcount.Value = "SubCategoryTotalNumberOfRecord"
        End If
    End Sub

    Public Sub fillUser()
        Try
            GridView1.VirtualItemCount = MainBLL.TotalRowInGridview(hftotalrecord.Value)
            GridView1.DataSource = MainBLL.FillGridView("0", SearchControl.Uddpagesize.SelectedValue, Hfgridview.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SubCategory", "fillUser", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub IndexfillUser()
        Try
            GridView1.DataSource = MainBLL.FillGridView(GridView1.PageIndex, SearchControl.Uddpagesize.SelectedValue, Hfgridview.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SubCategory", "IndexfillUser", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
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
            ExecptionBLL.Insert("SubCategory", "GridView1_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddpagesize_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchControl.SelectedIndexChanged
        If SearchControl.Uddpagesize.SelectedItem.Text <> "0" Then
            GridView1.PageSize = SearchControl.Uddpagesize.SelectedValue.ToString()
            IndexfillUser()
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
        End If
    End Sub

    Protected Sub lkadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchControl.LKClick
        lblheading.Text = "Add New SubCategory"
        hfcheck.Value = 0
        txtCategoryname.Text = ""
        lblcatname.Text = ""
        txtCategoryname.Focus()
        FillCategory()
        ddcategory.ClearSelection()
        mpe.Show()
        txtsequence.Text = MainBLL.GetCode("SubCategorySeqNo")
    End Sub

    Protected Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs)
        SetSortDirection(SortDireaction)
        Try
            Dim dt As DataSet = MainBLL.SortingGridView("SubCategorySorting")
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
            ExecptionBLL.Insert("SubCategory", "GridView1_Sorting", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "deletelink" Then
            If deletestatus.Value = "yes" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                MainId = GridView1.DataKeys(index).Value
                Try
                    MainBLL.DeleteSI(MainId, Session("UserId"), "SubCategoryDeleteSi", Session("Audlog_Id"))
                    IndexfillUser()
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("SubCategory", "deletelink", error1, Session("UserId"))
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
                MainBLL.UpdateStatus(MainId, Session("UserId"), "SubCategoryStatus", Session("Audlog_Id"))
                If SearchControl.UtxtSearch.Text.Trim = "" Then
                    IndexfillUser()
                Else
                    SearchFillUser()
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("SubCategory", "statuslink", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        ElseIf e.CommandName = "addlink" Then
            Try
                lblcatname.Text = ""
                lblparent.Text = ""
                txtCategoryname.Text = ""
                mpe.Enabled = True
                mpe.Show()
                hfcheck.Value = 0
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("SubCategory", "addlink", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        ElseIf e.CommandName = "editlink" Then
            lblheading.Text = "Modify SubCategory"
            txtCategoryname.Focus()
            FillCategory()
            lblcatname.Text = ""
            lblparent.Text = ""
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            MainId = GridView1.DataKeys(index).Value
            hfcheck.Value = MainId
            Dim row As GridViewRow = GridView1.Rows(index)
            Try
                mpe.Enabled = True
                mpe.Show()
                Dim dt As DataSet = MainBLL.ViewByID(MainId, "SubCategoryViewByID")
                Dim dtUser As New DataTable
                dtUser = dt.Tables(0)
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                txtCategoryname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Category_Name").ToString())
                ddcategory.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Category_ParentID").ToString())
                txtsequence.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Category_SequenceNo").ToString())
                hfchanged.Value = txtCategoryname.Text
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("SubCategory", "editlink", error1, Session("UserId"))
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
            ExecptionBLL.Insert("SubCategory", "SearchFillUser", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub CheckPrivilage()
        Try
            DynamicparcelGridview.CheckPrivilageWithSamePageModified(SearchControl.ULkadd, 4, 5, 3, GridView1, Session("UserRoleID"), "Category.aspx")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SubCategory", "CheckPrivilage", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If hfcheck.Value = 0 Then
            SaveProduct(DML_OPERATION.INSERT)
        ElseIf hfcheck.Value > 0 Then
            SaveProduct(DML_OPERATION.UPDATE)
        End If

    End Sub

    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try
                    Dim CheckPageName As String = ""
                    If Not txtCategoryname.Text = hfchanged.Value Then
                        CheckPageName = MainBLL.CheckPageNameWithID(txtCategoryname.Text.Trim, Convert.ToInt32(ddcategory.SelectedValue), "SubCategoryNameCheck")
                    End If

                    If (CheckPageName = "Already Exist") Then
                        lblcatname.Text = "SubCategory name  already exist"
                        txtCategoryname.Focus()
                        remembername.Display = ValidatorDisplay.Dynamic
                        mpe.Show()
                    Else
                        If String.IsNullOrEmpty(txtsequence.Text) Then
                            txtsequence.Text = "0"
                        End If
                        ParentiD = ddcategory.SelectedValue
                        SubCategoryBLL.Update(txtCategoryname.Text.Trim, ParentiD, "Child", Session("Audlog_Id"), Session("UserId"), hfcheck.Value, txtsequence.Text)
                        fillUser()
                        mpe.Hide()

                    End If
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("SubCategory", "UPDATE", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Case DML_OPERATION.INSERT
                Try
                    Dim CheckPageName As String = MainBLL.CheckPageNameWithID(txtCategoryname.Text.Trim, Convert.ToInt32(ddcategory.SelectedValue), "SubCategoryNameCheck")
                    If (CheckPageName = "Already Exist") Then
                        lblcatname.Text = "SubCategory name  already exist"
                        txtCategoryname.Focus()
                        remembername.Display = ValidatorDisplay.Dynamic
                        mpe.Show()
                    Else
                        If String.IsNullOrEmpty(txtsequence.Text) Then
                            txtsequence.Text = "0"
                        End If
                        ParentiD = ddcategory.SelectedValue
                        SubCategoryBLL.Insert(txtCategoryname.Text.Trim, ParentiD, "Child", Session("Audlog_Id"), Session("UserId"), txtsequence.Text)
                        GridView1.PageIndex = GridView1.PageIndex
                        fillUser()
                        mpe.Hide()

                    End If
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("SubCategory", "INSERT", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub

    Public Sub FillCategory()
        Try
            ddcategory.DataSource = MainBLL.Dropdown("CategoryDropDown")
            ddcategory.DataTextField = "Breadcrumb"
            ddcategory.DataValueField = "Category_ID"
            ddcategory.DataBind()
            ddcategory.Items.Insert(0, "Select Category")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

End Class
