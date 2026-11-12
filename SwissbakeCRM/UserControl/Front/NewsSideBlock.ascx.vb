
Partial Class UserControl_Front_NewsSideBlock
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fillNewsideBlock()

        End If
    End Sub
    Public Function DateFormat(ByVal objInput As Object) As Object
        If objInput Is DBNull.Value Then
            Return Nothing
        Else
            Dim dt As Date = Convert.ToDateTime(objInput)
            objInput = dt.ToString("MMM-dd-yyyy")
        End If
        Return objInput
    End Function

    Public Sub fillNewsideBlock()
        Try
            rprecentnews.DataSource = MainWebsiteBLL.MainWebsiteFill("FillNewsSideBlock")
            rprecentnews.DataBind()

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class
