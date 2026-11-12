
Partial Class UserControl_Back_OpportunityControl
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
                FillOpportunity()
                FillStage()
                FillOwner()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("OpportunityControl", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub FillOpportunity()
        Try
            GridView1.DataSource = OpportunityBLL.ViewOpportunityByAssignType(hftype.Value, hftypeid.Value, Session("UserId"))
            GridView1.DataBind()
            Dim DS As DataSet = DirectCast(GridView1.DataSource, DataSet)
            Dim totalcount As Integer = DS.Tables(0).Rows.Count
            If totalcount > 0 Then
                lblcontact.Text = "Opportunity (" + totalcount.ToString + ")"
            Else
                lblcontact.Text = "No Opportunity"
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("OpportunityControl", "FillOpportunity", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim lbprobability As Literal = DirectCast(e.Row.FindControl("lblProbability"), Literal)
                Dim divprogress As HtmlGenericControl = DirectCast(e.Row.FindControl("divprogress"), HtmlGenericControl)
                divprogress.Style("width") = lbprobability.Text + "%"
                'divprogress.InnerHtml = lbprobability.Text
                lbprobability.Text = lbprobability.Text.Replace("%", "")
                If lbprobability.Text >= 0 And lbprobability.Text <= 20 Then
                    divprogress.Attributes("class") = "progress-bar progress-bar-danger"
                ElseIf lbprobability.Text >= 20 And lbprobability.Text <= 40 Then
                    divprogress.Attributes("class") = "progress-bar progress-bar-warning"
                ElseIf lbprobability.Text >= 40 And lbprobability.Text <= 60 Then
                    divprogress.Attributes("class") = "progress-bar progress-bar-info"
                ElseIf lbprobability.Text >= 60 Then
                    divprogress.Attributes("class") = "progress-bar progress-bar-success"
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("OpportunityControl", "GridView1_RowDataBound", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            GridView1.PageIndex = e.NewPageIndex
            GridView1.DataSource = OpportunityBLL.ViewOpportunityByAssignType(hftype.Value, hftypeid.Value, Session("UserId"))
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("OpportunityControl", "GridView1_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub


    Public Sub FillOwner()
        Try
            ddowner.DataSource = MainBLL.Dropdown("UserDropDown")
            ddowner.DataTextField = "U_FirstName"
            ddowner.DataValueField = "U_ID"
            ddowner.DataBind()
            ddowner.SelectedValue = Session("UserId")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("OpportunityControl", "FillOwner", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillStage()
        Try
            ddstage.DataSource = MainBLL.Dropdown("OpporStageDropDown")
            ddstage.DataTextField = "OppStage_Name"
            ddstage.DataValueField = "OppStage_ID"
            ddstage.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("OpportunityControl", "FillStage", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddstage_TextChanged(sender As Object, e As EventArgs) Handles ddstage.TextChanged
        Try
            If ddstage.SelectedValue = "0" Then
            Else
                lbprobability.Text = OpportunityBLL.GetProbability(ddstage.SelectedValue)
                txtrevenue.Text = (lbprobability.Text * txtamount.Text) / 100
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("OpportunityControl", "ddstage_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub txtamount_TextChanged(sender As Object, e As EventArgs) Handles txtamount.TextChanged
        Try
            lbprobability.Text = OpportunityBLL.GetProbability(ddstage.SelectedValue)
            txtrevenue.Text = (lbprobability.Text * txtamount.Text) / 100
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("OpportunityControl", "txtamount_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            If txtamount.Text = "" Then
                txtamount.Text = 0
            End If
            MainID = OpportunityBLL.Insert(ddowner.SelectedValue, txtname.Text.Trim, "", "", CDate(txtduedate.Text.Trim).ToString("yyyy-MM-dd"),
            "0", "Other", hftype.Value, hftypeid.Value, ddstage.SelectedValue, Session("Audlog_Id"), Session("UserId"), txtamount.Text)
            OpporStageHistoryBLL.Insert(CDate(txtduedate.Text.Trim).ToString("yyyy-MM-dd"), "Opportunity", MainID, ddstage.SelectedValue, Session("Audlog_Id"), Session("UserId"), txtamount.Text)
            Dim count As Integer = 0
            Count = AssignToBLL.MaxAssignTo
            Dim sb As New StringBuilder
            sb.Append("<root>")
            sb.Append("<row Assignto_ID='" & count.ToString & "' Assignto_UserID='" & Session("UserId") &
                     "' Assignto_Type='" & "Opportunity" & "' Assignto_TypeID='" & MainID & "' Assignto_CreatedID='" & Session("UserId") &
                     "' Assignto_CreatedDate='" & DateAndTime.DateString & "' Assignto_ModifiedID='" & Session("UserId") & "' Assignto_ModifiedDate='" & DateAndTime.DateString &
                      "' Assignto_Del='0' Assignto_Status='Active' />")
            count = count + 1
            sb.Append("</root>")
            AssignToBLL.XMLInsert(sb.ToString, Session("Audlog_Id"), hftype.Value)
            FillOpportunity()
            mpe.Hide()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("OpportunityControl", "btnsave_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class
