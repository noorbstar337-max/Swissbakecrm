
Partial Class index1
    Inherits _PageBaseClass
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Session("UserRoleID") = Nothing Then
                Response.Redirect("login.aspx")
                'divall.Visible = False
                'divPurchase.Visible = True
            End If
            If Not IsPostBack Then
                '   If Session("UserRoleID") = "3" Then
                'FillUserName()
                'fillQuotation()
                'fillqrcount()
                'Else
                
                fillLead("FillTopTenActivity")
                
            End If
          
            lblusername.Text = Session("UName")

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Activity", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Closing" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = GridView1.Rows(index)
            Try
                Activityclose.Uhactivity.Value = GridView1.DataKeys(index).Value()
                Dim ltrelatedtype As Literal = DirectCast(row.FindControl("ltrelatedtype"), Literal)
                Dim ltrelatedtypeid As Literal = DirectCast(row.FindControl("ltrelatedtypeid"), Literal)
                Activityclose.Umpclose.Show()
                Activityclose.Uhftype.Value = ltrelatedtype.Text
                Activityclose.Uhftypeid.Value = ltrelatedtypeid.Text
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("Closing", "GridView1_RowCommand", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
            '========================== added By MUBYN 
        ElseIf e.CommandName = "ChangeToDSR" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = GridView1.Rows(index)
            Try
                If deletestatus.Value = "yes" Then
                    Dim ltrelatedtype As Literal = DirectCast(row.FindControl("ltrelatedtype"), Literal)
                    Dim ltrelatedtypeid As Literal = DirectCast(row.FindControl("ltrelatedtypeid"), Literal)
                    Dim Activity_Id As Integer
                    Activity_Id = GridView1.DataKeys(index).Value
                    ActivityBLL.ChangeToDSR(Activity_Id, Session("UserId"))
                    fillLead("FillTopTenActivity")
                    'For Each row As GridViewRow In GridView1.Rows
                    '    GridView1.HeaderRow.Cells(4).Visible = False
                    '    row.Cells(4).Visible = False
                    '    GridView1.HeaderRow.Cells(3).Visible = False
                    '    row.Cells(3).Visible = False
                    'Next
                    UpdatePanel2.Update()
                Else

                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ChangeToDSR", "GridView1_RowCommand", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
            '============= Modification by Mubyn ends here
        ElseIf e.CommandName = "Viewing" Then
            Dim ID As Integer = 0
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = GridView1.Rows(index)
            Dim ltrelatedtype As Literal = DirectCast(row.FindControl("ltrelatedtype"), Literal)
            Dim ltrelatedtypeid As Literal = DirectCast(row.FindControl("ltrelatedtypeid"), Literal)
            ID = GridView1.DataKeys(index).Value
            lvnote.DataSource = NoteBLL.NoteActivWithAssReverse(Session("UserId"), ID)
            lvnote.DataBind()
            grdactivityhistory.DataSource = MainBLL.ViewByID(ID, "ActivityHistory")
            grdactivityhistory.DataBind()
            hfmainactivityid.Value = ID
            hfreltypeId.Value = ltrelatedtypeid.Text
            hfreltype.Value = ltrelatedtype.Text
            Dim dt As DataSet
            If hfreltype.Value = "Account" Or hfreltype.Value = "Prospect" Then
                dt = NoteBLL.RecentActivity(ID, hfreltype.Value, hfreltypeId.Value)
                trcontact.Visible = True
                Dim dtUser As New DataTable
                dtUser = dt.Tables(0)
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                lblname.Text = hfreltype.Value + " Name"
                lblsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                ltstartdate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                ltenddate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                lblaccname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
                ltpriority.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                ltowner.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                If ltpriority.Text = "High" Then
                    ltpriority.CssClass = "label label-success"
                ElseIf ltpriority.Text = "Highest" Then
                    ltpriority.CssClass = "label label-success"
                ElseIf ltpriority.Text = "Lowest" Then
                    ltpriority.CssClass = "label label-danger"
                ElseIf ltpriority.Text = "Low" Then
                    ltpriority.CssClass = "label label-warning"
                ElseIf ltpriority.Text = "Normal" Then
                    ltpriority.CssClass = "label label-info"
                End If
                ltstatus.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                If ltstatus.Text = "Close" Then
                    ltstatus.CssClass = "label label-success"
                ElseIf ltstatus.Text = "Close Postpone" Then
                    ltstatus.CssClass = "label label-info"
                ElseIf ltstatus.Text = "Pending" Or ltstatus.Text = "Due" Then
                    ltstatus.CssClass = "label label-warning"
                ElseIf ltstatus.Text = "Today" Then
                    ltstatus.CssClass = "label label-success"
                ElseIf (ltstatus.Text = "Missed") Then
                    ltstatus.CssClass = "label label-danger"
                ElseIf (ltstatus.Text = "Tommorrow") Then
                    ltstatus.CssClass = "label label-info"
                End If
                ltdesc.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                ltresult.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                ltcontact.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("ContactName").ToString())
                'lblconatctd.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString())
                hffollowactivityid.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Id").ToString())
            ElseIf hfreltype.Value = "Quotation" Then
                dt = NoteBLL.ViewNoteQuotation(ID, hfreltypeId.Value)
                Dim dtUser As New DataTable
                dtUser = dt.Tables(0)
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                lblname.Text = "Quotation Name"
                trcontact.Visible = False
                lblsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                ltstartdate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                ltenddate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                ltpriority.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                ltowner.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                If ltpriority.Text = "High" Then
                    ltpriority.CssClass = "label label-success"
                ElseIf ltpriority.Text = "Highest" Then
                    ltpriority.CssClass = "label label-success"
                ElseIf ltpriority.Text = "Lowest" Then
                    ltpriority.CssClass = "label label-danger"
                ElseIf ltpriority.Text = "Low" Then
                    ltpriority.CssClass = "label label-warning"
                ElseIf ltpriority.Text = "Normal" Then
                    ltpriority.CssClass = "label label-info"
                End If
                ltstatus.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                If ltstatus.Text = "Close" Then
                    ltstatus.CssClass = "label label-success"
                ElseIf ltstatus.Text = "Close Postpone" Then
                    ltstatus.CssClass = "label label-info"
                ElseIf ltstatus.Text = "Pending" Or ltstatus.Text = "Due" Then
                    ltstatus.CssClass = "label label-warning"
                ElseIf ltstatus.Text = "Today" Then
                    ltstatus.CssClass = "label label-success"
                ElseIf (ltstatus.Text = "Missed") Then
                    ltstatus.CssClass = "label label-danger"
                ElseIf (ltstatus.Text = "Tommorrow") Then
                    ltstatus.CssClass = "label label-info"
                End If
                ltdesc.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                ltresult.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                lblaccname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_No").ToString()) + "-" + DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
                'lblconatctd.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString())
                hffollowactivityid.Value = ID
            ElseIf hfreltype.Value = "Opportunity" Then
                dt = NoteBLL.ViewOpportunityByID(ID, hfreltypeId.Value)
                Dim dtUser As New DataTable
                dtUser = dt.Tables(0)
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                lblname.Text = "Opportunity Name"
                lblaccname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity_Name").ToString()) + "-" + DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
                trcontact.Visible = True
                lblsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                ltstartdate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                ltenddate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                ltpriority.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                ltowner.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                ltcontact.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("ContactName").ToString())
                If ltpriority.Text = "High" Then
                    ltpriority.CssClass = "label label-success"
                ElseIf ltpriority.Text = "Highest" Then
                    ltpriority.CssClass = "label label-success"
                ElseIf ltpriority.Text = "Lowest" Then
                    ltpriority.CssClass = "label label-danger"
                ElseIf ltpriority.Text = "Low" Then
                    ltpriority.CssClass = "label label-warning"
                ElseIf ltpriority.Text = "Normal" Then
                    ltpriority.CssClass = "label label-info"
                End If
                ltstatus.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                If ltstatus.Text = "Close" Then
                    ltstatus.CssClass = "label label-success"
                ElseIf ltstatus.Text = "Close Postpone" Then
                    ltstatus.CssClass = "label label-info"
                ElseIf ltstatus.Text = "Pending" Then
                    ltstatus.CssClass = "label label-warning"
                ElseIf ltstatus.Text = "Today" Then
                    ltstatus.CssClass = "label label-success"
                ElseIf (ltstatus.Text = "Missed") Then
                    ltstatus.CssClass = "label label-danger"
                ElseIf (ltstatus.Text = "Tommorrow") Then
                    ltstatus.CssClass = "label label-info"
                End If
                ltdesc.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                ltresult.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                hffollowactivityid.Value = ID
            ElseIf hfreltype.Value = "Lead" Then
                dt = NoteBLL.ViewLeadViewByID(ID, hfreltypeId.Value)
                Dim dtUser As New DataTable
                dtUser = dt.Tables(0)
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                lblname.Text = "Lead Name"
                lblaccname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead_Name").ToString())
                trcontact.Visible = True
                lblsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                ltstartdate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                ltenddate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                ltpriority.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                ltowner.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                ltcontact.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("ContactName").ToString())
                If ltpriority.Text = "High" Then
                    ltpriority.CssClass = "label label-success"
                ElseIf ltpriority.Text = "Highest" Then
                    ltpriority.CssClass = "label label-success"
                ElseIf ltpriority.Text = "Lowest" Then
                    ltpriority.CssClass = "label label-danger"
                ElseIf ltpriority.Text = "Low" Then
                    ltpriority.CssClass = "label label-warning"
                ElseIf ltpriority.Text = "Normal" Then
                    ltpriority.CssClass = "label label-info"
                End If
                ltstatus.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                If ltstatus.Text = "Close" Then
                    ltstatus.CssClass = "label label-success"
                ElseIf ltstatus.Text = "Close Postpone" Then
                    ltstatus.CssClass = "label label-info"
                ElseIf ltstatus.Text = "Pending" Then
                    ltstatus.CssClass = "label label-warning"
                ElseIf ltstatus.Text = "Today" Then
                    ltstatus.CssClass = "label label-success"
                ElseIf (ltstatus.Text = "Missed") Then
                    ltstatus.CssClass = "label label-danger"
                ElseIf (ltstatus.Text = "Tommorrow") Then
                    ltstatus.CssClass = "label label-info"
                End If
                ltdesc.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                ltresult.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                hffollowactivityid.Value = ID
            ElseIf hfreltype.Value = "None" Then
                dt = MainBLL.ViewByID(ID, "ActivityViewByID")
                Dim dtUser As New DataTable
                dtUser = dt.Tables(0)
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                lblname.Text = "Account Name"
                lblaccname.Text = "None"
                trcontact.Visible = False
                lblsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                ltstartdate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                ltenddate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                ltpriority.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                If ltpriority.Text = "High" Then
                    ltpriority.CssClass = "label label-success"
                ElseIf ltpriority.Text = "Highest" Then
                    ltpriority.CssClass = "label label-success"
                ElseIf ltpriority.Text = "Lowest" Then
                    ltpriority.CssClass = "label label-danger"
                ElseIf ltpriority.Text = "Low" Then
                    ltpriority.CssClass = "label label-warning"
                ElseIf ltpriority.Text = "Normal" Then
                    ltpriority.CssClass = "label label-info"
                End If
                ltstatus.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                If ltstatus.Text = "Close" Then
                    ltstatus.CssClass = "label label-success"
                ElseIf ltstatus.Text = "Close Postpone" Then
                    ltstatus.CssClass = "label label-info"
                ElseIf ltstatus.Text = "Pending" Or ltstatus.Text = "Due" Then
                    ltstatus.CssClass = "label label-warning"
                ElseIf ltstatus.Text = "Today" Then
                    ltstatus.CssClass = "label label-success"
                ElseIf (ltstatus.Text = "Missed") Then
                    ltstatus.CssClass = "label label-danger"
                ElseIf (ltstatus.Text = "Tommorrow") Then
                    ltstatus.CssClass = "label label-info"
                End If
                ltdesc.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                ltresult.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                ltowner.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                hffollowactivityid.Value = ID
            End If
            mpefollowup.Show()
        End If
    End Sub
    Protected Sub btncloseyes_Click(sender As Object, e As EventArgs) Handles Activityclose.LKCloseyesClick
        Try
            fillLead("FillTopTenActivity")
            For Each row As GridViewRow In GridView1.Rows
                GridView1.HeaderRow.Cells(4).Visible = False
                row.Cells(4).Visible = False
                GridView1.HeaderRow.Cells(3).Visible = False
                row.Cells(3).Visible = False
            Next
            UpdatePanel2.Update()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("NoteControl", "SaveProduct", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnpostponesave_Click(sender As Object, e As EventArgs) Handles Activityclose.LKpostponesaveClick
        Try
            fillLead("FillTopTenActivity")
            For Each row As GridViewRow In GridView1.Rows
                GridView1.HeaderRow.Cells(4).Visible = False
                row.Cells(4).Visible = False
                GridView1.HeaderRow.Cells(3).Visible = False
                row.Cells(3).Visible = False
            Next
            UpdatePanel2.Update()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("NoteControl", "SaveProduct", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnfollowsave_Click(sender As Object, e As EventArgs) Handles Activityclose.LKfollowsaveClick
        Try
            fillLead("FillTopTenActivity")
            For Each row As GridViewRow In GridView1.Rows
                GridView1.HeaderRow.Cells(4).Visible = False
                row.Cells(4).Visible = False
                GridView1.HeaderRow.Cells(3).Visible = False
                row.Cells(3).Visible = False
            Next
            UpdatePanel2.Update()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("NoteControl", "SaveProduct", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    'Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
    '    Try
    '        If e.Row.RowType = DataControlRowType.DataRow Then
    '            If e.Row.RowType = DataControlRowType.DataRow Then
    '                For Each cell As TableCell In e.Row.Cells
    '                    Dim littext As String = cell.Text
    '                    Dim Literals As Label = New Label()
    '                    If (cell.Text = "Low") Then
    '                        Literals.CssClass = "label label-warning"
    '                    ElseIf (cell.Text = "Lowest") Then
    '                        Literals.CssClass = "label label-warning"
    '                    ElseIf (cell.Text = "High") Then
    '                        Literals.CssClass = "label label-danger"
    '                    ElseIf (cell.Text = "Highest") Then
    '                        Literals.CssClass = "label label-danger"
    '                    ElseIf (cell.Text = "Normal") Then
    '                        Literals.CssClass = "label label-info"
    '                    End If
    '                    If (cell.Text = "Event") Then
    '                        littext = "Sampling/Demo"
    '                    ElseIf (cell.Text = "Call") Then
    '                        littext = "Phone/Email"
    '                    End If
    '                    Literals.Text = littext
    '                    cell.Controls.Add(Literals)

    '                Next
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert("Index.aspx", "GridView1_RowDataBound", error1, Session("UserId"))
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound        '===========Added By MUBYN
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim row As GridViewRow = e.Row
                Dim data As DataRow = DirectCast(row.DataItem, DataRowView).Row
                Dim HyperLink1 As HyperLink = DirectCast(e.Row.FindControl("HyperLink1"), HyperLink)
                Dim lnk As LinkButton = DirectCast(e.Row.FindControl("lnk"), LinkButton)
                Dim lnkChangeDSR As LinkButton = DirectCast(e.Row.FindControl("lnkChangeDSR"), LinkButton)
                Dim ActivityID As Long = data.Field(Of Long)("Id")
                'lnk.Attributes.Add("onClick", "ShowMyModalPopup()")
                'lnk.Attributes.Add("onClick", "ShowMyModalPopup('" & data.Field(Of String)("Status") & "')")

                'Dim Type As String = data.Field(Of String)("Status")
                'GridView.Columns("").Visible = False
                Select Case data.Field(Of String)("Activity Type")
                    Case "Task"
                        HyperLink1.NavigateUrl = Page.ResolveUrl("~/ActivityTask.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID)))
                        Dim activitistatus As String = data.Field(Of String)("Status")
                        If activitistatus = "Close" Then
                            lnk.Visible = False
                            HyperLink1.Visible = False
                        Else
                            lnk.Visible = True
                            HyperLink1.Visible = True
                        End If
                        Exit Select
                        '    'Added By MUBYN
                    Case "Reminder"
                        HyperLink1.NavigateUrl = Page.ResolveUrl("~/Reminder.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID)))
                        Dim activitistatus As String = data.Field(Of String)("Status")
                        If activitistatus = "Close" Then
                            lnk.Visible = False
                            HyperLink1.Visible = False
                            lnkChangeDSR.Visible = False
                        Else
                            lnk.Visible = False
                            HyperLink1.Visible = True
                            lnkChangeDSR.Visible = True
                        End If
                        Exit Select
                    Case "Event"
                        HyperLink1.NavigateUrl = Page.ResolveUrl("~/ActivityEvent.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID)))
                        Dim activitistatus As String = data.Field(Of String)("Status")
                        If activitistatus = "Close" Then
                            lnk.Visible = False
                            HyperLink1.Visible = False
                        Else
                            lnk.Visible = True
                            HyperLink1.Visible = True
                        End If
                        Exit Select
                    Case "Call"
                        HyperLink1.NavigateUrl = Page.ResolveUrl("~/ActivityCall.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID)))
                        Dim activitistatus As String = data.Field(Of String)("Status")
                        If activitistatus = "Close" Then
                            lnk.Visible = False
                            HyperLink1.Visible = False
                        Else
                            lnk.Visible = True
                            HyperLink1.Visible = True
                        End If
                        Exit Select
                        '=============Modification By MUBYN ===========Start
                    Case "DSR"
                        'HyperLink1.NavigateUrl = Page.ResolveUrl("~/dsr.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)))
                        HyperLink1.NavigateUrl = Page.ResolveUrl("~/dsr.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID)))
                        Dim activitistatus As String = data.Field(Of String)("Status")
                        If activitistatus = "Close" Then
                            lnk.Visible = False
                            HyperLink1.Visible = False
                        Else
                            lnk.Visible = True
                            HyperLink1.Visible = True
                        End If
                        Exit Select
                        '=============Modification By MUBYN ===========End

                End Select
                If e.Row.RowType = DataControlRowType.DataRow Then
                    For Each cell As TableCell In e.Row.Cells
                        Dim littext As String = cell.Text
                        Dim Literals As Label = New Label()
                        If (cell.Text = "Pending" Or cell.Text = "Low" Or cell.Text = "Lowest") Then
                            Literals.CssClass = "label label-warning"
                        ElseIf (cell.Text = "Due") Then
                            Literals.CssClass = "label label-warning"
                        ElseIf (cell.Text = "Missed") Then
                            Literals.CssClass = "label label-danger"
                        ElseIf (cell.Text = "High" Or cell.Text = "Highest") Then
                            Literals.CssClass = "label label-danger"
                        ElseIf (cell.Text = "Close" Or cell.Text = "Today") Then
                            Literals.CssClass = "label label-success"
                        ElseIf (cell.Text = "Close Postpone" Or cell.Text = "Normal") Then
                            Literals.CssClass = "label label-info"
                        ElseIf (cell.Text = "Tommorrow") Then
                            Literals.CssClass = "label label-info"
                        End If
                        If (cell.Text = "Event") Then
                            littext = "Sampling/Demo"
                        ElseIf (cell.Text = "Call") Then
                            littext = "Phone/Email"
                        End If
                        Literals.EnableViewState = True
                        Literals.Text = littext
                        cell.Controls.Add(Literals)
                    Next
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Activity", "GridView1_RowDataBound", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillLead(ByVal Type As String)
        Try
            GridView1.DataSource = ActivityBLL.FillAllActivity("0", "10", Session("DUserId"), Type)
            GridView1.DataBind()
            For Each row As GridViewRow In GridView1.Rows
                GridView1.HeaderRow.Cells(4).Visible = False
                row.Cells(4).Visible = False
                GridView1.HeaderRow.Cells(3).Visible = False
                row.Cells(3).Visible = False
                GridView1.HeaderRow.Cells(12).Visible = False
                row.Cells(12).Visible = False
            Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Activity", "fillLead", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class
