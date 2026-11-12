
Partial Class ViewAccount
    Inherits _PageBaseClass
    Dim MainID As Integer
    'Dim countrydt As DataTable
    Dim statedt As DataTable
    Dim strvat As New List(Of String)
    Dim countrate As Double = 0.0
    Dim countrate1 As Double = 0.0

    Private pgitems As New PagedDataSource()
    Dim Count As Integer = 0
    Dim ds1 As New DataSet()
    Private dt1 As New DataTable()
    Public tabss As Integer
    Private maxPage As Integer
    Private minPage As Integer

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
                ExecptionBLL.Insert("ViewAccount", "Page_Init", error1, Session("UserId"))
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
                ExecptionBLL.Insert("ViewAccount", "Page_Init", error1, Session("UserId"))
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
                Me.txtsearch.Attributes.Add("onkeyup", String.Format("javascript:__doPostBack('{0}','')", Me.UpdatePanel4.ClientID))
                privilage()
                FillCount()
                aedit.HRef = Page.ResolveUrl("ModifyAccount.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())) + "&returnurl=y")
                FillViewSample()
                FillDetail()
                aprint.HRef = Page.ResolveUrl("PrintDocs.aspx?tpy=Price&type=" + HttpUtility.UrlEncode(Security.Encrypt((ltcontactname.Text).ToString())) + "&Id=" + HttpUtility.UrlEncode(Security.Encrypt((MainID).ToString())))
                lnkAddComplaint.PostBackUrl = Page.ResolveUrl("ModifyCustomerComplaint.aspx?&Id=" + HttpUtility.UrlEncode(Security.Encrypt((0).ToString())) + "&type=A&typeId=" + HttpUtility.UrlEncode(Security.Encrypt((MainID).ToString())))
                FillBillingAddressDetail()
                fillOrder()
                FillSampleReq()
                fillInvoice()
                fillPayment()
                FillComplaint()
                fillCase()
                fillDSR()
                fillCRMFeedback()
                activitycontrol.Uhftype.Value = "Account"
                activitycontrol.Uhftypeid.Value = MainID
                documentcontrol.Uhftype.Value = "Account"
                documentcontrol.Uhftypeid.Value = MainID
                notecontrol.Uhftype.Value = "Account"
                notecontrol.Uhftypeid.Value = MainID
                contactcontrol.Uhftype.Value = "Account"
                contactcontrol.Uhftypeid.Value = MainID
                oportunitycontrol.Uhftype.Value = "Account"
                oportunitycontrol.Uhftypeid.Value = MainID
                emailcontrol.Uhftype.Value = "Account"
                emailcontrol.Uhftypeid.Value = MainID
                quotationcontrol.Uhftype.Value = "Account"
                quotationcontrol.Uhftypeid.Value = MainID
                If Session("UserRoleID") = "4" Then
                    quotationcontrol.Visible = False
                End If
            Else
                Dim target As String = Me.Request.Form("__EVENTTARGET")
                If Not String.IsNullOrEmpty(target) AndAlso target.Equals(Me.UpdatePanel4.ClientID) Then
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
            ExecptionBLL.Insert("ViewAccount", "Page_Load", error1, Session("UserId"))
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
            ExecptionBLL.Insert("ViewAccount", "lkquicktask_Click", error1, Session("UserId"))
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
            ExecptionBLL.Insert("ViewAccount", "lkquickevent_Click", error1, Session("UserId"))
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
            ExecptionBLL.Insert("ViewAccount", "lkquickcall_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "ViewAccountByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            ltleaddate.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Email").ToString())
            ltcontactname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
            ltcompanyname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString())
            ltmobile.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Mobile").ToString())
            ltphone.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Landline").ToString())
            lblcst.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Cust_Tin").ToString())
            lblpan.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Cust_Pan").ToString())
            lblvat.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Cust_Vat").ToString())
            lblgst.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Cust_GST").ToString())
            'ltowner.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
			Lblbank.Text = DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(1).Rows(0)("BankName").ToString())
            rpowner.DataSource = AssignToBLL.FillAssignTo("Account", MainID)
            rpowner.DataBind()
            dt = Nothing
            dt = ActivityBLL.FillTaskType("Account", MainID, "CountActivity")
            dtUser = dt.Tables(0)
            drLogin = dtUser.Rows(0)
            ltcounttask.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Task").ToString())
            ltcountevent.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Evented").ToString())
            ltcountcall.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Calls").ToString())
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewAccount", "FillDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub privilage()
        Try
            Dim dt As DataSet = PrivilageBLL.CheckPrivilige(Session("UserRoleID"), "Account.aspx")
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
            ExecptionBLL.Insert("ViewAccount", "privilage", error1, Session("UserId"))
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
            ExecptionBLL.Insert("ViewAccount", "lkdelete_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    'Order
    Public Sub fillOrder()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            GridView3.VirtualItemCount = MainBLL.TotalRowInGridviewBYID("OrderTotalNumberOfRecordBYACC", MainID)
            If (GridView3.VirtualItemCount = 0) Then
                lblorder.Text = "No Orders"
            Else
                lblorder.Text = "Orders (" + GridView3.VirtualItemCount.ToString + ")"
            End If
            GridView3.DataSource = MainBLL.FillGridViewById(0, 10000, MainID, "OrderBYACCountID")
            GridView3.DataBind()
            If Session("UserRoleID") = "4" Then
                GridView3.Columns(0).Visible = False
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewAccount", "fillOrder", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub GridView3_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView3.PageIndexChanging
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            GridView3.PageIndex = e.NewPageIndex
            GridView3.DataSource = MainBLL.FillGridViewById(e.NewPageIndex, 10000, MainID, "OrderBYACCountID")
            GridView3.DataBind()
            If Session("UserRoleID") = "4" Then
                GridView3.Columns(0).Visible = False
            End If
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    'Order

    'Invoice
    Public Sub fillInvoice()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            GridView1.VirtualItemCount = MainBLL.TotalRowInGridviewBYID("InvoiceTotalNumberOfRecord", MainID)
            If (GridView1.VirtualItemCount = 0) Then
                lblinvoice.Text = "No Invoice"
            Else
                lblinvoice.Text = "Invoice (" + GridView1.VirtualItemCount.ToString + ")"
            End If
            GridView1.DataSource = MainBLL.FillGridViewById("0", 10, MainID, "InvoiceGridview")
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            GridView1.PageIndex = e.NewPageIndex
            GridView1.DataSource = MainBLL.FillGridViewById(e.NewPageIndex, 10, MainID, "InvoiceGridview")
            GridView1.DataBind()
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    'Invoice

    'payment
    Public Sub fillPayment()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            GridView2.VirtualItemCount = MainBLL.TotalRowInGridviewBYID("PaymentTotalNumberOfRecord", MainID)
            If (GridView2.VirtualItemCount = 0) Then
                lblpayment.Text = "No Payments"
            Else
                lblpayment.Text = "Payments (" + GridView2.VirtualItemCount.ToString + ")"
            End If
            GridView2.DataSource = MainBLL.FillGridViewById("0", 10, MainID, "PaymentGridview")
            GridView2.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            GridView2.PageIndex = e.NewPageIndex
            GridView2.DataSource = MainBLL.FillGridViewById(e.NewPageIndex, 10, MainID, "PaymentGridview")
            GridView2.DataBind()
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    'payment

    Protected Sub GridView2_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView2.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblinfo As Literal = DirectCast(e.Row.FindControl("lblinfo"), Literal)
            If String.IsNullOrEmpty(lblinfo.Text.Trim) Then
                lblinfo.Text = "-"
            End If
        End If
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
    Public Sub FillCount()
        Try
            Dim ds As DataSet = AccountBLL.Accview(MainID)
            If ds.Tables.Count > 0 Then
                lblorderamount.Text = Convert.ToDouble(Convert.ToString(ds.Tables(0).Rows(0)(1))).ToString("#,##0.00")
                lblordercount.Text = Convert.ToString(ds.Tables(0).Rows(0)(0))
                lblinvtotal.Text = Convert.ToDouble(Convert.ToString(ds.Tables(1).Rows(0)(1))).ToString("#,##0.00")
                lblinvoicecount.Text = Convert.ToString(ds.Tables(1).Rows(0)(0))
                lblpaytotal.Text = Convert.ToDouble(Convert.ToString(ds.Tables(2).Rows(0)(1))).ToString("#,##0.00")
                lblpaycount.Text = Convert.ToString(ds.Tables(2).Rows(0)(0))
                lblbalpay.Text = Convert.ToDouble(Convert.ToString(ds.Tables(3).Rows(0)(0))).ToString("#,##0.00")
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Index.aspx", "FillIndexCount", error1, Session("UserId"))
            Throw ex
        End Try
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
            GridView4.DataSource = ViewState("Fillproduct")
            GridView4.DataBind()

            ' GridView1.DataSource = ProductBLL.CRMProductViewAll(ddrelatedtypeid.SelectedValue)
            ' GridView1.DataBind()


            For Each value As String In strvat
                For Each row As GridViewRow In GridView4.Rows
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
            GridView4.DataSource = SampleBLL.SearchGridViewByID(txtsearch.Text.Trim, MainID, "SearchSampleProduct").Tables(0)
            GridView4.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifySalesOrder", "FillSearch", error1, Session("UserId"))
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


                For Each row As GridViewRow In GridView4.Rows
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
                For Each row As GridViewRow In GridView4.Rows
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
            ds = SampleBLL.ViewByID(MainID, "SampleViewProductAcc", "Account")
            If ds.Tables(0).Rows.Count > 0 Then

                Session("OrderProduct") = ds.Tables(0)
            End If
            ds = SampleBLL.ViewByID(MainID, "SampleViewProductLink", "Account")
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

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lbldirect As System.Web.UI.WebControls.Label = DirectCast(e.Row.FindControl("lbldirect"), System.Web.UI.WebControls.Label)
            Dim lbldash As System.Web.UI.WebControls.Label = DirectCast(e.Row.FindControl("lbldash"), System.Web.UI.WebControls.Label)
            Dim HyperLink1 As System.Web.UI.WebControls.HyperLink = DirectCast(e.Row.FindControl("HyperLink1"), System.Web.UI.WebControls.HyperLink)
            Dim lblunit As System.Web.UI.WebControls.Label = DirectCast(e.Row.FindControl("lblunit"), System.Web.UI.WebControls.Label)

            If lbldirect.Text = "Direct" Then
                HyperLink1.Visible = False
                lbldirect.Visible = True
                lbldash.Visible = False
            End If
            If lblunit.Text = "Cancel" Then
                HyperLink1.Visible = False
                lbldash.Visible = True
                lbldirect.Visible = False
            End If

        End If
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
                SampleBLL.DeleteProductLinkCrm(MainID, "Account")
                SampleBLL.UpdateDesc("UpdateLeadDesc", MainID, txtOtherPI.Text, "Account", Session("UserId"))
                For i As Integer = 0 To grditemproduct.Rows.Count - 1
                    '  Dim index As Integer = grditemproduct.Rows(i).RowIndex
                    Dim ltproductid As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltproductid"), Label)
                    SampleBLL.InsertProductLinkCrm(MainID, "Account", ltproductid.Text, Session("UserId"))
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
            ExecptionBLL.Insert("ViewAccount", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub CheckPrivi() 'MUBYN
        Try
            Dim ds As DataSet = UserBLL.CheckPrivi(Session("UserRoleID"), "Account.aspx")
            Dim strArr() As String
            Dim TemStr As String = ""
            Dim dtPrivi As New DataTable
            dtPrivi = Session("dtPrivilege")
            Dim rows() As DataRow = dtPrivi.Select("Menu_URL = 'Account.aspx'")

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
                    If strArr(1) = "1" Then
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

    Public Sub FillSampleReq()
        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        grdsamplereq.DataSource = MainBLL.ViewByIDs(Session("UserId"), MainID, "AccountSampleReqViewByID")
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
        grdsamplereq.DataSource = MainBLL.ViewByIDs(Session("UserId"), MainID, "AccountSampleReqViewByID")
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
            gvFeedBack.DataSource = ds1 'FeedBackBLL.FillGridViewById("0", 10, CRMMainID, "FillGVFeedBackByValue", 0, CRMMainID, txtfrom, txtto)
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
    '#Region "CRm Feedback"
    '    Protected Sub BindGridview()
    '        Try
    '            Dim CRMMainID As Integer
    '            CRMMainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
    '            Dim tempDate As Date = Date.Now.ToString("yyyy-MM-dd")
    '            Dim startOfMonth As New DateTime(tempDate.Year, tempDate.Month, 1)
    '            'Dim endOfMonth As DateTime = startOfMonth.AddMonths(1).AddDays(-1)
    '            startOfMonth = "2020-01-01"
    '            Dim endOfMonth As DateTime = Date.Now.ToString("yyyy-MM-dd")
    '            Dim txtfrom As String = startOfMonth.ToString("yyyy-MM-dd")
    '            Dim txtto As String = endOfMonth.ToString("yyyy-MM-dd")
    '            'ds1 = MainBLL.FillGridView(hfgridview.Value)
    '            ds1 = FeedBackBLL.FillGridByID("FeedBackByValue", 0, CRMMainID, txtfrom, txtto)

    '            dt1 = ds1.Tables(0)
    '            If (dt1.Rows.Count > 0) Then
    '                lblCRMFeedback.Text = "CRM Feedback (" + dt1.Rows.Count.ToString + ")"
    '            Else
    '                lblCRMFeedback.Text = "No CRM Feedback"
    '            End If
    '            Session("dt1FB") = dt1

    '            fillpage()
    '        Catch ex As Exception
    '            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Binding Account'" + ex.Message + ")", True)
    '        End Try
    '    End Sub
    '    Public Sub fillpage()
    '        Dim dt As New DataTable()
    '        'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" Then
    '        If txtSearch.Text <> "" Then
    '            dt = DirectCast(Session("dt2FB"), DataTable)
    '        Else

    '            dt = DirectCast(Session("dt1FB"), DataTable)
    '        End If
    '        'If dt.Rows.Count = 0 Then
    '        '    Dim FooterTemplate As Control = rpgridview.Controls(rpgridview.Controls.Count - 1).Controls(0)
    '        '    FooterTemplate.FindControl("trEmpty").Visible = True
    '        'Else
    '        If dt.Rows.Count = 0 Then
    '            pgitems.DataSource = dt.DefaultView
    '            rpgridview.DataSource = pgitems
    '            rpgridview.DataBind()
    '            Dim FooterTemplate As Control = rpgridview.Controls(rpgridview.Controls.Count - 1).Controls(0)
    '            FooterTemplate.FindControl("trEmpty").Visible = True
    '            PopulatePager(0, 1)
    '            ' pgitems.AllowPaging = false ;

    '            lblTcount.Visible = False
    '        Else
    '            pgitems.DataSource = dt.DefaultView
    '            pgitems.AllowPaging = True
    '            lblTcount.Visible = True
    '            Count = dt.Rows.Count
    '            If Count > 1 Then
    '                lblTcount.Text = Count.ToString() + " " + " records"
    '            Else
    '                lblTcount.Text = Count.ToString() + " " + " record"
    '            End If

    '            pgitems.PageSize = Convert.ToInt32(10)
    '            PopulatePager(pgitems.PageCount, PageNumber)
    '            pgitems.CurrentPageIndex = PageNumber

    '            tabss = PageNumber + 1
    '            tab.Value = tabss.ToString()

    '            rpgridview.DataSource = pgitems
    '            rpgridview.DataBind()
    '        End If
    '        'End If
    '        'CheckPrivilage()
    '    End Sub
    '    Private Sub PopulatePager(recordCount As Integer, currentPage As Integer)
    '        ' int drcount = Convert.ToInt32(lblTcount.Text.Trim("records");
    '        If Count > 10 Then
    '            Dim dblPageCount As Double = CDbl(CDec(recordCount) / Decimal.Parse((1).ToString()))
    '            Dim pageCount As Integer = CInt(Math.Ceiling(dblPageCount))
    '            Dim pages As New List(Of ListItem)()
    '            If pageCount > 0 Then
    '                If PageNumber = 0 Then
    '                Else
    '                    pages.Add(New ListItem("<", "1", currentPage > 1))
    '                End If
    '                Dim pagesToShow As Integer = 4
    '                minPage = Math.Max(1, currentPage - (pagesToShow / 2))
    '                maxPage = Math.Min(pageCount, minPage + pagesToShow)

    '                'if (minPage > 1)
    '                '    pages.Add(new ListItem("...", (minPage - 1).ToString(), false));
    '                For i As Integer = minPage To maxPage
    '                    pages.Add(New ListItem(i.ToString(), i.ToString(), i <> currentPage))
    '                Next

    '                'if (maxPage < pageCount)
    '                '    pages.Add(new ListItem("...", (maxPage + 1).ToString(), false));

    '                If PageNumber = maxPage - 1 Then
    '                Else
    '                    pages.Add(New ListItem(">", pageCount.ToString(), currentPage < pageCount))

    '                End If
    '            End If
    '            Dim g As New System.Web.UI.HtmlControls.HtmlGenericControl()
    '            rptPaging.DataSource = pages
    '            rptPaging.DataBind()
    '        Else
    '            Dim pages As New DataTable()
    '            pages.Clear()
    '            rptPaging.DataSource = pages
    '            rptPaging.DataBind()
    '        End If

    '    End Sub
    '    Protected Sub rptPaging_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs)
    '        If e.CommandArgument.ToString() = "<" Then
    '            PageNumber = PageNumber - 1
    '            'FillDemoGridview();
    '            fillpage()
    '        ElseIf e.CommandArgument.ToString() = ">" Then
    '            PageNumber = PageNumber + 1
    '            'FillDemoGridview();
    '            fillpage()
    '        Else
    '            PageNumber = Convert.ToInt32(e.CommandArgument) - 1
    '            'FillDemoGridview();
    '            fillpage()
    '        End If

    '    End Sub

    '    Public Property PageNumber() As Integer
    '        Get
    '            If ViewState("PageNumber") IsNot Nothing Then
    '                Return Convert.ToInt32(ViewState("PageNumber"))
    '            Else
    '                Return 0
    '            End If
    '        End Get
    '        Set(value As Integer)
    '            ViewState("PageNumber") = value
    '        End Set
    '    End Property

    '    Protected Sub rptPaging_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
    '        Dim linkButton As LinkButton = DirectCast(e.Item.FindControl("btnPage"), LinkButton)

    '        If linkButton Is Nothing Then
    '        Else
    '            Dim scriptManager__1 = ScriptManager.GetCurrent(Me.Page)
    '            If scriptManager__1 IsNot Nothing Then
    '                scriptManager__1.RegisterAsyncPostBackControl(linkButton)
    '            End If
    '        End If
    '    End Sub

    '    Protected Sub Text_TextChanged(sender As Object, e As EventArgs)
    '        PageNumber = 0
    '    End Sub

    'Protected Sub rpgridview_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rpgridview.ItemCommand
    '    Try
    '        If (e.CommandName = "MessagePopUp") Then
    '            Dim index As Integer = Convert.ToInt32(e.CommandArgument.ToString())
    '            'Dim index As Integer = Convert.ToInt32(e.CommandArgument)
    '            'Cont_ID = Gridview1.DataKeys(index).Value
    '            Try

    '                'mpeFeed.Enabled = True
    '                mpeFeed.Show()
    '                ''Dim DsPop As DataTable = MainBLL.ViewByID(index, "ViewEmailSMSPopByID").Tables(0)
    '                ''If DsPop.Rows.Count > 0 Then

    '                ''    Dim drLogin As DataRow
    '                ''    drLogin = DsPop.Rows(0)
    '                Dim lblRemark As Literal = DirectCast(e.Item.FindControl("lblRemark"), Literal)
    '                Dim lblRating_TypeId As Literal = DirectCast(e.Item.FindControl("lblRating_TypeId"), Literal)
    '                Dim lblRating_Listening As Literal = DirectCast(e.Item.FindControl("lblRating_Listening"), Literal)
    '                Dim lblRating_Knowledge As Literal = DirectCast(e.Item.FindControl("lblRating_Knowledge"), Literal)
    '                Dim lblRating_Understandability As Literal = DirectCast(e.Item.FindControl("lblRating_Understandability"), Literal)

    '                lblMessage.Text = lblRemark.Text
    '                lblRating.Text = lblRating_TypeId.Text
    '                RatingListening.CurrentRating = lblRating_Listening.Text
    '                RatingKnowledge.CurrentRating = lblRating_Knowledge.Text
    '                RatingUnderstandability.CurrentRating = lblRating_Understandability.Text

    '                Dim lblActivityID As Literal = DirectCast(e.Item.FindControl("lblActivityID"), Literal)
    '                Dim ID As Integer = 0
    '                'Dim index As Integer = Convert.ToInt32(e.CommandArgument)
    '                'Dim row As GridViewRow = GridView1.Rows(index)
    '                ''Dim lbluId As Literal = DirectCast(GridView1.Items(index).FindControl("lbluId"), Literal)
    '                Dim lblRelatedType As Literal = DirectCast(e.Item.FindControl("lblRelatedType"), Literal)
    '                Dim lblRelatedTypeID As Literal = DirectCast(e.Item.FindControl("lblRelatedTypeID"), Literal)
    '                ID = lblActivityID.Text ' index 'GridView1.DataKeys(index).Value
    '                'lvnote.DataSource = NoteBLL.NoteActivWithAssReverse(Session("UserId"), ID)
    '                'lvnote.DataBind()
    '                'grdactivityhistory.DataSource = MainBLL.ViewByID(ID, "ActivityHistory")
    '                'grdactivityhistory.DataBind()
    '                hfmainactivityidFeed.Value = ID
    '                hfreltypeIdFeed.Value = lblRelatedTypeID.Text
    '                hfreltypeFeed.Value = lblRelatedType.Text
    '                Dim dt As DataSet
    '                If hfreltypeFeed.Value = "Account" Or hfreltypeFeed.Value = "Prospect" Then
    '                    dt = NoteBLL.RecentActivity(ID, hfreltypeFeed.Value, hfreltypeIdFeed.Value)
    '                    trcontactFeed.Visible = True
    '                    Dim dtUser As New DataTable
    '                    dtUser = dt.Tables(0)
    '                    Dim drLogin As DataRow
    '                    drLogin = dtUser.Rows(0)
    '                    lblnameFeed.Text = hfreltypeFeed.Value + " Name"
    '                    lblsubjectFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
    '                    ltstartdateFeed.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
    '                    ltenddateFeed.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
    '                    lblaccnameFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
    '                    ltpriorityFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
    '                    ltownerFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
    '                    If ltpriorityFeed.Text = "High" Then
    '                        ltpriorityFeed.CssClass = "label label-success"
    '                    ElseIf ltpriorityFeed.Text = "Highest" Then
    '                        ltpriorityFeed.CssClass = "label label-success"
    '                    ElseIf ltpriorityFeed.Text = "Lowest" Then
    '                        ltpriorityFeed.CssClass = "label label-danger"
    '                    ElseIf ltpriorityFeed.Text = "Low" Then
    '                        ltpriorityFeed.CssClass = "label label-warning"
    '                    ElseIf ltpriorityFeed.Text = "Normal" Then
    '                        ltpriorityFeed.CssClass = "label label-info"
    '                    End If
    '                    ltstatusFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
    '                    If ltstatusFeed.Text = "Close" Then
    '                        ltstatusFeed.CssClass = "label label-success"
    '                    ElseIf ltstatusFeed.Text = "Close Postpone" Then
    '                        ltstatusFeed.CssClass = "label label-info"
    '                    ElseIf ltstatusFeed.Text = "Pending" Or ltstatusFeed.Text = "Due" Then
    '                        ltstatusFeed.CssClass = "label label-warning"
    '                    ElseIf ltstatusFeed.Text = "Today" Then
    '                        ltstatusFeed.CssClass = "label label-success"
    '                    ElseIf (ltstatusFeed.Text = "Missed") Then
    '                        ltstatusFeed.CssClass = "label label-danger"
    '                    ElseIf (ltstatusFeed.Text = "Tommorrow") Then
    '                        ltstatusFeed.CssClass = "label label-info"
    '                    End If
    '                    ltdescFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
    '                    ltresultFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
    '                    ltcontactFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("ContactName").ToString())
    '                    'lblconatctd.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString())
    '                    hffollowactivityidFeed.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Id").ToString())
    '                ElseIf hfreltypeFeed.Value = "Quotation" Then
    '                    dt = NoteBLL.ViewNoteQuotation(ID, hfreltypeIdFeed.Value)
    '                    Dim dtUser As New DataTable
    '                    dtUser = dt.Tables(0)
    '                    Dim drLogin As DataRow
    '                    drLogin = dtUser.Rows(0)
    '                    lblnameFeed.Text = "Quotation Name"
    '                    trcontactFeed.Visible = False
    '                    lblsubjectFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
    '                    ltstartdateFeed.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
    '                    ltenddateFeed.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
    '                    ltpriorityFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
    '                    ltownerFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
    '                    If ltpriorityFeed.Text = "High" Then
    '                        ltpriorityFeed.CssClass = "label label-success"
    '                    ElseIf ltpriorityFeed.Text = "Highest" Then
    '                        ltpriorityFeed.CssClass = "label label-success"
    '                    ElseIf ltpriorityFeed.Text = "Lowest" Then
    '                        ltpriorityFeed.CssClass = "label label-danger"
    '                    ElseIf ltpriorityFeed.Text = "Low" Then
    '                        ltpriorityFeed.CssClass = "label label-warning"
    '                    ElseIf ltpriorityFeed.Text = "Normal" Then
    '                        ltpriorityFeed.CssClass = "label label-info"
    '                    End If
    '                    ltstatusFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
    '                    If ltstatusFeed.Text = "Close" Then
    '                        ltstatusFeed.CssClass = "label label-success"
    '                    ElseIf ltstatusFeed.Text = "Close Postpone" Then
    '                        ltstatusFeed.CssClass = "label label-info"
    '                    ElseIf ltstatusFeed.Text = "Pending" Or ltstatusFeed.Text = "Due" Then
    '                        ltstatusFeed.CssClass = "label label-warning"
    '                    ElseIf ltstatusFeed.Text = "Today" Then
    '                        ltstatusFeed.CssClass = "label label-success"
    '                    ElseIf (ltstatusFeed.Text = "Missed") Then
    '                        ltstatusFeed.CssClass = "label label-danger"
    '                    ElseIf (ltstatusFeed.Text = "Tommorrow") Then
    '                        ltstatusFeed.CssClass = "label label-info"
    '                    End If
    '                    ltdescFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
    '                    ltresultFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
    '                    lblaccnameFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_No").ToString()) + "-" + DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
    '                    'lblconatctd.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Name").ToString())
    '                    hffollowactivityidFeed.Value = ID
    '                ElseIf hfreltypeFeed.Value = "Opportunity" Then
    '                    dt = NoteBLL.ViewOpportunityByID(ID, hfreltypeIdFeed.Value)
    '                    Dim dtUser As New DataTable
    '                    dtUser = dt.Tables(0)
    '                    Dim drLogin As DataRow
    '                    drLogin = dtUser.Rows(0)
    '                    lblnameFeed.Text = "Opportunity Name"
    '                    lblaccnameFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity_Name").ToString()) + "-" + DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_Name").ToString())
    '                    trcontactFeed.Visible = True
    '                    lblsubjectFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
    '                    ltstartdateFeed.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
    '                    ltenddateFeed.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
    '                    ltpriorityFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
    '                    ltownerFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
    '                    ltcontactFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("ContactName").ToString())
    '                    If ltpriorityFeed.Text = "High" Then
    '                        ltpriorityFeed.CssClass = "label label-success"
    '                    ElseIf ltpriorityFeed.Text = "Highest" Then
    '                        ltpriorityFeed.CssClass = "label label-success"
    '                    ElseIf ltpriorityFeed.Text = "Lowest" Then
    '                        ltpriorityFeed.CssClass = "label label-danger"
    '                    ElseIf ltpriorityFeed.Text = "Low" Then
    '                        ltpriorityFeed.CssClass = "label label-warning"
    '                    ElseIf ltpriorityFeed.Text = "Normal" Then
    '                        ltpriorityFeed.CssClass = "label label-info"
    '                    End If
    '                    ltstatusFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
    '                    If ltstatusFeed.Text = "Close" Then
    '                        ltstatusFeed.CssClass = "label label-success"
    '                    ElseIf ltstatusFeed.Text = "Close Postpone" Then
    '                        ltstatusFeed.CssClass = "label label-info"
    '                    ElseIf ltstatusFeed.Text = "Pending" Then
    '                        ltstatusFeed.CssClass = "label label-warning"
    '                    ElseIf ltstatusFeed.Text = "Today" Then
    '                        ltstatusFeed.CssClass = "label label-success"
    '                    ElseIf (ltstatusFeed.Text = "Missed") Then
    '                        ltstatusFeed.CssClass = "label label-danger"
    '                    ElseIf (ltstatusFeed.Text = "Tommorrow") Then
    '                        ltstatusFeed.CssClass = "label label-info"
    '                    End If
    '                    ltdescFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
    '                    ltresultFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
    '                    hffollowactivityidFeed.Value = ID
    '                ElseIf hfreltypeFeed.Value = "Lead" Then
    '                    dt = NoteBLL.ViewLeadViewByID(ID, hfreltypeIdFeed.Value)
    '                    Dim dtUser As New DataTable
    '                    dtUser = dt.Tables(0)
    '                    Dim drLogin As DataRow
    '                    drLogin = dtUser.Rows(0)
    '                    lblnameFeed.Text = "Lead Name"
    '                    lblaccnameFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Lead_Name").ToString())
    '                    trcontactFeed.Visible = True
    '                    lblsubjectFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
    '                    ltstartdateFeed.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
    '                    ltenddateFeed.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
    '                    ltpriorityFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
    '                    ltownerFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
    '                    ltcontactFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("ContactName").ToString())
    '                    If ltpriorityFeed.Text = "High" Then
    '                        ltpriorityFeed.CssClass = "label label-success"
    '                    ElseIf ltpriorityFeed.Text = "Highest" Then
    '                        ltpriorityFeed.CssClass = "label label-success"
    '                    ElseIf ltpriorityFeed.Text = "Lowest" Then
    '                        ltpriorityFeed.CssClass = "label label-danger"
    '                    ElseIf ltpriorityFeed.Text = "Low" Then
    '                        ltpriorityFeed.CssClass = "label label-warning"
    '                    ElseIf ltpriorityFeed.Text = "Normal" Then
    '                        ltpriorityFeed.CssClass = "label label-info"
    '                    End If
    '                    ltstatusFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
    '                    If ltstatusFeed.Text = "Close" Then
    '                        ltstatusFeed.CssClass = "label label-success"
    '                    ElseIf ltstatusFeed.Text = "Close Postpone" Then
    '                        ltstatusFeed.CssClass = "label label-info"
    '                    ElseIf ltstatusFeed.Text = "Pending" Then
    '                        ltstatusFeed.CssClass = "label label-warning"
    '                    ElseIf ltstatusFeed.Text = "Today" Then
    '                        ltstatusFeed.CssClass = "label label-success"
    '                    ElseIf (ltstatusFeed.Text = "Missed") Then
    '                        ltstatusFeed.CssClass = "label label-danger"
    '                    ElseIf (ltstatusFeed.Text = "Tommorrow") Then
    '                        ltstatusFeed.CssClass = "label label-info"
    '                    End If
    '                    ltdescFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
    '                    ltresultFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
    '                    hffollowactivityidFeed.Value = ID
    '                ElseIf hfreltypeFeed.Value = "None" Then
    '                    dt = MainBLL.ViewByID(ID, "ActivityViewByID")
    '                    Dim dtUser As New DataTable
    '                    dtUser = dt.Tables(0)
    '                    Dim drLogin As DataRow
    '                    drLogin = dtUser.Rows(0)
    '                    lblnameFeed.Text = "Account Name"
    '                    lblaccnameFeed.Text = "None"
    '                    trcontactFeed.Visible = False
    '                    lblsubjectFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Subject").ToString())
    '                    ltstartdateFeed.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallStartTime").ToString())
    '                    ltenddateFeed.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Activity_CallEndTime").ToString())
    '                    ltpriorityFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Priority").ToString())
    '                    If ltpriorityFeed.Text = "High" Then
    '                        ltpriorityFeed.CssClass = "label label-success"
    '                    ElseIf ltpriorityFeed.Text = "Highest" Then
    '                        ltpriorityFeed.CssClass = "label label-success"
    '                    ElseIf ltpriorityFeed.Text = "Lowest" Then
    '                        ltpriorityFeed.CssClass = "label label-danger"
    '                    ElseIf ltpriorityFeed.Text = "Low" Then
    '                        ltpriorityFeed.CssClass = "label label-warning"
    '                    ElseIf ltpriorityFeed.Text = "Normal" Then
    '                        ltpriorityFeed.CssClass = "label label-info"
    '                    End If
    '                    ltstatusFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_ActivityStatus").ToString())
    '                    If ltstatusFeed.Text = "Close" Then
    '                        ltstatusFeed.CssClass = "label label-success"
    '                    ElseIf ltstatusFeed.Text = "Close Postpone" Then
    '                        ltstatusFeed.CssClass = "label label-info"
    '                    ElseIf ltstatusFeed.Text = "Pending" Or ltstatusFeed.Text = "Due" Then
    '                        ltstatusFeed.CssClass = "label label-warning"
    '                    ElseIf ltstatusFeed.Text = "Today" Then
    '                        ltstatusFeed.CssClass = "label label-success"
    '                    ElseIf (ltstatusFeed.Text = "Missed") Then
    '                        ltstatusFeed.CssClass = "label label-danger"
    '                    ElseIf (ltstatusFeed.Text = "Tommorrow") Then
    '                        ltstatusFeed.CssClass = "label label-info"
    '                    End If
    '                    ltdescFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Description").ToString())
    '                    ltresultFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Activity_Result").ToString())
    '                    ltownerFeed.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
    '                    hffollowactivityidFeed.Value = ID
    '                End If
    '                'mpeFeed.Enabled = True
    '                'mpeFeed.Show()
    '                'adc.Attributes.Add("class", "accordion-toggle")
    '            Catch ex As Exception
    '                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Updating Status')", True)
    '            End Try

    '        End If

    '    Catch ex As Exception
    '        ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Deleting Class')", True)
    '    End Try
    'End Sub
    '#End Region

   
End Class
