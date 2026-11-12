
Partial Class MCRMAddAccount
    Inherits _PageBaseClass
    Private MainId As Integer
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                FillddlState()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Lead", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub FillddlState()
        Try
            ddlState.Items.Clear()
            Dim ds As DataSet = MainBLL.DropdownWithID("StateDropDown", 105)
            ddlState.DataSource = ds.Tables(0)
            ddlState.DataTextField = "StateName"
            ddlState.DataValueField = "Id"
            ddlState.DataBind()
            ddlState.Items.Insert(0, New ListItem("Select State", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyAccount", "FillStatebill", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            SaveAccount()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Lead", "btnsave_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub SaveAccount()
        Try
            Dim CheckPageName As String = MainBLL.CheckPageName(txtAccountname.Text.Trim, "AccProNameCheck")
            If (CheckPageName = "Already Exist") Then
                lblname.Text = "Name already exist in Account"
                txtAccountname.Focus()
            Else
                MainId = MCRMBLL.InsertMCRMAccount(txtAccountname.Text.Trim, 0, 0, 0, Session("UserId"), 0, Session("UserId"), Session("Audlog_Id"), "account", txtemail.Text.Trim, "Account", 0, 45)

                MCRMBLL.InsertMCRMAccContact(txtContPerson.Text.Trim, 0, 0, txtmob.Text.Trim, txtofficeno.Text.Trim, txtextention.Text.Trim, txtemail.Text.Trim, 0, 1, "Account", MainId, Session("UserId"), "Email", Session("Audlog_Id"))

                MCRMBLL.InsertMCRMAccAddr(MainId, "Billing", txtAccountname.Text.Trim, txtemail.Text.Trim, txtmob.Text.Trim, txtofficeno.Text.Trim, txtAddress.Text.Trim, txtCity.Text.Trim, ddlState.SelectedValue, 105, txtPin.Text.Trim, Session("UserId"), Session("Audlog_Id"))

                MCRMBLL.InsertMCRMAccAddr(MainId, "Shipping", txtAccountname.Text.Trim, txtemail.Text.Trim, txtmob.Text.Trim, txtofficeno.Text.Trim, txtAddress.Text.Trim, txtCity.Text.Trim, ddlState.SelectedValue, 105, txtPin.Text.Trim, Session("UserId"), Session("Audlog_Id"))

                assigncontrol.AddAssignTo(MainId)
                Response.Redirect("index1.aspx")
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyAccount", "INSERT", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub hfcancel_Click(sender As Object, e As EventArgs) Handles hfcancel.Click
        Try
            Response.Redirect("index1.aspx")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyLead", "hfcancel_Click", error1, Session("UserId"))
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
End Class
