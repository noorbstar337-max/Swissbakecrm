
Partial Class Check
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Dim ds As DataSet
        'ds = ActivityBLL.ActivityOwnerList()
        'If ds.Tables(0).Rows.Count >= 1 Then
        '    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
        '        ltsubject.Text = " SwissBake CRM -Today Activity Notification " + DateTime.Now.ToString("dd-MM-yyyy") + " for " + ds.Tables(0).Rows(i)("U_FirstName").ToString + ""
        '        ltusername.Text = ds.Tables(0).Rows(i)("U_FirstName").ToString
        '        rpactivity.DataSource = ActivityBLL.TodayActivityMailByOwner(ds.Tables(0).Rows(i)("U_id").ToString)
        '        rpactivity.DataBind()
        '        If rpactivity.Items.Count >= 1 Then
        '            SendMail()
        '        End If
        '    Next
        'End If
        ActivityBLL.SendTodayMail()
        End Sub

    Public Sub SendMail()
        Dim htmlContent As String = Nothing
        Using sw As New StringWriter()
            Using hw As New HtmlTextWriter(sw)
                pnlactivity.RenderControl(hw)
                Dim sr As New StringReader(sw.ToString())
                htmlContent = [String].Format(sw.ToString())
            End Using
        End Using
        ActivityBLL.SendActivityMail("irfan.bstar@gmail.com", htmlContent, ltsubject.Text.Trim)
    End Sub

End Class
