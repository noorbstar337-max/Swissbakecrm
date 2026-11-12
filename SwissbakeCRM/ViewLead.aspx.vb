
Partial Class ViewLead
    Inherits System.Web.UI.Page
    Dim MainID As Integer
    'Dim countrydt As DataTable
    Dim statedt As DataTable
    Dim strvat As New List(Of String)
    Dim countrate As Double = 0.0
    Dim countrate1 As Double = 0.0

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
                ExecptionBLL.Insert("ViewLead", "Page_Init", error1, Session("UserId"))
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
                ExecptionBLL.Insert("ViewLead", "Page_Init", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
         End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                CheckPrivi()
                Session("OrderProduct") = Nothing
                Me.txtsearch.Attributes.Add("onkeyup", String.Format("javascript:__doPostBack('{0}','')", Me.UpdatePanel2.ClientID))
                privilage()
                aedit.HRef = Page.ResolveUrl("ModifyLead.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())) + "&returnurl=y")
                FillViewSample()
                FillDetail()
                FillContact()
                FillSampleReq()
                FillDesignation()
                FillAddressDetail()


                activitycontrol.Uhftype.Value = "Lead"
                activitycontrol.Uhftypeid.Value = MainID
                documentcontrol.Uhftype.Value = "Lead"
                documentcontrol.Uhftypeid.Value = MainID
                notecontrol.Uhftype.Value = "Lead"
                notecontrol.Uhftypeid.Value = MainID
                emailcontrol.Uhftype.Value = "Lead"
                emailcontrol.Uhftypeid.Value = MainID
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
            'FillDetail()
            'upquickaction.Update()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewLead", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub lkquicktask_Click(sender As Object, e As EventArgs) Handles lkquicktask.Click
        Try
            activitycontrol.dateTimeFuntion()
            activitycontrol.Utask.Show()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewLead", "lkquicktask_Click", error1, Session("UserId"))
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
            ExecptionBLL.Insert("ViewLead", "lkquickevent_Click", error1, Session("UserId"))
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
            ExecptionBLL.Insert("ViewLead", "lkquickcall_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "ViewLeadViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            Dim Converted As Boolean = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead_Converted").ToString())
            If Converted = True Then
                Response.Redirect("Index.aspx")
            End If
            ltleaddate.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadContact_Email").ToString())
            ltcompanyname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead_Name").ToString())
            ltcontactname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString())
            ltmobile.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadContact_MobileNo").ToString())
            ltphone.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadContact_OfficeNo").ToString())
            rpowner.DataSource = AssignToBLL.FillAssignTo("Lead", MainID)
            rpowner.DataBind()
            dt = Nothing
            dt = ActivityBLL.FillTaskType("Lead", MainID, "CountActivity")
            dtUser = dt.Tables(0)
            drLogin = dtUser.Rows(0)
            ltcounttask.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Task").ToString())
            ltcountevent.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Evented").ToString())
            ltcountcall.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Calls").ToString())
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewLead", "FillDetail", error1, Session("UserId"))
            ' ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub privilage()
        Try
            Dim dt As DataSet = PrivilageBLL.CheckPrivilige(Session("UserRoleID"), "Lead.aspx")
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
                    lkconvacount.Visible = True
                    lkconvprospect.Visible = True
                Else
                    aedit.Visible = False
                    lkconvacount.Visible = False
                    lkconvprospect.Visible = False
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
            ExecptionBLL.Insert("ViewLead", "privilage", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub lkconvacount_Click(sender As Object, e As EventArgs) Handles lkconvacount.Click
        Try
        'Response.Redirect("CommingSoon.aspx")
            'MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            'MainID = AccountBLL.ConvertLead("Account", Session("UserId"), Session("Audlog_Id"), MainID)
            '    Response.Redirect(Page.ResolveUrl("ViewAccount.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString()))))
            'If deletestatus.Value = "yes" Then
            '    MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            '    LeadBLL.UpdateLeadStage(MainID, 7)
            '    Response.Redirect("Lead.aspx")
            'End If
            deletestatus.Value = "Junk"
            ltreason.Text = "Junk Lead"
            mpclose.Show()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewLead", "lkconvacount_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub lkconvprospect_Click(sender As Object, e As EventArgs) Handles lkconvprospect.Click
        Try


            'Response.Redirect("CommingSoon.aspx")
            deletestatus.Value = "Prospect"

            ltreason.Text = "Convert To Prospect"
            mpclose.Show()
            'If deletestatus.Value = "yes" Then
            '    MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            '    MainID = AccountBLL.ConvertLead("Prospect", Session("UserId"), Session("Audlog_Id"), MainID)
            '    LeadBLL.UpdateLeadStage(MainID, 13)
            '    Response.Redirect(Page.ResolveUrl("ViewProspect.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString()))))
            'End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewLead", "lkconvprospect_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

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
            ExecptionBLL.Insert("ViewLead", "lkdelete_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    'Lead Contact
    Sub AtLeastOneContact_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        If txtemail.Text & txtofficeno.Text & txtmob.Text <> "" Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

    Protected Sub rbowner_CheckedChanged(sender As Object, e As EventArgs)
        Try
            Dim rd As RadioButton = DirectCast(sender, RadioButton)
            Dim row As GridViewRow = DirectCast(rd.NamingContainer, GridViewRow)
            Dim ContactID As Integer = GridView1.DataKeys(row.RowIndex).Value.ToString()
            'ContactBLL.UpdatePrimaryContact(hftype.Value, hftypeid.Value, ContactID, Session("UserId"), Session("Audlog_Id"))
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            LeadContactBLL.UpdatePrimaryContact(ContactID, Session("UserId"), MainID, Session("Audlog_Id"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewLead", "rbowner_CheckedChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillContact()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            GridView1.DataSource = MainBLL.ViewByID(MainID, "AllLeadContactViewByID")
            GridView1.DataBind()
            Dim DS As DataSet = DirectCast(GridView1.DataSource, DataSet)
            Dim totalcount As Integer = DS.Tables(0).Rows.Count
            If totalcount > 0 Then
                lblcontact.Text = "Contact (" + totalcount.ToString + ")"
            Else
                lblcontact.Text = "No Contact"
            End If
            For Each row As GridViewRow In GridView1.Rows
                GridView1.HeaderRow.Cells(2).Visible = False
                row.Cells(2).Visible = False
                GridView1.HeaderRow.Cells(7).Visible = False
                row.Cells(7).Visible = False
            Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewLead", "FillContact", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillSampleReq()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            grdsamplereq.DataSource = MainBLL.ViewByIDs(Session("UserId"), MainID, "LeadSampleReqViewByID")
            grdsamplereq.DataBind()
            Dim DS As DataSet = DirectCast(grdsamplereq.DataSource, DataSet)
            Dim totalcount As Integer = DS.Tables(0).Rows.Count
            If totalcount > 0 Then
                lblsamreq.Text = "Sample Request (" + totalcount.ToString + ")"
            Else
                lblsamreq.Text = "No Sample Request"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            If lblemail.Visible = False Then

                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                LeadContactBLL.QuickInsert1(txtname.Text.Trim, txtemail.Text.Trim, txtmob.Text.Trim, txtofficeno.Text.Trim,
                                         "", Session("UserId"), MainID, Session("Audlog_Id"), False, ddldesignation.SelectedValue, ddlnotifyby.SelectedItem.Text)
                FillContact()
                mpe.Hide()
                txtname.Text = ""
                txtemail.Text = ""
                txtmob.Text = ""
                txtofficeno.Text = ""
                ddldesignation.SelectedValue = "0"
                ddlnotifyby.SelectedValue = "Email"
            Else
                txtemail.Focus()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewLead", "btnsave_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            GridView1.PageIndex = e.NewPageIndex
            GridView1.DataSource = MainBLL.ViewByID(MainID, "AllLeadContactViewByID")
            GridView1.DataBind()
            For Each row As GridViewRow In GridView1.Rows
                GridView1.HeaderRow.Cells(2).Visible = False
                row.Cells(2).Visible = False
                GridView1.HeaderRow.Cells(7).Visible = False
                row.Cells(7).Visible = False
            Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewLead", "GridView1_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    'Lead Contact

    Protected Sub btncloseyes_Click(sender As Object, e As EventArgs) Handles btncloseyes.Click
        If deletestatus.Value = "Junk" Then
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            LeadBLL.UpdateLeadStage(MainID, 7, txtremark.Text.Trim)
            Response.Redirect("Lead.aspx")
        ElseIf deletestatus.Value = "Prospect" Then
            Dim PID As Integer
            Try
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                PID = AccountBLL.ConvertLead("Prospect", Session("UserId"), Session("Audlog_Id"), MainID)
                LeadBLL.UpdateLeadStage(MainID, 13, txtremark.Text.Trim)
                Response.Redirect(Page.ResolveUrl("ViewProspect.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(PID.ToString()))))
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ViewLead", "ConvetToProspect", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                Response.Redirect(Page.ResolveUrl("ViewProspect.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(PID.ToString()))))
            End Try
        End If
    End Sub

    Protected Sub btclosenno_Click(sender As Object, e As EventArgs) Handles btclosenno.Click
        mpclose.Hide()
    End Sub

    Public Sub FillAddressDetail()
        Try
            'countrydt = MainBLL.Dropdown("CountryDropDown").Tables(0)
            statedt = MainBLL.Dropdown("ALLStateDropDown").Tables(0)
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "LeadAddressViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                lbladdress.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadAddress_Address").ToString())
                lbladdress.Text += " " + DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadAddress_City").ToString())
                Dim state As Array = statedt.Select("ID = '" + drLogin("LeadAddress_State").ToString() + "'")
                If state.Length <> 0 Then
                    lbladdress.Text += " " + state(0)(1).ToString
                End If
                'Dim country As Array = countrydt.Select("ID = '" + drLogin("LeadAddress_Country").ToString() + "'")
                'If country.Length <> 0 Then
                '    lbladdress.Text += " " + country(0)(1).ToString + " "
                'End If
                lbladdress.Text += " " + DynamicparcelDataManipulation.FixNullFromDB(drLogin("LeadAddress_Pincode").ToString())
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewLead", "FillAddressDetail", error1, Session("UserId"))
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
            Button1.Enabled = True
            Button1.Text = "Save"
            ModalPopupExtender1.Show()
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
            ViewState("Fillproduct") = SampleBLL.ViewItemDetail(MainID).Tables(1)
            GridView2.DataSource = ViewState("Fillproduct")
            GridView2.DataBind()

            ' GridView2.DataSource = ProductBLL.CRMProductViewAll(ddrelatedtypeid.SelectedValue)
            ' GridView2.DataBind()


            For Each value As String In strvat
                For Each row As GridViewRow In GridView2.Rows
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

    Public Sub FillDesignation()
        Dim ds As DataSet = MainBLL.Dropdown("B2bDesignationDropDown")
        ddldesignation.DataSource = ds.Tables(0)
        ddldesignation.DataTextField = "Desig_Name"
        ddldesignation.DataValueField = "Desig_Id"
        ddldesignation.DataBind()
    End Sub

    Public Sub FillSearch()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            '  GridView2.DataSource = ProductBLL.SearchCRMProduct(MainID, txtsearch.Text.Trim)
            GridView2.DataSource = SampleBLL.SearchGridViewByID(txtsearch.Text.Trim, MainID, "SearchSampleProduct").Tables(1)
            GridView2.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifySalesOrder", "FillSearch", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub


    Protected Sub txt_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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


                For Each row As GridViewRow In GridView2.Rows
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
                For Each row As GridViewRow In GridView2.Rows
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

                ModalPopupExtender1.Hide()
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
            ds = SampleBLL.ViewByID(MainID, "SampleViewProduct", "Lead")
            If ds.Tables(0).Rows.Count > 0 Then

                Session("OrderProduct") = ds.Tables(0)


            End If
            ds = SampleBLL.ViewByID(MainID, "SampleViewProductLink", "Lead")
            If ds.Tables(0).Rows.Count > 0 Then

                txtOtherPI.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(0)("Lead_Description"))

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
            'If chkIntNotSpec.Checked = True Then
            '    Save()
            'ElseIf grditemproduct.Rows.Count > 0 Or txtOtherPI.Text <> "" Then
            '    Save()
            'Else

            '    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Select Atleast One Product Or Mention Product Interested In')", True)
            '    btnopen_Click(Nothing, Nothing)
            '    'aToggle.Attributes.Add("Class", "accordion-toggle")
            '    faq8561_q12.Attributes.Add("Class", "panel-collapse collapse in")
            '    faq8561_q12.Attributes.Add("style", " ")

            'End If
            
            Save()
            FillViewSample()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewLead", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub Save()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            SampleBLL.DeleteProductLinkCrm(MainID, "Lead")
            SampleBLL.UpdateDesc("UpdateLeadDesc", MainID, txtOtherPI.Text, "Lead", Session("UserId"))
            For i As Integer = 0 To grditemproduct.Rows.Count - 1
                '  Dim index As Integer = grditemproduct.Rows(i).RowIndex
                Dim ltproductid As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltproductid"), Label)
                SampleBLL.InsertProductLinkCrm(MainID, "Lead", ltproductid.Text, Session("UserId"))
            Next

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewLead", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub CheckPrivi()
        Try
            Dim ds As DataSet = UserBLL.CheckPrivi(Session("UserRoleID"), "Lead.aspx")
            Dim strArr() As String
            Dim TemStr As String = ""
            Dim dtPrivi As New DataTable
            dtPrivi = Session("dtPrivilege")
            Dim rows() As DataRow = dtPrivi.Select("Menu_URL = 'Lead.aspx'")

            TemStr = rows(0).Item("Val").ToString()
            strArr = TemStr.Split(",")
            If (strArr.Length > 3) Then
                If MainID = 0 Then
                    If strArr(2) = "1" Then
                    Else
                        Response.Redirect("index.aspx")
                    End If
                Else
                    'If strArr(1) = "1" Or strArr(2) = "1" Or strArr(3) = "1" Then
                    If strArr(2) = "1" Then
                    Else
                        Response.Redirect("index.aspx")
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        txtname.Text = ""
        txtemail.Text = ""
        txtmob.Text = ""
        txtofficeno.Text = ""
        ddldesignation.SelectedValue = 0
        ddlnotifyby.SelectedValue = 0
    End Sub

    Protected Sub grdsamplereq_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdsamplereq.PageIndexChanging
        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        grdsamplereq.PageIndex = e.NewPageIndex
        grdsamplereq.DataSource = MainBLL.ViewByIDs(Session("UserId"), MainID, "LeadSampleReqViewByID")
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

    Protected Sub txtemail_TextChanged(sender As Object, e As EventArgs) Handles txtemail.TextChanged
       Try
            If txtemail.Text <> "" Then
                If txtemail.Text.Trim <> hfLeadEmail.Value.Trim Then
                    Dim check As String = MainBLL.CheckEmail(txtemail.Text, "AccProEmailCheck")
                    If check = "Already Exist" Then
                        lblemail.Text = "Email already exist"
                        lblemail.Visible = True
                        txtemail.Focus()
                    Else
                        lblemail.Visible = False
                    End If
                Else
                    lblemail.Visible = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
