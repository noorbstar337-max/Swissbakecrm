Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class MCRMBLL
    '---------By MUBYN and used in MCRMAddAccount and MCRMAddProspect
    Public Shared Function InsertMCRMAccount(ByVal Acc_Name As String, ByVal Acc_IndustryId As Integer, ByVal Acc_SourceID As Integer, ByVal Acc_CampaignID As Integer,
                                            ByVal Acc_OwnerID As Integer, ByVal Acc_CompanyTypeID As Integer, ByVal Acc_CreatedID As Integer, ByVal AudtTrail_LogId As Integer,
                                            ByVal Cust_Password As String, ByVal Cust_EmailId As String, ByVal Acc_Type As String, ByVal Acc_OpeningBalance As String, ByVal Acc_dueDays As Integer) As Integer
        Dim sqlparams(14) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertMCRMAccount")
            sqlparams(1) = New SqlParameter("@Acc_Name", Acc_Name)
            sqlparams(2) = New SqlParameter("@Acc_IndustryId", Acc_IndustryId)
            sqlparams(3) = New SqlParameter("@Acc_SourceID", Acc_SourceID)
            sqlparams(4) = New SqlParameter("@Acc_CampaignID", Acc_CampaignID)
            sqlparams(5) = New SqlParameter("@Acc_OwnerID", Acc_OwnerID)
            sqlparams(6) = New SqlParameter("@Acc_CompanyTypeID", Acc_CompanyTypeID)
            sqlparams(7) = New SqlParameter("@Acc_CreatedID", Acc_CreatedID)
            sqlparams(8) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(9) = New SqlParameter("@Cust_Password", Cust_Password)
            sqlparams(10) = New SqlParameter("@Cust_EmailId", Cust_EmailId)
            sqlparams(11) = New SqlParameter("@Acc_Type", Acc_Type)
            sqlparams(12) = New SqlParameter("@Acc_OpeningBalance", Acc_OpeningBalance)
            sqlparams(13) = New SqlParameter("@Acc_dueDays", Acc_dueDays)

            'sqlparams(4) = New SqlParameter("@Acc_Description", Acc_Description)
            '
            '
            'sqlparams(9) = New SqlParameter("@Acc_Website", Acc_Website)
            'sqlparams(10) = New SqlParameter("@Acc_TurnOver", Acc_TurnOver)
            'sqlparams(13) = New SqlParameter("@Cust_StoreName", Cust_StoreName)
            'sqlparams(15) = New SqlParameter("@Cust_AList", Cust_AList)
            'sqlparams(16) = New SqlParameter("@Cust_CForm", Cust_CForm)
            'sqlparams(18) = New SqlParameter("@Cust_Vat", Cust_Vat)
            'sqlparams(19) = New SqlParameter("@Cust_Pan", Cust_Pan)
            'sqlparams(20) = New SqlParameter("@Cust_Tin", Cust_Tin)
            'sqlparams(23) = New SqlParameter("@Cust_GST", Cust_GST)
            'sqlparams(24) = New SqlParameter("@Acc_Category", category)
            Return DBBridge.ExecuteScalar("_spMCRM", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '---------By MUBYN and used in MCRMAddAccount and MCRMAddProspect
    Public Shared Function InsertMCRMAccContact(ByVal Contact_ContactPerson As String, ByVal Contact_Designation As Integer, ByVal Contact_Department As Integer,
                                            ByVal Contact_Mobile As String, ByVal Contact_Landline As String, ByVal Contact_Extention As String, ByVal Contact_Email As String,
                                            ByVal Contact_Type As Integer, ByVal Contact_Primary As Boolean, ByVal Contact_ContactType As String,
                                            ByVal Contact_ContactTypeId As Integer, ByVal Contact_CreatedID As String, ByVal Contact_Notifyby As String,
                                            ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(15) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertMCRMAccContact")

            sqlparams(1) = New SqlParameter("@Contact_ContactPerson", Contact_ContactPerson)
            sqlparams(2) = New SqlParameter("@Contact_Designation", Contact_Designation)
            sqlparams(3) = New SqlParameter("@Contact_Department", Contact_Department)

            sqlparams(4) = New SqlParameter("@Contact_Email", Contact_Email)
            sqlparams(5) = New SqlParameter("@Contact_Mobile", Contact_Mobile)
            sqlparams(6) = New SqlParameter("@Contact_Landline", Contact_Landline)
            sqlparams(7) = New SqlParameter("@Contact_Extention", Contact_Extention)
            sqlparams(8) = New SqlParameter("@Contact_CreatedID", Contact_CreatedID)
            sqlparams(9) = New SqlParameter("@Contact_ContactType", Contact_ContactType)
            sqlparams(10) = New SqlParameter("@Contact_ContactTypeId", Contact_ContactTypeId)
            sqlparams(11) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(12) = New SqlParameter("@Contact_Primary", Contact_Primary)
            sqlparams(13) = New SqlParameter("@Contact_Type", Contact_Type)
            sqlparams(14) = New SqlParameter("@Contact_Notifyby", Contact_Notifyby)

            'sqlparams(1) = New SqlParameter("@Contact_Title", Contact_Title)
            'sqlparams(13) = New SqlParameter("@Contact_Gender", Contact_Gender)
            'sqlparams(15) = New SqlParameter("@Contact_DOB", Contact_DOB)
            'sqlparams(16) = New SqlParameter("@Contact_WorkEmail", Contact_WorkEmail)
            'sqlparams(17) = New SqlParameter("@Contact_ProfilePic", Contact_ProfilePic)
            'sqlparams(19) = New SqlParameter("@Contact_Remark", Contact_Remark)
            Return DBBridge.ExecuteNonQuery("_spMCRM", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '---------By MUBYN and used in MCRMAddAccount and MCRMAddProspect 
    Public Shared Function InsertMCRMAccAddr(ByVal AccAddr_AccID As Integer, ByVal AccAddr_Type As String, ByVal AccAddr_Name As String, ByVal AccAddr_Email As String,
                                            ByVal AccAddr_Mobile As String, ByVal AccAddr_Telephone As String, ByVal AccAddr_Address As String,
                                 ByVal AccAddr_City As String, ByVal AccAddr_State As Integer, ByVal AccAddr_Country As Integer, ByVal AccAddr_Pincode As String,
                                            ByVal AccAddr_CreatedId As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(15) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertMCRMAccAddr")
            sqlparams(1) = New SqlParameter("@AccAddr_AccID", AccAddr_AccID)
            sqlparams(2) = New SqlParameter("@AccAddr_Type", AccAddr_Type)
            sqlparams(3) = New SqlParameter("@AccAddr_Name", AccAddr_Name)
            sqlparams(4) = New SqlParameter("@AccAddr_Email", AccAddr_Email)
            sqlparams(5) = New SqlParameter("@AccAddr_Mobile", AccAddr_Mobile)
            sqlparams(6) = New SqlParameter("@AccAddr_Telephone", AccAddr_Telephone)
            sqlparams(8) = New SqlParameter("@AccAddr_Address", AccAddr_Address)
            sqlparams(9) = New SqlParameter("@AccAddr_City", AccAddr_City)
            sqlparams(10) = New SqlParameter("@AccAddr_State", AccAddr_State)
            sqlparams(11) = New SqlParameter("@AccAddr_Country", AccAddr_Country)
            sqlparams(12) = New SqlParameter("@AccAddr_Pincode", AccAddr_Pincode)
            sqlparams(13) = New SqlParameter("@AccAddr_CreatedId", AccAddr_CreatedId)
            sqlparams(14) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)


            Return DBBridge.ExecuteNonQuery("_spMCRM", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
