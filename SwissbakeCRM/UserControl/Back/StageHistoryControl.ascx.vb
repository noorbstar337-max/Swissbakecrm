
Partial Class UserControl_Back_StageHistoryControl
    Inherits System.Web.UI.UserControl

#Region "User Control Property"
    Public Property Uhftype() As HiddenField
        Get
            Return Me.hftype
        End Get
        Set(value As HiddenField)
            Me.hftype = value
        End Set
    End Property
    Public Property Uhftypeid() As HiddenField
        Get
            Return Me.hftypeid
        End Get
        Set(value As HiddenField)
            Me.hftypeid = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                FillStagehistory()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("StageHistoryControl", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillStagehistory()
        Try
            grdstage.DataSource = OpporStageHistoryBLL.ViewStageHistotyByID(hftype.Value, hftypeid.Value)
            grdstage.DataBind()
            Dim DS As DataSet = DirectCast(grdstage.DataSource, DataSet)
            Dim totalcount As Integer = DS.Tables(0).Rows.Count
            If totalcount > 0 Then
                ltstage.Text = "Stage History (" + totalcount.ToString + ")"
            Else
                ltstage.Text = "No Stage History"
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("StageHistoryControl", "FillStagehistory", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub grdstage_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdstage.PageIndexChanging
        Try
            grdstage.PageIndex = e.NewPageIndex
            grdstage.DataSource = OpporStageHistoryBLL.ViewStageHistotyByID(hftype.Value, hftypeid.Value)
            grdstage.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("StageHistoryControl", "grdstage_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdstage.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim lbprobability As Literal = DirectCast(e.Row.FindControl("lblProbability"), Literal)
                Dim divprogress As HtmlGenericControl = DirectCast(e.Row.FindControl("divprogress"), HtmlGenericControl)
                divprogress.Style("width") = lbprobability.Text + "%"
                'divprogress.InnerHtml = lbprobability.Text
                lbprobability.Text = lbprobability.Text.Replace("%", "")
                If lbprobability.Text >= 0 And lbprobability.Text <= 20 Then
                    divprogress.Attributes("class") = "progress-bar progress-bar-danger"
                ElseIf lbprobability.Text >= 20 And lbprobability.Text <= 40 Then
                    divprogress.Attributes("class") = "progress-bar progress-bar-warning"
                ElseIf lbprobability.Text >= 40 And lbprobability.Text <= 60 Then
                    divprogress.Attributes("class") = "progress-bar progress-bar-info"
                ElseIf lbprobability.Text >= 60 Then
                    divprogress.Attributes("class") = "progress-bar progress-bar-success"
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("StageHistoryControl", "GridView1_RowDataBound", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class
