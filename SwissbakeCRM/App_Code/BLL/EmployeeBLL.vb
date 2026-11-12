Imports APPCODE.DAL

Public Class EmployeeBLL
    Private Shared _spname As String = "_spEmployee"

    Public Shared Function Insert(ByVal Employee_Name As String, ByVal Employee_Designation As String, ByVal Employee_Department As String, ByVal Employee_CompanyID As Integer, ByVal Employee_CreatedType As String, ByVal Employee_CreatedID As Integer) As Integer
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Employee_Name", Employee_Name)
            sqlparams(2) = New SqlParameter("@Employee_Designation", Employee_Designation)
            sqlparams(3) = New SqlParameter("@Employee_Department", Employee_Department)
            sqlparams(4) = New SqlParameter("@Employee_CompanyID", Employee_CompanyID)
            sqlparams(5) = New SqlParameter("@Employee_CreatedType", Employee_CreatedType)
            sqlparams(6) = New SqlParameter("@Employee_CreatedID", Employee_CreatedID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal Employee_Name As String, ByVal Employee_Designation As String, ByVal Employee_Department As String, ByVal Employee_CompanyID As Integer, ByVal Employee_ModifiedType As String, ByVal Employee_ModifiedID As Integer, ByVal Employee_Id As Integer) As Integer
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Employee_Name", Employee_Name)
            sqlparams(2) = New SqlParameter("@Employee_Designation", Employee_Designation)
            sqlparams(3) = New SqlParameter("@Employee_Department", Employee_Department)
            sqlparams(4) = New SqlParameter("@Employee_CompanyID", Employee_CompanyID)
            sqlparams(5) = New SqlParameter("@Employee_ModifiedType", Employee_ModifiedType)
            sqlparams(6) = New SqlParameter("@Employee_ModifiedID", Employee_ModifiedID)
            sqlparams(7) = New SqlParameter("@Employee_Id", Employee_Id)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
