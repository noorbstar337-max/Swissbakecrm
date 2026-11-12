Imports System.Data

Partial Class TopProduct
    Inherits System.Web.UI.Page
    Dim MainID As Integer
    Dim ds1 As New DataSet()
    Private dt1 As New DataTable()
    Private dt2 As New DataTable()
    Private dt3 As New DataTable()
    Private pgitems As New PagedDataSource()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim tempDate As Date = Date.Now.ToString("yyyy-MM-dd")
                Dim startOfMonth As New DateTime(tempDate.Year, tempDate.Month, 1)
                Dim endOfMonth As DateTime = Date.Now.ToString("yyyy-MM-dd")
                txtfrom.Text = startOfMonth.ToString("yyyy-MM-dd")
                txtto.Text = endOfMonth.ToString("yyyy-MM-dd")
                FillddlProduct()
                BindGridview()
                'txtSearch.Attributes.Add("onkeyup", [String].Format("javascript:__doPostBack('{0}','')", rpg.ClientID))
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("DSRReport", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    'Protected Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
    '    If IsPostBack Then
    '        If txtSearch.Text <> "" OrElse hfBackcount.Value = "1" Then
    '            'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" OrElse hfBackcount.Value = "1" Then
    '            getsearch()
    '            fillpage()
    '        Else
    '            fillpage()
    '        End If
    '    End If
    'End Sub
    Protected Sub BindGridview()
        Try
            ds1 = reportBLL.topproduct(ddlProduct.SelectedValue, txtfrom.Text, txtto.Text)
            'ds1 = MainBLL.FillGridView(hfgridview.Value)
            If ds1.Tables(0).Rows.Count > 0 Then
                'If ds1.Tables(0) IsNot Nothing Then
                dt1 = ds1.Tables(0)
                'rpgridview.DataSource = dt1
                'rpgridview.DataBind()
            End If
            dt3 = dt1
            Session("dt1TopProd") = dt1

            fillpage()
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Binding Account'" + ex.Message + ")", True)
        End Try
    End Sub
    'Public Sub getsearch()
    '    Try

    '        'date time column not working in search and footer
    '        dt2 = DirectCast(Session("dt1TopProd"), DataTable)


    '        If txtSearch.Text <> "" Then
    '            Dim selectedTable1 As DataTable = dt2.AsEnumerable().Where(Function(r) (r.Field(Of String)("Acc_Code").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
    '                       (r.Field(Of String)("Acc_Name").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
    '                        (r.Field(Of String)("AccAddr_City").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
    '                         (r.Field(Of String)("AssignTo").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
    '            (r.Field(Of String)("Sales_Amount").ToUpper().Contains(txtSearch.Text.ToUpper()))
    '                            ).CopyToDataTable()

    '            Session("dt2TopProd") = selectedTable1
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

    '            '    Session("dt2TopProd") = selectedTable1



    '        End If
    '    Catch ex As Exception
    '        '  Session["dt2"] = "1";
    '        Dim exception As New DataTable()
    '        exception.Clear()

    '        Session("dt2TopProd") = exception
    '    End Try
    'End Sub
    Public Sub fillpage()
        Dim dt As New DataTable()
        'If txtSearch.Text <> "" Then
        '    'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" Then
        '    dt = DirectCast(Session("dt2TopProd"), DataTable)
        'Else
        dt = DirectCast(Session("dt1TopProd"), DataTable)
        'End If
        'If dt.Rows.Count = 0 Then
        '    Dim FooterTemplate As Control = rpgridview.Controls(rpgridview.Controls.Count - 1).Controls(0)
        '    FooterTemplate.FindControl("trEmpty").Visible = True
        'Else
        If dt.Rows.Count = 0 Then
            pgitems.DataSource = dt.DefaultView
            rpgridview.DataSource = pgitems
            rpgridview.DataBind()
            'Dim FooterTemplate As Control = rpgridview.Controls(rpgridview.Controls.Count - 1).Controls(0)
            'FooterTemplate.FindControl("trEmpty").Visible = True
            'PopulatePager(0, 1)
            '' pgitems.AllowPaging = false ;

            'lblTcount.Visible = False
        Else
            pgitems.DataSource = dt.DefaultView
            'pgitems.AllowPaging = True
            'lblTcount.Visible = True
            'Count = dt.Rows.Count
            'If Count > 1 Then
            '    lblTcount.Text = Count.ToString() + " " + " records"
            'Else
            '    lblTcount.Text = Count.ToString() + " " + " record"
            'End If

            'pgitems.PageSize = Convert.ToInt32(ddpagesize.SelectedValue)
            'PopulatePager(pgitems.PageCount, PageNumber)
            'pgitems.CurrentPageIndex = PageNumber

            'tabss = PageNumber + 1
            'tab.Value = tabss.ToString()

            rpgridview.DataSource = pgitems
            rpgridview.DataBind()
        End If
        If dt.Rows.Count = Nothing Then
            tblGrid.Visible = False
            div1.Visible = False
            div2.Visible = False
            div3.Visible = False
            div4.Visible = False
        Else
            tblGrid.Visible = True
            div1.Visible = True
            div2.Visible = True
            div3.Visible = True
            div4.Visible = True
            'lblleadtotal.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Compute("SUM(qty)", "SampleRequest_Type = 'Lead'")))
            litoalquanty.Text = "Total Quantity"
            lbltoalquanty.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(dt.Compute("SUM(Totalqty)", ""))).ToString("N2")
            litotalamount.Text = "Total Amount"
            '	lbltotalamount.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(0).Compute("SUM(Rate)", ""))).ToString("N2")
            lbltotalamount.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(dt.Compute("SUM(TRate)", ""))).ToString("N2")
            div4.Visible = False
            If ddlProduct.SelectedValue = 0 Then
                litlead.Text = "Total Product"
                lblleadtotal.Text = dt.Rows.Count
            Else
                litlead.Text = ddlProduct.SelectedItem.Text
                lblleadtotal.Text = dt.Rows.Count
            End If
            If ddlProduct.SelectedValue <> 0 Then
                div4.Visible = True
                lblaverage.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(CInt(lbltotalamount.Text) / CInt(lbltoalquanty.Text))).ToString("N2")
                liaverage.Text = "Average"
            End If
        End If
        Dim FooterTemplate As Control = rpgridview.Controls(rpgridview.Controls.Count - 1).Controls(0)
        'FooterTemplate.FindControl("lblNoRecord").Visible = True
        Dim lblFProdTotalqty As Label = TryCast(FooterTemplate.FindControl("lblFProdTotalqty"), Label)
        Dim lblFProdRate As Label = TryCast(FooterTemplate.FindControl("lblFProdRate"), Label)
        If rpgridview.Items.Count > 0 Then
            lblFProdTotalqty.Text = CDbl(dt.Compute("Sum(Totalqty)", String.Empty)).ToString()
            lblFProdRate.Text = CDbl(dt.Compute("Sum(Rate)", String.Empty)).ToString()
        End If

        'End If
        ' '' '' '' '' '' ''CheckPrivilage()
    End Sub
    Public Sub fillgridview()
        Try
            rpgridview.DataSource = reportBLL.TopAccountReport("TopAccountReport", txtfrom.Text, txtto.Text)
            rpgridview.DataBind()
            Dim dt As New DataSet() '
            dt = rpgridview.DataSource
            Dim datatable As DataTable = dt.Tables(0)
            repHeader.Visible = True
            If datatable.Rows.Count = 0 Then
                Dim FooterTemplate As Control = rpgridview.Controls(rpgridview.Controls.Count - 1).Controls(0)
                FooterTemplate.FindControl("lblNoRecord").Visible = True
                repHeader.Visible = False
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            'ExecptionBLL.Insert("Activity", "fillLead", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try

    End Sub

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            'fillgridview()
            BindGridview()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            'ExecptionBLL.Insert("Activity", "fillLead", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnExportExcel_Click(sender As Object, e As ImageClickEventArgs) Handles btnExportExcel.Click
        Try
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=Top Product Report.xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)
            Dim Gridview2 As New GridView
            Dim dt As New DataSet()
            dt = reportBLL.topproduct(ddlProduct.SelectedValue, txtfrom.Text, txtto.Text)

            Dim dtExc As DataTable = dt.Tables(0)
            dtExc.Columns.Remove("Product_Id")
            dtExc.Columns.Remove("TRate")
            ''dtExc.Columns.Remove("RowNumber")
            dtExc.Columns("RowNumber").ColumnName = "Sr No."
            dtExc.Columns("Product_Name").ColumnName = "Product Name"
            dtExc.Columns("Product_Code").ColumnName = "Product Code"
            dtExc.Columns("Totalqty").ColumnName = "Total Qty"
            dtExc.Columns("Rate").ColumnName = "Product Rate"
            dtExc.Columns("Category").ColumnName = "Category Name"

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
        Catch ex As Exception

        End Try
    End Sub
  
    Public Sub FillddlProduct()
        Try
            Dim ds As DataSet
            ds = reportBLL.Dropdown("ProductDropDown")
            ddlProduct.DataSource = ds.Tables(0)
            ddlProduct.DataTextField = "Product_Name"
            ddlProduct.DataValueField = "Product_Id"
            ddlProduct.DataBind()
            ddlProduct.Items.Insert(0, New ListItem("All", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")

            Throw ex
        End Try
    End Sub
End Class
