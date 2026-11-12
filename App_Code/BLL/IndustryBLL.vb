Imports APPCODE.DAL

Public Class IndustryBLL
    Private Shared _spname As String = "_spIndustry"

    Public Shared Function Insert(ByVal Industry_Name As String, ByVal Industry_CreatedID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Industry_Name", Industry_Name)
            sqlparams(2) = New SqlParameter("@Industry_CreatedID", Industry_CreatedID)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal Industry_Name As String, ByVal Industry_ModifiedID As Integer, ByVal Industry_Id As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Industry_Name", Industry_Name)
            sqlparams(2) = New SqlParameter("@Industry_ModifiedID", Industry_ModifiedID)
            sqlparams(3) = New SqlParameter("@Industry_Id", Industry_Id)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
