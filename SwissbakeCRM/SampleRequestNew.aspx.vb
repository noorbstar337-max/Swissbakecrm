Imports System.Drawing

Partial Class SampleRequestNew
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
    Public SessId As Integer

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        hlnkAdd.NavigateUrl = Page.ResolveUrl("ModifySampleRequest.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)))
        SessId = Session("UserId")
        If Not IsPostBack Then

            Hfgridview.Value = "SampleGridviewByAssignNew"
            hfExcel.Value = "SampleViewSearchByAssign"
            'BindGridview()
            BindLoad()
            CheckPrivilage()
            'BindGridview()
            'txtSearch.Attributes.Add("onkeyup", [String].Format("javascript:__doPostBack('{0}','')", rpg.ClientID))
            
            ' ''If Session("UserRoleID") = 1 Then
            ' ''    btnExport.Visible = True
            ' ''Else
            ' ''    btnExport.Visible = False
            ' ''End If
        End If
        'If Session("UserId") = Nothing Then

        'Else

        'End If

    End Sub

    Protected Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        If IsPostBack Then
            'If txtSearch.Text <> "" OrElse hfBackcount.Value = "1" Then
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
            ds1 = MainBLL.FillGridByID(Hfgridview.Value, SessId)
            'ds1 = MainBLL.FillGridView(hfgridview.Value)
            If ds1.Tables(0).Rows.Count > 0 Then
                dt1 = ds1.Tables(0)
                'rpgridview.DataSource = dt1
                'rpgridview.DataBind()
            End If
            dt3 = dt1
            Session("dt1SamReqNew") = dt1

            fillpage()
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Binding Account'" + ex.Message + ")", True)
        End Try
    End Sub
    Public Sub fillpage()
        Dim dt As New DataTable()
        'If txtSearch.Text <> "" Then
        '    'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" Then
        '    dt = DirectCast(Session("dt2SamReqNew"), DataTable)
        'Else

        dt = DirectCast(Session("dt1SamReqNew"), DataTable)
        'End If
        'If dt.Rows.Count = 0 Then
        '    Dim FooterTemplate As Control = rpgridview.Controls(rpgridview.Controls.Count - 1).Controls(0)
        '    FooterTemplate.FindControl("trEmpty").Visible = True
        'Else
        If dt IsNot Nothing Then
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
    '        dt2 = DirectCast(Session("dt1SamReqNew"), DataTable)


    '        If txtSearch.Text <> "" Then
    '            Dim selectedTable1 As DataTable = dt2.AsEnumerable().Where(Function(r) (r.Field(Of String)("SampleRequest_No").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
    '                       (r.Field(Of String)("SampleRequest_Date").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
    '                        (r.Field(Of String)("CompanyName").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
    '                         (r.Field(Of Decimal)("ContactName").ToString().Contains(txtSearch.Text.ToUpper())) OrElse
    '            (r.Field(Of String)("qty").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
    '            (r.Field(Of String)("AssignTo").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
    '            (r.Field(Of String)("SampleRequest_SampleStatus").ToUpper().Contains(txtSearch.Text.ToUpper()))
    '                            ).CopyToDataTable()

    '            Session("dt2SamReqNew") = selectedTable1
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

    '            '    Session("dt2SamReqNew") = selectedTable1



    '        End If
    '    Catch ex As Exception
    '        '  Session["dt2SO"] = "1";
    '        Dim exception As New DataTable()
    '        exception.Clear()

    '        Session("dt2SamReqNew") = exception
    '    End Try
    'End Sub
    Protected Sub Sorting(sender As Object, e As EventArgs)
        Try
            Dim Header As LinkButton = DirectCast(sender, LinkButton)

            If Not Session("dt1SamReqNew") Is Nothing Then
                Dim dt As DataTable = Session("dt1SamReqNew")
                If ViewState("SortDir") Is Nothing Or ViewState("SortDir") = "Asc" Then
                    dt.DefaultView.Sort = Header.ID
                    dt = dt.DefaultView.ToTable()
                    ViewState("SortDir") = "Desc"
                Else
                    dt.DefaultView.Sort = Header.ID & " DESC"
                    dt = dt.DefaultView.ToTable()
                    ViewState("SortDir") = "Asc"
                End If
                Session("dt1SamReqNew") = dt
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
                        Dim msg As String = SampleBLL.DeleteSI(uid, SessId, "SampleDeleteSi", Session("Audlog_Id"))
                        If Not String.IsNullOrEmpty(msg) Then
                            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + msg + "')", True)
                        End If
                        BindNewGridview()
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
            Response.AddHeader("content-disposition", "attachment;filename=SampleRequest.xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            Dim Gridview2 As New GridView

            Dim dt As New DataTable()
            'dt = MainBLL.FillGridByID(Hfgridview.Value, SessId)
            'dt = MainBLL.SearchGridViewByID(txtSearch.Text.Trim, Session("UserId"), hfExcel.Value)
            'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" Then
            'If txtSearch.Text <> "" Then
            '    dt = DirectCast(Session("dt2SamReqNew"), DataTable)
            'Else
            dt = DirectCast(Session("dt1SamReqNew"), DataTable)
            'End If

            Dim dtExc As DataTable = dt
            'dtExc.Columns.Remove("Order_ID")
            'dtExc.Columns.Remove("Acc_id")
            'dtExc.Columns.Remove("Order_Del")
            ''dtExc.Columns.Remove("Order_type")
            'dtExc.Columns.Remove("Class")
            'dtExc.Columns.Remove("Order_Status")
            'dtExc.Columns.Remove("OrderCreated")
            'dtExc.Columns.Remove("invCount")
            ' ''dtExc.Columns.Remove("RowNumber")*******
            ''dtExc.Columns("Acc_Name").ColumnName = "Account Name"
            'dtExc.Columns("Order_Code").ColumnName = "Order Code"
            'dtExc.Columns("Order_CreatedDate").ColumnName = "Order Date"
            'dtExc.Columns("Acc_Name").ColumnName = "Customer Name"
            'dtExc.Columns("Order_OrderStatus").ColumnName = "Order Status"
            'dtExc.Columns("city").ColumnName = "City"
            'dtExc.Columns("Order_type").ColumnName = "From"
            'dtExc.Columns("AccountOwner").ColumnName = "Customer Owner"
            'dtExc.Columns("AccCreatedBy").ColumnName = "Customer Created By"
            'dtExc.Columns("Customer Name").SetOrdinal(2)
            'dtExc.Columns("City").SetOrdinal(4)
            'dtExc.Columns("Customer Owner").SetOrdinal(6)
            'dtExc.Columns("From").SetOrdinal(9)

            Gridview2.DataSource = dtExc
            'Gridview2.DataBind()
            Gridview2.AllowPaging = False
            Gridview2.DataBind()
            Gridview2.RenderControl(hw)
            BindNewGridview()

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

        End Try
    End Sub

    Public Sub CheckPrivilage()
        Try
            Dim dt As DataSet = PrivilageBLL.CheckPrivilige(Session("UserRoleID"), "SampleRequest.aspx")
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
            Else
                drprivilage = dtprivilage.Rows(0)
                If (drprivilage("Prvg_RAdd").ToString()) = True Then
                    hlnkAdd.Visible = True
                Else
                    hlnkAdd.Visible = False
                End If
                If (drprivilage("Prvg_RUpdate").ToString()) = True Then
                    thEdit.Visible = True
                    For i As Integer = 0 To rpgridview.Items.Count - 1
                        Dim tdEdit As HtmlTableCell = DirectCast(rpgridview.Items(i).FindControl("tdEdit"), HtmlTableCell)
                        tdEdit.Visible = True
                    Next
                Else
                    thEdit.Visible = False
                    For i As Integer = 0 To rpgridview.Items.Count - 1
                        Dim tdEdit As HtmlTableCell = DirectCast(rpgridview.Items(i).FindControl("tdEdit"), HtmlTableCell)
                        tdEdit.Visible = False
                    Next
                End If
                If (drprivilage("Prvg_RDelete").ToString()) = True Then
                    thDelete.Visible = True
                    For i As Integer = 0 To rpgridview.Items.Count - 1
                        Dim tdDelete As HtmlTableCell = DirectCast(rpgridview.Items(i).FindControl("tdDelete"), HtmlTableCell)
                        tdDelete.Visible = True
                    Next
                Else
                    thDelete.Visible = False
                    For i As Integer = 0 To rpgridview.Items.Count - 1
                        Dim tdDelete As HtmlTableCell = DirectCast(rpgridview.Items(i).FindControl("tdDelete"), HtmlTableCell)
                        tdDelete.Visible = False
                    Next
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SampleRequest", "CheckPrivilage", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
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
            Dim WhereClause1 As String = ""
            If txtSampleRequestNo.Text <> "" Then
                WhereClause = WhereClause + " and ( SampleRequest_No LIKE '%' + '" + txtSampleRequestNo.Text.Trim + "' + '%' ) "
                WhereClause1 = WhereClause1 + " and ( SampleRequest_No LIKE '%' + '" + txtSampleRequestNo.Text.Trim + "' + '%' ) "
            End If
            If txtRequestDate.Text <> "" Then
                WhereClause = WhereClause + " and ( convert(date,SampleRequest_Date,105) = '" + txtRequestDate.Text.Trim + "'  ) "
                WhereClause1 = WhereClause1 + " and ( convert(date,SampleRequest_Date,105) = '" + txtRequestDate.Text.Trim + "'  ) "
            End If
            If txtCompanyName.Text <> "" Then
                WhereClause = WhereClause + " and ( Lead_Name LIKE '%' + '" + txtCompanyName.Text.Trim.Replace("'", "''") + "' + '%' ) "
                WhereClause1 = WhereClause1 + " and ( Acc_Name LIKE '%' + '" + txtCompanyName.Text.Trim.Replace("'", "''") + "' + '%' ) "
            End If
            If txtContactName.Text <> "" Then
                WhereClause = WhereClause + " and ( LeadContact_Name LIKE '%' + '" + txtContactName.Text.Trim + "' + '%' ) "
                WhereClause1 = WhereClause1 + " and ( Contact_ContactPerson LIKE '%' + '" + txtContactName.Text.Trim + "' + '%' ) "
            End If
            'If txtQTY.Text <> "" Then
            '    WhereClause = WhereClause + " and ( Order_Code LIKE '%' + '" + txtQTY.Text.Trim + "' + '%' ) "
            '    WhereClause1 = WhereClause1 + " and ( Order_Code LIKE '%' + '" + txtQTY.Text.Trim + "' + '%' ) "
            'End If
            If txtAssignTo.Text <> "" Then
                WhereClause = WhereClause + " and ( tblUser.U_FirstName LIKE '%' + '" + txtAssignTo.Text.Trim + "' + '%' ) "
                WhereClause1 = WhereClause1 + " and ( tblUser.U_FirstName LIKE '%' + '" + txtAssignTo.Text.Trim + "' + '%' ) "
            End If
            If txtRequestStatus.Text <> "" Then
                WhereClause = WhereClause + " and ( SampleRequest_SampleStatus LIKE '%' + '" + txtRequestStatus.Text.Trim + "' + '%' ) "
                WhereClause1 = WhereClause1 + " and ( SampleRequest_SampleStatus LIKE '%' + '" + txtRequestStatus.Text.Trim + "' + '%' ) "
            End If
            If ddlStatus.SelectedValue <> "Select" Then
                WhereClause = WhereClause + " and ( SampleRequest_SampleStatus = '" + ddlStatus.SelectedValue + "' ) "
                WhereClause1 = WhereClause1 + " and ( SampleRequest_SampleStatus = '" + ddlStatus.SelectedValue + "'  ) "
            End If
            ''If txtSampleRequestNo.Text <> "" Or txtRequestDate.Text <> "" Or txtCompanyName.Text <> "" Or txtContactName.Text <> "" Or txtQTY.Text <> "" Or txtAssignTo.Text <> "" Then
            ''    ds1 = MainBLL.FillSampleReqFilter("SampleReqCRMFilter", Session("UserId"), txtSampleRequestNo.Text.Trim, txtRequestDate.Text.Trim,
            ''                                      txtCompanyName.Text.Trim, txtContactName.Text.Trim, txtQTY.Text.Trim, txtAssignTo.Text.Trim, txtRequestStatus.Text.Trim)
            ''End If
            If WhereClause <> "" Then
                ds1 = FilterBLL.FillNewFilter2("SampleReqCRMFiltM", Session("UserId"), WhereClause, WhereClause1)
            End If
            If ds1.Tables.Count > 0 Then
                If ds1.Tables(0).Rows.Count > 0 Then
                    dt1 = ds1.Tables(0)
                    divMain.Visible = True
                    If Session("UserRoleID") = 1 Then
                        btnExport.Visible = True
                    Else
                        btnExport.Visible = False
                    End If
                Else
                    divMain.Visible = False
                    btnExport.Visible = False
                End If
                PageNumber = 0
                dt3 = dt1
                Session("dt1SamReqNew") = dt1

                fillpage()
            Else
                divMain.Visible = False
                btnExport.Visible = False
            End If
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Binding Account'" + ex.Message + ")", True)
        End Try
    End Sub
    Sub AtLeastOneField_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        If txtSampleRequestNo.Text & txtRequestDate.Text & txtCompanyName.Text & txtContactName.Text & txtQTY.Text & txtAssignTo.Text & txtRequestStatus.Text <> "" Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

    Protected Sub BindLoad()
        Try
            Dim WhereClause As String = ""
            Dim WhereClause1 As String = ""
            WhereClause = WhereClause + "  and	( convert(date, SampleRequest_CreatedDate, 105) >= '" + Date.Now.AddDays(-7).Date.ToString("yyyy-MM-dd") + "'  )  "
            WhereClause1 = WhereClause1 + "  and	( convert(date, SampleRequest_CreatedDate, 105) >= '" + Date.Now.AddDays(-7).Date.ToString("yyyy-MM-dd") + "'  )  "

            If WhereClause <> "" Then
                ds1 = FilterBLL.FillNewFilter2("SampleReqCRMFiltM", Session("UserId"), WhereClause, WhereClause1)
            End If
            If ds1.Tables.Count > 0 Then
                If ds1.Tables(0).Rows.Count > 0 Then
                    dt1 = ds1.Tables(0)
                    divMain.Visible = True
                    If Session("UserRoleID") = 1 Then
                        btnExport.Visible = True
                    Else
                        btnExport.Visible = False
                    End If
                Else
                    divMain.Visible = False
                    btnExport.Visible = False
                End If
                PageNumber = 0
                dt3 = dt1
                Session("dt1SamReqNew") = dt1

                fillpage()
            Else
                divMain.Visible = False
                btnExport.Visible = False
            End If
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Binding Account'" + ex.Message + ")", True)
        End Try
    End Sub

    'Protected Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click
    '    Try
    '        txtSampleRequestNo.Text = ""
    '        txtRequestDate.Text = ""
    '        txtCompanyName.Text = ""
    '        txtContactName.Text = ""
    '        txtQTY.Text = ""
    '        txtAssignTo.Text = ""
    '        ddlStatus.SelectedValue = "Select"
    '    Catch ex As Exception

    '    End Try
    'End Sub
End Class
