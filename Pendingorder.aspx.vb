Imports System.Drawing

Partial Class Pendingorder
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
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                txtSearch.Attributes.Add("onkeyup", [String].Format("javascript:__doPostBack('{0}','')", rpg.ClientID))
                BindGridview()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        If IsPostBack Then
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
            ds1 = CountBLL.IndexCount("fillPending", Session("DUserId"))
            If ds1.Tables(1).Rows.Count > 0 Then
                dt1 = ds1.Tables(1)
            End If
            dt3 = dt1
            Session("dt1POrd") = dt1

            fillpage()
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Binding Account'" + ex.Message + ")", True)
        End Try
    End Sub
    Public Sub fillpage()
        Dim dt As New DataTable()
        If txtSearch.Text <> "" Then
            dt = DirectCast(Session("dt2POrd"), DataTable)
        Else

            dt = DirectCast(Session("dt1POrd"), DataTable)
        End If
        
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
            TAB.Value = tabss.ToString()

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
            dt2 = DirectCast(Session("dt1POrd"), DataTable)
            If txtSearch.Text <> "" Then
                Dim selectedTable1 As DataTable = dt2.AsEnumerable().Where(Function(r) (r.Field(Of String)("AccountName").ToUpper().Contains(txtSearch.Text.Trim.ToUpper())) OrElse
                                                                               (r.Field(Of String)("Order_Code").ToUpper().Contains(txtSearch.Text.Trim.ToUpper())) OrElse
                                                                                (r.Field(Of String)("Order_CreatedDate").ToUpper().Contains(txtSearch.Text.Trim.ToUpper())) OrElse
                (r.Field(Of Decimal)("Amount").ToString().Contains(txtSearch.Text.Trim()))
                                ).CopyToDataTable()

                Session("dt2POrd") = selectedTable1
            End If
        Catch ex As Exception
            Dim exception As New DataTable()
            exception.Clear()
            Session("dt2POrd") = exception
        End Try
    End Sub
    Protected Sub Sorting(sender As Object, e As EventArgs)
        Try
            Dim Header As LinkButton = DirectCast(sender, LinkButton)

            If Not Session("dt1POrd") Is Nothing Then
                Dim dt As DataTable = Session("dt1POrd")
                If ViewState("SortDir") Is Nothing Or ViewState("SortDir") = "Asc" Then
                    dt.DefaultView.Sort = Header.ID
                    dt = dt.DefaultView.ToTable()
                    ViewState("SortDir") = "Desc"
                Else
                    dt.DefaultView.Sort = Header.ID & " DESC"
                    dt = dt.DefaultView.ToTable()
                    ViewState("SortDir") = "Asc"
                End If
                Session("dt1POrd") = dt
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
End Class
