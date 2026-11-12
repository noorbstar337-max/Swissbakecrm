
Partial Class MIS
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
        If Session("UserRoleID") <> "1" Then
            Response.Redirect("Index.aspx")
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillMISType()
        End If
    End Sub

    Public Sub FillMISType()
        Try
            Dim dt As New DataTable()
            dt.Columns.AddRange(New DataColumn() {New DataColumn("name", GetType(String))})
            dt.Rows.Add("Admin Report")
            dt.Rows.Add("Summary Report")
            dt.Rows.Add("Accounts Report")
            dt.Rows.Add("Product List Report")
            dt.Rows.Add("Lead Report")
            dt.Rows.Add("Activity Report")
            dt.Rows.Add("Opportunity Report")
            dt.Rows.Add("Sales Order Report")
            dt.Rows.Add("Quotation Report")
            dt.Rows.Add("Complaints Report")
            dt.Rows.Add("Custom Report")
            dt.Rows.Add("Top In Particular Period")
            dt.Rows.Add("Outstanding Report")
            GridView1.DataSource = dt
            GridView1.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim grdreport As GridView = DirectCast(e.Row.FindControl("grdreport"), GridView)
            Dim grdsalesreport As GridView = DirectCast(e.Row.FindControl("grdsalesreport"), GridView)
            Dim grdsalesreportnew As GridView = DirectCast(e.Row.FindControl("grdsalesreportnew"), GridView)
            Dim grdTop As GridView = DirectCast(e.Row.FindControl("grdTop"), GridView)
            Dim grdTopProduct As GridView = DirectCast(e.Row.FindControl("grdTopProduct"), GridView)
            Dim grdPerformance As GridView = DirectCast(e.Row.FindControl("grdPerformance"), GridView)
            Dim ltname As Literal = DirectCast(e.Row.FindControl("ltname"), Literal)
            If ltname.Text = "Summary Report" Then
                Dim dt As New DataTable()
                dt.Columns.AddRange(New DataColumn() {New DataColumn("CustomReport_Name", GetType(String)), New DataColumn("CustomReport_Id", GetType(Integer))})
                dt.Rows.Add("Sales Performance by User Report", 0)
                grdsalesreport.DataSource = dt
                grdsalesreport.DataBind()
            ElseIf ltname.Text = "Top In Particular Period" Then
                Dim dt As New DataTable()
                dt.Columns.AddRange(New DataColumn() {New DataColumn("CustomReport_Name", GetType(String)), New DataColumn("CustomReport_Id", GetType(Integer))})
                dt.Rows.Add("Accounts report sorted according to sales brought in a particular time period", 0)
                grdTop.DataSource = dt
                grdTop.DataBind()
                Dim dt1 As New DataTable()
                dt1.Columns.AddRange(New DataColumn() {New DataColumn("CustomReport_Name", GetType(String)), New DataColumn("CustomReport_Id", GetType(Integer))})
                dt1.Rows.Add("Product report sorted according to product sold most to least in a particular time period", 0)
                grdTopProduct.DataSource = dt1
                grdTopProduct.DataBind()
            ElseIf ltname.Text = "Activity Report" Then
                Dim dt As New DataTable()
                dt.Columns.AddRange(New DataColumn() {New DataColumn("CustomReport_Name", GetType(String)), New DataColumn("CustomReport_Id", GetType(Integer))})
                dt.Rows.Add("Performance Report", 0)
                grdPerformance.DataSource = dt
                grdPerformance.DataBind()
            ElseIf ltname.Text = "Sales Order Report" Then
                Dim dt As New DataTable()
                dt.Columns.AddRange(New DataColumn() {New DataColumn("CustomReport_Name", GetType(String)), New DataColumn("CustomReport_Id", GetType(String))})

                Dim btnanchor As HtmlAnchor = TryCast(e.Row.FindControl("btnanchor"), HtmlAnchor)
                Dim a As String = "SalesPerformanceReportByUser.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(11))
                dt.Rows.Add("Sales Order Report", a)
                dt.Rows.Add("City Wise Sales Report", "citywisereport.aspx")
                dt.Rows.Add("Product Wise Profit/loss", "ProductWiseReport.aspx")
                dt.Rows.Add("User Wise Profit/loss", "UserWiseReport.aspx")
                grdsalesreportnew.DataSource = dt
                grdsalesreportnew.DataBind()
            Else
                grdreport.DataSource = CustomsReport.ViewReportType(ltname.Text)
                grdreport.DataBind()
            End If
        End If
    End Sub
End Class
