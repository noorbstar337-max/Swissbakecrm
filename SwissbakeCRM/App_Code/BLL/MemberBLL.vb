Imports Microsoft.VisualBasic
Imports APPCODE.DAL
Public Class MemberBLL
    Private Shared _spname As String = "_spMember"

    Public Shared Function Insert(ByVal _MTitle As String, ByVal _MName As String, ByVal _MEmail As String, ByVal _MPass As String, ByVal _MMobile As String, ByVal _CountryId As Integer) As Integer
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Member_Title", _MTitle)
            sqlparams(2) = New SqlParameter("@Member_Name", _MName)
            sqlparams(3) = New SqlParameter("@Member_Email", _MEmail)
            sqlparams(4) = New SqlParameter("@Member_Password", _MPass)
            sqlparams(5) = New SqlParameter("@Member_Mobile", _MMobile)
            sqlparams(6) = New SqlParameter("@Member_CountryID", _CountryId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ValidateMember(ByVal _MEmail As String, ByVal _MPassword As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ValidateMember")
            sqlparams(1) = New SqlParameter("@Member_Email", _MEmail)
            sqlparams(2) = New SqlParameter("@Member_Password", _MPassword)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillMemberDetails(ByVal Member_ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ViewFrontMember")
            sqlparams(1) = New SqlParameter("@Member_ID", Member_ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal _MTitle As String, ByVal _MName As String, ByVal _MEmail As String, ByVal _MMobile As String, ByVal _MSecQues As String,
                                  _MSecAns As String, ByVal _MCountryID As Integer, ByVal _ID As Integer) As Integer
        Dim sqlparams(8) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Member_Title", _MTitle)
            sqlparams(2) = New SqlParameter("@Member_Name", _MName)
            sqlparams(3) = New SqlParameter("@Member_Email", _MEmail)
            sqlparams(4) = New SqlParameter("@Member_SecAnswer", _MSecAns)
            sqlparams(5) = New SqlParameter("@Member_Mobile", _MMobile)
            sqlparams(6) = New SqlParameter("@Member_SecQuestion", _MSecQues)
            sqlparams(7) = New SqlParameter("@Member_CountryID", _MCountryID)
            sqlparams(8) = New SqlParameter("@Member_ID", _ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdatePassword(ByVal _MPass As String, _ID As Integer) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdatePassword")
            sqlparams(1) = New SqlParameter("@Member_Password", _MPass)
            sqlparams(2) = New SqlParameter("@Member_ID", _ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
