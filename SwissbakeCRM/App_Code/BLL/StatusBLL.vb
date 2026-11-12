Imports APPCODE.DAL

Public Class StatusBLL
    Private Shared _spname As String = "_spStatus"

    Public Shared Function Insert(ByVal Status_Name As String, ByVal Status_Type As String, ByVal Status_CreatedID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Status_Name", Status_Name)
            sqlparams(2) = New SqlParameter("@Status_Type", Status_Type)
            sqlparams(3) = New SqlParameter("@Status_CreatedID", Status_CreatedID)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal Status_Name As String, ByVal Status_Type As String, ByVal Status_ModifiedID As Integer, ByVal Status_ID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Status_Name", Status_Name)
            sqlparams(2) = New SqlParameter("@Status_Type", Status_Type)
            sqlparams(3) = New SqlParameter("@Status_ModifiedID", Status_ModifiedID)
            sqlparams(4) = New SqlParameter("@Status_ID", Status_ID)
            sqlparams(5) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Dropdown(ByVal _Type As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "DropDown")
            sqlparams(1) = New SqlParameter("@Status_Type", _Type)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
