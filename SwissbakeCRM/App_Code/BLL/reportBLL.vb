Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class reportBLL
    'Private Shared _spname As String = "_spReport"
    Private Shared _spname As String = "_spReport1"

    Public Shared Function topaccount() As DataSet
        Dim sqlparams(0) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "TopAccountFromBegning")
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function topproduct() As DataSet
        Dim sqlparams(0) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "TopProductFromBegning")
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function productaccountdate(ByVal ProductId As Integer, ByVal StartDate As String, ByVal EndDate As String) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ProductAccountDate")
            sqlparams(1) = New SqlParameter("@ProductId", ProductId)
            sqlparams(2) = New SqlParameter("@StartDate", StartDate)
            sqlparams(3) = New SqlParameter("@EndDate", EndDate)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function productaccount(ByVal ProductId As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ProductAccount")
            sqlparams(1) = New SqlParameter("@ProductId", ProductId)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function TopAccountInPeriod(ByVal StartDate As String, ByVal EndDate As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "TopAccountInPeriod")
            sqlparams(1) = New SqlParameter("@StartDate", StartDate)
            sqlparams(2) = New SqlParameter("@EndDate", EndDate)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function TopProductInPeriod(ByVal StartDate As String, ByVal EndDate As String) As Object
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "TopProductInPeriod")
            sqlparams(1) = New SqlParameter("@StartDate", StartDate)
            sqlparams(2) = New SqlParameter("@EndDate", EndDate)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function TopAccountInPeriodSearch(ByVal StartDate As String, ByVal EndDate As String, ByVal val As String) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "TopAccountInPeriodSearch")
            sqlparams(1) = New SqlParameter("@StartDate", StartDate)
            sqlparams(2) = New SqlParameter("@EndDate", EndDate)
            sqlparams(3) = New SqlParameter("@val", val)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function TopProductInPeriodSearch(ByVal StartDate As String, ByVal EndDate As String, ByVal val As String) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "TopProductInPeriodSearch")
            sqlparams(1) = New SqlParameter("@StartDate", StartDate)
            sqlparams(2) = New SqlParameter("@EndDate", EndDate)
            sqlparams(3) = New SqlParameter("@val", val)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function TopAccountInPeriodSearchnoDate(ByVal val As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "TopAccountInPeriodSearchnoDate")
            sqlparams(1) = New SqlParameter("@val", val)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function TopProductInPeriodSearchnoDate(ByVal val As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "TopProductInPeriodSearchnoDate")
            sqlparams(1) = New SqlParameter("@val", val)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillProductGrid(ByVal StartDate As String, ByVal EndDate As String, ByVal CategoryId As Integer, ByVal productId As Integer) As DataSet
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ProductWiseReport")
            sqlparams(1) = New SqlParameter("@StartDate", StartDate)
            sqlparams(2) = New SqlParameter("@EndDate", EndDate)
            sqlparams(3) = New SqlParameter("@Product_CategoryId", CategoryId)
            sqlparams(4) = New SqlParameter("@Product_Id", productId)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function FillProductGrid(ByVal StartDate As String, ByVal EndDate As String, ByVal CategoryId As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ProductWiseReport")
            sqlparams(1) = New SqlParameter("@StartDate", StartDate)
            sqlparams(2) = New SqlParameter("@EndDate", EndDate)
            sqlparams(3) = New SqlParameter("@Product_CategoryId", CategoryId)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function FillProductGridByUser(ByVal StartDate As String, ByVal EndDate As String, ByVal UserId As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UserWiseReport")
            sqlparams(1) = New SqlParameter("@StartDate", StartDate)
            sqlparams(2) = New SqlParameter("@EndDate", EndDate)
            sqlparams(3) = New SqlParameter("@Acc_Id", UserId)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '' =================== Added by MUBYN =============== Starts 30-01-2018
    'Public Shared Function FillDSRReport(ByVal ID As Integer, ByVal CompanyID As Integer, ByVal Type As String, ByVal FromDate As String, ByVal ToDate As String, ByVal Mode As String) As DataSet       '-------By MUBYN
    '	Dim sqlparams(6) As SqlParameter
    '	Try
    '		sqlparams(0) = New SqlParameter("@Mode", Mode)
    '		sqlparams(1) = New SqlParameter("@FromDate", FromDate)
    '		sqlparams(2) = New SqlParameter("@ToDate", ToDate)
    '		sqlparams(3) = New SqlParameter("@User_Id", ID)
    '		sqlparams(4) = New SqlParameter("@CompanyID", CompanyID)
    '		sqlparams(5) = New SqlParameter("@Type", Type)
    '		Return DBBridge.ExecuteDataset("_spReport", sqlparams)
    '	Catch ex As Exception
    '		Throw ex
    '	End Try
    'End Function
    'Public Shared Function FillDSRReport(ByVal ID As Integer, ByVal CompanyID As Integer, ByVal Type As String, ByVal FromDate As String, ByVal ToDate As String, ByVal Mode As String, ByVal lead_name As String) As DataSet       '-------By MUBYN
    '	Dim sqlparams(6) As SqlParameter
    '	Try
    '		sqlparams(0) = New SqlParameter("@Mode", Mode)
    '		sqlparams(1) = New SqlParameter("@FromDate", FromDate)
    '		sqlparams(2) = New SqlParameter("@ToDate", ToDate)
    '		sqlparams(3) = New SqlParameter("@User_Id", ID)
    '		sqlparams(4) = New SqlParameter("@CompanyID", CompanyID)
    '		sqlparams(5) = New SqlParameter("@Type", Type)
    '		sqlparams(5) = New SqlParameter("@lead_name", lead_name)
    '		Return DBBridge.ExecuteDataset("_spReport", sqlparams)
    '	Catch ex As Exception
    '		Throw ex
    '	End Try
    'End Function
    ' =================== Added by MUBYN =============== Starts 30-01-2018
    Public Shared Function FillDSRReport(ByVal ID As Integer, ByVal CompanyID As Integer, ByVal Type As String, ByVal FromDate As String, ByVal ToDate As String, ByVal Mode As String) As DataSet       '-------By MUBYN
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@FromDate", FromDate)
            sqlparams(2) = New SqlParameter("@ToDate", ToDate)
            If ID = 0 Then
                sqlparams(3) = New SqlParameter("@User_Id", DBNull.Value)
            Else
                sqlparams(3) = New SqlParameter("@User_Id", ID)
            End If
            If CompanyID = 0 Then
                sqlparams(4) = New SqlParameter("@CompanyID", DBNull.Value)
            Else
                sqlparams(4) = New SqlParameter("@CompanyID", CompanyID)
            End If
            If Type = "type" Then
                sqlparams(5) = New SqlParameter("@Type", DBNull.Value)
            Else
                sqlparams(5) = New SqlParameter("@Type", Type)
            End If
            'Return DBBridge.ExecuteDataset("_spReport", sqlparams)
            Return DBBridge.ExecuteDataset("_spReport1", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function FillDSRReport(ByVal ID As Integer, ByVal CompanyID As Integer, ByVal Type As String, ByVal FromDate As String, ByVal ToDate As String, ByVal Mode As String, ByVal lead_name As String) As DataSet       '-------By MUBYN
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@FromDate", FromDate)
            sqlparams(2) = New SqlParameter("@ToDate", ToDate)
            If ID = 0 Then
                sqlparams(3) = New SqlParameter("@User_Id", DBNull.Value)
            Else
                sqlparams(3) = New SqlParameter("@User_Id", ID)
            End If
            sqlparams(4) = New SqlParameter("@CompanyID", CompanyID)
            If Type = "type" Then
                sqlparams(5) = New SqlParameter("@Type", DBNull.Value)
            Else
                sqlparams(5) = New SqlParameter("@Type", Type)
            End If
            sqlparams(5) = New SqlParameter("@lead_name", lead_name)
            Return DBBridge.ExecuteDataset("_spReport", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function CompanyDropdownById(ByVal Mode As String, ByVal ID As Integer) As DataSet   '-------By MUBYN
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)
            Return DBBridge.ExecuteDataset("_spReport", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function UserDropdown(ByVal Mode As String) As DataSet         '  LeadReport.aspx / DSRReport.aspx / SampleRequestReport.aspx-------By MUBYN/productreport.aspx altaf
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)

            Return DBBridge.ExecuteDataset("_spReport", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function LeadReportViewNew(ByVal Mode As String, ByVal StartDate As String, ByVal EndDate As String, ByVal AssignTo As Integer, ByVal Lead_Id As Integer,
                                           ByVal TypeId As Integer, ByVal Lead_Category As String, ByVal Lead_SourceID As Integer, ByVal Lead_StageID As Integer) As DataSet
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@StartDate", StartDate)
            sqlparams(2) = New SqlParameter("@EndDate", EndDate)
            If AssignTo = 0 Then
                sqlparams(3) = New SqlParameter("@U_ID", DBNull.Value)
            Else
                sqlparams(3) = New SqlParameter("@U_ID", AssignTo)
            End If
            If Lead_Id = 0 Then
                sqlparams(4) = New SqlParameter("@Lead_Id", DBNull.Value)
            Else
                sqlparams(4) = New SqlParameter("@Lead_Id", Lead_Id)
            End If
            If TypeId = -1 Then
                sqlparams(5) = New SqlParameter("@Lead_LeadTypeID", DBNull.Value)
            Else
                sqlparams(5) = New SqlParameter("@Lead_LeadTypeID", TypeId)
            End If
            If Lead_Category = "All" Then
                sqlparams(6) = New SqlParameter("@Lead_Category", DBNull.Value)
            Else
                sqlparams(6) = New SqlParameter("@Lead_Category", Lead_Category)
            End If
            If Lead_SourceID = -1 Then
                sqlparams(7) = New SqlParameter("@Lead_SourceID", DBNull.Value)
            Else
                sqlparams(7) = New SqlParameter("@Lead_SourceID", Lead_SourceID)
            End If
            'If Lead_SourceID = -1 Then
            '    sqlparams(8) = New SqlParameter("@Lead_SourceID", DBNull.Value)
            'Else
            sqlparams(8) = New SqlParameter("@Lead_StageID", Lead_StageID)
            'End If
            'Return DBBridge.ExecuteDataset("_spReport", sqlparams)
            Return DBBridge.ExecuteDataset("_spReport1", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ProspectReportViewNew(ByVal Mode As String, ByVal StartDate As String, ByVal EndDate As String, ByVal AssignTo As Integer, ByVal Acc_Id As Integer,
                                           ByVal TypeId As Integer, ByVal Acc_Category As String, ByVal Acc_SourceID As Integer) As DataSet
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@StartDate", StartDate)
            sqlparams(2) = New SqlParameter("@EndDate", EndDate)
            If AssignTo = 0 Then
                sqlparams(3) = New SqlParameter("@U_ID", DBNull.Value)
            Else
                sqlparams(3) = New SqlParameter("@U_ID", AssignTo)
            End If
            If Acc_Id = 0 Then
                sqlparams(4) = New SqlParameter("@companyid", DBNull.Value)
            Else
                sqlparams(4) = New SqlParameter("@companyid", Acc_Id)
            End If
            If TypeId = -1 Then
                'sqlparams(5) = New SqlParameter("@Acc_CompanyTypeID", DBNull.Value)' BY Mubyn
                sqlparams(5) = New SqlParameter("@Industry_Id", DBNull.Value)
            Else
                'sqlparams(5) = New SqlParameter("@Acc_CompanyTypeID", TypeId)' BY Mubyn
                sqlparams(5) = New SqlParameter("@Industry_Id", TypeId)
            End If
            If Acc_Category = "All" Then
                sqlparams(6) = New SqlParameter("@Acc_Category", DBNull.Value)
            Else
                sqlparams(6) = New SqlParameter("@Acc_Category", Acc_Category)
            End If
            If Acc_SourceID = -1 Then
                sqlparams(7) = New SqlParameter("@Acc_SourceID", DBNull.Value)
            Else
                sqlparams(7) = New SqlParameter("@Acc_SourceID", Acc_SourceID)
            End If
            'If Lead_SourceID = -1 Then
            '    sqlparams(8) = New SqlParameter("@Lead_SourceID", DBNull.Value)
            'Else
            '	sqlparams(8) = New SqlParameter("@Lead_StageID", Acc_StageID)
            'End If
            'Return DBBridge.ExecuteDataset("_spReport", sqlparams)
            Return DBBridge.ExecuteDataset("_spReport1", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function LeadReportCount(ByVal Mode As String, ByVal StartDate As String, ByVal EndDate As String, ByVal AssignTo As Integer, ByVal Lead_Id As Integer,
                                              ByVal TypeId As Integer, ByVal Lead_Category As String, ByVal Lead_SourceID As Integer, ByVal Lead_StageID As Integer) As DataSet
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@StartDate", StartDate)
            sqlparams(2) = New SqlParameter("@EndDate", EndDate)
            If AssignTo = 0 Then
                sqlparams(3) = New SqlParameter("@U_ID", DBNull.Value)
            Else
                sqlparams(3) = New SqlParameter("@U_ID", AssignTo)
            End If
            If Lead_Id = 0 Then
                sqlparams(4) = New SqlParameter("@Lead_Id", DBNull.Value)
            Else
                sqlparams(4) = New SqlParameter("@Lead_Id", Lead_Id)
            End If
            If TypeId = -1 Then
                sqlparams(5) = New SqlParameter("@Lead_LeadTypeID", DBNull.Value)
            Else
                sqlparams(5) = New SqlParameter("@Lead_LeadTypeID", TypeId)
            End If
            If Lead_Category = "All" Then
                sqlparams(6) = New SqlParameter("@Lead_Category", DBNull.Value)
            Else
                sqlparams(6) = New SqlParameter("@Lead_Category", Lead_Category)
            End If
            If Lead_SourceID = -1 Then
                sqlparams(7) = New SqlParameter("@Lead_SourceID", DBNull.Value)
            Else
                sqlparams(7) = New SqlParameter("@Lead_SourceID", Lead_SourceID)
            End If
            'If Lead_SourceID = -1 Then
            '    sqlparams(8) = New SqlParameter("@Lead_SourceID", DBNull.Value)
            'Else
            sqlparams(8) = New SqlParameter("@Lead_StageID", Lead_StageID)
            'End If
            Return DBBridge.ExecuteDataset("_spReport", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function AccountReportCount(ByVal Mode As String, ByVal StartDate As String, ByVal EndDate As String, ByVal AssignTo As Integer) As DataSet
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@StartDate", StartDate)
            sqlparams(2) = New SqlParameter("@EndDate", EndDate)
            If AssignTo = 0 Then
                sqlparams(3) = New SqlParameter("@U_ID", DBNull.Value)
            Else
                sqlparams(3) = New SqlParameter("@U_ID", AssignTo)
            End If
            'If Lead_Id = 0 Then
            '	sqlparams(4) = New SqlParameter("@Lead_Id", DBNull.Value)
            'Else
            '	sqlparams(4) = New SqlParameter("@Lead_Id", Lead_Id)
            'End If
            'If TypeId = -1 Then
            '	sqlparams(5) = New SqlParameter("@Lead_LeadTypeID", DBNull.Value)
            'Else
            '	sqlparams(5) = New SqlParameter("@Lead_LeadTypeID", TypeId)
            'End If
            'If Lead_Category = "All" Then
            '	sqlparams(6) = New SqlParameter("@Lead_Category", DBNull.Value)
            'Else
            '	sqlparams(6) = New SqlParameter("@Lead_Category", Lead_Category)
            'End If
            'If Lead_SourceID = -1 Then
            '	sqlparams(7) = New SqlParameter("@Lead_SourceID", DBNull.Value)
            'Else
            '	sqlparams(7) = New SqlParameter("@Lead_SourceID", Lead_SourceID)
            'End If
            'If Lead_SourceID = -1 Then
            '    sqlparams(8) = New SqlParameter("@Lead_SourceID", DBNull.Value)
            'Else
            'sqlparams(8) = New SqlParameter("@Lead_StageID", Lead_StageID)
            'End If
            Return DBBridge.ExecuteDataset("_spReport", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ProductSRReportDD(ByVal _Discount_CustId As Integer, ByVal Type As String) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ProductSRReportDD")

            sqlparams(1) = New SqlParameter("@Discount_CustId", _Discount_CustId)
            sqlparams(2) = New SqlParameter("@Type", Type)
            Return DBBridge.ExecuteDataset("_spReport", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function LeadDropdownById(ByVal Mode As String, ByVal ID As Integer) As DataSet   '-------By MUBYN
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)
            Return DBBridge.ExecuteDataset("_spReport", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' =================== Added by MUBYN =============== Ends 30-01-2018
    Public Shared Function ProspectDropdownById(ByVal Mode As String, ByVal ID As Integer) As DataSet   '-------By MUBYN
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            If ID = 0 Then
                sqlparams(1) = New SqlParameter("@ID", DBNull.Value)
            Else
                sqlparams(1) = New SqlParameter("@ID", ID)
            End If

            Return DBBridge.ExecuteDataset("_spReport", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function LeadReportCount1(ByVal Mode As String, ByVal StartDate As String, ByVal EndDate As String, ByVal AssignTo As Integer) As String
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@StartDate", StartDate)
            sqlparams(2) = New SqlParameter("@EndDate", EndDate)
            sqlparams(3) = New SqlParameter("@U_ID", AssignTo)
            Return DBBridge.ExecuteScalar("_spReport", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function DropdownByID(ByVal Mode As String, ByVal ID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)
            Return DBBridge.ExecuteDataset("_spReport", sqlparams)
        Catch ex As Exception
            Throw ex
            'Productreport.aspx add by Altaf 8-mar-18
        End Try
    End Function
    Public Shared Function FillProductReport(ByVal ID As Integer, ByVal FromDate As String, ByVal ToDate As String, ByVal CompanyID As Integer,
                                             ByVal Type As String, ByVal ProdID As Integer, ByVal SampleRequest_SampleStatus As String, ByVal Mode As String) As DataSet
        Dim sqlparams(8) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@StartDate", FromDate)
            sqlparams(2) = New SqlParameter("@EndDate", ToDate)
            If ID = 0 Then
                sqlparams(3) = New SqlParameter("@U_Id", DBNull.Value)
            Else
                sqlparams(3) = New SqlParameter("@U_Id", ID)
            End If
            If CompanyID = 0 Then
                sqlparams(4) = New SqlParameter("@Acc_Id", DBNull.Value)
            Else
                sqlparams(4) = New SqlParameter("@Acc_Id", CompanyID)
            End If
            If Type = 0 Then
                sqlparams(5) = New SqlParameter("@Product_CategoryId", DBNull.Value)
            Else
                sqlparams(5) = New SqlParameter("@Product_CategoryId", Type)
            End If
            If ProdID = 0 Then
                sqlparams(6) = New SqlParameter("@Product_Id", DBNull.Value)
            Else
                sqlparams(6) = New SqlParameter("@Product_Id", ProdID)
            End If
            If SampleRequest_SampleStatus = "None" Then
                sqlparams(7) = New SqlParameter("@SampleRequest_SampleStatus", DBNull.Value)
            Else
                sqlparams(7) = New SqlParameter("@SampleRequest_SampleStatus", SampleRequest_SampleStatus)
            End If

            'Return DBBridge.ExecuteDataset("_spReport", sqlparams)
            Return DBBridge.ExecuteDataset("_spReport1", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function topproduct(ByVal Product_Id As Integer, ByVal FromDate As String, ByVal ToDate As String) As DataSet
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "TopProductFromBegning")
            sqlparams(1) = New SqlParameter("@StartDate", FromDate)
            sqlparams(2) = New SqlParameter("@EndDate", ToDate)
            If Product_Id = 0 Then
                sqlparams(3) = New SqlParameter("@Product_Id", DBNull.Value)
            Else
                sqlparams(3) = New SqlParameter("@Product_Id", Product_Id)
            End If
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function Dropdown(ByVal Mode As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)

            Return DBBridge.ExecuteDataset("_spReport", sqlparams)
        Catch ex As Exception
            Throw ex
            ''topproduct.aspx by altaf 10-mar2018
        End Try
    End Function
    Public Shared Function FillgridOutstanding(ByVal Mode As String, ByVal id As Integer, ByVal acc_id As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            If id = 0 Then
                sqlparams(1) = New SqlParameter("@U_id", DBNull.Value)
            Else
                sqlparams(1) = New SqlParameter("@U_id", id)
            End If
            If acc_id = 0 Then
                sqlparams(2) = New SqlParameter("@Acc_id", DBNull.Value)
            Else
                sqlparams(2) = New SqlParameter("@Acc_id", acc_id)
            End If
            'Return DBBridge.ExecuteDataset("_spReport", sqlparams)
            Return DBBridge.ExecuteDataset("_spReport1", sqlparams)
        Catch ex As Exception
            Throw ex
            ''topproduct.aspx by altaf 10-mar2018
        End Try
    End Function


    Public Shared Function LiveRate(ByVal Mode As String, ByVal Product_ForType As String) As DataSet            '--Created by MUBYN used in LiveRate.aspx 28-03-2018
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Product_ForType", Product_ForType)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillProdRep(ByVal Product_ForType As String) As DataSet              '--Created by MUBYN used in ProductsReport.aspx 28-03-2018
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ProductsReport")
            sqlparams(1) = New SqlParameter("@Product_ForType", Product_ForType)
            '  sqlparams(2) = New SqlParameter("@EndDate", EndDate)
            'sqlparams(3) = New SqlParameter("@Product_CategoryId", CategoryId)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillPriceList(ByVal ProductId As Integer, ByVal Product_ForType As String) As DataSet              '--Created by MUBYN used in ProductWisePriceList.aspx 28-03-2018
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ProductWisePriceList")
            sqlparams(1) = New SqlParameter("@ProductId", ProductId)
            sqlparams(2) = New SqlParameter("@Product_ForType", Product_ForType)
            ' sqlparams(3) = New SqlParameter("@Order", Order)

            '  sqlparams(2) = New SqlParameter("@EndDate", EndDate)
            'sqlparams(3) = New SqlParameter("@Product_CategoryId", CategoryId)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function FillPriceList(ByVal ProductId As Integer, ByVal Product_ForType As String, ByVal Order As String) As DataSet              '--Created by MUBYN used in ProductWisePriceList.aspx 28-03-2018
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ProductWisePriceList")
            sqlparams(1) = New SqlParameter("@ProductId", ProductId)
            sqlparams(2) = New SqlParameter("@Product_ForType", Product_ForType)
            sqlparams(3) = New SqlParameter("@Order", Order)

            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function FillProdName(ByVal ProductId As Integer) As DataSet              '--Created by MUBYN used in ProductWisePriceList.aspx 28-03-2018
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ProductNameByID")
            sqlparams(1) = New SqlParameter("@ProductId", ProductId)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '--Created by MUBYN used in ProductWisePriceList.aspx 27-04-2018 called by multiple events
    Public Shared Function FillOrderReport(ByVal Mode As String, ByVal StartDate As String, ByVal EndDate As String, ByVal UserId As Integer, ByVal Order_type As String) As DataSet
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@StartDate", StartDate)
            sqlparams(2) = New SqlParameter("@EndDate", EndDate)
            If UserId = "0" Then
                sqlparams(3) = New SqlParameter("@Acc_Id", DBNull.Value)
            Else
                sqlparams(3) = New SqlParameter("@Acc_Id", UserId)
            End If
            If Order_type = "All" Then
                sqlparams(4) = New SqlParameter("@Order_type", DBNull.Value)
            Else
                sqlparams(4) = New SqlParameter("@Order_type", Order_type)
            End If
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function topproductExcel(ByVal Product_Id As Integer, ByVal FromDate As String, ByVal ToDate As String) As DataSet '-- Added by NILESH
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "TopProductFromBegningExcel")
            sqlparams(1) = New SqlParameter("@StartDate", FromDate)
            sqlparams(2) = New SqlParameter("@EndDate", ToDate)
            If Product_Id = 0 Then
                sqlparams(3) = New SqlParameter("@Product_Id", DBNull.Value)
            Else
                sqlparams(3) = New SqlParameter("@Product_Id", Product_Id)
            End If
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function NewAccReport(ByVal Mode As String, ByVal StartDate As String, ByVal EndDate As String, ByVal Owner As Integer, ByVal State_Id As Integer,
                                      ByVal Acc_Category As String, ByVal Acc_SourceID As Integer) As DataSet
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@StartDate", StartDate)
            sqlparams(2) = New SqlParameter("@EndDate", EndDate)
            If Owner = 0 Then
                sqlparams(3) = New SqlParameter("@U_ID", DBNull.Value)
            Else
                sqlparams(3) = New SqlParameter("@U_ID", Owner)
            End If
            If State_Id = 0 Then
                sqlparams(4) = New SqlParameter("@State_Id", DBNull.Value)
            Else
                sqlparams(4) = New SqlParameter("@State_Id", State_Id)
            End If
            If Acc_Category = "All" Then
                sqlparams(6) = New SqlParameter("@Acc_Category", DBNull.Value)
            Else
                sqlparams(6) = New SqlParameter("@Acc_Category", Acc_Category)
            End If
            If Acc_SourceID = -1 Then
                sqlparams(7) = New SqlParameter("@Acc_SourceID", DBNull.Value)
            Else
                sqlparams(7) = New SqlParameter("@Acc_SourceID", Acc_SourceID)
            End If

            Return DBBridge.ExecuteDataset("_spReport1", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function TopAccountReport(ByVal Mode As String, ByVal StartDate As String, ByVal EndDate As String) As DataSet
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@StartDate", StartDate)
            sqlparams(2) = New SqlParameter("@EndDate", EndDate)
            'sqlparams(3) = New SqlParameter("@val", Val)
            Return DBBridge.ExecuteDataset("_spReport1", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
	
	Public Shared Function FillOrderReport(ByVal Mode As String, ByVal StartDate As String, ByVal EndDate As String) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@StartDate", StartDate)
            sqlparams(2) = New SqlParameter("@EndDate", EndDate)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class