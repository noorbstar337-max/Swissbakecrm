
Partial Class OutstandingReport
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
		Try
			If Not IsPostBack Then
				FillddlUser()
				fillgridview()
			End If
		Catch ex As Exception
			Dim error1 As String = ex.Message.Replace(Chr(34), "")
			error1 = error1.Replace(Chr(39), "")
			ExecptionBLL.Insert("Report_DSR", "Page_Load", error1, Session("UserId"))
			ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
		End Try
	End Sub
#Region "FillDropdowns"
	Public Sub FillddlUser()
		Try
			Dim ds As DataSet
			ds = DSRReportBLL.UserDropdown("UserDropDown")
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
				ds = DSRReportBLL.CompanyDropdownById("CompanyDropDown", ddlUser.SelectedValue)
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
		Dim ds As DataSet
		Try
			Dim str As String = ddlCompany.SelectedValue
			Dim strArr() As String
			strArr = str.Split("-")
			Dim CompanyID As Integer
			If strArr(0) = "" Then
				CompanyID = 0
			Else
				CompanyID = strArr(0)
			End If
            ds = reportBLL.FillgridOutstanding("Outstanding", ddlUser.SelectedValue, CompanyID)
            Dim dtNew As New DataTable
            dtNew = ds.Tables(0)
            rpgridview.DataSource = dtNew
            rpgridview.DataBind()

            Dim FooterTemplate As Control = rpgridview.Controls(rpgridview.Controls.Count - 1).Controls(0)
            Dim lblopeningbal As Label = TryCast(FooterTemplate.FindControl("lblopeningbal"), Label)
            Dim lblamt As Label = TryCast(FooterTemplate.FindControl("lblamt"), Label)
            Dim lblpayment As Label = TryCast(FooterTemplate.FindControl("lblpayment"), Label)
            Dim lbloutstanding As Label = TryCast(FooterTemplate.FindControl("lbloutstanding"), Label)
            Dim trFooter As HtmlTableRow = TryCast(FooterTemplate.FindControl("trFooter"), HtmlTableRow)

            If ds.Tables(0).Rows.Count > 0 Then
                lblopeningbal.Text = CDbl(dtNew.Compute("Sum(Acc_OpeningBalance)", String.Empty)).ToString("N2")
                lblamt.Text = CDbl(dtNew.Compute("Sum(amt)", String.Empty)).ToString("N2")
                lblpayment.Text = CDbl(dtNew.Compute("Sum(totalpayment)", String.Empty)).ToString("N2")
                lbloutstanding.Text = CDbl(dtNew.Compute("Sum(Outstanding)", String.Empty)).ToString("N2")
            Else
                trFooter.Visible = False
                lblfoot.Visible = True
            End If

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
    '	Try
    '		Response.Clear()
    '		Response.Buffer = True
    '		If ddlUser.SelectedItem.Text = "All" And ddlCompany.SelectedItem.Text = "All" Then
    '			Response.AddHeader("content-disposition", "attachment;filename=outstanding Report(All).xls")
    '		Else
    '			Response.AddHeader("content-disposition", "attachment;filename=outstanding Report(" + ddlUser.SelectedItem.Text + ")(" + ddlCompany.SelectedItem.Text + ").xls")
    '		End If
    '		Response.Charset = ""
    '		Response.ContentType = "application/vnd.ms-excel"
    '		Dim sw As New StringWriter()
    '		Dim hw As New HtmlTextWriter(sw)
    '           Dim ds As DataSet
    '		Dim GRD As New GridView
    '		Dim str As String = ddlCompany.SelectedValue
    '		Dim strArr() As String
    '		strArr = str.Split("-")
    '		Dim CompanyID As Integer
    '		If strArr(0) = "" Then
    '			CompanyID = 0
    '		Else
    '			CompanyID = strArr(0)
    '           End If

    '           ds = reportBLL.FillgridOutstanding("OutstandingExcel", ddlUser.SelectedValue, CompanyID)
    '           Dim dt As New DataTable
    '           dt = ds.Tables(0)
    '           GRD.DataSource = dt

    '           GRD.DataBind()
    '           GRD.AllowPaging = False
    '		GRD.DataBind()
    '		GRD.RenderControl(hw)
    '		Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
    '		Response.Write(style)
    '		Response.Output.Write(sw.ToString())
    '		Response.Flush()
    '		Response.End()
    '	Catch ex As Exception
    '		Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '		error1 = error1.Replace(Chr(39), "")
    '		ExecptionBLL.Insert("SearchControlWithId", "btnExportExcel_Click", error1, Session("UserId"))
    '		ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '	End Try
    'End Sub

	Private Sub ddlUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlUser.SelectedIndexChanged
		FillddlCompany()
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try

            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=Outstanding Report.xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            Dim Gridview2 As New GridView

            Dim dt As New DataSet()
            'dt = MainBLL.SearchGridViewByID(txtSearch.Text.Trim, Session("UserId"), hfExcel.Value)
            Dim str As String = ddlCompany.SelectedValue
            Dim strArr() As String
            strArr = str.Split("-")
            Dim CompanyID As Integer
            If strArr(0) = "" Then
                CompanyID = 0
            Else
                CompanyID = strArr(0)
            End If
            dt = reportBLL.FillgridOutstanding("Outstanding", ddlUser.SelectedValue, CompanyID)
          
            Dim dtExc As DataTable = dt.Tables(0)
            dtExc.Columns.Remove("Acc_Id")
            dtExc.Columns.Remove("U_ID")
            dtExc.Columns.Remove("Acc_Id1")
            dtExc.Columns.Remove("Order_CustId")
            dtExc.Columns.Remove("detail_amt")
            ''dtExc.Columns.Remove("RowNumber")
            dtExc.Columns("RowNumber").ColumnName = "Sr No."
            dtExc.Columns("Acc_Name").ColumnName = "Account Name"
            dtExc.Columns("Acc_OpeningBalance").ColumnName = "Opening Balance"
            dtExc.Columns("amt").ColumnName = "Invoice Amount"
            dtExc.Columns("TotalPayment").ColumnName = "Payment"
            dtExc.Columns("Outstanding").ColumnName = "Outstanding"
            dtExc.Columns("U_FirstName").ColumnName = "Owner"
         
            dtExc.Columns("Invoice Amount").SetOrdinal(3)
            dtExc.Columns("Owner").SetOrdinal(6)

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
