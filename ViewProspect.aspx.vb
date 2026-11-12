
Partial Class ViewProspect
    Inherits System.Web.UI.Page
    Dim MainID As Integer
    'Dim countrydt As DataTable
    Dim statedt As DataTable
    Dim strvat As New List(Of String)
    Dim countrate As Double = 0.0
    Dim countrate1 As Double = 0.0
    Dim ds1 As New DataSet()
    Private dt1 As New DataTable()

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            If (Request.QueryString("Id") = Nothing) Then
                Response.Redirect("index.aspx")
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewProspect", "Page_Init", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                CheckPrivi()
                Session("OrderProduct") = Nothing
                Me.txtsearch.Attributes.Add("onkeyup", String.Format("javascript:__doPostBack('{0}','')", Me.UpdatePanel2.ClientID))
                privilage()
                aedit.HRef = Page.ResolveUrl("ModifyProspect.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())) + "&returnurl=y")
                FillViewSample()
                FillDetail()
                aprint.HRef = Page.ResolveUrl("PrintDocs.aspx?tpy=Price&type=" + HttpUtility.UrlEncode(Security.Encrypt((ltcontactname.Text).ToString())) + "&Id=" + HttpUtility.UrlEncode(Security.Encrypt((MainID).ToString())))
                FillBillingAddressDetail()
                Fillsamplereq()
                lnkAddComplaint.PostBackUrl = Page.ResolveUrl("ModifyCustomerComplaint.aspx?&Id=" + HttpUtility.UrlEncode(Security.Encrypt((0).ToString())) + "&type=P&typeId=" + HttpUtility.UrlEncode(Security.Encrypt((MainID).ToString())))
                FillComplaint()
                fillCase()
                fillDSR()
                fillCRMFeedback()
                activitycontrol.Uhftype.Value = "Prospect"
                activitycontrol.Uhftypeid.Value = MainID
                documentcontrol.Uhftype.Value = "Prospect"
                documentcontrol.Uhftypeid.Value = MainID
                notecontrol.Uhftype.Value = "Prospect"
                notecontrol.Uhftypeid.Value = MainID
                contactcontrol.Uhftype.Value = "Prospect"
                contactcontrol.Uhftypeid.Value = MainID
                oportunitycontrol.Uhftype.Value = "Prospect"
                oportunitycontrol.Uhftypeid.Value = MainID
                emailcontrol.Uhftype.Value = "Prospect"
                emailcontrol.Uhftypeid.Value = MainID
                quotationcontrol.Uhftype.Value = "Prospect"
                quotationcontrol.Uhftypeid.Value = MainID
                If Session("UserRoleID") = "4" Then
                    quotationcontrol.Visible = False
                End If
            Else
                Dim target As String = Me.Request.Form("__EVENTTARGET")
                If Not String.IsNullOrEmpty(target) AndAlso target.Equals(Me.UpdatePanel2.ClientID) Then
                    If Not String.IsNullOrEmpty(Me.txtsearch.Text) Then
                        FillSearch()
                    Else
                        FillProductGrid()
                    End If
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewProspect", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
        'FillDetail()
        'upquickaction.Update()
    End Sub

    Protected Sub lkquicktask_Click(sender As Object, e As EventArgs) Handles lkquicktask.Click
        Try
            activitycontrol.dateTimeFuntion()
            activitycontrol.Utask.Show()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewProspect", "lkquicktask_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub lkquickevent_Click(sender As Object, e As EventArgs) Handles lkquickevent.Click
        Try
            activitycontrol.dateTimeFuntion()
            activitycontrol.UtaskEvent.Show()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewProspect", "lkquickevent_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub lkquickcall_Click(sender As Object, e As EventArgs) Handles lkquickcall.Click
        Try
            activitycontrol.dateTimeFuntion()
            activitycontrol.UtaskCall.Show()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewProspect", "lkquickcall_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "ViewProspectByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            ltleaddate.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Email").ToString())
            ltcontactname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
            ltcompanyname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString())
            ltmobile.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Mobile").ToString())
            ltphone.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Landline").ToString())
			Lblbank.Text = DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(1).Rows(0)("BankName").ToString())
            rpowner.DataSource = AssignToBLL.FillAssignTo("prospect", MainID)
            rpowner.DataBind()
            dt = Nothing
            dt = ActivityBLL.FillTaskType("prospect", MainID, "CountActivity")
            dtUser = dt.Tables(0)
            drLogin = dtUser.Rows(0)
            ltcounttask.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Task").ToString())
            ltcountevent.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Evented").ToString())
            ltcountcall.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Calls").ToString())
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewProspect", "FillDetail", error1, Session("UserId"))
            Response.Redirect("Index.aspx")
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub


    Public Sub privilage()
        Try
            Dim dt As DataSet = PrivilageBLL.CheckPrivilige(Session("UserRoleID"), "Prospect.aspx")
            Dim dtprivilage As New DataTable
            dtprivilage = dt.Tables(0)
            Dim drprivilage As DataRow
            If dtprivilage.Rows.Count = 0 Then
                aedit.Visible = False
                lkdelete.Visible = False
                lkconvacount.Visible = False
            Else
                drprivilage = dtprivilage.Rows(0)
                If (drprivilage("Prvg_RUpdate").ToString()) = True Then
                    aedit.Visible = True
                    lkconvacount.Visible = True
                Else
                    aedit.Visible = False
                    lkconvacount.Visible = False
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
            ExecptionBLL.Insert("ViewProspect", "privilage", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub lkconvacount_Click(sender As Object, e As EventArgs) Handles lkconvacount.Click
        Try
            'Response.Redirect("CommingSoon.aspx")
            'If deletestatus.Value = "yes" Then
            '    MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            '    AccountBLL.ConvertAccount(MainID)
            '    Response.Redirect(Page.ResolveUrl("ViewAccount.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString()))))
            'End If
            mpclose.Show()



        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewProspect", "lkconvacount_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub lkdelete_Click(sender As Object, e As EventArgs) Handles lkdelete.Click
        Try
            'MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            'If deletestatus.Value = "yes" Then
            '    'MainBLL.DeleteSI(MainID, Session("UserId"), "LeadDeleteSi", Session("Audlog_Id"))
            '    Response.Redirect("Prospect.aspx")
            'Else
            'End If
            mpclose.Show()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewProspect", "lkdelete_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btncloseyes_Click(sender As Object, e As EventArgs) Handles btncloseyes.Click
        Try
           MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            AccountBLL.ConvertAccount(MainID)
            AccountBLL.UpdateReason(MainID, txtremark.Text.Trim)
            Response.Redirect(Page.ResolveUrl("ViewAccount.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString()))))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewProspect", "lkconvacount_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btclosenno_Click(sender As Object, e As EventArgs) Handles btclosenno.Click
        mpclose.Hide()
    End Sub

    Public Sub FillBillingAddressDetail()
        Try
            'countrydt = MainBLL.Dropdown("CountryDropDown").Tables(0)
            statedt = MainBLL.Dropdown("ALLStateDropDown").Tables(0)
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "ProspectBillingAddressViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                lbladdress.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Name").ToString())
                'lbladdress.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Email").ToString())
                'lbladdress.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Telephone").ToString())
                lbladdress.Text += " " + DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Address").ToString())
                lbladdress.Text += " " + DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_City").ToString())
                Dim state As Array = statedt.Select("ID = '" + drLogin("AccAddr_State").ToString() + "'")
                If state.Length <> 0 Then
                    lbladdress.Text += " " + state(0)(1).ToString
                End If
                lbladdress.Text += " " + DynamicparcelDataManipulation.FixNullFromDB(drLogin("AccAddr_Pincode").ToString())
                'Dim country As Array = countrydt.Select("ID = '" + drLogin("AccAddr_Country").ToString() + "'")
                'If country.Length <> 0 Then
                '    lbladdress.Text += " " + country(0)(1).ToString + " "
                'End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyAccount", "FillBillingAddressDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub




    ''' <summary>
    ''' sufiyan
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>






    Protected Sub btnopen_Click(sender As Object, e As EventArgs) Handles btnopen.Click
        Try
            btnsave.Enabled = True
            btnsave.Text = "Save"
            mpe.Show()
            FillProductGrid()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifySalesOrder", "btnopen_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    '<WebMethod()> _
    'Public Shared Function GetCustomers(pageIndex As Integer) As DataSet
    '    Dim ds As DataSet = ProductBLL.CRMProductViewAll(pageIndex)
    '    Return ds
    'End Function


    Public Sub FillProductGrid()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If Session("OrderProduct") IsNot Nothing Then
                Dim dt As DataTable = DirectCast(Session("OrderProduct"), DataTable)
                If dt.Rows.Count > 0 Then
                    For Each row As DataRow In dt.Rows
                        Dim a As String = ""
                        strvat.Add(row("ProductId").ToString)

                    Next
                End If
            End If


            '  ViewState("Fillproduct") = ItemDetailBLL.ViewItemDetail(MainID).Tables(0)
            ViewState("Fillproduct") = SampleBLL.ViewItemDetail(MainID).Tables(0)
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
            '  GridView1.DataSource = ProductBLL.SearchCRMProduct(MainID, txtsearch.Text.Trim)
            GridView1.DataSource = SampleBLL.SearchGridViewByID(txtsearch.Text.Trim, MainID, "SearchSampleProduct").Tables(0)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifySalesOrder", "FillSearch", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub txtOrderQty_TextChanged(sender As Object, e As EventArgs)
        Try
            Dim rd As TextBox = DirectCast(sender, TextBox)
            Dim row As GridViewRow = DirectCast(rd.NamingContainer, GridViewRow)
            Dim txtOrderQty As TextBox = TryCast(row.FindControl("txtOrderQty"), TextBox)
            Dim ltrate As Label = TryCast(row.FindControl("lblrate"), Label)
            Dim ltproductWeight As Label = TryCast(row.FindControl("ltproductWeight"), Label)
            Dim ltkg As Label = TryCast(row.FindControl("lblkgs"), Label)
            Dim ltamount As Label = TryCast(row.FindControl("lbltotalamount1"), Label)
            Dim lblvat As Label = TryCast(row.FindControl("lblvat"), Label)
            Dim lbldiscount As Label = TryCast(row.FindControl("lbldiscount"), Label)
            If txtOrderQty.Text = "" Then
                txtOrderQty.Text = 1
            End If
            If txtOrderQty.Text.Contains(".") Then
                txtOrderQty.Text = Math.Floor(CDbl(txtOrderQty.Text))
            End If
            If lbldiscount.Text = "" Then
            Else
                countrate = lbldiscount.Text / 100
                countrate1 = ltrate.Text * countrate
                ltrate.Text = ltrate.Text - countrate1
            End If
            ltkg.Text = ltproductWeight.Text * txtOrderQty.Text
            ltamount.Text = (ltkg.Text * ltrate.Text).ToString("N2")
            ltrate.Text = CDbl(ltrate.Text).ToString("N2")
            Dim VAT As Double = Convert.ToDouble((lblvat.Text * ltamount.Text) / 100)
            ltamount.Text = (ltamount.Text + VAT).ToString("N2")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifySalesOrder", "txtOrderQty_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub txt_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        addproduct("SaveClose")
    End Sub
    Public Sub addproduct(ByVal flag As String)
        Try
            Dim count As Integer
            If Session("OrderProduct") Is Nothing Then
                count = 0
                Dim dt As New DataTable
                dt.Columns.Add("ItemDt_ID", GetType(Integer))
                dt.Columns.Add("ProductId", GetType(Integer))
                dt.Columns.Add("Product_Name", GetType(String))
                dt.Columns.Add("Product_Code", GetType(String))
               

                For Each row As GridViewRow In GridView1.Rows
                    Dim txtOrderQty = DirectCast(row.FindControl("txtOrderQty"), TextBox)
                    Dim lblproductId = DirectCast(row.FindControl("lblproductId"), Label)
                    Dim lblname = DirectCast(row.FindControl("lblname"), Label)
                    Dim lblcode = DirectCast(row.FindControl("lblcode"), Label)
                   
                    Dim ckselect = DirectCast(row.FindControl("ckselect"), CheckBox)
                    'Dim hfdiscountrate = DirectCast(row.FindControl("hfdiscountrate"), HiddenField)
                    'Dim lbldiscount = DirectCast(row.FindControl("lbldiscount"), Label)
                    'Dim SKUcost As Double = 0.0
                    If ckselect.Checked = True Then
                      
                        dt.Rows.Add(count, lblproductId.Text, lblname.Text, lblcode.Text)
                        count = count + 1
                        'End If
                    End If
                Next
                Session("OrderProduct") = dt
            Else
                Dim dt As DataTable = DirectCast(Session("OrderProduct"), DataTable)
                count = dt.Rows.Count
                For Each row As GridViewRow In GridView1.Rows
                    Dim txtOrderQty = DirectCast(row.FindControl("txtOrderQty"), TextBox)
                    Dim lblproductId = DirectCast(row.FindControl("lblproductId"), Label)
                    Dim lblname = DirectCast(row.FindControl("lblname"), Label)
                    Dim lblcode = DirectCast(row.FindControl("lblcode"), Label)
                 
                    Dim ckselect = DirectCast(row.FindControl("ckselect"), CheckBox)
                    'Dim hfdiscountrate = DirectCast(row.FindControl("hfdiscountrate"), HiddenField)
                    'Dim lbldiscount = DirectCast(row.FindControl("lbldiscount"), Label)
                    If ckselect.Checked = True Then
                        
                        dt.Rows.Add(count, lblproductId.Text, lblname.Text, lblcode.Text)
                        count = count + 1
                        'End If
                    End If
                Next
                Session("OrderProduct") = dt
            End If
            FillMainProduct()
            If flag = "Save" Then
                FillProductGrid()
            Else

                mpe.Hide()
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("UserId")) 'ExpenseReportByName", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
        End Try
    End Sub

    Public Sub FillViewSample()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim ds As DataSet
            ds = SampleBLL.ViewByID(MainID, "SampleViewProduct", "Prospect")
            If ds.Tables(0).Rows.Count > 0 Then

                Session("OrderProduct") = ds.Tables(0)


            End If
            ds = SampleBLL.ViewByID(MainID, "SampleViewProductLink", "Prospect")
            If ds.Tables(0).Rows.Count > 0 Then

                txtOtherPI.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(0)("Acc_Description"))

            End If
            FillMainProduct()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifySalesOrder", "FillMainProduct", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub FillMainProduct()
        Try
            Dim sb As New StringBuilder
            Dim amount As Double = 0
            If Session("OrderProduct") IsNot Nothing Then
                Dim dt As DataTable = DirectCast(Session("OrderProduct"), DataTable)
                'lblSample.Text = "Sample (" + dt.Rows.Count + ")"
                ' If dt.Rows.Count > 0 Then
                grditemproduct.DataSource = Session("OrderProduct")
                grditemproduct.DataBind()
                If Session("UserRoleID") = "4" Then
                    grditemproduct.Columns(2).Visible = False
                End If
            Else
                ' lblSample.Text = "No Sample"
            End If
            If grditemproduct.Rows.Count > 0 Or txtOtherPI.Text <> "" Then
                lblSample.Text = "Interested Products"
            Else
                lblSample.Text = "Interest Not Specified"

            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifySalesOrder", "FillMainProduct", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

   


    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grditemproduct.RowCommand
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
                ExecptionBLL.Insert("ModifySalesOrder", "deletelink", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        
        End If
    End Sub

  

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If grditemproduct.Rows.Count > 0 Then
              MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                SampleBLL.DeleteProductLinkCrm(MainID, "Prospect")
                SampleBLL.UpdateDesc("UpdateLeadDesc", MainID, txtOtherPI.Text, "Prospect", Session("UserId"))
                For i As Integer = 0 To grditemproduct.Rows.Count - 1
                    '  Dim index As Integer = grditemproduct.Rows(i).RowIndex
                    Dim ltproductid As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltproductid"), Label)
                    SampleBLL.InsertProductLinkCrm(MainID, "Prospect", ltproductid.Text, Session("UserId"))
                Next

            Else
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Select Atleast One Product')", True)
                btnopen_Click(Nothing, Nothing)
                'aToggle.Attributes.Add("Class", "accordion-toggle")
                faq8561_q12.Attributes.Add("Class", "panel-collapse collapse in")
                faq8561_q12.Attributes.Add("style", " ")
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewProspect", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillComplaint()   '======Added By MUBYN 13-07-2018
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            gvComplaint.VirtualItemCount = MainBLL.TotalRowInGridviewBYID("SolutionTotalNumberOfRecordByID", MainID)
            If (gvComplaint.VirtualItemCount = 0) Then
                lblSolution.Text = "No Complaints"
            Else
                lblSolution.Text = "Complaints (" + gvComplaint.VirtualItemCount.ToString + ")"
            End If
            gvComplaint.DataSource = MainBLL.FillGridViewById("0", 10, MainID, "SolutionGridviewByID")
            gvComplaint.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub gvComplaint_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvComplaint.PageIndexChanging '======Added By MUBYN 13-07-2018
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            gvComplaint.PageIndex = e.NewPageIndex
            gvComplaint.DataSource = MainBLL.FillGridViewById(e.NewPageIndex, 10, MainID, "SolutionGridviewByID")
            gvComplaint.DataBind()
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillCase()    '======Added By MUBYN 13-07-2018
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            gvCase.VirtualItemCount = MainBLL.TotalRowInGridviewBYID("ComplaintTotNoOfRecByID", MainID)
            If (gvCase.VirtualItemCount = 0) Then
                lblCase.Text = "No Case"
            Else
                lblCase.Text = "Cases (" + gvCase.VirtualItemCount.ToString + ")"
            End If
            gvCase.DataSource = MainBLL.FillGridViewById("0", 10, MainID, "CustComplaintGridviewByID")
            gvCase.DataBind()
            'If Session("UserRoleID") = "4" Then
            '    gvCase.Columns(6).Visible = False
            '    gvCase.Columns(7).Visible = False
            'End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub gvCase_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvCase.PageIndexChanging '======Added By MUBYN 13-07-2018
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            gvCase.PageIndex = e.NewPageIndex
            gvCase.DataSource = MainBLL.FillGridViewById(e.NewPageIndex, 10, MainID, "CustComplaintGridviewByID")
            gvCase.DataBind()
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    'Protected Sub gvCase_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvCase.RowDataBound '======Added By MUBYN 13-07-2018
    '    Try
    '        For Each row As GridViewRow In gvCase.Rows
    '            Dim ltchkmark = DirectCast(row.FindControl("ltchkmark"), Literal)
    '            Dim hledit As HyperLink = CType(row.FindControl("hledit"), HyperLink)
    '            'Dim lnkdelete = DirectCast(row.FindControl("lnkdelete"), LinkButton)

    '            Dim ltaction = DirectCast(row.FindControl("ltaction"), Literal)
    '            Dim ltprevent = DirectCast(row.FindControl("ltprevent"), Literal)
    '            Dim ltextrnal = DirectCast(row.FindControl("ltextrnal"), Literal)
    '            Dim ltinternal = DirectCast(row.FindControl("ltinternal"), Literal)
    '            Dim ltfeedback = DirectCast(row.FindControl("ltfeedback"), Literal)
    '            Dim lkstatus = DirectCast(row.FindControl("lkstatus"), Label)

    '            If ltchkmark.Text = "True" Then
    '                hledit.Visible = False
    '                'lnkdelete.Visible = False
    '            Else
    '                hledit.Visible = True
    '                'lnkdelete.Visible = True
    '            End If
    '            If ltextrnal.Text = "" And ltinternal.Text = "" And ltaction.Text = "" And ltprevent.Text = "" And ltfeedback.Text = "" Then
    '                lkstatus.Text = "Pending"
    '            ElseIf ltextrnal.Text = "" Or ltinternal.Text = "" Or ltaction.Text = "" Or ltprevent.Text = "" Or ltfeedback.Text = "" Then
    '                lkstatus.Text = "In Process"
    '            ElseIf ltextrnal.Text <> "" And ltinternal.Text <> "" And ltaction.Text <> "" And ltprevent.Text <> "" And ltfeedback.Text <> "" Then
    '                lkstatus.Text = "Complete"
    '            End If
    '        Next
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub
 


    Public Sub fillDSR()    '======Added By MUBYN 13-07-2018
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            gvDSR.VirtualItemCount = MainBLL.TotalRowInGridviewBYID("DSRActivityTotNoOfRecByID", MainID)
            If (gvDSR.VirtualItemCount = 0) Then
                lblDSR.Text = "No DSR"
            Else
                lblDSR.Text = "DSR (" + gvDSR.VirtualItemCount.ToString + ")"
            End If
            gvDSR.DataSource = MainBLL.FillGridViewById("0", 10, MainID, "DSRActivityGridviewByID")
            gvDSR.DataBind()
            If Session("UserRoleID") = "4" Then
                ' gvDSR.Columns(7).Visible = False
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub gvDSR_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvDSR.RowCommand
        Try
            If e.CommandName = "Viewing" Then
                Dim ID As Integer = 0
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Dim row As GridViewRow = gvDSR.Rows(index)
                Dim ltrelatedtype As Literal = DirectCast(row.FindControl("ltrelatedtype"), Literal)
                Dim ltrelatedtypeid As Literal = DirectCast(row.FindControl("ltrelatedtypeid"), Literal)
                ID = gvDSR.DataKeys(index).Value
                'lvnote.DataSource = NoteBLL.NoteActivWithAssReverse(Session("UserId"), ID)
                'lvnote.DataBind()
                grdactivityhistory.DataSource = MainBLL.ViewByID(ID, "ActivityHistory")
                grdactivityhistory.DataBind()
                hfmainactivityid.Value = ID
                hfreltypeId.Value = ltrelatedtypeid.Text
                hfreltype.Value = ltrelatedtype.Text
                Dim dt As DataSet
                If hfreltype.Value = "Account" Or hfreltype.Value = "Prospect" Then
                    dt = NoteBLL.RecentActivity(ID, hfreltype.Value, hfreltypeId.Value)
                    trcontact.Visible = True
                    Dim dtUser As New DataTable
                    dtUser = dt.Tables(0)
                    Dim drLogin As DataRow
                    drLogin = dtUser.Rows(0)
                    lblAccName.Text = hfreltype.Value + " Name"
                    lblsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                    ltstartdate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                    ltenddate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                    ltAccName.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
                    ltpriority.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                    ltowner.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                    If ltpriority.Text = "High" Then
                        ltpriority.CssClass = "label label-success"
                    ElseIf ltpriority.Text = "Highest" Then
                        ltpriority.CssClass = "label label-success"
                    ElseIf ltpriority.Text = "Lowest" Then
                        ltpriority.CssClass = "label label-danger"
                    ElseIf ltpriority.Text = "Low" Then
                        ltpriority.CssClass = "label label-warning"
                    ElseIf ltpriority.Text = "Normal" Then
                        ltpriority.CssClass = "label label-info"
                    End If
                    ltstatus.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                    If ltstatus.Text = "Close" Then
                        ltstatus.CssClass = "label label-success"
                    ElseIf ltstatus.Text = "Close Postpone" Then
                        ltstatus.CssClass = "label label-info"
                    ElseIf ltstatus.Text = "Pending" Or ltstatus.Text = "Due" Then
                        ltstatus.CssClass = "label label-warning"
                    ElseIf ltstatus.Text = "Today" Then
                        ltstatus.CssClass = "label label-success"
                    ElseIf (ltstatus.Text = "Missed") Then
                        ltstatus.CssClass = "label label-danger"
                    ElseIf (ltstatus.Text = "Tommorrow") Then
                        ltstatus.CssClass = "label label-info"
                    End If
                    ltdesc.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                    ltresult.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                    ltcontact.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("ContactName").ToString())
                    'lblconatctd.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString())
                    hffollowactivityid.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Id").ToString())

                End If
                mpefollowup.Show()
                fillDSR()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub gvDSR_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvDSR.PageIndexChanging '======Added By MUBYN 16-07-2018
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            gvDSR.PageIndex = e.NewPageIndex
            gvDSR.DataSource = MainBLL.FillGridViewById(e.NewPageIndex, 10, MainID, "DSRActivityGridviewByID")
            gvDSR.DataBind()
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub CheckPrivi()
        Try
            Dim ds As DataSet = UserBLL.CheckPrivi(Session("UserRoleID"), "Prospect.aspx")
            Dim strArr() As String
            Dim TemStr As String = ""
            Dim dtPrivi As New DataTable
            dtPrivi = Session("dtPrivilege")
            Dim rows() As DataRow = dtPrivi.Select("Menu_URL = 'Prospect.aspx'")

            TemStr = rows(0).Item("Val").ToString()
            strArr = TemStr.Split(",")
            If (strArr.Length > 3) Then
                If MainID = 0 Then
                    If strArr(2) = "1" Then
                    Else
                        If Not Session("UserRoleID") = "4" Then
                            Response.Redirect("index.aspx")
                        Else
                            Response.Redirect("SupportDashBoard.aspx")
                        End If
                    End If
                Else
                    'If strArr(1) = "1" Or strArr(2) = "1" Or strArr(3) = "1" Then
                    If strArr(2) = "1" Then
                    Else
                        If Not Session("UserRoleID") = "4" Then
                            Response.Redirect("index.aspx")
                        Else
                            Response.Redirect("SupportDashBoard.aspx")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Fillsamplereq()
        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        grdsamplereq.DataSource = MainBLL.ViewByIDs(Session("UserId"), MainID, "ProspectSampleReqViewByID")
        grdsamplereq.DataBind()
        Dim DS As DataSet = DirectCast(grdsamplereq.DataSource, DataSet)
        Dim totalcount As Integer = DS.Tables(0).Rows.Count
        If totalcount > 0 Then
            lblsamplereq.Text = "Sample Request (" + totalcount.ToString + ")"
        Else
            lblsamplereq.Text = "No Sample Request"
        End If
    End Sub

    Protected Sub grdsamplereq_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdsamplereq.PageIndexChanging
        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        grdsamplereq.PageIndex = e.NewPageIndex
        grdsamplereq.DataSource = MainBLL.ViewByIDs(Session("UserId"), MainID, "ProspectSampleReqViewByID")
        grdsamplereq.DataBind()
    End Sub
    Protected Sub grdsamplereq_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdsamplereq.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lbldirect As System.Web.UI.WebControls.Label = DirectCast(e.Row.FindControl("lbldirect"), System.Web.UI.WebControls.Label)
            Dim lbldash As System.Web.UI.WebControls.Label = DirectCast(e.Row.FindControl("lbldash"), System.Web.UI.WebControls.Label)
            Dim HyperLink1 As System.Web.UI.WebControls.HyperLink = DirectCast(e.Row.FindControl("HyperLink1"), System.Web.UI.WebControls.HyperLink)
            Dim lblunit As System.Web.UI.WebControls.Label = DirectCast(e.Row.FindControl("lblunit"), System.Web.UI.WebControls.Label)

            If lbldirect.Text = "Direct" Then
                HyperLink1.Visible = False
                lbldirect.Visible = True
                lbldash.visible = False
            End If
            If lblunit.Text = "Rejected" Then
                HyperLink1.Visible = False
                lbldash.Visible = True
                lbldirect.Visible = False
            End If

        End If
    End Sub

