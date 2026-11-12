
Partial Class ProductsReport
    'Inherits System.Web.UI.Page
    Inherits PageBaseClass
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                'Dim tempDate As Date = Date.Now.AddMonths(-1).ToString("yyyy-MM-dd")
                'Dim startOfMonth As New DateTime(tempDate.Year, tempDate.Month, 1)
                'Dim endOfMonth As DateTime = startOfMonth.AddMonths(1).AddDays(-1)
                'txtfrom.Text = startOfMonth.ToString("yyyy-MM-dd")
                'txtto.Text = endOfMonth.ToString("yyyy-MM-dd")
                'pnldemo.Visible = False
                'ddCategory.Items.Insert(0, "All")
                'ddProduct.Items.Insert(0, "All")
                'FillCategory()
                FillrpProdRep()
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

    Public Sub FillrpProdRep()
        Try
            Dim ds As DataSet
            Session("ProductType") = ddlProdType.SelectedValue
            '  Dim abc As String = Session("ProductType")
            ds = reportBLL.FillProdRep(ddlProdType.SelectedValue)
            rpProdRep.DataSource = ds
            rpProdRep.DataBind()

            Dim FooterTemplate As Control = rpProdRep.Controls(rpProdRep.Controls.Count - 1).Controls(0)
            Dim lblprodrate As Label = TryCast(FooterTemplate.FindControl("lblprodrate"), Label)
            Dim lblminprice As Label = TryCast(FooterTemplate.FindControl("lblminprice"), Label)
            Dim lblmaxprice As Label = TryCast(FooterTemplate.FindControl("lblmaxprice"), Label)

            If ds.Tables(0).Rows.Count > 0 Then
                lblprodrate.Text = CDbl(ds.Tables(0).Compute("Sum(Product_Rate)", String.Empty)).ToString("N2")
                lblminprice.Text = CDbl(ds.Tables(0).Compute("Sum(Min_Price)", String.Empty)).ToString("N2")
                lblmaxprice.Text = CDbl(ds.Tables(0).Compute("Sum(Max_Price)", String.Empty)).ToString("N2")
            End If

            ' Session("ProductType") = ddlProdType.SelectedValue
            'pnldemo.Visible = True
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            '  ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("UserId")) 'ExpenseDetail", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddlProdType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProdType.SelectedIndexChanged
        Try
            FillrpProdRep()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub rpProdRep_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rpProdRep.ItemCommand
        Try
            If e.CommandName = "Minimum" Then
                '  If e.Item.ItemType <> ListItemType.Item AndAlso e.Item.ItemType <> ListItemType.AlternatingItem Then
                Dim lnkMinP = e.Item.FindControl("lnkMinP")
                Dim Item As RepeaterItem = DirectCast(lnkMinP.NamingContainer, RepeaterItem)
                Dim rowIndex As Integer = Item.ItemIndex
                Dim ltProduct_Id As Label = DirectCast(rpProdRep.Items(rowIndex).FindControl("ltProduct_Id"), Label)

				'Dim ltProduct_Id = e.Item.FindControl("ltProduct_Id")
				'Dim Item As RepeaterItem = DirectCast(lnkMinP.NamingContainer, RepeaterItem)
				Response.Redirect("ProductWisePriceList.aspx?ord=a&Id=" + HttpUtility.UrlEncode(Security.Encrypt(ltProduct_Id.Text)) + "&Type=" + (Session("ProductType").ToString()))
				'End If
			ElseIf e.CommandName = "Maximum" Then
                '  If e.Item.ItemType <> ListItemType.Item AndAlso e.Item.ItemType <> ListItemType.AlternatingItem Then
                Dim lnkMinP = e.Item.FindControl("lnkMinP")
                Dim Item As RepeaterItem = DirectCast(lnkMinP.NamingContainer, RepeaterItem)
                Dim rowIndex As Integer = Item.ItemIndex
                Dim ltProduct_Id As Label = DirectCast(rpProdRep.Items(rowIndex).FindControl("ltProduct_Id"), Label)

                'Dim ltProduct_Id = e.Item.FindControl("ltProduct_Id")
                'Dim Item As RepeaterItem = DirectCast(lnkMinP.NamingContainer, RepeaterItem)
                Response.Redirect("ProductWisePriceList.aspx?ord=d&Id=" + HttpUtility.UrlEncode(Security.Encrypt(ltProduct_Id.Text)) + "&Type=" + (Session("ProductType").ToString()))
                'End If
            End If


        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try

            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=Invoice Report.xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            Dim Gridview2 As New GridView

            Dim dt As New DataSet()
            'dt = MainBLL.SearchGridViewByID(txtSearch.Text.Trim, Session("UserId"), hfExcel.Value)
            dt = reportBLL.FillProdRep(ddlProdType.SelectedValue)
            'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" Then
            'If txtSearch.Text <> "" Then
            '    dt = DirectCast(Session("dt2A"), DataTable)
            'Else
            '    dt = DirectCast(Session("dt1A"), DataTable)
            'End If

            Dim dtExc As DataTable = dt.Tables(0)
            dtExc.Columns.Remove("Product_Id")
         
            dtExc.Columns("RowNumber").ColumnName = "Sr No."
            dtExc.Columns("Product_Name").ColumnName = "Product Name"
            dtExc.Columns("Product_Rate").ColumnName = "Product Rate"
            dtExc.Columns("Min_Price").ColumnName = "Minimum Price"
            dtExc.Columns("Max_Price").ColumnName = "Maximum Price"

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
