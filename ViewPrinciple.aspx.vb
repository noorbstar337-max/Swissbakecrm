
Partial Class ViewPrinciple
    Inherits _PageBaseClass
    Dim MainID As Integer
    Dim Count As Integer = 0
    'Dim countrydt As DataTable
    Dim statedt As DataTable

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
                ExecptionBLL.Insert("ViewPrinciple", "Page_Init", error1, Session("UserId"))
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
                ExecptionBLL.Insert("ViewPrinciple", "Page_Init", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                'Me.txtsearch.Attributes.Add("onkeyup", String.Format("javascript:__doPostBack('{0}','')", Me.UpdatePanel1.ClientID))
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                FillDetail()
                FillPrinciple()
               activitycontrol.Uhftype.Value = "Principle"
                activitycontrol.Uhftypeid.Value = MainID
                documentcontrol.Uhftype.Value = "Principle"
                documentcontrol.Uhftypeid.Value = MainID
                notecontrol.Uhftype.Value = "Principle"
                notecontrol.Uhftypeid.Value = MainID
               emailcontrol.Uhftype.Value = "Principle"
                emailcontrol.Uhftypeid.Value = MainID
          Else
                Dim target As String = Me.Request.Form("__EVENTTARGET")
                 FillPrinciple()
          End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewPrinciple", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
        
    End Sub

    
    Public Sub FillDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "GetPrincipleRecordViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            ltemail.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Principle_EmailID").ToString())
            ltcontactname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Principle_CompanyName").ToString())
            ltmobile.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Principle_MobileNo").ToString())
            ltphone.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Principle_Phone").ToString())
            lbladdress.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Principle_Address").ToString()) + " " + DynamicparcelDataManipulation.FixNullFromDB(drLogin("Principle_City").ToString()) + " " + DynamicparcelDataManipulation.FixNullFromDB(drLogin("Principle_State").ToString())
            dt = Nothing
            dt = ActivityBLL.FillTaskType("Vendor", MainID, "CountActivity")
            dtUser = dt.Tables(0)
            drLogin = dtUser.Rows(0)
       Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewPrinciple", "FillDetail", error1, Session("UserId"))
            Throw ex
        End Try
    End Sub
    Public Sub FillPrinciple()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            gridview2.DataSource = MainBLL.FillGridViewById(0, 10, MainID, "PrinciplerWiseVendoGridview")
            gridview2.DataBind()
            Dim totalcount As Integer = gridview2.Rows.Count
            If totalcount > 0 Then
                lblprinciple.Text = "Vendor (" + totalcount.ToString + ")"
            Else
                lblprinciple.Text = "No Vendor"
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewPrinciple", "FillPrinciple", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class


