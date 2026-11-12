Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class OpportunityBLL
    Private Shared _spname As String = "_spOpportunity"

    Public Shared Function Insert(ByVal Owner As Integer, ByVal Name As String, ByVal NextType As String, ByVal Desc As String, ByVal DueDate As Date, ByVal SourceId As Integer, ByVal SourceType As String,
             ByVal Type As String, ByVal TypeID As Integer, ByVal StageID As Integer, ByVal AudtTrail_LogId As Integer, ByVal CreatedID As Integer, ByVal Amount As Double) As Integer
        Dim sqlparams(12) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Opportunity_TypeId", TypeID)
            sqlparams(2) = New SqlParameter("@Opportunity_Name", Name)
            sqlparams(3) = New SqlParameter("@Opportunity_Type", Type)
            sqlparams(4) = New SqlParameter("@Opportunity_ExpectedDate", DueDate)
            sqlparams(5) = New SqlParameter("@Opportunity_StageId", StageID)
            sqlparams(6) = New SqlParameter("@Opportunity_NextType", NextType)
            sqlparams(7) = New SqlParameter("@Opportunity_CreatedID", CreatedID)
            'sqlparams(7) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(8) = New SqlParameter("@Opportunity_SourceId", SourceId)
            sqlparams(9) = New SqlParameter("@Opportunity_SourceType", SourceType)
            sqlparams(10) = New SqlParameter("@Opportunity_Desc", Desc)
            sqlparams(11) = New SqlParameter("@Opportunity_Owner", Owner)
            sqlparams(12) = New SqlParameter("@Opportunity_Amount", Amount)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function OpportunitySortingByAssign(ByVal ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "OpportunitySortingByAssign")
            sqlparams(1) = New SqlParameter("@Opportunity_Id", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal Owner As Integer, ByVal Name As String, ByVal NextType As String, ByVal Desc As String, ByVal DueDate As Date, ByVal SourceId As Integer, ByVal SourceType As String,
            ByVal Type As String, ByVal TypeID As Integer, ByVal StageID As Integer, ByVal AudtTrail_LogId As Integer, ByVal ModifiedID As Integer, ByVal ID As Integer, ByVal Amount As Double) As Integer
        Dim sqlparams(13) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Opportunity_TypeId", TypeID)
            sqlparams(2) = New SqlParameter("@Opportunity_Name", Name)
            sqlparams(3) = New SqlParameter("@Opportunity_Type", Type)
            sqlparams(4) = New SqlParameter("@Opportunity_ExpectedDate", DueDate)
            sqlparams(5) = New SqlParameter("@Opportunity_StageId", StageID)
            sqlparams(6) = New SqlParameter("@Opportunity_NextType", NextType)
            sqlparams(7) = New SqlParameter("@Opportunity_ModifiedID", ModifiedID)
            'sqlparams(7) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(8) = New SqlParameter("@Opportunity_SourceId", SourceId)
            sqlparams(9) = New SqlParameter("@Opportunity_SourceType", SourceType)
            sqlparams(10) = New SqlParameter("@Opportunity_Desc", Desc)
            sqlparams(11) = New SqlParameter("@Opportunity_Owner", Owner)
            sqlparams(12) = New SqlParameter("@Opportunity_Id", ID)
            sqlparams(13) = New SqlParameter("@Opportunity_Amount", Amount)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function XMLItemDtInsert(ByVal XMLAssignTo As String) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "XMLItemDtInsert")
            sqlparams(1) = New SqlParameter("@XMLAssignTo", XMLAssignTo)
            'sqlparams(2) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            'sqlparams(3) = New SqlParameter("@Assignto_Type", Type)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function GetProbability(ByVal ID As Integer) As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "GetProbability")
            sqlparams(1) = New SqlParameter("@Opportunity_StageId", ID)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ViewOpportunityByAssignType(ByVal Type As String, ByVal TypeID As Integer, ByVal ID As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ViewOppByAssignType")
            sqlparams(1) = New SqlParameter("@Opportunity_TypeId", TypeID)
            sqlparams(2) = New SqlParameter("@Opportunity_Type", Type)
            sqlparams(3) = New SqlParameter("@Opportunity_Id", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
