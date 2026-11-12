Imports System.Data

Partial Class TopAccounts
    Inherits System.Web.UI.Page
    Dim MainID As Integer
    Dim ds1 As New DataSet()
    Private dt1 As New DataTable()
    Private dt2 As New DataTable()
    Private dt3 As New DataTable()
    Private pgitems As New PagedDataSource()

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
                '-------------------------    ddlUser_SelectedIndexChanged(Nothing, Nothing)
                'ddlCompany_SelectedIndexChanged(Nothing, Nothing)
                '------------------------       ddlStatusStage_SelectedIndexChanged(Nothing, Nothing)
                BindGridview() 'fillgridview()
                txtSearch.Attributes.Add("onkeyup", [String].Format("javascript:__doPostBack('{0}','')", rpg.ClientID))
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("DSRReport", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        If IsPostBack Then
            If txtSearch.Text <> "" OrElse hfBackcount.Value = "1" Then
                'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" OrElse hfBackcount.Value = "1" Then
                getsearch()
                fillpage()
            Else
                fillpage()
            End If
        End If
    End Sub
    Protected Sub BindGridview()
        Try
            ds1 = reportBLL.TopAccountReport("TopAccountReport", txtfrom.Text, txtto.Text)
            'ds1 = MainBLL.FillGridView(hfgridview.Value)
            If ds1.Tables(0).Rows.Count > 0 Then
                dt1 = ds1.Tables(0)
                'rpgridview.DataSource = dt1
                'rpgridview.DataBind()
            End If
            dt3 = dt1
            Session("dt1TopAcc") = dt1

            fillpage()
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Binding Account'" + ex.Message + ")", True)
        End Try
    End Sub
    Public Sub getsearch()
        Try

            'date time column not working in search and footer
            dt2 = DirectCast(Session("dt1TopAcc"), DataTable)


            If txtSearch.Text <> "" Then
                Dim selectedTable1 As DataTable = dt2.AsEnumerable().Where(Function(r) (r.Field(Of String)("Acc_Code").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                           (r.Field(Of String)("Acc_Name").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                            (r.Field(Of String)("AccAddr_City").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                             (r.Field(Of String)("AssignTo").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                (r.Field(Of String)("Sales_Amount").ToUpper().Contains(txtSearch.Text.ToUpper()))
                                ).CopyToDataTable()

                Session("dt2TopAcc") = selectedTable1
                'Else
                '    Dim selectedTable1 As DataTable = dt2.AsEnumerable().Where(Function(r) (r.Field(Of String)("Acc_Name").ToUpper().Contains(TextBox1.Text.ToUpper())) AndAlso
                '               (r.Field(Of String)("Contact_ContactPerson").ToUpper().Contains(TextBox2.Text.ToUpper())) AndAlso
                '                (r.Field(Of String)("Contact_Landline").ToUpper().Contains(TextBox3.Text.ToUpper())) AndAlso
                '                 (r.Field(Of String)("Contact_Email").ToUpper().Contains(TextBox4.Text.ToUpper())) AndAlso
                '    (r.Field(Of String)("Contact_Mobile").ToUpper().Contains(TextBox5.Text.ToUpper())) AndAlso
                '    (r.Field(Of String)("city").ToUpper().Contains(TextBox6.Text.ToUpper())) AndAlso
                '    (r.Field(Of String)("AssignTo").ToUpper().Contains(TextBox7.Text.ToUpper())) AndAlso
                '    (r.Field(Of String)("Acc_OpenFrom").ToUpper().Contains(TextBox8.Text.ToUpper()))
                '               ).CopyToDataTable()

                '    Session("dt2TopAcc") = selectedTable1



            End If
        Catch ex As Exception
            '  Session["dt2"] = "1";
            Dim exception As New DataTable()
            exception.Clear()

            Session("dt2TopAcc") = exception
        End Try
    End Sub
    Public Sub fillpage()
        Dim dt As New DataTable()
        If txtSearch.Text <> "" Then
            'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" Then
            dt = DirectCast(Session("dt2TopAcc"), DataTable)
        Else

            dt = DirectCast(Session("dt1TopAcc"), DataTable)
        End If
        'If dt.Rows.Count = 0 Then
        '    Dim FooterTemplate As Control = rpgridview.Controls(rpgridview.Controls.Count - 1).Controls(0)
        '    FooterTemplate.FindControl("trEmpty").Visible = True
        'Else
        If dt.Rows.Count = 0 Then
            pgitems.DataSource = dt.DefaultView
            rpgridview.DataSource = pgitems
            rpgridview.DataBind()
            'Dim FooterTemplate As Control = rpgridview.Controls(rpgridview.Controls.Count - 1).Controls(0)
            'FooterTemplate.FindControl("trEmpty").Visible = True
            'PopulatePager(0, 1)
            '' pgitems.AllowPaging = false ;

            'lblTcount.Visible = False
        Else
            pgitems.DataSource = dt.DefaultView
            'pgitems.AllowPaging = True
            'lblTcount.Visible = True
            'Count = dt.Rows.Count
            'If Count > 1 Then
            '    lblTcount.Text = Count.ToString() + " " + " records"
            'Else
            '    lblTcount.Text = Count.ToString() + " " + " record"
            'End If

            'pgitems.PageSize = Convert.ToInt32(ddpagesize.SelectedValue)
            'PopulatePager(pgitems.PageCount, PageNumber)
            'pgitems.CurrentPageIndex = PageNumber

            'tabss = PageNumber + 1
            'tab.Value = tabss.ToString()

            rpgridview.DataSource = pgitems
            rpgridview.DataBind()
        End If
        If dt.Rows.Count = Nothing Then
            tblGrid.Visible = False
        Else
            tblGrid.Visible = True
        End If
        'End If
        ' '' '' '' '' '' ''CheckPrivilage()
    End Sub
    Public Sub fillgridview()
        Try
            rpgridview.DataSource = reportBLL.TopAccountReport("TopAccountReport", txtfrom.Text, txtto.Text)
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
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            'ExecptionBLL.Insert("Activity", "fillLead", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try

    End Sub

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            'fillgridview()
            BindGridview()
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
    '        'Response.AddHeader("content-disposition", "attachment;filename=" + ddlUser.SelectedItem.Text + ".xls")
    '        Response.AddHeader("content-disposition", "attachment;filename=Prospect Report.xls")
    '        Response.Charset = ""
    '        Response.ContentType = "application/vnd.ms-excel"
    '        Dim sw As New StringWriter()
    '        Dim hw As New HtmlTextWriter(sw)

    '        Dim GRD As New GridView
    '        GRD.DataSource = reportBLL.TopAccountReport("TopAccountReport", txtfrom.Text, txtto.Text)
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
    Protected Sub btnExportExcel_Click(sender As Object, e As ImageClickEventArgs) Handles btnExportExcel.Click
        Try
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=Top Accounts Report.xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            Dim Gridview2 As New GridView

            Dim dt As New DataSet()
            'dt = MainBLL.SearchGridViewByID(txtSearch.Text.Trim, Session("UserId"), hfExcel.Value)

            dt = reportBLL.TopAccountReport("TopAccountReport", txtfrom.Text, txtto.Text)

            Dim dtExc As DataTable = dt.Tables(0)
            dtExc.Columns.Remove("Acc_Id")
            dtExc.Columns.Remove("Order_CustId")
            dtExc.Columns.Remove("NoOfOrder")
            dtExc.Columns.Remove("amt")
            ''dtExc.Columns.Remove("RowNumber")
            dtExc.Columns("RowNumber").ColumnName = "Sr No."
            dtExc.Columns("Acc_Code").ColumnName = "Account Code"
            dtExc.Columns("Acc_Name").ColumnName = "Account Name"
            dtExc.Columns("AccAddr_City").ColumnName = "City"
            dtExc.Columns("Sales_Amount").ColumnName = "Sales Amount (Rs)"
            'dtExc.Columns("Date").SetOrdinal(1)
            'dtExc.Columns("Company Name").SetOrdinal(3)
            For Each dr As DataRow In dtExc.Rows
                dr.Item("Sales Amount (Rs)") = dr.Item("Sales Amount (Rs)").ToString().Replace("₹", "")
            Next

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
    Protected Sub btnshowall_Click(sender As Object, e As EventArgs) Handles btnshowall.Click
        Try
            txtSearch.Text = ""
            fillpage()
        Catch ex As Exception

        End Try
    End Sub
End Class