Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class SalesTargetBLL
    Private Shared _spname As String = "_spSalesTarget"
    Public Shared Function DeleteSalesTargetDetail(ByVal ID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "DeleteSalesTargetDetail")
            sqlparams(1) = New SqlParameter("@SalesTarget_Id", ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function XMLInsert(ByVal XMLAssignTo As String, ByVal AudtTrail_LogId As Integer, ByVal XMLSCT As String) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "XMLInsert")
            sqlparams(1) = New SqlParameter("@XMLAssignTo", XMLAssignTo)
            sqlparams(2) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(3) = New SqlParameter("@XMLSCT", XMLSCT)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    

    Public Shared Function MaxSalesTargetDt() As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "MaxSalesTargetDt")
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Insert(ByVal YearID As Integer, ByVal userID As Integer, ByVal CreatedID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@SalesTarget_YearID", YearID)
            sqlparams(2) = New SqlParameter("@SalesTarget_userID", userID)
            sqlparams(3) = New SqlParameter("@SalesTarget_CreatedId", CreatedID)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function NewSalesTargetDetail(ByVal SalesTarget_userID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "NewSalesTargetDetail")
            sqlparams(1) = New SqlParameter("@SalesTarget_userID", SalesTarget_userID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function SalesAchievedIndividual(ByVal Id As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "SalesAchievedIndividual")
            sqlparams(1) = New SqlParameter("@SalesTarget_userID", Id)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function SalesAchievedTeam(ByVal Id As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "SalesAchievedTeam")
            sqlparams(1) = New SqlParameter("@SalesTarget_userID", Id)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
