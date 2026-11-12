Imports APPCODE.DAL

Public Class CountryBLL
    Private Shared _spname As String = "_spCountry"

    Public Shared Function Insert(ByVal Country_Code As String, ByVal Country_Name As String, ByVal Country_CreatedID As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Country_Code", Country_Code)
            sqlparams(2) = New SqlParameter("@Country_Name", Country_Name)
            sqlparams(3) = New SqlParameter("@Country_CreatedID", Country_CreatedID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal Country_Code As String, ByVal Country_Name As String, ByVal Country_ModifiedID As Integer, ByVal Country_ID As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Country_Code", Country_Code)
            sqlparams(2) = New SqlParameter("@Country_Name", Country_Name)
            sqlparams(3) = New SqlParameter("@Country_ModifiedID", Country_ModifiedID)
            sqlparams(4) = New SqlParameter("@Country_ID", Country_ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ViewCountry(ByVal _Mode As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", _Mode)
            Return DBBridge.ExecuteDataset("_spCountry", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function GetCountryName(ByVal Country_ID As Integer) As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "GetCountryName")
            sqlparams(1) = New SqlParameter("@Country_ID", Country_ID)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
