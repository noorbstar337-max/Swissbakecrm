Imports APPCODE.DAL

Public Class LeadContactBLL
    Private Shared _spname As String = "_spLeadContact"

	Public Shared Function Insert(ByVal LeadContact_Title As String, ByVal LeadContact_Name As String, ByVal LeadContact_DesigId As Integer,
								  ByVal LeadContact_Email As String, ByVal LeadContact_MobileNo As String, ByVal LeadContact_OfficeNo As String,
								  ByVal LeadContact_Extention As String, ByVal LeadContact_CreatedID As String,
								  ByVal LeadContact_LeadID As Integer, ByVal AudtTrail_LogId As Integer, ByVal PrimaryContact As Boolean, ByVal LeadContact_Notifyby As String) As Integer
		Dim sqlparams(13) As SqlParameter
		Try
			sqlparams(0) = New SqlParameter("@Mode", "Insert")
			sqlparams(1) = New SqlParameter("@LeadContact_Title", LeadContact_Title)
			sqlparams(2) = New SqlParameter("@LeadContact_Name", LeadContact_Name)
			sqlparams(3) = New SqlParameter("@LeadContact_DesigId", LeadContact_DesigId)
			sqlparams(4) = New SqlParameter("@LeadContact_Email", LeadContact_Email)
			sqlparams(5) = New SqlParameter("@LeadContact_MobileNo", LeadContact_MobileNo)
			sqlparams(6) = New SqlParameter("@LeadContact_OfficeNo", LeadContact_OfficeNo)
			sqlparams(7) = New SqlParameter("@LeadContact_Extention", LeadContact_Extention)
			sqlparams(8) = New SqlParameter("@LeadContact_CreatedID", LeadContact_CreatedID)
			sqlparams(9) = New SqlParameter("@LeadContact_LeadID", LeadContact_LeadID)
			sqlparams(10) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
			sqlparams(11) = New SqlParameter("@LeadContact_Primary", PrimaryContact)
			sqlparams(12) = New SqlParameter("@LeadContact_Notifyby", LeadContact_Notifyby)
			Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
    '-- Paramters increased check below QuickInsert1
	Public Shared Function QuickInsert(ByVal LeadContact_Name As String, ByVal LeadContact_Email As String, ByVal LeadContact_MobileNo As String, ByVal LeadContact_OfficeNo As String,
								  ByVal LeadContact_Extention As String, ByVal LeadContact_CreatedID As String, ByVal LeadContact_LeadID As Integer,
								  ByVal AudtTrail_LogId As Integer, ByVal PrimaryContact As Boolean, ByVal LeadContact_Notifyby As String) As Integer
		Dim sqlparams(12) As SqlParameter
		Try
			sqlparams(0) = New SqlParameter("@Mode", "Insert")
			sqlparams(1) = New SqlParameter("@LeadContact_Name", LeadContact_Name)
			sqlparams(2) = New SqlParameter("@LeadContact_Email", LeadContact_Email)
			sqlparams(3) = New SqlParameter("@LeadContact_MobileNo", LeadContact_MobileNo)
			sqlparams(4) = New SqlParameter("@LeadContact_OfficeNo", LeadContact_OfficeNo)
			sqlparams(5) = New SqlParameter("@LeadContact_Extention", LeadContact_Extention)
			sqlparams(6) = New SqlParameter("@LeadContact_CreatedID", LeadContact_CreatedID)
			sqlparams(7) = New SqlParameter("@LeadContact_LeadID", LeadContact_LeadID)
			sqlparams(8) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
			sqlparams(9) = New SqlParameter("@LeadContact_Primary", PrimaryContact)
			sqlparams(10) = New SqlParameter("@LeadContact_DesigId", 0)
			sqlparams(11) = New SqlParameter("@LeadContact_Notifyby", LeadContact_Notifyby)
			Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
		Catch ex As Exception
			Throw ex
		End Try
    End Function
    'use this function on view lead page --Modified by Nilesh
    Public Shared Function QuickInsert1(ByVal LeadContact_Name As String, ByVal LeadContact_Email As String, ByVal LeadContact_MobileNo As String, ByVal LeadContact_OfficeNo As String,
                                  ByVal LeadContact_Extention As String, ByVal LeadContact_CreatedID As String, ByVal LeadContact_LeadID As Integer,
                                  ByVal AudtTrail_LogId As Integer, ByVal PrimaryContact As Boolean, ByVal LeadContact_DesigId As Integer, ByVal LeadContact_Notifyby As String) As Integer
        Dim sqlparams(12) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@LeadContact_Name", LeadContact_Name)
            sqlparams(2) = New SqlParameter("@LeadContact_Email", LeadContact_Email)
            sqlparams(3) = New SqlParameter("@LeadContact_MobileNo", LeadContact_MobileNo)
            sqlparams(4) = New SqlParameter("@LeadContact_OfficeNo", LeadContact_OfficeNo)
            sqlparams(5) = New SqlParameter("@LeadContact_Extention", LeadContact_Extention)
            sqlparams(6) = New SqlParameter("@LeadContact_CreatedID", LeadContact_CreatedID)
            sqlparams(7) = New SqlParameter("@LeadContact_LeadID", LeadContact_LeadID)
            sqlparams(8) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(9) = New SqlParameter("@LeadContact_Primary", PrimaryContact)
            'sqlparams(10) = New SqlParameter("@LeadContact_DesigId", LeadContact_DesigId)
            sqlparams(10) = New SqlParameter("@LeadContact_DesigId", LeadContact_DesigId)
            sqlparams(11) = New SqlParameter("@LeadContact_Notifyby", LeadContact_Notifyby)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

	Public Shared Function Update(ByVal LeadContact_Title As String, ByVal LeadContact_Name As String, ByVal LeadContact_DesigId As Integer,
								  ByVal LeadContact_Email As String, ByVal LeadContact_MobileNo As String, ByVal LeadContact_OfficeNo As String,
								  ByVal LeadContact_Extention As String, ByVal LeadContact_ModifiedID As Integer, ByVal LeadContact_LeadId As Integer, ByVal AudtTrail_LogId As Integer,
								  ByVal LeadContact_Notifyby As String) As Integer
		Dim sqlparams(12) As SqlParameter
		Try
			sqlparams(0) = New SqlParameter("@Mode", "Update")
			sqlparams(1) = New SqlParameter("@LeadContact_Title", LeadContact_Title)
			sqlparams(2) = New SqlParameter("@LeadContact_Name", LeadContact_Name)
			sqlparams(3) = New SqlParameter("@LeadContact_DesigId", LeadContact_DesigId)
			sqlparams(4) = New SqlParameter("@LeadContact_Email", LeadContact_Email)
			sqlparams(5) = New SqlParameter("@LeadContact_MobileNo", LeadContact_MobileNo)
			sqlparams(6) = New SqlParameter("@LeadContact_OfficeNo", LeadContact_OfficeNo)
			sqlparams(7) = New SqlParameter("@LeadContact_Extention", LeadContact_Extention)
			sqlparams(8) = New SqlParameter("@LeadContact_ModifiedID", LeadContact_ModifiedID)
			sqlparams(9) = New SqlParameter("@LeadContact_LeadId", LeadContact_LeadId)
			sqlparams(10) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
			sqlparams(11) = New SqlParameter("@LeadContact_Notifyby", LeadContact_Notifyby)
			Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Shared Function UpdatePrimaryContact(ByVal LeadContactID As Integer, ByVal LeadContact_ModifiedID As Integer, ByVal LeadContact_LeadId As Integer,
                                                ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdatePrimaryContact")
            sqlparams(1) = New SqlParameter("@LeadContact_Id", LeadContactID)
            sqlparams(2) = New SqlParameter("@LeadContact_ModifiedID", LeadContact_ModifiedID)
            sqlparams(3) = New SqlParameter("@LeadContact_LeadId", LeadContact_LeadId)
            sqlparams(4) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
