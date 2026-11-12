Imports APPCODE.DAL

Public Class CounterBLL
    Private Shared _spname As String = "_spCounter"

    Public Shared Function Insert(ByVal Counter_Name As String, ByVal Counter_Value As Integer, ByVal Counter_Icon As String, ByVal Counter_CreatedID As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Counter_Name", Counter_Name)
            sqlparams(2) = New SqlParameter("@Counter_Value", Counter_Value)
            sqlparams(3) = New SqlParameter("@Counter_Icon", Counter_Icon)
            sqlparams(4) = New SqlParameter("@Counter_CreatedID", Counter_CreatedID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal Counter_Name As String, ByVal Counter_Value As Integer, ByVal Counter_Icon As String, ByVal Counter_ModifiedID As Integer, ByVal Counter_ID As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Counter_Name", Counter_Name)
            sqlparams(2) = New SqlParameter("@Counter_Value", Counter_Value)
            sqlparams(3) = New SqlParameter("@Counter_Icon", Counter_Icon)
            sqlparams(4) = New SqlParameter("@Counter_ModifiedID", Counter_ModifiedID)
            sqlparams(5) = New SqlParameter("@Counter_ID", Counter_ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function Counter() As DataSet
        Dim sqlparams(0) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Counter")
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
