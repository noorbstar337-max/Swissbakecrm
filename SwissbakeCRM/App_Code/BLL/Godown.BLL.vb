Imports APPCODE.DAL
Imports Microsoft.VisualBasic

Public Class GodownBLL
    Private Shared _spname As String = "_spGodown"
    Public Shared Function Insert(ByVal G_Name As String, ByVal G_Address As String, ByVal G_createID As Integer, ByVal G_createType As String,
                                  ByVal G_CPName As String, ByVal G_CPMobile As String, ByVal G_CPemail As String, ByVal G_Factory As Integer) As Integer
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@G_Name ", G_Name)
            sqlparams(2) = New SqlParameter("@G_Address", G_Address)
            sqlparams(3) = New SqlParameter("@G_createID", G_createID)
            sqlparams(4) = New SqlParameter("@G_createType", G_createType)
            sqlparams(5) = New SqlParameter("@G_CPName", G_CPName)
            sqlparams(6) = New SqlParameter("@G_CPMobile", G_CPMobile)
            sqlparams(7) = New SqlParameter("@G_CPemail", G_CPemail)
            sqlparams(8) = New SqlParameter("@G_Factory", G_Factory)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function Update(ByVal G_Name As String, ByVal G_Address As String, ByVal G_ModifiedID As Integer, ByVal G_ModifiedType As String, ByVal G_ID As Integer,
                                  ByVal G_CPName As String, ByVal G_CPMobile As String, ByVal G_CPemail As String, ByVal G_Factory As Integer) As Integer
        Dim sqlparams(10) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@G_ID ", G_ID)
            sqlparams(2) = New SqlParameter("@G_Name ", G_Name)
            sqlparams(3) = New SqlParameter("@G_Address", G_Address)
            sqlparams(4) = New SqlParameter("@G_ModifiedID", G_ModifiedID)
            sqlparams(5) = New SqlParameter("@G_ModifiedType", G_ModifiedType)
            sqlparams(6) = New SqlParameter("@G_CPName", G_CPName)
            sqlparams(7) = New SqlParameter("@G_CPMobile", G_CPMobile)
            sqlparams(8) = New SqlParameter("@G_CPemail", G_CPemail)
            sqlparams(9) = New SqlParameter("@G_Factory", G_Factory)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function GetGodwonById(ByVal G_ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "GetGodwonById")
            sqlparams(1) = New SqlParameter("@G_ID", G_ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function




End Class
