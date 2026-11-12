Imports Microsoft.VisualBasic
Imports APPCODE.DAL
Public Class PageBLL
    Private Shared _spname As String = "_spPage"

    Public Shared Function Insert(ByVal _PageName As String, ByVal _PageTitle As String, ByVal _PageDesc As String, ByVal _PageSeoUrl As String, ByVal _PageSeoDesc As String, ByVal _PageKeyword As String, ByVal _CreatedID As Integer) As Integer
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Page_Name", _PageName)
            sqlparams(2) = New SqlParameter("@Page_Title", _PageTitle)
            sqlparams(3) = New SqlParameter("@Page_Description", _PageDesc)
            sqlparams(4) = New SqlParameter("@Page_SeoUrl", _PageSeoUrl)
            sqlparams(5) = New SqlParameter("@Page_SeoDescription", _PageSeoDesc)
            sqlparams(6) = New SqlParameter("@Page_SeoKeyword", _PageKeyword)
            sqlparams(7) = New SqlParameter("@Page_CreatedID", _CreatedID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal _PageName As String, ByVal _PageTitle As String, ByVal _PageDesc As String, ByVal _PageSeoUrl As String, ByVal _PageSeoDesc As String, ByVal _PageKeyword As String, ByVal _ModifiedID As Integer, ByVal _ID As Integer) As Integer
        Dim sqlparams(8) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Page_Name", _PageName)
            sqlparams(2) = New SqlParameter("@Page_Title", _PageTitle)
            sqlparams(3) = New SqlParameter("@Page_Description", _PageDesc)
            sqlparams(4) = New SqlParameter("@Page_SeoUrl", _PageSeoUrl)
            sqlparams(5) = New SqlParameter("@Page_SeoDescription", _PageSeoDesc)
            sqlparams(6) = New SqlParameter("@Page_SeoKeyword", _PageKeyword)
            sqlparams(7) = New SqlParameter("@Page_CreatedID", _ModifiedID)
            sqlparams(8) = New SqlParameter("@Page_ID", _ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function CheckPageName(ByVal _PageName As String) As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "CheckPageName")
            sqlparams(1) = New SqlParameter("@Page_Name", _PageName)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
