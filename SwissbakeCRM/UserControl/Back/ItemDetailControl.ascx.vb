
Partial Class UserControl_Back_ItemDetailControl
    Inherits System.Web.UI.UserControl
    Dim MainID As Integer
    Dim Count As Integer = 0
    Dim TotalAmount As Double = 0.0
    Dim FooterTotalAmount As Double = 0.0
    Dim VatAmount As Double = 0.0
    Public countrate As Double = 0.0
    Public countrate1 As Double = 0.0
    Dim Opportxtamount As TextBox

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
    Public Property Uhfopptype() As HiddenField
        Get
            Return Me.hfopptype
        End Get
        Set(value As HiddenField)
            Me.hfopptype = value
        End Set
    End Property
    Public Property Uhfopptypeid() As HiddenField
        Get
            Return Me.hfopptypeid
        End Get
        Set(value As HiddenField)
            Me.hfopptypeid = value
        End Set
    End Property
    Public Property Ugrditemproduct() As GridView
        Get
            Return Me.grditemproduct
        End Get
        Set(value As GridView)
            Me.grditemproduct = value
        End Set
    End Property
#End Region

#Region "Method"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Me.txtsearch.Attributes.Add("onkeyup", String.Format("javascript:__doPostBack('{0}','')", Me.UpdatePanel1.ClientID))
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                If MainID = 0 Then
                Else
                    'FillAssignTo()
                    fillUser()
                    If grditemproduct.Rows.Count > 0 Then
                        Dim lttotalamount As Literal = DirectCast(grditemproduct.FooterRow.FindControl("lttotalamount"), Literal)
                        Dim lttotalvat As Literal = DirectCast(grditemproduct.FooterRow.FindControl("lttotalvat"), Literal)
                        Dim lblfreight As Label = DirectCast(grditemproduct.FooterRow.FindControl("lblfreight"), Label)
                        If String.IsNullOrEmpty(lblfreight.Text) Then
                            lblfreight.Text = "0"
                        End If
                        For i As Integer = 0 To grditemproduct.Rows.Count - 1
                            Dim ltamount As Literal = DirectCast(grditemproduct.Rows(i).FindControl("ltamount"), Literal)
                            Dim lblvatinrs As Literal = DirectCast(grditemproduct.Rows(i).FindControl("lblvatinrs"), Literal)
                            VatAmount = VatAmount + Math.Round(Convert.ToDouble(lblvatinrs.Text))
                            FooterTotalAmount = FooterTotalAmount + Math.Round(Convert.ToDouble(ltamount.Text))
                        Next
                        lttotalamount.Text = Math.Round(FooterTotalAmount + VatAmount + Convert.ToDouble(lblfreight.Text)).ToString("N2")
                        lttotalvat.Text = Math.Round(VatAmount).ToString("N2")
                        Opportxtamount = Me.Parent.FindControl("txtamount")
                        If Opportxtamount Is Nothing Then
                        Else
                            If grditemproduct.Rows.Count > 0 Then
                                Opportxtamount.ReadOnly = True
                            Else
                                Opportxtamount.ReadOnly = False
                            End If
                        End If
                    End If
                End If
            Else
                Dim target As String = Me.Request.Form("__EVENTTARGET")
                If Not String.IsNullOrEmpty(target) AndAlso target.Equals(Me.UpdatePanel1.ClientID) Then
                    If Not String.IsNullOrEmpty(Me.txtsearch.Text) Then
                        'GridView1.AllowCustomPaging = False
                        FillSearch()
                    Else
                        'GridView1.AllowCustomPaging = True
                        fillUser()
                    End If
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ItemDetailControl", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillUser()
        Try
            'GridView1.DataSource = ItemDetailBLL.ViewItemDetail(hfopptype.Value, hfopptypeid.Value, hftypeid.Value)
            GridView1.DataSource = ItemDetailBLL.ViewItemDetail(hftypeid.Value)
            GridView1.DataBind()
            grditemproduct.DataSource = ItemDetailBLL.FillItemDT(hfopptype.Value, hfopptypeid.Value, hftypeid.Value)
            grditemproduct.DataBind()
            FillOherDetail()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ItemDetailControl", "fillUser", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillOherDetail()
        Try
            Dim DS As DataSet = DirectCast(grditemproduct.DataSource, DataSet)
            Dim totalcount As Integer = DS.Tables(0).Rows.Count
            If totalcount > 0 Then
                lblitemdt.Text = "Item Detail (" + totalcount.ToString + ")"
            Else
                lblitemdt.Text = "No Item Detail"
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ItemDetailControl", "FillOherDetail", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillSearch()
        Try
            GridView1.DataSource = ItemDetailBLL.SearchItemDetail(hfopptype.Value, hfopptypeid.Value, hftypeid.Value, txtsearch.Text.Trim)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ItemDetailControl", "FillSearch", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            If txtsearch.Text = "" Then
                GridView1.PageIndex = e.NewPageIndex
                GridView1.DataSource = MainBLL.ViewByID(hftypeid.Value, "ViewItemDetail")
                GridView1.DataBind()
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
            Else
                GridView1.PageIndex = e.NewPageIndex
                FillSearch()
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ItemDetailControl", "GridView1_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            Count = MainBLL.GetCode("MaxItemDT")
            Count = Count + 1
            Dim sb As New StringBuilder
            sb.Append("<root>")
            For i As Integer = 0 To GridView1.Rows.Count - 1
                Dim index As Integer = GridView1.Rows(i).RowIndex
                Dim ckselect As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckselect"), CheckBox)
                If ckselect.Checked = True Then
                    Dim lbldiscount As Literal = DirectCast(GridView1.Rows(i).FindControl("lbldiscount"), Literal)
                    Dim lblProductId As Literal = DirectCast(GridView1.Rows(i).FindControl("lblProductId"), Literal)
                    Dim lblrate As Literal = DirectCast(GridView1.Rows(i).FindControl("lblrate"), Literal)
                    Dim lblunit As Literal = DirectCast(GridView1.Rows(i).FindControl("lblunit"), Literal)
                    Dim lblvat As Literal = DirectCast(GridView1.Rows(i).FindControl("lblvat"), Literal)
                    If lbldiscount.Text = "" Then
                    Else
                        countrate = (Convert.ToDouble(lbldiscount.Text) / 100)
                        countrate1 = (Convert.ToDouble(lblrate.Text)) * countrate
                        lblrate.Text = Math.Round(Convert.ToDouble(lblrate.Text)) - Math.Round(countrate1)
                    End If
                    TotalAmount = Convert.ToDouble(lblrate.Text) * Math.Floor(Convert.ToDouble(lblunit.Text))
                    'TotalAmount = Math.Round(Convert.ToDouble(lblrate.Text)) * Convert.ToDouble(Math.Floor(Convert.ToInt32(lblunit.Text)))
                    Dim VAT As Double = Math.Round(Convert.ToDouble((Math.Round(Convert.ToDouble(lblvat.Text)) * Math.Round(TotalAmount)) / 100))
                    'TotalAmount = TotalAmount + VAT
                    sb.Append("<row ItemDt_ID='" & Count.ToString & "' ItemDt_Type='" & hfopptype.Value &
                          "' ItemDt_TypeId='" & hfopptypeid.Value & "' ItemDt_ProductId='" & lblProductId.Text &
                          "' ItemDt_Qty='" & 1 & "' ItemDt_Rate='" & lblrate.Text & "' ItemDt_Amount='" & TotalAmount &
                           "' ItemDt_Vat='" & VAT & "' />")
                    Count = Count + 1
                End If
            Next
            sb.Append("</root>")
            OpportunityBLL.XMLItemDtInsert(sb.ToString)
            mpe.Hide()
            fillUser()
            If grditemproduct.Rows.Count > 0 Then
                Dim lttotalamount As Literal = DirectCast(grditemproduct.FooterRow.FindControl("lttotalamount"), Literal)
                Dim lttotalvat As Literal = DirectCast(grditemproduct.FooterRow.FindControl("lttotalvat"), Literal)
                Dim lblfreight As Label = DirectCast(grditemproduct.FooterRow.FindControl("lblfreight"), Label)
                If String.IsNullOrEmpty(lblfreight.Text) Then
                    lblfreight.Text = "0"
                End If
                For i As Integer = 0 To grditemproduct.Rows.Count - 1
                    Dim ltamount As Literal = DirectCast(grditemproduct.Rows(i).FindControl("ltamount"), Literal)
                    Dim lblvatinrs As Literal = DirectCast(grditemproduct.Rows(i).FindControl("lblvatinrs"), Literal)
                    VatAmount = Math.Round(VatAmount) + Math.Round(Convert.ToDouble(lblvatinrs.Text))
                    FooterTotalAmount = FooterTotalAmount + Math.Round(Convert.ToDouble(ltamount.Text))
                Next
                lttotalamount.Text = Math.Round(FooterTotalAmount + VatAmount + Convert.ToDouble(lblfreight.Text)).ToString("N2")
                lttotalvat.Text = Math.Round(VatAmount).ToString("N2")
                ItemDetailBLL.UpdateTotalAmountOpp(hftype.Value, hftypeid.Value, lttotalamount.Text)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ItemDetailControl", "btnsave_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub addItem()
        Try
            Dim count As Integer
            If Session("OrderProduct") Is Nothing Then
                count = 0
                Dim dt As New DataTable
                dt.Columns.Add("ItemDt_ID", GetType(Integer))
                dt.Columns.Add("ProductId", GetType(Integer))
                dt.Columns.Add("Product_Name", GetType(String))
                dt.Columns.Add("Product_Code", GetType(String))
                dt.Columns.Add("Packing_Packing", GetType(String))
                dt.Columns.Add("Packing_Weight", GetType(String))
                dt.Columns.Add("ItemDt_Rate", GetType(String))
                dt.Columns.Add("ItemDt_Qty", GetType(String))
                dt.Columns.Add("Product_Vat", GetType(String))
                For Each row As GridViewRow In GridView1.Rows
                    Dim txtOrderQty = DirectCast(row.FindControl("txtOrderQty"), TextBox)
                    Dim lblproductId = DirectCast(row.FindControl("lblproductId"), Label)
                    Dim lblname = DirectCast(row.FindControl("lblname"), Literal)
                    Dim lblcode = DirectCast(row.FindControl("lblcode"), Literal)
                    Dim lblunit = DirectCast(row.FindControl("lblunit"), Literal)
                    Dim ltproductWeight = DirectCast(row.FindControl("ltproductWeight"), Literal)
                    Dim Literal1 = DirectCast(row.FindControl("Literal1"), Literal)
                    Dim lblamount = DirectCast(row.FindControl("lbltotalamount1"), Label)
                    Dim lblvat = DirectCast(row.FindControl("lblvat"), Literal)
                    Dim lblkgs = DirectCast(row.FindControl("lblkgs"), Label)
                    Dim lblrate = DirectCast(row.FindControl("lblrate"), Literal)
                    Dim ckselect = DirectCast(row.FindControl("ckselect"), CheckBox)
                    Dim hfdiscountrate = DirectCast(row.FindControl("hfdiscountrate"), HiddenField)
                    If ckselect.Checked = True Then
                        If txtOrderQty.Text = "" Then
                        Else
                            If txtOrderQty.Text = 0 Then
                            Else
                                dt.Rows.Add(count, lblproductId.Text, lblname.Text, lblcode.Text, lblunit.Text, ltproductWeight.Text, hfdiscountrate.Value, txtOrderQty.Text,
                                            lblvat.Text)
                                count = count + 1
                            End If
                        End If
                    End If
                Next
                Session("OrderProduct") = dt
            Else
                Dim dt As DataTable = DirectCast(Session("OrderProduct"), DataTable)
                count = dt.Rows.Count
                For Each row As GridViewRow In GridView1.Rows
                    Dim txtOrderQty = DirectCast(row.FindControl("txtOrderQty"), TextBox)
                    Dim lblproductId = DirectCast(row.FindControl("lblproductId"), Label)
                    Dim lblname = DirectCast(row.FindControl("lblname"), Literal)
                    Dim lblcode = DirectCast(row.FindControl("lblcode"), Literal)
                    Dim lblunit = DirectCast(row.FindControl("lblunit"), Literal)
                    Dim ltproductWeight = DirectCast(row.FindControl("ltproductWeight"), Literal)
                    Dim Literal1 = DirectCast(row.FindControl("Literal1"), Literal)
                    Dim lblamount = DirectCast(row.FindControl("lbltotalamount1"), Label)
                    Dim lblvat = DirectCast(row.FindControl("lblvat"), Literal)
                    Dim lblkgs = DirectCast(row.FindControl("lblkgs"), Label)
                    Dim lblrate = DirectCast(row.FindControl("lblrate"), Literal)
                    Dim ckselect = DirectCast(row.FindControl("ckselect"), CheckBox)
                    Dim hfdiscountrate = DirectCast(row.FindControl("hfdiscountrate"), HiddenField)
                    If ckselect.Checked = True Then
                        If txtOrderQty.Text = "" Then
                        Else
                            If txtOrderQty.Text = 0 Then
                            Else
                                dt.Rows.Add(count, lblproductId.Text, lblname.Text, lblcode.Text, lblunit.Text, ltproductWeight.Text, hfdiscountrate.Value, txtOrderQty.Text,
                                            lblvat.Text)
                                count = count + 1
                            End If
                        End If
                    End If
                Next
                Session("OrderProduct") = dt
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
        End Try
    End Sub

    Protected Sub txtquantity_TextChanged(sender As Object, e As EventArgs)
        Try
            Dim rd As TextBox = DirectCast(sender, TextBox)
            Dim row As GridViewRow = DirectCast(rd.NamingContainer, GridViewRow)
            Dim txtquantity As TextBox = TryCast(row.FindControl("txtquantity"), TextBox)
            Dim ltrate As Literal = TryCast(row.FindControl("ltrate"), Literal)
            Dim ltitemid As Literal = TryCast(row.FindControl("ltitemid"), Literal)
            Dim ltproductWeight As Literal = TryCast(row.FindControl("ltproductWeight"), Literal)
            Dim ltkg As Literal = TryCast(row.FindControl("ltkg"), Literal)
            Dim ltamount As Literal = TryCast(row.FindControl("ltamount"), Literal)
            Dim lblvat As Literal = TryCast(row.FindControl("lblvat"), Literal)
            Dim lblvatinrs As Literal = TryCast(row.FindControl("lblvatinrs"), Literal)
            If txtquantity.Text = "" Then
                txtquantity.Text = 1
            End If
            If txtquantity.Text.Contains(".") Then
                txtquantity.Text = Math.Floor(CDbl(txtquantity.Text))
            End If
            ltkg.Text = ltproductWeight.Text * txtquantity.Text
            ltamount.Text = ltkg.Text * Math.Round(Convert.ToDouble(ltrate.Text))
            Dim VAT As Double = Math.Round(Convert.ToDouble((lblvat.Text * ltamount.Text) / 100), 2)
            lblvatinrs.Text = VAT.ToString("N2")
            ltamount.Text = Math.Round(Convert.ToDouble(ltamount.Text)).ToString("N2")
            If grditemproduct.Rows.Count > 0 Then
                Dim lttotalamount As Literal = DirectCast(grditemproduct.FooterRow.FindControl("lttotalamount"), Literal)
                Dim lttotalvat As Literal = DirectCast(grditemproduct.FooterRow.FindControl("lttotalvat"), Literal)
                Dim lblfreight As Label = DirectCast(grditemproduct.FooterRow.FindControl("lblfreight"), Label)
                If String.IsNullOrEmpty(lblfreight.Text) Then
                    lblfreight.Text = "0"
                End If
                For i As Integer = 0 To grditemproduct.Rows.Count - 1
                    ltamount = DirectCast(grditemproduct.Rows(i).FindControl("ltamount"), Literal)
                    lblvatinrs = DirectCast(grditemproduct.Rows(i).FindControl("lblvatinrs"), Literal)
                    VatAmount = VatAmount + lblvatinrs.Text
                    FooterTotalAmount = FooterTotalAmount + ltamount.Text
                Next
                lttotalamount.Text = Math.Round(FooterTotalAmount + VatAmount + Convert.ToDouble(lblfreight.Text)).ToString("N2")
                lttotalvat.Text = Math.Round(VatAmount).ToString("N2")
            End If
            'ItemDetailBLL.Update(txtquantity.Text, ltamount.Text, ltitemid.Text)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ItemDetailControl", "txtquantity_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grditemproduct.RowCommand
        If e.CommandName = "deletelink" Then
            Try
                Dim btn As LinkButton = TryCast(e.CommandSource, LinkButton)
                Dim row As GridViewRow = TryCast(btn.NamingContainer, GridViewRow)
                Dim ltitemid As Literal = TryCast(row.FindControl("ltitemid"), Literal)
                ItemDetailBLL.Delete(ltitemid.Text)
                fillUser()
                If grditemproduct.Rows.Count > 0 Then
                    Dim lttotalamount As Literal = DirectCast(grditemproduct.FooterRow.FindControl("lttotalamount"), Literal)
                    Dim lttotalvat As Literal = DirectCast(grditemproduct.FooterRow.FindControl("lttotalvat"), Literal)
                    Dim lblfreight As Label = DirectCast(grditemproduct.FooterRow.FindControl("lblfreight"), Label)
                    If String.IsNullOrEmpty(lblfreight.Text) Then
                        lblfreight.Text = "0"
                    End If
                    For i As Integer = 0 To grditemproduct.Rows.Count - 1
                        Dim ltamount As Literal = DirectCast(grditemproduct.Rows(i).FindControl("ltamount"), Literal)
                        Dim lblvatinrs As Literal = DirectCast(grditemproduct.Rows(i).FindControl("lblvatinrs"), Literal)
                        VatAmount = VatAmount + Math.Round(Convert.ToDouble(lblvatinrs.Text))
                        FooterTotalAmount = FooterTotalAmount + Math.Round(Convert.ToDouble(ltamount.Text))
                    Next
                    lttotalamount.Text = Math.Round(FooterTotalAmount + VatAmount + Convert.ToDouble(lblfreight.Text)).ToString("N2")
                    lttotalvat.Text = Math.Round(VatAmount).ToString("N2")
                    ItemDetailBLL.UpdateTotalAmountOpp(hftype.Value, hftypeid.Value, lttotalamount.Text)
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ItemDetailControl", "deletelink", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        ElseIf e.CommandName = "Editlink" Then
            Dim btn As LinkButton = TryCast(e.CommandSource, LinkButton)
            Dim row As GridViewRow = TryCast(btn.NamingContainer, GridViewRow)
            Dim lnkedit As LinkButton = TryCast(row.FindControl("lnkedit"), LinkButton)
            Dim lkupdate As LinkButton = TryCast(row.FindControl("lkupdate"), LinkButton)
            Dim lnkdelete As LinkButton = TryCast(row.FindControl("lnkdelete"), LinkButton)
            Dim txtquantity As TextBox = TryCast(row.FindControl("txtquantity"), TextBox)
            Dim ltquantity As Literal = TryCast(row.FindControl("ltquantity"), Literal)
            ltquantity.Visible = False
            txtquantity.Visible = True
            lkupdate.Visible = True
            lnkdelete.Visible = False
            lnkedit.Text = "Cancel"
            lnkedit.CommandName = "Cancellink"
            lnkedit.CssClass = "btn btn-xs btn-warning"
        ElseIf e.CommandName = "Cancellink" Then
            Dim btn As LinkButton = TryCast(e.CommandSource, LinkButton)
            Dim row As GridViewRow = TryCast(btn.NamingContainer, GridViewRow)
            Dim lnkedit As LinkButton = TryCast(row.FindControl("lnkedit"), LinkButton)
            Dim lkupdate As LinkButton = TryCast(row.FindControl("lkupdate"), LinkButton)
            Dim lnkdelete As LinkButton = TryCast(row.FindControl("lnkdelete"), LinkButton)
            Dim txtquantity As TextBox = TryCast(row.FindControl("txtquantity"), TextBox)
            Dim ltquantity As Literal = TryCast(row.FindControl("ltquantity"), Literal)
            ltquantity.Visible = True
            txtquantity.Visible = False
            lkupdate.Visible = False
            lnkdelete.Visible = True
            lnkedit.Text = "Edit"
            lnkedit.CommandName = "Editlink"
            lnkedit.CssClass = "btn btn-primary"
        ElseIf e.CommandName = "updatelink" Then
            Dim btn As LinkButton = TryCast(e.CommandSource, LinkButton)
            Dim row As GridViewRow = TryCast(btn.NamingContainer, GridViewRow)
            Dim txtquantity As TextBox = TryCast(row.FindControl("txtquantity"), TextBox)
            Dim ltrate As Literal = TryCast(row.FindControl("ltrate"), Literal)
            Dim ltitemid As Literal = TryCast(row.FindControl("ltitemid"), Literal)
            Dim ltproductWeight As Literal = TryCast(row.FindControl("ltproductWeight"), Literal)
            Dim ltkg As Literal = TryCast(row.FindControl("ltkg"), Literal)
            Dim ltamount As Literal = TryCast(row.FindControl("ltamount"), Literal)
            Dim lnkedit As LinkButton = TryCast(row.FindControl("lnkedit"), LinkButton)
            Dim lkupdate As LinkButton = TryCast(row.FindControl("lkupdate"), LinkButton)
            Dim lnkdelete As LinkButton = TryCast(row.FindControl("lnkdelete"), LinkButton)
            Dim ltquantity As Literal = TryCast(row.FindControl("ltquantity"), Literal)
            Dim lblvat As Literal = TryCast(row.FindControl("lblvat"), Literal)
            If txtquantity.Text = "" Then
                txtquantity.Text = 1
            End If
            If txtquantity.Text.Contains(".") Then
                txtquantity.Text = Math.Floor(CDbl(txtquantity.Text))
            End If
            ltkg.Text = ltproductWeight.Text * txtquantity.Text
            ltamount.Text = ltkg.Text * Math.Round(Convert.ToDouble(ltrate.Text))
            Dim VAT As Double = Math.Round(Convert.ToDouble((lblvat.Text * ltamount.Text) / 100))
            ltamount.Text = Math.Round(Convert.ToDouble(ltamount.Text))
            ItemDetailBLL.Update(txtquantity.Text, ltamount.Text, ltitemid.Text)
            ltquantity.Text = txtquantity.Text
            ltquantity.Visible = True
            txtquantity.Visible = False
            lkupdate.Visible = False
            lnkdelete.Visible = True
            lnkedit.Text = "Edit"
            lnkedit.CommandName = "Editlink"
            lnkedit.CssClass = "btn btn-primary"
            If grditemproduct.Rows.Count > 0 Then
                Dim lttotalamount As Literal = DirectCast(grditemproduct.FooterRow.FindControl("lttotalamount"), Literal)
                Dim lblfreight As Label = DirectCast(grditemproduct.FooterRow.FindControl("lblfreight"), Label)
                If String.IsNullOrEmpty(lblfreight.Text) Then
                    lblfreight.Text = "0"
                End If
                For i As Integer = 0 To grditemproduct.Rows.Count - 1
                    ltamount = DirectCast(grditemproduct.Rows(i).FindControl("ltamount"), Literal)
                    Dim lblvatinrs As Literal = DirectCast(grditemproduct.Rows(i).FindControl("lblvatinrs"), Literal)
                    VatAmount = VatAmount + Math.Round(Convert.ToDouble(lblvatinrs.Text))
                    FooterTotalAmount = FooterTotalAmount + Math.Round(Convert.ToDouble(ltamount.Text))
                Next
                lttotalamount.Text = Math.Round(FooterTotalAmount + VatAmount + Convert.ToDouble(lblfreight.Text))
                ItemDetailBLL.UpdateTotalAmountOpp(hftype.Value, hftypeid.Value, lttotalamount.Text)
            End If
        End If
    End Sub

    Protected Sub btnopen_Click(sender As Object, e As EventArgs) Handles btnopen.Click
        Try
            btnsave.Enabled = True
            btnsave.Text = "Save"
            mpe.Show()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ItemDetailControl", "btnopen_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    'Protected Sub grditemproduct_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grditemproduct.PageIndexChanging
    '    Try
    '        grditemproduct.PageIndex = e.NewPageIndex
    '        grditemproduct.DataSource = ItemDetailBLL.FillItemDT(hfopptype.Value, hfopptypeid.Value)
    '        grditemproduct.DataBind()
    '        If grditemproduct.Rows.Count > 0 Then
    '            Dim lttotalamount As Literal = DirectCast(grditemproduct.FooterRow.FindControl("lttotalamount"), Literal)
    '            Dim lttotalvat As Literal = DirectCast(grditemproduct.FooterRow.FindControl("lttotalvat"), Literal)
    '            For i As Integer = 0 To grditemproduct.Rows.Count - 1
    '                Dim ltamount As Literal = DirectCast(grditemproduct.Rows(i).FindControl("ltamount"), Literal)
    '                Dim lblvatinrs As Literal = DirectCast(grditemproduct.Rows(i).FindControl("lblvatinrs"), Literal)
    '                VatAmount = VatAmount + lblvatinrs.Text
    '                FooterTotalAmount = FooterTotalAmount + ltamount.Text
    '            Next
    '            lttotalamount.Text = FooterTotalAmount
    '            lttotalvat.Text = VatAmount
    '            ItemDetailBLL.UpdateTotalAmountOpp(hftype.Value, hftypeid.Value, lttotalamount.Text)
    '        End If
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert("ActivityUserControl", "GridView2_PageIndexChanging", error1, Session("UserId"))
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub

    Protected Sub grditemproduct_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grditemproduct.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim ltproductid As Literal = DirectCast(e.Row.FindControl("ltproductid"), Literal)
            Dim txtquantity As TextBox = TryCast(e.Row.FindControl("txtquantity"), TextBox)
            Dim ltrate As Literal = TryCast(e.Row.FindControl("ltrate"), Literal)
            Dim ltitemid As Literal = TryCast(e.Row.FindControl("ltitemid"), Literal)
            Dim ltproductWeight As Literal = TryCast(e.Row.FindControl("ltproductWeight"), Literal)
            Dim ltkg As Literal = TryCast(e.Row.FindControl("ltkg"), Literal)
            Dim ltamount As Literal = TryCast(e.Row.FindControl("ltamount"), Literal)
            Dim lblvat As Literal = TryCast(e.Row.FindControl("lblvat"), Literal)
            Dim lblvatinrs As Literal = TryCast(e.Row.FindControl("lblvatinrs"), Literal)
            If txtquantity.Text = "" Then
                txtquantity.Text = 1
            End If
            If txtquantity.Text.Contains(".") Then
                txtquantity.Text = Math.Floor(CDbl(txtquantity.Text))
            End If
            ltkg.Text = ltproductWeight.Text * txtquantity.Text
            ltamount.Text = ltkg.Text * Math.Round(Convert.ToDouble(ltrate.Text))
            Dim VAT As Double = Math.Round(Convert.ToDouble((lblvat.Text * ltamount.Text) / 100))
            lblvatinrs.Text = Math.Round(VAT).ToString("N2")
            ltamount.Text = Math.Round(Convert.ToDouble(ltamount.Text)).ToString("N2")
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            Dim lblfreight As Label = DirectCast(e.Row.FindControl("lblfreight"), Label)
            If Not lblfreight Is Nothing Then
                lblfreight.Text = ItemDetailBLL.GetFright(hfopptype.Value, hfopptypeid.Value).ToString
            End If
        End If
    End Sub

    Protected Sub btnshowall_Click(sender As Object, e As EventArgs) Handles btnshowall.Click
        txtsearch.Text = ""
        GridView1.DataSource = ItemDetailBLL.ViewItemDetail(hftypeid.Value)
        GridView1.DataBind()
    End Sub
#End Region


End Class
