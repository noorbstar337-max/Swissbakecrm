Imports APPCODE.DAL

Public Class ProspectContactBLL
    Private Shared _spname As String = "_spAccountContact"

	Public Shared Function Insert(ByVal Contact_Title As String, ByVal Contact_ContactPerson As String, ByVal Contact_Designation As Integer,
								  ByVal Contact_Email As String, ByVal Contact_Mobile As String, ByVal Contact_Landline As String,
								  ByVal Contact_Extention As String, ByVal Contact_CreatedID As String, ByVal Contact_ContactType As String,
								  ByVal Contact_ContactTypeId As Integer, ByVal AudtTrail_LogId As Integer, ByVal Contact_Primary As Boolean,
								  ByVal Contact_Gender As String, ByVal Contact_Department As Integer, ByVal Contact_DOB As Date,
								  ByVal Contact_WorkEmail As String, ByVal Contact_ProfilePic As String, ByVal Contact_Type As Integer, ByVal Contact_Remark As String, ByVal Contact_Notifyby As String) As Integer
		Dim sqlparams(21) As SqlParameter
		Try
			sqlparams(0) = New SqlParameter("@Mode", "Insert")
			sqlparams(1) = New SqlParameter("@Contact_Title", Contact_Title)
			sqlparams(2) = New SqlParameter("@Contact_ContactPerson", Contact_ContactPerson)
			sqlparams(3) = New SqlParameter("@Contact_Designation", Contact_Designation)
			sqlparams(4) = New SqlParameter("@Contact_Email", Contact_Email)
			sqlparams(5) = New SqlParameter("@Contact_Mobile", Contact_Mobile)
			sqlparams(6) = New SqlParameter("@Contact_Landline", Contact_Landline)
			sqlparams(7) = New SqlParameter("@Contact_Extention", Contact_Extention)
			sqlparams(8) = New SqlParameter("@Contact_CreatedID", Contact_CreatedID)
			sqlparams(9) = New SqlParameter("@Contact_ContactType", Contact_ContactType)
			sqlparams(10) = New SqlParameter("@Contact_ContactTypeId", Contact_ContactTypeId)
			sqlparams(11) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
			sqlparams(12) = New SqlParameter("@Contact_Primary", Contact_Primary)
			sqlparams(13) = New SqlParameter("@Contact_Gender", Contact_Gender)
			sqlparams(14) = New SqlParameter("@Contact_Department", Contact_Department)
			sqlparams(15) = New SqlParameter("@Contact_DOB", Contact_DOB)
			sqlparams(16) = New SqlParameter("@Contact_WorkEmail", Contact_WorkEmail)
			sqlparams(17) = New SqlParameter("@Contact_ProfilePic", Contact_ProfilePic)
			sqlparams(18) = New SqlParameter("@Contact_Type", Contact_Type)
			sqlparams(19) = New SqlParameter("@Contact_Remark", Contact_Remark)
			sqlparams(20) = New SqlParameter("@Contact_Notifyby", Contact_Notifyby)
			Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


	Public Shared Function Update(ByVal Contact_Title As String, ByVal Contact_ContactPerson As String, ByVal Contact_Designation As Integer,
								  ByVal Contact_Email As String, ByVal Contact_Mobile As String, ByVal Contact_Landline As String,
								  ByVal Contact_Extention As String, ByVal Contact_ModifiedID As String, ByVal Contact_ContactType As String,
								  ByVal Contact_ContactTypeId As Integer, ByVal AudtTrail_LogId As Integer, ByVal Contact_Primary As Boolean,
								  ByVal Contact_Gender As String, ByVal Contact_Department As Integer, ByVal Contact_DOB As Date,
								  ByVal Contact_WorkEmail As String, ByVal Contact_ProfilePic As String, ByVal Contact_Type As Integer,
								  ByVal Contact_Remark As String, ByVal Contact_Id As Integer, ByVal Contact_Notifyby As String) As Integer
		Dim sqlparams(22) As SqlParameter
		Try
			sqlparams(0) = New SqlParameter("@Mode", "Update")
			sqlparams(1) = New SqlParameter("@Contact_Title", Contact_Title)
			sqlparams(2) = New SqlParameter("@Contact_ContactPerson", Contact_ContactPerson)
			sqlparams(3) = New SqlParameter("@Contact_Designation", Contact_Designation)
			sqlparams(4) = New SqlParameter("@Contact_Email", Contact_Email)
			sqlparams(5) = New SqlParameter("@Contact_Mobile", Contact_Mobile)
			sqlparams(6) = New SqlParameter("@Contact_Landline", Contact_Landline)
			sqlparams(7) = New SqlParameter("@Contact_Extention", Contact_Extention)
			sqlparams(8) = New SqlParameter("@Contact_ModifiedID", Contact_ModifiedID)
			sqlparams(9) = New SqlParameter("@Contact_ContactType", Contact_ContactType)
			sqlparams(10) = New SqlParameter("@Contact_ContactTypeId", Contact_ContactTypeId)
			sqlparams(11) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
			sqlparams(12) = New SqlParameter("@Contact_Primary", Contact_Primary)
			sqlparams(13) = New SqlParameter("@Contact_Gender", Contact_Gender)
			sqlparams(14) = New SqlParameter("@Contact_Department", Contact_Department)
			sqlparams(15) = New SqlParameter("@Contact_DOB", Contact_DOB)
			sqlparams(16) = New SqlParameter("@Contact_WorkEmail", Contact_WorkEmail)
			sqlparams(17) = New SqlParameter("@Contact_ProfilePic", Contact_ProfilePic)
			sqlparams(18) = New SqlParameter("@Contact_Type", Contact_Type)
			sqlparams(19) = New SqlParameter("@Contact_Remark", Contact_Remark)
			sqlparams(20) = New SqlParameter("@Contact_Id", Contact_Id)
			sqlparams(21) = New SqlParameter("@Contact_Notifyby", Contact_Notifyby)
			Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

End Class
