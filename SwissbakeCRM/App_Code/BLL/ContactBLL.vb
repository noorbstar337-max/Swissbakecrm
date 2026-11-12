Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class ContactBLL
    Private Shared _spname As String = "_spContact"

	Public Shared Function Insert(ByVal Title As String, ByVal Gender As String, ByVal Name As String, ByVal DesigId As Integer, ByVal DepartmentId As Integer,
		   ByVal Email As String, ByVal WorkEmail As String, ByVal MobileNo As String, ByVal OfficeNo As String, ByVal DOB As String, ByVal ProfilePic As String,
		   ByVal Contact_Type As Integer, ByVal Remark As String, ByVal RelatedType As String, ByVal RelatedTypeID As Integer,
		   ByVal Extention As String, ByVal CreatedID As String, ByVal AudtTrail_LogId As Integer, ByVal ContactPrimary As Boolean, ByVal Contact_Notifyby As String) As Integer
		Dim sqlparams(20) As SqlParameter
		Try
			sqlparams(0) = New SqlParameter("@Mode", "Insert")
			sqlparams(1) = New SqlParameter("@Contact_Title", Title)
			sqlparams(2) = New SqlParameter("@Contact_Gender", Gender)
			sqlparams(3) = New SqlParameter("@Contact_ContactPerson", Name)
			sqlparams(4) = New SqlParameter("@Contact_Designation", DesigId)
			sqlparams(5) = New SqlParameter("@Contact_Department", DepartmentId)
			sqlparams(6) = New SqlParameter("@Contact_Email", Email)
			sqlparams(7) = New SqlParameter("@Contact_WorkEmail", WorkEmail)
			sqlparams(8) = New SqlParameter("@Contact_Mobile", MobileNo)
			sqlparams(9) = New SqlParameter("@Contact_Landline", OfficeNo)
			sqlparams(10) = New SqlParameter("@Contact_Extention", Extention)
			sqlparams(11) = New SqlParameter("@Contact_DOB", DOB)
			sqlparams(12) = New SqlParameter("@Contact_ProfilePic", ProfilePic)
			sqlparams(13) = New SqlParameter("@Contact_Type", Contact_Type)
			sqlparams(14) = New SqlParameter("@Contact_Remark", Remark)
			sqlparams(15) = New SqlParameter("@Contact_ContactType", RelatedType)
			sqlparams(16) = New SqlParameter("@Contact_ContactTypeId", RelatedTypeID)
			sqlparams(17) = New SqlParameter("@Contact_CreatedID", CreatedID)
			sqlparams(18) = New SqlParameter("@Contact_Primary", ContactPrimary)
			sqlparams(19) = New SqlParameter("@Contact_Notifyby", Contact_Notifyby)
			'sqlparams(18) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Shared Function InsertContact(ByVal Title As String, ByVal Gender As String, ByVal Name As String, ByVal DesigId As Integer, ByVal DepartmentId As Integer,
           ByVal Email As String, ByVal WorkEmail As String, ByVal MobileNo As String, ByVal OfficeNo As String, ByVal DOB As String, ByVal ProfilePic As String,
           ByVal Contact_Type As Integer, ByVal Remark As String, ByVal RelatedType As String, ByVal RelatedTypeID As Integer,
           ByVal Extention As String, ByVal CreatedID As String, ByVal AudtTrail_LogId As Integer, ByVal ContactPrimary As Boolean, ByVal MainID As Integer) As Integer
        Dim sqlparams(19) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertContact")
            sqlparams(1) = New SqlParameter("@Contact_Title", Title)
            sqlparams(2) = New SqlParameter("@Contact_Gender", Gender)
            sqlparams(3) = New SqlParameter("@Contact_ContactPerson", Name)
            sqlparams(4) = New SqlParameter("@Contact_Designation", DesigId)
            sqlparams(5) = New SqlParameter("@Contact_Department", DepartmentId)
            sqlparams(6) = New SqlParameter("@Contact_Email", Email)
            sqlparams(7) = New SqlParameter("@Contact_WorkEmail", WorkEmail)
            sqlparams(8) = New SqlParameter("@Contact_Mobile", MobileNo)
            sqlparams(9) = New SqlParameter("@Contact_Landline", OfficeNo)
            sqlparams(10) = New SqlParameter("@Contact_Extention", Extention)
            sqlparams(11) = New SqlParameter("@Contact_DOB", DOB)
            sqlparams(12) = New SqlParameter("@Contact_ProfilePic", ProfilePic)
            sqlparams(13) = New SqlParameter("@Contact_Type", Contact_Type)
            sqlparams(14) = New SqlParameter("@Contact_Remark", Remark)
            sqlparams(15) = New SqlParameter("@Contact_ContactType", RelatedType)
            sqlparams(16) = New SqlParameter("@Contact_ContactTypeId", RelatedTypeID)
            sqlparams(17) = New SqlParameter("@Contact_CreatedID", CreatedID)
            sqlparams(18) = New SqlParameter("@Contact_Primary", ContactPrimary)
            sqlparams(19) = New SqlParameter("@Opportunity_Id", MainID)
            'sqlparams(18) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

	Public Shared Function Update(ByVal Title As String, ByVal Gender As String, ByVal Name As String, ByVal DesigId As Integer, ByVal DepartmentId As Integer,
		 ByVal Email As String, ByVal WorkEmail As String, ByVal MobileNo As String, ByVal OfficeNo As String, ByVal DOB As String, ByVal ProfilePic As String,
		 ByVal Contact_Type As Integer, ByVal Remark As String, ByVal RelatedType As String, ByVal RelatedTypeID As Integer,
		 ByVal Extention As String, ByVal ModifiedID As String, ByVal AudtTrail_LogId As Integer, ByVal ID As Integer, ByVal Contact_Notifyby As String) As Integer
		Dim sqlparams(20) As SqlParameter
		Try
			sqlparams(0) = New SqlParameter("@Mode", "Update")
			sqlparams(1) = New SqlParameter("@Contact_Title", Title)
			sqlparams(2) = New SqlParameter("@Contact_Gender", Gender)
			sqlparams(3) = New SqlParameter("@Contact_ContactPerson", Name)
			sqlparams(4) = New SqlParameter("@Contact_Designation", DesigId)
			sqlparams(5) = New SqlParameter("@Contact_Department", DepartmentId)
			sqlparams(6) = New SqlParameter("@Contact_Email", Email)
			sqlparams(7) = New SqlParameter("@Contact_WorkEmail", WorkEmail)
			sqlparams(8) = New SqlParameter("@Contact_Mobile", MobileNo)
			sqlparams(9) = New SqlParameter("@Contact_Landline", OfficeNo)
			sqlparams(10) = New SqlParameter("@Contact_Extention", Extention)
			sqlparams(11) = New SqlParameter("@Contact_DOB", DOB)
			sqlparams(12) = New SqlParameter("@Contact_ProfilePic", ProfilePic)
			sqlparams(13) = New SqlParameter("@Contact_Type", Contact_Type)
			sqlparams(14) = New SqlParameter("@Contact_Remark", Remark)
			sqlparams(15) = New SqlParameter("@Contact_ContactType", RelatedType)
			sqlparams(16) = New SqlParameter("@Contact_ContactTypeId", RelatedTypeID)
			sqlparams(17) = New SqlParameter("@Contact_CreatedID", ModifiedID)
			sqlparams(18) = New SqlParameter("@Contact_Id", ID)
			sqlparams(19) = New SqlParameter("@Contact_Notifyby", Contact_Notifyby)
			'sqlparams(18) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
			Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Shared Function ContactByID(ByVal Type As String, ByVal TypeID As Integer, ByVal ID As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ContactByID")
            sqlparams(1) = New SqlParameter("@Contact_ContactType", Type)
            sqlparams(2) = New SqlParameter("@Contact_ContactTypeId", TypeID)
            'sqlparams(3) = New SqlParameter("@Activity_Id", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function SelectContactByID(ByVal TypeID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "SelectContactByID")
            sqlparams(1) = New SqlParameter("@Contact_ContactTypeId", TypeID)
            'sqlparams(3) = New SqlParameter("@Activity_Id", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ViewUnselectedContact(ByVal Type As String, ByVal TypeID As Integer, ByVal ID As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ViewUnselectedContact")
            sqlparams(1) = New SqlParameter("@Contact_ContactType", Type)
            sqlparams(2) = New SqlParameter("@Contact_ContactTypeId", TypeID)
            sqlparams(3) = New SqlParameter("@Contact_Id", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdatePrimaryContact(ByVal RelatedType As String, ByVal RelatedTypeID As Integer,
         ByVal ID As Integer, ByVal ModifiedID As String, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdatePrimaryContact")
            sqlparams(1) = New SqlParameter("@Contact_ContactType", RelatedType)
            sqlparams(2) = New SqlParameter("@Contact_ContactTypeId", RelatedTypeID)
            sqlparams(3) = New SqlParameter("@Contact_ModifiedID", ModifiedID)
            sqlparams(4) = New SqlParameter("@Contact_Id", ID)
            'sqlparams(18) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function XMLContactInsert(ByVal XMLAssignTo As String) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "XMLContactInsert")
            sqlparams(1) = New SqlParameter("@XMLAssignTo", XMLAssignTo)
            'sqlparams(2) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            'sqlparams(3) = New SqlParameter("@Assignto_Type", Type)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function MaxoppContactID() As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "MaxoppContactID")
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DeleteOppContact(ByVal ID As Integer) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "DeleteOppContact")
            sqlparams(1) = New SqlParameter("@Contact_Id", ID)
            'sqlparams(18) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateOpportunityContact(ByVal RelatedTypeID As Integer,
         ByVal ID As Integer, ByVal ModifiedID As String, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateOpportunityContact")
            sqlparams(1) = New SqlParameter("@Contact_ContactTypeId", RelatedTypeID)
            sqlparams(2) = New SqlParameter("@Contact_ModifiedID", ModifiedID)
            sqlparams(3) = New SqlParameter("@Contact_Id", ID)
            'sqlparams(18) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
