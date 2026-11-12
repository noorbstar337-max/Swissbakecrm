Imports APPCODE.DAL

Public Class ContactTypeBLL
    Private Shared _spname As String = "_spContactType"

    Public Shared Function Insert(ByVal ContactType_Name As String, ByVal AudtTrail_LogId As Integer, ByVal ContactType_CreatedID As Integer, ByVal ContactType_SequenceNo As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@ContactType_Name", ContactType_Name)
            sqlparams(2) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(3) = New SqlParameter("@ContactType_CreatedID", ContactType_CreatedID)
            sqlparams(4) = New SqlParameter("@ContactType_SequenceNo", ContactType_SequenceNo)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal ContactType_Name As String, ByVal AudtTrail_LogId As Integer, ByVal ContactType_ModifiedID As Integer, ByVal ContactType_Id As Integer, ByVal ContactType_SequenceNo As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@ContactType_Name", ContactType_Name)
            sqlparams(2) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(3) = New SqlParameter("@ContactType_ModifiedID", ContactType_ModifiedID)
            sqlparams(4) = New SqlParameter("@ContactType_Id", ContactType_Id)
            sqlparams(5) = New SqlParameter("@ContactType_SequenceNo", ContactType_SequenceNo)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
