
Partial Class ViewVendor
    Inherits _PageBaseClass
    Dim MainID As Integer
    Dim Count As Integer = 0
    'Dim countrydt As DataTable
    Dim statedt As DataTable

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
            Try
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("index.aspx")
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ViewVendor", "Page_Init", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        Else
            Try
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("index.aspx")
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ViewVendor", "Page_Init", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Me.txtsearch.Attributes.Add("onkeyup", String.Format("javascript:__doPostBack('{0}','')", Me.UpdatePanel1.ClientID))
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                '' privilage()
                'FillCount()
                aedit.HRef = Page.ResolveUrl("ModifyVendor.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())) + "&returnurl=y")
                FillDetail()
                fillUser()
                FillPrinciple()
                'FillBillingAddressDetail()
                'fillOrder()
                'fillInvoice()
                'fillPayment()
                activitycontrol.Uhftype.Value = "Vendor"
                activitycontrol.Uhftypeid.Value = MainID
                documentcontrol.Uhftype.Value = "Vendor"
                documentcontrol.Uhftypeid.Value = MainID
                notecontrol.Uhftype.Value = "Vendor"
                notecontrol.Uhftypeid.Value = MainID
                'contactcontrol.Uhftype.Value = "Vendor"
                'contactcontrol.Uhftypeid.Value = MainID
                'oportunitycontrol.Uhftype.Value = "Vendor"
                'oportunitycontrol.Uhftypeid.Value = MainID
                emailcontrol.Uhftype.Value = "Vendor"
                emailcontrol.Uhftypeid.Value = MainID
                'quotationcontrol.Uhftype.Value = "Vendor"
                'quotationcontrol.Uhftypeid.Value = MainID
            Else
                Dim target As String = Me.Request.Form("__EVENTTARGET")
                If Not String.IsNullOrEmpty(target) AndAlso target.Equals(Me.UpdatePanel1.ClientID) Then
                    If Not String.IsNullOrEmpty(Me.txtsearch.Text) Then
                        'GridView1.AllowCustomPaging = False
                        FillSearch()
                    Else
                        'GridView1.AllowCustomPaging = True
                        fillUser()
                        FillPrinciple()
                    End If
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewVendor", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
        'FillDetail()
        'upquickaction.Update()
    End Sub

    'Protected Sub lkquicktask_Click(sender As Object, e As EventArgs) Handles lkquicktask.Click
    '    Try
    '        activitycontrol.dateTimeFuntion()
    '        activitycontrol.Utask.Show()
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert("ViewVendor", "lkquicktask_Click", error1, Session("UserId"))
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub

    'Protected Sub lkquickevent_Click(sender As Object, e As EventArgs) Handles lkquickevent.Click
    '    Try
    '        activitycontrol.dateTimeFuntion()
    '        activitycontrol.UtaskEvent.Show()
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert("ViewVendor", "lkquickevent_Click", error1, Session("UserId"))
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub

    'Protected Sub lkquickcall_Click(sender As Object, e As EventArgs) Handles lkquickcall.Click
    '    Try
    '        activitycontrol.dateTimeFuntion()
    '        activitycontrol.UtaskCall.Show()
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert("ViewVendor", "lkquickcall_Click", error1, Session("UserId"))
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub

    Public Sub FillDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "VendorViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            ltemail.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Email").ToString())
            ltcontactname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Vendor_Name").ToString())
            'ltcompanyname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString())
            ltmobile.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Mobile").ToString())
            ltphone.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Landline").ToString())
            lbladdress.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Vendor_Address").ToString()) + " " + DynamicparcelDataManipulation.FixNullFromDB(drLogin("Vendor_City").ToString()) + " " + DynamicparcelDataManipulation.FixNullFromDB(drLogin("Vendor_State").ToString())
            'lblcst.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Cust_Tin").ToString())
            'lblpan.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Cust_Pan").ToString())
            'lblvat.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Cust_Vat").ToString())
            'ltowner.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
            'rpowner.DataSource = AssignToBLL.FillAssignTo("Vendor", MainID)
            'rpowner.DataBind()
            dt = Nothing
            dt = ActivityBLL.FillTaskType("Vendor", MainID, "CountActivity")
            dtUser = dt.Tables(0)
            drLogin = dtUser.Rows(0)
            'ltcounttask.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Task").ToString())
            'ltcountevent.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Evented").ToString())
            'ltcountcall.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Calls").ToString())
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewVendor", "FillDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub privilage()
        Try
            Dim dt As DataSet = PrivilageBLL.CheckPrivilige(Session("UserRoleID"), "Vendor.aspx")
            Dim dtprivilage As New DataTable
            dtprivilage = dt.Tables(0)
            Dim drprivilage As DataRow
            If dtprivilage.Rows.Count = 0 Then
                aedit.Visible = False
                lkdelete.Visible = False
            Else
                drprivilage = dtprivilage.Rows(0)
                If (drprivilage("Prvg_RUpdate").ToString()) = True Then
                    aedit.Visible = True
                Else
                    aedit.Visible = False
                End If
                'If (drprivilage("Prvg_RDelete").ToString()) = True Then
                '    lkdelete.Visible = True
                'Else
                '    lkdelete.Visible = False
                'End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewVendor", "privilage", error1, Session("UserId"))
            ' ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    'Protected Sub lkconvacount_Click(sender As Object, e As EventArgs) Handles lkconvacount.Click
    '    Response.Redirect("CommingSoon.aspx")
    'End Sub

    Protected Sub lkdelete_Click(sender As Object, e As EventArgs) Handles lkdelete.Click
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If deletestatus.Value = "yes" Then
                'MainBLL.DeleteSI(MainID, Session("UserId"), "LeadDeleteSi", Session("Audlog_Id"))
                Response.Redirect("Lead.aspx")
            Else

            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewVendor", "lkdelete_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    'Order
    'Public Sub fillOrder()
    '    Try
    '        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
    '        GridView3.VirtualItemCount = MainBLL.TotalRowInGridviewBYID("OrderTotalNumberOfRecordBYACC", MainID)
    '        If (GridView3.VirtualItemCount = 0) Then
    '            lblorder.Text = "No Orders"
    '        Else
    '            lblorder.Text = "Orders (" + GridView3.VirtualItemCount.ToString + ")"
    '        End If
    '        GridView3.DataSource = MainBLL.FillGridViewById(0, 10, MainID, "OrderBYVendorID")
    '        GridView3.DataBind()
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert("ViewVendor", "fillOrder", error1, Session("UserId"))
    '        'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '        Throw ex
    '    End Try
    'End Sub

    'Protected Sub GridView3_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView3.PageIndexChanging
    '    Try
    '        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
    '        GridView3.PageIndex = e.NewPageIndex
    '        GridView3.DataSource = MainBLL.FillGridViewById(e.NewPageIndex, 10, MainID, "OrderBYVendorID")
    '        GridView3.DataBind()
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub

    'Order

    'Invoice
    'Public Sub fillInvoice()
    '    Try
    '        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
    '        GridView1.VirtualItemCount = MainBLL.TotalRowInGridviewBYID("InvoiceTotalNumberOfRecord", MainID)
    '        If (GridView1.VirtualItemCount = 0) Then
    '            lblinvoice.Text = "No Invoice"
    '        Else
    '            lblinvoice.Text = "Invoice (" + GridView1.VirtualItemCount.ToString + ")"
    '        End If
    '        GridView1.DataSource = MainBLL.FillGridViewById("0", 10, MainID, "InvoiceGridview")
    '        GridView1.DataBind()
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub

    'Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
    '    Try
    '        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
    '        GridView1.PageIndex = e.NewPageIndex
    '        GridView1.DataSource = MainBLL.FillGridViewById(e.NewPageIndex, 10, MainID, "InvoiceGridview")
    '        GridView1.DataBind()
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub

    'Invoice

    'payment
    'Public Sub fillPayment()
    '    Try
    '        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
    '        GridView2.VirtualItemCount = MainBLL.TotalRowInGridviewBYID("PaymentTotalNumberOfRecord", MainID)
    '        If (GridView2.VirtualItemCount = 0) Then
    '            lblpayment.Text = "No Payments"
    '        Else
    '            lblpayment.Text = "Payments (" + GridView2.VirtualItemCount.ToString + ")"
    '        End If
    '        GridView2.DataSource = MainBLL.FillGridViewById("0", 10, MainID, "PaymentGridview")
    '        GridView2.DataBind()
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub

    'Protected Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
    '    Try
    '        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
    '        GridView2.PageIndex = e.NewPageIndex
    '        GridView2.DataSource = MainBLL.FillGridViewById(e.NewPageIndex, 10, MainID, "PaymentGridview")
    '        GridView2.DataBind()
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub
    ''payment

    'Protected Sub GridView2_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView2.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        Dim lblinfo As Literal = DirectCast(e.Row.FindControl("lblinfo"), Literal)
    '        If String.IsNullOrEmpty(lblinfo.Text.Trim) Then
    '            lblinfo.Text = "-"
    '        End If
    '    End If
    'End Sub

    'Public Sub FillCount()
    '    Try
    '        Dim ds As DataSet = VendorBLL.Accview(MainID)
    '        If ds.Tables.Count > 0 Then
    '            lblorderamount.Text = Convert.ToDouble(Convert.ToString(ds.Tables(0).Rows(0)(1))).ToString("#,##0.00")
    '            lblordercount.Text = Convert.ToString(ds.Tables(0).Rows(0)(0))
    '            lblinvtotal.Text = Convert.ToDouble(Convert.ToString(ds.Tables(1).Rows(0)(1))).ToString("#,##0.00")
    '            lblinvoicecount.Text = Convert.ToString(ds.Tables(1).Rows(0)(0))
    '            lblpaytotal.Text = Convert.ToDouble(Convert.ToString(ds.Tables(2).Rows(0)(1))).ToString("#,##0.00")
    '            lblpaycount.Text = Convert.ToString(ds.Tables(2).Rows(0)(0))
    '            lblbalpay.Text = Convert.ToDouble(Convert.ToString(ds.Tables(3).Rows(0)(0))).ToString("#,##0.00")
    '        End If
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert("Index.aspx", "FillIndexCount", error1, Session("UserId"))
    '        Throw ex
    '    End Try
    'End Sub

    Public Sub fillUser()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            GridView1.DataSource = RawmaterialBLL.ViewRawmaterial(MainID)
            GridView1.DataBind()
            'grditemproduct.DataSource = RawmaterialBLL.ViewSaveRawmaterial(MainID)
            'grditemproduct.DataBind()
            gridviewcontact.DataSource = MainBLL.FillGridViewById(0, 10, MainID, "VendorWiseContactGridview")
            gridviewcontact.DataBind()
            Dim totalcount As Integer = gridviewcontact.Rows.Count
            If totalcount > 0 Then
                lblitemdt.Text = "Contact (" + totalcount.ToString + ")"
            Else
                lblitemdt.Text = "No Contact"
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ItemDetailControl", "fillUser", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillPrinciple()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            gridview2.DataSource = MainBLL.FillGridViewById(0, 10, MainID, "VendorWisePrincipleGridview")
            gridview2.DataBind()
            Dim totalcount As Integer = gridview2.Rows.Count
            If totalcount > 0 Then
                lblprinciple.Text = "Principle (" + totalcount.ToString + ")"
            Else
                lblprinciple.Text = "No Principle"
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ItemDetailControl", "fillUser", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillSearch()
        Try
            GridView1.DataSource = RawmaterialBLL.SearchRawmaterial(MainID, txtsearch.Text.Trim)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ItemDetailControl", "FillSearch", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    'Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
    '    Try
    '        If txtsearch.Text = "" Then
    '            GridView1.PageIndex = e.NewPageIndex
    '            GridView1.DataSource = MainBLL.ViewByID(MainID, "ViewItemDetail")
    '            GridView1.DataBind()
    '            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
    '        Else
    '            GridView1.PageIndex = e.NewPageIndex
    '            FillSearch()
    '            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
    '        End If
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert("ItemDetailControl", "GridView1_PageIndexChanging", error1, Session("UserId"))
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Count = MainBLL.GetCode("MaxVenProd")
            Dim sb As New StringBuilder
            sb.Append("<root>")
            For i As Integer = 0 To GridView1.Rows.Count - 1
                Dim index As Integer = GridView1.Rows(i).RowIndex
                Dim ckselect As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckselect"), CheckBox)
                If ckselect.Checked = True Then
                    Dim lblProductId As Literal = DirectCast(GridView1.Rows(i).FindControl("lblProductId"), Literal)

                    sb.Append("<row VP_ID='" & Count.ToString & "' VP_RawId='" & lblProductId.Text &
                          "' VP_VenId='" & MainID & "' VP_CreatedDate='" & Date.Now.ToString("yyyy-MM-dd hh:mm:ss") &
                          "' VP_CreatedId='" & Session("UserId") & "'  />")
                    Count = Count + 1
                End If
            Next
            sb.Append("</root>")
            VendorBLL.XMLInsert(sb.ToString)
            mpe.Hide()
            fillUser()
            FillPrinciple()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ItemDetailControl", "btnsave_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
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

    Protected Sub btnshowall_Click(sender As Object, e As EventArgs) Handles btnshowall.Click
        txtsearch.Text = ""
        GridView1.DataSource = RawmaterialBLL.ViewRawmaterial(MainID)
        GridView1.DataBind()
    End Sub

    'Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grditemproduct.RowCommand
    '    If e.CommandName = "deletelink" Then
    '        Try
    '            Dim btn As LinkButton = TryCast(e.CommandSource, LinkButton)
    '            Dim row As GridViewRow = TryCast(btn.NamingContainer, GridViewRow)
    '            Dim ltitemid As Literal = TryCast(row.FindControl("ltitemid"), Literal)
    '            RawmaterialBLL.Delete(ltitemid.Text)
    '            fillUser()
    '        Catch ex As Exception
    '            Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '            error1 = error1.Replace(Chr(39), "")
    '            ExecptionBLL.Insert("ItemDetailControl", "deletelink", error1, Session("UserId"))
    '            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '        End Try
    '    ElseIf e.CommandName = "Editlink" Then
    '        Dim btn As LinkButton = TryCast(e.CommandSource, LinkButton)
    '        Dim row As GridViewRow = TryCast(btn.NamingContainer, GridViewRow)
    '        Dim lnkedit As LinkButton = TryCast(row.FindControl("lnkedit"), LinkButton)
    '        Dim lkupdate As LinkButton = TryCast(row.FindControl("lkupdate"), LinkButton)
    '        Dim lnkdelete As LinkButton = TryCast(row.FindControl("lnkdelete"), LinkButton)
    '        Dim txtquantity As TextBox = TryCast(row.FindControl("txtquantity"), TextBox)
    '        Dim ltquantity As Literal = TryCast(row.FindControl("ltquantity"), Literal)
    '        ltquantity.Visible = False
    '        txtquantity.Visible = True
    '        lkupdate.Visible = True
    '        lnkdelete.Visible = False
    '        lnkedit.Text = "Cancel"
    '        lnkedit.CommandName = "Cancellink"
    '        lnkedit.CssClass = "btn btn-xs btn-warning"
    '    ElseIf e.CommandName = "Cancellink" Then
    '        Dim btn As LinkButton = TryCast(e.CommandSource, LinkButton)
    '        Dim row As GridViewRow = TryCast(btn.NamingContainer, GridViewRow)
    '        Dim lnkedit As LinkButton = TryCast(row.FindControl("lnkedit"), LinkButton)
    '        Dim lkupdate As LinkButton = TryCast(row.FindControl("lkupdate"), LinkButton)
    '        Dim lnkdelete As LinkButton = TryCast(row.FindControl("lnkdelete"), LinkButton)
    '        Dim txtquantity As TextBox = TryCast(row.FindControl("txtquantity"), TextBox)
    '        Dim ltquantity As Literal = TryCast(row.FindControl("ltquantity"), Literal)
    '        ltquantity.Visible = True
    '        txtquantity.Visible = False
    '        lkupdate.Visible = False
    '        lnkdelete.Visible = True
    '        lnkedit.Text = "Edit"
    '        lnkedit.CommandName = "Editlink"
    '        lnkedit.CssClass = "btn btn-primary"
    '    ElseIf e.CommandName = "updatelink" Then
    '        Dim btn As LinkButton = TryCast(e.CommandSource, LinkButton)
    '        Dim row As GridViewRow = TryCast(btn.NamingContainer, GridViewRow)
    '        Dim txtquantity As TextBox = TryCast(row.FindControl("txtquantity"), TextBox)
    '        Dim lnkedit As LinkButton = TryCast(row.FindControl("lnkedit"), LinkButton)
    '        Dim lkupdate As LinkButton = TryCast(row.FindControl("lkupdate"), LinkButton)
    '        Dim lnkdelete As LinkButton = TryCast(row.FindControl("lnkdelete"), LinkButton)
    '        Dim ltquantity As Literal = TryCast(row.FindControl("ltquantity"), Literal)
    '        Dim ltitemid As Literal = TryCast(row.FindControl("ltitemid"), Literal)
    '        RawmaterialBLL.UpdatevenProd(txtquantity.Text, ltitemid.Text)
    '        ltquantity.Text = txtquantity.Text
    '        ltquantity.Visible = True
    '        txtquantity.Visible = False
    '        lkupdate.Visible = False
    '        lnkdelete.Visible = True
    '        lnkedit.Text = "Edit"
    '        lnkedit.CommandName = "Editlink"
    '        lnkedit.CssClass = "btn btn-primary"
    '    End If
    'End Sub
End Class
