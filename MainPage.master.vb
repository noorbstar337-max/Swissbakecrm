Imports DynamicparcelEnumerations
Imports System.Diagnostics

Partial Class MainPage
    Inherits System.Web.UI.MasterPage
    Dim path3 As String
    Dim temp As String
    Dim blogcookie As HttpCookie
    Dim strItem As New List(Of String)

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim host As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) ' HttpContext.Current.Request.Url.Host

        If host = "http://mcrm.swissbake.ch" Then
            Response.Redirect("index1.aspx")
            'Else
            '    Response.Redirect("index.aspx")
        End If
        If host = "http://lms.swissbake.ch" Then
            Response.Redirect("lmsdashboard.aspx")
            'Else
            '    Response.Redirect("index.aspx")
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

    'Public Function FindAndKillProcess(name As String) As Boolean
    '    'here we're going to get a list of all running processes on
    '    'the computer
    '    For Each clsProcess As Process In Process.GetProcesses()
    '        'now we're going to see if any of the running processes
    '        'match the currently running processes by using the StartsWith Method,
    '        'this prevents us from incluing the .EXE for the process we're looking for.
    '        '. Be sure to not
    '        'add the .exe to the name you provide, i.e: NOTEPAD,
    '        'not NOTEPAD.EXE or false is always returned even if
    '        'notepad is running
    '        If clsProcess.ProcessName.StartsWith(name) Then
    '            'since we found the proccess we now need to use the
    '            'Kill Method to kill the process. Remember, if you have
    '            'the process running more than once, say IE open 4
    '            'times the loop thr way it is now will close all 4,
    '            'if you want it to just close the first one it finds
    '            'then add a return; after the Kill
    '            clsProcess.Kill()
    '            'process killed, return true
    '            Return True
    '        End If
    '    Next
    '    'process not found, return false
    '    Return False
    'End Function

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Try
                If Not IsPostBack Then
                    Try

                        ' Default: hide Discount menu
                        liDiscount.Visible = False

                        ' Safety check
                        If Session("UserRoleID") Is Nothing OrElse
               Session("UserLevelID") Is Nothing OrElse
               Session("UserName") Is Nothing Then

                        End If

                        '  CheckPrivilage()

                        '  Check if session contains UserRoleID
                        If Session("UserRoleID") Is Nothing OrElse Session("UserRoleID").ToString().Trim() = "" Then
                            ' Try to get it from cookie
                            Dim blogcookie As HttpCookie = Request.Cookies.Get("blogcookievalue")
                            If blogcookie IsNot Nothing AndAlso blogcookie.Value <> "None" Then
                                Dim strArr As String() = blogcookie.Value.Split(",")
                                If strArr.Length > 3 Then
                                    Session("UserRoleID") = strArr(3).Trim()
                                End If
                            End If
                        End If
                        '  Output current role for checking
                        Dim roleId As String = Convert.ToString(Session("UserRoleID")).Trim()
                        Dim levelId As String = Session("UserRoleID").ToString().Trim() '  FIXED
                        Dim userName As String = Session("UserName").ToString().Trim().ToLower()

                        ' Allowed users (Managers + existing users)
                        Dim isAllowedUser As Boolean =
                            (userName = "irfan@bstarsw.com" OrElse
                             userName = "archit@swissbake.in" OrElse
                             userName = "sameed@swissbake.org" OrElse
                             userName = "mustansir.sales@swissbake.ch" OrElse
                             userName = "shahab@swissbake.co.in" OrElse
                             userName = "sayyed.nadeem@swissbake.co.in" OrElse
                             userName = "azhar@swissbake.co.in")

                        ' FINAL LOGIC
                        If isAllowedUser Then
                            liDiscount.Visible = True
                        ElseIf roleId = "2" OrElse roleId = "3" OrElse roleId = "4" OrElse roleId = "5" OrElse roleId = "6" Then
                            liDiscount.Visible = False
                        Else
                            liDiscount.Visible = True
                        End If


                        ' Technical Chef and Pre Sales
                        If roleId = "9" Then

                            ' Role 9: Hide ALL menus
                            liAddAccount.Visible = False
                            liAddLead.Visible = False
                            liAddProspect.Visible = False
                            liDiscount.Visible = False
                            liQuotation.Visible = False
                            liOrder.Visible = False
                            li1.Visible = False
                            limonthlyrept.Visible = False
                            liMis.Visible = False
                            FreeSample.Visible = False
                            liAccounts.Visible = True
                            liLead.Visible = True
                            liProspect.Visible = True
                            liAddressbook.Visible = False
                        ElseIf roleId = "10" Then
                            liAddAccount.Visible = False
                            limonthlyrept.Visible = False
                            liDiscount.Visible = False
                            liMis.Visible = False
                            FreeSample.Visible = False
                            ' Role 10: Hide ONLY Accounts
                            liAccounts.Visible = True
                            liAddressbook.Visible = True
                            liOrder.Visible = True
                            liAddProspect.Visible = True
                        Else

                            liAddressbook.Visible = False

                        End If

                    Catch ex As Exception
                        ' You can log this exception
                    End Try

                End If
            Catch ex As Exception
                ' You can log this exception
            End Try
            'Privilege Start
            If Not Session("dtPrivilege") Is Nothing Then

                If Not Session("UserRoleID") = "1" Then
                    If Request.Url.AbsolutePath.Replace("/Admin/", "").Replace("/admin/", "") = "/ChangePassword.aspx" Or Request.Url.AbsolutePath.Replace("/Admin/", "").Replace("/admin/", "") = "/personaldocument.aspx" Then

                    Else

                        If Request.Url.AbsolutePath <> "" Then
                            Dim strArr() As String
                            Dim TemStr As String = ""
                            Dim dtPrivi As New DataTable
                            dtPrivi = Session("dtPrivilege")
                            If Not Request.Url.AbsolutePath.Contains("Modify") And Not Request.Url.AbsolutePath.Contains("View") And Not Request.Url.AbsolutePath.Contains("Edit") Then


                                Dim rows() As DataRow = dtPrivi.Select("Menu_URL = '" + Request.Url.AbsolutePath.Replace("/Admin/", "").Replace("/admin/", "").Replace("/", "") + "'")
                                'Dim rows2() As DataRow = dtPrivi.Select("Menu_URL = '" + Request.Url.AbsolutePath.Replace("/Admin/", "").Replace("/admin/", "").Replace("/", "") + "'")
                                'Dim rows2() As DataRow = dtPrivi.Select("Menu_ModifyURL = '" + Request.Url.AbsolutePath.Replace("/Admin/", "").Replace("/admin/", "") + "'")
                                If Request.Url.AbsolutePath.ToLower().Contains("Addressbook.aspx") Then
                                    Response.Write("Role ID: " & Session("UserRoleID").ToString())
                                    Response.Write("<br>Privilege Rows: " & rows.Length)

                                    If rows.Length > 0 Then
                                        Response.Write("<br>Permission Value: " & rows(0)("Val").ToString())
                                    End If
                                End If
                                If rows.Count > 0 Then                              '/Checking details page privilege here/

                                    TemStr = rows(0).Item("Val").ToString()
                                    strArr = TemStr.Split(",")
                                    If Not Request.QueryString("ID") = Nothing Then
                                        Dim Mainid As Integer = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("ID")))
                                        If Mainid = 0 Then
                                            ''btnemail.Visible = True
                                            ''btnExport.Visible = True
                                            If strArr(0) = "1" Then
                                            Else
                                                Response.Redirect("404.aspx")
                                            End If
                                        Else
                                            If strArr(1) = "1" Or strArr(2) = "1" Or strArr(3) = "1" Then
                                            Else
                                                Response.Redirect("404.aspx")
                                            End If
                                        End If
                                    Else
                                        If (strArr.Length > 3) Then
                                            If strArr(0) = "1" Or strArr(1) = "1" Or strArr(2) = "1" Or strArr(3) = "1" Then
                                            Else
                                                Response.Redirect("404.aspx")
                                            End If
                                        End If
                                    End If


                                    ' ''ElseIf rows2.Count > 0 Then                          '/Checking Modify page privilege here/
                                    ' ''    TemStr = rows2(0).Item("Val").ToString()
                                    ' ''    strArr = TemStr.Split(",")
                                    ' ''    If Not Request.QueryString("ID") = Nothing Then
                                    ' ''        Dim Mainid As Integer = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("ID")))
                                    ' ''        If Mainid = 0 Then
                                    ' ''            If strArr(0) = "1" Then
                                    ' ''            Else
                                    ' ''                Response.Redirect("404.aspx")
                                    ' ''            End If
                                    ' ''        Else
                                    ' ''            If strArr(1) = "1" Or strArr(2) = "1" Or strArr(3) = "1" Then
                                    ' ''            Else
                                    ' ''                Response.Redirect("404.aspx")
                                    ' ''            End If
                                    ' ''        End If
                                    ' ''    Else
                                    ' ''        If (strArr.Length > 3) Then
                                    ' ''            If strArr(1) = "1" Or strArr(2) = "1" Or strArr(3) = "1" Then
                                    ' ''            Else
                                    ' ''                Response.Redirect("404.aspx")
                                    ' ''            End If
                                    ' ''        End If
                                    ' ''    End If
                                Else
                                    Response.Redirect("404.aspx")
                                End If
                            Else

                            End If
                        End If


                    End If
                End If
            Else
                Response.Redirect("Login.aspx")
            End If
            'Privilege End
            Page.Header.DataBind()
            If Session("UserId") = Nothing Then
                blogcookie = Request.Cookies.Get("blogcookievalue")
                If blogcookie.Value = "None" Then
                    Response.Redirect("Login.aspx")
                Else
                    Dim strArr() As String
                    strArr = blogcookie.Value.Split(",")
                    For i As Integer = 0 To strArr.Count - 1
                        If i = 0 Then
                            Session("UserId") = strArr(i)
                            temp = strArr(i)
                        ElseIf i = 1 Then
                            Session("DUserId") = strArr(i)
                            temp = strArr(i)
                        ElseIf i = 2 Then
                            Session("UserName") = strArr(i)
                            temp = strArr(i)
                        ElseIf i = 3 Then
                            Session("UserRoleID") = strArr(i)
                            temp = strArr(i)
                        ElseIf i = 4 Then
                            Session("UName") = strArr(i)
                            temp = strArr(i)
                        ElseIf i = 5 Then
                            Session("Audlog_Id") = strArr(i)
                            temp = strArr(i)
                        End If
                    Next
                    'Response.Redirect(Request.Url.AbsoluteUri)
                    'Session("UserId") = blogcookie.Value
                End If
            End If
            'Session("UserId") = 1
            'Session("DUserId") = 1
            'Session("UserName") = "tahir@swissbake.in"
            'Session("UserRoleID") = 1
            'Session("UName") = "Tahir Shaikh"
            'Session("Audlog_Id") = "671"
            If Not Session("UserRoleID") = "1" Then
                adminmenu1.Visible = False
                adminmenu2.Visible = False
                lib2bsupport.Visible = False
            Else
                adminmenu1.Visible = True
                adminmenu2.Visible = True

                lib2bsupport.Visible = True
            End If
            If Session("UserRoleID") = "3" Then

                horizontal_menu_collapse1.Visible = True
                horizontal_menu_collapse.Visible = False
                sidebarResponsive.Visible = False
                sidebarResponsive1.Visible = True
                sidebarUser1.Visible = True
                sidebarUser.Visible = False
                lidashboard.ViewStateMode = False
                adashboard.Visible = False
                lidivider.Visible = False
                licalendar.Visible = False
                lialarm.Visible = False
                limonthlyrept.Visible = False
            Else
                horizontal_menu_collapse1.Visible = False
                horizontal_menu_collapse.Visible = True
                sidebarResponsive.Visible = True
                sidebarResponsive1.Visible = False
                sidebarUser1.Visible = False
                sidebarUser.Visible = True
            End If
            If Session("UserRoleID") = "4" Then
                horizontal_menu_collapse2.Visible = True
                horizontal_menu_collapse1.Visible = False
                horizontal_menu_collapse.Visible = False
                sidebarResponsive.Visible = False
                sidebarResponsive1.Visible = False
                sidebarResponsive2.Visible = True
                sidebarUser2.Visible = True
                sidebarUser1.Visible = False
                sidebarUser.Visible = False
                lidashboard.ViewStateMode = False
                adashboard.Visible = False
                lidivider.Visible = False
                licalendar.Visible = False
                lialarm.Visible = False
                limonthlyrept.Visible = False
                liCompanyDoc.Visible = False
            End If
            'If Session("UserRoleID") = "2" OrElse Session("UserRoleID") = "3" OrElse Session("UserRoleID") = "4" OrElse Session("UserRoleID") = "5" OrElse Session("UserRoleID") = "6" Then

            '    liDiscount.Visible = False
            'End If


            Dim userNames As String = Session("UserName").ToString().Trim().ToLower()

            If (Session("UserRoleID") = "2" OrElse Session("UserRoleID") = "3" OrElse Session("UserRoleID") = "4" OrElse Session("UserRoleID") = "5" OrElse Session("UserRoleID") = "6") _
