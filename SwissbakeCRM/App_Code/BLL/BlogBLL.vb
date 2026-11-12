Imports Microsoft.VisualBasic
Imports APPCODE.DAL
Public Class BlogBLL
    
    Private Shared _spname As String = "_spBlog"

    Public Shared Function Insert(ByVal _MemberName As String, ByVal _BTitle As String, ByVal _BShrtDesc As String, ByVal _BLongDesc As String, ByVal _BSeoDesc As String,
                                  ByVal _CategoryID As Integer, ByVal _BImage As String,
                                  ByVal _BSeoKeyword As String, ByVal _BTag As String, ByVal _BSeoUrl As String, ByVal _CreatedID As Integer) As Integer
        Dim sqlparams(11) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Blog_BlogTitle", _BTitle)
            sqlparams(2) = New SqlParameter("@Blog_BlogDesc", _BShrtDesc)
            sqlparams(3) = New SqlParameter("@Blog_BlogPost", _BLongDesc)
            sqlparams(4) = New SqlParameter("@Blog_CategoryId", _CategoryID)
            sqlparams(5) = New SqlParameter("@Blog_BlogImage", _BImage)
            sqlparams(6) = New SqlParameter("@Blog_Tag", _BTag)
            sqlparams(7) = New SqlParameter("@Blog_SeoDescription", _BSeoDesc)
            sqlparams(8) = New SqlParameter("@Blog_SeoKeyword", _BSeoKeyword)
            sqlparams(9) = New SqlParameter("@Blog_SeoUrl", _BSeoUrl)
            sqlparams(10) = New SqlParameter("@Blog_CreatedID", _CreatedID)
            sqlparams(11) = New SqlParameter("@Blog_MemberName", _MemberName)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal _MemberName As String, ByVal _BTitle As String, ByVal _BShrtDesc As String, ByVal _BLongDesc As String, ByVal _BSeoDesc As String,
                                  ByVal _CategoryID As Integer, ByVal _BImage As String,
                                  ByVal _BSeoKeyword As String, ByVal _BTag As String, ByVal _BSeoUrl As String, ByVal _ModifiedID As Integer, ByVal _ID As Integer) As Integer
        Dim sqlparams(12) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Blog_BlogTitle", _BTitle)
            sqlparams(2) = New SqlParameter("@Blog_BlogDesc", _BShrtDesc)
            sqlparams(3) = New SqlParameter("@Blog_BlogPost", _BLongDesc)
            sqlparams(4) = New SqlParameter("@Blog_CategoryId", _CategoryID)
            sqlparams(5) = New SqlParameter("@Blog_BlogImage", _BImage)
            sqlparams(6) = New SqlParameter("@Blog_Tag", _BTag)
            sqlparams(7) = New SqlParameter("@Blog_SeoDescription", _BSeoDesc)
            sqlparams(8) = New SqlParameter("@Blog_SeoKeyword", _BSeoKeyword)
            sqlparams(9) = New SqlParameter("@Blog_SeoUrl", _BSeoUrl)
            sqlparams(10) = New SqlParameter("@Blog_MemberName", _MemberName)
            sqlparams(11) = New SqlParameter("@Blog_ModifiedID", _ModifiedID)
            sqlparams(12) = New SqlParameter("@Blog_ID", _ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillWebsiteBlog() As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "MainBlogView")
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillRecentBlog() As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "RecentBlog")
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function BlogDetail(ByVal _SeoUrl As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "BlogDetailBySeoUrl")
            sqlparams(1) = New SqlParameter("@Blog_SeoUrl", _SeoUrl)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateBlogView(ByVal _SeoUrl As String) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateBlogView")
            sqlparams(1) = New SqlParameter("@Blog_SeoUrl", _SeoUrl)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
