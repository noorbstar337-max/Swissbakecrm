
Partial Class OrderWiseReport
    Inherits System.Web.UI.Page
    Public TQty, TProfit, TSales, TCost, TQtyCancel, TSalesCancel, TQtyTot, TSalesTot As Double

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        Else
            'CheckPrivilage()
        End If
        If Session("UserRoleID") <> 1 Then
            Response.Redirect("index.aspx")
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim tempDate As Date = Date.Now.AddMonths(-1).ToString("yyyy-MM-dd")
                Dim startOfMonth As New DateTime(tempDate.Year, tempDate.Month, 1)
                Dim endOfMonth As DateTime = startOfMonth.AddMonths(1).AddDays(-1)
                txtfrom.Text = startOfMonth.ToString("yyyy-MM-dd")
                txtto.Text = endOfMonth.ToString("yyyy-MM-dd")
                'ddluser.SelectedValue = Session("UserId")
                FillUserName()
                FillOrderGrid()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub FillUserName()
        Try
            Dim ds As DataSet = MainBLL.Dropdown("UserDropDown")
            ddluser.DataSource = ds.Tables(0)
            ddluser.DataTextField = "U_FirstName"
            ddluser.DataValueField = "U_ID"
            ddluser.DataBind()
            ddluser.Items.Insert(0, New ListItem("All", "0"))
            ddluser.SelectedValue = 0
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            FillOrderGrid()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillOrderGrid()
        Try
            Dim dsNew As DataSet = reportBLL.FillOrderReport("OrderWiseReport", txtfrom.Text, txtto.Text, ddluser.SelectedValue, ddlBy.SelectedValue)
            'rpOrderReport.DataSource = reportBLL.FillOrderReport("OrderWiseReport", txtfrom.Text, txtto.Text, ddluser.SelectedValue, ddlBy.SelectedValue)
            Dim dtNew As New DataTable
            dtNew = dsNew.Tables(0)
            rpOrderReport.DataSource = dtNew
            rpOrderReport.DataBind()

            Dim dtNew1 As New DataTable
            dtNew1 = dsNew.Tables(1)
            Dim drLoginNew1 As DataRow
            drLoginNew1 = dtNew1.Rows(0)
            TSales = DynamicparcelDataManipulation.FixNullFromDB(drLoginNew1("TotalSales"))
            lblamtOrder.Text = TSales.ToString("N2")

            Dim dtNew2 As New DataTable
            dtNew2 = dsNew.Tables(2)
            Dim drLoginNew2 As DataRow
            drLoginNew2 = dtNew2.Rows(0)
            TSalesCancel = DynamicparcelDataManipulation.FixNullFromDB(drLoginNew2("TotalSales"))
            lblamtCancel.Text = TSalesCancel.ToString("N2")

            Dim dtNew3 As New DataTable
            dtNew3 = dsNew.Tables(3)
            Dim drLoginNew3 As DataRow
            drLoginNew3 = dtNew3.Rows(0)
            TSalesTot = DynamicparcelDataManipulation.FixNullFromDB(drLoginNew3("TotalSales"))
            lblamtTotal.Text = TSalesTot.ToString("N2")

            Dim ds As DataSet = reportBLL.FillOrderReport("OrderWiseReportTotal", txtfrom.Text, txtto.Text, ddluser.SelectedValue, ddlBy.SelectedValue)
            Dim dt As New DataTable
            dt = ds.Tables(0)
            Dim drLogin As DataRow
            drLogin = dt.Rows(0)
            TQty = DynamicparcelDataManipulation.FixNullFromDB(drLogin("TotalQuantity"))
            'TSales = DynamicparcelDataManipulation.FixNullFromDB(drLogin("TotalSales"))
            lblqtyOrder.Text = TQty.ToString("N2")
            'lblamtOrder.Text = TSales.ToString("N2")
            Dim dt1 As New DataTable
            dt1 = ds.Tables(1)
            Dim drLogin1 As DataRow
            drLogin1 = dt1.Rows(0)
            TQtyCancel = DynamicparcelDataManipulation.FixNullFromDB(drLogin1("TotalQuantity"))
            'TSalesCancel = DynamicparcelDataManipulation.FixNullFromDB(drLogin1("TotalSales"))
            lblqtyCancel.Text = TQtyCancel.ToString("N2")
            'lblamtCancel.Text = TSalesCancel.ToString("N2")
            Dim dt2 As New DataTable
            dt2 = ds.Tables(2)
            Dim drLogin2 As DataRow
            drLogin2 = dt2.Rows(0)
            TQtyTot = DynamicparcelDataManipulation.FixNullFromDB(drLogin2("TotalQuantity"))
            'TSalesTot = DynamicparcelDataManipulation.FixNullFromDB(drLogin2("TotalSales"))
            lblqtyTotal.Text = TQtyTot.ToString("N2")
            'lblamtTotal.Text = TSalesTot.ToString("N2")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub rpOrderReport_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rpOrderReport.ItemDataBound
        Try
            If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
                Dim tdOrdBy As HtmlTableCell = DirectCast(e.Item.FindControl("tdOrdBy"), HtmlTableCell)
                If ddlBy.SelectedValue = "All" Then
                    thOrdBy.Visible = True
                    tdOrdBy.Visible = True
                Else
                    thOrdBy.Visible = False
                    tdOrdBy.Visible = False
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class