AndAlso Not (
     userNames = "sameed@swissbake.org" OrElse
     userNames = "mustansir.sales@swissbake.ch" OrElse
     userNames = "shahab@swissbake.co.in" OrElse
     userNames = "sayyed.nadeem@swissbake.co.in" OrElse
     userNames = "azhar@swissbake.co.in"
) Then

                liDiscount.Visible = False
            End If
            'If Request.Url.AbsolutePath <> "/index.aspx" Then

            '    Dim dt As DataSet = PrivilageBLL.CheckPrivilige(Session("UserRoleID"), Request.Url.AbsolutePath)
            '    Dim dtprivilage As New DataTable
            '    dtprivilage = dt.Tables(0)
            '    If dtprivilage.Rows.Count > 0 Then
            '        For a = 0 To dtprivilage.Rows.Count - 1
            '            Dim MenuId As Integer = DynamicparcelDataManipulation.FixNullFromDB(dtprivilage.Rows(a)("Menu_Id"))
            '            ' MenuId privilege page menu id
            '            '   MenuId=2 is for Formulation

            '            If MenuId = 2 Or MenuId = 3 Then
            '                If (dtprivilage.Rows(a)("Prvg_RAdd").ToString()) = True Then
            '                    ' ''aVModFormulation.Visible = True
            '                    ' ''aHModFormulation.Visible = True
            '                Else
            '                End If
            '                If (dtprivilage.Rows(a)("Prvg_Rview").ToString()) = True Or (dtprivilage.Rows(a)("Prvg_RUpdate").ToString()) = True Then
            '                    ' ''aVFormulation.Visible = True
            '                    ' ''aHFormulation.Visible = True
            '                Else
            '                End If

            '            End If

            '            ' ''If MenuId = 4 Then
            '            ' ''    If (dtprivilage.Rows(a)("Prvg_RAdd").ToString()) = True Then
            '            ' ''        aVModTrial.Visible = True
            '            ' ''        aHModTrial.Visible = True
            '            ' ''    Else
            '            ' ''        aVModTrial.Visible = False
            '            ' ''        aHModTrial.Visible = False
            '            ' ''    End If
            '            ' ''    If (dtprivilage.Rows(a)("Prvg_Rview").ToString()) = True Or (dtprivilage.Rows(a)("Prvg_RUpdate").ToString()) = True Then
            '            ' ''        aVTrial.Visible = True
            '            ' ''        aHTrial.Visible = True
            '            ' ''    Else
            '            ' ''        aVTrial.Visible = False
            '            ' ''        aHTrial.Visible = False
            '            ' ''    End If
            '            ' ''    If aVModTrial.Visible <> True And aVTrial.Visible <> True Then
            '            ' ''        TrialMenu1.Visible = False
            '            ' ''        TrialMenu2.Visible = False
            '            ' ''    Else
            '            ' ''        TrialMenu1.Visible = True
            '            ' ''        TrialMenu2.Visible = True
            '            ' ''    End If
            '            ' ''End If
            '        Next
            '        ' ''If aVModFormulation.Visible <> True And aVFormulation.Visible <> True Then
            '        ' ''    FormulationMenu1.Visible = False
            '        ' ''    FormulationMenu2.Visible = False
            '        ' ''Else
            '        ' ''    FormulationMenu1.Visible = True
            '        ' ''    FormulationMenu2.Visible = True
            '        ' ''End If
            '    Else
            '        ' ''UserMenu1.Visible = False
            '        ' ''UserMenu2.Visible = False
            '        ' ''PrivilegeMenu1.Visible = False
            '        ' ''PrivilegeMenu2.Visible = False
            '        ' ''ReportMenu1.Visible = False
            '        ' ''ReportMenu2.Visible = False
            '        ' ''FormulationMenu1.Visible = False
            '        ' ''FormulationMenu2.Visible = False
            '        '' ''RecipeMenu1.Visible = False
            '        '' ''RecipeMenu2.Visible = False
            '        ' ''TrialMenu1.Visible = False
            '        ' ''TrialMenu2.Visible = False
            '    End If

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
                reminderlnk.Attributes.Remove("class")
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
        End Try
    End Sub

    Public Sub MaintainSession()
        blogcookie = Request.Cookies.Get("blogcookievalue")
        If blogcookie.Value = "None" Then
            Response.Redirect("Login.aspx")
        Else
            Dim strArr() As String
            strArr = blogcookie.Value.Split(",")
            For i As Integer = 0 To strArr.Count - 1
                If i = 0 Then
                    Session("UserId") = strArr(i)
                    temp = strArr(i)
                ElseIf i = 1 Then
                    Session("DUserId") = strArr(i)
                    temp = strArr(i)
                ElseIf i = 2 Then
                    Session("UserName") = strArr(i)
                    temp = strArr(i)
                ElseIf i = 3 Then
                    Session("UserRoleID") = strArr(i)
                    temp = strArr(i)
                ElseIf i = 4 Then
                    Session("UName") = strArr(i)
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
            Dim sb As String = Convert.ToString(MainBLL.ThemeViewByID(Session("UserId"), "CheckThemeViewByID"))
            If sb = "" Then
                themepath.HRef = "default"
                ' themepath.HRef = "css/themes/darkblue.css"
            Else
                themepath.HRef = sb
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "FillColor", error1, Session("UserId"))
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
            ExecptionBLL.Insert("MasterPage", "UserImageUpload", error1, Session("UserId"))
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
        End Try
    End Sub

    Protected Sub btnprofilesave_Click(sender As Object, e As EventArgs) Handles btnprofilesave.Click
        Try
            UserImageUpload()
            If path3 = "" Then
                path3 = "img/placeholders/avatars/avatar2.jpg"
                UserBLL.UpdateImage(lblfname.Text, lbllname.Text, lblmobile.Text, lbldate.Text, path3, Session("UserId"))
            Else
                UserBLL.UpdateImage(lblfname.Text, lbllname.Text, lblmobile.Text, lbldate.Text, path3, Session("UserId"))
            End If


            Response.Redirect(Request.RawUrl)
            FillProfile()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "btnprofilesave_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillProfile()
        Try
            Dim dt As DataSet = MainBLL.ViewByID(Session("UserId"), "UserProfileViewByID")
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
                imgprofileresponsive1.ImageUrl = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ProfileImage").ToString())
                imgprofileresponsive2.ImageUrl = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ProfileImage").ToString())
                Image1.ImageUrl = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ProfileImage").ToString())
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "FillProfile", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Try
            MainBLL.UpdateTheme(Session("UserId"), "css/themes/night.css", "UpdateTheme")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "LinkButton1_Click", error1, Session("UserId"))
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
        End Try
    End Sub

    Protected Sub LinkButton2_Click(sender As Object, e As EventArgs) Handles LinkButton2.Click
        Try
            MainBLL.UpdateTheme(Session("UserId"), "css/themes/amethyst.css", "UpdateTheme")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "LinkButton2_Click", error1, Session("UserId"))
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
        End Try
    End Sub

    Protected Sub LinkButton3_Click(sender As Object, e As EventArgs) Handles LinkButton3.Click
        Try
            MainBLL.UpdateTheme(Session("UserId"), "css/themes/modern.css", "UpdateTheme")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "LinkButton3_Click", error1, Session("UserId"))
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
        End Try
    End Sub

    Protected Sub LinkButton4_Click(sender As Object, e As EventArgs) Handles LinkButton4.Click
        Try
            MainBLL.UpdateTheme(Session("UserId"), "css/themes/autumn.css", "UpdateTheme")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "LinkButton4_Click", error1, Session("UserId"))
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
        End Try
    End Sub

    Protected Sub LinkButton5_Click(sender As Object, e As EventArgs) Handles LinkButton5.Click
        Try
            MainBLL.UpdateTheme(Session("UserId"), "css/themes/flatie.css", "UpdateTheme")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "LinkButton5_Click", error1, Session("UserId"))
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
        End Try
    End Sub

    Protected Sub LinkButton6_Click(sender As Object, e As EventArgs) Handles LinkButton6.Click
        Try
            MainBLL.UpdateTheme(Session("UserId"), "css/themes/spring.css", "UpdateTheme")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "LinkButton6_Click", error1, Session("UserId"))
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
        End Try
    End Sub

    Protected Sub LinkButton7_Click(sender As Object, e As EventArgs) Handles LinkButton7.Click
        Try
            MainBLL.UpdateTheme(Session("UserId"), "css/themes/fancy.css", "UpdateTheme")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "LinkButton7_Click", error1, Session("UserId"))
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
        End Try
    End Sub

    Protected Sub LinkButton8_Click(sender As Object, e As EventArgs) Handles LinkButton8.Click
        Try
            MainBLL.UpdateTheme(Session("UserId"), "css/themes/fire.css", "UpdateTheme")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "LinkButton8_Click", error1, Session("UserId"))
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
        End Try
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "btnsave_Click", error1, Session("UserId"))
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
        End Try
    End Sub

    Public Sub FillDetail()
        Try
            'Dim CompanyId As Integer = 1
            'Dim dt As DataSet = MainBLL.ViewByID(CompanyId, "CrmCompanyViewByID")
            'Dim dtFaq As New DataTable
            'dtFaq = dt.Tables(0)
            'Dim drFaqRow As DataRow
            'drFaqRow = dtFaq.Rows(0)
            'lblcompanyname.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_Name").ToString())
            'lblcompany.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_Name").ToString())
            rpreminder.DataSource = ActivityBLL.ActivityReminder(Session("UserId"))
            rpreminder.DataBind()
            ltremindercount.Text = rpreminder.Items.Count
            ltrmcount.Text = ltremindercount.Text
            If rpreminder.Items.Count = 0 Then
                reminderlnk.Attributes.Remove("class")
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "FillDetail", error1, Session("UserId"))
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
                ExecptionBLL.Insert("MasterPage", "rpreminder_ItemDataBound", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
    End Sub

    ' Public Sub FillGrid()
    '    Try
    '        Dim dt As DataSet = MainBLL.ViewByID(Session("UserId"), "UserProfileViewByID")
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
            ExecptionBLL.Insert("MasterPage", "lbtnFirst_Click", error1, Session("UserId"))
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
        End Try
    End Sub

    Protected Sub txtfirstname_TextChanged(sender As Object, e As EventArgs)
        Try
            UserBLL.UpdateImage(txtfirstname.Text, lbllname.Text, lblmobile.Text, lbldate.Text, HiddenField1.Value, Session("UserId"))
            txtfirstname.Visible = False
            lblfname.Visible = True
            FillProfile()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "txtfirstname_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
        End Try
    End Sub

    Protected Sub txtlastname_TextChanged(sender As Object, e As EventArgs)
        Try
            UserBLL.UpdateImage(lblfname.Text, txtlastname.Text, lblmobile.Text, lbldate.Text, HiddenField1.Value, Session("UserId"))
            txtlastname.Visible = False
            lbllname.Visible = True
            FillProfile()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "txtlastname_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
        End Try
    End Sub

    Protected Sub txtmobile_TextChanged(sender As Object, e As EventArgs)
        Try
            UserBLL.UpdateImage(lblfname.Text, lbllname.Text, txtmobile.Text, lbldate.Text, HiddenField1.Value, Session("UserId"))
            txtmobile.Visible = False
            lblmobile.Visible = True
            FillProfile()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "txtmobile_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
        End Try
    End Sub

    Protected Sub txtdate_TextChanged(sender As Object, e As EventArgs)
        Try
            UserBLL.UpdateImage(lblfname.Text, lbllname.Text, lblmobile.Text, txtdate.Text, HiddenField1.Value, Session("UserId"))
            txtdate.Visible = False
            lbldate.Visible = True
            FillProfile()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "txtdate_TextChanged", error1, Session("UserId"))
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
            ExecptionBLL.Insert("MasterPage", "lbtnLast_Click", error1, Session("UserId"))
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
            ExecptionBLL.Insert("MasterPage", "lbtnMobile_Click", error1, Session("UserId"))
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
            ExecptionBLL.Insert("MasterPage", "lbtndate_Click", error1, Session("UserId"))
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
        End Try
    End Sub

    Protected Sub lnkaddlead_Click(sender As Object, e As EventArgs) Handles lnkaddlead.Click
        Response.Redirect("ModifyLead.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")
    End Sub

    Protected Sub lnkaddprospect_Click(sender As Object, e As EventArgs) Handles lnkaddprospect.Click
        Response.Redirect("ModifyProspect.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")
    End Sub

    Protected Sub lnkaddaccount_Click(sender As Object, e As EventArgs) Handles lnkaddaccount.Click
        Response.Redirect("ModifyAccount.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")
    End Sub

    'Protected Sub lkrawmaterial_Click(sender As Object, e As EventArgs) Handles lkrawmaterial.Click
    '    Response.Redirect("ModifyAccount.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")
    'End Sub

    Protected Sub lkVendor_Click(sender As Object, e As EventArgs) Handles lkVendor.Click
        Response.Redirect("ModifyVendor.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")
    End Sub

    Protected Sub lkQuotationRequest_Click(sender As Object, e As EventArgs) Handles lkQuotationRequest.Click
        Response.Redirect("ModifyQuotationRequest.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")
    End Sub


End Class

