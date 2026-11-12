
Partial Class UserControl_Back_OpportunityContactControl
    Inherits System.Web.UI.UserControl
    Dim Count As Integer
    Dim ContactID As Integer
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
    Public Property Uhfopptype() As HiddenField
        Get
            Return Me.hfopptype
        End Get
        Set(value As HiddenField)
            Me.hfopptype = value
        End Set
    End Property
    Public Property Uhfopptypeid() As HiddenField
        Get
            Return Me.hfopptypeid
        End Get
        Set(value As HiddenField)
            Me.hfopptypeid = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                FillContact()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("OpportunityContactControl", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillContact()
        Try
            GridView1.DataSource = ContactBLL.SelectContactByID(hfopptypeid.Value)
            GridView1.DataBind()
            GridView2.DataSource = ContactBLL.ViewUnselectedContact(hftype.Value, hftypeid.Value, hfopptypeid.Value)
            GridView2.DataBind()
            Dim DS As DataSet = DirectCast(GridView1.DataSource, DataSet)
            Dim totalcount As Integer = DS.Tables(0).Rows.Count
            If totalcount > 0 Then
                lblcontact.Text = "Contact (" + totalcount.ToString + ")"
            Else
                lblcontact.Text = "No Contact"
            End If
            For Each row As GridViewRow In GridView2.Rows
                GridView2.HeaderRow.Cells(1).Visible = False
                row.Cells(1).Visible = False
                GridView2.HeaderRow.Cells(6).Visible = False
                row.Cells(6).Visible = False
            Next
            For Each row As GridViewRow In GridView1.Rows
                GridView1.HeaderRow.Cells(3).Visible = False
                row.Cells(3).Visible = False
                GridView1.HeaderRow.Cells(4).Visible = False
                row.Cells(4).Visible = False
                GridView1.HeaderRow.Cells(10).Visible = False
                row.Cells(10).Visible = False
            Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("OpportunityContactControl", "FillContact", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Sub AtLeastOneContact_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        If txtemail.Text & txtofficeno.Text & txtmob.Text <> "" Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            ContactBLL.InsertContact("Mr.", "Male", txtname.Text.Trim, "0", "0", txtemail.Text.Trim,
                                 "", txtmob.Text.Trim, txtofficeno.Text.Trim, "", "", "0", "",
                                hftype.Value, hftypeid.Value, "", Session("UserId"), Session("Audlog_Id"), False, hfopptypeid.Value)
            FillContact()
            mpe.Hide()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("OpportunityContactControl", "btnsave_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnselectcontact_Click(sender As Object, e As EventArgs) Handles btnselectcontact.Click
        Try
            Count = ContactBLL.MaxoppContactID
            Count = Count + 1
            Dim sb As New StringBuilder
            sb.Append("<root>")
            For i As Integer = 0 To GridView2.Rows.Count - 1
                Dim index As Integer = GridView2.Rows(i).RowIndex
                Dim ckselect As CheckBox = DirectCast(GridView2.Rows(i).FindControl("ckselect"), CheckBox)
                ContactID = GridView2.DataKeys(index).Value
                Dim lblname As Literal = DirectCast(GridView2.Rows(i).FindControl("lblname"), Literal)
                If ckselect.Checked = True Then
                    sb.Append("<row OpporCont_Id='" & Count.ToString & "' OpporCont_OportunityId='" & hfopptypeid.Value &
                          "' OpporCont_ContactId='" & ContactID & "' OpporCont_CreatedID='" & Session("UserId") &
                          "' OpporCont_CreatedDate='" & DateAndTime.DateString & "' OpporCont_ModifiedID='" & Session("UserId") & "' OpporCont_ModifiedDate='" & DateAndTime.DateString &
                           "' OpporCont_Del='0' OpporCont_Status='Active' OpporCont_Primary='0' />")
                    Count = Count + 1
                End If
            Next
            sb.Append("</root>")
            ContactBLL.XMLContactInsert(sb.ToString)
            FillContact()
            mpeselectcontact.Hide()
            'AssignToBLL.XMLInsert(sb.ToString, Session("Audlog_Id"), hftype.Value)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("OpportunityContactControl", "btnselectcontact_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Closing" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ContactID = GridView1.DataKeys(index).Value
            Try
                ContactBLL.DeleteOppContact(ContactID)
                FillContact()
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("OpportunityContactControl", "GridView1_RowCommand", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            GridView1.PageIndex = e.NewPageIndex
            GridView1.DataSource = ContactBLL.SelectContactByID(hfopptypeid.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("OpportunityContactControl", "GridView1_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub rbowner_CheckedChanged(sender As Object, e As EventArgs)
        Try
            Dim rd As RadioButton = DirectCast(sender, RadioButton)
            Dim row As GridViewRow = DirectCast(rd.NamingContainer, GridViewRow)
            Dim ContactID As Integer = GridView1.DataKeys(row.RowIndex).Value.ToString()
            Dim lnk As LinkButton = DirectCast(row.FindControl("lnk"), LinkButton)
            'ContactBLL.UpdatePrimaryContact(hftype.Value, hftypeid.Value, ContactID, Session("UserId"), Session("Audlog_Id"))
            ContactBLL.UpdateOpportunityContact(hfopptypeid.Value, ContactID, Session("UserId"), Session("Audlog_Id"))
            FillContact()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("OpportunityContactControl", "rbowner_CheckedChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim row As GridViewRow = e.Row
                Dim data As DataRow = DirectCast(row.DataItem, DataRowView).Row
                Dim rbowner As RadioButton = DirectCast(e.Row.FindControl("rbowner"), RadioButton)
                Dim lnk As LinkButton = DirectCast(e.Row.FindControl("lnk"), LinkButton)
                If rbowner.Checked = True Then
                    lnk.Visible = False
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("OpportunityContactControl", "GridView1_RowDataBound", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class
