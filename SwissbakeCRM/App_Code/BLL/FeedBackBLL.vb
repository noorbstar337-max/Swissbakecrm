Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class FeedBackBLL
    Private Shared _spname As String = "_spFeedBack"

    Public Shared Function FillGridByID(ByVal Mode As String, ByVal Rating_AgentId As Integer, ByVal Activity_RelatedTypeID As Integer, ByVal StartDate As String, ByVal EndDate As String) As DataSet
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            If (Rating_AgentId = 0) Then
                sqlparams(1) = New SqlParameter("@Rating_AgentId", DBNull.Value)
            Else
                sqlparams(1) = New SqlParameter("@Rating_AgentId", Rating_AgentId)
            End If
            sqlparams(2) = New SqlParameter("@StartDate", StartDate)
            sqlparams(3) = New SqlParameter("@EndDate", EndDate)
            If (Activity_RelatedTypeID = 0) Then
                sqlparams(4) = New SqlParameter("@Activity_RelatedTypeID", DBNull.Value)
            Else
                sqlparams(4) = New SqlParameter("@Activity_RelatedTypeID", Activity_RelatedTypeID)
            End If
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillReportByID(ByVal Mode As String, ByVal Rating_AgentId As Integer, ByVal Activity_RelatedTypeID As Integer, ByVal StartDate As String,
                                          ByVal EndDate As String, ByVal Id As Integer) As DataSet
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            If (Rating_AgentId = 0) Then
                sqlparams(1) = New SqlParameter("@Rating_AgentId", DBNull.Value)
            Else
                sqlparams(1) = New SqlParameter("@Rating_AgentId", Rating_AgentId)
            End If
            sqlparams(2) = New SqlParameter("@StartDate", StartDate)
            sqlparams(3) = New SqlParameter("@EndDate", EndDate)
            If (Activity_RelatedTypeID = 0) Then
                sqlparams(4) = New SqlParameter("@Activity_RelatedTypeID", DBNull.Value)
            Else
                sqlparams(4) = New SqlParameter("@Activity_RelatedTypeID", Activity_RelatedTypeID)
            End If
            sqlparams(5) = New SqlParameter("@ID", Id)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Dropdown(ByVal Mode As String, ByVal ID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)

            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillGridViewById(ByVal PageIndex As Integer, ByVal PageSize As Integer, ByVal Id As Integer, ByVal Mode As String,
                                            ByVal Rating_AgentId As Integer, ByVal Activity_RelatedTypeID As Integer, ByVal StartDate As String, ByVal EndDate As String) As DataSet
        Dim sqlparams(8) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@PageIndex", PageIndex)
            sqlparams(2) = New SqlParameter("@PageSize", PageSize)
            sqlparams(3) = New SqlParameter("@Id", Id)
            If (Rating_AgentId = 0) Then
                sqlparams(4) = New SqlParameter("@Rating_AgentId", DBNull.Value)
            Else
                sqlparams(4) = New SqlParameter("@Rating_AgentId", Rating_AgentId)
            End If
            sqlparams(5) = New SqlParameter("@StartDate", StartDate)
            sqlparams(6) = New SqlParameter("@EndDate", EndDate)
            If (Activity_RelatedTypeID = 0) Then
                sqlparams(7) = New SqlParameter("@Activity_RelatedTypeID", DBNull.Value)
            Else
                sqlparams(7) = New SqlParameter("@Activity_RelatedTypeID", Activity_RelatedTypeID)
            End If
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
