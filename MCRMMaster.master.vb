Imports DynamicparcelEnumerations
Imports System.Diagnostics

Partial Class MCRMMaster
    Inherits System.Web.UI.MasterPage
    Dim path3 As String
    Dim temp As String
    Dim blogcookie As HttpCookie
    Dim strItem As New List(Of String)

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
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
                'adminmenu1.Visible = False
                'adminmenu2.Visible = False
                '  lib2bsupport.Visible = False
            Else
                'adminmenu1.Visible = True
                'adminmenu2.Visible = True

                ' lib2bsupport.Visible = True
            End If
            If Session("UserRoleID") = "3" Then


                horizontal_menu_collapse.Visible = False
                sidebarResponsive.Visible = False
                sidebarUser1.Visible = True
                sidebarUser.Visible = False
                'lidashboard.ViewStateMode = False
                'adashboard.Visible = False
                ' lidivider.Visible = False
                'licalendar.Visible = False
                'lialarm.Visible = False
                ' limonthlyrept.Visible = False
            Else

                horizontal_menu_collapse.Visible = True
                sidebarResponsive.Visible = True
                sidebarUser1.Visible = False
                sidebarUser.Visible = True
            End If
            If Not IsPostBack Then
                Try
                    FillDetail()
                    FillColor()
                    FillProfile()
                Catch ex As Exception
                End Try
            End If
            If ltremindercount.Text = 0 Then
                ' reminderlnk.Attributes.Remove("class")
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
        End Try
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
            rpreminder.DataSource = ActivityBLL.ActivityReminder(Session("UserId"))
            rpreminder.DataBind()
            ltremindercount.Text = rpreminder.Items.Count
            ' ltrmcount.Text = ltremindercount.Text
            If rpreminder.Items.Count = 0 Then
                '   reminderlnk.Attributes.Remove("class")
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

 

    Public Sub UserImageUpload()
        Try
            'If FileUploadControl.PostedFile.FileName = "" Then
            '    path3 = hfimgpath.Value
            'Else
            '    Dim MyDate As DateTime = DateTime.Now
            '    Dim filename As String = Path.GetFileName(MyDate.ToString("ddMMyyhhmmss") + "-" + FileUploadControl.PostedFile.FileName)
            '    path3 = "img/ProfileImage/" + filename

            '    Dim path2 As String = Server.MapPath("~/img/ProfileImage/" + filename)
            '    FileUploadControl.PostedFile.SaveAs(path2)
            '    DynamicparcelImages.CompressImage(path2, 25)
            'End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "UserImageUpload", error1, Session("UserId"))
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
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
                'lblfname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                'txtfirstname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                'lbllname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_LastName").ToString())
                'txtlastname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_LastName").ToString())
                'lbldate.Text = DynamicparcelDataManipulation.DateFormat(drLogin("U_DOB").ToString())
                'txtdate.Text = DynamicparcelDataManipulation.DateFormat(drLogin("U_DOB").ToString())
                'lblmobile.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_Mobile").ToString())
                hfimgpath.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ProfileImage").ToString())
                'txtmobile.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_Mobile").ToString())
                imgprofile.ImageUrl = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ProfileImage").ToString())
                imgprofileresponsive.ImageUrl = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ProfileImage").ToString())
                imgprofileresponsive1.ImageUrl = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ProfileImage").ToString())
                ' Image1.ImageUrl = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ProfileImage").ToString())
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MasterPage", "FillProfile", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
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

End Class

Partial Class MCRMMaster
    Inherits System.Web.UI.MasterPage
End Class

