Imports APPCODE.DAL

Public Class TargetCategoryBLL
    Private Shared _spname As String = "_spTargetCategory"

    Public Shared Function Insert(ByVal TargetCategory_Name As String, ByVal TargetCategory_CreatedID As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@TargetCategory_Name", TargetCategory_Name)
            sqlparams(2) = New SqlParameter("@TargetCategory_CreatedID", TargetCategory_CreatedID)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal TargetCategory_Name As String, ByVal TargetCategory_ModifiedID As Integer, ByVal TargetCategory_Id As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(1) = New SqlParameter("@TargetCategory_Name", TargetCategory_Name)
            sqlparams(2) = New SqlParameter("@TargetCategory_ModifiedID", TargetCategory_ModifiedID)
            sqlparams(3) = New SqlParameter("@TargetCategory__Id", TargetCategory_Id)
            sqlparams(4) = New SqlParameter("@Mode", "Update")
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ViewSTCDetailByID(ByVal STCD_MonthName As String, ByVal STCD_TargetID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@STCD_MonthName", STCD_MonthName)
            sqlparams(1) = New SqlParameter("@STCD_TargetID", STCD_TargetID)
            sqlparams(2) = New SqlParameter("@Mode", "ViewSTCDetailByID")
            Return DBBridge.ExecuteDataset("_spSTCD", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function XMLInsert(ByVal XMLSCT As String) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "XMLInsert")
            sqlparams(1) = New SqlParameter("@XMLSCT", XMLSCT)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function TCProductDeleteSi(ByVal TargetCategory__Id As Integer) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "TCProductDeleteSi")
            sqlparams(1) = New SqlParameter("@TargetCategory__Id", TargetCategory__Id)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
