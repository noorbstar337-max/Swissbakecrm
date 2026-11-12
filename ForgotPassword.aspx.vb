Imports System.Net.Mail
Imports System.Net

Partial Class ForgotPassword
    Inherits System.Web.UI.Page
    Dim fname As String
    Dim uname As String
    Dim ustatus As String
    Dim udel As Boolean
    Dim userid As Integer

    Protected Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        Try
            Dim ds As DataSet = UserBLL.CheckEmail(txtusername.Text)
            Dim dtUser1 As DataTable = ds.Tables(0)
            If dtUser1.Rows.Count > 0 Then
                fname = ds.Tables(0).Rows(0)(0)
                uname = ds.Tables(0).Rows(0)(1)
                udel = ds.Tables(0).Rows(0)(2)
                ustatus = ds.Tables(0).Rows(0)(3)
                userid = ds.Tables(0).Rows(0)(4)
                If ustatus = "Active" Then
                    'Temporary stop email 06-10-2023 by Noor
                    ' sendrequest(fname, txtusername.Text)
                    ActivityBLL.InsertFullTask(1, "New Password Request", "", Date.Now(), "Task", "None", 0, "", 0, "High", Session("Audlog_Id"), "New Password Request by " + fname + " EmailID:- " + uname + " ", "", userid, Date.Now(), Date.Now(), True, Date.Now())
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Your new password request sent to Admin successfully!');window.location='Login.aspx'", True)
                Else
                    ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Inactive User\n Contact Admin');", True)
                    txtusername.Text = ""
                End If
            Else
                lblemail.Visible = True
                lblemail.Text = "Email id not exist"
                txtusername.Text = ""
                txtusername.Focus()
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ForgotPassword", "btnsubmit_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Private Sub sendrequest(ByVal name As String, ByVal reqemail As String)
        Try
            Dim emailid As String = SendMailBLL.AdminEmailId
            Dim body As String = String.Empty
            Dim reader As StreamReader = New StreamReader(Server.MapPath("~/Email/Forgotpass.html"))
            body = reader.ReadToEnd
            body = body.Replace("#reqemail", reqemail)
            body = body.Replace("#name", name)
            SendMailBLL.SendMail(emailid, body, "New Password Request from " + name)
            reader.Dispose()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
