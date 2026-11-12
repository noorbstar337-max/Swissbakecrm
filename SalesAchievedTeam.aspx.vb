Partial Class SalesAchievedTeam
    Inherits _PageBaseClass

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                fillOrder()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SalesAchievedTeam", "Page_Load", error1, Session("DUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillOrder()
        Try
            GridView1.DataSource = SalesTargetBLL.SalesAchievedTeam(Session("DUserId"))
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SalesAchievedTeam", "fillOrder", error1, Session("DUserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        Try
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=SalesAchievedTeam.xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            GridView1.AllowPaging = False
            GridView1.DataSource = SalesTargetBLL.SalesAchievedTeam(Session("DUserId"))
            GridView1.DataBind()

            For Each cell As TableCell In GridView1.HeaderRow.Cells
                cell.BackColor = GridView1.HeaderStyle.BackColor
            Next
            For Each row As GridViewRow In GridView1.Rows
                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = GridView1.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = GridView1.RowStyle.BackColor
                    End If
                    cell.CssClass = "textmode"
                    Dim controls As New List(Of Control)()

                    'Add controls to be removed to Generic List
                    For Each control As Control In cell.Controls
                        controls.Add(control)
                    Next

                    'Loop through the controls to be removed and replace then with Literal
                    For Each control As Control In controls
                        Select Case control.GetType().Name
                            Case "HyperLink"
                                cell.Controls.Add(New Literal() With { _
                                 .Text = TryCast(control, HyperLink).Text _
                                })
                                Exit Select
                            Case "Literal"
                                cell.Controls.Add(New Literal() With { _
                                 .Text = TryCast(control, Literal).Text _
                                })
                                Exit Select
                            Case "Label"
                                cell.Controls.Add(New Literal() With { _
                                 .Text = TryCast(control, Label).Text _
                                })
                                Exit Select
                        End Select
                        cell.Controls.Remove(control)
                    Next
                Next
            Next

            GridView1.RenderControl(hw)

            'style to format numbers to string 
            Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
            Response.Write(style)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.End()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SalesAchievedTeam", "btnExportExcel_Click", error1, Session("DUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
End Class
