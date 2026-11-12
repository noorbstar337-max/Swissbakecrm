
Partial Class Logout
    Inherits System.Web.UI.Page
    Dim blogcookie As HttpCookie
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            Session("OrderProduct") = Nothing
            Session.Remove("UserId")
            Session.Remove("UserName")
            Session.Remove("UserRoleID")
            UserBLL.Logout(Session("Audlog_Id"))
            Session.Abandon()
            Session.Clear()
            blogcookie = Request.Cookies.Get("blogcookievalue")
            blogcookie.Expires = Now
            Response.Cookies.Add(Request.Cookies("blogcookievalue"))
            blogcookie = Request.Cookies.Get("blogcookievalue")
            Response.Redirect("Login.aspx")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", Popup.Msgbox(error1.ToString).ToString, True)
        End Try
    End Sub
    Protected Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        'Default Private Property Item(ByVal Optional  As MasterPageFile = "~/MasterPage2.master") 
        Dim host As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) ' HttpContext.Current.Request.Url.Host
        ' Dim url As String

        If host = "http://mcrm.swissbake.ch" Then
            Me.MasterPageFile = "MCRMMaster.master"

        End If

    End Sub
End Class
