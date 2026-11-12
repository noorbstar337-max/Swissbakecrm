Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class CampaignBLL
    Private Shared _spname As String = "_spCampaign"

    Public Shared Function Insert(ByVal Campaign_TypeId As Integer, ByVal Campaign_Name As String, ByVal Campaign_StartDate As Date, ByVal Campaign_EndDate As Date, ByVal Campaign_Invest As Integer, ByVal Campaign_NoOfLead As Integer, ByVal Campaign_Owner As Integer, ByVal Campaign_Remark As String, ByVal Campaign_CreatedID As Integer, ByVal Campaign_ModifiedID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(11) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Campaign_TypeId", Campaign_TypeId)
            sqlparams(2) = New SqlParameter("@Campaign_StartDate", Campaign_StartDate)
            sqlparams(3) = New SqlParameter("@Campaign_EndDate", Campaign_EndDate)
            sqlparams(4) = New SqlParameter("@Campaign_Invest", Campaign_Invest)
            sqlparams(5) = New SqlParameter("@Campaign_NoOfLead", Campaign_NoOfLead)
            sqlparams(6) = New SqlParameter("@Campaign_Owner", Campaign_Owner)
            sqlparams(7) = New SqlParameter("@Campaign_Remark", Campaign_Remark)
            sqlparams(8) = New SqlParameter("@Campaign_CreatedID", Campaign_CreatedID)
            sqlparams(9) = New SqlParameter("@Campaign_ModifiedID", Campaign_ModifiedID)
            sqlparams(10) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(11) = New SqlParameter("@Campaign_Name", Campaign_Name)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function Update(ByVal Campaign_Id As Integer, ByVal Campaign_Name As String, ByVal Campaign_TypeId As Integer, ByVal Campaign_StartDate As Date, ByVal Campaign_EndDate As Date, ByVal Campaign_Invest As Integer, ByVal Campaign_NoOfLead As Integer, ByVal Campaign_Owner As Integer, ByVal Campaign_Remark As String, ByVal Campaign_ModifiedID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(11) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Campaign_TypeId", Campaign_TypeId)
            sqlparams(2) = New SqlParameter("@Campaign_StartDate", Campaign_StartDate)
            sqlparams(3) = New SqlParameter("@Campaign_EndDate", Campaign_EndDate)
            sqlparams(4) = New SqlParameter("@Campaign_Invest", Campaign_Invest)
            sqlparams(5) = New SqlParameter("@Campaign_NoOfLead", Campaign_NoOfLead)
            sqlparams(6) = New SqlParameter("@Campaign_Owner", Campaign_Owner)
            sqlparams(7) = New SqlParameter("@Campaign_Remark", Campaign_Remark)
            sqlparams(8) = New SqlParameter("@Campaign_ModifiedID", Campaign_ModifiedID)
            sqlparams(9) = New SqlParameter("@Campaign_Id", Campaign_Id)
            sqlparams(10) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(11) = New SqlParameter("@Campaign_Name", Campaign_Name)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
