Imports DynamicparcelEnumerations

Partial Class LiveRate
    'Inherits System.Web.UI.Page
    Inherits _PageBaseClass

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                fillUser()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillUser()
        Try


            rptDomesticRate.DataSource = reportBLL.LiveRate("LiveRate", "Domestic")
            Dim ds As DataSet = rptDomesticRate.DataSource
            Dim dtNew As New DataTable
            dtNew = ds.Tables(0)

            rptDomesticRate.DataBind()

            Dim FooterTemplate As Control = rptDomesticRate.Controls(rptDomesticRate.Controls.Count - 1).Controls(0)
            Dim lblDomclp As Label = TryCast(FooterTemplate.FindControl("lblDomclp"), Label)
            Dim lblDomdlp As Label = TryCast(FooterTemplate.FindControl("lblDomdlp"), Label)
            Dim trFooter As HtmlTableRow = TryCast(FooterTemplate.FindControl("trFooter"), HtmlTableRow)

            If ds.Tables(0).Rows.Count > 0 Then
                lblDomclp.Text = CDbl(dtNew.Compute("Sum(Product_Rate)", String.Empty)).ToString("N2")
                lblDomdlp.Text = CDbl(dtNew.Compute("Sum(DLP)", String.Empty)).ToString("N2")
            Else
                trFooter.Visible = False
                lblfoot.Visible = True
            End If

            'If rptDomesticRate.Items.Count > 0 Then
            '    lblfoot.Visible = False
            'Else
            '    lblfoot.Visible = True
            'End If

            rptExportRate.DataSource = reportBLL.LiveRate("LiveRate", "Export")
            Dim ds1 As DataSet = rptExportRate.DataSource
            Dim dtNew1 As New DataTable
            dtNew1 = ds1.Tables(0)
            rptExportRate.DataBind()

            Dim FooterTemplate1 As Control = rptExportRate.Controls(rptExportRate.Controls.Count - 1).Controls(0)
            Dim lblExpoclp As Label = TryCast(FooterTemplate1.FindControl("lblExpoclp"), Label)
            Dim lblExpodlp As Label = TryCast(FooterTemplate1.FindControl("lblExpodlp"), Label)
            Dim trFooter1 As HtmlTableRow = TryCast(FooterTemplate1.FindControl("trFooter1"), HtmlTableRow)

            If ds1.Tables(0).Rows.Count > 0 Then
                lblExpoclp.Text = CDbl(dtNew1.Compute("Sum(Product_Rate)", String.Empty)).ToString("N2")
                lblExpodlp.Text = CDbl(dtNew1.Compute("Sum(DLP)", String.Empty)).ToString("N2")
            Else
                trFooter1.Visible = False
                lblfoot1.Visible = True
            End If
            'If rptExportRate.Items.Count > 0 Then
            '    lblNoDataExp.Visible = False
            'Else
            '    lblNoDataExp.Visible = True
            'End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class
