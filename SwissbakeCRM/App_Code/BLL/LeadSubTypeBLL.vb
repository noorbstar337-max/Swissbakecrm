Imports APPCODE.DAL

Public Class LeadSubTypeBLL
    Private Shared _spname As String = "_spLeadSubType"

    Public Shared Function Insert(ByVal LeadSubType As String, ByVal LeadSubType_CompanyID As Integer, ByVal LeadSubType_CreatedType As String, ByVal LeadSubType_CreatedID As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@LeadSubType", LeadSubType)
            sqlparams(2) = New SqlParameter("@LeadSubType_CompanyID", LeadSubType_CompanyID)
            sqlparams(3) = New SqlParameter("@LeadSubType_CreatedType", LeadSubType_CreatedType)
            sqlparams(4) = New SqlParameter("@LeadSubType_CreatedID", LeadSubType_CreatedID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal LeadSubType As String, ByVal LeadSubType_CompanyID As Integer, ByVal LeadSubType_ModifiedType As String, ByVal LeadSubType_ModifiedID As Integer, ByVal LeadSubType_ID As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@LeadSubType", LeadSubType)
            sqlparams(2) = New SqlParameter("@LeadSubType_CompanyID", LeadSubType_CompanyID)
            sqlparams(3) = New SqlParameter("@LeadSubType_ModifiedType", LeadSubType_ModifiedType)
            sqlparams(4) = New SqlParameter("@LeadSubType_ModifiedID", LeadSubType_ModifiedID)
            sqlparams(5) = New SqlParameter("@LeadSubType_ID", LeadSubType_ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
