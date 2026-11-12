Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class ExecptionBLL
    Private Shared _spname As String = "_spSupExceptions"

    Public Shared Function Insert(ByVal _Formname As String, ByVal _MethodNmae As String, ByVal _Execption_ErrorMessage As String,
                                   ByVal _Execption_UserId As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Execption_FormName", _Formname)
            sqlparams(2) = New SqlParameter("@Execption_MethodName", _MethodNmae)
            sqlparams(3) = New SqlParameter("@Execption_ErrorMessage", _Execption_ErrorMessage)
            sqlparams(4) = New SqlParameter("@Execption_UserId", _Execption_UserId)
            If Not _Execption_ErrorMessage = "Thread was being aborted." Then
                Return DBBridge.ExecuteScalar(_spname, sqlparams)
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
