Imports APPCODE.DAL

Public Class ProductBLL
    Private Shared _spname As String = "_spProduct"

    Public Shared Function Insert(ByVal Product_Name As String, ByVal Product_CategoryId As Integer, ByVal _ReferenceNo As String, ByVal _BarCode As String, ByVal UOMID As Integer,
                                 ByVal Price As Double, ByVal TariffHeading As String, ByVal Product_MinOrder As String, ByVal CurrencyId As Integer, ByVal Description As String,
                                 ByVal Product_OpenningStock As String, ByVal Product_CreatedID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(13) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Product_Name", Product_Name)
            sqlparams(2) = New SqlParameter("@Product_CategoryId", Product_CategoryId)
            sqlparams(3) = New SqlParameter("@Product_ReferenceNo", _ReferenceNo)
            sqlparams(4) = New SqlParameter("@Product_BarCode", _BarCode)
            sqlparams(5) = New SqlParameter("@Product_UOMID", UOMID)
            sqlparams(6) = New SqlParameter("@Product_Price", Price)
            sqlparams(7) = New SqlParameter("@Product_TariffHeading", TariffHeading)
            sqlparams(8) = New SqlParameter("@Product_MinOrder", Product_MinOrder)
            sqlparams(9) = New SqlParameter("@Product_CurrencyId", CurrencyId)
            sqlparams(10) = New SqlParameter("@Product_Description", Description)
            sqlparams(11) = New SqlParameter("@Product_CreatedID", Product_CreatedID)
            sqlparams(12) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(13) = New SqlParameter("@Product_OpenningStock", Product_OpenningStock)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
	'===========================gayatri 09-08-2017 for product list by packing==================================='
	Public Shared Function FillGrid(ByVal PageIndex As Integer, ByVal PageSize As Integer, ByVal Mode As String, ByVal type As String) As DataSet
		Dim sqlparams(3) As SqlParameter
		Try
			sqlparams(0) = New SqlParameter("@Mode", Mode)
			sqlparams(1) = New SqlParameter("@PageIndex", PageIndex)
			sqlparams(2) = New SqlParameter("@PageSize", PageSize)
			sqlparams(3) = New SqlParameter("@type", type)
			Return DBBridge.ExecuteDataset("_spFillUserByPaging", sqlparams)
		Catch ex As Exception
			Throw ex
			'altaf add productlist.aspx 
		End Try
	End Function
	'==============================================================================================================='


	Public Shared Function MainProductViewAll(ByVal _Discount_CustId As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "MainProductViewAll")

            sqlparams(1) = New SqlParameter("@Discount_CustId", _Discount_CustId)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Public Shared Function CRMProductViewAll(ByVal _Discount_CustId As Integer) As DataSet
    '    Dim sqlparams(3) As SqlParameter
    '    Try
    '        sqlparams(0) = New SqlParameter("@Mode", "CRMProductViewAll")

    '        sqlparams(1) = New SqlParameter("@Discount_CustId", _Discount_CustId)
    '        Return DBBridge.ExecuteDataset(_spname, sqlparams)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function
    '==========================GAYATRI created this method on 09-08-2017 for updating product cost and rate =================
    Public Shared Function Update(ByVal Product_Rate As Double, ByVal Product_Cost As Double, ByVal Product_ModifiedID As Integer, ByVal Product_Id As Integer, ByVal AudtTrail_LogId As Integer, ByVal Margin As Double) As Integer
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(1) = New SqlParameter("@Product_Rate", Product_Rate)
            sqlparams(2) = New SqlParameter("@Product_Cost", Product_Cost)
            sqlparams(3) = New SqlParameter("@Product_ModifiedID", Product_ModifiedID)
            sqlparams(4) = New SqlParameter("@Product_Id", Product_Id)
            sqlparams(5) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(6) = New SqlParameter("@Product_Margin", Margin)
            sqlparams(7) = New SqlParameter("@Mode", "UpdateProductCost")
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function Update(ByVal Product_Name As String, ByVal Product_CategoryId As Integer, ByVal _ReferenceNo As String, ByVal _BarCode As String, ByVal UOMID As Integer,
                                 ByVal Price As Double, ByVal TariffHeading As String, ByVal Product_MinOrder As String, ByVal CurrencyId As Integer, ByVal Description As String,
                                  ByVal Product_ModifiedID As Integer, ByVal Product_Id As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(14) As SqlParameter
        Try
            sqlparams(1) = New SqlParameter("@Product_Name", Product_Name)
            sqlparams(2) = New SqlParameter("@Product_CategoryId", Product_CategoryId)
            sqlparams(3) = New SqlParameter("@Product_ReferenceNo", _ReferenceNo)
            sqlparams(4) = New SqlParameter("@Product_BarCode", _BarCode)
            sqlparams(5) = New SqlParameter("@Product_UOMID", UOMID)
            sqlparams(6) = New SqlParameter("@Product_Price", Price)
            sqlparams(7) = New SqlParameter("@Product_TariffHeading", TariffHeading)
            sqlparams(8) = New SqlParameter("@Product_MinOrder", Product_MinOrder)
            sqlparams(9) = New SqlParameter("@Product_CurrencyId", CurrencyId)
            sqlparams(10) = New SqlParameter("@Product_Description", Description)
            sqlparams(11) = New SqlParameter("@Product_ModifiedID", Product_ModifiedID)
            sqlparams(12) = New SqlParameter("@Product_Id", Product_Id)
            sqlparams(13) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(14) = New SqlParameter("@Mode", "Update")
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function CRMProductViewAll(ByVal _DiscountID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "CRMProductViewAll")
            sqlparams(1) = New SqlParameter("@Discount_CustId", _DiscountID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function TargetCategoryProductADD(ByVal TCP_TCID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "TargetCategoryProductADD")
            sqlparams(1) = New SqlParameter("@TCP_TCID", TCP_TCID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function CRMProductViewRec(ByVal _DiscountID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "CRMProductViewRec")
            sqlparams(1) = New SqlParameter("@Discount_CustId", _DiscountID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function SearchCRMProduct(ByVal _DiscountID As Integer, ByVal Value As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "SearchCRMProduct")
            sqlparams(1) = New SqlParameter("@Discount_CustId", _DiscountID)
            sqlparams(2) = New SqlParameter("@Product_Name", Value)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function TargetCategoryProductView(ByVal TCP_TCID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "TargetCategoryProductView")
            sqlparams(1) = New SqlParameter("@TCP_TCID", TCP_TCID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '===========================gayatri 22-08-2017 for quotation page revision button==================================='
    Public Shared Function getDiscountPrice(ByVal product_Id As Integer, ByVal Discount_CustId As Integer, ByVal ItemDt_TypeId As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "GetDiscountPrice")
            sqlparams(1) = New SqlParameter("@Product_Id", product_Id)
            sqlparams(2) = New SqlParameter("@Discount_CustId", Discount_CustId)
            sqlparams(3) = New SqlParameter("@ItemDt_TypeId", ItemDt_TypeId)
            Return DBBridge.ExecuteDataset("_spProduct", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '==============================================================================================================='

    Public Shared Function ViewPricelist(ByVal _Discount_CustId As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ViewPricelist")

            sqlparams(1) = New SqlParameter("@Discount_CustId", _Discount_CustId)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
