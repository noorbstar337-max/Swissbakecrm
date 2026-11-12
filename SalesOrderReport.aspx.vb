Imports System.Drawing

Partial Class SalesOrderReport
    Inherits _PageBaseClass
    Dim Mainid As Integer
    Dim Query As String
    Dim ModuleName As String
    Dim strNames As New List(Of String)
    Dim sb As New StringBuilder
    Dim Count As Integer = 0

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                fillLead()
                FillUserName()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("CustomMis", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            'Throw ex
        End Try
    End Sub

    Public Sub fillLead()
        Try
            Mainid =Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(Mainid, "ViewCustomReport")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                Query = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustomReport_Query"))
                hfReport_Type.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustomReport_Type").ToString)
                hfquery.Value = Query
                hfmodule.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustomReport_TableName"))
                Dim str As String = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustomReport_SelectedFields").ToString())
                Dim strArr() As String
                strArr = str.Split(",")
            End If
            GridView1.PageIndex = 0
            GridView1.DataSource = CustomsReport.FillCustomReport(Query)
            GridView1.DataBind()
            rpsearch.DataSource = MainBLL.ViewByID(Mainid, "ViewCustomreportDT")
            rpsearch.DataBind()
            If rpsearch.Items.Count > 0 Then
                btnadd.Visible = True
                btnshowall.Visible = True
            Else
                btnadd.Visible = False
                btnshowall.Visible = False
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("CustomMis", "fillLead", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillUserName()
        Try
            Dim ds As DataSet = MainBLL.DropdownWithID("UserAssignDropDown", Session("UserId"))
            ddluser.DataSource = ds.Tables(0)
            ddluser.DataTextField = "U_FirstName"
            ddluser.DataValueField = "U_ID"
            ddluser.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyUser", "FillUserName", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            If txttop.Text = "" Then
                sb.Append(hfquery.Value + " Where ")
            Else
                txttop.Text = txttop.Text.Replace(".", "")
                hftopquery.Value = hfquery.Value
                hftopquery.Value = hftopquery.Value.Replace("SELECT distinct ", "Select Top " + txttop.Text + " ")
                sb.Append(hftopquery.Value + " Where ")
            End If
            Count = 1
            For i As Integer = 0 To rpsearch.Items.Count - 1
                Dim hfcoloumname As HiddenField = CType(rpsearch.Items(i).FindControl("hfcoloumname"), HiddenField)
                Dim hflogoperator As HiddenField = CType(rpsearch.Items(i).FindControl("hflogoperator"), HiddenField)
                Dim hfoperator As HiddenField = CType(rpsearch.Items(i).FindControl("hfoperator"), HiddenField)
                Dim hfdatatype As HiddenField = CType(rpsearch.Items(i).FindControl("hfdatatype"), HiddenField)
                Dim txtsearch As TextBox = CType(rpsearch.Items(i).FindControl("txtsearch"), TextBox)
                Dim txtstart As TextBox = CType(rpsearch.Items(i).FindControl("txtstart"), TextBox)
                Dim txtend As TextBox = CType(rpsearch.Items(i).FindControl("txtend"), TextBox)
                If (txtsearch.Text = "") Then
                    If (txtend.Text = "" And txtstart.Text = "") Then
                    Else
                        If i = 0 Then
                            If (hfoperator.Value = "like") Then
                                sb.Append(hfcoloumname.Value + " LIKE '%" & txtsearch.Text & "%' ")
                                Count = Count + 1
                            ElseIf (hfoperator.Value = "BETWEEN") Then
                                sb.Append(hfcoloumname.Value + " " + hfoperator.Value + " '" + txtstart.Text + "' " + " And " + " '" + txtend.Text + "' ")
                                Count = Count + 1
                            ElseIf (hfoperator.Value = "<") Then
                                sb.Append(hfcoloumname.Value + " " + hfoperator.Value + " '" + txtsearch.Text + "' ")
                                Count = Count + 1
                            ElseIf (hfoperator.Value = ">") Then
                                sb.Append(hfcoloumname.Value + " " + hfoperator.Value + " '" + txtsearch.Text + "' ")
                                Count = Count + 1
                            ElseIf (hfoperator.Value = "<>") Then
                                sb.Append(hfcoloumname.Value + " " + hfoperator.Value + " '" + txtsearch.Text + "' ")
                                Count = Count + 1
                            ElseIf (hfoperator.Value = "=") Then
                                sb.Append(hfcoloumname.Value + " " + hfoperator.Value + " '" + txtsearch.Text + "' ")
                                Count = Count + 1
                            End If
                        Else
                            If (hfoperator.Value = "like") Then
                                sb.Append(hflogoperator.Value + " " + hfcoloumname.Value + " LIKE '%" & txtsearch.Text & "%' ")
                                Count = Count + 1
                            ElseIf (hfoperator.Value = "BETWEEN") Then
                                sb.Append(hflogoperator.Value + " Convert(date," + hfcoloumname.Value + ") " + hfoperator.Value + " '" + txtstart.Text + "' " + " And " + " '" + txtend.Text + "' ")
                                Count = Count + 1
                            ElseIf (hfoperator.Value = "<") Then
                                sb.Append(hflogoperator.Value + " " + hfcoloumname.Value + " " + hfoperator.Value + " '" + txtsearch.Text + "' ")
                                Count = Count + 1
                            ElseIf (hfoperator.Value = ">") Then
                                sb.Append(hflogoperator.Value + " " + hfcoloumname.Value + " " + hfoperator.Value + " '" + txtsearch.Text + "' ")
                                Count = Count + 1
                            ElseIf (hfoperator.Value = "<>") Then
                                sb.Append(hflogoperator.Value + " " + hfcoloumname.Value + " " + hfoperator.Value + " '" + txtsearch.Text + "' ")
                                Count = Count + 1
                            ElseIf (hfoperator.Value = "=") Then
                                sb.Append(hflogoperator.Value + " " + hfcoloumname.Value + " " + hfoperator.Value + " '" + txtsearch.Text + "' ")
                                Count = Count + 1
                            End If
                        End If
                    End If
                Else
                    If i = 0 Then
                        If (hfoperator.Value = "like") Then
                            sb.Append(hfcoloumname.Value + " LIKE '%" & txtsearch.Text & "%' ")
                            Count = Count + 1
                        ElseIf (hfoperator.Value = "BETWEEN") Then
                            sb.Append(hfcoloumname.Value + " " + hfoperator.Value + " '" + txtstart.Text + "' " + " And " + " '" + txtend.Text + "' ")
                            Count = Count + 1
                        ElseIf (hfoperator.Value = "<") Then
                            sb.Append(hfcoloumname.Value + " " + hfoperator.Value + " '" + txtsearch.Text + "' ")
                            Count = Count + 1
                        ElseIf (hfoperator.Value = ">") Then
                            sb.Append(hfcoloumname.Value + " " + hfoperator.Value + " '" + txtsearch.Text + "' ")
                            Count = Count + 1
                        ElseIf (hfoperator.Value = "<>") Then
                            sb.Append(hfcoloumname.Value + " " + hfoperator.Value + " '" + txtsearch.Text + "' ")
                            Count = Count + 1
                        ElseIf (hfoperator.Value = "=") Then
                            sb.Append(hfcoloumname.Value + " " + hfoperator.Value + " '" + txtsearch.Text + "' ")
                            Count = Count + 1
                        End If
                    Else
                        If (hfoperator.Value = "like") Then
                            If hfdatatype.Value = "datetime" Then
                                sb.Append(hflogoperator.Value + " " + "CONVERT(VARCHAR(10), " + hfcoloumname.Value + ", 105)" + " LIKE '%" & CDate(txtsearch.Text).ToString("dd-MM-yyyy") & "%' ")
                                Count = Count + 1
                            Else
                                sb.Append(hflogoperator.Value + " " + hfcoloumname.Value + " LIKE '%" & txtsearch.Text & "%' ")
                                Count = Count + 1
                            End If

                        ElseIf (hfoperator.Value = "BETWEEN") Then
                            If hfdatatype.Value = "datetime" Then
                                sb.Append(hflogoperator.Value + " " + "CONVERT(VARCHAR(10), " + hfcoloumname.Value + ", 105)" + " LIKE '%" & CDate(txtsearch.Text).ToString("dd-MM-yyyy") & "%' ")
                                Count = Count + 1
                            Else
                                sb.Append(hflogoperator.Value + " " + hfcoloumname.Value + " " + hfoperator.Value + " '" + txtstart.Text + "' " + " And " + " '" + txtend.Text + "' ")
                                Count = Count + 1
                            End If
                        ElseIf (hfoperator.Value = "<") Then
                            If hfdatatype.Value = "datetime" Then
                                sb.Append(hflogoperator.Value + " " + "CONVERT(VARCHAR(10), " + hfcoloumname.Value + ", 105)" + " LIKE '%" & CDate(txtsearch.Text).ToString("dd-MM-yyyy") & "%' ")
                                Count = Count + 1
                            Else
                                sb.Append(hflogoperator.Value + " " + hfcoloumname.Value + " " + hfoperator.Value + " '" + txtsearch.Text + "' ")
                                Count = Count + 1
                            End If
                        ElseIf (hfoperator.Value = ">") Then
                            If hfdatatype.Value = "datetime" Then
                                sb.Append(hflogoperator.Value + " " + "CONVERT(VARCHAR(10), " + hfcoloumname.Value + ", 105)" + " LIKE '%" & CDate(txtsearch.Text).ToString("dd-MM-yyyy") & "%' ")
                                Count = Count + 1
                            Else
                                sb.Append(hflogoperator.Value + " " + hfcoloumname.Value + " " + hfoperator.Value + " '" + txtsearch.Text + "' ")
                                Count = Count + 1
                            End If
                        ElseIf (hfoperator.Value = "<>") Then
                            If hfdatatype.Value = "datetime" Then
                                sb.Append(hflogoperator.Value + " " + "CONVERT(VARCHAR(10), " + hfcoloumname.Value + ", 105)" + " LIKE '%" & CDate(txtsearch.Text).ToString("dd-MM-yyyy") & "%' ")
                                Count = Count + 1
                            Else
                                sb.Append(hflogoperator.Value + " " + hfcoloumname.Value + " " + hfoperator.Value + " '" + txtsearch.Text + "' ")
                                Count = Count + 1
                            End If
                        ElseIf (hfoperator.Value = "=") Then
                            If hfdatatype.Value = "datetime" Then
                                sb.Append(hflogoperator.Value + " " + "CONVERT(VARCHAR(10), " + hfcoloumname.Value + ", 105)" + " LIKE '%" & CDate(txtsearch.Text).ToString("dd-MM-yyyy") & "%' ")
                                Count = Count + 1
                            Else
                                sb.Append(hflogoperator.Value + " " + hfcoloumname.Value + " " + hfoperator.Value + " '" + txtsearch.Text + "' ")
                                Count = Count + 1
                            End If
                        End If
                    End If
                End If
            Next
            If ddlType.SelectedValue = "Team" Then
                sb.Append("AND  U_ID IN (select U_ID from [dbo].[UserOwnerChain](" + ddluser.SelectedValue + "))")
                Count = Count + 1
            Else
                sb.Append("AND  U_ID = " + ddluser.SelectedValue)
                Count = Count + 1
            End If
            If Count > 1 Then
                sb = sb.Replace("Where AND", "Where ")
                sb = sb.Replace("Where OR", "Where ")
                GridView1.DataSource = CustomsReport.SearchCustomReport(sb.ToString)
                GridView1.DataBind()
                Hfsearchcheck.Value = "True"
                hfsearchquery.Value = sb.ToString
            Else
                sb = sb.Replace("Where", "")
                sb = sb.Replace("Where", "")
                GridView1.DataSource = CustomsReport.FillCustomReport(sb.ToString)
                GridView1.DataBind()
                hftopquery.Value = hfquery.Value
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("CustomMis", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            'Throw ex
        End Try
    End Sub

    Protected Sub rpsearch_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rpsearch.ItemDataBound
        Try
            If e.Item.ItemType = DataControlRowType.DataRow Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim ltid As Literal = CType(e.Item.FindControl("ltid"), Literal)
                Dim hfcoloumname As HiddenField = CType(e.Item.FindControl("hfcoloumname"), HiddenField)
                Dim hflogoperator As HiddenField = CType(e.Item.FindControl("hflogoperator"), HiddenField)
                Dim hfoperator As HiddenField = CType(e.Item.FindControl("hfoperator"), HiddenField)
                Dim hfdatatype As HiddenField = CType(e.Item.FindControl("hfdatatype"), HiddenField)
                Dim txtsearch As TextBox = CType(e.Item.FindControl("txtsearch"), TextBox)
                Dim txtstart As TextBox = CType(e.Item.FindControl("txtstart"), TextBox)
                Dim txtend As TextBox = CType(e.Item.FindControl("txtend"), TextBox)
                Dim divTextbox As HtmlGenericControl = CType(e.Item.FindControl("divTextbox"), HtmlGenericControl)
                Dim divbetwwen As HtmlGenericControl = CType(e.Item.FindControl("divbetwwen"), HtmlGenericControl)
                Dim lblopertor As Label = CType(e.Item.FindControl("lbloperator"), Label)
                Dim lbloperator1 As Label = CType(e.Item.FindControl("lbloperator1"), Label)
                Dim cValidation As CustomValidator = TryCast(e.Item.FindControl("cValidation"), CustomValidator)
                If hfoperator.Value = "BETWEEN" Then
                    If hfdatatype.Value = "datetime" Then
                        divTextbox.Visible = False
                        divbetwwen.Visible = True
                        txtstart.TextMode = TextBoxMode.Date
                        txtend.TextMode = TextBoxMode.Date

                    Else
                        divTextbox.Visible = False
                        divbetwwen.Visible = True
                    End If
                ElseIf hfdatatype.Value = "bigint" Then
                    divTextbox.Visible = True
                    divbetwwen.Visible = False
                ElseIf (hfdatatype.Value = "datetime" And hfoperator.Value <> "BETWEEN") Then
                    divTextbox.Visible = True
                    divbetwwen.Visible = False
                    txtsearch.TextMode = TextBoxMode.Date
                End If
                If hfReport_Type.Value = "Custom Report" Then
                    lbloperator1.Visible = True
                    lblopertor.Visible = True
                End If

            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("CustomMis", "rpsearch_ItemDataBound", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            'Throw ex
        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            If Hfsearchcheck.Value = "True" Then
                GridView1.PageIndex = e.NewPageIndex
                GridView1.DataSource = CustomsReport.SearchCustomReport(hfsearchquery.Value)
                GridView1.DataBind()
            ElseIf txttop.Text <> "" Then
                txttop.Text = txttop.Text.Replace(".", "")
                hftopquery.Value = hfquery.Value
                hftopquery.Value = hftopquery.Value.Replace("SELECT distinct ", "Select Top " + txttop.Text + " ")
                GridView1.PageIndex = e.NewPageIndex
                GridView1.DataSource = CustomsReport.FillCustomReport(hftopquery.Value)
                GridView1.DataBind()
            Else
                GridView1.PageIndex = e.NewPageIndex
                GridView1.DataSource = CustomsReport.FillCustomReport(hfquery.Value)
                GridView1.DataBind()
            End If
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("CustomMis", "GridView1_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            'Throw ex
        End Try
    End Sub

    Protected Sub btnshowall_Click(sender As Object, e As EventArgs) Handles btnshowall.Click
        Try
            fillLead()
            txttop.Text = ""
            Hfsearchcheck.Value = ""
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("CustomMis", "btnshowall_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        Try
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=SalesOrderReport.xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)
            If Hfsearchcheck.Value = "True" Then
                GridView1.AllowPaging = False
                GridView1.DataSource = CustomsReport.SearchCustomReport(hfsearchquery.Value)
                GridView1.DataBind()
            ElseIf txttop.Text <> "" Then
                GridView1.AllowPaging = False
                txttop.Text = txttop.Text.Replace(".", "")
                hftopquery.Value = hfquery.Value
                hftopquery.Value = hftopquery.Value.Replace("SELECT distinct ", "Select Top " + txttop.Text + " ")
                GridView1.DataSource = CustomsReport.FillCustomReport(hftopquery.Value)
                GridView1.DataBind()
            Else
                GridView1.AllowPaging = False
                GridView1.DataSource = CustomsReport.FillCustomReport(hfquery.Value)
                GridView1.DataBind()
            End If
            GridView1.HeaderRow.BackColor = Color.White
            For Each cell As TableCell In GridView1.HeaderRow.Cells
                cell.BackColor = GridView1.HeaderStyle.BackColor
            Next
            For Each row As GridViewRow In GridView1.Rows
                row.BackColor = Color.White
                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = GridView1.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = GridView1.RowStyle.BackColor
                    End If
                    cell.CssClass = "textmode"
                Next
            Next
            GridView1.RenderControl(hw)
            Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
            Response.Write(style)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            GridView1.AllowPaging = True
            GridView1.PageSize = 30
            Response.End()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("CustomMis", "btnExportExcel_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Verifies that the control is rendered 
    End Sub

    Protected Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs)
        SetSortDirection(SortDireaction)
        Try
            Dim DataTable As DataTable
            If Hfsearchcheck.Value = "True" Then
                DataTable = CustomsReport.SearchCustomReport(hfsearchquery.Value)
            Else
                DataTable = CustomsReport.FillCustomReport(hfquery.Value)
            End If
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
            ExecptionBLL.Insert("Currency", "GridView1_Sorting", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class
