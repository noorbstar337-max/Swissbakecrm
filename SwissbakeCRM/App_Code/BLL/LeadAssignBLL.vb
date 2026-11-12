Imports APPCODE.DAL

Public Class LeadAssignBLL
    Private Shared _spname As String = "_spLeadAssign"

    Public Shared Function Insert(ByVal LeadAssign_EmployeeID As Integer, ByVal LeadAssign_LeadID As Integer, ByVal LeadAssign_CompanyID As Integer, ByVal LeadAssign_CreatedType As String, ByVal LeadAssign_CreatedID As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@LeadAssign_EmployeeID", LeadAssign_EmployeeID)
            sqlparams(2) = New SqlParameter("@LeadAssign_LeadID", LeadAssign_LeadID)
            sqlparams(3) = New SqlParameter("@LeadAssign_CompanyID", LeadAssign_CompanyID)
            sqlparams(4) = New SqlParameter("@LeadAssign_CreatedType", LeadAssign_CreatedType)
            sqlparams(5) = New SqlParameter("@LeadAssign_CreatedID", LeadAssign_CreatedID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal LeadAssign_EmployeeID As Integer, ByVal LeadAssign_LeadID As Integer, ByVal LeadAssign_CompanyID As Integer, ByVal LeadAssign_ModifiedType As String, ByVal LeadAssign_ModifiedID As Integer, ByVal LeadAssign_ID As Integer) As Integer
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@LeadAssign_EmployeeID", LeadAssign_EmployeeID)
            sqlparams(2) = New SqlParameter("@LeadAssign_LeadID", LeadAssign_LeadID)
            sqlparams(3) = New SqlParameter("@LeadAssign_CompanyID", LeadAssign_CompanyID)
            sqlparams(4) = New SqlParameter("@LeadAssign_ModifiedType", LeadAssign_ModifiedType)
            sqlparams(5) = New SqlParameter("@LeadAssign_ModifiedID", LeadAssign_ModifiedID)
            sqlparams(6) = New SqlParameter("@LeadAssign_ID", LeadAssign_ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
