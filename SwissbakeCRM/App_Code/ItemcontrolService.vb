Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Newtonsoft.Json

'Imports Newtonsoft.Json

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class ItemcontrolService
    Inherits System.Web.Services.WebService


    <WebMethod()>
    Public Function Encrypt(ByVal id As Integer) As String
        Try
            Return HttpUtility.UrlEncode(Security.Encrypt(id.ToString()))
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    <WebMethod()>
    Public Function MultiEncrypt(ByVal id As Integer, ByVal custid As Integer) As String
        Try
            Return HttpUtility.UrlEncode(Security.Encrypt(id.ToString())) + "," + HttpUtility.UrlEncode(Security.Encrypt(custid.ToString()))
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    <WebMethod()>
    Public Function TripleEncrypt(ByVal invid As Integer, ByVal id As Integer, ByVal custid As Integer) As String
        Try
            Return HttpUtility.UrlEncode(Security.Encrypt(invid.ToString())) + "," + HttpUtility.UrlEncode(Security.Encrypt(id.ToString())) + "," + HttpUtility.UrlEncode(Security.Encrypt(custid.ToString()))
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    <WebMethod()>
    Public Function DoubleEncrypt(ByVal id As Integer, ByVal type As String) As String
        Try
            Return HttpUtility.UrlEncode(Security.Encrypt(id.ToString())) + "," + HttpUtility.UrlEncode(Security.Encrypt(type.ToString())) '+ "," + HttpUtility.UrlEncode(Security.Encrypt(custid.ToString()))
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    <WebMethod(EnableSession:=True)>
    Public Sub Filldropdown()
        Try
            Dim dt As New DataTable
            dt = SampleBLL.LiveDropdownWithtypeAndID("AccountLiveDropDown", "Account", Session("UserId"), HttpContext.Current.Request.Form("value1"), HttpContext.Current.Request.Form("q")).Tables(0)

            '  Dim Notifi As IList(Of data) = New List(Of data)()
            If dt.Rows.Count > 0 Then

                Dim rows As List(Of Dictionary(Of String, Object)) = ConvertDTForJson(dt)
                Dim sJSONResponse As String = JsonConvert.SerializeObject(rows)
                'Return Notifi
                Context.Response.Write(sJSONResponse)
                'Return JsonConvert.SerializeObject(dt, Formatting.Indented)
            Else
                'Return (("{""status"":false,""data"":[]}")).ToArray
                '  Return Notifi
            End If
            ' Return New MemoryStream(Encoding.UTF8.GetBytes("{""status"":true,""data"":" + GetJson(js) + "}"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Shared Function ConvertDTForJson(ByVal dt As DataTable) As List(Of Dictionary(Of String, Object))
        Dim rows As List(Of Dictionary(Of String, Object)) = New List(Of Dictionary(Of String, Object))()
        Dim row As Dictionary(Of String, Object)

        For Each dr As DataRow In dt.Rows
            row = New Dictionary(Of String, Object)()

            For Each col As DataColumn In dt.Columns
                row.Add(col.ColumnName, dr(col))
            Next

            rows.Add(row)
        Next

        Return rows
    End Function
End Class
'Class data
'    '  Public Property Name As String
'    Public Property text As String
'    'Public Property Url As String

'    'Public Property Status As String

'    'Public Property Datetime As String


'    Public Property id As Integer



'End Class