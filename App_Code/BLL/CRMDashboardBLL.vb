Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class CRMDashboardBLL

    Public Shared Function TotalRowInGridview(ByVal Mode As String, ByVal ID As String) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)
            Return DBBridge.ExecuteScalar("_spCRMDashboard", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function IndexCount(ByVal Mode As String, ByVal ID As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)
            Return DBBridge.ExecuteDataset("_spCRMDashboard", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'reportby user
    Public Shared Function ReportbyUser(ByVal Mode As String, ByVal id As Integer, ByVal StartDate As String, ByVal endDate As String) As String
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@id", id)
            sqlparams(2) = New SqlParameter("@StartDate", StartDate)
            sqlparams(3) = New SqlParameter("@endDate", endDate)
            ' sqlparams(2) = New SqlParameter("@Deprt_CreatedID", Deprt_CreatedID)
            Return DBBridge.ExecuteScalar("_spCRMDashboard", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function perReportbyUser(ByVal Mode As String, ByVal id As Integer, ByVal StartDate As String, ByVal endDate As String) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@id", id)
            sqlparams(2) = New SqlParameter("@StartDate", StartDate)
            sqlparams(3) = New SqlParameter("@endDate", endDate)
            ' sqlparams(2) = New SqlParameter("@Deprt_CreatedID", Deprt_CreatedID)
            Return DBBridge.ExecuteDataset("_spCRMDashboard", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function MonthlyReport(ByVal Mode As String, ByVal id As Integer, ByVal StartDate As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", id)
            sqlparams(2) = New SqlParameter("@date", StartDate)
            Return DBBridge.ExecuteDataset("_spMontlyReport", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
