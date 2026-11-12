
Partial Class ViewCustomerComplaint
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
                ExecptionBLL.Insert("ViewCustomerComplaint", "Page_Init", error1, Session("UserId"))
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
                ExecptionBLL.Insert("ViewCustomerComplaint", "Page_Init", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                privilage()
                aedit.HRef = Page.ResolveUrl("ModifyCustomerComplaint.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())) + "&returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)))
                FillDetail()
                activitycontrol.Uhftype.Value = "Complaint"
                activitycontrol.Uhftypeid.Value = MainID
                DocumentControl.Uhftype.Value = "Complaint"
                DocumentControl.Uhftypeid.Value = MainID
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewCustomerComplaint", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
        'FillDetail()
        'upquickaction.Update()
    End Sub
   
    Public Sub FillDetail()
        Try

            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "CustomerComplaintViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            lbltitleofcomp.Text = DynamicparcelDataManipulation.FixNullFromDB((DynamicparcelDisplayFunctions.TruncateDescription(drLogin("CustComplaint_Title"), 100)).ToString())
            lbltitleofcomp1.Text = DynamicparcelDataManipulation.FixNullFromDB((drLogin("CustComplaint_Title")).ToString())
            lblexternal.Text = DynamicparcelDataManipulation.FixNullFromDB((drLogin("CustComplaint_RCExt")).ToString())
            lblinternal.Text = DynamicparcelDataManipulation.FixNullFromDB((drLogin("CustComplaint_RCInt")).ToString())
            lblaction.Text = DynamicparcelDataManipulation.FixNullFromDB((drLogin("CustComplaint_Action")).ToString())
            lblprevent.Text = DynamicparcelDataManipulation.FixNullFromDB((drLogin("CustComplaint_Prevent")).ToString())
            lblfeedback.Text = DynamicparcelDataManipulation.FixNullFromDB((drLogin("CustComplaint_Feedback")).ToString())

            lbldescription.Text = DynamicparcelDataManipulation.FixNullFromDB((drLogin("CustComplaint_Desc")).ToString())
            ltcomplaint.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustComplaint_No").ToString())
            ltinvoice.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustComplaint_InvoiceNo").ToString())
            ltbatch.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustComplaint_BatchNo").ToString())
            ltProduct.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Product_Name").ToString())
            ltaccount.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
            ltAccPro.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Type").ToString())
            ltcontactname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustComplaint_No").ToString())
            rpowner.DataSource = AssignToBLL.FillAssignTo("Customer Complaint", MainID)
            rpowner.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewCustomerComplaint", "FillDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub privilage()
        Try
            Dim dt As DataSet = PrivilageBLL.CheckPrivilige(Session("UserRoleID"), "Solution.aspx")
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
            ExecptionBLL.Insert("ViewCustomerComplaint", "privilage", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

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
            ExecptionBLL.Insert("ViewCustomerComplaint", "lkdelete_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class
