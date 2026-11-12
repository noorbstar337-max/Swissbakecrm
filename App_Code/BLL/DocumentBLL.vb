Imports APPCODE.DAL

Public Class DocumentBLL
    Private Shared _spname As String = "_spDocument"

    Public Shared Function Insert(ByVal Doc_Path As String, ByVal Doc_Extention As String, ByVal Type As String, ByVal TypeID As Integer, ByVal Doc_Name As String,
                                   ByVal AudtTrail_LogId As Integer, ByVal CreatedID As Integer) As Integer
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Doc_Path", Doc_Path)
            sqlparams(2) = New SqlParameter("@Doc_Extention", Doc_Extention)
            sqlparams(3) = New SqlParameter("@Doc_Type", Type)
            sqlparams(4) = New SqlParameter("@Doc_TypeId", TypeID)
            sqlparams(5) = New SqlParameter("@Doc_Name", Doc_Name)
            sqlparams(6) = New SqlParameter("@Doc_CreatedID", CreatedID)
            sqlparams(7) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal Doc_Name As String, ByVal Doc_Id As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateDocument")
            sqlparams(1) = New SqlParameter("@Doc_Name", Doc_Name)
            sqlparams(2) = New SqlParameter("@Doc_Id", Doc_Id)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DeleteDocument(ByVal Type As String, ByVal TypeID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "DeleteDocument")
            sqlparams(1) = New SqlParameter("@Doc_Type", Type)
            sqlparams(2) = New SqlParameter("@Doc_TypeId", TypeID)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function XMLInsert(ByVal XMLDocument As String, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "XMLInsert")
            sqlparams(1) = New SqlParameter("@XMLDocument", XMLDocument)
            sqlparams(2) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function MaxDocuemntID() As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "MaxDocuemntID")
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillDocument(ByVal Type As String, ByVal TypeID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FillDocument")
            sqlparams(1) = New SqlParameter("@Doc_Type", Type)
            sqlparams(2) = New SqlParameter("@Doc_TypeId", TypeID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

  
    Public Shared Function NewFillDocument(ByVal Type As String, ByVal TypeID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "NewFillDocument")
            sqlparams(1) = New SqlParameter("@Doc_Type", Type)
            sqlparams(2) = New SqlParameter("@Doc_TypeId", TypeID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function NewDeleteDocument(ByVal Type As String, ByVal TypeID As Integer, ByVal AudtTrail_LogId As Integer, ByVal ID As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "NewDeleteDocument")
            sqlparams(1) = New SqlParameter("@Doc_Type", Type)
            sqlparams(2) = New SqlParameter("@Doc_TypeId", TypeID)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(4) = New SqlParameter("@Doc_Id", ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
   
End Class
