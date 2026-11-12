Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class ProformaBLL
    Private Shared _spname As String = "_spProforma"

    Public Shared Function Insert(ByVal Type As String, ByVal TypeID As Integer, ByVal Dates As Date, ByVal Term_Condition As String,
                                  ByVal Pdf As String, ByVal OwnerID As Integer, ByVal Amount As Double, ByVal PayableAmount As Double, ByVal CreatedID As Integer,
                                  ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(10) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Proforma_Type", Type)
            sqlparams(2) = New SqlParameter("@Proforma_TypeID", TypeID)
            sqlparams(3) = New SqlParameter("@Proforma_Date", Dates)
            sqlparams(4) = New SqlParameter("@Proforma_Term_Condition", Term_Condition)
            sqlparams(5) = New SqlParameter("@Proforma_Pdf", Pdf)
            sqlparams(6) = New SqlParameter("@Proforma_OwnerID", OwnerID)
            sqlparams(7) = New SqlParameter("@Proforma_QuotAmount", Amount)
            sqlparams(8) = New SqlParameter("@Proforma_PayableNow", PayableAmount)
            sqlparams(9) = New SqlParameter("@Proforma_CreatedID", CreatedID)
            sqlparams(10) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Public Shared Function Update(ByVal Dates As Date, ByVal Term_Condition As String, ByVal Pdf As String, ByVal PayableAmount As Double,
    '                              ByVal ModifiedID As Integer, ByVal AudtTrail_LogId As Integer, ByVal ID As Integer) As Integer
    '    Dim sqlparams(7) As SqlParameter
    '    Try
    '        sqlparams(0) = New SqlParameter("@Mode", "Update")
    '        sqlparams(1) = New SqlParameter("@Proforma_Date", Dates)
    '        sqlparams(2) = New SqlParameter("@Proforma_Term_Condition", Term_Condition)
    '        sqlparams(3) = New SqlParameter("@Proforma_Pdf", Pdf)
    '        sqlparams(4) = New SqlParameter("@Proforma_PayableNow", PayableAmount)
    '        sqlparams(5) = New SqlParameter("@Proforma_ModifiedID", ModifiedID)
    '        sqlparams(6) = New SqlParameter("@Proforma_Id", ID)
    '        sqlparams(7) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
    '        Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Public Shared Function Update(ByVal Dates As Date, ByVal PayableAmount As Double,
                                  ByVal ModifiedID As Integer, ByVal AudtTrail_LogId As Integer, ByVal ID As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Update")
            sqlparams(1) = New SqlParameter("@Proforma_Date", Dates)
            sqlparams(2) = New SqlParameter("@Proforma_PayableNow", PayableAmount)
            sqlparams(3) = New SqlParameter("@Proforma_ModifiedID", ModifiedID)
            sqlparams(4) = New SqlParameter("@Proforma_Id", ID)
            sqlparams(5) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Shared Function UpdatePdf(ByVal Pdf As String, ByVal ID As Integer) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdatePdf")
            sqlparams(1) = New SqlParameter("@Proforma_Pdf", Pdf)
            sqlparams(2) = New SqlParameter("@Proforma_Id", ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DeleteProforma(ByVal ID As Integer) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "DeleteProforma")
            sqlparams(1) = New SqlParameter("@Proforma_Id", ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ProfromaByType(ByVal Type As String, ByVal TypeID As Integer, ByVal OwnerID As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ProfromaByType")
            sqlparams(1) = New SqlParameter("@Proforma_Type", Type)
            sqlparams(2) = New SqlParameter("@Proforma_TypeID", TypeID)
            sqlparams(3) = New SqlParameter("@Proforma_OwnerID", OwnerID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function crystalProforma(ByVal mode As String, ByVal TypeID As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", mode)

            sqlparams(2) = New SqlParameter("@Proforma_TypeID", TypeID)

            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function Proformatype(ByVal TypeID As Integer) As String
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Proformatype")

            sqlparams(1) = New SqlParameter("@Proforma_TypeID", TypeID)

            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
