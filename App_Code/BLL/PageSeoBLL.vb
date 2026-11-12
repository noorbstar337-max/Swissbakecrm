Imports Microsoft.VisualBasic
Imports APPCODE.DAL
Public Class PageSeoBLL
    Private Shared _spname As String = "_spPageSeo"

    Public Shared Function Insert(ByVal _BatchID As Integer, ByVal _PageName As String, ByVal _PageDesc As String, ByVal _PageSeoTitle As String, ByVal _PageSeoKeyword As String,
                                  ByVal _PageSeoDesc As String, ByVal _PageSeoUrl As String, ByVal _FromType As String, ByVal _FromID As Integer,
                                  ByVal _ToType As String, ByVal _ToID As Integer, ByVal _CreatedID As Integer) As Integer
        Dim sqlparams(12) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@PSeo_BatchID", _BatchID)
            sqlparams(2) = New SqlParameter("@PSeo_PageName", _PageName)
            sqlparams(3) = New SqlParameter("@PSeo_Description", _PageDesc)
            sqlparams(4) = New SqlParameter("@PSeo_SeoTitle", _PageSeoTitle)
            sqlparams(5) = New SqlParameter("@PSeo_SeoKeyword", _PageSeoKeyword)
            sqlparams(6) = New SqlParameter("@PSeo_SeoDescription", _PageSeoDesc)
            sqlparams(7) = New SqlParameter("@PSeo_SeoUrl", _PageSeoUrl)
            sqlparams(8) = New SqlParameter("@PSeo_FromType", _FromType)
            sqlparams(9) = New SqlParameter("@PSeo_FromID", _FromID)
            sqlparams(10) = New SqlParameter("@PSeo_ToType", _ToType)
            sqlparams(11) = New SqlParameter("@PSeo_ToID", _ToID)
            sqlparams(12) = New SqlParameter("@PSeo_CreatedID", _CreatedID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertBatch(ByVal _BatchName As String) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertBatch")
            sqlparams(1) = New SqlParameter("@Batch_Name", _BatchName)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function SortingGridView(ByVal BatchID As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "PageSeoSorting")
            sqlparams(1) = New SqlParameter("@PSeo_BatchID", BatchID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function BatchGridView() As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "BatchGridview")
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function FillGridView(ByVal PageIndex As Integer, ByVal PageSize As Integer, ByVal BatchID As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "PageSeoGridview")
            sqlparams(1) = New SqlParameter("@PageIndex", PageIndex)
            sqlparams(2) = New SqlParameter("@PageSize", PageSize)
            sqlparams(3) = New SqlParameter("@PSeo_BatchID", BatchID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function TotalRowInGridview(ByVal BatchID As Integer) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "PageSeoTotalNumberOfRecord")
            sqlparams(1) = New SqlParameter("@PSeo_BatchID", BatchID)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateBatch(ByVal BatchID As Integer) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateBacth")
            sqlparams(1) = New SqlParameter("@PSeo_BatchID", BatchID)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FirstIdbatch() As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "BatchTop")
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function SearchGridView(ByVal PSeo_BatchID As Integer, ByVal SearchValue As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "PageSeoSearch")
            sqlparams(1) = New SqlParameter("@PSeo_BatchID", PSeo_BatchID)
            sqlparams(2) = New SqlParameter("@SearchValue", SearchValue)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ViewBySeoUrl(ByVal SeoUrl As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ViewBySeoUrl")
            sqlparams(1) = New SqlParameter("@PSeo_SeoUrl", SeoUrl)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DeleteBatch(ByVal BatchID As String) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "DeleteBatch")
            sqlparams(1) = New SqlParameter("@Batch_ID", BatchID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
