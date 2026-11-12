Imports APPCODE.DAL

Public Class ReviewBLL
    Private Shared _spname As String = "_spReview"

    Public Shared Function Insert(ByVal REV_Rating As Integer, ByVal REV_Review As String, ByVal REV_CreatedID As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@REV_Rating", REV_Rating)
            sqlparams(2) = New SqlParameter("@REV_Review", REV_Review)
            sqlparams(3) = New SqlParameter("@REV_CreatedID", REV_CreatedID)
            sqlparams(4) = New SqlParameter("@REV_MemberID", REV_CreatedID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal REV_Rating As Integer, ByVal REV_Review As String, ByVal REV_ModifiedID As Integer, ByVal REV_ID As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@REV_Rating", REV_Rating)
            sqlparams(2) = New SqlParameter("@REV_Review", REV_Review)
            sqlparams(3) = New SqlParameter("@REV_ModifiedID", REV_ModifiedID)
            sqlparams(4) = New SqlParameter("@REV_ID", REV_ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertSubscription(ByVal S_Email As String) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@S_Email", S_Email)

            Return DBBridge.ExecuteNonQuery("_spSubscription", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
