
Partial Class ModifyLeadContact
    Inherits System.Web.UI.Page
    Dim MainID As Integer

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("index.aspx")
                Else
                    MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                    FillDesignation()
                    If Not MainID = "0" Then
                        FillContactDetail()
                    End If
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyLeadContact", "Page_Load", error1, Session("UserId"))
            End Try
        End If
    End Sub

    Public Sub FillContactDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "FillLeadContactViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                ddltitle.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadContact_Title").ToString())
                txtname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadContact_Name").ToString())
                ddldesignation.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadContact_DesigId").ToString())
                txtemail.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadContact_Email").ToString())
                txtmob.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadContact_MobileNo").ToString())
                txtofficeno.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadContact_OfficeNo").ToString())
                txtextention.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadContact_Extention").ToString())
                hfcontactid.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadContact_Id").ToString())
				hfleadid.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadContact_LeadId").ToString())
                ddlnotifyby.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadContact_Notifyby").ToString())
			End If
		Catch ex As Exception
			Dim error1 As String = ex.Message.Replace(Chr(34), "")
			error1 = error1.Replace(Chr(39), "")
			ExecptionBLL.Insert("ModifyLeadContact", "FillContactDetail", error1, Session("UserId"))
			'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
			Throw ex
		End Try
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
			ExecptionBLL.Insert("ModifyLeadContact", "FillDesignation", error1, Session("UserId"))
			'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
			Throw ex
		End Try
	End Sub

	Sub AtLeastOneContact_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
		If txtemail.Text & txtofficeno.Text & txtmob.Text <> "" Then
			args.IsValid = True
		Else
			args.IsValid = False
		End If
	End Sub

	Protected Sub hfcancel_Click(sender As Object, e As EventArgs) Handles hfcancel.Click
		Try
			MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
			If Request.QueryString("returnurl") = "y" And MainID <> 0 Then
				Response.Redirect("ViewLead.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(hfleadid.Value.ToString)))
			Else
				Response.Redirect("Lead.aspx")
			End If
		Catch ex As Exception
			Dim error1 As String = ex.Message.Replace(Chr(34), "")
			error1 = error1.Replace(Chr(39), "")
			ExecptionBLL.Insert("ModifyLeadContact", "hfcancel_Click", error1, Session("UserId"))
			ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
		End Try
	End Sub

	Protected Sub HyperLink1_Click(sender As Object, e As EventArgs) Handles HyperLink1.Click
		Try
			MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
			If Request.QueryString("returnurl") = "y" And MainID <> 0 Then
				Response.Redirect("ViewLead.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(hfleadid.Value.ToString())))
			Else
				Response.Redirect("Lead.aspx")
			End If
		Catch ex As Exception
			Dim error1 As String = ex.Message.Replace(Chr(34), "")
			error1 = error1.Replace(Chr(39), "")
			ExecptionBLL.Insert("ModifyLeadContact", "HyperLink1_Click", error1, Session("UserId"))
			ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
		End Try
	End Sub

	Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
		Try
            LeadContactBLL.Update(ddltitle.SelectedValue, txtname.Text.Trim, ddldesignation.SelectedValue, txtemail.Text.Trim, txtmob.Text.Trim,
                                  txtofficeno.Text.Trim, txtextention.Text.Trim, Session("UserId"), hfcontactid.Value, Session("Audlog_Id"), ddlnotifyby.SelectedValue)
			If Request.QueryString("returnurl") = "y" Then
				Response.Redirect("ViewLead.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(hfleadid.Value())))
			Else
				Response.Redirect("Lead.aspx")
			End If
		Catch ex As Exception
			Dim error1 As String = ex.Message.Replace(Chr(34), "")
			error1 = error1.Replace(Chr(39), "")
			ExecptionBLL.Insert("ModifyLeadConatct", "btnadd_Click", error1, Session("UserId"))
			ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
		End Try
	End Sub

	Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Try
            LeadContactBLL.Update(ddltitle.SelectedValue, txtname.Text.Trim, ddldesignation.SelectedValue, txtemail.Text.Trim, txtmob.Text.Trim,
                                  txtofficeno.Text.Trim, txtextention.Text.Trim, Session("UserId"), hfcontactid.Value, Session("Audlog_Id"), ddlnotifyby.SelectedValue)
			If Request.QueryString("returnurl") = "y" Then
                Response.Redirect("ViewLead.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(hfleadid.Value.ToString)))
            Else
                Response.Redirect("Lead.aspx")
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyLeadConatct", "Button1_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class
