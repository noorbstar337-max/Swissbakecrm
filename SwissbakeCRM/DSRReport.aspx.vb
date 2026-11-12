
Partial Class DSRReport
    Inherits System.Web.UI.Page
    Dim MainID As Integer

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            If Not IsPostBack Then
                'Dim tempDate As Date = Date.Now.AddMonths(-1).ToString("yyyy-MM-dd")
                Dim tempDate As Date = Date.Now.ToString("yyyy-MM-dd")
                Dim startOfMonth As New DateTime(tempDate.Year, tempDate.Month, 1)
                'Dim endOfMonth As DateTime = startOfMonth.AddMonths(1).AddDays(-1)
                Dim endOfMonth As DateTime = Date.Now.ToString("yyyy-MM-dd")
                txtfrom.Text = startOfMonth.ToString("yyyy-MM-dd")
                txtto.Text = endOfMonth.ToString("yyyy-MM-dd")

                'pnldemo.Visible = False
                ' btndashboard_Click(New Object(), New EventArgs())
                FillddlUser()
                FillddlCompany()
                ddlUser_SelectedIndexChanged(Nothing, Nothing)
                'ddlCompany_SelectedIndexChanged(Nothing, Nothing)
                'fillgridview()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("DSRReport", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
#Region "FillDropdowns"

    Public Sub FillddlUser()
        Try
            'MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim ds As DataSet
            ' If MainID = 0 Then
            ds = reportBLL.UserDropdown("UserDropDown")
            ddlUser.DataSource = ds.Tables(0)
            ddlUser.DataTextField = "Name"
            ddlUser.DataValueField = "ID"
            ddlUser.DataBind()
            ddlUser.Items.Insert(0, New ListItem("All", "0"))
            FillddlCompany()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")

            Throw ex
        End Try
    End Sub
    Public Sub FillddlCompany()
        Try
            Dim ds As DataSet
            If ddlUser.SelectedValue = 0 Then
                ds = reportBLL.CompanyDropdownById("CompanyDropDown", 1)
            Else
                ds = reportBLL.CompanyDropdownById("CompanyDropDown", ddlUser.SelectedValue)
            End If
            ddlCompany.DataSource = ds.Tables(0)
            ddlCompany.DataTextField = "Acc_Name"
            ddlCompany.DataValueField = "ID"
            ddlCompany.DataBind()
            ddlCompany.Items.Insert(0, New ListItem("All", "0"))

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")

            Throw ex
        End Try
    End Sub
