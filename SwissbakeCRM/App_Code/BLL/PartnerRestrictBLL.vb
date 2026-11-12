Imports APPCODE.DAL

Public Class PartnerRestrictBLL
    Private Shared _spname As String = "_spPartnerRest"

    Public Shared Function Insert(ByVal PTR_PartnerID As Integer, ByVal PTR_Restriction As String, ByVal PTR_CreatedID As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@PTR_PartnerID", PTR_PartnerID)
            sqlparams(2) = New SqlParameter("@PTR_Restriction", PTR_Restriction)
            sqlparams(3) = New SqlParameter("@PTR_CreatedID", PTR_CreatedID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal PTR_PartnerID As Integer, ByVal PTR_Restriction As String, ByVal PTR_ModifiedID As Integer, ByVal PTR_ID As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@PTR_PartnerID", PTR_PartnerID)
            sqlparams(2) = New SqlParameter("@PTR_Restriction", PTR_Restriction)
            sqlparams(3) = New SqlParameter("@PTR_ModifiedID", PTR_ModifiedID)
            sqlparams(4) = New SqlParameter("@PTR_ID", PTR_ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
