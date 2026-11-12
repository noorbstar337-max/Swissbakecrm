Imports APPCODE.DAL

Public Class UOMBLL
    Private Shared _spname As String = "_spUinitOfMeasurement"

    Public Shared Function Insert(ByVal UOM_Name As String, ByVal UOM_CreatedID As Integer, ByVal AudtTrail_LogId As Integer, ByVal UOM_SequenceNo As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@UOM_Name", UOM_Name)
            sqlparams(2) = New SqlParameter("@UOM_CreatedID", UOM_CreatedID)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(4) = New SqlParameter("@UOM_SequenceNo", UOM_SequenceNo)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal UOM_Name As String, ByVal UOM_ModifiedID As Integer, ByVal UOM_ID As Integer, ByVal AudtTrail_LogId As Integer, ByVal UOM_SequenceNo As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@UOM_Name", UOM_Name)
            sqlparams(2) = New SqlParameter("@UOM_ModifiedID", UOM_ModifiedID)
            sqlparams(3) = New SqlParameter("@UOM_ID", UOM_ID)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(5) = New SqlParameter("@UOM_SequenceNo", UOM_SequenceNo)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
