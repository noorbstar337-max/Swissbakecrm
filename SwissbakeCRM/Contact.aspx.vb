Imports DynamicparcelEnumerations

Partial Class Contact
    Inherits System.Web.UI.Page
    Dim MainID As Integer
    Dim RelatedID As Integer
    Dim returnurl As String

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
        If Not IsPostBack Then
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                FillDesignation()
                FillDeparment()
                FillContactType()
                If MainID = 0 Then
                    lbltitle1.Text = "New Contact"
                    lbltitle2.Text = "New Contact"
                Else
                    lbltitle1.Text = "Modify Contact"
                    lbltitle2.Text = "Modify Contact"
                    FillContactDetail()
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Contact", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Sub AtLeastOneContact_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        If txtemail.Text & txtofficeno.Text & txtmob.Text <> "" Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

    Public Sub FillDesignation()
        Try
            Dim ds As DataSet = MainBLL.Dropdown("DesignationDropDown")
            ddldesignation.DataSource = ds.Tables(0)
            ddldesignation.DataTextField = "Desig_Name"
            ddldesignation.DataValueField = "Desig_Id"
            ddldesignation.DataBind()
            'ddldesignation.Items.Insert(0, New ListItem("Select Designation", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Contact", "FillDesignation", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillDeparment()
        Try
            Dim ds As DataSet = MainBLL.Dropdown("DepartmentDropDown")
            dddepartment.DataSource = ds.Tables(0)
            dddepartment.DataTextField = "Deprt_Name"
            dddepartment.DataValueField = "Deprt_Id"
            dddepartment.DataBind()
            'ddldesignation.Items.Insert(0, New ListItem("Select Designation", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Contact", "FillDeparment", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillContactType()
        Try
            Dim ds As DataSet = MainBLL.Dropdown("ContactTypeDropDown")
            ddcontacttype.DataSource = ds.Tables(0)
            ddcontacttype.DataTextField = "ContactType_Name"
            ddcontacttype.DataValueField = "ContactType_Id"
            ddcontacttype.DataBind()
            'ddldesignation.Items.Insert(0, New ListItem("Select Designation", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Contact", "FillContactType", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub ddrelatedtype_TextChanged(sender As Object, e As EventArgs) Handles ddrelatedtype.TextChanged
        Try
        If ddrelatedtype.SelectedValue = "Account" Then
                Dim ds As DataSet
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                If MainID = 0 Then
                    ds = MainBLL.DropdownWithtypeAndID("AccountDropDown", "Account", Session("UserId"))
                Else
                    ds = MainBLL.DropdownWithtype("EditAccountDropDown", "Account")
                End If
            ddrelatedtypeid.DataSource = ds
            ddrelatedtypeid.DataTextField = "Acc_Name"
            ddrelatedtypeid.DataValueField = "Acc_Id"
            ddrelatedtypeid.DataBind()
        ElseIf ddrelatedtype.SelectedValue = "Prospect" Then
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
        ElseIf ddrelatedtype.SelectedValue = "None" Then
            ddrelatedtypeid.DataSource = ""
            ddrelatedtypeid.DataBind()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Contact", "ddrelatedtype_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        If MainID = 0 Then
            SaveProduct(DML_OPERATION.INSERT)
        Else
            SaveProduct(DML_OPERATION.UPDATE)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Contact", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try
                    MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                    If ddrelatedtype.SelectedValue = "None" Then
                        RelatedID = 0
                    Else
                        RelatedID = ddrelatedtypeid.SelectedValue
                    End If
                    ContactBLL.Update(ddltitle.SelectedValue, ddgender.SelectedValue, txtname.Text.Trim, ddldesignation.SelectedValue, dddepartment.SelectedValue, txtemail.Text.Trim,
                                         txtworkemailid.Text.Trim, txtmob.Text.Trim, txtofficeno.Text.Trim, txtdob.Value.Trim, "", ddcontacttype.SelectedValue, txtremark.Text.Trim,
                                         ddrelatedtype.SelectedValue, RelatedID, txtextention.Text.Trim, Session("UserId"), Session("Audlog_Id"), MainID, ddlnotifyby.SelectedValue)
					returnurl = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("returnurl")))
					Response.Redirect(returnurl)
				Catch ex As Exception
					Dim error1 As String = ex.Message.Replace(Chr(34), "")
					error1 = error1.Replace(Chr(39), "")
					ExecptionBLL.Insert("Contact", "Update", error1, Session("UserId"))
					ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
				End Try
			Case DML_OPERATION.INSERT
				Try
					If ddrelatedtype.SelectedValue = "None" Then
						RelatedID = 0
					Else
						RelatedID = ddrelatedtypeid.SelectedValue
					End If
                    ContactBLL.Insert(ddltitle.SelectedValue, ddgender.SelectedValue, txtname.Text.Trim, ddldesignation.SelectedValue, dddepartment.SelectedValue, txtemail.Text.Trim,
                                         txtworkemailid.Text.Trim, txtmob.Text.Trim, txtofficeno.Text.Trim, txtdob.Value.Trim, "", ddcontacttype.SelectedValue, txtremark.Text.Trim,
                                         ddrelatedtype.SelectedValue, RelatedID, txtextention.Text.Trim, Session("UserId"), Session("Audlog_Id"), False, ddlnotifyby.SelectedValue)
					returnurl = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("returnurl")))
					Response.Redirect(returnurl)
				Catch ex As Exception
					Dim error1 As String = ex.Message.Replace(Chr(34), "")
					error1 = error1.Replace(Chr(39), "")
					ExecptionBLL.Insert("Contact", "Insert", error1, Session("UserId"))
					ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
				End Try
		End Select
	End Sub

	Public Sub FillContactDetail()
		Try
			MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
			Dim dt As DataSet = MainBLL.ViewByID(MainID, "ConatctViewBYID")
			Dim dtUser As New DataTable
			dtUser = dt.Tables(0)
			If dtUser.Rows.Count > 0 Then
				Dim drLogin As DataRow
				drLogin = dtUser.Rows(0)
				ddltitle.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Title").ToString())
				ddgender.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Gender").ToString())
				txtname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_ContactPerson").ToString())
                ddldesignation.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Designation").ToString())
                If DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Department").ToString()) = "" Then
                    dddepartment.SelectedValue = 0
                Else
                    dddepartment.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Department").ToString())
                End If

                ddcontacttype.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Type").ToString())
                ddrelatedtype.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_ContactType").ToString())
                ddrelatedtype_TextChanged(Nothing, Nothing)
                ddrelatedtypeid.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_ContactTypeId").ToString())
                txtremark.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Remark").ToString())
                txtemail.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Email").ToString())
                txtworkemailid.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_WorkEmail").ToString())
                txtdob.Value = DynamicparcelDataManipulation.DateFormat(drLogin("Contact_DOB").ToString())
                If txtdob.Value = "1900-01-01" Then
                    txtdob.Value = ""
                End If
                txtmob.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Mobile").ToString())
                txtofficeno.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Landline").ToString())
                txtextention.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Extention").ToString())
                ddlnotifyby.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Notifyby").ToString())
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Contact", "FillContactDetail", error1, Session("UserId"))
            ' ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub hfcancel_Click(sender As Object, e As EventArgs) Handles hfcancel.Click
        Try
        returnurl = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("returnurl")))
            Response.Redirect(returnurl)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Contact", "hfcancel_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

End Class
