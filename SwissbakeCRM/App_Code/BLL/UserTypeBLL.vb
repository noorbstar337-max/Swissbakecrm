Imports APPCODE.DAL

Public Class UserTypeBLL
    Private Shared _spname As String = "_spUserType"

    Public Shared Function Insert(ByVal UType_Name As String, ByVal UType_CreatedID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@UType_Name", UType_Name)
            sqlparams(2) = New SqlParameter("@UType_CreatedID", UType_CreatedID)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal UType_Name As String, ByVal UType_ModifiedID As Integer, ByVal UType_ID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@UType_Name", UType_Name)
            sqlparams(2) = New SqlParameter("@UType_ModifiedID", UType_ModifiedID)
            sqlparams(3) = New SqlParameter("@UType_ID", UType_ID)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
