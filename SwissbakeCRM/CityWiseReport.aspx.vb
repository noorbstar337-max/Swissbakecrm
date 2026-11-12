
Partial Class CityWiseReport
    Inherits _PageBaseClass
    Dim MainID As Integer
    Public amount As Double = 0.0
    Public Tamount, Tqty As Double
    Public quantity As Integer = 0
    Dim quantityTotal As Object
    Dim amountTotal As Object

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                ' Dim tempDate As Date = Date.Now.AddMonths(-1).ToString("yyyy-MM-dd")
                Dim tempDate As Date = Date.Now.ToString("yyyy-MM-dd")
                Dim startOfMonth As New DateTime(tempDate.Year, tempDate.Month, 1)
                'Dim endOfMonth As DateTime = startOfMonth.AddMonths(1).AddDays(-1)
                Dim endOfMonth As DateTime = Date.Now.ToString("yyyy-MM-dd")
                txtfrom.Text = startOfMonth.ToString("yyyy-MM-dd")
                txtto.Text = endOfMonth.ToString("yyyy-MM-dd")
                pnldemo.Visible = False
                FillEmployee()
                btndashboard_Click(New Object(), New EventArgs())

                'Dim FooterTemplate As Control = rpgridview.Controls(rpgridview.Controls.Count - 1).Controls(0)
                'Dim quantityTotal As Label = TryCast(FooterTemplate.FindControl("quantityTotal"), Label)
                'quantityTotal.Text = quantity.ToString("N2") + ("Kg")
                'Dim amountTotal As Label = TryCast(FooterTemplate.FindControl("amountTotal"), Label)
                'amountTotal.Text = amount.ToString("#,##0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub FillEmployee()
        Try
            ddCity.DataSource = MainBLL.Dropdown("CityDropDown")
            ddCity.DataTextField = "AccAddr_City"
            ddCity.DataValueField = "AccAddr_City"
            ddCity.DataBind()
            ddCity.Items.Insert(0, "All")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("UserId")) 'ExpenseDetail", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btndashboard_Click(sender As Object, e As EventArgs) Handles btndashboard.Click
        pnldemo.Visible = True
        FillEmployeeDetail()
        'InOutPresentyBoxes()
    End Sub

    Public Sub FillEmployeeDetail()
        Try
            ' Dim dt As DataTable = MainBLL.ViewByDateCity(ddCity.SelectedValue, "CityWiseReportViewByID", txtfrom.Text, txtto.Text).Tables(0)
            Dim ds As DataSet = MainBLL.ViewByDateCity(ddCity.SelectedValue, "CityWiseReportViewByID1", txtfrom.Text, txtto.Text)
            Dim dt As DataTable
            dt = ds.Tables(0)
            rpgridview.DataSource = dt
            rpgridview.DataBind()

            Dim FooterTemplate As Control = rpgridview.Controls(rpgridview.Controls.Count - 1).Controls(0)
            Dim quantityTotal As Label = TryCast(FooterTemplate.FindControl("quantityTotal"), Label)
            Dim amountTotal As Label = TryCast(FooterTemplate.FindControl("amountTotal"), Label)
            
            Dim trFooter As HtmlTableRow = TryCast(FooterTemplate.FindControl("trFooter"), HtmlTableRow)

            If ds.Tables(0).Rows.Count > 0 Then
                lblfoot.Visible = False
                divsumary.Visible = True
                quantityTotal.Text = dt.Compute("sum(Quantity)", String.Empty)
                amountTotal.Text = CDbl(dt.Compute("sum(OrDetail_Amount)", String.Empty)).ToString("N2")
            Else
                lblfoot.Visible = True
                divsumary.Visible = False
                trFooter.Visible = False
            End If

            'If dt.Rows.Count > 0 Then
            '    divsumary.Visible = True
            'Else
            '    lblfoot.Visible = True
            '    divsumary.Visible = False

            'End If


            Dim dt1 As New DataTable
            dt1 = ds.Tables(0)
         
            Tamount = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(dt1.Compute("SUM(OrDetail_Amount)", String.Empty)))
            lblamt.Text = Tamount.ToString("N2")
            Tqty = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(dt1.Compute("SUM(Quantity)", String.Empty)))
            lblqty.Text = Tqty.ToString("N2")

            'Else
            '    rpgridview.DataSource = MainBLL.ViewByIDByDate(txtfrom.Text, txtto.Text, "EmployeeReportViewByID", Session("UserId"))
            '    rpgridview.DataBind()
            '    InOutPresentyBoxesUser()
            'End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("UserId")) 'ExpenseDetail", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub rpgridview_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rpgridview.ItemDataBound
        Try

            'If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
            '    Dim ltqty As Literal = DirectCast(e.Item.FindControl("ltqty"), Literal)
            '    Dim ltamount As Literal = DirectCast(e.Item.FindControl("ltamount"), Literal)
            '    ltqty.Text = ltqty.Text.Replace("Kg", "")
            '    amount = amount + ltamount.Text
            '    quantity = quantity + ltqty.Text
            '    lblamt.Text = amount.ToString("#,##0.00")
            '    lblqty.Text = quantity.ToString("N2")
            'End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try

            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=City Wise Report.xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            Dim Gridview2 As New GridView

            Dim dt As New DataSet()
            'dt = MainBLL.SearchGridViewByID(txtSearch.Text.Trim, Session("UserId"), hfExcel.Value)
            dt = MainBLL.ViewByDateCity(ddCity.SelectedValue, "CityWiseReportViewByID1", txtfrom.Text, txtto.Text)
            'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" Then
            'If txtSearch.Text <> "" Then
            '    dt = DirectCast(Session("dt2A"), DataTable)
            'Else
            '    dt = DirectCast(Session("dt1A"), DataTable)
            'End If

            Dim dtExc As DataTable = dt.Tables(0)
            dtExc.Columns.Remove("Order_ID")
            'dtExc.Columns.Remove("U_ID")
            'dtExc.Columns.Remove("Industry_Name")
            'dtExc.Columns.Remove("Industry_Id")
            'dtExc.Columns.Remove("Order_CustId")
            ''dtExc.Columns.Remove("RowNumber")
            dtExc.Columns("RowNumber").ColumnName = "Sr No."
            dtExc.Columns("Order_Code").ColumnName = "Order No."
            dtExc.Columns("U_FirstName").ColumnName = "Employee Name"
            dtExc.Columns("Product_Name").ColumnName = "Product Name"
            dtExc.Columns("Quantity").ColumnName = "Quantity (KG)"
            dtExc.Columns("OrDetail_Amount").ColumnName = "Amount"
            'dtExc.Columns("Order_Freight").ColumnName = "Freight (Rs)"
            'dtExc.Columns("TotalAmount").ColumnName = "Total (Rs)"
            'dtExc.Columns("Owner").ColumnName = "Owner"
            'dtExc.Columns("AssignTo").ColumnName = "Assignto"
            'dtExc.Columns("Order_OrderStatus").ColumnName = "Status"
            'dtExc.Columns("From").SetOrdinal(1)
            'dtExc.Columns("Qty.").SetOrdinal(4)
            'dtExc.Columns("Owner").SetOrdinal(9)
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