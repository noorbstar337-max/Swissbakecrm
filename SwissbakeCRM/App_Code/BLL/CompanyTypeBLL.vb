Imports APPCODE.DAL

Public Class CompanyTypeBLL
    Private Shared _spname As String = "_spCompanyType"

    Public Shared Function Insert(ByVal CompanyType As String, ByVal CompanyType_CreatedID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@CompanyType", CompanyType)
            sqlparams(2) = New SqlParameter("@CompanyType_CreatedID", CompanyType_CreatedID)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal CompanyType As String, ByVal CompanyType_ModifiedID As Integer, ByVal CompanyType_ID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@CompanyType", CompanyType)
            sqlparams(2) = New SqlParameter("@CompanyType_ModifiedID", CompanyType_ModifiedID)
            sqlparams(3) = New SqlParameter("@CompanyType_ID", CompanyType_ID)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
