
Imports DynamicparcelEnumerations
Imports System.Diagnostics

Partial Class LMSMasterPage
    Inherits System.Web.UI.MasterPage

        Dim path3 As String
        Dim temp As String
        Dim blogcookie As HttpCookie
        Dim strItem As New List(Of String)

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim host As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) ' HttpContext.Current.Request.Url.Host

        If host = "http://mcrm.swissbake.ch" Then
            Response.Redirect("login.aspx")
            'Response.Redirect("index1.aspx")
            'Else
            '    Response.Redirect("index.aspx")
        ElseIf host = "http://crm.swissbake.ch" Then
            Response.Redirect("login.aspx")


        End If

        Dim javascript As New HtmlGenericControl("script")
        javascript.Attributes("type") = "text/javascript"
        javascript.Attributes("src") = "js/plugins.js"
        Page.Header.Controls.Add(javascript)
        'Dim processes As Process() = Process.GetProcessesByName("AcroRd32.exe")
        'For Each process__1 As Process In processes


        '    process__1.Kill()
        'Next


        ''FindAndKillProcess("AcroRd32.exe")

        'Dim a As String = Session("deletefile")
        'If Session("deletefile") = "1" Or Session("deletefile") = Nothing Then
        'Else
        '    System.IO.File.Delete(a)
        '    Session("deletefile") = "1"
        'End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Page.Header.DataBind()
            If Session("LMSUserId") = Nothing Then
                blogcookie = Request.Cookies.Get("blogcookievalue")
                If blogcookie.Value = "None" Then
                    Response.Redirect("LMSLogin.aspx")
                Else
                    Dim strArr() As String
                    strArr = blogcookie.Value.Split(",")
                    For i As Integer = 0 To strArr.Count - 1
                        If i = 0 Then
                            Session("LMSUserId") = strArr(i)
                            temp = strArr(i)
                        ElseIf i = 1 Then
                            Session("LMSDUserId") = strArr(i)
                            temp = strArr(i)
                        ElseIf i = 2 Then
                            Session("LMSUserName") = strArr(i)
                            temp = strArr(i)
                        ElseIf i = 3 Then
                            Session("LMSUserRoleID") = strArr(i)
                            temp = strArr(i)
                        ElseIf i = 4 Then
                            Session("LMSUName") = strArr(i)
                            temp = strArr(i)
                        ElseIf i = 5 Then
                            Session("Audlog_Id") = strArr(i)
                            temp = strArr(i)
                        End If
                    Next
                    'Response.Redirect(Request.Url.AbsoluteUri)
                    'Session("LMSUserId") = blogcookie.Value
                End If
            End If
            'Session("LMSUserId") = 1
            'Session("LMSDUserId") = 1
            'Session("LMSUserName") = "tahir@swissbake.in"
            'Session("LMSUserRoleID") = 1
            'Session("LMSUName") = "Tahir Shaikh"
            'Session("Audlog_Id") = "671"
            If Not Session("LMSUserRoleID") = "1" Then
                UserMenu1.Visible = False
                UserMenu2.Visible = False
                PrivilegeMenu1.Visible = False
                PrivilegeMenu2.Visible = False
                ReportMenu1.Visible = False
                ReportMenu2.Visible = False
                FormulationMenu1.Visible = True
                FormulationMenu2.Visible = True
                RawMatMenu1.Visible = False
                RawMatMenu2.Visible = False
                'RecipeMenu1.Visible = True
                'RecipeMenu2.Visible = True
                TrialMenu1.Visible = True
                TrialMenu2.Visible = True
            Else
                UserMenu1.Visible = True
                UserMenu2.Visible = True
                PrivilegeMenu1.Visible = True
                PrivilegeMenu2.Visible = True
                ReportMenu1.Visible = True
                ReportMenu2.Visible = True
                FormulationMenu1.Visible = True
                FormulationMenu2.Visible = True
                RawMatMenu1.Visible = True
                RawMatMenu2.Visible = True
                'RecipeMenu1.Visible = True
                'RecipeMenu2.Visible = True
                TrialMenu1.Visible = True
                TrialMenu2.Visible = True
            End If
            'If Session("LMSUserRoleID") = "2" Then
            '    UserMenu1.Visible = False
            '    UserMenu2.Visible = False
            '    PrivilegeMenu1.Visible = False
            '    PrivilegeMenu2.Visible = False
            '    FormulationMenu1.Visible = True
            '    FormulationMenu2.Visible = True
            '    'RecipeMenu1.Visible = True
            '    'RecipeMenu2.Visible = True
            '    TrialMenu1.Visible = True
            '    TrialMenu2.Visible = True
            'ElseIf Session("LMSUserRoleID") = "3" Then
            '    UserMenu1.Visible = False
            '    UserMenu2.Visible = False
            '    PrivilegeMenu1.Visible = False
            '    PrivilegeMenu2.Visible = False
            '    FormulationMenu1.Visible = True
            '    FormulationMenu2.Visible = True
            '    'RecipeMenu1.Visible = True
            '    'RecipeMenu2.Visible = True
            '    TrialMenu1.Visible = True
            '    TrialMenu2.Visible = True
            'ElseIf Session("LMSUserRoleID") = "4" Then
            '    UserMenu1.Visible = False
            '    UserMenu2.Visible = False
            '    PrivilegeMenu1.Visible = False
            '    PrivilegeMenu2.Visible = False
            '    'FormulationMenu1.Visible = False
            '    'FormulationMenu2.Visible = False
            '    'RecipeMenu1.Visible = False
            '    'RecipeMenu2.Visible = False
            '    'TrialMenu1.Visible = True
            '    'TrialMenu2.Visible = True
            'End If
            
            Dim dt As DataSet = LMSPrivilegeBLL.CheckLMSPrivilegeMaster(Session("LMSUserRoleID"))
            Dim dtprivilage As New DataTable
            dtprivilage = dt.Tables(0)
            If dtprivilage.Rows.Count > 0 Then
                For a = 0 To dtprivilage.Rows.Count - 1
                    Dim MenuId As Integer = DynamicparcelDataManipulation.FixNullFromDB(dtprivilage.Rows(a)("Menu_Id"))
                    ' MenuId privilege page menu id
                    '   MenuId=2 is for Formulation
                    
                    If MenuId = 2 Or MenuId = 3 Then
                        If (dtprivilage.Rows(a)("Prvg_RAdd").ToString()) = True Then
                            aVModFormulation.Visible = True
                            aHModFormulation.Visible = True
                        Else
                            'aVModFormulation.Visible = False
                            'aHModFormulation.Visible = False
                        End If
                        If (dtprivilage.Rows(a)("Prvg_Rview").ToString()) = True Or (dtprivilage.Rows(a)("Prvg_RUpdate").ToString()) = True Then
                            aVFormulation.Visible = True
                            aHFormulation.Visible = True
                        Else
                            'aVFormulation.Visible = False
                            'aHFormulation.Visible = False
                        End If
                        
                    End If
                    '   MenuId=3 is for Recipe
                    ''If MenuId = 3 Then
                    ''    ''If (dtprivilage.Rows(a)("Prvg_RAdd").ToString()) = True Then
                    ''    ''    aVModRecipe.Visible = True
                    ''    ''    aHModRecipe.Visible = True
                    ''    ''Else
                    ''    ''    aVModRecipe.Visible = False
                    ''    ''    aHModRecipe.Visible = False
                    ''    ''End If
                    ''    ''If (dtprivilage.Rows(a)("Prvg_Rview").ToString()) = True Or (dtprivilage.Rows(a)("Prvg_RUpdate").ToString()) = True Then
                    ''    ''    aVRecipe.Visible = True
                    ''    ''    aHRecipe.Visible = True
                    ''    ''Else
                    ''    ''    aVRecipe.Visible = False
                    ''    ''    aHRecipe.Visible = False
                    ''    ''End If
                    ''    ''If aVModRecipe.Visible <> True And aVRecipe.Visible <> True Then
                    ''    ''    'RecipeMenu1.Visible = False
                    ''    ''    'RecipeMenu2.Visible = False
                    ''    ''Else
                    ''    ''    'RecipeMenu1.Visible = True
                    ''    ''    'RecipeMenu2.Visible = True
                    ''    ''End If
                    ''End If
                    '   MenuId=4 is for Trial
                    If MenuId = 4 Then
                        If (dtprivilage.Rows(a)("Prvg_RAdd").ToString()) = True Then
                            aVModTrial.Visible = True
                            aHModTrial.Visible = True
                        Else
                            aVModTrial.Visible = False
                            aHModTrial.Visible = False
                        End If
                        If (dtprivilage.Rows(a)("Prvg_Rview").ToString()) = True Or (dtprivilage.Rows(a)("Prvg_RUpdate").ToString()) = True Then
                            aVTrial.Visible = True
                            aHTrial.Visible = True
                        Else
                            aVTrial.Visible = False
                            aHTrial.Visible = False
                        End If
                        If aVModTrial.Visible <> True And aVTrial.Visible <> True Then
                            TrialMenu1.Visible = False
                            TrialMenu2.Visible = False
                        Else
                            TrialMenu1.Visible = True
                            TrialMenu2.Visible = True
                        End If
                    End If
                Next
                If aVModFormulation.Visible <> True And aVFormulation.Visible <> True Then
                    FormulationMenu1.Visible = False
                    FormulationMenu2.Visible = False
                Else
                    FormulationMenu1.Visible = True
                    FormulationMenu2.Visible = True
                End If
                'aVModFormulation.Visible = True
                'aVModFormulation.Visible = False
                'aVModFormulation.Visible = True
                'aVModFormulation.Visible = False
                'aVModFormulation.Visible = True
            Else
                UserMenu1.Visible = False
                UserMenu2.Visible = False
                PrivilegeMenu1.Visible = False
                PrivilegeMenu2.Visible = False
                ReportMenu1.Visible = False
                ReportMenu2.Visible = False
                FormulationMenu1.Visible = False
                FormulationMenu2.Visible = False
                'RecipeMenu1.Visible = False
                'RecipeMenu2.Visible = False
                TrialMenu1.Visible = False
                TrialMenu2.Visible = False
            End If
            'If Session("LMSUserRoleID") = "3" Then

            '    horizontal_menu_collapse1.Visible = True
            '    horizontal_menu_collapse.Visible = False
            '    sidebarResponsive.Visible = False
            '    sidebarResponsive1.Visible = True
            '    sidebarUser1.Visible = True
            '    sidebarUser.Visible = False
            '    lidashboard.ViewStateMode = False
            '    adashboard.Visible = False
            '    lidivider.Visible = False
            '    licalendar.Visible = False
            '    lialarm.Visible = False
            '    limonthlyrept.Visible = False
            'Else
            '    horizontal_menu_collapse1.Visible = False
            '    horizontal_menu_collapse.Visible = True
            '    sidebarResponsive.Visible = True
            '    sidebarResponsive1.Visible = False
            '    sidebarUser1.Visible = False
            '    sidebarUser.Visible = True
            'End If
            If Not IsPostBack Then
                Try
                    FillDetail()
                    FillColor()
                    FillProfile()
                Catch ex As Exception
                End Try
            End If
            If ltremindercount.Text = 0 Then
                'reminderlnk.Attributes.Remove("class")
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "Page_Load", error1, Session("LMSUserId"))
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
        End Try
    End Sub

        Public Sub MaintainSession()
            blogcookie = Request.Cookies.Get("blogcookievalue")
            If blogcookie.Value = "None" Then
            Response.Redirect("LMSLogin.aspx")
            Else
                Dim strArr() As String
                strArr = blogcookie.Value.Split(",")
                For i As Integer = 0 To strArr.Count - 1
                    If i = 0 Then
                    Session("LMSUserId") = strArr(i)
                        temp = strArr(i)
                    ElseIf i = 1 Then
                    Session("LMSDUserId") = strArr(i)
                        temp = strArr(i)
                    ElseIf i = 2 Then
                    Session("LMSUserName") = strArr(i)
                        temp = strArr(i)
                    ElseIf i = 3 Then
                    Session("LMSUserRoleID") = strArr(i)
                        temp = strArr(i)
                    ElseIf i = 4 Then
                    Session("LMSUName") = strArr(i)
                        temp = strArr(i)
                    ElseIf i = 5 Then
                        Session("Audlog_Id") = strArr(i)
                        temp = strArr(i)
                    End If
                Next
            End If
        End Sub

        Public Sub FillColor()
            Try
            Dim sb As String = Convert.ToString(MainBLL.ThemeViewByID(Session("LMSUserId"), "CheckThemeViewByID"))
                If sb = "" Then
                    themepath.HRef = "default"
                    ' themepath.HRef = "css/themes/darkblue.css"
                Else
                    themepath.HRef = sb
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "FillColor", error1, Session("LMSUserId"))
                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
            End Try
        End Sub

        Public Sub UserImageUpload()
            Try
                If FileUploadControl.PostedFile.FileName = "" Then
                    path3 = hfimgpath.Value
                Else
                    Dim MyDate As DateTime = DateTime.Now
                    Dim filename As String = Path.GetFileName(MyDate.ToString("ddMMyyhhmmss") + "-" + FileUploadControl.PostedFile.FileName)
                    path3 = "img/ProfileImage/" + filename

                    Dim path2 As String = Server.MapPath("~/img/ProfileImage/" + filename)
                    FileUploadControl.PostedFile.SaveAs(path2)
                    DynamicparcelImages.CompressImage(path2, 25)
                End If

            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "UserImageUpload", error1, Session("LMSUserId"))
                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
            End Try
        End Sub

        Protected Sub btnprofilesave_Click(sender As Object, e As EventArgs) Handles btnprofilesave.Click
            Try
                UserImageUpload()
                If path3 = "" Then
                    path3 = "img/placeholders/avatars/avatar2.jpg"
                UserBLL.UpdateImage(lblfname.Text, lbllname.Text, lblmobile.Text, lbldate.Text, path3, Session("LMSUserId"))
                Else
                UserBLL.UpdateImage(lblfname.Text, lbllname.Text, lblmobile.Text, lbldate.Text, path3, Session("LMSUserId"))
                End If


                Response.Redirect(Request.RawUrl)
                FillProfile()
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "btnprofilesave_Click", error1, Session("LMSUserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End Sub

        Public Sub FillProfile()
            Try
            Dim dt As DataSet = MainBLL.ViewByID(Session("LMSUserId"), "UserProfileViewByID")
                Dim dtUser As New DataTable
                dtUser = dt.Tables(0)
                If dtUser.Rows.Count > 0 Then
                    Dim drLogin As DataRow
                    drLogin = dtUser.Rows(0)
                    lblfname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                    txtfirstname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                    lbllname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_LastName").ToString())
                    txtlastname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_LastName").ToString())
                    lbldate.Text = DynamicparcelDataManipulation.DateFormat(drLogin("U_DOB").ToString())
                    txtdate.Text = DynamicparcelDataManipulation.DateFormat(drLogin("U_DOB").ToString())
                    lblmobile.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_Mobile").ToString())
                    hfimgpath.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ProfileImage").ToString())
                    txtmobile.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_Mobile").ToString())
                    imgprofile.ImageUrl = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ProfileImage").ToString())
                    imgprofileresponsive.ImageUrl = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ProfileImage").ToString())
                ' imgprofileresponsive1.ImageUrl = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ProfileImage").ToString())
                    Image1.ImageUrl = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ProfileImage").ToString())
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "FillProfile", error1, Session("LMSUserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End Sub

        Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
            Try
            MainBLL.UpdateTheme(Session("LMSUserId"), "css/themes/night.css", "UpdateTheme")
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "LinkButton1_Click", error1, Session("LMSUserId"))
                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
            End Try
        End Sub

        Protected Sub LinkButton2_Click(sender As Object, e As EventArgs) Handles LinkButton2.Click
            Try
            MainBLL.UpdateTheme(Session("LMSUserId"), "css/themes/amethyst.css", "UpdateTheme")
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "LinkButton2_Click", error1, Session("LMSUserId"))
                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
            End Try
        End Sub

        Protected Sub LinkButton3_Click(sender As Object, e As EventArgs) Handles LinkButton3.Click
            Try
            MainBLL.UpdateTheme(Session("LMSUserId"), "css/themes/modern.css", "UpdateTheme")
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "LinkButton3_Click", error1, Session("LMSUserId"))
                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
            End Try
        End Sub

        Protected Sub LinkButton4_Click(sender As Object, e As EventArgs) Handles LinkButton4.Click
            Try
            MainBLL.UpdateTheme(Session("LMSUserId"), "css/themes/autumn.css", "UpdateTheme")
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "LinkButton4_Click", error1, Session("LMSUserId"))
                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
            End Try
        End Sub

        Protected Sub LinkButton5_Click(sender As Object, e As EventArgs) Handles LinkButton5.Click
            Try
            MainBLL.UpdateTheme(Session("LMSUserId"), "css/themes/flatie.css", "UpdateTheme")
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "LinkButton5_Click", error1, Session("LMSUserId"))
                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
            End Try
        End Sub

        Protected Sub LinkButton6_Click(sender As Object, e As EventArgs) Handles LinkButton6.Click
            Try
            MainBLL.UpdateTheme(Session("LMSUserId"), "css/themes/spring.css", "UpdateTheme")
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "LinkButton6_Click", error1, Session("LMSUserId"))
                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
            End Try
        End Sub

        Protected Sub LinkButton7_Click(sender As Object, e As EventArgs) Handles LinkButton7.Click
            Try
            MainBLL.UpdateTheme(Session("LMSUserId"), "css/themes/fancy.css", "UpdateTheme")
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "LinkButton7_Click", error1, Session("LMSUserId"))
                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
            End Try
        End Sub

        Protected Sub LinkButton8_Click(sender As Object, e As EventArgs) Handles LinkButton8.Click
            Try
            MainBLL.UpdateTheme(Session("LMSUserId"), "css/themes/fire.css", "UpdateTheme")
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "LinkButton8_Click", error1, Session("LMSUserId"))
                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
            End Try
        End Sub

        Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
            Try
                Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "btnsave_Click", error1, Session("LMSUserId"))
                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
            End Try
        End Sub

        Public Sub FillDetail()
            Try
                Dim CompanyId As Integer = 1
                Dim dt As DataSet = MainBLL.ViewByID(CompanyId, "CrmCompanyViewByID")
                Dim dtFaq As New DataTable
                dtFaq = dt.Tables(0)
                Dim drFaqRow As DataRow
                drFaqRow = dtFaq.Rows(0)
                lblcompanyname.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_Name").ToString())
                lblcompany.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_Name").ToString())
            rpreminder.DataSource = ActivityBLL.ActivityReminder(Session("LMSUserId"))
                rpreminder.DataBind()
                ltremindercount.Text = rpreminder.Items.Count
            'ltrmcount.Text = ltremindercount.Text
                If rpreminder.Items.Count = 0 Then
                '  reminderlnk.Attributes.Remove("class")
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "FillDetail", error1, Session("LMSUserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End Sub

        Protected Sub rpreminder_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rpreminder.ItemCommand
            If e.CommandName = "dellink" Then
                Try
                    Dim index As Integer = Convert.ToInt32(e.Item.ItemIndex)
                    Dim ActivityID As HiddenField = DirectCast(e.Item.FindControl("ActivityID"), HiddenField)
                    ActivityBLL.ClosedReminder(ActivityID.Value)
                    FillDetail()
                Catch ex As Exception

                End Try
            End If
        End Sub

        Protected Sub rpreminder_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rpreminder.ItemDataBound
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Try
                    Dim hfactivitytype As HiddenField = CType(e.Item.FindControl("hfactivitytype"), HiddenField)
                    Dim hyactivity As HyperLink = CType(e.Item.FindControl("hyactivity"), HyperLink)
                    Dim ActivityID As HiddenField = CType(e.Item.FindControl("ActivityID"), HiddenField)
                    Select Case hfactivitytype.Value
                        Case "Task"
                            hyactivity.NavigateUrl = Page.ResolveUrl("~/ActivityTask.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID.Value)))
                            Exit Select
                        Case "Event"
                            hyactivity.NavigateUrl = Page.ResolveUrl("~/ActivityEvent.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID.Value)))
                            Exit Select
                        Case "Call"
                            hyactivity.NavigateUrl = Page.ResolveUrl("~/ActivityCall.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID.Value)))
                            Exit Select
                    End Select
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("MasterPage", "rpreminder_ItemDataBound", error1, Session("LMSUserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            End If
        End Sub

        ' Public Sub FillGrid()
        '    Try
    '        Dim dt As DataSet = MainBLL.ViewByID(Session("LMSUserId"), "UserProfileViewByID")
        '        GridView1.DataSource = dt
        '        GridView1.DataBind()
        '    Catch ex As Exception
        '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
        '        error1 = error1.Replace(Chr(39), "")
        '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        '    End Try
        'End Sub

        'Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        '    Dim center_id As Integer
        '    If (e.CommandName = "firstname") Then
        '        Dim index As Integer = Convert.ToInt32(e.CommandArgument)

        '        center_id = GridView1.DataKeys(index).Value
        '    End If
        'End Sub

        Protected Sub lbtnFirst_Click(sender As Object, e As EventArgs) Handles lbtnFirst.Click
            Try
                txtfirstname.Visible = True
                lblfname.Visible = False
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "lbtnFirst_Click", error1, Session("LMSUserId"))
                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
            End Try
        End Sub

        Protected Sub txtfirstname_TextChanged(sender As Object, e As EventArgs)
            Try
            UserBLL.UpdateImage(txtfirstname.Text, lbllname.Text, lblmobile.Text, lbldate.Text, HiddenField1.Value, Session("LMSUserId"))
                txtfirstname.Visible = False
                lblfname.Visible = True
                FillProfile()
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "txtfirstname_TextChanged", error1, Session("LMSUserId"))
                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
            End Try
        End Sub

        Protected Sub txtlastname_TextChanged(sender As Object, e As EventArgs)
            Try
            UserBLL.UpdateImage(lblfname.Text, txtlastname.Text, lblmobile.Text, lbldate.Text, HiddenField1.Value, Session("LMSUserId"))
                txtlastname.Visible = False
                lbllname.Visible = True
                FillProfile()
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "txtlastname_TextChanged", error1, Session("LMSUserId"))
                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
            End Try
        End Sub

        Protected Sub txtmobile_TextChanged(sender As Object, e As EventArgs)
            Try
            UserBLL.UpdateImage(lblfname.Text, lbllname.Text, txtmobile.Text, lbldate.Text, HiddenField1.Value, Session("LMSUserId"))
                txtmobile.Visible = False
                lblmobile.Visible = True
                FillProfile()
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "txtmobile_TextChanged", error1, Session("LMSUserId"))
                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
            End Try
        End Sub

        Protected Sub txtdate_TextChanged(sender As Object, e As EventArgs)
            Try
            UserBLL.UpdateImage(lblfname.Text, lbllname.Text, lblmobile.Text, txtdate.Text, HiddenField1.Value, Session("LMSUserId"))
                txtdate.Visible = False
                lbldate.Visible = True
                FillProfile()
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "txtdate_TextChanged", error1, Session("LMSUserId"))
                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
            End Try
        End Sub

        Protected Sub lbtnLast_Click(sender As Object, e As EventArgs) Handles lbtnLast.Click
            Try
                txtlastname.Visible = True
                lbllname.Visible = False
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "lbtnLast_Click", error1, Session("LMSUserId"))
                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
            End Try
        End Sub

        Protected Sub lbtnMobile_Click(sender As Object, e As EventArgs) Handles lbtnMobile.Click
            Try
                txtmobile.Visible = True
                lblmobile.Visible = False
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "lbtnMobile_Click", error1, Session("LMSUserId"))
                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
            End Try
        End Sub

        Protected Sub lbtndate_Click(sender As Object, e As EventArgs) Handles lbtndate.Click
            Try
                txtdate.Visible = True
                lbldate.Visible = False
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "lbtndate_Click", error1, Session("LMSUserId"))
                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
            End Try
        End Sub

    'Protected Sub lnkaddUser_Click(sender As Object, e As EventArgs) Handles lnkaddUser.Click
    '    Response.Redirect("ModifyLMSUser.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")
    'End Sub

    'Protected Sub lnkaddRecipe_Click(sender As Object, e As EventArgs) Handles lnkaddRecipe.ServerClick
    '    Response.Redirect("ModifyRecipe.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")
    'End Sub

    'Protected Sub lnkAddTrial_Click(sender As Object, e As EventArgs) Handles lnkAddTrial.Click
    '    Response.Redirect("ModifyTrial.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")
    'End Sub


    Protected Sub aVModFormulation_ServerClick(sender As Object, e As EventArgs) Handles aVModFormulation.ServerClick
        Response.Redirect("ModifyTrials.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")
        'Response.Redirect("ModifyFormulation.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")
    End Sub

    Protected Sub aVModRecipe_ServerClick(sender As Object, e As EventArgs) Handles aVModRecipe.ServerClick
        Response.Redirect("ModifyRecipe.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")
    End Sub

    Protected Sub aVModTrial_ServerClick(sender As Object, e As EventArgs) Handles aVModTrial.ServerClick
        Response.Redirect("ModifyFeedback.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")
    End Sub

    Protected Sub aHModFormulation_ServerClick(sender As Object, e As EventArgs) Handles aHModFormulation.ServerClick
        Response.Redirect("ModifyTrials.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")
        'Dim Url As String = "ModifyTrials.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y"
        'ScriptManager.RegisterStartupScript(aHModFormulation, Me.GetType(), "OpenWindow", "window.open('" + Url + "','_blank');", True)

        'Response.Redirect("ModifyFormulation.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")

    End Sub

    Protected Sub aHModRecipe_ServerClick(sender As Object, e As EventArgs) Handles aHModRecipe.ServerClick
        Response.Redirect("ModifyRecipe.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")

    End Sub

    Protected Sub aHModTrial_ServerClick(sender As Object, e As EventArgs) Handles aHModTrial.ServerClick
        Response.Redirect("ModifyFeedback.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")

    End Sub
End Class


