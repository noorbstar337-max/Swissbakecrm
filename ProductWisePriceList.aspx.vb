
Partial Class ProductWisePriceList
    Inherits System.Web.UI.Page
    Dim ProdID As String
    Dim Type As String
    Dim ord As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                ProdID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                Type = (Request.QueryString("Type"))
                ord = (Request.QueryString("ord"))
                FillHeader()
                FillrpPriceList()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub FillHeader()
        Try
            Dim ds As DataSet = reportBLL.FillProdName(ProdID)
            lblProdName.Text = ds.Tables(0).Rows(0)(1)
            lblSKU.Text = ds.Tables(0).Rows(0)(3)
            lblRate.Text = ds.Tables(0).Rows(0)(2)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub FillrpPriceList()
        Try
            rpPriceList.DataSource = reportBLL.FillPriceList(ProdID, Type, ord)
            rpPriceList.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            '  ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("UserId")) 'ExpenseDetail", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class
