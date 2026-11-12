
Partial Class UserControl_Back_QuotationControl
    Inherits System.Web.UI.UserControl
#Region "User Control Property"
    Public Property Uhftype() As HiddenField
        Get
            Return Me.hftype
        End Get
        Set(value As HiddenField)
            Me.hftype = value
        End Set
    End Property
    Public Property Uhftypeid() As HiddenField
        Get
            Return Me.hftypeid
        End Get
        Set(value As HiddenField)
            Me.hftypeid = value
        End Set
    End Property
#End Region

#Region "Method"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillQuotation()
        End If
    End Sub

    Public Sub FillQuotation()
        Try
            grdquotation.DataSource = QuotationBLL.QuotationByType(Session("UserId"), hftypeid.Value, hftype.Value)
            grdquotation.DataBind()
            Dim DS As DataSet = DirectCast(grdquotation.DataSource, DataSet)
            Dim totalcount As Integer = DS.Tables(0).Rows.Count
            If totalcount > 0 Then
                ltstage.Text = "Quotation (" + totalcount.ToString + ")"
            Else
                ltstage.Text = "No Quotation"
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("View" + hftype.Value + "", "FillQuotation", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btncomposeemail_Click(sender As Object, e As EventArgs) Handles btncomposeemail.Click
        Response.Redirect("ModifyQuotation.aspx?id=" + HttpUtility.UrlEncode(Security.Encrypt(hftypeid.Value)) + "&type=" + HttpUtility.UrlEncode(Security.Encrypt(hftype.Value)) + "&returnurl=" + HttpUtility.UrlEncode(Security.Encrypt(Request.Url.AbsoluteUri.ToString)))
    End Sub

    Protected Sub grdquotation_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdquotation.PageIndexChanging
        Try
            grdquotation.PageIndex = e.NewPageIndex
            grdquotation.DataSource = QuotationBLL.QuotationByType(Session("UserId"), hftypeid.Value, hftype.Value)
            grdquotation.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ActivityUserControl", "GridView2_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
#End Region

End Class
