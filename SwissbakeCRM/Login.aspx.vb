
Partial Class Login
    Inherits System.Web.UI.Page
    Dim blogcookie As HttpCookie
    Protected Sub btnsubmit_ServerClick(sender As Object, e As EventArgs) Handles btnsubmit.Click
        Try

            ValidateUserLogin()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Login", "btnsubmit_ServerClick", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", Popup.Msgbox(error1.ToString).ToString, True)

        End Try
    End Sub
  
    Public Sub ValidateUserLogin()
        Try
            'Dim ds As DataSet = UserBLL.ValidateLogin(txtusername.Text.Trim, txtpassword.Text.Trim)
            Dim ds As DataSet = UserBLL.ValidateLoginPrev(txtusername.Text.Trim, txtpassword.Text.Trim)
            Dim count As Integer
            Dim dtUser As DataTable = ds.Tables(0)
            Dim dtPrvl As DataTable = ds.Tables(1)
            Dim dtPvl As DataTable = ds.Tables(2)
            If dtUser.Rows.Count = 0 Then
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Invalid UserName or Password')", True)
            Else
                If ds.Tables.Count > 0 Then
                    dtPrvl = ds.Tables(1)
                    dtPvl = ds.Tables(2)
                    Session("dtPrivilageAdminMenu") = dtPrvl
                    Session("dtPrivilege") = dtPvl
                End If
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                Session("UserId") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ID").ToString())
                Session("DUserId") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ID").ToString())
                Session("UserName") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_UserName").ToString())
                Session("UserRoleID") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_LevelId").ToString())
                Session("UName") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString())

                count = UserBLL.InsertAuditLog(Session("UserId"))
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

                If host = "http://mcrm.swissbake.ch" Then
                    Response.Redirect("index1.aspx")
                Else
                    If Session("UserRoleID") = "4" Then
                        Response.Redirect("SupportDashBoard.aspx")
                    ElseIf Session("UserRoleID") = "3" Then
                        Response.Redirect("index.aspx")
                    Else

                        Response.Redirect("crmindex.aspx")
                    End If
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Login", "ValidateUserLogin", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", Popup.Msgbox(error1.ToString).ToString, True)
            Throw ex
        End Try

    End Sub
    'Public Sub ValidateUserLogin()
    '    Try
    '        Dim ds As DataSet = UserBLL.ValidateLogin(txtusername.Text.Trim, txtpassword.Text.Trim)
    '        Dim count As Integer
    '        Dim dtUser As DataTable = ds.Tables(0)
    '        If dtUser.Rows.Count = 0 Then
    '            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Invalid UserName or Password')", True)
    '        Else
    '            Dim drLogin As DataRow
    '            drLogin = dtUser.Rows(0)
    '            Session("UserId") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ID").ToString())
    '            Session("DUserId") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ID").ToString())
    '            Session("UserName") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_UserName").ToString())
    '            Session("UserRoleID") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_LevelId").ToString())
    '            Session("UName") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString())

    '            count = UserBLL.InsertAuditLog(Session("UserId"))
    '            Session("Audlog_Id") = count
    '            blogcookie = Request.Cookies.Get("blogcookievalue")
    '            blogcookie.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ID").ToString()) & "," &
    '            DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ID").ToString()) & "," & DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_UserName").ToString()) &
    '            "," & DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_LevelId").ToString()) & "," &
    '            DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString()) & "," & count
    '            blogcookie.Expires = DateTime.Now.AddMinutes(120)
    '            Response.Cookies.Add(Request.Cookies("blogcookievalue"))
    '            blogcookie = Request.Cookies.Get("blogcookievalue")
    '            '  Response.Redirect("index.aspx")

    '            Dim host As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) ' HttpContext.Current.Request.Url.Host

    '            If host = "http://mcrm.swissbake.ch" Then
    '                Response.Redirect("index1.aspx")
    '            Else
    '                If Session("UserRoleID") = "4" Then
    '                    Response.Redirect("SupportDashBoard.aspx")
    '                Else
    '                    Response.Redirect("index.aspx")
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert("Login", "ValidateUserLogin", error1, Session("UserId"))
    '        'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", Popup.Msgbox(error1.ToString).ToString, True)
    '        Throw ex
    '    End Try

    'End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim host As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) ' HttpContext.Current.Request.Url.Host

            If host = "http://lms.swissbake.ch" Then
                Response.Redirect("lmslogin.aspx")
                
            End If
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
            ExecptionBLL.Insert("Login", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", Popup.Msgbox(error1.ToString).ToString, True)
        End Try
    End Sub

  
End Class
