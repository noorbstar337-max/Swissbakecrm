Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class CompetitorBLL
    Private Shared _spname As String = "_spCompetitor"

    Public Shared Function Insert(ByVal Name As String, ByVal Type As String, ByVal TypeID As Integer, ByVal Amount As String, ByVal Remark As String,
                                  ByVal CreatedID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Competitor_Name", Name)
            sqlparams(2) = New SqlParameter("@Competitor_Type", Type)
            sqlparams(3) = New SqlParameter("@Competitor_TypeID", TypeID)
            sqlparams(4) = New SqlParameter("@Competitor_Amount", Amount)
            sqlparams(5) = New SqlParameter("@Competitor_Remark", Remark)
            sqlparams(6) = New SqlParameter("@Competitor_CreatedID", CreatedID)
            'sqlparams(5) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal Name As String, ByVal Amount As String, ByVal Remark As String, ByVal Website As String,
                                 ByVal Strengths As String, ByVal Weaknesses As String, ByVal ModifiedID As Integer, ByVal AudtTrail_LogId As Integer, ByVal ID As Integer) As Integer
        Dim sqlparams(8) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Competitor_Name", Name)
            sqlparams(2) = New SqlParameter("@Competitor_Amount", Amount)
            sqlparams(3) = New SqlParameter("@Competitor_Remark", Remark)
            sqlparams(4) = New SqlParameter("@Competitor_ModifiedID", ModifiedID)
            sqlparams(5) = New SqlParameter("@Competitor_Website", Website)
            sqlparams(6) = New SqlParameter("@Competitor_Strengths", Strengths)
            sqlparams(7) = New SqlParameter("@Competitor_Weaknesses", Weaknesses)
            sqlparams(8) = New SqlParameter("@Competitor_ID", ID)
            'sqlparams(5) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ViewCompetitorByType(ByVal Type As String, ByVal TypeID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ViewCompetitorByType")
            sqlparams(1) = New SqlParameter("@Competitor_Type", Type)
            sqlparams(2) = New SqlParameter("@Competitor_TypeID", TypeID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
