Imports System.Net
Imports System.Net.Mail
Partial Class EditSalesOrder
    Inherits System.Web.UI.Page
    Dim countrate As Double = 0.0
    Dim countrate1 As Double = 0.0
    Dim FooterTotalAmount As Double = 0.0
    Dim TcsAmount As Double = 0.0
    Dim VatAmount As Double = 0.0
    Dim ODACharges As Double = 0.0
    'Dim countrydt As DataTable
    'Dim statedt As DataTable
    Dim MainID As Integer
    Dim strvat As New List(Of String)
    'Protected lblODAAmount123 As Label

    Private ReadOnly conString As String =
        ConfigurationManager.ConnectionStrings("connectionString").ConnectionString
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                CheckPrivi()
                lbltitle1.Text = "Modify Sales Order"
                lbltitle2.Text = "Modify Sales Order"
                'lblODAAmount.Text = ""
                chkInvoice()
                fillaccount()
                fillcompany()
                FillBilledfrom()
                FillShippedfrom()
                FillCountry()
                FillCountryCOO()
                FillStatebill()
                FillDetail()
                FillBillingAddressDetail()
                ' ''FillShippingAddressDetail()'MUBYN
                FillShipAddrByOrderId()
                FillTaxdetails()
                FillAccountdetails()
                FillMainProduct()
                ShowHideItemTotalKgsGSTVATfreight()
                fillInvoice()
                'FillBanks()		   
                '  panel.Enabled = False
                ddrelatedtypeid.Enabled = False
                ddQuotationType.Enabled = False
                txttermpayment.Enabled = False
                'ddlcountrybill.Enabled = False
                'ddlcountrybillCOO.Enabled = False
                'ddlstatebill.Enabled = False
                ddrelatedtypeid.CssClass = " form-control"
                assigncontrol.Uhftype.Value = "Order"
                assigncontrol.Uhftypeid.Value = MainID
                'activitycontrol.Uhftype.Value = "Order"
                'activitycontrol.Uhftypeid.Value = MainID             
                Me.txtsearch.Attributes.Add("onkeyup", String.Format("javascript:__doPostBack('{0}','')", Me.UpdatePanel1.ClientID))
            Else
                Dim target As String = Me.Request.Form("__EVENTTARGET")
                If Not String.IsNullOrEmpty(target) AndAlso target.Equals(Me.UpdatePanel1.ClientID) Then
                    If Not String.IsNullOrEmpty(Me.txtsearch.Text) Then
                        FillSearch()
                    Else
                        FillProductGrid()
                    End If
                End If
            End If
            '================================================
            '  Dim dt As DataSet = AccountBLL.SelectCategoryByAccId(ddrelatedtypeid.SelectedValue)
            ' Dim dtUser As New DataTable
            ' dtUser = dt.Tables(0)
            ' Dim drLogin As DataRow
            'drLogin = dtUser.Rows(0)
            ' If drLogin("Acc_Category").ToString() Then
            If ddQuotationType.SelectedValue = "Domestic" Then
                divDomestic.Visible = False
                ddQuotationType.SelectedValue = "Domestic"
                CheckType()
            Else
                divDomestic.Visible = True
                ddQuotationType.SelectedValue = "Export"
                CheckType()

            End If
            '=======================================================
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifySalesOrder", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub CheckType()
        Try
            ' Dim dt As DataSet = AccountBLL.SelectCategoryByAccId(ddrelatedtypeid.SelectedValue)
            ' Dim dtUser As New DataTable
            '' dtUser = dt.Tables(0)
            ' Dim drLogin As DataRow
            ' drLogin = dtUser.Rows(0)
            qtntype.Value = ddQuotationType.SelectedValue ' drLogin("Acc_Category").ToString() 
            If ddQuotationType.SelectedValue = "Export" Then
                ddCurrency.SelectedValue = "USD"
                divCurrencyRate.Visible = True


                divDomestic.Visible = True
                If ddPaymentTerms.SelectedValue <> "Pre Payment" Then

                    divmop.Visible = True
                End If
                Convertcurrency()

                ddPaymentTerms.Visible = True
                txttermpayment.Visible = False

                dddelivery.Visible = True
                txttermdelivery.Visible = False

                '  If Session("UserRoleID") = "1" Then
                '  divcalc.Visible = True
                'Else
                ' divcalc.Visible = False
                ' End If
            Else
                ddCurrency.SelectedValue = "INR"
                divCurrencyRate.Visible = False

                divDomestic.Visible = False
                divmop.Visible = False


                ddPaymentTerms.Visible = False
                txttermpayment.Visible = True

                dddelivery.Visible = False
                txttermdelivery.Visible = True

                divdocnclr.Visible = False
                divocnfre.Visible = False
                divins.Visible = False
                divinclude.Visible = False
            End If
            'If ddQuotationType.SelectedValue = "Domestic" Then
            '    divDomestic.Visible = False
            '    divmop.Visible = False
            'Else
            '    divDomestic.Visible = True
            '    'divmop.Visible = True
            '    Convertcurrency()
            'End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyQuotation", "CheckType", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    'Public Sub CheckType()
    '    Try
    '        ' Dim dt As DataSet = AccountBLL.SelectCategoryByAccId(ddrelatedtypeid.SelectedValue)
    '        ' Dim dtUser As New DataTable
    '        '' dtUser = dt.Tables(0)
    '        ' Dim drLogin As DataRow
    '        ' drLogin = dtUser.Rows(0)
    '        qtntype.Value = ddQuotationType.SelectedValue ' drLogin("Acc_Category").ToString() 
    '        If ddQuotationType.SelectedValue = "Export" Then
    '            ddCurrency.SelectedValue = "USD"
    '            divCurrencyRate.Visible = True
    '            ' divmop.Visible = True
    '            If Session("UserRoleID") = "1" Then
    '                '  divcalc.Visible = True
    '            Else
    '                ' divcalc.Visible = False
    '            End If
    '        Else
    '            ddCurrency.SelectedValue = "INR"
    '            divCurrencyRate.Visible = False
    '            ' divmop.Visible = False
    '        End If
    '        If ddQuotationType.SelectedValue = "Domestic" Then
    '            divDomestic.Visible = False
    '            'divmop.Visible = False
    '        Else
    '            divDomestic.Visible = True
    '            ' divmop.Visible = True
    '        End If
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert("ModifyQuotation", "CheckType", error1, Session("UserId"))
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub

    Protected Sub ddQuotationType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddQuotationType.SelectedIndexChanged
        Try
            If (ddQuotationType.SelectedValue = "Domestic") Then
                Dim ds As DataSet
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                If MainID = 0 Then
                    ds = MainBLL.DropdownWithtypeAndID1("AccountDropDowndomestic", "Account", Session("UserId"), ddQuotationType.SelectedValue)
                Else
                    ds = MainBLL.DropdownWithtype("EditAccountDropDown", ddQuotationType.SelectedValue)
                End If
                ddrelatedtypeid.DataSource = ds
                ddrelatedtypeid.DataTextField = "Acc_Name"
                ddrelatedtypeid.DataValueField = "Acc_Id"
                ddrelatedtypeid.DataBind()
                ddrelatedtypeid_SelectedIndexChanged(Nothing, Nothing)
                If ddrelatedtypeid.Items.Count >= 1 Then
                Else
                    ' ddrelatedtype.SelectedValue = "None"
                    ddrelatedtypeid.DataSource = ""
                    ddrelatedtypeid.DataBind()
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + ("No prospect found").ToString + "')", True)
                End If
                CheckType()
                ViewState("OrderProduct") = Nothing
                grditemproduct.DataSource = ""
                grditemproduct.DataBind()
                ' fillUser()
                'txtdispath.Text = ""
            ElseIf (ddQuotationType.SelectedValue = "Export") Then
                Dim ds As DataSet
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                If MainID = 0 Then
                    ds = MainBLL.DropdownWithtypeAndID1("AccountDropDowndomestic", "Account", Session("UserId"), ddQuotationType.SelectedValue)
                Else
                    ds = MainBLL.DropdownWithtype("EditAccountDropDown", ddQuotationType.SelectedValue)
                End If
                ddrelatedtypeid.DataSource = ds
                ddrelatedtypeid.DataTextField = "Acc_Name"
                ddrelatedtypeid.DataValueField = "Acc_Id"
                ddrelatedtypeid.DataBind()
                ddrelatedtypeid_SelectedIndexChanged(Nothing, Nothing)
                FillCountry()
                FillCountryCOO()
                FillStatebill()
                If ddrelatedtypeid.Items.Count >= 1 Then
                Else
                    ' ddrelatedtype.SelectedValue = "None"
                    ddrelatedtypeid.DataSource = ""
                    ddrelatedtypeid.DataBind()
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + ("No account found").ToString + "')", True)
                End If
                CheckType()
                ViewState("OrderProduct") = Nothing
                grditemproduct.DataSource = ""
                grditemproduct.DataBind()
                ' fillUser()
                ' txtdispath.Text = "Transport Agent"
                '  ddModeOfTransport_SelectedIndexChanged(ddModeOfTransport, New EventArgs())


                'ElseIf (ddrelatedtype.SelectedValue = "None") Then
                '    ddrelatedtypeid.DataSource = ""
                '    ddrelatedtypeid.DataBind()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyQuotation", "ddrelatedtype_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddModeOfTransport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddModeOfTransport.SelectedIndexChanged
        If ddModeOfTransport.SelectedValue = "Sea" Then
            txtPortLoading.Text = "Nhava Shiva"
        ElseIf ddModeOfTransport.SelectedValue = "Air" Then
            txtPortLoading.Text = "Sahara Airport"
        End If
    End Sub

    Public Sub FillCountry()
        Try
            Dim ds As DataSet = MainBLL.Dropdown("CountryDropDown")
            ddlcountrybill.DataSource = ds.Tables(0)
            ddlcountrybill.DataTextField = "CountryName"
            ddlcountrybill.DataValueField = "CountryName"
            ddlcountrybill.DataBind()
            ddlcountrybill.Items.Insert(0, New ListItem("Select Country", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyLead", "FillCountry", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillCountryCOO()
        Try
            Dim ds As DataSet = MainBLL.Dropdown("CountryDropDown")
            ddlcountrybillCOO.DataSource = ds.Tables(0)
            ddlcountrybillCOO.DataTextField = "CountryName"
            ddlcountrybillCOO.DataValueField = "CountryName"
            ddlcountrybillCOO.DataBind()
            ddlcountrybillCOO.Items.Insert(0, New ListItem("Select Country", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyLead", "FillCountry", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillStatebill()
        Try
            ddlstatebill.Items.Clear()
            Dim ds As DataSet = MainBLL.DropdownWithname("StateDropDownbyname", ddlcountrybill.SelectedValue)
            ddlstatebill.DataSource = ds.Tables(0)
            ddlstatebill.DataTextField = "StateName"
            ddlstatebill.DataValueField = "StateName"
            ddlstatebill.DataBind()
            ddlstatebill.Items.Insert(0, New ListItem("Select State", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyLead", "FillStatebill", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub ddPaymentTerms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddPaymentTerms.SelectedIndexChanged
        If ddPaymentTerms.SelectedValue = "Pre Payment" Then
            divmop.Visible = False
        ElseIf ddPaymentTerms.SelectedValue = "Payment Against Document" Then
            lbmopsub.Text = "Document"
            txtmopsub.ToolTip = "Document"
            txtmopsub.Attributes.Add("placeholder", "Document")
            divmop.Visible = True
        ElseIf ddPaymentTerms.SelectedValue = "Credit" Then
            lbmopsub.Text = "Number of days"
            txtmopsub.ToolTip = "Number of days"
            txtmopsub.Attributes.Add("placeholder", "Number of days")
            divmop.Visible = True
        End If
    End Sub

    Protected Sub ddlcountrybill_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlcountrybill.SelectedIndexChanged
        Try
            FillStatebill()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyLead", "ddlcountrybill_SelectedIndexChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub


    Public Sub fillaccount()
        Try
            ' ''Dim ds As DataSet = MainBLL.DropdownWithtypeAndID("ALLAccountDropDown", "Account", Session("UserId"))
            Dim ds As DataSet = MainBLL.DropdownWithtypeAndID("ALLAccountDropDownCopy", "Account", Session("UserId"))
            ddrelatedtypeid.DataSource = ds
            ddrelatedtypeid.DataTextField = "Acc_Name"
            ddrelatedtypeid.DataValueField = "Acc_Id"
            ddrelatedtypeid.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifySalesOrder", "fillaccount", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillcompany()
        Try
            Dim ds As DataSet = MainBLL.Dropdown("CompanyDropDown")
            ddlcompany.DataSource = ds
            ddlcompany.DataTextField = "Company_Name"
            ddlcompany.DataValueField = "Company_ID"
            ddlcompany.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifySalesOrder", "fillcompany", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    'Protected Sub ddrelatedtype_TextChanged(sender As Object, e As EventArgs) Handles ddrelatedtype.TextChanged
    '    Try
    '        If (ddrelatedtype.SelectedValue = "Account") Then
    '            Dim ds As DataSet = MainBLL.DropdownWithtype("AccountDropDown", "Account")
    '            ddrelatedtypeid.DataSource = ds
    '            ddrelatedtypeid.DataTextField = "Acc_Name"
    '            ddrelatedtypeid.DataValueField = "Acc_Id"
    '            ddrelatedtypeid.DataBind()
    '        ElseIf (ddrelatedtype.SelectedValue = "None") Then
    '            ddrelatedtypeid.DataSource = ""
    '            ddrelatedtypeid.DataBind()
    '        End If
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert("ModifySalesOrder", "ddrelatedtype_TextChanged", error1, Session("UserId"))
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub

    Protected Sub btnopen_Click(sender As Object, e As EventArgs) Handles btnopen.Click
        btnsave.Enabled = True
        btnsave.Text = "Save"
        hfbtnsave.Value = "All"
        mpe.Show()
        FillProductGrid()
    End Sub

    Protected Sub btnquickopen_Click(sender As Object, e As EventArgs) Handles btnquickopen.Click
        btnsave.Enabled = True
        btnsave.Text = "Save"
        hfbtnsave.Value = "Recent"
        mpe.Show()
        FillRecProductGrid()
    End Sub

    Public Sub FillProductGrid()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataTable = OrderBLL.GetProductsId(MainID).Tables(0)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim a As String = ""
                    strvat.Add(row("ProductId").ToString)
                Next
            End If
            'GridView1.DataSource = ProductBLL.CRMProductViewAll(ddrelatedtypeid.SelectedValue)
            'GridView1.DataBind()

            ViewState("Fillproduct") = ItemDetailBLL.ViewItemDetail(ddrelatedtypeid.SelectedValue).Tables(0)
            GridView1.DataSource = ViewState("Fillproduct")
            GridView1.DataBind()

            For Each value As String In strvat
                For Each row As GridViewRow In GridView1.Rows
                    Dim lblproductId = DirectCast(row.FindControl("lblproductId"), Label)
                    If lblproductId.Text = value Then
                        row.Visible = False
                    End If
                Next
            Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifySalesOrder", "FillProductGrid", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub FillSearch()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataTable = OrderBLL.GetProductsId(MainID).Tables(0)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim a As String = ""
                    strvat.Add(row("ProductId").ToString)
                Next
            End If
            '            GridView1.DataSource = ProductBLL.SearchCRMProduct(ddrelatedtypeid.SelectedValue, txtsearch.Text.Trim)
            GridView1.DataSource = ItemDetailBLL.Searchquationproduct(ddrelatedtypeid.SelectedValue, txtsearch.Text.Trim)
            GridView1.DataBind()
            For Each value As String In strvat
                For Each row As GridViewRow In GridView1.Rows
                    Dim lblproductId = DirectCast(row.FindControl("lblproductId"), Label)
                    If lblproductId.Text = value Then
                        row.Visible = False
                    End If
                Next
            Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifySalesOrder", "FillSearch", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub FillRecProductGrid()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataTable = OrderBLL.GetProductsId(MainID).Tables(0)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim a As String = ""
                    strvat.Add(row("ProductId").ToString)
                Next
            End If
            GridView1.DataSource = ProductBLL.CRMProductViewRec(ddrelatedtypeid.SelectedValue)
            GridView1.DataBind()
            For Each value As String In strvat
                For Each row As GridViewRow In GridView1.Rows
                    Dim lblproductId = DirectCast(row.FindControl("lblproductId"), Label)
                    If lblproductId.Text = value Then
                        row.Visible = False
                    End If
                Next
            Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifySalesOrder", "FillRecProductGrid", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    'Protected Sub txtOrderQty_TextChanged(sender As Object, e As EventArgs)
    '    Dim rd As TextBox = DirectCast(sender, TextBox)
    '    Dim row As GridViewRow = DirectCast(rd.NamingContainer, GridViewRow)
    '    Dim txtOrderQty As TextBox = TryCast(row.FindControl("txtOrderQty"), TextBox)
    '    Dim ltrate As Label = TryCast(row.FindControl("lblrate"), Label)
    '    Dim ltproductWeight As Label = TryCast(row.FindControl("ltproductWeight"), Label)
    '    Dim ltkg As Label = TryCast(row.FindControl("lblkgs"), Label)
    '    Dim ltamount As Label = TryCast(row.FindControl("lbltotalamount1"), Label)
    '    Dim lblvat As Label = TryCast(row.FindControl("lblvat"), Label)
    '    Dim lbldiscount As Label = TryCast(row.FindControl("lbldiscount"), Label)
    '    If txtOrderQty.Text = "" Then
    '        txtOrderQty.Text = 1
    '    End If
    '    If txtOrderQty.Text.Contains(".") Then
    '        txtOrderQty.Text = Math.Floor(CDbl(txtOrderQty.Text))
    '    End If
    '    If lbldiscount.Text = "" Then
    '    Else
    '        countrate = lbldiscount.Text / 100
    '        countrate1 = ltrate.Text * countrate
    '        ltrate.Text = ltrate.Text - countrate1
    '    End If
    '    ltkg.Text = ltproductWeight.Text * txtOrderQty.Text
    '    ltamount.Text = ltkg.Text * ltrate.Text
    '    Dim VAT As Double = Convert.ToDouble((lblvat.Text * ltamount.Text) / 100)
    '    ltamount.Text = (ltamount.Text + VAT).ToString("N2")
    'End Sub

    Protected Sub txt_TextChanged(sender As Object, e As EventArgs)

    End Sub



    Public Sub FillMainProduct()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            ' Dim DiscountAmount As Double = 0
            Dim ds As DataSet
            Dim dtOrderDetails As New DataTable
            Dim dtOrder As New DataTable
            ds = OrderBLL.FillOrderDetail(MainID)
            dtOrderDetails = ds.Tables(0)
            dtOrder = ds.Tables(1)
            Dim drOrder As DataRow
            drOrder = dtOrder.Rows(0)

            ' APPLY CASH DISCOUNT CHECKBOX
            If Not IsDBNull(drOrder("ApplyCashDiscount")) Then
                chkApplyCashDiscount.Checked = Convert.ToBoolean(drOrder("ApplyCashDiscount"))
            Else
                chkApplyCashDiscount.Checked = False
            End If

            grditemproduct.DataSource = dtOrderDetails
            grditemproduct.DataBind()


            ShowHideItemTotalKgsGSTVATfreight()


            If Request.QueryString("chk") = "v" Then

                grditemproduct.Columns(14).Visible = False


                btnadd.Visible = False
                txtpodate.Enabled = False
                txtpono.Enabled = False
                txtorderdate.Enabled = False
                txttermdelivery.Enabled = False
                txttermpayment.Enabled = False
                txtdispach.Enabled = False
                txtfreight.Enabled = False
                ddpayment.Enabled = False
                ddpayment.CssClass = " form-control"
                ddlcompany.Enabled = False
                ddlcompany.CssClass = " form-control"
                btnopen.Visible = False
                btnquickopen.Visible = False
                lbltitle1.Text = "View Sales Order"
                lbltitle2.Text = "View Sales Order"
                panel.Enabled = False
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
        End Try
    End Sub
    Protected Sub Convertcurrency()
        Try
            If txtCurrencyRate.Text = "" Then
                ServicePointManager.Expect100Continue = True
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                Dim web As New WebClient()
                ' Dim response As String = web.DownloadString("https://www.google.co.in/search?q=%241&oq=%2411")
                'also if need we can use as this https://www.google.co.in/search?ei=rOYgW4qBL4vVvASzhIhY&q=QAR+to+inr

                Dim response As String = web.DownloadString("https://www.google.co.in/search?ei=rOYgW4qBL4vVvASzhIhY&q=USD+to+inr")
                'Dim values As String() = Regex.Split(response, " Dollar = ")
                Dim values As String() = Regex.Split(response, "class=" + """" + "BNeawe iBp4i AP7Wnd" + """" + ">")
                'Dim rate As Decimal = System.Convert.ToDecimal(values(1).Substring(0, 5))
                Dim rate As Decimal = System.Convert.ToDecimal(values(2).Substring(0, 5))

                'Dim rate As Decimal = System.Convert.ToDecimal(values(0).Substring(values(0).Length - 5))
                txtCurrencyRate.Text = rate.ToString("N2").Replace("D", "")
            End If
        Catch ex As Exception
            If txtCurrencyRate.Text = "" Then
                txtCurrencyRate.Text = "65.23"
            End If
        End Try
    End Sub
    'Protected Sub Convertcurrency()
    '    Try
    '        If txtCurrencyRate.Text = "" Then

    '            Dim web As New WebClient()
    '            Dim response As String = web.DownloadString("https://finance.google.com/finance/converter?a=1&from=USD&to=INR&meta=ei%3Deq76Wbm0INq-uwS5hJ6gBg")
    '            Dim values As String() = Regex.Split(response, "class=bld>")
    '            Dim rate As Decimal = System.Convert.ToDecimal(values(1).Substring(0, 5))

    '            txtCurrencyRate.Text = rate.ToString("N2").Replace("D", "")
    '            ' End If

    '        End If
    '    Catch ex As Exception
    '        If txtCurrencyRate.Text = "" Then
    '            txtCurrencyRate.Text = "65.23"
    '        End If
    '    End Try
    'End Sub
    Public Sub FillDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "EditOrderViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            ddpayment.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_ModeofPayment").ToString())
            ddrelatedtypeid.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_CustId").ToString())
            txtpono.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_PoNo").ToString())
            If Not String.IsNullOrEmpty(drLogin("Order_PoDate").ToString()) Then
                txtpodate.Text = DynamicparcelDataManipulation.DateFormatDateMode(drLogin("Order_PoDate").ToString())
            End If
            'chkAddFreeSample.Checked = (drLogin("Order_AddFreeSample").ToString() = "True")
            hfgrand.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_CustId").ToString())
            lblordcode.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_Code").ToString())
            txtorderdate.Text = DynamicparcelDataManipulation.DateFormatDateTimeLocal(drLogin("Order_CreatedDate").ToString())

            txtdocnclr.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_Doc_Clearance").ToString())
            txtocfrei.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_OceanFreight").ToString())
            txtinsurance.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_Insurance").ToString())
            If DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_WithFreight").ToString()) = "" Then
                chkqif.Checked = "False"
            Else
                chkqif.Checked = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_WithFreight").ToString())
            End If

            Session("hreforder") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("hreforder").ToString())
            hforderhref.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("hreforder").ToString())
            '  txttermdelivery.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_TermsDelivery").ToString())
            ' txttermpayment.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_TermsPayment").ToString())
            txtdispach.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_Dispach").ToString())
            txtfreight.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_Freight").ToString())
            ' ddlcompany.SelectedValue  = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_Billedfrom").ToString())
            ddlbilledfrom.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_Billedfrom").ToString())
            txtCurrencyRate.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_CurrencyRate").ToString())
            If txtCurrencyRate.Text = "" Then
                Convertcurrency()
            End If

            Dim dt1 As DataSet = AccountBLL.SelectCategoryByAccId(ddrelatedtypeid.SelectedValue)
            Dim dtUser1 As New DataTable
            dtUser1 = dt1.Tables(0)
            Dim drLogin1 As DataRow
            drLogin1 = dtUser1.Rows(0)
            ' If drLogin("Acc_Category").ToString() = "Domestic" Then
            'divDomestic.Visible = False
            'ddQuotationType.SelectedValue = "Domestic"
            ' CheckType()
            'Else
            'divDomestic.Visible = True
            'ddQuotationType.SelectedValue = "Export"
            'CheckType()

            ' End If
            FillBanks()

            If drLogin("BankId").ToString() <> "" Then
                ddlBank.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("BankId").ToString())
            End If
            If drLogin1("Acc_Category").ToString() = "Domestic" Then
                ddQuotationType.SelectedValue = "Domestic"
                txttermpayment.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_TermsPayment").ToString())
                txttermdelivery.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_TermsDelivery").ToString())
                ddlPrint.SelectedValue = "INR"
            Else
                ddQuotationType.SelectedValue = "Export"
                ddModeOfTransport.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_ModeOfTransport").ToString())
                txtPortLoading.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_PortOfLoading").ToString())
                txtPortDischarge.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_PortOfDischarge").ToString())
                ddlcountrybillCOO.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_CountryOfOrigin").ToString())
                ddlcountrybill.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_CountryOfFinalDestination").ToString())
                ddlcountrybill_SelectedIndexChanged(Nothing, Nothing)
                ddlstatebill.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_FinalDestination").ToString())

                ddlPrint.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_PrintIn").ToString())

                dddelivery.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_TermsDelivery").ToString())
                dddelivery_TextChanged(Nothing, Nothing)
                ddPaymentTerms.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_TermsPayment").ToString())
                ddPaymentTerms_SelectedIndexChanged(Nothing, Nothing)
                txtmopsub.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_TrmsPyt_Card_doc").ToString())
            End If



            'ddQuotationType.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_TermsOfPayment").ToString())
        Catch ex As Exception
        End Try
    End Sub

    'Protected Sub txtquantity_TextChanged(sender As Object, e As EventArgs)
    '    Try
    '        Dim rd As TextBox = DirectCast(sender, TextBox)
    '        Dim row As GridViewRow = DirectCast(rd.NamingContainer, GridViewRow)
    '        Dim txtquantity As TextBox = TryCast(row.FindControl("txtquantity"), TextBox)
    '        Dim ltrate As Label = TryCast(row.FindControl("ltrate"), Label)
    '        Dim ltitemid As Label = TryCast(row.FindControl("ltitemid"), Label)
    '        Dim ltproductWeight As Label = TryCast(row.FindControl("ltproductWeight"), Label)
    '        Dim ltkg As Label = TryCast(row.FindControl("ltkg"), Label)
    '        Dim ltamount As Label = TryCast(row.FindControl("ltamount"), Label)
    '        Dim lblvat As Label = TryCast(row.FindControl("lblvat"), Label)
    '        Dim lblvatinrs As Label = TryCast(row.FindControl("lblvatinrs"), Label)
    '        If txtquantity.Text = "" Then
    '            txtquantity.Text = 1
    '        End If
    '        If txtquantity.Text.Contains(".") Then
    '            txtquantity.Text = Math.Floor(CDbl(txtquantity.Text))
    '        End If
    '        ltkg.Text = ltproductWeight.Text * txtquantity.Text
    '        ltamount.Text = ltkg.Text * ltrate.Text
    '        Dim VAT As Double = Convert.ToDouble((lblvat.Text * ltamount.Text) / 100)
    '        lblvatinrs.Text = VAT.ToString("N2")
    '        ltamount.Text = (ltamount.Text + VAT).ToString("N2")
    '        If grditemproduct.Rows.Count > 0 Then
    '            Dim lttotalamount As Label = DirectCast(grditemproduct.FooterRow.FindControl("lttotalamount"), Label)
    '            Dim lttotalvat As Label = DirectCast(grditemproduct.FooterRow.FindControl("lttotalvat"), Label)
    '            For i As Integer = 0 To grditemproduct.Rows.Count - 1
    '                ltamount = DirectCast(grditemproduct.Rows(i).FindControl("ltamount"), Label)
    '                lblvatinrs = DirectCast(grditemproduct.Rows(i).FindControl("lblvatinrs"), Label)
    '                VatAmount = VatAmount + lblvatinrs.Text
    '                FooterTotalAmount = FooterTotalAmount + ltamount.Text
    '            Next
    '            lttotalamount.Text = FooterTotalAmount.ToString("N2")
    '            lttotalvat.Text = VatAmount.ToString("N2")
    '        End If
    '        'ItemDetailBLL.Update(txtquantity.Text, ltamount.Text, ltitemid.Text)
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert("ItemDetailControl", "txtquantity_TextChanged", error1, Session("UserId"))
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grditemproduct.RowCommand
        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        If e.CommandName = "deletelink" Then
            Try
                Dim btn As LinkButton = TryCast(e.CommandSource, LinkButton)
                Dim row As GridViewRow = TryCast(btn.NamingContainer, GridViewRow)
                Dim ltitemid As Label = TryCast(row.FindControl("ltitemid"), Label)
                If grditemproduct.Rows.Count > 1 Then
                    OrderBLL.DeleteOrderItem(ltitemid.Text, MainID, Session("Audlog_Id"))
                Else
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('All products should not allow deleting,\n please add desire product then removing unwanted')", True)
                End If
                FillMainProduct()
                'If grditemproduct.Rows.Count > 0 Then
                '    Dim lttotalamount As Label = DirectCast(grditemproduct.FooterRow.FindControl("lttotalamount"), Label)
                '    Dim lttotalvat As Label = DirectCast(grditemproduct.FooterRow.FindControl("lttotalvat"), Label)
                '    For i As Integer = 0 To grditemproduct.Rows.Count - 1
                '        Dim ltamount As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltamount"), Label)
                '        Dim lblvatinrs As Label = DirectCast(grditemproduct.Rows(i).FindControl("lblvatinrs"), Label)
                '        VatAmount = VatAmount + lblvatinrs.Text
                '        FooterTotalAmount = FooterTotalAmount + ltamount.Text
                '    Next
                '    lttotalamount.Text = FooterTotalAmount
                '    lttotalvat.Text = VatAmount
                'End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ItemDetailControl", "deletelink", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
            'ElseIf e.CommandName = "Editlink" Then
            '    Dim btn As LinkButton = TryCast(e.CommandSource, LinkButton)
            '    Dim row As GridViewRow = TryCast(btn.NamingContainer, GridViewRow)
            '    Dim lnkedit As LinkButton = TryCast(row.FindControl("lnkedit"), LinkButton)
            '    Dim lkupdate As LinkButton = TryCast(row.FindControl("lkupdate"), LinkButton)
            '    Dim lnkdelete As LinkButton = TryCast(row.FindControl("lnkdelete"), LinkButton)
            '    Dim txtquantity As TextBox = TryCast(row.FindControl("txtquantity"), TextBox)
            '    Dim ltquantity As Label = TryCast(row.FindControl("ltquantity"), Label)
            '    ltquantity.Visible = False
            '    txtquantity.Visible = True
            '    lkupdate.Visible = True
            '    lnkdelete.Visible = False
            '    lnkedit.Text = "Cancel"
            '    lnkedit.CommandName = "Cancellink"
            '    lnkedit.CssClass = "btn btn-xs btn-warning"
            'ElseIf e.CommandName = "Cancellink" Then
            '    'Dim btn As LinkButton = TryCast(e.CommandSource, LinkButton)
            '    'Dim row As GridViewRow = TryCast(btn.NamingContainer, GridViewRow)
            '    'Dim lnkedit As LinkButton = TryCast(row.FindControl("lnkedit"), LinkButton)
            '    'Dim lkupdate As LinkButton = TryCast(row.FindControl("lkupdate"), LinkButton)
            '    'Dim lnkdelete As LinkButton = TryCast(row.FindControl("lnkdelete"), LinkButton)
            '    'Dim txtquantity As TextBox = TryCast(row.FindControl("txtquantity"), TextBox)
            '    'Dim ltquantity As Label = TryCast(row.FindControl("ltquantity"), Label)
            '    'ltquantity.Visible = True
            '    'txtquantity.Visible = False
            '    'lkupdate.Visible = False
            '    'lnkdelete.Visible = True
            '    'lnkedit.Text = "Edit"
            '    'lnkedit.CommandName = "Editlink"
            '    'lnkedit.CssClass = "btn btn-primary"
            '    FillMainProduct()
            'ElseIf e.CommandName = "updatelink" Then
            '    Dim btn As LinkButton = TryCast(e.CommandSource, LinkButton)
            '    Dim row As GridViewRow = TryCast(btn.NamingContainer, GridViewRow)
            '    Dim txtquantity As TextBox = TryCast(row.FindControl("txtquantity"), TextBox)
            '    Dim ltrate As Label = TryCast(row.FindControl("ltrate"), Label)
            '    Dim ltitemid As Label = TryCast(row.FindControl("ltitemid"), Label)
            '    Dim ltproductWeight As Label = TryCast(row.FindControl("ltproductWeight"), Label)
            '    Dim ltkg As Label = TryCast(row.FindControl("ltkg"), Label)
            '    Dim ltamount As Label = TryCast(row.FindControl("ltamount"), Label)
            '    Dim lnkedit As LinkButton = TryCast(row.FindControl("lnkedit"), LinkButton)
            '    Dim lkupdate As LinkButton = TryCast(row.FindControl("lkupdate"), LinkButton)
            '    Dim lnkdelete As LinkButton = TryCast(row.FindControl("lnkdelete"), LinkButton)
            '    Dim ltquantity As Label = TryCast(row.FindControl("ltquantity"), Label)
            '    Dim lblvat As Label = TryCast(row.FindControl("lblvat"), Label)
            '    Dim lblvatinrs As Label = TryCast(row.FindControl("lblvatinrs"), Label)
            '    If txtquantity.Text = "" Then
            '        txtquantity.Text = 1
            '    End If
            '    If txtquantity.Text.Contains(".") Then
            '        txtquantity.Text = Math.Floor(CDbl(txtquantity.Text))
            '    End If
            '    ltkg.Text = ltproductWeight.Text * txtquantity.Text
            '    ltamount.Text = ltkg.Text * ltrate.Text
            '    Dim VAT As Double = Convert.ToDouble((lblvat.Text * ltamount.Text) / 100)
            '    ltamount.Text = ltamount.Text + VAT
            '    ItemDetailBLL.Update(txtquantity.Text, ltamount.Text, ltitemid.Text)
            '    ltquantity.Text = txtquantity.Text
            '    ltquantity.Visible = True
            '    txtquantity.Visible = False
            '    lkupdate.Visible = False
            '    lnkdelete.Visible = True
            '    lnkedit.Text = "Edit"
            '    lnkedit.CommandName = "Editlink"
            '    lnkedit.CssClass = "btn btn-primary"
            '    If grditemproduct.Rows.Count > 0 Then
            '        Dim lttotalamount As Label = DirectCast(grditemproduct.FooterRow.FindControl("lttotalamount"), Label)
            '        Dim lttotalvat As Label = DirectCast(grditemproduct.FooterRow.FindControl("lttotalvat"), Label)
            '        For i As Integer = 0 To grditemproduct.Rows.Count - 1
            '            ltamount = DirectCast(grditemproduct.Rows(i).FindControl("ltamount"), Label)
            '            FooterTotalAmount = (FooterTotalAmount + ltamount.Text).ToString("N2")
            '        Next
            '        lttotalamount.Text = FooterTotalAmount
            '        OrderBLL.UpdateSalesOrder(ltitemid.Text, txtquantity.Text.Trim, ltamount.Text, lblvatinrs.Text, MainID, lttotalamount.Text, lttotalvat.Text, Session("Audlog_Id"))
            '    End If
        End If
    End Sub

    Protected Sub grditemproduct_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grditemproduct.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ''Dim ltproductid As Label = DirectCast(e.Row.FindControl("ltproductid"), Label)
            If Request.QueryString("chk") = "v" Then
                Dim txtquantity As TextBox = TryCast(e.Row.FindControl("txtquantity"), TextBox)
                txtquantity.ReadOnly = True
            End If
            If ddQuotationType.SelectedValue = "Export" Then
                Dim ltrate As Label = TryCast(e.Row.FindControl("ltrate"), Label)
                ltrate.Text = (Convert.ToDouble(ltrate.Text)).ToString("N2")
                If ddQuotationType.SelectedValue = "Export" Then
                    grditemproduct.Columns(5).Visible = True  '$rate/kg
                    grditemproduct.Columns(6).Visible = True  '$rate/sku
                    grditemproduct.Columns(7).Visible = False  'lotno
                    grditemproduct.Columns(8).Visible = False  'mfgdate
                    grditemproduct.Columns(9).Visible = False  'expdate
                    grditemproduct.Columns(11).Visible = False 'VAT
                    '   ltamtrupee.Visible = True 'rupee symbol
                    '  ltamtdollar.Visible = True  'dollar symbol  
                Else
                    grditemproduct.Columns(5).Visible = False  '$rate/kg
                    grditemproduct.Columns(6).Visible = False  '$rate/sku
                    grditemproduct.Columns(7).Visible = False  'lotno
                    grditemproduct.Columns(8).Visible = False  'mfgdate
                    grditemproduct.Columns(9).Visible = False  'expdate

                    grditemproduct.Columns(11).Visible = True 'VAT
                    '  ltamtrupee.Visible = True 'rupee symbol
                    'ltamtrupee.Visible = True 'rupee symbol
                End If
            Else
                Dim ltrate As Label = TryCast(e.Row.FindControl("ltrate"), Label)
                Dim lblLinkAs As Label = TryCast(e.Row.FindControl("lblLinkAs"), Label)
                If lblLinkAs.Text = "Sample" Then 'MUBYN due to sample round off removed
                    ltrate.Text = (Convert.ToDouble(ltrate.Text)).ToString("N2")
                Else
                    ltrate.Text = Math.Round(Convert.ToDouble(ltrate.Text)).ToString("N2")
                End If

                If ddQuotationType.SelectedValue = "Export" Then
                    grditemproduct.Columns(5).Visible = True  '$rate/kg
                    grditemproduct.Columns(6).Visible = True  '$rate/sku
                    grditemproduct.Columns(7).Visible = False  'lotno
                    grditemproduct.Columns(8).Visible = False  'mfgdate
                    grditemproduct.Columns(9).Visible = False  'expdate
                    grditemproduct.Columns(11).Visible = False 'VAT
                    '   ltamtrupee.Visible = True 'rupee symbol
                    '  ltamtdollar.Visible = True  'dollar symbol  
                Else
                    grditemproduct.Columns(5).Visible = False  '$rate/kg
                    grditemproduct.Columns(6).Visible = False  '$rate/sku
                    grditemproduct.Columns(7).Visible = False  'lotno
                    grditemproduct.Columns(8).Visible = False  'mfgdate
                    grditemproduct.Columns(9).Visible = False  'expdate

                    grditemproduct.Columns(11).Visible = True 'VAT
                    '  ltamtrupee.Visible = True 'rupee symbol
                    'ltamtrupee.Visible = True 'rupee symbol
                End If
            End If


        End If
    End Sub
    Protected Sub btnAddFreeSample_Click(sender As Object, e As EventArgs) Handles btnAddFreeSample.Click

        Dim orderId As Integer = 0

        If Not String.IsNullOrEmpty(Request.QueryString("Id")) Then
            Integer.TryParse(
            Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id"))),
            orderId
        )
        End If

        If orderId <= 0 Then
            ScriptManager.RegisterStartupScript(
            Me, Me.GetType(), "OrderError",
            "alert('Invalid Order ID. Please open an existing order.');", True
        )
            Return
        End If

        Response.Redirect("FreeSample.aspx?OrderID=" & orderId)

    End Sub
    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            If txtCurrencyRate.Text = "" Then
                txtCurrencyRate.Text = 1
            End If
            'Get Order ID before Free Sample validation
            MainID = Convert.ToInt32(
            Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        )
            '  FillMainProduct1()
            If ddQuotationType.SelectedValue = "Domestic" Then
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                If CDbl(hfgrandtotal.Value) > 0 Then
                    assigncontrol.AddAssignTo(MainID)
                    Dim totalgst As Double = 0
                    Dim totalallamount As Double = 0
                    For i As Integer = 0 To grditemproduct.Rows.Count - 1
                        Dim index As Integer = grditemproduct.Rows(i).RowIndex
                        Dim ltproductid As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltproductid"), Label)
                        Dim ltitemid As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltitemid"), Label)
                        Dim txtquantity As TextBox = TryCast(grditemproduct.Rows(i).FindControl("txtquantity"), TextBox)
                        Dim ltquantity As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltquantity"), Label)
                        Dim ltrate As Label = TryCast(grditemproduct.Rows(i).FindControl("ltrate"), Label)
                        Dim ltkg As Label = TryCast(grditemproduct.Rows(i).FindControl("ltkg"), Label)
                        Dim lblvat As Label = TryCast(grditemproduct.Rows(i).FindControl("lblvat"), Label)
                        Dim ltamount As Label = TryCast(grditemproduct.Rows(i).FindControl("ltamount"), Label)
                        Dim hfltamount As HiddenField = TryCast(grditemproduct.Rows(i).FindControl("hfltamount"), HiddenField)
                        Dim lblvatinrs As Label = TryCast(grditemproduct.Rows(i).FindControl("lblvatinrs"), Label)
                        Dim hflblvatinrs As HiddenField = TryCast(grditemproduct.Rows(i).FindControl("hflblvatinrs"), HiddenField)

                        totalallamount = totalallamount + CDbl(hfltamount.Value)
                        totalgst = totalgst + CDbl(hflblvatinrs.Value)

                        If Not txtquantity.Text = ltquantity.Text Then
                            'OrderBLL.UpdateSalesOrderF(ltitemid.Text, txtquantity.Text.Trim, hfltamount.Value, hflblvatinrs.Value, MainID, hfgrandtotal.Value, hftotalvat.Value, Session("Audlog_Id"), FreightTax.ToString)
                            ' ''OrderBLL.UpdateSalesOrder(ltitemid.Text, txtquantity.Text.Trim, hfltamount.Value, hflblvatinrs.Value, MainID, hfgrandtotal.Value, hftotalvat.Value, Session("Audlog_Id"))
                            ' ''OrderBLL.UpdateSalesOrder(ltitemid.Text, txtquantity.Text.Trim, hfltamount.Value, hflblvatinrs.Value, MainID, hfgrandtotal.Value, hftotalvat.Value, Session("Audlog_Id"))*********MUBYN
                            OrderBLL.UpdateSalesOrder(ltitemid.Text, txtquantity.Text.Trim, hfltamount.Value, hflblvatinrs.Value, MainID, Math.Round(CDbl(hfgrandtotal.Value)).ToString(), Math.Round(CDbl(hftotalvat.Value)).ToString(), Session("Audlog_Id"))
                        End If
                    Next
                    ''free sample
                    'If chkAddFreeSample.Checked Then

                    Dim freeSampleCount As Integer = GetFreeSampleCount(MainID)

                        If freeSampleCount > 0 Then
                            AddFreeSamplesToOrder(MainID, False)
                        End If

                    'End If
                    If txtfreight.Text = "" Then
                        txtfreight.Text = "0"
                    End If
                    Dim FreightTax As Double = ConfigurationManager.AppSettings("freightvalue")
                    ' ''Dim freightamt As Double = Math.Round(Convert.ToDouble(txtfreight.Text) * CDbl(FreightTax) / 100).ToString("N2")'***MUBYN
                    Dim freightamt As Double = (Convert.ToDouble(txtfreight.Text) * CDbl(FreightTax) / 100).ToString("N2")

                    txtorderdate.Text = Convert.ToDateTime(txtorderdate.Text).ToString("yyyy-MM-dd HH:mm ")
                    'OrderBLL.UpdateCRMSalesOrder(MainID, txtpono.Text.Trim, txtpodate.Text, ddpayment.SelectedValue, Session("Audlog_Id"), txtorderdate.Text, txttermdelivery.Text.Trim, txttermpayment.Text.Trim, txtdispach.Text.Trim, txtfreight.Text.Trim, ddlcompany.SelectedValue)

                    'Discount Amount
                    Dim DiscountAmount As Double = 0
                    Dim DiscountPer As Double = 0

                    If ViewState("CashDiscountPer") IsNot Nothing Then
                        DiscountPer = Convert.ToDouble(ViewState("CashDiscountPer"))
                    End If

                    Dim ProductTotal As Double = totalallamount

                    DiscountAmount = Math.Round((ProductTotal * DiscountPer) / 100, 2)

                    ViewState("Discount_Amount") = DiscountAmount

                    Dim ApplyCashDiscount As Boolean = False

                    If chkApplyCashDiscount IsNot Nothing Then
                        ApplyCashDiscount = chkApplyCashDiscount.Checked
                    End If

                    'End of Discount calculation

                    OrderBLL.UpdateCRMSalesOrderF(MainID, txtpono.Text.Trim, txtpodate.Text, ddpayment.SelectedValue, Session("UserId"), txtorderdate.Text, txttermdelivery.Text.Trim, txttermpayment.Text.Trim, txtdispach.Text.Trim, txtfreight.Text.Trim, CInt(ddlbilledfrom.SelectedValue), FreightTax, Math.Round(CDbl(hfgrandtotal.Value)).ToString("N2"), VatAmount, "INR", ddlBank.SelectedItem.Value, DiscountAmount, ApplyCashDiscount) ', DiscountAmount ' replacing ddlcompany.SelectedValue with CInt(ddlbilledfrom.SelectedValue)
                    ' ''totalgst = Math.Round(totalgst + freightamt).ToString("N2")**********MUBYN
                    totalgst = (totalgst + freightamt).ToString("N2")
                    ' ''totalallamount = totalallamount + totalgst'***********MUBYN
                    totalallamount = Math.Round((totalallamount + totalgst), 0, MidpointRounding.AwayFromZero).ToString("N2") '***********MUBYN
                    OrderBLL.Updateafterinsert(MainID, totalgst, totalallamount)
                    Dim uid As Integer? = Nothing
                    If Session("UserId") IsNot Nothing AndAlso IsNumeric(Session("UserId")) Then
                        uid = Convert.ToInt32(Session("UserId"))
                    End If
                    ActivityLogger.SaveLog(
    uid,
    Session("UName").ToString(),
    "ORDER_UPDATE",
    "Order Update",
    lblordcode.Text,
    "Order Update successfully | Account Name : " & ddrelatedtypeid.SelectedItem.Text &
    " | Order No : " & lblordcode.Text,
    Request
)
                    Dim lttotalamount As Label = TryCast(grditemproduct.FooterRow.FindControl("lttotalamount"), Label)

                    Dim dt As DataSet = OrderBLL.getOrderCode(MainID)
                    Dim dtUser As New DataTable
                    dtUser = dt.Tables(0)
                    Dim drLogin As DataRow
                    drLogin = dtUser.Rows(0)

                    Dim ordercode As String = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_Code").ToString())
                    ' Dim amount As Double = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_Amount").ToString())
                    Dim amount As Decimal = 0
                    If lttotalamount IsNot Nothing AndAlso IsNumeric(lttotalamount.Text) Then
                        amount = Math.Round(Convert.ToDecimal(lttotalamount.Text), 2, MidpointRounding.AwayFromZero)
                    End If


                    'amount = Math.Round(amount).ToString("N2")
                    ' Only when sending in message, convert to string with formatting:
                    Dim amountFormatted As String = amount.ToString("N2")

                    txtorderdate.Text = Convert.ToDateTime(txtorderdate.Text).ToString("yyyy-MM-dd")




                    'Dim isLocal As Boolean = HttpContext.Current.Request.IsLocal
                    'If isLocal = True Then
                    '    '  SendUsingSMPP.SendSMS("*ORDER UPDATED* Order No. " + ordercode + " amount has been updated to " + amount.ToString("N2") + " from " + SmsBLL.CustomerName(ddrelatedtypeid.SelectedValue).Replace(" ", "_") + " on " + txtorderdate.Text + ".", "9773409163")
                    'Else
                    '    SendUsingSMPP.SendSMS("*ORDER UPDATED* Order No. " + ordercode + " amount has been updated to " + amount.ToString("N2") + " from " + SmsBLL.CustomerName(ddrelatedtypeid.SelectedValue).Replace(" ", "_") + " on " + txtorderdate.Text + ".", "9892127786")
                    '    SendUsingSMPP.SendSMS("*ORDER UPDATED* Order No. " + ordercode + " amount has been updated to " + amount.ToString("N2") + " from " + SmsBLL.CustomerName(ddrelatedtypeid.SelectedValue).Replace(" ", "_") + " on " + txtorderdate.Text + ".", "9702044786")

                    'End If

                    'Dim isLocal As Boolean = HttpContext.Current.Request.IsLocal
                    'Dim customerName As String = SmsBLL.CustomerName(ddrelatedtypeid.SelectedValue)
                    'If isLocal Then
                    '    SendUsingSMPP.SendWhatsAppMessage(ordercode, amount, customerName, "9167263664", "update_order")
                    'Else
                    '    SendUsingSMPP.SendWhatsAppMessage(ordercode, amount, customerName, "9892127786", "update_order")
                    '    SendUsingSMPP.SendWhatsAppMessage(ordercode, amount, customerName, "9702044786", "update_order")
                    'End If

                    'Stop whatsapp message after approve uncomment  On 18-10-25 by Noor

                    Dim isLocal As Boolean = HttpContext.Current.Request.IsLocal
                    Dim customerName As String = SmsBLL.CustomerName(ddrelatedtypeid.SelectedValue)

                    ' Prepare template params for "new_order"
                    Dim orderParams As New List(Of String) From {
    ordercode,
    amount.ToString("N2"),
    customerName
}

                    If isLocal Then
                        SendUsingSMPP.SendWhatsAppMessage("9167263664", "update_order", orderParams)
                    Else
                        SendUsingSMPP.SendWhatsAppMessage("8309252022", "update_order", orderParams) ' 9892127786
                        SendUsingSMPP.SendWhatsAppMessage("9167263664", "update_order", orderParams) ' 9702044786
                    End If



                    Dim host As String = HttpContext.Current.Request.Url.Host
                    ' Dim url As String
                    Session("OrderEmailSubj") = "Order Updated-" + ordercode
                    Dim OrderID As Integer = MainID '123  ' Replace with actual Order ID
                    ' Dim ordercode As String = "ORD1234" ' Replace with actual order code
                    'Dim Freight As String = freightamt    '"100"  ' Replace with actual freight amount
                    Dim Freight As String = "0.00"
                    'If grditemproduct IsNot Nothing AndAlso grditemproduct.FooterRow IsNot Nothing Then
                    '    Dim lblFreight As Label = TryCast(grditemproduct.FooterRow.FindControl("lblfreight"), Label)
                    '    If lblFreight IsNot Nothing AndAlso IsNumeric(lblFreight.Text) Then
                    '        Freight = CDbl(lblFreight.Text).ToString("N2")
                    '    End If
                    'End If


                    Dim GST As String = totalgst '"50"  ' Replace with actual GST amount
                    Dim TCSAmount As String = "0"  ' Replace with actual TCS amount
                    Dim TotalAmount As String = amount '"1000"  ' Replace with actual total amount  irfan.bstar@gmail.com

                    Dim ODACharges As Double = 0.0

                    If grditemproduct IsNot Nothing AndAlso grditemproduct.FooterRow IsNot Nothing Then
                        Dim lblTcs As Label = TryCast(grditemproduct.FooterRow.FindControl("LblTcsAmount"), Label)
                        Dim lblOda As Label = TryCast(grditemproduct.FooterRow.FindControl("LblODAAmnt"), Label)
                        Dim lblFreight As Label = TryCast(grditemproduct.FooterRow.FindControl("lblfreight"), Label)
                        If lblFreight IsNot Nothing AndAlso IsNumeric(lblFreight.Text) Then
                            Freight = CDbl(lblFreight.Text).ToString("N2")
                        End If

                        If lblTcs IsNot Nothing AndAlso IsNumeric(lblTcs.Text) Then
                            TCSAmount = CDbl(lblTcs.Text).ToString("N2")
                        End If

                        ' Show ODA only when applicable flag is visible and label present
                        If lblODAApplicable IsNot Nothing AndAlso lblODAApplicable.Visible _
                         AndAlso lblOda IsNot Nothing AndAlso IsNumeric(lblOda.Text) Then
                            ODACharges = CDbl(lblOda.Text)
                        End If
                    End If
                    ' Ensure all values are properly formatted
                    Freight = If(IsNumeric(Freight), CDbl(Freight).ToString("N2"), "0.00")
                    GST = If(IsNumeric(GST), CDbl(GST).ToString("N2"), "0.00")
                    TCSAmount = If(IsNumeric(TCSAmount), CDbl(TCSAmount).ToString("N2"), "0.00")
                    TotalAmount = If(IsNumeric(TotalAmount), CDbl(TotalAmount).ToString("N2"), "0.00")

                    ' Dim recipientEmail As String = "irfan.bstar@gmail.com"
                    Dim recipientEmail As String = ""
                    Dim icount As Integer = 0
                    Dim CustId As Integer = OrderBLL.GetCustId(OrderID)
                    If CustId > 0 Then
                        Dim dts As DataSet = AccountBLL.GetAssignTo(CustId)

                        If dts IsNot Nothing AndAlso dts.Tables.Count > 0 AndAlso dts.Tables(0).Rows.Count > 0 Then
                            ' Debug Output
                            Console.WriteLine("Rows Found: " & dts.Tables(0).Rows.Count)
                            Console.WriteLine("U_Email: " & Convert.ToString(dts.Tables(0).Rows(0)("U_Email")))

                            recipientEmail = recipientEmail & Convert.ToString(dts.Tables(0).Rows(0)("U_Email"))

                            If icount < dts.Tables.Count AndAlso icount < dts.Tables(0).Rows.Count Then

                                recipientEmail = recipientEmail & ","

                            End If
                        Else

                            Console.WriteLine("Dataset is empty.")
                        End If
                    End If
                    'Temporary stop email on 10-10-25 by Noor
                    SendOrderUpdateEmail(OrderID, ordercode, Freight, GST, TCSAmount, TotalAmount, ODACharges, recipientEmail) 'DiscountAmount,

                    If host = "localhost" Then
                        '   Response.Redirect("http://localhost:56361/PrintSalesOrdergst1.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())) & "&Update=t&tp="  + HttpUtility.UrlEncode(Security.Encrypt(0)))
                        Response.Redirect("http://localhost:56361/PrintDocs.aspx?tpy=SENDSODom&type=pJyQIVSSnfWdSCc47JLzHg%3d%3d&Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID)) & "&Gyt32XyHTtsuc=" + HttpUtility.UrlEncode(Security.Encrypt((ddrelatedtypeid.SelectedValue))) & "&Update=t")
                        ' ''Response.Redirect("SalesOrders.aspx")
                    Else
                        ' ''Response.Redirect("http://b2b.swissbake.ch/PrintSalesOrdergst1.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())) & "&Update=t&tp=" + HttpUtility.UrlEncode(Security.Encrypt(0)))
                        'Response.Redirect("http://uatadmin.swissbake.in/PrintDocs.aspx?tpy=SENDSODom&type=pJyQIVSSnfWdSCc47JLzHg%3d%3d&Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID)) & "&Gyt32XyHTtsuc=" + HttpUtility.UrlEncode(Security.Encrypt((ddrelatedtypeid.SelectedValue))) & "&Update=t")
                        Response.Redirect("SalesOrdersNew.aspx")
                    End If

                    ' Response.Redirect("SalesOrders.aspx")
                Else
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Order amount should be greater than zero !!!')", True)
                End If
            ElseIf ddQuotationType.SelectedValue = "Export" Then
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                If CDbl(hfgrandtotal.Value) > 0 Then
                    assigncontrol.AddAssignTo(MainID)
                    For i As Integer = 0 To grditemproduct.Rows.Count - 1
                        Dim index As Integer = grditemproduct.Rows(i).RowIndex
                        Dim ltproductid As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltproductid"), Label)
                        Dim ltitemid As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltitemid"), Label)
                        Dim txtquantity As TextBox = TryCast(grditemproduct.Rows(i).FindControl("txtquantity"), TextBox)
                        Dim txtlot As TextBox = TryCast(grditemproduct.Rows(i).FindControl("txtlot"), TextBox)
                        Dim txtmfgdate As TextBox = TryCast(grditemproduct.Rows(i).FindControl("txtmfgdate"), TextBox)
                        Dim txtExpdate As TextBox = TryCast(grditemproduct.Rows(i).FindControl("txtExpdate"), TextBox)
                        Dim ltquantity As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltquantity"), Label)
                        Dim ltrate As Label = TryCast(grditemproduct.Rows(i).FindControl("ltrate"), Label)
                        Dim ltkg As Label = TryCast(grditemproduct.Rows(i).FindControl("ltkg"), Label)
                        Dim lblvat As Label = TryCast(grditemproduct.Rows(i).FindControl("lblvat"), Label)
                        Dim ltamount As Label = TryCast(grditemproduct.Rows(i).FindControl("ltamount"), Label)
                        Dim hfltamount As HiddenField = TryCast(grditemproduct.Rows(i).FindControl("hfltamount"), HiddenField)
                        Dim lblvatinrs As Label = TryCast(grditemproduct.Rows(i).FindControl("lblvatinrs"), Label)
                        Dim hflblvatinrs As HiddenField = TryCast(grditemproduct.Rows(i).FindControl("hflblvatinrs"), HiddenField)
                        If Not txtquantity.Text = ltquantity.Text Then
                            OrderBLL.UpdateSalesOrder(ltitemid.Text, txtquantity.Text.Trim, hfltamount.Value, 0, MainID, hfgrandtotal.Value, 0, Session("Audlog_Id"))
                        End If
                        OrderBLL.UpdateExpSalesOrder(ltitemid.Text, Session("Audlog_Id"), txtlot.Text.Trim, txtmfgdate.Text.Trim, txtExpdate.Text.Trim)
                    Next
                    'If chkAddFreeSample.Checked Then

                    Dim freeSampleCount As Integer = GetFreeSampleCount(MainID)

                        If freeSampleCount > 0 Then
                            AddFreeSamplesToOrder(MainID, True)
                        End If

                    'End If
                    txtorderdate.Text = Convert.ToDateTime(txtorderdate.Text).ToString("yyyy-MM-dd HH:mm ")
                    OrderBLL.UpdateCRMSalesOrderExport(MainID, txtpono.Text.Trim, txtpodate.Text, ddpayment.SelectedValue, Session("Audlog_Id"), txtorderdate.Text, dddelivery.SelectedValue, ddPaymentTerms.SelectedValue, txtdispach.Text.Trim, txtfreight.Text.Trim, CInt(ddlbilledfrom.SelectedValue), ddCurrency.SelectedValue, Convert.ToDouble(txtCurrencyRate.Text),
                                ddPaymentTerms.SelectedValue, ddModeOfTransport.SelectedValue, ddlcountrybillCOO.SelectedValue, ddlcountrybill.SelectedValue, txtPortLoading.Text, txtPortDischarge.Text,
                                ddlstatebill.SelectedValue, txtmopsub.Text.Trim, txtdocnclr.Text, txtocfrei.Text, txtinsurance.Text, chkqif.Checked, ddlPrint.SelectedValue) ' replacing ddlcompany.SelectedValue with CInt(ddlbilledfrom.SelectedValue)

                    Dim dt As DataSet = OrderBLL.getOrderCode(MainID)
                    Dim dtUser As New DataTable
                    dtUser = dt.Tables(0)
                    Dim drLogin As DataRow
                    drLogin = dtUser.Rows(0)

                    Dim ordercode As String = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_Code").ToString())
                    Dim amount As Double = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_Amount").ToString())
                    amount = Math.Round(amount).ToString("N2")
                    txtorderdate.Text = Convert.ToDateTime(txtorderdate.Text).ToString("yyyy-MM-dd")

                    ' Replace with the actual email address of the user or admin
                    Dim recipientEmail As String = "user@example.com"
                    SendOrderUpdateEmail1(ordercode, amount, recipientEmail)


                    'Dim isLocal As Boolean = HttpContext.Current.Request.IsLocal
                    'If isLocal = True Then
                    '    SendUsingSMPP.SendSMS("*ORDER UPDATED* Order No. " + ordercode + " amount has been updated to " + amount.ToString("N2") + " from " + SmsBLL.CustomerName(ddrelatedtypeid.SelectedValue).Replace(" ", "_") + " on " + txtorderdate.Text + ".", "9773409163")
                    'Else
                    '    SendUsingSMPP.SendSMS("*ORDER UPDATED* Order No. " + ordercode + " amount has been updated to " + amount.ToString("N2") + " from " + SmsBLL.CustomerName(ddrelatedtypeid.SelectedValue).Replace(" ", "_") + " on " + txtorderdate.Text + ".", "9892127786")
                    '    SendUsingSMPP.SendSMS("*ORDER UPDATED* Order No. " + ordercode + " amount has been updated to " + amount.ToString("N2") + " from " + SmsBLL.CustomerName(ddrelatedtypeid.SelectedValue).Replace(" ", "_") + " on " + txtorderdate.Text + ".", "9702044786")

                    'End If

                    'Dim host As String = HttpContext.Current.Request.Url.Host
                    '' Dim url As String
                    'Session("OrderEmailSubj") = "Order Updated-" + ordercode
                    'If host = "localhost" Then
                    '    Response.Redirect("http://localhost:56361/PrintSalesOrdergst1.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())) & "&tp=" + HttpUtility.UrlEncode(Security.Encrypt(0)))
                    'Else
                    '    Response.Redirect("http://b2b.swissbake.ch/PrintSalesOrdergst1.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())) & "&tp=" + HttpUtility.UrlEncode(Security.Encrypt(0)))

                    'End If

                    Response.Redirect("SalesOrders.aspx")
                Else
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Order amount should be greater than zero !!!')", True)
                End If
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("InsertSalesOrder", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    ''GetFreeSampleCount
    Private Function GetFreeSampleCount(orderId As Integer) As Integer

        Using con As New SqlConnection(conString)

            Dim query As String =
            "SELECT COUNT(*) FROM tblFreeSample WHERE FreeSample_OrderId = @OrderId"

            Using cmd As New SqlCommand(query, con)

                cmd.Parameters.AddWithValue("@OrderId", orderId)

                con.Open()
                Return Convert.ToInt32(cmd.ExecuteScalar())

            End Using

        End Using

    End Function

    'Private Sub AddFreeSamplesToOrder(orderId As Integer, isExport As Boolean)

    '    Using con As New SqlConnection(conString)

    '        Dim productIds As New List(Of Integer)

    '        Dim selectQuery As String =
    '        "SELECT FreeSample_ProductId FROM tblFreeSample WHERE FreeSample_OrderId = @OrderId"

    '        Using cmd As New SqlCommand(selectQuery, con)

    '            cmd.Parameters.AddWithValue("@OrderId", orderId)

    '            con.Open()

    '            Using dr As SqlDataReader = cmd.ExecuteReader()

    '                While dr.Read()
    '                    productIds.Add(Convert.ToInt32(dr("FreeSample_ProductId")))
    '                End While

    '            End Using

    '        End Using

    '        For Each productId As Integer In productIds

    '            If isExport Then

    '                OrderBLL.Main_ExportOrder_Details(
    '                orderId,
    '                productId.ToString(),
    '                "1",
    '                "0",
    '                0.0R,
    '                0.0R,
    '                "",
    '                "",
    '                ""
    '            )

    '            Else

    '                OrderBLL.Main_Order_Details(
    '                orderId,
    '                productId,
    '                1,
    '                0.0R,
    '                0.0R,
    '                0.0R
    '            )

    '            End If

    '        Next

    '        'Delete only samples belonging to this order
    '        Using deleteCmd As New SqlCommand(
    '        "DELETE FROM tblFreeSample WHERE FreeSample_OrderId = @OrderId", con)

    '            deleteCmd.Parameters.AddWithValue("@OrderId", orderId)
    '            deleteCmd.ExecuteNonQuery()

    '        End Using

    '    End Using

    'End Sub
    Private Sub AddFreeSamplesToOrder(orderId As Integer, isExport As Boolean)

        Using con As New SqlConnection(conString)

            Dim samples As New DataTable()

            Dim selectQuery As String = "SELECT FreeSample_ProductId, FreeSample_Amount FROM tblFreeSample WHERE FreeSample_OrderId = @OrderId"

            Using cmd As New SqlCommand(selectQuery, con)
                cmd.Parameters.AddWithValue("@OrderId", orderId)

                Using da As New SqlDataAdapter(cmd)
                    da.Fill(samples)
                End Using
            End Using

            For Each row As DataRow In samples.Rows

                Dim productId As Integer = Convert.ToInt32(row("FreeSample_ProductId"))
                Dim amount As Double = If(IsDBNull(row("FreeSample_Amount")), 0, Convert.ToDouble(row("FreeSample_Amount")))

                If isExport Then

                    '    OrderBLL.Main_ExportOrder_Details(
                    '    orderId, productId, 1, amount, amount, 0,
                    '    "", "", ""
                    ')
                    OrderBLL.Main_ExportOrder_Details(orderId, productId, 1, amount, amount, 0, "", "", "", True)

                Else

                    '    OrderBLL.Main_Order_Details(
                    '    orderId, productId, 1, amount, amount, 0
                    ')
                    OrderBLL.Main_Order_Details(orderId, productId, 1, amount, amount, 0, True)

                End If

            Next

            Using deleteCmd As New SqlCommand("DELETE FROM tblFreeSample WHERE FreeSample_OrderId = @OrderId", con)
                deleteCmd.Parameters.AddWithValue("@OrderId", orderId)
                con.Open()
                deleteCmd.ExecuteNonQuery()
            End Using

        End Using

    End Sub
    'edit order email 
    Private Sub SendOrderUpdateEmail1(ByVal orderCode As String, ByVal amount As Double, ByVal recipientEmail As String)
        Try
            Dim mail As New MailMessage()
            Dim smtpServer As New SmtpClient("smtp.gmail.com")

            mail.From = New MailAddress("nooruddinkhan1521@gmail.com")
            mail.To.Add(recipientEmail)
            mail.Subject = "Order Updated - " & orderCode
            mail.Body = "Dear Customer, " & vbCrLf &
                         "The order with Order Code " & orderCode & " has been updated. The new amount is INR " & amount.ToString("N2") & "." & vbCrLf &
                         "Thank you for your business!"

            smtpServer.Port = 587 ' SMTP port
            smtpServer.Credentials = New NetworkCredential("nooruddinkhan1521@gmail.com", "fqnb jxwf ceof iwsc")
            smtpServer.EnableSsl = True

            smtpServer.Send(mail)
        Catch ex As Exception
            ' Log the error or handle it as needed
            Console.WriteLine("Error sending email: " & ex.Message)
        End Try
    End Sub
    'Public Sub SendOrderUpdateEmail(ByVal OrderID As Integer, ByVal Ordercode As String, ByVal Freight As String, ByVal GST As String, ByVal TCSAmount As String, ByVal TotalAmount As String)
    '    Try
    '        Dim sb As New StringBuilder
    '        Dim count As Integer = 1
    '        Dim s As String = ""
    '        Dim body As String = String.Empty
    '        Dim reader As StreamReader = New StreamReader(Server.MapPath("~/Email/Order_Placing.html"))
    '        body = reader.ReadToEnd
    '        Dim totalQty As String
    '        totalQty = 0
    '        Dim SubTotal As String
    '        SubTotal = 0
    '        Dim ds As DataSet = MainBLL.ViewByID(OrderID, "OrderProductViewByID")
    '        Dim dt As DataTable = ds.Tables(0)

    '        Dim dsBank As DataSet = MainBLL.GetOrderBankDetails(OrderID)
    '        Dim dtBank As DataTable = dsBank.Tables(0)

    '        sb.Append("<table border='1' cellspacing='0' cellpadding='5' style='border-color: rgb(247, 247, 247);width:100%;text-align:center;'><tr>")
    '        sb.Append("<th><center>SR</center></th>")
    '        sb.Append("<th><center>PRODUCT NAME</center></th>")
    '        sb.Append("<th style='width:15%;'><center>SKU</center></th>")
    '        sb.Append("<th style='width:15%;'><center>ORDERED QTY</center></th>")
    '        sb.Append("<th style='width:15%;'><center>ORDERED QTY Total</center></th>")
    '        sb.Append("<th style='width:15%;'><center>TOTAL AMOUNT</center></th></tr>")
    '        For Each dr As DataRow In dt.Rows
    '            sb.Append("<tr><td>" + count.ToString + "</td>")
    '            sb.Append("<td>" + dr("Product_Name").ToString + "</td>")
    '            sb.Append("<td>" + dr("Packing_Packing").ToString + "</td>")
    '            sb.Append("<td>" + dr("OrDetail_Qty").ToString + "</td>")
    '            sb.Append("<td>" + (dr("OrDetail_Qty") * dr("Packing_Weight")).ToString + " KG </td>")
    '            sb.Append("<td style='text-align: right;'> &#8377; " + dr("OrDetail_Amount").ToString + "</td></tr>")
    '            count = count + 1
    '            totalQty = totalQty + dr("OrDetail_Qty") * dr("Packing_Weight")
    '            SubTotal = SubTotal + dr("OrDetail_Amount")
    '        Next
    '        totalQty = totalQty
    '        sb.Append("<tr><th colspan='4' style='text-align: left;border-bottom:none;'><b style='font-weight:600'>SUB TOTAL</b></th><td><b style='font-weight:600;'>" + CInt(totalQty).ToString("N2") + " KG </b></td><td style='text-align: right;'><b style='font-weight:600;'>&#8377; " + CInt(SubTotal).ToString("N2") + "</b></td></tr>")
    '        sb.Append("<tr><th colspan='4' style='text-align: left;border-bottom:none;border-top:none;'><b style='font-weight:600'>FREIGHT AMOUNT</b></th><td> (+) </td><td style='text-align: right;'>&#8377; " + Freight + "</td></tr>")
    '        sb.Append("<tr><th colspan='4' style='text-align: left;border-top:none;border-bottom:none;'><b style='font-weight:600'>TOTAL GST</b></th><td> (+) </td><td style='text-align: right;'>&#8377; " + GST + "</td></tr>")

    '        If TCSAmount > 0 Then
    '            sb.Append("<tr><th colspan='4' style='text-align: left;border-top:none;border-bottom:none;'><b style='font-weight:600'>TCS AMOUNT</b></th><td> (+) </td><td style='text-align: right;'>&#8377; " + TCSAmount + "</td></tr>")
    '        End If

    '        sb.Append("<tr><th colspan='4' style='text-align: left;border-top:none;'><b style='font-weight:600'>AMOUNT PAYABLE</b></th><th colspan='2' style='text-align: right;'><b style='font-weight:600;'>&#8377; " + TotalAmount + "</b></th></tr>")

    '        'sb.Append("<tr><th colspan='2' style='text-align: left;'><b style='font-weight:600'>SUB TOTAL</b></th><td></td><td>" + hftotalq.Value + "</td><td>" + CInt(totalQty).ToString("N2") + " KG </td><td style='text-align: right;'> &#8377; " + hfsubtotal.Value + "</td></tr>")
    '        'sb.Append("<tr><th colspan='2' style='text-align: left;'><b style='font-weight:600'>GST</b></th><td></td><td></td><td> (+) </td><td style='text-align: right;'> &#8377; " + hfvat.Value + "</td></tr>")
    '        'sb.Append("<tr><th colspan='2' style='text-align: left;'><b style='font-weight:600'>FREIGHT</b></th><td></td><td></td><td> (+) </td><td style='text-align: right;'>&#8377; 200.00</td></tr>")
    '        'sb.Append("<tr><th colspan='3' style='text-align: left;'><b style='font-weight:600'>AMOUNT PAYABLE</b></th><td></td><td></td><th colspan='2' style='text-align: right;'><b style='font-weight:600'> &#8377; " + hfgrand.Value + "</b></th></tr>")
    '        sb.Append("</table>")

    '        body = body.Replace("#Table", sb.ToString)

    '        body = body.Replace("#ORDERID", Ordercode)
    '        'body = body.Replace("#NAME", Session("UserName"))
    '        body = body.Replace("#NAME", ddrelatedtypeid.SelectedItem.Text.Substring(0, ddrelatedtypeid.SelectedItem.Text.IndexOf("-")).Trim())

    '        If (dtBank.Rows.Count > 0) Then
    '            body = body.Replace("#BankName", dtBank.Rows(0)("Name").ToString())
    '            body = body.Replace("#AccountNo", dtBank.Rows(0)("AccountNum").ToString())
    '            body = body.Replace("#IFSCCode", dtBank.Rows(0)("IFSCCode").ToString())
    '            body = body.Replace("#Branch", dtBank.Rows(0)("Branch").ToString())
    '        End If


    '        Dim email As String = MainBLL.Email(ddrelatedtypeid.SelectedItem.Value)

    '        SendMailBLL.SendMail(email, body.ToString, "Your SwissBake order no. " + Ordercode + " has been placed")
    '        reader.Dispose()


    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert("ModifySalesOrder", "NewOrderCreatedMail", error1, Session("UserId"))
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub
    Public Sub SendOrderUpdateEmail(ByVal OrderID As Integer, ByVal Ordercode As String, ByVal Freight As String, ByVal GST As String, ByVal TCSAmount As String, ByVal TotalAmount As String, ByVal ODACharges As Double, ByVal recipientEmail As String) 'ByVal DiscountAmount As Double,
        Try
            ' Initialize StringBuilder for email content
            Dim sb As New StringBuilder
            Dim count As Integer = 1
            Dim body As String = String.Empty
            Dim totalQty As String = "0"
            Dim SubTotal As String = "0"

            ' Read the email template
            Dim reader As StreamReader = New StreamReader(Server.MapPath("~/Email/Order_Placing.html"))
            body = reader.ReadToEnd()
            reader.Dispose()

            ' Fetch order product details (Hardcoded for now)
            Dim ds As DataSet = MainBLL.ViewByID(OrderID, "OrderProductViewByID")
            Dim dt As DataTable = ds.Tables(0)

            ' Fetch bank details (Hardcoded for now)
            Dim dsBank As DataSet = MainBLL.GetOrderBankDetails(OrderID)
            Dim dtBank As DataTable = dsBank.Tables(0)

            ' Constructing order table manually with hardcoded values
            sb.Append("<table border='1' cellspacing='0' cellpadding='5' style='border-color: rgb(247, 247, 247);width:100%;text-align:center;'><tr>")
            sb.Append("<th><center>SR</center></th>")
            sb.Append("<th><center>PRODUCT NAME</center></th>")
            sb.Append("<th style='width:15%;'><center>SKU</center></th>")
            sb.Append("<th style='width:15%;'><center>ORDERED QTY</center></th>")
            sb.Append("<th style='width:15%;'><center>ORDERED QTY Total</center></th>")
            sb.Append("<th style='width:15%;'><center>TOTAL AMOUNT</center></th></tr>")


            For Each dr As DataRow In dt.Rows
                sb.Append("<tr><td>" + count.ToString + "</td>")
                sb.Append("<td>" + dr("Product_Name").ToString + "</td>")
                sb.Append("<td>" + dr("Packing_Packing").ToString + "</td>")
                sb.Append("<td>" + dr("OrDetail_Qty").ToString + "</td>")
                sb.Append("<td>" + (dr("OrDetail_Qty") * dr("Packing_Weight")).ToString + " KG </td>")
                sb.Append("<td style='text-align: right;'> &#8377; " + dr("OrDetail_Amount").ToString + "</td></tr>")
                count = count + 1
                totalQty = totalQty + dr("OrDetail_Qty") * dr("Packing_Weight")
                SubTotal = SubTotal + dr("OrDetail_Amount")
            Next
            totalQty = totalQty
            sb.Append("<tr><th colspan='4' style='text-align: left;border-bottom:none;'><b style='font-weight:600'>SUB TOTAL</b></th><td><b style='font-weight:600;'>" + CInt(totalQty).ToString("N2") + " KG </b></td><td style='text-align: right;'><b style='font-weight:600;'>&#8377; " + CInt(SubTotal).ToString("N2") + "</b></td></tr>")
            '=======================
            ' DISCOUNT IN EMAIL 
            '=======================
            'If DiscountAmount > 0 Then
            '    sb.Append("<tr><th colspan='4' style='text-align: left;border-top:none;border-bottom:none;'><b style='font-weight:600'>DISCOUNT AMOUNT</b></th><td> (-) </td><td style='text-align: right;'>&#8377; " + DiscountAmount.ToString("N2") + "</td></tr>")
            'End If

            ' Add ODA Charges to the email body
            If ODACharges > 0 Then
                sb.Append("<tr><th colspan='4' style='text-align: left;border-top:none;'><b style='font-weight:600'>ODA CHARGES</b></th><td> (+) </td><td style='text-align: right;'>&#8377; " + ODACharges.ToString("N2") + "</td></tr>")
            End If
            sb.Append("<tr><th colspan='4' style='text-align: left;border-bottom:none;border-top:none;'><b style='font-weight:600'>FREIGHT AMOUNT</b></th><td> (+) </td><td style='text-align: right;'>&#8377; " + Freight + "</td></tr>")
            sb.Append("<tr><th colspan='4' style='text-align: left;border-top:none;border-bottom:none;'><b style='font-weight:600'>TOTAL GST</b></th><td> (+) </td><td style='text-align: right;'>&#8377; " + GST + "</td></tr>")

            If TCSAmount > 0 Then
                sb.Append("<tr><th colspan='4' style='text-align: left;border-top:none;border-bottom:none;'><b style='font-weight:600'>TCS AMOUNT</b></th><td> (+) </td><td style='text-align: right;'>&#8377; " + TCSAmount + "</td></tr>")
            End If

            sb.Append("<tr><th colspan='4' style='text-align: left;border-top:none;'><b style='font-weight:600'>AMOUNT PAYABLE</b></th><th colspan='2' style='text-align: right;'><b style='font-weight:600;'>&#8377; " + (Convert.ToDouble(TotalAmount) + ODACharges + TCSAmount).ToString("N2") + "</b></th></tr>")
            'sb.Append("<tr><th colspan='4' style='text-align: left;border-top:none;'><b style='font-weight:600'>AMOUNT PAYABLE</b></th><th colspan='2' style='text-align: right;'><b style='font-weight:600;'>&#8377; " + (Convert.ToDouble(TotalAmount) + ODACharges + TCSAmount + Freight + GST).ToString("N2") + "</b></th></tr>")
            'sb.Append("<tr><th colspan='2' style='text-align: left;'><b style='font-weight:600'>SUB TOTAL</b></th><td></td><td>" + hftotalq.Value + "</td><td>" + CInt(totalQty).ToString("N2") + " KG </td><td style='text-align: right;'> &#8377; " + hfsubtotal.Value + "</td></tr>")
            'sb.Append("<tr><th colspan='2' style='text-align: left;'><b style='font-weight:600'>GST</b></th><td></td><td></td><td> (+) </td><td style='text-align: right;'> &#8377; " + hfvat.Value + "</td></tr>")
            'sb.Append("<tr><th colspan='2' style='text-align: left;'><b style='font-weight:600'>FREIGHT</b></th><td></td><td></td><td> (+) </td><td style='text-align: right;'>&#8377; 200.00</td></tr>")
            'sb.Append("<tr><th colspan='3' style='text-align: left;'><b style='font-weight:600'>AMOUNT PAYABLE</b></th><td></td><td></td><th colspan='2' style='text-align: right;'><b style='font-weight:600'> &#8377; " + hfgrand.Value + "</b></th></tr>")
            sb.Append("</table>")

            body = body.Replace("#Table", sb.ToString)

            body = body.Replace("#ORDERID", Ordercode)
            'body = body.Replace("#NAME", Session("UserName"))
            body = body.Replace("#NAME", ddrelatedtypeid.SelectedItem.Text.Substring(0, ddrelatedtypeid.SelectedItem.Text.IndexOf("-")).Trim())

            If (dtBank.Rows.Count > 0) Then
                body = body.Replace("#BankName", dtBank.Rows(0)("Name").ToString())
                body = body.Replace("#AccountNo", dtBank.Rows(0)("AccountNum").ToString())
                body = body.Replace("#IFSCCode", dtBank.Rows(0)("IFSCCode").ToString())
                body = body.Replace("#Branch", dtBank.Rows(0)("Branch").ToString())
            End If




            ' Hardcoded email address for now
            Dim email As String = MainBLL.Email(ddrelatedtypeid.SelectedItem.Value)

            'body = "Helllo Testing.."
            ' Send email (Uncomment the line below when using actual email sending)
            If String.IsNullOrEmpty(email) Then
                email = MainBLL.Email(ddrelatedtypeid.SelectedItem.Value)
                ' Else
                '  email &= "," & MainBLL.Email(hfcustId.Value)
            End If

            'merge recipient email 

            If Not String.IsNullOrEmpty(recipientEmail) Then
                If Not String.IsNullOrEmpty(email) Then
                    email &= "," & recipientEmail
                Else
                    email = recipientEmail
                End If
            End If

            SendMailBLL.SendMail(email, body.ToString(), "Your SwissBake order no. " + Ordercode + " has been Updated")
            reader.Dispose()
            'Dim mail As New MailMessage()
            'Dim smtpServer As New SmtpClient("smtp.gmail.com")

            'mail.From = New MailAddress("nooruddinkhan1521@gmail.com")
            'mail.To.Add(email)
            'mail.Subject = "Your SwissBake order no. " + Ordercode + " has been Updated" '"Order Updated - " & Ordercode
            'mail.Body = body.ToString
            ''"Dear Customer, " & vbCrLf &
            ''            "The order with Order Code " & Ordercode & " has been updated. The new amount is INR " & amount.ToString("N2") & "." & vbCrLf &
            ''           "Thank you for your business!"

            'smtpServer.Port = 587 ' SMTP port
            'smtpServer.Credentials = New NetworkCredential("nooruddinkhan1521@gmail.com", "fqnb jxwf ceof iwsc")
            'smtpServer.EnableSsl = True
            'mail.IsBodyHtml = True
            'smtpServer.Send(mail)

        Catch ex As Exception
            ' Handle exceptions
            Dim error1 As String = ex.Message.Replace(Chr(34), "").Replace(Chr(39), "")
            ' Log error (Uncomment when logging is needed)
            ExecptionBLL.Insert("ModifySalesOrder", "NewOrderCreatedMail", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + error1.ToString() + "')", True)
        End Try
    End Sub

    Private Sub chkInvoice()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If Request.QueryString("chk") = "e" Then
                If OrderBLL.ChkInvoiceGenrated(MainID) > 0 Then
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('This Order is already in Process and Invoice has been Generated');window.location='SalesOrders.aspx';", True)
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("InsertSalesOrder", "chkInvoice", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "');window.location='SalesOrders.aspx';", True)
        End Try
    End Sub

    Public Sub FillBillingAddressDetail()
        Try
            ' ''countrydt = MainBLL.Dropdown("CountryDropDown").Tables(0)
            ' ''statedt = MainBLL.Dropdown("ALLStateDropDown").Tables(0)
            MainID = ddrelatedtypeid.SelectedValue
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "ProspectBillingAddressViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                If String.IsNullOrEmpty(drLogin("AccAddr_Name").ToString()) Then
                    lblnamebill.Visible = False
                Else
                    lblnamebill.Visible = True
                    lblnamebill.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Name").ToString()) + " - " + DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Code").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("AccAddr_Email").ToString()) Then
                    lblemailbill.Visible = False
                    bemail.Visible = False
                Else
                    bemail.Visible = True
                    lblemailbill.Visible = True
                    lblemailbill.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Email").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("AccAddr_Telephone").ToString()) Then
                    lbltelephonebill.Visible = False
                    bphone.Visible = False
                Else
                    bphone.Visible = True
                    lbltelephonebill.Visible = True
                    lbltelephonebill.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Telephone").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("AccAddr_Address").ToString()) Then
                    lbladdressbill.Visible = False
                Else
                    lbladdressbill.Visible = True
                    lbladdressbill.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Address").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("AccAddr_Pincode").ToString()) Then
                    lblpincodebill.Visible = False
                Else
                    lblpincodebill.Visible = True
                    lblpincodebill.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Pincode").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("AccAddr_City").ToString()) Then
                    lblCitybill.Visible = False
                Else
                    lblCitybill.Visible = True
                    lblCitybill.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_City").ToString())
                End If
                'Dim country As Array = countrydt.Select("ID = '" + drLogin("AccAddr_Country").ToString() + "'")
                'If country.Length <> 0 Then
                If Not String.IsNullOrEmpty(drLogin("CountryName").ToString()) Then
                    lblcountrybill.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CountryName").ToString())
                End If
                'Dim state As Array = statedt.Select("ID = '" + drLogin("AccAddr_State").ToString() + "'")
                'If state.Length <> 0 Then
                If Not String.IsNullOrEmpty(drLogin("StateName").ToString()) Then
                    lblsatatebill.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("StateName").ToString())
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifySalesOrder", "FillBillingAddressDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillShippingAddressDetail()
        Try
            ' ''countrydt = MainBLL.Dropdown("CountryDropDown").Tables(0)
            ' ''statedt = MainBLL.Dropdown("ALLStateDropDown").Tables(0)
            MainID = ddrelatedtypeid.SelectedValue
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "ProspectShippingAddressViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                If String.IsNullOrEmpty(drLogin("AccAddr_Name").ToString()) Then
                    lblnameship.Visible = False
                Else
                    lblnameship.Visible = True
                    lblnameship.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Name").ToString()) + " - " + DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Code").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("AccAddr_Email").ToString()) Then
                    lblemailship.Visible = False
                    semail.Visible = False
                Else
                    semail.Visible = True
                    lblemailship.Visible = True
                    lblemailship.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Email").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("AccAddr_Telephone").ToString()) Then
                    lbltelephoneship.Visible = False
                    sphone.Visible = False
                Else
                    sphone.Visible = True
                    lbltelephoneship.Visible = True
                    lbltelephoneship.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Telephone").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("AccAddr_Address").ToString()) Then
                    lbladdressShip.Visible = False
                Else
                    lbladdressShip.Visible = True
                    lbladdressShip.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Address").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("AccAddr_Pincode").ToString()) Then
                    lblpincodeship.Visible = False
                Else
                    lblpincodeship.Visible = True
                    lblpincodeship.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Pincode").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("AccAddr_City").ToString()) Then
                    lblCityship.Visible = False
                Else
                    lblCityship.Visible = True
                    lblCityship.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_City").ToString())
                End If
                ' ''Dim country As Array = countrydt.Select("ID = '" + drLogin("AccAddr_Country").ToString() + "'")
                ' ''If country.Length <> 0 Then
                If Not String.IsNullOrEmpty(drLogin("AccAddr_Country").ToString()) Then
                    lblcountryship.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Country").ToString())
                End If
                ' ''Dim state As Array = statedt.Select("ID = '" + drLogin("AccAddr_State").ToString() + "'")
                ' ''If state.Length <> 0 Then
                If Not String.IsNullOrEmpty(drLogin("AccAddr_State").ToString()) Then
                    lblsatateship.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_State").ToString())
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifySalesOrder", "FillShippingAddressDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillShipAddrByOrderId()
        Try
            ' ''countrydt = MainBLL.Dropdown("CountryDropDown").Tables(0)
            ' ''statedt = MainBLL.Dropdown("ALLStateDropDown").Tables(0)
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "ShipAddrByOrderId")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count = 0 Then
                OrderBLL.CopyAddr(MainID)
                dt = MainBLL.ViewByID(MainID, "ShipAddrByOrderId")
                dtUser = dt.Tables(0)
            End If

            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                If String.IsNullOrEmpty(drLogin("OrderAddr_Name").ToString()) Then
                    lblnameship.Visible = False
                Else
                    lblnameship.Visible = True
                    lblnameship.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("OrderAddr_Name").ToString()) + " - " + DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Code").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("OrderAddr_Email").ToString()) Then
                    lblemailship.Visible = False
                    semail.Visible = False
                Else
                    semail.Visible = True
                    lblemailship.Visible = True
                    lblemailship.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("OrderAddr_Email").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("OrderAddr_Telephone").ToString()) Then
                    lbltelephoneship.Visible = False
                    sphone.Visible = False
                Else
                    sphone.Visible = True
                    lbltelephoneship.Visible = True
                    lbltelephoneship.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("OrderAddr_Telephone").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("OrderAddr_Address").ToString()) Then
                    lbladdressShip.Visible = False
                Else
                    lbladdressShip.Visible = True
                    lbladdressShip.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("OrderAddr_Address").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("OrderAddr_Pincode").ToString()) Then
                    lblpincodeship.Visible = False
                Else
                    lblpincodeship.Visible = True
                    lblpincodeship.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("OrderAddr_Pincode").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("OrderAddr_City").ToString()) Then
                    lblCityship.Visible = False
                Else
                    lblCityship.Visible = True
                    lblCityship.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("OrderAddr_City").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("CountryName").ToString()) Then
                    lblcountryship.Visible = False
                Else
                    lblcountryship.Visible = True
                    lblcountryship.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("CountryName").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("StateName").ToString()) Then
                    lblsatateship.Visible = False
                Else
                    lblsatateship.Visible = True
                    lblsatateship.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("StateName").ToString())
                End If
                'Dim country As Array = countrydt.Select("ID = '" + drLogin("AccAddr_Country").ToString() + "'")
                'If country.Length <> 0 Then
                '    lblcountryship.Text = country(0)(1).ToString + " "
                'End If
                'Dim state As Array = statedt.Select("ID = '" + drLogin("AccAddr_State").ToString() + "'")
                'If state.Length <> 0 Then
                '    lblsatateship.Text = state(0)(1).ToString
                'End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifySalesOrder", "FillShipAddrByOrderId", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillTaxdetails()
        Try
            MainID = ddrelatedtypeid.SelectedValue
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "TaxdetailViewByID")
            If dt.Tables.Count > 0 Then
                Dim dtCustomer As New DataTable
                dtCustomer = dt.Tables(0)
                If dtCustomer.Rows.Count > 0 Then
                    Dim drCustomerRow As DataRow
                    drCustomerRow = dtCustomer.Rows(0)
                    If String.IsNullOrEmpty(drCustomerRow("Cust_Pan").ToString()) Then
                        lblpan.Text = "-"
                    Else
                        lblpan.Text = DynamicparcelDataManipulation.FixNullFromDB(drCustomerRow("Cust_Pan").ToString())
                    End If
                    If String.IsNullOrEmpty(drCustomerRow("Cust_Tin").ToString()) Then
                        lblcst.Text = "-"
                    Else
                        lblcst.Text = DynamicparcelDataManipulation.FixNullFromDB(drCustomerRow("Cust_Tin").ToString())
                    End If
                    If String.IsNullOrEmpty(drCustomerRow("Cust_Gst").ToString()) Then
                        lblvat.Text = "-"
                    Else
                        lblvat.Text = DynamicparcelDataManipulation.FixNullFromDB(drCustomerRow("Cust_Gst").ToString())
                    End If
                    ' Set ODA Charges
                    ' If String.IsNullOrEmpty(drCustomerRow("Acc_ODAfreight").ToString()) Then
                    'LblODAAmount.Text = "0"
                    'Else
                    '   LblODAAmount.Text = DynamicparcelDataManipulation.FixNullFromDB(drCustomerRow("Acc_ODAfreight").ToString())
                    'End If
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifySalesOrder", "FillTaxdetails", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillAccountdetails()
        Try
            MainID = ddrelatedtypeid.SelectedValue
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "AccountViewByID")
            If dt.Tables.Count > 0 Then
                Dim dtCustomer As New DataTable
                dtCustomer = dt.Tables(0)
                If dtCustomer.Rows.Count > 0 Then
                    Dim drCustomerRow As DataRow
                    drCustomerRow = dtCustomer.Rows(0)
                    If String.IsNullOrEmpty(drCustomerRow("Acc_Name").ToString()) Then
                        lblaccname.Visible = False
                    Else
                        lblaccname.Text = DynamicparcelDataManipulation.FixNullFromDB(drCustomerRow("Acc_Name").ToString())
                    End If
                    If String.IsNullOrEmpty(drCustomerRow("Contact_ContactPerson").ToString()) Then
                        lblaccontact.Visible = False
                    Else
                        lblaccontact.Text = DynamicparcelDataManipulation.FixNullFromDB(drCustomerRow("Contact_ContactPerson").ToString())
                    End If
                    If String.IsNullOrEmpty(drCustomerRow("Contact_Landline").ToString()) Then
                        lbltelephone.Visible = False
                        atphone.Visible = False
                    Else
                        atphone.Visible = True
                        lbltelephone.Text = DynamicparcelDataManipulation.FixNullFromDB(drCustomerRow("Contact_Landline").ToString())
                    End If
                    If String.IsNullOrEmpty(drCustomerRow("Contact_Mobile").ToString()) Then
                        lblacphone.Visible = False
                        amphone.Visible = False
                    Else
                        amphone.Visible = True
                        lblacphone.Text = DynamicparcelDataManipulation.FixNullFromDB(drCustomerRow("Contact_Mobile").ToString())
                    End If

                    If String.IsNullOrEmpty(drCustomerRow("Contact_Email").ToString()) Then
                        lblaccemail.Visible = False
                        aemail.Visible = False
                    Else
                        aemail.Visible = True
                        lblaccemail.Text = DynamicparcelDataManipulation.FixNullFromDB(drCustomerRow("Contact_Email").ToString())
                    End If
                    Dim DiscountPer As Double = 0

                    If Not IsDBNull(drCustomerRow("CashDiscountPer")) Then
                        DiscountPer = Convert.ToDouble(drCustomerRow("CashDiscountPer"))
                    End If

                    ViewState("CashDiscountPer") = DiscountPer

                    DisplayODATagAndAmount()

                    DisplayTCSTagAndAmount()

                End If
            End If
        Catch ex As Exception


            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifySalesOrder", "FillAccountdetails", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub




    Protected Sub chkApplyCashDiscount_CheckedChanged(
    sender As Object,
    e As EventArgs) Handles chkApplyCashDiscount.CheckedChanged

        ShowHideItemTotalKgsGSTVATfreight()

    End Sub



    Public Sub ShowHideItemTotalKgsGSTVATfreight()
        VatAmount = 0
        If grditemproduct.Rows.Count > 0 Then
            Dim lttotalamount As Label = DirectCast(grditemproduct.FooterRow.FindControl("lttotalamount"), Label)

            Dim lttotalvat As Label = DirectCast(grditemproduct.FooterRow.FindControl("lttotalvat"), Label)
            Dim lttotalkg As Label = DirectCast(grditemproduct.FooterRow.FindControl("lttotalkg"), Label)
            Dim lblfreight As Label = DirectCast(grditemproduct.FooterRow.FindControl("lblfreight"), Label)
            Dim LblTcsAmount As Label = DirectCast(grditemproduct.FooterRow.FindControl("LblTcsAmount"), Label)
            Dim TcsAmtPercentage As Double = ConfigurationManager.AppSettings("TcsAmtPercentage")
            'Dim lblDiscountPer As Label = DirectCast(grditemproduct.FooterRow.FindControl("lblDiscountPer"), Label)
            Dim totalkg As Double = 0
            Dim SubTotalAmount As Double = 0

            For i As Integer = 0 To grditemproduct.Rows.Count - 1
                Dim ltamount As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltamount"), Label)
                Dim lblvatinrs As Label = DirectCast(grditemproduct.Rows(i).FindControl("lblvatinrs"), Label)
                Dim lblvat As Label = DirectCast(grditemproduct.Rows(i).FindControl("lblvat"), Label)
                Dim hfPacking_Weight As HiddenField = DirectCast(grditemproduct.Rows(i).FindControl("hfPacking_Weight"), HiddenField)
                Dim ltquantity As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltquantity"), Label)
                Dim ltkg As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltkg"), Label)
                Dim hfltamount As HiddenField = TryCast(grditemproduct.Rows(i).FindControl("hfltamount"), HiddenField)
                Dim hflblvatinrs As HiddenField = TryCast(grditemproduct.Rows(i).FindControl("hflblvatinrs"), HiddenField)

                ltkg.Text = CDbl(hfPacking_Weight.Value) * CDbl(ltquantity.Text)
                VatAmount = VatAmount + lblvatinrs.Text
                Dim vat As Double = (lblvat.Text / ltamount.Text) * 100
                'lblvat.Text = (vat).ToString("N2")
                lblvat.Text = Math.Round(CDbl(vat), 1, MidpointRounding.AwayFromZero).ToString("N2")

                ltamount.Text = Math.Round(CDbl(ltamount.Text)).ToString("N2")
                hfltamount.Value = ltamount.Text.Replace(",", "")
                ' ''lblvatinrs.Text = Math.Round(CDbl(lblvatinrs.Text)).ToString("N2")***********MUBYN
                lblvatinrs.Text = (CDbl(lblvatinrs.Text)).ToString("N2")
                hflblvatinrs.Value = lblvatinrs.Text.Replace(",", "")
                totalkg = totalkg + Convert.ToDouble(ltkg.Text)
                SubTotalAmount += Math.Round(CDbl(ltamount.Text))

            Next

            'If String.IsNullOrEmpty(txtfreight.Text) Then
            '    lblfreight.Text = 0.ToString("N2")
            'Else
            '    fixfreight()
            '    lblfreight.Text = Math.Round(Convert.ToDouble(txtfreight.Text)).ToString("N2")
            'End If

            Dim divfootvat As HtmlGenericControl = TryCast(grditemproduct.FooterRow.FindControl("divfootvat"), HtmlGenericControl)
            Dim divfootvatamt As HtmlGenericControl = TryCast(grditemproduct.FooterRow.FindControl("divfootvatamt"), HtmlGenericControl)

            Dim FreightPrcnt As Double = ConfigurationManager.AppSettings("freightvalue")
            Dim freightgst As Double = 0.0 'Math.Round(Convert.ToDouble(lblfreight.Text) * CDbl(FreightTax) / 100).ToString("N2")
            Dim FreightValue As Double = 0.0

            lttotalamount.Text = SubTotalAmount.ToString("N2")

            If ddQuotationType.SelectedValue = "Export" Then
                VatAmount = 0
                'lttotalvat.Text = "0"
                divfootvat.Visible = False
                divfootvatamt.Visible = False
                'freightamt = 0.0 'Math.Round(Convert.ToDouble(lblfreight.Text) * CDbl(FreightTax) / 100).ToString("N2")


                FreightValue = (CDbl(txtfreight.Text) + CDbl(txtdocnclr.Text) + CDbl(txtocfrei.Text) + CDbl(txtinsurance.Text)).ToString("N2")

                FooterTotalAmount = SubTotalAmount + VatAmount + FreightValue

            Else
                divfootvat.Visible = True
                divfootvatamt.Visible = True
                ' ''freightamt = Math.Round(Convert.ToDouble(lblfreight.Text) * CDbl(FreightTax) / 100).ToString("N2")'***MUBYN
                freightgst = (Convert.ToDouble(txtfreight.Text) * CDbl(FreightPrcnt) / 100).ToString("N2")


                '=======================
                ' DISCOUNT CALCULATION
                '=======================
                'Dim DiscountPer As Double = 0
                'Dim DiscountAmount As Double = 0

                'Dim lblDiscountPer As Label = TryCast(grditemproduct.FooterRow.FindControl("lblDiscountPer"), Label)
                'Dim LbldiscountAmt As Label = TryCast(grditemproduct.FooterRow.FindControl("LbldiscountAmt"), Label)
                'Dim divdiscount As HtmlGenericControl = TryCast(grditemproduct.FooterRow.FindControl("divdiscount"), HtmlGenericControl)
                'Dim discountamt As HtmlGenericControl = TryCast(grditemproduct.FooterRow.FindControl("discountamt"), HtmlGenericControl)

                'If ViewState("CashDiscountPer") IsNot Nothing Then
                '    DiscountPer = Convert.ToDouble(ViewState("CashDiscountPer"))
                'End If

                'Dim ProductTotal As Double = SubTotalAmount

                'If DiscountPer > 0 Then
                '    DiscountAmount = Math.Round((ProductTotal * DiscountPer) / 100, 2)

                '    If LbldiscountAmt IsNot Nothing Then
                '        LbldiscountAmt.Text = DiscountAmount.ToString("N2")
                '    End If

                '    If discountamt IsNot Nothing Then
                '        discountamt.InnerText = "-" & DiscountAmount.ToString("N2")
                '    End If

                '    If divdiscount IsNot Nothing Then divdiscount.Visible = True
                '    If discountamt IsNot Nothing Then discountamt.Visible = True
                'Else
                '    DiscountAmount = 0

                '    If LbldiscountAmt IsNot Nothing Then
                '        LbldiscountAmt.Text = "0.00"
                '    End If

                '    If divdiscount IsNot Nothing Then divdiscount.Visible = False
                '    If discountamt IsNot Nothing Then discountamt.Visible = False
                'End If

                'If lblDiscountPer IsNot Nothing Then
                '    lblDiscountPer.Text = DiscountPer.ToString("0.##")
                '    ProductTotal = SubTotalAmount
                'End If

                '=======DISCOUNTChanges for checkbox logic 

                Dim DiscountPer As Double = 0
                Dim DiscountAmount As Double = 0

                Dim lblDiscountPer As Label = TryCast(grditemproduct.FooterRow.FindControl("lblDiscountPer"), Label)
                Dim LbldiscountAmt As Label = TryCast(grditemproduct.FooterRow.FindControl("LbldiscountAmt"), Label)
                Dim divdiscount As HtmlGenericControl = TryCast(grditemproduct.FooterRow.FindControl("divdiscount"), HtmlGenericControl)
                Dim discountamt As HtmlGenericControl = TryCast(grditemproduct.FooterRow.FindControl("discountamt"), HtmlGenericControl)

                If ViewState("CashDiscountPer") IsNot Nothing Then
                    DiscountPer = Convert.ToDouble(ViewState("CashDiscountPer"))
                End If

                Dim ApplyCashDiscount As Boolean = False

                If chkApplyCashDiscount IsNot Nothing Then
                    ApplyCashDiscount = chkApplyCashDiscount.Checked
                End If

                Dim ProductTotal As Double = SubTotalAmount

                If ApplyCashDiscount AndAlso DiscountPer > 0 Then

                    DiscountAmount = Math.Round((ProductTotal * DiscountPer) / 100, 2)

                    ViewState("DiscountAmount") = DiscountAmount

                    If LbldiscountAmt IsNot Nothing Then
                        LbldiscountAmt.Text = "-" & DiscountAmount.ToString("N2")
                    End If

                    If discountamt IsNot Nothing Then
                        discountamt.Visible = True
                    End If

                    If divdiscount IsNot Nothing Then
                        divdiscount.Visible = True
                    End If

                Else

                    DiscountAmount = 0
                    ViewState("DiscountAmount") = 0

                    If LbldiscountAmt IsNot Nothing Then
                        LbldiscountAmt.Text = "0.00"
                    End If

                    If divdiscount IsNot Nothing Then
                        divdiscount.Visible = False
                    End If

                    If discountamt IsNot Nothing Then
                        discountamt.Visible = False
                    End If

                End If

                If lblDiscountPer IsNot Nothing Then
                    lblDiscountPer.Text = DiscountPer.ToString("0.##")
                End If

                '=========END Discount Check box


                VatAmount = VatAmount + freightgst


                FreightValue = Convert.ToDouble(txtfreight.Text).ToString("N2")

                ' --- Show Hide TCS Amount
                'If String.IsNullOrEmpty(drOrder("Tcs_Amount").ToString()) Then
                '    TcsAmount = DynamicparcelDataManipulation.FixNullFromDB(drOrder("Tcs_Amount").ToString())
                'End If

                DisplayTCSTagAndAmount()

                DisplayODATagAndAmount()

                Dim LblTcsAmt As Label = DirectCast(grditemproduct.FooterRow.FindControl("LblTcsAmount"), Label)

                Dim LblODAAmt As Label = TryCast(grditemproduct.FooterRow.FindControl("LblODAAmnt"), Label)

                TcsAmount = Convert.ToDecimal(LblTcsAmt.Text)
                ODACharges = Convert.ToDecimal(LblODAAmt.Text)

                FooterTotalAmount = SubTotalAmount + VatAmount + TcsAmount + ODACharges + FreightValue

                lblfreight.Text = FreightValue.ToString("N2")

            End If




            hfgrandtotal.Value = FooterTotalAmount '- Convert.ToDouble(lblfreight.Text)

            hftotalvat.Value = VatAmount
            lttotalvat.Text = Math.Round(VatAmount, 0) '.ToString("N2")
            ' ''lttotalamount.Text = Math.Round(FooterTotalAmount).ToString("N2")'****MUBYN
            lttotalamount.Text = Math.Round(FooterTotalAmount, 0, MidpointRounding.AwayFromZero).ToString("N2")
            ' ''lttotalvat.Text = Math.Round(VatAmount).ToString("N2")**********MUBYN
            lttotalvat.Text = Math.Round(VatAmount, 0).ToString("N2")
            lttotalkg.Text = totalkg.ToString + " Kg"

        End If


    End Sub

    'Public Sub ShowHideItemTotalKgsGSTVATfreight()
    '    VatAmount = 0

    '    If grditemproduct.Rows.Count > 0 Then

    '        Dim lttotalamount As Label = DirectCast(grditemproduct.FooterRow.FindControl("lttotalamount"), Label)
    '        Dim lttotalvat As Label = DirectCast(grditemproduct.FooterRow.FindControl("lttotalvat"), Label)
    '        Dim lttotalkg As Label = DirectCast(grditemproduct.FooterRow.FindControl("lttotalkg"), Label)
    '        Dim lblfreight As Label = DirectCast(grditemproduct.FooterRow.FindControl("lblfreight"), Label)

    '        Dim totalkg As Double = 0
    '        Dim SubTotalAmount As Double = 0

    '        '=======================
    '        ' GET DISCOUNT %
    '        '=======================
    '        Dim DiscountPer As Double = 0
    '        If ViewState("CashDiscountPer") IsNot Nothing Then
    '            DiscountPer = Convert.ToDouble(ViewState("CashDiscountPer"))
    '        End If

    '        '=======================
    '        ' LOOP (ROW LEVEL)
    '        '=======================
    '        For i As Integer = 0 To grditemproduct.Rows.Count - 1

    '            Dim ltamount As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltamount"), Label)
    '            Dim lblvatinrs As Label = DirectCast(grditemproduct.Rows(i).FindControl("lblvatinrs"), Label)
    '            Dim lblvat As Label = DirectCast(grditemproduct.Rows(i).FindControl("lblvat"), Label)
    '            Dim hfPacking_Weight As HiddenField = DirectCast(grditemproduct.Rows(i).FindControl("hfPacking_Weight"), HiddenField)
    '            Dim ltquantity As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltquantity"), Label)
    '            Dim ltkg As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltkg"), Label)
    '            Dim hfltamount As HiddenField = TryCast(grditemproduct.Rows(i).FindControl("hfltamount"), HiddenField)
    '            Dim hflblvatinrs As HiddenField = TryCast(grditemproduct.Rows(i).FindControl("hflblvatinrs"), HiddenField)

    '            ' KG calc
    '            ltkg.Text = CDbl(hfPacking_Weight.Value) * CDbl(ltquantity.Text)

    '            ' VAT calc
    '            VatAmount += CDbl(lblvatinrs.Text)

    '            '=======================
    '            ' APPLY DISCOUNT ON ROW
    '            '=======================
    '            Dim originalAmount As Double = CDbl(ltamount.Text)
    '            Dim finalAmount As Double = originalAmount

    '            If DiscountPer > 0 Then
    '                finalAmount = Math.Round(originalAmount - (originalAmount * DiscountPer / 100), 2)
    '            End If

    '            ' UPDATE UI (IMPORTANT)
    '            ltamount.Text = finalAmount.ToString("N2")

    '            If hfltamount IsNot Nothing Then
    '                hfltamount.Value = finalAmount.ToString().Replace(",", "")
    '            End If

    '            ' VAT formatting
    '            lblvatinrs.Text = CDbl(lblvatinrs.Text).ToString("N2")
    '            If hflblvatinrs IsNot Nothing Then
    '                hflblvatinrs.Value = lblvatinrs.Text.Replace(",", "")
    '            End If

    '            ' TOTALS
    '            totalkg += CDbl(ltkg.Text)
    '            SubTotalAmount += finalAmount

    '        Next

    '        '=======================
    '        ' FOOTER DISCOUNT DISPLAY
    '        '=======================
    '        Dim LbldiscountAmt As Label = TryCast(grditemproduct.FooterRow.FindControl("LbldiscountAmt"), Label)
    '        Dim lblDiscountPer As Label = TryCast(grditemproduct.FooterRow.FindControl("lblDiscountPer"), Label)
    '        Dim divdiscount As HtmlGenericControl = TryCast(grditemproduct.FooterRow.FindControl("divdiscount"), HtmlGenericControl)
    '        Dim discountamt As HtmlGenericControl = TryCast(grditemproduct.FooterRow.FindControl("discountamt"), HtmlGenericControl)

    '        Dim DiscountAmount As Double = 0

    '        If DiscountPer > 0 Then
    '            DiscountAmount = Math.Round((SubTotalAmount * DiscountPer) / 100, 2)

    '            If LbldiscountAmt IsNot Nothing Then
    '                LbldiscountAmt.Text = DiscountAmount.ToString("N2")
    '            End If

    '            If discountamt IsNot Nothing Then
    '                discountamt.InnerText = "-" & DiscountAmount.ToString("N2")
    '            End If

    '            If divdiscount IsNot Nothing Then divdiscount.Visible = True
    '            If discountamt IsNot Nothing Then discountamt.Visible = True
    '        Else
    '            If LbldiscountAmt IsNot Nothing Then
    '                LbldiscountAmt.Text = "0.00"
    '            End If

    '            If divdiscount IsNot Nothing Then divdiscount.Visible = False
    '            If discountamt IsNot Nothing Then discountamt.Visible = False
    '        End If

    '        If lblDiscountPer IsNot Nothing Then
    '            lblDiscountPer.Text = DiscountPer.ToString("0.##")
    '        End If

    '        '=======================
    '        ' OTHER CALCULATIONS
    '        '=======================
    '        Dim FreightPrcnt As Double = ConfigurationManager.AppSettings("freightvalue")
    '        Dim freightgst As Double = (Convert.ToDouble(txtfreight.Text) * CDbl(FreightPrcnt) / 100)

    '        VatAmount += freightgst

    '        Dim FreightValue As Double = Convert.ToDouble(txtfreight.Text)

    '        DisplayTCSTagAndAmount()
    '        DisplayODATagAndAmount()

    '        Dim LblTcsAmt As Label = DirectCast(grditemproduct.FooterRow.FindControl("LblTcsAmount"), Label)
    '        Dim LblODAAmt As Label = TryCast(grditemproduct.FooterRow.FindControl("LblODAAmnt"), Label)

    '        TcsAmount = Convert.ToDecimal(LblTcsAmt.Text)
    '        ODACharges = Convert.ToDecimal(LblODAAmt.Text)

    '        FooterTotalAmount = SubTotalAmount + VatAmount + TcsAmount + ODACharges + FreightValue

    '        '=======================
    '        ' FINAL UI UPDATE
    '        '=======================
    '        lttotalamount.Text = Math.Round(FooterTotalAmount, 0, MidpointRounding.AwayFromZero).ToString("N2")
    '        lttotalvat.Text = Math.Round(VatAmount, 0).ToString("N2")
    '        lttotalkg.Text = totalkg.ToString & " Kg"
    '        lblfreight.Text = FreightValue.ToString("N2")

    '        hfgrandtotal.Value = FooterTotalAmount
    '        hftotalvat.Value = VatAmount

    '    End If

    'End Sub


    Public Function FetchCustomerRecords() As DataRow

        Dim MainID As Integer = ddrelatedtypeid.SelectedValue
        Dim dt As DataSet = MainBLL.ViewByID(MainID, "AccountViewByID")
        Dim dtCustomer As New DataTable
        Dim drCustRow As DataRow

        If dt.Tables.Count > 0 Then
            dtCustomer = dt.Tables(0)
            If dtCustomer.Rows.Count > 0 Then
                drCustRow = dtCustomer.Rows(0)
            End If
        End If

        Return drCustRow

    End Function


    Public Sub DisplayODATagAndAmount()

        Dim drCustRow As DataRow

        If grditemproduct.Rows.Count > 0 Then

            drCustRow = FetchCustomerRecords()


            Dim LblODAAmount As Label = TryCast(grditemproduct.FooterRow.FindControl("LblODAAmnt"), Label)
            Dim LblODATitle As Label = TryCast(grditemproduct.FooterRow.FindControl("LblODATitle"), Label)
            Dim hrODA As Label = TryCast(grditemproduct.FooterRow.FindControl("hrODA"), Label)
            Dim hrODAValue As Label = TryCast(grditemproduct.FooterRow.FindControl("hrODAValue"), Label)
            Dim rsODA As Label = TryCast(grditemproduct.FooterRow.FindControl("rsODA"), Label)


            lblODALimit.Text = DynamicparcelDataManipulation.FixNullFromDB(drCustRow("Acc_ODAamount").ToString())
            lblODAFreight.Text = DynamicparcelDataManipulation.FixNullFromDB(drCustRow("Acc_ODAfreight").ToString())

            divODALimit.Visible = False
            divODACharge.Visible = False

            Dim TotalItemAmount As Double = 0

            If grditemproduct.Rows.Count > 0 Then
                Dim lttotalamount As Label = DirectCast(grditemproduct.FooterRow.FindControl("lttotalamount"), Label)
                TotalItemAmount = Convert.ToDecimal(lttotalamount.Text)
            End If


            If Not String.IsNullOrEmpty(lblODALimit.Text) AndAlso Not String.IsNullOrEmpty(lblODAFreight.Text) Then
                Dim odaLimit As Decimal = Convert.ToDecimal(lblODALimit.Text)
                Dim odaFreight As Decimal = Convert.ToDecimal(lblODAFreight.Text)

                If TotalItemAmount >= odaLimit Then
                    lblODAApplicable.Visible = True

                    LblODAAmount.Visible = True
                    hrODAValue.Visible = True
                    LblODATitle.Visible = True
                    LblODAAmount.Text = odaFreight.ToString("N2")
                    LblODATitle.Text = "ODA Charges:"
                    hrODA.Visible = True
                    rsODA.Visible = True
                    'ODACharges = Convert.ToDecimal(lblODACharges.Text)

                Else
                    lblODAApplicable.Visible = False

                    LblODAAmount.Visible = False
                    hrODAValue.Visible = False
                    LblODATitle.Visible = False
                    hrODA.Visible = False
                    rsODA.Visible = False


                End If
            Else
                lblODAApplicable.Visible = False
            End If

        End If


    End Sub



    Public Sub DisplayTCSTagAndAmount()

        Dim TCSapplicableBln As Boolean = 0
        Dim drCustRow As DataRow
        drCustRow = FetchCustomerRecords()



        Try

            If Not (String.IsNullOrEmpty(drCustRow("Acc_TcsApplicable").ToString())) Then
                TCSapplicableBln = Convert.ToBoolean(drCustRow("Acc_TcsApplicable"))
            End If
            If (TCSapplicableBln) Then
                lblTCSApplicable.Visible = True
            End If


            If grditemproduct.Rows.Count > 0 Then

                Dim LblTcsAmount As Label = DirectCast(grditemproduct.FooterRow.FindControl("LblTcsAmount"), Label)
                Dim hrTCS As Label = TryCast(grditemproduct.FooterRow.FindControl("hrtcs"), Label)
                Dim LblTCSTitle As Label = TryCast(grditemproduct.FooterRow.FindControl("LblTCSTitle"), Label)
                Dim hrTCSValue As Label = TryCast(grditemproduct.FooterRow.FindControl("hrTCSValue"), Label)
                Dim rsTCS As Label = TryCast(grditemproduct.FooterRow.FindControl("rstcs"), Label)


                Dim TotalItemAmount As Double = 0

                If grditemproduct.Rows.Count > 0 Then
                    Dim lttotalamount As Label = DirectCast(grditemproduct.FooterRow.FindControl("lttotalamount"), Label)
                    TotalItemAmount = Convert.ToDecimal(lttotalamount.Text)
                End If

                Dim TcsAmtPercent As Double = ConfigurationManager.AppSettings("TcsAmtPercentage")
                TcsAmount = (Convert.ToDouble(TcsAmtPercent * TotalItemAmount) / 100).ToString("N2")

                If TcsAmount <= 0 Then  'String.IsNullOrEmpty(drOrder("Tcs_Amount").ToString()) Then
                    LblTcsAmount.Visible = False  '.Text = "0"
                    LblTcsAmount.Text = 0
                    hrTCS.Visible = False
                    rsTCS.Visible = False
                    hrTCSValue.Visible = False
                    LblTCSTitle.Visible = False
                Else
                    'TcsAmount = DynamicparcelDataManipulation.FixNullFromDB(drOrder("Tcs_Amount").ToString())
                    LblTcsAmount.Text = TcsAmount.ToString("N2")
                    LblTcsAmount.Visible = True
                    hrTCS.Visible = True
                    rsTCS.Visible = True
                    LblTCSTitle.Visible = True
                    hrTCSValue.Visible = True
                    LblTCSTitle.Text = "TCS Amount:"
                End If

            End If


        Catch ex As Exception
            'lblTCSApplicable.Text = drCustomerRow("Acc_TcsApplicable").ToString()
            'lblTCSApplicable.Visible = True
        End Try

    End Sub



    Protected Sub ddrelatedtypeid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddrelatedtypeid.SelectedIndexChanged
        FillBillingAddressDetail()
        ' ''FillShippingAddressDetail()
        FillShipAddrByOrderId()
        FillTaxdetails()
        FillAccountdetails()
    End Sub
    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            addproduct("Save")
            'MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            'For Each row As GridViewRow In GridView1.Rows
            '    Dim txtOrderQty = DirectCast(row.FindControl("txtOrderQty"), TextBox)
            '    Dim lblproductId = DirectCast(row.FindControl("lblproductId"), Label)
            '    Dim lblname = DirectCast(row.FindControl("lblname"), Label)
            '    Dim lblcode = DirectCast(row.FindControl("lblcode"), Label)
            '    Dim lblunit = DirectCast(row.FindControl("lblunit"), Label)
            '    Dim ltproductWeight = DirectCast(row.FindControl("ltproductWeight"), Label)
            '    Dim Label1 = DirectCast(row.FindControl("Label1"), Label)
            '    Dim lblamount = DirectCast(row.FindControl("lbltotalamount1"), Label)
            '    Dim lblvat = DirectCast(row.FindControl("lblvat"), Label)
            '    Dim lblkgs = DirectCast(row.FindControl("lblkgs"), Label)
            '    Dim lblrate = DirectCast(row.FindControl("lblrate"), Label)
            '    Dim ckselect = DirectCast(row.FindControl("ckselect"), CheckBox)
            '    ' If ckselect.Checked = True Then
            '    If (txtOrderQty.Text <> "" And txtOrderQty.Text <> "0") Or ckselect.Checked = True Then   '   If txtOrderQty.Text = "0" Then

            '        If String.IsNullOrEmpty(txtOrderQty.Text) Or txtOrderQty.Text = "0" Then
            '            txtOrderQty.Text = 1
            '        End If
            '        lblkgs.Text = ltproductWeight.Text * txtOrderQty.Text
            '        lblamount.Text = lblkgs.Text * lblrate.Text
            '        Dim VAT As Double = Convert.ToDouble((lblvat.Text * lblamount.Text) / 100)
            '        OrderBLL.Main_Order_Details(MainID, lblproductId.Text, txtOrderQty.Text, lblrate.Text, lblamount.Text, VAT)
            '    End If
            'Next
            'FillMainProduct()
            'OrderBLL.UpdateOrderAmount(hfgrandtotal.Value, hftotalvat.Value, MainID)
            ''mpe.Hide()
            'If hfbtnsave.Value = "All" Then
            '    FillProductGrid()
            'Else
            '    FillRecProductGrid()
            'End If

            ' Call the email method
            ' SendOrderEditEmail(MainID, orderCode)


        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
        End Try
    End Sub
    Public Sub addproduct(ByVal flag As String)
        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))

        For Each row As GridViewRow In GridView1.Rows
            Dim txtOrderQty = DirectCast(row.FindControl("txtOrderQty"), TextBox)
            Dim lblproductId = DirectCast(row.FindControl("lblproductId"), Label)
            Dim lblname = DirectCast(row.FindControl("lblname"), Label)
            Dim lblcode = DirectCast(row.FindControl("lblcode"), Label)
            Dim lblunit = DirectCast(row.FindControl("lblunit"), Label)
            Dim ltproductWeight = DirectCast(row.FindControl("ltproductWeight"), Label)
            Dim Label1 = DirectCast(row.FindControl("Label1"), Label)
            Dim lblamount = DirectCast(row.FindControl("lbltotalamount1"), Label)
            Dim lblvat = DirectCast(row.FindControl("lblvat"), Label)
            Dim lblkgs = DirectCast(row.FindControl("lblkgs"), Label)
            Dim lblrate = DirectCast(row.FindControl("lblrate"), Label)
            Dim hfrate = DirectCast(row.FindControl("hfrate"), HiddenField)
            hfrate.Value = lblrate.Text
            Dim ckselect = DirectCast(row.FindControl("ckselect"), CheckBox)
            Dim hfdiscountrate = DirectCast(row.FindControl("hfdiscountrate"), HiddenField)
            Dim lbldiscount = DirectCast(row.FindControl("lbldiscount"), Label)
            Dim lblLinkAs = DirectCast(row.FindControl("lblLinkAs"), Label)
            ' If ckselect.Checked = True Then
            If (txtOrderQty.Text <> "" And txtOrderQty.Text <> "0") Or ckselect.Checked = True Then   '   If txtOrderQty.Text = "0" Then

                '    If txtOrderQty.Text = "0" Then
                'Else
                If String.IsNullOrEmpty(txtOrderQty.Text) Or txtOrderQty.Text = "0" Then
                    txtOrderQty.Text = 1
                End If
                If lbldiscount.Text = "" Then

                Else
                    countrate = lbldiscount.Text / 100
                    countrate1 = lblrate.Text * countrate
                    lblrate.Text = lblrate.Text - countrate1
                End If
                lblrate.Text = Math.Round(CDbl(lblrate.Text)).ToString
                lblkgs.Text = ltproductWeight.Text * txtOrderQty.Text
                'DISCOUNT LOGIC

                'lblamount.Text = (lblkgs.Text * lblrate.Text).ToString("N2")
                ' lblamount.Text = (lblkgs.Text * lblrate.Text).ToString("N2")
                Dim amount As Double = CDbl(lblkgs.Text) * CDbl(lblrate.Text)

                Dim DiscountPer As Double = 0

                If ViewState("CashDiscountPer") IsNot Nothing Then
                    DiscountPer = Convert.ToDouble(ViewState("CashDiscountPer"))
                End If

                ' If DiscountPer > 0 Then
                If chkApplyCashDiscount.Checked AndAlso DiscountPer > 0 Then
                    Dim DiscountAmt As Double = (amount * DiscountPer) / 100
                    amount = amount - DiscountAmt
                End If

                lblamount.Text = amount.ToString("N2")
                'END LOGIC

                Dim VAT As Double = Convert.ToDouble((lblvat.Text * lblamount.Text) / 100)
                'lblamount.Text = (lblamount.Text + VAT).ToString("N2")

                If ddQuotationType.SelectedValue = "Domestic" Then
                    If lblLinkAs.Text = "Sample" Then
                        OrderBLL.Main_Order_Details(MainID, lblproductId.Text, txtOrderQty.Text, lblamount.Text, lblamount.Text, VAT)
                    Else
                        OrderBLL.Main_Order_Details(MainID, lblproductId.Text, txtOrderQty.Text, lblrate.Text, lblamount.Text, VAT)
                    End If
                Else
                    OrderBLL.Main_Order_Details(MainID, lblproductId.Text, txtOrderQty.Text, lblrate.Text, lblamount.Text, 0)
                End If
                'dt.Rows.Add(count, lblproductId.Text, lblname.Text, lblcode.Text, lblunit.Text, ltproductWeight.Text, hfrate.Value, lblrate.Text, txtOrderQty.Text,
                '            lblvat.Text)
                'count = count + 1
            End If
            ' End If
        Next

        'End If
        FillMainProduct()
        OrderBLL.UpdateOrderAmount(hfgrandtotal.Value, hftotalvat.Value, MainID)
        If flag = "Save" Then
            If hfbtnsave.Value = "All" Then
                FillProductGrid()
            Else
                FillRecProductGrid()
            End If
        Else

            mpe.Hide()
        End If

    End Sub
    Protected Sub btnsaveclose_Click(sender As Object, e As EventArgs) Handles btnsaveclose.Click
        Try
            addproduct("SaveClose")
            'MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))

            'For Each row As GridViewRow In GridView1.Rows
            '    Dim txtOrderQty = DirectCast(row.FindControl("txtOrderQty"), TextBox)
            '    Dim lblproductId = DirectCast(row.FindControl("lblproductId"), Label)
            '    Dim lblname = DirectCast(row.FindControl("lblname"), Label)
            '    Dim lblcode = DirectCast(row.FindControl("lblcode"), Label)
            '    Dim lblunit = DirectCast(row.FindControl("lblunit"), Label)
            '    Dim ltproductWeight = DirectCast(row.FindControl("ltproductWeight"), Label)
            '    Dim Label1 = DirectCast(row.FindControl("Label1"), Label)
            '    Dim lblamount = DirectCast(row.FindControl("lbltotalamount1"), Label)
            '    Dim lblvat = DirectCast(row.FindControl("lblvat"), Label)
            '    Dim lblkgs = DirectCast(row.FindControl("lblkgs"), Label)
            '    Dim lblrate = DirectCast(row.FindControl("lblrate"), Label)
            '    Dim hfrate = DirectCast(row.FindControl("hfrate"), HiddenField)
            '    hfrate.Value = lblrate.Text
            '    Dim ckselect = DirectCast(row.FindControl("ckselect"), CheckBox)
            '    Dim hfdiscountrate = DirectCast(row.FindControl("hfdiscountrate"), HiddenField)
            '    Dim lbldiscount = DirectCast(row.FindControl("lbldiscount"), Label)
            '    ' If ckselect.Checked = True Then
            '    If (txtOrderQty.Text <> "" And txtOrderQty.Text <> "0") Or ckselect.Checked = True Then   '   If txtOrderQty.Text = "0" Then

            '        '    If txtOrderQty.Text = "0" Then
            '        'Else
            '        If String.IsNullOrEmpty(txtOrderQty.Text) Or txtOrderQty.Text = "0" Then
            '            txtOrderQty.Text = 1
            '        End If
            '        If lbldiscount.Text = "" Then
            '        Else
            '            countrate = lbldiscount.Text / 100
            '            countrate1 = lblrate.Text * countrate
            '            lblrate.Text = lblrate.Text - countrate1
            '        End If
            '        lblkgs.Text = ltproductWeight.Text * txtOrderQty.Text
            '        lblamount.Text = (lblkgs.Text * lblrate.Text).ToString("N2")
            '        Dim VAT As Double = Convert.ToDouble((lblvat.Text * lblamount.Text) / 100)
            '        'lblamount.Text = (lblamount.Text + VAT).ToString("N2")
            '        OrderBLL.Main_Order_Details(MainID, lblproductId.Text, txtOrderQty.Text, lblrate.Text, lblamount.Text, VAT)
            '        'dt.Rows.Add(count, lblproductId.Text, lblname.Text, lblcode.Text, lblunit.Text, ltproductWeight.Text, hfrate.Value, lblrate.Text, txtOrderQty.Text,
            '        '            lblvat.Text)
            '        'count = count + 1
            '    End If
            '    ' End If
            'Next

            ''End If
            'FillMainProduct()
            'OrderBLL.UpdateOrderAmount(hfgrandtotal.Value, hftotalvat.Value, MainID)
            'mpe.Hide()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifySalesOrder", "btnsaveclose_Click", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    'Invoice
    Public Sub fillInvoice()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            GridView2.VirtualItemCount = MainBLL.TotalRowInGridviewBYID("InvoiceTotalNumberOfRecordByOrd", MainID)
            If (GridView2.VirtualItemCount = 0) Then
                lblinvoice.Text = "No Invoice"
            Else
                lblinvoice.Text = "Invoice (" + GridView2.VirtualItemCount.ToString + ")"
            End If
            GridView2.DataSource = MainBLL.FillGridViewById("0", 10, MainID, "InvoiceGridviewByOrder")
            GridView2.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ' ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            ExecptionBLL.Insert("ModifySalesOrder", "fillInvoice", error1, Session("UserId"))
            Throw ex
        End Try
    End Sub

    Protected Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            GridView2.PageIndex = e.NewPageIndex
            GridView2.DataSource = MainBLL.FillGridViewById(e.NewPageIndex, 10, MainID, "InvoiceGridviewByOrder")
            GridView2.DataBind()
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifySalesOrder", "GridView2_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    'Invoice    


    Protected Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))


        Dim host As String = HttpContext.Current.Request.Url.Host
        Dim url As String
        hforderhref.Value = hforderhref.Value.Replace("PrintSalesOrdergst.aspx?Id=", "Admin/PrintDocs.aspx?tpy=SODom&type=")

        If host = "localhost" Then
            If ddQuotationType.SelectedValue = "Domestic" Then
                If hforderhref.Value = "PrintSalesOrder.aspx?Id=" Then
                    url = "http://localhost:56361/" + hforderhref.Value + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString()))
                Else
                    url = "http://localhost:56361/" + hforderhref.Value + "pJyQIVSSnfWdSCc47JLzHg%3d%3d" + "&Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())) + "&Gyt32XyHTtsuc=" + HttpUtility.UrlEncode(Security.Encrypt(ddrelatedtypeid.SelectedValue.ToString()))
                End If
            Else
                url = "http://localhost:56361/" + hforderhref.Value + HttpUtility.UrlEncode(Security.Encrypt(("USD").ToString())) + "&Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())) + "&Gyt32XyHTtsuc=" + HttpUtility.UrlEncode(Security.Encrypt((ddrelatedtypeid.SelectedValue).ToString()))
            End If

        Else
            If ddQuotationType.SelectedValue = "Domestic" Then
                If hforderhref.Value = "PrintSalesOrder.aspx?Id=" Then
                    url = "http://localhost:56361/" + hforderhref.Value + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString()))
                Else
                    url = "http://uatadmin.swissbake.in/" + hforderhref.Value + "pJyQIVSSnfWdSCc47JLzHg%3d%3d" + "&Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())) + "&Gyt32XyHTtsuc=" + HttpUtility.UrlEncode(Security.Encrypt(ddrelatedtypeid.SelectedValue.ToString()))
                End If
            Else
                url = "http://uatadmin.swissbake.in/" + hforderhref.Value + HttpUtility.UrlEncode(Security.Encrypt(("USD").ToString())) + "&Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())) + "&Gyt32XyHTtsuc=" + HttpUtility.UrlEncode(Security.Encrypt((ddrelatedtypeid.SelectedValue).ToString()))
            End If
        End If
        'If host = "localhost" Then
        '    If ddQuotationType.SelectedValue = "Domestic" Then
        '        url = "http://localhost:56361/" + hforderhref.Value + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString()))
        '    Else
        '        url = "http://localhost:56361/" + hforderhref.Value + HttpUtility.UrlEncode(Security.Encrypt(("USD").ToString())) + "&Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())) + "&Gyt32XyHTtsuc=" + HttpUtility.UrlEncode(Security.Encrypt((ddrelatedtypeid.SelectedValue).ToString()))
        '    End If

        'Else
        '    If ddQuotationType.SelectedValue = "Domestic" Then
        '        url = "http://b2b.swissbake.ch/" + hforderhref.Value + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString()))
        '    Else
        '        url = "http://b2b.swissbake.ch/" + hforderhref.Value + HttpUtility.UrlEncode(Security.Encrypt(("USD").ToString())) + "&Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())) + "&Gyt32XyHTtsuc=" + HttpUtility.UrlEncode(Security.Encrypt((ddrelatedtypeid.SelectedValue).ToString()))
        '    End If


        'End If



        ' End If

        Response.Redirect(url)
    End Sub
    Public Sub fixfreight()
        If txtfreight.Text = "" Then
            txtfreight.Text = "0"
        End If

        If txtdocnclr.Text = "" Then
            txtdocnclr.Text = "0"
        End If

        If txtocfrei.Text = "" Then
            txtocfrei.Text = "0"
        End If

        If txtinsurance.Text = "" Then
            txtinsurance.Text = "0"
        End If
    End Sub
    Private Sub dddelivery_TextChanged(sender As Object, e As EventArgs) Handles dddelivery.TextChanged
        Try
            If dddelivery.SelectedValue = "EXW" Then
                txtfreight.Enabled = False
                divdocnclr.Visible = False
                divocnfre.Visible = False
                divins.Visible = False
                txtfreight.Text = "0"
                txtdocnclr.Text = "0"
                txtocfrei.Text = "0"
                txtinsurance.Text = "0"
            ElseIf dddelivery.SelectedValue = "FOB" Then
                txtfreight.Enabled = True
                divdocnclr.Visible = True
                divocnfre.Visible = False
                divins.Visible = False
                txtocfrei.Text = "0"
                txtinsurance.Text = "0"
            ElseIf dddelivery.SelectedValue = "CNF" Then
                txtfreight.Enabled = True
                divdocnclr.Visible = True
                divocnfre.Visible = True
                divins.Visible = False
                txtinsurance.Text = "0"
            ElseIf dddelivery.SelectedValue = "CIF" Then
                txtfreight.Enabled = True
                divdocnclr.Visible = True
                divocnfre.Visible = True
                divins.Visible = True
            End If
            checkfreight()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub checkfreight()
        If grditemproduct.Rows.Count > 0 Then

            If txtfreight.Text = "" Then
                txtfreight.Text = "0"
            End If

            If txtdocnclr.Text = "" Then
                txtdocnclr.Text = "0"
            End If

            If txtocfrei.Text = "" Then
                txtocfrei.Text = "0"
            End If

            If txtinsurance.Text = "" Then
                txtinsurance.Text = "0"
            End If



            Dim lttotalamount As Label = DirectCast(grditemproduct.FooterRow.FindControl("lttotalamount"), Label)


            Dim lttotalvat As Label = DirectCast(grditemproduct.FooterRow.FindControl("lttotalvat"), Label)
            Dim lblfreight As Label = DirectCast(grditemproduct.FooterRow.FindControl("lblfreight"), Label)
            lblfreight.Text = (CDbl(txtfreight.Text) + CDbl(txtdocnclr.Text) + CDbl(txtocfrei.Text) + CDbl(txtinsurance.Text)).ToString("N2")
            For i As Integer = 0 To grditemproduct.Rows.Count - 1
                Dim ltamount As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltamount"), Label)
                Dim lblvatinrs As Label = DirectCast(grditemproduct.Rows(i).FindControl("lblvatinrs"), Label)
                ' ''VatAmount = VatAmount + Math.Round(Convert.ToDouble(lblvatinrs.Text))*************MUBYN
                VatAmount = VatAmount + (Convert.ToDouble(lblvatinrs.Text))
                FooterTotalAmount = FooterTotalAmount + Math.Round(Convert.ToDouble(ltamount.Text))
            Next
            lttotalamount.Text = Math.Round(FooterTotalAmount + VatAmount + Convert.ToDouble(lblfreight.Text)).ToString("N2")
            ' ''lttotalvat.Text = Math.Round(VatAmount).ToString("N2")*********MUBYN
            lttotalvat.Text = (VatAmount).ToString("N2")
            Dim divfootvat As HtmlGenericControl = TryCast(grditemproduct.FooterRow.FindControl("divfootvat"), HtmlGenericControl)
            Dim divfootvatamt As HtmlGenericControl = TryCast(grditemproduct.FooterRow.FindControl("divfootvatamt"), HtmlGenericControl)
            If ddCurrency.SelectedValue = "USD" Then
                VatAmount = 0
                lttotalvat.Text = "0"
                divfootvat.Visible = False
                divfootvatamt.Visible = False
            Else
                divfootvat.Visible = True
                divfootvatamt.Visible = True
            End If


        End If
    End Sub
    Protected Sub txtinsurance_TextChanged(sender As Object, e As EventArgs) Handles txtinsurance.TextChanged
        checkfreight()
    End Sub

    Protected Sub txtocfrei_TextChanged(sender As Object, e As EventArgs) Handles txtocfrei.TextChanged
        checkfreight()
    End Sub

    Protected Sub txtdocnclr_TextChanged(sender As Object, e As EventArgs) Handles txtdocnclr.TextChanged
        checkfreight()
    End Sub

    Public Sub CheckPrivi()
        Try
            Dim ds As DataSet = UserBLL.CheckPrivi(Session("UserRoleID"), "SalesOrders.aspx")
            Dim strArr() As String
            Dim TemStr As String = ""
            Dim dtPrivi As New DataTable
            dtPrivi = Session("dtPrivilege")
            Dim rows() As DataRow = dtPrivi.Select("Menu_URL = 'SalesOrders.aspx'")

            TemStr = rows(0).Item("Val").ToString()
            strArr = TemStr.Split(",")
            If (strArr.Length > 3) Then
                If MainID = 0 Then
                    If strArr(2) = "1" Then
                    Else
                        Response.Redirect("index.aspx")
                    End If
                Else
                    If strArr(2) = "1" Then
                        'If strArr(1) = "1" Or strArr(2) = "1" Or strArr(3) = "1" Then
                    Else
                        Response.Redirect("index.aspx")
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub FillBanks()
        ddlBank.DataSource = ProspectBLL.Dropdown()
        ddlBank.DataTextField = "Name"
        ddlBank.DataValueField = "Id"
        ddlBank.DataBind()
        ddlBank.Items.Insert(0, New ListItem("Select Bank", "0"))
    End Sub

    Protected Sub txtfreight_TextChanged(sender As Object, e As EventArgs) 'Handles txtfreight.TextChanged
        Try
            FillMainProduct()
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Call", "alert('Error in freight update: " & ex.Message & "')", True)
        End Try
    End Sub
    Protected Sub txtquantity_TextChanged(sender As Object, e As EventArgs)
        Try
            Dim txtQty As TextBox = DirectCast(sender, TextBox)
            Dim row As GridViewRow = DirectCast(txtQty.NamingContainer, GridViewRow)
            Dim rowIndex As Integer = row.RowIndex

            Dim dt As DataTable = TryCast(Session("OrderProduct"), DataTable)
            If dt IsNot Nothing AndAlso dt.Rows.Count > rowIndex Then
                dt.Rows(rowIndex)("OrDetail_Qty") = Convert.ToInt32(txtQty.Text)
                Session("OrderProduct") = dt
            End If

            ' Recalculate totals using session
            ShowHideItemTotalKgsGSTVATfreight()
            DisplayODATagAndAmount()
            DisplayTCSTagAndAmount()

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "err", "alert('Error in quantity update: " & ex.Message & "')", True)
        End Try
    End Sub

    Public Sub FillShippedfrom()
        Try
            Dim ds As DataSet = MainBLL.Dropdown("WarehouseDropDown")
            ddlshippedfrom.DataSource = ds.Tables(0)
            ddlshippedfrom.DataTextField = "Warehouse_Name"
            ddlshippedfrom.DataValueField = "Warehouse_ID"
            ddlshippedfrom.DataBind()
            ddlshippedfrom.Items.Insert(0, New ListItem("Select Warehouse", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub


    Public Sub FillBilledfrom()
        Try
            Dim ds As DataSet = MainBLL.Dropdown("CompanyDropDown")
            ddlbilledfrom.DataSource = ds.Tables(0)
            ddlbilledfrom.DataTextField = "Company_Name"
            ddlbilledfrom.DataValueField = "Company_ID"
            ddlbilledfrom.DataBind()
            ddlbilledfrom.Items.Remove(ddlbilledfrom.Items.FindByValue("5"))
            ddlbilledfrom.Items.Insert(0, New ListItem("Select Company", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class