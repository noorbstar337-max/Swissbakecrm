
Partial Class Companydocument
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            documentcontrol.Uhftype.Value = "Company"
            documentcontrol.Uhftypeid.Value = "1"
        End If
    End Sub
End Class
