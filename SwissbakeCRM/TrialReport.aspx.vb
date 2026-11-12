
Partial Class TrialReport

    Inherits System.Web.UI.Page
    Private InvoiceId As Integer
    Public tabss As Integer
    Private maxPage As Integer
    Private minPage As Integer
    Public p1 As String
    Public p2 As String
    Public p3 As String
    Public ds1 As DataSet
    Private dt1 As New DataTable()
    Private dt2 As New DataTable()
    Private dt3 As New DataTable()
    Private pgitems As New PagedDataSource()
    Private s As New Security()
    Public count As Integer
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            If Session("LMSUserRoleId") <> 1 Then
                Response.Redirect("LMSDashboard.aspx")
            End If
            If Session("LMSUserId") = Nothing Then
                TryCast(Me.Master, LMSMasterPage).MaintainSession()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim tempDate As Date = Date.Now.AddMonths(-1).ToString("yyyy-MM-dd")
                Dim startOfMonth As New DateTime(tempDate.Year, tempDate.Month, 1)
                Dim endOfMonth As DateTime = startOfMonth.AddMonths(1).AddDays(-1)
                txtfrom.Text = startOfMonth.ToString("yyyy-MM-dd")
                txtto.Text = endOfMonth.ToString("yyyy-MM-dd")
                fillproduct()
                FillFormulation()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillFormulation()
        Try
            Dim value As String() = ddlProduct.SelectedValue.Split("^")
          
            ds1 = LMSBLL.TrialReport("TrialReport", Session("LMSUserId"), "Trial", ddlMixTypeForm.SelectedValue, ddlFormulationType.SelectedValue, value(0), value(1), txtfrom.Text, txtto.Text)
            dt1 = ds1.Tables(0)
            rpFormulation.DataSource = dt1
            rpFormulation.DataBind()
            If dt1.Rows.Count = 0 Then
                lblNoData.Visible = True
            Else
                lblNoData.Visible = False
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub


    Public Sub fillproduct()
        Try
         
            Dim ds As DataSet
            ds = LMSBLL.ddProduct("FillfProductByID", Session("LMSUserId"), Session("LMSUserRoleID"), ddlFormulationType.SelectedValue, ddlMixTypeForm.SelectedValue)
            ddlProduct.DataSource = ds.Tables(0)
            ddlProduct.DataTextField = "Product_Name"
            ddlProduct.DataValueField = "Product_Id"

            ddlProduct.DataBind()
            ddlProduct.Items.Insert(0, New ListItem("All", "All^-1"))
            'ddlProduct.Items.Insert(0, "Select Product")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btsubmit_Click(sender As Object, e As EventArgs) Handles btsubmit.Click
        Try
            FillFormulation()
        Catch ex As Exception

        End Try
    End Sub

  
    Protected Sub ddlMixTypeForm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMixTypeForm.SelectedIndexChanged
        Try
            fillproduct()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddlFormulationType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlFormulationType.SelectedIndexChanged
        Try
            fillproduct()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class

