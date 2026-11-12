Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class CampaignTypeBLL
    Private Shared _spname As String = "_spCampaignType"


    Public Shared Function Insert(ByVal CampaignType_Name As String, ByVal CampaignType_CreatedID As Integer, ByVal CampaignType_ModifiedID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@CampaignType_Name", CampaignType_Name)
            sqlparams(2) = New SqlParameter("@CampaignType_CreatedID", CampaignType_CreatedID)
            sqlparams(3) = New SqlParameter("@CampaignType_ModifiedID", CampaignType_ModifiedID)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal CampaignType_Name As String, ByVal CampaignType_ModifiedID As Integer, _ID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@CampaignType_Name", CampaignType_Name)
            sqlparams(2) = New SqlParameter("@CampaignType_ModifiedID", CampaignType_ModifiedID)
            sqlparams(3) = New SqlParameter("@CampaignType_Id", _ID)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
