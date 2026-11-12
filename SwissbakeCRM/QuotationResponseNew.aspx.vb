Imports System.Drawing

Partial Class QuotationResponseNew
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

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        Else
        End If
        'hlnkAdd.NavigateUrl = Page.ResolveUrl("ModifyProspect.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=y")
        If Not IsPostBack Then
            Hfgridview.Value = "QuotationResponseFilterCRM"
            hfExcel.Value = "ExcelAccountByAssign"
            BindLoad()
            'BindGridview()
            'CheckPrivilage()
            txtSearch.Attributes.Add("onkeyup", [String].Format("javascript:__doPostBack('{0}','')", rpg.ClientID))

            ''If Session("UserRoleID") = 1 Then
            ''    btnExport.Visible = True
            ''Else
            ''    btnExport.Visible = False
            ''End If
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
            Session("dt1QRespNew") = dt1

            fillpage()
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Binding Account'" + ex.Message + ")", True)
        End Try
    End Sub
    Public Sub fillpage()
        Dim dt As New DataTable()
        If txtSearch.Text <> "" Then
            'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" Then
            dt = DirectCast(Session("dt2QRespNew"), DataTable)
        Else

            dt = DirectCast(Session("dt1QRespNew"), DataTable)
        End If
        'If dt.Rows.Count = 0 Then
        '    Dim FooterTemplate As Control = rpgridview.Controls(rpgridview.Controls.Count - 1).Controls(0)
        '    FooterTemplate.FindControl("trEmpty").Visible = True
        'Else
        If dt IsNot Nothing Then
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
        End If
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
            dt2 = DirectCast(Session("dt1QRespNew"), DataTable)

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

                Session("dt2QRespNew") = selectedTable1

            End If
        Catch ex As Exception
            '  Session["dt2"] = "1";
            Dim exception As New DataTable()
            exception.Clear()

            Session("dt2QRespNew") = exception
        End Try
    End Sub
    Protected Sub Sorting(sender As Object, e As EventArgs)
        Try
            Dim Header As LinkButton = DirectCast(sender, LinkButton)

            If Not Session("dt1QRespNew") Is Nothing Then
                Dim dt As DataTable = Session("dt1QRespNew")
                If ViewState("SortDir") Is Nothing Or ViewState("SortDir") = "Asc" Then
                    dt.DefaultView.Sort = Header.ID
                    dt = dt.DefaultView.ToTable()
                    ViewState("SortDir") = "Desc"
                Else
                    dt.DefaultView.Sort = Header.ID & " DESC"
                    dt = dt.DefaultView.ToTable()
                    ViewState("SortDir") = "Asc"
                End If
                Session("dt1QRespNew") = dt
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
        Try
            If e.CommandName = "Approvedink" Then
                Try
                    Dim commandArgs As String() = e.CommandArgument.ToString().Split(New Char() {","c})
                    Dim a, b As String
                    a = commandArgs(0)
                    b = commandArgs(1)
                    QuotationResponseBLL.UpdateQuotationStatus("UpdateStatusApprove", a, b, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('This Quotation has been approved');", True)
                    BindNewGridview()
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("AddquotationResponse", "btnApprove_Click", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            ElseIf e.CommandName = "createPO" Then
                Dim commandArgs As String() = e.CommandArgument.ToString().Split(New Char() {","c})
                Dim a, b As String
                a = commandArgs(0)
                b = commandArgs(1)
                ' Dim index As Integer = Convert.ToInt32(e.CommandArgument)

                Dim oItem As RepeaterItem = DirectCast(DirectCast(e.CommandSource, LinkButton).NamingContainer, RepeaterItem)
                Dim index As Integer = oItem.ItemIndex

                Dim lblPerUnit As Literal = DirectCast(rpgridview.Items(index).FindControl("lblPerUnit1"), Literal)

                Dim lblAmount As Literal = DirectCast(rpgridview.Items(index).FindControl("lblAmount1"), Literal)
                Dim lblTax As Literal = DirectCast(rpgridview.Items(index).FindControl("lblTax1"), Literal)
                Dim lblFreight As Literal = DirectCast(rpgridview.Items(index).FindControl("lblFreight1"), Literal)
                Dim lblRMID As Literal = DirectCast(rpgridview.Items(index).FindControl("lblRMID"), Literal)
                Dim lblQResponse_Code As Literal = DirectCast(rpgridview.Items(index).FindControl("lblQResponse_Code"), Literal)
                Dim lblQty As Literal = DirectCast(rpgridview.Items(index).FindControl("lblQty1"), Literal)
                Dim getstring As String() = lblQty.Text.ToString().Split(New Char() {"-"c})
                Dim Qty, unit As String
                Qty = getstring(0)
                unit = getstring(1)
                Dim PurchaseOrder_ID As Integer = PurchaseOrderBLL.InsertPurchaseOrder(a, lblQResponse_Code.Text, b, lblAmount.Text, lblTax.Text, lblFreight.Text, Session("UserId"), Session("Audlog_Id"))
                PurchaseOrderBLL.InsertPORawMaterial(lblRMID.Text, PurchaseOrder_ID, Qty, unit, Session("UserId"), Session("Audlog_Id"))
                PurchaseOrderBLL.UpdatePORawMaterial(lblRMID.Text, PurchaseOrder_ID, CDbl(lblPerUnit.Text), CDbl(lblTax.Text), CDbl(lblAmount.Text))

                Response.Redirect("Purchaseorder.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(a)) + "&VId=" + HttpUtility.UrlEncode(Security.Encrypt(b)))
             
                BindNewGridview()
            End If

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Deleting Class')", True)
        End Try
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
                dt = DirectCast(Session("dt2QRespNew"), DataTable)
            Else
                dt = DirectCast(Session("dt1QRespNew"), DataTable)
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
            Dim LblR As Literal = DirectCast(e.Item.FindControl("LblR"), Literal)
            Dim LblV As Literal = DirectCast(e.Item.FindControl("LblV"), Literal)
            Dim LblResponse_ID As Literal = DirectCast(e.Item.FindControl("LblResponse_ID"), Literal)
            Dim checkcname As String = PurchaseOrderBLL.CheckExistsPurchaseOrder(LblR.Text, LblResponse_ID.Text, LblV.Text)
            Dim hledit = DirectCast(e.Item.FindControl("hledit"), HyperLink)
            Dim lblStatus As Literal = CType(e.Item.FindControl("lblStatus1"), Literal)
            Dim lblApproved = DirectCast(e.Item.FindControl("lnkApproved"), LinkButton)
            Dim lblPO = DirectCast(e.Item.FindControl("lnkPO"), LinkButton)
            Dim LnkViewPO As HtmlAnchor = DirectCast(e.Item.FindControl("LnkViewPO"), HtmlAnchor)
            If lblStatus.Text = "Pending" Then
                lblPO.Visible = False
                LnkViewPO.Visible = False
                lblApproved.Visible = True
                hledit.Visible = True
                'lblDelete.Visible = True
            ElseIf lblStatus.Text = "Approved" Then
                lblPO.Visible = True
                LnkViewPO.Visible = False
                lblApproved.Visible = False
                hledit.Visible = False
                ' lblDelete.Visible = False

            Else
                lblPO.Visible = False
                lblApproved.Visible = False
                hledit.Visible = False
                LnkViewPO.Visible = False
                '  lblDelete.Visible = False
            End If
            If (checkcname = "Already Exist") Then
                lblPO.Visible = False
                lblApproved.Visible = False
                hledit.Visible = False
                LnkViewPO.Visible = True
            End If

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

            If txtVendorName.Text <> "" Then
                WhereClause = WhereClause + "  and ( Vendor_Name LIKE '%' + '" + txtVendorName.Text.Trim.Replace("'", "''") + "' + '%' )  "
            End If
            If txtItem.Text <> "" Then
                WhereClause = WhereClause + "  and ( Rm_Name LIKE '%' + '" + txtItem.Text.Trim + "' + '%' )  "
            End If

            If txtQuantity.Text <> "" Then
                WhereClause = WhereClause + "  and ( Quantity LIKE '%' + '" + txtQuantity.Text.Trim + "' + '%' )  "
            End If
            If txtAmount.Text <> "" Then
                WhereClause = WhereClause + "  and ( Amount LIKE '%' + '" + txtAmount.Text.Trim + "' + '%' )  "
            End If
            If txtPerUnit.Text <> "" Then
                WhereClause = WhereClause + "  and ( Per_Unit LIKE '%' + '" + txtPerUnit.Text.Trim + "' + '%' )  "
            End If
            If txtTax.Text <> "" Then
                WhereClause = WhereClause + "  and ( Tax LIKE '%' + '" + txtTax.Text.Trim + "' + '%' )  "
            End If
            If txtFreight.Text <> "" Then
                WhereClause = WhereClause + "  and ( Freight LIKE '%' + '" + txtFreight.Text.Trim + "' + '%' )  "
            End If
            If txtTotal.Text <> "" Then
                WhereClause = WhereClause + "  and ( Total LIKE '%' + '" + txtTotal.Text.Trim + "' + '%' )  "
            End If
            ' ''If txtStatus.Text <> "" Then
            ' ''    WhereClause = WhereClause + "  and ( QuotationResponse_Status LIKE '%' + '" + txtStatus.Text.Trim + "' + '%' )  "
            ' ''End If
            If ddlStatus.SelectedValue <> "" Then
                WhereClause = WhereClause + "  and ( QuotationResponse_Status = '" + ddlStatus.SelectedValue + "'  )  "
            End If
            'ds1 = MainBLL.FillQuotRespFilter(Hfgridview.Value, Session("UserId"), txtQRNO.Text.Trim, txtVendorName.Text.Trim, txtItem.Text.Trim, txtQuantity.Text.Trim, txtAmount.Text.Trim,
            '                                 txtPerUnit.Text.Trim, txtTax.Text.Trim, txtFreight.Text.Trim, txtTotal.Text.Trim, txtStatus.Text.Trim)
            If WhereClause <> "" Then
                ds1 = FilterBLL.FillNewFilter("QuotationResponseCRMFiltM", Session("UserId"), WhereClause)
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
                Session("dt1QRespNew") = dt1

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
        If txtQRNO.Text & txtVendorName.Text & txtItem.Text & txtQuantity.Text & txtAmount.Text & txtPerUnit.Text & txtTax.Text & txtFreight.Text & txtTotal.Text & txtStatus.Text <> "" Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

    Protected Sub BindLoad()
        Try
            Dim WhereClause As String = ""
            WhereClause = WhereClause + "  and	( convert(date, QuotationResponse_CreateDate, 105) >= '" + Date.Now.AddDays(-7).Date.ToString("yyyy-MM-dd") + "'  )  "

            If WhereClause <> "" Then
                ds1 = FilterBLL.FillNewFilter("QuotationResponseCRMFiltM", Session("UserId"), WhereClause)
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
                Session("dt1QRespNew") = dt1

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
    '        txtVendorName.Text = ""
    '        txtItem.Text = ""
    '        txtQuantity.Text = ""
    '        txtAmount.Text = ""
    '        txtPerUnit.Text = ""
    '        txtTax.Text = ""
    '        txtFreight.Text = ""
    '        txtTotal.Text = ""
    '        ddlStatus.SelectedValue = "Select"

    '    Catch ex As Exception

    '    End Try
    'End Sub
End Class
