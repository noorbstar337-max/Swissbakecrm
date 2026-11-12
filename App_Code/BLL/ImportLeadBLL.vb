Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class ImportLeadBLL
    Private Shared _spname As String = "_spImportLead"

    Public Shared Function LeadImporColumn() As DataSet
        Dim sqlparams(0) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "LeadImporColumn")
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function XMLInsert(ByVal XMLLead As String, ByVal XMLLeadAddress As String, ByVal XMLLeadContact As String, ByVal AudtTrail_LogId As Integer, ByVal Leadcount As Integer) As String
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "XMLInsert")
            sqlparams(1) = New SqlParameter("@XMLLead", XMLLead)
            sqlparams(2) = New SqlParameter("@XMLLeadAddress", XMLLeadAddress)
            sqlparams(3) = New SqlParameter("@XMLLeadContact", XMLLeadContact)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(5) = New SqlParameter("@action", Leadcount)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function countlead() As Integer
        Dim sqlparams(0) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "LeadCount")
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function LeadAddressCount() As Integer
        Dim sqlparams(0) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "LeadAddressCount")
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function LeadContactCount() As Integer
        Dim sqlparams(0) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "LeadContactCount")
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
