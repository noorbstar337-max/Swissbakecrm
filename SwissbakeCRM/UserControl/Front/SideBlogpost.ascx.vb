
Partial Class UserControl_Front_BlogSideBlogCategory
    Inherits System.Web.UI.UserControl
    Public Sub FillBlogCategory()
        Try
            rprecentblog.DataSource = MainWebsiteBLL.MainWebsiteFill("BlogCategory")
            rprecentblog.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillBlogCategory()

        End If
    End Sub
End Class
