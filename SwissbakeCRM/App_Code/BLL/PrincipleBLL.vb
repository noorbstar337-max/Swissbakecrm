Imports APPCODE.DAL
Imports Microsoft.VisualBasic

Public Class PrincipleBLL
    Private Shared _spname As String = "_spPrinciple"
    Public Shared Function Insert(ByVal P_ComPanyName As String, ByVal P_ContactPerson As String, ByVal Principle_EmailID As String, ByVal Principle_MobileNo As String,
                                  ByVal _Phone As String, ByVal _Address As String, ByVal _pincode As String, ByVal _City As String, ByVal _state As Integer, ByVal _country As Integer,
                                  ByVal Principle_CreateID As Integer, ByVal Principle_CreateType As String, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(20) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@P_ComPanyName", P_ComPanyName)
            sqlparams(2) = New SqlParameter("@P_ContactPerson", P_ContactPerson)
            sqlparams(3) = New SqlParameter("@P_EmailID", Principle_EmailID)
            sqlparams(5) = New SqlParameter("@P_MobileNo", Principle_MobileNo)
            sqlparams(6) = New SqlParameter("@P_CreateID", Principle_CreateID)
            sqlparams(7) = New SqlParameter("@P_CreateType", Principle_CreateType)
            sqlparams(8) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)

            sqlparams(9) = New SqlParameter("@Principle_Phone", _Phone)
            sqlparams(10) = New SqlParameter("@Principle_Address", _Address)
            sqlparams(11) = New SqlParameter("@Principle_Pincode", _pincode)
            sqlparams(12) = New SqlParameter("@Principle_City ", _City)
            sqlparams(13) = New SqlParameter("@Principle_State", _state)
            sqlparams(14) = New SqlParameter("@Principle_Country ", _country)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function Update(ByVal P_ComPanyName As String, ByVal P_ContactPerson As String, ByVal Principle_EmailID As String, ByVal Principle_MobileNo As String,
                                  ByVal _Phone As String, ByVal _Address As String, ByVal _pincode As String, ByVal _City As String, ByVal _state As Integer, ByVal _country As Integer,
                                  ByVal Principle_ModifiedID As Integer, ByVal Principle_ModifiedType As String, ByVal principleID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(19) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@P_ID", principleID)
            sqlparams(2) = New SqlParameter("@P_ComPanyName", P_ComPanyName)
            sqlparams(3) = New SqlParameter("@P_ContactPerson", P_ContactPerson)
            sqlparams(4) = New SqlParameter("@P_EmailID", Principle_EmailID)
            sqlparams(5) = New SqlParameter("@P_MobileNo", Principle_MobileNo)
            sqlparams(6) = New SqlParameter("@P_ModifiedID", Principle_ModifiedID)
            sqlparams(7) = New SqlParameter("@P_ModifiedType", Principle_ModifiedType)
            sqlparams(8) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)

            sqlparams(9) = New SqlParameter("@Principle_Phone", _Phone)
            sqlparams(10) = New SqlParameter("@Principle_Address", _Address)
            sqlparams(11) = New SqlParameter("@Principle_Pincode", _pincode)
            sqlparams(12) = New SqlParameter("@Principle_City ", _City)
            sqlparams(13) = New SqlParameter("@Principle_State", _state)
            sqlparams(14) = New SqlParameter("@Principle_Country ", _country)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
