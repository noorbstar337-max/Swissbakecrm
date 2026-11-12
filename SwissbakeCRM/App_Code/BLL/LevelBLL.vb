Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class LevelBLL
    Private Shared _spname As String = "_spLevel"


    Public Shared Function Insert(ByVal _Name As String, ByVal _CreatedId As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Level_LevelName", _Name)
            sqlparams(2) = New SqlParameter("@Level_CreatedId", _CreatedId)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal _Name As String, ByVal _ModifiedId As Integer, _ID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Level_LevelName", _Name)
            sqlparams(2) = New SqlParameter("@Level_ModifiedId", _ModifiedId)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(4) = New SqlParameter("@Level_Id", _ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
