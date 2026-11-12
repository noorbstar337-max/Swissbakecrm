Imports APPCODE.DAL

Public Class HomepageImageBLL
    Private Shared _spname As String = "_spHomepageImage"

    Public Shared Function Update(ByVal type As String, ByVal name As String, ByVal description As String, ByVal Image_url As String, ByVal MenuType As String, ByVal MenuUrl As String, ByVal id As Integer) As Integer
        Dim sqlparams(8) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@type", type)
            sqlparams(2) = New SqlParameter("@name", name)
            sqlparams(3) = New SqlParameter("@description", description)
            sqlparams(4) = New SqlParameter("@Image_url", Image_url)
            sqlparams(5) = New SqlParameter("@MenuType", MenuType)
            sqlparams(6) = New SqlParameter("@MenuUrl", MenuUrl)
            sqlparams(7) = New SqlParameter("@id", id)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Insert(ByVal type As String, ByVal name As String, ByVal description As String, ByVal Image_url As String, ByVal MenuType As String, ByVal MenuUrl As String) As Integer
        Dim sqlparams(8) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@type", type)
            sqlparams(2) = New SqlParameter("@name", name)
            sqlparams(3) = New SqlParameter("@description", description)
            sqlparams(4) = New SqlParameter("@Image_url", Image_url)
            sqlparams(5) = New SqlParameter("@MenuType", MenuType)
            sqlparams(6) = New SqlParameter("@MenuUrl", MenuUrl)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
