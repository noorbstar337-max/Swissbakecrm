Imports DynamicparcelEnumerations

Partial Class UserModify
    Inherits System.Web.UI.Page
    Dim MainID As Integer
    Dim path3 As String

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
            Try
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("index.aspx")
                End If
                DynamicparcelGridview.CheckPrivilageForModify(Session("UserRoleID"), Button1, btnadd, "User.aspx")
                CheckPrivilage()
                If Request.QueryString("chk") = "v" Then
                    txtfirstname.ReadOnly = True
                    txtlastname.ReadOnly = True
                    txtempid.ReadOnly = True
                    txtemail.ReadOnly = True
                    txtmob.ReadOnly = True
                    txtdob.ReadOnly = True
                    txtaddr1.ReadOnly = True
                    txtaddr2.ReadOnly = True
                    txtcity.ReadOnly = True
                    txtpincode.ReadOnly = True
                    txtdoj.ReadOnly = True
                    btnadd.Visible = False
                    Button1.Visible = False
                    ddlstate.CssClass = "form-control"
                    ddlcountry.CssClass = "form-control"
                    ddlusertype.CssClass = "form-control"
                    ddllevel.CssClass = "form-control"
                    ddldept.CssClass = "form-control"
                    ddldesignation.CssClass = "form-control"
                    ddlregion.CssClass = "form-control"
                    ddlemp.CssClass = "form-control"
                    ddlstate.Enabled = False
                    ddlcountry.Enabled = False
                    ddlusertype.Enabled = False
                    ddllevel.Enabled = False
                    ddldept.Enabled = False
                    ddldesignation.Enabled = False
                    ddlregion.Enabled = False
                    ddlemp.Enabled = False
                    ddlservername.Enabled = False
                    txtport.ReadOnly = True
                    txtemailpassword.ReadOnly = True
                    chkSSL.Enabled = False
                    divresetpassword.Visible = False
                    txtdisplayname.Enabled = False
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyUser", "Page_Init", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        Else
            Try
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("index.aspx")
                End If
                DynamicparcelGridview.CheckPrivilageForModify(Session("UserRoleID"), Button1, btnadd, "User.aspx")
                CheckPrivilage()
                If Request.QueryString("chk") = "v" Then
                    txtfirstname.ReadOnly = True
                    txtlastname.ReadOnly = True
                    txtempid.ReadOnly = True
                    txtemail.ReadOnly = True
                    txtmob.ReadOnly = True
                    txtdob.ReadOnly = True
                    txtaddr1.ReadOnly = True
                    txtaddr2.ReadOnly = True
                    txtcity.ReadOnly = True
                    txtpincode.ReadOnly = True
                    txtdoj.ReadOnly = True
                    btnadd.Visible = False
                    Button1.Visible = False
                    ddlstate.CssClass = "form-control"
                    ddlcountry.CssClass = "form-control"
                    ddlusertype.CssClass = "form-control"
                    ddllevel.CssClass = "form-control"
                    ddldept.CssClass = "form-control"
                    ddldesignation.CssClass = "form-control"
                    ddlregion.CssClass = "form-control"
                    ddlemp.CssClass = "form-control"
                    ddlstate.Enabled = False
                    ddlcountry.Enabled = False
                    ddlusertype.Enabled = False
                    ddllevel.Enabled = False
                    ddldept.Enabled = False
                    ddldesignation.Enabled = False
                    ddlregion.Enabled = False
                    ddlemp.Enabled = False
                    ddlservername.Enabled = False
                    txtport.ReadOnly = True
                    txtemailpassword.ReadOnly = True
                    chkSSL.Enabled = False
                    divresetpassword.Visible = False
                    txtdisplayname.Enabled = False
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyUser", "Page_Init", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
        End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
        If Not IsPostBack Then
            Try
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                Filllevel()
                FillDepartment()
                Filldesignation()
                FillCountry()
                FillState()
                FillRegion()
                FillUserType()
                FillUserName()
                If MainID = "0" Then
                    If Not (UserBLL.NoOfUser().ToString = "Allowed") Then
                        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Reach end of user limit\n Contact super Admin');window.location='User.aspx';", True)
                        End If
                        divpass.Visible = True
                        modifyspan.Visible = False
                        divresetpassword.Visible = False
                    Else
                        modifyspan.Visible = True
                        divpass.Visible = False
                        divCpass.Visible = False
                        FillDetail()
                End If
            Catch ex As Exception
                Response.Redirect("index.aspx")
            End Try
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyUser", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Private Sub SaveUser(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try

                    Dim CheckPageName As String = ""
                    If Not txtemail.Text = hfemail.Value Then
                        CheckPageName = MainBLL.CheckPageName(txtemail.Text.Trim, "EmailCheck")
                    End If
                    If CheckPageName = "Already Exist" Then
                        lblemail.Visible = True
                        lblemail.Text = "Email Already Exist"
                    Else
                        UserBLL.Update(txtfirstname.Text.Trim, txtlastname.Text.Trim, txtemail.Text.Trim, txtmob.Text.Trim,
                                        CInt(ddldept.SelectedValue), CInt(ddlemp.SelectedValue), txtaddr1.Text.Trim, txtaddr2.Text.Trim, txtcity.Text.Trim, CInt(ddlstate.SelectedValue), CInt(ddlcountry.SelectedValue),
                                        txtpincode.Text.Trim, CInt(ddlregion.SelectedValue), txtempid.Text.Trim, txtdoj.Text, txtdob.Text, CInt(ddllevel.SelectedValue),
                                         CInt(ddldesignation.SelectedValue), CInt(ddlusertype.SelectedValue), Session("UserId"), MainID, Session("Audlog_Id"), ddlservername.SelectedValue, txtport.Text, txtemailpassword.Text, chkSSL.Checked, txtdisplayname.Text)
                        lblemail.Text = ""
                        Response.Redirect("User.aspx")
                    End If
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Case DML_OPERATION.INSERT
                Try
                    'If txtdob.Text = "" Then
                    '    txtdob.Text = Date.Now.ToString("yyyy-MM-dd")
                    'End If
                    'If txtdoj.Text = "" Then
                    '    txtdoj.Text = Date.Now.ToString("yyyy-MM-dd")
                    'End If
                    Dim CheckCategory As String = MainBLL.CheckPageName(txtemail.Text.Trim, "EmailCheck")
                    If CheckCategory = "Already Exist" Then
                        lblemail.Visible = True
                        lblemail.Text = "Email Already Exist"
                    Else
                        UserBLL.Insert(txtfirstname.Text.Trim, txtlastname.Text.Trim, txtpass.Text.Trim, txtemail.Text.Trim, txtmob.Text.Trim,
                                        CInt(ddldept.SelectedValue), CInt(ddlemp.SelectedValue), txtaddr1.Text.Trim, txtaddr2.Text.Trim, txtcity.Text.Trim, CInt(ddlstate.SelectedValue), CInt(ddlcountry.SelectedValue),
                                        txtpincode.Text.Trim, CInt(ddlregion.SelectedValue), txtempid.Text.Trim, txtdoj.Text, txtdob.Text, CInt(ddllevel.SelectedValue),
                                         CInt(ddldesignation.SelectedValue), CInt(ddlusertype.SelectedValue), Session("UserId"), Session("Audlog_Id"), ddlservername.SelectedValue, txtport.Text, txtemailpassword.Text, chkSSL.Checked, txtdisplayname.Text)
                        lblemail.Text = ""
                        Response.Redirect("User.aspx")
                    End If
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ModifyUser", "INSERT", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        If MainID = 0 Then
            SaveUser(DML_OPERATION.INSERT)
        ElseIf MainID > 0 Then
            SaveUser(DML_OPERATION.UPDATE)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyUser", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "UserViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            ddllevel.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_LevelId").ToString())
            txtfirstname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
            txtlastname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_LastName").ToString())
            ddldept.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_DeptId").ToString())
            ddldesignation.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_DesignationId").ToString())
            txtempid.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_EmployeeId").ToString())
            hfemail.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_Email").ToString())
            txtemail.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_Email").ToString())
            txtmob.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_Mobile").ToString())
            txtdob.Text = DynamicparcelDataManipulation.DateFormat(drLogin("U_DOB").ToString())
            txtaddr1.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_Address1").ToString())
            txtaddr2.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_Address2").ToString())
            txtcity.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_City").ToString())
            ddlcountry.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_CountryId").ToString())
            ddlstate.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_StateId").ToString())
            txtpincode.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_Pincode").ToString())
            ddlusertype.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_TypeId").ToString())
            ddlregion.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_RegionId").ToString())
            txtdoj.Text = DynamicparcelDataManipulation.DateFormat(drLogin("U_DOJ").ToString())
            lblmodifieddate.Text = DynamicparcelDataManipulation.AlphaDateFormat(drLogin("U_ModifiedDate").ToString())
            lblmodifiedname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("ModfName").ToString())
            ddlemp.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ReportingTo").ToString())
            txtdisplayname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_DisplayName").ToString())
            ddlservername.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_EmailServerName").ToString())
            txtport.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ServerPort").ToString())
            txtemailpassword.Attributes.Add("Value", DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_EmailPassword").ToString()))
            If Not String.IsNullOrEmpty(drLogin("U_SSL").ToString()) Then
                chkSSL.Checked = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_SSL").ToString())
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyUser", "FillDetail", error1, Session("UserId"))
            ' ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub Filllevel()
        Try
            ddllevel.DataSource = MainBLL.Dropdown("LevelDropDown")
            ddllevel.DataTextField = "Level_LevelName"
            ddllevel.DataValueField = "Level_Id"
            ddllevel.DataBind()
            ddllevel.Items.Insert(0, New ListItem("Select Role", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyUser", "Filllevel", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillDepartment()
        Try
            ddldept.DataSource = MainBLL.Dropdown("DepartmentDropDown")
            ddldept.DataTextField = "Deprt_Name"
            ddldept.DataValueField = "Deprt_Id"
            ddldept.DataBind()
            'ddldept.Items.Insert(0, New ListItem("Select Department", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyUser", "FillDepartment", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub Filldesignation()
        Try
            ' ddldesignation.DataSource = MainBLL.Dropdown("DesignationDropDown")
            ddldesignation.DataSource = MainBLL.Dropdown("CrmDesignationDropDown")
            ddldesignation.DataTextField = "Desig_Name"
            ddldesignation.DataValueField = "Desig_Id"
            ddldesignation.DataBind()
            ddldesignation.Items.Insert(0, New ListItem("Select Designation", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyUser", "Filldesignation", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillCountry()
        Try
            Dim ds As DataSet = MainBLL.Dropdown("CountryDropDown")
            ddlcountry.DataSource = ds.Tables(0)
            ddlcountry.DataTextField = "CountryName"
            ddlcountry.DataValueField = "Id"
            ddlcountry.DataBind()
            ddlcountry.Items.Insert(0, New ListItem("Select Country", "0"))
            ddlcountry.SelectedValue = 105
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyUser", "FillCountry", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillState()
        Try
            Dim ds As DataSet = MainBLL.DropdownWithID("StateDropDown", ddlcountry.SelectedValue)
            ddlstate.DataSource = ds.Tables(0)
            ddlstate.DataTextField = "StateName"
            ddlstate.DataValueField = "Id"
            ddlstate.DataBind()
            ddlstate.Items.Insert(0, New ListItem("Select State", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyUser", "FillState", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillRegion()
        Try
            Dim ds As DataSet = MainBLL.Dropdown("RegionDropDown")
            ddlregion.DataSource = ds.Tables(0)
            ddlregion.DataTextField = "Region_Name"
            ddlregion.DataValueField = "Region_Id"
            ddlregion.DataBind()
            'ddlregion.Items.Insert(0, New ListItem("Select Region", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyUser", "FillRegion", error1, Session("UserId"))
            ' ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillUserType()
        Try
            Dim ds As DataSet = MainBLL.Dropdown("UserTypeDropDown")
            ddlusertype.DataSource = ds.Tables(0)
            ddlusertype.DataTextField = "UType_Name"
            ddlusertype.DataValueField = "UType_ID"
            ddlusertype.DataBind()
            'ddlusertype.Items.Insert(0, New ListItem("Select User Type", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyUser", "FillUserType", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillUserName()
        Try
            Dim ds As DataSet = MainBLL.Dropdown("UserDropDown")
            ddlemp.DataSource = ds.Tables(0)
            ddlemp.DataTextField = "U_FirstName"
            ddlemp.DataValueField = "U_ID"
            ddlemp.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyUser", "FillUserName", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub ddlcountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlcountry.SelectedIndexChanged
        Try
            FillState()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyUser", "ddlcountry_SelectedIndexChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub CheckPrivilage()
        Try
            If Session("UserRoleID").ToString = "1" Then
                ddllevel.Enabled = True
                ddlemp.Enabled = True
                divresetpassword.Visible = True
            Else
                ddllevel.Enabled = False
                ddlemp.Enabled = False
                divresetpassword.Visible = False
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyUser", "CheckPrivilage", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub btnresetpass_Click(sender As Object, e As EventArgs) Handles btnresetpass.Click
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If Not String.IsNullOrEmpty(txtnewpass.Text) Then
                If txtnewpass.Text.Trim = txtconfirm.Text.Trim Then
                    UserBLL.Changepass(txtnewpass.Text.Trim, MainID)
                    'Temporary stop email 06-10-2023 by Noor
                    'sendnewpass(txtemail.Text, txtnewpass.Text, txtfirstname.Text)
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Password reseted successfully!');", True)
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub


    Private Sub sendnewpass(ByVal email As String, ByVal newpass As String, ByVal name As String)
        Try
            Dim body As String = String.Empty
            Dim reader As StreamReader = New StreamReader(Server.MapPath("~/Email/Resetting_password.html"))
            body = reader.ReadToEnd
            body = body.Replace("#PASSWORD", newpass)
            body = body.Replace("#NAME", name)
            body = body.Replace("#LOGIN", email)
            SendMailBLL.SendMail(email, body, "Your password has been reset successfully")
            reader.Dispose()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
