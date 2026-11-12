Imports APPCODE.DAL

Public Class CurrencyBLL
    Private Shared _spname As String = "_spCurrency"

    Public Shared Function Insert(ByVal Currency_Code As String, ByVal Currency_Name As String, ByVal Currency_CreatedID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Currency_Code", Currency_Code)
            sqlparams(2) = New SqlParameter("@Currency_Name", Currency_Name)
            sqlparams(3) = New SqlParameter("@Currency_CreatedID", Currency_CreatedID)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)

            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal Currency_Code As String, ByVal Currency_Name As String, ByVal Currency_ModifiedID As Integer, ByVal Currency_ID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Currency_Code", Currency_Code)
            sqlparams(2) = New SqlParameter("@Currency_Name", Currency_Name)
            sqlparams(3) = New SqlParameter("@Currency_ModifiedID", Currency_ModifiedID)
            sqlparams(4) = New SqlParameter("@Currency_ID", Currency_ID)
            sqlparams(5) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)

            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
