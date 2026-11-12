Imports DynamicparcelEnumerations

Partial Class UserControl_Back_ActivityControl
    Inherits System.Web.UI.UserControl
    Dim MainID As Integer
    Dim FormDate As String, FromTime As String, FromDateTime As String
    Dim ReminderDate As String, Remindertime As String, Reminderdatetime As String, Reminder As Boolean
    Dim toDate As String, Toime As String, ToDateTime As String
    Dim Total As Integer = 0

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
    Public Property Uhfactivityid() As HiddenField
        Get
            Return Me.hfactivityid
        End Get
        Set(value As HiddenField)
            Me.hfactivityid = value
        End Set
    End Property
    Public Property Utask() As AjaxControlToolkit.ModalPopupExtender
        Get
            Return Me.mpe
        End Get
        Set(value As AjaxControlToolkit.ModalPopupExtender)
            Me.mpe = value
        End Set
    End Property
    Public Property UtaskCall() As AjaxControlToolkit.ModalPopupExtender
        Get
            Return Me.mpecall
        End Get
        Set(value As AjaxControlToolkit.ModalPopupExtender)
            Me.mpecall = value
        End Set
    End Property
    Public Property UtaskEvent() As AjaxControlToolkit.ModalPopupExtender
        Get
            Return Me.mpeevent
        End Get
        Set(value As AjaxControlToolkit.ModalPopupExtender)
            Me.mpeevent = value
        End Set
    End Property

#End Region

