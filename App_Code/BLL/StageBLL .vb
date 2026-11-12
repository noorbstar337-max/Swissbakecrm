Imports APPCODE.DAL

Public Class StageBLL
    Private Shared _spname As String = "_spStage"
    
    Public Shared Function Insert(ByVal Stage_Name As String, ByVal Stage_OpenClose As String, ByVal Stage_ColorBand As String, ByVal Stage_CreatedID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Stage_Name", Stage_Name)
            sqlparams(2) = New SqlParameter("@Stage_OpenClose", Stage_OpenClose)
            sqlparams(3) = New SqlParameter("@Stage_ColorBand", Stage_ColorBand)
            sqlparams(4) = New SqlParameter("@Stage_CreatedID", Stage_CreatedID)
            sqlparams(5) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal Stage_Name As String, ByVal Stage_OpenClose As String, ByVal Stage_ColorBand As String, ByVal Stage_ModifiedID As Integer, ByVal Stage_Id As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Stage_Name", Stage_Name)
            sqlparams(2) = New SqlParameter("@Stage_OpenClose", Stage_OpenClose)
            sqlparams(3) = New SqlParameter("@Stage_ColorBand", Stage_ColorBand)
            sqlparams(4) = New SqlParameter("@Stage_ModifiedID", Stage_ModifiedID)
            sqlparams(5) = New SqlParameter("@Stage_Id", Stage_Id)
            sqlparams(6) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertOpportunityStage(ByVal Name As String, ByVal OpenClose As String, ByVal ColorBand As String,
                                                  ByVal OppStage_ColorBand As String, ByVal OppStage_Sequence As String, ByVal Stage_CreatedID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertOpportunityStage")
            sqlparams(1) = New SqlParameter("@Stage_Name", Name)
            sqlparams(2) = New SqlParameter("@Stage_OpenClose", OpenClose)
            sqlparams(3) = New SqlParameter("@Stage_ColorBand", ColorBand)
            sqlparams(4) = New SqlParameter("@OppStage_ColorBand", OppStage_ColorBand)
            sqlparams(5) = New SqlParameter("@OppStage_Sequence", OppStage_Sequence)
            sqlparams(6) = New SqlParameter("@Stage_CreatedID", Stage_CreatedID)
            sqlparams(7) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateOpportunityStage(ByVal Stage_Name As String, ByVal Stage_OpenClose As String, ByVal Stage_ColorBand As String,
                                                  ByVal OppStage_ColorBand As String, ByVal OppStage_Sequence As String, ByVal Stage_ModifiedID As Integer, ByVal Stage_Id As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(8) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateOpportunityStage")
            sqlparams(1) = New SqlParameter("@Stage_Name", Stage_Name)
            sqlparams(2) = New SqlParameter("@Stage_OpenClose", Stage_OpenClose)
            sqlparams(3) = New SqlParameter("@Stage_ColorBand", Stage_ColorBand)
            sqlparams(4) = New SqlParameter("@OppStage_ColorBand", OppStage_ColorBand)
            sqlparams(5) = New SqlParameter("@OppStage_Sequence", OppStage_Sequence)
            sqlparams(6) = New SqlParameter("@Stage_ModifiedID", Stage_ModifiedID)
            sqlparams(7) = New SqlParameter("@Stage_Id", Stage_Id)
            sqlparams(8) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
