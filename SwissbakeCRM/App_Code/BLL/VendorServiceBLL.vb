Imports APPCODE.DAL

Public Class VendorServiceBLL
    Private Shared _spname As String = "_spVendorService"

    Public Shared Function Insert(ByVal Vs_Name As String, ByVal Vs_Icon As String, ByVal Vs_CreatedID As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Vs_Name", Vs_Name)
            sqlparams(2) = New SqlParameter("@Vs_Icon", Vs_Icon)
            sqlparams(3) = New SqlParameter("@Vs_CreatedID", Vs_CreatedID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal Vs_Name As String, ByVal Vs_Icon As String, ByVal Vs_ModifiedID As Integer, ByVal Vs_ID As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Vs_Name", Vs_Name)
            sqlparams(2) = New SqlParameter("@Vs_Icon", Vs_Icon)
            sqlparams(3) = New SqlParameter("@Vs_ModifiedID", Vs_ModifiedID)
            sqlparams(4) = New SqlParameter("@Vs_ID", Vs_ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
