Imports System.Drawing

Partial Class Prospect
    Inherits _PageBaseClass
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
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
        If Session("UserRoleID") = "4" Then
            Response.Redirect("SupportDashBoard.aspx")
        End If
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        hlnkAdd.NavigateUrl = Page.ResolveUrl("ModifyProspect.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")
        If Not IsPostBack Then

            If Request.QueryString("Type") = Nothing Then
                Response.Redirect("ProspectNew.aspx")
            ElseIf Request.QueryString("Type") = "All" Then
                Hfgridview.Value = "ProspectGVByAssignCRM"
                hfExcel.Value = "ExcelAccountByAssign"
                BindGridview()
            Else
                If Request.QueryString("Type").ToString = "gktdf" Then
                    Hfgridview.Value = "ProspectGVByAchivedCRM"
                    hfExcel.Value = "ExcelProspectByAchived"
                    BindGridview()
                Else
                    Hfgridview.Value = "ProspectWithNoActivityCRM"
                    hfExcel.Value = "ExcelProspectWithNoActivity"
                    BindGridview()
                End If
            End If
            CheckPrivilage()
            'BindGridview()
            txtSearch.Attributes.Add("onkeyup", [String].Format("javascript:__doPostBack('{0}','')", rpg.ClientID))
            'TextBox1.Attributes.Add("onkeyup", [String].Format("javascript:__doPostBack('{0}','')", rpg.ClientID))
            'TextBox2.Attributes.Add("onkeyup", [String].Format("javascript:__doPostBack('{0}','')", rpg.ClientID))
            'TextBox3.Attributes.Add("onkeyup", [String].Format("javascript:__doPostBack('{0}','')", rpg.ClientID))
            'TextBox4.Attributes.Add("onkeyup", [String].Format("javascript:__doPostBack('{0}','')", rpg.ClientID))
            'TextBox5.Attributes.Add("onkeyup", [String].Format("javascript:__doPostBack('{0}','')", rpg.ClientID))
            'TextBox6.Attributes.Add("onkeyup", [String].Format("javascript:__doPostBack('{0}','')", rpg.ClientID))
            'TextBox7.Attributes.Add("onkeyup", [String].Format("javascript:__doPostBack('{0}','')", rpg.ClientID))
            'TextBox8.Attributes.Add("onkeyup", [String].Format("javascript:__doPostBack('{0}','')", rpg.ClientID))
            'TextBox9.Attributes.Add("onkeyup", [String].Format("javascript:__doPostBack('{0}','')", rpg.ClientID))
            'TextBox10.Attributes.Add("onkeyup", [String].Format("javascript:__doPostBack('{0}','')", rpg.ClientID))
            If Session("UserRoleID") = 1 Then
                btnExport.Visible = True
            Else
                btnExport.Visible = False
            End If
        End If

    End Sub

    Protected Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        If IsPostBack Then
            If txtSearch.Text <> "" OrElse hfBackcount.Value = "1" Then
                'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" OrElse hfBackcount.Value = "1" Then
                getsearch()
                fillpage()
            Else
                fillpage()
            End If
        End If
    End Sub


    Protected Sub BindGridview()
        Try
            ds1 = MainBLL.FillGridByID(Hfgridview.Value, Session("UserId"))
            'ds1 = MainBLL.FillGridView(hfgridview.Value)
            If ds1.Tables(0).Rows.Count > 0 Then
                dt1 = ds1.Tables(0)
                'rpgridview.DataSource = dt1
                'rpgridview.DataBind()
            End If
            dt3 = dt1
            Session("dt1P") = dt1

            fillpage()
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Binding Account'" + ex.Message + ")", True)
        End Try
    End Sub
    Public Sub fillpage()
        Dim dt As New DataTable()
        If txtSearch.Text <> "" Then
            'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" Then
            dt = DirectCast(Session("dt2P"), DataTable)
        Else

            dt = DirectCast(Session("dt1P"), DataTable)
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


    Public Sub getsearch()
        Try
            'date time column not working in search and footer
            dt2 = DirectCast(Session("dt1P"), DataTable)

            If txtSearch.Text <> "" Then
                Dim selectedTable1 As DataTable = dt2.AsEnumerable().Where(Function(r) (r.Field(Of String)("Acc_Name").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                            (r.Field(Of String)("Contact_ContactPerson").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                            (r.Field(Of String)("Contact_Landline").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                            (r.Field(Of String)("Contact_Email").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                            (r.Field(Of String)("city").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                            (r.Field(Of String)("Contact_Mobile").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                            (r.Field(Of String)("AssignTo").ToUpper().Contains(txtSearch.Text.ToUpper()))
                                ).CopyToDataTable()

                Session("dt2P") = selectedTable1
                '(r.Field(Of String)("city").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                '(r.Field(Of String)("U_FirstName").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                '(r.Field(Of String)("Acc_OpenFrom").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                'Else
                '    Dim selectedTable1 As DataTable = dt2.AsEnumerable().Where(Function(r) (r.Field(Of String)("Acc_Name").ToUpper().Contains(TextBox1.Text.ToUpper())) AndAlso
                '               (r.Field(Of String)("Contact_ContactPerson").ToUpper().Contains(TextBox2.Text.ToUpper())) AndAlso
                '                (r.Field(Of String)("Contact_Landline").ToUpper().Contains(TextBox3.Text.ToUpper())) AndAlso
                '                 (r.Field(Of String)("Contact_Email").ToUpper().Contains(TextBox4.Text.ToUpper())) AndAlso
                '    (r.Field(Of String)("Contact_Mobile").ToUpper().Contains(TextBox5.Text.ToUpper())) AndAlso
                '    (r.Field(Of String)("city").ToUpper().Contains(TextBox6.Text.ToUpper())) AndAlso
                '    (r.Field(Of String)("AssignTo").ToUpper().Contains(TextBox7.Text.ToUpper())) AndAlso
                '    (r.Field(Of String)("Acc_OpenFrom").ToUpper().Contains(TextBox8.Text.ToUpper()))
                '               ).CopyToDataTable()

                '    Session("dt2P") = selectedTable1



            End If
        Catch ex As Exception
            '  Session["dt2"] = "1";
            Dim exception As New DataTable()
            exception.Clear()

            Session("dt2P") = exception
        End Try
    End Sub
    Protected Sub Sorting(sender As Object, e As EventArgs)
        Try
            Dim Header As LinkButton = DirectCast(sender, LinkButton)

            If Not Session("dt1P") Is Nothing Then
                Dim dt As DataTable = Session("dt1P")
                If ViewState("SortDir") Is Nothing Or ViewState("SortDir") = "Asc" Then
                    dt.DefaultView.Sort = Header.ID
                    dt = dt.DefaultView.ToTable()
                    ViewState("SortDir") = "Desc"
                Else
                    dt.DefaultView.Sort = Header.ID & " DESC"
                    dt = dt.DefaultView.ToTable()
                    ViewState("SortDir") = "Asc"
                End If
                Session("dt1P") = dt
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

    Protected Sub rpgridview_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rpgridview.ItemCommand
        Try
            If e.CommandName = "Delete" Then
                If deletestatus.Value = "yes" Then
                    Dim uid As Integer = Convert.ToInt32(e.CommandArgument.ToString())

                    Try
                        ' MainBLL.DeleteSI(MainId, Session("UserID"), "LeadDeleteSi", Session("Audlog_Id"))
                        BindGridview()
                    Catch ex As Exception
                        Dim error1 As String = ex.Message.Replace(Chr(34), "")
                        error1 = error1.Replace(Chr(39), "")

                        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                    End Try
                End If

            End If

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Deleting Class')", True)
        End Try
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try

            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=Prospect-List.xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            Dim Gridview2 As New GridView

            Dim dt As New DataTable()
            'dt = MainBLL.SearchGridViewByID(txtSearch.Text.Trim, Session("UserId"), hfExcel.Value)
            'dt = MainBLL.FillGridByID(Hfgridview.Value, Session("UserId"))
            'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" Then
            If txtSearch.Text <> "" Then
                dt = DirectCast(Session("dt2P"), DataTable)
            Else
                dt = DirectCast(Session("dt1P"), DataTable)
            End If

            Dim dtExc As DataTable = dt
            dtExc.Columns.Remove("Acc_Id")
            ''dtExc.Columns.Remove("Contact_ContactPerson")***
            'dtExc.Columns.Remove("Contact_Landline")
            dtExc.Columns.Remove("U_FirstName")
            dtExc.Columns.Remove("U_ID")
            dtExc.Columns.Remove("Acc_OpenFrom")
            dtExc.Columns("Acc_Name").ColumnName = "Company Name"
            dtExc.Columns("Contact_ContactPerson").ColumnName = "Contact Person"
            dtExc.Columns("Contact_Email").ColumnName = "Email"
            dtExc.Columns("Contact_Landline").ColumnName = "Phone"
            dtExc.Columns("Contact_Mobile").ColumnName = "Mobile"
            'dtExc.Columns("Contact_Email").ColumnName = "Email"
            'dtExc.Columns("city").ColumnName = "City"

            Gridview2.DataSource = dtExc
            'Gridview2.DataBind()
            Gridview2.AllowPaging = False
            Gridview2.DataBind()
            Gridview2.RenderControl(hw)
            BindGridview()
            'style to format numbers to string
            Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
            Response.Write(style)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.End()
            ' ''Dim html2 As String = Regex.Replace(sw.ToString(), "(<img\/?[^>]+>)", "", RegexOptions.IgnoreCase)
            '' ''html2 = Regex.Replace(html2, "(<input class=""checkbox""\/?[^>]+>)", "", RegexOptions.IgnoreCase)
            ' ''html2 = Regex.Replace(html2, "(<a \/?[^>]+>)", "", RegexOptions.IgnoreCase)
            ' ''html2 = Regex.Replace(html2, "(<i \/?[^>]+>)", "(INR)", RegexOptions.IgnoreCase)
            ' ''Response.Write(html2.ToString())
            ' ''Response.Flush()
            ' ''Response.End()

            'DoValidate.closeConn(_conn)

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Prospect", "btnExport_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub CheckPrivilage()
        Try
            Dim dt As DataSet = PrivilageBLL.CheckPrivilige(Session("UserRoleID"), "Prospect.aspx")
            Dim dtprivilage As New DataTable
            dtprivilage = dt.Tables(0)
            Dim drprivilage As DataRow
            If dtprivilage.Rows.Count = 0 Then
                hlnkAdd.Visible = False
                thEdit.Visible = False
                For i As Integer = 0 To rpgridview.Items.Count - 1
                    Dim tdEdit As HtmlTableCell = DirectCast(rpgridview.Items(i).FindControl("tdEdit"), HtmlTableCell)
                    tdEdit.Visible = False
                Next
                ' ''SearchControl.Uhfadd.Visible = False
                ' ''GridView1.Columns(0).Visible = False
                ' ''SearchControl.ULkadd.Visible = False

            Else

                drprivilage = dtprivilage.Rows(0)
                If (drprivilage("Prvg_RAdd").ToString()) = True Then
                    hlnkAdd.Visible = True
                    ' ''SearchControl.Uhfadd.Visible = True
                Else
                    hlnkAdd.Visible = False
                    ' ''SearchControl.Uhfadd.Visible = False
                End If
                If (drprivilage("Prvg_RUpdate").ToString()) = True Then
                    ' ''GridView1.Columns(0).Visible = True
                Else
                    thEdit.Visible = False
                    For i As Integer = 0 To rpgridview.Items.Count - 1
                        Dim tdEdit As HtmlTableCell = DirectCast(rpgridview.Items(i).FindControl("tdEdit"), HtmlTableCell)
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

End Class
