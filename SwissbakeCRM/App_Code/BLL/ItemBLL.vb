Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class ItemBLL
    Private Shared _spname As String = "_spItem"

    Public Shared Function DeleteItem(ByVal Type As String, ByVal TypeID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "DeleteItem")
            sqlparams(1) = New SqlParameter("@Item_Type", Type)
            sqlparams(2) = New SqlParameter("@Item_TypeID", TypeID)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function XMLInsert(ByVal XMLDocument As String, ByVal AudtTrail_LogId As Integer, ByVal Type As String) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "XMLInsert")
            sqlparams(1) = New SqlParameter("@XMLItem", XMLDocument)
            sqlparams(2) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(3) = New SqlParameter("@Item_Type", Type)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function MaxItemID() As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "MaxItemID")
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillItemProduct(ByVal Type As String, ByVal TypeID As Integer, ByVal ProductID As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FillItemProduct")
            sqlparams(1) = New SqlParameter("@Item_ProductID", ProductID)
            sqlparams(2) = New SqlParameter("@Item_TypeID", TypeID)
            sqlparams(3) = New SqlParameter("@Item_Type", Type)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ItemProductID(ByVal Type As String, ByVal TypeID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ItemProductID")
            sqlparams(1) = New SqlParameter("@Item_TypeID", TypeID)
            sqlparams(2) = New SqlParameter("@Item_Type", Type)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

  
End Class
