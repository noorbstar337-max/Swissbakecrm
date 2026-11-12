
Partial Class LMSLogin
    Inherits System.Web.UI.Page
    Dim blogcookie As HttpCookie
    Protected Sub btnsubmit_ServerClick(sender As Object, e As EventArgs) Handles btnsubmit.Click
        Try

            ValidateLMSUserLogin()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Login", "btnsubmit_ServerClick", error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", Popup.Msgbox(error1.ToString).ToString, True)

        End Try
    End Sub
    Public Sub sendcode()
        Dim rand As Random = New Random
        Dim code As Integer = rand.Next(100000, 999999)

        If Not String.IsNullOrEmpty(Session("LMSMobile")) Then
            SendUsingSMPP.SendSMS("Enter " + code.ToString + " as your login OTP. Treat this as confidential. Sharing it anyone gives them full access to your account on lms.swissbake.ch. Valid for 5 minutes. Do not share with anyone.", Session("LMSMobile"))
        End If
        Session("Code") = code
        Session("CodeTime") = DateTime.Now.AddMinutes(5)
        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('OTP code has been sent to your mobile number: " + Session("LMSMobile").Remove(2, 6).Insert(2, "******") + "');", True)

        txtuname.Text = ""
        mpe.Show()
    End Sub
    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If Page.IsValid Then
            If Not Session("Code") Is Nothing And Not Session("CodeTime") Is Nothing Then
                Dim scode As String = Session("Code").ToString
                Dim scodeTime As String = Session("CodeTime").ToString
                Dim scodeTime2 As String = Convert.ToDateTime(Date.Now)
                If Convert.ToDateTime(Session("CodeTime").ToString) >= Convert.ToDateTime(Date.Now) Then
                    If Session("Code").ToString = txtuname.Text Then

                        txtuname.Text = ""
                        Session("Verified") = "True"
                        Response.Redirect("lmsdashboard.aspx")
                    Else
                        'Session.Abandon()
                        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Invalid OTP code');", True)
                        mpe.Show()
                    End If
                Else
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('OTP code has been expired');", True)
                    mpe.Show()
                End If
            Else
                HyperLink1_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Public Sub ValidateLMSUserLogin()
        Try
            Dim ds As DataSet = LMSBLL.ValidateLogin(txtusername.Text.Trim, txtpassword.Text.Trim)
            Dim count As Integer
            Dim dtUser As DataTable = ds.Tables(0)
            If dtUser.Rows.Count = 0 Then
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Invalid UserName or Password')", True)
            Else
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                Session("LMSUserId") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ID").ToString())
                Session("LMSDUserId") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ID").ToString())
                Session("LMSUserName") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_UserName").ToString())
                Session("LMSUserRoleID") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_LevelId").ToString())
                Session("LMSUName") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString())
                Session("LMSMobile") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_Mobile").ToString())
                count = UserBLL.InsertAuditLog(Session("LMSUserId"))
                Session("Audlog_Id") = count
                blogcookie = Request.Cookies.Get("blogcookievalue")
                blogcookie.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ID").ToString()) & "," &
                DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ID").ToString()) & "," & DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_UserName").ToString()) &
                "," & DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_LevelId").ToString()) & "," &
                DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString()) & "," & count
                blogcookie.Expires = DateTime.Now.AddMinutes(120)
                Response.Cookies.Add(Request.Cookies("blogcookievalue"))
                blogcookie = Request.Cookies.Get("blogcookievalue")
                '  Response.Redirect("index.aspx")
                Dim host As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) ' HttpContext.Current.Request.Url.Host
                host = "http://localhost:56360"
                If host = "http://localhost:56360" Then
                    Session("Verified") = "True"
                    Response.Redirect("lmsdashboard.aspx")

                Else

                    sendcode()
                End If

            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Login", "ValidateUserLogin", error1, Session("LMSUserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", Popup.Msgbox(error1.ToString).ToString, True)
            Throw ex
        End Try

    End Sub

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim host As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) ' HttpContext.Current.Request.Url.Host

        If host = "http://mcrm.swissbake.ch" Or host = "http://mcrm.swissbake.ch" Then
            Response.Redirect("login.aspx")
            'ElseIf host = "http://mcrm.swissbake.ch" Then

            '    Response.Redirect("LMSDashboard.aspx")
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            txtusername.Focus()
            Dim ipaddress As String
            ipaddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
            If ipaddress = "" Or ipaddress Is Nothing Then
                ipaddress = Request.ServerVariables("REMOTE_ADDR")
            End If
            lblip.Text = ipaddress
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Login", "Page_Load", error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", Popup.Msgbox(error1.ToString).ToString, True)
        End Try
    End Sub


    Protected Sub HyperLink1_Click(sender As Object, e As EventArgs) Handles HyperLink1.Click
        sendcode()

    End Sub
End Class
