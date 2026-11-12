Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class ColoumSettingBLL
    Private Shared _spname As String = "_spColoumPageSetting"

    Public Shared Function Insert(ByVal _UserId As Integer, ByVal _TableName As String, ByVal _ColoumName As String, ByVal _DelColoum As String,
      ByVal _PrimaryColoum As String, ByVal _CreatedId As Integer, ByVal AudtTrail_LogId As Integer, ByVal TableName As String) As Integer
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@ColoumSetting_UserId", _UserId)
            sqlparams(2) = New SqlParameter("@ColoumSetting_ColoumName", _ColoumName)
            sqlparams(3) = New SqlParameter("@ColoumSetting_MenuUrl", TableName)
            sqlparams(4) = New SqlParameter("@ColoumSetting_DelColoum", _DelColoum)
            sqlparams(5) = New SqlParameter("@ColoumSetting_PrimaryColoum", _PrimaryColoum)
            sqlparams(6) = New SqlParameter("@ColoumSetting_TableName", _TableName)
            sqlparams(7) = New SqlParameter("@ColoumSetting_CreatedId", _CreatedId)
            sqlparams(8) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal _UserId As Integer, ByVal _TableName As String, ByVal _ColoumName As String, ByVal _DelColoum As String,
    ByVal _PrimaryColoum As String, ByVal _CreatedId As Integer, ByVal AudtTrail_LogId As Integer, ByVal TableName As String) As Integer
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@ColoumSetting_UserId", _UserId)
            sqlparams(2) = New SqlParameter("@ColoumSetting_ColoumName", _ColoumName)
            sqlparams(3) = New SqlParameter("@ColoumSetting_MenuUrl", TableName)
            sqlparams(4) = New SqlParameter("@ColoumSetting_DelColoum", _DelColoum)
            sqlparams(5) = New SqlParameter("@ColoumSetting_PrimaryColoum", _PrimaryColoum)
            sqlparams(6) = New SqlParameter("@ColoumSetting_TableName", _TableName)
            sqlparams(7) = New SqlParameter("@ColoumSetting_CreatedId", _CreatedId)
            sqlparams(8) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function CheckSettingExist(ByVal _UserId As Integer, ByVal _TableName As String) As String
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "CheckSettingExist")
            sqlparams(1) = New SqlParameter("@ColoumSetting_UserId", _UserId)
            sqlparams(2) = New SqlParameter("@ColoumSetting_TableName", _TableName)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function



End Class
