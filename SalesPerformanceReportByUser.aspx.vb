
Partial Class SalesPerformanceReportByUser
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
            FillUser()
        End If
    End Sub

    Public Sub FillUser()
        Try
            
            rplead.DataSource = MainBLL.Dropdown("UserDropDown")
            rplead.DataBind()

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SalesPerformanceReportByUser", "FillUser", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillUser1()
        Try

            rplead.DataSource = MainBLL.DropdownByuser("UserDropDown1", ddusertype.SelectedValue)
            rplead.DataBind()

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

    Protected Sub rpsearch_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rplead.ItemDataBound
        If e.Item.ItemType = DataControlRowType.DataRow Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim ltid As Literal = CType(e.Item.FindControl("ltid"), Literal)
            Dim ltactive As Literal = CType(e.Item.FindControl("ltactive"), Literal)
            Dim ltlnew As Literal = CType(e.Item.FindControl("ltlnew"), Literal)
            Dim ltclose As Literal = CType(e.Item.FindControl("ltclose"), Literal)
            Dim ltopcount As Literal = CType(e.Item.FindControl("ltopcount"), Literal)
            Dim ltoprevenue As Literal = CType(e.Item.FindControl("ltoprevenue"), Literal)
            Dim ltquocount As Literal = CType(e.Item.FindControl("ltquocount"), Literal)
            Dim ltquoamount As Literal = CType(e.Item.FindControl("ltquoamount"), Literal)
            Dim ltordercount As Literal = CType(e.Item.FindControl("ltordercount"), Literal)
            Dim ltorderamount As Literal = CType(e.Item.FindControl("ltorderamount"), Literal)
            Dim dt As DataSet
            If button1WasClicked = True Then
                dt = MainBLL.ViewByDateID(ltid.Text, "SalesreportdateByID", txtstartdate.Text, txtenddate.Text)
            Else
                dt = MainBLL.ViewByID(ltid.Text, "SalesreportByID")
            End If

            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            ltactive.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead Active Count").ToString())
            ltlnew.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead New Count").ToString())
            ltclose.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead Close Count").ToString())
            ltoprevenue.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity Revenue").ToString())
            If ltoprevenue.Text = "" Then
            Else
                ltoprevenue.Text = Math.Round(CDbl(DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity Revenue").ToString())), 2)
            End If
            ltopcount.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity Count").ToString())
            ltquocount.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation Count").ToString())
            ltquoamount.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation Amount").ToString())
            If ltquoamount.Text = "" Then
            Else
                ltquoamount.Text = Math.Round(CDbl(DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation Amount").ToString())), 2)
            End If
            ltorderamount.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order Amount").ToString())
            If ltorderamount.Text = "" Then
            Else
                ltorderamount.Text = Math.Round(CDbl(DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order Amount").ToString())), 2)
            End If
            ltordercount.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order Count").ToString())
        End If
    End Sub

   
    Protected Sub btnreport_Click(sender As Object, e As EventArgs) Handles btnreport.Click
        Try
            button1WasClicked = True
            FillUser1()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnshow_Click(sender As Object, e As EventArgs) Handles btnshow.Click
        Response.Redirect("SalesPerformanceReportByUser.aspx")
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
