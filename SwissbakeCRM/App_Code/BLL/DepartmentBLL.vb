Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class DepartmentBLL
    Private Shared _spname As String = "_spDepartment"


    Public Shared Function Insert(ByVal _Deprt_Name As String, ByVal _Deprt_CreatedId As Integer, ByVal _Deprt_ModifiedId As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Deprt_Name", _Deprt_Name)
            sqlparams(2) = New SqlParameter("@Deprt_CreatedId", _Deprt_CreatedId)
            sqlparams(3) = New SqlParameter("@Deprt_ModifiedId", _Deprt_ModifiedId)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal _Deprt_Name As String, ByVal _Deprt_ModifiedId As Integer, _ID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Deprt_Name", _Deprt_Name)
            sqlparams(2) = New SqlParameter("@Deprt_ModifiedId", _Deprt_ModifiedId)
            sqlparams(3) = New SqlParameter("@Deprt_Id", _ID)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
