
Partial Class SampleRequestReport
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            If Not IsPostBack Then
                'Dim tempDate As Date = Date.Now.AddMonths(-1).ToString("yyyy-MM-dd")
                Dim tempDate As Date = Date.Now.ToString("yyyy-MM-dd")
                Dim startOfMonth As New DateTime(tempDate.Year, tempDate.Month, 1)
                'Dim endOfMonth As DateTime = startOfMonth.AddMonths(1).AddDays(-1)
                Dim endOfMonth As DateTime = Date.Now.ToString("yyyy-MM-dd")
                txtfrom.Text = startOfMonth.ToString("yyyy-MM-dd")
                txtto.Text = endOfMonth.ToString("yyyy-MM-dd")

                'pnldemo.Visible = False
                '' btndashboard_Click(New Object(), New EventArgs())

                'FillddlCompany()
                'ddlUser_SelectedIndexChanged(Nothing, Nothing)
                ''ddlCompany_SelectedIndexChanged(Nothing, Nothing)
                'fillgridview()
                FillddlUser()
                FillddlProduct()
                fillgridview()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Report_DSR", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
#Region "FillDropdowns"

    Public Sub FillddlUser()
        Try
            'MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim ds As DataSet
            ' If MainID = 0 Then
            ds = DSRReportBLL.UserDropdown("UserDropDown")
            ddlUser.DataSource = ds.Tables(0)
            ddlUser.DataTextField = "Name"
            ddlUser.DataValueField = "ID"
            ddlUser.DataBind()
            ddlUser.Items.Insert(0, New ListItem("All", "0"))
            FillddlCompany()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")

            Throw ex
        End Try
    End Sub
    Public Sub FillddlCompany()
        Try
            Dim ds As DataSet
            If ddlUser.SelectedValue = 0 And ddcompanytype.SelectedValue = "All" Then
                ds = DSRReportBLL.CompanyDropdownById("CompanyDropDown", 1)
            ElseIf ddcompanytype.SelectedValue <> "All" Then
                ds = DSRReportBLL.CompanyDropdownById("CompanyDropDownbytype", 1, ddcompanytype.SelectedValue)
            Else
                ds = DSRReportBLL.CompanyDropdownById("CompanyDropDown", ddlUser.SelectedValue)
            End If
            ddlCompany.DataSource = ds.Tables(0)
            ddlCompany.DataTextField = "Acc_Name"
            ddlCompany.DataValueField = "ID"
            ddlCompany.DataBind()
            ddlCompany.Items.Insert(0, New ListItem("All", "0"))

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")

            Throw ex
        End Try
    End Sub
    Public Sub FillddlProduct()
        Try
            Dim ds As DataSet
            ds = DSRReportBLL.Dropdown("ProductDropDown")
            ddlProduct.DataSource = ds.Tables(0)
            ddlProduct.DataTextField = "Product_Name"
            ddlProduct.DataValueField = "Product_Id"
            ddlProduct.DataBind()
            ddlProduct.Items.Insert(0, New ListItem("All", "0"))

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")

            Throw ex
        End Try
    End Sub
