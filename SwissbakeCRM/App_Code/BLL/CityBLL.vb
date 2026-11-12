Imports APPCODE.DAL

Public Class CityBLL
    Private Shared _spname As String = "_spCity"

    Public Shared Function Insert(ByVal City_Code As String, ByVal City_Name As String, ByVal City_CountryID As Integer, ByVal City_CreatedID As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@City_Code", City_Code)
            sqlparams(2) = New SqlParameter("@City_Name", City_Name)
            sqlparams(3) = New SqlParameter("@City_CountryID", City_CountryID)
            sqlparams(4) = New SqlParameter("@City_CreatedID", City_CreatedID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
	
    Public Shared Function Update(ByVal City_Code As String, ByVal City_Name As String, ByVal City_CountryID As Integer, ByVal City_ModifiedID As Integer, ByVal City_ID As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@City_Code", City_Code)
            sqlparams(2) = New SqlParameter("@City_Name", City_Name)
            sqlparams(3) = New SqlParameter("@City_CountryID", City_CountryID)
            sqlparams(4) = New SqlParameter("@City_ModifiedID", City_ModifiedID)
            sqlparams(5) = New SqlParameter("@City_ID", City_ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
	
    Public Shared Function GetCityName(ByVal City_ID As Integer) As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "GetCityName")
            sqlparams(1) = New SqlParameter("@City_ID", City_ID)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
