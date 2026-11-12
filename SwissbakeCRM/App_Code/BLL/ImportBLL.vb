Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class ImportBLL

    Public Shared Function XMLInsert(ByVal productxml As String, ByVal pricexml As String) As String
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@productxml", productxml)
            sqlparams(2) = New SqlParameter("@pricexml", pricexml)

            Return DBBridge.ExecuteScalar("_Imported", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function XMLInsertDistributor(ByVal partyxml As String, ByVal partadd As String, ByVal partcontxml As String) As String
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertDistributor")
            sqlparams(1) = New SqlParameter("@partyxml", partyxml)
            sqlparams(2) = New SqlParameter("@partadd", partadd)
            sqlparams(3) = New SqlParameter("@partcontxml", partcontxml)
            Return DBBridge.ExecuteScalar("_Imported", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