#End Region

    Public Sub fillgridview()
        Try
            Dim UserID1 As Integer
            UserID1 = ddlUser.SelectedValue
            Dim str As String = ddlCompany.SelectedValue
            Dim strArr() As String
            strArr = str.Split("-")
            Dim CompanyID As Integer = strArr(0)
            Dim Type As String
            If CompanyID <> 0 Then
                Type = strArr(1)
            Else
                Type = "type"
            End If
            rpgridview.DataSource = reportBLL.FillDSRReport(UserID1, CompanyID, Type, txtfrom.Text, txtto.Text, "DSRReportViewNew")
            rpgridview.DataBind()
            If rpgridview.Items.Count > 0 Then
                tblGrid.Visible = True
            Else
                tblGrid.Visible = False
            End If
            rrtotal.DataSource = reportBLL.FillDSRReport(UserID1, CompanyID, Type, txtfrom.Text, txtto.Text, "DSRReportViewNew").Tables(1)
            rrtotal.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            'ExecptionBLL.Insert("Activity", "fillLead", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try

    End Sub

    Protected Sub ddlUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlUser.SelectedIndexChanged
        Try
            FillddlCompany()
            fillgridview()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            'ExecptionBLL.Insert("Activity", "fillLead", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddlCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCompany.SelectedIndexChanged
        Try
            fillgridview()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            'ExecptionBLL.Insert("Activity", "fillLead", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btndashboard_Click(sender As Object, e As EventArgs) Handles btndashboard.Click
        Try
            fillgridview()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            'ExecptionBLL.Insert("Activity", "fillLead", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    'Protected Sub btnExportExcel_Click(sender As Object, e As ImageClickEventArgs) Handles btnExportExcel.Click
    '    Try
    '        Response.Clear()
    '        Response.Buffer = True
    '        Response.AddHeader("content-disposition", "attachment;filename=" + ddlUser.SelectedItem.Text + ".xls")
    '        Response.Charset = ""
    '        Response.ContentType = "application/vnd.ms-excel"
    '        Dim sw As New StringWriter()
    '        Dim hw As New HtmlTextWriter(sw)

    '        Dim GRD As New GridView

    '        Dim UserID1 As Integer
    '        If ddlUser.SelectedValue = 0 Then
    '            UserID1 = 1
    '        Else
    '            UserID1 = ddlUser.SelectedValue
    '        End If
    '        Dim str As String = ddlCompany.SelectedValue
    '        Dim strArr() As String
    '        strArr = str.Split("-")
    '        Dim CompanyID As Integer = strArr(0)
    '        Dim Type As String
    '        If CompanyID <> 0 Then
    '            Type = strArr(1)
    '        Else
    '            Type = "None"
    '        End If

    '        GRD.DataSource = reportBLL.FillDSRReport(UserID1, CompanyID, Type, txtfrom.Text, txtto.Text, "DSRReportViewExcel").Tables(0)
    '        GRD.DataBind()
    '        GRD.AllowPaging = False
    '        GRD.DataBind()
    '        GRD.RenderControl(hw)
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

	Private Sub rrtotal_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rrtotal.ItemDataBound
        Try
            Dim UserID1 As Integer
            'If ddlUser.SelectedValue = 0 Then
            '    UserID1 = 1
            'Else
            UserID1 = ddlUser.SelectedValue
            'End If
            Dim str As String = ddlCompany.SelectedValue
            Dim strArr() As String
            strArr = str.Split("-")
            Dim CompanyID As Integer = strArr(0)
            Dim Type As String
            If CompanyID <> 0 Then
                Type = strArr(1)
            Else
                Type = "type"
            End If
            Dim litname As Literal = TryCast(e.Item.FindControl("litname"), Literal)
            Dim rrtotalin As Repeater = TryCast(e.Item.FindControl("rrtotalin"), Repeater)
            rrtotalin.DataSource = reportBLL.FillDSRReport(UserID1, CompanyID, Type, txtfrom.Text, txtto.Text, "DSRReportViewtotal", litname.Text).Tables(0)
            rrtotalin.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            'ExecptionBLL.Insert("SearchControlWithId", "btnExportExcel_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
	End Sub

    Protected Sub rpgridview_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rpgridview.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item AndAlso e.Item.ItemType <> ListItemType.AlternatingItem Then Return
        Dim tdOwner1 = e.Item.FindControl("tdOwner1")
        If ddlUser.SelectedValue = 0 Then
            tdOwner.Visible = True
            tdOwner1.Visible = True
        Else
            tdOwner.Visible = False
            tdOwner1.Visible = False
        End If
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try

            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=DSR Report.xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            Dim Gridview2 As New GridView

            Dim dt As New DataSet()
            'dt = MainBLL.SearchGridViewByID(txtSearch.Text.Trim, Session("UserId"), hfExcel.Value)
            Dim UserID1 As Integer
            UserID1 = ddlUser.SelectedValue
            Dim str As String = ddlCompany.SelectedValue
            Dim strArr() As String
            strArr = str.Split("-")
            Dim CompanyID As Integer = strArr(0)
            Dim Type As String
            If CompanyID <> 0 Then
                Type = strArr(1)
            Else
                Type = "type"
            End If
            dt = reportBLL.FillDSRReport(UserID1, CompanyID, Type, txtfrom.Text, txtto.Text, "DSRReportViewNew")
       
            Dim dtExc As DataTable = dt.Tables(0)
            dtExc.Columns.Remove("ID")
            dtExc.Columns.Remove("Activity_RelatedTypeID")
            dtExc.Columns.Remove("To")
            dtExc.Columns.Remove("Priority")
            dtExc.Columns.Remove("Status")
            dtExc.Columns.Remove("Activity Type")
            dtExc.Columns("RowNumber").ColumnName = "Sr No."
            dtExc.Columns("From").ColumnName = "Date"
            dtExc.Columns("City").ColumnName = "City"
            dtExc.Columns("Related Type").ColumnName = "Type"
            dtExc.Columns("Name").ColumnName = "Name"
            dtExc.Columns("Subject").ColumnName = "Subject"
            dtExc.Columns("Activity_Description").ColumnName = "Description"
            dtExc.Columns("Duration").ColumnName = "Time"
            dtExc.Columns("AssignTo").ColumnName = "Owner"
            'For Each dr As DataRow In dtExc.Rows
            '    dr.Item("Date") = dr.Item("Date").ToString().Replace("₹", "")
            'Next
            dtExc.Columns("Date").SetOrdinal(1)
            dtExc.Columns("City").SetOrdinal(2)
            dtExc.Columns("Description").SetOrdinal(6)

            Gridview2.DataSource = dtExc
            'Gridview2.DataBind()
            Gridview2.AllowPaging = False
            Gridview2.DataBind()
            Gridview2.RenderControl(hw)

            'style to format numbers to string
            Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
            Response.Write(style)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.End()
            ' ''Dim html2 As String = Regex.Replace(sw.ToString(), "(<img\/?[^>]+>)", "", RegexOptions.IgnoreCase)
            '' ''html2 = Regex.Replace(html2, "(<input class=""checkbox""\/?[^>]+>)", "", RegexOptions.IgnoreCase)
            ' ''html2 = Regex.Replace(html2, "(<a \/?[^>]+>)", "", RegexOptions.IgnoreCase)
            ' ''html2 = Regex.Replace(html2, "(<i \/?[^>]+>)", "(INR)", RegexOptions.IgnoreCase)
            ' ''Response.Write(html2.ToString())
            ' ''Response.Flush()
            ' ''Response.End()

            'DoValidate.closeConn(_conn)

        Catch ex As Exception

        End Try
    End Sub
End Class
