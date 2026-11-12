
Partial Class OrderReport
    Inherits System.Web.UI.Page
    Public TQty, TProfit, TSales, TCost, TQtyCancel, TSalesCancel, TQtyTot, TSalesTot As Double

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        Else
            'CheckPrivilage()
        End If
        If Session("UserRoleID") <> 1 Then
           ' Response.Redirect("index.aspx")
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim tempDate As Date = Date.Now.ToString("yyyy-MM-dd")
                'Dim tempDate As Date = Date.Now.AddMonths(-1).ToString("yyyy-MM-dd")
                Dim startOfMonth As New DateTime(tempDate.Year, tempDate.Month, 1)
                Dim endOfMonth As DateTime = Date.Now.ToString("yyyy-MM-dd")
                'Dim endOfMonth As DateTime = startOfMonth.AddMonths(1).AddDays(-1)
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
            Dim dsNew As DataSet = reportBLL.FillOrderReport("OrderReport", txtfrom.Text, txtto.Text, ddluser.SelectedValue, ddlBy.SelectedValue)
            'rpOrderReport.DataSource = reportBLL.FillOrderReport("OrderWiseReport", txtfrom.Text, txtto.Text, ddluser.SelectedValue, ddlBy.SelectedValue)
            Dim dtNew As New DataTable
            dtNew = dsNew.Tables(0)
            rpOrderReport.DataSource = dtNew
            rpOrderReport.DataBind()

            Dim FooterTemplate As Control = rpOrderReport.Controls(rpOrderReport.Controls.Count - 1).Controls(0)
            Dim lblQty As Label = TryCast(FooterTemplate.FindControl("lblQty"), Label)
            Dim lblAmount As Label = TryCast(FooterTemplate.FindControl("lblAmount"), Label)
            Dim lblGST As Label = TryCast(FooterTemplate.FindControl("lblGST"), Label)
            Dim lblFreight As Label = TryCast(FooterTemplate.FindControl("lblFreight"), Label)
            Dim lblAmountTot As Label = TryCast(FooterTemplate.FindControl("lblAmountTot"), Label)
            Dim trFooter As HtmlTableRow = TryCast(FooterTemplate.FindControl("trFooter"), HtmlTableRow)

            If dsNew.Tables(0).Rows.Count > 0 Then
                tblGrid.Visible = True
                lblQty.Text = dtNew.Compute("Sum(Kg)", String.Empty)
                lblAmount.Text = CDbl(dtNew.Compute("Sum(Order_Amount)", String.Empty)).ToString("N2")
                lblGST.Text = CDbl(dtNew.Compute("Sum(Order_TotalVat)", String.Empty)).ToString("N2")
                lblFreight.Text = CDbl(dtNew.Compute("Sum(Order_Freight)", String.Empty)).ToString("N2")
                lblAmountTot.Text = CDbl(dtNew.Compute("Sum(TotalAmount)", String.Empty)).ToString("N2")
                lblfoot.Visible = False
            Else
                tblGrid.Visible = False
                trFooter.Visible = False
                lblfoot.Visible = True
            End If
            'quantityTotal.Text = quantit1.ToString("N3") + ("Kg")
            'Dim amountTotal As Label = TryCast(FooterTemplate.FindControl("amountTotal"), Label)
            'amountTotal.Text = amount1.ToString("#,##0.00")

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

            Dim ds As DataSet = reportBLL.FillOrderReport("OrderReportTotal", txtfrom.Text, txtto.Text, ddluser.SelectedValue, ddlBy.SelectedValue)
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
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try

            Dim dt As New DataSet()
            dt = reportBLL.FillOrderReport("OrderReport", txtfrom.Text, txtto.Text, ddluser.SelectedValue, ddlBy.SelectedValue)
            Dim dtExc As DataTable = dt.Tables(0)
            If dtExc.Rows.Count > 0 Then

                Response.Clear()
                Response.Buffer = True
                Response.AddHeader("content-disposition", "attachment;filename=Order Report.xls")
                Response.Charset = ""
                Response.ContentType = "application/vnd.ms-excel"
                Dim sw As New StringWriter()
                Dim hw As New HtmlTextWriter(sw)

                Dim Gridview2 As New GridView

                'dt = MainBLL.SearchGridViewByID(txtSearch.Text.Trim, Session("UserId"), hfExcel.Value)
                'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" Then
                'If txtSearch.Text <> "" Then
                '    dt = DirectCast(Session("dt2A"), DataTable)
                'Else
                '    dt = DirectCast(Session("dt1A"), DataTable)
                'End If

                dtExc.Columns.Remove("Order_ID")
                dtExc.Columns.Remove("U_ID")
                dtExc.Columns.Remove("Industry_Name")
                dtExc.Columns.Remove("Industry_Id")
                dtExc.Columns.Remove("Order_CustId")
                'dtExc.Columns.Remove("RowNumber")
                dtExc.Columns("Order_type").ColumnName = "From"
                dtExc.Columns("Order_Code").ColumnName = "Order No."
                dtExc.Columns("Acc_Name").ColumnName = "Account Name"
                dtExc.Columns("Kg").ColumnName = "Qty."
                dtExc.Columns("Order_Amount").ColumnName = "Amount (Rs)"
                dtExc.Columns("Order_TotalVat").ColumnName = "GST (Rs)"
                dtExc.Columns("Order_Freight").ColumnName = "Freight (Rs)"
                dtExc.Columns("TotalAmount").ColumnName = "Total (Rs)"
                dtExc.Columns("Owner").ColumnName = "Owner"
                dtExc.Columns("AssignTo").ColumnName = "Assignto"
                dtExc.Columns("Order_OrderStatus").ColumnName = "Status"
                dtExc.Columns("Qty.").SetOrdinal(4)
                dtExc.Columns("From").SetOrdinal(10)
                dtExc.Columns("Owner").SetOrdinal(11)
                dtExc.Columns("Assignto").SetOrdinal(12)

                Gridview2.DataSource = dtExc
                Gridview2.AllowPaging = False
                Gridview2.DataBind()
                Gridview2.RenderControl(hw)

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
            Else
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + "No Data Found" + "')", True)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class