#End Region
    

    Public Sub fillgridview()
        Dim ds As DataSet
        'Dim tlead, tprosect, taccount, lamount, pamount, aamount As Double
        Try
            Dim UserID1 As Integer
            If ddlUser.SelectedValue = 0 Then
                UserID1 = 0
            Else
                UserID1 = ddlUser.SelectedValue
            End If
            Dim str As String = ddlCompany.SelectedValue
            Dim strArr() As String
            strArr = str.Split("-")
            Dim CompanyID As Integer = strArr(0)
            Dim Type As String
            If CompanyID <> 0 Then
                Type = strArr(1)
            ElseIf ddcompanytype.SelectedValue = "All" Then
                Type = "None"
            Else
                Type = ddcompanytype.SelectedValue
            End If
            Dim ProdID As Integer = ddlProduct.SelectedValue


            'rpgridview.DataSource = DSRReportBLL.FillSampleReqReport(UserID1, txtfrom.Text, txtto.Text, "SampleReqReportView")
            ds = DSRReportBLL.FillSampleReqReport(UserID1, txtfrom.Text, txtto.Text, CompanyID, Type, ProdID, ddlStage.SelectedValue, "SampleReqReportView")
            rpgridview.DataSource = ds
            rpgridview.DataBind()

            If ds.Tables(0).Rows.Count = Nothing Then
                tblGrid.Visible = False
                div1.Visible = False
                div2.Visible = False
                div3.Visible = False
                div4.Visible = False
                lblfoot.Visible = True
            Else
                tblGrid.Visible = True
                If ddcompanytype.SelectedValue = "All" And ddlProduct.SelectedItem.Text = "All" And ddlCompany.SelectedItem.Text = "All" Then
                    litlead.Text = "Lead"
                    liaccount.Text = "Account"
                    liprospect.Text = "Prospect"

                    lblleadtotal.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Compute("SUM(qty)", "SampleRequest_Type = 'Lead'")))
                    lblleadamt.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Compute("SUM(Samplerate)", "SampleRequest_Type = 'Lead'"))).ToString("N2")

                    lblPtotal.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Compute("SUM(qty)", "SampleRequest_Type = 'Prospect'")))
                    lblpamt.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Compute("SUM(Samplerate)", "SampleRequest_Type = 'Prospect'"))).ToString("N2")
                    lblatotal.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Compute("SUM(qty)", "SampleRequest_Type = 'Account'")))
                    lblaamt.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Compute("SUM(Samplerate)", "SampleRequest_Type = 'Account'"))).ToString("N2")
                    lbaatotal.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Compute("SUM(qty)", "")))
                    labamtt1.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Compute("SUM(Samplerate)", ""))).ToString("N2")
                    div1.Visible = True
                    div2.Visible = True
                    div3.Visible = True
                    div4.Visible = True
                Else
                    div1.Visible = True
                    div4.Visible = False
                    lblleadtotal.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Compute("SUM(qty)", "")))
                    lblleadamt.Text = (Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Compute("SUM(Samplerate)", "")))).ToString("N2")
                    div2.Visible = False
                    div3.Visible = False
                    If ddlCompany.SelectedValue <> "0" Then
                        litlead.Text = ddlCompany.SelectedItem.Text
                    ElseIf ddlProduct.SelectedValue <> "0" Then
                        litlead.Text = ddlProduct.SelectedItem.Text
                    Else
                        litlead.Text = "Total"
                    End If

                End If
                lblfoot.Visible = False
            End If
            Dim FooterTemplate As Control = rpgridview.Controls(rpgridview.Controls.Count - 1).Controls(0)
            Dim lblQty As Label = TryCast(FooterTemplate.FindControl("lblQty"), Label)
            Dim lblrate As Label = TryCast(FooterTemplate.FindControl("lblrate"), Label)
            Dim lblprice As Label = TryCast(FooterTemplate.FindControl("lblprice"), Label)
            Dim trFooter As HtmlTableRow = TryCast(FooterTemplate.FindControl("trFooter"), HtmlTableRow)

            If ds.Tables(0).Rows.Count > 0 Then
                lblQty.Text = ds.Tables(0).Compute("Sum(qty)", String.Empty)
                lblrate.Text = CDbl(ds.Tables(0).Compute("Sum(Product_Rate)", String.Empty)).ToString("N2")
                lblprice.Text = CDbl(ds.Tables(0).Compute("Sum(Samplerate)", String.Empty)).ToString("N2")
            Else
                trFooter.Visible = False
                ' lblfoot.Visible = True
            End If




        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            'ExecptionBLL.Insert("Activity", "fillLead", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try

    End Sub
    Protected Sub btndashboard_Click(sender As Object, e As EventArgs) Handles btndashboard.Click
        Try
            fillgridview()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            'ExecptionBLL.Insert("Activity", "fillLead", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Private Sub ddcompanytype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddcompanytype.SelectedIndexChanged
        FillddlCompany()
    End Sub

    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=Sample Request Report.xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            Dim Gridview2 As New GridView

            Dim dt As New DataSet()
            'dt = MainBLL.SearchGridViewByID(txtSearch.Text.Trim, Session("UserId"), hfExcel.Value)
            Dim UserID1 As Integer
            If ddlUser.SelectedValue = 0 Then
                UserID1 = 0
            Else
                UserID1 = ddlUser.SelectedValue
            End If
            Dim str As String = ddlCompany.SelectedValue
            Dim strArr() As String
            strArr = str.Split("-")
            Dim CompanyID As Integer = strArr(0)
            Dim Type As String
            If CompanyID <> 0 Then
                Type = strArr(1)
            ElseIf ddcompanytype.SelectedValue = "All" Then
                Type = "None"
            Else
                Type = ddcompanytype.SelectedValue
            End If
            Dim ProdID As Integer = ddlProduct.SelectedValue
            dt = DSRReportBLL.FillSampleReqReport(UserID1, txtfrom.Text, txtto.Text, CompanyID, Type, ProdID, ddlStage.SelectedValue, "SampleReqReportView")

            Dim dtExc As DataTable = dt.Tables(0)
            dtExc.Columns.Remove("SampleRequest_Id")
            dtExc.Columns.Remove("ContactName")
            dtExc.Columns.Remove("SampleRequest_TypeId")
            dtExc.Columns.Remove("SampleRequestDetail_ProductId")
            dtExc.Columns.Remove("U_ID")
            ''dtExc.Columns.Remove("RowNumber")
            dtExc.Columns("RowNumber").ColumnName = "Sr No."
            dtExc.Columns("SampleRequest_Date").ColumnName = "Date"
            dtExc.Columns("SampleRequest_No").ColumnName = "Request No."
            dtExc.Columns("CompanyName").ColumnName = "Company Name"
            dtExc.Columns("SampleRequest_Type").ColumnName = "Type"
            dtExc.Columns("Product_Name").ColumnName = "Product Name"
            dtExc.Columns("qty").ColumnName = "Quantity"
            dtExc.Columns("Product_Rate").ColumnName = "Rate / KG"
            dtExc.Columns("Samplerate").ColumnName = "Price"
            dtExc.Columns("SampleRequest_SampleStatus").ColumnName = "Status"
            dtExc.Columns("AssignTo").ColumnName = "Owner"
            dtExc.Columns("Date").SetOrdinal(1)
            dtExc.Columns("Company Name").SetOrdinal(3)
            dtExc.Columns("Product Name").SetOrdinal(5)
            dtExc.Columns("Rate / KG").SetOrdinal(7)
            dtExc.Columns("Price").SetOrdinal(8)

            Gridview2.DataSource = dtExc
            'Gridview2.DataBind()
            Gridview2.AllowPaging = False
            Gridview2.DataBind()
            Gridview2.RenderControl(hw)

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

        End Try
    End Sub
End Class
