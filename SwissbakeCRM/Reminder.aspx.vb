

Imports DynamicparcelEnumerations

Partial Class Reminder
	Inherits System.Web.UI.Page
	Dim MainID As Integer
	Dim ContactID As Integer
	Dim RelatedID As Integer
	Dim ConatctType As String
	Dim RelatedType As String
	Dim returnurl As String
	Dim FormDate As String, FromTime As String, FromDateTime As String, billable As Boolean
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
                        txtstarttime.Text = Date.Now.Add(New TimeSpan(-1, 0, 0)).ToString("H:mm")
                        txtendtime.Text = Date.Now.ToString("H:mm")
						ddlDate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
						FillOwner()
						txtduedate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
						txtleaddate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
						If MainID = 0 Then
							lbltitle1.Text = "New Reminder"
							lbltitle2.Text = "New Reminder"

							assigncontrol.Uhftype.Value = "ActivityTask"
							assigncontrol.Uhftypeid.Value = MainID
							ddowner.SelectedValue = Session("UserId")
							notecontrol.Visible = False
							divstatus.Visible = False
							Fillddrelatedtypeid()
                            'FillddlDate()
						Else
							lbltitle1.Text = "Modify Reminder"
							lbltitle2.Text = "Modify Reminder"

							FillDetail()
							txtstarttime.ReadOnly = True
							txtendtime.ReadOnly = True
							'  txtdate.Enabled = False
							ddrelatedtypeid.CssClass = "form-control"
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
                         ddlDate.Attributes("min") = DateTime.Now.ToString("yyyy-MM-dd")
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
                        'txtstarttime.Text = Date.Now.Add(-TimeSpan.FromHours(1)) '.ToString("h:mm")
                        'txtstarttime.Text = Date.Now.AddMinutes(-59).ToString("H:mm")
						txtendtime.Text = Date.Now.ToString("H:mm")
                        ddlDate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                        FillOwner()
						txtduedate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
						txtleaddate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
						If MainID = 0 Then
							lbltitle1.Text = "New Reminder"
							lbltitle2.Text = "New Reminder"

							assigncontrol.Uhftype.Value = "ActivityTask"
							assigncontrol.Uhftypeid.Value = MainID
							ddowner.SelectedValue = Session("UserId")
							notecontrol.Visible = False
							divstatus.Visible = False
							Fillddrelatedtypeid()
                            'FillddlDate()
						Else
							lbltitle1.Text = "Modify Reminder"
							lbltitle2.Text = "Modify Reminder"

							FillDetail()
                            'FillddlDate()
							txtstarttime.ReadOnly = True
							txtendtime.ReadOnly = True

							'   txtdate.Enabled = False
							ddrelatedtypeid.CssClass = "form-control"
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
                        ddlDate.Attributes("min") = DateTime.Now.ToString("yyyy-MM-dd")
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
				Response.Redirect("index1.aspx")
			Else
				Response.Redirect("Activity.aspx")
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
                    Reminder = 1

					ActivityBLL.UpdateTask(ddowner.SelectedValue, txtsubject.Text.Trim, ddstatus.SelectedValue, txtduedate.Text.Trim,
					"Reminder", RelatedType, RelatedID, ConatctType, ContactID,
					ddpriority.SelectedValue, Session("Audlog_Id"), txtdec.Text.Trim, txtresult.Text.Trim, Session("UserId"), MainID, FromDateTime, ToDateTime, Reminder, Reminderdatetime)
					assigncontrol.AddAssignTo(MainID)
					If RelatedType = "Lead" Then
						LeadBLL.UpdateLeadStage(RelatedID, 12)
					End If
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

					Dim a As String = ddlDate.Text.ToString()
					FormDate = DynamicparcelDataManipulation.DateFormat(a)
					FromTime = txtstarttime.Text.Trim
					FromDateTime = Convert.ToDateTime(FormDate + " " + FromTime)

					ReminderDate = FormDate
					Remindertime = FromTime
					Reminderdatetime = Convert.ToDateTime(ReminderDate + " " + Remindertime)
					toDate = ddlDate.Text.Trim
					Toime = txtendtime.Text
					ToDateTime = Convert.ToDateTime(toDate + " " + Toime)
                    Reminder = 1

                    MainID = ActivityBLL.InsertFullTask(ddowner.SelectedValue, txtsubject.Text.Trim, "Pending", txtduedate.Text.Trim,
                    "Reminder", RelatedType, RelatedID, ConatctType, ContactID,
                    ddpriority.SelectedValue, Session("Audlog_Id"), txtdec.Text.Trim, txtresult.Text.Trim, Session("UserId"), FromDateTime, ToDateTime, Reminder, Reminderdatetime)
					assigncontrol.AddAssignTo(MainID)
                    'ActivityBLL.ClosedActivity(MainID, "Reminder Self Closed")
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

		Catch ex As Exception
			Dim error1 As String = ex.Message.Replace(Chr(34), "")
			error1 = error1.Replace(Chr(39), "")

			Throw ex
		End Try
	End Sub
	Public Sub FillddlDate()
		'Try
		'	MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
		'	If MainID = 0 Then
		'		Dim ds As DataSet
		'		' If MainID = 0 Then
		'		ds = SampleBLL.DropdownWithPrevDate("PrevDateDropDown")
		'		ddlDate.DataSource = ds.Tables(0)
		'		ddlDate.DataTextField = "Date"
		'		ddlDate.DataValueField = "ID"
		'		ddlDate.DataBind()
		'		ddlDate.Items.Insert(0, New ListItem("Select Date", "0"))
		'	Else
		'		'Dim ds As DataSet
		'		'ddlDate.DataSource = ds.Tables(0)
		'		'ddlDate.Items.Insert(0, New ListItem("First Static", 0))
		'		ddlDate.Items.Insert(0, New ListItem("Select Date", "0"))
		'		ddlDate.Items.Insert(1, New ListItem(Session("ddlDate"), "1"))
		'		' ddlDate.DataBind()
		'		ddlDate.SelectedValue = 1
		'	End If

		'Catch ex As Exception
		'	Dim error1 As String = ex.Message.Replace(Chr(34), "")
		'	error1 = error1.Replace(Chr(39), "")
		'	Throw ex
		'End Try
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
			Dim str As String = ddrelatedtypeid.SelectedValue

			Dim strArr() As String
			strArr = str.Split("-")
			Dim conID As Integer = Convert.ToInt32(strArr(0))
			FillContactReminder(strArr(1), conID)

		Catch ex As Exception
			Dim error1 As String = ex.Message.Replace(Chr(34), "")
			error1 = error1.Replace(Chr(39), "")
			ExecptionBLL.Insert("ActivitTask", "ddrelatedtypeid_TextChanged", error1, Session("UserId"))
			ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
		End Try
	End Sub
	Public Sub FillContactReminder(ByVal Type As String, ByVal conID As Integer)
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
			txtsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
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
			LeadAddressBLL.Insert("", "", 0, 105, "", Session("UserId"), MainID, "Billing", Session("Audlog_Id"))
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
End Class

