Imports APPCODE.DAL

Public Class DiscountBLL
    Private Shared _spname As String = "_spDiscount"

    Public Shared Function Update(ByVal XMLStock As String) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@XMLStock", XMLStock)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function Delete(ByVal Discount_CustId As Integer) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Delete")
            sqlparams(1) = New SqlParameter("@Discount_CustId", Discount_CustId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function DeleteSingle(ByVal Discount_CustId As Integer, ByVal Discount_ProductId As Integer) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "DeleteSingle")
            sqlparams(1) = New SqlParameter("@Discount_CustId", Discount_CustId)
            sqlparams(2) = New SqlParameter("@Discount_ProductId", Discount_ProductId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function MaxDiscountID() As Integer
        Dim sqlparams(0) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "MaxDiscountID")
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'modify account to add distributor discount
    Public Shared Function FillGridView(ByVal Mode As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            'sqlparams(1) = New SqlParameter("@Id", Id)
            Return DBBridge.ExecuteDataset("_spDistributorDiscount", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
