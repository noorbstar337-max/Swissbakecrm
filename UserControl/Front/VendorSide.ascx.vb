
Partial Class UserControl_Front_VendorSide
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillVendor()
        End If
    End Sub

    Public Sub FillVendor()
        Try
            rpvendorside.DataSource = MainWebsiteBLL.GetUserControlMasterVendorFromcache
            rpvendorside.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class
