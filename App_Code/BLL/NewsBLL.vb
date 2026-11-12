Imports Microsoft.VisualBasic
Imports APPCODE.DAL
Public Class NewsBLL
    Private Shared _spname As String = "_spNews"

    Public Shared Function Insert(ByVal _NTitle As String, ByVal _NShrtDesc As String, ByVal _NLongDesc As String, ByVal _NSeoDesc As String, ByVal _NSeoKeyword As String, ByVal _NSeoUrl As String, ByVal _CreatedID As Integer) As Integer
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@N_Title", _NTitle)
            sqlparams(2) = New SqlParameter("@N_ShrtDescription", _NShrtDesc)
            sqlparams(3) = New SqlParameter("@N_LongDescription", _NLongDesc)
            sqlparams(4) = New SqlParameter("@N_SeoDescription", _NSeoDesc)
            sqlparams(5) = New SqlParameter("@N_SeoKeyword", _NSeoKeyword)
            sqlparams(6) = New SqlParameter("@N_SeoUrl", _NSeoUrl)
            sqlparams(7) = New SqlParameter("@N_CreatedID", _CreatedID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal _NTitle As String, ByVal _NShrtDesc As String, ByVal _NLongDesc As String, ByVal _NSeoDesc As String, ByVal _NSeoKeyword As String, ByVal _NSeoUrl As String, ByVal _ModifiedID As Integer, ByVal _ID As Integer) As Integer
        Dim sqlparams(8) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@N_Title", _NTitle)
            sqlparams(2) = New SqlParameter("@N_ShrtDescription", _NShrtDesc)
            sqlparams(3) = New SqlParameter("@N_LongDescription", _NLongDesc)
            sqlparams(4) = New SqlParameter("@N_SeoDescription", _NSeoDesc)
            sqlparams(5) = New SqlParameter("@N_SeoKeyword", _NSeoKeyword)
            sqlparams(6) = New SqlParameter("@N_SeoUrl", _NSeoUrl)
            sqlparams(7) = New SqlParameter("@N_ModifiedID", _ModifiedID)
            sqlparams(8) = New SqlParameter("@N_ID", _ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function NewsDetail(ByVal _SeoUrl As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FillNewsDetails")
            sqlparams(1) = New SqlParameter("@N_SeoUrl", _SeoUrl)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
