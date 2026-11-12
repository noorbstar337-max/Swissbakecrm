Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class MappingTaxNameBLL
    Private Shared _spname As String = "_spMappingTaxName"

    Public Shared Function DeleteAssignTo(ByVal TaxMapping_TaxID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "DeleteTaxMapping")
            sqlparams(1) = New SqlParameter("@TaxMapping_TaxID", TaxMapping_TaxID)
            sqlparams(2) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function XMLInsert(ByVal XMLTaxMapping As String, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "XMLInsert")
            sqlparams(1) = New SqlParameter("@XMLTaxMapping", XMLTaxMapping)
            sqlparams(2) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function MaxAssignTo() As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "MaxTaxMapping")
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillAssignTo(ByVal TaxMapping_MainTaxID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FillTaxMapping")
            sqlparams(1) = New SqlParameter("@TaxMapping_MainTaxID", TaxMapping_MainTaxID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
