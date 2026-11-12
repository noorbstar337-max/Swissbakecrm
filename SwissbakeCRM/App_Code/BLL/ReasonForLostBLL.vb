Imports APPCODE.DAL

Public Class ReasonForLostBLL
    Private Shared _spname As String = "_spReasonForLost"

    Public Shared Function Insert(ByVal RFL_Name As String, ByVal AudtTrail_LogId As Integer, ByVal RFL_CreatedID As Integer, ByVal RFL_SequenceNo As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@RFL_Name", RFL_Name)
            sqlparams(2) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(3) = New SqlParameter("@RFL_CreatedID", RFL_CreatedID)
            sqlparams(4) = New SqlParameter("@RFL_SequenceNo", RFL_SequenceNo)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal RFL_Name As String, ByVal AudtTrail_LogId As Integer, ByVal RFL_ModifiedID As Integer, ByVal RFL_Id As Integer, ByVal RFL_SequenceNo As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@RFL_Name", RFL_Name)
            sqlparams(2) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(3) = New SqlParameter("@RFL_ModifiedID", RFL_ModifiedID)
            sqlparams(4) = New SqlParameter("@RFL_Id", RFL_Id)
            sqlparams(5) = New SqlParameter("@RFL_SequenceNo", RFL_SequenceNo)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
