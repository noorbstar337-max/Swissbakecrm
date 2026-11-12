Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class TrackingBLL
    Private Shared _spname As String = "_spTraking"

    Public Shared Function Insert(ByVal _Tracking_AWB As String, ByVal _Tracking_Date As Date, ByVal _Tracking_Time As DateTime, ByVal _Tracking_CorresponTracking As String, ByVal _Tracking_Activity As String,
     ByVal _Tracking_Location As String, ByVal _Tracking_Maplink As String, ByVal _Tracking_TrackingStatus As String, ByVal _CreatedID As Integer) As Integer
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Tracking_Date", _Tracking_Date)
            sqlparams(2) = New SqlParameter("@Tracking_Time", _Tracking_Time)
            sqlparams(3) = New SqlParameter("@Tracking_CorresponTracking", _Tracking_CorresponTracking)
            sqlparams(4) = New SqlParameter("@Tracking_Activity", _Tracking_Activity)
            sqlparams(5) = New SqlParameter("@Tracking_Location", _Tracking_Location)
            sqlparams(6) = New SqlParameter("@Tracking_Maplink", _Tracking_Maplink)
            sqlparams(7) = New SqlParameter("@N_CreatedID", _CreatedID)
            sqlparams(8) = New SqlParameter("@Tracking_TrackingStatus", _Tracking_TrackingStatus)
            sqlparams(9) = New SqlParameter("@Tracking_AWB", _Tracking_AWB)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal _Tracking_AWB As String, ByVal _Tracking_Date As Date, ByVal _Tracking_Time As String, ByVal _Tracking_CorresponTracking As String, ByVal _Tracking_Activity As String,
    ByVal _Tracking_Location As String, ByVal _Tracking_Maplink As String, ByVal _Tracking_TrackingStatus As String,
    ByVal _ModifiedID As Integer, ByVal _ID As Integer) As Integer
        Dim sqlparams(10) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Tracking_Date", _Tracking_Date)
            sqlparams(2) = New SqlParameter("@Tracking_Time", _Tracking_Time)
            sqlparams(3) = New SqlParameter("@Tracking_CorresponTracking", _Tracking_CorresponTracking)
            sqlparams(4) = New SqlParameter("@Tracking_Activity", _Tracking_Activity)
            sqlparams(5) = New SqlParameter("@Tracking_Location", _Tracking_Location)
            sqlparams(6) = New SqlParameter("@Tracking_Maplink", _Tracking_Maplink)
            sqlparams(7) = New SqlParameter("@Tracking_ModifiedID", _ModifiedID)
            sqlparams(8) = New SqlParameter("@Tracking_TrackingStatus", _Tracking_TrackingStatus)
            sqlparams(9) = New SqlParameter("@Tracking_AWB", _Tracking_AWB)
            sqlparams(10) = New SqlParameter("@Tracking_ID", _ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ViewByID(ByVal ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ViewTrackingByAWB")
            sqlparams(1) = New SqlParameter("@Tracking_AWB", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function LatestTracking(ByVal ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "LatestTracking")
            sqlparams(1) = New SqlParameter("@Tracking_AWB", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DetailTracking(ByVal ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "TrackingDetail")
            sqlparams(1) = New SqlParameter("@Tracking_AWB", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
