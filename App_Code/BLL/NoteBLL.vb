Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class NoteBLL
    Private Shared _spname As String = "_spNote"

    Public Shared Function Insert(ByVal Text As String, ByVal Type As String, ByVal TypeID As Integer,
                                   ByVal AudtTrail_LogId As Integer, ByVal CreatedID As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Note_Text", Text)
            sqlparams(2) = New SqlParameter("@Note_Type", Type)
            sqlparams(3) = New SqlParameter("@Note_TypeID", TypeID)
            sqlparams(4) = New SqlParameter("@Note_CreatedId", CreatedID)
            sqlparams(5) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal Text As String, ByVal Note_Id As Integer, ByVal Note_ModifiedId As Integer, ByVal AudtTrail_LogId As Integer, ByVal Type As String) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Note_Text", Text)
            sqlparams(2) = New SqlParameter("@Note_Id", Note_Id)
            sqlparams(3) = New SqlParameter("@Note_ModifiedId", Note_ModifiedId)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(5) = New SqlParameter("@Note_Type", Type)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function delete(ByVal Note_Id As Integer, ByVal Note_ModifiedId As Integer, ByVal AudtTrail_LogId As Integer, ByVal Type As String) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "NoteDelete")
            sqlparams(1) = New SqlParameter("@Note_Id", Note_Id)
            sqlparams(2) = New SqlParameter("@Note_ModifiedId", Note_ModifiedId)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(4) = New SqlParameter("@Note_Type", Type)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillNoteByType(ByVal Type As String, ByVal TypeID As Integer, ByVal ID As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FillNoteByType")
            sqlparams(1) = New SqlParameter("@Note_Type", Type)
            sqlparams(2) = New SqlParameter("@Note_TypeID", TypeID)
            sqlparams(3) = New SqlParameter("@Note_CreatedId", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function NoteActivityWithAssign(ByVal UserID As Integer, ByVal ID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "NoteActivityWithAssign")
            sqlparams(1) = New SqlParameter("@Note_Id", ID)
            sqlparams(2) = New SqlParameter("@Note_ModifiedId", UserID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function RecentActivity(ByVal ID As Integer, ByVal Note_Type As String, ByVal Note_TypeID As String) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "RecentActivity")
            sqlparams(1) = New SqlParameter("@Note_Id", ID)
            sqlparams(2) = New SqlParameter("@Note_Type", Note_Type)
            sqlparams(3) = New SqlParameter("@Note_TypeID", Note_TypeID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function NoteActivWithAssReverse(ByVal UserID As Integer, ByVal ID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "NoteActivWithAssReverse")
            sqlparams(1) = New SqlParameter("@Note_Id", ID)
            sqlparams(2) = New SqlParameter("@Note_ModifiedId", UserID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ViewNoteQuotation(ByVal UserID As Integer, ByVal ID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ViewNoteQuotation")
            sqlparams(1) = New SqlParameter("@Note_Id", ID)
            sqlparams(2) = New SqlParameter("@Note_ModifiedId", UserID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ViewOpportunityByID(ByVal UserID As Integer, ByVal ID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ViewOpportunityByID")
            sqlparams(1) = New SqlParameter("@Note_Id", ID)
            sqlparams(2) = New SqlParameter("@Note_ModifiedId", UserID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ViewLeadViewByID(ByVal UserID As Integer, ByVal ID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ViewLeadViewByID")
            sqlparams(1) = New SqlParameter("@Note_Id", ID)
            sqlparams(2) = New SqlParameter("@Note_ModifiedId", UserID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
