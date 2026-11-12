Imports APPCODE.DAL

Public Class FollowUpBLL
    Private Shared _spname As String = "_spFollowUp"

    Public Shared Function Insert(ByVal FollowUp_EmployeeID As Integer, ByVal FollowUp_LeadID As Integer, ByVal FollowUp_FollowUpStatus As String, ByVal FollowUp_Remark As String, ByVal FollowUp_CompanyID As Integer, ByVal FollowUp_CreatedType As String, ByVal FollowUp_CreatedID As Integer) As Integer
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@FollowUp_EmployeeID", FollowUp_EmployeeID)
            sqlparams(2) = New SqlParameter("@FollowUp_LeadID", FollowUp_LeadID)
            sqlparams(3) = New SqlParameter("@FollowUp_FollowUpStatus", FollowUp_FollowUpStatus)
            sqlparams(4) = New SqlParameter("@FollowUp_Remark", FollowUp_Remark)
            sqlparams(5) = New SqlParameter("@FollowUp_CompanyID", FollowUp_CompanyID)
            sqlparams(6) = New SqlParameter("@FollowUp_CreatedType", FollowUp_CreatedType)
            sqlparams(7) = New SqlParameter("@FollowUp_CreatedID", FollowUp_CreatedID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal FollowUp_EmployeeID As Integer, ByVal FollowUp_FollowUpStatus As String, ByVal FollowUp_Remark As String, ByVal FollowUp_CompanyID As Integer, ByVal FollowUp_ModifiedType As String, ByVal FollowUp_ModifiedID As Integer, ByVal FollowUp_Id As Integer, ByVal FollowUp_LeadID As Integer) As Integer
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@FollowUp_EmployeeID", FollowUp_EmployeeID)
            sqlparams(2) = New SqlParameter("@FollowUp_FollowUpStatus", FollowUp_FollowUpStatus)
            sqlparams(3) = New SqlParameter("@FollowUp_Remark", FollowUp_Remark)
            sqlparams(4) = New SqlParameter("@FollowUp_CompanyID", FollowUp_CompanyID)
            sqlparams(5) = New SqlParameter("@FollowUp_ModifiedType", FollowUp_ModifiedType)
            sqlparams(6) = New SqlParameter("@FollowUp_ModifiedID", FollowUp_ModifiedID)
            sqlparams(7) = New SqlParameter("@FollowUp_Id", FollowUp_Id)
            sqlparams(8) = New SqlParameter("@FollowUp_LeadID", FollowUp_LeadID)

            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
