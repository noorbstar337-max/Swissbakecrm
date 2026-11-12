Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class ProspectAddressBLL
    Private Shared _spname As String = "_spAccountAddress"

    Public Shared Function Insert(ByVal AccAddr_AccID As Integer, ByVal AccAddr_Type As String, ByVal AccAddr_Name As String, ByVal AccAddr_Email As String,
                                  ByVal AccAddr_Mobile As String, ByVal AccAddr_Telephone As String, ByVal AccAddr_Fax As String, ByVal AccAddr_Address As String,
                                  ByVal AccAddr_City As String, ByVal AccAddr_State As Integer, ByVal AccAddr_Country As Integer, ByVal AccAddr_Pincode As String,
                                  ByVal AccAddr_CreatedId As Integer, ByVal AccAddr_GST As String) As Integer
        Dim sqlparams(15) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@AccAddr_AccID", AccAddr_AccID)
            sqlparams(2) = New SqlParameter("@AccAddr_Type", AccAddr_Type)
            sqlparams(3) = New SqlParameter("@AccAddr_Name", AccAddr_Name)
            sqlparams(4) = New SqlParameter("@AccAddr_Email", AccAddr_Email)
            sqlparams(5) = New SqlParameter("@AccAddr_Mobile", AccAddr_Mobile)
            sqlparams(6) = New SqlParameter("@AccAddr_Telephone", AccAddr_Telephone)
            sqlparams(7) = New SqlParameter("@AccAddr_Fax", AccAddr_Fax)
            sqlparams(8) = New SqlParameter("@AccAddr_Address", AccAddr_Address)
            sqlparams(9) = New SqlParameter("@AccAddr_City", AccAddr_City)
            sqlparams(10) = New SqlParameter("@AccAddr_State", AccAddr_State)
            sqlparams(11) = New SqlParameter("@AccAddr_Country", AccAddr_Country)
            sqlparams(12) = New SqlParameter("@AccAddr_Pincode", AccAddr_Pincode)
            sqlparams(13) = New SqlParameter("@AccAddr_CreatedId", AccAddr_CreatedId)
            sqlparams(14) = New SqlParameter("@AccAddr_GST", AccAddr_GST)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function Update(ByVal AccAddr_AccID As Integer, ByVal AccAddr_Type As String, ByVal AccAddr_Name As String, ByVal AccAddr_Email As String,
                                  ByVal AccAddr_Mobile As String, ByVal AccAddr_Telephone As String, ByVal AccAddr_Fax As String, ByVal AccAddr_Address As String,
                                  ByVal AccAddr_City As String, ByVal AccAddr_State As Integer, ByVal AccAddr_Country As Integer, ByVal AccAddr_Pincode As String,
                                  ByVal AccAddr_ModifiedId As Integer, ByVal AccAddr_GST As String) As Integer
        Dim sqlparams(15) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@AccAddr_AccID", AccAddr_AccID)
            sqlparams(2) = New SqlParameter("@AccAddr_Type", AccAddr_Type)
            sqlparams(3) = New SqlParameter("@AccAddr_Name", AccAddr_Name)
            sqlparams(4) = New SqlParameter("@AccAddr_Email", AccAddr_Email)
            sqlparams(5) = New SqlParameter("@AccAddr_Mobile", AccAddr_Mobile)
            sqlparams(6) = New SqlParameter("@AccAddr_Telephone", AccAddr_Telephone)
            sqlparams(7) = New SqlParameter("@AccAddr_Fax", AccAddr_Fax)
            sqlparams(8) = New SqlParameter("@AccAddr_Address", AccAddr_Address)
            sqlparams(9) = New SqlParameter("@AccAddr_City", AccAddr_City)
            sqlparams(10) = New SqlParameter("@AccAddr_State", AccAddr_State)
            sqlparams(11) = New SqlParameter("@AccAddr_Country", AccAddr_Country)
            sqlparams(12) = New SqlParameter("@AccAddr_Pincode", AccAddr_Pincode)
            sqlparams(13) = New SqlParameter("@AccAddr_ModifiedId", AccAddr_ModifiedId)
            sqlparams(14) = New SqlParameter("@AccAddr_GST", AccAddr_GST)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function UpdateShipping(ByVal AccAddr_ID As Integer, ByVal AccAddr_Type As String, ByVal AccAddr_Name As String, ByVal AccAddr_Email As String,
                                  ByVal AccAddr_Mobile As String, ByVal AccAddr_Telephone As String, ByVal AccAddr_Fax As String, ByVal AccAddr_Address As String,
                                  ByVal AccAddr_City As String, ByVal AccAddr_State As Integer, ByVal AccAddr_Country As Integer, ByVal AccAddr_Pincode As String,
                                  ByVal AccAddr_ModifiedId As Integer, ByVal AccAddr_GST As String) As Integer
        Dim sqlparams(15) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateShipping")
            sqlparams(1) = New SqlParameter("@AccAddr_ID", AccAddr_ID)
            sqlparams(2) = New SqlParameter("@AccAddr_Type", AccAddr_Type)
            sqlparams(3) = New SqlParameter("@AccAddr_Name", AccAddr_Name)
            sqlparams(4) = New SqlParameter("@AccAddr_Email", AccAddr_Email)
            sqlparams(5) = New SqlParameter("@AccAddr_Mobile", AccAddr_Mobile)
            sqlparams(6) = New SqlParameter("@AccAddr_Telephone", AccAddr_Telephone)
            sqlparams(7) = New SqlParameter("@AccAddr_Fax", AccAddr_Fax)
            sqlparams(8) = New SqlParameter("@AccAddr_Address", AccAddr_Address)
            sqlparams(9) = New SqlParameter("@AccAddr_City", AccAddr_City)
            sqlparams(10) = New SqlParameter("@AccAddr_State", AccAddr_State)
            sqlparams(11) = New SqlParameter("@AccAddr_Country", AccAddr_Country)
            sqlparams(12) = New SqlParameter("@AccAddr_Pincode", AccAddr_Pincode)
            sqlparams(13) = New SqlParameter("@AccAddr_ModifiedId", AccAddr_ModifiedId)
            sqlparams(14) = New SqlParameter("@AccAddr_GST", AccAddr_GST)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
