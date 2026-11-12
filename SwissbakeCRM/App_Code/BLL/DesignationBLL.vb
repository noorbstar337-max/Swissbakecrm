Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class DesignationBLL
    Private Shared _spname As String = "_spDesignation"


    Public Shared Function Insert(ByVal Desig_Name As String, ByVal Desig_CreatedId As Integer, ByVal Desig_ModifiedId As Integer, ByVal AudtTrail_LogId As Integer, ByVal Desig_Type As String) As Integer
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Desig_Name", Desig_Name)
            sqlparams(2) = New SqlParameter("@Desig_CreatedId", Desig_CreatedId)
            sqlparams(3) = New SqlParameter("@Desig_ModifiedId", Desig_ModifiedId)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(5) = New SqlParameter("@Desig_Type", Desig_Type)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' Add CrmInsert function by nilesh 10-01-2019
    Public Shared Function CrmInsert(ByVal Desig_Name As String, ByVal Desig_CreatedId As Integer, ByVal Desig_ModifiedId As Integer, ByVal AudtTrail_LogId As Integer, ByVal Desig_Type As String) As Integer
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "CrmInsert")
            sqlparams(1) = New SqlParameter("@Desig_Name", Desig_Name)
            sqlparams(2) = New SqlParameter("@Desig_CreatedId", Desig_CreatedId)
            sqlparams(3) = New SqlParameter("@Desig_ModifiedId", Desig_ModifiedId)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(5) = New SqlParameter("@Desig_Type", Desig_Type)

            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal Desig_Name As String, ByVal Desig_ModifiedId As Integer, _ID As Integer, ByVal AudtTrail_LogId As Integer, ByVal Desig_Type As String) As Integer
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Desig_Name", Desig_Name)
            sqlparams(2) = New SqlParameter("@Desig_ModifiedId", Desig_ModifiedId)
            sqlparams(3) = New SqlParameter("@Desig_Id", _ID)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(5) = New SqlParameter("@Desig_Type", Desig_Type)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'added CrmUpdate function by nilesh 10-01-2019
    Public Shared Function CrmUpdate(ByVal Desig_Name As String, ByVal Desig_ModifiedId As Integer, _ID As Integer, ByVal AudtTrail_LogId As Integer, ByVal Desig_Type As String) As Integer
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "CrmUpdate")
            sqlparams(1) = New SqlParameter("@Desig_Name", Desig_Name)
            sqlparams(2) = New SqlParameter("@Desig_ModifiedId", Desig_ModifiedId)
            sqlparams(3) = New SqlParameter("@Desig_Id", _ID)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(5) = New SqlParameter("@Desig_Type", Desig_Type)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
