Imports DynamicparcelEnumerations

Partial Class ModifyProspect
    Inherits System.Web.UI.Page
    Dim MainID As Integer

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
            Try
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("index.aspx")
                End If
                If Request.QueryString("chk") = "e" Then
                    lbltitle1.Text = "Modify Prospect"
                    lbltitle2.Text = "Modify Prospect"
                Else
                    lbltitle1.Text = "New Prospect"
                    lbltitle2.Text = "New Prospect"
                End If
                DynamicparcelGridview.CheckPrivilageForModify(Session("UserRoleID"), Button1, btnadd, "Prospect.aspx")
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyProspect", "Page_Init", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "');window.location='index.aspx';", True)
            End Try
        Else
            Try
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("index.aspx")
                End If
                If Request.QueryString("chk") = "e" Then
                    lbltitle1.Text = "Modify Prospect"
                    lbltitle2.Text = "Modify Prospect"
                Else
                    lbltitle1.Text = "New Prospect"
                    lbltitle2.Text = "New Prospect"
                End If
                DynamicparcelGridview.CheckPrivilageForModify(Session("UserRoleID"), Button1, btnadd, "Prospect.aspx")
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyProspect", "Page_Init", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "');window.location='index.aspx';", True)
            End Try
        End If
       End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                CheckPrivi()
                assigncontrol.Uhftype.Value = "Prospect"
                assigncontrol.Uhftypeid.Value = MainID
                FillSource()
                FillCampaign()
                FillIndustry()
                FillCompanyType()
                FillCountry()
                FillStatebill()
                FillCountryShip()
                FillStateShip()
                FillDesignation()
				FillBanks()		   
                divcampaign.Visible = False
                If Not MainID = "0" Then
                    FillDetail()
                    FillContactDetail()
                    FillBillingAddressDetail()
                    FillShippingAddressDetail()
                    shipdiv.Visible = True
                    chksameadd.Checked = False
                    divcode.Visible = True
                    modifyspan.Visible = True
                Else
                    modifyspan.Visible = False
                    divcode.Visible = False
                    shipdiv.Visible = False
                    chksameadd.Checked = True
                    divcampaign.Visible = False
                End If
            Catch ex As Exception
                Response.Redirect("index.aspx")
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyProspect", "Page_Load", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
    End Sub

    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try
                    ProspectBLL.Update(txtProspectname.Text.Trim, ddlindustry.SelectedValue, txtdiscription.Text, ddlsource.SelectedValue, ddlcamp.SelectedValue, Session("UserId"), ddlcompnytype.SelectedValue, txtwebsite.Text.Trim, txtturnover.Text.Trim, Session("UserId"), MainID, Session("Audlog_Id"), "", "account", "", "0", txtemail.Text, txtvat.Text, txtpan.Text, txttin.Text, "0", txtGST.Text.Trim, ddCategory.SelectedValue.Trim, 1, 0, ddlBank.SelectedItem.Value)
					ProspectContactBLL.Update(ddltitle.SelectedValue, txtname.Text.Trim, ddldesignation.SelectedValue, txtemail.Text.Trim, txtmob.Text.Trim, txtofficeno.Text.Trim, txtextention.Text.Trim, Session("UserId"), "Prospect", MainID, Session("Audlog_Id"), "True", "", 0, Date.Now(), "", "", 0, "", MainID, ddlnotifyby.SelectedItem.Text)
                    ProspectAddressBLL.Update(MainID, "Billing", txtaddname.Text.Trim, txtaddemail.Text.Trim, "", txtaddphone.Text, "", txtaddressbill.Text.Trim, txtcitybill.Text, ddlstatebill.SelectedValue, ddlcountrybill.SelectedValue, txtpincodebill.Text, Session("UserId"), txtGST.Text.Trim)
					If chksameadd.Checked Then
                        ProspectAddressBLL.UpdateShipping(hfAccAddrShipID.Value, "Shipping", txtaddname.Text.Trim, txtaddemail.Text.Trim, "", txtaddphone.Text, "", txtaddressbill.Text.Trim, txtcitybill.Text, ddlstatebill.SelectedValue, ddlcountrybill.SelectedValue, txtpincodebill.Text, Session("UserId"), txtGST.Text.Trim)
					Else
                        ProspectAddressBLL.UpdateShipping(hfAccAddrShipID.Value, "Shipping", txtaddnameship.Text.Trim, txtaddemailship.Text.Trim, "", txtaddphoneship.Text, "", txtaddship.Text.Trim, txtcityship.Text, ddlstateship.SelectedValue, ddlcountryship.SelectedValue, txtpincodeship.Text, Session("UserId"), txtGSTShip.Text.Trim)
					End If
                    assigncontrol.AddAssignTo(MainID)
                    Dim uid As Integer? = Nothing
                    If Session("UserId") IsNot Nothing AndAlso IsNumeric(Session("UserId")) Then
                        uid = Convert.ToInt32(Session("UserId"))
                    End If
                    ActivityLogger.SaveLog(
        uid,
        Session("UName").ToString(),
"PROSPECT_UPDATED",
"Prospect",
Nothing,
        "prospect Created successfully |  Prospect Name : " & txtProspectname.Text, Request)
                    If Request.QueryString("returnurl") = "y" Then
						Response.Redirect("ViewProspect.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())))
					Else
						Response.Redirect("Prospect.aspx")
					End If
				Catch ex As Exception
					Dim error1 As String = ex.Message.Replace(Chr(34), "")
					error1 = error1.Replace(Chr(39), "")
					ExecptionBLL.Insert("ModifyProspect", "UPDATE", error1, Session("UserId"))
					ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
				End Try
			Case DML_OPERATION.INSERT
				Try
                    MainID = ProspectBLL.Insert(txtProspectname.Text.Trim, ddlindustry.SelectedValue, txtdiscription.Text, ddlsource.SelectedValue, ddlcamp.SelectedValue, Session("UserId"), ddlcompnytype.SelectedValue, txtwebsite.Text.Trim, txtturnover.Text.Trim, Session("UserId"), Session("Audlog_Id"), "", "account", "", "0", txtemail.Text, txtvat.Text, txtpan.Text, txttin.Text, "Prospect", "0", txtGST.Text.Trim, ddCategory.SelectedValue.Trim, 1, 0, ddlBank.SelectedItem.Value)
					ProspectContactBLL.Insert(ddltitle.SelectedValue, txtname.Text.Trim, ddldesignation.SelectedValue, txtemail.Text.Trim, txtmob.Text.Trim, txtofficeno.Text.Trim, txtextention.Text.Trim, Session("UserId"), "Prospect", MainID, Session("Audlog_Id"), "True", "", 0, Date.Now(), "", "", 0, "", ddlnotifyby.SelectedItem.Text)
                    ProspectAddressBLL.Insert(MainID, "Billing", txtaddname.Text.Trim, txtaddemail.Text.Trim, "", txtaddphone.Text, "", txtaddressbill.Text.Trim, txtcitybill.Text, ddlstatebill.SelectedValue, ddlcountrybill.SelectedValue, txtpincodebill.Text, Session("UserId"), txtGST.Text.Trim)
					If chksameadd.Checked Then
                        ProspectAddressBLL.Insert(MainID, "Shipping", txtaddname.Text.Trim, txtaddemail.Text.Trim, "", txtaddphone.Text, "", txtaddressbill.Text.Trim, txtcitybill.Text, ddlstatebill.SelectedValue, ddlcountrybill.SelectedValue, txtpincodebill.Text, Session("UserId"), txtGST.Text.Trim)
					Else
                        ProspectAddressBLL.Insert(MainID, "Shipping", txtaddnameship.Text.Trim, txtaddemailship.Text.Trim, "", txtaddphoneship.Text, "", txtaddship.Text.Trim, txtcityship.Text, ddlstateship.SelectedValue, ddlcountryship.SelectedValue, txtpincodeship.Text, Session("UserId"), txtGSTShip.Text.Trim)
					End If
                    assigncontrol.AddAssignTo(MainID)

                    Dim uid As Integer? = Nothing
                    If Session("UserId") IsNot Nothing AndAlso IsNumeric(Session("UserId")) Then
                        uid = Convert.ToInt32(Session("UserId"))
                    End If
                    ActivityLogger.SaveLog(
        uid,
        Session("UName").ToString(),
"PROSPECT_CREATED",
"Prospect",
Nothing,
        "Prospect Created successfully |  Prospect Name : " & txtProspectname.Text, Request)
                    If Request.QueryString("returnurl") = "y" Then
						Response.Redirect("ViewProspect.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())))
					Else
						Response.Redirect("Prospect.aspx")
					End If
				Catch ex As Exception
					Dim error1 As String = ex.Message.Replace(Chr(34), "")
					error1 = error1.Replace(Chr(39), "")
					ExecptionBLL.Insert("ModifyProspect", "INSERT", error1, Session("UserId"))
					ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
				End Try
		End Select
	End Sub

	Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
		Try
			MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
			If Page.IsValid Then
                If lblemail.Visible = False Then
                    If MainID = 0 Then
                        Dim CheckPageName As String = MainBLL.CheckPageName(txtProspectname.Text.Trim, "AccProNameCheck")
                        If (CheckPageName = "Already Exist") Then
                            lblname.Text = "name already exist"
                            txtProspectname.Focus()
                        ElseIf (CheckPageName = "Account") Then
                            lblname.Text = "name already exist in Account"
                            txtProspectname.Focus()
                        ElseIf (CheckPageName = "Prospect") Then
                            lblname.Text = "name already exist in Prospect"
                            txtProspectname.Focus()
                        Else
                            SaveProduct(DML_OPERATION.INSERT)
                        End If
                    ElseIf MainID > 0 Then
                        If txtProspectname.Text.Trim <> hfProspName.Value.Trim Then
                            Dim CheckPageName As String = MainBLL.CheckPageName(txtProspectname.Text.Trim, "AccProNameCheck")
                            If (CheckPageName = "Already Exist") Then
                                lblname.Text = "name already exist"
                                txtProspectname.Focus()
                            ElseIf (CheckPageName = "Account") Then
                                lblname.Text = "name already exist in Account"
                                txtProspectname.Focus()
                            ElseIf (CheckPageName = "Prospect") Then
                                lblname.Text = "name already exist in Prospect"
                                txtProspectname.Focus()
                            Else
                                SaveProduct(DML_OPERATION.UPDATE)
                            End If
                        Else
                            SaveProduct(DML_OPERATION.UPDATE)
                        End If
                    End If
                Else
                    txtemail.Focus()
                End If
            End If
		Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyProspect", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
	End Sub


	Public Sub FillDetail()
		Try
			MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
			Dim dt As DataSet = MainBLL.ViewByID(MainID, "ProspectViewByID")
			Dim dtUser As New DataTable
			dtUser = dt.Tables(0)
			If dtUser.Rows.Count > 0 Then
				Dim drLogin As DataRow
				drLogin = dtUser.Rows(0)
				divcode.Visible = True
                txtProspectname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
                hfProspName.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
				txtcode.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Code").ToString())
				ddlsource.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_SourceID").ToString())
				Dim Acc_CampaignID As String = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_CampaignID").ToString())
				If Acc_CampaignID <> "0" Then
					divcampaign.Visible = True
					ddlcamp.SelectedValue = Acc_CampaignID
				Else
					ddlcamp.SelectedValue = Acc_CampaignID
					divcampaign.Visible = False
				End If
				ddlcompnytype.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_CompanyTypeID").ToString())
				ddlindustry.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_IndustryId").ToString())
				If drLogin("Acc_Category").ToString() <> "" Then
					ddCategory.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Category").Trim.ToString())

				End If
				txtturnover.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_TurnOver").ToString())
				txtwebsite.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Website").ToString())
				lblconvertdate.Text = DynamicparcelDataManipulation.DateFormat(drLogin("Acc_ConvertDate").ToString())
				txtdiscription.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Description").ToString())
				txtpan.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Cust_Pan").ToString())
				txtvat.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Cust_Vat").ToString())
				txttin.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Cust_Tin").ToString())
				txtGST.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Cust_GST").ToString())
                lblmodifieddate.Text = DynamicparcelDataManipulation.DateFormat(drLogin("Acc_ModifiedDate").ToString())
				lblmodifiedname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
				
				If Not String.IsNullOrEmpty(drLogin("BankId").ToString()) Then
                    ddlBank.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("BankId").ToString())
                End If
				
			End If
		Catch ex As Exception
			Dim error1 As String = ex.Message.Replace(Chr(34), "")
			error1 = error1.Replace(Chr(39), "")
			ExecptionBLL.Insert("ModifyProspect", "FillDetail", error1, Session("UserId"))
			'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
			Throw ex
		End Try
	End Sub

	Public Sub FillContactDetail()
		Try
			MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
			Dim dt As DataSet = MainBLL.ViewByID(MainID, "ProspectContactViewByID")
			Dim dtUser As New DataTable
			dtUser = dt.Tables(0)
			If dtUser.Rows.Count > 0 Then
				Dim drLogin As DataRow
				drLogin = dtUser.Rows(0)
				ddltitle.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Title").ToString())
				txtname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_ContactPerson").ToString())
				ddldesignation.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Designation").ToString())
                txtemail.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Email").ToString())
                hfProspEmail.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Email").ToString())
				txtmob.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Mobile").ToString())
				txtofficeno.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Landline").ToString())
				txtextention.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Extention").ToString())
				ddlnotifyby.SelectedItem.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Notifyby").ToString())
			End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyProspect", "FillContactDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillBillingAddressDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            ' ''Dim dt As DataSet = MainBLL.ViewByID(MainID, "ProspectBillingAddressViewByID")      'MUBYN Commented due to new query made with Left join as state was null 7-11-19
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "BillingAddrByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                txtaddname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Name").ToString())
                txtaddemail.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Email").ToString())
                txtaddphone.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Telephone").ToString())
                txtaddressbill.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Address").ToString())
                txtpincodebill.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Pincode").ToString())
                ddlcountrybill.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Country").ToString())
                ddlcountrybill_SelectedIndexChanged(Nothing, Nothing)
                ddlstatebill.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_State").ToString())
                txtcitybill.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_City").ToString())
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyProspect", "FillBillingAddressDetail", error1, Session("UserId"))
            ' ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillShippingAddressDetail()
        Try
            shipdiv.Visible = True
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            ' ''Dim dt As DataSet = MainBLL.ViewByID(MainID, "ProspectShippingAddressViewByID")'MUBYN due to top 1 desc n addrId reqd
            ' ''Dim dt As DataSet = MainBLL.ViewByID(MainID, "ProspShipAddrViewByIDNew")    'MUBYN Commented due to new query made with Left join as state was null 7-11-19
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "ShippingAddrByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                txtaddnameship.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Name").ToString())
                txtaddemailship.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Email").ToString())
                txtaddphoneship.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Telephone").ToString())
                txtaddship.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Address").ToString())
                txtpincodeship.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Pincode").ToString())
                ddlcountryship.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Country").ToString())
                ddlcountryship_SelectedIndexChanged(Nothing, Nothing)
                ddlstateship.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_State").ToString())
                txtcityship.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_City").ToString())
                txtGSTShip.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_GST").ToString())
                hfAccAddrShipID.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_ID").ToString())
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyProspect", "FillShippingAddressDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    
    Public Sub FillSource()
        Try
            ddlsource.DataSource = MainBLL.Dropdown("SourceDropDown")
            ddlsource.DataTextField = "Source_Name"
            ddlsource.DataValueField = "Source_Id"
            ddlsource.DataBind()
            'ddlsource.Items.Insert(0, New ListItem("Select Source", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyProspect", "FillSource", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillCampaign()
        Try
            ddlcamp.DataSource = MainBLL.Dropdown("CampaignNameDropDown")
            ddlcamp.DataTextField = "Campaign_Name"
            ddlcamp.DataValueField = "Campaign_Id"
            ddlcamp.DataBind()
            ddlcamp.Items.Insert(0, New ListItem("Select Campaign", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyProspect", "FillCampaign", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillIndustry()
        Try
            ddlindustry.DataSource = MainBLL.Dropdown("IndustryDropDown")
            ddlindustry.DataTextField = "Industry_Name"
            ddlindustry.DataValueField = "Industry_Id"
            ddlindustry.DataBind()
            'ddlindustry.Items.Insert(0, New ListItem("Select Industry", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyProspect", "FillIndustry", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillCompanyType()
        Try
            ddlcompnytype.DataSource = MainBLL.Dropdown("CompanyTypeDropDown")
            ddlcompnytype.DataTextField = "CompanyType"
            ddlcompnytype.DataValueField = "CompanyType_ID"
            ddlcompnytype.DataBind()
            'ddlcompnytype.Items.Insert(0, New ListItem("Select Company Type", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyProspect", "FillCompanyType", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
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
            ddlcountrybill.SelectedValue = 105
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyProspect", "FillCountry", error1, Session("UserId"))
            ' ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
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
            ExecptionBLL.Insert("ModifyProspect", "FillStatebill", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillDesignation()
        Try
            'Dim ds As DataSet = MainBLL.Dropdown("DesignationDropDown")
            Dim ds As DataSet = MainBLL.Dropdown("B2bDesignationDropDown")
            ddldesignation.DataSource = ds.Tables(0)
            ddldesignation.DataTextField = "Desig_Name"
            ddldesignation.DataValueField = "Desig_Id"
            ddldesignation.DataBind()

            ' ddldesignation.Items.Insert(0, New ListItem("Select Designation", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyProspect", "FillDesignation", error1, Session("UserId"))
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
            ExecptionBLL.Insert("ModifyProspect", "ddlcountrybill_SelectedIndexChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try

    End Sub

    Protected Sub ddlsource_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlsource.SelectedIndexChanged
        Try
        If ddlsource.SelectedItem.ToString.ToLower = "campaign" Then
            divcampaign.Visible = True
        Else
                divcampaign.Visible = False
                ddlcamp.SelectedIndex = 0
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyProspect", "ddlsource_SelectedIndexChanged", error1, Session("UserId"))
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

    Protected Sub hfcancel_Click(sender As Object, e As EventArgs) Handles hfcancel.Click
        Try
        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If Request.QueryString("returnurl") = "y" And MainID <> 0 Then
                Response.Redirect("ViewProspect.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())))
            Else
                Response.Redirect("Prospect.aspx")
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyProspect", "hfcancel_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub


    Public Sub FillCountryShip()
        Try
            Dim ds As DataSet = MainBLL.Dropdown("CountryDropDown")
            ddlcountryship.DataSource = ds.Tables(0)
            ddlcountryship.DataTextField = "CountryName"
            ddlcountryship.DataValueField = "Id"
            ddlcountryship.DataBind()
            ddlcountryship.Items.Insert(0, New ListItem("Select Country", "0"))
            ddlcountryship.SelectedValue = 105
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyProspect", "FillCountryShip", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillStateShip()
        Try
            ddlstateship.Items.Clear()
            Dim ds As DataSet = MainBLL.DropdownWithID("StateDropDown", ddlcountryship.SelectedValue)
            ddlstateship.DataSource = ds.Tables(0)
            ddlstateship.DataTextField = "StateName"
            ddlstateship.DataValueField = "Id"
            ddlstateship.DataBind()
            ddlstateship.Items.Insert(0, New ListItem("Select State", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyProspect", "FillStateShip", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try

    End Sub


    Protected Sub chksameadd_CheckedChanged(sender As Object, e As EventArgs) Handles chksameadd.CheckedChanged
        Try
            If chksameadd.Checked Then
                shipdiv.Visible = False
                txtaddnameship.Text = txtaddname.Text
                txtaddemailship.Text = txtaddemail.Text
                txtaddphoneship.Text = txtaddphone.Text
                ddlcountryship.SelectedValue = ddlcountrybill.SelectedValue
                txtcityship.Text = txtcitybill.Text
                txtpincodeship.Text = txtpincodebill.Text
                txtaddship.Text = txtaddressbill.Text
                ddlcountryship_SelectedIndexChanged(Nothing, Nothing)
                ddlstateship.SelectedValue = ddlstatebill.SelectedValue
            Else
                shipdiv.Visible = True
                txtaddnameship.Text = ""
                txtaddemailship.Text = ""
                txtaddphoneship.Text = ""
                txtcityship.Text = ""
                txtpincodeship.Text = ""
                txtaddship.Text = ""
                ddlcountryship.ClearSelection()
                ddlstateship.ClearSelection()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyProspect", "chksameadd_CheckedChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddlcountryship_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlcountryship.SelectedIndexChanged
        Try
            FillStateShip()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyProspect", "ddlcountryship_SelectedIndexChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub CheckPrivi()
        Try
            Dim ds As DataSet = UserBLL.CheckPrivi(Session("UserRoleID"), "Prospect.aspx")
            Dim strArr() As String
            Dim TemStr As String = ""
            Dim dtPrivi As New DataTable
            dtPrivi = Session("dtPrivilege")
            Dim rows() As DataRow = dtPrivi.Select("Menu_URL = 'Prospect.aspx'")

            TemStr = rows(0).Item("Val").ToString()
            strArr = TemStr.Split(",")
            If (strArr.Length > 3) Then
                If MainID = 0 Then
                    If strArr(0) = "1" Then
                    Else
                        Response.Redirect("index.aspx")
                    End If
                Else
                    If strArr(1) = "1" Or strArr(2) = "1" Or strArr(3) = "1" Then
                    Else
                        Response.Redirect("index.aspx")
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtemail_TextChanged(sender As Object, e As EventArgs) Handles txtemail.TextChanged
        Try
            If txtemail.Text <> "" Then
                If txtemail.Text.Trim <> hfProspEmail.Value.Trim Then
                    Dim check As String = MainBLL.CheckEmail(txtemail.Text, "AccProEmailCheck")
                    If check = "Already Exist" Then
                        lblemail.Text = "Email already exist"
                        lblemail.Visible = True
                        txtemail.Focus()
                    Else
                        lblemail.Visible = False
                    End If
                Else
                    lblemail.Visible = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
	Public Sub FillBanks()
        ddlBank.DataSource = ProspectBLL.Dropdown()
        ddlBank.DataTextField = "Name"
        ddlBank.DataValueField = "Id"
        ddlBank.DataBind()
        ddlBank.Items.Insert(0, New ListItem("Select Bank", "0"))
    End Sub					  
End Class
