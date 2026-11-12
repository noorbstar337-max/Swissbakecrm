Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class ComplaintBLL

    Private Shared Complaint_spname As String = "_spComplaint"

    Public Shared Function FillListView(ByVal Complaint_ID As Integer, ByVal Mode As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Complaint_ID", Complaint_ID)

            Return DBBridge.ExecuteDataset(Complaint_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Public Shared Function Insert(ByVal Reply_Discription As String, ByVal Reply_ModifiedID As Integer, ByVal Reply_CreatedID As Integer) As Integer
    '    Dim sqlparams(3) As SqlParameter
    '    Try
    '        sqlparams(0) = New SqlParameter("@Mode", "Insert")
    '        sqlparams(1) = New SqlParameter("@Reply_Discription", Reply_Discription)
    '        sqlparams(2) = New SqlParameter("@Reply_ModifiedID", Reply_ModifiedID)
    '        sqlparams(3) = New SqlParameter("@Reply_CreatedID", Reply_CreatedID)
    '        Return DBBridge.ExecuteNonQuery(Complaint_spname, sqlparams)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Public Shared Function Update(ByVal Reply_Discription As String, ByVal Reply_Attachment As String, ByVal Reply_ModifiedID As Integer, ByVal Complaint_ID As Integer, ByVal Complaint_CompStatus As String) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Reply_Discription", Reply_Discription)
            sqlparams(2) = New SqlParameter("@Reply_Attachment", Reply_Attachment)
            sqlparams(3) = New SqlParameter("@Reply_ModifiedID", Reply_ModifiedID)
            sqlparams(4) = New SqlParameter("@Complaint_ID", Complaint_ID)
            sqlparams(5) = New SqlParameter("@Complaint_CompStatus", Complaint_CompStatus)

            Return DBBridge.ExecuteNonQuery(Complaint_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Insert(ByVal _Complaint_DeptId As Integer, ByVal _Complaint_CustId As Integer, ByVal _Complaint_Subject As String, ByVal _Complaint_Discription As String, ByVal _Complaint_Attachment As String) As Integer
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Complaint_DeptId", _Complaint_DeptId)
            sqlparams(2) = New SqlParameter("@Complaint_CustId", _Complaint_CustId)
            sqlparams(3) = New SqlParameter("@Complaint_Subject", _Complaint_Subject)
            sqlparams(4) = New SqlParameter("@Complaint_Discription", _Complaint_Discription)
            sqlparams(5) = New SqlParameter("@Complaint_Attachment", _Complaint_Attachment)
            Return DBBridge.ExecuteScalar(Complaint_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function InsertCrm(ByVal _Complaint_DeptId As Integer, ByVal _Complaint_CustId As Integer, ByVal _Complaint_Subject As String, ByVal _Complaint_Discription As String, ByVal _Complaint_Attachment As String, ByVal _Complaint_CreatedID As Integer) As Integer
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertCrm")
            sqlparams(1) = New SqlParameter("@Complaint_DeptId", _Complaint_DeptId)
            sqlparams(2) = New SqlParameter("@Complaint_CustId", _Complaint_CustId)
            sqlparams(3) = New SqlParameter("@Complaint_Subject", _Complaint_Subject)
            sqlparams(4) = New SqlParameter("@Complaint_Discription", _Complaint_Discription)
            sqlparams(5) = New SqlParameter("@Complaint_Attachment", _Complaint_Attachment)
            sqlparams(6) = New SqlParameter("@Complaint_CreatedID", _Complaint_CreatedID)
            Return DBBridge.ExecuteScalar(Complaint_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillTicket(ByVal _Complaint_CustId As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "MainTicketFill")
            sqlparams(1) = New SqlParameter("@Complaint_CustId", _Complaint_CustId)

            Return DBBridge.ExecuteDataset(Complaint_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function FillTicket1(ByVal _Complaint_CustId As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "MainTicketFill1")
            sqlparams(1) = New SqlParameter("@Complaint_CustId", _Complaint_CustId)

            Return DBBridge.ExecuteDataset(Complaint_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillTicket_ByID(ByVal _Complaint_ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "MainTicketFill_ById")
            sqlparams(1) = New SqlParameter("@Complaint_ID", _Complaint_ID)

            Return DBBridge.ExecuteDataset(Complaint_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
