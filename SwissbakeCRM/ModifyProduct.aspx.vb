Imports DynamicparcelEnumerations

Partial Class ModifyProduct
    Inherits System.Web.UI.Page
    Dim MainID As Integer

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
            If (Request.QueryString("Id") = Nothing) Then
                Response.Redirect("index.aspx")
            End If
            DynamicparcelGridview.CheckPrivilageForModify(Session("UserRoleID"), Button1, btnadd, "Product.aspx")
            If Request.QueryString("chk") = "v" Then
                txtbarcode.ReadOnly = True
                txtdesc.ReadOnly = True
                txtminorder.ReadOnly = True
                txtprice.ReadOnly = True
                txtproductname.ReadOnly = True
                txtrefid.ReadOnly = True
                txttariffheading.ReadOnly = True
                btnadd.Visible = False
                Button1.Visible = False
                ddcategory.CssClass = "form-control"
                ddcurrency.CssClass = "form-control"
                dduom.CssClass = "form-control"
                ddcategory.Enabled = False
                ddcurrency.Enabled = False
                dduom.Enabled = False
            Else
                lbltitle1.Text = "Modify Product"
                lbltitle2.Text = "Modify Product"
            End If
        Else
            If (Request.QueryString("Id") = Nothing) Then
                Response.Redirect("index.aspx")
            End If
            DynamicparcelGridview.CheckPrivilageForModify(Session("UserRoleID"), Button1, btnadd, "Product.aspx")
            If Request.QueryString("chk") = "v" Then
                txtbarcode.ReadOnly = True
                txtdesc.ReadOnly = True
                txtminorder.ReadOnly = True
                txtprice.ReadOnly = True
                txtproductname.ReadOnly = True
                txtrefid.ReadOnly = True
                txttariffheading.ReadOnly = True
                btnadd.Visible = False
                Button1.Visible = False
                ddcategory.CssClass = "form-control"
                ddcurrency.CssClass = "form-control"
                dduom.CssClass = "form-control"
                ddcategory.Enabled = False
                ddcurrency.Enabled = False
                dduom.Enabled = False
            Else
                lbltitle1.Text = "Modify Product"
                lbltitle2.Text = "Modify Product"
            End If
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                FillCategory()
                FillCurrency()
                FillUOM()
                If MainID = "0" Then
                    lbltitle1.Text = "New Product"
                    lbltitle2.Text = "New Product"
                    divdate.Visible = False
                    modifyspan.Visible = False
                    divopenningstock.Visible = True
                    'Add This Line For DocumentBLL Control 
                    documentcontrol.Visible = True
                    Newdocumentcontrol.Visible = False
                    documentcontrol.Uhftype.Value = "Product"
                    documentcontrol.Uhftypeid.Value = MainID
                    Newdocumentcontrol.Uhftype.Value = "Product"
                    Newdocumentcontrol.Uhftypeid.Value = MainID
                    'itemcontrol.Uhftype.Value = "Product"
                    'itemcontrol.Uhftypeid.Value = MainID
                    ''Add This Line For DocumentBLL Control 
                Else
                    modifyspan.Visible = True
                    divopenningstock.Visible = False
                    FillDetail()
                    'Add This Line For DocumentBLL Control 
                    documentcontrol.Visible = False
                    Newdocumentcontrol.Visible = True
                    documentcontrol.Uhftype.Value = "Product"
                    documentcontrol.Uhftypeid.Value = MainID
                    Newdocumentcontrol.Uhftype.Value = "Product"
                    Newdocumentcontrol.Uhftypeid.Value = MainID
                    'itemcontrol.Uhftype.Value = "Product"
                    'itemcontrol.Uhftypeid.Value = MainID
                    ''Add This Line For DocumentBLL Control 
                End If
            Catch ex As Exception
                Response.Redirect("index.aspx")
            End Try
        End If
    End Sub

    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try
                    ProductBLL.Update(txtproductname.Text.Trim, ddcategory.SelectedValue, txtrefid.Text.Trim, txtbarcode.Text.Trim, dduom.SelectedValue,
                                    txtprice.Text.Trim, txttariffheading.Text.Trim, txtminorder.Text.Trim, ddcurrency.SelectedValue,
                                    txtdesc.Text.Trim, Session("UserId"), MainID, Session("Audlog_Id"))
                    'Add This Line For DocumentBLL Control 
                    'documentcontrol.AddDocument(MainID)
                    'Add This Line For DocumentBLL Control 
                    ''Add This Line For ItemBLL ProductControl 
                    'itemcontrol.AddItem(MainID)
                    ''Add This Line For ItemBLL ProductControl 
                    Response.Redirect("Product.aspx")
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ModifyProduct", "UPDATE", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Case DML_OPERATION.INSERT
                Try
                    If String.IsNullOrEmpty(txtopenstock.Text) Then
                        txtopenstock.Text = "0"
                    End If
                    MainID = ProductBLL.Insert(txtproductname.Text.Trim, ddcategory.SelectedValue, txtrefid.Text.Trim, txtbarcode.Text.Trim, dduom.SelectedValue,
                                       txtprice.Text.Trim, txttariffheading.Text.Trim, txtminorder.Text.Trim, ddcurrency.SelectedValue,
                                       txtdesc.Text.Trim, txtopenstock.Text.Trim, Session("UserId"), Session("Audlog_Id"))
                    'Add This Line For DocumentBLL Control 
                    documentcontrol.AddDocument(MainID)
                    'Add This Line For DocumentBLL Control 
                    ''Add This Line For ItemBLL ProductControl 
                    'itemcontrol.AddItem(MainID)
                    ''Add This Line For ItemBLL ProductControl 
                    Response.Redirect("Product.aspx")
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ModifyProduct", "INSERT", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        If MainID = 0 Then
            SaveProduct(DML_OPERATION.INSERT)
        ElseIf MainID > 0 Then
            SaveProduct(DML_OPERATION.UPDATE)
        End If
    End Sub

    Public Sub FillDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "ProductViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            txtproductname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Product_Name").ToString())
            ddcategory.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Product_CategoryId").ToString())
            txtrefid.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Product_ReferenceNo").ToString())
            txtbarcode.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Product_BarCode").ToString())
            dduom.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Product_UOMID").ToString())
            txtprice.Text = CInt(DynamicparcelDataManipulation.FixNullFromDB(drLogin("Product_Price").ToString()))
            txttariffheading.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Product_TariffHeading").ToString())
            txtminorder.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Product_MinOrder").ToString())
            ddcurrency.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Product_CurrencyId").ToString())
            txtdesc.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Product_Description").ToString())
            lblmodifieddate.Text = DynamicparcelDataManipulation.AlphaDateFormat(drLogin("Product_ModifiedDate").ToString())
            lblmodifiedname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("ModfName").ToString())
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyProduct", "FillDetail", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillCategory()
        Try
            ddcategory.DataSource = MainBLL.Dropdown("CategoryDropDown")
            ddcategory.DataTextField = "Breadcrumb"
            ddcategory.DataValueField = "Category_ID"
            ddcategory.DataBind()
            ddcategory.Items.Insert(0, "Select Category")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyProduct", "FillCategory", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillCurrency()
        Try
            ddcurrency.DataSource = MainBLL.Dropdown("CurrencyDropdown")
            ddcurrency.DataTextField = "Currency_Name"
            ddcurrency.DataValueField = "Currency_ID"
            ddcurrency.DataBind()
            'ddcurrency.Items.Insert(0, "Select Currency")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyProduct", "FillCurrency", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillUOM()
        Try
            dduom.DataSource = MainBLL.Dropdown("UOMDropdown")
            dduom.DataTextField = "UOM_Name"
            dduom.DataValueField = "UOM_ID"
            dduom.DataBind()
            'dduom.Items.Insert(0, "Select UOM")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyProduct", "FillUOM", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

End Class
