Imports DynamicparcelEnumerations

Partial Class LMSUser
    Inherits _PageBaseClass
    ' Inherits System.Web.UI.Page

    Private MainId As Integer

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("LMSUserRoleID") = Nothing Then
            TryCast(Me.Master, LMSMasterPage).MaintainSession()
            If Not Session("LMSUserRoleID") = "1" Then
                Response.Redirect("LMSdashboard.aspx")
            End If
        Else
            If Not Session("LMSUserRoleID") = "1" Then
                Response.Redirect("LMSdashboard.aspx")
            End If
        End If
        'If Session("LMSUserId") = Nothing Then
        '    TryCast(Me.Master, LMSMasterPage).MaintainSession()
        'End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'SearchControl.Uhfadd.Visible = False
            SearchControl.UbtnExportExcel.Visible = False
            SearchControl.UbtnExportWord.Visible = False
            SearchControl.ULkadd.Visible = False
            SearchControl.ULkadd.Text = "Quick Add"
            'SearchControl.UhfExcelName.Value = "User Details"
            'SearchControl.Uhfadd.NavigateUrl = Page.ResolveUrl("ModifyUser.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)))
            SearchControl.Uhfadd.NavigateUrl = "~/ModifyLMSUser.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0))
            If Not IsPostBack Then
                Hfgridview.Value = "LMSUserGridview"
                hfsearch.Value = "LMSUserSearch"
                hftotalrecord.Value = "LMSUserTotalNumberOfRecord"
                If MainId = "0" Then
                    If Not (LMSBLL.NoOfUser().ToString = "Allowed") Then
                        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Reach end of user limit\n Contact super Admin')", True)
                        SearchControl.Uhfadd.Enabled = False
                        SearchControl.ULkadd.Enabled = False
                    End If
                End If
                fillUser()
                'Filllevel()
                CheckLMSPrivilege()
                'Above Line For Passing Mode In Search User Control
                'SearchControl.UhfExcelName.Value = "User Details"
                SearchControl.Uhfgridviewmode.Value = "LMSUserGridview"
                SearchControl.Uhfsearchmode.Value = "LMSUserSearch"
                'SearchControl.UhfExcelmode.Value = "UserExcel"
                SearchControl.Uhftotalcount.Value = "UserTotalNumberOfRecord"
                'SearchControl.Uhfadd.Visible = False
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("LMSUser", "Page_Load", error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillUser()
        Try
            GridView1.VirtualItemCount = MainBLL.TotalRowInGridview(hftotalrecord.Value)
            'GridView1.VirtualItemCount = LMSBLL.TotalRowInGridview(hftotalrecord.Value)
            GridView1.DataSource = MainBLL.FillGridView("0", SearchControl.Uddpagesize.SelectedValue, Hfgridview.Value)
            'GridView1.DataSource = LMSBLL.FillGridView("0", SearchControl.Uddpagesize.SelectedValue, Hfgridview.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("LMSUser", "fillUser", error1, Session("LMSUserId"))
            ' ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

        Public Sub IndexfillUser()
            Try
            GridView1.DataSource = MainBLL.FillGridView(GridView1.PageIndex, SearchControl.Uddpagesize.SelectedValue, Hfgridview.Value)
            'GridView1.DataSource = LMSBLL.FillGridView(GridView1.PageIndex, SearchControl.Uddpagesize.SelectedValue, Hfgridview.Value)
                GridView1.DataBind()
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("LMSUser", "IndexfillUser", error1, Session("LMSUserId"))
                ' ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                Throw ex
            End Try
        End Sub


        Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
            Try
                If SearchControl.UtxtSearch.Text = "" Then
                    GridView1.PageIndex = e.NewPageIndex
                GridView1.DataSource = MainBLL.FillGridView(e.NewPageIndex, SearchControl.Uddpagesize.SelectedValue, Hfgridview.Value)
                'GridView1.DataSource = LMSBLL.FillGridView(e.NewPageIndex, SearchControl.Uddpagesize.SelectedValue, Hfgridview.Value)
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
            ExecptionBLL.Insert("LMSUser", "GridView1_PageIndexChanging", error1, Session("LMSUserId"))
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
            ExecptionBLL.Insert("LMSUser", "ddpagesize_SelectedIndexChanged", error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs)
        SetSortDirection(SortDireaction)
        Try
            Dim dt As DataSet = MainBLL.SortingGridView("UserSorting")
            'Dim dt As DataSet = LMSBLL.SortingGridView("UserSorting")
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
            ExecptionBLL.Insert("LMSUser", "GridView1_Sorting", error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "deletelink" Then
            If deletestatus.Value = "yes" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                MainId = GridView1.DataKeys(index).Value
                Try
                    LMSBLL.DeleteSI(MainId, Session("LMSUserId"), "UserDeleteSi", Session("Audlog_Id"))
                    IndexfillUser()
                    If (LMSBLL.NoOfUser().ToString = "Allowed") Then
                        'SearchControl.Uhfadd.Enabled = True
                        SearchControl.ULkadd.Enabled = True
                    End If
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("LMSUser", "deletelink", error1, Session("LMSUserId"))
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
                LMSBLL.UpdateStatus(MainId, Session("LMSUserId"), "UserStatus", Session("Audlog_Id"))
                If SearchControl.UtxtSearch.Text.Trim = "" Then
                    IndexfillUser()
                Else
                    SearchFillUser()
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("LMSUser", "statuslink", error1, Session("LMSUserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
    End Sub

    Public Sub SearchFillUser()
        Try
            'Shhaid
            GridView1.DataSource = MainBLL.SearchGridView(SearchControl.UtxtSearch.Text.Trim, hfsearch.Value)
            'GridView1.DataSource = LMSBLL.SearchGridView(SearchControl.UtxtSearch.Text.Trim, hfsearch.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("LMSUser", "SearchFillUser", error1, Session("LMSUserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub CheckLMSPrivilege()
        Try
            'DynamicparcelGridview.CheckPrivilagewithNoView(9, 8, 7, GridView1, Session("LMSUserRoleID"), SearchControl.Uhfadd, "LMSUser.aspx")
            DynamicparcelGridview.CheckLMSPrivilegewithNoView(9, 8, 7, GridView1, Session("LMSUserRoleID"), SearchControl.Uhfadd, "LMSUser.aspx")
            If Not SearchControl.Uhfadd.Visible Then
                SearchControl.ULkadd.Visible = False
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("LMSUser", "CheckPrivilage", error1, Session("LMSUserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub


        Protected Sub lkadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchControl.LKClick
            Try
                fillUser()
            If (LMSBLL.NoOfUser().ToString = "Allowed") Then
                lblheading.Text = "Add New User"
                hfcheck.Value = 0
                txtuname.Text = ""
                txtemail.Text = ""
                txtnewpass.Text = ""
                txtconfirm.Text = ""
                lblname.Text = ""
                ddllevel.SelectedValue = 0
                txtuname.Focus()
                mpe.Show()
            Else
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Reach end of user limit\n Contact super Admin')", True)
                mpe.Hide()
            End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("LMSUser", "lkadd_Click", error1, Session("LMSUserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End Sub


        Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnsave.Click
            Try
            If (LMSBLL.NoOfUser().ToString = "Allowed") Then
                If hfcheck.Value = 0 Then
                    SaveUser(DML_OPERATION.INSERT)
                ElseIf hfcheck.Value > 0 Then
                    SaveUser(DML_OPERATION.UPDATE)
                End If
            Else
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Reach end of user limit\n Contact super Admin')", True)
                mpe.Hide()
            End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("LMSUser", "Button1_Click", error1, Session("LMSUserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End Sub

    Private Sub SaveUser(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
            Case DML_OPERATION.INSERT
                Try
                    Dim CheckPageName As String = LMSBLL.CheckPageName(txtemail.Text.Trim, "EmailCheck")
                    If (CheckPageName = "Already Exist") Then
                        lblname.Text = "Email already exist"
                        txtemail.Focus()
                        remembername.Display = ValidatorDisplay.Dynamic
                        mpe.Show()
                    Else
                        lblname.Text = ""
                        remembername.Display = ValidatorDisplay.Static
                        LMSBLL.QuickInsert(txtuname.Text.Trim, txtconfirm.Text.Trim, txtemail.Text.Trim, ddllevel.SelectedValue, txtMobile.Text, Session("LMSUserId"), Session("Audlog_Id"))
                        GridView1.PageIndex = GridView1.PageIndex
                        fillUser()
                        mpe.Hide()
                    End If

                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("Stage", "INSERT", error1, Session("LMSUserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub

        Public Sub Filllevel()
            Try
            '  ddllevel.DataSource = MainBLL.Dropdown("LevelDropDown")
            ddllevel.DataSource = LMSBLL.Dropdown("LevelDropDown")
                ddllevel.DataTextField = "Level_LevelName"
                ddllevel.DataValueField = "Level_Id"
                ddllevel.DataBind()
                ddllevel.Items.Insert(0, New ListItem("Select Role", "0"))
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyUser", "Filllevel", error1, Session("LMSUserId"))
                'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                Throw ex
            End Try
        End Sub

    End Class

