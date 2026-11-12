Imports DynamicparcelEnumerations

Partial Class ModifyCompetitor
    Inherits System.Web.UI.Page
    Dim MainID As Integer
    Dim returnurl As String

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("index.aspx")
                Else
                    MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                    If MainID = 0 Then
                        lbltitle1.Text = "New Competitor"
                        lbltitle2.Text = "New Competitor"
                    Else
                        lbltitle1.Text = "Modify Competitor"
                        lbltitle2.Text = "Modify Competitor"
                        FillDetail()
                    End If
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyCompetitor", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "ViewCompetitorsByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            txtname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Competitor_Name").ToString())
            txtamount.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Competitor_Amount").ToString())
            txtwebsite.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Competitor_Website").ToString())
            txtstrengths.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Competitor_Strengths").ToString())
            txtweakness.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Competitor_Weaknesses").ToString())
            txtremark.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Competitor_Remark").ToString())
            txtname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Competitor_Name").ToString())
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyCompetitor", "FillDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If MainID = 0 Then
                'SaveProduct(DML_OPERATION.INSERT)
            ElseIf MainID > 0 Then
                SaveProduct(DML_OPERATION.UPDATE)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyCompetitor", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try
                    CompetitorBLL.Update(txtname.Text.Trim, txtamount.Text.Trim, txtremark.Text.Trim, txtwebsite.Text.Trim, txtstrengths.Text.Trim, txtweakness.Text.Trim,
                                         Session("UserId"), Session("Audlog_Id"), MainID)
                    returnurl = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("returnurl")))
                    Response.Redirect(returnurl)
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ModifyCompetitor", "SaveProduct", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub
End Class
