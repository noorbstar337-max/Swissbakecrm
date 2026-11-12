Imports APPCODE.DAL

Public Class TaxBLL
    Private Shared _spname As String = "_spTax"

    Public Shared Function Insert(ByVal Tax_Name As String, ByVal Tax_Percentage As Double, ByVal Tax_Editable As Boolean,
                                  ByVal Tax_AddtoPrincipal As Boolean, ByVal Tax_Addtion As Boolean, ByVal Tax_Subtraction As Boolean,
                                  ByVal Tax_TaxOnPrincipal As Boolean, ByVal Tax_Tax As Boolean, ByVal Tax_AddtionalCharge As Boolean,
                                   ByVal Tax_SortOrder As Integer, ByVal Tax_CreatedID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(12) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Tax_Name", Tax_Name)
            sqlparams(2) = New SqlParameter("@Tax_Percentage", Tax_Percentage)
            sqlparams(3) = New SqlParameter("@Tax_Editable", Tax_Editable)
            sqlparams(4) = New SqlParameter("@Tax_AddtoPrincipal", Tax_AddtoPrincipal)
            sqlparams(5) = New SqlParameter("@Tax_Addtion", Tax_Addtion)
            sqlparams(6) = New SqlParameter("@Tax_Subtraction", Tax_Subtraction)
            sqlparams(7) = New SqlParameter("@Tax_TaxOnPrincipal", Tax_TaxOnPrincipal)
            sqlparams(8) = New SqlParameter("@Tax_Tax", Tax_Tax)
            sqlparams(9) = New SqlParameter("@Tax_AddtionalCharge", Tax_AddtionalCharge)
            sqlparams(10) = New SqlParameter("@Tax_SortOrder", Tax_SortOrder)
            sqlparams(11) = New SqlParameter("@Tax_CreatedID", Tax_CreatedID)
            sqlparams(12) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Update(ByVal Tax_Name As String, ByVal Tax_Percentage As Double, ByVal Tax_Editable As Boolean,
                                  ByVal Tax_AddtoPrincipal As Boolean, ByVal Tax_Addtion As Boolean, ByVal Tax_Subtraction As Boolean,
                                  ByVal Tax_TaxOnPrincipal As Boolean, ByVal Tax_Tax As Boolean, ByVal Tax_AddtionalCharge As Boolean,
                                   ByVal Tax_SortOrder As Integer, ByVal Tax_ModifiedID As Integer, ByVal Tax_Id As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(13) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Tax_Name", Tax_Name)
            sqlparams(2) = New SqlParameter("@Tax_Percentage", Tax_Percentage)
            sqlparams(3) = New SqlParameter("@Tax_Editable", Tax_Editable)
            sqlparams(4) = New SqlParameter("@Tax_AddtoPrincipal", Tax_AddtoPrincipal)
            sqlparams(5) = New SqlParameter("@Tax_Addtion", Tax_Addtion)
            sqlparams(6) = New SqlParameter("@Tax_Subtraction", Tax_Subtraction)
            sqlparams(7) = New SqlParameter("@Tax_TaxOnPrincipal", Tax_TaxOnPrincipal)
            sqlparams(8) = New SqlParameter("@Tax_Tax", Tax_Tax)
            sqlparams(9) = New SqlParameter("@Tax_AddtionalCharge", Tax_AddtionalCharge)
            sqlparams(10) = New SqlParameter("@Tax_SortOrder", Tax_SortOrder)
            sqlparams(11) = New SqlParameter("@Tax_ModifiedID", Tax_ModifiedID)
            sqlparams(12) = New SqlParameter("@Tax_Id", Tax_Id)
            sqlparams(13) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
