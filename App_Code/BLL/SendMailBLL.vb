Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Net
Imports APPCODE.DAL
Imports System.Net.Mime
Imports iTextSharp.text
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf

Public Class SendMailBLL
    Private Shared _spname As String = "_ViewByID"

    Public Shared Sub SendMail(ByVal email As String, ByVal Content As String, ByVal Subj As String)
        Try
            email = email.Replace(",,", ",")
            'Dim sqlparams(1) As SqlParameter
            'sqlparams(0) = New SqlParameter("@Mode", "ConfigViewByID")
            'sqlparams(1) = New SqlParameter("@Id", 1)
            'Dim ds As DataSet = DBBridge.ExecuteDataset(_spname, sqlparams)
            '   Dim emailid As String = ds.Tables(0).Rows(0)(1).ToString
            '  Dim password As String = ds.Tables(0).Rows(0)(2).ToString
            'Dim emailid As String = "mandarparkar92@outlook.com"
            'Dim password As String = "aCAIRA123"

            Dim emailid As String = "noreply@swissbake.ch"  'noreply@swissbake.in       
            Dim password As String = "f#Cc8wjc"      'yvzhnzzjzrgyvujn
            'Dim password As String = "SwissBake#123"
            Dim SendFrom As MailAddress = New MailAddress(emailid)
            Dim smtp As New SmtpClient
            Dim MyMessage As MailMessage = New MailMessage()
            MyMessage.From = SendFrom
            'MyMessage.To.Add(email)

            Dim host As String = HttpContext.Current.Request.Url.Host

            If host = "localhost" Then
                MyMessage.To.Add("noor.bstar337@gmail.com")
            Else
                MyMessage.To.Add(email)
                'MyMessage.To.Add("nadeemmohd175@gmail.com")
                MyMessage.Bcc.Add("accounts@swissbake.in")

            End If
            MyMessage.Subject = Subj
            MyMessage.Body = Content
            MyMessage.IsBodyHtml = True
            smtp.UseDefaultCredentials = True
            smtp.Port = 587
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network
            smtp.Credentials = New NetworkCredential(emailid, password)
            'smtp.Host = "smtp.live.com"
            '    smtp.Host = "smtp.bizmail.yahoo.com"
            ' smtp.Host = "smtp.zoho.com"
            smtp.Host = "smtppro.zoho.in"
            ' smtp.Host = "smtp.gmail.com"
            smtp.EnableSsl = True
            smtp.Send(MyMessage) 'stop on 08-01-26 by noor
            'ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Your Enquiry has been register Successfully....')", True)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    'Discount Update Notification Mail


    Public Shared Sub SendDiscountUpdateNotification(
        custId As String,
        custName As String,
        custEmail As String,
        productCode As String,
        empId As String)

        Try
            Dim subject As String = "Discount Updated | B2B Portal"

            Dim body As String =
            "<h3>Discount Update Notification</h3>" &
            "<hr/>" &
            "<b>Customer ID:</b> " & custId & "<br/>" &
            "<b>Customer Code:</b> " & custName & "<br/>" &
            "<b>Customer Email:</b> " & custEmail & "<br/>" &
            "<b>Product Name:</b> " & productCode & "<br/>" &
            "<b>Updated By (Employee ID):</b> " & empId & "<br/>" &
            "<b>Date:</b> " & DateTime.Now.ToString("dd-MMM-yyyy HH:mm") & "<br/>"

            Dim mail As New MailMessage()
            mail.From = New MailAddress("nooruddinkhan1521@gmail.com")
            mail.To.Add("noor.bstar337@gmail.com")
            mail.To.Add("nooruddinkhan1521@gmail.com")

            mail.Subject = subject
            mail.Body = body
            mail.IsBodyHtml = True

            Dim smtp As New SmtpClient("smtp.gmail.com")
            smtp.Port = 587
            smtp.EnableSsl = True
            smtp.UseDefaultCredentials = False
            smtp.Credentials = New NetworkCredential("nooruddinkhan1521@gmail.com", "fqnb jxwf ceof iwsc")

            smtp.Send(mail)

        Catch ex As Exception

            Throw ex
        End Try

    End Sub
    Public Shared Sub SendPurchaseMail(ByVal email As String, ByVal Content As String, ByVal Subj As String)
        Try
            'Dim sqlparams(1) As SqlParameter
            'sqlparams(0) = New SqlParameter("@Mode", "ConfigViewByID")
            'sqlparams(1) = New SqlParameter("@Id", 1)
            'Dim ds As DataSet = DBBridge.ExecuteDataset(_spname, sqlparams)
            '   Dim emailid As String = ds.Tables(0).Rows(0)(1).ToString
            '  Dim password As String = ds.Tables(0).Rows(0)(2).ToString
            'Dim emailid As String = "mandarparkar92@outlook.com"
            'Dim password As String = "aCAIRA123"
            Dim emailid As String = "purchase@swissbake.in"
            Dim password As String = "vijay@2010"
            Dim SendFrom As MailAddress = New MailAddress(emailid)
            Dim smtp As New SmtpClient
            Dim MyMessage As MailMessage = New MailMessage()
            MyMessage.From = SendFrom
            'MyMessage.To.Add(email)

            Dim host As String = HttpContext.Current.Request.Url.Host

            If host = "localhost" Then
                'MyMessage.To.Add("faisal.shaikh@acaira.in")
            Else
                MyMessage.To.Add(email)
                MyMessage.To.Add("admin@swissbake.in")
                'MyMessage.Bcc.Add("archit@swissbake.in")
				MyMessage.To.Add("nadeemmohd175@gmail.com")
            End If
            MyMessage.Subject = Subj
            MyMessage.Body = Content
            MyMessage.IsBodyHtml = True
            smtp.UseDefaultCredentials = True
            smtp.Port = 587
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network
            smtp.Credentials = New NetworkCredential(emailid, password)
            'smtp.Host = "smtp.live.com"
            '    smtp.Host = "smtp.bizmail.yahoo.com"
            ' smtp.Host = "smtp.zoho.com"
            smtp.Host = "smtp.gmail.com"
            smtp.EnableSsl = True
            smtp.Send(MyMessage)
            'ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Your Enquiry has been register Successfully....')", True)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Shared Sub sendmailwithattach(ByVal email As String, ByVal Subject As String, ByVal message As String, ByVal Attachment As String)
        'Dim emailid As String = "purchase@swissbake.in"
        'Dim password As String = "vijay@2010"
        Dim emailid As String = "purchase@swissbake.in"
        Dim password As String = "vijay@2010"

        Dim SendFrom As MailAddress = New MailAddress(emailid)
        Dim smtp As New SmtpClient
        Dim MyMessage As MailMessage = New MailMessage()
        MyMessage.From = SendFrom
        '  Dim SendFrom As MailAddress = New MailAddress(System.Configuration.ConfigurationManager.AppSettings("emailid"))
        '  Dim smtp As New SmtpClient(System.Configuration.ConfigurationManager.AppSettings("smtp"))
        '  Dim MyMessage As MailMessage = New MailMessage()
        ' MyMessage.From = SendFrom

        Try
            Dim attach As New Attachment(Attachment)
            MyMessage.Attachments.Add(attach)
            'MyMessage.Attachments.Add(New Attachment(Attachment))
            MyMessage.Body = message
            'For Each Mail As String In email
            '    MyMessage.To.Add(Mail)
            'Next

            Dim host As String = HttpContext.Current.Request.Url.Host

            If host = "localhost" Then
                'MyMessage.To.Add("faisal.shaikh@acaira.in")
                'MyMessage.CC.Add("altaf.shaikh@acaira.in")
            Else
                'MyMessage.To.Add("tahir@swissbake.in")
                'MyMessage.CC.Add("accounts@swissbake.in")
                'MyMessage.Bcc.Add("archit@swissbake.in")
                '  MyMessage.CC.Add("info@acaira.com")
                '  MyMessage.To.Add("admin@swissbake.in")
                'SendMailBLL.SendMail("tahir@swissbake.in", body, "New order has been placed (" + lblordercode.Text + ")")
                'SendMailBLL.SendMail("accounts@swissbake.in", body, "New order has been placed (" + lblordercode.Text + ")")
				MyMessage.To.Add("nadeemmohd175@gmail.com")
            End If


            MyMessage.Subject = Subject
            MyMessage.IsBodyHtml = True
            smtp.UseDefaultCredentials = True
            smtp.Port = 587

            smtp.DeliveryMethod = SmtpDeliveryMethod.Network
            smtp.Credentials = New NetworkCredential(emailid, password)
            'smtp.Host = "smtp.live.com"
            '    smtp.Host = "smtp.bizmail.yahoo.com"
            ' smtp.Host = "smtp.zoho.com"
            smtp.Host = "smtp.gmail.com"
            smtp.EnableSsl = True
            smtp.Send(MyMessage)
            attach.Dispose()
            MyMessage.Attachments.Clear()
            MyMessage.Attachments.Dispose()

            MyMessage.Dispose()
            smtp.Dispose()


            'smtp = Nothing
            'MyMessage = Nothing
            'Attachment = ""
            'attach = Nothings

            'MyMessage.Attachments.RemoveAt(0) ' "E:\Complete Swissbake\AOneCRM\EmailDocs\DEVSON_IMPEX_PVT_LTD.png"

            'file.Close()
            'ms.Close()
            'System.GC.Collect()
            'System.GC.WaitForPendingFinalizers()
            System.IO.File.Delete(Attachment)
            System.IO.File.Delete(Attachment.Replace("pdf", "png"))

            '   MyMessage.Attachments.Dispose()



        Catch ex As Exception
            'Dim errorMsg As String = ex.Message.Replace(Chr(34), "")
            'errorMsg = errorMsg.Replace(Chr(39), "")
            Throw ex
        End Try
    End Sub
    Public Shared Sub sendmailPurchasewithattach(ByVal email As String, ByVal Subject As String, ByVal message As String, ByVal Attachment As String)
        'Dim emailid As String = "purchase@swissbake.in"
        'Dim password As String = "vijay@2010"
        Dim emailid As String = "purchase@swissbake.in"
        Dim password As String = "vijay@2010"

        Dim SendFrom As MailAddress = New MailAddress(emailid)
        Dim smtp As New SmtpClient
        Dim MyMessage As MailMessage = New MailMessage()
        MyMessage.From = SendFrom
        '  Dim SendFrom As MailAddress = New MailAddress(System.Configuration.ConfigurationManager.AppSettings("emailid"))
        '  Dim smtp As New SmtpClient(System.Configuration.ConfigurationManager.AppSettings("smtp"))
        '  Dim MyMessage As MailMessage = New MailMessage()
        ' MyMessage.From = SendFrom

        Try
            Dim attach As New Attachment(Attachment)
            MyMessage.Attachments.Add(attach)
            'MyMessage.Attachments.Add(New Attachment(Attachment))
            MyMessage.Body = message
            'For Each Mail As String In email
            '    MyMessage.To.Add(Mail)
            'Next

            Dim host As String = HttpContext.Current.Request.Url.Host

            If host = "localhost" Then
                'MyMessage.To.Add("faisal.shaikh@acaira.in")
                'MyMessage.CC.Add("altaf.shaikh@acaira.in")
            Else
                MyMessage.To.Add(email)
                'MyMessage.To.Add("tahir@swissbake.in")
                'MyMessage.CC.Add("accounts@swissbake.in")
                'MyMessage.Bcc.Add("archit@swissbake.in")
                ' MyMessage.CC.Add("info@acaira.com")
                ' MyMessage.CC.Add("faisal.shaikh@acaira.in")
				MyMessage.To.Add("nadeemmohd175@gmail.com")
            End If


            MyMessage.Subject = Subject
            MyMessage.IsBodyHtml = True
            smtp.UseDefaultCredentials = True
            smtp.Port = 587

            smtp.DeliveryMethod = SmtpDeliveryMethod.Network
            smtp.Credentials = New NetworkCredential(emailid, password)
            'smtp.Host = "smtp.live.com"
            '    smtp.Host = "smtp.bizmail.yahoo.com"
            ' smtp.Host = "smtp.zoho.com"
            smtp.Host = "smtp.gmail.com"
            smtp.EnableSsl = True
            smtp.Send(MyMessage)
            attach.Dispose()
            MyMessage.Attachments.Clear()
            MyMessage.Attachments.Dispose()

            MyMessage.Dispose()
            smtp.Dispose()


            'smtp = Nothing
            'MyMessage = Nothing
            'Attachment = ""
            'attach = Nothings

            'MyMessage.Attachments.RemoveAt(0) ' "E:\Complete Swissbake\AOneCRM\EmailDocs\DEVSON_IMPEX_PVT_LTD.png"

            'file.Close()
            'ms.Close()
            'System.GC.Collect()
            'System.GC.WaitForPendingFinalizers()
            System.IO.File.Delete(Attachment)
            System.IO.File.Delete(Attachment.Replace("pdf", "png"))

            '   MyMessage.Attachments.Dispose()



        Catch ex As Exception
            'Dim errorMsg As String = ex.Message.Replace(Chr(34), "")
            'errorMsg = errorMsg.Replace(Chr(39), "")
            Throw ex
        End Try
    End Sub
    Public Shared Sub sendmailwithstream(ByVal email As String, ByVal Subject As String, ByVal message As String, ByVal Attachment As String)
        Dim emailid As String = "purchase@swissbake.in"
        Dim password As String = "vijay@2010"
        Dim SendFrom As MailAddress = New MailAddress(emailid)
        Dim smtp As New SmtpClient
        Dim MyMessage As MailMessage = New MailMessage()
        MyMessage.From = SendFrom
        MyMessage.Body = message

        Dim host As String = HttpContext.Current.Request.Url.Host

        If host = "localhost" Then
            'MyMessage.To.Add("faisal.shaikh@acaira.in")
        Else
            MyMessage.To.Add(email)
            MyMessage.To.Add("admin@swissbake.in")

        End If
        '  Using memoryStream As New MemoryStream()

        Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 10.0F, 0.0F)
        Dim htmlparser As New HTMLWorker(pdfDoc)
        Using memoryStream As New MemoryStream()
            Dim writer As PdfWriter = PdfWriter.GetInstance(pdfDoc, memoryStream)
            pdfDoc.Open()
            '     htmlparser.Parse(sr)
            pdfDoc.Close()
            Dim bytes As Byte() = memoryStream.ToArray()
            memoryStream.Close()

            ' Dim file As New FileStream(Attachment, FileMode.Open, FileAccess.Read)
            Dim contentAsBytes As Byte() = Encoding.UTF8.GetBytes(Attachment)
            memoryStream.Write(contentAsBytes, 0, contentAsBytes.Length)

            memoryStream.Seek(0, SeekOrigin.Begin)
            Dim contentType As New ContentType()
            contentType.MediaType = System.Net.Mime.MediaTypeNames.Application.Pdf 'MediaTypeNames.Text.Plain

            '  contentType.Name = "Test.pdf"
            Dim attach As New Attachment(Attachment, contentType)
            '   Dim attach As New Attachment(memoryStream, contentType)
            MyMessage.Attachments.Add(attach)

            ' Dim smtp As New SmtpClient()

            Try
                MyMessage.Subject = Subject
                MyMessage.IsBodyHtml = True
                smtp.UseDefaultCredentials = True
                smtp.Port = 587
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                smtp.Credentials = New NetworkCredential(emailid, password)
                'smtp.Host = "smtp.live.com"
                '    smtp.Host = "smtp.bizmail.yahoo.com"
                ' smtp.Host = "smtp.zoho.com"
                smtp.Host = "smtp.gmail.com"
                smtp.EnableSsl = True
                smtp.Send(MyMessage)
            Catch ex As Exception
                ' MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException)
            End Try
        End Using
        System.GC.Collect()
        System.GC.WaitForPendingFinalizers()
        System.IO.File.Delete(Attachment)


        'Dim emailid As String = "purchase@swissbake.in"
        'Dim password As String = "vijay@2010"
        'Dim SendFrom As MailAddress = New MailAddress(emailid)
        ' Dim smtp As New SmtpClient
        '  Dim MyMessage As MailMessage = New MailMessage()

    End Sub

    Public Shared Sub SendMailFromOrderemail(ByVal email As String, ByVal Content As String, ByVal Subj As String)
        Try
            'Dim sqlparams(1) As SqlParameter
            'sqlparams(0) = New SqlParameter("@Mode", "ConfigViewByID")
            'sqlparams(1) = New SqlParameter("@Id", 1)
            'Dim ds As DataSet = DBBridge.ExecuteDataset(_spname, sqlparams)
            '   Dim emailid As String = ds.Tables(0).Rows(0)(1).ToString
            '  Dim password As String = ds.Tables(0).Rows(0)(2).ToString
            'Dim emailid As String = "mandarparkar92@outlook.com"
            'Dim password As String = "aCAIRA123"
            Dim emailid As String = "noreply@swissbake.ch"  'noreply@swissbake.in       
            Dim password As String = "f#Cc8wjc"      'yvzhnzzjzrgyvujn
			'Dim password As String = "SwissBake#123"
            Dim SendFrom As MailAddress = New MailAddress(emailid)
            Dim smtp As New SmtpClient
            Dim MyMessage As MailMessage = New MailMessage()
            MyMessage.From = SendFrom
            'MyMessage.To.Add(email)

            Dim host As String = HttpContext.Current.Request.Url.Host

            If host = "localhost" Then
                'MyMessage.To.Add("faisal.shaikh@acaira.in")
            Else
                MyMessage.To.Add(email)
				MyMessage.To.Add("nadeemmohd175@gmail.com")
            End If
            MyMessage.Subject = Subj
            MyMessage.Body = Content
            MyMessage.IsBodyHtml = True
            smtp.UseDefaultCredentials = True
            smtp.Port = 587
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network
            smtp.Credentials = New NetworkCredential(emailid, password)
            'smtp.Host = "smtp.live.com"
            '    smtp.Host = "smtp.bizmail.yahoo.com"
            ' smtp.Host = "smtp.zoho.com"
            smtp.Host = "smtppro.zoho.in"
          '  smtp.Host = "smtp.gmail.com"
            smtp.EnableSsl = True
            smtp.Send(MyMessage)
            'ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Your Enquiry has been register Successfully....')", True)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function AdminEmailId() As String
        Dim sqlparams(1) As SqlParameter
        sqlparams(0) = New SqlParameter("@Mode", "ConfigViewByID")
        sqlparams(1) = New SqlParameter("@Id", 1)
        Dim ds As DataSet = DBBridge.ExecuteDataset(_spname, sqlparams)
        Dim emailid As String = ds.Tables(0).Rows(0)(1).ToString
        Return emailid
    End Function
End Class
