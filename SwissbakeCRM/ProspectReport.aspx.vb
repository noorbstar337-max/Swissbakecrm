
Imports System.Data

Partial Class ProspectReport
	Inherits System.Web.UI.Page
	Dim MainID As Integer
	Dim ContactID As Integer
	Dim RelatedID As Integer
	Dim ConatctType As String
	Dim RelatedType As String
	Dim returnurl As String
	Dim FormDate As String, FromTime As String, FromDateTime As String, billable As Boolean
	Dim toDate As String, Toime As String, ToDateTime As String
	Dim ReminderDate As String, Remindertime As String, Reminderdatetime As String, Reminder As Boolean

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
				FillddlUser()
				FillddlType()
				FillddlLeadName()
				FillddlSource()
				'-------------------------    ddlUser_SelectedIndexChanged(Nothing, Nothing)
				'ddlCompany_SelectedIndexChanged(Nothing, Nothing)
				'------------------------       ddlStatusStage_SelectedIndexChanged(Nothing, Nothing)
				fillgridview()
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
			FillddlLeadName()
		Catch ex As Exception
			Dim error1 As String = ex.Message.Replace(Chr(34), "")
			error1 = error1.Replace(Chr(39), "")

			Throw ex
		End Try
	End Sub
	Public Sub FillddlLeadName()
		Try
			Dim ds As DataSet
			If ddlUser.SelectedValue = 0 Then
				ds = reportBLL.ProspectDropdownById("ProspectDropDownById", 0)
			Else
				ds = reportBLL.ProspectDropdownById("ProspectDropDownById", ddlUser.SelectedValue)
			End If
			ddlProspectName.DataSource = ds.Tables(0)
			ddlProspectName.DataTextField = "Prospect_Name"
			ddlProspectName.DataValueField = "ID"
			ddlProspectName.DataBind()
			ddlProspectName.Items.Insert(0, New ListItem("All", "0"))

		Catch ex As Exception
			Dim error1 As String = ex.Message.Replace(Chr(34), "")
			error1 = error1.Replace(Chr(39), "")

			Throw ex
		End Try
	End Sub
	Public Sub FillddlSource()
		Try
			ddlSource.DataSource = MainBLL.Dropdown("SourceDropDown")
			ddlSource.DataTextField = "Source_Name"
			ddlSource.DataValueField = "Source_Id"
			ddlSource.DataBind()
			ddlSource.Items.Insert(0, New ListItem("All", "-1"))
		Catch ex As Exception
			Dim error1 As String = ex.Message.Replace(Chr(34), "")
			error1 = error1.Replace(Chr(39), "")
			ExecptionBLL.Insert("LeadReport", "FillddlSource", error1, Session("UserId"))
			'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
			Throw ex
		End Try
	End Sub

	Public Sub FillddlType()
		Try
			ddlType.DataSource = MainBLL.Dropdown("IndustryDropDown")
			ddlType.DataTextField = "Industry_Name"
			ddlType.DataValueField = "Industry_Id"
			ddlType.DataBind()
			ddlType.Items.Insert(0, New ListItem("All", "-1"))
		Catch ex As Exception
			Dim error1 As String = ex.Message.Replace(Chr(34), "")
			error1 = error1.Replace(Chr(39), "")
			ExecptionBLL.Insert("LeadReport", "FillddlSource", error1, Session("UserId"))
			'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
			Throw ex
		End Try
	End Sub
