
Partial Class trialdatecheck
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        '' txtGetdate.Text = Date.Now.Date.AddDays(-1).ToString("yyyy-MM-dd")
        If Not IsPostBack Then

            txtDate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            txtDate.Attributes("min") = DateTime.Now.ToString("yyyy-MM-dd")
            lbltest.Text = txtDate.Text
        End If
    End Sub

    Protected Sub txtDate_TextChanged(sender As Object, e As EventArgs) Handles txtDate.TextChanged
        lbltest.Text = txtDate.Text
    End Sub

    Protected Sub ddlDate_TextChanged(sender As Object, e As EventArgs) Handles ddlDate.TextChanged
        lbltest.Text = ddlDate.Text
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        LMSBLL.InsertFormulation(1, 1, 1,
                                                                           1, "Product", 1, 0.01, Session("LMSUserId"),
                                                                           1, 1, ddlDate.Text, False, -1)
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LMSBLL.InsertFormulation(1, 1, 1,
                                                                         1, "Product", 1, 0.01, Session("LMSUserId"),
                                                                         1, 1, txtDate.Text, False, -1)
    End Sub
End Class
