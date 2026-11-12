Imports DynamicparcelEnumerations

Partial Class ActivityEvent
    Inherits System.Web.UI.Page
    Dim MainID As Integer
    Dim ContactID As Integer
    Dim RelatedID As Integer
    Dim ConatctType As String
    Dim RelatedType As String
    Dim returnurl As String
    Dim FormDate As String, FromTime As String, FromDateTime As String
    Dim toDate As String, Toime As String, ToDateTime As String
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
                        txtfromdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                        txttodate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                        txtfromtime.Text = Date.Now.ToString("H:mm")
                        txttotime.Text = Date.Now.Add(New TimeSpan(0, 30, 0)).ToString("H:mm")
                        txtreminderdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                        txtremindertime.Text = Date.Now.ToString("H:mm")
                        FillOwner()
                        If MainID = 0 Then
                            lbltitle1.Text = "New Sampling/Demo"
                            lbltitle2.Text = "New Sampling/Demo"
                            assigncontrol.Uhftype.Value = "ActivityEvent"
                            assigncontrol.Uhftypeid.Value = MainID
                            ddowner.SelectedValue = Session("UserId")
                            notecontrol.Visible = False
                            divstatus.Visible = False
                            txttodate.Enabled = True
                            txtfromdate.Enabled = True
                            txttotime.Enabled = True
                            txtfromtime.Enabled = True
                        Else
                            lbltitle1.Text = "Modify Sampling/Demo"
                            lbltitle2.Text = "Modify Sampling/Demo"
                            FillDetail()
                            assigncontrol.Uhftype.Value = "ActivityEvent"
                            assigncontrol.Uhftypeid.Value = MainID
                            notecontrol.Visible = True
                            notecontrol.Uhftype.Value = "Activity"
                            notecontrol.Uhftypeid.Value = MainID
                            divstatus.Visible = True
                            txttodate.Enabled = False
                            txtfromdate.Enabled = False
                            txttotime.Enabled = False
                            txtfromtime.Enabled = False
                            ddrelatedtypeid.CssClass = "form-control"
                            ddcontactypeid.CssClass = "form-control"
                            ddrelatedtype.Enabled = False
                            ddrelatedtypeid.Enabled = False
                            ddcontactypeid.Enabled = False
                        End If
                    End If
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ActivityEvent", "Page_Load", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        Else
            Try
                If Not IsPostBack Then
                    If (Request.QueryString("Id") = Nothing) Then
                        Response.Redirect("index.aspx")
                    Else
                        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                        txtfromdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                        txttodate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                        txtfromtime.Text = Date.Now.ToString("H:mm")
                        txttotime.Text = Date.Now.Add(New TimeSpan(0, 30, 0)).ToString("H:mm")
                        txtreminderdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                        txtremindertime.Text = Date.Now.ToString("H:mm")
                        FillOwner()
                        If MainID = 0 Then
                            lbltitle1.Text = "New Sampling/Demo"
                            lbltitle2.Text = "New Sampling/Demo"
                            assigncontrol.Uhftype.Value = "ActivityEvent"
                            assigncontrol.Uhftypeid.Value = MainID
                            ddowner.SelectedValue = Session("UserId")
                            notecontrol.Visible = False
                            divstatus.Visible = False
                            txttodate.Enabled = True
                            txtfromdate.Enabled = True
                            txttotime.Enabled = True
                            txtfromtime.Enabled = True
                        Else
                            lbltitle1.Text = "Modify Sampling/Demo"
                            lbltitle2.Text = "Modify Sampling/Demo"
                            FillDetail()
                            assigncontrol.Uhftype.Value = "ActivityEvent"
                            assigncontrol.Uhftypeid.Value = MainID
                            notecontrol.Visible = True
                            notecontrol.Uhftype.Value = "Activity"
                            notecontrol.Uhftypeid.Value = MainID
                            divstatus.Visible = True
                            txttodate.Enabled = False
                            txtfromdate.Enabled = False
                            txttotime.Enabled = False
                            txtfromtime.Enabled = False
                            ddrelatedtypeid.CssClass = "form-control"
                            ddcontactypeid.CssClass = "form-control"
                            ddrelatedtype.Enabled = False
                            ddrelatedtypeid.Enabled = False
                            ddcontactypeid.Enabled = False
                        End If
                    End If
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ActivityEvent", "Page_Load", error1, Session("UserId"))
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
                ddrelatedtype.SelectedValue = "Lead"
                ddrelatedtypeid.DataSource = ds
                ddrelatedtypeid.DataTextField = "Lead_Name"
                ddrelatedtypeid.DataValueField = "Lead_Id"
                ddrelatedtypeid.DataBind()
            ElseIf (ddcontactype.SelectedValue = "Contact") Then
                ddrelatedtype.SelectedValue = "Prospect"
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
                ddrelatedtypeid.DataSource = ""
                ddrelatedtypeid.DataBind()
                ddrelatedtype.SelectedValue = "None"
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityEvent", "ddcontactype_TextChanged", error1, Session("UserId"))
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
                    ddrelatedtype.SelectedValue = "Lead"
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
                 ElseIf (ddrelatedtype.SelectedValue = "Opportunity") Then
                    ddcontactype.SelectedValue = "Contact"
                Dim ds As DataSet = MainBLL.DropdownWithID("OpportunityDropDown", Session("UserId"))
                If ds.Tables(0).Rows.Count >= 1 Then
                    ddrelatedtypeid.DataSource = ds
                    ddrelatedtypeid.DataTextField = "Opportunity_Name"
                    ddrelatedtypeid.DataValueField = "Opportunity_Id"
                    ddrelatedtypeid.DataBind()
                    If ds.Tables(0).Rows.Count >= 1 Then
                        Dim dt As DataSet = MainBLL.ViewByID(ddrelatedtypeid.SelectedValue, "ViewOppTypeByID")
                        Dim dtUser As New DataTable
                        dtUser = dt.Tables(0)
                        Dim drLogin As DataRow
                        drLogin = dtUser.Rows(0)
                        ddcontactypeid.DataSource = MainBLL.DropdownWithtypeAndID("ContacttDropDown", drLogin("Opportunity_Type").ToString(), drLogin("Opportunity_TypeId").ToString())
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
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + ("No opportunity found").ToString + "')", True)
                End If
                     ElseIf (ddrelatedtype.SelectedValue = "Quotation") Then
                    ddcontactype.SelectedValue = "Contact"
                Dim ds As DataSet
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                If MainID = 0 Then
                    ds = MainBLL.DropdownWithID("QuotationDropDown", Session("UserId"))
                Else
                    ds = MainBLL.Dropdown("EditQuotationDropDown")
                End If
                If ds.Tables(0).Rows.Count >= 1 Then
                    ddrelatedtypeid.DataSource = ds
                    ddrelatedtypeid.DataTextField = "Name"
                    ddrelatedtypeid.DataValueField = "Quotation_Id"
                    ddrelatedtypeid.DataBind()
                    If ds.Tables(0).Rows.Count > 1 Then
                        Dim dt As DataSet = MainBLL.ViewByID(ddrelatedtypeid.SelectedValue, "QuotationType")
                        Dim dtUser As New DataTable
                        dtUser = dt.Tables(0)
                        Dim drLogin As DataRow
                        drLogin = dtUser.Rows(0)
                        ddcontactypeid.DataSource = MainBLL.DropdownWithtypeAndID("ContacttDropDown", drLogin("Quotation_Type").ToString(), drLogin("Quotation_TypeID").ToString())
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
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + ("No quotation found").ToString + "')", True)
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
            ExecptionBLL.Insert("ActivityEvent", "ddrelatedtype_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddcontactypeid_TextChanged(sender As Object, e As EventArgs) Handles ddcontactypeid.TextChanged
        Try
            If ddrelatedtype.SelectedValue = "Lead" Then
                ddrelatedtypeid.SelectedIndex = ddcontactypeid.SelectedIndex
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityEvent", "ddcontactypeid_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddrelatedtypeid_TextChanged(sender As Object, e As EventArgs) Handles ddrelatedtypeid.TextChanged
        Try
            If ddrelatedtype.SelectedValue = "Lead" Then
                ddcontactypeid.SelectedIndex = ddrelatedtypeid.SelectedIndex
            ElseIf ddrelatedtype.SelectedValue = "Prospect" Then
                ddcontactypeid.DataSource = MainBLL.DropdownWithtypeAndID("ContacttDropDown", "Prospect", ddrelatedtypeid.SelectedValue)
                ddcontactypeid.DataTextField = "Contact_ContactPerson"
                ddcontactypeid.DataValueField = "Contact_Id"
                ddcontactypeid.DataBind()
            ElseIf ddrelatedtype.SelectedValue = "Account" Then
                ddcontactypeid.DataSource = MainBLL.DropdownWithtypeAndID("ContacttDropDown", "Account", ddrelatedtypeid.SelectedValue)
                ddcontactypeid.DataTextField = "Contact_ContactPerson"
                ddcontactypeid.DataValueField = "Contact_Id"
                ddcontactypeid.DataBind()
            ElseIf ddrelatedtype.SelectedValue = "Opportunity" Then
                Dim dt As DataSet = MainBLL.ViewByID(ddrelatedtypeid.SelectedValue, "ViewOppTypeByID")
                Dim dtUser As New DataTable
                dtUser = dt.Tables(0)
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                ddcontactypeid.DataSource = MainBLL.DropdownWithtypeAndID("ContacttDropDown", drLogin("Opportunity_Type").ToString(), drLogin("Opportunity_TypeId").ToString())
                ddcontactypeid.DataTextField = "Contact_ContactPerson"
                ddcontactypeid.DataValueField = "Contact_Id"
                ddcontactypeid.DataBind()
            ElseIf ddrelatedtype.SelectedValue = "Quotation" Then
                Dim dt As DataSet = MainBLL.ViewByID(ddrelatedtypeid.SelectedValue, "QuotationType")
                Dim dtUser As New DataTable
                dtUser = dt.Tables(0)
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                ddcontactypeid.DataSource = MainBLL.DropdownWithtypeAndID("ContacttDropDown", drLogin("Quotation_Type").ToString(), drLogin("Quotation_TypeID").ToString())
                ddcontactypeid.DataTextField = "Contact_ContactPerson"
                ddcontactypeid.DataValueField = "Contact_Id"
                ddcontactypeid.DataBind()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityEvent", "ddrelatedtypeid_TextChanged", error1, Session("UserId"))
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
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityEvent", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillOwner()
        Try
            ddowner.DataSource = MainBLL.Dropdown("UserDropDown")
            ddowner.DataTextField = "U_FirstName"
            ddowner.DataValueField = "U_ID"
            ddowner.DataBind()
            ddowner.SelectedValue = Session("UserId")
            'ddowner.Items.Insert(0, New ListItem("Select Host", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityEvent", "FillOwner", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try
                    If ddcontactypeid.SelectedValue = "" Then
                        ContactID = 0
                        ConatctType = "None"
                    Else
                        ContactID = ddcontactypeid.SelectedValue
                        ConatctType = ddcontactype.SelectedValue
                    End If
                    If ddrelatedtypeid.SelectedValue = "" Then
                        RelatedID = 0
                        RelatedType = "None"
                    Else
                        RelatedID = ddrelatedtypeid.SelectedValue
                        RelatedType = ddrelatedtype.SelectedValue
                    End If
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
                    If String.IsNullOrEmpty(txtreminderdate.Text) Then
                        txtreminderdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                    End If
                    If String.IsNullOrEmpty(txtremindertime.Text) Then
                        txtremindertime.Text = Date.Now.ToString("H:mm:ss")
                    End If
                    FormDate = txtfromdate.Text.Trim
                    FromTime = txtfromtime.Text
                    FromDateTime = Convert.ToDateTime(FormDate + " " + FromTime)
                    toDate = txttodate.Text.Trim
                    Toime = txttotime.Text
                    ToDateTime = Convert.ToDateTime(toDate + " " + Toime)
                    ReminderDate = txtreminderdate.Text.Trim
                    Remindertime = txtremindertime.Text.Trim
                    Reminderdatetime = Convert.ToDateTime(ReminderDate + " " + Remindertime)
                    If ckreminder.Checked = True Then
                        Reminder = 1
                    Else
                        Reminder = 0
                    End If
                    ActivityBLL.UpdateEvent(ddowner.SelectedValue, txteventname.Text.Trim, txtlocation.Text.Trim, FromDateTime, ToDateTime,
                    RelatedType, RelatedID, ConatctType, ContactID, ddstatus.SelectedValue, Session("Audlog_Id"), txtdec.Text.Trim, Session("UserId"),
                    MainID, ddpriority.SelectedValue, Reminder, Reminderdatetime)
                    assigncontrol.AddAssignTo(MainID)
                    If RelatedType = "Lead" Then
                        LeadBLL.UpdateLeadStage(RelatedID, 12)
                    End If
                    If Request.QueryString("returnurl") = Nothing Then
                        Response.Redirect("Activity.aspx")
                    Else
                        returnurl = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("returnurl")))
                        Response.Redirect(returnurl)
                    End If
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ActivityEvent", "UPDATE", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Case DML_OPERATION.INSERT
                Try
                    If ddcontactypeid.SelectedValue = "" Then
                        ContactID = 0
                        ConatctType = "None"
                    Else
                        ContactID = ddcontactypeid.SelectedValue
                        ConatctType = ddcontactype.SelectedValue
                    End If
                    If ddrelatedtypeid.SelectedValue = "" Then
                        RelatedID = 0
                        RelatedType = "None"
                    Else
                        RelatedID = ddrelatedtypeid.SelectedValue
                        RelatedType = ddrelatedtype.SelectedValue
                        If RelatedType = "Lead" Then
                            ConatctType = "Lead"
                        End If
                    End If
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
                    If String.IsNullOrEmpty(txtreminderdate.Text) Then
                        txtreminderdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                    End If
                    If String.IsNullOrEmpty(txtremindertime.Text) Then
                        txtremindertime.Text = Date.Now.ToString("H:mm:ss")
                    End If
                    ReminderDate = txtreminderdate.Text.Trim
                    Remindertime = txtremindertime.Text.Trim
                    Reminderdatetime = Convert.ToDateTime(ReminderDate + " " + Remindertime)
                    If ckreminder.Checked = True Then
                        Reminder = 1
                    Else
                        Reminder = 0
                    End If
                    FormDate = txtfromdate.Text.Trim
                    FromTime = txtfromtime.Text
                    FromDateTime = Convert.ToDateTime(FormDate + " " + FromTime)
                    toDate = txttodate.Text.Trim
                    Toime = txttotime.Text
                    ToDateTime = Convert.ToDateTime(toDate + " " + Toime)
                    MainID = ActivityBLL.InsertFullEvent(ddowner.SelectedValue, txteventname.Text.Trim, txtlocation.Text.Trim, FromDateTime, ToDateTime,
                    RelatedType, RelatedID, ConatctType, ContactID, ddstatus.SelectedValue, Session("Audlog_Id"), txtdec.Text.Trim,
                    Session("UserId"), ddpriority.SelectedValue, Reminder, Reminderdatetime)
                    returnurl = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("returnurl")))
                    If RelatedType = "Lead" Then
                        LeadBLL.UpdateLeadStage(RelatedID, 12)
                    End If
                    assigncontrol.AddAssignTo(MainID)
                    Response.Redirect(returnurl)
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ActivityEvent", "INSERT", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub

    Public Sub FillDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "ActivityViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            txteventname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
            ddowner.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Owner").ToString())
            ddpriority.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
            txtdec.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
            txtlocation.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Location").ToString())
            If IsDBNull(drLogin("Activity_Reminderdatetime")) Then
                txtreminderdate.Text = ""
                txtremindertime.Text = ""
            Else
                txtreminderdate.Text = DynamicparcelDataManipulation.DateFormat(drLogin("Activity_Reminderdatetime").ToString())
                Dim rst As Date = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Reminderdatetime").ToString())
                txtremindertime.Text = rst.ToString("H:mm")
            End If
            If IsDBNull(drLogin("Activity_Reminder")) Then
                ckreminder.Checked = False
            Else
                ckreminder.Checked = drLogin("Activity_Reminder")
            End If
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
            Dim fdt As Date = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Fromdate").ToString())
            txtfromdate.Text = fdt.ToString("yyyy-MM-dd")
            txtfromtime.Text = fdt.ToString("H:mm")
            Dim tdt As Date = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Todate").ToString())
            txttodate.Text = tdt.ToString("yyyy-MM-dd")
            txttotime.Text = tdt.ToString("H:mm")
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
            ExecptionBLL.Insert("ActivityEvent", "FillDetail", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub hfcancel_Click(sender As Object, e As EventArgs) Handles hfcancel.Click
        Try
            If Request.QueryString("returnurl") = Nothing Then
                Response.Redirect("Activity.aspx")
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
                Response.Redirect("Activity.aspx")
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
End Class

