'Imports CrystalDecisions.Shared
'Imports CrystalDecisions.CrystalReports.Engine

Partial Class QuotationNew
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
    Public countrate As Double = 0.0
    Public countrate1 As Double = 0.0
    Dim TotalAmount As Double = 0.0
    Dim rate As Double = 0.0
    Public OrderID As Integer
    '  Dim cryRpt As New ReportDocument()
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
    End Sub


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        hlnkAdd.NavigateUrl = Page.ResolveUrl("ModifyQuotation.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)))
        If Not IsPostBack Then

            Hfgridview.Value = "QuotationGVByAssignCRM"
            hfExcel.Value = "ExcelQuotationByAssign"
            BindLoad()
            'SearchControl.UhfExcelmode.Value = "ExcelQuotationByAssign"
            'BindGridview()
            CheckPrivilage()
            'txtSearch.Attributes.Add("onkeyup", [String].Format("javascript:__doPostBack('{0}','')", rpg.ClientID))

            ' ''If Session("UserRoleID") = 1 Then
            ' ''    btnExport.Visible = True
            ' ''Else
            ' ''    btnExport.Visible = False
            ' ''End If
        End If
        If Session("UserId") = Nothing Then

        Else

        End If

    End Sub

    Protected Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        If IsPostBack Then
            'If txtSearch.Text <> "" OrElse hfBackcount.Value = "1" Then
            '    'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" OrElse hfBackcount.Value = "1" Then
            '    getsearch()
            '    fillpage()
            'Else
            fillpage()
            'End If
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
            Session("dt1QNew") = dt1

            fillpage()
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Binding Account'" + ex.Message + ")", True)
        End Try
    End Sub
    Public Sub fillpage()
        Dim dt As New DataTable()
        'If txtSearch.Text <> "" Then
        '    'If txtSearch.Text <> "" OrElse TextBox1.Text <> "" OrElse TextBox2.Text <> "" OrElse TextBox3.Text <> "" OrElse TextBox4.Text <> "" OrElse TextBox5.Text <> "" OrElse TextBox6.Text <> "" OrElse TextBox7.Text <> "" OrElse TextBox8.Text <> "" OrElse TextBox9.Text <> "" OrElse TextBox10.Text <> "" Then
        '    dt = DirectCast(Session("dt2QNew"), DataTable)
        'Else

        dt = DirectCast(Session("dt1QNew"), DataTable)
        'End If
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


    'Public Sub getsearch()
    '    Try

    '        'date time column not working in search and footer
    '        dt2 = DirectCast(Session("dt1QNew"), DataTable)


    '        If txtSearch.Text <> "" Then
    '            Dim selectedTable1 As DataTable = dt2.AsEnumerable().Where(Function(r) (r.Field(Of String)("Quotation_No").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
    '                       (r.Field(Of String)("Quotation_Date").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
    '                        (r.Field(Of String)("Quotation_QuoStatus").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
    '                         (r.Field(Of Decimal)("FinalAmount").ToString().Contains(txtSearch.Text.ToUpper())) OrElse
    '                         (r.Field(Of String)("Acc_name").ToUpper().Contains(txtSearch.Text.ToUpper())) OrElse
    '            (r.Field(Of String)("AssignTo").ToUpper().Contains(txtSearch.Text.ToUpper()))
    '                            ).CopyToDataTable()

    '            Session("dt2QNew") = selectedTable1
    '            'Else
    '            '    Dim selectedTable1 As DataTable = dt2.AsEnumerable().Where(Function(r) (r.Field(Of String)("Acc_Name").ToUpper().Contains(TextBox1.Text.ToUpper())) AndAlso
    '            '               (r.Field(Of String)("Contact_ContactPerson").ToUpper().Contains(TextBox2.Text.ToUpper())) AndAlso
    '            '                (r.Field(Of String)("Contact_Landline").ToUpper().Contains(TextBox3.Text.ToUpper())) AndAlso
    '            '                 (r.Field(Of String)("Contact_Email").ToUpper().Contains(TextBox4.Text.ToUpper())) AndAlso
    '            '    (r.Field(Of String)("Contact_Mobile").ToUpper().Contains(TextBox5.Text.ToUpper())) AndAlso
    '            '    (r.Field(Of String)("city").ToUpper().Contains(TextBox6.Text.ToUpper())) AndAlso
    '            '    (r.Field(Of String)("AssignTo").ToUpper().Contains(TextBox7.Text.ToUpper())) AndAlso
    '            '    (r.Field(Of String)("Acc_OpenFrom").ToUpper().Contains(TextBox8.Text.ToUpper()))
    '            '               ).CopyToDataTable()

    '            '    Session("dt2QNew") = selectedTable1



    '        End If
    '    Catch ex As Exception
    '        '  Session["dt2"] = "1";
    '        Dim exception As New DataTable()
    '        exception.Clear()

    '        Session("dt2QNew") = exception
    '    End Try
    'End Sub
    Protected Sub Sorting(sender As Object, e As EventArgs)
        Try
            Dim Header As LinkButton = DirectCast(sender, LinkButton)

            If Not Session("dt1QNew") Is Nothing Then
                Dim dt As DataTable = Session("dt1QNew")
                If ViewState("SortDir") Is Nothing Or ViewState("SortDir") = "Asc" Then
                    dt.DefaultView.Sort = Header.ID
                    dt = dt.DefaultView.ToTable()
                    ViewState("SortDir") = "Desc"
                Else
                    dt.DefaultView.Sort = Header.ID & " DESC"
                    dt = dt.DefaultView.ToTable()
                    ViewState("SortDir") = "Asc"
                End If
                Session("dt1QNew") = dt
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
            If e.CommandName = "Delete" Then
                If deletestatus.Value = "yes" Then
                    Dim uid As Integer = Convert.ToInt32(e.CommandArgument.ToString())

                    Try
                        MainBLL.DeleteSI(MainId, Session("UserID"), "LeadDeleteSi", Session("Audlog_Id"))
                        BindNewGridview()
                    Catch ex As Exception
                        Dim error1 As String = ex.Message.Replace(Chr(34), "")
                        error1 = error1.Replace(Chr(39), "")

                        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                    End Try
                End If
            ElseIf e.CommandName = "createorder" Then
                'starts
                'If Session("UserId") = 28 Or Session("UserId") = 21 Then

                '    System.Threading.Thread.Sleep(19000)
                '    Response.Redirect("Quotation.aspx")
                'Else
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Try

                    Dim dtcheck As DataSet = QuotationBLL.Checkorderexist(index.ToString())
                    Dim checkcname As String = dtcheck.Tables(0).Rows(0)("checkname").ToString()
                    If checkcname = "Already Exist" Then

                        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Your trying to open Quotation through a invalid link, you will be redirected.');window.location='quotation.aspx'", True)
                    Else

                        Dim rnd As New Random()
                        Dim verfirycode As Integer = rnd.[Next](10000, 999999)
                        Dim dice As String = "OD" + rnd.[Next](10000, 999999).ToString() + " "
                        Dim tempDate As Date = Date.Now.ToString("yyyy-MM-dd HH:mm ")
                        Dim orderdate As String = tempDate
                        Dim dt As DataSet = QuotationBLL.getQuotation(index)
                        Dim dtUser As New DataTable
                        dtUser = dt.Tables(0)
                        Dim drLogin As DataRow
                        drLogin = dtUser.Rows(0)
                        Dim FreightTax As Double = ConfigurationManager.AppSettings("freightvalue")

                        If DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Currency").ToString()) = "USD" Then



                            OrderID = OrderBLL.InsertQuotationOrderE(dice, DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_TypeID").ToString()),
                                                              DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(1).Rows(0)("total").ToString()),
                                                              "Pending", DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_ModeOFPayment").ToString()),
                                                              DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(1).Rows(0)("TotalVat").ToString()),
                                                              Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Freight").ToString())).ToString("N2"),
                                                              Session("UserId"), "", "", "",
                                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_TermOFDelivery").ToString()),
                                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_TermsOfPayment").ToString()),
                                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_DispatchThrough").ToString()),
                                                              1,
                                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Id").ToString()),
                                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Currency").ToString()),
                                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_CurrencyRate").ToString()),
                                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_ModeOfTransport").ToString()),
                                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_CountryOfOrigin").ToString()),
                                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_CountryOfFinalDestination").ToString()),
                                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_PortOfLoading").ToString()),
                                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_PortOfDischarge").ToString()),
                                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_FinalDestination").ToString()),
                                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_TrmsPyt_Card_doc").ToString()),
                                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Doc_Clearance").ToString()),
                                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_OceanFreight").ToString()),
                                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Insurance").ToString()),
                                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_WithFreight").ToString()),
                                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_PrintIn").ToString())
                                                             )
                        Else
                            ' ''Dim freightamt As Double = Math.Round(Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Freight").ToString())) * CDbl(FreightTax) / 100).ToString("N2")'***MUBYN
                            Dim freightamt As Double = (Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Freight").ToString())) * CDbl(FreightTax) / 100).ToString("N2")
                            Dim totalamt As Double = Math.Round(CDbl(DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(1).Rows(0)("total").ToString())) + CDbl(DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(1).Rows(0)("TotalVat").ToString())) + freightamt).ToString("N2")
                            Dim totalVat As Double = CDbl(DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(1).Rows(0)("TotalVat").ToString())) + freightamt

                            OrderID = OrderBLL.InsertQuotationOrderD(dice, DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_TypeID").ToString()),
                                             totalamt.ToString(),
                                                 "Pending", DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_ModeOFPayment").ToString()),
                                               totalVat.ToString(),
                                                 Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Freight").ToString())).ToString("N2"),
                                                Session("UserId"), "", "", "", DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_TermOFDelivery").ToString()),
                                                DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_TermsOfPayment").ToString()),
                                                 DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_DispatchThrough").ToString()),
                                                1,
                                                DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Id").ToString()),
                                                 DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Currency").ToString()),
                                                 DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_CurrencyRate").ToString()),
                                                 DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_ModeOfTransport").ToString()),
                                                 DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_CountryOfOrigin").ToString()),
                                                 DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_CountryOfFinalDestination").ToString()),
                                                 DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_PortOfLoading").ToString()),
                                                 DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_PortOfDischarge").ToString()),
                                                 DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_FinalDestination").ToString()),
                                                 DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_TrmsPyt_Card_doc").ToString()),
                                                                      DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Doc_Clearance").ToString()),
                                                                      DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_OceanFreight").ToString()),
                                                                      DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Insurance").ToString()),
                                                                      DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_WithFreight").ToString()),
                                                                      FreightTax,
                                                                      DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_PrintIn").ToString())
                                                )
                        End If

                        'OrderBLL.InsertAddr("InsertOrderAddr", ddlShipAddr.SelectedValue, OrderID)


                        Dim discountId As Integer = DiscountBLL.MaxDiscountID
                        For Each dr As DataRow In dt.Tables(0).Rows
                            OrderBLL.Main_Order_Details(OrderID, DynamicparcelDataManipulation.FixNullFromDB(dr("ItemDt_ProductId").ToString()),
                                                      DynamicparcelDataManipulation.FixNullFromDB(dr("ItemDt_Qty").ToString()),
                                                         DynamicparcelDataManipulation.FixNullFromDB(dr("ItemDt_Rate").ToString()),
                                                DynamicparcelDataManipulation.FixNullFromDB(dr("ItemDt_Amount").ToString()), DynamicparcelDataManipulation.FixNullFromDB(dr("ItemDt_Vat").ToString()))





                            Dim custid As String = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_TypeID").ToString())
                            DiscountBLL.DeleteSingle(Convert.ToInt32(custid), DynamicparcelDataManipulation.FixNullFromDB(dr("ItemDt_ProductId").ToString()))

                            Dim sb As New StringBuilder
                            sb.Append("<root>")
                            '   For i As Integer = 0 To GridView1.Rows.Count - 1 Step 1
                            Dim productid As String = DynamicparcelDataManipulation.FixNullFromDB(dr("ItemDt_ProductId").ToString())
                            Dim discount As String = DynamicparcelDataManipulation.FixNullFromDB(dr("discount").ToString())
                            '    Dim txtdiscount As TextBox = discount
                            'If String.IsNullOrEmpty(txtdiscount.Text) Or txtdiscount.Text = "0" Then
                            'Else
                            sb.Append("<row Discount_ID='" & CStr(discountId) & "' Discount_CustId='" & custid & "' Discount_ProductId='" & productid & "' Discount_Discount='" & discount &
                                  "' Discount_CreatedDate='" & DateAndTime.DateString & "' Discount_CreatedID='" & Session("UserId") &
                                  "' Discount_ModifiedDate='" & DateAndTime.DateString & "' Discount_ModifiedID='" & Session("UserId") &
                                  "' Discount_Del='0' Discount_Status='Active'/>")
                            discountId = discountId + 1
                            ' End If
                            'Next
                            sb.Append("</root>")
                            DiscountBLL.Update(sb.ToString)

                        Next
                        hfassigntype.Value = "Order"
                        AddAssignTo(OrderID)
                        ' ''If DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Currency").ToString()) = "USD" Then
                        ' ''    Response.Redirect("EditSalesOrder.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(OrderID.ToString())) + "&click=1")
                        ' ''Else
                        ' ''    Dim host As String = HttpContext.Current.Request.Url.Host
                        ' ''    '' Session("OrderEmailSubj") = "New order has been placed-" + ordercode
                        ' ''    If host = "localhost" Then
                        ' ''        Response.Redirect("http://localhost:56361/PrintSalesOrdergst1.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(OrderID)) & "&tp=" + HttpUtility.UrlEncode(Security.Encrypt(0)))
                        ' ''        '  Response.Redirect("SalesOrders.aspx")
                        ' ''    Else
                        ' ''        Response.Redirect("http://b2b.swissbake.ch/PrintSalesOrdergst1.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(OrderID)) & "&tp=" + HttpUtility.UrlEncode(Security.Encrypt(0)))

                        ' ''    End If
                        ' ''End If
                        ' ''Order Payment Start
                        'QtnPaymnet commented by Mubyn it was not on live but was worked on shared database in Lockdown
                        ' '' ''Dim CheckQtnPayment As String = QtnPaymentBLL.CheckQtnPayment(index, "CheckQtnPayment")
                        ' '' ''If (CheckQtnPayment = "Already Exist") Then
                        ' '' ''    Dim dsQtn As DataSet = QtnPaymentBLL.ViewByID(index, "QtnPaymentbyID")
                        ' '' ''    Dim dtQtnPayment As New DataTable
                        ' '' ''    dtQtnPayment = dsQtn.Tables(0)
                        ' '' ''    Dim drQtn As DataRow
                        ' '' ''    drQtn = dtQtnPayment.Rows(0)
                        ' '' ''    Dim PayId As Integer = QtnPaymentBLL.InsertOrderPayment(DynamicparcelDataManipulation.FixNullFromDB(drQtn("QtnPayment_CustId").ToString()),
                        ' '' ''                                                            DynamicparcelDataManipulation.FixNullFromDB(drQtn("QtnPayment_Amount").ToString()),
                        ' '' ''                                                            DynamicparcelDataManipulation.FixNullFromDB(drQtn("QtnPayment_Mode").ToString()),
                        ' '' ''                                                            DynamicparcelDataManipulation.FixNullFromDB(drQtn("QtnPayment_Date").ToString()),
                        ' '' ''                                                            DynamicparcelDataManipulation.FixNullFromDB(drQtn("QtnPayment_PBankName").ToString()),
                        ' '' ''                                                            DynamicparcelDataManipulation.FixNullFromDB(drQtn("QtnPayment_No").ToString()),
                        ' '' ''                                                            DynamicparcelDataManipulation.FixNullFromDB(drQtn("QtnPayment_CreatedID").ToString()),
                        ' '' ''                                                            Session("EmpAuditLogID"))

                        ' '' ''    QtnPaymentBLL.InsertOrderPayRef(PayId, "Order", OrderID,
                        ' '' ''                                     DynamicparcelDataManipulation.FixNullFromDB(drQtn("QtnPayRef_Amount").ToString()),
                        ' '' ''                                     DynamicparcelDataManipulation.FixNullFromDB(drQtn("QtnPayRef_CreatedID").ToString()),
                        ' '' ''                                    OrderID, Session("EmpAuditLogID"))

                        ' '' ''End If

                        ' ''Order Payment End

                        Response.Redirect("EditSalesOrder.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(OrderID.ToString())) + "&click=1")
                    End If
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("Quotation", "statuslink", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
                '     End If ''ends
                ' ''Dim index As Integer = Convert.ToInt32(e.CommandArgument.ToString())
                ' ''Try

                ' ''    Dim dtcheck As DataSet = QuotationBLL.Checkorderexist(index.ToString())
                ' ''    Dim checkcname As String = dtcheck.Tables(0).Rows(0)("checkname").ToString()
                ' ''    If checkcname = "Already Exist" Then

                ' ''        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Your trying to open Quotation through a invalid link, you will be redirected.');window.location='quotation.aspx'", True)
                ' ''    Else

                ' ''        Dim rnd As New Random()
                ' ''        Dim verfirycode As Integer = rnd.[Next](10000, 999999)
                ' ''        Dim dice As String = "OD" + rnd.[Next](10000, 999999).ToString() + " "
                ' ''        Dim tempDate As Date = Date.Now.ToString("yyyy-MM-dd HH:mm ")
                ' ''        Dim orderdate As String = tempDate
                ' ''        Dim dt As DataSet = QuotationBLL.getQuotation(index)
                ' ''        Dim dtUser As New DataTable
                ' ''        dtUser = dt.Tables(0)
                ' ''        Dim drLogin As DataRow
                ' ''        drLogin = dtUser.Rows(0)
                ' ''        Dim FreightTax As Double = ConfigurationManager.AppSettings("freightvalue")

                ' ''        If DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Currency").ToString()) = "USD" Then



                ' ''            OrderID = OrderBLL.InsertQuotationOrderE(dice, DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_TypeID").ToString()),
                ' ''                                              DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(1).Rows(0)("total").ToString()),
                ' ''                                              "Pending", DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_ModeOFPayment").ToString()),
                ' ''                                              DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(1).Rows(0)("TotalVat").ToString()),
                ' ''                                              Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Freight").ToString())).ToString("N2"),
                ' ''                                              Session("UserId"), "", "", "",
                ' ''                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_TermOFDelivery").ToString()),
                ' ''                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_TermsOfPayment").ToString()),
                ' ''                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_DispatchThrough").ToString()),
                ' ''                                              1,
                ' ''                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Id").ToString()),
                ' ''                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Currency").ToString()),
                ' ''                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_CurrencyRate").ToString()),
                ' ''                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_ModeOfTransport").ToString()),
                ' ''                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_CountryOfOrigin").ToString()),
                ' ''                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_CountryOfFinalDestination").ToString()),
                ' ''                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_PortOfLoading").ToString()),
                ' ''                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_PortOfDischarge").ToString()),
                ' ''                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_FinalDestination").ToString()),
                ' ''                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_TrmsPyt_Card_doc").ToString()),
                ' ''                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Doc_Clearance").ToString()),
                ' ''                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_OceanFreight").ToString()),
                ' ''                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Insurance").ToString()),
                ' ''                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_WithFreight").ToString()),
                ' ''                                              DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_PrintIn").ToString())
                ' ''                                             )
                ' ''        Else
                ' ''            Dim freightamt As Double = Math.Round(Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Freight").ToString())) * CDbl(FreightTax) / 100).ToString("N2")
                ' ''            Dim totalamt As Double = CDbl(DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(1).Rows(0)("total").ToString())) + CDbl(DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(1).Rows(0)("TotalVat").ToString())) + freightamt
                ' ''            Dim totalVat As Double = CDbl(DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(1).Rows(0)("TotalVat").ToString())) + freightamt

                ' ''            OrderID = OrderBLL.InsertQuotationOrderD(dice, DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_TypeID").ToString()),
                ' ''                             totalamt.ToString(),
                ' ''                                 "Pending", DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_ModeOFPayment").ToString()),
                ' ''                               totalVat.ToString(),
                ' ''                                 Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Freight").ToString())).ToString("N2"),
                ' ''                                Session("UserId"), "", "", "", DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_TermOFDelivery").ToString()),
                ' ''                                DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_TermsOfPayment").ToString()),
                ' ''                                 DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_DispatchThrough").ToString()),
                ' ''                                1,
                ' ''                                DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Id").ToString()),
                ' ''                                 DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Currency").ToString()),
                ' ''                                 DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_CurrencyRate").ToString()),
                ' ''                                 DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_ModeOfTransport").ToString()),
                ' ''                                 DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_CountryOfOrigin").ToString()),
                ' ''                                 DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_CountryOfFinalDestination").ToString()),
                ' ''                                 DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_PortOfLoading").ToString()),
                ' ''                                 DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_PortOfDischarge").ToString()),
                ' ''                                 DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_FinalDestination").ToString()),
                ' ''                                 DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_TrmsPyt_Card_doc").ToString()),
                ' ''                                                      DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Doc_Clearance").ToString()),
                ' ''                                                      DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_OceanFreight").ToString()),
                ' ''                                                      DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_Insurance").ToString()),
                ' ''                                                      DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_WithFreight").ToString()),
                ' ''                                                      FreightTax,
                ' ''                                                      DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_PrintIn").ToString())
                ' ''                                )
                ' ''        End If



                ' ''        Dim discountId As Integer = DiscountBLL.MaxDiscountID
                ' ''        For Each dr As DataRow In dt.Tables(0).Rows
                ' ''            OrderBLL.Main_Order_Details(OrderID, DynamicparcelDataManipulation.FixNullFromDB(dr("ItemDt_ProductId").ToString()),
                ' ''                                      DynamicparcelDataManipulation.FixNullFromDB(dr("ItemDt_Qty").ToString()),
                ' ''                                         DynamicparcelDataManipulation.FixNullFromDB(dr("ItemDt_Rate").ToString()),
                ' ''                                DynamicparcelDataManipulation.FixNullFromDB(dr("ItemDt_Amount").ToString()), DynamicparcelDataManipulation.FixNullFromDB(dr("ItemDt_Vat").ToString()))





                ' ''            Dim custid As String = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Quotation_TypeID").ToString())
                ' ''            DiscountBLL.DeleteSingle(Convert.ToInt32(custid), DynamicparcelDataManipulation.FixNullFromDB(dr("ItemDt_ProductId").ToString()))

                ' ''            Dim sb As New StringBuilder
                ' ''            sb.Append("<root>")
                ' ''            '   For i As Integer = 0 To GridView1.Rows.Count - 1 Step 1
                ' ''            Dim productid As String = DynamicparcelDataManipulation.FixNullFromDB(dr("ItemDt_ProductId").ToString())
                ' ''            Dim discount As String = DynamicparcelDataManipulation.FixNullFromDB(dr("discount").ToString())
                ' ''            '    Dim txtdiscount As TextBox = discount
                ' ''            'If String.IsNullOrEmpty(txtdiscount.Text) Or txtdiscount.Text = "0" Then
                ' ''            'Else
                ' ''            sb.Append("<row Discount_ID='" & CStr(discountId) & "' Discount_CustId='" & custid & "' Discount_ProductId='" & productid & "' Discount_Discount='" & discount &
                ' ''                  "' Discount_CreatedDate='" & DateAndTime.DateString & "' Discount_CreatedID='" & Session("UserId") &
                ' ''                  "' Discount_ModifiedDate='" & DateAndTime.DateString & "' Discount_ModifiedID='" & Session("UserId") &
                ' ''                  "' Discount_Del='0' Discount_Status='Active'/>")
                ' ''            discountId = discountId + 1
                ' ''            ' End If
                ' ''            'Next
                ' ''            sb.Append("</root>")
                ' ''            DiscountBLL.Update(sb.ToString)

                ' ''        Next
                ' ''        hfassigntype.Value = "Order"
                ' ''        AddAssignTo(OrderID)
                ' ''        ' ''fillLead()
                ' ''        ' ''BindGridview()
                ' ''        Response.Redirect("EditSalesOrder.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(OrderID.ToString())) + "&click=1")

                ' ''    End If
                ' ''Catch ex As Exception
                ' ''    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                ' ''    error1 = error1.Replace(Chr(39), "")
                ' ''    ExecptionBLL.Insert("Quotation", "statuslink", error1, Session("UserId"))
                ' ''    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                ' ''End Try
            End If

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Deleting Class')", True)
        End Try
    End Sub
    Public Sub AddAssignTo(ByVal DID As Integer) 'function created by gayatri on 21-08-2017 for createOrder button on quotation page
        Try
            Dim HashAssignTo As Hashtable = New Hashtable
            Dim Count As Integer
            Dim hftype As String = hfassigntype.Value
            '  Dim DID As Integer
            ' Dim MainID As Integer
            If DID > 0 Then
                AssignToBLL.DeleteAssignTo(hftype, DID, Session("Audlog_Id"))
            End If
            Dim HCatid As Hashtable = If(Session("dassigntohash") IsNot Nothing, DirectCast(Session("dassigntohash"), Hashtable), Nothing)
            If HCatid IsNot Nothing Then
                HashAssignTo = Session("dassigntohash")
            Else
                HashAssignTo.Add(Session("UserId"), Session("UserName"))
            End If
            Count = AssignToBLL.MaxAssignTo
            Dim sb As New StringBuilder
            sb.Append("<root>")
            For i As Integer = 0 To HashAssignTo.Count - 1
                sb.Append("<row Assignto_ID='" & Count.ToString & "' Assignto_UserID='" & HashAssignTo.Keys(i) &
                         "' Assignto_Type= '" & hftype & "' Assignto_TypeID='" & DID & "' Assignto_CreatedID='" & Session("UserId") &
                         "' Assignto_CreatedDate='" & DateAndTime.DateString & "' Assignto_ModifiedID='" & Session("UserId") & "' Assignto_ModifiedDate='" & DateAndTime.DateString &
                          "' Assignto_Del='0' Assignto_Status='Active' />")
                Count = Count + 1
            Next
            sb.Append("</root>")
            AssignToBLL.XMLInsert(sb.ToString, Session("Audlog_Id"), "Order")
            Session("dassigntohash") = Nothing
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AssignToUserControl", "AddAssignTo", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try

            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=Quotation.xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            Dim Gridview2 As New GridView

            Dim dt As New DataTable()
            'dt = MainBLL.SearchGridViewByID(txtSearch.Text.Trim, Session("UserId"), hfExcel.Value)
           
            dt = DirectCast(Session("dt1QNew"), DataTable)
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
            ExecptionBLL.Insert("Quotation", "btnExport_Click", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub CheckPrivilage()
        Try
            Dim dt As DataSet = PrivilageBLL.CheckPrivilige(Session("UserRoleID"), "Account.aspx")
            Dim dtprivilage As New DataTable
            dtprivilage = dt.Tables(0)
            Dim drprivilage As DataRow
            If dtprivilage.Rows.Count = 0 Then
                hlnkAdd.Visible = False
                thEdit.Visible = False
                For i As Integer = 0 To rpgridview.Items.Count - 1
                    Dim tdEdit As HtmlTableCell = DirectCast(rpgridview.Items(i).FindControl("tdEdit"), HtmlTableCell)
                    tdEdit.Visible = False
                Next
                ' ''SearchControl.Uhfadd.Visible = False
                ' ''GridView1.Columns(0).Visible = False
                ' ''SearchControl.ULkadd.Visible = False

            Else

                drprivilage = dtprivilage.Rows(0)
                If (drprivilage("Prvg_RAdd").ToString()) = True Then
                    hlnkAdd.Visible = True
                    ' ''SearchControl.Uhfadd.Visible = True
                Else
                    hlnkAdd.Visible = False
                    ' ''SearchControl.Uhfadd.Visible = False
                End If
                If (drprivilage("Prvg_RUpdate").ToString()) = True Then
                    ' ''GridView1.Columns(0).Visible = True
                Else
                    thEdit.Visible = False
                    For i As Integer = 0 To rpgridview.Items.Count - 1
                        Dim tdEdit As HtmlTableCell = DirectCast(rpgridview.Items(i).FindControl("tdEdit"), HtmlTableCell)
                        tdEdit.Visible = False
                    Next
                    ' ''GridView1.Columns(0).Visible = False
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Account", "CheckPrivilage", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub rpgridview_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rpgridview.ItemDataBound
        Try
            If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
                Dim COUNTsTATUS As Integer = 0
                ' Dim lnkRevision As LinkButton = DirectCast(e.Item.FindControl("lnkRevision"), LinkButton)
                Dim lnkorder As LinkButton = DirectCast(e.Item.FindControl("lnkorder"), LinkButton)
                Dim lbluId As Literal = DirectCast(e.Item.FindControl("lbluId"), Literal)
                'Dim HyperLink2 As LinkButton = DirectCast(e.Item.FindControl("HyperLink2"), LinkButton)
                Dim lblAccId As Literal = DirectCast(e.Item.FindControl("lblAccId"), Literal)
                Dim vieworder As HtmlAnchor = DirectCast(e.Item.FindControl("vieworder"), HtmlAnchor)
                Dim lkedit As Label = DirectCast(e.Item.FindControl("lkedit"), Label)
                'Dim lkedit As HtmlAnchor = DirectCast(e.Item.FindControl("lkedit"), HtmlAnchor)
                Dim dtcheck As DataSet = QuotationBLL.Checkorderexist(lbluId.Text.Trim)
                Dim checkcname As String = dtcheck.Tables(0).Rows(0)("checkname").ToString()

                If (checkcname = "Already Exist") Then
                    lnkorder.Visible = False
                    ' ''lnkRevision.Visible = False
                    ' ''HyperLink2.Visible = False
                    lkedit.Visible = False
                    vieworder.Visible = True
                    ' If dtcheck.Tables(1).Rows.Count > 0 Then

                    vieworder.HRef = "EditSalesOrder.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(dtcheck.Tables(1).Rows(0)("Order_ID").ToString()))
                    'End If
                Else
                    lnkorder.Visible = True
                    ' ''lnkRevision.Visible = True
                    ' ''HyperLink2.Visible = True
                    lkedit.Visible = True
                    vieworder.Visible = False

                    Dim dsItem As DataSet = ItemDetailBLL.FillItemDT("Quotation", Convert.ToInt32(lbluId.Text), Convert.ToInt32(lblAccId.Text))

                    Dim dtItem As New DataTable
                    dtItem = dsItem.Tables(0)
                    If dtItem.Rows.Count > 0 Then
                        Dim count As Integer = 0
                        For Each row In dtItem.Rows
                            Dim drItem As DataRow
                            drItem = dtItem.Rows(count)
                            Dim ds As DataSet = ItemDetailBLL.DiscountItemDetail("CheckStatus", Convert.ToInt32(lbluId.Text), Convert.ToInt32(drItem("ItemDt_ID").ToString()), Convert.ToInt32(lblAccId.Text))
                            count = count + 1
                            Dim dt As New DataTable
                            dt = ds.Tables(0)
                            Dim dr As DataRow
                            dr = dt.Rows(0)
                            If (dr("status").ToString() = "Active") Then
                                COUNTsTATUS = COUNTsTATUS + 1
                            End If

                        Next
                        ' ''lnkRevision.Visible = IIf(COUNTsTATUS > 0, True, False)
                        If COUNTsTATUS > 0 Then
                            ' HyperLink2.Visible = False

                        End If
                    End If
                End If
                If dtcheck.Tables(2).Rows.Count > 0 Then

                    ' ''lnkRevision.Visible = False
                    ' ''HyperLink2.Visible = False
                    lkedit.Visible = False
                End If
            End If
        Catch ex As Exception

        End Try
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
            If txtQuotationNo.Text <> "" Then
                WhereClause = WhereClause + " and ( Quotation_No LIKE '%' + '" + txtQuotationNo.Text.Trim + "' + '%' ) "
                'WhereClause = WhereClause + " and ( Quotation_id = ( select Top 1 Quotation_Id from [tblQuotation] Where Quotation_No LIKE '%" + txtQuotationNo.Text.Trim + "%' )) "
            
			End If
            If txtQuotationDate.Text <> "" Then
                WhereClause = WhereClause + " And (isnull(convert(date,[Quotation_Date],103),'') = '" + txtQuotationDate.Text.Trim + "'  ) "
            End If
            ' ''If txtQuotationStatus.Text <> "" Then
            ' ''    WhereClause = WhereClause + " and ( Quotation_QuoStatus LIKE '%' + '" + txtQuotationStatus.Text.Trim + "' + '%' ) "
            ' ''End If
            If ddstatus.SelectedValue <> "Select" Then
                'WhereClause = WhereClause + " and ( Quotation_QuoStatus = '" + ddstatus.SelectedValue + "'  ) "
				WhereClause = WhereClause + " and ( Quotation_QuoStatus = '" + ddstatus.SelectedValue + "'  ) "
				
				 
            End If
            If txtAccPros.Text <> "" Then
                WhereClause = WhereClause + "  and ( Acc_name LIKE '%' + '" + txtAccPros.Text.Trim + "' + '%' )  "
            End If
            
   
            'If txtQuotationNo.Text <> "" Or txtQuotationDate.Text <> "" Or txtQuotationStatus.Text <> "" Or txtAccPros.Text <> "" Or txtAmount.Text <> "" Or txtAssignTo.Text <> "" Then
            'ds1 = MainBLL.FillQuotationFilter("FillQuotationCRMFilter", Session("UserId"), txtQuotationNo.Text.Trim, txtQuotationDate.Text.Trim,
            '                                 txtQuotationStatus.Text.Trim, txtAccPros.Text.Trim, txtAmount.Text.Trim, txtAssignTo.Text.Trim)
            If WhereClause <> "" Then
                ds1 = FilterBLL.FillNewFilter("FillQuotationCRMFiltM", Session("UserId"), WhereClause)
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
                Session("dt1QNew") = dt1

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
        If txtQuotationDate.Text & txtQuotationStatus.Text & txtAccPros.Text & txtAmount.Text & txtAssignTo.Text & txtQuotationNo.Text <> "" Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

    Protected Sub BindLoad()
        Try
            Dim WhereClause As String = ""
            WhereClause = WhereClause + "  and	( convert(date, Quotation_CreatedDate,105) >= '" + Date.Now.AddDays(-2).Date.ToString("yyyy-MM-dd") + "'  )  "

            If WhereClause <> "" Then
                ds1 = FilterBLL.FillNewFilter("FillQuotationCRMFiltM", Session("UserId"), WhereClause)
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
                Session("dt1QNew") = dt1

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
    '        txtQuotationNo.Text = ""
    '        txtQuotationDate.Text = ""
    '        ddstatus.SelectedValue = "Select"
    '        txtAccPros.Text = ""
    '        txtAmount.Text = ""
    '        txtAssignTo.Text = ""
    '    Catch ex As Exception

    '    End Try
    'End Sub
End Class
