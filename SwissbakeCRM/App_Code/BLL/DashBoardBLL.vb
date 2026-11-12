Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class DashBoardBLL

    Private Shared _spname As String = "_spDashboard"

    Public Shared Function ViewById(ByVal Mode As String, ByVal LeadUserID As String, ByVal StartDate As String, ByVal endDate As String) As DataTable
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode.ToString)
            sqlparams(1) = New SqlParameter("@id", LeadUserID)
            sqlparams(2) = New SqlParameter("@StartDate", StartDate)
            sqlparams(3) = New SqlParameter("@endDate", endDate)
            ' sqlparams(2) = New SqlParameter("@Deprt_CreatedID", Deprt_CreatedID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams).Tables(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'Lead_date between @StartDate And @endDate  And 
    Public Shared Function Count(ByVal Mode As String, ByVal LeadUserID As String, ByVal StartDate As String, ByVal endDate As String) As String
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode.ToString)
            sqlparams(1) = New SqlParameter("@id", LeadUserID)
            sqlparams(2) = New SqlParameter("@StartDate", StartDate)
            sqlparams(3) = New SqlParameter("@endDate", endDate)
            ' sqlparams(2) = New SqlParameter("@Deprt_CreatedID", Deprt_CreatedID)
            Return DBBridge.ExecuteScalar("_spDashBoardCount", sqlparams).ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
