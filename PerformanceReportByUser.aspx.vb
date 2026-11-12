
Partial Class PerformanceReportByUser
    Inherits System.Web.UI.Page
    Private button1WasClicked As Boolean = False

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim tempDate As Date = Date.Now.ToString("yyyy-MM-dd")
            Dim startOfMonth As New DateTime(tempDate.Year, tempDate.Month, 1)
            Dim endOfMonth As DateTime = startOfMonth.AddMonths(1).AddDays(-1)
            FillUserType()
            txtstartdate.Text = startOfMonth.ToString("yyyy-MM-dd")
            txtenddate.Text = endOfMonth.ToString("yyyy-MM-dd")
            ' FillUser()
            FillIndexCount()
            PercentageFillIndexCount()
        End If
    End Sub

    Public Sub FillUser()
        Try

            'rplead.DataSource = MainBLL.Dropdown("UserDropDown")
            'rplead.DataBind()

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SalesPerformanceReportByUser", "FillUser", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    'Public Sub FillUserName()
    '    Try
    '        Dim ds As DataSet = MainBLL.DropdownWithID("UserAssignDropDown", Session("UserId"))
    '        ddluser.DataSource = ds.Tables(0)
    '        ddluser.DataTextField = "U_FirstName"
    '        ddluser.DataValueField = "U_ID"
    '        ddluser.DataBind()
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert("ModifyUser", "FillUserName", error1, Session("UserId"))
    '        'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '        Throw ex
    '    End Try
    'End Sub
    Public Sub FillUser1()
        Try

            'rplead.DataSource = MainBLL.DropdownByuser("UserDropDown1", ddusertype.SelectedValue)
            'rplead.DataBind()

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SalesPerformanceReportByUser", "FillUser", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillUserType()
        Try

            ddusertype.DataSource = MainBLL.Dropdown("UserDropDown")
            ddusertype.DataTextField = "U_FirstName"
            ddusertype.DataValueField = "U_ID"
            ddusertype.DataBind()

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SalesPerformanceReportByUser", "FillUser", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub


    Protected Sub btnreport_Click(sender As Object, e As EventArgs) Handles btnreport.Click
        Try
            button1WasClicked = True
            'FillUser1()
            FillIndexCount()
            PercentageFillIndexCount()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub FillIndexCount()
        Try
            ' Dim ds As DataSet = DashBoardBLL.Count("ReportbyUser", Session("DUserId"), txtstartdate.Text, txtenddate.Text)
            'If ds.Tables.Count > 0 Then
            '    taskPerform.Text = ds.Tables(0).Rows(0)(0).ToString
            '    taskMissed.Text = ds.Tables(1).Rows(0)(0).ToString()
            '    taskClose.Text = ds.Tables(2).Rows(0)(0).ToString()
            '    '  taskTotal.Text = ds.Tables(1).Rows(0)(0).ToString()
            '    demoPerform.Text = ds.Tables(3).Rows(0)(0).ToString()
            '    demoMissed.Text = ds.Tables(1).Rows(0)(0).ToString
            '    demoClose.Text = ds.Tables(4).Rows(0)(0).ToString
            '    '  demoTotal.Text = ds.Tables(9).Rows(0)(0).ToString()
            '    phonePerform.Text = ds.Tables(5).Rows(0)(0).ToString()
            '    phoneMissed.Text = ds.Tables(1).Rows(0)(0).ToString
            '    phoneClose.Text = ds.Tables(6).Rows(0)(0).ToString
            '    '  phoneTotal.Text = Convert.ToDouble(ds.Tables(10).Rows(0)(0).ToString).ToString("#,##0.00")
            'End If

            taskPerform.Text = CountBLL.ReportbyUser("taskperform", ddusertype.SelectedValue.ToString, txtstartdate.Text, txtenddate.Text)
            taskMissed.Text = CountBLL.ReportbyUser("missedtask", ddusertype.SelectedValue.ToString, txtstartdate.Text, txtenddate.Text)
            taskClose.Text = CountBLL.ReportbyUser("taskclose", ddusertype.SelectedValue.ToString, txtstartdate.Text, txtenddate.Text)
            taskTotal.Text = Convert.ToDouble(Convert.ToInt32(taskPerform.Text) + Convert.ToInt32(taskMissed.Text) + Convert.ToInt32(taskClose.Text)).ToString

            demoPerform.Text = CountBLL.ReportbyUser("performdemo", ddusertype.SelectedValue.ToString, txtstartdate.Text, txtenddate.Text)
            demoMissed.Text = CountBLL.ReportbyUser("misseddemo", ddusertype.SelectedValue.ToString, txtstartdate.Text, txtenddate.Text)
            demoClose.Text = CountBLL.ReportbyUser("democlose", ddusertype.SelectedValue.ToString, txtstartdate.Text, txtenddate.Text)
            demoTotal.Text = Convert.ToDouble(Convert.ToInt32(demoPerform.Text) + Convert.ToInt32(demoMissed.Text) + Convert.ToInt32(demoClose.Text)).ToString

            phonePerform.Text = CountBLL.ReportbyUser("performcall", ddusertype.SelectedValue.ToString, txtstartdate.Text, txtenddate.Text)
            phoneMissed.Text = CountBLL.ReportbyUser("missedcall", ddusertype.SelectedValue.ToString, txtstartdate.Text, txtenddate.Text)
            phoneClose.Text = CountBLL.ReportbyUser("phoneclose", ddusertype.SelectedValue.ToString, txtstartdate.Text, txtenddate.Text)
            phoneTotal.Text = Convert.ToDouble(Convert.ToInt32(phonePerform.Text) + Convert.ToInt32(phoneMissed.Text) + Convert.ToInt32(phoneClose.Text)).ToString

            totalPerform.Text = Convert.ToDouble(Convert.ToInt32(taskPerform.Text) + Convert.ToInt32(demoPerform.Text) + Convert.ToInt32(phonePerform.Text)).ToString
            totalkMissed.Text = Convert.ToDouble(Convert.ToInt32(taskMissed.Text) + Convert.ToInt32(demoMissed.Text) + Convert.ToInt32(phoneMissed.Text)).ToString
            totalClose.Text = Convert.ToDouble(Convert.ToInt32(taskClose.Text) + Convert.ToInt32(demoClose.Text) + Convert.ToInt32(phoneClose.Text)).ToString

            totalTotal.Text = Convert.ToDouble(Convert.ToInt32(totalPerform.Text) + Convert.ToInt32(totalkMissed.Text) + Convert.ToInt32(totalClose.Text)).ToString


        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Index.aspx", "FillIndexCount", error1, Session("UserId"))
            Throw ex
        End Try
    End Sub

    Public Sub PercentageFillIndexCount()
        Try
            'Dim ds As DataSet = CountBLL.perReportbyUser("perReportbyUser", ddusertype.SelectedValue.ToString, txtstartdate.Text, txtenddate.Text)
            'If ds.Tables.Count > 0 Then


            pertaskPerform.Text = Convert.ToDouble(taskPerform.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"
            pertaskMissed.Text = Convert.ToDouble(taskMissed.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"
            pertaskClose.Text = Convert.ToDouble(taskClose.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"

            pertaskTotal.Text = Convert.ToDouble(taskTotal.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"


            perdemoPerform.Text = Convert.ToDouble(demoPerform.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"
            perdemoMissed.Text = Convert.ToDouble(demoMissed.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"
            perdemoClose.Text = Convert.ToDouble(demoClose.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"

            perdemoTotal.Text = Convert.ToDouble(demoTotal.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"


            perphonePerform.Text = Convert.ToDouble(phonePerform.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"
            perphoneMissed.Text = Convert.ToDouble(phoneMissed.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"
            perphoneClose.Text = Convert.ToDouble(phoneClose.Text / phoneTotal.Text * 100).ToString("#,##0.00") + "%"

            perphoneTotal.Text = Convert.ToDouble(phoneTotal.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"

            pertotalPerform.Text = Convert.ToDouble(totalPerform.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"
            pertotalkMissed.Text = Convert.ToDouble(totalkMissed.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"
            pertotalClose.Text = Convert.ToDouble(totalClose.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"


        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Index.aspx", "FillIndexCount", error1, Session("UserId"))
            Throw ex
        End Try
    End Sub

    Protected Sub btnshow_Click(sender As Object, e As EventArgs) Handles btnshow.Click
        Response.Redirect("PerformanceReportByUser.aspx")
    End Sub

    'Protected Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
    '    Try
    '        Response.Clear()
    '        Response.Buffer = True
    '        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls")
    '        Response.Charset = ""
    '        Response.ContentType = "application/vnd.ms-excel"
    '        Dim sw As New StringWriter()
    '        Dim hw As New HtmlTextWriter(sw)
    '        rplead.RenderControl(hw)
    '        Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
    '        Response.Write(style)
    '        Response.Output.Write(sw.ToString())
    '        Response.Flush()
    '        Response.End()


    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert("SearchControlWithId", "btnExportExcel_Click", error1, Session("UserId"))
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub
End Class
