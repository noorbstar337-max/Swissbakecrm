Imports APPCODE.DAL

Public Class RawmaterialBLL
    Private Shared _spname As String = "_spRawmaterial"
	'=================GAYATRI added Rm_Type on 27-07-2017===========
	Public Shared Function Insert(ByVal Rm_Name As String, ByVal Rm_Desc As String, ByVal Rm_Brand As String, ByVal Rm_CreatedID As Integer, ByVal AudtTrail_LogId As Integer,
								  ByVal Rm_Code As String, ByVal Rm_Type As String, ByVal Rm_Stock As String, ByVal Rm_GenericName As String) As Integer
		Dim sqlparams(10) As SqlParameter
		Try
			sqlparams(0) = New SqlParameter("@Mode", "Insert")
			sqlparams(1) = New SqlParameter("@Rm_Name", Rm_Name)
			sqlparams(2) = New SqlParameter("@Rm_Desc", Rm_Desc)
			sqlparams(3) = New SqlParameter("@Rm_Brand", Rm_Brand)
			sqlparams(4) = New SqlParameter("@Rm_CreatedID", Rm_CreatedID)
			sqlparams(5) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
			sqlparams(6) = New SqlParameter("@Rm_Code", Rm_Code)
			sqlparams(7) = New SqlParameter("@Rm_Type", Rm_Type)
			sqlparams(8) = New SqlParameter("@Rm_Stock", Rm_Stock)
			sqlparams(9) = New SqlParameter("@Rm_GenericName", Rm_GenericName)
			Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	'=================GAYATRI added Rm_Type on 27-07-2017===========
	Public Shared Function Update(ByVal Rm_Name As String, ByVal Rm_Desc As String, ByVal Rm_Brand As String, ByVal Rm_ModifiedID As Integer, ByVal Rawmaterial_Id As Integer, ByVal AudtTrail_LogId As Integer,
								   ByVal Rm_Code As String, ByVal Rm_Type As String, ByVal Rm_Stock As String, ByVal Rm_GenericName As String) As Integer
		Dim sqlparams(11) As SqlParameter
		Try
			sqlparams(0) = New SqlParameter("@Mode", "Update")
			sqlparams(1) = New SqlParameter("@Rm_Name", Rm_Name)
			sqlparams(2) = New SqlParameter("@Rm_Desc", Rm_Desc)
			sqlparams(3) = New SqlParameter("@Rm_Brand", Rm_Brand)
			sqlparams(4) = New SqlParameter("@Rm_ModifiedID", Rm_ModifiedID)
			sqlparams(5) = New SqlParameter("@Rm_ID", Rawmaterial_Id)
			sqlparams(6) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
			sqlparams(7) = New SqlParameter("@Rm_Code", Rm_Code)
			sqlparams(8) = New SqlParameter("@Rm_Type", Rm_Type)
			sqlparams(9) = New SqlParameter("@Rm_Stock", Rm_Stock)
			sqlparams(10) = New SqlParameter("@Rm_GenericName", Rm_GenericName)
			Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Shared Function ViewRawmaterial(ByVal MainID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ViewRawmaterial")
            sqlparams(1) = New SqlParameter("@Rm_ID", MainID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function ViewSaveRawmaterial(ByVal MainID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ViewSaveRawmaterial")
            sqlparams(1) = New SqlParameter("@Rm_ID", MainID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function SearchRawmaterial(ByVal MainID As Integer, ByVal value As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "SearchRawmaterial")
            sqlparams(1) = New SqlParameter("@Rm_ID", MainID)
            sqlparams(2) = New SqlParameter("@val", value)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function Delete(ByVal Id As Integer) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Delete")
            sqlparams(1) = New SqlParameter("@Rm_ID", Id)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function UpdatevenProd(ByVal VP_RefName As String, ByVal id As Integer) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdatevenProd")
            sqlparams(1) = New SqlParameter("@Rm_ID", id)
            sqlparams(2) = New SqlParameter("@VP_RefName", VP_RefName)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
