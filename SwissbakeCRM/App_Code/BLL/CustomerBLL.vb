Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class CustomerBLL
    Private Shared _spname As String = "_spCustomer"


    Public Shared Function CustAdminInsert(ByVal Cust_CompanyName As String, ByVal Cust_Name As String, ByVal Cust_EmailId As String,
                                  ByVal Cust_MobileNumber As String, ByVal Cust_DOB As String, ByVal Cust_PaymentMode As String,
                                  ByVal Cust_Pan As String, ByVal Cust_Tin As String, ByVal Cust_AssignTo As Integer,
                                  ByVal Cust_AList As String, ByVal Cust_CForm As Boolean, ByVal Cust_Password As String, ByVal Cust_ModifiedType As String, ByVal Cust_ModifiedId As Integer) As Integer
        Dim sqlparams(14) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "CustAdminInsert")
            sqlparams(1) = New SqlParameter("@Cust_CompanyName", Cust_CompanyName)
            sqlparams(2) = New SqlParameter("@Cust_Name", Cust_Name)
            sqlparams(3) = New SqlParameter("@Cust_EmailId", Cust_EmailId)
            sqlparams(4) = New SqlParameter("@Cust_MobileNumber", Cust_MobileNumber)
            sqlparams(5) = New SqlParameter("@Cust_DOB", Cust_DOB)
            sqlparams(6) = New SqlParameter("@Cust_PaymentMode", Cust_PaymentMode)
            sqlparams(7) = New SqlParameter("@Cust_Pan", Cust_Pan)
            sqlparams(8) = New SqlParameter("@Cust_Tin", Cust_Tin)
            sqlparams(9) = New SqlParameter("@Cust_AssignTo", Cust_AssignTo)
            sqlparams(10) = New SqlParameter("@Cust_AList", Cust_AList)
            sqlparams(11) = New SqlParameter("@Cust_CForm", Cust_CForm)
            sqlparams(12) = New SqlParameter("@Cust_Password", Cust_Password)
            sqlparams(13) = New SqlParameter("@Cust_ModifiedId", Cust_ModifiedId)
            sqlparams(14) = New SqlParameter("@Cust_ModifiedType", Cust_ModifiedType)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function CustAdminUpdate(ByVal Cust_CompanyName As String, ByVal Cust_Name As String, ByVal Cust_EmailId As String,
                                   ByVal Cust_MobileNumber As String, ByVal Cust_DOB As String, ByVal Cust_PaymentMode As String,
                                   ByVal Cust_Pan As String, ByVal Cust_Tin As String, ByVal Cust_AssignTo As Integer,
                                   ByVal Cust_AList As String, ByVal Cust_CForm As Boolean, ByVal Cust_ModifiedType As String, ByVal Cust_ModifiedId As Integer, ByVal Cust_ID As Integer) As Integer
        Dim sqlparams(14) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "CustAdminUpdate")
            sqlparams(1) = New SqlParameter("@Cust_CompanyName", Cust_CompanyName)
            sqlparams(2) = New SqlParameter("@Cust_Name", Cust_Name)
            sqlparams(3) = New SqlParameter("@Cust_EmailId", Cust_EmailId)
            sqlparams(4) = New SqlParameter("@Cust_MobileNumber", Cust_MobileNumber)
            sqlparams(5) = New SqlParameter("@Cust_DOB", Cust_DOB)
            sqlparams(6) = New SqlParameter("@Cust_PaymentMode", Cust_PaymentMode)
            sqlparams(7) = New SqlParameter("@Cust_Pan", Cust_Pan)
            sqlparams(8) = New SqlParameter("@Cust_Tin", Cust_Tin)
            sqlparams(9) = New SqlParameter("@Cust_AssignTo", Cust_AssignTo)
            sqlparams(10) = New SqlParameter("@Cust_AList", Cust_AList)
            sqlparams(11) = New SqlParameter("@Cust_CForm", Cust_CForm)
            sqlparams(12) = New SqlParameter("@Cust_ModifiedId", Cust_ModifiedId)
            sqlparams(13) = New SqlParameter("@Cust_ID", Cust_ID)
            sqlparams(14) = New SqlParameter("@Cust_ModifiedType", Cust_ModifiedType)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function Insert(ByVal _Cust_CompanyName As String, ByVal _Cust_Name As String, ByVal _Cust_EmailId As String, ByVal _Cust_MobileNumber As String, ByVal _Cust_Password As String) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")

            sqlparams(1) = New SqlParameter("@Cust_Name", _Cust_Name)
            sqlparams(2) = New SqlParameter("@Cust_EmailId", _Cust_EmailId)
            sqlparams(3) = New SqlParameter("@Cust_MobileNumber", _Cust_MobileNumber)
            sqlparams(4) = New SqlParameter("@Cust_CompanyName", _Cust_CompanyName)
            sqlparams(5) = New SqlParameter("@Cust_Password", _Cust_Password)

            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function InsertAddressDetails(ByVal _Address_CustId As Integer, ByVal _Address_Type As String, ByVal _Address_Cust_Name As String, ByVal _Address_Cust_Email As String, ByVal _Address_Cust_Mobile As String, ByVal _Address_Country As String, ByVal _Address_State As String, ByVal _Address_City As String, ByVal _Address_Pincode As String) As Integer
        Dim sqlparams(10) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertAddress")
            sqlparams(1) = New SqlParameter("@Address_Cust_Name", _Address_Cust_Name)
            sqlparams(2) = New SqlParameter("@Address_Cust_Email", _Address_Cust_Email)
            sqlparams(3) = New SqlParameter("@Address_Cust_Mobile", _Address_Cust_Mobile)
            sqlparams(4) = New SqlParameter("@Address_Country", _Address_Country)
            sqlparams(5) = New SqlParameter("@Address_CustId", _Address_CustId)
            sqlparams(6) = New SqlParameter("@Address_Type", _Address_Type)
            sqlparams(7) = New SqlParameter("@Address_State", _Address_State)
            sqlparams(8) = New SqlParameter("@Address_City", _Address_City)
            sqlparams(9) = New SqlParameter("@Address_Pincode", _Address_Pincode)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function AddressInsert(ByVal _Cust_Name As String, ByVal _Cust_EmailId As String, ByVal _Cust_MobileNumber As String, ByVal _Cust_Status As String) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Cust_Name", _Cust_Name)
            sqlparams(2) = New SqlParameter("@Cust_EmailId", _Cust_EmailId)
            sqlparams(3) = New SqlParameter("@Cust_MobileNumber", _Cust_MobileNumber)
            sqlparams(4) = New SqlParameter("@Cust_Status", _Cust_Status)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function CheckPassword(ByVal _Cust_ID As String) As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "CheckPassword")
            sqlparams(1) = New SqlParameter("@Cust_ID", _Cust_ID)

            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdatePassword(ByVal Cust_Password As String, ByVal Cust_ID As Integer) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdatePassword")
            sqlparams(1) = New SqlParameter("@Cust_Password", Cust_Password)
            sqlparams(2) = New SqlParameter("@Cust_ID", Cust_ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdatePaymentMode(ByVal _PaymentMode As String, ByVal _Cust_ID As Integer) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdatePaymentMode")
            sqlparams(1) = New SqlParameter("@Cust_PaymentMode", _PaymentMode)
            sqlparams(2) = New SqlParameter("@Cust_ID", _Cust_ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateTaxationMode(ByVal _Cust_Pan As String, ByVal _Cust_Tin As String, ByVal _Cust_ID As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateTaxation")
            sqlparams(1) = New SqlParameter("@Cust_Pan", _Cust_Pan)
            sqlparams(2) = New SqlParameter("@Cust_ID", _Cust_ID)
            sqlparams(3) = New SqlParameter("@Cust_Tin", _Cust_Tin)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Taxation_ViewByID(ByVal _Cust_ID As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Taxation_ViewById")
            sqlparams(1) = New SqlParameter("@Cust_ID", _Cust_ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateProfile(ByVal _Cust_CompanyName As String, ByVal _Cust_Name As String, ByVal _Cust_EmailId As String, ByVal _Cust_MobileNumber As String, ByVal _Cust_DOB As Date, ByVal _Cust_ID As Integer, ByVal Cust_ModifiedId As Integer) As Integer
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateProfile")
            sqlparams(1) = New SqlParameter("@Cust_Name", _Cust_Name)
            sqlparams(2) = New SqlParameter("@Cust_EmailId", _Cust_EmailId)
            sqlparams(3) = New SqlParameter("@Cust_MobileNumber", _Cust_MobileNumber)
            sqlparams(4) = New SqlParameter("@Cust_DOB", _Cust_DOB)
            sqlparams(5) = New SqlParameter("@Cust_ID", _Cust_ID)
            sqlparams(6) = New SqlParameter("@Cust_ModifiedId", Cust_ModifiedId)
            sqlparams(6) = New SqlParameter("@Cust_CompanyName", _Cust_CompanyName)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ViewByID(ByVal _Cust_ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ViewById")
            sqlparams(1) = New SqlParameter("@Cust_ID", _Cust_ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillListView(ByVal Complaint_ID As Integer, ByVal Mode As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Complaint_ID", Complaint_ID)

            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ValidateLogin(ByVal _Cust_EmailId As String, ByVal _Cust_Password As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ValidateLogin")
            sqlparams(1) = New SqlParameter("@Cust_EmailId", _Cust_EmailId)
            sqlparams(2) = New SqlParameter("@Cust_Password", _Cust_Password)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ValidateOldPass(ByVal _Cust_Id As String, ByVal _Cust_Password As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ValidateOldPass")
            sqlparams(1) = New SqlParameter("@Cust_Id", _Cust_Id)
            sqlparams(2) = New SqlParameter("@Cust_Password", _Cust_Password)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
