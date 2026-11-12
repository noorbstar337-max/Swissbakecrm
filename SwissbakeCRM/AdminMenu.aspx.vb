
Partial Class AdminMenu
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            'TryCast(Me.Master, MainPage).MaintainSession()
            If Not Session("UserRoleID") = "1" Then
                Response.Redirect("index.aspx")
            End If
        Else
            If Not Session("UserRoleID") = "1" Then
                Response.Redirect("index.aspx")
            End If
        End If
        End Sub
End Class
