Imports APPCODE.DAL
Public Class PrivilageBLL
    Private Shared _spname As String = "_spPrivilage"

    Public Shared Function FillPrivilage(ByVal _LevelID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FillPrivilage")
            sqlparams(1) = New SqlParameter("@Prvg_LevelId", _LevelID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertPrivilage(ByVal XMLPrivilage As String) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertPrivilage")
            sqlparams(1) = New SqlParameter("@XMLPrivilage", XMLPrivilage)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DeletePrivilige(ByVal LevelID As String) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "DeletePrivilige")
            sqlparams(1) = New SqlParameter("@Prvg_LevelId", LevelID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function CheckPrivilige(ByVal _LevelID As Integer, _MenuUrl As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "CheckPrivilige")
            sqlparams(1) = New SqlParameter("@Prvg_LevelId", _LevelID)
            sqlparams(2) = New SqlParameter("@Menuurl", _MenuUrl)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '------------Added by MUBYN Used in Dynamic Parcel for LMS
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
End Class
