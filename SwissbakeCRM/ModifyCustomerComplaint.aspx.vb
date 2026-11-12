Imports DynamicparcelEnumerations

Partial Class ModifyCustomerComplaint
    Inherits System.Web.UI.Page
    Dim MainID As Integer
    Dim Type As String
    Dim TypeID As Integer

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
            Try
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("index.aspx")
                End If
                If Request.QueryString("chk") = "e" Then
                    lbltitle1.Text = "Modify Customer Complaint"
                    lbltitle2.Text = "Modify Customer Complaint"
                Else
                    lbltitle1.Text = "New Customer Complaint"
                    lbltitle2.Text = "New Customer Complaint"
                End If
                'DynamicparcelGridview.CheckPrivilageForModify(Session("UserRoleID"), Button1, btnadd, "CustomerComplaint.aspx")
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyCustomerComplaint", "Page_Init", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "');window.location='index.aspx';", True)
            End Try
        Else
            Try
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("index.aspx")
                End If
                If Request.QueryString("chk") = "e" Then
                    lbltitle1.Text = "Modify Customer Complaint"
                    lbltitle2.Text = "Modify Customer Complaint"
                Else
                    lbltitle1.Text = "New Customer Complaint"
                    lbltitle2.Text = "New Customer Complaint"
                End If
                'DynamicparcelGridview.CheckPrivilageForModify(Session("UserRoleID"), Button1, btnadd, "CustomerComplaint.aspx")
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyCustomerComplaint", "Page_Init", error1, Session("UserId"))
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

                    assigncontrol.Uhftype.Value = "Customer Complaint"
                    assigncontrol.Uhftypeid.Value = MainID
                    modifyspan.Visible = False
                    '  FillAccount()
                    ' FillProspect()
                    ddtype_TextChanged(Nothing, Nothing)
                    FillProduct()
                    If Not MainID = "0" Then
                        modifyspan.Visible = True
                        FillDetail()
                    Else
                        txtcomplaintcode.Text = MainBLL.GetGodownCode("ComplaintCode")
                        txtfeedback_TextChanged(Nothing, Nothing)
                        If Not Request.QueryString("type") = Nothing Then
                            If Request.QueryString("type") = "A" Then
                                ddtype.SelectedValue = "Account"
                                ddtype_TextChanged(Nothing, Nothing)
                                'ddtypeid.SelectedValue = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("typeId")))
                            Else
                                ddtype.SelectedValue = "Prospect"
                                ddtype_TextChanged(Nothing, Nothing)
                                'ddtypeid.SelectedValue = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("typeId")))
                            End If
                            ddtypeid.SelectedValue = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("typeId")))
                            'ddtype.Enabled = False
                            'ddtypeid.Enabled = False
                        End If
                    End If
                Catch ex As Exception
                    Response.Redirect("index.aspx")
                End Try
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyCustomerComplaint", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try
                    Type = ddtype.SelectedValue
                    TypeID = ddtypeid.SelectedValue

                    SolutionBLL.Update(txtcomplaintcode.Text, ddproduct.SelectedValue, Type, TypeID, txtbatch.Text, txtinvoice.Text, txttitle.Text, txtdiscription.Text,
                                         txtexterneal.Text, txtinternal.Text, chksolution.Checked, txtaction.Text, txtprevent.Text, txtfeedback.Text, Session("UserId"), MainID, Session("Audlog_Id"))
                    assigncontrol.AddAssignTo(MainID)
                    Response.Redirect("CustomerComplaint.aspx")
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ModifyCustomerComplaint", "UPDATE", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Case DML_OPERATION.INSERT
                Try
                    Type = ddtype.SelectedValue
                    TypeID = ddtypeid.SelectedValue
                    Dim ComplaintID As Integer = SolutionBLL.Insert(txtcomplaintcode.Text, ddproduct.SelectedValue, Type, TypeID, txtbatch.Text, txtinvoice.Text, txttitle.Text, txtdiscription.Text,
                                          txtexterneal.Text, txtinternal.Text, chksolution.Checked, txtaction.Text, txtprevent.Text, txtfeedback.Text, Session("UserId"), Session("Audlog_Id"))
                    assigncontrol.AddAssignTo(ComplaintID)

                    Dim dateAsString = DateTime.Now.ToString("yyyy-MM-dd")

                    Dim name As String = Session("UName")
                    name = name.Replace(" ", "-")
                    'SendUsingSMPP.SendSMS("Complaint " + txtcomplaintcode.Text + " received from " + SmsBLL.CustomerName(TypeID).Replace(" ", "_") + ". Complaint posted by " + name + " on " + dateAsString + ".", "9892127786")
                    Dim customerName As String = SmsBLL.CustomerName(ddtypeid.SelectedValue)

                    Dim complaintParams As New List(Of String) From {
                    txtcomplaintcode.Text,
                    customerName,
                    name,
                    dateAsString
}

                    SendUsingSMPP.SendWhatsAppMessage("8309252022", "complaint_received", complaintParams) '9892127786
                    Response.Redirect("CustomerComplaint.aspx")
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ModifyCustomerComplaint", "INSERT", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select

    End Sub

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If Page.IsValid Then
                If MainID = 0 Then
                    SaveProduct(DML_OPERATION.INSERT)
                ElseIf MainID > 0 Then
                    SaveProduct(DML_OPERATION.UPDATE)
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyCustomerComplaint", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub


    Public Sub FillDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "SolutionViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                txtcomplaintcode.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustComplaint_No").ToString())
                ddproduct.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustComplaint_ProID").ToString())
                '  ddaccount.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustComplaint_AccID").ToString())
                ' ddprospect.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustComplaint_ProspID").ToString())
                ddtype.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustComplaint_Type").ToString())
                hfCustId.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustComplaint_AccID").ToString())
                ddtype_TextChanged(Nothing, Nothing)
                ddtypeid.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustComplaint_AccID").ToString())
                '
                txtbatch.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustComplaint_BatchNo").ToString())
                txtinvoice.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustComplaint_InvoiceNo").ToString())
                txttitle.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustComplaint_Title").ToString())
                txtdiscription.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustComplaint_Desc").ToString())
                txtexterneal.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustComplaint_RCExt").ToString())
                txtinternal.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustComplaint_RCInt").ToString())
                chksolution.Checked = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustComplaint_Solution").ToString())
                txtaction.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustComplaint_Action").ToString())
                txtprevent.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustComplaint_Prevent").ToString())
                txtfeedback.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CustComplaint_Feedback").ToString())
                txtfeedback_TextChanged(Nothing, Nothing)
                lblmodifieddate.Text = DynamicparcelDataManipulation.AlphaDateFormat(drLogin("CustComplaint_ModifiedDate").ToString())
                lblmodifiedname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyCustomerComplaint", "FillDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillProduct()
        Try
            ddproduct.DataSource = MainBLL.Dropdown("ProductDropDown")
            ddproduct.DataTextField = "Product_Name"
            ddproduct.DataValueField = "Product_Id"
            ddproduct.DataBind()
            ddproduct.Items.Insert(0, New ListItem("None", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyCustomerComplaint", "FillProduct", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub hfcancel_Click(sender As Object, e As EventArgs) Handles hfcancel.Click
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            'If Request.QueryString("returnurl") = "y" And MainID <> 0 Then
            '    Response.Redirect("ViewLead.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())))
            'Else
            Response.Redirect("CustomerComplaint.aspx")
            'End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyCustomerComplaint", "hfcancel_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub txtfeedback_TextChanged(sender As Object, e As EventArgs) Handles txtfeedback.TextChanged
        ChkVaue()
    End Sub

    Protected Sub txtexterneal_textchanged(sender As Object, e As EventArgs)
        ChkVaue()
    End Sub

    Protected Sub txtprevent_TextChanged(sender As Object, e As EventArgs)
        ChkVaue()
    End Sub

    Protected Sub txtaction_TextChanged(sender As Object, e As EventArgs)
        ChkVaue()
    End Sub

    Protected Sub txtinternal_TextChanged(sender As Object, e As EventArgs)
        ChkVaue()
    End Sub

    Public Function IsEnable() As Boolean
        If txtfeedback.Text = "" Then
            Return False
        End If
        If txtinternal.Text = "" Then
            Return False
        End If
        If txtexterneal.Text = "" Then
            Return False
        End If
        If txtprevent.Text = "" Then
            Return False
        End If
        If txtaction.Text = "" Then
            Return False
        End If
        Return True
    End Function

    Public Sub ChkVaue()
        If IsEnable() Then
            chksolution.Enabled = True
        Else
            chksolution.Enabled = False
            chksolution.Checked = False
        End If
    End Sub

    'Public Sub FillAccount()
    '    Try
    '        ddaccount.DataSource = MainBLL.DropdownWithtype("ALLAccountDropDown", "Account")
    '        ddaccount.DataTextField = "Acc_Name"
    '        ddaccount.DataValueField = "Acc_Id"
    '        ddaccount.DataBind()
    '        ddaccount.Items.Insert(0, New ListItem("None", "0"))
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert("ModifyCustomerComplaint", "FillAccount", error1, Session("UserId"))
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub
    'Public Sub FillProspect()
    '    Try

    '        ddprospect.DataSource = MainBLL.DropdownWithtype("ALLAccountDropDown", "Prospect")
    '        ddprospect.DataTextField = "Acc_Name"
    '        ddprospect.DataValueField = "Acc_Id"
    '        ddprospect.DataBind()
    '        ddprospect.Items.Insert(0, New ListItem("None", "0"))
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Protected Sub ddtype_TextChanged(sender As Object, e As EventArgs) Handles ddtype.TextChanged
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If MainID <> 0 Then
                Dim type As String
                If hfCustId.Value <> "" Then
                    type = MainBLL.AccTypeByID("AccTypeByID", hfCustId.Value)
                Else
                    type = MainBLL.AccTypeByID("AccTypeByID", MainID)
                End If
                ddtype.SelectedValue = Type
            End If
            If ddtype.SelectedValue = "Account" Then
                ddtypeid.DataSource = MainBLL.DropdownWithtype("ALLAccountDropDown", "Account")
                ddtypeid.DataTextField = "Acc_Name"
                ddtypeid.DataValueField = "Acc_Id"
                ddtypeid.DataBind()
                ddtypeid.Items.Insert(0, New ListItem("None", "0"))
            ElseIf ddtype.SelectedValue = "Prospect" Then
                ddtypeid.DataSource = MainBLL.DropdownWithtype("ALLAccountDropDown", "Prospect")
                ddtypeid.DataTextField = "Acc_Name"
                ddtypeid.DataValueField = "Acc_Id"
                ddtypeid.DataBind()
                ddtypeid.Items.Insert(0, New ListItem("None", "0"))
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Opportunity", "ddtype_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub CheckPrivi() 'MUBYN
        Try
            Dim ds As DataSet = UserBLL.CheckPrivi(Session("UserRoleID"), "CustomerComplaint.aspx")
            Dim strArr() As String
            Dim TemStr As String = ""
            Dim dtPrivi As New DataTable
            dtPrivi = Session("dtPrivilege")
            Dim rows() As DataRow = dtPrivi.Select("Menu_URL = 'CustomerComplaint.aspx'")

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
End Class
