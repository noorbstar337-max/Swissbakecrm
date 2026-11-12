Imports APPCODE.DAL
Imports Microsoft.VisualBasic

Public Class PurchaseOrderBLL

    Private Shared _spname As String = "_spPurchaseOrder"
    Public Shared Function InsertPurchaseOrder(ByVal PurchaseOrder_QRespID As Integer, ByVal PurchaseOrder_Code As String, ByVal PurchaseOrder_VendorID As Integer, ByVal PurchaseOrder_Amt As Double, ByVal PurchaseOrder_Tax As Double,
                                               ByVal PurchaseOrder_Freight As Double, ByVal PurchaseOrder_CreateID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(20) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertPurchaseOrder")
            sqlparams(1) = New SqlParameter("@PurchaseOrder_QRespID", PurchaseOrder_QRespID)
            sqlparams(2) = New SqlParameter("@PurchaseOrder_Code", PurchaseOrder_Code)
            sqlparams(3) = New SqlParameter("@PurchaseOrder_VendorID", PurchaseOrder_VendorID)
            sqlparams(5) = New SqlParameter("@PurchaseOrder_Amt", PurchaseOrder_Amt)
            sqlparams(6) = New SqlParameter("@PurchaseOrder_Tax", PurchaseOrder_Tax)
            sqlparams(7) = New SqlParameter("@PurchaseOrder_Freight", PurchaseOrder_Freight)
            sqlparams(8) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(9) = New SqlParameter("@PurchaseOrder_CreateID", PurchaseOrder_CreateID)


            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertPORawMaterial(ByVal PORawMaterial_RawID As Integer, ByVal PORawMaterial_POID As Integer, ByVal PORawMaterial_Qty As Integer, ByVal PORawMaterial_Unit As String, ByVal PORawMaterial_CreateID As Integer,
                                                ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(20) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertPORawMaterial")
            sqlparams(1) = New SqlParameter("@PORawMaterial_RawID", PORawMaterial_RawID)
            sqlparams(2) = New SqlParameter("@PORawMaterial_POID", PORawMaterial_POID)
            sqlparams(3) = New SqlParameter("@PORawMaterial_Qty", PORawMaterial_Qty)
            sqlparams(5) = New SqlParameter("@PORawMaterial_Unit", PORawMaterial_Unit)
            sqlparams(6) = New SqlParameter("@PORawMaterial_CreateID", PORawMaterial_CreateID)
            sqlparams(8) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)


            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function CheckExistsPurchaseOrder(ByVal PurchaseOrder_QRespID As Integer, ByVal Qrno As Integer, ByVal PurchaseOrder_VendorID As Integer) As String
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "PurchaseorderCheck")
            sqlparams(1) = New SqlParameter("@ID", PurchaseOrder_QRespID)
            sqlparams(2) = New SqlParameter("@Value", Qrno)
            sqlparams(3) = New SqlParameter("@VId", PurchaseOrder_VendorID)



            Return DBBridge.ExecuteScalar("_spCheckExist", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '--faisal added 19-04-18 directpo.aspx
    Public Shared Function InsertdirectQuotation(ByVal QR_Date As String, ByVal vendorid As Integer, ByVal QR_Code As String, ByVal QR_AdditionalInfo As String, ByVal QR_Godown_ID As String, ByVal QR_createID As Integer, ByVal QR_CompanyID As Integer, ByVal QREHistory_Amt As Double,
                                              ByVal QREHistory_Tax As Double, ByVal QREHistory_Freight As Double,
                                              ByVal QREHistory_PaymentTerms As String, ByVal QREHistory_DeliveryTerms As String, ByVal QREHistory_QtnExport As Boolean, ByVal QuotationResponse_CurrencyType As String, ByVal QuotationResponse_CurrencyRate As Double,
                                              ByVal QREHistory_QuotationTerms As String, ByVal QREHistory_QuotationPlace As String, ByVal QREHistory_Doc_Cre As String) As String
        Dim sqlparams(19) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertDirectQtnReq")
            sqlparams(1) = New SqlParameter("@QuotationRequest_Date", QR_Date)
            'sqlparams(2) = New SqlParameter("@QuotationRequest_No", QR_Code)
            sqlparams(3) = New SqlParameter("@QuotationRequest_AdditionalInfo", QR_AdditionalInfo)
            sqlparams(4) = New SqlParameter("@QuotationRequest_Godown_ID", QR_Godown_ID)
            sqlparams(5) = New SqlParameter("@CreateID", QR_createID)
            sqlparams(6) = New SqlParameter("@QuotationRequest_CompanyID", QR_CompanyID)
            sqlparams(7) = New SqlParameter("@PurchaseOrder_Amt", QREHistory_Amt)
            sqlparams(8) = New SqlParameter("@PurchaseOrder_Tax", QREHistory_Tax)
            sqlparams(9) = New SqlParameter("@PurchaseOrder_Freight", QREHistory_Freight)
            sqlparams(10) = New SqlParameter("@QREHistory_PaymentTerms", QREHistory_PaymentTerms)
            sqlparams(11) = New SqlParameter("@QREHistory_DeliveryTerms", QREHistory_DeliveryTerms)
            sqlparams(12) = New SqlParameter("@QRVendor_VendorID", vendorid)
            sqlparams(13) = New SqlParameter("@QREHistory_QtnExport", QREHistory_QtnExport)
            sqlparams(14) = New SqlParameter("@QuotationResponse_CurrencyType", QuotationResponse_CurrencyType)
            sqlparams(15) = New SqlParameter("@QuotationResponse_CurrencyRate", QuotationResponse_CurrencyRate)
            sqlparams(16) = New SqlParameter("@QREHistory_QuotationTerms", QREHistory_QuotationTerms)
            sqlparams(17) = New SqlParameter("@QREHistory_QuotationPlace", QREHistory_QuotationPlace)
            sqlparams(18) = New SqlParameter("@QREHistory_Doc_Cre", QREHistory_Doc_Cre)

            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertDirectRespRawMaterial(ByVal Raw_ID As Integer, ByVal _quantity As String, ByVal _unit As String, ByVal _CreateID As Integer,
                                               _QuotationHistoryID As Integer, ByVal QResponse_HSCode As String, ByVal QResponse_PackSize As String, ByVal QRERawMaterial_Rate As Double, ByVal QRERawMaterial_Tax As Double) As Integer
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertQRespRaw")
            sqlparams(1) = New SqlParameter("PORawMaterial_RawID", Raw_ID)
            sqlparams(2) = New SqlParameter("PORawMaterial_Qty", _quantity)
            sqlparams(3) = New SqlParameter("@PORawMaterial_Unit", _unit)
            sqlparams(4) = New SqlParameter("@CreateID", _CreateID)
            sqlparams(5) = New SqlParameter("@QREHistory_ID", _QuotationHistoryID)
            sqlparams(6) = New SqlParameter("@QResponse_HSCode", QResponse_HSCode)
            sqlparams(7) = New SqlParameter("@QResponse_PackSize", QResponse_PackSize)
            sqlparams(8) = New SqlParameter("@Qraw_Rate", QRERawMaterial_Rate)
            sqlparams(9) = New SqlParameter("@Qraw_tax", QRERawMaterial_Tax)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '-------Added by MUBYN used in QuotationResponse.aspx 11-04-2018
    Public Shared Function UpdatePORawMaterial(ByVal PORawMaterial_RawID As Integer, ByVal PORawMaterial_POID As Integer,
                                               ByVal PORawMaterial_Rate As Double, ByVal PORawMaterial_Tax As Double, ByVal PORawMaterial_Amount As Double) As Integer
        Dim sqlparams(8) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdatePORawMaterial")
            sqlparams(1) = New SqlParameter("@PORawMaterial_RawID", PORawMaterial_RawID)
            sqlparams(2) = New SqlParameter("@PORawMaterial_POID", PORawMaterial_POID)
            sqlparams(3) = New SqlParameter("@PORawMaterial_Rate", PORawMaterial_Rate)
            sqlparams(4) = New SqlParameter("@PORawMaterial_Tax", PORawMaterial_Tax)
            sqlparams(5) = New SqlParameter("@PORawMaterial_Amount", PORawMaterial_Amount)

            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class


