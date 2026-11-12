Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class ImportAccountBLL
    Private Shared _spname As String = "_spImportAccount"

    Public Shared Function XMLInsert(ByVal XMLAccount As String, ByVal XMLAddress As String, ByVal XMLContact As String, ByVal AudtTrail_LogId As Integer, ByVal Accountcount As Integer, ByVal AddressCount As Integer, ByVal ContactCount As Integer) As String
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "XMLInsert")
            sqlparams(1) = New SqlParameter("@XMLAccount", XMLAccount)
            sqlparams(2) = New SqlParameter("@XMLAddress", XMLAddress)
            sqlparams(3) = New SqlParameter("@XMLContact", XMLContact)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(5) = New SqlParameter("@Accountcount", Accountcount)
            sqlparams(6) = New SqlParameter("@AddressCount", AddressCount)
            sqlparams(7) = New SqlParameter("@ContactCount", ContactCount)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function XMLInsertAccountContact(ByVal XMLContact As String, ByVal AudtTrail_LogId As Integer) As String
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "XMLContactInsert")
            sqlparams(1) = New SqlParameter("@XMLContact", XMLContact)
            sqlparams(2) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function XMLInsertAccountVAT(ByVal XMLContact As String) As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "XMLVATInsert")
            sqlparams(1) = New SqlParameter("@XMLContact", XMLContact)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function XMLInsertEmailStatus(ByVal XMLImportStatus As String) As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "XMLInsertEmailStatus")
            sqlparams(1) = New SqlParameter("@XMLImportStatus", XMLImportStatus)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function countAccount() As Integer
        Dim sqlparams(0) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "AccountCount")
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function MaxContactID() As Integer
        Dim sqlparams(0) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "MaxContactID")
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function AccountAddressCount() As Integer
        Dim sqlparams(0) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "AccountAddressCount")
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function AccountCode() As String
        Dim sqlparams(0) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "AccountCode")
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ProspectCode() As String
        Dim sqlparams(0) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ProspectCode")
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Importstatus() As Integer
        Dim sqlparams(0) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Importstatus")
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function AccountImporColumn() As DataSet
        Dim sqlparams(0) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "AccountImporColumn")
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
