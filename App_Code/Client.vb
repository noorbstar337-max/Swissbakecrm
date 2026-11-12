
' Copyright (C) 2009-2013 pdfcrowd.com
' 
' Permission is hereby granted, free of charge, to any person
' obtaining a copy of this software and associated documentation
' files (the "Software"), to deal in the Software without
' restriction, including without limitation the rights to use,
' copy, modify, merge, publish, distribute, sublicense, and/or sell
' copies of the Software, and to permit persons to whom the
' Software is furnished to do so, subject to the following
' conditions:
' 
' The above copyright notice and this permission notice shall be
' included in all copies or substantial portions of the Software.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
' EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
' OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
' NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
' HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
' WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
' FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
' OTHER DEALINGS IN THE SOFTWARE.

Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Web
Imports System.Diagnostics
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Net.Security

Namespace pdfcrowd
    '
    ' Pdfcrowd API client.
    ' 
    Public Class Client
        '
        ' Client constructor.
        ' 
        Public username As String = "faisal_shakh"
        Public api_key As String = "7bbc52c6f15a37dae64eef5bd1b64c53"
        ' 
        Public Sub New(username As String, api_key As String)
            useSSL(False)
            fields.Add("username", username)
            fields.Add("key", api_key)
            fields.Add("pdf_scaling_factor", "1")
            fields.Add("html_zoom", "200")
        End Sub

        '
        ' Client constructor.
        ' 
        ' username - your username at Pdfcrowd
        ' api_key  - your API key
        ' 
        ' 
        Public Sub New(username As String, api_key As String, hostname As String)
            fields.Add("username", username)
            fields.Add("key", api_key)
            fields.Add("pdf_scaling_factor", "1")
            fields.Add("html_zoom", "200")
            HOST = hostname
            useSSL(False)
        End Sub


        '
        ' Converts a web page.
        '
        ' uri        - a web page URL
        ' out_stream - a System.IO.Stream implementation
        ' 
        Public Sub convertURI(uri As String, out_stream As Stream)
            convert(out_stream, "uri", uri)
        End Sub

        '
        ' Converts an in-memory html document.
        '
        ' content    - a string containing a html document
        ' out_stream - a System.IO.Stream implementation
        ' 
        Public Sub convertHtml(content As String, out_stream As Stream)
            convert(out_stream, "html", content)
        End Sub

        '
        ' Converts an html file.
        '
        ' fpath      - a path to an html file
        ' out_stream - a System.IO.Stream implementation
        ' 
        Public Sub convertFile(fpath As String, out_stream As Stream)
            '  post_multipart(fpath, out_stream)
        End Sub

        '
        ' Returns the number of available conversion tokens.
        ' 
        Public Function numTokens() As Integer
            Dim uri As String = [String].Format("{0}user/{1}/tokens/", api_uri, fields("username"))
            Dim stream As New MemoryStream()
            call_api(uri, stream, Nothing)
            stream.Position = 0
            Dim value As String = read_stream(stream)
            Return Int32.Parse(value)
        End Function


        Public Sub useSSL(use_ssl As Boolean)
            If use_ssl Then
                api_uri = String.Format("https://{0}:{1}{2}", HOST, HTTPS_PORT, API_SELECTOR_BASE)
            Else
                api_uri = String.Format("http://{0}:{1}{2}", HOST, HTTP_PORT, API_SELECTOR_BASE)
            End If
        End Sub

        Public Sub setUsername(username As String)
            fields("username") = username
        End Sub

        Public Sub setApiKey(key As String)
            fields("key") = key
        End Sub

        Public Sub setPageWidth(value As String)
            fields("width") = value
        End Sub

        Public Sub setPageWidth(value As Double)
            fields("width") = value.ToString()


        End Sub

        Public Sub setPageHeight(value As String)
            fields("height") = value
        End Sub

        Public Sub setPageHeight(value As Double)
            fields("height") = value.ToString()
        End Sub

        Public Sub setHorizontalMargin(value As Double)
            fields("margin_right") = value.ToString()
            fields("margin_left") = value.ToString()
        End Sub

        Public Sub setHorizontalMargin(value As String)
            fields("margin_right") = value
            fields("margin_left") = value
        End Sub

        Public Sub setVerticalMargin(value As Double)
            fields("margin_top") = value.ToString()
            fields("margin_bottom") = value.ToString()
        End Sub

        Public Sub setVerticalMargin(value As String)
            fields("margin_top") = value
            fields("margin_bottom") = value
        End Sub

        Public Sub setPageMargins(top As String, right As String, bottom As String, left As String)
            fields("margin_top") = top
            fields("margin_right") = right
            fields("margin_bottom") = bottom
            fields("margin_left") = left
        End Sub

        Public Sub setEncrypted(value As Boolean)
            fields("encrypted") = If(value, "true", Nothing)
        End Sub

        Public Sub setEncrypted()
            setEncrypted(True)
        End Sub

        Public Sub setUserPassword(pwd As String)
            fields("user_pwd") = pwd
        End Sub

        Public Sub setOwnerPassword(pwd As String)
            fields("owner_pwd") = pwd
        End Sub

        Public Sub setNoPrint(value As Boolean)
            fields("no_print") = If(value, "true", Nothing)
        End Sub

        Public Sub setNoPrint()
            setNoPrint(True)
        End Sub

        Public Sub setNoModify(value As Boolean)
            fields("no_modify") = If(value, "true", Nothing)
        End Sub

        Public Sub setNoModify()
            setNoModify(True)
        End Sub

        Public Sub setNoCopy(value As Boolean)
            fields("no_copy") = If(value, "true", Nothing)
        End Sub

        Public Sub setNoCopy()
            setNoCopy(True)
        End Sub

        ' constants for setPageLayout()
        Public Shared SINGLE_PAGE As Integer = 1
        Public Shared CONTINUOUS As Integer = 2
        Public Shared CONTINUOUS_FACING As Integer = 3

        Public Sub setPageLayout(value As Integer)
            Debug.Assert(value > 0 AndAlso value <= 3)
            fields("page_layout") = value.ToString()
        End Sub

        ' constants for setPageMode()
        Public Shared NONE_VISIBLE As Integer = 1
        Public Shared THUMBNAILS_VISIBLE As Integer = 2
        Public Shared FULLSCREEN As Integer = 3

        Public Sub setPageMode(value As Integer)
            Debug.Assert(value > 0 AndAlso value <= 3)
            fields("page_mode") = value.ToString()
        End Sub

        Public Sub setFooterText(value As String)
            fields("footer_text") = value
        End Sub

        Public Sub enableImages()
            enableImages(True)
        End Sub

        Public Sub enableImages(value As Boolean)
            fields("no_images") = If(value, Nothing, "true")
        End Sub

        Public Sub enableBackgrounds()
            enableBackgrounds(True)
        End Sub

        Public Sub enableBackgrounds(value As Boolean)
            fields("no_backgrounds") = If(value, Nothing, "true")
        End Sub

        Public Sub setHtmlZoom(value As Single)
            fields("html_zoom") = value.ToString()
        End Sub

        Public Sub enableJavaScript()
            enableJavaScript(True)
        End Sub

        Public Sub enableJavaScript(value As Boolean)
            fields("no_javascript") = If(value, Nothing, "true")
        End Sub

        Public Sub enableHyperlinks()
            enableHyperlinks(True)
        End Sub

        Public Sub enableHyperlinks(value As Boolean)
            fields("no_hyperlinks") = If(value, Nothing, "true")
        End Sub

        Public Sub setDefaultTextEncoding(value As String)
            fields("text_encoding") = value
        End Sub

        Public Sub usePrintMedia()
            usePrintMedia(True)
        End Sub

        Public Sub usePrintMedia(value As Boolean)
            fields("use_print_media") = If(value, "true", Nothing)
        End Sub

        Public Sub setMaxPages(value As Integer)
            fields("max_pages") = value.ToString()
        End Sub

        Public Sub enablePdfcrowdLogo()
            enablePdfcrowdLogo(True)
        End Sub

        Public Sub enablePdfcrowdLogo(value As Boolean)
            fields("pdfcrowd_logo") = If(value, "true", Nothing)
        End Sub

        ' constants for setInitialPdfZoomType()
        Public Shared FIT_WIDTH As Integer = 1
        Public Shared FIT_HEIGHT As Integer = 2
        Public Shared FIT_PAGE As Integer = 3

        Public Sub setInitialPdfZoomType(value As Integer)
            Debug.Assert(value > 0 AndAlso value <= 3)
            fields("initial_pdf_zoom_type") = value.ToString()
        End Sub

        Public Sub setInitialPdfExactZoom(value As Single)
            fields("initial_pdf_zoom_type") = "4"
            fields("initial_pdf_zoom") = value.ToString()
        End Sub

        Public Sub setAuthor(value As String)
            fields("author") = value
        End Sub

        Public Sub setFailOnNon200(value As Boolean)
            fields("fail_on_non200") = If(value, "true", Nothing)
        End Sub

        Public Sub setPdfScalingFactor(value As Single)
            fields("pdf_scaling_factor") = value.ToString()
        End Sub

        Public Sub setFooterHtml(value As String)
            fields("footer_html") = value
        End Sub

        Public Sub setFooterUrl(value As String)
            fields("footer_url") = value
        End Sub

        Public Sub setHeaderHtml(value As String)
            fields("header_html") = value
        End Sub

        Public Sub setHeaderUrl(value As String)
            fields("header_url") = value
        End Sub

        Public Sub setPageBackgroundColor(value As String)
            fields("page_background_color") = value
        End Sub




        Public Sub setTransparentBackground()
            setTransparentBackground(True)
        End Sub

        Public Sub setTransparentBackground(val As Boolean)
            fields("transparent_background") = If(val, "true", Nothing)
        End Sub


        Public Sub setPageNumberingOffset(value As Integer)
            fields("page_numbering_offset") = value.ToString()
        End Sub

        Public Sub setHeaderFooterPageExcludeList(value As String)
            fields("header_footer_page_exclude_list") = value
        End Sub

        Public Sub setWatermark(url As String, offset_x As Single, offset_y As Single)
            fields("watermark_url") = url
            fields("watermark_offset_x") = offset_x.ToString()
            fields("watermark_offset_y") = offset_y.ToString()
        End Sub

        Public Sub setWatermark(url As String, offset_x As String, offset_y As String)
            fields("watermark_url") = url
            fields("watermark_offset_x") = offset_x
            fields("watermark_offset_y") = offset_y
        End Sub

        Public Sub setWatermarkRotation(angle As Double)
            fields("watermark_rotation") = angle.ToString()
        End Sub

        Public Sub setWatermarkInBackground()
            setWatermarkInBackground(True)
        End Sub

        Public Sub setWatermarkInBackground(val As Boolean)
            fields("watermark_in_background") = If(val, "true", Nothing)
        End Sub




        ' ---------------------------------------------------------------------------
        '
        '                        Private stuff
        '

        Shared API_SELECTOR_BASE As String = "/api/"

        Public HOST As String = "pdfcrowd.com"
        Public Shared HTTP_PORT As Integer = 80
        Public Shared HTTPS_PORT As Integer = 443

        Private fields As New StringDictionary()
        Private api_uri As String


        Private Sub convert(out_stream As Stream, method As String, src As String)
            Dim uri As String = [String].Format("{0}pdf/convert/{1}/", api_uri, method)
            call_api(uri, out_stream, src)
        End Sub

        Private Shared Sub CopyStream(input As Stream, output As Stream)
            Dim buffer As Byte() = New Byte(32767) {}
            While True
                Dim read As Integer = input.Read(buffer, 0, buffer.Length)
                If read <= 0 Then
                    Return
                End If
                output.Write(buffer, 0, read)
            End While
        End Sub


        Private Sub call_api(uri As String, out_stream As Stream, src As String)
            Dim extra_data As New StringDictionary()
            If src IsNot Nothing Then
                extra_data("src") = src
            End If
            Dim data As String = encode_post_data(extra_data)
            do_request(uri, out_stream, data, "application/x-www-form-urlencoded")
        End Sub

        Private Shared Sub do_request(uri As String, out_stream As Stream, data As Object, content_type As String)
            Dim request As WebRequest = WebRequest.Create(uri)
            request.Method = "POST"

            Dim byteArray As Byte()
            If (TypeOf data Is Byte()) Then
                byteArray = DirectCast(data, Byte())
            Else
                byteArray = Encoding.UTF8.GetBytes(DirectCast(data, String))
            End If
            request.ContentType = content_type
            request.ContentLength = byteArray.Length
            Try
                Using dataStream As Stream = request.GetRequestStream()
                    dataStream.Write(byteArray, 0, byteArray.Length)
                End Using

                ' Get the response.
                Using response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
                    If response.StatusCode = HttpStatusCode.OK Then
                        ' Get the stream containing content returned by the server.
                        Using dataStream As Stream = response.GetResponseStream()
                            CopyStream(dataStream, out_stream)
                            out_stream.Position = 0
                        End Using
                    Else
                        Throw New [Error](response.StatusDescription, response.StatusCode)
                    End If
                End Using
            Catch why As WebException
                If why.Status = WebExceptionStatus.ProtocolError Then
                    Dim response As HttpWebResponse = DirectCast(why.Response, HttpWebResponse)

                    Dim stream As New MemoryStream()
                    CopyStream(response.GetResponseStream(), stream)
                    stream.Position = 0
                    Dim err As String = read_stream(stream)
                    Throw New [Error](err, response.StatusCode)
                Else
                    Dim innerException As String = ""
                    If why.InnerException IsNot Nothing Then
                        innerException = vbLf + why.InnerException.Message
                    End If
                    Throw New [Error](why.Message + innerException, HttpStatusCode.Unused)
                End If
            End Try
        End Sub

        Private Function encode_post_data(extra_data As StringDictionary) As String
            Dim data As New StringDictionary()
            If extra_data IsNot Nothing Then
                For Each entry As DictionaryEntry In extra_data
                    If entry.Value IsNot Nothing Then
                        data.Add(entry.Key.ToString(), entry.Value.ToString())
                    End If
                Next
            End If

            For Each entry As DictionaryEntry In fields
                If entry.Value IsNot Nothing Then
                    data.Add(entry.Key.ToString(), entry.Value.ToString())
                End If
            Next
            Dim result As String = ""
            Dim i As Integer = 0
            For Each entry As DictionaryEntry In data
                result += HttpUtility.UrlEncode(entry.Key.ToString()) + "=" + HttpUtility.UrlEncode(entry.Value.ToString())
                If i < data.Count Then
                    result += "&"
                End If
            Next
            Return result.Substring(0, result.Length - 1)
        End Function

        Private Shared boundary As String = "----------ThIs_Is_tHe_bOUnDary_$"
        ' Private Shared multipart_content_type As String = Convert.ToString("multipart/form-data; boundary=") & boundary
        Private Shared new_line As String = vbCr & vbLf

        Private Shared Function get_mime_type(fileName As String) As String
            Dim mimeType As String = "application/octet-stream"
            Dim ext As String = System.IO.Path.GetExtension(fileName).ToLower()
            Dim regKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext)
            If regKey IsNot Nothing AndAlso regKey.GetValue("Content Type") IsNot Nothing Then
                mimeType = regKey.GetValue("Content Type").ToString()
            End If
            Return mimeType
        End Function

        'Private Function encode_multipart_post_data(filename As String) As Byte()
        '    Dim memw As New MemoryStream()
        '    Dim retval As New BinaryWriter(memw)
        '    Dim utf8 As New UTF8Encoding()

        '    Dim result As String = ""
        '    For Each entry As DictionaryEntry In fields
        '        If entry.Value IsNot Nothing Then
        '            result += Convert.ToString(Convert.ToString("--") & boundary) & new_line
        '            result += [String].Format("Content-Disposition: form-data; name=""{0}""", entry.Key) & new_line
        '            result += new_line
        '            result += entry.Value.ToString() & new_line
        '        End If
        '    Next
        '    ' filename
        '    result += Convert.ToString(Convert.ToString("--") & boundary) & new_line
        '    result += [String].Format("Content-Disposition: form-data; name=""src""; filename=""{0}""", filename) & new_line
        '    result += Convert.ToString(Convert.ToString("Content-Type: ") & get_mime_type(filename)) & new_line
        '    result += new_line
        '    retval.Write(utf8.GetBytes(result))
        '    ' filename contents
        '    Using fin As FileStream = File.OpenRead(filename)
        '        Dim b As Byte() = New Byte(8191) {}
        '        Dim r As Integer
        '        While (InlineAssignHelper(r, fin.Read(b, 0, b.Length))) > 0
        '            retval.Write(b, 0, r)
        '        End While
        '    End Using
        '    ' finalize
        '    result = Convert.ToString((Convert.ToString(new_line & Convert.ToString("--")) & boundary) + "--") & new_line
        '    result += new_line

        '    retval.Write(utf8.GetBytes(result))
        '    retval.Flush()
        '    Return memw.ToArray()
        'End Function

        Private Shared Function read_stream(stream As Stream) As String
            Using reader As New StreamReader(stream, Encoding.UTF8)
                Return reader.ReadToEnd()
            End Using
        End Function

        'Private Sub post_multipart(fpath As String, out_stream As Stream)
        '    Dim data As Byte() = encode_multipart_post_data(fpath)
        '    do_request(api_uri & Convert.ToString("pdf/convert/html/"), out_stream, data, multipart_content_type)
        'End Sub
        Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function


    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
