Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Net
Imports Newtonsoft.Json.Linq
Imports System.Web

Public Class ActivityLogger

    '================ GET REAL CLIENT IP =================
    Private Shared Function GetClientIP(request As HttpRequest) As String
        Dim ip As String = request.ServerVariables("HTTP_X_FORWARDED_FOR")

        If String.IsNullOrEmpty(ip) Then
            ip = request.ServerVariables("REMOTE_ADDR")
        End If

        If ip = "::1" Then
            ip = "127.0.0.1"
        End If

        Return ip
    End Function


    '================ GET CITY / STATE / COUNTRY =================
    Private Shared Sub GetGeoInfo(ip As String,
                                  ByRef city As String,
                                  ByRef state As String,
                                  ByRef country As String)
        Try
            Dim url As String = "http://ip-api.com/json/" & ip
            Dim wc As New WebClient()
            Dim json As String = wc.DownloadString(url)

            Dim obj = JObject.Parse(json)
            city = obj("city").ToString()
            state = obj("regionName").ToString()
            country = obj("country").ToString()

        Catch
            city = Nothing
            state = Nothing
            country = Nothing
        End Try
    End Sub


    '================ SAVE LOG =================
    Public Shared Sub SaveLog(
        userId As Integer?,
        userName As String,
        actionName As String,
        moduleName As String,
        orderNo As String,
        description As String,
        request As HttpRequest
    )

        Dim ip As String = GetClientIP(request)

        Dim city As String = Nothing
        Dim state As String = Nothing
        Dim country As String = Nothing

        ' Geo lookup only for real IPs
        If ip <> "127.0.0.1" Then
            GetGeoInfo(ip, city, state, country)
        End If

        Using con As New SqlConnection(
            ConfigurationManager.ConnectionStrings("connectionString").ConnectionString)

            Dim sql As String =
                "INSERT INTO ActivityLog " &
                "(UserId, UserName, Action, Module, Description, IPAddress, Browser, City, State, Country) " &
                "VALUES " &
                "(@UserId, @UserName, @Action, @Module, @Description, @IP, @Browser, @City, @State, @Country)"

            Using cmd As New SqlCommand(sql, con)

                cmd.Parameters.AddWithValue("@UserId", If(userId.HasValue, userId.Value, CType(DBNull.Value, Object)))
                cmd.Parameters.AddWithValue("@UserName", userName)
                cmd.Parameters.AddWithValue("@Action", actionName)
                cmd.Parameters.AddWithValue("@Module", moduleName)
                ' cmd.Parameters.AddWithValue("@OrderNo", If(String.IsNullOrEmpty(orderNo), CType(DBNull.Value, Object), orderNo))
                cmd.Parameters.AddWithValue("@Description", description)
                cmd.Parameters.AddWithValue("@IP", ip)
                cmd.Parameters.AddWithValue("@Browser", request.Browser.Browser & " " & request.Browser.Version)
                cmd.Parameters.AddWithValue("@City", If(city, CType(DBNull.Value, Object)))
                cmd.Parameters.AddWithValue("@State", If(state, CType(DBNull.Value, Object)))
                cmd.Parameters.AddWithValue("@Country", If(country, CType(DBNull.Value, Object)))

                con.Open()
                cmd.ExecuteNonQuery()

            End Using
        End Using
    End Sub

End Class