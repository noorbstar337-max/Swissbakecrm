
Partial Class Trial
    Inherits System.Web.UI.Page
    Private InvoiceId As Integer
    Public tabss As Integer
    Private maxPage As Integer
    Private minPage As Integer
    Public p1 As String
    Public p2 As String
    Public p3 As String
    Public ds1 As DataSet
    Private dt1 As New DataTable()
    Private dt2 As New DataTable()
    Private dt3 As New DataTable()
    Private pgitems As New PagedDataSource()
    Private s As New Security()
    Public count As Integer

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("LMSUserId") = Nothing Then
            TryCast(Me.Master, LMSMasterPage).MaintainSession()
        End If
    End Sub
    Protected Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        If txtSearch.Text <> "" OrElse hfBackcount.Value = "1" Then
            getsearch()
            fillpage()
        End If
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                FillTrial()
                ' CheckPrivilage()
                txtSearch.Attributes.Add("onkeyup", [String].Format("javascript:__doPostBack('{0}','')", rpg.ClientID))
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillTrial()
        Try
            ds1 = LMSBLL.Fillgridwitid("FillTrial", Session("LMSUserId"), "Trial")
            'ds1 = LMSBLL.FillRepeater("FillTrial")
            dt1 = ds1.Tables(0)
            'rpgridview.DataSource = dt1
            ' rpgridview.DataBind()
            Session("SessionTrial") = dt1
            dt3 = dt1
            fillpage()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub rptrial_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptrial.ItemCommand
        Try
            If e.CommandName = "edit" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                'Response.Redirect("LabManagement.aspx?view=FormulationView" + "&id=" + Security.Encrypt(HttpUtility.UrlEncode(index)))
                Response.Redirect("ModifyFeedback.aspx?chk=e&ID=" + HttpUtility.UrlEncode(Security.Encrypt(index)) + "&returnurl=y")

            ElseIf e.CommandName = "view" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Response.Redirect("ModifyFeedback.aspx?chk=v&ID=" + HttpUtility.UrlEncode(Security.Encrypt(index)) + "&returnurl=y")
                'Response.Redirect("Modify_Customer.aspx?chk=v&Customer_Id=" + HttpUtility.UrlEncode(Security.Encrypt(index)))

            ElseIf e.CommandName = "delete" Then
                If deletestatus.Value = "yes" Then
                    Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                    Try
                        LMSBLL.DeleteRecipe(index, Session("LMSUserId"), "DeleteTrial")
                        FillTrial()
                    Catch ex As Exception
                        ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Updating Status')", True)
                    End Try
                End If

            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub Text_TextChanged(sender As Object, e As EventArgs)
        PageNumber = 0
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
    Protected Sub Sorting(sender As Object, e As EventArgs)
        Try
            Dim Header As LinkButton = DirectCast(sender, LinkButton)

            If Not Session("SessionTrial") Is Nothing Then
                Dim dt As DataTable = Session("SessionTrial")
                If ViewState("SortDir") Is Nothing Or ViewState("SortDir") = "Asc" Then
                    dt.DefaultView.Sort = Header.ID
                    dt = dt.DefaultView.ToTable()
                    ViewState("SortDir") = "Desc"
                Else
                    dt.DefaultView.Sort = Header.ID & " DESC"
                    dt = dt.DefaultView.ToTable()
                    ViewState("SortDir") = "Asc"
                End If
                Session("SessionTrial") = dt
                fillpage()

            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub fillpage()
        Try

            Dim dt As New DataTable()
            'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" Then
            If txtSearch.Text <> "" Then
                dt = DirectCast(Session("SessionTrial2"), DataTable)
            Else

                dt = DirectCast(Session("SessionTrial"), DataTable)
            End If
            'If dt.Rows.Count = 0 Then
            '    Dim FooterTemplate As Control = rpgridview.Controls(rpgridview.Controls.Count - 1).Controls(0)
            '    FooterTemplate.FindControl("trEmpty").Visible = True
            'Else
            If dt.Rows.Count = 0 Then
                pgitems.DataSource = dt.DefaultView
                rptrial.DataSource = pgitems
                rptrial.DataBind()
                Dim FooterTemplate As Control = rptrial.Controls(rptrial.Controls.Count - 1).Controls(0)
                FooterTemplate.FindControl("trEmpty").Visible = True
                PopulatePager(0, 1)
                ' pgitems.AllowPaging = false ;

                lblTcount.Visible = False
            Else
                pgitems.DataSource = dt.DefaultView
                pgitems.AllowPaging = True
                lblTcount.Visible = True
                count = dt.Rows.Count
                If count > 1 Then
                    lblTcount.Text = count.ToString() + " " + " records"
                Else
                    lblTcount.Text = count.ToString() + " " + " record"
                End If

                pgitems.PageSize = Convert.ToInt32(ddpagesize.SelectedValue)
                PopulatePager(pgitems.PageCount, PageNumber)
                pgitems.CurrentPageIndex = PageNumber

                tabss = PageNumber + 1
                tab.Value = tabss.ToString()

                rptrial.DataSource = pgitems
                rptrial.DataBind()
            End If
            'End If
            CheckPrivilage()

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub PopulatePager(recordCount As Integer, currentPage As Integer)
        Try
            ' int drcount = Convert.ToInt32(lblTcount.Text.Trim("records");
            If count > 10 Then
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
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub CheckPrivilage()
        Try
            Dim dt As DataSet = LMSPrivilegeBLL.CheckLMSPrivilege(Session("LMSUserId"), "Formulation.aspx")
            Dim dtprivilage As New DataTable
            dtprivilage = dt.Tables(0)
            Dim drprivilage As DataRow
            If dtprivilage.Rows.Count = 0 Then
                For Each Item In rptrial.Items
                    Dim tdview As HtmlTableCell = DirectCast(Item.FindControl("tdview"), HtmlTableCell)
                    tdview.Visible = False
                    Dim tdedit As HtmlTableCell = DirectCast(Item.FindControl("tdedit"), HtmlTableCell)
                    tdedit.Visible = False
                    Dim tddelete As HtmlTableCell = DirectCast(Item.FindControl("tddelete"), HtmlTableCell)
                    tddelete.Visible = False
                Next
                thview.Visible = False
                thEdit.Visible = False
                thDelete.Visible = False
                'rptrial.Items(0).Visible = False
                'rptrial.Items(1).Visible = False
                'rptrial.Items(2).Visible = False
            Else
                drprivilage = dtprivilage.Rows(0)
                If (drprivilage("Prvg_RAdd").ToString()) = True Then

                Else

                End If
                If (drprivilage("Prvg_RUpdate").ToString()) = True Then
                    For Each Item In rptrial.Items
                        Dim tdedit As HtmlTableCell = DirectCast(Item.FindControl("tdedit"), HtmlTableCell)
                        tdedit.Visible = True
                    Next
                    thEdit.Visible = True
                Else
                    For Each Item In rptrial.Items
                        Dim tdedit As HtmlTableCell = DirectCast(Item.FindControl("tdedit"), HtmlTableCell)
                        tdedit.Visible = False
                    Next
                    thEdit.Visible = False
                End If
                If (drprivilage("Prvg_RDelete").ToString()) = True Then
                    For Each Item In rptrial.Items
                        Dim tddelete As HtmlTableCell = DirectCast(Item.FindControl("tddelete"), HtmlTableCell)
                        tddelete.Visible = False
                    Next
                    thDelete.Visible = False
                Else
                    For Each Item In rptrial.Items
                        Dim tddelete As HtmlTableCell = DirectCast(Item.FindControl("tddelete"), HtmlTableCell)
                        tddelete.Visible = False
                    Next
                    thDelete.Visible = False
                End If
                If (drprivilage("Prvg_Rview").ToString()) = True Then
                    For Each Item In rptrial.Items
                        Dim tdview As HtmlTableCell = DirectCast(Item.FindControl("tdview"), HtmlTableCell)
                        tdview.Visible = True
                    Next
                    thview.Visible = True
                Else
                    For Each Item In rptrial.Items
                        Dim tdview As HtmlTableCell = DirectCast(Item.FindControl("tdview"), HtmlTableCell)
                        tdview.Visible = False
                    Next
                    thview.Visible = False
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
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
    Protected Sub rptPaging_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        'If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
        '    Dim scriptMan As ScriptManager = ScriptManager.GetCurrent(Me)
        '    Dim btn As LinkButton = TryCast(e.Item.FindControl("btnPage"), LinkButton)
        '    If btn IsNot Nothing Then
        '        'btn.Click += LinkButton1_Click
        '        scriptMan.RegisterAsyncPostBackControl(btn)
        '    End If
        'End If

        Try
            Dim linkButton As LinkButton = DirectCast(e.Item.FindControl("btnPage"), LinkButton)

            If linkButton Is Nothing Then
            Else
                Dim scriptManager__1 = ScriptManager.GetCurrent(Me.Page)
                If scriptManager__1 IsNot Nothing Then
                    scriptManager__1.RegisterAsyncPostBackControl(linkButton)
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub getsearch()
        Try

            'date time column not working in search and footer
            dt2 = DirectCast(Session("SessionTrial"), DataTable)


            If txtSearch.Text <> "" Then
                Dim selectedTable1 As DataTable = dt2.AsEnumerable().Where(Function(r) (r.Field(Of String)("Trial_No").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                           (r.Field(Of String)("AssignTo").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                           (r.Field(Of String)("Trial_CreatedDate").ToUpper().Contains(txtSearch.Text.ToUpper()))
                           ).CopyToDataTable()

                Session("SessionTrial2") = selectedTable1
            Else
                'Dim selectedTable1 As DataTable = dt2.AsEnumerable().Where(Function(r) (r.Field(Of String)("Invoice_number").ToUpper().Contains(TextBox1.Text.ToUpper())) AndAlso
                '           (r.Field(Of String)("Invoice_Date").ToUpper().Contains(TextBox2.Text.ToUpper())) AndAlso
                '           (r.Field(Of String)("Student_Name").ToUpper().Contains(TextBox3.Text.ToUpper())) AndAlso
                '         (r.Field(Of String)("Amount1").ToUpper().Contains(TextBox4.Text.ToUpper())) AndAlso
                '(r.Field(Of String)("Invoice_Status").ToUpper().Contains(TextBox5.Text.ToUpper()))
                '           ).CopyToDataTable()

                'Session("dtO2") = selectedTable1

                fillpage()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub ddpagesize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddpagesize.SelectedIndexChanged
        Try
            fillpage()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class
