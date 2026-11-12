
Partial Class ChangePassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
            If Session("UserId") = Nothing Then
                Response.Redirect("index.aspx")
            End If
        Else
            If Session("UserId") = Nothing Then
                Response.Redirect("index.aspx")
            End If
        End If
       End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                txtoldpass.Attributes.Add("readonly", "readonly")
                newpassdiv.Visible = False
                btnadd.Text = "Next"
            Catch ex As Exception
                Response.Redirect("index.aspx")
            End Try
        End If
        Me.Title = "Change Password"
    End Sub

    
    Protected Sub txtoldpass_TextChanged(sender As Object, e As EventArgs) Handles txtoldpass.TextChanged
        Try
            Dim ds As DataSet = UserBLL.ValidateOldPass(Session("UserId"), txtoldpass.Text.Trim)
            Dim dtUser As DataTable = ds.Tables(0)
            If dtUser.Rows.Count = 0 Then
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Invalid Password')", True)
                newpassdiv.Visible = False
                txtoldpass.Focus()
            Else
                btnadd.Text = "Update"
                newpassdiv.Visible = True
                txtnewpass.Focus()
                divoldpass.Visible = False
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            If Not String.IsNullOrEmpty(txtnewpass.Text) Then
                If txtnewpass.Text.Trim = txtconfirm.Text.Trim Then
                    UserBLL.Changepass(txtnewpass.Text.Trim, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Password changed successfully!');window.location='Login.aspx'", True)
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

End Class
