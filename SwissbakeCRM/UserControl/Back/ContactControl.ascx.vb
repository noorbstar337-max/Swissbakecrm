
Partial Class UserControl_Back_ContactControl
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
                    FillContact()
                    FillDesignation()
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ContactControl", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillContact()
        Try
            GridView1.DataSource = ContactBLL.ContactByID(hftype.Value, hftypeid.Value, 0)
            GridView1.DataBind()
            Dim DS As DataSet = DirectCast(GridView1.DataSource, DataSet)
            Dim totalcount As Integer = DS.Tables(0).Rows.Count
            If totalcount > 0 Then
                lblcontact.Text = "Contact (" + totalcount.ToString + ")"
            Else
                lblcontact.Text = "No Contact"
            End If
            For Each row As GridViewRow In GridView1.Rows
                If Session("UserRoleID") = "4" Then
                    GridView1.HeaderRow.Cells(1).Visible = False
                    row.Cells(1).Visible = False
                End If
                GridView1.HeaderRow.Cells(2).Visible = False
                row.Cells(2).Visible = False
                GridView1.HeaderRow.Cells(7).Visible = False
                row.Cells(7).Visible = False
            Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ContactControl", "FillContact", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub rbowner_CheckedChanged(sender As Object, e As EventArgs)
        Try
            Dim rd As RadioButton = DirectCast(sender, RadioButton)
            Dim row As GridViewRow = DirectCast(rd.NamingContainer, GridViewRow)
            Dim ContactID As Integer = GridView1.DataKeys(row.RowIndex).Value.ToString()
            ContactBLL.UpdatePrimaryContact(hftype.Value, hftypeid.Value, ContactID, Session("UserId"), Session("Audlog_Id"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ContactControl", "rbowner_CheckedChanged", error1, Session("UserId"))
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
            ContactBLL.Insert("Mr.", "Male", txtname.Text.Trim, ddldesignation.SelectedValue, "0", txtemail.Text.Trim,
                                 "", txtmob.Text.Trim, txtofficeno.Text.Trim, "", "", "0", "",
                                hftype.Value, hftypeid.Value, "", Session("UserId"), Session("Audlog_Id"), False, ddlnotifyby.SelectedValue)
            FillContact()
            mpe.Hide()
            txtname.Text = ""
            txtemail.Text = ""
            txtmob.Text = ""
            txtofficeno.Text = ""
            ddldesignation.SelectedValue = "0"
            ddlnotifyby.SelectedValue = "0"
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ContactControl", "btnsave_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            GridView1.PageIndex = e.NewPageIndex
            GridView1.DataSource = ContactBLL.ContactByID(hftype.Value, hftypeid.Value, 0)
            GridView1.DataBind()
            For Each row As GridViewRow In GridView1.Rows
                GridView1.HeaderRow.Cells(2).Visible = False
                row.Cells(2).Visible = False
                GridView1.HeaderRow.Cells(7).Visible = False
                row.Cells(7).Visible = False
            Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ContactControl", "GridView1_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub FillDesignation()
        Dim ds As DataSet = MainBLL.Dropdown("B2bDesignationDropDown")
        ddldesignation.DataSource = ds.Tables(0)
        ddldesignation.DataTextField = "Desig_Name"
        ddldesignation.DataValueField = "Desig_Id"
        ddldesignation.DataBind()
    End Sub
End Class
