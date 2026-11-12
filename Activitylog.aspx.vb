
Imports System

Partial Class Activitylog
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindLog()
        End If
    End Sub

    Private Sub BindLog()
        Using con As New SqlConnection(
            ConfigurationManager.ConnectionStrings("connectionString").ConnectionString)

            'Dim sql As String = "
            '    SELECT TOP 200 *
            '    FROM ActivityLog
            '    ORDER BY CreatedDate DESC
            '"
            Dim sql As String =
    "SELECT TOP 200 * " &
    "FROM ActivityLog " &
    "ORDER BY CreatedOn DESC"

            Using da As New SqlDataAdapter(sql, con)
                Dim dt As New DataTable
                da.Fill(dt)
                gvActivityLog.DataSource = dt
                gvActivityLog.DataBind()
            End Using
        End Using
    End Sub
End Class
