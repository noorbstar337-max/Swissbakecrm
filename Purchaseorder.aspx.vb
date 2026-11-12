Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Drawing

Imports System.Drawing.Imaging
Imports System.IO

Imports iTextSharp.text
Imports iTextSharp.text.pdf
Partial Class Purchaseorder
    Inherits _PageBaseClass
    ' using System.Text;
    Dim countrydt As DataTable
    Dim statedt As DataTable
    Public MainId As Integer
    Public VendorID As Integer
    Public VatAmount As Double = 0.0
    Public FooterTotalAmount As Double = 0.0
    Public TotalKg As Integer = 0
    Public name As String
    Public sb As New StringBuilder

    'Can you provide an example of how to implement PDF generation in PrintDocs.aspx.vb similar to the functionality in Purchaseorder.aspx?




    Private bc As New BarcodeLib.Barcode()
    Dim BitBarcode As New Bitmap(120, 80)
    Dim imagepath As String
    Dim invoiceNumber As String
    Dim currencytype As String
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            Response.Redirect("login.aspx")
        End If
    End Sub

    'Protected Sub btnPrintPDF_Click(sender As Object, e As EventArgs) Handles btnPrintPDF.Click

    '    Response.Write("MainId = " & MainId & "<br/>")
    '    Response.Write("VendorID = " & VendorID & "<br/>")
    '    Response.Write("MainId = " & MainId & "<br/>")
    '    Response.Write("VendorID = " & VendorID & "<br/>")
    '    Response.Write("CurrencyType = " & If(String.IsNullOrEmpty(currencytype), "Nothing", currencytype) & "<br/>")
    '    Response.End()
    '    Response.End()
    '    Dim url As String = "~/PrintDocs.aspx?tpy=Purchase" &
    '                    "&Id=" & HttpUtility.UrlEncode(Security.Encrypt(MainId.ToString())) &
    '                    "&type=" & HttpUtility.UrlEncode(Security.Encrypt(currencytype)) &
    '                    "&VendorID=" & HttpUtility.UrlEncode(Security.Encrypt(VendorID.ToString()))

    '    Response.Redirect(url, False)

    'End Sub
    Protected Sub btnPrintPDF_Click(sender As Object, e As EventArgs) Handles btnPrintPDF.Click

        Dim url As String = "~/PrintDocs.aspx?tpy=Purchase" &
                        "&Id=" & HttpUtility.UrlEncode(Security.Encrypt(MainId.ToString())) &
                        "&VendorID=" & HttpUtility.UrlEncode(Security.Encrypt(VendorID.ToString()))

        Response.Redirect(url, False)

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        MainId = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        VendorID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("VId")))
        If Not IsPostBack Then
            If Not Request.QueryString("Id") = Nothing Then
                Try
                    MainId = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                    VendorID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("VId")))
                    FillDetail()
                    Fillcompany()
                    '  FillMainProduct()
                    '  FillfooterDetail()
                    Filladdress()
                    fillbarcode()
                    If Not Request.QueryString("tp") = Nothing Then
                        Dim tp As Integer = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("tp")))
                        If tp = 0 Then
                            btnemail.Visible = True
                            btnExport.Visible = True
                        End If
                        If currencytype <> "INR" Then
                            btnemail.Visible = False
                        End If
                    End If
                    Session("mailsent") = "1"
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("PurchaseOrder", "Page_Load", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Else
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('There is no Purchase order to print!')", True)
            End If
        End If
    End Sub
    Protected Sub ExportToImage(sender As Object, e As EventArgs)
        ''Dim base64 As String = Request.Form(hfImageData.UniqueID).Split(",")(1)
        ''Dim bytes As Byte() = Convert.FromBase64String(base64)
        ''Response.Clear()
        ''Response.ContentType = "image/png"
        ''Response.AddHeader("Content-Disposition", "attachment; filename=HTML.png")
        ''Response.Buffer = True
        ''Response.Cache.SetCacheability(HttpCacheability.NoCache)
        ''Response.BinaryWrite(bytes)
        ''Response.End()
        'If Session("mailsent") = "1" Then
        'Else

        '    Dim base64 As String = Request.Form(hfImageData.UniqueID).Split(","c)(1)
        '    Dim bytes As Byte() = Convert.FromBase64String(base64)
        '    File.WriteAllBytes(Server.MapPath("~/images/test.png"), bytes)


        '    'Dim pdfpath As String = Server.MapPath("Images")
        '    Dim imagepath As String = Server.MapPath("Images")
        '    'Dim doc As New Document()
        '    'Try
        '    '    PdfWriter.GetInstance(doc, New FileStream(pdfpath & Convert.ToString("/Images.pdf"), FileMode.Create))
        '    '    doc.Open()

        '    '    Dim gif As Image = Image.GetInstance(imagepath & Convert.ToString("/Tahir.png"))
        '    '    doc.Add(gif)
        '    '    'Log error;
        '    'Catch ex As Exception
        '    'Finally
        '    '    doc.Close()
        '    'End Try

        '    Response.ContentType = "application/pdf"
        '    Response.AddHeader("content-disposition", "attachment;filename=test.pdf")

        '    '  Response.TransmitFile(Server.MapPath("~/Images/Test1.pdf"))
        '    Response.Cache.SetCacheability(HttpCacheability.NoCache)
        '    'Dim sw As New StringWriter()
        '    'Dim hw As New HtmlTextWriter(sw)
        '    'Me.Page.RenderControl(hw)
        '    'Dim sr As New StringReader(sw.ToString())
        '    Dim pdfDoc As New Document(PageSize.A4, 0.0F, 0.0F, 0.0F, 0.0F)


        '    'Dim htmlparser As New HTMLWorker(pdfDoc)
        '    'PdfWriter.GetInstance(pdfDoc, Response.OutputStream)


        '    'Dim a As String = "New FileStream(context.Server.MapPath(" + "Images" + ")" + "mypdf.pdf"
        '    ' PdfWriter.GetInstance(pdfDoc, New FileStream(imagepath, FileMode.Create))
        '    'System.Security.Permissions.FileIOPermissionAccess.Write,
        '    PdfWriter.GetInstance(pdfDoc, New FileStream(imagepath + "\test.pdf", FileMode.Create))
        '    pdfDoc.Open()

        '    Dim gif As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imagepath & Convert.ToString("/test.png"))
        '    gif.SetDpi(300, 300)
        '    'gif.ScalePercent(29.0F)
        '    'gif.ScaleAbsolute(790, 1122)
        '    gif.ScaleToFit(PageSize.A4.Width(), PageSize.A4.Height())
        '    gif.ScaleToFit(PageSize.A4.Width(), PageSize.A4.Height())
        '    ' Dim scaler As Single = ((Document.getPageSize().getWidth() - Document.LeftMargin() - Document.RightMargin() - indentation) / image.getWidth()) * 100

        '    ' image.scalePercent(scaler)

        '    pdfDoc.Add(gif)
        '    pdfDoc.Close()
        '    '   Response.Write(pdfDoc)
        '    'Response.[End]()
        '    Dim pdfPath As String
        '    Session("mailsent") = "1"
        '    pdfPath = "images/test.pdf"
        '    SendMailBLL.sendmailwithattach("faisal.shaikh@acaira.in".Trim, "Purchase Order", "test", Server.MapPath(pdfPath))
        '    'System.IO.File.Delete(pdfPath)
        '    Response.AddHeader("Refresh", "12;URL=polist.aspx")

        '    Response.[End]()
        ' End If
    End Sub
    Protected Sub btnemail_Click(sender As Object, e As EventArgs) Handles btnemail.Click
       

        If Session("mailsent") = "0" Then
        Else
            Response.Clear()

            'Dim pdfname As String = lblaccname.Text.Replace(" ", "_").Replace(".", "").Replace("\", "").Replace("/", "")
            Dim pdfname As String = lblinvoicenumber.Text.Replace(" ", "_").Replace(".", "").Replace("\", "").Replace("/", "")
            Dim base64 As String = Request.Form(hfImageData.UniqueID).Split(","c)(1)
            Dim bytes As Byte() = Convert.FromBase64String(base64)
            '   File.WriteAllBytes(Server.MapPath("~/images/test.png"), bytes)
            File.WriteAllBytes(Server.MapPath("~/EmailDocs/" + pdfname + ".png"), bytes)

            'Dim pdfpath As String = Server.MapPath("Images")
            Dim imagepath As String = Server.MapPath("EmailDocs")
            'Dim doc As New Document()
            'Try
            '    PdfWriter.GetInstance(doc, New FileStream(pdfpath & Convert.ToString("/Images.pdf"), FileMode.Create))
            '    doc.Open()

            '    Dim gif As Image = Image.GetInstance(imagepath & Convert.ToString("/Tahir.png"))
            '    doc.Add(gif)
            '    'Log error;
            'Catch ex As Exception
            'Finally
            '    doc.Close()
            'End Try

            Response.ContentType = "application/pdf"
            ' Response.AddHeader("content-disposition", "attachment;filename=test.pdf")
            Response.AddHeader("content-disposition", "attachment;filename=" + pdfname + ".pdf")


            ' Response.TransmitFile(Server.MapPath("~/Images/Test1.pdf"))
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Dim sw As New StringWriter()
            'Dim hw As New HtmlTextWriter(sw)
            'Me.Page.RenderControl(hw)
            'Dim sr As New StringReader(sw.ToString())

            Dim pdfDoc As New Document(PageSize.A4, 0.0F, 0.0F, 0.0F, 0.0F)


            'Dim htmlparser As New HTMLWorker(pdfDoc)
            'PdfWriter.GetInstance(pdfDoc, Response.OutputStream)



            PdfWriter.GetInstance(pdfDoc, New FileStream(imagepath + "\" + pdfname + ".pdf", FileMode.Create))
            pdfDoc.Open()

            '    Dim gif As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imagepath & Convert.ToString("/test.png"))
            Dim gif As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imagepath & Convert.ToString("/" + pdfname + ".png"))
            gif.SetDpi(300, 300)
            'gif.ScalePercent(29.0F)
            'gif.ScaleAbsolute(790, 1122)
            gif.ScaleToFit(PageSize.A4.Width(), PageSize.A4.Height())
            gif.ScaleToFit(PageSize.A4.Width(), PageSize.A4.Height())
            ' Dim scaler As Single = ((Document.getPageSize().getWidth() - Document.LeftMargin() - Document.RightMargin() - indentation) / image.getWidth()) * 100

            ' image.scalePercent(scaler)

            pdfDoc.Add(gif)
            pdfDoc.Close()

            '   Response.Write(pdfDoc)
            'Response.[End]()
            Dim pdfPath As String
            Session("mailsent") = "0"
            pdfPath = "EmailDocs/" + pdfname + ".pdf"



            Dim sb As New StringBuilder
            Dim count As Integer = 1
            Dim body As String = String.Empty
            Dim reader As StreamReader = New StreamReader(Server.MapPath("~/Email/purchaseorder.html"))
            body = reader.ReadToEnd

          


            ' body = body.Replace("#Table", sb.ToString)
            '  body = body.Replace("#Table", "Please find the copy of your invoice in the attachment.")
            If lblquotationNo.Text = "DIRECT" Then
                body = body.Replace("#VENDORQUOTATIONNO ", "")
            Else
                body = body.Replace("#VENDORQUOTATIONNO ", "<p>Your Quotation No " + vendorquotationcode.Value + " dated #VENDORQUOTEDATE  has been approved !</p>")
            End If
            body = body.Replace("#VENDORQUOTEDATE ", Quotation_Date.Value)
            If PURCHASEORDERNO.Value = "DIRECT" Then
                body = body.Replace("#PURCHASEORDERNO", "")
            Else
                body = body.Replace("#PURCHASEORDERNO", "  <p>PURCHASE ORDER 			:" + PURCHASEORDERNO.Value + "</p>")
            End If
            ' body = body.Replace("#PURCHASEORDERNO", Session("PURCHASEORDERNO"))
            body = body.Replace("#PURCHASEORDERAMT", PURCHASEORDERAMT.Value)
            body = body.Replace("#DELIVERYADDRESS", DELIVERYADDRESS.Value)
            body = body.Replace("#PAYMENTTERMS", paymentterms.Value)
            body = body.Replace("#NAME", Fname.Value)

            'Session("body") = body
            '  Session("Subject") = "Purchase Order against your Quotation " + Session("vendorquotationcode") + "| Swiss Bake Ingredients Pvt. Ltd."
            Session("adminemail") = "1"

            If lblquotationNo.Text = "DIRECT" Then
                'Temporary stop email 06-10-2023 by Noor
                'SendMailBLL.sendmailPurchasewithattach(vendoremailid.Value, "Purchase Order | Swiss Bake Ingredients Pvt. Ltd.", body, Server.MapPath(pdfPath))
            Else
                'Temporary stop email 06-10-2023 by Noor
                'SendMailBLL.sendmailPurchasewithattach(vendoremailid.Value, "Purchase Order against your Quotation " + vendorquotationcode.Value + " | Swiss Bake Ingredients Pvt. Ltd.", body, Server.MapPath(pdfPath))
            End If
            reader.Dispose()

            '  If pdfDoc.IsOpen Then

            pdfDoc.Close()
            MainId = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            VendorID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("VId")))

            QuotationResponseBLL.updateEmailstatus(MainId, VendorID)

            '  Session("deletefile") = Server.MapPath(pdfPath)
            '    System.IO.File.Delete(imagepath + "\test.pdf")
            ' System.IO.File.Delete(Server.MapPath(pdfPath))
            'End If
            '  Response.[Flush]()
            '  Response.Clear()
            'Dim processes As Process() = Process.GetProcessesByName("AcroRd32")
            'For Each process__1 As Process In processes


            '    process__1.Kill()
            'Next

            Response.Redirect("polist.aspx")
            'Response.AddHeader("Refresh", "12;URL=polist.aspx")
            'Response.Write("<script> setTimeout('Redirect()', 100);</script>")
            'Response.[Close]()
            '' System.IO.File.Delete(imagepath + "\test.pdf")
            'Response.[End]()
        End If
    End Sub
    Public Sub fillbarcode()
        Dim W As Integer = 260
        Dim H As Integer = 60
        Dim belowbarcode As String = invoiceNumber
        Dim barCode As String = invoiceNumber

        Dim imgBarCode As New System.Web.UI.WebControls.Image()
        'Barcode alignment
        bc.Alignment = BarcodeLib.AlignmentPositions.CENTER
        Dim type As BarcodeLib.TYPE = BarcodeLib.TYPE.UNSPECIFIED
        type = BarcodeLib.TYPE.CODE128

        If type <> BarcodeLib.TYPE.UNSPECIFIED Then
            bc.IncludeLabel = False
            bc.RotateFlipType = DirectCast([Enum].Parse(GetType(RotateFlipType), "rotatenoneflipnone", True), RotateFlipType)
            'label alignment and position
            bc.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER
            '===== Encoding performed here =====
            Me.BitBarcode = bc.Encode(type, belowbarcode, System.Drawing.Color.Black, System.Drawing.Color.White, W, H)
            'Dim filename As String = Path.GetFileName(_candId)
            'imagepath = "img/Barcode/" + filename + ".jpg"
            'Dim path1 As String = Server.MapPath("~/img/Barcode/" + filename)
            'BitBarcode.Save(path1 + ".jpg")
            Using ms As New MemoryStream()
                BitBarcode.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                Dim byteImage As Byte() = ms.ToArray()

                Convert.ToBase64String(byteImage)
                '  imgBarCode.ImageUrl = "data:image/png;base64," & Convert.ToBase64String(byteImage)TryCast(e.Item.FindControl("inwt"), System.Web.UI.WebControls.Label)
                '  Dim Image1 As System.Web.UI.WebControls.Image = TryCast(e.Item.FindControl("Image1"), System.Web.UI.WebControls.Image)
                Image1.ImageUrl = "data:image/png;base64," & Convert.ToBase64String(byteImage)
            End Using
        End If
    End Sub
    Public Sub FillDetail()
        Try
            MainId = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            ' Dim dt As DataSet = MainBLL.ViewByID(MainId, "InvoicePrintViewByID")
            Dim dt As DataSet = MainBLL.QResponseViewByID(MainId, VendorID, "PurchaseOrderProductViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            If dt.Tables(3).Rows.Count > 0 Then

                If String.IsNullOrEmpty(drLogin("QREHistory_PaymentTerms").ToString()) Then
                    lbltermsofpay.Text = "&nbsp;"
                Else
                    lbltermsofpay.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QREHistory_PaymentTerms").ToString())
                    paymentterms.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QREHistory_PaymentTerms").ToString())
                End If
                If paymentterms.Value = "Payment against documents" Then
                    lbltopdetail.Text = "Documents No"
                ElseIf paymentterms.Value = "Credit" Then
                    lbltopdetail.Text = "Credit"
                Else
                    trtopd.Visible = False
                End If
                If String.IsNullOrEmpty(drLogin("QuotationResponse_Currencytype").ToString()) Then
                Else
                    currencytype = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationResponse_Currencytype").ToString())
                End If
                'If Not String.IsNullOrEmpty(drLogin("QuotationResponse_Code").ToString()) Then
                '    lblsuplierref.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationResponse_Code").ToString())
                'End If
                'If Not String.IsNullOrEmpty(drLogin("QuotationResponse_Code").ToString()) Then
                '    lblsuplierref.Text += "/" + DynamicparcelDataManipulation.DateFormatfirstdate(drLogin("QuotationResponse_Date").ToString())
                'End If
                If String.IsNullOrEmpty(drLogin("QREHistory_QuotationTerms").ToString()) Then
                    ' trQuotationterm.Visible = False
                Else
                    lblquotationterms.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QREHistory_QuotationTerms").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("QREHistory_QuotationPlace").ToString()) Then
                    ' trQplace.Visible = False
                Else
                    lblqplace.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QREHistory_QuotationPlace").ToString())
                End If
                If String.IsNullOrEmpty(drLogin("QREHistory_Doc_Cre").ToString()) Then
                    ' trtopd.Visible = False
                Else
                    lbltopdetails.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QREHistory_Doc_Cre").ToString())

                End If
                If Not String.IsNullOrEmpty(drLogin("QuotationResponse_Code").ToString()) Then
                    lblquotationNo.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationResponse_Code").ToString())
                    'Session("vendorquotationcode") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationResponse_Code").ToString())
                    vendorquotationcode.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationResponse_Code").ToString())
                End If
                If Not String.IsNullOrEmpty(drLogin("QuotationResponse_Date").ToString()) Then
                    'lblQuotationdate.Text = DynamicparcelDataManipulation.DateFormatfirstdate(drLogin("QuotationResponse_Date").ToString())
                    'Session("Quotation_Date") = DynamicparcelDataManipulation.DateFormatfirstdate(drLogin("QuotationResponse_Date").ToString())
                    lblQuotationdate.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationResponse_Date").ToString())
                    Quotation_Date.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QuotationResponse_Date").ToString())
                Else
                    lblQuotationdate.Text = "&nbsp;"
                End If
                lbldate.Text = DynamicparcelDataManipulation.DateFormatfirstdate(dt.Tables(1).Rows(0)("PurchaseOrder_CreateDate").ToString()) 'DynamicparcelDataManipulation.AlphaDateFormat(drLogin("Invoice_Date").ToString())
                lblinvoicenumber.Text = DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(1).Rows(0)("PurchaseOrder_POCode").ToString())
                PURCHASEORDERNO.Value = DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(1).Rows(0)("PurchaseOrder_POCode").ToString())
                lblVendorcode.Text = DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(2).Rows(0)("Vendor_Code").ToString())
                invoiceNumber = lblinvoicenumber.Text
                ' hfcustid.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Order_CustId").ToString())
                hfcustid.Value = MainId
                ' hfFreight.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Invoice_Freight").ToString())
                hfcompanyid.Value = 1 'DynamicparcelDataManipulation.FixNullFromDB(drLogin("Invoice_BilledFrom").ToString())
                lbldate.Text = lbldate.Text.ToUpper
                Fname.Value = DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(3).Rows(0)("Contact_ContactPerson").ToString())

                lbltermofdelivery.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("QREHistory_DeliveryTerms").ToString())


                ' KeyBenefityList.InnerHtml = sb.ToString
                'If String.IsNullOrEmpty(drLogin("Invoice_Dispatch").ToString()) Then
                '    lbldispatch.Text = "&nbsp;"
                'Else
                '    lbldispatch.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Invoice_Dispatch").ToString())
                'End If
                If String.IsNullOrEmpty(dt.Tables(0).Rows(0)("Godown_Name").ToString()) Then
                    lbldestination.Text = "&nbsp;"
                Else
                    lbldestination.Text = DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(0).Rows(0)("Godown_Name").ToString())
                End If
                'If String.IsNullOrEmpty(drLogin("Invoice_DispatchDocNo").ToString()) Then
                '    lbldisdocno.Text = "&nbsp;"
                'Else
                '    lbldisdocno.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Invoice_DispatchDocNo").ToString())
                'End If
                lblgodownname.Text = DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(0).Rows(0)("Godown_Name").ToString())
                'lblgodownaddress.Text = DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(0).Rows(0)("Godown_Address").ToString())
                lblgodcpname.Text = DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(0).Rows(0)("Godown_ContactPerson").ToString())
                lblgodcpmobile.Text = DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(0).Rows(0)("Godown_Mobile").ToString())
                lblgodcpemail.Text = DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(0).Rows(0)("Godown_Email").ToString())


                name = DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(0).Rows(0)("Godown_Address").ToString())

                Dim name1() As String
                name1 = name.Split("*")
                'Dim sb1 As StringBuilder
                For Each name As String In name1
                    sb.Append("<li style='font-size: 12px; font-family: Arial; margin: 0px;'>" + name + "</li>")


                Next

                KeyBenefityList.InnerHtml = sb.ToString
                sb = sb.Clear()

                name = DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(0).Rows(0)("Godown_Address").ToString())
                Dim name2() As String
                name2 = name.Split("*")
                For Each name As String In name2
                    sb.Append("<li style='margin: 0px;'>" + name + "</li>")


                Next
                DELIVERYADDRESS.Value = sb.ToString

                '''' fill product 
                ' MainId = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                Dim ds As DataSet = dt 'MainBLL.QResponseViewByID(MainId, VendorID, "PurchaseOrderProductViewByID")
                grditemproduct.DataSource = ds
                grditemproduct.DataBind()
                If grditemproduct.Items.Count > 0 Then
                    Dim freight As Double = 0.0
                    Dim netwt As Double = 0.0
                    ' hfFreight.Value = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(0)("Freight").ToString())
                    For i As Integer = 0 To grditemproduct.Items.Count - 1
                        Dim ltamount As Label = DirectCast(grditemproduct.Items(i).FindControl("ltamount"), Label)
                        Dim ltPrdrate As Label = DirectCast(grditemproduct.Items(i).FindControl("ltPrdrate"), Label)
                        Dim lblvatinrs As Label = DirectCast(grditemproduct.Items(i).FindControl("lblvatinrs"), Label)
                        Dim hfPacking_Weight As HiddenField = DirectCast(grditemproduct.Items(i).FindControl("hfPacking_Weight"), HiddenField)
                        Dim ltquantity As Label = DirectCast(grditemproduct.Items(i).FindControl("ltquantity"), Label)
                        Dim ltkg As Label = DirectCast(grditemproduct.Items(i).FindControl("ltkg"), Label)
                        Dim imgrate As HtmlImage = DirectCast(grditemproduct.Items(i).FindControl("imgrate"), HtmlImage)
                        Dim lblinr As Label = DirectCast(grditemproduct.Items(i).FindControl("lblinr"), Label)
                        Dim lbldollar As Label = DirectCast(grditemproduct.Items(i).FindControl("lbldollar"), Label)
                        Dim lblinr1 As Label = DirectCast(grditemproduct.Items(i).FindControl("lblinr1"), Label)
                        Dim lbldollar1 As Label = DirectCast(grditemproduct.Items(i).FindControl("lbldollar1"), Label)
                        Dim lblinr2 As Label = DirectCast(grditemproduct.Items(i).FindControl("lblinr2"), Label)
                        Dim lbldollar2 As Label = DirectCast(grditemproduct.Items(i).FindControl("lbldollar2"), Label)


                        If currencytype <> "INR" Then
                            trbarcode.Visible = False
                            trinr.Visible = False
                            trdollar.Visible = True
                            trgst.Visible = False
                            lblinr.Visible = False
                            lbldollar.Visible = True
                            lblinr1.Visible = False
                            lbldollar1.Visible = True
                            lblinr2.Visible = False
                            lbldollar2.Visible = True
                            lblinrf.Visible = False
                            lbldollarf.Visible = True
                            lblinrf1.Visible = False
                            lbldollarf1.Visible = True
                            lblinrf2.Visible = False
                            lbldollarf2.Visible = True
                            lblinrf3.Visible = False
                            lbldollarf3.Visible = True
                            trexpcod.Visible = True
                            btnemail.Visible = False
                            'mgrate.Src = "img/PrintInvoice/d.png"
                            If vendorquotationcode.Value = "DIRECT" Then
                                trQuotation.Visible = False
                                trQuotationdate.Visible = False
                            Else
                                trQuotation.Visible = True
                                trQuotationdate.Visible = True
                            End If
                            trvendorgst.Visible = False
                            trVENDORstate.Visible = False
                            trQuotationterm.Visible = True
                            trQplace.Visible = True
                            trQuotationterm.Visible = True
                        Else
                            trbarcode.Visible = True
                            trinr.Visible = True
                            trdollar.Visible = False
                            trgst.Visible = True
                            lblinr.Visible = True
                            lbldollar.Visible = False
                            lblinr1.Visible = True
                            lbldollar1.Visible = False
                            lblinr2.Visible = True
                            lbldollar2.Visible = False
                            lblinrf.Visible = True
                            lbldollarf.Visible = False
                            lblinrf1.Visible = True
                            lbldollarf1.Visible = False
                            lblinrf2.Visible = True
                            lbldollarf2.Visible = False
                            lblinrf3.Visible = True
                            lbldollarf3.Visible = False
                            trQuotationterm.Visible = True
                            trQplace.Visible = False
                            trexpcod.Visible = False
                            trQuotationterm.Visible = False
                            If vendorquotationcode.Value = "DIRECT" Then
                                trQuotation.Visible = False
                                trQuotationdate.Visible = False
                            Else
                                trQuotation.Visible = True
                                trQuotationdate.Visible = True
                            End If
                        End If
                        'ltkg.Text = ""
                        ' ltkg.Text = CInt(hfPacking_Weight.Value) * CInt(ltquantity.Text)
                        ' TotalKg = TotalKg + Convert.ToInt32(ltkg.Text)

                        VatAmount = VatAmount + lblvatinrs.Text
                        FooterTotalAmount = FooterTotalAmount + ltamount.Text
                        If ds.Tables(1).Rows(0)("PurchaseOrder_Code").ToString() = "MULTIPLE" Then

                            freight = freight + DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(i)("Freight").ToString())
                        End If

                        netwt = netwt + DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(i)("QRERawmaterial_Qty").ToString())
                        '  Dim ltamount As Literal = DirectCast(grditemproduct.Rows(i).FindControl("ltamount"), Literal)
                        ' Dim lblvatinrs As Label = DirectCast(grditemproduct.Rows(i).FindControl("lblvatinrs"), Label)
                        Dim lblvat As Label = DirectCast(grditemproduct.Items(i).FindControl("lblvat"), Label)
                        '  Dim txtvat As TextBox = DirectCast(grditemproduct.Rows(i).FindControl("txtvat"), TextBox)

                        'VatAmount = VatAmount + lblvatinrs.Text
                        Dim vat As Double = (lblvatinrs.Text / ltamount.Text) * 100
                        'lblvat.Text = (vat).ToString("N2")
                        'lblvat.Text = Math.Round(CDbl(vat)).ToString("N2")
                        lblvat.Text = Math.Round(CDbl(vat), 1, MidpointRounding.AwayFromZero).ToString("N2") ' vat.ToString("N2")
                    Next
                    '  freight = freight + DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(0)("Freight").ToString())
                    If ds.Tables(1).Rows(0)("PurchaseOrder_Code").ToString() <> "MULTIPLE" Then

                        freight = freight + DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(0)("Freight").ToString())
                    End If

                    hfFreight.Value = freight
                    '   lbltotalkg.Text = "5"
                    'lbltotalkg.Text = TotalKg.ToString
                    Dim unit As String = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(0)("Quantity").ToString())
                    ' unit = unit.LastIndexOf(" ")
                    '  Dim newString As String =
                    lbltotalkg.Text = netwt.ToString("N2") + " " + unit.Remove(0, unit.IndexOf(" ") + 1) ' DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Compute("sum(QRERawmaterial_Qty)", String.Empty))
                    '   lbltotalkg.Text = lbltotalkg.Text.Replace("Each", " Nos.")
                    lblsubtotal.Text = Math.Round(FooterTotalAmount).ToString("N2")
                    lblfreight.Text = Math.Round(Convert.ToDouble(hfFreight.Value)).ToString("N2")
                    FooterTotalAmount = Math.Round(FooterTotalAmount + VatAmount + Convert.ToDouble(lblfreight.Text))
                    lttotalamount.Text = FooterTotalAmount.ToString("N2")
                    PURCHASEORDERAMT.Value = lttotalamount.Text
                    lttotalvat.Text = Math.Round(VatAmount).ToString("N2")
                    lblamountword.Text = MainBLL.NumbersToWords(FooterTotalAmount) + " Only"
                    lblvatword.Text = MainBLL.NumbersToWords(VatAmount) + " Only"
                End If
            Else

                Dim message As String = "alert('Please save State of vendor first');window.location='ModifyVendor.aspx?chk=e&Id=" + Request.QueryString("VId").ToString() + "';"
                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", message, True)

                '  Dim link As String = Request.QueryString("VId")
                'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Please select State of vendor');window.location='ModifyVendor.aspx'", True)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PurchaseOrder", "FillDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub Fillcompany()
        Try
            If hfcompanyid.Value = 1 Then
                'mumbank.Visible = True
                'otherbank.Visible = False
            Else
                ' mumbank.Visible = False
                'otherbank.Visible = True
            End If
            'Dim dt As DataSet = MainBLL.ViewByID(hfcompanyid.Value, "CompanyViewByID")
            Dim dt As DataSet = QuotationRequestBLL.FillGridViewByID("emailvendor", MainId)
            Dim dtFaq As New DataTable
            dtFaq = dt.Tables(0)
            Dim drFaqRow As DataRow
            drFaqRow = dtFaq.Rows(0)
            lblcompanyName.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_Name").ToString())
            lblDto.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_Name").ToString().Remove(drFaqRow("Company_Name").ToString.IndexOf("(")))
            lblcompanyaddress.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_Address").ToString())
            lblCompanyEmail.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_EmailId").ToString())
            lblcompanypan.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_PAN").ToString())
            lblcompanyvat.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_GST").ToString())
            lblcompanycst.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("Company_State").ToString())

            'faisal  uppercase 
            lblcompanyName.Text = lblcompanyName.Text.ToUpper()
            lblcompanyaddress.Text = lblcompanyaddress.Text.ToUpper()


        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("urchaseOrder", "Fillcompany", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillMainProduct()
        Try
            MainId = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim ds As DataSet = MainBLL.QResponseViewByID(MainId, VendorID, "PurchaseOrderProductViewByID")
            grditemproduct.DataSource = ds
            grditemproduct.DataBind()
            If grditemproduct.Items.Count > 0 Then
                '   Dim lab As Label = TryCast(item.FindControl("lblName"), Label)
                '   Dim lttotalamount As Label = DirectCast(grditemproduct.FindControl("lttotalamount"), Label)
                '  Dim lttotalvat As Label = DirectCast(grditemproduct.FindControl("lttotalvat"), Label)
                '  Dim lblsubtotal As Label = DirectCast(grditemproduct.FindControl("lblsubtotal"), Label)
                '  Dim lblfreight As Label = DirectCast(grditemproduct.FindControl("lblfreight"), Label)
                '  Dim lbltotalkg As Label = TryCast(grditemproduct.FindControl("lbltotalkg"), Label)
                hfFreight.Value = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(0)("Freight").ToString())
                For i As Integer = 0 To grditemproduct.Items.Count - 1
                    Dim ltamount As Label = DirectCast(grditemproduct.Items(i).FindControl("ltamount"), Label)
                    Dim ltPrdrate As Label = DirectCast(grditemproduct.Items(i).FindControl("ltPrdrate"), Label)
                    Dim lblvatinrs As Label = DirectCast(grditemproduct.Items(i).FindControl("lblvatinrs"), Label)
                    Dim hfPacking_Weight As HiddenField = DirectCast(grditemproduct.Items(i).FindControl("hfPacking_Weight"), HiddenField)
                    Dim ltquantity As Label = DirectCast(grditemproduct.Items(i).FindControl("ltquantity"), Label)
                    Dim ltkg As Label = DirectCast(grditemproduct.Items(i).FindControl("ltkg"), Label)
                    'ltkg.Text = ""
                    ' ltkg.Text = CInt(hfPacking_Weight.Value) * CInt(ltquantity.Text)
                    ' TotalKg = TotalKg + Convert.ToInt32(ltkg.Text)

                    VatAmount = VatAmount + lblvatinrs.Text
                    FooterTotalAmount = FooterTotalAmount + ltamount.Text



                    '  Dim ltamount As Literal = DirectCast(grditemproduct.Rows(i).FindControl("ltamount"), Literal)
                    ' Dim lblvatinrs As Label = DirectCast(grditemproduct.Rows(i).FindControl("lblvatinrs"), Label)
                    Dim lblvat As Label = DirectCast(grditemproduct.Items(i).FindControl("lblvat"), Label)
                    '  Dim txtvat As TextBox = DirectCast(grditemproduct.Rows(i).FindControl("txtvat"), TextBox)

                    'VatAmount = VatAmount + lblvatinrs.Text
                    Dim vat As Double = (lblvatinrs.Text / ltamount.Text) * 100
                    'lblvat.Text = (vat).ToString("N2")
                    'lblvat.Text = Math.Round(CDbl(vat)).ToString("N2")
                    lblvat.Text = vat.ToString("N2")
                Next
                '   lbltotalkg.Text = "5"
                'lbltotalkg.Text = TotalKg.ToString
                lbltotalkg.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(0)("Quantity").ToString())
                '   lbltotalkg.Text = lbltotalkg.Text.Replace("Each", " Nos.")
                lblsubtotal.Text = Math.Round(FooterTotalAmount).ToString("N2")
                lblfreight.Text = Math.Round(Convert.ToDouble(hfFreight.Value)).ToString("N2")
                FooterTotalAmount = Math.Round(FooterTotalAmount + VatAmount + Convert.ToDouble(lblfreight.Text))
                lttotalamount.Text = FooterTotalAmount.ToString("N2")
                PURCHASEORDERAMT.Value = lttotalamount.Text
                lttotalvat.Text = Math.Round(VatAmount).ToString("N2")
                lblamountword.Text = MainBLL.NumbersToWords(FooterTotalAmount) + " Only"
                lblvatword.Text = MainBLL.NumbersToWords(VatAmount) + " Only"
            End If
            'If grditemproduct.Rows.Count > 0 Then
            '    Dim lttotalamount As Label = DirectCast(grditemproduct.FooterRow.FindControl("lttotalamount"), Label)
            '    Dim lttotalvat As Label = DirectCast(grditemproduct.FooterRow.FindControl("lttotalvat"), Label)
            '    Dim lblsubtotal As Label = DirectCast(grditemproduct.FooterRow.FindControl("lblsubtotal"), Label)
            '    Dim lblfreight As Label = DirectCast(grditemproduct.FooterRow.FindControl("lblfreight"), Label)
            '    Dim lbltotalkg As Label = DirectCast(grditemproduct.FooterRow.FindControl("lbltotalkg"), Label)

            '    For i As Integer = 0 To grditemproduct.Rows.Count - 1
            '        Dim ltamount As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltamount"), Label)
            '        Dim ltPrdrate As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltPrdrate"), Label)
            '        Dim lblvatinrs As Label = DirectCast(grditemproduct.Rows(i).FindControl("lblvatinrs"), Label)
            '        Dim hfPacking_Weight As HiddenField = DirectCast(grditemproduct.Rows(i).FindControl("hfPacking_Weight"), HiddenField)
            '        Dim ltquantity As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltquantity"), Label)
            '        Dim ltkg As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltkg"), Label)
            '        ltkg.Text = CInt(hfPacking_Weight.Value) * CInt(ltquantity.Text)
            '        TotalKg = TotalKg + Convert.ToInt32(ltkg.Text)
            '        ltPrdrate.Text = Math.Round(Convert.ToDouble(ltPrdrate.Text)).ToString("N2")
            '        ltamount.Text = Math.Round(Convert.ToDouble(ltamount.Text)).ToString("N2")
            '        lblvatinrs.Text = Math.Round(Convert.ToDouble(lblvatinrs.Text)).ToString("N2")
            '        VatAmount = VatAmount + lblvatinrs.Text
            '        FooterTotalAmount = FooterTotalAmount + ltamount.Text
            '        ltamount.Text = CDbl(ltamount.Text).ToString("N2")
            '        lblvatinrs.Text = CDbl(lblvatinrs.Text).ToString("N2")


            '        '  Dim ltamount As Literal = DirectCast(grditemproduct.Rows(i).FindControl("ltamount"), Literal)
            '        ' Dim lblvatinrs As Label = DirectCast(grditemproduct.Rows(i).FindControl("lblvatinrs"), Label)
            '        Dim lblvat As Label = DirectCast(grditemproduct.Rows(i).FindControl("lblvat"), Label)
            '        '  Dim txtvat As TextBox = DirectCast(grditemproduct.Rows(i).FindControl("txtvat"), TextBox)

            '        'VatAmount = VatAmount + lblvatinrs.Text
            '        Dim vat As Double = (lblvatinrs.Text / ltamount.Text) * 100
            '        'lblvat.Text = (vat).ToString("N2")
            '        lblvat.Text = Math.Round(CDbl(vat)).ToString("N2")
            '    Next
            '    lbltotalkg.Text = TotalKg.ToString
            '    lblsubtotal.Text = Math.Round(FooterTotalAmount).ToString("N2")
            '    lblfreight.Text = Math.Round(Convert.ToDouble(hfFreight.Value)).ToString("N2")
            '    FooterTotalAmount = Math.Round(FooterTotalAmount + VatAmount + Convert.ToDouble(lblfreight.Text))
            '    lttotalamount.Text = FooterTotalAmount.ToString("N2")
            '    lttotalvat.Text = Math.Round(VatAmount).ToString("N2")
            '    lblamountword.Text = InvoiceBLL.NumbersToWords(FooterTotalAmount) + " Only"
            '    lblvatword.Text = InvoiceBLL.NumbersToWords(VatAmount) + " Only"
            'End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PurchaseOrder", "FillMainProduct", error1, Session("UserId"))
            Throw ex
        End Try
    End Sub

    Public Sub FillfooterDetail()
        '   Try
        '    MainId = hfcustid.Value

        '    'Dim dt As DataSet = MainBLL.ViewByID(MainID, "ACCTaxationDetail")
        '    Dim dt As DataSet = MainBLL.QResponseViewByID(MainId, VendorID, "PurchaseOrderProductViewByID")
        '    Dim dtUser As New DataTable
        '    dtUser = dt.Tables(3)
        '    If dtUser.Rows.Count > 0 Then
        '        Dim drLogin As DataRow
        '        drLogin = dtUser.Rows(0)
        '        '   lblbuyercst.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("vendor_State").ToString())
        '        '  lblbuyervat.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Vendor_GstNo").ToString())
        '        '  '''''   'lblbuyervat.Text += " / " + DynamicparcelDataManipulation.FixNullFromDB(drLogin("Cust_Tin").ToString())

        '    End If
        'Catch ex As Exception
        '    Dim error1 As String = ex.Message.Replace(Chr(34), "")
        '    error1 = error1.Replace(Chr(39), "")
        '    ExecptionBLL.Insert("PurchaseOrder", "FillfooterDetail", error1, Session("UserId"))
        '    'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        '    Throw ex
        'End Try
    End Sub


    Private Sub Filladdress()
        Try
            countrydt = MainBLL.Dropdown("CountryDropDown").Tables(0)
            statedt = MainBLL.Dropdown("ALLStateDropDown").Tables(0)
            MainId = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))

            'MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim CustId As Integer = hfcustid.Value
            Dim dt As DataSet = MainBLL.QResponseViewByID(MainId, VendorID, "PurchaseOrderProductViewByID")
            Dim dtOrder As New DataTable
            dtOrder = dt.Tables(0)
            Dim drOrderRow As DataRow
            drOrderRow = dtOrder.Rows(0)
            dtOrder = dt.Tables(0)
            drOrderRow = dtOrder.Rows(0)

            lblaccname.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Vendor_Name").ToString()) ' + " - " + DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Acc_Code").ToString())
            ' lblaccname2.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Vendor_Name").ToString()) ' + " - " + DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Acc_Code").ToString())
            'lblcode.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Acc_Code").ToString())
            'lblcode2.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Acc_Code").ToString())
            lblbilladdress.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Vendor_Address").ToString())
            lblbillcity.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Vendor_City").ToString())
            Dim country As Array = countrydt.Select("ID = '" + drOrderRow("Vendor_Country").ToString() + "'")
            If country.Length <> 0 Then
                lblbillpincode.Text = country(0)(1).ToString + " "
            End If
            Dim state As Array = statedt.Select("ID = '" + drOrderRow("Vendor_State").ToString() + "'")
            If state.Length <> 0 Then
                lblbillpincode.Text += state(0)(1).ToString + "- "
            End If
            lblbillpincode.Text += DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Vendor_PinCode").ToString())


            If dtOrder.Rows.Count > 0 Then
                drOrderRow = dtOrder.Rows(0)
                'lblshipaddress.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Vendor_Address").ToString())
                ' lblshipcity.Text = DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Vendor_City").ToString())
                country = countrydt.Select("ID = '" + drOrderRow("Vendor_Country").ToString() + "'")
                If country.Length <> 0 Then
                    'lblshippincode.Text = country(0)(1).ToString + " "
                End If
                state = statedt.Select("ID = '" + drOrderRow("Vendor_State").ToString() + "'")
                If state.Length <> 0 Then
                    ' lblshippincode.Text += state(0)(1).ToString + "- "
                End If
                ' lblshippincode.Text += DynamicparcelDataManipulation.FixNullFromDB(drOrderRow("Vendor_City").ToString())
            End If

            'faisal uppercase 
            lblaccname.Text = lblaccname.Text.ToUpper
            ' lblaccname2.Text = lblaccname2.Text.ToUpper
            lblbilladdress.Text = lblbilladdress.Text.ToUpper
            lblbillcity.Text = lblbillcity.Text.ToUpper
            '  lblshipaddress.Text = lblshipaddress.Text.ToUpper
            '  lblshipcity.Text = lblshipcity.Text.ToUpper



            ''
            'footerdetail using here insted of calling above again
            lblbuyercst.Text = DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(3).Rows(0)("vendor_State").ToString())
            lblbuyervat.Text = DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(3).Rows(0)("Vendor_GstNo").ToString())
            ' Session("vendoremailid") = DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(4).Rows(0)("Contact_Email").ToString())
            vendoremailid.Value = DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(4).Rows(0)("Contact_Email").ToString())
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    'Protected Sub grditemproduct_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles grditemproduct.ItemDataBound
    '    If grditemproduct.Items.Count > 0 Then
    '        '   Dim lab As Label = TryCast(item.FindControl("lblName"), Label)
    '        Dim lttotalamount As Label = DirectCast(grditemproduct.FindControl("lttotalamount"), Label)
    '        Dim lttotalvat As Label = DirectCast(grditemproduct.FindControl("lttotalvat"), Label)
    '        Dim lblsubtotal As Label = DirectCast(grditemproduct.FindControl("lblsubtotal"), Label)
    '        Dim lblfreight As Label = DirectCast(grditemproduct.FindControl("lblfreight"), Label)
    '        Dim lbltotalkg As Label = DirectCast(grditemproduct.FindControl("lbltotalkg"), Label)

    '        For i As Integer = 0 To grditemproduct.Items.Count - 1
    '            Dim ltamount As Label = DirectCast(grditemproduct.Items(i).FindControl("ltamount"), Label)
    '            Dim ltPrdrate As Label = DirectCast(grditemproduct.Items(i).FindControl("ltPrdrate"), Label)
    '            Dim lblvatinrs As Label = DirectCast(grditemproduct.Items(i).FindControl("lblvatinrs"), Label)
    '            Dim hfPacking_Weight As HiddenField = DirectCast(grditemproduct.Items(i).FindControl("hfPacking_Weight"), HiddenField)
    '            Dim ltquantity As Label = DirectCast(grditemproduct.Items(i).FindControl("ltquantity"), Label)
    '            Dim ltkg As Label = DirectCast(grditemproduct.Items(i).FindControl("ltkg"), Label)
    '            ltkg.Text = CInt(hfPacking_Weight.Value) * CInt(ltquantity.Text)
    '            TotalKg = TotalKg + Convert.ToInt32(ltkg.Text)
    '            ltPrdrate.Text = Math.Round(Convert.ToDouble(ltPrdrate.Text)).ToString("N2")
    '            ltamount.Text = Math.Round(Convert.ToDouble(ltamount.Text)).ToString("N2")
    '            lblvatinrs.Text = Math.Round(Convert.ToDouble(lblvatinrs.Text)).ToString("N2")
    '            VatAmount = VatAmount + lblvatinrs.Text
    '            FooterTotalAmount = FooterTotalAmount + ltamount.Text
    '            ltamount.Text = CDbl(ltamount.Text).ToString("N2")
    '            lblvatinrs.Text = CDbl(lblvatinrs.Text).ToString("N2")


    '            '  Dim ltamount As Literal = DirectCast(grditemproduct.Rows(i).FindControl("ltamount"), Literal)
    '            ' Dim lblvatinrs As Label = DirectCast(grditemproduct.Rows(i).FindControl("lblvatinrs"), Label)
    '            Dim lblvat As Label = DirectCast(grditemproduct.Items(i).FindControl("lblvat"), Label)
    '            '  Dim txtvat As TextBox = DirectCast(grditemproduct.Rows(i).FindControl("txtvat"), TextBox)

    '            'VatAmount = VatAmount + lblvatinrs.Text
    '            Dim vat As Double = (lblvatinrs.Text / ltamount.Text) * 100
    '            'lblvat.Text = (vat).ToString("N2")
    '            lblvat.Text = Math.Round(CDbl(vat)).ToString("N2")
    '        Next
    '        lbltotalkg.Text = TotalKg.ToString
    '        lblsubtotal.Text = Math.Round(FooterTotalAmount).ToString("N2")
    '        lblfreight.Text = Math.Round(Convert.ToDouble(hfFreight.Value)).ToString("N2")
    '        FooterTotalAmount = Math.Round(FooterTotalAmount + VatAmount + Convert.ToDouble(lblfreight.Text))
    '        lttotalamount.Text = FooterTotalAmount.ToString("N2")
    '        lttotalvat.Text = Math.Round(VatAmount).ToString("N2")
    '        lblamountword.Text = InvoiceBLL.NumbersToWords(FooterTotalAmount) + " Only"
    '        lblvatword.Text = InvoiceBLL.NumbersToWords(VatAmount) + " Only"
    '    End If
    '    'For Each item As RepeaterItem In grditemproduct.Items
    '    '    Dim lab As Label = TryCast(item.FindControl("lblName"), Label)
    '    'Next
    'End Sub

    Protected Sub grditemproduct_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles grditemproduct.ItemDataBound
        Dim tdgst As HtmlTableCell = DirectCast(e.Item.FindControl("tdgst"), HtmlTableCell)
        If currencytype = "USD" Then
            tdgst.Visible = False
        Else
            tdgst.Visible = True
        End If

    End Sub
End Class