#End Region

	Public Sub fillgridview()
		Try
			rpgridview.DataSource = reportBLL.ProspectReportViewNew("ProspectreportView", txtfrom.Text, txtto.Text, ddlUser.SelectedValue, ddlProspectName.SelectedValue, ddlType.SelectedValue, ddlCategory.SelectedValue, ddlSource.SelectedValue)
			rpgridview.DataBind()
			Dim dt As New DataSet() '
			dt = rpgridview.DataSource
			Dim datatable As DataTable = dt.Tables(0)
			repHeader.Visible = True
			If datatable.Rows.Count = 0 Then
				Dim FooterTemplate As Control = rpgridview.Controls(rpgridview.Controls.Count - 1).Controls(0)
				FooterTemplate.FindControl("lblNoRecord").Visible = True
				repHeader.Visible = False
			End If
			FillReportCount()
		Catch ex As Exception
			Dim error1 As String = ex.Message.Replace(Chr(34), "")
			error1 = error1.Replace(Chr(39), "")
			'ExecptionBLL.Insert("Activity", "fillLead", error1, Session("UserId"))
			ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
		End Try

	End Sub

	Public Sub FillReportCount()
		Try
			'Dim ds As DataSet = reportBLL.AccountReportCount("ProspectReportCount", txtfrom.Text, txtto.Text, ddlUser.SelectedValue)
			Dim ds As DataSet = reportBLL.ProspectReportViewNew("ProspectReportCount", txtfrom.Text, txtto.Text, ddlUser.SelectedValue, ddlProspectName.SelectedValue, ddlType.SelectedValue, ddlCategory.SelectedValue, ddlSource.SelectedValue)
			If ds.Tables.Count > 0 Then
				ltTotalProspects.Text = ds.Tables(0).Rows(0)(0).ToString()
				ltDirectProspects.Text = ds.Tables(0).Rows(0)(1).ToString()
				ltConvertedProspects.Text = ds.Tables(0).Rows(0)(2).ToString()
				ltHotProspects.Text = ds.Tables(0).Rows(0)(0).ToString()
				ltWebSiteProspects.Text = ds.Tables(1).Rows(0)(0).ToString()
				litrader.Text = ds.Tables(2).Rows(0)(0).ToString()
			End If
			'If ddlStatusStage.SelectedValue = 0 Then
			'	ltProspectidl.Text = reportBLL.LeadReportCount1("IdelLeadCountByUser", txtfrom.Text, txtto.Text, ddlUser.SelectedValue)
			'Else
			'	ltProspectidl.Text = 0
			'End If
			''ltleadidl.Text = reportBLL.LeadReportCount1("IdelLeadCountByUser", txtfrom.Text, txtto.Text, ddlUser.SelectedValue)
		Catch ex As Exception
			Dim error1 As String = ex.Message.Replace(Chr(34), "")
			error1 = error1.Replace(Chr(39), "")
			ExecptionBLL.Insert("Index.aspx", "FillIndexCount", error1, Session("UserId"))
			Throw ex
		End Try
	End Sub

	Protected Sub ddlUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlUser.SelectedIndexChanged
		Try
			FillddlLeadName()
			'	fillgridview()
		Catch ex As Exception
			Dim error1 As String = ex.Message.Replace(Chr(34), "")
			error1 = error1.Replace(Chr(39), "")
			ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
		End Try
	End Sub

	Protected Sub ddlLeadName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProspectName.SelectedIndexChanged
		Try
			'fillgridview()
		Catch ex As Exception
			Dim error1 As String = ex.Message.Replace(Chr(34), "")
			error1 = error1.Replace(Chr(39), "")
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

	Protected Sub btnExportExcel_Click(sender As Object, e As ImageClickEventArgs) Handles btnExportExcel.Click
		Try
			Response.Clear()
			Response.Buffer = True
            'Response.AddHeader("content-disposition", "attachment;filename=" + ddlUser.SelectedItem.Text + ".xls")
            Response.AddHeader("content-disposition", "attachment;filename=Prospect Report.xls")
			Response.Charset = ""
			Response.ContentType = "application/vnd.ms-excel"
			Dim sw As New StringWriter()
			Dim hw As New HtmlTextWriter(sw)

			Dim GRD As New GridView

			Dim UserID1 As Integer
			If ddlUser.SelectedValue = 0 Then
				UserID1 = 1
			Else
				UserID1 = ddlUser.SelectedValue
			End If
			Dim str As String = ddlProspectName.SelectedValue
			Dim strArr() As String
			strArr = str.Split("-")
			Dim CompanyID As Integer = strArr(0)
			Dim Type As String
			If CompanyID <> 0 Then
				Type = strArr(1)
			Else
				Type = "None"
			End If

            GRD.DataSource = reportBLL.ProspectReportViewNew("ProspectreportViewExcel", txtfrom.Text, txtto.Text, ddlUser.SelectedValue, ddlProspectName.SelectedValue, ddlType.SelectedValue, ddlCategory.SelectedValue, ddlSource.SelectedValue).Tables(0)
			GRD.DataBind()
			GRD.AllowPaging = False
			GRD.DataBind()
			GRD.RenderControl(hw)
			Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
			Response.Write(style)
			Response.Output.Write(sw.ToString())
			Response.Flush()
			Response.End()
		Catch ex As Exception
			Dim error1 As String = ex.Message.Replace(Chr(34), "")
			error1 = error1.Replace(Chr(39), "")
			ExecptionBLL.Insert("SearchControlWithId", "btnExportExcel_Click", error1, Session("UserId"))
			ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
		End Try
	End Sub

	'Protected Sub ddlStatusStage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlStatusStage.SelectedIndexChanged
	'	Try
	'		fillgridview()
	'	Catch ex As Exception
	'		Dim error1 As String = ex.Message.Replace(Chr(34), "")
	'		error1 = error1.Replace(Chr(39), "")
	'		ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
	'	End Try
	'End Sub

	Protected Sub rpgridview_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rpgridview.ItemDataBound
		Try
			If e.Item.ItemType <> ListItemType.Item AndAlso e.Item.ItemType <> ListItemType.AlternatingItem Then Return
			Dim ColJunkRows = e.Item.FindControl("ColJunkRows")

			'If ddlStatusStage.SelectedValue = 7 Then
			'	ColJunk.Visible = True
			'	ColJunkRows.Visible = True
			'Else
			'	ColJunk.Visible = False
			'	ColJunkRows.Visible = False

			'End If
		Catch
			'Dim error1 As String = e.Message.Replace(Chr(34), "")
			'error1 = error1.Replace(Chr(39), "")
			'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
		End Try
	End Sub
End Class



