Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class LeadAddressBLL
    Private Shared _spname As String = "_spLeadAddress"

    Public Shared Function Insert(ByVal LeadAddress_Address As String, ByVal LeadAddress_City As String, ByVal LeadAddress_State As String,
                                  ByVal LeadAddress_Country As String, ByVal LeadAddress_Pincode As String, ByVal LeadAddress_CreatedId As Integer,
                                  ByVal LeadAddress_LeadID As Integer, ByVal LeadAddress_Type As String, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@LeadAddress_Address", LeadAddress_Address)
            sqlparams(2) = New SqlParameter("@LeadAddress_City", LeadAddress_City)
            sqlparams(3) = New SqlParameter("@LeadAddress_State", LeadAddress_State)
            sqlparams(4) = New SqlParameter("@LeadAddress_Country", LeadAddress_Country)
            sqlparams(5) = New SqlParameter("@LeadAddress_Pincode", LeadAddress_Pincode)
            sqlparams(6) = New SqlParameter("@LeadAddress_CreatedId", LeadAddress_CreatedId)
            sqlparams(7) = New SqlParameter("@LeadAddress_LeadID", LeadAddress_LeadID)
            sqlparams(8) = New SqlParameter("@LeadAddress_Type", LeadAddress_Type)
            sqlparams(9) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function Update(ByVal LeadAddress_Address As String, ByVal LeadAddress_City As String, ByVal LeadAddress_State As String,
                                  ByVal LeadAddress_Country As String, ByVal LeadAddress_Pincode As String, ByVal LeadAddress_ModifiedId As Integer,
                                  ByVal LeadAddress_LeadID As Integer, ByVal LeadAddress_Type As String, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@LeadAddress_Address", LeadAddress_Address)
            sqlparams(2) = New SqlParameter("@LeadAddress_City", LeadAddress_City)
            sqlparams(3) = New SqlParameter("@LeadAddress_State", LeadAddress_State)
            sqlparams(4) = New SqlParameter("@LeadAddress_Country", LeadAddress_Country)
            sqlparams(5) = New SqlParameter("@LeadAddress_Pincode", LeadAddress_Pincode)
            sqlparams(6) = New SqlParameter("@LeadAddress_ModifiedId", LeadAddress_ModifiedId)
            sqlparams(7) = New SqlParameter("@LeadAddress_LeadID", LeadAddress_LeadID)
            sqlparams(8) = New SqlParameter("@LeadAddress_Type", LeadAddress_Type)
            sqlparams(9) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
