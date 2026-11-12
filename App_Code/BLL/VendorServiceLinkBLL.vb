Imports APPCODE.DAL

Public Class VendorServiceLinkBLL
    Private Shared _spname As String = "_spVendorServiceLink"

    Public Shared Function Insert(ByVal Vsl_VendorId As Integer, ByVal Vsl_ServiceId As Integer, ByVal Vsl_ServiceValue As String, ByVal Vsl_CreatedID As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Vsl_VendorId", Vsl_VendorId)
            sqlparams(2) = New SqlParameter("@Vsl_ServiceId", Vsl_ServiceId)
            sqlparams(3) = New SqlParameter("@Vsl_ServiceValue", Vsl_ServiceValue)
            sqlparams(4) = New SqlParameter("@Vsl_CreatedID", Vsl_CreatedID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal Vsl_VendorId As Integer, ByVal Vsl_ServiceId As Integer, ByVal Vsl_ServiceValue As String, ByVal Vsl_ModifiedID As Integer, ByVal Vsl_ID As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Vsl_VendorId", Vsl_VendorId)
            sqlparams(2) = New SqlParameter("@Vsl_ServiceId", Vsl_ServiceId)
            sqlparams(3) = New SqlParameter("@Vsl_ServiceValue", Vsl_ServiceValue)
            sqlparams(4) = New SqlParameter("@Vsl_ModifiedID", Vsl_ModifiedID)
            sqlparams(5) = New SqlParameter("@Vsl_ID", Vsl_ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
