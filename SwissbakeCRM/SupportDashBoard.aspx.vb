
Partial Class SupportDashBoard
    Inherits _PageBaseClass
    Dim Validate As Boolean

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            If Not Session("UserRoleID") = "4" Then
                Response.Redirect("index.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then


                GridView1.AllowCustomPaging = True
                Hfgridview.Value = "LeadGridviewByAssign"
                'hfsearch.Value = "SearchLeadByAssign"
                hftotalrecord.Value = "LeadTotalNumberOfRecord"

                'fillGrid()
                'CheckPrivilage()
                'Above Line For Passing Mode In Search Lead Control
                'SearchControl.Uhfadd.Visible = False
                'SearchControl.ULkadd.Visible = False
                'SearchControl.UbtnExportExcel.Visible = False
                'SearchControl.ULkadd.Visible = False
                If Not IsPostBack Then
                    fillDetail()
                Else
                    'Session("DUserId") = ddluser.SelectedValue
                    'fillLead("FillTopTenActivity")
                    'FillIndexCount()
                    'FillIndexCountNew()
                    'FillSalesTargetCount()
                    'fillPending()
                End If
                'fillLead()
                lblusername.Text = Session("UName")
            End If
            ClientScript.RegisterStartupScript([GetType](), "Javascript", "Temp();", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Activity", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub fillDetail()
        Try
            Dim ds As DataSet = SupportBLL.SupportTotalNumberOfComplaint()
           
            lblSwissComplaint.Text = ds.Tables(0).Rows(0)(0).ToString
            If lblSwissComplaint.Text = "0" Then
                divnewComplaint.Attributes.Remove("class")
                'divnewComplaint.Attributes.Add("class", "col-sm-4")
                divnewComplaint.Attributes.Add("class", "col-sm-3")
            Else
                'divnewComplaint.Attributes.Add("class", "col-sm-4 animation-pulse")
                divnewComplaint.Attributes.Add("class", "col-sm-3 animation-pulse")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub fillGrid()
        Try
            ' GridView1.PageSize = ddlPaging.SelectedValue
            Dim dsA As DataSet = AccountBLL.SupportAccGridviewByPara("SupportAccGridviewByPara", txtCode.Text, txtName.Text, txtCompany.Text, txtMobile.Text,
                                                                       txtEmail.Text, txtOrderCode.Text, txtInvNo.Text, txtTracking.Text)
            'GridView1.VirtualItemCount = AccountBLL.SupportAccTotalNumberOfRecord("SupportAccTotalNumberOfRecord", txtCode.Text, txtName.Text, txtCompany.Text,
            '                                                                      txtMobile.Text, txtEmail.Text, txtOrderCode.Text, txtInvNo.Text, txtTracking.Text)
            GridView1.VirtualItemCount = dsA.Tables(0).Rows.Count
            ' GridView1.VirtualItemCount = MainBLL.TotalRowInGridviewBYID(hftotalrecord.Value, Session("UserId"))
            GridView1.DataSource = dsA.Tables(0)

            'GridView1.DataSource = AccountBLL.SupportAccGridviewByPara("SupportAccGridviewByPara", txtCode.Text, txtName.Text, txtCompany.Text, txtMobile.Text,
            '                                                           txtEmail.Text, txtOrderCode.Text, txtInvNo.Text, txtTracking.Text)
            'GridView1.DataSource = AccountBLL.SupportAccGridviewByPara("SupportAccGridviewByPara", txtCode.Text, txtName.Text, txtCompany.Text, txtMobile.Text, txtEmail.Text, GridView1.PageIndex, ddlPaging.SelectedValue)
            'GridView1.DataSource = MainBLL.FillGridViewById("0", SearchControl.Uddpagesize.SelectedValue, Session("UserId"), Hfgridview.Value)

            GridView1.DataBind()

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Lead", "fillGrid", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            'Dim dt As DataSet = GridView1.DataSource
            'Dim dtUser As New DataTable
            'dtUser = dt.Tables(0)
            'Dim drLogin As DataRow
            'drLogin = dtUser.Rows(sender)
            'Dim AccType As String = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Type").ToString())

            ''For Each row As GridViewRow In GridView1.Rows
            ''For i As Integer = 0 To dtUser.Rows.Count - 1
            'Dim HypLnkType As HyperLink = CType(e.Row.FindControl("HypLnkType"), HyperLink)
            'Dim lbluId As Literal = DirectCast(e.Row.FindControl("lbluId"), Literal)
            'If AccType = "Prospect" Then
            '    HypLnkType.NavigateUrl = "Viewprospect.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(lbluId.Text).ToString())
            'Else
            '    HypLnkType.NavigateUrl = "ViewAccount.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(lbluId.Text).ToString())
            'End If
            ''Next
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btndashboard_Click(sender As Object, e As EventArgs) Handles btndashboard.Click
        Try
            If Validate = True Then
                GridView1.Visible = True
                fillGrid()
            Else
                GridView1.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs)
        SetSortDirection(SortDireaction)
        Try
            Dim dt As DataSet
            Dim DataTable As DataTable
            'If Hfsearchcheck.Value = "True" Then
            '    dt = AccountBLL.SupportAccGridviewByPara("SupportAccGridviewByPara", ddlType.SelectedValue, txtName.Text, txtCompany.Text, txtMobile.Text, txtEmail.Text)
            '    DataTable = dt.Tables(0)
            '    ' DataTable = CustomsReport.SearchCustomReport(hfsearchquery.Value)
            'Else
            'If Request.QueryString("Type") = Nothing Then
            '    dt = LeadBLL.LeadSortingByAssign(Session("UserId"))
            '    DataTable = dt.Tables(0)
            'Else
            '    Dim temp As String = Request.QueryString("Type")
            '    If temp = "zhtqu" Then
            '        dt = LeadBLL.LeadAchivedSorting(Session("UserId"))
            '        DataTable = dt.Tables(0)
            '    Else
            '        dt = LeadBLL.SortingLeadWithNoActivity(Session("UserId"))
            '        DataTable = dt.Tables(0)
            '    End If
            'End If
            'End If
            dt = AccountBLL.SupportAccGridviewByPara("SupportAccGridviewByPara", txtCode.Text, txtName.Text, txtCompany.Text, txtMobile.Text, txtEmail.Text,
                                                     txtOrderCode.Text, txtInvNo.Text, txtTracking.Text)
            'dt = AccountBLL.SupportAccGridviewByPara("SupportAccGridviewByPara", txtCode.Text, txtName.Text, txtCompany.Text, txtMobile.Text, txtEmail.Text, GridView1.PageIndex, ddlPaging.SelectedValue)
            DataTable = dt.Tables(0)
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
            ExecptionBLL.Insert("Lead", "GridView1_Sorting", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            GridView1.PageIndex = e.NewPageIndex
            fillGrid()
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Lead", "GridView1_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Sub AtLeastOneContact_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        'If txtCode.Text & txtName.Text & txtCompany.Text & txtEmail.Text & txtMobile.Text <> "" Then
        If txtCode.Text <> "" Or txtName.Text <> "" Or txtCompany.Text <> "" Or txtEmail.Text <> "" Or txtMobile.Text <> "" Or txtOrderCode.Text <> "" Or txtInvNo.Text <> "" Or txtTracking.Text <> "" Then
            'If txtCode.Text IsNot Nothing And txtName.Text IsNot Nothing And txtCompany.Text IsNot Nothing And txtEmail.Text IsNot Nothing And txtMobile.Text IsNot Nothing Then
            args.IsValid = True
            Validate = True
        Else
            args.IsValid = False
            Validate = False
        End If
    End Sub

End Class
