Imports APPCODE.DAL

Public Class SourceBLL
    Private Shared _spname As String = "_spSource"

    Public Shared Function Insert(ByVal Source_Name As String, ByVal Source_CreatedID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Source_Name", Source_Name)
            sqlparams(2) = New SqlParameter("@Source_CreatedID", Source_CreatedID)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal Source_Name As String, ByVal Source_ModifiedID As Integer, ByVal Source_Id As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Source_Name", Source_Name)
            sqlparams(2) = New SqlParameter("@Source_ModifiedID", Source_ModifiedID)
            sqlparams(3) = New SqlParameter("@Source_Id", Source_Id)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
