Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class DSRReportBLL
    Public Shared Function FillDSRReport(ByVal ID As Integer, ByVal CompanyID As Integer, ByVal Type As String, ByVal FromDate As String, ByVal ToDate As String, ByVal Mode As String) As DataSet
        ' Public Shared Function FillDSRReport(ByVal ID As Integer, ByVal CompanyID As Integer, ByVal FromDate As String, ByVal ToDate As String, ByVal Mode As String) As DataSet
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            'sqlparams(1) = New SqlParameter("@PageIndex", PageIndex)
            'sqlparams(2) = New SqlParameter("@PageSize", PageSize)
            sqlparams(1) = New SqlParameter("@FromDate", FromDate)
            sqlparams(2) = New SqlParameter("@ToDate", ToDate)
            sqlparams(3) = New SqlParameter("@User_Id", ID)
            sqlparams(4) = New SqlParameter("@CompanyID", CompanyID)
            sqlparams(5) = New SqlParameter("@Type", Type)
            Return DBBridge.ExecuteDataset("_spReport", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
	Public Shared Function CompanyDropdownById(ByVal Mode As String, ByVal ID As Integer) As DataSet
		Dim sqlparams(1) As SqlParameter
		Try
			sqlparams(0) = New SqlParameter("@Mode", Mode)
			sqlparams(1) = New SqlParameter("@ID", ID)
			Return DBBridge.ExecuteDataset("_spReport", sqlparams)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Shared Function CompanyDropdownById(ByVal Mode As String, ByVal ID As Integer, ByVal type As String) As DataSet
		Dim sqlparams(3) As SqlParameter
		Try
			sqlparams(0) = New SqlParameter("@Mode", Mode)
			sqlparams(1) = New SqlParameter("@ID", ID)
			sqlparams(2) = New SqlParameter("@type", type)
			Return DBBridge.ExecuteDataset("_spReport", sqlparams)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Shared Function UserDropdown(ByVal Mode As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)

			Return DBBridge.ExecuteDataset("_spReport", sqlparams)
		Catch ex As Exception
            Throw ex
        End Try
    End Function
    '========Copied From SampleBLL
    Public Shared Function Dropdown(ByVal Mode As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)

			Return DBBridge.ExecuteDataset("_spReport", sqlparams)
		Catch ex As Exception
            Throw ex
        End Try
    End Function
	Public Shared Function FillSampleReqReport(ByVal ID As Integer, ByVal FromDate As String, ByVal ToDate As String, ByVal CompanyID As Integer, ByVal Type As String, ByVal ProdID As Integer, ByVal SampleRequest_SampleStatus As String, ByVal Mode As String) As DataSet
		'Public Shared Function FillSampleReqReport(ByVal ID As Integer, ByVal FromDate As String, ByVal ToDate As String, ByVal Mode As String) As DataSet
		' Public Shared Function FillDSRReport(ByVal ID As Integer, ByVal CompanyID As Integer, ByVal Type As String, ByVal FromDate As String, ByVal ToDate As String, ByVal Mode As String) As DataSet
		Dim sqlparams(8) As SqlParameter
		Try
			sqlparams(0) = New SqlParameter("@Mode", Mode)
			'sqlparams(1) = New SqlParameter("@PageIndex", PageIndex)
			'sqlparams(2) = New SqlParameter("@PageSize", PageSize)
			sqlparams(1) = New SqlParameter("@FromDate", FromDate)
			sqlparams(2) = New SqlParameter("@ToDate", ToDate)
			If ID = 0 Then
				sqlparams(3) = New SqlParameter("@User_Id", DBNull.Value)
			Else
				sqlparams(3) = New SqlParameter("@User_Id", ID)
			End If
			sqlparams(4) = New SqlParameter("@CompanyID", CompanyID)
			If Type = "None" Then
				sqlparams(5) = New SqlParameter("@Type", DBNull.Value)
			Else
				sqlparams(5) = New SqlParameter("@Type", Type)
			End If
			If ProdID = 0 Then
				sqlparams(6) = New SqlParameter("@ProductID", DBNull.Value)
			Else
				sqlparams(6) = New SqlParameter("@ProductID", ProdID)
			End If
			If SampleRequest_SampleStatus = "None" Then
				sqlparams(7) = New SqlParameter("@SampleRequest_SampleStatus", DBNull.Value)
			Else
				sqlparams(7) = New SqlParameter("@SampleRequest_SampleStatus", SampleRequest_SampleStatus)
			End If

            Return DBBridge.ExecuteDataset("_spReport1", sqlparams)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

End Class
