
Partial Class Lock
    Inherits System.Web.UI.Page
    Dim blogcookie As HttpCookie
    Dim temp As String
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Not Session("UserId") = Nothing Then
            MaintainSession()
        End If
    End Sub

    Public Sub MaintainSession()
        blogcookie = Request.Cookies.Get("blogcookievalue")
        If blogcookie.Value = "None" Then
            Response.Redirect("Login.aspx")
        Else
            Dim strArr() As String
            strArr = blogcookie.Value.Split(",")
            For i As Integer = 0 To strArr.Count - 1
                If i = 0 Then
                    Session("UserId") = strArr(i)
                    temp = strArr(i)
                ElseIf i = 1 Then
                    Session("DUserId") = strArr(i)
                    temp = strArr(i)
                ElseIf i = 2 Then
                    Session("UserName") = strArr(i)
                    temp = strArr(i)
                ElseIf i = 3 Then
                    Session("UserRoleID") = strArr(i)
                    temp = strArr(i)
                ElseIf i = 4 Then
                    Session("UName") = strArr(i)
                    temp = strArr(i)
                ElseIf i = 5 Then
                    Session("Audlog_Id") = strArr(i)
                    temp = strArr(i)
                End If
            Next
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not Session("UserId") = Nothing Then
                Try
                    txtlockpass.Attributes.Add("readonly", "readonly")
                    FillProfile()
                    lblname.Text = Session("UName").ToString
                    lblname2.Text = Session("UName").ToString
                    lblemail.Text = Session("UserName").ToString
                    clearsession()
                    txtlockpass.Focus()

                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("MasterPage", "FillProfile", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Else
                Response.Redirect("Login.aspx")
            End If
        End If

    End Sub

    Public Sub FillProfile()
        Try
            Dim dt As DataSet = MainBLL.ViewByID(Session("UserId"), "UserProfileViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                If Not String.IsNullOrEmpty(drLogin("U_ProfileImage").ToString()) Then
                    imgprofile.ImageUrl = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ProfileImage").ToString())
                Else
                    imgprofile.ImageUrl = "img/placeholders/avatars/avatar2.jpg"
                End If

            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "FillProfile", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub ValidateUserLogin()
        Try
            Dim ds As DataSet = UserBLL.ValidateLogin(lblemail.Text, txtlockpass.Text.Trim)
            Dim dtUser As DataTable = ds.Tables(0)
            If dtUser.Rows.Count = 0 Then
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Invalid UserName or Password')", True)
            Else
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                Session("UserId") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ID").ToString())
                Session("UserName") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_UserName").ToString())
                Session("UserRoleID") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_LevelId").ToString())
                Session("UName") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString())
                Session("Audlog_Id") = UserBLL.InsertAuditLog(Session("UserId"))
                Response.Redirect("index.aspx")
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", Popup.Msgbox(error1.ToString).ToString, True)
        End Try
    End Sub

    Public Sub clearsession()
        Session.Abandon()
        'Session("UserId") = Nothing
        'Session("UserName") = Nothing
        'Session("UserRoleID") = Nothing
        'Session("UName") = Nothing
        'Session("Audlog_Id") = Nothing
    End Sub

    Protected Sub btnunlock_Click(sender As Object, e As EventArgs) Handles btnunlock.Click
        ValidateUserLogin()
    End Sub
End Class
