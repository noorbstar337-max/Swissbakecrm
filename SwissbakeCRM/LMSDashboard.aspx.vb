
Partial Class LMSDashboard
    Inherits System.Web.UI.Page
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("LMSUserId") = Nothing Then
            TryCast(Me.Master, LMSMasterPage).MaintainSession()
        End If
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fillgrid()

            If Session("LMSUserId") <> 1 Then
                Grdtrial.Columns(5).Visible = False
                Grdtrial.Columns(6).Visible = False
                Grdtrial.Columns(4).Visible = False
                GrdPendTrial.Columns(2).Visible = False
                'GrdPendTrial.Columns(6).Visible = False
                GrdPendTrial.Columns(4).Visible = False
                'GrdPendTrial.Columns(7).Visible = False
                grdTodayTrial.Columns(2).Visible = False
                'grdTodayTrial.Columns(6).Visible = False
                grdTodayTrial.Columns(4).Visible = False
                'grdTodayTrial.Columns(7).Visible = False
                'divfcount.Visible = False
            Else
                GrdPendTrial.Columns(3).Visible = True
                grdTodayTrial.Columns(3).Visible = True
            End If
            fillCount()
        End If
    End Sub
    Public Sub fillgrid()
        Try
            Dim dt As DataSet = LMSBLL.FillGridByID(Session("LMSUserId"), "Fillgrddash")
            GrdPendTrial.DataSource = dt.Tables(0)
            GrdPendTrial.DataBind()
            Grdtrial.DataSource = dt.Tables(1)
            Grdtrial.DataBind()
            grdTodayTrial.DataSource = dt.Tables(2)
            grdTodayTrial.DataBind()
            ltPendTr.Text = dt.Tables(0).Rows.Count
            ltTodPendTr.Text = dt.Tables(2).Rows.Count
            ltFBCount.Text = dt.Tables(1).Rows.Count
            If dt.Tables(0).Rows.Count = 0 Then
                divRecipegrd.Visible = False
            End If
            If dt.Tables(1).Rows.Count = 0 Then
                divtrialgrd.Visible = False
            End If
            If dt.Tables(2).Rows.Count = 0 Then
                divTodayTrial.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub fillCount()
        Try
            'Dim dt As DataSet = LMSBLL.FillGridByID(Session("LMSUserId"), "Dashcount") 'Incorret O/p
            'ltPendTr.Text = dt.Tables(0).Rows(0)(0)
            'ltTodPendTr.Text = dt.Tables(1).Rows(0)(0)
            'ltFBCount.Text = dt.Tables(2).Rows(0)(0)
            If ltPendTr.Text = 0 Then
                divPendcount.Visible = False
            End If
            If ltTodPendTr.Text = 0 Then
                divTodPendCount.Visible = False
            End If
            If ltFBCount.Text = 0 Then
                divFeedBack.Visible = False
            End If
            If divPendcount.Visible = False Then
                divTodPendCount.Attributes.Add("class", "col-lg-6")
                divFeedBack.Attributes.Add("class", "col-lg-6")
            End If
            If divTodPendCount.Visible = False Then
                divPendcount.Attributes.Add("class", "col-lg-6")
                divFeedBack.Attributes.Add("class", "col-lg-6")
            End If
            If divFeedBack.Visible = False Then
                divTodPendCount.Attributes.Add("class", "col-lg-6")
                divPendcount.Attributes.Add("class", "col-lg-6")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Grdtrial_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles Grdtrial.RowCommand
        Try
            If e.CommandName = "ApproveTrialLink" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                LMSBLL.UpdateApprove("UpdateTrialApprove", index, Session("LMSUserId"), "")
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Trial Has been Approved.')", True)
                fillgrid()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            Throw ex
        End Try
    End Sub

    Protected Sub GrdPendTrial_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GrdPendTrial.RowCommand

        Try
            If e.CommandName = "Approvedink" Then
                '      Dim index As Integer = Convert.ToInt32(e.CommandArgument)

                Dim commandArgs As String() = e.CommandArgument.ToString().Split(New Char() {","c})
                Dim a, b As String
                a = commandArgs(0)
                b = commandArgs(1)
                ' Dim a As String = ltFormApprove.Text
                LMSBLL.UpdateApprove("UpdateRecipeApprove", a, Session("LMSUserId"), "")
                LMSBLL.UpdateApprove("UpdateFormulationApprove", b, Session("LMSUserId"), "")
                fillgrid()
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Trial Has been Approved.')", True)
            ElseIf e.CommandName = "AddFeed" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Response.Redirect("ModifyFeedback.aspx?&ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&RId=" + HttpUtility.UrlEncode(Security.Encrypt(index)))
            ElseIf e.CommandName = "ViewFeed" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Dim TrId As Integer = LMSBLL.IdById("getTrialIdByRecipe", index)
                Response.Redirect("ModifyFeedback.aspx?chk=v&ID=" + HttpUtility.UrlEncode(Security.Encrypt(TrId)) + "&returnurl=y")
                ' ''Response.Redirect("ModifyFeedback.aspx?&ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&RId=" + HttpUtility.UrlEncode(Security.Encrypt(index)))
            End If

            'LMSBLL.UpdateApprove("UpdateRecipeApprove", ViewState("Recipe_Id"), Session("LMSUserId"))

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            Throw ex
        End Try
    End Sub

    Protected Sub grdTodayTrial_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdTodayTrial.RowCommand
        Try
            If e.CommandName = "Approvedink" Then
                '      Dim index As Integer = Convert.ToInt32(e.CommandArgument)

                Dim commandArgs As String() = e.CommandArgument.ToString().Split(New Char() {","c})
                Dim a, b As String
                a = commandArgs(0)
                b = commandArgs(1)
                ' Dim a As String = ltFormApprove.Text
                LMSBLL.UpdateApprove("UpdateRecipeApprove", a, Session("LMSUserId"), "")
                LMSBLL.UpdateApprove("UpdateFormulationApprove", b, Session("LMSUserId"), "")
                fillgrid()
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Trial Has been Approved.')", True)
            ElseIf e.CommandName = "AddFeed" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Response.Redirect("ModifyFeedback.aspx?&ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&RId=" + HttpUtility.UrlEncode(Security.Encrypt(index)))
            ElseIf e.CommandName = "ViewFeed" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Dim TrId As Integer = LMSBLL.IdById("getTrialIdByRecipe", index)
                Response.Redirect("ModifyFeedback.aspx?chk=v&ID=" + HttpUtility.UrlEncode(Security.Encrypt(TrId)) + "&returnurl=y")
                ' ''Response.Redirect("ModifyFeedback.aspx?&ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&RId=" + HttpUtility.UrlEncode(Security.Encrypt(index)))
            End If

            'LMSBLL.UpdateApprove("UpdateRecipeApprove", ViewState("Recipe_Id"), Session("LMSUserId"))

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            Throw ex
        End Try
    End Sub
End Class
