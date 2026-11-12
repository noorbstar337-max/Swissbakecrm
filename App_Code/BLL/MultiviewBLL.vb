Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class MultivieBLL
    Private Shared _spname As String = "_spmultiview"
    Public Shared Function getChildIdByQId(ByVal Mode As String, ByVal ID As Integer) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ProductID", ID)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'faisal 
    Public Shared Function FillDetailbyID(ByVal Mode As String, ByVal ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@id", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Fillinner(ByVal Mode As String, ByVal id As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)

            sqlparams(1) = New SqlParameter("@id", id)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function getMainID(ByVal Mode As String, ByVal ID As Integer) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@id", ID)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
