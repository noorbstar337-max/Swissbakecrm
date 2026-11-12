Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class LMSPrivilegeBLL
    Private Shared _spname As String = "_spLMSPrivilege"

    '-----------Created by MUBYN and used at LMSPrivilege.aspx 30-04-2018
    Public Shared Function FillLMSPrivilege(ByVal _LevelID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FillLMSPrivilege")
            sqlparams(1) = New SqlParameter("@Prvg_LevelId", _LevelID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '-----------Created by MUBYN and used at LMSPrivilege.aspx 30-04-2018
    Public Shared Function InsertLMSPrivilege(ByVal XMLPrivilage As String) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertLMSPrivilege")
            sqlparams(1) = New SqlParameter("@XMLPrivilage", XMLPrivilage)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '-----------Created by MUBYN and used at LMSPrivilege.aspx 30-04-2018
    Public Shared Function DeleteLMSPrivilige(ByVal LevelID As String) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "DeleteLMSPrivilige")
            sqlparams(1) = New SqlParameter("@Prvg_LevelId", LevelID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '-----------Created by MUBYN and used at LMSPrivilege.aspx 30-04-2018
    Public Shared Function CheckLMSPrivilege(ByVal _LevelID As Integer, _MenuUrl As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "CheckLMSPrivilege")
            sqlparams(1) = New SqlParameter("@Prvg_LevelId", _LevelID)
            sqlparams(2) = New SqlParameter("@Menuurl", _MenuUrl)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ChkLMSPrivilegeTrails(ByVal _LevelID As Integer) As DataSet
        '-----------Created by MUBYN and used at LMSPrivilege.aspx 27-09-2018
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ChkLMSPrivilegeTrails")
            sqlparams(1) = New SqlParameter("@Prvg_LevelId", _LevelID)
            'sqlparams(2) = New SqlParameter("@Menuurl", _MenuUrl)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '-----------Created by MUBYN and used at LMSPrivilege.aspx 30-04-2018
    Public Shared Function CheckLMSPrivilegeMaster(ByVal _LevelID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "CheckLMSPrivilegeMaster")
            sqlparams(1) = New SqlParameter("@Prvg_LevelId", _LevelID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
