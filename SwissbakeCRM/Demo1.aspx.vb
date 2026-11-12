
Partial Class Demo1
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
     
        abc.InnerHtml = Session("print")

    End Sub
End Class
