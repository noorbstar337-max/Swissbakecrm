Imports DynamicparcelEnumerations

Partial Class ModifyLMSUser
    Inherits System.Web.UI.Page
    Dim MainID As Integer

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("LMSUserId") = Nothing Then
            TryCast(Me.Master, LMSMasterPage).MaintainSession()
            Try
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("LMS.aspx")
                End If
                DynamicparcelGridview.CheckPrivilageForModify(Session("LMSUserRoleID"), Button1, btnadd, "LMSUser.aspx")
                'CheckLMSPrivilege()
                CheckPrivilege()
                If Request.QueryString("chk") = "v" Then
                    txtfirstname.ReadOnly = True
                    txtlastname.ReadOnly = True
                    txtemail.ReadOnly = True
                    txtmob.ReadOnly = True
                    btnadd.Visible = False
                    Button1.Visible = False
                    ddllevel.CssClass = "form-control"
                    ddldept.CssClass = "form-control"
                    ddldesignation.CssClass = "form-control"
                    ddlemp.CssClass = "form-control"
                    ddllevel.Enabled = False
                    ddldept.Enabled = False
                    ddldesignation.Enabled = False
                    ddlemp.Enabled = False
                    divresetpassword.Visible = False
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyLMSUser", "Page_Init", error1, Session("LMSUserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        Else
            Try
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("LMS.aspx")
                End If
                DynamicparcelGridview.CheckLMSPrivilageForModify(Session("LMSUserRoleID"), Button1, btnadd, "LMSUser.aspx")
                'CheckLMSPrivilege()
                CheckPrivilege()
                If Request.QueryString("chk") = "v" Then
                    txtfirstname.ReadOnly = True
                    txtlastname.ReadOnly = True
                    txtemail.ReadOnly = True
                    txtmob.ReadOnly = True

                    btnadd.Visible = False
                    Button1.Visible = False

                    ddllevel.CssClass = "form-control"
                    ddldept.CssClass = "form-control"
                    ddldesignation.CssClass = "form-control"
                    ddlemp.CssClass = "form-control"
                    ddllevel.Enabled = False
                    ddldept.Enabled = False
                    ddldesignation.Enabled = False
                    ddlemp.Enabled = False
                    divresetpassword.Visible = False
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyLMSUser", "Page_Init", error1, Session("LMSUserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Try
                    MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                    FillDepartment()
                    Filldesignation()
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
                        FillDetail()
                    End If
                Catch ex As Exception
                    Response.Redirect("LMS.aspx")
                End Try
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyLMSUser", "Page_Load", error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
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
            ExecptionBLL.Insert("ModifyLMSUser", "btnadd_Click", error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub SaveUser(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try
                    Dim CheckPageName As String = ""
                    If Not txtemail.Text = hfemail.Value Then
                        CheckPageName = MainBLL.CheckPageName(txtemail.Text.Trim, "LMSEmailCheck")
                    End If
                    If CheckPageName = "Already Exist" Then
                        lblemail.Visible = True
                        lblemail.Text = "Email Already Exist"
                    Else
                        LMSBLL.UpdateLMSUser(txtfirstname.Text.Trim, txtlastname.Text.Trim, txtemail.Text.Trim, txtmob.Text.Trim, CInt(ddllevel.SelectedValue), CInt(ddldept.SelectedValue),
                                             CInt(ddlemp.SelectedValue), CInt(ddldesignation.SelectedValue), Session("LMSUserId"), MainID, Session("Audlog_Id"))
                        lblemail.Text = ""
                        Response.Redirect("LMSUser.aspx")
                    End If
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Case DML_OPERATION.INSERT
                Try
                    Dim CheckCategory As String = MainBLL.CheckPageName(txtemail.Text.Trim, "LMSEmailCheck")
                    If CheckCategory = "Already Exist" Then
                        lblemail.Visible = True
                        lblemail.Text = "Email Already Exist"
                    Else
                        LMSBLL.InsertLMSUser(txtfirstname.Text.Trim, txtlastname.Text.Trim, txtpass.Text.Trim, txtemail.Text.Trim, txtmob.Text.Trim, CInt(ddllevel.SelectedValue), CInt(ddldept.SelectedValue),
                                             CInt(ddlemp.SelectedValue), CInt(ddldesignation.SelectedValue), Session("LMSUserId"), Session("Audlog_Id"))
                        lblemail.Text = ""
                        Response.Redirect("LMSUser.aspx")
                    End If
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ModifyLMSUser", "INSERT", error1, Session("LMSUserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub
    Public Sub CheckPrivilege()
        Try
            If Session("LMSUserId").ToString = "1" Then
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
            ExecptionBLL.Insert("ModifyLMSUser", "CheckPrivilege", error1, Session("LMSUserId"))
            Throw ex
        End Try
    End Sub
    'Public Sub CheckLMSPrivilege()
    '    Try
    '        'DynamicparcelGridview.CheckPrivilagewithNoView(9, 8, 7, GridView1, Session("LMSUserRoleID"), SearchControl.Uhfadd, "LMSUser.aspx")
    '        DynamicparcelGridview.CheckLMSPrivilegewithNoView(9, 8, 7, GridView1, Session("LMSUserRoleID"), SearchControl.Uhfadd, "LMSUser.aspx")
    '        If Not SearchControl.Uhfadd.Visible Then
    '            SearchControl.ULkadd.Visible = False
    '        End If
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert("LMSUser", "CheckPrivilage", error1, Session("LMSUserId"))
    '        'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '        Throw ex
    '    End Try
    'End Sub
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
            ExecptionBLL.Insert("ModifyLMSUser", "FillDepartment", error1, Session("LMSUserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Public Sub Filldesignation()
        Try
            ddldesignation.DataSource = MainBLL.Dropdown("DesignationDropDown")
            ddldesignation.DataTextField = "Desig_Name"
            ddldesignation.DataValueField = "Desig_Id"
            ddldesignation.DataBind()
            'ddldesignation.Items.Insert(0, New ListItem("Select Designation", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyLMSUser", "Filldesignation", error1, Session("LMSUserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Public Sub FillUserName()
        Try
            Dim ds As DataSet = MainBLL.Dropdown("LMSUserDropDown")
            ddlemp.DataSource = ds.Tables(0)
            ddlemp.DataTextField = "U_FirstName"
            ddlemp.DataValueField = "U_ID"
            ddlemp.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyLMSUser", "FillUserName", error1, Session("LMSUserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Public Sub FillDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "LMSUserViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            ddllevel.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_LevelId").ToString())
            txtfirstname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
            txtlastname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_LastName").ToString())
            ddldept.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_DeptId").ToString())
            ddldesignation.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_DesignationId").ToString())
            hfemail.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_Email").ToString())
            txtemail.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_Email").ToString())
            txtmob.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_Mobile").ToString())
            lblmodifieddate.Text = DynamicparcelDataManipulation.AlphaDateFormat(drLogin("U_ModifiedDate").ToString())
            lblmodifiedname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("ModfName").ToString())
            ddlemp.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ReportingTo").ToString())
           
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyLMSUser", "FillDetail", error1, Session("LMSUserId"))
            ' ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub btnresetpass_Click(sender As Object, e As EventArgs) Handles btnresetpass.Click
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If Not String.IsNullOrEmpty(txtnewpass.Text) Then
                If txtnewpass.Text.Trim = txtconfirm.Text.Trim Then
                    LMSBLL.ChangeLMSPass(txtnewpass.Text.Trim, MainID)
                    'sendnewpass(txtemail.Text, txtnewpass.Text, txtfirstname.Text)
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Password reset successfully!');", True)
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
