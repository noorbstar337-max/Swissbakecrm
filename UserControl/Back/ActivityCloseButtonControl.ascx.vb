
Partial Class UserControl_Back_ActivityCloseButtonControl
    Inherits System.Web.UI.UserControl
    Dim MainID As Integer
    Dim FormDate As String, FromTime As String, FromDateTime As String
    Dim toDate As String, Toime As String, ToDateTime As String
    Dim ReminderDate As String, Remindertime As String, Reminderdatetime As String, Reminder As Boolean
    Dim Total As Integer = 0
    Public Event BubbleClick As EventHandler
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
    Public Property Uhactivity() As HiddenField
        Get
            Return Me.hfactivityid
        End Get
        Set(value As HiddenField)
            Me.hfactivityid = value
        End Set
    End Property
    Public Property Umpclose() As AjaxControlToolkit.ModalPopupExtender
        Get
            Return Me.mpclose
        End Get
        Set(value As AjaxControlToolkit.ModalPopupExtender)
            Me.mpclose = value
        End Set
    End Property
#End Region

#Region "Method"
    Protected Sub rdcloselist_TextChanged(sender As Object, e As EventArgs) Handles rdcloselist.TextChanged
        If rdcloselist.SelectedValue = "Close" Then
            divremark.Visible = True
            divremarkfooter.Visible = True
            mpclose.Show()
            divfollowup.Visible = False
            divtask.Visible = False
            divcall.Visible = False
            divevent.Visible = False
            btnfollowsave.ValidationGroup = "FollowTaskMasterGroup"
            rqdvresult.ValidationGroup = ""
            ddtype.Visible = False
            divpostpone.Visible = False
            divpostponesave.Visible = False
            dvresult.Visible = False
        ElseIf rdcloselist.SelectedValue = "FollowUp" Then
            divtask.Visible = True
            divcall.Visible = False
            divevent.Visible = False
            btnfollowsave.ValidationGroup = "FollowTaskMasterGroup"
            rqdvresult.ValidationGroup = "FollowTaskMasterGroup"
            ddtype.Visible = True
            divremark.Visible = False
            divremarkfooter.Visible = False
            divfollowup.Visible = True
            dateTimeFuntion1()
            divpostpone.Visible = False
            divpostponesave.Visible = False
            dvresult.Visible = True
            mpclose.Show()
        ElseIf rdcloselist.SelectedValue = "Postpone" Then
            divpostpone.Visible = True
            divtask.Visible = False
            divcall.Visible = False
            divevent.Visible = False
            btnfollowsave.ValidationGroup = "FollowTaskMasterGroup"
            rqdvresult.ValidationGroup = "Postponegroup"
            ddtype.Visible = False
            divremark.Visible = False
            divremarkfooter.Visible = False
            divfollowup.Visible = False
            divpostponesave.Visible = True
            dvresult.Visible = True
            txtpostponedate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            txtpostponestart.Text = Date.Now.ToString("H:mm")
            txtpostponeend.Text = Date.Now.Add(New TimeSpan(0, 1, 0)).ToString("H:mm")
            txtpostreminderdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            txtpostremindertime.Text = Date.Now.ToString("H:mm")
            mpclose.Show()
        End If
    End Sub

    Public Sub dateTimeFuntion1()
        Try
            txtfollowtaskdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            txtfollowcalldate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            txtfollowcallstart.Text = Date.Now.ToString("H:mm")
            txtfollowcallend.Text = Date.Now.Add(New TimeSpan(0, 1, 0)).ToString("H:mm")
            txtfollowfrom.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            txtfollowfromtime.Text = Date.Now.ToString("H:mm")
            txtfollowto.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            txtfollowtotime.Text = Date.Now.Add(New TimeSpan(0, 30, 0)).ToString("H:mm")
            txtfollowstart.Text = Date.Now.ToString("H:mm")
            txtfollowend.Text = Date.Now.Add(New TimeSpan(0, 1, 0)).ToString("H:mm")
            txttaskreminderdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            txttaskremindertime.Text = Date.Now.ToString("H:mm")
            txteventreminderdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            txteventremindertime.Text = Date.Now.ToString("H:mm")
            txtcallreminderdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            txtcallremindertime.Text = Date.Now.ToString("H:mm")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityUserControl", "dateTimeFuntion", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddtype_TextChanged(sender As Object, e As EventArgs) Handles ddtype.TextChanged
        If ddtype.SelectedValue = "Task" Then
            dvresult.Visible = True
            divtask.Visible = True
            divcall.Visible = False
            divevent.Visible = False
            btnfollowsave.ValidationGroup = "FollowTaskMasterGroup"
            rqdvresult.ValidationGroup = "FollowTaskMasterGroup"
            mpclose.Show()
        ElseIf ddtype.SelectedValue = "Call" Then
            dvresult.Visible = True
            divtask.Visible = False
            divcall.Visible = True
            divevent.Visible = False
            btnfollowsave.ValidationGroup = "CallTaskMasterGroup"
            rqdvresult.ValidationGroup = "CallTaskMasterGroup"
            mpclose.Show()
        ElseIf ddtype.SelectedValue = "Event" Then
            dvresult.Visible = True
            divtask.Visible = False
            divcall.Visible = False
            divevent.Visible = True
            btnfollowsave.ValidationGroup = "FollowEventMasterGroup"
            rqdvresult.ValidationGroup = "FollowEventMasterGroup"
            mpclose.Show()
        End If
    End Sub

    Protected Sub btclosenno_Click(sender As Object, e As EventArgs) Handles btclosenno.Click
        Try
            mpclose.Hide()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityUserControl", "btclosenno_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try

    End Sub

    Public Event LKCloseyesClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event LKpostponesaveClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event LKfollowsaveClick(ByVal sender As Object, ByVal e As System.EventArgs)

    Protected Sub btncloseyes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncloseyes.Click
        ActivityBLL.ClosedActivity(hfactivityid.Value, txtremark.Text.Trim)
        RaiseEvent LKCloseyesClick(sender, e)
    End Sub

    Protected Sub btnpostponesave_Click(sender As Object, e As EventArgs) Handles btnpostponesave.Click
        Try
            If String.IsNullOrEmpty(txtpostponedate.Text) Then
                txtpostponedate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            End If
            If String.IsNullOrEmpty(txtpostponestart.Text) Then
                txtpostponestart.Text = Date.Now.ToString("H:mm")
            End If
            If String.IsNullOrEmpty(txtpostponeend.Text) Then
                txtpostponeend.Text = Date.Now.Add(New TimeSpan(0, 1, 0)).ToString("H:mm")
            End If
            If String.IsNullOrEmpty(txtpostreminderdate.Text) Then
                txtpostreminderdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            End If
            If String.IsNullOrEmpty(txtpostremindertime.Text) Then
                txtpostremindertime.Text = Date.Now.ToString("H:mm:ss")
            End If
            FormDate = txtpostponedate.Text.Trim
            FromTime = txtpostponestart.Text.Trim
            FromDateTime = Convert.ToDateTime(FormDate + " " + FromTime)
            toDate = txtpostponedate.Text.Trim
            Toime = txtpostponeend.Text
            ToDateTime = Convert.ToDateTime(toDate + " " + Toime)
            ReminderDate = txtpostreminderdate.Text.Trim
            Remindertime = txtpostremindertime.Text.Trim
            Reminderdatetime = Convert.ToDateTime(ReminderDate + " " + Remindertime)
            If ckpostponereminder.Checked = True Then
                Reminder = 1
            Else
                Reminder = 0
            End If
            ActivityBLL.InsertPostpone(FromDateTime, ToDateTime, hfactivityid.Value, Reminder, Reminderdatetime, txtdvresult.Text)
            RaiseEvent LKpostponesaveClick(sender, e)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivitycloseButtonUserControl", "btnpostponesave_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnfollowsave_Click(sender As Object, e As EventArgs) Handles btnfollowsave.Click
        Try
            If ddtype.SelectedValue = "Task" Then
                Dim FormDate As String, FromTime As String, FromDateTime As String
                Dim toDate As String, Toime As String, ToDateTime As String
                If String.IsNullOrEmpty(txtfollowtaskdate.Text) Then
                    txtfollowtaskdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                End If
                If String.IsNullOrEmpty(txtfollowstart.Text) Then
                    txtfollowstart.Text = Date.Now.ToString("H:mm")
                End If
                If String.IsNullOrEmpty(txtfollowend.Text) Then
                    txtfollowend.Text = Date.Now.Add(New TimeSpan(0, 1, 0)).ToString("H:mm")
                End If
                If String.IsNullOrEmpty(txttaskreminderdate.Text) Then
                    txttaskreminderdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                End If
                If String.IsNullOrEmpty(txttaskremindertime.Text) Then
                    txttaskremindertime.Text = Date.Now.ToString("H:mm:ss")
                End If
                FormDate = txtfollowtaskdate.Text
                FromTime = txtfollowstart.Text
                FromDateTime = Convert.ToDateTime(FormDate + " " + FromTime)
                toDate = txtfollowtaskdate.Text
                Toime = txtfollowend.Text
                ToDateTime = Convert.ToDateTime(toDate + " " + Toime)
                ReminderDate = txttaskreminderdate.Text.Trim
                Remindertime = txttaskremindertime.Text.Trim
                Reminderdatetime = Convert.ToDateTime(ReminderDate + " " + Remindertime)
                If cktaskreminder.Checked = True Then
                    Reminder = 1
                Else
                    Reminder = 0
                End If
                ActivityBLL.InsertChildTask(Session("UserId"), txtfollowupsubject.SelectedValue, "Pending", txtfollowtaskdate.Text, "Task",
                hftype.Value, hftypeid.Value, ddfollowpriority.SelectedValue, Session("Audlog_Id"), Session("UserId"), FromDateTime,
                ToDateTime, hfactivityid.Value, Reminder, Reminderdatetime)
            ElseIf ddtype.SelectedValue = "Event" Then
                Dim FormDate As String, FromTime As String, FromDateTime As String
                Dim toDate As String, Toime As String, ToDateTime As String
                If String.IsNullOrEmpty(txtfollowfrom.Text) Then
                    txtfollowfrom.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                End If
                If String.IsNullOrEmpty(txtfollowfromtime.Text) Then
                    txtfollowfromtime.Text = Date.Now.ToString("H:mm")
                End If
                If String.IsNullOrEmpty(txtfollowto.Text) Then
                    txtfollowto.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                End If
                If String.IsNullOrEmpty(txtfollowtotime.Text) Then
                    txtfollowtotime.Text = Date.Now.Add(New TimeSpan(0, 30, 0)).ToString("H:mm")
                End If
                If String.IsNullOrEmpty(txteventreminderdate.Text) Then
                    txteventreminderdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                End If
                If String.IsNullOrEmpty(txteventremindertime.Text) Then
                    txteventremindertime.Text = Date.Now.ToString("H:mm:ss")
                End If
                FormDate = txtfollowfrom.Text.Trim
                FromTime = txtfollowfromtime.Text
                FromDateTime = Convert.ToDateTime(FormDate + " " + FromTime)
                toDate = txtfollowto.Text
                Toime = txtfollowtotime.Text
                ToDateTime = Convert.ToDateTime(toDate + " " + Toime)
                ReminderDate = txteventreminderdate.Text.Trim
                Remindertime = txteventremindertime.Text.Trim
                Reminderdatetime = Convert.ToDateTime(ReminderDate + " " + Remindertime)
                If ckeventreminder.Checked = True Then
                    Reminder = 1
                Else
                    Reminder = 0
                End If
                ActivityBLL.InsertChildEvent(Session("UserId"), txtfolloweventname.SelectedValue, txtfollowlocation.Text.Trim, FromDateTime, ToDateTime,
                hftype.Value, hftypeid.Value, Session("Audlog_Id"), Session("UserId"), hfactivityid.Value, ddeventfollowpriority.SelectedValue, Reminder, Reminderdatetime)
            ElseIf ddtype.SelectedValue = "Call" Then
                Dim FormDate As String, FromTime As String, FromDateTime As String
                Dim toDate As String, Toime As String, ToDateTime As String
                If String.IsNullOrEmpty(txtfollowcalldate.Text) Then
                    txtfollowcalldate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                End If
                If String.IsNullOrEmpty(txtfollowcallstart.Text) Then
                    txtfollowcallstart.Text = Date.Now.ToString("H:mm")
                End If
                If String.IsNullOrEmpty(txtfollowcallend.Text) Then
                    txtfollowcallend.Text = Date.Now.Add(New TimeSpan(0, 1, 0)).ToString("H:mm")
                End If
                If String.IsNullOrEmpty(txtcallreminderdate.Text) Then
                    txtcallreminderdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                End If
                If String.IsNullOrEmpty(txtcallremindertime.Text) Then
                    txtcallremindertime.Text = Date.Now.ToString("H:mm:ss")
                End If
                FormDate = txtfollowcalldate.Text
                FromTime = txtfollowcallstart.Text
                FromDateTime = Convert.ToDateTime(FormDate + " " + FromTime)
                toDate = txtfollowcalldate.Text
                Toime = txtfollowcallend.Text
                ToDateTime = Convert.ToDateTime(toDate + " " + Toime)
                ReminderDate = txtcallreminderdate.Text.Trim
                Remindertime = txtcallremindertime.Text.Trim
                Reminderdatetime = Convert.ToDateTime(ReminderDate + " " + Remindertime)
                If ckcallreminder.Checked = True Then
                    Reminder = 1
                Else
                    Reminder = 0
                End If
                ActivityBLL.InsertChildCall(txtcallsubject.Text, ddfollowcalltype.SelectedValue, FromDateTime, ToDateTime, hftype.Value, hftypeid.Value,
                Session("Audlog_Id"), ddfollowcallpurpose.SelectedValue, Session("UserId"), hfactivityid.Value, ddfollowcallpriority.SelectedValue, Reminder, Reminderdatetime)
            End If
            ActivityBLL.UpdateFollowActivity(Session("UserId"), hfactivityid.Value, txtdvresult.Text)
            RaiseEvent LKfollowsaveClick(sender, e)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("NoteControl", "SaveProduct", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
#End Region
End Class
