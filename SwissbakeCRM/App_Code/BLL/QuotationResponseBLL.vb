Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class QuotationResponseBLL
    Private Shared _spname As String = "_spQuotationResponse"
    '==================================altaf remove Gayatri Added 2 columns in InsertQResponse QR_HSCode,QR_PackSize===========================================================
    Public Shared Function InsertQResponse(ByVal QR_Date As String, ByVal QR_Code As String, ByVal QR_AdditionalInfo As String,
                                           ByVal QR_Request_ID As String, ByVal QR_createID As Integer) As Integer
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertQResponse")
            sqlparams(1) = New SqlParameter("@CreateDate", QR_Date)
            sqlparams(2) = New SqlParameter("@QResponse_Code", QR_Code)
            sqlparams(3) = New SqlParameter("@QResponse_Remarks", QR_AdditionalInfo)
            sqlparams(4) = New SqlParameter("@QResponse_QRDID", QR_Request_ID)
            sqlparams(5) = New SqlParameter("@CreateID", QR_createID)

            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '==============================gayatri added column QREHistory_DeliveryTerms============================================================
    Public Shared Function InsertQRespHistory(ByVal QResponse_Id As Integer, ByVal QREHistory_VendorID As Integer, ByVal QREHistory_Amt As Double,
                                              ByVal QREHistory_Tax As Double, ByVal QREHistory_Freight As Double,
                                              ByVal QREHistory_PaymentTerms As String, ByVal QREHistory_DeliveryTerms As String,
                                              ByVal QRVendor_CreateID As Integer) As Integer
        Dim sqlparams(8) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertQRespHistory")
            sqlparams(1) = New SqlParameter("@QResponse_Id", QResponse_Id)
            sqlparams(2) = New SqlParameter("@QREHistory_VendorID", QREHistory_VendorID)
            sqlparams(3) = New SqlParameter("@QREHistory_Amt", QREHistory_Amt)
            sqlparams(4) = New SqlParameter("@QREHistory_Tax", QREHistory_Tax)
            sqlparams(5) = New SqlParameter("@QREHistory_Freight", QREHistory_Freight)
            sqlparams(6) = New SqlParameter("@QREHistory_PaymentTerms", QREHistory_PaymentTerms)
            sqlparams(7) = New SqlParameter("@QREHistory_DeliveryTerms", QREHistory_DeliveryTerms)
            sqlparams(8) = New SqlParameter("@CreateID", QRVendor_CreateID)

            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function vendorNameByID(ByVal Mode As String, ByVal _ID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Vendor_ID", _ID)
            Return DBBridge.ExecuteDataset("_spQuotationRequest", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function InsertRespRawMaterial(ByVal Raw_ID As Integer, ByVal _quantity As String, ByVal _unit As String, ByVal _CreateID As Integer,
                                                 _QuotationHistoryID As Integer, ByVal QResponse_HSCode As String, ByVal QResponse_PackSize As String) As Integer
        Dim sqlparams(8) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertQRespRaw")
            sqlparams(1) = New SqlParameter("@QRERawMaterial_RawID", Raw_ID)
            sqlparams(2) = New SqlParameter("@QRERawMaterial_Qty", _quantity)
            sqlparams(3) = New SqlParameter("@QRERawMaterial_Unit", _unit)
            sqlparams(4) = New SqlParameter("@CreateID", _CreateID)
            sqlparams(5) = New SqlParameter("@QREHistory_ID", _QuotationHistoryID)
            sqlparams(6) = New SqlParameter("@QResponse_HSCode", QResponse_HSCode)
            sqlparams(7) = New SqlParameter("@QResponse_PackSize", QResponse_PackSize)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function FillrawRespbyID(ByVal Mode As String, ByVal ID As Integer, ByVal vendorid As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@QResponse_QRDID", ID)
            sqlparams(2) = New SqlParameter("@QREHistory_VendorID", vendorid)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function FillQRespDetailbyID(ByVal Mode As String, ByVal ID As Integer, ByVal vendorid As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@QResponse_QRDID", ID)
            sqlparams(2) = New SqlParameter("@QREHistory_VendorID", vendorid)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function FillQRCode(ByVal Mode As String, ByVal ID As Integer) As String
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)

            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '==================================altaf remove Gayatri Added 2 columns in InsertQResponse QR_HSCode,QR_PackSize===========================================================
    Public Shared Function UpdateQuotationResp(ByVal QR_Code As String, ByVal QResponse_Remarks As String, ByVal _ModifiedID As Integer,
                                           ByVal Quotation_ID As Integer, ByVal vendorid As Integer) As Integer
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateQuotationResp")
            sqlparams(1) = New SqlParameter("@QResponse_Code", QR_Code)
            sqlparams(2) = New SqlParameter("@QResponse_Remarks", QResponse_Remarks)
            sqlparams(3) = New SqlParameter("@ModifiedID", _ModifiedID)
            sqlparams(4) = New SqlParameter("@QResponse_QRDID", Quotation_ID)
            sqlparams(5) = New SqlParameter("@QREHistory_VendorID", vendorid)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '=====================================================================================================================================================
    Public Shared Function UpdateQRespRaw(ByVal _Quantity As String, ByVal _Unit As String, ByVal _Modified As Integer,
                                          ByVal Quotation_ID As Integer, ByVal vendorid As Integer, ByVal QResponse_HSCode As String, ByVal QResponse_PackSize As String) As Integer
        Dim sqlparams(8) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateQRespRaw")
            sqlparams(1) = New SqlParameter("@QRERawMaterial_Qty", _Quantity)
            sqlparams(2) = New SqlParameter("@QRERawMaterial_Unit", _Unit)
            sqlparams(3) = New SqlParameter("@CreateID", _Modified)
            sqlparams(4) = New SqlParameter("@QResponse_QRDID", Quotation_ID)
            sqlparams(5) = New SqlParameter("@QREHistory_VendorID", vendorid)
            sqlparams(6) = New SqlParameter("@QResponse_HSCode", QResponse_HSCode)
            sqlparams(7) = New SqlParameter("@QResponse_PackSize", QResponse_PackSize)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertQRHistoryVersion(ByVal QResponse_Id As Integer, ByVal QREHistory_VendorID As Integer, ByVal QREHistory_Amt As Double,
                                                  ByVal QREHistory_Tax As Double, ByVal QREHistory_Freight As Double, ByVal QREHistory_PaymentTerms As String,
                                                  ByVal QRVendor_CreateID As Integer, ByVal QREHistory_DeliveryTerms As String) As Integer
        Dim sqlparams(8) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertQRHistoryVersion")
            sqlparams(1) = New SqlParameter("@QResponse_QRDID", QResponse_Id)
            sqlparams(2) = New SqlParameter("@QREHistory_VendorID", QREHistory_VendorID)
            sqlparams(3) = New SqlParameter("@QREHistory_Amt", QREHistory_Amt)
            sqlparams(4) = New SqlParameter("@QREHistory_Tax", QREHistory_Tax)
            sqlparams(5) = New SqlParameter("@QREHistory_Freight", QREHistory_Freight)
            sqlparams(6) = New SqlParameter("@QREHistory_PaymentTerms", QREHistory_PaymentTerms)
            sqlparams(7) = New SqlParameter("@CreateID", QRVendor_CreateID)
            sqlparams(8) = New SqlParameter("QREHistory_DeliveryTerms", QREHistory_DeliveryTerms)

            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateQuotationStatus(ByVal Mode As String, ByVal QResponse_Id As Integer, ByVal QREHistory_VendorID As Integer, ByVal QRVendor_CreateID As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@QResponse_QRDID", QResponse_Id)
            sqlparams(2) = New SqlParameter("@QREHistory_VendorID", QREHistory_VendorID)

            sqlparams(3) = New SqlParameter("@CreateID", QRVendor_CreateID)

            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function fillQRespbyStatus(ByVal Status As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "fillQRespbyStatus")
            sqlparams(1) = New SqlParameter("@Status", Status)

            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function GetQRCount() As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "GetQRCount")


            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function FillGridview(ByVal mode As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", mode)


            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function updateEmailstatus(ByVal PurchaseOrder_QRespID As Integer, PurchaseOrder_VendorID As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "updateEmailstatus")
            sqlparams(1) = New SqlParameter("@QResponse_Id", PurchaseOrder_QRespID)
            sqlparams(2) = New SqlParameter("@VId", PurchaseOrder_VendorID)
           
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function PoIDQrespUpdate(ByVal ID As Integer, ByVal QResponse_Id As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "PoIDQrespUpdate")
            sqlparams(1) = New SqlParameter("@ID", ID)
            sqlparams(2) = New SqlParameter("@QResponse_Id", QResponse_Id)
         

            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
