Imports APPCODE.DAL

Public Class LeadBLL
    Private Shared _spname As String = "_spLead"

    Public Shared Function Insert(ByVal Lead_Date As Date, Lead_Name As String, ByVal Lead_IndustryId As Integer, ByVal Lead_Description As String, ByVal Lead_SourceID As Integer,
                                  ByVal Lead_StageID As Integer, ByVal Lead_Reference As String, ByVal Lead_OwnerID As Integer, ByVal Lead_CompanyTypeID As String,
                                  ByVal Lead_LeadTypeID As Integer, ByVal Lead_Website As String, ByVal Lead_CampaignId As Integer, ByVal Lead_TurnOver As String, ByVal Lead_CreatedID As Integer, ByVal AudtTrail_LogId As Integer, ByVal Lead_Category As String) As Integer
        Dim sqlparams(16) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Lead_Date", Lead_Date)
            sqlparams(2) = New SqlParameter("@Lead_Name", Lead_Name)
            sqlparams(3) = New SqlParameter("@Lead_IndustryId", Lead_IndustryId)
            sqlparams(4) = New SqlParameter("@Lead_SourceID", Lead_SourceID)
            sqlparams(5) = New SqlParameter("@Lead_StageID", Lead_StageID)
            sqlparams(6) = New SqlParameter("@Lead_Reference", Lead_Reference)
            sqlparams(7) = New SqlParameter("@Lead_OwnerID", Lead_OwnerID)
            sqlparams(8) = New SqlParameter("@Lead_CompanyTypeID", Lead_CompanyTypeID)
            sqlparams(9) = New SqlParameter("@Lead_LeadTypeID", Lead_LeadTypeID)
            sqlparams(10) = New SqlParameter("@Lead_Website", Lead_Website)
            sqlparams(11) = New SqlParameter("@Lead_CreatedID", Lead_CreatedID)
            sqlparams(12) = New SqlParameter("@Lead_Description", Lead_Description)
            sqlparams(13) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(14) = New SqlParameter("@Lead_CampaignId", Lead_CampaignId)
            sqlparams(15) = New SqlParameter("@Lead_TurnOver", Lead_TurnOver)
            sqlparams(16) = New SqlParameter("@Lead_Category", Lead_Category)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function QuickInsert(ByVal Lead_Date As Date, Lead_Name As String, ByVal Lead_StageID As Integer,
                                       ByVal Lead_OwnerID As Integer, ByVal Lead_CreatedID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(8) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Lead_Date", Lead_Date)
            sqlparams(2) = New SqlParameter("@Lead_Name", Lead_Name)
            sqlparams(3) = New SqlParameter("@Lead_StageID", Lead_StageID)
            sqlparams(4) = New SqlParameter("@Lead_OwnerID", Lead_OwnerID)
            sqlparams(5) = New SqlParameter("@Lead_CreatedID", Lead_CreatedID)
            sqlparams(6) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(7) = New SqlParameter("@Lead_Category", "Domestic")
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function QuickLeadInsert(ByVal Lead_Date As Date, Lead_Name As String, ByVal Lead_StageID As Integer,
                                      ByVal Lead_OwnerID As Integer, ByVal Lead_CreatedID As Integer, ByVal AudtTrail_LogId As Integer, Lead_Category As String, Lead_Description As String) As Integer
        Dim sqlparams(8) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Lead_Date", Lead_Date)
            sqlparams(2) = New SqlParameter("@Lead_Name", Lead_Name)
            sqlparams(3) = New SqlParameter("@Lead_StageID", Lead_StageID)
            sqlparams(4) = New SqlParameter("@Lead_OwnerID", Lead_OwnerID)
            sqlparams(5) = New SqlParameter("@Lead_CreatedID", Lead_CreatedID)
            sqlparams(6) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(7) = New SqlParameter("@Lead_Category", Lead_Category)
            sqlparams(8) = New SqlParameter("@Lead_Description", Lead_Description)

            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal Lead_Date As Date, Lead_Name As String, ByVal Lead_IndustryId As Integer, ByVal Lead_Description As String, ByVal Lead_SourceID As Integer,
                                  ByVal Lead_StageID As Integer, ByVal Lead_Reference As String, ByVal Lead_OwnerID As Integer, ByVal Lead_CompanyTypeID As String,
                                  ByVal Lead_LeadTypeID As Integer, ByVal Lead_Website As String, ByVal Lead_CampaignId As Integer, ByVal Lead_TurnOver As String, ByVal Lead_ModifiedID As Integer, ByVal Lead_Id As Integer, ByVal AudtTrail_LogId As Integer, ByVal Lead_Category As String) As Integer
        Dim sqlparams(17) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Lead_Date", Lead_Date)
            sqlparams(2) = New SqlParameter("@Lead_Name", Lead_Name)
            sqlparams(3) = New SqlParameter("@Lead_IndustryId", Lead_IndustryId)
            sqlparams(4) = New SqlParameter("@Lead_SourceID", Lead_SourceID)
            sqlparams(5) = New SqlParameter("@Lead_StageID", Lead_StageID)
            sqlparams(6) = New SqlParameter("@Lead_Reference", Lead_Reference)
            sqlparams(7) = New SqlParameter("@Lead_OwnerID", Lead_OwnerID)
            sqlparams(8) = New SqlParameter("@Lead_CompanyTypeID", Lead_CompanyTypeID)
            sqlparams(9) = New SqlParameter("@Lead_LeadTypeID", Lead_LeadTypeID)
            sqlparams(10) = New SqlParameter("@Lead_Website", Lead_Website)
            sqlparams(11) = New SqlParameter("@Lead_ModifiedID", Lead_ModifiedID)
            sqlparams(12) = New SqlParameter("@Lead_Id", Lead_Id)
            sqlparams(13) = New SqlParameter("@Lead_Description", Lead_Description)
            sqlparams(14) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(15) = New SqlParameter("@Lead_CampaignId", Lead_CampaignId)
            sqlparams(16) = New SqlParameter("@Lead_TurnOver", Lead_TurnOver)
            sqlparams(17) = New SqlParameter("@Lead_Category", Lead_Category)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillGridView(ByVal PageIndex As Integer, ByVal PageSize As Integer, ByVal ID As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "LeadGridviewByAssign")
            sqlparams(1) = New SqlParameter("@PageIndex", PageIndex)
            sqlparams(2) = New SqlParameter("@PageSize", PageSize)
            sqlparams(3) = New SqlParameter("@Lead_Id", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function LeadSortingByAssign(ByVal ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "LeadSortingByAssign")
            sqlparams(1) = New SqlParameter("@Lead_Id", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function SortingLeadWithNoActivity(ByVal ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "SortingLeadWithNoActivity")
            sqlparams(1) = New SqlParameter("@Lead_Id", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function LeadAchivedSorting(ByVal ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "LeadAchivedSorting")
            sqlparams(1) = New SqlParameter("@Lead_Id", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateLeadStage(ByVal ID As Integer, ByVal StageID As Integer, ByVal Lead_Reason As String) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateLeadStage")
            sqlparams(1) = New SqlParameter("@Lead_Id", ID)
            sqlparams(2) = New SqlParameter("@Lead_StageID", StageID)
            sqlparams(3) = New SqlParameter("@Lead_Reason", Lead_Reason)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateLeadStage(ByVal ID As Integer, ByVal StageID As Integer) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateLeadStage")
            sqlparams(1) = New SqlParameter("@Lead_Id", ID)
            sqlparams(2) = New SqlParameter("@Lead_StageID", StageID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
