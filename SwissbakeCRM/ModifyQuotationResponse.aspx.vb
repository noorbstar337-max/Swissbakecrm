
Partial Class ModifyQuotationResponse
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        lbltitle1.Text = " Quotation Response"
    End Sub
    Protected Sub hfcancel_Click(sender As Object, e As EventArgs) Handles hfcancel.Click
        Response.Redirect("QuotationResponse.aspx")
    End Sub
End Class
