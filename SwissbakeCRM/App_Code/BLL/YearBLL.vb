Imports APPCODE.DAL

Public Class YearBLL
    Private Shared _spname As String = "_spYear"

    Public Shared Function Insert(ByVal Year As String, ByVal Year_CreatedID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Year", Year)
            sqlparams(2) = New SqlParameter("@Year_CreatedID", Year_CreatedID)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal Year As String, ByVal Year_ModifiedID As Integer, ByVal Year_ID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Year", Year)
            sqlparams(2) = New SqlParameter("@Year_ModifiedID", Year_ModifiedID)
            sqlparams(3) = New SqlParameter("@Year_ID", Year_ID)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
