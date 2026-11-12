Imports APPCODE.DAL

Public Class CompanyBLL
    Private Shared _spname As String = "_spCrmCompany"

    Public Shared Function Update(ByVal CM_Phone As String, ByVal CM_FaxNo As String, ByVal CM_InfoEmail As String, ByVal CM_CTS As String,
                                  ByVal CM_Country As Integer, ByVal CM_State As Integer, ByVal CM_Image As String, ByVal CM_PAN As String,
                                  ByVal CM_Cin As String, ByVal CM_VatTin As String, ByVal CM_STaxRegNo As String, ByVal CM_STTime As String,
                                  ByVal CM_STType As String, ByVal CM_ModifiedID As Integer, ByVal CM_ID As Integer, ByVal CM_Address1 As String,
                                  ByVal CM_Address2 As String, ByVal CM_HImage As String, ByVal CM_FImage As String) As Integer
        Dim sqlparams(19) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@CM_Phone", CM_Phone)
            sqlparams(2) = New SqlParameter("@CM_FaxNo", CM_FaxNo)
            sqlparams(3) = New SqlParameter("@CM_InfoEmail", CM_InfoEmail)
            sqlparams(4) = New SqlParameter("@CM_CTS", CM_CTS)
            sqlparams(5) = New SqlParameter("@CM_Country", CM_Country)
            sqlparams(6) = New SqlParameter("@CM_State", CM_State)
            sqlparams(7) = New SqlParameter("@CM_Image", CM_Image)
            sqlparams(8) = New SqlParameter("@CM_PAN", CM_PAN)
            sqlparams(9) = New SqlParameter("@CM_Cin", CM_Cin)
            sqlparams(10) = New SqlParameter("@CM_VatTin", CM_VatTin)
            sqlparams(11) = New SqlParameter("@CM_STaxRegNo", CM_STaxRegNo)
            sqlparams(12) = New SqlParameter("@CM_STTime", CM_STTime)
            sqlparams(13) = New SqlParameter("@CM_STType", CM_STType)
            sqlparams(14) = New SqlParameter("@CM_ModifiedID", CM_ModifiedID)
            sqlparams(15) = New SqlParameter("@CM_ID", CM_ID)
            sqlparams(16) = New SqlParameter("@CM_Address1", CM_Address1)
            sqlparams(17) = New SqlParameter("@CM_Address2", CM_Address2)
            sqlparams(18) = New SqlParameter("@CM_HImage", CM_HImage)
            sqlparams(19) = New SqlParameter("@CM_FImage", CM_FImage)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class