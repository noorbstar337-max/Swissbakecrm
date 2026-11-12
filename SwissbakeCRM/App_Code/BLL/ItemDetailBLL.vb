Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class ItemDetailBLL
    Private Shared _spname As String = "_sptblItemDetail"

    Public Shared Function FillItemDT(ByVal Type As String, ByVal TypeID As Integer, ByVal accId As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FillItemDT")
            sqlparams(1) = New SqlParameter("@ItemDt_Type", Type)
            sqlparams(2) = New SqlParameter("@ItemDt_TypeId", TypeID)
            sqlparams(3) = New SqlParameter("@Acc_Id", accId) 'account id
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillItemOnedit(ByVal Type As String, ByVal TypeID As Integer, ByVal accId As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FillItemOnedit")
            sqlparams(1) = New SqlParameter("@ItemDt_Type", Type)
            sqlparams(2) = New SqlParameter("@ItemDt_TypeId", TypeID)
            sqlparams(3) = New SqlParameter("@Acc_Id", accId) 'account id
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function Update(ByVal Qty As Integer, ByVal Amount As Double, ByVal ID As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@ItemDt_Qty", Qty)
            sqlparams(2) = New SqlParameter("@ItemDt_Amount", Amount)
            sqlparams(3) = New SqlParameter("@ItemDt_ID", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Delete(ByVal ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Delete")
            sqlparams(1) = New SqlParameter("@ItemDt_ID", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Public Shared Function ViewItemDetail(ByVal Type As String, ByVal TypeID As Integer, ByVal ID As Integer) As DataSet
    '    Dim sqlparams(3) As SqlParameter
    '    Try
    '        sqlparams(0) = New SqlParameter("@Mode", "ViewItemDetail")
    '        sqlparams(1) = New SqlParameter("@ItemDt_Type", Type)
    '        sqlparams(2) = New SqlParameter("@ItemDt_TypeId", TypeID)
    '        sqlparams(3) = New SqlParameter("@ItemDt_ID", ID)
    '        Return DBBridge.ExecuteDataset(_spname, sqlparams)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function
    Public Shared Function ViewItemDetail(ByVal _Discount_CustId As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ViewItemDetail")

            sqlparams(1) = New SqlParameter("@Discount_CustId", _Discount_CustId)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

	Public Shared Function SearchItemDetail(ByVal Type As String, ByVal TypeID As Integer, ByVal ID As Integer, ByVal SearchValue As String) As DataSet
		Dim sqlparams(4) As SqlParameter
		Try
			sqlparams(0) = New SqlParameter("@Mode", "SearchItemDetail")
			sqlparams(1) = New SqlParameter("@ItemDt_Type", Type)
			sqlparams(2) = New SqlParameter("@ItemDt_TypeId", TypeID)
			sqlparams(3) = New SqlParameter("@ItemDt_ID", ID)
			sqlparams(4) = New SqlParameter("@SearchValue", SearchValue)
			Return DBBridge.ExecuteDataset(_spname, sqlparams)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Shared Function Searchquationproduct(ByVal TypeID As Integer, ByVal SearchValue As String) As DataSet
		Dim sqlparams(4) As SqlParameter
		Try
			sqlparams(0) = New SqlParameter("@Mode", "SearchItemDetail")
			sqlparams(2) = New SqlParameter("@Discount_CustId", TypeID)
			sqlparams(4) = New SqlParameter("@SearchValue", SearchValue)
			Return DBBridge.ExecuteDataset(_spname, sqlparams)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Shared Function UpdateTotalAmountOpp(ByVal Type As String, ByVal TypeID As Integer, ByVal Amount As Double) As DataSet
		Dim sqlparams(3) As SqlParameter
		Try
			sqlparams(0) = New SqlParameter("@Mode", "UpdateTotalAmountOpp")
			sqlparams(1) = New SqlParameter("@ItemDt_Type", Type)
			sqlparams(2) = New SqlParameter("@ItemDt_TypeId", TypeID)
			sqlparams(3) = New SqlParameter("@ItemDt_Amount", Amount)
			Return DBBridge.ExecuteDataset(_spname, sqlparams)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Shared Function TotalAmount(ByVal Type As String, ByVal TypeID As Integer) As Double
		Dim sqlparams(2) As SqlParameter
		Try
			sqlparams(0) = New SqlParameter("@Mode", "TotalAmount")
			sqlparams(1) = New SqlParameter("@ItemDt_TypeId", TypeID)
			sqlparams(2) = New SqlParameter("@ItemDt_Type", Type)
			Return DBBridge.ExecuteScalar(_spname, sqlparams)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Shared Function GetFright(ByVal Type As String, ByVal TypeID As Integer) As Long
		Dim sqlparams(3) As SqlParameter
		Try
			sqlparams(0) = New SqlParameter("@Mode", "GetFright")
			sqlparams(1) = New SqlParameter("@ItemDt_Type", Type)
			sqlparams(2) = New SqlParameter("@ItemDt_TypeId", TypeID)
			Return DBBridge.ExecuteScalar(_spname, sqlparams)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	'gayatri added this function to fetch product wise latest discount for revision button on 24-08-2017
	Public Shared Function DiscountItemDetail(ByVal Mode As String, ByVal TypeID As Integer, ByVal ID As Integer, ByVal Acc_ID As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ItemDt_TypeId", TypeID)
            sqlparams(2) = New SqlParameter("@ItemDt_ID", ID)
            sqlparams(3) = New SqlParameter("@Acc_Id", Acc_ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function CheckStatus(ByVal Mode As String, ByVal TypeID As Integer, ByVal Acc_ID As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ItemDt_TypeId", TypeID)
            sqlparams(2) = New SqlParameter("@Acc_Id", Acc_ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getItemByQId(ByVal QId As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "getItemByQId")
            sqlparams(1) = New SqlParameter("@ItemDt_TypeId", QId)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function getQuotationDetailsById(ByVal QId As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "getQuotationDetailsById")
            sqlparams(1) = New SqlParameter("@Quotation_Id", QId)
            Return DBBridge.ExecuteDataset("_spQuotation", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
