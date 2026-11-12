

Imports DynamicparcelEnumerations

Partial Class dsr
    Inherits System.Web.UI.Page
    Dim MainID As Integer
    Dim ContactID As Integer
    Dim RelatedID As Integer
    Dim ConatctType As String
    Dim RelatedType As String
    Dim returnurl As String
    Dim FormDate As String, FormMailDate As String, FromTime As String, FromDateTime As String, billable As Boolean
    Dim toDate As String, Toime As String, ToDateTime As String
    Dim FromDateTimeRem As String, ToDateTimeRem As String
    Dim ReminderDate As String, Remindertime As String, Reminderdatetime As String, Reminder As Boolean

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
            Try
                If Not IsPostBack Then
                    If (Request.QueryString("Id") = Nothing) Then
                        Response.Redirect("index.aspx")
                    Else
                        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                        txtstarttime.Text = Date.Now.Add(New TimeSpan(-1, 0, 0)).ToString("H:mm")
                        txtstarttimeRem.Text = Date.Now.ToString("H:mm")
                        txtendtime.Text = Date.Now.ToString("H:mm")
                        FillOwner()
                        FillDesignation()
                        FillCountry()
                        FillStatebill()
                        txtTodayDate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                        txtduedate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                        txtleaddate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                        txtReminderDate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                        If MainID = 0 Then
                            lbltitle1.Text = "New DSR"
                            lbltitle2.Text = "New DSR"

                            assigncontrol.Uhftype.Value = "ActivityTask"
                            assigncontrol.Uhftypeid.Value = MainID
                            ddowner.SelectedValue = Session("UserId")
                            notecontrol.Visible = False
                            divstatus.Visible = False
                            Fillddrelatedtypeid()
                            FillddlDate()
                            rblAction.SelectedValue = "CALL"
                            rblAction_SelectedIndexChanged(Nothing, Nothing)
                        Else
                            lbltitle1.Text = "Modify DSR"
                            lbltitle2.Text = "Modify DSR"

                            FillDetail()
                            txtstarttime.ReadOnly = True
                            txtstarttimeRem.ReadOnly = True
                            txtendtime.ReadOnly = True
                            '  txtdate.Enabled = False
                            ddrelatedtypeid.CssClass = "select-select2"
                            'ddrelatedtypeid.Attributes.Add("class", "select-chosen form-control")
                            ddcontactypeid.CssClass = "form-control"
                            ddlDate.CssClass = "form-control"
                            'ddrelatedtype.Enabled = False
                            ddrelatedtypeid.Enabled = False
                            ddcontactypeid.Enabled = False
                            ddlDate.Enabled = False
                            assigncontrol.Uhftype.Value = "ActivityTask"
                            assigncontrol.Uhftypeid.Value = MainID
                            notecontrol.Visible = True
                            notecontrol.Uhftype.Value = "Activity"
                            notecontrol.Uhftypeid.Value = MainID
                            divstatus.Visible = True
                        End If
                    End If
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ActivitTask", "Page_Load", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        Else
            Try
                If Not IsPostBack Then
                    If (Request.QueryString("Id") = Nothing) Then
                        Response.Redirect("index.aspx")
                    Else
                        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                        txtstarttime.Text = Date.Now.Add(New TimeSpan(-1, 0, 0)).ToString("H:mm")
                        txtstarttimeRem.Text = Date.Now.ToString("H:mm")
                        txtendtime.Text = Date.Now.ToString("H:mm")
                        FillOwner()
                        FillDesignation()
                        FillCountry()
                        FillStatebill()
                        txtTodayDate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                        txtduedate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                        txtleaddate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                        txtReminderDate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                        If MainID = 0 Then
                            lbltitle1.Text = "New DSR"
                            lbltitle2.Text = "New DSR"

                            assigncontrol.Uhftype.Value = "ActivityTask"
                            assigncontrol.Uhftypeid.Value = MainID
                            ddowner.SelectedValue = Session("UserId")
                            notecontrol.Visible = False
                            divstatus.Visible = False
                            Fillddrelatedtypeid()
                            FillddlDate()
                            rblAction.SelectedValue = "CALL"
                            rblAction_SelectedIndexChanged(Nothing, Nothing)
                        Else
                            lbltitle1.Text = "Modify DSR"
                            lbltitle2.Text = "Modify DSR"

                            FillDetail()
                            FillddlDate()
                            txtstarttime.ReadOnly = True
                            txtstarttimeRem.ReadOnly = True
                            txtendtime.ReadOnly = True

                            '   txtdate.Enabled = False
                            ddrelatedtypeid.CssClass = "select-select2"
                            'ddrelatedtypeid.Attributes.Add("class", "select-chosen")
                            ddcontactypeid.CssClass = "form-control"
                            ddlDate.CssClass = "form-control"
                            'ddrelatedtype.Enabled = False
                            ddrelatedtypeid.Enabled = False
                            ddcontactypeid.Enabled = False
                            ddlDate.Enabled = False
                            assigncontrol.Uhftype.Value = "ActivityTask"
                            assigncontrol.Uhftypeid.Value = MainID
                            notecontrol.Visible = True
                            notecontrol.Uhftype.Value = "Activity"
                            notecontrol.Uhftypeid.Value = MainID
                            divstatus.Visible = True
                        End If
                    End If
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ActivitTask", "Page_Load", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
    End Sub

    Protected Sub ddcontactype_TextChanged(sender As Object, e As EventArgs) Handles ddcontactype.TextChanged
        Try
            If ddcontactype.SelectedValue = "Lead" Then
                Dim ds As DataSet
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                If MainID = 0 Then
                    ds = MainBLL.DropdownWithID("LeadContactDropDown", Session("UserId"))
                Else
                    ds = MainBLL.Dropdown("EditLeadContactDropDown")
                End If
                ddcontactypeid.DataSource = ds
                ddcontactypeid.DataTextField = "LeadContact_Name"
                ddcontactypeid.DataValueField = "LeadContact_Id"
                ddcontactypeid.DataBind()
                'ddrelatedtype.SelectedValue = "Lead"
                ddrelatedtypeid.DataSource = ds
                ddrelatedtypeid.DataTextField = "Lead_Name"
                ddrelatedtypeid.DataValueField = "Lead_Id"
                ddrelatedtypeid.DataBind()
            ElseIf (ddcontactype.SelectedValue = "Contact") Then
                ' ddrelatedtype.SelectedValue = "Prospect"
                Dim ds As DataSet
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                If MainID = 0 Then
                    ds = MainBLL.DropdownWithtypeAndID("AccountDropDown", "Prospect", Session("UserId"))
                Else
                    ds = MainBLL.DropdownWithtype("EditAccountDropDown", "Prospect")
                End If
                ddrelatedtypeid.DataSource = ds
                ddrelatedtypeid.DataTextField = "Acc_Name"
                ddrelatedtypeid.DataValueField = "Acc_Id"
                ddrelatedtypeid.DataBind()
                ddcontactypeid.DataSource = MainBLL.DropdownWithtypeAndID("ContacttDropDown", "Prospect", ddrelatedtypeid.SelectedValue)
                ddcontactypeid.DataTextField = "Contact_ContactPerson"
                ddcontactypeid.DataValueField = "Contact_Id"
                ddcontactypeid.DataBind()
            ElseIf (ddcontactype.SelectedValue = "None") Then
                ddcontactypeid.DataSource = ""
                ddcontactypeid.DataBind()
                'ddrelatedtypeid.DataSource = ""
                'ddrelatedtypeid.DataBind()
                'ddrelatedtype.SelectedValue = "None"
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivitTask", "ddcontactype_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddrelatedtype_TextChanged(sender As Object, e As EventArgs) Handles ddrelatedtype.TextChanged
        Try
            If ddrelatedtype.SelectedValue = "Lead" Then
                Dim ds As DataSet
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                If MainID = 0 Then
                    ds = MainBLL.DropdownWithID("LeadContactDropDown", Session("UserId"))
                Else
                    ds = MainBLL.Dropdown("EditLeadContactDropDown")
                End If
                If ds.Tables(0).Rows.Count >= 1 Then
                    ddcontactypeid.DataSource = ds
                    ddcontactypeid.DataTextField = "LeadContact_Name"
                    ddcontactypeid.DataValueField = "LeadContact_Id"
                    ddcontactypeid.DataBind()
                    ddcontactype.SelectedValue = "Lead"
                    ddrelatedtypeid.DataSource = ds
                    ddrelatedtypeid.DataTextField = "Lead_Name"
                    ddrelatedtypeid.DataValueField = "Lead_Id"
                    ddrelatedtypeid.DataBind()
                Else
                    ddrelatedtype.SelectedValue = "None"
                    ddcontactypeid.DataSource = ""
                    ddcontactypeid.DataBind()
                    ddrelatedtypeid.DataSource = ""
                    ddrelatedtypeid.DataBind()
                    ddcontactype.SelectedValue = "None"
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + ("No lead found").ToString + "')", True)
                End If
            ElseIf (ddrelatedtype.SelectedValue = "Prospect") Then
                ddcontactype.SelectedValue = "Contact"
                Dim ds As DataSet
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                If MainID = 0 Then
                    ds = MainBLL.DropdownWithtypeAndID("AccountDropDown", "Prospect", Session("UserId"))
                Else
                    ds = MainBLL.DropdownWithtype("EditAccountDropDown", "Prospect")
                End If
                If ds.Tables(0).Rows.Count >= 1 Then
                    ddrelatedtypeid.DataSource = ds
                    ddrelatedtypeid.DataTextField = "Acc_Name"
                    ddrelatedtypeid.DataValueField = "Acc_Id"
                    ddrelatedtypeid.DataBind()
                    If ds.Tables(0).Rows.Count >= 1 Then
                        ddcontactypeid.DataSource = MainBLL.DropdownWithtypeAndID("ContacttDropDown", "Prospect", ddrelatedtypeid.SelectedValue)
                        ddcontactypeid.DataTextField = "Contact_ContactPerson"
                        ddcontactypeid.DataValueField = "Contact_Id"
                        ddcontactypeid.DataBind()
                    End If
                Else
                    ddrelatedtype.SelectedValue = "None"
                    ddcontactypeid.DataSource = ""
                    ddcontactypeid.DataBind()
                    ddrelatedtypeid.DataSource = ""
                    ddrelatedtypeid.DataBind()
                    ddcontactype.SelectedValue = "None"
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + ("No prospect found").ToString + "')", True)
                End If
            ElseIf (ddrelatedtype.SelectedValue = "Account") Then
                ddcontactype.SelectedValue = "Contact"
                Dim ds As DataSet = MainBLL.DropdownWithtypeAndID("AccountDropDown", "Account", Session("UserId"))
                If ds.Tables(0).Rows.Count >= 1 Then
                    ddrelatedtypeid.DataSource = ds
                    ddrelatedtypeid.DataTextField = "Acc_Name"
                    ddrelatedtypeid.DataValueField = "Acc_Id"
                    ddrelatedtypeid.DataBind()
                    If ds.Tables(0).Rows.Count >= 1 Then
                        ddcontactypeid.DataSource = MainBLL.DropdownWithtypeAndID("ContacttDropDown", "Account", ddrelatedtypeid.SelectedValue)
                        ddcontactypeid.DataTextField = "Contact_ContactPerson"
                        ddcontactypeid.DataValueField = "Contact_Id"
                        ddcontactypeid.DataBind()
                    End If
                Else
                    ddrelatedtype.SelectedValue = "None"
                    ddcontactypeid.DataSource = ""
                    ddcontactypeid.DataBind()
                    ddrelatedtypeid.DataSource = ""
                    ddrelatedtypeid.DataBind()
                    ddcontactype.SelectedValue = "None"
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + ("No account found").ToString + "')", True)
                End If


            ElseIf (ddrelatedtype.SelectedValue = "None") Then
                ddcontactypeid.DataSource = ""
                ddcontactypeid.DataBind()
                ddrelatedtypeid.DataSource = ""
                ddrelatedtypeid.DataBind()
                ddcontactype.SelectedValue = "None"
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivitTask", "ddrelatedtype_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If MainID = 0 Then
                SaveProduct(DML_OPERATION.INSERT)
            ElseIf MainID > 0 Then
                SaveProduct(DML_OPERATION.UPDATE)
            End If
            Dim host As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) ' HttpContext.Current.Request.Url.Host

            If host = "http://mcrm.swissbake.ch" Then
                'Response.Redirect("index1.aspx")
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "alert", " alert('Activity details shared with Contact Person for feedback.\n आपकी  एक्टिविटी के डिटेल्स कांटेक्ट पर्सन के साथ शेयर किये गए है उनका फीडबैक जानने के लिए'); window.open('index1.aspx', '_self');", True)
            Else
                'Response.Redirect("Activity.aspx")
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "alert", " alert('Activity details shared with Contact Person for feedback.\n आपकी  एक्टिविटी के डिटेल्स कांटेक्ट पर्सन के साथ शेयर किये गए है उनका फीडबैक जानने के लिए'); window.open('Activity.aspx', '_self');", True)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivitTask", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillOwner()
        Try
            ddowner.DataSource = MainBLL.Dropdown("UserDropDown")
            ddowner.DataTextField = "U_FirstName"
            ddowner.DataValueField = "U_ID"
            ddowner.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivitTask", "FillOwner", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try
                    Dim str As String = ddrelatedtypeid.SelectedValue

                    Dim strArr() As String
                    strArr = str.Split("-")

                    If ddcontactypeid.SelectedValue = "" Then
                        ContactID = 0
                        ConatctType = "None"
                    Else
                        ContactID = ddcontactypeid.SelectedValue
                        ConatctType = strArr(1)

                    End If
                    If ddrelatedtypeid.SelectedValue = "" Then
                        RelatedID = 0
                        RelatedType = "None"
                    Else
                        ' RelatedID = Session("RelatedID")
                        'RelatedType = Session("Related")
                        RelatedID = Convert.ToInt32(strArr(0))
                        RelatedType = strArr(1)

                    End If
                    'If String.IsNullOrEmpty(ddlDate.Text) Then
                    '    ddlDate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                    'End If
                    If String.IsNullOrEmpty(txtstarttime.Text) Then
                        txtstarttime.Text = Date.Now.ToString("H:mm:ss")
                    End If

                    If String.IsNullOrEmpty(txtendtime.Text) Then
                        txtendtime.Text = Date.Now.Add(New TimeSpan(0, 1, 0)).ToString("H:mm:ss")
                    End If
                    Dim a As String = Session("ddlDate")
                    'Dim a As String = ddlDate.SelectedValue.ToString()
                    FormDate = DynamicparcelDataManipulation.DateFormat(a)
                    FromTime = txtstarttime.Text.Trim
                    FromDateTime = Convert.ToDateTime(FormDate + " " + FromTime)
                    toDate = Session("ddlDate")
                    Toime = txtendtime.Text
                    ToDateTime = Convert.ToDateTime(toDate + " " + Toime)

                    ReminderDate = FormDate
                    Remindertime = FromTime
                    Reminderdatetime = Convert.ToDateTime(ReminderDate + " " + Remindertime)
                    Reminder = 0
                    Dim Subj As String
                    If rblAction.SelectedValue = "CALL" Then
                        Subj = ddlSubJCall.Text.Trim
                    ElseIf rblAction.SelectedValue = "MEETING" Then
                        Subj = ddlSubJMeet.Text.Trim
                    ElseIf rblAction.SelectedValue = "OTHERS" Then
                        Subj = ddlSubJOther.Text.Trim
                    End If
                    ' ''ActivityBLL.UpdateTask(ddowner.SelectedValue, txtsubject.Text.Trim, ddstatus.SelectedValue, txtduedate.Text.Trim,
                    ' ''"DSR", RelatedType, RelatedID, ConatctType, ContactID,
                    ' ''ddpriority.SelectedValue, Session("Audlog_Id"), txtdec.Text.Trim, txtresult.Text.Trim, Session("UserId"), MainID, FromDateTime, ToDateTime, Reminder, Reminderdatetime)
                    ActivityBLL.UpdateTask(ddowner.SelectedValue, Subj, ddstatus.SelectedValue, txtduedate.Text.Trim,
                    "DSR", RelatedType, RelatedID, ConatctType, ContactID,
                    ddpriority.SelectedValue, Session("Audlog_Id"), txtdec.Text.Trim, txtresult.Text.Trim, Session("UserId"), MainID, FromDateTime, ToDateTime, Reminder, Reminderdatetime)
                    assigncontrol.AddAssignTo(MainID)
                    If RelatedType = "Lead" Then
                        LeadBLL.UpdateLeadStage(RelatedID, 12)
                    End If

                    'Reminder
                    ActivityBLL.UpdateTask(ddowner.SelectedValue, Subj, ddstatus.SelectedValue, txtduedate.Text.Trim,
                    "Reminder", RelatedType, RelatedID, ConatctType, ContactID,
                    ddpriority.SelectedValue, Session("Audlog_Id"), txtdec.Text.Trim, txtresult.Text.Trim, Session("UserId"), MainID, FromDateTime, ToDateTime, Reminder, Reminderdatetime)
                    assigncontrol.AddAssignTo(MainID)

                    If Request.QueryString("returnurl") = Nothing Then
                        Dim host As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) ' HttpContext.Current.Request.Url.Host

                        If host = "http://mcrm.swissbake.ch" Then
                            Response.Redirect("index1.aspx")
                        Else
                            Response.Redirect("Activity.aspx")
                        End If
                    Else
                        returnurl = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("returnurl")))
                        Response.Redirect(returnurl)
                    End If
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ActivitTask", "UPDATE", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Case DML_OPERATION.INSERT
                Try
                    Dim str As String = ddrelatedtypeid.SelectedValue

                    Dim strArr() As String
                    strArr = str.Split("-")
                    ' Dim conID As Integer = Convert.ToInt32(strArr(0))

                    If ddcontactypeid.SelectedValue = "" Then
                        ContactID = 0
                        ConatctType = "None"
                    Else
                        ContactID = ddcontactypeid.SelectedValue
                        'ConatctType = ddcontactype.SelectedValue
                        ConatctType = strArr(1)
                    End If
                    If ddrelatedtypeid.SelectedValue = "" Then
                        RelatedID = 0
                        RelatedType = "None"
                    Else
                        'Dim str As String = ddrelatedtypeid.SelectedValue
                        'Dim strArr() As String
                        'strArr = str.Split("-")
                        RelatedID = Convert.ToInt32(strArr(0))

                        RelatedType = strArr(1)
                    End If
                    If String.IsNullOrEmpty(txtduedate.Text) Then
                        txtduedate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                    End If

                    If String.IsNullOrEmpty(ddlDate.Text) Then
                        ddlDate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                    End If

                    If String.IsNullOrEmpty(txtstarttime.Text) Then
                        txtstarttime.Text = Date.Now.ToString("H:mm:ss")
                    End If
                    If String.IsNullOrEmpty(txtendtime.Text) Then
                        txtendtime.Text = Date.Now.Add(New TimeSpan(0, 1, 0)).ToString("H:mm:ss")
                    End If

                    Dim a As String = ddlDate.SelectedValue.ToString()
                    FormDate = DynamicparcelDataManipulation.DateFormat(a)
                    FormMailDate = DynamicparcelDataManipulation.DateFormat(a)
                    FromTime = txtstarttime.Text.Trim
                    FromDateTime = Convert.ToDateTime(FormDate + " " + FromTime)

                    ReminderDate = FormDate
                    Remindertime = FromTime
                    Reminderdatetime = Convert.ToDateTime(ReminderDate + " " + Remindertime)
                    'toDate = ddlDate.Text.Trim
                    toDate = DynamicparcelDataManipulation.DateFormat(a)
                    'Toime = txtendtime.Text
                    Toime = Convert.ToDateTime(FromDateTime).Add(New TimeSpan(1, 0, 0)).ToString("H:mm:ss")
                    ToDateTime = Convert.ToDateTime(toDate + " " + Toime)
                    Reminder = 0
                    Dim Subj As String
                    If rblAction.SelectedValue = "CALL" Then
                        Subj = ddlSubJCall.Text.Trim
                    ElseIf rblAction.SelectedValue = "MEETING" Then
                        Subj = ddlSubJMeet.Text.Trim
                    ElseIf rblAction.SelectedValue = "OTHERS" Then
                        Subj = ddlSubJOther.Text.Trim
                    End If
                    ' ''MainID = ActivityBLL.InsertFullTask(ddowner.SelectedValue, txtsubject.Text.Trim, "Close", txtduedate.Text.Trim,
                    ' ''"DSR", RelatedType, RelatedID, ConatctType, ContactID,
                    ' ''ddpriority.SelectedValue, Session("Audlog_Id"), txtdec.Text.Trim, txtresult.Text.Trim, Session("UserId"), FromDateTime, ToDateTime, Reminder, Reminderdatetime)
                    MainID = ActivityBLL.InsertFullTask(ddowner.SelectedValue, Subj, "Close", txtduedate.Text.Trim,
                    "DSR", RelatedType, RelatedID, ConatctType, ContactID,
                    ddpriority.SelectedValue, Session("Audlog_Id"), txtdec.Text.Trim, txtresult.Text.Trim, Session("UserId"), FromDateTime, ToDateTime, Reminder, Reminderdatetime)
                    'assigncontrol.AddAssignTo(MainID)
                    Dim Count As Integer = AssignToBLL.MaxAssignTo
                    Dim sb As New StringBuilder
                    sb.Append("<root>")
                    '  For i As Integer = 0 To HashAssignTo.Count - 1
                    sb.Append("<row Assignto_ID='" & Count.ToString & "' Assignto_UserID='" & Session("UserId") &
                             "' Assignto_Type='" & "ActivityTask" & "' Assignto_TypeID='" & MainID & "' Assignto_CreatedID='" & Session("UserId") &
                             "' Assignto_CreatedDate='" & DateAndTime.DateString & "' Assignto_ModifiedID='" & Session("UserId") & "' Assignto_ModifiedDate='" & DateAndTime.DateString &
                              "' Assignto_Del='0' Assignto_Status='Active' />")
                    Count = Count + 1
                    ' Next
                    sb.Append("</root>")
                    AssignToBLL.XMLInsert(sb.ToString, Session("Audlog_Id"), "ActivityTask")
                    ActivityBLL.ClosedActivity(MainID, "DSR Self Closed")

                    'Reminder
                    If ckreminder.Checked = True Then

                        Dim aa As String = txtReminderDate.Text.ToString()
                        FormDate = DynamicparcelDataManipulation.DateFormat(aa)
                        FromTime = txtstarttimeRem.Text.Trim
                        FromDateTimeRem = Convert.ToDateTime(FormDate + " " + FromTime)

                        ReminderDate = FormDate
                        Remindertime = FromTime
                        Reminderdatetime = Convert.ToDateTime(ReminderDate + " " + Remindertime)
                        'toDate = ddlDate.Text.Trim
                        toDate = DynamicparcelDataManipulation.DateFormat(aa)
                        'Toime = txtendtime.Text
                        Toime = Convert.ToDateTime(FromDateTimeRem).Add(New TimeSpan(1, 0, 0)).ToString("H:mm:ss")
                        ToDateTimeRem = Convert.ToDateTime(toDate + " " + Toime)
                        Dim RemID As Integer
                        RemID = ActivityBLL.InsertFullTask(ddowner.SelectedValue, Subj, "Pending", txtduedate.Text.Trim,
                        "Reminder", RelatedType, RelatedID, ConatctType, ContactID,
                        ddpriority.SelectedValue, Session("Audlog_Id"), txtdec.Text.Trim, txtresult.Text.Trim, Session("UserId"), FromDateTimeRem, ToDateTimeRem, Reminder, Reminderdatetime)
                        assigncontrol.AddAssignTo(RemID)

                    End If
                    'Mubyn
                    'If chkComment.Checked = True Then
                    If txtComments.Text <> "" Then

                        If hfRelateType.Value = "Lead" Then
                            NoteBLL.Insert(txtComments.Text.Trim, hfRelateType.Value, hfRelatedID.Value, Session("Audlog_Id"), Session("UserId"))
                        ElseIf hfRelateType.Value = "Prospect" Then
                            NoteBLL.Insert(txtComments.Text.Trim, hfRelateType.Value, hfRelatedID.Value, Session("Audlog_Id"), Session("UserId"))
                        ElseIf hfRelateType.Value = "Account" Then
                            NoteBLL.Insert(txtComments.Text.Trim, hfRelateType.Value, hfRelatedID.Value, Session("Audlog_Id"), Session("UserId"))
                        End If

                    End If
                    'End If
                    'Dim RateID As Integer = ActivityBLL.InsertRating(Session("UserId"), MainID, 0, 0, 0, "", "", Session("UserId"), "", "")
                    'SendRatingMail(Session("UserId"), MainID, FromDateTime, RelatedType, RelatedID)
                    'Temporary stop for mail 06-10-25 by Noor
                    'SendRatingMail(Session("UserId"), MainID, FormMailDate)
                    'If RelatedType = "Lead" Then
                    '    LeadBLL.UpdateLeadStage(RelatedID, 12)
                    'End If
                    'Response.Redirect("~/dsr.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt("0")))
                    'returnurl = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("returnurl")))
                    'Response.Redirect(returnurl)
                    'Response.Redirect("Activity.aspx")
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ActivitTask", "INSERT", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub
    Public Sub Fillddrelatedtypeid()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim ds As DataSet
            ' If MainID = 0 Then
            ds = SampleBLL.comanyDropdownWithID("CompanyDropDown", Session("UserID"))
            ddrelatedtypeid.DataSource = ds.Tables(0)
            ddrelatedtypeid.DataTextField = "Acc_Name"
            ddrelatedtypeid.DataValueField = "ID"
            ddrelatedtypeid.DataBind()
            ddrelatedtypeid.Items.Insert(0, New ListItem("Select Company", "0"))
            Dim asd As Integer = ds.Tables(0).Rows.Count
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")

            Throw ex
        End Try
    End Sub
    Public Sub FillddlDate()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If MainID = 0 Then
                Dim ds As DataSet
                ' If MainID = 0 Then
                ds = SampleBLL.DropdownWithPrevDate("PrevDateDropDown")
                ddlDate.DataSource = ds.Tables(0)
                ddlDate.DataTextField = "Date"
                ddlDate.DataValueField = "ID"
                ddlDate.DataBind()
                ddlDate.Items.Insert(0, New ListItem("Select Date", "0"))
            Else
                'Dim ds As DataSet
                'ddlDate.DataSource = ds.Tables(0)
                'ddlDate.Items.Insert(0, New ListItem("First Static", 0))
                ddlDate.Items.Insert(0, New ListItem("Select Date", "0"))
                ddlDate.Items.Insert(1, New ListItem(Session("ddlDate"), "1"))
                ' ddlDate.DataBind()
                ddlDate.SelectedValue = 1
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            Throw ex
        End Try
    End Sub
    Protected Sub ddcontactypeid_TextChanged(sender As Object, e As EventArgs) Handles ddcontactypeid.TextChanged
        Try
            Dim str As String = ddcontactypeid.SelectedValue

            If ddcontactype.SelectedValue = "Lead" Then
                ddrelatedtypeid.SelectedIndex = ddcontactypeid.SelectedIndex
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivitTask", "ddcontactypeid_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub ddrelatedtypeid_TextChanged(sender As Object, e As EventArgs) Handles ddrelatedtypeid.TextChanged
        Try
            If ddrelatedtypeid.SelectedValue = "0" Then
                lnkAddContact.Visible = False
            Else
                Dim str As String = ddrelatedtypeid.SelectedValue

                Dim strArr() As String
                strArr = str.Split("-")
                Dim conID As Integer = Convert.ToInt32(strArr(0))
                hfRelatedID.Value = strArr(0)
                hfRelateType.Value = strArr(1)
                FillContactDSR(strArr(1), conID)
                lnkAddContact.Visible = True
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivitTask", "ddrelatedtypeid_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub FillContactDSR(ByVal Type As String, ByVal conID As Integer)
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim ds As DataSet
            ' If MainID = 0 Then
            ds = SampleBLL.DropdownForAccountContact("ContactDSRDropDown", Type, conID)
            ddcontactypeid.DataSource = ds.Tables(0)
            ddcontactypeid.DataTextField = "Name"
            ddcontactypeid.DataValueField = "ID"
            ddcontactypeid.DataBind()
            'ddcontactypeid.Items.Insert(0, New ListItem("Select Contact", "0"))

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            Throw ex
        End Try
    End Sub
    'Public Sub FillContactLead(ByVal conID As Integer)
    '    Try
    '        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
    '        Dim ds As DataSet
    '        ' If MainID = 0 Then
    '        ds = SampleBLL.DropdownForLeadContact("ContactLeadDropDown", conID)
    '        ddcontactypeid.DataSource = ds.Tables(0)
    '        ddcontactypeid.DataTextField = "Name"
    '        ddcontactypeid.DataValueField = "ID"
    '        ddcontactypeid.DataBind()
    '        ddcontactypeid.Items.Insert(0, New ListItem("Select Contact", "0"))
    '        ''Else
    '        ''    ds = MainBLL.DropdownWithtype("EditAccountDropDown", "Prospect")
    '        ' End If
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        'ExecptionBLL.Insert("ModifyLead", "FillCountry", error1, Session("UserId"))
    '        'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '        Throw ex
    '    End Try
    'End Sub

    Public Sub FillDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "ActivityViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)

            ' ''txtsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
            Dim Subj As String
            Subj = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
            If Subj = "Sales Follow up" Or Subj = "Sample Follow up" Or Subj = "Payment Follow up" Or Subj = "General Call" Then
                rblAction.SelectedValue = "CALL"
                rblAction_SelectedIndexChanged(Nothing, Nothing)
                ddlSubJCall.Text = Subj
            ElseIf Subj = "Sales Meeting" Or Subj = "Demo" Or Subj = "Order Follow Up" Or Subj = "General Meeting" Or Subj = "Meeting" Or Subj = "Sampling Demo" Then
                rblAction.SelectedValue = "MEETING"
                rblAction_SelectedIndexChanged(Nothing, Nothing)
                ddlSubJMeet.Text = Subj
            ElseIf Subj = "Chat" Or Subj = "Email" Or Subj = "Email/Phone Call" Then
                rblAction.SelectedValue = "OTHERS"
                rblAction_SelectedIndexChanged(Nothing, Nothing)
                ddlSubJOther.Text = Subj
            End If
        
            ddowner.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Owner").ToString())
            Dim status As String = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
            ltstatus.Text = status
            If status = "Pending" Or status = "Due" Then
                divstatus.Attributes("class") = "alert alert-warning animation-fadeInQuick"
            ElseIf status = "Close" Or status = "Today" Then
                divstatus.Attributes("class") = "alert alert-success animation-fadeInQuick"
            ElseIf status = "Close Postpone" Or status = "Tommorrow" Then
                divstatus.Attributes("class") = "alert alert-info animation-fadeInQuick"
            ElseIf status = "Missed" Then
                divstatus.Attributes("class") = "alert alert-danger animation-fadeInQuick"
            End If
            txtdec.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
            txtresult.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
            'txtduedate.Text = DynamicparcelDataManipulation.DateFormat(drLogin("Activity_Duedate").ToString())
            ddpriority.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
            Dim cdt As Date = DynamicparcelDataManipulation.DateFormat(drLogin("Activity_CallStartTime").ToString())
            Session("ddlDate") = cdt
            ddlDate.Text = cdt.Date.ToString("yyyy-MM-dd")

            Dim cst As Date = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_CallStartTime").ToString())
            txtstarttime.Text = cst.ToString("H:mm")
            Dim cet As Date = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_CallEndTime").ToString())
            txtendtime.Text = cet.ToString("H:mm")
            ddrelatedtype.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_RelatedType").ToString())
            If ddrelatedtype.SelectedValue = "Prospect" Or ddrelatedtype.SelectedValue = "Lead" Then
                ddrelatedtype_TextChanged(Nothing, Nothing)
                ddrelatedtypeid.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_RelatedTypeID").ToString())
                If drLogin("Activity_ContactType") Is DBNull.Value Then
                    ddcontactype.SelectedValue = "Lead"
                    ddcontactypeid.SelectedIndex = ddrelatedtypeid.SelectedIndex
                Else
                    ddcontactype.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ContactType").ToString())
                    ddcontactype_TextChanged(Nothing, Nothing)
                    ddcontactypeid.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ContactTypeID").ToString())
                End If
            ElseIf ddrelatedtype.SelectedValue = "Account" Then
                ddcontactype.SelectedValue = "Contact"
                'Dim ds As DataSet = MainBLL.DropdownWithtypeAndID("AccountDropDown", "Account", Session("UserId"))
                Dim ds As DataSet = MainBLL.DropdownWithtype("EditAccountDropDown", "Account")
                ddrelatedtypeid.DataSource = ds
                ddrelatedtypeid.DataTextField = "Acc_Name"
                ddrelatedtypeid.DataValueField = "Acc_Id"
                ddrelatedtypeid.DataBind()
                ddrelatedtypeid.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_RelatedTypeID").ToString())
                ddcontactypeid.DataSource = MainBLL.DropdownWithtypeAndID("ContacttDropDown", "Account", ddrelatedtypeid.SelectedValue)
                ddcontactypeid.DataTextField = "Contact_ContactPerson"
                ddcontactypeid.DataValueField = "Contact_Id"
                ddcontactypeid.DataBind()
                ddcontactypeid.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ContactTypeID").ToString())
            ElseIf ddrelatedtype.SelectedValue = "Opportunity" Then
                ddcontactype.SelectedValue = "Contact"
                Dim TID As Integer = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ContactTypeID").ToString())
                'Dim ds As DataSet = MainBLL.DropdownWithID("OpportunityDropDown", Session("UserId"))
                Dim ds As DataSet = MainBLL.Dropdown("EditOpportunityDropDown")
                ddrelatedtypeid.DataSource = ds
                ddrelatedtypeid.DataTextField = "Opportunity_Name"
                ddrelatedtypeid.DataValueField = "Opportunity_Id"
                ddrelatedtypeid.DataBind()
                ddrelatedtypeid.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_RelatedTypeID").ToString())
                dt = MainBLL.ViewByID(ddrelatedtypeid.SelectedValue, "ViewOppTypeByID")
                dtUser = dt.Tables(0)
                drLogin = dtUser.Rows(0)
                ddcontactypeid.DataSource = MainBLL.DropdownWithtypeAndID("ContacttDropDown", drLogin("Opportunity_Type").ToString(), drLogin("Opportunity_TypeId").ToString())
                ddcontactypeid.DataTextField = "Contact_ContactPerson"
                ddcontactypeid.DataValueField = "Contact_Id"
                ddcontactypeid.DataBind()
                ddcontactypeid.SelectedValue = TID
            ElseIf ddrelatedtype.SelectedValue = "Quotation" Then
                Dim TID As Integer
                If (IsDBNull(drLogin("Activity_ContactTypeID"))) Then
                    TID = 0
                Else
                    TID = drLogin("Activity_ContactTypeID")
                End If

                ddrelatedtype_TextChanged(Nothing, Nothing)
                ddrelatedtypeid.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_RelatedTypeID").ToString())
                dt = MainBLL.ViewByID(ddrelatedtypeid.SelectedValue, "QuotationType")
                dtUser = dt.Tables(0)
                drLogin = dtUser.Rows(0)
                ddcontactypeid.DataSource = MainBLL.DropdownWithtypeAndID("ContacttDropDown", drLogin("Quotation_Type").ToString(), drLogin("Quotation_TypeID").ToString())
                ddcontactypeid.DataTextField = "Contact_ContactPerson"
                ddcontactypeid.DataValueField = "Contact_Id"
                ddcontactypeid.DataBind()
                If TID = 0 Then
                Else
                    ddcontactypeid.SelectedValue = TID
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivitTask", "FillDetail", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub hfcancel_Click(sender As Object, e As EventArgs) Handles hfcancel.Click
        Try
            If Request.QueryString("returnurl") = Nothing Then
                ' Response.Redirect("Activity.aspx")

                Dim host As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) ' HttpContext.Current.Request.Url.Host

                If host = "http://mcrm.swissbake.ch" Then
                    Response.Redirect("index1.aspx")
                Else
                    Response.Redirect("Activity.aspx")
                End If
            Else
                returnurl = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("returnurl")))
                Response.Redirect(returnurl)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityCall", "hfcancel_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub





    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Try
            If Request.QueryString("returnurl") = Nothing Then
                Dim host As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) ' HttpContext.Current.Request.Url.Host

                If host = "http://mcrm.swissbake.ch" Then
                    Response.Redirect("index1.aspx")
                Else
                    Response.Redirect("Activity.aspx")
                End If
            Else
                returnurl = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("returnurl")))
                Response.Redirect(returnurl)
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityCall", "hfcancel_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub FillCountry()
        Try
            Dim ds As DataSet = MainBLL.Dropdown("CountryDropDown")
            ddlcountrybill.DataSource = ds.Tables(0)
            ddlcountrybill.DataTextField = "CountryName"
            ddlcountrybill.DataValueField = "Id"
            ddlcountrybill.DataBind()
            ddlcountrybill.Items.Insert(0, New ListItem("Select Country", "0"))
            If ddlLeadCategory.SelectedValue = "Domestic" Then
                ddlcountrybill.SelectedValue = 105
                ddlcountrybill.Enabled = False
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("DSR", "FillCountry", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Public Sub FillStatebill()
        Try
            ddlstatebill.Items.Clear()
            Dim ds As DataSet = MainBLL.DropdownWithID("StateDropDown", ddlcountrybill.SelectedValue)
            ddlstatebill.DataSource = ds.Tables(0)
            ddlstatebill.DataTextField = "StateName"
            ddlstatebill.DataValueField = "Id"
            ddlstatebill.DataBind()
            ddlstatebill.Items.Insert(0, New ListItem("Select State", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("DSR", "FillStatebill", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Protected Sub ddlcountrybill_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlcountrybill.SelectedIndexChanged
        Try
            FillStatebill()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("DSR", "ddlcountrybill_SelectedIndexChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub btnsavePop_Click(sender As Object, e As EventArgs) Handles btnsavePop.Click
        Try
            SaveProduct()
            'Response.Redirect(Request.RawUrl)


            'ddrelatedtype.SelectedValue = "Lead"
            'ddrelatedtypeid.SelectedValue=
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Lead", "btnsavePop_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub SaveProduct()
        Try
            MainID = LeadBLL.QuickLeadInsert(txtleaddate.Text.Trim, txtleadname.Text.Trim, 1, Session("UserId"), Session("UserId"), Session("Audlog_Id"), ddlLeadCategory.SelectedValue, "")
            Session("relatedtypeid") = MainID
            LeadContactBLL.QuickInsert(txtname.Text.Trim, txtemail.Text.Trim, txtmob.Text.Trim, txtofficeno.Text.Trim, txtextention.Text.Trim, Session("UserId"), MainID, Session("Audlog_Id"), True, "Email")
            LeadAddressBLL.Insert("", txtcitybill.Text, ddlstatebill.SelectedValue, ddlcountrybill.SelectedValue, "", Session("UserId"), MainID, "Billing", Session("Audlog_Id"))
            Dim count As Integer = 0
            count = AssignToBLL.MaxAssignTo
            Dim sb As New StringBuilder
            sb.Append("<root>")
            sb.Append("<row Assignto_ID='" & count.ToString & "' Assignto_UserID='" & Session("UserId") &
                     "' Assignto_Type='" & "Lead" & "' Assignto_TypeID='" & MainID & "' Assignto_CreatedID='" & Session("UserId") &
                     "' Assignto_CreatedDate='" & DateAndTime.DateString & "' Assignto_ModifiedID='" & Session("UserId") & "' Assignto_ModifiedDate='" & DateAndTime.DateString &
                      "' Assignto_Del='0' Assignto_Status='Active' />")
            count = count + 1
            sb.Append("</root>")
            AssignToBLL.XMLInsert(sb.ToString, Session("Audlog_Id"), "Lead")
            'GridView1.PageIndex = GridView1.PageIndex
            'fillLead()
            mpe.Hide()
            'ddrelatedtype.SelectedValue = "Lead"
            ' ddrelatedtype_TextChanged(Nothing, Nothing)
            'ddcontactypeid_TextChanged(Nothing, Nothing)
            Fillddrelatedtypeid()
            ddrelatedtypeid.SelectedValue = Convert.ToString(DynamicparcelDataManipulation.FixNullFromDB(Session("relatedtypeid"))) + "-Lead"
            ddrelatedtypeid_TextChanged(Nothing, Nothing)
            '  ddcontactypeid_TextChanged(Nothing, Nothing)

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Lead", "SaveProduct", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub


    Protected Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        'Default Private Property Item(ByVal Optional  As MasterPageFile = "~/MasterPage2.master") 
        Dim host As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) ' HttpContext.Current.Request.Url.Host
        ' Dim url As String

        If host = "http://mcrm.swissbake.ch" Then
            Me.MasterPageFile = "MCRMMaster.master"

        End If

    End Sub
    Sub AtLeastOneContact_ServerValidate1(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        If txtemail.Text & txtmob.Text <> "" Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub
#Region "addContact"
    Public Sub FillDesignation()
        Dim ds As DataSet = MainBLL.Dropdown("B2bDesignationDropDown")
        ddldesignation.DataSource = ds.Tables(0)
        ddldesignation.DataTextField = "Desig_Name"
        ddldesignation.DataValueField = "Desig_Id"
        ddldesignation.DataBind()
    End Sub

    Sub AtLeastOneContact_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        If txtemailContact.Text & txtofficenoContact.Text & txtmobContact.Text <> "" Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            If lblEmailExist.Visible = False And lblMobileExist.Visible = False Then

                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                Dim CIds As Integer
                If hfRelateType.Value = "Lead" Then
                    CIds = LeadContactBLL.QuickInsert1(txtnameContact.Text.Trim, txtemailContact.Text.Trim, txtmobContact.Text.Trim, txtofficenoContact.Text.Trim,
                                             "", Session("UserId"), hfRelatedID.Value, Session("Audlog_Id"), False, ddldesignation.SelectedValue, ddlnotifyby.SelectedItem.Text)
                ElseIf hfRelateType.Value = "Prospect" Then
                    CIds = ContactBLL.Insert("Mr.", "Male", txtnameContact.Text.Trim, ddldesignation.SelectedValue, "0", txtemailContact.Text.Trim,
                                    "", txtmobContact.Text.Trim, txtofficenoContact.Text.Trim, "", "", "0", "",
                                   "Prospect", hfRelatedID.Value, "", Session("UserId"), Session("Audlog_Id"), False, ddlnotifyby.SelectedItem.Text)
                ElseIf hfRelateType.Value = "Account" Then
                    CIds = ContactBLL.Insert("Mr.", "Male", txtnameContact.Text.Trim, ddldesignation.SelectedValue, "0", txtemailContact.Text.Trim,
                                     "", txtmobContact.Text.Trim, txtofficenoContact.Text.Trim, "", "", "0", "",
                                    "Account", hfRelatedID.Value, "", Session("UserId"), Session("Audlog_Id"), False, ddlnotifyby.SelectedItem.Text)
                End If
                Session("Contacteid") = CIds
                'FillContactDSR(hfRelateType.Value, hfRelatedID.Value)
                'ddrelatedtypeid_TextChanged(Nothing, Nothing)
                'FillContact()
                mpeC.Hide()
                txtnameContact.Text = ""
                txtemailContact.Text = ""
                txtmobContact.Text = ""
                txtofficenoContact.Text = ""
                'ddldesignation.SelectedValue = "0"
                ddlnotifyby.SelectedValue = "Email"
                FillContactDSR(hfRelateType.Value, hfRelatedID.Value)
                ddcontactypeid.SelectedValue = Session("Contacteid")
                ddcontactypeid_TextChanged(Nothing, Nothing)
            Else
                btnsave.Enabled = True

            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewLead", "btnsave_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

#End Region

    Protected Sub rblAction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblAction.SelectedIndexChanged
        Try
            If rblAction.SelectedValue = "CALL" Then
                ddlSubJCall.Style("display") = "block"
                ddlSubJMeet.Style("display") = "none"
                ddlSubJOther.Style("display") = "none"
                rfSubjCall.Style("display") = "visible"
                rfSubjMeet.Style("display") = "hidden"
                rfSubjOther.Style("display") = "hidden"
                rfSubjCall.Enabled = True
                rfSubjMeet.Enabled = False
                rfSubjOther.Enabled = False
            ElseIf rblAction.SelectedValue = "MEETING" Then
                ddlSubJCall.Style("display") = "none"
                ddlSubJMeet.Style("display") = "block"
                ddlSubJOther.Style("display") = "none"
                rfSubjCall.Style("display") = "hidden"
                rfSubjMeet.Style("display") = "visible"
                rfSubjOther.Style("display") = "hidden"
                rfSubjCall.Enabled = False
                rfSubjMeet.Enabled = True
                rfSubjOther.Enabled = False
            ElseIf rblAction.SelectedValue = "OTHERS" Then
                ddlSubJCall.Style("display") = "none"
                ddlSubJMeet.Style("display") = "none"
                ddlSubJOther.Style("display") = "block"
                rfSubjCall.Style("display") = "hidden"
                rfSubjMeet.Style("display") = "hidden"
                rfSubjOther.Style("display") = "visible"
                rfSubjCall.Enabled = False
                rfSubjMeet.Enabled = False
                rfSubjOther.Enabled = True
            End If
            'If rblAction.SelectedValue = "CALL" Then
            '    ddlSubJCall.Visible = True
            '    ddlSubJMeet.Visible = False
            '    ddlSubJOther.Visible = False
            'ElseIf rblAction.SelectedValue = "MEETING" Then
            '    ddlSubJCall.Visible = False
            '    ddlSubJMeet.Visible = True
            '    ddlSubJOther.Visible = False
            'ElseIf rblAction.SelectedValue = "OTHERS" Then
            '    ddlSubJCall.Visible = False
            '    ddlSubJMeet.Visible = False
            '    ddlSubJOther.Visible = True
            'End If
        Catch ex As Exception

        End Try
    End Sub
    'Public Sub SendRatingMail(ByVal id As Integer, ByVal ActivityId As Integer, ByVal date1 As String, ByVal AccRelatedType As String, ByVal AccRelatedID As String)
    Public Sub SendRatingMail(ByVal id As Integer, ByVal ActivityId As Integer, ByVal date1 As String)
        'Dim data1 As tblAgent = New tblAgent()
        Try

            'If id1 IsNot Nothing Then
            If id.ToString <> "" Then
                Dim ClientName As String = ddcontactypeid.SelectedItem.Text
                'data1 = uow.AgentRepo.GetById(id)
                Dim dsCust As DataSet = MainBLL.getemailbyid(hfRelateType.Value, ddcontactypeid.SelectedValue, "AccContDetsById")
                Dim CusEmail As String = DynamicparcelDataManipulation.FixNullFromDB(dsCust.Tables(0).Rows(0)("Email").ToString())
                Dim CusMobile As String = DynamicparcelDataManipulation.FixNullFromDB(dsCust.Tables(0).Rows(0)("Mobile").ToString())


                Dim dsUser As DataSet = MainBLL.ViewByID(Session("UserId"), "UserProfileViewByID")

                Dim UserFName As String = DynamicparcelDataManipulation.FixNullFromDB(dsUser.Tables(0).Rows(0)("U_FirstName").ToString())
                Dim UserLName As String = DynamicparcelDataManipulation.FixNullFromDB(dsUser.Tables(0).Rows(0)("U_LastName").ToString())
                Dim body As String = String.Empty
                Dim reader As StreamReader = New StreamReader(Server.MapPath("~/Email/Rating.html"))
                body = reader.ReadToEnd()
                body = body.Replace("#Name", ClientName)
                body = body.Replace("#SalesName", UserFName + " " + UserLName)
                body = body.Replace("#Date1", date1)
                Dim EmailSubject As String = "Share you feedback of interaction with SwissBake®"
                Dim SMSUrl As String = ("https://www.swissbake.in/Feedback/Index?feedbackid=3&AgentId=") & Security.Encrypt(HttpUtility.UrlEncode(Convert.ToString((id)))) + Convert.ToString("&ActivtyID=") + Security.Encrypt(HttpUtility.UrlEncode(Convert.ToString((ActivityId))))
                If rblAction.SelectedValue = "CALL" Then
                    If CusMobile <> "" Then
                        SendUsingSMPP.SendSMS("Dear " + ClientName + " Thank you for talking to SwissBake representative  " + UserFName + " " + UserLName + " on " + Convert.ToDateTime(date1).ToString("dd-MMM-yyyy") + " . Kindly share your valuable feedback on this interaction with us. CLICK HERE " + SMSUrl + " . Thank you !", CusMobile)
                    End If
                    EmailSubject = "Share you feedback of Phone call with SwissBake®"
                    body = body.Replace("#Line1", "Our Sales Representative <strong>" + UserFName + " " + UserLName + "</strong> has spoken to you on <strong>" + date1 + "</strong>")
                    body = body.Replace("#Line2", "We would like to know if you were satisfied with the service and support rendered to you during this Call.")
                    body = body.Replace("#Line3", "You are requested to kindly rate this Call as per below.")
                ElseIf rblAction.SelectedValue = "MEETING" Then
                    If CusMobile <> "" Then
                        SendUsingSMPP.SendSMS("Dear " + ClientName + " Thank you for meeting SwissBake representative  " + UserFName + " " + UserLName + " on " + Convert.ToDateTime(date1).ToString("dd-MMM-yyyy") + " . Kindly share your valuable feedback on this interaction with us. CLICK HERE " + SMSUrl + " . Thank you !", CusMobile)
                    End If
                    EmailSubject = "Share you feedback of meeting with SwissBake®"
                    body = body.Replace("#Line1", "Our Sales Representative <strong>" + UserFName + " " + UserLName + "</strong> has met with you on <strong>" + date1 + "</strong>")
                    body = body.Replace("#Line2", "We would like to know if you were satisfied with the service and support rendered to you during this meeting.")
                    body = body.Replace("#Line3", "You are requested to kindly rate this meeting as per below.")
                ElseIf rblAction.SelectedValue = "OTHERS" Then
                    If CusMobile <> "" Then
                        SendUsingSMPP.SendSMS("Dear " + ClientName + " Thank you for your interaction with SwissBake representative  " + UserFName + " " + UserLName + " on " + Convert.ToDateTime(date1).ToString("dd-MMM-yyyy") + " . Kindly share your valuable feedback on this interaction with us. CLICK HERE " + SMSUrl + " . Thank you !", CusMobile)
                    End If
                    EmailSubject = "Share you feedback of interaction with SwissBake®"
                    body = body.Replace("#Line1", "Our Sales Representative <strong>" + UserFName + " " + UserLName + "</strong> has interacted with you on <strong>" + date1 + "</strong>")
                    body = body.Replace("#Line2", "We would like to know if you were satisfied with the service and support rendered to you during this conversation.")
                    body = body.Replace("#Line3", "You are requested to kindly rate this conversation as per below.")
                    End If

                    body = body.Replace("#Url1", ("https://www.swissbake.in/Feedback/Index?feedbackid=1&AgentId=") & Security.Encrypt(HttpUtility.UrlEncode(Convert.ToString((id)))) + Convert.ToString("&ActivtyID=") + Security.Encrypt(HttpUtility.UrlEncode(Convert.ToString((ActivityId)))))
                    body = body.Replace("#Url2", ("https://www.swissbake.in/Index?feedbackid=2&AgentId=") & Security.Encrypt(HttpUtility.UrlEncode(Convert.ToString((id)))) + Convert.ToString("&ActivtyID=") + Security.Encrypt(HttpUtility.UrlEncode(Convert.ToString((ActivityId)))))
                    body = body.Replace("#Url3", ("https://www.swissbake.in/Feedback/Index?feedbackid=3&AgentId=") & Security.Encrypt(HttpUtility.UrlEncode(Convert.ToString((id)))) + Convert.ToString("&ActivtyID=") + Security.Encrypt(HttpUtility.UrlEncode(Convert.ToString((ActivityId)))))
                    body = body.Replace("#Url4", ("https://www.swissbake.in/Feedback/Index?feedbackid=4&AgentId=") & Security.Encrypt(HttpUtility.UrlEncode(Convert.ToString((id)))) + Convert.ToString("&ActivtyID=") + Security.Encrypt(HttpUtility.UrlEncode(Convert.ToString((ActivityId)))))
                    body = body.Replace("#Url5", ("https://www.swissbake.in/Feedback/Index?feedbackid=5&AgentId=") & Security.Encrypt(HttpUtility.UrlEncode(Convert.ToString((id)))) + Convert.ToString("&ActivtyID=") + Security.Encrypt(HttpUtility.UrlEncode(Convert.ToString((ActivityId)))))

                    SendMailBLL.SendMail(CusEmail, body, EmailSubject)
                    reader.Dispose()


                    'Dim id1 As Integer = 1
                    'Dim ActivityId1 As Integer = 4140
                    'Dim asda As String = ("https://www.swissbake.in/Feedback/Index?feedbackid=1&AgentId=") & Security.Encrypt(HttpUtility.UrlEncode(Convert.ToString((id1)))) + Convert.ToString("&ActivtyID=") + Security.Encrypt(HttpUtility.UrlEncode(Convert.ToString((ActivityId1))))
                End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtemailContact_TextChanged(sender As Object, e As EventArgs) Handles txtemailContact.TextChanged
        Try
            If txtemailContact.Text <> "" Then
                Dim CheckEmailContact As String = ""
                If hfRelateType.Value = "Lead" Then
                    CheckEmailContact = MainBLL.CheckEmail(txtemailContact.Text, "LeadContactEmailCheck")
                ElseIf hfRelateType.Value = "Prospect" Then
                    CheckEmailContact = MainBLL.CheckEmail(txtemailContact.Text, "AccountContactEmailCheck")
                ElseIf hfRelateType.Value = "Account" Then
                    CheckEmailContact = MainBLL.CheckEmail(txtemailContact.Text, "AccountContactEmailCheck")
                End If
                If CheckEmailContact = "Already Exist" Then
                    lblEmailExist.Visible = True
                    btnsave.Enabled = False
                Else
                    lblEmailExist.Visible = False
                    btnsave.Enabled = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtmobContact_TextChanged(sender As Object, e As EventArgs) Handles txtmobContact.TextChanged
        Try
            If txtmobContact.Text <> "" Then
                Dim CheckMobileContact As String = ""
                If hfRelateType.Value = "Lead" Then
                    CheckMobileContact = MainBLL.CheckEmail(txtmobContact.Text, "LeadContactMobileCheck")
                ElseIf hfRelateType.Value = "Prospect" Then
                    CheckMobileContact = MainBLL.CheckEmail(txtmobContact.Text, "AccountContactMobileCheck")
                ElseIf hfRelateType.Value = "Account" Then
                    CheckMobileContact = MainBLL.CheckEmail(txtmobContact.Text, "AccountContactMobileCheck")
                End If
                If CheckMobileContact = "Already Exist" Then
                    lblMobileExist.Visible = True
                    btnsave.Enabled = False
                Else
                    lblMobileExist.Visible = False
                    btnsave.Enabled = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub ddlLeadCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlLeadCategory.SelectedIndexChanged
        Try
            If ddlLeadCategory.SelectedValue = "Domestic" Then
                ddlcountrybill.SelectedValue = 105
                ddlcountrybill.Enabled = False
                FillStatebill()
            Else
                ddlcountrybill.Enabled = True
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("DSR", "ddlcountrybill_SelectedIndexChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class

