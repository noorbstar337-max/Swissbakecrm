Imports APPCODE.DAL

Public Class VendorTypeBLL
    Private Shared _spname As String = "_spVendorType"

    Public Shared Function Insert(ByVal _Type As String, ByVal _CreatedID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@VendorType_Name", _Type)
            sqlparams(2) = New SqlParameter("@VendorType_CreateID", _CreatedID)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal _Type As String, ByVal _ModifiedID As Integer, ByVal _Id As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@VendorType_Name", _Type)
            sqlparams(2) = New SqlParameter("@VendorType_ModifiedID", _ModifiedID)
            sqlparams(3) = New SqlParameter("@VendorType_ID", _Id)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
