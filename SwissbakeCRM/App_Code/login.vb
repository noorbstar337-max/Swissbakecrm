Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class login
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function Checklogin(ByVal username As String, ByVal password As String) As DataTable
        Dim ds As DataSet = UserBLL.ValidateLogin(username, password)
        Return ds.Tables(0)
    End Function

End Class