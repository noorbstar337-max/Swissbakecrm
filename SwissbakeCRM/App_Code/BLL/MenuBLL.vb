Imports Microsoft.VisualBasic
Imports APPCODE.DAL
Public Class MenuBLL
    Private Shared _spname As String = "_spMenu"

    Public Shared Function Insert(ByVal _MenuName As String, ByVal _MenuUrl As String, ByVal _MenuParentID As Integer, ByVal _MenuUrlType As String, ByVal _CreatedID As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Menu_Name", _MenuName)
            sqlparams(2) = New SqlParameter("@Menu_Url", _MenuUrl)
            sqlparams(3) = New SqlParameter("@Menu_ParentID", _MenuParentID)
            sqlparams(4) = New SqlParameter("@Menu_CreatedID", _CreatedID)
            sqlparams(5) = New SqlParameter("@Menu_UrlType", _MenuUrlType)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal _MenuName As String, ByVal _MenuUrl As String, ByVal _MenuParentID As Integer, ByVal _MenuUrlType As String, ByVal _ModifiedID As Integer, ByVal _ID As Integer) As Integer
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Menu_Name", _MenuName)
            sqlparams(2) = New SqlParameter("@Menu_Url", _MenuUrl)
            sqlparams(3) = New SqlParameter("@Menu_ParentID", _MenuParentID)
            sqlparams(4) = New SqlParameter("@Menu_ModifiedID", _ModifiedID)
            sqlparams(5) = New SqlParameter("@Menu_ID", _ID)
            sqlparams(6) = New SqlParameter("@Menu_UrlType", _MenuUrlType)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function GetDynamicparcelMenu() As String
        Return MainBLL.DynamicparcelMenu
    End Function
End Class
