
Partial Class SupportAddLead
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Session("UserRoleID") = 4 Then
                txtleaddate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                If Not IsPostBack Then
                    FillAssignTo()
                End If
            Else
                Response.Redirect("Login.aspx")
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SupportAddLead", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub FillAssignTo()
        Try
            ddlAssignTo.DataSource = MainBLL.Dropdown("LeadSupportAsgnDD")
            ddlAssignTo.DataTextField = "U_FirstName"
            ddlAssignTo.DataValueField = "U_ID"
            ddlAssignTo.DataBind()
            ddlAssignTo.Items.Insert(0, New ListItem("Select", "-1"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SupportAddLead", "FillLeadType", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            SaveProduct()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Lead", "btnsave_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Private Sub SaveProduct()
        Try
            'Dim CheckPageName As String = MainBLL.CheckPageName(txtleadname.Text.Trim, "AccProNameCheck")
            'If (CheckPageName = "Already Exist") Then
            '    lblname.Text = "name already exist"
            '    txtleadname.Focus()
            '    ' fillLead()
            '    ' mpe.Show()
            'ElseIf (CheckPageName = "Account") Then
            '    lblname.Text = "name already exist in Account"
            '    txtleadname.Focus()
            'ElseIf (CheckPageName = "Prospect") Then
            '    lblname.Text = "name already exist in Prospect"
            '    txtleadname.Focus()
            If lblname.Visible = False And lblErrEmail.Visible = False Then

                Dim MainId As Integer = LeadBLL.QuickInsert(txtleaddate.Text.Trim, txtleadname.Text.Trim, 1, ddlAssignTo.SelectedValue, Session("UserId"), Session("Audlog_Id"))
                'Dim MainId As Integer = LeadBLL.QuickInsert(txtleaddate.Text.Trim, txtleadname.Text.Trim, 1, Session("UserId"), Session("UserId"), Session("Audlog_Id"))
                LeadContactBLL.QuickInsert(txtname.Text.Trim, txtemail.Text.Trim, txtmob.Text.Trim, txtofficeno.Text.Trim, txtextention.Text.Trim, Session("UserId"), MainId, Session("Audlog_Id"), True, "Email")
                LeadAddressBLL.Insert("", "", 0, 105, "", Session("UserId"), MainId, "Billing", Session("Audlog_Id"))
                Dim count As Integer = 0
                count = AssignToBLL.MaxAssignTo
                Dim sb As New StringBuilder
                sb.Append("<root>")
                sb.Append("<row Assignto_ID='" & count.ToString & "' Assignto_UserID='" & ddlAssignTo.SelectedValue &
                        "' Assignto_Type='" & "Lead" & "' Assignto_TypeID='" & MainId & "' Assignto_CreatedID='" & Session("UserId") &
                        "' Assignto_CreatedDate='" & DateAndTime.DateString & "' Assignto_ModifiedID='" & Session("UserId") & "' Assignto_ModifiedDate='" & DateAndTime.DateString &
                         "' Assignto_Del='0' Assignto_Status='Active' />")
                
                count = count + 1
                sb.Append("</root>")
                AssignToBLL.XMLInsert(sb.ToString, Session("Audlog_Id"), "Lead")
                
                Response.Redirect("SupportDashBoard.aspx")
            Else
                If lblname.Visible = True Then
                    txtleadname.Focus()
                Else
                    txtemail.Focus()
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SupportAddLead", "SaveProduct", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Sub AtLeastOneContact_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Try
            If txtemail.Text & txtofficeno.Text & txtmob.Text <> "" Then
                args.IsValid = True
            Else
                args.IsValid = False
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SupportAddLead", "AtLeastOneContact_ServerValidate", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub txtleadname_TextChanged(sender As Object, e As EventArgs) Handles txtleadname.TextChanged
        Try
            Dim CheckPageName As String = MainBLL.CheckPageName(txtleadname.Text.Trim, "AccProNameCheck")
            If (CheckPageName = "Already Exist") Then
                lblname.Visible = True
                lblname.Text = "name already exist"
                txtleadname.Focus()
               
            ElseIf (CheckPageName = "Account") Then
                lblname.Visible = True
                lblname.Text = "name already exist in Account"
                txtleadname.Focus()
            ElseIf (CheckPageName = "Prospect") Then
                lblname.Visible = True
                lblname.Text = "Name already exist in Prospect"
                txtleadname.Focus()
            Else
                lblname.Visible = False
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SupportAddLead", "txtleadname_TextChanged", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub txtemail_TextChanged(sender As Object, e As EventArgs) Handles txtemail.TextChanged
        Try
            Dim CheckPageName As String = MainBLL.CheckPageName(txtemail.Text.Trim, "AccProEmailCheck")
            If (CheckPageName = "Already Exist") Then
                lblErrEmail.Visible = True
                lblErrEmail.Text = "Email already exist"
                txtleadname.Focus()
            Else
                lblErrEmail.Visible = False
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SupportAddLead", "txtemail_TextChanged", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class
