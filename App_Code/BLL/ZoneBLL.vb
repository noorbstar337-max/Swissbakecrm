Imports APPCODE.DAL

Public Class ZoneBLL
    Private Shared _spname As String = "_spZone"

    Public Shared Function Insert(ByVal Zone_Code As String, ByVal Zone_Name As String, ByVal Zone_CreatedID As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Zone_Code", Zone_Code)
            sqlparams(2) = New SqlParameter("@Zone_Name", Zone_Name)
            sqlparams(3) = New SqlParameter("@Zone_CreatedID", Zone_CreatedID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal Zone_Code As String, ByVal Zone_Name As String, ByVal Zone_ModifiedID As Integer, ByVal Zone_ID As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Zone_Code", Zone_Code)
            sqlparams(2) = New SqlParameter("@Zone_Name", Zone_Name)
            sqlparams(3) = New SqlParameter("@Zone_ModifiedID", Zone_ModifiedID)
            sqlparams(4) = New SqlParameter("@Zone_ID", Zone_ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
