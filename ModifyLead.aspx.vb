Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports DynamicparcelEnumerations

Partial Class ModifyLead
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
                    divstage.Visible = False
                    divdiscription.Visible = True
                    lbltitle1.Text = "Modify Lead"
                    lbltitle2.Text = "Modify Lead"
                Else
                    divstage.Visible = False
                    divdiscription.Visible = False
                    lbltitle1.Text = "New Lead"
                    lbltitle2.Text = "New Lead"
                End If
                DynamicparcelGridview.CheckPrivilageForModify(Session("UserRoleID"), Button1, btnadd, "Lead.aspx")
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyLead", "Page_Init", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "');window.location='index.aspx';", True)
            End Try
        Else
            Try
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("index.aspx")
                End If
                If Request.QueryString("chk") = "e" Then
                    divstage.Visible = False
                    divdiscription.Visible = True
                    lbltitle1.Text = "Modify Lead"
                    lbltitle2.Text = "Modify Lead"
                Else
                    divstage.Visible = False
                    divdiscription.Visible = False
                    lbltitle1.Text = "New Lead"
                    lbltitle2.Text = "New Lead"
                End If
                DynamicparcelGridview.CheckPrivilageForModify(Session("UserRoleID"), Button1, btnadd, "Lead.aspx")
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyLead", "Page_Init", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "');window.location='index.aspx';", True)
            End Try
        End If



    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Try
                    MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                    CheckPrivi()
                    assigncontrol.Uhftype.Value = "Lead"
                    assigncontrol.Uhftypeid.Value = MainID
                    FillLeadType()
                    FillSource()
                    FillCampaign()
                    FillIndustry()
                    FillCompanyType()
                    FillCountry()
                    FillStatebill()
                    FillDesignation()
                    FillStage()
                    modifyspan.Visible = False
                    divcampaign.Visible = False
                    txtleaddate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                    If Not MainID = "0" Then
                        modifyspan.Visible = True
                        FillDetail()
                        FillContactDetail()
                        FillAddressDetail()
                    End If
                Catch ex As Exception
                    Response.Redirect("index.aspx")
                End Try
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyLead", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try
                    LeadBLL.Update(txtleaddate.Text.Trim, txtleadname.Text.Trim, ddlindustry.SelectedValue, txtdiscription.Text.Trim, ddlsource.SelectedValue, ddlstage.SelectedValue, txtotherref.Text.Trim, Session("UserId"), ddlcompnytype.SelectedValue, ddlleadtype.SelectedValue, txtwebsite.Text.Trim, ddlcamp.SelectedValue, txtturnover.Text.Trim, Session("UserId"), MainID, Session("Audlog_Id"), ddCategory.SelectedValue.Trim)
                    LeadContactBLL.Update(ddltitle.SelectedValue, txtname.Text.Trim, ddldesignation.SelectedValue, txtemail.Text.Trim, txtmob.Text.Trim,
txtofficeno.Text.Trim, txtextention.Text.Trim, Session("UserId"), hfcontactid.Value, Session("Audlog_Id"), ddlnotifyby.SelectedItem.Text)
                    LeadAddressBLL.Update(txtaddressbill.Text.Trim, txtcitybill.Text.Trim, ddlstatebill.SelectedValue, ddlcountrybill.SelectedValue, txtpincodebill.Text.Trim,
Session("UserId"), MainID, "Billing", Session("Audlog_Id"))
                    assigncontrol.AddAssignTo(MainID)
                    Dim uid As Integer? = Nothing
                    If Session("UserId") IsNot Nothing AndAlso IsNumeric(Session("UserId")) Then
                        uid = Convert.ToInt32(Session("UserId"))
                    End If
                    ActivityLogger.SaveLog(
        uid,
        Session("UName").ToString(),
"LEAD_UPDATED",
"Lead",
Nothing,
        "Lead Update successfully |  Lead Name : " & txtleadname.Text, Request)
                    If Request.QueryString("returnurl") = "y" Then
                        Response.Redirect("ViewLead.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())))
                    Else
                        Response.Redirect("Lead.aspx")
                    End If
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ModifyLead", "UPDATE", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Case DML_OPERATION.INSERT
                Try
                    Dim CheckPageName As String = MainBLL.CheckPageName(txtleadname.Text.Trim, "AccProNameCheck")
                    If (CheckPageName = "Already Exist") Then
                        lblname.Text = "name already exist"
                        txtleadname.Focus()
                    ElseIf (CheckPageName = "Account") Then
                        lblname.Text = "name already exist in Account"
                        txtleadname.Focus()
                    ElseIf (CheckPageName = "Prospect") Then
                        lblname.Text = "name already exist in Prospect"
                        txtleadname.Focus()
                    Else
                        MainID = LeadBLL.Insert(txtleaddate.Text.Trim, txtleadname.Text.Trim, ddlindustry.SelectedValue, "", ddlsource.SelectedValue, 1, txtotherref.Text.Trim, Session("UserId"), ddlcompnytype.SelectedValue, ddlleadtype.SelectedValue, txtwebsite.Text.Trim, ddlcamp.SelectedValue, txtturnover.Text.Trim, Session("UserId"), Session("Audlog_Id"), ddCategory.SelectedValue.Trim)
                        LeadContactBLL.Insert(ddltitle.SelectedValue, txtname.Text.Trim, ddldesignation.SelectedValue, txtemail.Text.Trim, txtmob.Text.Trim, txtofficeno.Text.Trim, txtextention.Text.Trim, Session("UserId"), MainID, Session("Audlog_Id"), True, ddlnotifyby.SelectedItem.Text)
                        LeadAddressBLL.Insert(txtaddressbill.Text.Trim, txtcitybill.Text.Trim, ddlstatebill.SelectedValue, ddlcountrybill.SelectedValue, txtpincodebill.Text.Trim, Session("UserId"), MainID, "Billing", Session("Audlog_Id"))
                        assigncontrol.AddAssignTo(MainID)

                        Dim uid As Integer? = Nothing
                        If Session("UserId") IsNot Nothing AndAlso IsNumeric(Session("UserId")) Then
                            uid = Convert.ToInt32(Session("UserId"))
                        End If
                        ActivityLogger.SaveLog(
        uid,
        Session("UName").ToString(),
"LEAD_CREATED",
"Lead",
Nothing,
        "Lead Created successfully |  Lead Name : " & txtleadname.Text, Request)
                        ''Add This Line For DocumentBLL Control 
                        'documentcontrol.AddDocument(MainID)
                        ''Add This Line For DocumentBLL Control 
                        ''Add This Line For ItemBLL ProductControl 
                        'itemcontrol.AddItem(MainID)
                        ''Add This Line For ItemBLL ProductControl 
                        If Request.QueryString("returnurl") = "y" Then
                            Response.Redirect("ViewLead.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())))
                        Else
                            Response.Redirect("Lead.aspx")
                        End If
                    End If
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ModifyLead", "INSERT", error1, Session("UserId"))
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
                        SaveProduct(DML_OPERATION.INSERT)
                    ElseIf MainID > 0 Then
                        If txtleadname.Text.Trim <> hfLeadName.Value.Trim Then
                            Dim CheckPageName As String = MainBLL.CheckPageName(txtleadname.Text.Trim, "AccProNameCheck")
                            If (CheckPageName = "Already Exist") Then
                                lblname.Text = "name already exist"
                                txtleadname.Focus()
                            ElseIf (CheckPageName = "Account") Then
                                lblname.Text = "name already exist in Account"
                                txtleadname.Focus()
                            ElseIf (CheckPageName = "Prospect") Then
                                lblname.Text = "name already exist in Prospect"
                                txtleadname.Focus()
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
            ExecptionBLL.Insert("ModifyLead", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub


    Public Sub FillDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "LeadViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                txtleadname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead_Name").ToString())
                hfLeadName.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead_Name").ToString())
                txtleaddate.Text = DynamicparcelDataManipulation.DateFormat(drLogin("Lead_Date").ToString())
                ddlleadtype.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead_LeadTypeID").ToString())
                ddlsource.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead_SourceID").ToString())
                If drLogin("Lead_Category").ToString() <> "" Then
                    ddCategory.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead_Category").Trim.ToString())
                End If
                If drLogin("Lead_CampaignId").ToString() <> "0" Then
                    divcampaign.Visible = True
                    ddlcamp.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead_CampaignId").ToString())
                    'Else
                    '    divcampaign.Visible = False
                End If
                ddlcompnytype.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead_CompanyTypeID").ToString())
                ddlindustry.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead_IndustryId").ToString())
                txtturnover.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead_TurnOver").ToString())
                txtwebsite.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead_Website").ToString())
                txtotherref.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead_Reference").ToString())
                ddlstage.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead_StageID").ToString())
                txtdiscription.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead_Description").ToString())
                lblmodifieddate.Text = DynamicparcelDataManipulation.AlphaDateFormat(drLogin("Lead_ModifiedDate").ToString())
                lblmodifiedname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyLead", "FillDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Public Sub FillContactDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "LeadContactViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                ddltitle.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadContact_Title").ToString())
                txtname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadContact_Name").ToString())
                ddldesignation.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadContact_DesigId").ToString())
                txtemail.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadContact_Email").ToString())
                hfLeadEmail.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadContact_Email").ToString())
                txtmob.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadContact_MobileNo").ToString())
                txtofficeno.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadContact_OfficeNo").ToString())
                txtextention.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadContact_Extention").ToString())
                hfcontactid.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadContact_Id").ToString())
                ddlnotifyby.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadContact_Notifyby").ToString())
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyLead", "FillContactDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Public Sub FillAddressDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "LeadAddressViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                txtaddressbill.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadAddress_Address").ToString())
                txtpincodebill.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadAddress_Pincode").ToString())
                ddlcountrybill.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadAddress_Country").ToString())
                ddlstatebill.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadAddress_State").ToString())
                txtcitybill.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadAddress_City").ToString())
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyLead", "FillAddressDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillLeadType()
        Try
            ddlleadtype.DataSource = MainBLL.Dropdown("LeadTypeDropDown")
            ddlleadtype.DataTextField = "LeadType"
            ddlleadtype.DataValueField = "LeadType_ID"
            ddlleadtype.DataBind()
            'ddlleadtype.Items.Insert(0, New ListItem("Select Lead Type", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyLead", "FillLeadType", error1, Session("UserId"))
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
            ExecptionBLL.Insert("ModifyLead", "FillSource", error1, Session("UserId"))
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
            ExecptionBLL.Insert("ModifyLead", "FillCampaign", error1, Session("UserId"))
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
            ExecptionBLL.Insert("ModifyLead", "FillIndustry", error1, Session("UserId"))
            ' ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
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
            ExecptionBLL.Insert("ModifyLead", "FillCompanyType", error1, Session("UserId"))
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
            ExecptionBLL.Insert("ModifyLead", "FillCountry", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillStatebill()
        Try
            ddlstatebill.Items.Clear()
            'ddlstatebill.SelectedValue = ""  ' Clear any existing SelectedValue to prevent "invalid value" error during DataBind
            Dim ds As DataSet = MainBLL.DropdownWithID("StateDropDown", ddlcountrybill.SelectedValue)
            ddlstatebill.DataSource = ds.Tables(0)
            ddlstatebill.DataTextField = "StateName"
            ddlstatebill.DataValueField = "Id"
            ddlstatebill.DataBind()
            ddlstatebill.Items.Insert(0, New ListItem("Select State", "0"))
            ddlstatebill.SelectedIndex = 0  ' Ensure the "Select State" item is selected by default
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            Dim lineNumber As Int32 = GetLineNumber(ex)

            ExecptionBLL.Insert("ModifyLead", "FillStatebill", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Public Function GetLineNumber(ByVal ex As Exception)
        Dim lineNumber As Int32 = 0
        Const lineSearch As String = ":line "
        Dim index = ex.StackTrace.LastIndexOf(lineSearch)
        If index <> -1 Then
            Dim lineNumberText = ex.StackTrace.Substring(index + lineSearch.Length)
            If Int32.TryParse(lineNumberText, lineNumber) Then
            End If
        End If
        Return lineNumber
    End Function

    Public Sub FillDesignation()
        Try
            'Dim ds As DataSet = MainBLL.Dropdown("DesignationDropDown")
            Dim ds As DataSet = MainBLL.Dropdown("B2bDesignationDropDown")
            ddldesignation.DataSource = ds.Tables(0)
            ddldesignation.DataTextField = "Desig_Name"
            ddldesignation.DataValueField = "Desig_Id"
            ddldesignation.DataBind()
            'ddldesignation.Items.Insert(0, New ListItem("Select Designation", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyLead", "FillDesignation", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillStage()
        Try
            Dim ds As DataSet = MainBLL.Dropdown("StageDropDown")
            ddlstage.DataSource = ds.Tables(0)
            ddlstage.DataTextField = "Stage_Name"
            ddlstage.DataValueField = "Stage_Id"
            ddlstage.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyLead", "FillStage", error1, Session("UserId"))
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
            ExecptionBLL.Insert("ModifyLead", "ddlcountrybill_SelectedIndexChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddlsource_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlsource.SelectedIndexChanged
        Try
            If ddlsource.SelectedItem.ToString.ToLower = "campaign" Then
                divcampaign.Visible = True
            Else
                divcampaign.Visible = False
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyLead", "ddlsource_SelectedIndexChanged", error1, Session("UserId"))
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
                Response.Redirect("ViewLead.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())))
            Else
                Response.Redirect("Lead.aspx")
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyLead", "hfcancel_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub CheckPrivi()
        Try
            Dim ds As DataSet = UserBLL.CheckPrivi(Session("UserRoleID"), "Lead.aspx")
            Dim strArr() As String
            Dim TemStr As String = ""
            Dim dtPrivi As New DataTable
            dtPrivi = Session("dtPrivilege")
            Dim rows() As DataRow = dtPrivi.Select("Menu_URL = 'Lead.aspx'")

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
                If txtemail.Text.Trim <> hfLeadEmail.Value.Trim Then
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
End Class
