Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Services

Partial Class VBCode
  Inherits System.Web.UI.Page
	Protected Sub Page_Load(sender As Object, e As EventArgs)

	End Sub
	<WebMethod> _
	Public Shared Function GetChartData() As List(Of countrydetails)
        Dim dt As New DataTable()
        'dt = DashBoardBILL.ViewById("LeadByIndustryByTeam", "")
        dt = DashBoardBLL.ViewById("LeadByIndustryByTeam", "", DateTime.Now.ToString(), DateTime.Now.ToString())

        Dim dataList As New List(Of countrydetails)()

		For Each dtrow As DataRow In dt.Rows
			Dim details As New countrydetails()
            details.Industry_Name = dtrow(1).ToString()
            details.lead_id = Convert.ToInt32(dtrow(0))
            dataList.Add(details)
        Next
        Return dataList
    End Function
End Class
Public Class countrydetails
    Public Property Industry_Name() As String
        Get
            Return m_Industry_Name
        End Get
        Set(value As String)
            m_Industry_Name = Value
        End Set
    End Property
    Private m_Industry_Name As String
    Public Property lead_id() As Integer
        Get
            Return m_lead_id
        End Get
        Set(value As Integer)
            m_lead_id = Value
        End Set
    End Property
    Private m_lead_id As Integer
End Class
