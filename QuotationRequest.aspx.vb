
Imports System.IO
Partial Class QuotationRequest
    Inherits _PageBaseClass
    Private MainId As Integer
    Dim RespCount As String
    Dim RespVendor As String
    Public name As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
            Try
                SearchControl.ULkadd.Visible = False
                SearchControl.Uhfadd.NavigateUrl = Page.ResolveUrl("ModifyQuotationrequest.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")
                If Not IsPostBack Then
                    Hfgridview.Value = "QuotationReqGridviewByAssign"
                    hfsearch.Value = "SearchQuotationReqByAssign"
                    hftotalrecord.Value = "QuotationReqTotalNumberOfRecord"
                    fillQuotation()
                    'CheckPrivilage()
                    'Above Line For Passing Mode In Search Lead Control
                    SearchControl.UhfExcelName.Value = "Quotation Request Details"
                    SearchControl.Uhfgridviewmode.Value = "QuotationReqGridviewByAssign"
                    SearchControl.Uhfsearchmode.Value = "SearchQuotationReqByAssign"
                    SearchControl.UhfExcelmode.Value = "ExcelQuotationReqByAssign"
                    SearchControl.Uhftotalcount.Value = "QuotationReqTotalNumberOfRecord"
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("Vendor", "Page_Load", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        Else
            Try
                SearchControl.ULkadd.Visible = False
                SearchControl.Uhfadd.NavigateUrl = Page.ResolveUrl("ModifyQuotationrequest.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")
                If Not IsPostBack Then

                    Hfgridview.Value = "QuotationReqGridviewByAssign"
                    hfsearch.Value = "SearchQuotationReqByAssign"
                    hftotalrecord.Value = "QuotationReqTotalNumberOfRecord"
                    fillQuotation()
                    'CheckPrivilage()
                    'Above Line For Passing Mode In Search Lead Control
                    SearchControl.UhfExcelName.Value = "Quotation Request Details"
                    SearchControl.Uhfgridviewmode.Value = "QuotationReqGridviewByAssign"
                    SearchControl.Uhfsearchmode.Value = "SearchQuotationReqByAssign"
                    SearchControl.UhfExcelmode.Value = "ExcelQuotationReqByAssign"
                    SearchControl.Uhftotalcount.Value = "QuotationReqTotalNumberOfRecord"
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("Vendor", "Page_Load", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If

    End Sub

    Public Sub fillQuotation()
        Try
            GridView1.PageSize = SearchControl.Uddpagesize.SelectedValue
            GridView1.VirtualItemCount = MainBLL.TotalRowInGridview(hftotalrecord.Value)
            GridView1.DataSource = MainBLL.FillGridView("0", SearchControl.Uddpagesize.SelectedValue, Hfgridview.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Vendor", "fillLead", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub IndexfillQuotation()
        Try
            GridView1.DataSource = MainBLL.FillGridView(GridView1.PageIndex, SearchControl.Uddpagesize.SelectedValue, Hfgridview.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Vendor", "IndexfillLead", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            If SearchControl.UtxtSearch.Text = "" Then
                GridView1.PageIndex = e.NewPageIndex
                GridView1.DataSource = MainBLL.FillGridView(GridView1.PageIndex, SearchControl.Uddpagesize.SelectedValue, Hfgridview.Value)
                GridView1.DataBind()
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
            Else
                GridView1.PageIndex = e.NewPageIndex
                SearchFillQuotation()
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Vendor", "GridView1_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddpagesize_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchControl.SelectedIndexChanged
        Try
            If SearchControl.Uddpagesize.SelectedItem.Text <> "0" Then
                GridView1.PageSize = SearchControl.Uddpagesize.SelectedValue.ToString()
                IndexfillQuotation()
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Vendor", "ddpagesize_SelectedIndexChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GridView1.Sorting
        SetSortDirection(SortDireaction)
        Try
            Dim dt As DataSet
            dt = MainBLL.SortingGridView("QuotationRequestSorting")

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
            ExecptionBLL.Insert("Vendor", "GridView1_Sorting", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub SearchFillQuotation()
        Try
            'Shhaid
            GridView1.DataSource = MainBLL.SearchGridView(SearchControl.UtxtSearch.Text, hfsearch.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Vendor", "SearchFillLead", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub


    Public Sub CheckPrivilage()
        Try
            Dim dt As DataSet = PrivilageBLL.CheckPrivilige(Session("UserRoleID"), "QuotationRequest.aspx")
            Dim dtprivilage As New DataTable
            dtprivilage = dt.Tables(0)
            Dim drprivilage As DataRow
            If dtprivilage.Rows.Count = 0 Then
                SearchControl.Uhfadd.Visible = False
                GridView1.Columns(0).Visible = False
                SearchControl.ULkadd.Visible = False
            Else
                drprivilage = dtprivilage.Rows(0)
                If (drprivilage("Prvg_RAdd").ToString()) = True Then
                    SearchControl.Uhfadd.Visible = True
                Else
                    SearchControl.Uhfadd.Visible = False

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
            ExecptionBLL.Insert("Vendor", "CheckPrivilage", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "deletelink" Then
            If deletestatus.Value = "yes" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                MainId = GridView1.DataKeys(index).Value
                Try
                    MainBLL.DeleteSI(MainId, Session("UserId"), "QuotationDeleteSi", Session("Audlog_Id"))
                    IndexfillQuotation()
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("Vendor", "deletelink", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Else
                If SearchControl.UtxtSearch.Text.Trim = "" Then
                    IndexfillQuotation()
                Else
                    SearchFillQuotation()
                End If
            End If
        ElseIf e.CommandName = "statuslink" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            MainId = GridView1.DataKeys(index).Value
            Try
                MainBLL.UpdateStatus(MainId, Session("LeadId"), "QuotationStatus", Session("Audlog_Id"))
                If SearchControl.UtxtSearch.Text.Trim = "" Then
                    IndexfillQuotation()
                Else
                    SearchFillQuotation()
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("Vendor", "statuslink", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        ElseIf e.CommandName = "addresponse" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            MainId = GridView1.DataKeys(index).Value
            Response.Redirect("AddQuotationResponse.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&QRID=" + index)

        ElseIf e.CommandName = "emailpopup" Then
            fillQuotation()
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Session("Qid") = index
            mpe.Show()
            fillVendorViewEdit(index)


            'MainId = GridView1.DataKeys(index).Value
            '  Response.Redirect("AddQuotationResponse.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&QRID=" + index)

        End If
    End Sub
    Public Sub fillVendorViewEdit(vId As Integer)
        Try
            Dim dtbl As New DataTable
            dtbl.Columns.Add("ItemDt_ID", GetType(Integer))
            dtbl.Columns.Add("Vendor_ID", GetType(Integer))
            dtbl.Columns.Add("Vendor_Name", GetType(String))
            dtbl.Columns.Add("Contact_ContactPerson", GetType(String))
            dtbl.Columns.Add("Contact_Mobile", GetType(String))
            dtbl.Columns.Add("Contact_Email", GetType(String))
            dtbl = QuotationRequestBLL.VendorViewByQuotation(vId).Tables(0)
            Session("OrderProduct") = dtbl
            If dtbl.Columns.Count > 0 Then
                grdvendoremail.DataSource = dtbl
                grdvendoremail.DataBind()
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
    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = ListItemType.AlternatingItem Then



                'For Each row As GridViewRow In GridView1.Rows
                Dim lblid = DirectCast(e.Row.FindControl("lblid"), Literal)
                Dim hladdresponse = DirectCast(e.Row.FindControl("hladdresponse"), HyperLink)
                Dim hledit = DirectCast(e.Row.FindControl("hledit"), HyperLink)
                Dim HyperLinkdelete = DirectCast(e.Row.FindControl("lnkdelete"), LinkButton)
                Dim dt As DataSet = MainBLL.ViewByID(lblid.Text, "CountResponseViewbyID")
                Dim dtUser As New DataTable
                dtUser = dt.Tables(0)
                If dtUser.Rows.Count > 0 Then
                    Dim drLogin As DataRow
                    drLogin = dtUser.Rows(0)
                    RespCount = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationResponse_QRDID").ToString())
                End If

                dtUser = dt.Tables(1)
                If dtUser.Rows.Count > 0 Then
                    Dim drLogin1 As DataRow
                    drLogin1 = dtUser.Rows(0)
                    RespVendor = DynamicparcelDataManipulation.FixNullFromDB(drLogin1("QRVendor_ID").ToString())
                End If
                If dt.Tables(2).Rows(0)("QuotationRequest_Status") = "Approved" Then
                    hladdresponse.Visible = False
                    HyperLinkdelete.Visible = False
                    hledit.Visible = False

                Else
                    If RespCount = 0 Then
                        hladdresponse.Visible = True
                        hledit.Visible = True
                        HyperLinkdelete.Visible = True
                    ElseIf RespCount > 0 And RespCount < RespVendor Then
                        hladdresponse.Visible = True
                        hledit.Visible = False
                        HyperLinkdelete.Visible = False
                    ElseIf RespCount = RespVendor Then
                        hladdresponse.Visible = False
                        HyperLinkdelete.Visible = False
                        hledit.Visible = False


                    End If


                End If
                '   Next

            End If

            'If RespVendor > 1 Then
            '    hledit.Visible = False
            '    hladdresponse.Visible = True
            'ElseIf RespVendor = 0 Then
            '    hledit.Visible = True
            '    hladdresponse.Visible = True
            'ElseIf RespCount < 1 Then
            '    hledit.Visible = False
            '    hladdresponse.Visible = False
            'ElseIf RespVendor = RespCount Then
            '    hledit.Visible = False
            '    hladdresponse.Visible = False
            'End If


            'If RespCount = "" Then
            '    hladdresponse.Visible = True
            '    hledit.Visible = True
            'ElseIf RespCount > 1 Then
            '    hladdresponse.Visible = False
            '    hledit.Visible = False
            'ElseIf RespCount = 1 Then
            '    hladdresponse.Visible = True
            '    hledit.Visible = False
            'End If


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub grdvendoremail_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdvendoremail.RowCommand

        If e.CommandName = "sendmail" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            fillQuotation()

            Dim row As GridViewRow = grdvendoremail.Rows(index)
            Dim ltcntactprsn As Label = DirectCast(grdvendoremail.Rows(row.RowIndex).FindControl("ltcntactprsn"), Label)
            Dim ltemail As Label = DirectCast(grdvendoremail.Rows(row.RowIndex).FindControl("ltemail"), Label)
            Dim ltvendorid As Label = DirectCast(grdvendoremail.Rows(row.RowIndex).FindControl("ltvendorid"), Label)
            Dim dt As DataSet = QuotationRequestBLL.FillGridViewByID("GetVendorALLid", ltvendorid.Text)
            For i As Integer = 0 To dt.Tables(0).Rows.Count - 1
                Dim email As String = dt.Tables(0).Rows(i)("Contact_Email").ToString()
                Dim ContactName As String = dt.Tables(0).Rows(i)("Contact_ContactPerson").ToString()
                RegistrationMail(Session("Qid"), email, ContactName, ltvendorid.Text.Trim)
            Next
            'RegistrationMail(Session("Qid"), ltemail.Text.Trim, ltcntactprsn.Text.Trim, ltvendorid.Text.Trim)
            QuotationRequestBLL.UpdateQtnemail(Session("Qid"), Convert.ToInt32(ltvendorid.Text.Trim))
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "Call", "alert('Email Successfully sent!)", True)
            mpe.Show()


            fillVendorViewEdit(Session("Qid"))
        End If
    End Sub

    Public Sub RegistrationMail(ByVal qid As Integer, ByVal emailid As String, ByVal name As String, ByVal vid As Integer)
        Try
            Dim sb, sb1 As New StringBuilder
            Dim count As Integer = 1
            Dim s As String = ""
            Dim body As String = String.Empty
            Dim reader As StreamReader = New StreamReader(Server.MapPath("~/Email/quotationrequest.html"))
            body = reader.ReadToEnd

            Dim ds As DataSet = QuotationRequestBLL.FillGridViewByID("emailvendor", qid)
            Dim dtUser As New DataTable
            dtUser = ds.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)

            Dim dt As DataTable = ds.Tables(0)
            sb.Append("<table border='1' cellspacing='0' cellpadding='5' style='border-color: rgb(247, 247, 247);width:100%;text-align:center;'><tr>")
            sb.Append("<th><center>SR</center></th>")
            sb.Append("<th><center>RAW MATERIAL</center></th>")
            sb.Append("<th style='width:15%;'><center>QUANTITY</center></th>")
            sb.Append("<th style='width:15%;'><center>UNIT</center></th></tr>")
            For Each dr As DataRow In dt.Rows
                sb.Append("<tr><td>" + count.ToString + "</td>")
                sb.Append("<td>" + dr("Rm_Name").ToString + "</td>")
                sb.Append("<td>" + dr("QRRawMaterial_Quantity").ToString + "</td>")
                sb.Append("<td>" + dr("QRRawMaterial_Unit").ToString + "</td></tr>")
                count = count + 1

            Next
            'sb.Append("<tr><th colspan='2' style='text-align: left;'><b style='font-weight:600'>SUB TOTAL</b></th><td>" + hftotalq.Value + "</td><td>" + hfsubtotal.Value + "</td></tr>")
            'sb.Append("<tr><th colspan='2' style='text-align: left;'><b style='font-weight:600'>VAT</b></th><td> (+) </td><td>" + hfvat.Value + "</td></tr>")
            'sb.Append("<tr><th colspan='3' style='text-align: left;'><b style='font-weight:600'>AMOUNT PAYABLE</b></th><th colspan='2'><b style='font-weight:600'>" + hfgrand.Value + "</b></th></tr>")
            sb.Append("</table>")


       

            body = body.Replace("#Table", sb.ToString)
            body = body.Replace("#NAME", name)
            body = body.Replace("#REQUESTNO", DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationRequest_No").ToString()))
            body = body.Replace("#DATE", DynamicparcelDataManipulation.DateFormatfirstdate(drLogin("QuotationRequest_Date").ToString()))
            ' body = body.Replace("#DELIVERYADDRESS", DynamicparcelDataManipulation.FixNullFromDB(drLogin("Godown_Address").ToString()))
            body = body.Replace("#Companyname", DynamicparcelDataManipulation.FixNullFromDB(drLogin("Company_Name").ToString()))
            body = body.Replace("#Contactname", DynamicparcelDataManipulation.FixNullFromDB(drLogin("Godown_ContactPerson").ToString()))
            body = body.Replace("#emailid", DynamicparcelDataManipulation.FixNullFromDB(drLogin("Godown_Email").ToString()))
            body = body.Replace("#contactno", DynamicparcelDataManipulation.FixNullFromDB(drLogin("Godown_Mobile").ToString()))
            Dim url As String = "<a href='" + "http://www.swissbake.ch/submitquote.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(qid)) & "&VId=" + HttpUtility.UrlEncode(Security.Encrypt(vid)) + "&returnurl=y" + "'> http://www.swissbake.ch/sghfhjgsf</a>"

            'Dim url As String = "<a href='" + "http://www.swissbake.in/SubmitQuotation.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(qid)) & "&VId=" + HttpUtility.UrlEncode(Security.Encrypt(vid)) + "&returnurl=y" + "'>" + "http://www.swissbake.in/SubmitQuotation.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(qid)) & "&VId=" + HttpUtility.UrlEncode(Security.Encrypt(vid)) + "&returnurl=y" + "</a>"
            body = body.Replace("#QUOTELINK", url).ToString()
            name = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Godown_Address").ToString())

            Dim name1() As String
            name1 = name.Split("*")
            'Dim sb1 As StringBuilder
            For Each name In name1
                sb1.Append("<li >" + name + "</li>")


            Next
            body = body.Replace("#DELIVERYADDRESS", sb1.ToString)
            'Dim dt1 As DataSet = Customer_AddressBLL.ViewByID("Shipping", Session("CustId"))
            'Dim dtCustomer As New DataTable
            'dtCustomer = dt1.Tables(0)

            'body = body.Replace("#CPerson", txtname.Text)
            'body = body.Replace("#Email", txtemail.Text)
            'body = body.Replace("#TelNumber", txtmobile.Text)
            'Dim dt As DataTable = ConfigBLL.GetConfig()
            'Try
            '   If dt.Rows.Count > 0 Then
            '      Dim EmailId, EmailPassword As String
            '     EmailId = DynamicparcelDataManipulation.FixNullFromDB(dt.Rows(0)("Support_Email").ToString)
            '    EmailPassword = DynamicparcelDataManipulation.FixNullFromDB(dt.Rows(0)("Support_Password").ToString)
            '   Pro.SendMail(txtemail.Text, body.ToString, "Your Registration at www.SwissBake.in", EmailId, EmailPassword)
            '  End If
            'Catch ex As Exception

            '  End Try

            SendMailBLL.SendPurchaseMail(emailid, body.ToString, "Request for Quotation | Swiss-Bake Ingredients Pvt. Ltd.")
            reader.Dispose()
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub grdvendoremail_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdvendoremail.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Try


                Dim lblsent As Label = DirectCast(e.Row.FindControl("lblsent"), Label)
                Dim lblnotsent As Label = DirectCast(e.Row.FindControl("lblnotsent"), Label)
                Dim lblemailstatus As Label = DirectCast(e.Row.FindControl("lblemailstatus"), Label)
                If lblemailstatus.Text = "False" Then
                    lblnotsent.Visible = True
                    lblsent.Visible = False
                Else
                    lblnotsent.Visible = False
                    lblsent.Visible = True
                End If

            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("UserId")) 'User", "GridView1_PageIndexChanging", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
    End Sub

    Protected Sub btnsendall_Click(sender As Object, e As EventArgs) Handles btnsendall.Click

        For i As Integer = 0 To grdvendoremail.Rows.Count - 1

            Dim row As GridViewRow = grdvendoremail.Rows(i)
            Dim ltcntactprsn As Label = DirectCast(grdvendoremail.Rows(row.RowIndex).FindControl("ltcntactprsn"), Label)
            Dim ltemail As Label = DirectCast(grdvendoremail.Rows(row.RowIndex).FindControl("ltemail"), Label)
            Dim ltvendorid As Label = DirectCast(grdvendoremail.Rows(row.RowIndex).FindControl("ltvendorid"), Label)
            Dim dt As DataSet = QuotationRequestBLL.FillGridViewByID("GetVendorALLid", ltvendorid.Text)
            For x As Integer = 0 To dt.Tables(0).Rows.Count - 1
                Dim email As String = dt.Tables(0).Rows(x)("Contact_Email").ToString()
                Dim ContactName As String = dt.Tables(0).Rows(x)("Contact_ContactPerson").ToString()
                'Temporary stop email 06-10-2023 by Noor
                'RegistrationMail(Session("Qid"), email, ContactName, ltvendorid.Text.Trim)
            Next
            'RegistrationMail(Session("Qid"), ltemail.Text.Trim, ltcntactprsn.Text.Trim, ltvendorid.Text.Trim)
            QuotationRequestBLL.UpdateQtnemail(Session("Qid"), Convert.ToInt32(ltvendorid.Text.Trim))


        Next
        fillQuotation()
        ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "Call", "alert('Email Successfully sent!)", True)
        mpe.Show()
        fillVendorViewEdit(Session("Qid"))
    End Sub
End Class
