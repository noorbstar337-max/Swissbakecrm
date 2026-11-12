
Partial Class ViewOpportunity
    Inherits System.Web.UI.Page
    Dim MainID As Integer

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
            Try
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("index.aspx")
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ViewOpportunity", "Page_Init", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        Else
            Try
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("index.aspx")
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ViewOpportunity", "Page_Init", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
        End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
        If Not IsPostBack Then
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                privilage()
                aedit.HRef = Page.ResolveUrl("opportunity.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())) + "&returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)))
            FillDetail()
            activitycontrol.Uhftype.Value = "Opportunity"
            activitycontrol.Uhftypeid.Value = MainID
            documentcontrol.Uhftype.Value = "Opportunity"
            documentcontrol.Uhftypeid.Value = MainID
            notecontrol.Uhftype.Value = "Opportunity"
            notecontrol.Uhftypeid.Value = MainID
            'contactcontrol.Uhftype.Value = hfcontacttype.Value
            'contactcontrol.Uhftypeid.Value = hfcontacttypeid.Value
            opcontactcontrol.Uhftype.Value = hfcontacttype.Value
            opcontactcontrol.Uhftypeid.Value = hfcontacttypeid.Value
            itemdtcontrol.Uhftype.Value = hfcontacttype.Value
            itemdtcontrol.Uhftypeid.Value = hfcontacttypeid.Value
            itemdtcontrol.Uhfopptype.Value = "Opportunity"
            itemdtcontrol.Uhfopptypeid.Value = MainID
            opcontactcontrol.Uhfopptype.Value = "Opportunity"
            opcontactcontrol.Uhfopptypeid.Value = MainID
            staeghistorycontrol.Uhftype.Value = "Opportunity"
            staeghistorycontrol.Uhftypeid.Value = MainID
            Competitorcontrol.Uhftype.Value = "Opportunity"
                Competitorcontrol.Uhftypeid.Value = MainID
                emailcontrol.Uhftype.Value = "Opportunity"
                emailcontrol.Uhftypeid.Value = MainID
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewOpportunity", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
        'FillDetail()
        'upquickaction.Update()
    End Sub

    Protected Sub lkquicktask_Click(sender As Object, e As EventArgs) Handles lkquicktask.Click
        Try
            activitycontrol.dateTimeFuntion()
            activitycontrol.Utask.Show()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewOpportunity", "lkquicktask_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub lkquickevent_Click(sender As Object, e As EventArgs) Handles lkquickevent.Click
        Try
            activitycontrol.dateTimeFuntion()
            activitycontrol.UtaskEvent.Show()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewOpportunity", "lkquickevent_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub lkquickcall_Click(sender As Object, e As EventArgs) Handles lkquickcall.Click
        Try
            activitycontrol.dateTimeFuntion()
            activitycontrol.UtaskCall.Show()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewOpportunity", "lkquickcall_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "ViewOpportunityByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            ltrevenue.Text = Math.Round(CDbl(DynamicparcelDataManipulation.FixNullFromDB(drLogin("Revenue").ToString())), 2)
            ltcontactname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity_Name").ToString())
            ltdate .Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity_Name").ToString())
            ltcompanyname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString())
            ltStage.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("OppStage_Name").ToString())
            ltprobability.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("OppStage_Probability").ToString())
            'ltprobability.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Revenue").ToString())
            rpowner.DataSource = AssignToBLL.FillAssignTo("Opportunity", MainID)
            rpowner.DataBind()
            hfcontacttype.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity_Type").ToString())
            hfcontacttypeid.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity_TypeId").ToString())
            ltdate.Text = DynamicparcelDataManipulation.AlphaDateFormat(drLogin("Opportunity_ExpectedDate").ToString())
            ltamount.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity_Amount").ToString())
            ltaccname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
            dt = Nothing
            dt = ActivityBLL.FillTaskType("Opportunity", MainID, "CountActivity")
            dtUser = dt.Tables(0)
            drLogin = dtUser.Rows(0)
            ltcounttask.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Task").ToString())
            ltcountevent.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Evented").ToString())
            ltcountcall.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Calls").ToString())
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewOpportunity", "FillDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub privilage()
        Try
            Dim dt As DataSet = PrivilageBLL.CheckPrivilige(Session("UserRoleID"), "Lead.aspx")
            Dim dtprivilage As New DataTable
            dtprivilage = dt.Tables(0)
            Dim drprivilage As DataRow
            If dtprivilage.Rows.Count = 0 Then
                aedit.Visible = False
                lkdelete.Visible = False
            Else
                drprivilage = dtprivilage.Rows(0)
                If (drprivilage("Prvg_RUpdate").ToString()) = True Then
                    aedit.Visible = True
                Else
                    aedit.Visible = False
                End If
                'If (drprivilage("Prvg_RDelete").ToString()) = True Then
                '    lkdelete.Visible = True
                'Else
                '    lkdelete.Visible = False
                'End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewOpportunity", "privilage", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    'Protected Sub lkconvacount_Click(sender As Object, e As EventArgs) Handles lkconvacount.Click
    '    'Response.Redirect("CommingSoon.aspx")
    '    'MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
    '    'AccountBLL.ConvertAccount(MainID)
    '    'Response.Redirect(Page.ResolveUrl("ViewAccount.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString()))))
    'End Sub

    Protected Sub lkdelete_Click(sender As Object, e As EventArgs) Handles lkdelete.Click
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If deletestatus.Value = "yes" Then
                'MainBLL.DeleteSI(MainID, Session("UserId"), "LeadDeleteSi", Session("Audlog_Id"))
                Response.Redirect("MainOpportunity.aspx")
            Else

            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewOpportunity", "lkdelete_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class
