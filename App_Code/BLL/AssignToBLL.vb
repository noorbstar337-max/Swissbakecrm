Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class AssignToBLL
    Private Shared _spname As String = "_spAssignTo"
    Public Shared Function DeleteAssignTo(ByVal Type As String, ByVal TypeID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "DeleteAssignTo")
            sqlparams(1) = New SqlParameter("@Assignto_Type", Type)
            sqlparams(2) = New SqlParameter("@Assignto_TypeID", TypeID)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function XMLInsert(ByVal XMLAssignTo As String, ByVal AudtTrail_LogId As Integer, ByVal Type As String) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "XMLInsert")
            sqlparams(1) = New SqlParameter("@XMLAssignTo", XMLAssignTo)
            sqlparams(2) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(3) = New SqlParameter("@Assignto_Type", Type)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function MaxAssignTo() As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "MaxAssignTo")
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillAssignTo(ByVal Type As String, ByVal TypeID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FillAssignTo")
            sqlparams(1) = New SqlParameter("@Assignto_Type", Type)
            sqlparams(2) = New SqlParameter("@Assignto_TypeID", TypeID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '---Added By MUBYN for LMS
    Public Shared Function FillLMSAssignTo(ByVal Type As String, ByVal TypeID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FillLMSAssignTo")
            sqlparams(1) = New SqlParameter("@Assignto_Type", Type)
            sqlparams(2) = New SqlParameter("@Assignto_TypeID", TypeID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function FillLMSRecFormAssignTo(ByVal Type As String, ByVal TypeID As Integer) As DataSet
        '---Added By MUBYN for LMS
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FillLMSRecFormAssignTo")
            sqlparams(1) = New SqlParameter("@Assignto_Type", Type)
            sqlparams(2) = New SqlParameter("@Assignto_TypeID", TypeID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
