Imports DynamicparcelEnumerations
Partial Class ProductList
     Inherits _PageBaseClass
    Private MainId As Integer
    Dim ParentiD As String
    Private ProductId As Integer
    Dim result As Integer
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
                fillProduct()
                SearchControl.Uhfadd.Visible = False
                SearchControl.ULkadd.Visible = False
                SearchControl.Uddpagesize.Visible = False
                SearchControl.UbtnExportExcel.Visible = False
                SearchControl.UbtnExportWord.Visible = False
                SearchControl.Ubtnshowall.Visible = False

                SearchControl.UhfExcelName.Value = "ProductListDetails"
                SearchControl.Uhfgridviewmode.Value = "FillProductGrid"
                SearchControl.Uhfsearchmode.Value = "ProductListSearch"
                SearchControl.UhfExcelmode.Value = "ProductListExcel"
				SearchControl.Uhftotalcount.Value = "ProductListTotalNumberOfRecord"
			End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    'Public Sub CheckPrivilage()
    '    Try
    '        Dim dt As DataSet = PrivilageBLL.CheckPrivilige(Session("UserRoleID"), "ProductList.aspx")
    '        Dim dtprivilage As New DataTable
    '        dtprivilage = dt.Tables(0)
    '        Dim drprivilage As DataRow
    '        If dtprivilage.Rows.Count = 0 Then
    '            SearchControl.Uhfadd.Visible = False
    '            GridView1.Columns(0).Visible = False
    '            SearchControl.ULkadd.Visible = False
    '        Else
    '            drprivilage = dtprivilage.Rows(0)
    '            If (drprivilage("Prvg_RAdd").ToString()) = True Then
    '                SearchControl.Uhfadd.Visible = True
    '                SearchControl.ULkadd.Visible = True
    '            Else
    '                SearchControl.Uhfadd.Visible = False
    '                SearchControl.ULkadd.Visible = False
    '            End If
    '            If (drprivilage("Prvg_RUpdate").ToString()) = True Then
    '                GridView1.Columns(0).Visible = True
    '            Else
    '                GridView1.Columns(0).Visible = False
    '            End If
    '            Response.Redirect("index.aspx")
    '        End If
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert("Lead", "CheckPrivilage", error1, Session("UserId"))
    '        'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '        Throw ex
    '    End Try
    'End Sub
    Public Sub fillProduct()
        Try
            GridView1.VirtualItemCount = MainBLL.TotalRowInGridview("ProductListTotalNumberOfRecord")
			GridView1.DataSource = ProductBLL.FillGrid("0", 10, "FillProductGrid", ddtype.SelectedValue)
			GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub IndexfillUser()
        Try
            GridView1.DataSource = MainBLL.FillGridView(GridView1.PageIndex, SearchControl.Uddpagesize.SelectedValue, "FillProductGrid")
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub txtCostPerKG_TextChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In GridView1.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim txtPrdrate As Label = DirectCast(row.FindControl("txtPrdrate"), Label)
                Dim txtCostPerKG As TextBox = DirectCast(row.FindControl("txtCostPerKG"), TextBox)
                Dim lblMargin As Label = DirectCast(row.FindControl("lblMargin"), Label)
                Dim txtMarginPercent As TextBox = DirectCast(row.FindControl("txtMarginPercent"), TextBox)
                If Convert.ToDouble(txtCostPerKG.Text) > Convert.ToDouble(txtPrdrate.Text) Then
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Cost price must be less than selling price')", True)
                    txtCostPerKG.Text = txtPrdrate.Text
                End If
                If txtCostPerKG.Text = "" Or txtMarginPercent.Text = "" Then
                    txtCostPerKG.Text = 0
                    txtMarginPercent.Text = 0
                    lblMargin.Text = Convert.ToDouble(Convert.ToDouble(txtMarginPercent.Text) + Convert.ToDouble(txtCostPerKG.Text)).ToString("N2")
                    txtMarginPercent.Text = Convert.ToDouble(Convert.ToDouble(lblMargin.Text) - Convert.ToDouble(txtCostPerKG.Text)).ToString("N2")
                Else
                    lblMargin.Text = Convert.ToDouble((Convert.ToDouble(txtCostPerKG.Text) * Convert.ToDouble(txtMarginPercent.Text) * 0.01) + Convert.ToDouble(txtCostPerKG.Text)).ToString("N2")
                End If
            End If
        Next
    End Sub
    Public Sub txtMarginPercent_TextChanged(sender As Object, e As EventArgs)
        '  For Each row As GridViewRow In GridView1.Rows
        '  If row.RowType = DataControlRowType.DataRow Then
        Dim rd As TextBox = DirectCast(sender, TextBox)
        Dim row As GridViewRow = DirectCast(rd.NamingContainer, GridViewRow)
        Dim txtMarginPercent As TextBox = TryCast(row.FindControl("txtMarginPercent"), TextBox)
        Dim txtCostPerKG As TextBox = TryCast(row.FindControl("txtCostPerKG"), TextBox)
        Dim lblMargin As Label = TryCast(row.FindControl("lblMargin"), Label)
        '  Dim rfmargin As CustomValidator = TryCast(row.FindControl("rfmargin"), CustomValidator)
        'Dim txtCostPerKG As TextBox = DirectCast(row.FindControl("txtCostPerKG"), TextBox)
        'Dim lblMargin As Label = DirectCast(row.FindControl("lblMargin"), Label)
        'Dim txtMarginPercent As TextBox = DirectCast(row.FindControl("txtMarginPercent"), TextBox)
        If txtMarginPercent.Text = "" Then
            txtMarginPercent.Text = Convert.ToDouble(lblMargin.Text - txtCostPerKG.Text).ToString("N2")
        Else
            lblMargin.Text = Convert.ToDouble((Convert.ToDouble(txtCostPerKG.Text) * 0.01 * Convert.ToDouble(txtMarginPercent.Text)) + txtCostPerKG.Text).ToString("N2")

            'Dim sp As Double = 0.0
            'sp = (100 / (100 - CDbl(txtMarginPercent.Text))) * CDbl(txtCostPerKG.Text)
            'lblMargin.Text = (Math.Round(sp)).ToString("N2")
            If lblMargin.Text > txtCostPerKG.Text Then
                'rfmargin.Enabled = True

                'rfmargin.ErrorMessage = "Cannot be greater than product rate"
                'rfmargin.Display = ValidatorDisplay.Dynamic
                'rfmargin.ForeColor = Drawing.Color.DarkRed

            End If
        End If
        ' End If
        ' Next
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            If SearchControl.UtxtSearch.Text = "" Then
                GridView1.PageIndex = e.NewPageIndex
                GridView1.DataSource = MainBLL.FillGridView(e.NewPageIndex, SearchControl.Uddpagesize.SelectedValue, "FillProductGrid")
                GridView1.DataBind()
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
            Else
                GridView1.PageIndex = e.NewPageIndex
                SearchFillUser()
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
	Protected Sub ddpagesize_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchControl.SelectedIndexChanged
		Try
			If SearchControl.Uddpagesize.SelectedItem.Text <> "0" Then
				GridView1.PageSize = SearchControl.Uddpagesize.SelectedValue.ToString()
				IndexfillUser()
				ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
			End If
		Catch ex As Exception
			Dim error1 As String = ex.Message.Replace(Chr(34), "")
			error1 = error1.Replace(Chr(39), "")
			ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
		End Try
	End Sub
	Public Sub SearchFillUser()
        Try
            GridView1.DataSource = MainBLL.SearchGridView(SearchControl.UtxtSearch.Text.Trim, "ProductListSearch")
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim txtCostPerKG As TextBox = DirectCast(e.Row.FindControl("txtCostPerKG"), TextBox)
                Dim txtMarginPercent As TextBox = DirectCast(e.Row.FindControl("txtMarginPercent"), TextBox)
                Dim lblMargin As Label = DirectCast(e.Row.FindControl("lblMargin"), Label)

                If txtMarginPercent.Text = "" Or txtCostPerKG.Text = "" Then
                    txtMarginPercent.Text = 0
                    txtCostPerKG.Text = 0
                End If
                lblMargin.Text = Convert.ToDouble((Convert.ToDouble(txtCostPerKG.Text) * Convert.ToDouble(txtMarginPercent.Text) * 0.01) + Convert.ToDouble(txtCostPerKG.Text)).ToString("N2")

            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
	Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
		For Each row As GridViewRow In GridView1.Rows
			If row.RowType = DataControlRowType.DataRow Then
				Dim txtPrdrate As Label = DirectCast(row.FindControl("txtPrdrate"), Label)
				Dim txtCostPerKG As TextBox = DirectCast(row.FindControl("txtCostPerKG"), TextBox)
				Dim lblMargin As Label = DirectCast(row.FindControl("lblMargin"), Label)
				Dim txtMarginPercent As TextBox = DirectCast(row.FindControl("txtMarginPercent"), TextBox)
				Dim lblproductid As Label = DirectCast(row.FindControl("lblproductid"), Label)
				If txtPrdrate.Text = "" Or txtCostPerKG.Text = "" Then
					txtPrdrate.Text = 0
					txtCostPerKG.Text = 0
				End If
				If Convert.ToDouble(txtCostPerKG.Text) > Convert.ToDouble(txtPrdrate.Text) Then
					ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Cost price must be less than sailing price')", True)
				End If
				result = ProductBLL.Update(Convert.ToDouble(txtPrdrate.Text).ToString("N2"), Convert.ToDouble(txtCostPerKG.Text).ToString("N2"), Session("UserId"), Convert.ToInt32(lblproductid.Text), Convert.ToInt64(Session("Audlog_Id")), Convert.ToDouble(txtMarginPercent.Text).ToString("N2"))
				If result > 0 Then
					ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Updated Successfully')", True)
					fillProduct()
				End If
			End If
		Next

	End Sub
	Private Sub ddtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddtype.SelectedIndexChanged
		txtsearch.Text = ""
		fillProduct()
	End Sub
	Public Sub FillSearch()
		Try
			GridView1.DataSource = MainBLL.SearchGridView(txtsearch.Text.Trim, "ProductListSearch", ddtype.SelectedValue, Session("UserID"))
			GridView1.DataBind()
		Catch ex As Exception
			Dim error1 As String = ex.Message.Replace(Chr(34), "")
			error1 = error1.Replace(Chr(39), "")
			ExecptionBLL.Insert("SearchControl", "FillSearch", error1, Session("UserId"))
			ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
		End Try
	End Sub

	Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
		If txtsearch.Text = "" Then
			fillProduct()
		Else
			FillSearch()
		End If
	End Sub
End Class
