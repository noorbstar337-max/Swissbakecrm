Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class AccountBLL
    Private Shared _spname As String = "_spAccount"

    Public Shared Function ConvertLead(ByVal Type As String, ByVal CreatedID As Integer, ByVal AudtTrail_LogId As Integer, _ID As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ConvertLead")
            sqlparams(1) = New SqlParameter("@Acc_Type", Type)
            sqlparams(2) = New SqlParameter("@Acc_CreatedID", CreatedID)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(4) = New SqlParameter("@Acc_SourceID", _ID)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function GetAssignTo(ByVal Acc_Id As String) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "GetAssignTo")
            sqlparams(1) = New SqlParameter("@Assignto_TypeID", Acc_Id)
            sqlparams(2) = New SqlParameter("@Assignto_Type", "Account")

            Return DBBridge.ExecuteDataset("_spAssignTo", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function AccountSortingByAssign(ByVal ID As Integer, ByVal Type As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "AccountSortingByAssign")
            sqlparams(1) = New SqlParameter("@Acc_Id", ID)
            sqlparams(2) = New SqlParameter("@Acc_Type", Type)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function AccountSortingByOwner() As DataSet
        Dim sqlparams(0) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "AccountSortingByOwner")
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ConvertAccount(ByVal ID As Integer) As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ConvertProsToAccount")
            sqlparams(1) = New SqlParameter("@Acc_Id", ID)
            'sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function SortingProspectWithNoActivity(ByVal ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "SortingProspectWithNoActivity")
            sqlparams(1) = New SqlParameter("@Acc_Id", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ProspectAchivedSorting(ByVal ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ProspectAchivedSorting")
            sqlparams(1) = New SqlParameter("@Acc_Id", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function SortingAccountWithNoSales(ByVal ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "SortingAccountWithNoSales")
            sqlparams(1) = New SqlParameter("@Acc_Id", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function SortingAccountByMonth(ByVal ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "SortingAccountByMonth")
            sqlparams(1) = New SqlParameter("@Acc_Id", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Accview(ByVal ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Accview")
            sqlparams(1) = New SqlParameter("@Acc_Id", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateReason(ByVal ID As Integer, ByVal Reason As String) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateReason")
            sqlparams(1) = New SqlParameter("@acc_ID", ID)
            sqlparams(2) = New SqlParameter("@Acc_Description", Reason)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateOwner(ByVal ID As Integer, ByVal Acc_OwnerID As Integer, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateOwner")
            sqlparams(1) = New SqlParameter("@Acc_Id", ID)
            sqlparams(2) = New SqlParameter("@Acc_OwnerID", Acc_OwnerID)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    'gayatri created this on 18-08-2017 for ModifyQuotationPage to check type and fill currency accordingly. 
    Public Shared Function SelectCategoryByAccId(ByVal Acc_Id As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "SelectCategoryByAccId")
            sqlparams(1) = New SqlParameter("@Acc_Id", Acc_Id)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '==== Created by MUBYN used in SupportDashBoard.aspx 10-07-2018
    Public Shared Function SupportAccGridviewByPara(ByVal Mode As String, ByVal Acc_Code As String, ByVal Contact_ContactPerson As String, ByVal Acc_Name As String,
                                                 ByVal Contact_Mobile As String, ByVal Contact_WorkEmail As String, ByVal Order_Code As String,
                                                 ByVal Invoice_Number As String, ByVal Invoice_AWB As String) As DataSet
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            If Acc_Code = "" Then
                sqlparams(1) = New SqlParameter("@Acc_Code", DBNull.Value)
            Else
                sqlparams(1) = New SqlParameter("@Acc_Code", Acc_Code)
            End If
            'sqlparams(1) = New SqlParameter("@Acc_Type", Acc_Type)
            If Contact_ContactPerson = "" Then
                sqlparams(2) = New SqlParameter("@Contact_ContactPerson", DBNull.Value)
            Else
                sqlparams(2) = New SqlParameter("@Contact_ContactPerson", Contact_ContactPerson)
            End If
            If Acc_Name = "" Then
                sqlparams(3) = New SqlParameter("@Acc_Name", DBNull.Value)
            Else
                sqlparams(3) = New SqlParameter("@Acc_Name", Acc_Name)
            End If
            If Contact_Mobile = "" Then
                sqlparams(4) = New SqlParameter("@Contact_Mobile", DBNull.Value)
            Else
                sqlparams(4) = New SqlParameter("@Contact_Mobile", Contact_Mobile)
            End If
            If Contact_WorkEmail = "" Then
                sqlparams(5) = New SqlParameter("@Contact_WorkEmail", DBNull.Value)
            Else
                sqlparams(5) = New SqlParameter("@Contact_WorkEmail", Contact_WorkEmail)
            End If
            If Order_Code = "" Then
                sqlparams(6) = New SqlParameter("@Order_Code", DBNull.Value)
            Else
                sqlparams(6) = New SqlParameter("@Order_Code", Order_Code)
            End If
            If Invoice_Number = "" Then
                sqlparams(7) = New SqlParameter("@Invoice_Number", DBNull.Value)
            Else
                sqlparams(7) = New SqlParameter("@Invoice_Number", Invoice_Number)
            End If
            If Invoice_AWB = "" Then
                sqlparams(8) = New SqlParameter("@Invoice_AWB", DBNull.Value)
            Else
                sqlparams(8) = New SqlParameter("@Invoice_AWB", Invoice_AWB)
            End If
            'If Contact_Landline = "" Then
            '    sqlparams(6) = New SqlParameter("@Contact_Landline", DBNull.Value)
            'Else
            '    sqlparams(6) = New SqlParameter("@Contact_Landline", Contact_Landline)
            'End If
            'sqlparams(6) = New SqlParameter("@PageIndex", PageIndex)
            'sqlparams(7) = New SqlParameter("@PageSize", PageSize)
            Return DBBridge.ExecuteDataset("_spAccount", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function SupportAccTotalNumberOfRecord(ByVal Mode As String, ByVal Acc_Code As String, ByVal Contact_ContactPerson As String, ByVal Acc_Name As String,
                                                 ByVal Contact_Mobile As String, ByVal Contact_WorkEmail As String, ByVal Order_Code As String,
                                                 ByVal Invoice_Number As String, ByVal Invoice_AWB As String) As Integer
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            If Acc_Code = "" Then
                sqlparams(1) = New SqlParameter("@Acc_Code", DBNull.Value)
            Else
                sqlparams(1) = New SqlParameter("@Acc_Code", Acc_Code)
            End If
            'sqlparams(1) = New SqlParameter("@Acc_Type", Acc_Type)
            If Contact_ContactPerson = "" Then
                sqlparams(2) = New SqlParameter("@Contact_ContactPerson", DBNull.Value)
            Else
                sqlparams(2) = New SqlParameter("@Contact_ContactPerson", Contact_ContactPerson)
            End If
            If Acc_Name = "" Then
                sqlparams(3) = New SqlParameter("@Acc_Name", DBNull.Value)
            Else
                sqlparams(3) = New SqlParameter("@Acc_Name", Acc_Name)
            End If
            If Contact_Mobile = "" Then
                sqlparams(4) = New SqlParameter("@Contact_Mobile", DBNull.Value)
            Else
                sqlparams(4) = New SqlParameter("@Contact_Mobile", Contact_Mobile)
            End If
            If Contact_WorkEmail = "" Then
                sqlparams(5) = New SqlParameter("@Contact_WorkEmail", DBNull.Value)
            Else
                sqlparams(5) = New SqlParameter("@Contact_WorkEmail", Contact_WorkEmail)
            End If
            If Order_Code = "" Then
                sqlparams(6) = New SqlParameter("@Order_Code", DBNull.Value)
            Else
                sqlparams(6) = New SqlParameter("@Order_Code", Order_Code)
            End If
            If Invoice_Number = "" Then
                sqlparams(7) = New SqlParameter("@Invoice_Number", DBNull.Value)
            Else
                sqlparams(7) = New SqlParameter("@Invoice_Number", Invoice_Number)
            End If
            If Invoice_Number = "" Then
                sqlparams(8) = New SqlParameter("@Invoice_AWB", DBNull.Value)
            Else
                sqlparams(8) = New SqlParameter("@Invoice_AWB", Invoice_AWB)
            End If
            'If Contact_Landline = "" Then
            '    sqlparams(6) = New SqlParameter("@Contact_Landline", DBNull.Value)
            'Else
            '    sqlparams(6) = New SqlParameter("@Contact_Landline", Contact_Landline)
            'End If
            'sqlparams(6) = New SqlParameter("@PageIndex", PageIndex)
            'sqlparams(7) = New SqlParameter("@PageSize", PageSize)
            Return DBBridge.ExecuteScalar("_spAccount", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function GetAssignedOwner(ByVal AccId As Integer) As DataSet

        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "GetAssignedOwner")
            sqlparams(1) = New SqlParameter("@Acc_Id", AccId)

            Return DBBridge.ExecuteDataset("_spAccount", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ClearAccountOwners(ByVal ID As Integer) As Integer

        Dim sqlparams(1) As SqlParameter

        Try
            sqlparams(0) = New SqlParameter("@Mode", "ClearAccountOwners")
            sqlparams(1) = New SqlParameter("@Acc_Id", ID)

            Return DBBridge.ExecuteScalar(_spname, sqlparams)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class
