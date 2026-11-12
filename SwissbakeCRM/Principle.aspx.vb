Imports DynamicparcelEnumerations

Partial Class Principle
    Inherits _PageBaseClass
    Private MainId As Integer
    Private RespCount As Integer

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
            Try
                CheckPrivilage()
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "');window.location='AdminMenu.aspx';", True)
            End Try
        Else
            Try
                CheckPrivilage()
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "');window.location='AdminMenu.aspx';", True)
            End Try
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            SearchControl.Uhfadd.Visible = False
            If Not IsPostBack Then
                Hfgridview.Value = "PrincipleGridview"
                hfsearch.Value = "PrincipleSearch"
                hftotalrecord.Value = "PrincipleTotalNumberOfRecord"
                fillPrinciple()
                'CheckPrivilage()
                'Above Line For Passing Mode In Search User Control
                SearchControl.UhfExcelName.Value = "Principle Details"
                SearchControl.Uhfgridviewmode.Value = "PrincipleGridview"
                SearchControl.Uhfsearchmode.Value = "PrincipleSearch"
                SearchControl.UhfExcelmode.Value = "PrincipleExcel"
                SearchControl.Uhftotalcount.Value = "PrincipleTotalNumberOfRecord"
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Principle", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillPrinciple()
        Try
            GridView1.VirtualItemCount = MainBLL.TotalRowInGridview(hftotalrecord.Value)
            GridView1.DataSource = MainBLL.FillGridView("0", SearchControl.Uddpagesize.SelectedValue, Hfgridview.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Principle", "fillPrinciple", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub IndexfillPrinciple()
        Try
            GridView1.DataSource = MainBLL.FillGridView(GridView1.PageIndex, SearchControl.Uddpagesize.SelectedValue, Hfgridview.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Principle", "IndexfillPrinciple", error1, Session("UserId"))
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
            ExecptionBLL.Insert("Principle", "GridView1_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddpagesize_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchControl.SelectedIndexChanged
        Try
            If SearchControl.Uddpagesize.SelectedItem.Text <> "0" Then
                GridView1.PageSize = SearchControl.Uddpagesize.SelectedValue.ToString()
                IndexfillPrinciple()
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Principle", "ddpagesize_SelectedIndexChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    'Protected Sub lkadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchControl.LKClick
    '    Try
    '        lblheading.Text = "Add New Principle"
    '        hfcheck.Value = 0
    '        txtPrinciplename.Text = ""
    '        lblname.Text = ""
    '        txtPrinciplename.Focus()
    '        mpe.Show()
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert("Principle", "lkadd_Click", error1, Session("UserId"))
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub
    Protected Sub lkadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchControl.LKClick
        Try
            hfcheck.Value = 0
            lblheading.Text = "Add New Principle"
            mpe.Show()
            txtcompanyname.Text = ""
            txtconperson.Text = ""
            txtemail.Text = ""
            txtmob.Text = ""
            txtaddressbill.Text = ""
            txtcitybill.Text = ""
            txtofficeno.Text = ""
            txtpincodebill.Text = ""
            FillCountry()
            fillPrinciple()

            ddlpCountry_SelectedIndexChanged(Nothing, Nothing)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Principle", "lkadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs)
        SetSortDirection(SortDireaction)
        Try
            Dim dt As DataSet = MainBLL.SortingGridView("PrincipleSorting")
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
            ExecptionBLL.Insert("Principle", "GridView1_Sorting", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "deletelink" Then
            If deletestatus.Value = "yes" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                MainId = GridView1.DataKeys(index).Value
                Try
                    MainBLL.DeleteSI(MainId, Session("UserId"), "PrincipleDeleteSi", Session("Audlog_Id"))
                    IndexfillPrinciple()
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("Principle", "deletelink", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Else
                If SearchControl.UtxtSearch.Text.Trim = "" Then
                    IndexfillPrinciple()
                Else
                    SearchFillUser()
                End If
            End If

        ElseIf e.CommandName = "statuslink" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            MainId = GridView1.DataKeys(index).Value
            Try
                MainBLL.UpdateStatus(MainId, Session("UserId"), "PrincipleStatus", Session("Audlog_Id"))
                If SearchControl.UtxtSearch.Text.Trim = "" Then
                    IndexfillPrinciple()
                Else
                    SearchFillUser()
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("Principle", "statuslink", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        ElseIf e.CommandName = "addlink" Then
            Try
                lblname.Text = ""
                ' txtPrinciplename.Text = ""
                mpe.Enabled = True
                mpe.Show()
                hfcheck.Value = 0
                FillCountry()
                FillPStatebill()
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("Principle", "addlink", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        ElseIf e.CommandName = "editlink" Then
            lblheading.Text = "Modify Principle"
            '   txtPrinciplename.Focus()
            lblname.Text = ""
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            MainId = GridView1.DataKeys(index).Value
            hfcheck.Value = MainId
            Dim row As GridViewRow = GridView1.Rows(index)
            Try
                mpe.Enabled = True
                fillPrinciple()
                mpe.Show()
                Dim lblcompanyname As Literal = DirectCast(GridView1.Rows(row.RowIndex).FindControl("lblscname"), Literal)
                Dim lblcontactperson As Literal = DirectCast(GridView1.Rows(row.RowIndex).FindControl("lblconperson"), Literal)
                Dim lblEmail As Literal = DirectCast(GridView1.Rows(row.RowIndex).FindControl("lblEmail"), Literal)
                Dim lblmobileno As Literal = DirectCast(GridView1.Rows(row.RowIndex).FindControl("lblmobile"), Literal)
                Dim hfphone As HiddenField = DirectCast(GridView1.Rows(row.RowIndex).FindControl("hfphone"), HiddenField)
                Dim hfstate As HiddenField = DirectCast(GridView1.Rows(row.RowIndex).FindControl("hfstate"), HiddenField)
                Dim hfaddress As HiddenField = DirectCast(GridView1.Rows(row.RowIndex).FindControl("hfaddress"), HiddenField)
                Dim hfcity As HiddenField = DirectCast(GridView1.Rows(row.RowIndex).FindControl("hfcity"), HiddenField)
                Dim hfpincode As HiddenField = DirectCast(GridView1.Rows(row.RowIndex).FindControl("hfpincode"), HiddenField)
                Dim hfcountry As HiddenField = DirectCast(GridView1.Rows(row.RowIndex).FindControl("hfcountry"), HiddenField)

                txtcompanyname.Text = lblcompanyname.Text
                hfchanged.Value = lblcompanyname.Text
                txtconperson.Text = lblcontactperson.Text
                txtemail.Text = lblEmail.Text
                txtmob.Text = lblmobileno.Text
                txtpincodebill.Text = hfpincode.Value
                txtcitybill.Text = hfcity.Value
                txtaddressbill.Text = hfaddress.Value
                txtofficeno.Text = hfphone.Value
                FillCountry()
                ddlcountrybill.SelectedValue = hfcountry.Value
                ddlpCountry_SelectedIndexChanged(Nothing, Nothing)
                ddlstatebill.SelectedValue = hfstate.Value

            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("Principle", "editlink", error1, Session("UserId"))
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
            ExecptionBLL.Insert("Principle", "SearchFillUser", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub CheckPrivilage()
        Try
            DynamicparcelGridview.CheckPrivilageWithSamePageModified(SearchControl.ULkadd, 3, 4, 2, GridView1, Session("UserRoleID"), "Principle.aspx")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Principle", "CheckPrivilage", error1, Session("UserId"))
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
            ExecptionBLL.Insert("Principle", "Button1_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try
                    Dim CheckPageName As String = ""
                    If Not txtcompanyname.Text = hfchanged.Value Then
                        CheckPageName = MainBLL.CheckPageName(txtcompanyname.Text.Trim, "PrincipleNameCheck")
                    End If

                    If (CheckPageName = "Already Exist") Then
                        lblname.Text = "Principle name  already exist"
                        txtcompanyname.Focus()
                        remembername.Display = ValidatorDisplay.Dynamic
                        mpe.Show()
                    Else
                        lblname.Text = ""
                        remembername.Display = ValidatorDisplay.Static
                        PrincipleBLL.Update(txtcompanyname.Text, txtconperson.Text, txtemail.Text, (txtmob.Text).ToString, txtofficeno.Text, txtaddressbill.Text, txtpincodebill.Text,
                                            txtcitybill.Text, ddlstatebill.SelectedValue, ddlcountrybill.SelectedValue, Session("UserId"), Session("UName"), hfcheck.Value, Session("Audlog_Id"))
                        fillPrinciple()
                        mpe.Hide()
                        Response.Redirect(Request.RawUrl)
                    End If
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("Principle", "UPDATE", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Case DML_OPERATION.INSERT
                Try
                    Dim CheckPageName As String = MainBLL.CheckPageName(txtcompanyname.Text.Trim, "PrincipleNameCheck")
                    If (CheckPageName = "Already Exist") Then
                        lblname.Text = "Principle name  already exist"
                        txtcompanyname.Focus()
                        remembername.Display = ValidatorDisplay.Dynamic
                        mpe.Show()
                    Else
                        lblname.Text = ""
                        remembername.Display = ValidatorDisplay.Static
                        PrincipleBLL.Insert(txtcompanyname.Text, txtconperson.Text, txtemail.Text, (txtmob.Text).ToString, txtofficeno.Text, txtaddressbill.Text, txtpincodebill.Text,
                                            txtcitybill.Text, ddlstatebill.SelectedValue, ddlcountrybill.SelectedValue, Session("userID"), "Admin", Session("Audlog_Id"))
                        GridView1.PageIndex = GridView1.PageIndex
                        fillPrinciple()
                        mpe.Hide()
                        Response.Redirect(Request.RawUrl)
                    End If
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("Principle", "INSERT", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub

    Public Sub FillCountry()
        Try
            Dim ds As DataSet = MainBLL.Dropdown("CountryDropDown")
            ddlcountrybill.DataSource = ds.Tables(0)
            ddlcountrybill.DataTextField = "CountryName"
            ddlcountrybill.DataValueField = "Id"
            ddlcountrybill.DataBind()
            ddlcountrybill.Items.Insert(0, New ListItem("Select Country", "0"))
            ddlcountrybill.SelectedValue = 105
            ddlcountrybill.CssClass = "form-control"
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Principle", "FillCountry", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillPStatebill()
        Try
            ddlstatebill.Items.Clear()
            Dim ds As DataSet = MainBLL.DropdownWithID("StateDropDown", ddlcountrybill.SelectedValue)
            ddlstatebill.DataSource = ds.Tables(0)
            ddlstatebill.DataTextField = "StateName"
            ddlstatebill.DataValueField = "Id"
            ddlstatebill.DataBind()
            ddlstatebill.Items.Insert(0, New ListItem("Select State", "0"))
            ddlstatebill.CssClass = "form-control"
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Principle", "FillStatebill", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub ddlpCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlcountrybill.SelectedIndexChanged
        Try
            FillPStatebill()
            mpe.Show()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Principle", "ddlcountrybill_SelectedIndexChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            For Each row As GridViewRow In GridView1.Rows
                Dim lblid = DirectCast(row.FindControl("lblscId"), Literal)

                Dim hledit = DirectCast(row.FindControl("HyperLink2"), LinkButton)
                Dim HyperLinkdelete = DirectCast(row.FindControl("lnkdelete"), LinkButton)
                Dim dt As DataSet = MainBLL.ViewByID(lblid.Text, "PrinciplerWiseVendoGridviewViewByID")
                Dim dtUser As New DataTable
                dtUser = dt.Tables(0)

                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                RespCount = DynamicparcelDataManipulation.FixNullFromDB(drLogin("TCount").ToString())


                If lblid.Text = 0 Then
                    hledit.Visible = False
                    HyperLinkdelete.Visible = False
                Else
                    If RespCount = 0 Then
                        HyperLinkdelete.Visible = True
                        hledit.Visible = True

                    ElseIf RespCount > 0 Then

                        hledit.Visible = True
                        HyperLinkdelete.Visible = False


                    End If

                End If

            Next
        Catch ex As Exception

        End Try
    End Sub
End Class

