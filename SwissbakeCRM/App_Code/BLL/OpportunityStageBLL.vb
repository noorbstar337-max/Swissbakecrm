Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class OpportunityStageBLL
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
End Class
