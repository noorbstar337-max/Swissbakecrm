Imports Microsoft.VisualBasic
Imports APPCODE.DAL
Public Class EnquiryBLL
    Private Shared _spname As String = "_spEnquiry"


    Public Shared Function Insert(ByVal ENQ_Name As String, ByVal ENQ_EmailID As String, ByVal ENQ_MobileNumber As String, ByVal ENQ_Enquiry As String, ByVal ENQ_MemberID As Integer) As Integer
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@ENQ_Name", ENQ_Name)
            sqlparams(2) = New SqlParameter("@ENQ_EmailID", ENQ_EmailID)
            sqlparams(3) = New SqlParameter("@ENQ_MobileNumber", ENQ_MobileNumber)
            sqlparams(4) = New SqlParameter("@ENQ_Enquiry", ENQ_Enquiry)
            sqlparams(5) = New SqlParameter("@ENQ_MemberID", ENQ_MemberID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
