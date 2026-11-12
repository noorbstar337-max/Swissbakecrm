Imports APPCODE.DAL

Public Class SubCategoryBLL
    Private Shared _spname As String = "_spSubCategory"


    Public Shared Function Insert(ByVal Category_Name As String, ByVal Category_ParentID As Integer, ByVal Category_UrlType As String, ByVal AudtTrail_LogId As Integer, ByVal Category_CreatedID As Integer, ByVal Category_SequenceNo As Integer) As Integer
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Category_Name", Category_Name)
            sqlparams(2) = New SqlParameter("@Category_ParentID", Category_ParentID)
            sqlparams(3) = New SqlParameter("@Category_UrlType", Category_UrlType)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(5) = New SqlParameter("@Category_CreatedID", Category_CreatedID)
            sqlparams(6) = New SqlParameter("@Category_SequenceNo", Category_SequenceNo)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function




    Public Shared Function Update(ByVal Category_Name As String, ByVal Category_ParentID As Integer, ByVal Category_UrlType As String, ByVal AudtTrail_LogId As Integer, ByVal Category_ModifiedID As Integer, ByVal Category_Id As Integer, ByVal Category_SequenceNo As Integer) As Integer
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Category_Name", Category_Name)
            sqlparams(2) = New SqlParameter("@Category_ParentID", Category_ParentID)
            sqlparams(3) = New SqlParameter("@Category_UrlType", Category_UrlType)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(5) = New SqlParameter("@Category_ModifiedID", Category_ModifiedID)
            sqlparams(6) = New SqlParameter("@Category_Id", Category_Id)
            sqlparams(7) = New SqlParameter("@Category_SequenceNo", Category_SequenceNo)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertParent(ByVal Category_Name As String, ByVal Category_UrlType As String, ByVal AudtTrail_LogId As String, ByVal Category_CreatedID As Integer, ByVal Category_SequenceNo As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertParent")
            sqlparams(1) = New SqlParameter("@Category_Name", Category_Name)
            sqlparams(2) = New SqlParameter("@Category_UrlType", Category_UrlType)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(4) = New SqlParameter("@Category_CreatedID", Category_CreatedID)
            sqlparams(5) = New SqlParameter("@Category_SequenceNo", Category_SequenceNo)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
