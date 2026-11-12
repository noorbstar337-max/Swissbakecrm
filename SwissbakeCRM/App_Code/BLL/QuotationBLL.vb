Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class QuotationBLL
    Private Shared _spname As String = "_spQuotation"
    'gayatri added 2 columns Quotation_Currency,Quotation_CurrencyRate on 18-08-2017 for ModifyQuotation page
    '---- Quotation_PrintIn column added by MUBYN 17-07-2018
    Public Shared Function Insert(ByVal Type As String, ByVal TypeID As Integer, ByVal QuoStatus As String, ByVal Quotation_Date As Date, ByVal Validity As String,
                                  ByVal ModeOFPayment As String, ByVal TermOFDelivery As String, ByVal DispatchThrough As String, ByVal AuthSign As String,
                                  ByVal ExpClosing As Date, ByVal OwnerID As Integer, ByVal PrdAmount As Double, ByVal CreatedID As Integer,
                                  ByVal AudtTrail_LogId As Integer, ByVal Quotation_Freight As Integer,
                                  ByVal Currency As String, ByVal CurrencyRate As Double, ByVal TermsOfPayment As String,
                                  ByVal ModeOfTransport As String, ByVal CountryOfOrigin As String, ByVal CountryOfFinalDestination As String, ByVal PortOfLoading As String,
                                  ByVal PortOfDischarge As String, ByVal FinalDestination As String, ByVal Quotation_TrmsPyt_Card_doc As String,
                                  ByVal Quotation_Doc_Clearance As Double, ByVal Quotation_OceanFreight As Double, ByVal Quotation_Insurance As Double, ByVal Quotation_WithFreight As Integer,
                                  ByVal Quotation_PrintIn As String, ByVal BankId As Integer, ByVal TcsAmount As Double, ByVal ODACharges As Double, ByVal TotalDiscountAmount As Double, ApplyCashDiscount As Boolean, ByVal Quotation_Billedfrom As Integer) As Integer
        Dim sqlparams(36) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Quotation_Type", Type)
            sqlparams(2) = New SqlParameter("@Quotation_TypeID", TypeID)
            sqlparams(3) = New SqlParameter("@Quotation_QuoStatus", QuoStatus)
            sqlparams(4) = New SqlParameter("@Quotation_Date", Quotation_Date)
            sqlparams(5) = New SqlParameter("@Quotation_Validity", Validity)
            sqlparams(6) = New SqlParameter("@Quotation_ModeOFPayment", ModeOFPayment)
            sqlparams(7) = New SqlParameter("@Quotation_TermOFDelivery", TermOFDelivery)
            sqlparams(8) = New SqlParameter("@Quotation_DispatchThrough", DispatchThrough)
            sqlparams(9) = New SqlParameter("@Quotation_AuthSign", AuthSign)
            sqlparams(10) = New SqlParameter("@Quotation_ExpClosing", ExpClosing)
            sqlparams(11) = New SqlParameter("@Quotation_OwnerID", OwnerID)
            sqlparams(12) = New SqlParameter("@Quotation_PrdAmount", PrdAmount)
            sqlparams(13) = New SqlParameter("@Quotation_CreatedID", CreatedID)
            sqlparams(14) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(15) = New SqlParameter("@Quotation_Freight", Quotation_Freight)
            sqlparams(16) = New SqlParameter("@Quotation_Currency", Currency)
            sqlparams(17) = New SqlParameter("@Quotation_CurrencyRate", CurrencyRate)
            sqlparams(18) = New SqlParameter("@Quotation_TermsOfPayment", TermsOfPayment)
            sqlparams(19) = New SqlParameter("@Quotation_ModeOfTransport", ModeOfTransport)
            sqlparams(20) = New SqlParameter("@Quotation_CountryOfOrigin", CountryOfOrigin)
            sqlparams(21) = New SqlParameter("@Quotation_CountryOfFinalDestination", CountryOfFinalDestination)
            sqlparams(22) = New SqlParameter("@Quotation_PortOfLoading", PortOfLoading)
            sqlparams(23) = New SqlParameter("@Quotation_PortOfDischarge", PortOfDischarge)
            sqlparams(24) = New SqlParameter("@Quotation_FinalDestination", FinalDestination)
            sqlparams(25) = New SqlParameter("@Quotation_TrmsPyt_Card_doc", Quotation_TrmsPyt_Card_doc)
            sqlparams(26) = New SqlParameter("@Quotation_Doc_Clearance", Quotation_Doc_Clearance)
            sqlparams(27) = New SqlParameter("@Quotation_OceanFreight", Quotation_OceanFreight)
            sqlparams(28) = New SqlParameter("@Quotation_Insurance", Quotation_Insurance)
            sqlparams(29) = New SqlParameter("@Quotation_WithFreight", Quotation_WithFreight)
            sqlparams(30) = New SqlParameter("@Quotation_PrintIn", Quotation_PrintIn)
            sqlparams(31) = New SqlParameter("@BankId", BankId)
            sqlparams(32) = New SqlParameter("@Tcs_Amount", TcsAmount)
            sqlparams(33) = New SqlParameter("@ODA_Charges", ODACharges)
            sqlparams(34) = New SqlParameter("@Quotation_DiscountAmount", TotalDiscountAmount)
            sqlparams(35) = New SqlParameter("@ApplyCashDiscount", ApplyCashDiscount)
            sqlparams(36) = New SqlParameter("@Quotation_Billedfrom", Quotation_Billedfrom)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'gayatri added 2 columns Quotation_Currency,Quotation_CurrencyRate on 18-08-2017 for ModifyQuotation page
    '---- Quotation_PrintIn column added by MUBYN 17-07-2018
    Public Shared Function Update(ByVal Type As String, ByVal TypeID As Integer, ByVal QuoStatus As String, ByVal Quotation_Date As Date, ByVal Validity As String,
                                 ByVal ModeOFPayment As String, ByVal TermOFDelivery As String, ByVal DispatchThrough As String, ByVal AuthSign As String,
                                 ByVal ExpClosing As Date, ByVal OwnerID As Integer, ByVal PrdAmount As Double, ByVal ModID As Integer,
                                 ByVal AudtTrail_LogId As Integer, ByVal ID As Integer, ByVal Quotation_Freight As Integer,
                                 ByVal Currency As String, ByVal CurrencyRate As Double, ByVal TermsOfPayment As String,
                                 ByVal ModeOfTransport As String, ByVal CountryOfOrigin As String, ByVal CountryOfFinalDestination As String, ByVal PortOfLoading As String,
                                 ByVal PortOfDischarge As String, ByVal FinalDestination As String, ByVal Quotation_TrmsPyt_Card_doc As String,
                                 ByVal Quotation_Doc_Clearance As Double, ByVal Quotation_OceanFreight As Double, ByVal Quotation_Insurance As Double, ByVal Quotation_WithFreight As Integer,
                                 ByVal Quotation_PrintIn As String, ByVal BankId As Integer, ByVal TcsAmount As Double, ByVal ODACharges As Double, ByVal TotalDiscountAmount As Double, ApplyCashDiscount As Boolean, ByVal Quotation_Billedfrom As Integer) As Integer
        Dim sqlparams(36) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Quotation_Type", Type)
            sqlparams(2) = New SqlParameter("@Quotation_TypeID", TypeID)
            sqlparams(3) = New SqlParameter("@Quotation_QuoStatus", QuoStatus)
            sqlparams(4) = New SqlParameter("@Quotation_Date", Quotation_Date)
            sqlparams(5) = New SqlParameter("@Quotation_Validity", Validity)
            sqlparams(6) = New SqlParameter("@Quotation_ModeOFPayment", ModeOFPayment)
            sqlparams(7) = New SqlParameter("@Quotation_TermOFDelivery", TermOFDelivery)
            sqlparams(8) = New SqlParameter("@Quotation_DispatchThrough", DispatchThrough)
            sqlparams(9) = New SqlParameter("@Quotation_AuthSign", AuthSign)
            sqlparams(10) = New SqlParameter("@Quotation_ExpClosing", ExpClosing)
            sqlparams(11) = New SqlParameter("@Quotation_OwnerID", OwnerID)
            sqlparams(12) = New SqlParameter("@Quotation_PrdAmount", PrdAmount)
            sqlparams(13) = New SqlParameter("@Quotation_ModifiedID", ModID)
            sqlparams(14) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(15) = New SqlParameter("@Quotation_Id", ID)
            sqlparams(16) = New SqlParameter("@Quotation_Freight", Quotation_Freight)
            sqlparams(17) = New SqlParameter("@Quotation_Currency", Currency)
            sqlparams(18) = New SqlParameter("@Quotation_CurrencyRate", CurrencyRate)
            sqlparams(19) = New SqlParameter("@Quotation_TermsOfPayment", TermsOfPayment)
            sqlparams(20) = New SqlParameter("@Quotation_ModeOfTransport", ModeOfTransport)
            sqlparams(21) = New SqlParameter("@Quotation_CountryOfOrigin", CountryOfOrigin)
            sqlparams(22) = New SqlParameter("@Quotation_CountryOfFinalDestination", CountryOfFinalDestination)
            sqlparams(23) = New SqlParameter("@Quotation_PortOfLoading", PortOfLoading)
            sqlparams(24) = New SqlParameter("@Quotation_PortOfDischarge", PortOfDischarge)
            sqlparams(25) = New SqlParameter("@Quotation_FinalDestination", FinalDestination)
            sqlparams(26) = New SqlParameter("@Quotation_TrmsPyt_Card_doc", Quotation_TrmsPyt_Card_doc)
            sqlparams(27) = New SqlParameter("@Quotation_Doc_Clearance", Quotation_Doc_Clearance)
            sqlparams(28) = New SqlParameter("@Quotation_OceanFreight", Quotation_OceanFreight)
            sqlparams(29) = New SqlParameter("@Quotation_Insurance", Quotation_Insurance)
            sqlparams(30) = New SqlParameter("@Quotation_WithFreight", Quotation_WithFreight)
            sqlparams(31) = New SqlParameter("@Quotation_PrintIn", Quotation_PrintIn)
            sqlparams(32) = New SqlParameter("@BankId", BankId)
            sqlparams(33) = New SqlParameter("@Tcs_Amount", TcsAmount)
            sqlparams(33) = New SqlParameter("@ODA_Charges", ODACharges)
            sqlparams(34) = New SqlParameter("@Quotation_DiscountAmount", TotalDiscountAmount)
            sqlparams(35) = New SqlParameter("@ApplyCashDiscount", ApplyCashDiscount)
            sqlparams(36) = New SqlParameter("@Quotation_Billedfrom", Quotation_Billedfrom)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function GetTCSODAAmountByQuotationId(QuotationId As Integer) As DataTable
        Dim sqlparams(2) As SqlParameter
        sqlparams(0) = New SqlParameter("@Mode", "GetTCSODAAmountByQuotationId")
        sqlparams(1) = New SqlParameter("@Quotation_Id", QuotationId)

        Try
            Dim ds As DataSet = DBBridge.ExecuteDataset(_spname, sqlparams)
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
                Return ds.Tables(0)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function XMLItemDtInsert(ByVal XMLAssignTo As String) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ItemDtInsert")
            sqlparams(1) = New SqlParameter("@XMLAssignTo", XMLAssignTo)
            'sqlparams(2) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            'sqlparams(3) = New SqlParameter("@Assignto_Type", Type)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function SortingQuotationByAssign(ByVal ID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "SortingQuotationByAssign")
            sqlparams(1) = New SqlParameter("@Quotation_Id", ID)

            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function SortingQuotationByAssignmq(ByVal ID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "SortingQuotationByAssignmq")
            sqlparams(1) = New SqlParameter("@Quotation_Id", ID)

            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function QuotationByType(ByVal ID As Integer, ByVal TypeID As Integer, ByVal Type As String) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "QuotationByType")
            sqlparams(1) = New SqlParameter("@Quotation_Id", ID)
            sqlparams(2) = New SqlParameter("@Quotation_TypeID", TypeID)
            sqlparams(3) = New SqlParameter("@Quotation_Type", Type)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'gayatri added this function from PackOne on 18-08-2017 to check type of quotation account/prospect
    Public Shared Function Checktypebyid(ByVal Quotation_TypeID As Integer) As String
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "checktypebyid")
            sqlparams(1) = New SqlParameter("@Quotation_TypeID", Quotation_TypeID)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'gayatri created this for printQuotation to fetch customer id by quotation id on 18-08-2017
    Public Shared Function GetCustId(ByVal Quotation_Id As Integer) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "GetCustId")
            sqlparams(1) = New SqlParameter("@Quotation_Id", Quotation_Id)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'gayatri created this for Quotation page createOrder button on 21-08-2017
    Public Shared Function FillGridView(ByVal Mode As String, ByVal id As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "GetCustId")
            sqlparams(1) = New SqlParameter("@Quotation_Id", id)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'gayatri created this for Quotation page REVISION button on 21-08-2017
    'Public Shared Function getChildId(ByVal id As Integer) As DataSet
    '    Dim sqlparams(1) As SqlParameter
    '    Try
    '        sqlparams(0) = New SqlParameter("@Mode", "getChildId")
    '        sqlparams(1) = New SqlParameter("@Quotation_Id", id)
    '        Return DBBridge.ExecuteDataset(_spname, sqlparams)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function
    Public Shared Function getQuotation(ByVal id As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "getQuotationById")
            sqlparams(1) = New SqlParameter("@Quotation_Id", id)
            Return DBBridge.ExecuteDataset("_spQuotation", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'gayatri created this for Quotation page REVISION button on 21-08-2017
    Public Shared Function getQuotationById(ByVal id As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "getQuotationById")
            sqlparams(1) = New SqlParameter("@Quotation_Id", id)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'gayatri added this on 23-08-2017 for showing history of quotation
    Public Shared Function FillQDetailbyID(ByVal Mode As String, ByVal ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Quotation_Id", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'gayatri added this on 23-08-2017 for showing history of quotation
    Public Shared Function getChildIdByQId(ByVal Mode As String, ByVal ID As Integer) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Quotation_Id", ID)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertRevision(ByVal Type As String, ByVal TypeID As Integer, ByVal QuoStatus As String, ByVal Quotation_Date As Date, ByVal Validity As String,
                                  ByVal ModeOFPayment As String, ByVal TermOFDelivery As String, ByVal DispatchThrough As String, ByVal AuthSign As String,
                                  ByVal ExpClosing As Date, ByVal OwnerID As Integer, ByVal PrdAmount As Double, ByVal CreatedID As Integer,
                                  ByVal AudtTrail_LogId As Integer, ByVal Quotation_Freight As Integer,
                                  ByVal Currency As String, ByVal CurrencyRate As Double, ByVal isChild As Integer, ByVal TermsOfPayment As String,
                                  ByVal ModeOfTransport As String, ByVal CountryOfOrigin As String, ByVal CountryOfFinalDestination As String, ByVal PortOfLoading As String,
                                  ByVal PortOfDischarge As String, ByVal FinalDestination As String, ByVal Quotation_TrmsPyt_Card_doc As String,
                                  ByVal Quotation_Doc_Clearance As Double, ByVal Quotation_OceanFreight As Double, ByVal Quotation_Insurance As Double, ByVal Quotation_WithFreight As Integer,
                                  ByVal Quotation_PrintIn As String, ByVal BankId As Integer) As Integer
        Dim sqlparams(33) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Quotation_Type", Type)
            sqlparams(2) = New SqlParameter("@Quotation_TypeID", TypeID)
            sqlparams(3) = New SqlParameter("@Quotation_QuoStatus", QuoStatus)
            sqlparams(4) = New SqlParameter("@Quotation_Date", Quotation_Date)
            sqlparams(5) = New SqlParameter("@Quotation_Validity", Validity)
            sqlparams(6) = New SqlParameter("@Quotation_ModeOFPayment", ModeOFPayment)
            sqlparams(7) = New SqlParameter("@Quotation_TermOFDelivery", TermOFDelivery)
            sqlparams(8) = New SqlParameter("@Quotation_DispatchThrough", DispatchThrough)
            sqlparams(9) = New SqlParameter("@Quotation_AuthSign", AuthSign)
            sqlparams(10) = New SqlParameter("@Quotation_ExpClosing", ExpClosing)
            sqlparams(11) = New SqlParameter("@Quotation_OwnerID", OwnerID)
            sqlparams(12) = New SqlParameter("@Quotation_PrdAmount", PrdAmount)
            sqlparams(13) = New SqlParameter("@Quotation_CreatedID", CreatedID)
            sqlparams(14) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(15) = New SqlParameter("@Quotation_Freight", Quotation_Freight)
            sqlparams(16) = New SqlParameter("@Quotation_Currency", Currency)
            sqlparams(17) = New SqlParameter("@Quotation_CurrencyRate", CurrencyRate)
            sqlparams(18) = New SqlParameter("@Quotation_isChild", isChild)
            sqlparams(19) = New SqlParameter("@Quotation_TermsOfPayment", TermsOfPayment)
            sqlparams(20) = New SqlParameter("@Quotation_ModeOfTransport", ModeOfTransport)
            sqlparams(21) = New SqlParameter("@Quotation_CountryOfOrigin", CountryOfOrigin)
            sqlparams(22) = New SqlParameter("@Quotation_CountryOfFinalDestination", CountryOfFinalDestination)
            sqlparams(23) = New SqlParameter("@Quotation_PortOfLoading", PortOfLoading)
            sqlparams(24) = New SqlParameter("@Quotation_PortOfDischarge", PortOfDischarge)
            sqlparams(25) = New SqlParameter("@Quotation_FinalDestination", FinalDestination)
            sqlparams(26) = New SqlParameter("@Quotation_TrmsPyt_Card_doc", Quotation_TrmsPyt_Card_doc)
            sqlparams(27) = New SqlParameter("@Quotation_Doc_Clearance", Quotation_Doc_Clearance)
            sqlparams(28) = New SqlParameter("@Quotation_OceanFreight", Quotation_OceanFreight)
            sqlparams(29) = New SqlParameter("@Quotation_Insurance", Quotation_Insurance)
            sqlparams(30) = New SqlParameter("@Quotation_WithFreight", Quotation_WithFreight)
            sqlparams(31) = New SqlParameter("@Quotation_PrintIn", Quotation_PrintIn)
            sqlparams(32) = New SqlParameter("@BankId", BankId)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'gayatri created it.. if order exists createorder button is invisible on quotation page 23-08-2017
    Public Shared Function Checkorderexist(ByVal _pocode As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "orderCheck")
            sqlparams(1) = New SqlParameter("@Value", _pocode)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function CheckQtnbeforedit(ByVal id As Integer) As String
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "QuotationCheck")
            sqlparams(1) = New SqlParameter("@id", id)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function ViewByID(ByVal ID As Integer, ByVal Mode As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Quotation_Id", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function crystaldetails(ByVal Mode As String, ByVal id As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@id", id)
            'sqlparams(2) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            'sqlparams(3) = New SqlParameter("@Assignto_Type", Type)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function Quotationdiscount(ByVal Mode As String, ByVal Id As Integer, ByVal TypeId As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Id", Id)
            sqlparams(2) = New SqlParameter("@TypeId", TypeId)
            Return DBBridge.ExecuteDataset("_spFillByPaging", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateQuotationFreight(ByVal Quotation_FreightTaxPer As String, ByVal Quotation_Id As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateQuotationFreight")
            sqlparams(1) = New SqlParameter("@Quotation_FreightTaxPer", Quotation_FreightTaxPer)
            sqlparams(2) = New SqlParameter("@Quotation_Id", Quotation_Id)
            'sqlparams(3) = New SqlParameter("@Quotation_DiscountAmount", DiscountAmount)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
