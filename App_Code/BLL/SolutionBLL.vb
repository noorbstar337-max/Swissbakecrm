Imports APPCODE.DAL

Public Class SolutionBLL
    Private Shared _spname As String = "_spCustComplaint"

    Public Shared Function Insert(ByVal CustComplaint_No As String, ByVal CustComplaint_ProID As Integer, ByVal CustComplaint_Type As String, ByVal CustComplaint_AccID As Integer, ByVal CustComplaint_BatchNo As String,
                                  ByVal CustComplaint_InvoiceNo As String, ByVal CustComplaint_Title As String, ByVal CustComplaint_Desc As String, ByVal CustComplaint_RCExt As String,
                                  ByVal CustComplaint_RCInt As String, ByVal CustComplaint_Solution As Boolean, ByVal CustComplaint_Action As String, ByVal CustComplaint_Prevent As String,
                                 ByVal CustComplaint_Feedback As String, ByVal CustComplaint_CreatedID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(17) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@CustComplaint_No", CustComplaint_No)
            sqlparams(2) = New SqlParameter("@CustComplaint_BatchNo", CustComplaint_BatchNo)
            sqlparams(3) = New SqlParameter("@CustComplaint_ProID", CustComplaint_ProID)
            sqlparams(4) = New SqlParameter("@CustComplaint_AccID", CustComplaint_AccID)
            sqlparams(5) = New SqlParameter("@CustComplaint_InvoiceNo", CustComplaint_InvoiceNo)
            sqlparams(6) = New SqlParameter("@CustComplaint_Title", CustComplaint_Title)
            sqlparams(7) = New SqlParameter("@CustComplaint_Desc", CustComplaint_Desc)
            sqlparams(8) = New SqlParameter("@CustComplaint_RCExt", CustComplaint_RCExt)
            sqlparams(9) = New SqlParameter("@CustComplaint_RCInt", CustComplaint_RCInt)
            sqlparams(10) = New SqlParameter("@CustComplaint_Solution", CustComplaint_Solution)
            sqlparams(11) = New SqlParameter("@CustComplaint_Action", CustComplaint_Action)
            sqlparams(12) = New SqlParameter("@CustComplaint_Prevent", CustComplaint_Prevent)
            sqlparams(13) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(14) = New SqlParameter("@CustComplaint_Feedback", CustComplaint_Feedback)
            sqlparams(15) = New SqlParameter("@CreatedID", CustComplaint_CreatedID)
            sqlparams(16) = New SqlParameter("@CustComplaint_Type", CustComplaint_Type)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal CustComplaint_No As String, ByVal CustComplaint_ProID As Integer, ByVal CustComplaint_Type As String, ByVal CustComplaint_AccID As Integer, ByVal CustComplaint_BatchNo As String,
                                  ByVal CustComplaint_InvoiceNo As String, ByVal CustComplaint_Title As String, ByVal CustComplaint_Desc As String, ByVal CustComplaint_RCExt As String,
                                  ByVal CustComplaint_RCInt As String, ByVal CustComplaint_Solution As Boolean, ByVal CustComplaint_Action As String, ByVal CustComplaint_Prevent As String,
                                 ByVal CustComplaint_Feedback As String, ByVal CustComplaint_ModifiedID As Integer, ByVal CustComplaint_ID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(18) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@CustComplaint_No", CustComplaint_No)
            sqlparams(2) = New SqlParameter("@CustComplaint_BatchNo", CustComplaint_BatchNo)
            sqlparams(3) = New SqlParameter("@CustComplaint_ProID", CustComplaint_ProID)
            sqlparams(4) = New SqlParameter("@CustComplaint_AccID", CustComplaint_AccID)
            sqlparams(5) = New SqlParameter("@CustComplaint_InvoiceNo", CustComplaint_InvoiceNo)
            sqlparams(6) = New SqlParameter("@CustComplaint_Title", CustComplaint_Title)
            sqlparams(7) = New SqlParameter("@CustComplaint_Desc", CustComplaint_Desc)
            sqlparams(8) = New SqlParameter("@CustComplaint_RCExt", CustComplaint_RCExt)
            sqlparams(9) = New SqlParameter("@CustComplaint_RCInt", CustComplaint_RCInt)
            sqlparams(10) = New SqlParameter("@CustComplaint_Solution", CustComplaint_Solution)
            sqlparams(11) = New SqlParameter("@CustComplaint_Action", CustComplaint_Action)
            sqlparams(12) = New SqlParameter("@CustComplaint_Prevent", CustComplaint_Prevent)
            sqlparams(13) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(14) = New SqlParameter("@CustComplaint_Feedback", CustComplaint_Feedback)
            sqlparams(15) = New SqlParameter("@CreatedID", CustComplaint_ModifiedID)
            sqlparams(16) = New SqlParameter("@CustComplaint_ID", CustComplaint_ID)
            sqlparams(17) = New SqlParameter("@CustComplaint_Type", CustComplaint_Type)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function SolutionSearch(ByVal _CustComplaint_No As String, ByVal Product_Name As String, ByVal Acc_Name As String, ByVal _CustComplaint_BatchNo As String,
                                          ByVal _CustComplaint_InvoiceNo As String, ByVal _CustComplaint_Title As String, ByVal _CustComplaint_Desc As String, ByVal _CustComplaint_RCExt As String,
                                          ByVal _CustComplaint_RCInt As String, ByVal _CustComplaint_Action As String, ByVal _CustComplaint_Prevent As String, ByVal _CustComplaint_Feedback As String,
                                          ByVal Mode As String) As DataSet
        Dim sqlparams(15) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(2) = New SqlParameter("@CustComplaint_No", _CustComplaint_No)
            sqlparams(3) = New SqlParameter("@Product_Name", Product_Name)
            sqlparams(4) = New SqlParameter("@Acc_Name", Acc_Name)
            sqlparams(5) = New SqlParameter("@CustComplaint_BatchNo", _CustComplaint_BatchNo)
            sqlparams(6) = New SqlParameter("@CustComplaint_InvoiceNo", _CustComplaint_InvoiceNo)
            sqlparams(7) = New SqlParameter("@CustComplaint_Title", _CustComplaint_Title)
            sqlparams(8) = New SqlParameter("@CustComplaint_Desc", _CustComplaint_Desc)
            sqlparams(9) = New SqlParameter("@CustComplaint_RCExt", _CustComplaint_RCExt)
            sqlparams(10) = New SqlParameter("@CustComplaint_RCInt", _CustComplaint_RCInt)
            sqlparams(12) = New SqlParameter("@CustComplaint_Action", _CustComplaint_Action)
            sqlparams(13) = New SqlParameter("@CustComplaint_Prevent", _CustComplaint_Prevent)
            sqlparams(14) = New SqlParameter("@CustComplaint_Feedback", _CustComplaint_Feedback)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
