
Partial Class UserControl_Back_EmailViewControl
    Inherits System.Web.UI.UserControl
#Region "User Control Property"
    Public Property Uhftype() As HiddenField
        Get
            Return Me.hftype
        End Get
        Set(value As HiddenField)
            Me.hftype = value
        End Set
    End Property
    Public Property Uhftypeid() As HiddenField
        Get
            Return Me.hftypeid
        End Get
        Set(value As HiddenField)
            Me.hftypeid = value
        End Set
    End Property
#End Region

#Region "Method"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                FillEmail()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("EmailViewControl", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillEmail()
        Try
            grdemail.DataSource = EmailBLL.ViewEmailByType(hftype.Value, hftypeid.Value, Session("UserId"))
            grdemail.DataBind()
            Dim DS As DataSet = DirectCast(grdemail.DataSource, DataSet)
            Dim totalcount As Integer = DS.Tables(0).Rows.Count
            If totalcount > 0 Then
                ltstage.Text = "Email (" + totalcount.ToString + ")"
            Else
                ltstage.Text = "No Email"
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("EmailViewControl", "FillEmail", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btncomposeemail_Click(sender As Object, e As EventArgs) Handles btncomposeemail.Click
        Try
            Response.Redirect("ComposeMessage.aspx?id=" + HttpUtility.UrlEncode(Security.Encrypt(hftypeid.Value)) + "&type=" + HttpUtility.UrlEncode(Security.Encrypt(hftype.Value)) + "&returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("EmailViewControl", "btncomposeemail_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub grdemail_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdemail.PageIndexChanging
        Try
            grdemail.PageIndex = e.NewPageIndex
            grdemail.DataSource = EmailBLL.ViewEmailByType(hftype.Value, hftypeid.Value, Session("UserId"))
            grdemail.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("EmailViewControl", "grdemail_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
#End Region
  
End Class
