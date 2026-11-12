
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

Imports System.Collections.Generic
Imports System.Text
Imports System.Net

Namespace pdfcrowd
    Public Class [Error]
        Inherits Exception

        Private [error] As String = ""
        Private http_code As HttpStatusCode = HttpStatusCode.Unused

        Public Sub New(_error As String, _http_code As HttpStatusCode)
            [error] = _error
            http_code = _http_code
        End Sub

        Public Overrides Function ToString() As String
            If http_code <> HttpStatusCode.Unused Then
                Return [String].Format("{0} - {1}", CInt(http_code), [error])
            Else
                Return [error]
            End If
        End Function
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
