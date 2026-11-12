Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class CustomerAddressBLL
    Private Shared _spname As String = "_spCustomerAddress"

    Public Shared Function UpdateAddress(ByVal _Address_Cust_Name As String, ByVal _Address_Cust_Email As String,
                                         ByVal _Address_Cust_Mobile As String, ByVal _Address_Country As Integer,
                                         ByVal _Address_City As String, ByVal _Address_State As Integer,
                                         ByVal _Address_Pincode As String, ByVal _Address_Address As String,
                                         ByVal _Address_Type As String, ByVal _Address_CustId As Integer, ByVal Address_ModifiedType As String, ByVal Address_ModifiedId As Integer) As Integer
        Dim sqlparams(12) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateAddress")
            sqlparams(1) = New SqlParameter("@Address_Country", _Address_Country)
            sqlparams(2) = New SqlParameter("@Address_City", _Address_City)
            sqlparams(3) = New SqlParameter("@Address_Pincode", _Address_Pincode)
            sqlparams(4) = New SqlParameter("@Address_Address", _Address_Address)
            sqlparams(5) = New SqlParameter("@Address_Type", _Address_Type)
            sqlparams(6) = New SqlParameter("@Address_CustId", _Address_CustId)
            sqlparams(7) = New SqlParameter("@Address_ModifiedId", Address_ModifiedId)
            sqlparams(8) = New SqlParameter("@Address_Cust_Name", _Address_Cust_Name)
            sqlparams(9) = New SqlParameter("@Address_Cust_Email", _Address_Cust_Email)
            sqlparams(10) = New SqlParameter("@Address_Cust_Mobile", _Address_Cust_Mobile)
            sqlparams(11) = New SqlParameter("@Address_State", _Address_State)
            sqlparams(12) = New SqlParameter("@Address_ModifiedType", Address_ModifiedType)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function AdminInsertAddress(ByVal _Address_Cust_Name As String, ByVal _Address_Cust_Email As String,
                                         ByVal _Address_Cust_Mobile As String, ByVal _Address_Country As Integer,
                                         ByVal _Address_City As String, ByVal _Address_State As Integer,
                                         ByVal _Address_Pincode As String, ByVal _Address_Address As String,
                                         ByVal _Address_Type As String, ByVal _Address_CustId As Integer, ByVal Address_ModifiedType As String, ByVal _Address_ModifiedId As Integer) As Integer
        Dim sqlparams(12) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "AdminInsertAddress")
            sqlparams(1) = New SqlParameter("@Address_Country", _Address_Country)
            sqlparams(2) = New SqlParameter("@Address_City", _Address_City)
            sqlparams(3) = New SqlParameter("@Address_Pincode", _Address_Pincode)
            sqlparams(4) = New SqlParameter("@Address_Address", _Address_Address)
            sqlparams(5) = New SqlParameter("@Address_Type", _Address_Type)
            sqlparams(6) = New SqlParameter("@Address_CustId", _Address_CustId)
            sqlparams(7) = New SqlParameter("@Address_ModifiedId", _Address_ModifiedId)
            sqlparams(8) = New SqlParameter("@Address_Cust_Name", _Address_Cust_Name)
            sqlparams(9) = New SqlParameter("@Address_Cust_Email", _Address_Cust_Email)
            sqlparams(10) = New SqlParameter("@Address_Cust_Mobile", _Address_Cust_Mobile)
            sqlparams(11) = New SqlParameter("@Address_State", _Address_State)
            sqlparams(12) = New SqlParameter("@Address_ModifiedType", Address_ModifiedType)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
