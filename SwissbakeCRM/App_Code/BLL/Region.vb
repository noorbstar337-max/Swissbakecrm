Imports APPCODE.DAL

Public Class RegionBLL
    Private Shared _spname As String = "_spRegion"

    Public Shared Function Insert(ByVal Region_Name As String, ByVal Region_CreatedID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Region_Name", Region_Name)
            sqlparams(2) = New SqlParameter("@Region_CreatedID", Region_CreatedID)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal Region_Name As String, ByVal Region_ModifiedID As Integer, ByVal Region_Id As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Region_Name", Region_Name)
            sqlparams(2) = New SqlParameter("@Region_ModifiedID", Region_ModifiedID)
            sqlparams(3) = New SqlParameter("@Region_Id", Region_Id)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
