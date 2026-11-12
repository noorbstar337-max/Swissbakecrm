Imports APPCODE.DAL

Public Class LeadTypeBLL
    Private Shared _spname As String = "_spLeadType"

    Public Shared Function Insert(ByVal LeadType As String, ByVal AudtTrail_LogId As Integer, ByVal LeadType_CreatedID As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@LeadType", LeadType)
            sqlparams(2) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(3) = New SqlParameter("@LeadType_CreatedID", LeadType_CreatedID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal LeadType As String, ByVal AudtTrail_LogId As Integer, ByVal LeadType_ModifiedID As Integer, ByVal LeadType_ID As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@LeadType", LeadType)
            sqlparams(2) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(3) = New SqlParameter("@LeadType_ModifiedID", LeadType_ModifiedID)
            sqlparams(4) = New SqlParameter("@LeadType_ID", LeadType_ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
