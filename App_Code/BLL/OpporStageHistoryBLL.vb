Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class OpporStageHistoryBLL
    Private Shared _spname As String = "_spOpporStageHistory"

    Public Shared Function Insert(ByVal DueDate As Date, ByVal Type As String, ByVal TypeID As Integer, ByVal StageID As Integer,
                                  ByVal AudtTrail_LogId As Integer, ByVal CreatedID As Integer, ByVal Amount As Double) As Integer
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@OpStageHistory_TypeId", TypeID)
            sqlparams(2) = New SqlParameter("@OpStageHistory_Type", Type)
            sqlparams(3) = New SqlParameter("@OpStageHistory_ExpectedDate", DueDate)
            sqlparams(4) = New SqlParameter("@OpStageHistory_StageId", StageID)
            sqlparams(5) = New SqlParameter("@OpStageHistory_Amount", Amount)
            sqlparams(6) = New SqlParameter("@OpStageHistory_CreatedID", CreatedID)
            'sqlparams(7) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ViewStageHistotyByID(ByVal Type As String, ByVal TypeID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ViewStageHistotyByID")
            sqlparams(1) = New SqlParameter("@OpStageHistory_TypeId", TypeID)
            sqlparams(2) = New SqlParameter("@OpStageHistory_Type", Type)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
