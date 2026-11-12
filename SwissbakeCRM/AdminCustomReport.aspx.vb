
Partial Class AdminCustomReport
    Inherits System.Web.UI.Page
    Dim addrowtype As New Label
    Dim Count As Integer = 0

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            Dim rightSelectedItems As String = Request.Form(lstRight.UniqueID)
            Dim strNames As New List(Of String)
            lstRight.Items.Clear()
            Dim Temp As String = ""
            If Not String.IsNullOrEmpty(rightSelectedItems) Then
                For Each item As String In rightSelectedItems.Split(",")
                    Dim input As String = item
                    item = input.Split("."c).Last()
                    lstRight.Items.Add(item)
                    strNames.Add(item)
                Next
                Temp = String.Join(",", strNames)
            End If
            Dim Query As String = "SELECT distinct " + Temp + " FROM " + ddmodule.SelectedValue
            Dim CustomID As Integer = CustomsReport.Insert(txtreportname.Text.Trim, ddmodule.SelectedValue, txtdesc.Text.Trim, Temp, Query, Session("UserId"), Session("UserId"), ddreporttype.SelectedValue)
            Count = CustomsReport.MaxCustomID()
            Dim LogOperatorText As String = ""
            Dim LogOperator As String = ""
            Dim FieldName As String = ""
            Dim sb As New StringBuilder
            sb.Append("<root>")
            For i As Integer = 0 To GridView1.Rows.Count - 1
                Dim ddlogoperator As DropDownList = DirectCast(GridView1.Rows(i).FindControl("ddlogoperator"), DropDownList)
                Dim ddfieldname As DropDownList = DirectCast(GridView1.Rows(i).FindControl("ddfieldname"), DropDownList)
                Dim ddoperator As DropDownList = DirectCast(GridView1.Rows(i).FindControl("ddoperator"), DropDownList)
                Dim input As String = ddfieldname.SelectedValue
                LogOperator = input.Split("."c).First()
                If i = 0 Then
                    LogOperatorText = ""
                Else
                    LogOperatorText = ddlogoperator.SelectedValue
                End If
                sb.Append("<row CustomReportDt_Id='" & Count.ToString & "' CustomReportDt_ReportId='" & CustomID & "' CustomReportDt_LogOperator='" & LogOperatorText.ToString &
                            "' CustomReportDt_FieldName='" & ddfieldname.SelectedItem.Text & "' CustomReportDt_Operator='" & ddoperator.SelectedValue.Trim &
                           "' CustomReportDt_CreatedDate='" & DateAndTime.DateString &
                          "' CustomReportDt_ModifiedDate='" & DateAndTime.DateString &
                          "' CustomReportDt_DataType='" & LogOperator.ToString & "' />")
                Count = Count + 1
            Next
            sb.Append("</root>")
            If GridView1.Rows.Count >= 1 Then
                CustomsReport.XMLInsert(sb.ToString, Session("Audlog_Id"))
            End If
            Response.Redirect("MainCustomReport.aspx")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AdminCustomReport", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            'Throw ex
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                GridView1.DataSource = ""
                GridView1.DataBind()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AdminCustomReport", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddmodule_TextChanged(sender As Object, e As EventArgs) Handles ddmodule.TextChanged
        Try
            lstLeft.DataSource = CustomsReport.ViewColoumName(ddmodule.SelectedValue)
            lstLeft.DataTextField = "COLUMN_NAME"
            lstLeft.DataValueField = "DATA_TYPE"
            lstLeft.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AdminCustomReport", "ddmodule_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            'Throw ex
        End Try
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "AddNewRow" Then
                AddNewRow()
            ElseIf e.CommandName = "Add" Then
                FirstGridViewRow1()
            ElseIf e.CommandName = "deletelink" Then
                If ViewState("NewTable") IsNot Nothing Then
                    Dim dt As DataTable = DirectCast(ViewState("NewTable"), DataTable)
                    Dim drCurrentRow As DataRow = Nothing
                    Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
                    If dt.Rows.Count > 0 Then
                        dt.Rows.Remove(dt.Rows(rowIndex))
                        drCurrentRow = dt.NewRow()
                        ViewState("NewTable") = dt
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                        For i As Integer = 0 To GridView1.Rows.Count - 2
                            GridView1.Rows(i).Cells(0).Text = Convert.ToString(i + 1)
                        Next
                    End If
                End If
                SetPreviousData1()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AdminCustomReport", "GridView1_RowCommand", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            'Throw ex
        End Try
    End Sub

    Private Sub FirstGridViewRow1()
        Try
            Dim dt As New DataTable()
            Dim dr As DataRow = Nothing
            dt.Columns.Add(New DataColumn("RowNumber", GetType(String)))
            dt.Columns.Add(New DataColumn("ddlogoperator", GetType(String)))
            dt.Columns.Add(New DataColumn("ddfieldname", GetType(String)))
            dt.Columns.Add(New DataColumn("ddoperator", GetType(String)))
            dt.Columns.Add(New DataColumn("lnkdelete", GetType(String)))
            dr = dt.NewRow()
            dr("RowNumber") = 1
            dr("ddlogoperator") = String.Empty
            dr("ddfieldname") = String.Empty
            dr("ddoperator") = String.Empty
            dr("lnkdelete") = String.Empty
            dt.Rows.Add(dr)
            ViewState("NewTable") = dt
            GridView1.DataSource = dt
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AdminCustomReport", "FillOwner", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Private Sub AddNewRow()
        Try
            Dim rowIndex As Integer = 0
            addrowtype.Text = "NEW"
            If ViewState("NewTable") IsNot Nothing Then
                Dim dtCurrentTable As DataTable = DirectCast(ViewState("NewTable"), DataTable)
                Dim drCurrentRow As DataRow = Nothing
                If dtCurrentTable.Rows.Count > 0 Then
                    For i As Integer = 1 To dtCurrentTable.Rows.Count
                        Dim ddlogoperator As DropDownList = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("ddlogoperator"), DropDownList)
                        Dim ddfieldname As DropDownList = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("ddfieldname"), DropDownList)
                        Dim ddoperator As DropDownList = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("ddoperator"), DropDownList)
                        Dim ddvalues As LinkButton = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("lnkdelete"), LinkButton)
                        drCurrentRow = dtCurrentTable.NewRow()
                        drCurrentRow("RowNumber") = i + 1
                        dtCurrentTable.Rows(i - 1)("ddlogoperator") = ddlogoperator.SelectedValue
                        dtCurrentTable.Rows(i - 1)("ddfieldname") = ddfieldname.SelectedValue
                        dtCurrentTable.Rows(i - 1)("ddoperator") = ddoperator.SelectedValue
                        rowIndex += 1
                    Next
                    dtCurrentTable.Rows.Add(drCurrentRow)
                    ViewState("NewTable") = dtCurrentTable
                    GridView1.DataSource = dtCurrentTable
                    GridView1.DataBind()
                End If
            Else
                Response.Write("ViewState is null")
            End If
            SetPreviousData1()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AdminCustomReport", "AddNewRow", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Private Sub SetPreviousData1()
        Try
            Dim rowIndex As Integer = 0
            If ViewState("NewTable") IsNot Nothing Then
                Dim dt As DataTable = DirectCast(ViewState("NewTable"), DataTable)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim ddlogoperator As DropDownList = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("ddlogoperator"), DropDownList)
                        Dim ddfieldname As DropDownList = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("ddfieldname"), DropDownList)
                        Dim ddoperator As DropDownList = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("ddoperator"), DropDownList)
                        Dim ddvalues As LinkButton = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("lnkdelete"), LinkButton)
                        GridView1.Rows(i).Cells(0).Text = Convert.ToString(i + 1)
                        ddlogoperator.SelectedValue = dt.Rows(i)("ddlogoperator").ToString()
                        ddoperator.SelectedValue = dt.Rows(i)("ddoperator").ToString()
                        ddfieldname.SelectedValue = dt.Rows(i)("ddfieldname").ToString()
                        rowIndex += 1
                    Next
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AdminCustomReport", "SetPreviousData1", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim ddattribute As DropDownList = DirectCast(e.Row.FindControl("ddfieldname"), DropDownList)
                ddattribute.DataSource = CustomsReport.ViewColoumName(ddmodule.SelectedValue)
                ddattribute.DataTextField = "COLUMN_NAME"
                ddattribute.DataValueField = "DATA_TYPE"
                ddattribute.DataBind()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AdminCustomReport", "GridView1_RowDataBound", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            'Throw ex
        End Try
    End Sub
End Class
