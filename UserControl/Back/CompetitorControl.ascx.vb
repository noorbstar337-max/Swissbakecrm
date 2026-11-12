
Partial Class UserControl_Back_CompetitorControl
    Inherits System.Web.UI.UserControl
    Dim MainID As Integer
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

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                If MainID = 0 Then
                Else
                    FillCompetitors()
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("CompetitorControl", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            CompetitorBLL.Insert(txtname.Text.Trim, hftype.Value, hftypeid.Value, txtamount.Text.Trim, txtremark.Text.Trim, Session("UserId"), Session("Audlog_Id"))
            FillCompetitors()
            mpe.Hide()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("CompetitorControl", "btnsave_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillCompetitors()
        Try
            GridView1.DataSource = CompetitorBLL.ViewCompetitorByType(hftype.Value, hftypeid.Value)
            GridView1.DataBind()
            Dim DS As DataSet = DirectCast(GridView1.DataSource, DataSet)
            Dim totalcount As Integer = DS.Tables(0).Rows.Count
            If totalcount > 0 Then
                lblcontact.Text = "Competitor (" + totalcount.ToString + ")"
            Else
                lblcontact.Text = "No Competitor"
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("CompetitorControl", "FillCompetitors", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            GridView1.PageIndex = e.NewPageIndex
            GridView1.DataSource = CompetitorBLL.ViewCompetitorByType(hftype.Value, hftypeid.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("CompetitorControl", "GridView1_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class
