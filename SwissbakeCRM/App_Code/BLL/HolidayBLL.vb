Imports APPCODE.DAL

Public Class HolidayBLL
    Private Shared _spname As String = "_spHoliday"

    Public Shared Function Insert(ByVal Holiday_Date As String, ByVal Holiday_Discription As String, ByVal Holiday_CreatedID As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Holiday_Date", Holiday_Date)
            sqlparams(2) = New SqlParameter("@Holiday_Discription", Holiday_Discription)
            sqlparams(3) = New SqlParameter("@Holiday_CreatedID", Holiday_CreatedID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal Holiday_Date As String, ByVal Holiday_Discription As String, ByVal Holiday_ModifiedID As Integer, ByVal Holiday_ID As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Holiday_Date", Holiday_Date)
            sqlparams(2) = New SqlParameter("@Holiday_Discription", Holiday_Discription)
            sqlparams(3) = New SqlParameter("@Holiday_ModifiedID", Holiday_ModifiedID)
            sqlparams(4) = New SqlParameter("@Holiday_ID", Holiday_ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function GetHolidays() As DataSet
        Dim sqlparams(0) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "GetHolidays")
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
