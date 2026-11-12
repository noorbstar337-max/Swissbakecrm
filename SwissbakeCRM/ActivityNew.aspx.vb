Imports System.Drawing

Partial Class ActivityNew
    'Inherits _PageBaseClass
    Inherits System.Web.UI.Page
    Dim FormDate As String, FromTime As String, FromDateTime As String
    Dim toDate As String, Toime As String, ToDateTime As String
    Dim Total As Integer = 0
    Dim Type As String
    Dim Query As String
    Dim ModuleName As String
    Dim strNames As New List(Of String)
    Dim sb As New StringBuilder
    Private MainId As Integer
    Dim Count As Integer = 0
    Dim ds1 As New DataSet()
    Private dt1 As New DataTable()
    Private dt2 As New DataTable()
    Private dt3 As New DataTable()
    Private pgitems As New PagedDataSource()
    Public tabss As Integer
    Private maxPage As Integer
    Private minPage As Integer
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
            Try
                If Not IsPostBack Then
                    'txtsearch.Attributes.Add("onkeyup", [String].Format("javascript:__doPostBack('{0}','')", rpg.ClientID))
                    If Request.QueryString("type") = Nothing Then
                        hfSearchValue.Value = ""
                        hfType.Value = ""
                        BindLoad()
                        'BindGridview()
                    End If
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("Activity", "Page_Load", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        Else
            Try
                If Not IsPostBack Then
                    'txtsearch.Attributes.Add("onkeyup", [String].Format("javascript:__doPostBack('{0}','')", rpg.ClientID))
                    If Request.QueryString("type") = Nothing Then
                        hfSearchValue.Value = ""
                        hfType.Value = ""
                        BindLoad()
                        'BindGridview()
                    End If
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("Activity", "Page_Load", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If

    End Sub
    Protected Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        If IsPostBack Then
            'If txtsearch.Text <> "" OrElse hfBackcount.Value = "1" Then
            '    'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" OrElse hfBackcount.Value = "1" Then
            '    getsearch()
            '    fillpage()
            'Else
            fillpage()
            'End If
        End If
    End Sub


    Protected Sub BindGridview()
        Try
            'ds1 = MainBLL.FillGridByID(Hfgridview.Value, Session("UserId"))
            'ds1 = ActivityBLL.FillAllActivity("0", "10", Session("UserId"), Type)
            'ds1 = ActivityBLL.SearchAllActivity("FillAllActivityCRM", Session("UserId"), txtsearch.Text.Trim)
            ds1 = ActivityBLL.SearchActivitybyType("FillAllActivityCRM", Session("UserId"), hfSearchValue.Value, hfType.Value)
            'ds1 = MainBLL.FillGridView(hfgridview.Value)
            If ds1.Tables(0).Rows.Count > 0 Then
                dt1 = ds1.Tables(0)
                'rpgridview.DataSource = dt1
                'rpgridview.DataBind()
            End If
            dt3 = dt1
            Session("dt1ActNew") = dt1
            'If txtsearch.Text <> "" Then
            ' Session("dt2ActNew") = dt1
            'End If
            fillpage()
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Binding Account'" + ex.Message + ")", True)
        End Try
    End Sub
    Public Sub fillpage()
        Dim dt As New DataTable()
        ' ''If txtsearch.Text <> "" Then
        ' ''    'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" Then
        ' ''    dt = DirectCast( Session("dt2ActNew"), DataTable)
        ' ''Else
        dt = DirectCast(Session("dt1ActNew"), DataTable)
        ' ''End If
        If dt IsNot Nothing Then
            If dt.Rows.Count = 0 Then
                pgitems.DataSource = dt.DefaultView
                GridView1.DataSource = pgitems
                GridView1.DataBind()
                Dim FooterTemplate As Control = GridView1.Controls(GridView1.Controls.Count - 1).Controls(0)
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

                GridView1.DataSource = pgitems
                GridView1.DataBind()
            End If
        End If
        ' '' '' '' '' '' ''CheckPrivilage()
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
        Dim linkButton As LinkButton = DirectCast(e.Item.FindControl("btnPage"), LinkButton)

        If linkButton Is Nothing Then
        Else
            Dim scriptManager__1 = ScriptManager.GetCurrent(Me.Page)
            If scriptManager__1 IsNot Nothing Then
                scriptManager__1.RegisterAsyncPostBackControl(linkButton)
            End If
        End If
    End Sub

    'Public Sub getsearch()
    '    Try

    '        'date time column not working in search and footer
    '        dt2 = DirectCast( Session("dt1ActNew"), DataTable)


    '        If txtsearch.Text <> "" Then
    '            Dim selectedTable1 As DataTable = dt2.AsEnumerable().Where(Function(r) (r.Field(Of String)("RelatedType").ToUpper().Contains(txtsearch.Text.ToUpper())) OrElse
    '                       (r.Field(Of String)("Name").ToUpper().Contains(txtsearch.Text.ToUpper())) OrElse
    '                        (r.Field(Of String)("Subject").ToUpper().Contains(txtsearch.Text.ToUpper())) OrElse
    '                         (r.Field(Of String)("ActivityType").ToUpper().Contains(txtsearch.Text.ToUpper())) OrElse
    '            (r.Field(Of String)("From1").ToUpper().Contains(txtsearch.Text.ToUpper())) OrElse
    '            (r.Field(Of String)("To1").ToUpper().Contains(txtsearch.Text.ToUpper())) OrElse
    '            (r.Field(Of String)("Priority").ToUpper().Contains(txtsearch.Text.ToUpper())) OrElse
    '            (r.Field(Of String)("Status").ToUpper().Contains(txtsearch.Text.ToUpper())) OrElse
    '            (r.Field(Of String)("AssignTo").ToUpper().Contains(txtsearch.Text.ToUpper())) OrElse
    '            (r.Field(Of String)("Activity_Description").ToUpper().Contains(txtsearch.Text.ToUpper()))
    '                            ).CopyToDataTable()

    '             Session("dt2ActNew") = selectedTable1
    '            'Else
    '            '    Dim selectedTable1 As DataTable = dt2.AsEnumerable().Where(Function(r) (r.Field(Of String)("Acc_Name").ToUpper().Contains(TextBox1.Text.ToUpper())) AndAlso
    '            '               (r.Field(Of String)("Contact_ContactPerson").ToUpper().Contains(TextBox2.Text.ToUpper())) AndAlso
    '            '                (r.Field(Of String)("Contact_Landline").ToUpper().Contains(TextBox3.Text.ToUpper())) AndAlso
    '            '                 (r.Field(Of String)("Contact_Email").ToUpper().Contains(TextBox4.Text.ToUpper())) AndAlso
    '            '    (r.Field(Of String)("Contact_Mobile").ToUpper().Contains(TextBox5.Text.ToUpper())) AndAlso
    '            '    (r.Field(Of String)("city").ToUpper().Contains(TextBox6.Text.ToUpper())) AndAlso
    '            '    (r.Field(Of String)("AssignTo").ToUpper().Contains(TextBox7.Text.ToUpper())) AndAlso
    '            '    (r.Field(Of String)("Acc_OpenFrom").ToUpper().Contains(TextBox8.Text.ToUpper()))
    '            '               ).CopyToDataTable()

    '            '     Session("dt2ActNew") = selectedTable1



    '        End If
    '    Catch ex As Exception
    '        '  Session["dt2"] = "1";
    '        Dim exception As New DataTable()
    '        exception.Clear()

    '         Session("dt2ActNew") = exception
    '    End Try
    'End Sub
    Protected Sub Sorting(sender As Object, e As EventArgs)
        Try
            Dim Header As LinkButton = DirectCast(sender, LinkButton)

            If Not Session("dt1ActNew") Is Nothing Then
                Dim dt As DataTable = Session("dt1ActNew")
                If ViewState("SortDir") Is Nothing Or ViewState("SortDir") = "Asc" Then
                    dt.DefaultView.Sort = Header.ID
                    dt = dt.DefaultView.ToTable()
                    ViewState("SortDir") = "Desc"
                Else
                    dt.DefaultView.Sort = Header.ID & " DESC"
                    dt = dt.DefaultView.ToTable()
                    ViewState("SortDir") = "Asc"
                End If
                Session("dt1ActNew") = dt
                fillpage()

            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub ddpagesize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddpagesize.SelectedIndexChanged
        fillpage()

    End Sub

    Protected Sub Text_TextChanged(sender As Object, e As EventArgs)
        PageNumber = 0
    End Sub

    Public Sub CheckPrivilage()
        Try
            Dim dt As DataSet = PrivilageBLL.CheckPrivilige(Session("UserRoleID"), "Activity.aspx")
            Dim dtprivilage As New DataTable
            dtprivilage = dt.Tables(0)
            Dim drprivilage As DataRow
            If dtprivilage.Rows.Count = 0 Then
                '' ''hlnkAdd.Visible = False****
                thEdit.Visible = False
                For i As Integer = 0 To GridView1.Items.Count - 1
                    Dim tdEdit As HtmlTableCell = DirectCast(GridView1.Items(i).FindControl("tdEdit"), HtmlTableCell)
                    tdEdit.Visible = False
                Next
                ' ''SearchControl.Uhfadd.Visible = False
                ' ''GridView1.Columns(0).Visible = False
                ' ''SearchControl.ULkadd.Visible = False

            Else

                drprivilage = dtprivilage.Rows(0)
                If (drprivilage("Prvg_RAdd").ToString()) = True Then
                    ' ''hlnkAdd.Visible = True*******
                    ' ''SearchControl.Uhfadd.Visible = True
                Else
                    ' ''hlnkAdd.Visible = False******
                    ' ''SearchControl.Uhfadd.Visible = False
                End If
                If (drprivilage("Prvg_RUpdate").ToString()) = True Then
                    ' ''GridView1.Columns(0).Visible = True
                Else
                    thEdit.Visible = False
                    For i As Integer = 0 To GridView1.Items.Count - 1
                        Dim tdEdit As HtmlTableCell = DirectCast(GridView1.Items(i).FindControl("tdEdit"), HtmlTableCell)
                        tdEdit.Visible = False
                    Next
                    ' ''GridView1.Columns(0).Visible = False
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Account", "CheckPrivilage", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Public Sub fillLead(ByVal Type As String)
        Try
            'GridView1.DataSource = ActivityBLL.FillAllActivity("0", "10", Session("UserId"), Type)
            'GridView1.DataBind()

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Activity", "fillLead", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles GridView1.ItemCommand
        Try
            If e.CommandName = "Closing" Then
                Dim ID As Integer = 0
                Dim index As Integer = Convert.ToInt32(e.CommandArgument.ToString())
                Dim row As RepeaterItem = GridView1.Items(index)
                'Dim row As GridViewRow = GridView1.Rows(index)
                Try
                    Dim lbluId As Literal = DirectCast(GridView1.Items(index).FindControl("lbluId"), Literal)
                    Dim ltrelatedtype As Literal = DirectCast(GridView1.Items(index).FindControl("ltrelatedtype"), Literal)
                    Dim ltrelatedtypeid As Literal = DirectCast(GridView1.Items(index).FindControl("ltrelatedtypeid"), Literal)
                    ID = lbluId.Text
                    Activityclose.Uhactivity.Value = ID 'index ' GridView1.DataKeys(index).Value()
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

                Dim index As Integer = Convert.ToInt32(e.CommandArgument.ToString())
                'Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                'Dim row As GridViewRow = GridView1.Rows(index)
                Try
                    If deletestatus.Value = "yes" Then
                        Dim Activity_Id As Integer
                        Activity_Id = index ' GridView1.DataKeys(index).Value
                        ActivityBLL.ChangeToDSR(Activity_Id, Session("UserId"))
                        'fillLead("FillAllActivity")
                        hfSearchValue.Value = ""
                        hfType.Value = ""
                        BindNewGridview()
                        'For Each row1 As GridViewRow In GridView1.Rows
                        '    GridView1.HeaderRow.Cells(4).Visible = False
                        '    row1.Cells(4).Visible = False
                        '    GridView1.HeaderRow.Cells(3).Visible = False
                        '    row1.Cells(3).Visible = False
                        'Next
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
                Dim index As Integer = Convert.ToInt32(e.CommandArgument.ToString())
                'Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                'Dim row As GridViewRow = GridView1.Rows(index)
                Dim lbluId As Literal = DirectCast(GridView1.Items(index).FindControl("lbluId"), Literal)
                Dim ltrelatedtype As Literal = DirectCast(GridView1.Items(index).FindControl("ltrelatedtype"), Literal)
                Dim ltrelatedtypeid As Literal = DirectCast(GridView1.Items(index).FindControl("ltrelatedtypeid"), Literal)
                ID = lbluId.Text ' index 'GridView1.DataKeys(index).Value
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
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnAddDSR_Click(sender As Object, e As EventArgs) Handles btnAddDSR.Click
        Try
            Response.Redirect("~/dsr.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)), True)
            '"dsr.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(0))"
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Activity", "btntask_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnAddReminder_Click(sender As Object, e As EventArgs) Handles btnAddReminder.Click
        Try
            Response.Redirect("~/Reminder.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)), True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Activity", "btntask_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub rpgridview_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles GridView1.ItemDataBound
        Try
            If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then

                Dim data As DataRow = DirectCast(e.Item.DataItem, DataRowView).Row
                Dim lkedit As Label = DirectCast(e.Item.FindControl("lkedit"), Label)
                'Dim lkedit As HtmlAnchor = DirectCast(e.Item.FindControl("lkedit"), HtmlAnchor)
                Dim lnk As LinkButton = DirectCast(e.Item.FindControl("lnk"), LinkButton)
                Dim lnkChangeDSR As LinkButton = DirectCast(e.Item.FindControl("lnkChangeDSR"), LinkButton)
                Dim ActivityID As Long = data.Field(Of Long)("Id")
                Select Case data.Field(Of String)("ActivityType")
                    Case "Task"
                        'lkedit.NavigateUrl = Page.ResolveUrl("~/ActivityTask.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID)))
                        Dim activitistatus As String = data.Field(Of String)("Status")
                        If activitistatus = "Close" Then
                            lnk.Visible = False
                            lkedit.Visible = False
                        Else
                            lnk.Visible = True
                            lkedit.Visible = True
                        End If
                        Exit Select
                        '    'Added By MUBYN
                    Case "Reminder"
                        'lkedit.NavigateUrl = Page.ResolveUrl("~/Reminder.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID)))
                        Dim activitistatus As String = data.Field(Of String)("Status")
                        If activitistatus = "Close" Then
                            lnk.Visible = False
                            lkedit.Visible = False
                            lnkChangeDSR.Visible = False
                        Else
                            lnk.Visible = False
                            lkedit.Visible = True
                            lnkChangeDSR.Visible = True
                        End If
                        Exit Select
                    Case "Event"
                        'lkedit.NavigateUrl = Page.ResolveUrl("~/ActivityEvent.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID)))
                        Dim activitistatus As String = data.Field(Of String)("Status")
                        If activitistatus = "Close" Then
                            lnk.Visible = False
                            lkedit.Visible = False
                        Else
                            lnk.Visible = True
                            lkedit.Visible = True
                        End If
                        Exit Select
                    Case "Call"
                        'lkedit.NavigateUrl = Page.ResolveUrl("~/ActivityCall.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID)))
                        Dim activitistatus As String = data.Field(Of String)("Status")
                        If activitistatus = "Close" Then
                            lnk.Visible = False
                            lkedit.Visible = False
                        Else
                            lnk.Visible = True
                            lkedit.Visible = True
                        End If
                        Exit Select
                        '=============Modification By MUBYN ===========Start
                    Case "DSR"
                        'HyperLink1.NavigateUrl = Page.ResolveUrl("~/dsr.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)))
                        'lkedit.NavigateUrl = Page.ResolveUrl("~/dsr.aspx?returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)) + "&ID=" + HttpUtility.UrlEncode(Security.Encrypt(ActivityID)))
                        Dim activitistatus As String = data.Field(Of String)("Status")
                        If activitistatus = "Close" Then
                            lnk.Visible = False
                            lkedit.Visible = False
                        Else
                            lnk.Visible = True
                            lkedit.Visible = True
                        End If
                        Exit Select
                        '=============Modification By MUBYN ===========End

                End Select

                ' ''    Dim COUNTsTATUS As Integer = 0
                ' ''    ' Dim lnkRevision As LinkButton = DirectCast(e.Item.FindControl("lnkRevision"), LinkButton)
                ' ''    Dim lnkorder As LinkButton = DirectCast(e.Item.FindControl("lnkorder"), LinkButton)
                ' ''    Dim lbluId As Literal = DirectCast(e.Item.FindControl("lbluId"), Literal)
                ' ''    'Dim HyperLink2 As LinkButton = DirectCast(e.Item.FindControl("HyperLink2"), LinkButton)
                ' ''    Dim lblAccId As Literal = DirectCast(e.Item.FindControl("lblAccId"), Literal)
                ' ''    Dim vieworder As HtmlAnchor = DirectCast(e.Item.FindControl("vieworder"), HtmlAnchor)
                ' ''    'Dim lkedit As Label = DirectCast(e.Item.FindControl("lkedit"), Label)
                ' ''    'Dim lkedit As HtmlAnchor = DirectCast(e.Item.FindControl("lkedit"), HtmlAnchor)
                ' ''    Dim dtcheck As DataSet = QuotationBLL.Checkorderexist(lbluId.Text.Trim)
                ' ''    Dim checkcname As String = dtcheck.Tables(0).Rows(0)("checkname").ToString()

                ' ''    If (checkcname = "Already Exist") Then
                ' ''        lnkorder.Visible = False
                ' ''        ' ''lnkRevision.Visible = False
                ' ''        ' ''HyperLink2.Visible = False
                ' ''        lkedit.Visible = False
                ' ''        vieworder.Visible = True
                ' ''        ' If dtcheck.Tables(1).Rows.Count > 0 Then

                ' ''        vieworder.HRef = "EditSalesOrder.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(dtcheck.Tables(1).Rows(0)("Order_ID").ToString()))
                ' ''        'End If
                ' ''    Else
                ' ''        lnkorder.Visible = True
                ' ''        ' ''lnkRevision.Visible = True
                ' ''        ' ''HyperLink2.Visible = True
                ' ''        lkedit.Visible = True
                ' ''        vieworder.Visible = False

                ' ''        Dim dsItem As DataSet = ItemDetailBLL.FillItemDT("Quotation", Convert.ToInt32(lbluId.Text), Convert.ToInt32(lblAccId.Text))

                ' ''        Dim dtItem As New DataTable
                ' ''        dtItem = dsItem.Tables(0)
                ' ''        If dtItem.Rows.Count > 0 Then
                ' ''            Dim count As Integer = 0
                ' ''            For Each row In dtItem.Rows
                ' ''                Dim drItem As DataRow
                ' ''                drItem = dtItem.Rows(count)
                ' ''                Dim ds As DataSet = ItemDetailBLL.DiscountItemDetail("CheckStatus", Convert.ToInt32(lbluId.Text), Convert.ToInt32(drItem("ItemDt_ID").ToString()), Convert.ToInt32(lblAccId.Text))
                ' ''                count = count + 1
                ' ''                Dim dt As New DataTable
                ' ''                dt = ds.Tables(0)
                ' ''                Dim dr As DataRow
                ' ''                dr = dt.Rows(0)
                ' ''                If (dr("status").ToString() = "Active") Then
                ' ''                    COUNTsTATUS = COUNTsTATUS + 1
                ' ''                End If

                ' ''            Next
                ' ''            ' ''lnkRevision.Visible = IIf(COUNTsTATUS > 0, True, False)
                ' ''            If COUNTsTATUS > 0 Then
                ' ''                ' HyperLink2.Visible = False

                ' ''            End If
                ' ''        End If
                ' ''    End If
                ' ''    If dtcheck.Tables(2).Rows.Count > 0 Then

                ' ''        ' ''lnkRevision.Visible = False
                ' ''        ' ''HyperLink2.Visible = False
                ' ''        lkedit.Visible = False
                ' ''    End If
            End If
            If e.Item.ItemType = DataControlCellType.DataCell Then

            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ddtasktype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddtasktype.SelectedIndexChanged
        Try
            'txtsearch.Text = ""
            If ddtasktype.SelectedValue = "Reminder" Then        '-------Added By MUBYN
                fillLead("FillReminderActivity")
                hfSearchValue.Value = ""
                hfType.Value = "Reminder"
            ElseIf ddtasktype.SelectedValue = "DSR" Then       '-------Added By MUBYN
                fillLead("FillDSRActivity")
                hfSearchValue.Value = ""
                hfType.Value = "DSR"
            ElseIf ddtasktype.SelectedValue = "Missed" Then       '-------Added By MUBYN 
                fillLead("FillMissedActivity")
                hfSearchValue.Value = "Missed"
                hfType.Value = ""
                'GridView1.DataSource = ActivityBLL.SearchAllActivity("SearchMissedActivity", Session("UserId"), "Missed")
                'GridView1.DataBind()
            ElseIf ddtasktype.SelectedValue = "All Activities" Then
                fillLead("FillAllActivity")
                hfSearchValue.Value = ""
                hfType.Value = ""
            End If
            BindNewGridview()
            'For Each row As GridViewRow In GridView1.Rows
            '    GridView1.HeaderRow.Cells(4).Visible = False
            '    row.Cells(4).Visible = False
            '    GridView1.HeaderRow.Cells(3).Visible = False
            '    row.Cells(3).Visible = False
            'Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Activity", "ddtasktype_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            BindNewGridview()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub BindNewGridview()
        Try
            Dim WhereClause As String = ""
            ' ''If txtRelatedType.Text <> "" Then
            ' ''    WhereClause = WhereClause + " and ( RelatedType LIKE '%' + '" + txtRelatedType.Text.Trim + "' + '%' ) "
            ' ''End If
            If ddlrelatedtype.SelectedValue <> "Select" Then
                WhereClause = WhereClause + " and ( RelatedType = '" + ddlrelatedtype.SelectedValue + "' ) "
            End If
            If txtNameColumn.Text <> "" Then
                WhereClause = WhereClause + " And ( Name LIKE '%' + '" + txtNameColumn.Text.Trim.Trim.Replace("'", "''") + "' + '%' ) "
            End If
            ' ''If txtSubject.Text <> "" Then
            ' ''    WhereClause = WhereClause + " and ( Subject LIKE '%' + '" + txtSubject.Text.Trim + "' + '%' ) "
            ' ''End If
            If ddlSubject.SelectedValue <> "Select" Then
                WhereClause = WhereClause + " and ( Subject = '" + ddlSubject.SelectedValue + "'  ) "
            End If
            ' ''If txtActivityType.Text <> "" Then
            ' ''    WhereClause = WhereClause + "  and ( ActivityType LIKE '%' + '" + txtActivityType.Text.Trim + "' + '%' )  "
            ' ''End If
            If ddlActivityType.SelectedValue <> "Select" Then
                WhereClause = WhereClause + "  and ( ActivityType = '" + ddlActivityType.SelectedValue + "' )  "
            End If
            ' ''If txtFrom.Text <> "" Then
            ' ''    WhereClause = WhereClause + "  and ( From1 LIKE '%' + '" + txtFrom.Text.Trim + "' + '%' )  "
            ' ''End If
            If txtFrom.Text <> "" Then
                WhereClause = WhereClause + "  and ( convert(date,From1,111) = '" + txtFrom.Text.Trim + "' )  "
            End If

            ' ''If txtTo.Text <> "" Then
            ' ''    WhereClause = WhereClause + "  and ( To1 LIKE '%' + '" + txtTo.Text.Trim + "' + '%' )  "
            ' ''End If
            If txtTo.Text <> "" Then
                WhereClause = WhereClause + "  and ( convert(date,To1,111) = '" + txtTo.Text.Trim + "'  )  "
            End If
            ' ''If txtPriority.Text <> "" Then
            ' ''    WhereClause = WhereClause + "  and ( Priority LIKE '%' + '" + txtPriority.Text.Trim + "' + '%' )  "
            ' ''End If
            If ddpriority.SelectedValue <> "Select" Then
                WhereClause = WhereClause + "  and ( Priority = '" + ddpriority.SelectedValue + "' )  "
            End If
            ' ''If txtStatus.Text <> "" Then
            ' ''    WhereClause = WhereClause + "  and ( Status LIKE '%' + '" + txtStatus.Text.Trim + "' + '%' )  "
            ' ''End If
            If ddlStatus.SelectedValue <> "Select" Then
                WhereClause = WhereClause + "  and ( Status = '" + ddlStatus.SelectedValue + "'  )  "
            End If
            If txtAssignTo.Text <> "" Then
                WhereClause = WhereClause + "  and ( AssignTo LIKE '%' + '" + txtAssignTo.Text.Trim + "' + '%' )  "
            End If
            If txtActDescription.Text <> "" Then
                WhereClause = WhereClause + "  and ( Activity_Description LIKE '%' + '" + txtActDescription.Text.Trim + "' + '%' )  "
            End If
            'If txtRelatedType.Text <> "" Or txtNameColumn.Text <> "" Or txtSubject.Text <> "" Or txtActivityType.Text <> "" Or txtFrom.Text <> "" Or txtTo.Text <> "" Or txtPriority.Text <> "" Or txtStatus.Text <> "" Or txtAssignTo.Text <> "" Or txtActDescription.Text <> "" Then
            '    ds1 = MainBLL.FillActivityFilter("FillAllActivityCRM", Session("UserId"), hfSearchValue.Value, hfType.Value, txtRelatedType.Text.Trim, txtNameColumn.Text.Trim,
            '                                     txtSubject.Text.Trim, txtActivityType.Text.Trim, txtFrom.Text.Trim, txtTo.Text.Trim, txtPriority.Text.Trim, txtStatus.Text.Trim, txtAssignTo.Text.Trim, txtActDescription.Text.Trim)
            'End If
            If WhereClause <> "" Then
                ds1 = FilterBLL.FillNewFilter("AllActivityCRMFiltM", Session("UserId"), WhereClause)
            End If
            If ds1.Tables.Count > 0 Then
                If ds1.Tables(0).Rows.Count > 0 Then
                    dt1 = ds1.Tables(0)
                    divMain.Visible = True
                Else
                    divMain.Visible = False
                End If
                PageNumber = 0
                dt3 = dt1
                Session("dt1ActNew") = dt1

                fillpage()
            Else
                divMain.Visible = False
            End If
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Binding Account'" + ex.Message + ")", True)
        End Try
    End Sub
    Sub AtLeastOneField_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        If txtRelatedType.Text & txtNameColumn.Text & txtSubject.Text & txtActivityType.Text & txtFrom.Text & txtTo.Text & txtPriority.Text & txtStatus.Text & txtAssignTo.Text & txtActDescription.Text <> "" Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

    Protected Sub BindLoad()
        Try
            Dim WhereClause As String = ""
            WhereClause = WhereClause + "  and	( convert(date, Activity_CreatedDate,105) >= '" + Date.Now.AddDays(-7).Date.ToString("yyyy-MM-dd") + "'  )  "

            If WhereClause <> "" Then
                ds1 = FilterBLL.FillNewFilter("AllActivityCRMFiltM", Session("UserId"), WhereClause)
            End If
            If ds1.Tables.Count > 0 Then
                If ds1.Tables(0).Rows.Count > 0 Then
                    dt1 = ds1.Tables(0)
                    divMain.Visible = True
                Else
                    divMain.Visible = False
                End If
                PageNumber = 0
                dt3 = dt1
                Session("dt1ActNew") = dt1

                fillpage()
            Else
                divMain.Visible = False
            End If
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Binding Account'" + ex.Message + ")", True)
        End Try
    End Sub
    'Protected Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click
    '    Try
    '        ddlrelatedtype.SelectedValue = "Select"
    '        txtNameColumn.Text = ""
    '        ddlSubject.SelectedValue = "Select"
    '        ddlActivityType.SelectedValue = "Select"
    '        txtFrom.Text = ""
    '        txtTo.Text = ""
    '        ddpriority.SelectedValue = "Select"
    '        ddlStatus.SelectedValue = "Select"
    '        txtAssignTo.Text = ""
    '        txtActDescription.Text = ""
    '    Catch ex As Exception

    '    End Try
    'End Sub
End Class
