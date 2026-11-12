Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class EmailBLL
    Private Shared _spname As String = "_spEmail"

    Public Shared Function Insert(ByVal Type As String, ByVal TypeId As Integer, ByVal Owner As Integer,
                                  ByVal Subject As String, ByVal Message As String, ByVal fromMail As String,
                                  ByVal ToMail As String, ByVal Email_Cc As String, ByVal Email_Bcc As String, ByVal CreatedID As Integer, ByVal Status As String) As Integer
        Dim sqlparams(11) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Email_Type", Type)
            sqlparams(2) = New SqlParameter("@Email_TypeId", TypeId)
            sqlparams(3) = New SqlParameter("@Email_Owner", Owner)
            sqlparams(4) = New SqlParameter("@Email_Subject", Subject)
            sqlparams(5) = New SqlParameter("@Email_Message", Message)
            sqlparams(6) = New SqlParameter("@email_from", fromMail)
            sqlparams(7) = New SqlParameter("@Email_To", ToMail)
            sqlparams(8) = New SqlParameter("@Email_Cc", Email_Cc)
            sqlparams(9) = New SqlParameter("@Email_Bcc", Email_Bcc)
            sqlparams(10) = New SqlParameter("@Email_CreatedID", CreatedID)
            sqlparams(11) = New SqlParameter("@Email_Status", Status)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ViewEmailByType(ByVal Type As String, ByVal TypeId As Integer, ByVal CreatedID As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ViewEmailByType")
            sqlparams(1) = New SqlParameter("@Email_Type", Type)
            sqlparams(2) = New SqlParameter("@Email_TypeId", TypeId)
            sqlparams(3) = New SqlParameter("@Email_CreatedID", CreatedID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function EmailAccountSortingByAssign(ByVal ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "SortingEmail")
            sqlparams(1) = New SqlParameter("@Email_CreatedID", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
