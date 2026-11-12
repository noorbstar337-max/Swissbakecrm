Imports APPCODE.DAL

Public Class ProspectBLL
    Private Shared _spname As String = "_spAccount"

    Public Shared Function Insert(ByVal Acc_Name As String, ByVal Acc_IndustryId As Integer, ByVal Acc_Description As String,
                                  ByVal Acc_SourceID As Integer, ByVal Acc_CampaignID As Integer, ByVal Acc_OwnerID As Integer, ByVal Acc_CompanyTypeID As Integer,
                                  ByVal Acc_Website As String, ByVal Acc_TurnOver As String, ByVal Acc_CreatedID As Integer, ByVal AudtTrail_LogId As Integer,
                                  ByVal Cust_StoreName As String, ByVal Cust_Password As String, ByVal Cust_AList As String, ByVal Cust_CForm As Boolean,
                                  ByVal Cust_EmailId As String, ByVal Cust_Vat As String, ByVal Cust_Pan As String, ByVal Cust_Tin As String, ByVal Acc_Type As String, ByVal Acc_OpeningBalance As String, ByVal Cust_GST As String, ByVal category As String, ByVal Acc_dueDays As Integer,
								  ByVal Acc_TcsApplicable As Boolean, ByVal BankId As Integer) As Integer
        Dim sqlparams(28) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Acc_Name", Acc_Name)
            sqlparams(3) = New SqlParameter("@Acc_IndustryId", Acc_IndustryId)
            sqlparams(4) = New SqlParameter("@Acc_Description", Acc_Description)
            sqlparams(5) = New SqlParameter("@Acc_SourceID", Acc_SourceID)
            sqlparams(6) = New SqlParameter("@Acc_CampaignID", Acc_CampaignID)
            sqlparams(7) = New SqlParameter("@Acc_OwnerID", Acc_OwnerID)
            sqlparams(8) = New SqlParameter("@Acc_CompanyTypeID", Acc_CompanyTypeID)
            sqlparams(9) = New SqlParameter("@Acc_Website", Acc_Website)
            sqlparams(10) = New SqlParameter("@Acc_TurnOver", Acc_TurnOver)
            sqlparams(11) = New SqlParameter("@Acc_CreatedID", Acc_CreatedID)
            sqlparams(12) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(13) = New SqlParameter("@Cust_StoreName", Cust_StoreName)
            sqlparams(14) = New SqlParameter("@Cust_Password", Cust_Password)
            sqlparams(15) = New SqlParameter("@Cust_AList", Cust_AList)
            sqlparams(16) = New SqlParameter("@Cust_CForm", Cust_CForm)
            sqlparams(17) = New SqlParameter("@Cust_EmailId", Cust_EmailId)
            sqlparams(18) = New SqlParameter("@Cust_Vat", Cust_Vat)
            sqlparams(19) = New SqlParameter("@Cust_Pan", Cust_Pan)
            sqlparams(20) = New SqlParameter("@Cust_Tin", Cust_Tin)
            sqlparams(21) = New SqlParameter("@Acc_Type", Acc_Type)
            sqlparams(22) = New SqlParameter("@Acc_OpeningBalance", Acc_OpeningBalance)
            sqlparams(23) = New SqlParameter("@Cust_GST", Cust_GST)
            sqlparams(24) = New SqlParameter("@Acc_Category", category)
            sqlparams(25) = New SqlParameter("@Acc_dueDays", Acc_dueDays)
			sqlparams(26) = New SqlParameter("@Acc_TcsApplicable", Acc_TcsApplicable)
            sqlparams(27) = New SqlParameter("@BankId", BankId)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

  
    Public Shared Function Update(ByVal Acc_Name As String, ByVal Acc_IndustryId As Integer, ByVal Acc_Description As String,
                                  ByVal Acc_SourceID As Integer, ByVal Acc_CampaignID As Integer, ByVal Acc_OwnerID As Integer, ByVal Acc_CompanyTypeID As Integer,
                                  ByVal Acc_Website As String, ByVal Acc_TurnOver As String, ByVal Acc_ModifiedID As Integer, ByVal Acc_Id As Integer, ByVal AudtTrail_LogId As Integer,
                                  ByVal Cust_StoreName As String, ByVal Cust_Password As String, ByVal Cust_AList As String, ByVal Cust_CForm As String,
                                  ByVal Cust_EmailId As String, ByVal Cust_Vat As String, ByVal Cust_Pan As String, ByVal Cust_Tin As String, ByVal Acc_OpeningBalance As String, ByVal Cust_GST As String, ByVal category As String, ByVal Acc_dueDays As Integer,
								  ByVal Acc_TcsApplicable As Boolean, ByVal BankId As Integer) As Integer
        Dim sqlparams(28) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Acc_Name", Acc_Name)
            sqlparams(3) = New SqlParameter("@Acc_IndustryId", Acc_IndustryId)
            sqlparams(4) = New SqlParameter("@Acc_Description", Acc_Description)
            sqlparams(5) = New SqlParameter("@Acc_SourceID", Acc_SourceID)
            sqlparams(6) = New SqlParameter("@Acc_CampaignID", Acc_CampaignID)
            sqlparams(7) = New SqlParameter("@Acc_OwnerID", Acc_OwnerID)
            sqlparams(8) = New SqlParameter("@Acc_CompanyTypeID", Acc_CompanyTypeID)
            sqlparams(9) = New SqlParameter("@Acc_Website", Acc_Website)
            sqlparams(10) = New SqlParameter("@Acc_TurnOver", Acc_TurnOver)
            sqlparams(11) = New SqlParameter("@Acc_ModifiedID", Acc_ModifiedID)
            sqlparams(12) = New SqlParameter("@Acc_Id", Acc_Id)
            sqlparams(13) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(14) = New SqlParameter("@Cust_StoreName", Cust_StoreName)
            sqlparams(15) = New SqlParameter("@Cust_Password", Cust_Password)
            sqlparams(16) = New SqlParameter("@Cust_AList", Cust_AList)
            sqlparams(17) = New SqlParameter("@Cust_CForm", Cust_CForm)
            sqlparams(18) = New SqlParameter("@Cust_EmailId", Cust_EmailId)
            sqlparams(19) = New SqlParameter("@Cust_Vat", Cust_Vat)
            sqlparams(20) = New SqlParameter("@Cust_Pan", Cust_Pan)
            sqlparams(21) = New SqlParameter("@Cust_Tin", Cust_Tin)
            sqlparams(22) = New SqlParameter("@Acc_OpeningBalance", Acc_OpeningBalance)
            sqlparams(23) = New SqlParameter("@Cust_GST", Cust_GST)
            sqlparams(24) = New SqlParameter("@Acc_Category", category)
            sqlparams(25) = New SqlParameter("@Acc_dueDays", Acc_dueDays)
			sqlparams(26) = New SqlParameter("@Acc_TcsApplicable", Acc_TcsApplicable)
            sqlparams(27) = New SqlParameter("@BankId", BankId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
	
	
	Public Shared Function Dropdown() As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "DropDown")
            Return DBBridge.ExecuteDataset("_spBank", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
