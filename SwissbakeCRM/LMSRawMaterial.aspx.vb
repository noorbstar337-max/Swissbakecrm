Imports DynamicparcelEnumerations

Partial Class LMSRawMaterial
    Inherits _PageBaseClass
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
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            SearchControl.Uhfadd.Visible = False
            If Not IsPostBack Then
                Hfgridview.Value = "RawmaterialGridview"
                hfsearch.Value = "RawmaterialSearch"
                hftotalrecord.Value = "RawmaterialTotalNumberOfRecord"
                fillUser()
                'Above Line For Passing Mode In Search User Control
                SearchControl.UhfExcelName.Value = "Rawmaterial Details"
                SearchControl.Uhfgridviewmode.Value = "RawmaterialGridview"
                SearchControl.Uhfsearchmode.Value = "RawmaterialSearch"
                SearchControl.UhfExcelmode.Value = "RawmaterialExcel"
                SearchControl.Uhftotalcount.Value = "RawmaterialTotalNumberOfRecord"
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Rawmaterial", "Page_Load", error1, Session("LMSUserId"))
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
            ExecptionBLL.Insert("Rawmaterial", "fillUser", error1, Session("LMSUserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
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
            ExecptionBLL.Insert("Rawmaterial", "IndexfillUser", error1, Session("LMSUserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
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
            ExecptionBLL.Insert("Rawmaterial", "GridView1_PageIndexChanging", error1, Session("LMSUserId"))
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
            ExecptionBLL.Insert("Rawmaterial", "ddpagesize_SelectedIndexChanged", error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub lkadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchControl.LKClick
        Try
            lblheading.Text = "Add New Raw Material"
            hfcheck.Value = 0
            txtRawmaterialCode.Text = ""
            txtRawmaterialname.Text = ""
            lblname.Text = ""
            'txtRawmaterialname.Text = ""
            txtbrand.Text = ""
            txtdesc.Text = ""
            txtRawmaterialCode.Focus()
            mpe.Show()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Rawmaterial", "lkadd_Click", error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs)
        SetSortDirection(SortDireaction)
        Try
            Dim dt As DataSet = MainBLL.SortingGridView("RawmaterialSorting")
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
            ExecptionBLL.Insert("Rawmaterial", "GridView1_Sorting", error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "deletelink" Then
            If deletestatus.Value = "yes" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                MainId = GridView1.DataKeys(index).Value
                Try
                    MainBLL.DeleteSI(MainId, Session("LMSUserId"), "RawmaterialDeleteSi", Session("Audlog_Id"))
                    IndexfillUser()
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("Rawmaterial", "deletelink", error1, Session("LMSUserId"))
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
                MainBLL.UpdateStatus(MainId, Session("LMSUserId"), "RawmaterialStatus", Session("Audlog_Id"))
                If SearchControl.UtxtSearch.Text.Trim = "" Then
                    IndexfillUser()
                Else
                    SearchFillUser()
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("Rawmaterial", "statuslink", error1, Session("LMSUserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        ElseIf e.CommandName = "addlink" Then
            Try
                txtRawmaterialCode.Text = ""
                lblname.Text = ""
                txtRawmaterialname.Text = ""
                txtbrand.Text = ""
                txtdesc.Text = ""
                txtgenericname.Text = ""
                mpe.Enabled = True
                mpe.Show()
                hfcheck.Value = 0
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("Rawmaterial", "addlink", error1, Session("LMSUserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        ElseIf e.CommandName = "editlink" Then
            lblheading.Text = "Modify Raw Materail"
            ddItemType.SelectedIndex = 0
            txtRawmaterialname.Focus()
            lblname.Text = ""
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            MainId = GridView1.DataKeys(index).Value
            hfcheck.Value = MainId
            Dim dt As DataSet = MainBLL.ViewByID(MainId, "RawmaterialViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            Dim row As GridViewRow = GridView1.Rows(index)
            Try
                mpe.Enabled = True
                mpe.Show()
                txtRawmaterialCode.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Rm_Code").ToString())
                txtRawmaterialname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Rm_Name").ToString())
                txtbrand.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Rm_Brand").ToString())
                txtdesc.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Rm_Desc").ToString())
                hfchanged.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Rm_Name").ToString())
                txtinstock.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Rm_Stock").ToString())
                txtgenericname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Rm_GenericName").ToString())

                ddItemType.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Rm_Type").ToString())
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("Rawmaterial", "editlink", error1, Session("LMSUserId"))
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
            ExecptionBLL.Insert("Rawmaterial", "SearchFillUser", error1, Session("LMSUserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub CheckPrivilage()
        Try
            DynamicparcelGridview.CheckPrivilageWithSamePageModified(SearchControl.ULkadd, 3, 4, 2, GridView1, Session("UserRoleID"), "Vendor.aspx")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Rawmaterial", "CheckPrivilage", error1, Session("LMSUserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
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
            ExecptionBLL.Insert("Rawmaterial", "Button1_Click", error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try
                    Dim CheckPageName As String = ""
                    If Not txtRawmaterialname.Text = hfchanged.Value Then
                        CheckPageName = MainBLL.CheckPageName(txtRawmaterialname.Text.Trim, "RawmaterialNameCheck")
                    End If

                    If (CheckPageName = "Already Exist") Then
                        lblname.Text = "Item name  already exist"
                        txtRawmaterialname.Focus()
                        remembername.Display = ValidatorDisplay.Dynamic
                        mpe.Show()
                    Else
                        lblname.Text = ""
                        remembername.Display = ValidatorDisplay.Static
                        '=============gayatri added Rm_Type on 27-07-2017====================================
                        RawmaterialBLL.Update(txtRawmaterialname.Text.Trim, txtdesc.Text.Trim, txtbrand.Text.Trim, Session("LMSUserId"), hfcheck.Value, Session("Audlog_Id"),
                                              txtRawmaterialCode.Text.Trim, ddItemType.SelectedValue.ToString, txtinstock.Text, txtgenericname.Text)
                        fillUser()
                        lblname.Text = ""
                        txtRawmaterialname.Text = ""
                        txtbrand.Text = ""
                        txtdesc.Text = ""
                        txtinstock.Text = ""
                        txtgenericname.Text = ""
                        mpe.Hide()
                    End If
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("Rawmaterial", "UPDATE", error1, Session("LMSUserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Case DML_OPERATION.INSERT
                Try
                    Dim CheckPageName As String = MainBLL.CheckPageName(txtRawmaterialname.Text.Trim, "RawmaterialNameCheck")
                    If (CheckPageName = "Already Exist") Then
                        lblname.Text = "Rawmaterial name  already exist"
                        txtRawmaterialname.Focus()
                        remembername.Display = ValidatorDisplay.Dynamic
                        mpe.Show()
                    Else
                        lblname.Text = ""
                        remembername.Display = ValidatorDisplay.Static
                        '=============gayatri added Rm_Type on 27-07-2017====================================
                        RawmaterialBLL.Insert(txtRawmaterialname.Text.Trim, txtdesc.Text.Trim, txtbrand.Text.Trim, Session("LMSUserId"), Session("Audlog_Id"),
                                              txtRawmaterialCode.Text.Trim, ddItemType.SelectedValue.ToString, txtinstock.Text, txtgenericname.Text)
                        GridView1.PageIndex = GridView1.PageIndex
                        fillUser()
                        lblname.Text = ""
                        txtRawmaterialname.Text = ""
                        txtbrand.Text = ""
                        txtdesc.Text = ""
                        txtinstock.Text = ""
                        txtgenericname.Text = ""
                        mpe.Hide()
                    End If

                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("Rawmaterial", "INSERT", error1, Session("LMSUserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub

End Class

