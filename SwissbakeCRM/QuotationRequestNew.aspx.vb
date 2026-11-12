Imports System.Drawing

Partial Class QuotationRequestNew
    Inherits _PageBaseClass
    Private MainId As Integer
    Dim Count As Integer = 0
    Dim ds1 As New DataSet()
    Private dt1 As New DataTable()
    Private dt2 As New DataTable()
    Private dt3 As New DataTable()
    Private pgitems As New PagedDataSource()
    Public tabss As Integer
    Private maxPage As Integer
    Private minPage As Integer
    Dim RespCount As String
    Dim RespVendor As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        Else
        End If
        hlnkAdd.NavigateUrl = Page.ResolveUrl("ModifyQuotationrequest.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")
        If Not IsPostBack Then
            Hfgridview.Value = "QuotReqFilterCRM"
            hfExcel.Value = "ExcelAccountByAssign"
            FillGodown()
            BindLoad()
            'BindGridview()
            'CheckPrivilage()
            txtSearch.Attributes.Add("onkeyup", [String].Format("javascript:__doPostBack('{0}','')", rpg.ClientID))

            ' ''If Session("UserRoleID") = 1 Then
            ' ''    btnExport.Visible = True
            ' ''Else
            ' ''    btnExport.Visible = False
            ' ''End If
        End If

    End Sub

    Protected Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        If IsPostBack Then
            If txtSearch.Text <> "" OrElse hfBackcount.Value = "1" Then
                'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" OrElse hfBackcount.Value = "1" Then
                getsearch()
                fillpage()
            Else
                fillpage()
            End If
        End If
    End Sub

    Public Sub FillGodown()
        Try
            Dim ds As DataSet = MainBLL.Dropdown("GodownDropDown")
            ddlGodown.DataSource = ds
            ddlGodown.DataTextField = "Godown_Name"
            ddlGodown.DataValueField = "Godown_ID"
            ddlGodown.DataBind()
            ddlGodown.Items.Insert(0, New ListItem("Select Godown", "0"))

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyAccount", "FillSource", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Protected Sub BindGridview()
        Try
            ds1 = MainBLL.FillGridByID(Hfgridview.Value, Session("UserId"))
            'ds1 = MainBLL.FillGridView(hfgridview.Value)
            If ds1.Tables(0).Rows.Count > 0 Then
                dt1 = ds1.Tables(0)
                'rpgridview.DataSource = dt1
                'rpgridview.DataBind()
            End If
            dt3 = dt1
            Session("dt1QuotReqNew") = dt1

            fillpage()
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Binding Account'" + ex.Message + ")", True)
        End Try
    End Sub
    Public Sub fillpage()
        Dim dt As New DataTable()
        If txtSearch.Text <> "" Then
            'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" Then
            dt = DirectCast(Session("dt2QuotReqNew"), DataTable)
        Else

            dt = DirectCast(Session("dt1QuotReqNew"), DataTable)
        End If
        'If dt.Rows.Count = 0 Then
        '    Dim FooterTemplate As Control = rpgridview.Controls(rpgridview.Controls.Count - 1).Controls(0)
        '    FooterTemplate.FindControl("trEmpty").Visible = True
        'Else
        If dt.Rows.Count = 0 Then
            pgitems.DataSource = dt.DefaultView
            rpgridview.DataSource = pgitems
            rpgridview.DataBind()
            Dim FooterTemplate As Control = rpgridview.Controls(rpgridview.Controls.Count - 1).Controls(0)
            FooterTemplate.FindControl("trEmpty").Visible = True
            PopulatePager(0, 1)
            ' pgitems.AllowPaging = false ;

            lblTcount.Visible = False
        Else
            pgitems.DataSource = dt.DefaultView
            pgitems.AllowPaging = True
            lblTcount.Visible = True
            Count = dt.Rows.Count
            If Count > 1 Then
                lblTcount.Text = Count.ToString() + " " + " records"
            Else
                lblTcount.Text = Count.ToString() + " " + " record"
            End If

            pgitems.PageSize = Convert.ToInt32(ddpagesize.SelectedValue)
            PopulatePager(pgitems.PageCount, PageNumber)
            pgitems.CurrentPageIndex = PageNumber

            tabss = PageNumber + 1
            tab.Value = tabss.ToString()

            rpgridview.DataSource = pgitems
            rpgridview.DataBind()
        End If
        'End If
        ' '' '' '' '' '' ''CheckPrivilage()
    End Sub
    Private Sub PopulatePager(recordCount As Integer, currentPage As Integer)
        ' int drcount = Convert.ToInt32(lblTcount.Text.Trim("records");
        If Count > 10 Then
            Dim dblPageCount As Double = CDbl(CDec(recordCount) / Decimal.Parse((1).ToString()))
            Dim pageCount As Integer = CInt(Math.Ceiling(dblPageCount))
            Dim pages As New List(Of ListItem)()
            If pageCount > 0 Then
                If PageNumber = 0 Then
                Else
                    pages.Add(New ListItem("<", "1", currentPage > 1))
                End If
                Dim pagesToShow As Integer = 4
                minPage = Math.Max(1, currentPage - (pagesToShow / 2))
                maxPage = Math.Min(pageCount, minPage + pagesToShow)

                'if (minPage > 1)
                '    pages.Add(new ListItem("...", (minPage - 1).ToString(), false));
                For i As Integer = minPage To maxPage
                    pages.Add(New ListItem(i.ToString(), i.ToString(), i <> currentPage))
                Next

                'if (maxPage < pageCount)
                '    pages.Add(new ListItem("...", (maxPage + 1).ToString(), false));

                If PageNumber = maxPage - 1 Then
                Else
                    pages.Add(New ListItem(">", pageCount.ToString(), currentPage < pageCount))

                End If
            End If
            Dim g As New System.Web.UI.HtmlControls.HtmlGenericControl()
            rptPaging.DataSource = pages
            rptPaging.DataBind()
        Else
            Dim pages As New DataTable()
            pages.Clear()
            rptPaging.DataSource = pages
            rptPaging.DataBind()
        End If

    End Sub
    Protected Sub rptPaging_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs)
        If e.CommandArgument.ToString() = "<" Then
            PageNumber = PageNumber - 1
            'FillDemoGridview();
            fillpage()
        ElseIf e.CommandArgument.ToString() = ">" Then
            PageNumber = PageNumber + 1
            'FillDemoGridview();
            fillpage()
        Else
            PageNumber = Convert.ToInt32(e.CommandArgument) - 1
            'FillDemoGridview();
            fillpage()
        End If

    End Sub

    Public Property PageNumber() As Integer
        Get
            If ViewState("PageNumber") IsNot Nothing Then
                Return Convert.ToInt32(ViewState("PageNumber"))
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            ViewState("PageNumber") = value
        End Set
    End Property

    Protected Sub rptPaging_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        Dim linkButton As LinkButton = DirectCast(e.Item.FindControl("btnPage"), LinkButton)

        If linkButton Is Nothing Then
        Else
            Dim scriptManager__1 = ScriptManager.GetCurrent(Me.Page)
            If scriptManager__1 IsNot Nothing Then
                scriptManager__1.RegisterAsyncPostBackControl(linkButton)
            End If
        End If
    End Sub


    Public Sub getsearch()
        Try
            'date time column not working in search and footer
            dt2 = DirectCast(Session("dt1QuotReqNew"), DataTable)

            If txtSearch.Text <> "" Then
                Dim selectedTable1 As DataTable = dt2.AsEnumerable().Where(Function(r) (r.Field(Of String)("QuotationRequest_No").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                            (r.Field(Of String)("Vendor_Name").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                            (r.Field(Of String)("Rm_Name").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                            (r.Field(Of String)("Quantity").ToString.ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                            (r.Field(Of Decimal)("Amount").ToString.ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                            (r.Field(Of Decimal)("Per_Unit").ToString.ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                            (r.Field(Of Decimal)("Tax").ToString.ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                            (r.Field(Of Decimal)("Freight").ToString.ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                            (r.Field(Of Decimal)("Total").ToString.ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
                            (r.Field(Of String)("QuotationResponse_Status").ToUpper().Contains(txtSearch.Text.ToUpper()))
                                ).CopyToDataTable()

                Session("dt2QuotReqNew") = selectedTable1

            End If
        Catch ex As Exception
            '  Session["dt2"] = "1";
            Dim exception As New DataTable()
            exception.Clear()

            Session("dt2QuotReqNew") = exception
        End Try
    End Sub
    Protected Sub Sorting(sender As Object, e As EventArgs)
        Try
            Dim Header As LinkButton = DirectCast(sender, LinkButton)

            If Not Session("dt1QuotReqNew") Is Nothing Then
                Dim dt As DataTable = Session("dt1QuotReqNew")
                If ViewState("SortDir") Is Nothing Or ViewState("SortDir") = "Asc" Then
                    dt.DefaultView.Sort = Header.ID
                    dt = dt.DefaultView.ToTable()
                    ViewState("SortDir") = "Desc"
                Else
                    dt.DefaultView.Sort = Header.ID & " DESC"
                    dt = dt.DefaultView.ToTable()
                    ViewState("SortDir") = "Asc"
                End If
                Session("dt1QuotReqNew") = dt
                fillpage()

            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub ddpagesize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddpagesize.SelectedIndexChanged
        fillpage()

    End Sub

    Protected Sub Text_TextChanged(sender As Object, e As EventArgs)
        PageNumber = 0
    End Sub

    Protected Sub rpgridview_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rpgridview.ItemCommand
        If e.CommandName = "deletelink" Then
            If deletestatus.Value = "yes" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                MainId = index
                Try
                    MainBLL.DeleteSI(MainId, Session("UserId"), "QuotationDeleteSi", Session("Audlog_Id"))
                    BindNewGridview()
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("Vendor", "deletelink", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Else
                BindNewGridview()
            End If
        ElseIf e.CommandName = "statuslink" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            MainId = index
            Try
                MainBLL.UpdateStatus(MainId, Session("LeadId"), "QuotationStatus", Session("Audlog_Id"))
                BindNewGridview()
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("Vendor", "statuslink", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        ElseIf e.CommandName = "addresponse" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            MainId = index
            Response.Redirect("AddQuotationResponse.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&QRID=" + index)

        ElseIf e.CommandName = "emailpopup" Then
            'BindGridview()
            'fillQuotation()
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Session("Qid") = index
            mpe.Show()
            fillVendorViewEdit(index)

        End If
    End Sub
    Public Sub RegistrationMail(ByVal qid As Integer, ByVal Vdate As String, ByVal name As String, ByVal PONO As String, ByVal Amt As String, ByVal QNO As String)
        Try
            Dim sb, sb1 As New StringBuilder
            Dim count As Integer = 1
            Dim s As String = ""
            Dim body As String = String.Empty
            Dim reader As StreamReader = New StreamReader(Server.MapPath("~/Email/QuotationRequestCancel.html"))
            body = reader.ReadToEnd

            Dim ds As DataSet = QuotationRequestBLL.FillGridViewByID("VendorEmail", qid)
            Dim dtUser As New DataTable
            dtUser = ds.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)

            Dim dt As DataTable = ds.Tables(0)
            Dim emailid As String = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Email").ToString())
            body = body.Replace("#NAME", name)
            body = body.Replace("#PURCHASEORDERNO", PONO)
            body = body.Replace("#PURCHSEORDERDATE", Vdate)
            body = body.Replace("#PURCHASEORDERAMT", "&#8377 " + Amt)
            body = body.Replace("#VENDORQUOTATIONNO", QNO)
            SendMailBLL.SendPurchaseMail(emailid, body.ToString, "Purchase Order No. " + PONO + " has been Cancelled")
            reader.Dispose()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try

            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=Prospect-List.xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            Dim Gridview2 As New GridView

            Dim dt As New DataTable()
            'dt = MainBLL.SearchGridViewByID(txtSearch.Text.Trim, Session("UserId"), hfExcel.Value)
            'dt = MainBLL.FillGridByID(Hfgridview.Value, Session("UserId"))
            'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" Then
            If txtSearch.Text <> "" Then
                dt = DirectCast(Session("dt2QuotReqNew"), DataTable)
            Else
                dt = DirectCast(Session("dt1QuotReqNew"), DataTable)
            End If

            Dim dtExc As DataTable = dt

            Gridview2.DataSource = dtExc
            'Gridview2.DataBind()
            Gridview2.AllowPaging = False
            Gridview2.DataBind()
            Gridview2.RenderControl(hw)
            BindNewGridview()
            'style to format numbers to string
            Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
            Response.Write(style)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.End()
            ' ''Dim html2 As String = Regex.Replace(sw.ToString(), "(<img\/?[^>]+>)", "", RegexOptions.IgnoreCase)
            '' ''html2 = Regex.Replace(html2, "(<input class=""checkbox""\/?[^>]+>)", "", RegexOptions.IgnoreCase)
            ' ''html2 = Regex.Replace(html2, "(<a \/?[^>]+>)", "", RegexOptions.IgnoreCase)
            ' ''html2 = Regex.Replace(html2, "(<i \/?[^>]+>)", "(INR)", RegexOptions.IgnoreCase)
            ' ''Response.Write(html2.ToString())
            ' ''Response.Flush()
            ' ''Response.End()

            'DoValidate.closeConn(_conn)

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Prospect", "btnExport_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
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
                hlnkAdd.Visible = False
                'GridView1.Columns(0).Visible = False
                'SearchControl.ULkadd.Visible = False
            Else
                drprivilage = dtprivilage.Rows(0)
                If (drprivilage("Prvg_RAdd").ToString()) = True Then
                    hlnkAdd.Visible = True
                Else
                    hlnkAdd.Visible = False

                End If
                If (drprivilage("Prvg_RUpdate").ToString()) = True Then
                    'GridView1.Columns(0).Visible = True
                Else
                    'GridView1.Columns(0).Visible = False
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("QuotationResponse", "CheckPrivilage", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Shared Function checkPocancelStatus(ByVal status As String) As String
        If status = "True" Then
            Return "Cancelled"
        Else
            Return ""
        End If
    End Function

    Protected Sub rpgridview_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rpgridview.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim lblid = DirectCast(e.Item.FindControl("lblid"), Literal)
            Dim hladdresponse = DirectCast(e.Item.FindControl("hladdresponse"), HyperLink)
            Dim hledit = DirectCast(e.Item.FindControl("hledit"), HyperLink)
            Dim HyperLinkdelete = DirectCast(e.Item.FindControl("lnkdelete"), LinkButton)
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
        BindNewGridview()
        'fillQuotation()
        ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "Call", "alert('Email Successfully sent!)", True)
        mpe.Show()
        fillVendorViewEdit(Session("Qid"))
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

    Protected Sub grdvendoremail_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdvendoremail.RowCommand

        If e.CommandName = "sendmail" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            'BindNewGridview()

            Dim row As GridViewRow = grdvendoremail.Rows(index)
            Dim ltcntactprsn As Label = DirectCast(grdvendoremail.Rows(row.RowIndex).FindControl("ltcntactprsn"), Label)
            Dim ltemail As Label = DirectCast(grdvendoremail.Rows(row.RowIndex).FindControl("ltemail"), Label)
            Dim ltvendorid As Label = DirectCast(grdvendoremail.Rows(row.RowIndex).FindControl("ltvendorid"), Label)
            Dim dt As DataSet = QuotationRequestBLL.FillGridViewByID("GetVendorALLid", ltvendorid.Text)
            For i As Integer = 0 To dt.Tables(0).Rows.Count - 1
                Dim email As String = dt.Tables(0).Rows(i)("Contact_Email").ToString()
                Dim ContactName As String = dt.Tables(0).Rows(i)("Contact_ContactPerson").ToString()
                'Temporary stop email 06-10-2023 by Noor
                'RegistrationMail(Session("Qid"), email, ContactName, ltvendorid.Text.Trim)
            Next
            'RegistrationMail(Session("Qid"), ltemail.Text.Trim, ltcntactprsn.Text.Trim, ltvendorid.Text.Trim)
            QuotationRequestBLL.UpdateQtnemail(Session("Qid"), Convert.ToInt32(ltvendorid.Text.Trim))
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "Call", "alert('Email Successfully sent!)", True)
            mpe.Show()


            fillVendorViewEdit(Session("Qid"))
        End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            BindNewGridview()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub BindNewGridview()
        Try
            Dim WhereClause As String = ""
            If txtQRNO.Text <> "" Then
                WhereClause = WhereClause + " and ( QuotationRequest_No LIKE '%' + '" + txtQRNO.Text.Trim + "' + '%' ) "
            End If

            If txtQuotationDate.Text <> "" Then
                WhereClause = WhereClause + "  and ( convert(date,QuotationRequest_Date,105) = '" + txtQuotationDate.Text.Trim + "'  )  "
            End If
            ' ''If txtQRGodown.Text <> "" Then
            ' ''    WhereClause = WhereClause + "  and ( Godown_Name LIKE '%' + '" + txtQRGodown.Text.Trim + "' + '%' )  "
            ' ''End If
            If ddlGodown.SelectedValue <> "0" Then
                WhereClause = WhereClause + "  and ( QuotationRequest_Godown_ID = '" + ddlGodown.SelectedValue + "'  )  "
            End If


            If txtQRItem.Text <> "" Then
                WhereClause = WhereClause + "  and ( Rm_Name LIKE '%' + '" + txtQRItem.Text.Trim + "' + '%' )  "
            End If
            If txtQRQuantity.Text <> "" Then
                WhereClause = WhereClause + "  and ( QRRawMaterial_Quantity LIKE '%' + '" + txtQRQuantity.Text.Trim + "' + '%' )  "
            End If

            'ds1 = MainBLL.FillQuotRequestFilter(Hfgridview.Value, Session("UserId"), txtQRNO.Text.Trim, txtQuotationDate.Text.Trim, txtQRGodown.Text.Trim, txtQRItem.Text.Trim, txtQRQuantity.Text.Trim)
            If WhereClause <> "" Then
                ds1 = FilterBLL.FillNewFilter("QuotRequestCRMFiltM", Session("UserId"), WhereClause)
            End If
            If ds1.Tables.Count > 0 Then
                If ds1.Tables(0).Rows.Count > 0 Then
                    dt1 = ds1.Tables(0)
                    divMain.Visible = True
                    If Session("UserRoleID") = 1 Then
                        btnExport.Visible = True
                    Else
                        btnExport.Visible = False
                    End If
                Else
                    divMain.Visible = False
                    btnExport.Visible = False
                End If
                PageNumber = 0
                dt3 = dt1
                Session("dt1QuotReqNew") = dt1

                fillpage()
            Else
                divMain.Visible = False
                btnExport.Visible = False
            End If
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Binding Account'" + ex.Message + ")", True)
        End Try
    End Sub

    Sub AtLeastOneField_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        If txtQRNO.Text & txtQRGodown.Text & txtQRGodown.Text & txtQRItem.Text & txtQRQuantity.Text <> "" Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

    Protected Sub BindLoad()
        Try
            Dim WhereClause As String = ""
            WhereClause = WhereClause + "  and	( convert(date, QuotationRequest_CreateDate, 105) >= '" + Date.Now.AddDays(-7).Date.ToString("yyyy-MM-dd") + "'  )  "

            If WhereClause <> "" Then
                ds1 = FilterBLL.FillNewFilter("QuotRequestCRMFiltM", Session("UserId"), WhereClause)
            End If
            If ds1.Tables.Count > 0 Then
                If ds1.Tables(0).Rows.Count > 0 Then
                    dt1 = ds1.Tables(0)
                    divMain.Visible = True
                    If Session("UserRoleID") = 1 Then
                        btnExport.Visible = True
                    Else
                        btnExport.Visible = False
                    End If
                Else
                    divMain.Visible = False
                    btnExport.Visible = False
                End If
                PageNumber = 0
                dt3 = dt1
                Session("dt1QuotReqNew") = dt1

                fillpage()
            Else
                divMain.Visible = False
                btnExport.Visible = False
            End If
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Binding Account'" + ex.Message + ")", True)
        End Try
    End Sub

    'Protected Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click
    '    Try
    '        txtQRNO.Text = ""
    '        txtQuotationDate.Text = ""
    '        ddlGodown.SelectedValue = "0"
    '        txtQRItem.Text = ""
    '        txtQRQuantity.Text = ""
    '    Catch ex As Exception

    '    End Try
    'End Sub
End Class
