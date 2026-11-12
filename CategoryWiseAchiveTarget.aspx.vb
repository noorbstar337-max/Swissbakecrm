
Partial Class CategoryWiseAchiveTarget
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        filltarget()
    End Sub

    Public Sub filltarget()
        Dim ds As DataSet = SalesTargetBLL.NewSalesTargetDetail(Session("DUserId"))
        If ds.Tables.Count > 0 Then
            rptIndividual.DataSource = ds.Tables(2)
            rptIndividual.DataBind()
            rptTeam.DataSource = ds.Tables(5)
            rptTeam.DataBind()

            ltsalesachivedIndividual.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(0)(0))).ToString("N2")
            If ds.Tables.Count >= 1 Then
                If ds.Tables(1).Rows.Count > 0 Then
                    ltsalestargetIndividual.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(1).Rows(0)(0))).ToString("N2")
                End If
            End If
            If ds.Tables.Count >= 4 Then
                If ds.Tables(4).Rows.Count > 0 Then
                    ltsalesachivedTeam.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(4).Rows(0)(0))).ToString("N2")
                End If
            End If
            If ds.Tables.Count >= 3 Then
                If ds.Tables(4).Rows.Count > 0 Then
                    ltsalestargetTeam.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(3).Rows(0)(0))).ToString("N2")
                End If
            End If
            If Not String.IsNullOrEmpty(ltsalesachivedIndividual.Text) And Not String.IsNullOrEmpty(ltsalestargetIndividual.Text) Then
                If ltsalestargetIndividual.Text = "0" Then
                    divsaleschart.Attributes.Add("data-percent", "0")
                    'ltsalespercentageIndividual.Text += " %"
                Else
                    ltsalespercentageIndividual.Text = Math.Round((Convert.ToDouble(ltsalesachivedIndividual.Text) / Convert.ToDouble(ltsalestargetIndividual.Text)) * 100).ToString
                    divsaleschart.Attributes.Add("data-percent", ltsalespercentageIndividual.Text)
                    ltsalespercentageIndividual.Text += " %"
                End If
            End If
            If Not String.IsNullOrEmpty(ltsalesachivedTeam.Text) And Not String.IsNullOrEmpty(ltsalestargetTeam.Text) Then
                If ltsalestargetTeam.Text = "0" Then
                    divsaleschartTeam.Attributes.Add("data-percent", "0")
                    ' ltsalespercentageTeam.Text += " %"
                Else
                    ltsalespercentageTeam.Text = Math.Round((Convert.ToDouble(ltsalesachivedTeam.Text) / Convert.ToDouble(ltsalestargetTeam.Text)) * 100).ToString
                    divsaleschartTeam.Attributes.Add("data-percent", ltsalespercentageTeam.Text)
                    ltsalespercentageTeam.Text += " %"
                End If
            End If
        End If
    End Sub

End Class
