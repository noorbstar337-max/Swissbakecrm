
Partial Class UserControl_Back_ProductItemControl
    Inherits System.Web.UI.UserControl
    Dim HashItem As Hashtable = New Hashtable
    Dim strItem As New List(Of String)
    Dim TotalAmountCount As Integer = 0
    Dim TotalQuantity As Integer = 0
    Dim Count As Integer
    Dim a As Integer = 0
    Dim a1 As Integer = 0
    Dim q As Integer = 0

#Region "User Control Property"
    Public Property Uhftype() As HiddenField
        Get
            Return Me.hftype
        End Get
        Set(value As HiddenField)
            Me.hftype = value
        End Set
    End Property
    Public Property Uhftypeid() As HiddenField
        Get
            Return Me.hftypeid
        End Get
        Set(value As HiddenField)
            Me.hftypeid = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Me.txtsearch.Attributes.Add("onkeyup", String.Format("javascript:__doPostBack('{0}','')", Me.UpdatePanel1.ClientID))
                fillUser()
                fillItem()
                If grditemproduct.Rows.Count > 0 Then
                    Dim txttotalamount As TextBox = DirectCast(grditemproduct.FooterRow.FindControl("txttotalamount"), TextBox)
                    Dim txtquantitytotal As TextBox = DirectCast(grditemproduct.FooterRow.FindControl("txtquantitytotal"), TextBox)
                    txttotalamount.Text = TotalAmountCount
                    txtquantitytotal.Text = TotalQuantity
                End If
            Else
                Dim target As String = Me.Request.Form("__EVENTTARGET")
                If Not String.IsNullOrEmpty(target) AndAlso target.Equals(Me.UpdatePanel1.ClientID) Then
                    If Not String.IsNullOrEmpty(Me.txtsearch.Text) Then
                        GridView1.AllowCustomPaging = False
                        FillSearch()
                    Else
                        GridView1.AllowCustomPaging = True
                        fillUser()
                    End If
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ProductItemUserControl", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillUser()
        Try
            GridView1.VirtualItemCount = MainBLL.TotalRowInGridview("ProductTotalNumberOfRecord")
            GridView1.DataSource = MainBLL.FillGridView("0", "10", "ProductGridview")
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ProductItemUserControl", "fillUser", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillSearch()
        Try
            GridView1.DataSource = MainBLL.SearchGridView(txtsearch.Text.Trim, "ProductSearch")
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ProductItemUserControl", "FillSearch", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            Dim ids As List(Of String) = If(Session("Itemarray") IsNot Nothing, DirectCast(Session("Itemarray"), List(Of String)), Nothing)
            If ids IsNot Nothing Then
                strItem = Session("Itemarray")
                For i As Integer = 0 To GridView1.Rows.Count - 1
                    Dim ckselect As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckselect"), CheckBox)
                    Dim lblscId As Literal = DirectCast(GridView1.Rows(i).FindControl("lblscId"), Literal)
                    If ckselect.Checked = True Then
                        strItem.Add(lblscId.Text.Trim)
                    End If
                Next
                Session("Itemarray") = strItem
            Else
                For i As Integer = 0 To GridView1.Rows.Count - 1
                    Dim ckselect As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckselect"), CheckBox)
                    Dim lblscId As Literal = DirectCast(GridView1.Rows(i).FindControl("lblscId"), Literal)
                    If ckselect.Checked = True Then
                        strItem.Add(lblscId.Text.Trim)
                    End If
                Next
            End If
            Session("Itemarray") = strItem
            grditemproduct.DataSource = strItem
            grditemproduct.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ProductItemUserControl", "btnsave_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try

    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grditemproduct.RowCommand
        If e.CommandName = "deletelink" Then
            Try
                Dim btn As LinkButton = TryCast(e.CommandSource, LinkButton)
                Dim row As GridViewRow = TryCast(btn.NamingContainer, GridViewRow)
                Dim lblscId As Literal = TryCast(row.FindControl("ltproductid"), Literal)
                Dim ids As List(Of String) = If(Session("Itemarray") IsNot Nothing, DirectCast(Session("Itemarray"), List(Of String)), Nothing)
                If ids IsNot Nothing Then
                    strItem = Session("Itemarray")
                    strItem.Remove(lblscId.Text)
                    Session("Itemarray") = strItem
                Else
                    strItem.Remove(lblscId.Text)
                    Session("Itemarray") = strItem
                End If
                grditemproduct.DataSource = strItem
                grditemproduct.DataBind()
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ProductItemUserControl", "deletelink", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
    End Sub

    Public Sub fillItem()
        Try
            If hftypeid.Value > 0 Then
                Dim dttemp As DataSet
                dttemp = ItemBLL.ItemProductID(hftype.Value, hftypeid.Value)
                    For j As Integer = 0 To dttemp.Tables(0).Rows.Count - 1
                        strItem.Add(dttemp.Tables(0).Rows(j)("Item_ProductID").ToString())
                    Next
                    Session("Itemarray") = strItem
                    grditemproduct.DataSource = strItem
                    grditemproduct.DataBind()
            Else
                grditemproduct.DataSource = ""
                grditemproduct.DataBind()
                Session("Itemarray") = Nothing
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ProductItemUserControl", "fillItem", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub grditemproduct_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grditemproduct.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim ltproductid As Literal = DirectCast(e.Row.FindControl("ltproductid"), Literal)
                Dim ltpname As Literal = DirectCast(e.Row.FindControl("ltpname"), Literal)
                Dim ltuom As Literal = DirectCast(e.Row.FindControl("ltuom"), Literal)
                Dim ltuomid As Literal = DirectCast(e.Row.FindControl("ltuomid"), Literal)
                Dim txtrate As TextBox = DirectCast(e.Row.FindControl("txtrate"), TextBox)
                Dim txtamount As TextBox = DirectCast(e.Row.FindControl("txtamount"), TextBox)
                Dim txtquantity As TextBox = DirectCast(e.Row.FindControl("txtquantity"), TextBox)
                If ltproductid.Text = "" Then
                Else
                    'Dim dttemp As DataSet = MainBLL.ViewByID(ltproductid.Text, "FillItemProduct")
                    Dim dttemp As DataSet = ItemBLL.FillItemProduct(hftype.Value, hftypeid.Value, ltproductid.Text)
                    ltpname.Text = DynamicparcelDataManipulation.FixNullFromDB(dttemp.Tables(0).Rows(0)("Product_Name").ToString())
                    ltuom.Text = dttemp.Tables(0).Rows(0)("UOM_Name").ToString()
                    ltuomid.Text = dttemp.Tables(0).Rows(0)("UOM_ID").ToString()
                    If dttemp.Tables(0).Rows(0)("item_Rate").ToString() = "" Then
                        txtrate.Text = CInt(dttemp.Tables(0).Rows(0)("Product_Price").ToString())
                    Else
                        txtrate.Text = CInt(dttemp.Tables(0).Rows(0)("item_Rate").ToString())
                    End If

                    Dim Temp As String = dttemp.Tables(0).Rows(0)("Item_Quantity").ToString()
                    If Temp = "" Then
                        txtquantity.Text = "1"
                        txtamount.Text = CInt(txtquantity.Text * txtrate.Text)
                    Else
                        txtquantity.Text = dttemp.Tables(0).Rows(0)("Item_Quantity").ToString()
                        txtamount.Text = CInt(txtquantity.Text * txtrate.Text)
                    End If
                    txtamount.Text = CInt(txtquantity.Text * txtrate.Text)
                    TotalQuantity = TotalQuantity + txtquantity.Text
                    TotalAmountCount = TotalAmountCount + txtamount.Text
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ProductItemUserControl", "grditemproduct_RowDataBound", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub AddItem(ByVal ItemID As Integer)
        Try
            If ItemID > 0 Then
                DocumentBLL.DeleteDocument("Product", ItemID, Session("Audlog_Id"))
                ItemBLL.DeleteItem(hftype.Value, ItemID, Session("Audlog_Id"))
            End If
           Count = ItemBLL.MaxItemID
            Dim sb As New StringBuilder
            sb.Append("<root>")
            For i As Integer = 0 To grditemproduct.Rows.Count - 1
                Dim ltproductid As Literal = DirectCast(grditemproduct.Rows(i).FindControl("ltproductid"), Literal)
                Dim lblscId As Literal = DirectCast(grditemproduct.Rows(i).FindControl("lblscId"), Literal)
                Dim txtamount As TextBox = DirectCast(grditemproduct.Rows(i).FindControl("txtamount"), TextBox)
                Dim txtquantity As TextBox = DirectCast(grditemproduct.Rows(i).FindControl("txtquantity"), TextBox)
                Dim txtrate As TextBox = DirectCast(grditemproduct.Rows(i).FindControl("txtrate"), TextBox)
                Dim ltuomid As Literal = DirectCast(grditemproduct.Rows(i).FindControl("ltuomid"), Literal)
                sb.Append("<row Item_Id='" & Count.ToString & "' Item_ProductID='" & ltproductid.Text.Trim & "' Item_TypeID='" & ItemID & "' Item_Type='" & hftype.Value &
                        "' Item_Desc='" & "" & "' Item_Quantity='" & txtquantity.Text.Trim & "' Item_UOM='" & ltuomid.Text.Trim & "' Item_Rate='" & txtrate.Text.Trim & "' Item_CreatedID='" & Session("UserId") &
                         "' Item_CreatedDate='" & DateAndTime.DateString & "' Item_ModifiedID='" & Session("UserId") & "' Item_ModifiedDate='" & DateAndTime.DateString &
                          "' Item_Del='0' Item_Status='Active' />")
                Count = Count + 1
            Next
            sb.Append("</root>")
            ItemBLL.XMLInsert(sb.ToString, Session("Audlog_Id"), hftype.Value)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ProductItemUserControl", "AddItem", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub txtquantity_TextChanged(sender As Object, e As EventArgs)
        Try
            Dim i As Integer = 0

            For Each row As GridViewRow In grditemproduct.Rows
                Dim lbltotal As Literal = DirectCast(row.FindControl("lbltotal"), Literal)
                Dim txtquantity As TextBox = DirectCast(row.FindControl("txtquantity"), TextBox)
                Dim txtrate As TextBox = DirectCast(row.FindControl("txtrate"), TextBox)
                Dim txtamount As TextBox = DirectCast(row.FindControl("txtamount"), TextBox)
                Dim txttotalamount As TextBox = DirectCast(grditemproduct.FooterRow.FindControl("txttotalamount"), TextBox)
                Dim txtquantitytotal As TextBox = DirectCast(grditemproduct.FooterRow.FindControl("txtquantitytotal"), TextBox)

                txtamount.Text = txtquantity.Text * txtrate.Text
                For Each row1 As GridViewRow In grditemproduct.Rows
                    Dim txtamount1 As TextBox = DirectCast(row1.FindControl("txtamount"), TextBox)
                    a = a + txtamount1.Text

                    Dim txtquantity1 As TextBox = DirectCast(row1.FindControl("txtquantity"), TextBox)
                    q = q + txtquantity1.Text
                Next
                txttotalamount.Text = Convert.ToInt32(a.ToString)
                txtquantitytotal.Text = Convert.ToInt32(q.ToString)
                Exit For
            Next

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ProductItemUserControl", "txtquantity_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub txtrate_TextChanged(sender As Object, e As EventArgs)
        Try
            Dim i As Integer = 0
            Dim count As Integer = 0
            For Each row As GridViewRow In grditemproduct.Rows
                Dim lbltotal As Literal = DirectCast(row.FindControl("lbltotal"), Literal)
                Dim txtquantity As TextBox = DirectCast(row.FindControl("txtquantity"), TextBox)
                Dim txtrate As TextBox = DirectCast(row.FindControl("txtrate"), TextBox)
                Dim txtamount As TextBox = DirectCast(row.FindControl("txtamount"), TextBox)
                Dim txttotalamount As TextBox = DirectCast(grditemproduct.FooterRow.FindControl("txttotalamount"), TextBox)
                Dim txtquantitytotal As TextBox = DirectCast(grditemproduct.FooterRow.FindControl("txtquantitytotal"), TextBox)

                txtamount.Text = txtquantity.Text * txtrate.Text
                If count = 0 Then
                    For Each row1 As GridViewRow In grditemproduct.Rows
                        count = grditemproduct.Rows.Count
                        Dim txtquantity1 As TextBox = DirectCast(row1.FindControl("txtquantity"), TextBox)

                        Dim txtamount1 As TextBox = DirectCast(row1.FindControl("txtamount"), TextBox)
                        a = txtquantity1.Text * txtamount.Text
                        a1 = a1 + a

                        q = q + txtquantity1.Text
                      
                    Next
                End If
               
                txttotalamount.Text = Convert.ToInt32(a1.ToString)
                txtquantitytotal.Text = Convert.ToInt32(q.ToString)
                'Exit For
            Next

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ProductItemUserControl", "txtrate_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class
