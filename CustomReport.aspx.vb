
Partial Class CustomReport
    Inherits System.Web.UI.Page
    Dim addrowtype As New Label
    Dim Count As Integer = 0
    Dim Mainid As Integer
    Dim Gridid As Integer
    Dim ds1 As DataSet
    Public count1 As Integer

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            Mainid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If Mainid = 0 Then
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
            Else

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
                Dim CustomID As Integer = CustomsReport.UpdateReport(txtreportname.Text.Trim, ddmodule.SelectedValue, txtdesc.Text.Trim, Temp, Query, Session("UserId"), ddreporttype.SelectedValue, Mainid)
                CustomsReport.DeleteReport(Mainid, "DeleteReport")
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
                    sb.Append("<row CustomReportDt_Id='" & Count.ToString & "' CustomReportDt_ReportId='" & Mainid & "' CustomReportDt_LogOperator='" & LogOperatorText.ToString &
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
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("CustomReport", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            'Throw ex
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                ViewState("count") = 0
                If Request.QueryString("Id") = Nothing Then
                    Response.Redirect("index.aspx")
                Else
                    Mainid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                    If Mainid = 0 Then
                        GridView1.DataSource = ""
                        GridView1.DataBind()
                    Else
                        Dim dt As DataSet = MainBLL.ViewByID(Mainid, "ViewCustomReport")
                        Dim dtUser As New DataTable
                        dtUser = dt.Tables(0)
                        If dtUser.Rows.Count > 0 Then
                            Dim drLogin As DataRow
                            drLogin = dtUser.Rows(0)
                            txtreportname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustomReport_Name"))
                            ddmodule.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustomReport_TableName").ToString)
                            ddmodule_TextChanged(Nothing, Nothing)
                            txtdesc.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustomReport_Description").ToString)
                            ddreporttype.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustomReport_Type"))
                            Dim str As String = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustomReport_SelectedFields").ToString())
                            Dim strArr() As String
                            strArr = str.Split(",")
                            lstRight.DataSource = strArr
                            lstRight.DataBind()
                        End If
                        ds1 = MainBLL.ViewByID(Mainid, "FillCustomreportDT")
                        Dim dt12 As DataTable = ds1.Tables(0)
                        If ViewState("NewTable") Is Nothing Then
                            ViewState("NewTable") = dt12
                        End If
                        GridView1.DataSource = ds1
                        GridView1.DataBind()
                    End If
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("CustomReport", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddmodule_TextChanged(sender As Object, e As EventArgs) Handles ddmodule.TextChanged
        Try
            If ViewState("count") <= 0 Then
                lstLeft.DataSource = CustomsReport.ViewColoumName(ddmodule.SelectedValue)
                lstLeft.DataTextField = "COLUMN_NAME"
                lstLeft.DataValueField = "DATA_TYPE"
                lstLeft.DataBind()
                ViewState("count") = 1
            Else
                lstLeft.DataSource = CustomsReport.ViewColoumName(ddmodule.SelectedValue)
                lstLeft.DataTextField = "COLUMN_NAME"
                lstLeft.DataValueField = "DATA_TYPE"
                lstLeft.DataBind()
                lstRight.Items.Clear()
                GridView1.DataSource = ""
                GridView1.DataBind()
            End If
           
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("CustomReport", "ddmodule_TextChanged", error1, Session("UserId"))
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
            ExecptionBLL.Insert("CustomReport", "GridView1_RowCommand", error1, Session("UserId"))
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
            ExecptionBLL.Insert("CustomReport", "FirstGridViewRow1", error1, Session("UserId"))
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
            ExecptionBLL.Insert("CustomReport", "AddNewRow", error1, Session("UserId"))
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
            ExecptionBLL.Insert("CustomReport", "SetPreviousData1", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim ddattribute As DropDownList = DirectCast(e.Row.FindControl("ddfieldname"), DropDownList)
                Dim ddlogoperator As DropDownList = DirectCast(e.Row.FindControl("ddlogoperator"), DropDownList)
                Dim ddoperator As DropDownList = DirectCast(e.Row.FindControl("ddoperator"), DropDownList)
                Dim ltlogoperator As Literal = DirectCast(e.Row.FindControl("ltlogoperator"), Literal)
                Dim ltdatatype As Literal = DirectCast(e.Row.FindControl("ltdatatype"), Literal)
                Dim ltoperator As Literal = DirectCast(e.Row.FindControl("ltoperator"), Literal)
                ddattribute.DataSource = CustomsReport.ViewColoumName(ddmodule.SelectedValue)
                ddattribute.DataTextField = "COLUMN_NAME"
                ddattribute.DataValueField = "DATA_TYPE"
                ddattribute.DataBind()
                Mainid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                If Mainid = 0 Then
                Else
                    ddlogoperator.SelectedValue = ltlogoperator.Text
                    ddoperator.SelectedValue = ltoperator.Text
                    ddattribute.SelectedValue = ltdatatype.Text
                End If

            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("CustomReport", "GridView1_RowDataBound", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            'Throw ex
        End Try
    End Sub

    'Protected Sub ddfieldname_TextChanged(sender As Object, e As EventArgs)
    '    Try
    '        Dim a1 As ListItem
    '        Dim a As Integer
    '        Dim strNames As New List(Of String)
    '        Dim Temp As String = ""
    '        For Each row As GridViewRow In GridView1.Rows
    '            Dim ddfieldname As DropDownList = DirectCast(row.FindControl("ddfieldname"), DropDownList)
    '            Dim ddoperator As DropDownList = DirectCast(row.FindControl("ddoperator"), DropDownList)
    '            If Not String.IsNullOrEmpty(ddfieldname.SelectedValue) Then
    '                For Each item As String In ddfieldname.SelectedValue.Split(",")
    '                    Dim input As String = item
    '                    item = input.Split("."c).First()
    '                    If item = "varchar" Then

    '                        If ddoperator.Items.Contains(New ListItem(">")) Then
    '                            a1 = ddoperator.Items.FindByValue(">")
    '                            a1.Enabled = False
    '                        End If
    '                        If ddoperator.Items.Contains(New ListItem("<")) Then
    '                            a1 = ddoperator.Items.FindByValue("<")
    '                            a1.Enabled = False
    '                        End If


    '                    End If


    '                Next
    '                Temp = String.Join(",", strNames)
    '            End If



    '        Next

    '    Catch ex As Exception

    '    End Try
    'End Sub

    Protected Sub lstRight_DataBound(sender As Object, e As EventArgs)
        Try
            Dim lb As ListBox = TryCast(sender, ListBox)
            Dim a As String
            Dim a1 As String
            For Each itemright As ListItem In lb.Items
                a1 = itemright.Text
                For Each itemleft As ListItem In lstLeft.Items

                    If itemleft.Text.Contains(a1) Then

                        itemleft.Enabled = False
                    End If
                Next
            Next
        Catch ex As Exception

        End Try
    End Sub


   
    Protected Sub hfcancel_Click(sender As Object, e As EventArgs) Handles hfcancel.Click
        Try
            Response.Redirect("MainCustomReport.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class
