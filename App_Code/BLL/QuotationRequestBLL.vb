Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class QuotationRequestBLL
    Private Shared _spname As String = "_spQuotationRequest"

    Public Shared Function InsertQuotation(ByVal QR_Date As String, ByVal QR_Code As String, ByVal QR_AdditionalInfo As String, ByVal QR_Godown_ID As String, ByVal QR_createID As Integer, ByVal QR_CompanyID As Integer) As Integer
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertQuotation")
            sqlparams(1) = New SqlParameter("@QuotationRequest_Date", QR_Date)
            sqlparams(2) = New SqlParameter("@QuotationRequest_No", QR_Code)
            sqlparams(3) = New SqlParameter("@QuotationRequest_AdditionalInfo", QR_AdditionalInfo)
            sqlparams(4) = New SqlParameter("@QuotationRequest_Godown_ID", QR_Godown_ID)
            sqlparams(5) = New SqlParameter("@QuotationRequest_CreateID", QR_createID)
            sqlparams(6) = New SqlParameter("@QuotationRequest_CompanyID", QR_CompanyID)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertRawMaterial(ByVal Raw_ID As Integer, ByVal _quantity As String, ByVal _unite As String, ByVal _CreateID As Integer, _QuotationID As Integer) As Integer
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertRawMaterial")
            sqlparams(1) = New SqlParameter("@QRRawMaterial_RawID", Raw_ID)
            sqlparams(2) = New SqlParameter("@QRRawMaterial_Quantity", _quantity)
            If Not String.IsNullOrEmpty(_quantity) Then
                sqlparams(2) = New SqlParameter("@QRRawMaterial_Quantity", _quantity)
            Else
                sqlparams(2) = New SqlParameter("@QRRawMaterial_Quantity", DBNull.Value)
            End If
            sqlparams(3) = New SqlParameter("@QRRawMaterial_Unit", _unite)
            sqlparams(4) = New SqlParameter("@QRRawMaterial_CreateID", _CreateID)
            sqlparams(5) = New SqlParameter("@QRRawMaterial_QRDID", _QuotationID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertVendor(ByVal QRVendor_QRDID As Integer, ByVal QRVendor_VendorID As Integer, ByVal QRVendor_CreateID As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertVendor")
            sqlparams(1) = New SqlParameter("@QRVendor_QRDID", QRVendor_QRDID)
            sqlparams(2) = New SqlParameter("@QRVendor_VendorID", QRVendor_VendorID)
            sqlparams(3) = New SqlParameter("@QRVendor_CreateID", QRVendor_CreateID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateQuotation(ByVal QR_Date As String, ByVal QR_Code As String, ByVal QR_AdditionalInfo As String, ByVal QR_Godown_ID As String,
                                           ByVal _ModifiedID As Integer, ByVal Quotation_ID As Integer, ByVal QR_CompanyID As Integer) As Integer
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateQuotation")
            sqlparams(1) = New SqlParameter("@QuotationRequest_Date", QR_Date)
            sqlparams(2) = New SqlParameter("@QuotationRequest_No", QR_Code)
            sqlparams(3) = New SqlParameter("@QuotationRequest_AdditionalInfo", QR_AdditionalInfo)
            sqlparams(4) = New SqlParameter("@QuotationRequest_Godown_ID", QR_Godown_ID)
            sqlparams(5) = New SqlParameter("@QuotationRequest_ModifiedID", _ModifiedID)
            sqlparams(6) = New SqlParameter("@QuotationRequest_ID", Quotation_ID)
            sqlparams(7) = New SqlParameter("@QuotationRequest_CompanyID", QR_CompanyID)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function UpdateRawMaterial(ByVal _Material As Integer, ByVal _Quantity As String, ByVal _Unite As String, ByVal _ModifiedID As Integer, QR_Id As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateRawMaterial")
            sqlparams(1) = New SqlParameter("@QRRawMaterial_RawID", _Material)
            'sqlparams(2) = New SqlParameter("@QRRawMaterial_Quantity", _Quantity)
            If Not String.IsNullOrEmpty(_Quantity) Then
                sqlparams(2) = New SqlParameter("@QRRawMaterial_Quantity", _Quantity)
            Else
                sqlparams(2) = New SqlParameter("@QRRawMaterial_Quantity", DBNull.Value)
            End If
            sqlparams(3) = New SqlParameter("@QRRawMaterial_Unit", _Unite)
            sqlparams(4) = New SqlParameter("@QRRawMaterial_ModifiedID", _ModifiedID)
            sqlparams(5) = New SqlParameter("@QRRawMaterial_QRDID", QR_Id)

            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function UpdateVendor(ByVal QRVendor_VendorID As Integer, ByVal QRVendor_ModifiedID As Integer, ByVal QRVendor_ID As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(1) = New SqlParameter("@QRVendor_VendorID", QRVendor_VendorID)
            sqlparams(2) = New SqlParameter("@QRVendor_ModifiedID", QRVendor_ModifiedID)
            sqlparams(3) = New SqlParameter("@QRVendor_ID", QRVendor_ID)
            sqlparams(4) = New SqlParameter("@Mode", "UpdateVendor")
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function QuotationVendorDeleteSi(ByVal QRVendor_QRDID As Integer) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "QuotationVendorDeleteSi")
            sqlparams(1) = New SqlParameter("@QRVendor_QRDID ", QRVendor_QRDID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function FillGridView(ByVal Mode As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillGridViewByID(ByVal Mode As String, ByVal ID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function VendorViewByQuotation(ByVal QRVendor_QRDID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "VendorViewByQuotation")
            sqlparams(1) = New SqlParameter("@QRVendor_QRDID", QRVendor_QRDID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '============================gayatri for search quotation request=======================================    
    Public Shared Function SearchVendorByQuotation(ByVal _DiscountID As Integer, ByVal Value As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "SearchVendorByQuotation")
            sqlparams(2) = New SqlParameter("@value", Value)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '==================================================================================
    Public Shared Function VendorByQuotationADD(ByVal TCP_TCID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "VendorByQuotationADD")
            'sqlparams(1) = New SqlParameter("@QRVendor_QRDID", TCP_TCID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function UpdateQtnemail(ByVal QRVendor_ID As Integer, ByVal QR_Vendor_ID As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@ID", QRVendor_ID)

            sqlparams(1) = New SqlParameter("@Mode", "updateQtnEmailstatus")
            sqlparams(2) = New SqlParameter("@QR_Vendor_ID", QR_Vendor_ID)

            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
   

End Class