#Region "CRm Feedback"
    Public Sub fillCRMFeedback()    '======Added By MUBYN 13-07-2018
        Try
            Dim CRMMainID As Integer
            CRMMainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim tempDate As Date = Date.Now.ToString("yyyy-MM-dd")
            Dim startOfMonth As New DateTime(tempDate.Year, tempDate.Month, 1)
            'Dim endOfMonth As DateTime = startOfMonth.AddMonths(1).AddDays(-1)
            startOfMonth = "2020-01-01"
            Dim endOfMonth As DateTime = Date.Now.ToString("yyyy-MM-dd")
            Dim txtfrom As String = startOfMonth.ToString("yyyy-MM-dd")
            Dim txtto As String = endOfMonth.ToString("yyyy-MM-dd")
            'ds1 = MainBLL.FillGridView(hfgridview.Value)
            'ds1 = FeedBackBLL.FillGridByID("FeedBackByValue", 0, CRMMainID, txtfrom, txtto)
            ds1 = FeedBackBLL.FillGridViewById("0", 10, CRMMainID, "FillGVFeedBackByValue", 0, CRMMainID, txtfrom, txtto)

            dt1 = ds1.Tables(0)
            If (dt1.Rows.Count > 0) Then
                lblCRMFeedback.Text = "CRM Feedback (" + dt1.Rows.Count.ToString + ")"
            Else
                lblCRMFeedback.Text = "No CRM Feedback"
            End If
            gvFeedBack.VirtualItemCount = dt1.Rows.Count
            gvFeedBack.DataSource = ds1             '           FeedBackBLL.FillGridViewById("0", 10, CRMMainID, "FillGVFeedBackByValue", 0, CRMMainID, txtfrom, txtto)
            gvFeedBack.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub gvFeedBack_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvFeedBack.RowCommand
        Try
            If e.CommandName = "Viewing" Then
                Dim ID As Integer = 0
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Dim row As GridViewRow = gvFeedBack.Rows(index)
                Dim ltrelatedtype As Literal = DirectCast(row.FindControl("ltrelatedtype"), Literal)
                Dim ltrelatedtypeid As Literal = DirectCast(row.FindControl("ltrelatedtypeid"), Literal)
                ID = gvFeedBack.DataKeys(index).Value
                'lvnote.DataSource = NoteBLL.NoteActivWithAssReverse(Session("UserId"), ID)
                'lvnote.DataBind()
                Dim lblRemark As Literal = DirectCast(row.FindControl("lblRemark"), Literal)
                Dim lblRating_TypeId As Literal = DirectCast(row.FindControl("lblRating_TypeId"), Literal)
                Dim lblRating_Listening As Literal = DirectCast(row.FindControl("lblRating_Listening"), Literal)
                Dim lblRating_Knowledge As Literal = DirectCast(row.FindControl("lblRating_Knowledge"), Literal)
                Dim lblRating_Understandability As Literal = DirectCast(row.FindControl("lblRating_Understandability"), Literal)

                lblMessage.Text = lblRemark.Text
                lblRating.Text = lblRating_TypeId.Text
                RatingListening.CurrentRating = lblRating_Listening.Text
                RatingKnowledge.CurrentRating = lblRating_Knowledge.Text
                RatingUnderstandability.CurrentRating = lblRating_Understandability.Text

                Dim lblActivityID As Literal = DirectCast(row.FindControl("lblActivityID"), Literal)
                'Dim ID As Integer = 0
                'Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                'Dim row As GridViewRow = GridView1.Rows(index)
                ''Dim lbluId As Literal = DirectCast(GridView1.Items(index).FindControl("lbluId"), Literal)
                Dim lblRelatedType As Literal = DirectCast(row.FindControl("lblRelatedType"), Literal)
                Dim lblRelatedTypeID As Literal = DirectCast(row.FindControl("lblRelatedTypeID"), Literal)
                ID = lblActivityID.Text ' index 'GridView1.DataKeys(index).Value
                'lvnote.DataSource = NoteBLL.NoteActivWithAssReverse(Session("UserId"), ID)
                'lvnote.DataBind()
                'grdactivityhistory.DataSource = MainBLL.ViewByID(ID, "ActivityHistory")
                'grdactivityhistory.DataBind()
                hfmainactivityidFeed.Value = ID
                hfreltypeIdFeed.Value = lblRelatedTypeID.Text
                hfreltypeFeed.Value = lblRelatedType.Text
                Dim dt As DataSet
                If hfreltypeFeed.Value = "Account" Or hfreltypeFeed.Value = "Prospect" Then
                    dt = NoteBLL.RecentActivity(ID, hfreltypeFeed.Value, hfreltypeIdFeed.Value)
                    trcontactFeed.Visible = True
                    Dim dtUser As New DataTable
                    dtUser = dt.Tables(0)
                    Dim drLogin As DataRow
                    drLogin = dtUser.Rows(0)
                    lblnameFeed.Text = hfreltypeFeed.Value + " Name"
                    lblsubjectFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                    ltstartdateFeed.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                    ltenddateFeed.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                    lblaccnameFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
                    ltpriorityFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                    ltownerFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                    If ltpriorityFeed.Text = "High" Then
                        ltpriorityFeed.CssClass = "label label-success"
                    ElseIf ltpriorityFeed.Text = "Highest" Then
                        ltpriorityFeed.CssClass = "label label-success"
                    ElseIf ltpriorityFeed.Text = "Lowest" Then
                        ltpriorityFeed.CssClass = "label label-danger"
                    ElseIf ltpriorityFeed.Text = "Low" Then
                        ltpriorityFeed.CssClass = "label label-warning"
                    ElseIf ltpriorityFeed.Text = "Normal" Then
                        ltpriorityFeed.CssClass = "label label-info"
                    End If
                    ltstatusFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                    If ltstatusFeed.Text = "Close" Then
                        ltstatusFeed.CssClass = "label label-success"
                    ElseIf ltstatusFeed.Text = "Close Postpone" Then
                        ltstatusFeed.CssClass = "label label-info"
                    ElseIf ltstatusFeed.Text = "Pending" Or ltstatusFeed.Text = "Due" Then
                        ltstatusFeed.CssClass = "label label-warning"
                    ElseIf ltstatusFeed.Text = "Today" Then
                        ltstatusFeed.CssClass = "label label-success"
                    ElseIf (ltstatusFeed.Text = "Missed") Then
                        ltstatusFeed.CssClass = "label label-danger"
                    ElseIf (ltstatusFeed.Text = "Tommorrow") Then
                        ltstatusFeed.CssClass = "label label-info"
                    End If
                    ltdescFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                    ltresultFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                    ltcontactFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("ContactName").ToString())
                    'lblconatctd.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString())
                    hffollowactivityidFeed.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Id").ToString())
                ElseIf hfreltypeFeed.Value = "Quotation" Then
                    dt = NoteBLL.ViewNoteQuotation(ID, hfreltypeIdFeed.Value)
                    Dim dtUser As New DataTable
                    dtUser = dt.Tables(0)
                    Dim drLogin As DataRow
                    drLogin = dtUser.Rows(0)
                    lblnameFeed.Text = "Quotation Name"
                    trcontactFeed.Visible = False
                    lblsubjectFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                    ltstartdateFeed.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                    ltenddateFeed.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                    ltpriorityFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                    ltownerFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                    If ltpriorityFeed.Text = "High" Then
                        ltpriorityFeed.CssClass = "label label-success"
                    ElseIf ltpriorityFeed.Text = "Highest" Then
                        ltpriorityFeed.CssClass = "label label-success"
                    ElseIf ltpriorityFeed.Text = "Lowest" Then
                        ltpriorityFeed.CssClass = "label label-danger"
                    ElseIf ltpriorityFeed.Text = "Low" Then
                        ltpriorityFeed.CssClass = "label label-warning"
                    ElseIf ltpriorityFeed.Text = "Normal" Then
                        ltpriorityFeed.CssClass = "label label-info"
                    End If
                    ltstatusFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                    If ltstatusFeed.Text = "Close" Then
                        ltstatusFeed.CssClass = "label label-success"
                    ElseIf ltstatusFeed.Text = "Close Postpone" Then
                        ltstatusFeed.CssClass = "label label-info"
                    ElseIf ltstatusFeed.Text = "Pending" Or ltstatusFeed.Text = "Due" Then
                        ltstatusFeed.CssClass = "label label-warning"
                    ElseIf ltstatusFeed.Text = "Today" Then
                        ltstatusFeed.CssClass = "label label-success"
                    ElseIf (ltstatusFeed.Text = "Missed") Then
                        ltstatusFeed.CssClass = "label label-danger"
                    ElseIf (ltstatusFeed.Text = "Tommorrow") Then
                        ltstatusFeed.CssClass = "label label-info"
                    End If
                    ltdescFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                    ltresultFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                    lblaccnameFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_No").ToString()) + "-" + DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
                    'lblconatctd.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString())
                    hffollowactivityidFeed.Value = ID
                ElseIf hfreltypeFeed.Value = "Opportunity" Then
                    dt = NoteBLL.ViewOpportunityByID(ID, hfreltypeIdFeed.Value)
                    Dim dtUser As New DataTable
                    dtUser = dt.Tables(0)
                    Dim drLogin As DataRow
                    drLogin = dtUser.Rows(0)
                    lblnameFeed.Text = "Opportunity Name"
                    lblaccnameFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity_Name").ToString()) + "-" + DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
                    trcontactFeed.Visible = True
                    lblsubjectFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                    ltstartdateFeed.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                    ltenddateFeed.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                    ltpriorityFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                    ltownerFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                    ltcontactFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("ContactName").ToString())
                    If ltpriorityFeed.Text = "High" Then
                        ltpriorityFeed.CssClass = "label label-success"
                    ElseIf ltpriorityFeed.Text = "Highest" Then
                        ltpriorityFeed.CssClass = "label label-success"
                    ElseIf ltpriorityFeed.Text = "Lowest" Then
                        ltpriorityFeed.CssClass = "label label-danger"
                    ElseIf ltpriorityFeed.Text = "Low" Then
                        ltpriorityFeed.CssClass = "label label-warning"
                    ElseIf ltpriorityFeed.Text = "Normal" Then
                        ltpriorityFeed.CssClass = "label label-info"
                    End If
                    ltstatusFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                    If ltstatusFeed.Text = "Close" Then
                        ltstatusFeed.CssClass = "label label-success"
                    ElseIf ltstatusFeed.Text = "Close Postpone" Then
                        ltstatusFeed.CssClass = "label label-info"
                    ElseIf ltstatusFeed.Text = "Pending" Then
                        ltstatusFeed.CssClass = "label label-warning"
                    ElseIf ltstatusFeed.Text = "Today" Then
                        ltstatusFeed.CssClass = "label label-success"
                    ElseIf (ltstatusFeed.Text = "Missed") Then
                        ltstatusFeed.CssClass = "label label-danger"
                    ElseIf (ltstatusFeed.Text = "Tommorrow") Then
                        ltstatusFeed.CssClass = "label label-info"
                    End If
                    ltdescFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                    ltresultFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                    hffollowactivityidFeed.Value = ID
                ElseIf hfreltypeFeed.Value = "Lead" Then
                    dt = NoteBLL.ViewLeadViewByID(ID, hfreltypeIdFeed.Value)
                    Dim dtUser As New DataTable
                    dtUser = dt.Tables(0)
                    Dim drLogin As DataRow
                    drLogin = dtUser.Rows(0)
                    lblnameFeed.Text = "Lead Name"
                    lblaccnameFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead_Name").ToString())
                    trcontactFeed.Visible = True
                    lblsubjectFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                    ltstartdateFeed.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                    ltenddateFeed.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                    ltpriorityFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                    ltownerFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                    ltcontactFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("ContactName").ToString())
                    If ltpriorityFeed.Text = "High" Then
                        ltpriorityFeed.CssClass = "label label-success"
                    ElseIf ltpriorityFeed.Text = "Highest" Then
                        ltpriorityFeed.CssClass = "label label-success"
                    ElseIf ltpriorityFeed.Text = "Lowest" Then
                        ltpriorityFeed.CssClass = "label label-danger"
                    ElseIf ltpriorityFeed.Text = "Low" Then
                        ltpriorityFeed.CssClass = "label label-warning"
                    ElseIf ltpriorityFeed.Text = "Normal" Then
                        ltpriorityFeed.CssClass = "label label-info"
                    End If
                    ltstatusFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                    If ltstatusFeed.Text = "Close" Then
                        ltstatusFeed.CssClass = "label label-success"
                    ElseIf ltstatusFeed.Text = "Close Postpone" Then
                        ltstatusFeed.CssClass = "label label-info"
                    ElseIf ltstatusFeed.Text = "Pending" Then
                        ltstatusFeed.CssClass = "label label-warning"
                    ElseIf ltstatusFeed.Text = "Today" Then
                        ltstatusFeed.CssClass = "label label-success"
                    ElseIf (ltstatusFeed.Text = "Missed") Then
                        ltstatusFeed.CssClass = "label label-danger"
                    ElseIf (ltstatusFeed.Text = "Tommorrow") Then
                        ltstatusFeed.CssClass = "label label-info"
                    End If
                    ltdescFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                    ltresultFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                    hffollowactivityidFeed.Value = ID
                ElseIf hfreltypeFeed.Value = "None" Then
                    dt = MainBLL.ViewByID(ID, "ActivityViewByID")
                    Dim dtUser As New DataTable
                    dtUser = dt.Tables(0)
                    Dim drLogin As DataRow
                    drLogin = dtUser.Rows(0)
                    lblnameFeed.Text = "Account Name"
                    lblaccnameFeed.Text = "None"
                    trcontactFeed.Visible = False
                    lblsubjectFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
                    ltstartdateFeed.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
                    ltenddateFeed.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
                    ltpriorityFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
                    If ltpriorityFeed.Text = "High" Then
                        ltpriorityFeed.CssClass = "label label-success"
                    ElseIf ltpriorityFeed.Text = "Highest" Then
                        ltpriorityFeed.CssClass = "label label-success"
                    ElseIf ltpriorityFeed.Text = "Lowest" Then
                        ltpriorityFeed.CssClass = "label label-danger"
                    ElseIf ltpriorityFeed.Text = "Low" Then
                        ltpriorityFeed.CssClass = "label label-warning"
                    ElseIf ltpriorityFeed.Text = "Normal" Then
                        ltpriorityFeed.CssClass = "label label-info"
                    End If
                    ltstatusFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
                    If ltstatusFeed.Text = "Close" Then
                        ltstatusFeed.CssClass = "label label-success"
                    ElseIf ltstatusFeed.Text = "Close Postpone" Then
                        ltstatusFeed.CssClass = "label label-info"
                    ElseIf ltstatusFeed.Text = "Pending" Or ltstatusFeed.Text = "Due" Then
                        ltstatusFeed.CssClass = "label label-warning"
                    ElseIf ltstatusFeed.Text = "Today" Then
                        ltstatusFeed.CssClass = "label label-success"
                    ElseIf (ltstatusFeed.Text = "Missed") Then
                        ltstatusFeed.CssClass = "label label-danger"
                    ElseIf (ltstatusFeed.Text = "Tommorrow") Then
                        ltstatusFeed.CssClass = "label label-info"
                    End If
                    ltdescFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
                    ltresultFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
                    ltownerFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                    hffollowactivityidFeed.Value = ID
                End If
                mpeFeed.Show()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub gvFeedBack_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvFeedBack.PageIndexChanging '======Added By MUBYN 16-07-2018
        Try
            Dim CRMMainID As Integer
            CRMMainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim tempDate As Date = Date.Now.ToString("yyyy-MM-dd")
            Dim startOfMonth As New DateTime(tempDate.Year, tempDate.Month, 1)
            'Dim endOfMonth As DateTime = startOfMonth.AddMonths(1).AddDays(-1)
            startOfMonth = "2020-01-01"
            Dim endOfMonth As DateTime = Date.Now.ToString("yyyy-MM-dd")
            Dim txtfrom As String = startOfMonth.ToString("yyyy-MM-dd")
            Dim txtto As String = endOfMonth.ToString("yyyy-MM-dd")

            gvFeedBack.PageIndex = e.NewPageIndex
            gvFeedBack.DataSource = FeedBackBLL.FillGridViewById(e.NewPageIndex, 10, CRMMainID, "FillGVFeedBackByValue", 0, CRMMainID, txtfrom, txtto)
            gvFeedBack.DataBind()
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
#End Region
End Class
