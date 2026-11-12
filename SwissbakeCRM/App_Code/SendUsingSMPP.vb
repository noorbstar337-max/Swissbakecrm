Imports System.IO
Imports System.Net
Imports System.Data
Imports System.Web

Public Class SendUsingSMPP

    Public Shared Function SendSMS(ByVal message1 As String, ByVal number As String) As String
        If Not number = 0 Then
            Dim WebRequest As Net.WebRequest 'object for WebRequest 
            Dim WebResonse As Net.WebResponse 'object for WebResponse 
            ' DEFINE PARAMETERS USED IN URL 
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' '''''''' 
            'To what server you need to connect to for submission 
            'i.e. Dim Server As String = "xxxxx.xxxxx.xxxxx" 
            Dim Server As String = "103.16.101.52"
            'Port that is to be used like 8080 or 8000 
            Dim Port As String = "8080"
            'Username that is to be used for submission 
            'i.e. Dim UserName As String = "tester" 
            Dim UserName As String = "atec-swissb"
            ' password that is to be used along with username 
            'i.e. Dim Password As String = "password" 
            Dim Password As String = "123456"
            'What type of the message that is to be sent. 
            '0:means plain text 
            '1:means flash 
            '2:means Unicode (Message content should be in Hex)
            '6:means Unicode Flash(Message content should be in Hex) 
            Dim type As Integer = 0
            'Message content that is to be transmitted 
            Dim Message As String = message1.ToString
            'Url Encode message 
            Message = HttpUtility.UrlEncode(Message)
            If (type = 2) Or (type = 6) Then
                Message = SendUsingSMPP.ConvertToUnicode(Message)
            End If
            'Require DLR or not 
            '0:means DLR is not Required 
            '1:means DLR is Required 
            Dim DLR As Integer = 1
            'Sender Id to be used for submitting the message 
            'i.e. Dim SenderName As String = "test" 
            Dim Source As String = "SWBAKE"
            'Destinations to which message is to be sent For submitting more 
            'than(one)
            'destination at once destinations should be comma separated Like 
            '91999000123,91999000124

            Dim Destination As String '= number
            Dim host As String = HttpContext.Current.Request.Url.Host
            If host = "localhost" Then
                Destination = "9773438089"
                'Destination = "9029258816"
            Else
                Destination = number

            End If
            '''''''CODE COMPLETE TO DEFINE PARAMETER'''''''''''''''' 
            Dim WebResponseString As String = ""
            Dim URL As String = "http://" & Server & ":" & Port & "/bulksms/bulksms?username=" & UserName & "&password=" & Password & "&type=" & type & "&dlr=" & DLR & "&destination=" & Destination & "&source=" & Source & "&message=" & Message & ""
            WebRequest = Net.HttpWebRequest.Create(URL) 'Hit URL Link 
            WebRequest.Timeout = 25000

            Try
                WebResonse = WebRequest.GetResponse 'Get Response 
                Dim reader As IO.StreamReader = New IO.StreamReader(WebResonse.GetResponseStream)
                'Read Response and store in variable 
                WebResponseString = reader.ReadToEnd()
                WebResonse.Close()
                ' MessageBox.Show(WebResponseString) 'Display Response. 
            Catch ex As Exception
                WebResponseString = "Request Timeout" 'If any exception 
                'occur.
                '  MessageBox.Show(WebResponseString, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Return WebResponseString
        Else
            Return 0
        End If
    End Function
    'Function To Convert String to Unicode if MessageType=2 and 6. 


    'Public Shared Sub SendWhatsAppMessage(ordercode As String, amount As Decimal, customerName As String, mobileNo As String, templateName As String)

    '    Dim apiKey As String = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjY0ZWM0OTgwMzUzYWU1MGJjZWU4ODk4MiIsIm5hbWUiOiJTd2lzcyBCYWtlIEluZ3JlZGllbnRzIFB2dCBMdGQiLCJhcHBOYW1lIjoiQWlTZW5zeSIsImNsaWVudElkIjoiNjRlYzQ5N2YzNTNhZTUwYmNlZTg4OTdkIiwiYWN0aXZlUGxhbiI6IkJBU0lDX01PTlRITFkiLCJpYXQiOjE2OTMyMDY5MTJ9.HzFeK3_61EzW7e5x2vFGqyMFPBDUY4yQyEG_5hsuC2E"
    '    Dim apiUrl As String = "https://backend.aisensy.com/campaign/t1/api/v2"

    '    ' Build JSON for 3 template parameters
    '    'Dim sb As New StringBuilder()
    '    'sb.Append("{")
    '    'sb.Append("""apiKey"": """ & apiKey & """,")
    '    'sb.Append("""campaignName"": ""new_order"",")
    '    'sb.Append("""destination"": ""91" & mobileNo & """,")
    '    'sb.Append("""userName"": ""Swiss Bake Ingredients Pvt Ltd"",")
    '    'sb.Append("""templateParams"": [")
    '    'sb.Append("""" & ordercode & """,")      ' param 1: order code
    '    'sb.Append("""" & amount.ToString("N2") & """,")  ' param 2: amount
    '    'sb.Append("""" & customerName.Replace("""", "") & """") ' param 3: customer name
    '    'sb.Append("],")
    '    'sb.Append("""source"": ""new-landing-page form"",")
    '    'sb.Append("""media"": {},""buttons"": [],""carouselCards"": [],""location"": {},")
    '    'sb.Append("""attributes"": {},""paramsFallbackValue"": {""FirstName"": ""user""}")
    '    'sb.Append("}")
    '    Dim sb As New StringBuilder()
    '    sb.Append("{")
    '    sb.Append("""apiKey"": """ & apiKey & """,")
    '    sb.Append("""campaignName"": """ & templateName & """,")  ' dynamic template
    '    sb.Append("""destination"": ""91" & mobileNo & """,")
    '    sb.Append("""userName"": ""Swiss Bake Ingredients Pvt Ltd"",")
    '    sb.Append("""templateParams"": [")
    '    sb.Append("""" & ordercode & """,")      ' param 1: order code
    '    sb.Append("""" & amount.ToString("N2") & """,")  ' param 2: amount
    '    sb.Append("""" & customerName.Replace("""", "") & """") ' param 3: customer name
    '    sb.Append("],")
    '    sb.Append("""source"": ""new-landing-page form"",")
    '    sb.Append("""media"": {},""buttons"": [],""carouselCards"": [],""location"": {},")
    '    sb.Append("""attributes"": {},""paramsFallbackValue"": {""FirstName"": ""user""}")
    '    sb.Append("}")

    '    Dim postData As String = sb.ToString()

    '    Dim request As HttpWebRequest = CType(WebRequest.Create(apiUrl), HttpWebRequest)
    '    request.Method = "POST"
    '    request.ContentType = "application/json"

    '    Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
    '    request.ContentLength = byteArray.Length

    '    Using dataStream As Stream = request.GetRequestStream()
    '        dataStream.Write(byteArray, 0, byteArray.Length)
    '    End Using

    '    Try
    '        Using response As WebResponse = request.GetResponse()
    '            Using reader As New StreamReader(response.GetResponseStream())
    '                Dim responseFromServer As String = reader.ReadToEnd()
    '                ' Optional: log response
    '            End Using
    '        End Using
    '    Catch ex As WebException
    '        Using stream As Stream = ex.Response.GetResponseStream()
    '            Using reader As New StreamReader(stream)
    '                Dim errorResponse As String = reader.ReadToEnd()
    '                Throw New Exception("AiSensy error: " & errorResponse)
    '            End Using
    '        End Using
    '    End Try
    'End Sub


    Public Shared Sub SendWhatsAppMessage(mobileNo As String, templateName As String, templateParams As List(Of String))

        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        Dim apiKey As String = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjY0ZWM0OTgwMzUzYWU1MGJjZWU4ODk4MiIsIm5hbWUiOiJTd2lzcyBCYWtlIEluZ3JlZGllbnRzIFB2dCBMdGQiLCJhcHBOYW1lIjoiQWlTZW5zeSIsImNsaWVudElkIjoiNjRlYzQ5N2YzNTNhZTUwYmNlZTg4OTdkIiwiYWN0aXZlUGxhbiI6IkJBU0lDX01PTlRITFkiLCJpYXQiOjE2OTMyMDY5MTJ9.HzFeK3_61EzW7e5x2vFGqyMFPBDUY4yQyEG_5hsuC2E" ' replace with your actual key
        Dim apiUrl As String = "https://backend.aisensy.com/campaign/t1/api/v2"

        ' Build JSON dynamically based on templateParams
        Dim sb As New StringBuilder()
        sb.Append("{")
        sb.Append("""apiKey"": """ & apiKey & """,")
        sb.Append("""campaignName"": """ & templateName & """,")
        sb.Append("""destination"": ""91" & mobileNo & """,")
        sb.Append("""userName"": ""Swiss Bake Ingredients Pvt Ltd"",")
        sb.Append("""templateParams"": [")

        For i As Integer = 0 To templateParams.Count - 1
            sb.Append("""" & templateParams(i).Replace("""", "") & """")
            If i < templateParams.Count - 1 Then
                sb.Append(",")
            End If
        Next

        sb.Append("],")
        sb.Append("""source"": ""new-landing-page form"",")
        sb.Append("""media"": {},""buttons"": [],""carouselCards"": [],""location"": {},")
        sb.Append("""attributes"": {},""paramsFallbackValue"": {""FirstName"": ""user""}")
        sb.Append("}")

        Dim postData As String = sb.ToString()

        Dim request As HttpWebRequest = CType(WebRequest.Create(apiUrl), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"

        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = byteArray.Length

        Using dataStream As Stream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
        End Using

        Try
            Using response As WebResponse = request.GetResponse()
                Using reader As New StreamReader(response.GetResponseStream())
                    Dim responseFromServer As String = reader.ReadToEnd()
                    ' Optional: log success
                End Using
            End Using
        Catch ex As WebException
            Using stream As Stream = ex.Response.GetResponseStream()
                Using reader As New StreamReader(stream)
                    Dim errorResponse As String = reader.ReadToEnd()
                    Throw New Exception("AiSensy error: " & errorResponse)
                End Using
            End Using
        End Try
    End Sub
    Public Shared Function ConvertToUnicode(ByVal str As String) As String
        Dim ArrayOFBytes() As Byte =
        System.Text.Encoding.Unicode.GetBytes(str)
        Dim UnicodeString As String = ""
        Dim v As Integer
        For v = 0 To ArrayOFBytes.Length - 1
            If v Mod 2 = 0 Then
                Dim t As Integer = ArrayOFBytes(v)
                ArrayOFBytes(v) = ArrayOFBytes(v + 1)
                ArrayOFBytes(v + 1) = t
            End If
        Next
        For v = 0 To ArrayOFBytes.Length - 1
            Dim c As String = Hex$(ArrayOFBytes(v))
            If c.Length = 1 Then
                c = "0" & c
            End If
            UnicodeString = UnicodeString & c
        Next
        Return UnicodeString
    End Function
End Class
