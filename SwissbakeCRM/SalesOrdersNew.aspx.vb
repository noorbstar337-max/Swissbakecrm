Imports System.Drawing

Partial Class SalesOrdersNew
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

        hlnkAdd.NavigateUrl = Page.ResolveUrl("ModifySalesOrder.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)))
        SessId = Session("UserId")
        If Not IsPostBack Then
            Hfgridview.Value = "SalesOrderCRMFilter"
            hfExcel.Value = "ExcelOrderByAssign"
            FillUsers()
            ' ''If Request.QueryString("Type") = Nothing Then
            ' ''    Hfgridview.Value = "SalesOrderGVByAssignCRM"
            ' ''    hfExcel.Value = "ExcelOrderByAssign"
            ' ''    BindGridview()
            ' ''Else
            ' ''    If Request.QueryString("Type").ToString = "prgvfhjsghf" Then
            ' ''        SessId = Session("DUserId")
            ' ''        Hfgridview.Value = "AchivedSalesLastMonthCRM"
            ' ''        hfExcel.Value = "ExcelAchivedSalesLastMonth"
            ' ''        BindGridview()
            ' ''    ElseIf Request.QueryString("Type").ToString = "zhtqu" Then
            ' ''        SessId = Session("DUserId")
            ' ''        Hfgridview.Value = "AchivedSalesCRM"
            ' ''        hfExcel.Value = "ExcelAchivedSales"
            ' ''        BindGridview()
            ' ''    ElseIf Request.QueryString("Type").ToString = "zmhytsqaules" Then
            ' ''        SessId = Session("DUserId")
            ' ''        Hfgridview.Value = "AchivedMySalesCRM"
            ' ''        hfExcel.Value = "ExcelAchivedSales"
            ' ''        BindGridview()
            ' ''    Else
            ' ''        SessId = Session("UserId")
            ' ''        Hfgridview.Value = "AchivedSalesCRM"
            ' ''        hfExcel.Value = "ExcelAchivedSales"
            ' ''        BindGridview()
            ' ''    End If
            ' ''End If
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
            'If Session("UserRoleID") = 1 Then
            '    btnExport.Visible = True
            'Else
            '    btnExport.Visible = False
            'End If
            ddlStatus.SelectedValue = "Pending"
            BindNewGridview()
        End If
        'If Session("UserId") = Nothing Then

        'Else

        'End If

    End Sub
    Public Sub FillUsers()
        Try
            Dim ds As DataSet = MainBLL.DropdownByuser("UserAssignDropDown", Session("UserId"))
            ddlCustOwner.DataSource = ds
            ddlCustOwner.DataTextField = "U_FirstName"
            ddlCustOwner.DataValueField = "U_ID"
            ddlCustOwner.DataBind()
            ddlCustOwner.Items.Insert(0, New ListItem("Select Customer Owner", "0"))

            ddlCreatedBy.DataSource = ds
            ddlCreatedBy.DataTextField = "U_FirstName"
            ddlCreatedBy.DataValueField = "U_ID"
            ddlCreatedBy.DataBind()
            ddlCreatedBy.Items.Insert(0, New ListItem("Select Created By", "0"))

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyAccount", "FillSource", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
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
            ds1 = MainBLL.FillGridByID(Hfgridview.Value, SessId)
            'ds1 = MainBLL.FillGridView(hfgridview.Value)
            If ds1.Tables(0).Rows.Count > 0 Then
                dt1 = ds1.Tables(0)
                'rpgridview.DataSource = dt1
                'rpgridview.DataBind()
            End If
            dt3 = dt1
            Session("dt1SONew") = dt1

            fillpage()
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Binding Account'" + ex.Message + ")", True)
        End Try
    End Sub
    Public Sub fillpage()
        Dim dt As New DataTable()
        If txtSearch.Text <> "" Then
            'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" Then
            dt = DirectCast(Session("dt2SONew"), DataTable)
        Else

            dt = DirectCast(Session("dt1SONew"), DataTable)
        End If
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


    Public Sub getsearch()
        Try

            'date time column not working in search and footer
            dt2 = DirectCast(Session("dt1SONew"), DataTable)


            If txtSearch.Text <> "" Then
                Dim selectedTable1 As DataTable = dt2.AsEnumerable().Where(Function(r) (r.Field(Of String)("Order_Code").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                           (r.Field(Of String)("Order_CreatedDate").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                            (r.Field(Of String)("Acc_Name").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                             (r.Field(Of Decimal)("amount").ToString().Contains(txtSearch.Text.ToUpper())) OrElse
                (r.Field(Of String)("City").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                (r.Field(Of String)("Order_OrderStatus").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                (r.Field(Of String)("AccountOwner").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                (r.Field(Of String)("AssignTo").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                (r.Field(Of String)("OrderCreated").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                (r.Field(Of String)("Order_type").ToUpper().Contains(txtSearch.Text.ToUpper()))
                                ).CopyToDataTable()

                Session("dt2SONew") = selectedTable1
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

                '    Session("dt2SONew") = selectedTable1



            End If
        Catch ex As Exception
            '  Session["dt2SO"] = "1";
            Dim exception As New DataTable()
            exception.Clear()

            Session("dt2SONew") = exception
        End Try
    End Sub
    Protected Sub Sorting(sender As Object, e As EventArgs)
        Try
            Dim Header As LinkButton = DirectCast(sender, LinkButton)

            If Not Session("dt1SONew") Is Nothing Then
                Dim dt As DataTable = Session("dt1SONew")
                If ViewState("SortDir") Is Nothing Or ViewState("SortDir") = "Asc" Then
                    dt.DefaultView.Sort = Header.ID
                    dt = dt.DefaultView.ToTable()
                    ViewState("SortDir") = "Desc"
                Else
                    dt.DefaultView.Sort = Header.ID & " DESC"
                    dt = dt.DefaultView.ToTable()
                    ViewState("SortDir") = "Asc"
                End If
                Session("dt1SONew") = dt
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
                        Dim msg As String = MainBLL.DeleteSI(uid, SessId, "OrderDeleteSi", Session("Audlog_Id"))
                        If Not String.IsNullOrEmpty(msg) Then
                            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + msg + "')", True)
                        End If

                        ' ===== SAFE USER =====
                        Dim uiduser As Integer? = Nothing
                        If Session("UserId") IsNot Nothing AndAlso IsNumeric(Session("UserId")) Then
                            uiduser = Convert.ToInt32(Session("UserId"))
                        End If

                        Dim uname As String = ""
                        If Session("UName") IsNot Nothing Then
                            uname = Session("UName").ToString()
                        End If

                        ' ===== ACTIVITY LOG =====
                        ActivityLogger.SaveLog(
                        uiduser,
                        uname,
                        "ORDER_DELETED",
                        "Order",
                        uid.ToString(),
                        "Order deleted successfully | Order Id : " & uid.ToString(),
                        Request
                    )
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
            Response.AddHeader("content-disposition", "attachment;filename=SalesOrders.xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            Dim Gridview2 As New GridView

            Dim dt As New DataTable()
            'dt = MainBLL.FillGridByID(Hfgridview.Value, SessId)
            'dt = MainBLL.SearchGridViewByID(txtSearch.Text.Trim, Session("UserId"), hfExcel.Value)
            'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" Then
            If txtSearch.Text <> "" Then
                dt = DirectCast(Session("dt2SONew"), DataTable)
            Else
                dt = DirectCast(Session("dt1SONew"), DataTable)
            End If

            Dim dtExc As DataTable = dt
            dtExc.Columns.Remove("Order_ID")
            dtExc.Columns.Remove("Acc_id")
            dtExc.Columns.Remove("Order_Del")
            'dtExc.Columns.Remove("Order_type")
            dtExc.Columns.Remove("Class")
            dtExc.Columns.Remove("Order_Status")
            dtExc.Columns.Remove("OrderCreated")
            dtExc.Columns.Remove("Order_CreatedDate")
            dtExc.Columns.Remove("invCount")
            ''dtExc.Columns.Remove("RowNumber")*******
            'dtExc.Columns("Acc_Name").ColumnName = "Account Name"
            dtExc.Columns("Order_Code").ColumnName = "Order Code"
            dtExc.Columns("Order_CreatedDate1").ColumnName = "Order Date"
            dtExc.Columns("Acc_Name").ColumnName = "Customer Name"
            dtExc.Columns("Order_OrderStatus").ColumnName = "Order Status"
            dtExc.Columns("City").ColumnName = "City"
            dtExc.Columns("State").ColumnName = "State"
            dtExc.Columns("Order_type").ColumnName = "From"
            dtExc.Columns("AccountOwner").ColumnName = "Customer Owner"
            dtExc.Columns("AccCreatedBy").ColumnName = "Customer Created By"
            dtExc.Columns("Customer Name").SetOrdinal(2)
            'dtExc.Columns("Qty").SetOrdinal(4)
            'dtExc.Columns("City").SetOrdinal(5)
			'dtExc.Columns("State").SetOrdinal(6)
            'dtExc.Columns("Customer Owner").SetOrdinal(3)
            dtExc.Columns("From").SetOrdinal(10)

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
            Dim dt As DataSet = PrivilageBLL.CheckPrivilige(Session("UserRoleID"), "Account.aspx")
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
                Else
                    thEdit.Visible = False
                    thDelete.Visible = False
                    For i As Integer = 0 To rpgridview.Items.Count - 1
                        Dim tdEdit As HtmlTableCell = DirectCast(rpgridview.Items(i).FindControl("tdEdit"), HtmlTableCell)
                        Dim tdDelete As HtmlTableCell = DirectCast(rpgridview.Items(i).FindControl("tdDelete"), HtmlTableCell)
                        tdEdit.Visible = False
                        tdDelete.Visible = False
                    Next
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

    ' ''#Region "OlD"
    ' ''    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
    ' ''        Try
    ' ''            hlnkAdd.NavigateUrl = Page.ResolveUrl("ModifySalesOrder.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")
    ' ''            SessId = Session("UserId")
    ' ''            If Not IsPostBack Then
    ' ''                If Request.QueryString("Type") = Nothing Then

    ' ''                    Hfgridview.Value = "SalesOrderGridviewByAssign"
    ' ''                    hfsearch.Value = "SearchOrderByAssign"
    ' ''                    hftotalrecord.Value = "OrderTotalNumberOfRecord"
    ' ''                    fillOrder()
    ' ''                    CheckPrivilage()
    ' ''                    'Above Line For Passing Mode In Search Order Control
    ' ''                    SearchControl.UhfExcelName.Value = "Sales Order Details"
    ' ''                    SearchControl.Uhfgridviewmode.Value = "SalesOrderGridviewByAssign"
    ' ''                    SearchControl.Uhfsearchmode.Value = "SearchOrderByAssign"
    ' ''                    SearchControl.UhfExcelmode.Value = "ExcelOrderByAssign"
    ' ''                    SearchControl.Uhftotalcount.Value = "OrderTotalNumberOfRecord"
    ' ''                Else
    ' ''                    If Request.QueryString("Type").ToString = "prgvfhjsghf" Then
    ' ''                        SessId = Session("DUserId")
    ' ''                        Hfgridview.Value = "AchivedSalesLastMonth"
    ' ''                        hfsearch.Value = "SearchAchivedSalesLastMonth"
    ' ''                        hftotalrecord.Value = "CountAchivedSalesLastMonth"
    ' ''                        fillOrder()
    ' ''                        CheckPrivilage()
    ' ''                        'Above Line For Passing Mode In Search Order Control
    ' ''                        SearchControl.UhfExcelName.Value = "Sales Order Details"
    ' ''                        SearchControl.Uhfgridviewmode.Value = "AchivedSalesLastMonth"
    ' ''                        SearchControl.Uhfsearchmode.Value = "SearchAchivedSalesLastMonth"
    ' ''                        SearchControl.UhfExcelmode.Value = "ExcelAchivedSalesLastMonth"
    ' ''                        SearchControl.Uhftotalcount.Value = "CountAchivedSalesLastMonth"
    ' ''                    ElseIf Request.QueryString("Type").ToString = "zhtqu" Then
    ' ''                        SessId = Session("DUserId")
    ' ''                        Hfgridview.Value = "AchivedSales"
    ' ''                        hfsearch.Value = "SearchAchivedSales"
    ' ''                        hftotalrecord.Value = "CountAchivedSales"
    ' ''                        fillOrder()
    ' ''                        CheckPrivilage()
    ' ''                        'Above Line For Passing Mode In Search Order Control
    ' ''                        SearchControl.UhfExcelName.Value = "Sales Order Details"
    ' ''                        SearchControl.Uhfgridviewmode.Value = "AchivedSales"
    ' ''                        SearchControl.Uhfsearchmode.Value = "SearchAchivedSales"
    ' ''                        SearchControl.UhfExcelmode.Value = "ExcelAchivedSales"
    ' ''                        SearchControl.Uhftotalcount.Value = "CountAchivedSales"
    ' ''                    Else
    ' ''                        SessId = Session("UserId")
    ' ''                        Hfgridview.Value = "AchivedSales"
    ' ''                        hfsearch.Value = "SearchAchivedSales"
    ' ''                        hftotalrecord.Value = "CountAchivedSales"
    ' ''                        fillOrder()
    ' ''                        CheckPrivilage()
    ' ''                        'Above Line For Passing Mode In Search Order Control
    ' ''                        SearchControl.UhfExcelName.Value = "Sales Order Details"
    ' ''                        SearchControl.Uhfgridviewmode.Value = "AchivedSales"
    ' ''                        SearchControl.Uhfsearchmode.Value = "SearchAchivedSales"
    ' ''                        SearchControl.UhfExcelmode.Value = "ExcelAchivedSales"
    ' ''                        SearchControl.Uhftotalcount.Value = "CountAchivedSales"
    ' ''                    End If
    ' ''                End If
    ' ''            End If
    ' ''        Catch ex As Exception
    ' ''            Dim error1 As String = ex.Message.Replace(Chr(34), "")
    ' ''            error1 = error1.Replace(Chr(39), "")
    ' ''            ExecptionBLL.Insert("Order", "Page_Load", error1, Session("UserId"))
    ' ''            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    ' ''        End Try
    ' ''    End Sub

    ' ''    Public Sub fillOrder()
    ' ''        Try
    ' ''            GridView1.PageSize = SearchControl.Uddpagesize.SelectedValue
    ' ''            'GridView1.VirtualItemCount = MainBLL.TotalRowInGridview(hftotalrecord.Value)
    ' ''            GridView1.VirtualItemCount = MainBLL.TotalRowInGridviewBYID(hftotalrecord.Value, SessId)
    ' ''            GridView1.DataSource = MainBLL.FillGridViewById("0", SearchControl.Uddpagesize.SelectedValue, SessId, Hfgridview.Value)
    ' ''            GridView1.DataBind()
    ' ''        Catch ex As Exception
    ' ''            Dim error1 As String = ex.Message.Replace(Chr(34), "")
    ' ''            error1 = error1.Replace(Chr(39), "")
    ' ''            ExecptionBLL.Insert("Order", "fillOrder", error1, Session("UserId"))
    ' ''            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    ' ''            Throw ex
    ' ''        End Try
    ' ''    End Sub

    ' ''    Public Sub IndexfillOrder()
    ' ''        Try
    ' ''            GridView1.DataSource = MainBLL.FillGridViewById(GridView1.PageIndex, SearchControl.Uddpagesize.SelectedValue, SessId, Hfgridview.Value)
    ' ''            GridView1.DataBind()
    ' ''        Catch ex As Exception
    ' ''            Dim error1 As String = ex.Message.Replace(Chr(34), "")
    ' ''            error1 = error1.Replace(Chr(39), "")
    ' ''            ExecptionBLL.Insert("Order", "IndexfillOrder", error1, Session("UserId"))
    ' ''            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    ' ''            Throw ex
    ' ''        End Try
    ' ''    End Sub

    ' ''    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
    ' ''        Try
    ' ''            If SearchControl.UtxtSearch.Text = "" Then
    ' ''                GridView1.PageIndex = e.NewPageIndex
    ' ''                GridView1.DataSource = MainBLL.FillGridViewById(GridView1.PageIndex, SearchControl.Uddpagesize.SelectedValue, SessId, Hfgridview.Value)
    ' ''                GridView1.DataBind()
    ' ''                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
    ' ''            Else
    ' ''                GridView1.PageIndex = e.NewPageIndex
    ' ''                SearchFillOrder()
    ' ''                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
    ' ''            End If
    ' ''        Catch ex As Exception
    ' ''            Dim error1 As String = ex.Message.Replace(Chr(34), "")
    ' ''            error1 = error1.Replace(Chr(39), "")
    ' ''            ExecptionBLL.Insert("Order", "GridView1_PageIndexChanging", error1, Session("UserId"))
    ' ''            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    ' ''        End Try
    ' ''    End Sub

    ' ''    Protected Sub ddpagesize_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchControl.SelectedIndexChanged
    ' ''        Try
    ' ''            If SearchControl.Uddpagesize.SelectedItem.Text <> "0" Then
    ' ''                GridView1.PageSize = SearchControl.Uddpagesize.SelectedValue.ToString()
    ' ''                IndexfillOrder()
    ' ''                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
    ' ''            End If
    ' ''        Catch ex As Exception
    ' ''            Dim error1 As String = ex.Message.Replace(Chr(34), "")
    ' ''            error1 = error1.Replace(Chr(39), "")
    ' ''            ExecptionBLL.Insert("Order", "ddpagesize_SelectedIndexChanged", error1, Session("UserId"))
    ' ''            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    ' ''        End Try
    ' ''    End Sub

    ' ''    Protected Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs)
    ' ''        SetSortDirection(SortDireaction)
    ' ''        Try
    ' ''            Dim dt As DataSet
    ' ''            If Request.QueryString("Type") = Nothing Then
    ' ''                dt = OrderBLL.SortOrderCRM(Session("UserId"))
    ' ''            Else
    ' ''                If Request.QueryString("Type").ToString = "prgvfhjsghf" Then
    ' ''                    dt = OrderBLL.SortingSalesAchivedLastMonth(Session("UserId"))
    ' ''                Else
    ' ''                    dt = OrderBLL.SortingSalesAchived(Session("UserId"))
    ' ''                End If
    ' ''            End If
    ' ''            Dim DataTable As DataTable = dt.Tables(0)
    ' ''            If DataTable IsNot Nothing Then
    ' ''                DataTable.DefaultView.Sort = Convert.ToString(e.SortExpression) & " " & _sortDirection
    ' ''                GridView1.DataSource = DataTable
    ' ''                GridView1.DataBind()
    ' ''                SortDireaction = _sortDirection
    ' ''                Dim columnIndex As Integer = 0
    ' ''                For Each headerCell As DataControlFieldHeaderCell In GridView1.HeaderRow.Cells
    ' ''                    If headerCell.ContainingField.SortExpression = e.SortExpression Then
    ' ''                        columnIndex = GridView1.HeaderRow.Cells.GetCellIndex(headerCell)
    ' ''                    End If
    ' ''                Next
    ' ''                GridView1.HeaderRow.Cells(columnIndex).Controls.Add(sortImage)
    ' ''            End If
    ' ''        Catch ex As Exception
    ' ''            Dim error1 As String = ex.Message.Replace(Chr(34), "")
    ' ''            error1 = error1.Replace(Chr(39), "")
    ' ''            ExecptionBLL.Insert("Order", "GridView1_Sorting", error1, Session("UserId"))
    ' ''            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    ' ''        End Try
    ' ''    End Sub

    ' ''    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
    ' ''        If e.CommandName = "deletelink" Then
    ' ''            If deletestatus.Value = "yes" Then
    ' ''                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
    ' ''                MainId = GridView1.DataKeys(index).Value
    ' ''                Try
    ' ''                    Dim msg As String = MainBLL.DeleteSI(MainId, SessId, "OrderDeleteSi", Session("Audlog_Id"))
    ' ''                    If Not String.IsNullOrEmpty(msg) Then
    ' ''                        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + msg + "')", True)
    ' ''                    End If
    ' ''                    IndexfillOrder()
    ' ''                Catch ex As Exception
    ' ''                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
    ' ''                    error1 = error1.Replace(Chr(39), "")
    ' ''                    ExecptionBLL.Insert("Order", "deletelink", error1, Session("UserId"))
    ' ''                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    ' ''                End Try
    ' ''            Else
    ' ''                If SearchControl.UtxtSearch.Text.Trim = "" Then
    ' ''                    IndexfillOrder()
    ' ''                Else
    ' ''                    SearchFillOrder()
    ' ''                End If
    ' ''            End If
    ' ''        ElseIf e.CommandName = "statuslink" Then
    ' ''            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
    ' ''            MainId = GridView1.DataKeys(index).Value
    ' ''            Try
    ' ''                MainBLL.UpdateStatus(MainId, Session("OrderId"), "OrderStatus", Session("Audlog_Id"))
    ' ''                If SearchControl.UtxtSearch.Text.Trim = "" Then
    ' ''                    IndexfillOrder()
    ' ''                Else
    ' ''                    SearchFillOrder()
    ' ''                End If
    ' ''            Catch ex As Exception
    ' ''                Dim error1 As String = ex.Message.Replace(Chr(34), "")
    ' ''                error1 = error1.Replace(Chr(39), "")
    ' ''                ExecptionBLL.Insert("Order", "statuslink", error1, Session("UserId"))
    ' ''                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    ' ''            End Try
    ' ''        End If
    ' ''    End Sub

    ' ''    Public Sub SearchFillOrder()
    ' ''        Try
    ' ''            GridView1.DataSource = MainBLL.SearchGridViewByID(SearchControl.UtxtSearch.Text.Trim, SessId, hfsearch.Value)
    ' ''            GridView1.DataBind()
    ' ''        Catch ex As Exception
    ' ''            Dim error1 As String = ex.Message.Replace(Chr(34), "")
    ' ''            error1 = error1.Replace(Chr(39), "")
    ' ''            ExecptionBLL.Insert("Order", "SearchFillOrder", error1, Session("UserId"))
    ' ''            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    ' ''            Throw ex
    ' ''        End Try
    ' ''    End Sub

    ' ''    Public Sub CheckPrivilage()
    ' ''        Try
    ' ''            Dim dt As DataSet = PrivilageBLL.CheckPrivilige(Session("UserRoleID"), "SalesOrders.aspx")
    ' ''            Dim dtprivilage As New DataTable
    ' ''            dtprivilage = dt.Tables(0)
    ' ''            Dim drprivilage As DataRow
    ' ''            If dtprivilage.Rows.Count = 0 Then
    ' ''                SearchControl.Uhfadd.Visible = False
    ' ''                GridView1.Columns(0).Visible = False
    ' ''                SearchControl.ULkadd.Visible = False
    ' ''            Else
    ' ''                drprivilage = dtprivilage.Rows(0)
    ' ''                If (drprivilage("Prvg_RAdd").ToString()) = True Then
    ' ''                    SearchControl.Uhfadd.Visible = True
    ' ''                Else
    ' ''                    SearchControl.Uhfadd.Visible = False
    ' ''                End If
    ' ''                If (drprivilage("Prvg_RUpdate").ToString()) = True Then
    ' ''                    GridView1.Columns(0).Visible = True
    ' ''                Else
    ' ''                    GridView1.Columns(0).Visible = False
    ' ''                End If
    ' ''                If (drprivilage("Prvg_RDelete").ToString()) = True Then
    ' ''                    GridView1.Columns(11).Visible = True
    ' ''                Else
    ' ''                    GridView1.Columns(11).Visible = False
    ' ''                End If
    ' ''            End If
    ' ''        Catch ex As Exception
    ' ''            Dim error1 As String = ex.Message.Replace(Chr(34), "")
    ' ''            error1 = error1.Replace(Chr(39), "")
    ' ''            ExecptionBLL.Insert("Order", "CheckPrivilage", error1, Session("UserId"))
    ' ''            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    ' ''            Throw ex
    ' ''        End Try
    ' ''    End Sub

    ' ''    'Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
    ' ''    '    Try
    ' ''    '        If e.Row.RowType = DataControlRowType.DataRow Then
    ' ''    '            Dim lblDate As Literal = DirectCast(e.Row.FindControl("lblDate"), Literal)
    ' ''    '            lblDate.Text = DynamicparcelDataManipulation.AlphaDateFormat(lblDate.Text)
    ' ''    '        End If
    ' ''    '    Catch ex As Exception
    ' ''    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    ' ''    '        error1 = error1.Replace(Chr(39), "")
    ' ''    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    ' ''    '    End Try
    ' ''    'End Sub

    ' ''    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
    ' ''        Try
    ' ''            If e.Row.RowType = DataControlRowType.DataRow Then
    ' ''                Dim ltdel As Literal = DirectCast(e.Row.FindControl("ltdel"), Literal)
    ' ''                Dim lnkdelete As LinkButton = DirectCast(e.Row.FindControl("lnkdelete"), LinkButton)
    ' ''                If ltdel.Text = 0 Then
    ' ''                    lnkdelete.Visible = True
    ' ''                Else
    ' ''                    lnkdelete.Visible = False
    ' ''                End If
    ' ''            End If
    ' ''        Catch ex As Exception
    ' ''            Dim error1 As String = ex.Message.Replace(Chr(34), "")
    ' ''            error1 = error1.Replace(Chr(39), "")
    ' ''            ExecptionBLL.Insert("SalesOrders", "GridView1_RowDataBound", error1, Session("UserId"))
    ' ''            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    ' ''        End Try
    ' ''    End Sub
    ' ''#End Region

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            BindNewGridview()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub BindNewGridview()
        Try
            Dim WhereClause As String = ""
            If txtORDERCODE.Text <> "" Then
                WhereClause = WhereClause + " and ( Order_Code LIKE '%' + '" + txtORDERCODE.Text.Trim + "' + '%' ) "
            End If
            If txtORDERDATE.Text <> "" Then
                ' ''WhereClause = WhereClause + " And (CONVERT(VARCHAR(20), [Order_CreatedDate], 100) LIKE '%' + '" + txtORDERDATE.Text.Trim + "' + '%') "
                WhereClause = WhereClause + " And ( CONVERT(VARCHAR(20), [Order_CreatedDate], 111) = '" + txtORDERDATE.Text.Replace("-", "/").Trim + "' ) "
            End If
            If txtCUSTOMERNAME.Text <> "" Then
                WhereClause = WhereClause + " and ( Acc_Name LIKE '%' + '" + txtCUSTOMERNAME.Text.Trim.Replace("'", "''") + "' + '%' ) "
            End If
            If txtCity.Text <> "" Then
                WhereClause = WhereClause + "  and ( AccAddr_City LIKE '%' + '" + txtCity.Text.Trim + "' + '%' )  "
            End If
            ' ''If txtORDERSTATUS.Text <> "" Then
            ' ''    WhereClause = WhereClause + "  and ( Order_OrderStatus LIKE '%' + '" + txtORDERSTATUS.Text.Trim + "' + '%' )  "
            ' ''End If
            If ddlStatus.SelectedValue <> "Select" Then
                WhereClause = WhereClause + "  and ( Order_OrderStatus = '" + ddlStatus.SelectedValue + "'  )  "
            End If
            ' ''If txtCUSTOMEROWNER.Text <> "" Then
            ' ''    WhereClause = WhereClause + "  and ( ussowner.U_FirstName LIKE '%' + '" + txtCUSTOMEROWNER.Text.Trim + "' + '%' )  "
            ' ''End If
            If ddlCustOwner.SelectedValue <> "0" Then
                WhereClause = WhereClause + "  and ( Acc_OwnerID = '" + ddlCustOwner.SelectedValue + "'  )  "
            End If
            ' ''If txtCreatedBy.Text <> "" Then
            ' ''    WhereClause = WhereClause + "  and ( usscreated.U_FirstName LIKE '%' + '" + txtCreatedBy.Text.Trim + "' + '%' )  "
            ' ''End If
            If ddlCreatedBy.SelectedValue <> "0" Then
                WhereClause = WhereClause + "  and ( Acc_CreatedID = '" + ddlCreatedBy.SelectedValue + "' )  "
            End If
            ' ''If txtFrom.Text <> "" Then
            ' ''    WhereClause = WhereClause + "  and ( replace(isnull([Order_type],''),'Swissbake','B2B') LIKE '%' + '" + txtFrom.Text.Trim + "' + '%' )  "
            ' ''End If
            If ddlFrom.SelectedValue <> "Select" Then
                WhereClause = WhereClause + "  and ( replace(isnull([Order_type],''),'Swissbake','B2B') = '" + ddlFrom.SelectedValue + "' )  "
            End If

            'ds1 = MainBLL.FillSalesOrderFilter(Hfgridview.Value, Session("UserId"), txtORDERCODE.Text.Trim, txtORDERDATE.Text.Trim, txtCUSTOMERNAME.Text.Trim, txtAMOUNT.Text.Trim,
            '                                   txtCity.Text.Trim, txtORDERSTATUS.Text.Trim, txtCUSTOMEROWNER.Text.Trim, txtAssignTo.Text.Trim, txtCreatedBy.Text.Trim, txtFrom.Text.Trim)
            If WhereClause <> "" Then
                ds1 = FilterBLL.FillNewFilter("SalesOrderCRMFiltM", Session("UserId"), WhereClause)
            End If
            If ds1.Tables.Count > 0 Then

                If ds1.Tables(0).Rows.Count > 0 Then
                    dt1 = ds1.Tables(0)
                    divMain.Visible = True
                    If Session("UserRoleID") = 1 Then
                        btnExport.Visible = True
                    Else
                        'btnExport.Visible = False
                    End If
                    'btnExport.Visible = True
                Else
                    divMain.Visible = False
                    'btnExport.Visible = False
                End If
                PageNumber = 0
                dt3 = dt1
                Session("dt1SONew") = dt1

                fillpage()
            Else
                divMain.Visible = False
                'btnExport.Visible = False
            End If
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Binding Account'" + ex.Message + ")", True)
        End Try
    End Sub
    Sub AtLeastOneField_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        'If txtORDERCODE.Text & txtORDERDATE.Text & txtCUSTOMERNAME.Text & txtAMOUNT.Text & txtCity.Text & txtORDERSTATUS.Text & txtCUSTOMEROWNER.Text & txtAssignTo.Text & txtCreatedBy.Text & txtFrom.Text <> "" Then
        If txtORDERCODE.Text & txtORDERDATE.Text & txtCUSTOMERNAME.Text & txtAMOUNT.Text & txtCity.Text & txtCUSTOMEROWNER.Text & txtAssignTo.Text & txtCreatedBy.Text & txtFrom.Text <> "" Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub


    'Protected Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click
    '    Try
    '        txtORDERCODE.Text = ""
    '        txtORDERDATE.Text = ""
    '        txtCUSTOMERNAME.Text = ""
    '        txtAMOUNT.Text = ""
    '        txtCity.Text = ""
    '        ddlStatus.SelectedValue = "Select"
    '        ddlCustOwner.SelectedValue = "0"
    '        txtAssignTo.Text = ""
    '        ddlCreatedBy.SelectedValue = "0"
    '        ddlFrom.SelectedValue = "Select"
    '    Catch ex As Exception

    '    End Try
    'End Sub
End Class
