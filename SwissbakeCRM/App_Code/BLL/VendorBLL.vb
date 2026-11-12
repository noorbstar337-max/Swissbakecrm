Imports APPCODE.DAL

Public Class VendorBLL
    Private Shared _spname As String = "_spVendor"
  
    'Public Shared Function InsertPrinciple(ByVal Principle_CompanyName As String, ByVal Principle_ContactPerson As String, ByVal Principle_EmailID As String,
    '                                       ByVal Principle_MobileNo As String, ByVal Principle_City As String, ByVal Principle_CreateID As Integer,
    '                                       Principle_IsVendor As Integer) As Integer
    '    Dim sqlparams(9) As SqlParameter
    '    Try
    '        sqlparams(0) = New SqlParameter("@Mode", "InsertPrinciple")
    '        sqlparams(1) = New SqlParameter("@Principle_CompanyName", Principle_CompanyName)
    '        sqlparams(2) = New SqlParameter("@Principle_ContactPerson", Principle_ContactPerson)
    '        sqlparams(3) = New SqlParameter("@Principle_EmailID", Principle_EmailID)
    '        sqlparams(5) = New SqlParameter("@Principle_MobileNo", Principle_MobileNo)
    '        sqlparams(6) = New SqlParameter("@Principle_City ", Principle_City)
    '        sqlparams(7) = New SqlParameter("@Principle_CreateID", Principle_CreateID)
    '        sqlparams(9) = New SqlParameter("@Principle_IsVendor", Principle_IsVendor)
    '        Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    ' -----------------------------------angelo---------  for Insert------------------------------------------------------
    Public Shared Function Update(ByVal Vendor_Name As String, ByVal Vendor_Type As String, ByVal Vendor_ContactNo As String, ByVal Vendor_Mobile As String,
                                  ByVal Vendor_Email As String, ByVal Vendor_ConactPerson As String, ByVal Vendor_Address As String, ByVal Vendor_City As String,
                                  ByVal Vendor_State As String, ByVal Vendor_Country As String, ByVal Vendor_PinCode As String, ByVal Vendor_PrincipleName As String,
                                  ByVal Vendor_PConactPerson As String, ByVal Vendor_PContactNo As String, ByVal Vendor_PMobile As String, ByVal Vendor_PEmail As String,
                                  ByRef Vendor_PAddress As String, ByVal Vendor_PCity As String, ByVal Vendor_PState As String, ByVal Vendor_PCountry As String,
                                  ByVal Vendor_PPincode As String, ByVal Vendor_CreatedID As Integer, ByVal Vendor_ID As Integer) As Integer
        Dim sqlparams(23) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Vendor_Name", Vendor_Name)
            sqlparams(2) = New SqlParameter("@Vendor_Type", Vendor_Type)
            sqlparams(3) = New SqlParameter("@Vendor_ContactNo", Vendor_ContactNo)
            sqlparams(4) = New SqlParameter("@Vendor_Mobile", Vendor_Mobile)
            sqlparams(5) = New SqlParameter("@Vendor_Email", Vendor_Email)
            sqlparams(6) = New SqlParameter("@Vendor_ConactPerson", Vendor_ConactPerson)
            sqlparams(7) = New SqlParameter("@Vendor_Address", Vendor_Address)
            sqlparams(8) = New SqlParameter("@Vendor_City", Vendor_City)
            sqlparams(9) = New SqlParameter("@Vendor_State", Vendor_State)
            sqlparams(10) = New SqlParameter("@Vendor_Country", Vendor_Country)
            sqlparams(11) = New SqlParameter("@Vendor_PinCode", Vendor_PinCode)
            sqlparams(12) = New SqlParameter("@Vendor_PrincipleName", Vendor_PrincipleName)
            sqlparams(13) = New SqlParameter("@Vendor_PConactPerson", Vendor_PConactPerson)
            sqlparams(14) = New SqlParameter("@Vendor_PContactNo", Vendor_PContactNo)
            sqlparams(15) = New SqlParameter("@Vendor_PMobile", Vendor_PMobile)
            sqlparams(16) = New SqlParameter("@Vendor_PEmail", Vendor_PEmail)
            sqlparams(17) = New SqlParameter("@Vendor_PAddress", Vendor_PAddress)
            sqlparams(18) = New SqlParameter("@Vendor_PCity", Vendor_PCity)
            sqlparams(19) = New SqlParameter("@Vendor_PState", Vendor_PState)
            sqlparams(20) = New SqlParameter("@Vendor_PCountry", Vendor_PCountry)
            sqlparams(21) = New SqlParameter("@Vendor_PPincode", Vendor_PPincode)
            sqlparams(22) = New SqlParameter("@Vendor_CreatedID", Vendor_CreatedID)
            sqlparams(23) = New SqlParameter("@Vendor_ID", Vendor_ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function










    Public Shared Function XMLInsert(ByVal XML As String) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "XMLInsert")
            sqlparams(1) = New SqlParameter("@XML", XML)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillGridView(ByVal Mode As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            Return DBBridge.ExecuteDataset("_spVendor", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillGridViewByID(ByVal Mode As String, ByVal ID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)
            Return DBBridge.ExecuteDataset("_spVendor", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' -----------------------------------angelo---------  for Insert------------------------------------------------------
    '========gayatri added Vendor_PaymentTermsDays on 27-07-2017============================
    Public Shared Function Insertvendor(ByVal Vendor_Name As String, ByVal Vendor_Type As Integer, ByVal Vendor_Address As String, ByVal Vendor_City As String,
                                  ByVal Vendor_State As Integer, ByVal Vendor_Country As Integer, ByVal Vendor_PinCode As String, ByVal Vendor_CreatedID As Integer,
                                  ByVal Vendor_CstNo As String, ByVal Vendor_VatTinNo As String, ByVal Vendor_PaymentTerms As String, ByVal Vendor_gstno As String, ByVal Vendor_PaymentTermsDays As Integer) As Integer
        Dim sqlparams(14) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insertvendor")
            sqlparams(1) = New SqlParameter("@Vendor_Name", Vendor_Name)
            sqlparams(2) = New SqlParameter("@Vendor_Type", Vendor_Type)
            sqlparams(3) = New SqlParameter("@Vendor_Address", Vendor_Address)
            sqlparams(4) = New SqlParameter("@Vendor_City", Vendor_City)
            sqlparams(5) = New SqlParameter("@Vendor_State", Vendor_State)
            sqlparams(6) = New SqlParameter("@Vendor_Country", Vendor_Country)
            sqlparams(7) = New SqlParameter("@Vendor_PinCode", Vendor_PinCode)
            sqlparams(8) = New SqlParameter("@Vendor_CreatedID", Vendor_CreatedID)
            sqlparams(9) = New SqlParameter("@Vendor_CstNo", Vendor_CstNo)
            sqlparams(10) = New SqlParameter("@Vendor_VatTinNo", Vendor_VatTinNo)
            sqlparams(11) = New SqlParameter("@Vendor_PaymentTerms", Vendor_PaymentTerms)
            sqlparams(12) = New SqlParameter("@Vendor_gstno", Vendor_gstno)
            sqlparams(13) = New SqlParameter("@Vendor_PaymentTermsDays", Vendor_PaymentTermsDays)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertContact(ByVal Contact_ContactPerson As String, ByVal Contact_Email As String, ByVal Contact_Mobile As String, ByVal Contact_Landline As String, ByVal Contact_Primary As Boolean, ByVal Contact_IsVendor As Integer, ByVal Contact_CreatedID As Integer, ByVal Contact_Secondary As Boolean) As Integer
        Dim sqlparams(10) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertContact")
            sqlparams(1) = New SqlParameter("@Contact_ContactPerson", Contact_ContactPerson)
            sqlparams(2) = New SqlParameter("@Contact_Email", Contact_Email)
            sqlparams(3) = New SqlParameter("@Contact_Mobile", Contact_Mobile)
            sqlparams(4) = New SqlParameter("@Contact_Landline", Contact_Landline)
            sqlparams(6) = New SqlParameter("@Contact_Primary", Contact_Primary)
            sqlparams(7) = New SqlParameter("@Contact_IsVendor", Contact_IsVendor)
            sqlparams(8) = New SqlParameter("@Contact_CreatedID", Contact_CreatedID)
            sqlparams(9) = New SqlParameter("@Contact_IsSecondary", Contact_Secondary)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertPrinciple(ByVal Principle_CompanyName As String, ByVal Principle_CreateID As Integer, Principle_IsVendor As Integer) As Integer
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertPrinciple")
            sqlparams(1) = New SqlParameter("@PV_PID", Principle_CompanyName)
            sqlparams(2) = New SqlParameter("@PV_CreateID", Principle_CreateID)
            sqlparams(3) = New SqlParameter("@PV_VID", Principle_IsVendor)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function DeletePrinciple(Principle_IsVendor As Integer) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "DeletePrinciple")
            sqlparams(1) = New SqlParameter("@PV_VID", Principle_IsVendor)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' -----------------------------------angelo--------- for update-----------------------------------------------------------------------------------
    '========gayatri added Vendor_PaymentTermsDays on 27-07-2017============================
    Public Shared Function UpdateVendor(ByVal Vendor_Name As String, ByVal Vendor_Type As String, ByVal Vendor_Address As String, ByVal Vendor_City As String,
                                  ByVal Vendor_State As String, ByVal Vendor_Country As String, ByVal Vendor_PinCode As String, ByVal Vendor_ModifiedID As Integer,
                                   ByVal Vendor_ID As Integer, ByVal Vendor_CstNo As String, ByVal Vendor_VatTinNo As String, ByVal Vendor_PaymentTerms As String, ByVal Vendor_gstno As String, ByVal Vendor_PaymentTermsDays As Integer) As Integer
        Dim sqlparams(15) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateVendor")
            sqlparams(1) = New SqlParameter("@Vendor_Name", Vendor_Name)
            sqlparams(2) = New SqlParameter("@Vendor_Type", Vendor_Type)
            sqlparams(3) = New SqlParameter("@Vendor_Address", Vendor_Address)
            sqlparams(4) = New SqlParameter("@Vendor_City", Vendor_City)
            sqlparams(5) = New SqlParameter("@Vendor_State", Vendor_State)
            sqlparams(6) = New SqlParameter("@Vendor_Country", Vendor_Country)
            sqlparams(7) = New SqlParameter("@Vendor_PinCode", Vendor_PinCode)
            sqlparams(8) = New SqlParameter("@Vendor_ID", Vendor_ID)
            sqlparams(9) = New SqlParameter("@Vendor_CstNo", Vendor_CstNo)
            sqlparams(10) = New SqlParameter("@Vendor_VatTinNo", Vendor_VatTinNo)
            sqlparams(11) = New SqlParameter("@Vendor_PaymentTerms", Vendor_PaymentTerms)
            sqlparams(12) = New SqlParameter("@Vendor_ModifiedID", Vendor_ModifiedID)
            sqlparams(13) = New SqlParameter("@Vendor_gstno", Vendor_gstno)
            sqlparams(14) = New SqlParameter("@Vendor_PaymentTermsDays", Vendor_PaymentTermsDays)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateContact(ByVal Contact_ContactPerson As String, ByVal Contact_Email As String, ByVal Contact_Mobile As String,
                                         ByVal Contact_Landline As String, ByVal Contact_Primary As Boolean, ByVal Contact_ModifiedID As Integer, ByVal Contact_ID As Integer, ByVal Contact_IsSecondary As Boolean) As Integer
        Dim sqlparams(10) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateContact")
            sqlparams(1) = New SqlParameter("@Contact_ContactPerson", Contact_ContactPerson)
            sqlparams(2) = New SqlParameter("@Contact_Email", Contact_Email)
            sqlparams(3) = New SqlParameter("@Contact_Mobile", Contact_Mobile)
            sqlparams(4) = New SqlParameter("@Contact_Landline", Contact_Landline)
            sqlparams(6) = New SqlParameter("@Contact_Primary", Contact_Primary)
            sqlparams(7) = New SqlParameter("@Contact_Id", Contact_ID)
            sqlparams(8) = New SqlParameter("@Contact_ModifiedID", Contact_ModifiedID)
            sqlparams(9) = New SqlParameter("@Contact_IsSecondary", Contact_IsSecondary)


            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Shared Function UpdatePrinciple(ByVal Principle_CompanyName As String, ByVal Principle_ModifiedID As Integer, PV_Id As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdatePrinciple")
            sqlparams(1) = New SqlParameter("@PV_PID", Principle_CompanyName)
            sqlparams(2) = New SqlParameter("@PV_Id", PV_Id)
            sqlparams(3) = New SqlParameter("@PV_ModifiedID", Principle_ModifiedID)

            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    

    ' -----------------------------------angelo---------- for update --------------------------------------------------------------------------------------
    Public Shared Function DeleteContact(ByVal Contact_ID As Integer) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "DeleteContact")

            sqlparams(1) = New SqlParameter("@Contact_Id", Contact_ID)

            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
