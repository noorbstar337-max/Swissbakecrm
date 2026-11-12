Imports APPCODE.DAL

Public Class PartnerBLL
    Private Shared _spname As String = "_spPartner"
    Public Shared Function Insert(ByVal PT_Name As String, ByVal PT_Logo As String, ByVal PT_FuelTax As String, ByVal PT_ServiceTax As String, ByVal PT_CreatedID As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@PT_Name", PT_Name)
            sqlparams(2) = New SqlParameter("@PT_Logo", PT_Logo)
            sqlparams(3) = New SqlParameter("@PT_FuelTax", PT_FuelTax)
            sqlparams(4) = New SqlParameter("@PT_ServiceTax", PT_ServiceTax)
            sqlparams(5) = New SqlParameter("@PT_CreatedID", PT_CreatedID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal PT_Name As String, ByVal PT_Logo As String, ByVal PT_FuelTax As String, ByVal PT_ServiceTax As String, ByVal PT_ModifiedID As Integer, ByVal PT_ID As Integer) As Integer
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@PT_Name", PT_Name)
            sqlparams(2) = New SqlParameter("@PT_Logo", PT_Logo)
            sqlparams(3) = New SqlParameter("@PT_FuelTax", PT_FuelTax)
            sqlparams(4) = New SqlParameter("@PT_ServiceTax", PT_ServiceTax)
            sqlparams(5) = New SqlParameter("@PT_ModifiedID", PT_ModifiedID)
            sqlparams(6) = New SqlParameter("@PT_ID", PT_ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
