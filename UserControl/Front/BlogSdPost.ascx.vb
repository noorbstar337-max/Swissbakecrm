
Partial Class UserControl_Front_BlogSiderecenrPost
    Inherits System.Web.UI.UserControl

    Public Function DateFormat(ByVal objInput As Object) As Object
        If objInput Is DBNull.Value Then
            Return Nothing
        Else
            Dim dt As Date = Convert.ToDateTime(objInput)
            objInput = dt.ToString("MMM-dd-yyyy")
        End If
        Return objInput
    End Function

    Public Sub FillrecentBlog()
        Try
            rprecentblog.DataSource = MainWebsiteBLL.MainWebsiteFill("RecentBlog")
            rprecentblog.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillrecentBlog()
        End If
    End Sub
End Class
