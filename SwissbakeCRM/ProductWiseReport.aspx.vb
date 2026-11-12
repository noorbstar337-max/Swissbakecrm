
Partial Class ProductWiseReport
    Inherits System.Web.UI.Page
    Public TQty, TProfit, TSales, TCost As Double
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        Else
            'CheckPrivilage()
        End If
        If Session("UserId") <> 1 Then
            Response.Redirect("index.aspx")
        End If
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                'Dim tempDate As Date = Date.Now.AddMonths(-1).ToString("yyyy-MM-dd")
                Dim tempDate As Date = Date.Now.ToString("yyyy-MM-dd")
                Dim startOfMonth As New DateTime(tempDate.Year, tempDate.Month, 1)
                ' Dim endOfMonth As DateTime = startOfMonth.AddMonths(1).AddDays(-1)
                Dim endOfMonth As DateTime = Date.Now.ToString("yyyy-MM-dd")
                txtfrom.Text = startOfMonth.ToString("yyyy-MM-dd")
                txtto.Text = endOfMonth.ToString("yyyy-MM-dd")
                pnldemo.Visible = False
                ddCategory.Items.Insert(0, "All")
                ddProduct.Items.Insert(0, "All")
            
                FillCategory()
                FillProductGrid()
                'Dim FooterTemplate As Control = rpgridview.Controls(rpgridview.Controls.Count - 1).Controls(0)
                'Dim quantityTotal As Label = TryCast(FooterTemplate.FindControl("quantityTotal"), Label)
                'TotalRate.Text = Rate.ToString("#,##0.00")
                'Dim amountTotal As Label = TryCast(FooterTemplate.FindControl("amountTotal"), Label)
                'TotalCost.Text = Cost.ToString("#,##0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub FillCategory()
        Try
            ddCategory.DataSource = MainBLL.Dropdown("CategoryDropDown")
            ddCategory.DataTextField = "PrdCategory_Name"
            ddCategory.DataValueField = "PrdCategory_ID"
            ddCategory.DataBind()
            ddCategory.Items.Insert(0, "All")
            ddProduct.Items.Insert(0, "All")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("UserId")) 'ExpenseDetail", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub FillProduct()
        Try
            ddProduct.DataSource = MainBLL.Dropdown("ProductByCategoryDropDown", ddCategory.SelectedValue)
            ddProduct.DataTextField = "Product_Name"
            ddProduct.DataValueField = "Product_Id"
            ddProduct.DataBind()
            ddProduct.Items.Insert(0, "All")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("UserId")) 'ExpenseDetail", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub FillProductGrid()
        Try
            Dim ds As DataSet
            If ddCategory.SelectedValue = "All" Then

                ds = reportBLL.FillProductGrid(txtfrom.Text, txtto.Text, 0)
                rpgridview.DataSource = ds
            Else
                If ddProduct.SelectedValue = "All" Then
                    ds = reportBLL.FillProductGrid(txtfrom.Text, txtto.Text, ddCategory.SelectedValue, 0)
                    rpgridview.DataSource = ds
                Else
                    ds = reportBLL.FillProductGrid(txtfrom.Text, txtto.Text, ddCategory.SelectedValue, ddProduct.SelectedValue)
                    rpgridview.DataSource = ds
                End If
            End If

            rpgridview.DataBind()

            Dim FooterTemplate As Control = rpgridview.Controls(rpgridview.Controls.Count - 1).Controls(0)
            Dim lblmrp As Label = TryCast(FooterTemplate.FindControl("lblmrp"), Label)
            Dim lblcostprice As Label = TryCast(FooterTemplate.FindControl("lblcostprice"), Label)
            Dim lblmargin As Label = TryCast(FooterTemplate.FindControl("lblmargin"), Label)
            Dim lblminselprice As Label = TryCast(FooterTemplate.FindControl("lblminselprice"), Label)
            Dim lblselprice As Label = TryCast(FooterTemplate.FindControl("lblselprice"), Label)
            Dim lblqty As Label = TryCast(FooterTemplate.FindControl("lblqty"), Label)
            Dim lblprofit As Label = TryCast(FooterTemplate.FindControl("lblprofit"), Label)
            Dim lbltotal As Label = TryCast(FooterTemplate.FindControl("lbltotal"), Label)
            Dim trFooter As HtmlTableRow = TryCast(FooterTemplate.FindControl("trFooter"), HtmlTableRow)

            If ds.Tables(0).Rows.Count > 0 Then
                tblGrid.Visible = True
                lblmrp.Text = CDbl(ds.Tables(0).Compute("Sum(Product_Rate)", String.Empty)).ToString("N2")
                lblcostprice.Text = CDbl(ds.Tables(0).Compute("Sum(OrDetail_ProductCost)", String.Empty)).ToString("N2")
                lblmargin.Text = CDbl(ds.Tables(0).Compute("Sum(Product_Margin)", String.Empty)).ToString("N2")
                lblminselprice.Text = CDbl(ds.Tables(0).Compute("Sum(MinSP)", String.Empty)).ToString("N2")
                lblselprice.Text = CDbl(ds.Tables(0).Compute("Sum(OrDetail_Rate)", String.Empty)).ToString("N2")
                lblqty.Text = ds.Tables(0).Compute("Sum(OrDetail_Qty)", String.Empty)
                lblprofit.Text = CDbl(ds.Tables(0).Compute("Sum(Profit)", String.Empty)).ToString("N2")
                lbltotal.Text = CDbl(ds.Tables(0).Compute("Sum(TotalSales)", String.Empty)).ToString("N2")

            Else
                tblGrid.Visible = False
                trFooter.Visible = False
                lblfoot.Visible = True
            End If

            pnldemo.Visible = True
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("UserId")) 'ExpenseDetail", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub btndashboard_Click(sender As Object, e As EventArgs) Handles btndashboard.Click
        pnldemo.Visible = True
        FillProductGrid()
    End Sub

    Protected Sub ddCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddCategory.SelectedIndexChanged
        ddProduct.Visible = True
        lblProd.Visible = True
        lblProd.InnerText = "Product"

        If (ddCategory.SelectedIndex = 0) Then

            ddProduct.SelectedIndex = 0
            ddProduct.Visible = False
            lblProd.Visible = False
        Else

            FillProduct()
        End If
    End Sub
    Protected Sub rpgridview_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rpgridview.ItemDataBound
        Try

            Dim Qty As Double = 0.0
            Dim Profit As Double = 0.0
            Dim Sales As Double = 0.0
            Dim Cost As Double = 0.0
            If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
                Qty += Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "OrDetail_Qty"))
                Profit += Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Profit"))
                Sales += Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "TotalSales"))
                Cost += Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "TotalCost"))
              

                TQty = TQty + Qty
                TProfit = TProfit + Profit
                TSales = TSales + Sales
                TCost = TCost + Cost
            End If
			'If (e.Item.ItemType = ListItemType.Footer) Then
			'    Dim TotalQty As Label = DirectCast(e.Item.FindControl("TotalQty"), Label)
			'    Dim TotalProfit As Label = DirectCast(e.Item.FindControl("TotalProfit"), Label)
			'    Dim TotalSales As Label = DirectCast(e.Item.FindControl("TotalSales"), Label)
			'    Dim TotalCost As Label = DirectCast(e.Item.FindControl("TotalCost"), Label)

			'    TotalQty.Text = TQty.ToString("N2")
			'    TotalProfit.Text = TProfit.ToString("N2")
			'    TotalSales.Text = TSales.ToString("N2")
			'    TotalCost.Text = TCost.ToString("N2")

			'End If
			lblamt.Text = TSales.ToString("N2")
            lblqty.Text = TQty.ToString("N2")
            lblProfit.Text = TProfit.ToString("N2")
            '            lblCost.Text = TCost.ToString("N2")
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try

            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=Product Wise Report.xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            Dim Gridview2 As New GridView

            Dim dt As New DataSet()
            'dt = MainBLL.SearchGridViewByID(txtSearch.Text.Trim, Session("UserId"), hfExcel.Value)
            If ddCategory.SelectedValue = "All" Then
                dt = reportBLL.FillProductGrid(txtfrom.Text, txtto.Text, 0)
            Else
                If ddProduct.SelectedValue = "All" Then
                    dt = reportBLL.FillProductGrid(txtfrom.Text, txtto.Text, ddCategory.SelectedValue, 0)
                Else
                    dt = reportBLL.FillProductGrid(txtfrom.Text, txtto.Text, ddCategory.SelectedValue, ddProduct.SelectedValue)
                End If
            End If
            'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" Then
            'If txtSearch.Text <> "" Then
            '    dt = DirectCast(Session("dt2A"), DataTable)
            'Else
            '    dt = DirectCast(Session("dt1A"), DataTable)
            'End If

            Dim dtExc As DataTable = dt.Tables(0)
            dtExc.Columns.Remove("Product_Id")
            dtExc.Columns.Remove("Product_CategoryId")
            dtExc.Columns.Remove("TotalCost")
            dtExc.Columns("RowNumber").ColumnName = "Sr No."
            dtExc.Columns("Product_Name").ColumnName = "Product Name"
            dtExc.Columns("Product_Rate").ColumnName = "MRP"
            dtExc.Columns("OrDetail_ProductCost").ColumnName = "Cost Price"
            dtExc.Columns("Product_Margin").ColumnName = "Margin"
            dtExc.Columns("MinSP").ColumnName = "Min Selling Price"
            dtExc.Columns("OrDetail_Rate").ColumnName = "Selling Price"
            dtExc.Columns("OrDetail_Qty").ColumnName = "Quantity(KG)"
            dtExc.Columns("Profit").ColumnName = "Profit/Loss (Rs)"
            dtExc.Columns("TotalSales").ColumnName = "Total Sales (Rs)"
            'dtExc.Columns("Order_Freight").ColumnName = "Freight (Rs)"
            'dtExc.Columns("TotalAmount").ColumnName = "Total (Rs)"
            'dtExc.Columns("Owner").ColumnName = "Owner"
            'dtExc.Columns("AssignTo").ColumnName = "Assignto"
            'dtExc.Columns("Order_OrderStatus").ColumnName = "Status"
            'dtExc.Columns("From").SetOrdinal(1)
            dtExc.Columns("Margin").SetOrdinal(4)
            dtExc.Columns("Min Selling Price").SetOrdinal(5)
            'dtExc.Columns("Assignto").SetOrdinal(10)

            Gridview2.DataSource = dtExc
            'Gridview2.DataBind()
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

        Catch ex As Exception

        End Try
    End Sub
End Class