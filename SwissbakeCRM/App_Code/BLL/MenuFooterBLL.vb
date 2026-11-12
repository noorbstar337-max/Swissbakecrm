Imports Microsoft.VisualBasic
Imports APPCODE.DAL
Public Class MenuFooterBLL
    Private Shared _spname As String = "_spMenuFooter"

    Public Shared Function Insert(ByVal _MenuName As String, ByVal _MenuUrl As String, ByVal _MenuParentID As Integer, ByVal _MenuUrlType As String, ByVal _CreatedID As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            If Not HttpRuntime.Cache("DynamicparcelMenuFooter") Is Nothing Then HttpRuntime.Cache.Remove("DynamicparcelMenuFooter")
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@MF_Name", _MenuName)
            sqlparams(2) = New SqlParameter("@MF_Url", _MenuUrl)
            sqlparams(3) = New SqlParameter("@MF_LevelID", _MenuParentID)
            sqlparams(4) = New SqlParameter("@MF_CreatedID", _CreatedID)
            sqlparams(5) = New SqlParameter("@MF_UrlType", _MenuUrlType)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal _MenuName As String, ByVal _MenuUrl As String, ByVal _MenuParentID As Integer, ByVal _MenuUrlType As String, ByVal _ModifiedID As Integer, ByVal _ID As Integer) As Integer
        Dim sqlparams(6) As SqlParameter
        Try
            If Not HttpRuntime.Cache("DynamicparcelMenuFooter") Is Nothing Then HttpRuntime.Cache.Remove("DynamicparcelMenuFooter")
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@MF_Name", _MenuName)
            sqlparams(2) = New SqlParameter("@MF_Url", _MenuUrl)
            sqlparams(3) = New SqlParameter("@MF_LevelID", _MenuParentID)
            sqlparams(4) = New SqlParameter("@MF_ModifiedID", _ModifiedID)
            sqlparams(5) = New SqlParameter("@MF_ID", _ID)
            sqlparams(6) = New SqlParameter("@MF_UrlType", _MenuUrlType)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ChildFooter(ByVal ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ChildFooterItem")
            sqlparams(1) = New SqlParameter("@MF_LevelID", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function GetDynamicparcelMenuFooter() As String
        Return MainBLL.DynamicparcelMenuFooter()
    End Function

    Public Shared Function CheckMenuFooterChache() As Boolean
        If Not HttpRuntime.Cache("DynamicparcelMenuFooter") Is Nothing Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
