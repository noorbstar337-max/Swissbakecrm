Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class SupportBLL
    '==== Created by MUBYN used in SupportDashBoard.aspx 24-07-2018
    Public Shared Function SupportTotalNumberOfComplaint() As DataSet
        Dim sqlparams(0) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "SupportTotalNumberOfComplaint")
            Return DBBridge.ExecuteDataset("_spTotalNumberOfRecord", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '==== Created by MUBYN used in SupportComplaint.aspx 25-07-2018
    Public Shared Function FillGridView(ByVal PageIndex As Integer, ByVal PageSize As Integer, ByVal Mode As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@PageIndex", PageIndex)
            sqlparams(2) = New SqlParameter("@PageSize", PageSize)
            Return DBBridge.ExecuteDataset("_spFillByPaging", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '==== Created by MUBYN used in SupportComplaint.aspx 25-07-2018
    Public Shared Function TotalRowInGridview(ByVal Mode As String) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            Return DBBridge.ExecuteScalar("_spTotalNumberOfRecord", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '==== Created by MUBYN used in SupportComplaint.aspx 25-07-2018
    Public Shared Function SearchGridView(ByVal SearchValue As String, ByVal Mode As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@SearchValue", SearchValue)
            Return DBBridge.ExecuteDataset("_spSearch", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '==== Created by MUBYN used in SupportComplaint.aspx 25-07-2018
    Public Shared Function SortingGridView(ByVal Mode As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            Return DBBridge.ExecuteDataset("_spFillAllRecordForSorting", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '==== Created by MUBYN used in SupportComplaint.aspx 25-07-2018
    Public Shared Function DeleteSI(ByVal ID As Integer, ByVal ModifiedID As Integer, ByVal Mode As String) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)
            sqlparams(2) = New SqlParameter("@ModifiedID", ModifiedID)
            Return DBBridge.ExecuteScalar("_spDeleteSi", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '==== Created by MUBYN used in SupportComplaint.aspx 25-07-2018
    Public Shared Function UpdateStatus(ByVal ID As Integer, ByVal ModifiedID As Integer, ByVal Mode As String) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)
            sqlparams(2) = New SqlParameter("@ModifiedID", ModifiedID)
            Return DBBridge.ExecuteScalar("_spUpdateStatus", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
