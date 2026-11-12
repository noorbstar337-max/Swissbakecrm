Imports System.Web.UI.WebControls
Imports System.Data.SqlClient
Imports System.Data
Imports System.Drawing

Partial Class CRMFeedBacks
    Inherits _PageBaseClass
    Public conn As String
    Public newrecord As Boolean
    Dim admin As String
    Dim pagename As String
    Public tabss As Integer
    Private maxPage As Integer
    Private minPage As Integer
    Public p1 As String
    Public p2 As String
    Public p3 As String
    Dim ds1 As New DataSet()
    Private dt1 As New DataTable()
    Private dt2 As New DataTable()
    Private pgitems As New PagedDataSource()
    Private s As New Security()
    Private _conn As SqlConnection
    Private dr As SqlDataReader
    Private MainId As Integer
    Dim sb As New StringBuilder
    Dim Count As Integer = 0
    Dim Query As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Response.Redirect("index.aspx")
			FillCust()
            FillUser()
            If Request.QueryString("Type") = Nothing Then
                divParam.Visible = False
                divSub.Visible = False
                Dim tempDate As Date = Date.Now.ToString("yyyy-MM-dd")
                Dim startOfMonth As New DateTime(tempDate.Year, tempDate.Month, 1)
                'Dim endOfMonth As DateTime = startOfMonth.AddMonths(1).AddDays(-1)
                startOfMonth = "2020-01-01"
                ddlUser.SelectedValue = Session("UserId")
                Dim endOfMonth As DateTime = Date.Now.ToString("yyyy-MM-dd")
                txtfrom.Text = startOfMonth.ToString("yyyy-MM-dd")
                txtto.Text = endOfMonth.ToString("yyyy-MM-dd")
                hfgridview.Value = "FeedBackByValue"
                BindGridview()
            Else
                If Request.QueryString("Type").ToString = "Rregpvofrhtj" Then
                    lblHead1.Text = "CRM Feedback Report"
                    lblHead2.Text = "CRM Feedback Report"
                    lblHead3.Text = "CRM Feedback Report"
                    divParam.Visible = True
                    divSub.Visible = True
                    Dim tempDate As Date = Date.Now.ToString("yyyy-MM-dd")
                    Dim startOfMonth As New DateTime(tempDate.Year, tempDate.Month, 1)
                    'Dim endOfMonth As DateTime = startOfMonth.AddMonths(1).AddDays(-1)
                    Dim endOfMonth As DateTime = Date.Now.ToString("yyyy-MM-dd")
                    txtfrom.Text = startOfMonth.ToString("yyyy-MM-dd")
                    txtto.Text = endOfMonth.ToString("yyyy-MM-dd")
                    hfgridview.Value = "FeedBackReport"
                    BindGridview()
                ElseIf Request.QueryString("Type").ToString = "prgvfhjsghf" Then
                    divParam.Visible = False
                    divSub.Visible = False
                    Dim tempDate As Date = Date.Now.AddMonths(-1).ToString("yyyy-MM-dd")
                    Dim startOfMonth As New DateTime(tempDate.Year, tempDate.Month, tempDate.Day)
                    'Dim endOfMonth As DateTime = startOfMonth.AddMonths(1).AddDays(-1)
                    Dim endOfMonth As DateTime = Date.Now.ToString("yyyy-MM-dd")
                    ddlUser.SelectedValue = Session("DUserId")
                    txtfrom.Text = startOfMonth.ToString("yyyy-MM-dd")
                    txtto.Text = endOfMonth.ToString("yyyy-MM-dd")
                    hfgridview.Value = "FeedBackByValue"
                    BindGridview()
                End If
            End If



            txtSearch.Attributes.Add("onkeyup", [String].Format("javascript:__doPostBack('{0}','')", rpg.ClientID))

        End If
    End Sub

    Protected Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        If IsPostBack Then
            'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse hfBackcount.Value = "1" Then
            If txtSearch.Text <> "" OrElse hfBackcount.Value = "1" Then
                getsearch()
                fillpage()
            Else
                fillpage()
            End If
        End If
    End Sub
  
    Protected Sub BindGridview()
        Try
            'ds1 = MainBLL.FillGridView(hfgridview.Value)
            If Request.QueryString("Type") = Nothing Then
                ds1 = FeedBackBLL.FillGridByID(hfgridview.Value, ddlUser.SelectedValue, ddlCustomer.SelectedValue, txtfrom.Text, txtto.Text)
            Else
                If Request.QueryString("Type").ToString = "Rregpvofrhtj" Then
                    ds1 = FeedBackBLL.FillReportByID(hfgridview.Value, ddlUser.SelectedValue, ddlCustomer.SelectedValue, txtfrom.Text, txtto.Text, Session("UserId"))
                Else
                    ds1 = FeedBackBLL.FillGridByID(hfgridview.Value, ddlUser.SelectedValue, ddlCustomer.SelectedValue, txtfrom.Text, txtto.Text)
                End If
            End If

            dt1 = ds1.Tables(0)

            Session("dt1FB") = dt1

            fillpage()
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Binding Account'" + ex.Message + ")", True)
        End Try
    End Sub
    Public Sub fillpage()
        Dim dt As New DataTable()
        'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" Then
        If txtSearch.Text <> "" Then
            dt = DirectCast(Session("dt2FB"), DataTable)
        Else

            dt = DirectCast(Session("dt1FB"), DataTable)
        End If
        'If dt.Rows.Count = 0 Then
        '    Dim FooterTemplate As Control = rpgridview.Controls(rpgridview.Controls.Count - 1).Controls(0)
        '    FooterTemplate.FindControl("trEmpty").Visible = True
        'Else
        If dt.Rows.Count = 0 Then
            pgitems.DataSource = dt.DefaultView
            rpgridview.DataSource = pgitems
            rpgridview.DataBind()
            Dim FooterTemplate As Control = rpgridview.Controls(rpgridview.Controls.Count - 1).Controls(0)
            FooterTemplate.FindControl("trEmpty").Visible = True
            PopulatePager(0, 1)
            ' pgitems.AllowPaging = false ;

            lblTcount.Visible = False
        Else
            pgitems.DataSource = dt.DefaultView
            pgitems.AllowPaging = True
            lblTcount.Visible = True
            Count = dt.Rows.Count
            If Count > 1 Then
                lblTcount.Text = Count.ToString() + " " + " records"
            Else
                lblTcount.Text = Count.ToString() + " " + " record"
            End If

            pgitems.PageSize = Convert.ToInt32(ddpagesize.SelectedValue)
            PopulatePager(pgitems.PageCount, PageNumber)
            pgitems.CurrentPageIndex = PageNumber

            tabss = PageNumber + 1
            tab.Value = tabss.ToString()

            rpgridview.DataSource = pgitems
            rpgridview.DataBind()
        End If
        'End If
        'CheckPrivilage()
    End Sub
    Private Sub PopulatePager(recordCount As Integer, currentPage As Integer)
        ' int drcount = Convert.ToInt32(lblTcount.Text.Trim("records");
        If Count > 10 Then
            Dim dblPageCount As Double = CDbl(CDec(recordCount) / Decimal.Parse((1).ToString()))
            Dim pageCount As Integer = CInt(Math.Ceiling(dblPageCount))
            Dim pages As New List(Of ListItem)()
            If pageCount > 0 Then
                If PageNumber = 0 Then
                Else
                    pages.Add(New ListItem("<", "1", currentPage > 1))
                End If
                Dim pagesToShow As Integer = 4
                minPage = Math.Max(1, currentPage - (pagesToShow / 2))
                maxPage = Math.Min(pageCount, minPage + pagesToShow)

                'if (minPage > 1)
                '    pages.Add(new ListItem("...", (minPage - 1).ToString(), false));
                For i As Integer = minPage To maxPage
                    pages.Add(New ListItem(i.ToString(), i.ToString(), i <> currentPage))
                Next

                'if (maxPage < pageCount)
                '    pages.Add(new ListItem("...", (maxPage + 1).ToString(), false));

                If PageNumber = maxPage - 1 Then
                Else
                    pages.Add(New ListItem(">", pageCount.ToString(), currentPage < pageCount))

                End If
            End If
            Dim g As New System.Web.UI.HtmlControls.HtmlGenericControl()
            rptPaging.DataSource = pages
            rptPaging.DataBind()
        Else
            Dim pages As New DataTable()
            pages.Clear()
            rptPaging.DataSource = pages
            rptPaging.DataBind()
        End If

    End Sub
    Protected Sub rptPaging_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs)
        If e.CommandArgument.ToString() = "<" Then
            PageNumber = PageNumber - 1
            'FillDemoGridview();
            fillpage()
        ElseIf e.CommandArgument.ToString() = ">" Then
            PageNumber = PageNumber + 1
            'FillDemoGridview();
            fillpage()
        Else
            PageNumber = Convert.ToInt32(e.CommandArgument) - 1
            'FillDemoGridview();
            fillpage()
        End If

    End Sub

    Public Property PageNumber() As Integer
        Get
            If ViewState("PageNumber") IsNot Nothing Then
                Return Convert.ToInt32(ViewState("PageNumber"))
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            ViewState("PageNumber") = value
        End Set
    End Property

    Protected Sub rptPaging_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        'If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
        '    Dim scriptMan As ScriptManager = ScriptManager.GetCurrent(Me)
        '    Dim btn As LinkButton = TryCast(e.Item.FindControl("btnPage"), LinkButton)
        '    If btn IsNot Nothing Then
        '        'btn.Click += LinkButton1_Click
        '        scriptMan.RegisterAsyncPostBackControl(btn)
        '    End If
        'End If


        Dim linkButton As LinkButton = DirectCast(e.Item.FindControl("btnPage"), LinkButton)

        If linkButton Is Nothing Then
        Else
            Dim scriptManager__1 = ScriptManager.GetCurrent(Me.Page)
            If scriptManager__1 IsNot Nothing Then
                scriptManager__1.RegisterAsyncPostBackControl(linkButton)
            End If
        End If
    End Sub


    Public Sub getsearch()
        Try

            'date time column not working in search and footer
            dt2 = DirectCast(Session("dt1FB"), DataTable)


            If txtSearch.Text <> "" Then
                Dim selectedTable1 As DataTable = dt2.AsEnumerable().Where(Function(r) (r.Field(Of String)("AccName").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                                                  (r.Field(Of String)("ContactName").ToString.ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                                                  (r.Field(Of String)("Subject").ToString.ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                                                  (r.Field(Of String)("From1").ToString.ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                                                  (r.Field(Of String)("Ratings").ToString.ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                                                  (r.Field(Of String)("U_FirstName").ToUpper().Contains(txtSearch.Text.ToUpper()))
                                                  ).CopyToDataTable()

                Session("dt2FB") = selectedTable1
            Else
                'Dim selectedTable1 As DataTable = dt2.AsEnumerable().Where(Function(r) (r.Field(Of String)("Acc_Name").ToUpper().Contains(TextBox1.Text.ToUpper())) AndAlso
                '           (r.Field(Of String)("Contact_ContactPerson").ToUpper().Contains(TextBox2.Text.ToUpper())) AndAlso
                '            (r.Field(Of String)("Contact_Landline").ToUpper().Contains(TextBox3.Text.ToUpper())) AndAlso
                '             (r.Field(Of String)("Contact_Email").ToUpper().Contains(TextBox4.Text.ToUpper())) AndAlso
                '(r.Field(Of String)("Contact_Mobile").ToUpper().Contains(TextBox5.Text.ToUpper())) AndAlso
                '(r.Field(Of String)("city").ToUpper().Contains(TextBox6.Text.ToUpper())) AndAlso
                '(r.Field(Of String)("Acc_Type").ToUpper().Contains(TextBox9.Text.ToUpper())) AndAlso
                '(r.Field(Of String)("AssignTo").ToUpper().Contains(TextBox7.Text.ToUpper())) AndAlso
                '(r.Field(Of String)("Reseller_Name").ToUpper().Contains(TextBox10.Text.ToUpper())) AndAlso
                '(r.Field(Of String)("Acc_OpenFrom").ToUpper().Contains(TextBox8.Text.ToUpper()))
                '           ).CopyToDataTable()

                'Session("dt2FB") = selectedTable1



            End If
        Catch ex As Exception
            '  Session["dt2"] = "1";
            Dim exception As New DataTable()
            exception.Clear()

            Session("dt2FB") = exception
        End Try
    End Sub

    Protected Sub ddpagesize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddpagesize.SelectedIndexChanged
        fillpage()

    End Sub

    Protected Sub Text_TextChanged(sender As Object, e As EventArgs)
        PageNumber = 0
    End Sub

    Protected Sub rpgridview_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rpgridview.ItemCommand
        Try
            If e.CommandName = "Delete" Then
                If deletestatus.Value = "yes" Then
                    Dim uid As Integer = Convert.ToInt32(e.CommandArgument.ToString())

                    Try
                        'MainBLL.DeleteSI(MainId, Session("UserID"), "LeadDeleteSi")
                        BindGridview()
                    Catch ex As Exception
                        Dim error1 As String = ex.Message.Replace(Chr(34), "")
                        error1 = error1.Replace(Chr(39), "")

                        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                    End Try
                End If

            ElseIf (e.CommandName = "MessagePopUp") Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument.ToString())
                'Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                'Cont_ID = Gridview1.DataKeys(index).Value
                Try

                    mpe.Enabled = True
                    mpe.Show()
                    ''Dim DsPop As DataTable = MainBLL.ViewByID(index, "ViewEmailSMSPopByID").Tables(0)
                    ''If DsPop.Rows.Count > 0 Then

                    ''    Dim drLogin As DataRow
                    ''    drLogin = DsPop.Rows(0)
                    Dim lblRemark As Literal = DirectCast(e.Item.FindControl("lblRemark"), Literal)
                    Dim lblRating_TypeId As Literal = DirectCast(e.Item.FindControl("lblRating_TypeId"), Literal)
                    Dim lblRating_Listening As Literal = DirectCast(e.Item.FindControl("lblRating_Listening"), Literal)
                    Dim lblRating_Knowledge As Literal = DirectCast(e.Item.FindControl("lblRating_Knowledge"), Literal)
                    Dim lblRating_Understandability As Literal = DirectCast(e.Item.FindControl("lblRating_Understandability"), Literal)

                    lblMessage.Text = lblRemark.Text
                    lblRating.Text = lblRating_TypeId.Text
                    RatingListening.CurrentRating = lblRating_Listening.Text
                    RatingKnowledge.CurrentRating = lblRating_Knowledge.Text
                    RatingUnderstandability.CurrentRating = lblRating_Understandability.Text
                    ' ''lblMessage.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Message_Message").ToString())
                    ' ''lblFromPopUp.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Message_From").ToString())
                    ' ''lblToPopUp.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Message_To").ToString())
                    ' ''If lblType.Text = "Email" Then
                    ' ''    Dim CC As String = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Message_Cc").ToString())
                    ' ''    Dim BCC As String = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Message_Bcc").ToString())
                    ' ''    If CC <> "" Then
                    ' ''        lblCCPopUp1.Visible = True
                    ' ''        lblCCPopUp.Visible = True
                    ' ''        lblCCPopUp.Text = CC
                    ' ''    End If
                    ' ''    If BCC <> "" Then
                    ' ''        lblBCCPopUp1.Visible = True
                    ' ''        lblBCCPopUp.Visible = True
                    ' ''        lblBCCPopUp.Text = BCC
                    ' ''    End If
                    ' ''Else
                    ' ''    lblCCPopUp1.Visible = False
                    ' ''    lblCCPopUp.Visible = False
                    ' ''    lblBCCPopUp1.Visible = False
                    ' ''    lblBCCPopUp.Visible = False
                    ' ''End If
                    ''End If

                    Dim lblActivityID As Literal = DirectCast(e.Item.FindControl("lblActivityID"), Literal)
                    Dim ID As Integer = 0
                    'Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                    'Dim row As GridViewRow = GridView1.Rows(index)
                    ''Dim lbluId As Literal = DirectCast(GridView1.Items(index).FindControl("lbluId"), Literal)
                    Dim lblRelatedType As Literal = DirectCast(e.Item.FindControl("lblRelatedType"), Literal)
                    Dim lblRelatedTypeID As Literal = DirectCast(e.Item.FindControl("lblRelatedTypeID"), Literal)
                    ID = lblActivityID.Text ' index 'GridView1.DataKeys(index).Value
                    'lvnote.DataSource = NoteBLL.NoteActivWithAssReverse(Session("UserId"), ID)
                    'lvnote.DataBind()
                    'grdactivityhistory.DataSource = MainBLL.ViewByID(ID, "ActivityHistory")
                    'grdactivityhistory.DataBind()
                    hfmainactivityid.Value = ID
                    hfreltypeId.Value = lblRelatedTypeID.Text
                    hfreltype.Value = lblRelatedType.Text
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
                Catch ex As Exception
                    ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Updating Status')", True)
                End Try

            End If

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Deleting Class')", True)
        End Try
    End Sub

    Public Sub FillUser()
        Try
            'MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim ds As DataSet
            ' If MainID = 0 Then
            ds = FeedBackBLL.Dropdown("UserDD", Session("UserId"))
            ddlUser.DataSource = ds.Tables(0)
            ddlUser.DataTextField = "U_FirstName"
            ddlUser.DataValueField = "U_ID"
            ddlUser.DataBind()
            ddlUser.Items.Insert(0, New ListItem("All", "0"))
            ''FillddlCompany()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")

            Throw ex
        End Try
    End Sub
    Public Sub FillCust()
        Try
            'MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim ds As DataSet
            ' If MainID = 0 Then
            ds = FeedBackBLL.Dropdown("AllAccountDD", Session("UserId"))
            ddlCustomer.DataSource = ds.Tables(0)
            ddlCustomer.DataTextField = "Acc_Name"
            ddlCustomer.DataValueField = "Acc_ID"
            ddlCustomer.DataBind()
            ddlCustomer.Items.Insert(0, New ListItem("All", "0"))
            ''FillddlCompany()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")

            Throw ex
        End Try
    End Sub

    Protected Sub btndashboard_Click(sender As Object, e As EventArgs) Handles btndashboard.Click
        Try
            BindGridview()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            'ExecptionBLL.Insert("Activity", "fillLead", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try

            Response.Clear()
            Response.Buffer = True
            Dim FileName As String = "CRM-Feeback-list-" + Date.Now + ".xls"
            Response.AddHeader("Content-Disposition", Convert.ToString("attachment;filename=") & FileName)
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)
            Dim Gridview2 As New GridView


            Dim dtASD As New DataTable()
            'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" Then
            'If txtSearch.Text <> "" Then
            '    dtASD = TryCast(Session("dt2FB"), DataTable)
            'Else
            '    dtASD = TryCast(Session("dt1FB"), DataTable)
            'End If
            If Request.QueryString("Type") = Nothing Then
                dtASD = FeedBackBLL.FillGridByID(hfgridview.Value, ddlUser.SelectedValue, ddlCustomer.SelectedValue, txtfrom.Text, txtto.Text).Tables(0)
            Else
                If Request.QueryString("Type").ToString = "Rregpvofrhtj" Then
                    dtASD = FeedBackBLL.FillReportByID(hfgridview.Value, ddlUser.SelectedValue, ddlCustomer.SelectedValue, txtfrom.Text, txtto.Text, Session("UserId")).Tables(0)
                Else
                    dtASD = FeedBackBLL.FillGridByID(hfgridview.Value, ddlUser.SelectedValue, ddlCustomer.SelectedValue, txtfrom.Text, txtto.Text).Tables(0)
                End If
            End If
            'dtASD = FeedBackBLL.FillGridByID(hfgridview.Value, ddlUser.SelectedValue, ddlCustomer.SelectedValue, txtfrom.Text, txtto.Text).Tables(0)

            Dim dtExc As New DataTable
            dtExc = dtASD
            '          [Rating_Listening], [Rating_Knowledge], [Rating_Understandability]
            ', [Rating_Remark], [Rating_Status], [Rating_CreateDate], [Rating_CreatedBy], [Rating_ModifyDate], [Rating_ModifiedBy]
            dtExc.Columns.Remove("Rating_Id")
            dtExc.Columns.Remove("Rating_AgentId")
            dtExc.Columns.Remove("Rating_TypeId")
            dtExc.Columns.Remove("Rating_ActivityId")
            dtExc.Columns.Remove("Rating_Status")
            dtExc.Columns.Remove("Rating_CreateDate")
            dtExc.Columns.Remove("Rating_CreatedBy")
            dtExc.Columns.Remove("Rating_ModifyDate")
            dtExc.Columns.Remove("Rating_ModifiedBy")
            dtExc.Columns.Remove("Rating_Delete")
            dtExc.Columns.Remove("Rating_DeleteDate")
            dtExc.Columns.Remove("Rating_BadStatus")
            dtExc.Columns.Remove("Activity_RelatedType")
            dtExc.Columns.Remove("Activity_Id")
            dtExc.Columns.Remove("Activity_RelatedTypeID")
            dtExc.Columns.Remove("ActivityType")
            'dtExc.Columns.Remove("Activity_RelatedTypeID1")
            dtExc.Columns.Remove("RelatedType")
            dtExc.Columns.Remove("To1")
            dtExc.Columns.Remove("Activity_CallStartTime")

            dtExc.Columns("U_FirstName").ColumnName = "User"
            dtExc.Columns("AccName").ColumnName = "Customer"
            dtExc.Columns("ContactName").ColumnName = "Contact"
            dtExc.Columns("Subject").ColumnName = "Subject"
            dtExc.Columns("From1").ColumnName = "Date"
            dtExc.Columns("Rating_Remark").ColumnName = "Customer Remark"
            dtExc.Columns("Rating_Listening").ColumnName = "Communication"
            dtExc.Columns("Rating_Knowledge").ColumnName = "Product Knowledge"
            dtExc.Columns("Rating_Understandability").ColumnName = "Attitude"
            dtExc.Columns("User").SetOrdinal(0)
            dtExc.Columns("Customer").SetOrdinal(1)
            dtExc.Columns("Contact").SetOrdinal(2)
            dtExc.Columns("Subject").SetOrdinal(3)
            dtExc.Columns("Date").SetOrdinal(4)
            dtExc.Columns("Ratings").SetOrdinal(5)
            dtExc.Columns("Communication").SetOrdinal(6)
            dtExc.Columns("Product Knowledge").SetOrdinal(7)
            dtExc.Columns("Attitude").SetOrdinal(8)
            dtExc.Columns("Customer Remark").SetOrdinal(9)

            Gridview2.DataSource = dtExc
            Gridview2.DataBind()
            Gridview2.AllowPaging = False
            Gridview2.DataBind()
            Gridview2.RenderControl(hw)

            'style to format numbers to string
            Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
            Response.Write(style)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.End()
            'Dim html2 As String = Regex.Replace(sw.ToString(), "(<img\/?[^>]+>)", "", RegexOptions.IgnoreCase)
            ''html2 = Regex.Replace(html2, "(<input class=""checkbox""\/?[^>]+>)", "", RegexOptions.IgnoreCase)
            'html2 = Regex.Replace(html2, "(<a \/?[^>]+>)", "", RegexOptions.IgnoreCase)
            'html2 = Regex.Replace(html2, "(<i \/?[^>]+>)", "(INR)", RegexOptions.IgnoreCase)
            'Response.Write(html2.ToString())
            'Response.Flush()
            'Response.End()

            'DoValidate.closeConn(_conn)

        Catch ex As Exception

        End Try
    End Sub

    'Public Sub CheckPrivilage()
    '    Try
    '        Dim dsPriv As DataSet = PrivilegeBLL.PrivilegeByPage(Session("UserRoleID"), "Account List")
    '        Dim dtPriv As DataTable = dsPriv.Tables(0)
    '        If dtPriv.Rows.Count > 0 Then
    '            If dtPriv.Rows(0)("Prvg_RAdd") = False And dtPriv.Rows(0)("Prvg_RUpdate") = False And dtPriv.Rows(0)("Prvg_Rview") = False And dtPriv.Rows(0)("Prvg_RDelete") = False Then
    '                Response.Redirect("index.aspx")
    '            Else
    '                'If dtPriv.Rows(0)("Prvg_RAdd") = True Then
    '                '    hlnkAdd.Visible = True
    '                'Else
    '                '    hlnkAdd.Visible = False
    '                'End If
    '                If dtPriv.Rows(0)("Prvg_RUpdate") = True Then
    '                    For Each Item In rpgridview.Items
    '                        Dim tdEdit As HtmlTableCell = DirectCast(Item.FindControl("tdedit"), HtmlTableCell)
    '                        tdEdit.Visible = True
    '                    Next
    '                    thEdit.Visible = True
    '                End If
    '                If dtPriv.Rows(0)("Prvg_Rview") = True Then
    '                    For Each Item In rpgridview.Items
    '                        Dim tdEdit As HtmlTableCell = DirectCast(Item.FindControl("tdedit"), HtmlTableCell)
    '                        tdEdit.Visible = True
    '                    Next
    '                    thEdit.Visible = True
    '                End If
    '                If dtPriv.Rows(0)("Prvg_RDelete") = True Then
    '                    'For Each Item In rpgridview.Items
    '                    '    Dim tddelete As HtmlTableCell = DirectCast(Item.FindControl("tddelete"), HtmlTableCell)
    '                    '    tddelete.Visible = False
    '                    'Next
    '                    'thDelete.Visible = False
    '                End If

    '            End If
    '        Else
    '            Response.Redirect("index.aspx")
    '        End If

    '        'If Request.QueryString("chk") = "e" Then  'For Edit
    '        '    If dtPriv.Rows(0)("Prvg_RUpdate") = True Then
    '        '        ' hfAccessFor.Value = "Formulation"
    '        '    Else
    '        '        Response.Redirect("index.aspx")
    '        '    End If
    '        'ElseIf Request.QueryString("chk") = "v" Then  'For View
    '        '    If dtPriv.Rows(0)("Prvg_Rview") = True Then
    '        '        ' hfAccessFor.Value = "Formulation"
    '        '    Else
    '        '        Response.Redirect("index.aspx")
    '        '    End If
    '        'Else         ' for add new 
    '        '    If dtPriv.Rows(0)("Prvg_RAdd") = True Then
    '        '        ' hfAccessFor.Value = "Formulation"
    '        '    Else
    '        '        Response.Redirect("index.aspx")
    '        '    End If
    '        'End If
    '    Catch ex As Exception

    '    End Try
    'End Sub


    Protected Sub ddlCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCustomer.SelectedIndexChanged
        Try
            BindGridview()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ddlUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlUser.SelectedIndexChanged
        Try
            BindGridview()
        Catch ex As Exception

        End Try
    End Sub
End Class

