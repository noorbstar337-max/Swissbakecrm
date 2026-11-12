Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class FilterBLL

    Public Shared Function FillNewFilter(ByVal Mode As String, ByVal Id As Integer, ByVal WhereClause As String) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Id", Id)
            sqlparams(2) = New SqlParameter("@WhereClause", WhereClause)
            Return DBBridge.ExecuteDataset("_spFillFilters", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function FillNewFilter2(ByVal Mode As String, ByVal Id As Integer, ByVal WhereClause As String, ByVal WhereClause1 As String) As DataSet
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Id", Id)
            sqlparams(2) = New SqlParameter("@WhereClause", WhereClause)
            sqlparams(3) = New SqlParameter("@WhereClause1", WhereClause1)
            Return DBBridge.ExecuteDataset("_spFillFilters", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
