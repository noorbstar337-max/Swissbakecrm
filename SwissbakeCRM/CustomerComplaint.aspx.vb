Imports DynamicparcelEnumerations

Partial Class CustomerComplaint
    Inherits _PageBaseClass
    Private MainId As Integer
    Dim ParentiD As String
    Private ProductId As Integer

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
        If Session("UserRoleID") = "4" Then
            Response.Redirect("SupportDashBoard.aspx")
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            SearchControl.ULkadd.Visible = False
            SearchControl.Uhfadd.NavigateUrl = Page.ResolveUrl("ModifyCustomerComplaint.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")
            If Not IsPostBack Then
                fillUser()
                'Above Line For Passing Mode In Search User Control
                SearchControl.UhfExcelName.Value = "Complaint Details"
                SearchControl.Uhfgridviewmode.Value = "CustComplaintGridview"
                SearchControl.Uhfsearchmode.Value = "CustComplaintSearch"
                SearchControl.UhfExcelmode.Value = "CustComplaintExcel"
                SearchControl.Uhftotalcount.Value = "CustComplaintTotalNumberOfRecord"
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillUser()
        Try
            GridView1.VirtualItemCount = MainBLL.TotalRowInGridview("CustComplaintTotalNumberOfRecord")
            GridView1.DataSource = MainBLL.FillGridView("0", 10, "CustComplaintGridview")
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub


    Public Sub IndexfillUser()
        Try
            GridView1.DataSource = MainBLL.FillGridView(GridView1.PageIndex, SearchControl.Uddpagesize.SelectedValue, "CustComplaintGridview")
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            If SearchControl.UtxtSearch.Text = "" Then
                GridView1.PageIndex = e.NewPageIndex
                GridView1.DataSource = MainBLL.FillGridView(e.NewPageIndex, SearchControl.Uddpagesize.SelectedValue, "CustComplaintGridview")
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
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs)
        SetSortDirection(SortDireaction)
        Try
            Dim dt As DataSet = MainBLL.SortingGridView("CustComplaintSorting")
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
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "deletelink" Then
            If deletestatus.Value = "yes" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                ProductId = GridView1.DataKeys(index).Value
                Try
                    MainBLL.DeleteSI(ProductId, Session("UserId"), "CustComplaintDeleteSi", Session("Audlog_Id"))
                    IndexfillUser()
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
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
            ProductId = GridView1.DataKeys(index).Value
            Try
                MainBLL.UpdateStatus(ProductId, Session("UserId"), "CustComplaintStatus", Session("Audlog_Id"))
                If SearchControl.UtxtSearch.Text.Trim = "" Then
                    IndexfillUser()
                Else
                    SearchFillUser()
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
    End Sub

    Public Sub SearchFillUser()
        Try
            GridView1.DataSource = MainBLL.SearchGridView(SearchControl.UtxtSearch.Text.Trim, "CustComplaintSearch")
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            For Each row As GridViewRow In GridView1.Rows
                Dim ltchkmark = DirectCast(row.FindControl("ltchkmark"), Literal)
                Dim hledit As HyperLink = CType(row.FindControl("hledit"), HyperLink)
                Dim lnkdelete = DirectCast(row.FindControl("lnkdelete"), LinkButton)

                Dim ltaction = DirectCast(row.FindControl("ltaction"), Literal)
                Dim ltprevent = DirectCast(row.FindControl("ltprevent"), Literal)
                Dim ltextrnal = DirectCast(row.FindControl("ltextrnal"), Literal)
                Dim ltinternal = DirectCast(row.FindControl("ltinternal"), Literal)
                Dim ltfeedback = DirectCast(row.FindControl("ltfeedback"), Literal)
                Dim lkstatus = DirectCast(row.FindControl("lkstatus"), Label)

                If ltchkmark.Text = "True" Then
                    hledit.Visible = False
                    lnkdelete.Visible = False
                Else
                    hledit.Visible = True
                    lnkdelete.Visible = True
                End If

        
                If ltextrnal.Text = "" And ltinternal.Text = "" And ltaction.Text = "" And ltprevent.Text = "" And ltfeedback.Text = "" Then
                    lkstatus.Text = "Pending"
                    lkstatus.Attributes.Add("class", "pend")
                ElseIf ltextrnal.Text = "" Or ltinternal.Text = "" Or ltaction.Text = "" Or ltprevent.Text = "" Or ltfeedback.Text = "" Then
                    lkstatus.Text = "In Process"
                    lkstatus.Attributes.Add("class", "Place")
                ElseIf ltextrnal.Text <> "" And ltinternal.Text <> "" And ltaction.Text <> "" And ltprevent.Text <> "" And ltfeedback.Text <> "" Then
                    lkstatus.Text = "Complete"
                    lkstatus.Attributes.Add("class", "Complet")
                End If
            Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class
