Imports DocumentFormat.OpenXml.Bibliography
Imports DynamicparcelEnumerations
Imports Org.BouncyCastle.Asn1.Ocsp
Partial Class Crm_Discount
    Inherits _PageBaseClass
    Private discountId As Integer
    Dim margin As Double
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtflatdis.Text = ""
            btnadd.Visible = False
            divflat.Visible = False
            FillCustomer()
            CheckPrivilage()
        End If
    End Sub

    Public Sub fillUser()
        Try
            btnadd.Visible = True
            GridView1.PageIndex = 0
            GridView1.PageSize = 10
            GridView1.DataSource = MainBLL.FillGridViewDiscount("DiscountGridview", ddlcustid.SelectedValue)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs)
        SetSortDirection(SortDireaction)
        Try
            Dim dt As DataSet = MainBLL.SortingGridView("DiscountSorting", ddlcustid.SelectedValue)
            Dim DataTable As DataTable = dt.Tables(0)
            If DataTable IsNot Nothing Then
                DataTable.DefaultView.Sort = Convert.ToString(e.SortExpression) & " " & _sortDirection
                GridView1.DataSource = DataTable
                GridView1.DataBind()
                SortDireaction = _sortDirection
                Dim columnIndex As Integer = 0
                For Each headerCell As DataControlFieldHeaderCell In GridView1.HeaderRow.Cells
                    If headerCell.ContainingField.SortExpression = e.SortExpression Then
                        columnIndex = GridView1.HeaderRow.Cells.GetCellIndex(headerCell)
                    End If
                Next
                GridView1.HeaderRow.Cells(columnIndex).Controls.Add(sortImage)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub fillproduct(ByVal id As Integer)
        Dim ds As DataSet = ItemDetailBLL.ViewItemDetail(id)
        ddProduct.DataSource = ds.Tables(0)
        ddProduct.DataTextField = "Product_Name"
        ddProduct.DataValueField = "Product_Id"
        ddProduct.DataBind()
        ddProduct.Items.Insert(0, "All Product")
        'ddProduct.Items.Insert(0, New ListItem("All Product", "0"))
    End Sub
    Public Sub FillCustomer()
        Try
            'Dim ds As DataSet = MainBLL.CRMDiscountDropdown("DiscountCRMCustomerDropDown", ddtype.SelectedValue, ddCategory.SelectedValue, Session("UserId"))
            Dim ds As DataSet = MainBLL.NewDropdownWithtypeAndID("DiscountCRMCustomerDropDown", ddtype.SelectedValue, Session("UserId"), ddCategory.SelectedValue)
            ddlcustid.DataSource = ds.Tables(0)
            ddlcustid.DataTextField = "Acc_Code"
            ddlcustid.DataValueField = "Acc_Id"
            ddlcustid.DataBind()
            ddlcustid.Items.Insert(0, "Select Customer Code")
            ddlcustname.DataSource = ds.Tables(0)
            ddlcustname.DataTextField = "Acc_Name"
            ddlcustname.DataValueField = "Acc_Id"
            ddlcustname.DataBind()
            ddlcustname.Items.Insert(0, "Select Customer Name")
            ddlemail.DataSource = ds.Tables(0)
            ddlemail.DataTextField = "Cust_EmailId"
            ddlemail.DataValueField = "Acc_Id"
            ddlemail.DataBind()
            ddlemail.Items.Insert(0, "Select Customer Email Id")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub


    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            If (IsValid = True) Then
                If ddProduct.SelectedValue <> "All Product" Then
                    Dim custid As String = ddlcustid.SelectedValue
                    Dim custnames As String = ddlcustname.SelectedValue
                    DiscountBLL.DeleteSingle(Convert.ToInt32(custid), Convert.ToInt32(ddProduct.SelectedValue))
                    discountId = DiscountBLL.MaxDiscountID
                    Dim sb As New StringBuilder
                    sb.Append("<root>")
                    For i As Integer = 0 To GridView1.Rows.Count - 1 Step 1


                        Dim productid As String = GridView1.DataKeys(i).Value
                        Dim txtdiscount As TextBox = CType(GridView1.Rows(i).FindControl("txtdiscount"), TextBox)

                        'Adding for discount amount show in log 
                        Dim lblRate As Label = CType(GridView1.Rows(i).FindControl("lblRate"), Label)
                        'Dim txtdiscount As TextBox = CType(GridView1.Rows(i).FindControl("txtdiscount"), TextBox)
                        Dim txtDiscountedRate As TextBox = CType(GridView1.Rows(i).FindControl("txtDiscountedRate"), TextBox)

                        Dim oldRate As String = lblRate.Text
                        Dim discountPercent As String = txtdiscount.Text
                        Dim newRate As String = txtDiscountedRate.Text
                        'END 
                        If String.IsNullOrEmpty(txtdiscount.Text) Or txtdiscount.Text = "0" Then
                        Else
                            sb.Append("<row Discount_ID='" & CStr(discountId) & "' Discount_CustId='" & custid & "' Discount_ProductId='" & productid & "' Discount_Discount='" & txtdiscount.Text &
                                  "' Discount_CreatedDate='" & DateAndTime.DateString & "' Discount_CreatedID='" & Session("UserId") &
                                  "' Discount_ModifiedDate='" & DateAndTime.DateString & "' Discount_ModifiedID='" & Session("UserId") &
                                  "' Discount_Del='0' Discount_Status='Active'/>")


                            Dim uid As Integer? = Nothing
                            If Session("UserId") IsNot Nothing AndAlso IsNumeric(Session("UserId")) Then
                                uid = Convert.ToInt32(Session("UserId"))
                            End If
                            '  LOG PER PRODUCT 
                            ActivityLogger.SaveLog(
            uid,
            Session("UName").ToString(),
            "DISCOUNT_UPDATE",
            "discount",
            Nothing,
            "Customer: " & ddlcustname.SelectedItem.Text &
            " | Product: " & ddProduct.SelectedItem.Text &
            " | Old Rate: " & oldRate &
            " | Discount(%): " & discountPercent &
            " | New Rate: " & newRate,
            Request
        )
                            discountId = discountId + 1
                        End If
                    Next
                    sb.Append("</root>")
                    DiscountBLL.Update(sb.ToString)
                    fillproductbyid()
                    txtflatdis.Text = ""

                    'CUSTOMER NAAME ADDED 
                    '                    ActivityLogger.SaveLog(
                    '    uid,
                    '    Session("UName").ToString(),
                    '    "DISCOUNT_UPDATE",
                    '    "discount",
                    '    Nothing,
                    '    "Discount updated successfully | ProductId : " & discountId &
                    '    " | Product Name : " & ddProduct.SelectedItem.Text &
                    '    " | Customer Name : " & ddlcustname.SelectedItem.Text,
                    '    Request
                    ')
                    'END 
                    '                    ActivityLogger.SaveLog(
                    '    uid,
                    '    Session("UName").ToString(),
                    '    "DISCOUNT_UPDATE",
                    '    "discount",
                    '    Nothing,
                    '    "Customer: " & ddlcustname.SelectedItem.Text &
                    '    " | Product: " & ddProduct.SelectedItem.Text &
                    '    " | Old Rate: " & oldRate &
                    '    " | Discount(%): " & discountPercent &
                    '    " | New Rate: " & newRate,
                    '    Request
                    ')

                    ' ===== CUSTOMER DETAILS =====
                    Dim custName As String = ddlcustid.SelectedItem.Text
                    Dim custEmail As String = ddlemail.SelectedItem.Text
                    Dim productCode As String = ddProduct.SelectedItem.Text   ' single product

                    Dim empId As String = Session("UserId").ToString()

                    SendMailBLL.SendDiscountUpdateNotification(
    custid,
    custName,
    custEmail,
    productCode,
    empId
)
                    '                    ' WhatsApp
                    Dim mobileNo As String = "9167263664"
                    Dim templateName As String = "discount_update_notification"

                    Dim templateParams As New List(Of String) From {
    custid,
    custName,
    custEmail,
    productCode
}

                    SendUsingSMPP.SendWhatsAppMessage(mobileNo, templateName, templateParams)
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + ("Discount Updated successfully").ToString + "')", True)
                Else
                    Dim custid As String = ddlcustid.SelectedValue
                    DiscountBLL.Delete(Convert.ToInt32(custid))
                    discountId = DiscountBLL.MaxDiscountID
                    Dim sb As New StringBuilder
                    sb.Append("<root>")
                    For i As Integer = 0 To GridView1.Rows.Count - 1 Step 1
                        Dim productid As String = GridView1.DataKeys(i).Value
                        Dim txtdiscount As TextBox = CType(GridView1.Rows(i).FindControl("txtdiscount"), TextBox)
                        If String.IsNullOrEmpty(txtdiscount.Text) Or txtdiscount.Text = "0" Then
                        Else
                            sb.Append("<row Discount_ID='" & CStr(discountId) & "' Discount_CustId='" & custid & "' Discount_ProductId='" & productid & "' Discount_Discount='" & txtdiscount.Text &
                                  "' Discount_CreatedDate='" & DateAndTime.DateString & "' Discount_CreatedID='" & Session("UserId") &
                                  "' Discount_ModifiedDate='" & DateAndTime.DateString & "' Discount_ModifiedID='" & Session("UserId") &
                                  "' Discount_Del='0' Discount_Status='Active'/>")
                            discountId = discountId + 1
                        End If
                    Next
                    sb.Append("</root>")
                    DiscountBLL.Update(sb.ToString)
                    fillUser()
                    txtflatdis.Text = ""
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + ("Discount Updated successfully").ToString + "')", True)
                End If


            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddlcustid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlcustid.SelectedIndexChanged
        Try
            fillgrid(ddlcustid.SelectedValue)
            'If ddlcustid.SelectedIndex = "0" Then
            '    GridView1.Visible = False
            '    divflat.Visible = False
            '    btnadd.Visible = False
            '    ddlcustname.SelectedIndex = ddlcustid.SelectedIndex
            '    ddlemail.SelectedIndex = ddlcustid.SelectedIndex
            '    Throw New Exception("please select Customer")
            'Else
            '    ddlcustname.SelectedIndex = ddlcustid.SelectedIndex
            '    ddlemail.SelectedIndex = ddlcustid.SelectedIndex
            '    GridView1.Visible = True
            '    fillUser()
            '    fillproduct(ddlcustid.SelectedValue)
            'End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub fillgrid(ByVal id As String)
        Dim a As Integer
        If Int32.TryParse(id, a) Then

        Else
            id = 0
        End If

        If id = 0 Then
            GridView1.Visible = False
            divflat.Visible = False
            btnadd.Visible = False
            ddlcustid.SelectedIndex = id
            ddlemail.SelectedIndex = id
            ddlcustname.SelectedIndex = id
            divprod.Visible = False
            '  Throw New Exception("Please select Customer")
            '   If ddProduct.SelectedValue = "0" Then

            ' Else

            ' End If
            divflat.Visible = False
            btnadd.Visible = False
        Else
            ddlcustid.SelectedValue = id
            ddlemail.SelectedValue = id
            ddlcustname.SelectedValue = id
            GridView1.Visible = True
            divprod.Visible = True

            fillUser()
            fillproduct(id)


            divflat.Visible = True
            btnadd.Visible = True
        End If

    End Sub
    Protected Sub ddlcustname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlcustname.SelectedIndexChanged
        Try
            fillgrid(ddlcustname.SelectedValue)
            'If ddlcustname.SelectedIndex = "0" Then
            '    GridView1.Visible = False
            '    divflat.Visible = False
            '    btnadd.Visible = False
            '    ddlcustid.SelectedValue = ddlcustname.SelectedValue
            '    ddlemail.SelectedValue = ddlcustname.SelectedValue
            '    Throw New Exception("please select Customer")
            'Else
            '    ddlcustid.SelectedValue = ddlcustname.SelectedValue
            '    ddlemail.SelectedValue = ddlcustname.SelectedValue
            '    GridView1.Visible = True
            '    fillUser()
            '    fillproduct(ddlcustid.SelectedValue)
            'End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddlemail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlemail.SelectedIndexChanged
        Try
            fillgrid(ddlemail.SelectedValue)
            'If ddlemail.SelectedIndex = "0" Then
            '    GridView1.Visible = False
            '    divflat.Visible = False
            '    btnadd.Visible = False
            '    ddlcustid.SelectedIndex = ddlemail.SelectedIndex
            '    ddlcustname.SelectedIndex = ddlemail.SelectedIndex
            '    Throw New Exception("please select Customer")
            'Else
            '    ddlcustid.SelectedIndex = ddlemail.SelectedIndex
            '    ddlcustname.SelectedIndex = ddlemail.SelectedIndex
            '    GridView1.Visible = True
            '    fillUser()
            '    fillproduct(ddlcustid.SelectedValue)
            'End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub



    'Protected Sub btnflatdiscount_Click(sender As Object, e As EventArgs) Handles btnflatdiscount.Click
    '    Try
    '        For i As Integer = 0 To GridView1.Rows.Count - 1 Step 1
    '            Dim txtdiscount As TextBox = CType(GridView1.Rows(i).FindControl("txtdiscount"), TextBox)
    '            Dim txtDiscountedRate As TextBox = CType(GridView1.Rows(i).FindControl("txtDiscountedRate"), TextBox)
    '            Dim lblRate As Label = CType(GridView1.Rows(i).FindControl("lblRate"), Label)
    '            txtdiscount.Text = txtflatdis.Text
    '            txtDiscountedRate.Text = (lblRate.Text - ((lblRate.Text * txtdiscount.Text) / 100))


    '        Next
    '        txtflatdis.Text = ""
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub

    Protected Sub btnflatdiscount_Click(sender As Object, e As EventArgs) Handles btnflatdiscount.Click
        Try
            Dim uid As Integer? = Nothing
            If Session("UserId") IsNot Nothing AndAlso IsNumeric(Session("UserId")) Then
                uid = Convert.ToInt32(Session("UserId"))
            End If
            Dim custid As String = ddlcustid.SelectedValue
            For i As Integer = 0 To GridView1.Rows.Count - 1 Step 1

                Dim txtdiscount As TextBox = CType(GridView1.Rows(i).FindControl("txtdiscount"), TextBox)
                Dim txtDiscountedRate As TextBox = CType(GridView1.Rows(i).FindControl("txtDiscountedRate"), TextBox)
                Dim lblRate As Label = CType(GridView1.Rows(i).FindControl("lblRate"), Label)

                '  Product Name per row (IMPORTANT)
                'Dim lblProduct As Label = CType(GridView1.Rows(i).FindControl("lblname"), Label)
                Dim lblProduct As Literal = CType(GridView1.Rows(i).FindControl("lblname"), Literal)
                ' Apply flat discount
                txtdiscount.Text = txtflatdis.Text

                Dim oldRate As Decimal = Convert.ToDecimal(lblRate.Text)
                Dim discountPercent As Decimal = Convert.ToDecimal(txtdiscount.Text)
                Dim newRate As Decimal = oldRate - ((oldRate * discountPercent) / 100)

                txtDiscountedRate.Text = newRate.ToString("0.00")

                '  LOG PER PRODUCT (separate entry)
                ActivityLogger.SaveLog(
                uid,
                Session("UName").ToString(),
                "DISCOUNT_UPDATE",
                "discount",
                Nothing,
                "Customer: " & ddlcustname.SelectedItem.Text &
                " | Product: " & lblProduct.Text &
                " | Old Rate: " & oldRate &
                " | Discount(%): " & discountPercent &
                " | New Rate: " & newRate,
                Request
            )

            Next
            ' ===== CUSTOMER DETAILS =====
            Dim custName As String = ddlcustid.SelectedItem.Text
            Dim custEmail As String = ddlemail.SelectedItem.Text
            Dim productCode As String = ddProduct.SelectedItem.Text   ' single product

            Dim empId As String = Session("UserId").ToString()

            SendMailBLL.SendDiscountUpdateNotification(
    custid,
    custName,
    custEmail,
    productCode,
    empId
)
            txtflatdis.Text = ""

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub valueCheck(ByVal source As Object, ByVal e As System.Web.UI.WebControls.ServerValidateEventArgs)
        For Each row As GridViewRow In GridView1.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim cv As CustomValidator = CType(row.FindControl("CustomValidator1"), CustomValidator)
                Dim txtdiscount As TextBox = DirectCast(row.FindControl("txtdiscount"), TextBox)
                Dim ltCost As Literal = DirectCast(row.FindControl("ltCost"), Literal)
                Dim ltMargin As Literal = DirectCast(row.FindControl("ltMargin"), Literal)
                Dim ltRate As Literal = DirectCast(row.FindControl("ltRate"), Literal)
                Dim cost As Double = Convert.ToDouble(ltCost.Text)
                Dim Rate As Double = Convert.ToDouble(ltRate.Text)
                Dim marginPercent As Double = Convert.ToDouble(ltMargin.Text)
                Dim cal, cal1 As Double
                If cost <> 0 Or marginPercent <> 0 Then
                    margin = Convert.ToDouble((cost * marginPercent * 0.01) + cost).ToString("N2")
                    If Convert.ToDouble(Rate - (Convert.ToDouble(txtdiscount.Text) * Rate * 0.01)) < margin Then
                        cal = Convert.ToDouble((100 * margin) / Rate).ToString("N2")
                        cal1 = Convert.ToDouble(100 - cal)
                        cv.ErrorMessage = "Discount must be less than " + cal1.ToString("N2") + " %"
                        'cv.ErrorMessage = "Discount must be less than " + margin.ToString("N2") + " ₹"
                        e.IsValid = False
                    Else
                        cv.ErrorMessage = ""
                    End If
                End If

            End If
        Next


    End Sub

    Protected Sub ddtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddtype.SelectedIndexChanged
        FillCustomer()
        fillgrid(0)
        'ddProduct_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Protected Sub ddCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddCategory.SelectedIndexChanged
        FillCustomer()
        fillgrid(0)
        ' ddProduct_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Protected Sub ddProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddProduct.SelectedIndexChanged
        If ddProduct.SelectedValue = "All Product" Then
            divflat.Visible = True
            btnadd.Visible = True
            fillUser()
        Else
            divflat.Visible = False
            btnadd.Visible = False
            fillproductbyid()
        End If
    End Sub

    Public Sub fillproductbyid()
        Try
            btnadd.Visible = True
            GridView1.PageIndex = 0
            GridView1.PageSize = 10
            GridView1.DataSource = MainBLL.FillGridViewDiscountbyid("DiscountGridviewbyid", ddlcustid.SelectedValue, ddProduct.SelectedValue)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub CheckPrivilage()
        Try
            Dim dt As DataSet = PrivilageBLL.CheckPrivilige(Session("UserRoleID"), "Discount.aspx")
            Dim dtprivilage As New DataTable
            dtprivilage = dt.Tables(0)
            Dim drprivilage As DataRow
            If dtprivilage.Rows.Count = 0 Then
                '  SearchControl.Uhfadd.Visible = False
                GridView1.Columns(0).Visible = False
                ' SearchControl.ULkadd.Visible = False
            Else
                drprivilage = dtprivilage.Rows(0)
                If (drprivilage("Prvg_RAdd").ToString()) = True Then
                    ' SearchControl.Uhfadd.Visible = True
                Else
                    ' SearchControl.Uhfadd.Visible = False

                End If
                If (drprivilage("Prvg_RUpdate").ToString()) = True Then
                    GridView1.Columns(0).Visible = True
                Else
                    GridView1.Columns(0).Visible = False
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

End Class
