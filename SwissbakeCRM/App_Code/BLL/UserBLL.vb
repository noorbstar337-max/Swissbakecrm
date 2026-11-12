Imports UserTableAdapters
Imports APPCODE.DAL
Public Class UserBLL
    Private Shared _Adptr As tblUserTableAdapter = Nothing
    Private Shared _spname As String = "_spInsertUser"


#Region "DatasetCoding"
    Protected Shared ReadOnly Property Adptr() As tblUserTableAdapter
        Get
            _Adptr = New tblUserTableAdapter
            Return _Adptr
        End Get
    End Property

    Public Shared Function ValidateUserLogin(ByVal _UserName As String, ByVal _Password As String) As DataTable
        Try
            Return Adptr._ValidateUserLogin(_UserName, _Password)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function TotalNumberOFUserRecord(ByVal _Mode As String) As Integer
        Try
            Return Adptr._TotalNumberOfUserRecord(_Mode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillUserByPaging(ByVal _PageIndex As Integer, ByVal _PageSize As Integer, ByVal _Mode As String) As DataTable
        Try
            Return Adptr.GetUserByPaging(_PageIndex, _PageSize, _Mode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'Public Shared Function UserByPaging(ByVal dt As DataTable, ByVal _PageIndex As Integer, ByVal _PageSize As Integer, ByVal _Mode As String) As DataTable
    '    Try

    '        Return Adptr._FillUserByPaging(dt, _PageIndex, _PageSize, _Mode)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function
    Public Shared Function FillAllUserForSorting() As DataTable
        Try
            Return Adptr.GetFillAllUserRecordForSorting
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DeleteSiUser(ByVal _ModifiediD As Integer, ByVal _U_ID As Integer) As Integer
        Try
            Return Adptr._DeleteSiUser(_ModifiediD, _U_ID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function SearchUser(ByVal _SearchValue As String, ByVal _Mode As String) As DataTable
        Try
            Return Adptr.Get_SearchUser(_SearchValue, _Mode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateUserStatus(ByVal _U_ID As Integer, ByVal _ModifiediD As Integer) As Integer
        Try
            Return Adptr._UpdateUserStatus(_U_ID, _ModifiediD)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertUser(ByVal _Name As String, ByVal _Username As String, ByVal _Password As String, ByVal _RoleID As Integer, ByVal _CreatedID As Integer) As Integer
        Try
            Return Adptr._InsertUser(_Name, _Username, _Password, _RoleID, _CreatedID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateUser(ByVal _Name As String, ByVal _Username As String, ByVal _Password As String, ByVal _RoleID As Integer, ByVal _ModifiediD As Integer, ByVal _UID As Integer) As Integer
        Try
            Return Adptr._UpdateUser(_Name, _Username, _Password, _RoleID, _ModifiediD, _UID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ViewBYIDUser(ByVal _UID As Integer) As DataTable
        Try
            Return Adptr.Get_ViewByID(_UID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    Public Shared Function Insert(ByVal U_FirstName As String, ByVal U_LastName As String, ByVal U_Password As String, ByVal U_Email As String, ByVal U_Mobile As String,
                                  ByVal U_DeptId As Integer, ByVal U_ReportingTo As Integer, ByVal U_Address1 As String, ByVal U_Address2 As String, ByVal U_City As String, ByVal U_StateId As Integer,
                                  ByVal U_CountryId As Integer, ByVal U_Pincode As String, ByVal U_RegionId As Integer, ByVal U_EmployeeId As String, ByVal U_DOJ As String,
                                  ByVal U_DOB As String, ByVal U_LevelId As Integer, ByVal U_DesignationId As Integer, ByVal U_TypeId As Integer, ByVal U_CreatedID As Integer, ByVal Audlog_Id As Integer,
                                  ByVal U_EmailServerName As String, ByVal U_ServerPort As String, ByVal U_EmailPassword As String, ByVal U_SSL As String, ByVal U_DisplayName As String) As Integer
        Dim sqlparams(28) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@U_FirstName", U_FirstName)
            sqlparams(2) = New SqlParameter("@U_LastName", U_LastName)
            sqlparams(3) = New SqlParameter("@U_Password", U_Password)
            sqlparams(4) = New SqlParameter("@U_Email", U_Email)
            sqlparams(5) = New SqlParameter("@U_Mobile", U_Mobile)
            sqlparams(6) = New SqlParameter("@U_DeptId", U_DeptId)
            sqlparams(7) = New SqlParameter("@U_Address1", U_Address1)
            sqlparams(8) = New SqlParameter("@U_Address2", U_Address2)
            sqlparams(9) = New SqlParameter("@U_City", U_City)
            sqlparams(10) = New SqlParameter("@U_StateId", U_StateId)
            sqlparams(11) = New SqlParameter("@U_CountryId", U_CountryId)
            sqlparams(12) = New SqlParameter("@U_Pincode", U_Pincode)
            sqlparams(13) = New SqlParameter("@U_RegionId", U_RegionId)
            sqlparams(14) = New SqlParameter("@U_EmployeeId", U_EmployeeId)
            If Not String.IsNullOrEmpty(U_DOJ) Then
                sqlparams(15) = New SqlParameter("@U_DOJ", U_DOJ)
            Else
                sqlparams(15) = New SqlParameter("@U_DOJ", DBNull.Value)
            End If

            If Not String.IsNullOrEmpty(U_DOB) Then
                sqlparams(16) = New SqlParameter("@U_DOB", U_DOB)
            Else
                sqlparams(16) = New SqlParameter("@U_DOB", DBNull.Value)
            End If
            sqlparams(17) = New SqlParameter("@U_LevelId", U_LevelId)
            sqlparams(18) = New SqlParameter("@U_DesignationId", U_DesignationId)
            sqlparams(19) = New SqlParameter("@U_TypeId", U_TypeId)
            sqlparams(20) = New SqlParameter("@U_CreatedID", U_CreatedID)
            sqlparams(21) = New SqlParameter("@Audlog_Id", Audlog_Id)
            sqlparams(22) = New SqlParameter("@U_EmailServerName", U_EmailServerName)
            sqlparams(23) = New SqlParameter("@U_ServerPort", U_ServerPort)
            sqlparams(24) = New SqlParameter("@U_EmailPassword", U_EmailPassword)
            sqlparams(25) = New SqlParameter("@U_SSL", U_SSL)
            sqlparams(26) = New SqlParameter("@U_ReportingTo", U_ReportingTo)
            sqlparams(27) = New SqlParameter("@U_DisplayName", U_DisplayName)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Shared Function QuickInsert(ByVal U_FirstName As String, ByVal U_Password As String, ByVal U_Email As String, ByVal U_LevelId As Integer, ByVal U_CreatedID As Integer, ByVal Audlog_Id As Integer) As Integer
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@U_FirstName", U_FirstName)
            sqlparams(2) = New SqlParameter("@U_Password", U_Password)
            sqlparams(3) = New SqlParameter("@U_Email", U_Email)
            sqlparams(4) = New SqlParameter("@U_CreatedID", U_CreatedID)
            sqlparams(5) = New SqlParameter("@Audlog_Id", Audlog_Id)
            sqlparams(6) = New SqlParameter("@U_LevelId", U_LevelId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'created by nilesh on 11-01-2019
    Public Shared Function QuickInsert1(ByVal U_FirstName As String, ByVal U_Password As String, ByVal U_DeptId As Integer, ByVal U_DesignationId As Integer, ByVal U_Email As String, ByVal U_LevelId As Integer, ByVal U_RegionId As Integer, ByVal U_CreatedID As Integer, ByVal Audlog_Id As Integer) As Integer
        Dim sqlparams(10) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@U_FirstName", U_FirstName)
            sqlparams(2) = New SqlParameter("@U_Password", U_Password)
            sqlparams(3) = New SqlParameter("@U_Email", U_Email)
            sqlparams(4) = New SqlParameter("@U_DeptId", U_DeptId)
            sqlparams(5) = New SqlParameter("@U_DesignationId", U_DesignationId)
            sqlparams(6) = New SqlParameter("@U_CreatedID", U_CreatedID)
            sqlparams(7) = New SqlParameter("@Audlog_Id", Audlog_Id)
            sqlparams(8) = New SqlParameter("@U_LevelId", U_LevelId)
            sqlparams(9) = New SqlParameter("@U_RegionId", U_RegionId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal U_FirstName As String, ByVal U_LastName As String, ByVal U_Email As String, ByVal U_Mobile As String,
                                  ByVal U_DeptId As Integer, ByVal U_ReportingTo As Integer, ByVal U_Address1 As String, ByVal U_Address2 As String, ByVal U_City As String, ByVal U_StateId As Integer,
                                  ByVal U_CountryId As Integer, ByVal U_Pincode As String, ByVal U_RegionId As Integer, ByVal U_EmployeeId As String, ByVal U_DOJ As String,
                                  ByVal U_DOB As String, ByVal U_LevelId As Integer, ByVal U_DesignationId As Integer, ByVal U_TypeId As Integer, ByVal _ModifiedID As Integer,
                                  ByVal ID As Integer, ByVal Audlog_Id As Integer, ByVal U_EmailServerName As String, ByVal U_ServerPort As String, ByVal U_EmailPassword As String, ByVal U_SSL As String,
                                  ByVal U_Displayname As String) As Integer
        Dim sqlparams(27) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@U_FirstName", U_FirstName)
            sqlparams(2) = New SqlParameter("@U_LastName", U_LastName)
            sqlparams(3) = New SqlParameter("@U_Email", U_Email)
            sqlparams(4) = New SqlParameter("@U_Mobile", U_Mobile)
            sqlparams(5) = New SqlParameter("@U_DeptId", U_DeptId)
            sqlparams(6) = New SqlParameter("@U_Address1", U_Address1)
            sqlparams(7) = New SqlParameter("@U_Address2", U_Address2)
            sqlparams(8) = New SqlParameter("@U_City", U_City)
            sqlparams(9) = New SqlParameter("@U_StateId", U_StateId)
            sqlparams(10) = New SqlParameter("@U_CountryId", U_CountryId)
            sqlparams(11) = New SqlParameter("@U_Pincode", U_Pincode)
            sqlparams(12) = New SqlParameter("@U_RegionId", U_RegionId)
            sqlparams(13) = New SqlParameter("@U_EmployeeId", U_EmployeeId)
            If Not String.IsNullOrEmpty(U_DOJ) Then
                sqlparams(14) = New SqlParameter("@U_DOJ", U_DOJ)
            Else
                sqlparams(14) = New SqlParameter("@U_DOJ", DBNull.Value)
            End If

            If Not String.IsNullOrEmpty(U_DOB) Then
                sqlparams(15) = New SqlParameter("@U_DOB", U_DOB)
            Else
                sqlparams(15) = New SqlParameter("@U_DOB", DBNull.Value)
            End If
            'sqlparams(14) = New SqlParameter("@U_DOJ", U_DOJ)
            'sqlparams(15) = New SqlParameter("@U_DOB", U_DOB)
            sqlparams(16) = New SqlParameter("@U_LevelId", U_LevelId)
            sqlparams(17) = New SqlParameter("@U_DesignationId", U_DesignationId)
            sqlparams(18) = New SqlParameter("@U_TypeId", U_TypeId)
            sqlparams(19) = New SqlParameter("@U_ModifiedID", _ModifiedID)
            sqlparams(20) = New SqlParameter("@U_ID", ID)
            sqlparams(21) = New SqlParameter("@Audlog_Id", Audlog_Id)
            sqlparams(22) = New SqlParameter("@U_EmailServerName", U_EmailServerName)
            sqlparams(23) = New SqlParameter("@U_ServerPort", U_ServerPort)
            sqlparams(24) = New SqlParameter("@U_EmailPassword", U_EmailPassword)
            sqlparams(25) = New SqlParameter("@U_SSL", U_SSL)
            sqlparams(26) = New SqlParameter("@U_ReportingTo", U_ReportingTo)
            sqlparams(27) = New SqlParameter("@U_DisplayName", U_Displayname)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function UpdateProfile(ByVal U_FirstName As String, ByVal U_LastName As String, ByVal U_Email As String, ByVal U_Mobile As String, ByVal U_DOB As Date, ByVal U_Theme As String, ByVal U_ID As Integer) As Integer
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateProfile")
            sqlparams(1) = New SqlParameter("@U_FirstName", U_FirstName)
            sqlparams(2) = New SqlParameter("@U_LastName", U_LastName)
            sqlparams(3) = New SqlParameter("@U_Email", U_Email)
            sqlparams(4) = New SqlParameter("@U_Mobile", U_Mobile)
            sqlparams(5) = New SqlParameter("@U_DOB", U_DOB)
            sqlparams(6) = New SqlParameter("@U_Theme", U_Theme)
            sqlparams(7) = New SqlParameter("@U_ID", U_ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function ValidateLogin(ByVal _Username As String, ByVal _Password As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ValidateLogin")
            sqlparams(1) = New SqlParameter("@U_UserName", _Username)
            sqlparams(2) = New SqlParameter("@U_Password", _Password)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Changepass(ByVal _Password As String, ByVal ID As Integer) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Changepass")
            sqlparams(1) = New SqlParameter("@U_Password", _Password)
            sqlparams(2) = New SqlParameter("@U_ID", ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertAuditLog(ByVal U_ID As Integer) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertAuditLog")
            sqlparams(1) = New SqlParameter("@U_ID", U_ID)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Logout(ByVal Audlog_Id As Integer) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Logout")
            sqlparams(1) = New SqlParameter("@Audlog_Id", Audlog_Id)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function NoOfUser() As String
        Dim sqlparams(0) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "NoOfUser")
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ValidateOldPass(ByVal U_Id As String, ByVal U_Password As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ValidateOldPass")
            sqlparams(1) = New SqlParameter("@U_Id", U_Id)
            sqlparams(2) = New SqlParameter("@U_Password", U_Password)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function UpdateImage(ByVal U_FirstName As String, ByVal U_LastName As String, ByVal U_Mobile As String, ByVal U_DOB As String, ByVal U_ProfileImage As String, ByVal U_ID As String) As Integer
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateImage")
            sqlparams(1) = New SqlParameter("@U_FirstName", U_FirstName)
            sqlparams(2) = New SqlParameter("@U_LastName", U_LastName)
            sqlparams(3) = New SqlParameter("@U_Mobile", U_Mobile)
            If String.IsNullOrEmpty(U_DOB) Then
                sqlparams(4) = New SqlParameter("@U_DOB", DBNull.Value)
            Else
                sqlparams(4) = New SqlParameter("@U_DOB", U_DOB)
            End If

            sqlparams(5) = New SqlParameter("@U_ProfileImage", U_ProfileImage)
            sqlparams(6) = New SqlParameter("@U_ID", U_ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function CheckEmail(ByVal U_UserName As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "CheckEmail")
            sqlparams(1) = New SqlParameter("@U_UserName", U_UserName)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function FillAssignUser(ByVal ReportingTo As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FillAssignUser")
            sqlparams(1) = New SqlParameter("@U_ReportingTo", ReportingTo)
            Return DBBridge.ExecuteDataset("_spUser", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function SearchUserByAssign(ByVal ReportingTo As Integer, ByVal SearchUser As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "SearchUserByAssign")
            sqlparams(1) = New SqlParameter("@U_ReportingTo", ReportingTo)
            sqlparams(2) = New SqlParameter("@U_UserName", SearchUser)
            Return DBBridge.ExecuteDataset("_spUser", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Email(ByVal usserid As Integer) As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Getreportingtoemail")
            sqlparams(1) = New SqlParameter("@U_ID", usserid)
            Return DBBridge.ExecuteScalar("_spUser", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '-------------Added by MUBYN Used in LMSAssignToControl
    Public Shared Function FillLMSAssignUser(ByVal ReportingTo As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FillLMSAssignUser")
            sqlparams(1) = New SqlParameter("@U_ReportingTo", ReportingTo)
            Return DBBridge.ExecuteDataset("_spUser", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '-------------Added by MUBYN Used in LMSAssignToControl
    Public Shared Function SearchLMSUserByAssign(ByVal ReportingTo As Integer, ByVal SearchUser As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "SearchLMSUserByAssign")
            sqlparams(1) = New SqlParameter("@U_ReportingTo", ReportingTo)
            sqlparams(2) = New SqlParameter("@U_UserName", SearchUser)
            Return DBBridge.ExecuteDataset("_spUser", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '-------------Added by MUBYN 
    Public Shared Function ValidateLoginPrev(ByVal _Username As String, ByVal _Password As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ValidateLoginPrev")
            sqlparams(1) = New SqlParameter("@U_UserName", _Username)
            sqlparams(2) = New SqlParameter("@U_Password", _Password)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '-------------Added by MUBYN 
    Public Shared Function CheckPrivi(ByVal U_LevelId As Integer, ByVal Menu_URL As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "CheckPrivi")
            sqlparams(1) = New SqlParameter("@U_LevelId", U_LevelId)
            sqlparams(2) = New SqlParameter("@Menu_URL", Menu_URL)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
	    '-------------Added by MUBYN in Hierarchy
    Public Shared Function ReportingTo(ByVal Mode As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            Return DBBridge.ExecuteDataset("_spUser", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
