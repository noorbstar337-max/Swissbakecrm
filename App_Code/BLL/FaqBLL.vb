Imports APPCODE.DAL

Public Class FaqBLL
    Private Shared _spname As String = "_spInsertFaq"

    Public Shared Function Insert(ByVal FAQ_Question As String, ByVal FAQ_Answer As String, ByVal FAQ_CreatedID As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@FAQ_Question", FAQ_Question)
            sqlparams(2) = New SqlParameter("@FAQ_Answer", FAQ_Answer)
            sqlparams(3) = New SqlParameter("@FAQ_CreatedID", FAQ_CreatedID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal FAQ_Question As String, ByVal FAQ_Answer As String, ByVal FAQ_ModifiedID As Integer, ByVal FAQ_ID As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@FAQ_Question", FAQ_Question)
            sqlparams(2) = New SqlParameter("@FAQ_Answer", FAQ_Answer)
            sqlparams(3) = New SqlParameter("@FAQ_ModifiedID", FAQ_ModifiedID)
            sqlparams(4) = New SqlParameter("@FAQ_ID", FAQ_ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillHomeFaq() As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "HomeFaq")
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