#Region "Method"

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                FillOwner()
                FillDDOwner()
                FillTaskOverDue()
                FillTommorrowTask()
                FillTodayTask()
                dateTimeFuntion()

                If Total > 0 Then
                    ltopentask.Text = "Due Activity (" + Total.ToString + ")"
                Else
                    ltopentask.Text = "No Due Activity"
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityUserControl", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            SaveTaskActivity(DML_OPERATION.INSERT)
            mpe.Hide()
            Response.Redirect(Page.Request.RawUrl)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityUserControl", "btnsave_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Private Sub SaveTaskActivity(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
            Case DML_OPERATION.INSERT
                Try
                    If String.IsNullOrEmpty(txtduedate.Text) Then
                        txtduedate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                    End If
                    If String.IsNullOrEmpty(txttaskdate.Text) Then
                        txttaskdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                    End If
                    If String.IsNullOrEmpty(txtstarttime.Text) Then
                        txttaskstarttime.Text = Date.Now.ToString("H:mm")
                    End If
                    If String.IsNullOrEmpty(txtendtime.Text) Then
                        txttaskendtime.Text = Date.Now.Add(New TimeSpan(0, 1, 0)).ToString("H:mm")
                    End If
                    If String.IsNullOrEmpty(txtopnetaskreminderdate.Text) Then
                        txtopnetaskreminderdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                    End If
                    If String.IsNullOrEmpty(txtopnetaskremindertime.Text) Then
                        txtopnetaskremindertime.Text = Date.Now.ToString("H:mm:ss")
                    End If
                    FormDate = txttaskdate.Text.Trim
                    FromTime = txttaskstarttime.Text.Trim
                    FromDateTime = Convert.ToDateTime(FormDate + " " + FromTime)
                    toDate = txttaskdate.Text.Trim
                    Toime = txttaskendtime.Text
                    ToDateTime = Convert.ToDateTime(toDate + " " + Toime)
                    ReminderDate = txtopnetaskreminderdate.Text.Trim
                    Remindertime = txtopnetaskremindertime.Text.Trim
                    Reminderdatetime = Convert.ToDateTime(ReminderDate + " " + Remindertime)
                    If ckopentaskreminder.Checked = True Then
                        Reminder = 1
                    Else
                        Reminder = 0
                    End If
                    ActivityBLL.Insert(ddowner.SelectedValue, txtsubject.Text.Trim, ddstatus.SelectedValue, txtduedate.Text, "Task",
                    hftype.Value, hftypeid.Value, ddpriority.SelectedValue, Session("Audlog_Id"), Session("UserId"), FromDateTime, ToDateTime, Reminder, Reminderdatetime)
                    If hftype.Value = "Lead" Then
                        LeadBLL.UpdateLeadStage(hftypeid.Value, 12)
                    End If
                    FillOwner()
                    FillTaskOverDue()
                    FillTommorrowTask()
                    FillTodayTask()
                    If Total > 0 Then
                        ltopentask.Text = "Open Task (" + Total.ToString + ")"
                    Else
                        ltopentask.Text = "No Open Task"
                    End If
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ActivityUserControl", "SaveTaskActivity", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub

    Public Sub FillOwner()
        Try
            GridView1.DataSource = ActivityBLL.FillActivityByRelatedType(hftype.Value, hftypeid.Value, Session("UserId"))
            GridView1.DataBind()
            Dim DS As DataSet = DirectCast(GridView1.DataSource, DataSet)
            Dim totalcount As Integer = DS.Tables(0).Rows.Count
            If totalcount > 0 Then
                lblactivity.Text = "Open Activity (" + totalcount.ToString + ")"
            Else
                lblactivity.Text = "No Open Activity"
            End If
            For Each row As GridViewRow In GridView1.Rows
                GridView1.HeaderRow.Cells(3).Visible = False
                row.Cells(3).Visible = False
            Next
            GridView2.DataSource = ActivityBLL.FillCloseActivityByRelatedType(hftype.Value, hftypeid.Value, Session("UserId"))
            GridView2.DataBind()
            DS = DirectCast(GridView2.DataSource, DataSet)
            totalcount = DS.Tables(0).Rows.Count
            If totalcount > 0 Then
                lblcloseactivity.Text = "Close Activity (" + totalcount.ToString + ")"
            Else
                lblcloseactivity.Text = "No Close Activity"
            End If
            For Each row As GridViewRow In GridView2.Rows
                GridView2.HeaderRow.Cells(1).Visible = False
                row.Cells(1).Visible = False
                GridView2.HeaderRow.Cells(2).Visible = False
                row.Cells(2).Visible = False
            Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityUserControl", "FillOwner", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub dateTimeFuntion()
        Try
            txttaskdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            txttaskstarttime.Text = Date.Now.ToString("H:mm")
            txttaskendtime.Text = Date.Now.Add(New TimeSpan(0, 1, 0)).ToString("H:mm")
            txtduedate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            txtdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            txtstarttime.Text = Date.Now.ToString("H:mm")
            txtendtime.Text = Date.Now.Add(New TimeSpan(0, 1, 0)).ToString("H:mm")
            txtfromdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            txtfromtime.Text = Date.Now.ToString("H:mm")
            txttodate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            txttotime.Text = Date.Now.Add(New TimeSpan(0, 30, 0)).ToString("H:mm")
            txtopnetaskreminderdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            txtopnetaskremindertime.Text = Date.Now.ToString("H:mm")
            txtopeneventreminderdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            txtopeneventremindertime.Text = Date.Now.ToString("H:mm")
            txtopencallremindrdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            txtopencallremindrtime.Text = Date.Now.ToString("H:mm")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityUserControl", "dateTimeFuntion", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "Closing" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                hfactivityid.Value = GridView1.DataKeys(index).Value()
                Try
                    txtremark.Text = ""
                    dateTimeFuntion1()
                    mpclose.Show()
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ActivityUserControl", "GridView1_RowCommand", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            ElseIf e.CommandName = "Viewing" Then
                Dim ID As Integer = 0
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Dim row As GridViewRow = GridView1.Rows(index)
                ID = GridView1.DataKeys(index).Value
                lvnote.DataSource = NoteBLL.NoteActivWithAssReverse(Session("UserId"), ID)
                lvnote.DataBind()
                grdactivityhistory.DataSource = MainBLL.ViewByID(ID, "ActivityHistory")
                grdactivityhistory.DataBind()
                hfmainactivityid.Value = ID
                hfreltypeId.Value = hftypeid.Value
                hfreltype.Value = hftype.Value
                Dim dt As DataSet
                ddtype.SelectedValue = "Task"
                divtask.Visible = True
                divcall.Visible = False
                divevent.Visible = False
                btnfollowsave.ValidationGroup = "FollowTaskMasterGroup"
                If hfreltype.Value = "Account" Or hfreltype.Value = "Prospect" Then
                    dt = NoteBLL.RecentActivity(ID, hfreltype.Value, hfreltypeId.Value)
                    Dim dtUser As New DataTable
                    dtUser = dt.Tables(0)
                    Dim drLogin As DataRow
                    drLogin = dtUser.Rows(0)
                    lblname.Text = hfreltype.Value + " Name"
                    lblsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                    ltstartdate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                    ltenddate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                    lblaccname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
                    ltpriority.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                    ltowner.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                    trcontact.Visible = True
                    If ltpriority.Text = "High" Then
                        ltpriority.CssClass = "label label-danger"
                    ElseIf ltpriority.Text = "Highest" Then
                        ltpriority.CssClass = "label label-danger"
                    ElseIf ltpriority.Text = "Lowest" Then
                        ltpriority.CssClass = "label label-warning"
                    ElseIf ltpriority.Text = "Low" Then
                        ltpriority.CssClass = "label label-warning"
                    ElseIf ltpriority.Text = "Normal" Then
                        ltpriority.CssClass = "label label-info"
                    End If
                    ltstatus.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                    If ltstatus.Text = "Close" Then
                        ltstatus.CssClass = "label label-success"
                    ElseIf ltstatus.Text = "Close Postpone" Then
                        ltstatus.CssClass = "label label-info"
                    ElseIf ltstatus.Text = "Pending" Then
                        ltstatus.CssClass = "label label-warning"
                    ElseIf ltstatus.Text = "Today" Then
                        ltstatus.CssClass = "label label-success"
                    ElseIf (ltstatus.Text = "Missed") Then
                        ltstatus.CssClass = "label label-danger"
                    ElseIf (ltstatus.Text = "Tommorrow") Then
                        ltstatus.CssClass = "label label-info"
                    End If
                    ltdesc.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                    ltresult.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                    ltcontact.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("ContactName").ToString())
                    'lblconatctd.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString())
                    hffollowactivityid.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Id").ToString())
                ElseIf hfreltype.Value = "Quotation" Then
                    dt = NoteBLL.ViewNoteQuotation(ID, hfreltypeId.Value)
                    Dim dtUser As New DataTable
                    dtUser = dt.Tables(0)
                    Dim drLogin As DataRow
                    drLogin = dtUser.Rows(0)
                    lblname.Text = "Quotation Name"
                    trcontact.Visible = False
                    lblsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                    ltstartdate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                    ltenddate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                    ltpriority.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                    ltowner.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                    If ltpriority.Text = "High" Then
                        ltpriority.CssClass = "label label-danger"
                    ElseIf ltpriority.Text = "Highest" Then
                        ltpriority.CssClass = "label label-danger"
                    ElseIf ltpriority.Text = "Lowest" Then
                        ltpriority.CssClass = "label label-warning"
                    ElseIf ltpriority.Text = "Low" Then
                        ltpriority.CssClass = "label label-warning"
                    ElseIf ltpriority.Text = "Normal" Then
                        ltpriority.CssClass = "label label-info"
                    End If
                    ltstatus.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                    If ltstatus.Text = "Close" Then
                        ltstatus.CssClass = "label label-success"
                    ElseIf ltstatus.Text = "Close Postpone" Then
                        ltstatus.CssClass = "label label-info"
                    ElseIf ltstatus.Text = "Pending" Then
                        ltstatus.CssClass = "label label-warning"
                    ElseIf ltstatus.Text = "Today" Then
                        ltstatus.CssClass = "label label-success"
                    ElseIf (ltstatus.Text = "Missed") Then
                        ltstatus.CssClass = "label label-danger"
                    ElseIf (ltstatus.Text = "Tommorrow") Then
                        ltstatus.CssClass = "label label-info"
                    End If
                    ltdesc.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                    ltresult.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                    lblaccname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_No").ToString()) + "-" + DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
                    'lblconatctd.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString())
                    hffollowactivityid.Value = ID
                ElseIf hfreltype.Value = "Opportunity" Then
                    dt = NoteBLL.ViewOpportunityByID(ID, hfreltypeId.Value)
                    Dim dtUser As New DataTable
                    dtUser = dt.Tables(0)
                    Dim drLogin As DataRow
                    drLogin = dtUser.Rows(0)
                    lblname.Text = "Opportunity Name"
                    lblaccname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity_Name").ToString()) + "-" + DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
                    trcontact.Visible = True
                    lblsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                    ltstartdate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                    ltenddate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                    ltpriority.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                    ltowner.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                    ltcontact.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("ContactName").ToString())
                    If ltpriority.Text = "High" Then
                        ltpriority.CssClass = "label label-danger"
                    ElseIf ltpriority.Text = "Highest" Then
                        ltpriority.CssClass = "label label-danger"
                    ElseIf ltpriority.Text = "Lowest" Then
                        ltpriority.CssClass = "label label-warning"
                    ElseIf ltpriority.Text = "Low" Then
                        ltpriority.CssClass = "label label-warning"
                    ElseIf ltpriority.Text = "Normal" Then
                        ltpriority.CssClass = "label label-info"
                    End If
                    ltstatus.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                    If ltstatus.Text = "Close" Then
                        ltstatus.CssClass = "label label-success"
                    ElseIf ltstatus.Text = "Close Postpone" Then
                        ltstatus.CssClass = "label label-info"
                    ElseIf ltstatus.Text = "Pending" Then
                        ltstatus.CssClass = "label label-warning"
                    ElseIf ltstatus.Text = "Today" Then
                        ltstatus.CssClass = "label label-success"
                    ElseIf (ltstatus.Text = "Missed") Then
                        ltstatus.CssClass = "label label-danger"
                    ElseIf (ltstatus.Text = "Tommorrow") Then
                        ltstatus.CssClass = "label label-info"
                    End If
                    ltdesc.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                    ltresult.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                    hffollowactivityid.Value = ID
                ElseIf hfreltype.Value = "Lead" Then
                    dt = NoteBLL.ViewLeadViewByID(ID, hfreltypeId.Value)
                    Dim dtUser As New DataTable
                    dtUser = dt.Tables(0)
                    Dim drLogin As DataRow
                    drLogin = dtUser.Rows(0)
                    lblname.Text = "Lead Name"
                    lblaccname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead_Name").ToString())
                    trcontact.Visible = True
                    lblsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                    ltstartdate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                    ltenddate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                    ltpriority.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                    ltowner.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                    ltcontact.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("ContactName").ToString())
                    If ltpriority.Text = "High" Then
                        ltpriority.CssClass = "label label-danger"
                    ElseIf ltpriority.Text = "Highest" Then
                        ltpriority.CssClass = "label label-danger"
                    ElseIf ltpriority.Text = "Lowest" Then
                        ltpriority.CssClass = "label label-warning"
                    ElseIf ltpriority.Text = "Low" Then
                        ltpriority.CssClass = "label label-warning"
                    ElseIf ltpriority.Text = "Normal" Then
                        ltpriority.CssClass = "label label-info"
                    End If
                    ltstatus.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                    If ltstatus.Text = "Close" Then
                        ltstatus.CssClass = "label label-success"
                    ElseIf ltstatus.Text = "Close Postpone" Then
                        ltstatus.CssClass = "label label-info"
                    ElseIf ltstatus.Text = "Pending" Then
                        ltstatus.CssClass = "label label-warning"
                    ElseIf ltstatus.Text = "Today" Then
                        ltstatus.CssClass = "label label-success"
                    ElseIf (ltstatus.Text = "Missed") Then
                        ltstatus.CssClass = "label label-danger"
                    ElseIf (ltstatus.Text = "Tommorrow") Then
                        ltstatus.CssClass = "label label-info"
                    End If
                    ltdesc.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                    ltresult.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                    hffollowactivityid.Value = ID
                End If
                dateTimeFuntion1()
                Dim ds As DataSet = MainBLL.Dropdown("UserDropDown")
                ckcreatefollowupactvt.Checked = False
                divtask.Visible = False
                divcall.Visible = False
                divevent.Visible = False
                ddtype.Visible = False
                txtname.Text = ""
                mpefollowup.Show()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityUserControl", "GridView1_RowCommand", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnaddnote_Click(sender As Object, e As EventArgs) Handles btnaddnote.Click
        Try
            NoteBLL.Insert(txtname.Text.Trim, "Activity", hffollowactivityid.Value, Session("Audlog_Id"), Session("UserId"))
            lvnote.DataSource = NoteBLL.NoteActivWithAssReverse(Session("UserId"), hfmainactivityid.Value)
            lvnote.DataBind()
            txtname.Text = ""
            mpefollowup.Show()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("NoteControl", "SaveProduct", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btclosenno_Click(sender As Object, e As EventArgs) Handles btclosenno.Click
        Try
            mpclose.Hide()
            Response.Redirect(Page.Request.RawUrl)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityUserControl", "btclosenno_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try

    End Sub

    Protected Sub btncloseyes_Click(sender As Object, e As EventArgs) Handles btncloseyes.Click
        Try
            ActivityBLL.ClosedActivity(hfactivityid.Value, txtremark.Text.Trim)
            FillOwner()
            FillTaskOverDue()
            FillTommorrowTask()
            FillTodayTask()
            If Total > 0 Then
                ltopentask.Text = "Due Activity (" + Total.ToString + ")"
            Else
                ltopentask.Text = "Due Activity"
            End If
            For Each row As GridViewRow In GridView1.Rows
                GridView1.HeaderRow.Cells(2).Visible = False
                row.Cells(2).Visible = False
            Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityUserControl", "btncloseyes_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            GridView1.PageIndex = e.NewPageIndex
            GridView1.DataSource = ActivityBLL.FillActivityByRelatedType(hftype.Value, hftypeid.Value, Session("UserId"))
            GridView1.DataBind()
            For Each row As GridViewRow In GridView1.Rows
                GridView1.HeaderRow.Cells(3).Visible = False
                row.Cells(3).Visible = False
            Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityUserControl", "GridView1_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btneventsave_Click(sender As Object, e As EventArgs) Handles btneventsave.Click
        Try
            If String.IsNullOrEmpty(txtfromdate.Text) Then
                txtfromdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            End If
            If String.IsNullOrEmpty(txtfromtime.Text) Then
                txtfromtime.Text = Date.Now.ToString("H:mm")
            End If
            If String.IsNullOrEmpty(txttodate.Text) Then
                txttodate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            End If
            If String.IsNullOrEmpty(txttotime.Text) Then
                txttotime.Text = Date.Now.Add(New TimeSpan(0, 30, 0)).ToString("H:mm")
            End If
            If String.IsNullOrEmpty(txtopeneventreminderdate.Text) Then
                txtopeneventreminderdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            End If
            If String.IsNullOrEmpty(txtopeneventremindertime.Text) Then
                txtopeneventremindertime.Text = Date.Now.ToString("H:mm:ss")
            End If
            FormDate = txtfromdate.Text.Trim
            FromTime = txtfromtime.Text
            FromDateTime = Convert.ToDateTime(FormDate + " " + FromTime)
            toDate = txttodate.Text.Trim
            Toime = txttotime.Text
            ReminderDate = txtopeneventreminderdate.Text.Trim
            Remindertime = txtopeneventremindertime.Text.Trim
            Reminderdatetime = Convert.ToDateTime(ReminderDate + " " + Remindertime)
            If ckopeneventreminder.Checked = True Then
                Reminder = 1
            Else
                Reminder = 0
            End If
            ToDateTime = Convert.ToDateTime(toDate + " " + Toime)
            ActivityBLL.InsertEvent(ddhost.SelectedValue, txteventname.Text.Trim, txtlocation.Text.Trim, FromDateTime, ToDateTime,
            hftype.Value, hftypeid.Value, Session("Audlog_Id"), Session("UserId"), ddeventprioritys.SelectedValue, Reminder, Reminderdatetime)
            If hftype.Value = "Lead" Then
                LeadBLL.UpdateLeadStage(hftypeid.Value, 12)
            End If
            FillOwner()
            mpeevent.Hide()
            Response.Redirect(Page.Request.RawUrl)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityUserControl", "btneventsave_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim row As GridViewRow = e.Row
                Dim data As DataRow = DirectCast(row.DataItem, DataRowView).Row
                Dim HyperLink1 As HyperLink = DirectCast(e.Row.FindControl("HyperLink1"), HyperLink)
                Dim lnk As LinkButton = DirectCast(e.Row.FindControl("lnk"), LinkButton)
                Dim ActivityID As Long = data.Field(Of Long)("Id")
                Select Case data.Field(Of String)("Activity Type")
                    Case "Task"
                        HyperLink1.NavigateUrl = Page.ResolveUrl("~/ActivityTask.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID)))
                        lnk.Visible = True
                        Exit Select
                    Case "Event"
                        HyperLink1.NavigateUrl = Page.ResolveUrl("~/ActivityEvent.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID)))
                        lnk.Visible = True
                        Exit Select
                    Case "Call"
                        HyperLink1.NavigateUrl = Page.ResolveUrl("~/ActivityCall.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID)))
                        lnk.Visible = True
                        Exit Select
                End Select
                If e.Row.RowType = DataControlRowType.DataRow Then
                    For Each cell As TableCell In e.Row.Cells
                        Dim littext As String = cell.Text
                        Dim Literals As Label = New Label()
                        If (cell.Text = "Pending" Or cell.Text = "Due") Then
                            Literals.CssClass = "label label-warning"
                        ElseIf (cell.Text = "Missed") Then
                            Literals.CssClass = "label label-danger"
                        ElseIf (cell.Text = "Today") Then
                            Literals.CssClass = "label label-success"
                        ElseIf (cell.Text = "Tommorrow" Or cell.Text = "Close Postpone") Then
                            Literals.CssClass = "label label-info"
                        End If
                        If cell.Text = "High" Then
                            Literals.CssClass = "label label-danger"
                        ElseIf cell.Text = "Highest" Then
                            Literals.CssClass = "label label-danger"
                        ElseIf cell.Text = "Lowest" Then
                            Literals.CssClass = "label label-warning"
                        ElseIf cell.Text = "Low" Then
                            Literals.CssClass = "label label-warning"
                        ElseIf cell.Text = "Normal" Then
                            Literals.CssClass = "label label-info"
                        End If
                        If (cell.Text = "Event") Then
                            littext = "Sampling/Demo"
                        ElseIf (cell.Text = "Call") Then
                            littext = "Phone/Email"
                        End If
                        Literals.EnableViewState = True
                        Literals.Text = littext
                        cell.Controls.Add(Literals)
                    Next
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityUserControl", "GridView1_RowDataBound", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btncalladd_Click(sender As Object, e As EventArgs) Handles btncalladd.Click
        Try
            If String.IsNullOrEmpty(txtdate.Text) Then
                txtdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            End If
            If String.IsNullOrEmpty(txtstarttime.Text) Then
                txtstarttime.Text = Date.Now.ToString("H:mm:ss")
            End If
            If String.IsNullOrEmpty(txtendtime.Text) Then
                txtendtime.Text = Date.Now.Add(New TimeSpan(0, 1, 0)).ToString("H:mm:ss")
            End If
            If String.IsNullOrEmpty(txtopencallremindrdate.Text) Then
                txtopencallremindrdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            End If
            If String.IsNullOrEmpty(txtopencallremindrtime.Text) Then
                txtopencallremindrtime.Text = Date.Now.ToString("H:mm:ss")
            End If
            FormDate = txtdate.Text.Trim
            FromTime = txtstarttime.Text.Trim
            FromDateTime = Convert.ToDateTime(FormDate + " " + FromTime)
            toDate = txtdate.Text.Trim
            Toime = txtendtime.Text
            ToDateTime = Convert.ToDateTime(toDate + " " + Toime)
            ReminderDate = txtopencallremindrdate.Text.Trim
            Remindertime = txtopencallremindrtime.Text.Trim
            Reminderdatetime = Convert.ToDateTime(ReminderDate + " " + Remindertime)
            If ckopencallreminder.Checked = True Then
                Reminder = 1
            Else
                Reminder = 0
            End If
            ActivityBLL.InsertCall(TextBox1.Text, ddcalltype.SelectedValue, FromDateTime, ToDateTime, hftype.Value, hftypeid.Value,
            Session("Audlog_Id"), ddcallpurpose.SelectedValue, Session("UserId"), ddcallpriority.SelectedValue, Reminder, Reminderdatetime)
            If hftype.Value = "Lead" Then
                LeadBLL.UpdateLeadStage(hftypeid.Value, 12)
            End If
            FillOwner()
            mpecall.Hide()
            Response.Redirect(Page.Request.RawUrl)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityUserControl", "btncalladd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillTodayTask()
        Try
            rptasktoday.DataSource = ActivityBLL.FillTaskTypeById(hftype.Value, hftypeid.Value, Session("UserId"), "FillTaskTodaybyAssign")
            rptasktoday.DataBind()
            If rptasktoday.Items.Count <= 0 Then
                headtoday.Visible = False
                lbltoday.Visible = True
            Else
                headtoday.Visible = True
                lbltoday.Visible = False
                Total = Total + rptasktoday.Items.Count
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityUserControl", "FillTodayTask", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillTaskOverDue()
        Try
            rpoverdue.DataSource = ActivityBLL.FillTaskTypeById(hftype.Value, hftypeid.Value, Session("UserId"), "FillTaskOverduebyAssign")
            rpoverdue.DataBind()
            If rpoverdue.Items.Count <= 0 Then
                headoverdue.Visible = False
                lbloverdue.Visible = True
            Else
                headoverdue.Visible = True
                lbloverdue.Visible = False
                Total = Total + rpoverdue.Items.Count
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityUserControl", "FillTaskOverDue", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillTommorrowTask()
        Try
            rptasktommorrow.DataSource = ActivityBLL.FillTaskTypeById(hftype.Value, hftypeid.Value, Session("UserId"), "FillTaskTomorrowbyAssign")
            rptasktommorrow.DataBind()
            If rptasktommorrow.Items.Count <= 0 Then
                headtommorrow.Visible = False
                lbltommorrow.Visible = True
            Else
                headtommorrow.Visible = True
                lbltommorrow.Visible = False
                Total = Total + rptasktommorrow.Items.Count
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityUserControl", "FillTommorrowTask", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillDDOwner()
        Try
            ddowner.DataSource = MainBLL.Dropdown("UserDropDown")
            ddowner.DataTextField = "U_FirstName"
            ddowner.DataValueField = "U_ID"
            ddowner.DataBind()
            ddhost.DataSource = MainBLL.Dropdown("UserDropDown")
            ddhost.DataTextField = "U_FirstName"
            ddhost.DataValueField = "U_ID"
            ddhost.DataBind()
            ddowner.SelectedValue = Session("UserId")
            ddhost.SelectedValue = Session("UserId")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityUserControl", "FillDDOwner", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView2_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView2.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim row As GridViewRow = e.Row
                Dim data As DataRow = DirectCast(row.DataItem, DataRowView).Row
                Dim HyperLink1 As HyperLink = DirectCast(e.Row.FindControl("HyperLink1"), HyperLink)
                Dim ActivityID As Long = data.Field(Of Long)("Id")
                Select Case data.Field(Of String)("Activity Type")
                    Case "Task"
                        HyperLink1.NavigateUrl = Page.ResolveUrl("~/ActivityTask.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID)))
                        Exit Select
                    Case "Event"
                        HyperLink1.NavigateUrl = Page.ResolveUrl("~/ActivityEvent.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID)))
                        Exit Select
                    Case "Call"
                        HyperLink1.NavigateUrl = Page.ResolveUrl("~/ActivityCall.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID)))
                        Exit Select
                End Select
                If e.Row.RowType = DataControlRowType.DataRow Then
                    For Each cell As TableCell In e.Row.Cells
                        Dim littext As String = cell.Text
                        Dim Literals As Label = New Label()
                        If (cell.Text = "Close") Then
                            Literals.CssClass = "label label-danger"
                        End If
                        If cell.Text = "High" Then
                            Literals.CssClass = "label label-danger"
                        ElseIf cell.Text = "Highest" Then
                            Literals.CssClass = "label label-danger"
                        ElseIf cell.Text = "Lowest" Then
                            Literals.CssClass = "label label-warning"
                        ElseIf cell.Text = "Low" Then
                            Literals.CssClass = "label label-warning"
                        ElseIf cell.Text = "Normal" Then
                            Literals.CssClass = "label label-info"
                        End If
                        If (cell.Text = "Event") Then
                            littext = "Sampling/Demo"
                        ElseIf (cell.Text = "Call") Then
                            littext = "Phone/Email"
                        End If
                        Literals.EnableViewState = True
                        Literals.Text = littext
                        cell.Controls.Add(Literals)
                    Next
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityUserControl", "GridView2_RowDataBound", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        Try
            GridView2.PageIndex = e.NewPageIndex
            GridView2.DataSource = ActivityBLL.FillCloseActivityByRelatedType(hftype.Value, hftypeid.Value, Session("UserId"))
            GridView2.DataBind()
            For Each row As GridViewRow In GridView2.Rows
                GridView2.HeaderRow.Cells(1).Visible = False
                row.Cells(1).Visible = False
                GridView2.HeaderRow.Cells(2).Visible = False
                row.Cells(2).Visible = False
            Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityUserControl", "GridView2_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
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
                hftype.Value, hftypeid.Value, ddfollowpriority.SelectedValue, Session("Audlog_Id"), Session("UserId"), FromDateTime, ToDateTime, hfactivityid.Value, Reminder, Reminderdatetime)
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
            ActivityBLL.UpdateFollowActivity(Session("UserId"), hfactivityid.Value, txtdvresult.Text.Trim)
            FillOwner()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("NoteControl", "SaveProduct", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ckcreatefollowupactvt_CheckedChanged(sender As Object, e As EventArgs) Handles ckcreatefollowupactvt.CheckedChanged
        If ckcreatefollowupactvt.Checked = True Then
            divtask.Visible = True
            divcall.Visible = False
            divevent.Visible = False
            btnfollowsave.ValidationGroup = "FollowTaskMasterGroup"
            ddtype.Visible = True
            mpefollowup.Show()
        Else
            divtask.Visible = False
            divcall.Visible = False
            divevent.Visible = False
            ddtype.Visible = False
            mpefollowup.Show()
        End If
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
            txtpostponedate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            txtpostponestart.Text = Date.Now.ToString("H:mm")
            txtpostponeend.Text = Date.Now.Add(New TimeSpan(0, 1, 0)).ToString("H:mm")
            txtpostreminderdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            txtpostremindertime.Text = Date.Now.ToString("H:mm")
            dvresult.Visible = True
            mpclose.Show()
        End If
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
            ActivityBLL.InsertPostpone(FromDateTime, ToDateTime, hfactivityid.Value, Reminder, Reminderdatetime, txtdvresult.Text.Trim)
            FillOwner()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GridView2_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView2.RowCommand
        Try
            If e.CommandName = "Closing" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                hfactivityid.Value = GridView1.DataKeys(index).Value()
                Try
                    txtremark.Text = ""
                    dateTimeFuntion1()
                    mpclose.Show()
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ActivityUserControl", "GridView1_RowCommand", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            ElseIf e.CommandName = "Viewing" Then
                Dim ID As Integer = 0
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Dim row As GridViewRow = GridView2.Rows(index)
                ID = GridView2.DataKeys(index).Value
                lvnote.DataSource = NoteBLL.NoteActivWithAssReverse(Session("UserId"), ID)
                lvnote.DataBind()
                grdactivityhistory.DataSource = MainBLL.ViewByID(ID, "ActivityHistory")
                grdactivityhistory.DataBind()
                hfmainactivityid.Value = ID
                hfreltypeId.Value = hftypeid.Value
                hfreltype.Value = hftype.Value
                Dim dt As DataSet
                ddtype.SelectedValue = "Task"
                divtask.Visible = True
                divcall.Visible = False
                divevent.Visible = False
                btnfollowsave.ValidationGroup = "FollowTaskMasterGroup"
                If hfreltype.Value = "Account" Or hfreltype.Value = "Prospect" Then
                    dt = NoteBLL.RecentActivity(ID, hfreltype.Value, hfreltypeId.Value)
                    trcontact.Visible = True
                    Dim dtUser As New DataTable
                    dtUser = dt.Tables(0)
                    Dim drLogin As DataRow
                    drLogin = dtUser.Rows(0)
                    lblname.Text = hfreltype.Value + " Name"
                    lblsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                    ltstartdate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                    ltenddate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                    lblaccname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
                    ltpriority.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                    ltowner.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                    If ltpriority.Text = "High" Then
                        ltpriority.CssClass = "label label-success"
                    ElseIf ltpriority.Text = "Highest" Then
                        ltpriority.CssClass = "label label-success"
                    ElseIf ltpriority.Text = "Lowest" Then
                        ltpriority.CssClass = "label label-danger"
                    ElseIf ltpriority.Text = "Low" Then
                        ltpriority.CssClass = "label label-warning"
                    ElseIf ltpriority.Text = "Normal" Then
                        ltpriority.CssClass = "label label-info"
                    End If
                    ltstatus.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                    If ltstatus.Text = "Close" Then
                        ltstatus.CssClass = "label label-success"
                    ElseIf ltstatus.Text = "Close Postpone" Then
                        ltstatus.CssClass = "label label-info"
                    ElseIf ltstatus.Text = "Pending" Then
                        ltstatus.CssClass = "label label-warning"
                    ElseIf ltstatus.Text = "Today" Then
                        ltstatus.CssClass = "label label-success"
                    ElseIf (ltstatus.Text = "Missed") Then
                        ltstatus.CssClass = "label label-danger"
                    ElseIf (ltstatus.Text = "Tommorrow") Then
                        ltstatus.CssClass = "label label-info"
                    End If
                    ltdesc.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                    ltresult.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                    ltcontact.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("ContactName").ToString())
                    'lblconatctd.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString())
                    hffollowactivityid.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Id").ToString())
                ElseIf hfreltype.Value = "Quotation" Then
                    dt = NoteBLL.ViewNoteQuotation(ID, hfreltypeId.Value)
                    Dim dtUser As New DataTable
                    dtUser = dt.Tables(0)
                    Dim drLogin As DataRow
                    drLogin = dtUser.Rows(0)
                    lblname.Text = "Quotation Name"
                    trcontact.Visible = False
                    lblsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                    ltstartdate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                    ltenddate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                    ltpriority.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                    ltowner.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                    If ltpriority.Text = "High" Then
                        ltpriority.CssClass = "label label-success"
                    ElseIf ltpriority.Text = "Highest" Then
                        ltpriority.CssClass = "label label-success"
                    ElseIf ltpriority.Text = "Lowest" Then
                        ltpriority.CssClass = "label label-danger"
                    ElseIf ltpriority.Text = "Low" Then
                        ltpriority.CssClass = "label label-warning"
                    ElseIf ltpriority.Text = "Normal" Then
                        ltpriority.CssClass = "label label-info"
                    End If
                    ltstatus.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                    If ltstatus.Text = "Close" Then
                        ltstatus.CssClass = "label label-success"
                    ElseIf ltstatus.Text = "Close Postpone" Then
                        ltstatus.CssClass = "label label-info"
                    ElseIf ltstatus.Text = "Pending" Then
                        ltstatus.CssClass = "label label-warning"
                    ElseIf ltstatus.Text = "Today" Then
                        ltstatus.CssClass = "label label-success"
                    ElseIf (ltstatus.Text = "Missed") Then
                        ltstatus.CssClass = "label label-danger"
                    ElseIf (ltstatus.Text = "Tommorrow") Then
                        ltstatus.CssClass = "label label-info"
                    End If
                    ltdesc.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                    ltresult.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                    lblaccname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_No").ToString()) + "-" + DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
                    'lblconatctd.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString())
                    hffollowactivityid.Value = ID
                ElseIf hfreltype.Value = "Opportunity" Then
                    dt = NoteBLL.ViewOpportunityByID(ID, hfreltypeId.Value)
                    Dim dtUser As New DataTable
                    dtUser = dt.Tables(0)
                    Dim drLogin As DataRow
                    drLogin = dtUser.Rows(0)
                    lblname.Text = "Opportunity Name"
                    lblaccname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity_Name").ToString()) + "-" + DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
                    trcontact.Visible = True
                    lblsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                    ltstartdate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                    ltenddate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                    ltpriority.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                    ltowner.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                    ltcontact.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("ContactName").ToString())
                    If ltpriority.Text = "High" Then
                        ltpriority.CssClass = "label label-success"
                    ElseIf ltpriority.Text = "Highest" Then
                        ltpriority.CssClass = "label label-success"
                    ElseIf ltpriority.Text = "Lowest" Then
                        ltpriority.CssClass = "label label-danger"
                    ElseIf ltpriority.Text = "Low" Then
                        ltpriority.CssClass = "label label-warning"
                    ElseIf ltpriority.Text = "Normal" Then
                        ltpriority.CssClass = "label label-info"
                    End If
                    ltstatus.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                    If ltstatus.Text = "Close" Then
                        ltstatus.CssClass = "label label-success"
                    ElseIf ltstatus.Text = "Close Postpone" Then
                        ltstatus.CssClass = "label label-info"
                    ElseIf ltstatus.Text = "Pending" Then
                        ltstatus.CssClass = "label label-warning"
                    ElseIf ltstatus.Text = "Today" Then
                        ltstatus.CssClass = "label label-success"
                    ElseIf (ltstatus.Text = "Missed") Then
                        ltstatus.CssClass = "label label-danger"
                    ElseIf (ltstatus.Text = "Tommorrow") Then
                        ltstatus.CssClass = "label label-info"
                    End If
                    ltdesc.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                    ltresult.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                    hffollowactivityid.Value = ID
                ElseIf hfreltype.Value = "Lead" Then
                    dt = NoteBLL.ViewLeadViewByID(ID, hfreltypeId.Value)
                    Dim dtUser As New DataTable
                    dtUser = dt.Tables(0)
                    Dim drLogin As DataRow
                    drLogin = dtUser.Rows(0)
                    lblname.Text = "Lead Name"
                    lblaccname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead_Name").ToString())
                    trcontact.Visible = True
                    lblsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                    ltstartdate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                    ltenddate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                    ltpriority.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                    ltowner.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                    ltcontact.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("ContactName").ToString())
                    If ltpriority.Text = "High" Then
                        ltpriority.CssClass = "label label-success"
                    ElseIf ltpriority.Text = "Highest" Then
                        ltpriority.CssClass = "label label-success"
                    ElseIf ltpriority.Text = "Lowest" Then
                        ltpriority.CssClass = "label label-danger"
                    ElseIf ltpriority.Text = "Low" Then
                        ltpriority.CssClass = "label label-warning"
                    ElseIf ltpriority.Text = "Normal" Then
                        ltpriority.CssClass = "label label-info"
                    End If
                    ltstatus.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                    If ltstatus.Text = "Close" Then
                        ltstatus.CssClass = "label label-success"
                    ElseIf ltstatus.Text = "Close Postpone" Then
                        ltstatus.CssClass = "label label-info"
                    ElseIf ltstatus.Text = "Pending" Then
                        ltstatus.CssClass = "label label-warning"
                    ElseIf ltstatus.Text = "Today" Then
                        ltstatus.CssClass = "label label-success"
                    ElseIf (ltstatus.Text = "Missed") Then
                        ltstatus.CssClass = "label label-danger"
                    ElseIf (ltstatus.Text = "Tommorrow") Then
                        ltstatus.CssClass = "label label-info"
                    End If
                    ltdesc.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                    ltresult.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                    hffollowactivityid.Value = ID
                End If
                dateTimeFuntion1()
                Dim ds As DataSet = MainBLL.Dropdown("UserDropDown")
                ckcreatefollowupactvt.Checked = False
                divtask.Visible = False
                divcall.Visible = False
                divevent.Visible = False
                ddtype.Visible = False
                txtname.Text = ""
                mpefollowup.Show()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityUserControl", "GridView1_RowCommand", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    

#End Region

   
End Class
