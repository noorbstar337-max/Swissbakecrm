Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class CustomsReport
    Private Shared _spname As String = "_spCustomReport"

    Public Shared Function Insert(ByVal Name As String, ByVal TableName As String, ByVal Description As String, ByVal SelectedFields As String, ByVal Query As String,
                                          ByVal CreatedID As Integer, ByVal AudtTrail_LogId As Integer, ByVal CustomReport_Type As String) As Integer
        Dim sqlparams(8) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@CustomReport_Name", Name)
            sqlparams(2) = New SqlParameter("@CustomReport_TableName", TableName)
            sqlparams(3) = New SqlParameter("@CustomReport_Description", Description)
            sqlparams(4) = New SqlParameter("@CustomReport_SelectedFields", SelectedFields)
            sqlparams(5) = New SqlParameter("@CustomReport_Query", Query)
            sqlparams(6) = New SqlParameter("@CustomReport_CreatedID", CreatedID)
            sqlparams(7) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(8) = New SqlParameter("@CustomReport_Type", CustomReport_Type)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateReport(ByVal Name As String, ByVal TableName As String, ByVal Description As String, ByVal SelectedFields As String, ByVal Query As String,
                                      ByVal CreatedID As Integer, ByVal CustomReport_Type As String, ByVal CustomReport_Id As Integer) As Integer
        Dim sqlparams(8) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateReport")
            sqlparams(1) = New SqlParameter("@CustomReport_Name", Name)
            sqlparams(2) = New SqlParameter("@CustomReport_TableName", TableName)
            sqlparams(3) = New SqlParameter("@CustomReport_Description", Description)
            sqlparams(4) = New SqlParameter("@CustomReport_SelectedFields", SelectedFields)
            sqlparams(5) = New SqlParameter("@CustomReport_Query", Query)
            sqlparams(6) = New SqlParameter("@CustomReport_CreatedID", CreatedID)
            sqlparams(7) = New SqlParameter("@CustomReport_Type", CustomReport_Type)
            sqlparams(8) = New SqlParameter("@CustomReport_Id", CustomReport_Id)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DeleteReport(ByVal CustomReport_Id As Integer, ByVal Mode As String) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@CustomReport_Id", CustomReport_Id)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function XMLInsert(ByVal XMLAssignTo As String, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "XMLInsert")
            sqlparams(1) = New SqlParameter("@XMLAssignTo", XMLAssignTo)
            sqlparams(2) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function MaxCustomID() As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(1) = New SqlParameter("@Mode", "MaxCustomID")
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ViewColoumName(ByVal TableName As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ViewColoumName")
            sqlparams(1) = New SqlParameter("@CustomReport_TableName", TableName)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ViewReportType(ByVal Type As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ViewReportType")
            sqlparams(1) = New SqlParameter("@CustomReport_Type", Type)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillCustomReport(ByVal _Query As String) As DataTable
        Dim sqlparams(3) As SqlParameter
        Try
            Dim strConnString As String = ConfigurationManager.ConnectionStrings("connectionString").ToString()
            Using sqlConn As New SqlConnection(strConnString)
                sqlConn.Open()
                Dim cmd As SqlCommand = sqlConn.CreateCommand
                Dim sqlDT As New DataTable
                Dim sqlDA As New SqlDataAdapter(_Query, sqlConn)
                sqlDA.Fill(sqlDT)
                Return sqlDT
                sqlConn.Close()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function SearchCustomReport(ByVal _Query As String) As DataTable
        Dim sqlparams(3) As SqlParameter
        Try
            Dim strConnString As String = ConfigurationManager.ConnectionStrings("connectionString").ToString()
            Using sqlConn As New SqlConnection(strConnString)
                sqlConn.Open()
                Dim cmd As SqlCommand = sqlConn.CreateCommand
                Dim sqlDT As New DataTable
                Dim sqlDA As New SqlDataAdapter(_Query, sqlConn)
                sqlDA.Fill(sqlDT)
                Return sqlDT
                sqlConn.Close()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
