
Partial Class Addressbook
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            If Session("UserId") = Nothing Then
                TryCast(Me.Master, MainPage).MaintainSession()
                CheckPrivilage()
            Else
                CheckPrivilage()
            End If
            'If Session("UserRoleID") <> "1" Then
            '    Response.Redirect("Index.aspx")
            'End If
            If Session("UserRoleID") <> "1" AndAlso Session("UserRoleID") <> "10" Then
                Response.Redirect("Index.aspx")
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "');window.location='AdminMenu.aspx';", True)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                'CheckPrivilage()
                filContact("ContactGridview")
                Me.txtsearch.Attributes.Add("onkeyup", String.Format("javascript:__doPostBack('{0}','')", Me.UpdatePanel1.ClientID))
                hfIsalpha.Value = False
            Else
                Dim target As String = Me.Request.Form("__EVENTTARGET")
                If Not String.IsNullOrEmpty(target) AndAlso target.Equals(Me.UpdatePanel1.ClientID) Then
                    If Not String.IsNullOrEmpty(Me.txtsearch.Text) Then
                        GridView1.AllowCustomPaging = False
                        FillSearch()
                    Else
                        GridView1.AllowCustomPaging = True
                        filContact("ContactGridview")
                    End If
                End If
            End If

            Dim scriptManager__1 As ScriptManager = ScriptManager.GetCurrent(Me.Page)
            scriptManager__1.RegisterPostBackControl(Me.btnExportWord)
            scriptManager__1.RegisterPostBackControl(Me.btnExportExcel)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Addressbook", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub filContact(ByVal Type As String)
        Try
            GridView1.PageSize = ddpagesize.SelectedValue
            GridView1.VirtualItemCount = MainBLL.TotalRowInGridview("ContactTotalNumberOfRecord")
            GridView1.DataSource = MainBLL.FillGridView("0", ddpagesize.SelectedValue, Type)
            GridView1.DataBind()
            For Each row As GridViewRow In GridView1.Rows
                GridView1.HeaderRow.Cells(1).Visible = False
                row.Cells(1).Visible = False
            Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Addressbook", "fillContact", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            Response.Redirect(Page.ResolveUrl("Contact.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&Id=" + HttpUtility.UrlEncode(Security.Encrypt(0))))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Addressbook", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillSearch()
        Try
            GridView1.DataSource = MainBLL.SearchGridView(txtsearch.Text.Trim, "ContactSearch")
            GridView1.AllowCustomPaging = False
            GridView1.DataBind()
            For Each row As GridViewRow In GridView1.Rows
                GridView1.HeaderRow.Cells(1).Visible = False
                row.Cells(1).Visible = False
            Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Addressbook", "FillSearch", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnshowall_Click(sender As Object, e As EventArgs) Handles btnshowall.Click
        Try
            GridView1.AllowCustomPaging = True
            filContact("ContactGridview")
            hfIsalpha.Value = False
            hfalpha.Value = ""
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Addressbook", "btnshowall_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            If txtsearch.Text = "" Then
                If CBool(hfIsalpha.Value) Then
                    'GridView1.VirtualItemCount = MainBLL.SearchGridView(hfalpha.Value.ToString, "ContactSearchTotalbyDairy").Tables(0).Rows(0)(0).ToString
                    GridView1.PageIndex = e.NewPageIndex
                    GridView1.DataSource = MainBLL.SearchGridView(hfalpha.Value.ToString, "ContactSearchByDairy")
                    GridView1.DataBind()
                    For Each row As GridViewRow In GridView1.Rows
                        GridView1.HeaderRow.Cells(1).Visible = False
                        row.Cells(1).Visible = False
                    Next
                Else
                    GridView1.PageIndex = e.NewPageIndex
                    GridView1.DataSource = MainBLL.FillGridView(e.NewPageIndex, ddpagesize.SelectedValue, "ContactGridview")
                    GridView1.DataBind()
                    For Each row As GridViewRow In GridView1.Rows
                        GridView1.HeaderRow.Cells(1).Visible = False
                        row.Cells(1).Visible = False
                    Next
                End If
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
            Else
                GridView1.PageIndex = e.NewPageIndex
                FillSearch()
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Addressbook", "GridView1_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName.Equals("AlphaPaging") Then
                txtsearch.Text = ""
                GridView1.DataSource = ""
                hfalpha.Value = e.CommandArgument
                hfIsalpha.Value = True
                GridView1.AllowCustomPaging = False
                'GridView1.VirtualItemCount = MainBLL.SearchGridView(e.CommandArgument, "ContactSearchTotalbyDairy").Tables(0).Rows(0)(0).ToString
                GridView1.DataSource = MainBLL.SearchGridView(e.CommandArgument, "ContactSearchByDairy")
                GridView1.DataBind()
                For Each row As GridViewRow In GridView1.Rows
                    GridView1.HeaderRow.Cells(1).Visible = False
                    row.Cells(1).Visible = False
                Next
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Addressbook", "GridView1_RowCommand", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowCreated
        Try
            If e.Row.RowType = DataControlRowType.Footer Then
                Dim cell As TableCell = e.Row.Cells(0)
                'e.Row.Cells.RemoveAt(7)
                e.Row.Cells.RemoveAt(6)
                e.Row.Cells.RemoveAt(5)
                e.Row.Cells.RemoveAt(4)
                e.Row.Cells.RemoveAt(3)
                e.Row.Cells.RemoveAt(2)
                e.Row.Cells.RemoveAt(1)
                cell.ColumnSpan = 15
                For i As Integer = 65 To (65 + 25)
                    Dim lb As New LinkButton()
                    lb.Text = [Char].ConvertFromUtf32(i) + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                    lb.CommandArgument = [Char].ConvertFromUtf32(i)
                    lb.CommandName = "AlphaPaging"
                    lb.Style("text-decoration") = "none"
                    cell.Controls.Add(lb)
                Next
            ElseIf e.Row.RowType = DataControlRowType.EmptyDataRow Then
                Dim cell As TableCell = e.Row.Cells(0)
                cell.ColumnSpan = 2
                For i As Integer = 65 To (65 + 25)
                    Dim lb As New LinkButton()
                    lb.Text = [Char].ConvertFromUtf32(i) + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                    lb.CommandArgument = [Char].ConvertFromUtf32(i)
                    lb.CommandName = "AlphaPaging"
                    lb.Style("text-decoration") = "none"
                    cell.Controls.Add(lb)
                Next
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Addressbook", "GridView1_RowCreated", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddpagesize_TextChanged(sender As Object, e As EventArgs) Handles ddpagesize.TextChanged
        Try
            GridView1.PageSize = ddpagesize.SelectedValue
            GridView1.VirtualItemCount = MainBLL.TotalRowInGridview("ContactTotalNumberOfRecord")
            GridView1.DataSource = MainBLL.FillGridView(GridView1.PageIndex, ddpagesize.SelectedValue, "ContactGridview")
            GridView1.DataBind()
            For Each row As GridViewRow In GridView1.Rows
                GridView1.HeaderRow.Cells(1).Visible = False
                row.Cells(1).Visible = False
            Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Addressbook", "ddpagesize_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnExportWord_Click(sender As Object, e As EventArgs) Handles btnExportWord.Click
        Try
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=Addressbook Details.doc")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-word "
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)
            Dim GRD As New GridView
            If txtsearch.Text = "" Then
                GRD.DataSource = MainBLL.SearchGridView(txtsearch.Text.Trim, "ContactExcel")
                GRD.DataBind()
                GRD.AllowPaging = False
                GRD.DataBind()
                For Each row As GridViewRow In GRD.Rows
                    GRD.HeaderRow.Cells(1).Visible = False
                    row.Cells(1).Visible = False
                Next
            Else
                GRD.DataSource = MainBLL.SearchGridView(txtsearch.Text.Trim, "ContactExcel")
                GRD.DataBind()
                GRD.AllowPaging = False
                GRD.DataBind()
                For Each row As GridViewRow In GRD.Rows
                    GRD.HeaderRow.Cells(1).Visible = False
                    row.Cells(1).Visible = False
                Next
            End If
            GRD.RenderControl(hw)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.[End]()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Addressbook", "btnExportWord_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        Try
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=Addressbook Details.xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)
            Dim GRD As New GridView
            If txtsearch.Text = "" Then
                GRD.DataSource = MainBLL.SearchGridView(txtsearch.Text.Trim, "ContactExcel")
                GRD.DataBind()
                GRD.AllowPaging = False
                GRD.DataBind()
                For Each row As GridViewRow In GRD.Rows
                    GRD.HeaderRow.Cells(1).Visible = False
                    row.Cells(1).Visible = False
                Next
            Else
                GRD.DataSource = MainBLL.SearchGridView(txtsearch.Text.Trim, "ContactExcel")
                GRD.DataBind()
                GRD.AllowPaging = False
                GRD.DataBind()
                For Each row As GridViewRow In GRD.Rows
                    GRD.HeaderRow.Cells(1).Visible = False
                    row.Cells(1).Visible = False
                Next
            End If
            GRD.RenderControl(hw)
            Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
            Response.Write(style)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.End()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Addressbook", "btnExportExcel_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub CheckPrivilage()
        Try
            Dim dt As DataSet = PrivilageBLL.CheckPrivilige(Session("UserRoleID"), "Addressbook.aspx")
            Dim dtprivilage As New DataTable
            dtprivilage = dt.Tables(0)
            Dim drprivilage As DataRow
            If dtprivilage.Rows.Count = 0 Then
                btnadd.Visible = False
                GridView1.Columns(0).Visible = False
                'GridView1.Columns(1).Visible = False
            Else
                drprivilage = dtprivilage.Rows(0)
                If (drprivilage("Prvg_RAdd").ToString()) = True Then
                    btnadd.Visible = True
                Else
                    btnadd.Visible = False
                End If
                If (drprivilage("Prvg_RUpdate").ToString()) = True Then
                    GridView1.Columns(0).Visible = True
                Else
                    GridView1.Columns(0).Visible = False
                End If
                If (drprivilage("Prvg_Rview").ToString()) = True Then
                Else
                    Throw New Exception("You don't have right to view this page\n Please contact admin!")
                End If
                'If (drprivilage("Prvg_RDelete").ToString()) = True Then
                '    GridView1.Columns(0).Visible = True
                'Else
                '    GridView1.Columns(0).Visible = False
                'End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Lead", "CheckPrivilage", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
End Class
