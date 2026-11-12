
Partial Class MIS_Report
    Inherits System.Web.UI.Page
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
        If Session("UserRoleID") <> "1" Then
            Response.Redirect("Index.aspx")
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub
   
End Class
