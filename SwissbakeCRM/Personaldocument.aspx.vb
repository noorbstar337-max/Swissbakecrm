
Partial Class Personaldocument
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            documentcontrol.Uhftype.Value = "User"
            documentcontrol.Uhftypeid.Value = Session("UserId")
        End If
    End Sub
End Class
