Imports DynamicparcelEnumerations
Imports System.Data
Imports System.Data.SqlClient

Partial Class ModifyQuotationrequest
    Inherits _PageBaseClass
    Dim MainID As Integer
    Dim dt As New Data.DataTable
    Dim addrowtype As New Label
    Dim Temptable As DataTable
    Dim strvat As New List(Of String)
    Private dt2 As New DataSet

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
            Try
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("index.aspx")
                End If
                If Request.QueryString("chk") = "e" Then
                    lbltitle1.Text = "Modify Quotation Request"
                    lbltitle2.Text = "Modify Quotation Request"


                ElseIf Request.QueryString("chk") = "v" Then
                    lbltitle1.Text = "View Quotation Request"
                    lbltitle2.Text = "View Quotation Request"
                    FullPanel.Enabled = False
                    btnopen.Visible = False
                Else
                    lbltitle1.Text = "New Quotation Request"
                    lbltitle2.Text = "New Quotation Request"
                End If

                'DynamicparcelGridview.CheckPrivilageForModify(Session("UserRoleID"), Button1, btnadd, "Vendor.aspx")
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyVendor", "Page_Init", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "');window.location='index.aspx';", True)
            End Try
        Else
            Try
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("index.aspx")
                End If
                If Request.QueryString("chk") = "e" Then
                    lbltitle1.Text = "Modify Quotation Request"
                    lbltitle2.Text = "Modify Quotation Request"


                ElseIf Request.QueryString("chk") = "v" Then
                    lbltitle1.Text = "View Quotation Request"
                    lbltitle2.Text = "View Quotation Request"
                    FullPanel.Enabled = False
                    btnopen.Visible = False
                Else
                    lbltitle1.Text = "New Quotation Request"
                    lbltitle2.Text = "New Quotation Request"
                End If
                'DynamicparcelGridview.CheckPrivilageForModify(Session("UserRoleID"), Button1, btnadd, "Vendor.aspx")
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyVendor", "Page_Init", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "');window.location='index.aspx';", True)
            End Try
        End If
    End Sub
    Protected Sub grditemproduct_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grditemproduct.RowDataBound
        For Each row As GridViewRow In grditemproduct.Rows


            Dim lnkdelete = DirectCast(row.FindControl("lnkdelete"), LinkButton)

            If Request.QueryString("chk") = "v" Then
                lnkdelete.Visible = False
            End If
        Next
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                FirstGridViewRow()
                FillGodown()
                'txtdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                '     txtdate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")
                FillBilledfrom()
                If Not MainID = "0" Then
                    FillDetail()
                    modifyspan.Visible = True
                    txtdate.Enabled = False
                Else
                    txtcode.Text = MainBLL.GetGodownCode("QuotationCode")
                    FillGodown()
                    'txtdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                    txtdate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")
                    txtdate.Attributes("min") = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")
                    fillVendorViewEdit()
                    modifyspan.Visible = False
                End If

            Catch ex As Exception
                'Response.Redirect("index.aspx")
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyVendor", "Page_Load", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
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

      
        ' txtdate.Attributes("min") = DateTime.Now.ToString("yyyy-MM-dd")
        'txtdate.Attributes("min") = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")
    End Sub
   
    Public Sub FillBilledfrom() ' gayatri on 09-06-17
        Dim ds As DataSet = MainBLL.Dropdown("CompanyDropDown")
        ddlbilledfrom.DataSource = ds.Tables(0)
        ddlbilledfrom.DataTextField = "Company_Name"
        ddlbilledfrom.DataValueField = "Company_ID"
        ddlbilledfrom.DataBind()
        ddlbilledfrom.Items.Insert(0, New ListItem("Select Company", "0"))
    End Sub
    Public Sub FillSearch() 'gayatri 08-06-17
        Try
            'GridView2.DataSource = QuotationRequestBLL.SearchVendorByQuotation(MainID, txtsearch.Text.Trim).Tables(0)
            'GridView2.DataBind()

            If Session("OrderProduct") IsNot Nothing Then
                Dim dt As DataTable = DirectCast(Session("OrderProduct"), DataTable)
                If dt.Rows.Count > 0 Then
                    For Each row As DataRow In dt.Rows
                        Dim a As String = ""
                        strvat.Add(row("Vendor_ID").ToString)

                    Next
                End If
            End If

            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            GridView2.DataSource = QuotationRequestBLL.SearchVendorByQuotation(MainID, txtsearch.Text.Trim).Tables(0)
            GridView2.DataBind()

            For Each value As String In strvat
                For Each row As GridViewRow In GridView2.Rows
                    Dim lblVendorID = DirectCast(row.FindControl("lblVendorID"), Label)
                    If lblVendorID.Text = value Then
                        row.Visible = False
                    End If
                Next
            Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyQuotationRequest", "FillSearch", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub FillGodown()
        Try
            ddgodown.DataSource = MainBLL.Dropdown("GodownDropDown")
            ddgodown.DataTextField = "Godown_Name"
            ddgodown.DataValueField = "Godown_ID"
            ddgodown.DataBind()
            'ddlsource.Items.Insert(0, New ListItem("Select Source", "0"))
            ddgodown.Items.Insert(0, "Select Godown")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyQuotationrequest", "FillGodown", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try
                    QuotationRequestBLL.UpdateQuotation(DynamicparcelDataManipulation.DateFormat(txtdate.Text), txtcode.Text, txtaddinfo.Text, ddgodown.SelectedValue, Session("UserId"), MainID, Convert.ToInt32(ddlbilledfrom.SelectedValue))
                    For Each row As GridViewRow In GridView1.Rows
                        Dim ltqrid = DirectCast(row.FindControl("ltqrid"), Literal)
                        Dim ltattid = DirectCast(row.FindControl("ltattid"), Literal)
                        Dim ddrawmaterial = DirectCast(row.FindControl("ddrawmaterial"), DropDownList)
                        Dim txtquantity = DirectCast(row.FindControl("txtquantity"), TextBox)
                        Dim ddunuit = DirectCast(row.FindControl("ddunuit"), DropDownList)
                        Dim rfvddmaterial = DirectCast(row.FindControl("rfvddmaterial"), RequiredFieldValidator)
                        Dim rfvdqty = DirectCast(row.FindControl("rfvdqty"), RequiredFieldValidator)
                        Dim rfvddunit = DirectCast(row.FindControl("rfvddunit"), RequiredFieldValidator)
                        If ddrawmaterial.SelectedValue = "Select Raw Material" Then
                            'vendorbll.insertprinciple(ddrawmaterial.selectedvalue, session("userid"), mainid)
                            rfvddmaterial.Enabled = True
                         

                        Else

                            QuotationRequestBLL.UpdateRawMaterial(ddrawmaterial.SelectedValue, txtquantity.Text, ddunuit.SelectedValue, Session("UserId"), ltqrid.Text)
                        End If

                    Next
                    QuotationRequestBLL.QuotationVendorDeleteSi(MainID)
                    For i As Integer = 0 To grditemproduct.Rows.Count - 1
                        Dim ltvendorid As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltvendorid"), Label)
                        'QuotationRequestBLL.UpdateVendor(ltvendorid.Text, Session("UserId"), MainID)
                        QuotationRequestBLL.InsertVendor(MainID, ltvendorid.Text, Session("UserId"))
                    Next


                    Response.Redirect("QuotationRequest.aspx")
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ModifyQuotationrequest", "UPDATE", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Case DML_OPERATION.INSERT
                Try
                    ''Adding Quotation 
                    Dim QuotationID As String
                    QuotationID = QuotationRequestBLL.InsertQuotation(DynamicparcelDataManipulation.DateFormat(txtdate.Text), txtcode.Text, txtaddinfo.Text, ddgodown.SelectedValue, Session("UserId"), Convert.ToInt32(ddlbilledfrom.SelectedValue))

                    ''Adding Raw material
                    For Each row As GridViewRow In GridView1.Rows
                        Dim ddrawmaterial = DirectCast(row.FindControl("ddrawmaterial"), DropDownList)
                        Dim txtquantity = DirectCast(row.FindControl("txtquantity"), TextBox)
                        Dim ddunuit = DirectCast(row.FindControl("ddunuit"), DropDownList)
                        Dim rfvddmaterial = DirectCast(row.FindControl("rfvddmaterial"), RequiredFieldValidator)
                        If ddrawmaterial.SelectedValue = "Select Raw Material" Then
                            'vendorbll.insertprinciple(ddrawmaterial.selectedvalue, session("userid"), mainid)
                            rfvddmaterial.Enabled = True
                        Else
                            QuotationRequestBLL.InsertRawMaterial(ddrawmaterial.SelectedIndex, txtquantity.Text, ddunuit.SelectedValue, Session("UserId"), QuotationID)
                        End If
                    Next

                    ''Adding Vendor
                    For i As Integer = 0 To grditemproduct.Rows.Count - 1
                        Dim ltvendorid As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltvendorid"), Label)

                        QuotationRequestBLL.InsertVendor(QuotationID, ltvendorid.Text, Session("UserId"))
                    Next


                    Response.Redirect("QuotationRequest.aspx")
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ModifyQuotationrequest", "INSERT", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub
    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If Page.IsValid Then
                Dim dtcount As DataTable = Session("OrderProduct")

                ''Adding Raw material
                For Each row As GridViewRow In GridView1.Rows
                    Dim ddrawmaterial = DirectCast(row.FindControl("ddrawmaterial"), DropDownList)
                    Dim txtquantity = DirectCast(row.FindControl("txtquantity"), TextBox)
                    Dim ddunuit = DirectCast(row.FindControl("ddunuit"), DropDownList)
                    Dim rfvddmaterial = DirectCast(row.FindControl("rfvddmaterial"), RequiredFieldValidator)
                    Dim rfvdqty = DirectCast(row.FindControl("rfvdqty"), RequiredFieldValidator)
                    Dim rfvddunit = DirectCast(row.FindControl("rfvddunit"), RequiredFieldValidator)
                    If ddrawmaterial.SelectedValue = "Select Raw Material" Then
                        rfvddmaterial.Enabled = True
                    Else
                        rfvddmaterial.Enabled = False
                    End If
                    If ddunuit.SelectedValue = "Select Material" Then
                        rfvddunit.Enabled = True
                    Else
                        rfvddunit.Enabled = True
                    End If
                    If txtquantity.Text = "" Then
                        rfvdqty.Enabled = True
                    Else
                        rfvdqty.Enabled = False
                    End If
                Next

                If dtcount.Rows.Count = 0 Then
                    ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "Call", "alert('Please select vendor')", True)
                Else
                    If MainID = 0 Then
                        SaveProduct(DML_OPERATION.INSERT)
                    ElseIf MainID > 0 Then
                        SaveProduct(DML_OPERATION.UPDATE)
                    End If
                End If

            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyQuotationrequest", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub FillDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "QuotationReqViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                txtcode.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationRequest_No").ToString())
                txtdate.Text = DynamicparcelDataManipulation.DateFormat(drLogin("QuotationRequest_Date").ToString())
                ddgodown.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationRequest_Godown_ID").ToString())
                txtaddinfo.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationRequest_AdditionalInfo").ToString())
                'txtaddinfo.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationRequest_Vendor_ID").ToString())
                lblmodifiedname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                lblmodifieddate.Text = DynamicparcelDataManipulation.DateFormat(drLogin("QuotationRequest_ModifiedDate").ToString())
                ddlbilledfrom.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationRequest_CompanyID").ToString())
                FillRawmaterialViewByID(dt)
                fillVendorViewEdit()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyQuotationrequest", "FillDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Public Sub FillRawmaterialViewByID(ByVal ViewQuotation As DataSet)
        Dim dsRcptDtl As DataSet
        Try
            dsRcptDtl = QuotationRequestBLL.FillGridViewByID("fillmaterialByQuotation", MainID)
            Temptable = dsRcptDtl.Tables(0)
            ViewState("CurrentTable") = Temptable
            GridView1.DataSource = dsRcptDtl
            GridView1.DataBind()
        Catch ex As Exception
            Dim errorMsg As String = ex.Message.Replace(Chr(34), "")
            errorMsg = errorMsg.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyQuotationrequest", "fillRcptDtl", errorMsg, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (errorMsg.ToString).ToString + "')", True)
        End Try
    End Sub
   
    Public Sub fillRcptDtl()
        Dim dsRcptDtl As DataSet
        Try
            dsRcptDtl = QuotationRequestBLL.FillGridView("FillRawMaterialDropDown")
            Temptable = dsRcptDtl.Tables(0)
            ViewState("CurrentTable") = Temptable
            GridView1.DataSource = dsRcptDtl
            GridView1.DataBind()

        Catch ex As Exception
            Dim errorMsg As String = ex.Message.Replace(Chr(34), "")
            errorMsg = errorMsg.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyQuotationrequest", "fillRcptDtl", errorMsg, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (errorMsg.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "AddNewRow" Then
                AddNewRow()
            ElseIf e.CommandName = "Add" Then
                FirstGridViewRow()
            ElseIf e.CommandName = "deletelink" Then
                If ViewState("CurrentTable") IsNot Nothing Then
                    Dim dt As DataTable = DirectCast(ViewState("CurrentTable"), DataTable)
                    Dim drCurrentRow As DataRow = Nothing
                    Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
                    If dt.Rows.Count > 0 Then
                        dt.Rows.Remove(dt.Rows(rowIndex))
                        drCurrentRow = dt.NewRow()
                        ViewState("CurrentTable") = dt
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                        For i As Integer = 0 To GridView1.Rows.Count - 2
                            GridView1.Rows(i).Cells(0).Text = Convert.ToString(i + 1)
                        Next
                    End If
                End If
                SetPreviousData()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyQuotationrequest", "Gridview4_RowCommand", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)

        End Try
    End Sub
    Private Sub FirstGridViewRow()
        Try
            Dim dt As New DataTable()
            Dim dr As DataRow = Nothing
            dt.Columns.Add(New DataColumn("RowNumber", GetType(String)))
            dt.Columns.Add(New DataColumn("QRRawMaterial_QRDID", GetType(String)))
            dt.Columns.Add(New DataColumn("QRRawMaterial_RawID", GetType(String)))
            dt.Columns.Add(New DataColumn("QRRawMaterial_Quantity", GetType(String)))
            dt.Columns.Add(New DataColumn("QRRawMaterial_Unit", GetType(String)))
            'dt.Columns.Add(New DataColumn("Principle_EmailID", GetType(String)))
            dr = dt.NewRow()
            dr("RowNumber") = 1
            strrowcount.Value = dr("RowNumber")
            dr("QRRawMaterial_QRDID") = String.Empty
            dr("QRRawMaterial_RawID") = String.Empty
            dr("QRRawMaterial_Quantity") = String.Empty
            dr("QRRawMaterial_Unit") = String.Empty

            dt.Rows.Add(dr)
            ViewState("CurrentTable") = dt
            GridView1.DataSource = dt
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyQuotationrequest", "FirstGridViewRow", error1, Session("UserId"))
            Throw ex
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub AddNewRow()
        Try
            Dim rowIndex As Integer = 0
            'addrowtype.Text = "NEW"
            If ViewState("CurrentTable") IsNot Nothing Then
                Dim dtCurrentTable As DataTable = DirectCast(ViewState("CurrentTable"), DataTable)
                Dim drCurrentRow As DataRow = Nothing
                If dtCurrentTable.Rows.Count > 0 Then
                    For i As Integer = 1 To dtCurrentTable.Rows.Count
                        Dim ddrawmaterial As DropDownList = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("ddrawmaterial"), DropDownList)
                        Dim txtquantity As TextBox = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("txtquantity"), TextBox)
                        Dim ddunuit As DropDownList = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("ddunuit"), DropDownList)

                        drCurrentRow = dtCurrentTable.NewRow()
                        drCurrentRow("RowNumber") = i + 1
                        strrowcount.Value = drCurrentRow("RowNumber")
                        'drCurrentRow("RcptDtl_ID") = "0"

                        dtCurrentTable.Rows(i - 1)("QRRawMaterial_RawID") = ddrawmaterial.SelectedValue
                        rowIndex += 1
                    Next

                    dtCurrentTable.Rows.Add(drCurrentRow)
                    ViewState("CurrentTable") = dtCurrentTable
                    GridView1.DataSource = dtCurrentTable
                    GridView1.DataBind()
                End If
            Else
                Response.Write("ViewState is null")
            End If
            SetPreviousData()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyQuotationrequest", "AddNewRow", error1, Session("UserId"))
            Throw ex
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub SetPreviousData()
        Try
            Dim rowIndex As Integer = 0
            If ViewState("CurrentTable") IsNot Nothing Then
                Dim dt As DataTable = DirectCast(ViewState("CurrentTable"), DataTable)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim ddrawmaterial As DropDownList = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("ddrawmaterial"), DropDownList)
                        Dim txtquantity As TextBox = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("txtquantity"), TextBox)
                        Dim ddunuit As DropDownList = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("ddunuit"), DropDownList)
                        GridView1.Rows(i).Cells(0).Text = Convert.ToString(i + 1)

                        ddrawmaterial.SelectedValue = dt.Rows(i)("QRRawMaterial_RawID").ToString
                        txtquantity.Text = dt.Rows(i)("QRRawMaterial_Quantity").ToString
                        ddunuit.Text = dt.Rows(i)("QRRawMaterial_Unit").ToString
                        rowIndex += 1
                    Next
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            'Dim ddprinciple As DropDownList = DirectCast(e.Row.FindControl("ddprinciple"), DropDownList)
            Dim ddrawmaterial As DropDownList = TryCast(e.Row.FindControl("ddrawmaterial"), DropDownList)
            Dim ltattid As Literal = DirectCast(e.Row.FindControl("ltattid"), Literal)
            Dim ddunuit As DropDownList = DirectCast(e.Row.FindControl("ddunuit"), DropDownList)
            Dim lblunite As Label = DirectCast(e.Row.FindControl("lblunite"), Label)
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim ds As New DataSet
                ds = MainBLL.Dropdown("RawmaterialDropDown")
                ddrawmaterial.DataSource = ds.Tables(0)
                'ddprinciple.DataSource = MainBLL.Dropdown("PrincipleDropDown")
                ddrawmaterial.DataTextField = "Rm_Name"
                ddrawmaterial.DataValueField = "Rm_ID"
                ddrawmaterial.DataBind()
                ddrawmaterial.Items.Insert(0, "Select Raw Material")
                ddrawmaterial.SelectedValue = ltattid.Text
                ddunuit.SelectedValue = lblunite.Text
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub FirstGridViewRowWithPenelty(ByVal amt As Double)
        Try
            Dim dt As New DataTable()
            Dim dr As DataRow = Nothing
            dt.Columns.Add(New DataColumn("RowNumber", GetType(String)))
            dt.Columns.Add(New DataColumn("Principle_ID", GetType(String)))
            dt.Columns.Add(New DataColumn("Principle_ContactPerson", GetType(String)))
            dt.Columns.Add(New DataColumn("Principle_MobileNo", GetType(String)))
            dt.Columns.Add(New DataColumn("Principle_City", GetType(String)))
            dt.Columns.Add(New DataColumn("Principle_EmailID", GetType(String)))

            dr = dt.NewRow()
            dr("RowNumber") = 1
            dr("Principle_ID") = "1"
            dr("Principle_ContactPerson") = String.Empty
            dr("Principle_MobileNo") = String.Empty
            dr("Principle_City") = String.Empty
            dr("Principle_EmailID") = String.Empty

            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("RowNumber") = 2
            dr("Principle_ID") = String.Empty
            dr("Principle_ContactPerson") = String.Empty
            dr("Principle_MobileNo") = String.Empty
            dr("Principle_City") = String.Empty
            dr("Principle_EmailID") = String.Empty
            dt.Rows.Add(dr)


            ViewState("CurrentTable") = dt
            GridView1.DataSource = dt
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyVisa", "FirstGridViewRow", error1, Session("UserId"))
            Throw ex
        End Try
    End Sub

    ''Code for the vendor view edit
    Public Sub fillVendorViewEdit()
        Try
            Dim dtbl As New DataTable
            dtbl.Columns.Add("ItemDt_ID", GetType(Integer))
            dtbl.Columns.Add("Vendor_ID", GetType(Integer))
            dtbl.Columns.Add("Vendor_Name", GetType(String))
            dtbl.Columns.Add("Contact_ContactPerson", GetType(String))
            dtbl.Columns.Add("Contact_Mobile", GetType(String))
            dtbl.Columns.Add("Contact_Email", GetType(String))
            dtbl = QuotationRequestBLL.VendorViewByQuotation(MainID).Tables(0)
            Session("OrderProduct") = dtbl
            If dtbl.Columns.Count > 0 Then
                grditemproduct.DataSource = dtbl
                grditemproduct.DataBind()
            Else
                Dim lblmessage As Label
                lblmessage.Text = "No record found"
            End If
            
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTargetCategory", "fillProduct", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try

    End Sub
    Protected Sub btnopen_Click(sender As Object, e As EventArgs) Handles btnopen.Click
        Try
            mpe.Show()
            FillProductGrid()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTargetCategory", "btnopen_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub FillProductGrid()
        Try

            If Session("OrderProduct") IsNot Nothing Then
                Dim dt As DataTable = DirectCast(Session("OrderProduct"), DataTable)
                If dt.Rows.Count > 0 Then
                    For Each row As DataRow In dt.Rows
                        Dim a As String = ""
                        strvat.Add(row("Vendor_ID").ToString)

                    Next
                End If
            End If

            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            GridView2.DataSource = QuotationRequestBLL.VendorByQuotationADD(MainID)
            GridView2.DataBind()

            For Each value As String In strvat
                For Each row As GridViewRow In GridView2.Rows
                    Dim lblVendorID = DirectCast(row.FindControl("lblVendorID"), Label)
                    If lblVendorID.Text = value Then
                        row.Visible = False
                    End If
                Next
            Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTargetCategory", "FillProductGrid", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            Dim count As Integer
            If Session("OrderProduct") Is Nothing Then
                count = 0
                Dim dtbl As New DataTable
                dtbl.Columns.Add("ItemDt_ID", GetType(Integer))
                dtbl.Columns.Add("Vendor_ID", GetType(Integer))
                dtbl.Columns.Add("Vendor_Name", GetType(String))
                dtbl.Columns.Add("Contact_ContactPerson", GetType(String))
                dtbl.Columns.Add("Contact_Mobile", GetType(String))
                dtbl.Columns.Add("Contact_Email", GetType(String))
                Dim myrow As DataRow
                For Each row As GridViewRow In GridView2.Rows
                    Dim lblVendorID = DirectCast(row.FindControl("lblVendorID"), Label)
                    Dim lblname = DirectCast(row.FindControl("lblname"), Label)
                    Dim lblcontact = DirectCast(row.FindControl("lblcontact"), Label)
                    Dim lblmobile = DirectCast(row.FindControl("lblmobile"), Label)
                    Dim lblemail = DirectCast(row.FindControl("lblemail"), Label)
                    Dim ckselect = DirectCast(row.FindControl("ckselect"), CheckBox)
                    If ckselect.Checked = True Then
                        myrow = dtbl.NewRow()
                        myrow("ItemDt_ID") = count
                        myrow("Vendor_ID") = lblVendorID.Text
                        myrow("Vendor_Name") = lblname.Text
                        myrow("Contact_ContactPerson") = lblcontact.Text
                        myrow("Contact_Mobile") = lblmobile.Text
                        myrow("Contact_Email") = lblemail.Text
                        ' dtbl.Rows.Add(count, lblproductId.Text, lblname.Text, lblcode.Text, lblunit.Text, lblCategory.Text)
                        dtbl.Rows.Add(myrow)
                        count = count + 1
                    End If
                Next
                Session("OrderProduct") = dtbl
            Else
                Dim myrow As DataRow
                Dim dtbl As DataTable = DirectCast(Session("OrderProduct"), DataTable)
                count = dtbl.Rows.Count
                For Each row As GridViewRow In GridView2.Rows
                    Dim lblVendorID = DirectCast(row.FindControl("lblVendorID"), Label)
                    Dim lblname = DirectCast(row.FindControl("lblname"), Label)
                    Dim lblcontact = DirectCast(row.FindControl("lblcontact"), Label)
                    Dim lblmobile = DirectCast(row.FindControl("lblmobile"), Label)
                    Dim lblemail = DirectCast(row.FindControl("lblemail"), Label)
                    Dim ckselect = DirectCast(row.FindControl("ckselect"), CheckBox)
                    If ckselect.Checked = True Then
                        myrow = dtbl.NewRow()
                        myrow("ItemDt_ID") = count
                        myrow("Vendor_ID") = lblVendorID.Text
                        myrow("Vendor_Name") = lblname.Text
                        myrow("Contact_ContactPerson") = lblcontact.Text
                        myrow("Contact_Mobile") = lblmobile.Text
                        myrow("Contact_Email") = lblemail.Text
                        ' dtbl.Rows.Add(count, lblproductId.Text, lblname.Text, lblcode.Text, lblunit.Text, lblCategory.Text)
                        dtbl.Rows.Add(myrow)
                        count = count + 1
                    End If
                Next
                Session("OrderProduct") = dtbl
            End If
            FillMainProduct()
            FillProductGrid()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTargetCategory", "btnsave_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub FillMainProduct()
        Try
            If Session("OrderProduct") IsNot Nothing Then
                Dim dt As DataTable = DirectCast(Session("OrderProduct"), DataTable)
                If dt.Rows.Count > 0 Then
                    grditemproduct.DataSource = Session("OrderProduct")
                    grditemproduct.DataBind()
                Else
                    grditemproduct.DataSource = Nothing
                    grditemproduct.DataBind()
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTargetCategory", "FillMainProduct", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub btnsaveclose_Click(sender As Object, e As EventArgs) Handles btnsaveclose.Click
        Try
            Dim count As Integer
            If Session("OrderProduct") Is Nothing Then
                count = 0
                Dim dtbl As New DataTable
                dtbl.Columns.Add("ItemDt_ID", GetType(Integer))
                dtbl.Columns.Add("Vendor_ID", GetType(Integer))
                dtbl.Columns.Add("Vendor_Name", GetType(String))
                dtbl.Columns.Add("Contact_ContactPerson", GetType(String))
                dtbl.Columns.Add("Contact_Mobile", GetType(String))
                dtbl.Columns.Add("Contact_Email", GetType(String))
                Dim myrow As DataRow
                For Each row As GridViewRow In GridView2.Rows
                    Dim lblVendorID = DirectCast(row.FindControl("lblVendorID"), Label)
                    Dim lblname = DirectCast(row.FindControl("lblname"), Label)
                    Dim lblcontact = DirectCast(row.FindControl("lblcontact"), Label)
                    Dim lblmobile = DirectCast(row.FindControl("lblmobile"), Label)
                    Dim lblemail = DirectCast(row.FindControl("lblemail"), Label)
                    Dim ckselect = DirectCast(row.FindControl("ckselect"), CheckBox)
                    If ckselect.Checked = True Then
                        myrow = dtbl.NewRow()
                        myrow("ItemDt_ID") = count
                        myrow("Vendor_ID") = lblVendorID.Text
                        myrow("Vendor_Name") = lblname.Text
                        myrow("Contact_ContactPerson") = lblcontact.Text
                        myrow("Contact_Mobile") = lblmobile.Text
                        myrow("Contact_Email") = lblemail.Text
                        ' dtbl.Rows.Add(count, lblproductId.Text, lblname.Text, lblcode.Text, lblunit.Text, lblCategory.Text)
                        dtbl.Rows.Add(myrow)
                        count = count + 1
                    End If
                Next
                Session("OrderProduct") = dtbl
            Else
                Dim dtbl As DataTable = DirectCast(Session("OrderProduct"), DataTable)
                Dim myrow As DataRow
                count = dtbl.Rows.Count
                For Each row As GridViewRow In GridView2.Rows
                    Dim lblVendorID = DirectCast(row.FindControl("lblVendorID"), Label)
                    Dim lblname = DirectCast(row.FindControl("lblname"), Label)
                    Dim lblcontact = DirectCast(row.FindControl("lblcontact"), Label)
                    Dim lblmobile = DirectCast(row.FindControl("lblmobile"), Label)
                    Dim lblemail = DirectCast(row.FindControl("lblemail"), Label)
                    Dim ckselect = DirectCast(row.FindControl("ckselect"), CheckBox)
                    If ckselect.Checked = True Then
                        myrow = dtbl.NewRow()
                        myrow("ItemDt_ID") = count
                        myrow("Vendor_ID") = lblVendorID.Text
                        myrow("Vendor_Name") = lblname.Text
                        myrow("Contact_ContactPerson") = lblcontact.Text
                        myrow("Contact_Mobile") = lblmobile.Text
                        myrow("Contact_Email") = lblemail.Text
                        ' dtbl.Rows.Add(count, lblproductId.Text, lblname.Text, lblcode.Text, lblunit.Text, lblCategory.Text)
                        dtbl.Rows.Add(myrow)
                        count = count + 1
                    End If
                Next
                Session("OrderProduct") = dtbl
            End If
            FillMainProduct()
            mpe.Hide()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTargetCategory", "btnsave_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub GridView2_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grditemproduct.RowCommand
        If e.CommandName = "deletelink" Then
            Try
                Dim btn As LinkButton = TryCast(e.CommandSource, LinkButton)
                Dim row As GridViewRow = TryCast(btn.NamingContainer, GridViewRow)
                Dim ltitemid As Label = TryCast(row.FindControl("ltitemid"), Label)
                Dim dt As DataTable
                dt = DirectCast(Session("OrderProduct"), DataTable)
                If dt.Rows.Count >= 0 Then
                    For Each rows As DataRow In dt.Rows
                        Dim a As Integer
                        If rows("ItemDt_ID").ToString = ltitemid.Text Then
                            a = CDbl(rows("ItemDt_ID").ToString)
                            dt.Rows.Remove(rows)
                            Session("OrderProduct") = dt
                            FillMainProduct()
                            Exit For
                        End If
                    Next
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyTargetCategory", "deletelink", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try

        End If
    End Sub

    '=================================GAYATRI====================================
    
    
   
End Class
