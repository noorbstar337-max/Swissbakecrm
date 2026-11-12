Imports APPCODE.DAL

Public Class SmsBLL
    Private Shared _spname As String = "_ViewByID"

    Public Shared Function CustomerNo(ByVal Acc_Id As String) As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "CustomerNo")
            sqlparams(1) = New SqlParameter("@ID", Acc_Id)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            'Throw ex
            Return 0
        End Try
    End Function

    Public Shared Function AdminNo() As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "AdminNo")
            sqlparams(1) = New SqlParameter("@ID", 1)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function UserNo(ByVal User_Id As String) As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UserNo")
            sqlparams(1) = New SqlParameter("@ID", User_Id)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function AllUserNo() As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "AllUserNo")
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function UserNoFromCust(ByVal Acc_Id As String) As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UserNoFromCust")
            sqlparams(1) = New SqlParameter("@ID", Acc_Id)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function CustomerName(ByVal Acc_Id As String) As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "CustomerName")
            sqlparams(1) = New SqlParameter("@ID", Acc_Id)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            'Throw ex
            Return 0
        End Try
    End Function

    Public Shared Function LMSUserNameByID(ByVal ID As String) As String   'Added By MUBYN for LMSAssignToControl.ascx 14-06-2018
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "LMSUserNameByID")
            sqlparams(1) = New SqlParameter("@ID", ID)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            'Throw ex
            Return 0
        End Try
    End Function

    Public Shared Function LMSUserContactByID(ByVal ID As String) As String   'Added By MUBYN for LMSAssignToControl.ascx 14-06-2018
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "LMSUserContactByID")
            sqlparams(1) = New SqlParameter("@ID", ID)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            'Throw ex
            Return 0
        End Try
    End Function
End Class
