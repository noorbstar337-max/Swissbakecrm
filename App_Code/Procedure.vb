Option Explicit On
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data
Imports System.IO
Imports System.Net
Imports System.Web
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports System.Math
Public Class Procedure

    

    Public Shared Function NumbersToWords(ByVal inputNumber As Integer) As String
        Dim inputNo As Integer = inputNumber

        If inputNo = 0 Then
            Return "Zero"
        End If

        Dim numbers As Integer() = New Integer(3) {}
        Dim first As Integer = 0
        Dim u As Integer, h As Integer, t As Integer
        Dim sb As New System.Text.StringBuilder()

        If inputNo < 0 Then
            sb.Append("Minus ")
            inputNo = -inputNo
        End If

        Dim words0 As String() = {"", "One ", "Two ", "Three ", "Four ", "Five ", _
         "Six ", "Seven ", "Eight ", "Nine "}
        Dim words1 As String() = {"Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", _
         "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen "}
        Dim words2 As String() = {"Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", _
         "Eighty ", "Ninety "}
        Dim words3 As String() = {"Thousand ", "Lakh ", "Crore "}

        numbers(0) = inputNo Mod 1000
        ' units
        numbers(1) = inputNo \ 1000
        numbers(2) = inputNo \ 100000
        numbers(1) = numbers(1) - 100 * numbers(2)
        ' thousands
        numbers(3) = inputNo \ 10000000
        ' crores
        numbers(2) = numbers(2) - 100 * numbers(3)
        ' lakhs
        For i As Integer = 3 To 1 Step -1
            If numbers(i) <> 0 Then
                first = i
                Exit For
            End If
        Next
        For i As Integer = first To 0 Step -1
            If numbers(i) = 0 Then
                Continue For
            End If
            u = numbers(i) Mod 10
            ' ones
            t = numbers(i) \ 10
            h = numbers(i) \ 100
            ' hundreds
            t = t - 10 * h
            ' tens
            If h > 0 Then
                sb.Append(words0(h) & "Hundred ")
            End If
            If u > 0 OrElse t > 0 Then
                If h > 0 OrElse i = 0 Then
                    sb.Append(" ")
                End If
                If t = 0 Then
                    sb.Append(words0(u))
                ElseIf t = 1 Then
                    sb.Append(words1(u))
                Else
                    sb.Append(words2(t - 2) & words0(u))
                End If
            End If
            If i <> 0 Then
                sb.Append(words3(i - 1))
            End If
        Next
        Return sb.ToString().TrimEnd()
    End Function

    Public Function getDate(ByVal str As String) As String
        Dim sa As String() = str.Split("/"c)
        If sa.Count > 1 Then
            Return ((sa(2) + "/" + sa(1) + "/" + sa(0).ToString))
        Else
            Return ("")
        End If
    End Function

    Public Function Encrypt(clearText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, _
             &H65, &H64, &H76, &H65, &H64, &H65, _
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function

    Public Function Decrypt(cipherText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        cipherText = cipherText.Replace(" ", "+")
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, _
             &H65, &H64, &H76, &H65, &H64, &H65, _
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
        Return cipherText
    End Function

    Public Function BindChartPie(ByVal dT As DataTable, ByVal TitleChart As String, Optional ByVal ChartType As Integer = 0) As StringBuilder
        Dim r As Random = New Random
        Dim strScript As New StringBuilder(), DivName As String = r.Next(1, 9999).ToString
        '

        Try
            Dim dtColName As New List(Of String)
            For Each dc As DataColumn In dT.Columns
                dtColName.Add(dc.ColumnName.ToString)
            Next


            'Below code For Static Fixed 
            'strScript.Append("<div id='piechart_3d' style='width: 900px; height: 500px;'></div><script type='text/javascript'>" & vbCr & vbLf & "                    google.load('visualization', '1', {packages: ['corechart']}); </script>" & vbCr & vbLf & "                    " & vbCr & vbLf & "                    <script type='text/javascript'>" & vbCr & vbLf & "                   " & vbCr & vbLf & "                    function drawChart() {       " & vbCr & vbLf & "                    var data = google.visualization.arrayToDataTable([" & vbCr & vbLf & "                    ['Task', 'Hours of Day'],")
            'Below Code is For Dynaminc Column_Name
            If dtColName.Count > 1 Then
                strScript.Append("<div id='piechart_3d" & DivName.Trim & "' style='width: 95%; height: 500px; border:1px solid;'></div><script type='text/javascript'>" & vbCr & vbLf & "                    google.load('visualization', '1', {packages: ['corechart']}); </script>" & vbCr & vbLf & "                    " & vbCr & vbLf & "                    <script type='text/javascript'>" & vbCr & vbLf & "                   " & vbCr & vbLf & "                    function drawChart() {       " & vbCr & vbLf & "                    var data = google.visualization.arrayToDataTable([" & vbCr & vbLf & "                    ['" & dtColName.Item(1).ToString & "', '" & dtColName.Item(0).ToString & "'],")
            End If
            'Below code is For Dynaminc Data

            For Each row As DataRow In dT.Rows
                strScript.Append("['" + row(dtColName.Item(1).ToString).ToString + "'," + row(dtColName.Item(0).ToString).ToString + "],")
            Next
            If dT.Rows.Count <= 0 Then
                strScript.Append("['0',0],")
            End If
            ' Below is for Static For Test 
            'strScript.Append("['Work',1],")
            'strScript.Append("['Play',12],")
            'strScript.Append("['Study',33],")
            'strScript.Append("['Home',44],")
            strScript.Remove(strScript.Length - 1, 1)
            strScript.Append("]);")
            If ChartType = 0 Then
                strScript.Append(" var options = {   " & vbCr & vbLf & "                                    title: '" & TitleChart.ToString & "',          " & vbCr & vbLf & "                                    is3D: true,        " & vbCr & vbLf & "                                    };   ")
                strScript.Append("var chart = new google.visualization.PieChart(document.getElementById('piechart_3d" & DivName.Trim & "'));        " & vbCr & vbLf & "                                chart.draw(data, options);      " & vbCr & vbLf & "                                }  " & vbCr & vbLf & "                            google.setOnLoadCallback(drawChart);" & vbCr & vbLf & "                            ")
            ElseIf ChartType = 1 Then
                strScript.Append(" var options = {   " & vbCr & vbLf & "                                    title: '" & TitleChart.ToString & "',          " & vbCr & vbLf & "                                    is3D: true,        " & vbCr & vbLf & "                                    };   ")
                strScript.Append("var chart = new google.visualization.ColumnChart(document.getElementById('piechart_3d" & DivName.Trim & "'));        " & vbCr & vbLf & "                                chart.draw(data, options);      " & vbCr & vbLf & "                                }  " & vbCr & vbLf & "                            google.setOnLoadCallback(drawChart);" & vbCr & vbLf & "                            ")
            ElseIf ChartType = 2 Then
                strScript.Append(" var options = {   " & vbCr & vbLf & "                                    title: '" & TitleChart.ToString & "',          " & vbCr & vbLf & "                                    is3D: true,      pieHole: 0.4,   " & vbCr & vbLf & "                                    };   ")
                strScript.Append("var chart = new google.visualization.PieChart(document.getElementById('piechart_3d" & DivName.Trim & "'));        " & vbCr & vbLf & "                                chart.draw(data, options);      " & vbCr & vbLf & "                                }  " & vbCr & vbLf & "                            google.setOnLoadCallback(drawChart);" & vbCr & vbLf & "                            ")
            End If
            strScript.Append(" </script>")
            Return strScript
        Catch

        End Try
    End Function

    Public Sub SendMail(ByVal email As String, ByVal Content As String, ByVal Subj As String)
        Try
            Dim SendFrom As MailAddress = New MailAddress("support@india2biz.com")
            Dim smtp As New SmtpClient
            Dim MyMessage As MailMessage = New MailMessage()
            MyMessage.From = SendFrom
            MyMessage.To.Add(email)
            MyMessage.Subject = Subj
            MyMessage.Body = Content
            MyMessage.IsBodyHtml = True
            smtp.UseDefaultCredentials = True
            'smtp.Port = "25"
            smtp.Port = 25
            smtp.Credentials = New NetworkCredential("support@india2biz.com", "India@123")
            'smtp.Host = "smtpout.secureserver.net"
            smtp.Host = "smtp-mail.outlook.com"
            'smtp.EnableSsl = False
            smtp.EnableSsl = True
            smtp.Send(MyMessage)
            '  ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Your Enquiry has been register Successfully....')", True)
        Catch ex As Exception
            Dim err As String = "alert('Error While Getting data" + ex.Message + "')"
            '  ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", err, True)
        End Try
    End Sub

    Public Sub DynamicSendMail(ByVal emailto As String, ByVal emailfrom As String, ByVal emailfromPass As String, ByVal SSL As Boolean, ByVal Port As String,
                               ByVal Content As String, ByVal Subj As String, ByVal Host As String, ByVal AttachmentCollection As ArrayList)
        Try
            Dim SendFrom As MailAddress = New MailAddress(emailfrom)
            Dim smtp As New SmtpClient
            Dim MyMessage As MailMessage = New MailMessage()
            MyMessage.From = SendFrom
            MyMessage.To.Add(emailto)
            MyMessage.Subject = Subj
            MyMessage.Body = Content
            For i As Integer = 0 To AttachmentCollection.Count - 1
                '  MyMessage.Attachments.Add(New Attachment(Attachment.Keys(i), Attachment.Values(i)))
                MyMessage.Attachments.Add(New Attachment(AttachmentCollection(i)))
            Next
            MyMessage.IsBodyHtml = True
            smtp.UseDefaultCredentials = True
            'smtp.Port = "25"
            smtp.Port = Port
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network
            smtp.Credentials = New NetworkCredential(emailfrom, emailfromPass)
            'smtp.Host = "smtpout.secureserver.net"
            smtp.Host = Host
            'smtp.EnableSsl = False
            smtp.EnableSsl = SSL
            smtp.Send(MyMessage)
           
            '  ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Your Enquiry has been register Successfully....')", True)
        Catch ex As Exception
            'Dim err As String = "alert('Error While Getting data" + ex.Message + "')"
            Throw ex
            '  ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", err, True)
        End Try
    End Sub

End Class